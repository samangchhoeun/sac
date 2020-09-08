Imports System.Globalization
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports ClosedXML.Excel
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors

Module GenFunctions
    Public ms As MemoryStream

    Public Sub LoadForm(f As Form)
        Dim fm As Boolean = False
        For Each T As Form In Application.OpenForms
            If T.Name = f.Name Then
                fm = True
                T.Focus()
                T.Activate()
                Exit For
            End If
        Next

        If Not fm Then
            f.MdiParent = frmMainProject
            'f.Activate()
            f.Show()
        End If
    End Sub

    Public Sub LoadFormDialog(f As Form)
        'f.TopMost = True
        f.ShowDialog()
    End Sub

    Public Function GenEncryption(ByVal IsMe As String) As String
        'SHA256 sha = new SHA256CryptoServiceProvider();
        Dim sha As New MD5CryptoServiceProvider()
        Dim txtString As String = "Eddie"

        'compute hash from the bytes of text
        sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(IsMe & txtString))

        'get hash result after compute it
        Dim result As Byte() = sha.Hash

        Dim strBuilder As New StringBuilder()
        For i As Integer = 0 To result.Length - 1
            'change it into 2 hexadecimal digits
            'for each byte
            strBuilder.Append(result(i).ToString("x2"))
        Next

        Return strBuilder.ToString()
    End Function

    Public Function GenEncryptPassword(ByVal password As String) As String
        'SHA256 sha = new SHA256CryptoServiceProvider();
        Dim sha As New MD5CryptoServiceProvider()
        Dim txtString As String = "Eddie"

        'compute hash from the bytes of text
        sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password & txtString))

        'get hash result after compute it
        Dim result As Byte() = sha.Hash

        Dim strBuilder As New StringBuilder()
        For i As Integer = 0 To result.Length - 1
            'change it into 2 hexadecimal digits
            'for each byte
            strBuilder.Append(result(i).ToString("x2"))
        Next

        Return strBuilder.ToString()
    End Function

    Public Function GetWorkingPeriod(StartDate As String, StopDate As String) As String
        Dim total_days As Integer = 0

        Dim pStopDate As DateTime, pStartDate As DateTime

        If String.IsNullOrEmpty(StopDate) Then
            pStopDate = DateTime.Now
        Else
            pStopDate = Convert.ToDateTime(StopDate)
        End If

        If String.IsNullOrEmpty(StartDate) Then
            pStartDate = DateTime.Now
        Else
            pStartDate = Convert.ToDateTime(StartDate)
        End If

        total_days = pStopDate.Subtract(pStartDate).Days

        total_days += 1

        'The actual answer, with the math behind it is: 365.25/12 = 30.4375
        'If you don't want to account for leap years: 365/12 = 30.416666667 

        Dim years As Double = Math.Floor(total_days / 365.25)
        Dim months As Double = Math.Floor(Math.Floor(total_days Mod 365.25) / 30.4375)
        Dim days As Double = Math.Floor(Math.Floor(total_days Mod 365.25) Mod 30.4375)

        Dim str As String = ""
        If years = 1 Then
            str += years.ToString + " Year "
        ElseIf years > 1 Then
            str += years.ToString + " Years "
        End If

        If months = 1 Then
            str += months.ToString + " Month "
        ElseIf months > 1 Then
            str += months.ToString + " Months "
        End If

        If days = 1 Then
            str += days.ToString + " Day "
        ElseIf days > 1 Then
            str += days.ToString + " Days "
        End If
        Return str
    End Function

    Public Function GetNumDaysVisit(StartDate As DateTime, EndDate As DateTime) As String
        Dim Str As String = ""
        Dim span As TimeSpan = EndDate.Subtract(StartDate)
        Str += span.Days.ToString + "d "
        Str += span.Hours.ToString + "h "
        Str += span.Minutes.ToString + "m "
        Str += span.Seconds.ToString + "s "
        Str = Str.Trim
        Return Str
    End Function

    Public Function GetTimeInHours(tm1 As String, tm2 As String, ta1 As String, ta2 As String, te1 As String, te2 As String) As String
        Dim dtm As TimeSpan = Convert.ToDateTime(tm2) - Convert.ToDateTime(tm1)
        Dim dta As TimeSpan = Convert.ToDateTime(ta2) - Convert.ToDateTime(ta1)
        Dim dte As TimeSpan = Convert.ToDateTime(te2) - Convert.ToDateTime(te1)
        Dim mhours As Double = Math.Round(dtm.TotalHours, 3)
        Dim ahours As Double = Math.Round(dta.TotalHours, 3)
        Dim ehours As Double = Math.Round(dte.TotalHours, 3)
        Dim hours As Double = 0
        hours = mhours + ahours + ehours
        hours = If(hours < 0, 24 + hours, hours)
        Return hours.ToString()
    End Function

    Public Function imageToByteArray(imageIn As Image) As Byte()
        ms = New MemoryStream()
        imageIn.Save(ms, imageIn.RawFormat)
        Return ms.ToArray()
    End Function

    Public Function byteArrayToImage(byteArrayIn As Byte()) As Image
        Dim returnImage As Image = Nothing
        Try
            ms = New MemoryStream(byteArrayIn)
            returnImage = Image.FromStream(ms)
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
        Return returnImage
    End Function

    Public Function ToTitleCase(str As String) As String
        Dim getStr As String = ""
        getStr = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.Trim().ToLower())
        Return getStr
    End Function

    Public Function GetAvailableControl() As List(Of AvailableControls)
        ' Control Model
        Dim _con As New List(Of AvailableControls)()

        'Get Control From Database - DataTable
        Dim _Controls As List(Of clsControls) = clsControls.GetListOfControls()
        Dim _ExcludeControls As List(Of clsControls) = clsControls.GetExcludeControls()

        For Each f As Form In Application.OpenForms
            If f.Name.ToLower() = "frmMainProject".ToLower() Then
                Dim rc As RibbonControl = f.Controls.OfType(Of RibbonControl)().FirstOrDefault()
                For Each tab As RibbonPage In rc.Pages
                    For Each group As RibbonPageGroup In tab.Groups
                        For Each btn As BarButtonItemLink In group.ItemLinks
                            Dim _button As New AvailableControls()
                            '_button.Form = f.Name
                            _button.Tab = tab.Text
                            _button.Group = group.Text
                            _button.Caption = btn.Item.Caption
                            For Each c As clsControls In _Controls
                                If c.ControlName = btn.Item.Name Then _button.KhmerCaption = c.KhmerCaption
                            Next
                            _button.Control = btn.Item.Name
                            _button.IsAdded = False

                            For Each c As clsControls In _Controls
                                If c.ControlName = btn.Item.Name Then _button.IsAdded = True
                            Next

                            'remove exclude controls from the list
                            Dim CanAdd As Boolean = True
                            For Each ec As clsControls In _ExcludeControls
                                If ec.ControlName = btn.Item.Name Then CanAdd = False
                            Next

                            If CanAdd Then _con.Add(_button)
                        Next
                    Next
                Next
            End If
        Next
        Return _con
    End Function

    Public Function GetAvailableUserAccessControl(UserNo As Integer) As List(Of UserAccessPermissions)
        ' Control Model
        Dim _con As New List(Of UserAccessPermissions)()

        Dim _AllControls As List(Of clsControls) = clsControls.GetListOfControls()

        'Get Control From Database - DataTable
        Dim _Controls As List(Of clsControls) = clsControls.GetVisibleUserAccessControlsToList(UserNo)
        Dim _ExcludeControls As List(Of clsControls) = clsControls.GetExcludeControls()

        For Each f As Form In Application.OpenForms
            If f.Name.ToLower() = "frmMainProject".ToLower() Then
                Dim rc As RibbonControl = f.Controls.OfType(Of RibbonControl)().FirstOrDefault()
                For Each tab As RibbonPage In rc.Pages
                    For Each group As RibbonPageGroup In tab.Groups
                        For Each btn As BarButtonItemLink In group.ItemLinks
                            Dim _button As New UserAccessPermissions()
                            '_button.Form = f.Name
                            _button.Tab = tab.Text
                            _button.Group = group.Text
                            _button.Caption = btn.Item.Caption
                            For Each c As clsControls In _Controls
                                If c.ControlName = btn.Item.Name Then _button.KhmerCaption = c.KhmerCaption
                            Next
                            _button.Control = btn.Item.Name
                            _button.IsAdded = False
                            _button.IsAllowed = False

                            For Each ac As clsControls In _AllControls
                                If ac.ControlName = btn.Item.Name Then _button.IsAdded = True
                            Next

                            For Each c As clsControls In _Controls
                                If c.ControlName = btn.Item.Name Then
                                    _button.IsAllowed = True
                                    _button.AccountType = c.AccountType
                                End If
                            Next

                            'remove exclude controls from the list
                            Dim CanAdd As Boolean = True
                            For Each ec As clsControls In _ExcludeControls
                                If ec.ControlName = btn.Item.Name Then CanAdd = False
                            Next

                            If CanAdd Then _con.Add(_button)
                        Next
                    Next
                Next
            End If
        Next
        Return _con
    End Function

    Public Function GetExludedControlsAvailable() As List(Of AvailableControls)
        ' Control Model
        Dim _con1 As New List(Of AvailableControls)()

        'Get Control From Database - DataTable
        Dim _ExcludeControls As List(Of clsControls) = clsControls.GetExcludeControls()

        For Each f As Form In Application.OpenForms
            If f.Name.ToLower() = "frmMainProject".ToLower() Then
                Dim rc As RibbonControl = f.Controls.OfType(Of RibbonControl)().FirstOrDefault()
                For Each tab As RibbonPage In rc.Pages
                    For Each group As RibbonPageGroup In tab.Groups
                        For Each btn As BarButtonItemLink In group.ItemLinks
                            Dim _button As New AvailableControls()
                            '_button.Form = f.Name
                            _button.Tab = tab.Text
                            _button.Group = group.Text
                            _button.Caption = btn.Item.Caption
                            For Each c As clsControls In _ExcludeControls
                                If c.ControlName = btn.Item.Name Then _button.KhmerCaption = c.KhmerCaption
                            Next
                            _button.Control = btn.Item.Name
                            _button.IsAdded = True

                            'remove exclude controls from the list
                            Dim CanAdd As Boolean = False
                            For Each ec As clsControls In _ExcludeControls
                                If ec.ControlName = btn.Item.Name Then CanAdd = True
                            Next

                            If CanAdd Then _con1.Add(_button)
                        Next
                    Next
                Next
            End If
        Next
        Return _con1
    End Function

    Public Function GetNewControls() As List(Of AvailableControls)
        ' Control Model
        Dim _con As New List(Of AvailableControls)()

        'Get Control From Database - DataTable
        Dim _Controls As List(Of clsControls) = clsControls.GetListOfAllControls

        For Each f As Form In Application.OpenForms
            If f.Name.ToLower() = "frmMainProject".ToLower() Then
                Dim rc As RibbonControl = f.Controls.OfType(Of RibbonControl)().FirstOrDefault()
                For Each tab As RibbonPage In rc.Pages
                    For Each group As RibbonPageGroup In tab.Groups
                        For Each btn As BarButtonItemLink In group.ItemLinks
                            Dim _button As New AvailableControls()
                            '_button.Form = f.Name
                            _button.Tab = tab.Text
                            _button.Group = group.Text
                            _button.Caption = btn.Item.Caption
                            For Each c As clsControls In _Controls
                                If c.ControlName = btn.Item.Name Then _button.KhmerCaption = c.KhmerCaption
                            Next
                            _button.Control = btn.Item.Name
                            _button.IsAdded = False

                            'remove exclude controls from the list
                            Dim CanAdd As Boolean = True
                            For Each c As clsControls In _Controls
                                If c.ControlName = btn.Item.Name Then CanAdd = False
                            Next

                            If CanAdd Then _con.Add(_button)
                        Next
                    Next
                Next
            End If
        Next
        Return _con
    End Function

    Public Function GetInactiveControls() As List(Of AvailableControls)
        ' Control Model
        Dim _con As New List(Of AvailableControls)()

        'Get Control From Database - DataTable
        Dim _Controls As List(Of clsControls) = clsControls.GetListOfAllControls
        Dim _ItemsOnForm As New List(Of clsControls)

        For Each f As Form In Application.OpenForms
            If f.Name.ToLower() = "frmMainProject".ToLower() Then
                Dim rc As RibbonControl = f.Controls.OfType(Of RibbonControl)().FirstOrDefault()
                For Each tab As RibbonPage In rc.Pages
                    For Each group As RibbonPageGroup In tab.Groups
                        For Each btn As BarButtonItemLink In group.ItemLinks
                            Dim _Items As New clsControls
                            _Items.Caption = btn.Item.Caption
                            For Each c As clsControls In _Controls
                                If c.ControlName = btn.Item.Name Then _Items.KhmerCaption = c.KhmerCaption
                            Next
                            _Items.ControlName = btn.Item.Name
                            _ItemsOnForm.Add(_Items)
                        Next
                    Next
                Next

            End If
        Next

        For Each c As clsControls In _Controls
            Dim _ListItem As New AvailableControls
            Dim CanAdd As Boolean = True

            For Each item As clsControls In _ItemsOnForm
                If c.ControlName = item.ControlName Then
                    CanAdd = False
                    Exit For
                End If
            Next

            If CanAdd Then
                _ListItem.Caption = c.Caption
                _ListItem.Control = c.ControlName
                _con.Add(_ListItem)
            End If
        Next

        Return _con
    End Function

    Public Function GetRemovedControls() As List(Of AvailableControls)
        ' Control Model
        Dim _con As New List(Of AvailableControls)()

        'Get Control From Database - DataTable
        Dim _Controls As List(Of clsControls) = clsControls.GetListOfRemovedControls

        For Each f As Form In Application.OpenForms
            If f.Name.ToLower() = "frmMainProject".ToLower() Then
                Dim rc As RibbonControl = f.Controls.OfType(Of RibbonControl)().FirstOrDefault()
                For Each tab As RibbonPage In rc.Pages
                    For Each group As RibbonPageGroup In tab.Groups
                        For Each btn As BarButtonItemLink In group.ItemLinks
                            Dim _button As New AvailableControls()
                            '_button.Form = f.Name
                            _button.Tab = tab.Text
                            _button.Group = group.Text
                            _button.Caption = btn.Item.Caption
                            For Each c As clsControls In _Controls
                                If c.ControlName = btn.Item.Name Then _button.KhmerCaption = c.KhmerCaption
                            Next
                            _button.Control = btn.Item.Name
                            _button.IsAdded = False

                            'remove exclude controls from the list
                            Dim CanAdd As Boolean = False
                            For Each ec As clsControls In _Controls
                                If ec.ControlName = btn.Item.Name Then CanAdd = True
                            Next

                            If CanAdd Then _con.Add(_button)
                        Next
                    Next
                Next
            End If
        Next

        Return _con
    End Function

    Public Sub ExportToXlsx(ByVal dt As DataTable, ByVal fileName As String, Optional ByVal SheetName As String = "Report")
        If dt.Rows.Count > 0 Then
            Dim SaveDialog As New SaveFileDialog
            With SaveDialog
                .Filter = "Excel File | *.xlsx | All Files | *.*"
                Dim CurDate As String = DateTime.Now.ToString("yyMMddhhmm")
                .FileName = CurDate + "_" + fileName + "_by_" + AccountName + ".xlsx"
                If .ShowDialog() = DialogResult.OK Then
                    If My.Computer.FileSystem.FileExists(.FileName) Then My.Computer.FileSystem.DeleteFile(.FileName)
                    Using workbook As New XLWorkbook()
                        Dim worksheet = workbook.Worksheets.Add(SheetName)
                        If dt.Rows.Count > 0 Then
                            For j = 0 To dt.Columns.Count - 1
                                worksheet.Row(1).Cell(j + 1).Value = dt.Columns(j).ColumnName

                                '''Style
                                worksheet.Row(1).Cell(j + 1).Style.Font.Bold = True
                                worksheet.Row(1).Cell(j + 1).Style.Font.FontName = "Trebuchet MS"
                                worksheet.Row(1).Cell(j + 1).Style.Font.FontSize = 10
                                worksheet.Row(1).Cell(j + 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#FF0066CC")
                                worksheet.Row(1).Cell(j + 1).Style.Font.FontColor = XLColor.White
                            Next

                            For i = 0 To dt.Rows.Count - 1
                                For j = 0 To dt.Columns.Count - 1
                                    worksheet.Row(2 + i).Cell(j + 1).Style.Font.FontName = "Trebuchet MS"
                                    worksheet.Row(2 + i).Cell(j + 1).Style.Font.FontSize = 10
                                    worksheet.Row(2 + i).Cell(j + 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
                                    worksheet.Row(2 + i).Cell(j + 1).Value = dt.Rows(i).ItemArray(j)
                                Next
                            Next

                            'Set border to table
                            worksheet.Cells.Style.Border.OutsideBorder = XLBorderStyleValues.Thin

                            ' Adjust row heights
                            worksheet.Rows.AdjustToContents()
                            ' Adjust column width
                            worksheet.Columns.AdjustToContents()


                            If My.Computer.FileSystem.FileExists(.FileName) Then My.Computer.FileSystem.DeleteFile(.FileName)
                            workbook.SaveAs(.FileName)
                            Dim detected As DialogResult = MessageBox.Show("Do you want to open this file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If detected = DialogResult.Yes Then
                                System.Diagnostics.Process.Start(.FileName)
                            End If
                        End If
                    End Using
                End If
            End With
        Else
            XtraMessageBox.Show("No records to export", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub ValidNumber(sender As Object, e As KeyPressEventArgs)
        Dim ch As Char = e.KeyChar

        If Not Char.IsDigit(ch) AndAlso (ch <> Convert.ToChar(8)) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Public Sub ValidDecimal(sender As Object, e As KeyPressEventArgs)
        Dim ch As Char = e.KeyChar

        If Not Char.IsDigit(ch) AndAlso (ch <> Convert.ToChar(8)) AndAlso Not Char.IsWhiteSpace(ch) AndAlso (ch <> "." Or CType(sender, TextEdit).Text.IndexOf(".") > -1) Then
            e.Handled = True
        End If
    End Sub

    Public ReadOnly Property LoginConfigPath As String
        Get
            Return "syssacusers.json"
            'Try
            '    Return Path.Combine(Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory, "syssacusers.json")
            'Catch ex As Exception
            '    Return "syssacusers.json"
            'End Try
        End Get
    End Property

    Public ReadOnly Property StoreConfigPath As String
        Get
            Return "ClinicConfig.json"
            'Try
            '    Return Path.Combine(Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory, "StoreConfig.json")
            'Catch ex As Exception
            '    Return "ClinicConfig.json"
            'End Try
        End Get
    End Property

    Public ReadOnly Property PrinterConfigPath As String
        Get
            Return "PrinterConfig.json"
            'Try
            '    Return Path.Combine(Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory, "PrinterConfig.json")
            'Catch ex As Exception
            '    Return "PrinterConfig.json"
            'End Try
        End Get
    End Property

    Public Function FormatPatientCode(_PatientCode As String) As String
        Dim Str As String = ""
        If Len(_PatientCode) > 0 Then Str = Mid(_PatientCode, 1, 2) & "-" & Mid(_PatientCode, 3, 3) & "-" & Mid(_PatientCode, 6, 4)
        Return Str
    End Function

    Public Sub PTCode_KeyPress(ByVal txt As SearchControl, ByVal E As System.Windows.Forms.KeyPressEventArgs)
        If E.KeyChar = vbBack Then Exit Sub
        If Len(txt.Text) > 1 Then
            If E.KeyChar <> "0" Then
                If Val(E.KeyChar) = 0 Then E.KeyChar = Nothing
            End If
        End If

        If Len(txt.Text) = 2 Then
            txt.Text = Mid(txt.Text, 1, 2) & "-"
            txt.Text = UCase(txt.Text)
            txt.SelectionStart = 4
        ElseIf Len(txt.Text) = 6 Then
            txt.Text = Mid(txt.Text, 1, 6) & "-"
            txt.SelectionStart = 8
        End If
    End Sub '19-000-0001

    Public Sub PTCodeButtonEdit_KeyPress(ByVal txt As ButtonEdit, ByVal E As System.Windows.Forms.KeyPressEventArgs)
        If E.KeyChar = vbBack Then Exit Sub
        If Len(txt.Text) > 1 Then
            If E.KeyChar <> "0" Then
                If Val(E.KeyChar) = 0 Then E.KeyChar = Nothing
            End If
        End If

        If Len(txt.Text) = 2 Then
            txt.Text = Mid(txt.Text, 1, 2) & "-"
            txt.Text = UCase(txt.Text)
            txt.SelectionStart = 4
        ElseIf Len(txt.Text) = 6 Then
            txt.Text = Mid(txt.Text, 1, 6) & "-"
            txt.SelectionStart = 8
        End If
    End Sub '19-000-0001

    Public Sub PTCodeTextEdit_KeyPress(ByVal txt As TextEdit, ByVal E As System.Windows.Forms.KeyPressEventArgs)
        If E.KeyChar = vbBack Then Exit Sub
        If Len(txt.Text) > 1 Then
            If E.KeyChar <> "0" Then
                If Val(E.KeyChar) = 0 Then E.KeyChar = Nothing
            End If
        End If

        If Len(txt.Text) = 2 Then
            txt.Text = Mid(txt.Text, 1, 2) & "-"
            txt.Text = UCase(txt.Text)
            txt.SelectionStart = 4
        ElseIf Len(txt.Text) = 6 Then
            txt.Text = Mid(txt.Text, 1, 6) & "-"
            txt.SelectionStart = 8
        End If
    End Sub '19-000-0001

    Public Function GetStandardPatientCode(ByVal _PatientCode As String) As String
        Dim Str As String = ""
        If Len(_PatientCode) > 0 Then Str = Mid(_PatientCode, 1, 2) & Mid(_PatientCode, 4, 3) & Mid(_PatientCode, 8, 4)
        Return Str
    End Function

End Module
