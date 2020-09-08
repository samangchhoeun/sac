Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmViewSupplier
    Dim _ID As Integer = 0
    Dim dtData As New DataTable
    Public PageRefresh As String = ""

    Private Sub frmViewSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataToList()
    End Sub

    Public Sub LoadDataToList(Optional ByVal _ID As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_GetSuppliersByID", New SqlParameter("@ID", _ID), New SqlParameter("@isList", 0))
            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .Columns("CompanyID").Visible = False
                    .Columns("Notes").Visible = False
                    .Columns("Website").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
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

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = MouseButtons.Right Then ppMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub bbiPRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRefresh.ItemClick
        LoadDataToList()
    End Sub

    Private Sub bbiPExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExport.ItemClick
        ExportToXlsx(dtData, "Supplier Report")
    End Sub

    Private Sub bbnClose_Click(sender As Object, e As EventArgs) Handles bbnClose.Click
        Dispose()
    End Sub

    Private Sub frmViewSupplier_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        InitPageRefresh()
        Dispose()
    End Sub

    Private Sub InitPageRefresh()
        If PageRefresh = "frmMedicationStockIn" Then
            frmMedicationStockIn.InitSuppliers()
            'ElseIf PageRefresh = "frmMembershipServicePkg" Then
            '    frmMembershipServicePkg.InitMembershipType()
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContents()
        LoadDataToList()
        EnabledEdit()
        btnNew.Enabled = False
        txtCompanyName.Focus()
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        txtCompanyName.ReadOnly = Not en
        txtCompanyCode.ReadOnly = Not en
        txtCellPhone.ReadOnly = Not en
        txtEmail.ReadOnly = Not en
        txtOfficePhone.ReadOnly = Not en
        txtWebsite.ReadOnly = Not en
        txtContactPerson.ReadOnly = Not en
        txtContactEmail.ReadOnly = Not en
        meAddress.ReadOnly = Not en
        meNote.ReadOnly = Not en
    End Sub

    Private Sub ClearAllContents()
        _ID = 0
        txtCode.Text = "***"
        txtCompanyName.Text = ""
        txtCompanyCode.Text = ""
        txtCellPhone.Text = ""
        txtEmail.Text = ""
        txtOfficePhone.Text = ""
        txtWebsite.Text = ""
        txtContactPerson.Text = ""
        txtContactEmail.Text = ""
        meAddress.Text = ""
        meNote.Text = ""
        EnabledButtonSave()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            Dim SelRows As Integer() = gvData.GetSelectedRows()
            Dim i = 0
            For Each index As Integer In SelRows
                If (index >= 0) Then i += 1
            Next
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i > 1 Then
                XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i = 1 Then
                Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(SelRows(0)), DataRowView)
                GetSearchDataByID(CInt(SelectedRow("CompanyID")))
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub GetSearchDataByID(Find_ID As Integer)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetSuppliersByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", 0))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledEdit()
                    EnabledButtonSave("&Update", True, True)
                    btnNew.Enabled = True
                    txtCode.Text = .Rows(0)("CompanyID").ToString
                    _ID = CInt(.Rows(0)("CompanyID"))
                    txtCompanyName.Text = .Rows(0)("Company").ToString
                    txtCompanyCode.Text = .Rows(0)("CompanyCode").ToString
                    txtOfficePhone.Text = .Rows(0)("OfficePhone").ToString
                    txtWebsite.Text = .Rows(0)("Website").ToString
                    txtEmail.Text = .Rows(0)("Email").ToString
                    meAddress.Text = .Rows(0)("Address").ToString
                    txtContactPerson.Text = .Rows(0)("ContactPerson").ToString
                    txtCellPhone.Text = .Rows(0)("CellPhone").ToString
                    txtContactEmail.Text = .Rows(0)("ContactEmail").ToString
                    meNote.Text = .Rows(0)("Notes").ToString
                    txtCompanyName.Focus()
                Else
                    ClearAllContents()
                    LoadDataToList()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtCompanyName.Text.Trim) OrElse String.IsNullOrEmpty(txtOfficePhone.Text.Trim) Then
            XtraMessageBox.Show("Please enter company name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCompanyName.Focus()
            Return
        ElseIf String.IsNullOrEmpty(txtContactPerson.Text.Trim) OrElse String.IsNullOrEmpty(txtCellPhone.Text.Trim) Then
            XtraMessageBox.Show("Please enter contact person name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtContactPerson.Focus()
            Return
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveSupplier", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _ID)
                .AddWithValue("@Company", txtCompanyName.Text.Trim)
                .AddWithValue("@CompanyCode", txtCompanyCode.Text.Trim)
                .AddWithValue("@OfficePhone", txtOfficePhone.Text.Trim)
                .AddWithValue("@Webiste", txtWebsite.Text.Trim)
                .AddWithValue("@Email", txtEmail.Text.Trim)
                .AddWithValue("@Address", meAddress.Text.Trim)
                .AddWithValue("@ContactPerson", txtContactPerson.Text.Trim)
                .AddWithValue("@CellPhone", txtCellPhone.Text.Trim)
                .AddWithValue("@ContactEmail", txtContactEmail.Text.Trim)
                .AddWithValue("@Notes", txtContactEmail.Text.Trim)
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
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Supplier", MessageBoxButtons.OK, MMS)
            btnNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            Dim SelRows() As Integer = gvData.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("CompanyID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove the selected suplliers?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledItems(_IDTempList, 1)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisabledItems(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisabledSuppliers", Con)
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
            ClearAllContents()
            btnNew.Enabled = False
            LoadDataToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm Message", MessageBoxButtons.OK, MMS)
            txtCompanyName.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        Try
            Dim SelRows() As Integer = gvData.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("CompanyID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to restore the selected suplliers?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledItems(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class