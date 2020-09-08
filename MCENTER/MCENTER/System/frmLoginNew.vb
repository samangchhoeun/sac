Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Alerter
Imports DevExpress.XtraEditors

Public Class frmLoginNew
    Dim configureDataAccess As IConfigurationDataAccess(Of LoginConfiguration)
    Dim Change_Pass_NextLog As Integer
    Dim Disabled_Acc As Integer
    Friend IsSaveLogin As Boolean = False
    Dim fUpdate As frmNewSoftwareUpdate
    Dim p() As Process

    Private Sub CheckIfRunning()
        'Application can run one at a time.
        p = Process.GetProcessesByName(IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath))
        If p.Count > 1 Then Application.Exit()
    End Sub

    Private Sub lblForgotPassword_Click(sender As Object, e As EventArgs) Handles lblForgotPassword.Click
        'XtraMessageBox.Show("Please contact us At samangchhoeun@gmail.com." & vbCrLf & "System is developed by Sam Ang Chhoeun.", "Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadFormDialog(frmForgetPassword)
    End Sub

    Private Sub frmLoginNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Opacity = 0        GetDataToComboBoxWithParam(lueLanguage, "SA_GetNationalityList", "ID", "Nationality")        
        CheckIfRunning()
        Dim random As New Random
        Dim answer As Integer = random.Next(1, 100)
        GetWindowsTheme(answer)
        LoadRememberLogin()
        RemotePath = ConfigurationPath.ReadConfig(frmAddRemotePath.ConfigFilePath)
        If String.IsNullOrEmpty(RemotePath) Then
            LoadFormDialog(frmAddRemotePath)
            ' Application.Exit()
        End If

        LoadDBConnection()
        If IsConnectedDB Then
            GetDataToComboBoxWithParam(lueLanguage, "SA_GetLanguages", "ID", "Language")
            lueLanguage.ItemIndex = 0
            'txtUserID.Properties.MaskBoxPadding = New Padding(25, 3, 0, 3)
            'txtPwd.Properties.MaskBoxPadding = New Padding(25, 3, 0, 3)
            txtUserID.Properties.MaskBoxPadding = New Padding(25, 0, 0, 0)
            txtPwd.Properties.MaskBoxPadding = New Padding(25, 0, 0, 0)
            lueLanguage.Properties.MaskBoxPadding = New Padding(25, 0, 0, 0)

            Dim MyAutoUpdate As New AutoUpdate
            'CheckForUpdate = True
            If MyAutoUpdate.IsRequiredUpdate Then
                'XtraMessageBox.Show(IIf(String.IsNullOrEmpty(LatestAppVersion), "", "Software update " + LatestAppVersion + vbNewLine + vbNewLine).ToString + "A new verion of " + Application.ProductName + " is available." + vbCrLf + vbCrLf + "Your software will be updated now...", "Software Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.DoEvents()
                fUpdate = New frmNewSoftwareUpdate
                fUpdate.StartPosition = FormStartPosition.CenterScreen
                fUpdate.ShowDialog()
                frmUpdateProgress.ShowDialog()
            Else
                'Call RefreshConn()
            End If

            lblVersion.Text = "Ver: " + systemVersion
            lblDateTime.Text = TimeIO.GetSystemDateTime()
            CheckAccessCode()

            Try
                ConfigClinic = ConfigurationDataAccess(Of ClinicConfiguration).GetConfiguration(StoreConfigPath)
                If Not IsNothing(ConfigClinic) Then
                    lblStore.Text = ConfigClinic.Clinic
                Else
                    lblStore.Text = "Clinic: None "
                    'XtraMessageBox.Show("You are required to set default clinic and building. ", "Set Default Clinic", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmSetDefaultStore._IsDefaultOpen = False
                    LoadFormDialog(frmSetDefaultStore)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub LoadRememberLogin()
        Try
            Dim ConfigLogin As LoginConfiguration = ConfigurationDataAccess(Of LoginConfiguration).GetConfiguration(LoginConfigPath)
            If Not IsNothing(ConfigLogin) Then
                txtUserID.Text = ConfigLogin.Username
                txtPwd.Text = ConfigLogin.Password
                lueLanguage.EditValue = ConfigLogin.Lang
                chkRemember.Checked = ConfigLogin.IsRemember
            Else
                ClearAllContent()
            End If
            txtUserID.Select()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'txtUserID.Text = Encrypt("RootUserSAC")
        'txtUserID.Text = GenEncryptPassword(txtPwd.Text)        
        ValidateLogin()
    End Sub

    Private Sub GetWindowsTheme(Optional ind As Integer = 0)
        Dim Col As New Color
        If ind < 20 Then
            Col = Color.LightSlateGray
        ElseIf ind < 40 Then
            Col = Color.DarkGray
        ElseIf ind < 60 Then
            Col = Color.SeaGreen
        ElseIf ind < 80 Then
            Col = Color.SandyBrown
        Else
            Col = Color.SlateGray
        End If

        Appearance.BackColor = Col
    End Sub

    Private Sub ValidateLogin()
        If IsSaveLogin Then RememberLogin(CBool(chkRemember.Checked))

        Dim L_User As String = Encrypt(txtUserID.Text.Trim.ToLower)
        Dim L_Pass As String = GenEncryptPassword(txtPwd.Text.Trim)
        Try
            If String.CompareOrdinal(_DBConfigUser.ToLower, L_User.ToLower) = 0 AndAlso String.CompareOrdinal(_DBConfigPass.ToLower, L_Pass.ToLower) = 0 Then
                LoadFormDialog(frmDatabase)
                ClearAllContent()
                Exit Sub
            End If

            Using UserLogin As DataTable = GetDataFromDBToTable("SA_GetExistingUserLogin",
                                                                    New SqlParameter("@UserID", L_User),
                                                                    New SqlParameter("@Pwd", L_Pass),
                                                                    New SqlParameter("@KC", SAC))
                With UserLogin
                    If .Rows.Count = 1 Then
                        LogUserID = Decrypt(.Rows(0)("UserID").ToString)
                        LogPass = .Rows(0)("Pass").ToString
                        LogUserNo = CInt(.Rows(0)("UserNo").ToString)
                        LogRoleID = CInt(.Rows(0)("RoleID").ToString)
                        AccountName = .Rows(0)("Name").ToString
                        'LastLoggedIn = .Rows(0)("VisitedAt").ToString
                        Disabled_Acc = CInt(.Rows(0)("Disabled_Acc"))
                        Change_Pass_NextLog = CInt(.Rows(0)("Change_Pass_NextLog"))
                        LogClinicID = CInt(.Rows(0)("ClinicID"))
                        'LogDivisionID = CInt(.Rows(0)("DivisionID"))
                        LogDeptID = CInt(.Rows(0)("DepartmentID"))
                        LogCampusID = CInt(.Rows(0)("CampusID"))
                        User_Cannot_Change_Pass = CInt(.Rows(0)("User_Cannot_Change_Pass"))
                        lang = lueLanguage.Text.Trim
                        'MessageBox.Show(Change_Pass_NextLog.ToString)
                        If Disabled_Acc <> 0 Then
                            XtraMessageBox.Show("Your account has been disabled. Your account will be permanently deleted in 90 days." + vbCrLf + vbCrLf + "Please see your system administrator.", "Warining!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtUserID.Focus()
                            Return
                        ElseIf Change_Pass_NextLog <> 0 AndAlso User_Cannot_Change_Pass = 0 Then
                            XtraMessageBox.Show("You are required to change password at first logon.", "Logon Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Hide()
                            frmChangePassword.Show()
                        Else
                            Hide()
                            frmWelcomePage.Show()
                            ' frmMainProject.Show()
                        End If
                    Else
                        Dim info As AlertInfo = New AlertInfo("Login Fail", "Username " + txtUserID.Text.Trim + " is not valid." + vbNewLine + vbNewLine + "Please try another username or password.")
                        AlertControl1.Show(Me, info)
                        XtraMessageBox.Show("The username or password is incorrect.", "Login Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ClearAllContent()
                    End If
                End With
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("System Error: " + ex.Message + "." + vbNewLine + "Please see your system administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'ClearAllContent()
        txtUserID.Focus()
    End Sub

    Private Sub RememberLogin(Optional En As Boolean = True)
        Try
            configureDataAccess = New ConfigurationDataAccess(Of LoginConfiguration)(LoginConfigPath)
            Dim Config As New LoginConfiguration
            With Config
                If En Then
                    .Username = txtUserID.Text.Trim.ToLower
                    .Password = txtPwd.Text.Trim
                    .Lang = CInt(lueLanguage.EditValue)
                    .IsRemember = CBool(chkRemember.EditValue)
                    .SaveDate = Now.ToString
                    configureDataAccess.Save(Config)
                Else
                    configureDataAccess.Delete()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub picMJQE_Click(sender As Object, e As EventArgs)
        txtUserID.Focus()
    End Sub

    Public Sub ClearAllContent()
        txtUserID.Text = ""
        txtPwd.Text = ""
        lueLanguage.EditValue = 1
        chkRemember.Checked = False
        txtUserID.Focus()
    End Sub

    Private Sub txtUserID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(txtUserID.Text.Trim) AndAlso Not String.IsNullOrEmpty(txtPwd.Text.Trim) Then
                ValidateLogin()
            ElseIf Not String.IsNullOrEmpty(txtUserID.Text.Trim) Then
                txtPwd.Select()
            End If
        End If
    End Sub

    Private Sub txtPwd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPwd.KeyDown
        If e.KeyCode = Keys.Enter Then If Not String.IsNullOrEmpty(txtPwd.Text.Trim) And Not String.IsNullOrEmpty(txtUserID.Text.Trim) Then ValidateLogin()
    End Sub

    'Private Sub lblAboutDeveloper_Click(sender As Object, e As EventArgs)
    '    LoadFormDialog(frmAboutDevelopers)
    'End Sub

    Private Sub btnClose_MouseClick(sender As Object, e As MouseEventArgs) Handles btnClose.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Left Then ppMenuPopup.ShowPopup(Me.bmMenuPopup, Control.MousePosition)
    End Sub

    Private Sub bbiClear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClear.ItemClick
        ClearAllContent()
    End Sub

    Private Sub bbiPClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPClose.ItemClick
        timLoading.Stop()
        timPopupForm.Stop()
        ''added November 05, 2019
        If p.Count > 0 Then Process.GetProcessesByName(IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath))(0).Kill()
        Application.Exit()
    End Sub

    Private Sub timPopupForm_Tick(sender As Object, e As EventArgs) Handles timPopupForm.Tick
        If Opacity < 100 Then
            Opacity += 0.1
        Else
            timPopupForm.Stop()
        End If
    End Sub

    Private Sub picLogo_Click(sender As Object, e As EventArgs) Handles picLogo.Click
        txtUserID.Focus()
    End Sub

    Private Sub timLoading_Tick(sender As Object, e As EventArgs) Handles timLoading.Tick
        lblDateTime.Text = TimeIO.GetSystemDateTime()
    End Sub

    Private Sub chkRemember_Modified(sender As Object, e As EventArgs) Handles chkRemember.Modified
        IsSaveLogin = True
    End Sub

    Private Sub lblDateTime_Click(sender As Object, e As EventArgs) Handles lblDateTime.Click
        LoadFormDialog(frmNewMessageAlert)
    End Sub
End Class