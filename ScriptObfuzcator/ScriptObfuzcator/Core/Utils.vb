Namespace Core

    Public Class Utils


        Public Shared Sub Snooze(ByVal seconds As Integer)
            For i As Integer = 0 To seconds * 100
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
            Next
        End Sub

#Region " Dir "

        Public Shared TempDir As String = IO.Path.GetTempPath

        Public Shared Function IsFolder(ByVal path As String) As Boolean
            Return ((IO.File.GetAttributes(path) And IO.FileAttributes.Directory) = IO.FileAttributes.Directory)
        End Function

        Public Shared Function Get_All_Files(ByVal Directory As String, Optional ByVal Recursive As Boolean = False) As Array
            If System.IO.Directory.Exists(Directory) Then
                If Not Recursive Then : Return System.IO.Directory.GetFiles(Directory, "*", IO.SearchOption.TopDirectoryOnly)
                Else : Return IO.Directory.GetFiles(Directory, "*", IO.SearchOption.AllDirectories)
                End If
            Else
                Return Nothing
            End If
        End Function

#End Region

#Region " File Funcs "

        Public Shared FileManagerEx As String = String.Empty

        Public Shared Function FileWriteText(ByVal FileDir As String, Optional ByVal ContentText As String = "") As Boolean
            Try
                Dim swEx As New IO.StreamWriter(FileDir, False)
                swEx.Write(ContentText)
                swEx.Close()
                Return True
            Catch ex As Exception
                FileManagerEx = ex.Message
                Return False
            End Try
        End Function


        Public Shared Function FileReadText(ByVal FileDir As String) As String
            Try
                Dim swEx As New IO.StreamReader(FileDir, False)
                Dim ReadAllText As String = swEx.ReadToEnd
                swEx.Close()
                Return ReadAllText
            Catch ex As Exception
                FileManagerEx = ex.Message
                Return "Error!"
            End Try
        End Function

        Public Shared Async Function FileReadTextAsync(ByVal FileDir As String) As Task(Of String)
            Try
                Dim swEx As New IO.StreamReader(FileDir, False)
                Dim ReadAllText As String = Await swEx.ReadToEndAsync()
                swEx.Close()
                Return ReadAllText
            Catch ex As Exception
                FileManagerEx = ex.Message
                Return "Error!"
            End Try
        End Function


        Public Shared Function OpenFile() As List(Of String)
            Dim OpenFileDialog1 As New OpenFileDialog
            ' OpenFileDialog1.DefaultExt = "txt"
            OpenFileDialog1.FileName = ""
            '  OpenFileDialog1.InitialDirectory = "c:\"
            OpenFileDialog1.Title = "Select file"
            OpenFileDialog1.Filter = "All files|*.*|" & _
                "All files Suported|*.txt;*.ada;*.asm;*.asn;*.asn;*.bat;*.cmd;*.nt;*.bb;*.cpp;*.cc;*.cxx;*.h;*.hh;*.hpp;*.hxx;*.ino;" & _
                "*.css;*.f;*.for;*.f90;*.f95;*.f2k;*.f23;*.bas;*.bi;*.html;*.hta;*.json;*.js;*.lsp;*.lisp;*.lua;*.mak;*.mk;*.pas;*.pp;" & _
                "*.p;*.inc;*.lpr;*.pl;*.pm;*.plx;*.php;*.phps;*.php3;*.php4;*.php5;*.phpt;*.phtml;*.ps1;*.psm1;*.properties;*.pb;*.py;*.pyw;" & _
                "*.r;*.s;*.splus;*.rb;*.rbw;*.st;*.sql;*.vb;*.vbs;*.wsf;*.v;*.sv;*.vh;*.svh;*.xml;*.xaml;*.xsl;*.xslt;*.xsd;*.xul;*.kml;*.svg;*.mxml;*.xsml|" & _
                "Ada Script|*.ada|" & _
                "ASM|*.asm;*.asn|" & _
                "Batch|*.bat;*.cmd;*.nt|" & _
                "BlitzBasic|*.bb|" & _
                "C++|*.cpp;*.cc;*.cxx;*.h;*.hh;*.hpp;*.hxx;*.ino|" & _
                "Cascade Style Sheet|*.css|" & _
                "Fortran|*.f;*.for;*.f90;*.f95;*.f2k;*.f23|" & _
                "FreeBasic|*.bas;*.bi|" & _
                "HTML|*.html;*.hta|" & _
                "JavaScript|*.js;*.json|" & _
                "Lisp|*.lisp;*.lsp|" & _
                "Lua|*.lua|" & _
                "Markdown|*.mak;*.mk|" & _
                "Pascal|*.pas;*.pp;*.p;*.inc;*.lpr|" & _
                "Perl|*.pl;*.pm;*.plx|" & _
                "PHP|*.php;*.phps;*.php3;*.php4;*.php5;*.phpt;*.phtml|" & _
                "PowerShell|*.ps1;*.psm1|" & _
                "Properties|*.properties|" & _
                "PureBasic|*.pb|" & _
                "Python|*.py;*.pyw|" & _
                "R Script|*.r;*.s;*.splus|" & _
                "Ruby|*.rb;*.rbw|" & _
                "Smalltalk|*.st|" & _
                "Sql|*.sql|" & _
                "Visual Basic|*.vb;*.vbproj|" & _
                "Visual Basic Script|*.vbs;*.wsf|" & _
                "Verilog|*.v;*.sv;*.vh;*.svh|" & _
                "XML|*.xml;*.xaml;*.xsl;*.xslt;*.xsd;*.xul;*.kml;*.svg;*.mxml;*.xsml"

            Dim ListFiles As New List(Of String)

            If Not OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then
                ListFiles.AddRange(OpenFileDialog1.FileNames)
                Return ListFiles
            End If

            Return Nothing

        End Function

        Public Shared Function SaveFile(Optional ByVal NameFile As String = "", Optional ByVal Formats As String = "") As String
            Dim SaveFileDialog1 As New SaveFileDialog
            ' OpenFileDialog1.DefaultExt = "txt"
            SaveFileDialog1.FileName = NameFile
            '  OpenFileDialog1.InitialDirectory = "c:\"
            SaveFileDialog1.Title = "Save file"
            If Not Formats = "" Then
                SaveFileDialog1.Filter = Formats
            Else
                SaveFileDialog1.Filter = "All files|*.*|" & _
                "All files Suported|*.txt;*.ada;*.asm;*.asn;*.asn;*.bat;*.cmd;*.nt;*.bb;*.cpp;*.cc;*.cxx;*.h;*.hh;*.hpp;*.hxx;*.ino;" & _
                "*.css;*.f;*.for;*.f90;*.f95;*.f2k;*.f23;*.bas;*.bi;*.html;*.hta;*.json;*.js;*.lsp;*.lisp;*.lua;*.mak;*.mk;*.pas;*.pp;" & _
                "*.p;*.inc;*.lpr;*.pl;*.pm;*.plx;*.php;*.phps;*.php3;*.php4;*.php5;*.phpt;*.phtml;*.ps1;*.psm1;*.properties;*.pb;*.py;*.pyw;" & _
                "*.r;*.s;*.splus;*.rb;*.rbw;*.st;*.sql;*.vb;*.vbs;*.wsf;*.v;*.sv;*.vh;*.svh;*.xml;*.xaml;*.xsl;*.xslt;*.xsd;*.xul;*.kml;*.svg;*.mxml;*.xsml|" & _
                "Ada Script (*.ada)|*.ada|" & _
                "ASM (*.asm;*.asn)|*.asm;*.asn|" & _
                "Batch (*.bat;*.cmd;*.nt)|*.bat;*.cmd;*.nt|" & _
                "BlitzBasic (*.bb)|*.bb|" & _
                "C++ (*.cpp;*.cc;*.cxx;*.h;*.hh;*.hpp;*.hxx;*.ino)|*.cpp;*.cc;*.cxx;*.h;*.hh;*.hpp;*.hxx;*.ino|" & _
                "Cascade Style Sheet (*.css)|*.css|" & _
                "Fortran (*.f;*.for;*.f90;*.f95;*.f2k;*.f23)|*.f;*.for;*.f90;*.f95;*.f2k;*.f23|" & _
                "FreeBasic (*.bas;*.bi)|*.bas;*.bi|" & _
                "HTML (*.html;*.hta)|*.html;*.hta|" & _
                "JavaScript (*.js;*.json)|*.js;*.json|" & _
                "Lisp (*.lisp;*.lsp)|*.lisp;*.lsp|" & _
                "Lua (*.lua)|*.lua|" & _
                "Markdown (*.mak;*.mk)|*.mak;*.mk|" & _
                "Pascal (*.pas;*.pp;*.p;*.inc;*.lpr)|*.pas;*.pp;*.p;*.inc;*.lpr|" & _
                "Perl (*.pl;*.pm;*.plx)|*.pl;*.pm;*.plx|" & _
                "PHP (*.php;*.phps;*.php3;*.php4;*.php5;*.phpt;*.phtml)|*.php;*.phps;*.php3;*.php4;*.php5;*.phpt;*.phtml|" & _
                "PowerShell (*.ps1;*.psm1)|*.ps1;*.psm1|" & _
                "Properties (*.properties)|*.properties|" & _
                "PureBasic (*.pb)|*.pb|" & _
                "Python (*.py;*.pyw)|*.py;*.pyw|" & _
                "R Script (*.r;*.s;*.splus)|*.r;*.s;*.splus|" & _
                "Ruby (*.rb;*.rbw)|*.rb;*.rbw|" & _
                "Smalltalk (*.st)|*.st|" & _
                "Sql (*.sql)|*.sql|" & _
                "Visual Basic (*.vb;*.vbproj)|*.vb;*.vbproj|" & _
                "Visual Basic Script (*.vbs;*.wsf)|*.vbs;*.wsf|" & _
                "Verilog (*.v;*.sv;*.vh;*.svh)|*.v;*.sv;*.vh;*.svh|" & _
                "XML (*.xml;*.xaml;*.xsl;*.xslt;*.xsd;*.xul;*.kml;*.svg;*.mxml;*.xsml)|*.xml;*.xaml;*.xsl;*.xslt;*.xsd;*.xul;*.kml;*.svg;*.mxml;*.xsml"


            End If

            If Not SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Return SaveFileDialog1.FileName
            End If

            Return Nothing

        End Function

