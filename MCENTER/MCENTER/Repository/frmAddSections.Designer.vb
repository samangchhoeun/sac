<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddSections
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddSections))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSectionEn = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSectionKh = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.lueDepartment = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSectionEn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSectionKh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueDepartment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 461
        Me.LabelControl1.Text = "Section Code"
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = "***"
        Me.txtNumber.Location = New System.Drawing.Point(110, 18)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumber.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.txtNumber.Properties.Appearance.Options.UseBackColor = True
        Me.txtNumber.Properties.Appearance.Options.UseForeColor = True
        Me.txtNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtNumber.Size = New System.Drawing.Size(348, 20)
        Me.txtNumber.TabIndex = 5
        '
        'btnNew
        '
        Me.btnNew.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.btnNew.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnNew.Appearance.Options.UseBackColor = True
        Me.btnNew.Appearance.Options.UseForeColor = True
        Me.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnNew.Enabled = False
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(1, 171)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(216, 34)
        Me.btnNew.TabIndex = 4
        Me.btnNew.Text = "Add New"
        '
        'btnSave
        '
        Me.btnSave.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSave.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnSave.Appearance.Options.UseBackColor = True
        Me.btnSave.Appearance.Options.UseForeColor = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(218, 171)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(253, 34)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Create"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(12, 129)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl2.TabIndex = 463
        Me.LabelControl2.Text = "Section in Khmer"
        '
        'txtSectionEn
        '
        Me.txtSectionEn.Location = New System.Drawing.Point(110, 88)
        Me.txtSectionEn.Name = "txtSectionEn"
        Me.txtSectionEn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSectionEn.Size = New System.Drawing.Size(348, 20)
        Me.txtSectionEn.TabIndex = 1
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl6.Appearance.Options.UseForeColor = True
        Me.LabelControl6.Location = New System.Drawing.Point(12, 91)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(82, 13)
        Me.LabelControl6.TabIndex = 422
        Me.LabelControl6.Text = "Section in English"
        '
        'txtSectionKh
        '
        Me.txtSectionKh.Location = New System.Drawing.Point(110, 121)
        Me.txtSectionKh.Name = "txtSectionKh"
        Me.txtSectionKh.Properties.Appearance.Font = New System.Drawing.Font("Khmer OS Battambang", 9.75!)
        Me.txtSectionKh.Properties.Appearance.Options.UseFont = True
        Me.txtSectionKh.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSectionKh.Size = New System.Drawing.Size(348, 30)
        Me.txtSectionKh.TabIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(12, 55)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl4.TabIndex = 467
        Me.LabelControl4.Text = "Department"
        '
        'lueDepartment
        '
        Me.lueDepartment.EditValue = ""
        Me.lueDepartment.Location = New System.Drawing.Point(110, 52)
        Me.lueDepartment.Name = "lueDepartment"
        Me.lueDepartment.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.lueDepartment.Properties.Appearance.ForeColor = System.Drawing.Color.DarkCyan
        Me.lueDepartment.Properties.Appearance.Options.UseBackColor = True
        Me.lueDepartment.Properties.Appearance.Options.UseForeColor = True
        Me.lueDepartment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDepartment.Properties.NullText = ""
        Me.lueDepartment.Size = New System.Drawing.Size(349, 20)
        Me.lueDepartment.TabIndex = 0
        '
        'frmAddSections
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 205)
        Me.Controls.Add(Me.lueDepartment)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.txtSectionKh)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.txtSectionEn)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.LabelControl6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddSections"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modify Sections"
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSectionEn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSectionKh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueDepartment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Private WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Private WithEvents txtSectionEn As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtSectionKh As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Private WithEvents lueDepartment As DevExpress.XtraEditors.LookUpEdit
End Class
