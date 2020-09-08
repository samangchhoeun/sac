<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSearchInvoiceStockIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchInvoiceStockIn))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.txtSID = New DevExpress.XtraEditors.ButtonEdit()
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSID
        '
        Me.txtSID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSID.Location = New System.Drawing.Point(0, 0)
        Me.txtSID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSID.Name = "txtSID"
        Me.txtSID.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.txtSID.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.txtSID.Properties.Appearance.Options.UseFont = True
        Me.txtSID.Properties.Appearance.Options.UseForeColor = True
        Me.txtSID.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtSID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("txtSID.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.txtSID.Properties.MaxLength = 10
        Me.txtSID.Size = New System.Drawing.Size(246, 30)
        Me.txtSID.TabIndex = 0
        '
        'frmSearchInvoiceStockIn
        '
        Me.Appearance.BackColor = System.Drawing.Color.SlateGray
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 30)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtSID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchInvoiceStockIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Enter Invoice No"
        CType(Me.txtSID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtSID As DevExpress.XtraEditors.ButtonEdit
End Class
