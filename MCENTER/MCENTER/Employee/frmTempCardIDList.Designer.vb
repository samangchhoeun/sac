<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTempCardIDList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTempCardIDList))
        Me.gcTempIDList = New DevExpress.XtraGrid.GridControl()
        Me.gvTempIDList = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.gcTempIDList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvTempIDList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcTempIDList
        '
        Me.gcTempIDList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcTempIDList.Location = New System.Drawing.Point(0, 0)
        Me.gcTempIDList.MainView = Me.gvTempIDList
        Me.gcTempIDList.Name = "gcTempIDList"
        Me.gcTempIDList.Size = New System.Drawing.Size(143, 349)
        Me.gcTempIDList.TabIndex = 1
        Me.gcTempIDList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvTempIDList})
        '
        'gvTempIDList
        '
        Me.gvTempIDList.GridControl = Me.gcTempIDList
        Me.gvTempIDList.Name = "gvTempIDList"
        Me.gvTempIDList.OptionsBehavior.Editable = False
        Me.gvTempIDList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvTempIDList.OptionsView.EnableAppearanceEvenRow = True
        Me.gvTempIDList.OptionsView.ShowAutoFilterRow = True
        Me.gvTempIDList.OptionsView.ShowGroupPanel = False
        '
        'frmTempCardIDList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(143, 349)
        Me.Controls.Add(Me.gcTempIDList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTempCardIDList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Temporary ID"
        CType(Me.gcTempIDList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvTempIDList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gcTempIDList As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvTempIDList As DevExpress.XtraGrid.Views.Grid.GridView
End Class
