Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports DevExpress.XtraEditors

Public Class frmUserRoles
    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Public Sub frmUserRoles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDataToComboBoxWithParam(lueUserGroups, "SA_GetGroupToCombo", "ID", "GroupName")
        If isLoggedInOwner Then
            bbiDisableUser.Enabled = True
            bbiEnableUser.Enabled = True
            bbiPPermanentDelete.Enabled = True
        End If
    End Sub

    Private Async Sub lueUserGroups_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueUserGroups.Closed
        Try
            If CInt(lueUserGroups.EditValue) <= 0 Then
                XtraMessageBox.Show("Please select group users to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lueUserGroups.Focus()
                Return
            End If

            Await GetUserGroupInfo(lueUserGroups.EditValue.ToString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Friend Async Function GetUserGroupInfo(Find_ID As String) As Task
        Try
            frmLoadingData.Show(Me)
            Await Task.Delay(200)
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetGroupToList", New SqlParameter("@ID", Find_ID))
            With dtData
                If .Rows.Count = 1 Then
                    txtNumber.Text = .Rows(0)("ID").ToString
                    meDescription.Text = .Rows(0)("Description").ToString
                    LoadUserPrivileges(Find_ID)
                    LoadAllControlsToList(Find_ID)
                    LoadDefaultControlsToList()
                Else
                    XtraMessageBox.Show("Searching keyword: " + lueUserGroups.Text.Trim + " doesnot exist on the target system.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    lueUserGroups.Focus()
                End If
            End With
            frmLoadingData.Hide()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + ". Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Sub LoadUserPrivileges(FindID As String)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetUserPrivilegesToList", New SqlParameter("@id", FindID))
            If dt.Rows.Count > 0 Then
                gcUsers.DataSource = dt
                With gvUsers
                    .PopulateColumns()
                    .Columns("UserNo").Visible = False
                    .Columns("Inactive").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("CardID").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("CardID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("AccountBlock").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("ChangePasswordNextLogon").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("RestrictPasswordChange").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            Else
                gcUsers.DataSource = Nothing
                gvUsers.Columns.Clear()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LoadAllControlsToList(UserGroupID As String)
        Try
            gcGroups.DataSource = GetAvailableControlByGroup(UserGroupID)
            With gvGroups
                .PopulateColumns()
                .Columns("Tab").Group()
                .Columns("Group").Group()
                '.Columns("IsAdded").OptionsColumn.FixedWidth = True
                '.Columns("IsAdded").Width = 170
                .Columns("IsAdded").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .ExpandAllGroups()
                .BestFitColumns()
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LoadDefaultControlsToList()
        Try
            gcDefaultPermissions.DataSource = GetExludedControlsAvailable()
            With gvDefaultPermissions
                .PopulateColumns()
                .Columns("Tab").Group()
                .Columns("Group").Group()
                '.Columns("IsAdded").OptionsColumn.FixedWidth = True
                '.Columns("IsAdded").Width = 170
                .Columns("IsAdded").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .ExpandAllGroups()
                .BestFitColumns()
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub gcUsers_MouseClick(sender As Object, e As MouseEventArgs) Handles gcUsers.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppMenuUserRoles.ShowPopup(Me.bmMenuUserRoles, Control.MousePosition)
    End Sub

    Private Sub gcGroups_MouseClick(sender As Object, e As MouseEventArgs) Handles gcGroups.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppMenuPermissions.ShowPopup(Me.bmMenuPermissions, Control.MousePosition)
    End Sub

    Private Sub bbiMAddUser_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiMAddUser.ItemClick
        Try
            UserGroupName = lueUserGroups.Text.Trim
            UserGroupID = lueUserGroups.EditValue.ToString
            LoadFormDialog(frmAssignUserPermissions)
        Catch ex As Exception
            XtraMessageBox.Show("Please select group to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lueUserGroups.Focus()
        End Try

    End Sub

    Private Sub bbiMAddPermission_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiMAddPermission.ItemClick
        Try
            UserGroupName = lueUserGroups.Text.Trim
            UserGroupID = lueUserGroups.EditValue.ToString
            LoadFormDialog(frmAssignGroupPermissions)
        Catch ex As Exception
            XtraMessageBox.Show("Please select group to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lueUserGroups.Focus()
        End Try
    End Sub

    Private Sub bbiMRemoveUser_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiMRemoveUser.ItemClick
        Try
            Dim SelRows() As Integer = gvUsers.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvUsers.Focus()
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvUsers.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("CardID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove selected accounts from this list?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            RemoveUsersPermission(_IDTempList, 0, 1, 1)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiDisableUser_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiDisableUser.ItemClick
        Try
            Dim SelRows() As Integer = gvUsers.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvUsers.Focus()
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvUsers.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("CardID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to block selected accounts from this list?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            RemoveUsersPermission(_IDTempList, 1, 0)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiEnableUser_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiEnableUser.ItemClick
        Try
            Dim SelRows() As Integer = gvUsers.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvUsers.Focus()
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvUsers.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("CardID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to unblock selected accounts from this list?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            RemoveUsersPermission(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmUserRoles_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        Try
            Dim SelRows() As Integer = gvUsers.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvUsers.Focus()
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvUsers.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("CardID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to restore selected accounts from this list?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            RemoveUsersPermission(_IDTempList, 0, 0, 1)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiMRemovePermission_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiMRemovePermission.ItemClick
        Try
            Dim SelRows() As Integer = gvGroups.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvUsers.Focus()
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As AvailableControls = DirectCast(gvGroups.GetRow(index), AvailableControls)
                    _TempID(i) = SelectedRow.Control
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove selected permissions from this group?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            RemovePermissions(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RemovePermissions(ControlList As String)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_RemoveGroupPermissions", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@GroupID", lueUserGroups.EditValue.ToString)
                .AddWithValue("@ControlList", ControlList)
                .Add("@IsUpdate", SqlDbType.Int)
                cmd.Parameters("@IsUpdate").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 300)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsUpdate").Value)
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error
            LoadAllControlsToList(lueUserGroups.EditValue.ToString)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Permissions", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub RemoveUsersPermission(_IDList As String, Optional ByVal _InActive As Integer = 0, Optional ByVal _IsRemoved As Integer = 0, Optional _FlagRemove As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_RemoveUserPrivileges", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDList)
                .AddWithValue("@GroupID", lueUserGroups.EditValue.ToString)
                .AddWithValue("@InActive", _InActive)
                .AddWithValue("@IsRemoved", _IsRemoved)
                .AddWithValue("@FlagRemove", _FlagRemove)
                .AddWithValue("@User", AccountName)
                .Add("@IsUpdate", SqlDbType.Int)
                cmd.Parameters("@IsUpdate").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 400)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim mms As MessageBoxIcon = MessageBoxIcon.Information
            If CInt(cmd.Parameters("@IsUpdate").Value) = 0 Then mms = MessageBoxIcon.Error
            LoadUserPrivileges(lueUserGroups.EditValue.ToString)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm message", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub PermanentDeleteAccount(_IDList As String)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_PermanentDeleteAccountByGroupID", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@GroupID", lueUserGroups.EditValue.ToString)
                .AddWithValue("@StrID", _IDList)
                .Add("@IsUpdate", SqlDbType.Int)
                cmd.Parameters("@IsUpdate").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 400)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim mms As MessageBoxIcon = MessageBoxIcon.Information
            If CInt(cmd.Parameters("@IsUpdate").Value) = 0 Then mms = MessageBoxIcon.Error
            LoadUserPrivileges(lueUserGroups.EditValue.ToString)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm message", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub bbiPPermanentDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPPermanentDelete.ItemClick
        Try
            Dim SelRows() As Integer = gvUsers.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvUsers.Focus()
                Return
            End If

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

            detected = XtraMessageBox.Show("Do you want to permanently delete selected account from this group?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            PermanentDeleteAccount(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class