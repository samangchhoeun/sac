Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmUpdateLogoImage
    Friend ImageID As Integer = 0
    Dim PhotoBuffer As Byte()
    Friend IsImageChange As Integer = 0
    Friend ImageType As String = "Clinic Logo"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim GetImage As Object

            If IsArray(PhotoBuffer) = False Then
                GetImage = 0
            Else
                GetImage = PhotoBuffer
            End If

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveLogoImage", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", ImageID)
                .AddWithValue("@IsChanged", IsImageChange)
                .AddWithValue("@Photo", GetImage)
                .AddWithValue("@StartDate", deStartDate.Text.Trim)
                .AddWithValue("@EndDate", deEndDate.Text.Trim)
                .AddWithValue("@IsPermanent", CBool(chkIsPermanent.Checked))
                .AddWithValue("@ImageType", ImageType)
                .AddWithValue("@User", LogUserNo)
                .Add("@isAdd", SqlDbType.Int)
                cmd.Parameters("@isAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim _Msg As String = ""
            Dim mms As MessageBoxIcon
            If Convert.ToInt16(cmd.Parameters("@isAdd").Value) <> 0 Then
                'EnabledButtonSave("Save", False)
                mms = MessageBoxIcon.Information
            Else
                mms = MessageBoxIcon.Error
            End If

            If IsImageChange = 0 Then
                _Msg = "There is no new image uploaded."
            Else
                _Msg = cmd.Parameters("@msg").Value.ToString()
            End If
            LoadLogoImage()
            XtraMessageBox.Show(_Msg, "Logo", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnBrowse.Focus()
        End Try

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If btnBrowse.Text.Trim = "Browse..." Then
            Try
                Dim OpenImage As New OpenFileDialog
                OpenImage.Filter = "Image Files (*.jpg; *.jpeg; *.bmp; *png) |*.jpg; *.jpeg; *.bmp; *png"
                OpenImage.Title = "Select a Profile Picture"
                If OpenImage.ShowDialog() = DialogResult.OK Then
                    With picPhoto
                        .Load(OpenImage.FileName.Trim)
                        .SizeMode = PictureBoxSizeMode.StretchImage
                        .BackgroundImage = Nothing
                    End With

                    PhotoBuffer = imageToByteArray(picPhoto.Image)

                    If ms.Length > MAX_LOGO_IMAGE_SIZE Then
                        picPhoto.Image = Nothing
                        ReDim PhotoBuffer(0)
                        XtraMessageBox.Show("Maximum allowed size for file is 1MB.", "Uploaded Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        picPhoto.BackgroundImage = My.Resources.NoImage
                        Exit Sub
                    End If

                    IsImageChange = 1

                    ms.Flush()
                Else
                    If IsArray(PhotoBuffer) = False Then ReDim PhotoBuffer(0)
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Uploaded Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            If PhotoBuffer.Length > 1 Then btnBrowse.Text = "Remove"
            btnSave.Focus()
        Else
            btnBrowse.Text = "Browse..."
            picPhoto.Image = Nothing
            picPhoto.BackgroundImage = My.Resources.NoImage
            PhotoBuffer = Nothing
            btnBrowse.Focus()
        End If
    End Sub

    Private Sub LoadLogoImage()
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetLogoImage", New SqlParameter("@ImageType", ImageType))
            With dtData
                If .Rows.Count = 1 Then
                    ImageID = CInt(.Rows(0)("ID"))
                    GetImageInfo(.Rows(0)("Photo"), .Rows(0)("StartDate").ToString, .Rows(0)("EndDate").ToString, CBool(.Rows(0)("IsPermanent")))
                    btnBrowse.Focus()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadProfilePhoto(Src As Object, ProfilePicture As PictureBox)
        Try
            Dim img As Byte() = TryCast(Src, Byte())

            If img.Length > 4 Then
                btnBrowse.Text = "Remove"
            End If

            ProfilePicture.Image = byteArrayToImage(img)
            ProfilePicture.BackgroundImage = Nothing
            ProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage
            ProfilePicture.Refresh()
        Catch ex As Exception
            ProfilePicture.Image = Nothing
            ProfilePicture.BackgroundImage = My.Resources.NoImage
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs)
        deStartDate.EditValue = Nothing
        deEndDate.EditValue = Nothing
        IsImageChange = 0
        chkIsPermanent.Checked = True
        picPhoto.Image = My.Resources.NoImage
        picPhoto.Image = Nothing
        picPhoto.BackgroundImage = My.Resources.NoImage
        btnBrowse.Text = "Browse..."
        btnBrowse.Focus()
    End Sub

    Private Sub frmUpdateLogoImage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Friend Sub GetImageInfo(_Photo As Object, _StartDate As String, _EndDate As String, _Ispermanent As Boolean)
        LoadProfilePhoto(_Photo, picPhoto)
        chkIsPermanent.Checked = _Ispermanent
        If Not String.IsNullOrEmpty(_StartDate) Then deStartDate.EditValue = CDate(_StartDate)
        If Not String.IsNullOrEmpty(_EndDate) Then deEndDate.EditValue = CDate(_EndDate)
    End Sub

    Private Sub frmUpdateLogoImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLogoImage()
    End Sub

    Private Sub chkIsPermanent_CheckStateChanged_1(sender As Object, e As EventArgs) Handles chkIsPermanent.CheckStateChanged
        If CBool(chkIsPermanent.Checked) Then
            deStartDate.EditValue = Nothing
            deEndDate.EditValue = Nothing
        Else
            deStartDate.EditValue = Now.Date
            deEndDate.EditValue = Now.Date
        End If
        deStartDate.Enabled = Not CBool(chkIsPermanent.Checked)
        deEndDate.Enabled = Not CBool(chkIsPermanent.Checked)
    End Sub
End Class