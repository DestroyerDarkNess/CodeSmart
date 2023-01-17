Imports System.Text.RegularExpressions

Namespace Core.Batch

    Public Class DebugResult

        Private _Line As Integer = -1
        Public Property Line As Integer
            Get
                Return _Line
            End Get
            Set(value As Integer)
                _Line = value
            End Set
        End Property

        Private _NumberText As Integer = -1
        Public Property NumberText As Integer
            Get
                Return _NumberText
            End Get
            Set(value As Integer)
                _NumberText = value
            End Set
        End Property

        Private _ExeptionInfo As String = String.Empty
        Public Property ExeptionInfo As String
            Get
                Return _ExeptionInfo
            End Get
            Set(value As String)
                _ExeptionInfo = value
            End Set
        End Property

        Private _ErrorCommand As String = String.Empty
        Public Property ErrorCommand As String
            Get
                Return _ErrorCommand
            End Get
            Set(value As String)
                _ErrorCommand = value
            End Set
        End Property

        Private _IsCurrentError As Boolean = False
        Public Property IsCurrentError As Boolean
            Get
                Return _IsCurrentError
            End Get
            Set(value As Boolean)
                _IsCurrentError = value
            End Set
        End Property

    End Class

    Public Class Debugger

        Private ResultFound As Boolean = False
        Private DebugPath As String = Utils.TempDir & "DebugResult.txt"
        Private BatchLauncher2 As String = "@echo off & echo Starting VBS Script Host & cls & cscript %File% 2>&1 & pause"
        Private BatchLauncher As String = "%File%"
        Public Ouput As String = String.Empty

        Public Function RunCMDHost(ByVal File As String) As DebugResult
            Dim FilePath As String = """" & File & """"
            Dim BatchLaunch As String = BatchLauncher.Replace("%File%", FilePath)

            Dim cmdProcess As New Process
            With cmdProcess
                .StartInfo = New ProcessStartInfo("cmd.exe", BatchLaunch)
                With .StartInfo
                    .CreateNoWindow = True
                    .UseShellExecute = False
                    .RedirectStandardOutput = True
                End With
                .Start()
                .WaitForExit()
            End With

            Dim HostOutput As String = cmdProcess.StandardOutput.ReadToEnd
            Ouput = HostOutput
            Dim DebugResultEx As New DebugResult

            Dim ProxexorResult As String = HostOutput

            ProxexorResult = Utils.GetTextLine(File, ProxexorResult)
            ProxexorResult = ProxexorResult.Replace(File, "")

            Dim ProxLineNumber As String = Regex.Match(ProxexorResult, "\(([^)]*)\)").Groups(1).Value
            If ProxLineNumber = "" Then
                DebugResultEx.IsCurrentError = False
                Return DebugResultEx
            Else
                Dim LineAndNumber As String() = ProxLineNumber.Split(",")
                Dim ExeptionMsg As String = ProxexorResult.Replace("(" & ProxLineNumber & ")", "")
                Dim GetError As String = Utils.GetTextIntoSymbol(ExeptionMsg, "'")

                DebugResultEx.IsCurrentError = True
                DebugResultEx.Line = LineAndNumber(0)
                DebugResultEx.NumberText = LineAndNumber(1)
                DebugResultEx.ExeptionInfo = ExeptionMsg
                DebugResultEx.ErrorCommand = GetError

                Return DebugResultEx
            End If

        End Function


        Declare Function AttachConsole Lib "kernel32.dll" (ByVal dwProcessId As Int32) As Boolean
        Declare Function FreeConsole Lib "kernel32.dll" () As Boolean

        Public Shared Sub AttachConsole()
            AttachConsole(-1) ' Attach the console
            System.Console.WriteLine("I am writing from a WinForm to the console!")
            FreeConsole() ' Desattach the console
        End Sub

        Public Declare Function AllocConsole Lib "kernel32.dll" () As Boolean

        Public Shared Sub AllocCMD()
            AllocConsole()
            System.Console.WriteLine("this is my console!")

            Threading.Thread.Sleep(5000)
        End Sub




    End Class
End Namespace

