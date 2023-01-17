Imports CodeSmart.Core.Scintilla
Imports CodeSmart.Core.SettingsManager
Imports CodeSmart.Core.SettingsLoader

Public Class Form1

#Region " Declare "

    Public GetThemeApp As ThemeApp = ThemeApp.Dark
    Public GetProcesorMethod As ProcesorMethod = SettingLoader.GetProcesorMethod
    Public OptionsForm As Form = New Options With {.TopLevel = True, .Visible = False}
    Public WindowForm As Form = New Window With {.TopLevel = True, .Visible = False}
   
#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        StartAllRutines()
    End Sub

    Private Sub StartAllRutines()
        StartAllGui()
        ElektroKit.ThirdParty.ScintillaNet.Tools.ScintillaNetUtil.SetVbNetDarkStyle(Scintilla3)
        ComandLineArgs()
    End Sub

    Private Sub ComandLineArgs()
        Dim ArgsArray As String() = Environment.GetCommandLineArgs()
        For Each Arg As String In ArgsArray
            If Core.Utils.IsFolder(Arg) Then
                If IO.Directory.Exists(Arg) = True Then
                    Dim FilesEx As Array = Core.Utils.Get_All_Files(Arg, True)
                    For Each File In FilesEx
                        If IO.File.Exists(File) = True Then
                            AddEditorTap(File)
                        End If
                    Next
                End If
            Else
                If IO.File.Exists(Arg) = True Then
                    If Not Arg = Application.ExecutablePath Then
                        AddEditorTap(Arg)
                    End If
                End If
             End If
        Next
    End Sub


