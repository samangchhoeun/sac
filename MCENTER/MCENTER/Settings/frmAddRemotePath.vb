Imports System.IO
Imports DevExpress.XtraEditors

Public Class frmAddRemotePath
    Public ReadOnly ConfigFilePath As String = "RemoteDbPath.dll"

    Private Sub frmAddRemotePath_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Config As String = ConfigurationPath.ReadConfig(ConfigFilePath)
        If Not String.IsNullOrEmpty(Config) Then
            txtConServer.ReadOnly = True
            btnConSave.Enabled = False
        End If

        txtConServer.Text = Config
    End Sub

    Private Sub btnConSave_Click(sender As Object, e As EventArgs) Handles btnConSave.Click
        If String.IsNullOrEmpty(txtConServer.Text.Trim) Then
            XtraMessageBox.Show("Remote path is blank!", "Remote Path", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtConServer.Focus()
            Return
        End If

        Try
            ConfigurationPath.SaveConfig(ConfigFilePath, txtConServer.Text)
            XtraMessageBox.Show("Save success!" + vbNewLine + "The application will close.", "Change Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Application.Exit()
            'Dispose()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Change Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtConServer_DoubleClick(sender As Object, e As EventArgs) Handles txtConServer.DoubleClick
        txtConServer.ReadOnly = False
        btnConSave.Enabled = True
    End Sub

    Private Sub frmAddRemotePath_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class