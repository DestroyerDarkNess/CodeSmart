Imports Xylon_Antivir.Lxib

Public Class XylonScanner

    Dim Engine As Antivir = New Antivir()
    Dim EngineHash As Hash = New Hash()

    Private Sub XylonScanner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        Me.Location = Form1.CenterForm(Me, Me.Location)
        StartAllRutines()
    End Sub


    Private Sub StartAllRutines()
        StartAllGui()
    End Sub

#Region " Gui "

    Private Sub StartAllGui()
        AddDragger(PanelHeader)
        AddDragger(GunaLabel1)
        AddDragger(GunaPictureBox1)
        AddDragger(GunaPanel1)
       UpdateSettings()
    End Sub

    Public Sub UpdateSettings()

    End Sub

    Private Sub AddDragger(ByVal cControl As Control)
        Dim NewDragC As New Guna.UI.WinForms.GunaDragControl With {.TargetControl = cControl}
    End Sub

#End Region

#Region " Methods "

    Dim SplitLine As String = "-------------------------------------------------"

    Public Sub SetPath(ByVal FilePath As String)
        If IO.File.Exists(FilePath) = True Then
            GunaLabel3.Text = FilePath
            Dim ScanResult As String = Engine.FileScan(FilePath, True, False, False)

            If ScanResult <> "False" Then
                Dim VirusInfo As String() = ScanResult.Split("|".ToCharArray())
                Dim FilePathEx As String = VirusInfo(0)
                Dim VirusDefinition As String = VirusInfo(1)
                DetectionLBL.Text = "Name: " & IO.Path.GetFileNameWithoutExtension(FilePathEx) & vbNewLine & _
                    " Path : " & FilePathEx & vbNewLine & _
                    " Sig: [" & VirusDefinition & "]" & vbNewLine & vbNewLine & SplitLine & vbNewLine & vbNewLine
                CircleProgressBar1.Value += 36
                Dim md5 As String = EngineHash.Get_MD5_Of_File(FilePath)
                Dim shad1 As String = EngineHash.Get_SHA1_Of_File(FilePath)
                Dim shad256 As String = EngineHash.Get_Shad256_Of_File(FilePath)
                DetectionLBL.Text += "MD5: " & md5 & vbNewLine & "Shad1: " & shad1 & vbNewLine & "Shad256: " & shad256 & vbNewLine & vbNewLine & SplitLine & vbNewLine & vbNewLine
                CircleProgressBar1.Value += 10
                Dim GetFileInvokes As List(Of String) = Engine.ScanFileWinAPI(FilePath)
                If Not GetFileInvokes.Count = 0 Then
                    For Each PinvokeStr As String In GetFileInvokes
                        If Not CircleProgressBar1.Value = 100 Then
                            CircleProgressBar1.Value += 1
                        End If
                        ListBox1.Items.Add(PinvokeStr)
                    Next
                    GunaLabel5.Visible = True
                    ListBox1.Visible = True
                End If
                If CircleProgressBar1.Value < 20 Then
                    CircleProgressBar1.ProgressColor = Color.LightYellow
                ElseIf CircleProgressBar1.Value > 21 And CircleProgressBar1.Value < 40 Then
                    CircleProgressBar1.ProgressColor = Color.Yellow
                ElseIf CircleProgressBar1.Value > 41 And CircleProgressBar1.Value < 50 Then
                    CircleProgressBar1.ProgressColor = Color.Orange
                ElseIf CircleProgressBar1.Value > 51 And CircleProgressBar1.Value < 55 Then
                    CircleProgressBar1.ProgressColor = Color.OrangeRed
                ElseIf CircleProgressBar1.Value > 55 Then
                    CircleProgressBar1.ProgressColor = Color.Red
                End If
                CircleProgressBar1.ProgressColor = Color.Red
            Else
                DetectionLBL.Text = SplitLine & vbNewLine & "Secure Script" & vbNewLine & SplitLine
                DetectionLBL.ForeColor = Color.Lime
                CircleProgressBar1.ProgressColor = Color.Lime
            End If
        Else
            Me.Close()
        End If
    End Sub

#End Region

    Private Sub SaveAsFileEx(ByVal Filename As String, ByVal rText As String)
        Dim CurrentText As String = String.Empty
        Dim FilePatch As String = Core.Utils.SaveFile(Filename, "Text file|*.txt")

        If Not FilePatch = Nothing Then
            CurrentText = rText
            Dim SaveF As Boolean = Core.Utils.FileWriteText(FilePatch, CurrentText)
            If SaveF = False Then
                MsgBox(Core.Utils.FileManagerEx)
            End If

        End If

    End Sub


    Private Sub GunaControlBox1_Click(sender As Object, e As EventArgs) Handles GunaControlBox1.Click
        Me.Close()
    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        Dim Report As String = "[CodeSmart Xylon Antivir Report]" & vbNewLine & "Official Page : " & "https://toolslib.net/downloads/viewdownload/631-code-smart/" & vbNewLine
        Report += "Suspicious Percent: " & CircleProgressBar1.Value & vbNewLine & vbNewLine & "Report : " & vbNewLine & DetectionLBL.Text & vbNewLine
        SaveAsFileEx("CodeSmart AV Report", Report)
    End Sub
End Class