Namespace Core

    Public Class Helper

        Public Shared InstallerInstanse As New InstallerCore
        Public Shared ComRegistered As New Core.COManager
        Public Shared MainForm As Form1 = Nothing

        Public Shared Sub ControlCorner(ctrl As Control, CurveSize As Integer)
            Dim p As New System.Drawing.Drawing2D.GraphicsPath

            p.StartFigure()
            p.AddArc(New Rectangle(0, 0, CurveSize, CurveSize), 180, 90)
            'p.AddLine(CurveSize, 0, ctrl.Width - CurveSize, 0)

            p.AddArc(New Rectangle(ctrl.Width - CurveSize, 0, CurveSize, CurveSize), -90, 90)
            'p.AddLine(ctrl.Width, CurveSize, ctrl.Width, ctrl.Height - CurveSize)

            p.AddArc(New Rectangle(ctrl.Width - CurveSize, ctrl.Height - CurveSize, CurveSize, CurveSize), 0, 90)
            'p.AddLine(ctrl.Width - 40, ctrl.Height, 40, ctrl.Height)

            p.AddArc(New Rectangle(0, ctrl.Height - CurveSize, CurveSize, CurveSize), 90, 90)
            p.CloseFigure()

            ctrl.Region = New Region(p)
            p.Dispose()
        End Sub

        Public Shared Sub Snooze(ByVal seconds As Integer)
            For i As Integer = 0 To seconds * 100
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
            Next
        End Sub

        ' Usage:
        '
        ' RenameFile("C:\Test.txt", "TeSt.TxT")
        ' RenameFile("C:\Test.txt", "Test", "doc")
        ' RenameFile(FileInfoObject.FullName, FileInfoObject.Name.ToLower, FileInfoObject.Extension.ToUpper)
        ' If RenameFile("C:\Test.txt", "TeSt.TxT") Is Nothing Then MsgBox("El archivo no existe!")

#Region " RenameFile function "

        Public Shared Function RenameFile(ByVal File As String, ByVal NewFileName As String, Optional ByVal NewFileExtension As String = Nothing)
            If IO.File.Exists(File) Then
                Try
                    Dim FileToBeRenamed As New System.IO.FileInfo(File)
                    If NewFileExtension Is Nothing Then
                        FileToBeRenamed.MoveTo(FileToBeRenamed.Directory.FullName & "\" & NewFileName) ' Rename file with same extension
                    Else
                        FileToBeRenamed.MoveTo(FileToBeRenamed.Directory.FullName & "\" & NewFileName & NewFileExtension) ' Rename file with new extension
                    End If
                    Return True ' File was renamed OK
                Catch ex As Exception
                    ' MsgBox(ex.Message)
                    Return False ' File can't be renamed maybe because User Permissions
                End Try
            Else
                Return Nothing ' File doesn't exist
            End If
        End Function

#End Region

#Region " Create ShortCut Function "

        ' [ Create ShortCut Function ]
        '
        ' // By Elektro H@cker
        '
        ' Examples :
        '
        ' Create_ShortCut(ShortcutPath.MyDocuments, "My APP Shortcut.lnk", "C:\File.exe")
        ' Create_ShortCut(ShortcutPath.Desktop, "My CMD Shortcut.lnk", "CMD.exe", "/C Echo Hello World & Pause")
        ' Create_ShortCut(ShortcutPath.Favorites, "My INTERNET Shortcut.lnk", "http://www.Google.com", , "CTRL+SHIFT+S")
        ' Create_ShortCut(ShortcutPath.Favorites, "My INTERNET Shortcut.lnk", "http://www.Google.com", , "CTRL+SHIFT+S", "Description of the shortcut")

        Enum ShortcutPath
            AppData = Environment.SpecialFolder.ApplicationData
            Desktop = Environment.SpecialFolder.Desktop
            Favorites = Environment.SpecialFolder.Favorites
            LocalAppData = Environment.SpecialFolder.LocalApplicationData
            MyDocuments = Environment.SpecialFolder.MyDocuments
            ProgramFiles = Environment.SpecialFolder.ProgramFiles
            ProgramFilesx86 = Environment.SpecialFolder.ProgramFilesX86
            StartMenu = Environment.SpecialFolder.StartMenu
            System32 = Environment.SpecialFolder.System
            SysWOW64 = Environment.SpecialFolder.SystemX86
            UserProfile = Environment.SpecialFolder.UserProfile
            Windows = Environment.SpecialFolder.Windows
        End Enum

        Public Shared Function Create_ShortCut(ByVal Shortcut_Path As ShortcutPath, _
                                ByVal Shortcut_Name As String, _
                                ByVal APP As String, _
                                Optional ByVal APP_Arguments As String = Nothing, _
                                Optional ByVal HotKey As String = Nothing, _
                                Optional ByVal Icon As String = Nothing, _
                                Optional ByVal Description As String = Nothing) As Boolean

            Dim Dir As String = Environment.GetFolderPath(Shortcut_Path)
            Dim WorkingDir As IO.FileInfo
            If Not APP.Contains("/") Then WorkingDir = New IO.FileInfo(APP) Else WorkingDir = Nothing
            Try
                Dim WSHShell As Object = CreateObject("WScript.Shell")
                Dim Shortcut As Object
                Shortcut = WSHShell.CreateShortcut(IO.Path.Combine(Dir, Shortcut_Name))
                Shortcut.TargetPath = APP
                Shortcut.Arguments = APP_Arguments
                Shortcut.WindowStyle = 2
                Shortcut.Hotkey = HotKey
                Shortcut.Description = Description
                If Not APP.Contains("/") Then Shortcut.WorkingDirectory = WorkingDir.DirectoryName
                If Icon IsNot Nothing Then Shortcut.IconLocation = Icon Else Shortcut.IconLocation = APP
                Shortcut.Save()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Function

#End Region

    End Class


End Namespace
