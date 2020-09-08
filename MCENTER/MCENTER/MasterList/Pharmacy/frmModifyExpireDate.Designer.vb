<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModifyExpireDate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModifyExpireDate))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtInvoiceNo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMedCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtBrandName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtQty = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSOH = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.deExpiredDate = New DevExpress.XtraEditors.DateEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtInvoiceNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMedCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBrandName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSOH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deExpiredDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deExpiredDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Invoice No"
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(83, 13)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan
        Me.txtInvoiceNo.Properties.Appearance.Options.UseBackColor = True
        Me.txtInvoiceNo.Properties.Appearance.Options.UseTextOptions = True
        Me.txtInvoiceNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtInvoiceNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtInvoiceNo.Size = New System.Drawing.Size(156, 20)
        Me.txtInvoiceNo.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(255, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Medication Code"
        '
        'txtMedCode
        '
        Me.txtMedCode.Location = New System.Drawing.Point(344, 13)
        Me.txtMedCode.Name = "txtMedCode"
        Me.txtMedCode.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan
        Me.txtMedCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtMedCode.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMedCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtMedCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtMedCode.Size = New System.Drawing.Size(137, 20)
        Me.txtMedCode.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 48)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Brand Name"
        '
        'txtBrandName
        '
        Me.txtBrandName.Location = New System.Drawing.Point(83, 44)
        Me.txtBrandName.Name = "txtBrandName"
        Me.txtBrandName.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan
        Me.txtBrandName.Properties.Appearance.Options.UseBackColor = True
        Me.txtBrandName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtBrandName.Size = New System.Drawing.Size(398, 20)
        Me.txtBrandName.TabIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 82)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl4.TabIndex = 2
        Me.LabelControl4.Text = "Quantity"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(83, 78)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan
        Me.txtQty.Properties.Appearance.Options.UseBackColor = True
        Me.txtQty.Properties.Appearance.Options.UseTextOptions = True
        Me.txtQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtQty.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtQty.Size = New System.Drawing.Size(156, 20)
        Me.txtQty.TabIndex = 1
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(255, 82)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl5.TabIndex = 2
        Me.LabelControl5.Text = "Stock On Hand"
        '
        'txtSOH
        '
        Me.txtSOH.Location = New System.Drawing.Point(344, 78)
        Me.txtSOH.Name = "txtSOH"
        Me.txtSOH.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan
        Me.txtSOH.Properties.Appearance.Options.UseBackColor = True
        Me.txtSOH.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSOH.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtSOH.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtSOH.Size = New System.Drawing.Size(137, 20)
        Me.txtSOH.TabIndex = 1
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(11, 120)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl6.TabIndex = 2
        Me.LabelControl6.Text = "Expired Date"
        '
        'deExpiredDate
        '
        Me.deExpiredDate.EditValue = Nothing
        Me.deExpiredDate.Location = New System.Drawing.Point(83, 116)
        Me.deExpiredDate.Name = "deExpiredDate"
        Me.deExpiredDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deExpiredDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deExpiredDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deExpiredDate.Size = New System.Drawing.Size(398, 20)
        Me.deExpiredDate.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Appearance.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnSave.Appearance.Options.UseBackColor = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(0, 152)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(496, 30)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save Change"
        '
        'frmModifyExpireDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 182)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.deExpiredDate)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtSOH)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.txtBrandName)
        Me.Controls.Add(Me.txtMedCode)
        Me.Controls.Add(Me.txtInvoiceNo)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmModifyExpireDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modify Expired Date"
        CType(Me.txtInvoiceNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMedCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBrandName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSOH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deExpiredDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deExpiredDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtInvoiceNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMedCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtBrandName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSOH As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents deExpiredDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
