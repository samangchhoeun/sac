Imports DevExpress.XtraEditors

Public Class frmAuthAccess

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dispose()
    End Sub

    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Action()
        End If
    End Sub

    Private Sub Action()
        Dim CurPass As String = GenEncryptPassword(txtPass.Text.Trim)
        'MessageBox.Show(Pass)
        If String.IsNullOrEmpty(txtPass.Text.Trim) Then
            XtraMessageBox.Show("Please enter your password.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Text = ""
            txtPass.Focus()
            Return
        ElseIf (String.CompareOrdinal(CurPass, LogPass) <> 0) Then
            XtraMessageBox.Show("Invalid confirm password.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Text = ""
            txtPass.Focus()
            Return
        End If

        Dispose()
        isAuthForm = 1
        isAuthorized = 1
    End Sub

    Private Sub txtPass_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles txtPass.ButtonClick
        Action()
    End Sub
End Class