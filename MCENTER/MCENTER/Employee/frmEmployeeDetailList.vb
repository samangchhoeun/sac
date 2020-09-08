Imports System.Data.SqlClient

Public Class frmEmployeeDetailList

    Private Sub gvStaffDetailsList_DoubleClick(sender As Object, e As EventArgs) Handles gvStaffDetailsList.DoubleClick
        Try
            tempCardID = gvStaffDetailsList.GetRowCellValue(gvStaffDetailsList.FocusedRowHandle, "CardID").ToString
        Catch ex As Exception

        End Try

        If Not String.IsNullOrEmpty(tempCardID) Then
            Dispose()
            'If IsOpenForm = 1 Then
            '    LoadForm(frmEmployeeProfile)
            'ElseIf IsOpenForm = 2 Then
            '    LoadForm(frmEmployeeHistory)
            'ElseIf IsOpenForm = 5 Then
            '    LoadForm(frmEmployeeResign)
            'ElseIf IsOpenForm = 6 Then
            '    LoadForm(frmEmploymentContract)
            'End If
        End If
    End Sub

    Private Sub frmStaffList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tempCardID = ""
        LoadDataToTable()
    End Sub

    Private Sub LoadDataToTable()
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetStaffDetailByIDToList", New SqlParameter("@ID", ""))
            gcStaffDetailsList.DataSource = dt
            With gvStaffDetailsList
                .PopulateColumns()
                .Columns("CardID").Width = 50
                .Columns("CardID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("CardID").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Sex").Width = 30
                .Columns("Sex").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Sex").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("JoinDate").Width = 90
                .Columns("JoinDate").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("JoinDate").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("EmpStatus").Width = 60
                .Columns("EmpStatus").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("EmpStatus").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Department").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                .Columns("Department").SummaryItem.DisplayFormat = "Total: {0} Records"
                '.Columns("Campus").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                '.Columns("Campus").SummaryItem.DisplayFormat = "Total: {0} Records"
                '.BestFitColumns()
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class