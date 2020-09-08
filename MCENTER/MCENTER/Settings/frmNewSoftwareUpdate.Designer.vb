<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewSoftwareUpdate
    Inherits DevExpress.XtraSplashScreen.SplashScreen

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSoftwareUpdate))
        Me.marqueeProgressBarControl1 = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.lblVersion = New DevExpress.XtraEditors.LabelControl()
        Me.lblAppName = New DevExpress.XtraEditors.LabelControl()
        Me.lblMessage = New DevExpress.XtraEditors.LabelControl()
        Me.timLoading = New System.Windows.Forms.Timer(Me.components)
        CType(Me.marqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'marqueeProgressBarControl1
        '
        Me.marqueeProgressBarControl1.EditValue = 0
        Me.marqueeProgressBarControl1.Location = New System.Drawing.Point(18, 90)
        Me.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1"
        Me.marqueeProgressBarControl1.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.Cycle
        Me.marqueeProgressBarControl1.Size = New System.Drawing.Size(357, 15)
        Me.marqueeProgressBarControl1.TabIndex = 11
        '
        'lblVersion
        '
        Me.lblVersion.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Appearance.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblVersion.Appearance.Options.UseFont = True
        Me.lblVersion.Appearance.Options.UseForeColor = True
        Me.lblVersion.Location = New System.Drawing.Point(20, 15)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(210, 16)
        Me.lblVersion.TabIndex = 12
        Me.lblVersion.Text = "Software update version 1.0.0.5"
        '
        'lblAppName
        '
        Me.lblAppName.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppName.Appearance.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblAppName.Appearance.Options.UseFont = True
        Me.lblAppName.Appearance.Options.UseForeColor = True
        Me.lblAppName.Location = New System.Drawing.Point(19, 39)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(262, 14)
        Me.lblAppName.TabIndex = 13
        Me.lblAppName.Text = "A new version of MJQE HRM System is available."
        '
        'lblMessage
        '
        Me.lblMessage.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Appearance.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblMessage.Appearance.Options.UseFont = True
        Me.lblMessage.Appearance.Options.UseForeColor = True
        Me.lblMessage.Location = New System.Drawing.Point(20, 69)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(181, 14)
        Me.lblMessage.TabIndex = 14
        Me.lblMessage.Text = "Your software is updating now..."
        '
        'timLoading
        '
        Me.timLoading.Enabled = True
        Me.timLoading.Interval = 1000
        '
        'frmNewSoftwareUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 126)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblAppName)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.marqueeProgressBarControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewSoftwareUpdate"
        Me.Text = "Software Update"
        CType(Me.marqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents marqueeProgressBarControl1 As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents lblVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblAppName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMessage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents timLoading As Timer
End Class
