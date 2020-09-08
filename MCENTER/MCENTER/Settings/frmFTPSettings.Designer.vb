<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFTPSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFTPSettings))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFTPUser = New DevExpress.XtraEditors.TextEdit()
        Me.txtFTPAddress = New DevExpress.XtraEditors.TextEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTest = New DevExpress.XtraEditors.SimpleButton()
        Me.groupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.gcData = New DevExpress.XtraGrid.GridControl()
        Me.gvData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.lueFTPGroup = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.meRemark = New DevExpress.XtraEditors.MemoEdit()
        Me.txtID = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.bmMenu = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemoveLeave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPSearch = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPModify = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiSendEmail = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPTestConnection = New DevExpress.XtraBars.BarButtonItem()
        Me.ppMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btnAddNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnFTPPass = New DevExpress.XtraEditors.ButtonEdit()
        Me.bbiRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRestore = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.txtFTPUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFTPAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupControl3.SuspendLayout()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueFTPGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meRemark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFTPPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 85)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Username"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(18, 118)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Password"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(18, 53)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "FTP Host"
        '
        'txtFTPUser
        '
        Me.txtFTPUser.Location = New System.Drawing.Point(105, 83)
        Me.txtFTPUser.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFTPUser.Name = "txtFTPUser"
        Me.txtFTPUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtFTPUser.Size = New System.Drawing.Size(295, 20)
        Me.txtFTPUser.TabIndex = 1
        '
        'txtFTPAddress
        '
        Me.txtFTPAddress.Location = New System.Drawing.Point(105, 50)
        Me.txtFTPAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFTPAddress.Name = "txtFTPAddress"
        Me.txtFTPAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtFTPAddress.Size = New System.Drawing.Size(295, 20)
        Me.txtFTPAddress.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(301, 275)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(99, 28)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        '
        'btnTest
        '
        Me.btnTest.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnTest.Enabled = False
        Me.btnTest.Image = CType(resources.GetObject("btnTest.Image"), System.Drawing.Image)
        Me.btnTest.Location = New System.Drawing.Point(18, 275)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(113, 28)
        Me.btnTest.TabIndex = 7
        Me.btnTest.Text = "Test Connection"
        '
        'groupControl3
        '
        Me.groupControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupControl3.CaptionImage = CType(resources.GetObject("groupControl3.CaptionImage"), System.Drawing.Image)
        Me.groupControl3.Controls.Add(Me.gcData)
        Me.groupControl3.Location = New System.Drawing.Point(430, 17)
        Me.groupControl3.Name = "groupControl3"
        Me.groupControl3.Size = New System.Drawing.Size(601, 491)
        Me.groupControl3.TabIndex = 9
        Me.groupControl3.Text = "FTP Settings. Right-click on the list to manage."
        '
        'gcData
        '
        Me.gcData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcData.Location = New System.Drawing.Point(2, 23)
        Me.gcData.MainView = Me.gvData
        Me.gcData.Name = "gcData"
        Me.gcData.Size = New System.Drawing.Size(597, 466)
        Me.gcData.TabIndex = 10
        Me.gcData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvData})
        '
        'gvData
        '
        Me.gvData.GridControl = Me.gcData
        Me.gvData.Name = "gvData"
        Me.gvData.OptionsBehavior.Editable = False
        Me.gvData.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvData.OptionsSelection.MultiSelect = True
        Me.gvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvData.OptionsView.EnableAppearanceEvenRow = True
        Me.gvData.OptionsView.ShowAutoFilterRow = True
        Me.gvData.OptionsView.ShowFooter = True
        Me.gvData.OptionsView.ShowGroupPanel = False
        Me.gvData.OptionsView.ShowViewCaption = True
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(18, 151)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl4.TabIndex = 480
        Me.LabelControl4.Text = "Group Type"
        '
        'lueFTPGroup
        '
        Me.lueFTPGroup.EditValue = ""
        Me.lueFTPGroup.Location = New System.Drawing.Point(105, 148)
        Me.lueFTPGroup.Name = "lueFTPGroup"
        Me.lueFTPGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueFTPGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueFTPGroup.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.lueFTPGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueFTPGroup.Size = New System.Drawing.Size(295, 20)
        Me.lueFTPGroup.TabIndex = 3
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(18, 184)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl5.TabIndex = 481
        Me.LabelControl5.Text = "Remark"
        '
        'meRemark
        '
        Me.meRemark.Location = New System.Drawing.Point(105, 182)
        Me.meRemark.Name = "meRemark"
        Me.meRemark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meRemark.Size = New System.Drawing.Size(295, 78)
        Me.meRemark.TabIndex = 4
        '
        'txtID
        '
        Me.txtID.EditValue = "***"
        Me.txtID.EnterMoveNextControl = True
        Me.txtID.Location = New System.Drawing.Point(105, 17)
        Me.txtID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtID.Name = "txtID"
        Me.txtID.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtID.Properties.Appearance.Options.UseBackColor = True
        Me.txtID.Properties.Appearance.Options.UseForeColor = True
        Me.txtID.Properties.Appearance.Options.UseTextOptions = True
        Me.txtID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtID.Properties.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(295, 20)
        Me.txtID.TabIndex = 8
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(18, 20)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl6.TabIndex = 483
        Me.LabelControl6.Text = "FTP Code"
        '
        'bmMenu
        '
        Me.bmMenu.DockControls.Add(Me.barDockControlTop)
        Me.bmMenu.DockControls.Add(Me.barDockControlBottom)
        Me.bmMenu.DockControls.Add(Me.barDockControlLeft)
        Me.bmMenu.DockControls.Add(Me.barDockControlRight)
        Me.bmMenu.Form = Me
        Me.bmMenu.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPPrint, Me.bbiPPreview, Me.bbiPRemoveLeave, Me.bbiPSearch, Me.bbiPModify, Me.bbiSendEmail, Me.bbiPTestConnection, Me.bbiRemove, Me.bbiPRestore})
        Me.bmMenu.MaxItemId = 9
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1043, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 520)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1043, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 520)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1043, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 520)
        '
        'bbiPPrint
        '
        Me.bbiPPrint.Caption = "Print Preview"
        Me.bbiPPrint.Id = 0
        Me.bbiPPrint.ImageUri.Uri = "Print"
        Me.bbiPPrint.Name = "bbiPPrint"
        '
        'bbiPPreview
        '
        Me.bbiPPreview.Caption = "Preview"
        Me.bbiPPreview.Id = 1
        Me.bbiPPreview.ImageUri.Uri = "Preview"
        Me.bbiPPreview.Name = "bbiPPreview"
        '
        'bbiPRemoveLeave
        '
        Me.bbiPRemoveLeave.Caption = "Remove Leave Balance"
        Me.bbiPRemoveLeave.Id = 2
        Me.bbiPRemoveLeave.ImageUri.Uri = "Delete"
        Me.bbiPRemoveLeave.Name = "bbiPRemoveLeave"
        '
        'bbiPSearch
        '
        Me.bbiPSearch.Caption = "Search"
        Me.bbiPSearch.Id = 3
        Me.bbiPSearch.ImageUri.Uri = "Find"
        Me.bbiPSearch.Name = "bbiPSearch"
        '
        'bbiPModify
        '
        Me.bbiPModify.Caption = "Modify"
        Me.bbiPModify.Id = 4
        Me.bbiPModify.ImageUri.Uri = "Edit"
        Me.bbiPModify.Name = "bbiPModify"
        '
        'bbiSendEmail
        '
        Me.bbiSendEmail.Caption = "Email Pay Slip"
        Me.bbiSendEmail.Id = 5
        Me.bbiSendEmail.ImageUri.Uri = "SendPDF"
        Me.bbiSendEmail.Name = "bbiSendEmail"
        '
        'bbiPTestConnection
        '
        Me.bbiPTestConnection.Caption = "Test Connection"
        Me.bbiPTestConnection.Id = 6
        Me.bbiPTestConnection.ImageUri.Uri = "Apply"
        Me.bbiPTestConnection.Name = "bbiPTestConnection"
        '
        'ppMenu
        '
        Me.ppMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPModify, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRestore, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPTestConnection, True)})
        Me.ppMenu.Manager = Me.bmMenu
        Me.ppMenu.Name = "ppMenu"
        '
        'btnAddNew
        '
        Me.btnAddNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnAddNew.Enabled = False
        Me.btnAddNew.Image = CType(resources.GetObject("btnAddNew.Image"), System.Drawing.Image)
        Me.btnAddNew.Location = New System.Drawing.Point(137, 275)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(77, 28)
        Me.btnAddNew.TabIndex = 6
        Me.btnAddNew.Text = "Add New"
        '
        'btnFTPPass
        '
        Me.btnFTPPass.Location = New System.Drawing.Point(105, 114)
        Me.btnFTPPass.MenuManager = Me.bmMenu
        Me.btnFTPPass.Name = "btnFTPPass"
        Me.btnFTPPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.btnFTPPass.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("btnFTPPass.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.btnFTPPass.Properties.UseSystemPasswordChar = True
        Me.btnFTPPass.Size = New System.Drawing.Size(295, 22)
        Me.btnFTPPass.TabIndex = 2
        '
        'bbiRemove
        '
        Me.bbiRemove.Caption = "Remove"
        Me.bbiRemove.Id = 7
        Me.bbiRemove.ImageUri.Uri = "Delete"
        Me.bbiRemove.Name = "bbiRemove"
        '
        'bbiPRestore
        '
        Me.bbiPRestore.Caption = "Restore"
        Me.bbiPRestore.Id = 8
        Me.bbiPRestore.ImageUri.Uri = "Refresh"
        Me.bbiPRestore.Name = "bbiPRestore"
        '
        'frmFTPSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 520)
        Me.Controls.Add(Me.btnFTPPass)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.meRemark)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.lueFTPGroup)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.groupControl3)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtFTPAddress)
        Me.Controls.Add(Me.txtFTPUser)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmFTPSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FTP Integration Wizard"
        CType(Me.txtFTPUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFTPAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupControl3.ResumeLayout(False)
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueFTPGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meRemark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFTPPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFTPUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFTPAddress As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTest As DevExpress.XtraEditors.SimpleButton
    Private WithEvents groupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcData As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents meRemark As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bmMenu As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemoveLeave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPModify As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiSendEmail As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents lueFTPGroup As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnAddNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnFTPPass As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents bbiPTestConnection As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRestore As DevExpress.XtraBars.BarButtonItem
End Class
