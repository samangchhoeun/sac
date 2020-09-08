Imports System.IO

Public Class ConfigurationPath
    Public Shared Function ReadConfig(ByVal filePath As String) As String
        Dim fullRemoteDbPath As String = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), filePath)
        If File.Exists(fullRemoteDbPath) Then
            Dim EncContents As String = File.ReadAllText(fullRemoteDbPath)
            Return Decrypt(EncContents)
        Else
            Return ""
        End If
    End Function

    Public Shared Sub SaveConfig(ByVal filePath As String, ByVal contents As String)
        Dim fullExeDbPath As String = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), filePath)
        Dim contentEncrypt As String = Encrypt(contents)
        File.WriteAllText(fullExeDbPath, contentEncrypt)
    End Sub
End Class
