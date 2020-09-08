Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmAccountList
    Dim dtData As New DataTable

    Private Sub frmAccountList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub gcUserLog_MouseClick(sender As Object, e As MouseEventArgs) Handles gcUserLog.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppUserLogMenu.ShowPopup(Me.bmUserLogMenu, Control.MousePosition)
    End Sub

    Private Sub LoadUserLogToTable(Optional _CardID As String = "", Optional _RoleID As Integer = 0, Optional _BlockAcc As Integer = 0, Optional _RestrictPasswordChange As Integer = 0, Optional _RequiredPasswordChange As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_GetUserLogByFilter",
                                                   New SqlParameter("@CardID", _CardID),
                                                   New SqlParameter("@RoleID", _RoleID),
                                                   New SqlParameter("@BlockAcc", _BlockAcc),
                                                   New SqlParameter("@RestrictPasswordChange", _RestrictPasswordChange),
                                                   New SqlParameter("@RequiredPasswordChange", _RequiredPasswordChange),
                                                   New SqlParameter("@KC", SAC))
            If dtData.Rows.Count > 0 Then
                gcUserLog.DataSource = dtData
                With gvUserLog
                    .PopulateColumns()
                    .Columns("ID").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("RoleType").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("UserID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("Position").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("Department").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("RestrictPasswordChange").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("RestrictPasswordChange").SummaryItem.DisplayFormat = "Total: {0} Records"
                    .BestFitColumns()
                End With
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmAccountList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LogRoleID <> 1 AndAlso LogRoleID <> 2 AndAlso Not isLoggedInOwner Then
            bbiPExportTo.Enabled = False
        Else
            bbiPExportTo.Enabled = True
        End If
    End Sub

    Private Sub bbiPRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRefresh.ItemClick
        LoadUserLogToTable()
    End Sub

    Private Sub bbiPExportTo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPExportTo.ItemClick
        ExportToXlsx(dtData, "User Accounts Report")
    End Sub
End Class