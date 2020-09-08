Imports DevExpress.XtraEditors

Public Class frmSearchMedication
    Public Opt As String = ""
    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSID_ButtonClick(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Dispose()
        End If
    End Sub

    Private Sub frmSearchMedication_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub txtSID_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles txtSID.ButtonClick
        Dim Find_ID As String = txtSID.Text.Trim

        If String.IsNullOrEmpty(Find_ID) Then
            XtraMessageBox.Show("Please enter code before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSID.Focus()
            Return
        End If

        txtSID.Text = txtSID.Text.Trim.ToUpper
        If Opt = "search_medication" Then
            frmStockCarts.SelectMedicationInfo(0, Find_ID, Find_ID)
        ElseIf Opt = "search_patient" Then
            frmPatient.GetEmployeeRecord(Find_ID)
        End If
        txtSID.Text = ""
    End Sub
End Class