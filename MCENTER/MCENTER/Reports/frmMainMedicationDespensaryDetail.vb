Imports System
Imports System.Windows.Forms
Imports System.IO 'file
Imports DevExpress.Data
Imports DevExpress.Printing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.XtraReports.UI
Public Class frmMainMedicationDespensaryDetail
    Public RptName As String
    Public RptType As String

    Public Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        'Dim byBrandName1 As String
        'Dim byBrandName2 As String
        'Dim bySupplier As String
        'Dim byStockInIVNumber As String

        'Dim byCampus As String

        'If cboCampus.Text = "ALL" Then
        '    byCampus = ""
        'Else
        '    byCampus = " AND DisCampus = '" & cboCampus.Text & "'"
        'End If


        'If brandName_cbo.Text = "ALL" Then
        '    byBrandName1 = ""
        '    byBrandName2 = ""
        'Else
        '    byBrandName1 = "AND [Brand Name]='" & brandName_cbo.Text & "'"
        '    byBrandName2 = "AND [drugBrandName]='" & brandName_cbo.Text & "'"
        'End If


        'If RptName = "StockCardExpired" Then
        '    Dim StockByCampus As String
        '    If cboCampus.Text = "ALL" Then
        '        StockByCampus = ""
        '    Else
        '        StockByCampus = " AND campus = '" & cboCampus.Text & "'"
        '    End If

        '    createReport("[Expired in Month] " & Operator_cbo.Text & ExpiredInMonth_cbo.Text & StockByCampus & " AND drugItemType='" & RptType & "'", "StockCardExpired")
        'ElseIf RptName = "MedicalStockin" Or RptName = "MedicalStockinByInvoice" Then 'Medication Stock in 

        '    If supplierName_cbo.Text = "ALL" Then
        '        bySupplier = ""
        '    Else
        '        bySupplier = "AND Ph_tblSupplier.supplierName = '" & supplierName_cbo.Text & "'"
        '    End If

        '    If StockinIVNum_txt.Text.Trim = "" Then
        '        byStockInIVNumber = ""
        '    Else
        '        byStockInIVNumber = "AND Ph_tblInvoiceMedicalStockIn.IVRecievedNum='" & StockinIVNum_txt.Text & "'"
        '    End If

        '    Dim DateRange As String
        '    If StartDate_Dtp.Text.Trim = "" Or StopDate_Dtp.Text.Trim = "" Then
        '        DateRange = ""
        '    Else
        '        DateRange = " AND cast(convert(nvarchar,recievedDate,101) AS DATETIME) BETWEEN '" & CDate(StartDate_Dtp.Text) & "' AND '" & CDate(StopDate_Dtp.Text) & "'"
        '    End If


        '    Dim byStockinCampus As String

        '    If cboCampus.Text = "ALL" Then
        '        byStockinCampus = ""
        '    Else
        '        byStockinCampus = " AND Ph_tblInvoiceMedicalStockIn.campus='" & cboCampus.Text & "'"
        '    End If



        '    Dim Table As New DataTable
        '    Dim Str As String

        '    Table.Clear()


        '    'Str = "SELECT IVRecievedNum,RecievedDate,Recievedby,Remark,Ph_tblSupplier.supplierName,drugBrandName,Form,Strength,ProductMadein,ExpiredDate,RealCost,Ph_tblDrugMaster.mainRetailPrice AS RetailCost,Quantity,Ph_tblDrugDetail.realCost*Quantity AS [LineTotalRealCost]" & _
        '    '         "  FROM Ph_tblInvoiceMedicalStockIn " & _
        '    '         "  INNER JOIN Ph_tblDrugDetail ON Ph_tblInvoiceMedicalStockIn.invoiceMedicalStockInCode=Ph_tblDrugDetail.invoiceMedicalStockInCode" & _
        '    '         "  INNER JOIN Ph_tblDrugMaster ON Ph_tblDrugDetail.drugMasterCode=Ph_tblDrugMaster.drugMasterCode " & _
        '    '         "  INNER JOIN Ph_tblSupplier ON Ph_tblInvoiceMedicalStockIn.supplierCode=Ph_tblSupplier.supplierCode " & _
        '    '         "  WHERE  Ph_tblInvoiceMedicalStockIn.IVRecievedNum NOT LIKE '%TF%' and Ph_tblInvoiceMedicalStockIn.isActive='True' AND Ph_tblDrugDetail.isActive='True' AND drugItemType= '" & RptType & "' " & DateRange & byBrandName2 & byStockinCampus & bySupplier & byStockInIVNumber

        '    Str = "SELECT IVRecievedNum,RecievedDate,Recievedby,Remark,Ph_tblSupplier.supplierName,drugBrandName,Form,Strength,ProductMadein,ExpiredDate,RealCost,Ph_tblDrugMaster.mainRetailPrice AS RetailCost,Quantity,Ph_tblDrugDetail.realCost*Quantity AS [LineTotalRealCost]" & _
        '       "  FROM Ph_tblInvoiceMedicalStockIn " & _
        '       "  INNER JOIN Ph_tblDrugDetail ON Ph_tblInvoiceMedicalStockIn.invoiceMedicalStockInCode=Ph_tblDrugDetail.invoiceMedicalStockInCode" & _
        '       "  INNER JOIN Ph_tblDrugMaster ON Ph_tblDrugDetail.drugMasterCode=Ph_tblDrugMaster.drugMasterCode " & _
        '       "  INNER JOIN Ph_tblSupplier ON Ph_tblInvoiceMedicalStockIn.supplierCode=Ph_tblSupplier.supplierCode " & _
        '       "  WHERE Ph_tblInvoiceMedicalStockIn.isActive='True' AND Ph_tblDrugDetail.isActive='True'  AND IVRecievedNum LIKE '%IV%' AND drugItemType= '" & RptType & "' " & DateRange & byBrandName2 & byStockinCampus & bySupplier & byStockInIVNumber



        '    Table = Get_DataTable(Str)

        '    If Table.Rows.Count = 0 Then
        '        MsgBox("Not found result to display", , "Confirm")

        '    End If


        '    If reportType_cbo.Text = "Summary" Then
        '        Dim Report As New XtraRpt_MedicationStockinSummary
        '        Me.Cursor = Cursors.WaitCursor
        '        ' Bind the report's printing system to the print control. 
        '        PrintControl1.PrintingSystem = Report.PrintingSystem
        '        Report.DataSource = Table
        '        Report.CreateDocument()
        '        PrintControl1.Refresh()
        '        Me.Cursor = Cursors.Default

        '    Else ' Detail Report
        '        Dim Report As New XtraRpt_MedicationStockinDetail
        '        Me.Cursor = Cursors.WaitCursor
        '        ' Bind the report's printing system to the print control. 
        '        PrintControl1.PrintingSystem = Report.PrintingSystem
        '        Report.DataSource = Table
        '        Report.CreateDocument()
        '        PrintControl1.Refresh()
        '        Me.Cursor = Cursors.Default
        '    End If

        'Else

        '    If reportType_cbo.Text = "Detail" Then 'Report Type = Detail

        '        If StartDate_Dtp.Text.Trim = "" Or StopDate_Dtp.Text.Trim = "" Then
        '            StartDate_Dtp.Text = Format(Now.Date, "MMM dd, yyyy")
        '            StopDate_Dtp.Text = Format(Now.Date, "MMM dd, yyyy")
        '        End If

        '        If MedicalDispensery_rdB.Checked = True Then
        '            createReport("[Prescription Date] <= #" & StopDate_Dtp.Text & "# AND [Prescription Date] >= #" & CDate(StartDate_Dtp.Text) & "#" & byBrandName1 & byCampus, "DispensaryDetail")
        '        ElseIf OtherMedicalDispensery_rdB.Checked Then
        '            createReport("[Prescription Date] <= #" & StopDate_Dtp.Text & "# AND [Prescription Date] >= #" & CDate(StartDate_Dtp.Text) & "#" & byBrandName1 & byCampus, "OtherDispensary")
        '        Else
        '            Dim Report As New XtraReport
        '            Me.Cursor = Cursors.WaitCursor
        '            ' Bind the report's printing system to the print control. 
        '            PrintControl1.PrintingSystem = Report.PrintingSystem
        '            Report.DataSource = Nothing
        '            Report.CreateDocument()
        '            PrintControl1.Refresh()
        '            Me.Cursor = Cursors.Default
        '            MsgBox("Under Construction", , "Confirm")
        '        End If
        '    Else 'Report Type = Summary
        '        If MedicalDispensery_rdB.Checked = True Then
        '            'createReport("(dateTimeStamp <= #" & StopDate_Dtp.Text & "# AND dateTimeStamp >= #" & StartDate_Dtp.Text & "#)" & byBrandName & " AND (isOtherDispensary= 'False') ", "DispensarySummary")

        '            Dim Report As New XtraRpt_Ph_MedDispensary_Summary
        '            Me.Cursor = Cursors.WaitCursor
        '            ' Bind the report's printing system to the print control. 
        '            PrintControl1.PrintingSystem = Report.PrintingSystem
        '            Dim Table As New DataTable
        '            Dim Str As String

        '            If byCampus.Trim <> "" Then
        '                byCampus = " And Ph_tblMedicationDispensary.DisCampus= '" & cboCampus.Text & "'"
        '            End If


        '            Str = "     SELECT dbo.Ph_tblDrugMaster.drugBrandName AS [Brand Name], dbo.Ph_tblDrugMaster.Form, dbo.Ph_tblDrugMaster.Strength,                                                                           " & _
        '                  "     SUM(dbo.Ph_tblMedicationDispensaryDetail.realCost * dbo.Ph_tblMedicationDispensaryDetail.Quantity) AS [LineTotal (Real Cost)],                                                                 " & _
        '                  "     SUM(dbo.Ph_tblMedicationDispensaryDetail.retailCost * dbo.Ph_tblMedicationDispensaryDetail.Quantity) AS [ LineTotal (Retail Cost)],                                                            " & _
        '                  "     SUM(dbo.Ph_tblMedicationDispensaryDetail.Quantity) AS Quantity                                                                                                                                 " & _
        '                  "     FROM     dbo.Ph_tblMedicationDispensary INNER JOIN                                                                                                                                       " & _
        '                  "                             dbo.Ph_tblMedicationDispensaryDetail ON                                                                                                                                " & _
        '                  "                             dbo.Ph_tblMedicationDispensary.MedicationDispensaryCode = dbo.Ph_tblMedicationDispensaryDetail.MedicationDispensaryCode INNER JOIN                                     " & _
        '                  "                             dbo.Ph_tblDrugDetail ON dbo.Ph_tblMedicationDispensaryDetail.drugDetailCode = dbo.Ph_tblDrugDetail.drugDetailCode INNER JOIN                                           " & _
        '                  "                             dbo.Ph_tblDrugMaster ON dbo.Ph_tblDrugDetail.drugMasterCode = dbo.Ph_tblDrugMaster.drugMasterCode                                                                      " & _
        '                  "     WHERE     (dbo.Ph_tblMedicationDispensaryDetail.isActive = 'True') AND (dbo.Ph_tblMedicationDispensary.isCancel = 'False') AND dbo.Ph_tblMedicationDispensary.isOtherDispensary='False'      " & _
        '                  "     AND cast(convert(nvarchar,Ph_tblMedicationDispensary.dateTimeStamp,101) AS DATETIME)  between '" & CDate(Me.StartDate_Dtp.Text) & "' and '" & CDate(Me.StopDate_Dtp.Text) & "'" & byBrandName2 & byCampus & _
        '                  "     GROUP BY dbo.Ph_tblDrugMaster.drugBrandName, dbo.Ph_tblDrugMaster.form, dbo.Ph_tblDrugMaster.Strength "
        '            Table = Get_DataTable(Str)
        '            Report.DataSource = Table
        '            Report.CreateDocument()
        '            PrintControl1.Refresh()
        '            Me.Cursor = Cursors.Default

        '        ElseIf OtherMedicalDispensery_rdB.Checked Then
        '            ' createReport("(dateTimeStamp <= #" & StopDate_Dtp.Text & "# AND dateTimeStamp >= #" & StartDate_Dtp.Text & "#)" & byBrandName & " AND (isOtherDispensary= 'True') ", "OtherDispensarySummary")

        '            Dim Report As New XtraRpt_Ph_MedDispensary_Summary
        '            Me.Cursor = Cursors.WaitCursor
        '            ' Bind the report's printing system to the print control. 

        '            If byCampus.Trim <> "" Then
        '                byCampus = " And Ph_tblMedicationDispensary.DisCampus= '" & cboCampus.Text & "'"
        '            End If

        '            PrintControl1.PrintingSystem = Report.PrintingSystem
        '            Dim Table As New DataTable
        '            Dim Str As String
        '            Str = "     SELECT dbo.Ph_tblDrugMaster.drugBrandName AS [Brand Name], dbo.Ph_tblDrugMaster.Form, dbo.Ph_tblDrugMaster.Strength,                                                                           " & _
        '                  "     SUM(dbo.Ph_tblMedicationDispensaryDetail.realCost * dbo.Ph_tblMedicationDispensaryDetail.Quantity) AS [LineTotal (Real Cost)],                                                                 " & _
        '                  "     SUM(dbo.Ph_tblMedicationDispensaryDetail.retailCost * dbo.Ph_tblMedicationDispensaryDetail.Quantity) AS [ LineTotal (Retail Cost)],                                                            " & _
        '                  "     SUM(dbo.Ph_tblMedicationDispensaryDetail.Quantity) AS Quantity                                                                                                                                 " & _
        '                  "     FROM     dbo.Ph_tblMedicationDispensary INNER JOIN                                                                                                                                             " & _
        '                  "                             dbo.Ph_tblMedicationDispensaryDetail ON                                                                                                                                " & _
        '                  "                             dbo.Ph_tblMedicationDispensary.MedicationDispensaryCode = dbo.Ph_tblMedicationDispensaryDetail.MedicationDispensaryCode INNER JOIN                                     " & _
        '                  "                             dbo.Ph_tblDrugDetail ON dbo.Ph_tblMedicationDispensaryDetail.drugDetailCode = dbo.Ph_tblDrugDetail.drugDetailCode INNER JOIN                                           " & _
        '                  "                             dbo.Ph_tblDrugMaster ON dbo.Ph_tblDrugDetail.drugMasterCode = dbo.Ph_tblDrugMaster.drugMasterCode                                                                      " & _
        '                  "     WHERE     (dbo.Ph_tblMedicationDispensaryDetail.isActive = 'True') AND (dbo.Ph_tblMedicationDispensary.isCancel = 'False') AND dbo.Ph_tblMedicationDispensary.isOtherDispensary='True'         " & _
        '                  "     AND cast(convert(nvarchar,Ph_tblMedicationDispensary.dateTimeStamp,101) AS DATETIME)  between '" & CDate(Me.StartDate_Dtp.Text) & "' and '" & CDate(Me.StopDate_Dtp.Text) & "'" & byBrandName2 & byCampus & _
        '                  "     GROUP BY dbo.Ph_tblDrugMaster.drugBrandName, dbo.Ph_tblDrugMaster.form, dbo.Ph_tblDrugMaster.Strength "

        '            Table = Get_DataTable(Str)
        '            Report.DataSource = Table
        '            Report.CreateDocument()
        '            PrintControl1.Refresh()
        '            Me.Cursor = Cursors.Default
        '        Else

        '            Dim Report As New XtraRpt_Ph_MedDispensary_Summary
        '            Me.Cursor = Cursors.WaitCursor
        '            ' Bind the report's printing system to the print control. 
        '            PrintControl1.PrintingSystem = Report.PrintingSystem
        '            Dim Table As New DataTable
        '            Dim Str As String

        '            'Ph_tblMedicationDispensary

        '            If byCampus.Trim <> "" Then
        '                byCampus = " And Ph_tblMedicationDispensary.DisCampus= '" & cboCampus.Text & "'"
        '            End If

        '            Str = "     SELECT dbo.Ph_tblDrugMaster.drugBrandName AS [Brand Name], dbo.Ph_tblDrugMaster.Form, dbo.Ph_tblDrugMaster.Strength,                                                                           " & _
        '                  "     SUM(dbo.Ph_tblMedicationDispensaryDetail.realCost * dbo.Ph_tblMedicationDispensaryDetail.Quantity) AS [LineTotal (Real Cost)],                                                                 " & _
        '                  "     SUM(dbo.Ph_tblMedicationDispensaryDetail.retailCost * dbo.Ph_tblMedicationDispensaryDetail.Quantity) AS [ LineTotal (Retail Cost)],                                                            " & _
        '                  "     SUM(dbo.Ph_tblMedicationDispensaryDetail.Quantity) AS Quantity                                                                                                                                 " & _
        '                  "     FROM     dbo.Ph_tblMedicationDispensary INNER JOIN                                                                                                                                             " & _
        '                  "                             dbo.Ph_tblMedicationDispensaryDetail ON                                                                                                                                " & _
        '                  "                             dbo.Ph_tblMedicationDispensary.MedicationDispensaryCode = dbo.Ph_tblMedicationDispensaryDetail.MedicationDispensaryCode INNER JOIN                                     " & _
        '                  "                             dbo.Ph_tblDrugDetail ON dbo.Ph_tblMedicationDispensaryDetail.drugDetailCode = dbo.Ph_tblDrugDetail.drugDetailCode INNER JOIN                                           " & _
        '                  "                             dbo.Ph_tblDrugMaster ON dbo.Ph_tblDrugDetail.drugMasterCode = dbo.Ph_tblDrugMaster.drugMasterCode                                                                      " & _
        '                  "     WHERE     (dbo.Ph_tblMedicationDispensaryDetail.isActive = 'True') AND (dbo.Ph_tblMedicationDispensary.isCancel = 'False')                                                                     " & _
        '                  "     AND cast(convert(nvarchar,Ph_tblMedicationDispensary.dateTimeStamp,101) AS DATETIME)  between '" & CDate(Me.StartDate_Dtp.Text) & "' and '" & CDate(Me.StopDate_Dtp.Text) & "'" & byBrandName2 & byCampus & _
        '                  "     GROUP BY dbo.Ph_tblDrugMaster.drugBrandName, dbo.Ph_tblDrugMaster.form, dbo.Ph_tblDrugMaster.Strength "
        '            Table = Get_DataTable(Str)
        '            Report.DataSource = Table
        '            Report.CreateDocument()
        '            PrintControl1.Refresh()
        '            Me.Cursor = Cursors.Default

        '        End If
        '    End If
        'End If
    End Sub

    Private Sub frmMainMedicationDespensaryDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim Table As New DataTable
        'Dim drow As DataRow


        'Table = Get_DataTable("SELECT ClinicLocation FROM tblClinicLocation")
        'cboStockCardbyCampus.Properties.Items.Clear()

        'cboStockCardbyCampus.Text = "ALL"
        'cboStockCardbyCampus.Properties.Items.Add("ALL")
        'For Each drow In Table.Rows
        '    cboStockCardbyCampus.Properties.Items.Add(drow("ClinicLocation"))
        'Next
        'Table.Clear()


        'Me.cboCampus.Properties.Items.Clear()
        'Table = Get_DataTable("SELECT ClinicLocation FROM tblClinicLocation ")
        'cboCampus.Text = "ALL"
        'cboCampus.Properties.Items.Add("ALL")
        'For Each drow In Table.Rows
        '    cboCampus.Properties.Items.Add(drow("ClinicLocation"))
        'Next
        'Table.Clear()



        'Table = Get_DataTable("SELECT drugBrandName FROM Ph_tblDrugMaster WHERE drugItemType='" & RptType & "' ORDER BY drugBrandName")
        ''Table = Get_DataTable("SELECT drugBrandName FROM Ph_tblDrugMaster     ORDER BY drugBrandName")

        'brandName_cbo.Properties.Items.Clear()

        'brandName_cbo.Properties.Items.Add("ALL")
        'brandName_cbo.Text = "ALL"
        'brandName1_cbo.Properties.Items.Add("ALL")
        'brandName1_cbo.Text = "ALL"
        'For Each drow In Table.Rows
        '    brandName_cbo.Properties.Items.Add(drow("drugBrandName"))
        '    brandName1_cbo.Properties.Items.Add(drow("drugBrandName"))
        'Next


        'reportType_cbo.Text = "Detail"

        'StartDate_Dtp.Text = Format(Now, "MMM dd, yyyy")
        'StopDate_Dtp.Text = Format(Now, "MMM dd, yyyy")
        'DateAdjFrom.Text = Format(Now, "MMM dd, yyyy")
        'DateAdjTo.Text = Format(Now, "MMM dd, yyyy")


        'MedicalDispensery_rdB.Checked = True

        'If RptName = "StockCard" Then
        '    NavBarControl1.Visible = False
        '    Dim Cmd As New System.Data.SqlClient.SqlCommand
        '    Dim Da As New System.Data.SqlClient.SqlDataAdapter
        '    Dim Ds As New DataSet
        '    Cmd.Connection = Cnn
        '    Cmd.CommandType = CommandType.Text
        '    Cmd.CommandText = "SELECT       dbo.Ph_tblDrugMaster.drugBrandName AS [Brand Name], dbo.Ph_tblDrugMaster.form, dbo.Ph_tblDrugMaster.Strength,                         " & _
        '                    " SUM(dbo.Ph_tblDrugDetail.Quantity) AS TotalStockIn, SUM(dbo.Ph_tblDrugDetail.StockOnHand) AS SOH, dbo.Ph_tblDrugMaster.minSOH,                      " & _
        '                    " SUM(dbo.Ph_tblDrugDetail.Quantity) - SUM(dbo.Ph_tblDrugDetail.StockOnHand) AS [Total Dispensed] ,SUM(dbo.Ph_tblDrugDetail.StockOnHand)-MINSOH AS CheckStock, " & _
        '                    " SUM(StockOnHand * realCost) AS SOH_CostPrice,SUM(StockOnHand * retailcost) AS SOH_SalePrice " & _
        '                    " FROM dbo.Ph_tblDrugMaster INNER JOIN                                                                                                                " & _
        '                    " dbo.Ph_tblDrugDetail ON dbo.Ph_tblDrugMaster.drugMasterCode = dbo.Ph_tblDrugDetail.drugMasterCode INNER JOIN                                        " & _
        '                    " dbo.Ph_tblInvoiceMedicalStockIn ON dbo.Ph_tblDrugDetail.invoiceMedicalStockInCode = dbo.Ph_tblInvoiceMedicalStockIn.invoiceMedicalStockInCode       " & _
        '                    " WHERE (dbo.Ph_tblInvoiceMedicalStockIn.isActive = 'True') AND (dbo.Ph_tblDrugDetail.isActive = 'True')  AND drugItemType='" & RptType & "'          " & _
        '                    " GROUP BY dbo.Ph_tblDrugMaster.drugBrandName, dbo.Ph_tblDrugMaster.form, dbo.Ph_tblDrugMaster.Strength, dbo.Ph_tblDrugMaster.minSOH                  " & _
        '                    " ORDER BY [Brand Name]"

        '    Da.SelectCommand = Cmd
        '    Da.Fill(Ds, "Stockcard")
        '    Da = Nothing

        '    Dim Report As New XtraRpt_StockCard
        '    Me.Cursor = Cursors.WaitCursor
        '    ' Bind the report's printing system to the print control. 
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    Report.DataSource = Ds.Tables("Stockcard")
        '    Report.CreateDocument()
        '    PrintControl1.Refresh()
        '    Me.Cursor = Cursors.Default


        '    SortColumn_cbo.Properties.Items.Clear()
        '    SortColumn_cbo.Properties.Items.Add("Brand Name")
        '    SortColumn_cbo.Properties.Items.Add("Form")
        '    SortColumn_cbo.Properties.Items.Add("Strength")
        '    SortColumn_cbo.Properties.Items.Add("TotalStockIn")
        '    SortColumn_cbo.Properties.Items.Add("SOH")
        '    SortColumn_cbo.Properties.Items.Add("MinSOH")
        '    SortColumn_cbo.Properties.Items.Add("Total Dispensed")

        'ElseIf RptName = "FeeByCategory" Then
        '    NavBarControl1.Visible = False
        '    Dim Cmd As New System.Data.SqlClient.SqlCommand
        '    Dim Da As New System.Data.SqlClient.SqlDataAdapter
        '    Dim Ds As New DataSet
        '    Cmd.Connection = Cnn
        '    Cmd.CommandType = CommandType.StoredProcedure
        '    Cmd.CommandText = "pro_CrossTab"
        '    Cmd.Parameters.AddWithValue("@SelectStatement", "SELECT ISNULL(Months,0) as Months,ISNULL(Years,0) as Years, ISNULL(ServiceCategory,0) as ServiceCategory, ISNULL(TotalAmount,0) AS TotalAmount  FROM Vw_Cashier_MonthlyTotalServiceByCategory")
        '    Cmd.Parameters.AddWithValue("@PivotColumn", "Months")
        '    Cmd.Parameters.AddWithValue("@Summary", "SUM (TotalAmount)[]")
        '    Cmd.Parameters.AddWithValue("@GroupbyField", "Years, ServiceCategory")
        '    Da.SelectCommand = Cmd
        '    Da.Fill(Ds, "Category")
        '    Da = Nothing
        '    Dim Report As New XtraRpt_CountPatientVisitbyMembershipType
        '    Me.Cursor = Cursors.WaitCursor
        '    ' Bind the report's printing system to the print control. 
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    Report.DataSource = Ds.Tables("Category")
        '    Report.CreateDocument()
        '    PrintControl1.Refresh()
        '    Me.Cursor = Cursors.Default
        'ElseIf RptName = "MonthlyHealcareUsed" Then
        '    NavBarControl1.Visible = False
        '    Dim Cmd As New System.Data.SqlClient.SqlCommand
        '    Dim Da As New System.Data.SqlClient.SqlDataAdapter
        '    Dim Ds As New DataSet
        '    Cmd.Connection = Cnn
        '    Cmd.CommandType = CommandType.StoredProcedure
        '    Cmd.CommandText = "pro_CrossTab"
        '    Cmd.Parameters.AddWithValue("@SelectStatement", "SELECT  creditBalancePaid, Months, Years, Division, CooperatorName  FROM   Vw_Cashier_MontlyHealthcareBalanceUsed")
        '    Cmd.Parameters.AddWithValue("@PivotColumn", "Months")
        '    Cmd.Parameters.AddWithValue("@Summary", "SUM (creditBalancePaid)[]")
        '    Cmd.Parameters.AddWithValue("@GroupbyField", "Years, CooperatorName,Division")
        '    Da.SelectCommand = Cmd
        '    Da.Fill(Ds, "MonthlyHealcareUsed")
        '    Da = Nothing

        '    'Ds.Tables("MonthlyHealcareUsed").WriteXmlSchema("D:\Schemar.xml") ' Write data to XML

        '    Dim Report As New XtraRpt_Cashier_MontlyHealthcareBalanceUsed9
        '    Me.Cursor = Cursors.WaitCursor
        '    ' Bind the report's printing system to the print control. 
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    Report.DataSource = Ds.Tables("MonthlyHealcareUsed")
        '    Report.CreateDocument()
        '    PrintControl1.Refresh()
        '    Me.Cursor = Cursors.Default

        'ElseIf RptName = "CountPtVisitByMembershipType" Then
        '    NavBarControl1.Visible = False
        '    Dim Cmd As New System.Data.SqlClient.SqlCommand
        '    Dim Da As New System.Data.SqlClient.SqlDataAdapter
        '    Dim Ds As New DataSet
        '    Cmd.Connection = Cnn
        '    Cmd.CommandType = CommandType.StoredProcedure
        '    Cmd.CommandText = "pro_CrossTab"
        '    Cmd.Parameters.AddWithValue("@SelectStatement", "SELECT  [MembershipType], DATENAME(month, datein) AS Months, DATEPART(year, datein) AS Years FROM tblVisits WHERE isActive=1")
        '    Cmd.Parameters.AddWithValue("@PivotColumn", "Months")
        '    Cmd.Parameters.AddWithValue("@Summary", "COUNT([MembershipType])[]")
        '    Cmd.Parameters.AddWithValue("@GroupbyField", "Years,[MembershipType]")
        '    Da.SelectCommand = Cmd
        '    Da.Fill(Ds, "Membership")
        '    Da = Nothing

        '    'Ds.Tables("MonthlyHealcareUsed").WriteXmlSchema("D:\Schemar.xml") ' Write data to XML

        '    Dim Report As New XtraRpt_CountPtVisitByMembership
        '    Me.Cursor = Cursors.WaitCursor
        '    ' Bind the report's printing system to the print control. 
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    Report.DataSource = Ds.Tables("Membership")
        '    Report.CreateDocument()
        '    PrintControl1.Refresh()
        '    Me.Cursor = Cursors.Default

        'ElseIf RptName = "StockCardExpired" Then
        '    ExpiredInMonth_cbo.Properties.Items.Clear()
        '    For i As Integer = 0 To 100
        '        ExpiredInMonth_cbo.Properties.Items.Add(i)
        '    Next
        '    ExpiredInMonth_cbo.Text = 3
        '    cmdShowReport_Click(sender, e)
        'ElseIf RptName = "StockCard-BaseOn-CostPrice" Then
        '    NavBarControl1.Visible = False
        '    Dim Cmd As New System.Data.SqlClient.SqlCommand
        '    Dim Da As New System.Data.SqlClient.SqlDataAdapter
        '    Dim Ds As New DataSet
        '    Cmd.Connection = Cnn
        '    Cmd.CommandType = CommandType.Text
        '    Cmd.CommandText = "SELECT	Ph_tblInvoiceMedicalStockIn.IvRecievedNum,drugBrandName AS [Brand Name],productMadeIn AS [Made in],CONVERT(NVARCHAR,expiredDate,107) AS [Expired Date]," & _
        '                       " Strength,Form,realCost AS [Cost Price],mainRetailPrice AS [Sale Price],(mainRetailPrice-realCost) AS Earned,(mainRetailPrice-realCost)/Realcost AS Markup   " & _
        '                       " FROM Ph_tblDrugMaster INNER JOIN Ph_tblDrugDetail ON Ph_tblDrugMaster.drugMasterCode = Ph_tblDrugDetail.drugMasterCode  " & _
        '                       " INNER JOIN Ph_tblInvoiceMedicalStockIn ON Ph_tblDrugDetail.invoiceMedicalStockInCode = Ph_tblInvoiceMedicalStockIn.invoiceMedicalStockInCode " & _
        '                       " WHERE Ph_tblDrugDetail.isActive='True'  AND (mainRetailPrice-realCost) > 0 " & _
        '                       " ORDER BY drugBrandName "

        '    Da.SelectCommand = Cmd
        '    Da.Fill(Ds, "CostPrice")
        '    ' Da = Nothing


        '    'Ds.Tables("CostPrice").WriteXmlSchema("D:\Schemar.xml") ' Write data to XML



        '    Dim Report As New XtraRpt_StockCardBaseOnCostPrice
        '    Me.Cursor = Cursors.WaitCursor
        '    ' Bind the report's printing system to the print control. 
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    Report.DataSource = Ds.Tables("CostPrice")
        '    Report.CreateDocument()
        '    PrintControl1.Refresh()
        '    Me.Cursor = Cursors.Default


        '    SortColumn_cbo.Properties.Items.Clear()
        '    SortColumn_cbo.Properties.Items.Add("Brand Name")
        '    SortColumn_cbo.Properties.Items.Add("Cost Price")
        '    SortColumn_cbo.Properties.Items.Add("Sale Price")
        '    SortColumn_cbo.Properties.Items.Add("Earned")
        '    SortColumn_cbo.Properties.Items.Add("Markup")
        'End If

    End Sub

    Private Sub StartDate_Dtp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartDate_Dtp.Validated
        If StartDate_Dtp.Text.Trim <> "" Then
            StartDate_Dtp.Text = Format(CDate(StartDate_Dtp.Text), "MMM dd, yyyy")
        End If
    End Sub

    Private Sub StopDate_Dtp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopDate_Dtp.Validated
        If StopDate_Dtp.Text.Trim <> "" Then
            StopDate_Dtp.Text = Format(CDate(StopDate_Dtp.Text), "MMM dd, yyyy")
        End If
    End Sub

    Private Sub createReport(ByVal filterString As String, ByVal rptType As String)
        'If rptType = "OtherDispensary" Then
        '    Dim Report As New XtraRpt_OtherMedicationDespensaryDetail
        '    Me.Cursor = Cursors.WaitCursor
        '    ' Bind the report's printing system to the print control. 
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    ' Apply filter string
        '    Report.FilterString = filterString
        '    Report.ApplyFiltering()
        '    ' Generate the report's print document. 
        '    Report.CreateDocument()
        '    PrintControl1.Refresh()
        '    Me.Cursor = Cursors.Default

        'ElseIf rptType = "DispensaryDetail" Then
        '    Dim Report As New XtraRpt_MedicationDespensaryDetail
        '    Me.Cursor = Cursors.WaitCursor
        '    ' Bind the report's printing system to the print control. 
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    ' Apply filter string
        '    Report.FilterString = filterString
        '    Report.ApplyFiltering()
        '    ' Generate the report's print document. 
        '    Report.CreateDocument()
        '    PrintControl1.Refresh()
        '    Me.Cursor = Cursors.Default
        'ElseIf rptType = "DispensarySummary" Then
        '    Dim Report As New XtraRpt_Ph_MedDispensary_Summary
        '    Me.Cursor = Cursors.WaitCursor
        '    ' Bind the report's printing system to the print control. 
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    ' Apply filter string
        '    Report.FilterString = filterString
        '    Report.ApplyFiltering()
        '    ' Generate the report's print document. 
        '    Report.CreateDocument()
        '    PrintControl1.Refresh()
        '    Me.Cursor = Cursors.Default
        'ElseIf RptName = "StockCardExpired" Then
        '    Dim Report As New XtraRpt_StockCard_Expired
        '    Me.Cursor = Cursors.WaitCursor
        '    ' Bind the report's printing system to the print control. 
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    ' Apply filter string
        '    Report.FilterString = filterString
        '    Report.ApplyFiltering()
        '    ' Generate the report's print document. 
        '    Report.CreateDocument()
        '    PrintControl1.Refresh()
        '    Me.Cursor = Cursors.Default
        'End If

    End Sub

    Private Sub ExportExcel_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcel_cmd.Click
        brandName_cbo.Text = "ALL"
        StockinIVNum_txt.Text = ""
        supplierName_cbo.Text = "ALL"
        cboCampus.Text = "ALL"

        'If RptName Then

        'End If
        StartDate_Dtp.Text = ""
        StopDate_Dtp.Text = ""

    End Sub


    Private Sub previewAdjReport_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles previewAdjReport_cmd.Click
        'Dim Cmd As New System.Data.SqlClient.SqlCommand
        'Dim Da As New System.Data.SqlClient.SqlDataAdapter
        'Dim Ds As New DataSet
        'Cmd.Connection = Cnn
        'Cmd.CommandType = CommandType.Text
        'Cmd.CommandText = " SELECT convert(nvarchar,datetimeadj,107)  AS [AdjustedDate],Ph_tblStockAdjustment.InputBy AS [Adjustedby],DrugBrandName , Form,Strength,convert(nvarchar,ExpiredDate,107)  AS [ExpiredDate] " & _
        '                  " ,Ph_tblStockAdjustment.beforeAdjSOH,Ph_tblStockAdjustment.afterAdjSOH,QtyAdj,Ph_tblStockAdjustment.adjReason,CASE  WHEN isAdjIn='True' THEN 'In'   ELSE 'Out'  END   AS [AdjType]" & _
        '                  " FROM Ph_tblDrugMaster INNER JOIN Ph_tblDrugDetail ON Ph_tblDrugMaster.drugMasterCode=Ph_tblDrugDetail.drugMasterCode " & _
        '                  " INNER JOIN Ph_tblStockAdjustment ON Ph_tblDrugDetail.drugDetailCode=ph_tblStockAdjustment.drugDetailCode " & _
        '                  " WHERE drugItemType='" & RptType & "' AND cast(convert(nvarchar,datetimeadj,101) AS DATETIME) BETWEEN '" & CDate(Me.DateAdjFrom.Text) & "' and '" & CDate(Me.DateAdjTo.Text) & "' AND Ph_tblDrugDetail.isActive='True'"

        'Da.SelectCommand = Cmd
        'Da.Fill(Ds, "StockAdjustment")
        'Da = Nothing

        'Dim Report As New XtraRpt_StockAdjustment
        'Me.Cursor = Cursors.WaitCursor
        '' Bind the report's printing system to the print control. 
        'PrintControl1.PrintingSystem = Report.PrintingSystem
        'Report.DataSource = Ds.Tables("StockAdjustment")
        'Report.CreateDocument()
        'PrintControl1.Refresh()
        'Me.Cursor = Cursors.Default

    End Sub

    Private Sub DateAdjFrom_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateAdjFrom.Validated
        DateAdjFrom.Text = Format(CDate(DateAdjFrom.Text), "MMM dd, yyyy")
    End Sub

    Private Sub DateAdjTo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateAdjTo.Validated
        DateAdjTo.Text = Format(CDate(DateAdjTo.Text), "MMM dd, yyyy")
    End Sub

    Private Sub cmdShortStockCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sortStockCard_cmd.Click
        ''Dim Cmd As New System.Data.SqlClient.SqlCommand
        ''Dim Da As New System.Data.SqlClient.SqlDataAdapter
        ''Dim Ds As New DataSet
        ''Cmd.Connection = Cnn
        ''Cmd.CommandType = CommandType.Text
        ''Cmd.CommandText = "SELECT      Ph_tblDrugMaster.drugmastercode, dbo.Ph_tblDrugMaster.drugBrandName AS [Brand Name], dbo.Ph_tblDrugMaster.form, dbo.Ph_tblDrugMaster.Strength," & _
        ''                  "     SUM(dbo.Ph_tblDrugDetail.Quantity) AS TotalStockIn, SUM(dbo.Ph_tblDrugDetail.StockOnHand) AS SOH, dbo.Ph_tblDrugMaster.minSOH," & _
        ''                  "     SUM(dbo.Ph_tblDrugDetail.Quantity) - SUM(dbo.Ph_tblDrugDetail.StockOnHand) AS [Total Dispensed] ,  " & _
        ''                  "     SUM(dbo.Ph_tblDrugDetail.StockOnHand)-MINSOH AS CheckStock,SUM(StockOnHand * realCost) AS SOH_CostPrice,SUM(StockOnHand * retailcost) AS SOH_SalePrice   " & _
        ''"	 FROM dbo.Ph_tblDrugMaster INNER JOIN   " &
        ''                  "     dbo.Ph_tblDrugDetail ON dbo.Ph_tblDrugMaster.drugMasterCode = dbo.Ph_tblDrugDetail.drugMasterCode INNER JOIN " & _
        ''                  "     dbo.Ph_tblInvoiceMedicalStockIn ON dbo.Ph_tblDrugDetail.invoiceMedicalStockInCode = dbo.Ph_tblInvoiceMedicalStockIn.invoiceMedicalStockInCode  " & _
        ''                  "     WHERE (dbo.Ph_tblInvoiceMedicalStockIn.isActive = 'True') AND drugItemType='Pharmacy' AND (dbo.Ph_tblDrugDetail.isActive = 'True')   " & _
        ''                  "     GROUP BY Ph_tblDrugMaster.drugmastercode,dbo.Ph_tblDrugMaster.drugBrandName, dbo.Ph_tblDrugMaster.form, dbo.Ph_tblDrugMaster.Strength, dbo.Ph_tblDrugMaster.minSOH    " & _
        ''                  "     ORDER BY [Brand Name] ASC"

        ''Da.SelectCommand = Cmd
        ''Da.Fill(Ds, "StockCard")
        ''Ds.Tables("StockCard").WriteXmlSchema("D:\SchemarStockCard.xml") ' Write data to XML


        'Dim SortType As String
        'If sortType_cbo.Text = "A=>Z" Then
        '    SortType = "ASC"
        'Else
        '    SortType = "DESC"
        'End If

        'Dim byBrandName As String
        'If brandName1_cbo.Text = "ALL" Then
        '    byBrandName = ""
        'Else
        '    byBrandName = "AND [drugBrandName]='" & brandName1_cbo.Text & "'"
        'End If


        'Dim byStockCampus As String

        'If cboStockCardbyCampus.Text = "ALL" Then
        '    byStockCampus = ""
        'Else
        '    byStockCampus = "AND (dbo.Ph_tblDrugDetail.campus = '" & cboStockCardbyCampus.Text & "')"
        'End If



        'Dim Cmd As New System.Data.SqlClient.SqlCommand
        'Dim Da As New System.Data.SqlClient.SqlDataAdapter
        'Dim Ds As New DataSet
        'Cmd.Connection = Cnn
        'Cmd.CommandType = CommandType.Text


        'If RptName = "StockCard" Then
        '    Cmd.CommandText = "SELECT dbo.Ph_tblDrugMaster.drugBrandName AS [Brand Name], dbo.Ph_tblDrugMaster.form, dbo.Ph_tblDrugMaster.Strength,                                " & _
        '                           " SUM(dbo.Ph_tblDrugDetail.Quantity) AS TotalStockIn, SUM(dbo.Ph_tblDrugDetail.StockOnHand) AS SOH, dbo.Ph_tblDrugMaster.minSOH,                      " & _
        '                           " SUM(dbo.Ph_tblDrugDetail.Quantity) - SUM(dbo.Ph_tblDrugDetail.StockOnHand) AS [Total Dispensed] , SUM(dbo.Ph_tblDrugDetail.StockOnHand)-MINSOH AS CheckStock,  " & _
        '                           " SUM(StockOnHand * realCost) AS SOH_CostPrice,SUM(StockOnHand * retailcost) AS SOH_SalePrice " & _
        '                           " FROM dbo.Ph_tblDrugMaster INNER JOIN                                                                                                                " & _
        '                           " dbo.Ph_tblDrugDetail ON dbo.Ph_tblDrugMaster.drugMasterCode = dbo.Ph_tblDrugDetail.drugMasterCode INNER JOIN                                        " & _
        '                           " dbo.Ph_tblInvoiceMedicalStockIn ON dbo.Ph_tblDrugDetail.invoiceMedicalStockInCode = dbo.Ph_tblInvoiceMedicalStockIn.invoiceMedicalStockInCode       " & _
        '                           " WHERE (dbo.Ph_tblInvoiceMedicalStockIn.isActive = 'True') AND drugItemType='" & RptType & "' " & byStockCampus & " AND (dbo.Ph_tblDrugDetail.isActive = 'True')  " & byBrandName & _
        '                           " GROUP BY dbo.Ph_tblDrugMaster.drugBrandName, dbo.Ph_tblDrugMaster.form, dbo.Ph_tblDrugMaster.Strength, dbo.Ph_tblDrugMaster.minSOH                  " & _
        '                           " ORDER BY [" & SortColumn_cbo.Text & "] " & SortType

        '    Da.SelectCommand = Cmd
        '    Da.Fill(Ds, "Stockcard")
        '    Da = Nothing

        '    Dim Report As New XtraRpt_StockCard
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    Report.DataSource = Ds.Tables("Stockcard")
        '    Report.CreateDocument()
        'ElseIf RptName = "StockCard-BaseOn-CostPrice" Then


        '    Cmd.Connection = Cnn
        '    Cmd.CommandType = CommandType.Text
        '    Cmd.CommandText = "SELECT	Ph_tblInvoiceMedicalStockIn.IvRecievedNum,drugBrandName AS [Brand Name],productMadeIn AS [Made in],CONVERT(NVARCHAR,expiredDate,107) AS [Expired Date],Strength,Form,realCost AS [Cost Price],RetailCost AS [Sale Price],(RetailCost-realCost) AS Earned,(RetailCost-realCost)/Realcost AS Markup " & _
        '                     " FROM Ph_tblDrugMaster INNER JOIN Ph_tblDrugDetail ON Ph_tblDrugMaster.drugMasterCode = Ph_tblDrugDetail.drugMasterCode                                                                                                                                                                                     " & _
        '                     " INNER JOIN Ph_tblInvoiceMedicalStockIn ON Ph_tblDrugDetail.invoiceMedicalStockInCode = Ph_tblInvoiceMedicalStockIn.invoiceMedicalStockInCode                                                                                                                                                               " & _
        '                     " WHERE  Ph_tblDrugDetail.isActive='True'  AND (RetailCost-realCost) > 0  " & byBrandName & _
        '                     " ORDER BY [" & SortColumn_cbo.Text & "] " & SortType

        '    Da.SelectCommand = Cmd
        '    Da.Fill(Ds, "CostPrice")
        '    Da = Nothing

        '    Dim Report As New XtraRpt_StockCardBaseOnCostPrice
        '    PrintControl1.PrintingSystem = Report.PrintingSystem
        '    Report.DataSource = Ds.Tables("CostPrice")
        '    Report.CreateDocument()

        'End If


        '' Bind the report's printing system to the print control. 
        'Me.Cursor = Cursors.WaitCursor
        'PrintControl1.Refresh()
        'Me.Cursor = Cursors.Default

    End Sub


End Class