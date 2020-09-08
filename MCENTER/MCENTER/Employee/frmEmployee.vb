Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmEmployee
    Public _TempCardID As String = ""
    Dim _TempID As Integer = 0
    Dim _PhotoBuffer As Byte()
    Dim _IsExistImage As Integer = 0
    Dim _ChangePhoto As String = "Browse..."
    Dim _PositionID As Integer = 0


    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deDOB.DateTime = Now.Date.AddYears(-18)
        deStartDate.DateTime = Now.Date
        deNationalID_IssueDate.DateTime = Now.Date
        dePassport_IssueDate.DateTime = Now.Date
        GetDataToComboBoxWithParam(lueNationality, "SA_GetNationalityList", "ID", "Nationality")
        'lueNationality.EditValue = 29
        GetDataToComboBoxWithParam(lueCity, "SA_GetCityList", "PID", "City/Province", New SqlParameter("@ID", 0), New SqlParameter("@Flag", 0))
        'lueCity.ItemIndex = 14
        GetDataToComboBoxWithParam(lueClinic, "SA_GetClinicByID", "ClinicID", "ClinicEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        'GetDataToComboBoxWithParam(lueDepartment, "SA_GetAllDepartmentsList", "DepartmentID", "Department", New SqlParameter("@Flag", 1))
        GetDataToComboBoxWithParam(lueCampus, "SA_GetCampusByID", "CampusID", "ABBR", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        GetDataToComboBoxWithParam(lueEmRelation, "SA_GetAllRelationsList", "RelationID", "Relation", New SqlParameter("@Flag", 1))
        txtKLastName.Select()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContents()
        EnabledButtonSave()
        txtKLastName.Select()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
        btnBrowse.Enabled = en
        btnDelete.Enabled = del
    End Sub

    Private Sub EnableEmployeeEdit(Optional En As Boolean = True)
        txtKLastName.Enabled = En
        txtKFirstName.Enabled = En
        txtFirstName.Enabled = En
        txtLastName.Enabled = En
        rgGender.Enabled = En
        rgMaritalStatus.Enabled = En
        lueNationality.Enabled = En
        deDOB.Enabled = En
        mePOB.Enabled = En
        txtCardID.Enabled = En
        txtPosition.Enabled = En
        lueClinic.Enabled = En
        lueDepartment.Enabled = En
        lueSection.Enabled = En
        lueCampus.Enabled = En
        deStartDate.Enabled = En
        txtNSSF.Enabled = En
        txtWorkBook.Enabled = En
        lueCity.Enabled = En
        lueKhan.Enabled = En
        lueSangkat.Enabled = En
        lueVillage.Enabled = En
        txtStreet.Enabled = En
        txtHome.Enabled = En
        txtCellPhone.Enabled = En
        txtHonePhone.Enabled = En
        txtEmail.Enabled = En
        txtNationalID.Enabled = En
        deNationalID_IssueDate.Enabled = En
        deNationalID_ExpireDate.Enabled = En
        txtPassportNo.Enabled = En
        dePassport_IssueDate.Enabled = En
        dePassport_ExpireDate.Enabled = En
        txtEmName.Enabled = En
        lueEmRelation.Enabled = En
        txtEmCellPhone.Enabled = En
        txtEmHomePhone.Enabled = En
        meNote.Enabled = En
        btnBrowse.Enabled = En
    End Sub

    Private Sub ClearAllContents()
        _TempID = 0
        _IsExistImage = 0
        _TempCardID = ""
        txtEmpCode.Text = "***"
        txtKLastName.Text = ""
        txtKFirstName.Text = ""
        txtLastName.Text = ""
        txtFirstName.Text = ""
        txtEmployeeID.Text = ""
        rgGender.SelectedIndex = 0
        rgMaritalStatus.SelectedIndex = 0
        'lueNationality.EditValue = 29
        lueNationality.EditValue = -1
        deDOB.DateTime = Now.Date.AddYears(-18)
        mePOB.Text = ""
        txtCardID.Text = ""
        txtPosition.Text = ""
        lueClinic.EditValue = -1
        lueDepartment.EditValue = -1
        lueSection.EditValue = -1
        lueCampus.EditValue = -1
        deStartDate.DateTime = Now.Date
        txtNSSF.Text = ""
        txtWorkBook.Text = ""
        lueCity.EditValue = -1
        'lueCity.ItemIndex = 14
        lueKhan.EditValue = -1
        lueSangkat.EditValue = -1
        lueVillage.EditValue = -1
        txtStreet.Text = ""
        txtHome.Text = ""
        txtCellPhone.Text = ""
        txtHonePhone.Text = ""
        txtEmail.Text = ""
        txtNationalID.Text = ""
        deNationalID_IssueDate.DateTime = Now.Date
        txtPassportNo.Text = ""
        dePassport_IssueDate.DateTime = Now.Date
        meNote.Text = ""
        txtEmName.Text = ""
        lueEmRelation.EditValue = -1
        txtEmCellPhone.Text = ""
        txtEmHomePhone.Text = ""
        picPhoto.Image = Nothing
        picPhoto.BackgroundImage = My.Resources.MJQE_Photo
        btnBrowse.Text = "Browse..."
        lciStatus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        meStatus.Visible = False
        meStatus.Text = ""
    End Sub

    Private Sub EnabledEmploymentEdit(Optional En As Boolean = True)
        txtPosition.ReadOnly = Not En
        lueClinic.ReadOnly = Not En
        lueDepartment.ReadOnly = Not En
        lueSection.ReadOnly = Not En
        lueCampus.ReadOnly = Not En
        txtCardID.ReadOnly = Not En
        txtCardID.Properties.Buttons(0).Enabled = En
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
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetEmployeeProfile", New SqlParameter("@CardID", Find_ID), New SqlParameter("@IsDoctor", 0), New SqlParameter("@Flag", 0))
            With dtData
                Dim i As Integer = .Rows.Count
                If i = 1 Then
                    _IsExistImage = 1
                    _TempID = CInt(.Rows(0)("StaffNo"))
                    _TempCardID = .Rows(0)("CardID").ToString
                    EnabledButtonSave("&Update", True, True)
                    EnabledEmploymentEdit(False)
                    txtEmpCode.Text = .Rows(0)("StaffNo").ToString
                    txtCardID.Text = .Rows(0)("CardID").ToString
                    txtEmployeeID.Text = .Rows(0)("CardID").ToString
                    txtFirstName.Text = .Rows(0)("FirstName").ToString
                    txtLastName.Text = .Rows(0)("LastName").ToString
                    txtKFirstName.Text = .Rows(0)("KFirstName").ToString
                    txtKLastName.Text = .Rows(0)("KLastName").ToString
                    rgGender.EditValue = .Rows(0)("Sex").ToString
                    rgMaritalStatus.EditValue = .Rows(0)("MaritalStatus").ToString

                    If Not String.IsNullOrEmpty(.Rows(0)("Nationality").ToString) Then
                        lueNationality.Text = .Rows(0)("Nationality").ToString
                    Else
                        lueNationality.EditValue = -1
                    End If

                    Dim dob As String = .Rows(0)("DOB").ToString
                    If String.IsNullOrEmpty(dob) Then
                        deDOB.DateTime = DateTime.Now.AddYears(-18)
                    Else
                        deDOB.DateTime = Convert.ToDateTime(dob)
                    End If
                    mePOB.Text = .Rows(0)("PlaceOfBirth").ToString

                    txtPosition.Text = .Rows(0)("PositionEn").ToString
                    _PositionID = CInt(.Rows(0)("PositionID"))

                    If CInt(.Rows(0)("ClinicID")) > 0 Then
                        lueClinic.EditValue = CInt(.Rows(0)("ClinicID"))
                    Else
                        lueClinic.EditValue = -1
                    End If

                    If CInt(.Rows(0)("DepartmentID")) > 0 Then
                        GetDataToComboBoxWithParam(lueDepartment, "SA_GetDepartmentByID", "DepartmentID", "Department", New SqlParameter("@ID", 0), New SqlParameter("@ClinicID", 0), New SqlParameter("@isList", 1))
                        lueDepartment.EditValue = CInt(.Rows(0)("DepartmentID"))
                    Else
                        lueDepartment.EditValue = -1
                    End If

                    If CInt(.Rows(0)("SectionID")) > 0 Then
                        GetDataToComboBoxWithParam(lueSection, "SA_GetSectionToListForAdmin", "SectionID", "SectionEn", New SqlParameter("@SectionID", 0), New SqlParameter("@DeptID", CInt(lueDepartment.EditValue)))
                        lueSection.EditValue = CInt(.Rows(0)("SectionID"))
                    Else
                        lueSection.EditValue = -1
                    End If

                    If CInt(.Rows(0)("CampusID")) > 0 Then
                        lueCampus.EditValue = CInt(.Rows(0)("CampusID"))
                    Else
                        lueCampus.EditValue = -1
                    End If

                    Dim StartDate As String = .Rows(0)("StartDate").ToString
                    If String.IsNullOrEmpty(StartDate) Then
                        deStartDate.DateTime = Now.Date
                    Else
                        deStartDate.DateTime = Convert.ToDateTime(StartDate)
                    End If

                    txtNSSF.Text = .Rows(0)("NSSF").ToString
                    txtWorkBook.Text = .Rows(0)("WorkBook").ToString

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

                    txtStreet.Text = .Rows(0)("CurStreet").ToString
                    txtHome.Text = .Rows(0)("CurHome").ToString
                    txtCellPhone.Text = .Rows(0)("CellPhone").ToString
                    txtHonePhone.Text = .Rows(0)("HomePhone").ToString
                    txtEmail.Text = .Rows(0)("Email").ToString.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(" ", "")

                    txtNationalID.Text = .Rows(0)("NationalID").ToString
                    Dim ID_IssueDate As String = .Rows(0)("NationalID_IssueDate").ToString
                    If String.IsNullOrEmpty(ID_IssueDate) Then
                        deNationalID_IssueDate.DateTime = Now.Date
                    Else
                        deNationalID_IssueDate.DateTime = Convert.ToDateTime(ID_IssueDate)
                    End If

                    Dim ID_ExpireDate As String = .Rows(0)("NationalID_ExpireDate").ToString
                    If String.IsNullOrEmpty(ID_ExpireDate) Then
                        deNationalID_ExpireDate.DateTime = Now.Date
                    Else
                        deNationalID_ExpireDate.DateTime = Convert.ToDateTime(ID_ExpireDate)
                    End If

                    txtPassportNo.Text = .Rows(0)("PassportNo").ToString
                    Dim Passport_IssueDate As String = .Rows(0)("Passport_IssueDate").ToString
                    If String.IsNullOrEmpty(Passport_IssueDate) Then
                        dePassport_IssueDate.DateTime = Now.Date
                    Else
                        dePassport_IssueDate.DateTime = Convert.ToDateTime(Passport_IssueDate)
                    End If

                    Dim Passport_ExpireDate As String = .Rows(0)("Passport_ExpireDate").ToString
                    If String.IsNullOrEmpty(Passport_ExpireDate) Then
                        dePassport_ExpireDate.DateTime = Now.Date
                    Else
                        dePassport_ExpireDate.DateTime = Convert.ToDateTime(Passport_ExpireDate)
                    End If

                    txtEmName.Text = .Rows(0)("EmContactName").ToString
                    If CInt(.Rows(0)("EmRelation")) > 0 Then
                        lueEmRelation.EditValue = CInt(.Rows(0)("EmRelation"))
                    Else
                        lueEmRelation.EditValue = -1
                    End If

                    txtEmCellPhone.Text = .Rows(0)("EmCellPhone").ToString
                    txtEmHomePhone.Text = .Rows(0)("EmHomePhone").ToString
                    LoadProfilePhoto(.Rows(0)("Photo"), picPhoto)
                    _PhotoBuffer = CType(.Rows(0)("Photo"), Byte())
                    If CBool(.Rows(0)("Inactive")) Then
                        meStatus.Visible = True
                        lciStatus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                        meStatus.Text = "This employee has been removed. Please contact System Administrator to restore this employee."
                        btnDelete.Enabled = False
                    Else
                        lciStatus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                        meStatus.Visible = False
                        btnDelete.Enabled = True
                        meStatus.Text = ""
                    End If
                    frmSearchEmployee.Dispose()
                Else
                    EnabledEmploymentEdit()
                    ClearAllContents()
                    XtraMessageBox.Show("Searching keyword: " + Find_ID + " doesnot exist on the target system. " & vbLf & "Please try another Card ID.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtKLastName.Focus()
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
        frmSearchEmployee._Option = "search_employee"
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
                txtFirstName.Focus()
                Return
            ElseIf String.IsNullOrEmpty(txtCardID.Text.Trim()) OrElse String.IsNullOrEmpty(txtPosition.Text.Trim()) OrElse String.IsNullOrEmpty(txtEmail.Text.Trim()) OrElse String.IsNullOrEmpty(txtCellPhone.Text.Trim()) Then
                XtraMessageBox.Show("Some fields are blank. Please check it.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCardID.Focus()
                Return
            ElseIf String.IsNullOrEmpty(lueClinic.Text) OrElse String.IsNullOrEmpty(lueDepartment.Text) OrElse String.IsNullOrEmpty(lueCampus.Text) Then
                XtraMessageBox.Show("Please select the mandatory information from the box.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lueClinic.Focus()
                Return
            End If
        End If

        Try
            Dim _Clinic As Object = lueClinic.EditValue
            Dim _Department As Object = lueDepartment.EditValue
            Dim _Section As Object = lueSection.EditValue
            Dim _Campus As Object = lueCampus.EditValue
            Dim _City As Object = lueCity.EditValue
            Dim _Khan As Object = lueKhan.EditValue
            Dim _Sangkat As Object = lueSangkat.EditValue
            Dim _Village As Object = lueVillage.EditValue
            Dim _Nationality As Object = lueNationality.EditValue
            Dim _EmRelation As Object = lueEmRelation.EditValue

            Dim _Gender As String = rgGender.EditValue.ToString
            Dim _MaritalStatus As String = rgMaritalStatus.EditValue.ToString
            Dim _FirstName As String = ToTitleCase(txtFirstName.Text.Trim)
            Dim _LastName As String = ToTitleCase(txtLastName.Text.Trim)
            Dim _EmName As String = ToTitleCase(txtEmName.Text.Trim)

            Dim ID As String = txtCardID.Text.Trim.ToUpper
            Dim NewInsertID As Integer = 0
            If txtEmpCode.Text.Trim <> "***" Then NewInsertID = CInt(txtEmpCode.Text.Trim)

            Dim GetImage As Object = 0
            If IsArray(_PhotoBuffer) Then GetImage = _PhotoBuffer

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveEmployeeProfile", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StaffNo", NewInsertID)
                .AddWithValue("@CardID", ID)
                .AddWithValue("@KLastName", txtKLastName.Text.Trim)
                .AddWithValue("@KFirstName", txtKFirstName.Text.Trim)
                .AddWithValue("@FirstName", _FirstName)
                .AddWithValue("@LastName", _LastName)
                .AddWithValue("@Sex", _Gender)
                .AddWithValue("@DOB", deDOB.DateTime)
                .AddWithValue("@MaritalStatus", _MaritalStatus)
                .AddWithValue("@Nationality", CInt(_Nationality))
                .AddWithValue("@PlaceOfBirth", mePOB.Text.Trim)
                .AddWithValue("@PositionID", _PositionID)
                .AddWithValue("@Clinic", CInt(_Clinic))
                .AddWithValue("@Department", CInt(_Department))
                .AddWithValue("@Section", CInt(_Section))
                .AddWithValue("@Campus", CInt(_Campus))
                .AddWithValue("@StartDate", deStartDate.DateTime)
                .AddWithValue("@NSSF", txtNSSF.Text.Trim)
                .AddWithValue("@WorkBookNo", txtWorkBook.Text.Trim)
                .AddWithValue("@CurCity", CInt(_City))
                .AddWithValue("@CurKhan", CInt(_Khan))
                .AddWithValue("@CurSangkat", CInt(_Sangkat))
                .AddWithValue("@CurVillage", CInt(_Village))
                .AddWithValue("@CurStreet", txtStreet.Text.Trim)
                .AddWithValue("@CurHome", txtHome.Text.Trim)
                .AddWithValue("@CellPhone", txtCellPhone.Text.Trim)
                .AddWithValue("@HomePhone", txtHonePhone.Text.Trim)
                .AddWithValue("@Email", txtEmail.Text.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(" ", ""))
                .AddWithValue("@NationalID", txtNationalID.Text.Trim)
                .AddWithValue("@NationalID_IssueDate", deNationalID_IssueDate.DateTime)
                .AddWithValue("@NationalID_ExpireDate", deNationalID_ExpireDate.DateTime)
                .AddWithValue("@PassportNo", txtPassportNo.Text.Trim)
                .AddWithValue("@Passport_IssueDate", dePassport_IssueDate.DateTime)
                .AddWithValue("@Passport_ExpireDate", dePassport_ExpireDate.DateTime)
                .AddWithValue("@Remark", meRemark.Text.Trim)
                .AddWithValue("@EmContactName", _EmName)
                .AddWithValue("@EmRelation", CInt(_EmRelation))
                .AddWithValue("@EmCellPhone", txtEmCellPhone.Text.Trim)
                .AddWithValue("@EmHomePhone", txtEmHomePhone.Text.Trim)
                .AddWithValue("@Note", meNote.Text.Trim)
                .AddWithValue("@IsExistImage", _IsExistImage)
                .AddWithValue("@Photo", GetImage)
                .AddWithValue("@User", LogUserNo)
                .Add("@isAdd", SqlDbType.Int)
                cmd.Parameters("@isAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)

            Dim mms As MessageBoxIcon = MessageBoxIcon.Error
            If Convert.ToInt16(cmd.Parameters("@isAdd").Value) <> 0 Then
                EnabledButtonSave("Save", False)
                mms = MessageBoxIcon.Information
            End If
            XtraMessageBox.Show(cmd.Parameters("@msg").Value.ToString, "Employee Info", MessageBoxButtons.OK, mms)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        btnNew.Focus()
    End Sub

    Private Sub deNationalID_IssueDate_EditValueChanged(sender As Object, e As EventArgs) Handles deNationalID_IssueDate.EditValueChanged
        deNationalID_ExpireDate.DateTime = deNationalID_IssueDate.DateTime.AddYears(10).AddDays(-1)
    End Sub

    Private Sub dePassport_IssueDate_EditValueChanged(sender As Object, e As EventArgs) Handles dePassport_IssueDate.EditValueChanged
        dePassport_ExpireDate.DateTime = dePassport_IssueDate.DateTime.AddYears(10).AddDays(-1)
    End Sub

    Private Sub lueClinic_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueClinic.Closed
        Try
            GetDataToComboBoxWithParam(lueDepartment, "SA_GetDepartmentByID", "DepartmentID", "Department", New SqlParameter("@ID", 0), New SqlParameter("@ClinicID", 0), New SqlParameter("@isList", 1))
            lueCampus.Focus()
        Catch ex As Exception

        End Try
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

    Private Sub txtCardID_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles txtCardID.ButtonClick

    End Sub

    Private Sub txtPosition_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles txtPosition.ButtonClick
        If String.IsNullOrEmpty(lueDepartment.Text) Then
            XtraMessageBox.Show("Please select department from the box.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lueDepartment.Focus()
            Return
        End If
        isFormPositionOpen = 1
        frmPositionList.DeptID = CInt(lueDepartment.EditValue)
        LoadFormDialog(frmPositionList)
        deStartDate.Focus()
    End Sub

    Public Sub SelectPositionName(Find_ID As Integer)
        Try
            Dim dtTable As DataTable = GetDataFromDBToTable("SA_GetPositionsByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@DeptID", 0))
            With dtTable
                If .Rows.Count = 1 Then
                    txtPosition.Text = .Rows(0)("PositionEn").ToString
                    _PositionID = CInt(.Rows(0)("PositionID"))
                    deStartDate.Focus()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see your system administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lueNationality_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueNationality.Closed
        deDOB.Focus()
    End Sub

    Private Sub lueDepartment_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueDepartment.Closed
        Try
            GetDataToComboBoxWithParam(lueSection, "SA_GetSectionToListForAdmin", "SectionID", "SectionEn", New SqlParameter("@SectionID", 0), New SqlParameter("@DeptID", CInt(lueDepartment.EditValue)))
            lueSection.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lueSection_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueSection.Closed
        txtPosition.Focus()
    End Sub

    Private Sub lueCampus_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueCampus.Closed
        lueDepartment.Focus()
    End Sub

    Private Sub lueEmRelation_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueEmRelation.Closed
        txtEmCellPhone.Focus()
    End Sub

    Private Sub deDOB_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles deDOB.Closed
        mePOB.Focus()
    End Sub

    Private Sub txtKLastName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtKLastName.KeyUp
        If (e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control) Then
            frmSearchEmployee._Option = "search_employee"
            LoadFormDialog(frmSearchEmployee)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub DisabledItems(_StaffNo As Integer, _CardID As String, Optional _Inactive As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_DisableEmployeeByID", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StaffNo", _StaffNo)
                .AddWithValue("@CardID", _CardID)
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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If _TempID = 0 OrElse String.IsNullOrEmpty(_TempCardID) Then
                XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            detected = XtraMessageBox.Show("Do you want to remove the selected Employee?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            DisabledItems(_TempID, _TempCardID, 1)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class