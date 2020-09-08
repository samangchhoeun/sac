Imports DevExpress.XtraEditors

Public Class frmSearchInvoiceStockIn
    Public Opt As String = ""

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSID_ButtonClick(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Dispose()
        End If
    End Sub

    Private Sub frmSearchInvoiceStockIn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
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
        If Opt = "OtherDispensary" Then
            'frm_OtherDispensary.SearchByPrescriptionCode(ivSearch_txt.Text)
        ElseIf Opt = "StockIn" Then
            frmMedicationStockIn.Opt = "search-invoice-stockin"
            frmMedicationStockIn.SearchMedicationByInvoice(txtSID.Text.Trim)
        ElseIf Opt = "LabQtyRecieved" Then
            'frm_LabQtyRecieved.Search_By_InvoiceNumber(Me.ivSearch_txt.Text)
        ElseIf Opt = "Transfer" Then
            'frm_transferStock.Search_By_InvoiceNumber(Me.ivSearch_txt.Text)
        End If

        'InitInvoiceCode()
    End Sub

    Private Sub frmSearchInvoiceStockIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitInvoiceCode()
    End Sub

    Private Sub InitInvoiceCode()
        txtSID.Text = ""
        Select Case Opt
            Case "OtherDispensary"
                txtSID.Text = "OD" + DateTime.Now.ToString("yy")
                Text = "Prescription Code"
            Case "StockIn"
                txtSID.Text = "IV" + DateTime.Now.ToString("yy")
                Text = "Invoice Number"
            Case "LabQtyRecieved"
                txtSID.Text = "LB" + DateTime.Now.ToString("yy")
                Text = "Invoice Number"
            Case Else
                txtSID.Text = ""
                Text = "Invoice Number"
        End Select
        txtSID.Select(txtSID.Text.Length + 1, 0)
    End Sub
End Class