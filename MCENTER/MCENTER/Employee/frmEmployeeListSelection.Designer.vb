<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmployeeListSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeListSelection))
        Me.meStaffSelection = New DevExpress.XtraEditors.MemoEdit()
        Me.btnAddToList = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.meName = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.meStaffSelection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'meStaffSelection
        '
        Me.meStaffSelection.EditValue = ""
        Me.meStaffSelection.Location = New System.Drawing.Point(10, 28)
        Me.meStaffSelection.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.meStaffSelection.Name = "meStaffSelection"
        Me.meStaffSelection.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.meStaffSelection.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.meStaffSelection.Properties.Appearance.Options.UseFont = True
        Me.meStaffSelection.Properties.Appearance.Options.UseForeColor = True
        Me.meStaffSelection.Size = New System.Drawing.Size(366, 68)
        Me.meStaffSelection.TabIndex = 0
        '
        'btnAddToList
        '
        Me.btnAddToList.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnAddToList.Image = CType(resources.GetObject("btnAddToList.Image"), System.Drawing.Image)
        Me.btnAddToList.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnAddToList.Location = New System.Drawing.Point(9, 242)
        Me.btnAddToList.Name = "btnAddToList"
        Me.btnAddToList.Size = New System.Drawing.Size(74, 25)
        Me.btnAddToList.TabIndex = 3
        Me.btnAddToList.Text = "Apply"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 11)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(89, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Enter Employee ID"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(106, 11)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(231, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "(separates by comma, space, dot or semi-colon)"
        '
        'meName
        '
        Me.meName.Location = New System.Drawing.Point(9, 123)
        Me.meName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.meName.Name = "meName"
        Me.meName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.meName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.meName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.meName.Properties.Appearance.Options.UseBackColor = True
        Me.meName.Properties.Appearance.Options.UseFont = True
        Me.meName.Properties.Appearance.Options.UseForeColor = True
        Me.meName.Properties.ReadOnly = True
        Me.meName.Size = New System.Drawing.Size(366, 108)
        Me.meName.TabIndex = 6
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(10, 105)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(111, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Employee Selection List"
        '
        'btnOK
        '
        Me.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnOK.Location = New System.Drawing.Point(298, 242)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(77, 25)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        '
        'frmEmployeeListSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 277)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.meName)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnAddToList)
        Me.Controls.Add(Me.meStaffSelection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmployeeListSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employee Selection"
        CType(Me.meStaffSelection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents meStaffSelection As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents btnAddToList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents meName As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
End Class
