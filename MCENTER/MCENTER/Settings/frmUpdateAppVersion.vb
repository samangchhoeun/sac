Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmUpdateAppVersion
    Dim Second As Integer = 0
    Dim IsUpToDate As Boolean = False
    Dim _UpCount As Integer = 0
    Dim _Count As Integer = 0
    Dim _ftpClient As New FTPClient

    Private Sub frmUpdateAppVersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadDBConnection()
        RemotePath = ConfigurationPath.ReadConfig(frmAddRemotePath.ConfigFilePath)

        If String.IsNullOrEmpty(RemotePath) Then LoadFormDialog(frmAddRemotePath)
        Dim MyAutoUpdate As New AutoUpdate

        If MyAutoUpdate.RequiredUpdateAppVer Then
            timReset.Enabled = True
            timReset.Start()
            'btnUpdate.Enabled = True
            lblMsg.ForeColor = Color.Red
            ''lblMsg.Text = "New software version is released."
        Else
            timReset.Stop()
            timReset.Enabled = False
            'btnUpdate.Enabled = False
            IsUpToDate = True
            ''lblMsg.Text = "Software version is current."
        End If

        lblMsg.Text = appVersionMsg
        txtUpdateVer.Text = systemVersion

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If Not _ftpClient.CheckFTPConnection(3, 5) Then
                XtraMessageBox.Show("FTP connection is unlinked. Please check the FTP Settings.", "Unlink FTP Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim _dtFTPInfo As DataTable = GetDataFromDBToTable("SA_GetFTPSettings",
                                                          New SqlParameter("@ID", 3),
                                                          New SqlParameter("@Flag", 5),
                                                          New SqlParameter("@KC", SAC))

            _ftpClient = _ftpClient.GetFTPDefaultConfiguration(_dtFTPInfo)
            Dim _Success As Boolean = False

            If Not CBool(chkSources.Checked) Then
                'open connection if close
                OpenCon(Con)
                Dim cmd As New SqlCommand("SA_UpdateAppVersion", Con)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@AppName", Application.ProductName)
                    .AddWithValue("@Version", systemVersion)
                    .Add("@IsChange", SqlDbType.Int)
                    cmd.Parameters("@IsChange").Direction = ParameterDirection.Output
                    .Add("@Msg", SqlDbType.NVarChar, 200)
                    cmd.Parameters("@Msg").Direction = ParameterDirection.Output
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                CloseCon(Con)
                Dim IsChanged As Integer = CInt(cmd.Parameters("@IsChange").Value)
                If IsChanged <> 0 Then
                    btnUpdate.Enabled = False
                    ''Dim files() As String = IO.Directory.GetFiles(Application.StartupPath, "*.exe")
                    Dim files() As String = IO.Directory.GetFiles(Application.StartupPath)
                    _Count = files.Count
                    If _Count > 0 Then
                        For Each _file As String In files
                            Try
                                Dim ftp As New FTPUpload(_ftpClient)
                                ftp.UploadFile(_file)
                                AddHandler ftp.FtpFileUploading, AddressOf FTPFileUploadProgressChanged
                                AddHandler ftp.FtpFileUploadCompleted, AddressOf FTPFileUploadCompleted
                                _Success = True
                            Catch ex As Exception
                            End Try
                        Next

                        If _Success Then frmShowUploadPercentage.ShowDialog()
                        XtraMessageBox.Show("Files are successfully uploaded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        XtraMessageBox.Show("Files not found to upload.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    timReset.Stop() 'Timer stops functioning
                    timReset.Enabled = False
                    Second = 0
                    lblMsg.ForeColor = Color.Green
                    lblMsg.Text = "Software version is up to date."
                    'btnUpdate.Enabled = False
                    IsUpToDate = True
                End If
            Else
                Dim _files As New OpenFileDialog
                _files.Multiselect = True
                _files.Filter = "All Files (*.*) | *.*"
                _files.Title = "Select an attachement"
                If _files.ShowDialog() = DialogResult.Cancel Then Return

                Dim fileList() As String = _files.FileNames
                _Count = fileList.Count
                If _Count > 0 Then
                    btnUpdate.Enabled = False
                    For Each _file As String In fileList
                        Try
                            Dim ftp As New FTPUpload(_ftpClient)
                            ftp.UploadFile(_file)
                            AddHandler ftp.FtpFileUploading, AddressOf FTPFileUploadProgressChanged
                            AddHandler ftp.FtpFileUploadCompleted, AddressOf FTPFileUploadCompleted
                            _Success = True
                        Catch ex As Exception
                        End Try
                    Next

                    If _Success Then frmShowUploadPercentage.ShowDialog()
                    XtraMessageBox.Show("Files are successfully uploaded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    XtraMessageBox.Show("Files not found to upload.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ''===============================
                ''Dim files() As String = IO.Directory.GetFiles(Application.StartupPath, "*.exe")
                'Dim files() As String = IO.Directory.GetFiles(Application.StartupPath)
                '_Count = files.Count
                'If _Count > 0 Then
                '    btnUpdate.Enabled = False
                '    _ftpClient = _ftpClient.GetFTPDefaultConfiguration(_dtFTPInfo)
                '    For Each _file As String In files
                '        Try
                '            Dim ftp As New FTPUpload(_ftpClient)
                '            ftp.UploadFile(_file)
                '            AddHandler ftp.FtpFileUploading, AddressOf FTPFileUploadProgressChanged
                '            AddHandler ftp.FtpFileUploadCompleted, AddressOf FTPFileUploadCompleted
                '        Catch ex As Exception

                '        End Try
                '    Next

                '    frmShowUploadPercentage.ShowDialog()
                '    XtraMessageBox.Show("Files are successfully uploaded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Else
                '    XtraMessageBox.Show("Files not found to upload.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If

                timReset.Stop() 'Timer stops functioning
                timReset.Enabled = False
                Second = 0
                lblMsg.ForeColor = Color.Green
                lblMsg.Text = "Software version is up to date."
                'btnUpdate.Enabled = False
                IsUpToDate = True
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub timReset_Tick(sender As Object, e As EventArgs) Handles timReset.Tick
        If Not IsUpToDate Then
            lblMsg.Text = appVersionMsg
            If Second = 0 Then
                lblMsg.ForeColor = Color.Red
            Else
                lblMsg.ForeColor = Color.Blue
            End If
            Second += 1

            If Second > 2 Then
                Second = 0
            End If
        End If
    End Sub

    Private Sub FTPFileUploadProgressChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim args As FtpUploadingEventArgs = TryCast(e, FtpUploadingEventArgs)
        frmShowUploadPercentage.pbAttachment.EditValue = args.DownloadPercentage
        frmShowUploadPercentage.lblUpload.Text = args.DownloadPercentage.ToString + "% completed..."
    End Sub

    Private Sub FTPFileUploadCompleted(ByVal sender As Object, ByVal e As EventArgs)
        _UpCount += 1
        If _UpCount = _Count Then
            _UpCount = 0
            Application.DoEvents()
            Threading.Thread.Sleep(2000)
            frmShowUploadPercentage.Dispose()
        End If
    End Sub

    Private Sub frmUpdateAppVersion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub chkSources_CheckStateChanged(sender As Object, e As EventArgs) Handles chkSources.CheckStateChanged
        btnUpdate.Focus()
    End Sub
End Class