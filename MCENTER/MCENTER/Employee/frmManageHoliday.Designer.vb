<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageHoliday
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageHoliday))
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.groupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.chkSetAsCL = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUpdateAllCurrent = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNumHolidays = New DevExpress.XtraEditors.TextEdit()
        Me.chkInActive = New DevExpress.XtraEditors.CheckEdit()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.meKhDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.deHoliday = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.meEnDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupControl3.SuspendLayout()
        CType(Me.chkSetAsCL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUpdateAllCurrent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumHolidays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkInActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meKhDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deHoliday.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deHoliday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meEnDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(397, 302)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(74, 25)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        '
        'groupControl3
        '
        Me.groupControl3.CaptionImage = CType(resources.GetObject("groupControl3.CaptionImage"), System.Drawing.Image)
        Me.groupControl3.Controls.Add(Me.chkSetAsCL)
        Me.groupControl3.Controls.Add(Me.chkUpdateAllCurrent)
        Me.groupControl3.Controls.Add(Me.LabelControl8)
        Me.groupControl3.Controls.Add(Me.LabelControl7)
        Me.groupControl3.Controls.Add(Me.txtNumHolidays)
        Me.groupControl3.Controls.Add(Me.chkInActive)
        Me.groupControl3.Controls.Add(Me.btnSave)
        Me.groupControl3.Controls.Add(Me.btnNew)
        Me.groupControl3.Controls.Add(Me.LabelControl4)
        Me.groupControl3.Controls.Add(Me.meKhDescription)
        Me.groupControl3.Controls.Add(Me.deHoliday)
        Me.groupControl3.Controls.Add(Me.LabelControl1)
        Me.groupControl3.Controls.Add(Me.txtNumber)
        Me.groupControl3.Controls.Add(Me.LabelControl2)
        Me.groupControl3.Controls.Add(Me.meEnDescription)
        Me.groupControl3.Controls.Add(Me.LabelControl3)
        Me.groupControl3.Location = New System.Drawing.Point(13, 15)
        Me.groupControl3.Name = "groupControl3"
        Me.groupControl3.Size = New System.Drawing.Size(484, 340)
        Me.groupControl3.TabIndex = 0
        Me.groupControl3.Text = "Holiday Info"
        '
        'chkSetAsCL
        '
        Me.chkSetAsCL.Location = New System.Drawing.Point(12, 80)
        Me.chkSetAsCL.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkSetAsCL.Name = "chkSetAsCL"
        Me.chkSetAsCL.Properties.Caption = "Set as Common Leave"
        Me.chkSetAsCL.Size = New System.Drawing.Size(128, 19)
        Me.chkSetAsCL.TabIndex = 3
        '
        'chkUpdateAllCurrent
        '
        Me.chkUpdateAllCurrent.Location = New System.Drawing.Point(13, 275)
        Me.chkUpdateAllCurrent.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkUpdateAllCurrent.Name = "chkUpdateAllCurrent"
        Me.chkUpdateAllCurrent.Properties.Caption = "Update this holiday on current year"
        Me.chkUpdateAllCurrent.Size = New System.Drawing.Size(195, 19)
        Me.chkUpdateAllCurrent.TabIndex = 6
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl8.Appearance.Options.UseForeColor = True
        Me.LabelControl8.Location = New System.Drawing.Point(13, 31)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl8.TabIndex = 469
        Me.LabelControl8.Text = "Holiday ID"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(376, 29)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl7.TabIndex = 468
        Me.LabelControl7.Text = "No of Holidays"
        '
        'txtNumHolidays
        '
        Me.txtNumHolidays.EditValue = ""
        Me.txtNumHolidays.Location = New System.Drawing.Point(376, 50)
        Me.txtNumHolidays.Name = "txtNumHolidays"
        Me.txtNumHolidays.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtNumHolidays.Size = New System.Drawing.Size(94, 20)
        Me.txtNumHolidays.TabIndex = 2
        '
        'chkInActive
        '
        Me.chkInActive.Location = New System.Drawing.Point(406, 275)
        Me.chkInActive.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkInActive.Name = "chkInActive"
        Me.chkInActive.Properties.Caption = "Inactive"
        Me.chkInActive.Size = New System.Drawing.Size(64, 19)
        Me.chkInActive.TabIndex = 7
        '
        'btnNew
        '
        Me.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnNew.Enabled = False
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(312, 302)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(74, 25)
        Me.btnNew.TabIndex = 9
        Me.btnNew.Text = "New"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(13, 178)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl4.TabIndex = 463
        Me.LabelControl4.Text = "Khmer Description"
        '
        'meKhDescription
        '
        Me.meKhDescription.EditValue = ""
        Me.meKhDescription.Location = New System.Drawing.Point(13, 197)
        Me.meKhDescription.Name = "meKhDescription"
        Me.meKhDescription.Properties.Appearance.Font = New System.Drawing.Font("Khmer OS Battambang", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.meKhDescription.Properties.Appearance.Options.UseFont = True
        Me.meKhDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meKhDescription.Size = New System.Drawing.Size(458, 74)
        Me.meKhDescription.TabIndex = 5
        '
        'deHoliday
        '
        Me.deHoliday.EditValue = Nothing
        Me.deHoliday.Location = New System.Drawing.Point(129, 50)
        Me.deHoliday.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deHoliday.Name = "deHoliday"
        Me.deHoliday.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deHoliday.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deHoliday.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deHoliday.Size = New System.Drawing.Size(212, 20)
        Me.deHoliday.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(129, 31)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl1.TabIndex = 461
        Me.LabelControl1.Text = "Select Date"
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = "***"
        Me.txtNumber.Location = New System.Drawing.Point(13, 50)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumber.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNumber.Properties.Appearance.Options.UseBackColor = True
        Me.txtNumber.Properties.Appearance.Options.UseForeColor = True
        Me.txtNumber.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtNumber.Properties.ReadOnly = True
        Me.txtNumber.Size = New System.Drawing.Size(89, 20)
        Me.txtNumber.TabIndex = 11
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(13, 108)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(89, 13)
        Me.LabelControl2.TabIndex = 437
        Me.LabelControl2.Text = "English Description"
        '
        'meEnDescription
        '
        Me.meEnDescription.Location = New System.Drawing.Point(13, 128)
        Me.meEnDescription.Name = "meEnDescription"
        Me.meEnDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meEnDescription.Size = New System.Drawing.Size(458, 41)
        Me.meEnDescription.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(107, 108)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl3.TabIndex = 459
        Me.LabelControl3.Text = "*"
        '
        'frmManageHoliday
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 369)
        Me.Controls.Add(Me.groupControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageHoliday"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage Holiday"
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupControl3.ResumeLayout(False)
        Me.groupControl3.PerformLayout()
        CType(Me.chkSetAsCL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUpdateAllCurrent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumHolidays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkInActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meKhDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deHoliday.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deHoliday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meEnDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents groupControl3 As DevExpress.XtraEditors.GroupControl
    Private WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtNumHolidays As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkInActive As DevExpress.XtraEditors.CheckEdit
    Private WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Private WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents meKhDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents deHoliday As DevExpress.XtraEditors.DateEdit
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents meEnDescription As DevExpress.XtraEditors.MemoEdit
    Private WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkUpdateAllCurrent As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSetAsCL As DevExpress.XtraEditors.CheckEdit
End Class
