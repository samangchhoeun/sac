<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangePassword))
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtConfirmPass = New DevExpress.XtraEditors.TextEdit()
        Me.txtPass = New DevExpress.XtraEditors.TextEdit()
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.pictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.labelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtConfirmPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSave.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnSave.Appearance.Options.UseBackColor = True
        Me.btnSave.Appearance.Options.UseForeColor = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(12, 118)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(327, 28)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save Change"
        '
        'txtConfirmPass
        '
        Me.txtConfirmPass.Location = New System.Drawing.Point(167, 73)
        Me.txtConfirmPass.Name = "txtConfirmPass"
        Me.txtConfirmPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtConfirmPass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPass.Size = New System.Drawing.Size(172, 20)
        Me.txtConfirmPass.TabIndex = 1
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(167, 43)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(172, 20)
        Me.txtPass.TabIndex = 0
        '
        'labelControl2
        '
        Me.labelControl2.Location = New System.Drawing.Point(72, 76)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(84, 13)
        Me.labelControl2.TabIndex = 8
        Me.labelControl2.Text = "Retype Password"
        '
        'labelControl1
        '
        Me.labelControl1.Location = New System.Drawing.Point(72, 46)
        Me.labelControl1.Name = "labelControl1"
        Me.labelControl1.Size = New System.Drawing.Size(70, 13)
        Me.labelControl1.TabIndex = 6
        Me.labelControl1.Text = "New Password"
        '
        'pictureEdit1
        '
        Me.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default
        Me.pictureEdit1.EditValue = CType(resources.GetObject("pictureEdit1.EditValue"), Object)
        Me.pictureEdit1.Location = New System.Drawing.Point(0, 31)
        Me.pictureEdit1.Name = "pictureEdit1"
        Me.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.pictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pictureEdit1.Properties.ZoomAccelerationFactor = 1.0R
        Me.pictureEdit1.Size = New System.Drawing.Size(75, 84)
        Me.pictureEdit1.TabIndex = 4
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.PanelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Appearance.Options.UseFont = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.labelControl4)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(355, 29)
        Me.PanelControl1.TabIndex = 39
        '
        'labelControl4
        '
        Me.labelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.labelControl4.Appearance.Options.UseFont = True
        Me.labelControl4.Appearance.Options.UseForeColor = True
        Me.labelControl4.Location = New System.Drawing.Point(6, 6)
        Me.labelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.labelControl4.Name = "labelControl4"
        Me.labelControl4.Size = New System.Drawing.Size(115, 16)
        Me.labelControl4.TabIndex = 33
        Me.labelControl4.Text = "Change Password"
        '
        'frmChangePassword
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 159)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtConfirmPass)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.labelControl2)
        Me.Controls.Add(Me.labelControl1)
        Me.Controls.Add(Me.pictureEdit1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        CType(Me.txtConfirmPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Private WithEvents txtConfirmPass As DevExpress.XtraEditors.TextEdit
    Private WithEvents txtPass As DevExpress.XtraEditors.TextEdit
    Private WithEvents labelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents labelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents pictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Private WithEvents labelControl4 As DevExpress.XtraEditors.LabelControl
End Class
