<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogoImage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogoImage))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.gcImageList = New DevExpress.XtraGrid.GridControl()
        Me.gvImageList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.bgLoading = New System.ComponentModel.BackgroundWorker()
        Me.ppPopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.bbiPAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPModify = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRestore = New DevExpress.XtraBars.BarButtonItem()
        Me.bmPopupMenu = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPAddAccessList = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPEditAccessList = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemoveHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPSearch = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gcImageList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvImageList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.gcImageList)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1014, 656)
        Me.GroupControl1.TabIndex = 477
        Me.GroupControl1.Text = "Popup Images. Right click to manage."
        '
        'gcImageList
        '
        Me.gcImageList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcImageList.Location = New System.Drawing.Point(2, 20)
        Me.gcImageList.MainView = Me.gvImageList
        Me.gcImageList.Name = "gcImageList"
        Me.gcImageList.Size = New System.Drawing.Size(1010, 634)
        Me.gcImageList.TabIndex = 470
        Me.gcImageList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvImageList})
        '
        'gvImageList
        '
        Me.gvImageList.GridControl = Me.gcImageList
        Me.gvImageList.Name = "gvImageList"
        Me.gvImageList.OptionsBehavior.Editable = False
        Me.gvImageList.OptionsCustomization.AllowColumnResizing = False
        Me.gvImageList.OptionsCustomization.AllowRowSizing = True
        Me.gvImageList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvImageList.OptionsSelection.MultiSelect = True
        Me.gvImageList.OptionsView.EnableAppearanceEvenRow = True
        Me.gvImageList.OptionsView.ShowAutoFilterRow = True
        Me.gvImageList.OptionsView.ShowFooter = True
        Me.gvImageList.OptionsView.ShowGroupPanel = False
        '
        'bgLoading
        '
        '
        'ppPopupMenu
        '
        Me.ppPopupMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPAdd, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPModify, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRestore, True)})
        Me.ppPopupMenu.Manager = Me.bmPopupMenu
        Me.ppPopupMenu.Name = "ppPopupMenu"
        '
        'bbiPAdd
        '
        Me.bbiPAdd.Caption = "Add New"
        Me.bbiPAdd.Id = 4
        Me.bbiPAdd.ImageUri.Uri = "Add"
        Me.bbiPAdd.Name = "bbiPAdd"
        '
        'bbiPModify
        '
        Me.bbiPModify.Caption = "Modify"
        Me.bbiPModify.Id = 6
        Me.bbiPModify.ImageUri.Uri = "Edit"
        Me.bbiPModify.Name = "bbiPModify"
        '
        'bbiPRemove
        '
        Me.bbiPRemove.Caption = "Remove"
        Me.bbiPRemove.Id = 5
        Me.bbiPRemove.ImageUri.Uri = "Delete"
        Me.bbiPRemove.Name = "bbiPRemove"
        '
        'bbiPRestore
        '
        Me.bbiPRestore.Caption = "Restore"
        Me.bbiPRestore.Id = 7
        Me.bbiPRestore.ImageUri.Uri = "Redo"
        Me.bbiPRestore.Name = "bbiPRestore"
        '
        'bmPopupMenu
        '
        Me.bmPopupMenu.DockControls.Add(Me.barDockControlTop)
        Me.bmPopupMenu.DockControls.Add(Me.barDockControlBottom)
        Me.bmPopupMenu.DockControls.Add(Me.barDockControlLeft)
        Me.bmPopupMenu.DockControls.Add(Me.barDockControlRight)
        Me.bmPopupMenu.Form = Me
        Me.bmPopupMenu.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPAddAccessList, Me.bbiPEditAccessList, Me.bbiPRemoveHoliday, Me.bbiPSearch, Me.bbiPAdd, Me.bbiPRemove, Me.bbiPModify, Me.bbiPRestore})
        Me.bmPopupMenu.MaxItemId = 8
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1014, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 656)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1014, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 656)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1014, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 656)
        '
        'bbiPAddAccessList
        '
        Me.bbiPAddAccessList.Caption = "Set Access Location"
        Me.bbiPAddAccessList.Id = 0
        Me.bbiPAddAccessList.ImageUri.Uri = "AddItem"
        Me.bbiPAddAccessList.Name = "bbiPAddAccessList"
        '
        'bbiPEditAccessList
        '
        Me.bbiPEditAccessList.Caption = "Edit Access Location"
        Me.bbiPEditAccessList.Id = 1
        Me.bbiPEditAccessList.ImageUri.Uri = "Edit"
        Me.bbiPEditAccessList.Name = "bbiPEditAccessList"
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
        'frmLogoImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1014, 656)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLogoImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TimeIO Popup Image"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.gcImageList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvImageList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppPopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmPopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcImageList As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvImageList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents bgLoading As System.ComponentModel.BackgroundWorker
    Friend WithEvents ppPopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiPSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bmPopupMenu As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPAddAccessList As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPEditAccessList As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemoveHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPModify As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRestore As DevExpress.XtraBars.BarButtonItem
End Class
