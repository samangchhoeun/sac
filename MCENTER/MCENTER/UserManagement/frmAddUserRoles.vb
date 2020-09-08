Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmAddUserRoles
    Dim _ID As Integer = 0

    Private Sub frmAddUserRoles_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Public Sub GetSearchDataByID(Find_ID As Integer)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetUserRoleByID", New SqlParameter("@ID", Find_ID))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True)
                    btnNew.Enabled = False
                    txtNumber.Text = .Rows(0)("Code").ToString
                    _ID = CInt(.Rows(0)("Code"))
                    txtAccountName.Text = .Rows(0)("RoleType").ToString
                    meRemark.Text = .Rows(0)("Remark").ToString
                    txtAccountName.Focus()
                Else
                    ClearIfNewContent()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        meRemark.ReadOnly = Not en
        txtAccountName.ReadOnly = Not en
    End Sub

    Private Sub ClearIfNewContent()
        'deHoliday.DateTime = DateTime.Now
        txtNumber.Text = "***"
        meRemark.Text = ""
        _ID = 0
        txtAccountName.Text = ""
        EnabledButtonSave()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtAccountName.Text.Trim) Then
            XtraMessageBox.Show("Please enter role type.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAccountName.Focus()
            Return
        End If

        Try
            If txtNumber.Text <> "***" Then _ID = CInt(txtNumber.Text.Trim)

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveUserRole", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _ID)
                .AddWithValue("@RoleType", txtAccountName.Text.Trim)
                .AddWithValue("@Remark", meRemark.Text.Trim)
                .AddWithValue("@User", AccountName)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            EnabledEdit()
            btnSave.Enabled = False
            btnNew.Enabled = False
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            If IsAdd > 0 Then
                MMS = MessageBoxIcon.Information
                EnabledEdit(False)
                EnabledButtonSave("Save", False)
                btnNew.Enabled = True
            End If

            frmViewUserRoles.LoadAccTypesToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Role Type", MessageBoxButtons.OK, MMS)
            btnNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearIfNewContent()
        EnabledEdit()
        txtAccountName.Focus()
    End Sub
End Class