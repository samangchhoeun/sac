Imports System.Data.SqlClient

Public Class frmHolidayCalendar

    Private Sub frmHolidayCalendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDBConnection()
        deSStartDate.DateTime = DateTime.Now
        'deSEndDate.DateTime = DateTime.Now
        '' deSStartDate.DateTime = New DateTime(Now.Year, 1, 1)
        deSEndDate.DateTime = New DateTime(Now.Year, 12, 31)
        deHoliday.DateTime = DateTime.Now
        LoadHolidayToList(rgHoliday.EditValue.ToString, deSStartDate.EditValue.ToString, deSEndDate.EditValue.ToString)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'MessageBox.Show(SDate + "=" + EDate)
        LoadHolidayToList(rgHoliday.EditValue.ToString, deSStartDate.EditValue.ToString, deSEndDate.EditValue.ToString)
    End Sub

    Private Sub rgHoliday_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rgHoliday.SelectedIndexChanged
        EnabledHoliday(CInt(rgHoliday.EditValue))
    End Sub

    Private Sub EnabledHoliday(Optional En As Integer = 0)
        deSStartDate.DateTime = DateTime.Now
        deSEndDate.DateTime = DateTime.Now
        deSStartDate.Enabled = False
        deSEndDate.Enabled = False
        If En = 0 Then
            deSStartDate.Enabled = True
            deSEndDate.Enabled = True
            deSStartDate.Focus()
        ElseIf En = 1 Then
            deSEndDate.DateTime = New DateTime(Now.Year, 12, 31)
            btnSearch.Focus()
        End If
    End Sub

    Private Sub LoadHolidayToList(Choose As String, DateFrom As String, DateTo As String)
        Dim Holidays As DataTable = GetDataFromDBToTable("SA_GetHolidayCalendarToList", New SqlParameter("@id", Choose), New SqlParameter("@id2", DateFrom), New SqlParameter("@id3", DateTo))

        If Holidays.Rows.Count > 0 Then
            gcHolidays.DataSource = Holidays
            gvHolidays.PopulateColumns()
            gvHolidays.Columns("ID").OptionsColumn.FixedWidth = True
            gvHolidays.Columns("ID").Width = 50
            gvHolidays.Columns("ID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            gvHolidays.Columns("ID").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            'gvHolidays.Columns("ID").Visible = False
            gvHolidays.Columns("UserCreate").Visible = False
            gvHolidays.Columns("DateCreate").Visible = False
            gvHolidays.Columns("UserUpdate").Visible = False
            gvHolidays.Columns("DateUpdate").Visible = False
            gvHolidays.BestFitColumns()
        Else
            gcHolidays.DataSource = Nothing
            gvHolidays.Columns.Clear()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(meEnDescription.Text.Trim) Then
            MessageBox.Show("Please select staff to perform this action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            meEnDescription.Focus()
            Return
        End If

        Dim Days As Integer = 1

        Try
            If Not String.IsNullOrEmpty(txtNumHolidays.Text.Trim) Then
                Days = CInt(txtNumHolidays.Text.Trim)
            End If
        Catch ex As Exception
            Return
        End Try

        Try
            rgHoliday.EditValue = 2
            Dim Holiday As Object = deHoliday.DateTime

            For i As Integer = 1 To Days
                Dim NewInsertID As Integer = GetNewRecordID("SA_GetNewHolidayID")
                If txtNumber.Text <> "***" Then
                    NewInsertID = CInt(txtNumber.Text.Trim)
                End If

                OpenCon(Con)
                Dim cmd As New SqlCommand("SA_SavePublicHoliday", Con)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@ID", NewInsertID)
                    .AddWithValue("@Holiday", Holiday)
                    .AddWithValue("@EnDes", meEnDescription.Text.Trim)
                    .AddWithValue("@KhDes", meKhDescription.Text.Trim)
                    .AddWithValue("@UserCreate", AccountName)
                    .AddWithValue("@UserUpdate", AccountName)
                    .Add("@IsAdd", SqlDbType.Int)
                    cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                    .Add("@Msg", SqlDbType.NVarChar, 200)
                    cmd.Parameters("@Msg").Direction = ParameterDirection.Output
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                'MessageBox.Show(Holiday.ToString)
                Holiday = deHoliday.DateTime.AddDays(i)

                EnabledEdit()

                If i = Days Then
                    Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
                    Dim IsChanged As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)

                    rgHoliday.SelectedIndex = 2
                    If IsChanged <> 0 Then
                        EnabledButtonSave("&Update", False)
                        EnabledEdit(False)
                        btnNew.Enabled = True
                    Else
                        deHoliday.Focus()
                        MMS = MessageBoxIcon.Error
                    End If

                    LoadHolidayToList(rgHoliday.EditValue.ToString, deSStartDate.EditValue.ToString, deSEndDate.EditValue.ToString)
                    MessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Holiday", MessageBoxButtons.OK, MMS)
                    deHoliday.Focus()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Holiday", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        CloseCon(Con)
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional val As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
        btnTrush.Enabled = val
    End Sub

    Private Sub txtNumHolidays_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumHolidays.KeyPress
        ValidNumber(sender, e)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearIfNewContent()
        EnabledEdit()
        deHoliday.Focus()
    End Sub

    Private Sub ClearIfNewContent()
        'deHoliday.DateTime = DateTime.Now
        meEnDescription.Text = ""
        meKhDescription.Text = ""
        txtNumHolidays.Text = ""
        txtNumber.Text = "***"
        txtNumHolidays.Enabled = True
        EnabledButtonSave()
        ShowUpdateFooterNote(False)
        ShowAddFooterNote(False)
    End Sub

    Private Sub ClearAllContent()
        rgHoliday.SelectedIndex = 0
        gcHolidays.DataSource = Nothing
        gvHolidays.Columns.Clear()
        ClearIfNewContent()
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAllContent()
        deSStartDate.Focus()
    End Sub

    Private Sub gcHolidays_DoubleClick(sender As Object, e As EventArgs) Handles gcHolidays.DoubleClick
        Try
            txtNumber.Text = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "ID").ToString
            deHoliday.EditValue = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "Holiday").ToString
            meEnDescription.Text = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "EnglishDescription").ToString
            meKhDescription.Text = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "KhmerDescription").ToString

            Dim UserCreate As String = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "UserCreate").ToString
            Dim DateCreate As String = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "DateCreate").ToString
            Dim UserUpdate As String = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "UserUpdate").ToString
            Dim DateUpdate As String = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "DateUpdate").ToString

            getFooterNote(UserCreate, DateCreate, UserUpdate, DateUpdate)
            txtNumHolidays.Enabled = False
            EnabledButtonSave("&Update", True, True)
        Catch ex As Exception
            ClearAllContent()
            txtNumHolidays.Enabled = False
            EnabledButtonSave()
            deHoliday.Focus()
        End Try
    End Sub

    Private Sub EnabledEdit(Optional en As Boolean = True)
        deHoliday.Enabled = en
        txtNumHolidays.Enabled = en
        meEnDescription.Enabled = en
        meKhDescription.Enabled = en

    End Sub

    Private Sub gcHolidays_MouseClick(sender As Object, e As MouseEventArgs) Handles gcHolidays.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            'ppAddHolidayCalendar.ShowPopup(e.Location)
            ppAddHolidayCalendar.ShowPopup(Me.bmHolidayCalendar, Control.MousePosition)
        End If
    End Sub

    Private Sub bbiPAddHoilday_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAddHoilday.ItemClick
        MessageBox.Show("Add")
    End Sub

    Private Sub bbiPEditHoliday_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPEditHoliday.ItemClick


        'Try
        '    txtNumber.Text = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "ID").ToString
        '    deHoliday.EditValue = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "Holiday").ToString
        '    meEnDescription.Text = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "EnglishDescription").ToString
        '    meKhDescription.Text = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "KhmerDescription").ToString

        '    Dim UserCreate As String = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "UserCreate").ToString
        '    Dim DateCreate As String = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "DateCreate").ToString
        '    Dim UserUpdate As String = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "UserUpdate").ToString
        '    Dim DateUpdate As String = gvHolidays.GetRowCellValue(gvHolidays.FocusedRowHandle, "DateUpdate").ToString

        '    getFooterNote(UserCreate, DateCreate, UserUpdate, DateUpdate)
        '    txtNumHolidays.Enabled = False
        '    EnabledButtonSave("&Update", True, True)
        'Catch ex As Exception
        '    ClearAllContent()
        '    txtNumHolidays.Enabled = False
        '    EnabledButtonSave()
        '    deHoliday.Focus()
        'End Try
    End Sub

    Private Sub bbiPRemoveHoliday_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemoveHoliday.ItemClick
        MessageBox.Show("Remove")
    End Sub
End Class