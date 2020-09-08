Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmViewDoctor
    Dim _TempID As Integer = 0
    Dim _TempCardID As String = ""

    Private Sub frmViewDoctor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub


    Private Sub btnNew_Click(sender As Object, e As EventArgs)
        ClearAllContent()
    End Sub

    Private Sub ClearAllContent()
        _TempID = 0
        _TempCardID = ""
    End Sub

    Private Sub gcData_MouseClick(sender As Object, e As MouseEventArgs) Handles gcDoctor.MouseClick
        If e.Button = MouseButtons.Right Then pmDoctor.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub frmViewDoctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployeeToList()
        LoadDoctorToList()
    End Sub

    Public Sub LoadEmployeeToList(Optional ByVal _ID As String = "")
        Dim dt As DataTable = GetDataFromDBToTable("SA_GetEmployeeProfile", New SqlParameter("@CardID", _ID), New SqlParameter("@IsDoctor", 0), New SqlParameter("@Flag", 1))
        If dt.Rows.Count > 0 Then
            gcEmployee.DataSource = dt
            With gvEmployee
                .PopulateColumns()
                .Columns("ID").Visible = False
                .Columns("StaffNo").Visible = False
                .Columns("CardExpire").Visible = False
                .Columns("FirstName").Visible = False
                .Columns("LastName").Visible = False
                .Columns("KLastName").Visible = False
                .Columns("KFirstName").Visible = False
                .Columns("KhmerName").Visible = False
                .Columns("DOB").Visible = False
                .Columns("Age").Visible = False
                .Columns("PlaceOfBirth").Visible = False
                .Columns("MaritalStatus").Visible = False
                .Columns("Nationality").Visible = False
                .Columns("DepartmentEn").Visible = False
                .Columns("SectionEn").Visible = False
                .Columns("CampusEn").Visible = False
                .Columns("StartDate").Visible = False
                .Columns("NSSF").Visible = False
                .Columns("WorkBook").Visible = False
                .Columns("NationalID").Visible = False
                .Columns("NationalID_IssueDate").Visible = False
                .Columns("NationalID_ExpireDate").Visible = False
                .Columns("PassportNo").Visible = False
                .Columns("Passport_IssueDate").Visible = False
                .Columns("Passport_ExpireDate").Visible = False
                .Columns("CellPhone").Visible = False
                .Columns("HomePhone").Visible = False
                .Columns("Email").Visible = False
                .Columns("CurCity").Visible = False
                .Columns("CurKhan").Visible = False
                .Columns("CurSangkat").Visible = False
                .Columns("CurVillage").Visible = False
                .Columns("CurStreet").Visible = False
                .Columns("CurHome").Visible = False
                .Columns("EmContactName").Visible = False
                .Columns("EmRelation").Visible = False
                .Columns("EmCellPhone").Visible = False
                .Columns("EmHomePhone").Visible = False
                .Columns("Remark").Visible = False
                .Columns("Note").Visible = False
                .Columns("EmpStatus").Visible = False
                .Columns("DateResign").Visible = False
                .Columns("Inactive").Visible = False
                .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                .Columns("CardID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("ClinicEn").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Sex").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Inactive").Width = 120
                '.Columns("Inactive").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("ClinicEn").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                .Columns("ClinicEn").SummaryItem.DisplayFormat = "{0} Records"
                .BestFitColumns()
            End With
        Else
            gcEmployee.DataSource = Nothing
            gvEmployee.Columns.Clear()
        End If
    End Sub

    Public Sub LoadDoctorToList(Optional ByVal _ID As String = "")
        Dim dt As DataTable = GetDataFromDBToTable("SA_GetEmployeeProfile", New SqlParameter("@CardID", _ID), New SqlParameter("@IsDoctor", 1), New SqlParameter("@Flag", 0))
        If dt.Rows.Count > 0 Then
            gcDoctor.DataSource = dt
            With gvDoctor
                .PopulateColumns()
                .Columns("ID").Visible = False
                .Columns("StaffNo").Visible = False
                .Columns("CardExpire").Visible = False
                .Columns("FirstName").Visible = False
                .Columns("LastName").Visible = False
                .Columns("KLastName").Visible = False
                .Columns("KFirstName").Visible = False
                .Columns("KhmerName").Visible = False
                '.Columns("DOB").Visible = False
                .Columns("Age").Visible = False
                .Columns("PlaceOfBirth").Visible = False
                .Columns("MaritalStatus").Visible = False
                .Columns("Nationality").Visible = False
                .Columns("DepartmentEn").Visible = False
                .Columns("SectionEn").Visible = False
                .Columns("CampusEn").Visible = False
                .Columns("StartDate").Visible = False
                .Columns("NSSF").Visible = False
                .Columns("WorkBook").Visible = False
                .Columns("NationalID").Visible = False
                .Columns("NationalID_IssueDate").Visible = False
                .Columns("NationalID_ExpireDate").Visible = False
                .Columns("PassportNo").Visible = False
                .Columns("Passport_IssueDate").Visible = False
                .Columns("Passport_ExpireDate").Visible = False
                '.Columns("CellPhone").Visible = False
                '.Columns("HomePhone").Visible = False
                '.Columns("Email").Visible = False
                .Columns("CurCity").Visible = False
                .Columns("CurKhan").Visible = False
                .Columns("CurSangkat").Visible = False
                .Columns("CurVillage").Visible = False
                .Columns("CurStreet").Visible = False
                .Columns("CurHome").Visible = False
                .Columns("EmContactName").Visible = False
                .Columns("EmRelation").Visible = False
                .Columns("EmCellPhone").Visible = False
                .Columns("EmHomePhone").Visible = False
                .Columns("Remark").Visible = False
                .Columns("Note").Visible = False
                .Columns("EmpStatus").Visible = False
                .Columns("DateResign").Visible = False
                .Columns("Inactive").Visible = False
                .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                .Columns("CardID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("ClinicEn").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Sex").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                '.Columns("Inactive").Width = 120
                '.Columns("Inactive").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Email").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                .Columns("Email").SummaryItem.DisplayFormat = "{0} Records"
                .BestFitColumns()
            End With
        Else
            gcDoctor.DataSource = Nothing
            gvDoctor.Columns.Clear()
        End If
    End Sub

    Private Sub gcEmployee_MouseClick(sender As Object, e As MouseEventArgs) Handles gcEmployee.MouseClick
        If e.Button = MouseButtons.Right Then pmEmployee.ShowPopup(Me.bmMenu, Control.MousePosition)
    End Sub

    Private Sub bbiPDRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPDRefresh.ItemClick
        LoadDoctorToList()
    End Sub

    Private Sub bbiPRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRefresh.ItemClick
        LoadEmployeeToList()
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            With gvEmployee
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to remove the selected employees from doctor list?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ID").ToString)
                AssignAsDoctor(_ID.ToString)
            End With
        Catch ex As Exception
            ClearAllContent()
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try
        '    Dim SelRows() As Integer = gvDoctor.GetSelectedRows()
        '    If SelRows.Count <= 0 Then
        '        XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    End If

        '    Dim _IDTempList As String = ""
        '    Dim _TempID(SelRows.Count) As String
        '    Dim i As Integer = 0
        '    Dim MyChar() As Char = {","c, " "c, "|"c}
        '    For Each index As Integer In SelRows
        '        If index >= 0 Then
        '            Dim SelectedRow As DataRowView = DirectCast(gvDoctor.GetRow(index), DataRowView)
        '            _TempID(i) = SelectedRow("ID").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to remove the selected employees from doctor list?", "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    AssignAsDoctor(_IDTempList)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub AssignAsDoctor(Optional _IDTempList As String = "", Optional _IsDoctor As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_AssignAsDoctor", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@StrID", _IDTempList)
                .AddWithValue("@IsDoctor", _IsDoctor)
                .AddWithValue("@User", LogUserNo)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = Convert.ToInt16(cmd.Parameters("@IsAdd").Value)
            Dim MMS As MessageBoxIcon = MessageBoxIcon.Information
            If IsAdd = 0 Then MMS = MessageBoxIcon.Error
            LoadEmployeeToList()
            LoadDoctorToList()
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm Message", MessageBoxButtons.OK, MMS)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPAssignAsDoctor_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAssignAsDoctor.ItemClick
        Try
            With gvEmployee
                If .RowCount <= 0 Then
                    XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                detected = XtraMessageBox.Show("Do you want to assign the selected employees as doctor?", "Confirm Assign?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then Return
                Dim _ID As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ID").ToString)
                AssignAsDoctor(_ID.ToString, 1)
            End With
        Catch ex As Exception
            ClearAllContent()
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try
        '    Dim SelRows() As Integer = gvEmployee.GetSelectedRows()
        '    If SelRows.Count <= 0 Then
        '        XtraMessageBox.Show("There is no record selected to perform action.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    End If

        '    Dim _IDTempList As String = ""
        '    Dim _TempID(SelRows.Count) As String
        '    Dim i As Integer = 0
        '    Dim MyChar() As Char = {","c, " "c, "|"c}
        '    For Each index As Integer In SelRows
        '        If index >= 0 Then
        '            Dim SelectedRow As DataRowView = DirectCast(gvEmployee.GetRow(index), DataRowView)
        '            _TempID(i) = SelectedRow("ID").ToString()
        '            i += 1
        '        End If
        '    Next
        '    If i = 0 Then Exit Sub
        '    _IDTempList = String.Join(",", _TempID)
        '    _IDTempList = _IDTempList.TrimEnd(MyChar)

        '    detected = XtraMessageBox.Show("Do you want to assign the selected employees as doctor?", "Confirm Assign?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If detected = DialogResult.No Then Return
        '    AssignAsDoctor(_IDTempList, 1)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
End Class