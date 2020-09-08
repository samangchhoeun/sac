Imports DevExpress.XtraEditors

Public Class frmCheckForUpdates
    Dim Second As Integer = 0
    Dim IsUpToDate As Boolean = False
    Dim MyAutoUpdate As New AutoUpdate
    Dim Msg As String

    Private Sub frmCheckForUpdates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadDBConnection()
        RemotePath = ConfigurationPath.ReadConfig(frmAddRemotePath.ConfigFilePath)

        If String.IsNullOrEmpty(RemotePath) Then LoadFormDialog(frmAddRemotePath)

        If MyAutoUpdate.IsRequiredUpdate Then
            Msg = "<size=12><B>" + Application.ProductName + " " + latestAppVersion + "</B><size><br/><br/>"
            Msg += "A new and improved version of " + Application.ProductName + " " + latestAppVersion + " is available. Get the new version free of charge."
            btnUpdate.Enabled = True
        Else
            Msg = "<size=12><B>" + Application.ProductName + " " + systemVersion + "</B><size><br/><br/>"
            Msg += "Software is up to date. <br/><br/>"
            Msg += Application.ProductName + " " + latestAppVersion + " was developed by: Mr. Sam Ang Chhoeun, Master of Engineering."
            btnUpdate.Enabled = False
        End If

        tecAppUpdate.Appearance.Text.Font = New Font("Tahoma", 9, FontStyle.Regular)
        tecAppUpdate.HtmlText = Msg
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MyAutoUpdate.IsRequiredUpdate Then
            XtraMessageBox.Show(IIf(String.IsNullOrEmpty(latestAppVersion), "", "Sotware Update " + latestAppVersion + vbNewLine + vbNewLine).ToString + "A new verion of " + Application.ProductName + " is available. Your software will be updated now...", "New Software Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Application.DoEvents()
            frmUpdateProgress.ShowDialog()
        End If
    End Sub
End Class