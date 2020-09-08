Imports DevExpress.XtraEditors

Public Class frmSearchEmployee
    Public _Option As String = ""

    Private Sub frmSearchEmployee_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSID_ButtonClick(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Dispose()
        End If
    End Sub

    Private Sub txtSID_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles txtSID.ButtonClick
        Dim Find_ID As String = txtSID.Text.Trim
        If String.IsNullOrEmpty(Find_ID) Then
            XtraMessageBox.Show("Please enter Employee ID before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSID.Focus()
            Return
        End If

        txtSID.Text = txtSID.Text.Trim.ToUpper
        If _Option = "search_employee" Then
            frmEmployee.GetEmployeeRecord(Find_ID)
        ElseIf _Option = "search_patient" Then
            frmPatient.GetEmployeeRecord(GetStandardPatientCode(Find_ID))
        End If
        'txtSID.Text = ""
    End Sub

    Private Sub frmSearchEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AutoCompleteID(txtSID, "SA_GetCardIDByCompany")
        If _Option = "search_patient" Then
            txtSID.Properties.MaxLength = 11
        ElseIf _Option = "search_employee" Then
            txtSID.Properties.MaxLength = 4
        End If
    End Sub

    Private Sub txtSID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSID.KeyPress
        If _Option = "search_patient" Then PTCodeButtonEdit_KeyPress(txtSID, e)
    End Sub
End Class