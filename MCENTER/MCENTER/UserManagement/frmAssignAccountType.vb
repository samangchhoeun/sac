Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmAssignAccountType
    Public _IDTempList As String = ""
    Public _UserNo As Integer = 0

    Private Sub frmAssignAccountType_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        If String.IsNullOrEmpty(_IDTempList) OrElse _UserNo = 0 Then
            XtraMessageBox.Show("Please choose an account to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            frmAssignUserAccessRoles.AssignGroupPermissions(_IDTempList, _UserNo, 1, CInt(lueAccountType.EditValue))
            frmAssignUserAccessRoles.LoadUserAccessControlToList(_UserNo)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub LoadAccountType()
        GetDataToComboBoxWithParam(lueAccountType, "SA_GetRoleList", "RoleID", "RoleType", New SqlParameter("@IsAdmin", isLoggedInOwner))
        lueAccountType.ItemIndex = 0
    End Sub

    Private Sub frmAssignAccountType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAccountType()
    End Sub
End Class