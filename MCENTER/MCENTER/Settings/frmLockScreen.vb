Imports DevExpress.XtraEditors

Public Class frmLockScreen
    Dim i As Integer = 0, _tCount As Integer = 0
    Private Sub frmLockScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTime.Text = Format(Now, "hh:mm tt")
        lblDate.Text = Format(Now, "dddd, MMMM dd, yyyy")

        'AddActivityHandler(Me)
        'AddHandler Me.MouseDown, AddressOf NonActivityTimerStop
        'AddHandler Me.KeyDown, AddressOf NonActivityTimerStop
        'NonActivityTimer.Start()
    End Sub

    Private Sub timeTimer_Tick(sender As Object, e As EventArgs) Handles timeTimer.Tick
        lblTime.Text = Format(Now, "hh:mm tt")
        lblDate.Text = Format(Now, "dddd, MMMM dd, yyyy")
        lblUsername.Text = AccountName
    End Sub

    Private Sub btnShutdown_Click(sender As Object, e As EventArgs) Handles btnShutdown.Click
        ExitProgram()
    End Sub

    Private Sub ExitProgram()
        detected = XtraMessageBox.Show("Do you want to close this program?" & vbCrLf & vbCrLf & "Make sure that you have saved all your information.", "Closing Program?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If detected = DialogResult.Yes Then
            Application.Exit()
            Close()
        End If
        txtPwd.Focus()
    End Sub

    Private Sub txtPwd_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtPwd.ButtonClick
        'NonActivityTimer.Stop()

        If i = 3 Then
            txtPwd.Visible = False
            txtPwd.Text = ""
            btnOK.Visible = False
            lblIncorrectPassword.Visible = True
            lblIncorrectPassword.Text = "System is disabled"
            lblTryAgain.Visible = True
            timeCountDown.Start()
        Else
            Dim CurPass As String = GenEncryptPassword(txtPwd.Text.Trim)
            If (String.CompareOrdinal(CurPass, LogPass) <> 0) Then
                EnabledText()
                i += 1
                'NonActivityTimer.Start()
                btnOK.Focus()
                Return
            End If
            Dispose()
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        EnabledText(False)
        txtPwd.Focus()
    End Sub

    Private Sub EnabledText(Optional En As Boolean = True)
        txtPwd.Visible = Not En
        txtPwd.Text = ""
        lblTryAgain.Visible = False
        lblIncorrectPassword.Visible = En
        lblIncorrectPassword.Text = "The password is incorrect. Try again."
        btnOK.Visible = En
    End Sub

    Private Sub txtPwd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPwd.KeyDown
        If e.KeyCode = Keys.Enter Then
            'NonActivityTimer.Stop()

            If i = 3 Then
                txtPwd.Visible = False
                txtPwd.Text = ""
                btnOK.Visible = False
                lblIncorrectPassword.Visible = True
                lblIncorrectPassword.Text = "System is disabled"
                lblTryAgain.Visible = True
                timeCountDown.Start()
            Else
                Dim CurPass As String = GenEncryptPassword(txtPwd.Text.Trim)
                If (String.CompareOrdinal(CurPass, LogPass) <> 0) Then
                    EnabledText()
                    i += 1
                    'NonActivityTimer.Start()
                    btnOK.Focus()
                    Return
                End If
                Dispose()
            End If
        End If
    End Sub

    Private Sub frmLockScreen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (e.CloseReason = CloseReason.UserClosing) Then
            e.Cancel = True
            'XtraMessageBox.Show("Closing of the form is not allowed", "Security", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub timeCountDown_Tick(sender As Object, e As EventArgs) Handles timeCountDown.Tick
        If _tCount = 60 Then
            timeCountDown.Stop()
            EnabledText(False)
            _tCount = 0
            i = 0
            'NonActivityTimer.Start()
        End If
        _tCount += 1
    End Sub
End Class