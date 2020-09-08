Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmPatientReminderAlert
    Public _ReminderCode As Integer = 0

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _ReminderCode > 0 Then
            detected = XtraMessageBox.Show("Are you sure to delete this patient reminder?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledItems(_ReminderCode.ToString, 1)
        End If
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
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Patient Reminder", MessageBoxButtons.OK, MMS)
            If IsAdd <> 0 Then
                _ReminderCode = 0
                meReminder.Text = ""
                Dispose()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmPatientReminderAlert_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class