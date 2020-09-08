<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWelcomePage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWelcomePage))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblApplication = New DevExpress.XtraEditors.LabelControl()
        Me.pbcStatus = New DevExpress.XtraEditors.ProgressBarControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblVersion = New DevExpress.XtraEditors.LabelControl()
        Me.lblPercent = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbcStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(17, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(103, 97)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblApplication
        '
        Me.lblApplication.Appearance.Font = New System.Drawing.Font("Bliss", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApplication.Appearance.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblApplication.Appearance.Options.UseFont = True
        Me.lblApplication.Appearance.Options.UseForeColor = True
        Me.lblApplication.Appearance.Options.UseTextOptions = True
        Me.lblApplication.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblApplication.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblApplication.Location = New System.Drawing.Point(137, 19)
        Me.lblApplication.Name = "lblApplication"
        Me.lblApplication.Size = New System.Drawing.Size(301, 38)
        Me.lblApplication.TabIndex = 1
        Me.lblApplication.Text = "PB MEDICAL CENTER"
        '
        'pbcStatus
        '
        Me.pbcStatus.Location = New System.Drawing.Point(17, 155)
        Me.pbcStatus.Name = "pbcStatus"
        Me.pbcStatus.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.pbcStatus.Properties.ShowTitle = True
        Me.pbcStatus.Size = New System.Drawing.Size(421, 20)
        Me.pbcStatus.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseBackColor = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(137, 81)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(301, 10)
        Me.LabelControl1.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Bliss", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Crimson
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Appearance.Options.UseTextOptions = True
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(137, 97)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(301, 19)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Powered By PreemBell Group"
        '
        'lblVersion
        '
        Me.lblVersion.Appearance.Font = New System.Drawing.Font("Bliss", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Appearance.ForeColor = System.Drawing.Color.Crimson
        Me.lblVersion.Appearance.Options.UseFont = True
        Me.lblVersion.Appearance.Options.UseForeColor = True
        Me.lblVersion.Appearance.Options.UseTextOptions = True
        Me.lblVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblVersion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblVersion.Location = New System.Drawing.Point(318, 61)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(120, 14)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "Version: 0.0.0.0"
        '
        'lblPercent
        '
        Me.lblPercent.Appearance.Font = New System.Drawing.Font("Bliss", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPercent.Appearance.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblPercent.Appearance.Options.UseFont = True
        Me.lblPercent.Appearance.Options.UseForeColor = True
        Me.lblPercent.Appearance.Options.UseTextOptions = True
        Me.lblPercent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblPercent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblPercent.Location = New System.Drawing.Point(317, 130)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(121, 19)
        Me.lblPercent.TabIndex = 6
        Me.lblPercent.Text = "Loading 0%"
        '
        'frmWelcomePage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 196)
        Me.Controls.Add(Me.lblPercent)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.pbcStatus)
        Me.Controls.Add(Me.lblApplication)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWelcomePage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmWelcomePage"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbcStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblApplication As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pbcStatus As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPercent As DevExpress.XtraEditors.LabelControl
End Class
