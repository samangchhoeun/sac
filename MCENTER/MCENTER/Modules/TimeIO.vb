Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class TimeIO
    Public Property No As Integer
    Public Property StaffID As String
    Public Property M_TimeIn As String
    Public Property M_TimeOut As String
    Public Property A_TimeIn As String
    Public Property A_TimeOut As String
    Public Property E_TimeIn As String
    Public Property E_TimeOut As String
    Public Property ModifiedDate As DateTime?
    Public Property RemarkCode As String
    Public Property Remark As String

    Public Shared Function ActivateDate(ByVal _SetDate As String) As String
        Return Format(Convert.ToDateTime(_SetDate), "MM/dd/yyyy").Trim
    End Function

    Public Shared Function ActivateTime(ByVal _SetTime As String) As String
        Return Format(Convert.ToDateTime(_SetTime), "h:mm:ss tt").Trim
    End Function

    Public Shared Function GetScheduleDateTime(ByVal _SetDateTime As String) As String
        Return Format(Convert.ToDateTime(_SetDateTime), "MM/dd/yyyy h:mm:ss tt").Trim
    End Function

    'Public Shared Function GetSystemShortTime() As String
    '    'Dim _DataList As List(Of String) = Get2Results("SA_GetServerDateTime")
    '    'Return Format(Convert.ToDateTime(Right(_DataList(0), 11)), "hh:mm tt").Trim
    'End Function

    'Public Shared Function GetSystemLongTime() As String
    '    'Dim _DataList As List(Of String) = Get2Results("SA_GetServerDateTime")
    '    'Return Format(Convert.ToDateTime(Right(_DataList(0), 11)), "h:mm:ss tt").Trim
    'End Function

    'Public Shared Function GetSystemDate() As String
    '    'Dim _DataList As List(Of String) = Get2Results("SA_GetServerDateTime")
    '    'Return Format(Convert.ToDateTime(_DataList(0)), "MM/dd/yyyy").Trim
    'End Function


    Public Shared Function GetSystemDateTime() As String
        Try
            'Dim _DataList As List(Of String) = Get2Results("SA_GetServerDateTime")
            'Return Format(Convert.ToDateTime(_DataList(0)), "dddd, MMMM dd, yyyy h:mm:ss tt").Trim
            Return Format(Now, "dddd, MMMM dd, yyyy h:mm:ss tt").Trim
        Catch ex As Exception
            Return Format(Now, "dddd, MMMM dd, yyyy h:mm:ss tt")
        End Try
    End Function

    'Public Shared Function GetSystemCompareDateTime() As String
    '    'Try
    '    '    Dim _DataList As List(Of String) = Get2Results("SA_GetServerDateTime")
    '    '    Return Format(Convert.ToDateTime(_DataList(0)), "MM/dd/yyyy h:mm:ss tt").Trim
    '    'Catch ex As Exception
    '    '    Return Format(Now, "MM/dd/yyyy h:mm:ss tt")
    '    'End Try
    'End Function


    'Public Shared Sub LoadDefaultDateTime(ByVal _SetDateTime As String)
    '    defaultDate = TimeIO.ActivateDate(_SetDateTime)
    '    defaultTime = TimeIO.ActivateTime(_SetDateTime)
    '    If String.IsNullOrEmpty(defaultDate) Then defaultDate = TimeIO.GetSystemDate
    '    If String.IsNullOrEmpty(defaultTime) Then defaultTime = TimeIO.GetSystemLongTime
    'End Sub
End Class
