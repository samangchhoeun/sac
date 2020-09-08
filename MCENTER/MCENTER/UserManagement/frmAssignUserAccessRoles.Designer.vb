<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAssignUserAccessRoles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssignUserAccessRoles))
        Me.gvGroups = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcGroups = New DevExpress.XtraGrid.GridControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lueStaffID = New DevExpress.XtraEditors.LookUpEdit()
        Me.bmMenu = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPAddHoilday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPEditHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemoveHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPSearch = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPSetCommonLeave = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiRemoveFromCL = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiCopyTo = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPAddNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPModify = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRestore = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPcopyPermissionFrom = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPCopyPermissionTo = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPAssignAccountType = New DevExpress.XtraBars.BarButtonItem()
        Me.ppMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.gvGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.lueStaffID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.gvGroups.OptionsView.ShowAutoFilterRow = True
        Me.gvGroups.OptionsView.ShowGroupPanel = False
        '
        'gcGroups
        '
        Me.gcGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcGroups.Location = New System.Drawing.Point(11, 66)
        Me.gcGroups.MainView = Me.gvGroups
        Me.gcGroups.Name = "gcGroups"
        Me.gcGroups.Size = New System.Drawing.Size(1057, 536)
        Me.gcGroups.TabIndex = 1
        Me.gcGroups.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvGroups})
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionImage = CType(resources.GetObject("GroupControl1.CaptionImage"), System.Drawing.Image)
        Me.GroupControl1.Controls.Add(Me.lueStaffID)
        Me.GroupControl1.Controls.Add(Me.gcGroups)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1080, 614)
        Me.GroupControl1.TabIndex = 470
        Me.GroupControl1.Text = "Select User Account"
        '
        'lueStaffID
        '
        Me.lueStaffID.Location = New System.Drawing.Point(12, 34)
        Me.lueStaffID.Name = "lueStaffID"
        Me.lueStaffID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueStaffID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueStaffID.Properties.NullText = ""
        Me.lueStaffID.Size = New System.Drawing.Size(501, 20)
        Me.lueStaffID.TabIndex = 9
        '
        'bmMenu
        '
        Me.bmMenu.DockControls.Add(Me.barDockControlTop)
        Me.bmMenu.DockControls.Add(Me.barDockControlBottom)
        Me.bmMenu.DockControls.Add(Me.barDockControlLeft)
        Me.bmMenu.DockControls.Add(Me.barDockControlRight)
        Me.bmMenu.Form = Me
        Me.bmMenu.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPAddHoilday, Me.bbiPEditHoliday, Me.bbiPRemoveHoliday, Me.bbiPSearch, Me.bbiPSetCommonLeave, Me.BarButtonItem1, Me.bbiRemoveFromCL, Me.bbiCopyTo, Me.bbiPAddNew, Me.bbiPModify, Me.bbiPRemove, Me.bbiPRestore, Me.bbiPcopyPermissionFrom, Me.bbiPCopyPermissionTo, Me.bbiPAssignAccountType})
        Me.bmMenu.MaxItemId = 15
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1080, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 614)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1080, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 614)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1080, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 614)
        '
        'bbiPAddHoilday
        '
        Me.bbiPAddHoilday.Caption = "Add New"
        Me.bbiPAddHoilday.Id = 0
        Me.bbiPAddHoilday.ImageUri.Uri = "AddItem"
        Me.bbiPAddHoilday.Name = "bbiPAddHoilday"
        '
        'bbiPEditHoliday
        '
        Me.bbiPEditHoliday.Caption = "Modify Holiday"
        Me.bbiPEditHoliday.Id = 1
        Me.bbiPEditHoliday.ImageUri.Uri = "Edit"
        Me.bbiPEditHoliday.Name = "bbiPEditHoliday"
        '
        'bbiPRemoveHoliday
        '
        Me.bbiPRemoveHoliday.Caption = "Remove Holiday"
        Me.bbiPRemoveHoliday.Id = 2
        Me.bbiPRemoveHoliday.ImageUri.Uri = "Delete"
        Me.bbiPRemoveHoliday.Name = "bbiPRemoveHoliday"
        '
        'bbiPSearch
        '
        Me.bbiPSearch.Caption = "Search"
        Me.bbiPSearch.Id = 3
        Me.bbiPSearch.ImageUri.Uri = "Find"
        Me.bbiPSearch.Name = "bbiPSearch"
        '
        'bbiPSetCommonLeave
        '
        Me.bbiPSetCommonLeave.Caption = "Set as Common Leave"
        Me.bbiPSetCommonLeave.Glyph = CType(resources.GetObject("bbiPSetCommonLeave.Glyph"), System.Drawing.Image)
        Me.bbiPSetCommonLeave.Id = 4
        Me.bbiPSetCommonLeave.LargeGlyph = CType(resources.GetObject("bbiPSetCommonLeave.LargeGlyph"), System.Drawing.Image)
        Me.bbiPSetCommonLeave.Name = "bbiPSetCommonLeave"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Unmark as Common Leave"
        Me.BarButtonItem1.Id = 5
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'bbiRemoveFromCL
        '
        Me.bbiRemoveFromCL.Caption = "Set as Normal Holiday"
        Me.bbiRemoveFromCL.Glyph = CType(resources.GetObject("bbiRemoveFromCL.Glyph"), System.Drawing.Image)
        Me.bbiRemoveFromCL.Id = 6
        Me.bbiRemoveFromCL.LargeGlyph = CType(resources.GetObject("bbiRemoveFromCL.LargeGlyph"), System.Drawing.Image)
        Me.bbiRemoveFromCL.Name = "bbiRemoveFromCL"
        '
        'bbiCopyTo
        '
        Me.bbiCopyTo.Caption = "Copy Holiday To..."
        Me.bbiCopyTo.Id = 7
        Me.bbiCopyTo.ImageUri.Uri = "Copy"
        Me.bbiCopyTo.Name = "bbiCopyTo"
        '
        'bbiPAddNew
        '
        Me.bbiPAddNew.Caption = "Allow Access"
        Me.bbiPAddNew.Id = 8
        Me.bbiPAddNew.ImageUri.Uri = "AddItem"
        Me.bbiPAddNew.Name = "bbiPAddNew"
        '
        'bbiPModify
        '
        Me.bbiPModify.Caption = "Modify"
        Me.bbiPModify.Id = 9
        Me.bbiPModify.ImageUri.Uri = "Edit"
        Me.bbiPModify.Name = "bbiPModify"
        '
        'bbiPRemove
        '
        Me.bbiPRemove.Caption = "Remove Access"
        Me.bbiPRemove.Id = 10
        Me.bbiPRemove.ImageUri.Uri = "Delete"
        Me.bbiPRemove.Name = "bbiPRemove"
        '
        'bbiPRestore
        '
        Me.bbiPRestore.Caption = "Restore"
        Me.bbiPRestore.Id = 11
        Me.bbiPRestore.ImageUri.Uri = "Forward"
        Me.bbiPRestore.Name = "bbiPRestore"
        '
        'bbiPcopyPermissionFrom
        '
        Me.bbiPcopyPermissionFrom.Caption = "Copy Permission From..."
        Me.bbiPcopyPermissionFrom.Id = 12
        Me.bbiPcopyPermissionFrom.ImageUri.Uri = "Backward"
        Me.bbiPcopyPermissionFrom.Name = "bbiPcopyPermissionFrom"
        '
        'bbiPCopyPermissionTo
        '
        Me.bbiPCopyPermissionTo.Caption = "Copy Permission To..."
        Me.bbiPCopyPermissionTo.Id = 13
        Me.bbiPCopyPermissionTo.ImageUri.Uri = "Forward"
        Me.bbiPCopyPermissionTo.Name = "bbiPCopyPermissionTo"
        '
        'bbiPAssignAccountType
        '
        Me.bbiPAssignAccountType.Caption = "Assign Account Type"
        Me.bbiPAssignAccountType.Id = 14
        Me.bbiPAssignAccountType.ImageUri.Uri = "Edit"
        Me.bbiPAssignAccountType.Name = "bbiPAssignAccountType"
        '
        'ppMenu
        '
        Me.ppMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPAddNew, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPAssignAccountType, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPCopyPermissionTo, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPcopyPermissionFrom, True)})
        Me.ppMenu.Manager = Me.bmMenu
        Me.ppMenu.Name = "ppMenu"
        '
        'frmAssignUserAccessRoles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1080, 614)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAssignUserAccessRoles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assign User Access Permissions"
        CType(Me.gvGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.lueStaffID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvGroups As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcGroups As DevExpress.XtraGrid.GridControl
    Private WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lueStaffID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents bmMenu As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPAddHoilday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPEditHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemoveHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPSetCommonLeave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiRemoveFromCL As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiCopyTo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPAddNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPModify As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRestore As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiPcopyPermissionFrom As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPCopyPermissionTo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPAssignAccountType As DevExpress.XtraBars.BarButtonItem
End Class
