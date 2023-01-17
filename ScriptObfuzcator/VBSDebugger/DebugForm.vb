Imports System.Windows.Forms

Public Class DebugForm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Clipboard.SetText(RichTextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveAsFileEx()
    End Sub

    Private Sub SaveAsFileEx()
        Dim CurrentText As String = RichTextBox1.Text
        Dim FilePatch As String = SaveFile()
     
        If Not FilePatch = Nothing Then

            Try
                IO.File.WriteAllText(FilePatch, CurrentText)
            Catch ex As Exception

            End Try

        End If

    End Sub

    Public Shared Function SaveFile() As String
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.FileName = ""
       SaveFileDialog1.Title = "Save file"
        SaveFileDialog1.Filter = "Text File|*.txt"

        If Not SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Return SaveFileDialog1.FileName
        End If

        Return Nothing

    End Function

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.SelectionStart = Len(RichTextBox1.Text)
        RichTextBox1.ScrollToCaret()
        RichTextBox1.Select()
    End Sub

#Region " Console "

    Public Sub WriteConsole(ByVal TextEnv As String)
        Dim LocalDate As String = My.Computer.Clock.LocalTime.ToString.Split(" ").First
        Dim LocalTime As String = My.Computer.Clock.LocalTime.ToString.Split(" ").Last
        Dim LogDate As String = "[ " & LocalDate & " ] " & " [ " & LocalTime & " ]   >> "
        RichTextBox1.Text += LogDate & TextEnv & vbNewLine
    End Sub

#End Region

End Class