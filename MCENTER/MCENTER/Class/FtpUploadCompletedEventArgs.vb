Public Class FtpUploadCompletedEventArgs
    Inherits EventArgs

    Public Property Status As String
    Public Property HasError As Boolean
    Public Property ErrorMessage As String
End Class
