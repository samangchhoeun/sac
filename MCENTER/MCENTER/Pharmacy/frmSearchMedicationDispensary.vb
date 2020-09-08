Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmSearchMedicationDispensary
    Public Opt As String = ""

    Private Sub frmSearchMedicationDispensary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub lueSearchOption_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueSearchOption.Closed
        InitSearchOption()
    End Sub

    Private Sub InithOption()
        Try
            GetDataToComboBoxFitColWithParam(lueSearchOption, "SA_SearchOptDispensary", "ID", "SearchOption", New SqlParameter("@Opt", Opt))
            lueSearchOption.ItemIndex = 0
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub


    Private Sub frmSearchMedicationDispensary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InithOption()
        InitSearchOption()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If lueSearchOption.Text.Trim <> "" And txtCode.Text.Trim <> "" Then
            If Opt = "PHC-Payment" Then
                'frm_PrimaryHealthCareProgramePayment.Search(Me.searchBy_cbo.Text, Code_Txt.Text)
            ElseIf Opt = "Patient-Payment" Then
                If lueSearchOption.Text.Trim = "Patient Code" Then
                    'frm_patientPayment.ptCode_txt.Text = Code_Txt.Text
                    'frm_patientPayment.ptCode_txt_Validated(sender, e)
                ElseIf lueSearchOption.Text.Trim = "Invoice Number" Then
                    'frm_patientPayment.SearchInvoiceNumber(Code_Txt.Text)
                End If
            ElseIf Opt = "Dispensary" Then
                If lueSearchOption.Text.Trim = "Patient Code" Then
                    frmMedicationDispensary.txtPatientCode.Text = txtCode.Text.Trim
                    frmMedicationDispensary.txtPatientCode_Validated(sender, e)
                ElseIf lueSearchOption.Text.Trim = "Prescription Code" Then
                    'frm_dispensary.SearchInvoiceNumber(Code_Txt.Text)
                End If
            End If
        Else
            XtraMessageBox.Show("Oops, please input code to search.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCode.Focus()
        End If
    End Sub

    Private Sub InitSearchOption()
        txtCode.Text = ""
        If Opt = "PHC-Payment" Then
            If lueSearchOption.Text.Trim = "Invoice Number" Then
                txtCode.Text = "PHC"
            End If
        ElseIf Opt = "Patient-Payment" Then
            If lueSearchOption.Text.Trim = "Invoice Number" Then
                txtCode.Text = "IV"
            End If
        ElseIf Opt = "Dispensary" Then
            If lueSearchOption.Text.Trim = "Prescription Code" Then
                txtCode.Properties.MaxLength = 9
                txtCode.Text = "D"
            Else
                txtCode.Properties.MaxLength = 11
            End If
        End If
        txtCode.Focus()
        txtCode.Select(txtCode.Text.Length + 1, 0)
    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress
        If lueSearchOption.Text.Trim = "Patient Code" Then PTCode_KeyPress(txtCode, e)
    End Sub

    Private Sub txtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.Enter Then btnSearch_Click(Nothing, Nothing)
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        LoadForm(frmSearchPatient)
        txtCode.Focus()
    End Sub
End Class