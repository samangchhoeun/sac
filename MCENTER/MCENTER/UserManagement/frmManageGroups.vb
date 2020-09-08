Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmManageGroups
    Dim _ID As Integer = 0

    Public Sub GetSearchDataByID(Find_ID As Integer)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetGroupToList", New SqlParameter("@id", Find_ID))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True)
                    btnNew.Enabled = False
                    txtNumber.Text = .Rows(0)("ID").ToString
                    _ID = CInt(.Rows(0)("ID"))
                    txtGroup.Text = .Rows(0)("GroupName").ToString
                    meDescription.Text = .Rows(0)("Description").ToString
                    txtGroup.Focus()
                Else
                    ClearIfNewContent()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please contact your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        txtGroup.ReadOnly = Not en
        meDescription.ReadOnly = Not en
    End Sub

    Private Sub ClearIfNewContent()
        txtNumber.Text = "***"
        meDescription.Text = ""
        _ID = 0
        txtGroup.Text = ""
        EnabledButtonSave()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtGroup.Text.Trim) Then
            XtraMessageBox.Show("Please enter group name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtGroup.Focus()
            Return
        End If

        Try
            If txtNumber.Text <> "***" Then _ID = CInt(txtNumber.Text.Trim)

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveGroup", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _ID)
                .AddWithValue("@GroupName", txtGroup.Text.Trim)
                .AddWithValue("@Description", meDescription.Text.Trim)
                .AddWithValue("@User", LogUserNo)
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

            frmGroupAccounts.LoadGroupTypesToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Group Type", MessageBoxButtons.OK, MMS)
            btnNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearIfNewContent()
        EnabledEdit()
        txtGroup.Focus()
    End Sub

    Private Sub frmManageGroups_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class