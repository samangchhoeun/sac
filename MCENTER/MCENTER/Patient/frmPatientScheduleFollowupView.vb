Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPatientScheduleFollowupView
    Dim PatientCode As String = ""

    Private Sub frmPatientScheduleFollowupView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deAppointmentDate.DateTime = Now.Date
        lueDoctor.EditValue = 0
        ccSchedule.DateTime = Now.Date
        LoadDoctor()
        InitDataToGrid()
    End Sub

    Private Sub LoadDoctor()
        Try
            GetDataToComboBoxWithParam(lueDoctor, "SA_GetDoctorsToList", "ID", "Doctor", New SqlParameter("@ID", 0), New SqlParameter("@isList", 2))
        Catch ex As Exception
        End Try
    End Sub

    Public Sub InitDataToGrid()
        Try
            gcData.DataSource = Nothing
            gvData.Columns.Clear()
            Dim fullData As New DataTable
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetDoctorsToList", New SqlParameter("@ID", CInt(lueDoctor.EditValue)), New SqlParameter("@isList", 3))
            With dt
                '''Bind column header to datatable
                fullData.Columns.Add("Time")
                If .Rows.Count > 0 Then
                    '''Bind doctors to column header on datatable
                    Dim j As Integer = 1
                    For i As Integer = 0 To .Rows.Count - 1
                        fullData.Columns.Add(.Rows(i)("Doctor").ToString)
                        j += 1
                    Next
                    '''end bind doctors to column header on datatable
                    '''

                    '''bind row cell to datatable
                    fullData.Rows.Clear()
                    Dim timStart As DateTime = Convert.ToDateTime("6:00 AM")
                    Dim timEnd As DateTime = Convert.ToDateTime("9:00 PM")
                    While (timStart <= timEnd)
                        Dim dr As DataRow = fullData.NewRow
                        dr(0) = timStart.ToShortTimeString
                        'Dim m As Integer = 1
                        'For i As Integer = 0 To .Rows.Count - 1
                        '    dr(m) = "Test" + m.ToString
                        '    m += 1
                        'Next
                        fullData.Rows.Add(dr)
                        timStart = timStart.AddMinutes(15)
                    End While


                    Dim ds As DataTable = GetDataFromDBToTable("SA_CheckPatientFollowup", New SqlParameter("@ID", 0), New SqlParameter("@DoctorID", CInt(lueDoctor.EditValue)), New SqlParameter("@SelDate", ccSchedule.DateTime), New SqlParameter("@PatientCode", ""), New SqlParameter("@NoDate", 0))
                    If ds.Rows.Count > 0 Then
                        With fullData
                            For m As Integer = 1 To .Columns.Count - 1
                                For Each Drow As DataRow In ds.Rows
                                    If .Columns(m).ColumnName = Drow("Doctor").ToString.Trim Then ' if Column Header = Drow DoctorName
                                        For n As Integer = 0 To .Rows.Count - 1 'LOOP ROW
                                            If .Rows(n)("Time").ToString <> Nothing Then ' Column Time
                                                If .Rows(n)("Time").ToString = Drow("TimeFU").ToString Then
                                                    '.Rows(n)(.Columns(m).ColumnName) = Drow("PatientCode").ToString
                                                    .Rows(n)(Drow("Doctor").ToString.Trim) = Drow("PatientCode").ToString & ", " & Drow("PatientName").ToString & ", " & Drow("Gender").ToString & ", " & Drow("Age").ToString
                                                End If
                                            End If
                                        Next
                                    End If
                                Next
                            Next
                        End With

                        '    'For Each Drow As DataRow In ds.Rows
                        '    '    For m As Integer = 1 To gvData.Columns.Count ' LOOP Column
                        '    '        If gvData.Columns(m).FieldName = Drow("Doctor").ToString.Trim Then ' if Column Header = Drow DoctorName
                        '    '            For i As Integer = 0 To gvData.DataRowCount - 1 'LOOP ROW
                        '    '                'Dim tmp As String
                        '    '                'If gvData.GetRowCellValue(i, "Time").ToString = Drow("TimeFU").ToString Then
                        '    '                '    'do something  
                        '    '                '    gvData.SetRowCellValue(i, Drow("Doctor").ToString.Trim, Drow("PatientCode").ToString & ", " & Drow("PatientName").ToString & ", " & Drow("Gender").ToString & ", " & Drow("Age").ToString)
                        '    '                'End If
                        '    '                If gvData.GetRowCellValue(i, "Time").ToString = Drow("TimeFU").ToString Then
                        '    '                    'do something  
                        '    '                    gvData.SetRowCellValue(i, Drow("Doctor").ToString.Trim, Drow("PatientCode").ToString & ", " & Drow("PatientName").ToString & ", " & Drow("Gender").ToString & ", " & Drow("Age").ToString)

                        '    '                End If

                        '    '            Next
                        '    '        End If
                        '    '    Next
                        '    'Next
                    End If
                End If

                gcData.DataSource = fullData
                gvData.Columns(0).Width = 80
                If .Rows.Count >= 1 Then
                    For k = 1 To .Rows.Count
                        gvData.Columns(k).Width = 150
                    Next
                End If
                gvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                gvData.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadPatientFollowup(_PatientCode As String)
        Try
            Dim ds As DataTable = GetDataFromDBToTable("SA_CheckPatientFollowup", New SqlParameter("@ID", 0), New SqlParameter("@DoctorID", CInt(lueDoctor.EditValue)), New SqlParameter("@SelDate", ccSchedule.DateTime), New SqlParameter("@PatientCode", _PatientCode), New SqlParameter("@NoDate", 0))
            With ds
                If .Rows.Count = 1 Then
                    txtCode.Text = .Rows(0)("PatientCodeF").ToString
                    txtPatient.Text = .Rows(0)("PatientName").ToString
                    txtGender.Text = .Rows(0)("Gender").ToString
                    txtDOB.Text = CDate(.Rows(0)("DOB")).ToString("MMM dd, yyyy")
                    txtCellPhone.Text = .Rows(0)("CellPhone").ToString
                    txtAge.Text = .Rows(0)("Age").ToString
                    txtDoctor.Text = .Rows(0)("Doctor").ToString
                    meNote.Text = .Rows(0)("Note").ToString
                Else
                    ClearAllContent()
                    gvData.Focus()
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub LoadDataToHeaderGridControl()
    '    gvData.Columns.Clear()
    '    '=================Create Time Label to GridView=======================================
    '    Dim Column = New GridColumn
    '    Column.Caption = "Time"
    '    Column.FieldName = "Time"
    '    Column.Width = 110
    '    Column.Visible = True
    '    gvData.Columns.Insert(0, Column)

    '    ''Bind Doctor name from database to GridView
    '    Try
    '        Dim dtData As DataTable = GetDataFromDBToTable("SA_GetDoctorsToList", New SqlParameter("@ID", CInt(lueDoctor.EditValue)), New SqlParameter("@isList", 3))
    '        With dtData
    '            If .Rows.Count > 0 Then
    '                Dim j As Integer = 1
    '                For i As Integer = 0 To .Rows.Count
    '                    Dim dbField = New GridColumn
    '                    dbField.Caption = .Rows(i)("Doctor").ToString
    '                    dbField.FieldName = .Rows(i)("Doctor").ToString
    '                    dbField.Width = 150
    '                    dbField.Visible = True
    '                    gvData.Columns.Insert(j, dbField)
    '                    gvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '                    j += 1
    '                Next
    '            End If
    '        End With

    '        'Dim column = gvData.Columns.AddVisible("Time", String.Empty)
    '        'gvData.Columns.Add(column)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub LoadDataToRowGridControl()
    '    LoadDataToHeaderGridControl()
    '    Dim i As Integer = 0
    '    While i < gvData.RowCount
    '        gvData.DeleteRow(i)
    '    End While
    '    Dim rd = New GridRow
    '    gvData.AddNewRow()
    '    'Dim rowHandle As Integer = gvData.GetRowHandle(gvData.DataRowCount)
    '    ''If gvData.IsNewItemRow(rowHandle) Then
    '    ''    gvData.SetRowCellValue(rowHandle, gvData.Columns(0), "A")
    '    ''    gvData.SetRowCellValue(rowHandle, gvData.Columns(1), "b")
    '    ''    gvData.SetRowCellValue(rowHandle, gvData.Columns(2), "b")
    '    ''End If        
    '    gvData.SetFocusedRowCellValue(gvData.Columns(0), "A")
    '    gvData.UpdateCurrentRow()
    '    gvData.RefreshData()

    '    'gvData.SetRowCellValue(rowHandle, gvData.Columns(1), "b")
    '    'gvData.SetRowCellValue(rowHandle, gvData.Columns(2), "b")

    '    '''Bind Doctor name from database to GridView
    '    'Try
    '    '    Dim dtData As DataTable = GetDataFromDBToTable("SA_GetDoctorsToList", New SqlParameter("@ID", CInt(lueDoctor.EditValue)), New SqlParameter("@isList", 3))
    '    '    With dtData
    '    '        If .Rows.Count > 0 Then
    '    '            Dim j As Integer = 1
    '    '            For i As Integer = 0 To .Rows.Count
    '    '                Dim dbField = New GridColumn
    '    '                dbField.Caption = .Rows(i)("Doctor").ToString
    '    '                dbField.FieldName = .Rows(i)("Doctor").ToString
    '    '                dbField.Width = 150
    '    '                dbField.Visible = True
    '    '                gvData.Columns.Insert(j, dbField)
    '    '                gvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '    '                j += 1
    '    '            Next
    '    '        End If
    '    '    End With

    '    '    'Dim column = gvData.Columns.AddVisible("Time", String.Empty)
    '    '    'gvData.Columns.Add(column)
    '    'Catch ex As Exception

    '    'End Try
    'End Sub

    Private Sub lueDoctor_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueDoctor.Closed
        InitDataToGrid()
    End Sub

    Private Sub gvData_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles gvData.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        With currentView
            Dim tempVal As DateTime = Convert.ToDateTime(.GetRowCellValue(e.RowHandle, .Columns(0)))
            If tempVal < Convert.ToDateTime("7:30 AM") Or (tempVal > Convert.ToDateTime("12:00 PM") And tempVal < Convert.ToDateTime("1:30 PM")) Or tempVal > Convert.ToDateTime("6:00 PM") Then
                'If e.Column.FieldName = "Time" Then e.Appearance.BackColor = Color.LightSlateGray
                e.Appearance.BackColor = Color.LightSlateGray
                'currentView.Columns(0).AppearanceCell.BackColor = Color.LightSlateGray
            Else
                If e.Column.FieldName = "Time" Then e.Appearance.BackColor = Color.FromArgb(&HCC, &HFF, &HFF)
            End If

            If e.Column.FieldName <> "Time" Then If .GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString <> "" Then e.Appearance.BackColor = Color.Khaki
        End With
    End Sub

    Private Sub gvData_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles gvData.RowCellClick
        Try
            With gvData
                If .FocusedColumn.GetTextCaption <> "Time" Then
                    PatientCode = .GetRowCellValue(.FocusedRowHandle, .FocusedColumn.GetTextCaption).ToString.Replace("-", "").Substring(0, 9)
                    'txtCode.Text = .GetRowCellValue(.FocusedRowHandle, .FocusedColumn.GetTextCaption).ToString.Substring(0, 11)
                    LoadPatientFollowup(PatientCode)
                Else
                    ClearAllContent()
                End If
            End With

        Catch ex As Exception
            ClearAllContent()
            txtDoctor.Text = gvData.FocusedColumn.GetTextCaption
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        InitDataToGrid()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAllContent()
        lueDoctor.Focus()
    End Sub

    Private Sub ClearAllContent()
        txtCode.Text = ""
        txtDoctor.Text = ""
        txtGender.Text = ""
        txtPatient.Text = ""
        txtCellPhone.Text = ""
        txtDOB.Text = ""
        txtAge.Text = ""
        meNote.Text = ""
    End Sub

    Private Sub gvData_DoubleClick(sender As Object, e As EventArgs) Handles gvData.DoubleClick
        If DateDiff(DateInterval.Day, Now.Date, ccSchedule.DateTime) < 0 OrElse (DateDiff(DateInterval.Day, Now.Date, ccSchedule.DateTime) = 0 AndAlso Convert.ToDateTime(gvData.GetRowCellValue(gvData.FocusedRowHandle, "Time").ToString) < Convert.ToDateTime(Now.ToLocalTime)) Then
            'detected = XtraMessageBox.Show("Do you want to reset the follow up schedule?", "Reset schedule?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            detected = XtraMessageBox.Show("Oops, something went wrong with your date and time selection." + vbNewLine + vbNewLine + "Do you want to reset the follow up schedule?", "Reset schedule?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If detected = DialogResult.No Then Return
            'ElseIf DateDiff(DateInterval.Day, Now.Date, ccSchedule.DateTime) = 0 AndAlso Convert.ToDateTime(gvData.GetRowCellValue(gvData.FocusedRowHandle, "Time").ToString) < Convert.ToDateTime(Now.ToLocalTime) Then
            '    XtraMessageBox.Show("Oops, something went wrong. Please select time again", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Return
        End If

        Try
            With gvData
                If .FocusedColumn.GetTextCaption <> "Time" Then
                    frmPatientFollowUp.TempDoctor = GetDoctorID(gvData.FocusedColumn.GetTextCaption)
                    frmPatientFollowUp.TempDate = ccSchedule.DateTime
                    frmPatientFollowUp.TempTime = gvData.GetRowCellValue(gvData.FocusedRowHandle, "Time").ToString
                    PatientCode = .GetRowCellValue(.FocusedRowHandle, .FocusedColumn.GetTextCaption).ToString.Replace("-", "").Substring(0, 9)
                    frmPatientFollowUp.LoadFollowUpSchedule(CInt(lueDoctor.EditValue), ccSchedule.DateTime, PatientCode)
                    'frmPatientFollowUp.LoadPatientFollowup(CInt(lueDoctor.EditValue), ccSchedule.DateTime, PatientCode)
                    LoadFormDialog(frmPatientFollowUp)
                Else
                    ClearAllContent()
                End If
            End With
        Catch ex As Exception
            ClearAllContent()
            txtDoctor.Text = gvData.FocusedColumn.GetTextCaption
            frmPatientFollowUp.TempDoctor = GetDoctorID(gvData.FocusedColumn.GetTextCaption)
            frmPatientFollowUp.TempDate = ccSchedule.DateTime
            frmPatientFollowUp.TempTime = gvData.GetRowCellValue(gvData.FocusedRowHandle, "Time").ToString
            frmPatientFollowUp.IsFormClick = True
            LoadFormDialog(frmPatientFollowUp)
        End Try
    End Sub

    Private Function GetDoctorID(Doctor As String) As Integer
        Dim TID As Integer = 0
        Dim dt As DataTable = GetDataFromDBToTable("SA_GetDoctorID", New SqlParameter("@Doctor", Doctor))
        If dt.Rows.Count = 1 Then TID = CInt(dt.Rows(0)("ID"))
        Return TID
    End Function

    Private Sub ccSchedule_DateTimeCommit(sender As Object, e As EventArgs) Handles ccSchedule.DateTimeCommit
        deAppointmentDate.DateTime = CDate(ccSchedule.DateTime.ToShortDateString)
        InitDataToGrid()
    End Sub
End Class