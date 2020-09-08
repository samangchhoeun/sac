Imports DevExpress.XtraEditors

Public Class frmReportWorkingHoursSearch
    Private Sub frmSearchWorkingHours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDBConnection()
        AutoCompleteID(txtSID, "SA_GetStaffIDByCompany")
        GetDataToComboBoxWithParam(lueDivision, "SA_GetAllDivisionList", "ID", "Division")
        lueDivision.ItemIndex = 0
        GetDataToComboBoxWithParam(lueCampus, "SA_GetAllCampusList", "Num", "Campus")
        lueCampus.ItemIndex = 0
        GetDataToComboBoxWithParam(lueDepartment, "SA_GetDepartmentForRemarkList", "ID", "Department")
        lueDepartment.ItemIndex = 0
        GetDataToComboBoxWithParam(lueCondition, "SA_GetAllWorkingConditions", "Code", "Condition")
        lueCondition.ItemIndex = 0
        deDateFrom.DateTime = CDate("2004-10-01")
        deDateTo.DateTime = Now.Date
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAllContent()

    End Sub

    Private Sub ClearAllContent()
        txtSID.Text = ""
        lueCampus.ItemIndex = 0
        lueDivision.ItemIndex = 0
        lueCondition.ItemIndex = 0
        lueDepartment.ItemIndex = 0
        chkAllDates.Checked = True
        deDateFrom.DateTime = CDate("2004-10-01")
        deDateTo.DateTime = Now.Date
        frmReportWorkingHours.gcEmploeeDetails.DataSource = Nothing
        frmReportWorkingHours.gvEmploeeDetails.Columns.Clear()
        txtSID.Focus()
    End Sub

    Private Sub chkAllDates_CheckStateChanged(sender As Object, e As EventArgs) Handles chkAllDates.CheckStateChanged
        EnabledEditDate(CBool(chkAllDates.Checked))
    End Sub

    Private Sub EnabledEditDate(Optional En As Boolean = True)
        deDateFrom.Enabled = Not En
        deDateTo.Enabled = Not En
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim _CardID As String = If(String.IsNullOrEmpty(txtSID.Text.Trim), "", txtSID.Text.Trim)
        Dim _Campus As Integer = CInt(lueCampus.EditValue.ToString)
        Dim _Division As Integer = CInt(lueDivision.EditValue.ToString)
        Dim _Department As Integer = CInt(lueDepartment.EditValue.ToString)
        Dim _Condition As String = lueCondition.EditValue.ToString
        Dim _DateFrom As String = deDateFrom.EditValue.ToString
        Dim _DateTo As String = deDateTo.EditValue.ToString
        Dim _IsAllDate As Boolean = CBool(chkAllDates.Checked)

        frmReportWorkingHours.GetDataListReportByEmpID(_Department, _Division, _Campus, _CardID, _Condition, _IsAllDate, _DateFrom, _DateTo)
        txtSID.Focus()
    End Sub

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrEmpty(txtSID.Text.Trim) Then
                XtraMessageBox.Show("Please enter Employee ID before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSID.Focus()
                Return
            End If

            Dim _CardID As String = If(String.IsNullOrEmpty(txtSID.Text.Trim), "", txtSID.Text.Trim)
            Dim _Campus As Integer = CInt(lueCampus.EditValue.ToString)
            Dim _Division As Integer = CInt(lueDivision.EditValue.ToString)
            Dim _Department As Integer = CInt(lueDepartment.EditValue.ToString)
            Dim _Condition As String = lueCondition.EditValue.ToString
            Dim _DateFrom As String = deDateFrom.EditValue.ToString
            Dim _DateTo As String = deDateTo.EditValue.ToString
            Dim _IsAllDate As Boolean = CBool(chkAllDates.Checked)

            frmReportWorkingHours.GetDataListReportByEmpID(_Department, _Division, _Campus, _CardID, _Condition, _IsAllDate, _DateFrom, _DateTo)
            txtSID.Focus()
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportToXlsx(frmReportWorkingHours.dtEmployeeList, "Employee Working Hours Report")
    End Sub
End Class