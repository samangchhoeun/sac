<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewMembershipType
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewMembershipType))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.gcData = New DevExpress.XtraGrid.GridControl()
        Me.gvData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.meNote = New DevExpress.XtraEditors.MemoEdit()
        Me.txtMembershipType = New DevExpress.XtraEditors.TextEdit()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.bmMenu = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPModify = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRestore = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPExport = New DevExpress.XtraBars.BarButtonItem()
        Me.pmMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMembershipType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnClose)
        Me.LayoutControl1.Controls.Add(Me.btnNew)
        Me.LayoutControl1.Controls.Add(Me.btnSave)
        Me.LayoutControl1.Controls.Add(Me.gcData)
        Me.LayoutControl1.Controls.Add(Me.meNote)
        Me.LayoutControl1.Controls.Add(Me.txtMembershipType)
        Me.LayoutControl1.Controls.Add(Me.txtCode)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(819, 358, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(630, 610)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(538, 116)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 22)
        Me.btnClose.StyleController = Me.LayoutControl1
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        '
        'btnNew
        '
        Me.btnNew.Enabled = False
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Location = New System.Drawing.Point(538, 90)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(68, 22)
        Me.btnNew.StyleController = Me.LayoutControl1
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "New"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(538, 48)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 38)
        Me.btnSave.StyleController = Me.LayoutControl1
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'gcData
        '
        Me.gcData.Location = New System.Drawing.Point(15, 213)
        Me.gcData.MainView = Me.gvData
        Me.gcData.Name = "gcData"
        Me.gcData.Size = New System.Drawing.Size(600, 382)
        Me.gcData.TabIndex = 7
        Me.gcData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvData})
        '
        'gvData
        '
        Me.gvData.GridControl = Me.gcData
        Me.gvData.Name = "gvData"
        Me.gvData.OptionsBehavior.Editable = False
        Me.gvData.OptionsBehavior.ReadOnly = True
        Me.gvData.OptionsPrint.EnableAppearanceEvenRow = True
        Me.gvData.OptionsView.ShowAutoFilterRow = True
        Me.gvData.OptionsView.ShowFooter = True
        Me.gvData.OptionsView.ShowGroupPanel = False
        Me.gvData.OptionsView.ShowViewCaption = True
        '
        'meNote
        '
        Me.meNote.Location = New System.Drawing.Point(139, 108)
        Me.meNote.Name = "meNote"
        Me.meNote.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meNote.Size = New System.Drawing.Size(387, 62)
        Me.meNote.StyleController = Me.LayoutControl1
        Me.meNote.TabIndex = 1
        '
        'txtMembershipType
        '
        Me.txtMembershipType.Location = New System.Drawing.Point(139, 78)
        Me.txtMembershipType.Name = "txtMembershipType"
        Me.txtMembershipType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtMembershipType.Size = New System.Drawing.Size(387, 20)
        Me.txtMembershipType.StyleController = Me.LayoutControl1
        Me.txtMembershipType.TabIndex = 0
        '
        'txtCode
        '
        Me.txtCode.EditValue = "***"
        Me.txtCode.Location = New System.Drawing.Point(139, 48)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtCode.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseForeColor = True
        Me.txtCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtCode.Properties.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(387, 20)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 6
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3, Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(630, 610)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CaptionImage = CType(resources.GetObject("LayoutControlGroup2.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.EmptySpaceItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(610, 174)
        Me.LayoutControlGroup2.Text = "Memership Type Setting"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtCode
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(514, 30)
        Me.LayoutControlItem1.Text = "Code"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(110, 20)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtMembershipType
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 30)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(514, 30)
        Me.LayoutControlItem2.Text = "Membership Type"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(110, 20)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.meNote
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 60)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(514, 66)
        Me.LayoutControlItem3.Text = "Note"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(110, 20)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnClose
        Me.LayoutControlItem7.Location = New System.Drawing.Point(514, 68)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(72, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnNew
        Me.LayoutControlItem6.Location = New System.Drawing.Point(514, 42)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(72, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnSave
        Me.LayoutControlItem5.Location = New System.Drawing.Point(514, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(72, 42)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CaptionImage = CType(resources.GetObject("LayoutControlGroup3.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 174)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(610, 416)
        Me.LayoutControlGroup3.Text = "Membership Types"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.gcData
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(604, 386)
        Me.LayoutControlItem4.Text = "Membership Type"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'bmMenu
        '
        Me.bmMenu.DockControls.Add(Me.barDockControlTop)
        Me.bmMenu.DockControls.Add(Me.barDockControlBottom)
        Me.bmMenu.DockControls.Add(Me.barDockControlLeft)
        Me.bmMenu.DockControls.Add(Me.barDockControlRight)
        Me.bmMenu.Form = Me
        Me.bmMenu.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPRefresh, Me.bbiPModify, Me.bbiPRemove, Me.bbiPRestore, Me.bbiPExport})
        Me.bmMenu.MaxItemId = 7
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(630, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 610)
        Me.barDockControlBottom.Size = New System.Drawing.Size(630, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 610)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(630, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 610)
        '
        'bbiPRefresh
        '
        Me.bbiPRefresh.Caption = "Refresh"
        Me.bbiPRefresh.Id = 0
        Me.bbiPRefresh.ImageUri.Uri = "Refresh"
        Me.bbiPRefresh.Name = "bbiPRefresh"
        '
        'bbiPModify
        '
        Me.bbiPModify.Caption = "Modify"
        Me.bbiPModify.Id = 1
        Me.bbiPModify.ImageUri.Uri = "Edit"
        Me.bbiPModify.Name = "bbiPModify"
        '
        'bbiPRemove
        '
        Me.bbiPRemove.Caption = "Remove"
        Me.bbiPRemove.Id = 4
        Me.bbiPRemove.ImageUri.Uri = "Delete"
        Me.bbiPRemove.Name = "bbiPRemove"
        '
        'bbiPRestore
        '
        Me.bbiPRestore.Caption = "Restore"
        Me.bbiPRestore.Id = 5
        Me.bbiPRestore.ImageUri.Uri = "Backward"
        Me.bbiPRestore.Name = "bbiPRestore"
        '
        'bbiPExport
        '
        Me.bbiPExport.Caption = "Export to Excel..."
        Me.bbiPExport.Id = 6
        Me.bbiPExport.ImageUri.Uri = "ExportToXLSX"
        Me.bbiPExport.Name = "bbiPExport"
        '
        'pmMenu
        '
        Me.pmMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPModify, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRestore, True)})
        Me.pmMenu.Manager = Me.bmMenu
        Me.pmMenu.Name = "pmMenu"
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(514, 94)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(72, 32)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmViewMembershipType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 610)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewMembershipType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Membership Type"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMembershipType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents meNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtMembershipType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcData As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents bmMenu As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPModify As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRestore As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pmMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
