Imports CodeSmart.Core.SettingsManager
Imports CodeSmart.Core.SettingsLoader

Public Class Converter

#Region " Declare "

    Public GetThemeApp As ThemeApp = ThemeApp.Dark
    Public GetProcesorMethod As ProcesorMethod = SettingLoader.GetProcesorMethod

#End Region

    Private Sub Converter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        StartAllRutines()
    End Sub

    Private Sub StartAllRutines()
        StartAllGui()
    End Sub

#Region " Heredate Text "

    Public Sub SetTextByFile(ByVal FileName As String)
        AddEditorTap(FileName)
    End Sub

    Public Sub SetTextByText(ByVal CodeText As String)
        If Not CodeText = "" Then
            Scintilla1.Text = CodeText
        End If

    End Sub

#End Region

#Region " Gui "

    Private Sub StartAllGui()
        GetThemeApp = LoadTheme()
        AddDragger(PanelHeader)
        AddDragger(GunaLabel1)
        AddDragger(GunaPictureBox1)
        AddDragger(GunaPanel2)
        SplitContainer1.SplitterWidth = 1
        SplitContainer2.SplitterWidth = 1
        UpdateSettings()
    End Sub

    Public Sub UpdateSettings()
        SetStyleApp(GetThemeApp)
    End Sub

    Private Sub SetStyleApp(ByVal Style As ThemeApp)
        GetThemeApp = Style

        Dim ScintillaControls As New List(Of ScintillaNET.Scintilla)
        ScintillaControls.Clear()
        ScintillaControls.AddRange({Scintilla1, Scintilla2})

        For Each ControlVal As ScintillaNET.Scintilla In ScintillaControls

            ElektroKit.ThirdParty.ScintillaNet.Tools.ScintillaNetUtil.SetVbNetDarkStyle(ControlVal)

        Next

    End Sub

    Private Sub AddDragger(ByVal cControl As Control)
        Dim NewDragC As New Guna.UI.WinForms.GunaDragControl With {.TargetControl = cControl}
    End Sub

    Private Sub GunaControlBox1_Click(sender As Object, e As EventArgs) Handles GunaControlBox1.Click
        Me.Close()
    End Sub

#End Region

#Region " Resizer "

    Private Resizer As ControlResizer = ControlResizer.Empty

    Private Sub InitializeResizer()
        Me.Resizer = New ControlResizer(Me)
        Me.Resizer.Enabled = True
        Me.Resizer.PixelMargin = 4
    End Sub

    Private Sub Test() Handles MyBase.Shown
        Me.InitializeResizer()
    End Sub

#End Region

