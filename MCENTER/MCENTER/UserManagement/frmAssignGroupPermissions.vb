Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmAssignGroupPermissions
    Dim IsSuccessAddedControl As Boolean = False
    Private Sub frmAssignPermissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadDBConnection()
        txtGroup.Text = UserGroupName
        LoadAllControlsToList()
    End Sub

    Private Sub LoadAllControlsToList()
        Dim _GroupControlIDs As List(Of clsControls) = clsControls.GetGroupControlID(UserGroupID)
        gcGroups.DataSource = GetAvailableControl()
        With gvGroups
            .PopulateColumns()
            .Columns("Tab").Group()
            .Columns("Group").Group()
            .ExpandAllGroups()
            .SelectAll()
            Dim SelRows As Integer() = .GetSelectedRows
            .ClearSelection()
            If _GroupControlIDs.Count > 0 Then
                For Each i As Integer In SelRows
                    If (i >= 0) Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(i), AvailableControls)
                        For index As Integer = 0 To _GroupControlIDs.Count - 1
                            If SelectedRow.Control.ToString = _GroupControlIDs.Item(index).ControlName Then .SelectRow(i)
                        Next
                    End If
                Next
            End If

            .BestFitColumns()
        End With
    End Sub

    Private Sub frmAssignGroupPermissions_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        GetSelectedPermissions()
    End Sub

    Private Sub GetSelectedPermissions()
        Dim SelRows() As Integer = gvGroups.GetSelectedRows()
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            'DeletedOldGroupPermissions()

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As AvailableControls = CType(gvGroups.GetRow(index), AvailableControls)
                    If (index >= 0) Then _TempID(i) = SelectedRow.Control.ToString
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Want to add the selected permissions to group?", "Add Permissions", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            AssignGroupPermissions(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AssignGroupPermissions(ByVal _StrID As String)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveGroupPermissions", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@GroupID", UserGroupID)
                .AddWithValue("@ControlList", _StrID)
                .AddWithValue("@User", AccountName)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            Dim IsAdd As Integer = CInt(cmd.Parameters("@IsAdd").Value)
            If IsAdd <> 0 Then MMS = MessageBoxIcon.Information
            frmUserRoles.LoadAllControlsToList(UserGroupID)
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Permissions", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub DeletedOldGroupPermissions()
    '    Try
    '        OpenCon(Con)
    '        Dim cmd As New SqlCommand("SA_DeleteOldGroupPermissions", Con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        With cmd.Parameters
    '            .AddWithValue("@GroupID", UserGroupID)
    '        End With
    '        cmd.ExecuteNonQuery()
    '        cmd.Dispose()
    '        CloseCon(Con)
    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End Try
    'End Sub
End Class

