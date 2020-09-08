<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchMedicationDispensary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchMedicationDispensary))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lueSearchOption = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCode = New DevExpress.XtraEditors.SearchControl()
        CType(Me.lueSearchOption.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 14)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Search By"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(12, 53)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(28, 14)
        Me.LabelControl2.TabIndex = 0
        Me.LabelControl2.Text = "Code"
        '
        'lueSearchOption
        '
        Me.lueSearchOption.Location = New System.Drawing.Point(82, 15)
        Me.lueSearchOption.Name = "lueSearchOption"
        Me.lueSearchOption.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lueSearchOption.Properties.Appearance.Options.UseFont = True
        Me.lueSearchOption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueSearchOption.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueSearchOption.Properties.NullText = ""
        Me.lueSearchOption.Size = New System.Drawing.Size(191, 22)
        Me.lueSearchOption.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(281, 14)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 25)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        '
        'btnBrowse
        '
        Me.btnBrowse.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(281, 50)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(90, 25)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "Browse..."
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(82, 51)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.txtCode.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Properties.Appearance.Options.UseForeColor = True
        Me.txtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.txtCode.Properties.NullValuePrompt = "Enter Code..."
        Me.txtCode.Size = New System.Drawing.Size(191, 22)
        Me.txtCode.TabIndex = 0
        '
        'frmSearchMedicationDispensary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 89)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.lueSearchOption)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSearchMedicationDispensary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search"
        CType(Me.lueSearchOption.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lueSearchOption As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCode As DevExpress.XtraEditors.SearchControl
End Class
