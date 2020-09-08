Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPatientFollowUp
    Dim ID As Integer = 0
    Dim TempPatientCode As String = ""
    Public TempDate As DateTime = Now.Date
    Public TempDoctor As Integer = 0
    Public TempTime As String = ""
    Public IsFormClick As Boolean = False
    Dim IsModify As Boolean = False
    Dim dtData As New DataTable

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        txtSID.ReadOnly = False
        btnNew.Enabled = False
        txtSID.Text = ""
        txtSID.Focus()
    End Sub

    Private Sub ClearAllContent()
        ID = 0
        IsModify = False
        txtPatient.Text = ""
        txtCity.Text = ""
        txtCellPhone.Text = ""
        txtGender.Text = ""
        txtAge.Text = ""
        meNote.Text = ""
        txtDOB.Text = ""
        deAppointmentDate.DateTime = TempDate
        lueAppoitmentType.EditValue = -1
        EnabledButtonSave()
    End Sub


    Private Sub frmPatientFollowUp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
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

    Private Sub SelectPatientVisit(_PatientCode As String)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientProfile", New SqlParameter("@PatientCode", _PatientCode))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True, True)
                    'EnabledEdit()
                    btnNew.Enabled = True
                    TempPatientCode = .Rows(0)("PatientCode").ToString
                    'txtSID.Text = GetPatientCode(.Rows(0)("PatientCode").ToString)
                    txtPatient.Text = .Rows(0)("EnglishName").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                    txtAge.Text = .Rows(0)("Age").ToString
                    txtCellPhone.Text = .Rows(0)("CellPhone").ToString
                    txtCity.Text = .Rows(0)("City").ToString
                    LoadFollowUpSchedule(TempDoctor, TempDate, _PatientCode)
                    lueClinic.Focus()
                Else
                    ClearAllContent()
                    XtraMessageBox.Show("Searching keyword: " + _PatientCode + " doesnot exist on the target system. " & vbLf & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
        btnDelete.Enabled = del
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        lueClinic.Enabled = en
        lueDoctor.Enabled = en
        lueAppoitmentType.Enabled = en
        deAppointmentDate.Enabled = en
        lueTime.Enabled = en
        meNote.Enabled = en
    End Sub

    Public Sub LoadFollowUpSchedule(_Doctor As Integer, SelDate As DateTime, _PatientCode As String, Optional _ID As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_CheckPatientFollowup", New SqlParameter("@ID", _ID), New SqlParameter("@DoctorID", _Doctor), New SqlParameter("@SelDate", SelDate), New SqlParameter("@PatientCode", _PatientCode), New SqlParameter("@NoDate", 1))
            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .Columns("DateTimeFU").DisplayFormat.FormatType = FormatType.DateTime
                    .Columns("DateTimeFU").DisplayFormat.FormatString = "MMM dd, yyyy hh:mm tt"
                    'Dim de As New RepositoryItemDateEdit()
                    'de.Mask.EditMask = "MMM dd, yyyy HH:mm tt"
                    'de.Mask.UseMaskAsDisplayFormat = True
                    '.Columns("DateTimeFU").ColumnEdit = de
                    .Columns("TranID").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Columns("DateFU").Visible = False
                    .Columns("TimeFU").Visible = False
                    .Columns("PatientCode").Visible = False
                    .Columns("PatientName").Visible = False
                    .Columns("Gender").Visible = False
                    .Columns("Age").Visible = False
                    .Columns("DOB").Visible = False
                    .Columns("PatientCode").Width = 60
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("PatientName").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("Doctor").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("TypeFU").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("ReminderToUsername").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("Note").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            Else
                gcData.DataSource = Nothing
                gvData.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(TempPatientCode) Then
            XtraMessageBox.Show("Please select patient to set follow up schedule.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSID.Focus()
        ElseIf CInt(lueClinic.EditValue) <= 0 Or CInt(lueDoctor.EditValue) <= 0 Or CInt(lueAppoitmentType.EditValue) <= 0 Then
            XtraMessageBox.Show("Please select required information from the box.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lueClinic.Focus()
            Return
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SavePatientFollowUp", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", ID)
                .AddWithValue("@PatientCode", TempPatientCode)
                .AddWithValue("@DateTimeFU", ClinicConfiguration.ActivateDate(deAppointmentDate.DateTime.ToShortDateString) + " " + ClinicConfiguration.ActivateTime(lueTime.EditValue.ToString))
                .AddWithValue("@DoctorID", CInt(lueDoctor.EditValue))
                .AddWithValue("@ClinicID", ConfigClinic.ClinicID)
                .AddWithValue("@TypeFU", CInt(lueAppoitmentType.EditValue))
                .AddWithValue("@Note", meNote.Text.Trim)
                .AddWithValue("@IsConfirmed", 0)
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
            LoadFollowUpSchedule(CInt(lueDoctor.EditValue), CDate(deAppointmentDate.DateTime), TempPatientCode)
            frmPatientScheduleFollowupView.InitDataToGrid()
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Set Schedule", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnNew.Enabled = True
        btnNew.Focus()
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = MouseButtons.Right Then ppMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            Dim SelRows() As Integer = gvData.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("TranID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove the selected schedule (Yes: Disable, No: Permanently)?", "Confirm Remove?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If detected = DialogResult.Cancel Then Return
            btnDelete.Enabled = False
            If detected = DialogResult.Yes Then
                DisabledItems(_IDTempList, 1)
            Else
                DisabledItems(_IDTempList, 1, 1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            Dim SelRows As Integer() = gvData.GetSelectedRows()
            Dim i = 0
            For Each index As Integer In SelRows
                If (index >= 0) Then i += 1
            Next
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i > 1 Then
                XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i = 1 Then
                IsModify = True
                Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(SelRows(0)), DataRowView)
                LoadPatientFollowup(TempDoctor, TempDate, TempPatientCode, CInt(SelectedRow("TranID")))
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        Try
            Dim SelRows() As Integer = gvData.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("TranID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to restore the selected schedule?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledItems(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisabledItems(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0, Optional _IsPermanent As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisablePatientFollowUp", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@Inactive", _Inactive)
                .AddWithValue("@IsPermanent", _IsPermanent)
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
            LoadFollowUpSchedule(CInt(lueDoctor.EditValue), CDate(deAppointmentDate.DateTime), TempPatientCode)
            frmPatientScheduleFollowupView.InitDataToGrid()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Patient Schedule", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bbiPExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExport.ItemClick
        ExportToXlsx(dtData, "Patient Follow Up Schedule Report")
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If ID = 0 Then
                XtraMessageBox.Show("Please select patient to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSID.Focus()
                Return
            End If
            detected = XtraMessageBox.Show("Do you want to remove the selected schedule (Yes: Permanently, No: Disable)?", "Confirm Remove?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If detected = DialogResult.Cancel Then Return
            btnDelete.Enabled = False
            If detected = DialogResult.Yes Then
                DisabledItems(ID.ToString, 1, 1)
            Else
                DisabledItems(ID.ToString, 1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmPatientFollowUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoCompleteID(txtSID, "SA_GetPatientCodeList")
        deAppointmentDate.DateTime = TempDate
        GetDataToLookupEdit(lueTime, InitTime, "ID", "Time")
        lueTime.EditValue = TempTime
        InitClinic()
        InitDoctor()
        InitAppointmentType()
        If IsFormClick Then
            deAppointmentDate.Enabled = False
            lueTime.Enabled = False
        Else
            deAppointmentDate.Enabled = True
            lueTime.Enabled = True
        End If
        If isLoggedInOwner Then bbiPRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub

    Private Function InitTime() As List(Of FollowUpTime)
        Dim lstTime As New List(Of FollowUpTime)
        Dim timStart As DateTime = Convert.ToDateTime("6:00 AM")
        Dim timEnd As DateTime = Convert.ToDateTime("9:00 PM")
        Dim i As Integer = 1
        While (timStart <= timEnd)
            Dim Temp As New FollowUpTime
            Temp.ID = timStart.ToShortTimeString
            Temp.Time = timStart.ToShortTimeString
            lstTime.Add(Temp)
            timStart = timStart.AddMinutes(15)
        End While
        Return lstTime
    End Function


    Public Sub LoadPatientFollowup(_Doctor As Integer, SelDate As DateTime, _PatientCode As String, Optional _ID As Integer = 0)
        Try
            Dim ds As DataTable = GetDataFromDBToTable("SA_CheckPatientFollowup", New SqlParameter("@ID", _ID), New SqlParameter("@DoctorID", _Doctor), New SqlParameter("@SelDate", SelDate), New SqlParameter("@PatientCode", _PatientCode), New SqlParameter("@NoDate", 0))
            With ds
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True, True)
                    'EnabledEdit()                    
                    btnNew.Enabled = True
                    ID = CInt(.Rows(0)("TranID"))
                    TempPatientCode = .Rows(0)("PatientCode").ToString
                    txtSID.Text = .Rows(0)("PatientCodeF").ToString
                    txtPatient.Text = .Rows(0)("PatientName").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                    txtCellPhone.Text = .Rows(0)("CellPhone").ToString
                    txtAge.Text = .Rows(0)("Age").ToString
                    txtCity.Text = .Rows(0)("City").ToString
                    If CInt(.Rows(0)("TypeFU")) > 0 Then
                        lueAppoitmentType.EditValue = CInt(.Rows(0)("TypeFU"))
                    Else
                        lueAppoitmentType.EditValue = -1
                    End If
                    meNote.Text = .Rows(0)("Note").ToString

                    If IsModify Then
                        If CInt(.Rows(0)("DoctorID")) > 0 Then
                            lueDoctor.EditValue = CInt(.Rows(0)("DoctorID"))
                        Else
                            lueDoctor.EditValue = TempDoctor
                        End If
                        If CInt(.Rows(0)("ClinicID")) > 0 Then
                            lueClinic.EditValue = CInt(.Rows(0)("ClinicID"))
                        ElseIf Not IsNothing(ConfigClinic) Then
                            lueClinic.EditValue = ConfigClinic.ClinicID
                        Else
                            lueClinic.EditValue = -1
                        End If
                        If Not String.IsNullOrEmpty(.Rows(0)("DateFU").ToString) Then
                            deAppointmentDate.DateTime = CDate(.Rows(0)("DateFU"))
                        Else
                            deAppointmentDate.DateTime = TempDate
                        End If
                        If Not String.IsNullOrEmpty(.Rows(0)("TimeFU").ToString) Then
                            lueTime.EditValue = .Rows(0)("TimeFU").ToString
                        Else
                            lueTime.EditValue = TempTime
                        End If
                    Else
                        lueDoctor.EditValue = TempDoctor
                        If Not IsNothing(ConfigClinic) Then
                            lueClinic.EditValue = ConfigClinic.ClinicID
                        Else
                            lueClinic.EditValue = -1
                        End If
                        deAppointmentDate.DateTime = TempDate
                        lueTime.EditValue = TempTime
                    End If
                Else
                    ClearAllContent()
                    gvData.Focus()
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InitClinic()
        Try
            GetDataToComboBoxWithParam(lueClinic, "SA_GetClinicByID", "ClinicID", "ClinicEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 2))
            If Not IsNothing(ConfigClinic) Then
                lueClinic.EditValue = ConfigClinic.ClinicID
            Else
                lueClinic.EditValue = -1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InitDoctor()
        Try
            GetDataToComboBoxWithParam(lueDoctor, "SA_GetDoctorsToList", "ID", "Doctor", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
            lueDoctor.EditValue = TempDoctor
        Catch ex As Exception
        End Try
    End Sub

    Private Sub InitAppointmentType()
        Try
            GetDataToComboBoxWithParam(lueAppoitmentType, "SA_GetPatientAppointmentType", "ID", "AppointmentType", New SqlParameter("@ID", 0))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bbiPRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRefresh.ItemClick
        LoadFollowUpSchedule(TempDoctor, TempDate, TempPatientCode)
    End Sub

    Private Sub gvData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gvData.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As DateTime = Convert.ToDateTime(.GetRowCellValue(e.RowHandle, "DateTimeFU"))
            If DateDiff(DateInterval.Second, tempVal, Convert.ToDateTime(Now)) > 0 Then e.Appearance.ForeColor = Color.Gray
        End With
    End Sub
End Class