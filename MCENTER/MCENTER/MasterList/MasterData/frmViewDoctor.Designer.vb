<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewDoctor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewDoctor))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.gcEmployee = New DevExpress.XtraGrid.GridControl()
        Me.gvEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcDoctor = New DevExpress.XtraGrid.GridControl()
        Me.gvDoctor = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.pmEmployee = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.bbiPRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPAssignAsDoctor = New DevExpress.XtraBars.BarButtonItem()
        Me.bmMenu = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPDRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.pmDoctor = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.gcEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcDoctor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDoctor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmDoctor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.gcEmployee)
        Me.LayoutControl1.Controls.Add(Me.gcDoctor)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(782, 457, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1138, 802)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'gcEmployee
        '
        Me.gcEmployee.Location = New System.Drawing.Point(24, 48)
        Me.gcEmployee.MainView = Me.gvEmployee
        Me.gcEmployee.Name = "gcEmployee"
        Me.gcEmployee.Size = New System.Drawing.Size(393, 730)
        Me.gcEmployee.TabIndex = 16
        Me.gcEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvEmployee})
        '
        'gvEmployee
        '
        Me.gvEmployee.GridControl = Me.gcEmployee
        Me.gvEmployee.Name = "gvEmployee"
        Me.gvEmployee.OptionsBehavior.Editable = False
        Me.gvEmployee.OptionsBehavior.ReadOnly = True
        Me.gvEmployee.OptionsView.EnableAppearanceOddRow = True
        Me.gvEmployee.OptionsView.ShowAutoFilterRow = True
        Me.gvEmployee.OptionsView.ShowFooter = True
        Me.gvEmployee.OptionsView.ShowGroupPanel = False
        Me.gvEmployee.OptionsView.ShowViewCaption = True
        '
        'gcDoctor
        '
        Me.gcDoctor.Location = New System.Drawing.Point(453, 48)
        Me.gcDoctor.MainView = Me.gvDoctor
        Me.gcDoctor.Name = "gcDoctor"
        Me.gcDoctor.Size = New System.Drawing.Size(661, 730)
        Me.gcDoctor.TabIndex = 15
        Me.gcDoctor.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDoctor})
        '
        'gvDoctor
        '
        Me.gvDoctor.GridControl = Me.gcDoctor
        Me.gvDoctor.Name = "gvDoctor"
        Me.gvDoctor.OptionsBehavior.Editable = False
        Me.gvDoctor.OptionsBehavior.ReadOnly = True
        Me.gvDoctor.OptionsView.EnableAppearanceOddRow = True
        Me.gvDoctor.OptionsView.ShowAutoFilterRow = True
        Me.gvDoctor.OptionsView.ShowFooter = True
        Me.gvDoctor.OptionsView.ShowGroupPanel = False
        Me.gvDoctor.OptionsView.ShowViewCaption = True
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1138, 802)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CaptionImage = CType(resources.GetObject("LayoutControlGroup2.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(421, 782)
        Me.LayoutControlGroup2.Text = "Employee List"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.gcEmployee
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(397, 734)
        Me.LayoutControlItem1.Text = "Employee List"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CaptionImage = CType(resources.GetObject("LayoutControlGroup3.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(421, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(697, 782)
        Me.LayoutControlGroup3.Spacing = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlGroup3.Text = "Doctor List"
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.gcDoctor
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(665, 734)
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
        'pmEmployee
        '
        Me.pmEmployee.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPAssignAsDoctor, True)})
        Me.pmEmployee.Manager = Me.bmMenu
        Me.pmEmployee.Name = "pmEmployee"
        '
        'bbiPRefresh
        '
        Me.bbiPRefresh.Caption = "Refresh"
        Me.bbiPRefresh.Id = 0
        Me.bbiPRefresh.ImageUri.Uri = "Refresh"
        Me.bbiPRefresh.Name = "bbiPRefresh"
        '
        'bbiPAssignAsDoctor
        '
        Me.bbiPAssignAsDoctor.Caption = "Assign As Doctor"
        Me.bbiPAssignAsDoctor.Id = 1
        Me.bbiPAssignAsDoctor.ImageUri.Uri = "Forward"
        Me.bbiPAssignAsDoctor.Name = "bbiPAssignAsDoctor"
        '
        'bmMenu
        '
        Me.bmMenu.DockControls.Add(Me.barDockControlTop)
        Me.bmMenu.DockControls.Add(Me.barDockControlBottom)
        Me.bmMenu.DockControls.Add(Me.barDockControlLeft)
        Me.bmMenu.DockControls.Add(Me.barDockControlRight)
        Me.bmMenu.Form = Me
        Me.bmMenu.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPRefresh, Me.bbiPAssignAsDoctor, Me.bbiPDRefresh, Me.bbiPRemove})
        Me.bmMenu.MaxItemId = 4
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1138, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 802)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1138, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 802)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1138, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 802)
        '
        'bbiPDRefresh
        '
        Me.bbiPDRefresh.Caption = "Refresh"
        Me.bbiPDRefresh.Id = 2
        Me.bbiPDRefresh.ImageUri.Uri = "Refresh"
        Me.bbiPDRefresh.Name = "bbiPDRefresh"
        '
        'bbiPRemove
        '
        Me.bbiPRemove.Caption = "Remove from List"
        Me.bbiPRemove.Id = 3
        Me.bbiPRemove.ImageUri.Uri = "Delete"
        Me.bbiPRemove.Name = "bbiPRemove"
        '
        'pmDoctor
        '
        Me.pmDoctor.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPDRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRemove, True)})
        Me.pmDoctor.Manager = Me.bmMenu
        Me.pmDoctor.Name = "pmDoctor"
        '
        'frmViewDoctor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 802)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmViewDoctor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Doctors"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.gcEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcDoctor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDoctor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmDoctor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents gcDoctor As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDoctor As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents pmEmployee As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bmMenu As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents pmDoctor As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiPRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPAssignAsDoctor As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPDRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemove As DevExpress.XtraBars.BarButtonItem
End Class
