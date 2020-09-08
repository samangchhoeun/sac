Imports DevExpress.XtraBars.Alerter

Public Class frmNewMessageAlert
    Dim WXRes As Short
    Dim HYRes As Short
    Dim WFormLocation As Short 'form alert location
    Dim HFormLocation As Short 'form alert location

    Dim i As Integer = 0
    Dim Drag As Boolean = False
    Dim mouseX As Integer
    Dim mouseY As Integer
    Dim isAlert As Boolean = False
    Dim isOnTop As Boolean = False
    Dim ImageVisible As Boolean = False
    Dim dtData As New DataTable

    Private Sub timImageFlicker_Tick(sender As Object, e As EventArgs) Handles timImageFlicker.Tick
        If ImageVisible Then
            picNewMessage.Image = icNewMessage.Images(0)
            ImageVisible = False
        Else
            picNewMessage.Image = icNewMessage.Images(1)
            ImageVisible = True
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        If frmMainProject.WindowState <> FormWindowState.Maximized Then frmMainProject.WindowState = FormWindowState.Maximized

        If Height = 37 Then
            Height += 462
        Else
            Height -= 462
        End If

        If Height = 499 Then
            btnDown.Image = ilButtonList.Images(0)
        Else
            btnDown.Image = ilButtonList.Images(1)
        End If
    End Sub

    Private Sub frmNewMessageAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowInTaskbar = False
        WXRes = CShort(Screen.PrimaryScreen.Bounds.Width)
        HYRes = CShort(Screen.PrimaryScreen.Bounds.Height)
        ShowAlert()
        Dim info As AlertInfo = New AlertInfo("New Message Alert", "There is new message box" + vbNewLine + vbNewLine + "Please check the box on the top right corner.")
        AlertControl1.Show(Me, info)
    End Sub

    Private Sub timUp_Tick(sender As Object, e As EventArgs) Handles timUp.Tick
        If isOnTop = False Then
            If i > HYRes - (HYRes - 37) Then
                Location = New Point(WFormLocation, i)
                i -= 30 'Speed up
            Else
                timUp.Enabled = False
                isOnTop = True 'Notify that form is already on top
            End If
        End If
    End Sub

    Private Sub timDown_Tick(sender As Object, e As EventArgs) Handles timDown.Tick
        If i < HYRes Then
            Location = New Point(WFormLocation, i)
            i += 50 'Speed down
        Else
            isOnTop = False 'Form is not on top
            Hide()
            timDown.Enabled = False
        End If
    End Sub

    Public Sub InitCheckDataList()
        isAlert = True
    End Sub

    Public Sub ShowAlert()
        InitCheckDataList()

        If isAlert Then 'If have something to alert
            If isOnTop = False Then 'If form is not on top yet, so form need to move up till the top
                TopMost = True
                'Show()
                'WXRes = CShort(Screen.PrimaryScreen.Bounds.Width)
                'HYRes = CShort(Screen.PrimaryScreen.Bounds.Height)
                Width = 190
                Height = 37
                WFormLocation = CShort((WXRes - Width) - 3)
                HFormLocation = CShort(HYRes - Height)
                Location = New Point(WFormLocation, HFormLocation - 70)

                '=========Up=============
                Location = New Point(WFormLocation, HYRes - 70)
                i = HYRes - 70
                timUp.Enabled = True
                '========================

                Console.Beep()
                Console.Beep()
                Console.Beep()
            Else
                Exit Sub 'If form is already stay on the top, so it will not run again
            End If
        Else
            Height = 37
            isOnTop = False
            timDown.Enabled = True
        End If

        If Height = 499 Then
            btnDown.Image = ilButtonList.Images(0)
        Else
            btnDown.Image = ilButtonList.Images(1)
        End If
    End Sub

    Private Sub nbcContent_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbcContent.LinkClicked
        frmMainProject.WindowState = FormWindowState.Maximized
        MessageBox.Show(e.Link.Group.Caption.Trim)
        'If e.Link.Group.Caption.Trim = "Rx To Dispense" Then
        '    MessageBox.Show(e.Link.Group.Caption.Trim)
        'End If
    End Sub

    Private Sub frmNewMessageAlert_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub frmNewMessageAlert_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        timDown.Stop()
        timUp.Stop()
        timImageFlicker.Stop()
        timDown.Enabled = False
        timUp.Enabled = False
        timImageFlicker.Enabled = False
    End Sub

    Private Sub picNewMessage_DoubleClick(sender As Object, e As EventArgs) Handles picNewMessage.DoubleClick
        If frmMainProject.WindowState <> FormWindowState.Maximized Then frmMainProject.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub InitCheckRecords()

    End Sub
End Class