#Region " Gui "

    Public Sub UpdateSettings()
        GetThemeApp = LoadTheme()
        GetProcesorMethod = SettingLoader.GetProcesorMethod
        SetStyleApp(GetThemeApp)
        Dim BarStatus As Boolean = LoadShowStatusBarStatus()
        StatusBarToolStripMenuItem.Checked = BarStatus
    End Sub

    Private Sub StartAllGui()
        AddDragger(PanelHeader)
        AddDragger(GunaLabel1)
        AddDragger(GunaPictureBox1)
        AddDragger(GunaPanel2)
        SplitContainer1.SplitterWidth = 1
        SplitContainer2.SplitterWidth = 1
        UpdateSettings()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim CurrentTapsCount As Integer = TabVScontrol1.TabPages.Count
        If CurrentTapsCount = 0 Then
            AddEditorTap()
        End If
        Dim DirLbl As Label = GetLabelDirControl()
        Dim LexerLbl As Label = GetLabelLexerControl()
        If DirLbl IsNot Nothing Then
            If Not DirLbl.Text = "" Then
                Dim Lex As ScintillaNET.Lexer = GetLexer(IO.Path.GetExtension(DirLbl.Text))
                DebugLengCheck(Lex)
            Else


                If LexerLbl IsNot Nothing Then
                    If Not LexerLbl.Text = "" Then

                        Select Case LexerLbl.Text
                            Case "Batch" : DebugLengCheck(ScintillaNET.Lexer.Batch)
                            Case "VBS" : DebugLengCheck(ScintillaNET.Lexer.VbScript)
                        End Select

                    End If
                End If

            End If
        End If
    End Sub

    Private Sub DebugLengCheck(ByVal LexerEx As ScintillaNET.Lexer)
        BatchToolStripMenuItem.Checked = False
        VBSToolStripMenuItem.Checked = False
        Select Case LexerEx
            Case ScintillaNET.Lexer.Batch : BatchToolStripMenuItem.Checked = True
            Case ScintillaNET.Lexer.VbScript : VBSToolStripMenuItem.Checked = True
        End Select
    End Sub

    Private _ForeColor As Color = Color.White
    Private _BackColor As Color = Color.FromArgb(41, 44, 49)
    Private _OnHoverBaseColor As Color = Color.FromArgb(41, 44, 49)
    Private _OnHoverForeColor As Color = Color.FromArgb(41, 44, 49)

    Public Sub SetAllColor()
        Dim PanelsControl As New List(Of Guna.UI.WinForms.GunaPanel)
        PanelsControl.AddRange({Me.GunaPanel1, Me.GunaPanel2, Me.GunaPanel3, Me.GunaPanel4, Me.GunaPanel5, Me.GunaPanel6, Me.GunaPanel7, Me.GunaPanel8, Me.PanelHeader})
        For Each GPanels As Guna.UI.WinForms.GunaPanel In PanelsControl
            GPanels.ForeColor = _ForeColor
            GPanels.BackColor = _BackColor
            GunaResizeControl1.ForeColor = _ForeColor
            For Each SubsGControls In GPanels.Controls
                If TypeOf SubsGControls Is Guna.UI.WinForms.GunaButton Then
                    Dim NewSubsGControls As Guna.UI.WinForms.GunaButton = TryCast(SubsGControls, Guna.UI.WinForms.GunaButton)
                    NewSubsGControls.ForeColor = _ForeColor
                    NewSubsGControls.BackColor = _BackColor
                    NewSubsGControls.OnHoverBaseColor = _OnHoverBaseColor
                    NewSubsGControls.OnHoverForeColor = _ForeColor
                End If
                If TypeOf SubsGControls Is Guna.UI.WinForms.GunaLabel Then
                    Dim NewSubsGControls As Guna.UI.WinForms.GunaLabel = TryCast(SubsGControls, Guna.UI.WinForms.GunaLabel)
                    NewSubsGControls.ForeColor = _ForeColor
                    NewSubsGControls.BackColor = _BackColor
                End If
                If TypeOf SubsGControls Is Guna.UI.WinForms.GunaControlBox Then
                    Dim NewSubsGControls As Guna.UI.WinForms.GunaControlBox = TryCast(SubsGControls, Guna.UI.WinForms.GunaControlBox)
                    NewSubsGControls.IconColor = _ForeColor
                    NewSubsGControls.BackColor = _BackColor
                End If
            Next

        Next
        Select Case GetThemeApp
            Case ThemeApp.Dark : MenuStripZ1.BackColor = _BackColor
            Case ThemeApp.Light : MenuStripZ1.BackColor = Color.DodgerBlue
            Case ThemeApp.Blue : MenuStripZ1.BackColor = Color.FromArgb(54, 78, 114)
        End Select
        MenuStripZ1.ForeColor = _ForeColor
    End Sub

    Private Sub SetStyleApp(ByVal Style As ThemeApp)
      
        Select Case Style
            Case ThemeApp.Dark : TabVScontrol1.Style = TabVScontrol.Styles.Dark : TabVScontrol1.Refresh() : _BackColor = Color.FromArgb(41, 44, 49) : _OnHoverBaseColor = Color.FromArgb(41, 44, 49) : _ForeColor = Color.White : SetAllColor()
            Case ThemeApp.Light : TabVScontrol1.Style = TabVScontrol.Styles.Light : TabVScontrol1.Refresh() : _BackColor = Color.White : _OnHoverBaseColor = Color.WhiteSmoke : _ForeColor = Color.Black : SetAllColor()
            Case ThemeApp.Blue : TabVScontrol1.Style = TabVScontrol.Styles.Blue : TabVScontrol1.Refresh() : _BackColor = Color.FromArgb(54, 78, 114) : _OnHoverBaseColor = Color.WhiteSmoke : _ForeColor = Color.White : SetAllColor()
        End Select

        For Each TabPageC As TabPage In TabVScontrol1.TabPages

            For Each ControlsinTab As Control In TabPageC.Controls

                If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                    Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)

                    Select Case Style
                        Case ThemeApp.Dark : ElektroKit.ThirdParty.ScintillaNet.Tools.ScintillaNetUtil.SetVbNetDarkStyle(ControlVal)
                        Case ThemeApp.Light : ElektroKit.ThirdParty.ScintillaNet.Tools.ScintillaNetUtil.SetVbNetLightStyle(ControlVal)
                        Case ThemeApp.Blue : ElektroKit.ThirdParty.ScintillaNet.Tools.ScintillaNetUtil.SetVbNetLightStyle(ControlVal)
                    End Select


                End If

            Next

        Next

    End Sub

    Private Sub AddDragger(ByVal cControl As Control)
        Dim NewDragC As New Guna.UI.WinForms.GunaDragControl With {.TargetControl = cControl}
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

