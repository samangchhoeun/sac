Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPatientTreatment
    Dim index As Integer = 0
    Dim dtVitalSign As New DataTable
    Dim TempPatientCode As String = ""
    Dim VisitCode As Integer = 0

    Dim TempHeight As Double = 0.0
    Dim TempWeight As Double = 0.0
    Dim lstPatientDiagnosis As New List(Of PatientDiagnosis)
    Dim IsModify As Boolean = False
    Dim TempDxID As Integer = 0

    Private Sub frmPatientTreatment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoCompleteID(txtPatientCode, "SA_GetPatientCodeList")
        AutoCompleteID(txtDxCode, "SA_GetDiagnosisByDxCode", New SqlParameter("@DxCode", txtDxCode.Text.Trim), New SqlParameter("@Flag", 0))

        If Not IsNothing(ConfigClinic) Then
            txtClinic.Text = ConfigClinic.Clinic
            txtBuilding.Text = ConfigClinic.Building
        Else
            txtClinic.Text = "None"
            txtBuilding.Text = "None"
        End If
        LoadDoctor()
        InitPatientWaitingTreatment()
        LoadClinic()
        LoadDiagnosisGroup()
    End Sub

    Private Sub LoadDoctor()
        Try
            GetDataToComboBoxWithParam(lueDoctor, "SA_GetDoctorsToList", "ID", "Doctor", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception

        End Try
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


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub LoadDiagnosisGroup()
        Try
            GetDataToComboBoxWithParam(lueDxGroup, "SA_GetDiagnosisGroupByID", "Code", "DxGroupEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDiagnosis(_DxGroupID As Integer)
        Try
            GetDataToComboBoxWithParam(lueDiagnosis, "SA_GetDiagnosisByID", "DiagnosisCode", "DxEn", New SqlParameter("@ID", 0), New SqlParameter("@DxGroup", _DxGroupID), New SqlParameter("@isList", 1))
            'txtDxCode.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lueDxGroup_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueDxGroup.Closed
        If CInt(lueDxGroup.EditValue) >= 0 Then
            LoadDiagnosis(CInt(lueDxGroup.EditValue))
            'lueDiagnosis.Focus()
        Else
            'lueDxGroup.Focus()
        End If
    End Sub

    Private Sub frmPatientTreatment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Public Sub GetSearchDataByID(Optional Find_ID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetDxDiagnosisCode", New SqlParameter("@ID", Find_ID))
            With dtData
                If .Rows.Count = 1 Then
                    txtDxCode.Text = .Rows(0)("DxCode").ToString
                    txtNote.Focus()
                Else
                    txtDxCode.Text = ""
                    lueDiagnosis.Focus()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lueDiagnosis_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueDiagnosis.Closed
        If CInt(lueDiagnosis.EditValue) > 0 Then GetSearchDataByID(CInt(lueDiagnosis.EditValue))
    End Sub

    Private Sub ClearAllContent()
        index = 0
        TempPatientCode = ""
        VisitCode = 0
        TempHeight = 0.0
        TempWeight = 0.0
        txtPatient.Text = ""
        txtGender.Text = ""
        txtDOB.Text = ""
        txtAge.Text = ""
        txtPatientType.Text = ""
        'lueClinic.EditValue = -1
        txtDateCheckIn.Text = ""
        mePatientComplaint.Text = ""
        meProgressNote.Text = ""
        lueDxGroup.EditValue = -1
        lueDiagnosis.EditValue = -1
        txtDxCode.Text = ""
        txtNote.Text = ""
        lblRec.Text = "0 / 0"
        btnNext.Enabled = False
        btnPrev.Enabled = False
        btnChoose.Enabled = False
        btnBMICalc.Enabled = False
        IsModify = False
        lcgWaiting.Text = "Patients Waiting for Treatment"
        lcgVitalSignHistory.Text = "Vital Sign Information"
        lcgDiagnosis.Text = "Diagnosis Information"
        gcVitalSign.DataSource = Nothing
        gvVitalSign.Columns.Clear()
        gcDiagnosis.DataSource = Nothing
        gvDiagnosis.Columns.Clear()
    End Sub

    Private Sub btnBMICalc_Click(sender As Object, e As EventArgs) Handles btnBMICalc.Click
        'Try
        '    Dim dt As DataTable = GetDataFromDBToTable("SA_GetDataForBMI", New SqlParameter("@PatientCode", TempPatientCode))
        '    With dt
        '        If .Rows.Count > 0 Then
        '            frmBMICalculator.txtHeight.Text = .Rows(0)("Height").ToString
        '            frmBMICalculator.txtWeight.Text = .Rows(0)("Weight").ToString
        '            frmBMICalculator.btnCalculate_Click(sender, e)
        '        End If
        '    End With
        'Catch ex As Exception
        'End Try
        Try
            frmBMICalculator.txtHeight.Text = TempHeight.ToString
            frmBMICalculator.txtWeight.Text = TempWeight.ToString
            frmBMICalculator.btnCalculate_Click(sender, e)
        Catch ex As Exception

        End Try
        LoadFormDialog(frmBMICalculator)
    End Sub

    Private Sub btnRx_Click(sender As Object, e As EventArgs) Handles btnRx.Click
        LoadForm(frmPatientPrescription)
    End Sub

    Private Sub bbiPTreatment_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPTreatment.ItemClick
        Try
            If CInt(lueDoctor.EditValue) > 0 Then
                With gvPatientsWaiting
                    Dim VisitCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VisitCode").ToString)
                    TempPatientCode = .GetRowCellValue(.FocusedRowHandle, "PatientCode").ToString.Replace("-", "")
                    SelectPatientForTreatment(TempPatientCode)
                    'PatientVitalSignHistory(TempPatientCode)
                End With
            Else
                XtraMessageBox.Show("Please choose a doctor to treat a patient", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lueDoctor.Focus()
            End If
        Catch ex As Exception
            ClearAllContent()
            mePatientComplaint.Focus()
        End Try
        timPatientWaiting.Enabled = True
    End Sub

    Private Sub gcPatientsWaiting_MouseClick(sender As Object, e As MouseEventArgs) Handles gcPatientsWaiting.MouseClick
        If e.Button = MouseButtons.Right Then ppPatientWaiting.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub


    Public Sub PatientVitalSignHistory(Optional _PatientCode As String = "", Optional _VitalCode As Integer = 0)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetPatientVitalSign", New SqlParameter("@VitalCode", _VitalCode), New SqlParameter("@PatientCode", _PatientCode))
            If dt.Rows.Count > 0 Then
                lcgVitalSignHistory.Text = "Vital Sign Information [ " + dt.Rows.Count.ToString + " ]"
                'hasVitalSign = True
                gcVitalSign.DataSource = dt
                With gvVitalSign
                    .PopulateColumns()
                    .Columns("DateVitalSign").DisplayFormat.FormatType = FormatType.DateTime
                    .Columns("DateVitalSign").DisplayFormat.FormatString = "MMM dd, yyyy hh:mm tt"
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
                    .Columns("Inactive").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("ChiefComplaint").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            Else
                'hasVitalSign = False
                gcVitalSign.DataSource = Nothing
                gvVitalSign.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        txtPatientCode.Text = ""
        btnChoose.Enabled = False
        txtPatientCode.Focus()
        btnNew.Enabled = False
        txtPatientCode.ReadOnly = False
    End Sub

    Private Sub timPatientWaiting_Tick(sender As Object, e As EventArgs) Handles timPatientWaiting.Tick
        InitPatientWaitingTreatment()
    End Sub

    Private Sub InitPatientWaitingTreatment(Optional _PatientCode As String = "", Optional _Doctor As Integer = 0)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetPatientWaitingforTreatment", New SqlParameter("@PatientCode", _PatientCode), New SqlParameter("@Doctor", _Doctor))
            If dt.Rows.Count > 0 Then
                lcgWaiting.Text = "Patients Waiting for Treatment [ " + dt.Rows.Count.ToString + " ]"
                gcPatientsWaiting.DataSource = dt
                With gvPatientsWaiting
                    .PopulateColumns()
                    .Columns("DateIn").DisplayFormat.FormatType = FormatType.DateTime
                    .Columns("DateIn").DisplayFormat.FormatString = "MMM dd, yyyy hh:mm tt"
                    .Columns("VisitCode").Visible = False
                    .Columns("VitalCode").Visible = False
                    '.Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("ChiefComplaint").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("ClinicEn").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("ClinicEn").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            Else
                gcPatientsWaiting.DataSource = Nothing
                gvPatientsWaiting.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvVitalSign_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gvVitalSign.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As DateTime = CDate(.GetRowCellValue(e.RowHandle, "DateVitalSign"))
            If DateDiff(DateInterval.Minute, tempVal, Now.Date) >= 0 Then e.Appearance.ForeColor = Color.Gray
        End With
    End Sub

    Private Sub SetColorFormatting()
        Dim cn As StyleFormatCondition
        cn = New StyleFormatCondition(FormatConditionEnum.Equal, gvVitalSign.Columns("VisitCode"), Nothing, VisitCode)
        cn.Appearance.BackColor = Color.Pink
        cn.Appearance.ForeColor = Color.Black
        cn.ApplyToRow = True
        gvVitalSign.FormatConditions.Add(cn)

        cn = New StyleFormatCondition(FormatConditionEnum.NotEqual, gvVitalSign.Columns("VisitCode"), Nothing, VisitCode)
        cn.Appearance.BackColor = Color.White
        cn.Appearance.ForeColor = Color.Black
        cn.ApplyToRow = True
        gvVitalSign.FormatConditions.Add(cn)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            If (index < dtVitalSign.Rows.Count - 1) Then
                index += 1
                GetScrollRecord(index)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("There is no record found.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Try
            If (index > 0) Then
                index -= 1
                GetScrollRecord(index)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("There is no record found.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub GetScrollRecord(ind As Integer)
        Try
            dtVitalSign.Clear()
            dtVitalSign = GetDataFromDBToTable("SA_GetPatientTreatmentHistory", New SqlParameter("@PatientCode", TempPatientCode), New SqlParameter("@VisitCode", 0))
            If dtVitalSign.Rows.Count = 0 Then
                btnNext.Enabled = False
                btnPrev.Enabled = False
                lblRec.Text = "0 / 0"
                Exit Sub
            ElseIf ind = 0 Then
                btnNext.Enabled = True
                btnPrev.Enabled = False
            ElseIf ind = dtVitalSign.Rows.Count - 1 Then
                btnNext.Enabled = False
                btnPrev.Enabled = True
            Else
                btnNext.Enabled = True
                btnPrev.Enabled = True
            End If

            Dim Drow As DataRow = dtVitalSign.Rows(ind)
            TempWeight = CDbl(Drow("Weight"))
            TempHeight = CDbl(Drow("Height"))
            mePatientComplaint.Text = IIf(IsDBNull(Drow("PTComplain")), "", Drow("PTComplain")).ToString
            meProgressNote.Text = IIf(IsDBNull(Drow("DRProgressNote")), "", Drow("DRProgressNote")).ToString
            lueClinic.EditValue = CInt(Drow("ClinicID"))
            VisitCode = CInt(Drow("VisitCode"))
            txtDateCheckIn.Text = CDate(Drow("DateIn")).ToString("MMM dd, yyyy hh:mm tt")
            GetPatientDiagnosisList(TempPatientCode, VisitCode)

            'Load_Diagnosis_List() ' Desplay Dx list after click on < or >
            If Not IsDBNull(Drow("VisitedDoctor")) Then lueDoctor.EditValue = CInt(Drow("VisitedDoctor"))
            dtVitalSign.Dispose()
            SetColorFormatting()
            lblRec.Text = ind + 1 & " / " & dtVitalSign.Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lueDoctor_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueDoctor.Closed
        If CInt(lueDoctor.EditValue) > 0 Then
            txtPatientCode.ReadOnly = False
            txtPatientCode.Focus()
        Else
            txtPatientCode.ReadOnly = True
            gvPatientsWaiting.Focus()
        End If
    End Sub

    Private Sub txtPatientCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPatientCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            ClearAllContent()
            TempPatientCode = txtPatientCode.Text.Trim
            If String.IsNullOrEmpty(TempPatientCode) Then
                XtraMessageBox.Show("Please enter Patient Code before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPatientCode.Focus()
                Return
            End If
            txtPatientCode.Text = txtPatientCode.Text.Trim.ToUpper
            SelectPatientForTreatment(TempPatientCode)
        End If
    End Sub

    Private Sub SelectPatientForTreatment(_PatientCode As String)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientProfile", New SqlParameter("@PatientCode", _PatientCode))
            With dtData
                If .Rows.Count = 1 Then
                    txtPatientCode.ReadOnly = True
                    btnNew.Enabled = True
                    btnBMICalc.Enabled = True
                    btnChoose.Enabled = True
                    TempPatientCode = .Rows(0)("PatientCode").ToString
                    txtPatientCode.Text = .Rows(0)("PatientCode").ToString
                    txtPatient.Text = .Rows(0)("EnglishName").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                    txtAge.Text = .Rows(0)("Age").ToString
                    txtPatientType.Text = .Rows(0)("PatientType").ToString
                    PatientVitalSignHistory(_PatientCode)
                    GetScrollRecord(index)
                    CheckPatientReminder(_PatientCode, CInt(lueClinic.EditValue))
                    mePatientComplaint.Focus()
                Else
                    ClearAllContent()
                    XtraMessageBox.Show("Searching keyword: " + _PatientCode + " doesnot exist on the target system. " & vbLf & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetPatientDiagnosisList(_PatientCode As String, _VisitCode As Integer)
        Try
            lstPatientDiagnosis = GetPatientDiagnosisToList("SA_GetPatientDiagnosis", New SqlParameter("@PatientCode", _PatientCode), New SqlParameter("@VisitCode", _VisitCode))
            If lstPatientDiagnosis.Count > 0 Then
                lcgDiagnosis.Text = "Diagnosis Information [ " + lstPatientDiagnosis.Count.ToString + " ]"
                gcDiagnosis.DataSource = lstPatientDiagnosis
                gcDiagnosis.RefreshDataSource()
                With gvDiagnosis
                    .PopulateColumns()
                    .Columns("DxTimeStamp").DisplayFormat.FormatType = FormatType.DateTime
                    .Columns("DxTimeStamp").DisplayFormat.FormatString = "MMM dd, yyyy hh:mm:ss tt"
                    .Columns("ID").Visible = False
                    .Columns("DiagnosisCode").Visible = False
                    .Columns("DxGroupID").Visible = False
                    '.Columns("DxTimeStamp").Visible = False
                    .Columns("DxCode").Width = 40
                    '.Columns("ID").Width = 20
                    '.Columns("ID").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                    '.Columns("ID").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("DxCode").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("DxCode").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                    '.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    '.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    .BestFitColumns()
                End With
            Else
                gcDiagnosis.DataSource = Nothing
                gvDiagnosis.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CheckPatientReminder(Optional _PatientCode As String = "", Optional _ClinicID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_CheckPatientReminderAlert", New SqlParameter("@ClinicID", _ClinicID), New SqlParameter("@PatientCode", _PatientCode))
            With dtData
                If .Rows.Count = 1 Then
                    frmPatientReminderAlert._ReminderCode = CInt(.Rows(0)("ReminderCode"))
                    frmPatientReminderAlert.meReminder.Text = "Patient Reminder: " + .Rows(0)("PTReminder").ToString + vbNewLine + vbNewLine + "Reminder is created by " + .Rows(0)("UserCreate").ToString + " on " + .Rows(0)("DateCreate").ToString + "."
                    frmPatientReminderAlert.ShowDialog(Me)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDxCode_Validated(sender As Object, e As EventArgs) Handles txtDxCode.Validated
        'GetDiagnosisInfo()
    End Sub

    Private Sub GetDiagnosisInfo(_DxCode As String)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetDiagnosisByDxCode", New SqlParameter("@DxCode", _DxCode), New SqlParameter("@Flag", 1))
            With dt
                If .Rows.Count > 0 Then
                    lueDxGroup.EditValue = CInt(.Rows(0)("DxGroup"))
                    LoadDiagnosis(CInt(.Rows(0)("DxGroup")))
                    lueDiagnosis.EditValue = CInt(.Rows(0)("DiagnosisCode"))
                    txtNote.Focus()
                Else
                    lueDxGroup.EditValue = -1
                    lueDiagnosis.EditValue = -1
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDxCode_Leave(sender As Object, e As EventArgs) Handles txtDxCode.Leave
        txtDxCode.Text = txtDxCode.Text.Trim.ToUpper
    End Sub

    Private Sub txtDxCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDxCode.KeyDown
        If e.KeyCode = Keys.Enter Then GetDiagnosisInfo(txtDxCode.Text.Trim)
    End Sub

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        If String.IsNullOrEmpty(txtDxCode.Text.Trim) OrElse CInt(lueDxGroup.EditValue) < 0 OrElse CInt(lueDiagnosis.EditValue) < 0 Then
            XtraMessageBox.Show("Some fields are blank. Please check it.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDxCode.Select()
            Return
        End If

        Dim IsExistItem As Boolean = False

        If Not IsModify And TempDxID = 0 Then
            Dim obj As New PatientDiagnosis
            obj.ID = lstPatientDiagnosis.Count + 1
            obj.DiagnosisCode = CInt(lueDiagnosis.EditValue)
            obj.Diagnosis = lueDiagnosis.Text.Trim
            obj.DxCode = txtDxCode.Text.Trim
            obj.DxGroup = lueDxGroup.Text.Trim
            obj.DxNote = txtNote.Text.Trim
            obj.DxGroupID = CInt(lueDxGroup.EditValue)
            obj.DxTimeStamp = Convert.ToDateTime(Now)

            For Each a As PatientDiagnosis In lstPatientDiagnosis
                If a.DiagnosisCode = obj.DiagnosisCode Then IsExistItem = True
            Next
            If Not IsExistItem Then
                lstPatientDiagnosis.Add(obj)
            Else
                XtraMessageBox.Show("Diagnosis: " + obj.Diagnosis + " is already added to the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDxCode.Select()
            End If
        Else
            For Each t As PatientDiagnosis In lstPatientDiagnosis
                If t.DiagnosisCode = CInt(lueDiagnosis.EditValue) Then IsExistItem = True
            Next

            If Not IsExistItem Then
                For Each U As PatientDiagnosis In lstPatientDiagnosis
                    If U.ID = TempDxID Then
                        U.DiagnosisCode = CInt(lueDiagnosis.EditValue)
                        U.Diagnosis = lueDiagnosis.Text.Trim
                        U.DxCode = txtDxCode.Text.Trim
                        U.DxGroup = lueDxGroup.Text.Trim
                        U.DxNote = txtNote.Text.Trim
                        U.DxGroupID = CInt(lueDxGroup.EditValue)
                        U.DxTimeStamp = Convert.ToDateTime(Now)
                    End If
                Next
            Else
                XtraMessageBox.Show("Diagnosis: " + lueDiagnosis.Text.Trim + " is already added to the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDxCode.Select()
            End If
        End If

        lcgDiagnosis.Text = "Diagnosis Information [ " + lstPatientDiagnosis.Count.ToString + " ]"
        lstPatientDiagnosis = lstPatientDiagnosis.OrderBy(Function(p) p.DxGroupID).ThenBy(Function(p) p.DxCode).ToList
        gcDiagnosis.DataSource = lstPatientDiagnosis
        gcDiagnosis.RefreshDataSource()
        With gvDiagnosis
            .PopulateColumns()
            .Columns("DxTimeStamp").DisplayFormat.FormatType = FormatType.DateTime
            .Columns("DxTimeStamp").DisplayFormat.FormatString = "MMM dd, yyyy hh:mm:ss tt"
            .Columns("ID").Visible = False
            .Columns("DiagnosisCode").Visible = False
            .Columns("DxGroupID").Visible = False
            '.Columns("DxTimeStamp").Visible = False
            .Columns("DxCode").Width = 40
            '.Columns("ID").Width = 20
            '.Columns("ID").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            '.Columns("ID").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            .Columns("DxCode").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            .Columns("DxCode").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            '.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
            '.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
            .BestFitColumns()
        End With
        HighlightUpdate()
        ClearForNewDx()
    End Sub

    Private Sub bbiPAddNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAddNew.ItemClick
        ClearForNewDx()
        DefaultFormatUpdate()
    End Sub

    Private Sub ClearForNewDx()
        IsModify = False
        TempDxID = 0
        txtDxCode.Text = ""
        lueDxGroup.EditValue = -1
        lueDiagnosis.EditValue = -1
        txtNote.Text = ""
        txtDxCode.Focus()
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        With gvDiagnosis
            If .RowCount <= 0 Then
                XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Try
                Dim DxEn As String = .GetRowCellValue(.FocusedRowHandle, "Diagnosis").ToString
                detected = XtraMessageBox.Show("Do you want to remove diagnosis: " + DxEn + " from the list?", "Confirm Message?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return

                Dim SelectedIndex As Integer = CInt(.GetVisibleIndex(.FocusedRowHandle))
                lstPatientDiagnosis.RemoveAt(SelectedIndex)

                Dim Ind As Integer = 1
                For Each T As PatientDiagnosis In lstPatientDiagnosis
                    T.ID = Ind
                    Ind += 1
                Next

                gcDiagnosis.RefreshDataSource()
                ClearForNewDx()
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            Dim SelectedIndex As Integer = CInt(gvDiagnosis.GetVisibleIndex(gvDiagnosis.FocusedRowHandle))
            With lstPatientDiagnosis
                TempDxID = .Item(SelectedIndex).ID
                txtDxCode.Text = .Item(SelectedIndex).DxCode
                lueDxGroup.EditValue = .Item(SelectedIndex).DxGroupID
                LoadDiagnosis(.Item(SelectedIndex).DxGroupID)
                lueDiagnosis.EditValue = .Item(SelectedIndex).DiagnosisCode
                txtNote.Text = .Item(SelectedIndex).DxNote
                IsModify = True
            End With
            HighlightUpdate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gcDiagnosis_MouseClick(sender As Object, e As MouseEventArgs) Handles gcDiagnosis.MouseClick
        If e.Button = MouseButtons.Right Then ppDiagnosis.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub txtNote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNote.KeyDown
        If e.KeyCode = Keys.Enter Then btnChoose_Click(sender, e)
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If lstPatientDiagnosis.Count > 0 Then
                Await PatientDiagnosisExec.InsertDxDiagnosisAsync(lstPatientDiagnosis, TempPatientCode, VisitCode, CInt(lueClinic.EditValue), mePatientComplaint.Text.Trim, meProgressNote.Text.Trim)
                btnSave.Enabled = False
                btnRx.Enabled = True
                XtraMessageBox.Show("Doctor has diagnosed the patient " + TempPatientCode + ", check-in date: " + txtDateCheckIn.Text.Trim + ".", "Treatment", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnRx.Focus()
            Else
                btnSave.Enabled = True
                btnRx.Enabled = False
                XtraMessageBox.Show("Doctor does not diagnose the patient " + TempPatientCode + ", check-in date: " + txtDateCheckIn.Text.Trim + ".", "No Treatment", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDxCode.Focus()
            End If
        Catch ex As Exception
            btnSave.Enabled = True
            btnRx.Enabled = False
            XtraMessageBox.Show("Operation failed: " + ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub HighlightUpdate()
        Dim cn As StyleFormatCondition

        cn = New StyleFormatCondition(FormatConditionEnum.Equal, gvDiagnosis.Columns("ID"), Nothing, TempDxID)
        cn.Appearance.BackColor = Color.LightSkyBlue
        cn.Appearance.ForeColor = Color.Black
        cn.ApplyToRow = True
        gvDiagnosis.FormatConditions.Add(cn)

        cn = New StyleFormatCondition(FormatConditionEnum.NotEqual, gvDiagnosis.Columns("ID"), Nothing, TempDxID)
        cn.Appearance.BackColor = Color.White
        cn.Appearance.ForeColor = Color.Black
        cn.ApplyToRow = True
        gvDiagnosis.FormatConditions.Add(cn)
    End Sub

    Private Sub DefaultFormatUpdate()
        Dim cn As StyleFormatCondition
        cn = New StyleFormatCondition(FormatConditionEnum.NotEqual, gvDiagnosis.Columns("ID"), Nothing, Nothing)
        cn.Appearance.BackColor = Color.White
        cn.Appearance.ForeColor = Color.Black
        cn.ApplyToRow = True
        gvDiagnosis.FormatConditions.Add(cn)
    End Sub
End Class