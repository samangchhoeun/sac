Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors

Public Class frmViewMedicalTreatment
    Dim _TempID As Integer = 0
    Dim dtData As New DataTable

    Private Sub frmViewMedicalTreatment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs)
        ClearAllContent()
        LoadDataToList()
        btnNew.Enabled = False
        lueTreatmentCategory.Focus()
    End Sub

    Private Sub ClearAllContent()
        _TempID = 0
        txtCode.Text = "***"
        lueTreatmentCategory.EditValue = -1
        lueClinic.EditValue = 0
        txtServiceCode.Text = ""
        txtEn.Text = ""
        txtKh.Text = ""
        meNote.Text = ""
        EnabledButtonSave()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = MouseButtons.Right Then pmMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub frmViewMedicalTreatment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTreatmentCategory()
        LoadClinic()
        LoadDataToList()
    End Sub

    Public Sub LoadTreatmentCategory()
        Try
            GetDataToComboBoxWithParam(lueTreatmentCategory, "SA_GetMedTreatmentCategoryByID", "CategoryCode", "CategoryEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
            lueClinic.EditValue = 0
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadClinic()
        Try
            GetDataToComboBoxWithParam(lueClinic, "SA_GetClinicByID", "ClinicID", "ClinicEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 2))
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadDataToList(Optional ByVal Find_ID As Integer = 0, Optional CategoryID As Integer = 0, Optional ByVal _Flag As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_GetMedTreatmentByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@CategoryID", CategoryID), New SqlParameter("@isList", _Flag))
            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .Columns("TreatmentCode").Visible = False
                    .Columns("ServiceKh").Visible = False
                    .Columns("Note").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Columns("OriginalCost").DisplayFormat.FormatType = FormatType.Numeric
                    .Columns("OriginalCost").DisplayFormat.FormatString = "c3"
                    .Columns("LocalFee").DisplayFormat.FormatType = FormatType.Numeric
                    .Columns("LocalFee").DisplayFormat.FormatString = "c3"
                    .Columns("ExpatFee").DisplayFormat.FormatType = FormatType.Numeric
                    .Columns("ExpatFee").DisplayFormat.FormatString = "c3"
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    '.Columns("ServiceCode").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                    '.Columns("OriginalCost").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                    '.Columns("LocalFee").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                    '.Columns("ExpatFee").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("ServiceKh").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("ServiceEn").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("Inactive").Width = 120
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "{0} Records"
                    .BestFitColumns()
                End With
            Else
                gcData.DataSource = Nothing
                gvData.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bbiPRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRefresh.ItemClick
        LoadDataToList()
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "TreatmentCode").ToString)
                GetSearchDataByID(_ID)
            End With
        Catch ex As Exception
            ClearAllContent()
            lueClinic.Focus()
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        'Try
        '    Dim SelRows As Integer() = gvData.GetSelectedRows()
        '    Dim i = 0
        '    For Each index As Integer In SelRows
        '        If (index >= 0) Then i += 1
        '    Next
        '    If SelRows.Count <= 0 Then
        '        XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    ElseIf i > 1 Then
        '        XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    ElseIf i = 1 Then
        '        Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(SelRows(0)), DataRowView)
        '        GetSearchDataByID(CInt(SelectedRow("TreatmentCode")))
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Public Sub GetSearchDataByID(Optional ByVal Find_ID As Integer = 0, Optional CategoryID As Integer = 0, Optional ByVal _Flag As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetMedTreatmentByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@CategoryID", CategoryID), New SqlParameter("@isList", _Flag))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True, True)
                    EnabledEdit()
                    btnNew.Enabled = True
                    txtCode.Text = .Rows(0)("TreatmentCode").ToString
                    _TempID = CInt(.Rows(0)("TreatmentCode"))
                    If CInt(.Rows(0)("Category")) > 0 Then
                        lueTreatmentCategory.EditValue = CInt(.Rows(0)("Category"))
                    Else
                        lueTreatmentCategory.EditValue = -1
                    End If
                    txtServiceCode.Text = .Rows(0)("ServiceCode").ToString
                    txtEn.Text = .Rows(0)("ServiceEn").ToString
                    txtKh.Text = .Rows(0)("ServiceKh").ToString
                    If CInt(.Rows(0)("ClinicID")) >= 0 Then
                        lueClinic.EditValue = CInt(.Rows(0)("ClinicID"))
                    Else
                        lueClinic.EditValue = -1
                    End If
                    chkIsDiscount.Checked = CBool(.Rows(0)("IsDiscount"))
                    txtOriginalCost.Text = .Rows(0)("OriginalCost").ToString
                    txtLocalFee.Text = .Rows(0)("LocalFee").ToString
                    txtExpatFee.Text = .Rows(0)("ExpatFee").ToString
                    meNote.Text = .Rows(0)("Note").ToString
                    lueTreatmentCategory.Focus()
                Else
                    ClearAllContent()
                    LoadDataToList()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If CInt(lueTreatmentCategory.EditValue) <= 0 Then
            XtraMessageBox.Show("Please choose treatment category.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lueTreatmentCategory.Focus()
            Return
        ElseIf String.IsNullOrEmpty(txtEn.Text.Trim) Or String.IsNullOrEmpty(txtServiceCode.Text.Trim) Then
            XtraMessageBox.Show("Please enter service name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtServiceCode.Focus()
            Return
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveMedTreatment", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _TempID)
                .AddWithValue("@CategoryID", CInt(lueTreatmentCategory.EditValue))
                .AddWithValue("@ServiceCode", txtServiceCode.Text.Trim)
                .AddWithValue("@ServiceEn", txtEn.Text.Trim)
                .AddWithValue("@ServiceKh", txtKh.Text.Trim)
                .AddWithValue("@ClinicID", CInt(lueClinic.EditValue))
                .AddWithValue("@IsDiscount", chkIsDiscount.Checked)
                .AddWithValue("@OriginalCost", txtOriginalCost.Text.Trim)
                .AddWithValue("@LocalFee", txtLocalFee.Text.Trim)
                .AddWithValue("@ExpatFee", txtExpatFee.Text.Trim)
                .AddWithValue("@Des", meNote.Text.Trim)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            If IsAdd > 0 Then
                MMS = MessageBoxIcon.Information
                EnabledEdit(False)
                EnabledButtonSave("Save", False, True)
                btnNew.Enabled = True
            Else
                EnabledEdit()
                EnabledButtonSave()
                btnNew.Enabled = False
            End If

            LoadDataToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Treatment", MessageBoxButtons.OK, MMS)
            btnNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click_1(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        LoadDataToList()
        EnabledEdit()
        btnNew.Enabled = False
        lueTreatmentCategory.Focus()
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        txtServiceCode.ReadOnly = Not en
        lueTreatmentCategory.ReadOnly = Not en
        lueClinic.ReadOnly = Not en
        txtEn.ReadOnly = Not en
        txtKh.ReadOnly = Not en
        meNote.ReadOnly = Not en
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to remove the selected treatment?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "TreatmentCode").ToString)
                DisabledItems(_ID.ToString, 1)
            End With
        Catch ex As Exception
            ClearAllContent()
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lueClinic.Focus()
        End Try
        'Try
        '    Dim SelRows() As Integer = gvData.GetSelectedRows()
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
        '            _TempID(i) = SelectedRow("TreatmentCode").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to remove the selected treatment?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList, 1)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub DisabledItems(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisabledMedTreatment", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@Inactive", _Inactive)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error
            ClearAllContent()
            btnNew.Enabled = False
            LoadDataToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm Message", MessageBoxButtons.OK, MMS)
            lueTreatmentCategory.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to restore the selected treatment?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "TreatmentCode").ToString)
                DisabledItems(_ID.ToString)
            End With
        Catch ex As Exception
            ClearAllContent()
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lueClinic.Focus()
        End Try

        'Try
        '    Dim SelRows() As Integer = gvData.GetSelectedRows()
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
        '            _TempID(i) = SelectedRow("TreatmentCode").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to restore the selected treatment?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub bbiPExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExport.ItemClick
        ExportToXlsx(dtData, "Medical Treatment Report")
    End Sub

    Private Sub lueDxGroup_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueTreatmentCategory.Closed
        txtServiceCode.Focus()
    End Sub

    Private Sub txtOriginalCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOriginalCost.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub txtLocalFee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLocalFee.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub txtExpatFee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExpatFee.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub btnClinic_Click(sender As Object, e As EventArgs) Handles btnClinic.Click
        frmViewClinic.PageRefresh = "frmViewMedicalTreatment"
        LoadForm(frmViewClinic)
    End Sub

    Private Sub btnTreatmentCate_Click(sender As Object, e As EventArgs) Handles btnTreatmentCate.Click
        LoadFormDialog(frmViewMedicalTreatmentCategory)
    End Sub
End Class