<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainReport))
        Me.crvAttendanceViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvAttendanceViewer
        '
        Me.crvAttendanceViewer.ActiveViewIndex = -1
        Me.crvAttendanceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvAttendanceViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvAttendanceViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvAttendanceViewer.Location = New System.Drawing.Point(0, 0)
        Me.crvAttendanceViewer.Name = "crvAttendanceViewer"
        Me.crvAttendanceViewer.Size = New System.Drawing.Size(996, 694)
        Me.crvAttendanceViewer.TabIndex = 0
        '
        'frmMainReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 694)
        Me.Controls.Add(Me.crvAttendanceViewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMainReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Staff Attedance Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvAttendanceViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
