Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmCopyHolidayTo
    Friend _IDList As String = ""
    Friend _SelNum As Integer = 0

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        deNewHolday.Enabled = False
        btnCopy.Enabled = False
        'IsOpenForm = 1
        _CopyDate = CDate(deNewHolday.EditValue)

        If _SelNum > 0 Then
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_CopyHolidayToNewHoliday", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDList)
                .AddWithValue("@NewHoliday", _CopyDate)
                .AddWithValue("@User", AccountName)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)

            Dim mms As MessageBoxIcon = MessageBoxIcon.Information
            If CInt(cmd.Parameters("@IsAdd").Value) = 0 Then mms = MessageBoxIcon.Error

            frmHolidayList.LoadHolidayToList(_SearchOption, _SDateFrom.ToString, _SDateTo.ToString)
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm message", MessageBoxButtons.OK, mms)
        End If
    End Sub

    Private Sub frmCopyHolidayTo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub frmCopyHolidayTo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deNewHolday.DateTime = Now.AddYears(1).Date
    End Sub
End Class