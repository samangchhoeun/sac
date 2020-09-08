Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmControls
    Dim _isSuccessAdded As Boolean = False
    Dim _confirmMsg As String = ""
    Dim _mMS As MessageBoxIcon = MessageBoxIcon.Error

    Private Sub frmControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllControls()
        LoadNewControls()
        LoadExcludedControls()
        LoadInactiveControls()
        LoadRemovedControls()
    End Sub

    Private Sub LoadAllControls()
        Try
            Dim _GroupControlIDs As List(Of clsControls) = clsControls.GetGroupControlID(UserGroupID)
            gcActiveControls.DataSource = GetAvailableControl()
            With gvActiveControls
                .PopulateColumns()
                .Columns("Tab").Group()
                .Columns("Group").Group()
                .ExpandAllGroups()
                .SelectAll()
                Dim SelRows As Integer() = .GetSelectedRows
                .ClearSelection()
                If _GroupControlIDs.Count > 0 Then
                    For Each i As Integer In SelRows
                        If (i >= 0) Then
                            Dim SelectedRow As AvailableControls = CType(.GetRow(i), AvailableControls)
                            For index As Integer = 0 To _GroupControlIDs.Count - 1
                                If SelectedRow.Control.ToString = _GroupControlIDs.Item(index).ControlName Then .SelectRow(i)
                            Next
                        End If
                    Next
                End If
                .Columns("IsAdded").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .BestFitColumns()
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadExcludedControls()
        Try
            gcExcludedControls.DataSource = GetExludedControlsAvailable()
            With gvExcludedControls
                .PopulateColumns()
                .Columns("Tab").Group()
                .Columns("Group").Group()
                .ExpandAllGroups()
                .Columns("IsAdded").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .BestFitColumns()
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadNewControls()
        Try
            gcNewControls.DataSource = GetNewControls()
            With gvNewControls
                .PopulateColumns()
                .Columns("Tab").Group()
                .Columns("Group").Group()
                .ExpandAllGroups()
                .Columns("IsAdded").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .BestFitColumns()
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadInactiveControls()
        Try
            gcInactiveControls.DataSource = GetInactiveControls()
            With gvInactiveControls
                .PopulateColumns()
                .Columns("IsAdded").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .BestFitColumns()
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRemovedControls()
        Try
            gcRemovedControls.DataSource = GetRemovedControls()
            With gvRemovedControls
                .PopulateColumns()
                .Columns("IsAdded").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .BestFitColumns()
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub gcActiveControls_MouseClick(sender As Object, e As MouseEventArgs) Handles gcActiveControls.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppActive.ShowPopup(Me.bmActive, Control.MousePosition)
    End Sub

    Private Sub gcNewControls_MouseClick(sender As Object, e As MouseEventArgs) Handles gcNewControls.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppNew.ShowPopup(Me.bmActive, Control.MousePosition)
    End Sub

    Private Sub gcInactiveControls_MouseClick(sender As Object, e As MouseEventArgs) Handles gcInactiveControls.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppInActive.ShowPopup(Me.bmActive, Control.MousePosition)
    End Sub

    Private Sub gcExcludedControls_MouseClick(sender As Object, e As MouseEventArgs) Handles gcExcludedControls.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppExclude.ShowPopup(Me.bmActive, Control.MousePosition)
    End Sub

    Private Sub bbiNewAddActive_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiNewAddActive.ItemClick
        Try
            With gvNewControls
                Dim SelRows As Integer() = .GetSelectedRows
                If SelRows.Count <= 0 Then
                    XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ControlList As String = "", _CaptionList As String = ""
                Dim _Controls(SelRows.Count) As String
                Dim _Captions(SelRows.Count) As String
                Dim i As Integer = 0
                Dim MyChar() As Char = {","c, " "c, "|"c}
                For Each index As Integer In SelRows
                    If index >= 0 Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(index), AvailableControls)
                        _Controls(i) = SelectedRow.Control.ToString
                        _Captions(i) = SelectedRow.Caption.ToString
                        i += 1
                    End If
                Next

                _ControlList = String.Join(",", _Controls)
                _ControlList = _ControlList.TrimEnd(MyChar)

                _CaptionList = String.Join(",", _Captions)
                _CaptionList = _CaptionList.TrimEnd(MyChar)

                SaveNewControls(_ControlList, _CaptionList)
                If _isSuccessAdded Then
                    LoadAllControls()
                    LoadNewControls()
                End If
                XtraMessageBox.Show(_confirmMsg, "Confrim Message", MessageBoxButtons.OK, _mMS)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection. " + ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveNewControls(ByVal Controls As String, ByVal Captions As String, Optional ByVal Excluded As Boolean = False, Optional ByVal Mark_Deleted As Boolean = False)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_SaveNewControls", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Controls", Controls)
                .AddWithValue("@Captions", Captions)
                .AddWithValue("@Mark_Deleted", Mark_Deleted)
                .AddWithValue("@Excluded", Excluded)
                .AddWithValue("@User", AccountName)
                .Add("@IsAdd", SqlDbType.Int)
                cmd.Parameters("@IsAdd").Direction = ParameterDirection.Output
                .Add("@msg", SqlDbType.NVarChar, -1)
                cmd.Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            CloseCon(Con)
            Dim IsAdd As Integer = CInt(cmd.Parameters("@IsAdd").Value)
            If IsAdd <> 0 Then
                _IsSuccessAdded = True
                _mMS = MessageBoxIcon.Information
            End If
            _confirmMsg = cmd.Parameters("@msg").Value.ToString
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiNewAddExclude_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiNewAddExclude.ItemClick
        Try
            With gvNewControls
                Dim SelRows As Integer() = .GetSelectedRows
                If SelRows.Count <= 0 Then
                    XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ControlList As String = "", _CaptionList As String = ""
                Dim _Controls(SelRows.Count) As String
                Dim _Captions(SelRows.Count) As String
                Dim i As Integer = 0
                Dim MyChar() As Char = {","c, " "c, "|"c}
                For Each index As Integer In SelRows
                    If index >= 0 Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(index), AvailableControls)
                        _Controls(i) = SelectedRow.Control.ToString
                        _Captions(i) = SelectedRow.Caption.ToString
                        i += 1
                    End If
                Next

                _ControlList = String.Join(",", _Controls)
                _ControlList = _ControlList.TrimEnd(MyChar)

                _CaptionList = String.Join(",", _Captions)
                _CaptionList = _CaptionList.TrimEnd(MyChar)

                SaveNewControls(_ControlList, _CaptionList, True)
                If _isSuccessAdded Then
                    LoadNewControls()
                    LoadExcludedControls()
                End If
                XtraMessageBox.Show(_confirmMsg, "Confrim Message", MessageBoxButtons.OK, _mMS)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection. " + ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiMarkInactive_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiMarkInactive.ItemClick
        Try
            With gvNewControls
                Dim SelRows As Integer() = .GetSelectedRows
                If SelRows.Count <= 0 Then
                    XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ControlList As String = "", _CaptionList As String = ""
                Dim _Controls(SelRows.Count) As String
                Dim _Captions(SelRows.Count) As String
                Dim i As Integer = 0
                Dim MyChar() As Char = {","c, " "c, "|"c}
                For Each index As Integer In SelRows
                    If index >= 0 Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(index), AvailableControls)
                        _Controls(i) = SelectedRow.Control.ToString
                        _Captions(i) = SelectedRow.Caption.ToString
                        i += 1
                    End If
                Next

                _ControlList = String.Join(",", _Controls)
                _ControlList = _ControlList.TrimEnd(MyChar)

                _CaptionList = String.Join(",", _Captions)
                _CaptionList = _CaptionList.TrimEnd(MyChar)

                SaveNewControls(_ControlList, _CaptionList, False, True)
                If _isSuccessAdded Then
                    LoadNewControls()
                    LoadRemovedControls()
                End If
                XtraMessageBox.Show(_confirmMsg, "Confrim Message", MessageBoxButtons.OK, _mMS)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection. " + ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiActiveAddExclude_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiActiveAddExclude.ItemClick
        Try
            With gvActiveControls
                Dim SelRows As Integer() = .GetSelectedRows
                If SelRows.Count <= 0 Then
                    XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ControlList As String = "", _CaptionList As String = ""
                Dim _Controls(SelRows.Count) As String
                Dim _Captions(SelRows.Count) As String
                Dim i As Integer = 0
                Dim MyChar() As Char = {","c, " "c, "|"c}
                For Each index As Integer In SelRows
                    If index >= 0 Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(index), AvailableControls)
                        _Controls(i) = SelectedRow.Control.ToString
                        _Captions(i) = SelectedRow.Caption.ToString
                        i += 1
                    End If
                Next

                _ControlList = String.Join(",", _Controls)
                _ControlList = _ControlList.TrimEnd(MyChar)

                _CaptionList = String.Join(",", _Captions)
                _CaptionList = _CaptionList.TrimEnd(MyChar)

                SaveNewControls(_ControlList, _CaptionList, True)
                If _isSuccessAdded Then
                    LoadAllControls()
                    LoadExcludedControls()
                End If
                XtraMessageBox.Show(_confirmMsg, "Confrim Message", MessageBoxButtons.OK, _mMS)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection. " + ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiActiveMarkInactive_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiActiveMarkInactive.ItemClick
        Try
            With gvActiveControls
                Dim SelRows As Integer() = .GetSelectedRows
                If SelRows.Count <= 0 Then
                    XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ControlList As String = "", _CaptionList As String = ""
                Dim _Controls(SelRows.Count) As String
                Dim _Captions(SelRows.Count) As String
                Dim i As Integer = 0
                Dim MyChar() As Char = {","c, " "c, "|"c}
                For Each index As Integer In SelRows
                    If index >= 0 Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(index), AvailableControls)
                        _Controls(i) = SelectedRow.Control.ToString
                        _Captions(i) = SelectedRow.Caption.ToString
                        i += 1
                    End If
                Next

                _ControlList = String.Join(",", _Controls)
                _ControlList = _ControlList.TrimEnd(MyChar)

                _CaptionList = String.Join(",", _Captions)
                _CaptionList = _CaptionList.TrimEnd(MyChar)

                SaveNewControls(_ControlList, _CaptionList, False, True)
                If _isSuccessAdded Then
                    LoadAllControls()
                    LoadRemovedControls()
                End If
                XtraMessageBox.Show(_confirmMsg, "Confrim Message", MessageBoxButtons.OK, _mMS)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection. " + ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiExcludeAddasActive_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiExcludeAddasActive.ItemClick
        Try
            With gvExcludedControls
                Dim SelRows As Integer() = .GetSelectedRows
                If SelRows.Count <= 0 Then
                    XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ControlList As String = "", _CaptionList As String = ""
                Dim _Controls(SelRows.Count) As String
                Dim _Captions(SelRows.Count) As String
                Dim i As Integer = 0
                Dim MyChar() As Char = {","c, " "c, "|"c}
                For Each index As Integer In SelRows
                    If index >= 0 Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(index), AvailableControls)
                        _Controls(i) = SelectedRow.Control.ToString
                        _Captions(i) = SelectedRow.Caption.ToString
                        i += 1
                    End If
                Next

                _ControlList = String.Join(",", _Controls)
                _ControlList = _ControlList.TrimEnd(MyChar)

                _CaptionList = String.Join(",", _Captions)
                _CaptionList = _CaptionList.TrimEnd(MyChar)

                SaveNewControls(_ControlList, _CaptionList)
                If _isSuccessAdded Then
                    LoadAllControls()
                    LoadExcludedControls()
                End If
                XtraMessageBox.Show(_confirmMsg, "Confrim Message", MessageBoxButtons.OK, _mMS)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection. " + ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiExcludeMarkasInactive_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiExcludeMarkasInactive.ItemClick
        Try
            With gvExcludedControls
                Dim SelRows As Integer() = .GetSelectedRows
                If SelRows.Count <= 0 Then
                    XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ControlList As String = "", _CaptionList As String = ""
                Dim _Controls(SelRows.Count) As String
                Dim _Captions(SelRows.Count) As String
                Dim i As Integer = 0
                Dim MyChar() As Char = {","c, " "c, "|"c}
                For Each index As Integer In SelRows
                    If index >= 0 Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(index), AvailableControls)
                        _Controls(i) = SelectedRow.Control.ToString
                        _Captions(i) = SelectedRow.Caption.ToString
                        i += 1
                    End If
                Next

                _ControlList = String.Join(",", _Controls)
                _ControlList = _ControlList.TrimEnd(MyChar)

                _CaptionList = String.Join(",", _Captions)
                _CaptionList = _CaptionList.TrimEnd(MyChar)

                SaveNewControls(_ControlList, _CaptionList, False, True)
                If _isSuccessAdded Then
                    LoadAllControls()
                    LoadExcludedControls()
                End If
                XtraMessageBox.Show(_confirmMsg, "Confrim Message", MessageBoxButtons.OK, _mMS)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection. " + ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        Try
            With gvInactiveControls
                Dim SelRows As Integer() = .GetSelectedRows
                If SelRows.Count <= 0 Then
                    XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ControlList As String = "", _CaptionList As String = ""
                Dim _Controls(SelRows.Count) As String
                Dim _Captions(SelRows.Count) As String
                Dim i As Integer = 0
                Dim MyChar() As Char = {","c, " "c, "|"c}
                For Each index As Integer In SelRows
                    If index >= 0 Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(index), AvailableControls)
                        _Controls(i) = SelectedRow.Control.ToString
                        _Captions(i) = SelectedRow.Caption.ToString
                        i += 1
                    End If
                Next

                _ControlList = String.Join(",", _Controls)
                _ControlList = _ControlList.TrimEnd(MyChar)

                _CaptionList = String.Join(",", _Captions)
                _CaptionList = _CaptionList.TrimEnd(MyChar)

                SaveNewControls(_ControlList, _CaptionList, False, True)
                If _isSuccessAdded Then
                    LoadInactiveControls()
                    LoadRemovedControls()
                End If
                XtraMessageBox.Show(_confirmMsg, "Confrim Message", MessageBoxButtons.OK, _mMS)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection. " + ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub gcRemovedControls_MouseClick(sender As Object, e As MouseEventArgs) Handles gcRemovedControls.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then ppRemoved.ShowPopup(Me.bmActive, Control.MousePosition)
    End Sub

    Private Sub bbiRemovedMoveasExclude_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiRemovedMoveasExclude.ItemClick
        Try
            With gvRemovedControls
                Dim SelRows As Integer() = .GetSelectedRows
                If SelRows.Count <= 0 Then
                    XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ControlList As String = "", _CaptionList As String = ""
                Dim _Controls(SelRows.Count) As String
                Dim _Captions(SelRows.Count) As String
                Dim i As Integer = 0
                Dim MyChar() As Char = {","c, " "c, "|"c}
                For Each index As Integer In SelRows
                    If index >= 0 Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(index), AvailableControls)
                        _Controls(i) = SelectedRow.Control.ToString
                        _Captions(i) = SelectedRow.Caption.ToString
                        i += 1
                    End If
                Next

                _ControlList = String.Join(",", _Controls)
                _ControlList = _ControlList.TrimEnd(MyChar)

                _CaptionList = String.Join(",", _Captions)
                _CaptionList = _CaptionList.TrimEnd(MyChar)

                SaveNewControls(_ControlList, _CaptionList, True)
                If _isSuccessAdded Then
                    LoadAllControls()
                    LoadRemovedControls()
                    LoadExcludedControls()
                End If
                XtraMessageBox.Show(_confirmMsg, "Confrim Message", MessageBoxButtons.OK, _mMS)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection. " + ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bbiRemovedMoveasActive_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiRemovedMoveasActive.ItemClick
        Try
            With gvRemovedControls
                Dim SelRows As Integer() = .GetSelectedRows
                If SelRows.Count <= 0 Then
                    XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim _ControlList As String = "", _CaptionList As String = ""
                Dim _Controls(SelRows.Count) As String
                Dim _Captions(SelRows.Count) As String
                Dim i As Integer = 0
                Dim MyChar() As Char = {","c, " "c, "|"c}
                For Each index As Integer In SelRows
                    If index >= 0 Then
                        Dim SelectedRow As AvailableControls = CType(.GetRow(index), AvailableControls)
                        _Controls(i) = SelectedRow.Control.ToString
                        _Captions(i) = SelectedRow.Caption.ToString
                        i += 1
                    End If
                Next

                _ControlList = String.Join(",", _Controls)
                _ControlList = _ControlList.TrimEnd(MyChar)

                _CaptionList = String.Join(",", _Captions)
                _CaptionList = _CaptionList.TrimEnd(MyChar)

                SaveNewControls(_ControlList, _CaptionList)
                If _isSuccessAdded Then
                    LoadAllControls()
                    LoadRemovedControls()
                End If
                XtraMessageBox.Show(_confirmMsg, "Confrim Message", MessageBoxButtons.OK, _mMS)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Invalid record selection. " + ex.Message, "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmControls_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class