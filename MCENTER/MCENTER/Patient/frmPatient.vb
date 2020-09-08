Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmPatient
    Public _TempPatientCode As String = ""
    Dim _TempPatientID As Integer = 0
    Dim _PhotoBuffer As Byte()
    Dim _IsExistImage As Integer = 0
    Dim _ChangePhoto As String = "Browse..."

    Private Sub frmPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deDOB.DateTime = Now.Date.AddYears(-18)
        deRegistrationDate.DateTime = Now.Date
        GetDataToComboBoxWithParam(lueNationality, "SA_GetNationalityList", "ID", "Nationality")
        'lueNationality.EditValue = 29
        GetDataToComboBoxWithParam(lueCity, "SA_GetCityList", "PID", "City/Province", New SqlParameter("@ID", 0), New SqlParameter("@Flag", 0))
        GetDataToComboBoxWithParam(luePOBCity, "SA_GetCityList", "PID", "City/Province", New SqlParameter("@ID", 0), New SqlParameter("@Flag", 0))
        'lueCity.ItemIndex = 14
        GetDataToComboBoxWithParam(lueCooperatedCompany, "SA_GetCorporateClientsByID", "ID", "CorporateClient", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        GetDataToComboBoxWithParam(lueEmRelation, "SA_GetAllRelationsList", "RelationID", "Relation", New SqlParameter("@Flag", 1))
        GetDataToComboBoxWithParam(lueOccupation, "SA_GetPatientOccupation", "OccupationID", "Occupation", New SqlParameter("@ID", 0))
        GetDataToComboBoxWithParam(luePatientType, "SA_GetPatientTypes", "ID", "PatientType", New SqlParameter("@ID", 0))
        GetMediaChannel()
        GetPatientReminder()
    End Sub

    Private Sub GetPatientReminder()
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientReminder", New SqlParameter("@ID", 0))
            With dtData
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        chkAppointmentReminder.Items.Add(.Rows(i).Item("ID").ToString, .Rows(i).Item("Reminder").ToString)
                    Next
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetMediaChannel()
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetMediaChannel", New SqlParameter("@ID", 0))
            With dtData
                For i As Integer = 0 To .Rows.Count - 1
                    rgHowToKnowUs.Properties.Items.Add(New RadioGroupItem(.Rows(i).Item("ID"), .Rows(i).Item("MediaChannel").ToString))
                Next
                rgHowToKnowUs.SelectedIndex = -1
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContents()
        EnabledButtonSave()
        deRegistrationDate.Select()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
        btnBrowse.Enabled = en
        btnDelete.Enabled = del
    End Sub

    Private Sub ClearAllContents()
        _TempPatientCode = ""
        _TempPatientID = 0
        deRegistrationDate.DateTime = Now.Date
        txtPatientCode.Text = "***"
        txtPatientID.Text = "***"
        txtKLastName.Text = ""
        txtKFirstName.Text = ""
        txtLastName.Text = ""
        txtFirstName.Text = ""
        rgGender.SelectedIndex = 0
        rgMaritalStatus.SelectedIndex = 0
        'lueNationality.EditValue = 29
        lueNationality.EditValue = -1
        deDOB.DateTime = Now.Date.AddYears(-18)

        lueOccupation.EditValue = -1
        txtCellPhone.Text = ""
        txtHonePhone.Text = ""
        txtEmail.Text = ""
        txtNSSF.Text = ""
        luePatientType.EditValue = -1
        txtCardID.Text = ""
        lueCooperatedCompany.EditValue = -1
        txtCompanyPhone.Text = ""
        meCompanyAddress.Text = ""
        luePOBCity.EditValue = -1
        luePOBKhan.EditValue = -1
        luePOBSangkat.EditValue = -1
        luePOBVillage.EditValue = -1
        txtPOBStreet.Text = ""
        txtPOBHome.Text = ""
        lueCity.EditValue = -1
        lueKhan.EditValue = -1
        lueSangkat.EditValue = -1
        lueVillage.EditValue = -1
        txtStreet.Text = ""
        txtHome.Text = ""
        rgHowToKnowUs.SelectedIndex = -1
        chkAppointmentReminder.UnCheckAll()
        txtEmName.Text = ""
        lueEmRelation.EditValue = -1
        txtEmCellPhone.Text = ""
        txtEmHomePhone.Text = ""
        meNote.Text = ""
        picPhoto.Image = Nothing
        picPhoto.BackgroundImage = My.Resources.MJQE_Photo
        btnBrowse.Text = "Browse..."
        meStatus.Visible = False
        meStatus.Text = ""
    End Sub

    Private Sub LoadProfileImage(Src As Object, ProfilePicture As PictureBox)
        Try
            Dim img As Byte() = TryCast(Src, Byte())

            If img.Length > 4 Then
                _ChangePhoto = "Remove"
                btnBrowse.Text = "Remove"
            End If

            ProfilePicture.Image = byteArrayToImage(img)
            ProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage
            ProfilePicture.Refresh()
        Catch ex As Exception
            ProfilePicture.Image = Nothing
        End Try
    End Sub

    Public Sub GetEmployeeRecord(Find_ID As String)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientProfile", New SqlParameter("@PatientCode", Find_ID))
            With dtData
                If .Rows.Count = 1 Then
                    _IsExistImage = 1
                    EnabledButtonSave("&Update", True, True)
                    If String.IsNullOrEmpty(.Rows(0)("RegistrationDate").ToString) Then
                        deRegistrationDate.DateTime = DateTime.Now.AddYears(-18)
                    Else
                        deRegistrationDate.DateTime = CDate(.Rows(0)("RegistrationDate").ToString)
                    End If

                    _TempPatientID = CInt(.Rows(0)("PatientID"))
                    _TempPatientCode = .Rows(0)("PatientCode").ToString
                    txtPatientCode.Text = FormatPatientCode(.Rows(0)("PatientCode").ToString)
                    txtPatientID.Text = .Rows(0)("PatientID").ToString
                    txtFirstName.Text = .Rows(0)("FirstName").ToString
                    txtLastName.Text = .Rows(0)("LastName").ToString
                    txtKFirstName.Text = .Rows(0)("KFirstName").ToString
                    txtKLastName.Text = .Rows(0)("KLastName").ToString
                    Dim EnglishName As String = .Rows(0)("EnglishName").ToString
                    Dim KhmerName As String = .Rows(0)("KhmerName").ToString
                    rgGender.EditValue = .Rows(0)("Gender").ToString
                    rgMaritalStatus.EditValue = .Rows(0)("MaritalStatus").ToString

                    If CInt(.Rows(0)("Nationality")) > 0 Then
                        lueNationality.EditValue = CInt(.Rows(0)("Nationality"))
                    Else
                        lueNationality.EditValue = -1
                    End If

                    Dim dob As String = .Rows(0)("DOB").ToString
                    If String.IsNullOrEmpty(dob) Then
                        deDOB.DateTime = DateTime.Now.AddYears(-18)
                    Else
                        deDOB.DateTime = Convert.ToDateTime(dob)
                    End If

                    If CInt(.Rows(0)("BirthCity")) > 0 Then
                        luePOBCity.EditValue = CInt(.Rows(0)("BirthCity"))
                    Else
                        luePOBCity.EditValue = -1
                    End If
                    If CInt(.Rows(0)("BirthKhan")) > 0 Then
                        GetDataToComboBoxWithParam(luePOBKhan, "SA_GetKhanList", "KhanID", "Khan/District", New SqlParameter("@ID", 0), New SqlParameter("@CityID", CInt(luePOBCity.EditValue)), New SqlParameter("@Flag", 0))
                        luePOBKhan.EditValue = CInt(.Rows(0)("BirthKhan"))
                    Else
                        luePOBKhan.EditValue = -1
                    End If
                    If CInt(.Rows(0)("BirthSangkat")) > 0 Then
                        GetDataToComboBoxWithParam(luePOBSangkat, "SA_GetSangkatList", "SangkatID", "Sangkat/Commune", New SqlParameter("@ID", 0), New SqlParameter("@KhanID", CInt(luePOBKhan.EditValue)), New SqlParameter("@Flag", 0))
                        luePOBSangkat.EditValue = CInt(.Rows(0)("BirthSangkat"))
                    Else
                        luePOBSangkat.EditValue = -1
                    End If
                    If CInt(.Rows(0)("BirthVillage")) > 0 Then
                        GetDataToComboBoxWithParam(luePOBVillage, "SA_GetVillageList", "VillageID", "Village", New SqlParameter("@ID", 0), New SqlParameter("@SangkatID", CInt(luePOBSangkat.EditValue)), New SqlParameter("@Flag", 0))
                        luePOBVillage.EditValue = CInt(.Rows(0)("BirthVillage"))
                    Else
                        luePOBVillage.EditValue = -1
                    End If

                    txtPOBHome.Text = .Rows(0)("BirthHome").ToString
                    txtPOBStreet.Text = .Rows(0)("BirthStreet").ToString

                    If CInt(.Rows(0)("CurCity")) > 0 Then
                        lueCity.EditValue = CInt(.Rows(0)("CurCity"))
                    Else
                        lueCity.EditValue = -1
                    End If
                    If CInt(.Rows(0)("CurKhan")) > 0 Then
                        GetDataToComboBoxWithParam(lueKhan, "SA_GetKhanList", "KhanID", "Khan/District", New SqlParameter("@ID", 0), New SqlParameter("@CityID", CInt(lueCity.EditValue)), New SqlParameter("@Flag", 0))
                        lueKhan.EditValue = CInt(.Rows(0)("CurKhan"))
                    Else
                        lueKhan.EditValue = -1
                    End If
                    If CInt(.Rows(0)("CurSangkat")) > 0 Then
                        GetDataToComboBoxWithParam(lueSangkat, "SA_GetSangkatList", "SangkatID", "Sangkat/Commune", New SqlParameter("@ID", 0), New SqlParameter("@KhanID", CInt(lueKhan.EditValue)), New SqlParameter("@Flag", 0))
                        lueSangkat.EditValue = CInt(.Rows(0)("CurSangkat"))
                    Else
                        lueSangkat.EditValue = -1
                    End If
                    If CInt(.Rows(0)("CurVillage")) > 0 Then
                        GetDataToComboBoxWithParam(lueVillage, "SA_GetVillageList", "VillageID", "Village", New SqlParameter("@ID", 0), New SqlParameter("@SangkatID", CInt(lueSangkat.EditValue)), New SqlParameter("@Flag", 0))
                        lueVillage.EditValue = CInt(.Rows(0)("CurVillage"))
                    Else
                        lueVillage.EditValue = -1
                    End If

                    txtHome.Text = .Rows(0)("CurHome").ToString
                    txtStreet.Text = .Rows(0)("CurStreet").ToString

                    If CInt(.Rows(0)("Occupation")) > 0 Then
                        lueOccupation.EditValue = CInt(.Rows(0)("Occupation"))
                    Else
                        lueOccupation.EditValue = -1
                    End If

                    txtCellPhone.Text = .Rows(0)("CellPhone").ToString
                    txtHonePhone.Text = .Rows(0)("HomePhone").ToString
                    txtEmail.Text = .Rows(0)("Email").ToString
                    txtNSSF.Text = .Rows(0)("NSSF").ToString

                    If CInt(.Rows(0)("PatientTypeID")) > 0 Then
                        luePatientType.EditValue = CInt(.Rows(0)("PatientTypeID"))
                    Else
                        luePatientType.EditValue = -1
                    End If

                    txtCardID.Text = .Rows(0)("CardID").ToString
                    If CInt(.Rows(0)("CorporatedCompany")) > 0 Then
                        lueCooperatedCompany.EditValue = CInt(.Rows(0)("CorporatedCompany"))
                    Else
                        lueCooperatedCompany.EditValue = -1
                    End If
                    txtCompanyPhone.Text = .Rows(0)("CompanyPhone").ToString
                    meCompanyAddress.Text = .Rows(0)("CompanyAddress").ToString

                    txtEmName.Text = .Rows(0)("EmName").ToString
                    If CInt(.Rows(0)("EmRelation")) > 0 Then
                        lueEmRelation.EditValue = CInt(.Rows(0)("EmRelation"))
                    Else
                        lueEmRelation.EditValue = -1
                    End If
                    txtEmCellPhone.Text = .Rows(0)("EmCellPhone").ToString
                    txtEmHomePhone.Text = .Rows(0)("EmHomePhone").ToString
                    rgHowToKnowUs.EditValue = CInt(.Rows(0)("KnownUs"))

                    Dim Splits As String() = {Comma}
                    Dim AReminderList As String = .Rows(0)("AppointmentReminder").ToString
                    Dim AReminderGroup As String() = AReminderList.Split(Splits, StringSplitOptions.RemoveEmptyEntries)

                    chkAppointmentReminder.UnCheckAll()
                    For i = 0 To chkAppointmentReminder.ItemCount - 1
                        If AReminderGroup.Contains(chkAppointmentReminder.Items(i).Value.ToString) Then
                            chkAppointmentReminder.SetItemChecked(i, True)
                        End If
                    Next
                    'For Each t As String In AReminderGroup
                    '    For i = 0 To chkAppointmentReminder.ItemCount - 1
                    '        If chkAppointmentReminder.Items(i).Value.ToString = t Then
                    '            chkAppointmentReminder.SetItemChecked(i, True)
                    '        End If
                    '    Next
                    'Next

                    LoadProfilePhoto(.Rows(0)("Photo"), picPhoto)
                    _PhotoBuffer = CType(.Rows(0)("Photo"), Byte())
                    If CBool(.Rows(0)("Mark_Deleted")) Then
                        meStatus.Visible = True
                        meStatus.Text = "This patient has been removed. Please contact System Administrator to restore this patient."
                        btnDelete.Enabled = False
                    Else
                        meStatus.Visible = False
                        btnDelete.Enabled = True
                        meStatus.Text = ""
                    End If
                    frmSearchEmployee.Dispose()
                Else
                    _IsExistImage = 0
                    XtraMessageBox.Show("Searching keyword: " + _TempPatientCode + " doesnot exist on the target system. " & vbLf & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                _ChangePhoto = "Remove"
                btnBrowse.Text = "Remove"
            End If

            ProfilePicture.Image = byteArrayToImage(img)
            ProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage
            ProfilePicture.Refresh()
        Catch ex As Exception
            ProfilePicture.Image = Nothing
        End Try

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ClearAllContents()
        EnabledButtonSave()
        frmSearchEmployee._Option = "search_patient"
        LoadFormDialog(frmSearchEmployee)
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If btnBrowse.Text.Trim = "Browse..." Then
            'ReDim PhotoBuffer(0)

            Try
                Dim OpenImage As New OpenFileDialog
                OpenImage.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp; *png) |*.jpg; *.jpeg; *.gif; *.bmp; *png"
                OpenImage.Title = "Select a Profile Picture"
                If OpenImage.ShowDialog() = DialogResult.OK Then
                    With picPhoto
                        .Load(OpenImage.FileName.Trim)
                        .SizeMode = PictureBoxSizeMode.StretchImage
                    End With

                    _PhotoBuffer = imageToByteArray(picPhoto.Image)

                    If ms.Length > MAX_IMAGE_SIZE Then
                        picPhoto.Image = Nothing
                        ReDim _PhotoBuffer(0)
                        XtraMessageBox.Show("Maximum allowed size for file is 1MB.", "Uploaded Photo Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    _IsExistImage = 0
                    ms.Flush()
                Else
                    If IsArray(_PhotoBuffer) = False Then ReDim _PhotoBuffer(0)
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Uploaded Photo Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            If _PhotoBuffer.Length > 1 Then btnBrowse.Text = "Remove"
        Else
            _IsExistImage = 0
            btnBrowse.Text = "Browse..."
            picPhoto.Image = Nothing
            _PhotoBuffer = Nothing
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not isLoggedInOwner Then
            If String.IsNullOrEmpty(txtFirstName.Text.Trim()) OrElse String.IsNullOrEmpty(txtLastName.Text.Trim()) Then
                XtraMessageBox.Show("Some fields are blank. Please check it.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtLastName.Focus()
                Return
            ElseIf String.IsNullOrEmpty(txtCellPhone.Text.Trim()) Then
                XtraMessageBox.Show("Some fields are blank. Please check it.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCellPhone.Focus()
                Return
            ElseIf CInt(lueOccupation.EditValue) <= 0 OrElse CInt(lueNationality.EditValue) <= 0 OrElse CInt(luePatientType.EditValue) <= 0 OrElse CInt(lueEmRelation.EditValue) <= 0 Then
                XtraMessageBox.Show("Some selection boxes are required.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lueOccupation.Focus()
                Return
            ElseIf chkAppointmentReminder.CheckedItems.Count = 0 Then
                XtraMessageBox.Show("Please choose appointment reminder option.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                chkAppointmentReminder.Focus()
                Return
            End If
        End If


        Try
            Dim OptList As String = String.Join(",", chkAppointmentReminder.CheckedItems.Cast(Of CheckedListBoxItem).Select(Function(item) item.Value.ToString).ToArray.OrderBy(Function(item) item))

            Dim _Nationality As Object = CInt(lueNationality.EditValue)
            Dim _Gender As String = rgGender.EditValue.ToString
            Dim _MaritalStatus As String = rgMaritalStatus.EditValue.ToString
            Dim _FirstName As String = ToTitleCase(txtFirstName.Text.Trim)
            Dim _LastName As String = ToTitleCase(txtLastName.Text.Trim)
            Dim _EmName As String = ToTitleCase(txtEmName.Text.Trim)

            Dim GetImage As Object = 0
            If IsArray(_PhotoBuffer) Then GetImage = _PhotoBuffer

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SavePatientProfile", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@PatientID", _TempPatientID)
                .AddWithValue("@FirstName", _FirstName)
                .AddWithValue("@LastName", _LastName)
                .AddWithValue("@KLastName", txtKLastName.Text.Trim)
                .AddWithValue("@KFirstName", txtKFirstName.Text.Trim)
                .AddWithValue("@Gender", _Gender)
                .AddWithValue("@MaritalStatus", _MaritalStatus)
                .AddWithValue("@Nationality", _Nationality)
                .AddWithValue("@DOB", deDOB.DateTime)
                .AddWithValue("@BirthHome", txtPOBHome.Text.Trim)
                .AddWithValue("@BirthStreet", txtPOBStreet.Text.Trim)
                .AddWithValue("@BirthVillage", CInt(luePOBVillage.EditValue))
                .AddWithValue("@BirthSangkat", CInt(luePOBSangkat.EditValue))
                .AddWithValue("@BirthKhan", CInt(luePOBKhan.EditValue))
                .AddWithValue("@BirthCity", CInt(luePOBCity.EditValue))
                .AddWithValue("@CurHome", txtHome.Text.Trim)
                .AddWithValue("@CurStreet", txtStreet.Text.Trim)
                .AddWithValue("@CurVillage", CInt(lueVillage.EditValue))
                .AddWithValue("@CurSangkat", CInt(lueSangkat.EditValue))
                .AddWithValue("@CurKhan", CInt(lueKhan.EditValue))
                .AddWithValue("@CurCity", CInt(lueCity.EditValue))
                .AddWithValue("@Occupation", CInt(lueOccupation.EditValue))
                .AddWithValue("@CellPhone", txtCellPhone.Text.Trim)
                .AddWithValue("@HomePhone", txtHonePhone.Text.Trim)
                .AddWithValue("@Email", txtEmail.Text.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(" ", ""))
                .AddWithValue("@NSSF", txtNSSF.Text.Trim)
                .AddWithValue("@PatientTypeID", CInt(luePatientType.EditValue))
                .AddWithValue("@CardID", txtCardID.Text.Trim)
                .AddWithValue("@CorporatedCompany", CInt(lueCooperatedCompany.EditValue))
                .AddWithValue("@CompanyPhone", txtCompanyPhone.Text.Trim)
                .AddWithValue("@CompanyAddress", meCompanyAddress.Text.Trim)
                .AddWithValue("@EmName", _EmName)
                .AddWithValue("@EmRelation", CInt(lueEmRelation.EditValue))
                .AddWithValue("@EmCellPhone", txtEmCellPhone.Text.Trim)
                .AddWithValue("@EmHomePhone", txtEmHomePhone.Text.Trim)
                .AddWithValue("@RegistrationDate", deRegistrationDate.DateTime)
                .AddWithValue("@RegClinic", ConfigClinic.ClinicID)
                .AddWithValue("@KnownUs", CInt(rgHowToKnowUs.EditValue))
                .AddWithValue("@AppointmentReminder", OptList)
                .AddWithValue("@Remark", meNote.Text.Trim)
                .AddWithValue("@IsExistImage", _IsExistImage)
                .AddWithValue("@Photo", GetImage)
                .AddWithValue("@User", LogUserNo)
                .Add("@isAdd", SqlDbType.Int)
                cmd.Parameters("@isAdd").Direction = ParameterDirection.Output
                .Add("@PatientCode", SqlDbType.NVarChar, 30)
                cmd.Parameters("@PatientCode").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            'Dim _PatientCode As String = ""
            Dim mms As MessageBoxIcon = MessageBoxIcon.Error
            If Convert.ToInt16(cmd.Parameters("@isAdd").Value) <> 0 Then
                EnabledButtonSave("Save", False)
                '_PatientCode = "This Patient Code is " + cmd.Parameters("@PatientCode").Value.ToString + "."
                mms = MessageBoxIcon.Information
            End If
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Register Patient", MessageBoxButtons.OK, mms)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        btnNew.Focus()
    End Sub

    Private Sub lueKhan_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueKhan.Closed
        Try
            GetDataToComboBoxWithParam(lueSangkat, "SA_GetSangkatList", "SangkatID", "Sangkat/Commune", New SqlParameter("@ID", 0), New SqlParameter("@KhanID", CInt(lueKhan.EditValue)), New SqlParameter("@Flag", 0))
            lueSangkat.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lueCity_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueCity.Closed
        Try
            GetDataToComboBoxWithParam(lueKhan, "SA_GetKhanList", "KhanID", "Khan/District", New SqlParameter("@ID", 0), New SqlParameter("@CityID", CInt(lueCity.EditValue)), New SqlParameter("@Flag", 0))
            lueKhan.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lueSangkat_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueSangkat.Closed
        Try
            GetDataToComboBoxWithParam(lueVillage, "SA_GetVillageList", "VillageID", "Village", New SqlParameter("@ID", 0), New SqlParameter("@SangkatID", CInt(lueSangkat.EditValue)), New SqlParameter("@Flag", 0))
            lueVillage.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lueVillage_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueVillage.Closed
        txtStreet.Focus()
    End Sub

    Private Sub txtCardID_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs)

    End Sub

    Private Sub txtPosition_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs)
        isFormPositionOpen = 1
        LoadFormDialog(frmPositionList)
    End Sub

    'Public Sub SelectPositionName(Find_ID As Integer)
    '    Try
    '        Dim dtTable As DataTable = GetDataFromDBToTable("SA_GetPositionsByID", New SqlParameter("@ID", Find_ID))
    '        With dtTable
    '            If .Rows.Count = 1 Then
    '                txtPosition.Text = .Rows(0)("PositionEn").ToString
    '                txtCellPhone.Focus()
    '            End If
    '        End With
    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message + vbNewLine + "Please see your system administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub lueNationality_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueNationality.Closed
        deDOB.Focus()
    End Sub

    Private Sub lueCampus_Closed(sender As Object, e As Controls.ClosedEventArgs)
        txtKLastName.Focus()
    End Sub

    Private Sub lueEmRelation_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueEmRelation.Closed
        txtEmCellPhone.Focus()
    End Sub

    Private Sub luePOBCity_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles luePOBCity.Closed
        Try
            GetDataToComboBoxWithParam(luePOBKhan, "SA_GetKhanList", "KhanID", "Khan/District", New SqlParameter("@ID", 0), New SqlParameter("@CityID", CInt(luePOBCity.EditValue)), New SqlParameter("@Flag", 0))
            luePOBKhan.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub luePOBKhan_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles luePOBKhan.Closed
        Try
            GetDataToComboBoxWithParam(luePOBSangkat, "SA_GetSangkatList", "SangkatID", "Sangkat/Commune", New SqlParameter("@ID", 0), New SqlParameter("@KhanID", CInt(luePOBKhan.EditValue)), New SqlParameter("@Flag", 0))
            luePOBSangkat.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub luePOBSangkat_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles luePOBSangkat.Closed
        Try
            GetDataToComboBoxWithParam(luePOBVillage, "SA_GetVillageList", "VillageID", "Village", New SqlParameter("@ID", 0), New SqlParameter("@SangkatID", CInt(luePOBSangkat.EditValue)), New SqlParameter("@Flag", 0))
            luePOBVillage.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub luePOBVillage_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles luePOBVillage.Closed
        txtPOBStreet.Focus()
    End Sub

    Private Sub lueOccupation_Closed(sender As Object, e As ClosedEventArgs) Handles lueOccupation.Closed
        txtCellPhone.Focus()
    End Sub

    Private Sub deRegistrationDate_KeyUp(sender As Object, e As KeyEventArgs) Handles deRegistrationDate.KeyUp
        txtPatientCode_KeyUp(sender, e)
    End Sub

    Private Sub txtPatientCode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPatientCode.KeyUp
        If (e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control) Then
            frmSearchEmployee._Option = "search_patient"
            LoadFormDialog(frmSearchEmployee)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If _TempPatientID = 0 OrElse String.IsNullOrEmpty(_TempPatientCode) Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            detected = XtraMessageBox.Show("Do you want to remove the selected Employee?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledItems(_TempPatientID, _TempPatientCode, 1)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisabledItems(_PatientID As Integer, _PatientCode As String, Optional _Inactive As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisablePatientByID", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@PatientID", _PatientID)
                .AddWithValue("@PatientCode", _PatientCode)
                .AddWithValue("@Inactive", _Inactive)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error

            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm Message", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class