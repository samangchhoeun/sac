Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmCambodiaAdminAreas
    Dim CityID As Integer = 0
    Dim KhanID As Integer = 0
    Dim SangkatID As Integer = 0
    Dim VillageID As Integer = 0

    Private Sub frmCambodiaAdminAreas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCityData()
    End Sub

    Public Sub GetCityData(Optional _CityID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetCityList", New SqlParameter("@ID", _CityID), New SqlParameter("@Flag", 1))
            If dtData.Rows.Count > 0 Then
                btnShowKhan.Enabled = True
                gcCity.DataSource = dtData
                With gvCity
                    .PopulateColumns()
                    .Columns("PID").Visible = False
                    '.Columns("PH_Code").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("PH_Code").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Inactive").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "{0}"
                    .BestFitColumns()
                End With
            Else
                gcCity.DataSource = Nothing
                gvCity.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetKhanData(Optional _CityID As Integer = 0, Optional _KhanID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetKhanList", New SqlParameter("@ID", _KhanID), New SqlParameter("@CityID", _CityID), New SqlParameter("@Flag", 1))
            If dtData.Rows.Count > 0 Then
                btnHideKhan.Enabled = True
                btnShowSangkat.Enabled = True
                gcKhan.DataSource = dtData
                With gvKhan
                    .PopulateColumns()
                    .Columns("KhanID").Visible = False
                    .Columns("CityID").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("PostalCode").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Inactive").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "{0}"
                    .BestFitColumns()
                End With
            Else
                txtKhan.Text = ""
                txtKhanKh.Text = ""
                txtKhanPostalCode.Text = ""
                _KhanID = 0
                gcKhan.DataSource = Nothing
                gvKhan.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub GetSangkatData(Optional _KhanID As Integer = 0, Optional _SangkatID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetSangkatList", New SqlParameter("@ID", _SangkatID), New SqlParameter("@KhanID", _KhanID), New SqlParameter("@Flag", 1))
            If dtData.Rows.Count > 0 Then
                btnHideSangkat.Enabled = True
                btnShowVillage.Enabled = True
                gcSangkat.DataSource = dtData
                With gvSangkat
                    .PopulateColumns()
                    .Columns("SangkatID").Visible = False
                    .Columns("KhanID").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("PostalCode").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Inactive").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "{0}"
                    .BestFitColumns()
                End With
            Else
                txtSangkat.Text = ""
                txtSangkatKh.Text = ""
                txtSangkatCode.Text = ""
                _SangkatID = 0
                gcSangkat.DataSource = Nothing
                gvSangkat.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetVillageData(Optional _SangkatID As Integer = 0, Optional _Village As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetVillageList", New SqlParameter("@ID", _Village), New SqlParameter("@SangkatID", _SangkatID), New SqlParameter("@Flag", 1))
            If dtData.Rows.Count > 0 Then
                btnHideVillage.Enabled = True
                gcVillage.DataSource = dtData
                With gvVillage
                    .PopulateColumns()
                    .Columns("VillageID").Visible = False
                    .Columns("SangkatID").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns("Inactive").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Inactive").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("Inactive").SummaryItem.DisplayFormat = "{0}"
                    .BestFitColumns()
                End With
            Else
                txtVillage.Text = ""
                txtVillageKh.Text = ""
                txtVillageCode.Text = ""
                _Village = 0
                gcVillage.DataSource = Nothing
                gvVillage.Columns.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnabledEditCity(Optional En As Boolean = True)
        txtCity.Enabled = En
        txtCityKh.Enabled = En
        txtPhoneCode.Enabled = En
        btnCitySave.Enabled = En
    End Sub

    Private Sub EnabledEditKhan(Optional En As Boolean = True)
        txtKhan.Enabled = En
        txtKhanKh.Enabled = En
        txtKhanPostalCode.Enabled = En
        btnKhanSave.Enabled = En
        'btnShowKhan.Enabled = Not En
        'btnHideKhan.Enabled = En
    End Sub

    Private Sub EnabledEditSangkat(Optional En As Boolean = True)
        txtSangkat.Enabled = En
        txtSangkatKh.Enabled = En
        txtSangkatCode.Enabled = En
        btnSangkatSave.Enabled = En
        'btnShowSangkat.Enabled = Not En
        'btnHideSangkat.Enabled = En
    End Sub

    Private Sub EnabledEditVillage(Optional En As Boolean = True)
        txtVillage.Enabled = En
        txtVillageKh.Enabled = En
        txtVillageCode.Enabled = En
        btnVillageSave.Enabled = En
        'btnShowVillage.Enabled = Not En
        'btnHideVillage.Enabled = En
    End Sub

    Private Sub ClearAllContentCity()
        EnabledEditCity(False)
        gcCity.DataSource = Nothing
        gvCity.Columns.Clear()
        txtCity.Text = ""
        txtCityKh.Text = ""
        txtPhoneCode.Text = ""
        CityID = 0
        btnCitySave.Text = "SAVE"
    End Sub

    Private Sub ClearAllContentKhan()
        EnabledEditKhan(False)
        btnHideKhan.Enabled = False
        gcKhan.DataSource = Nothing
        gvKhan.Columns.Clear()
        txtKhan.Text = ""
        txtKhanKh.Text = ""
        txtKhanPostalCode.Text = ""
        KhanID = 0
        CityID = 0
        btnKhanSave.Text = "SAVE"
    End Sub

    Private Sub ClearAllContentSangkat()
        EnabledEditSangkat(False)
        btnHideSangkat.Enabled = False
        gcSangkat.DataSource = Nothing
        gvSangkat.Columns.Clear()
        txtSangkat.Text = ""
        txtSangkatKh.Text = ""
        txtSangkatCode.Text = ""
        SangkatID = 0
        KhanID = 0
        btnSangkatSave.Text = "SAVE"
    End Sub

    Private Sub ClearAllContentVillage()
        EnabledEditVillage(False)
        btnHideVillage.Enabled = False
        gcVillage.DataSource = Nothing
        gvVillage.Columns.Clear()
        txtVillage.Text = ""
        txtVillageKh.Text = ""
        txtVillageCode.Text = ""
        VillageID = 0
        SangkatID = 0
        btnSangkatSave.Text = "SAVE"
    End Sub

    Private Sub btnHideVillage_Click(sender As Object, e As EventArgs) Handles btnHideVillage.Click
        ClearAllContentVillage()
        gvSangkat.Focus()
    End Sub

    Private Sub btnHideSangkat_Click(sender As Object, e As EventArgs) Handles btnHideSangkat.Click
        ClearAllContentSangkat()
        ClearAllContentVillage()
        btnShowVillage.Enabled = False
        gvKhan.Focus()
    End Sub

    Private Sub btnHideKhan_Click(sender As Object, e As EventArgs) Handles btnHideKhan.Click
        ClearAllContentKhan()
        ClearAllContentSangkat()
        ClearAllContentVillage()
        btnShowSangkat.Enabled = False
        btnShowVillage.Enabled = False
        gvCity.Focus()
    End Sub

    Private Sub btnKhanSave_Click(sender As Object, e As EventArgs) Handles btnKhanSave.Click
        Dim SelRows As Integer() = gvCity.GetSelectedRows()
        Dim i = 0

        Try
            For Each index As Integer In SelRows
                If (index >= 0) Then i += 1
            Next

            'If SelRows.Count <= 0 Then
            If i = 0 Then
                XtraMessageBox.Show("Please select city or province to add new Khan.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvCity.Focus()
                Return
            ElseIf i > 1 Then
                XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvCity.Focus()
                Return
            ElseIf i = 1 AndAlso String.IsNullOrEmpty(txtKhan.Text.Trim) Then
                XtraMessageBox.Show("Please enter khan name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtKhan.Focus()
                Return
            ElseIf i = 1 Then
                CityID = GetSelectedValue(gvCity)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveKhan", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", KhanID)
                .AddWithValue("@CityID", CityID)
                .AddWithValue("@KhanEn", txtKhan.Text.Trim)
                .AddWithValue("@KhanKh", txtKhanKh.Text.Trim)
                .AddWithValue("@Code", txtKhanPostalCode.Text.Trim)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            EnabledEditKhan()
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            If IsAdd > 0 Then
                MMS = MessageBoxIcon.Information
                EnabledEditKhan(False)
            End If

            GetKhanData(CityID)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Khan", MessageBoxButtons.OK, MMS)
            btnShowSangkat.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCitySave_Click(sender As Object, e As EventArgs) Handles btnCitySave.Click
        If String.IsNullOrEmpty(txtCity.Text.Trim) Then
            XtraMessageBox.Show("Please enter city name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCity.Focus()
            Return
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveCity", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", CityID)
                .AddWithValue("@CityEn", txtCity.Text.Trim)
                .AddWithValue("@CityKh", txtCityKh.Text.Trim)
                .AddWithValue("@Code", txtPhoneCode.Text.Trim)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            EnabledEditCity()
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            If IsAdd > 0 Then
                MMS = MessageBoxIcon.Information
                EnabledEditCity(False)
            End If

            GetCityData()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add City", MessageBoxButtons.OK, MMS)
            btnShowKhan.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSangkatSave_Click(sender As Object, e As EventArgs) Handles btnSangkatSave.Click
        Dim SelRows As Integer() = gvKhan.GetSelectedRows()
        Dim i = 0

        Try
            For Each index As Integer In SelRows
                If (index >= 0) Then i += 1
            Next

            'If SelRows.Count <= 0 Then
            If i = 0 Then
                XtraMessageBox.Show("Please select Khan or district to add new Sangkat.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvKhan.Focus()
                Return
            ElseIf i > 1 Then
                XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvKhan.Focus()
                Return
            ElseIf i = 1 AndAlso String.IsNullOrEmpty(txtSangkat.Text.Trim) Then
                XtraMessageBox.Show("Please enter khan name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSangkat.Focus()
                Return
            ElseIf i = 1 Then
                KhanID = GetSelectedValue(gvKhan)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveSangkat", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", SangkatID)
                .AddWithValue("@KhanID", KhanID)
                .AddWithValue("@SangkatEn", txtSangkat.Text.Trim)
                .AddWithValue("@SangkatKh", txtSangkatKh.Text.Trim)
                .AddWithValue("@Code", txtSangkatCode.Text.Trim)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            EnabledEditSangkat()
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            If IsAdd > 0 Then
                MMS = MessageBoxIcon.Information
                EnabledEditSangkat(False)
            End If

            GetSangkatData(KhanID)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Khan", MessageBoxButtons.OK, MMS)
            btnShowSangkat.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVillageSave_Click(sender As Object, e As EventArgs) Handles btnVillageSave.Click
        Dim SelRows As Integer() = gvSangkat.GetSelectedRows()
        Dim i = 0

        Try
            For Each index As Integer In SelRows
                If (index >= 0) Then i += 1
            Next

            'If SelRows.Count <= 0 Then
            If i = 0 Then
                XtraMessageBox.Show("Please select Sangkat or commune to add new Sangkat.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvSangkat.Focus()
                Return
            ElseIf i > 1 Then
                XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvSangkat.Focus()
                Return
            ElseIf i = 1 AndAlso String.IsNullOrEmpty(txtVillage.Text.Trim) Then
                XtraMessageBox.Show("Please enter village name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSangkat.Focus()
                Return
            ElseIf i = 1 Then
                SangkatID = GetSelectedValue(gvSangkat)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveVillage", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", VillageID)
                .AddWithValue("@SangkatID", SangkatID)
                .AddWithValue("@VillageEn", txtVillage.Text.Trim)
                .AddWithValue("@VillageKh", txtVillageKh.Text.Trim)
                .AddWithValue("@Code", txtVillageCode.Text.Trim)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            EnabledEditVillage()
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            If IsAdd > 0 Then
                MMS = MessageBoxIcon.Information
                EnabledEditVillage(False)
            End If

            GetVillageData(SangkatID)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Village", MessageBoxButtons.OK, MMS)
            btnShowSangkat.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnShowKhan_Click(sender As Object, e As EventArgs) Handles btnShowKhan.Click
        ShowItems(gvCity)
        'Dim SelRows As Integer() = gvCity.GetSelectedRows()
        'Try
        '    Dim i = 0
        '    For Each index As Integer In SelRows
        '        If (index >= 0) Then i += 1
        '    Next

        '    If i = 0 Then
        '        XtraMessageBox.Show("Please select city or province to add new Khan.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        gvCity.Focus()
        '        Return
        '    ElseIf i > 1 Then
        '        XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        gvCity.Focus()
        '        Return
        '    ElseIf i = 1 Then
        '        Dim SelectedRow As DataRowView = DirectCast(gvCity.GetRow(SelRows(0)), DataRowView)
        '        GetKhanData(CInt(SelectedRow("PID")))
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Private Sub gcCity_MouseClick(sender As Object, e As MouseEventArgs) Handles gcCity.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppMenuCity.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub bbiPAddNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiAddNew.ItemClick
        EnabledEditCity()
        txtCity.Text = ""
        txtCityKh.Text = ""
        CityID = 0
        btnCitySave.Text = "SAVE"
        txtCity.Select()
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        GetItemtoModify(gvCity)
        'Dim SelRows As Integer() = gvCity.GetSelectedRows()

        'Try
        '    Dim i = 0
        '    For Each index As Integer In SelRows
        '        If (index >= 0) Then i += 1
        '    Next
        '    If i = 0 Then
        '        XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    ElseIf i > 1 Then
        '        XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    ElseIf i = 1 Then
        '        isOpenForm = 2
        '        Dim _ID As Integer = CInt(gvCity.GetRowCellValue(gvCity.FocusedRowHandle, "PID").ToString)
        '        GetCityDataByID(_ID)
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Private Sub GetCityDataByID(Optional _CityID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetCityList", New SqlParameter("@ID", _CityID), New SqlParameter("@Flag", 1))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledEditCity()
                    btnCitySave.Text = "UPDATE"
                    ' btnShowKhan.Enabled = True
                    CityID = CInt(.Rows(0)("PID"))
                    txtCity.Text = .Rows(0)("City").ToString
                    txtCityKh.Text = .Rows(0)("CityKh").ToString
                    txtPhoneCode.Text = .Rows(0)("PH_Code").ToString
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetKhanDataByID(Optional _CityID As Integer = 0, Optional _KhanID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetKhanList", New SqlParameter("@ID", _KhanID), New SqlParameter("@CityID", _CityID), New SqlParameter("@Flag", 1))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledEditKhan()
                    btnKhanSave.Text = "UPDATE"
                    KhanID = CInt(.Rows(0)("KhanID"))
                    CityID = CInt(.Rows(0)("CityID"))
                    txtKhan.Text = .Rows(0)("KhanEn").ToString
                    txtKhanKh.Text = .Rows(0)("KhanKh").ToString
                    txtKhanPostalCode.Text = .Rows(0)("PostalCode").ToString
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetSangkatDataByID(Optional _KhanID As Integer = 0, Optional _SangkatID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetSangkatList", New SqlParameter("@ID", _SangkatID), New SqlParameter("@KhanID", _KhanID), New SqlParameter("@Flag", 1))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledEditSangkat()
                    btnSangkatSave.Text = "UPDATE"
                    SangkatID = CInt(.Rows(0)("SangkatID"))
                    KhanID = CInt(.Rows(0)("KhanID"))
                    txtSangkat.Text = .Rows(0)("SangkatEn").ToString
                    txtSangkatKh.Text = .Rows(0)("SangkatKh").ToString
                    txtSangkatCode.Text = .Rows(0)("PostalCode").ToString
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetVillageDataByID(Optional _SangkatID As Integer = 0, Optional _Village As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetVillageList", New SqlParameter("@ID", _Village), New SqlParameter("@SangkatID", _SangkatID), New SqlParameter("@Flag", 1))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledEditVillage()
                    btnVillageSave.Text = "UPDATE"
                    VillageID = CInt(.Rows(0)("VillageID"))
                    SangkatID = CInt(.Rows(0)("SangkatID"))
                    txtVillage.Text = .Rows(0)("VillageEn").ToString
                    txtVillageKh.Text = .Rows(0)("VillageKh").ToString
                    txtVillageCode.Text = .Rows(0)("PostalCode").ToString
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub


    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            Dim SelRows() As Integer = gvCity.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvCity.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("PID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove the selected cities (Yes: Permanently, No: Disable)?", "Confirm Remove?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If detected = DialogResult.Cancel Then Return
            If detected = DialogResult.Yes Then
                DisabledCity(_IDTempList, 1, 1)
            Else
                DisabledCity(_IDTempList, 1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisabledCity(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0, Optional _Permament As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisabledCity", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@Inactive", _Inactive)
                .AddWithValue("@Permanent", _Permament)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error

            GetCityData()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm Message", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisabledKhan(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0, Optional _Permament As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisabledKhan", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@Inactive", _Inactive)
                .AddWithValue("@Permanent", _Permament)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error

            GetKhanData(CityID)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm Message", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisabledSangkat(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0, Optional _Permament As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisabledSangkat", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@Inactive", _Inactive)
                .AddWithValue("@Permanent", _Permament)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error
            GetSangkatData(KhanID)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm Message", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisabledVillage(Optional _IDTempList As String = "", Optional _Inactive As Integer = 0, Optional _Permament As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisabledVillage", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@Inactive", _Inactive)
                .AddWithValue("@Permanent", _Permament)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error
            GetVillageData(SangkatID)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm Message", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        Try
            Dim SelRows() As Integer = gvCity.GetSelectedRows()
            If SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvCity.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("PID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to restore the selected cities?", "Confirm Restore?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledCity(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub gcKhan_MouseClick(sender As Object, e As MouseEventArgs) Handles gcKhan.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then pmKhan.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub bbiPKhanAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPKhanAdd.ItemClick
        EnabledEditKhan()
        txtKhan.Text = ""
        txtKhanKh.Text = ""
        KhanID = 0
        btnKhanSave.Text = "SAVE"
        txtKhan.Select()
    End Sub

    Private Sub bbiPVillageAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPVillageAdd.ItemClick
        EnabledEditVillage()
        txtVillage.Text = ""
        txtVillageKh.Text = ""
        VillageID = 0
        btnVillageSave.Text = "SAVE"
        txtVillage.Select()
    End Sub

    Private Sub bbiPSangkatAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPSangkatAdd.ItemClick
        EnabledEditSangkat()
        txtSangkat.Text = ""
        txtSangkatKh.Text = ""
        SangkatID = 0
        btnSangkatSave.Text = "SAVE"
        txtSangkat.Select()
    End Sub

    Private Sub gcSangkat_MouseClick(sender As Object, e As MouseEventArgs) Handles gcSangkat.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then pmSangkat.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub gcVillage_MouseClick(sender As Object, e As MouseEventArgs) Handles gcVillage.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then pmVillage.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub bbiKhanModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiKhanModify.ItemClick
        GetItemtoModify(gvKhan)
        'Dim SelRows As Integer() = gvKhan.GetSelectedRows()
        'Try
        '    Dim i = 0

        '    For Each index As Integer In SelRows
        '        If (index >= 0) Then i += 1
        '    Next

        '    If i = 0 Then
        '        XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    ElseIf i > 1 Then
        '        XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    ElseIf i = 1 Then
        '        isOpenForm = 2
        '        Dim _ID As Integer = CInt(gvKhan.GetRowCellValue(gvKhan.FocusedRowHandle, "KhanID").ToString)
        '        GetKhanDataByID(_ID, CInt(gvCity.GetRowCellValue(gvCity.FocusedRowHandle, "PID")))
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Private Sub bbiPKhanRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPKhanRemove.ItemClick
        Try
            CityID = GetSelectedValue(gvCity)
            Dim SelRows() As Integer = gvKhan.GetSelectedRows()
            If CityID = 0 Then
                XtraMessageBox.Show("Please select City or province to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvCity.Focus()
                Return
            ElseIf SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvKhan.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("KhanID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove the selected Khan (Yes: Permanently, No: Disable)?", "Confirm Remove?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If detected = DialogResult.Cancel Then Return
            If detected = DialogResult.Yes Then
                DisabledKhan(_IDTempList, 1, 1)
            Else
                DisabledKhan(_IDTempList, 1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPKhanRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPKhanRestore.ItemClick
        Try
            CityID = GetSelectedValue(gvCity)
            Dim SelRows() As Integer = gvKhan.GetSelectedRows()
            If CityID = 0 Then
                XtraMessageBox.Show("Please select City or province to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvCity.Focus()
                Return
            ElseIf SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvKhan.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("KhanID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to restore the selected Khan?", "Confirm Restore?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledKhan(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnShowSangkat_Click(sender As Object, e As EventArgs) Handles btnShowSangkat.Click
        ShowItems(gvKhan)
        'Dim SelRows As Integer() = gvKhan.GetSelectedRows()
        'Try
        '    Dim i = 0
        '    For Each index As Integer In SelRows
        '        If (index >= 0) Then i += 1
        '    Next

        '    If i = 0 Then
        '        XtraMessageBox.Show("Please select Khan or district to add new Sangkat.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        gvKhan.Focus()
        '        Return
        '    ElseIf i > 1 Then
        '        XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        gvKhan.Focus()
        '        Return
        '    ElseIf i = 1 Then
        '        Dim SelectedRow As DataRowView = DirectCast(gvKhan.GetRow(SelRows(0)), DataRowView)
        '        GetSangkatData(CInt(SelectedRow("KhanID")))
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Private Sub bbiPSangkatModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPSangkatModify.ItemClick
        GetItemtoModify(gvSangkat)
        'Dim SelRows As Integer() = gvSangkat.GetSelectedRows()
        'Try
        '    Dim i = 0

        '    For Each index As Integer In SelRows
        '        If (index >= 0) Then i += 1
        '    Next

        '    If i = 0 Then
        '        XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    ElseIf i > 1 Then
        '        XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    ElseIf i = 1 Then
        '        isOpenForm = 2
        '        Dim _ID As Integer = CInt(gvSangkat.GetRowCellValue(gvSangkat.FocusedRowHandle, "SangkatID").ToString)
        '        GetSangkatDataByID(_ID, CInt(gvKhan.GetRowCellValue(gvKhan.FocusedRowHandle, "KhanID")))
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Private Function GetSelectedValue(gv As GridView) As Integer
        Dim SelRows As Integer() = gv.GetSelectedRows()
        Dim _ID As Integer = 0
        Try
            Dim i = 0
            For Each index As Integer In SelRows
                If (index >= 0) Then i += 1
            Next

            If i = 1 Then
                Dim SelectedRow As DataRowView = DirectCast(gv.GetRow(SelRows(0)), DataRowView)
                Select Case gv.Name
                    Case NameOf(gvCity)
                        _ID = CInt(SelectedRow("PID"))
                    Case NameOf(gvKhan)
                        _ID = CInt(SelectedRow("KhanID"))
                    Case NameOf(gvSangkat)
                        _ID = CInt(SelectedRow("SangkatID"))
                    Case NameOf(gvVillage)
                        _ID = CInt(SelectedRow("VillageID"))
                End Select
            End If
        Catch ex As Exception
            'XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return _ID
    End Function

    Private Sub ShowItems(gv As GridView)
        Dim SelRows As Integer() = gv.GetSelectedRows()
        Try
            Dim i = 0
            For Each index As Integer In SelRows
                If (index >= 0) Then i += 1
            Next

            If i = 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i > 1 Then
                XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i = 1 Then
                Dim SelectedRow As DataRowView = DirectCast(gv.GetRow(SelRows(0)), DataRowView)
                Select Case gv.Name
                    Case NameOf(gvCity)
                        GetKhanData(CInt(SelectedRow("PID")))
                    Case NameOf(gvKhan)
                        GetSangkatData(CInt(SelectedRow("KhanID")))
                    Case NameOf(gvSangkat)
                        GetVillageData(CInt(SelectedRow("SangkatID")))
                End Select
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub GetItemtoModify(gv As GridView)
        Dim SelRows As Integer() = gv.GetSelectedRows()
        Try
            Dim i = 0
            For Each index As Integer In SelRows
                If (index >= 0) Then i += 1
            Next

            If i = 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i > 1 Then
                XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i = 1 Then
                Dim SelectedRow As DataRowView = DirectCast(gv.GetRow(SelRows(0)), DataRowView)
                Select Case gv.Name
                    Case NameOf(gvCity)
                        GetCityDataByID(CInt(SelectedRow("PID")))
                    Case NameOf(gvKhan)
                        Dim MainSelRows As Integer() = gvCity.GetSelectedRows()
                        Dim MailSelectedRow As DataRowView = DirectCast(gvCity.GetRow(MainSelRows(0)), DataRowView)
                        GetKhanDataByID(CInt(MailSelectedRow("PID")), CInt(SelectedRow("KhanID")))
                    Case NameOf(gvSangkat)
                        Dim MainSelRows As Integer() = gvKhan.GetSelectedRows()
                        Dim MailSelectedRow As DataRowView = DirectCast(gvKhan.GetRow(MainSelRows(0)), DataRowView)
                        GetSangkatDataByID(CInt(MailSelectedRow("KhanID")), CInt(SelectedRow("SangkatID")))
                    Case NameOf(gvVillage)
                        Dim MainSelRows As Integer() = gvSangkat.GetSelectedRows()
                        Dim MailSelectedRow As DataRowView = DirectCast(gvSangkat.GetRow(MainSelRows(0)), DataRowView)
                        GetVillageDataByID(CInt(MailSelectedRow("SangkatID")), CInt(SelectedRow("VillageID")))
                End Select
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnShowVillage_Click(sender As Object, e As EventArgs) Handles btnShowVillage.Click
        ShowItems(gvSangkat)
    End Sub

    Private Sub bbiPSangkatRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPSangkatRemove.ItemClick
        Try
            KhanID = GetSelectedValue(gvKhan)
            Dim SelRows() As Integer = gvSangkat.GetSelectedRows()
            If KhanID = 0 Then
                XtraMessageBox.Show("Please select Khan or district to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvKhan.Focus()
                Return
            ElseIf SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvSangkat.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("SangkatID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove the selected Sangkat (Yes: Permanently, No: Disable)?", "Confirm Remove?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If detected = DialogResult.Cancel Then Return
            If detected = DialogResult.Yes Then
                DisabledSangkat(_IDTempList, 1, 1)
            Else
                DisabledSangkat(_IDTempList, 1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPSangkatRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPSangkatRestore.ItemClick
        Try
            KhanID = GetSelectedValue(gvKhan)
            Dim SelRows() As Integer = gvSangkat.GetSelectedRows()
            If KhanID = 0 Then
                XtraMessageBox.Show("Please select Khan or district to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvKhan.Focus()
                Return
            ElseIf SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvSangkat.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("SangkatID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to restore the selected Sangkat?", "Confirm Restore?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledSangkat(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPAddPHCode_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAddPHCode.ItemClick
        ModifySeletedItem(gvCity)
    End Sub

    'Private Sub ModifyCityPhoneCode(gv As GridView)
    '    Dim SelRows As Integer() = gv.GetSelectedRows()
    '    Try
    '        Dim i = 0
    '        For Each index As Integer In SelRows
    '            If (index >= 0) Then i += 1
    '        Next

    '        If i = 0 Then
    '            XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Return
    '        ElseIf i > 1 Then
    '            XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Return
    '        ElseIf i = 1 Then
    '            Dim SelectedRow As DataRowView = DirectCast(gv.GetRow(SelRows(0)), DataRowView)
    '            frmAddPhoneCode.GetCityInfo(CInt(SelectedRow("PID")))
    '            LoadFormDialog(frmAddPhoneCode)
    '        End If
    '    Catch ex As Exception
    '        XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End Try
    'End Sub

    Private Sub bbiPVillageModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPVillageModify.ItemClick
        GetItemtoModify(gvVillage)
    End Sub

    Private Sub bbiPVillageRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPVillageRemove.ItemClick
        Try
            SangkatID = GetSelectedValue(gvSangkat)
            Dim SelRows() As Integer = gvVillage.GetSelectedRows()
            If SangkatID = 0 Then
                XtraMessageBox.Show("Please select Sangkat or commune to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvKhan.Focus()
                Return
            ElseIf SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvVillage.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("VillageID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to remove the selected Villages (Yes: Permanently, No: Disable)?", "Confirm Remove?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If detected = DialogResult.Cancel Then Return
            If detected = DialogResult.Yes Then
                DisabledVillage(_IDTempList, 1, 1)
            Else
                DisabledVillage(_IDTempList, 1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPVillageRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPVillageRestore.ItemClick
        Try
            SangkatID = GetSelectedValue(gvSangkat)
            Dim SelRows() As Integer = gvVillage.GetSelectedRows()
            If SangkatID = 0 Then
                XtraMessageBox.Show("Please select Sangkat or commune to perform action.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                gvSangkat.Focus()
                Return
            ElseIf SelRows.Count <= 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvVillage.GetRow(index), DataRowView)
                    _TempID(i) = SelectedRow("VillageID").ToString()
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Do you want to restore the selected Village?", "Confirm Restore?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledVillage(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPSangkatPostalCode_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPSangkatPostalCode.ItemClick
        ModifySeletedItem(gvSangkat)
    End Sub

    Private Sub bbiPKhanPostalCode_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPKhanPostalCode.ItemClick
        ModifySeletedItem(gvKhan)
    End Sub

    Private Sub ModifySeletedItem(gv As GridView)
        Dim SelRows As Integer() = gv.GetSelectedRows()
        Try
            Dim i = 0
            For Each index As Integer In SelRows
                If (index >= 0) Then i += 1
            Next

            If i = 0 Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i > 1 Then
                XtraMessageBox.Show("You cannot select multiple records at a time.", "Multiple Records Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf i = 1 Then
                Dim SelectedRow As DataRowView = DirectCast(gv.GetRow(SelRows(0)), DataRowView)
                Dim TempID As Integer = 0
                Dim TempKhanID As Integer = 0
                Dim TempSangkatID As Integer = 0
                Select Case gv.Name
                    Case NameOf(gvCity)
                        TempID = CInt(SelectedRow("PID"))
                        frmAddPhoneCode._Access = "phone_code"
                    Case NameOf(gvKhan)
                        TempID = GetSelectedValue(gvCity)
                        TempKhanID = CInt(SelectedRow("KhanID"))
                        frmAddPhoneCode._Access = "khan_postal_code"
                    Case NameOf(gvSangkat)
                        TempKhanID = GetSelectedValue(gvKhan)
                        TempSangkatID = CInt(SelectedRow("SangkatID"))
                        frmAddPhoneCode._Access = "sangkat_postal_code"
                End Select

                frmAddPhoneCode.GetItemInfo(TempID, TempKhanID, TempSangkatID)
                LoadFormDialog(frmAddPhoneCode)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Oops, something went wrong. Please try again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmCambodiaAdminAreas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class