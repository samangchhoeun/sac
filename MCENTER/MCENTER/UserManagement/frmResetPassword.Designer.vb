<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmResetPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResetPassword))
        Me.lblAccName = New DevExpress.XtraEditors.LabelControl()
        Me.txtOldPass = New DevExpress.XtraEditors.TextEdit()
        Me.labelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtConfirmPass = New DevExpress.XtraEditors.TextEdit()
        Me.txtNewPass = New DevExpress.XtraEditors.TextEdit()
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.pictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.timReset = New System.Windows.Forms.Timer(Me.components)
        CType(Me.txtOldPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfirmPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNewPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAccName
        '
        Me.lblAccName.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.lblAccName.Appearance.Options.UseForeColor = True
        Me.lblAccName.Location = New System.Drawing.Point(79, 15)
        Me.lblAccName.Name = "lblAccName"
        Me.lblAccName.Size = New System.Drawing.Size(224, 13)
        Me.lblAccName.TabIndex = 20
        Me.lblAccName.Text = "Please fill out information to change password."
        '
        'txtOldPass
        '
        Me.txtOldPass.Location = New System.Drawing.Point(178, 39)
        Me.txtOldPass.Name = "txtOldPass"
        Me.txtOldPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtOldPass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPass.Size = New System.Drawing.Size(180, 20)
        Me.txtOldPass.TabIndex = 0
        '
        'labelControl3
        '
        Me.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.labelControl3.Appearance.Options.UseForeColor = True
        Me.labelControl3.Location = New System.Drawing.Point(79, 42)
        Me.labelControl3.Name = "labelControl3"
        Me.labelControl3.Size = New System.Drawing.Size(86, 13)
        Me.labelControl3.TabIndex = 19
        Me.labelControl3.Text = "Current Password"
        '
        'txtConfirmPass
        '
        Me.txtConfirmPass.Location = New System.Drawing.Point(178, 99)
        Me.txtConfirmPass.Name = "txtConfirmPass"
        Me.txtConfirmPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtConfirmPass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPass.Size = New System.Drawing.Size(180, 20)
        Me.txtConfirmPass.TabIndex = 2
        '
        'txtNewPass
        '
        Me.txtNewPass.Location = New System.Drawing.Point(178, 69)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtNewPass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPass.Size = New System.Drawing.Size(180, 20)
        Me.txtNewPass.TabIndex = 1
        '
        'labelControl2
        '
        Me.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.labelControl2.Appearance.Options.UseForeColor = True
        Me.labelControl2.Location = New System.Drawing.Point(79, 102)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(86, 13)
        Me.labelControl2.TabIndex = 18
        Me.labelControl2.Text = "Confirm Password"
        '
        'labelControl1
        '
        Me.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.labelControl1.Appearance.Options.UseForeColor = True
        Me.labelControl1.Location = New System.Drawing.Point(79, 72)
        Me.labelControl1.Name = "labelControl1"
        Me.labelControl1.Size = New System.Drawing.Size(70, 13)
        Me.labelControl1.TabIndex = 17
        Me.labelControl1.Text = "New Password"
        '
        'pictureEdit1
        '
        Me.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default
        Me.pictureEdit1.EditValue = CType(resources.GetObject("pictureEdit1.EditValue"), Object)
        Me.pictureEdit1.Location = New System.Drawing.Point(1, 16)
        Me.pictureEdit1.Name = "pictureEdit1"
        Me.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.pictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pictureEdit1.Properties.ZoomAccelerationFactor = 1.0R
        Me.pictureEdit1.Size = New System.Drawing.Size(72, 84)
        Me.pictureEdit1.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSave.Appearance.Options.UseBackColor = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(0, 133)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(372, 32)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save Change"
        '
        'timReset
        '
        Me.timReset.Interval = 1000
        '
        'frmResetPassword
        '
        Me.AcceptButton = Me.btnSave
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 165)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblAccName)
        Me.Controls.Add(Me.txtOldPass)
        Me.Controls.Add(Me.labelControl3)
        Me.Controls.Add(Me.txtConfirmPass)
        Me.Controls.Add(Me.txtNewPass)
        Me.Controls.Add(Me.labelControl2)
        Me.Controls.Add(Me.labelControl1)
        Me.Controls.Add(Me.pictureEdit1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResetPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reset Password"
        CType(Me.txtOldPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfirmPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNewPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblAccName As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtOldPass As DevExpress.XtraEditors.TextEdit
    Private WithEvents labelControl3 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtConfirmPass As DevExpress.XtraEditors.TextEdit
    Private WithEvents txtNewPass As DevExpress.XtraEditors.TextEdit
    Private WithEvents labelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents labelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents pictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Private WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents timReset As Timer
End Class
