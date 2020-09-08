Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmPatientCheckOut
    Dim _PatientCode As String = ""

    Private Sub frmPatientCheckOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(ConfigClinic) Then
            lueClinic.EditValue = ConfigClinic.ClinicID
        Else
            lueClinic.EditValue = -1
        End If
        deCheckOutDate.DateTime = Now
        deCheckOutDate.Select()
    End Sub

    Public Sub LoadSearchItemByID(Optional _ClinicID As Integer = 0, Optional _VisitCode As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientCheckInList", New SqlParameter("@ClinicID", _ClinicID), New SqlParameter("@VisitCode", _VisitCode), New SqlParameter("@IsAdmin", isLoggedInOwner))
            With dtData
                If .Rows.Count = 1 Then
                    'EnabledButtonSave("&Update", True)
                    _VisitCode = CInt(.Rows(0)("VisitCode"))
                    txtSID.Text = FormatPatientCode(.Rows(0)("PatientCode").ToString)
                    _PatientCode = .Rows(0)("PatientCode").ToString
                    txtEnglishName.Text = .Rows(0)("EnglishName").ToString
                    Dim dob As String = .Rows(0)("DOB").ToString
                    If String.IsNullOrEmpty(dob) Then
                        deDOB.DateTime = DateTime.Now.AddYears(-18)
                    Else
                        deDOB.DateTime = CDate(dob)
                    End If
                    txtAge.Text = .Rows(0)("Age").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    txtMembership.Text = .Rows(0)("MembershipType").ToString
                    If CInt(.Rows(0)("ClinicID")) > 0 Then
                        GetDataToComboBoxWithParam(lueClinic, "SA_GetClinicByID", "ClinicID", "ClinicEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
                        lueClinic.EditValue = CInt(.Rows(0)("ClinicID"))
                    Else
                        lueClinic.EditValue = -1
                    End If

                    Dim DateIn As String = .Rows(0)("DateIn").ToString
                    If String.IsNullOrEmpty(DateIn) Then
                        deCheckIndate.DateTime = Now
                    Else
                        deCheckIndate.DateTime = Convert.ToDateTime(DateIn)
                    End If
                    deCheckOutDate.Enabled = True
                Else
                    ClearAllContent()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        deCheckOutDate.Select()
    End Sub

    Private Sub ClearAllContent()
        ' txtSID.Text = ""
        txtEnglishName.Text = ""
        txtGender.Text = ""
        txtAge.Text = ""
        deDOB.DateTime = Now.Date.AddYears(-18)
        deCheckOutDate.DateTime = Now
        'lueClinic.EditValue = -1
        If Not IsNothing(ConfigClinic) Then
            lueClinic.EditValue = ConfigClinic.ClinicID
        Else
            lueClinic.EditValue = -1
        End If
        'EnabledCheckIn(False)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub frmPatientCheckOut_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Escape Then Dispose()
    End Sub

    Private Sub deCheckOutDate_EditValueChanged(sender As Object, e As EventArgs) Handles deCheckOutDate.EditValueChanged
        txtNumDaysVisit.Text = GetNumDaysVisit(deCheckIndate.DateTime, deCheckOutDate.DateTime)
    End Sub
End Class