#Region " TapControl "

    Private Sub AddEditorTap(Optional ByVal FileDir As String = "")
        Dim TexEditor As New ScintillaNET.Scintilla With {.Dock = DockStyle.Fill, .BorderStyle = BorderStyle.None, .ScrollWidth = 2, .VScrollBar = False, .HScrollBar = False}
        Dim NewTabPage As New TabPage
        Dim LabelPatch As New Label With {.Name = "dirlbl", .Text = FileDir, .Visible = False}
        Dim LabelLexer As New Label With {.Name = "lexer", .Text = FileDir, .Visible = False}
        Dim AutoComplete As New AutocompleteMenuNS.AutocompleteMenu

        Select Case GetThemeApp
            Case ThemeApp.Dark : ElektroKit.ThirdParty.ScintillaNet.Tools.ScintillaNetUtil.SetVbNetDarkStyle(TexEditor)
            Case ThemeApp.Light : ElektroKit.ThirdParty.ScintillaNet.Tools.ScintillaNetUtil.SetVbNetLightStyle(TexEditor)
            Case ThemeApp.Blue : ElektroKit.ThirdParty.ScintillaNet.Tools.ScintillaNetUtil.SetVbNetLightStyle(TexEditor)
        End Select

        If Not FileDir = "" Then
            NewTabPage.Text = IO.Path.GetFileName(FileDir)
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
            NewTabPage.Text = "Untitle"
        End If

        NewTabPage.Controls.AddRange({TexEditor, LabelPatch, LabelLexer})
        TabVScontrol1.TabPages.Add(NewTabPage)
        TabVScontrol1.SelectTab(TabVScontrol1.TabPages.Count - 1)
        '  AutoComplete.Items()
        AutoComplete.TargetControlWrapper = New ScintillaWrapper(TexEditor)

        AddHandler TexEditor.TextChanged, AddressOf scintilla_TextChanged

    End Sub

    Private Sub scintilla_TextChanged(sender As Object, e As EventArgs)
        Dim CurrentScintilla As ScintillaNET.Scintilla = GetScintillaControl()
        If CurrentScintilla IsNot Nothing Then
            Dim LasWord As String = getLastWord(CurrentScintilla)

        End If
    End Sub


    Private Function getLastWord(scintilla As ScintillaNET.Scintilla) As String

        Dim word As String = ""

        Dim pos As Integer = scintilla.SelectionStart
        If pos > 1 Then

            Dim tmp As String = ""
            Dim f As New Char()
            While f <> " " And pos > 0
                pos -= 1
                tmp = scintilla.Text.Substring(pos, 1)
                f = CChar(tmp(0))
                word += f
            End While

            Dim ca As Char() = word.ToCharArray()
            Array.Reverse(ca)

            word = New [String](ca)
        End If
        Return word.Trim()

    End Function

    Private Function GetScintillaControl() As ScintillaNET.Scintilla
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                Return ControlVal

            End If

        Next

        Return Nothing
    End Function


    Private Function GetLabelDirControl() As Label
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is Label Then

                If ControlsinTab.Name = "dirlbl" Then
                    Dim ControlVal As Label = TryCast(ControlsinTab, Label)
                    Return ControlVal
                End If


            End If

        Next

        Return Nothing
    End Function

    Private Function GetLabelLexerControl() As Label
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is Label Then

                If ControlsinTab.Name = "lexer" Then
                    Dim ControlVal As Label = TryCast(ControlsinTab, Label)
                    Return ControlVal
                End If


            End If

        Next

        Return Nothing
    End Function

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
            Case ".js" : Return ScintillaNET.Lexer.Json
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

#Region " TabStrip "

