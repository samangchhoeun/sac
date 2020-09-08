Public Class frmNewSoftwareUpdate
    Dim tCount As Integer = 0

    Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub frmNewSoftwareUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVersion.Text = "Software update " + latestAppVersion + "."
        lblAppName.Text = "A new verion of " + Application.ProductName + " is available."
        lblMessage.Text = "Your software is updating now..."
    End Sub

    Private Sub timLoading_Tick(sender As Object, e As EventArgs) Handles timLoading.Tick
        tCount += 1
        If tCount = 5 Then
            timLoading.Enabled = False
            tCount = 0

            Threading.Thread.Sleep(5000)
            Dispose()
        End If
    End Sub
End Class