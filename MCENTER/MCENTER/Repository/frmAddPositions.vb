Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmAddPositions
    Dim _ID As Integer = 0

    Private Sub frmAddPositions_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Public Sub GetSearchDataByID(Find_ID As Integer)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPositionsByID", New SqlParameter("@ID", Find_ID), New SqlParameter("@DeptID", 0))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True)
                    btnNew.Enabled = False
                    txtNumber.Text = .Rows(0)("PositionID").ToString
                    _ID = CInt(.Rows(0)("PositionID"))
                    txtPositionEn.Text = .Rows(0)("PositionEn").ToString
                    txtPositionKh.Text = .Rows(0)("PositionKh").ToString
                    meRemark.Text = .Rows(0)("Remark").ToString
                    lueDepartment.EditValue = CInt(.Rows(0)("DepartmentID"))
                Else
                    ClearIfNewContent()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        txtPositionEn.Select()
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        txtPositionKh.ReadOnly = Not en
        txtPositionEn.ReadOnly = Not en
        meRemark.ReadOnly = Not en
        lueDepartment.ReadOnly = Not en
    End Sub

    Private Sub ClearIfNewContent()
        txtNumber.Text = "***"
        _ID = 0
        txtPositionKh.Text = ""
        txtPositionEn.Text = ""
        meRemark.Text = ""
        lueDepartment.EditValue = -1
        EnabledButtonSave()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtPositionEn.Text.Trim) Then
            XtraMessageBox.Show("Please enter position name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPositionEn.Focus()
            Return
        End If

        Try
            If txtNumber.Text <> "***" Then _ID = CInt(txtNumber.Text.Trim)

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SavePosition", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", _ID)
                .AddWithValue("@DepartmentID", CInt(lueDepartment.EditValue))
                .AddWithValue("@Position", txtPositionEn.Text.Trim)
                .AddWithValue("@PositionKh", txtPositionKh.Text.Trim)
                .AddWithValue("@Remark", meRemark.Text.Trim)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            EnabledEdit()
            btnSave.Enabled = True
            btnNew.Enabled = False
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Error
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            If IsAdd > 0 Then
                MMS = MessageBoxIcon.Information
                EnabledEdit(False)
                btnSave.Enabled = False
                btnNew.Enabled = True
            End If

            frmViewPositions.LoadPositionsToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Add Positions", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnNew.Focus()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearIfNewContent()
        EnabledEdit()
        txtPositionEn.Focus()
    End Sub

    Private Sub frmAddPositions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GetDataToComboBoxWithParam(lueDepartment, "SA_GetAllDepartmentsList", "DepartmentID", "Department", New SqlParameter("@ClinicID", 0), New SqlParameter("@Flag", 1))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lueDepartment_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueDepartment.Closed
        txtPositionEn.Focus()
    End Sub
End Class