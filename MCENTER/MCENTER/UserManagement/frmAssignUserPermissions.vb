Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmAssignUserPermissions
    Dim _isSuccess As Boolean = False

    Private Sub frmAssignUserPermissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtGroup.Text = UserGroupName
        LoadUserAccountsToList()
    End Sub

    Friend Sub LoadUserAccountsToList()
        Dim UserIDs As DataTable = GetDataFromDBToTable("SA_GetUserPrivilegeID", New SqlParameter("@id", UserGroupID))
        Dim dtData As DataTable = GetDataFromDBToTable("SA_GetUserAccountToList", New SqlParameter("@ID", ""))
        If dtData.Rows.Count > 0 Then
            gcUsers.DataSource = dtData
            With gvUsers
                .PopulateColumns()
                If UserIDs.Rows.Count > 0 Then
                    For index As Integer = 0 To UserIDs.Rows.Count - 1
                        For i As Integer = 0 To .RowCount - 1
                            If .GetDataRow(i).Item("UserNo").ToString = UserIDs.Rows(index)("UserNo").ToString Then .SelectRow(i)
                        Next
                    Next
                End If
                .Columns("UserNo").Visible = False
                .Columns("UserCreate").Visible = False
                .Columns("DateCreate").Visible = False
                .Columns("UserUpdate").Visible = False
                .Columns("DateUpdate").Visible = False
                .Columns("CardID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("CardID").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .BestFitColumns()
            End With
        End If
    End Sub

    Private Sub frmAssignUserPermissions_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'frmUserPrivileges.LoadUserPrivileges(UserGroupID)
        UserGroupName = ""
        UserGroupID = ""
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        GetSelectedUsers()
    End Sub

    Private Sub GetSelectedUsers()
        Dim SelRows() As Integer = gvUsers.GetSelectedRows()
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvUsers.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("UserNo").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Want to add the selected accounts to group?", "Add Accounts", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            AssignUsersPermission(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AssignUsersPermission(ByVal _StrID As String)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveUserPrivileges", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@GroupID", UserGroupID)
                .AddWithValue("@StrID", _StrID)
                .AddWithValue("@Remark", "")
                .AddWithValue("@User", AccountName)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            Dim IsAdd As Integer = CInt(cmd.Parameters("@IsAdd").Value)
            If IsAdd <> 0 Then MMS = MessageBoxIcon.Information
            frmUserRoles.LoadUserPrivileges(UserGroupID)
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "User Accounts", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class