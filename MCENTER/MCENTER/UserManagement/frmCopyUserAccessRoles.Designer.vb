<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyUserAccessRoles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCopyUserAccessRoles))
        Me.lueStaffID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblLabel = New DevExpress.XtraEditors.LabelControl()
        Me.btnAssign = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.lueStaffID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lueStaffID
        '
        Me.lueStaffID.Location = New System.Drawing.Point(0, 28)
        Me.lueStaffID.Name = "lueStaffID"
        Me.lueStaffID.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lueStaffID.Properties.Appearance.Options.UseFont = True
        Me.lueStaffID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueStaffID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueStaffID.Properties.NullText = ""
        Me.lueStaffID.Size = New System.Drawing.Size(302, 26)
        Me.lueStaffID.TabIndex = 11
        '
        'lblLabel
        '
        Me.lblLabel.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblLabel.Appearance.Options.UseFont = True
        Me.lblLabel.Appearance.Options.UseForeColor = True
        Me.lblLabel.Location = New System.Drawing.Point(0, 7)
        Me.lblLabel.Name = "lblLabel"
        Me.lblLabel.Size = New System.Drawing.Size(118, 14)
        Me.lblLabel.TabIndex = 12
        Me.lblLabel.Text = "Copy Permission To..."
        '
        'btnAssign
        '
        Me.btnAssign.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAssign.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnAssign.Image = CType(resources.GetObject("btnAssign.Image"), System.Drawing.Image)
        Me.btnAssign.Location = New System.Drawing.Point(0, 71)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(302, 28)
        Me.btnAssign.TabIndex = 13
        Me.btnAssign.Text = "Copy"
        '
        'frmCopyUserAccessRoles
        '
        Me.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 99)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.lueStaffID)
        Me.Controls.Add(Me.lblLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCopyUserAccessRoles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Copy Access Permissions"
        CType(Me.lueStaffID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lueStaffID As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents lblLabel As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAssign As DevExpress.XtraEditors.SimpleButton
End Class
