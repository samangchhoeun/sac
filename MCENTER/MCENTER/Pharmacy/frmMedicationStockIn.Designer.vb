<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMedicationStockIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicationStockIn))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnReport = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddToList = New DevExpress.XtraEditors.SimpleButton()
        Me.txtQuantity = New DevExpress.XtraEditors.TextEdit()
        Me.txtRetailCost = New DevExpress.XtraEditors.TextEdit()
        Me.txtMakeup = New DevExpress.XtraEditors.TextEdit()
        Me.txtRealCost = New DevExpress.XtraEditors.TextEdit()
        Me.deExpiredDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtLots = New DevExpress.XtraEditors.TextEdit()
        Me.lueMadein = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtForm = New DevExpress.XtraEditors.TextEdit()
        Me.txtStrength = New DevExpress.XtraEditors.TextEdit()
        Me.lueGenericName = New DevExpress.XtraEditors.LookUpEdit()
        Me.lueBrandName = New DevExpress.XtraEditors.LookUpEdit()
        Me.meAddress = New DevExpress.XtraEditors.MemoEdit()
        Me.txtContactNumber = New DevExpress.XtraEditors.TextEdit()
        Me.txtContactPerson = New DevExpress.XtraEditors.TextEdit()
        Me.btnBrowseSuppliers = New DevExpress.XtraEditors.SimpleButton()
        Me.lueSupplierName = New DevExpress.XtraEditors.LookUpEdit()
        Me.meRermark = New DevExpress.XtraEditors.MemoEdit()
        Me.deDateReceived = New DevExpress.XtraEditors.DateEdit()
        Me.txtRefInvoiceNo = New DevExpress.XtraEditors.TextEdit()
        Me.txtInvoiceNo = New DevExpress.XtraEditors.TextEdit()
        Me.gcMedication = New DevExpress.XtraGrid.GridControl()
        Me.gvMedication = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lueWarehouse = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtReceivedBy = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.bmMed = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiPAddHoilday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPEditHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPRemoveHoliday = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPModify = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPServiceFee = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPVoidInvoice = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiPDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.ppMed = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRetailCost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMakeup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRealCost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deExpiredDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deExpiredDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLots.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueMadein.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtForm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStrength.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueGenericName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueBrandName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContactNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContactPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueSupplierName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meRermark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateReceived.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateReceived.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRefInvoiceNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInvoiceNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcMedication, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvMedication, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueWarehouse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReceivedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmMed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppMed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnReport)
        Me.LayoutControl1.Controls.Add(Me.btnSave)
        Me.LayoutControl1.Controls.Add(Me.btnNew)
        Me.LayoutControl1.Controls.Add(Me.btnSearch)
        Me.LayoutControl1.Controls.Add(Me.btnClose)
        Me.LayoutControl1.Controls.Add(Me.btnAddToList)
        Me.LayoutControl1.Controls.Add(Me.txtQuantity)
        Me.LayoutControl1.Controls.Add(Me.txtRetailCost)
        Me.LayoutControl1.Controls.Add(Me.txtMakeup)
        Me.LayoutControl1.Controls.Add(Me.txtRealCost)
        Me.LayoutControl1.Controls.Add(Me.deExpiredDate)
        Me.LayoutControl1.Controls.Add(Me.txtLots)
        Me.LayoutControl1.Controls.Add(Me.lueMadein)
        Me.LayoutControl1.Controls.Add(Me.txtForm)
        Me.LayoutControl1.Controls.Add(Me.txtStrength)
        Me.LayoutControl1.Controls.Add(Me.lueGenericName)
        Me.LayoutControl1.Controls.Add(Me.lueBrandName)
        Me.LayoutControl1.Controls.Add(Me.meAddress)
        Me.LayoutControl1.Controls.Add(Me.txtContactNumber)
        Me.LayoutControl1.Controls.Add(Me.txtContactPerson)
        Me.LayoutControl1.Controls.Add(Me.btnBrowseSuppliers)
        Me.LayoutControl1.Controls.Add(Me.lueSupplierName)
        Me.LayoutControl1.Controls.Add(Me.meRermark)
        Me.LayoutControl1.Controls.Add(Me.deDateReceived)
        Me.LayoutControl1.Controls.Add(Me.txtRefInvoiceNo)
        Me.LayoutControl1.Controls.Add(Me.txtInvoiceNo)
        Me.LayoutControl1.Controls.Add(Me.gcMedication)
        Me.LayoutControl1.Controls.Add(Me.lueWarehouse)
        Me.LayoutControl1.Controls.Add(Me.txtReceivedBy)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(869, 354, 312, 437)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1321, 671)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnReport
        '
        Me.btnReport.Image = CType(resources.GetObject("btnReport.Image"), System.Drawing.Image)
        Me.btnReport.Location = New System.Drawing.Point(903, 621)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(89, 38)
        Me.btnReport.StyleController = Me.LayoutControl1
        Me.btnReport.TabIndex = 32
        Me.btnReport.Text = "Report"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(996, 621)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(73, 38)
        Me.btnSave.StyleController = Me.LayoutControl1
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "Save"
        '
        'btnNew
        '
        Me.btnNew.Enabled = False
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Location = New System.Drawing.Point(1073, 621)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(78, 38)
        Me.btnNew.StyleController = Me.LayoutControl1
        Me.btnNew.TabIndex = 30
        Me.btnNew.Text = "New"
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(1155, 621)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 38)
        Me.btnSearch.StyleController = Me.LayoutControl1
        Me.btnSearch.TabIndex = 29
        Me.btnSearch.Text = "Search"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1236, 621)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(73, 38)
        Me.btnClose.StyleController = Me.LayoutControl1
        Me.btnClose.TabIndex = 28
        Me.btnClose.Text = " Close"
        '
        'btnAddToList
        '
        Me.btnAddToList.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToList.Appearance.Options.UseFont = True
        Me.btnAddToList.Image = CType(resources.GetObject("btnAddToList.Image"), System.Drawing.Image)
        Me.btnAddToList.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAddToList.Location = New System.Drawing.Point(1218, 246)
        Me.btnAddToList.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAddToList.Name = "btnAddToList"
        Me.btnAddToList.Size = New System.Drawing.Size(79, 56)
        Me.btnAddToList.StyleController = Me.LayoutControl1
        Me.btnAddToList.TabIndex = 27
        Me.btnAddToList.Text = "Add to List"
        '
        'txtQuantity
        '
        Me.txtQuantity.EditValue = ""
        Me.txtQuantity.Location = New System.Drawing.Point(628, 278)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Properties.Appearance.Options.UseFont = True
        Me.txtQuantity.Properties.Appearance.Options.UseTextOptions = True
        Me.txtQuantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtQuantity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtQuantity.Properties.DisplayFormat.FormatString = "0"
        Me.txtQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtQuantity.Properties.EditFormat.FormatString = "0"
        Me.txtQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtQuantity.Properties.NullText = "0"
        Me.txtQuantity.Size = New System.Drawing.Size(167, 20)
        Me.txtQuantity.StyleController = Me.LayoutControl1
        Me.txtQuantity.TabIndex = 26
        '
        'txtRetailCost
        '
        Me.txtRetailCost.EditValue = ""
        Me.txtRetailCost.Location = New System.Drawing.Point(1060, 278)
        Me.txtRetailCost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtRetailCost.Name = "txtRetailCost"
        Me.txtRetailCost.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetailCost.Properties.Appearance.Options.UseFont = True
        Me.txtRetailCost.Properties.Appearance.Options.UseTextOptions = True
        Me.txtRetailCost.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtRetailCost.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtRetailCost.Properties.NullText = "0"
        Me.txtRetailCost.Size = New System.Drawing.Size(146, 20)
        Me.txtRetailCost.StyleController = Me.LayoutControl1
        Me.txtRetailCost.TabIndex = 25
        '
        'txtMakeup
        '
        Me.txtMakeup.EditValue = ""
        Me.txtMakeup.Location = New System.Drawing.Point(957, 278)
        Me.txtMakeup.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMakeup.Name = "txtMakeup"
        Me.txtMakeup.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMakeup.Properties.Appearance.Options.UseFont = True
        Me.txtMakeup.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMakeup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtMakeup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtMakeup.Properties.NullText = "0"
        Me.txtMakeup.Size = New System.Drawing.Size(90, 20)
        Me.txtMakeup.StyleController = Me.LayoutControl1
        Me.txtMakeup.TabIndex = 24
        '
        'txtRealCost
        '
        Me.txtRealCost.EditValue = ""
        Me.txtRealCost.Location = New System.Drawing.Point(808, 278)
        Me.txtRealCost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtRealCost.Name = "txtRealCost"
        Me.txtRealCost.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRealCost.Properties.Appearance.Options.UseFont = True
        Me.txtRealCost.Properties.Appearance.Options.UseTextOptions = True
        Me.txtRealCost.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtRealCost.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtRealCost.Properties.NullText = "0"
        Me.txtRealCost.Size = New System.Drawing.Size(136, 20)
        Me.txtRealCost.StyleController = Me.LayoutControl1
        Me.txtRealCost.TabIndex = 23
        '
        'deExpiredDate
        '
        Me.deExpiredDate.EditValue = Nothing
        Me.deExpiredDate.Location = New System.Drawing.Point(1060, 232)
        Me.deExpiredDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deExpiredDate.Name = "deExpiredDate"
        Me.deExpiredDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deExpiredDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deExpiredDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deExpiredDate.Properties.DisplayFormat.FormatString = "MMM dd, yyyy"
        Me.deExpiredDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deExpiredDate.Size = New System.Drawing.Size(146, 20)
        Me.deExpiredDate.StyleController = Me.LayoutControl1
        Me.deExpiredDate.TabIndex = 22
        '
        'txtLots
        '
        Me.txtLots.Location = New System.Drawing.Point(957, 232)
        Me.txtLots.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLots.Name = "txtLots"
        Me.txtLots.Properties.Appearance.Options.UseTextOptions = True
        Me.txtLots.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtLots.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtLots.Size = New System.Drawing.Size(90, 20)
        Me.txtLots.StyleController = Me.LayoutControl1
        Me.txtLots.TabIndex = 21
        '
        'lueMadein
        '
        Me.lueMadein.Location = New System.Drawing.Point(808, 232)
        Me.lueMadein.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lueMadein.Name = "lueMadein"
        Me.lueMadein.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueMadein.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueMadein.Properties.NullText = ""
        Me.lueMadein.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueMadein.Size = New System.Drawing.Size(136, 20)
        Me.lueMadein.StyleController = Me.LayoutControl1
        Me.lueMadein.TabIndex = 20
        '
        'txtForm
        '
        Me.txtForm.Location = New System.Drawing.Point(416, 278)
        Me.txtForm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtForm.Name = "txtForm"
        Me.txtForm.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan
        Me.txtForm.Properties.Appearance.Options.UseBackColor = True
        Me.txtForm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtForm.Size = New System.Drawing.Size(199, 20)
        Me.txtForm.StyleController = Me.LayoutControl1
        Me.txtForm.TabIndex = 19
        '
        'txtStrength
        '
        Me.txtStrength.Location = New System.Drawing.Point(25, 278)
        Me.txtStrength.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtStrength.Name = "txtStrength"
        Me.txtStrength.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan
        Me.txtStrength.Properties.Appearance.Options.UseBackColor = True
        Me.txtStrength.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtStrength.Size = New System.Drawing.Size(378, 20)
        Me.txtStrength.StyleController = Me.LayoutControl1
        Me.txtStrength.TabIndex = 18
        '
        'lueGenericName
        '
        Me.lueGenericName.Location = New System.Drawing.Point(416, 232)
        Me.lueGenericName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lueGenericName.Name = "lueGenericName"
        Me.lueGenericName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueGenericName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueGenericName.Properties.NullText = ""
        Me.lueGenericName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueGenericName.Size = New System.Drawing.Size(379, 20)
        Me.lueGenericName.StyleController = Me.LayoutControl1
        Me.lueGenericName.TabIndex = 17
        '
        'lueBrandName
        '
        Me.lueBrandName.Location = New System.Drawing.Point(25, 232)
        Me.lueBrandName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lueBrandName.Name = "lueBrandName"
        Me.lueBrandName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueBrandName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueBrandName.Properties.NullText = ""
        Me.lueBrandName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueBrandName.Size = New System.Drawing.Size(378, 20)
        Me.lueBrandName.StyleController = Me.LayoutControl1
        Me.lueBrandName.TabIndex = 16
        '
        'meAddress
        '
        Me.meAddress.Location = New System.Drawing.Point(111, 108)
        Me.meAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.meAddress.Name = "meAddress"
        Me.meAddress.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.meAddress.Properties.Appearance.Options.UseBackColor = True
        Me.meAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meAddress.Size = New System.Drawing.Size(516, 29)
        Me.meAddress.StyleController = Me.LayoutControl1
        Me.meAddress.TabIndex = 15
        '
        'txtContactNumber
        '
        Me.txtContactNumber.Location = New System.Drawing.Point(437, 146)
        Me.txtContactNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtContactNumber.Properties.Appearance.Options.UseBackColor = True
        Me.txtContactNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtContactNumber.Size = New System.Drawing.Size(190, 20)
        Me.txtContactNumber.StyleController = Me.LayoutControl1
        Me.txtContactNumber.TabIndex = 14
        '
        'txtContactPerson
        '
        Me.txtContactPerson.Location = New System.Drawing.Point(111, 146)
        Me.txtContactPerson.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtContactPerson.Properties.Appearance.Options.UseBackColor = True
        Me.txtContactPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtContactPerson.Size = New System.Drawing.Size(243, 20)
        Me.txtContactPerson.StyleController = Me.LayoutControl1
        Me.txtContactPerson.TabIndex = 13
        '
        'btnBrowseSuppliers
        '
        Me.btnBrowseSuppliers.Image = CType(resources.GetObject("btnBrowseSuppliers.Image"), System.Drawing.Image)
        Me.btnBrowseSuppliers.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnBrowseSuppliers.Location = New System.Drawing.Point(602, 78)
        Me.btnBrowseSuppliers.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBrowseSuppliers.Name = "btnBrowseSuppliers"
        Me.btnBrowseSuppliers.Size = New System.Drawing.Size(25, 22)
        Me.btnBrowseSuppliers.StyleController = Me.LayoutControl1
        Me.btnBrowseSuppliers.TabIndex = 12
        '
        'lueSupplierName
        '
        Me.lueSupplierName.Location = New System.Drawing.Point(110, 79)
        Me.lueSupplierName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lueSupplierName.Name = "lueSupplierName"
        Me.lueSupplierName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueSupplierName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueSupplierName.Properties.NullText = ""
        Me.lueSupplierName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueSupplierName.Size = New System.Drawing.Size(488, 20)
        Me.lueSupplierName.StyleController = Me.LayoutControl1
        Me.lueSupplierName.TabIndex = 11
        '
        'meRermark
        '
        Me.meRermark.Location = New System.Drawing.Point(730, 110)
        Me.meRermark.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.meRermark.Name = "meRermark"
        Me.meRermark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meRermark.Size = New System.Drawing.Size(565, 56)
        Me.meRermark.StyleController = Me.LayoutControl1
        Me.meRermark.TabIndex = 10
        '
        'deDateReceived
        '
        Me.deDateReceived.EditValue = Nothing
        Me.deDateReceived.Location = New System.Drawing.Point(730, 81)
        Me.deDateReceived.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deDateReceived.Name = "deDateReceived"
        Me.deDateReceived.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deDateReceived.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateReceived.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateReceived.Properties.DisplayFormat.FormatString = "MMM dd, yyyy"
        Me.deDateReceived.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deDateReceived.Size = New System.Drawing.Size(233, 20)
        Me.deDateReceived.StyleController = Me.LayoutControl1
        Me.deDateReceived.TabIndex = 8
        '
        'txtRefInvoiceNo
        '
        Me.txtRefInvoiceNo.Location = New System.Drawing.Point(1066, 52)
        Me.txtRefInvoiceNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtRefInvoiceNo.Name = "txtRefInvoiceNo"
        Me.txtRefInvoiceNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtRefInvoiceNo.Size = New System.Drawing.Size(229, 20)
        Me.txtRefInvoiceNo.StyleController = Me.LayoutControl1
        Me.txtRefInvoiceNo.TabIndex = 7
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.EditValue = "***"
        Me.txtInvoiceNo.Location = New System.Drawing.Point(730, 52)
        Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtInvoiceNo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.txtInvoiceNo.Properties.Appearance.Options.UseBackColor = True
        Me.txtInvoiceNo.Properties.Appearance.Options.UseFont = True
        Me.txtInvoiceNo.Properties.Appearance.Options.UseForeColor = True
        Me.txtInvoiceNo.Properties.Appearance.Options.UseTextOptions = True
        Me.txtInvoiceNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtInvoiceNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtInvoiceNo.Properties.ReadOnly = True
        Me.txtInvoiceNo.Size = New System.Drawing.Size(233, 20)
        Me.txtInvoiceNo.StyleController = Me.LayoutControl1
        Me.txtInvoiceNo.TabIndex = 6
        '
        'gcMedication
        '
        Me.gcMedication.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gcMedication.Location = New System.Drawing.Point(15, 345)
        Me.gcMedication.MainView = Me.gvMedication
        Me.gcMedication.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gcMedication.Name = "gcMedication"
        Me.gcMedication.Size = New System.Drawing.Size(1291, 269)
        Me.gcMedication.TabIndex = 5
        Me.gcMedication.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvMedication})
        '
        'gvMedication
        '
        Me.gvMedication.GridControl = Me.gcMedication
        Me.gvMedication.Name = "gvMedication"
        Me.gvMedication.OptionsBehavior.Editable = False
        Me.gvMedication.OptionsBehavior.ReadOnly = True
        Me.gvMedication.OptionsView.ShowFooter = True
        Me.gvMedication.OptionsView.ShowGroupPanel = False
        '
        'lueWarehouse
        '
        Me.lueWarehouse.Location = New System.Drawing.Point(111, 52)
        Me.lueWarehouse.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lueWarehouse.Name = "lueWarehouse"
        Me.lueWarehouse.Properties.Appearance.ForeColor = System.Drawing.Color.DarkGreen
        Me.lueWarehouse.Properties.Appearance.Options.UseForeColor = True
        Me.lueWarehouse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueWarehouse.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueWarehouse.Properties.NullText = ""
        Me.lueWarehouse.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueWarehouse.Size = New System.Drawing.Size(516, 20)
        Me.lueWarehouse.StyleController = Me.LayoutControl1
        Me.lueWarehouse.TabIndex = 4
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.Location = New System.Drawing.Point(1066, 81)
        Me.txtReceivedBy.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtReceivedBy.Properties.DisplayFormat.FormatString = "d"
        Me.txtReceivedBy.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtReceivedBy.Properties.EditFormat.FormatString = "d"
        Me.txtReceivedBy.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtReceivedBy.Size = New System.Drawing.Size(229, 20)
        Me.txtReceivedBy.StyleController = Me.LayoutControl1
        Me.txtReceivedBy.TabIndex = 9
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3, Me.LayoutControlGroup4, Me.LayoutControlGroup6, Me.LayoutControlGroup5, Me.LayoutControlItem25, Me.LayoutControlItem26, Me.LayoutControlItem27, Me.LayoutControlItem28, Me.LayoutControlItem29})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.OptionsItemText.TextToControlDistance = 4
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1321, 671)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem6})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 609)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.OptionsItemText.TextToControlDistance = 4
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(891, 42)
        Me.LayoutControlGroup3.Text = "Menu"
        Me.LayoutControlGroup3.TextVisible = False
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(867, 18)
        Me.EmptySpaceItem6.Text = "Menu"
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CaptionImage = CType(resources.GetObject("LayoutControlGroup4.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 306)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.OptionsItemText.TextToControlDistance = 4
        Me.LayoutControlGroup4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1301, 303)
        Me.LayoutControlGroup4.Text = "Medication List"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.gcMedication
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1295, 273)
        Me.LayoutControlItem2.Text = "Medication"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.CaptionImage = CType(resources.GetObject("LayoutControlGroup6.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9, Me.LayoutControlItem8, Me.LayoutControlItem10, Me.LayoutControlItem12, Me.LayoutControlItem11, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup6"
        Me.LayoutControlGroup6.OptionsItemText.TextToControlDistance = 4
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(1301, 173)
        Me.LayoutControlGroup6.Spacing = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3)
        Me.LayoutControlGroup6.Text = "Stock Info"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.btnBrowseSuppliers
        Me.LayoutControlItem9.Location = New System.Drawing.Point(577, 29)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 15, 2, 2)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(42, 27)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.lueSupplierName
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 29)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 4)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(577, 27)
        Me.LayoutControlItem8.Text = "Supplier Name"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(80, 13)
        Me.LayoutControlItem8.TextToControlDistance = 5
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtContactPerson
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(341, 29)
        Me.LayoutControlItem10.Text = "Contact Person"
        Me.LayoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(80, 13)
        Me.LayoutControlItem10.TextToControlDistance = 5
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.meAddress
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 56)
        Me.LayoutControlItem12.MaxSize = New System.Drawing.Size(0, 38)
        Me.LayoutControlItem12.MinSize = New System.Drawing.Size(95, 38)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 15, 5, 4)
        Me.LayoutControlItem12.Size = New System.Drawing.Size(619, 38)
        Me.LayoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem12.Text = "Address"
        Me.LayoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(80, 13)
        Me.LayoutControlItem12.TextToControlDistance = 5
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtContactNumber
        Me.LayoutControlItem11.Location = New System.Drawing.Point(341, 94)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 15, 5, 4)
        Me.LayoutControlItem11.Size = New System.Drawing.Size(278, 29)
        Me.LayoutControlItem11.Text = "Telephone"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.lueWarehouse
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 15, 5, 4)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(619, 29)
        Me.LayoutControlItem1.Text = "Warehouse"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(80, 13)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtInvoiceNo
        Me.LayoutControlItem3.Location = New System.Drawing.Point(619, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(331, 29)
        Me.LayoutControlItem3.Text = "Invoice No"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(80, 13)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtRefInvoiceNo
        Me.LayoutControlItem4.Location = New System.Drawing.Point(950, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 5, 4)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(325, 29)
        Me.LayoutControlItem4.Text = "Ref. Invoice No"
        Me.LayoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(85, 13)
        Me.LayoutControlItem4.TextToControlDistance = 5
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.deDateReceived
        Me.LayoutControlItem5.Location = New System.Drawing.Point(619, 29)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(331, 29)
        Me.LayoutControlItem5.Text = "Date Received"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(80, 13)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtReceivedBy
        Me.LayoutControlItem6.Location = New System.Drawing.Point(950, 29)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 5, 4)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(325, 29)
        Me.LayoutControlItem6.Text = "Received By"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(85, 13)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.meRermark
        Me.LayoutControlItem7.Location = New System.Drawing.Point(619, 58)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(0, 65)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(95, 65)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 5, 4)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(656, 65)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "Remark"
        Me.LayoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(80, 13)
        Me.LayoutControlItem7.TextToControlDistance = 5
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.CaptionImage = CType(resources.GetObject("LayoutControlGroup5.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem13, Me.LayoutControlItem15, Me.LayoutControlItem16, Me.LayoutControlItem23, Me.LayoutControlItem14, Me.LayoutControlItem17, Me.LayoutControlItem18, Me.LayoutControlItem19, Me.LayoutControlItem20, Me.LayoutControlItem21, Me.LayoutControlItem22, Me.LayoutControlItem24, Me.LayoutControlGroup2})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 173)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup5"
        Me.LayoutControlGroup5.OptionsItemText.TextToControlDistance = 4
        Me.LayoutControlGroup5.Padding = New DevExpress.XtraLayout.Utils.Padding(9, 9, 0, 9)
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1301, 133)
        Me.LayoutControlGroup5.Text = "Medication Info"
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.lueBrandName
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem13.Size = New System.Drawing.Size(391, 46)
        Me.LayoutControlItem13.Text = "Brand Name"
        Me.LayoutControlItem13.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.txtStrength
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 46)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem15.Size = New System.Drawing.Size(391, 48)
        Me.LayoutControlItem15.Text = "Strength"
        Me.LayoutControlItem15.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.txtForm
        Me.LayoutControlItem16.Location = New System.Drawing.Point(391, 46)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem16.Size = New System.Drawing.Size(212, 48)
        Me.LayoutControlItem16.Text = "Form"
        Me.LayoutControlItem16.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.txtQuantity
        Me.LayoutControlItem23.Location = New System.Drawing.Point(603, 46)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem23.Size = New System.Drawing.Size(180, 48)
        Me.LayoutControlItem23.Text = "Quantity"
        Me.LayoutControlItem23.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.lueGenericName
        Me.LayoutControlItem14.Location = New System.Drawing.Point(391, 0)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem14.Size = New System.Drawing.Size(392, 46)
        Me.LayoutControlItem14.Text = "Generic Name"
        Me.LayoutControlItem14.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.lueMadein
        Me.LayoutControlItem17.Location = New System.Drawing.Point(783, 0)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem17.Size = New System.Drawing.Size(149, 46)
        Me.LayoutControlItem17.Text = "Made in"
        Me.LayoutControlItem17.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.txtLots
        Me.LayoutControlItem18.Location = New System.Drawing.Point(932, 0)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem18.Size = New System.Drawing.Size(103, 46)
        Me.LayoutControlItem18.Text = "Lots Number"
        Me.LayoutControlItem18.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.deExpiredDate
        Me.LayoutControlItem19.Location = New System.Drawing.Point(1035, 0)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem19.Size = New System.Drawing.Size(159, 46)
        Me.LayoutControlItem19.Text = "Expired Date"
        Me.LayoutControlItem19.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.txtRealCost
        Me.LayoutControlItem20.Location = New System.Drawing.Point(783, 46)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem20.Size = New System.Drawing.Size(149, 48)
        Me.LayoutControlItem20.Text = "Real Cost"
        Me.LayoutControlItem20.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.txtMakeup
        Me.LayoutControlItem21.Location = New System.Drawing.Point(932, 46)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem21.Size = New System.Drawing.Size(103, 48)
        Me.LayoutControlItem21.Text = "Makeup (%)"
        Me.LayoutControlItem21.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.txtRetailCost
        Me.LayoutControlItem22.Location = New System.Drawing.Point(1035, 46)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 10, 5, 4)
        Me.LayoutControlItem22.Size = New System.Drawing.Size(159, 48)
        Me.LayoutControlItem22.Text = "Retail Cost"
        Me.LayoutControlItem22.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.btnAddToList
        Me.LayoutControlItem24.Location = New System.Drawing.Point(1194, 34)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(83, 60)
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem24.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(59, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.btnClose
        Me.LayoutControlItem25.Location = New System.Drawing.Point(1224, 609)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(77, 42)
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem25.TextVisible = False
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.btnSearch
        Me.LayoutControlItem26.Location = New System.Drawing.Point(1143, 609)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(81, 42)
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem26.TextVisible = False
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.btnNew
        Me.LayoutControlItem27.Location = New System.Drawing.Point(1061, 609)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(82, 42)
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem27.TextVisible = False
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.btnSave
        Me.LayoutControlItem28.Location = New System.Drawing.Point(984, 609)
        Me.LayoutControlItem28.Name = "LayoutControlItem28"
        Me.LayoutControlItem28.Size = New System.Drawing.Size(77, 42)
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem28.TextVisible = False
        '
        'LayoutControlItem29
        '
        Me.LayoutControlItem29.Control = Me.btnReport
        Me.LayoutControlItem29.Location = New System.Drawing.Point(891, 609)
        Me.LayoutControlItem29.Name = "LayoutControlItem29"
        Me.LayoutControlItem29.Size = New System.Drawing.Size(93, 42)
        Me.LayoutControlItem29.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem29.TextVisible = False
        '
        'bmMed
        '
        Me.bmMed.DockControls.Add(Me.barDockControlTop)
        Me.bmMed.DockControls.Add(Me.barDockControlBottom)
        Me.bmMed.DockControls.Add(Me.barDockControlLeft)
        Me.bmMed.DockControls.Add(Me.barDockControlRight)
        Me.bmMed.Form = Me
        Me.bmMed.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiPAddHoilday, Me.bbiPEditHoliday, Me.bbiPRemoveHoliday, Me.bbiPModify, Me.bbiPServiceFee, Me.bbiPVoidInvoice, Me.bbiPDelete})
        Me.bmMed.MaxItemId = 7
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1321, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 671)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1321, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 671)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1321, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 671)
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
        'bbiPModify
        '
        Me.bbiPModify.Caption = "Modify Medication"
        Me.bbiPModify.Id = 3
        Me.bbiPModify.ImageUri.Uri = "InLineWithText"
        Me.bbiPModify.Name = "bbiPModify"
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
        'bbiPDelete
        '
        Me.bbiPDelete.Caption = "Delete Medication"
        Me.bbiPDelete.Id = 6
        Me.bbiPDelete.ImageUri.Uri = "Delete"
        Me.bbiPDelete.Name = "bbiPDelete"
        '
        'ppMed
        '
        Me.ppMed.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPModify), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiPDelete, True)})
        Me.ppMed.Manager = Me.bmMed
        Me.ppMed.Name = "ppMed"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(1194, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(83, 34)
        Me.LayoutControlGroup2.Text = "Add"
        Me.LayoutControlGroup2.TextVisible = False
        '
        'frmMedicationStockIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 671)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmMedicationStockIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Medication Stock In"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRetailCost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMakeup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRealCost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deExpiredDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deExpiredDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLots.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueMadein.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtForm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStrength.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueGenericName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueBrandName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContactNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContactPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueSupplierName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meRermark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateReceived.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateReceived.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRefInvoiceNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInvoiceNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcMedication, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvMedication, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueWarehouse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReceivedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmMed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppMed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lueWarehouse As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents gcMedication As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvMedication As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lueSupplierName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents meRermark As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents deDateReceived As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtRefInvoiceNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtInvoiceNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnBrowseSuppliers As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtReceivedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents meAddress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtContactNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtContactPerson As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lueBrandName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRealCost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents deExpiredDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtLots As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lueMadein As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtForm As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtStrength As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lueGenericName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtMakeup As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtQuantity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRetailCost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnAddToList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnReport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem28 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem29 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents bmMed As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiPAddHoilday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPEditHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPRemoveHoliday As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPModify As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPServiceFee As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPVoidInvoice As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiPDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ppMed As DevExpress.XtraBars.PopupMenu
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
End Class
