<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddPhoneCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddPhoneCode))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.txtCity = New DevExpress.XtraEditors.TextEdit()
        Me.txtLabelCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtCode = New DevExpress.XtraEditors.ButtonEdit()
        CType(Me.txtCity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLabelCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCity
        '
        Me.txtCity.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtCity.Location = New System.Drawing.Point(0, 0)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Properties.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.txtCity.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCity.Properties.Appearance.Options.UseBackColor = True
        Me.txtCity.Properties.Appearance.Options.UseFont = True
        Me.txtCity.Properties.Appearance.Options.UseForeColor = True
        Me.txtCity.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtCity.Properties.ReadOnly = True
        Me.txtCity.Size = New System.Drawing.Size(209, 22)
        Me.txtCity.TabIndex = 0
        '
        'txtLabelCode
        '
        Me.txtLabelCode.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtLabelCode.EditValue = "Enter Phone Code"
        Me.txtLabelCode.Location = New System.Drawing.Point(0, 22)
        Me.txtLabelCode.Name = "txtLabelCode"
        Me.txtLabelCode.Properties.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.txtLabelCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLabelCode.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.txtLabelCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtLabelCode.Properties.Appearance.Options.UseFont = True
        Me.txtLabelCode.Properties.Appearance.Options.UseForeColor = True
        Me.txtLabelCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtLabelCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtLabelCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtLabelCode.Properties.ReadOnly = True
        Me.txtLabelCode.Size = New System.Drawing.Size(209, 22)
        Me.txtLabelCode.TabIndex = 4
        '
        'txtCode
        '
        Me.txtCode.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtCode.Location = New System.Drawing.Point(0, 44)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("txtCode.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.txtCode.Size = New System.Drawing.Size(209, 26)
        Me.txtCode.TabIndex = 5
        '
        'frmAddPhoneCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(209, 70)
        Me.Controls.Add(Me.txtLabelCode)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtCode)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddPhoneCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Update Code"
        CType(Me.txtCity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLabelCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtCity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLabelCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCode As DevExpress.XtraEditors.ButtonEdit
End Class
