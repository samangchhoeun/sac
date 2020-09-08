Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmResetUserLogPass
    Private Old_Password As String = ""

    Private Sub frmResetUserLogPass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserLogToList()
        ClearAllContent()
        txtSID.Text = ""
        txtSID.Focus()
    End Sub

    Private Sub ClearAllContent()
        txtEmpID.Text = ""
        txtENName.Text = ""
        ClearContentIfNew()
    End Sub

    Private Sub ClearContentIfNew()
        txtNumber.Text = ""
        txtUserID.Text = ""
        chkUserCannotChangePass.Checked = False
        txtUserID.ReadOnly = False
        txtConfirmPass.Text = ""
        txtPass.Text = ""
        'ShowUpdateFooterNote(False)
        'ShowAddFooterNote(False)
    End Sub

    'Private Sub ShowUpdateFooterNote(Optional ByVal en As Boolean = True)
    '    If Not en Then
    '        txtUpdatedBy.Text = ""
    '        txtUpdatedDate.Text = ""
    '    End If
    '    txtUpdatedBy.Visible = en
    '    lblUpdatedBy.Visible = en
    '    txtUpdatedDate.Visible = en
    '    lblUpdatedDate.Visible = en
    'End Sub

    'Private Sub ShowAddFooterNote(Optional ByVal en As Boolean = True)
    '    If Not en Then
    '        txtCreatedBy.Text = ""
    '        txtCreatedDate.Text = ""
    '    End If

    '    lblCreatedBy.Visible = en
    '    txtCreatedBy.Visible = en
    '    lblCreatedDate.Visible = en
    '    txtCreatedDate.Visible = en
    'End Sub


    'Private Sub getFooterNote(useradd As String, dateadd As String, userupdate As String, dateupdate As String)
    '    If String.IsNullOrEmpty(useradd) OrElse String.IsNullOrEmpty(dateadd) Then
    '        ShowAddFooterNote(False)
    '    Else
    '        txtCreatedBy.Text = useradd
    '        txtCreatedDate.Text = dateadd
    '        ShowAddFooterNote()
    '    End If

    '    If String.IsNullOrEmpty(userupdate) OrElse String.IsNullOrEmpty(dateupdate) Then
    '        ShowUpdateFooterNote(False)
    '    Else
    '        txtUpdatedBy.Text = userupdate
    '        txtUpdatedDate.Text = dateupdate
    '        ShowUpdateFooterNote()
    '    End If
    'End Sub

    Private Sub LoadUserLogToList()
        AutoCompleteID(txtSID, "SA_GetUserLogIDList", New SqlParameter("@Admin", isLoggedInOwner))
    End Sub

    Private Sub ClearPasswordBox()
        txtPass.Text = ""
        txtConfirmPass.Text = ""
        txtPass.Focus()
    End Sub


    Private Sub EnabledButtonSave(Optional en As Boolean = True)
        btnSave.Enabled = en
    End Sub

    Private Sub frmResetUserLogPass_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        'LoadUserLogToList()
    End Sub

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim Find_ID As String = txtSID.Text.Trim
            ClearAllContent()

            If String.IsNullOrEmpty(Find_ID) Then
                XtraMessageBox.Show("Please enter Employee ID before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSID.Focus()
                Return
            End If

            SelectUserLogRec(Find_ID)
        End If
    End Sub

    Private Sub SelectUserLogRec(Find_ID As String)
        Try
            Dim dbDataList As DataTable = GetDataFromDBToTable("SA_GetUserAccountByID", New SqlParameter("@CardID", Find_ID), New SqlParameter("@KC", SAC))
            With dbDataList
                If .Rows.Count = 1 Then
                    txtEmpID.Text = .Rows(0)("CardID").ToString
                    txtENName.Text = .Rows(0)("Name").ToString
                    txtNumber.Text = .Rows(0)("UserNo").ToString
                    txtUserID.Text = Decrypt(.Rows(0)("UserID").ToString)
                    Old_Password = .Rows(0)("Pass").ToString

                    EnabledButtonSave(False)

                    SID = CInt(.Rows(0)("UserNo"))
                    If IsMainOwnerAllowModifyOthers() OrElse IsOwnerAllowModifyOthers(SID) Then EnabledButtonSave(True)

                    chkChangePassNextLog.Checked = CBool(.Rows(0)("Change_Pass_NextLog"))
                    chkUserCannotChangePass.Checked = CBool(.Rows(0)("User_Cannot_Change_Pass"))
                    'Dim UserCreate As String = .Rows(0)("UserCreate").ToString
                    'Dim DateCreate As String = .Rows(0)("DateCreate").ToString
                    'Dim UserUpdate As String = .Rows(0)("UserUpdate").ToString
                    'Dim DateUpdate As String = .Rows(0)("DateUpdate").ToString

                    'getFooterNote(UserCreate, DateCreate, UserUpdate, DateUpdate)
                    txtPass.Focus()
                Else
                    ClearAllContent()
                    XtraMessageBox.Show("Searching keyword: " + txtSID.Text.Trim + " doesnot exist on the target system.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtSID.Focus()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + " . Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'close connection if open
        CloseCon(Con)
    End Sub

    Private Sub chkUserCannotChangePass_CheckStateChanged(sender As Object, e As EventArgs) Handles chkUserCannotChangePass.CheckStateChanged
        EnabledCheckAcc(CBool(chkUserCannotChangePass.Checked))
    End Sub

    Private Sub EnabledCheckAcc(Optional en As Boolean = False)
        chkChangePassNextLog.Enabled = Not en
        If en Then
            chkChangePassNextLog.Checked = False
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        EnabledButtonSave(False)
        txtSID.Text = ""
        txtSID.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Password As String = ""
        If Not String.IsNullOrEmpty(txtNumber.Text.Trim) Then SID = CInt(txtNumber.Text.Trim)

        If String.IsNullOrEmpty(txtPass.Text.Trim) OrElse String.IsNullOrEmpty(txtConfirmPass.Text.Trim) Then
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
        ElseIf IsMainOwnerNotAllowToModify(SID) Then
            XtraMessageBox.Show(builtinAccMsg, "User Error?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSID.Focus()
            Return
        End If

        Try
            Password = GenEncryptPassword(txtPass.Text.Trim)
            Dim _CardID As String = txtEmpID.Text.Trim.ToUpper
            Dim NewInsertID As Integer = CInt(txtNumber.Text.Trim)

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_ResetUserAccountPass", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@UserNo", NewInsertID)
                .AddWithValue("@CardID", _CardID)
                .AddWithValue("@Pass", Password)
                .AddWithValue("@Change_Pass_NextLog", chkChangePassNextLog.Checked)
                .AddWithValue("@User_Cannot_Change_Pass", chkUserCannotChangePass.Checked)
                .AddWithValue("@User", AccountName)
                .Add("@IsChange", SqlDbType.Int)
                cmd.Parameters("@IsChange").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim MMS As MessageBoxIcon
            Dim IsChanged As Integer = Convert.ToInt16(cmd.Parameters("@IsChange").Value)

            If IsChanged <> 0 Then
                EnabledButtonSave(False)
                'IsResetPass = 1
                MMS = MessageBoxIcon.Information
            Else
                txtUserID.Focus()
                MMS = MessageBoxIcon.Error
            End If

            'LoadUserLogToList()
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Reset Password", MessageBoxButtons.OK, MMS)
            txtPass.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmResetUserLogPass_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class