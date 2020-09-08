Public Class frmModifyMedReason
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        frmMedicationStockIn.AdjustmentReason = ""
        If Not String.IsNullOrEmpty(meReason.Text.Trim) Then
            frmMedicationStockIn.AdjustmentReason = meReason.Text.Trim
            Dispose()
        End If
    End Sub

    Private Sub meReason_KeyDown(sender As Object, e As KeyEventArgs) Handles meReason.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnConfirm_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            frmMedicationStockIn.AdjustmentReason = ""
            Dispose()
        End If
    End Sub

    Private Sub frmModifyMedReason_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If String.IsNullOrEmpty(meReason.Text.Trim) Then frmMedicationStockIn.AdjustmentReason = ""
        Dispose()
    End Sub
End Class