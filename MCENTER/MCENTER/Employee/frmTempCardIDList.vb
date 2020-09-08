Imports System.Data.SqlClient

Public Class frmTempCardIDList

    Private Sub frmTempCardIDList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable = GetDataFromDBToTable("SA_GetTempCardIDList", New SqlParameter("@id", ""))
        gcTempIDList.DataSource = dt
        gvTempIDList.Columns("TempID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        gvTempIDList.Columns("TempID").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    End Sub

    Private Sub gvTempIDList_DoubleClick(sender As Object, e As EventArgs) Handles gvTempIDList.DoubleClick
        tempID = gvTempIDList.GetRowCellValue(gvTempIDList.FocusedRowHandle, "TempID").ToString
        If Not String.IsNullOrEmpty(tempID) Then
            Hide()
            LoadForm(frmEmployee)
        End If
    End Sub
End Class