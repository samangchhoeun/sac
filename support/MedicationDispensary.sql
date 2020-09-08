Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports Microsoft.Office.Interop
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Utils

Public Class frm_dispensary
    Public DtDispensary, DtDispensaryDetail As New DataTable
    Public index As Integer = 0

    Private Sub frm_dispensary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initialize_ComboBox()
        PrescriptionDate_DateEdit.Text = Format(Now, "MMM dd, yyyy")
        ptCode_txt.Focus()
        InitValidationRules()
        prescriptionCode_txt.Text = GetMedicalAutoNumber()
        cboCampus.Text = "MTT"

        If checkPermission("Write", False) = False Then 'Disable Add for user that don't have permission to write information
            GroupMedicationInformation.Enabled = False
        End If
    End Sub

    Public Sub Initialize_ComboBox()
        Dim table As DataTable
        Dim Drow As DataRow

        Me.cboCampus.Properties.Items.Clear()
        'table = Get_DataTable("SELECT CampusAbbr FROM SystemDB.dbo.tblCampus ")
        'For Each Drow In table.Rows
        '    cboCampus.Properties.Items.Add(Drow("CampusAbbr"))
        'Next
        'table.Clear()


        table = Get_DataTable("SELECT ClinicLocation FROM tblClinicLocation")
        cboCampus.Properties.Items.Clear()
        For Each Drow In table.Rows
            cboCampus.Properties.Items.Add(Drow("ClinicLocation"))
        Next
        table.Clear()



        Prescriber_cbo.Properties.Items.Clear()
        table = Get_DataTable("SELECT drName From TblDoctor WHERE isActive='TRUE'")
        For Each Drow In table.Rows
            Prescriber_cbo.Properties.Items.Add(Drow("drName"))
        Next
        table.Clear()

        BrandName_LookUpEdit1.Properties.Columns.Clear()
        Generic_LookUpEdit1.Properties.Columns.Clear()
        Generic_LookUpEdit1.Properties.DataSource = Nothing
        BrandName_LookUpEdit1.Properties.DataSource = Nothing

        Dim StrBrandName As String
        StrBrandName = " SELECT Ph_tblDrugDetail.drugMasterCode AS [Master Code],drugDetailCode as Code,drugCode,drugBrandName as [Brand Name],drugGenericName as [Generic Name],Strength,Form,Ph_tblDrugDetail.productMadeIn AS [Made in],convert(nvarchar,ExpiredDate,107) AS ExpiredDates,Ph_tblDrugDetail.RealCost,  mainRetailPrice AS RetailCost,StockOnHand " & _
              " FROM Ph_tblDrugMaster " & _
              " INNER JOIN Ph_tblDrugDetail " & _
              " ON ph_tblDrugMaster.drugMasterCode = ph_tblDrugDetail.drugMasterCode " & _
              " WHERE Ph_tblDrugMaster.isActive='True' AND Ph_tblDrugDetail.isActive='True' AND Ph_tblDrugMaster.branch='" & CurrentBranch & "' AND Ph_tblDrugDetail.StockOnHand > 0 AND drugItemType='Pharmacy' and Ph_tblDrugDetail.campus='" & cboCampus.Text & "' ORDER BY drugBrandName,ExpiredDate "

        Dim StrGenericName As String
        StrGenericName = "SELECT Ph_tblDrugDetail.drugMasterCode AS [Master Code],drugCode,drugDetailCode as Code,drugGenericName as [Generic Name],drugBrandName as [Brand Name],Strength,Form,Ph_tblDrugDetail.productMadeIn AS [Made in],convert(nvarchar,ExpiredDate,107) AS ExpiredDates,Ph_tblDrugDetail.RealCost,  mainRetailPrice AS RetailCost,StockOnHand " & _
              " FROM Ph_tblDrugMaster " & _
              " INNER JOIN Ph_tblDrugDetail " & _
              " ON ph_tblDrugMaster.drugMasterCode = ph_tblDrugDetail.drugMasterCode " & _
              " WHERE Ph_tblDrugMaster.isActive='True' AND Ph_tblDrugDetail.isActive='True' AND Ph_tblDrugMaster.branch='" & CurrentBranch & "' AND Ph_tblDrugDetail.StockOnHand > 0 AND drugItemType='Pharmacy'  and Ph_tblDrugDetail.campus='" & cboCampus.Text & "' ORDER BY drugGenericName,ExpiredDate "


        table = Get_DataTable(StrBrandName)
        BrandName_LookUpEdit1.Properties.DataSource = table
        BrandName_LookUpEdit1.Properties.DisplayMember = "Brand Name"
        BrandName_LookUpEdit1.Properties.ValueMember = "Code"
        BrandName_LookUpEdit1.Properties.PopupWidth = 900
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Master Code", 0, "Master Code"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Code", 0, "Code"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("drugCode", 0, "drugCode"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Brand Name", 30, "Brand Name"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Generic Name", 50, "Generic Name"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Strength", 15, "Strength"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Form", 10, "Form"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Made in", 20, "Made in"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("ExpiredDates", 15, "ExpiredDates"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("RealCost", 15, "RealCost"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("RetailCost", 15, "RetailCost"))
        BrandName_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("StockOnHand", 20, "StockOnHand"))
        ' Table.Clear()

        table = Get_DataTable(StrGenericName)
        Generic_LookUpEdit1.Properties.DataSource = table
        Generic_LookUpEdit1.Properties.DisplayMember = "Generic Name"
        Generic_LookUpEdit1.Properties.ValueMember = "Code"
        Generic_LookUpEdit1.Properties.PopupWidth = 900
        Generic_LookUpEdit1.Properties.BestFitWidth = True

        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Master Code", 0, "Master Code"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Code", 0, "Code"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("drugCode", 0, "drugCode"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Generic Name", 50, "Generic Name"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Brand Name", 30, "Brand Name"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Strength", 15, "Strength"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Form", 10, "Form"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("Made in", 20, "Made in"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("ExpiredDates", 15, "ExpiredDates"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("RealCost", 15, "RealCost"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("RetailCost", 15, "RetailCost"))
        Generic_LookUpEdit1.Properties.Columns.Add(New LookUpColumnInfo("StockOnHand", 20, "StockOnHand"))

    End Sub

    Private Sub ptCode_txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ptCode_txt.KeyPress
        ptCode_keyPress(ptCode_txt, e)
    End Sub

    Private Sub LoadPatient()
        If ptCode_txt.Text.Trim = "" Then Clear(True) : Exit Sub


        If Len(ptCode_txt.Text) = 10 Then
            Dim table As New DataTable
            table = Get_DataTable("Select  eName,Gender,DateOfBirth,phone1,ptType,Occupation FROM tblPatient WHERE ptCode='" & Get_Number(ptCode_txt.Text) & "' and isActive='True'")
            If table.Rows.Count > 0 Then
                ptName_txt.Text = table.Rows(0).Item(0).ToString
                ptSex_lbl.Text = table.Rows(0).Item(1).ToString
                ptAge_lbl.Text = Now.Year - Year(table.Rows(0).Item(2).ToString)
                ptDOB_lbl.Text = Format(table.Rows(0).Item(2), "MMM dd, yyyy")
                ptOccupation_lbl.Text = table.Rows(0).Item(5).ToString

                cboCampus.Enabled = False
            Else
                MsgBox("Patient code not found")
                ptName_txt.Text = ""
                ptSex_lbl.Text = ""
                ptAge_lbl.Text = ""
                ptOccupation_lbl.Text = ""
                Clear(True)
                index = 0
                ptCode_txt.Focus()
                cboCampus.Enabled = True
            End If
        Else
            MsgBox("Please input correct patient code", , "Confirm")
            ptName_txt.Text = ""
            ptSex_lbl.Text = ""
            ptAge_lbl.Text = ""
            ptOccupation_lbl.Text = ""
            ptCode_txt.Focus()
        End If


        If ptName_txt.Text.Trim = "" Then
            ptCode_txt.Text = ""
            ptCode_txt.Focus()
        Else
            Initialize_Datatable(Get_Number(ptCode_txt.Text))
        End If

        index = 0
        Display_Dispensary(index)
        Enable_Navigation()
    End Sub

    Public Sub ptCode_txt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ptCode_txt.Validated
        LoadPatient()
    End Sub

    Private Sub PrescriptionDate_DateEdit_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrescriptionDate_DateEdit.Validated
        If PrescriptionDate_DateEdit.Text.Trim <> "" Then
            PrescriptionDate_DateEdit.Text = Format(CDate(PrescriptionDate_DateEdit.Text), "MMM dd, yyyy")
        End If
    End Sub

    Private Sub ClearAll_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAll_Cmd.Click
        Clear(True)
        index = 0
        ptCode_txt.Focus()
    End Sub

    Private Sub Qty_txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Qty_txt.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub BrandName_LookUpEdit1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrandName_LookUpEdit1.Validated
        Qty_txt.Focus()
    End Sub

    Private Sub Generic_LookUpEdit1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Generic_LookUpEdit1.Validated
        Qty_txt.Focus()
    End Sub

    Private Function CheckStockOnHand(ByRef drugDetailCode As Integer) As Integer
        Dim cmd As New SqlCommand
        cmd.Connection = Cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT StockOnHand From Ph_tblDrugDetail WHERE drugDetailCode=" & drugDetailCode
        If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
        Try

            If MedicationDispensaryDetailCode_txt.Text.Trim <> "" Then
                Return cmd.ExecuteScalar() + QuantityBeforeUpdate_txt.Text
            Else
                Return cmd.ExecuteScalar()
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Private Sub SaveMed_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveMed_cmd.Click
        If checkPermission("Write", True) = False Then Exit Sub
        If DxValidationProvider1.Validate = False Then Exit Sub
        If cancelInvoiceStatus_lbl.Text.Trim <> "" Then MsgBox("Sorry you can't make change. Prescription already cancelled", , "Confirm") : Exit Sub
        If ptCode_txt.Text.Trim = "" Then MsgBox("Please input patient code", , "Confirm") : Exit Sub
        If cboCampus.Text.Trim = "" Then MsgBox("Campus is required.", MsgBoxStyle.Information) : Exit Sub

        If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
        Dim myTransaction = Cnn.BeginTransaction()
        Dim Cmd As New SqlCommand
        Dim StrQurSave As String
        Dim StrQurUpdate As String
        Cmd.Connection = Cnn
        Cmd.Transaction = myTransaction   ' Start a local transaction.

        '============Return Invoice Number=========Becast Transaction could not run comment outside transaction
        Dim GetAutoNumber As String
        Dim dread As SqlDataReader
        Dim invoiceNumber() As String = Nothing
        Cmd.CommandType = CommandType.Text

        Cmd.CommandText = "Select Top 1 DisCode from Ph_tblMedicationDispensary WHERE DisCode like 'D" & Mid(Now.Year, 3, 2) & "%' and branch='" & CurrentBranch & "' order by DisCode DESC"
        dread = Cmd.ExecuteReader
        While dread.Read
            invoiceNumber = Split(dread("DisCode"), "D" & Mid(Now.Year, 3, 2))
        End While
        dread.Close()
        If IsNothing(invoiceNumber) Then
            GetAutoNumber = "D" & Mid(Now.Year, 3, 2) & "000001"
        Else
            If invoiceNumber(1) + 1 <= 9 Then
                GetAutoNumber = "D" & Mid(Now.Year, 3, 2) & "00000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 99 Then
                GetAutoNumber = "D" & Mid(Now.Year, 3, 2) & "0000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 999 Then
                GetAutoNumber = "D" & Mid(Now.Year, 3, 2) & "000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 9999 Then
                GetAutoNumber = "D" & Mid(Now.Year, 3, 2) & "00" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 99999 Then
                GetAutoNumber = "D" & Mid(Now.Year, 3, 2) & "0" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 999999 Then
                GetAutoNumber = "D" & Mid(Now.Year, 3, 2) & invoiceNumber(1) + 1
            Else
                MsgBox("Prescription Number is overload 999999pt/year only. Please contact administrator", MsgBoxStyle.Critical, "Over Load")
                Exit Sub
            End If
        End If
        '=========================================

        If Qty_txt.Text.Trim = "" Then Qty_txt.Text = 1

        '===Compare QTY Request with Stock On Hand LIVE in Table Ph_tblDrugDetail =========== 
        Dim CurrentSOH As Integer
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "SELECT StockOnHand From Ph_tblDrugDetail WHERE drugDetailCode=" & BrandName_LookUpEdit1.GetColumnValue("Code").ToString
        If MedicationDispensaryDetailCode_txt.Text.Trim <> "" Then
            CurrentSOH = Cmd.ExecuteScalar() + QuantityBeforeUpdate_txt.Text
        Else
            CurrentSOH = Cmd.ExecuteScalar()
        End If
        If IIf(Qty_txt.Text.Trim = "", 1, Qty_txt.Text) > CurrentSOH Then
            MsgBox("Sorry current stock on hand smaller than quantity requested", , "Confirm")
            Exit Sub
        End If
        '===============================================================================
        Cmd.CommandType = CommandType.Text
        StrQurSave = " INSERT INTO Ph_tblMedicationDispensary (DisCode,ptCode, drPrescriber, dateTimeStamp, remark, isCancel, inputBy, inputDate, isOtherDispensary, dispensaryType, branch,DisCampus)" & _
                     " VALUES (@DisCode,@ptCode, @drPrescriber, @dateTimeStamp, @remark, @isCancel, @inputBy, @inputDate, @isOtherDispensary, @dispensaryType, @branch,@DisCampus) "
        StrQurUpdate = " UPDATE Ph_tblMedicationDispensary SET drPrescriber=@drPrescriber , dateTimeStamp=@dateTimeStamp, remark=@remark, isCancel=@isCancel, UpdateBy=@UpdateBy, UpdateDate=@UpdateDate, isOtherDispensary=@isOtherDispensary, dispensaryType=dispensaryType, branch=@branch,DisCampus=@DisCampus " & _
                       " WHERE MedicationDispensaryCode= " & MedicationDispensaryCode_txt.Text
        Cmd.Parameters.Clear()
        If MedicationDispensaryCode_txt.Text.Trim = "" Then '  Save Mode
            Cmd.CommandText = StrQurSave
            Cmd.Parameters.AddWithValue("@inputBy", UserName)
            Cmd.Parameters.AddWithValue("@inputDate", Now)
            Cmd.Parameters.AddWithValue("@DisCode", GetAutoNumber)
        Else ' update mode
            Cmd.CommandText = StrQurUpdate
            Cmd.Parameters.AddWithValue("@updateby", UserName)
            Cmd.Parameters.AddWithValue("@updatedate", Now)
        End If
        With Cmd.Parameters
            .AddWithValue("@ptCode", Get_Number(ptCode_txt.Text))
            .AddWithValue("@drPrescriber", Prescriber_cbo.Text)
            .AddWithValue("@dateTimeStamp", PrescriptionDate_DateEdit.Text)
            .AddWithValue("@remark", RxRemark_MemoEdit.Text)
            .AddWithValue("@isCancel", False)
            .AddWithValue("@isOtherDispensary", False)
            .AddWithValue("@dispensaryType", DBNull.Value)
            .AddWithValue("@branch", CurrentBranch)
            .AddWithValue("@DisCampus", cboCampus.Text)
        End With
        Try
            If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
            Cmd.ExecuteNonQuery() 'Save Record to table Ph_tblMedicationDispensary

            If MedicationDispensaryCode_txt.Text.Trim = "" Then
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT MAX (MedicationDispensaryCode) AS MedicationDispensaryCode FROM Ph_tblMedicationDispensary WHERE Branch ='" & CurrentBranch & "'"
                ' Cmd.CommandText = "SELECT Top 1 MedicationDispensaryCode FROM Ph_tblMedicationDispensary WHERE Branch ='" & CurrentBranch & "' ORDER BY MedicationDispensaryCode DESC "
                MedicationDispensaryCode_txt.Text = Cmd.ExecuteScalar()
            End If
            Cmd.Parameters.Clear()

            If MedicationDispensaryDetailCode_txt.Text.Trim = "" Then
                Cmd.CommandText = "Insert Into Ph_tblMedicationDispensaryDetail ( MedicationDispensaryCode, drugDetailCode, Quantity, retailCost, realCost,remark, isActive, inputBy, inputDate, branch,DisCampus)" & _
                                           " VALUES (@MedicationDispensaryCode, @drugDetailCode, @Quantity, @retailCost, @realCost,@remark, @isActive, @inputBy, @inputDate, @branch,@DisCampus) "
                Cmd.Parameters.AddWithValue("@inputBy", UserName)
                Cmd.Parameters.AddWithValue("@inputDate", Now)
            Else
                Cmd.CommandText = "UPDATE  Ph_tblMedicationDispensaryDetail SET MedicationDispensaryCode=@MedicationDispensaryCode,drugDetailCode=@drugDetailCode,Quantity=@Quantity,retailCost=@retailCost,realCost=@realCost,remark=@remark,isActive=@isActive,updateby=@updateby,updatedate=@updatedate,branch=@branch,DisCampus=@DisCampus " & _
                    "WHERE MedicationDispensaryDetailCode=" & MedicationDispensaryDetailCode_txt.Text
                Cmd.Parameters.AddWithValue("@updateBy", UserName)
                Cmd.Parameters.AddWithValue("@updateDate", Now)
            End If

            With Cmd.Parameters
                .AddWithValue("@MedicationDispensaryCode", MedicationDispensaryCode_txt.Text)
                .AddWithValue("@drugDetailCode", BrandName_LookUpEdit1.GetColumnValue("Code"))
                .AddWithValue("@Quantity", IIf(Qty_txt.Text.Trim = "", 1, Qty_txt.Text))
                .AddWithValue("@realCost", IIf(costPrice_txt.Text = "", DBNull.Value, costPrice_txt.Text))
                .AddWithValue("@retailCost", IIf(salePrice_txt.Text = "", DBNull.Value, salePrice_txt.Text))
                .AddWithValue("@remark", MedicalRemark_txt.Text)
                .AddWithValue("@branch", CurrentBranch)
                .AddWithValue("@isActive", True)
                .AddWithValue("@DisCampus", cboCampus.Text)
            End With
            If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
            Cmd.ExecuteNonQuery()

            '======================================================
            If DrugDetailCode_BeforeUpdate_txt.Text.Trim <> "" Then
                'If user update the medication and change to other medication name 
                'we should add the SOH to medication Detail product and old medication master product 
                If DrugDetailCode_BeforeUpdate_txt.Text <> BrandName_LookUpEdit1.GetColumnValue("Code").ToString Then
                    If Not Cnn.State = ConnectionState.Open Then Cnn.Open()

                    '================================================================
                    Dim TmpDrugDetailSOH As Integer = 0
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = "SELECT StockOnHand from  Ph_tblDrugDetail  WHERE drugDetailCode=" & GrdVw_Medical.GetFocusedRow("drugDetailCode").ToString
                    TmpDrugDetailSOH = Cmd.ExecuteScalar()


                    Dim TmpMainCampusSHO As Integer = 0
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = " SELECT sum(Ph_tblDrugDetail.StockOnHand) AS StockOnHand FROM dbo.Ph_tblDrugMaster INNER JOIN dbo.Ph_tblDrugDetail ON dbo.Ph_tblDrugMaster.drugMasterCode = dbo.Ph_tblDrugDetail.drugMasterCode " & _
                                       " WHERE (dbo.Ph_tblDrugMaster.drugItemType = 'Pharmacy') AND (dbo.Ph_tblDrugMaster.isActive = 'True') AND (dbo.Ph_tblDrugDetail.isActive = 'True') " & _
                                       " AND dbo.Ph_tblDrugDetail.campus = '" & cboCampus.Text & "' AND (dbo.Ph_tblDrugMaster.drugMasterCode = " & GrdVw_Medical.GetFocusedRow("drugMasterCode").ToString & "  ) GROUP BY   Ph_tblDrugMaster.drugMasterCode "
                    TmpMainCampusSHO = Cmd.ExecuteScalar()


                    Dim TmpDrugMasterSOH As Integer = 0
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = "SELECT totalSOH from Ph_tblDrugMaster  WHERE drugMasterCode=" & GrdVw_Medical.GetFocusedRow("drugMasterCode").ToString
                    TmpDrugMasterSOH = Cmd.ExecuteScalar()
                    '==================================================================
                    '========Insert to Ph_tblStockTransaction=========================
                    Cmd.CommandText = "INSERT INTO Ph_tblStockTransaction (drugDetailCode, transDate, mainBegQtySOH,mainCampusBegQtySOH, detailBegQtySOH, QtyDistributed, detailEndQtySOH,mainCampusEndQtySOH, mainEndQtySOH, inputby, inputdate, branch, remark, isActive,DisCampus)" & _
                                      " VALUES (" & GrdVw_Medical.GetFocusedRow("drugDetailCode").ToString & ",'" & Now.Date & "', " & TmpDrugMasterSOH & " ," & TmpMainCampusSHO & "," & TmpDrugDetailSOH & ",-" & Val(QuantityBeforeUpdate_txt.Text) & "," & TmpDrugDetailSOH + Val(QuantityBeforeUpdate_txt.Text) & "," & TmpMainCampusSHO + Val(QuantityBeforeUpdate_txt.Text) & " ," & TmpDrugMasterSOH + Val(QuantityBeforeUpdate_txt.Text) & ",'" & UserName & "' , '" & Now & "','" & CurrentBranch & "', 'IV Dispensary Nº: " & prescriptionCode_txt.Text & " : " & RxRemark_MemoEdit.Text & " - Dispensary Updated','True','" & cboCampus.Text & "')"
                    Cmd.ExecuteNonQuery()
                    '================================================================

                    MedicationDispensaryDetailCode_txt.Text = ""
                    '=========Add SOH + QuantityBeforeUpdate_txt  To DrugDetailCode======
                    Cmd.CommandText = "UPDATE Ph_tblDrugDetail SET StockOnHand=StockOnHand + " & QuantityBeforeUpdate_txt.Text & " WHERE drugDetailCode=" & DrugDetailCode_BeforeUpdate_txt.Text
                    Cmd.ExecuteNonQuery()
                    '========Add TotalSOH + QuantityBeforeUpdate_txt to DrugMasterCode
                    Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalSOH=totalSOH + " & QuantityBeforeUpdate_txt.Text & " WHERE drugMasterCode=" & DrugMasterCode_BeforeUpdate_txt.Text
                    Cmd.ExecuteNonQuery()
                End If
            End If
            '=====================================================

            If MedicationDispensaryDetailCode_txt.Text.Trim = "" Then '===Only Save mode ======
                '======================Minus or Update Stock On Hand from table Ph_tblDrugDetail================
                Cmd.CommandText = "UPDATE Ph_tblDrugDetail SET StockOnHand=StockOnHand-" & IIf(Qty_txt.Text.Trim = "", 1, Qty_txt.Text) & " WHERE drugDetailCode=" & BrandName_LookUpEdit1.GetColumnValue("Code").ToString
                Cmd.ExecuteNonQuery()
                '======================Minus or Update Stock On Hand from table Ph_tblDrugDetail================
                '===Only Save mode ======
                Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalSOH=totalSOH - " & IIf(Qty_txt.Text.Trim = "", 1, Qty_txt.Text) & " WHERE drugMasterCode=" & BrandName_LookUpEdit1.GetColumnValue("Master Code").ToString
                Cmd.ExecuteNonQuery()
                '===============================================================================================

                '============Get SOH BY CAMPUS=========
                Dim TmpMainCampusSHO As Integer = 0
                Dim Str As String
                Str = " SELECT sum(Ph_tblDrugDetail.StockOnHand) AS StockOnHand FROM dbo.Ph_tblDrugMaster INNER JOIN dbo.Ph_tblDrugDetail ON dbo.Ph_tblDrugMaster.drugMasterCode = dbo.Ph_tblDrugDetail.drugMasterCode " & _
                      " WHERE (dbo.Ph_tblDrugMaster.drugItemType = 'Pharmacy') AND (dbo.Ph_tblDrugMaster.isActive = 'True') AND (dbo.Ph_tblDrugDetail.isActive = 'True') " & _
                      " AND dbo.Ph_tblDrugDetail.campus = '" & cboCampus.Text & "' AND (dbo.Ph_tblDrugMaster.drugMasterCode = " & Generic_LookUpEdit1.GetColumnValue("Master Code").ToString & " ) GROUP BY   Ph_tblDrugMaster.drugMasterCode "
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Str
                TmpMainCampusSHO = Cmd.ExecuteScalar()
                '====================================

                Dim TmpDrugMasterSOH As Integer = 0
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT totalSOH from Ph_tblDrugMaster  WHERE drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Master Code").ToString
                TmpDrugMasterSOH = Cmd.ExecuteScalar()

                '========Insert to Ph_tblStockTransaction=========================
                Cmd.CommandText = "INSERT INTO Ph_tblStockTransaction (drugDetailCode, transDate, mainBegQtySOH, mainCampusBegQtySOH, detailBegQtySOH, QtyDistributed, detailEndQtySOH,mainCampusEndQtySOH, mainEndQtySOH, inputby, inputdate, branch, remark, isActive,DisCampus)" & _
                                  " VALUES (" & BrandName_LookUpEdit1.GetColumnValue("Code").ToString & ",'" & Now.Date & "', " & TmpDrugMasterSOH + Val(Qty_txt.Text) & " ," & TmpMainCampusSHO + Val(Qty_txt.Text) & " ," & Generic_LookUpEdit1.GetColumnValue("StockOnHand").ToString & "," & Val(Qty_txt.Text) & "," & Generic_LookUpEdit1.GetColumnValue("StockOnHand").ToString - Val(Qty_txt.Text) & " ," & TmpMainCampusSHO & "," & TmpDrugMasterSOH & ",'" & UserName & "' , '" & Now & "','" & CurrentBranch & "', 'IV Dispensary Nº: " & prescriptionCode_txt.Text & " : " & RxRemark_MemoEdit.Text & " - Dispensary','True','" & cboCampus.Text & "')"
                Cmd.ExecuteNonQuery()
                '================================================================

            Else '===Update Mode==========

                '''''==========Addd QTY before update to get Origenal SOH in table Ph_tblDrugDetail  ================
                Cmd.CommandText = "UPDATE Ph_tblDrugDetail SET StockOnHand=StockOnHand + " & QuantityBeforeUpdate_txt.Text & " WHERE drugDetailCode=" & BrandName_LookUpEdit1.GetColumnValue("Code").ToString
                Cmd.ExecuteNonQuery()
                '======================Addd QTY before update to get Origenal SOH in  table Ph_tblDrugMaster================
                '===Only Save mode ======
                Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalSOH=totalSOH + " & QuantityBeforeUpdate_txt.Text & " WHERE drugMasterCode=" & BrandName_LookUpEdit1.GetColumnValue("Master Code").ToString
                Cmd.ExecuteNonQuery()


                '===================================================
                Cmd.CommandText = "UPDATE Ph_tblDrugDetail SET StockOnHand=StockOnHand-" & IIf(Qty_txt.Text.Trim = "", 1, Qty_txt.Text) & " WHERE drugDetailCode=" & BrandName_LookUpEdit1.GetColumnValue("Code").ToString
                Cmd.ExecuteNonQuery()
                '======================Minus or Update Stock On Hand from table Ph_tblDrugMaster================
                '===Only Save mode ======
                Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalSOH=totalSOH - " & IIf(Qty_txt.Text.Trim = "", 1, Qty_txt.Text) & " WHERE drugMasterCode=" & BrandName_LookUpEdit1.GetColumnValue("Master Code").ToString
                Cmd.ExecuteNonQuery()


                '============Get SOH BY CAMPUS=========
                Dim TmpMainCampusSHO As Integer = 0
                Dim Str As String
                Str = " SELECT sum(Ph_tblDrugDetail.StockOnHand) AS StockOnHand FROM dbo.Ph_tblDrugMaster INNER JOIN dbo.Ph_tblDrugDetail ON dbo.Ph_tblDrugMaster.drugMasterCode = dbo.Ph_tblDrugDetail.drugMasterCode " & _
                      " WHERE (dbo.Ph_tblDrugMaster.drugItemType = 'Pharmacy') AND (dbo.Ph_tblDrugMaster.isActive = 'True') AND (dbo.Ph_tblDrugDetail.isActive = 'True') " & _
                      " AND dbo.Ph_tblDrugDetail.campus = '" & cboCampus.Text & "' AND (dbo.Ph_tblDrugMaster.drugMasterCode = " & Generic_LookUpEdit1.GetColumnValue("Master Code").ToString & " ) GROUP BY   Ph_tblDrugMaster.drugMasterCode "
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Str
                TmpMainCampusSHO = Cmd.ExecuteScalar()
                '====================================


                '================================================================
                Dim TmpDrugDetailSOH As Integer = 0
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT StockOnHand from  Ph_tblDrugDetail  WHERE drugDetailCode=" & GrdVw_Medical.GetFocusedRow("drugDetailCode").ToString
                TmpDrugDetailSOH = Cmd.ExecuteScalar()

                Dim TmpDrugMasterSOH As Integer = 0
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT totalSOH from Ph_tblDrugMaster  WHERE drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Master Code").ToString
                TmpDrugMasterSOH = Cmd.ExecuteScalar()
                '==================================================================

                '========Insert to Ph_tblStockTransaction=========================
                Cmd.CommandText = "INSERT INTO Ph_tblStockTransaction (drugDetailCode, transDate, mainBegQtySOH,mainCampusBegQtySOH, detailBegQtySOH, QtyDistributed, detailEndQtySOH, mainCampusEndQtySOH,mainEndQtySOH, inputby, inputdate, branch, remark, isActive,DisCampus)" & _
                                  " VALUES (" & BrandName_LookUpEdit1.GetColumnValue("Code").ToString & ",'" & Now.Date & "', " & TmpDrugMasterSOH + Val(Qty_txt.Text) - Val(QuantityBeforeUpdate_txt.Text) & " ," & TmpMainCampusSHO + Val(Qty_txt.Text) - Val(QuantityBeforeUpdate_txt.Text) & " ," & Generic_LookUpEdit1.GetColumnValue("StockOnHand").ToString & ",-" & Val(QuantityBeforeUpdate_txt.Text) & "," & TmpDrugDetailSOH + Val(Qty_txt.Text) & " , " & TmpMainCampusSHO + Val(Qty_txt.Text) & " ," & TmpDrugMasterSOH + Val(Qty_txt.Text) & ",'" & UserName & "' , '" & Now & "','" & CurrentBranch & "', 'IV Dispensary Nº: " & prescriptionCode_txt.Text & " : " & RxRemark_MemoEdit.Text & " - Dispensary Updated','True','" & cboCampus.Text & "')"
                Cmd.ExecuteNonQuery()
                '================================================================

                '========Insert to Ph_tblStockTransaction=========================
                Cmd.CommandText = "INSERT INTO Ph_tblStockTransaction (drugDetailCode, transDate, mainBegQtySOH,mainCampusBegQtySOH, detailBegQtySOH, QtyDistributed, detailEndQtySOH,mainCampusEndQtySOH, mainEndQtySOH, inputby, inputdate, branch, remark, isActive,DisCampus)" & _
                                  " VALUES (" & BrandName_LookUpEdit1.GetColumnValue("Code").ToString & ",'" & Now.Date & "', " & TmpDrugMasterSOH + Val(Qty_txt.Text) & " , " & TmpMainCampusSHO + Val(Qty_txt.Text) & "," & TmpDrugDetailSOH + Val(Qty_txt.Text) & "," & Val(Qty_txt.Text) & "," & TmpDrugDetailSOH & " ," & TmpMainCampusSHO & "," & TmpDrugMasterSOH & ",'" & UserName & "' , '" & Now & "','" & CurrentBranch & "', 'IV Dispensary Nº: " & prescriptionCode_txt.Text & " : " & RxRemark_MemoEdit.Text & " - Dispensary','True','" & cboCampus.Text & "')"
                Cmd.ExecuteNonQuery()
                '================================================================

            End If

            myTransaction.Commit()
        Catch ex As Exception
            myTransaction.Rollback()
            MsgBox(Err.Description)
            MsgBox("Saving Data Error Please Try again.", , "Comfirm")
            Exit Sub
        End Try

        '=====================================================================
        '======Clear Medication Information Section===========================
        BrandName_LookUpEdit1.EditValue = DBNull.Value                      '=
        Generic_LookUpEdit1.EditValue = DBNull.Value
        Madein_txt.Text = ""
        DrugDetailCode_BeforeUpdate_txt.Text = ""
        DrugMasterCode_BeforeUpdate_txt.Text = ""
        MedicationDispensaryDetailCode_txt.Text = ""
        QuantityBeforeUpdate_txt.Text = ""
        ExpiredDate_txt.Text = ""
        Qty_txt.Text = ""
        salePrice_txt.Text = ""
        costPrice_txt.Text = ""
        MedicalRemark_txt.Text = ""
        StockOnHand_txt.Text = ""
        form_txt.Text = ""
        Strength_txt.Text = ""
        BrandName_LookUpEdit1.Focus()
        cboCampus.Enabled = False
        '=====================================================================
        If index = 0 Then
            Initialize_Datatable(Get_Number(ptCode_txt.Text))
        Else
            Dim TmpValue As Integer
            Initialize_Datatable(Get_Number(ptCode_txt.Text))
            index = TmpValue
        End If

        Display_Dispensary(index)
        Enable_Navigation()
        Initialize_ComboBox()
        frm_ManageLabStockCard.LoadData_ToCombo()
        frm_ManageLabStockCard.LoadMedicationList()
        frm_OtherDispensary.Initialize_ComboBox()
        frm_StockIn.Load_Medical_To_List()
    End Sub

    Public Sub Initialize_Datatable(ByVal ptCode As String)

        '=====Initialize Dispensary=========
        DtDispensary.Clear()
        DtDispensary = Get_DataTable("SELECT * FROM Ph_tblMedicationDispensary WHERE ptCode='" & ptCode & "' AND branch = '" & CurrentBranch & "' ORDER BY MedicationDispensaryCode DESC")
        '===================================


        '=====Initialize DispensaryDetail===
        DtDispensaryDetail.Clear()
        Dim Str As String
        Str = " SELECT MedicationDispensaryDetailCode,Ph_tblMedicationDispensary.MedicationdiSpensaryCode,DrugBrandName as [Brand Name],DrugGenericName as [Generic Name],ProductMadeIn as [Made in],Ph_tblDrugMaster.Strength,Form,convert(nvarchar,ExpiredDate,107) AS ExpiredDate,Ph_tblMedicationDispensaryDetail.RealCost " & _
              " ,Ph_tblMedicationDispensaryDetail.RetailCost,Ph_tblMedicationDispensaryDetail.Quantity,Ph_tblMedicationDispensaryDetail.Quantity * Ph_tblMedicationDispensaryDetail.RetailCost AS [Line Total],Ph_tblDrugMaster.drugMasterCode,Ph_tblMedicationDispensaryDetail.drugDetailCode,Ph_tblMedicationDispensaryDetail.Remark  " & _
              " FROM Ph_tblDrugMaster INNER JOIN " & _
              " Ph_tblDrugDetail ON Ph_tblDrugMaster.drugMasterCode = Ph_tblDrugDetail.drugMasterCode INNER JOIN " & _
              " Ph_tblMedicationDispensaryDetail ON Ph_tblDrugDetail.drugDetailCode = Ph_tblMedicationDispensaryDetail.drugDetailCode INNER JOIN " & _
              " Ph_tblMedicationDispensary ON " & _
              " Ph_tblMedicationDispensaryDetail.MedicationDispensaryCode = Ph_tblMedicationDispensary.MedicationDispensaryCode " & _
              " WHERE ph_tblMedicationDispensary.ptCode='" & ptCode & "' AND ph_tblMedicationDispensaryDetail.isActive='True' "
        DtDispensaryDetail = Get_DataTable(Str)
        '==================================
        DtDispensaryDetail.PrimaryKey = New DataColumn() {DtDispensaryDetail.Columns("MedicationDispensaryDetailCode")}

    End Sub

    Public Sub Display_Dispensary(ByVal Row As Integer)
        Dim DrowDispensry As DataRow
        ' Dim DrowDispensryDetail() As DataRow
        If DtDispensary.Rows.Count = 0 Then
            Clear(False)
            index = 0
            Enable_Navigation()
            Exit Sub
        End If
        DrowDispensry = DtDispensary.Rows(Row)
        prescriptionCode_txt.Text = DrowDispensry("DisCode")
        PrescriptionDate_DateEdit.Text = Format(DrowDispensry("dateTimeStamp"), "MMM dd, yyyy")
        Prescriber_cbo.Text = DrowDispensry("drPrescriber")
        RxRemark_MemoEdit.Text = IIf(IsDBNull(DrowDispensry("Remark")), "", DrowDispensry("Remark"))
        MedicationDispensaryCode_txt.Text = DrowDispensry("MedicationdiSpensaryCode")
        cboCampus.Text = DrowDispensry("DisCampus")

        '==========Check isCancel============
        If DrowDispensry("isCancel") = True Then
            cancelInvoiceStatus_lbl.Text = DrowDispensry("cancelReason")
        Else
            cancelInvoiceStatus_lbl.Text = ""
        End If
        '====================================

        GrdCtr_Medical.DataSource = DtDispensaryDetail


        '========Row Postion========
        recordPosition_lbl.Text = index + 1 & "/" & DtDispensary.Rows.Count
        '===========================


        Dim SerivceView As ColumnView = GrdVw_Medical
        SerivceView.ActiveFilter.Add(SerivceView.Columns("MedicationdiSpensaryCode"),
                                     New ColumnFilterInfo("MedicationdiSpensaryCode =" & MedicationDispensaryCode_txt.Text & " ", ""))

        If GrdVw_Medical.RowCount > 0 Then

            GrdVw_Medical.Columns(0).Visible = False
            GrdVw_Medical.Columns(1).Visible = False
            GrdVw_Medical.Columns(12).Visible = False
            GrdVw_Medical.Columns(13).Visible = False
            GrdVw_Medical.Columns(14).Visible = False

            'GrdVw_Medical.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
            'GrdVw_Medical.Columns(7).SummaryItem.DisplayFormat = "Total = {0:C}"

            'GrdVw_Medical.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
            'GrdVw_Medical.Columns(8).SummaryItem.DisplayFormat = "Total = {0:C}"

            GrdVw_Medical.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
            GrdVw_Medical.Columns(10).SummaryItem.DisplayFormat = "Count = {0}"

            GrdVw_Medical.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
            GrdVw_Medical.Columns(11).SummaryItem.DisplayFormat = "Total = {0:C}"

            '=========Update to database ==============
            Dim TotalQTY As Double
            Dim LineTotal As Double
            For i As Integer = 0 To Me.GrdVw_Medical.RowCount - 1
                TotalQTY += GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("Quantity"))
                LineTotal += GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("Line Total"))
            Next
            Update_Record("UPDATE Ph_tblMedicationDispensary SET TotalAmount=" & LineTotal & ", TotalQuantity = " & TotalQTY & " WHERE MedicationdiSpensaryCode = " & MedicationDispensaryCode_txt.Text)
            '===========================================

            If checkPermission("Write", False) = False Then 'Hide real cost for user that don't have per mission
                GrdVw_Medical.Columns("RealCost").Visible = False
            End If
        End If

    End Sub

    Private Sub Enable_Navigation()
        If DtDispensary.Rows.Count > 0 Then
            moveNext_cmd.Enabled = True
            movePrevous_Cmd.Enabled = True
        Else
            moveNext_cmd.Enabled = False
            movePrevous_Cmd.Enabled = False
        End If
        If index > DtDispensary.Rows.Count Then
            moveNext_cmd.Enabled = False
        End If
        If index = 0 Then
            movePrevous_Cmd.Enabled = False
        End If

        If index = DtDispensary.Rows.Count - 1 Then
            moveNext_cmd.Enabled = False
        End If
        recordPosition_lbl.Text = index + 1 & "/" & DtDispensary.Rows.Count
    End Sub

    Private Sub movePrevous_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movePrevous_Cmd.Click
        If DtDispensary.Rows.Count = 0 Then Exit Sub
        Try
            If (Not index = 0) Then
                index -= 1
                Display_Dispensary(index)
                moveNext_cmd.Enabled = True
            Else
                Display_Dispensary(index)
                movePrevous_Cmd.Enabled = False
                moveNext_cmd.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub moveNext_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moveNext_cmd.Click
        If DtDispensary.Rows.Count = 0 Then Exit Sub
        Try
            If (Not index = DtDispensary.Rows.Count - 1) Then
                index += 1
                Display_Dispensary(index)
                movePrevous_Cmd.Enabled = True
            Else
                ' CearDetial()
                moveNext_cmd.Enabled = False
                movePrevous_Cmd.Enabled = True
                'recordPosition_lbl.Text = "Add New"
            End If
        Catch ex As Exception
            MsgBox("No record found")
        End Try
    End Sub

    Private Sub Clear(ByVal All As Boolean)

        If All Then
            ptCode_txt.Text = ""
            ptName_txt.Text = ""
            ptSex_lbl.Text = ""
            ptAge_lbl.Text = ""
            ptDOB_lbl.Text = ""
            ptOccupation_lbl.Text = ""
            recordPosition_lbl.Text = "New/0"
            DtDispensary.Clear()
            DtDispensaryDetail.Clear()
            '  ptCode_txt.Focus()

        End If
        cboCampus.Enabled = True
        prescriptionCode_txt.Text = GetMedicalAutoNumber()
        PrescriptionDate_DateEdit.Text = Format(Now, "MMM dd, yyyy")
        RxRemark_MemoEdit.Text = ""
        Prescriber_cbo.Text = ""
        Generic_LookUpEdit1.EditValue = DBNull.Value
        BrandName_LookUpEdit1.EditValue = DBNull.Value
        StockOnHand_txt.Text = ""
        Madein_txt.Text = ""
        cancelInvoiceStatus_lbl.Text = ""
        MedicationDispensaryDetailCode_txt.Text = ""
        QuantityBeforeUpdate_txt.Text = ""
        DrugDetailCode_BeforeUpdate_txt.Text = ""
        DrugMasterCode_BeforeUpdate_txt.Text = ""
        Strength_txt.Text = ""
        form_txt.Text = ""
        salePrice_txt.Text = ""
        ExpiredDate_txt.Text = ""
        Qty_txt.Text = ""
        costPrice_txt.Text = ""
        MedicalRemark_txt.Text = ""
        MedicationDispensaryCode_txt.Text = ""
        GrdCtr_Medical.DataSource = Nothing
        cboCampus.Text = ""
    End Sub

    Private Sub newRx_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newRx_cmd.Click
        'Clear(False)
        'Prescriber_cbo.Focus()
        Clear(False)
        index = 0
        Enable_Navigation()
        '===========Enable Navigation========
        recordPosition_lbl.Text = "New/" & DtDispensary.Rows.Count
        '====================================
        Prescriber_cbo.Focus()
    End Sub

    Private Sub InitValidationRules()
        '========English name =======
        Dim Con_Field_notEmpty As New ConditionValidationRule
        Con_Field_notEmpty.ConditionOperator = ConditionOperator.IsNotBlank
        Con_Field_notEmpty.ErrorType = ErrorType.Critical
        Con_Field_notEmpty.ErrorText = "Field is required "
        Me.DxValidationProvider1.SetValidationRule(PrescriptionDate_DateEdit, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(Prescriber_cbo, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(BrandName_LookUpEdit1, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(Generic_LookUpEdit1, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(ptCode_txt, Con_Field_notEmpty)
    End Sub

    Private Sub Close_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close_Cmd.Click
        Me.Close()
    End Sub

    Private Sub GrdCtr_Medical_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GrdCtr_Medical.MouseDown
        If GrdVw_Medical.RowCount > 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Edit_ContextmenueStrip.Show(GrdCtr_Medical, e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub DeleteMedicalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMedicalToolStripMenuItem.Click
        If cancelInvoiceStatus_lbl.Text.Trim <> "" Then MsgBox("Sorry you can't make change. Prescription already cancelled", , "Confirm") : Exit Sub
        If checkPermission("Delete", True) = False Then Exit Sub
        If GrdVw_Medical.RowCount = 0 Then Exit Sub

        If MsgBox("Are you sure to delete Medication << " & GrdVw_Medical.GetFocusedRow("Brand Name").ToString & " >> from list ?", vbYesNo, "Confirm") = vbYes Then
            If Update_Record("UPDATE Ph_tblMedicationDispensaryDetail SET  updateby='" & UserName & "',updatedate='" & Now() & "' ,isActive='False' WHERE MedicationDispensaryDetailCode=" & GrdVw_Medical.GetFocusedRow("MedicationDispensaryDetailCode").ToString) Then

                '======================Minus or Update Stock On Hand from table Ph_tblDrugDetail================
                Dim Cmd As New SqlCommand
                If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
                Cmd.Connection = Cnn
                Cmd.CommandType = CommandType.Text
                '===Only Save mode ======
                Cmd.CommandText = "UPDATE Ph_tblDrugDetail SET StockOnHand=StockOnHand + " & GrdVw_Medical.GetFocusedRow("Quantity").ToString & " WHERE drugDetailCode=" & GrdVw_Medical.GetFocusedRow("drugDetailCode").ToString
                Cmd.ExecuteNonQuery()
                '===Update Mode=========

                '======================Minus or Update Stock On Hand from table Ph_tblDrugDetail================
                '===Only Save mode ======
                Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalSOH=totalSOH + " & GrdVw_Medical.GetFocusedRow("Quantity").ToString & " WHERE drugMasterCode=" & GrdVw_Medical.GetFocusedRow("drugMasterCode").ToString
                Cmd.ExecuteNonQuery()
                '===Update Mode==========

                '================================================================
                Dim TmpDrugDetailSOH As Integer = 0
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT StockOnHand from  Ph_tblDrugDetail  WHERE drugDetailCode=" & GrdVw_Medical.GetFocusedRow("drugDetailCode").ToString
                TmpDrugDetailSOH = Cmd.ExecuteScalar()

                Dim TmpMainCampusSHO As Integer = 0
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = " SELECT sum(Ph_tblDrugDetail.StockOnHand) AS StockOnHand FROM dbo.Ph_tblDrugMaster INNER JOIN dbo.Ph_tblDrugDetail ON dbo.Ph_tblDrugMaster.drugMasterCode = dbo.Ph_tblDrugDetail.drugMasterCode " & _
                                   " WHERE (dbo.Ph_tblDrugMaster.drugItemType = 'Pharmacy') AND (dbo.Ph_tblDrugMaster.isActive = 'True') AND (dbo.Ph_tblDrugDetail.isActive = 'True') " & _
                                   " AND dbo.Ph_tblDrugDetail.campus = '" & cboCampus.Text & "' AND (dbo.Ph_tblDrugMaster.drugMasterCode = " & GrdVw_Medical.GetFocusedRow("drugMasterCode").ToString & "  ) GROUP BY   Ph_tblDrugMaster.drugMasterCode "
                TmpMainCampusSHO = Cmd.ExecuteScalar()

                Dim TmpDrugMasterSOH As Integer = 0
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT totalSOH from Ph_tblDrugMaster  WHERE drugMasterCode=" & GrdVw_Medical.GetFocusedRow("drugMasterCode").ToString
                TmpDrugMasterSOH = Cmd.ExecuteScalar()

                '========Insert to Ph_tblStockTransaction=========================
                Cmd.CommandText = "INSERT INTO Ph_tblStockTransaction (drugDetailCode, transDate, mainBegQtySOH,mainCampusBegQtySOH, detailBegQtySOH, QtyDistributed, detailEndQtySOH, mainCampusEndQtySOH , mainEndQtySOH, inputby, inputdate, branch, remark, isActive,DisCampus)" & _
                                  " VALUES (" & GrdVw_Medical.GetFocusedRow("drugDetailCode").ToString & ",'" & Now.Date & "', " & TmpDrugMasterSOH - GrdVw_Medical.GetFocusedRow("Quantity").ToString & " ," & TmpMainCampusSHO - GrdVw_Medical.GetFocusedRow("Quantity").ToString & "," & TmpDrugDetailSOH & "," & -GrdVw_Medical.GetFocusedRow("Quantity").ToString & "," & TmpDrugDetailSOH & "," & TmpMainCampusSHO & "," & TmpDrugMasterSOH & ",'" & UserName & "' , '" & Now & "','" & CurrentBranch & "', 'IV Dispensary Nº: " & prescriptionCode_txt.Text & " : " & RxRemark_MemoEdit.Text & " - Deleted','True','" & cboCampus.Text & "')"
                Cmd.ExecuteNonQuery()
                '================================================================

                '======================== 
                Initialize_ComboBox()
                frm_ManageLabStockCard.LoadData_ToCombo()
                frm_ManageLabStockCard.LoadMedicationList()
                frm_OtherDispensary.Initialize_ComboBox()

                Initialize_Datatable(Get_Number(ptCode_txt.Text))
                Display_Dispensary(index)
                MsgBox("Deleted", MsgBoxStyle.Information, "Confirm")
            End If
        End If

    End Sub

    Private Sub cancelRx_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelRx_cmd.Click
        If checkPermission("Delete", True) = False Then Exit Sub
        If MedicationDispensaryCode_txt.Text.Trim = "" Then MsgBox("Sorry not found Prescription to cancel.", , "Confirm") : Exit Sub
        If cancelInvoiceStatus_lbl.Text.Trim <> "" Then MsgBox("You could not make change because Prescription already canceled", , "Confirm") : Exit Sub

        If MsgBox("Are you sure to cancel this Prescription ?", vbYesNo, "Confirm") = vbYes Then
            frm_cancelInvoicePopUpNotes.invoiceDetailCode_txt.Text = MedicationDispensaryCode_txt.Text
            frm_cancelInvoicePopUpNotes.CancelFromForm = "Med.Dispensary"
            frm_cancelInvoicePopUpNotes.ShowDialog()
        End If
    End Sub

    Private Sub Generic_LookUpEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Generic_LookUpEdit1.EditValueChanged
        On Error Resume Next
        BrandName_LookUpEdit1.EditValue = Generic_LookUpEdit1.EditValue
        Madein_txt.Text = Generic_LookUpEdit1.GetColumnValue("Made in").ToString
        ExpiredDate_txt.Text = Generic_LookUpEdit1.GetColumnValue("ExpiredDates")
        StockOnHand_txt.Text = Generic_LookUpEdit1.GetColumnValue("StockOnHand").ToString
        costPrice_txt.Text = Return_AvgCostPrice(BrandName_LookUpEdit1.GetColumnValue("Master Code"))
        ' Strength_txt.Text = ReturnSingleValue("select Strength from Ph_tblDrugMaster where drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Master Code").ToString) '
        Strength_txt.Text = Generic_LookUpEdit1.GetColumnValue("Strength").ToString
        form_txt.Text = Generic_LookUpEdit1.GetColumnValue("Form").ToString
        salePrice_txt.Text = Generic_LookUpEdit1.GetColumnValue("RetailCost").ToString
    End Sub

    Private Sub BrandName_LookUpEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrandName_LookUpEdit1.EditValueChanged
        On Error Resume Next
        Generic_LookUpEdit1.EditValue = BrandName_LookUpEdit1.EditValue
        Madein_txt.Text = BrandName_LookUpEdit1.GetColumnValue("Made in").ToString
        ExpiredDate_txt.Text = BrandName_LookUpEdit1.GetColumnValue("ExpiredDates")
        StockOnHand_txt.Text = BrandName_LookUpEdit1.GetColumnValue("StockOnHand").ToString
        costPrice_txt.Text = Return_AvgCostPrice(BrandName_LookUpEdit1.GetColumnValue("Master Code"))
        'Strength_txt.Text = ReturnSingleValue("select Strength from Ph_tblDrugMaster where drugMasterCode=" & BrandName_LookUpEdit1.GetColumnValue("Master Code").ToString) '
        Strength_txt.Text = BrandName_LookUpEdit1.GetColumnValue("Strength").ToString
        form_txt.Text = BrandName_LookUpEdit1.GetColumnValue("Form").ToString
        salePrice_txt.Text = BrandName_LookUpEdit1.GetColumnValue("RetailCost").ToString
    End Sub

    Public Sub CancelMedication()
        Dim Cmd As New SqlCommand
        If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
        Cmd.Connection = Cnn
        Cmd.CommandType = CommandType.Text
        For i As Integer = 0 To Me.GrdVw_Medical.RowCount - 1
            '===Only Save mode ======
            Cmd.CommandText = "UPDATE Ph_tblDrugDetail SET StockOnHand=StockOnHand + " & GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("Quantity")) & " WHERE drugDetailCode=" & GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("drugDetailCode"))
            Cmd.ExecuteNonQuery()
            '===Update Mode=========

            '======================Minus or Update Stock On Hand from table Ph_tblDrugDetail================
            '===Only Save mode ======
            Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalSOH=totalSOH + " & GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("Quantity")) & " WHERE drugMasterCode=" & GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("drugMasterCode"))
            Cmd.ExecuteNonQuery()
            '===Update Mode==========


            '================================================================
            Dim TmpDrugDetailSOH As Integer = 0
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "SELECT StockOnHand from  Ph_tblDrugDetail  WHERE drugDetailCode=" & GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("drugDetailCode"))
            TmpDrugDetailSOH = Cmd.ExecuteScalar()

            Dim TmpDrugMasterSOH As Integer = 0
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "SELECT totalSOH from Ph_tblDrugMaster  WHERE drugMasterCode=" & GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("drugMasterCode"))
            TmpDrugMasterSOH = Cmd.ExecuteScalar()

            '========Insert to Ph_tblStockTransaction=========================
            Cmd.CommandText = "INSERT INTO Ph_tblStockTransaction (drugDetailCode, transDate, mainBegQtySOH, detailBegQtySOH, QtyDistributed, detailEndQtySOH, mainEndQtySOH, inputby, inputdate, branch, remark, isActive,DisCampus)" & _
                              " VALUES (" & GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("drugDetailCode")) & ",'" & Now.Date & "', " & TmpDrugMasterSOH - GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("Quantity")) & " ," & TmpDrugDetailSOH & "," & -GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("Quantity")) & "," & TmpDrugDetailSOH & "," & TmpDrugMasterSOH & ",'" & UserName & "' , '" & Now & "','" & CurrentBranch & "', 'IV Dispensary Nº: " & prescriptionCode_txt.Text & " : " & RxRemark_MemoEdit.Text & " - Cancel Dispensary','True','" & cboCampus.Text & "')"
            Cmd.ExecuteNonQuery()
            '================================================================
        Next
        Initialize_ComboBox()
        frm_ManageLabStockCard.LoadData_ToCombo()
        frm_ManageLabStockCard.LoadMedicationList()
        frm_OtherDispensary.Initialize_ComboBox()
        frm_StockIn.Load_Medical_To_List()
    End Sub

    Private Sub EditMedicalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMedicalToolStripMenuItem.Click
        If GrdVw_Medical.RowCount > 0 Then
            MedicationDispensaryDetailCode_txt.Text = GrdVw_Medical.GetFocusedRow("MedicationDispensaryDetailCode").ToString

            BrandName_LookUpEdit1.Text = GrdVw_Medical.GetFocusedRow("Brand Name").ToString
            Generic_LookUpEdit1.Text = GrdVw_Medical.GetFocusedRow("Generic Name").ToString

            Madein_txt.Text = GrdVw_Medical.GetFocusedRow("Made in").ToString
            Strength_txt.Text = GrdVw_Medical.GetFocusedRow("Strength").ToString
            ExpiredDate_txt.Text = GrdVw_Medical.GetFocusedRow("ExpiredDate").ToString
            costPrice_txt.Text = GrdVw_Medical.GetFocusedRow("RealCost").ToString
            salePrice_txt.Text = GrdVw_Medical.GetFocusedRow("RetailCost").ToString
            DrugMasterCode_BeforeUpdate_txt.Text = GrdVw_Medical.GetFocusedRow("drugMasterCode").ToString
            DrugDetailCode_BeforeUpdate_txt.Text = GrdVw_Medical.GetFocusedRow("drugDetailCode").ToString
            MedicalRemark_txt.Text = GrdVw_Medical.GetFocusedRow("Remark").ToString
            Qty_txt.Text = GrdVw_Medical.GetFocusedRow("Quantity").ToString
            QuantityBeforeUpdate_txt.Text = GrdVw_Medical.GetFocusedRow("Quantity").ToString
            Generic_LookUpEdit1.Properties.PopulateColumns()
            BrandName_LookUpEdit1.Properties.PopulateColumns()
        End If
    End Sub

    Private Function GetMedicalAutoNumber() As String
        Dim cmd As New SqlCommand
        Dim dread As SqlDataReader
        Dim invoiceNumber() As String = Nothing
        If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
        cmd.Connection = Cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select Top 1 DisCode from Ph_tblMedicationDispensary WHERE DisCode like 'D" & Mid(Now.Year, 3, 2) & "%' and branch='" & CurrentBranch & "' order by DisCode DESC"
        dread = cmd.ExecuteReader
        While dread.Read
            invoiceNumber = Split(dread("DisCode"), "D" & Mid(Now.Year, 3, 2))
        End While
        dread.Close()

        If IsNothing(invoiceNumber) Then
            Return "D" & Mid(Now.Year, 3, 2) & "000001"
        Else
            If invoiceNumber(1) + 1 <= 9 Then
                Return "D" & Mid(Now.Year, 3, 2) & "00000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 99 Then
                Return "D" & Mid(Now.Year, 3, 2) & "0000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 999 Then
                Return "D" & Mid(Now.Year, 3, 2) & "000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 9999 Then
                Return "D" & Mid(Now.Year, 3, 2) & "00" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 99999 Then
                Return "D" & Mid(Now.Year, 3, 2) & "0" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 999999 Then
                Return "D" & Mid(Now.Year, 3, 2) & invoiceNumber(1) + 1
            Else
                MsgBox("Prescription Number is overload 999999pt/year only. Please contact administrator", MsgBoxStyle.Critical, "Over Load")
                Exit Function
            End If
        End If

    End Function

    Private Sub Search_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search_cmd.Click
        index = 0
        frm_searchOptionPopUp.SearchFrom = "Dispensary"
        frm_searchOptionPopUp.ShowDialog()
    End Sub

    Public Sub SearchInvoiceNumber(ByVal Code As String)
        Dim Table As New DataTable
        Table = Get_DataTable(String.Format("SELECT ptCode from Ph_tblMedicationDispensary WHERE DisCode ='{0}'", Code))
        If Table.Rows.Count = 0 Then
            MsgBox("Sorry not found invoice number ")
            Clear(True)
            Exit Sub
        End If
        ptCode_txt.Text = Set_Number(Table.Rows(0).Item(0).ToString)
        Table.Clear()


        '====================================
        '====================================Load Patient Information
        '====================================

        Table = Get_DataTable("Select  eName,Gender,DateOfBirth,phone1,ptType,Occupation FROM tblPatient WHERE ptCode='" & Get_Number(ptCode_txt.Text) & "' and isActive='True'")
        If Table.Rows.Count > 0 Then
            ptName_txt.Text = Table.Rows(0).Item(0).ToString
            ptSex_lbl.Text = Table.Rows(0).Item(1).ToString
            ptAge_lbl.Text = Now.Year - Year(Table.Rows(0).Item(2).ToString)
            ptDOB_lbl.Text = Format(Table.Rows(0).Item(2), "MMM dd, yyyy")
            ptOccupation_lbl.Text = Table.Rows(0).Item(5).ToString
        Else
            MsgBox("Patient code not found")
            ptName_txt.Text = ""
            ptSex_lbl.Text = ""
            ptAge_lbl.Text = ""
            ptOccupation_lbl.Text = ""
            Clear(True)
            index = 0
            ptCode_txt.Focus()
        End If

        If ptName_txt.Text.Trim = "" Then
            ptCode_txt.Text = ""
            ptCode_txt.Focus()
        Else
            'Initialize Invoice==============================
            DtDispensary.Clear()
            DtDispensary = Get_DataTable("Select * from Ph_tblMedicationDispensary where DisCode='" & Code & "' and branch='" & CurrentBranch & "' order by dateTimeStamp DESC ,MedicationDispensaryCode  DESC")
            '================================================
            'Initialize Invoice Detail======================= 
            DtDispensaryDetail.Clear()
            DtDispensaryDetail = Get_DataTable(" SELECT MedicationDispensaryDetailCode,Ph_tblMedicationDispensary.MedicationdiSpensaryCode,DrugBrandName as [Brand Name],DrugGenericName as [Generic Name],ProductMadeIn as [Made in],Ph_tblDrugMaster.Strength,Form,convert(nvarchar,ExpiredDate,107) AS ExpiredDate,Ph_tblMedicationDispensaryDetail.RealCost " & _
                                         " ,Ph_tblMedicationDispensaryDetail.RetailCost,Ph_tblMedicationDispensaryDetail.Quantity,Ph_tblMedicationDispensaryDetail.Quantity * Ph_tblMedicationDispensaryDetail.RetailCost AS [Line Total],Ph_tblDrugMaster.drugMasterCode,Ph_tblMedicationDispensaryDetail.drugDetailCode,Ph_tblMedicationDispensaryDetail.Remark  " & _
                                         "  FROM Ph_tblDrugMaster INNER JOIN  Ph_tblDrugDetail ON Ph_tblDrugMaster.drugMasterCode = Ph_tblDrugDetail.drugMasterCode " & _
                                         "  INNER JOIN  Ph_tblMedicationDispensaryDetail ON Ph_tblDrugDetail.drugDetailCode = Ph_tblMedicationDispensaryDetail.drugDetailCode  " & _
                                         "  INNER JOIN  Ph_tblMedicationDispensary ON  Ph_tblMedicationDispensaryDetail.MedicationDispensaryCode = Ph_tblMedicationDispensary.MedicationDispensaryCode  " & _
                                         "  WHERE   ph_tblMedicationDispensaryDetail.isActive='True' AND disCode='" & Code & "' AND Ph_tblMedicationDispensary.branch='" & CurrentBranch & "'")
            'DtDispensaryDetail = Get_DataTable("SELECT MedicationDispensaryDetailCode,Ph_tblMedicationDispensary.MedicationdiSpensaryCode,DrugBrandName as [Brand Name],DrugGenericName as [Generic Name],ProductMadeIn as [Made in], " & _
            '                              "  convert(nvarchar,ExpiredDate,107) AS ExpiredDate,Ph_tblMedicationDispensaryDetail.Remark,Ph_tblMedicationDispensaryDetail.RealCost  , " & _
            '                              "  Ph_tblMedicationDispensaryDetail.RetailCost,Ph_tblMedicationDispensaryDetail.Quantity,Ph_tblMedicationDispensaryDetail.Quantity * Ph_tblMedicationDispensaryDetail.RetailCost AS [Line Total], " & _
            '                              "  Ph_tblDrugMaster.drugMasterCode,Ph_tblMedicationDispensaryDetail.drugDetailCode " & _
            '                              "  FROM Ph_tblDrugMaster INNER JOIN  Ph_tblDrugDetail ON Ph_tblDrugMaster.drugMasterCode = Ph_tblDrugDetail.drugMasterCode " & _
            '                              "  INNER JOIN  Ph_tblMedicationDispensaryDetail ON Ph_tblDrugDetail.drugDetailCode = Ph_tblMedicationDispensaryDetail.drugDetailCode  " & _
            '                              "  INNER JOIN  Ph_tblMedicationDispensary ON  Ph_tblMedicationDispensaryDetail.MedicationDispensaryCode = Ph_tblMedicationDispensary.MedicationDispensaryCode  " & _
            '                              "  WHERE   ph_tblMedicationDispensaryDetail.isActive='True' AND disCode='" & Code & "' AND Ph_tblMedicationDispensary.branch='" & CurrentBranch & "'")
            DtDispensaryDetail.PrimaryKey = New DataColumn() {DtDispensaryDetail.Columns("MedicationDispensaryDetailCode")}
        End If
        '====================================
        '====================================
        '====================================
        DisplayInvoice_ByInvoiceNumber(0)


    End Sub

    Private Sub DisplayInvoice_ByInvoiceNumber(ByVal Rows As Integer)
        Dim DrowInvoice As DataRow
        If DtDispensary.Rows.Count = 0 Then
            Clear(False)
            index = 0
            Enable_Navigation()
            Exit Sub
        End If
        '==============Initialize Invoice=====================
        DrowInvoice = DtDispensary.Rows(Rows)
        MedicationDispensaryCode_txt.Text = DrowInvoice("MedicationDispensaryCode")
        prescriptionCode_txt.Text = DrowInvoice("disCode")
        PrescriptionDate_DateEdit.Text = Format(DrowInvoice("dateTimeStamp"), "MMM dd, yyyy")
        RxRemark_MemoEdit.Text = IIf(IsDBNull(DrowInvoice("remark")), "", DrowInvoice("remark"))
        Prescriber_cbo.Text = DrowInvoice("drPrescriber")
        cboCampus.Text = DrowInvoice("DisCampus")
        '========Row Postion========
        recordPosition_lbl.Text = index + 1 & "/" & DtDispensary.Rows.Count
        '===========================
        '======================================================

        '==========Check isCancel============
        If DrowInvoice("isCancel") = True Then
            cancelInvoiceStatus_lbl.Text = DrowInvoice("cancelReason")
        Else
            cancelInvoiceStatus_lbl.Text = ""
        End If
        '====================================

        '==============Initialize Invoice Detail===============
        GrdVw_Medical.Columns.Clear()
        GrdCtr_Medical.DataSource = DtDispensaryDetail
        ' Dim SerivceView As ColumnView = GrdVw_Medical
        'SerivceView.ActiveFilter.Add(SerivceView.Columns("MedicationDispensaryCode"),
        '                             New ColumnFilterInfo("MedicationDispensaryCode =" & MedicationDispensaryCode_txt.Text & "", ""))

        GrdVw_Medical.Columns(0).Visible = False
        GrdVw_Medical.Columns(1).Visible = False
        GrdVw_Medical.Columns(12).Visible = False
        GrdVw_Medical.Columns(13).Visible = False
        GrdVw_Medical.Columns(14).Visible = False

        'GrdVw_Medical.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
        'GrdVw_Medical.Columns(7).SummaryItem.DisplayFormat = "Total = {0:C}"

        'GrdVw_Medical.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
        'GrdVw_Medical.Columns(8).SummaryItem.DisplayFormat = "Total = {0:C}"

        GrdVw_Medical.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
        GrdVw_Medical.Columns(10).SummaryItem.DisplayFormat = "Count = {0}"

        GrdVw_Medical.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
        GrdVw_Medical.Columns(11).SummaryItem.DisplayFormat = "Total = {0:C}"

        '=========Update to database ==============
        Dim TotalQTY As Double
        Dim LineTotal As Double
        For i As Integer = 0 To Me.GrdVw_Medical.RowCount - 1
            TotalQTY += GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("Quantity"))
            LineTotal += GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("Line Total"))
        Next
        Update_Record("UPDATE Ph_tblMedicationDispensary SET TotalAmount=" & LineTotal & ", TotalQuantity = " & TotalQTY & " WHERE MedicationdiSpensaryCode = " & MedicationDispensaryCode_txt.Text)
        '===========================================

    End Sub

    Private Sub Strength_txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Strength_txt.KeyDown, StockOnHand_txt.KeyDown, prescriptionCode_txt.KeyDown, Madein_txt.KeyDown, ExpiredDate_txt.KeyDown, costPrice_txt.KeyDown, form_txt.KeyDown, salePrice_txt.KeyDown
        e.Handled = True

    End Sub

    Private Sub Strength_txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Strength_txt.KeyPress, StockOnHand_txt.KeyPress, prescriptionCode_txt.KeyPress, Madein_txt.KeyPress, ExpiredDate_txt.KeyPress, costPrice_txt.KeyPress, form_txt.KeyPress, salePrice_txt.KeyPress
        e.Handled = True
    End Sub

    Private Function Return_AvgCostPrice(ByVal MasterCode As String) As Double
        Dim AvgCost As Double
        Dim Table As New DataTable
        Table = Get_DataTable("SELECT ph_tbldrugmaster.drugmastercode,AVG(Ph_tblDrugDetail.RealCost) AS CostPrice FROM Ph_tblDrugMaster INNER JOIN Ph_tblDrugDetail ON ph_tbldrugmaster.drugMasterCode=ph_tbldrugdetail.drugMasterCode WHERE Ph_tblDrugMaster.isActive='True' AND Ph_tblDrugDetail.isActive='True' AND Ph_tblDrugDetail.StockOnHand > 0 AND Ph_tblDrugDetail.drugMasterCode=" & MasterCode & " GROUP BY ph_tbldrugmaster.drugmastercode")
        If Table.Rows.Count > 0 Then
            AvgCost = Table.Rows(0).Item("CostPrice")
            AvgCost = Format(AvgCost, "###0.00000")
        Else
            AvgCost = 0
        End If
        Return AvgCost
    End Function

    Private Sub cboCampus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCampus.SelectedIndexChanged
        Initialize_ComboBox()
    End Sub


    Private Sub cboCampus_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCampus.Validated
        If MedicationDispensaryCode_txt.Text.Trim <> "" Then
            If MsgBox("Are you sure to change campus to <<" & cboCampus.Text & ">> ? ", MsgBoxStyle.YesNo, "Confirmation") = vbYes Then
                If Update_Record("UPDATE  Ph_tblMedicationDispensary SET DisCampus = '" & cboCampus.Text & "' WHERE MedicationDispensaryCode=" & MedicationDispensaryCode_txt.Text) = True Then
                    MsgBox("Campus Updated")
                End If
            End If
        End If


    End Sub
End Class