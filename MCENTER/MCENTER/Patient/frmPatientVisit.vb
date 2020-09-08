Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPatientVisit
    Dim TempPatientCode As String = ""
    Dim TempPatientID As Integer = 0
    Dim VisitCode As Integer = 0
    Dim dtData As New DataTable
    Dim IsUpdate As Boolean = False

    Private Sub frmPatientVisit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AutoCompleteID(txtSID, "SA_GetPatientCodeList")
        deCheckInDate.DateTime = Now
        deDOB.DateTime = Now.Date.AddYears(-18)
        LoadClinic()
        LoadDoctor()
        LoadPatientCheckIn()
        If isLoggedInOwner Then
            bbiPReactivateCheckIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            'bbiPRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Else
            bbiPReactivateCheckIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            'bbiPRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        btnNew.Enabled = False
        'btnCheckIn.Enabled = False
        txtSID.ReadOnly = False
        EnabledButtonSave("Check In", False)
        txtSID.Text = ""
        txtSID.Focus()
    End Sub

    Private Sub LoadClinic()
        Try
            GetDataToComboBoxWithParam(lueClinic, "SA_GetClinicByID", "ClinicID", "ClinicEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
            If Not IsNothing(ConfigClinic) Then
                lueClinic.EditValue = ConfigClinic.ClinicID
            Else
                lueClinic.EditValue = -1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDoctor()
        Try
            GetDataToComboBoxWithParam(lueDoctor, "SA_GetDoctorsToList", "ID", "Doctor", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearAllContent()
        ' txtSID.Text = ""
        txtPatientName.Text = ""
        txtGender.Text = ""
        txtAge.Text = ""
        txtMembership.Text = ""
        deDOB.DateTime = Now.Date.AddYears(-18)
        deCheckInDate.DateTime = Now
        meReasonOfVisit.Text = ""
        'lueClinic.EditValue = -1
        If Not IsNothing(ConfigClinic) Then
            lueClinic.EditValue = ConfigClinic.ClinicID
        Else
            lueClinic.EditValue = -1
        End If

        lueDoctor.EditValue = -1
        TempPatientCode = ""
        TempPatientID = 0
        VisitCode = 0
        EnabledCheckIn(False)
    End Sub

    Private Sub btnCheckIn_Click(sender As Object, e As EventArgs) Handles btnCheckIn.Click
        If String.IsNullOrEmpty(txtSID.Text.Trim) Then
            XtraMessageBox.Show("Please select patient to check-in.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSID.Focus()
            Return
        ElseIf CInt(lueClinic.EditValue) <= 0 OrElse CInt(lueDoctor.EditValue) <= 0 Then
            XtraMessageBox.Show("Some selection boxes are required.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lueClinic.Focus()
            Return
        ElseIf String.IsNullOrEmpty(meReasonOfVisit.Text.Trim) Then
            XtraMessageBox.Show("Please tell the reason of visit.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            meReasonOfVisit.Focus()
            Return
        ElseIf IsCheckedIn(TempPatientCode, deCheckInDate.DateTime.ToString) Then
            XtraMessageBox.Show("This patient," + txtSID.Text.Trim + " already checked-in at " + deCheckInDate.DateTime.ToLongDateString + " at clinic " + lueClinic.Text.Trim + ".", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSID.Focus()
            Return
        End If

        Try
            If Not IsUpdate AndAlso IsMultiCheckedInPerDay(TempPatientCode, deCheckInDate.DateTime.ToString) Then
                Dim detected As DialogResult = XtraMessageBox.Show("Today, this patient, " + txtSID.Text.Trim + " is already checked-in. Do you wish to check-in again?", "Check-In Again?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If detected = DialogResult.No Then Exit Try
            End If

            Dim _Clinic As Object = CInt(lueClinic.EditValue)
            Dim _Doctor As Object = CInt(lueDoctor.EditValue)

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SavePatientVisit", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@VisitCode", VisitCode)
                .AddWithValue("@PatientCode", TempPatientCode)
                .AddWithValue("@Patient", txtPatientName.Text.Trim)
                .AddWithValue("@MembershipType", txtMembership.Text.Trim)
                .AddWithValue("@DateIn", deCheckInDate.DateTime)
                .AddWithValue("@ClinicID", _Clinic)
                .AddWithValue("@CheckInToDoctor", _Doctor)
                .AddWithValue("@ReasonOfVisit", meReasonOfVisit.Text.Trim)
                .AddWithValue("@RegClinic", ConfigClinic.ClinicID)
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
                EnabledButtonSave("Check In", False)
                '_PatientCode = "This Patient Code is " + cmd.Parameters("@PatientCode").Value.ToString + "."
                mms = MessageBoxIcon.Information
            End If
            LoadPatientCheckIn()
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Register Patient", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnNew.Enabled = True
        btnNew.Focus()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "Check In", Optional en As Boolean = True, Optional del As Boolean = False)
        btnCheckIn.Text = txt
        btnCheckIn.Enabled = en
    End Sub

    Public Sub LoadPatientCheckIn(Optional _ClinicID As Integer = 0, Optional _VisitCode As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_GetPatientCheckInList", New SqlParameter("@ClinicID", _ClinicID), New SqlParameter("@VisitCode", _VisitCode), New SqlParameter("@IsAdmin", isLoggedInOwner))
            lcgCheckIn.Text = "Check-In List [ " + dtData.Rows.Count.ToString + " ]"
            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .Columns("DateCheckIn").DisplayFormat.FormatType = FormatType.DateTime
                    .Columns("DateCheckIn").DisplayFormat.FormatString = "MMM dd, yyyy hh:mm:ss tt"
                    .Columns("DOB").DisplayFormat.FormatType = FormatType.DateTime
                    .Columns("DOB").DisplayFormat.FormatString = "MMM dd, yyyy"
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Columns("VisitCode").Visible = False
                    .Columns("Inactive").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("NumIn").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("PatientCode").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Gender").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Age").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("DOB").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    ' .Columns("VisitCode").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("DateCheckIn").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("DateCheckIn").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("DateCheckIn").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            Else
                gcData.DataSource = Nothing
                gvData.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dispose()
    End Sub

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    ClearAllContent()
        '    TempPatientCode = txtSID.Text.Trim
        '    If String.IsNullOrEmpty(TempPatientCode) Then
        '        XtraMessageBox.Show("Please enter Patient Code before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtSID.Focus()
        '        Return
        '    End If
        '    txtSID.Text = txtSID.Text.Trim.ToUpper
        '    SelectPatientVisit(TempPatientCode)
        'End If
    End Sub

    Private Sub SelectPatientVisit(_PatientCode As String)
        Try
            TempPatientCode = GetStandardPatientCode(_PatientCode)
            If String.IsNullOrEmpty(_PatientCode) Then ClearAllContent() : Exit Sub
            If Len(GetStandardPatientCode(_PatientCode)) = 9 Then
                Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientProfile", New SqlParameter("@PatientCode", GetStandardPatientCode(_PatientCode)))
                With dtData
                    If .Rows.Count = 1 Then
                        EnabledCheckIn()
                        txtSID.ReadOnly = True
                        btnNew.Enabled = True
                        EnabledButtonSave()
                        TempPatientID = CInt(.Rows(0)("PatientID"))
                        TempPatientCode = .Rows(0)("PatientCode").ToString
                        'txtSID.Text = GetPatientCode(.Rows(0)("PatientCode").ToString)
                        txtPatientName.Text = .Rows(0)("EnglishName").ToString
                        txtGender.Text = .Rows(0)("Gender").ToString
                        Dim dob As String = .Rows(0)("DOB").ToString
                        If String.IsNullOrEmpty(dob) Then
                            deDOB.DateTime = DateTime.Now.AddYears(-18)
                        Else
                            deDOB.DateTime = Convert.ToDateTime(dob)
                        End If
                        txtAge.Text = .Rows(0)("Age").ToString
                        txtMembership.Text = .Rows(0)("PatientType").ToString
                        CheckPatientReminder(TempPatientCode, CInt(lueClinic.EditValue))
                        lueDoctor.Focus()
                    Else
                        XtraMessageBox.Show("Searching keyword: " + _PatientCode + " doesnot exist on the target system. " & vbNewLine & vbNewLine & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End With
            Else
                XtraMessageBox.Show("Oops, you probably input wrong patient code.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnNew.Enabled = False
                EnabledButtonSave("Check In", False)
                txtPatientName.Text = ""
                txtGender.Text = ""
                deDOB.DateTime = Now.Date.AddYears(-18)
                txtAge.Text = ""
                txtMembership.Text = ""
                txtSID.Focus()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CheckPatientReminder(Optional _PatientCode As String = "", Optional _ClinicID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_CheckPatientReminderAlert", New SqlParameter("@ClinicID", _ClinicID), New SqlParameter("@PatientCode", _PatientCode))
            With dtData
                If .Rows.Count = 1 Then
                    frmPatientReminderAlert._ReminderCode = CInt(.Rows(0)("ReminderCode"))
                    frmPatientReminderAlert.meReminder.Text = "Patient Reminder: " + .Rows(0)("PTReminder").ToString + vbNewLine + vbNewLine + "Reminder is created by " + .Rows(0)("UserCreate").ToString + " on " + CDate(.Rows(0)("DateCreate").ToString).ToString("MMM dd, yyyy hh:mm:ss tt") + "."
                    frmPatientReminderAlert.ShowDialog(Me)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EnabledCheckIn(Optional En As Boolean = True)
        If isLoggedInOwner Then lueClinic.Enabled = En
        lueDoctor.Enabled = En
        deCheckInDate.Enabled = En
        meReasonOfVisit.Enabled = En
    End Sub

    Private Sub lueClinic_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueClinic.Closed
        lueDoctor.Focus()
    End Sub

    Private Sub lueDoctor_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueDoctor.Closed
        meReasonOfVisit.Focus()
    End Sub

    Private Sub deCheckInDate_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles deCheckInDate.Closed
        meReasonOfVisit.Focus()
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim VisitCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VisitCode").ToString)
                LoadSearchItemByID(0, VisitCode)
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
        '        LoadSearchItemByID(0, CInt(SelectedRow("VisitCode")))
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Public Sub LoadSearchItemByID(Optional _ClinicID As Integer = 0, Optional _VisitCode As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientCheckInList", New SqlParameter("@ClinicID", _ClinicID), New SqlParameter("@VisitCode", _VisitCode), New SqlParameter("@IsAdmin", isLoggedInOwner))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True)
                    EnabledCheckIn()
                    IsUpdate = True
                    VisitCode = CInt(.Rows(0)("VisitCode"))
                    TempPatientCode = .Rows(0)("PatientCode").ToString
                    txtSID.Text = FormatPatientCode(.Rows(0)("PatientCode").ToString)
                    txtPatientName.Text = .Rows(0)("EnglishName").ToString
                    txtMembership.Text = .Rows(0)("MembershipType").ToString
                    txtAge.Text = .Rows(0)("Age").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    'If CInt(.Rows(0)("ClinicID")) > 0 Then
                    '    lueClinic.EditValue = CInt(.Rows(0)("ClinicID"))
                    'Else
                    '    lueClinic.EditValue = -1
                    'End If
                    ' MessageBox.Show(.Rows(0)("CheckInToDoctor").ToString)

                    If CInt(.Rows(0)("CheckInToDoctor")) > 0 Then
                        lueDoctor.EditValue = CInt(.Rows(0)("CheckInToDoctor"))
                    Else
                        lueDoctor.EditValue = -1
                    End If
                    deCheckInDate.DateTime = CDate(.Rows(0)("DateIn"))
                    meReasonOfVisit.Text = .Rows(0)("ReasonForVisit").ToString
                Else
                    ClearAllContent()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        lueDoctor.Focus()
    End Sub

    Private Sub bbiPCheckOut_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPCheckOut.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim VisitCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VisitCode").ToString)
                frmPatientCheckOut.LoadSearchItemByID(0, VisitCode)
                LoadFormDialog(frmPatientCheckOut)
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
        '        frmPatientCheckOut.LoadSearchItemByID(0, CInt(SelectedRow("VisitCode")))
        '        LoadFormDialog(frmPatientCheckOut)
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        With gvData
            If .RowCount > 0 Then
                If e.Button = MouseButtons.Right Then
                    Dim _IsCancelled As Boolean = CBool(.GetRowCellValue(.FocusedRowHandle, "IsCancelled"))
                    If _IsCancelled Then
                        bbiPReactivateCheckIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                        bbiPCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    Else
                        bbiPReactivateCheckIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        bbiPCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    End If

                    ppMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
                End If
            End If
        End With
    End Sub

    Private Sub bbiPCancel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPCancel.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to cancell the selected patient visits?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim VisitCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VisitCode").ToString)
                DisabledItems(VisitCode.ToString, 1, 0)
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
        '            _TempID(i) = SelectedRow("VisitCode").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to cancell the selected patient visits?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList, 1, 0)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub DisabledItems(Optional _IDTempList As String = "", Optional _IsCancel As Integer = 0, Optional _IsRemove As Integer = 0, Optional _FlagRemove As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_RemovePatientVisit", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@IsCancell", _IsCancel)
                .AddWithValue("@IsRemove", _IsRemove)
                .AddWithValue("@FlagRemove", _FlagRemove)
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
            LoadPatientCheckIn()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Patient Visit", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to remove the selected patient visits?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim VisitCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VisitCode").ToString)
                DisabledItems(VisitCode.ToString, 0, 1, 1)
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
        '            _TempID(i) = SelectedRow("VisitCode").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to remove the selected patient visits?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList, 0, 1, 1)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to restore the selected patient visits?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim VisitCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VisitCode").ToString)
                DisabledItems(VisitCode.ToString, 0, 0, 1)
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
        '            _TempID(i) = SelectedRow("VisitCode").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to restore the selected patient visits?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList, 0, 0, 1)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub bbiPReactivateCheckIn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPReactivateCheckIn.ItemClick
        Try
            With gvData
                detected = XtraMessageBox.Show("Do you want to reactive the selected patient visits?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim VisitCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VisitCode").ToString)
                DisabledItems(VisitCode.ToString)
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
        '            _TempID(i) = SelectedRow("VisitCode").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to reactive the selected patient visits?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub bbiPExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExport.ItemClick
        ExportToXlsx(dtData, "Patient Visit Report")
    End Sub

    Private Sub gvData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gvData.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As Date = CDate(.GetRowCellValue(e.RowHandle, "DateCheckIn"))
            If DateDiff(DateInterval.Minute, tempVal, Now.Date) > 0 Then e.Appearance.ForeColor = Color.Gray
        End With
    End Sub

    Private Sub txtSID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSID.KeyPress
        PTCode_KeyPress(txtSID, e)
    End Sub

    Private Sub txtSID_Validated(sender As Object, e As EventArgs) Handles txtSID.Validated
        SelectPatientVisit(txtSID.Text.Trim)
    End Sub
End Class