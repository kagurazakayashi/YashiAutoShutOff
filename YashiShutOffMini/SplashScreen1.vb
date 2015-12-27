Public NotInheritable Class SplashScreen1

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Globalization.CultureInfo.InstalledUICulture.Name.Equals("zh-CN") = False Then
            label1.Text = "Yashi timed shutdown"
            info.Text = "Starting timer"
        End If
    End Sub

End Class
