<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountList))
        Me.gcAccount = New DevExpress.XtraEditors.GroupControl()
        Me.gcUserLog = New DevExpress.XtraGrid.GridControl()
        Me.gvUserLog = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.bmUserLogMenu = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPAddHoilday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPEditHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemoveHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPServiceFee = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPVoidInvoice = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPExportTo = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPSearch = New DevExpress.XtraBars.BarButtonItem()
        Me.ppUserLogMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.gcAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcAccount.SuspendLayout()
        CType(Me.gcUserLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvUserLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmUserLogMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppUserLogMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcAccount
        '
        Me.gcAccount.CaptionImage = CType(resources.GetObject("gcAccount.CaptionImage"), System.Drawing.Image)
        Me.gcAccount.Controls.Add(Me.gcUserLog)
        Me.gcAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcAccount.Location = New System.Drawing.Point(0, 0)
        Me.gcAccount.Name = "gcAccount"
        Me.gcAccount.Size = New System.Drawing.Size(1257, 729)
        Me.gcAccount.TabIndex = 4
        Me.gcAccount.Text = "Right-click on the list to manage"
        '
        'gcUserLog
        '
        Me.gcUserLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcUserLog.Location = New System.Drawing.Point(2, 23)
        Me.gcUserLog.MainView = Me.gvUserLog
        Me.gcUserLog.Name = "gcUserLog"
        Me.gcUserLog.Size = New System.Drawing.Size(1253, 704)
        Me.gcUserLog.TabIndex = 402
        Me.gcUserLog.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvUserLog})
        '
        'gvUserLog
        '
        Me.gvUserLog.GridControl = Me.gcUserLog
        Me.gvUserLog.Name = "gvUserLog"
        Me.gvUserLog.OptionsBehavior.Editable = False
        Me.gvUserLog.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvUserLog.OptionsView.EnableAppearanceEvenRow = True
        Me.gvUserLog.OptionsView.ShowAutoFilterRow = True
        Me.gvUserLog.OptionsView.ShowFooter = True
        Me.gvUserLog.OptionsView.ShowGroupPanel = False
        '
        'bmUserLogMenu
        '
        Me.bmUserLogMenu.DockControls.Add(Me.barDockControlTop)
        Me.bmUserLogMenu.DockControls.Add(Me.barDockControlBottom)
        Me.bmUserLogMenu.DockControls.Add(Me.barDockControlLeft)
        Me.bmUserLogMenu.DockControls.Add(Me.barDockControlRight)
        Me.bmUserLogMenu.Form = Me
        Me.bmUserLogMenu.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPAddHoilday, Me.bbiPEditHoliday, Me.bbiPRemoveHoliday, Me.bbiPRefresh, Me.bbiPServiceFee, Me.bbiPVoidInvoice, Me.bbiPExportTo, Me.bbiPSearch})
        Me.bmUserLogMenu.MaxItemId = 8
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1257, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 729)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1257, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 729)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1257, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 729)
        '
        'bbiPAddHoilday
        '
        Me.bbiPAddHoilday.Caption = "New Holiday"
        Me.bbiPAddHoilday.Id = 0
        Me.bbiPAddHoilday.ImageUri.Uri = "AddItem"
        Me.bbiPAddHoilday.Name = "bbiPAddHoilday"
        '
        'bbiPEditHoliday
        '
        Me.bbiPEditHoliday.Caption = "Edit Holiday"
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
        'bbiPRefresh
        '
        Me.bbiPRefresh.Caption = "Refresh"
        Me.bbiPRefresh.Id = 3
        Me.bbiPRefresh.ImageUri.Uri = "Refresh"
        Me.bbiPRefresh.Name = "bbiPRefresh"
        '
        'bbiPServiceFee
        '
        Me.bbiPServiceFee.Caption = "Add Reference"
        Me.bbiPServiceFee.Id = 4
        Me.bbiPServiceFee.ImageUri.Uri = "Currency"
        Me.bbiPServiceFee.Name = "bbiPServiceFee"
        '
        'bbiPVoidInvoice
        '
        Me.bbiPVoidInvoice.Caption = "Void Invoice"
        Me.bbiPVoidInvoice.Id = 5
        Me.bbiPVoidInvoice.ImageUri.Uri = "Delete"
        Me.bbiPVoidInvoice.Name = "bbiPVoidInvoice"
        '
        'bbiPExportTo
        '
        Me.bbiPExportTo.Caption = "Export To Excel..."
        Me.bbiPExportTo.Id = 6
        Me.bbiPExportTo.ImageUri.Uri = "ExportToXLSX"
        Me.bbiPExportTo.Name = "bbiPExportTo"
        '
        'bbiPSearch
        '
        Me.bbiPSearch.Caption = "Search"
        Me.bbiPSearch.Id = 7
        Me.bbiPSearch.ImageUri.Uri = "Find"
        Me.bbiPSearch.Name = "bbiPSearch"
        '
        'ppUserLogMenu
        '
        Me.ppUserLogMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPSearch, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPExportTo, True)})
        Me.ppUserLogMenu.Manager = Me.bmUserLogMenu
        Me.ppUserLogMenu.Name = "ppUserLogMenu"
        '
        'frmAccountList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1257, 729)
        Me.Controls.Add(Me.gcAccount)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmAccountList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Accounts"
        CType(Me.gcAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcAccount.ResumeLayout(False)
        CType(Me.gcUserLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvUserLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmUserLogMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppUserLogMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents gcAccount As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcUserLog As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvUserLog As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents bmUserLogMenu As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPAddHoilday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPEditHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemoveHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPServiceFee As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPVoidInvoice As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPExportTo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppUserLogMenu As DevExpress.XtraBars.PopupMenu
End Class
