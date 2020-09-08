Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmVAT
    Dim _ID As Integer = 0

    Private Sub frmVAT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub btnSetVAT_Click(sender As Object, e As EventArgs) Handles btnSetVAT.Click
        Try
            If String.IsNullOrEmpty(txtVAT.Text.Trim) Then txtVAT.Text = "0"
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveVAT", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _ID)
                .AddWithValue("@NotifyDate", CDate(deNotifyDate.DateTime))
                .AddWithValue("@VAT", txtVAT.Text.Trim)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            If IsAdd > 0 Then MMS = MessageBoxIcon.Information
            GetSearchItem()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Set VAT", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmVAT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gcDate.Text = "Current Date: " + Now.ToShortDateString.ToString
        GetSearchItem()
    End Sub

    Public Sub GetSearchItem(Optional Find_ID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetVAT", New SqlParameter("@ID", Find_ID), New SqlParameter("@Flag", 1))
            With dtData
                If .Rows.Count = 1 Then
                    _ID = CInt(.Rows(0)("TranID"))
                    txtVAT.Text = .Rows(0)("VAT").ToString
                    deNotifyDate.DateTime = CDate(.Rows(0)("NotifiedDate").ToString)
                Else
                    deNotifyDate.DateTime = Now.Date
                    txtVAT.Text = ""
                    _ID = 0
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        deNotifyDate.Select()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        _ID = 0
        deNotifyDate.DateTime = Now.Date
        txtVAT.Text = ""
        deNotifyDate.Focus()
    End Sub

    Private Sub txtVAT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVAT.KeyPress
        'ValidDecimal(sender, e)
    End Sub
End Class