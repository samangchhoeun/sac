Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors

Module DBFunctions
    Public Const MAX_IMAGE_SIZE As Long = 1048576 '1 MB
    Public Const MAX_LOGO_IMAGE_SIZE As Long = 1048576  '6 MB
    Public IsConnectedDB As Boolean = False
    Public Str_Con As String = ""
    Public _DBConfigUser As String = "dbconfig"
    Public _DBConfigPass As String = "f99e4f599cab06447dfd7a1d9e189415"
    Public _ObjFTP As New FTPClient

    Public Sub OpenCon(con As SqlConnection)
        Dim state As ConnectionState = con.State
        If state = ConnectionState.Closed Then
            Try
                con.Open()
            Catch ex As Exception
                XtraMessageBox.Show("The following error occurred while attempting to connect to database. The program will be terminated then. " & vbLf & vbLf & "Please contact us At samangchhoeun@gmail.com.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Application.Exit()
            End Try
        End If
    End Sub

    Public Sub CloseCon(con As SqlConnection)
        Try
            Dim state As ConnectionState = con.State
            If state = ConnectionState.Open Then
                'con.Dispose();
                con.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub TestConnection(ByVal Server As String, ByVal DB As String, ByVal User As String, ByVal Pass As String)
        Dim ConString As String
        ConString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", Server, DB, User, Pass)
        Dim SqlCon As New SqlConnection(ConString)
        Try
            SqlCon.Open()
            XtraMessageBox.Show("Test connection succeeded!", "Microsoft Data Link", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SqlCon.Close()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Microsoft Data Link Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LoadDBConnection()
        GetDBSettings()

        'If Not File.Exists(DbFileName) Or IsConnectedDB = False Then
        If IsConnectedDB = False Then
            'Hide()
            LoadFormDialog(frmDatabase)
            Str_Con = ReadConnection()
        End If

        Con = New SqlConnection(Str_Con)
    End Sub

    Public Sub GetDBSettings()
        Str_Con = ReadConnection()
        'Dim connParts As List(Of String) = ListDBConnection(Str_Con)

        Dim conB As New SqlConnectionStringBuilder With {.ConnectionString = Str_Con}
        If Not String.IsNullOrEmpty(conB.ConnectionString) Then
            DBPwd = conB.Password
            DBUser = conB.UserID
            DBName = conB.InitialCatalog
            ServerName = conB.DataSource
            Con = New SqlConnection(conB.ConnectionString) 'just update on September 04, 2018
            IsConnectedDB = IsConnectionOpen(ServerName, DBName, DBUser, DBPwd)
        End If
    End Sub

    Public Function ConnectionStrBuilder(ByVal Pass As String, ByVal User As String, ByVal DB As String, ByVal Server As String) As String
        Dim ConString As String
        ConString = String.Format("Password={0};Persist Security Info=True;User ID={1};Initial Catalog={2};Data Source={3}", Pass, User, DB, Server)
        Dim conBuild As New SqlConnectionStringBuilder
        conBuild.ConnectionString = ConString
        conBuild.ConnectTimeout = 3
        Return conBuild.ConnectionString
    End Function

    Public Function ReadConnection() As String
        Dim contentDecrypt As String = ""
        'Get Full-Execute File Path and Combine with DbFileName
        Dim fullExeDbPath As String = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), dbFileName)

        If File.Exists(fullExeDbPath) Then contentDecrypt = Decrypt(System.IO.File.ReadAllText(fullExeDbPath))
        'XtraMessageBox.Show(String.Format("Fun: ReadConnection => Path:{0}", contentDecrypt))
        Return contentDecrypt

    End Function

    Public Function IsConnectionOpen(ByVal Server As String, ByVal DB As String, ByVal User As String, ByVal Pass As String) As Boolean
        Dim IsConnected As Boolean = False
        Dim ConString As String = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}; Connection Timeout=3", Server, DB, User, Pass)
        Dim SqlCon As New SqlConnection(ConString)
        Try
            SqlCon.Open()
            IsConnected = True
            SqlCon.Close()
        Catch ex As Exception
        End Try

        Return IsConnected
    End Function

    Public Function Encrypt(ByVal content As String) As String
        Dim contentByte As Byte() = System.Text.Encoding.UTF8.GetBytes(content)
        Return Convert.ToBase64String(contentByte)
    End Function

    Public Function Decrypt(ByVal content As String) As String
        Dim contentByte As Byte() = Convert.FromBase64String(content)
        Return System.Text.Encoding.UTF8.GetString(contentByte)
    End Function

    Public Sub CheckAccessCode()
        Dim GetSACLink As DataTable = GetDataFromDBToTable("SA_GetMyStore", New SqlParameter("@Code", 2))
        If GetSACLink.Rows.Count = 1 Then SAC = Decrypt(GetSACLink.Rows(0)("MyStore").ToString())
    End Sub

    Public Sub SaveConnection(ByVal con As String)
        Dim fullExeDbPath As String = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), dbFileName)
        Dim contentEncrypt As String = Encrypt(con)

        System.IO.File.WriteAllText(fullExeDbPath, contentEncrypt)
    End Sub

    Public Function ReadUdl(ByVal path As String) As SqlConnectionStringBuilder
        Dim content As String() = File.ReadAllText(path).Split(";"c)
        Dim conStr As String = ""
        For i = 2 To content.Length - 1
            conStr &= content(i) & ";"
        Next
        Dim connectionString As New SqlConnectionStringBuilder
        connectionString.ConnectionString = conStr
        Return connectionString
    End Function

    Public Sub GetAccessLink()
        Try
            Dim GetLink As DataTable = GetDataFromDBToTable("SA_GetMyStore", New SqlParameter("@Code", 1))
            If GetLink.Rows.Count = 1 Then IsMrSAM = GetLink.Rows(0)("MyStore").ToString()
        Catch ex As Exception
            'XtraXtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Function IsSystemOwner(Head As Integer, Body As String, Tail As String) As Boolean
        Dim isMe As Boolean = False
        Try
            GetAccessLink()
            Dim EncryptList As DataTable = GetDataFromDBToTable(IsMrSAM)
            If EncryptList.Rows.Count > 0 Then
                For Each RowList As DataRow In EncryptList.Rows
                    If (String.CompareOrdinal(RowList("Head").ToString, GenEncryption(Head.ToString)) = 0) AndAlso (String.CompareOrdinal(RowList("Body").ToString, GenEncryption(Body)) = 0) And (String.CompareOrdinal(RowList("Tail").ToString, GenEncryption(Tail)) = 0) Then
                        isMe = True
                        isLoggedInOwner = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            'XtraXtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return isMe
    End Function

    Public Function IsOwnerAllowModifyOthers(SID As Integer) As Boolean
        Dim isMe As Boolean = False

        Try
            Dim EncryptList As DataTable = GetDataFromDBToTable(IsMrSAM)
            If EncryptList.Rows.Count > 0 Then
                For Each RowList As DataRow In EncryptList.Rows
                    If (String.CompareOrdinal(RowList("Head").ToString, GenEncryption(LogUserNo.ToString)) = 0 AndAlso SID <> 3) Then
                        isMe = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            'XtraXtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return isMe
    End Function

    Public Function IsMainOwnerAllowModifyOthers() As Boolean
        Dim isMe As Boolean = False

        Try
            Dim EncryptList As DataTable = GetDataFromDBToTable(IsMrSAM)
            If EncryptList.Rows.Count > 0 Then
                For Each RowList As DataRow In EncryptList.Rows
                    If (String.CompareOrdinal(RowList("Head").ToString, GenEncryption(LogUserNo.ToString)) = 0 AndAlso LogUserNo = 3) Then
                        isMe = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            'XtraXtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return isMe
    End Function

    Public Function IsMainOwnerNotAllowToModify(SID As Integer) As Boolean
        Dim isMe As Boolean = False

        Try
            Dim EncryptList As DataTable = GetDataFromDBToTable(IsMrSAM)
            If EncryptList.Rows.Count > 0 Then
                For Each RowList As DataRow In EncryptList.Rows
                    If (String.CompareOrdinal(RowList("Head").ToString, GenEncryption(LogUserNo.ToString)) = 0 AndAlso SID = 3) Then
                        isMe = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            'XtraXtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return isMe
    End Function

    Public Function IsOwnerCurrentLoggedIn(SID As Integer) As Boolean
        Dim isMe As Boolean = False

        Try
            Dim EncryptList As DataTable = GetDataFromDBToTable(IsMrSAM)
            If EncryptList.Rows.Count > 0 Then
                For Each RowList As DataRow In EncryptList.Rows
                    If (String.CompareOrdinal(RowList("Head").ToString, GenEncryption(LogUserNo.ToString)) = 0 AndAlso LogUserNo = SID) Then
                        isMe = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            'XtraXtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return isMe
    End Function

    Public Function GetFTPConfiguration(ByVal _dtFTPInfo As DataTable) As Boolean
        Dim _IsFound As Boolean = False
        _ObjFTP = _ObjFTP.GetFTPDefaultConfiguration(_dtFTPInfo)
        With frmFTPSettings
            ._TempID = _ObjFTP.ID
            .txtID.Text = _ObjFTP.ID.ToString
            .txtFTPAddress.Text = _ObjFTP.FtpAddress
            .txtFTPUser.Text = _ObjFTP.FtpUsername
            .btnFTPPass.Text = _ObjFTP.FtpPassword
            .lueFTPGroup.EditValue = _ObjFTP.FtpGroup
            .meRemark.Text = _ObjFTP.Remark
        End With
        If _ObjFTP.ID > 0 Then _IsFound = True

        Return _IsFound
    End Function

    Public Sub AutoCompleteID(ByVal txt As TextEdit, ByVal SQL As String, ByVal ParamArray params() As SqlParameter)
        With txt.MaskBox
            .AutoCompleteCustomSource = getAutoCompleteID(SQL, params)
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End With
    End Sub

    Public Function getAutoCompleteID(ByVal SQL As String, ByVal ParamArray params() As SqlParameter) As AutoCompleteStringCollection
        OpenCon(Con)
        Dim cmd As New SqlCommand
        With cmd
            .Connection = Con
            .CommandType = CommandType.StoredProcedure
            .CommandText = SQL
            If params.Length > 0 Then
                .Parameters.AddRange(params)
            End If
            .CommandTimeout = 300
        End With

        Dim dr As SqlDataReader = cmd.ExecuteReader()
        Dim col As New AutoCompleteStringCollection()
        While dr.Read()
            col.Add(dr(0).ToString())
        End While
        dr.Close()
        CloseCon(Con)
        Return col
    End Function

    Public Sub GetDataToComboBoxWithParam(cbo As LookUpEdit, SP As String, Member As String, Display As String, ByVal ParamArray params() As SqlParameter)
        With cbo.Properties
            .DataSource = GetDataFromDBToTable(SP, params)
            .ValueMember = Member
            .DisplayMember = Display
            .ForceInitialize()
            .PopulateColumns()
            .Columns(Member).Visible = False
        End With
    End Sub

    Public Sub GetDataToComboBoxFitColWithParam(cbo As LookUpEdit, SP As String, Member As String, Display As String, ByVal ParamArray params() As SqlParameter)
        With cbo.Properties
            .DataSource = GetDataFromDBToTable(SP, params)
            .ValueMember = Member
            .DisplayMember = Display
            .PopupWidth = 900
            .ForceInitialize()
            .PopulateColumns()
            .BestFitWidth = 1
            .Columns(Member).Visible = False
        End With
    End Sub

    Public Sub GetDataToLookupEdit(cbo As LookUpEdit, SP As Object, Member As String, Display As String)
        With cbo.Properties
            .DataSource = SP
            .ValueMember = Member
            .DisplayMember = Display
            .ForceInitialize()
            .PopulateColumns()
            .Columns(Member).Visible = False
        End With
    End Sub

    Public Function GetDataFromDBToTable(ByVal SQL As String, ParamArray ByVal params() As SqlParameter) As DataTable
        Dim cmd As New SqlCommand
        With cmd
            .Connection = Con
            .CommandType = CommandType.StoredProcedure
            .CommandText = SQL
            If params.Length > 0 Then .Parameters.AddRange(params)
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetPatientDiagnosisToList(ByVal SQL As String, ParamArray ByVal params As SqlParameter()) As List(Of PatientDiagnosis)
        Dim tmpList As New List(Of PatientDiagnosis)
        Dim dt As DataTable = GetDataFromDBToTable(SQL, params)
        Dim i As Integer = 0
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim _list As New PatientDiagnosis
                With _list
                    .ID = CInt(row("ID"))
                    .DiagnosisCode = CInt(row("DiagnosisCode"))
                    .DxCode = row("DxCode").ToString
                    .Diagnosis = row("Diagnosis").ToString
                    .DxGroup = row("DxGroupEn").ToString
                    .DxNote = row("DxNote").ToString
                    .DxGroupID = CInt(row("DxGroupID"))
                    .DxTimeStamp = Convert.ToDateTime(row("DxTimeStamp").ToString)
                End With
                i += 1
                tmpList.Add(_list)
            Next
        End If

        Return tmpList
    End Function

    Public Function Get2Results(ByVal func As String, ParamArray ByVal params As SqlParameter()) As List(Of String)
        Dim tmpList As New List(Of String)
        Dim cmd As New SqlCommand(func, Con)
        With cmd
            .CommandType = CommandType.StoredProcedure
            If params.Count() > 0 Then
                For Each p As SqlParameter In params
                    .Parameters.Add(p)
                Next
            End If
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()

        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            'Dim i As Integer = dr.Table.Columns.Count
            For i = 0 To dr.Table.Columns.Count - 1
                tmpList.Add(dr(i).ToString())
            Next
            'tmpList.Add(dr(0).ToString())
            'tmpList.Add(dr(1).ToString())
        End If

        Return tmpList
    End Function

    Public Function GetNewRecordID(sp As String) As Integer
        'open connection if close
        OpenCon(Con)
        Dim cmd As New SqlCommand(sp, Con)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@num", SqlDbType.Int)
            .Parameters("@num").Direction = ParameterDirection.Output
            .ExecuteNonQuery()
            .Dispose()
        End With

        'close connection if open
        CloseCon(Con)
        Dim i As Integer = Convert.ToInt16(cmd.Parameters("@num").Value.ToString())
        Return i
    End Function

    Public Function GetAvailableControlByGroup(GroupID As String) As List(Of AvailableControls)
        ' Control Model
        Dim _con As New List(Of AvailableControls)()

        'Get Control From Database - DataTable
        Dim _Controls As List(Of clsControls) = clsControls.GetGroupControlsByID(GroupID)

        'Get Control From Database - DataTable
        'Dim _ExcludeControls As List(Of clsControls) = clsControls.GetExcludeControls()

        For Each f As Form In Application.OpenForms
            If f.Name.ToLower() = "frmMainProject".ToLower() Then
                Dim rc As RibbonControl = f.Controls.OfType(Of RibbonControl)().FirstOrDefault()
                For Each tab As RibbonPage In rc.Pages
                    For Each group As RibbonPageGroup In tab.Groups
                        For Each btn As BarButtonItemLink In group.ItemLinks
                            Dim _button As New AvailableControls()
                            '_button.Form = f.Name
                            _button.Tab = tab.Text
                            _button.Group = group.Text
                            _button.Caption = btn.Item.Caption
                            For Each c As clsControls In _Controls
                                If c.ControlName = btn.Item.Name Then _button.KhmerCaption = c.KhmerCaption
                            Next
                            _button.Control = btn.Item.Name
                            _button.IsAdded = True

                            'remove exclude controls from the list
                            Dim CanAdd As Boolean = False
                            For Each ec As clsControls In _Controls
                                If ec.ControlName = btn.Item.Name Then CanAdd = True
                            Next

                            'For Each ec As clsControls In _ExcludeControls
                            '    If ec.ControlName = btn.Item.Name Then CanAdd = True
                            'Next

                            If CanAdd Then _con.Add(_button)
                        Next
                    Next
                Next
            End If
        Next

        Return _con
    End Function

    Public Sub SetAvailableControl()
        GetDisabledControls()
        'Get Control From Database - DataTable
        Dim _AvialableControls As List(Of clsControls) = clsControls.GetVisibleControlsToList(LogUserNo, GroupID)

        'Get Control From Database - DataTable
        'Dim _BuildInControls As List(Of clsControls) = clsControls.GetExcludeControls()

        For Each f As Form In Application.OpenForms
            If f.Name.ToLower() = "frmMainProject".ToLower() Then
                Dim rc As RibbonControl = f.Controls.OfType(Of RibbonControl)().FirstOrDefault()
                For Each tab As RibbonPage In rc.Pages
                    tab.Visible = True

                    For Each group As RibbonPageGroup In tab.Groups
                        group.Visible = True
                        For Each btn As BarButtonItemLink In group.ItemLinks
                            ' btn.Item.Enabled = False
                            btn.Item.Visibility = BarItemVisibility.Never

                            'Check hide/show controls
                            For Each c As clsControls In _AvialableControls
                                If c.ControlName = btn.Item.Name Then btn.Item.Visibility = BarItemVisibility.Always
                            Next

                            ''Keep BuildInControls visible
                            'For Each cb As clsControls In _BuildInControls
                            '    If cb.ControlName = btn.Item.Name Then btn.Item.Visibility = BarItemVisibility.Always
                            'Next
                        Next

                        'Keep BuildInControls visible
                        'BuiltInControls()

                        'Check hide/show Group
                        Dim controlCount As Integer = group.ItemLinks.Count
                        Dim hideControl As Integer = 0

                        For Each btn As BarButtonItemLink In group.ItemLinks
                            If btn.Item.Visibility = BarItemVisibility.Never Then hideControl += 1
                        Next

                        If controlCount = hideControl Then group.Visible = False
                    Next

                    'Check hide/show Tab
                    Dim groupCount As Integer = tab.Groups.Count
                    Dim hideGroup As Integer = 0

                    For Each btn As RibbonPageGroup In tab.Groups
                        If btn.Visible = False Then hideGroup += 1
                    Next

                    If groupCount = hideGroup Then tab.Visible = False
                Next
            End If
        Next
    End Sub

    Public Sub GetDisabledControls()
        For Each f As Form In Application.OpenForms
            If f.Name.ToLower() = "frmMainProject".ToLower() Then
                Dim rc As RibbonControl = f.Controls.OfType(Of RibbonControl)().FirstOrDefault()
                For Each tab As RibbonPage In rc.Pages
                    tab.Visible = False
                    'For Each group As RibbonPageGroup In tab.Groups
                    '    group.Visible = False
                    '    'For Each btn As BarButtonItemLink In group.ItemLinks
                    '    '    ' btn.Item.Enabled = False
                    '    '    btn.Item.Visibility = BarItemVisibility.Never
                    '    'Next
                    'Next
                Next
            End If
        Next
    End Sub

    Public Function GetTempCardID() As String
        Dim TempID As String = ""
        Dim TempIDList As DataTable = GetDataFromDBToTable("SA_GetTempCardIDList", New SqlParameter("@id", "1"))
        If TempIDList.Rows.Count = 1 Then TempID = TempIDList.Rows(0)("TempID").ToString
        Return TempID
    End Function

    Public Function IsAccessAllowed(_Permission As String, Optional _Flag As Integer = 0) As Boolean
        Dim _IsVerified As Boolean = False
        Dim TempIDList As DataTable = GetDataFromDBToTable("SA_IsUserAccessAllowed",
                                                           New SqlParameter("@UserNo", LogUserNo),
                                                           New SqlParameter("@RoleID", LogRoleID),
                                                           New SqlParameter("@Permission", _Permission),
                                                           New SqlParameter("@Flag", _Flag))
        If TempIDList.Rows.Count = 1 Then _IsVerified = True
        Return _IsVerified
    End Function

    Public Function IsMultiCheckedInPerDay(_PatientCode As String, Optional _DateIn As String = "") As Boolean
        Dim _IsVerified As Boolean = False
        Dim TempIDList As DataTable = GetDataFromDBToTable("SA_IsMultiCheckedInPerDay",
                                                           New SqlParameter("@PatientCode", _PatientCode),
                                                           New SqlParameter("@DateIn", _DateIn))
        If TempIDList.Rows.Count > 0 Then _IsVerified = True
        Return _IsVerified
    End Function

    Public Function IsCheckedIn(_PatientCode As String, Optional _DateIn As String = "") As Boolean
        Dim _IsVerified As Boolean = False
        Dim TempIDList As DataTable = GetDataFromDBToTable("SA_IsCheckedIn",
                                                           New SqlParameter("@PatientCode", _PatientCode),
                                                           New SqlParameter("@DateIn", _DateIn))
        If TempIDList.Rows.Count > 0 Then _IsVerified = True
        Return _IsVerified
    End Function

    Public Function GetDataFromDBToList(ByVal SQL As String, ParamArray ByVal params As SqlParameter()) As List(Of Medication)
        Dim tmpList As New List(Of Medication)
        Dim cmd As New SqlCommand
        With cmd
            .Connection = Con
            .CommandType = CommandType.StoredProcedure
            .CommandText = SQL
            .Parameters.AddRange(params)
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)

        Dim i As Integer = 0
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim _lst As New Medication
                With _lst
                    .ID = i + 1
                    .BrandName = row(0).ToString
                    .GenericName = row(1).ToString
                    .MadeIn = row(2).ToString
                    .ExpiredDate = row(3).ToString
                    .Strength = row(4).ToString
                End With
                i += 1
                tmpList.Add(_lst)
            Next

        End If
        Return tmpList
    End Function

End Module
