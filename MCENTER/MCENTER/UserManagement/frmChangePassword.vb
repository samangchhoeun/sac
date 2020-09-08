Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmChangePassword

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveChangePassword()
    End Sub

    Private Sub SaveChangePassword()
        Dim Password As String = ""
        If String.IsNullOrEmpty(txtPass.Text.Trim) OrElse String.IsNullOrEmpty(txtConfirmPass.Text.Trim) Then
            XtraMessageBox.Show("Please enter your password.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Focus()
            Return
        ElseIf (txtPass.Text.Trim().Length < 6) Then
            XtraMessageBox.Show("Password must be at least 6 characters long.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Focus()
            Return
        ElseIf (String.CompareOrdinal(txtPass.Text.Trim(), txtConfirmPass.Text.Trim()) <> 0) Then
            XtraMessageBox.Show("Confirm Password mismatch. Please try again.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Focus()
            Return
        End If

        Try
            Password = GenEncryptPassword(txtPass.Text.Trim)
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_UpdateUserLogPass", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@UserNo", LogUserNo)
                .AddWithValue("@UserID", Encrypt(LogUserID))
                .AddWithValue("@Pass", Password)
                .AddWithValue("@UserUpdate", AccountName)
                .Add("@IsChange", SqlDbType.Int)
                cmd.Parameters("@IsChange").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            Dim IsChanged As Integer = Convert.ToInt16(cmd.Parameters("@IsChange").Value)
            Dim MMS As MessageBoxIcon
            If IsChanged <> 0 Then
                MMS = MessageBoxIcon.Information
            Else
                txtPass.Focus()
                MMS = MessageBoxIcon.Error
            End If
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString(), "Change Password", MessageBoxButtons.OK, MMS)

            If IsChanged <> 0 Then
                Hide()
                Threading.Thread.Sleep(500)
                frmLoginWindows.Show()
                frmLoginWindows.txtUserID.Focus()
                'Hide()
                'frmMainProject.Show()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        CloseCon(Con)
    End Sub

    Private Sub frmChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDBConnection()
    End Sub

    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(txtPass.Text.Trim) Then
                txtConfirmPass.Select()
            End If
        End If
    End Sub

    Private Sub txtConfirmPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConfirmPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(txtPass.Text.Trim) And Not String.IsNullOrEmpty(txtConfirmPass.Text.Trim) Then
                SaveChangePassword()
            End If
        End If
    End Sub
End Class