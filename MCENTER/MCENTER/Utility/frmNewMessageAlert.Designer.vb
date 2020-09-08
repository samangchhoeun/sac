<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewMessageAlert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewMessageAlert))
        Me.pcHeader = New DevExpress.XtraEditors.PanelControl()
        Me.btnDown = New DevExpress.XtraEditors.SimpleButton()
        Me.picNewMessage = New System.Windows.Forms.PictureBox()
        Me.pcContent = New DevExpress.XtraEditors.PanelControl()
        Me.nbcContent = New DevExpress.XtraNavBar.NavBarControl()
        Me.nbgMedToDispense = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarItem1 = New DevExpress.XtraNavBar.NavBarItem()
        Me.rbgUrgentResult = New DevExpress.XtraNavBar.NavBarGroup()
        Me.ngvAlertVaccine = New DevExpress.XtraNavBar.NavBarGroup()
        Me.nbgReadyToPay = New DevExpress.XtraNavBar.NavBarGroup()
        Me.nbgUrgentRequest = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.timUp = New System.Windows.Forms.Timer(Me.components)
        Me.timDown = New System.Windows.Forms.Timer(Me.components)
        Me.icNewMessage = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ilButtonList = New System.Windows.Forms.ImageList(Me.components)
        Me.timImageFlicker = New System.Windows.Forms.Timer(Me.components)
        Me.AlertControl1 = New DevExpress.XtraBars.Alerter.AlertControl(Me.components)
        CType(Me.pcHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcHeader.SuspendLayout()
        CType(Me.picNewMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcContent.SuspendLayout()
        CType(Me.nbcContent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icNewMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pcHeader
        '
        Me.pcHeader.Controls.Add(Me.btnDown)
        Me.pcHeader.Controls.Add(Me.picNewMessage)
        Me.pcHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pcHeader.Location = New System.Drawing.Point(0, 0)
        Me.pcHeader.Name = "pcHeader"
        Me.pcHeader.Size = New System.Drawing.Size(190, 37)
        Me.pcHeader.TabIndex = 7
        '
        'btnDown
        '
        Me.btnDown.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDown.Image = CType(resources.GetObject("btnDown.Image"), System.Drawing.Image)
        Me.btnDown.Location = New System.Drawing.Point(163, 2)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(25, 33)
        Me.btnDown.TabIndex = 7
        '
        'picNewMessage
        '
        Me.picNewMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picNewMessage.Dock = System.Windows.Forms.DockStyle.Left
        Me.picNewMessage.Image = CType(resources.GetObject("picNewMessage.Image"), System.Drawing.Image)
        Me.picNewMessage.Location = New System.Drawing.Point(2, 2)
        Me.picNewMessage.Name = "picNewMessage"
        Me.picNewMessage.Size = New System.Drawing.Size(160, 33)
        Me.picNewMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picNewMessage.TabIndex = 6
        Me.picNewMessage.TabStop = False
        '
        'pcContent
        '
        Me.pcContent.Controls.Add(Me.nbcContent)
        Me.pcContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcContent.Location = New System.Drawing.Point(0, 37)
        Me.pcContent.Name = "pcContent"
        Me.pcContent.Size = New System.Drawing.Size(190, 463)
        Me.pcContent.TabIndex = 8
        '
        'nbcContent
        '
        Me.nbcContent.ActiveGroup = Me.nbgMedToDispense
        Me.nbcContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.nbcContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nbcContent.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.nbgMedToDispense, Me.rbgUrgentResult, Me.ngvAlertVaccine, Me.nbgReadyToPay, Me.nbgUrgentRequest, Me.NavBarGroup1})
        Me.nbcContent.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.NavBarItem1})
        Me.nbcContent.Location = New System.Drawing.Point(2, 2)
        Me.nbcContent.LookAndFeel.UseDefaultLookAndFeel = False
        Me.nbcContent.Name = "nbcContent"
        Me.nbcContent.OptionsNavPane.ExpandedWidth = 186
        Me.nbcContent.Size = New System.Drawing.Size(186, 459)
        Me.nbcContent.TabIndex = 0
        Me.nbcContent.Text = "ContentMessage"
        '
        'nbgMedToDispense
        '
        Me.nbgMedToDispense.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbgMedToDispense.Appearance.Options.UseFont = True
        Me.nbgMedToDispense.Caption = "Rx To Dispense"
        Me.nbgMedToDispense.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem1)})
        Me.nbgMedToDispense.Name = "nbgMedToDispense"
        Me.nbgMedToDispense.SmallImage = CType(resources.GetObject("nbgMedToDispense.SmallImage"), System.Drawing.Image)
        '
        'NavBarItem1
        '
        Me.NavBarItem1.Caption = "NavBarItem1"
        Me.NavBarItem1.Name = "NavBarItem1"
        '
        'rbgUrgentResult
        '
        Me.rbgUrgentResult.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbgUrgentResult.Appearance.Options.UseFont = True
        Me.rbgUrgentResult.Caption = "Urgent Result"
        Me.rbgUrgentResult.Expanded = True
        Me.rbgUrgentResult.Name = "rbgUrgentResult"
        Me.rbgUrgentResult.SmallImage = CType(resources.GetObject("rbgUrgentResult.SmallImage"), System.Drawing.Image)
        '
        'ngvAlertVaccine
        '
        Me.ngvAlertVaccine.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ngvAlertVaccine.Appearance.Options.UseFont = True
        Me.ngvAlertVaccine.Caption = "Alert Vaccine"
        Me.ngvAlertVaccine.Name = "ngvAlertVaccine"
        Me.ngvAlertVaccine.SmallImage = CType(resources.GetObject("ngvAlertVaccine.SmallImage"), System.Drawing.Image)
        '
        'nbgReadyToPay
        '
        Me.nbgReadyToPay.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbgReadyToPay.Appearance.Options.UseFont = True
        Me.nbgReadyToPay.Caption = "Ready To Pay"
        Me.nbgReadyToPay.Name = "nbgReadyToPay"
        Me.nbgReadyToPay.SmallImage = CType(resources.GetObject("nbgReadyToPay.SmallImage"), System.Drawing.Image)
        '
        'nbgUrgentRequest
        '
        Me.nbgUrgentRequest.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbgUrgentRequest.Appearance.Options.UseFont = True
        Me.nbgUrgentRequest.Caption = "Urgent Request"
        Me.nbgUrgentRequest.Name = "nbgUrgentRequest"
        Me.nbgUrgentRequest.SmallImage = CType(resources.GetObject("nbgUrgentRequest.SmallImage"), System.Drawing.Image)
        '
        'NavBarGroup1
        '
        Me.NavBarGroup1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarGroup1.Appearance.Options.UseFont = True
        Me.NavBarGroup1.Caption = "New Result To Print"
        Me.NavBarGroup1.Expanded = True
        Me.NavBarGroup1.Name = "NavBarGroup1"
        Me.NavBarGroup1.SmallImage = CType(resources.GetObject("NavBarGroup1.SmallImage"), System.Drawing.Image)
        '
        'timUp
        '
        Me.timUp.Interval = 1
        '
        'timDown
        '
        Me.timDown.Interval = 1
        '
        'icNewMessage
        '
        Me.icNewMessage.ImageSize = New System.Drawing.Size(273, 60)
        Me.icNewMessage.ImageStream = CType(resources.GetObject("icNewMessage.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.icNewMessage.Images.SetKeyName(0, "Alert3.png")
        Me.icNewMessage.Images.SetKeyName(1, "Alert4.png")
        '
        'ilButtonList
        '
        Me.ilButtonList.ImageStream = CType(resources.GetObject("ilButtonList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilButtonList.TransparentColor = System.Drawing.Color.Transparent
        Me.ilButtonList.Images.SetKeyName(0, "bullet_go-2.png")
        Me.ilButtonList.Images.SetKeyName(1, "bullet_go.png")
        '
        'timImageFlicker
        '
        Me.timImageFlicker.Enabled = True
        Me.timImageFlicker.Interval = 150
        '
        'frmNewMessageAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(190, 500)
        Me.ControlBox = False
        Me.Controls.Add(Me.pcContent)
        Me.Controls.Add(Me.pcHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewMessageAlert"
        Me.Text = "New Message Alert"
        CType(Me.pcHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcHeader.ResumeLayout(False)
        CType(Me.picNewMessage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcContent.ResumeLayout(False)
        CType(Me.nbcContent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icNewMessage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picNewMessage As PictureBox
    Friend WithEvents pcHeader As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnDown As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pcContent As DevExpress.XtraEditors.PanelControl
    Friend WithEvents timUp As Timer
    Friend WithEvents timDown As Timer
    Friend WithEvents icNewMessage As DevExpress.Utils.ImageCollection
    Friend WithEvents ilButtonList As ImageList
    Friend WithEvents timImageFlicker As Timer
    Friend WithEvents nbcContent As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents nbgMedToDispense As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents rbgUrgentResult As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents ngvAlertVaccine As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents nbgReadyToPay As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents nbgUrgentRequest As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGroup1 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem1 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents AlertControl1 As DevExpress.XtraBars.Alerter.AlertControl
End Class
