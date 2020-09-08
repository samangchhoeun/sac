<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssignAccountType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssignAccountType))
        Me.lueAccountType = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnAssign = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.lueAccountType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lueAccountType
        '
        Me.lueAccountType.Location = New System.Drawing.Point(0, 12)
        Me.lueAccountType.Name = "lueAccountType"
        Me.lueAccountType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lueAccountType.Properties.Appearance.Options.UseFont = True
        Me.lueAccountType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueAccountType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueAccountType.Properties.NullText = ""
        Me.lueAccountType.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.lueAccountType.Size = New System.Drawing.Size(263, 26)
        Me.lueAccountType.TabIndex = 6
        '
        'btnAssign
        '
        Me.btnAssign.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAssign.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnAssign.Image = CType(resources.GetObject("btnAssign.Image"), System.Drawing.Image)
        Me.btnAssign.Location = New System.Drawing.Point(0, 51)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(263, 30)
        Me.btnAssign.TabIndex = 8
        Me.btnAssign.Text = "Assign"
        '
        'frmAssignAccountType
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 81)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.lueAccountType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAssignAccountType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assign User Role"
        CType(Me.lueAccountType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lueAccountType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnAssign As DevExpress.XtraEditors.SimpleButton
End Class
