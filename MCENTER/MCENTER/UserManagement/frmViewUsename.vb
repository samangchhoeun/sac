Public Class frmViewUsename

    Private Sub frmViewUsename_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _TempUser = ""
        Dispose()
    End Sub

    Private Sub frmViewUsename_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = _TempUser
    End Sub
End Class