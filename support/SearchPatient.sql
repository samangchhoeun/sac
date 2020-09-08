Imports Microsoft.Office.Interop
Public Class frm_searchPatientInformation

    Private Sub ptCode_txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ptCode_txt.KeyPress
        ptCode_keyPress(ptCode_txt, e)
    End Sub

    Private Sub Start_DateEdit1_Closed(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles Start_DateEdit1.Closed
        If Start_DateEdit1.Text.Trim <> "" Then
            Start_DateEdit1.Text = Format(CDate(Start_DateEdit1.Text), "MMM dd, yyyy")
        End If
    End Sub
    Private Sub End_DateEdit2_Closed(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles End_DateEdit2.Closed
        If End_DateEdit2.Text.Trim <> "" Then
            End_DateEdit2.Text = Format(CDate(End_DateEdit2.Text), "MMM dd, yyyy")
        End If
    End Sub

    Private Sub Start_DateEdit1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Start_DateEdit1.Validated
        If Start_DateEdit1.Text.Trim <> "" Then
            Start_DateEdit1.Text = Format(CDate(Start_DateEdit1.Text), "MMM dd, yyyy")
        End If
    End Sub

    Private Sub End_DateEdit2_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles End_DateEdit2.Validated
        If End_DateEdit2.Text.Trim <> "" Then
            End_DateEdit2.Text = Format(CDate(End_DateEdit2.Text), "MMM dd, yyyy")
        End If
    End Sub

    Private Sub find_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles find_cmd.Click
        LoadList()
    End Sub

    Public Sub LoadList()
        Dim Table As New DataTable
        '        WHERE  isActive = 'True' AND CAST(CONVERT(NVARCHAR,regdate,107) AS Datetime) BETWEEN  '01/29/2012' AND '03/29/2012'  
        'AND ptcode='05005555' AND Ename LIKE '%prak%' AND Phone1='012 999 9999'
        Dim DateCriteria As String
        Dim ptCode As String
        Dim ptName As String
        Dim ptPhone As String
        Dim ptIDCard As String
        Dim ptDOB As String

        If Start_DateEdit1.Text.Trim <> "" And End_DateEdit2.Text.Trim <> "" Then
            DateCriteria = "AND CAST(CONVERT(NVARCHAR,regdate,107) AS Datetime) BETWEEN  '" & CDate(Me.Start_DateEdit1.Text) & "' AND '" & CDate(Me.End_DateEdit2.Text) & "'"
        ElseIf Start_DateEdit1.Text.Trim <> "" And End_DateEdit2.Text.Trim = "" Then
            DateCriteria = "AND CAST(CONVERT(NVARCHAR,regdate,107) AS Datetime) >=  '" & CDate(Me.Start_DateEdit1.Text) & "'"
        ElseIf Start_DateEdit1.Text.Trim = "" And End_DateEdit2.Text.Trim <> "" Then
            DateCriteria = "AND CAST(CONVERT(NVARCHAR,regdate,107) AS Datetime) <=  '" & CDate(Me.End_DateEdit2.Text) & "'"
        End If

        If ptCode_txt.Text.Trim <> "" Then
            ptCode = "AND ptcode='" & Get_Number(Me.ptCode_txt.Text) & "'"
        Else
            ptCode = ""
        End If

        If ptName_txt.Text.Trim <> "" Then
            ptName = "AND Ename LIKE '%" & ptName_txt.Text & "%'"
        Else
            ptName = ""
        End If

        If Phone_txt.Text.Trim <> "" Then
            ptPhone = "AND Phone1='" & Phone_txt.Text & "'"
        Else
            ptPhone = ""
        End If

        If IDCard_txt.Text <> "" Then
            ptIDCard = "AND IDCard='" & IDCard_txt.Text & "'"
        Else
            ptIDCard = ""
        End If

        If DateOfBirthDateEdit1.Text <> "" Then
            ptDOB = "AND convert(nvarchar,DateOfBirth,107) = '" & DateOfBirthDateEdit1.Text & "'"
        Else
            ptDOB = ""
        End If

        Table = Get_DataTable("SELECT convert(nvarchar,regDate,107) AS [Date Register], ptCode AS [Patient Code], kName[Khmer Name], eName AS [English Name], Gender, " & _
                              " convert(nvarchar,DateOfBirth,107) AS  [D.O.B.],year(GETDATE())-year(dateofBirth) AS Age, MaritalStatus, Phone1 AS Phone, Occupation, ptType AS [Patient Type], ProCity AS [Address], " & _
                              " IdCard,inputBy AS [Input by]  FROM tblPatient  WHERE  isActive = 'True' " & DateCriteria & ptCode & ptName & ptPhone & ptIDCard & ptDOB & " ORDER BY eName ")
        PatientList_GridViewControl.DataSource = Table

        If PatientList_GridView.RowCount > 0 Then

            ' LayoutControlGroup5.Text = "Patient List (" & PatientList_GridView.RowCount.ToString & ")"

            'PatientList_GridView.Columns(1).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

        Else
            PatientList_GridView.Columns.Clear()
            LayoutControlGroup5.Text = "Patient List"
        End If

    End Sub

    Private Sub clear_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clear_cmd.Click
        Start_DateEdit1.Text = ""
        End_DateEdit2.Text = ""
        ptCode_txt.Text = ""
        ptName_txt.Text = ""
        Phone_txt.Text = ""
        DateOfBirthDateEdit1.Text = ""
        IDCard_txt.Text = ""
        PatientList_GridView.Columns.Clear()
        ResultFound_Layout.Text = "Patient List"
    End Sub

    Private Sub PatientList_GridView_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatientList_GridView.ColumnFilterChanged

        Try
            If PatientList_GridView.RowCount > 0 Then
                LayoutControlGroup5.Text = "Patient List (" & PatientList_GridView.RowCount.ToString & ")"
            Else
                PatientList_GridView.Columns.Clear()
                LayoutControlGroup5.Text = "Patient List"
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub ExportExcel_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcel_cmd.Click
        ExportToExcel_Fu()
    End Sub
    Private Sub ExportToExcel_Fu()
        '=========initialize Excel Application=========
        Dim ExApp As New Excel.Application
        Dim Wbook As Excel.Workbook = ExApp.Workbooks.Add
        Dim Sheet As Excel.Worksheet = Wbook.Worksheets(1)
        '==============================================

        '==========Set Page Setup==========
        With Sheet
            .PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
            .PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            .PageSetup.Zoom = 75
        End With
        '==================================

        '=============LOGO=================
        Sheet.Shapes.AddPicture(Application.StartupPath & "\support image\Mengly J. Quach Student Health Center.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 105, 59)
        '==================================

        '===========Set Column Width===================
        With Sheet
            .Range("A1").ColumnWidth = 5
            .Range("B1").ColumnWidth = 11.7
            .Range("C1").ColumnWidth = 11.7
            .Range("D1").ColumnWidth = 18.7
            .Range("E1").ColumnWidth = 23.57
            .Range("F1").ColumnWidth = 7
            .Range("G1").ColumnWidth = 10
            .Range("H1").ColumnWidth = 4
            .Range("I1").ColumnWidth = 13
            .Range("J1").ColumnWidth = 11
            .Range("K1").ColumnWidth = 22
            .Range("L1").ColumnWidth = 12
            .Range("M1").ColumnWidth = 12

        End With
        '==============================================

        '=============Set Title=====================
        With Sheet
            .Range("A2", "L2").Merge()
            .Range("A2").Value = "Patient List"
            .Range("A2").Font.Size = 20
            .Range("A2").Font.Bold = True
            .Range("A2").HorizontalAlignment = 3
            '.Range("A4").Value = "Start Date: " & StartDate_Dtp.Text
            '.Range("A5").Value = "End Date: " & StopDate_Dtp.Text
            '.Range("A6").Value = "Clinic: " & clinic_cbo.Text
            '.Range("A7").Value = "Doctor: " & doctor_cbo.Text

        End With
        '=======================================

        '==========Set Column Header=============
        With Sheet
            .Range("A9").Value = "Nº"
            .Range("B9").Value = "Date Register"
            .Range("C9").Value = "Patient Code"
            .Range("D9").Value = "Khmer Name"
            .Range("E9").Value = "English Name"
            .Range("F9").Value = "Gender"
            .Range("G9").Value = "D.O.B."
            .Range("H9").Value = "Age"
            .Range("I9").Value = "Marital Status"
            .Range("J9").Value = "Phone"
            .Range("K9").Value = "Occupation"
            .Range("L9").Value = "Patient Type"
            .Range("M9").Value = "Address"

            .Range("A9", "M9").HorizontalAlignment = 3
            .Range("A9", "M9").Font.Bold = True
        End With
        '========================================

        Dim R As Integer = 10
        Dim j As Integer = 1



        '================Load Data from list=================
        For i As Integer = 0 To PatientList_GridView.RowCount - 1
            Sheet.Cells(R, 1) = j
            Sheet.Cells(R, 2) = PatientList_GridView.GetRowCellValue(i, "Date Register")
            Sheet.Cells(R, 3) = Set_Number(PatientList_GridView.GetRowCellValue(i, "Patient Code"))
            Sheet.Cells(R, 4) = PatientList_GridView.GetRowCellValue(i, "Khmer Name")
            Sheet.Cells(R, 5) = PatientList_GridView.GetRowCellValue(i, "English Name")
            Sheet.Cells(R, 6) = PatientList_GridView.GetRowCellValue(i, "Gender")
            Sheet.Cells(R, 7) = PatientList_GridView.GetRowCellValue(i, "D.O.B.")
            Sheet.Cells(R, 8) = PatientList_GridView.GetRowCellValue(i, "Age")
            Sheet.Cells(R, 9) = PatientList_GridView.GetRowCellValue(i, "MaritalStatus")
            Sheet.Cells(R, 10) = PatientList_GridView.GetRowCellValue(i, "Phone")
            Sheet.Cells(R, 11) = PatientList_GridView.GetRowCellValue(i, "Occupation")
            Sheet.Cells(R, 12) = PatientList_GridView.GetRowCellValue(i, "Patient Type")
            Sheet.Cells(R, 13) = PatientList_GridView.GetRowCellValue(i, "Address")
            Sheet.Range("B" & R).NumberFormat = "mmm dd, yyyy"

            R += 1
            j += 1
        Next
        '====================================================

        '==========Set Border============
        Sheet.Range("A9", "M" & R - 1).BorderAround(1)
        Sheet.Range("A9", "M" & R - 1).Borders.LineStyle = 1
        '================================
        ExApp.Visible = True

        '========Print Section==========
        'Frm_ChoosePrinter.ShowDialog(Me)
        'If PrinterName = "" Then Wbook.Close(False) : Exit Sub
        'If PrinterName = "Excel" Then
        '    ExApp.Visible = True
        'Else
        '    Sheet.PrintOutEx(, , NumberOfCopies, , PrinterName)
        '    Wbook.Close(False)
        'End If
        '=============================

    End Sub

    Private Sub PatientList_GridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatientList_GridView.DoubleClick
        If PatientList_GridView.RowCount > 0 Then
            frm_PatientFile.MdiParent = frm_MainForm
            frm_PatientFile.Show()
            frm_PatientFile.Focus()
            frm_PatientFile.ptCode_Txt.Text = Set_Number(PatientList_GridView.GetFocusedRow(1).ToString)
            frm_PatientFile.ptCode_Txt_LostFocus(sender, e)

        End If
    End Sub

    Private Sub DateOfBirthDateEdit1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateOfBirthDateEdit1.Validated
        If DateOfBirthDateEdit1.Text.Trim <> "" Then
            DateOfBirthDateEdit1.Text = Format(CDate(DateOfBirthDateEdit1.Text), "MMM dd, yyyy")
        End If

    End Sub

    Private Sub frm_searchPatientInformation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class