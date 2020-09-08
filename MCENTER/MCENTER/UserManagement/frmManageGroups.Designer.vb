<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageGroups
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageGroups))
        Me.cmsRightMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewPermissionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtGroup = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.meDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.cmsRightMenu.SuspendLayout()
        CType(Me.txtGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmsRightMenu
        '
        Me.cmsRightMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsRightMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewPermissionsToolStripMenuItem})
        Me.cmsRightMenu.Name = "ContextMenuStrip1"
        Me.cmsRightMenu.Size = New System.Drawing.Size(166, 26)
        '
        'ViewPermissionsToolStripMenuItem
        '
        Me.ViewPermissionsToolStripMenuItem.Name = "ViewPermissionsToolStripMenuItem"
        Me.ViewPermissionsToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ViewPermissionsToolStripMenuItem.Text = "View Permissions"
        '
        'txtGroup
        '
        Me.txtGroup.Location = New System.Drawing.Point(92, 51)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtGroup.Size = New System.Drawing.Size(353, 20)
        Me.txtGroup.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(12, 94)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl2.TabIndex = 437
        Me.LabelControl2.Text = "Description"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(80, 54)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl3.TabIndex = 459
        Me.LabelControl3.Text = "*"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 54)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl1.TabIndex = 461
        Me.LabelControl1.Text = "Group Name"
        '
        'meDescription
        '
        Me.meDescription.Location = New System.Drawing.Point(92, 84)
        Me.meDescription.Name = "meDescription"
        Me.meDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meDescription.Size = New System.Drawing.Size(353, 61)
        Me.meDescription.TabIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(12, 21)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl4.TabIndex = 466
        Me.LabelControl4.Text = "Group ID"
        '
        'btnNew
        '
        Me.btnNew.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.btnNew.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnNew.Appearance.Options.UseBackColor = True
        Me.btnNew.Appearance.Options.UseForeColor = True
        Me.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(1, 169)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(218, 34)
        Me.btnNew.TabIndex = 5
        Me.btnNew.Text = "Add New"
        '
        'btnSave
        '
        Me.btnSave.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSave.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnSave.Appearance.Options.UseBackColor = True
        Me.btnSave.Appearance.Options.UseForeColor = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(220, 169)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(239, 34)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Create Group"
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = "***"
        Me.txtNumber.Location = New System.Drawing.Point(92, 18)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumber.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.txtNumber.Properties.Appearance.Options.UseBackColor = True
        Me.txtNumber.Properties.Appearance.Options.UseForeColor = True
        Me.txtNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtNumber.Size = New System.Drawing.Size(353, 20)
        Me.txtNumber.TabIndex = 6
        '
        'frmManageGroups
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(461, 204)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtGroup)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.meDescription)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageGroups"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage User Groups"
        Me.cmsRightMenu.ResumeLayout(False)
        CType(Me.txtGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtGroup As DevExpress.XtraEditors.TextEdit
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents meDescription As DevExpress.XtraEditors.MemoEdit
    Private WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmsRightMenu As System.Windows.Forms.ContextMenuStrip
    Private WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ViewPermissionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
