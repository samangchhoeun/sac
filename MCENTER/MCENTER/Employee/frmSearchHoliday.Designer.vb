<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSearchHoliday
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchHoliday))
        Me.rgHoliday = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.deSEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.deSStartDate = New DevExpress.XtraEditors.DateEdit()
        CType(Me.rgHoliday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deSEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deSEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deSStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deSStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rgHoliday
        '
        Me.rgHoliday.EditValue = CType(2, Short)
        Me.rgHoliday.Location = New System.Drawing.Point(10, 11)
        Me.rgHoliday.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rgHoliday.Name = "rgHoliday"
        Me.rgHoliday.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.rgHoliday.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgHoliday.Properties.Appearance.Options.UseBackColor = True
        Me.rgHoliday.Properties.Appearance.Options.UseFont = True
        Me.rgHoliday.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.rgHoliday.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(CType(0, Short), "Custom"), New DevExpress.XtraEditors.Controls.RadioGroupItem(CType(1, Short), "Current Year"), New DevExpress.XtraEditors.Controls.RadioGroupItem(CType(2, Short), "Upcoming")})
        Me.rgHoliday.Size = New System.Drawing.Size(331, 28)
        Me.rgHoliday.TabIndex = 465
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.White
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Appearance.Options.UseForeColor = True
        Me.LabelControl5.Location = New System.Drawing.Point(166, 55)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(15, 16)
        Me.LabelControl5.TabIndex = 471
        Me.LabelControl5.Text = "To"
        '
        'btnSearch
        '
        Me.btnSearch.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSearch.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Appearance.Options.UseBackColor = True
        Me.btnSearch.Appearance.Options.UseFont = True
        Me.btnSearch.Appearance.Options.UseForeColor = True
        Me.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(0, 92)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(350, 30)
        Me.btnSearch.TabIndex = 468
        Me.btnSearch.Text = "Search "
        '
        'deSEndDate
        '
        Me.deSEndDate.EditValue = Nothing
        Me.deSEndDate.Enabled = False
        Me.deSEndDate.Location = New System.Drawing.Point(190, 53)
        Me.deSEndDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deSEndDate.Name = "deSEndDate"
        Me.deSEndDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deSEndDate.Properties.Appearance.Options.UseFont = True
        Me.deSEndDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deSEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deSEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deSEndDate.Size = New System.Drawing.Size(151, 22)
        Me.deSEndDate.TabIndex = 467
        '
        'deSStartDate
        '
        Me.deSStartDate.EditValue = Nothing
        Me.deSStartDate.Enabled = False
        Me.deSStartDate.Location = New System.Drawing.Point(10, 53)
        Me.deSStartDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deSStartDate.Name = "deSStartDate"
        Me.deSStartDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deSStartDate.Properties.Appearance.Options.UseFont = True
        Me.deSStartDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deSStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deSStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deSStartDate.Size = New System.Drawing.Size(151, 22)
        Me.deSStartDate.TabIndex = 466
        '
        'frmSearchHoliday
        '
        Me.AcceptButton = Me.btnSearch
        Me.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 122)
        Me.Controls.Add(Me.rgHoliday)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.deSEndDate)
        Me.Controls.Add(Me.deSStartDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchHoliday"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search Options"
        CType(Me.rgHoliday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deSEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deSEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deSStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deSStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rgHoliday As DevExpress.XtraEditors.RadioGroup
    Private WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents deSEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deSStartDate As DevExpress.XtraEditors.DateEdit
End Class
