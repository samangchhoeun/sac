<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaputreImage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaputreImage))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.picWebCam = New System.Windows.Forms.PictureBox()
        Me.picSave = New System.Windows.Forms.PictureBox()
        Me.btnStart = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCapture = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.picShow = New System.Windows.Forms.PictureBox()
        Me.lblImageFile = New DevExpress.XtraEditors.LabelControl()
        Me.lblUserFile = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.picWebCam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picShow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 338.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.picWebCam, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.picSave, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.picShow, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 52)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1007, 224)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'picWebCam
        '
        Me.picWebCam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picWebCam.Location = New System.Drawing.Point(3, 3)
        Me.picWebCam.Name = "picWebCam"
        Me.picWebCam.Size = New System.Drawing.Size(328, 218)
        Me.picWebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picWebCam.TabIndex = 0
        Me.picWebCam.TabStop = False
        '
        'picSave
        '
        Me.picSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picSave.Location = New System.Drawing.Point(337, 3)
        Me.picSave.Name = "picSave"
        Me.picSave.Size = New System.Drawing.Size(328, 218)
        Me.picSave.TabIndex = 1
        Me.picSave.TabStop = False
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(12, 12)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start"
        '
        'btnCapture
        '
        Me.btnCapture.Location = New System.Drawing.Point(105, 12)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(75, 23)
        Me.btnCapture.TabIndex = 2
        Me.btnCapture.Text = "Capture"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(199, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        '
        'picShow
        '
        Me.picShow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picShow.Location = New System.Drawing.Point(671, 3)
        Me.picShow.Name = "picShow"
        Me.picShow.Size = New System.Drawing.Size(333, 218)
        Me.picShow.TabIndex = 2
        Me.picShow.TabStop = False
        '
        'lblImageFile
        '
        Me.lblImageFile.Location = New System.Drawing.Point(510, 12)
        Me.lblImageFile.Name = "lblImageFile"
        Me.lblImageFile.Size = New System.Drawing.Size(34, 13)
        Me.lblImageFile.TabIndex = 4
        Me.lblImageFile.Text = "Image:"
        '
        'lblUserFile
        '
        Me.lblUserFile.Location = New System.Drawing.Point(510, 31)
        Me.lblUserFile.Name = "lblUserFile"
        Me.lblUserFile.Size = New System.Drawing.Size(34, 13)
        Me.lblUserFile.TabIndex = 5
        Me.lblUserFile.Text = "Image:"
        '
        'frmCaputreImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 291)
        Me.Controls.Add(Me.lblUserFile)
        Me.Controls.Add(Me.lblImageFile)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCapture)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCaputreImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Capture Image"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.picWebCam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picShow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents picWebCam As PictureBox
    Friend WithEvents picSave As PictureBox
    Friend WithEvents btnStart As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCapture As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents picShow As PictureBox
    Friend WithEvents lblImageFile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUserFile As DevExpress.XtraEditors.LabelControl
End Class
