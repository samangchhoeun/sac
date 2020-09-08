<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLabMasterList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLabMasterList))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.gcData = New DevExpress.XtraGrid.GridControl()
        Me.gvData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtKh = New DevExpress.XtraEditors.TextEdit()
        Me.txtEn = New DevExpress.XtraEditors.TextEdit()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciEn = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciKh = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
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
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciEn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.gcData)
        Me.LayoutControl1.Controls.Add(Me.btnClose)
        Me.LayoutControl1.Controls.Add(Me.btnNew)
        Me.LayoutControl1.Controls.Add(Me.btnSave)
        Me.LayoutControl1.Controls.Add(Me.txtKh)
        Me.LayoutControl1.Controls.Add(Me.txtEn)
        Me.LayoutControl1.Controls.Add(Me.txtCode)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(521, 14, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(566, 492)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'gcData
        '
        Me.gcData.Location = New System.Drawing.Point(15, 185)
        Me.gcData.MainView = Me.gvData
        Me.gcData.Name = "gcData"
        Me.gcData.Size = New System.Drawing.Size(536, 292)
        Me.gcData.TabIndex = 10
        Me.gcData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvData})
        '
        'gvData
        '
        Me.gvData.GridControl = Me.gcData
        Me.gvData.Name = "gvData"
        Me.gvData.OptionsBehavior.Editable = False
        Me.gvData.OptionsBehavior.ReadOnly = True
        Me.gvData.OptionsView.ShowAutoFilterRow = True
        Me.gvData.OptionsView.ShowFooter = True
        Me.gvData.OptionsView.ShowGroupPanel = False
        Me.gvData.OptionsView.ShowViewCaption = True
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(459, 116)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(83, 22)
        Me.btnClose.StyleController = Me.LayoutControl1
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        '
        'btnNew
        '
        Me.btnNew.Enabled = False
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Location = New System.Drawing.Point(459, 90)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(83, 22)
        Me.btnNew.StyleController = Me.LayoutControl1
        Me.btnNew.TabIndex = 8
        Me.btnNew.Text = "New"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(459, 48)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 38)
        Me.btnSave.StyleController = Me.LayoutControl1
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        '
        'txtKh
        '
        Me.txtKh.Location = New System.Drawing.Point(109, 108)
        Me.txtKh.Name = "txtKh"
        Me.txtKh.Properties.Appearance.Font = New System.Drawing.Font("Khmer OS Battambang", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKh.Properties.Appearance.Options.UseFont = True
        Me.txtKh.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtKh.Size = New System.Drawing.Size(338, 28)
        Me.txtKh.StyleController = Me.LayoutControl1
        Me.txtKh.TabIndex = 6
        '
        'txtEn
        '
        Me.txtEn.Location = New System.Drawing.Point(109, 78)
        Me.txtEn.Name = "txtEn"
        Me.txtEn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtEn.Size = New System.Drawing.Size(338, 20)
        Me.txtEn.StyleController = Me.LayoutControl1
        Me.txtEn.TabIndex = 5
        '
        'txtCode
        '
        Me.txtCode.EditValue = "***"
        Me.txtCode.Location = New System.Drawing.Point(109, 48)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtCode.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseForeColor = True
        Me.txtCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtCode.Size = New System.Drawing.Size(338, 20)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(566, 492)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CaptionImage = CType(resources.GetObject("LayoutControlGroup2.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.lciEn, Me.lciKh, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(546, 146)
        Me.LayoutControlGroup2.Text = "Information Setting"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtCode
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(435, 30)
        Me.LayoutControlItem1.Text = "Code"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(80, 20)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'lciEn
        '
        Me.lciEn.Control = Me.txtEn
        Me.lciEn.Location = New System.Drawing.Point(0, 30)
        Me.lciEn.Name = "lciEn"
        Me.lciEn.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.lciEn.Size = New System.Drawing.Size(435, 30)
        Me.lciEn.Text = "Unit"
        Me.lciEn.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciEn.TextSize = New System.Drawing.Size(80, 20)
        Me.lciEn.TextToControlDistance = 5
        '
        'lciKh
        '
        Me.lciKh.AppearanceItemCaption.Font = New System.Drawing.Font("Khmer OS Battambang", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lciKh.AppearanceItemCaption.Options.UseFont = True
        Me.lciKh.Control = Me.txtKh
        Me.lciKh.Location = New System.Drawing.Point(0, 60)
        Me.lciKh.Name = "lciKh"
        Me.lciKh.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.lciKh.Size = New System.Drawing.Size(435, 38)
        Me.lciKh.Text = "ខ្នាត"
        Me.lciKh.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciKh.TextSize = New System.Drawing.Size(80, 20)
        Me.lciKh.TextToControlDistance = 5
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnSave
        Me.LayoutControlItem4.Location = New System.Drawing.Point(435, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(87, 42)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnNew
        Me.LayoutControlItem5.Location = New System.Drawing.Point(435, 42)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(87, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnClose
        Me.LayoutControlItem6.Location = New System.Drawing.Point(435, 68)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(87, 30)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CaptionImage = CType(resources.GetObject("LayoutControlGroup3.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 146)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(546, 326)
        Me.LayoutControlGroup3.Text = "Lab Unit List"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.gcData
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(540, 296)
        Me.LayoutControlItem7.Text = "Unit List"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
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
        Me.barDockControlTop.Size = New System.Drawing.Size(566, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 492)
        Me.barDockControlBottom.Size = New System.Drawing.Size(566, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 492)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(566, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 492)
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
        'frmLabMasterList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 492)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLabMasterList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lab Master Data"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciEn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtKh As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciEn As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciKh As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcData As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
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
End Class
