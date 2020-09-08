Imports Dapper

Public Class clsControls
    Public Property ID As Integer
    Public Property Caption As String
    Public Property KhmerCaption As String
    Public Property ControlName As String
    Public Property IsAdded As Boolean
    Public Property AccountType As String


    Public Shared Function GetListOfControls() As List(Of clsControls)
        'LoadDBConnection()
        Return Con.Query(Of clsControls)("SA_GetControlsToList ''").ToList()
    End Function

    Public Shared Function GetVisibleUserAccessControlsToList(UserNo As Integer) As List(Of clsControls)
        'LoadDBConnection()
        Return Con.Query(Of clsControls)("SA_GetUserAccessPermissionByID @UserNo", New With {.UserNo = UserNo}).ToList()
    End Function

    Public Shared Function GetVisibleControlsToList(UserNo As Integer, GroupID As Integer) As List(Of clsControls)
        'LoadDBConnection()
        Return Con.Query(Of clsControls)("SA_GetVisibleControlsToList @UserNo, @GroupID", New With {.UserNo = UserNo, .GroupID = GroupID}).ToList()
    End Function

    Public Shared Function GetExcludeControls() As List(Of clsControls)
        'LoadDBConnection()
        Return Con.Query(Of clsControls)("SA_GetExcludeControlsToList").ToList()
    End Function

    Public Shared Function GetGroupControlID(GroupID As String) As List(Of clsControls)
        'LoadDBConnection()
        Return Con.Query(Of clsControls)("SA_GetGroupControlID @GroupID", New With {.GroupID = GroupID}).ToList()
    End Function

    Public Shared Function GetGroupControlsByID(GroupID As String) As List(Of clsControls)
        'LoadDBConnection()
        Return Con.Query(Of clsControls)("SA_GetGroupPermissionToList @GroupID", New With {.GroupID = GroupID}).ToList()
    End Function

    Public Shared Function GetListOfAllControls() As List(Of clsControls)
        'LoadDBConnection()
        Return Con.Query(Of clsControls)("SA_GetAllControlsToList").ToList()
    End Function

    Public Shared Function GetListOfRemovedControls() As List(Of clsControls)
        'LoadDBConnection()
        Return Con.Query(Of clsControls)("SA_GetRemovedControlsToList").ToList()
    End Function

End Class
