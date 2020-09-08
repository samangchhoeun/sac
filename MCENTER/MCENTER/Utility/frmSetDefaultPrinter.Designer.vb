<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetDefaultPrinter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetDefaultPrinter))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.luePrinterType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.seNumCopies = New DevExpress.XtraEditors.SpinEdit()
        Me.luePaperSize = New DevExpress.XtraEditors.LookUpEdit()
        Me.lueOrientation = New DevExpress.XtraEditors.LookUpEdit()
        Me.luePrinter = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.luePrinterType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seNumCopies.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.luePaperSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueOrientation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.luePrinter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.luePrinterType)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.seNumCopies)
        Me.GroupControl1.Controls.Add(Me.luePaperSize)
        Me.GroupControl1.Controls.Add(Me.lueOrientation)
        Me.GroupControl1.Controls.Add(Me.luePrinter)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(540, 138)
        Me.GroupControl1.TabIndex = 0
        '
        'luePrinterType
        '
        Me.luePrinterType.Location = New System.Drawing.Point(96, 66)
        Me.luePrinterType.Name = "luePrinterType"
        Me.luePrinterType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.luePrinterType.Properties.Appearance.ForeColor = System.Drawing.Color.SlateGray
        Me.luePrinterType.Properties.Appearance.Options.UseFont = True
        Me.luePrinterType.Properties.Appearance.Options.UseForeColor = True
        Me.luePrinterType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.luePrinterType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.luePrinterType.Properties.NullText = ""
        Me.luePrinterType.Size = New System.Drawing.Size(171, 22)
        Me.luePrinterType.TabIndex = 1
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Location = New System.Drawing.Point(10, 69)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(70, 16)
        Me.LabelControl5.TabIndex = 8
        Me.LabelControl5.Text = "Printer Type"
        '
        'seNumCopies
        '
        Me.seNumCopies.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.seNumCopies.Location = New System.Drawing.Point(389, 100)
        Me.seNumCopies.Name = "seNumCopies"
        Me.seNumCopies.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seNumCopies.Properties.Appearance.ForeColor = System.Drawing.Color.SlateGray
        Me.seNumCopies.Properties.Appearance.Options.UseFont = True
        Me.seNumCopies.Properties.Appearance.Options.UseForeColor = True
        Me.seNumCopies.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.seNumCopies.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.seNumCopies.Properties.MaxValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.seNumCopies.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.seNumCopies.Properties.NullText = "1"
        Me.seNumCopies.Size = New System.Drawing.Size(138, 22)
        Me.seNumCopies.TabIndex = 4
        '
        'luePaperSize
        '
        Me.luePaperSize.Location = New System.Drawing.Point(389, 66)
        Me.luePaperSize.Name = "luePaperSize"
        Me.luePaperSize.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.luePaperSize.Properties.Appearance.ForeColor = System.Drawing.Color.SlateGray
        Me.luePaperSize.Properties.Appearance.Options.UseFont = True
        Me.luePaperSize.Properties.Appearance.Options.UseForeColor = True
        Me.luePaperSize.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.luePaperSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.luePaperSize.Properties.NullText = ""
        Me.luePaperSize.Size = New System.Drawing.Size(138, 22)
        Me.luePaperSize.TabIndex = 3
        '
        'lueOrientation
        '
        Me.lueOrientation.Location = New System.Drawing.Point(96, 101)
        Me.lueOrientation.Name = "lueOrientation"
        Me.lueOrientation.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lueOrientation.Properties.Appearance.ForeColor = System.Drawing.Color.SlateGray
        Me.lueOrientation.Properties.Appearance.Options.UseFont = True
        Me.lueOrientation.Properties.Appearance.Options.UseForeColor = True
        Me.lueOrientation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueOrientation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueOrientation.Properties.NullText = ""
        Me.lueOrientation.Size = New System.Drawing.Size(171, 22)
        Me.lueOrientation.TabIndex = 2
        '
        'luePrinter
        '
        Me.luePrinter.Location = New System.Drawing.Point(96, 32)
        Me.luePrinter.Name = "luePrinter"
        Me.luePrinter.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.luePrinter.Properties.Appearance.ForeColor = System.Drawing.Color.SlateGray
        Me.luePrinter.Properties.Appearance.Options.UseFont = True
        Me.luePrinter.Properties.Appearance.Options.UseForeColor = True
        Me.luePrinter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.luePrinter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.luePrinter.Properties.NullText = ""
        Me.luePrinter.Size = New System.Drawing.Size(431, 22)
        Me.luePrinter.TabIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Location = New System.Drawing.Point(279, 70)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(61, 16)
        Me.LabelControl4.TabIndex = 3
        Me.LabelControl4.Text = "Paper Size"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(10, 102)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(63, 16)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Orientation"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(279, 102)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(100, 16)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Number of copies"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(10, 35)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(77, 16)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Select Printer"
        '
        'btnSave
        '
        Me.btnSave.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSave.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnSave.Appearance.Options.UseBackColor = True
        Me.btnSave.Appearance.Options.UseForeColor = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(0, 139)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(540, 32)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Set as Default"
        '
        'frmSetDefaultPrinter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 171)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetDefaultPrinter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Set Default Printer"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.luePrinterType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seNumCopies.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.luePaperSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueOrientation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.luePrinter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents seNumCopies As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents luePaperSize As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lueOrientation As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents luePrinter As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents luePrinterType As DevExpress.XtraEditors.LookUpEdit
End Class