#End Region

#Region " Internet Funcs "

        ' [ Is Connectivity Avaliable? Function ]
        '
        ' Examples :
        ' MsgBox(Is_Connectivity_Avaliable())
        ' While Not Is_Connectivity_Avaliable() : Application.DoEvents() : End While

        Private Function Is_Connectivity_Avaliable()

            Dim WebSites() As String = {"Google.com", "Facebook.com", "Microsoft.com"}

            If My.Computer.Network.IsAvailable Then
                For Each WebSite In WebSites
                    Try
                        My.Computer.Network.Ping(WebSite)
                        Return True ' Network connectivity is OK.
                    Catch : End Try
                Next
                Return False ' Network connectivity is down.
            Else
                Return False ' No network adapter is connected.
            End If

        End Function

#End Region

#Region " Text Funcs "



        Private Function removeLines(ByVal textInLineToFind As String, ByVal selectedTextBox As TextBox) As String
            Dim arTemp As String() = selectedTextBox.Lines '// set all lines from TextBox into a String Array.
            Dim sTemp As String = "" '// clear for new input.
            For Each txtLine As String In arTemp '// loop thru all arrays.
                If Not txtLine.Contains(textInLineToFind) Then '// check for line that contains preselected text and skip if .Contains.
                    '// if not in line, add to string.
                    If Not sTemp = "" Then sTemp &= vbNewLine & txtLine Else sTemp = txtLine
                End If
            Next
            Return sTemp '// return text back to TextBox.
        End Function


        Public Shared Function GetTextLine(ByVal textInLineToFind As String, ByVal selectedText As String) As String
            Dim LinesTextFormat As String() = selectedText.Split(vbNewLine)
            For Each LinesText As String In LinesTextFormat
                If LinesText.Contains(textInLineToFind) Then
                    Return LinesText
                End If
            Next
            Return ""
        End Function

        Public Shared Function GetTextIntoSymbol(ByVal TextToGet As String, ByVal Simbol As String) As String
            Dim FinalResult As String = String.Empty
            Dim myChars() As Char = TextToGet.ToCharArray()

            Dim Encounter As Boolean = False
            Dim FinishCicle As Boolean = False

            For Each ch As Char In myChars

                If FinishCicle = True Then
                    Exit For
                End If

                If Encounter = True Then
                    FinalResult += ch
                End If

                If ch = Simbol Then
                    If Encounter = False Then
                        Encounter = True
                    Else
                        Encounter = False
                        FinishCicle = True
                    End If
               End If

            Next

            Return FinalResult.Replace(Simbol, "")
        End Function

