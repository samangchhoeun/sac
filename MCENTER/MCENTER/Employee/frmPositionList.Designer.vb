<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPositionList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPositionList))
        Me.gvData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcData = New DevExpress.XtraGrid.GridControl()
        Me.btnGo = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvData
        '
        Me.gvData.GridControl = Me.gcData
        Me.gvData.Name = "gvData"
        Me.gvData.OptionsBehavior.Editable = False
        Me.gvData.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvData.OptionsSelection.MultiSelect = True
        Me.gvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvData.OptionsView.EnableAppearanceEvenRow = True
        Me.gvData.OptionsView.ShowAutoFilterRow = True
        Me.gvData.OptionsView.ShowFooter = True
        Me.gvData.OptionsView.ShowGroupPanel = False
        '
        'gcData
        '
        Me.gcData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcData.Location = New System.Drawing.Point(0, 0)
        Me.gcData.MainView = Me.gvData
        Me.gcData.Name = "gcData"
        Me.gcData.Size = New System.Drawing.Size(700, 428)
        Me.gcData.TabIndex = 2
        Me.gcData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvData})
        '
        'btnGo
        '
        Me.btnGo.Appearance.BackColor = System.Drawing.Color.SkyBlue
        Me.btnGo.Appearance.Options.UseBackColor = True
        Me.btnGo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnGo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.Location = New System.Drawing.Point(0, 428)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(700, 34)
        Me.btnGo.TabIndex = 3
        Me.btnGo.Text = "GO"
        '
        'frmPositionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 462)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.gcData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmPositionList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select a position"
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcData As DevExpress.XtraGrid.GridControl
    Friend WithEvents btnGo As DevExpress.XtraEditors.SimpleButton
End Class
