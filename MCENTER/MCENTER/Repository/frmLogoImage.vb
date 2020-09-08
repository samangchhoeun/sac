Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmLogoImage
    Friend DataList As New DataTable

    Private Sub frmLogoImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bgLoading.RunWorkerAsync()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bgLoading_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgLoading.DoWork
        'Threading.Thread.Sleep(500)

        Try
            e.Result = GetDataFromDBToTable("SA_GetTimeIOScreenSaver", New SqlParameter("@Flag", _isLoggedInOwner))
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub bgLoading_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgLoading.RunWorkerCompleted
        Try
            DataList = CType(e.Result, DataTable)

            With gvImageList
                If DataList.Rows.Count > 0 Then
                    gcImageList.DataSource = DataList
                    .PopulateColumns()
                    .Columns("ID").OptionsColumn.FixedWidth = True
                    .Columns("ID").Width = 100
                    .Columns("ID").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("ID").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("ImageOrder").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("ImageOrder").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("Inactive").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .OptionsView.RowAutoHeight = True
                    .Columns("PhotoScreen").Width = 250
                    '.Columns("ClientIP").Width = 200
                    .Columns("DateUpdate").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    .Columns("DateUpdate").SummaryItem.DisplayFormat = "Total: {0} Records"
                Else
                    gcImageList.DataSource = Nothing
                    .Columns.Clear()
                End If
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
        frmLoadingData.Hide()
    End Sub

    Private Sub gcImageList_MouseClick(sender As Object, e As MouseEventArgs) Handles gcImageList.MouseClick
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            ppPopupMenu.ShowPopup(Me.bmPopupMenu, Control.MousePosition)
        End If
    End Sub

    Private Sub bbiPAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPAdd.ItemClick
        LoadFormDialog(frmUpdateLogoImage)
    End Sub

    Private Sub bbiPModify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPModify.ItemClick
        With gvImageList
            If .RowCount <= 0 Then
                XtraMessageBox.Show("There is no record selected to modify.", "No Record Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Try
                frmUpdateLogoImage.btnSave.Text = "Update"
                Dim _Photo As Object = .GetRowCellValue(.FocusedRowHandle, "PhotoScreen")
                Dim _ImageOrder As String = .GetRowCellValue(.FocusedRowHandle, "ImageOrder").ToString
                frmUpdateLogoImage._ImageID = CInt(.GetRowCellValue(.FocusedRowHandle, "ID").ToString)
                Dim _Ispermanent As Boolean = CBool(.GetRowCellValue(.FocusedRowHandle, "Ispermanent").ToString)
                Dim _StartDate As String = .GetRowCellValue(.FocusedRowHandle, "StartDate").ToString
                Dim _EndDate As String = .GetRowCellValue(.FocusedRowHandle, "EndDate").ToString
                frmUpdateLogoImage.GetImageInfo(_Photo, _ImageOrder, _StartDate, _EndDate, _Ispermanent)
                LoadFormDialog(frmUpdateLogoImage)
            Catch ex As Exception
                XtraMessageBox.Show("Invalid record selection.", "No Record Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub

    Private Sub bbiPRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRestore.ItemClick
        'XtraMessageBox.Show("This option currently is disabled by System Admin", "Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information)

        With gvImageList
            If .RowCount <= 0 Then
                XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Try
                Dim _Code As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ID").ToString)

                detected = XtraMessageBox.Show("Do you want to restore image id: " + _Code.ToString + "?", "Restore?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then
                    Return
                End If
                RemovePopupImage(_Code)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub

    Friend Sub RemovePopupImage(_ImageID As Integer, Optional ByVal _IsRemoved As Integer = 0)
        Try
            OpenCon(Con)
            Dim cmd As New SqlCommand("SA_RemovePopupImage", Con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Code", _ImageID)
                .AddWithValue("@Isremoved", _IsRemoved)
                .AddWithValue("@User", AccountName)
                .Add("@IsDeleted", SqlDbType.Int)
                cmd.Parameters("@IsDeleted").Direction = ParameterDirection.Output
                .Add("@Msg", SqlDbType.NVarChar, 300)
                cmd.Parameters("@Msg").Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            Dim mms As MessageBoxIcon = MessageBoxIcon.Information
            If CInt(cmd.Parameters("@IsDeleted").Value) = 0 Then
                mms = MessageBoxIcon.Error
            End If

            bgLoading.RunWorkerAsync()
            Me.Cursor = Cursors.Default
            XtraMessageBox.Show(cmd.Parameters("@Msg").Value.ToString, "Confirm message", MessageBoxButtons.OK, mms)
        Catch ex As Exception
            ErrorLog.WriteLog("SA_RemovePopupImage", ex.Message)
        End Try

        CloseCon(Con)
    End Sub

    Private Sub bbiPRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPRemove.ItemClick
        With gvImageList
            If .RowCount <= 0 Then
                XtraMessageBox.Show("There is no item in the list.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Try
                Dim _Code As Integer = CInt(.GetRowCellValue(.FocusedRowHandle, "ID").ToString)

                detected = XtraMessageBox.Show("Do you want to remove image id: " + _Code.ToString + "?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If detected = DialogResult.No Then
                    Return
                End If

                'DeletePopupImage(_Code)
                RemovePopupImage(_Code, 1)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error Help?", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End With
    End Sub
End Class