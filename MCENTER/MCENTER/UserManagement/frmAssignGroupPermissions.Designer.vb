<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAssignGroupPermissions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssignGroupPermissions))
        Me.gvGroups = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcGroups = New DevExpress.XtraGrid.GridControl()
        Me.txtGroup = New DevExpress.XtraEditors.TextEdit()
        Me.btnAssign = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gvGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvGroups
        '
        Me.gvGroups.GridControl = Me.gcGroups
        Me.gvGroups.Name = "gvGroups"
        Me.gvGroups.OptionsBehavior.Editable = False
        Me.gvGroups.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvGroups.OptionsSelection.MultiSelect = True
        Me.gvGroups.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvGroups.OptionsView.EnableAppearanceEvenRow = True
        Me.gvGroups.OptionsView.ShowAutoFilterRow = True
        Me.gvGroups.OptionsView.ShowGroupPanel = False
        '
        'gcGroups
        '
        Me.gcGroups.Location = New System.Drawing.Point(11, 46)
        Me.gcGroups.MainView = Me.gvGroups
        Me.gcGroups.Name = "gcGroups"
        Me.gcGroups.Size = New System.Drawing.Size(577, 500)
        Me.gcGroups.TabIndex = 1
        Me.gcGroups.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvGroups})
        '
        'txtGroup
        '
        Me.txtGroup.Location = New System.Drawing.Point(12, 14)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtGroup.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroup.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtGroup.Properties.Appearance.Options.UseBackColor = True
        Me.txtGroup.Properties.Appearance.Options.UseFont = True
        Me.txtGroup.Properties.Appearance.Options.UseForeColor = True
        Me.txtGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtGroup.Properties.ReadOnly = True
        Me.txtGroup.Size = New System.Drawing.Size(576, 20)
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
        Me.btnAssign.Location = New System.Drawing.Point(0, 565)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(600, 30)
        Me.btnAssign.TabIndex = 2
        Me.btnAssign.Text = "Assign"
        '
        'frmAssignGroupPermissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(600, 595)
        Me.Controls.Add(Me.txtGroup)
        Me.Controls.Add(Me.gcGroups)
        Me.Controls.Add(Me.btnAssign)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAssignGroupPermissions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assign Group Permissions"
        CType(Me.gvGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvGroups As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcGroups As DevExpress.XtraGrid.GridControl
    Private WithEvents btnAssign As DevExpress.XtraEditors.SimpleButton
    Private WithEvents txtGroup As DevExpress.XtraEditors.TextEdit
End Class
