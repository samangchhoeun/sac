<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddUserRoles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddUserRoles))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.meRemark = New DevExpress.XtraEditors.MemoEdit()
        Me.txtAccountName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meRemark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl1.TabIndex = 461
        Me.LabelControl1.Text = "Role Code"
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = "***"
        Me.txtNumber.Location = New System.Drawing.Point(118, 18)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumber.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.txtNumber.Properties.Appearance.Options.UseBackColor = True
        Me.txtNumber.Properties.Appearance.Options.UseForeColor = True
        Me.txtNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtNumber.Size = New System.Drawing.Size(348, 20)
        Me.txtNumber.TabIndex = 4
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
        Me.btnNew.Location = New System.Drawing.Point(0, 167)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(210, 32)
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "Add New"
        '
        'btnSave
        '
        Me.btnSave.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSave.Appearance.Options.UseBackColor = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(210, 167)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(269, 32)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Create"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(12, 92)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl2.TabIndex = 463
        Me.LabelControl2.Text = "Remark"
        '
        'meRemark
        '
        Me.meRemark.Location = New System.Drawing.Point(118, 84)
        Me.meRemark.Name = "meRemark"
        Me.meRemark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meRemark.Size = New System.Drawing.Size(348, 61)
        Me.meRemark.TabIndex = 1
        '
        'txtAccountName
        '
        Me.txtAccountName.Location = New System.Drawing.Point(118, 51)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtAccountName.Size = New System.Drawing.Size(348, 20)
        Me.txtAccountName.TabIndex = 0
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl6.Appearance.Options.UseForeColor = True
        Me.LabelControl6.Location = New System.Drawing.Point(12, 54)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl6.TabIndex = 422
        Me.LabelControl6.Text = "Role"
        '
        'frmAddUserRoles
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 199)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.meRemark)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.txtAccountName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.LabelControl6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddUserRoles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage Roles"
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meRemark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Private WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Private WithEvents txtAccountName As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents meRemark As DevExpress.XtraEditors.MemoEdit
End Class
