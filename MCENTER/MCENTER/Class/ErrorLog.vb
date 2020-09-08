Public NotInheritable Class ErrorLog
    Public Property Title As String
    Public Property Message As String
    Public Property ErrorTime As DateTime

    Private Shared ReadOnly Property LogFileName As String = "ErrorLog.dll"

    Private Shared Sub Save(ByVal logList As List(Of ErrorLog))
        Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(logList, Newtonsoft.Json.Formatting.Indented)
        'Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(logList, Newtonsoft.Json.Formatting.None)
        System.IO.File.WriteAllText(LogFileName, jsonString)
    End Sub

    Private Shared Function ReadErrorLog() As List(Of ErrorLog)
        Dim lstLog As New List(Of ErrorLog)
        If System.IO.File.Exists(LogFileName) Then
            Dim jsonString As String = System.IO.File.ReadAllText(LogFileName)
            lstLog = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of ErrorLog))(jsonString)
        End If
        Return lstLog
    End Function

    Public Shared Sub WriteLog(ByVal Title As String, ByVal Message As String)
        Dim errors As List(Of ErrorLog) = ReadErrorLog()
        errors.Add(New ErrorLog() With {.Title = Title, .Message = Message, .ErrorTime = Now})
        Save(errors)
    End Sub

End Class