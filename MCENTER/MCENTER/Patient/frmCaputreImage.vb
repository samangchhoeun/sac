Imports AForge
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports System.IO

Public Class frmCaputreImage
    Dim CAMERA As VideoCaptureDevice
    Dim bmp As Bitmap

    Private Sub frmCaputreImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
        If cameras.ShowDialog = DialogResult.OK Then
            CAMERA = cameras.VideoDevice
            AddHandler CAMERA.NewFrame, New NewFrameEventHandler(AddressOf Captured)
            CAMERA.Start()
        End If
    End Sub

    Private Sub Captured(sender As Object, eventArgs As NewFrameEventArgs)
        bmp = DirectCast(eventArgs.Frame.Clone, Bitmap)
        picWebCam.Image = DirectCast(eventArgs.Frame.Clone, Bitmap)
    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        lblImageFile.Text = ""
        If lblImageFile.Text <> "" Then
            picShow.Image = Image.FromFile(lblImageFile.Text)
        End If
        picSave.Image = picWebCam.Image
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveFileDialog1.DefaultExt = "*.jpg"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            picSave.Image.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Jpeg)
            lblImageFile.Text = SaveFileDialog1.FileName
            lblUserFile.Text = Path.GetFileName(SaveFileDialog1.FileName)
            'Dispose
        Else
            lblUserFile.Text = ""
        End If
    End Sub

    Private Sub frmCaputreImage_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            CAMERA.Stop()
        Catch ex As Exception

        End Try

    End Sub
End Class