<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCheckForUpdates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckForUpdates))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.tecAppUpdate = New DevExpress.XtraRichEdit.RichEditControl()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(147, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "There is new update available:"
        '
        'btnUpdate
        '
        Me.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnUpdate.Location = New System.Drawing.Point(115, 227)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(134, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Download and Install"
        '
        'btnCancel
        '
        Me.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnCancel.Location = New System.Drawing.Point(255, 227)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Close"
        '
        'tecAppUpdate
        '
        Me.tecAppUpdate.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        Me.tecAppUpdate.Appearance.Text.Options.UseTextOptions = True
        Me.tecAppUpdate.Appearance.Text.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.tecAppUpdate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.tecAppUpdate.Location = New System.Drawing.Point(13, 32)
        Me.tecAppUpdate.Name = "tecAppUpdate"
        Me.tecAppUpdate.ReadOnly = True
        Me.tecAppUpdate.Size = New System.Drawing.Size(400, 185)
        Me.tecAppUpdate.TabIndex = 4
        '
        'frmCheckForUpdates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 262)
        Me.Controls.Add(Me.tecAppUpdate)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheckForUpdates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Software Update"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tecAppUpdate As DevExpress.XtraRichEdit.RichEditControl
End Class
