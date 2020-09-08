<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoginNew
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginNew))
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.lblVersion = New DevExpress.XtraEditors.LabelControl()
        Me.lblForgotPassword = New DevExpress.XtraEditors.LabelControl()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.ppMenuPopup = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.bbiClear = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bmMenuPopup = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiMAddUser = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPEditHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiMCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiDisableUser = New DevExpress.XtraBars.BarButtonItem()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.timPopupForm = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkRemember = New DevExpress.XtraEditors.CheckEdit()
        Me.lueLanguage = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtPwd = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtUserID = New DevExpress.XtraEditors.ButtonEdit()
        Me.btnLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.PictureEdit2 = New DevExpress.XtraEditors.PictureEdit()
        Me.picLogo = New DevExpress.XtraEditors.PictureEdit()
        Me.timLoading = New System.Windows.Forms.Timer(Me.components)
        Me.lblDateTime = New DevExpress.XtraEditors.LabelControl()
        Me.PictureEdit3 = New DevExpress.XtraEditors.PictureEdit()
        Me.lblStore = New DevExpress.XtraEditors.LabelControl()
        Me.AlertControl1 = New DevExpress.XtraBars.Alerter.AlertControl(Me.components)
        CType(Me.ppMenuPopup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenuPopup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.chkRemember.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueLanguage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblVersion
        '
        Me.lblVersion.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Appearance.Options.UseFont = True
        Me.lblVersion.Appearance.Options.UseForeColor = True
        Me.lblVersion.Appearance.Options.UseTextOptions = True
        Me.lblVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblVersion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblVersion.Location = New System.Drawing.Point(133, 374)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(131, 13)
        Me.lblVersion.TabIndex = 34
        Me.lblVersion.Text = "Version"
        '
        'lblForgotPassword
        '
        Me.lblForgotPassword.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblForgotPassword.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForgotPassword.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblForgotPassword.Appearance.Options.UseBackColor = True
        Me.lblForgotPassword.Appearance.Options.UseFont = True
        Me.lblForgotPassword.Appearance.Options.UseForeColor = True
        Me.lblForgotPassword.Location = New System.Drawing.Point(150, 187)
        Me.lblForgotPassword.Name = "lblForgotPassword"
        Me.lblForgotPassword.Size = New System.Drawing.Size(77, 17)
        Me.lblForgotPassword.TabIndex = 4
        Me.lblForgotPassword.Text = "Forgot Password?"
        '
        'btnClose
        '
        Me.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnClose.Location = New System.Drawing.Point(4, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnClose.Size = New System.Drawing.Size(24, 24)
        Me.btnClose.TabIndex = 56
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl2.Appearance.Options.UseBackColor = True
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(0, 1)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(270, 5)
        Me.LabelControl2.TabIndex = 57
        '
        'ppMenuPopup
        '
        Me.ppMenuPopup.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiClear, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPClose, True)})
        Me.ppMenuPopup.Manager = Me.bmMenuPopup
        Me.ppMenuPopup.Name = "ppMenuPopup"
        '
        'bbiClear
        '
        Me.bbiClear.Caption = "Clear"
        Me.bbiClear.Glyph = CType(resources.GetObject("bbiClear.Glyph"), System.Drawing.Image)
        Me.bbiClear.Id = 4
        Me.bbiClear.LargeGlyph = CType(resources.GetObject("bbiClear.LargeGlyph"), System.Drawing.Image)
        Me.bbiClear.Name = "bbiClear"
        '
        'bbiPClose
        '
        Me.bbiPClose.Caption = "Close"
        Me.bbiPClose.Glyph = CType(resources.GetObject("bbiPClose.Glyph"), System.Drawing.Image)
        Me.bbiPClose.Id = 5
        Me.bbiPClose.LargeGlyph = CType(resources.GetObject("bbiPClose.LargeGlyph"), System.Drawing.Image)
        Me.bbiPClose.Name = "bbiPClose"
        '
        'bmMenuPopup
        '
        Me.bmMenuPopup.DockControls.Add(Me.barDockControlTop)
        Me.bmMenuPopup.DockControls.Add(Me.barDockControlBottom)
        Me.bmMenuPopup.DockControls.Add(Me.barDockControlLeft)
        Me.bmMenuPopup.DockControls.Add(Me.barDockControlRight)
        Me.bmMenuPopup.Form = Me
        Me.bmMenuPopup.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiMAddUser, Me.bbiPEditHoliday, Me.bbiMCancel, Me.bbiDisableUser, Me.bbiClear, Me.bbiPClose})
        Me.bmMenuPopup.MaxItemId = 6
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(270, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 394)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(270, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 394)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(270, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 394)
        '
        'bbiMAddUser
        '
        Me.bbiMAddUser.Caption = "Add User"
        Me.bbiMAddUser.Id = 0
        Me.bbiMAddUser.ImageUri.Uri = "AddItem"
        Me.bbiMAddUser.Name = "bbiMAddUser"
        '
        'bbiPEditHoliday
        '
        Me.bbiPEditHoliday.Caption = "Edit Holiday"
        Me.bbiPEditHoliday.Id = 1
        Me.bbiPEditHoliday.ImageUri.Uri = "Edit"
        Me.bbiPEditHoliday.Name = "bbiPEditHoliday"
        '
        'bbiMCancel
        '
        Me.bbiMCancel.Caption = "Cancel"
        Me.bbiMCancel.Id = 2
        Me.bbiMCancel.ImageUri.Uri = "Refresh"
        Me.bbiMCancel.Name = "bbiMCancel"
        '
        'bbiDisableUser
        '
        Me.bbiDisableUser.Caption = "Disable User"
        Me.bbiDisableUser.Glyph = CType(resources.GetObject("bbiDisableUser.Glyph"), System.Drawing.Image)
        Me.bbiDisableUser.Id = 3
        Me.bbiDisableUser.Name = "bbiDisableUser"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.White
        Me.LabelControl3.Appearance.Options.UseBackColor = True
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(52, 43)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(143, 24)
        Me.LabelControl3.TabIndex = 67
        Me.LabelControl3.Text = "Log in to your account"
        '
        'timPopupForm
        '
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.chkRemember)
        Me.Panel1.Controls.Add(Me.LabelControl3)
        Me.Panel1.Controls.Add(Me.lblForgotPassword)
        Me.Panel1.Controls.Add(Me.lueLanguage)
        Me.Panel1.Location = New System.Drawing.Point(15, 73)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 265)
        Me.Panel1.TabIndex = 72
        '
        'chkRemember
        '
        Me.chkRemember.Location = New System.Drawing.Point(10, 185)
        Me.chkRemember.MenuManager = Me.bmMenuPopup
        Me.chkRemember.Name = "chkRemember"
        Me.chkRemember.Properties.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed", 11.25!)
        Me.chkRemember.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.chkRemember.Properties.Appearance.Options.UseFont = True
        Me.chkRemember.Properties.Appearance.Options.UseForeColor = True
        Me.chkRemember.Properties.Caption = "Remember Me"
        Me.chkRemember.Size = New System.Drawing.Size(100, 21)
        Me.chkRemember.TabIndex = 3
        '
        'lueLanguage
        '
        Me.lueLanguage.EditValue = ""
        Me.lueLanguage.Location = New System.Drawing.Point(10, 155)
        Me.lueLanguage.Name = "lueLanguage"
        Me.lueLanguage.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.lueLanguage.Properties.Appearance.Font = New System.Drawing.Font("Khmer OS Battambang", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lueLanguage.Properties.Appearance.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lueLanguage.Properties.Appearance.Options.UseBackColor = True
        Me.lueLanguage.Properties.Appearance.Options.UseFont = True
        Me.lueLanguage.Properties.Appearance.Options.UseForeColor = True
        Me.lueLanguage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueLanguage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueLanguage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueLanguage.Size = New System.Drawing.Size(218, 28)
        Me.lueLanguage.TabIndex = 2
        '
        'txtPwd
        '
        Me.txtPwd.EditValue = ""
        Me.txtPwd.Location = New System.Drawing.Point(25, 190)
        Me.txtPwd.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtPwd.Properties.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPwd.Properties.Appearance.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.txtPwd.Properties.Appearance.Options.UseBackColor = True
        Me.txtPwd.Properties.Appearance.Options.UseFont = True
        Me.txtPwd.Properties.Appearance.Options.UseForeColor = True
        Me.txtPwd.Properties.AutoHeight = False
        Me.txtPwd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPwd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.txtPwd.Properties.NullValuePrompt = "Password"
        Me.txtPwd.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtPwd.Properties.UseSystemPasswordChar = True
        Me.txtPwd.Size = New System.Drawing.Size(218, 28)
        Me.txtPwd.TabIndex = 1
        '
        'txtUserID
        '
        Me.txtUserID.EditValue = ""
        Me.txtUserID.Location = New System.Drawing.Point(25, 152)
        Me.txtUserID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtUserID.Properties.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.Properties.Appearance.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.txtUserID.Properties.Appearance.Options.UseBackColor = True
        Me.txtUserID.Properties.Appearance.Options.UseFont = True
        Me.txtUserID.Properties.Appearance.Options.UseForeColor = True
        Me.txtUserID.Properties.AutoHeight = False
        Me.txtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtUserID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.txtUserID.Properties.NullValuePrompt = "Username"
        Me.txtUserID.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtUserID.Size = New System.Drawing.Size(218, 28)
        Me.txtUserID.TabIndex = 0
        '
        'btnLogin
        '
        Me.btnLogin.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.btnLogin.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Appearance.Options.UseBackColor = True
        Me.btnLogin.Appearance.Options.UseFont = True
        Me.btnLogin.Appearance.Options.UseForeColor = True
        Me.btnLogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnLogin.Location = New System.Drawing.Point(25, 290)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(218, 32)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "LOGIN"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(29, 194)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(4, Byte), Integer))
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.Appearance.Options.UseForeColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ZoomAccelerationFactor = 1.0R
        Me.PictureEdit1.Size = New System.Drawing.Size(20, 20)
        Me.PictureEdit1.TabIndex = 47
        '
        'PictureEdit2
        '
        Me.PictureEdit2.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureEdit2.EditValue = CType(resources.GetObject("PictureEdit2.EditValue"), Object)
        Me.PictureEdit2.Location = New System.Drawing.Point(29, 156)
        Me.PictureEdit2.Name = "PictureEdit2"
        Me.PictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit2.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit2.Properties.ZoomAccelerationFactor = 1.0R
        Me.PictureEdit2.Size = New System.Drawing.Size(20, 20)
        Me.PictureEdit2.TabIndex = 48
        '
        'picLogo
        '
        Me.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picLogo.Cursor = System.Windows.Forms.Cursors.Default
        Me.picLogo.EditValue = CType(resources.GetObject("picLogo.EditValue"), Object)
        Me.picLogo.Location = New System.Drawing.Point(95, 29)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.Properties.Appearance.Options.UseBackColor = True
        Me.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picLogo.Properties.ZoomAccelerationFactor = 1.0R
        Me.picLogo.Size = New System.Drawing.Size(80, 80)
        Me.picLogo.TabIndex = 62
        '
        'timLoading
        '
        Me.timLoading.Enabled = True
        Me.timLoading.Interval = 1000
        '
        'lblDateTime
        '
        Me.lblDateTime.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblDateTime.Appearance.Options.UseFont = True
        Me.lblDateTime.Appearance.Options.UseForeColor = True
        Me.lblDateTime.Appearance.Options.UseTextOptions = True
        Me.lblDateTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblDateTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDateTime.Location = New System.Drawing.Point(25, 342)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(219, 16)
        Me.lblDateTime.TabIndex = 77
        Me.lblDateTime.Text = "Date and Time"
        '
        'PictureEdit3
        '
        Me.PictureEdit3.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureEdit3.EditValue = CType(resources.GetObject("PictureEdit3.EditValue"), Object)
        Me.PictureEdit3.Location = New System.Drawing.Point(29, 232)
        Me.PictureEdit3.Name = "PictureEdit3"
        Me.PictureEdit3.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(4, Byte), Integer))
        Me.PictureEdit3.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit3.Properties.Appearance.Options.UseForeColor = True
        Me.PictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit3.Properties.ZoomAccelerationFactor = 1.0R
        Me.PictureEdit3.Size = New System.Drawing.Size(20, 20)
        Me.PictureEdit3.TabIndex = 82
        '
        'lblStore
        '
        Me.lblStore.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed", 11.25!)
        Me.lblStore.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblStore.Appearance.Options.UseFont = True
        Me.lblStore.Appearance.Options.UseForeColor = True
        Me.lblStore.Location = New System.Drawing.Point(6, 371)
        Me.lblStore.Name = "lblStore"
        Me.lblStore.Size = New System.Drawing.Size(23, 17)
        Me.lblStore.TabIndex = 87
        Me.lblStore.Text = "Clinic"
        '
        'frmLoginNew
        '
        Me.Appearance.BackColor = System.Drawing.Color.SlateGray
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(270, 394)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblStore)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.PictureEdit3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.PictureEdit2)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLoginNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mengly J. Quach Education"
        CType(Me.ppMenuPopup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenuPopup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.chkRemember.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueLanguage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblVersion As DevExpress.XtraEditors.LabelControl
    Private WithEvents lblForgotPassword As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ppMenuPopup As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiClear As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiMCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bmMenuPopup As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiMAddUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPEditHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiDisableUser As DevExpress.XtraBars.BarButtonItem
    Private WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents timPopupForm As Timer
    Friend WithEvents Panel1 As Panel
    Private WithEvents picLogo As DevExpress.XtraEditors.PictureEdit
    Private WithEvents PictureEdit2 As DevExpress.XtraEditors.PictureEdit
    Private WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtUserID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtPwd As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents timLoading As Timer
    Private WithEvents lblDateTime As DevExpress.XtraEditors.LabelControl
    Private WithEvents PictureEdit3 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblStore As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkRemember As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lueLanguage As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AlertControl1 As DevExpress.XtraBars.Alerter.AlertControl
End Class
