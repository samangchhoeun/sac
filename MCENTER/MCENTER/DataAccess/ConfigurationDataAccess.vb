Imports System.IO
Imports Newtonsoft.Json

Public Class ConfigurationDataAccess(Of T)
    Implements IConfigurationDataAccess(Of T)
    Private ReadOnly Path As String
    Public Sub New(ByVal Path As String)
        Dim IsValid As Boolean
        Try
            If File.Exists(Path) Then IsValid = True
        Catch ex As Exception

        End Try

        '' Avoid Error Exception during OnceClick Deployment Location
        'If IsValid Then
        '    Me.Path = Path
        'Else
        '    Me.Path = ""
        'End If

        Me.Path = Path
    End Sub

    Public Function GetConfig() As T Implements IConfigurationDataAccess(Of T).GetConfig
        If File.Exists(Path) Then
            Dim Json As String = File.ReadAllText(Path)
            Dim Output As T = JsonConvert.DeserializeObject(Of T)(Decrypt(Json))
            Return Output
        Else
            Return Nothing
        End If
    End Function

    Public Sub Save(ByVal Configuration As T) Implements IConfigurationDataAccess(Of T).Save
        'If not empty
        If Not Configuration Is Nothing Then
            Dim Json As String = JsonConvert.SerializeObject(Configuration, Formatting.Indented)

            File.WriteAllText(Path, Encrypt(Json))
        End If
    End Sub

    Public Sub Delete() Implements IConfigurationDataAccess(Of T).Delete
        File.Delete(Path)
    End Sub

    Public Shared Function GetConfiguration(ByVal Path As String) As T
        Dim dataAccess As New ConfigurationDataAccess(Of T)(Path)
        Return dataAccess.GetConfig()
    End Function

    Public Shared Sub SaveConfiguration(ByVal Path As String, ByVal Configuration As T)
        Dim dataAccess As New ConfigurationDataAccess(Of T)(Path)
        dataAccess.Save(Configuration)
    End Sub
End Class
