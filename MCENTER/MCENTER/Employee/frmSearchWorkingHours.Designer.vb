<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchWorkingHours
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchWorkingHours))
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
        Me.chkAllDates.Location = New System.Drawing.Point(576, 156)
        Me.chkAllDates.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.chkAllDates.Name = "chkAllDates"
        Me.chkAllDates.Size = New System.Drawing.Size(28, 27)
        Me.chkAllDates.TabIndex = 499
        Me.chkAllDates.UseVisualStyleBackColor = True
        '
        'lueDepartment
        '
        Me.lueDepartment.Location = New System.Drawing.Point(614, 90)
        Me.lueDepartment.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.lueDepartment.Name = "lueDepartment"
        Me.lueDepartment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDepartment.Properties.NullText = ""
        Me.lueDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueDepartment.Size = New System.Drawing.Size(400, 34)
        Me.lueDepartment.TabIndex = 497
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(428, 98)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(111, 25)
        Me.LabelControl2.TabIndex = 498
        Me.LabelControl2.Text = "Department"
        '
        'btnClear
        '
        Me.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(730, 210)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(136, 50)
        Me.btnClear.TabIndex = 491
        Me.btnClear.Text = "Clear"
        '
        'lueCampus
        '
        Me.lueCampus.Location = New System.Drawing.Point(160, 90)
        Me.lueCampus.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.lueCampus.Name = "lueCampus"
        Me.lueCampus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueCampus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueCampus.Properties.NullText = ""
        Me.lueCampus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueCampus.Size = New System.Drawing.Size(236, 34)
        Me.lueCampus.TabIndex = 487
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(24, 98)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(75, 25)
        Me.LabelControl7.TabIndex = 496
        Me.LabelControl7.Text = "Campus"
        '
        'deDateTo
        '
        Me.deDateTo.EditValue = Nothing
        Me.deDateTo.Enabled = False
        Me.deDateTo.Location = New System.Drawing.Point(838, 150)
        Me.deDateTo.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.deDateTo.Name = "deDateTo"
        Me.deDateTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deDateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateTo.Size = New System.Drawing.Size(176, 34)
        Me.deDateTo.TabIndex = 489
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(802, 158)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 25)
        Me.LabelControl6.TabIndex = 495
        Me.LabelControl6.Text = "To"
        '
        'deDateFrom
        '
        Me.deDateFrom.EditValue = Nothing
        Me.deDateFrom.Enabled = False
        Me.deDateFrom.Location = New System.Drawing.Point(614, 150)
        Me.deDateFrom.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.deDateFrom.Name = "deDateFrom"
        Me.deDateFrom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deDateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateFrom.Size = New System.Drawing.Size(176, 34)
        Me.deDateFrom.TabIndex = 488
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(428, 158)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(130, 25)
        Me.LabelControl5.TabIndex = 494
        Me.LabelControl5.Text = "Effective Date"
        '
        'txtSID
        '
        Me.txtSID.Location = New System.Drawing.Point(160, 31)
        Me.txtSID.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.txtSID.Name = "txtSID"
        Me.txtSID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.txtSID.Properties.NullValuePrompt = "Enter Employee ID"
        Me.txtSID.Size = New System.Drawing.Size(236, 34)
        Me.txtSID.TabIndex = 486
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(24, 38)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(119, 25)
        Me.LabelControl1.TabIndex = 493
        Me.LabelControl1.Text = "Employee ID"
        '
        'btnClose
        '
        Me.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(24, 210)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(136, 50)
        Me.btnClose.TabIndex = 490
        Me.btnClose.Text = "Close"
        '
        'btnSearch
        '
        Me.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(878, 210)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 50)
        Me.btnSearch.TabIndex = 492
        Me.btnSearch.Text = "Search "
        '
        'lueDivision
        '
        Me.lueDivision.EditValue = ""
        Me.lueDivision.Location = New System.Drawing.Point(614, 33)
        Me.lueDivision.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.lueDivision.Name = "lueDivision"
        Me.lueDivision.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueDivision.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDivision.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.lueDivision.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueDivision.Size = New System.Drawing.Size(400, 34)
        Me.lueDivision.TabIndex = 500
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(428, 37)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(71, 25)
        Me.LabelControl3.TabIndex = 501
        Me.LabelControl3.Text = "Division"
        '
        'lueCondition
        '
        Me.lueCondition.Location = New System.Drawing.Point(160, 150)
        Me.lueCondition.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.lueCondition.Name = "lueCondition"
        Me.lueCondition.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueCondition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueCondition.Properties.NullText = ""
        Me.lueCondition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.lueCondition.Size = New System.Drawing.Size(236, 34)
        Me.lueCondition.TabIndex = 502
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(24, 158)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(88, 25)
        Me.LabelControl4.TabIndex = 503
        Me.LabelControl4.Text = "Condition"
        '
        'frmSearchWorkingHours
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1053, 313)
        Me.ControlBox = False
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
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchWorkingHours"
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
End Class
