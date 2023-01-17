Namespace Core.Converter
    Public Class HTMLConverter

        Public Shared Function html2Bat(ByVal Source As String) As String

            Dim CodeMethod As String = <a><![CDATA[

<!-- :
REM Convert by CodeSmart : https://toolslib.net/downloads/viewdownload/631-code-smart/
@echo off
start "" mshta.exe "%~f0"
exit /b
-->

%HTMLCODE%

]]></a>.Value

            Dim ProcessSource As String = Source

            Dim FinalCode As String = CodeMethod.Replace("%HTMLCODE%", ProcessSource)

            Return FinalCode
        End Function

        Public Shared Function html2vbs(ByVal Source As String) As String
            Dim LineCodeMethod1 As String = "ar.writeline " & """" & " %LineCode%  " & """"
            Dim CodeMethod As String = <a><![CDATA[' Convert by CodeSmart : https://toolslib.net/downloads/viewdownload/631-code-smart/
Const TemporaryFolder = 2

Dim fso: Set fso = CreateObject("Scripting.FileSystemObject")

Dim tempFolder: tempFolder = fso.GetSpecialFolder(TemporaryFolder)

set b=createobject("wscript.shell")
Set objfso = createobject("scripting.filesystemobject")
Set ar= objfso.createtextfile(tempFolder & "Filetemp.html",true)

%htmlCode%

ar.close
b.run tempFolder & "Filetemp.html", 1, true

' Convert by CodeSmart : https://toolslib.net/downloads/viewdownload/631-code-smart/
]]></a>.Value

            Dim ProcessSource As String = Source

            Dim CreateLineCode As String = String.Empty

            For i As Integer = 0 To ProcessSource.Length - 1
                Dim c = ProcessSource(i)

                CreateLineCode += c

            Next


            Dim ConstructorCode As String = String.Empty

            For Each LineText As String In CreateLineCode.Split(vbLf)

                If Not LineText = "" Then

                    Dim LineC As String = String.Empty

                    LineC = LineCodeMethod1.Replace("%LineCode%", RemoveEmptyLines(LineText))

                    ConstructorCode += LineC + vbNewLine

                End If

            Next

            Dim FinalCode As String = CodeMethod.Replace("%htmlCode%", ConstructorCode)

            Return FinalCode
        End Function

        Private Shared ReadOnly TrimNewLineChars As Char() = Environment.NewLine.ToCharArray()

        Public Shared Function RemoveEmptyLines(ByVal str As String) As String
            If str Is Nothing Then
                Return Nothing
            End If

            Dim lines = str.Split(TrimNewLineChars, StringSplitOptions.RemoveEmptyEntries)
            Dim stringBuilder = New System.Text.StringBuilder(str.Length)

            For Each line In lines
                stringBuilder.AppendLine(line)
            Next

            Return stringBuilder.ToString().TrimEnd(TrimNewLineChars)
        End Function

    End Class
End Namespace

