<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUserRoles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserRoles))
        Me.groupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.lueUserGroups = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.meDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.Users = New DevExpress.XtraTab.XtraTabPage()
        Me.gcUsers = New DevExpress.XtraGrid.GridControl()
        Me.gvUsers = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Permissions = New DevExpress.XtraTab.XtraTabPage()
        Me.gcGroups = New DevExpress.XtraGrid.GridControl()
        Me.gvGroups = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.gcDefaultPermissions = New DevExpress.XtraGrid.GridControl()
        Me.gvDefaultPermissions = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemMemoEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.ppMenuUserRoles = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.bbiMAddUser = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiMRemoveUser = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRestore = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiDisableUser = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiEnableUser = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPPermanentDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.bmMenuUserRoles = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPEditHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bmMenuPermissions = New DevExpress.XtraBars.BarManager(Me.components)
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.bbiMAddPermission = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiMRemovePermission = New DevExpress.XtraBars.BarButtonItem()
        Me.ppMenuPermissions = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupControl3.SuspendLayout()
        CType(Me.lueUserGroups.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.Users.SuspendLayout()
        CType(Me.gcUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Permissions.SuspendLayout()
        CType(Me.gcGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.gcDefaultPermissions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDefaultPermissions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppMenuUserRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenuUserRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenuPermissions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppMenuPermissions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupControl3
        '
        Me.groupControl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupControl3.CaptionImage = CType(resources.GetObject("groupControl3.CaptionImage"), System.Drawing.Image)
        Me.groupControl3.Controls.Add(Me.lueUserGroups)
        Me.groupControl3.Controls.Add(Me.txtNumber)
        Me.groupControl3.Controls.Add(Me.meDescription)
        Me.groupControl3.Controls.Add(Me.LabelControl1)
        Me.groupControl3.Controls.Add(Me.LabelControl2)
        Me.groupControl3.Location = New System.Drawing.Point(9, 9)
        Me.groupControl3.Name = "groupControl3"
        Me.groupControl3.Size = New System.Drawing.Size(911, 125)
        Me.groupControl3.TabIndex = 470
        Me.groupControl3.Text = "User Roles"
        '
        'lueUserGroups
        '
        Me.lueUserGroups.Location = New System.Drawing.Point(109, 35)
        Me.lueUserGroups.Name = "lueUserGroups"
        Me.lueUserGroups.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueUserGroups.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueUserGroups.Properties.NullText = ""
        Me.lueUserGroups.Size = New System.Drawing.Size(549, 20)
        Me.lueUserGroups.TabIndex = 0
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = ""
        Me.txtNumber.Location = New System.Drawing.Point(21, 89)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(61, 20)
        Me.txtNumber.TabIndex = 459
        Me.txtNumber.Visible = False
        '
        'meDescription
        '
        Me.meDescription.Location = New System.Drawing.Point(109, 68)
        Me.meDescription.Name = "meDescription"
        Me.meDescription.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.meDescription.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.meDescription.Properties.Appearance.Options.UseBackColor = True
        Me.meDescription.Properties.Appearance.Options.UseForeColor = True
        Me.meDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meDescription.Properties.ReadOnly = True
        Me.meDescription.Size = New System.Drawing.Size(549, 39)
        Me.meDescription.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(21, 37)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl1.TabIndex = 461
        Me.LabelControl1.Text = "Group Name"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(21, 70)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl2.TabIndex = 437
        Me.LabelControl2.Text = "Description"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(9, 144)
        Me.XtraTabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.Users
        Me.XtraTabControl1.Size = New System.Drawing.Size(916, 440)
        Me.XtraTabControl1.TabIndex = 471
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.Users, Me.Permissions, Me.XtraTabPage1})
        '
        'Users
        '
        Me.Users.Controls.Add(Me.gcUsers)
        Me.Users.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Users.Name = "Users"
        Me.Users.Size = New System.Drawing.Size(910, 412)
        Me.Users.Text = "User Accounts"
        '
        'gcUsers
        '
        Me.gcUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcUsers.Location = New System.Drawing.Point(0, 0)
        Me.gcUsers.MainView = Me.gvUsers
        Me.gcUsers.Name = "gcUsers"
        Me.gcUsers.Size = New System.Drawing.Size(910, 412)
        Me.gcUsers.TabIndex = 5
        Me.gcUsers.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvUsers})
        '
        'gvUsers
        '
        Me.gvUsers.GridControl = Me.gcUsers
        Me.gvUsers.Name = "gvUsers"
        Me.gvUsers.OptionsBehavior.Editable = False
        Me.gvUsers.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvUsers.OptionsSelection.MultiSelect = True
        Me.gvUsers.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvUsers.OptionsView.EnableAppearanceEvenRow = True
        Me.gvUsers.OptionsView.ShowFooter = True
        Me.gvUsers.OptionsView.ShowGroupPanel = False
        '
        'Permissions
        '
        Me.Permissions.Controls.Add(Me.gcGroups)
        Me.Permissions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Permissions.Name = "Permissions"
        Me.Permissions.Size = New System.Drawing.Size(910, 412)
        Me.Permissions.Text = "Permissions"
        '
        'gcGroups
        '
        Me.gcGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcGroups.Location = New System.Drawing.Point(0, 0)
        Me.gcGroups.MainView = Me.gvGroups
        Me.gcGroups.Name = "gcGroups"
        Me.gcGroups.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.gcGroups.Size = New System.Drawing.Size(910, 412)
        Me.gcGroups.TabIndex = 5
        Me.gcGroups.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvGroups})
        '
        'gvGroups
        '
        Me.gvGroups.GridControl = Me.gcGroups
        Me.gvGroups.Name = "gvGroups"
        Me.gvGroups.OptionsBehavior.Editable = False
        Me.gvGroups.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvGroups.OptionsSelection.MultiSelect = True
        Me.gvGroups.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvGroups.OptionsView.EnableAppearanceEvenRow = True
        Me.gvGroups.OptionsView.ShowFooter = True
        Me.gvGroups.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.gcDefaultPermissions)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(910, 412)
        Me.XtraTabPage1.Text = "Default Permissions"
        '
        'gcDefaultPermissions
        '
        Me.gcDefaultPermissions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDefaultPermissions.Location = New System.Drawing.Point(0, 0)
        Me.gcDefaultPermissions.MainView = Me.gvDefaultPermissions
        Me.gcDefaultPermissions.Name = "gcDefaultPermissions"
        Me.gcDefaultPermissions.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit2})
        Me.gcDefaultPermissions.Size = New System.Drawing.Size(910, 412)
        Me.gcDefaultPermissions.TabIndex = 6
        Me.gcDefaultPermissions.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDefaultPermissions})
        '
        'gvDefaultPermissions
        '
        Me.gvDefaultPermissions.GridControl = Me.gcDefaultPermissions
        Me.gvDefaultPermissions.Name = "gvDefaultPermissions"
        Me.gvDefaultPermissions.OptionsBehavior.Editable = False
        Me.gvDefaultPermissions.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvDefaultPermissions.OptionsSelection.MultiSelect = True
        Me.gvDefaultPermissions.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvDefaultPermissions.OptionsView.EnableAppearanceEvenRow = True
        Me.gvDefaultPermissions.OptionsView.ShowFooter = True
        Me.gvDefaultPermissions.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemMemoEdit2
        '
        Me.RepositoryItemMemoEdit2.Name = "RepositoryItemMemoEdit2"
        '
        'ppMenuUserRoles
        '
        Me.ppMenuUserRoles.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiMAddUser), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiMRemoveUser, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRestore, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiDisableUser, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiEnableUser, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPPermanentDelete, True)})
        Me.ppMenuUserRoles.Manager = Me.bmMenuUserRoles
        Me.ppMenuUserRoles.Name = "ppMenuUserRoles"
        '
        'bbiMAddUser
        '
        Me.bbiMAddUser.Caption = "Add User"
        Me.bbiMAddUser.Id = 0
        Me.bbiMAddUser.ImageUri.Uri = "AddItem"
        Me.bbiMAddUser.Name = "bbiMAddUser"
        '
        'bbiMRemoveUser
        '
        Me.bbiMRemoveUser.Caption = "Remove User"
        Me.bbiMRemoveUser.Id = 2
        Me.bbiMRemoveUser.ImageUri.Uri = "Delete"
        Me.bbiMRemoveUser.Name = "bbiMRemoveUser"
        '
        'bbiPRestore
        '
        Me.bbiPRestore.Caption = "Restore User"
        Me.bbiPRestore.Id = 5
        Me.bbiPRestore.ImageUri.Uri = "Apply"
        Me.bbiPRestore.Name = "bbiPRestore"
        '
        'bbiDisableUser
        '
        Me.bbiDisableUser.Caption = "Block User"
        Me.bbiDisableUser.Enabled = False
        Me.bbiDisableUser.Glyph = CType(resources.GetObject("bbiDisableUser.Glyph"), System.Drawing.Image)
        Me.bbiDisableUser.Id = 3
        Me.bbiDisableUser.Name = "bbiDisableUser"
        '
        'bbiEnableUser
        '
        Me.bbiEnableUser.Caption = "Unblock User"
        Me.bbiEnableUser.Enabled = False
        Me.bbiEnableUser.Glyph = CType(resources.GetObject("bbiEnableUser.Glyph"), System.Drawing.Image)
        Me.bbiEnableUser.Id = 4
        Me.bbiEnableUser.Name = "bbiEnableUser"
        '
        'bbiPPermanentDelete
        '
        Me.bbiPPermanentDelete.Caption = "Permanent Delete"
        Me.bbiPPermanentDelete.Enabled = False
        Me.bbiPPermanentDelete.Id = 6
        Me.bbiPPermanentDelete.ImageUri.Uri = "Delete"
        Me.bbiPPermanentDelete.Name = "bbiPPermanentDelete"
        '
        'bmMenuUserRoles
        '
        Me.bmMenuUserRoles.DockControls.Add(Me.barDockControlTop)
        Me.bmMenuUserRoles.DockControls.Add(Me.barDockControlBottom)
        Me.bmMenuUserRoles.DockControls.Add(Me.barDockControlLeft)
        Me.bmMenuUserRoles.DockControls.Add(Me.barDockControlRight)
        Me.bmMenuUserRoles.Form = Me
        Me.bmMenuUserRoles.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiMAddUser, Me.bbiPEditHoliday, Me.bbiMRemoveUser, Me.bbiDisableUser, Me.bbiEnableUser, Me.bbiPRestore, Me.bbiPPermanentDelete})
        Me.bmMenuUserRoles.MaxItemId = 7
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(930, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 588)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(930, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 588)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(930, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 588)
        '
        'bbiPEditHoliday
        '
        Me.bbiPEditHoliday.Caption = "Edit Holiday"
        Me.bbiPEditHoliday.Id = 1
        Me.bbiPEditHoliday.ImageUri.Uri = "Edit"
        Me.bbiPEditHoliday.Name = "bbiPEditHoliday"
        '
        'bmMenuPermissions
        '
        Me.bmMenuPermissions.DockControls.Add(Me.BarDockControl1)
        Me.bmMenuPermissions.DockControls.Add(Me.BarDockControl2)
        Me.bmMenuPermissions.DockControls.Add(Me.BarDockControl3)
        Me.bmMenuPermissions.DockControls.Add(Me.BarDockControl4)
        Me.bmMenuPermissions.Form = Me
        Me.bmMenuPermissions.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiMAddPermission, Me.BarButtonItem2, Me.bbiMRemovePermission})
        Me.bmMenuPermissions.MaxItemId = 3
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BarDockControl1.Size = New System.Drawing.Size(930, 0)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 588)
        Me.BarDockControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BarDockControl2.Size = New System.Drawing.Size(930, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 588)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(930, 0)
        Me.BarDockControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 588)
        '
        'bbiMAddPermission
        '
        Me.bbiMAddPermission.Caption = "Add Permission"
        Me.bbiMAddPermission.Id = 0
        Me.bbiMAddPermission.ImageUri.Uri = "AddItem"
        Me.bbiMAddPermission.Name = "bbiMAddPermission"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Edit Holiday"
        Me.BarButtonItem2.Id = 1
        Me.BarButtonItem2.ImageUri.Uri = "Edit"
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'bbiMRemovePermission
        '
        Me.bbiMRemovePermission.Caption = "Remove Permission"
        Me.bbiMRemovePermission.Id = 2
        Me.bbiMRemovePermission.ImageUri.Uri = "Delete"
        Me.bbiMRemovePermission.Name = "bbiMRemovePermission"
        '
        'ppMenuPermissions
        '
        Me.ppMenuPermissions.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiMAddPermission), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiMRemovePermission, True)})
        Me.ppMenuPermissions.Manager = Me.bmMenuPermissions
        Me.ppMenuPermissions.Name = "ppMenuPermissions"
        '
        'frmUserRoles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 588)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.groupControl3)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserRoles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Roles"
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupControl3.ResumeLayout(False)
        Me.groupControl3.PerformLayout()
        CType(Me.lueUserGroups.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.Users.ResumeLayout(False)
        CType(Me.gcUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Permissions.ResumeLayout(False)
        CType(Me.gcGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.gcDefaultPermissions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDefaultPermissions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppMenuUserRoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenuUserRoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenuPermissions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppMenuPermissions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents groupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lueUserGroups As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents meDescription As DevExpress.XtraEditors.MemoEdit
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents Users As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Permissions As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcGroups As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvGroups As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents gcUsers As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvUsers As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ppMenuUserRoles As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiMAddUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPEditHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiMRemoveUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bmMenuUserRoles As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bmMenuPermissions As DevExpress.XtraBars.BarManager
    Friend WithEvents bbiMAddPermission As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiMRemovePermission As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppMenuPermissions As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiDisableUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiEnableUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRestore As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcDefaultPermissions As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDefaultPermissions As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemMemoEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents bbiPPermanentDelete As DevExpress.XtraBars.BarButtonItem
End Class
