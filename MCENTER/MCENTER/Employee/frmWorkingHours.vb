Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmWorkingHours
    Private _ID, _Name, _WorkingPeriod, _EmpStatus, _StartDate, _StopDate As String

    Dim MFM1 As String, MFM2 As String, MFA1 As String, MFA2 As String, MFE1 As String, MFE2 As String
    Dim SAM1 As String, SAM2 As String, SAA1 As String, SAA2 As String, SAE1 As String, SAE2 As String
    Dim SUM1 As String, SUM2 As String, SUA1 As String, SUA2 As String, SUE1 As String, SUE2 As String
    Dim TotalWH As Double = 0

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(Optional ByVal ID As String = "", Optional Name As String = "", Optional WorkingPeriod As String = "", Optional EmpStatus As String = "", Optional StartDate As String = "", Optional StopDate As String = "")
        _ID = ID
        _Name = Name
        _WorkingPeriod = WorkingPeriod
        _EmpStatus = EmpStatus
        _StartDate = StartDate
        _StopDate = StopDate
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtEmpID.Text.Trim()) Then
            XtraMessageBox.Show("Please select an Employee!", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSID.Focus()
            Return
        End If

        Try
            Dim StrEmpID As String = ""
            Dim _CardID As String = txtEmpID.Text.Trim
            Dim _CardIDList As String() = tempCardID.Split(Splits, StringSplitOptions.RemoveEmptyEntries)

            Dim SMFM1 As Object = teMFM1.Text
            Dim SMFM2 As Object = teMFM2.Text
            Dim SMFA1 As Object = teMFA1.Text
            Dim SMFA2 As Object = teMFA2.Text
            Dim SMFE1 As Object = teMFE1.Text
            Dim SMFE2 As Object = teMFE2.Text
            Dim SSAM1 As Object = teSAM1.Text
            Dim SSAM2 As Object = teSAM2.Text
            Dim SSAA1 As Object = teSAA1.Text
            Dim SSAA2 As Object = teSAA2.Text
            Dim SSUM1 As Object = teSUM1.Text
            Dim SSUM2 As Object = teSUM2.Text
            Dim SSUA1 As Object = teSUA1.Text
            Dim SSUA2 As Object = teSUA2.Text

            'Dim GetImage As Object

            If Not chkMFM.Checked Then
                SMFM1 = ""
                SMFM2 = ""
            End If

            If Not chkMFA.Checked Then
                SMFA1 = ""
                SMFA2 = ""
            End If

            If Not chkMFE.Checked Then
                SMFE1 = ""
                SMFE2 = ""
            End If

            If Not chkSAM.Checked Then
                SSAM1 = ""
                SSAM2 = ""
            End If

            If Not chkSAA.Checked Then
                SSAA1 = ""
                SSAA2 = ""
            End If

            If Not chkSUM.Checked Then
                SSUM1 = ""
                SSUM2 = ""
            End If

            If Not chkSUA.Checked Then
                SSUA1 = ""
                SSUA2 = ""
            End If

            Dim Condition As String = rdoCondition.EditValue.ToString
            'Dim NewInsertID As Integer = GetNewRecordID("SA_GetNewWorkingHoursID")
            'If txtShiftNo.Text <> "***" Then
            '    NewInsertID = CInt(txtShiftNo.Text.Trim)
            'End If

            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_UpdateEmployeeWorkingHours", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                '.AddWithValue("@StaffNo", NewInsertID)
                '.AddWithValue("@CardID", Trim(t))
                .AddWithValue("@EmpIDList", _CardID)
                .AddWithValue("@Condition", Condition)
                .AddWithValue("@TotalWorkingHour", txtTWH.Text.Trim)
                .AddWithValue("@M_TimeIn", SMFM1)
                .AddWithValue("@M_TimeOut", SMFM2)
                .AddWithValue("@A_TimeIn", SMFA1)
                .AddWithValue("@A_TimeOut", SMFA2)
                .AddWithValue("@E_TimeIn", SMFE1)
                .AddWithValue("@E_TimeOut", SMFE2)
                .AddWithValue("@SM_TimeIn", SSAM1)
                .AddWithValue("@SM_TimeOut", SSAM2)
                .AddWithValue("@SA_TimeIn", SSAA1)
                .AddWithValue("@SA_TimeOut", SSAA2)
                .AddWithValue("@UM_TimeIn", SSUM1)
                .AddWithValue("@UM_TimeOut", SSUM2)
                .AddWithValue("@UA_TimeIn", SSUA1)
                .AddWithValue("@UA_TimeOut", SSUA2)
                .AddWithValue("@EffectiveDate", deEffectiveDate.EditValue)
                .AddWithValue("@UserCreate", AccountName)
                .AddWithValue("@UserUpdate", AccountName)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 200)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            'i += 1
            EnabledButtonSave()

            Dim StrMsg As String = ""
            Dim AddRecord As Integer = CInt(cmd.Parameters("@IsAdd").Value.ToString)
            Dim mms As MessageBoxIcon = MessageBoxIcon.Information
            If AddRecord = 2 Then
                EnabledButtonSave("Save", False)
                StrMsg = "Working hour has been updated for employee id " + txtEmpID.Text.Trim + " successfully."
            ElseIf AddRecord = 1 Then
                EnabledButtonSave("Save", False)
                StrMsg = "Working hour has been set for employee id " + txtEmpID.Text.Trim + " successfully."
            Else
                mms = MessageBoxIcon.Error
                StrMsg = "System Error: Employee ID: " + txtEmpID.Text.Trim + " cannot set duplicate working hours."
            End If

            LoadWorkingHoursToList(txtEmpID.Text.Trim)

            If isOpenForm = 1 And (AddRecord = 1 Or AddRecord = 2) Then
                frmReportWorkingHours.GetDataListReportByEmpID(LogDeptID)
            End If
            XtraMessageBox.Show(StrMsg, "Working Hours", MessageBoxButtons.OK, mms)
            btnClear.Focus()

            'Dim i As Integer = 0
            'For Each t As String In StaffIDList
            '    If Not String.IsNullOrEmpty(Trim(t)) Then

            '        Dim SMFM1 As Object = teMFM1.Text
            '        Dim SMFM2 As Object = teMFM2.Text
            '        Dim SMFA1 As Object = teMFA1.Text
            '        Dim SMFA2 As Object = teMFA2.Text
            '        Dim SMFE1 As Object = teMFE1.Text
            '        Dim SMFE2 As Object = teMFE2.Text
            '        Dim SSAM1 As Object = teSAM1.Text
            '        Dim SSAM2 As Object = teSAM2.Text
            '        Dim SSAA1 As Object = teSAA1.Text
            '        Dim SSAA2 As Object = teSAA2.Text
            '        Dim SSUM1 As Object = teSUM1.Text
            '        Dim SSUM2 As Object = teSUM2.Text
            '        Dim SSUA1 As Object = teSUA1.Text
            '        Dim SSUA2 As Object = teSUA2.Text

            '        'Dim GetImage As Object

            '        If Not chkMFM.Checked Then
            '            SMFM1 = ""
            '            SMFM2 = ""
            '        End If

            '        If Not chkMFA.Checked Then
            '            SMFA1 = ""
            '            SMFA2 = ""
            '        End If

            '        If Not chkMFE.Checked Then
            '            SMFE1 = ""
            '            SMFE2 = ""
            '        End If

            '        If Not chkSAM.Checked Then
            '            SSAM1 = ""
            '            SSAM2 = ""
            '        End If

            '        If Not chkSAA.Checked Then
            '            SSAA1 = ""
            '            SSAA2 = ""
            '        End If

            '        If Not chkSUM.Checked Then
            '            SSUM1 = ""
            '            SSUM2 = ""
            '        End If

            '        If Not chkSUA.Checked Then
            '            SSUA1 = ""
            '            SSUA2 = ""
            '        End If

            '        Dim Condition As String = rdoCondition.EditValue.ToString
            '        'Dim NewInsertID As Integer = GetNewRecordID("SA_GetNewWorkingHoursID")
            '        'If txtShiftNo.Text <> "***" Then
            '        '    NewInsertID = CInt(txtShiftNo.Text.Trim)
            '        'End If

            '        OpenCon(Con)
            '        Dim cmd As New SqlCommand("SA_UpdateEmployeeWorkingHours", Con)
            '        cmd.CommandType = CommandType.StoredProcedure
            '        With cmd.Parameters
            '            '.AddWithValue("@StaffNo", NewInsertID)
            '            '.AddWithValue("@CardID", Trim(t))
            '            .AddWithValue("@EmpIDList", _StaffID)
            '            .AddWithValue("@Condition", Condition)
            '            .AddWithValue("@TotalWorkingHour", txtTWH.Text.Trim)
            '            .AddWithValue("@M_TimeIn", SMFM1)
            '            .AddWithValue("@M_TimeOut", SMFM2)
            '            .AddWithValue("@A_TimeIn", SMFA1)
            '            .AddWithValue("@A_TimeOut", SMFA2)
            '            .AddWithValue("@E_TimeIn", SMFE1)
            '            .AddWithValue("@E_TimeOut", SMFE2)
            '            .AddWithValue("@SM_TimeIn", SSAM1)
            '            .AddWithValue("@SM_TimeOut", SSAM2)
            '            .AddWithValue("@SA_TimeIn", SSAA1)
            '            .AddWithValue("@SA_TimeOut", SSAA2)
            '            .AddWithValue("@UM_TimeIn", SSUM1)
            '            .AddWithValue("@UM_TimeOut", SSUM2)
            '            .AddWithValue("@UA_TimeIn", SSUA1)
            '            .AddWithValue("@UA_TimeOut", SSUA2)
            '            .AddWithValue("@EffectiveDate", deEffectiveDate.EditValue)
            '            .AddWithValue("@UserCreate", AccountName)
            '            .AddWithValue("@UserUpdate", AccountName)
            '            .Add("@IsAdd", SqlDbType.Int)
            '            cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
            '            .Add("@Msg", SqlDbType.NVarChar, 200)
            '            cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            '        End With
            '        cmd.ExecuteNonQuery()
            '        cmd.Dispose()
            '        i += 1
            '        EnabledButtonSave()

            '        If i = StaffIDList.Count Then
            '            Dim StrMsg As String = ""
            '            Dim AddRecord As Integer = CInt(cmd.Parameters("@IsAdd").Value.ToString)
            '            Dim mms As MessageBoxIcon = MessageBoxIcon.Information
            '            If AddRecord = 1 Then
            '                EnabledButtonSave("Save", False)
            '                StrMsg = "Working hour has been set for employee id " + txtEmpID.Text.Trim + " successfully."
            '            ElseIf AddRecord = 2 Then
            '                EnabledButtonSave("Save", False)
            '                StrMsg = "Working hour has been updated for employee id " + txtEmpID.Text.Trim + " successfully."
            '            Else
            '                mms = MessageBoxIcon.Error
            '                StrMsg = "System Error: Employee ID: " + txtEmpID.Text.Trim + " cannot set duplicate working hours."
            '            End If

            '            LoadWorkingHoursToList(txtEmpID.Text.Trim)

            '            If IsOpenForm = 1 And (AddRecord = 1 Or AddRecord = 2) Then
            '                frmReportWorkingHoursList.LoadWorkingHoursToList("")
            '            End If
            '            MessageBox.Show(StrMsg, "Working Hours", MessageBoxButtons.OK, mms)
            '            btnClear.Focus()
            '        End If
            '    End If
            'Next
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Existing...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        CloseCon(Con)
    End Sub

    Private Sub LoadWorkingHoursToList(Find_ID As String)
        Try
            Dim dt As DataTable = GetDataFromDBToTable("SA_GetAllWorkingHoursToList",
                                                                New SqlParameter("@EmpIDList", Find_ID),
                                                                New SqlParameter("@ID", ""))
            With gvWorkingHours
                If dt.Rows.Count > 0 Then
                    gcWorkingHours.DataSource = dt
                    .PopulateColumns()
                    .Columns(0).Width = 50
                    .Columns(1).Width = 60
                    .Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    '.Columns("StaffID").Visible = False
                    .Columns("Condition").Visible = False
                    .Columns("TotalWorkingHour").Visible = False
                    .Columns("UserCreate").Visible = False
                    .Columns("DateCreate").Visible = False
                    .Columns("UserUpdate").Visible = False
                    .Columns("DateUpdate").Visible = False
                    .BestFitColumns()
                End If
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EnabledButtonSave(Optional txt As String = "&Save", Optional en As Boolean = True, Optional del As Boolean = False)
        btnSave.Text = txt
        btnSave.Enabled = en
        btnTrush.Enabled = del
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtSID.Text = ""
        ClearAllContent()
        btnClear.Enabled = False
        txtSID.Focus()
    End Sub

    Private Sub ClearAllContent()
        txtShiftNo.Text = "***"
        txtEmpID.Text = ""
        txtSName.Text = ""
        txtWorkingPeriod.Text = ""
        txtEmpStatus.Text = ""
        txtStartDate.Text = ""
        txtEndDate.Text = ""
        SetDefaultGroup(False)
        ClearToAddRecord()
        gcWorkingHours.DataSource = Nothing
        gvWorkingHours.Columns.Clear()
    End Sub

    Private Sub ShowUpdateFooterNote(Optional ByVal en As Boolean = True)
        If Not en Then
            txtUpdatedBy.Text = ""
            txtUpdatedDate.Text = ""
        End If
        txtUpdatedBy.Visible = en
        lblUpdatedBy.Visible = en
        txtUpdatedDate.Visible = en
        lblUpdatedDate.Visible = en
    End Sub

    Private Sub ShowAddFooterNote(Optional ByVal en As Boolean = True)
        If Not en Then
            txtCreatedBy.Text = ""
            txtCreatedDate.Text = ""
        End If

        lblCreatedBy.Visible = en
        txtCreatedBy.Visible = en
        lblCreatedDate.Visible = en
        txtCreatedDate.Visible = en
    End Sub

    Private Sub getFooterNote(useradd As String, dateadd As String, userupdate As String, dateupdate As String)
        If String.IsNullOrEmpty(useradd) OrElse String.IsNullOrEmpty(dateadd) Then
            ShowAddFooterNote(False)
        Else
            txtCreatedBy.Text = useradd
            txtCreatedDate.Text = dateadd
            ShowAddFooterNote()
        End If

        If String.IsNullOrEmpty(userupdate) OrElse String.IsNullOrEmpty(dateupdate) Then
            ShowUpdateFooterNote(False)
        Else
            txtUpdatedBy.Text = userupdate
            txtUpdatedDate.Text = dateupdate
            ShowUpdateFooterNote()
        End If
    End Sub


    Private Sub SetDefaultWorkingHour()
        teMFM1.EditValue = "07:30 AM"
        teMFM2.EditValue = "12:00 PM"
        teMFA1.EditValue = "01:30 PM"
        teMFA2.EditValue = "06:00 PM"
        teMFE1.EditValue = "12:00 AM"
        teMFE2.EditValue = "12:00 AM"

        teSAM1.EditValue = "08:00 AM"
        teSAM2.EditValue = "11:00 AM"
        teSAA1.EditValue = "12:00 AM"
        teSAA2.EditValue = "12:00 AM"
    End Sub

    Private Sub chkMF_CheckStateChanged(sender As Object, e As EventArgs) Handles chkMF.CheckStateChanged
        EnabledMF(CBool(chkMF.EditValue))
    End Sub

    Private Sub chkSaturday_CheckStateChanged(sender As Object, e As EventArgs) Handles chkSaturday.CheckStateChanged
        EnabledSA(CBool(chkSaturday.EditValue))
    End Sub

    Private Sub chkMFM_CheckStateChanged(sender As Object, e As EventArgs) Handles chkMFM.CheckStateChanged
        EnabledMFM(CBool(chkMFM.EditValue))
        'If rdoCondition.SelectedIndex = 2 AndAlso CBool(chkMFM.EditValue) = True Then
        '    chkMFA.Checked = False
        'End If
    End Sub

    Private Sub chkMFA_CheckStateChanged(sender As Object, e As EventArgs) Handles chkMFA.CheckStateChanged
        EnabledMFA(CBool(chkMFA.EditValue))
        'If rdoCondition.SelectedIndex = 2 AndAlso CBool(chkMFA.EditValue) = True Then
        '    chkMFM.Checked = False
        'End If
    End Sub

    Private Sub chkMFE_CheckStateChanged(sender As Object, e As EventArgs) Handles chkMFE.CheckStateChanged
        EnabledMFE(CBool(chkMFE.EditValue))
    End Sub

    Private Sub chkSAM_CheckStateChanged(sender As Object, e As EventArgs) Handles chkSAM.CheckStateChanged
        EnabledSAM(CBool(chkSAM.EditValue))
    End Sub

    Private Sub chkSAA_CheckStateChanged(sender As Object, e As EventArgs) Handles chkSAA.CheckStateChanged
        EnabledSAA(CBool(chkSAA.EditValue))
    End Sub

    Private Sub rdoCondition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdoCondition.SelectedIndexChanged

        chkMF.Checked = True
        chkMFA.Checked = True
        chkSaturday.Checked = True
        teMFA2.EditValue = "06:00 PM"

        If rdoCondition.SelectedIndex = 3 Then
            chkMF.Checked = False
            chkSaturday.Checked = False
        ElseIf rdoCondition.SelectedIndex = 1 Then
            chkSaturday.Checked = False
            chkMFA.Checked = True
            chkMFM.Checked = True
            teMFA2.EditValue = "05:00 PM"
        ElseIf rdoCondition.SelectedIndex = 2 Then
            chkMFM.Checked = True
            chkSaturday.Checked = False
            chkMFA.Checked = False
        End If

    End Sub

    Private Sub teMFM1_EditValueChanged(sender As Object, e As EventArgs) Handles teMFM1.EditValueChanged
        ComputeTotalWHMF()
    End Sub

    Private Sub teMFM2_EditValueChanged(sender As Object, e As EventArgs) Handles teMFM2.EditValueChanged
        ComputeTotalWHMF()
    End Sub

    Private Sub teMFA1_EditValueChanged(sender As Object, e As EventArgs) Handles teMFA1.EditValueChanged
        ComputeTotalWHMF()
    End Sub

    Private Sub teMFA2_EditValueChanged(sender As Object, e As EventArgs) Handles teMFA2.EditValueChanged
        ComputeTotalWHMF()
    End Sub

    Private Sub teMFE2_EditValueChanged(sender As Object, e As EventArgs) Handles teMFE2.EditValueChanged
        ComputeTotalWHMF()
    End Sub

    Private Sub teMFE1_EditValueChanged(sender As Object, e As EventArgs) Handles teMFE1.EditValueChanged
        ComputeTotalWHMF()
    End Sub

    Private Sub teSAM1_EditValueChanged(sender As Object, e As EventArgs) Handles teSAM1.EditValueChanged
        ComputeTotalWHSA()
    End Sub

    Private Sub teSAM2_EditValueChanged(sender As Object, e As EventArgs) Handles teSAM2.EditValueChanged
        ComputeTotalWHSA()
    End Sub

    Private Sub teSAA1_EditValueChanged(sender As Object, e As EventArgs) Handles teSAA1.EditValueChanged
        ComputeTotalWHSA()
    End Sub

    Private Sub teSAA2_EditValueChanged(sender As Object, e As EventArgs) Handles teSAA2.EditValueChanged
        ComputeTotalWHSA()
    End Sub

    Private Sub GetSearchWorkingHoursListByID(Find_ID As String)
        Try
            'open connection if close
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_GetWorkingHoursToList", Con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CardID", txtEmpID.Text.Trim)
            cmd.Parameters.AddWithValue("@ID", Find_ID)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            With ds.Tables(0)
                Dim i As Integer = .Rows.Count
                If i = 1 Then
                    EnabledButtonSave("&Update", True, True)
                    btnNew.Enabled = True
                    rdoCondition.EditValue = .Rows(0)("Condition").ToString
                    Dim EffectiveDate As String = .Rows(0)("EffectiveDate").ToString
                    If String.IsNullOrEmpty(EffectiveDate) Then
                        deEffectiveDate.DateTime = DateTime.Now
                    Else
                        deEffectiveDate.DateTime = Convert.ToDateTime(EffectiveDate)
                    End If
                    '''mon-fri
                    Dim MFM1 As String = .Rows(0)("M_TimeIn").ToString

                    If String.IsNullOrEmpty(MFM1) Then
                        teMFM1.EditValue = "07:30 AM"
                    Else
                        teMFM1.EditValue = DateTime.Parse(MFM1)
                    End If

                    Dim MFM2 As String = .Rows(0)("M_TimeOut").ToString

                    If String.IsNullOrEmpty(MFM2) Then
                        teMFM2.EditValue = "12:00 PM"
                    Else
                        teMFM2.EditValue = DateTime.Parse(MFM2)
                    End If

                    If String.IsNullOrEmpty(MFM1) OrElse MFM1 = "12:00 AM" OrElse String.IsNullOrEmpty(MFM2) OrElse MFM2 = "12:00 AM" Then
                        chkMFM.Checked = False
                    Else
                        chkMFM.Checked = True
                    End If

                    Dim MFA1 As String = .Rows(0)("A_TimeIn").ToString
                    If String.IsNullOrEmpty(MFA1) Then
                        teMFA1.EditValue = "01:30 PM"
                    Else
                        teMFA1.EditValue = DateTime.Parse(MFA1)
                    End If

                    Dim MFA2 As String = .Rows(0)("A_TimeOut").ToString
                    If String.IsNullOrEmpty(MFA2) Then
                        teMFA2.EditValue = "06:00 PM"
                    Else
                        teMFA2.EditValue = DateTime.Parse(MFA2)
                    End If

                    If String.IsNullOrEmpty(MFA1) OrElse MFA1 = "12:00 AM" OrElse String.IsNullOrEmpty(MFA2) OrElse MFA2 = "12:00 AM" Then
                        chkMFA.Checked = False
                    Else
                        chkMFA.Checked = True
                    End If

                    Dim MFE1 As String = .Rows(0)("E_TimeIn").ToString
                    If String.IsNullOrEmpty(MFE1) Then
                        teMFE1.EditValue = "12:00 AM"
                    Else
                        teMFE1.EditValue = DateTime.Parse(MFE1)
                    End If

                    Dim MFE2 As String = .Rows(0)("E_TimeOut").ToString
                    If String.IsNullOrEmpty(MFE2) Then
                        teMFE2.EditValue = "12:00 AM"
                    Else
                        teMFE2.EditValue = DateTime.Parse(MFE2)
                    End If

                    If String.IsNullOrEmpty(MFE1) OrElse MFE1 = "12:00 AM" OrElse String.IsNullOrEmpty(MFE2) OrElse MFE2 = "12:00 AM" Then
                        chkMFE.Checked = False
                    Else
                        chkMFE.Checked = True
                    End If

                    'saturday
                    Dim SAM1 As String = .Rows(0)("SM_TimeIn").ToString
                    If String.IsNullOrEmpty(SAM1) Then
                        teSAM1.EditValue = "08:00 AM"
                    Else
                        teSAM1.EditValue = DateTime.Parse(SAM1)
                    End If

                    Dim SAM2 As String = .Rows(0)("SM_TimeOut").ToString
                    If String.IsNullOrEmpty(SAM2) Then
                        teSAM2.EditValue = "11:00 AM"
                    Else
                        teSAM2.EditValue = DateTime.Parse(SAM2)
                    End If

                    If String.IsNullOrEmpty(SAM1) OrElse SAM1 = "12:00 AM" OrElse String.IsNullOrEmpty(SAM2) OrElse SAM2 = "12:00 AM" Then
                        chkSAM.Checked = False
                    Else
                        chkSAM.Checked = True
                    End If

                    Dim SAA1 As String = .Rows(0)("SA_TimeIn").ToString
                    If String.IsNullOrEmpty(SAA1) Then
                        teSAA1.EditValue = "02:00 PM"
                    Else
                        teSAA1.EditValue = DateTime.Parse(SAA1)
                    End If

                    Dim SAA2 As String = .Rows(0)("SA_TimeOut").ToString
                    If String.IsNullOrEmpty(SAA2) Then
                        teSAA2.EditValue = "05:00 PM"
                    Else
                        teSAA2.EditValue = DateTime.Parse(SAA2)
                    End If

                    If String.IsNullOrEmpty(SAA1) OrElse SAA1 = "12:00 AM" OrElse String.IsNullOrEmpty(SAA2) OrElse SAA2 = "12:00 AM" Then
                        chkSAA.Checked = False
                    Else
                        chkSAA.Checked = True
                    End If

                    ''-------------
                    Dim SUM1 As String = .Rows(0)("UM_TimeIn").ToString
                    If String.IsNullOrEmpty(SUM1) Then
                        teSUM1.EditValue = "08:00 AM"
                    Else
                        teSUM1.EditValue = DateTime.Parse(SUM1)
                    End If

                    Dim SUM2 As String = .Rows(0)("UM_TimeOut").ToString
                    If String.IsNullOrEmpty(SUM2) Then
                        teSUM2.EditValue = "11:00 AM"
                    Else
                        teSUM2.EditValue = DateTime.Parse(SUM2)
                    End If

                    If String.IsNullOrEmpty(SUM1) OrElse SAM1 = "12:00 AM" OrElse String.IsNullOrEmpty(SUM2) OrElse SUM2 = "12:00 AM" Then
                        chkSUM.Checked = False
                    Else
                        chkSUM.Checked = True
                    End If

                    Dim SUA1 As String = .Rows(0)("UA_TimeIn").ToString
                    If String.IsNullOrEmpty(SUA1) Then
                        teSUA1.EditValue = "02:00 PM"
                    Else
                        teSUA1.EditValue = DateTime.Parse(SUA1)
                    End If

                    Dim SUA2 As String = .Rows(0)("UA_TimeOut").ToString
                    If String.IsNullOrEmpty(SUA2) Then
                        teSUA2.EditValue = "05:00 PM"
                    Else
                        teSUA2.EditValue = DateTime.Parse(SUA2)
                    End If

                    If String.IsNullOrEmpty(SUA1) OrElse SUA1 = "12:00 AM" OrElse String.IsNullOrEmpty(SUA2) OrElse SUA2 = "12:00 AM" Then
                        chkSUA.Checked = False
                    Else
                        chkSUA.Checked = True
                    End If


                    Dim UserCreate As String = .Rows(0)("UserCreate").ToString
                    Dim DateCreate As String = .Rows(0)("DateCreate").ToString
                    Dim UserUpdate As String = .Rows(0)("UserUpdate").ToString
                    Dim DateUpdate As String = .Rows(0)("DateUpdate").ToString
                    getFooterNote(UserCreate, DateCreate, UserUpdate, DateUpdate)
                Else
                    XtraMessageBox.Show("Searching keyword: " + txtSID.Text.Trim + " doesnot exist on the target system.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtSID.Focus()
                End If
            End With

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + ". Please contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'close connection if open
        CloseCon(Con)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearToAddRecord()
        rdoCondition.Focus()
    End Sub

    Private Sub ClearToAddRecord()
        btnNew.Enabled = False
        txtShiftNo.Text = "***"
        rdoCondition.SelectedIndex = 0
        deEffectiveDate.DateTime = DateTime.Now
        EnabledButtonSave()
        chkMFM.Checked = True
        chkMFA.Checked = True
        chkSAM.Checked = True
        chkSAA.Checked = False
        SetDefaultWorkingHour()
        ShowUpdateFooterNote(False)
        ShowAddFooterNote(False)
    End Sub

    Private Sub btnSelectedList_Click(sender As Object, e As EventArgs) Handles btnSelectedList.Click
        frmEmployeeListSelection.meStaffSelection.Text = ""
        frmEmployeeListSelection.meName.Text = ""
        LoadFormDialog(frmEmployeeListSelection)
        If Not String.IsNullOrEmpty(tempIDList) Then
            SetDefaultGroup()
            btnClear.Enabled = True
            txtSID.Text = tempIDList
            txtEmpID.Text = tempIDList
            LoadWorkingHoursToList(tempIDList)
        End If
    End Sub

    Private Sub chkSunday_CheckStateChanged(sender As Object, e As EventArgs) Handles chkSunday.CheckStateChanged
        EnabledSU(CBool(chkSunday.EditValue))
    End Sub

    Private Sub SetDefaultGroup(Optional En As Boolean = True)
        If En Then
            txtSName.Text = "Group List"
            txtEmpStatus.Text = "Group List"
            txtWorkingPeriod.Text = "Group List"
            txtStartDate.Text = "Group List"
            txtEndDate.Text = "Group List"
        Else
            txtSName.Text = ""
            txtEmpStatus.Text = ""
            txtWorkingPeriod.Text = ""
            txtStartDate.Text = ""
            txtEndDate.Text = ""
        End If
    End Sub

    Private Sub chkSUM_CheckStateChanged(sender As Object, e As EventArgs) Handles chkSUM.CheckStateChanged
        EnabledSUM(CBool(chkSUM.EditValue))
    End Sub

    Private Sub teSUM1_EditValueChanged(sender As Object, e As EventArgs) Handles teSUM1.EditValueChanged
        ComputeTotalWHSU()
    End Sub

    Private Sub teSUM2_EditValueChanged(sender As Object, e As EventArgs) Handles teSUM2.EditValueChanged
        ComputeTotalWHSU()
    End Sub

    Private Sub teSUA1_EditValueChanged(sender As Object, e As EventArgs) Handles teSUA1.EditValueChanged
        ComputeTotalWHSU()
    End Sub

    Private Sub teSUA2_EditValueChanged(sender As Object, e As EventArgs) Handles teSUA2.EditValueChanged
        ComputeTotalWHSU()
    End Sub

    Private Sub txtSUWH_EditValueChanged(sender As Object, e As EventArgs) Handles txtSUWH.EditValueChanged
        TotalWorkingHour()
    End Sub

    Private Sub gcWorkingHours_MouseClick(sender As Object, e As MouseEventArgs) Handles gcWorkingHours.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            ppMenuPopup.ShowPopup(Me.bmMenuPopup, Control.MousePosition)
        End If
    End Sub

    Private Sub bbiEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiEdit.ItemClick
        Try
            With gvWorkingHours
                If .RowCount > 2 Then
                    XtraMessageBox.Show("You cannot change individual record.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rdoCondition.Focus()
                    Return
                End If

                txtShiftNo.Text = .GetRowCellValue(.FocusedRowHandle, "ID").ToString
                txtEmpID.Text = .GetRowCellValue(.FocusedRowHandle, "CardID").ToString
                txtSID.Text = .GetRowCellValue(.FocusedRowHandle, "CardID").ToString
                GetSearchWorkingHoursListByID(txtShiftNo.Text.Trim)
            End With
        Catch ex As Exception
            ClearToAddRecord()
            EnabledButtonSave()
            rdoCondition.Focus()
        End Try
    End Sub

    Private Sub txtMFWH_EditValueChanged(sender As Object, e As EventArgs) Handles txtMFWH.EditValueChanged
        TotalWorkingHour()
    End Sub

    Private Sub chkSUA_CheckStateChanged(sender As Object, e As EventArgs) Handles chkSUA.CheckStateChanged
        EnabledSUA(CBool(chkSUA.EditValue))
    End Sub

    Private Sub txtSAWH_EditValueChanged(sender As Object, e As EventArgs) Handles txtSAWH.EditValueChanged
        TotalWorkingHour()
    End Sub

    Private Sub txtSID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim Find_ID As String = txtSID.Text.Trim
            ClearAllContent()

            If String.IsNullOrEmpty(Find_ID) Then
                XtraMessageBox.Show("Please enter Staff ID before performing the operation.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSID.Focus()
                Return
            End If

            txtSID.Text = txtSID.Text.Trim.ToUpper
            SelectStaffRec(Find_ID)
        End If
    End Sub

    Private Sub SelectStaffRec(Find_ID As String)
        Try
            'open connection if close
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_GetEmployeeInfoForNewAdd", Con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ID", Find_ID)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            With ds.Tables(0)
                Dim i As Integer = .Rows.Count
                If i = 1 Then
                    EnabledButtonSave()
                    btnClear.Enabled = True
                    txtEmpID.Text = .Rows(0)("CardID").ToString
                    txtSName.Text = .Rows(0)("Name").ToString

                    Dim SDate As String = .Rows(0)("JoinDate").ToString
                    If String.IsNullOrEmpty(SDate) Then
                        txtStartDate.Text = "NA"
                    Else
                        txtStartDate.Text = DateTime.Parse(SDate).ToString("MMM. dd, yyyy")
                        deEffectiveDate.DateTime = Convert.ToDateTime(SDate)
                    End If

                    txtSName.ForeColor = Color.Green
                    txtEmpStatus.ForeColor = Color.Green
                    txtWorkingPeriod.ForeColor = Color.Green
                    txtStartDate.ForeColor = Color.Green
                    txtEndDate.ForeColor = Color.Green
                    Dim StopDate As String = .Rows(0)("StopDate").ToString
                    If String.IsNullOrEmpty(StopDate) Then
                        txtEndDate.Text = "NA"
                    Else
                        txtSName.ForeColor = Color.Red
                        txtEmpStatus.ForeColor = Color.Red
                        txtWorkingPeriod.ForeColor = Color.Red
                        txtStartDate.ForeColor = Color.Red
                        txtEndDate.ForeColor = Color.Red
                        txtEndDate.Text = DateTime.Parse(StopDate).ToString("MMM. dd, yyyy")
                    End If

                    txtWorkingPeriod.Text = GetWorkingPeriod(SDate, StopDate)
                    txtEmpStatus.Text = .Rows(0)("EmpStatus").ToString

                    LoadWorkingHoursToList(Find_ID)
                Else
                    XtraMessageBox.Show("Searching keyword: " + txtSID.Text.Trim + " doesnot exist on the target system. ", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtSID.Focus()
                End If
            End With

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message + ". Please contact System Administrator.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'close connection if open
        CloseCon(Con)
    End Sub

    Private Sub frmWorkingHours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoCompleteID(txtSID, "SA_GetCardIDByCompany")

        Dim DTConditionTypes As DataTable = GetDataFromDBToTable("SA_GetWorkingConditions")
        For i As Integer = 0 To DTConditionTypes.Rows.Count - 1
            rdoCondition.Properties.Items.Add(New RadioGroupItem(DTConditionTypes.Rows(i).Item("Code"), DTConditionTypes.Rows(i).Item("Condition").ToString))
        Next
        SetDefaultWorkingHour()
        deEffectiveDate.DateTime = DateTime.Now

        If isFomEmployeeInfo Then
            txtSID.Text = _ID
            txtEmpID.Text = _ID
            txtSName.Text = _Name
            txtWorkingPeriod.Text = _WorkingPeriod
            txtEmpStatus.Text = _EmpStatus
            txtStartDate.Text = _StartDate
            txtEndDate.Text = _StopDate
            deEffectiveDate.DateTime = Convert.ToDateTime(_StartDate)

            If Not String.IsNullOrEmpty(_ID) Then
                LoadWorkingHoursToList(_ID)
            End If
        End If
    End Sub

    Private Sub EnabledMF(Optional en As Boolean = True)
        chkMFM.Enabled = en
        chkMFA.Enabled = en
        chkMFE.Enabled = en
        chkMFM.Checked = en
        chkMFA.Checked = en

        If Not en AndAlso CBool(chkMFE.Checked) Then
            chkMFE.Checked = False
        End If
    End Sub

    Private Sub EnabledSA(Optional en As Boolean = True)
        chkSAM.Enabled = en
        chkSAA.Enabled = en
        chkSAM.Checked = en

        If Not en AndAlso CBool(chkSAA.Checked) Then
            chkSAA.Checked = False
        End If
    End Sub

    Private Sub EnabledSU(Optional en As Boolean = True)
        chkSUM.Enabled = en
        chkSUA.Enabled = en
        chkSUM.Checked = en

        If Not en AndAlso CBool(chkSUA.Checked) Then
            chkSUA.Checked = False
        End If
    End Sub

    Private Sub EnabledMFM(Optional en As Boolean = True)
        teMFM1.Enabled = en
        teMFM2.Enabled = en
        If en = False Then
            teMFM1.EditValue = "12:00 AM"
            teMFM2.EditValue = "12:00 AM"
        Else
            teMFM1.EditValue = "07:30 AM"
            teMFM2.EditValue = "12:00 PM"
        End If
    End Sub

    Private Sub EnabledMFA(Optional en As Boolean = True)
        teMFA1.Enabled = en
        teMFA2.Enabled = en

        If en = False Then
            teMFA1.EditValue = "12:00 AM"
            teMFA2.EditValue = "12:00 AM"
        Else
            teMFA1.EditValue = "01:30 PM"
            teMFA2.EditValue = "06:00 PM"
        End If
    End Sub

    Private Sub EnabledMFE(Optional en As Boolean = True)
        teMFE1.Enabled = en
        teMFE2.Enabled = en

        If en = False Then
            teMFE1.EditValue = "12:00 AM"
            teMFE2.EditValue = "12:00 AM"
        End If
    End Sub

    Private Sub EnabledSAM(Optional en As Boolean = True)
        teSAM1.Enabled = en
        teSAM2.Enabled = en
        If en = False Then
            teSAM1.EditValue = "12:00 AM"
            teSAM2.EditValue = "12:00 AM"
        Else
            teSAM1.EditValue = "08:00 AM"
            teSAM2.EditValue = "11:00 AM"
        End If
    End Sub

    Private Sub EnabledSUM(Optional en As Boolean = True)
        teSUM1.Enabled = en
        teSUM2.Enabled = en
        If en = False Then
            teSUM1.EditValue = "12:00 AM"
            teSUM2.EditValue = "12:00 AM"
        Else
            teSUM1.EditValue = "08:00 AM"
            teSUM2.EditValue = "11:00 AM"
        End If
    End Sub

    Private Sub EnabledSUA(Optional en As Boolean = True)
        teSUA1.Enabled = en
        teSUA2.Enabled = en

        If en = False Then
            teSUA1.EditValue = "12:00 AM"
            teSUA2.EditValue = "12:00 AM"
        Else
            teSUA1.EditValue = "02:00 PM"
            teSUA2.EditValue = "05:00 PM"
        End If
    End Sub

    Private Sub EnabledSAA(Optional en As Boolean = True)
        teSAA1.Enabled = en
        teSAA2.Enabled = en

        If en = False Then
            teSAA1.EditValue = "12:00 AM"
            teSAA2.EditValue = "12:00 AM"
        Else
            teSAA1.EditValue = "02:00 PM"
            teSAA2.EditValue = "05:00 PM"
        End If
    End Sub

    Private Sub ComputeTotalWHMF()
        If Not CBool(chkMFM.Checked) Then
            MFM1 = "12:00 AM"
            MFM2 = "12:00 AM"
        Else
            MFM1 = teMFM1.Text
            MFM2 = teMFM2.Text
        End If

        If Not CBool(chkMFA.Checked) Then
            MFA1 = "12:00 AM"
            MFA2 = "12:00 AM"
        Else
            MFA1 = teMFA1.Text
            MFA2 = teMFA2.Text
        End If

        If Not CBool(chkMFE.Checked) Then
            MFE1 = "12:00 AM"
            MFE2 = "12:00 AM"
        Else
            MFE1 = teMFE1.Text
            MFE2 = teMFE2.Text
        End If

        txtMFWH.Text = GetTimeInHours(MFM1, MFM2, MFA1, MFA2, MFE1, MFE2)
    End Sub

    Private Sub ComputeTotalWHSA()
        If Not CBool(chkSAM.Checked) Then
            SAM1 = "12:00 AM"
            SAM2 = "12:00 AM"
        Else
            SAM1 = teSAM1.Text
            SAM2 = teSAM2.Text
        End If

        If Not CBool(chkSAA.Checked) Then
            SAA1 = "12:00 AM"
            SAA2 = "12:00 AM"
        Else
            SAA1 = teSAA1.Text
            SAA2 = teSAA2.Text
        End If

        SAE1 = "12:00 AM"
        SAE2 = "12:00 AM"

        txtSAWH.Text = GetTimeInHours(SAM1, SAM2, SAA1, SAA2, SAE1, SAE2)
    End Sub

    Private Sub ComputeTotalWHSU()
        If Not CBool(chkSUM.Checked) Then
            SUM1 = "12:00 AM"
            SUM2 = "12:00 AM"
        Else
            SUM1 = teSAM1.Text
            SUM2 = teSAM2.Text
        End If

        If Not CBool(chkSUA.Checked) Then
            SUA1 = "12:00 AM"
            SUA2 = "12:00 AM"
        Else
            SUA1 = teSUA1.Text
            SUA2 = teSUA2.Text
        End If

        SUE1 = "12:00 AM"
        SUE2 = "12:00 AM"

        txtSUWH.Text = GetTimeInHours(SUM1, SUM2, SUA1, SUA2, SUE1, SUE2)
    End Sub


    Private Sub TotalWorkingHour()
        Dim MFWH, SAWH, SUWH As Double
        If Not String.IsNullOrEmpty(txtMFWH.Text.Trim) Then
            MFWH = CDbl(txtMFWH.Text)
        End If
        If Not String.IsNullOrEmpty(txtSAWH.Text.Trim) Then
            SAWH = CDbl(txtSAWH.Text)
        End If
        If Not String.IsNullOrEmpty(txtSUWH.Text.Trim) Then
            SUWH = CDbl(txtSUWH.Text)
        End If
        TotalWH = MFWH * 5 + SAWH + SUWH
        txtTWH.Text = TotalWH.ToString
    End Sub
End Class