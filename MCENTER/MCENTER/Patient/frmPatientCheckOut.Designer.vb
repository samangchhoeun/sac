<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientCheckOut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientCheckOut))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCheckOut = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNumDaysVisit = New DevExpress.XtraEditors.TextEdit()
        Me.deCheckIndate = New DevExpress.XtraEditors.DateEdit()
        Me.txtMembership = New DevExpress.XtraEditors.TextEdit()
        Me.lueClinic = New DevExpress.XtraEditors.LookUpEdit()
        Me.deCheckOutDate = New DevExpress.XtraEditors.DateEdit()
        Me.deDOB = New DevExpress.XtraEditors.DateEdit()
        Me.txtAge = New DevExpress.XtraEditors.TextEdit()
        Me.txtGender = New DevExpress.XtraEditors.TextEdit()
        Me.txtEnglishName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSID = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lcgPatientCheckOut = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtNumDaysVisit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deCheckIndate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deCheckIndate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMembership.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueClinic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deCheckOutDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deCheckOutDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDOB.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDOB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGender.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEnglishName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgPatientCheckOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnClose)
        Me.LayoutControl1.Controls.Add(Me.btnCheckOut)
        Me.LayoutControl1.Controls.Add(Me.txtNumDaysVisit)
        Me.LayoutControl1.Controls.Add(Me.deCheckIndate)
        Me.LayoutControl1.Controls.Add(Me.txtMembership)
        Me.LayoutControl1.Controls.Add(Me.lueClinic)
        Me.LayoutControl1.Controls.Add(Me.deCheckOutDate)
        Me.LayoutControl1.Controls.Add(Me.deDOB)
        Me.LayoutControl1.Controls.Add(Me.txtAge)
        Me.LayoutControl1.Controls.Add(Me.txtGender)
        Me.LayoutControl1.Controls.Add(Me.txtEnglishName)
        Me.LayoutControl1.Controls.Add(Me.txtSID)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(523, 272, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(565, 338)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(24, 276)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(187, 38)
        Me.btnClose.StyleController = Me.LayoutControl1
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        '
        'btnCheckOut
        '
        Me.btnCheckOut.Image = CType(resources.GetObject("btnCheckOut.Image"), System.Drawing.Image)
        Me.btnCheckOut.Location = New System.Drawing.Point(215, 276)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(326, 38)
        Me.btnCheckOut.StyleController = Me.LayoutControl1
        Me.btnCheckOut.TabIndex = 14
        Me.btnCheckOut.Text = "Check-Out"
        '
        'txtNumDaysVisit
        '
        Me.txtNumDaysVisit.Location = New System.Drawing.Point(414, 225)
        Me.txtNumDaysVisit.Name = "txtNumDaysVisit"
        Me.txtNumDaysVisit.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumDaysVisit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtNumDaysVisit.Properties.Appearance.Options.UseBackColor = True
        Me.txtNumDaysVisit.Properties.Appearance.Options.UseForeColor = True
        Me.txtNumDaysVisit.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNumDaysVisit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtNumDaysVisit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtNumDaysVisit.Properties.ReadOnly = True
        Me.txtNumDaysVisit.Size = New System.Drawing.Size(127, 20)
        Me.txtNumDaysVisit.StyleController = Me.LayoutControl1
        Me.txtNumDaysVisit.TabIndex = 13
        '
        'deCheckIndate
        '
        Me.deCheckIndate.EditValue = Nothing
        Me.deCheckIndate.Location = New System.Drawing.Point(24, 225)
        Me.deCheckIndate.Name = "deCheckIndate"
        Me.deCheckIndate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.deCheckIndate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.deCheckIndate.Properties.Appearance.Options.UseBackColor = True
        Me.deCheckIndate.Properties.Appearance.Options.UseForeColor = True
        Me.deCheckIndate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deCheckIndate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deCheckIndate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deCheckIndate.Properties.DisplayFormat.FormatString = "MMM dd, yyyy hh:mm:ss tt"
        Me.deCheckIndate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deCheckIndate.Properties.EditFormat.FormatString = "G"
        Me.deCheckIndate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deCheckIndate.Properties.Mask.EditMask = "G"
        Me.deCheckIndate.Properties.ReadOnly = True
        Me.deCheckIndate.Size = New System.Drawing.Size(179, 20)
        Me.deCheckIndate.StyleController = Me.LayoutControl1
        Me.deCheckIndate.TabIndex = 12
        '
        'txtMembership
        '
        Me.txtMembership.Location = New System.Drawing.Point(24, 176)
        Me.txtMembership.Name = "txtMembership"
        Me.txtMembership.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtMembership.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtMembership.Properties.Appearance.Options.UseBackColor = True
        Me.txtMembership.Properties.Appearance.Options.UseForeColor = True
        Me.txtMembership.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtMembership.Size = New System.Drawing.Size(179, 20)
        Me.txtMembership.StyleController = Me.LayoutControl1
        Me.txtMembership.TabIndex = 11
        '
        'lueClinic
        '
        Me.lueClinic.Location = New System.Drawing.Point(215, 176)
        Me.lueClinic.Name = "lueClinic"
        Me.lueClinic.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.lueClinic.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.lueClinic.Properties.Appearance.Options.UseBackColor = True
        Me.lueClinic.Properties.Appearance.Options.UseForeColor = True
        Me.lueClinic.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueClinic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueClinic.Properties.NullText = ""
        Me.lueClinic.Properties.ReadOnly = True
        Me.lueClinic.Size = New System.Drawing.Size(326, 20)
        Me.lueClinic.StyleController = Me.LayoutControl1
        Me.lueClinic.TabIndex = 10
        '
        'deCheckOutDate
        '
        Me.deCheckOutDate.EditValue = Nothing
        Me.deCheckOutDate.Enabled = False
        Me.deCheckOutDate.Location = New System.Drawing.Point(215, 225)
        Me.deCheckOutDate.Name = "deCheckOutDate"
        Me.deCheckOutDate.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.deCheckOutDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.deCheckOutDate.Properties.Appearance.Options.UseBackColor = True
        Me.deCheckOutDate.Properties.Appearance.Options.UseForeColor = True
        Me.deCheckOutDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deCheckOutDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deCheckOutDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deCheckOutDate.Properties.DisplayFormat.FormatString = "MMM dd, yyyy hh:mm:ss tt"
        Me.deCheckOutDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deCheckOutDate.Properties.Mask.EditMask = "G"
        Me.deCheckOutDate.Size = New System.Drawing.Size(187, 20)
        Me.deCheckOutDate.StyleController = Me.LayoutControl1
        Me.deCheckOutDate.TabIndex = 9
        '
        'deDOB
        '
        Me.deDOB.EditValue = Nothing
        Me.deDOB.Location = New System.Drawing.Point(215, 124)
        Me.deDOB.Name = "deDOB"
        Me.deDOB.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.deDOB.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.deDOB.Properties.Appearance.Options.UseBackColor = True
        Me.deDOB.Properties.Appearance.Options.UseForeColor = True
        Me.deDOB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deDOB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDOB.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDOB.Properties.DisplayFormat.FormatString = "MMM dd, yyyy"
        Me.deDOB.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deDOB.Size = New System.Drawing.Size(232, 20)
        Me.deDOB.StyleController = Me.LayoutControl1
        Me.deDOB.TabIndex = 8
        '
        'txtAge
        '
        Me.txtAge.Location = New System.Drawing.Point(459, 124)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtAge.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtAge.Properties.Appearance.Options.UseBackColor = True
        Me.txtAge.Properties.Appearance.Options.UseForeColor = True
        Me.txtAge.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtAge.Properties.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(82, 20)
        Me.txtAge.StyleController = Me.LayoutControl1
        Me.txtAge.TabIndex = 7
        '
        'txtGender
        '
        Me.txtGender.Location = New System.Drawing.Point(24, 124)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtGender.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtGender.Properties.Appearance.Options.UseBackColor = True
        Me.txtGender.Properties.Appearance.Options.UseForeColor = True
        Me.txtGender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtGender.Properties.ReadOnly = True
        Me.txtGender.Size = New System.Drawing.Size(179, 20)
        Me.txtGender.StyleController = Me.LayoutControl1
        Me.txtGender.TabIndex = 6
        '
        'txtEnglishName
        '
        Me.txtEnglishName.Location = New System.Drawing.Point(215, 73)
        Me.txtEnglishName.Name = "txtEnglishName"
        Me.txtEnglishName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtEnglishName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtEnglishName.Properties.Appearance.Options.UseBackColor = True
        Me.txtEnglishName.Properties.Appearance.Options.UseForeColor = True
        Me.txtEnglishName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtEnglishName.Properties.ReadOnly = True
        Me.txtEnglishName.Size = New System.Drawing.Size(326, 20)
        Me.txtEnglishName.StyleController = Me.LayoutControl1
        Me.txtEnglishName.TabIndex = 5
        '
        'txtSID
        '
        Me.txtSID.Location = New System.Drawing.Point(24, 73)
        Me.txtSID.Name = "txtSID"
        Me.txtSID.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtSID.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtSID.Properties.Appearance.Options.UseBackColor = True
        Me.txtSID.Properties.Appearance.Options.UseFont = True
        Me.txtSID.Properties.Appearance.Options.UseForeColor = True
        Me.txtSID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSID.Properties.ReadOnly = True
        Me.txtSID.Size = New System.Drawing.Size(179, 22)
        Me.txtSID.StyleController = Me.LayoutControl1
        Me.txtSID.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcgPatientCheckOut})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(565, 338)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'lcgPatientCheckOut
        '
        Me.lcgPatientCheckOut.CaptionImage = CType(resources.GetObject("lcgPatientCheckOut.CaptionImage"), System.Drawing.Image)
        Me.lcgPatientCheckOut.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem5, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem6, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.EmptySpaceItem1})
        Me.lcgPatientCheckOut.Location = New System.Drawing.Point(0, 0)
        Me.lcgPatientCheckOut.Name = "lcgPatientCheckOut"
        Me.lcgPatientCheckOut.Size = New System.Drawing.Size(545, 318)
        Me.lcgPatientCheckOut.Text = "Check-Out Info"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtSID
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(191, 51)
        Me.LayoutControlItem1.Text = "Patient Code"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.deDOB
        Me.LayoutControlItem5.Location = New System.Drawing.Point(191, 51)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(244, 52)
        Me.LayoutControlItem5.Text = "Date of Birth"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtEnglishName
        Me.LayoutControlItem2.Location = New System.Drawing.Point(191, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(330, 51)
        Me.LayoutControlItem2.Text = "English Name"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtAge
        Me.LayoutControlItem4.Location = New System.Drawing.Point(435, 51)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 5)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(86, 52)
        Me.LayoutControlItem4.Text = "Age"
        Me.LayoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem4.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtGender
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 51)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(191, 52)
        Me.LayoutControlItem3.Text = "Gender"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.lueClinic
        Me.LayoutControlItem7.Location = New System.Drawing.Point(191, 103)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(330, 49)
        Me.LayoutControlItem7.Text = "Clinic"
        Me.LayoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem7.TextToControlDistance = 5
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtMembership
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 103)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(191, 49)
        Me.LayoutControlItem8.Text = "Membership Type"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem8.TextToControlDistance = 5
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.deCheckOutDate
        Me.LayoutControlItem6.Location = New System.Drawing.Point(191, 152)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(199, 49)
        Me.LayoutControlItem6.Text = "Check-Out"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.deCheckIndate
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 152)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(191, 49)
        Me.LayoutControlItem9.Text = "Check-In"
        Me.LayoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem9.TextToControlDistance = 5
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtNumDaysVisit
        Me.LayoutControlItem10.Location = New System.Drawing.Point(390, 152)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(131, 49)
        Me.LayoutControlItem10.Text = "NumDays Visit"
        Me.LayoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem10.TextToControlDistance = 5
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.btnCheckOut
        Me.LayoutControlItem11.Location = New System.Drawing.Point(191, 228)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(330, 42)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.btnClose
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 228)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(191, 42)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 201)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(521, 27)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmPatientCheckOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 338)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientCheckOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Patient Check-Out"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtNumDaysVisit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deCheckIndate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deCheckIndate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMembership.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueClinic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deCheckOutDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deCheckOutDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDOB.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDOB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGender.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEnglishName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgPatientCheckOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lcgPatientCheckOut As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtSID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lueClinic As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents deCheckOutDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deDOB As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtAge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtGender As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEnglishName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtMembership As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtNumDaysVisit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents deCheckIndate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCheckOut As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
End Class
