Imports DevExpress.XtraEditors

Public Class frmSearchHoliday


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

    Private Sub frmSearchHoliday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deSStartDate.DateTime = DateTime.Now
        deSEndDate.DateTime = New DateTime(Now.Year, 12, 31)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Holiday = New SearchHoliday With {.SearchOption = CInt(rgHoliday.EditValue), .HolidayFrom = deSStartDate.EditValue.ToString, .HolidayTo = deSEndDate.EditValue.ToString}
            'Hide()
            'Dispose()
            _SearchOption = CInt(rgHoliday.EditValue.ToString)
            _SDateFrom = CDate(deSStartDate.EditValue)
            _SDateTo = CDate(deSEndDate.EditValue)
            frmHolidayList.LoadHolidayToList(Holiday.SearchOption, Holiday.HolidayFrom, Holiday.HolidayTo)
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub rgHoliday_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles rgHoliday.SelectedIndexChanged
        EnabledHoliday(CInt(rgHoliday.EditValue))
    End Sub

    Private Sub frmSearchHoliday_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class