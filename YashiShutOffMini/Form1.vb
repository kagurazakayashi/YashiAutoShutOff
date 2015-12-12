Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        numy2.Value = Now.Year
        numm2.Value = Now.Month
        numd2.Value = Now.Day
        numh2.Value = Now.Hour
        numi2.Value = Now.Minute
        nums2.Value = Now.Second
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        numy1.Value = Now.Year
        numm1.Value = Now.Month
        numd1.Value = Now.Day
        numh1.Value = Now.Hour
        numi1.Value = Now.Minute
        nums1.Value = Now.Second
        If numy1.Value >= numy2.Value And numm1.Value >= numm2.Value And numd1.Value >= numd2.Value And numh1.Value >= numh2.Value And numi1.Value >= numi2.Value And nums1.Value >= nums2.Value Then
            If RadioButton2.Checked Then
                RadioButton1.Checked = True
                MsgBox("已到达预定时间。", MsgBoxStyle.OkOnly, "雅诗简易定时关机提醒")
            ElseIf RadioButton3.Checked Then
                RadioButton1.Checked = True
                Shutdown()
            ElseIf RadioButton4.Checked Then
                RadioButton1.Checked = True
                Restart()
            ElseIf RadioButton5.Checked Then
                RadioButton1.Checked = True
                Sleep()
            End If
        End If

    End Sub

    Private Sub Shutdown()
        Timer1.Enabled = False
        Shell("shutdown -s -t 0", vbHide) '关机
    End Sub

    Private Sub Restart()
        Timer1.Enabled = False
        Shell("shutdown -r -t 0", vbHide)
    End Sub

    Private Sub Sleep()
        Timer1.Enabled = False
        Shell("shutdown -h -t 0", vbHide)
    End Sub
End Class
