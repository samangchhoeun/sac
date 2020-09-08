Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmExchangeRate
    Dim _ID As Integer = 0

    Private Sub frmExchangeRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gcDate.Text = "Current Date: " + Now.ToShortDateString.ToString
        GetSearchItem()
    End Sub

    Private Sub deNotifyDate_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles deNotifyDate.Closed
        txtRate.Focus()
    End Sub

    Private Sub frmExchangeRate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtRate.Text.Trim) Then
            XtraMessageBox.Show("Please enter rate.", "Confirm Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRate.Focus()
            Return
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveExchangeRate", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _ID)
                .AddWithValue("@NotifyDate", CDate(deNotifyDate.DateTime))
                .AddWithValue("@Rate", txtRate.Text.Trim)
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
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Set Exchange Rate", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GetSearchItem(Optional Find_ID As Integer = 0)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetExchangeRate", New SqlParameter("@ID", Find_ID), New SqlParameter("@Flag", 1))
            With dtData
                If .Rows.Count = 1 Then
                    _ID = CInt(.Rows(0)("TranID"))
                    txtRate.Text = .Rows(0)("ExchangeRate").ToString
                    deNotifyDate.DateTime = CDate(.Rows(0)("NotifiedDate").ToString)
                Else
                    deNotifyDate.DateTime = Now.Date
                    txtRate.Text = ""
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
        txtRate.Text = ""
        deNotifyDate.Focus()
    End Sub

    Private Sub txtRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRate.KeyPress
        'ValidDecimal(sender, e)
    End Sub
End Class