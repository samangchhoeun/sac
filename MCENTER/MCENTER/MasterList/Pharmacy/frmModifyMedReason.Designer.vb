<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmModifyMedReason
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModifyMedReason))
        Me.btnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.meReason = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.meReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnConfirm
        '
        Me.btnConfirm.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnConfirm.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnConfirm.Image = CType(resources.GetObject("btnConfirm.Image"), System.Drawing.Image)
        Me.btnConfirm.Location = New System.Drawing.Point(0, 50)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(357, 32)
        Me.btnConfirm.TabIndex = 1
        Me.btnConfirm.Text = "CONFIRM"
        '
        'meReason
        '
        Me.meReason.Dock = System.Windows.Forms.DockStyle.Top
        Me.meReason.Location = New System.Drawing.Point(0, 0)
        Me.meReason.Name = "meReason"
        Me.meReason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meReason.Size = New System.Drawing.Size(357, 49)
        Me.meReason.TabIndex = 0
        '
        'frmModifyMedReason
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 82)
        Me.Controls.Add(Me.meReason)
        Me.Controls.Add(Me.btnConfirm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmModifyMedReason"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Adjustment reason"
        CType(Me.meReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents meReason As DevExpress.XtraEditors.MemoEdit
End Class
