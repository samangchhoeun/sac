Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmEmployeeListSelection

    Dim StrEmpID As String = "", StrEmpName As String = ""

    Private Sub btnAddToList_Click(sender As Object, e As EventArgs) Handles btnAddToList.Click
        ValidationEmployeeIDList()
    End Sub

    Public Function GetEmployeeDetailsID(_CardID As String) As List(Of Object)
        Dim lstObj As New List(Of Object)

        Dim dataList As DataTable = GetDataFromDBToTable("SA_IsExistEmployeeDatails", New SqlParameter("@CardID", _CardID))
        If dataList.Rows.Count = 1 Then
            lstObj.Add(dataList.Rows(0)("CardID").ToString())
            lstObj.Add(dataList.Rows(0)("Name").ToString())
        End If

        Return lstObj

    End Function


    'Public Function GetEmployeeIDIFExists(_CardID As String) As String
    '    Dim TempID As String = ""

    '    Try
    '        OpenCon(Con)
    '        Dim cmd As New SqlCommand("SA_IsExistEmployeeID", Con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        With cmd.Parameters
    '            .AddWithValue("@CardID", _CardID)
    '            .Add("@EmpID", SqlDbType.NVarChar, 10)
    '            cmd.Parameters("@EmpID").Direction = ParameterDirection.Output
    '        End With
    '        cmd.ExecuteNonQuery()
    '        cmd.Dispose()

    '        If Not String.IsNullOrEmpty(cmd.Parameters("@EmpID").Value.ToString) Then
    '            TempID = cmd.Parameters("@EmpID").Value.ToString
    '        End If

    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    '    CloseCon(Con)
    '    Return TempID
    'End Function

    'Public Function GetEmployeeNameIFExists(EmpID As String) As String
    '    Dim TempName As String = ""

    '    Try
    '        OpenCon(Con)
    '        Dim cmd As New SqlCommand("SA_IsEmployeeExistGetName", Con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        With cmd.Parameters
    '            .AddWithValue("@StaffID", EmpID)
    '            .Add("@Name", SqlDbType.NVarChar, 100)
    '            cmd.Parameters("@Name").Direction = ParameterDirection.Output
    '        End With
    '        cmd.ExecuteNonQuery()
    '        cmd.Dispose()

    '        If Not String.IsNullOrEmpty(cmd.Parameters("@Name").Value.ToString) Then
    '            TempName = cmd.Parameters("@Name").Value.ToString
    '        End If

    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    '    CloseCon(Con)
    '    Return TempName
    'End Function

    Private Sub meStaffSelection_DoubleClick(sender As Object, e As EventArgs) Handles meStaffSelection.DoubleClick
        meStaffSelection.ReadOnly = False
    End Sub

    Private Sub ValidationEmployeeIDList()
        If String.IsNullOrEmpty(meStaffSelection.Text.Trim) Then
            XtraMessageBox.Show("Please enter Employee IDs before performing the operation.", "No Employee Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            meStaffSelection.Focus()
            Return
        End If

        Dim StaffID As String = meStaffSelection.Text.Trim
        Dim StaffIDList As String() = StaffID.Split(Splits, StringSplitOptions.RemoveEmptyEntries)

        Dim item(StaffIDList.Count), iName(StaffIDList.Count) As String

        Dim i As Integer = 0
        For Each t As String In StaffIDList
            'If Not String.IsNullOrEmpty(GetEmployeeIDIFExists(Trim(t))) Then
            If GetEmployeeDetailsID(Trim(t)).Count > 0 Then
                'StrEmpID += GetEmployeeIDIFExists(Trim(t)) + vbNewLine
                item(i) = GetEmployeeDetailsID(Trim(t))(0).ToString
                StrEmpID = String.Join(", ", item)
                'Dim MyChar() As Char = {","c, " "c, "|"c, ";"c, "-"c, "."c, "/"c, "|"c, "\"c}
                StrEmpID = StrEmpID.TrimEnd(MyChar)

                iName(i) = GetEmployeeDetailsID(Trim(t))(1).ToString
                StrEmpName = String.Join(", ", iName)
                'Dim MyCharName() As Char = {","c, " "c, "|"c, ";"c, "-"c, "."c, "/"c, "|"c, "\"c}
                StrEmpName = StrEmpName.TrimEnd(MyChar)
                i += 1
            End If
        Next

        'XtraMessageBox.Show(StrEmpID)
        meStaffSelection.ReadOnly = True
        meStaffSelection.Text = StrEmpID
        meName.Text = StrEmpName
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ValidationEmployeeIDList()

        If Not String.IsNullOrEmpty(StrEmpID) Then
            detected = XtraMessageBox.Show("Do you want to confirm the process for employee " + StrEmpName + "?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If detected = DialogResult.Yes Then
                tempIDList = StrEmpID
                Dispose()
                Hide()
            End If
        End If
    End Sub
End Class