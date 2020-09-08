Imports System.IO
Imports DevExpress.XtraEditors

Public Class frmSetActivateTime
    Dim _IsRefresh As Boolean = False

    Public ReadOnly SchedulefilePath As String = "BlockSchedule.dll"

    Private Sub frmSetActivateTime_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'If _IsRefresh = False Then
        'frmMainProject.timLoading.Stop()
        'frmMainProject.timLoading.Enabled = False
        '    _DefaultDateTime = ConfigurationPath.ReadConfig(SchedulefilePath)
        '    ConfigurationPath.SaveConfig(SchedulefilePath, _DefaultDateTime)
        'frmMainProject.timLoading.Enabled = True
        'frmMainProject.timLoading.Start()
        'End If
        Dispose()
    End Sub

    Private Sub btnSchedule_Click(sender As Object, e As EventArgs) Handles btnSchedule.Click
        'defaultDateTime = TimeIO.ActivateDate(deDate.Text.Trim) + " " + TimeIO.ActivateTime(teSetTime.Text.Trim)

        'If TimeIO.GetScheduleDateTime(defaultDateTime) <= TimeIO.GetSystemCompareDateTime() Then
        '    XtraMessageBox.Show("The selected time: " + defaultDateTime + " is older than current time: " + TimeIO.GetSystemCompareDateTime() + ".", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return
        'End If

        'Try
        '    '_IsRefresh = True
        '    frmMainProject.timLoading.Stop()
        '    frmMainProject.timLoading.Enabled = False
        '    ConfigurationPath.SaveConfig(SchedulefilePath, defaultDateTime)
        '    XtraMessageBox.Show(defaultDateTime + " is scheduled.", "Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    defaultDateTime = ConfigurationPath.ReadConfig(SchedulefilePath)
        '    TimeIO.LoadDefaultDateTime(defaultDateTime)
        '    deDate.EditValue = defaultDate
        '    teSetTime.EditValue = defaultTime
        '    teSetTime.Focus()
        '    frmMainProject.timLoading.Enabled = True
        '    frmMainProject.timLoading.Start()
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub frmSetActivateTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        '    defaultDateTime = ConfigurationPath.ReadConfig(SchedulefilePath)
        '    TimeIO.LoadDefaultDateTime(defaultDateTime)
        '    deDate.EditValue = defaultDate
        '    teSetTime.EditValue = defaultTime
        'Catch ex As Exception
        '    deDate.EditValue = Now.Date
        '    teSetTime.EditValue = Now.Date.ToLongTimeString
        'End Try
    End Sub

    Private Sub chkGetCurDateTime_CheckStateChanged(sender As Object, e As EventArgs) Handles chkGetCurDateTime.CheckStateChanged
        'If CBool(chkGetCurDateTime.Checked) Then
        '    deDate.EditValue = CDate(TimeIO.GetSystemCompareDateTime()).Date
        '    teSetTime.EditValue = CDate(TimeIO.GetSystemCompareDateTime()).ToLongTimeString
        '    teSetTime.Focus()
        'Else
        '    defaultDateTime = ConfigurationPath.ReadConfig(SchedulefilePath)
        '    TimeIO.LoadDefaultDateTime(defaultDateTime)
        '    deDate.EditValue = defaultDate
        '    teSetTime.EditValue = defaultTime
        '    deDate.Focus()
        'End If
    End Sub
End Class