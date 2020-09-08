Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmBMICalculator
    Private Sub frmBMICalculator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBMICategories()
    End Sub

    Public Sub LoadBMICategories()
        Try
            Dim dtData As DataTable = GetDataFromDBToTable("SA_GetBMICategories", New SqlParameter("@Score", 0))
            If dtData.Rows.Count > 0 Then
                gcData.DataSource = dtData
                With gvData
                    .PopulateColumns()
                    .BestFitColumns()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtHeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHeight.KeyPress
        ValidNumber(sender, e)
    End Sub

    Private Sub txtWeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWeight.KeyPress
        ValidDecimal(sender, e)
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtHeight.Text = ""
        txtWeight.Text = ""
        lblYourBMI.Text = "Your BMI"
        gvData.FocusedRowHandle = 0
        txtHeight.Focus()
    End Sub

    Friend Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        If String.IsNullOrEmpty(txtHeight.Text.Trim) OrElse String.IsNullOrEmpty(txtWeight.Text.Trim) Then
            XtraMessageBox.Show("Please enter your information", "Your BMI Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHeight.Focus()
            Return
        End If
        Try
            Dim TotalBMI As Double = 0.0
            TotalBMI = CDbl(txtWeight.Text.Trim) / ((CDbl(txtHeight.Text.Trim) / 100.0) * (CDbl(txtHeight.Text.Trim) / 100.0))
            Dim Result As String = ""
            Dim ID As Integer = 0
            Dim dtBMI As DataTable = GetDataFromDBToTable("SA_GetBMICategories", New SqlParameter("@Score", TotalBMI))
            With dtBMI
                If .Rows.Count = 1 Then
                    Result = ", " & .Rows(0)("Classification").ToString
                    ID = CInt(.Rows(0)("ID"))
                End If
            End With

            lblYourBMI.Text = "Your BMI : " & Format(TotalBMI, "#0.00") & Result
            LoadBMICategoriesResult(ID)
            btnReset.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Friend Sub LoadBMICategoriesResult(_ID As Integer)
        Dim dtData As DataTable = GetDataFromDBToTable("SA_GetBMICategories", New SqlParameter("@Score", 0))
        If dtData.Rows.Count > 0 Then
            gcData.DataSource = dtData
            With gvData
                .PopulateColumns()
                If _ID > 0 Then
                    For i As Integer = 0 To .RowCount - 1
                        If CInt(.GetDataRow(i).Item("ID")) = _ID Then .FocusedRowHandle = i
                    Next
                End If
                .Columns("ID").Visible = False
                .BestFitColumns()
            End With
        End If
    End Sub


    Private Sub btnBMIChart_Click(sender As Object, e As EventArgs) Handles btnBMIChart.Click
        LoadForm(frmBMIChart)
        txtHeight.Focus()
    End Sub

    Private Sub txtWeight_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWeight.KeyDown
        If e.KeyCode = Keys.Enter Then btnCalculate_Click(sender, e)
    End Sub

    Private Sub txtHeight_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHeight.KeyDown
        If e.KeyCode = Keys.Enter Then txtWeight.Focus()
    End Sub
End Class