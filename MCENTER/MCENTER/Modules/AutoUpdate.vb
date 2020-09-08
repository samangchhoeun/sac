Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class AutoUpdate
    Public Function IsRequiredUpdate() As Boolean
        Dim IsRequired As Boolean = False
        Dim Key As String = "&**#@!" ' any unique sequence of characters
        If InStr(Microsoft.VisualBasic.Command(), Key) > 0 Then
            Try
                ' try to delete the AutoUpdate program, 
                ' since it is not needed anymore
                System.IO.File.Delete(Application.StartupPath & "\AutouUpdate.exe")
            Catch ex As Exception
                XtraMessageBox.Show("Coud not remove the old version of the application." + vbNewLine + ex.Message, "Warining!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
            ' return false means that no update is needed
        Else
            Try
                'open connection if close
                OpenCon(Con)
                Dim cmd As New SqlCommand("SA_CheckAutoUpdateApp", Con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@AppName", Application.ProductName)
                cmd.Parameters.AddWithValue("@Version", systemVersion)
                cmd.Parameters.Add("@IsNewVersion", SqlDbType.NVarChar, 20)
                cmd.Parameters("@IsNewVersion").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()


                Dim LastVersion As String = cmd.Parameters("@IsNewVersion").Value.ToString()
                If Not LastVersion = "0" Then
                    IsRequired = True
                    latestAppVersion = LastVersion
                End If
                cmd.Parameters.Clear()
                cmd.Dispose()
            Catch ex As Exception
                XtraMessageBox.Show("There was a problem runing the Auto Update." + vbNewLine + "Please see your system administrator." + vbNewLine + ex.Message, "Warining!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
        'close connection if open
        CloseCon(Con)

        Return IsRequired
    End Function

    Public Function RequiredUpdateAppVer() As Boolean
        Dim IsRequired As Boolean = False
        Try
            'open connection if close
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_RequiredUpdateAppVer", Con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AppName", Application.ProductName)
            cmd.Parameters.AddWithValue("@Version", systemVersion)
            cmd.Parameters.Add("@IsNewVersion", SqlDbType.NVarChar, 20)
            cmd.Parameters("@IsNewVersion").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 50)
            cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()

            Dim LastVersion As String = cmd.Parameters("@IsNewVersion").Value.ToString()
            appVersionMsg = cmd.Parameters("@Msg").Value.ToString()
            If Not LastVersion = "0" Then
                IsRequired = True
                newAppVersion = LastVersion
            End If
            cmd.Parameters.Clear()
            cmd.Dispose()

        Catch ex As Exception
            XtraMessageBox.Show("There was a problem runing the Auto Update." + vbNewLine + "Please see your system administrator." + vbNewLine + ex.Message, "Warining!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        'close connection if open
        CloseCon(Con)
        Return IsRequired
    End Function

    Public Function ProcessUpdate(ByRef CommandLine As String, ByVal RemotePath As String) As Boolean
        Dim Key As String = "&**#@!" ' any unique sequence of characters
        ' the file with the update information
        Dim sfile As String = "LogUpdateConfig.dll"
        ' the Assembly name 
        Dim AssemblyName As String = System.Reflection.Assembly.GetEntryAssembly.GetName.Name
        ' where are the files for a specific system
        Dim RemoteUri As String = RemotePath & "/" & AssemblyName & "/"
        'Dim RemoteUri As String = RemotePath & AssemblyName & "/"
        ' clean up the command line getting rid of the key
        CommandLine = Replace(Microsoft.VisualBasic.Command(), Key, "")
        ' Verify if was called by the autoupdate
        If InStr(Microsoft.VisualBasic.Command(), Key) > 0 Then
            Try
                ' try to delete the AutoUpdate program, 
                ' since it is not needed anymore
                System.IO.File.Delete(Application.StartupPath & "\AutoUpdate.exe")
            Catch ex As Exception
            End Try
            ' return false means that no update is needed
            Return False
        Else
            ' was called by the user
            Dim ret As Boolean = False ' Default - no update needed
            Try
                Dim myWebClient As New System.Net.WebClient 'the webclient
                ' Download the update info file to the memory, 
                ' read and close the stream
                Dim file As New System.IO.StreamReader(
                    myWebClient.OpenRead(RemoteUri & sfile), True)
                Dim Contents As String = file.ReadToEnd()
                file.Close()
                ' if something was read
                If Contents <> "" Then
                    ' Break the contents 
                    Dim x() As String = Split(Contents, "|")
                    ' the first parameter is the version. if it's 
                    ' greater then the current version starts the 
                    ' update process
                    ' I ignore this because the file version is 
                    ' already checked with database

                    ' assembly the parameter to be passed to the auto 
                    ' update program
                    ' x(1) is the files that need to be 
                    ' updated separated by "?"
                    Dim arg As String = Application.ExecutablePath & "|" &
                                RemoteUri & "|" & x(1) & "|" & Key & "|" &
                                Microsoft.VisualBasic.Command()
                    ' Download the auto update program to the application 
                    ' path, so you always have the last version runing
                    Dim localautoupdate As String = Application.StartupPath & "\AutoUpdate.exe"
                    If Not My.Computer.FileSystem.FileExists(localautoupdate) Then
                        myWebClient.DownloadFile(RemotePath & "AutoUpdate.exe", localautoupdate)
                    End If

                    ' Call the auto update program with all the parameters
                    System.Diagnostics.Process.Start(localautoupdate, arg)
                    ' return true - auto update in progress
                    ret = True
                End If
            Catch ex As Exception
                ' if there is an error return true, 
                ' what means that the application
                ' should be closed
                ret = True
                ' something went wrong... 
                XtraMessageBox.Show("There was a problem runing the Auto Update for the new version." + vbNewLine + ex.Message, "Warining!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ret = False
            End Try
            Return ret
        End If
    End Function
End Class
