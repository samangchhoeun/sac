Public Class FtpUploadingEventArgs
    Inherits EventArgs

    Public Property Status As String
    Public Property DownloadPercentage As Integer
    Public Property TotalFileSize As Long
End Class