#Region " Lexer "

    Public Sub SetLexer(ByVal FileName As String)
        Dim FileLexer As ScintillaNET.Lexer = GetLexer(IO.Path.GetExtension(FileName))
        Scintilla1.Lexer = FileLexer
        Scintilla2.Lexer = FileLexer
        If FileLexer = ScintillaNET.Lexer.Batch Then
            GunaComboBox1.StartIndex = 0
        ElseIf FileLexer = ScintillaNET.Lexer.VbScript Then
            GunaComboBox1.StartIndex = 1
        ElseIf FileLexer = ScintillaNET.Lexer.Html Then
            GunaComboBox1.StartIndex = 2
        ElseIf FileLexer = ScintillaNET.Lexer.Json Then
            GunaComboBox1.StartIndex = 3
        End If
        GunaComboBox1.Refresh()
    End Sub

    Public Function GetLexer(ByVal FileFormat As String) As ScintillaNET.Lexer
        Select Case LCase(FileFormat)
            Case ".ada" : Return ScintillaNET.Lexer.Ada
            Case ".asm" : Return ScintillaNET.Lexer.Asm
            Case ".asn" : Return ScintillaNET.Lexer.Asm
            Case ".bat" : Return ScintillaNET.Lexer.Batch
            Case ".cmd" : Return ScintillaNET.Lexer.Batch
            Case ".nt" : Return ScintillaNET.Lexer.Batch
            Case ".bb" : Return ScintillaNET.Lexer.BlitzBasic
                ' Case ".ct" : Return ScintillaNET.Lexer.Container
                'c++
            Case ".cpp" : Return ScintillaNET.Lexer.Cpp
            Case ".cc" : Return ScintillaNET.Lexer.Cpp
            Case ".cxx" : Return ScintillaNET.Lexer.Cpp
            Case ".h" : Return ScintillaNET.Lexer.Cpp
            Case ".hh" : Return ScintillaNET.Lexer.Cpp
            Case ".hpp" : Return ScintillaNET.Lexer.Cpp
            Case ".hxx" : Return ScintillaNET.Lexer.Cpp
            Case ".ino" : Return ScintillaNET.Lexer.Cpp
                'Cascade Style Sheet
            Case ".css" : Return ScintillaNET.Lexer.Css
                'Fortran
            Case ".f" : Return ScintillaNET.Lexer.Fortran
            Case ".for" : Return ScintillaNET.Lexer.Fortran
            Case ".f90" : Return ScintillaNET.Lexer.Fortran
            Case ".f95" : Return ScintillaNET.Lexer.Fortran
            Case ".f2k" : Return ScintillaNET.Lexer.Fortran
            Case ".f23" : Return ScintillaNET.Lexer.Fortran
                'FreeBasic
            Case ".bas" : Return ScintillaNET.Lexer.FreeBasic
            Case ".bi" : Return ScintillaNET.Lexer.FreeBasic
                '
            Case ".html" : Return ScintillaNET.Lexer.Html
            Case ".hta" : Return ScintillaNET.Lexer.Html
                '
            Case ".json" : Return ScintillaNET.Lexer.Json
                '
            Case ".lsp" : Return ScintillaNET.Lexer.Lisp
            Case ".lisp" : Return ScintillaNET.Lexer.Lisp
                'Lua
            Case ".lua" : Return ScintillaNET.Lexer.Lua
                '
            Case ".mak" : Return ScintillaNET.Lexer.Markdown
            Case ".mk" : Return ScintillaNET.Lexer.Markdown
                '
            Case ".pas" : Return ScintillaNET.Lexer.Pascal
            Case ".pp" : Return ScintillaNET.Lexer.Pascal
            Case ".p" : Return ScintillaNET.Lexer.Pascal
            Case ".inc" : Return ScintillaNET.Lexer.Pascal
            Case ".lpr" : Return ScintillaNET.Lexer.Pascal
                '
            Case ".pl" : Return ScintillaNET.Lexer.Perl
            Case ".pm" : Return ScintillaNET.Lexer.Perl
            Case ".plx" : Return ScintillaNET.Lexer.Perl
                '
            Case ".php" : Return ScintillaNET.Lexer.PhpScript
            Case ".phps" : Return ScintillaNET.Lexer.PhpScript
            Case ".php3" : Return ScintillaNET.Lexer.PhpScript
            Case ".php4" : Return ScintillaNET.Lexer.PhpScript
            Case ".php5" : Return ScintillaNET.Lexer.PhpScript
            Case ".phpt" : Return ScintillaNET.Lexer.PhpScript
            Case ".phtml" : Return ScintillaNET.Lexer.PhpScript
                '
            Case ".ps1" : Return ScintillaNET.Lexer.PowerShell
            Case ".psm1" : Return ScintillaNET.Lexer.PowerShell
                '
            Case ".properties" : Return ScintillaNET.Lexer.Properties
                '
            Case ".pb" : Return ScintillaNET.Lexer.PureBasic
                '
            Case ".py" : Return ScintillaNET.Lexer.Python
            Case ".pyw" : Return ScintillaNET.Lexer.Python
                '
            Case ".r" : Return ScintillaNET.Lexer.R
            Case ".s" : Return ScintillaNET.Lexer.R
            Case ".splus" : Return ScintillaNET.Lexer.R
                '
            Case ".rb" : Return ScintillaNET.Lexer.Ruby
            Case ".rbw" : Return ScintillaNET.Lexer.Ruby
                '
            Case ".st" : Return ScintillaNET.Lexer.Smalltalk
                '
            Case ".sql" : Return ScintillaNET.Lexer.Sql
                '
            Case ".vb" : Return ScintillaNET.Lexer.Vb
            Case ".vbs" : Return ScintillaNET.Lexer.VbScript
            Case ".wsf" : Return ScintillaNET.Lexer.VbScript
                '
            Case ".v" : Return ScintillaNET.Lexer.Verilog
            Case ".sv" : Return ScintillaNET.Lexer.Verilog
            Case ".vh" : Return ScintillaNET.Lexer.Verilog
            Case ".svh" : Return ScintillaNET.Lexer.Verilog
                '
            Case ".xml" : Return ScintillaNET.Lexer.Xml
            Case ".xaml" : Return ScintillaNET.Lexer.Xml
            Case ".xsl" : Return ScintillaNET.Lexer.Xml
            Case ".xslt" : Return ScintillaNET.Lexer.Xml
            Case ".xsd" : Return ScintillaNET.Lexer.Xml
            Case ".xul" : Return ScintillaNET.Lexer.Xml
            Case ".kml" : Return ScintillaNET.Lexer.Xml
            Case ".svg" : Return ScintillaNET.Lexer.Xml
            Case ".mxml" : Return ScintillaNET.Lexer.Xml
            Case ".xsml" : Return ScintillaNET.Lexer.Xml

            Case Else

                Return ScintillaNET.Lexer.Null

        End Select
    End Function


