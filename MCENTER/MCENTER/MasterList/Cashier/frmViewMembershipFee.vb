Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmViewMembershipFee
    Dim _TempID As Integer = 0
    Dim dtData As New DataTable

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmViewMembershipFee_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        LoadDataToList()
        EnabledEdit()
        btnNew.Enabled = False
        lueMembershipType.Focus()
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        txtFee.ReadOnly = Not en
        meNote.ReadOnly = Not en
        lueMembershipType.ReadOnly = Not en
        lueEnrollmentType.ReadOnly = Not en
        lueClinic.ReadOnly = Not en
    End Sub

    Private Sub ClearAllContent()
        _TempID = 0
        txtCode.Text = "***"
        txtFee.Text = ""
        lueMembershipType.EditValue = -1
        lueEnrollmentType.EditValue = -1
        lueClinic.EditValue = 0
        meNote.Text = ""
        EnabledButtonSave()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Public Sub LoadDataToList(Optional ByVal Find_ID As Integer = 0, Optional ByVal _Flag As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_GetMembershipFeeByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .Columns("TranID").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("Fee").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Fee").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Fee").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns("Fee").DisplayFormat.FormatString = "c3"
                    .Columns("Inactive").Width = 120
                    .Columns("Inactive").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
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

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = MouseButtons.Right Then pmMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub frmViewMembershipFee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMembershipType()
        LoadEnrollmentType()
        LoadClinic()
        lueClinic.EditValue = 0
        LoadDataToList()
    End Sub

    Public Sub LoadMembershipType()
        Try
            GetDataToComboBoxWithParam(lueMembershipType, "SA_GetMembershipTypeByID", "TranID", "MembershipType", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadEnrollmentType()
        Try
            GetDataToComboBoxWithParam(lueEnrollmentType, "SA_GetEnrollmentTypeByID", "TranID", "EnrollmentType", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadClinic()
        Try
            GetDataToComboBoxWithParam(lueClinic, "SA_GetClinicByID", "ClinicID", "ClinicEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 2))
            lueClinic.EditValue = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "TranID").ToString)
                GetSearchDataByID(_ID)
            End With
        Catch ex As Exception
            ClearAllContent()
            txtFee.Focus()
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
        '        GetSearchDataByID(CInt(SelectedRow("TranID")))
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Public Sub GetSearchDataByID(Find_ID As Integer, Optional ByVal _Flag As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetMembershipFeeByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True, True)
                    EnabledEdit()
                    btnNew.Enabled = True
                    txtCode.Text = .Rows(0)("TranID").ToString
                    _TempID = CInt(.Rows(0)("TranID"))
                    If CInt(.Rows(0)("MembershipType")) >= 0 Then
                        lueMembershipType.EditValue = CInt(.Rows(0)("MembershipType"))
                    Else
                        lueMembershipType.EditValue = -1
                    End If
                    If CInt(.Rows(0)("EnrollmentType")) >= 0 Then
                        lueEnrollmentType.EditValue = CInt(.Rows(0)("EnrollmentType"))
                    Else
                        lueEnrollmentType.EditValue = -1
                    End If
                    If CInt(.Rows(0)("ClinicID")) >= 0 Then
                        lueClinic.EditValue = CInt(.Rows(0)("ClinicID"))
                    Else
                        lueClinic.EditValue = -1
                    End If
                    txtFee.Text = .Rows(0)("Fee").ToString
                    meNote.Text = .Rows(0)("Note").ToString
                    lueMembershipType.Focus()
                Else
                    ClearAllContent()
                    LoadDataToList()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to remove the selected membership fee?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "TranID").ToString)
                DisabledItems(_ID.ToString, 1)
            End With
        Catch ex As Exception
            ClearAllContent()
            txtFee.Focus()
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
        '            _TempID(i) = SelectedRow("TranID").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to remove the selected membership fee?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList, 1)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub DisabledItems(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisabledMembershipFee", Con)
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
            txtFee.Focus()
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
                detected = XtraMessageBox.Show("Do you want to restore the selected membership fee?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "TranID").ToString)
                DisabledItems(_ID.ToString)
            End With
        Catch ex As Exception
            ClearAllContent()
            txtFee.Focus()
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
        '            _TempID(i) = SelectedRow("TranID").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to restore the selected membership fee?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub bbiPExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExport.ItemClick
        ExportToXlsx(dtData, "Membership Fee Report")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If CInt(lueMembershipType.EditValue) <= 0 OrElse CInt(lueEnrollmentType.EditValue) <= 0 Then
            XtraMessageBox.Show("Please enter mandatory information.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lueMembershipType.Focus()
            Return
        ElseIf String.IsNullOrEmpty(txtFee.Text.Trim) Then
            XtraMessageBox.Show("Please enter fee.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFee.Focus()
            Return
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveMembershipFee", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _TempID)
                .AddWithValue("@MembershipType", CInt(lueMembershipType.EditValue))
                .AddWithValue("@EnrollmentType", CInt(lueEnrollmentType.EditValue))
                .AddWithValue("@ClinicID", CInt(lueClinic.EditValue))
                .AddWithValue("@Fee", txtFee.Text.Trim)
                .AddWithValue("@Note", meNote.Text.Trim)
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
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Membership Fee", MessageBoxButtons.OK, MMS)
            btnNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtFee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFee.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub lueMembershipType_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueMembershipType.Closed
        lueEnrollmentType.Focus()
    End Sub

    Private Sub lueEnrollmentType_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueEnrollmentType.Closed
        lueClinic.Focus()
    End Sub

    Private Sub lueClinic_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueClinic.Closed
        txtFee.Focus()
    End Sub

    Private Sub btnMembershipType_Click(sender As Object, e As EventArgs) Handles btnMembershipType.Click
        frmViewMembershipType.PageRefresh = "frmViewMembershipFee"
        LoadFormDialog(frmViewMembershipType)
    End Sub

    Private Sub btnEnrollmentType_Click(sender As Object, e As EventArgs) Handles btnEnrollmentType.Click
        LoadFormDialog(frmViewEnrollmentType)
    End Sub

    Private Sub btnClinic_Click(sender As Object, e As EventArgs) Handles btnClinic.Click
        frmViewClinic.PageRefresh = "frmViewMembershipFee"
        LoadForm(frmViewClinic)
    End Sub
End Class