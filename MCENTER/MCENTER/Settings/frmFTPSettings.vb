Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmFTPSettings
    Public _TempID As Integer = 0
    Private Sub frmFTPSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDataToComboBoxWithParam(lueFTPGroup, "SA_ReadFTPGroupList", "FTPGroupID", "GroupType")
        lueFTPGroup.ItemIndex = 0
        GetFTPSettingsToList()
    End Sub

    Public Sub LoadFTPSettings(Optional _ID As Integer = 0, Optional _Flag As Integer = 0)
        Try
            Dim dtFTPInfo As DataTable = GetDataFromDBToTable("SA_GetFTPSettings",
                                                          New SqlParameter("@ID", _ID),
                                                          New SqlParameter("@Flag", _Flag),
                                                          New SqlParameter("@KC", SAC))
            If GetFTPConfiguration(dtFTPInfo) Then
                btnTest.Enabled = True
                EnabledEdit(False)
                btnSave.Enabled = True
                btnAddNew.Enabled = True
            End If
        Catch ex As Exception
            ClearAllContents()
        End Try

        txtFTPAddress.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtFTPUser.Text.Trim) Or String.IsNullOrEmpty(btnFTPPass.Text.Trim) Or String.IsNullOrEmpty(txtFTPAddress.Text.Trim) Then
            XtraMessageBox.Show("Some fields are empty!", "FTP Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFTPAddress.Focus()
            Return
        End If

        Try
            EnabledEdit(True)
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveFTPConfiguration", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _TempID)
                .AddWithValue("@FTPAddress", txtFTPAddress.Text.Trim)
                .AddWithValue("@FTPUser", txtFTPUser.Text.Trim)
                .AddWithValue("@FTPPass", btnFTPPass.Text.Trim)
                .AddWithValue("@Remark", meRemark.Text.Trim)
                .AddWithValue("@FTPGroup", CInt(lueFTPGroup.EditValue))
                .AddWithValue("@KC", SAC)
                .AddWithValue("@User", AccountName)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            Dim MMS As MessageBoxIcon
            Dim IsChanged As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)

            If IsChanged <> 0 Then
                EnabledEdit()
                'btnTest.Enabled = True
                MMS = MessageBoxIcon.Information
            Else
                MMS = MessageBoxIcon.Error
            End If
            CloseCon(Con)
            GetFTPSettingsToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "New FTP Settings", MessageBoxButtons.OK, MMS)
            txtFTPAddress.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Change Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EnabledEdit(Optional En As Boolean = True)
        txtFTPUser.ReadOnly = En
        btnFTPPass.ReadOnly = En
        txtFTPAddress.ReadOnly = En
        lueFTPGroup.ReadOnly = En
        meRemark.ReadOnly = En
        btnSave.Enabled = Not En
    End Sub

    Private Sub EnabledEditDoubleClick(sender As Object, e As EventArgs) Handles txtFTPUser.DoubleClick, txtFTPAddress.DoubleClick
        EnabledEdit(False)
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Dim _ftpClient As New FTPClient
        If _ftpClient.CheckFTPConnection(_TempID) Then
            XtraMessageBox.Show("Connecting to " + txtFTPAddress.Text.Trim + " successfully!", "Aready Connected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            XtraMessageBox.Show("Connection failed", "FTP Link Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            ppMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
        End If
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Dim SelRows As Integer() = gvData.GetSelectedRows()
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to modify.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        ElseIf SelRows.Count > 1 Then
            XtraMessageBox.Show("You cannot select multiple records to modify at a time.", "Multiple Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            If SelRows.Count = 1 Then
                Me.Cursor = Cursors.WaitCursor
                gcData.Cursor = Cursors.WaitCursor
                Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(gvData.FocusedRowHandle), DataRowView)
                LoadFTPSettings(CInt(SelectedRow("ID").ToString))
                Me.Cursor = Cursors.Default
                gcData.Cursor = Cursors.Default
            End If

            'frmPreviewSalaryInfo._SalaryInfoList = GetSalarySlipPreview(_SalaryList.ID, _SalaryList.StaffID)
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearAllContents()
        _TempID = 0
        txtID.Text = "***"
        txtFTPAddress.Text = ""
        txtFTPUser.Text = ""
        btnFTPPass.Text = ""
        meRemark.Text = ""
        lueFTPGroup.ItemIndex = 0
        meRemark.Text = ""
        EnabledEdit(False)
        txtFTPAddress.Focus()
    End Sub

    Public Sub GetFTPSettingsToList(Optional _ID As Integer = 0, Optional _Flag As Integer = 0)
        Dim dtFTPInfo As DataTable = GetDataFromDBToTable("SA_GetFTPSettings",
                                                          New SqlParameter("@ID", _ID),
                                                          New SqlParameter("@Flag", _ID),
                                                          New SqlParameter("@KC", SAC))
        ' gvData.ViewCaption = GetCampusDepartment()
        If dtFTPInfo.Rows.Count > 0 Then
            gcData.DataSource = dtFTPInfo
            With gvData
                .PopulateColumns()
                .Columns("FTPPassword").Visible = False
                .Columns("ID").Visible = False
                .Columns("ID").Width = 30
                .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                .Columns("ID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Remark").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                .Columns("Remark").SummaryItem.DisplayFormat = "Total: {0} Records"
            End With
        Else
            gcData.DataSource = Nothing
            gvData.Columns.Clear()
        End If
    End Sub

    Private Sub btnFTPPassword_MouseDown(sender As Object, e As MouseEventArgs) Handles btnFTPPass.MouseDown
        btnFTPPass.Properties.UseSystemPasswordChar = False
    End Sub

    Private Sub btnFTPPassword_MouseUp(sender As Object, e As MouseEventArgs) Handles btnFTPPass.MouseUp
        btnFTPPass.Properties.UseSystemPasswordChar = True
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        btnTest.Enabled = False
        ClearAllContents()
    End Sub

    Private Sub bbiPTestConnection_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPTestConnection.ItemClick
        Dim SelRows As Integer() = gvData.GetSelectedRows()
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to modify.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        ElseIf SelRows.Count > 1 Then
            XtraMessageBox.Show("You cannot select multiple records to modify at a time.", "Multiple Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            If SelRows.Count = 1 Then
                Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(gvData.FocusedRowHandle), DataRowView)
                Dim _ftpClient As New FTPClient
                If _ftpClient.CheckFTPConnection(CInt(SelectedRow("ID").ToString)) Then
                    XtraMessageBox.Show("Connecting to " + SelectedRow("FTPAddress").ToString + " successfully!", "Aready Connected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    XtraMessageBox.Show("Connection failed", "FTP Link Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiRemove.ItemClick
        With gvData
            If .RowCount <= 0 Then
                XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Try
                Dim _Code As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ID").ToString)
                Dim _FTPAddress As String = .GetRowCellValue(.FocusedRowHandle, "FTPAddress").ToString

                detected = XtraMessageBox.Show("Do you want to remove FTP link: " + _FTPAddress + " from the list?", "Removing?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then
                    Return
                End If
                RemoveFTPConfiguration(_Code, _FTPAddress, 1)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub

    Friend Sub RemoveFTPConfiguration(_Code As Integer, _FTPAddress As String, Optional ByVal _IsRemoved As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_RemoveFTPLink", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Code", _Code)
                .AddWithValue("@FTPAddress", _FTPAddress)
                .AddWithValue("@Isremoved", _IsRemoved)
                .AddWithValue("@UserUpdate", AccountName)
                .Add("@IsDeleted", SqlDbType.Int)
                cmd.Parameters("@IsDeleted").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 300)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)

            Dim mms As MessageBoxIcon = MessageBoxIcon.Information
            If CInt(cmd.Parameters("@IsDeleted").Value) = 0 Then
                mms = MessageBoxIcon.Error
            End If

            GetFTPSettingsToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm message", MessageBoxButtons.OK, mms)
            btnAddNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        With gvData
            If .RowCount <= 0 Then
                XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Try
                Dim _Code As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ID").ToString)
                Dim _FTPAddress As String = .GetRowCellValue(.FocusedRowHandle, "FTPAddress").ToString

                detected = XtraMessageBox.Show("Do you want to restore FTP link: " + _FTPAddress + " to the list?", "Restore?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then
                    Return
                End If
                RemoveFTPConfiguration(_Code, _FTPAddress)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub
End Class