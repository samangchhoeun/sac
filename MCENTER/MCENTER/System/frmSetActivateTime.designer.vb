<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSetActivateTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetActivateTime))
        Me.teSetTime = New DevExpress.XtraEditors.TimeEdit()
        Me.btnSchedule = New DevExpress.XtraEditors.SimpleButton()
        Me.deDate = New DevExpress.XtraEditors.DateEdit()
        Me.chkGetCurDateTime = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.teSetTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGetCurDateTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'teSetTime
        '
        Me.teSetTime.EditValue = New Date(2019, 7, 26, 0, 0, 0, 0)
        Me.teSetTime.Location = New System.Drawing.Point(108, 18)
        Me.teSetTime.Name = "teSetTime"
        Me.teSetTime.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.teSetTime.Properties.Appearance.Options.UseFont = True
        Me.teSetTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.teSetTime.Size = New System.Drawing.Size(100, 22)
        Me.teSetTime.TabIndex = 1
        '
        'btnSchedule
        '
        Me.btnSchedule.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnSchedule.Image = CType(resources.GetObject("btnSchedule.Image"), System.Drawing.Image)
        Me.btnSchedule.Location = New System.Drawing.Point(218, 18)
        Me.btnSchedule.Name = "btnSchedule"
        Me.btnSchedule.Size = New System.Drawing.Size(75, 23)
        Me.btnSchedule.TabIndex = 3
        Me.btnSchedule.Text = "Schedule"
        '
        'deDate
        '
        Me.deDate.EditValue = Nothing
        Me.deDate.Location = New System.Drawing.Point(13, 18)
        Me.deDate.Name = "deDate"
        Me.deDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.deDate.Properties.Appearance.Options.UseFont = True
        Me.deDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDate.Size = New System.Drawing.Size(90, 22)
        Me.deDate.TabIndex = 0
        '
        'chkGetCurDateTime
        '
        Me.chkGetCurDateTime.Location = New System.Drawing.Point(12, 44)
        Me.chkGetCurDateTime.Name = "chkGetCurDateTime"
        Me.chkGetCurDateTime.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.chkGetCurDateTime.Properties.Appearance.Options.UseForeColor = True
        Me.chkGetCurDateTime.Properties.Caption = "Get current date and time"
        Me.chkGetCurDateTime.Size = New System.Drawing.Size(164, 19)
        Me.chkGetCurDateTime.TabIndex = 2
        '
        'frmSetActivateTime
        '
        Me.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 74)
        Me.Controls.Add(Me.chkGetCurDateTime)
        Me.Controls.Add(Me.deDate)
        Me.Controls.Add(Me.btnSchedule)
        Me.Controls.Add(Me.teSetTime)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetActivateTime"
        Me.Text = "Schedule"
        CType(Me.teSetTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGetCurDateTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents teSetTime As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents btnSchedule As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents deDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents chkGetCurDateTime As DevExpress.XtraEditors.CheckEdit
End Class
