Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.XtraEditors

Public Class frmDatabase

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If IsSaveCon Then GetDBSettings()
        If _IsActive Then
            If IsConnectedDB Then
                'Con.Close() 'just add on August 25, 2018
                XtraMessageBox.Show("You are required to re-login to update configuration!", "Microsoft Data Link", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmMainProject.Dispose()
                frmLoginWindows.Show()
                frmLoginWindows.txtUserID.Select()
            Else
                XtraMessageBox.Show("Error Establishing a Database Connection. The program will be terminated then.", "Unable to connect", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Environment.Exit(0)
                Application.Exit()
            End If
        End If

        Dispose()

        'Close()
        ''frmMainProject.frmMainProject_Load(Nothing, Nothing)
        'If IsSaveCon Then
        '    XtraMessageBox.Show("You are required to re-login to update configuration!", "Microsoft Data Link", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    frmMainProject.Hide()
        '    frmMainProject.Dispose()
        '    frmLoginWindows.Show()
        '    frmLoginWindows.txtUserID.Select()
        'End If
    End Sub

    Private Sub btnConTest_Click(sender As Object, e As EventArgs) Handles btnConTest.Click
        If String.IsNullOrEmpty(txtConServer.Text) OrElse String.IsNullOrEmpty(txtConDB.Text) OrElse String.IsNullOrEmpty(txtConUser.Text) OrElse String.IsNullOrEmpty(txtConPass.Text) Then
            XtraMessageBox.Show("Some fields are empty!", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtConServer.Focus()
            Return
        End If
        TestConnection(txtConServer.Text, txtConDB.Text, txtConUser.Text, txtConPass.Text)
    End Sub

    Private Sub btnUDLTest_Click(sender As Object, e As EventArgs) Handles btnUDLTest.Click
        If String.IsNullOrEmpty(txtUDLServer.Text) OrElse String.IsNullOrEmpty(txtUDLDB.Text) OrElse String.IsNullOrEmpty(txtUDLUser.Text) OrElse String.IsNullOrEmpty(txtUDLPass.Text) Then
            XtraMessageBox.Show("Some fields are empty!", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUDLServer.Focus()
            Return
        End If
        TestConnection(txtUDLServer.Text, txtUDLDB.Text, txtUDLUser.Text, txtUDLPass.Text)
    End Sub

    Private Sub btnBrowseUDL_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles btnBrowseUDL.ButtonClick
        With OpenFileDialog1
            .FileName = ""
            .Filter = "Universal Data Link File|*.udl|All Files|*.*"
            .Title = "Browse For Universal Data Link File"
            If .ShowDialog() = DialogResult.OK Then
                btnBrowseUDL.Text = .FileName

                Dim connParts = ReadUdl(btnBrowseUDL.Text)
                txtUDLPass.Text = connParts.Password
                txtUDLUser.Text = connParts.UserID
                txtUDLDB.Text = connParts.InitialCatalog
                txtUDLServer.Text = connParts.DataSource
            End If
        End With
    End Sub

    Private Sub btnConSave_Click(sender As Object, e As EventArgs) Handles btnConSave.Click
        If Not String.IsNullOrEmpty(txtConPass.Text) Or Not String.IsNullOrEmpty(txtConUser.Text) Or Not String.IsNullOrEmpty(txtConDB.Text) Or Not String.IsNullOrEmpty(txtConServer.Text) Then
            SaveDBConfiguration(txtConPass.Text, txtConUser.Text, txtConDB.Text, txtConServer.Text)
        Else
            XtraMessageBox.Show("Some fields are empty!", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub chkUDLShowPass_CheckStateChanged(sender As Object, e As EventArgs) Handles chkUDLShowPass.CheckStateChanged
        If chkUDLShowPass.Checked Then
            txtUDLPass.Properties.UseSystemPasswordChar = False
        Else
            txtUDLPass.Properties.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub chkConShowPass_CheckStateChanged(sender As Object, e As EventArgs) Handles chkConShowPass.CheckStateChanged
        If chkConShowPass.Checked Then
            txtConPass.Properties.UseSystemPasswordChar = False
        Else
            txtConPass.Properties.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btnUDLSave_Click(sender As Object, e As EventArgs) Handles btnUDLSave.Click
        If Not String.IsNullOrEmpty(txtUDLPass.Text) Or Not String.IsNullOrEmpty(txtUDLUser.Text) Or Not String.IsNullOrEmpty(txtUDLDB.Text) Or Not String.IsNullOrEmpty(txtUDLServer.Text) Then
            SaveDBConfiguration(txtUDLPass.Text, txtUDLUser.Text, txtUDLDB.Text, txtUDLServer.Text)
        Else
            XtraMessageBox.Show("Some fields are empty!", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub frmDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadDBConnection()
    End Sub

    Private Sub ReloadDBConnection()
        IsSaveCon = False

        Dim connParts = New SqlConnectionStringBuilder With {.ConnectionString = ReadConnection()}
        If Not String.IsNullOrEmpty(connParts.ConnectionString) Then
            txtConPass.Text = connParts.Password
            txtConUser.Text = connParts.UserID
            txtConDB.Text = connParts.InitialCatalog
            txtConServer.Text = connParts.DataSource
            Con = New SqlConnection(connParts.ConnectionString) ''just added August 15, 2018
        End If
    End Sub

    Public Sub SaveDBConfiguration(ByVal Pass As String, ByVal User As String, ByVal DB As String, ByVal Server As String)
        Try
            Dim Str As String = ConnectionStrBuilder(Pass, User, DB, Server)
            SaveConnection(Str)
            IsSaveCon = True
            _IsActive = True
            XtraMessageBox.Show("Save database configuration succeeded!", "Microsoft Data Link", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'ReloadDBConnection()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Microsoft Data Link Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class