Imports System.Data.SqlClient

Public Class frmReportWorkingHoursList
    Friend dtEmployeeList As New DataTable
    Private Sub frmReportEmployeeWorkingHoursList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'GetDataListReportByEmpID(CampusID, DeptID)
    End Sub

    Public Sub GetDataListReportByEmpID(Optional _Department As Integer = 0, Optional _Division As Integer = 0, Optional _Campus As Integer = 0, Optional _CardID As String = "", Optional _Condition As String = "ALL", Optional _IsAllDate As Boolean = True, Optional _DateFrom As String = "", Optional _DateTo As String = "")
        Try
            dtEmployeeList = GetDataFromDBToTable("SA_GetEmployeeWorkingHoursByFilter",
                                                  New SqlParameter("@CardID", _CardID),
                                                  New SqlParameter("@Condition", _Condition),
                                                  New SqlParameter("@Campus", _Campus),
                                                  New SqlParameter("@Division", _Division),
                                                  New SqlParameter("@Department", _Department),
                                                  New SqlParameter("@IsAllDate", _IsAllDate),
                                                  New SqlParameter("@DateFrom", _DateFrom),
                                                  New SqlParameter("@DateTo", _DateTo))

            gvEmploeeDetails.ViewCaption = GetViewCaption(_DateFrom, _DateTo)
            With gvEmploeeDetails
                If dtEmployeeList.Rows.Count > 0 Then
                    gcEmploeeDetails.DataSource = dtEmployeeList
                    .PopulateColumns()
                    .Columns("StaffNo").Width = 30
                    .Columns("CardID").Width = 40
                    .Columns("Sex").Width = 20
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("TotalWorkingHour").Visible = False
                    .Columns("UIDCard").Visible = False
                    .Columns("Division").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Columns("EffectiveDate").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("EffectiveDate").SummaryItem.DisplayFormat = "Total: {0} Records"
                Else
                    gcEmploeeDetails.DataSource = Nothing
                    .Columns.Clear()
                End If
            End With
        Catch ex As Exception
            'bgLoadingStaffs.CancelAsync()
        End Try
    End Sub

    Private Function GetViewCaption(_DateFrom As String, _DateTo As String) As String
        Dim _Str As String = "Working Hours Bank"
        '_Str += IIf(Not String.IsNullOrEmpty(_BuidlingName), "Building: " + _BuidlingName, "").ToString
        '_Str += ", Date: " + IIf(DateDiff(DateInterval.Day, CDate(_DateFrom), CDate(_DateTo)) = 0, Convert.ToDateTime(_DateFrom).ToString("MMM. dd, yyyy"), Convert.ToDateTime(_DateFrom).ToString("MMM. dd, yyyy") + "-" + Convert.ToDateTime(_DateTo).ToString("MMM. dd, yyyy")).ToString
        Return _Str
    End Function

    Private Sub gcWorkingHours_MouseClick(sender As Object, e As MouseEventArgs) Handles gcEmploeeDetails.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            'ppAddHolidayCalendar.ShowPopup(e.Location)
            ppAddWorkingHours.ShowPopup(Me.bmWorkingHours, Control.MousePosition)
        End If
    End Sub

    Private Sub bbiPAddHoilday_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAddHoilday.ItemClick
        isOpenForm = 1
        Dim frmFullWorkingHour As New frmWorkingHours
        LoadFormDialog(frmFullWorkingHour)
        frmFullWorkingHour.Dispose()
    End Sub

    Private Sub bbiPSearch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPSearch.ItemClick
        LoadFormDialog(frmSearchWorkingHours)
    End Sub

    Private Sub bbiPPreview_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPPreview.ItemClick

    End Sub
End Class