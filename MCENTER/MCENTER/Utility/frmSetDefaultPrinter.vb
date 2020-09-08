Imports System.Drawing.Printing
Imports DevExpress.XtraEditors

Public Class frmSetDefaultPrinter
    Private Sub frmSetDefaultPrinter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDataToLookupEdit(luePrinter, InitPrinters, "ID", "Printer")
        GetDataToLookupEdit(lueOrientation, PrinterOrientation, "ID", "PrinterOrientation")
        GetDataToLookupEdit(luePaperSize, PaperSize, "ID", "PaperSize")
        PrinterType()
        Try
            If Not IsNothing(ConfigPrinter) Then
                luePrinter.EditValue = ConfigPrinter.PrinterID
                luePrinterType.EditValue = ConfigPrinter.PrinterTypeID
                lueOrientation.EditValue = ConfigPrinter.PaperOrientationID
                luePaperSize.EditValue = ConfigPrinter.PaperSizeID
            Else
                luePrinter.EditValue = -1
                luePrinterType.EditValue = -1
                lueOrientation.EditValue = -1
                luePaperSize.EditValue = -1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrinterType()
        Try
            GetDataToComboBoxWithParam(luePrinterType, "SA_GetPrinterType", "ID", "PrinterType")
        Catch ex As Exception

        End Try
    End Sub

    Private Function InitPrinters() As List(Of Printers)
        Dim lstPrinters As New List(Of Printers)
        Dim pkInstalledPrinters As String
        Dim ID As Integer = 1
        ' Find all printers installed
        For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
            Dim Temp As New Printers
            Temp.ID = ID
            Temp.Printer = pkInstalledPrinters
            lstPrinters.Add(Temp)
            ID += 1
        Next pkInstalledPrinters

        Return lstPrinters
    End Function

    Private Function PrinterOrientation() As List(Of PrinterOrientation)
        Dim lstOrientation As New List(Of PrinterOrientation)
        Dim Temp As New PrinterOrientation With {.ID = 1, .PrinterOrientation = "Default Paper Orientation"}
        Dim Temp1 As New PrinterOrientation With {.ID = 2, .PrinterOrientation = "Portrait"}
        Dim Temp2 As New PrinterOrientation With {.ID = 3, .PrinterOrientation = "Landscape"}
        lstOrientation.Add(Temp)
        lstOrientation.Add(Temp1)
        lstOrientation.Add(Temp2)

        Return lstOrientation
    End Function

    Private Function PaperSize() As List(Of PaperSize)
        Dim lstPaper As New List(Of PaperSize)

        Dim Temp As New PaperSize With {.ID = 1, .PaperSize = "A3 (297 x 420 mm)"}
        Dim Temp1 As New PaperSize With {.ID = 2, .PaperSize = "A4 (210 x 297 mm)"}
        Dim Temp2 As New PaperSize With {.ID = 3, .PaperSize = "A5 (148 x 219 mm)"}
        Dim Temp3 As New PaperSize With {.ID = 3, .PaperSize = "A6 (105 x 148 mm)"}
        lstPaper.Add(Temp)
        lstPaper.Add(Temp1)
        lstPaper.Add(Temp2)
        lstPaper.Add(Temp3)

        Return lstPaper
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If CInt(luePrinter.EditValue) <= 0 Then
            XtraMessageBox.Show("Please select printer.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            luePrinter.Focus()
            Return
        ElseIf CInt(luePrinterType.EditValue) <= 0 Or CInt(lueOrientation.EditValue) <= 0 Or CInt(luePaperSize.EditValue) <= 0 Then
            XtraMessageBox.Show("Please select printer type and orientation.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            luePrinterType.Focus()
            Return
        ElseIf CInt(seNumCopies.Text.Trim) <= 0 Then
            XtraMessageBox.Show("Please enter number of copies.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            seNumCopies.Focus()
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim PrinterConfig As New PrinterConfiguration
            With PrinterConfig
                .PrinterID = CInt(luePrinter.EditValue)
                .PrinterName = luePrinter.Text.Trim
                .PrinterTypeID = CInt(luePrinterType.EditValue)
                .PrinterType = luePrinterType.Text.Trim
                .PaperSizeID = CInt(luePaperSize.EditValue)
                .PaperSize = luePaperSize.Text.Trim
                .PaperOrientationID = CInt(lueOrientation.EditValue)
                .PaperOrientation = lueOrientation.Text.Trim
                .NumberOfCopies = seNumCopies.Value.ToString
                .UserCreate = AccountName
                .DateCreate = Now.ToString
            End With

            ConfigurationDataAccess(Of PrinterConfiguration).SaveConfiguration(PrinterConfigPath, PrinterConfig)
            XtraMessageBox.Show("Successful. Set as default printer. Application will auto restart.", "Set as default", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Process.Start(Application.ExecutablePath)
            Application.Exit()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Fail setup", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmSetDefaultPrinter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class