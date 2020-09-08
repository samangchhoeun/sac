<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowUploadPercentage
    Inherits DevExpress.XtraSplashScreen.SplashScreen

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShowUploadPercentage))
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblUpload = New DevExpress.XtraEditors.LabelControl()
        Me.pbAttachment = New DevExpress.XtraEditors.ProgressBarControl()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        CType(Me.pbAttachment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelControl2
        '
        Me.labelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.labelControl2.Appearance.Options.UseFont = True
        Me.labelControl2.Appearance.Options.UseForeColor = True
        Me.labelControl2.Location = New System.Drawing.Point(12, 12)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(91, 18)
        Me.labelControl2.TabIndex = 12
        Me.labelControl2.Text = "Please wait... "
        '
        'lblUpload
        '
        Me.lblUpload.Location = New System.Drawing.Point(12, 57)
        Me.lblUpload.Name = "lblUpload"
        Me.lblUpload.Size = New System.Drawing.Size(62, 13)
        Me.lblUpload.TabIndex = 470
        Me.lblUpload.Text = "Uploading... "
        '
        'pbAttachment
        '
        Me.pbAttachment.Location = New System.Drawing.Point(12, 34)
        Me.pbAttachment.Name = "pbAttachment"
        Me.pbAttachment.Properties.ShowTitle = True
        Me.pbAttachment.Size = New System.Drawing.Size(294, 17)
        Me.pbAttachment.TabIndex = 471
        '
        'frmShowUploadPercentage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 80)
        Me.Controls.Add(Me.pbAttachment)
        Me.Controls.Add(Me.lblUpload)
        Me.Controls.Add(Me.labelControl2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmShowUploadPercentage"
        Me.Text = "Uploading..."
        CType(Me.pbAttachment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents labelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUpload As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pbAttachment As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
End Class
