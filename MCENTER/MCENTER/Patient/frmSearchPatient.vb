Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading.Tasks
Imports ClosedXML.Excel
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports Microsoft.SqlServer

Public Class frmSearchPatient
    Dim dtData As New DataTable

    Private Async Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Await LoadPatientToList()
    End Sub

    Private Sub txtPatientCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPatientCode.KeyPress
        PTCode_KeyPress(txtPatientCode, e)
    End Sub

    Private Async Function LoadPatientToList() As Task
        Try
            frmLoadingData.Show()
            Me.Cursor = Cursors.WaitCursor
            gcPatients.Cursor = Cursors.WaitCursor
            Await Task.Delay(200)
            dtData = GetDataFromDBToTable("SA_SearchPatientOption",
                                                       New SqlParameter("@StartDate", deStartDate.Text.Trim),
                                                       New SqlParameter("@EndDate", deEndDate.Text.Trim),
                                                       New SqlParameter("@PatientCode", GetStandardPatientCode(txtPatientCode.Text.Trim)),
                                                       New SqlParameter("@PatientName", txtPatientName.Text.Trim),
                                                       New SqlParameter("@DOB", deDOB.Text.Trim),
                                                       New SqlParameter("@Phone", txtPhone.Text.Trim))
            If dtData.Rows.Count > 0 Then
                gcPatients.DataSource = dtData
                With gvPatients
                    .PopulateColumns()
                    '.Columns("DrugDetailCode").Visible = False
                    '.Columns("InvoiceMedicalStockInCode").Visible = False
                    '.Columns("DrugMasterCode").Visible = False
                    .Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                    .Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center
                    .Columns("KhmerName").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .Columns("EnglishName").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
                    .BestFitColumns()
                End With
            Else
                gcPatients.DataSource = Nothing
                gvPatients.Columns.Clear()
            End If
            frmLoadingData.Hide()
            Me.Cursor = Cursors.Default
            gcPatients.Cursor = Cursors.Default
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function

    Private Sub deStartDate_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles deStartDate.Closed
        deEndDate.Focus()
    End Sub

    Private Sub deEndDate_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles deEndDate.Closed
        txtPatientCode.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAllContents()
        deStartDate.Focus()
    End Sub

    Private Sub ClearAllContents()
        deStartDate.EditValue = Nothing
        deEndDate.EditValue = Nothing
        txtPatientCode.Text = ""
        txtPatientName.Text = ""
        deDOB.EditValue = Nothing
        txtPhone.Text = ""
        gcPatients.DataSource = Nothing
        gvPatients.Columns.Clear()
    End Sub

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        ValidNumber(sender, e)
    End Sub

    Private Function LoadLogoImagePath() As MemoryStream
        Dim imagePath As New MemoryStream
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetLogoImage", New SqlParameter("@ImageType", "Clinic Logo"))
            With dtData
                If .Rows.Count = 1 Then
                    Dim imgSrc As Byte() = TryCast(.Rows(0)("Photo"), Byte())
                    Dim ms = New MemoryStream(imgSrc, 0, imgSrc.Length)
                    ms.Write(imgSrc, 0, imgSrc.Length)
                    imagePath = ms
                End If
            End With
        Catch ex As Exception
            '=====Get image to display in excel
            Dim PhotoBuffer As Byte() = File.ReadAllBytes("support_images\clinic_Logo.png")
            Dim ms = New MemoryStream(PhotoBuffer)
            imagePath = ms
        End Try

        Return imagePath
    End Function

    'Public Sub ExportToXlsxV2(ByVal dt As DataTable, ByVal fileName As String, Optional ByVal SheetName As String = "Patient")
    '    Try
    '        If gvPatients.RowCount > 0 Then
    '            Dim SaveDialog As New SaveFileDialog
    '            With SaveDialog
    '                .Filter = "Excel File | *.xlsx | All Files | *.*"
    '                'Dim CurDate As String = DateTime.Now.ToString("yyMMddhhmm")
    '                Dim CurDate As String = DateTime.Now.ToString("yyMMddhh00")
    '                .FileName = CurDate + "_" + fileName + "_by_" + AccountName + ".xlsx"
    '                If .ShowDialog() = DialogResult.OK Then
    '                    If My.Computer.FileSystem.FileExists(.FileName) Then My.Computer.FileSystem.DeleteFile(.FileName)

    '                    Using workbook As New XLWorkbook()

    '                        '=====Set Font to workbook=====
    '                        workbook.Style.Font.FontName = "Trebuchet MS"

    '                        '=====Initial Excel Application=====
    '                        Dim Sheet = workbook.Worksheets.Add(SheetName + "-" + DateTime.Now.ToString("ddMMMyyyy").ToUpper)
    '                        'Sheet.Column(3).Width = 60
    '                        'Sheet.Row(3).Height = 50

    '                        '=====Set Page Setup=====
    '                        With Sheet
    '                            .PageSetup.PaperSize = XLPaperSize.A4Paper
    '                            .PageSetup.PageOrientation = XLPageOrientation.Landscape
    '                            .PageSetup.Scale = 61
    '                            .PageSetup.Margins.Top = 0.393700787401575 '1cm
    '                            .PageSetup.Margins.Bottom = 0.393700787401575
    '                            .PageSetup.Margins.Left = 0.275590551181102 '0.7cm
    '                            .PageSetup.Margins.Right = 0.275590551181102
    '                            .PageSetup.Margins.Footer = 0.275590551181102
    '                            .PageSetup.Footer.Left.AddText("Created on: " + DateTime.Now.ToString("MMM dd, yyyy HH:mm:ss tt"))
    '                            '.PageSetup.Footer.Right.AddText(XLHFPredefinedText.Date, XLHFOccurrence.AllPages)
    '                            .PageSetup.Footer.Center.AddText("Page ", XLHFOccurrence.AllPages)
    '                            .PageSetup.Footer.Center.AddText(XLHFPredefinedText.PageNumber, XLHFOccurrence.AllPages)
    '                            .PageSetup.Footer.Center.AddText(" of ", XLHFOccurrence.AllPages)
    '                            .PageSetup.Footer.Center.AddText(XLHFPredefinedText.NumberOfPages, XLHFOccurrence.AllPages)
    '                        End With

    '                        '=====Add Logo=====
    '                        Dim imgPath = LoadLogoImagePath()
    '                        Dim clinic_logo = Sheet.AddPicture(imgPath).MoveTo(Sheet.Cell(1, 1))
    '                        clinic_logo.Name = "Clinic Logo"
    '                        clinic_logo.Width = 180
    '                        clinic_logo.Height = 80
    '                        imgPath.Close()

    '                        'Try
    '                        '    Dim dtData As DataTable = GetDataFromDBToTable("SA_GetLogoImage", New SqlParameter("@ImageType", "Clinic Logo"))
    '                        '    With dtData
    '                        '        If .Rows.Count = 1 Then
    '                        '            Dim imgSrc As Byte() = TryCast(.Rows(0)("Photo"), Byte())
    '                        '            Dim ms = New MemoryStream(imgSrc, 0, imgSrc.Length)
    '                        '            ms.Write(imgSrc, 0, imgSrc.Length)
    '                        '            Dim clinic_logo = Sheet.AddPicture(ms).MoveTo(Sheet.Cell(1, 1))
    '                        '            ms.Close()
    '                        '            clinic_logo.Name = "Clinic Logo"
    '                        '            clinic_logo.Width = 180
    '                        '            clinic_logo.Height = 80
    '                        '        End If
    '                        '    End With
    '                        'Catch ex As Exception
    '                        '    '=====Get image to display in excel
    '                        '    Dim imagePath = "support_images\clinic_Logo.png"
    '                        '    Dim clinic_logo = Sheet.AddPicture(imagePath).MoveTo(Sheet.Cell(1, 1))
    '                        '    clinic_logo.Name = "Clinic Logo"
    '                        '    clinic_logo.Width = 180
    '                        '    clinic_logo.Height = 80
    '                        'End Try

    '                        '=====Set Column widith=====
    '                        With Sheet
    '                            .Column("A").Width = 5
    '                            .Column("A").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("B").Width = 14.9
    '                            .Column("B").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("C").Width = 14
    '                            .Column("C").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("D").Width = 24
    '                            .Column("E").Width = 24
    '                            .Column("F").Width = 6.71
    '                            .Column("F").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("G").Width = 16.3
    '                            .Column("G").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("H").Width = 6.3
    '                            .Column("H").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("I").Width = 12.57
    '                            .Column("I").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("J").Width = 18.4
    '                            .Column("J").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("K").Width = 23
    '                            .Column("L").Width = 16
    '                            .Column("L").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("M").Width = 18
    '                            .Column("M").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("N").Width = 7.7
    '                            .Column("N").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                            .Column("O").Width = 20
    '                            .Column("O").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                        End With

    '                        '=============Set Title=====================
    '                        With Sheet
    '                            .Range("A3", "O3").Merge()
    '                            .Cell("A3").Value = "PB Medical Clinic"
    '                            .Cell("A3").Style.Font.FontSize = 18
    '                            .Cell("A3").Style.Font.Bold = True
    '                            .Cell("A3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

    '                            .Range("A4", "O4").Merge()
    '                            .Cell("A4").Value = "Patient List"
    '                            .Cell("A4").Style.Font.FontSize = 14
    '                            .Cell("A4").Style.Font.Bold = True
    '                            .Cell("A4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '                        End With

    '                        Dim borderColor As String = "#948A54"
    '                        Dim rowInd As Integer = 6
    '                        If gvPatients.RowCount > 0 Then
    '                            With Sheet.Row(rowInd).Cell(1)
    '                                .Value = "No"
    '                                .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

    '                                '=====Set column header style=====
    '                                .Style.Font.Bold = True
    '                                '.Style.Font.FontName = "Trebuchet MS"
    '                                .Style.Font.FontSize = 10
    '                                .Style.Fill.BackgroundColor = XLColor.FromHtml("#FF0066CC")
    '                                .Style.Font.FontColor = XLColor.White
    '                                .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
    '                                .Style.Border.OutsideBorderColor = XLColor.FromHtml(borderColor)
    '                            End With


    '                            For j = 1 To gvPatients.Columns.Count
    '                                '=====Set Column Header=====
    '                                With Sheet.Row(rowInd).Cell(j + 1)
    '                                    .Value = gvPatients.Columns(j - 1).GetTextCaption
    '                                    '.SetDataType(XLDataType.Text)
    '                                    .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

    '                                    '=====Set column header style=====
    '                                    .Style.Font.Bold = True
    '                                    '.Style.Font.FontName = "Trebuchet MS"
    '                                    .Style.Font.FontSize = 10
    '                                    .Style.Fill.BackgroundColor = XLColor.FromHtml("#FF0066CC")
    '                                    .Style.Font.FontColor = XLColor.White
    '                                    .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
    '                                    .Style.Border.OutsideBorderColor = XLColor.FromHtml(borderColor)
    '                                End With
    '                            Next

    '                            rowInd = rowInd + 1
    '                            For i = 0 To gvPatients.RowCount - 1
    '                                With Sheet.Row(rowInd + i).Cell(1)
    '                                    .Style.Font.FontSize = 10
    '                                    .Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
    '                                    .Value = i + 1
    '                                    .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
    '                                    .Style.Border.OutsideBorderColor = XLColor.FromHtml(borderColor)
    '                                End With

    '                                For j = 1 To gvPatients.Columns.Count
    '                                    With Sheet.Row(rowInd + i).Cell(j + 1)
    '                                        .Style.Font.FontSize = 10
    '                                        .Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
    '                                        .Value = gvPatients.GetRowCellValue(i, gvPatients.Columns(j - 1)).ToString 'Get date from GridControl
    '                                        '.Value = dt.Rows(i).ItemArray(j - 1) 'Get data from DataTable
    '                                        '.SetDataType(XLDataType.Text)
    '                                        .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
    '                                        .Style.Border.OutsideBorderColor = XLColor.FromHtml(borderColor)
    '                                    End With
    '                                Next
    '                            Next

    '                            ''For j = 1 To dt.Columns.Count
    '                            ''    '=====Set Column Header=====
    '                            ''    With Sheet.Row(rowInd).Cell(j + 1)
    '                            ''        .Value = dt.Columns(j - 1).ColumnName
    '                            ''        '.SetDataType(XLDataType.Text)
    '                            ''        .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

    '                            ''        '=====Set column header style=====
    '                            ''        .Style.Font.Bold = True
    '                            ''        '.Style.Font.FontName = "Trebuchet MS"
    '                            ''        .Style.Font.FontSize = 10
    '                            ''        .Style.Fill.BackgroundColor = XLColor.FromHtml("#FF0066CC")
    '                            ''        .Style.Font.FontColor = XLColor.White
    '                            ''        .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
    '                            ''        .Style.Border.OutsideBorderColor = XLColor.FromHtml("#FF0000")
    '                            ''    End With
    '                            ''Next
    '                            '''Sheet.Row(rowInd).AdjustToContents()

    '                            ''rowInd = rowInd + 1

    '                            ''For i = 0 To dt.Rows.Count - 1
    '                            ''    With Sheet.Row(rowInd + i).Cell(1)
    '                            ''        .Style.Font.FontSize = 10
    '                            ''        .Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
    '                            ''        .Value = i + 1
    '                            ''        .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
    '                            ''        .Style.Border.OutsideBorderColor = XLColor.FromHtml("#FF0000")
    '                            ''    End With

    '                            ''    For j = 1 To dt.Columns.Count
    '                            ''        With Sheet.Row(rowInd + i).Cell(j + 1)
    '                            ''            .Style.Font.FontSize = 10
    '                            ''            .Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
    '                            ''            .Value = dt.Rows(i).ItemArray(j - 1)
    '                            ''            .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
    '                            ''            .Style.Border.OutsideBorderColor = XLColor.FromHtml("#FF0000")
    '                            ''        End With
    '                            ''    Next
    '                            ''Next

    '                            'worksheet.Cell(3, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thick
    '                            'worksheet.Cell(3, 3).Style.Border.OutsideBorderColor = XLColor.Blue

    '                            ''Set the whole border to table
    '                            'Sheet.Cells.Style.Border.OutsideBorder = XLBorderStyleValues.Thin

    '                            '' Adjust row heights
    '                            'Sheet.Rows.AdjustToContents()
    '                            '' Adjust column width
    '                            'Sheet.Columns.AdjustToContents()

    '                            '=====Set Preparation Footer=====
    '                            'With Sheet
    '                            '    .Range("A" & rowInd, "C" & rowInd).Merge()
    '                            '    .Cell("A" & rowInd).Value = "Date: "
    '                            '    .Cell("A" & rowInd).Style.Font.FontSize = 10
    '                            '    .Cell("A" & rowInd).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left

    '                            '    .Range("A" & rowInd + 1, "C" & rowInd + 1).Merge()
    '                            '    .Cell("A" & rowInd + 1).Value = "Checked and approved by"
    '                            '    .Cell("A" & rowInd + 1).Style.Font.FontSize = 10
    '                            '    .Cell("A" & rowInd + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left

    '                            '    .Range("A" & rowInd + 6, "C" & rowInd + 6).Merge()
    '                            '    .Cell("A" & rowInd + 6).Value = "Name"
    '                            '    .Cell("A" & rowInd + 6).Style.Font.FontSize = 10
    '                            '    .Cell("A" & rowInd + 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
    '                            'End With

    '                            rowInd += gvPatients.RowCount + 1

    '                            With Sheet
    '                                .Range("N" & rowInd, "O" & rowInd).Merge()
    '                                .Cell("N" & rowInd).Value = "Date: " + Format(Now, "MMM dd, yyyy")
    '                                .Cell("N" & rowInd).Style.Font.FontSize = 10
    '                                .Cell("N" & rowInd).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left

    '                                .Range("N" & rowInd + 1, "O" & rowInd + 1).Merge()
    '                                .Cell("N" & rowInd + 1).Value = "Prepared by"
    '                                .Cell("N" & rowInd + 1).Style.Font.FontSize = 10
    '                                .Cell("N" & rowInd + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left

    '                                .Range("N" & rowInd + 6, "O" & rowInd + 6).Merge()
    '                                .Cell("N" & rowInd + 6).Value = AccountName
    '                                .Cell("N" & rowInd + 6).Style.Font.FontSize = 10
    '                                .Cell("N" & rowInd + 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
    '                            End With

    '                            '=====Overwrite existing file=====
    '                            If My.Computer.FileSystem.FileExists(.FileName) Then My.Computer.FileSystem.DeleteFile(.FileName)
    '                            workbook.SaveAs(.FileName)
    '                        End If
    '                    End Using

    '                    Dim detected As DialogResult = XtraMessageBox.Show("Do you want to open this file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                    If detected = DialogResult.Yes Then System.Diagnostics.Process.Start(.FileName)
    '                End If
    '            End With
    '        Else
    '            XtraMessageBox.Show("No found records to export", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Public Sub ExportToXlsx(ByVal dt As DataTable, ByVal fileName As String, Optional ByVal SheetName As String = "Patient")
        Try
            If My.Computer.FileSystem.FileExists(fileName) Then My.Computer.FileSystem.DeleteFile(fileName)

            Using workbook As New XLWorkbook()
                '=====Set Font to workbook=====
                workbook.Style.Font.FontName = "Trebuchet MS"

                '=====Initial Excel Application=====
                Dim Sheet = workbook.Worksheets.Add(SheetName + "-" + DateTime.Now.ToString("ddMMMyyyy").ToUpper)

                '=====Set Page Setup=====
                With Sheet
                    .PageSetup.PaperSize = XLPaperSize.A4Paper
                    .PageSetup.PageOrientation = XLPageOrientation.Landscape
                    .PageSetup.Scale = 61
                    .PageSetup.Margins.Top = 0.393700787401575 '1cm
                    .PageSetup.Margins.Bottom = 0.393700787401575
                    .PageSetup.Margins.Left = 0.275590551181102 '0.7cm
                    .PageSetup.Margins.Right = 0.275590551181102
                    .PageSetup.Margins.Footer = 0.275590551181102
                    .PageSetup.Footer.Left.AddText("Created on: " + DateTime.Now.ToString("MMM dd, yyyy HH:mm:ss tt"))
                    '.PageSetup.Footer.Right.AddText(XLHFPredefinedText.Date, XLHFOccurrence.AllPages)
                    .PageSetup.Footer.Center.AddText("Page ", XLHFOccurrence.AllPages)
                    .PageSetup.Footer.Center.AddText(XLHFPredefinedText.PageNumber, XLHFOccurrence.AllPages)
                    .PageSetup.Footer.Center.AddText(" of ", XLHFOccurrence.AllPages)
                    .PageSetup.Footer.Center.AddText(XLHFPredefinedText.NumberOfPages, XLHFOccurrence.AllPages)
                End With

                '=====Add Logo=====
                Dim imgPath = LoadLogoImagePath()
                Dim clinic_logo = Sheet.AddPicture(imgPath).MoveTo(Sheet.Cell(1, 1))
                clinic_logo.Name = "Clinic Logo"
                clinic_logo.Width = 180
                clinic_logo.Height = 80
                imgPath.Close()

                '=====Set Column widith=====
                With Sheet
                    .Column("A").Width = 5
                    .Column("A").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("B").Width = 14.9
                    .Column("B").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("C").Width = 14
                    .Column("C").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("D").Width = 24
                    .Column("E").Width = 24
                    .Column("F").Width = 6.71
                    .Column("F").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("G").Width = 16.3
                    .Column("G").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("H").Width = 6.3
                    .Column("H").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("I").Width = 12.57
                    .Column("I").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("J").Width = 18.4
                    .Column("J").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("K").Width = 23
                    .Column("L").Width = 16
                    .Column("L").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("M").Width = 18
                    .Column("M").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("N").Width = 7.7
                    .Column("N").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Column("O").Width = 20
                    .Column("O").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                End With

                '=============Set Title=====================
                With Sheet
                    .Range("A3", "O3").Merge()
                    .Cell("A3").Value = "PB Medical Clinic"
                    .Cell("A3").Style.Font.FontSize = 18
                    .Cell("A3").Style.Font.Bold = True
                    .Cell("A3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

                    .Range("A4", "O4").Merge()
                    .Cell("A4").Value = "Patient List"
                    .Cell("A4").Style.Font.FontSize = 14
                    .Cell("A4").Style.Font.Bold = True
                    .Cell("A4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                End With

                Dim borderColor As String = "#948A54"
                Dim rowInd As Integer = 6
                If gvPatients.RowCount > 0 Then
                    With Sheet.Row(rowInd).Cell(1)
                        .Value = "No"
                        .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

                        '=====Set column header style=====
                        .Style.Font.Bold = True
                        '.Style.Font.FontName = "Trebuchet MS"
                        .Style.Font.FontSize = 10
                        .Style.Fill.BackgroundColor = XLColor.FromHtml("#FF0066CC")
                        .Style.Font.FontColor = XLColor.White
                        .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                        .Style.Border.OutsideBorderColor = XLColor.FromHtml(borderColor)
                    End With

                    For j = 1 To gvPatients.Columns.Count
                        '=====Set Column Header=====
                        With Sheet.Row(rowInd).Cell(j + 1)
                            .Value = gvPatients.Columns(j - 1).GetTextCaption
                            '.SetDataType(XLDataType.Text)
                            .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

                            '=====Set column header style=====
                            .Style.Font.Bold = True
                            '.Style.Font.FontName = "Trebuchet MS"
                            .Style.Font.FontSize = 10
                            .Style.Fill.BackgroundColor = XLColor.FromHtml("#FF0066CC")
                            .Style.Font.FontColor = XLColor.White
                            .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                            .Style.Border.OutsideBorderColor = XLColor.FromHtml(borderColor)
                        End With
                    Next

                    rowInd = rowInd + 1
                    For i = 0 To gvPatients.RowCount - 1
                        With Sheet.Row(rowInd + i).Cell(1)
                            .Style.Font.FontSize = 10
                            .Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
                            .Value = i + 1
                            .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                            .Style.Border.OutsideBorderColor = XLColor.FromHtml(borderColor)
                        End With

                        For j = 1 To gvPatients.Columns.Count
                            With Sheet.Row(rowInd + i).Cell(j + 1)
                                .Style.Font.FontSize = 10
                                .Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
                                .Value = gvPatients.GetRowCellValue(i, gvPatients.Columns(j - 1)).ToString 'Get date from GridControl
                                '.Value = dt.Rows(i).ItemArray(j - 1) 'Get data from DataTable
                                '.SetDataType(XLDataType.Text)
                                .Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                                .Style.Border.OutsideBorderColor = XLColor.FromHtml(borderColor)
                            End With
                        Next
                    Next

                    '=====Set Preparation Footer=====
                    'With Sheet
                    '    .Range("A" & rowInd, "C" & rowInd).Merge()
                    '    .Cell("A" & rowInd).Value = "Date: "
                    '    .Cell("A" & rowInd).Style.Font.FontSize = 10
                    '    .Cell("A" & rowInd).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left

                    '    .Range("A" & rowInd + 1, "C" & rowInd + 1).Merge()
                    '    .Cell("A" & rowInd + 1).Value = "Checked and approved by"
                    '    .Cell("A" & rowInd + 1).Style.Font.FontSize = 10
                    '    .Cell("A" & rowInd + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left

                    '    .Range("A" & rowInd + 6, "C" & rowInd + 6).Merge()
                    '    .Cell("A" & rowInd + 6).Value = "Name"
                    '    .Cell("A" & rowInd + 6).Style.Font.FontSize = 10
                    '    .Cell("A" & rowInd + 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                    'End With

                    rowInd += gvPatients.RowCount + 1

                    With Sheet
                        .Range("N" & rowInd, "O" & rowInd).Merge()
                        .Cell("N" & rowInd).Value = "Date: " + Format(Now, "MMM dd, yyyy")
                        .Cell("N" & rowInd).Style.Font.FontSize = 10
                        .Cell("N" & rowInd).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left

                        .Range("N" & rowInd + 1, "O" & rowInd + 1).Merge()
                        .Cell("N" & rowInd + 1).Value = "Prepared by"
                        .Cell("N" & rowInd + 1).Style.Font.FontSize = 10
                        .Cell("N" & rowInd + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left

                        .Range("N" & rowInd + 6, "O" & rowInd + 6).Merge()
                        .Cell("N" & rowInd + 6).Value = AccountName
                        .Cell("N" & rowInd + 6).Style.Font.FontSize = 10
                        .Cell("N" & rowInd + 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                    End With

                    '=====Overwrite existing file=====
                    If My.Computer.FileSystem.FileExists(fileName) Then My.Computer.FileSystem.DeleteFile(fileName)
                    workbook.SaveAs(fileName)
                End If
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If gvPatients.RowCount > 0 Then
            Using SaveFileDialog As New SaveFileDialog
                With SaveFileDialog
                    'Configuration
                    .Filter = "Excel File | *.xlsx | All Files | *.*"
                    Dim CurDate As String = DateTime.Now.ToString("yyMMddhh00")
                    .FileName = CurDate + " Patient List_by_" + AccountName + ".xlsx"

                    If .ShowDialog() = DialogResult.OK Then
                        frmLoadingData.Show()
                        Me.Cursor = Cursors.WaitCursor
                        gcPatients.Cursor = Cursors.WaitCursor
                        Await Task.Run(Sub() ExportToXlsx(dtData, .FileName))
                        frmLoadingData.Hide()
                        Me.Cursor = Cursors.Default
                        gcPatients.Cursor = Cursors.Default

                        Dim detected As DialogResult = XtraMessageBox.Show("Do you want to open this file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If detected = DialogResult.Yes Then System.Diagnostics.Process.Start(.FileName)
                        frmLoadingData.Hide()
                        Me.Cursor = Cursors.Default
                        gcPatients.Cursor = Cursors.Default
                    End If
                End With
            End Using
        Else
            XtraMessageBox.Show("No record found to export", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub gvPatients_DoubleClick(sender As Object, e As EventArgs) Handles gvPatients.DoubleClick
        With gvPatients
            If .RowCount > 0 Then
                LoadForm(frmPatient)
                frmPatient.GetEmployeeRecord(.GetRowCellValue(.FocusedRowHandle, "PatientCode").ToString)
            End If
        End With
    End Sub
End Class