#Region " File "

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        AddEditorTap()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileEx()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileEx()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveAsFileEx()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub OpenFileEx()
        Dim FilesOpen As List(Of String) = Core.Utils.OpenFile
        If Not FilesOpen Is Nothing Then
            For Each FileDir As String In FilesOpen
                AddEditorTap(FileDir)
            Next
        End If
    End Sub

    Private Sub SaveFileEx()
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab
        Dim CurrentText As String = String.Empty
        Dim FilePatch As String = String.Empty

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is Label Then

                If ControlsinTab.Name = "dirlbl" Then
                    Dim ControlVal As Label = TryCast(ControlsinTab, Label)
                    FilePatch = ControlVal.Text
                End If


            End If

            If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                CurrentText = ControlVal.Text

            End If

        Next

        If FilePatch = "" Then
            SaveAsFileEx()
        Else
            Dim SaveF As Boolean = Core.Utils.FileWriteText(FilePatch, CurrentText)
            If Not SaveF = True Then
                MsgBox(Core.Utils.FileManagerEx)
            End If
        End If

    End Sub

    Private Function SaveAsFileEx() As Boolean
        Try
            Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab
            Dim CurrentText As String = String.Empty
            Dim FilePatch As String = Core.Utils.SaveFile()
            If FilePatch Is Nothing Then
                Return False
            End If
            Dim CurrentLblb As Label = Nothing

            If Not FilePatch = Nothing Then

                For Each ControlsinTab As Control In CurrentTabControl.Controls

                    If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                        Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                        CurrentText = ControlVal.Text

                    End If

                    If TypeOf ControlsinTab Is Label Then
                        If ControlsinTab.Name = "dirlbl" Then
                            Dim ControlLblVal = TryCast(ControlsinTab, Label)
                            CurrentLblb = ControlLblVal
                            ControlLblVal.Text = FilePatch
                        End If
                    End If

                Next

                Dim SaveF As Boolean = Core.Utils.FileWriteText(FilePatch, CurrentText)
                If SaveF = True Then
                    CurrentTabControl.Text = IO.Path.GetFileName(FilePatch)
                    If CurrentLblb IsNot Nothing Then
                        CurrentLblb.Text = FilePatch
                    End If
                Else
                    MsgBox(Core.Utils.FileManagerEx)
                    Return False
                End If

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region " Edit "

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        UndoEx()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        RedoEx()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        CutEx()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        CopyEx()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        PasteEx()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        SelectAllEx()
    End Sub

    Private Sub QuickFindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickFindToolStripMenuItem.Click
        FindEx()
    End Sub

    Private Sub UndoEx()
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                ControlVal.Undo()

            End If

        Next
    End Sub

    Private Sub RedoEx()
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                ControlVal.Redo()

            End If

        Next
    End Sub

    Private Sub CutEx()
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                ControlVal.Cut()

            End If

        Next
    End Sub

    Private Sub CopyEx()
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                ControlVal.Copy()

            End If

        Next
    End Sub

    Private Sub PasteEx()
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                ControlVal.Paste()

            End If

        Next
    End Sub

    Private Sub SelectAllEx()
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                ControlVal.SelectAll()

            End If

        Next
    End Sub

    Private Sub FindEx()
        Dim CurrentTabControl As TabPage = TabVScontrol1.SelectedTab

        For Each ControlsinTab As Control In CurrentTabControl.Controls

            If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                Dim FindFormEx As Form = ControlVal.FindForm
                FindFormEx.ShowInTaskbar = True
                FindFormEx.Visible = True
                FindFormEx.Show()

            End If

        Next
    End Sub

#End Region

#Region " View "

    Private Sub OutputToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles OutputToolStripMenuItem.CheckedChanged
        LoadChecks()
    End Sub

    Private Sub StatusBarToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles StatusBarToolStripMenuItem.CheckedChanged
        GunaPanel2.Visible = StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub LoadChecks()
        If OutputToolStripMenuItem.Checked = True Then
            SplitContainer2.Panel2Collapsed = False
        Else
            SplitContainer2.Panel2Collapsed = True
        End If
    End Sub

#End Region

#Region " Window "

    Private Sub NewWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        Process.Start(Application.ExecutablePath)
    End Sub

    Private Sub CloseAllDocumentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllDocumentsToolStripMenuItem.Click
        TabVScontrol1.TabPages.Clear()
    End Sub

    Private Sub WindowToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles WindowToolStripMenuItem1.Click
        WindowForm.ShowDialog()
    End Sub

#End Region

#Region " Help "

    Private Sub ViewHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewHelpToolStripMenuItem.Click

    End Sub

    Private Sub GunaButton10_Click(sender As Object, e As EventArgs) Handles GunaButton10.Click
        Process.Start("https://www.patreon.com/S4Lsalsoft")
    End Sub


    Private Sub ReportABugToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportABugToolStripMenuItem.Click
        Process.Start("https://www.patreon.com/posts/code-smart-47179971")
    End Sub

    Private Sub ForumTopicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForumTopicToolStripMenuItem.Click

    End Sub

    Private Sub AboutLominousToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutLominousToolStripMenuItem.Click
        AboutFrm.ShowDialog()
    End Sub

    Private Sub AboutXylonAntivirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutXylonAntivirToolStripMenuItem.Click
        Process.Start("https://github.com/DestroyerDarkNess/XylonAntivir")
    End Sub

#End Region

