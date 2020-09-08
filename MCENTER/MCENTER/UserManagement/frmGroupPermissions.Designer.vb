<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGroupPermissions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGroupPermissions))
        Me.groupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.lueUserGroups = New DevExpress.XtraEditors.LookUpEdit()
        Me.meDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnPermissions = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.gcGroups = New DevExpress.XtraGrid.GridControl()
        Me.gvGroups = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.panelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.txtUpdatedDate = New DevExpress.XtraEditors.TextEdit()
        Me.txtUpdatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.lblUpdatedDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblUpdatedBy = New DevExpress.XtraEditors.LabelControl()
        Me.txtCreatedDate = New DevExpress.XtraEditors.TextEdit()
        Me.txtCreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.lblCreatedDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblCreatedBy = New DevExpress.XtraEditors.LabelControl()
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupControl3.SuspendLayout()
        CType(Me.lueUserGroups.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gcGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl2.SuspendLayout()
        CType(Me.txtUpdatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUpdatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupControl3
        '
        Me.groupControl3.CaptionImage = CType(resources.GetObject("groupControl3.CaptionImage"), System.Drawing.Image)
        Me.groupControl3.Controls.Add(Me.lueUserGroups)
        Me.groupControl3.Controls.Add(Me.meDescription)
        Me.groupControl3.Controls.Add(Me.btnNew)
        Me.groupControl3.Controls.Add(Me.LabelControl1)
        Me.groupControl3.Controls.Add(Me.LabelControl2)
        Me.groupControl3.Controls.Add(Me.btnPermissions)
        Me.groupControl3.Controls.Add(Me.txtNumber)
        Me.groupControl3.Location = New System.Drawing.Point(13, 12)
        Me.groupControl3.Name = "groupControl3"
        Me.groupControl3.Size = New System.Drawing.Size(669, 132)
        Me.groupControl3.TabIndex = 413
        Me.groupControl3.Text = "User Groups"
        '
        'lueUserGroups
        '
        Me.lueUserGroups.Location = New System.Drawing.Point(109, 37)
        Me.lueUserGroups.Name = "lueUserGroups"
        Me.lueUserGroups.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueUserGroups.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueUserGroups.Properties.NullText = ""
        Me.lueUserGroups.Size = New System.Drawing.Size(430, 20)
        Me.lueUserGroups.TabIndex = 0
        '
        'meDescription
        '
        Me.meDescription.Location = New System.Drawing.Point(109, 72)
        Me.meDescription.Name = "meDescription"
        Me.meDescription.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.meDescription.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.meDescription.Properties.Appearance.Options.UseBackColor = True
        Me.meDescription.Properties.Appearance.Options.UseForeColor = True
        Me.meDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.meDescription.Properties.ReadOnly = True
        Me.meDescription.Size = New System.Drawing.Size(430, 41)
        Me.meDescription.TabIndex = 1
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnNew.Location = New System.Drawing.Point(556, 37)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(97, 26)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "New"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(21, 40)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl1.TabIndex = 461
        Me.LabelControl1.Text = "Group Name"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(21, 74)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl2.TabIndex = 437
        Me.LabelControl2.Text = "Description"
        '
        'btnPermissions
        '
        Me.btnPermissions.Enabled = False
        Me.btnPermissions.Image = CType(resources.GetObject("btnPermissions.Image"), System.Drawing.Image)
        Me.btnPermissions.Location = New System.Drawing.Point(556, 85)
        Me.btnPermissions.Name = "btnPermissions"
        Me.btnPermissions.Size = New System.Drawing.Size(97, 28)
        Me.btnPermissions.TabIndex = 3
        Me.btnPermissions.Text = "Permissions"
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = ""
        Me.txtNumber.Location = New System.Drawing.Point(21, 93)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(67, 20)
        Me.txtNumber.TabIndex = 459
        Me.txtNumber.Visible = False
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionImage = CType(resources.GetObject("GroupControl1.CaptionImage"), System.Drawing.Image)
        Me.GroupControl1.Controls.Add(Me.gcGroups)
        Me.GroupControl1.Location = New System.Drawing.Point(13, 158)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(669, 417)
        Me.GroupControl1.TabIndex = 467
        Me.GroupControl1.Text = "Group Permissions"
        '
        'gcGroups
        '
        Me.gcGroups.Location = New System.Drawing.Point(21, 38)
        Me.gcGroups.MainView = Me.gvGroups
        Me.gcGroups.Name = "gcGroups"
        Me.gcGroups.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.gcGroups.Size = New System.Drawing.Size(632, 361)
        Me.gcGroups.TabIndex = 4
        Me.gcGroups.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvGroups})
        '
        'gvGroups
        '
        Me.gvGroups.GridControl = Me.gcGroups
        Me.gvGroups.Name = "gvGroups"
        Me.gvGroups.OptionsBehavior.Editable = False
        Me.gvGroups.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvGroups.OptionsSelection.MultiSelect = True
        Me.gvGroups.OptionsView.EnableAppearanceOddRow = True
        Me.gvGroups.OptionsView.ShowFooter = True
        Me.gvGroups.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'panelControl2
        '
        Me.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl2.Controls.Add(Me.txtUpdatedDate)
        Me.panelControl2.Controls.Add(Me.txtUpdatedBy)
        Me.panelControl2.Controls.Add(Me.lblUpdatedDate)
        Me.panelControl2.Controls.Add(Me.lblUpdatedBy)
        Me.panelControl2.Controls.Add(Me.txtCreatedDate)
        Me.panelControl2.Controls.Add(Me.txtCreatedBy)
        Me.panelControl2.Controls.Add(Me.lblCreatedDate)
        Me.panelControl2.Controls.Add(Me.lblCreatedBy)
        Me.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelControl2.Location = New System.Drawing.Point(0, 590)
        Me.panelControl2.Name = "panelControl2"
        Me.panelControl2.Size = New System.Drawing.Size(695, 54)
        Me.panelControl2.TabIndex = 468
        '
        'txtUpdatedDate
        '
        Me.txtUpdatedDate.Location = New System.Drawing.Point(339, 7)
        Me.txtUpdatedDate.Name = "txtUpdatedDate"
        Me.txtUpdatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtUpdatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtUpdatedDate.Properties.Appearance.Options.UseBackColor = True
        Me.txtUpdatedDate.Properties.Appearance.Options.UseForeColor = True
        Me.txtUpdatedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtUpdatedDate.Size = New System.Drawing.Size(141, 18)
        Me.txtUpdatedDate.TabIndex = 61
        Me.txtUpdatedDate.Visible = False
        '
        'txtUpdatedBy
        '
        Me.txtUpdatedBy.Location = New System.Drawing.Point(89, 7)
        Me.txtUpdatedBy.Name = "txtUpdatedBy"
        Me.txtUpdatedBy.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtUpdatedBy.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtUpdatedBy.Properties.Appearance.Options.UseBackColor = True
        Me.txtUpdatedBy.Properties.Appearance.Options.UseForeColor = True
        Me.txtUpdatedBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtUpdatedBy.Size = New System.Drawing.Size(166, 18)
        Me.txtUpdatedBy.TabIndex = 59
        Me.txtUpdatedBy.Visible = False
        '
        'lblUpdatedDate
        '
        Me.lblUpdatedDate.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.lblUpdatedDate.Appearance.Options.UseForeColor = True
        Me.lblUpdatedDate.Location = New System.Drawing.Point(270, 11)
        Me.lblUpdatedDate.Name = "lblUpdatedDate"
        Me.lblUpdatedDate.Size = New System.Drawing.Size(65, 13)
        Me.lblUpdatedDate.TabIndex = 60
        Me.lblUpdatedDate.Text = "Date Update:"
        Me.lblUpdatedDate.Visible = False
        '
        'lblUpdatedBy
        '
        Me.lblUpdatedBy.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.lblUpdatedBy.Appearance.Options.UseForeColor = True
        Me.lblUpdatedBy.Location = New System.Drawing.Point(23, 11)
        Me.lblUpdatedBy.Name = "lblUpdatedBy"
        Me.lblUpdatedBy.Size = New System.Drawing.Size(64, 13)
        Me.lblUpdatedBy.TabIndex = 58
        Me.lblUpdatedBy.Text = "User Update:"
        Me.lblUpdatedBy.Visible = False
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.Location = New System.Drawing.Point(339, 28)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtCreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtCreatedDate.Properties.Appearance.Options.UseBackColor = True
        Me.txtCreatedDate.Properties.Appearance.Options.UseForeColor = True
        Me.txtCreatedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtCreatedDate.Size = New System.Drawing.Size(141, 18)
        Me.txtCreatedDate.TabIndex = 57
        Me.txtCreatedDate.Visible = False
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.Location = New System.Drawing.Point(89, 28)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtCreatedBy.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtCreatedBy.Properties.Appearance.Options.UseBackColor = True
        Me.txtCreatedBy.Properties.Appearance.Options.UseForeColor = True
        Me.txtCreatedBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtCreatedBy.Size = New System.Drawing.Size(166, 18)
        Me.txtCreatedBy.TabIndex = 55
        Me.txtCreatedBy.Visible = False
        '
        'lblCreatedDate
        '
        Me.lblCreatedDate.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.lblCreatedDate.Appearance.Options.UseForeColor = True
        Me.lblCreatedDate.Location = New System.Drawing.Point(269, 30)
        Me.lblCreatedDate.Name = "lblCreatedDate"
        Me.lblCreatedDate.Size = New System.Drawing.Size(63, 13)
        Me.lblCreatedDate.TabIndex = 56
        Me.lblCreatedDate.Text = "Date Create:"
        Me.lblCreatedDate.Visible = False
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.lblCreatedBy.Appearance.Options.UseForeColor = True
        Me.lblCreatedBy.Location = New System.Drawing.Point(23, 30)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(62, 13)
        Me.lblCreatedBy.TabIndex = 54
        Me.lblCreatedBy.Text = "User Create:"
        Me.lblCreatedBy.Visible = False
        '
        'frmGroupPermissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(695, 644)
        Me.Controls.Add(Me.panelControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.groupControl3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGroupPermissions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage Group Permissions"
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupControl3.ResumeLayout(False)
        Me.groupControl3.PerformLayout()
        CType(Me.lueUserGroups.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.gcGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl2.ResumeLayout(False)
        Me.panelControl2.PerformLayout()
        CType(Me.txtUpdatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUpdatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents groupControl3 As DevExpress.XtraEditors.GroupControl
    Private WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnPermissions As DevExpress.XtraEditors.SimpleButton
    Private WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents meDescription As DevExpress.XtraEditors.MemoEdit
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lueUserGroups As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcGroups As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvGroups As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Private WithEvents panelControl2 As DevExpress.XtraEditors.PanelControl
    Private WithEvents txtUpdatedDate As DevExpress.XtraEditors.TextEdit
    Private WithEvents txtUpdatedBy As DevExpress.XtraEditors.TextEdit
    Private WithEvents lblUpdatedDate As DevExpress.XtraEditors.LabelControl
    Private WithEvents lblUpdatedBy As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtCreatedDate As DevExpress.XtraEditors.TextEdit
    Private WithEvents txtCreatedBy As DevExpress.XtraEditors.TextEdit
    Private WithEvents lblCreatedDate As DevExpress.XtraEditors.LabelControl
    Private WithEvents lblCreatedBy As DevExpress.XtraEditors.LabelControl
End Class
