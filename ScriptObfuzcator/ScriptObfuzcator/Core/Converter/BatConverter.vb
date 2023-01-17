Namespace Core.Converter
    Public Class BatConverter


        Private Shared LineCodeMethod1 As String = "ar.writeline " & """" & " %LineCode%  "
        Private Shared CodeMethod1 As String = <a><![CDATA[' Convert by CodeSmart : https://toolslib.net/downloads/viewdownload/631-code-smart/
Const TemporaryFolder = 2

Dim fso: Set fso = CreateObject("Scripting.FileSystemObject")

Dim tempFolder: tempFolder = fso.GetSpecialFolder(TemporaryFolder)

set b=createobject("wscript.shell")
Set objfso = createobject("scripting.filesystemobject")
Set ar= objfso.createtextfile(tempFolder & "archivo.bat",true)

%BatCode%

ar.close
b.run tempFolder & "archivo.bat", 1, true

' Convert by CodeSmart : https://toolslib.net/downloads/viewdownload/631-code-smart/
]]></a>.Value


        Public Shared Function Bat2vbs(ByVal batSource As String) As String
            Dim ProcessSource As String = batSource

            Dim CreateLineCode As String = String.Empty

            For i As Integer = 0 To ProcessSource.Length - 1
                Dim c = ProcessSource(i)

                If c = "&" Then
                    CreateLineCode += """" & " : ar.writeline " & """"
                ElseIf c = """" Then
                    CreateLineCode += """" & """"
                ElseIf c = "%" Then
                    CreateLineCode += "%"

                Else

                    CreateLineCode += c

                End If

            Next


            Dim ConstructorCode As String = String.Empty

            For Each LineText As String In CreateLineCode.Split(vbLf)

                If Not LineText = "" Then

                    Dim LineC As String = String.Empty
                   
                    LineC = LineCodeMethod1.Replace("%LineCode%", RemoveEmptyLines(LineText) & " " & """")

                    ConstructorCode += LineC + vbNewLine

                End If

            Next

            Dim FinalvbsCode As String = CodeMethod1.Replace("%BatCode%", ConstructorCode)

            Return FinalvbsCode
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

