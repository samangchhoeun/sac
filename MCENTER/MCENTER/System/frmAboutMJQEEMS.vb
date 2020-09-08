Public Class frmAboutMJQEEMS
    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub frmAboutMJQEEMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblApplication.Text = Application.ProductName
        lblVersion.Text = systemVersion
        lblCopyRight.Text = "© " + Application.ProductName + " " + Now.Year.ToString + ". All rights reserved"
    End Sub

    Private Sub btnClose_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then Dispose()
    End Sub

    Private Sub frmAboutMJQEEMS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class