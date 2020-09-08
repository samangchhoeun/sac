Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmSetPatientReminder
    Dim TempPatientCode As String = ""
    Dim ReminderCode As Integer = 0
    Dim dtData As New DataTable

    Private Sub frmSetPatientReminder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoCompleteID(txtSID, "SA_GetPatientCodeList")
        deRemind.DateTime = Now.Date
        teRemind.EditValue = Now.ToLocalTime
        LoadUserAccount()
        LoadPatientReminder()
        If isLoggedInOwner Then bbiPRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

    End Sub

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then
            ClearAllContent()
            TempPatientCode = txtSID.Text.Trim
            If String.IsNullOrEmpty(TempPatientCode) Then
                XtraMessageBox.Show("Please enter Patient Code before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSID.Focus()
                Return
            End If
            txtSID.Text = txtSID.Text.Trim.ToUpper
            SelectPatientVisit(TempPatientCode)
        End If
    End Sub

    Private Sub LoadUserAccount()
        Try
            GetDataToComboBoxWithParam(lueReminderTo, "SA_GetUserAccount", "UserNo", "AccountName", New SqlParameter("@KC", SAC))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearAllContent()
        txtEnglishName.Text = ""
        txtGender.Text = ""
        txtAge.Text = ""
        txtDOB.Text = ""
        txtCellPhone.Text = ""
        txtCity.Text = ""
        chkIsRemind.Checked = False
        deRemind.DateTime = Now.Date
        teRemind.EditValue = Now.ToLocalTime
        meReminder.Text = ""
        lueReminderTo.EditValue = -1
        TempPatientCode = ""
        ReminderCode = 0
    End Sub

    Private Sub SelectPatientVisit(_PatientCode As String)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientProfile", New SqlParameter("@PatientCode", _PatientCode))
            With dtData
                If .Rows.Count = 1 Then
                    TempPatientCode = .Rows(0)("PatientCode").ToString
                    'txtSID.Text = GetPatientCode(.Rows(0)("PatientCode").ToString)
                    txtEnglishName.Text = .Rows(0)("EnglishName").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    Dim dob As String = .Rows(0)("DOB").ToString
                    txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                    txtAge.Text = .Rows(0)("Age").ToString
                    txtCellPhone.Text = .Rows(0)("CellPhone").ToString
                    txtCity.Text = .Rows(0)("City").ToString
                    meReminder.Focus()
                Else
                    XtraMessageBox.Show("Searching keyword: " + _PatientCode + " doesnot exist on the target system. " & vbLf & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LoadPatientReminder(Optional _ClinicID As Integer = 0, Optional _ReminderCode As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_CheckPatientReminder", New SqlParameter("@ClinicID", _ClinicID), New SqlParameter("@ReminderCode", _ReminderCode))
            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Columns("ClinicID").Visible = False
                    .Columns("ReminderCode").Visible = False
                    .Columns("DOB").Visible = False
                    .Columns("DateToReminder").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("PatientName").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("PTReminder").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("ReminderToUsername").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(TempPatientCode) Then
            XtraMessageBox.Show("Please select patient to set reminder.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSID.Focus()
            Return
        ElseIf String.IsNullOrEmpty(meReminder.Text.Trim) Then
            XtraMessageBox.Show("Please tell the reason of reminder.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            meReminder.Focus()
            Return
        ElseIf CInt(lueReminderTo.EditValue) <= 0 Then
            XtraMessageBox.Show("Please select person to follow up patient.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lueReminderTo.Focus()
            Return
        End If

        Try
            Dim _ReminderTo As Object = CInt(lueReminderTo.EditValue)

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SavePatientReminder", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ReminderCode", ReminderCode)
                .AddWithValue("@PatientCode", TempPatientCode)
                .AddWithValue("@Patient", txtEnglishName.Text.Trim)
                .AddWithValue("@ClinicID", ConfigClinic.ClinicID)
                .AddWithValue("@PTReminder", meReminder.Text.Trim)
                .AddWithValue("@IsReminderTo", CBool(chkIsRemind.EditValue))
                .AddWithValue("@ReminderToUsername", _ReminderTo)
                .AddWithValue("@DateToReminder", ClinicConfiguration.ActivateDate(deRemind.Text.Trim) + " " + ClinicConfiguration.ActivateTime(teRemind.Text.Trim))
                .AddWithValue("@User", LogUserNo)
                .Add("@isAdd", SqlDbType.Int)
                cmd.Parameters("@isAdd").Direction = ParameterDirection.Output
                .Add("@PTCodePrint", SqlDbType.NVarChar, 15)
                cmd.Parameters("@PTCodePrint").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim mms As MessageBoxIcon = MessageBoxIcon.Error
            If Convert.ToInt16(cmd.Parameters("@isAdd").Value) <> 0 Then
                btnSave.Enabled = False
                btnSave.Text = "Update"
                mms = MessageBoxIcon.Information
            End If
            LoadPatientReminder()
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Patient Reminder", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnNew.Enabled = True
        btnNew.Focus()
    End Sub

    Private Sub SelectPatientReminder(Optional _ClinicID As Integer = 0, Optional _ReminderCode As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_CheckPatientReminder", New SqlParameter("@ClinicID", _ClinicID), New SqlParameter("@ReminderCode", _ReminderCode))
            With dtData
                If .Rows.Count = 1 Then
                    txtSID.ReadOnly = True
                    btnDelete.Enabled = True
                    btnNew.Enabled = True
                    TempPatientCode = .Rows(0)("PatientCode").ToString
                    txtSID.Text = .Rows(0)("PatientCode").ToString
                    ReminderCode = CInt(.Rows(0)("ReminderCode"))
                    txtEnglishName.Text = .Rows(0)("PatientName").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    Dim dob As String = .Rows(0)("DOB").ToString
                    txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                    txtAge.Text = .Rows(0)("Age").ToString
                    txtCellPhone.Text = .Rows(0)("CellPhone").ToString
                    txtCity.Text = .Rows(0)("City").ToString
                    meReminder.Text = .Rows(0)("PTReminder").ToString
                    chkIsRemind.Checked = CBool(.Rows(0)("IsReminderTo"))
                    If CInt(.Rows(0)("ReminderToUsername")) > 0 Then
                        lueReminderTo.EditValue = CInt(.Rows(0)("ReminderToUsername"))
                    Else
                        lueReminderTo.EditValue = -1
                    End If
                    Dim DateReminder As String = .Rows(0)("DateReminder").ToString
                    If Not String.IsNullOrEmpty(DateReminder) Then
                        deRemind.DateTime = Convert.ToDateTime(DateReminder)
                    Else
                        deRemind.DateTime = Now.Date
                    End If

                    Dim TimeReminder As String = .Rows(0)("TimeReminder").ToString
                    If Not String.IsNullOrEmpty(TimeReminder) Then
                        teRemind.EditValue = TimeReminder
                    Else
                        teRemind.EditValue = Now.ToLocalTime
                    End If
                    meReminder.Focus()
                Else
                    XtraMessageBox.Show("Searching keyword: " + _ReminderCode.ToString + " doesnot exist on the target system. " & vbLf & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = MouseButtons.Right Then ppMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ReminderCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ReminderCode").ToString)
                SelectPatientReminder(0, _ReminderCode)
            End With
        Catch ex As Exception
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
        '        SelectPatientReminder(0, CInt(SelectedRow("ReminderCode")))
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Private Sub DisabledItems(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisablePatientReminder", Con)
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
            LoadPatientReminder()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Patient Visit", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExport.ItemClick
        ExportToXlsx(dtData, "Patient Reminder Report")
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        txtSID.ReadOnly = False
        btnSave.Text = "Save"
        btnSave.Enabled = True
        btnNew.Enabled = False
        txtSID.Text = ""
        txtSID.Focus()
    End Sub

    Private Sub txtSID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSID.KeyPress
        'PTCode_KeyPress(txtSID, e)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If ReminderCode = 0 Then
                XtraMessageBox.Show("Please select patient to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSID.Focus()
                Return
            End If

            detected = XtraMessageBox.Show("Do you want to remove the selected patient reminder?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            btnDelete.Enabled = False
            DisabledItems(ReminderCode.ToString, 1)
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

                detected = XtraMessageBox.Show("Do you want to restore the selected patient reminders?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ReminderCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ReminderCode").ToString)
                DisabledItems(_ReminderCode.ToString)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        '            _TempID(i) = SelectedRow("ReminderCode").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to restore the selected patient reminders?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to remove the selected patient reminders?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ReminderCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ReminderCode").ToString)
                DisabledItems(_ReminderCode.ToString, 1)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        '            _TempID(i) = SelectedRow("ReminderCode").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to remove the selected patient reminders?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList, 1)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub gvData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gvData.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As DateTime = CDate(.GetRowCellValue(e.RowHandle, "DateReminder"))
            If DateDiff(DateInterval.Minute, tempVal, Now.Date) >= 0 Then e.Appearance.ForeColor = Color.Gray
        End With
    End Sub
End Class