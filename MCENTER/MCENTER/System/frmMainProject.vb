Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Localization
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.LookAndFeel.DefaultLookAndFeel
Imports System.IO
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Alerter

Public Class frmMainProject
    Dim _tCount As Integer = 0
    Dim _isRequiredClose As Boolean = True
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property

    Private Sub bbiExit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiFileExit.ItemClick
        _isRequiredClose = False
        ExitProgram()
    End Sub

    Private Sub ExitProgram()
        detected = XtraMessageBox.Show("Do you want to close this program?" & vbCrLf & vbCrLf & "Make sure that you have saved all your information.", "Closing Program?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If detected = DialogResult.Yes Then
            timDateTime.Stop()
            timLoading.Stop()
            frmNewMessageAlert.Dispose()
            Application.Exit()
        End If
    End Sub

    Public Sub frmMainProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Skins()
        bsiDateTime.Caption = TimeIO.GetSystemDateTime()
        rpgAbout.Text = Application.ProductName + " v" + systemVersion
        bbiInfo.Caption = Application.ProductName + " v" + systemVersion
        If Not (String.IsNullOrEmpty(AccountName)) Then
            bsiServer.Caption = ServerName
            bsiVersion.Caption = "Ver: " + systemVersion
            bsiLoggedInAs.Caption = "Logged in as " + AccountName
            bsiUserLogin.Caption = AccountName
            bsiLastLoggedIn.Caption = "Last Logged in " + Date.Now.ToString
            bsiBuilding.Visibility = BarItemVisibility.Never
            If Not IsNothing(ConfigClinic) Then
                bsiClinic.Caption = ConfigClinic.Clinic
                bsiBuilding.Caption = ConfigClinic.Building
            Else
                bsiClinic.Caption = "Clinic: None"
                bsiBuilding.Caption = "Building: None"
            End If
            bbiSubLogout.Visibility = BarItemVisibility.Always
            bsiLoggedInRequired.Visibility = BarItemVisibility.Never
            Try
                ConfigPrinter = ConfigurationDataAccess(Of PrinterConfiguration).GetConfiguration(PrinterConfigPath)
            Catch ex As Exception

            End Try
        Else
            bsiLoggedInRequired.Visibility = BarItemVisibility.Always
            bsiLoggedInAs.Visibility = BarItemVisibility.Never
            bbiSubLogout.Visibility = BarItemVisibility.Never
        End If

        If lang = "English" Then
            bbiPKhmer.Caption = "ភាសាខ្មែរ"
            bbiPKhmer.Glyph = My.Resources.Khmer
            bsiEnglish.Caption = "English"
            bsiEnglish.Glyph = My.Resources.English
        Else

            bsiEnglish.Caption = "ភាសាខ្មែរ"
            bsiEnglish.Glyph = My.Resources.Khmer
            bbiPKhmer.Caption = "English"
            bbiPKhmer.Glyph = My.Resources.English
        End If

        If Not IsSystemOwner(LogUserNo, AccountName, LogUserID) Then SetAvailableControl()

        timCheckAlert.Enabled = True

        'AddActivityHandler(Me)
        'AddHandler Me.MouseDown, AddressOf NonActivityTimerStop
        'AddHandler Me.KeyDown, AddressOf NonActivityTimerStop
        'NonActivityTimer.Start()
    End Sub

    Public Sub Skins()
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(My.Settings.ApplicationSkinName)
    End Sub

    Private Sub bbiChangePassword_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiChangePassword.ItemClick
        If isResetPass = 1 Then
            XtraMessageBox.Show("Your password has been reset. Please re-login to active.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf User_Cannot_Change_Pass = 0 Then
            LoadFormDialog(frmResetPassword)
        Else
            XtraMessageBox.Show("You cannot reset password for this limited user.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub bbiExitProgram_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiExitProgram.ItemClick
        _isRequiredClose = False
        ExitProgram()
    End Sub

    Private Sub frmMainProject_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            SqlConnection.ClearAllPools()
            Con.Close()
            OpenCon(Con)
            Dim cmd1 As New SqlCommand("SA_RecordUserLogout", Con)
            cmd1.CommandType = CommandType.StoredProcedure
            cmd1.Parameters.AddWithValue("@ID", CInt(LogUserNo))
            cmd1.ExecuteNonQuery()
            cmd1.Dispose()
            Con.Close()
            Con = Nothing
        Catch ex As Exception
            XtraMessageBox.Show("System Error: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        isResetPass = 0
        IsUserOpen = False
        Application.Exit()
    End Sub

    Private Sub frmMainProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If _isRequiredClose Then
            Beep()
            e.Cancel = True
        End If
        My.Settings.ApplicationSkinName = UserLookAndFeel.LookAndFeel.ActiveSkinName
        My.Settings.Save()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiProduct.ItemClick
        XtraMessageBox.Show("The product is licensed to PreemBell Group.", "License", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub bbiInfo_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiInfo.ItemClick
        'XtraMessageBox.Show("Product Name: MJQE Employee MS v" & SystemVersion & vbCrLf & vbCrLf & "Developed by: Sam Ang Chhoeun, MEng.", "About?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadFormDialog(frmAboutMJQEEMS)
    End Sub

    Private Sub bbiLogout_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiLogout.ItemClick
        Logout()
    End Sub

    Private Sub bbiDatabase_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDatabase.ItemClick
        If Not IsAccessAllowed(e.Item.Name, 1) AndAlso Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadFormDialog(frmDatabase)
    End Sub

    Private Sub bbiResetPassword_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiResetPassword.ItemClick
        If Not IsAccessAllowed(e.Item.Name, 1) AndAlso Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadDialogFormAfterAuthorized(frmResetUserLogPass)
    End Sub

    Private Sub bbiChangePass_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiChangePass.ItemClick
        If isResetPass = 1 Then
            XtraMessageBox.Show("Your password has been reset. Please re-login to active.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf User_Cannot_Change_Pass = 0 Then
            LoadFormDialog(frmResetPassword)
        Else
            XtraMessageBox.Show("You cannot reset password for this limited user.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub bbiBanUserAccounts_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiManageRoles.ItemClick
        If Not IsAccessAllowed(e.Item.Name, 1) AndAlso Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadForm(frmViewUserRoles)
    End Sub

    Private Sub LoadFormAfterAuthorized(f As Form)
        If isLoggedInOwner Then
            LoadForm(f)
        Else
            If isAuthForm = 1 Then
                LoadForm(f)
            Else
                LoadFormDialog(frmAuthAccess)
                If isAuthorized = 1 Then
                    LoadForm(f)
                End If
            End If
        End If
    End Sub

    Private Sub LoadDialogFormAfterAuthorized(f As Form)

        If isLoggedInOwner Then
            LoadFormDialog(f)
        Else
            If isAuthForm = 1 Then
                LoadFormDialog(f)
            Else
                LoadFormDialog(frmAuthAccess)
                If isAuthorized = 1 Then
                    LoadFormDialog(f)
                End If
            End If
        End If
    End Sub

    Private Sub bbiGroups_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiGroups.ItemClick
        If Not IsAccessAllowed(e.Item.Name, 1) AndAlso Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadFormAfterAuthorized(frmGroupAccounts)
    End Sub

    Private Sub bbISystemControls_ItemClick(sender As Object, e As ItemClickEventArgs)
        LoadFormAfterAuthorized(frmControls)
    End Sub

    Private Sub bbiUserPrivileges_ItemClick(sender As Object, e As ItemClickEventArgs)
        'LoadFormAfterAuthorized(frmUserPrivileges)
        MessageBox.Show("HELLO")
    End Sub

    Private Sub bbiGroupPermissions_ItemClick(sender As Object, e As ItemClickEventArgs)
        MessageBox.Show("HELLO")
        'LoadFormAfterAuthorized(frmGroupPermissions)
    End Sub

    Private Sub bbiFileLogout_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiFileLogout.ItemClick
        Logout()
    End Sub

    Private Sub Logout()
        detected = XtraMessageBox.Show("Do you want to logout from this user account?" & vbCrLf & vbCrLf & "Make sure that you have saved all your data.", "Logout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If detected = DialogResult.Yes Then
            timDateTime.Stop()
            timLoading.Stop()
            frmNewMessageAlert.Dispose()
            'NonActivityTimer.Stop()
            IsUserOpen = False
            SqlConnection.ClearAllPools()
            ' Con.Close() 'just add on August 25, 2018
            CloseCon(Con)
            ' Con = Nothing
            Dispose()
            LoadRememberLogin() ''Update 01/05/2020
            'With frmLoginWindows
            '    .txtUserID.Text = ""
            '    .txtPwd.Text = ""
            '    .txtUserID.Select()
            '    .Show()
            'End With
        End If
    End Sub

    ''Update 01/05/2020
    Private Sub LoadRememberLogin()
        Try
            Dim ConfigLogin As LoginConfiguration = ConfigurationDataAccess(Of LoginConfiguration).GetConfiguration(LoginConfigPath)
            With frmLoginWindows
                If Not IsNothing(ConfigLogin) Then
                    .txtUserID.Text = ConfigLogin.Username
                    .txtPwd.Text = ConfigLogin.Password
                    .lueLanguage.EditValue = ConfigLogin.Lang
                    .chkRemember.Checked = ConfigLogin.IsRemember
                    '.btnLogin.Select()
                Else
                    .ClearAllContent()
                    '.txtUserID.Select()
                End If
                .txtUserID.Select()
                .IsSaveLogin = False
                .Show()
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bsiServer_ItemDoubleClick(sender As Object, e As ItemClickEventArgs) Handles bsiServer.ItemDoubleClick
        LoadFormDialog(frmDatabase)
    End Sub

    Private Sub bbiUserRoles_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiUserAuthentication.ItemClick
        If Not IsAccessAllowed(e.Item.Name, 1) AndAlso Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadForm(frmUserRoles)
    End Sub

    Private Sub bbiAddRemotePath_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiAddRemotePath.ItemClick
        If Not IsAccessAllowed(e.Item.Name, 1) AndAlso Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadFormDialog(frmAddRemotePath)
    End Sub

    Private Sub bbiUpdateSoftwareVersion_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiUpdateSoftwareVersion.ItemClick
        Dim _ftpClient As New FTPClient
        If Not _ftpClient.CheckFTPConnection(3, 5) Then
            detected = XtraMessageBox.Show("FTP connection is unlinked. Please check the FTP Settings." + vbNewLine + "Do you want to configure FTP Settings?", "Unlink FTP Connection", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If detected = DialogResult.No Then Exit Sub
            LoadForm(frmFTPSettings)
        Else
            LoadFormDialog(frmUpdateAppVersion)
        End If
    End Sub

    Private Sub bbiHelp_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiHelp.ItemClick
        XtraMessageBox.Show(Application.ProductName + " v" & systemVersion & " is powered by PreemBell Group on July 27, 2020." & vbCrLf & vbCrLf & "For further details, please contact us At samangchhoeun@gmail.com.", "Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Dim t As String = ""
        'For Each f As Form In Application.OpenForms
        '    t += f.Name + "-"
        'Next
        'MessageBox.Show(t)
    End Sub

    Private Sub bbiCheckForUpdates_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiCheckForUpdates.ItemClick
        LoadFormDialog(frmCheckForUpdates)
    End Sub

    Private Sub bbiSubLogout_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSubLogout.ItemClick
        Logout()
    End Sub

    Private Sub bbiFTPSettings_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiFTPSettings.ItemClick
        If Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadForm(frmFTPSettings)
    End Sub

    Private Sub bbiControls_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiControls.ItemClick
        If Not IsAccessAllowed(e.Item.Name, 1) AndAlso Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadForm(frmControls)
    End Sub

    Private Sub bbiLockScreen_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiLockScreen.ItemClick
        LoadFormDialog(frmLockScreen)
    End Sub

    Private Sub bbiBLock_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiBLock.ItemClick
        LoadFormDialog(frmLockScreen)
    End Sub

    Private Sub bsiVersion_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bsiVersion.ItemClick
        LoadFormDialog(frmUpdateAppVersion)
    End Sub

    Private Sub timDateTime_Tick(sender As Object, e As EventArgs) Handles timDateTime.Tick
        bsiDateTime.Caption = TimeIO.GetSystemDateTime()
    End Sub

    Private Sub bbiUserAccessPermission_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiUserAccessPermission.ItemClick
        If Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        LoadForm(frmAssignUserAccessRoles)
    End Sub

    Private Sub bbiPositions_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPositions.ItemClick
        If Not IsAccessAllowed(e.Item.Name, 1) AndAlso Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        LoadForm(frmViewPositions)
    End Sub

    Private Sub bbiUserAccounts_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiUserAccounts.ItemClick
        If Not IsAccessAllowed(e.Item.Name, 1) AndAlso Not isLoggedInOwner Then
            XtraMessageBox.Show("You do not have permission to access this section." + vbNewLine + vbNewLine + "Please contact System Administrator to verify your role.", "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadForm(frmUserAccounts)
    End Sub

    Private Sub bbiUserAccList_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiUserAccList.ItemClick
        LoadFormAfterAuthorized(frmAccountList)
    End Sub

    Private Sub bbiHolidayCalendar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiHolidayCalendar.ItemClick
        LoadForm(frmHolidayList)
    End Sub

    Private Sub bsiDateTime_ItemDoubleClick(sender As Object, e As ItemClickEventArgs) Handles bsiDateTime.ItemDoubleClick
        'If isLoggedInOwner Then
        '    Dim frm As New frmSetActivateTime
        '    frm.StartPosition = FormStartPosition.Manual
        '    frm.Location = New Point(Cursor.Position.X - frm.Width, Cursor.Position.Y)
        '    frm.ShowDialog()
        'End If
    End Sub

    Private Sub bbiPKhmer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPKhmer.ItemClick
        If bbiPKhmer.Caption = "ភាសាខ្មែរ" Then
            bsiEnglish.Caption = "ភាសាខ្មែរ"
            bsiEnglish.Glyph = My.Resources.Khmer
            bbiPKhmer.Caption = "English"
            bbiPKhmer.Glyph = My.Resources.English
        Else
            bbiPKhmer.Caption = "ភាសាខ្មែរ"
            bbiPKhmer.Glyph = My.Resources.Khmer
            bsiEnglish.Caption = "English"
            bsiEnglish.Glyph = My.Resources.English
        End If
    End Sub

    Private Sub bbiManageStaffDetails_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiManageStaffDetails.ItemClick
        LoadForm(frmEmployee)
    End Sub

    Private Sub bbiPHPatientMembershipList_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPHPatientMembershipList.ItemClick

    End Sub

    Private Sub bbiClinic_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiClinic.ItemClick
        LoadForm(frmViewClinic)
    End Sub

    Private Sub bbiDepartments_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDepartments.ItemClick
        LoadForm(frmViewDepartment)
    End Sub

    Private Sub bbiBuildings_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiBuildings.ItemClick
        LoadForm(frmViewBuilding)
    End Sub

    Private Sub bbiSections_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSections.ItemClick
        LoadForm(frmViewSection)
    End Sub

    Private Sub bbiCampuses_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiCampuses.ItemClick
        LoadForm(frmViewCampus)
    End Sub

    Private Sub bbiCambodiaAdminAreas_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiCambodiaAdminAreas.ItemClick
        LoadForm(frmCambodiaAdminAreas)
    End Sub

    Private Sub bbiAddPatient_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiAddPatient.ItemClick
        LoadForm(frmPatient)
    End Sub

    Private Sub timCheckAlert_Tick(sender As Object, e As EventArgs) Handles timCheckAlert.Tick
        timCheckAlert.Enabled = False
        ' frmNewMessageAlert.ShowAlert()
        frmNewMessageAlert.Show(Me)
    End Sub

    Private Sub bbiResetPassRequest_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiResetPassRequest.ItemClick

    End Sub

    Private Sub bbiSetDefaultClinic_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSetDefaultClinic.ItemClick
        LoadFormDialog(frmSetDefaultStore)
    End Sub

    Private Sub bbiSetDefaultPrinter_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSetDefaultPrinter.ItemClick
        LoadFormDialog(frmSetDefaultPrinter)
    End Sub

    Private Sub bbiExchangeRateSetting_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiExchangeRateSetting.ItemClick
        LoadFormDialog(frmExchangeRate)
    End Sub

    Private Sub bbiVATSetting_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiVATSetting.ItemClick
        LoadFormDialog(frmVAT)
    End Sub

    Private Sub bbiCorporateClient_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiCorporateClient.ItemClick
        LoadForm(frmViewCorporateClient)
    End Sub

    Private Sub bbiSupplier_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSupplier.ItemClick
        LoadForm(frmViewSupplier)
    End Sub

    Private Sub bbiDownloadClinicConfiguration_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDownloadClinicConfiguration.ItemClick
        If IsNothing(ConfigClinic) Then
            XtraMessageBox.Show("There is no default store configuration to export.", "Confirm Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            Dim dt As New DataTable
            dt.Columns.Add("ID")
            dt.Columns.Add("FieldName")
            dt.Columns.Add("ItemCode")
            dt.Columns.Add("Item")
            dt.Columns(0).AutoIncrementSeed = 1
            dt.Columns(0).AutoIncrement = True

            Dim R As DataRow = dt.NewRow
            R("FieldName") = "Clinic"
            R("ItemCode") = ConfigClinic.ClinicID
            R("Item") = ConfigClinic.Clinic

            Dim R1 As DataRow = dt.NewRow
            R1("FieldName") = "Building"
            R1("ItemCode") = ConfigClinic.BuildingID
            R1("Item") = ConfigClinic.Building

            Dim R2 As DataRow = dt.NewRow
            R2("FieldName") = "User Create"
            R2("ItemCode") = ""
            R2("Item") = ConfigClinic.UserCreate

            Dim R3 As DataRow = dt.NewRow
            R3("FieldName") = "Date Create"
            R3("ItemCode") = ""
            R3("Item") = ConfigClinic.DateCreate

            dt.Rows.Add(R)
            dt.Rows.Add(R1)
            dt.Rows.Add(R2)
            dt.Rows.Add(R3)

            ExportToXlsx(dt, "Default Clinic Configuration")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bbiDownloadPrinterConfiguration_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDownloadPrinterConfiguration.ItemClick
        Try
            If IsNothing(ConfigPrinter) Then
                XtraMessageBox.Show("There is no default printer configuration to export.", "Confirm Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim dt As New DataTable
            dt.Columns.Add("ID")
            dt.Columns.Add("FieldName")
            dt.Columns.Add("ItemCode")
            dt.Columns.Add("Item")
            dt.Columns(0).AutoIncrementSeed = 1
            dt.Columns(0).AutoIncrement = True

            Dim R As DataRow = dt.NewRow
            R("FieldName") = "Printer Name"
            R("ItemCode") = ConfigPrinter.PrinterID
            R("Item") = ConfigPrinter.PrinterName

            Dim R1 As DataRow = dt.NewRow
            R1("FieldName") = "Printer Type"
            R1("ItemCode") = ConfigPrinter.PrinterTypeID
            R1("Item") = ConfigPrinter.PrinterType

            Dim R2 As DataRow = dt.NewRow
            R2("FieldName") = "Paper Orientation"
            R2("ItemCode") = ConfigPrinter.PaperOrientationID
            R2("Item") = ConfigPrinter.PaperOrientation

            Dim R3 As DataRow = dt.NewRow
            R3("FieldName") = "Paper Size"
            R3("ItemCode") = ConfigPrinter.PaperSizeID
            R3("Item") = ConfigPrinter.PaperSize

            Dim R4 As DataRow = dt.NewRow
            R4("FieldName") = "Number of copies"
            R3("ItemCode") = ""
            R4("Item") = ConfigPrinter.NumberOfCopies

            Dim R5 As DataRow = dt.NewRow
            R5("FieldName") = "User Create"
            R5("ItemCode") = ""
            R5("Item") = ConfigPrinter.UserCreate

            Dim R6 As DataRow = dt.NewRow
            R6("FieldName") = "Date Create"
            R6("ItemCode") = ""
            R6("Item") = ConfigPrinter.DateCreate

            dt.Rows.Add(R)
            dt.Rows.Add(R1)
            dt.Rows.Add(R2)
            dt.Rows.Add(R3)
            dt.Rows.Add(R4)
            dt.Rows.Add(R5)
            dt.Rows.Add(R6)
            ExportToXlsx(dt, "Default Printer Configuration")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bbiPatientVisit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPatientVisit.ItemClick
        LoadForm(frmPatientVisit)
    End Sub

    Private Sub bbiDoctor_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDoctor.ItemClick
        LoadForm(frmViewDoctor)
    End Sub

    Private Sub bbiSetPatientReminder_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSetPatientReminder.ItemClick
        LoadForm(frmSetPatientReminder)
    End Sub

    Private Sub bbiPatientVitalSign_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPatientVitalSign.ItemClick
        LoadForm(frmPatientVitalSign)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        LoadForm(frmMembershipBaseBalance)
    End Sub

    Private Sub bbiDiagnosis_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDiagnosis.ItemClick
        LoadForm(frmViewDiagnosis)
    End Sub

    Private Sub bbiDiagnosisGroup_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDiagnosisGroup.ItemClick
        LoadFormDialog(frmViewDiagnosisGroup)
    End Sub

    Private Sub bbiMedicalTreatment_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMedicalTreatment.ItemClick
        LoadForm(frmViewMedicalTreatment)
    End Sub

    Private Sub bbiMembershipFee_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMembershipFee.ItemClick
        LoadForm(frmViewMembershipFee)
    End Sub

    Private Sub bbiMedicalForm_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMedicalForm.ItemClick
        LoadForm(frmViewMedicalForm)
    End Sub

    Private Sub bbiMedicalClassification_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMedicalClassification.ItemClick
        LoadForm(frmViewMedicalClassification)
    End Sub

    Private Sub bbiGenericName_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiGenericName.ItemClick
        LoadForm(frmViewGenericName)
    End Sub

    Private Sub bbiRxInstructionAbb_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiRxInstructionAbb.ItemClick
        LoadForm(frmViewRxInstructionAndAbbreviation)
    End Sub

    Private Sub bbiLabMeasurements_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiLabMeasurements.ItemClick
        frmLabMasterList.listType = "LabUnit"
        LoadFormDialog(frmLabMasterList)
    End Sub

    Private Sub bbiLabSection_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiLabSection.ItemClick
        frmLabMasterList.listType = "LabSection"
        LoadFormDialog(frmLabMasterList)
    End Sub

    Private Sub bbiLaboratory_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiLaboratory.ItemClick
        frmLabMasterList.listType = "Laboratory"
        LoadFormDialog(frmLabMasterList)
    End Sub

    Private Sub bbiGroupTest_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiGroupTest.ItemClick
        frmLabMasterList.listType = "GroupTest"
        LoadFormDialog(frmLabMasterList)
    End Sub

    Private Sub bbiFollowupSchedule_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiFollowupSchedule.ItemClick
        LoadForm(frmPatientScheduleFollowupView)
    End Sub

    Private Sub bbiViewPatient_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiViewPatient.ItemClick
        LoadForm(frmViewPatient)
    End Sub

    Private Sub bbiCheckPatient_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiCheckPatient.ItemClick
        LoadFormDialog(frmCaputreImage)
    End Sub

    Private Sub bbiPatientTreatment_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPatientTreatment.ItemClick
        LoadForm(frmPatientTreatment)
    End Sub

    Private Sub bbiPatientRx_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPatientRx.ItemClick
        LoadForm(frmPatientPrescription)
    End Sub

    Private Sub bbiShelf_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiShelf.ItemClick
        LoadFormDialog(frmViewShelf)
    End Sub

    Private Sub bbiMembershipServicePkg_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMembershipServicePkg.ItemClick
        LoadForm(frmMembershipServicePkg)
    End Sub

    Private Sub bbiStockCarts_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiStockCarts.ItemClick
        LoadForm(frmStockCarts)
    End Sub

    Private Sub bbiMedicationStockIn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMedicationStockIn.ItemClick
        LoadForm(frmMedicationStockIn)
    End Sub

    Private Sub bbiMedicationStockTransfer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMedicationStockTransfer.ItemClick
        LoadForm(frmMedicationStockTransfer)
    End Sub

    Private Sub bbiMedDispensary_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiMedDispensary.ItemClick
        LoadForm(frmMedicationDispensary)
    End Sub

    Private Sub bbiPLogoSetting_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPLogoSetting.ItemClick
        LoadFormDialog(frmUpdateLogoImage)
    End Sub
End Class