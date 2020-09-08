Public Class frmUpdateProgress
    Dim MyAutoUpdate As New AutoUpdate
    Private Sub frmUpdateProgress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        System.Threading.Thread.Sleep(3000)

        If Not MyAutoUpdate.ProcessUpdate(CommandLine, RemotePath) Then
            ' Ignore the update request 
            ' when the update server is not presented,
            Me.Cursor = Cursors.Default
            Dispose()
            'LoadDialogForm(frmLoginWindows)
        Else
            Me.Cursor = Cursors.Default
            Dispose()
            Application.Exit()
        End If
    End Sub
End Class