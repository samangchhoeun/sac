<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddRemotePath
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddRemotePath))
        Me.txtConServer = New DevExpress.XtraEditors.TextEdit()
        Me.btnConSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtConServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtConServer
        '
        Me.txtConServer.Location = New System.Drawing.Point(12, 34)
        Me.txtConServer.Name = "txtConServer"
        Me.txtConServer.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConServer.Properties.Appearance.Options.UseFont = True
        Me.txtConServer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtConServer.Properties.NullValuePrompt = "Enter Server Name"
        Me.txtConServer.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtConServer.Size = New System.Drawing.Size(265, 24)
        Me.txtConServer.TabIndex = 1
        '
        'btnConSave
        '
        Me.btnConSave.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnConSave.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnConSave.Appearance.Options.UseBackColor = True
        Me.btnConSave.Appearance.Options.UseForeColor = True
        Me.btnConSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnConSave.Image = CType(resources.GetObject("btnConSave.Image"), System.Drawing.Image)
        Me.btnConSave.Location = New System.Drawing.Point(12, 66)
        Me.btnConSave.Name = "btnConSave"
        Me.btnConSave.Size = New System.Drawing.Size(265, 26)
        Me.btnConSave.TabIndex = 7
        Me.btnConSave.Text = "SAVE"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.White
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(117, 16)
        Me.LabelControl1.TabIndex = 8
        Me.LabelControl1.Text = "Set Autoupdate Path"
        '
        'frmAddRemotePath
        '
        Me.AcceptButton = Me.btnConSave
        Me.Appearance.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 106)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnConSave)
        Me.Controls.Add(Me.txtConServer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddRemotePath"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Remote Path"
        CType(Me.txtConServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtConServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnConSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
