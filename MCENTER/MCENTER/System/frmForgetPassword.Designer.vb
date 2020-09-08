<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmForgetPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmForgetPassword))
        Me.btnLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.labelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtStaffID = New DevExpress.XtraEditors.TextEdit()
        Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFullName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUserID = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPhone = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtStaffID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFullName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLogin
        '
        Me.btnLogin.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnLogin.Appearance.Options.UseBackColor = True
        Me.btnLogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnLogin.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnLogin.Image = CType(resources.GetObject("btnLogin.Image"), System.Drawing.Image)
        Me.btnLogin.Location = New System.Drawing.Point(0, 198)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(280, 30)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "Request"
        '
        'labelControl5
        '
        Me.labelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl5.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.labelControl5.Appearance.Options.UseFont = True
        Me.labelControl5.Appearance.Options.UseForeColor = True
        Me.labelControl5.Location = New System.Drawing.Point(9, 12)
        Me.labelControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.labelControl5.Name = "labelControl5"
        Me.labelControl5.Size = New System.Drawing.Size(172, 14)
        Me.labelControl5.TabIndex = 45
        Me.labelControl5.Text = "Please fill in the information"
        '
        'labelControl2
        '
        Me.labelControl2.Location = New System.Drawing.Point(9, 130)
        Me.labelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(50, 13)
        Me.labelControl2.TabIndex = 44
        Me.labelControl2.Text = "Telephone"
        '
        'txtStaffID
        '
        Me.txtStaffID.EditValue = ""
        Me.txtStaffID.Location = New System.Drawing.Point(76, 36)
        Me.txtStaffID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtStaffID.Name = "txtStaffID"
        Me.txtStaffID.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtStaffID.Properties.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.txtStaffID.Properties.Appearance.Options.UseBackColor = True
        Me.txtStaffID.Properties.Appearance.Options.UseForeColor = True
        Me.txtStaffID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtStaffID.Size = New System.Drawing.Size(192, 20)
        Me.txtStaffID.TabIndex = 0
        '
        'labelControl1
        '
        Me.labelControl1.Location = New System.Drawing.Point(9, 40)
        Me.labelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.labelControl1.Name = "labelControl1"
        Me.labelControl1.Size = New System.Drawing.Size(37, 13)
        Me.labelControl1.TabIndex = 41
        Me.labelControl1.Text = "Card ID"
        '
        'txtFullName
        '
        Me.txtFullName.EditValue = ""
        Me.txtFullName.Location = New System.Drawing.Point(76, 66)
        Me.txtFullName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtFullName.Properties.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.txtFullName.Properties.Appearance.Options.UseBackColor = True
        Me.txtFullName.Properties.Appearance.Options.UseForeColor = True
        Me.txtFullName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtFullName.Size = New System.Drawing.Size(192, 20)
        Me.txtFullName.TabIndex = 1
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(9, 68)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl6.TabIndex = 47
        Me.LabelControl6.Text = "Full Name"
        '
        'txtEmail
        '
        Me.txtEmail.EditValue = ""
        Me.txtEmail.Location = New System.Drawing.Point(76, 98)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtEmail.Properties.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.txtEmail.Properties.Appearance.Options.UseBackColor = True
        Me.txtEmail.Properties.Appearance.Options.UseForeColor = True
        Me.txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtEmail.Size = New System.Drawing.Size(192, 20)
        Me.txtEmail.TabIndex = 2
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(9, 100)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl7.TabIndex = 49
        Me.LabelControl7.Text = "Username"
        '
        'txtUserID
        '
        Me.txtUserID.EditValue = ""
        Me.txtUserID.Location = New System.Drawing.Point(76, 159)
        Me.txtUserID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtUserID.Properties.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.txtUserID.Properties.Appearance.Options.UseBackColor = True
        Me.txtUserID.Properties.Appearance.Options.UseForeColor = True
        Me.txtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtUserID.Size = New System.Drawing.Size(192, 20)
        Me.txtUserID.TabIndex = 4
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(9, 162)
        Me.LabelControl8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl8.TabIndex = 50
        Me.LabelControl8.Text = "Email"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(76, 128)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtPhone.Properties.Appearance.Options.UseBackColor = True
        Me.txtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPhone.Properties.Mask.EditMask = "\099-000-0009"
        Me.txtPhone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.txtPhone.Size = New System.Drawing.Size(192, 20)
        Me.txtPhone.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(64, 38)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl3.TabIndex = 51
        Me.LabelControl3.Text = "*"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(64, 130)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl4.TabIndex = 52
        Me.LabelControl4.Text = "*"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl9.Appearance.Options.UseForeColor = True
        Me.LabelControl9.Location = New System.Drawing.Point(64, 68)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl9.TabIndex = 53
        Me.LabelControl9.Text = "*"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl10.Appearance.Options.UseForeColor = True
        Me.LabelControl10.Location = New System.Drawing.Point(64, 162)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl10.TabIndex = 54
        Me.LabelControl10.Text = "*"
        '
        'btnCancel
        '
        Me.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCancel.Location = New System.Drawing.Point(262, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(15, 15)
        Me.btnCancel.TabIndex = 55
        '
        'frmForgetPassword
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(280, 228)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.labelControl5)
        Me.Controls.Add(Me.labelControl2)
        Me.Controls.Add(Me.txtStaffID)
        Me.Controls.Add(Me.labelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmForgetPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Forgot Your Account?"
        CType(Me.txtStaffID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFullName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnLogin As DevExpress.XtraEditors.SimpleButton
    Private WithEvents labelControl5 As DevExpress.XtraEditors.LabelControl
    Private WithEvents labelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtStaffID As DevExpress.XtraEditors.TextEdit
    Private WithEvents labelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtFullName As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtEmail As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtUserID As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtPhone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
End Class
