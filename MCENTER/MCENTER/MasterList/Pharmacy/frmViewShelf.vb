Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmViewShelf
    Dim dtData As New DataTable
    Dim ID As Integer = 0
    Public PageRefresh As String = ""

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'InitPageRefresh()
        Dispose()
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = MouseButtons.Right Then pmMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub frmViewShelf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClinic()
        LoadDataToList()
        lueClinic.Select()
    End Sub

    Public Sub LoadDataToList(Optional Find_ID As Integer = 0, Optional ByVal _ClinicID As Integer = 0, Optional ByVal _Flag As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_GetShelfByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@ClinicID", _ClinicID), New SqlParameter("@isList", _Flag))
            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .Columns("ShelfCode").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("Inactive").Width = 120
                    .Columns("Inactive").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "{0} Records"
                    .BestFitColumns()
                End With
            Else
                gcData.DataSource = Nothing
                gvData.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bbiPRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRefresh.ItemClick
        LoadDataToList()
    End Sub

    'Private Sub InitPageRefresh()
    '    If PageRefresh = "frmStockCarts" Then
    '        frmStockCarts.InitShelf()
    '        'ElseIf PageRefresh = "frmMembershipServicePkg" Then
    '        '    frmMembershipServicePkg.InitMembershipType()
    '    End If
    'End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtShelfEn.Text.Trim) Then
            XtraMessageBox.Show("Please enter shelf name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtShelfEn.Focus()
            Return
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveShelf", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", ID)
                .AddWithValue("@ClinicID", CInt(lueClinic.EditValue))
                .AddWithValue("@En", txtShelfEn.Text.Trim)
                .AddWithValue("@Kh", txtShelfKh.Text.Trim)
                .AddWithValue("@Note", meNote.Text.Trim)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            If IsAdd > 0 Then
                MMS = MessageBoxIcon.Information
                EnabledEdit(False)
                EnabledButtonSave("Save", False, True)
                btnNew.Enabled = True
            Else
                EnabledEdit()
                EnabledButtonSave()
                btnNew.Enabled = False
            End If

            LoadDataToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Shelf Name", MessageBoxButtons.OK, MMS)
            btnNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        txtShelfEn.ReadOnly = Not en
        txtShelfKh.ReadOnly = Not en
        meNote.ReadOnly = Not en
    End Sub

    Private Sub ClearAllContent()
        ID = 0
        txtCode.Text = "***"
        txtShelfEn.Text = ""
        txtShelfKh.Text = ""
        meNote.Text = ""
        If Not IsNothing(ConfigClinic) Then
            lueClinic.EditValue = ConfigClinic.ClinicID
        Else
            lueClinic.EditValue = -1
        End If
        EnabledButtonSave()
    End Sub

    Private Sub LoadClinic()
        Try
            GetDataToComboBoxWithParam(lueClinic, "SA_GetClinicByID", "ClinicID", "ClinicEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
            If Not IsNothing(ConfigClinic) Then
                lueClinic.EditValue = ConfigClinic.ClinicID
            Else
                lueClinic.EditValue = -1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        LoadDataToList()
        EnabledEdit()
        btnNew.Enabled = False
        lueClinic.Focus()
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ShelfCode").ToString)
                GetSearchDataByID(_ID)
            End With
        Catch ex As Exception
            ClearAllContent()
            lueClinic.Focus()
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub GetSearchDataByID(Optional Find_ID As Integer = 0, Optional ByVal _ClinicID As Integer = 0, Optional ByVal _Flag As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetShelfByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@ClinicID", _ClinicID), New SqlParameter("@isList", _Flag))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True, True)
                    EnabledEdit()
                    btnNew.Enabled = True
                    txtCode.Text = .Rows(0)("ShelfCode").ToString
                    ID = CInt(.Rows(0)("ShelfCode"))
                    txtShelfEn.Text = .Rows(0)("ShelfEn").ToString
                    txtShelfKh.Text = .Rows(0)("ShelfKh").ToString
                    If CInt(.Rows(0)("ClinicID")) <> 0 Then
                        lueClinic.EditValue = CInt(.Rows(0)("ClinicID"))
                    Else
                        lueClinic.EditValue = -1
                    End If

                    meNote.Text = .Rows(0)("Note").ToString
                    lueClinic.Focus()
                Else
                    ClearAllContent()
                    LoadDataToList()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to restore the selected shelf?", "Confirm Message?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ShelfCode").ToString)
                DisabledItems(_ID.ToString, 1)
            End With
        Catch ex As Exception
            ClearAllContent()
            lueClinic.Focus()
        End Try
    End Sub

    Private Sub DisabledItems(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisabledShelf", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@Inactive", _Inactive)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error
            ClearAllContent()
            btnNew.Enabled = False
            LoadDataToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm Message", MessageBoxButtons.OK, MMS)
            lueClinic.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                detected = XtraMessageBox.Show("Do you want to restore the selected shelf?", "Confirm Message?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ShelfCode").ToString)
                DisabledItems(_ID.ToString)
            End With
        Catch ex As Exception
            ClearAllContent()
            lueClinic.Focus()
        End Try
    End Sub

    Private Sub bbiPExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExport.ItemClick
        ExportToXlsx(dtData, "Shelf Report")
    End Sub

    Private Sub frmViewShelf_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'InitPageRefresh()
        Dispose()
    End Sub
End Class