Public Class Options

    Private Sub Options_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim Theme As String = GunaComboBox1.Items(GunaComboBox1.SelectedIndex)
        Core.SettingsLoader.SaveTheme(Theme)

        Form1.UpdateSettings()
    End Sub

    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
   End Sub

#Region " Environment "

#Region " Visual Experience "
   
    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox1.CheckedChanged
        Core.SettingsLoader.SettingLoader.GetBarStatus = GunaCheckBox1.Checked
    End Sub

    Private Sub GunaCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox2.CheckedChanged
        Core.SettingsLoader.SettingLoader.GraphicsOptic = GunaCheckBox2.Checked
    End Sub

#End Region

#End Region


End Class