Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmViewPatient
    Dim ID As Integer = 0
    Dim index As Integer = 0
    Dim TempPatientCode As String = ""
    Dim dtData As New DataTable
    Dim lstPatientDiagnosis As New List(Of PatientDiagnosis)
    Dim dtVisitList As New DataTable
    Dim VisitCode As Integer = 0

    Private Sub frmViewPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoCompleteID(txtSID, "SA_GetPatientCodeList")
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

    Private Sub ClearAllContent()
        ID = 0
        VisitCode = 0
        index = 0
        TempPatientCode = ""
        txtPatient.Text = ""
        txtCity.Text = ""
        txtCellPhone.Text = ""
        txtGender.Text = ""
        txtAge.Text = ""
        meNote.Text = ""
        txtDOB.Text = ""
        txtPatientType.Text = ""
        picPhoto.Image = Nothing
        lblRec.Text = "0 / 0"
        btnNext.Enabled = False
        btnPrev.Enabled = False
        picPhoto.BackgroundImage = My.Resources.MJQE_Photo
        lcgFollowUp.Text = "Follow Up Schedule"
        lcgDiagnosis.Text = "Diagnosis Information"
        lcgVisit.Text = "Patient Visit"
        lcgVitalSignHistory.Text = "Vital Sign History"
        gcVisit.DataSource = Nothing
        gvVisit.Columns.Clear()
        gcFollowUp.DataSource = Nothing
        gvFollowUp.Columns.Clear()
        gcDiagnosis.DataSource = Nothing
        gvDiagnosis.Columns.Clear()
        gcVitalSign.DataSource = Nothing
        gvVitalSign.Columns.Clear()
    End Sub

    Private Sub GetScrollRecord(ind As Integer)
        Try
            dtVisitList.Clear()
            dtVisitList = GetDataFromDBToTable("SA_GetPatientVisitList", New SqlParameter("@PatientCode", TempPatientCode))
            If dtVisitList.Rows.Count = 0 Then
                btnNext.Enabled = False
                btnPrev.Enabled = False
                lblRec.Text = "0 / 0"
                Exit Sub
            ElseIf ind = 0 Then
                btnNext.Enabled = True
                btnPrev.Enabled = False
            ElseIf ind = dtVisitList.Rows.Count - 1 Then
                btnNext.Enabled = False
                btnPrev.Enabled = True
            Else
                btnNext.Enabled = True
                btnPrev.Enabled = True
            End If

            Dim Drow As DataRow = dtVisitList.Rows(ind)
            VisitCode = CInt(Drow("VisitCode"))
            PatientVitalSignHistory(TempPatientCode, VisitCode)
            GetPatientDiagnosisList(TempPatientCode, VisitCode)
            dtVisitList.Dispose()
            SetColorFormatting()
            lblRec.Text = ind + 1 & " / " & dtVisitList.Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetColorFormatting()
        Dim cn As StyleFormatCondition
        cn = New StyleFormatCondition(FormatConditionEnum.Equal, gvVisit.Columns("VisitCode"), Nothing, VisitCode)
        cn.Appearance.BackColor = Color.Pink
        cn.Appearance.ForeColor = Color.Black
        cn.ApplyToRow = True
        gvVisit.FormatConditions.Add(cn)

        cn = New StyleFormatCondition(FormatConditionEnum.NotEqual, gvVisit.Columns("VisitCode"), Nothing, VisitCode)
        cn.Appearance.BackColor = Color.White
        cn.Appearance.ForeColor = Color.Black
        cn.ApplyToRow = True
        gvVisit.FormatConditions.Add(cn)
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
                lcgDiagnosis.Text = "Diagnosis Information"
                gcDiagnosis.DataSource = Nothing
                gvDiagnosis.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub SelectPatientVisit(_PatientCode As String)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientProfile", New SqlParameter("@PatientCode", _PatientCode))
            With dtData
                If .Rows.Count = 1 Then
                    btnNew.Enabled = True
                    TempPatientCode = .Rows(0)("PatientCode").ToString
                    'txtSID.Text = GetPatientCode(.Rows(0)("PatientCode").ToString)
                    txtPatient.Text = .Rows(0)("EnglishName").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                    txtAge.Text = .Rows(0)("Age").ToString
                    txtCellPhone.Text = .Rows(0)("CellPhone").ToString
                    txtCity.Text = .Rows(0)("City").ToString
                    txtPatientType.Text = .Rows(0)("PatientType").ToString
                    meNote.Text = .Rows(0)("Remark").ToString
                    LoadProfilePhoto(.Rows(0)("Photo"), picPhoto)
                    LoadPatientVisit(_PatientCode)
                    GetScrollRecord(index)
                    LoadFollowUpSchedule(Now.Date, _PatientCode)
                    txtSID.Focus()
                Else
                    ClearAllContent()
                    XtraMessageBox.Show("Searching keyword: " + _PatientCode + " doesnot exist on the target system. " & vbLf & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LoadFollowUpSchedule(SelDate As DateTime, _PatientCode As String, Optional _Doctor As Integer = 0, Optional _ID As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_CheckPatientFollowup", New SqlParameter("@ID", _ID), New SqlParameter("@DoctorID", _Doctor), New SqlParameter("@SelDate", SelDate), New SqlParameter("@PatientCode", _PatientCode), New SqlParameter("@NoDate", 1))
            If dtData.Rows.Count > 0 Then
                lcgFollowUp.Text = "Follow Up Schedule [ " + dtData.Rows.Count.ToString + " ]"
                gcFollowUp.DataSource = dtData
                With gvFollowUp
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
                    .Columns("Inactive").Visible = False

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
                lcgFollowUp.Text = "Follow Up Schedule"
                gcFollowUp.DataSource = Nothing
                gvFollowUp.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub PatientVitalSignHistory(Optional _PatientCode As String = "", Optional _VisitCode As Integer = 0, Optional _VitalCode As Integer = 0)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetPatientVitalSignForView", New SqlParameter("@VitalCode", _VitalCode), New SqlParameter("@VisitCode", _VisitCode), New SqlParameter("@PatientCode", _PatientCode))
            If dt.Rows.Count > 0 Then
                lcgVitalSignHistory.Text = "Vital Sign History [ " + dt.Rows.Count.ToString + " ]"
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
                lcgVitalSignHistory.Text = "Vital Sign History"
                gcVitalSign.DataSource = Nothing
                gvVitalSign.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadPatientVisit(Optional _PatientCode As String = "")
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetPatientVisitList", New SqlParameter("@PatientCode", _PatientCode))
            If dt.Rows.Count > 0 Then
                lcgVisit.Text = "Patient Visit [ " + dt.Rows.Count.ToString + " ]"

                gcVisit.DataSource = dt
                With gvVisit
                    .PopulateColumns()
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Columns("VisitCode").Visible = False
                    .Columns("PatientCode").Visible = False
                    .Columns("PatientName").Visible = False
                    .Columns("Gender").Visible = False
                    .Columns("Age").Visible = False
                    .Columns("DOB").Visible = False

                    .Columns("MembershipType").Visible = False
                    .Columns("PTDiagnosis").Visible = False
                    .Columns("VisitedDoctor").Visible = False
                    .Columns("VisitStatus").Visible = False
                    .Columns("TreatmentBy").Visible = False
                    .Columns("TreatmentDate").Visible = False
                    .Columns("CheckInToDoctor").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("NumIn").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("DateIn").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("DateOut").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("ClinicEn").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("TreatmentDate").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    '.Columns("DateCheckIn").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    '.Columns("DateCheckIn").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    '.Columns("DateCheckIn").SummaryItem.DisplayFormat = "Total: {0} Records"
                    '.BestFitColumns()
                End With
            Else
                lcgVisit.Text = "Patient Visit"
                gcVisit.DataSource = Nothing
                gvVisit.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmViewPatient_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        txtSID.Text = ""
        txtSID.Focus()
    End Sub

    Private Sub gvFollowUp_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gvFollowUp.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As DateTime = Convert.ToDateTime(.GetRowCellValue(e.RowHandle, "DateTimeFU"))
            If DateDiff(DateInterval.Minute, tempVal, Convert.ToDateTime(Now)) >= 0 Then e.Appearance.ForeColor = Color.Gray

            'If DateDiff(DateInterval.Minute, tempVal, Convert.ToDateTime(Now)) > 0 Then
            '    e.Appearance.ForeColor = Color.Crimson
            '    'currentView.Columns(0).AppearanceCell.BackColor = Color.LightSlateGray
            '    'Else
            '    '    If e.Column.FieldName = "Time" Then e.Appearance.BackColor = Color.FromArgb(&HCC, &HFF, &HFF)
            'End If

            ''If e.Column.FieldName <> "Time" Then If .GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString <> "" Then e.Appearance.BackColor = Color.Khaki
        End With
    End Sub

    Private Sub gvVisit_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles gvVisit.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As DateTime = CDate(.GetRowCellValue(e.RowHandle, "DateIn"))
            If DateDiff(DateInterval.Minute, tempVal, Now.Date) >= 0 Then e.Appearance.ForeColor = Color.Gray
        End With
    End Sub

    Private Sub gvVitalSign_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles gvVitalSign.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As DateTime = CDate(.GetRowCellValue(e.RowHandle, "DateVitalSign"))
            If DateDiff(DateInterval.Minute, tempVal, Now.Date) >= 0 Then e.Appearance.ForeColor = Color.Gray
        End With
    End Sub

    Private Sub LoadProfilePhoto(Src As Object, ProfilePicture As PictureBox)
        Try
            Dim img As Byte() = TryCast(Src, Byte())
            'If img.Length > 4 Then
            '    _ChangePhoto = "Remove"
            '    btnBrowse.Text = "Remove"
            'End If

            ProfilePicture.Image = byteArrayToImage(img)
            ProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage
            ProfilePicture.Refresh()
        Catch ex As Exception
            ProfilePicture.Image = Nothing
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            If (index < dtVisitList.Rows.Count - 1) Then
                index += 1
                GetScrollRecord(index)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("There is no record found.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Try
            If (Index > 0) Then
                Index -= 1
                GetScrollRecord(Index)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("There is no record found.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub gvVisit_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles gvVisit.RowCellClick

    End Sub
End Class