<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchPatient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchPatient))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtPhone = New DevExpress.XtraEditors.TextEdit()
        Me.deDOB = New DevExpress.XtraEditors.DateEdit()
        Me.txtPatientName = New DevExpress.XtraEditors.TextEdit()
        Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.deEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.deStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.gcPatients = New DevExpress.XtraGrid.GridControl()
        Me.gvPatients = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtPatientCode = New DevExpress.XtraEditors.SearchControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDOB.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDOB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPatientName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcPatients, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvPatients, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPatientCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtPhone)
        Me.LayoutControl1.Controls.Add(Me.deDOB)
        Me.LayoutControl1.Controls.Add(Me.txtPatientName)
        Me.LayoutControl1.Controls.Add(Me.btnExport)
        Me.LayoutControl1.Controls.Add(Me.btnClear)
        Me.LayoutControl1.Controls.Add(Me.btnSearch)
        Me.LayoutControl1.Controls.Add(Me.deEndDate)
        Me.LayoutControl1.Controls.Add(Me.deStartDate)
        Me.LayoutControl1.Controls.Add(Me.gcPatients)
        Me.LayoutControl1.Controls.Add(Me.txtPatientCode)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1246, 687)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(774, 64)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPhone.Properties.NullValuePrompt = "Phone Number"
        Me.txtPhone.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtPhone.Size = New System.Drawing.Size(165, 20)
        Me.txtPhone.StyleController = Me.LayoutControl1
        Me.txtPhone.TabIndex = 5
        '
        'deDOB
        '
        Me.deDOB.EditValue = Nothing
        Me.deDOB.Location = New System.Drawing.Point(614, 64)
        Me.deDOB.Name = "deDOB"
        Me.deDOB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deDOB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDOB.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDOB.Properties.DisplayFormat.FormatString = "MMM dd, yyyy"
        Me.deDOB.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deDOB.Size = New System.Drawing.Size(148, 20)
        Me.deDOB.StyleController = Me.LayoutControl1
        Me.deDOB.TabIndex = 4
        '
        'txtPatientName
        '
        Me.txtPatientName.Location = New System.Drawing.Point(408, 64)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPatientName.Properties.NullValuePrompt = "Patient Name"
        Me.txtPatientName.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtPatientName.Size = New System.Drawing.Size(194, 20)
        Me.txtPatientName.StyleController = Me.LayoutControl1
        Me.txtPatientName.TabIndex = 3
        '
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.Location = New System.Drawing.Point(1117, 58)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(117, 38)
        Me.btnExport.StyleController = Me.LayoutControl1
        Me.btnExport.TabIndex = 8
        Me.btnExport.Text = "Export to Excel"
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(1044, 58)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(69, 38)
        Me.btnClear.StyleController = Me.LayoutControl1
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(963, 58)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 38)
        Me.btnSearch.StyleController = Me.LayoutControl1
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        '
        'deEndDate
        '
        Me.deEndDate.EditValue = Nothing
        Me.deEndDate.Location = New System.Drawing.Point(136, 64)
        Me.deEndDate.Name = "deEndDate"
        Me.deEndDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deEndDate.Properties.DisplayFormat.FormatString = "MMM dd, yyyy"
        Me.deEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deEndDate.Size = New System.Drawing.Size(88, 20)
        Me.deEndDate.StyleController = Me.LayoutControl1
        Me.deEndDate.TabIndex = 1
        '
        'deStartDate
        '
        Me.deStartDate.EditValue = Nothing
        Me.deStartDate.Location = New System.Drawing.Point(24, 64)
        Me.deStartDate.Name = "deStartDate"
        Me.deStartDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartDate.Properties.DisplayFormat.FormatString = "MMM dd, yyyy"
        Me.deStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deStartDate.Size = New System.Drawing.Size(100, 20)
        Me.deStartDate.StyleController = Me.LayoutControl1
        Me.deStartDate.TabIndex = 0
        '
        'gcPatients
        '
        Me.gcPatients.Location = New System.Drawing.Point(12, 100)
        Me.gcPatients.MainView = Me.gvPatients
        Me.gcPatients.Name = "gcPatients"
        Me.gcPatients.Size = New System.Drawing.Size(1222, 575)
        Me.gcPatients.TabIndex = 4
        Me.gcPatients.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvPatients})
        '
        'gvPatients
        '
        Me.gvPatients.GridControl = Me.gcPatients
        Me.gvPatients.Name = "gvPatients"
        Me.gvPatients.OptionsBehavior.Editable = False
        Me.gvPatients.OptionsBehavior.ReadOnly = True
        Me.gvPatients.OptionsView.ShowAutoFilterRow = True
        Me.gvPatients.OptionsView.ShowFooter = True
        Me.gvPatients.OptionsView.ShowGroupPanel = False
        '
        'txtPatientCode
        '
        Me.txtPatientCode.Location = New System.Drawing.Point(252, 64)
        Me.txtPatientCode.Name = "txtPatientCode"
        Me.txtPatientCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPatientCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.txtPatientCode.Properties.MaxLength = 11
        Me.txtPatientCode.Properties.NullValuePrompt = "Patient Code"
        Me.txtPatientCode.Size = New System.Drawing.Size(144, 20)
        Me.txtPatientCode.StyleController = Me.LayoutControl1
        Me.txtPatientCode.TabIndex = 2
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3, Me.LayoutControlItem1, Me.LayoutControlItem4, Me.LayoutControlGroup4, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1246, 687)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CaptionImage = CType(resources.GetObject("LayoutControlGroup2.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(228, 88)
        Me.LayoutControlGroup2.Text = "Registration Date"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.deStartDate
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(112, 40)
        Me.LayoutControlItem2.Text = "Start Date"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.deEndDate
        Me.LayoutControlItem3.Location = New System.Drawing.Point(112, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(92, 40)
        Me.LayoutControlItem3.Text = "End Date"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CaptionImage = CType(resources.GetObject("LayoutControlGroup3.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(228, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(715, 88)
        Me.LayoutControlGroup3.Text = "Patient Info"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtPatientCode
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(156, 40)
        Me.LayoutControlItem7.Text = "Patient Code"
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtPatientName
        Me.LayoutControlItem8.Location = New System.Drawing.Point(156, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(206, 40)
        Me.LayoutControlItem8.Text = "Patient Name"
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.deDOB
        Me.LayoutControlItem9.Location = New System.Drawing.Point(362, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(160, 40)
        Me.LayoutControlItem9.Text = "Date of Birth"
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtPhone
        Me.LayoutControlItem10.Location = New System.Drawing.Point(522, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(169, 40)
        Me.LayoutControlItem10.Text = "Phone Number"
        Me.LayoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.gcPatients
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 88)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1226, 579)
        Me.LayoutControlItem1.Text = "Patient List"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnSearch
        Me.LayoutControlItem4.Location = New System.Drawing.Point(943, 46)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(89, 42)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem4})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(943, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(283, 46)
        Me.LayoutControlGroup4.Spacing = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlGroup4.Text = "Menu"
        Me.LayoutControlGroup4.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(251, 22)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnClear
        Me.LayoutControlItem5.Location = New System.Drawing.Point(1032, 46)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(73, 42)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnExport
        Me.LayoutControlItem6.Location = New System.Drawing.Point(1105, 46)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(121, 42)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'frmSearchPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1246, 687)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSearchPatient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search Patients"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDOB.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDOB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPatientName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcPatients, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvPatients, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPatientCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents gcPatients As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvPatients As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents deEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPhone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents deDOB As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtPatientName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPatientCode As DevExpress.XtraEditors.SearchControl
End Class
