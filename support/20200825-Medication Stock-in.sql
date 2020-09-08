@Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base

Public Class frm_StockIn

    Dim isFound As Boolean

    Private Sub frm_StockIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RecivedDate_DateEdit.Text = Format(Now, "MMM dd, yyyy")
        InitializeCombox()
        IV_RecivedNum_txt.Text = Get_IVRecievedNum()
        Load_Medical_To_List()

        InitValidationRules()
        ' DxValidationProvider1.Validate()
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        IV_RecivedNum_txt.Text = Get_IVRecievedNum()
        SupplierName_cbo.Text = ""
        Address_mmEdit.Text = ""
        ContactPerson_txt.Text = ""
        phoneNumber_txt.Text = ""
        RecivedDate_DateEdit.Text = Format(Now, "MMM dd, yyyy")
        receivedby_txt.Text = ""
        Remark_MemoEdit1.Text = ""
        invoiceMedicalStockInCode_txt.Text = ""
        drugCode_txt.Text = ""
        'Clear detail================
        expiredDate_DateEdit.Text = ""
        RealCost_txt.Text = ""
        RetailCost_txt.Text = ""
        Form_txt.Text = ""
        Qty_txt.Text = ""
        markup_txt.Text = ""
        madeIn.Text = ""
        lotsNumber_txt.Text = ""
        drugDetailCode_txt.Text = ""
        BeforeUpdateQTY_txt.Text = ""
        txtDrugMasterCodeBeforeUpdate.Text = ""
        tmpSOH_txt.Text = ""
        Strength_txt.Text = ""
        Generic_LookUpEdit1.EditValue = DBNull.Value
        BrandName_LookUpEdit1.EditValue = DBNull.Value
        cboCampus.Text = ""
        '============================
        GrdCtr_Medical.DataSource = Nothing
        GrdVw_Medical.Columns.Clear()

        isFound = False
    End Sub

    Public Sub InitializeCombox()
        Dim Table As New DataTable

        Table = Get_DataTable("SELECT Location  FROM tblPatientNationality WHERE isActive='True' order by location")
        madeIn.Properties.Items.Clear()

        For Each drow In Table.Rows
            madeIn.Properties.Items.Add(drow("Location"))
        Next
        Table.Clear()

        Table = Get_DataTable("SELECT ClinicLocation FROM tblClinicLocation")
        cboCampus.Properties.Items.Clear()
        For Each drow In Table.Rows
            cboCampus.Properties.Items.Add(drow("ClinicLocation"))
        Next
        Table.Clear()


        Table = Get_DataTable("SELECT supplierName FROM Ph_tblSupplier Where isActive='True' ORDER BY supplierName ")
        SupplierName_cbo.Properties.Items.Clear()
        For Each dRow In Table.Rows
            SupplierName_cbo.Properties.Items.Add(dRow("supplierName"))
        Next
        Table.Clear()

        BrandName_LookUpEdit1.Properties.Columns.Clear()
        Generic_LookUpEdit1.Properties.Columns.Clear()
        Generic_LookUpEdit1.Properties.DataSource = Nothing
        BrandName_LookUpEdit1.Properties.DataSource = Nothing

        Table = Get_DataTable("SELECT drugMasterCode as Code,drugBrandName as [Brand Name],drugGenericName as [Generic Name],Strength,form FROM Ph_tblDrugMaster WHERE isActive='True' AND branch='" & CurrentBranch & "' AND drugItemType='Pharmacy' ")
        BrandName_LookUpEdit1.Properties.DataSource = Table
        BrandName_LookUpEdit1.Properties.DisplayMember = "Brand Name"
        BrandName_LookUpEdit1.Properties.ValueMember = "Code"
        BrandName_LookUpEdit1.Properties.PopupWidth = 900
        BrandName_LookUpEdit1.Properties.BestFitWidth = True
        ' Table.Clear()

        Table = Get_DataTable("SELECT drugMasterCode as Code,drugGenericName as [Generic Name],drugBrandName as [Brand Name],Strength,form  FROM Ph_tblDrugMaster WHERE isActive='True' AND branch='" & CurrentBranch & "' AND drugItemType='Pharmacy' ")
        Generic_LookUpEdit1.Properties.DataSource = Table
        Generic_LookUpEdit1.Properties.DisplayMember = "Generic Name"
        Generic_LookUpEdit1.Properties.ValueMember = "Code"
        Generic_LookUpEdit1.Properties.PopupWidth = 900
        Generic_LookUpEdit1.Properties.BestFitWidth = True


        ' Table.Clear()

    End Sub

    Private Sub SupplierName_cbo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SupplierName_cbo.TextChanged

        If SupplierName_cbo.Text.Trim <> "" Then
            Dim Table As New DataTable
            Table = Get_DataTable("SELECT * FROM Ph_tblSupplier WHERE isActive='True' and supplierName='" & SupplierName_cbo.Text & "'")
            If Table.Rows.Count Then
                Address_mmEdit.Text = Table.Rows(0).Item("address")
                ContactPerson_txt.Text = Table.Rows(0).Item("contactPerson")
                phoneNumber_txt.Text = Table.Rows(0).Item("phoneNumber")
            Else
                Address_mmEdit.Text = ""
                ContactPerson_txt.Text = ""
                phoneNumber_txt.Text = ""
            End If
        End If

    End Sub

    Private Sub RecivedDate_DateEdit_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecivedDate_DateEdit.Validated
        If RecivedDate_DateEdit.Text.Trim <> "" Then
            RecivedDate_DateEdit.Text = Format(CDate(RecivedDate_DateEdit.Text), "MMM dd, yyyy")
        End If
    End Sub

    Private Sub expiredDate_DateEdit_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles expiredDate_DateEdit.Validated
        If expiredDate_DateEdit.Text.Trim <> "" Then
            expiredDate_DateEdit.Text = Format(CDate(expiredDate_DateEdit.Text), "MMM dd, yyyy")
        End If
    End Sub

    Private Sub RealCost_txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RealCost_txt.KeyPress, markup_txt.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub RetailCost_txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RetailCost_txt.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub Qty_txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Qty_txt.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub Address_mmEdit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Address_mmEdit.KeyPress
        e.Handled = True
    End Sub

    Private Sub ContactPerson_txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ContactPerson_txt.KeyPress
        e.Handled = True
    End Sub

    Private Sub phoneNumber_txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles phoneNumber_txt.KeyPress
        e.Handled = True
    End Sub

    Try
    Private Function Get_IVRecievedNum() As String
        Dim cmd As New SqlCommand
        Dim dread As SqlDataReader
        Dim invoiceNumber() As String = Nothing
        If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
        cmd.Connection = Cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select Top 1 IVRecievedNum from Ph_tblInvoiceMedicalStockIn where IVRecievedNum like 'IV" & Mid(Now.Year, 3, 2) & "%' and branch='" & CurrentBranch & "' order by IVRecievedNum DESC"
        dread = cmd.ExecuteReader
        While dread.Read
            invoiceNumber = Split(dread("IVRecievedNum"), "IV" & Mid(Now.Year, 3, 2))
        End While
        dread.Close()

        If IsNothing(invoiceNumber) Then
            Return "IV" & Mid(Now.Year, 3, 2) & "000001"
        Else
            If invoiceNumber(1) + 1 <= 9 Then
                Return "IV" & Mid(Now.Year, 3, 2) & "00000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 99 Then
                Return "IV" & Mid(Now.Year, 3, 2) & "0000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 999 Then
                Return "IV" & Mid(Now.Year, 3, 2) & "000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 9999 Then
                Return "IV" & Mid(Now.Year, 3, 2) & "00" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 99999 Then
                Return "IV" & Mid(Now.Year, 3, 2) & "0" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 999999 Then
                Return "IV" & Mid(Now.Year, 3, 2) & invoiceNumber(1) + 1
            Else
                MsgBox("invoice Number is overload 999999pt/year only. Please contact administrator", MsgBoxStyle.Critical, "Over Load")
                Exit Function
            End If
        End If

    End Function
    Catch ex As Exception
    
    End Try

    Private Sub IV_RecivedNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub BrandName_LookUpEdit1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrandName_LookUpEdit1.TextChanged
        'Generic_LookUpEdit1.Text = ReturnSingleValue("SELECT drugGenericName as [Generic Name] FROM Ph_tblDrugMaster WHERE isActive='True' AND drugBrandName='" & BrandName_LookUpEdit1.Text & "' AND branch='" & CurrentBranch & "'")
        'Generic_LookUpEdit1.Properties.PopulateColumns()
    End Sub

    Private Sub Generic_LookUpEdit1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Generic_LookUpEdit1.TextChanged
        'BrandName_LookUpEdit1.Text = ReturnSingleValue("SELECT drugBrandName as [Brand Name] FROM Ph_tblDrugMaster WHERE isActive='True' AND drugGenericName='" & Generic_LookUpEdit1.Text & "' AND branch='" & CurrentBranch & "'")
        'BrandName_LookUpEdit1.Properties.PopulateColumns()
    End Sub

    Private Sub SaveMedical_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveMedical_cmd.Click

        If checkPermission("Write", True) = False Then Exit Sub
        If DxValidationProvider1.Validate = False Then Exit Sub

        If cboCampus.Text.Trim = "" Then MsgBox("Sorry, Campus is required.", , "Confirm") : cboCampus.Focus() : Exit Sub
        '================Input Ajustment Reason================

        Dim AdjustmentReason As String = ""
        If BeforeUpdateQTY_txt.Text.Trim <> "" Then
            If BeforeUpdateQTY_txt.Text <> Qty_txt.Text Then 'Adjustment only record when Quantity has been changed
                If tmpSOH_txt.Text - (BeforeUpdateQTY_txt.Text - Qty_txt.Text) < 0 Then
                    MsgBox("Sorry current stock on hand is smaller than quantity to be adjusted," & vbCrLf & "Incompleted adjustment", , "Confirm")
                    Qty_txt.Text = BeforeUpdateQTY_txt.Text
                    Exit Sub
                End If
                AdjustmentReason = InputBox("Please input your adjustment reason here:", "Reason")
                If AdjustmentReason.Trim = "" Then
                    MsgBox("Incompleted adjustment," & vbCrLf & "Because adjustment reason is required.", , "Confirm")
                    Qty_txt.Text = BeforeUpdateQTY_txt.Text
                    Exit Sub
                End If
            End If
        End If
        '''Reason That I put this block of code on the top because 
        ''' during the transaction is running in  the middle of time
        ''' we could not use input box for user to input. or it will error if 
        ''' we use inputbox or message box in the middle of transaction.
        '======================================================

        If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
        Dim myTransaction = Cnn.BeginTransaction()
        Dim Cmd As New SqlCommand
        Dim StrQurSave As String
        Dim StrQurUpdate As String
        Cmd.Connection = Cnn
        Cmd.Transaction = myTransaction ' Start a local transaction.

        '============Return Invoice Number=========Becast Transaction could not run comment outside transaction
        Dim GetAutoNumber As String
        Dim dread As SqlDataReader
        Dim invoiceNumber() As String = Nothing
        If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
        Cmd.Connection = Cnn
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "Select Top 1 IVRecievedNum from Ph_tblInvoiceMedicalStockIn where IVRecievedNum like 'IV" & Mid(Now.Year, 3, 2) & "%' and branch='" & CurrentBranch & "' order by IVRecievedNum DESC"
        dread = Cmd.ExecuteReader
        While dread.Read
            invoiceNumber = Split(dread("IVRecievedNum"), "IV" & Mid(Now.Year, 3, 2))
        End While
        dread.Close()

        If IsNothing(invoiceNumber) Then
            GetAutoNumber = "IV" & Mid(Now.Year, 3, 2) & "000001"
        Else
            If invoiceNumber(1) + 1 <= 9 Then
                GetAutoNumber = "IV" & Mid(Now.Year, 3, 2) & "00000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 99 Then
                GetAutoNumber = "IV" & Mid(Now.Year, 3, 2) & "0000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 999 Then
                GetAutoNumber = "IV" & Mid(Now.Year, 3, 2) & "000" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 9999 Then
                GetAutoNumber = "IV" & Mid(Now.Year, 3, 2) & "00" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 99999 Then
                GetAutoNumber = "IV" & Mid(Now.Year, 3, 2) & "0" & invoiceNumber(1) + 1
            ElseIf invoiceNumber(1) + 1 <= 999999 Then
                GetAutoNumber = "IV" & Mid(Now.Year, 3, 2) & invoiceNumber(1) + 1
            Else
                MsgBox("invoice Number is overload 999999pt/year only. Please contact administrator", MsgBoxStyle.Critical, "Over Load")
                Exit Sub
            End If
        End If
        '=====================================================
        '================Select SupplierCode======================
        Dim SupplierCode As String
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "SELECT supplierCode FROM Ph_tblSupplier WHERE supplierName='" & SupplierName_cbo.Text & "' AND isActive='True'"
        SupplierCode = Cmd.ExecuteScalar()

        '=====================================================
        Cmd.CommandType = CommandType.Text
        StrQurSave = "INSERT INTO Ph_tblInvoiceMedicalStockIn (supplierCode, IVRecievedNum, recievedDate, recievedBy, remark, inputBy, inputDate,isActive, branch,campus ) " & _
                     " VALUES (@supplierCode,@IVRecievedNum,@recievedDate,@recievedBy,@remark,@inputBy,@inputDate,@isActive,@branch,@campus) "
        StrQurUpdate = " UPDATE Ph_tblInvoiceMedicalStockIn SET supplierCode=@supplierCode, recievedDate = @recievedDate , recievedBy=@recievedBy, remark=@remark, updateBy=@updateBy, updateDate=@updateDate,isActive=@isActive, branch=@branch WHERE invoiceMedicalStockInCode= " & invoiceMedicalStockInCode_txt.Text


        If invoiceMedicalStockInCode_txt.Text.Trim = "" Then '  Save Mode
            Cmd.CommandText = StrQurSave
            Cmd.Parameters.AddWithValue("@IVRecievedNum", GetAutoNumber)
            Cmd.Parameters.AddWithValue("@inputBy", UserName)
            Cmd.Parameters.AddWithValue("@inputDate", Now)
        Else ' update mode
            Cmd.CommandText = StrQurUpdate
            Cmd.Parameters.AddWithValue("@updateby", UserName)
            Cmd.Parameters.AddWithValue("@updatedate", Now)
        End If

        With Cmd.Parameters
            .AddWithValue("@supplierCode", SupplierCode)
            .AddWithValue("@recievedDate", RecivedDate_DateEdit.Text)
            .AddWithValue("@recievedBy", receivedby_txt.Text)
            .AddWithValue("@remark", Remark_MemoEdit1.Text)
            .AddWithValue("@branch", CurrentBranch)
            .AddWithValue("@isActive", True)
            .AddWithValue("@campus", cboCampus.Text)
        End With

        Try
            If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
            Cmd.ExecuteNonQuery()

            If invoiceMedicalStockInCode_txt.Text.Trim = "" Then
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT MAX (invoiceMedicalStockInCode) AS MedicationDispensaryCode FROM Ph_tblInvoiceMedicalStockIn WHERE Branch ='" & CurrentBranch & "'"
                invoiceMedicalStockInCode_txt.Text = Cmd.ExecuteScalar()
            End If

            'Operation in Ph_tblDrugDetail==============================================================
            Cmd.Parameters.Clear()
            Dim StrSOH As String = ""
            If drugDetailCode_txt.Text = "" Then 'Save Mode
                Cmd.CommandText = " Insert Into Ph_tblDrugDetail ( invoiceMedicalStockInCode, drugMasterCode, productMadeIn, realCost, retailCost, Quantity,StockOnHand, expiredDate, LotNum, inputBy,  inputDate,  isActive, branch,isAdjustment,campus)" & _
                                  " Values( @invoiceMedicalStockInCode, @drugMasterCode, @productMadeIn, @realCost, @retailCost, @Quantity,@StockOnHand, @expiredDate, @LotNum, @inputBy,  @inputDate, @isActive, @branch,@isAdjustment,@campus)"

                Cmd.Parameters.AddWithValue("@inputBy", UserName)
                Cmd.Parameters.AddWithValue("@inputDate", Now)
                Cmd.Parameters.AddWithValue("@isAdjustment", False)
                Cmd.Parameters.AddWithValue("@StockOnHand", IIf(Qty_txt.Text.Trim = "", 0, Qty_txt.Text))

            Else ' Updaet Mode
                Cmd.CommandText = " UPDATE  Ph_tblDrugDetail SET invoiceMedicalStockInCode=@invoiceMedicalStockInCode, drugMasterCode=@drugMasterCode, productMadeIn=@productMadeIn, realCost=@realCost, retailCost=@retailCost, Quantity=@Quantity,StockOnHand=@StockOnHand, expiredDate=@expiredDate, LotNum=@LotNum, updateby=@updateby,  updateDate=@updateDate,  isActive=@isActive, branch=@branch,isAdjustment=@isAdjustment,campus=@campus WHERE drugDetailCode=" & drugDetailCode_txt.Text
                Cmd.Parameters.AddWithValue("@UpdateBy", UserName)
                Cmd.Parameters.AddWithValue("@UpdateDate", Now)

                If BeforeUpdateQTY_txt.Text = Qty_txt.Text Then ' Stock On Hand no Update or change becuase beforeUpdate QTy and Current Qty is equal
                    Cmd.Parameters.AddWithValue("@StockOnHand", tmpSOH_txt.Text)
                    Cmd.Parameters.AddWithValue("@isAdjustment", False)
                ElseIf BeforeUpdateQTY_txt.Text < Qty_txt.Text Then ' Adjustment in
                    StrSOH = tmpSOH_txt.Text + (Qty_txt.Text - BeforeUpdateQTY_txt.Text) ' New Stock On hand = Current Stock On hand + Ajustment Qty  (Adjust In)
                    Cmd.Parameters.AddWithValue("@StockOnHand", StrSOH)
                    Cmd.Parameters.AddWithValue("@isAdjustment", True)
                Else
                    StrSOH = tmpSOH_txt.Text - (BeforeUpdateQTY_txt.Text - Qty_txt.Text) ' New Stock On hand = Current Stock On hand - Ajustment Qty (Adjust Out)
                    If Val(StrSOH) >= 0 Then
                        Cmd.Parameters.AddWithValue("@StockOnHand", StrSOH)
                        Cmd.Parameters.AddWithValue("@isAdjustment", True)
                    End If
                End If

            End If

            With Cmd.Parameters
                .AddWithValue("@invoiceMedicalStockInCode", invoiceMedicalStockInCode_txt.Text)
                .AddWithValue("@drugMasterCode", Generic_LookUpEdit1.GetColumnValue("Code").ToString)
                .AddWithValue("@productMadeIn", madeIn.Text)
                .AddWithValue("@realCost", IIf(RealCost_txt.Text.Trim = "", 0, RealCost_txt.Text))
                .AddWithValue("@retailCost", IIf(RetailCost_txt.Text.Trim = "", 0, RetailCost_txt.Text))
                .AddWithValue("@Quantity", IIf(Qty_txt.Text.Trim = "", 0, Qty_txt.Text))
                .AddWithValue("@expiredDate", expiredDate_DateEdit.Text)
                .AddWithValue("@LotNum", IIf(lotsNumber_txt.Text.Trim = "", DBNull.Value, lotsNumber_txt.Text))
                .AddWithValue("@branch", CurrentBranch)
                .AddWithValue("@isActive", True)
                .AddWithValue("@campus", cboCampus.Text)
            End With
            If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
            Cmd.ExecuteNonQuery()
            '===========================================================================================
            '==========Operation In Stock Master and Stock Detail================================

            If drugDetailCode_txt.Text.Trim = "" Then ' Saved Mode 
                Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalSOH=totalSOH + " & Qty_txt.Text & " WHERE drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Code").ToString
                Cmd.ExecuteNonQuery() ' Add Qty to totalSOH

                '==============================
                Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalValueTodate=totalValueTodate + " & Qty_txt.Text & " WHERE drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Code").ToString
                Cmd.ExecuteNonQuery() ' Add Qty to totalValueTodate
                '==============================

                Dim TmpDrugDetailCode As String = ""
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT TOP 1 drugDetailCode FROM Ph_tblDrugMaster INNER JOIN  Ph_tblDrugDetail ON  Ph_tblDrugMaster.drugMasterCode = Ph_tblDrugDetail.drugMasterCode WHERE Ph_tblDrugMaster.drugItemType='Pharmacy' AND Ph_tblDrugMaster.isActive='True' AND Ph_tblDrugDetail.isActive='True'  ORDER BY drugDetailCode DESC "
                TmpDrugDetailCode = Cmd.ExecuteScalar()


                Dim TmpMainCampusSHO As Integer = 0
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = " SELECT sum(Ph_tblDrugDetail.StockOnHand) AS StockOnHand FROM dbo.Ph_tblDrugMaster INNER JOIN dbo.Ph_tblDrugDetail ON dbo.Ph_tblDrugMaster.drugMasterCode = dbo.Ph_tblDrugDetail.drugMasterCode " & _
                                   " WHERE (dbo.Ph_tblDrugMaster.drugItemType = 'Pharmacy') AND (dbo.Ph_tblDrugMaster.isActive = 'True') AND (dbo.Ph_tblDrugDetail.isActive = 'True') " & _
                                   " AND dbo.Ph_tblDrugDetail.campus = '" & cboCampus.Text & "' AND (dbo.Ph_tblDrugMaster.drugMasterCode = " & Generic_LookUpEdit1.GetColumnValue("Code").ToString & "  ) GROUP BY   Ph_tblDrugMaster.drugMasterCode "
                TmpMainCampusSHO = Cmd.ExecuteScalar()

                ' MsgBox(Generic_LookUpEdit1.GetColumnValue("Code").ToString)

                Dim TmpDrugMasterSOH As Integer = 0
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT totalSOH from Ph_tblDrugMaster  WHERE drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Code").ToString
                TmpDrugMasterSOH = Cmd.ExecuteScalar()


                '========Insert to Ph_tblStockTransaction=========================
                Cmd.CommandText = "INSERT INTO Ph_tblStockTransaction (drugDetailCode, transDate, mainBegQtySOH,mainCampusBegQtySOH, detailBegQtySOH, QtyReceived, detailEndQtySOH,mainCampusEndQtySOH, mainEndQtySOH, inputby, inputdate, branch, remark, isActive,DisCampus)" & _
                                  " VALUES (" & TmpDrugDetailCode & ",'" & Now.Date & "', " & TmpDrugMasterSOH - Val(Qty_txt.Text) & " ," & TmpMainCampusSHO - Val(Qty_txt.Text) & ",0," & Val(Qty_txt.Text) & "," & Val(Qty_txt.Text) & " ," & TmpMainCampusSHO & "," & TmpDrugMasterSOH & ",'" & UserName & "' , '" & Now & "','" & CurrentBranch & "', 'IV Recieve Nº: " & GetAutoNumber & " : " & Remark_MemoEdit1.Text & " - Added','True','" & cboCampus.Text & "')"
                Cmd.ExecuteNonQuery()
                ''================================================================

            Else ' Update Mode

                '============Operated to totalSOH===========
                Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalSOH=totalSOH - " & BeforeUpdateQTY_txt.Text & " WHERE drugMasterCode=" & txtDrugMasterCodeBeforeUpdate.Text
                Cmd.ExecuteNonQuery() ' Minus Original SOH

                Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalSOH=totalSOH + " & Qty_txt.Text & " WHERE drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Code").ToString
                Cmd.ExecuteNonQuery() ' Add New QTY to SOH

                '===========================================

                '============Operated to totalValueTodate===========
                Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalValueTodate=totalValueTodate - " & BeforeUpdateQTY_txt.Text & " WHERE drugMasterCode=" & txtDrugMasterCodeBeforeUpdate.Text
                Cmd.ExecuteNonQuery() ' Minus Original SOH

                Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET totalValueTodate=totalValueTodate + " & Qty_txt.Text & " WHERE drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Code").ToString
                Cmd.ExecuteNonQuery() ' Update New QTY to SOH
                '============================================

                If BeforeUpdateQTY_txt.Text <> Qty_txt.Text Then

                    Dim TmpDrugDetailSOH As String = ""
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = "SELECT StockOnHand FROM  Ph_tblDrugDetail WHERE  drugDetailCode= " & drugDetailCode_txt.Text
                    TmpDrugDetailSOH = Cmd.ExecuteScalar()


                    Dim TmpDrugMasterSOH As Integer = 0
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = "SELECT totalSOH FROM  Ph_tblDrugMaster WHERE drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Code").ToString
                    TmpDrugMasterSOH = Cmd.ExecuteScalar()


                    Dim TmpMainCampusSHO As String
                    Cmd.CommandType = CommandType.Text
                    TmpMainCampusSHO = " SELECT sum(Ph_tblDrugDetail.StockOnHand) AS StockOnHand FROM dbo.Ph_tblDrugMaster INNER JOIN dbo.Ph_tblDrugDetail ON dbo.Ph_tblDrugMaster.drugMasterCode = dbo.Ph_tblDrugDetail.drugMasterCode " & _
                                       " WHERE (dbo.Ph_tblDrugMaster.drugItemType = 'Pharmacy') AND (dbo.Ph_tblDrugMaster.isActive = 'True') AND (dbo.Ph_tblDrugDetail.isActive = 'True') " & _
                                       " AND dbo.Ph_tblDrugDetail.campus = '" & cboCampus.Text & "' AND (dbo.Ph_tblDrugDetail.drugMasterCode = " & Generic_LookUpEdit1.GetColumnValue("Code").ToString & "  ) GROUP BY   Ph_tblDrugMaster.drugMasterCode "
                    TmpMainCampusSHO = Cmd.ExecuteScalar()


                    '========Insert to Ph_tblStockTransaction=========================
                    Cmd.CommandText = "INSERT INTO Ph_tblStockTransaction (drugDetailCode, transDate, mainBegQtySOH ,mainCampusBegQtySOH, detailBegQtySOH, QtyAdjustment, detailEndQtySOH,mainCampusEndQtySOH, mainEndQtySOH, inputby, inputdate, branch, remark, isActive,DisCampus)" & _
                                      " VALUES (" & drugDetailCode_txt.Text & ",'" & Now.Date & "', " & TmpDrugMasterSOH - (Qty_txt.Text - BeforeUpdateQTY_txt.Text) & " ," & TmpMainCampusSHO - (Qty_txt.Text - BeforeUpdateQTY_txt.Text) & "," & TmpDrugDetailSOH + (BeforeUpdateQTY_txt.Text - Qty_txt.Text) & "," & Qty_txt.Text - Val(BeforeUpdateQTY_txt.Text) & "," & TmpDrugDetailSOH & "," & TmpMainCampusSHO & " ," & TmpDrugMasterSOH & ",'" & UserName & "' , '" & Now & "','" & CurrentBranch & "', 'IV Recieve Nº: " & IV_RecivedNum_txt.Text & " : Stock Adjusted - Reason : " & AdjustmentReason & "','True','" & cboCampus.Text & "')"
                    Cmd.ExecuteNonQuery()
                    ' " VALUES (" & TmpDrugDetailCode & ",       '" & Now.Date & "', " & TmpDrugMasterSOH - Val(Qty_txt.Text) & " ,0," & Val(Qty_txt.Text) & "," & Val(Qty_txt.Text) & " ," & TmpDrugMasterSOH & ",'" & UserName & "' , '" & Now & "','" & CurrentBranch & "', 'IV Recieve Nº: " & GetAutoNumber & " : " & Remark_MemoEdit1.Text & " - Added','True')"
                    ''================================================================
                End If
            End If

            '=====Get Top Sale Price to update into Ph_tblDrugMaster======================
            Dim TopSalePrice As String
            Cmd.CommandText = "SELECT  MAX(Ph_tblDrugDetail.RetailCost) AS RetailCost FROM  Ph_tblDrugDetail  WHERE   Ph_tblDrugDetail.isActive='True'  AND Ph_tblDrugDetail.StockOnHand > 0  AND drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Code").ToString

            If IsDBNull(Cmd.ExecuteScalar) Then
                Cmd.CommandText = "SELECT RetailCost  FROM  Ph_tblDrugDetail WHERE drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Code").ToString
                TopSalePrice = Cmd.ExecuteScalar ' For medication that Stock on hand = 0 
            Else
                TopSalePrice = Cmd.ExecuteScalar ' For medication that Stock on hand > 0 
            End If

            '=============================================================
            '========================Update Top Sale Price to Table Ph_tblDrugMaster========
            Cmd.CommandText = "UPDATE Ph_tblDrugMaster SET mainRetailPrice= " & TopSalePrice & " WHERE drugMasterCode=" & Generic_LookUpEdit1.GetColumnValue("Code").ToString
            Cmd.ExecuteNonQuery() ' Update Top retailPrice
            '=============================================================


            '=============Record to Ph_tblStockAdjustment========


            Cmd.CommandText = "INSERT INTO Ph_tblStockAdjustment (drugDetailCode, invoiceMedicalStockInCode, drugMasterCode, dateTimeAdj, beforeAdjSOH, afterAdjSOH, beforeAdjQty, afterAdjQty, adjReason,QtyAdj, isAdjIn, inputBy, inputDate,campus) " & _
                              " VALUES (@drugDetailCode, @invoiceMedicalStockInCode, @drugMasterCode, @dateTimeAdj, @beforeAdjSOH, @afterAdjSOH, @beforeAdjQty, @afterAdjQty, @adjReason,@QtyAdj, @isAdjIn, @inputBy, @inputDate,@campus )"

            Cmd.Parameters.Clear()
            With Cmd.Parameters
                .AddWithValue("@drugDetailCode", drugDetailCode_txt.Text)
                .AddWithValue("@invoiceMedicalStockInCode", invoiceMedicalStockInCode_txt.Text)
                .AddWithValue("@drugMasterCode", Generic_LookUpEdit1.GetColumnValue("Code").ToString)
                .AddWithValue("@dateTimeAdj", Now)
                .AddWithValue("@beforeAdjSOH", tmpSOH_txt.Text)
                .AddWithValue("@afterAdjSOH", StrSOH)
                .AddWithValue("@beforeAdjQty", BeforeUpdateQTY_txt.Text)
                .AddWithValue("@afterAdjQty", Qty_txt.Text)
                .AddWithValue("@adjReason", AdjustmentReason)
                .AddWithValue("@QtyAdj", Val(Qty_txt.Text) - Val(BeforeUpdateQTY_txt.Text))
                .AddWithValue("@isAdjIn", IIf(Val(BeforeUpdateQTY_txt.Text) < Val(Qty_txt.Text), True, False))
                .AddWithValue("@inputBy", UserName)
                .AddWithValue("@inputDate", Now)
                .AddWithValue("@campus", cboCampus.Text)
            End With

            If BeforeUpdateQTY_txt.Text.Trim <> "" Then
                If BeforeUpdateQTY_txt.Text <> Qty_txt.Text Then 'Adjustment only record when Quantity has been changed
                    If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
                    Cmd.ExecuteNonQuery()
                End If
            End If

            '============================================

            myTransaction.Commit()
            MsgBox("Saved", , "Confirm")
            Cnn.Close()
        Catch ex As Exception
            myTransaction.Rollback()
            MsgBox(Err.Description.ToString)
            Exit Sub
        End Try

        expiredDate_DateEdit.Text = ""
        RealCost_txt.Text = ""
        RetailCost_txt.Text = ""
        Qty_txt.Text = ""
        markup_txt.Text = ""
        madeIn.Text = ""
        lotsNumber_txt.Text = ""
        drugDetailCode_txt.Text = ""
        txtDrugMasterCodeBeforeUpdate.Text = ""
        tmpSOH_txt.Text = ""
        BeforeUpdateQTY_txt.Text = ""
        Strength_txt.Text = ""
        Form_txt.Text = ""
        drugCode_txt.Text = ""
        Generic_LookUpEdit1.EditValue = DBNull.Value
        BrandName_LookUpEdit1.EditValue = DBNull.Value
        BrandName_LookUpEdit1.Focus()
        Load_Medical_To_List()


        frm_ManageLabStockCard.LoadMedicationList()
        frm_ManageLabStockCard.LoadSupplier()
        frm_dispensary.Initialize_ComboBox()
        frm_OtherDispensary.Initialize_ComboBox()


        'drugCode_txt.Focus()

    End Sub

    Private Sub lotsNumber_txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lotsNumber_txt.Validated
        lotsNumber_txt.Text = StrConv(lotsNumber_txt.Text, vbUpperCase)
    End Sub

    Private Sub receivedby_txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles receivedby_txt.Validated
        receivedby_txt.Text = StrConv(receivedby_txt.Text, vbProperCase)
    End Sub

    Public Sub Load_Medical_To_List()
        Dim Str As String
        Dim Table As New DataTable
        Str = " SELECT	drugDetailCode,invoiceMedicalStockInCode,drugBrandName AS [Brand Name],drugGenericName AS [Generic Name]," & _
              "  productMadeIn AS [Made in],CONVERT(NVARCHAR,expiredDate,107) AS [Expired Date],Strength,Form," & _
              "  realCost AS [Real Cost],RetailCost AS [Retail Cost],Quantity,Ph_tblDrugDetail.drugMasterCode,RetailCost*quantity AS [Line Total],Ph_tblDrugDetail.StockOnHand  " & _
              "  ,CASE  WHEN isAdjustment='True' THEN 'Adjusted'   ELSE ''  END   AS [Stock Adjusted] " & _
              "  FROM Ph_tblDrugMaster INNER JOIN Ph_tblDrugDetail ON Ph_tblDrugMaster.drugMasterCode = Ph_tblDrugDetail.drugMasterCode " & _
              "  WHERE Ph_tblDrugDetail.isActive='True' AND invoiceMedicalStockInCode=" & invoiceMedicalStockInCode_txt.Text & "  ORDER BY Ph_tblDrugDetail.drugDetailCode "
        Table = Get_DataTable(Str)
        GrdCtr_Medical.DataSource = Table

        If Table.Rows.Count > 0 Then
            GrdVw_Medical.Columns(0).Visible = False
            GrdVw_Medical.Columns(1).Visible = False
            GrdVw_Medical.Columns(11).Visible = False

            'GrdVw_Medical.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
            'GrdVw_Medical.Columns(7).SummaryItem.DisplayFormat = "Total = {0:C}"

            'GrdVw_Medical.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
            'GrdVw_Medical.Columns(8).SummaryItem.DisplayFormat = "Total = {0:C}"

            GrdVw_Medical.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
            GrdVw_Medical.Columns(10).SummaryItem.DisplayFormat = "Count = {0}"

            GrdVw_Medical.Columns(12).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
            GrdVw_Medical.Columns(12).SummaryItem.DisplayFormat = "Total = {0:C}"


            GrdVw_Medical.Columns(13).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
            GrdVw_Medical.Columns(13).SummaryItem.DisplayFormat = "Count = {0}"

            SetColorCondition()

        End If
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        from_SearchInvoiceNumber.SearchFrom = "StockIn"
        from_SearchInvoiceNumber.ShowDialog()
    End Sub

    Public Sub Search_By_InvoiceNumber(ByVal InvoiceNumber As String)
        Dim Table As New DataTable
        Table = Get_DataTable("SELECT * FROM Ph_tblInvoiceMedicalStockIn WHERE IVRecievedNum LIKE 'IV%' AND IVRecievedNum='" & InvoiceNumber & "'")
        If Table.Rows.Count > 0 Then
            IV_RecivedNum_txt.Text = Table.Rows(0).Item("IVRecievedNum")
            SupplierName_cbo.Text = ReturnSingleValue("SELECT supplierName  FROM Ph_tblSupplier WHERE supplierCode=" & Table.Rows(0).Item("supplierCode").ToString)
            RecivedDate_DateEdit.Text = Format(CDate(Table.Rows(0).Item("recievedDate").ToString), "MMM, dd yyyy")
            receivedby_txt.Text = Table.Rows(0).Item("recievedBy")
            Remark_MemoEdit1.Text = Table.Rows(0).Item("remark")
            invoiceMedicalStockInCode_txt.Text = Table.Rows(0).Item("invoiceMedicalStockInCode")
            cboCampus.Text = Table.Rows(0).Item("campus").ToString
        Else

        End If
        Load_Medical_To_List()
    End Sub

    Private Sub InitValidationRules()
        Dim Con_Field_notEmpty As New ConditionValidationRule
        Con_Field_notEmpty.ConditionOperator = ConditionOperator.IsNotBlank
        Con_Field_notEmpty.ErrorText = "Field is required "
        Con_Field_notEmpty.ErrorType = ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(SupplierName_cbo, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(RecivedDate_DateEdit, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(receivedby_txt, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(expiredDate_DateEdit, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(Generic_LookUpEdit1, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(BrandName_LookUpEdit1, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(Qty_txt, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(RealCost_txt, Con_Field_notEmpty)
        Me.DxValidationProvider1.SetValidationRule(RetailCost_txt, Con_Field_notEmpty)

    End Sub

    Private Sub GrdCtr_Medical_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GrdCtr_Medical.MouseDown
        If GrdVw_Medical.RowCount > 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Edit_ContextmenueStrip.Show(GrdCtr_Medical, e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub DeleteMedicalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMedicalToolStripMenuItem.Click
        If checkPermission("Delete", True) = False Then Exit Sub

        If GrdVw_Medical.GetFocusedRow(10).ToString <> GrdVw_Medical.GetFocusedRow(13).ToString Then
            MsgBox("Sorry you can't make change, Please use used stock adjustment instead.", , "Confirm")
            Exit Sub
        End If



        If MsgBox("Are you sure to delete Mediation << " & GrdVw_Medical.GetFocusedRow(2).ToString & " >> from list ?", vbYesNo, "Confirm") = vbYes Then
            If Update_Record("UPDATE Ph_tblDrugDetail SET updateby='" & UserName & "',updatedate='" & Now() & "' ,isActive='False' WHERE drugDetailCode=" & GrdVw_Medical.GetFocusedRow(0).ToString) Then
                MsgBox("Deleted", MsgBoxStyle.Information, "Confirm")
                '=======UPDATE Ph_tblDrugMaster TO TABLE========
                Dim Cmd As New SqlCommand
                If Not Cnn.State = ConnectionState.Open Then Cnn.Open()
                Cmd.Connection = Cnn
                Cmd.CommandType = CommandType.Text
                Dim Str As String = "UPDATE Ph_tblDrugMaster SET totalValueTodate=totalValueTodate-" & GrdVw_Medical.GetFocusedRow(10).ToString & ",totalSOH=totalSOH - " & GrdVw_Medical.GetFocusedRow(10).ToString & " WHERE drugMasterCode=" & GrdVw_Medical.GetFocusedRow(11).ToString
                Cmd.CommandText = Str
                Cmd.ExecuteNonQuery() ' Update New QTY to SOH


                Dim TmpMainCampusSHO As Integer = 0
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = " SELECT sum(Ph_tblDrugDetail.StockOnHand) AS StockOnHand FROM dbo.Ph_tblDrugMaster INNER JOIN dbo.Ph_tblDrugDetail ON dbo.Ph_tblDrugMaster.drugMasterCode = dbo.Ph_tblDrugDetail.drugMasterCode " & _
                                   " WHERE (dbo.Ph_tblDrugMaster.drugItemType = 'Pharmacy') AND (dbo.Ph_tblDrugMaster.isActive = 'True') AND (dbo.Ph_tblDrugDetail.isActive = 'True') " & _
                                   " AND dbo.Ph_tblDrugDetail.campus = '" & cboCampus.Text & "' AND (dbo.Ph_tblDrugMaster.drugMasterCode = " & GrdVw_Medical.GetFocusedRow(11).ToString & "  ) GROUP BY   Ph_tblDrugMaster.drugMasterCode "
                TmpMainCampusSHO = Cmd.ExecuteScalar()


                Dim TmpDrugMasterSOH As Integer = 0
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT totalSOH FROM  Ph_tblDrugMaster WHERE drugMasterCode=" & GrdVw_Medical.GetFocusedRow(11).ToString
                TmpDrugMasterSOH = Cmd.ExecuteScalar()

                '========Insert to Ph_tblStockTransaction=========================
                Cmd.CommandText = "INSERT INTO Ph_tblStockTransaction (drugDetailCode, transDate, mainBegQtySOH, mainCampusBegQtySOH, detailBegQtySOH, QtyReceived, detailEndQtySOH,mainCampusEndQtySOH,mainEndQtySOH, inputby, inputdate, branch, remark, isActive,DisCampus)" & _
                                  " VALUES (" & GrdVw_Medical.GetFocusedRow(0).ToString & ",'" & Now.Date & "', " & TmpDrugMasterSOH + Val(GrdVw_Medical.GetFocusedRow(10).ToString) & " ," & TmpMainCampusSHO + Val(GrdVw_Medical.GetFocusedRow(10).ToString) & " ," & GrdVw_Medical.GetFocusedRow(10).ToString & " ,-" & GrdVw_Medical.GetFocusedRow(10).ToString & " ,0," & TmpMainCampusSHO & "," & TmpDrugMasterSOH & ",'" & UserName & "' , '" & Now & "','" & CurrentBranch & "', 'IV Recieve Nº: " & IV_RecivedNum_txt.Text & " : " & Remark_MemoEdit1.Text & " - Deleted','True','" & cboCampus.Text & "')"
                Cmd.ExecuteNonQuery()
                ''================================================================

               
                frm_ManageLabStockCard.LoadMedicationList()
                frm_ManageLabStockCard.LoadSupplier()
                frm_dispensary.Initialize_ComboBox()
                '===========================================

                Load_Medical_To_List()
            End If

        End If
    End Sub

    Private Sub EditMedicalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMedicalToolStripMenuItem.Click
        If checkPermission("StockAdjustment", True) = False Then Exit Sub

        If GrdVw_Medical.RowCount > 0 Then
            'If GrdVw_Medical.GetFocusedRow(9).ToString <> GrdVw_Medical.GetFocusedRow(12).ToString Then
            '    MsgBox("Sorry you can't make change, Please use used stock adjustment instead.", , "Confirm")
            'Else
            drugDetailCode_txt.Text = GrdVw_Medical.GetFocusedRow(0).ToString
            BrandName_LookUpEdit1.EditValue = GrdVw_Medical.GetFocusedRow(11)
            txtDrugMasterCodeBeforeUpdate.Text = GrdVw_Medical.GetFocusedRow(11)
            Generic_LookUpEdit1.EditValue = GrdVw_Medical.GetFocusedRow(11)
            madeIn.Text = GrdVw_Medical.GetFocusedRow(4).ToString
            expiredDate_DateEdit.Text = GrdVw_Medical.GetFocusedRow(5).ToString
            RealCost_txt.Text = GrdVw_Medical.GetFocusedRow(8).ToString
            RetailCost_txt.Text = GrdVw_Medical.GetFocusedRow(9).ToString
            Qty_txt.Text = GrdVw_Medical.GetFocusedRow(10).ToString
            BeforeUpdateQTY_txt.Text = GrdVw_Medical.GetFocusedRow(10).ToString
            tmpSOH_txt.Text = GrdVw_Medical.GetFocusedRow(13).ToString

        End If
    End Sub

    Private Sub addSupplierName_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addSupplierName_cmd.Click
        frm_Supplier.MdiParent = frm_MainForm
        frm_Supplier.Show()
        frm_Supplier.Focus()
    End Sub

    Private Sub cmcClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmcClose.Click
        Me.Close()
    End Sub

    Private Sub Strength_txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Strength_txt.KeyDown, IV_RecivedNum_txt.KeyDown, Form_txt.KeyDown
        e.Handled = True
    End Sub

    Private Sub Strength_txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Strength_txt.KeyPress, IV_RecivedNum_txt.KeyPress, Form_txt.KeyPress
        e.Handled = True
    End Sub

    Private Sub BrandName_LookUpEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrandName_LookUpEdit1.EditValueChanged
        On Error Resume Next
        Generic_LookUpEdit1.EditValue = BrandName_LookUpEdit1.EditValue
        Strength_txt.Text = BrandName_LookUpEdit1.GetColumnValue("Strength").ToString
        Form_txt.Text = BrandName_LookUpEdit1.GetColumnValue("form").ToString
    End Sub

    Private Sub Generic_LookUpEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Generic_LookUpEdit1.EditValueChanged
        On Error Resume Next
        BrandName_LookUpEdit1.EditValue = Generic_LookUpEdit1.EditValue
        Strength_txt.Text = Generic_LookUpEdit1.GetColumnValue("Strength").ToString
        Form_txt.Text = Generic_LookUpEdit1.GetColumnValue("form").ToString
    End Sub

    Private Sub drugCode_txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drugCode_txt.Validated
        'Dim Table As New DataTable
        'Table = Get_DataTable("SELECT   realPrice, retailPrice, SOH, MandIn, DateTime  FROM  ATmpPharmacyStockIn  WHERE (drugCode = '" & drugCode_txt.Text & "')")

        'If Table.Rows.Count > 0 Then
        '    RealCost_txt.Text = Table.Rows(0).Item("realPrice")
        '    RetailCost_txt.Text = Table.Rows(0).Item("retailPrice")
        '    expiredDate_DateEdit.Text = Format(Table.Rows(0).Item("DateTime"), "dd MMM, yyyy")
        '    madeIn.Text = IIf(IsDBNull(Table.Rows(0).Item("MandIn")), 0, Table.Rows(0).Item("MandIn"))
        '    Qty_txt.Text = IIf(IsDBNull(Table.Rows(0).Item("SOH")), 0, Table.Rows(0).Item("SOH"))

        '    Generic_LookUpEdit1.Text = ReturnSingleValue("SELECT drugGenericName as [Generic Name] FROM Ph_tblDrugMaster WHERE isActive='True' AND drugCode='" & drugCode_txt.Text & "' AND branch='" & CurrentBranch & "'")
        '    Generic_LookUpEdit1.Properties.PopulateColumns()
        '    Generic_LookUpEdit1_EditValueChanged(sender, e)

        '    BrandName_LookUpEdit1.Text = ReturnSingleValue("SELECT drugBrandName as [Brand Name] FROM Ph_tblDrugMaster WHERE isActive='True' AND drugCode='" & drugCode_txt.Text & "' AND branch='" & CurrentBranch & "'")
        '    BrandName_LookUpEdit1.Properties.PopulateColumns()
        '    BrandName_LookUpEdit1_EditValueChanged(sender, e)
        '    SaveMedical_cmd.Focus()
        'Else
        '    MsgBox("Sorry not found")

        'End If

    End Sub

    Private Sub previewReport_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles previewReport_cmd.Click
        If GrdVw_Medical.RowCount > 0 Then
            frmMain_XtraRpt_MedicationDespensaryDetail.Close()
            frmMain_XtraRpt_MedicationDespensaryDetail.RptName = "MedicalStockinByInvoice"
            frmMain_XtraRpt_MedicationDespensaryDetail.MdiParent = frm_MainForm
            frmMain_XtraRpt_MedicationDespensaryDetail.Show()
            frmMain_XtraRpt_MedicationDespensaryDetail.Focus()
            frmMain_XtraRpt_MedicationDespensaryDetail.Text = "Report- Medication Stock in Detail - Summary"

            frmMain_XtraRpt_MedicationDespensaryDetail.NavBarControl1.Visible = False
            frmMain_XtraRpt_MedicationDespensaryDetail.StockinIVNum_txt.Text = IV_RecivedNum_txt.Text
            frmMain_XtraRpt_MedicationDespensaryDetail.supplierName_cbo.Text = "ALL"
            frmMain_XtraRpt_MedicationDespensaryDetail.StartDate_Dtp.Text = ""
            frmMain_XtraRpt_MedicationDespensaryDetail.StopDate_Dtp.Text = ""
            frmMain_XtraRpt_MedicationDespensaryDetail.cmdShowReport_Click(sender, e)
        Else
            MsgBox("Not found medication to print", , "Not Found")
        End If

    End Sub

    Private Sub SetColorCondition()
        Dim cn As DevExpress.XtraGrid.StyleFormatCondition
        cn = New StyleFormatCondition(FormatConditionEnum.Equal, GrdVw_Medical.Columns("Stock Adjusted"), Nothing, "Adjusted")
        cn.Appearance.BackColor = Color.LightGray
        cn.Appearance.ForeColor = Color.FromArgb(&HCC, &H0, &H0)
        cn.ApplyToRow = True
        GrdVw_Medical.FormatConditions.Add(cn)

        cn = New StyleFormatCondition(FormatConditionEnum.Equal, GrdVw_Medical.Columns("Stock Adjusted"), Nothing, "")
        cn.Appearance.BackColor = Color.White
        cn.Appearance.ForeColor = Color.Black
        cn.ApplyToRow = True
        GrdVw_Medical.FormatConditions.Add(cn)
    End Sub


    Private Sub markup_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles markup_txt.TextChanged
        If RealCost_txt.Text.Trim <> "" Then
            RetailCost_txt.Text = Format(((Val(RealCost_txt.Text) * Val(markup_txt.Text)) / 100) + Val(RealCost_txt.Text), "0.000")
        End If
    End Sub

    Private Sub RetailCost_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetailCost_txt.TextChanged
        If RealCost_txt.Text.Trim <> "" Then
            markup_txt.Text = Format(((Val(RetailCost_txt.Text) - Val(RealCost_txt.Text)) / Val(RealCost_txt.Text)) * 100, "0")

        End If
    End Sub

    Private Sub RealCost_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RealCost_txt.TextChanged
        If RetailCost_txt.Text.Trim <> "" Or markup_txt.Text.Trim <> "" Then
            RetailCost_txt_TextChanged(sender, e)
        End If

    End Sub
End Class

Private Sub GoToStockInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToStockInToolStripMenuItem.Click
        If GrdVw_Supplier.RowCount > 0 Then
            If GrdVw_Supplier.GetFocusedRow(0).ToString.Contains("TF") Then
                frm_transferStock.MdiParent = frm_MainForm
                frm_transferStock.Show()
                frm_transferStock.Search_By_InvoiceNumber(GrdVw_Supplier.GetFocusedRow(0).ToString)
                frm_transferStock.Focus()
                frm_transferStock.GrdVw_Medical.ApplyFindFilter(brandName_txt.Text)
            Else
                frm_StockIn.MdiParent = frm_MainForm
                frm_StockIn.Show()
                frm_StockIn.Search_By_InvoiceNumber(GrdVw_Supplier.GetFocusedRow(0).ToString)
                frm_StockIn.Focus()
                frm_StockIn.GrdVw_Medical.ApplyFindFilter(brandName_txt.Text)
            End If

        End If
    End Sub

    Private Sub ModifyExpiredDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifyExpiredDateToolStripMenuItem.Click
        If GrdVw_Supplier.RowCount > 0 Then
            frm_ModifyMedicationExpiredDate.GetValue(DrugCode_txt.Text, brandName_txt.Text, GrdVw_Supplier.GetFocusedRow("Quantity").ToString, GrdVw_Supplier.GetFocusedRow("StockOnHand").ToString, GrdVw_Supplier.GetFocusedRow("Expired Date").ToString, GrdVw_Supplier.GetFocusedRow("drugDetailCode").ToString)
            frm_ModifyMedicationExpiredDate.ShowDialog()
        End If
    End Sub

	
    Private Sub DateEditExpiredDate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateEditExpiredDate.Validated
        If DateEditExpiredDate.Text.Trim <> "" Then
            DateEditExpiredDate.Text = Format(CDate(DateEditExpiredDate.Text), "MMM dd, yyyy")
        End If
    End Sub

    Public Sub GetValue(ByVal MedCode As String, ByVal BrandName As String, ByVal Qty As Integer, ByVal SOH As Integer, ByVal Expired As Date, ByVal drugDetailCode As Integer)
        txtMedCode.Text = MedCode
        TxTBrandName.Text = BrandName
        txtQty.Text = Qty
        txtSOH.Text = SOH
        DateEditExpiredDate.Text = Format(CDate(Expired), "MMM dd, yyyy")
        txtDrugDetailCode.Text = drugDetailCode
    End Sub


    Private Sub cmdSave_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.CheckedChanged
        If MsgBox("Are you sure to modify this medication expired date ?", vbYesNo, "Confirm") = vbYes Then
            If Update_Record("UPDATE Ph_tblDrugDetail SET  updateby='" & UserName & "',updatedate='" & Now() & "' ,expiredDate='" & DateEditExpiredDate.Text & "' WHERE drugDetailCode=" & txtDrugDetailCode.Text) Then
                frm_ManageLabStockCard.LoadSupplier()
                MsgBox("Updated", MsgBoxStyle.Information, "Confirm")
                Me.Close()
            End If
        End If
    End Sub


	--WARNING! ERRORS ENCOUNTERED DURING SQL PARSING!
SELECT IVRecievedNum
	,RecievedDate
	,Recievedby
	,Remark
	,Ph_tblSupplier.supplierName
	,drugBrandName
	,Form
	,Strength
	,ProductMadein
	,ExpiredDate
	,RealCost
	,Ph_tblDrugMaster.mainRetailPrice AS RetailCost
	,Quantity
	,Ph_tblDrugDetail.realCost * Quantity AS [LineTotalRealCost]
FROM Ph_tblInvoiceMedicalStockIn
INNER JOIN Ph_tblDrugDetail ON Ph_tblInvoiceMedicalStockIn.invoiceMedicalStockInCode = Ph_tblDrugDetail.invoiceMedicalStockInCode
INNER JOIN Ph_tblDrugMaster ON Ph_tblDrugDetail.drugMasterCode = Ph_tblDrugMaster.drugMasterCode
INNER JOIN Ph_tblSupplier ON Ph_tblInvoiceMedicalStockIn.supplierCode = Ph_tblSupplier.supplierCode
WHERE Ph_tblInvoiceMedicalStockIn.isActive = 'True'
	AND Ph_tblDrugDetail.isActive = 'True'
	AND IVRecievedNum LIKE '%IV%'
	AND drugItemType = 'Pharmacy'
	AND Ph_tblInvoiceMedicalStockIn.IVRecievedNum = 'IV19000020'
