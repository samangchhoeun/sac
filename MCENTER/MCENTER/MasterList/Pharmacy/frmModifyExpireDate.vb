Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmModifyExpireDate
    Dim DrugDetailCode As Integer = 0
    Dim DrugMasterCode As Integer = 0

    Public Sub LoadMedExpiredDate(_lst As MedicationExpiredDate)
        DrugDetailCode = CInt(_lst.DrugDetailCode)
        DrugMasterCode = CInt(_lst.DrugMasterCode)
        txtInvoiceNo.Text = _lst.InvoiceNo
        txtMedCode.Text = _lst.MedCode
        txtBrandName.Text = _lst.BrandName
        txtQty.Text = _lst.Quantity
        txtSOH.Text = _lst.SOH
        Try
            deExpiredDate.DateTime = CDate(_lst.ExpiredDate)
        Catch ex As Exception
            deExpiredDate.DateTime = Now.Date
        End Try
        deExpiredDate.Select()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        detected = XtraMessageBox.Show("Are you sure to modify this medication <<" + txtBrandName.Text.Trim + ">> expired date ?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If detected = DialogResult.No Then Return

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_UpdateMedicationExpiredDate", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@DrugDetailCode", DrugDetailCode)
                .AddWithValue("@BrandName", txtBrandName.Text.Trim)
                .AddWithValue("@ExpiredDate", deExpiredDate.DateTime)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsUpdate", SqlDbType.Int)
                cmd.Parameters("@IsUpdate").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsUpdate").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error
            frmStockCarts.LoadSupplier(DrugMasterCode)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmModifyExpireDate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class