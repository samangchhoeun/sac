Imports System.Data.SqlClient
Imports System.Threading
Imports System.Threading.Tasks

Public Class frmWelcomePage
    Private Run As Int32 = 0
    Dim token As CancellationToken
    Dim ct As CancellationTokenSource
    Dim _Interval As Integer = 100

    Private Async Sub frmWelcomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadLogoImage()
        lblApplication.Text = Application.ProductName
        lblVersion.Text = "Version: " + systemVersion
        Await Tasks.Task.Run(Sub() ShowProgressBar())
        'Await Task.Delay(7000)
        'frmMainProject.Show()
        'Dispose()
    End Sub

    'Private Function LoadLogoImage() As Image
    '    Dim Img As Image = Nothing
    '    Try
    '        Dim dtData As DataTable = GetDataFromDBToTable("SA_GetLogoImage", New SqlParameter("@ImageType", "Clinic Logo"))
    '        With dtData
    '            If .Rows.Count = 1 Then
    '                Dim imgSrc As Byte() = TryCast(.Rows(0)("Photo"), Byte())
    '                Img = byteArrayToImage(imgSrc)
    '            End If
    '        End With
    '    Catch ex As Exception

    '    End Try

    '    Return Img
    'End Function


    Private Sub ShowProgressBar()
        Dim outputResult As String = ""

        'Dim Watch As New Stopwatch
        Try
            ct = New CancellationTokenSource
            token = ct.Token
            Dim Completed As Integer
            If _Interval > 0 Then
                'Watch = Stopwatch.StartNew
                For Completed = 0 To _Interval
                    If (token.IsCancellationRequested) Then token.ThrowIfCancellationRequested()
                    'Dim ts As TimeSpan = TimeSpan.FromMilliseconds(Watch.ElapsedMilliseconds)
                    'lblPercent.Text = String.Format("Time elipsed: {0:D2}h {1:D2}m {2:D2}s", ts.Hours, ts.Minutes, ts.Seconds)            
                    UpdateProgress(Completed)
                    Thread.Sleep(40)
                    Completed += 1
                Next
            End If
            outputResult = "Completed!"
        Catch cancel As OperationCanceledException
            outputResult = "User cancelled!"
        Catch ex As Exception
            outputResult = "Error occurred!"
        Finally
            Invoke(Sub()
                       lblPercent.Text = "Completed!"
                       lblPercent.Refresh()
                       'Watch.Stop()
                       Thread.Sleep(300)
                       frmMainProject.Show()
                       Dispose()
                   End Sub)
            'Dim ts As TimeSpan = TimeSpan.FromMilliseconds(Watch.ElapsedMilliseconds)
            'lblPercent.Text = String.Format("Time elipsed: {0:D2}h {1:D2}m {2:D2}s", ts.Hours, ts.Minutes, ts.Seconds)            
        End Try
    End Sub

    Private Sub UpdateProgress(Value As Integer)
        BeginInvoke(Sub()
                        Dim Percentage As Double = CDbl(Value / _Interval) * 100.0
                        pbcStatus.EditValue = Percentage
                        lblPercent.Text = "Loading " + Percentage.ToString("#0.##") + "%"
                    End Sub)
    End Sub

    Private Sub frmWelcomePage_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class