#Region " Tools "

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        OptionsForm.ShowDialog()
    End Sub

    Private Sub ObfuzcatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObfuzcatorToolStripMenuItem.Click
        ShowObfuzcator()
    End Sub

    Private Sub GunaButton12_Click(sender As Object, e As EventArgs) Handles GunaButton12.Click
        ShowXylonScanner()
    End Sub

    Private Sub GunaButton11_Click(sender As Object, e As EventArgs) Handles GunaButton11.Click
        ShowObfuzcator()
    End Sub

    Private Sub ScriptConverterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScriptConverterToolStripMenuItem.Click
        ShowConverter()
    End Sub

    Private Sub GunaButton13_Click(sender As Object, e As EventArgs) Handles GunaButton13.Click
        ShowConverter()
    End Sub

    Private Sub ShowConverter()
        Dim DirLbl As Label = GetLabelDirControl()
        Dim CurrentScintilla As ScintillaNET.Scintilla = GetScintillaControl()
        Dim PropertiesForm As New Converter '= TryCast(ObfuzcationForm, Obfuzcator)
        PropertiesForm.SetTextByText(CurrentScintilla.Text)
        If Not DirLbl.Text = "" Then
            PropertiesForm.SetLexer(DirLbl.Text)
        End If
        PropertiesForm.Show()
    End Sub

    Private Sub ShowObfuzcator()
        Dim DirLbl As Label = GetLabelDirControl()
        Dim CurrentScintilla As ScintillaNET.Scintilla = GetScintillaControl()
        Dim PropertiesForm As New Obfuzcator '= TryCast(ObfuzcationForm, Obfuzcator)
        PropertiesForm.SetTextByText(CurrentScintilla.Text)
        If Not DirLbl.Text = "" Then
            PropertiesForm.SetLexer(DirLbl.Text)
        End If
        PropertiesForm.Show()
    End Sub

    Private Sub ShowXylonScanner()
         Dim DirLbl As Label = GetLabelDirControl()
        Dim CurrentScintilla As ScintillaNET.Scintilla = GetScintillaControl()
        Dim PropertiesForm As New XylonScanner
        If Not CurrentScintilla.Text = "" Then
            If DirLbl IsNot Nothing Then

                If Not DirLbl.Text = "" Then
                    PropertiesForm.SetPath(DirLbl.Text)
                Else
                    Dim FileTempPatch As String = String.Empty
                    Dim DebugType As String = GunaComboBox1.Items(GunaComboBox1.SelectedIndex)
                    Dim TempDir As String = Core.Utils.TempDir & "TempScan.txt"

                    Dim SaveF As Boolean = Core.Utils.FileWriteText(TempDir, CurrentScintilla.Text)
                    If Not SaveF = True Then
                        MsgBox(Core.Utils.FileManagerEx)
                        Exit Sub
                    End If
                    FileTempPatch = TempDir
                    PropertiesForm.SetPath(FileTempPatch)
                End If

            End If
            PropertiesForm.Show()
        End If
    End Sub

#End Region

#Region " Debug "

    Private Sub WindowsDefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsDefaultToolStripMenuItem.Click
        If WindowsDefaultToolStripMenuItem.Checked = True Then
            Dim LexerLbl As Label = GetLabelLexerControl()
            If LexerLbl IsNot Nothing Then
                LexerLbl.Text = "Null"
            End If
            BatchToolStripMenuItem.Checked = False
            VBSToolStripMenuItem.Checked = False
        End If
     End Sub

    Private Sub BatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BatchToolStripMenuItem.Click
        If BatchToolStripMenuItem.Checked = True Then
            Dim LexerLbl As Label = GetLabelLexerControl()
            If LexerLbl IsNot Nothing Then
                LexerLbl.Text = "Batch"
            End If
            WindowsDefaultToolStripMenuItem.Checked = False
            VBSToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub VBSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VBSToolStripMenuItem.Click
        If VBSToolStripMenuItem.Checked = True Then
            Dim LexerLbl As Label = GetLabelLexerControl()
            If LexerLbl IsNot Nothing Then
                LexerLbl.Text = "VBS"
            End If
            WindowsDefaultToolStripMenuItem.Checked = False
            BatchToolStripMenuItem.Checked = False
        End If
    End Sub

#End Region

#End Region

#Region " BarFuncs "

    Private Sub GunaButton8_Click(sender As Object, e As EventArgs) Handles GunaButton8.Click
        Process.Start(Application.ExecutablePath)
    End Sub

    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButton7.Click
        AddEditorTap()
    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        OpenFileEx()
    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        SaveFileEx()
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        SaveAsFileEx()
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        UndoEx()
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        RedoEx()
    End Sub

