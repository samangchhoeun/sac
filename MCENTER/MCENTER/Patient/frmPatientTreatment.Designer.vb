<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientTreatment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientTreatment))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtPatientCode = New DevExpress.XtraEditors.SearchControl()
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
        Me.bbiPTreatment = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPFindCheckIn = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPExport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNote = New DevExpress.XtraEditors.TextEdit()
        Me.txtDxCode = New DevExpress.XtraEditors.TextEdit()
        Me.lueDiagnosis = New DevExpress.XtraEditors.LookUpEdit()
        Me.lueDxGroup = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblRec = New DevExpress.XtraEditors.LabelControl()
        Me.btnPrev = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNext = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRx = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBMICalc = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDateCheckIn = New DevExpress.XtraEditors.TextEdit()
        Me.lueClinic = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtPatientType = New DevExpress.XtraEditors.TextEdit()
        Me.txtAge = New DevExpress.XtraEditors.TextEdit()
        Me.txtDOB = New DevExpress.XtraEditors.TextEdit()
        Me.txtGender = New DevExpress.XtraEditors.TextEdit()
        Me.txtPatient = New DevExpress.XtraEditors.TextEdit()
        Me.gcDiagnosis = New DevExpress.XtraGrid.GridControl()
        Me.gvDiagnosis = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcVitalSign = New DevExpress.XtraGrid.GridControl()
        Me.gvVitalSign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.meProgressNote = New DevExpress.XtraEditors.MemoEdit()
        Me.mePatientComplaint = New DevExpress.XtraEditors.MemoEdit()
        Me.gcPatientsWaiting = New DevExpress.XtraGrid.GridControl()
        Me.gvPatientsWaiting = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtBuilding = New DevExpress.XtraEditors.TextEdit()
        Me.txtClinic = New DevExpress.XtraEditors.TextEdit()
        Me.lueDoctor = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.lcgWaiting = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgVitalSignHistory = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgDiagnosis = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup8 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem30 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ppPatientWaiting = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.ppMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.timPatientWaiting = New System.Windows.Forms.Timer(Me.components)
        Me.ppDiagnosis = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtPatientCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDxCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueDxGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateCheckIn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueClinic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPatientType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDOB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGender.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPatient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcVitalSign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvVitalSign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meProgressNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mePatientComplaint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcPatientsWaiting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvPatientsWaiting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBuilding.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClinic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueDoctor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgWaiting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgVitalSignHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppPatientWaiting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtPatientCode)
        Me.LayoutControl1.Controls.Add(Me.btnChoose)
        Me.LayoutControl1.Controls.Add(Me.txtNote)
        Me.LayoutControl1.Controls.Add(Me.txtDxCode)
        Me.LayoutControl1.Controls.Add(Me.lueDiagnosis)
        Me.LayoutControl1.Controls.Add(Me.lueDxGroup)
        Me.LayoutControl1.Controls.Add(Me.lblRec)
        Me.LayoutControl1.Controls.Add(Me.btnPrev)
        Me.LayoutControl1.Controls.Add(Me.btnNext)
        Me.LayoutControl1.Controls.Add(Me.btnRx)
        Me.LayoutControl1.Controls.Add(Me.btnBMICalc)
        Me.LayoutControl1.Controls.Add(Me.btnClose)
        Me.LayoutControl1.Controls.Add(Me.btnSearch)
        Me.LayoutControl1.Controls.Add(Me.btnNew)
        Me.LayoutControl1.Controls.Add(Me.btnSave)
        Me.LayoutControl1.Controls.Add(Me.txtDateCheckIn)
        Me.LayoutControl1.Controls.Add(Me.lueClinic)
        Me.LayoutControl1.Controls.Add(Me.txtPatientType)
        Me.LayoutControl1.Controls.Add(Me.txtAge)
        Me.LayoutControl1.Controls.Add(Me.txtDOB)
        Me.LayoutControl1.Controls.Add(Me.txtGender)
        Me.LayoutControl1.Controls.Add(Me.txtPatient)
        Me.LayoutControl1.Controls.Add(Me.gcDiagnosis)
        Me.LayoutControl1.Controls.Add(Me.gcVitalSign)
        Me.LayoutControl1.Controls.Add(Me.meProgressNote)
        Me.LayoutControl1.Controls.Add(Me.mePatientComplaint)
        Me.LayoutControl1.Controls.Add(Me.gcPatientsWaiting)
        Me.LayoutControl1.Controls.Add(Me.txtBuilding)
        Me.LayoutControl1.Controls.Add(Me.txtClinic)
        Me.LayoutControl1.Controls.Add(Me.lueDoctor)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(778, 495, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1295, 825)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtPatientCode
        '
        Me.txtPatientCode.Location = New System.Drawing.Point(119, 321)
        Me.txtPatientCode.MenuManager = Me.bmMenu
        Me.txtPatientCode.Name = "txtPatientCode"
        Me.txtPatientCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientCode.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson
        Me.txtPatientCode.Properties.Appearance.Options.UseFont = True
        Me.txtPatientCode.Properties.Appearance.Options.UseForeColor = True
        Me.txtPatientCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPatientCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.txtPatientCode.Properties.MaxLength = 9
        Me.txtPatientCode.Properties.NullValuePrompt = "Enter Patient Code"
        Me.txtPatientCode.Properties.ReadOnly = True
        Me.txtPatientCode.Size = New System.Drawing.Size(195, 22)
        Me.txtPatientCode.StyleController = Me.LayoutControl1
        Me.txtPatientCode.TabIndex = 34
        '
        'bmMenu
        '
        Me.bmMenu.DockControls.Add(Me.barDockControlTop)
        Me.bmMenu.DockControls.Add(Me.barDockControlBottom)
        Me.bmMenu.DockControls.Add(Me.barDockControlLeft)
        Me.bmMenu.DockControls.Add(Me.barDockControlRight)
        Me.bmMenu.Form = Me
        Me.bmMenu.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPAddHoilday, Me.bbiPEditHoliday, Me.bbiPRemoveHoliday, Me.bbiPSearch, Me.bbiPSetCommonLeave, Me.BarButtonItem1, Me.bbiRemoveFromCL, Me.bbiCopyTo, Me.bbiPAddNew, Me.bbiPModify, Me.bbiPRemove, Me.bbiPRestore, Me.bbiPTreatment, Me.bbiPFindCheckIn, Me.bbiPExport})
        Me.bmMenu.MaxItemId = 15
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1295, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 825)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1295, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 825)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1295, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 825)
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
        '
        'bbiPTreatment
        '
        Me.bbiPTreatment.Caption = "Treatment"
        Me.bbiPTreatment.Id = 12
        Me.bbiPTreatment.ImageUri.Uri = "Apply"
        Me.bbiPTreatment.Name = "bbiPTreatment"
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
        'btnChoose
        '
        Me.btnChoose.Enabled = False
        Me.btnChoose.Image = CType(resources.GetObject("btnChoose.Image"), System.Drawing.Image)
        Me.btnChoose.Location = New System.Drawing.Point(1178, 609)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(93, 30)
        Me.btnChoose.StyleController = Me.LayoutControl1
        Me.btnChoose.TabIndex = 33
        Me.btnChoose.Text = "Choose"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(807, 617)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Properties.Appearance.Options.UseFont = True
        Me.txtNote.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtNote.Size = New System.Drawing.Size(354, 22)
        Me.txtNote.StyleController = Me.LayoutControl1
        Me.txtNote.TabIndex = 32
        '
        'txtDxCode
        '
        Me.txtDxCode.Location = New System.Drawing.Point(342, 617)
        Me.txtDxCode.Name = "txtDxCode"
        Me.txtDxCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtDxCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDxCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtDxCode.Properties.Appearance.Options.UseFont = True
        Me.txtDxCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDxCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtDxCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtDxCode.Size = New System.Drawing.Size(82, 22)
        Me.txtDxCode.StyleController = Me.LayoutControl1
        Me.txtDxCode.TabIndex = 31
        '
        'lueDiagnosis
        '
        Me.lueDiagnosis.Location = New System.Drawing.Point(621, 617)
        Me.lueDiagnosis.Name = "lueDiagnosis"
        Me.lueDiagnosis.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lueDiagnosis.Properties.Appearance.Options.UseFont = True
        Me.lueDiagnosis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueDiagnosis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDiagnosis.Properties.NullText = ""
        Me.lueDiagnosis.Size = New System.Drawing.Size(169, 22)
        Me.lueDiagnosis.StyleController = Me.LayoutControl1
        Me.lueDiagnosis.TabIndex = 30
        '
        'lueDxGroup
        '
        Me.lueDxGroup.Location = New System.Drawing.Point(441, 617)
        Me.lueDxGroup.Name = "lueDxGroup"
        Me.lueDxGroup.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lueDxGroup.Properties.Appearance.Options.UseFont = True
        Me.lueDxGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueDxGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDxGroup.Properties.NullText = ""
        Me.lueDxGroup.Size = New System.Drawing.Size(163, 22)
        Me.lueDxGroup.StyleController = Me.LayoutControl1
        Me.lueDxGroup.TabIndex = 29
        '
        'lblRec
        '
        Me.lblRec.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRec.Appearance.Options.UseFont = True
        Me.lblRec.Location = New System.Drawing.Point(726, 776)
        Me.lblRec.Name = "lblRec"
        Me.lblRec.Size = New System.Drawing.Size(27, 16)
        Me.lblRec.StyleController = Me.LayoutControl1
        Me.lblRec.TabIndex = 28
        Me.lblRec.Text = "0 / 0"
        '
        'btnPrev
        '
        Me.btnPrev.Enabled = False
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnPrev.Location = New System.Drawing.Point(682, 763)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(40, 38)
        Me.btnPrev.StyleController = Me.LayoutControl1
        Me.btnPrev.TabIndex = 27
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnNext.Location = New System.Drawing.Point(757, 763)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(40, 38)
        Me.btnNext.StyleController = Me.LayoutControl1
        Me.btnNext.TabIndex = 26
        '
        'btnRx
        '
        Me.btnRx.Enabled = False
        Me.btnRx.Image = CType(resources.GetObject("btnRx.Image"), System.Drawing.Image)
        Me.btnRx.Location = New System.Drawing.Point(918, 763)
        Me.btnRx.Name = "btnRx"
        Me.btnRx.Size = New System.Drawing.Size(57, 38)
        Me.btnRx.StyleController = Me.LayoutControl1
        Me.btnRx.TabIndex = 25
        Me.btnRx.Text = "Rx"
        '
        'btnBMICalc
        '
        Me.btnBMICalc.Enabled = False
        Me.btnBMICalc.Image = CType(resources.GetObject("btnBMICalc.Image"), System.Drawing.Image)
        Me.btnBMICalc.Location = New System.Drawing.Point(801, 763)
        Me.btnBMICalc.Name = "btnBMICalc"
        Me.btnBMICalc.Size = New System.Drawing.Size(113, 38)
        Me.btnBMICalc.StyleController = Me.LayoutControl1
        Me.btnBMICalc.TabIndex = 24
        Me.btnBMICalc.Text = "BMI Calculator"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1201, 763)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(70, 38)
        Me.btnClose.StyleController = Me.LayoutControl1
        Me.btnClose.TabIndex = 23
        Me.btnClose.Text = "Close"
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(1120, 763)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 38)
        Me.btnSearch.StyleController = Me.LayoutControl1
        Me.btnSearch.TabIndex = 22
        Me.btnSearch.Text = "Search"
        '
        'btnNew
        '
        Me.btnNew.Enabled = False
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Location = New System.Drawing.Point(1051, 763)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(65, 38)
        Me.btnNew.StyleController = Me.LayoutControl1
        Me.btnNew.TabIndex = 21
        Me.btnNew.Text = "New"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(979, 763)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 38)
        Me.btnSave.StyleController = Me.LayoutControl1
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        '
        'txtDateCheckIn
        '
        Me.txtDateCheckIn.Location = New System.Drawing.Point(119, 519)
        Me.txtDateCheckIn.Name = "txtDateCheckIn"
        Me.txtDateCheckIn.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtDateCheckIn.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateCheckIn.Properties.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.txtDateCheckIn.Properties.Appearance.Options.UseBackColor = True
        Me.txtDateCheckIn.Properties.Appearance.Options.UseFont = True
        Me.txtDateCheckIn.Properties.Appearance.Options.UseForeColor = True
        Me.txtDateCheckIn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtDateCheckIn.Properties.ReadOnly = True
        Me.txtDateCheckIn.Size = New System.Drawing.Size(195, 22)
        Me.txtDateCheckIn.StyleController = Me.LayoutControl1
        Me.txtDateCheckIn.TabIndex = 19
        '
        'lueClinic
        '
        Me.lueClinic.Location = New System.Drawing.Point(119, 491)
        Me.lueClinic.Name = "lueClinic"
        Me.lueClinic.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.lueClinic.Properties.Appearance.Options.UseBackColor = True
        Me.lueClinic.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueClinic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueClinic.Properties.NullText = ""
        Me.lueClinic.Properties.ReadOnly = True
        Me.lueClinic.Size = New System.Drawing.Size(195, 20)
        Me.lueClinic.StyleController = Me.LayoutControl1
        Me.lueClinic.TabIndex = 18
        '
        'txtPatientType
        '
        Me.txtPatientType.Location = New System.Drawing.Point(119, 463)
        Me.txtPatientType.Name = "txtPatientType"
        Me.txtPatientType.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtPatientType.Properties.Appearance.Options.UseBackColor = True
        Me.txtPatientType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPatientType.Properties.ReadOnly = True
        Me.txtPatientType.Size = New System.Drawing.Size(195, 20)
        Me.txtPatientType.StyleController = Me.LayoutControl1
        Me.txtPatientType.TabIndex = 17
        '
        'txtAge
        '
        Me.txtAge.Location = New System.Drawing.Point(119, 435)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtAge.Properties.Appearance.Options.UseBackColor = True
        Me.txtAge.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtAge.Properties.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(195, 20)
        Me.txtAge.StyleController = Me.LayoutControl1
        Me.txtAge.TabIndex = 16
        '
        'txtDOB
        '
        Me.txtDOB.Location = New System.Drawing.Point(119, 407)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtDOB.Properties.Appearance.Options.UseBackColor = True
        Me.txtDOB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtDOB.Properties.ReadOnly = True
        Me.txtDOB.Size = New System.Drawing.Size(195, 20)
        Me.txtDOB.StyleController = Me.LayoutControl1
        Me.txtDOB.TabIndex = 15
        '
        'txtGender
        '
        Me.txtGender.Location = New System.Drawing.Point(119, 379)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtGender.Properties.Appearance.Options.UseBackColor = True
        Me.txtGender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtGender.Properties.ReadOnly = True
        Me.txtGender.Size = New System.Drawing.Size(195, 20)
        Me.txtGender.StyleController = Me.LayoutControl1
        Me.txtGender.TabIndex = 14
        '
        'txtPatient
        '
        Me.txtPatient.Location = New System.Drawing.Point(119, 351)
        Me.txtPatient.Name = "txtPatient"
        Me.txtPatient.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtPatient.Properties.Appearance.Options.UseBackColor = True
        Me.txtPatient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPatient.Properties.ReadOnly = True
        Me.txtPatient.Size = New System.Drawing.Size(195, 20)
        Me.txtPatient.StyleController = Me.LayoutControl1
        Me.txtPatient.TabIndex = 13
        '
        'gcDiagnosis
        '
        Me.gcDiagnosis.Location = New System.Drawing.Point(342, 674)
        Me.gcDiagnosis.MainView = Me.gvDiagnosis
        Me.gcDiagnosis.Name = "gcDiagnosis"
        Me.gcDiagnosis.Size = New System.Drawing.Size(929, 85)
        Me.gcDiagnosis.TabIndex = 11
        Me.gcDiagnosis.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDiagnosis})
        '
        'gvDiagnosis
        '
        Me.gvDiagnosis.GridControl = Me.gcDiagnosis
        Me.gvDiagnosis.Name = "gvDiagnosis"
        Me.gvDiagnosis.OptionsBehavior.Editable = False
        Me.gvDiagnosis.OptionsBehavior.ReadOnly = True
        Me.gvDiagnosis.OptionsView.ShowAutoFilterRow = True
        Me.gvDiagnosis.OptionsView.ShowGroupPanel = False
        '
        'gcVitalSign
        '
        Me.gcVitalSign.Location = New System.Drawing.Point(342, 319)
        Me.gcVitalSign.MainView = Me.gvVitalSign
        Me.gcVitalSign.Name = "gcVitalSign"
        Me.gcVitalSign.Size = New System.Drawing.Size(929, 224)
        Me.gcVitalSign.TabIndex = 10
        Me.gcVitalSign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvVitalSign})
        '
        'gvVitalSign
        '
        Me.gvVitalSign.GridControl = Me.gcVitalSign
        Me.gvVitalSign.Name = "gvVitalSign"
        Me.gvVitalSign.OptionsBehavior.Editable = False
        Me.gvVitalSign.OptionsBehavior.ReadOnly = True
        Me.gvVitalSign.OptionsView.ShowAutoFilterRow = True
        Me.gvVitalSign.OptionsView.ShowGroupPanel = False
        '
        'meProgressNote
        '
        Me.meProgressNote.Location = New System.Drawing.Point(24, 717)
        Me.meProgressNote.Name = "meProgressNote"
        Me.meProgressNote.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.meProgressNote.Properties.Appearance.Options.UseFont = True
        Me.meProgressNote.Size = New System.Drawing.Size(290, 84)
        Me.meProgressNote.StyleController = Me.LayoutControl1
        Me.meProgressNote.TabIndex = 9
        '
        'mePatientComplaint
        '
        Me.mePatientComplaint.Location = New System.Drawing.Point(24, 620)
        Me.mePatientComplaint.Name = "mePatientComplaint"
        Me.mePatientComplaint.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mePatientComplaint.Properties.Appearance.Options.UseFont = True
        Me.mePatientComplaint.Size = New System.Drawing.Size(290, 60)
        Me.mePatientComplaint.StyleController = Me.LayoutControl1
        Me.mePatientComplaint.TabIndex = 8
        '
        'gcPatientsWaiting
        '
        Me.gcPatientsWaiting.Location = New System.Drawing.Point(24, 96)
        Me.gcPatientsWaiting.MainView = Me.gvPatientsWaiting
        Me.gcPatientsWaiting.Name = "gcPatientsWaiting"
        Me.gcPatientsWaiting.Size = New System.Drawing.Size(1247, 171)
        Me.gcPatientsWaiting.TabIndex = 7
        Me.gcPatientsWaiting.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvPatientsWaiting})
        '
        'gvPatientsWaiting
        '
        Me.gvPatientsWaiting.GridControl = Me.gcPatientsWaiting
        Me.gvPatientsWaiting.Name = "gvPatientsWaiting"
        Me.gvPatientsWaiting.OptionsBehavior.Editable = False
        Me.gvPatientsWaiting.OptionsBehavior.ReadOnly = True
        Me.gvPatientsWaiting.OptionsView.ShowAutoFilterRow = True
        Me.gvPatientsWaiting.OptionsView.ShowGroupPanel = False
        '
        'txtBuilding
        '
        Me.txtBuilding.Location = New System.Drawing.Point(603, 24)
        Me.txtBuilding.Name = "txtBuilding"
        Me.txtBuilding.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtBuilding.Properties.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.txtBuilding.Properties.Appearance.Options.UseBackColor = True
        Me.txtBuilding.Properties.Appearance.Options.UseForeColor = True
        Me.txtBuilding.Properties.Appearance.Options.UseTextOptions = True
        Me.txtBuilding.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtBuilding.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtBuilding.Properties.ReadOnly = True
        Me.txtBuilding.Size = New System.Drawing.Size(123, 20)
        Me.txtBuilding.StyleController = Me.LayoutControl1
        Me.txtBuilding.TabIndex = 6
        '
        'txtClinic
        '
        Me.txtClinic.Location = New System.Drawing.Point(390, 24)
        Me.txtClinic.Name = "txtClinic"
        Me.txtClinic.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtClinic.Properties.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.txtClinic.Properties.Appearance.Options.UseBackColor = True
        Me.txtClinic.Properties.Appearance.Options.UseForeColor = True
        Me.txtClinic.Properties.Appearance.Options.UseTextOptions = True
        Me.txtClinic.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtClinic.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtClinic.Properties.ReadOnly = True
        Me.txtClinic.Size = New System.Drawing.Size(126, 20)
        Me.txtClinic.StyleController = Me.LayoutControl1
        Me.txtClinic.TabIndex = 5
        '
        'lueDoctor
        '
        Me.lueDoctor.Location = New System.Drawing.Point(99, 24)
        Me.lueDoctor.Name = "lueDoctor"
        Me.lueDoctor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueDoctor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDoctor.Properties.NullText = ""
        Me.lueDoctor.Size = New System.Drawing.Size(204, 20)
        Me.lueDoctor.StyleController = Me.LayoutControl1
        Me.lueDoctor.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.lcgWaiting, Me.LayoutControlGroup4, Me.lcgVitalSignHistory, Me.LayoutControlGroup6, Me.lcgDiagnosis})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1295, 825)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CaptionImage = CType(resources.GetObject("LayoutControlGroup2.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1275, 48)
        Me.LayoutControlGroup2.Text = "Doctor Information"
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.lueDoctor
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 30, 2, 2)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(311, 24)
        Me.LayoutControlItem1.Text = "Doctor Name"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(70, 20)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtClinic
        Me.LayoutControlItem2.Location = New System.Drawing.Point(311, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 30, 2, 2)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(213, 24)
        Me.LayoutControlItem2.Text = "Clinic"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtBuilding
        Me.LayoutControlItem3.Location = New System.Drawing.Point(524, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 30, 2, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(210, 24)
        Me.LayoutControlItem3.Text = "Building"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(734, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(517, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'lcgWaiting
        '
        Me.lcgWaiting.CaptionImage = CType(resources.GetObject("lcgWaiting.CaptionImage"), System.Drawing.Image)
        Me.lcgWaiting.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.lcgWaiting.Location = New System.Drawing.Point(0, 48)
        Me.lcgWaiting.Name = "lcgWaiting"
        Me.lcgWaiting.Size = New System.Drawing.Size(1275, 223)
        Me.lcgWaiting.Text = "Patients Waiting for Treatment"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.gcPatientsWaiting
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1251, 175)
        Me.LayoutControlItem4.Text = "Patients in Queue"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CaptionImage = CType(resources.GetObject("LayoutControlGroup4.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem16, Me.LayoutControlItem9})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 271)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(318, 276)
        Me.LayoutControlGroup4.Text = "Patient Information"
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtPatient
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 30)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 4)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(294, 28)
        Me.LayoutControlItem10.Text = "Patient Name"
        Me.LayoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(90, 20)
        Me.LayoutControlItem10.TextToControlDistance = 5
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtGender
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 58)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 4)
        Me.LayoutControlItem11.Size = New System.Drawing.Size(294, 28)
        Me.LayoutControlItem11.Text = "Gender"
        Me.LayoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(90, 20)
        Me.LayoutControlItem11.TextToControlDistance = 5
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.txtDOB
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 86)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 4)
        Me.LayoutControlItem12.Size = New System.Drawing.Size(294, 28)
        Me.LayoutControlItem12.Text = "Date of Birth"
        Me.LayoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(90, 20)
        Me.LayoutControlItem12.TextToControlDistance = 5
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.txtAge
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 114)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 4)
        Me.LayoutControlItem13.Size = New System.Drawing.Size(294, 28)
        Me.LayoutControlItem13.Text = "Age"
        Me.LayoutControlItem13.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(90, 20)
        Me.LayoutControlItem13.TextToControlDistance = 5
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.txtPatientType
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 142)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 4)
        Me.LayoutControlItem14.Size = New System.Drawing.Size(294, 28)
        Me.LayoutControlItem14.Text = "Patient Type"
        Me.LayoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(90, 20)
        Me.LayoutControlItem14.TextToControlDistance = 5
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.lueClinic
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 170)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 4)
        Me.LayoutControlItem15.Size = New System.Drawing.Size(294, 28)
        Me.LayoutControlItem15.Text = "Clinic"
        Me.LayoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(90, 20)
        Me.LayoutControlItem15.TextToControlDistance = 5
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.txtDateCheckIn
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 198)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 4)
        Me.LayoutControlItem16.Size = New System.Drawing.Size(294, 30)
        Me.LayoutControlItem16.Text = "Date Check-In"
        Me.LayoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(90, 20)
        Me.LayoutControlItem16.TextToControlDistance = 5
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtPatientCode
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 4)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(294, 30)
        Me.LayoutControlItem9.Text = "Patient Code"
        Me.LayoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(90, 20)
        Me.LayoutControlItem9.TextToControlDistance = 5
        '
        'lcgVitalSignHistory
        '
        Me.lcgVitalSignHistory.CaptionImage = CType(resources.GetObject("lcgVitalSignHistory.CaptionImage"), System.Drawing.Image)
        Me.lcgVitalSignHistory.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7})
        Me.lcgVitalSignHistory.Location = New System.Drawing.Point(318, 271)
        Me.lcgVitalSignHistory.Name = "lcgVitalSignHistory"
        Me.lcgVitalSignHistory.Size = New System.Drawing.Size(957, 276)
        Me.lcgVitalSignHistory.Text = "Vital Sign Information"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.gcVitalSign
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(933, 228)
        Me.LayoutControlItem7.Text = "Vital Sign"
        Me.LayoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.CaptionImage = CType(resources.GetObject("LayoutControlGroup6.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 547)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup6"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(318, 258)
        Me.LayoutControlGroup6.Text = "Treatment Information"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.mePatientComplaint
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(294, 97)
        Me.LayoutControlItem5.Text = "Patient Complaint"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.meProgressNote
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 97)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(294, 113)
        Me.LayoutControlItem6.Text = "Progress Note"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'lcgDiagnosis
        '
        Me.lcgDiagnosis.CaptionImage = CType(resources.GetObject("lcgDiagnosis.CaptionImage"), System.Drawing.Image)
        Me.lcgDiagnosis.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem17, Me.LayoutControlItem21, Me.LayoutControlItem22, Me.LayoutControlItem23, Me.LayoutControlItem24, Me.LayoutControlItem25, Me.LayoutControlGroup8, Me.LayoutControlItem26, Me.LayoutControlItem27, Me.LayoutControlItem29, Me.LayoutControlItem30, Me.EmptySpaceItem1, Me.LayoutControlItem20, Me.LayoutControlItem18, Me.LayoutControlItem19, Me.LayoutControlItem28})
        Me.lcgDiagnosis.Location = New System.Drawing.Point(318, 547)
        Me.lcgDiagnosis.Name = "lcgDiagnosis"
        Me.lcgDiagnosis.Size = New System.Drawing.Size(957, 258)
        Me.lcgDiagnosis.Text = "Diagnosis Information"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.gcDiagnosis
        Me.LayoutControlItem8.Image = CType(resources.GetObject("LayoutControlItem8.Image"), System.Drawing.Image)
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 54)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(933, 114)
        Me.LayoutControlItem8.Text = "Diagnosis List"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 20)
        Me.LayoutControlItem8.TextToControlDistance = 5
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.btnSave
        Me.LayoutControlItem17.Location = New System.Drawing.Point(637, 168)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(72, 42)
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem17.TextVisible = False
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.btnBMICalc
        Me.LayoutControlItem21.Location = New System.Drawing.Point(459, 168)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(117, 42)
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem21.TextVisible = False
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.btnRx
        Me.LayoutControlItem22.Location = New System.Drawing.Point(576, 168)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(61, 42)
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem22.TextVisible = False
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.btnNext
        Me.LayoutControlItem23.Location = New System.Drawing.Point(415, 168)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(44, 42)
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem23.TextVisible = False
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.btnPrev
        Me.LayoutControlItem24.Location = New System.Drawing.Point(340, 168)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(44, 42)
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem24.TextVisible = False
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.lblRec
        Me.LayoutControlItem25.Location = New System.Drawing.Point(384, 168)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 15, 2)
        Me.LayoutControlItem25.Size = New System.Drawing.Size(31, 42)
        Me.LayoutControlItem25.Text = "-/-"
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem25.TextVisible = False
        '
        'LayoutControlGroup8
        '
        Me.LayoutControlGroup8.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem2})
        Me.LayoutControlGroup8.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlGroup8.Name = "LayoutControlGroup8"
        Me.LayoutControlGroup8.Size = New System.Drawing.Size(340, 42)
        Me.LayoutControlGroup8.Text = "Blank"
        Me.LayoutControlGroup8.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(316, 18)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.lueDxGroup
        Me.LayoutControlItem26.Location = New System.Drawing.Point(99, 0)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 15, 8, 8)
        Me.LayoutControlItem26.Size = New System.Drawing.Size(180, 54)
        Me.LayoutControlItem26.Text = "Dx Category"
        Me.LayoutControlItem26.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.lueDiagnosis
        Me.LayoutControlItem27.Location = New System.Drawing.Point(279, 0)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 15, 8, 8)
        Me.LayoutControlItem27.Size = New System.Drawing.Size(186, 54)
        Me.LayoutControlItem27.Text = "Patient Diagnosis"
        Me.LayoutControlItem27.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem29
        '
        Me.LayoutControlItem29.Control = Me.txtNote
        Me.LayoutControlItem29.Location = New System.Drawing.Point(465, 0)
        Me.LayoutControlItem29.Name = "LayoutControlItem29"
        Me.LayoutControlItem29.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 15, 8, 8)
        Me.LayoutControlItem29.Size = New System.Drawing.Size(371, 54)
        Me.LayoutControlItem29.Text = "Note"
        Me.LayoutControlItem29.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem29.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem30
        '
        Me.LayoutControlItem30.Control = Me.btnChoose
        Me.LayoutControlItem30.Location = New System.Drawing.Point(836, 14)
        Me.LayoutControlItem30.Name = "LayoutControlItem30"
        Me.LayoutControlItem30.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.LayoutControlItem30.Size = New System.Drawing.Size(97, 40)
        Me.LayoutControlItem30.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem30.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(836, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(97, 14)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.btnClose
        Me.LayoutControlItem20.Location = New System.Drawing.Point(859, 168)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(74, 42)
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem20.TextVisible = False
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.btnNew
        Me.LayoutControlItem18.Location = New System.Drawing.Point(709, 168)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(69, 42)
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem18.TextVisible = False
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.btnSearch
        Me.LayoutControlItem19.Location = New System.Drawing.Point(778, 168)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(81, 42)
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem19.TextVisible = False
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.txtDxCode
        Me.LayoutControlItem28.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem28.Name = "LayoutControlItem28"
        Me.LayoutControlItem28.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 15, 8, 8)
        Me.LayoutControlItem28.Size = New System.Drawing.Size(99, 54)
        Me.LayoutControlItem28.Text = "Dx Code"
        Me.LayoutControlItem28.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(82, 13)
        '
        'ppPatientWaiting
        '
        Me.ppPatientWaiting.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPTreatment)})
        Me.ppPatientWaiting.Manager = Me.bmMenu
        Me.ppPatientWaiting.Name = "ppPatientWaiting"
        '
        'ppMenu
        '
        Me.ppMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPAddNew, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPModify, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRestore, True)})
        Me.ppMenu.Manager = Me.bmMenu
        Me.ppMenu.Name = "ppMenu"
        '
        'timPatientWaiting
        '
        Me.timPatientWaiting.Enabled = True
        Me.timPatientWaiting.Interval = 5000
        '
        'ppDiagnosis
        '
        Me.ppDiagnosis.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPAddNew, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPModify, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPRemove, True)})
        Me.ppDiagnosis.Manager = Me.bmMenu
        Me.ppDiagnosis.Name = "ppDiagnosis"
        '
        'frmPatientTreatment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1295, 825)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPatientTreatment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Patient Treatment"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtPatientCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDxCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueDxGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateCheckIn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueClinic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPatientType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDOB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGender.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPatient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcVitalSign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvVitalSign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meProgressNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mePatientComplaint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcPatientsWaiting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvPatientsWaiting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBuilding.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClinic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueDoctor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgWaiting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgVitalSignHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppPatientWaiting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents lueDoctor As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtBuilding As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtClinic As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents gcPatientsWaiting As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvPatientsWaiting As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lcgWaiting As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lcgVitalSignHistory As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lcgDiagnosis As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents meProgressNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents mePatientComplaint As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcDiagnosis As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDiagnosis As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcVitalSign As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvVitalSign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDateCheckIn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lueClinic As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtPatientType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDOB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtGender As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPatient As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnBMICalc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblRec As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnPrev As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNext As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRx As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup8 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lueDiagnosis As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lueDxGroup As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNote As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDxCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem28 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem29 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem30 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ppPatientWaiting As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiPTreatment As DevExpress.XtraBars.BarButtonItem
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
    Friend WithEvents bbiPFindCheckIn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents timPatientWaiting As Timer
    Friend WithEvents txtPatientCode As DevExpress.XtraEditors.SearchControl
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ppDiagnosis As DevExpress.XtraBars.PopupMenu
End Class
