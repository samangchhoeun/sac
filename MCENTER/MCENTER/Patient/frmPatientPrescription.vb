Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmPatientPrescription
    Dim ID As Integer = 0
    Dim TempPatientCode As String = ""

    Private Sub frmPatientPrescription_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub frmPatientPrescription_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoCompleteID(txtSID, "SA_GetPatientCodeList")
        deDatePrescribe.DateTime = Now.Date
        txtInputBy.Text = AccountName
        LoadClinic()
        LoadDoctor()
        txtSID.Select()
    End Sub

    Private Sub LoadClinic()
        Try
            GetDataToComboBoxWithParam(lueClinic, "SA_GetClinicByID", "ClinicID", "ClinicEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
            If Not IsNothing(ConfigClinic) Then
                lueClinic.EditValue = ConfigClinic.ClinicID
            Else
                lueClinic.EditValue = -1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDoctor()
        Try
            GetDataToComboBoxWithParam(lueDoctor, "SA_GetDoctorsToList", "ID", "Doctor", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then
            ClearAllContent()
            TempPatientCode = txtSID.Text.Trim
            If String.IsNullOrEmpty(TempPatientCode) Then
                XtraMessageBox.Show("Please enter Patient Code before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSID.Focus()
                Return
            End If
            txtSID.Text = txtSID.Text.Trim.ToUpper
            SelectPatientVisit(TempPatientCode)
        End If
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub ClearAllContent()
        ID = 0
        txtPatient.Text = ""
        txtOccupation.Text = ""
        txtCellPhone.Text = ""
        txtGender.Text = ""
        txtAge.Text = ""
        txtAddress.Text = ""
        txtDOB.Text = ""
        deDatePrescribe.DateTime = Now.Date
        lueGeneric.EditValue = -1
        lueMedication.EditValue = -1

        txtStrengthForm.Text = ""
        txtSOH.Text = ""
        txtQty.Text = ""
        txtMorning.Text = ""
        txtAfternoon.Text = ""
        txtEvening.Text = ""
        txtNight.Text = ""
        txtNote.Text = ""
        chkMedicationInstruction.UnCheckAll()
        chkMedicationUsage.UnCheckAll()
        gcAllergies.DataSource = Nothing
        gvAllergies.Columns.Clear()
        gcData.DataSource = Nothing
        gvData.Columns.Clear()
        gcIncompletRx.DataSource = Nothing
        gvIncompletRx.Columns.Clear()
        EnabledButtonSave()
    End Sub

    Private Sub SelectPatientVisit(_PatientCode As String)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientProfile", New SqlParameter("@PatientCode", _PatientCode))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True, True)
                    'EnabledEdit()
                    btnNew.Enabled = True
                    TempPatientCode = .Rows(0)("PatientCode").ToString
                    'txtSID.Text = GetPatientCode(.Rows(0)("PatientCode").ToString)
                    txtPatient.Text = .Rows(0)("EnglishName").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                    txtAge.Text = .Rows(0)("Age").ToString
                    txtCellPhone.Text = .Rows(0)("CellPhone").ToString
                    txtOccupation.Text = .Rows(0)("PTOccupation").ToString
                    txtAddress.Text = .Rows(0)("PTAddress").ToString
                    lueClinic.Focus()
                Else
                    ClearAllContent()
                    XtraMessageBox.Show("Searching keyword: " + _PatientCode + " doesnot exist on the target system. " & vbLf & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearAllContent()
        txtSID.ReadOnly = False
        btnNew.Enabled = False
        txtSID.Text = ""
        txtSID.Focus()
    End Sub

    Private Sub gcAllergies_MouseClick(sender As Object, e As MouseEventArgs) Handles gcAllergies.MouseClick
        If e.Button = MouseButtons.Right Then ppAllergies.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcData.MouseClick
        If e.Button = MouseButtons.Right Then ppMedicationHistory.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub gcIncompletRx_MouseClick(sender As Object, e As MouseEventArgs) Handles gcIncompletRx.MouseClick
        If e.Button = MouseButtons.Right Then ppRxIncomplete.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub bbiPAddMedication_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAddMedication.ItemClick
        XtraMessageBox.Show("Hello")
    End Sub

    Private Sub chkMedicationInstruction_SelectedValueChanged(sender As Object, e As EventArgs) Handles chkMedicationInstruction.SelectedValueChanged
        If chkMedicationInstruction.ItemCount > 0 Then chkMedicationInstruction.UnCheckAll()
    End Sub

    Private Sub chkMedicationUsage_SelectedValueChanged(sender As Object, e As EventArgs) Handles chkMedicationUsage.SelectedValueChanged
        If chkMedicationUsage.ItemCount > 0 Then chkMedicationUsage.UnCheckAll()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If chkMedicationInstruction.ItemCount > 0 Then
            For Each t In chkMedicationInstruction.CheckedItems
                XtraMessageBox.Show(t.ToString)
            Next
        End If

        If chkMedicationUsage.ItemCount > 0 Then
            For Each t In chkMedicationUsage.CheckedItems
                XtraMessageBox.Show(t.ToString)
            Next
        End If
    End Sub

    Private Sub bbiPCancel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPCancel.ItemClick

    End Sub
End Class