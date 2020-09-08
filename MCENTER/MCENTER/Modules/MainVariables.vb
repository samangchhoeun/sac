Imports System.Data.SqlClient

Module MainVariables
    Public User_Cannot_Change_Pass As Integer
    Public LogUserID As String
    Public LogPass As String

    Public PositionID As String
    Public LogUserNo As Integer
    'Public LogDivisionID As Integer
    Public LogClinicID As Integer
    Public LogDeptID As Integer
    Public LogCampusID As Integer
    Public LogRoleID As Integer
    Public AccountName As String
    Public LastLoggedIn As String

    Public detected As DialogResult

    Public Con As SqlConnection
    Public ServerName As String
    Public DBName As String
    Public DBUser As String
    Public DBPwd As String
    Public IsSaveCon As Boolean = False
    Public _IsActive As Boolean = False

    Public UserGroupName As String
    Public UserGroupID As String
    Public GroupID As Integer

    Friend IsMrSAM As String
    Friend SAC As String
    Friend RemotePath As String
    Friend CommandLine As String

    Public IsUserOpen As Boolean

    Public Holiday As New SearchHoliday
    Public HolidayList As AddHoliday
    Friend _CopyDate As Date


    Public ConfigClinic As ClinicConfiguration
    Public ConfigPrinter As PrinterConfiguration
End Module
