Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmAddSections
    Dim _ID As Integer = 0

    Private Sub frmAddSections_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Public Sub GetSearchDataByID(Find_ID As Integer)
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetSectionToListForAdmin", New SqlParameter("@SectionID", Find_ID), New SqlParameter("@DeptID", 0))
            With dtData
                If .Rows.Count = 1 Then
                    EnabledButtonSave("&Update", True)
                    btnNew.Enabled = False
                    txtNumber.Text = .Rows(0)("SectionID").ToString
                    _ID = CInt(.Rows(0)("SectionID"))
                    txtSectionEn.Text = .Rows(0)("SectionEn").ToString
                    txtSectionKh.Text = .Rows(0)("SectionKH").ToString
                    lueDepartment.EditValue = CInt(.Rows(0)("DepartmentID").ToString)
                Else
                    ClearIfNewContent()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + vbNewLine + "Please see contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        txtSectionEn.Select()
    End Sub

    Public Sub EnabledEdit(Optional en As Boolean = True)
        txtSectionKh.ReadOnly = Not en
        txtSectionEn.ReadOnly = Not en
        lueDepartment.ReadOnly = Not en
    End Sub

    Private Sub ClearIfNewContent()
        txtNumber.Text = "***"
        _ID = 0
        txtSectionKh.Text = ""
        txtSectionEn.Text = ""
        lueDepartment.ItemIndex = 0
        EnabledButtonSave()
    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True)
        btnSave.Text = txt
        btnSave.Enabled = en
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtSectionEn.Text.Trim) OrElse String.IsNullOrEmpty(lueDepartment.Text.Trim) Then
            XtraMessageBox.Show("Please enter section name.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSectionEn.Focus()
            Return
        End If

        Try
            Dim NewInsertID As Integer = 0
            If txtNumber.Text.Trim <> "***" Then NewInsertID = CInt(txtNumber.Text.Trim)

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveSection", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", NewInsertID)
                .AddWithValue("@DepartmentID", CInt(lueDepartment.EditValue))
                .AddWithValue("@SectionEn", txtSectionEn.Text.Trim)
                .AddWithValue("@SectionKH", txtSectionKh.Text.Trim)
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
            Dim IsChanged As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)

            If IsChanged <> 0 Then
                EnabledButtonSave("&Update", False)
                btnNew.Enabled = True
                EnabledEdit(False)
                MMS = MessageBoxIcon.Information

            End If

            frmViewSection.LoadSectionToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "New Section", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "New Section", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnNew.Focus()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearIfNewContent()
        EnabledEdit()
        lueDepartment.Focus()
    End Sub

    Private Sub frmAddSections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GetDataToComboBoxWithParam(lueDepartment, "SA_GetAllDepartmentsList", "DepartmentID", "Department", New SqlParameter("@ClinicID", 0), New SqlParameter("@Flag", 1))
            ' lueDepartment.EditValue = LogDeptID
        Catch ex As Exception

        End Try
        If IsOpenForm = 1 Then
            btnNew.Enabled = True
        Else
            btnNew.Enabled = False
        End If
    End Sub

    Private Sub lueDepartment_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueDepartment.Closed
        txtSectionEn.Focus()
    End Sub
End Class