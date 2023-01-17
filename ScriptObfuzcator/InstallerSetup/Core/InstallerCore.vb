Namespace Core

    Public Class InstallerCore

#Region " Properties "

        Private _InstallationDir As String = String.Empty

        Public Property InstallationDir As String
            Get
                Return _InstallationDir
            End Get
            Set(value As String)
                _InstallationDir = value
            End Set
        End Property

        Private _ExErrorMessage As String = String.Empty

        Public Property ExErrorMessage As String
            Get
                Return _ExErrorMessage
            End Get
            Set(value As String)
                _ExErrorMessage = value
            End Set
        End Property

        Private _ZipBytes As Byte() = Nothing

        Public Property ZipBytes As Byte()
            Get
                Return _ZipBytes
            End Get
            Set(value As Byte())
                _ZipBytes = value
            End Set
        End Property

        Private _Installed As Boolean = False
        Public Shadows Property Installed As Boolean
            Get
                Return _Installed
            End Get
            Set(value As Boolean)
                _Installed = value
             End Set
        End Property

        Private _InstallProgress As Integer = 0

        Public Property InstallProgress As Integer
            Get
                Return _InstallProgress
            End Get
            Set(value As Integer)
                _InstallProgress = value
            End Set
        End Property

#End Region

#Region " Declare "

        Dim ProgramFilesFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
        Dim PathSplitter As String = "\"
        Dim FolderName As String = "CodeSmart"
        Dim TempFolder As String = IO.Path.GetTempPath
        Dim TempFileZip As String = TempFolder & FolderName & ".zip"
        Dim MainFileName As String = "ScriptObfuzcator.exe"
        Public MainFileDir As String = String.Empty

#End Region

        Public Sub New()

            _InstallationDir = ProgramFilesFolder & PathSplitter & FolderName

            MainFileDir = IO.Path.Combine(_InstallationDir, MainFileName)

            _Installed = IO.Directory.Exists(_InstallationDir)

        End Sub

        Public Function Install() As Boolean
            Try
                If _ZipBytes Is Nothing Then
                    _ExErrorMessage = "No Zip Bytes"
                    Return False
                Else
                    IO.File.WriteAllBytes(TempFileZip, _ZipBytes)
                End If

                If IO.Directory.Exists(_InstallationDir) = True Then
                    Return True
                Else
                    IO.Directory.CreateDirectory(_InstallationDir)
                End If

                ZipFileWithProgress.ExtractToDirectory(TempFileZip, _InstallationDir,
                    New BasicProgress(Of Double)(
                        Sub(p)
                        Dim ValProgress As Integer = Val(p * 100)
                        If ValProgress <= 100 Then
                            _InstallProgress = ValProgress
                        End If
                    End Sub))
                IO.File.Delete(TempFileZip)
                Return True
            Catch ex As Exception
                _ExErrorMessage = ex.Message
                Return False
            End Try
        End Function

    End Class

End Namespace

