Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports DevExpress.XtraEditors

Public Class FTPClient
    Public Property ID As Integer
    Public Property FtpUsername As String
    Public Property FtpPassword As String
    Public Property FtpAddress As String
    Public Property FtpGroup As Integer
    Public Property Remark As String


    Public Function GetFTPDefaultConfiguration(ByVal _dtFTPInfo As DataTable) As FTPClient
        Dim _ObjFTP As New FTPClient

        Try
            If _dtFTPInfo.Rows.Count > 0 Then
                With _ObjFTP
                    Try
                        .ID = CInt(_dtFTPInfo.Rows(0)("ID").ToString)
                        .FtpAddress = _dtFTPInfo.Rows(0)("FTPAddress").ToString
                        .FtpUsername = _dtFTPInfo.Rows(0)("FTPUsername").ToString
                        .FtpPassword = _dtFTPInfo.Rows(0)("FTPPassword").ToString
                        .FtpGroup = CInt(_dtFTPInfo.Rows(0)("FTPGroup").ToString)
                        .Remark = _dtFTPInfo.Rows(0)("Remark").ToString
                    Catch ex As Exception
                        .ID = 0
                        .FtpAddress = ""
                        .FtpUsername = ""
                        .FtpPassword = ""
                        .FtpGroup = -1
                        .Remark = ""
                    End Try
                End With
            End If
        Catch ex As Exception
            ErrorLog.WriteLog("Get FTP Configuration", ex.Message)
        End Try

        Return _ObjFTP
    End Function

    Public Sub FTPDownloadFile(ByVal downloadpath As String, ByVal ftpuri As String)
        Dim _dtFTPInfo As DataTable = GetDataFromDBToTable("SA_GetFTPSettings",
                                                          New SqlParameter("@ID", 1),
                                                          New SqlParameter("@Flag", 1),
                                                          New SqlParameter("@KC", SAC))
        Dim _ftpClient As New FTPClient
        _ftpClient = GetFTPDefaultConfiguration(_dtFTPInfo)

        Try
            'Create a WebClient.
            Dim request As New WebClient()

            ' Confirm the Network credentials based on the user name and password passed in.
            request.Credentials = New NetworkCredential(_ftpClient.FtpUsername, _ftpClient.FtpPassword)

            'Read the file data into a Byte array
            Dim bytes() As Byte = request.DownloadData(ftpuri)

            '  Create a FileStream to read the file into
            Dim DownloadStream As FileStream = IO.File.Create(downloadpath)
            '  Stream this data into the file
            DownloadStream.Write(bytes, 0, bytes.Length)
            '  Close the FileStream
            DownloadStream.Close()

        Catch ex As Exception
            XtraMessageBox.Show("Error: " + ex.Message)
            Exit Sub
        End Try

        'XtraMessageBox.Show("Process Complete!")
    End Sub



    Public Function IfNotFTPFolderCreate(ByVal _newFolders As String) As Boolean
        Dim exito As Boolean = True
        Dim lstFolders As String() = _newFolders.Split("/"c)
        Dim pathFTP As String = ""
        Try
            Dim _dtFTPInfo As DataTable = GetDataFromDBToTable("SA_GetFTPSettings",
                                                      New SqlParameter("@ID", 1),
                                                      New SqlParameter("@Flag", 1),
                                                      New SqlParameter("@KC", SAC))
            If _dtFTPInfo.Rows.Count > 0 Then
                Dim _ftpClient As FTPClient = GetFTPDefaultConfiguration(_dtFTPInfo)
                pathFTP = _ftpClient.FtpAddress
                Dim creds As NetworkCredential = New NetworkCredential(_ftpClient.FtpUsername, _ftpClient.FtpPassword)

                For Each fol As String In lstFolders
                    If fol <> "" Then
                        Try
                            pathFTP += "/" + fol
                            Dim requestDir As FtpWebRequest = CType(FtpWebRequest.Create(New Uri(pathFTP)), FtpWebRequest)
                            requestDir.Method = WebRequestMethods.Ftp.MakeDirectory
                            requestDir.Credentials = creds
                            requestDir.UsePassive = True
                            requestDir.UseBinary = True
                            requestDir.KeepAlive = False

                            Dim response As FtpWebResponse = CType(requestDir.GetResponse(), FtpWebResponse)
                            Dim ftpStream As Stream = response.GetResponseStream()
                            ftpStream.Close()
                            response.Close()
                        Catch ex As WebException
                            Dim response As FtpWebResponse = CType(ex.Response(), FtpWebResponse)
                            If Not response.StatusCode = FtpStatusCode.ActionNotTakenFileUnavailableOrBusy Then exito = False
                            response.Close()
                        End Try
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

        Return exito
    End Function

    Public Function IfFtpFilePathNotExists(Optional ByVal fileUri As String = "") As Boolean
        Dim IsExisted As Boolean = False

        Try
            Dim _dtFTPInfo As DataTable = GetDataFromDBToTable("SA_GetFTPSettings",
                                                          New SqlParameter("@ID", 1),
                                                          New SqlParameter("@Flag", 1),
                                                          New SqlParameter("@KC", SAC))
            If _dtFTPInfo.Rows.Count > 0 Then
                Dim _ftpClient As FTPClient = GetFTPDefaultConfiguration(_dtFTPInfo)

                Dim request As FtpWebRequest = CType(WebRequest.Create(_ftpClient.FtpAddress + fileUri), FtpWebRequest)
                request.Credentials = New NetworkCredential(_ftpClient.FtpUsername, _ftpClient.FtpPassword)
                request.Method = WebRequestMethods.Ftp.GetFileSize
                Try
                    Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                    ' THE FILE EXISTS
                Catch ex As WebException
                    Dim response As FtpWebResponse = CType(ex.Response, FtpWebResponse)
                    If FtpStatusCode.ActionNotTakenFileUnavailable = response.StatusCode Then
                        ' THE FILE DOES NOT EXIST
                        IsExisted = True
                    End If
                End Try
            End If

        Catch ex As Exception

        End Try

        Return IsExisted
    End Function


    Public Function CheckFTPConnection(_ID As Integer, Optional _Flag As Integer = 0) As Boolean
        Dim IsExisted As Boolean = False

        Try
            Dim _dtFTPInfo As DataTable = GetDataFromDBToTable("SA_GetFTPSettings", New SqlParameter("@ID", _ID), New SqlParameter("@Flag", _Flag), New SqlParameter("@KC", SAC))
            If _dtFTPInfo.Rows.Count = 1 Then
                Dim _ftpClient As FTPClient = GetFTPDefaultConfiguration(_dtFTPInfo)
                Dim request As FtpWebRequest = CType(WebRequest.Create(_ftpClient.FtpAddress), FtpWebRequest)
                request.Credentials = New NetworkCredential(_ftpClient.FtpUsername, _ftpClient.FtpPassword)
                request.Method = WebRequestMethods.Ftp.ListDirectory

                Try
                    Using response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
                        ' Folder exists here
                        IsExisted = True
                        'MsgBox("exists!")
                    End Using

                Catch ex As WebException
                    Dim response As FtpWebResponse = DirectCast(ex.Response, FtpWebResponse)
                    'Does not exist
                    If response.StatusCode = FtpStatusCode.ActionNotTakenFileUnavailable Then
                        'MsgBox("Doesn't exist!")
                    End If
                End Try
            End If
        Catch ex As Exception

        End Try

        Return IsExisted
    End Function

    Public Function CheckFTPStatus(_dtFTPInfo As DataTable) As Boolean
        Dim IsExisted As Boolean = False

        Try
            If _dtFTPInfo.Rows.Count > 0 Then
                Dim _ftpClient As FTPClient = GetFTPDefaultConfiguration(_dtFTPInfo)

                Dim request As FtpWebRequest = CType(WebRequest.Create(_ftpClient.FtpAddress), FtpWebRequest)
                request.Credentials = New NetworkCredential(_ftpClient.FtpUsername, _ftpClient.FtpPassword)
                request.Method = WebRequestMethods.Ftp.ListDirectory

                Try
                    Using response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
                        ' Folder exists here
                        IsExisted = True
                        'MsgBox("exists!")
                    End Using

                Catch ex As WebException
                    Dim response As FtpWebResponse = DirectCast(ex.Response, FtpWebResponse)
                    'Does not exist
                    If response.StatusCode = FtpStatusCode.ActionNotTakenFileUnavailable Then
                        'MsgBox("Doesn't exist!")
                    End If
                End Try
            End If
        Catch ex As Exception

        End Try

        Return IsExisted
    End Function

End Class
