Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmHolidayList
    Private Sub frmHoldayList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadHolidayToList(_SearchOption, _SDateFrom.ToString, _SDateTo.ToString)
    End Sub

    Public Sub LoadHolidayToList(Choose As Integer, DateFrom As String, DateTo As String)
        Try
            Dim Holidays As DataTable = GetDataFromDBToTable("SA_GetHolidayCalendarToList",
                                                                    New SqlParameter("@id", Choose),
                                                                    New SqlParameter("@id2", DateFrom),
                                                                    New SqlParameter("@id3", DateTo))
            If Holidays.Rows.Count > 0 Then
                gcHolidays.DataSource = Holidays
                With gvHolidays
                    .PopulateColumns()
                    .Columns("ID").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    '.Columns("ID").Width = 50
                    .Columns("Status").Width = 100
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("EnglishDescription").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("KhmerDescription").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("Status").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Status").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            Else
                gcHolidays.DataSource = Nothing
                gvHolidays.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gcHolidays_MouseClick(sender As Object, e As MouseEventArgs) Handles gcHolidays.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppAddHolidayCalendar.ShowPopup(Me.bmHolidayCalendar, Control.MousePosition)
    End Sub

    Private Sub bbiPSearch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPSearch.ItemClick
        LoadFormDialog(frmSearchHoliday)
    End Sub

    Private Sub bbiPAddHoilday_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAddHoilday.ItemClick
        IsOpenForm = 1
        LoadFormDialog(frmManageHoliday)
    End Sub


    Private Sub bbiPSetCommonLeave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPSetCommonLeave.ItemClick
        Dim SelRows() As Integer = gvHolidays.GetSelectedRows()
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to remove.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim _IDTempList As String = ""
            'Dim HolidayList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim _TempHoliday(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvHolidays.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("ID").ToString()
                    '_TempHoliday(i) = SelectedRow("Holiday").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            'HolidayList = String.Join(",", _TempHoliday)
            'HolidayList = HolidayList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to mark selected holiday as common leave?", "Holiday", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            SetAsCommonLeave(_IDTempList, 1)
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub SetAsCommonLeave(ByVal _StrID As String, Optional _CommonLeave As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SetHolidayAsCommonLeave", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _StrID)
                .AddWithValue("@CommonLeave", _CommonLeave)
                .AddWithValue("@User", AccountName)
                .Add("@IsUpdate", SqlDbType.Int)
                cmd.Parameters("@IsUpdate").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)

            Dim mms As MessageBoxIcon = MessageBoxIcon.Information
            If CInt(cmd.Parameters("@IsUpdate").Value) = 0 Then mms = MessageBoxIcon.Error

            LoadHolidayToList(_SearchOption, _SDateFrom.ToString, _SDateTo.ToString)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm message", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            ErrorLog.WriteLog("SA_SetHolidayAsCommonLeave", ex.Message)
        End Try
    End Sub

    Private Sub bbiRemoveFromCL_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiRemoveFromCL.ItemClick
        Dim SelRows() As Integer = gvHolidays.GetSelectedRows()
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to remove.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim _IDTempList As String = ""
            'Dim HolidayList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim _TempHoliday(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvHolidays.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("ID").ToString()
                    '_TempHoliday(i) = SelectedRow("Holiday").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            'HolidayList = String.Join(",", _TempHoliday)
            'HolidayList = HolidayList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to unmark selected holday from common leave?", "Holiday", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            SetAsCommonLeave(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bbiCopyTo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiCopyTo.ItemClick
        CopyTo()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        IsOpenForm = 1
        LoadFormDialog(frmManageHoliday)
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Modify()
    End Sub

    Private Sub btnCopyTo_Click(sender As Object, e As EventArgs) Handles btnCopyTo.Click
        CopyTo()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Remove()
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Remove()
    End Sub

    Private Sub Remove()
        Try
            Dim SelRows() As Integer = gvHolidays.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to remove.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvHolidays.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("ID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove the selected holiday?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisabledHoliday", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@Inactive", 1)
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
            LoadHolidayToList(_SearchOption, _SDateFrom.ToString, _SDateTo.ToString)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Holiday", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPCopyTo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPCopyTo.ItemClick
        CopyTo()
    End Sub

    Private Sub CopyTo()
        Try
            Dim SelRows() As Integer = gvHolidays.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to preview.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvHolidays.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("ID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub

            _IDTempList = String.Join(",", _TempID)
            frmCopyHolidayTo._IDList = _IDTempList.TrimEnd(MyChar)
            frmCopyHolidayTo._SelNum = i
            LoadFormDialog(frmCopyHolidayTo)
            'If IsOpenForm = 0 Then Exit Sub
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        Modify()
    End Sub

    Private Sub Modify()
        Dim SelRows As Integer() = gvHolidays.GetSelectedRows()
        Dim i = 0
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to preview.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            For Each index As Integer In SelRows
                If (index >= 0) Then i += 1
            Next

            If i > 1 Then
                XtraMessageBox.Show("You cannot select multiple records to preview at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i = 1 Then
                IsOpenForm = 2
                HolidayList = New AddHoliday With {.ID = CInt(gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "ID").ToString), .Holiday = CDate(gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "Holiday").ToString)}
                frmManageHoliday.GetSearchHolidayByID(HolidayList.ID, HolidayList.Holiday)
                LoadFormDialog(frmManageHoliday)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bbiPAddNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAddNew.ItemClick
        IsOpenForm = 1
        LoadFormDialog(frmManageHoliday)
    End Sub
End Class