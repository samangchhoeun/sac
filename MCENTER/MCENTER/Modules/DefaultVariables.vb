Module DefaultVariables
    Public latestAppVersion As String = ""
    Public systemVersion As String = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString
    Public appVersionMsg As String = ""
    Public newAppVersion As String = ""
    Public dbFileName As String = "SystemDataTalker.dll"
    Public isLoggedInOwner As Boolean = False

    Public isResetPass As Integer = 0
    Public isAuthForm As Integer = 0
    Public isAuthorized As Integer = 0
    Public SID As Integer = 0
    Public MrSAM As String = "SamAngChhoeun"
    Public MIN_PWD_LENGTH As Integer = 6
    Public minPassMsg As String = "Password must be at least 6 characters long."
    Public builtinAccMsg As String = "The following error occurred while attempting to update this user. " + vbCrLf + vbCrLf + " Cannot perform this operation on built-in accounts."
    Public disabledAccMsg As String = "You cannot deactivate this account because the user is currently logged into the system." & vbCrLf & vbCrLf & "Please see your system administrator."

    Public defaultTime As String = ""
    Public defaultDate As String = ""
    Public defaultDateTime As String = ""
    Public isOpenForm As Integer = 0
    Public tempCardID As String = ""
    Public tempIDList As String = ""
    Public tempID As String = ""
    Public isFormPositionOpen As Integer = 0
    Public isFomEmployeeInfo As Boolean = False
    Public Splits As String() = {" ", ",", ";", ".", "/", "|", "\", vbNewLine}
    Public MyChar() As Char = {","c, " "c, "|"c, ";"c, "."c, "/"c, "|"c, "\"c, CChar(vbNewLine)}
    Public Separator As String = " | "
    Public Comma As String = ","

    Public _SearchOption As Integer = 2
    Public _SDateFrom As Date = Now.Date
    Public _SDateTo As Date = Now.Date
    Public _TempUser As String = ""
    Public lang As String = "English"
    Public LogoImage As Image = Nothing
End Module