#End Region

#Region " File Manager "

    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButton7.Click
        AddEditorTap()
    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        OpenFileEx()
    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        SaveFileEx(Scintilla1, dirlbl)
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        SaveAsFileEx(Scintilla1, dirlbl)
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        Scintilla1.Undo()
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Scintilla1.Redo()
    End Sub

    Private Sub GunaButton11_Click(sender As Object, e As EventArgs) Handles GunaButton11.Click
        Scintilla2.Undo()
    End Sub

    Private Sub GunaButton12_Click(sender As Object, e As EventArgs) Handles GunaButton12.Click
        Scintilla2.Redo()
    End Sub

    Private Sub GunaButton8_Click(sender As Object, e As EventArgs) Handles GunaButton8.Click
        SaveFileEx(Scintilla2, dirlbl2)
    End Sub

    Private Sub GunaButton9_Click(sender As Object, e As EventArgs) Handles GunaButton9.Click
        SaveAsFileEx(Scintilla2, dirlbl2)
    End Sub

    Private Sub AddEditorTap(Optional ByVal FileDir As String = "")
        Dim TexEditor As ScintillaNET.Scintilla = Scintilla1
        Dim LabelPatch As Label = dirlbl
        Dim AutoComplete As New AutocompleteMenuNS.AutocompleteMenu

        If Not FileDir = "" Then
            If GetProcesorMethod = ProcesorMethod.Sync Then
                TexEditor.Text = Core.Utils.FileReadText(FileDir)
            ElseIf GetProcesorMethod = ProcesorMethod.Async Then

                Dim Asynctask As New Task(New Action(Async Function()
                                                         Dim FileAsyncText As String = Await Core.Utils.FileReadTextAsync(FileDir)
                                                         Me.BeginInvoke(Sub()
                                                                            TexEditor.Text = FileAsyncText
                                                                        End Sub)
                                                     End Function), TaskCreationOptions.PreferFairness)
                Asynctask.Start()

            End If
            TexEditor.Lexer = GetLexer(IO.Path.GetExtension(FileDir))
        Else
            Scintilla1.Text = ""
            Scintilla2.Text = ""
        End If

    End Sub

    Private Sub OpenFileEx()
        Dim FilesOpen As List(Of String) = Core.Utils.OpenFile
        If Not FilesOpen Is Nothing Then
            For Each FileDir As String In FilesOpen
                AddEditorTap(FileDir)
            Next
        End If
    End Sub

    Private Sub SaveFileEx(ByVal TextControl As ScintillaNET.Scintilla, ByVal DirLabelControl As Label)
        Dim CurrentText As String = String.Empty
        Dim FilePatch As String = String.Empty

        FilePatch = DirLabelControl.Text
        CurrentText = TextControl.Text

        If FilePatch = "" Then
            SaveAsFileEx(TextControl, DirLabelControl)
        Else
            Dim SaveF As Boolean = Core.Utils.FileWriteText(FilePatch, CurrentText)
            If Not SaveF = True Then
                MsgBox(Core.Utils.FileManagerEx)
            End If
        End If

    End Sub

    Private Sub SaveAsFileEx(ByVal TextControl As ScintillaNET.Scintilla, ByVal DirLabelControl As Label)

        If Not Scintilla2.Text = "" Then

            Dim Format As String = "Auto Format|" & GetFormat()

            Dim CurrentText As String = String.Empty

            Dim FilePatch As String = Core.Utils.SaveFile("", Format)
            Dim CurrentLblb As Label = Nothing

            If Not FilePatch = Nothing Then
                CurrentText = TextControl.Text
                CurrentLblb = DirLabelControl

                Dim SaveF As Boolean = Core.Utils.FileWriteText(FilePatch, CurrentText)
                If SaveF = True Then
                    If CurrentLblb IsNot Nothing Then
                        CurrentLblb.Text = FilePatch
                    End If
                Else
                    MsgBox(Core.Utils.FileManagerEx)
                End If

            End If


        End If

    End Sub

#End Region

