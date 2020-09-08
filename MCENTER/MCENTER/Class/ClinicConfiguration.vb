Public Class ClinicConfiguration
    Public Property ClinicID As Integer
    Public Property Clinic As String
    Public Property BuildingID As Integer
    Public Property Building As String
    Public Property UserCreate As String
    Public Property DateCreate As String

    Public Shared Function ActivateDate(ByVal _SetDate As String) As String
        Return Format(Convert.ToDateTime(_SetDate), "MM/dd/yyyy").Trim
    End Function

    Public Shared Function ActivateTime(ByVal _SetTime As String) As String
        Return Format(Convert.ToDateTime(_SetTime), "h:mm:ss tt").Trim
    End Function
End Class
