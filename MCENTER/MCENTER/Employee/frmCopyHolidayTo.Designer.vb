<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyHolidayTo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCopyHolidayTo))
        Me.deNewHolday = New DevExpress.XtraEditors.DateEdit()
        Me.btnCopy = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.deNewHolday.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deNewHolday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'deNewHolday
        '
        Me.deNewHolday.Dock = System.Windows.Forms.DockStyle.Top
        Me.deNewHolday.EditValue = Nothing
        Me.deNewHolday.Location = New System.Drawing.Point(0, 0)
        Me.deNewHolday.Name = "deNewHolday"
        Me.deNewHolday.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deNewHolday.Properties.Appearance.Options.UseFont = True
        Me.deNewHolday.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deNewHolday.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deNewHolday.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deNewHolday.Properties.DisplayFormat.FormatString = "yyyy"
        Me.deNewHolday.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.deNewHolday.Properties.EditFormat.FormatString = "yyyy"
        Me.deNewHolday.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.deNewHolday.Properties.Mask.EditMask = "yyyy"
        Me.deNewHolday.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView
        Me.deNewHolday.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.deNewHolday.Size = New System.Drawing.Size(278, 30)
        Me.deNewHolday.TabIndex = 1
        '
        'btnCopy
        '
        Me.btnCopy.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnCopy.Appearance.Options.UseBackColor = True
        Me.btnCopy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCopy.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnCopy.Image = CType(resources.GetObject("btnCopy.Image"), System.Drawing.Image)
        Me.btnCopy.Location = New System.Drawing.Point(0, 29)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(278, 30)
        Me.btnCopy.TabIndex = 2
        Me.btnCopy.Text = "COPY"
        '
        'frmCopyHolidayTo
        '
        Me.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 59)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.deNewHolday)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCopyHolidayTo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Copy To..."
        CType(Me.deNewHolday.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deNewHolday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents deNewHolday As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnCopy As DevExpress.XtraEditors.SimpleButton
End Class
