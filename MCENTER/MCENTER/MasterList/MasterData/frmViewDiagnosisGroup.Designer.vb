<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewDiagnosisGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewDiagnosisGroup))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtDxGroupKh = New DevExpress.XtraEditors.TextEdit()
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
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.meNote = New DevExpress.XtraEditors.MemoEdit()
        Me.MemoExEdit1 = New DevExpress.XtraEditors.MemoExEdit()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtDxGroupEn = New DevExpress.XtraEditors.TextEdit()
        Me.gcData = New DevExpress.XtraGrid.GridControl()
        Me.gvData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.pmMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtDxGroupKh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoExEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDxGroupEn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtDxGroupKh)
        Me.LayoutControl1.Controls.Add(Me.btnClose)
        Me.LayoutControl1.Controls.Add(Me.btnNew)
        Me.LayoutControl1.Controls.Add(Me.btnSave)
        Me.LayoutControl1.Controls.Add(Me.meNote)
        Me.LayoutControl1.Controls.Add(Me.MemoExEdit1)
        Me.LayoutControl1.Controls.Add(Me.txtCode)
        Me.LayoutControl1.Controls.Add(Me.txtDxGroupEn)
        Me.LayoutControl1.Controls.Add(Me.gcData)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(782, 458, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(622, 534)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtDxGroupKh
        '
        Me.txtDxGroupKh.Location = New System.Drawing.Point(149, 108)
        Me.txtDxGroupKh.MenuManager = Me.bmMenu
        Me.txtDxGroupKh.Name = "txtDxGroupKh"
        Me.txtDxGroupKh.Properties.Appearance.Font = New System.Drawing.Font("Khmer OS Battambang", 9.0!)
        Me.txtDxGroupKh.Properties.Appearance.Options.UseFont = True
        Me.txtDxGroupKh.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtDxGroupKh.Size = New System.Drawing.Size(348, 28)
        Me.txtDxGroupKh.StyleController = Me.LayoutControl1
        Me.txtDxGroupKh.TabIndex = 19
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
        Me.barDockControlTop.Size = New System.Drawing.Size(622, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 534)
        Me.barDockControlBottom.Size = New System.Drawing.Size(622, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 534)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(622, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 534)
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
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(509, 116)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(89, 22)
        Me.btnClose.StyleController = Me.LayoutControl1
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        '
        'btnNew
        '
        Me.btnNew.Enabled = False
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Location = New System.Drawing.Point(509, 90)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(89, 22)
        Me.btnNew.StyleController = Me.LayoutControl1
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "New"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(509, 48)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(89, 38)
        Me.btnSave.StyleController = Me.LayoutControl1
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'meNote
        '
        Me.meNote.Location = New System.Drawing.Point(149, 146)
        Me.meNote.MenuManager = Me.bmMenu
        Me.meNote.Name = "meNote"
        Me.meNote.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meNote.Size = New System.Drawing.Size(348, 46)
        Me.meNote.StyleController = Me.LayoutControl1
        Me.meNote.TabIndex = 1
        '
        'MemoExEdit1
        '
        Me.MemoExEdit1.Location = New System.Drawing.Point(123, 96)
        Me.MemoExEdit1.MenuManager = Me.bmMenu
        Me.MemoExEdit1.Name = "MemoExEdit1"
        Me.MemoExEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MemoExEdit1.Size = New System.Drawing.Size(294, 20)
        Me.MemoExEdit1.StyleController = Me.LayoutControl1
        Me.MemoExEdit1.TabIndex = 18
        '
        'txtCode
        '
        Me.txtCode.EditValue = "***"
        Me.txtCode.Location = New System.Drawing.Point(149, 48)
        Me.txtCode.MenuManager = Me.bmMenu
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtCode.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseForeColor = True
        Me.txtCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtCode.Properties.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(348, 20)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 6
        '
        'txtDxGroupEn
        '
        Me.txtDxGroupEn.Location = New System.Drawing.Point(149, 78)
        Me.txtDxGroupEn.MenuManager = Me.bmMenu
        Me.txtDxGroupEn.Name = "txtDxGroupEn"
        Me.txtDxGroupEn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtDxGroupEn.Size = New System.Drawing.Size(348, 20)
        Me.txtDxGroupEn.StyleController = Me.LayoutControl1
        Me.txtDxGroupEn.TabIndex = 0
        '
        'gcData
        '
        Me.gcData.Location = New System.Drawing.Point(15, 235)
        Me.gcData.MainView = Me.gvData
        Me.gcData.Name = "gcData"
        Me.gcData.Size = New System.Drawing.Size(592, 284)
        Me.gcData.TabIndex = 7
        Me.gcData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvData})
        '
        'gvData
        '
        Me.gvData.GridControl = Me.gcData
        Me.gvData.Name = "gvData"
        Me.gvData.OptionsBehavior.Editable = False
        Me.gvData.OptionsBehavior.ReadOnly = True
        Me.gvData.OptionsView.EnableAppearanceOddRow = True
        Me.gvData.OptionsView.ShowAutoFilterRow = True
        Me.gvData.OptionsView.ShowFooter = True
        Me.gvData.OptionsView.ShowGroupPanel = False
        Me.gvData.OptionsView.ShowViewCaption = True
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.MemoExEdit1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(397, 24)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(50, 20)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3, Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(622, 534)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CaptionImage = CType(resources.GetObject("LayoutControlGroup2.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem1, Me.LayoutControlItem4, Me.LayoutControlItem9, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem8, Me.EmptySpaceItem2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(602, 196)
        Me.LayoutControlGroup2.Text = "Diagnosis Group Information"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtCode
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(485, 30)
        Me.LayoutControlItem2.Text = "Diagnosis Group Code"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(120, 20)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtDxGroupEn
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 30)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(485, 30)
        Me.LayoutControlItem1.Text = "Diagnosis Group Name"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(120, 20)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.meNote
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 98)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(485, 50)
        Me.LayoutControlItem4.Text = "Note"
        Me.LayoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(120, 20)
        Me.LayoutControlItem4.TextToControlDistance = 5
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnSave
        Me.LayoutControlItem5.Location = New System.Drawing.Point(485, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(93, 42)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnNew
        Me.LayoutControlItem6.Location = New System.Drawing.Point(485, 42)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(93, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnClose
        Me.LayoutControlItem8.Location = New System.Drawing.Point(485, 68)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(93, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.AppearanceItemCaption.Font = New System.Drawing.Font("Khmer OS Battambang", 9.0!)
        Me.LayoutControlItem9.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem9.Control = Me.txtDxGroupKh
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 60)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(485, 38)
        Me.LayoutControlItem9.Text = "ក្រុមរោគវិនិច្ឆ័យ"
        Me.LayoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(120, 20)
        Me.LayoutControlItem9.TextToControlDistance = 5
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CaptionImage = CType(resources.GetObject("LayoutControlGroup3.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 196)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(602, 318)
        Me.LayoutControlGroup3.Text = "Diagnosis Group List"
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.gcData
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(596, 288)
        Me.LayoutControlItem12.Text = "Doctor List"
        Me.LayoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextToControlDistance = 0
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1094, 590)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'pmMenu
        '
        Me.pmMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPModify, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRestore, True)})
        Me.pmMenu.Manager = Me.bmMenu
        Me.pmMenu.Name = "pmMenu"
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(485, 94)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(93, 54)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmViewDiagnosisGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 534)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewDiagnosisGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Diagnosis Group"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtDxGroupKh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoExEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDxGroupEn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents gcData As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents pmMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bmMenu As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPModify As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents meNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents MemoExEdit1 As DevExpress.XtraEditors.MemoExEdit
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDxGroupEn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents bbiPRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRestore As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDxGroupKh As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
End Class
