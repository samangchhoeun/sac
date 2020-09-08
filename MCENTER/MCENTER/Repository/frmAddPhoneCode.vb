Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmAddPhoneCode
    Dim _ID As Integer = 0
    Public _Access As String = ""
    Dim _TCity As Integer = 0
    Dim _TKhan As Integer = 0
    Dim _TSangkat As Integer = 0

    Public Sub GetItemInfo(_CityID As Integer, _KhanID As Integer, _SangkatID As Integer)
        Try
            _TCity = _CityID
            _TKhan = _KhanID
            _TSangkat = _SangkatID
            If _Access = "phone_code" Then
                Dim dtData As DataTable = GetDataFromDBToTable("SA_GetCityList", New SqlParameter("@ID", _CityID), New SqlParameter("@Flag", 1))
                With dtData
                    If .Rows.Count = 1 Then
                        txtCity.Text = .Rows(0)("City").ToString
                        _ID = CInt(.Rows(0)("PID"))
                        _TCity = CInt(.Rows(0)("PID"))
                        txtLabelCode.Text = "Enter Phone Code"
                        txtCode.Text = .Rows(0)("PH_Code").ToString
                        txtCode.Select()
                    End If
                End With
            ElseIf _Access = "khan_postal_code" Then
                Dim dtData As DataTable = GetDataFromDBToTable("SA_GetKhanList", New SqlParameter("@ID", _KhanID), New SqlParameter("@CityID", _CityID), New SqlParameter("@Flag", 1))
                With dtData
                    If .Rows.Count = 1 Then
                        txtCity.Text = .Rows(0)("KhanEn").ToString
                        _ID = CInt(.Rows(0)("KhanID"))
                        _TKhan = CInt(.Rows(0)("KhanID"))
                        txtLabelCode.Text = "Enter Postal Code"
                        txtCode.Text = .Rows(0)("PostalCode").ToString
                        txtCode.Select()
                    End If
                End With
            ElseIf _Access = "sangkat_postal_code" Then
                Dim dtData As DataTable = GetDataFromDBToTable("SA_GetSangkatList", New SqlParameter("@ID", _SangkatID), New SqlParameter("@KhanID", _KhanID), New SqlParameter("@Flag", 1))
                With dtData
                    If .Rows.Count = 1 Then
                        txtCity.Text = .Rows(0)("SangkatEn").ToString
                        _ID = CInt(.Rows(0)("SangkatID"))
                        _TSangkat = CInt(.Rows(0)("SangkatID"))
                        txtLabelCode.Text = "Enter Postal Code"
                        txtCode.Text = .Rows(0)("PostalCode").ToString
                        txtCode.Select()
                    End If
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAddPhoneCode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress
        ValidNumber(sender, e)
    End Sub

    Private Sub txtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCode.Properties.Buttons(0).Enabled = True Then
                txtCode_ButtonClick(Nothing, Nothing)
            Else
                Dispose()
            End If
        End If
    End Sub

    Private Sub txtCode_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles txtCode.ButtonClick
        If _ID = 0 OrElse String.IsNullOrEmpty(txtCity.Text.Trim) OrElse String.IsNullOrEmpty(txtCode.Text.Trim) Then
            XtraMessageBox.Show("Please enter code to perform action", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return
        End If

        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_UpdateItemCode", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _ID)
                .AddWithValue("@Caption", txtCity.Text.Trim)
                .AddWithValue("@Code", txtCode.Text.Trim)
                .AddWithValue("@Flag", _Access)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            txtCode.ReadOnly = False
            txtCode.Properties.Buttons(0).Enabled = True
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            If IsAdd > 0 Then
                MMS = MessageBoxIcon.Information
                txtCode.ReadOnly = True
                txtCode.Properties.Buttons(0).Enabled = False
            End If

            If _Access = "phone_code" Then
                frmCambodiaAdminAreas.GetCityData()
            ElseIf _Access = "khan_postal_code" Then
                frmCambodiaAdminAreas.GetKhanData(_TCity)
            ElseIf _Access = "sangkat_postal_code" Then
                frmCambodiaAdminAreas.GetSangkatData(_TKhan)
            End If

            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Code", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class