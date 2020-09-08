<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLockScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLockScreen))
        Me.picPhoto = New System.Windows.Forms.PictureBox()
        Me.lblUsername = New DevExpress.XtraEditors.LabelControl()
        Me.txtPwd = New DevExpress.XtraEditors.ButtonEdit()
        Me.btnShutdown = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTime = New DevExpress.XtraEditors.LabelControl()
        Me.lblDate = New DevExpress.XtraEditors.LabelControl()
        Me.timeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblIncorrectPassword = New DevExpress.XtraEditors.LabelControl()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.timeCountDown = New System.Windows.Forms.Timer(Me.components)
        Me.lblTryAgain = New DevExpress.XtraEditors.LabelControl()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picPhoto
        '
        Me.picPhoto.BackColor = System.Drawing.Color.Transparent
        Me.picPhoto.BackgroundImage = CType(resources.GetObject("picPhoto.BackgroundImage"), System.Drawing.Image)
        Me.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picPhoto.Location = New System.Drawing.Point(269, 32)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(118, 127)
        Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPhoto.TabIndex = 377
        Me.picPhoto.TabStop = False
        Me.picPhoto.Tag = ""
        '
        'lblUsername
        '
        Me.lblUsername.Appearance.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblUsername.Appearance.Options.UseFont = True
        Me.lblUsername.Appearance.Options.UseForeColor = True
        Me.lblUsername.Appearance.Options.UseTextOptions = True
        Me.lblUsername.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblUsername.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblUsername.Location = New System.Drawing.Point(99, 177)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(457, 30)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Sam Ang Chhoeun"
        '
        'txtPwd
        '
        Me.txtPwd.EditValue = ""
        Me.txtPwd.Location = New System.Drawing.Point(207, 228)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtPwd.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtPwd.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson
        Me.txtPwd.Properties.Appearance.Options.UseBackColor = True
        Me.txtPwd.Properties.Appearance.Options.UseFont = True
        Me.txtPwd.Properties.Appearance.Options.UseForeColor = True
        Me.txtPwd.Properties.AutoHeight = False
        Me.txtPwd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtPwd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)})
        Me.txtPwd.Properties.NullValuePrompt = "Password"
        Me.txtPwd.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtPwd.Properties.UseSystemPasswordChar = True
        Me.txtPwd.Size = New System.Drawing.Size(242, 26)
        Me.txtPwd.TabIndex = 0
        '
        'btnShutdown
        '
        Me.btnShutdown.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.btnShutdown.Image = CType(resources.GetObject("btnShutdown.Image"), System.Drawing.Image)
        Me.btnShutdown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnShutdown.Location = New System.Drawing.Point(624, 326)
        Me.btnShutdown.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnShutdown.Name = "btnShutdown"
        Me.btnShutdown.Size = New System.Drawing.Size(24, 26)
        Me.btnShutdown.TabIndex = 5
        '
        'lblTime
        '
        Me.lblTime.Appearance.Font = New System.Drawing.Font("Calibri", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblTime.Appearance.Options.UseFont = True
        Me.lblTime.Appearance.Options.UseForeColor = True
        Me.lblTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTime.Location = New System.Drawing.Point(10, 278)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(173, 32)
        Me.lblTime.TabIndex = 3
        Me.lblTime.Text = "11:06 am"
        '
        'lblDate
        '
        Me.lblDate.Appearance.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblDate.Appearance.Options.UseFont = True
        Me.lblDate.Appearance.Options.UseForeColor = True
        Me.lblDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDate.Location = New System.Drawing.Point(11, 318)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(340, 24)
        Me.lblDate.TabIndex = 4
        Me.lblDate.Text = "Monday, August 20, 2018"
        '
        'timeTimer
        '
        Me.timeTimer.Enabled = True
        Me.timeTimer.Interval = 1000
        '
        'lblIncorrectPassword
        '
        Me.lblIncorrectPassword.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncorrectPassword.Appearance.ForeColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblIncorrectPassword.Appearance.Options.UseFont = True
        Me.lblIncorrectPassword.Appearance.Options.UseForeColor = True
        Me.lblIncorrectPassword.Appearance.Options.UseTextOptions = True
        Me.lblIncorrectPassword.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblIncorrectPassword.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblIncorrectPassword.Location = New System.Drawing.Point(181, 220)
        Me.lblIncorrectPassword.Name = "lblIncorrectPassword"
        Me.lblIncorrectPassword.Size = New System.Drawing.Size(293, 18)
        Me.lblIncorrectPassword.TabIndex = 2
        Me.lblIncorrectPassword.Text = "The password is incorrect. Try again."
        Me.lblIncorrectPassword.Visible = False
        '
        'btnOK
        '
        Me.btnOK.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.btnOK.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnOK.Appearance.BorderColor = System.Drawing.Color.White
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnOK.Appearance.Options.UseBackColor = True
        Me.btnOK.Appearance.Options.UseBorderColor = True
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.Appearance.Options.UseForeColor = True
        Me.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnOK.Location = New System.Drawing.Point(275, 249)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(105, 26)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.Visible = False
        '
        'timeCountDown
        '
        Me.timeCountDown.Interval = 1000
        '
        'lblTryAgain
        '
        Me.lblTryAgain.Appearance.Font = New System.Drawing.Font("Calibri", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTryAgain.Appearance.ForeColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblTryAgain.Appearance.Options.UseFont = True
        Me.lblTryAgain.Appearance.Options.UseForeColor = True
        Me.lblTryAgain.Appearance.Options.UseTextOptions = True
        Me.lblTryAgain.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblTryAgain.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTryAgain.Location = New System.Drawing.Point(225, 247)
        Me.lblTryAgain.Name = "lblTryAgain"
        Me.lblTryAgain.Size = New System.Drawing.Size(206, 18)
        Me.lblTryAgain.TabIndex = 378
        Me.lblTryAgain.Text = "try again in 1 minute"
        Me.lblTryAgain.Visible = False
        '
        'frmLockScreen
        '
        Me.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile
        Me.BackgroundImageStore = CType(resources.GetObject("$this.BackgroundImageStore"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(658, 362)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTryAgain)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblIncorrectPassword)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.btnShutdown)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.picPhoto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmLockScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lock Screen"
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents picPhoto As PictureBox
    Private WithEvents lblUsername As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPwd As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents btnShutdown As DevExpress.XtraEditors.SimpleButton
    Private WithEvents lblTime As DevExpress.XtraEditors.LabelControl
    Private WithEvents lblDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents timeTimer As Timer
    Private WithEvents lblIncorrectPassword As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents timeCountDown As Timer
    Private WithEvents lblTryAgain As DevExpress.XtraEditors.LabelControl
End Class
