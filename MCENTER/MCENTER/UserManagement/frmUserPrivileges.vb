Imports System.Data.SqlClient

Public Class frmUserPrivileges

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        UserGroupName = lueUserGroups.Text.Trim
        UserGroupID = lueUserGroups.EditValue.ToString
        LoadFormDialog(frmAssignUserPermissions)
    End Sub

    Private Sub frmUserPrivileges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDBConnection()
        GetDataToComboBoxWithParam(lueUserGroups, "SA_GetGroupToCombo", "ID", "GroupName")
    End Sub

    Private Sub lueUserGroups_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueUserGroups.Closed
        'If CInt(lueUserGroups.EditValue) <= 0 Then
        '    MessageBox.Show("Please enter or select a User Group.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return
        'End If
        Try
            GetUserGroupInfo(lueUserGroups.EditValue.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetUserGroupInfo(Find_ID As String)
        Try
            'open connection if close
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_GetGroupToList", Con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ID", Find_ID)

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            Dim i As Integer = ds.Tables(0).Rows.Count
            If i = 1 Then
                btnUsers.Enabled = True
                txtNumber.Text = ds.Tables(0).Rows(0)("ID").ToString
                meDescription.Text = ds.Tables(0).Rows(0)("Description").ToString

                LoadUserPrivileges(Find_ID)
                btnUsers.Focus()
            Else
                '' ClearAllContent()
                MessageBox.Show("Searching keyword: " + lueUserGroups.Text.Trim + " doesnot exist on the target system. " & vbLf & vbLf & "Please try another group name.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lueUserGroups.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + ". Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'close connection if open
        CloseCon(Con)
    End Sub

    Public Sub LoadUserPrivileges(FindID As String)
        Dim dt As DataTable = GetDataFromDBToTable("SA_GetUserPrivilegesToList", New SqlParameter("@id", FindID))
        If dt.Rows.Count > 0 Then
            With gvUsers
                gcUsers.DataSource = dt
                .PopulateColumns()
                .Columns("UserNo").Visible = False
                .Columns("UserCreate").Visible = False
                .Columns("DateCreate").Visible = False
                .Columns("UserUpdate").Visible = False
                .Columns("DateUpdate").Visible = False
                .BestFitColumns()
            End With
        Else
            gcUsers.DataSource = Nothing
        End If
    End Sub


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        lueUserGroups.Focus()
    End Sub

    Private Sub ClearAllContent()
        lueUserGroups.EditValue = -1
        txtNumber.Text = ""
        meDescription.Text = ""
        gcUsers.DataSource = Nothing
        ShowUpdateFooterNote(False)
        ShowAddFooterNote(False)
    End Sub

    Private Sub ShowUpdateFooterNote(Optional ByVal en As Boolean = True)
        If Not en Then
            txtUpdatedBy.Text = ""
            txtUpdatedDate.Text = ""
        End If
        txtUpdatedBy.Visible = en
        lblUpdatedBy.Visible = en
        txtUpdatedDate.Visible = en
        lblUpdatedDate.Visible = en
    End Sub

    Private Sub ShowAddFooterNote(Optional ByVal en As Boolean = True)
        If Not en Then
            txtCreatedBy.Text = ""
            txtCreatedDate.Text = ""
        End If

        lblCreatedBy.Visible = en
        txtCreatedBy.Visible = en
        lblCreatedDate.Visible = en
        txtCreatedDate.Visible = en
    End Sub


    Private Sub getFooterNote(useradd As String, dateadd As String, userupdate As String, dateupdate As String)
        If String.IsNullOrEmpty(useradd) OrElse String.IsNullOrEmpty(dateadd) Then
            ShowAddFooterNote(False)
        Else
            txtCreatedBy.Text = useradd
            txtCreatedDate.Text = dateadd
            ShowAddFooterNote()
        End If

        If String.IsNullOrEmpty(userupdate) OrElse String.IsNullOrEmpty(dateupdate) Then
            ShowUpdateFooterNote(False)
        Else
            txtUpdatedBy.Text = userupdate
            txtUpdatedDate.Text = dateupdate
            ShowUpdateFooterNote()
        End If
    End Sub
End Class