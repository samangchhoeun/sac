Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmStockCarts
    Dim DrugItemType As String = "Pharmacy"
    Dim DrugMasterCode As Integer = 0

    Private Sub frmStockCarts_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmStockCarts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitGeneric()
        InitMedForm()
        InitMedClassification()
        'InitShelf()
        'LoadDrugStockCartByItem()
        LoadMedicationList()
        txtDrugBrandName.Select()
        If isLoggedInOwner Then bbiPRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub

    Private Sub ClearAllContent()
        DrugMasterCode = 0
        txtMedCode.Text = "***"
        txtBarcode.Text = ""
        txtDrugBrandName.Text = ""
        txtStrength.Text = ""
        txtVolume.Text = ""
        txtMinStockAlert.Text = ""
        txtMaxSOH.Text = ""
        txtTotalSOH.Text = ""
        txtTotalValuetoDate.Text = ""
        lueDrugGenericName.EditValue = -1
        lueDrugForm.EditValue = -1
        lueDrugClassification.EditValue = -1
        meSpec.Text = ""
        gvSuppliers.Columns.Clear()
        gcSuppliers.DataSource = Nothing
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        btnNew.Enabled = False
        txtDrugBrandName.Focus()
    End Sub

    Private Sub btnGenericName_Click(sender As Object, e As EventArgs) Handles btnGenericName.Click
        frmViewGenericName.PageRefresh = " frmStockCarts"
        LoadForm(frmViewGenericName)
    End Sub

    Private Sub btnForm_Click(sender As Object, e As EventArgs) Handles btnForm.Click
        frmViewMedicalForm.PageRefresh = " frmStockCarts"
        LoadForm(frmViewMedicalForm)
    End Sub

    Public Sub InitGeneric()
        Try
            GetDataToComboBoxWithParam(lueDrugGenericName, "SA_GetGenericNameByID", "TranID", "GenericEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Stock Carts", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub InitMedForm()
        Try
            GetDataToComboBoxWithParam(lueDrugForm, "SA_GetMedicalFormByID", "TranID", "FormEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Stock Carts", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub InitMedClassification()
        Try
            GetDataToComboBoxWithParam(lueDrugClassification, "SA_GetMedicalClassificationByID", "TranID", "ClassificationEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Stock Carts", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    'Public Sub InitShelf()
    '    Try
    '        GetDataToComboBoxWithParam(lueShelf, "SA_GetShelfByID", "ShelfCode", "ShelfEn", New SqlParameter("@ID", 0), New SqlParameter("@ClinicID", IIf(isLoggedInOwner, 0, ConfigClinic.ClinicID)), New SqlParameter("@isList", 1))
    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message, "Stock Carts", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End Try
    'End Sub

    Private Sub btnClassification_Click(sender As Object, e As EventArgs) Handles btnClassification.Click
        frmViewMedicalClassification.PageRefresh = " frmStockCarts"
        LoadForm(frmViewMedicalClassification)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtDrugBrandName.Text.Trim) Then
            XtraMessageBox.Show("Please enter medication name", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDrugBrandName.Focus()
            Return
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveStockCarts", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@DrugMasterCode", DrugMasterCode)
                .AddWithValue("@DrugCode", IIf(txtMedCode.Text.Trim = "***", 0, txtMedCode.Text.Trim))
                .AddWithValue("@Barcode", txtBarcode.Text.Trim)
                .AddWithValue("@DrugBrandName", txtDrugBrandName.Text.Trim)
                .AddWithValue("@DrugGenericName", lueDrugGenericName.EditValue)
                .AddWithValue("@DrugForm", lueDrugForm.EditValue)
                .AddWithValue("@Strength", txtStrength.Text.Trim)
                .AddWithValue("@Volume", txtVolume.Text.Trim)
                .AddWithValue("@DrugSpecification", meSpec.Text.Trim)
                .AddWithValue("@DrugClassification", lueDrugClassification.EditValue)
                .AddWithValue("@MinSOH", IIf(txtMinStockAlert.Text.Trim = "", 0, txtMinStockAlert.Text.Trim))
                .AddWithValue("@MaxSOH", IIf(txtMaxSOH.Text.Trim = "", 0, txtMaxSOH.Text.Trim))
                .AddWithValue("@TotalSOH", IIf(txtTotalSOH.Text.Trim = "", 0, txtTotalSOH.Text.Trim))
                .AddWithValue("@TotalValuetoDate", IIf(txtTotalValuetoDate.Text.Trim = "", 0, txtTotalValuetoDate.Text.Trim))
                .AddWithValue("@DrugItemType", DrugItemType)
                .AddWithValue("@Branch", ConfigClinic.Clinic)
                .AddWithValue("@User", LogUserNo)
                .Add("@isAdd", SqlDbType.Int)
                cmd.Parameters("@isAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
                .Add("@TDrugCode", SqlDbType.NVarChar, 20)
                cmd.Parameters("@TDrugCode").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            LoadMedicationList()
            Dim mms As MessageBoxIcon = MessageBoxIcon.Error
            If CBool(chkClearAfterSave.Checked) Then
                If Convert.ToInt16(cmd.Parameters("@isAdd").Value) <> 0 Then
                    mms = MessageBoxIcon.Information
                End If
                btnNew_Click(Nothing, Nothing)
            Else
                If Convert.ToInt16(cmd.Parameters("@isAdd").Value) <> 0 Then
                    mms = MessageBoxIcon.Information
                    btnSave.Enabled = False
                    btnSave.Text = "Update"
                End If
                btnNew.Enabled = True
                btnNew.Focus()
            End If
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Create Medication", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMedicationList(Optional _DrugMasterCode As Integer = 0)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetDrugMasterList", New SqlParameter("@DrugMasterCode", _DrugMasterCode), New SqlParameter("@MedCode", ""), New SqlParameter("@DrugItemType", DrugItemType))
            If dt.Rows.Count > 0 Then
                gcMedications.DataSource = dt
                With gvMedications
                    .PopulateColumns()
                    .Columns("DrugMasterCode").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("BrandName").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("GenericName").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            Else
                gcMedications.DataSource = Nothing
                gvMedications.Columns.Clear()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Stock Carts", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub LoadSupplier(Optional _DrugMasterCode As Integer = 0)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetSupplierForStockCart", New SqlParameter("@DrugMasterCode", _DrugMasterCode))
            If dt.Rows.Count > 0 Then
                gcSuppliers.DataSource = dt
                With gvSuppliers
                    .PopulateColumns()
                    .Columns("InvoiceMedicalStockInCode").Visible = False
                    .Columns("DrugMasterCode").Visible = False
                    .Columns("DrugDetailCode").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("SupplierName").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near

                    .Columns("Quantity").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("Quantity").SummaryItem.DisplayFormat = "Count: {0}"
                    .Columns("StockOnHand").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("StockOnHand").SummaryItem.DisplayFormat = "Count: {0}"
                    .Columns("Dispensed").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("Dispensed").SummaryItem.DisplayFormat = "Count: {0}"
                    .BestFitColumns()
                End With
            Else
                gcSuppliers.DataSource = Nothing
                gvSuppliers.Columns.Clear()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Suppliers", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub LoadDrugStockCartByItem(Optional _DrugMasterCode As Integer = 0)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetDrugMasterList", New SqlParameter("@DrugMasterCode", _DrugMasterCode), New SqlParameter("@MedCode", ""), New SqlParameter("@DrugItemType", DrugItemType))
            If dt.Rows.Count = 1 Then
                With dt.Rows(0)
                    DrugMasterCode = CInt(.Item("DrugMasterCode"))
                    txtMedCode.Text = .Item("DrugCode").ToString
                End With
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Stock Carts", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub lueDrugGenericName_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueDrugGenericName.Closed
        lueDrugForm.Focus()
    End Sub

    Private Sub lueForm_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueDrugForm.Closed
        lueDrugClassification.Focus()
    End Sub

    Private Sub lueMedClass_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueDrugClassification.Closed
        txtStrength.Focus()
    End Sub

    Private Sub gcMedications_MouseClick(sender As Object, e As MouseEventArgs) Handles gcMedications.MouseClick
        If gvMedications.RowCount > 0 Then If e.Button = MouseButtons.Right Then ppMedical.ShowPopup(Me.bmMedical, Control.MousePosition)
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            With gvMedications
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _DMCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "DrugMasterCode").ToString)
                Dim _DMName As String = .GetRowCellValue(.FocusedRowHandle, "BrandName").ToString
                SelectMedicationInfo(_DMCode, _DMName)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub SelectMedicationInfo(Optional _DrugMasterCode As Integer = 0, Optional _DrugName As String = "", Optional _MedCode As String = "")
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetDrugMasterList", New SqlParameter("@DrugMasterCode", _DrugMasterCode), New SqlParameter("@MedCode", _MedCode), New SqlParameter("@DrugItemType", DrugItemType))
            With dtData
                If .Rows.Count = 1 Then
                    btnNew.Enabled = True
                    DrugMasterCode = CInt(.Rows(0)("DrugMasterCode"))
                    txtMedCode.Text = .Rows(0)("DrugCode").ToString
                    txtBarcode.Text = .Rows(0)("Barcode").ToString
                    meSpec.Text = .Rows(0)("DrugSpecification").ToString
                    txtDrugBrandName.Text = .Rows(0)("DrugBrandName").ToString
                    If CInt(IIf(String.IsNullOrEmpty(.Rows(0)("DrugGenericName").ToString), 0, .Rows(0)("DrugGenericName"))) > 0 Then
                        lueDrugGenericName.EditValue = CInt(.Rows(0)("DrugGenericName"))
                    Else
                        lueDrugGenericName.EditValue = -1
                    End If
                    If CInt(IIf(String.IsNullOrEmpty(.Rows(0)("DrugForm").ToString), 0, .Rows(0)("DrugForm"))) > 0 Then
                        lueDrugForm.EditValue = CInt(.Rows(0)("DrugForm"))
                    Else
                        lueDrugForm.EditValue = -1
                    End If
                    If CInt(IIf(String.IsNullOrEmpty(.Rows(0)("DrugClassification").ToString), 0, .Rows(0)("DrugClassification"))) > 0 Then
                        lueDrugClassification.EditValue = CInt(.Rows(0)("DrugClassification"))
                    Else
                        lueDrugClassification.EditValue = -1
                    End If
                    txtStrength.Text = .Rows(0)("Strength").ToString
                    txtVolume.Text = .Rows(0)("Volume").ToString
                    txtMinStockAlert.Text = .Rows(0)("MinSOH").ToString
                    txtMaxSOH.Text = .Rows(0)("MaxSOH").ToString
                    txtTotalSOH.Text = .Rows(0)("TotalSOH").ToString
                    txtTotalValuetoDate.Text = .Rows(0)("TotalValueToDate").ToString
                    LoadSupplier(DrugMasterCode)
                    frmSearchMedication.Dispose()
                    txtDrugBrandName.Focus()
                Else
                    XtraMessageBox.Show("Searching keyword: " + _DrugName.ToString + " does not exist on the target system.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMinStockAlert_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMinStockAlert.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub gcSuppliers_MouseClick(sender As Object, e As MouseEventArgs) Handles gcSuppliers.MouseClick
        If gvSuppliers.RowCount > 0 Then If e.Button = MouseButtons.Right Then ppSuppliers.ShowPopup(Me.bmSuppliers, Control.MousePosition)
    End Sub

    Private Sub DisabledItems(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisableMedication", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@Inactive", _Inactive)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsUpdate", SqlDbType.Int)
                cmd.Parameters("@IsUpdate").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsUpdate").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error
            LoadMedicationList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Stock Carts", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            With gvMedications
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _Name As String = .GetRowCellValue(.FocusedRowHandle, "BrandName").ToString
                detected = XtraMessageBox.Show("Do you want to delete medication <<" + _Name + ">> from the list?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _DMCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "DrugMasterCode").ToString)
                DisabledItems(_DMCode.ToString, 1)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        Try
            With gvMedications
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to restore the selected medications?", "Confirm Restore?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _DMCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "DrugMasterCode").ToString)
                DisabledItems(_DMCode.ToString)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        'Try
        '    Dim SelRows() As Integer = gvMedications.GetSelectedRows()
        '    If SelRows.Count <= 0 Then
        '        XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    End If

        '    Dim _IDTempList As String = ""
        '    Dim _TempID(SelRows.Count) As String
        '    Dim i As Integer = 0
        '    Dim MyChar() As Char = {","c, " "c, "|"c}
        '    For Each index As Integer In SelRows
        '        If index >= 0 Then
        '            Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
        '            _TempID(i) = SelectedRow("DrugMasterCode").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to restore the selected medications?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub txtMedCode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMedCode.KeyUp
        If (e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control) Then
            frmSearchMedication.Opt = "search_medication"
            LoadFormDialog(frmSearchMedication)
        End If
    End Sub

    Private Sub txtBarcode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyUp
        txtMedCode_KeyUp(sender, e)
    End Sub

    Private Sub txtDrugBrandName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDrugBrandName.KeyUp
        txtMedCode_KeyUp(sender, e)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmSearchMedication.Opt = "search_medication"
        LoadFormDialog(frmSearchMedication)
    End Sub

    Private Sub gvMedications_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gvMedications.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As Boolean = CBool(.GetRowCellValue(e.RowHandle, .Columns(11)))
            If tempVal Then
                e.Appearance.BackColor = Color.Gainsboro
                e.Appearance.ForeColor = Color.FromArgb(&HFF, &H0, &H33)
            End If
        End With
    End Sub

    Private Sub gvSuppliers_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles gvSuppliers.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As Decimal = CDec(.GetRowCellValue(e.RowHandle, .Columns(5)))
            If tempVal = 0 Then
                e.Appearance.BackColor = Color.FromArgb(&HFF, &HCC, &HCC)
                e.Appearance.ForeColor = Color.FromArgb(&H99, &H0, &H0)
            End If
        End With
    End Sub

    Private Sub bbiPGotoStockIn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPGotoStockIn.ItemClick
        Try
            With gvSuppliers
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                frmMedicationStockIn.Opt = "stock-carts"
                Dim _IVNumber As String = .GetRowCellValue(.FocusedRowHandle, "InvoiceNumber").ToString
                Dim _DDCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "DrugDetailCode"))
                frmMedicationStockIn.SearchMedicationByInvoice(_IVNumber.ToString)
                frmMedicationStockIn.SelectMedicationToEdit(_DDCode)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Oops! " + ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bbiPModifyExpireDate_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModifyExpireDate.ItemClick
        Try
            With gvSuppliers
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _listMed As New MedicationExpiredDate
                _listMed.InvoiceNo = .GetRowCellValue(.FocusedRowHandle, "InvoiceNumber").ToString
                _listMed.MedCode = txtMedCode.Text.Trim
                _listMed.BrandName = txtDrugBrandName.Text.Trim
                _listMed.Quantity = .GetRowCellValue(.FocusedRowHandle, "Quantity").ToString
                _listMed.SOH = .GetRowCellValue(.FocusedRowHandle, "StockOnHand").ToString
                _listMed.ExpiredDate = .GetRowCellValue(.FocusedRowHandle, "ExpiredDate").ToString
                _listMed.DrugDetailCode = .GetRowCellValue(.FocusedRowHandle, "DrugDetailCode").ToString
                _listMed.DrugMasterCode = .GetRowCellValue(.FocusedRowHandle, "DrugMasterCode").ToString
                If Not String.IsNullOrEmpty(.GetRowCellValue(.FocusedRowHandle, "DrugDetailCode").ToString) Then
                    frmModifyExpireDate.LoadMedExpiredDate(_listMed)
                    LoadFormDialog(frmModifyExpireDate)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Oops! " + ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class