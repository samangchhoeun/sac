Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPatientVitalSign
    Dim TempPatientCode As String = ""
    Dim TempPatientID As Integer = 0
    Dim TempDateCheckIn As DateTime
    Dim dtData As New DataTable
    Dim isClick As Boolean = False
    Dim VitalCode As Integer = 0
    Dim VisitCode As Integer = 0
    Dim dtCheckInDoctorList As New DataTable
    'Dim hasWaitingPatient As Boolean = False
    'Dim hasVitalSign As Boolean = False

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnBMICalc_Click(sender As Object, e As EventArgs) Handles btnBMICalc.Click
        LoadFormDialog(frmBMICalculator)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtSID.Text = ""
        ClearAllContent()
        'hasWaitingPatient = False
        'hasVitalSign = False
        txtSID.Focus()
    End Sub

    Private Sub ClearAllContent()
        txtSID.ReadOnly = False
        VitalCode = 0
        VisitCode = 0
        TempPatientCode = ""
        TempPatientID = 0
        txtPatientName.Text = ""
        txtAge.Text = ""
        txtGender.Text = ""
        txtDOB.Text = ""
        If Not IsNothing(ConfigClinic) Then
            lueClinic.EditValue = ConfigClinic.ClinicID
        Else
            lueClinic.EditValue = -1
        End If
        lcgVitalSignHistory.Text = "Patient Vital Sign History"
        ClearVitalSign()
        gcData.DataSource = Nothing
        gvData.Columns.Clear()
    End Sub

    Private Sub ClearVitalSign()
        deDate.DateTime = Now.Date
        teTime.EditValue = Now.ToLocalTime
        txtHeight.Text = ""
        txtWeight.Text = ""
        txtTemp.Text = ""
        txtBMP.Text = ""
        txtPulse.Text = ""
        txtRR.Text = ""
        txtSao2.Text = ""
        meChiefComplaint.Text = ""
    End Sub

    Private Sub frmPatientVitalSign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AutoCompleteID(txtSID, "SA_GetPatientCodeList")
        deDate.DateTime = Now.Date
        teTime.EditValue = Now.ToLocalTime
        LoadClinic()
        PatientWaitingVitalSign(Now())
        pmMenu.ShowCaption = False
        pmWaitingForVitalSign.ShowCaption = False
        txtSID.Select()
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

    Public Sub SelectPatientVisit(_SelDate As DateTime, Optional _VisitCode As Integer = 0, Optional _IsNoDate As Integer = 0)
        Try
            Dim ClinicID As Integer = 0
            If Not isLoggedInOwner Then ClinicID = ConfigClinic.ClinicID

            Dim dt As DataTable = GetDataFromDBToTable("SA_GetPatientWaitingForVitalSign", New SqlParameter("@VisitCode", _VisitCode), New SqlParameter("@ClinicID", ClinicID), New SqlParameter("@SelDate", _SelDate), New SqlParameter("@IsNoDate", _IsNoDate))
            With dt
                If .Rows.Count = 1 Then
                    txtSID.ReadOnly = True
                    VisitCode = CInt(.Rows(0)("VisitCode").ToString)
                    TempPatientCode = .Rows(0)("PatientCode").ToString
                    'If Not isClick Then txtSID.Text = .Rows(0)("PatientCode").ToString
                    txtSID.Text = .Rows(0)("PatientCode").ToString
                    txtPatientName.Text = .Rows(0)("PatientName").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                    txtAge.Text = .Rows(0)("Age").ToString
                    deDate.DateTime = CDate(.Rows(0)("DateCheckIn").ToString)
                    TempDateCheckIn = Convert.ToDateTime(.Rows(0)("DateCheckIn").ToString)
                    teTime.EditValue = Convert.ToDateTime(.Rows(0)("TimeIn").ToString)
                    meChiefComplaint.Focus()
                Else
                    ClearAllContent()
                    XtraMessageBox.Show("Searching keyword: " + TempPatientCode + " doesnot exist on the target system. " & vbNewLine + vbNewLine & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtHeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHeight.KeyPress
        ValidNumber(sender, e)
    End Sub

    Private Sub txtWeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWeight.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub txtTemp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTemp.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub txtRR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRR.KeyPress
        ValidNumber(sender, e)
    End Sub

    Private Sub txtBMP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBMP.KeyPress
        'ValidDecimal(sender, e)
    End Sub

    Private Sub txtPulse_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPulse.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub txtSao2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSao2.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        'If hasVitalSign Then If e.Button = MouseButtons.Right Then pmMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
        If gvData.RowCount > 0 Then If e.Button = MouseButtons.Right Then pmMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub timPatientWaitingForVitalSign_Tick(sender As Object, e As EventArgs) Handles timPatientWaitingForVitalSign.Tick
        PatientWaitingVitalSign(Now())
    End Sub

    Private Sub PatientWaitingVitalSign(_SelDate As DateTime, Optional _VisitCode As Integer = 0, Optional _IsNoDate As Integer = 1)
        Try
            Dim ClinicID As Integer = 0
            If Not isLoggedInOwner Then ClinicID = ConfigClinic.ClinicID

            Dim dt As DataTable = GetDataFromDBToTable("SA_GetPatientWaitingForVitalSign", New SqlParameter("@VisitCode", _VisitCode), New SqlParameter("@ClinicID", ClinicID), New SqlParameter("@SelDate", _SelDate), New SqlParameter("@IsNoDate", _IsNoDate))
            lcgWaiting.Text = "Patient Waiting for Vital Sign [ " + dt.Rows.Count.ToString + " ]"
            If dt.Rows.Count > 0 Then
                'lcgWaiting.Text = "Patient Waiting for Vital Sign [ " + dt.Rows.Count.ToString + " ]"
                'hasWaitingPatient = True
                gcWaiting.DataSource = dt
                With gvWaiting
                    .PopulateColumns()
                    .Columns("DateCheckIn").DisplayFormat.FormatType = FormatType.DateTime
                    .Columns("DateCheckIn").DisplayFormat.FormatString = "MMM dd, yyyy hh:mm:ss tt"
                    'Dim de As New RepositoryItemDateEdit()
                    'de.Mask.EditMask = "MMM dd, yyyy HH:mm tt"
                    'de.Mask.UseMaskAsDisplayFormat = True
                    '.Columns("DateTimeFU").ColumnEdit = de                    
                    .Columns("VisitCode").Visible = False
                    .Columns("TimeVisit").Visible = False
                    .Columns("TimeIn").Visible = False
                    .Columns("PatientCode").Width = 60
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("PatientName").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("DateCheckIn").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("DateCheckIn").SummaryItem.DisplayFormat = "Total: {0}"
                    .BestFitColumns()
                End With
            Else
                'hasWaitingPatient = False
                gcWaiting.DataSource = Nothing
                gvWaiting.Columns.Clear()
            End If
        Catch ex As Exception

        End Try

        'Dim Table As New DataTable

        'Table = Get_DataTable(" SELECT tblPatient.ptCode as [Patient Code],EName as Name,Gender as Sex,Substring(cast(convert(nvarchar,Datein,100) as nvarchar),12,8) as [Time in] " &
        '                    " FROM tblPatient INNER JOIN tblVisits ON tblPatient.ptCode=tblVisits.ptcode " &
        '                    " WHERE tblVisits.visitCode NOT IN (SELECT visitcode FROM tblVitalSign WHERE  tblVitalSign.isActive='true') " &
        '                    " AND cast(convert(nvarchar,datein,101) AS DATETIME) = cast(convert(nvarchar,GETDATE(),101) AS DATETIME) AND tblvisits.branch='" & CurrentBranch & "' AND tblvisits.isActive='True' AND Dateout IS NULL  ORDER BY Datein ")
        'GridControl1_PatientWaitingVitalSign.DataSource = Table

        'If GridView1_PatientWaitingVitalSign.RowCount > 0 Then
        '    GridView1_PatientWaitingVitalSign.Columns(0).Width = 100
        '    GridView1_PatientWaitingVitalSign.Columns(1).Width = 130
        '    GridView1_PatientWaitingVitalSign.Columns(2).Width = 70
        '    GridView1_PatientWaitingVitalSign.Columns(3).Width = 70
        '    LayoutControlGroup1.Text = "Patient Waiting for Vital Sign (" & GridView1_PatientWaitingVitalSign.RowCount & ")"
        'Else
        '    GridView1_PatientWaitingVitalSign.Columns.Clear()
        'End If
    End Sub

    Private Sub gcWaiting_MouseClick(sender As Object, e As MouseEventArgs) Handles gcWaiting.MouseClick
        'If hasWaitingPatient Then
        '    If e.Button = MouseButtons.Right Then
        '        timPatientWaitingForVitalSign.Enabled = False
        '        pmWaitingForVitalSign.ShowPopup(Me.bmMenu, Control.MousePosition)
        '    End If
        'End If

        If e.Button = MouseButtons.Right Then
            timPatientWaitingForVitalSign.Enabled = False
            If gvWaiting.RowCount > 0 Then pmWaitingForVitalSign.ShowPopup(Me.bmMenu, Control.MousePosition)
        End If
    End Sub

    Private Sub bbiPVitalSign_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPVitalSign.ItemClick
        Try
            With gvWaiting
                Dim VisitCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VisitCode").ToString)
                Dim PatientCode As String = .GetRowCellValue(.FocusedRowHandle, "PatientCode").ToString.Replace("-", "")
                SelectPatientVisit(Now(), VisitCode)
                PatientVitalSignHistory(PatientCode)
            End With
        Catch ex As Exception
            ClearAllContent()
            txtSID.Focus()
        End Try
        timPatientWaitingForVitalSign.Enabled = True
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        LoadFormDialog(frmPatientWaitingForVitalSign)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(TempPatientCode) OrElse VisitCode = 0 Then
            XtraMessageBox.Show("Please select patient to set the vital sign.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnBrowse.Focus()
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SavePatientVisitSign", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@VitalCode", VitalCode)
                .AddWithValue("@VisitCode", VisitCode)
                .AddWithValue("@PatientCode", TempPatientCode)
                .AddWithValue("@Weight", txtWeight.Text.Trim)
                .AddWithValue("@Height", txtHeight.Text.Trim)
                .AddWithValue("@Temperature", txtTemp.Text.Trim)
                .AddWithValue("@BPM", txtBMP.Text.Trim)
                .AddWithValue("@bpLeft", 0)
                .AddWithValue("@bpRight", 0)
                .AddWithValue("@Pulse", txtPulse.Text.Trim)
                .AddWithValue("@Respiration", txtRR.Text.Trim)
                .AddWithValue("@SaO2", txtSao2.Text.Trim)
                .AddWithValue("@DateVitalSign", TempDateCheckIn)
                .AddWithValue("@ChiefComplaint", meChiefComplaint.Text.Trim)
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
            PatientWaitingVitalSign(Now())
            PatientVitalSignHistory(TempPatientCode)
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Set Vital Sign", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnNew.Enabled = True
        btnNew.Focus()
    End Sub

    Public Sub SelectPatientVitalSign(Optional _VitalCode As Integer = 0, Optional _PatientCode As String = "")
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetPatientVitalSign", New SqlParameter("@VitalCode", _VitalCode), New SqlParameter("@PatientCode", _PatientCode))
            With dt
                If .Rows.Count = 1 Then
                    txtSID.ReadOnly = True
                    VitalCode = CInt(.Rows(0)("VitalCode").ToString)
                    VisitCode = CInt(.Rows(0)("VisitCode").ToString)
                    TempPatientCode = .Rows(0)("PatientCode").ToString
                    txtSID.Text = .Rows(0)("PatientCode").ToString
                    txtPatientName.Text = .Rows(0)("PatientName").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                    txtAge.Text = .Rows(0)("Age").ToString
                    deDate.DateTime = CDate(.Rows(0)("DateVitalSign").ToString)
                    TempDateCheckIn = CDate(.Rows(0)("DateVitalSign").ToString)
                    teTime.EditValue = CDate(.Rows(0)("TimeIn").ToString)
                    txtHeight.Text = .Rows(0)("Height").ToString
                    txtWeight.Text = .Rows(0)("Weight").ToString
                    txtTemp.Text = .Rows(0)("Temperature").ToString
                    txtBMP.Text = .Rows(0)("BPM").ToString
                    txtPulse.Text = .Rows(0)("Pulse").ToString
                    txtRR.Text = .Rows(0)("Respiration").ToString
                    txtSao2.Text = .Rows(0)("SaO2").ToString
                    meChiefComplaint.Text = .Rows(0)("ChiefComplaint").ToString
                    meChiefComplaint.Focus()
                Else
                    ClearAllContent()
                    XtraMessageBox.Show("Searching keyword: " + _PatientCode + " doesnot exist on the target system. " & vbLf & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub PatientVitalSignHistory(Optional _PatientCode As String = "", Optional _VitalCode As Integer = 0)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetPatientVitalSign", New SqlParameter("@VitalCode", _VitalCode), New SqlParameter("@PatientCode", _PatientCode))
            lcgVitalSignHistory.Text = "Patient Vital Sign History [ " + dt.Rows.Count.ToString + " ]"

            If dt.Rows.Count > 0 Then
                'hasVitalSign = True
                gcData.DataSource = dt
                With gvData
                    .PopulateColumns()
                    .Columns("DateVitalSign").DisplayFormat.FormatType = FormatType.DateTime
                    .Columns("DateVitalSign").DisplayFormat.FormatString = "MMM dd, yyyy hh:mm:ss tt"
                    'Dim de As New RepositoryItemDateEdit()
                    'de.Mask.EditMask = "MMM dd, yyyy HH:mm tt"
                    'de.Mask.UseMaskAsDisplayFormat = True
                    '.Columns("DateTimeFU").ColumnEdit = de                    
                    .Columns("VisitCode").Visible = False
                    .Columns("VitalCode").Visible = False
                    .Columns("TimeIn").Visible = False
                    .Columns("DOB").Visible = False
                    .Columns("Age").Visible = False
                    .Columns("Gender").Visible = False
                    .Columns("PatientName").Visible = False
                    .Columns("PatientCode").Visible = False
                    .Columns("ClinicEn").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("ChiefComplaint").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            Else
                'hasVitalSign = False
                gcData.DataSource = Nothing
                gvData.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        ClearAllContent()
    '        TempPatientCode = txtSID.Text.Trim
    '        If String.IsNullOrEmpty(TempPatientCode) Then
    '            XtraMessageBox.Show("Please enter Patient Code before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            txtSID.Focus()
    '            Return
    '        End If
    '        txtSID.Text = txtSID.Text.Trim.ToUpper
    '        SelectPatientVisit(TempPatientCode)
    '    End If
    'End Sub

    Private Sub SelectPatientVisit(_PatientCode As String)
        Try
            TempPatientCode = GetStandardPatientCode(_PatientCode)
            If String.IsNullOrEmpty(_PatientCode) Then ClearAllContent() : Exit Sub
            If Len(TempPatientCode) = 9 Then
                Dim dt As DataTable = GetDataFromDBToTable("SA_GetPatientProfile", New SqlParameter("@PatientCode", TempPatientCode))
                With dt
                    If .Rows.Count = 1 Then
                        txtSID.ReadOnly = True
                        TempPatientID = CInt(.Rows(0)("PatientID"))
                        TempPatientCode = .Rows(0)("PatientCode").ToString
                        txtPatientName.Text = .Rows(0)("EnglishName").ToString
                        txtGender.Text = .Rows(0)("Gender").ToString
                        txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                        txtAge.Text = .Rows(0)("Age").ToString
                        If Not IsNothing(ConfigClinic) Then
                            lueClinic.EditValue = ConfigClinic.ClinicID
                        Else
                            lueClinic.EditValue = -1
                        End If
                        PatientVitalSignHistory(TempPatientCode)
                        frmPatientVisit.CheckPatientReminder(TempPatientCode, CInt(lueClinic.EditValue))
                        If Not IsSelPatientCheckIn(TempPatientCode) Then
                            ClearVitalSign()
                            XtraMessageBox.Show("Please check-in Patient= " + _PatientCode + " before adding vital sign.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtSID.ReadOnly = False
                            txtSID.Focus()
                        Else
                            meChiefComplaint.Focus()
                        End If
                    Else
                        ClearAllContent()
                        XtraMessageBox.Show("Searching keyword: " + _PatientCode + " doesnot exist on the target system. " & vbNewLine & vbNewLine & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End With
            Else
                XtraMessageBox.Show("Oops, you probably input wrong patient code.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPatientName.Text = ""
                txtGender.Text = ""
                txtDOB.Text = ""
                txtAge.Text = ""
                lueClinic.EditValue = -1
                txtSID.Focus()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function IsSelPatientCheckIn(Optional _PatientCode As String = "", Optional _VisitCode As Integer = 0) As Boolean
        Dim isCheckIn As Boolean = False
        Try
            dtCheckInDoctorList = GetDataFromDBToTable("SA_IsSelPatientCheckIn", New SqlParameter("@VisitCode", _VisitCode), New SqlParameter("@PatientCode", _PatientCode))
            If dtCheckInDoctorList.Rows.Count > 1 Then isCheckIn = True
        Catch ex As Exception

        End Try
        Return isCheckIn
    End Function


    'Public Sub CheckPatientReminder(Optional _PatientCode As String = "", Optional _ClinicID As Integer = 0)
    '    Try
    '        Dim dt As DataTable = GetDataFromDBToTable("SA_CheckPatientReminderAlert", New SqlParameter("@ClinicID", _ClinicID), New SqlParameter("@PatientCode", _PatientCode))
    '        With dt
    '            If .Rows.Count = 1 Then
    '                frmPatientReminderAlert._ReminderCode = CInt(.Rows(0)("ReminderCode"))
    '                frmPatientReminderAlert.meReminder.Text = "Patient Reminder: " + .Rows(0)("PTReminder").ToString + vbNewLine + vbNewLine + "Reminder is created by " + .Rows(0)("UserCreate").ToString + " on " + CDate(.Rows(0)("DateCreate").ToString).ToString("MMM dd, yyyy hh:mm:ss tt") + "."
    '                frmPatientReminderAlert.ShowDialog(Me)
    '            End If
    '        End With
    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub bbiPExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExport.ItemClick
        ExportToXlsx(dtData, "Patient Vital Sign History Report")
    End Sub

    Private Sub bbiPAddNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAddNew.ItemClick
        btnNew_Click(Nothing, Nothing)
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            With gvData
                Dim VitalCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VitalCode").ToString)
                SelectPatientVitalSign(VitalCode, "")
            End With
        Catch ex As Exception
            ClearVitalSign()
            txtSID.Focus()
        End Try
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            With gvData
                Dim VitalCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VitalCode").ToString)
                detected = XtraMessageBox.Show("Do you want to remove the selected vital sign (Yes: Disable, No: Permanently)?", "Confirm Remove?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If detected = DialogResult.Cancel Then Return
                If detected = DialogResult.Yes Then
                    DisabledItems(VitalCode.ToString, 1)
                Else
                    DisabledItems(VitalCode.ToString, 1, 1)
                End If
            End With
        Catch ex As Exception
            ClearVitalSign()
            txtSID.Focus()
        End Try
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        Try
            With gvData
                Dim VitalCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VitalCode").ToString)
                detected = XtraMessageBox.Show("Do you want to restore the selected schedule?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                DisabledItems(VitalCode.ToString)
            End With
        Catch ex As Exception
            ClearVitalSign()
            txtSID.Focus()
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
            PatientVitalSignHistory(TempPatientCode)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Patient Vital Sign", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub gvWaiting_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gvWaiting.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As Date = CDate(.GetRowCellValue(e.RowHandle, "DateCheckIn"))
            If DateDiff(DateInterval.Minute, tempVal, Now.Date) >= 0 Then e.Appearance.ForeColor = Color.Gray
        End With
    End Sub

    Private Sub txtSID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSID.KeyPress
        PTCode_KeyPress(txtSID, e)
    End Sub

    Private Sub txtSID_Validated(sender As Object, e As EventArgs) Handles txtSID.Validated
        SelectPatientVisit(txtSID.Text.Trim)
    End Sub

    Private Sub txtSID_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSID.KeyUp
        If String.IsNullOrEmpty(txtSID.Text.Trim) Then
            btnBrowse.Enabled = True
        Else
            btnBrowse.Enabled = False
        End If
    End Sub
End Class