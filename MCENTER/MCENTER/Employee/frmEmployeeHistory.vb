Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmEmployeeHistory
    Dim _CardIDNo As Integer = 0

    Private Sub frmStaffTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadDBConnection()
        'AutoCompleteID(txtSID, "SA_GetStaffIDByCompany")
        GetDataToComboBoxWithParam(lueDivision, "SA_GetDivisionList", "ID", "Division")
        'lueCompany.ItemIndex = 0
        GetDataToComboBoxWithParam(lueDepartment, "SA_GetDepartmentList", "ID", "Department")
        'lueDepartment.ItemIndex = 0
        GetSectionToCombo()
        GetDataToComboBoxWithParam(lueCampus, "SA_GetCampusList", "Num", "Campus")
        'lueCampus.ItemIndex = 0
        GetDataToComboBoxWithParam(lueManagementLevel, "SA_GetManagementLevelList", "ID", "Management")

        'lueManagementLevel.ItemIndex = 0
        deEffectiveDate.DateTime = DateTime.Now
        deApprovedDate.DateTime = DateTime.Now
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'IsOpenForm = 2
        LoadFormDialog(frmEmployeeDetailList)
        If Not String.IsNullOrEmpty(tempCardID) Then
            txtSID.Text = tempCardID
            GetStaffTransferToList(tempCardID)
            txtPosition.Focus()
        Else
            txtSID.Focus()
        End If
    End Sub

    Private Sub GetStaffTransferToList(_CardID As String)
        Try
            'open connection if close
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_GetEmployeeHistory", Con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CardID", _CardID)

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            With ds.Tables(0)
                Dim i As Integer = .Rows.Count
                If i = 1 Then
                    EnabledButtonSave()
                    ClearToAddRecord()
                    EnabledEditBox()
                    btnClear.Enabled = True
                    txtEmpID.Text = .Rows(0)("CardID").ToString
                    txtENName.Text = .Rows(0)("Name").ToString
                    _CardIDNo = CInt(.Rows(0)("ID").ToString)
                    LoadStaffTransferToTable(_CardID)
                    txtPosition.Focus()
                Else
                    ClearAllContent()
                    XtraMessageBox.Show("Searching keyword: " + txtSID.Text.Trim + " doesnot exist on the target system. ", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtSID.Focus()
                End If
            End With

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + ". Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'close connection if open
        CloseCon(Con)
    End Sub

    Private Sub LoadStaffTransferToTable(_CardID As String)
        Try
            Dim DataList As DataTable = GetDataFromDBToTable("SA_GetEmploymentHistoryToList",
                                                                    New SqlParameter("@CardID", _CardID),
                                                                    New SqlParameter("@TranID", ""))
            With gvStaffTransfer
                If DataList.Rows.Count > 0 Then
                    gcStaffTransfer.DataSource = DataList

                    .PopulateColumns()
                    .Columns("TranID").OptionsColumn.FixedWidth = True
                    .Columns("TranID").Width = 40
                    .Columns("TranID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("TranID").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("CardID").Visible = False
                    .Columns("Remark").Visible = False
                    .Columns("ApprovedBy").Visible = False
                    .Columns("ApprovedDate").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .BestFitColumns()
                Else
                    gcStaffTransfer.DataSource = Nothing
                    .Columns.Clear()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
        btnTrush.Enabled = del
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

    'Private Sub ClearContentIfNew()
    '    txtNumber.Text = ""
    '    txtPosition.Text = ""
    '    lueCompany.EditValue = -1
    '    lueDepartment.EditValue = -1
    '    lueCampus.EditValue = -1
    '    lueManagementLevel.EditValue = -1
    '    txtApprovedBy.Text = ""
    '    txtReason.Text = ""
    '    meRemark.Text = ""
    '    deEffectiveDate.DateTime = DateTime.Now
    '    deApprovedDate.DateTime = DateTime.Now
    '    gcStaffTransfer.DataSource = Nothing
    '    lstManagementLevel.Items.Clear()
    '    ShowUpdateFooterNote(False)
    '    ShowAddFooterNote(False)
    'End Sub

    Private Sub ClearToAddRecord()
        txtNumber.Text = "***"
        txtPosition.Text = ""
        _CardIDNo = 0
        lueDivision.EditValue = -1
        lueDepartment.EditValue = -1
        lueSection.EditValue = -1
        lueCampus.EditValue = -1
        lueManagementLevel.ItemIndex = 0
        txtApprovedBy.Text = ""
        txtReason.Text = ""
        meRemark.Text = ""
        deEffectiveDate.DateTime = DateTime.Now
        deApprovedDate.DateTime = DateTime.Now
        lstManagementLevel.Items.Clear()
        ShowUpdateFooterNote(False)
        ShowAddFooterNote(False)
    End Sub

    Private Sub ClearAllContent()
        txtEmpID.Text = ""
        txtENName.Text = ""
        gcStaffTransfer.DataSource = Nothing
        gvStaffTransfer.Columns.Clear()
        ClearToAddRecord()
    End Sub

    Private Sub EnabledEditBox(Optional En As Boolean = True)
        txtPosition.Enabled = En
        lueDivision.Enabled = En
        lueDepartment.Enabled = En
        lueSection.Enabled = En
        lueCampus.Enabled = En
        deEffectiveDate.Enabled = En
        deApprovedDate.Enabled = En
        txtApprovedBy.Enabled = En
        txtReason.Enabled = En
        meRemark.Enabled = En
        lueManagementLevel.Enabled = En
        lstManagementLevel.Enabled = En
        btnAddIns.Enabled = En
        btnEditIns.Enabled = En
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAllContent()
        btnClear.Enabled = False
        btnNew.Enabled = False
        txtSID.Text = ""
        EnabledButtonSave("Save", False, False)
        txtSID.Focus()
    End Sub

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim Find_ID As String = txtSID.Text.Trim
            txtEmpID.ReadOnly = False
            ClearAllContent()

            If String.IsNullOrEmpty(Find_ID) Then
                XtraMessageBox.Show("Please enter Employee ID before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSID.Focus()
                Return
            End If

            txtSID.Text = txtSID.Text.Trim.ToUpper
            GetStaffTransferToList(Find_ID)
            'SelectStaffTransferRec(Find_ID)
        End If
    End Sub

    Private Sub GetSearchStaffTransferListByID(_TranID As String)
        Try
            'open connection if close
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_GetEmploymentHistoryToList", Con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CardID", txtEmpID.Text.Trim)
            cmd.Parameters.AddWithValue("@TranID", _TranID)

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            With ds.Tables(0)
                Dim i As Integer = .Rows.Count
                If i = 1 Then
                    EnabledButtonSave("&Update", True, True)
                    btnNew.Enabled = True
                    txtEmpID.Text = .Rows(0)("CardID").ToString
                    _CardIDNo = CInt(.Rows(0)("CardIDNo").ToString)
                    txtNumber.Text = .Rows(0)("TranID").ToString
                    txtPosition.Text = .Rows(0)("Position").ToString

                    If String.IsNullOrEmpty(.Rows(0)("Division").ToString) Then
                        lueDivision.EditValue = -1
                    Else
                        lueDivision.EditValue = CInt(.Rows(0).Item("Division").ToString)
                    End If

                    If String.IsNullOrEmpty(.Rows(0)("Department").ToString) Then
                        lueDepartment.EditValue = -1
                    Else
                        lueDepartment.EditValue = CInt(.Rows(0)("Department").ToString)
                    End If

                    If String.IsNullOrEmpty(.Rows(0)("Section").ToString) Then
                        lueSection.EditValue = -1
                    Else
                        lueSection.EditValue = CInt(.Rows(0)("Section").ToString)
                    End If

                    If String.IsNullOrEmpty(.Rows(0)("Campus").ToString) Then
                        lueCampus.EditValue = -1
                    Else
                        lueCampus.EditValue = CInt(.Rows(0)("Campus").ToString)
                    End If

                    txtReason.Text = .Rows(0)("Reason").ToString
                    Dim EffectiveDate As String = .Rows(0)("EffectiveDate").ToString
                    If String.IsNullOrEmpty(EffectiveDate) Then
                        deEffectiveDate.DateTime = DateTime.Now
                    Else
                        deEffectiveDate.DateTime = Convert.ToDateTime(EffectiveDate)
                    End If

                    txtApprovedBy.Text = .Rows(0)("ApprovedBy").ToString

                    Dim ApprovedDate As String = .Rows(0)("ApprovedDate").ToString
                    If String.IsNullOrEmpty(ApprovedDate) Then
                        deApprovedDate.DateTime = DateTime.Now
                    Else
                        deApprovedDate.DateTime = Convert.ToDateTime(ApprovedDate)
                    End If

                    Dim Splits As String() = {Separator}
                    Dim AccList As String = .Rows(0)("Management").ToString
                    lstManagementLevel.Items.Clear()
                    lueManagementLevel.EditValue = -1

                    If Not String.IsNullOrEmpty(AccList) Then
                        Dim allAllowedList As String() = AccList.Split(Splits, StringSplitOptions.RemoveEmptyEntries)
                        lueManagementLevel.ItemIndex = 0
                        'lstManagementLevel.Items.Clear()
                        For Each t As String In allAllowedList
                            lstManagementLevel.Items.Add(Trim(t))
                        Next
                    End If

                    meRemark.Text = .Rows(0)("Remark").ToString

                    Dim UserCreate As String = .Rows(0)("UserCreate").ToString
                    Dim DateCreate As String = .Rows(0)("DateCreate").ToString
                    Dim UserUpdate As String = .Rows(0)("UserUpdate").ToString
                    Dim DateUpdate As String = .Rows(0)("DateUpdate").ToString

                    getFooterNote(UserCreate, DateCreate, UserUpdate, DateUpdate)

                    LoadStaffTransferToTable(txtEmpID.Text.Trim)
                    txtPosition.Focus()
                Else
                    ClearAllContent()
                    txtSID.Focus()
                End If
            End With
        Catch generatedExceptionName As SqlException
            XtraMessageBox.Show("Cannot perform this selecting operation on ID: " + txtEmpID.Text.Trim + ". " & vbLf & vbLf & "Please try another Staff ID or see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'close connection if open
        CloseCon(Con)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not isLoggedInOwner Then
            If String.IsNullOrEmpty(txtPosition.Text.Trim()) OrElse String.IsNullOrEmpty(txtEmpID.Text.Trim()) OrElse String.IsNullOrEmpty(txtApprovedBy.Text.Trim()) OrElse String.IsNullOrEmpty(txtReason.Text.Trim()) Then
                XtraMessageBox.Show("Some fields are blank. Please check it.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPosition.Focus()
                Return
            ElseIf String.IsNullOrEmpty(lueDivision.Text) OrElse String.IsNullOrEmpty(lueDepartment.Text) OrElse String.IsNullOrEmpty(lueCampus.Text) Then
                XtraMessageBox.Show("Please select the mandatory information from the box.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lueDivision.Focus()
                Return
                'ElseIf String.IsNullOrEmpty(lueManagementLevel.Text) Then
                '    XtraMessageBox.Show("Please select management level for this employeee.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    lueManagementLevel.Focus()
                '    Return
            End If
        End If

        Try
            Dim Division As Object = lueDivision.EditValue
            Dim Department As Object = lueDepartment.EditValue
            Dim Campus As Object = lueCampus.EditValue
            Dim Section As Object = lueSection.EditValue

            Dim ManagementList As String = ""

            'If lstManagementLevel.ItemCount < 1 Then
            '    ManagementList = lueManagementLevel.EditValue.ToString
            'Else
            '    Dim items = lstManagementLevel.Items.OfType(Of Object)().Select(Function(i) Split(i.ToString(), ". ")(0)).ToArray()
            '    'AllowedList = String.Join(Separator, lstAccessLocation.Items.OfType(Of Object)())
            '    ManagementList = String.Join(Separator, items)
            'End If

            If lstManagementLevel.ItemCount > 0 Then
                Dim items = lstManagementLevel.Items.OfType(Of Object)().Select(Function(i) Split(i.ToString(), ". ")(0)).ToArray()
                'AllowedList = String.Join(Separator, lstAccessLocation.Items.OfType(Of Object)())
                ManagementList = String.Join(Separator, items)
            End If

            Dim NewInsertID As Integer = 0
            If txtNumber.Text <> "***" Then
                NewInsertID = CInt(txtNumber.Text.Trim)
            End If

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveEmploymentHistory", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@TranID", NewInsertID)
                .AddWithValue("@CardIDNo", _CardIDNo)
                .AddWithValue("@CardID", txtEmpID.Text.Trim)
                .AddWithValue("@Name", txtENName.Text.Trim)
                .AddWithValue("@Position", txtPosition.Text.Trim)
                .AddWithValue("@Division", Division)
                .AddWithValue("@Department", Department)
                .AddWithValue("@Section", Section)
                .AddWithValue("@Campus", Campus)
                .AddWithValue("@Management", ManagementList)
                .AddWithValue("@Reason", txtReason.Text.Trim)
                .AddWithValue("@EffectiveDate", deEffectiveDate.EditValue)
                .AddWithValue("@ApprovedBy", txtApprovedBy.Text.Trim)
                .AddWithValue("@ApprovedDate", deApprovedDate.EditValue)
                .AddWithValue("@Remark", meRemark.Text.Trim)
                .AddWithValue("@User", AccountName)
                .Add("@isAdd", SqlDbType.Int)
                cmd.Parameters("@isAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            Dim mms As MessageBoxIcon
            btnNew.Enabled = True

            If Convert.ToInt16(cmd.Parameters("@isAdd").Value) <> 0 Then
                EnabledButtonSave("Save", False)
                mms = MessageBoxIcon.Information
                txtSID.Focus()

            Else
                btnNew.Enabled = False
                mms = MessageBoxIcon.Error
                txtPosition.Focus()
            End If

            LoadStaffTransferToTable(txtEmpID.Text.Trim)

            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Employment History", MessageBoxButtons.OK, mms)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnClear.Focus()
        End Try

        CloseCon(Con)
    End Sub

    Private Sub btnTrush_Click(sender As Object, e As EventArgs) Handles btnTrush.Click
        Dim ManagementList As String = ""

        If lstManagementLevel.ItemCount < 1 Then
            ManagementList = lueManagementLevel.EditValue.ToString
        Else
            Dim items = lstManagementLevel.Items.OfType(Of Object)().Select(Function(i) Split(i.ToString(), ". ")(0)).ToArray()
            'AllowedList = String.Join(Separator, lstAccessLocation.Items.OfType(Of Object)())
            ManagementList = String.Join(Separator, items)
        End If
        XtraMessageBox.Show(ManagementList)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearToAddRecord()
        EnabledButtonSave()
        btnNew.Enabled = False
        txtPosition.Focus()
    End Sub

    Private Sub btnAddIns_Click(sender As Object, e As EventArgs) Handles btnAddIns.Click
        If Not lstManagementLevel.Items.Contains(lueManagementLevel.EditValue.ToString + ". " + lueManagementLevel.Text) Then
            ' Random Idea which doesnt work
            lstManagementLevel.Items.Add(lueManagementLevel.EditValue.ToString + ". " + lueManagementLevel.Text)
            'btnEditIns.Enabled = True
            'btnAddIns.Enabled = False
        End If
    End Sub

    Private Sub btnEditIns_Click(sender As Object, e As EventArgs) Handles btnEditIns.Click
        If lstManagementLevel.ItemCount > 0 Then
            lstManagementLevel.Items.RemoveAt(lstManagementLevel.SelectedIndex)
            lueManagementLevel.Focus()
        Else
            'btnEditIns.Enabled = False
            'btnAddIns.Enabled = True
        End If
    End Sub

    Private Sub lueManagementLevel_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueManagementLevel.Closed
        'btnAddIns.Enabled = False
        btnAddIns.Focus()

        If Not lstManagementLevel.Items.Contains(lueManagementLevel.EditValue) Then
            ' Random Idea which doesnt work
            'btnAddIns.Enabled = True
        End If
    End Sub

    Private Sub btnPositionList_Click(sender As Object, e As EventArgs)
        isFormPositionOpen = 2
        LoadFormDialog(frmPositionList)
        If Not String.IsNullOrEmpty(PositionID) Then
            SelectPositionName(PositionID)
        End If
    End Sub

    Private Sub SelectPositionName(Find_ID As String)
        Try
            'open connection if close
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_GetPositionByID", Con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ID", Find_ID)

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            Dim i As Integer = ds.Tables(0).Rows.Count
            If i = 1 Then
                btnNew.Enabled = True
                txtPosition.Text = ds.Tables(0).Rows(0)("Position").ToString
            Else
                ClearAllContent()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + " Please see your system administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        txtPosition.Focus()

        'close connection if open
        CloseCon(Con)
    End Sub

    Private Sub txtPosition_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtPosition.ButtonClick
        isFormPositionOpen = 2
        LoadFormDialog(frmPositionList)
        If Not String.IsNullOrEmpty(PositionID) Then
            SelectPositionName(PositionID)
            lueDivision.Focus()
        End If
    End Sub

    Private Sub gcStaffTransfer_MouseClick(sender As Object, e As MouseEventArgs) Handles gcStaffTransfer.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            ppMenuPopup.ShowPopup(Me.bmMenuPopup, Control.MousePosition)
        End If
    End Sub

    Private Sub bbiEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiEdit.ItemClick
        Try
            txtNumber.Text = gvStaffTransfer.GetRowCellValue(gvStaffTransfer.FocusedRowHandle, "TranID").ToString
            GetSearchStaffTransferListByID(txtNumber.Text.Trim)
        Catch ex As Exception
            ClearToAddRecord()
            EnabledButtonSave()
            txtPosition.Focus()
        End Try
    End Sub

    Private Sub deEffectiveDate_EditValueChanged(sender As Object, e As EventArgs) Handles deEffectiveDate.EditValueChanged
        deApprovedDate.DateTime = deEffectiveDate.DateTime
    End Sub

    Private Sub lueDepartment_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueDepartment.Closed
        GetSectionToCombo()
    End Sub

    Private Sub GetSection(_DeptID As Integer)
        GetDataToComboBoxWithParam(lueSection, "SA_GetSectionListByDept", "ID", "Section", New SqlParameter("@DeptID", _DeptID))
    End Sub


    Private Sub GetSectionToCombo()
        Try
            GetSection(CInt(lueDepartment.EditValue))
        Catch ex As Exception

        End Try
    End Sub
End Class