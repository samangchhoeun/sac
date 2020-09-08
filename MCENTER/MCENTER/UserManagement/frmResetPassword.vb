Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmResetPassword
    Dim Second As Integer = 0

    Private Sub SetAccountLabel(Msg As String)
        lblAccName.ForeColor = Color.Red
        lblAccName.Text = Msg
        timReset.Enabled = True
        timReset.Start()
    End Sub

    Private Sub ClearNewPasswordBox()
        txtNewPass.Text = ""
        txtConfirmPass.Text = ""
        txtNewPass.Focus()
    End Sub

    Private Sub ClearContent()
        txtOldPass.Text = ""
        txtNewPass.Text = ""
        txtConfirmPass.Text = ""
        txtOldPass.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveResetLoginPassword()
    End Sub

    Private Sub SaveResetLoginPassword()
        Dim Msg As String = ""
        Dim CurPass As String = txtOldPass.Text.Trim
        Dim NewPass As String = txtNewPass.Text.Trim

        If String.IsNullOrEmpty(CurPass) Then
            Msg = "Please fill out the current password."
            SetAccountLabel(Msg)
            txtOldPass.Focus()
        ElseIf String.IsNullOrEmpty(CurPass) Or String.IsNullOrEmpty(txtConfirmPass.Text.Trim) Then
            Msg = "Some mandatory fields are blank. Please check it."
            SetAccountLabel(Msg)
            txtNewPass.Focus()
        ElseIf NewPass.Length < 6 Then
            Msg = "Password must be at least 6 characters long."
            SetAccountLabel(Msg)
            txtNewPass.Focus()
        ElseIf (String.CompareOrdinal(NewPass, txtConfirmPass.Text.Trim) <> 0) Then
            Msg = "Confirm Password mismatch. Please try again."
            SetAccountLabel(Msg)
            ClearNewPasswordBox()
        Else
            Try
                CurPass = GenEncryptPassword(CurPass)
                NewPass = GenEncryptPassword(NewPass)
                OpenCon(Con)
                Dim cmd As New SqlCommand("SA_ResetUserLogPass", Con)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@UserNo", LogUserNo)
                    .AddWithValue("@UserID", Encrypt(LogUserID))
                    .AddWithValue("@CurPass", CurPass)
                    .AddWithValue("@NewPass", NewPass)
                    .AddWithValue("@UserUpdate", AccountName)
                    .Add("@IsChange", SqlDbType.Int)
                    cmd.Parameters("@IsChange").Direction = ParameterDirection.Output
                    .Add("@msg", SqlDbType.NVarChar, 200)
                    cmd.Parameters("@msg").Direction = ParameterDirection.Output
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                CloseCon(Con)

                Dim IsChanged As Integer = Convert.ToInt16(cmd.Parameters("@IsChange").Value)
                If IsChanged <> 0 Then
                    lblAccName.ForeColor = Color.White
                    lblAccName.Text = cmd.Parameters("@msg").Value.ToString
                    isResetPass = 1
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ClearContent()
        End If
    End Sub

    Private Sub timReset_Tick(sender As Object, e As EventArgs) Handles timReset.Tick
        Second += 1

        If Second >= 5 Then
            timReset.Stop() 'Timer stops functioning
            Second = 0
            lblAccName.ForeColor = Color.Yellow
            lblAccName.Text = "Please fill out information to change password."
        End If
    End Sub

    Private Sub frmResetPassword_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class