#End Region

#Region " Array Funcs "

        ' [ Remove Item From Array ]
        '
        ' Examples :
        ' Dim MyArray() As String = {"Elektro", "H@cker", "Christian"}
        ' Remove_Item_From_Array(MyArray, 0)               ' Remove first element => {"H@cker", "Christian"}
        ' Remove_Item_From_Array(MyArray, UBound(MyArray)) ' Remove last element => {"Elektro", "H@cker"}

        Public Sub Remove_Item_From_Array(Of T)(ByRef Array_Name() As T, ByVal Index As Integer)
            Array.Copy(Array_Name, Index + 1, Array_Name, Index, UBound(Array_Name) - Index)
            ReDim Preserve Array_Name(UBound(Array_Name) - 1)
        End Sub

        ' [ Join Array Function ]
        '
        ' Examples :
        ' Dim MyArray() As String = {"Hola", "que", "ase?"}
        ' MsgBox(Join_Array(MyArray, vbNewLine))
        ' MsgBox(Join_Array(MyArray, vbNewLine, True))

        Private Function Join_Array(ByRef Array_Name As Array, ByVal Separator As String, _
                                    Optional ByVal Enumerate As Boolean = False) As String

            Try
                If Enumerate Then
                    Dim Index As Int64 = 0
                    Dim Joined_str As String = String.Empty

                    For Each Item In Array_Name
                        Joined_str += Index & ". " & Item & Separator
                        Index += 1
                    Next

                    Return Joined_str
                Else
                    Return String.Join(Separator, Array_Name)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try

        End Function

