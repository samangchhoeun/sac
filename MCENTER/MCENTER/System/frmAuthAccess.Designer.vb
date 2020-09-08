<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuthAccess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuthAccess))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.labelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPass = New DevExpress.XtraEditors.ButtonEdit()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.btnExit)
        Me.PanelControl1.Controls.Add(Me.labelControl4)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(262, 29)
        Me.PanelControl1.TabIndex = 38
        '
        'btnExit
        '
        Me.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnExit.Location = New System.Drawing.Point(239, 4)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 42
        Me.btnExit.Text = "Exit"
        '
        'labelControl4
        '
        Me.labelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl4.Appearance.ForeColor = System.Drawing.Color.White
        Me.labelControl4.Appearance.Options.UseFont = True
        Me.labelControl4.Appearance.Options.UseForeColor = True
        Me.labelControl4.Location = New System.Drawing.Point(7, 6)
        Me.labelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.labelControl4.Name = "labelControl4"
        Me.labelControl4.Size = New System.Drawing.Size(155, 16)
        Me.labelControl4.TabIndex = 33
        Me.labelControl4.Text = "Security Authentication"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(0, 46)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Properties.Appearance.Options.UseFont = True
        Me.txtPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtPass.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("txtPass.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.txtPass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(262, 30)
        Me.txtPass.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(262, 5)
        Me.Panel1.TabIndex = 43
        '
        'frmAuthAccess
        '
        Me.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(262, 91)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.txtPass)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAuthAccess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Authorized Access Only"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Private WithEvents labelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPass As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Panel1 As Panel
End Class
