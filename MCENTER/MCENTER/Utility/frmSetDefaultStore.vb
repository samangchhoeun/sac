Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmSetDefaultStore
    Public _IsDefaultOpen As Boolean = True
    Private configureDataAccess As IConfigurationDataAccess(Of ClinicConfiguration)

    Private Sub frmCampusSetup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub frmCampusSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStoreToList()
        If _IsDefaultOpen Then
            pcMessage.Visible = False
        Else
            pcMessage.Visible = True
        End If
    End Sub

    Private Sub LoadStoreToList()
        Try
            GetDataToComboBoxWithParam(lueClinic, "SA_GetClinicByID", "ClinicID", "ClinicEn", New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
            If Not IsNothing(ConfigClinic) Then
                lueClinic.EditValue = ConfigClinic.ClinicID
                GetDataToComboBoxWithParam(lueBuilding, "SA_GetBuildingByID", "BuildingID", "Acronym", New SqlParameter("@ClinicID", ConfigClinic.ClinicID), New SqlParameter("@ID", 0), New SqlParameter("@isList", 1))
                lueBuilding.EditValue = ConfigClinic.BuildingID
            Else
                lueClinic.EditValue = -1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lueCampus_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueClinic.Closed
        LoadBuildingToList(CInt(lueClinic.EditValue))
    End Sub

    Private Sub LoadBuildingToList(_StoreID As Integer)
        Try
            If _StoreID <> 0 Then
                GetDataToComboBoxWithParam(lueBuilding, "SA_GetBuildingByID", "BuildingID", "Acronym", New SqlParameter("@ClinicID", _StoreID), New SqlParameter("@ID", 0))
                lueBuilding.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lueBuilding_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles lueBuilding.Closed
        btnSave.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If CInt(lueClinic.EditValue) <= 0 Or CInt(lueBuilding.EditValue) <= 0 Then
            XtraMessageBox.Show("Please select clinic and building.", "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lueClinic.Focus()
            Return
        End If

        Try
            Dim Config As New ClinicConfiguration
            With Config
                .ClinicID = CInt(lueClinic.EditValue)
                .Clinic = lueClinic.Text.Trim
                .BuildingID = CInt(lueBuilding.EditValue)
                .Building = lueBuilding.Text.Trim
                .UserCreate = AccountName
                .DateCreate = Now.ToString
            End With

            configureDataAccess = New ConfigurationDataAccess(Of ClinicConfiguration)(StoreConfigPath)
            configureDataAccess.Save(Config)

            XtraMessageBox.Show("Clinic Configuration was successfully saved. Application will auto restart.", "Save configuration", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Process.Start(Application.ExecutablePath)
            Application.Exit()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Fail save configuration", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub pcMessage_MouseClick(sender As Object, e As MouseEventArgs) Handles pcMessage.MouseClick
        pcMessage.Visible = False
    End Sub

    Private Sub lcClickHere_MouseClick(sender As Object, e As MouseEventArgs) Handles lcClickHere.MouseClick
        pcMessage.Visible = False
    End Sub
End Class