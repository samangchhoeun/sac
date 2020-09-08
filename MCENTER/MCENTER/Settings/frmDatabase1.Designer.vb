<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatabase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDatabase))
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.ConnectionString = New DevExpress.XtraTab.XtraTabPage()
        Me.chkConShowPass = New DevExpress.XtraEditors.CheckEdit()
        Me.btnConSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnConTest = New DevExpress.XtraEditors.SimpleButton()
        Me.txtConPass = New DevExpress.XtraEditors.TextEdit()
        Me.txtConUser = New DevExpress.XtraEditors.TextEdit()
        Me.txtConDB = New DevExpress.XtraEditors.TextEdit()
        Me.txtConServer = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.UDL = New DevExpress.XtraTab.XtraTabPage()
        Me.chkUDLShowPass = New DevExpress.XtraEditors.CheckEdit()
        Me.btnBrowseUDL = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.btnUDLSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnUDLTest = New DevExpress.XtraEditors.SimpleButton()
        Me.txtUDLPass = New DevExpress.XtraEditors.TextEdit()
        Me.txtUDLUser = New DevExpress.XtraEditors.TextEdit()
        Me.txtUDLDB = New DevExpress.XtraEditors.TextEdit()
        Me.txtUDLServer = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.ConnectionString.SuspendLayout()
        CType(Me.chkConShowPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UDL.SuspendLayout()
        CType(Me.chkUDLShowPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnBrowseUDL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUDLPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUDLUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUDLDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUDLServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(13, 40)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.ConnectionString
        Me.XtraTabControl1.Size = New System.Drawing.Size(329, 276)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.ConnectionString, Me.UDL})
        '
        'ConnectionString
        '
        Me.ConnectionString.Controls.Add(Me.chkConShowPass)
        Me.ConnectionString.Controls.Add(Me.btnConSave)
        Me.ConnectionString.Controls.Add(Me.btnConTest)
        Me.ConnectionString.Controls.Add(Me.txtConPass)
        Me.ConnectionString.Controls.Add(Me.txtConUser)
        Me.ConnectionString.Controls.Add(Me.txtConDB)
        Me.ConnectionString.Controls.Add(Me.txtConServer)
        Me.ConnectionString.Controls.Add(Me.LabelControl4)
        Me.ConnectionString.Controls.Add(Me.LabelControl3)
        Me.ConnectionString.Controls.Add(Me.LabelControl2)
        Me.ConnectionString.Controls.Add(Me.LabelControl1)
        Me.ConnectionString.Name = "ConnectionString"
        Me.ConnectionString.Size = New System.Drawing.Size(323, 248)
        Me.ConnectionString.Text = "ConnectionString"
        '
        'chkConShowPass
        '
        Me.chkConShowPass.Location = New System.Drawing.Point(211, 136)
        Me.chkConShowPass.Name = "chkConShowPass"
        Me.chkConShowPass.Properties.Caption = "Show Password"
        Me.chkConShowPass.Size = New System.Drawing.Size(94, 19)
        Me.chkConShowPass.TabIndex = 5
        '
        'btnConSave
        '
        Me.btnConSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnConSave.Location = New System.Drawing.Point(225, 208)
        Me.btnConSave.Name = "btnConSave"
        Me.btnConSave.Size = New System.Drawing.Size(80, 23)
        Me.btnConSave.TabIndex = 7
        Me.btnConSave.Text = "Save"
        '
        'btnConTest
        '
        Me.btnConTest.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnConTest.Location = New System.Drawing.Point(13, 208)
        Me.btnConTest.Name = "btnConTest"
        Me.btnConTest.Size = New System.Drawing.Size(100, 23)
        Me.btnConTest.TabIndex = 6
        Me.btnConTest.Text = "Test Connection"
        '
        'txtConPass
        '
        Me.txtConPass.Location = New System.Drawing.Point(109, 110)
        Me.txtConPass.Name = "txtConPass"
        Me.txtConPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtConPass.Properties.NullValuePrompt = "Enter Password"
        Me.txtConPass.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtConPass.Properties.UseSystemPasswordChar = True
        Me.txtConPass.Size = New System.Drawing.Size(196, 20)
        Me.txtConPass.TabIndex = 4
        '
        'txtConUser
        '
        Me.txtConUser.Location = New System.Drawing.Point(109, 78)
        Me.txtConUser.Name = "txtConUser"
        Me.txtConUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtConUser.Properties.NullValuePrompt = "Enter User Name"
        Me.txtConUser.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtConUser.Size = New System.Drawing.Size(196, 20)
        Me.txtConUser.TabIndex = 3
        '
        'txtConDB
        '
        Me.txtConDB.Location = New System.Drawing.Point(108, 46)
        Me.txtConDB.Name = "txtConDB"
        Me.txtConDB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtConDB.Properties.NullValuePrompt = "Enter Database Name"
        Me.txtConDB.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtConDB.Size = New System.Drawing.Size(197, 20)
        Me.txtConDB.TabIndex = 2
        '
        'txtConServer
        '
        Me.txtConServer.Location = New System.Drawing.Point(108, 15)
        Me.txtConServer.Name = "txtConServer"
        Me.txtConServer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtConServer.Properties.NullValuePrompt = "Enter Server Name"
        Me.txtConServer.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtConServer.Size = New System.Drawing.Size(198, 20)
        Me.txtConServer.TabIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(13, 48)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl4.TabIndex = 3
        Me.LabelControl4.Text = "Database Name"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(13, 112)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Password"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(13, 81)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "User Name"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Server Name"
        '
        'UDL
        '
        Me.UDL.Controls.Add(Me.chkUDLShowPass)
        Me.UDL.Controls.Add(Me.btnBrowseUDL)
        Me.UDL.Controls.Add(Me.LabelControl9)
        Me.UDL.Controls.Add(Me.btnUDLSave)
        Me.UDL.Controls.Add(Me.btnUDLTest)
        Me.UDL.Controls.Add(Me.txtUDLPass)
        Me.UDL.Controls.Add(Me.txtUDLUser)
        Me.UDL.Controls.Add(Me.txtUDLDB)
        Me.UDL.Controls.Add(Me.txtUDLServer)
        Me.UDL.Controls.Add(Me.LabelControl5)
        Me.UDL.Controls.Add(Me.LabelControl6)
        Me.UDL.Controls.Add(Me.LabelControl7)
        Me.UDL.Controls.Add(Me.LabelControl8)
        Me.UDL.Name = "UDL"
        Me.UDL.Size = New System.Drawing.Size(323, 248)
        Me.UDL.Text = "Universal Data Link"
        '
        'chkUDLShowPass
        '
        Me.chkUDLShowPass.Location = New System.Drawing.Point(211, 167)
        Me.chkUDLShowPass.Name = "chkUDLShowPass"
        Me.chkUDLShowPass.Properties.Caption = "Show Password"
        Me.chkUDLShowPass.Size = New System.Drawing.Size(94, 19)
        Me.chkUDLShowPass.TabIndex = 14
        '
        'btnBrowseUDL
        '
        Me.btnBrowseUDL.EditValue = ""
        Me.btnBrowseUDL.Location = New System.Drawing.Point(108, 15)
        Me.btnBrowseUDL.Name = "btnBrowseUDL"
        Me.btnBrowseUDL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.btnBrowseUDL.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.btnBrowseUDL.Properties.NullValuePrompt = "Browse UDL File"
        Me.btnBrowseUDL.Properties.NullValuePromptShowForEmptyValue = True
        Me.btnBrowseUDL.Size = New System.Drawing.Size(197, 20)
        Me.btnBrowseUDL.TabIndex = 9
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(13, 17)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl9.TabIndex = 20
        Me.LabelControl9.Text = "Browse..."
        '
        'btnUDLSave
        '
        Me.btnUDLSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnUDLSave.Location = New System.Drawing.Point(226, 208)
        Me.btnUDLSave.Name = "btnUDLSave"
        Me.btnUDLSave.Size = New System.Drawing.Size(80, 23)
        Me.btnUDLSave.TabIndex = 15
        Me.btnUDLSave.Text = "Save"
        '
        'btnUDLTest
        '
        Me.btnUDLTest.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnUDLTest.Location = New System.Drawing.Point(13, 208)
        Me.btnUDLTest.Name = "btnUDLTest"
        Me.btnUDLTest.Size = New System.Drawing.Size(100, 23)
        Me.btnUDLTest.TabIndex = 16
        Me.btnUDLTest.Text = "Test Connection"
        '
        'txtUDLPass
        '
        Me.txtUDLPass.Location = New System.Drawing.Point(108, 141)
        Me.txtUDLPass.Name = "txtUDLPass"
        Me.txtUDLPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtUDLPass.Properties.NullValuePrompt = "Enter Password"
        Me.txtUDLPass.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtUDLPass.Properties.UseSystemPasswordChar = True
        Me.txtUDLPass.Size = New System.Drawing.Size(198, 20)
        Me.txtUDLPass.TabIndex = 13
        '
        'txtUDLUser
        '
        Me.txtUDLUser.Location = New System.Drawing.Point(109, 110)
        Me.txtUDLUser.Name = "txtUDLUser"
        Me.txtUDLUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtUDLUser.Properties.NullValuePrompt = "Enter User Name"
        Me.txtUDLUser.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtUDLUser.Size = New System.Drawing.Size(197, 20)
        Me.txtUDLUser.TabIndex = 12
        '
        'txtUDLDB
        '
        Me.txtUDLDB.Location = New System.Drawing.Point(109, 78)
        Me.txtUDLDB.Name = "txtUDLDB"
        Me.txtUDLDB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtUDLDB.Properties.NullValuePrompt = "Enter Database Name"
        Me.txtUDLDB.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtUDLDB.Size = New System.Drawing.Size(197, 20)
        Me.txtUDLDB.TabIndex = 11
        '
        'txtUDLServer
        '
        Me.txtUDLServer.EditValue = ""
        Me.txtUDLServer.Location = New System.Drawing.Point(108, 46)
        Me.txtUDLServer.Name = "txtUDLServer"
        Me.txtUDLServer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtUDLServer.Properties.NullValuePrompt = "Enter Server Name"
        Me.txtUDLServer.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtUDLServer.Size = New System.Drawing.Size(197, 20)
        Me.txtUDLServer.TabIndex = 10
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(13, 81)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl5.TabIndex = 13
        Me.LabelControl5.Text = "Database Name"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(13, 144)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl6.TabIndex = 12
        Me.LabelControl6.Text = "Password"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(13, 112)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl7.TabIndex = 11
        Me.LabelControl7.Text = "User Name"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(13, 48)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl8.TabIndex = 10
        Me.LabelControl8.Text = "Server Name"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl10.Appearance.Options.UseFont = True
        Me.LabelControl10.Appearance.Options.UseForeColor = True
        Me.LabelControl10.Location = New System.Drawing.Point(13, 10)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(176, 18)
        Me.LabelControl10.TabIndex = 1
        Me.LabelControl10.Text = "Database Configuration"
        '
        'btnClose
        '
        Me.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.btnClose.Location = New System.Drawing.Point(268, 324)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(69, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmDatabase
        '
        Me.AcceptButton = Me.btnUDLSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 361)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDatabase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Database Configuration"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.ConnectionString.ResumeLayout(False)
        Me.ConnectionString.PerformLayout()
        CType(Me.chkConShowPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UDL.ResumeLayout(False)
        Me.UDL.PerformLayout()
        CType(Me.chkUDLShowPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnBrowseUDL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUDLPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUDLUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUDLDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUDLServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents ConnectionString As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents UDL As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtConUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtConDB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtConServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtConPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnConTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnConSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnUDLSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnUDLTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtUDLPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUDLUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUDLDB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUDLServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnBrowseUDL As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkUDLShowPass As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkConShowPass As DevExpress.XtraEditors.CheckEdit
End Class
