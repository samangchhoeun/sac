<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResetUserLogPass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResetUserLogPass))
        Me.chkChangePassNextLog = New DevExpress.XtraEditors.CheckEdit()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSID = New DevExpress.XtraEditors.SearchControl()
        Me.labelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtENName = New DevExpress.XtraEditors.TextEdit()
        Me.txtConfirmPass = New DevExpress.XtraEditors.TextEdit()
        Me.txtPass = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUserID = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEmpID = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.chkUserCannotChangePass = New DevExpress.XtraEditors.CheckEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.chkChangePassNextLog.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtENName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfirmPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUserCannotChangePass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkChangePassNextLog
        '
        Me.chkChangePassNextLog.Location = New System.Drawing.Point(126, 175)
        Me.chkChangePassNextLog.Name = "chkChangePassNextLog"
        Me.chkChangePassNextLog.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkChangePassNextLog.Properties.Appearance.Options.UseForeColor = True
        Me.chkChangePassNextLog.Properties.Caption = "User must change password at next logon"
        Me.chkChangePassNextLog.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chkChangePassNextLog.Properties.ValueChecked = CType(1, Short)
        Me.chkChangePassNextLog.Properties.ValueUnchecked = CType(0, Short)
        Me.chkChangePassNextLog.Size = New System.Drawing.Size(234, 19)
        Me.chkChangePassNextLog.TabIndex = 7
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = ""
        Me.txtNumber.Location = New System.Drawing.Point(18, 171)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(67, 20)
        Me.txtNumber.TabIndex = 10
        Me.txtNumber.Visible = False
        '
        'btnNew
        '
        Me.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(1, 237)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(155, 31)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "Add New"
        '
        'txtSID
        '
        Me.txtSID.Location = New System.Drawing.Point(126, 19)
        Me.txtSID.Name = "txtSID"
        Me.txtSID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.txtSID.Properties.NullValuePrompt = "Enter Employee ID..."
        Me.txtSID.Size = New System.Drawing.Size(247, 20)
        Me.txtSID.TabIndex = 1
        '
        'labelControl15
        '
        Me.labelControl15.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.labelControl15.Appearance.Options.UseForeColor = True
        Me.labelControl15.Location = New System.Drawing.Point(18, 22)
        Me.labelControl15.Name = "labelControl15"
        Me.labelControl15.Size = New System.Drawing.Size(73, 13)
        Me.labelControl15.TabIndex = 8
        Me.labelControl15.Text = "Search Card ID"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl12.Appearance.Options.UseForeColor = True
        Me.LabelControl12.Location = New System.Drawing.Point(18, 55)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl12.TabIndex = 389
        Me.LabelControl12.Text = "Account Name"
        '
        'txtENName
        '
        Me.txtENName.Location = New System.Drawing.Point(126, 52)
        Me.txtENName.Name = "txtENName"
        Me.txtENName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtENName.Properties.Appearance.Options.UseBackColor = True
        Me.txtENName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtENName.Properties.ReadOnly = True
        Me.txtENName.Size = New System.Drawing.Size(247, 20)
        Me.txtENName.TabIndex = 3
        '
        'txtConfirmPass
        '
        Me.txtConfirmPass.Location = New System.Drawing.Point(126, 147)
        Me.txtConfirmPass.Name = "txtConfirmPass"
        Me.txtConfirmPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtConfirmPass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPass.Size = New System.Drawing.Size(247, 20)
        Me.txtConfirmPass.TabIndex = 6
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(126, 116)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(247, 20)
        Me.txtPass.TabIndex = 5
        '
        'LabelControl20
        '
        Me.LabelControl20.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl20.Appearance.Options.UseForeColor = True
        Me.LabelControl20.Location = New System.Drawing.Point(18, 150)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl20.TabIndex = 439
        Me.LabelControl20.Text = "Confirm Password"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(18, 119)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl2.TabIndex = 437
        Me.LabelControl2.Text = "Password"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(126, 84)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtUserID.Size = New System.Drawing.Size(247, 20)
        Me.txtUserID.TabIndex = 4
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl6.Appearance.Options.UseForeColor = True
        Me.LabelControl6.Location = New System.Drawing.Point(18, 87)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl6.TabIndex = 422
        Me.LabelControl6.Text = "User ID"
        '
        'txtEmpID
        '
        Me.txtEmpID.EditValue = ""
        Me.txtEmpID.Location = New System.Drawing.Point(18, 203)
        Me.txtEmpID.Name = "txtEmpID"
        Me.txtEmpID.Properties.Appearance.BackColor = System.Drawing.Color.Beige
        Me.txtEmpID.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpID.Properties.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.txtEmpID.Properties.Appearance.Options.UseBackColor = True
        Me.txtEmpID.Properties.Appearance.Options.UseFont = True
        Me.txtEmpID.Properties.Appearance.Options.UseForeColor = True
        Me.txtEmpID.Properties.ReadOnly = True
        Me.txtEmpID.Size = New System.Drawing.Size(67, 18)
        Me.txtEmpID.TabIndex = 11
        Me.txtEmpID.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(114, 89)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl1.TabIndex = 442
        Me.LabelControl1.Text = "*"
        '
        'LabelControl17
        '
        Me.LabelControl17.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl17.Appearance.Options.UseForeColor = True
        Me.LabelControl17.Location = New System.Drawing.Point(114, 151)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl17.TabIndex = 441
        Me.LabelControl17.Text = "*"
        '
        'LabelControl16
        '
        Me.LabelControl16.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl16.Appearance.Options.UseForeColor = True
        Me.LabelControl16.Location = New System.Drawing.Point(114, 120)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl16.TabIndex = 440
        Me.LabelControl16.Text = "*"
        '
        'chkUserCannotChangePass
        '
        Me.chkUserCannotChangePass.Location = New System.Drawing.Point(126, 203)
        Me.chkUserCannotChangePass.Name = "chkUserCannotChangePass"
        Me.chkUserCannotChangePass.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.chkUserCannotChangePass.Properties.Appearance.Options.UseForeColor = True
        Me.chkUserCannotChangePass.Properties.Caption = "User cannot change password"
        Me.chkUserCannotChangePass.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chkUserCannotChangePass.Properties.ValueChecked = CType(1, Short)
        Me.chkUserCannotChangePass.Properties.ValueUnchecked = CType(0, Short)
        Me.chkUserCannotChangePass.Size = New System.Drawing.Size(171, 19)
        Me.chkUserCannotChangePass.TabIndex = 8
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSave.Enabled = False
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(157, 237)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(232, 31)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Reset"
        '
        'frmResetUserLogPass
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 268)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl17)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.LabelControl16)
        Me.Controls.Add(Me.labelControl15)
        Me.Controls.Add(Me.chkUserCannotChangePass)
        Me.Controls.Add(Me.txtEmpID)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtSID)
        Me.Controls.Add(Me.LabelControl20)
        Me.Controls.Add(Me.txtENName)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtConfirmPass)
        Me.Controls.Add(Me.chkChangePassNextLog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResetUserLogPass"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reset Password"
        CType(Me.chkChangePassNextLog.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtENName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfirmPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUserCannotChangePass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkChangePassNextLog As DevExpress.XtraEditors.CheckEdit
    Private WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Private WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Private WithEvents txtSID As DevExpress.XtraEditors.SearchControl
    Private WithEvents labelControl15 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtENName As DevExpress.XtraEditors.TextEdit
    Private WithEvents txtConfirmPass As DevExpress.XtraEditors.TextEdit
    Private WithEvents txtPass As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtUserID As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtEmpID As DevExpress.XtraEditors.TextEdit
    Private WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkUserCannotChangePass As DevExpress.XtraEditors.CheckEdit
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
End Class