#End Region

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        OutputToolStripMenuItem.Checked = True
        Dim DirLbl As Label = GetLabelDirControl()
        Dim CurrentScintilla As ScintillaNET.Scintilla = GetScintillaControl()
        Dim LexerLbl As Label = GetLabelLexerControl()

        If DirLbl IsNot Nothing Then
            If Not DirLbl.Text = "" Then

                Dim Lex As ScintillaNET.Lexer = GetLexer(IO.Path.GetExtension(DirLbl.Text))
                Select Case Lex
                    Case ScintillaNET.Lexer.Batch : BatchDebugger2(DirLbl, CurrentScintilla)
                    Case ScintillaNET.Lexer.VbScript : VBSDebugger2(DirLbl, CurrentScintilla)
                    Case Else
                        OutputToolStripMenuItem.Checked = False
                        DefaultDebbuger(DirLbl, CurrentScintilla)
                End Select

            Else
                If LexerLbl IsNot Nothing Then

                    If Not LexerLbl.Text = "" Then

                        Select Case LexerLbl.Text
                            Case "Batch" : BatchDebugger2(DirLbl, CurrentScintilla)
                            Case "VBS" : VBSDebugger2(DirLbl, CurrentScintilla)
                            Case "Null" : DefaultDebbuger(DirLbl, CurrentScintilla)
                        End Select

                    Else
                        Dim LexerSelectorEx As New LexerDebugSelector
                        '  LexerSelector.Size = Me.Size
                        LexerSelectorEx.ShowDialog()
                        If LexerSelectorEx.GunaButton1.DialogResult = Windows.Forms.DialogResult.OK Then
                            '    MsgBox(LexerSelectorEx.LexerSelector.ToString)
                            Select Case LexerSelectorEx.LexerSelector
                                Case ScintillaNET.Lexer.Batch : LexerLbl.Text = "Batch" : BatchDebugger2(DirLbl, CurrentScintilla)
                                Case ScintillaNET.Lexer.VbScript : LexerLbl.Text = "VBS" : VBSDebugger2(DirLbl, CurrentScintilla)
                                Case ScintillaNET.Lexer.Null : LexerLbl.Text = "Null" : DefaultDebbuger(DirLbl, CurrentScintilla)
                            End Select
                        End If
                    End If
                End If

            End If
        End If

    End Sub

#Region " CenterForm function "

    Function CenterForm(ByVal Form_to_Center As Form, ByVal Form_Location As Point) As Point
        Dim FormLocation As New Point
        FormLocation.X = (Me.Left + (Me.Width - Form_to_Center.Width) / 2) ' set the X coordinates.
        FormLocation.Y = (Me.Top + (Me.Height - Form_to_Center.Height) / 2) ' set the Y coordinates.
        Return FormLocation ' return the Location to the Form it was called from.
    End Function

#End Region

