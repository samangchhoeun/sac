<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientVitalSign
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientVitalSign))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtDOB = New DevExpress.XtraEditors.TextEdit()
        Me.bmMenu = New DevExpress.XtraBars.BarManager(Me.components)
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
        Me.bbiPAddNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPModify = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRestore = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPVitalSign = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPFindCheckIn = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPExport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.gcWaiting = New DevExpress.XtraGrid.GridControl()
        Me.gvWaiting = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.meChiefComplaint = New DevExpress.XtraEditors.MemoEdit()
        Me.lueClinic = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtAge = New DevExpress.XtraEditors.TextEdit()
        Me.txtGender = New DevExpress.XtraEditors.TextEdit()
        Me.txtPatientName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSID = New DevExpress.XtraEditors.SearchControl()
        Me.gcData = New DevExpress.XtraGrid.GridControl()
        Me.gvData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtSao2 = New DevExpress.XtraEditors.TextEdit()
        Me.txtRR = New DevExpress.XtraEditors.TextEdit()
        Me.txtPulse = New DevExpress.XtraEditors.TextEdit()
        Me.txtBMP = New DevExpress.XtraEditors.TextEdit()
        Me.txtTemp = New DevExpress.XtraEditors.TextEdit()
        Me.txtWeight = New DevExpress.XtraEditors.TextEdit()
        Me.txtHeight = New DevExpress.XtraEditors.TextEdit()
        Me.teTime = New DevExpress.XtraEditors.TimeEdit()
        Me.deDate = New DevExpress.XtraEditors.DateEdit()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBMICalc = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lcgWaiting = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgVitalSignHistory = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.pmMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.timPatientWaitingForVitalSign = New System.Windows.Forms.Timer(Me.components)
        Me.pmWaitingForVitalSign = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtDOB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcWaiting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvWaiting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meChiefComplaint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueClinic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGender.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPatientName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSao2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPulse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBMP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTemp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgWaiting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgVitalSignHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmWaitingForVitalSign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtDOB)
        Me.LayoutControl1.Controls.Add(Me.btnBrowse)
        Me.LayoutControl1.Controls.Add(Me.gcWaiting)
        Me.LayoutControl1.Controls.Add(Me.meChiefComplaint)
        Me.LayoutControl1.Controls.Add(Me.lueClinic)
        Me.LayoutControl1.Controls.Add(Me.txtAge)
        Me.LayoutControl1.Controls.Add(Me.txtGender)
        Me.LayoutControl1.Controls.Add(Me.txtPatientName)
        Me.LayoutControl1.Controls.Add(Me.txtSID)
        Me.LayoutControl1.Controls.Add(Me.gcData)
        Me.LayoutControl1.Controls.Add(Me.txtSao2)
        Me.LayoutControl1.Controls.Add(Me.txtRR)
        Me.LayoutControl1.Controls.Add(Me.txtPulse)
        Me.LayoutControl1.Controls.Add(Me.txtBMP)
        Me.LayoutControl1.Controls.Add(Me.txtTemp)
        Me.LayoutControl1.Controls.Add(Me.txtWeight)
        Me.LayoutControl1.Controls.Add(Me.txtHeight)
        Me.LayoutControl1.Controls.Add(Me.teTime)
        Me.LayoutControl1.Controls.Add(Me.deDate)
        Me.LayoutControl1.Controls.Add(Me.btnClose)
        Me.LayoutControl1.Controls.Add(Me.btnSave)
        Me.LayoutControl1.Controls.Add(Me.btnNew)
        Me.LayoutControl1.Controls.Add(Me.btnBMICalc)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(712, 337, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1208, 720)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtDOB
        '
        Me.txtDOB.Location = New System.Drawing.Point(129, 518)
        Me.txtDOB.MenuManager = Me.bmMenu
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Properties.Appearance.BackColor = System.Drawing.Color.Azure
        Me.txtDOB.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.txtDOB.Properties.Appearance.Options.UseBackColor = True
        Me.txtDOB.Properties.Appearance.Options.UseForeColor = True
        Me.txtDOB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtDOB.Properties.ReadOnly = True
        Me.txtDOB.Size = New System.Drawing.Size(169, 20)
        Me.txtDOB.StyleController = Me.LayoutControl1
        Me.txtDOB.TabIndex = 4
        '
        'bmMenu
        '
        Me.bmMenu.DockControls.Add(Me.barDockControlTop)
        Me.bmMenu.DockControls.Add(Me.barDockControlBottom)
        Me.bmMenu.DockControls.Add(Me.barDockControlLeft)
        Me.bmMenu.DockControls.Add(Me.barDockControlRight)
        Me.bmMenu.Form = Me
        Me.bmMenu.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPAddHoilday, Me.bbiPEditHoliday, Me.bbiPRemoveHoliday, Me.bbiPSearch, Me.bbiPSetCommonLeave, Me.BarButtonItem1, Me.bbiRemoveFromCL, Me.bbiCopyTo, Me.bbiPAddNew, Me.bbiPModify, Me.bbiPRemove, Me.bbiPRestore, Me.bbiPVitalSign, Me.bbiPFindCheckIn, Me.bbiPExport})
        Me.bmMenu.MaxItemId = 15
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1208, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 720)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1208, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 720)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1208, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 720)
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
        'bbiPAddNew
        '
        Me.bbiPAddNew.Caption = "Add New"
        Me.bbiPAddNew.Id = 8
        Me.bbiPAddNew.ImageUri.Uri = "AddItem"
        Me.bbiPAddNew.Name = "bbiPAddNew"
        '
        'bbiPModify
        '
        Me.bbiPModify.Caption = "Modify"
        Me.bbiPModify.Id = 9
        Me.bbiPModify.ImageUri.Uri = "Edit"
        Me.bbiPModify.Name = "bbiPModify"
        '
        'bbiPRemove
        '
        Me.bbiPRemove.Caption = "Remove"
        Me.bbiPRemove.Id = 10
        Me.bbiPRemove.ImageUri.Uri = "Delete"
        Me.bbiPRemove.Name = "bbiPRemove"
        '
        'bbiPRestore
        '
        Me.bbiPRestore.Caption = "Restore"
        Me.bbiPRestore.Id = 11
        Me.bbiPRestore.ImageUri.Uri = "Forward"
        Me.bbiPRestore.Name = "bbiPRestore"
        Me.bbiPRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbiPVitalSign
        '
        Me.bbiPVitalSign.Caption = "Vital Sign"
        Me.bbiPVitalSign.Id = 12
        Me.bbiPVitalSign.ImageUri.Uri = "Apply"
        Me.bbiPVitalSign.Name = "bbiPVitalSign"
        '
        'bbiPFindCheckIn
        '
        Me.bbiPFindCheckIn.Caption = "Search Patient Check-In"
        Me.bbiPFindCheckIn.Id = 13
        Me.bbiPFindCheckIn.ImageUri.Uri = "SwitchTimeScalesTo"
        Me.bbiPFindCheckIn.Name = "bbiPFindCheckIn"
        '
        'bbiPExport
        '
        Me.bbiPExport.Caption = "Export to Excel..."
        Me.bbiPExport.Id = 14
        Me.bbiPExport.ImageUri.Uri = "ExportToXLSX"
        Me.bbiPExport.Name = "bbiPExport"
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnBrowse.Location = New System.Drawing.Point(270, 412)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(28, 22)
        Me.btnBrowse.StyleController = Me.LayoutControl1
        Me.btnBrowse.TabIndex = 1
        '
        'gcWaiting
        '
        Me.gcWaiting.Location = New System.Drawing.Point(15, 39)
        Me.gcWaiting.MainView = Me.gvWaiting
        Me.gcWaiting.Name = "gcWaiting"
        Me.gcWaiting.Size = New System.Drawing.Size(292, 316)
        Me.gcWaiting.TabIndex = 20
        Me.gcWaiting.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvWaiting})
        '
        'gvWaiting
        '
        Me.gvWaiting.GridControl = Me.gcWaiting
        Me.gvWaiting.Name = "gvWaiting"
        Me.gvWaiting.OptionsBehavior.Editable = False
        Me.gvWaiting.OptionsBehavior.ReadOnly = True
        Me.gvWaiting.OptionsView.ShowAutoFilterRow = True
        Me.gvWaiting.OptionsView.ShowGroupPanel = False
        '
        'meChiefComplaint
        '
        Me.meChiefComplaint.Location = New System.Drawing.Point(24, 664)
        Me.meChiefComplaint.Name = "meChiefComplaint"
        Me.meChiefComplaint.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meChiefComplaint.Size = New System.Drawing.Size(274, 32)
        Me.meChiefComplaint.StyleController = Me.LayoutControl1
        Me.meChiefComplaint.TabIndex = 7
        '
        'lueClinic
        '
        Me.lueClinic.Location = New System.Drawing.Point(129, 586)
        Me.lueClinic.Name = "lueClinic"
        Me.lueClinic.Properties.Appearance.BackColor = System.Drawing.Color.Azure
        Me.lueClinic.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.lueClinic.Properties.Appearance.Options.UseBackColor = True
        Me.lueClinic.Properties.Appearance.Options.UseForeColor = True
        Me.lueClinic.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueClinic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueClinic.Properties.NullText = ""
        Me.lueClinic.Size = New System.Drawing.Size(169, 20)
        Me.lueClinic.StyleController = Me.LayoutControl1
        Me.lueClinic.TabIndex = 6
        '
        'txtAge
        '
        Me.txtAge.Location = New System.Drawing.Point(129, 550)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Properties.Appearance.BackColor = System.Drawing.Color.Azure
        Me.txtAge.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.txtAge.Properties.Appearance.Options.UseBackColor = True
        Me.txtAge.Properties.Appearance.Options.UseForeColor = True
        Me.txtAge.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtAge.Properties.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(169, 20)
        Me.txtAge.StyleController = Me.LayoutControl1
        Me.txtAge.TabIndex = 5
        '
        'txtGender
        '
        Me.txtGender.Location = New System.Drawing.Point(129, 486)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.Properties.Appearance.BackColor = System.Drawing.Color.Azure
        Me.txtGender.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.txtGender.Properties.Appearance.Options.UseBackColor = True
        Me.txtGender.Properties.Appearance.Options.UseForeColor = True
        Me.txtGender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtGender.Properties.ReadOnly = True
        Me.txtGender.Size = New System.Drawing.Size(169, 20)
        Me.txtGender.StyleController = Me.LayoutControl1
        Me.txtGender.TabIndex = 3
        '
        'txtPatientName
        '
        Me.txtPatientName.Location = New System.Drawing.Point(129, 450)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Properties.Appearance.BackColor = System.Drawing.Color.Azure
        Me.txtPatientName.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.txtPatientName.Properties.Appearance.Options.UseBackColor = True
        Me.txtPatientName.Properties.Appearance.Options.UseForeColor = True
        Me.txtPatientName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPatientName.Properties.ReadOnly = True
        Me.txtPatientName.Size = New System.Drawing.Size(169, 20)
        Me.txtPatientName.StyleController = Me.LayoutControl1
        Me.txtPatientName.TabIndex = 2
        '
        'txtSID
        '
        Me.txtSID.Location = New System.Drawing.Point(129, 412)
        Me.txtSID.Name = "txtSID"
        Me.txtSID.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtSID.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSID.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson
        Me.txtSID.Properties.Appearance.Options.UseBackColor = True
        Me.txtSID.Properties.Appearance.Options.UseFont = True
        Me.txtSID.Properties.Appearance.Options.UseForeColor = True
        Me.txtSID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.txtSID.Properties.MaxLength = 11
        Me.txtSID.Properties.NullValuePrompt = "Patient Code"
        Me.txtSID.Size = New System.Drawing.Size(137, 22)
        Me.txtSID.StyleController = Me.LayoutControl1
        Me.txtSID.TabIndex = 0
        '
        'gcData
        '
        Me.gcData.Location = New System.Drawing.Point(325, 175)
        Me.gcData.MainView = Me.gvData
        Me.gcData.Name = "gcData"
        Me.gcData.Size = New System.Drawing.Size(868, 488)
        Me.gcData.TabIndex = 21
        Me.gcData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvData})
        '
        'gvData
        '
        Me.gvData.GridControl = Me.gcData
        Me.gvData.Name = "gvData"
        Me.gvData.OptionsBehavior.Editable = False
        Me.gvData.OptionsBehavior.ReadOnly = True
        Me.gvData.OptionsView.ShowAutoFilterRow = True
        Me.gvData.OptionsView.ShowGroupPanel = False
        '
        'txtSao2
        '
        Me.txtSao2.Location = New System.Drawing.Point(950, 112)
        Me.txtSao2.Name = "txtSao2"
        Me.txtSao2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSao2.Size = New System.Drawing.Size(143, 20)
        Me.txtSao2.StyleController = Me.LayoutControl1
        Me.txtSao2.TabIndex = 16
        '
        'txtRR
        '
        Me.txtRR.Location = New System.Drawing.Point(799, 112)
        Me.txtRR.Name = "txtRR"
        Me.txtRR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtRR.Size = New System.Drawing.Size(139, 20)
        Me.txtRR.StyleController = Me.LayoutControl1
        Me.txtRR.TabIndex = 15
        '
        'txtPulse
        '
        Me.txtPulse.Location = New System.Drawing.Point(633, 112)
        Me.txtPulse.Name = "txtPulse"
        Me.txtPulse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPulse.Size = New System.Drawing.Size(154, 20)
        Me.txtPulse.StyleController = Me.LayoutControl1
        Me.txtPulse.TabIndex = 14
        '
        'txtBMP
        '
        Me.txtBMP.Location = New System.Drawing.Point(334, 112)
        Me.txtBMP.Name = "txtBMP"
        Me.txtBMP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtBMP.Size = New System.Drawing.Size(287, 20)
        Me.txtBMP.StyleController = Me.LayoutControl1
        Me.txtBMP.TabIndex = 13
        '
        'txtTemp
        '
        Me.txtTemp.Location = New System.Drawing.Point(950, 66)
        Me.txtTemp.Name = "txtTemp"
        Me.txtTemp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtTemp.Size = New System.Drawing.Size(143, 20)
        Me.txtTemp.StyleController = Me.LayoutControl1
        Me.txtTemp.TabIndex = 12
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(799, 66)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtWeight.Size = New System.Drawing.Size(139, 20)
        Me.txtWeight.StyleController = Me.LayoutControl1
        Me.txtWeight.TabIndex = 11
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(633, 66)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtHeight.Size = New System.Drawing.Size(154, 20)
        Me.txtHeight.StyleController = Me.LayoutControl1
        Me.txtHeight.TabIndex = 10
        '
        'teTime
        '
        Me.teTime.EditValue = New Date(2020, 1, 5, 0, 0, 0, 0)
        Me.teTime.Location = New System.Drawing.Point(508, 66)
        Me.teTime.Name = "teTime"
        Me.teTime.Properties.Appearance.BackColor = System.Drawing.Color.Azure
        Me.teTime.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.teTime.Properties.Appearance.Options.UseBackColor = True
        Me.teTime.Properties.Appearance.Options.UseForeColor = True
        Me.teTime.Properties.Appearance.Options.UseTextOptions = True
        Me.teTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.teTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.teTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.teTime.Size = New System.Drawing.Size(113, 20)
        Me.teTime.StyleController = Me.LayoutControl1
        Me.teTime.TabIndex = 9
        '
        'deDate
        '
        Me.deDate.EditValue = Nothing
        Me.deDate.Location = New System.Drawing.Point(334, 66)
        Me.deDate.Name = "deDate"
        Me.deDate.Properties.Appearance.BackColor = System.Drawing.Color.Azure
        Me.deDate.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.deDate.Properties.Appearance.Options.UseBackColor = True
        Me.deDate.Properties.Appearance.Options.UseForeColor = True
        Me.deDate.Properties.Appearance.Options.UseTextOptions = True
        Me.deDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.deDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDate.Properties.DisplayFormat.FormatString = "MMM dd, yyyy"
        Me.deDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deDate.Size = New System.Drawing.Size(167, 20)
        Me.deDate.StyleController = Me.LayoutControl1
        Me.deDate.TabIndex = 8
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1117, 670)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(79, 38)
        Me.btnClose.StyleController = Me.LayoutControl1
        Me.btnClose.TabIndex = 21
        Me.btnClose.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(1107, 68)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 38)
        Me.btnSave.StyleController = Me.LayoutControl1
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Save"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Location = New System.Drawing.Point(1107, 110)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(77, 22)
        Me.btnNew.StyleController = Me.LayoutControl1
        Me.btnNew.TabIndex = 19
        Me.btnNew.Text = "New"
        '
        'btnBMICalc
        '
        Me.btnBMICalc.Image = CType(resources.GetObject("btnBMICalc.Image"), System.Drawing.Image)
        Me.btnBMICalc.Location = New System.Drawing.Point(981, 670)
        Me.btnBMICalc.Name = "btnBMICalc"
        Me.btnBMICalc.Size = New System.Drawing.Size(132, 38)
        Me.btnBMICalc.StyleController = Me.LayoutControl1
        Me.btnBMICalc.TabIndex = 20
        Me.btnBMICalc.Text = "BMI Calculator"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcgWaiting, Me.LayoutControlGroup3, Me.LayoutControlGroup4, Me.lcgVitalSignHistory, Me.LayoutControlItem1, Me.LayoutControlItem4, Me.LayoutControlGroup6, Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1208, 720)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'lcgWaiting
        '
        Me.lcgWaiting.CaptionImage = CType(resources.GetObject("lcgWaiting.CaptionImage"), System.Drawing.Image)
        Me.lcgWaiting.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem22})
        Me.lcgWaiting.Location = New System.Drawing.Point(0, 0)
        Me.lcgWaiting.Name = "lcgWaiting"
        Me.lcgWaiting.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.lcgWaiting.Size = New System.Drawing.Size(302, 350)
        Me.lcgWaiting.Text = "Patient Waiting for Vital Sign "
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.gcWaiting
        Me.LayoutControlItem22.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(296, 320)
        Me.LayoutControlItem22.Text = "Patient Vital Sign Waiting List"
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem22.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CaptionImage = CType(resources.GetObject("LayoutControlGroup3.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem2, Me.LayoutControlItem3, Me.LayoutControlItem2, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.EmptySpaceItem1})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(302, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(886, 136)
        Me.LayoutControlGroup3.Spacing = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlGroup3.Text = "Vital Sign Information"
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(763, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(10, 88)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnSave
        Me.LayoutControlItem3.Location = New System.Drawing.Point(773, 20)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(81, 42)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnNew
        Me.LayoutControlItem2.Location = New System.Drawing.Point(773, 62)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(81, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.deDate
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 5, 2, 8)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(174, 48)
        Me.LayoutControlItem5.Text = "Date"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(102, 13)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.teTime
        Me.LayoutControlItem6.Location = New System.Drawing.Point(174, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(125, 48)
        Me.LayoutControlItem6.Text = "Time"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(102, 13)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtHeight
        Me.LayoutControlItem7.Location = New System.Drawing.Point(299, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(166, 48)
        Me.LayoutControlItem7.Text = "Height (cm)"
        Me.LayoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(102, 13)
        Me.LayoutControlItem7.TextToControlDistance = 5
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtWeight
        Me.LayoutControlItem8.Location = New System.Drawing.Point(465, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 8)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(151, 48)
        Me.LayoutControlItem8.Text = "Weight (kg)"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(102, 13)
        Me.LayoutControlItem8.TextToControlDistance = 5
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtTemp
        Me.LayoutControlItem9.Location = New System.Drawing.Point(616, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(147, 48)
        Me.LayoutControlItem9.Text = "Temp (°C)"
        Me.LayoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(102, 13)
        Me.LayoutControlItem9.TextToControlDistance = 5
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.txtRR
        Me.LayoutControlItem12.Location = New System.Drawing.Point(465, 48)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem12.Size = New System.Drawing.Size(151, 40)
        Me.LayoutControlItem12.Text = "RR (min)"
        Me.LayoutControlItem12.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.txtSao2
        Me.LayoutControlItem13.Location = New System.Drawing.Point(616, 48)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(147, 40)
        Me.LayoutControlItem13.Text = "Sao2 (%)"
        Me.LayoutControlItem13.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtBMP
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(299, 40)
        Me.LayoutControlItem10.Text = "BPM"
        Me.LayoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtPulse
        Me.LayoutControlItem11.Location = New System.Drawing.Point(299, 48)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem11.Size = New System.Drawing.Size(166, 40)
        Me.LayoutControlItem11.Text = "Pulse"
        Me.LayoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(46, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(773, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(81, 20)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CaptionImage = CType(resources.GetObject("LayoutControlGroup4.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem15, Me.LayoutControlItem16, Me.LayoutControlItem17, Me.LayoutControlItem18, Me.LayoutControlItem20, Me.LayoutControlItem23, Me.LayoutControlItem19})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 350)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(302, 266)
        Me.LayoutControlGroup4.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 10, 2)
        Me.LayoutControlGroup4.Text = "Patient Information"
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.txtSID
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 8)
        Me.LayoutControlItem15.Size = New System.Drawing.Size(246, 38)
        Me.LayoutControlItem15.Text = "Patient Code"
        Me.LayoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(100, 20)
        Me.LayoutControlItem15.TextToControlDistance = 5
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.txtPatientName
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 38)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 8)
        Me.LayoutControlItem16.Size = New System.Drawing.Size(278, 36)
        Me.LayoutControlItem16.Text = "Patient Name"
        Me.LayoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(100, 20)
        Me.LayoutControlItem16.TextToControlDistance = 5
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.txtGender
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 74)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 8)
        Me.LayoutControlItem17.Size = New System.Drawing.Size(278, 36)
        Me.LayoutControlItem17.Text = "Gender"
        Me.LayoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(100, 20)
        Me.LayoutControlItem17.TextToControlDistance = 5
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.txtAge
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 138)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 8)
        Me.LayoutControlItem18.Size = New System.Drawing.Size(278, 36)
        Me.LayoutControlItem18.Text = "Age"
        Me.LayoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(100, 20)
        Me.LayoutControlItem18.TextToControlDistance = 5
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.lueClinic
        Me.LayoutControlItem20.Location = New System.Drawing.Point(0, 174)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 8)
        Me.LayoutControlItem20.Size = New System.Drawing.Size(278, 36)
        Me.LayoutControlItem20.Text = "Clinic"
        Me.LayoutControlItem20.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(100, 20)
        Me.LayoutControlItem20.TextToControlDistance = 5
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.btnBrowse
        Me.LayoutControlItem23.Location = New System.Drawing.Point(246, 0)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 8)
        Me.LayoutControlItem23.Size = New System.Drawing.Size(32, 38)
        Me.LayoutControlItem23.Text = "Browse"
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem23.TextVisible = False
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.txtDOB
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 110)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 4)
        Me.LayoutControlItem19.Size = New System.Drawing.Size(278, 28)
        Me.LayoutControlItem19.Text = "Date of Birth"
        Me.LayoutControlItem19.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(100, 20)
        Me.LayoutControlItem19.TextToControlDistance = 5
        '
        'lcgVitalSignHistory
        '
        Me.lcgVitalSignHistory.CaptionImage = CType(resources.GetObject("lcgVitalSignHistory.CaptionImage"), System.Drawing.Image)
        Me.lcgVitalSignHistory.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem14})
        Me.lcgVitalSignHistory.Location = New System.Drawing.Point(302, 136)
        Me.lcgVitalSignHistory.Name = "lcgVitalSignHistory"
        Me.lcgVitalSignHistory.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.lcgVitalSignHistory.Size = New System.Drawing.Size(886, 522)
        Me.lcgVitalSignHistory.Spacing = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.lcgVitalSignHistory.Text = "Patient Vital Sign History"
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.gcData
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(872, 492)
        Me.LayoutControlItem14.Text = "Patient Vital Sign Waiting List"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnBMICalc
        Me.LayoutControlItem1.Location = New System.Drawing.Point(969, 658)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(136, 42)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnClose
        Me.LayoutControlItem4.Location = New System.Drawing.Point(1105, 658)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(83, 42)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.CaptionImage = CType(resources.GetObject("LayoutControlGroup6.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem21})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 616)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup6"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(302, 84)
        Me.LayoutControlGroup6.Text = "Chief Complaint"
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.meChiefComplaint
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(278, 36)
        Me.LayoutControlItem21.Text = "Chief Complaint"
        Me.LayoutControlItem21.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem21.TextToControlDistance = 0
        Me.LayoutControlItem21.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem5})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(302, 658)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(667, 42)
        Me.LayoutControlGroup2.Spacing = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlGroup2.Text = "Blank"
        Me.LayoutControlGroup2.TextVisible = False
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(635, 18)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'pmMenu
        '
        Me.pmMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPAddNew, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPModify, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRestore, True)})
        Me.pmMenu.Manager = Me.bmMenu
        Me.pmMenu.Name = "pmMenu"
        '
        'timPatientWaitingForVitalSign
        '
        Me.timPatientWaitingForVitalSign.Enabled = True
        Me.timPatientWaitingForVitalSign.Interval = 5000
        '
        'pmWaitingForVitalSign
        '
        Me.pmWaitingForVitalSign.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPVitalSign)})
        Me.pmWaitingForVitalSign.Manager = Me.bmMenu
        Me.pmWaitingForVitalSign.Name = "pmWaitingForVitalSign"
        '
        'frmPatientVitalSign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1208, 720)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPatientVitalSign"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Patient Vital Sign"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtDOB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcWaiting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvWaiting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meChiefComplaint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueClinic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGender.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPatientName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSao2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPulse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBMP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTemp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgWaiting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgVitalSignHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmWaitingForVitalSign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lcgWaiting As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lcgVitalSignHistory As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBMICalc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtBMP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTemp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtWeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtHeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents teTime As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents deDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSao2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRR As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPulse As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcData As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents meChiefComplaint As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lueClinic As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtAge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtGender As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPatientName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSID As DevExpress.XtraEditors.SearchControl
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcWaiting As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvWaiting As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents bmMenu As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPAddHoilday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPEditHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemoveHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPSetCommonLeave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiRemoveFromCL As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiCopyTo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPAddNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPModify As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRestore As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pmMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents timPatientWaitingForVitalSign As Timer
    Friend WithEvents pmWaitingForVitalSign As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiPVitalSign As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPFindCheckIn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDOB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
End Class
