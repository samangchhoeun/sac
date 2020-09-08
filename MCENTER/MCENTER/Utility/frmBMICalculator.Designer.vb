<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBMICalculator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBMICalculator))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnBMIChart = New DevExpress.XtraEditors.SimpleButton()
        Me.gcData = New DevExpress.XtraGrid.GridControl()
        Me.gvData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnReset = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCalculate = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblYourBMI = New DevExpress.XtraEditors.LabelControl()
        Me.txtWeight = New DevExpress.XtraEditors.TextEdit()
        Me.txtHeight = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnBMIChart)
        Me.LayoutControl1.Controls.Add(Me.gcData)
        Me.LayoutControl1.Controls.Add(Me.btnReset)
        Me.LayoutControl1.Controls.Add(Me.btnCalculate)
        Me.LayoutControl1.Controls.Add(Me.LabelControl3)
        Me.LayoutControl1.Controls.Add(Me.LabelControl2)
        Me.LayoutControl1.Controls.Add(Me.lblYourBMI)
        Me.LayoutControl1.Controls.Add(Me.txtWeight)
        Me.LayoutControl1.Controls.Add(Me.txtHeight)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(178, 154, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(408, 470)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnBMIChart
        '
        Me.btnBMIChart.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnBMIChart.Image = CType(resources.GetObject("btnBMIChart.Image"), System.Drawing.Image)
        Me.btnBMIChart.Location = New System.Drawing.Point(12, 420)
        Me.btnBMIChart.Name = "btnBMIChart"
        Me.btnBMIChart.Size = New System.Drawing.Size(384, 38)
        Me.btnBMIChart.TabIndex = 13
        Me.btnBMIChart.Text = "SHOW BMI CHART"
        '
        'gcData
        '
        Me.gcData.Font = New System.Drawing.Font("Tw Cen MT", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gcData.Location = New System.Drawing.Point(22, 218)
        Me.gcData.MainView = Me.gvData
        Me.gcData.Name = "gcData"
        Me.gcData.Size = New System.Drawing.Size(364, 178)
        Me.gcData.TabIndex = 12
        Me.gcData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvData})
        '
        'gvData
        '
        Me.gvData.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.gvData.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvData.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.gvData.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.gvData.Appearance.HeaderPanel.Options.UseFont = True
        Me.gvData.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.gvData.Appearance.Row.Font = New System.Drawing.Font("Tw Cen MT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvData.Appearance.Row.ForeColor = System.Drawing.Color.Green
        Me.gvData.Appearance.Row.Options.UseFont = True
        Me.gvData.Appearance.Row.Options.UseForeColor = True
        Me.gvData.GridControl = Me.gcData
        Me.gvData.Name = "gvData"
        Me.gvData.OptionsBehavior.Editable = False
        Me.gvData.OptionsBehavior.ReadOnly = True
        Me.gvData.OptionsView.EnableAppearanceOddRow = True
        Me.gvData.OptionsView.ShowGroupPanel = False
        '
        'btnReset
        '
        Me.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.Location = New System.Drawing.Point(286, 104)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(98, 38)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        '
        'btnCalculate
        '
        Me.btnCalculate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCalculate.Image = CType(resources.GetObject("btnCalculate.Image"), System.Drawing.Image)
        Me.btnCalculate.Location = New System.Drawing.Point(286, 62)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(98, 38)
        Me.btnCalculate.TabIndex = 2
        Me.btnCalculate.Text = "Calculate"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tw Cen MT", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(237, 104)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(26, 38)
        Me.LabelControl3.StyleController = Me.LayoutControl1
        Me.LabelControl3.TabIndex = 9
        Me.LabelControl3.Text = "(kg)"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tw Cen MT", 11.25!)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(237, 62)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 38)
        Me.LabelControl2.StyleController = Me.LayoutControl1
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "(cm)"
        '
        'lblYourBMI
        '
        Me.lblYourBMI.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYourBMI.Appearance.ForeColor = System.Drawing.Color.Crimson
        Me.lblYourBMI.Appearance.Options.UseFont = True
        Me.lblYourBMI.Appearance.Options.UseForeColor = True
        Me.lblYourBMI.Location = New System.Drawing.Point(24, 146)
        Me.lblYourBMI.Name = "lblYourBMI"
        Me.lblYourBMI.Size = New System.Drawing.Size(69, 22)
        Me.lblYourBMI.StyleController = Me.LayoutControl1
        Me.lblYourBMI.TabIndex = 7
        Me.lblYourBMI.Text = "Your BMI"
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(119, 110)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Properties.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Properties.Appearance.Options.UseFont = True
        Me.txtWeight.Properties.Appearance.Options.UseTextOptions = True
        Me.txtWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtWeight.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtWeight.Properties.MaxLength = 5
        Me.txtWeight.Size = New System.Drawing.Size(114, 26)
        Me.txtWeight.StyleController = Me.LayoutControl1
        Me.txtWeight.TabIndex = 1
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(119, 68)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Properties.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.Properties.Appearance.Options.UseFont = True
        Me.txtHeight.Properties.Appearance.Options.UseTextOptions = True
        Me.txtHeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtHeight.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtHeight.Properties.MaxLength = 3
        Me.txtHeight.Size = New System.Drawing.Size(114, 26)
        Me.txtHeight.StyleController = Me.LayoutControl1
        Me.txtHeight.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Appearance.Options.UseTextOptions = True
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(24, 24)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(360, 24)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Calculate Your Body Mass Index"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3, Me.LayoutControlItem10, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(408, 470)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CaptionImage = CType(resources.GetObject("LayoutControlGroup2.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem2, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem4, Me.EmptySpaceItem4, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(388, 172)
        Me.LayoutControlGroup2.Text = "BMI"
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.LabelControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(364, 28)
        Me.LayoutControlItem1.Text = "Body Mass Index"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.AppearanceItemCaption.Font = New System.Drawing.Font("Tw Cen MT", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem2.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem2.Control = Me.txtHeight
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 38)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 8)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(213, 42)
        Me.LayoutControlItem2.Text = "You Height"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(90, 20)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.AppearanceItemCaption.Font = New System.Drawing.Font("Tw Cen MT", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem3.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem3.Control = Me.txtWeight
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 80)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 8)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(213, 42)
        Me.LayoutControlItem3.Text = "Your Weight"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(90, 20)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 28)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(364, 10)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AppearanceItemCaption.Font = New System.Drawing.Font("Tw Cen MT", 11.25!)
        Me.LayoutControlItem5.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem5.Control = Me.LabelControl2
        Me.LayoutControlItem5.Location = New System.Drawing.Point(213, 38)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(30, 42)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(30, 42)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(30, 42)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "cm"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.AppearanceItemCaption.Font = New System.Drawing.Font("Tw Cen MT", 11.25!)
        Me.LayoutControlItem6.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem6.Control = Me.LabelControl3
        Me.LayoutControlItem6.Location = New System.Drawing.Point(213, 80)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(30, 42)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(30, 42)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(30, 42)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "kg"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.lblYourBMI
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 122)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(364, 26)
        Me.LayoutControlItem4.Text = "Your BMI"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(243, 38)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(19, 84)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnCalculate
        Me.LayoutControlItem7.Location = New System.Drawing.Point(262, 38)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(102, 42)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnReset
        Me.LayoutControlItem8.Location = New System.Drawing.Point(262, 80)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(102, 42)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.Font = New System.Drawing.Font("Tw Cen MT", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup3.CaptionImage = CType(resources.GetObject("LayoutControlGroup3.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 172)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(388, 226)
        Me.LayoutControlGroup3.Text = "BMI Categories"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.gcData
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(364, 178)
        Me.LayoutControlItem9.Text = "BMI Categories"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.btnBMIChart
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 408)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(388, 42)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 398)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(388, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmBMICalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 470)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmBMICalculator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BMI Calculator"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lblYourBMI As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtHeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnReset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCalculate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcData As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnBMIChart As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
