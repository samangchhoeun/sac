Public Class frm_searchOptionPopUp
    Public SearchFrom As String

    Private Sub Code_Txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Code_Txt.KeyPress
        If searchBy_cbo.Text = "Patient Code" Then
            ptCode_keyPress(Code_Txt, e)
        End If
    End Sub

    Private Sub searchBy_cbo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchBy_cbo.TextChanged
        Code_Txt.Text = ""
        If SearchFrom = "PHC-Payment" Then
            If searchBy_cbo.Text = "Invoice Number" Then
                Code_Txt.Text = "PHC"
            End If
        ElseIf SearchFrom = "Patient-Payment" Then
            If searchBy_cbo.Text = "Invoice Number" Then
                Code_Txt.Text = "IV"
            End If
        ElseIf SearchFrom = "Dispensary" Then
            If searchBy_cbo.Text = "Prescription Code" Then
                Code_Txt.Properties.MaxLength = 9
                Code_Txt.Text = "D"
            Else
                Code_Txt.Properties.MaxLength = 10
            End If
        End If
        Code_Txt.Focus()
    End Sub

    Private Sub Search_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search_cmd.Click
        If searchBy_cbo.Text.Trim <> "" And Code_Txt.Text.Trim <> "" Then
            If SearchFrom = "PHC-Payment" Then
                frm_PrimaryHealthCareProgramePayment.Search(Me.searchBy_cbo.Text, Code_Txt.Text)
            ElseIf SearchFrom = "Patient-Payment" Then
                If searchBy_cbo.Text = "Patient Code" Then
                    frm_patientPayment.ptCode_txt.Text = Code_Txt.Text
                    frm_patientPayment.ptCode_txt_Validated(sender, e)
                ElseIf searchBy_cbo.Text = "Invoice Number" Then
                    frm_patientPayment.SearchInvoiceNumber(Code_Txt.Text)
                End If
            ElseIf SearchFrom = "Dispensary" Then
                If searchBy_cbo.Text = "Patient Code" Then
                    frm_dispensary.ptCode_txt.Text = Code_Txt.Text
                    frm_dispensary.ptCode_txt_Validated(sender, e)
                ElseIf searchBy_cbo.Text = "Prescription Code" Then
                    frm_dispensary.SearchInvoiceNumber(Code_Txt.Text)
                End If
            End If
        Else
            MsgBox("Please input data to search", MsgBoxStyle.Information, "Confirm")
        End If
    End Sub

    Private Sub frm_searchOptionPrimaryHealthCareProgramPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Code_Txt.Text = ""
        searchBy_cbo.Text = ""
        searchBy_cbo.Properties.Items.Clear()

        If SearchFrom = "PHC-Payment" Then
            searchBy_cbo.Properties.Items.Add("Patient Code")
            searchBy_cbo.Properties.Items.Add("Group Nº")
            searchBy_cbo.Properties.Items.Add("Invoice Number")
        ElseIf SearchFrom = "Patient-Payment" Then
            searchBy_cbo.Properties.Items.Add("Patient Code")
            searchBy_cbo.Properties.Items.Add("Invoice Number")
        ElseIf SearchFrom = "Dispensary" Then
            searchBy_cbo.Properties.Items.Add("Patient Code")
            searchBy_cbo.Properties.Items.Add("Prescription Code")
        End If

    End Sub

    Private Sub moreSearch_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moreSearch_cmd.Click
        frm_searchPatientInformation.MdiParent = frm_MainForm
        frm_searchPatientInformation.Show()
        frm_searchPatientInformation.Focus()
    End Sub

End Class