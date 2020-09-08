Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmAssignUserAccessRoles
    Dim IsSuccessAddedControl As Boolean = False

    Private Sub frmAssignPermissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDataToComboBoxWithParam(lueStaffID, "SA_GetUserLogByIDToList", "UserNo", "AccountName", New SqlParameter("@ID", ""))
    End Sub

    Public Sub LoadUserAccessControlToList(UserNo As Integer)
        Try
            gcGroups.DataSource = GetAvailableUserAccessControl(UserNo)
            With gvGroups
                .PopulateColumns()
                .Columns("Tab").Group()
                .Columns("Group").Group()
                .Columns("IsAdded").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("IsAllowed").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("RoleType").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("RoleType").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .ExpandAllGroups()
                .BestFitColumns()
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmAssignUserAccessRoles_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Public Sub AssignGroupPermissions(ControlList As String, UserNo As Integer, Optional IsAllowed As Integer = 1, Optional RoleID As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveUserAccessPermissions", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@UserNo", UserNo)
                .AddWithValue("@IsAllowed", IsAllowed)
                .AddWithValue("@RoleID", RoleID)
                .AddWithValue("@ControlList", ControlList)
                .AddWithValue("@KC", SAC)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error
            LoadUserAccessControlToList(CInt(IIf(String.IsNullOrEmpty(lueStaffID.Text), 0, lueStaffID.EditValue)))
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Access Permissions", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lueStaffID_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueStaffID.Closed
        Try
            If CInt(lueStaffID.EditValue) <= 0 Then
                XtraMessageBox.Show("Please select group users to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lueStaffID.Focus()
                Return
            End If

            LoadUserAccessControlToList(CInt(lueStaffID.EditValue))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub gcGroups_MouseClick(sender As Object, e As MouseEventArgs) Handles gcGroups.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub bbiPAddNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAddNew.ItemClick
        Try
            Dim SelRows() As Integer = gvGroups.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvGroups.Focus()
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As UserAccessPermissions = DirectCast(gvGroups.GetRow(index), UserAccessPermissions)
                    _TempID(i) = SelectedRow.Control
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to add access permissions to selected account?", "Confirm Message?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return

            AssignGroupPermissions(_IDTempList, CInt(lueStaffID.EditValue))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            Dim SelRows() As Integer = gvGroups.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvGroups.Focus()
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As UserAccessPermissions = DirectCast(gvGroups.GetRow(index), UserAccessPermissions)
                    _TempID(i) = SelectedRow.Control
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove access permissions from selected account?", "Confirm Message?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return

            AssignGroupPermissions(_IDTempList, CInt(lueStaffID.EditValue), 0)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub bbiPAssignAccountType_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAssignAccountType.ItemClick
        Try
            Dim SelRows() As Integer = gvGroups.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvGroups.Focus()
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As UserAccessPermissions = DirectCast(gvGroups.GetRow(index), UserAccessPermissions)
                    _TempID(i) = SelectedRow.Control
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)
            frmAssignAccountType._IDTempList = _IDTempList
            frmAssignAccountType._UserNo = CInt(lueStaffID.EditValue)
            LoadFormDialog(frmAssignAccountType)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub bbiPCopyPermissionTo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPCopyPermissionTo.ItemClick
        If String.IsNullOrEmpty(lueStaffID.Text.Trim) Then
            XtraMessageBox.Show("Please choose an account to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lueStaffID.Focus()
            Return
        End If

        frmCopyUserAccessRoles._FormOpen = 1
        frmCopyUserAccessRoles._UserNoFrom = CInt(lueStaffID.EditValue)
        LoadFormDialog(frmCopyUserAccessRoles)
    End Sub

    Private Sub bbiPcopyPermissionFrom_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPcopyPermissionFrom.ItemClick
        If String.IsNullOrEmpty(lueStaffID.Text.Trim) Then
            XtraMessageBox.Show("Please choose an account to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lueStaffID.Focus()
            Return
        End If

        frmCopyUserAccessRoles._FormOpen = 0
        frmCopyUserAccessRoles._UserNoFrom = CInt(lueStaffID.EditValue)
        LoadFormDialog(frmCopyUserAccessRoles)
    End Sub
End Class

