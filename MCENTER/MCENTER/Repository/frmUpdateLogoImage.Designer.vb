<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUpdateLogoImage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdateLogoImage))
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.deEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.deStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.chkIsPermanent = New DevExpress.XtraEditors.CheckEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.picPhoto = New System.Windows.Forms.PictureBox()
        CType(Me.deEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsPermanent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(383, 40)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl7.TabIndex = 3345
        Me.LabelControl7.Text = "To"
        '
        'deEndDate
        '
        Me.deEndDate.EditValue = Nothing
        Me.deEndDate.Enabled = False
        Me.deEndDate.Location = New System.Drawing.Point(401, 37)
        Me.deEndDate.Name = "deEndDate"
        Me.deEndDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deEndDate.Properties.DisplayFormat.FormatString = "MMM dd, yyyy"
        Me.deEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deEndDate.Properties.Mask.EditMask = "g"
        Me.deEndDate.Size = New System.Drawing.Size(117, 20)
        Me.deEndDate.TabIndex = 4
        '
        'deStartDate
        '
        Me.deStartDate.EditValue = Nothing
        Me.deStartDate.Enabled = False
        Me.deStartDate.Location = New System.Drawing.Point(260, 37)
        Me.deStartDate.Name = "deStartDate"
        Me.deStartDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.deStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartDate.Properties.DisplayFormat.FormatString = "MMM dd, yyyy"
        Me.deStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deStartDate.Properties.Mask.EditMask = "g"
        Me.deStartDate.Size = New System.Drawing.Size(117, 20)
        Me.deStartDate.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(260, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl1.TabIndex = 3344
        Me.LabelControl1.Text = "Effective Date"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(260, 63)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(134, 13)
        Me.LabelControl2.TabIndex = 3346
        Me.LabelControl2.Text = " Image size= 225px X100px"
        '
        'chkIsPermanent
        '
        Me.chkIsPermanent.EditValue = True
        Me.chkIsPermanent.Location = New System.Drawing.Point(260, 82)
        Me.chkIsPermanent.Name = "chkIsPermanent"
        Me.chkIsPermanent.Properties.Caption = "Is Permanent?"
        Me.chkIsPermanent.Size = New System.Drawing.Size(93, 19)
        Me.chkIsPermanent.TabIndex = 3347
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(445, 95)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(73, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        '
        'btnBrowse
        '
        Me.btnBrowse.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(359, 95)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(80, 23)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "Browse..."
        '
        'picPhoto
        '
        Me.picPhoto.BackColor = System.Drawing.Color.Transparent
        Me.picPhoto.BackgroundImage = CType(resources.GetObject("picPhoto.BackgroundImage"), System.Drawing.Image)
        Me.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPhoto.Location = New System.Drawing.Point(12, 18)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(225, 100)
        Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPhoto.TabIndex = 3337
        Me.picPhoto.TabStop = False
        Me.picPhoto.Tag = ""
        '
        'frmUpdateLogoImage
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 134)
        Me.Controls.Add(Me.chkIsPermanent)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.deEndDate)
        Me.Controls.Add(Me.deStartDate)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.picPhoto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdateLogoImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Upload Logo"
        CType(Me.deEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsPermanent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnBrowse As DevExpress.XtraEditors.SimpleButton
    Private WithEvents picPhoto As PictureBox
    Private WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Private WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents deEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deStartDate As DevExpress.XtraEditors.DateEdit
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkIsPermanent As DevExpress.XtraEditors.CheckEdit
End Class
