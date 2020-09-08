Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmMedicationDispensary
    Dim ComboGenericClick As Boolean = False
    Dim DrugItemType As String = "Pharmacy"
    Dim TempPatientID As Integer = 0
    Dim TempPatientCode As String = ""
    Dim RowIndex As Integer = 0
    Dim dtDispensary, dtDispensaryDetail As New DataTable

    Dim MedicationDispensaryDetailCode As Integer = 0
    Dim MedicationDispensaryCode As Integer = 0
    Dim DrugMasterCodeBeforeUpdate As Integer = 0
    Dim DrugDetailCodeBeforeUpdate As Integer = 0
    Dim QuantityBeforeUpdate As Decimal = 0

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dispose()
    End Sub

    Private Sub LoadClinic()
        Try
            GetDataToComboBoxWithParam(lueClinic, "SA_GetClinicByID", "ClinicID", "ClinicEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
            If Not IsNothing(ConfigClinic) Then
                lueClinic.EditValue = ConfigClinic.ClinicID
            Else
                lueClinic.EditValue = -1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDoctor()
        Try
            GetDataToComboBoxWithParam(luePrescriber, "SA_GetDoctorsToList", "ID", "Doctor", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub SelectMedicationInfo(Optional _DrugMasterCode As Integer = 0, Optional _DrugName As String = "", Optional _MedCode As String = "")
    '    Try
    '        Dim dtData As DataTable = GetDataFromDBToTable("SA_GetDrugMasterList", New SqlParameter("@DrugMasterCode", _DrugMasterCode), New SqlParameter("@MedCode", _MedCode), New SqlParameter("@DrugItemType", DrugItemType))
    '        With dtData
    '            If .Rows.Count = 1 Then
    '                If ComboGenericClick Then
    '                    lueBrandName.EditValue = CInt(.Rows(0)("DrugMasterCode"))
    '                Else
    '                    lueGenericName.EditValue = CInt(.Rows(0)("DrugMasterCode"))
    '                End If
    '                txtForm.Text = .Rows(0)("Form").ToString
    '                txtStrength.Text = .Rows(0)("Strength").ToString

    '                If Not String.IsNullOrEmpty(.Rows(0)("ExpiredDate").ToString) Then
    '                    deExpiredDate.DateTime = CDate(.Rows(0)("ExpiredDate").ToString)
    '                Else
    '                    deExpiredDate.DateTime = Now.Date
    '                End If
    '                txtAvgCost.Text = Format(CDec(IIf(String.IsNullOrEmpty(.Rows(0)("RealCost").ToString), 0, .Rows(0)("RealCost").ToString)), "0.000")
    '                txtSalePrice.Text = Format(CDec(IIf(String.IsNullOrEmpty(.Rows(0)("RetailCost").ToString), 0, .Rows(0)("RetailCost").ToString)), "0.000")
    '                txtSOH.Text = Format(CDec(IIf(String.IsNullOrEmpty(.Rows(0)("StockOnHand").ToString), 0, .Rows(0)("StockOnHand").ToString)), "0.00")
    '                txtQuantity.Focus()
    '            Else
    '                If ComboGenericClick Then
    '                    lueBrandName.EditValue = -1
    '                Else
    '                    lueGenericName.EditValue = -1
    '                End If
    '                txtForm.Text = ""
    '                txtStrength.Text = ""
    '                txtMadeIn.Text = ""
    '                txtSOH.Text = ""
    '                txtQuantity.Text = ""
    '                txtAvgCost.Text = ""
    '                txtSalePrice.Text = ""
    '                lueBrandName.Focus()
    '            End If
    '        End With
    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    Public Sub InitGeneric()
        Try
            GetDataToComboBoxFitColWithParam(lueGenericName, "SA_GetBrandGenNameByID", "Code", "GenericName",
                                       New SqlParameter("@ID", 0),
                                       New SqlParameter("@isList", 4),
                                       New SqlParameter("@Branch", ConfigClinic.Clinic),
                                       New SqlParameter("@DrugItemType", DrugItemType))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub InitMedication()
        Try
            GetDataToComboBoxFitColWithParam(lueBrandName, "SA_GetBrandGenNameByID", "Code", "BrandName",
                                       New SqlParameter("@ID", 0),
                                       New SqlParameter("@isList", 3),
                                       New SqlParameter("@Branch", ConfigClinic.Clinic),
                                       New SqlParameter("@DrugItemType", DrugItemType))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub


    Private Sub frmMedicationDispensary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deDOB.DateTime = Now.Date.AddYears(-18)
        deExpiredDate.DateTime = Now.Date
        dePresDate.DateTime = Now.Date
        LoadClinic()
        LoadDoctor()
        InitGeneric()
        InitMedication()
        txtPatientCode.Select()
    End Sub

    Private Sub lueBrandName_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueBrandName.Closed
        ComboGenericClick = False
        Try
            With lueBrandName
                lueGenericName.EditValue = .EditValue
                txtStrength.Text = .GetColumnValue("Strength").ToString
                txtForm.Text = .GetColumnValue("Form").ToString
                txtMadeIn.Text = .GetColumnValue("MadeIn").ToString
                If Not String.IsNullOrEmpty(.GetColumnValue("ExpiredDate").ToString) Then
                    deExpiredDate.DateTime = CDate(.GetColumnValue("ExpiredDate").ToString)
                Else
                    deExpiredDate.DateTime = Now.Date
                End If
                txtAvgCost.Text = Format(CDec(IIf(String.IsNullOrEmpty(.GetColumnValue("AvgCost").ToString), 0, .GetColumnValue("AvgCost").ToString)), "0.000")
                txtSalePrice.Text = Format(CDec(IIf(String.IsNullOrEmpty(.GetColumnValue("RetailCost").ToString), 0, .GetColumnValue("RetailCost").ToString)), "0.000")
                txtSOH.Text = Format(CDec(IIf(String.IsNullOrEmpty(.GetColumnValue("StockOnHand").ToString), 0, .GetColumnValue("StockOnHand").ToString)), "0.00")
            End With
            txtQuantity.Focus()
        Catch ex As Exception
            ClearMedicationContent()
        End Try
    End Sub

    Private Sub lueGenericName_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles lueGenericName.Closed
        ComboGenericClick = True
        'SelectMedicationInfo(CInt(lueGenericName.EditValue), lueGenericName.Text.Trim)
        Try
            With lueGenericName
                lueBrandName.EditValue = .EditValue
                txtStrength.Text = .GetColumnValue("Strength").ToString
                txtForm.Text = .GetColumnValue("Form").ToString
                txtMadeIn.Text = .GetColumnValue("MadeIn").ToString
                If Not String.IsNullOrEmpty(.GetColumnValue("ExpiredDate").ToString) Then
                    deExpiredDate.DateTime = CDate(.GetColumnValue("ExpiredDate").ToString)
                Else
                    deExpiredDate.DateTime = Now.Date
                End If
                txtAvgCost.Text = Format(CDec(IIf(String.IsNullOrEmpty(.GetColumnValue("AvgCost").ToString), 0, .GetColumnValue("AvgCost").ToString)), "0.000")
                txtSalePrice.Text = Format(CDec(IIf(String.IsNullOrEmpty(.GetColumnValue("RetailCost").ToString), 0, .GetColumnValue("RetailCost").ToString)), "0.000")
                txtSOH.Text = Format(CDec(IIf(String.IsNullOrEmpty(.GetColumnValue("StockOnHand").ToString), 0, .GetColumnValue("StockOnHand").ToString)), "0.00")
            End With
            txtQuantity.Focus()
        Catch ex As Exception
            ClearMedicationContent()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnClear.Enabled = False
        txtPatientCode.ReadOnly = False
        ClearAllContents()
        txtPatientCode.Select()
    End Sub

    Private Sub ClearAllContents()
        lueClinic.Enabled = True
        If Not IsNothing(ConfigClinic) Then
            lueClinic.EditValue = ConfigClinic.ClinicID
        Else
            lueClinic.EditValue = -1
        End If

        ComboGenericClick = False
        TempPatientID = 0
        TempPatientCode = ""
        ClearPatientInfo()
        ClearPrescriptionContent()
        lueBrandName.EditValue = -1
        lueGenericName.EditValue = -1
        txtQuantity.Text = ""
        meNote.Text = ""
        MedicationDispensaryDetailCode = 0
        MedicationDispensaryCode = 0
        DrugMasterCodeBeforeUpdate = 0
        DrugDetailCodeBeforeUpdate = 0
        QuantityBeforeUpdate = 0
        dtDispensary.Clear()
        dtDispensaryDetail.Clear()
        ClearMedicationContent()
    End Sub

    Private Sub ClearMedicationContent()
        txtForm.Text = ""
        txtStrength.Text = ""
        txtMadeIn.Text = ""
        txtSOH.Text = ""
        txtAvgCost.Text = ""
        txtSalePrice.Text = ""
        deExpiredDate.DateTime = Now.Date
    End Sub

    Private Sub ClearPatientInfo()
        txtPatientCode.Text = ""
        txtPatientName.Text = ""
        txtGender.Text = ""
        deDOB.DateTime = Now.Date.AddYears(-18)
        txtOccupation.Text = ""
    End Sub

    Private Sub ClearPrescriptionContent()
        txtPresCode.Text = "***"
        dePresDate.DateTime = Now.Date
        luePrescriber.EditValue = -1
        meRemark.Text = ""
        btnFirst.Enabled = False
        btnPrev.Enabled = False
        btnNewPres.Enabled = False
        btnNext.Enabled = False
        btnLast.Enabled = False
        btnCancelPres.Enabled = False
        txtPage.Text = "New / 0"
        lblCancelReason.Text = ""
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub txtPatientCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPatientCode.KeyPress
        PTCode_KeyPress(txtPatientCode, e)
    End Sub

    Friend Sub txtPatientCode_Validated(sender As Object, e As EventArgs) Handles txtPatientCode.Validated
        LoadPatientInfo()
    End Sub

    Private Sub LoadPatientInfo()
        Try
            TempPatientCode = GetStandardPatientCode(txtPatientCode.Text.Trim)
            If String.IsNullOrEmpty(txtPatientCode.Text.Trim) Then ClearAllContents() : Exit Sub

            If Len(GetStandardPatientCode(txtPatientCode.Text.Trim)) = 9 Then
                Dim dtData As DataTable = GetDataFromDBToTable("SA_GetPatientProfile", New SqlParameter("@PatientCode", GetStandardPatientCode(txtPatientCode.Text.Trim)))
                With dtData
                    If .Rows.Count = 1 Then
                        txtPatientCode.ReadOnly = True
                        lueClinic.Enabled = False
                        btnClear.Enabled = True
                        TempPatientID = CInt(.Rows(0)("PatientID"))
                        TempPatientCode = .Rows(0)("PatientCode").ToString
                        txtPatientName.Text = .Rows(0)("EnglishName").ToString
                        txtGender.Text = .Rows(0)("Gender").ToString
                        Dim dob As String = .Rows(0)("DOB").ToString
                        If String.IsNullOrEmpty(dob) Then
                            deDOB.DateTime = DateTime.Now.AddYears(-18)
                        Else
                            deDOB.DateTime = Convert.ToDateTime(dob)
                        End If
                        txtAge.Text = .Rows(0)("Age").ToString
                        txtOccupation.Text = .Rows(0)("PTOccupation").ToString


                        LoadMedicationDispensary(GetStandardPatientCode(txtPatientCode.Text.Trim))

                        RowIndex = 0
                        LoadDispensaryRecord(RowIndex)
                        EnableNavigation()
                        luePrescriber.Focus()
                    Else
                        XtraMessageBox.Show("Searching keyword: " + txtPatientCode.Text.Trim + " doesnot exist on the target system. " & vbLf & "Please try another Patient Code.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End With
            Else
                XtraMessageBox.Show("Oops, you probably input wrong patient code.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPatientName.Text = ""
                txtGender.Text = ""
                deDOB.DateTime = Now.Date.AddYears(-18)
                txtOccupation.Text = ""
                txtPatientCode.Focus()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + "." + vbNewLine + "Please see your System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMedicationDispensary(Optional _PatientCode As String = "")
        Try
            '=====Initialize Dispensary=========
            dtDispensary.Clear()
            dtDispensary = GetDataFromDBToTable("SA_GetMedicationDispensary", New SqlParameter("@PatientCode", _PatientCode), New SqlParameter("@Branch", CInt(lueClinic.EditValue)))
            If dtDispensary.Rows.Count > 0 Then
                '=====Initialize DispensaryDetail===
                dtDispensaryDetail.Clear()
                dtDispensaryDetail = GetDataFromDBToTable("SA_GetMedicationDispensaryDetail", New SqlParameter("@PatientCode", _PatientCode))

                If dtDispensaryDetail.Rows.Count > 0 Then

                End If

                dtDispensaryDetail.PrimaryKey = New DataColumn() {dtDispensaryDetail.Columns("MedicationDispensaryDetailCode")}
            End If
            '===================================
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDispensaryRecord(Optional Row As Integer = 0)
        Dim DrowDispensry As DataRow
        If dtDispensary.Rows.Count = 0 Then
            'Clear(False)
            RowIndex = 0
            EnableNavigation()
            Exit Sub
        End If
        DrowDispensry = dtDispensary.Rows(Row)
        txtPresCode.Text = DrowDispensry("DisCode").ToString
        dePresDate.DateTime = CDate(DrowDispensry("DateTimeStamp"))
        luePrescriber.EditValue = CInt(DrowDispensry("Prescriber"))
        meRemark.Text = DrowDispensry("Remark").ToString
        MedicationDispensaryCode = CInt(DrowDispensry("MedicationDipensaryCode"))
        lueClinic.EditValue = CInt(DrowDispensry("DisCampus"))

        '==========Check isCancel============
        If CBool(DrowDispensry("isCancel")) = True Then
            lblCancelReason.Text = DrowDispensry("cancelReason").ToString
        Else
            lblCancelReason.Text = ""
        End If
        '====================================

        gcMedications.DataSource = dtDispensaryDetail


        '========Row Postion========
        txtPage.Text = RowIndex + 1 & " / " & IIf(dtDispensary.Rows.Count <= 0, 1, dtDispensary.Rows.Count).ToString
        '===========================


        'Dim SerivceView As ColumnView = GrdVw_Medical
        'SerivceView.ActiveFilter.Add(SerivceView.Columns("MedicationdiSpensaryCode"),
        '                             New ColumnFilterInfo("MedicationdiSpensaryCode =" & MedicationDispensaryCode_txt.Text & " ", ""))

        'If gvMedications.RowCount > 0 Then

        '    GrdVw_Medical.Columns(0).Visible = False
        '    GrdVw_Medical.Columns(1).Visible = False
        '    GrdVw_Medical.Columns(12).Visible = False
        '    GrdVw_Medical.Columns(13).Visible = False
        '    GrdVw_Medical.Columns(14).Visible = False

        '    'GrdVw_Medical.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
        '    'GrdVw_Medical.Columns(7).SummaryItem.DisplayFormat = "Total = {0:C}"

        '    'GrdVw_Medical.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
        '    'GrdVw_Medical.Columns(8).SummaryItem.DisplayFormat = "Total = {0:C}"

        '    GrdVw_Medical.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
        '    GrdVw_Medical.Columns(10).SummaryItem.DisplayFormat = "Count = {0}"

        '    GrdVw_Medical.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum 'Summary
        '    GrdVw_Medical.Columns(11).SummaryItem.DisplayFormat = "Total = {0:C}"

        '    '=========Update to database ==============
        '    Dim TotalQTY As Double
        '    Dim LineTotal As Double
        '    For i As Integer = 0 To Me.GrdVw_Medical.RowCount - 1
        '        TotalQTY += GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("Quantity"))
        '        LineTotal += GrdVw_Medical.GetRowCellValue(i, GrdVw_Medical.Columns("Line Total"))
        '    Next
        '    Update_Record("UPDATE Ph_tblMedicationDispensary SET TotalAmount=" & LineTotal & ", TotalQuantity = " & TotalQTY & " WHERE MedicationdiSpensaryCode = " & MedicationDispensaryCode_txt.Text)
        '    '===========================================

        '    If checkPermission("Write", False) = False Then 'Hide real cost for user that don't have per mission
        '        GrdVw_Medical.Columns("RealCost").Visible = False
        '    End If
        'End If
    End Sub

    Private Sub EnableNavigation()
        If dtDispensary.Rows.Count > 0 Then
            If RowIndex = 0 Then
                btnFirst.Enabled = False
                btnPrev.Enabled = False
                btnNext.Enabled = True
                btnLast.Enabled = True
            ElseIf RowIndex <= dtDispensary.Rows.Count - 1 Then
                btnFirst.Enabled = True
                btnPrev.Enabled = True
                btnNext.Enabled = True
                btnLast.Enabled = True
            ElseIf RowIndex = dtDispensary.Rows.Count - 1 Then
                btnPrev.Enabled = True
                btnFirst.Enabled = True
                btnNext.Enabled = False
                btnLast.Enabled = False
            End If
        Else
            btnFirst.Enabled = False
            btnPrev.Enabled = False
            btnNext.Enabled = False
            btnLast.Enabled = False
        End If

        txtPage.Text = RowIndex + 1 & " / " & IIf(dtDispensary.Rows.Count <= 0, 1, dtDispensary.Rows.Count).ToString
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        RowIndex = dtDispensary.Rows.Count - 1
        EnableNavigation()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        RowIndex = 0
        EnableNavigation()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If RowIndex <= dtDispensary.Rows.Count - 1 Then
            RowIndex += 1
            If RowIndex > dtDispensary.Rows.Count - 1 Then RowIndex = dtDispensary.Rows.Count - 1
        End If
        EnableNavigation()
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If RowIndex >= 0 Then
            RowIndex -= 1
            If RowIndex < 0 Then RowIndex = 0
        End If
        EnableNavigation()
    End Sub

    Private Sub btnNewPres_Click(sender As Object, e As EventArgs) Handles btnNewPres.Click
        txtPresCode.Text = "***"
        dePresDate.DateTime = Now.Date
        luePrescriber.EditValue = -1
        meRemark.Text = ""

        btnNewPres.Enabled = False
        RowIndex = 0
        txtPage.Text = "New / " + IIf(dtDispensary.Rows.Count <= 0, 1, dtDispensary.Rows.Count).ToString
        luePrescriber.Focus()
    End Sub

    Private Sub luePrescriber_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles luePrescriber.Closed
        If TempPatientCode <> "" And CInt(luePrescriber.EditValue) > 0 Then btnAdd.Enabled = True
        meRemark.Focus()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(lblCancelReason.Text.Trim) Then
            XtraMessageBox.Show("Oops! You CANNOT make change due to the prescription is already cancelled.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            luePrescriber.Focus()
            Return
        ElseIf TempPatientCode = "" OrElse String.IsNullOrEmpty(luePrescriber.Text.Trim) Then
            XtraMessageBox.Show("Please enter the patient code.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPatientCode.Focus()
            Return
        End If
    End Sub

    Private Sub txtPatientCode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPatientCode.KeyUp
        If (e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control) Then btnSearch_Click(Nothing, Nothing)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmSearchMedicationDispensary.Opt = "Dispensary"
        LoadFormDialog(frmSearchMedicationDispensary)
        If String.IsNullOrEmpty(txtPatientCode.Text.Trim) Then txtPatientCode.Focus()
    End Sub
End Class