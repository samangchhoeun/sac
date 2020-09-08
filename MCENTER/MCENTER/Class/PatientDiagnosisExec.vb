Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper
Imports DapperParameters

Public Class PatientDiagnosisExec
    Public Shared Sub InsertDxDiagnosis(records As List(Of PatientDiagnosis), _PatientCode As String, _VisitCode As Integer, _ClinicID As Integer, _PTComplaint As String, _DRProgressNote As String)
        Using conn As IDbConnection = New SqlConnection(Con.ConnectionString)
            Try
                Dim params As New DynamicParameters
                params.Add("@PatientCode", _PatientCode)
                params.Add("@VisitCode", _VisitCode)
                params.Add("@VisitedDoctor", LogUserNo)
                params.Add("@ClinicID", _ClinicID)
                params.Add("@PTComplaint", _VisitCode)
                params.Add("@DRProgressNote", _VisitCode)
                params.Add("@User", LogUserNo)
                params.AddTable("@DxInfo", "PatientDiagnosis", records)
                conn.Execute("MJQEWarehouse.dbo.SAC_BulkInsertDx", params, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                Throw ex
            End Try
        End Using
    End Sub

    Public Shared Async Function InsertDxDiagnosisAsync(records As List(Of PatientDiagnosis), _PatientCode As String, _VisitCode As Integer, _ClinicID As Integer, _PTComplaint As String, _DRProgressNote As String) As Task
        Using conn As IDbConnection = New SqlConnection(Con.ConnectionString)
            Try
                Dim params As New DynamicParameters
                params.Add("@PatientCode", _PatientCode)
                params.Add("@VisitCode", _VisitCode)
                params.Add("@VisitedDoctor", LogUserNo)
                params.Add("@ClinicID", _ClinicID)
                params.Add("@PTComplaint", _VisitCode)
                params.Add("@DRProgressNote", _VisitCode)
                params.Add("@User", LogUserNo)
                params.AddTable("@DxInfo", "PatientDiagnosis", records)
                Await conn.ExecuteAsync("MJQEWarehouse.dbo.SAC_BulkInsertDx", params, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                Throw ex
            End Try
        End Using
    End Function
End Class
