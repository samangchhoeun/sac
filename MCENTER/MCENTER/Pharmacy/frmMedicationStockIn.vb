Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmMedicationStockIn
    Dim DrugItemType As String = "Pharmacy"
    Dim ComboGenericClick As Boolean = False
    Dim BeforeUpdateQty As Decimal = 0
    Dim BeforeAdjSOH As Decimal = 0
    Dim InvoiceMedicalStockInCode As Integer = 0
    Dim DrugDetailCode As Integer = 0
    Dim DrugMasterCodeBeforeUpdate As Integer = 0
    Dim IsModifiedMedication As Boolean = False
    Public AdjustmentReason As String = ""
    Public listMed As New List(Of Medication)
    Public Opt As String = ""

    Private Sub frmMedicationStockIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deDateReceived.DateTime = Now.Date
        deExpiredDate.DateTime = Now.Date
        InitWarehouse()
        InitSuppliers()
        InitGeneric()
        InitMedication()
        InitCountry()
        InitMedicationHeader()
    End Sub

    Public Sub InitCountry()
        Try
            GetDataToComboBoxWithParam(lueMadein, "SA_GetCountryList", "ID", "Country")
            lueMadein.EditValue = 29
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub InitWarehouse()
        Try
            GetDataToComboBoxWithParam(lueWarehouse, "SA_GetClinicByID", "ClinicID", "ClinicEn",
                                       New SqlParameter("@ID", 0),
                                       New SqlParameter("@isList", 1))
            lueWarehouse.EditValue = ConfigClinic.ClinicID
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub InitGeneric()
        Try
            GetDataToComboBoxFitColWithParam(lueGenericName, "SA_GetBrandGenNameByID", "DrugMasterCode", "GenericName",
                                       New SqlParameter("@ID", 0),
                                       New SqlParameter("@isList", 2),
                                       New SqlParameter("@Branch", ConfigClinic.Clinic),
                                       New SqlParameter("@DrugItemType", DrugItemType))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub InitMedication()
        Try
            GetDataToComboBoxFitColWithParam(lueBrandName, "SA_GetBrandGenNameByID", "DrugMasterCode", "BrandName",
                                       New SqlParameter("@ID", 0),
                                       New SqlParameter("@isList", 1),
                                       New SqlParameter("@Branch", ConfigClinic.Clinic),
                                       New SqlParameter("@DrugItemType", DrugItemType))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub InitSuppliers()
        Try
            GetDataToComboBoxFitColWithParam(lueSupplierName, "SA_GetSuppliersByID", "CompanyID", "Company",
                                       New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub GetSearchDataByID(Find_ID As Integer)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetSuppliersByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", 0))
            With dtData
                If .Rows.Count = 1 Then
                    meAddress.Text = .Rows(0)("Address").ToString
                    txtContactPerson.Text = .Rows(0)("ContactPerson").ToString
                    txtContactNumber.Text = .Rows(0)("CellPhone").ToString
                    txtRefInvoiceNo.Focus()
                Else
                    meAddress.Text = ""
                    txtContactPerson.Text = ""
                    txtContactNumber.Text = ""
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lueSupplierName_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueSupplierName.Closed
        Try
            GetSearchDataByID(CInt(lueSupplierName.EditValue))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBrowseSuppliers_Click(sender As Object, e As EventArgs) Handles btnBrowseSuppliers.Click
        frmViewSupplier.PageRefresh = " frmMedicationStockIn"
        LoadForm(frmViewSupplier)
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        ValidDecimal(sender, e)
    End Sub

    'Public Sub SelectMedicationInfo(Optional _DrugMasterCode As Integer = 0, Optional _DrugName As String = "", Optional _MedCode As String = "")
    '    Try
    '        Dim dtData As DataTable = GetDataFromDBToTable("SA_GetDrugMasterList", New SqlParameter("@DrugMasterCode", _DrugMasterCode), New SqlParameter("@MedCode", _MedCode), New SqlParameter("@DrugItemType", DrugItemType))
    '        With dtData
    '            If .Rows.Count = 1 Then
    '                If ComboGenericClick Then
    '                    lueBrandName.EditValue = CInt(.Rows(0)("DrugMasterCode"))
    '                Else
    '                    lueGenericName.EditValue = CInt(.Rows(0)("DrugMasterCode"))
    '                End If
    '                txtForm.Text = .Rows(0)("Form").ToString
    '                txtStrength.Text = .Rows(0)("Strength").ToString
    '                lueMadein.Focus()
    '            Else
    '                If ComboGenericClick Then
    '                    lueBrandName.EditValue = -1
    '                Else
    '                    lueGenericName.EditValue = -1
    '                End If
    '                txtForm.Text = ""
    '                txtStrength.Text = ""
    '                lueMadein.Focus()
    '            End If
    '        End With
    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub lueBrandName_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueBrandName.Closed
        ComboGenericClick = False
        Try
            With lueBrandName
                lueGenericName.EditValue = .EditValue
                txtStrength.Text = .GetColumnValue("Strength").ToString
                txtForm.Text = .GetColumnValue("Form").ToString
            End With
            lueMadein.Focus()
        Catch ex As Exception
            txtForm.Text = ""
            txtStrength.Text = ""
        End Try
        'SelectMedicationInfo(CInt(lueBrandName.EditValue), lueBrandName.Text.Trim)
    End Sub

    Private Sub lueGenericName_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueGenericName.Closed
        ComboGenericClick = True
        Try
            With lueGenericName
                lueBrandName.EditValue = .EditValue
                txtStrength.Text = .GetColumnValue("Strength").ToString
                txtForm.Text = .GetColumnValue("Form").ToString
            End With
            lueMadein.Focus()
        Catch ex As Exception
            txtForm.Text = ""
            txtStrength.Text = ""
        End Try
        'SelectMedicationInfo(CInt(lueGenericName.EditValue), lueGenericName.Text.Trim)
    End Sub

    Private Sub ClearAllContent()
        InvoiceMedicalStockInCode = 0
        txtInvoiceNo.Text = "***"
        txtRefInvoiceNo.Text = ""
        Try
            lueWarehouse.EditValue = ConfigClinic.ClinicID
        Catch ex As Exception
            lueWarehouse.EditValue = -1
        End Try
        deDateReceived.DateTime = Now.Date
        txtReceivedBy.Text = ""
        meRermark.Text = ""
        lueSupplierName.EditValue = -1
        meAddress.Text = ""
        txtContactPerson.Text = ""
        txtContactNumber.Text = ""
        ClearMedication()
        gvMedication.Columns.Clear()
        gcMedication.DataSource = Nothing
    End Sub

    Private Sub ClearMedication()
        ComboGenericClick = False
        IsModifiedMedication = False
        AdjustmentReason = ""
        DrugDetailCode = 0
        BeforeUpdateQty = 0
        DrugMasterCodeBeforeUpdate = 0
        BeforeAdjSOH = 0
        lueBrandName.EditValue = -1
        lueGenericName.EditValue = -1
        lueMadein.EditValue = 29
        txtStrength.Text = ""
        txtForm.Text = ""
        txtLots.Text = ""
        txtQuantity.Text = ""
        txtMakeup.Text = ""
        txtRealCost.Text = ""
        txtRetailCost.Text = ""
        lueBrandName.ReadOnly = False
        lueGenericName.ReadOnly = False
        deExpiredDate.DateTime = Now.Date
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnAddToList_Click(sender As Object, e As EventArgs) Handles btnAddToList.Click
        If CInt(lueWarehouse.EditValue) <= 0 Then
            XtraMessageBox.Show("Oops! The warehouse is required.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lueWarehouse.Focus()
            Return
        ElseIf CInt(lueSupplierName.EditValue) <= 0 Then
            XtraMessageBox.Show("Oops! The supplier is required.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lueSupplierName.Focus()
            Return
        ElseIf CInt(lueBrandName.EditValue) <= 0 OrElse CInt(lueSupplierName.EditValue) <= 0 Then
            XtraMessageBox.Show("Oops! Medication info is required.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lueBrandName.Focus()
            Return
        ElseIf String.IsNullOrEmpty(txtReceivedBy.Text.Trim) Then
            XtraMessageBox.Show("Please fill in person received items.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReceivedBy.Focus()
            Return
            'ElseIf Convert.ToDecimal(IIf(txtQuantity.Text.Trim = "", 0, txtQuantity.Text.Trim)) <= 0 Then
            '    XtraMessageBox.Show("Please input quantity.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtQuantity.Focus()
            '    Return
            'ElseIf Convert.ToDecimal(IIf(txtRealCost.Text.Trim = "", 0, txtRealCost.Text.Trim)) <= 0 Then
            '    XtraMessageBox.Show("Please input real cost.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtRealCost.Focus()
            '    Return
        End If

        Dim Qty As Decimal = Convert.ToDecimal(IIf(txtQuantity.Text.Trim = "", 0, txtQuantity.Text))

        If IsModifiedMedication Then
            If BeforeUpdateQty > 0 Then
                If BeforeUpdateQty <> Qty Then 'Adjustment only record when Quantity has been changed
                    If BeforeAdjSOH - (BeforeUpdateQty - Qty) < 0 Then
                        XtraMessageBox.Show("Incompleted adjustment!" + vbNewLine + "Oops! Current stock on hand is smaller than quantity to be adjusted.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtQuantity.Text = BeforeUpdateQty.ToString
                        Exit Sub
                    End If
                    LoadFormDialog(frmModifyMedReason)

                    If String.IsNullOrEmpty(AdjustmentReason.Trim) Then
                        XtraMessageBox.Show("Incompleted adjustment!" + vbNewLine + "Oops! Adjustment reason is required.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtQuantity.Text = BeforeUpdateQty.ToString
                        Exit Sub
                    End If
                End If
            End If
        End If

        Try
            Dim AfterAdjSOH As Decimal = 0
            Dim IsAdjustment As Boolean = False

            If DrugDetailCode = 0 Then 'Save Mode
                AfterAdjSOH = Qty
            Else ' Updaet Mode
                If BeforeUpdateQty = Qty Then 'No update or change becuase BeforeUpdateQty and Current Qty is equal
                    AfterAdjSOH = BeforeAdjSOH
                ElseIf BeforeUpdateQty < Qty Then 'Adjustment in
                    AfterAdjSOH = BeforeAdjSOH + (Qty - BeforeUpdateQty) 'New Stock On hand = Current Stock On hand + Ajustment Qty  (Adjust In)
                    IsAdjustment = True
                Else
                    AfterAdjSOH = BeforeAdjSOH - (BeforeUpdateQty - Qty) ' New Stock On hand = Current Stock On hand - Ajustment Qty (Adjust Out)
                    If AfterAdjSOH >= 0 Then IsAdjustment = True
                End If
            End If

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveMedicationStockin", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@InvoiceMedicalStockInCode", InvoiceMedicalStockInCode)
                .AddWithValue("@Warehouse", CInt(lueWarehouse.EditValue))
                .AddWithValue("@SupplierCode", CInt(lueSupplierName.EditValue))
                .AddWithValue("@IVRecievedNum", IIf(txtInvoiceNo.Text.Trim = "***", "", txtInvoiceNo.Text.Trim))
                .AddWithValue("@RefInvoiceNo", txtRefInvoiceNo.Text.Trim)
                .AddWithValue("@RecievedDate", deDateReceived.DateTime)
                .AddWithValue("@RecievedBy", txtReceivedBy.Text.Trim)
                .AddWithValue("@Remark", meRermark.Text.Trim)
                .AddWithValue("@DrugDetailCode", DrugDetailCode)
                .AddWithValue("@DrugMasterCode", CInt(lueBrandName.EditValue))
                .AddWithValue("@MadeIn", CInt(lueMadein.EditValue))
                .AddWithValue("@RealCost", IIf(txtRealCost.Text.Trim = "", 0, txtRealCost.Text.Trim))
                .AddWithValue("@Markup", IIf(txtMakeup.Text.Trim = "", 0, txtMakeup.Text.Trim))
                .AddWithValue("@RetailCost", IIf(txtRetailCost.Text.Trim = "", 0, txtRetailCost.Text.Trim))
                .AddWithValue("@Quantity", IIf(txtQuantity.Text.Trim = "", 0, txtQuantity.Text.Trim))
                .AddWithValue("@BeforeAdjSOH", BeforeAdjSOH)
                .AddWithValue("@StockOnHand", AfterAdjSOH)
                .AddWithValue("@ExpiredDate", deExpiredDate.DateTime)
                .AddWithValue("@LotNum", IIf(txtLots.Text.Trim = "", DBNull.Value, txtLots.Text.Trim))
                .AddWithValue("@DrugMasterCodeBeforeUpdate", DrugMasterCodeBeforeUpdate)
                .AddWithValue("@BeforeUpdateQty", BeforeUpdateQty)
                .AddWithValue("@IsAdjustment", IsAdjustment)
                .AddWithValue("@AdjustmentReason", AdjustmentReason)
                .AddWithValue("@Branch", ConfigClinic.Clinic)
                .AddWithValue("@User", LogUserNo)
                .Add("@isAdd", SqlDbType.Int)
                cmd.Parameters("@isAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
                .Add("@TMIVStockInCode", SqlDbType.Int)
                cmd.Parameters("@TMIVStockInCode").Direction = ParameterDirection.Output
                .Add("@TMIVRecievedNum", SqlDbType.NVarChar, 30)
                cmd.Parameters("@TMIVRecievedNum").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim mms As MessageBoxIcon = MessageBoxIcon.Error
            If Convert.ToInt16(cmd.Parameters("@isAdd").Value) <> 0 Then
                mms = MessageBoxIcon.Information
                txtInvoiceNo.Text = cmd.Parameters("@TMIVRecievedNum").Value.ToString
                btnSave.Enabled = False
                btnSave.Text = "Update"
                ClearMedication()
                lueBrandName.Select()
            End If
            LoadMedicationList(0, CInt(cmd.Parameters("@TMIVStockInCode").Value))
            btnNew.Enabled = True

            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Add Stock-in Medication", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ''Add item from form to list
        'Dim _obj As New Medication
        '_obj.ID = listMed.Count + 1
        '_obj.BrandName = lueBrandName.Text.Trim
        '_obj.GenericName = lueGenericName.Text.Trim
        '_obj.MadeIn = lueMadein.Text.Trim
        '_obj.ExpiredDate = deExpiredDate.Text.Trim
        '_obj.Strength = txtStrength.Text.Trim

        'Dim IsExistItem As Boolean = False
        'For Each t As Medication In listMed
        '    If t.BrandName = _obj.BrandName And t.GenericName = _obj.GenericName And t.MadeIn = _obj.MadeIn Then IsExistItem = True
        'Next

        'If IsExistItem Then
        '    XtraMessageBox.Show(_obj.BrandName + " is already added!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    lueBrandName.Select()
        'Else
        '    listMed.Add(_obj)
        '    gcMedication.RefreshDataSource()

        '    'ClearAllContent()
        'End If
    End Sub

    Private Sub LoadMedicationList(Optional _DrugDetailCode As Integer = 0, Optional _InvoiceMedicalStockInCode As Integer = 0)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetDrugDetailInfo", New SqlParameter("@DrugDetailCode", _DrugDetailCode), New SqlParameter("@InvoiceMedicalStockInCode", _InvoiceMedicalStockInCode))
            If dt.Rows.Count > 0 Then
                gcMedication.DataSource = dt
                With gvMedication
                    .PopulateColumns()
                    .Columns("DrugDetailCode").Visible = False
                    .Columns("InvoiceMedicalStockInCode").Visible = False
                    .Columns("DrugMasterCode").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("BrandName").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("GenericName").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("Quantity").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("Quantity").SummaryItem.DisplayFormat = "Count: {0}"
                    .Columns("RealCost").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns("RealCost").DisplayFormat.FormatString = "c3"
                    .Columns("RetailCost").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns("RetailCost").DisplayFormat.FormatString = "c3"
                    .Columns("LineTotal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("LineTotal").SummaryItem.DisplayFormat = "Total: {0:C}"
                    .Columns("LineTotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns("LineTotal").DisplayFormat.FormatString = "c3"

                    .Columns("StockOnHand").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("StockOnHand").SummaryItem.DisplayFormat = "Count: {0}"
                    .BestFitColumns()
                End With
            Else
                gcMedication.DataSource = Nothing
                gvMedication.Columns.Clear()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Stock-in", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub gcMedication_MouseClick(sender As Object, e As MouseEventArgs) Handles gcMedication.MouseClick
        If gvMedication.RowCount > 0 Then If e.Button = MouseButtons.Right Then ppMed.ShowPopup(Me.bmMed, Control.MousePosition)
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPDelete.ItemClick
        With gvMedication
            If .RowCount <= 0 Then
                XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf CDec(.GetRowCellValue(.FocusedRowHandle, "Quantity")) <> CDec(.GetRowCellValue(.FocusedRowHandle, "StockOnHand")) Then
                XtraMessageBox.Show("Oops! You cannot perform this action. Please use stock adjustment instead.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Try
                Dim _Name As String = .GetRowCellValue(.FocusedRowHandle, "BrandName").ToString
                detected = XtraMessageBox.Show("Are you sure to delete medication <<" + _Name + ">> from the list?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _DDCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "DrugDetailCode").ToString)
                RemoveItems(_DDCode)

                ''Remove item from the list
                'Dim _SelInd As Integer = CInt(.GetVisibleIndex(.FocusedRowHandle))
                'listMed.RemoveAt(_SelInd)

                'Dim _Ind As Integer = 1
                'For Each T As Medication In listMed
                '    T.ID = _Ind
                '    _Ind += 1
                'Next

                gcMedication.RefreshDataSource()
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub

    Private Sub RemoveItems(Optional _DrugDetailCode As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_RemoveMedicationStockIn", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@DrugDetailCode", DrugDetailCode)
                .AddWithValue("@Branch", ConfigClinic.Clinic)
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
            'frm_ManageLabStockCard.LoadMedicationList()
            'frm_ManageLabStockCard.LoadSupplier()
            'frm_dispensary.Initialize_ComboBox()
            LoadMedicationList(0, InvoiceMedicalStockInCode)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitMedicationHeader()
        gcMedication.DataSource = listMed
        gvMedication.PopulateColumns()
        gvMedication.BestFitColumns()
    End Sub

    'Private Sub LoadMedicationToTable(Optional ByVal _CVID As Integer = 0)
    '    listMed = GetDataFromDBToList("CV_GetCVReferencesList", New SqlParameter("@CVID", _CVID))
    '    gcMedication.DataSource = listMed
    '    gcMedication.RefreshDataSource()
    'End Sub

    Private Sub txtRetailCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRetailCost.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub txtMakeup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMakeup.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub txtRealCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRealCost.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub ComputeRetailCost()
        Try
            If (txtRealCost.Text.Trim <> "" And txtRealCost.Text.Trim <> "0") Then
                Dim _Makeup As Decimal = Convert.ToDecimal(IIf(String.IsNullOrEmpty(txtMakeup.Text.Trim), 0, txtMakeup.Text.Trim))
                Dim _RealCost As Decimal = Convert.ToDecimal(IIf(String.IsNullOrEmpty(txtRealCost.Text.Trim), 0, txtRealCost.Text.Trim))
                txtRetailCost.Text = Format(((_RealCost * _Makeup) / 100) + _RealCost, "0.000")
            Else
                txtRetailCost.Text = "0.000"
            End If
        Catch ex As Exception
            txtRetailCost.Text = "0.000"
        End Try
    End Sub


    Private Sub ComputeMakeup()
        Try
            If (txtRealCost.Text.Trim <> "" And txtRealCost.Text.Trim <> "0") And (txtRetailCost.Text.Trim <> "" And txtRetailCost.Text.Trim <> "0") Then
                Dim _RetailCost As Decimal = CDec(IIf(String.IsNullOrEmpty(txtRetailCost.Text.Trim), 0, txtRetailCost.Text.Trim))
                Dim _RealCost As Decimal = CDec(IIf(String.IsNullOrEmpty(txtRealCost.Text.Trim), 0, txtRealCost.Text.Trim))
                txtMakeup.Text = Format(((_RetailCost - _RealCost) / _RealCost) * 100, "0.00")
            Else
                txtMakeup.Text = "0.00"
            End If
        Catch ex As Exception
            txtMakeup.Text = "0.00"
        End Try
    End Sub

    Private Sub txtRealCost_KeyUp(sender As Object, e As KeyEventArgs) Handles txtRealCost.KeyUp
        ComputeRetailCost()
    End Sub

    Private Sub txtMakeup_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMakeup.KeyUp
        ComputeRetailCost()
    End Sub

    Private Sub txtRetailCost_KeyUp(sender As Object, e As KeyEventArgs) Handles txtRetailCost.KeyUp
        ComputeMakeup()
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            With gvMedication
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _DDCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "DrugDetailCode").ToString)
                Dim _DMName As String = .GetRowCellValue(.FocusedRowHandle, "BrandName").ToString
                SelectMedicationToEdit(_DDCode, _DMName)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub SelectMedicationToEdit(Optional _DrugDetailCode As Integer = 0, Optional _DrugName As String = "", Optional _InvoiceMedicalStockInCode As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetDrugDetailInfo", New SqlParameter("@DrugDetailCode", _DrugDetailCode), New SqlParameter("@InvoiceMedicalStockInCode", _InvoiceMedicalStockInCode))
            With dtData
                If .Rows.Count = 1 Then
                    IsModifiedMedication = True
                    btnNew.Enabled = True
                    lueBrandName.ReadOnly = True
                    lueGenericName.ReadOnly = True
                    DrugDetailCode = CInt(.Rows(0)("DrugDetailCode"))
                    InvoiceMedicalStockInCode = CInt(.Rows(0)("InvoiceMedicalStockInCode"))
                    DrugMasterCodeBeforeUpdate = CInt(IIf(String.IsNullOrEmpty(.Rows(0)("DrugMasterCode").ToString), 0, .Rows(0)("DrugMasterCode")))
                    If CInt(IIf(String.IsNullOrEmpty(.Rows(0)("DrugMasterCode").ToString), 0, .Rows(0)("DrugMasterCode"))) > 0 Then
                        lueBrandName.EditValue = CInt(.Rows(0)("DrugMasterCode"))
                        lueGenericName.EditValue = CInt(.Rows(0)("DrugMasterCode"))
                    Else
                        lueBrandName.EditValue = -1
                        lueGenericName.EditValue = -1
                    End If

                    If CInt(IIf(String.IsNullOrEmpty(.Rows(0)("MadeIn").ToString), 0, .Rows(0)("MadeIn"))) > 0 Then
                        lueMadein.EditValue = CInt(.Rows(0)("MadeIn"))
                    Else
                        lueMadein.EditValue = 29
                    End If
                    txtLots.Text = .Rows(0)("LotNum").ToString
                    If Not String.IsNullOrEmpty(.Rows(0)("ExpiredDate").ToString) Then
                        deExpiredDate.DateTime = Convert.ToDateTime(.Rows(0)("ExpiredDate").ToString)
                    Else
                        deExpiredDate.DateTime = Now.Date
                    End If
                    txtStrength.Text = .Rows(0)("Strength").ToString
                    txtForm.Text = .Rows(0)("FormEn").ToString
                    txtQuantity.Text = .Rows(0)("Quantity").ToString
                    BeforeUpdateQty = Convert.ToDecimal(.Rows(0)("Quantity").ToString)
                    txtRealCost.Text = .Rows(0)("RealCost").ToString
                    txtMakeup.Text = .Rows(0)("Markup").ToString
                    BeforeAdjSOH = Convert.ToDecimal(.Rows(0)("StockOnHand"))
                    txtRetailCost.Text = .Rows(0)("RetailCost").ToString
                    lueBrandName.Select()
                Else
                    XtraMessageBox.Show("Searching keyword: " + _DrugName.ToString + " does not exist on the target system.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmSearchInvoiceStockIn.Opt = "StockIn"
        LoadFormDialog(frmSearchInvoiceStockIn)
    End Sub

    Public Sub SearchMedicationByInvoice(ByVal _InvoiceNo As String)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetInvoiceStockIn", New SqlParameter("@IVRecievedNum", _InvoiceNo))
            If dt.Rows.Count = 1 Then
                With dt.Rows(0)
                    If Opt = "search-invoice-stockin" Then
                        frmSearchInvoiceStockIn.Dispose()
                    ElseIf Opt = "stock-carts" Then
                        LoadForm(Me)
                    End If
                    btnNew.Enabled = True
                    InvoiceMedicalStockInCode = CInt(.Item("InvoiceMedicalStockInCode"))
                    lueWarehouse.EditValue = CInt(.Item("Warehouse"))
                    lueSupplierName.EditValue = CInt(.Item("SupplierCode"))
                    GetSearchDataByID(CInt(.Item("SupplierCode")))
                    txtInvoiceNo.Text = .Item("IVRecievedNum").ToString
                    txtRefInvoiceNo.Text = .Item("RefInvoiceNo").ToString
                    If Not String.IsNullOrEmpty(.Item("RecievedDate").ToString) Then
                        deDateReceived.DateTime = CDate(.Item("RecievedDate"))
                    Else
                        deDateReceived.DateTime = Now.Date
                    End If
                    txtReceivedBy.Text = .Item("RecievedBy").ToString
                    meRermark.Text = .Item("Remark").ToString
                    LoadMedicationList(0, InvoiceMedicalStockInCode)
                    lueBrandName.Select()
                End With
            Else
                XtraMessageBox.Show("Search not found for Invoice No " + _InvoiceNo + ".", "Medication Stock-in", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Stock-in", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        btnNew.Enabled = False
        lueSupplierName.Focus()
    End Sub

    Private Sub lueWarehouse_KeyUp(sender As Object, e As KeyEventArgs) Handles lueWarehouse.KeyUp
        If (e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control) Then btnSearch_Click(Nothing, Nothing)
    End Sub

    Private Sub lueSupplierName_KeyUp(sender As Object, e As KeyEventArgs) Handles lueSupplierName.KeyUp
        If (e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control) Then btnSearch_Click(Nothing, Nothing)
    End Sub

    Private Sub gvMedication_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gvMedication.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As String = .GetRowCellValue(e.RowHandle, .Columns(14)).ToString
            If tempVal = "Adjusted" Then
                e.Appearance.BackColor = Color.LightCyan
                e.Appearance.ForeColor = Color.FromArgb(&HCC, &H0, &H0)
            End If
        End With
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        If InvoiceMedicalStockInCode > 0 And gvMedication.RowCount > 0 Then
            XtraMessageBox.Show("Hello", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            XtraMessageBox.Show("Oops! Not found medication to print.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class