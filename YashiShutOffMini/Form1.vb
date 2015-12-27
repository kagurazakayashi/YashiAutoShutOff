Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Globalization.CultureInfo.InstalledUICulture.Name.Equals("zh-CN") = False Then
            English()
        End If
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

    Private Sub English()
        Text = "Yashi timed shutdown"
        Label1.Text = "Year"
        Label2.Text = "Month"
        Label3.Text = "Day"
        Label4.Text = "Hour"
        Label5.Text = "Minute"
        Label6.Text = "Second"
        Label12.Text = Label1.Text
        Label11.Text = Label2.Text
        Label10.Text = Label3.Text
        Label9.Text = Label4.Text
        Label8.Text = Label5.Text
        Label7.Text = Label6.Text
        RadioButton1.Text = "Disable"
        RadioButton2.Text = "Remind"
        RadioButton3.Text = "Shutdown"
        RadioButton4.Text = "Restart"
        RadioButton5.Text = "Sleep"
        GroupBox1.Text = "Current time"
        GroupBox2.Text = "Timing"
        GroupBox3.Text = "Start now"
    End Sub

End Class
