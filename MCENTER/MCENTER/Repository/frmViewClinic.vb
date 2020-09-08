Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmViewClinic
    Dim _ID As Integer = 0
    Dim dtData As New DataTable
    Public PageRefresh As String = ""

    Private Sub InitPageRefresh()
        If PageRefresh = "frmViewMembershipFee" Then
            frmViewMembershipFee.LoadClinic()
        ElseIf PageRefresh = "frmViewMedicalTreatment" Then
            frmViewMedicalTreatment.LoadClinic()
        End If
    End Sub

    Private Sub frmViewClinic_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        InitPageRefresh()
        Dispose()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs)
        ClearAllContents()
        LoadDataToList()
        btnNew.Enabled = False
        lueCampus.Focus()
    End Sub

    Private Sub ClearAllContents()
        _ID = 0
        txtCode.Text = "***"
        lueCampus.EditValue = -1
        txtClinicEn.Text = ""
        txtABB.Text = ""
        txtClinicKh.Text = ""
        EnabledButtonSave()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
        btnRemove.Enabled = del
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = MouseButtons.Right Then pmMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub frmViewClinic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCampus()
        LoadDataToList()
    End Sub

    Private Sub LoadCampus()
        Try
            GetDataToComboBoxWithParam(lueCampus, "SA_GetCampusByID", "CampusID", "ABBR", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadDataToList(Optional ByVal Find_ID As Integer = 0, Optional ByVal _Flag As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_GetClinicByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .Columns("ClinicID").Visible = False
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
                GetSearchDataByID(CInt(SelectedRow("ClinicID")))
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub GetSearchDataByID(Find_ID As Integer, Optional ByVal _Flag As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetClinicByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True, True)
                    btnNew.Enabled = True
                    EnabledEdit()
                    txtCode.Text = .Rows(0)("ClinicID").ToString
                    _ID = CInt(.Rows(0)("ClinicID"))
                    If CInt(.Rows(0)("CampusID")) > 0 Then
                        lueCampus.EditValue = CInt(.Rows(0)("CampusID"))
                    Else
                        lueCampus.EditValue = -1
                    End If
                    txtClinicEn.Text = .Rows(0)("ClinicEn").ToString
                    txtClinicKh.Text = .Rows(0)("ClinicKh").ToString
                    txtABB.Text = .Rows(0)("ABB").ToString
                    lueCampus.Focus()
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
        If CInt(lueCampus.EditValue) <= 0 Then
            XtraMessageBox.Show("Please select campus.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lueCampus.Focus()
            Return
        ElseIf String.IsNullOrEmpty(txtABB.Text.Trim) Or String.IsNullOrEmpty(txtClinicEn.Text.Trim) Then
            XtraMessageBox.Show("Please enter clinic name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClinicEn.Focus()
            Return
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveClinic", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _ID)
                .AddWithValue("@CampusID", CInt(lueCampus.EditValue))
                .AddWithValue("@ClinicEn", txtClinicEn.Text.Trim)
                .AddWithValue("@ClinicKh", txtClinicKh.Text.Trim)
                .AddWithValue("@ABB", txtABB.Text.Trim)
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
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Clinic", MessageBoxButtons.OK, MMS)
            btnNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click_1(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContents()
        LoadDataToList()
        EnabledEdit()
        btnNew.Enabled = False
        lueCampus.Focus()
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        txtClinicEn.ReadOnly = Not en
        lueCampus.ReadOnly = Not en
        txtABB.ReadOnly = Not en
        txtClinicKh.ReadOnly = Not en
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
                    _TempID(i) = SelectedRow("ClinicID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove the selected clinics?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledItems(_IDTempList, 1)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisabledItems(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisabledClinics", Con)
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
            lueCampus.Focus()
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
                    _TempID(i) = SelectedRow("ClinicID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to restore the selected clinic?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledItems(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If _ID = 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvData.Focus()
                Return
            End If
            detected = XtraMessageBox.Show("Do you want to remove clinic: " + txtABB.Text.Trim + "?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledItems(_ID.ToString, 1)
            'ClearAllContents()
            'btnNew.Enabled = False
            'txtClient.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        InitPageRefresh()
        Dispose()
    End Sub

    Private Sub bbiPExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExport.ItemClick
        ExportToXlsx(dtData, "Clinic Report")
    End Sub

    Private Sub lueDxGroup_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueCampus.Closed
        txtClinicEn.Focus()
    End Sub
End Class