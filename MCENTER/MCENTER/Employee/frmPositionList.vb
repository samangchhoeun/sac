Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmPositionList
    Public DeptID As Integer = 0

    Private Sub frmPositionList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDepartmentToList(DeptID)
    End Sub

    Private Sub LoadDepartmentToList(Optional _DeptID As Integer = 0, Optional _TempID As Integer = 0)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetPositionsByID", New SqlParameter("@ID", 0), New SqlParameter("@DeptID", _DeptID))
            With gvData
                If dt.Rows.Count > 0 Then
                    gcData.DataSource = dt
                    .PopulateColumns()
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Columns("PositionID").Visible = False
                    .Columns("DepartmentID").Visible = False
                    .Columns("Remark").Visible = False
                    .Columns("Inactive").Width = 40
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "{0}"
                    .BestFitColumns()
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
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
                frmEmployee.SelectPositionName(CInt(SelectedRow("PositionID")))
                Dispose()
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class