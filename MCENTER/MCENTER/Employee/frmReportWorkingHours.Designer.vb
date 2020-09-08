<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReportWorkingHours
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportWorkingHours))
        Me.gcEmploeeDetails = New DevExpress.XtraGrid.GridControl()
        Me.gvEmploeeDetails = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.bmWorkingHours = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPAddHoilday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPEditHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemoveHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPSearch = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.ppAddWorkingHours = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        CType(Me.gcEmploeeDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvEmploeeDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmWorkingHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppAddWorkingHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gcEmploeeDetails
        '
        Me.gcEmploeeDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcEmploeeDetails.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(6)
        Me.gcEmploeeDetails.Location = New System.Drawing.Point(3, 40)
        Me.gcEmploeeDetails.MainView = Me.gvEmploeeDetails
        Me.gcEmploeeDetails.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.gcEmploeeDetails.Name = "gcEmploeeDetails"
        Me.gcEmploeeDetails.Size = New System.Drawing.Size(2132, 1067)
        Me.gcEmploeeDetails.TabIndex = 51
        Me.gcEmploeeDetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvEmploeeDetails})
        '
        'gvEmploeeDetails
        '
        Me.gvEmploeeDetails.GridControl = Me.gcEmploeeDetails
        Me.gvEmploeeDetails.Name = "gvEmploeeDetails"
        Me.gvEmploeeDetails.OptionsBehavior.Editable = False
        Me.gvEmploeeDetails.OptionsView.EnableAppearanceOddRow = True
        Me.gvEmploeeDetails.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.gvEmploeeDetails.OptionsView.ShowAutoFilterRow = True
        Me.gvEmploeeDetails.OptionsView.ShowFooter = True
        Me.gvEmploeeDetails.OptionsView.ShowGroupPanel = False
        Me.gvEmploeeDetails.OptionsView.ShowViewCaption = True
        '
        'bmWorkingHours
        '
        Me.bmWorkingHours.DockControls.Add(Me.barDockControlTop)
        Me.bmWorkingHours.DockControls.Add(Me.barDockControlBottom)
        Me.bmWorkingHours.DockControls.Add(Me.barDockControlLeft)
        Me.bmWorkingHours.DockControls.Add(Me.barDockControlRight)
        Me.bmWorkingHours.Form = Me
        Me.bmWorkingHours.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPAddHoilday, Me.bbiPEditHoliday, Me.bbiPRemoveHoliday, Me.bbiPSearch, Me.bbiPPreview})
        Me.bmWorkingHours.MaxItemId = 5
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.barDockControlTop.Size = New System.Drawing.Size(2138, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 1110)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(2138, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 1110)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(2138, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 1110)
        '
        'bbiPAddHoilday
        '
        Me.bbiPAddHoilday.Caption = "New Working Hours"
        Me.bbiPAddHoilday.Id = 0
        Me.bbiPAddHoilday.ImageUri.Uri = "AddItem"
        Me.bbiPAddHoilday.Name = "bbiPAddHoilday"
        '
        'bbiPEditHoliday
        '
        Me.bbiPEditHoliday.Caption = "Edit Working Hours"
        Me.bbiPEditHoliday.Id = 1
        Me.bbiPEditHoliday.ImageUri.Uri = "Edit"
        Me.bbiPEditHoliday.Name = "bbiPEditHoliday"
        '
        'bbiPRemoveHoliday
        '
        Me.bbiPRemoveHoliday.Caption = "Remove Working Hours"
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
        'bbiPPreview
        '
        Me.bbiPPreview.Caption = "Preview"
        Me.bbiPPreview.Id = 4
        Me.bbiPPreview.ImageUri.Uri = "Preview"
        Me.bbiPPreview.Name = "bbiPPreview"
        '
        'ppAddWorkingHours
        '
        Me.ppAddWorkingHours.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPSearch), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPPreview, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPAddHoilday, True)})
        Me.ppAddWorkingHours.Manager = Me.bmWorkingHours
        Me.ppAddWorkingHours.Name = "ppAddWorkingHours"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.gcEmploeeDetails)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(2138, 1110)
        Me.GroupControl1.TabIndex = 56
        Me.GroupControl1.Text = "Employee Working Hours (Right-click on the list to manage)"
        '
        'frmReportWorkingHoursList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2138, 1110)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmReportWorkingHoursList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employee Working Hours"
        CType(Me.gcEmploeeDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvEmploeeDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmWorkingHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppAddWorkingHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gcEmploeeDetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvEmploeeDetails As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents bmWorkingHours As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPAddHoilday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPEditHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemoveHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppAddWorkingHours As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiPPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
End Class
