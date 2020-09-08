<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportWorkingHoursSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportWorkingHoursSearch))
        Me.chkAllDates = New System.Windows.Forms.CheckBox()
        Me.lueDepartment = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.lueCampus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.deDateTo = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.deDateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSID = New DevExpress.XtraEditors.SearchControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.lueDivision = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lueCondition = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.lueDepartment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCampus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueDivision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCondition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkAllDates
        '
        Me.chkAllDates.AutoSize = True
        Me.chkAllDates.Checked = True
        Me.chkAllDates.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAllDates.Location = New System.Drawing.Point(286, 75)
        Me.chkAllDates.Name = "chkAllDates"
        Me.chkAllDates.Size = New System.Drawing.Size(15, 14)
        Me.chkAllDates.TabIndex = 499
        Me.chkAllDates.UseVisualStyleBackColor = True
        '
        'lueDepartment
        '
        Me.lueDepartment.Location = New System.Drawing.Point(305, 41)
        Me.lueDepartment.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lueDepartment.Name = "lueDepartment"
        Me.lueDepartment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDepartment.Properties.NullText = ""
        Me.lueDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueDepartment.Size = New System.Drawing.Size(200, 20)
        Me.lueDepartment.TabIndex = 497
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(212, 45)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl2.TabIndex = 498
        Me.LabelControl2.Text = "Department"
        '
        'btnClear
        '
        Me.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(363, 103)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(68, 26)
        Me.btnClear.TabIndex = 491
        Me.btnClear.Text = "Clear"
        '
        'lueCampus
        '
        Me.lueCampus.Location = New System.Drawing.Point(78, 41)
        Me.lueCampus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lueCampus.Name = "lueCampus"
        Me.lueCampus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueCampus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueCampus.Properties.NullText = ""
        Me.lueCampus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueCampus.Size = New System.Drawing.Size(118, 20)
        Me.lueCampus.TabIndex = 487
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(10, 45)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl7.TabIndex = 496
        Me.LabelControl7.Text = "Campus"
        '
        'deDateTo
        '
        Me.deDateTo.EditValue = Nothing
        Me.deDateTo.Enabled = False
        Me.deDateTo.Location = New System.Drawing.Point(417, 72)
        Me.deDateTo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deDateTo.Name = "deDateTo"
        Me.deDateTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deDateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateTo.Size = New System.Drawing.Size(88, 20)
        Me.deDateTo.TabIndex = 489
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(399, 76)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl6.TabIndex = 495
        Me.LabelControl6.Text = "To"
        '
        'deDateFrom
        '
        Me.deDateFrom.EditValue = Nothing
        Me.deDateFrom.Enabled = False
        Me.deDateFrom.Location = New System.Drawing.Point(305, 72)
        Me.deDateFrom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deDateFrom.Name = "deDateFrom"
        Me.deDateFrom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deDateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateFrom.Size = New System.Drawing.Size(88, 20)
        Me.deDateFrom.TabIndex = 488
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(212, 76)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl5.TabIndex = 494
        Me.LabelControl5.Text = "Effective Date"
        '
        'txtSID
        '
        Me.txtSID.Location = New System.Drawing.Point(78, 10)
        Me.txtSID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSID.Name = "txtSID"
        Me.txtSID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.txtSID.Properties.NullValuePrompt = "Enter Employee ID"
        Me.txtSID.Size = New System.Drawing.Size(118, 20)
        Me.txtSID.TabIndex = 486
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 14)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl1.TabIndex = 493
        Me.LabelControl1.Text = "Employee ID"
        '
        'btnClose
        '
        Me.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(10, 103)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 26)
        Me.btnClose.TabIndex = 490
        Me.btnClose.Text = "Close"
        '
        'btnSearch
        '
        Me.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(437, 103)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(68, 26)
        Me.btnSearch.TabIndex = 492
        Me.btnSearch.Text = "Search "
        '
        'lueDivision
        '
        Me.lueDivision.EditValue = ""
        Me.lueDivision.Location = New System.Drawing.Point(305, 11)
        Me.lueDivision.Name = "lueDivision"
        Me.lueDivision.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueDivision.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDivision.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.lueDivision.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueDivision.Size = New System.Drawing.Size(200, 20)
        Me.lueDivision.TabIndex = 500
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(212, 13)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl3.TabIndex = 501
        Me.LabelControl3.Text = "Division"
        '
        'lueCondition
        '
        Me.lueCondition.Location = New System.Drawing.Point(78, 72)
        Me.lueCondition.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lueCondition.Name = "lueCondition"
        Me.lueCondition.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueCondition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueCondition.Properties.NullText = ""
        Me.lueCondition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueCondition.Size = New System.Drawing.Size(118, 20)
        Me.lueCondition.TabIndex = 502
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(10, 76)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl4.TabIndex = 503
        Me.LabelControl4.Text = "Condition"
        '
        'btnExport
        '
        Me.btnExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.Location = New System.Drawing.Point(270, 103)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(87, 26)
        Me.btnExport.TabIndex = 529
        Me.btnExport.Text = "Export..."
        '
        'frmReportWorkingHoursSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 139)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.lueCondition)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.lueDivision)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.chkAllDates)
        Me.Controls.Add(Me.lueDepartment)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.lueCampus)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.deDateTo)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.deDateFrom)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.txtSID)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportWorkingHoursSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search Options"
        CType(Me.lueDepartment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCampus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueDivision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCondition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkAllDates As CheckBox
    Friend WithEvents lueDepartment As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lueCampus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents deDateTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents deDateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSID As DevExpress.XtraEditors.SearchControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Private WithEvents lueDivision As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lueCondition As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
End Class
