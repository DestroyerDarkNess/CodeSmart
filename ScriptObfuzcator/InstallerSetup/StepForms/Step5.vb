Public Class Step5

    Private Sub Step5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Core.Helper.MainForm IsNot Nothing Then
            Core.Helper.MainForm.CancelButton.Text = "Close"
            Core.Helper.MainForm.CancelButton.Refresh()
        End If
    End Sub

    Private Sub LogInLabel7_Click(sender As Object, e As EventArgs) Handles LogInLabel7.Click
        LogInLabel7.ForeColor = Color.Blue
        Process.Start("https://toolslib.net/downloads/viewdownload/631-code-smart/")
        LogInLabel7.ForeColor = Color.DodgerBlue
    End Sub

End Class