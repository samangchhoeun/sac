Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmUserAccounts
    Public Old_Password As String = ""
    Public _TempCardID As String = ""

    Private Sub frmUserAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoCompleteID(txtSID, "SA_GetCardIDByCompany")
        LoadAccountType()
    End Sub

    Private Sub LoadAccountType()
        GetDataToComboBoxWithParam(lueAccountType, "SA_GetRoleList", "RoleID", "RoleType", New SqlParameter("@IsAdmin", isLoggedInOwner))
        lueAccountType.ItemIndex = 0
    End Sub

    Private Function IsFatherChecked() As Boolean
        Dim IsChecked As Boolean = False
        If chkDisabledAcc.Checked OrElse chkResetPass.Checked OrElse chkUserCannotChangePass.Checked OrElse chkChangePassNextLog.Checked Then IsChecked = True
        Return IsChecked
    End Function

    Private Sub frmUserAccounts_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub chkUserCannotChangePass_CheckStateChanged(sender As Object, e As EventArgs) Handles chkUserCannotChangePass.CheckStateChanged
        EnabledCheckAcc(CBool(chkUserCannotChangePass.Checked))
    End Sub

    Private Sub EnabledCheckAcc(Optional en As Boolean = False)
        chkResetPass.Enabled = Not en
        chkChangePassNextLog.Enabled = Not en
        If en Then
            chkResetPass.Checked = False
            chkChangePassNextLog.Checked = False
        End If
    End Sub

    Private Sub SetDefaultPassword()
        txtConfirmPass.Text = MrSAM
        txtPass.Text = MrSAM
    End Sub

    Private Sub EnablePasswordBox(Optional val As Boolean = True, Optional prov As Boolean = True)
        txtPass.ReadOnly = Not val
        txtConfirmPass.ReadOnly = Not val

        chkResetPass.Enabled = prov
        If prov = False Then chkResetPass.Checked = False
    End Sub

    Private Sub ClearPasswordBox()
        txtPass.Text = ""
        txtConfirmPass.Text = ""
        txtPass.Focus()
    End Sub

    Private Sub chkResetPass_CheckStateChanged(sender As Object, e As EventArgs) Handles chkResetPass.CheckStateChanged
        If chkResetPass.Checked And chkDisabledAcc.Checked = False Then
            EnablePasswordBox()
            ClearPasswordBox()
            txtPass.Focus()
        ElseIf String.IsNullOrEmpty(txtUserID.Text.Trim()) Then
            EnablePasswordBox(True, False)
            ClearPasswordBox()
            txtSID.Focus()
        ElseIf chkDisabledAcc.Checked Or chkUserCannotChangePass.Checked Then
            EnablePasswordBox(False, False)
            SetDefaultPassword()
        Else
            Dim keep As DialogResult = XtraMessageBox.Show("Want to use old password?", "Password Change?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If keep = DialogResult.Yes Then
                SetDefaultPassword()
                EnablePasswordBox(False)
            Else
                chkResetPass.Checked = True
                ClearPasswordBox()
                txtPass.Focus()
            End If
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        txtSID.Text = ""
        txtSID.Focus()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Create", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
        btnTrush.Enabled = del
    End Sub

    Private Sub ClearContentIfNew()
        txtNumber.Text = "***"
        txtUserID.Text = ""
        _TempCardID = ""
        txtUserID.ReadOnly = False
        txtConfirmPass.Text = ""
        txtPass.Text = ""
        chkDisabledAcc.Checked = False
        chkResetPass.Checked = False
        chkUserCannotChangePass.Checked = False
        lueAccountType.ItemIndex = 0
        picPhoto.Image = My.Resources.MJQE_Photo
        EnabledButtonSave()
        EnablePasswordBox(True, False)
    End Sub

    Private Sub ClearAllContent()
        txtENName.Text = ""
        ClearContentIfNew()
    End Sub

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Find_ID As String = txtSID.Text.Trim.ToUpper
            ClearAllContent()

            If String.IsNullOrEmpty(Find_ID) Then
                XtraMessageBox.Show("Please enter Card ID before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSID.Focus()
                Return
            End If

            txtSID.Text = txtSID.Text.Trim.ToUpper
            SelectUserLogRec(Find_ID)
        End If
    End Sub

    Private Sub SelectUserLogRec(Find_ID As String)
        Try
            Dim dbDataList As DataTable = GetDataFromDBToTable("SA_GetUserLogByID", New SqlParameter("@CardID", Find_ID), New SqlParameter("@KC", SAC))
            If dbDataList.Rows.Count = 1 Then
                With dbDataList
                    _TempCardID = .Rows(0)("CardID").ToString
                    txtENName.Text = .Rows(0)("Name").ToString
                    txtUserID.Text = .Rows(0)("Name").ToString.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(" ", "").ToLower
                    LoadProfilePhoto(.Rows(0)("Photo"), picPhoto)
                    EnablePasswordBox()

                    Dim IsExist As String = .Rows(0)("IsCreated").ToString
                    If IsExist = "IsCreated" Then
                        EnablePasswordBox(False)
                        EnabledButtonSave("&Update", False)
                        chkResetPass.Enabled = True
                        lueAccountType.Enabled = False
                        txtUserID.ReadOnly = True
                        SetDefaultPassword()

                        txtNumber.Text = .Rows(0)("UserNo").ToString
                        SID = CInt(.Rows(0)("UserNo"))
                        If IsMainOwnerAllowModifyOthers() Then
                            EnabledButtonSave("&Update", True, True)
                            lueAccountType.Enabled = True
                            txtUserID.ReadOnly = False
                        ElseIf IsOwnerAllowModifyOthers(SID) Then
                            EnabledButtonSave("&Update", True, True)
                            lueAccountType.Enabled = True
                        End If

                        txtUserID.Text = Decrypt(.Rows(0)("UserID").ToString)
                        Old_Password = .Rows(0)("Pass").ToString

                        If String.IsNullOrEmpty(.Rows(0)("RoleID").ToString) Then
                            lueAccountType.EditValue = ""
                        Else
                            lueAccountType.EditValue = CInt(.Rows(0)("RoleID"))
                        End If

                        chkChangePassNextLog.Checked = CBool(.Rows(0)("Change_Pass_NextLog"))
                        chkUserCannotChangePass.Checked = CBool(.Rows(0)("User_Cannot_Change_Pass"))
                        chkDisabledAcc.Checked = CBool(.Rows(0)("Disabled_Acc"))

                        'Dim UserCreate As String = .Rows(0)("UserCreate").ToString
                        'Dim DateCreate As String = .Rows(0)("DateCreate").ToString
                        'Dim UserUpdate As String = .Rows(0)("UserUpdate").ToString
                        'Dim DateUpdate As String = .Rows(0)("DateUpdate").ToString

                        'getFooterNote(UserCreate, DateCreate, UserUpdate, DateUpdate)
                    End If
                End With
                txtPass.Focus()
            Else
                ClearAllContent()
                XtraMessageBox.Show("Searching keyword: " + txtSID.Text.Trim + " doesnot exist on the target system.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSID.Focus()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EnableRightClickMenu(Optional En As Boolean = True)
        bbiPRequestChangePassword.Enabled = En
        bbiPRestrictPasswordChange.Enabled = En
        bbiPBlock.Enabled = En
        bbiPUnblock.Enabled = En
    End Sub

    Private Sub LoadProfilePhoto(Src As Object, ProfilePicture As PictureBox)
        Dim img As Byte() = TryCast(Src, Byte())
        ProfilePicture.Image = byteArrayToImage(img)
        ProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage
        ProfilePicture.Refresh()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Password As String = ""
        Dim NewInsertID As Integer = 0
        If txtNumber.Text.Trim <> "***" Then
            NewInsertID = CInt(txtNumber.Text.Trim)
            SID = CInt(txtNumber.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtUserID.Text.Trim) Then
            XtraMessageBox.Show("Some fields are blank.", "Confirm Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUserID.Focus()
            Return
        ElseIf String.IsNullOrEmpty(txtPass.Text.Trim) OrElse String.IsNullOrEmpty(txtConfirmPass.Text.Trim) Then
            XtraMessageBox.Show("Please enter your password.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Focus()
            Return
        ElseIf (txtPass.Text.Trim().Length < MIN_PWD_LENGTH) Then
            XtraMessageBox.Show(minPassMsg, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Focus()
            Return
        ElseIf (String.CompareOrdinal(txtPass.Text.Trim(), txtConfirmPass.Text.Trim()) <> 0) Then
            XtraMessageBox.Show("Confirm Password mismatch. Please try again.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Focus()
            Return
        ElseIf (String.IsNullOrEmpty(lueAccountType.Text)) Then
            XtraMessageBox.Show("Please select account type from the box. ", "User Error?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lueAccountType.Focus()
            Return
        ElseIf IsMainOwnerNotAllowToModify(SID) Then
            XtraMessageBox.Show(builtinAccMsg, "User Error?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSID.Focus()
            Return
        ElseIf IsOwnerCurrentLoggedIn(SID) AndAlso IsFatherChecked() Then
            XtraMessageBox.Show(disabledAccMsg, "Deactivate Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSID.Focus()
            Return
        End If

        If Not String.IsNullOrEmpty(Old_Password) And chkResetPass.Checked = False Then
            Password = Old_Password
        Else
            Password = GenEncryptPassword(txtPass.Text.Trim)
        End If

        Try
            Dim _RoleID As Object = lueAccountType.EditValue
            Dim L_UserID As String = Encrypt(txtUserID.Text.Trim.ToLower)

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveUserLog", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@UserNo", NewInsertID)
                .AddWithValue("@CardID", _TempCardID)
                .AddWithValue("@UserAccount", txtUserID.Text.Trim.ToLower)
                .AddWithValue("@UserID", L_UserID)
                .AddWithValue("@Pass", Password)
                .AddWithValue("@RoleID", _RoleID)
                .AddWithValue("@Change_Pass_NextLog", chkChangePassNextLog.EditValue)
                .AddWithValue("@User_Cannot_Change_Pass", chkUserCannotChangePass.EditValue)
                .AddWithValue("@Disabled_Acc", chkDisabledAcc.EditValue)
                .AddWithValue("@User", AccountName)
                .AddWithValue("@KC", SAC)
                .Add("@isAdd", SqlDbType.Int)
                cmd.Parameters("@isAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim mms As MessageBoxIcon = MessageBoxIcon.Information
            If Convert.ToInt16(cmd.Parameters("@isAdd").Value) <> 0 Then
                EnabledButtonSave("Create", False)
            Else
                txtUserID.Focus()
                mms = MessageBoxIcon.Error
            End If

            AutoCompleteID(txtSID, "SA_GetCardIDByCompany")
            LoadUserLogToTable()
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "User Accounts", MessageBoxButtons.OK, mms)
            btnNew.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUserLogToTable(Optional _CardID As String = "")
        Dim dt As DataTable = GetDataFromDBToTable("SA_GetUserLogToList", New SqlParameter("@CardID", _CardID), New SqlParameter("@KC", SAC), New SqlParameter("@Flag", isLoggedInOwner))
        If dt.Rows.Count > 0 Then
            gcData.DataSource = dt
            With gvData
                .PopulateColumns()
                .Columns("ID").Visible = False
                .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("AccountName").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                .Columns("UserID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                .Columns("RoleType").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                .Columns("DateCreate").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                .Columns("DateCreate").SummaryItem.DisplayFormat = "Total: {0} Records"
                .BestFitColumns()
            End With
        End If
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        EnableRightClickMenu(False)
        If isLoggedInOwner Then EnableRightClickMenu()
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppMenu.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub bbiPRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRefresh.ItemClick
        LoadUserLogToTable()
    End Sub

    Private Sub bbiPBlock_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPBlock.ItemClick
        Dim SelRows() As Integer = gvData.GetSelectedRows()
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim _TempHoliday(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
                    If CInt(SelectedRow("ID").ToString()) <> 3 Then
                        _TempID(i) = SelectedRow("ID").ToString()
                    End If
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Want to block the selected accounts?", "Block Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            SetAccountOptions(_IDTempList, 1)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetAccountOptions(ByVal _StrID As String, Optional BlockAcc As Integer = 0, Optional StictPassword As Integer = 0, Optional RequestChangePassword As Integer = 0, Optional Remove As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_BanUserAccount", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _StrID)
                .AddWithValue("@BlockAcc", BlockAcc)
                .AddWithValue("@StictPassword", StictPassword)
                .AddWithValue("@RequestChangePassword", RequestChangePassword)
                .AddWithValue("@Mark_Deleted", Remove)
                .AddWithValue("@User", AccountName)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            Dim MMS As MessageBoxIcon
            Dim IsAdd As Integer = CInt(cmd.Parameters("@IsAdd").Value)

            If IsAdd <> 0 Then
                MMS = MessageBoxIcon.Information
            Else
                MMS = MessageBoxIcon.Error
            End If

            LoadUserLogToTable()
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "User Accounts", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPUnblock_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPUnblock.ItemClick
        Dim SelRows() As Integer = gvData.GetSelectedRows()
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim _TempHoliday(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
                    If CInt(SelectedRow("ID").ToString()) <> 3 Then
                        _TempID(i) = SelectedRow("ID").ToString()
                    End If
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Want to unblock the selected accounts?", "Block Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            SetAccountOptions(_IDTempList)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRestrictPasswordChange_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestrictPasswordChange.ItemClick
        Dim SelRows() As Integer = gvData.GetSelectedRows()
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim _TempHoliday(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
                    If CInt(SelectedRow("ID").ToString()) <> 3 Then
                        _TempID(i) = SelectedRow("ID").ToString()
                    End If
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Restrict password change for the selected accounts?", "Block Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            SetAccountOptions(_IDTempList, 0, 1)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRequestChangePassword_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRequestChangePassword.ItemClick
        Dim SelRows() As Integer = gvData.GetSelectedRows()
        If SelRows.Count <= 0 Then
            XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            Dim _IDTempList As String = ""
            Dim _TempID(SelRows.Count) As String
            Dim _TempHoliday(SelRows.Count) As String
            Dim i As Integer = 0
            Dim MyChar() As Char = {","c, " "c, "|"c}
            For Each index As Integer In SelRows
                If index >= 0 Then
                    Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(index), DataRowView)
                    If CInt(SelectedRow("ID").ToString()) <> 3 Then
                        _TempID(i) = SelectedRow("ID").ToString()
                    End If
                    i += 1
                End If
            Next
            If i = 0 Then Exit Sub
            _IDTempList = String.Join(",", _TempID)
            _IDTempList = _IDTempList.TrimEnd(MyChar)

            detected = XtraMessageBox.Show("Require password change at next logon for the selected accounts?", "Block Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            SetAccountOptions(_IDTempList, 0, 0, 1)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPCopy_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPCopy.ItemClick
        Try
            With gvData
                Dim SelRows As Integer() = .GetSelectedRows()
                If SelRows.Count > 1 Then
                    XtraMessageBox.Show("Cannot copy multiple records to clipboard.", "No Record Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                My.Computer.Clipboard.SetText(.GetRowCellValue(.FocusedRowHandle, "UserCode").ToString)
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTrush_Click(sender As Object, e As EventArgs) Handles btnTrush.Click
        If SID = 0 Or String.IsNullOrEmpty(txtENName.Text.Trim) Then
            XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSID.Focus()
            Return
        ElseIf IsMainOwnerNotAllowToModify(SID) Then
            XtraMessageBox.Show(builtinAccMsg, "User Error?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSID.Focus()
            Return
        ElseIf IsOwnerCurrentLoggedIn(SID) AndAlso IsFatherChecked() Then
            XtraMessageBox.Show(disabledAccMsg, "Deactivate Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSID.Focus()
            Return
        End If

        detected = XtraMessageBox.Show("Want to remove this account?", "Remove Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If detected = DialogResult.No Then Return
        SetAccountOptions(SID.ToString, 0, 0, 0, 1)
    End Sub

    Private Sub bbiPViewUsername_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPViewUsername.ItemClick
        Try
            With gvData
                Dim SelRows As Integer() = .GetSelectedRows()
                If SelRows.Count > 1 Then
                    XtraMessageBox.Show("Cannot copy multiple records to clipboard.", "No Record Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                Me.Cursor = Cursors.WaitCursor
                gcData.Cursor = Cursors.WaitCursor
                Dim SelectedRow As DataRowView = DirectCast(gvData.GetRow(gvData.FocusedRowHandle), DataRowView)
                If CInt(.GetRowCellValue(.FocusedRowHandle, "ID").ToString) <> 3 Then _TempUser = Decrypt(.GetRowCellValue(.FocusedRowHandle, "UserID").ToString)

                If Not String.IsNullOrEmpty(_TempUser) Then
                    Dim frm As New frmViewUsename
                    frm.StartPosition = FormStartPosition.Manual
                    frm.Location = New Point(Cursor.Position.X - frm.Width, Cursor.Position.Y)
                    frm.ShowDialog()
                End If
                Me.Cursor = Cursors.Default
                gcData.Cursor = Cursors.Default
                txtSID.Focus()
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class