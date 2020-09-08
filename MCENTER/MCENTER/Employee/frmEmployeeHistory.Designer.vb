<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmployeeHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeHistory))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.btnBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSID = New DevExpress.XtraEditors.SearchControl()
        Me.btnTrush = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.txtENName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.groupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl36 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.btnEditIns = New DevExpress.XtraEditors.SimpleButton()
        Me.txtEmpID = New DevExpress.XtraEditors.TextEdit()
        Me.txtApprovedBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAddIns = New DevExpress.XtraEditors.SimpleButton()
        Me.txtReason = New DevExpress.XtraEditors.TextEdit()
        Me.meRemark = New DevExpress.XtraEditors.MemoEdit()
        Me.lstManagementLevel = New DevExpress.XtraEditors.ListBoxControl()
        Me.lueManagementLevel = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.lueDepartment = New DevExpress.XtraEditors.LookUpEdit()
        Me.deApprovedDate = New DevExpress.XtraEditors.DateEdit()
        Me.lueCampus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.deEffectiveDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lueDivision = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPosition = New DevExpress.XtraEditors.ButtonEdit()
        Me.panelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.txtUpdatedDate = New DevExpress.XtraEditors.TextEdit()
        Me.txtUpdatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.lblUpdatedDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblUpdatedBy = New DevExpress.XtraEditors.LabelControl()
        Me.txtCreatedDate = New DevExpress.XtraEditors.TextEdit()
        Me.txtCreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.lblCreatedDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblCreatedBy = New DevExpress.XtraEditors.LabelControl()
        Me.gcStaffTransfer = New DevExpress.XtraGrid.GridControl()
        Me.gvStaffTransfer = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ppMenuPopup = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.bbiEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.bmMenuPopup = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiMAddUser = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPEditHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiMCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiDisableUser = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPClose = New DevExpress.XtraBars.BarButtonItem()
        Me.lueSection = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtENName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupControl3.SuspendLayout()
        CType(Me.txtEmpID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApprovedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meRemark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstManagementLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueManagementLevel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueDepartment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deApprovedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deApprovedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCampus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEffectiveDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueDivision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl2.SuspendLayout()
        CType(Me.txtUpdatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUpdatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcStaffTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvStaffTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppMenuPopup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenuPopup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueSection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnBrowse.Location = New System.Drawing.Point(291, 36)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(39, 21)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "..."
        '
        'btnClear
        '
        Me.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnClear.Enabled = False
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(969, 106)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 26)
        Me.btnClear.TabIndex = 18
        Me.btnClear.Text = "Clear"
        '
        'btnNew
        '
        Me.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnNew.Enabled = False
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(969, 73)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 26)
        Me.btnNew.TabIndex = 17
        Me.btnNew.Text = "New"
        '
        'txtSID
        '
        Me.txtSID.Location = New System.Drawing.Point(97, 37)
        Me.txtSID.Name = "txtSID"
        Me.txtSID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.txtSID.Properties.NullValuePrompt = "Enter Employee ID..."
        Me.txtSID.Size = New System.Drawing.Size(189, 20)
        Me.txtSID.TabIndex = 0
        '
        'btnTrush
        '
        Me.btnTrush.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnTrush.Enabled = False
        Me.btnTrush.Image = CType(resources.GetObject("btnTrush.Image"), System.Drawing.Image)
        Me.btnTrush.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnTrush.Location = New System.Drawing.Point(973, 208)
        Me.btnTrush.Name = "btnTrush"
        Me.btnTrush.Size = New System.Drawing.Size(71, 26)
        Me.btnTrush.TabIndex = 19
        Me.btnTrush.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSave.Enabled = False
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(969, 36)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 29)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Save"
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = "***"
        Me.txtNumber.Location = New System.Drawing.Point(888, 37)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumber.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNumber.Properties.Appearance.Options.UseBackColor = True
        Me.txtNumber.Properties.Appearance.Options.UseForeColor = True
        Me.txtNumber.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtNumber.Properties.ReadOnly = True
        Me.txtNumber.Size = New System.Drawing.Size(69, 20)
        Me.txtNumber.TabIndex = 392
        '
        'txtENName
        '
        Me.txtENName.Location = New System.Drawing.Point(463, 37)
        Me.txtENName.Name = "txtENName"
        Me.txtENName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtENName.Properties.Appearance.ForeColor = System.Drawing.Color.Green
        Me.txtENName.Properties.Appearance.Options.UseBackColor = True
        Me.txtENName.Properties.Appearance.Options.UseForeColor = True
        Me.txtENName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtENName.Properties.ReadOnly = True
        Me.txtENName.Size = New System.Drawing.Size(183, 20)
        Me.txtENName.TabIndex = 2
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.LabelControl12.Appearance.Options.UseForeColor = True
        Me.LabelControl12.Location = New System.Drawing.Point(356, 40)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl12.TabIndex = 389
        Me.LabelControl12.Text = "Employee Name"
        '
        'groupControl3
        '
        Me.groupControl3.CaptionImage = CType(resources.GetObject("groupControl3.CaptionImage"), System.Drawing.Image)
        Me.groupControl3.Controls.Add(Me.lueSection)
        Me.groupControl3.Controls.Add(Me.LabelControl36)
        Me.groupControl3.Controls.Add(Me.btnTrush)
        Me.groupControl3.Controls.Add(Me.btnClear)
        Me.groupControl3.Controls.Add(Me.LabelControl15)
        Me.groupControl3.Controls.Add(Me.LabelControl11)
        Me.groupControl3.Controls.Add(Me.btnEditIns)
        Me.groupControl3.Controls.Add(Me.btnNew)
        Me.groupControl3.Controls.Add(Me.txtEmpID)
        Me.groupControl3.Controls.Add(Me.txtNumber)
        Me.groupControl3.Controls.Add(Me.btnSave)
        Me.groupControl3.Controls.Add(Me.btnBrowse)
        Me.groupControl3.Controls.Add(Me.txtApprovedBy)
        Me.groupControl3.Controls.Add(Me.LabelControl7)
        Me.groupControl3.Controls.Add(Me.LabelControl9)
        Me.groupControl3.Controls.Add(Me.LabelControl12)
        Me.groupControl3.Controls.Add(Me.txtSID)
        Me.groupControl3.Controls.Add(Me.txtENName)
        Me.groupControl3.Controls.Add(Me.btnAddIns)
        Me.groupControl3.Controls.Add(Me.txtReason)
        Me.groupControl3.Controls.Add(Me.meRemark)
        Me.groupControl3.Controls.Add(Me.lstManagementLevel)
        Me.groupControl3.Controls.Add(Me.lueManagementLevel)
        Me.groupControl3.Controls.Add(Me.LabelControl6)
        Me.groupControl3.Controls.Add(Me.LabelControl5)
        Me.groupControl3.Controls.Add(Me.LabelControl8)
        Me.groupControl3.Controls.Add(Me.LabelControl10)
        Me.groupControl3.Controls.Add(Me.lueDepartment)
        Me.groupControl3.Controls.Add(Me.deApprovedDate)
        Me.groupControl3.Controls.Add(Me.lueCampus)
        Me.groupControl3.Controls.Add(Me.LabelControl4)
        Me.groupControl3.Controls.Add(Me.deEffectiveDate)
        Me.groupControl3.Controls.Add(Me.LabelControl3)
        Me.groupControl3.Controls.Add(Me.lueDivision)
        Me.groupControl3.Controls.Add(Me.LabelControl13)
        Me.groupControl3.Controls.Add(Me.LabelControl1)
        Me.groupControl3.Controls.Add(Me.LabelControl14)
        Me.groupControl3.Controls.Add(Me.LabelControl2)
        Me.groupControl3.Controls.Add(Me.LabelControl17)
        Me.groupControl3.Controls.Add(Me.LabelControl18)
        Me.groupControl3.Controls.Add(Me.txtPosition)
        Me.groupControl3.Location = New System.Drawing.Point(15, 14)
        Me.groupControl3.Name = "groupControl3"
        Me.groupControl3.Size = New System.Drawing.Size(1059, 251)
        Me.groupControl3.TabIndex = 4
        Me.groupControl3.Text = "Condition Adjustment"
        '
        'LabelControl36
        '
        Me.LabelControl36.Location = New System.Drawing.Point(14, 170)
        Me.LabelControl36.Name = "LabelControl36"
        Me.LabelControl36.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl36.TabIndex = 3362
        Me.LabelControl36.Text = "Section/Unit"
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.LabelControl15.Appearance.Options.UseFont = True
        Me.LabelControl15.Appearance.Options.UseForeColor = True
        Me.LabelControl15.Location = New System.Drawing.Point(666, 40)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl15.TabIndex = 462
        Me.LabelControl15.Text = "Card ID"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl11.Appearance.Options.UseForeColor = True
        Me.LabelControl11.Location = New System.Drawing.Point(451, 103)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl11.TabIndex = 461
        Me.LabelControl11.Text = "*"
        '
        'btnEditIns
        '
        Me.btnEditIns.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnEditIns.Enabled = False
        Me.btnEditIns.Image = CType(resources.GetObject("btnEditIns.Image"), System.Drawing.Image)
        Me.btnEditIns.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEditIns.Location = New System.Drawing.Point(701, 123)
        Me.btnEditIns.Name = "btnEditIns"
        Me.btnEditIns.Size = New System.Drawing.Size(36, 25)
        Me.btnEditIns.TabIndex = 14
        '
        'txtEmpID
        '
        Me.txtEmpID.EditValue = ""
        Me.txtEmpID.Location = New System.Drawing.Point(744, 37)
        Me.txtEmpID.Name = "txtEmpID"
        Me.txtEmpID.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtEmpID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtEmpID.Properties.Appearance.Options.UseBackColor = True
        Me.txtEmpID.Properties.Appearance.Options.UseForeColor = True
        Me.txtEmpID.Properties.Appearance.Options.UseTextOptions = True
        Me.txtEmpID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtEmpID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtEmpID.Properties.ReadOnly = True
        Me.txtEmpID.Size = New System.Drawing.Size(81, 20)
        Me.txtEmpID.TabIndex = 459
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.Enabled = False
        Me.txtApprovedBy.Location = New System.Drawing.Point(463, 100)
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtApprovedBy.Size = New System.Drawing.Size(183, 20)
        Me.txtApprovedBy.TabIndex = 8
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl7.Appearance.Options.UseForeColor = True
        Me.LabelControl7.Location = New System.Drawing.Point(451, 161)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl7.TabIndex = 410
        Me.LabelControl7.Text = "*"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.LabelControl9.Appearance.Options.UseFont = True
        Me.LabelControl9.Appearance.Options.UseForeColor = True
        Me.LabelControl9.Location = New System.Drawing.Point(837, 40)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl9.TabIndex = 460
        Me.LabelControl9.Text = "Record #"
        '
        'btnAddIns
        '
        Me.btnAddIns.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnAddIns.Enabled = False
        Me.btnAddIns.Image = CType(resources.GetObject("btnAddIns.Image"), System.Drawing.Image)
        Me.btnAddIns.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAddIns.Location = New System.Drawing.Point(701, 94)
        Me.btnAddIns.Name = "btnAddIns"
        Me.btnAddIns.Size = New System.Drawing.Size(36, 25)
        Me.btnAddIns.TabIndex = 13
        '
        'txtReason
        '
        Me.txtReason.Enabled = False
        Me.txtReason.Location = New System.Drawing.Point(463, 159)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtReason.Size = New System.Drawing.Size(183, 20)
        Me.txtReason.TabIndex = 10
        '
        'meRemark
        '
        Me.meRemark.Enabled = False
        Me.meRemark.Location = New System.Drawing.Point(463, 190)
        Me.meRemark.Name = "meRemark"
        Me.meRemark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meRemark.Size = New System.Drawing.Size(494, 44)
        Me.meRemark.TabIndex = 11
        '
        'lstManagementLevel
        '
        Me.lstManagementLevel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstManagementLevel.Enabled = False
        Me.lstManagementLevel.Location = New System.Drawing.Point(744, 94)
        Me.lstManagementLevel.Name = "lstManagementLevel"
        Me.lstManagementLevel.Size = New System.Drawing.Size(213, 80)
        Me.lstManagementLevel.TabIndex = 15
        '
        'lueManagementLevel
        '
        Me.lueManagementLevel.EditValue = ""
        Me.lueManagementLevel.Enabled = False
        Me.lueManagementLevel.Location = New System.Drawing.Point(744, 68)
        Me.lueManagementLevel.Name = "lueManagementLevel"
        Me.lueManagementLevel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueManagementLevel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueManagementLevel.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.lueManagementLevel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueManagementLevel.Size = New System.Drawing.Size(213, 20)
        Me.lueManagementLevel.TabIndex = 12
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(356, 191)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl6.TabIndex = 407
        Me.LabelControl6.Text = "Remark"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(15, 40)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl5.TabIndex = 407
        Me.LabelControl5.Text = "Enter Card ID"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(666, 70)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl8.TabIndex = 430
        Me.LabelControl8.Text = "Management"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl10.Appearance.Options.UseForeColor = True
        Me.LabelControl10.Location = New System.Drawing.Point(85, 72)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl10.TabIndex = 0
        Me.LabelControl10.Text = "*"
        '
        'lueDepartment
        '
        Me.lueDepartment.EditValue = ""
        Me.lueDepartment.Enabled = False
        Me.lueDepartment.Location = New System.Drawing.Point(97, 135)
        Me.lueDepartment.Name = "lueDepartment"
        Me.lueDepartment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDepartment.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.lueDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueDepartment.Size = New System.Drawing.Size(233, 20)
        Me.lueDepartment.TabIndex = 5
        '
        'deApprovedDate
        '
        Me.deApprovedDate.EditValue = Nothing
        Me.deApprovedDate.Enabled = False
        Me.deApprovedDate.Location = New System.Drawing.Point(463, 131)
        Me.deApprovedDate.Name = "deApprovedDate"
        Me.deApprovedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deApprovedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deApprovedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deApprovedDate.Size = New System.Drawing.Size(183, 20)
        Me.deApprovedDate.TabIndex = 9
        '
        'lueCampus
        '
        Me.lueCampus.EditValue = ""
        Me.lueCampus.Enabled = False
        Me.lueCampus.Location = New System.Drawing.Point(97, 199)
        Me.lueCampus.Name = "lueCampus"
        Me.lueCampus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueCampus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueCampus.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.lueCampus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueCampus.Size = New System.Drawing.Size(233, 20)
        Me.lueCampus.TabIndex = 6
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(356, 133)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl4.TabIndex = 401
        Me.LabelControl4.Text = "Approved Date"
        '
        'deEffectiveDate
        '
        Me.deEffectiveDate.EditValue = Nothing
        Me.deEffectiveDate.Enabled = False
        Me.deEffectiveDate.Location = New System.Drawing.Point(463, 70)
        Me.deEffectiveDate.Name = "deEffectiveDate"
        Me.deEffectiveDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deEffectiveDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deEffectiveDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deEffectiveDate.Size = New System.Drawing.Size(183, 20)
        Me.deEffectiveDate.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(356, 102)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl3.TabIndex = 403
        Me.LabelControl3.Text = "Approved By"
        '
        'lueDivision
        '
        Me.lueDivision.EditValue = ""
        Me.lueDivision.Enabled = False
        Me.lueDivision.Location = New System.Drawing.Point(97, 103)
        Me.lueDivision.Name = "lueDivision"
        Me.lueDivision.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueDivision.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDivision.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.lueDivision.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueDivision.Size = New System.Drawing.Size(233, 20)
        Me.lueDivision.TabIndex = 4
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(15, 138)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl13.TabIndex = 387
        Me.LabelControl13.Text = "Department"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(356, 72)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl1.TabIndex = 397
        Me.LabelControl1.Text = "Effective Date"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(15, 202)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl14.TabIndex = 386
        Me.LabelControl14.Text = "Campus"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(356, 161)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(89, 13)
        Me.LabelControl2.TabIndex = 399
        Me.LabelControl2.Text = "Reason of Change"
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(15, 105)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl17.TabIndex = 383
        Me.LabelControl17.Text = "Division"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(15, 72)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl18.TabIndex = 378
        Me.LabelControl18.Text = "Job Title"
        '
        'txtPosition
        '
        Me.txtPosition.Enabled = False
        Me.txtPosition.Location = New System.Drawing.Point(97, 69)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPosition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("txtPosition.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.txtPosition.Size = New System.Drawing.Size(233, 22)
        Me.txtPosition.TabIndex = 3
        '
        'panelControl2
        '
        Me.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl2.Controls.Add(Me.txtUpdatedDate)
        Me.panelControl2.Controls.Add(Me.txtUpdatedBy)
        Me.panelControl2.Controls.Add(Me.lblUpdatedDate)
        Me.panelControl2.Controls.Add(Me.lblUpdatedBy)
        Me.panelControl2.Controls.Add(Me.txtCreatedDate)
        Me.panelControl2.Controls.Add(Me.txtCreatedBy)
        Me.panelControl2.Controls.Add(Me.lblCreatedDate)
        Me.panelControl2.Controls.Add(Me.lblCreatedBy)
        Me.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelControl2.Location = New System.Drawing.Point(0, 608)
        Me.panelControl2.Name = "panelControl2"
        Me.panelControl2.Size = New System.Drawing.Size(1087, 61)
        Me.panelControl2.TabIndex = 390
        '
        'txtUpdatedDate
        '
        Me.txtUpdatedDate.Location = New System.Drawing.Point(354, 10)
        Me.txtUpdatedDate.Name = "txtUpdatedDate"
        Me.txtUpdatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtUpdatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtUpdatedDate.Properties.Appearance.Options.UseBackColor = True
        Me.txtUpdatedDate.Properties.Appearance.Options.UseForeColor = True
        Me.txtUpdatedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtUpdatedDate.Size = New System.Drawing.Size(190, 18)
        Me.txtUpdatedDate.TabIndex = 53
        Me.txtUpdatedDate.Visible = False
        '
        'txtUpdatedBy
        '
        Me.txtUpdatedBy.Location = New System.Drawing.Point(79, 10)
        Me.txtUpdatedBy.Name = "txtUpdatedBy"
        Me.txtUpdatedBy.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtUpdatedBy.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtUpdatedBy.Properties.Appearance.Options.UseBackColor = True
        Me.txtUpdatedBy.Properties.Appearance.Options.UseForeColor = True
        Me.txtUpdatedBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtUpdatedBy.Size = New System.Drawing.Size(191, 18)
        Me.txtUpdatedBy.TabIndex = 51
        Me.txtUpdatedBy.Visible = False
        '
        'lblUpdatedDate
        '
        Me.lblUpdatedDate.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.lblUpdatedDate.Appearance.Options.UseForeColor = True
        Me.lblUpdatedDate.Location = New System.Drawing.Point(277, 13)
        Me.lblUpdatedDate.Name = "lblUpdatedDate"
        Me.lblUpdatedDate.Size = New System.Drawing.Size(71, 13)
        Me.lblUpdatedDate.TabIndex = 52
        Me.lblUpdatedDate.Text = "Updated Date:"
        Me.lblUpdatedDate.Visible = False
        '
        'lblUpdatedBy
        '
        Me.lblUpdatedBy.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.lblUpdatedBy.Appearance.Options.UseForeColor = True
        Me.lblUpdatedBy.Location = New System.Drawing.Point(13, 13)
        Me.lblUpdatedBy.Name = "lblUpdatedBy"
        Me.lblUpdatedBy.Size = New System.Drawing.Size(60, 13)
        Me.lblUpdatedBy.TabIndex = 50
        Me.lblUpdatedBy.Text = "Updated By:"
        Me.lblUpdatedBy.Visible = False
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.Location = New System.Drawing.Point(354, 34)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtCreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtCreatedDate.Properties.Appearance.Options.UseBackColor = True
        Me.txtCreatedDate.Properties.Appearance.Options.UseForeColor = True
        Me.txtCreatedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtCreatedDate.Size = New System.Drawing.Size(191, 18)
        Me.txtCreatedDate.TabIndex = 49
        Me.txtCreatedDate.Visible = False
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.Location = New System.Drawing.Point(79, 34)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtCreatedBy.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtCreatedBy.Properties.Appearance.Options.UseBackColor = True
        Me.txtCreatedBy.Properties.Appearance.Options.UseForeColor = True
        Me.txtCreatedBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtCreatedBy.Size = New System.Drawing.Size(191, 18)
        Me.txtCreatedBy.TabIndex = 47
        Me.txtCreatedBy.Visible = False
        '
        'lblCreatedDate
        '
        Me.lblCreatedDate.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.lblCreatedDate.Appearance.Options.UseForeColor = True
        Me.lblCreatedDate.Location = New System.Drawing.Point(277, 37)
        Me.lblCreatedDate.Name = "lblCreatedDate"
        Me.lblCreatedDate.Size = New System.Drawing.Size(69, 13)
        Me.lblCreatedDate.TabIndex = 48
        Me.lblCreatedDate.Text = "Created Date:"
        Me.lblCreatedDate.Visible = False
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.lblCreatedBy.Appearance.Options.UseForeColor = True
        Me.lblCreatedBy.Location = New System.Drawing.Point(13, 37)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(58, 13)
        Me.lblCreatedBy.TabIndex = 46
        Me.lblCreatedBy.Text = "Created By:"
        Me.lblCreatedBy.Visible = False
        '
        'gcStaffTransfer
        '
        Me.gcStaffTransfer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gcStaffTransfer.Location = New System.Drawing.Point(15, 280)
        Me.gcStaffTransfer.MainView = Me.gvStaffTransfer
        Me.gcStaffTransfer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gcStaffTransfer.Name = "gcStaffTransfer"
        Me.gcStaffTransfer.Size = New System.Drawing.Size(1059, 310)
        Me.gcStaffTransfer.TabIndex = 20
        Me.gcStaffTransfer.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvStaffTransfer})
        '
        'gvStaffTransfer
        '
        Me.gvStaffTransfer.GridControl = Me.gcStaffTransfer
        Me.gvStaffTransfer.Name = "gvStaffTransfer"
        Me.gvStaffTransfer.OptionsBehavior.Editable = False
        Me.gvStaffTransfer.OptionsView.EnableAppearanceOddRow = True
        Me.gvStaffTransfer.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.gvStaffTransfer.OptionsView.ShowAutoFilterRow = True
        Me.gvStaffTransfer.OptionsView.ShowFooter = True
        Me.gvStaffTransfer.OptionsView.ShowGroupPanel = False
        '
        'ppMenuPopup
        '
        Me.ppMenuPopup.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiEdit, True)})
        Me.ppMenuPopup.Manager = Me.bmMenuPopup
        Me.ppMenuPopup.Name = "ppMenuPopup"
        '
        'bbiEdit
        '
        Me.bbiEdit.Caption = "Modify"
        Me.bbiEdit.Glyph = CType(resources.GetObject("bbiEdit.Glyph"), System.Drawing.Image)
        Me.bbiEdit.Id = 4
        Me.bbiEdit.LargeGlyph = CType(resources.GetObject("bbiEdit.LargeGlyph"), System.Drawing.Image)
        Me.bbiEdit.Name = "bbiEdit"
        '
        'bmMenuPopup
        '
        Me.bmMenuPopup.DockControls.Add(Me.barDockControlTop)
        Me.bmMenuPopup.DockControls.Add(Me.barDockControlBottom)
        Me.bmMenuPopup.DockControls.Add(Me.barDockControlLeft)
        Me.bmMenuPopup.DockControls.Add(Me.barDockControlRight)
        Me.bmMenuPopup.Form = Me
        Me.bmMenuPopup.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiMAddUser, Me.bbiPEditHoliday, Me.bbiMCancel, Me.bbiDisableUser, Me.bbiEdit, Me.bbiPClose})
        Me.bmMenuPopup.MaxItemId = 6
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1087, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 669)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1087, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 669)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1087, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 669)
        '
        'bbiMAddUser
        '
        Me.bbiMAddUser.Caption = "Add User"
        Me.bbiMAddUser.Id = 0
        Me.bbiMAddUser.ImageUri.Uri = "AddItem"
        Me.bbiMAddUser.Name = "bbiMAddUser"
        '
        'bbiPEditHoliday
        '
        Me.bbiPEditHoliday.Caption = "Edit Holiday"
        Me.bbiPEditHoliday.Id = 1
        Me.bbiPEditHoliday.ImageUri.Uri = "Edit"
        Me.bbiPEditHoliday.Name = "bbiPEditHoliday"
        '
        'bbiMCancel
        '
        Me.bbiMCancel.Caption = "Cancel"
        Me.bbiMCancel.Id = 2
        Me.bbiMCancel.ImageUri.Uri = "Refresh"
        Me.bbiMCancel.Name = "bbiMCancel"
        '
        'bbiDisableUser
        '
        Me.bbiDisableUser.Caption = "Disable User"
        Me.bbiDisableUser.Glyph = CType(resources.GetObject("bbiDisableUser.Glyph"), System.Drawing.Image)
        Me.bbiDisableUser.Id = 3
        Me.bbiDisableUser.Name = "bbiDisableUser"
        '
        'bbiPClose
        '
        Me.bbiPClose.Caption = "Export To Excel..."
        Me.bbiPClose.Glyph = CType(resources.GetObject("bbiPClose.Glyph"), System.Drawing.Image)
        Me.bbiPClose.Id = 5
        Me.bbiPClose.LargeGlyph = CType(resources.GetObject("bbiPClose.LargeGlyph"), System.Drawing.Image)
        Me.bbiPClose.Name = "bbiPClose"
        '
        'lueSection
        '
        Me.lueSection.EditValue = ""
        Me.lueSection.Enabled = False
        Me.lueSection.Location = New System.Drawing.Point(97, 167)
        Me.lueSection.Name = "lueSection"
        Me.lueSection.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueSection.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueSection.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.lueSection.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueSection.Size = New System.Drawing.Size(233, 20)
        Me.lueSection.TabIndex = 3363
        '
        'frmEmployeeHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1087, 669)
        Me.Controls.Add(Me.gcStaffTransfer)
        Me.Controls.Add(Me.panelControl2)
        Me.Controls.Add(Me.groupControl3)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmployeeHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employee History"
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtENName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupControl3.ResumeLayout(False)
        Me.groupControl3.PerformLayout()
        CType(Me.txtEmpID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApprovedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meRemark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstManagementLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueManagementLevel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueDepartment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deApprovedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deApprovedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCampus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEffectiveDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueDivision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl2.ResumeLayout(False)
        Me.panelControl2.PerformLayout()
        CType(Me.txtUpdatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUpdatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcStaffTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvStaffTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppMenuPopup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenuPopup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueSection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Private WithEvents txtSID As DevExpress.XtraEditors.SearchControl
    Private WithEvents btnTrush As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Private WithEvents groupControl3 As DevExpress.XtraEditors.GroupControl
    Private WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Private WithEvents lueDepartment As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents lueCampus As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents lueDivision As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents deApprovedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deEffectiveDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents meRemark As DevExpress.XtraEditors.MemoEdit
    Private WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtENName As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Private WithEvents panelControl2 As DevExpress.XtraEditors.PanelControl
    Private WithEvents txtUpdatedDate As DevExpress.XtraEditors.TextEdit
    Private WithEvents txtUpdatedBy As DevExpress.XtraEditors.TextEdit
    Private WithEvents lblUpdatedDate As DevExpress.XtraEditors.LabelControl
    Private WithEvents lblUpdatedBy As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtCreatedDate As DevExpress.XtraEditors.TextEdit
    Private WithEvents txtCreatedBy As DevExpress.XtraEditors.TextEdit
    Private WithEvents lblCreatedDate As DevExpress.XtraEditors.LabelControl
    Private WithEvents lblCreatedBy As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gcStaffTransfer As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvStaffTransfer As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents btnBrowse As DevExpress.XtraEditors.SimpleButton
    Private WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtReason As DevExpress.XtraEditors.TextEdit
    Private WithEvents txtApprovedBy As DevExpress.XtraEditors.TextEdit
    Private WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Private WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnEditIns As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnAddIns As DevExpress.XtraEditors.SimpleButton
    Private WithEvents lstManagementLevel As DevExpress.XtraEditors.ListBoxControl
    Private WithEvents lueManagementLevel As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPosition As DevExpress.XtraEditors.ButtonEdit
    Private WithEvents txtEmpID As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ppMenuPopup As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bmMenuPopup As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiMAddUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPEditHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiMCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiDisableUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPClose As DevExpress.XtraBars.BarButtonItem
    Private WithEvents LabelControl36 As DevExpress.XtraEditors.LabelControl
    Private WithEvents lueSection As DevExpress.XtraEditors.LookUpEdit
End Class
