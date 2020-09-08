<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmControls
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControls))
        Me.xtcActiveControls = New DevExpress.XtraTab.XtraTabControl()
        Me.ActiveControls = New DevExpress.XtraTab.XtraTabPage()
        Me.gcActiveControls = New DevExpress.XtraGrid.GridControl()
        Me.gvActiveControls = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NewControls = New DevExpress.XtraTab.XtraTabPage()
        Me.gcNewControls = New DevExpress.XtraGrid.GridControl()
        Me.gvNewControls = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ExcludedControls = New DevExpress.XtraTab.XtraTabPage()
        Me.gcExcludedControls = New DevExpress.XtraGrid.GridControl()
        Me.gvExcludedControls = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.InactiveControls = New DevExpress.XtraTab.XtraTabPage()
        Me.gcInactiveControls = New DevExpress.XtraGrid.GridControl()
        Me.gvInactiveControls = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RemovedControls = New DevExpress.XtraTab.XtraTabPage()
        Me.gcRemovedControls = New DevExpress.XtraGrid.GridControl()
        Me.gvRemovedControls = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.bmActive = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPLive = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemoveLeave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPSearch = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiActiveAddExclude = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiNewAddActive = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiNewAddExclude = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiMarkInactive = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiActiveMarkInactive = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiExcludeAddasActive = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiExcludeMarkasInactive = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiRemovedMoveasExclude = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiRemovedMoveasActive = New DevExpress.XtraBars.BarButtonItem()
        Me.ppActive = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.ppNew = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.ppInActive = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.ppExclude = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.ppRemoved = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.xtcActiveControls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtcActiveControls.SuspendLayout()
        Me.ActiveControls.SuspendLayout()
        CType(Me.gcActiveControls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvActiveControls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NewControls.SuspendLayout()
        CType(Me.gcNewControls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvNewControls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExcludedControls.SuspendLayout()
        CType(Me.gcExcludedControls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvExcludedControls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InactiveControls.SuspendLayout()
        CType(Me.gcInactiveControls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvInactiveControls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RemovedControls.SuspendLayout()
        CType(Me.gcRemovedControls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvRemovedControls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppInActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppExclude, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppRemoved, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'xtcActiveControls
        '
        Me.xtcActiveControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xtcActiveControls.Location = New System.Drawing.Point(0, 0)
        Me.xtcActiveControls.Name = "xtcActiveControls"
        Me.xtcActiveControls.SelectedTabPage = Me.ActiveControls
        Me.xtcActiveControls.Size = New System.Drawing.Size(1250, 678)
        Me.xtcActiveControls.TabIndex = 0
        Me.xtcActiveControls.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.ActiveControls, Me.NewControls, Me.ExcludedControls, Me.InactiveControls, Me.RemovedControls})
        '
        'ActiveControls
        '
        Me.ActiveControls.Controls.Add(Me.gcActiveControls)
        Me.ActiveControls.Name = "ActiveControls"
        Me.ActiveControls.Size = New System.Drawing.Size(1244, 650)
        Me.ActiveControls.Text = "Active Controls"
        '
        'gcActiveControls
        '
        Me.gcActiveControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcActiveControls.Location = New System.Drawing.Point(0, 0)
        Me.gcActiveControls.MainView = Me.gvActiveControls
        Me.gcActiveControls.Name = "gcActiveControls"
        Me.gcActiveControls.Size = New System.Drawing.Size(1244, 650)
        Me.gcActiveControls.TabIndex = 471
        Me.gcActiveControls.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvActiveControls})
        '
        'gvActiveControls
        '
        Me.gvActiveControls.GridControl = Me.gcActiveControls
        Me.gvActiveControls.Name = "gvActiveControls"
        Me.gvActiveControls.OptionsBehavior.Editable = False
        Me.gvActiveControls.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvActiveControls.OptionsSelection.MultiSelect = True
        Me.gvActiveControls.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvActiveControls.OptionsView.EnableAppearanceEvenRow = True
        Me.gvActiveControls.OptionsView.ShowAutoFilterRow = True
        Me.gvActiveControls.OptionsView.ShowFooter = True
        Me.gvActiveControls.OptionsView.ShowGroupPanel = False
        '
        'NewControls
        '
        Me.NewControls.Controls.Add(Me.gcNewControls)
        Me.NewControls.Name = "NewControls"
        Me.NewControls.Size = New System.Drawing.Size(1244, 650)
        Me.NewControls.Text = "New Controls"
        '
        'gcNewControls
        '
        Me.gcNewControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcNewControls.Location = New System.Drawing.Point(0, 0)
        Me.gcNewControls.MainView = Me.gvNewControls
        Me.gcNewControls.Name = "gcNewControls"
        Me.gcNewControls.Size = New System.Drawing.Size(1244, 650)
        Me.gcNewControls.TabIndex = 472
        Me.gcNewControls.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvNewControls})
        '
        'gvNewControls
        '
        Me.gvNewControls.GridControl = Me.gcNewControls
        Me.gvNewControls.Name = "gvNewControls"
        Me.gvNewControls.OptionsBehavior.Editable = False
        Me.gvNewControls.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvNewControls.OptionsSelection.MultiSelect = True
        Me.gvNewControls.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvNewControls.OptionsView.EnableAppearanceEvenRow = True
        Me.gvNewControls.OptionsView.ShowAutoFilterRow = True
        Me.gvNewControls.OptionsView.ShowFooter = True
        Me.gvNewControls.OptionsView.ShowGroupPanel = False
        '
        'ExcludedControls
        '
        Me.ExcludedControls.Controls.Add(Me.gcExcludedControls)
        Me.ExcludedControls.Name = "ExcludedControls"
        Me.ExcludedControls.Size = New System.Drawing.Size(1244, 650)
        Me.ExcludedControls.Text = "Exclude Controls"
        '
        'gcExcludedControls
        '
        Me.gcExcludedControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcExcludedControls.Location = New System.Drawing.Point(0, 0)
        Me.gcExcludedControls.MainView = Me.gvExcludedControls
        Me.gcExcludedControls.Name = "gcExcludedControls"
        Me.gcExcludedControls.Size = New System.Drawing.Size(1244, 650)
        Me.gcExcludedControls.TabIndex = 472
        Me.gcExcludedControls.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvExcludedControls})
        '
        'gvExcludedControls
        '
        Me.gvExcludedControls.GridControl = Me.gcExcludedControls
        Me.gvExcludedControls.Name = "gvExcludedControls"
        Me.gvExcludedControls.OptionsBehavior.Editable = False
        Me.gvExcludedControls.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvExcludedControls.OptionsSelection.MultiSelect = True
        Me.gvExcludedControls.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvExcludedControls.OptionsView.EnableAppearanceEvenRow = True
        Me.gvExcludedControls.OptionsView.ShowAutoFilterRow = True
        Me.gvExcludedControls.OptionsView.ShowFooter = True
        Me.gvExcludedControls.OptionsView.ShowGroupPanel = False
        '
        'InactiveControls
        '
        Me.InactiveControls.Controls.Add(Me.gcInactiveControls)
        Me.InactiveControls.Name = "InactiveControls"
        Me.InactiveControls.Size = New System.Drawing.Size(1244, 650)
        Me.InactiveControls.Text = "Inactive Controls"
        '
        'gcInactiveControls
        '
        Me.gcInactiveControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcInactiveControls.Location = New System.Drawing.Point(0, 0)
        Me.gcInactiveControls.MainView = Me.gvInactiveControls
        Me.gcInactiveControls.Name = "gcInactiveControls"
        Me.gcInactiveControls.Size = New System.Drawing.Size(1244, 650)
        Me.gcInactiveControls.TabIndex = 473
        Me.gcInactiveControls.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvInactiveControls})
        '
        'gvInactiveControls
        '
        Me.gvInactiveControls.GridControl = Me.gcInactiveControls
        Me.gvInactiveControls.Name = "gvInactiveControls"
        Me.gvInactiveControls.OptionsBehavior.Editable = False
        Me.gvInactiveControls.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvInactiveControls.OptionsSelection.MultiSelect = True
        Me.gvInactiveControls.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvInactiveControls.OptionsView.EnableAppearanceEvenRow = True
        Me.gvInactiveControls.OptionsView.ShowAutoFilterRow = True
        Me.gvInactiveControls.OptionsView.ShowFooter = True
        Me.gvInactiveControls.OptionsView.ShowGroupPanel = False
        '
        'RemovedControls
        '
        Me.RemovedControls.Controls.Add(Me.gcRemovedControls)
        Me.RemovedControls.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RemovedControls.Name = "RemovedControls"
        Me.RemovedControls.Size = New System.Drawing.Size(1244, 650)
        Me.RemovedControls.Text = "Removed Controls"
        '
        'gcRemovedControls
        '
        Me.gcRemovedControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcRemovedControls.Location = New System.Drawing.Point(0, 0)
        Me.gcRemovedControls.MainView = Me.gvRemovedControls
        Me.gcRemovedControls.Name = "gcRemovedControls"
        Me.gcRemovedControls.Size = New System.Drawing.Size(1244, 650)
        Me.gcRemovedControls.TabIndex = 474
        Me.gcRemovedControls.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvRemovedControls})
        '
        'gvRemovedControls
        '
        Me.gvRemovedControls.GridControl = Me.gcRemovedControls
        Me.gvRemovedControls.Name = "gvRemovedControls"
        Me.gvRemovedControls.OptionsBehavior.Editable = False
        Me.gvRemovedControls.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvRemovedControls.OptionsSelection.MultiSelect = True
        Me.gvRemovedControls.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvRemovedControls.OptionsView.EnableAppearanceEvenRow = True
        Me.gvRemovedControls.OptionsView.ShowAutoFilterRow = True
        Me.gvRemovedControls.OptionsView.ShowFooter = True
        Me.gvRemovedControls.OptionsView.ShowGroupPanel = False
        '
        'bmActive
        '
        Me.bmActive.DockControls.Add(Me.barDockControlTop)
        Me.bmActive.DockControls.Add(Me.barDockControlBottom)
        Me.bmActive.DockControls.Add(Me.barDockControlLeft)
        Me.bmActive.DockControls.Add(Me.barDockControlRight)
        Me.bmActive.Form = Me
        Me.bmActive.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPPrint, Me.bbiPLive, Me.bbiPRemoveLeave, Me.bbiPSearch, Me.bbiActiveAddExclude, Me.bbiPRemove, Me.bbiNewAddActive, Me.bbiNewAddExclude, Me.bbiMarkInactive, Me.bbiActiveMarkInactive, Me.BarButtonItem1, Me.bbiExcludeAddasActive, Me.bbiExcludeMarkasInactive, Me.bbiRemovedMoveasExclude, Me.bbiRemovedMoveasActive})
        Me.bmActive.MaxItemId = 15
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1250, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 678)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1250, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 678)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1250, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 678)
        '
        'bbiPPrint
        '
        Me.bbiPPrint.Caption = "Preview"
        Me.bbiPPrint.Id = 0
        Me.bbiPPrint.ImageUri.Uri = "Preview"
        Me.bbiPPrint.Name = "bbiPPrint"
        '
        'bbiPLive
        '
        Me.bbiPLive.Caption = "Live Report"
        Me.bbiPLive.Id = 1
        Me.bbiPLive.ImageUri.Uri = "Apply"
        Me.bbiPLive.Name = "bbiPLive"
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
        'bbiActiveAddExclude
        '
        Me.bbiActiveAddExclude.Caption = "Add as Excluded"
        Me.bbiActiveAddExclude.Id = 4
        Me.bbiActiveAddExclude.ImageUri.Uri = "Add"
        Me.bbiActiveAddExclude.Name = "bbiActiveAddExclude"
        '
        'bbiPRemove
        '
        Me.bbiPRemove.Caption = "Remvoe"
        Me.bbiPRemove.Id = 5
        Me.bbiPRemove.ImageUri.Uri = "Delete"
        Me.bbiPRemove.Name = "bbiPRemove"
        '
        'bbiNewAddActive
        '
        Me.bbiNewAddActive.Caption = "Add as Active"
        Me.bbiNewAddActive.Id = 6
        Me.bbiNewAddActive.ImageUri.Uri = "Add"
        Me.bbiNewAddActive.Name = "bbiNewAddActive"
        '
        'bbiNewAddExclude
        '
        Me.bbiNewAddExclude.Caption = "Add as Excluded"
        Me.bbiNewAddExclude.Id = 7
        Me.bbiNewAddExclude.ImageUri.Uri = "BringToFrontOfText"
        Me.bbiNewAddExclude.Name = "bbiNewAddExclude"
        '
        'bbiMarkInactive
        '
        Me.bbiMarkInactive.Caption = "Mark as Inactive"
        Me.bbiMarkInactive.Id = 8
        Me.bbiMarkInactive.ImageUri.Uri = "Delete"
        Me.bbiMarkInactive.Name = "bbiMarkInactive"
        '
        'bbiActiveMarkInactive
        '
        Me.bbiActiveMarkInactive.Caption = "Mark as Inactive"
        Me.bbiActiveMarkInactive.Id = 9
        Me.bbiActiveMarkInactive.ImageUri.Uri = "Delete"
        Me.bbiActiveMarkInactive.Name = "bbiActiveMarkInactive"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Add as Excluded"
        Me.BarButtonItem1.Id = 10
        Me.BarButtonItem1.ImageUri.Uri = "BringToFrontOfText"
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'bbiExcludeAddasActive
        '
        Me.bbiExcludeAddasActive.Caption = "Add as Active"
        Me.bbiExcludeAddasActive.Id = 11
        Me.bbiExcludeAddasActive.ImageUri.Uri = "Add"
        Me.bbiExcludeAddasActive.Name = "bbiExcludeAddasActive"
        '
        'bbiExcludeMarkasInactive
        '
        Me.bbiExcludeMarkasInactive.Caption = "Mark as Inactive"
        Me.bbiExcludeMarkasInactive.Id = 12
        Me.bbiExcludeMarkasInactive.ImageUri.Uri = "Delete"
        Me.bbiExcludeMarkasInactive.Name = "bbiExcludeMarkasInactive"
        '
        'bbiRemovedMoveasExclude
        '
        Me.bbiRemovedMoveasExclude.Caption = "Move as Excluded"
        Me.bbiRemovedMoveasExclude.Id = 13
        Me.bbiRemovedMoveasExclude.ImageUri.Uri = "BringToFrontOfText"
        Me.bbiRemovedMoveasExclude.Name = "bbiRemovedMoveasExclude"
        '
        'bbiRemovedMoveasActive
        '
        Me.bbiRemovedMoveasActive.Caption = "Move as Active"
        Me.bbiRemovedMoveasActive.Id = 14
        Me.bbiRemovedMoveasActive.ImageUri.Uri = "Add"
        Me.bbiRemovedMoveasActive.Name = "bbiRemovedMoveasActive"
        '
        'ppActive
        '
        Me.ppActive.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiActiveAddExclude), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiActiveMarkInactive, True)})
        Me.ppActive.Manager = Me.bmActive
        Me.ppActive.Name = "ppActive"
        '
        'ppNew
        '
        Me.ppNew.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiNewAddActive, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiNewAddExclude, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiMarkInactive, True)})
        Me.ppNew.Manager = Me.bmActive
        Me.ppNew.Name = "ppNew"
        '
        'ppInActive
        '
        Me.ppInActive.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRemove)})
        Me.ppInActive.Manager = Me.bmActive
        Me.ppInActive.Name = "ppInActive"
        '
        'ppExclude
        '
        Me.ppExclude.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiExcludeAddasActive), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiExcludeMarkasInactive, True)})
        Me.ppExclude.Manager = Me.bmActive
        Me.ppExclude.Name = "ppExclude"
        '
        'ppRemoved
        '
        Me.ppRemoved.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiRemovedMoveasActive), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiRemovedMoveasExclude, True)})
        Me.ppRemoved.Manager = Me.bmActive
        Me.ppRemoved.Name = "ppRemoved"
        '
        'frmControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1250, 678)
        Me.Controls.Add(Me.xtcActiveControls)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmControls"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "System Controls"
        CType(Me.xtcActiveControls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtcActiveControls.ResumeLayout(False)
        Me.ActiveControls.ResumeLayout(False)
        CType(Me.gcActiveControls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvActiveControls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NewControls.ResumeLayout(False)
        CType(Me.gcNewControls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvNewControls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExcludedControls.ResumeLayout(False)
        CType(Me.gcExcludedControls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvExcludedControls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InactiveControls.ResumeLayout(False)
        CType(Me.gcInactiveControls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvInactiveControls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RemovedControls.ResumeLayout(False)
        CType(Me.gcRemovedControls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvRemovedControls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppInActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppExclude, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppRemoved, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents xtcActiveControls As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents ActiveControls As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents NewControls As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ExcludedControls As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcActiveControls As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvActiveControls As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcNewControls As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvNewControls As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcExcludedControls As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvExcludedControls As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents InactiveControls As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcInactiveControls As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvInactiveControls As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents bmActive As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPLive As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemoveLeave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiActiveAddExclude As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppActive As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiPRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppNew As DevExpress.XtraBars.PopupMenu
    Friend WithEvents ppInActive As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiNewAddActive As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiNewAddExclude As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiMarkInactive As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiActiveMarkInactive As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiExcludeAddasActive As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiExcludeMarkasInactive As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppExclude As DevExpress.XtraBars.PopupMenu
    Friend WithEvents RemovedControls As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcRemovedControls As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvRemovedControls As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ppRemoved As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiRemovedMoveasExclude As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiRemovedMoveasActive As DevExpress.XtraBars.BarButtonItem
End Class
