<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHolidayList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHolidayList))
        Me.gcHolidays = New DevExpress.XtraGrid.GridControl()
        Me.gvHolidays = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.bmHolidayCalendar = New DevExpress.XtraBars.BarManager(Me.components)
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
        Me.ppAddHolidayCalendar = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.groupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.btnAddNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModify = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCopyTo = New DevExpress.XtraEditors.SimpleButton()
        Me.bbiPModify = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPCopyTo = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPAddNew = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.gcHolidays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvHolidays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmHolidayCalendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppAddHolidayCalendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gcHolidays
        '
        Me.gcHolidays.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcHolidays.Location = New System.Drawing.Point(2, 23)
        Me.gcHolidays.MainView = Me.gvHolidays
        Me.gcHolidays.Name = "gcHolidays"
        Me.gcHolidays.Size = New System.Drawing.Size(1056, 532)
        Me.gcHolidays.TabIndex = 5
        Me.gcHolidays.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvHolidays})
        '
        'gvHolidays
        '
        Me.gvHolidays.GridControl = Me.gcHolidays
        Me.gvHolidays.Name = "gvHolidays"
        Me.gvHolidays.OptionsBehavior.Editable = False
        Me.gvHolidays.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvHolidays.OptionsSelection.MultiSelect = True
        Me.gvHolidays.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvHolidays.OptionsView.EnableAppearanceEvenRow = True
        Me.gvHolidays.OptionsView.ShowAutoFilterRow = True
        Me.gvHolidays.OptionsView.ShowFooter = True
        Me.gvHolidays.OptionsView.ShowGroupPanel = False
        '
        'bmHolidayCalendar
        '
        Me.bmHolidayCalendar.DockControls.Add(Me.barDockControlTop)
        Me.bmHolidayCalendar.DockControls.Add(Me.barDockControlBottom)
        Me.bmHolidayCalendar.DockControls.Add(Me.barDockControlLeft)
        Me.bmHolidayCalendar.DockControls.Add(Me.barDockControlRight)
        Me.bmHolidayCalendar.Form = Me
        Me.bmHolidayCalendar.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPAddHoilday, Me.bbiPEditHoliday, Me.bbiPRemoveHoliday, Me.bbiPSearch, Me.bbiPSetCommonLeave, Me.BarButtonItem1, Me.bbiRemoveFromCL, Me.bbiCopyTo, Me.bbiPModify, Me.bbiPRemove, Me.bbiPCopyTo, Me.bbiPAddNew})
        Me.bmHolidayCalendar.MaxItemId = 12
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1060, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 594)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1060, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 594)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1060, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 594)
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
        'ppAddHolidayCalendar
        '
        Me.ppAddHolidayCalendar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPSearch), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPAddNew, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPModify, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPCopyTo, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiRemoveFromCL, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPSetCommonLeave, True)})
        Me.ppAddHolidayCalendar.Manager = Me.bmHolidayCalendar
        Me.ppAddHolidayCalendar.Name = "ppAddHolidayCalendar"
        '
        'groupControl3
        '
        Me.groupControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupControl3.CaptionImage = CType(resources.GetObject("groupControl3.CaptionImage"), System.Drawing.Image)
        Me.groupControl3.Controls.Add(Me.gcHolidays)
        Me.groupControl3.Location = New System.Drawing.Point(0, 37)
        Me.groupControl3.Name = "groupControl3"
        Me.groupControl3.Size = New System.Drawing.Size(1060, 557)
        Me.groupControl3.TabIndex = 4
        Me.groupControl3.Text = "Public Holiday. Right-click on the list to manage"
        '
        'btnAddNew
        '
        Me.btnAddNew.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAddNew.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnAddNew.Appearance.Options.UseBackColor = True
        Me.btnAddNew.Appearance.Options.UseForeColor = True
        Me.btnAddNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnAddNew.Image = CType(resources.GetObject("btnAddNew.Image"), System.Drawing.Image)
        Me.btnAddNew.Location = New System.Drawing.Point(4, 5)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(83, 26)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "Add New"
        '
        'btnModify
        '
        Me.btnModify.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnModify.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnModify.Appearance.Options.UseBackColor = True
        Me.btnModify.Appearance.Options.UseForeColor = True
        Me.btnModify.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnModify.Image = CType(resources.GetObject("btnModify.Image"), System.Drawing.Image)
        Me.btnModify.Location = New System.Drawing.Point(93, 5)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(73, 26)
        Me.btnModify.TabIndex = 1
        Me.btnModify.Text = "Modify"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnRemove.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Appearance.Options.UseBackColor = True
        Me.btnRemove.Appearance.Options.UseForeColor = True
        Me.btnRemove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.Location = New System.Drawing.Point(976, 5)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(80, 26)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove"
        '
        'btnCopyTo
        '
        Me.btnCopyTo.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCopyTo.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnCopyTo.Appearance.Options.UseBackColor = True
        Me.btnCopyTo.Appearance.Options.UseForeColor = True
        Me.btnCopyTo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnCopyTo.Image = CType(resources.GetObject("btnCopyTo.Image"), System.Drawing.Image)
        Me.btnCopyTo.Location = New System.Drawing.Point(172, 5)
        Me.btnCopyTo.Name = "btnCopyTo"
        Me.btnCopyTo.Size = New System.Drawing.Size(129, 26)
        Me.btnCopyTo.TabIndex = 2
        Me.btnCopyTo.Text = "Copy Holiday To..."
        '
        'bbiPModify
        '
        Me.bbiPModify.Caption = "Modify"
        Me.bbiPModify.Id = 8
        Me.bbiPModify.ImageUri.Uri = "Edit"
        Me.bbiPModify.Name = "bbiPModify"
        '
        'bbiPRemove
        '
        Me.bbiPRemove.Caption = "Remove Holiday"
        Me.bbiPRemove.Id = 9
        Me.bbiPRemove.ImageUri.Uri = "Delete"
        Me.bbiPRemove.Name = "bbiPRemove"
        '
        'bbiPCopyTo
        '
        Me.bbiPCopyTo.Caption = "Copy Holiday To..."
        Me.bbiPCopyTo.Id = 10
        Me.bbiPCopyTo.ImageUri.Uri = "Copy"
        Me.bbiPCopyTo.Name = "bbiPCopyTo"
        '
        'bbiPAddNew
        '
        Me.bbiPAddNew.Caption = "Add New"
        Me.bbiPAddNew.Id = 11
        Me.bbiPAddNew.ImageUri.Uri = "AddItem"
        Me.bbiPAddNew.Name = "bbiPAddNew"
        '
        'frmHolidayList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 594)
        Me.Controls.Add(Me.btnCopyTo)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.groupControl3)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmHolidayList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Holiday Calendar"
        CType(Me.gcHolidays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvHolidays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmHolidayCalendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppAddHolidayCalendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupControl3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gcHolidays As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvHolidays As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents bmHolidayCalendar As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPAddHoilday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPEditHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemoveHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppAddHolidayCalendar As DevExpress.XtraBars.PopupMenu
    Private WithEvents groupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents bbiPSetCommonLeave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiRemoveFromCL As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiCopyTo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnAddNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCopyTo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModify As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bbiPModify As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPCopyTo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPAddNew As DevExpress.XtraBars.BarButtonItem
End Class
