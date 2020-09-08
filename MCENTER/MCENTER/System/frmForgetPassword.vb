Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmForgetPassword

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrEmpty(txtStaffID.Text.Trim) OrElse String.IsNullOrEmpty(txtFullName.Text.Trim) OrElse String.IsNullOrEmpty(txtPhone.Text.Trim) OrElse String.IsNullOrEmpty(txtEmail.Text.Trim) Then
            XtraMessageBox.Show("Some fields are blank. Please check it.", "Confirm Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtStaffID.Focus()
            Return
        End If

        Try
            btnLogin.Enabled = True

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_ForgotAccount", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@CardID", txtStaffID.Text.Trim.ToUpper)
                .AddWithValue("@Name", ToTitleCase(txtFullName.Text.Trim))
                .AddWithValue("@Phone", txtPhone.Text.Trim)
                .AddWithValue("@Email", txtEmail.Text.Trim.ToLower)
                .AddWithValue("@UserID", txtUserID.Text.Trim.ToLower)
                .Add("@isAdd", SqlDbType.Int)
                cmd.Parameters("@isAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            Dim mms As MessageBoxIcon
            If Convert.ToInt16(cmd.Parameters("@isAdd").Value) <> 0 Then
                mms = MessageBoxIcon.Information
                btnLogin.Enabled = False
            Else
                txtStaffID.Focus()
                mms = MessageBoxIcon.Error
            End If

            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Forgot Account?", MessageBoxButtons.OK, mms)
            txtStaffID.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmForgetPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDBConnection()
    End Sub

    Private Sub frmForgetPassword_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Hide()
    End Sub
End Class