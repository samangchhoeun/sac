Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmLabMasterList
    Public listType As String = ""
    Dim _TempID As Integer = 0
    Dim dtData As New DataTable

    Private Sub frmLabMasterList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub frmLabMasterList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(listType) Then Text = listType
        If listType = "LabUnit" Then
            lciEn.Text = "Lab Unit"
            lciKh.Text = "ខ្នាត"
        ElseIf listType = "LabSection" Then
            lciEn.Text = "Lab Section"
            lciKh.Text = "ផ្នែក"
        ElseIf listType = "Laboratory" Then
            lciEn.Text = "Laboratory"
            lciKh.Text = "មន្ទីរពិសោធន៍"
        ElseIf listType = "GroupTest" Then
            lciEn.Text = "Group​ Test"
            lciKh.Text = "ក្រុមតេស្ត"
        End If
        LoadDataToList()
    End Sub

    Public Sub LoadDataToList(Optional ByVal Find_ID As Integer = 0, Optional ByVal _Flag As Integer = 0)
        Try
            If listType = "LabUnit" Then
                dtData = GetDataFromDBToTable("SA_GetLabUnitByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            ElseIf listType = "LabSection" Then
                dtData = GetDataFromDBToTable("SA_GetLabSectionByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            ElseIf listType = "Laboratory" Then
                dtData = GetDataFromDBToTable("SA_GetLabByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            ElseIf listType = "GroupTest" Then
                dtData = GetDataFromDBToTable("SA_GetGroupTestByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            End If

            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .Columns("TranID").Visible = False
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

    Public Sub GetSearchDataByID(Find_ID As Integer, Optional ByVal _Flag As Integer = 0)
        Try
            Dim dtData As New DataTable
            If listType = "LabUnit" Then
                dtData = GetDataFromDBToTable("SA_GetLabUnitByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            ElseIf listType = "LabSection" Then
                dtData = GetDataFromDBToTable("SA_GetLabSectionByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            ElseIf listType = "Laboratory" Then
                dtData = GetDataFromDBToTable("SA_GetLabByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            ElseIf listType = "GroupTest" Then
                dtData = GetDataFromDBToTable("SA_GetGroupTestByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@isList", _Flag))
            End If

            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True, True)
                    EnabledEdit()
                    btnNew.Enabled = True
                    txtCode.Text = .Rows(0)("TranID").ToString
                    _TempID = CInt(.Rows(0)("TranID"))
                    If listType = "LabUnit" Then
                        txtEn.Text = .Rows(0)("UnitEn").ToString
                        txtKh.Text = .Rows(0)("UnitKh").ToString
                    ElseIf listType = "LabSection" Then
                        txtEn.Text = .Rows(0)("SectionEn").ToString
                        txtKh.Text = .Rows(0)("SectionEn").ToString
                    ElseIf listType = "Laboratory" Then
                        txtEn.Text = .Rows(0)("LabEn").ToString
                        txtKh.Text = .Rows(0)("LabKh").ToString
                    ElseIf listType = "GroupTest" Then
                        txtEn.Text = .Rows(0)("GroupEn").ToString
                        txtKh.Text = .Rows(0)("GroupKh").ToString
                    End If

                    txtEn.Focus()
                Else
                    ClearAllContent()
                    LoadDataToList()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = MouseButtons.Right Then pmMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtEn.Text.Trim) Then
            XtraMessageBox.Show("Please enter " + listType + " information.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEn.Focus()
            Return
        End If

        Try
            Dim SP As String = ""
            If listType = "LabUnit" Then
                SP = "SA_SaveLabUnit"
            ElseIf listType = "LabSection" Then
                SP = "SA_SaveLabSection"
            ElseIf listType = "Laboratory" Then
                SP = "SA_SaveLab"
            ElseIf listType = "GroupTest" Then
                SP = "SA_SaveGroupTest"
            End If
            If Not String.IsNullOrEmpty(SP) Then
                OpenCon(Con)
                Dim cmd As New SqlCommand(SP, Con)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@ID", _TempID)
                    .AddWithValue("@FullWordEn", txtEn.Text.Trim)
                    .AddWithValue("@FullWordKh", txtKh.Text.Trim)
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
                XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Master Item", MessageBoxButtons.OK, MMS)
            Else
                XtraMessageBox.Show("There is no delected request to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            btnNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub EnabledEdit(Optional en As Boolean = True)
        txtEn.ReadOnly = Not en
        txtKh.ReadOnly = Not en
    End Sub

    Private Sub ClearAllContent()
        _TempID = 0
        txtCode.Text = "***"
        txtEn.Text = ""
        txtKh.Text = ""
        EnabledButtonSave()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub bbiPExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExport.ItemClick
        ExportToXlsx(dtData, lciEn.Text.Trim + " Report")
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        LoadDataToList()
        EnabledEdit()
        btnNew.Enabled = False
        txtEn.Focus()
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to remove the selected records?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "DiagnosisCode").ToString)
                DisabledItems(_ID.ToString, 1)
            End With
        Catch ex As Exception
            ClearAllContent()
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEn.Focus()
        End Try

        'Try
        '    Dim SelRows() As Integer = gvData.GetSelectedRows()
        '    If SelRows.Count <= 0 Then
        '        XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    End If

        '    Dim _IDTempList As String = ""
        '    Dim _TempID(SelRows.Count) As String
        '    Dim i As Integer = 0
        '    Dim MyChar() As Char = {","c, " "c, "|"c}
        '    For Each index As Integer In SelRows
        '        If index >= 0 Then
        '            Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
        '            _TempID(i) = SelectedRow("TranID").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to remove the selected records?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList, 1)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to restore the selected records?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "TranID").ToString)
                DisabledItems(_ID.ToString)
            End With
        Catch ex As Exception
            ClearAllContent()
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEn.Focus()
        End Try

        'Try
        '    Dim SelRows() As Integer = gvData.GetSelectedRows()
        '    If SelRows.Count <= 0 Then
        '        XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    End If

        '    Dim _IDTempList As String = ""
        '    Dim _TempID(SelRows.Count) As String
        '    Dim i As Integer = 0
        '    Dim MyChar() As Char = {","c, " "c, "|"c}
        '    For Each index As Integer In SelRows
        '        If index >= 0 Then
        '            Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
        '            _TempID(i) = SelectedRow("TranID").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to restore the selected records?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    DisabledItems(_IDTempList)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub DisabledItems(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0)
        Try
            Dim SP As String = ""
            If listType = "LabUnit" Then
                SP = "SA_DisabledLabUnit"
            ElseIf listType = "LabSection" Then
                SP = "SA_DisabledLabSection"
            ElseIf listType = "Laboratory" Then
                SP = "SA_DisabledLab"
            ElseIf listType = "GroupTest" Then
                SP = "SA_DisabledGroupTest"
            End If
            If Not String.IsNullOrEmpty(SP) Then
                OpenCon(Con)
                Dim cmd As New SqlCommand(SP, Con)
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
            Else
                XtraMessageBox.Show("There is no delected request to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            txtEn.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Try
            With gvData
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "TranID").ToString)
                GetSearchDataByID(_ID)
            End With
        Catch ex As Exception
            ClearAllContent()
            txtEn.Focus()
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        'Try
        '    Dim SelRows As Integer() = gvData.GetSelectedRows()
        '    Dim i = 0
        '    For Each index As Integer In SelRows
        '        If (index >= 0) Then i += 1
        '    Next
        '    If SelRows.Count <= 0 Then
        '        XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    ElseIf i > 1 Then
        '        XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    ElseIf i = 1 Then
        '        Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(SelRows(0)), DataRowView)
        '        GetSearchDataByID(CInt(SelectedRow("TranID")))
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub
End Class