#Region " Code Manager "

    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        Dim Language As String = GunaComboBox1.Items(GunaComboBox1.SelectedIndex)
        GunaComboBox2.items.clear()
        Select Case LCase(Language)
            Case "batch" : Scintilla1.Lexer = GetLexer(".bat") : Scintilla2.Lexer = GetLexer(".bat")
                GunaComboBox2.Items.AddRange({"VBS"})
            Case "vbs" : Scintilla1.Lexer = GetLexer(".vbs") : Scintilla2.Lexer = GetLexer(".vbs")
                GunaComboBox2.Items.AddRange({"Batch (javascript Engine)", "Batch (vbscript Engine)"})
            Case "html" : Scintilla1.Lexer = GetLexer(".html") : Scintilla2.Lexer = GetLexer(".html")
                GunaComboBox2.Items.AddRange({"Batch (mshta.exe)", "VBS (Browser)"})
            Case "javascript" : Scintilla1.Lexer = GetLexer(".js") : Scintilla2.Lexer = ScintillaNET.Lexer.Batch
                GunaComboBox2.Items.AddRange({"Batch (mshta.exe)", "Batch (cscript.exe)"})
        End Select
        GunaComboBox2.StartIndex = 0
    End Sub

    Private Sub GunaComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox2.SelectedIndexChanged
        ExecuteConverter()
    End Sub

    Private Sub ExecuteConverter()
        If Not Scintilla1.Text = "" Then
            Dim LanguageIn As String = LCase(GunaComboBox1.Items(GunaComboBox1.SelectedIndex))
            Dim LanguageOut As String = LCase(GunaComboBox2.Items(GunaComboBox2.SelectedIndex))

            Select Case LCase(LanguageIn)
                Case "batch"

                    If LanguageOut = "vbs" Then
                        Scintilla2.Text = Core.Converter.BatConverter.Bat2vbs(Scintilla1.Text)

                    End If

                Case "vbs"

                    If LanguageOut = LCase("Batch (javascript Engine)") Then
                        Scintilla2.Text = Core.Converter.VBSConverter.VBS2Bat(Scintilla1.Text)
                    ElseIf LanguageOut = LCase("Batch (vbscript Engine)") Then
                        Scintilla2.Text = Core.Converter.VBSConverter.VBS2Bat2(Scintilla1.Text)
                    End If

                Case "html"

                    If LanguageOut = LCase("Batch (mshta.exe)") Then
                        Scintilla2.Text = Core.Converter.HTMLConverter.html2Bat(Scintilla1.Text)
                    ElseIf LanguageOut = LCase("VBS (Browser)") Then
                        Scintilla2.Text = Core.Converter.HTMLConverter.html2vbs(Scintilla1.Text)
                    End If

                Case "javascript"

                    If LanguageOut = LCase("Batch (mshta.exe)") Then
                        Scintilla2.Text = Core.Converter.JSConverter.JS2Bat(Scintilla1.Text)
                    ElseIf LanguageOut = LCase("Batch (cscript.exe)") Then
                        Scintilla2.Text = Core.Converter.JSConverter.JS2Bat2(Scintilla1.Text)
                    End If

            End Select
        End If
    End Sub

    Private Function GetFormat() As String
        Dim LanguageIn As String = LCase(GunaComboBox1.Items(GunaComboBox1.SelectedIndex))
        Dim LanguageOut As String = LCase(GunaComboBox2.Items(GunaComboBox2.SelectedIndex))

        Select Case LCase(LanguageIn)
            Case "batch"

                If LanguageOut = "vbs" Then
                    Return ".vbs"
                End If

            Case "vbs"

                If LanguageOut = LCase("Batch (javascript Engine)") Then
                    Return ".bat"
                ElseIf LanguageOut = LCase("Batch (vbscript Engine)") Then
                    Return ".bat"
                End If

            Case "html"

                If LanguageOut = LCase("Batch (mshta.exe)") Then
                    Return ".bat"
                ElseIf LanguageOut = LCase("VBS (Browser)") Then
                    Return ".vbs"
                End If

            Case "javascript"

                If LanguageOut = LCase("Batch (mshta.exe)") Then
                    Return ".bat"
                ElseIf LanguageOut = LCase("Batch (cscript.exe)") Then
                    Return ".bat"
                End If

        End Select

        Return String.Empty
    End Function


#End Region

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

        If Not Scintilla2.Text = "" Then
            Try
                Dim format As String = GetFormat()
                If Not format = String.Empty Then
                    Dim FileTempPatch As String = String.Empty
                    If Not dirlbl2.Text = "" Then
                        FileTempPatch = dirlbl2.Text
                    Else
                        Dim TempDir As String = Core.Utils.TempDir & "TempFile" & format
                        If IO.File.Exists(TempDir) = True Then
                            IO.File.Delete(TempDir)
                        End If
                        Dim SaveF As Boolean = Core.Utils.FileWriteText(TempDir, Scintilla2.Text)
                        If Not SaveF = True Then
                            MsgBox(Core.Utils.FileManagerEx)
                            Exit Sub
                        End If

                        FileTempPatch = TempDir

                        If IO.File.Exists(FileTempPatch) Then
                            Process.Start(FileTempPatch)
                        End If

                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
      
    End Sub

    
End Class