#End Region

#Region " Sleep "

        ' [ Sleep ]
        '
        ' Examples :
        ' Sleep(5) : MsgBox("Test")
        ' Sleep(5, Measure.Seconds) : MsgBox("Test")

        Public Enum Measure
            Milliseconds = 1
            Seconds = 2
            Minutes = 3
            Hours = 4
        End Enum

        Private Sub Sleep(ByVal Duration As Int64, Optional ByVal Measure As Measure = Measure.Seconds)

            Dim Starttime = DateTime.Now

            Select Case Measure
                Case Measure.Milliseconds : Do While (DateTime.Now - Starttime).TotalMilliseconds < Duration : Application.DoEvents() : Loop
                Case Measure.Seconds : Do While (DateTime.Now - Starttime).TotalSeconds < Duration : Application.DoEvents() : Loop
                Case Measure.Minutes : Do While (DateTime.Now - Starttime).TotalMinutes < Duration : Application.DoEvents() : Loop
                Case Measure.Hours : Do While (DateTime.Now - Starttime).TotalHours < Duration : Application.DoEvents() : Loop
                Case Else
            End Select

        End Sub

#End Region

#Region " Add Application To Startup "

        ' [ Add Application To Startup Function ]
        '
        ' Examples :
        ' Add_Application_To_Startup(Startup_User.All_Users)
        ' Add_Application_To_Startup(Startup_User.Current_User)
        ' Add_Application_To_Startup(Startup_User.Current_User, "Application Name", """C:\ApplicationPath.exe""" & " -Arguments")

        Public Enum Startup_User
            Current_User
            All_Users
        End Enum

        Private Function Add_Application_To_Startup(ByVal Startup_User As Startup_User, _
                                                Optional ByVal Application_Name As String = Nothing, _
                                                Optional ByVal Application_Path As String = Nothing) As Boolean

            If Application_Name Is Nothing Then Application_Name = Process.GetCurrentProcess().MainModule.ModuleName
            If Application_Path Is Nothing Then Application_Path = Application.ExecutablePath

            Try
                Select Case Startup_User
                    Case Startup_User.All_Users
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run", Application_Name, Application_Path, Microsoft.Win32.RegistryValueKind.String)
                    Case Startup_User.Current_User
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application_Name, Application_Path, Microsoft.Win32.RegistryValueKind.String)
                End Select
            Catch ex As Exception
                ' Throw New Exception(ex.Message)
                Return False
            End Try
            Return True

        End Function

#End Region

    End Class

End Namespace

