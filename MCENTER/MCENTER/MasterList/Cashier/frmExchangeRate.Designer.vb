<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExchangeRate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExchangeRate))
        Me.gcDate = New DevExpress.XtraEditors.GroupControl()
        Me.txtRate = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.deNotifyDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gcDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcDate.SuspendLayout()
        CType(Me.txtRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deNotifyDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deNotifyDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcDate
        '
        Me.gcDate.CaptionImage = CType(resources.GetObject("gcDate.CaptionImage"), System.Drawing.Image)
        Me.gcDate.Controls.Add(Me.txtRate)
        Me.gcDate.Controls.Add(Me.LabelControl2)
        Me.gcDate.Controls.Add(Me.deNotifyDate)
        Me.gcDate.Controls.Add(Me.LabelControl1)
        Me.gcDate.Dock = System.Windows.Forms.DockStyle.Top
        Me.gcDate.Location = New System.Drawing.Point(0, 0)
        Me.gcDate.Name = "gcDate"
        Me.gcDate.Size = New System.Drawing.Size(345, 108)
        Me.gcDate.TabIndex = 0
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(130, 72)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRate.Properties.Appearance.ForeColor = System.Drawing.Color.SlateGray
        Me.txtRate.Properties.Appearance.Options.UseFont = True
        Me.txtRate.Properties.Appearance.Options.UseForeColor = True
        Me.txtRate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtRate.Properties.Mask.EditMask = "n2"
        Me.txtRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtRate.Size = New System.Drawing.Size(191, 22)
        Me.txtRate.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(12, 75)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(102, 16)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Exchange Rate $1"
        '
        'deNotifyDate
        '
        Me.deNotifyDate.EditValue = Nothing
        Me.deNotifyDate.Location = New System.Drawing.Point(130, 36)
        Me.deNotifyDate.Name = "deNotifyDate"
        Me.deNotifyDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.deNotifyDate.Properties.Appearance.ForeColor = System.Drawing.Color.SlateGray
        Me.deNotifyDate.Properties.Appearance.Options.UseFont = True
        Me.deNotifyDate.Properties.Appearance.Options.UseForeColor = True
        Me.deNotifyDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deNotifyDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deNotifyDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deNotifyDate.Size = New System.Drawing.Size(191, 22)
        Me.deNotifyDate.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 39)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(62, 16)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Notify Date"
        '
        'btnSave
        '
        Me.btnSave.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSave.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnSave.Appearance.Options.UseBackColor = True
        Me.btnSave.Appearance.Options.UseForeColor = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(130, 110)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(215, 30)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Set Exchange Rate"
        '
        'btnNew
        '
        Me.btnNew.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.btnNew.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnNew.Appearance.Options.UseBackColor = True
        Me.btnNew.Appearance.Options.UseForeColor = True
        Me.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Location = New System.Drawing.Point(0, 110)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(128, 30)
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "Add New"
        '
        'frmExchangeRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 140)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gcDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExchangeRate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Exchange Rate"
        CType(Me.gcDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcDate.ResumeLayout(False)
        Me.gcDate.PerformLayout()
        CType(Me.txtRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deNotifyDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deNotifyDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gcDate As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents deNotifyDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
End Class
