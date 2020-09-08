<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientReminderAlert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientReminderAlert))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.meReminder = New DevExpress.XtraEditors.MemoEdit()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meReminder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(11, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(56, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'meReminder
        '
        Me.meReminder.Location = New System.Drawing.Point(74, 14)
        Me.meReminder.Name = "meReminder"
        Me.meReminder.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.meReminder.Properties.Appearance.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.meReminder.Properties.Appearance.Options.UseFont = True
        Me.meReminder.Properties.Appearance.Options.UseForeColor = True
        Me.meReminder.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meReminder.Properties.ReadOnly = True
        Me.meReminder.Size = New System.Drawing.Size(341, 89)
        Me.meReminder.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.btnDelete.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Appearance.Options.UseBackColor = True
        Me.btnDelete.Appearance.Options.UseForeColor = True
        Me.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(74, 116)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(341, 32)
        Me.btnDelete.TabIndex = 0
        Me.btnDelete.Text = "DELETE"
        '
        'frmPatientReminderAlert
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 160)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.meReminder)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPatientReminderAlert"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reminder"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meReminder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents meReminder As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
End Class
