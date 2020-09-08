Imports System.Net
Imports DevExpress.XtraEditors

Public Class FTPUpload
    Private _client As WebClient = Nothing
    Public Property FtpUsername As String
    Public Property FtpPassword As String
    Public Property FtpAddress As String

    Public Event FtpFileUploading As EventHandler
    Public Event FtpFileUploadCompleted As EventHandler

    Public Sub New(ByVal _FTPClient As FTPClient)
        FtpUsername = _FTPClient.FtpUsername
        FtpPassword = _FTPClient.FtpPassword
        FtpAddress = _FTPClient.FtpAddress
        If _client Is Nothing Then _client = New WebClient()
    End Sub

    Protected Overridable Sub OnFtpFileUploading(ByVal e As FtpUploadingEventArgs)
        RaiseEvent FtpFileUploading(Me, e)
    End Sub

    Protected Overridable Sub OnFtpFileUploadCompleted(ByVal e As FtpUploadCompletedEventArgs)
        RaiseEvent FtpFileUploadCompleted(Me, e)
    End Sub

    Public Sub UploadFile(ByVal filePath As String, Optional ByVal _Newfilename As String = "")
        Dim fileName = System.IO.Path.GetFileName(filePath)
        If Not String.IsNullOrEmpty(_Newfilename) Then
            'Dim ext As String = System.IO.Path.GetExtension(fileName)
            fileName = _Newfilename
        End If
        Dim _ftpAddress = New Uri(New Uri(FtpAddress), fileName)
        _client.Credentials = New NetworkCredential(FtpUsername, FtpPassword)
        _client.UploadFileAsync(_ftpAddress, WebRequestMethods.Ftp.UploadFile, filePath)

        AddHandler _client.UploadProgressChanged, AddressOf _client_UploadProgressChanged
        AddHandler _client.UploadFileCompleted, AddressOf _client_UploadFileCompleted
    End Sub

    Private Sub _client_UploadFileCompleted(ByVal sender As Object, ByVal e As UploadFileCompletedEventArgs)
        Dim args As FtpUploadCompletedEventArgs = New FtpUploadCompletedEventArgs()
        args.Status = "Upload Completed"
        OnFtpFileUploadCompleted(args)
    End Sub

    Private Sub _client_UploadProgressChanged(ByVal sender As Object, ByVal e As UploadProgressChangedEventArgs)
        Dim args As FtpUploadingEventArgs = New FtpUploadingEventArgs()
        args.DownloadPercentage = e.ProgressPercentage
        args.Status = "Uploading"
        args.TotalFileSize = e.TotalBytesToSend
        OnFtpFileUploading(args)
    End Sub

End Class