#Region " Debug "

    Public Sub DefaultDebbuger(ByVal DirLbl As Label, ByVal CurrentScintilla As ScintillaNET.Scintilla)
        ClearLog()
        Dim FileTempPatch As String = String.Empty
        If Not DirLbl.Text = "" Then
            FileTempPatch = DirLbl.Text
        Else
            Dim SaveFile As Boolean = SaveAsFileEx()
            If SaveFile = True Then
                DefaultDebbuger(DirLbl, CurrentScintilla)
            End If
           Exit Sub
        End If
        SetLog("'" & IO.Path.GetFileName(FileTempPatch) & "'" & " (Managed (Code Smart)): Loaded '" & FileTempPatch & "'", False)
        SetLog("'" & IO.Path.GetFileName(FileTempPatch) & "'" & " Startting Host...", False)
        If IO.File.Exists(FileTempPatch) Then
            Process.Start(FileTempPatch)
        End If
        SetLog("'" & IO.Path.GetFileName(FileTempPatch) & "'" & " End Host...", False)
        SetLog("'" & IO.Path.GetFileName(FileTempPatch) & "'" & ": ' has exited with code 0 (0x0)." & vbNewLine, False)
    End Sub

    Public Sub VBSDebugger2(ByVal DirLbl As Label, ByVal CurrentScintilla As ScintillaNET.Scintilla)
        ClearLog()
        SetStatus("Debuting", Color.FromArgb(202, 81, 0))
        Dim FileTempPatch As String = String.Empty
        If Not DirLbl.Text = "" Then
            FileTempPatch = DirLbl.Text
        Else
            Dim TempDir As String = Core.Utils.TempDir & "TempBatch.vbs"
            If IO.File.Exists(TempDir) = True Then
                IO.File.Delete(TempDir)
            End If
            Dim SaveF As Boolean = Core.Utils.FileWriteText(TempDir, CurrentScintilla.Text)
            If Not SaveF = True Then
                MsgBox(Core.Utils.FileManagerEx)
                Exit Sub
            End If
            FileTempPatch = TempDir
        End If

        Dim VBSDebugger As New Core.VBS.Debugger
        Dim DebugResult As Core.VBS.DebugResult = VBSDebugger.RunCMDHost(FileTempPatch)
        If DebugResult.IsCurrentError = True Then
            SetStatus("An error has occurred. Check Ouput", Color.Red)
            SetLog("Line: " & DebugResult.Line & "     |   Number Char : " & DebugResult.NumberText & vbNewLine & " Exeption Error : " & DebugResult.ExeptionInfo & vbNewLine & vbNewLine & _
                   "Command error : " & DebugResult.ErrorCommand)

            CurrentScintilla.Lines(DebugResult.Line).Goto()
        Else
            SetStatus("Debugging Finished", Color.Lime)
        End If
    End Sub


    Public Sub BatchDebugger2(ByVal dirlbl2 As Label, ByVal Scintilla2 As ScintillaNET.Scintilla)
        ClearLog()
        SetStatus("Debuting", Color.FromArgb(202, 81, 0))
        Dim FileTempPatch As String = String.Empty
        Dim DebugType As String = GunaComboBox1.Items(GunaComboBox1.SelectedIndex)
        If Not dirlbl2.Text = "" Then
            FileTempPatch = dirlbl2.Text
        Else
            Dim TempDir As String = Core.Utils.TempDir & "TempBatch.bat"
            If IO.File.Exists(TempDir) = True Then
                IO.File.Delete(TempDir)
            End If
            Dim SaveF As Boolean = Core.Utils.FileWriteText(TempDir, Scintilla2.Text)
            If Not SaveF = True Then
                MsgBox(Core.Utils.FileManagerEx)
                Exit Sub
            End If
            FileTempPatch = TempDir
        End If
        SetLog("'" & IO.Path.GetFileName(FileTempPatch) & "'" & " (Managed (CMD Host)): Loaded '" & FileTempPatch & "'", False)
        SetLog("'" & IO.Path.GetFileName(FileTempPatch) & "'" & " Startting Host...", False)
        Dim cmdProcess As New Process
        With cmdProcess
            .StartInfo = New ProcessStartInfo(FileTempPatch)
            With .StartInfo
                .UseShellExecute = False
            End With
            .Start()
            .WaitForExit()
        End With
        SetLog("'" & IO.Path.GetFileName(FileTempPatch) & "'" & " End Host...", False)
        SetLog("'" & IO.Path.GetFileName(FileTempPatch) & "'" & ": ' has exited with code 0 (0x0)." & vbNewLine, False)
        SetStatus("Debugging Finished", Color.Lime)
    End Sub


#End Region

#Region " Log "

    Public Sub SetLog(ByVal TextNew As String, Optional ByVal ShowTime As Boolean = False)

        If ShowTime = True Then

            Dim LocalDate As String = My.Computer.Clock.LocalTime.ToString.Split(" ").First
            Dim LocalTime As String = My.Computer.Clock.LocalTime.ToString.Split(" ").Last
            Dim LogDate As String = "[ " & LocalDate & " ] " & " [ " & LocalTime & " ]  "

            Scintilla3.Text += LogDate & " >> " & TextNew & vbNewLine
        Else

            Scintilla3.Text += TextNew & vbNewLine

        End If


    End Sub

    Public Sub SetStatus(ByVal TextNew As String, ByVal Ccolor As Color)
        GunaPanel2.BackColor = Ccolor
        Label1.Text = TextNew
        Core.Utils.Snooze(2)
        Label1.Text = "Ready"
        GunaPanel2.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Public Sub ClearLog()
        Scintilla3.Text = ""
    End Sub


#End Region

    Private Sub GunaButton9_Click(sender As Object, e As EventArgs) Handles GunaButton9.Click
        Process.Start("https://www.paypal.me/SalvadorKrilewski")
    End Sub

End Class
