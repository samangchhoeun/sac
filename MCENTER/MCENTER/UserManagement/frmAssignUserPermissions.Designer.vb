<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssignUserPermissions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssignUserPermissions))
        Me.gvUsers = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcUsers = New DevExpress.XtraGrid.GridControl()
        Me.txtGroup = New DevExpress.XtraEditors.TextEdit()
        Me.btnAssign = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvUsers
        '
        Me.gvUsers.GridControl = Me.gcUsers
        Me.gvUsers.Name = "gvUsers"
        Me.gvUsers.OptionsBehavior.Editable = False
        Me.gvUsers.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvUsers.OptionsSelection.MultiSelect = True
        Me.gvUsers.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvUsers.OptionsView.EnableAppearanceEvenRow = True
        Me.gvUsers.OptionsView.ShowAutoFilterRow = True
        Me.gvUsers.OptionsView.ShowGroupPanel = False
        '
        'gcUsers
        '
        Me.gcUsers.Location = New System.Drawing.Point(11, 48)
        Me.gcUsers.MainView = Me.gvUsers
        Me.gcUsers.Name = "gcUsers"
        Me.gcUsers.Size = New System.Drawing.Size(478, 483)
        Me.gcUsers.TabIndex = 1
        Me.gcUsers.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvUsers})
        '
        'txtGroup
        '
        Me.txtGroup.Location = New System.Drawing.Point(13, 15)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtGroup.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroup.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtGroup.Properties.Appearance.Options.UseBackColor = True
        Me.txtGroup.Properties.Appearance.Options.UseFont = True
        Me.txtGroup.Properties.Appearance.Options.UseForeColor = True
        Me.txtGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtGroup.Properties.ReadOnly = True
        Me.txtGroup.Size = New System.Drawing.Size(476, 20)
        Me.txtGroup.TabIndex = 0
        '
        'btnAssign
        '
        Me.btnAssign.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAssign.Appearance.Options.UseBackColor = True
        Me.btnAssign.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnAssign.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnAssign.Image = CType(resources.GetObject("btnAssign.Image"), System.Drawing.Image)
        Me.btnAssign.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnAssign.Location = New System.Drawing.Point(0, 548)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(501, 30)
        Me.btnAssign.TabIndex = 2
        Me.btnAssign.Text = "Assign"
        '
        'frmAssignUserPermissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 578)
        Me.Controls.Add(Me.txtGroup)
        Me.Controls.Add(Me.gcUsers)
        Me.Controls.Add(Me.btnAssign)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAssignUserPermissions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assign User Accounts"
        CType(Me.gvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvUsers As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcUsers As DevExpress.XtraGrid.GridControl
    Private WithEvents txtGroup As DevExpress.XtraEditors.TextEdit
    Private WithEvents btnAssign As DevExpress.XtraEditors.SimpleButton
End Class
