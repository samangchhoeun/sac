<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUpdateAppVersion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdateAppVersion))
        Me.txtUpdateVer = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.timReset = New System.Windows.Forms.Timer(Me.components)
        Me.lblMsg = New DevExpress.XtraEditors.LabelControl()
        Me.btnUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.chkSources = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.txtUpdateVer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSources.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUpdateVer
        '
        Me.txtUpdateVer.Location = New System.Drawing.Point(100, 14)
        Me.txtUpdateVer.Name = "txtUpdateVer"
        Me.txtUpdateVer.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdateVer.Properties.Appearance.ForeColor = System.Drawing.Color.Green
        Me.txtUpdateVer.Properties.Appearance.Options.UseFont = True
        Me.txtUpdateVer.Properties.Appearance.Options.UseForeColor = True
        Me.txtUpdateVer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.txtUpdateVer.Properties.NullValuePrompt = "Enter Server Name"
        Me.txtUpdateVer.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtUpdateVer.Properties.ReadOnly = True
        Me.txtUpdateVer.Size = New System.Drawing.Size(170, 22)
        Me.txtUpdateVer.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Update Version"
        '
        'timReset
        '
        Me.timReset.Interval = 3000
        '
        'lblMsg
        '
        Me.lblMsg.Appearance.ForeColor = System.Drawing.Color.Green
        Me.lblMsg.Appearance.Options.UseForeColor = True
        Me.lblMsg.Location = New System.Drawing.Point(161, 43)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(163, 13)
        Me.lblMsg.TabIndex = 5
        Me.lblMsg.Text = "New software version is released."
        '
        'btnUpdate
        '
        Me.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.Location = New System.Drawing.Point(276, 13)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(65, 23)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "Update"
        '
        'chkSources
        '
        Me.chkSources.EditValue = True
        Me.chkSources.Location = New System.Drawing.Point(17, 40)
        Me.chkSources.Name = "chkSources"
        Me.chkSources.Properties.Caption = "Upload source files only"
        Me.chkSources.Size = New System.Drawing.Size(138, 19)
        Me.chkSources.TabIndex = 18
        '
        'frmUpdateAppVersion
        '
        Me.AcceptButton = Me.btnUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 67)
        Me.Controls.Add(Me.chkSources)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtUpdateVer)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdateAppVersion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Software Version Update"
        CType(Me.txtUpdateVer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSources.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUpdateVer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents timReset As Timer
    Friend WithEvents lblMsg As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkSources As DevExpress.XtraEditors.CheckEdit
End Class
