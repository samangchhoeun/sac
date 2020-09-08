Imports System.Data.SqlClient
Imports DevExpress.Utils

Public Class frmPatientWaitingForVitalSign
    Private Sub frmPatientWaitingForVitalSign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PatientWaitingVitalSign(Now())
    End Sub

    Private Sub frmPatientWaitingForVitalSign_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub PatientWaitingVitalSign(SelDate As DateTime, Optional _VisitCode As Integer = 0, Optional _IsNoDate As Integer = 1)
        Try
            Dim ClinicID As Integer = 0
            If Not isLoggedInOwner Then ClinicID = ConfigClinic.ClinicID

            Dim dt As DataTable = GetDataFromDBToTable("SA_GetPatientWaitingForVitalSign", New SqlParameter("@VisitCode", _VisitCode), New SqlParameter("@ClinicID", ClinicID), New SqlParameter("@SelDate", SelDate), New SqlParameter("@IsNoDate", _IsNoDate))
            If dt.Rows.Count > 0 Then
                gcWaiting.DataSource = dt
                With gvWaiting
                    .PopulateColumns()
                    .Columns("DateCheckIn").DisplayFormat.FormatType = FormatType.DateTime
                    .Columns("DateCheckIn").DisplayFormat.FormatString = "MMM dd, yyyy hh:mm tt"
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
                    .Columns("DateCheckIn").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            Else
                gcWaiting.DataSource = Nothing
                gvWaiting.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gcWaiting_DoubleClick(sender As Object, e As EventArgs) Handles gcWaiting.DoubleClick
        Try
            With gvWaiting
                Dim VisitCode As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "VisitCode").ToString)
                frmPatientVitalSign.SelectPatientVisit(Now(), VisitCode)
                Dim PatientCode As String = .GetRowCellValue(.FocusedRowHandle, "PatientCode").ToString.Replace("-", "")
                frmPatientVitalSign.PatientVitalSignHistory(PatientCode)
                frmPatientVitalSign.timPatientWaitingForVitalSign.Enabled = True
                Dispose()
            End With
        Catch ex As Exception
            frmPatientVitalSign.timPatientWaitingForVitalSign.Enabled = True
        End Try
    End Sub
End Class