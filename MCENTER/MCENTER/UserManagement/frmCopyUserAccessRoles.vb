Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmCopyUserAccessRoles
    Public _FormOpen As Integer = 0
    Public _UserNoFrom As Integer = 0

    Private Sub frmCopyUserAccessRoles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _FormOpen = 1 Then
            lblLabel.Text = "Copy Permission To..."
        Else
            lblLabel.Text = "Copy Permission From..."
        End If

        GetDataToComboBoxWithParam(lueStaffID, "SA_GetUserLogByIDToList", "UserNo", "AccountName", New SqlParameter("@ID", ""))
        lueStaffID.ItemIndex = 0
    End Sub

    Private Sub frmCopyUserAccessRoles_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CopyAccessPermission(UserNoFrom As Integer, UserNoTo As Integer)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_CopyUserAccessPermissions", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@UserNoFrom", UserNoFrom)
                .AddWithValue("@UserNoTo", UserNoTo)
                .AddWithValue("@User", AccountName)
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
            frmAssignUserAccessRoles.LoadUserAccessControlToList(UserNoTo)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Access Permissions", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        If _UserNoFrom = 0 OrElse CInt(lueStaffID.EditValue) = 0 Then
            XtraMessageBox.Show("Please choose an account to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        ElseIf _UserNoFrom = CInt(lueStaffID.EditValue) Then
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lueStaffID.Focus()
            Return
        End If

        If _FormOpen = 1 Then
            CopyAccessPermission(_UserNoFrom, CInt(lueStaffID.EditValue))
        Else
            CopyAccessPermission(CInt(lueStaffID.EditValue), _UserNoFrom)
        End If
    End Sub
End Class