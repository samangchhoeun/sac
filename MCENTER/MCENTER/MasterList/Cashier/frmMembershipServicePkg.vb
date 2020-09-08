Imports System.Data.SqlClient
Imports DevExpress.Utils

Public Class frmMembershipServicePkg
    Dim ID As Integer = 0
    Dim dtData As New DataTable

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = MouseButtons.Right Then pmMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        btnNew.Enabled = False
        btnNew.Focus()
    End Sub

    Private Sub ClearAllContent()
        ID = 0
        lueMembeshipType.EditValue = -1
        txtServiceCode.Text = ""
        lueService.EditValue = -1
        txtNote.Text = ""
        EnabledButtonSave()
    End Sub

    Public Sub InitMembershipType()
        Try
            GetDataToComboBoxWithParam(lueMembeshipType, "SA_GetMembershipTypeByID", "TranID", "MembershipType", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmMembershipServicePkg_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub frmMembershipServicePkg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitMembershipType()
        LoadDataToList()
    End Sub

    Public Sub LoadDataToList(Optional ByVal _ID As Integer = 0)
        Try
            dtData = GetDataFromDBToTable("SA_GetCorporateClientsBaseBalanceByID", New SqlParameter("@ID", _ID))
            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .Columns("CorporateBalCode").Visible = False
                    .Columns("CorporateBalCode").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("BaseBalance").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns("BaseBalance").DisplayFormat.FormatString = "c3"
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("BaseBalance").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("EffectiveDate").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("Inactive").Width = 120
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

    Private Sub btnMembershipType_Click(sender As Object, e As EventArgs) Handles btnMembershipType.Click
        frmViewMembershipType.PageRefresh = "frmMembershipServicePkg"
        LoadFormDialog(frmViewMembershipType)
    End Sub

    Private Sub btnServiceName_Click(sender As Object, e As EventArgs) Handles btnServiceName.Click
        frmViewMembershipType.PageRefresh = "frmMembershipServicePkg"
        LoadFormDialog(frmViewMembershipType)
    End Sub
End Class