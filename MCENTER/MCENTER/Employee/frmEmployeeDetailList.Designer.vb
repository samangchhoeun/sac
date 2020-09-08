<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmployeeDetailList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeDetailList))
        Me.gcStaffDetailsList = New DevExpress.XtraGrid.GridControl()
        Me.gvStaffDetailsList = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.gcStaffDetailsList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvStaffDetailsList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcStaffDetailsList
        '
        Me.gcStaffDetailsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcStaffDetailsList.Location = New System.Drawing.Point(0, 0)
        Me.gcStaffDetailsList.MainView = Me.gvStaffDetailsList
        Me.gcStaffDetailsList.Name = "gcStaffDetailsList"
        Me.gcStaffDetailsList.Size = New System.Drawing.Size(947, 517)
        Me.gcStaffDetailsList.TabIndex = 0
        Me.gcStaffDetailsList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvStaffDetailsList})
        '
        'gvStaffDetailsList
        '
        Me.gvStaffDetailsList.GridControl = Me.gcStaffDetailsList
        Me.gvStaffDetailsList.Name = "gvStaffDetailsList"
        Me.gvStaffDetailsList.OptionsBehavior.Editable = False
        Me.gvStaffDetailsList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvStaffDetailsList.OptionsView.EnableAppearanceEvenRow = True
        Me.gvStaffDetailsList.OptionsView.ShowAutoFilterRow = True
        Me.gvStaffDetailsList.OptionsView.ShowFooter = True
        Me.gvStaffDetailsList.OptionsView.ShowGroupPanel = False
        '
        'frmStaffList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 517)
        Me.Controls.Add(Me.gcStaffDetailsList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmStaffList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employee Bank"
        CType(Me.gcStaffDetailsList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvStaffDetailsList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gcStaffDetailsList As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvStaffDetailsList As DevExpress.XtraGrid.Views.Grid.GridView
End Class
