Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmManageHoliday
    '0: Custome, 1: Current Year, 2: Upcoming

    Private Sub frmManageHoliday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkUpdateAllCurrent.Enabled = False
        btnNew.Enabled = False
        btnSave.Enabled = True

        If IsOpenForm = 2 Then
            chkUpdateAllCurrent.Enabled = True
        Else
            deHoliday.DateTime = DateTime.Now
        End If
        deHoliday.Select()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(meEnDescription.Text.Trim) Then
            XtraMessageBox.Show("Please enter holiday description.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            meEnDescription.Focus()
            Return
        End If

        Dim NumDays As Integer = 1

        Try
            If Not String.IsNullOrEmpty(txtNumHolidays.Text.Trim) Then NumDays = CInt(txtNumHolidays.Text.Trim)
        Catch ex As Exception
            'Return
        End Try

        Try
            If btnSave.Text <> "Remove" Then
                Dim NewInsertID As Integer = 0
                If txtNumber.Text <> "***" Then NewInsertID = CInt(txtNumber.Text.Trim)

                OpenCon(Con)
                Dim cmd As New SqlCommand("SA_SavePublicHolidayNew", Con)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@IsUpdate", chkUpdateAllCurrent.Checked)
                    .AddWithValue("@ID", NewInsertID)
                    .AddWithValue("@Holiday", deHoliday.EditValue)
                    .AddWithValue("@NumDays", NumDays)
                    .AddWithValue("@CommonLeave", chkSetAsCL.Checked)
                    .AddWithValue("@Inactive", chkInActive.Checked)
                    .AddWithValue("@EnDes", meEnDescription.Text.Trim)
                    .AddWithValue("@KhDes", meKhDescription.Text.Trim)
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
                Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
                Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
                If IsAdd = 1 Then
                    EnabledEdit(False)
                    EnabledButtonSave("Save", False)
                    btnNew.Enabled = True
                ElseIf IsAdd > 1 Then
                    EnabledEdit(False)
                    EnabledButtonSave("Save", False)
                Else
                    MMS = MessageBoxIcon.Error
                End If

                frmHolidayList.LoadHolidayToList(_SearchOption, "", "")
                XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Holiday", MessageBoxButtons.OK, MMS)
            Else
                detected = XtraMessageBox.Show("Do you want to remove this holiday?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return

                OpenCon(Con)
                Dim cmd As New SqlCommand("SA_DisabledHoliday", Con)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@StrID", CInt(txtNumber.Text.Trim))
                    .AddWithValue("@Inactive", chkInActive.Checked)
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
                EnabledEdit(False)
                btnSave.Enabled = False
                btnNew.Enabled = False
                If IsAdd > 0 Then
                    ClearIfNewContent()
                Else
                    MMS = MessageBoxIcon.Error
                End If

                btnSave.Enabled = False
                frmHolidayList.LoadHolidayToList(_SearchOption, "", "")
                XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Holiday", MessageBoxButtons.OK, MMS)
            End If

            btnNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Holiday", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub txtNumHolidays_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumHolidays.KeyPress
        ValidNumber(sender, e)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearIfNewContent()
        EnabledEdit()
        deHoliday.Focus()
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        deHoliday.ReadOnly = Not en
        chkInActive.ReadOnly = Not en
        chkUpdateAllCurrent.ReadOnly = Not en
        chkSetAsCL.ReadOnly = Not en
        txtNumHolidays.ReadOnly = Not en
        meEnDescription.ReadOnly = Not en
        meKhDescription.ReadOnly = Not en
    End Sub

    Private Sub ClearIfNewContent()
        'deHoliday.DateTime = DateTime.Now
        meEnDescription.Text = ""
        meKhDescription.Text = ""
        chkInActive.Checked = False
        chkUpdateAllCurrent.Checked = False
        chkSetAsCL.Checked = False
        txtNumHolidays.Text = ""
        txtNumber.Text = "***"
        txtNumHolidays.Enabled = True
        EnabledButtonSave()
    End Sub

    Public Sub GetSearchHolidayByID(Find_ID As Integer, Find_Holiday As Date)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetHolidayCalendarByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@Holiday", Find_Holiday))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True)
                    btnNew.Enabled = True
                    txtNumHolidays.Enabled = False
                    txtNumber.Text = .Rows(0)("ID").ToString
                    chkSetAsCL.Checked = CBool(.Rows(0)("CommonLeave").ToString)
                    deHoliday.EditValue = Convert.ToDateTime(.Rows(0)("Holiday").ToString)
                    meEnDescription.Text = .Rows(0)("EnglishDescription").ToString
                    meKhDescription.Text = .Rows(0)("KhmerDescription").ToString
                    deHoliday.Focus()
                Else
                    ClearIfNewContent()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmManageHoliday_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class