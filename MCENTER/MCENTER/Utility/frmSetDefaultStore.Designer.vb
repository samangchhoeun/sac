<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetDefaultStore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetDefaultStore))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lueBuilding = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lueClinic = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.pcMessage = New DevExpress.XtraEditors.PanelControl()
        Me.lblMsg = New DevExpress.XtraEditors.LabelControl()
        Me.lcClickHere = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.lueBuilding.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueClinic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcMessage.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.lueBuilding)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.lueClinic)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(339, 105)
        Me.GroupControl1.TabIndex = 0
        '
        'lueBuilding
        '
        Me.lueBuilding.Location = New System.Drawing.Point(72, 69)
        Me.lueBuilding.Name = "lueBuilding"
        Me.lueBuilding.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lueBuilding.Properties.Appearance.ForeColor = System.Drawing.Color.SlateGray
        Me.lueBuilding.Properties.Appearance.Options.UseFont = True
        Me.lueBuilding.Properties.Appearance.Options.UseForeColor = True
        Me.lueBuilding.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueBuilding.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueBuilding.Properties.NullText = ""
        Me.lueBuilding.Size = New System.Drawing.Size(250, 22)
        Me.lueBuilding.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(12, 72)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 16)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Building"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 36)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(30, 16)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Clinic"
        '
        'lueClinic
        '
        Me.lueClinic.Location = New System.Drawing.Point(72, 33)
        Me.lueClinic.Name = "lueClinic"
        Me.lueClinic.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lueClinic.Properties.Appearance.ForeColor = System.Drawing.Color.SlateGray
        Me.lueClinic.Properties.Appearance.Options.UseFont = True
        Me.lueClinic.Properties.Appearance.Options.UseForeColor = True
        Me.lueClinic.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lueClinic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueClinic.Properties.NullText = ""
        Me.lueClinic.Size = New System.Drawing.Size(250, 22)
        Me.lueClinic.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSave.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnSave.Appearance.Options.UseBackColor = True
        Me.btnSave.Appearance.Options.UseForeColor = True
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(0, 106)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(339, 32)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Set as Default"
        '
        'pcMessage
        '
        Me.pcMessage.Controls.Add(Me.lcClickHere)
        Me.pcMessage.Controls.Add(Me.lblMsg)
        Me.pcMessage.Location = New System.Drawing.Point(0, 0)
        Me.pcMessage.Name = "pcMessage"
        Me.pcMessage.Size = New System.Drawing.Size(339, 138)
        Me.pcMessage.TabIndex = 4
        '
        'lblMsg
        '
        Me.lblMsg.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Appearance.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblMsg.Appearance.Options.UseFont = True
        Me.lblMsg.Appearance.Options.UseForeColor = True
        Me.lblMsg.Location = New System.Drawing.Point(19, 41)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(295, 18)
        Me.lblMsg.TabIndex = 0
        Me.lblMsg.Text = "Please select default clinic and building"
        '
        'lcClickHere
        '
        Me.lcClickHere.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcClickHere.Appearance.ForeColor = System.Drawing.Color.Crimson
        Me.lcClickHere.Appearance.Options.UseFont = True
        Me.lcClickHere.Appearance.Options.UseForeColor = True
        Me.lcClickHere.Location = New System.Drawing.Point(130, 77)
        Me.lcClickHere.Name = "lcClickHere"
        Me.lcClickHere.Size = New System.Drawing.Size(75, 18)
        Me.lcClickHere.TabIndex = 1
        Me.lcClickHere.Text = "Click here"
        '
        'frmSetDefaultStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 138)
        Me.Controls.Add(Me.pcMessage)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetDefaultStore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Set Default Clinic"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.lueBuilding.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueClinic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcMessage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcMessage.ResumeLayout(False)
        Me.pcMessage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lueClinic As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lueBuilding As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pcMessage As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblMsg As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lcClickHere As DevExpress.XtraEditors.LabelControl
End Class
