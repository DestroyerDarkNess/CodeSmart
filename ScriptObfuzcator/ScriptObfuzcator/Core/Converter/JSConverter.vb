Namespace Core.Converter

    Public Class JSConverter

        Public Shared Function JS2Bat(ByVal Source As String) As String

            Dim CodeMethod As String = <a><![CDATA[

@if (true == false) @end /*!
@echo off
REM Convert by CodeSmart : https://toolslib.net/downloads/viewdownload/631-code-smart/
mshta "about:<script src='file://%~f0'></script><script>close()</script>" %*
goto :EOF */

%CODE%

]]></a>.Value

            Dim ProcessSource As String = Source

            Dim FinalCode As String = CodeMethod.Replace("%CODE%", ProcessSource)

            Return FinalCode
        End Function


        Public Shared Function JS2Bat2(ByVal Source As String) As String

            Dim CodeLine1 As String = "::'@echo off &cscript //nologo //e:jscript " & """" & "%~f0" & """"
            Dim CodeLine2 As String = "::'>nul pause & REM Delete this line in case you don't want to pause at the end of the execution"
            Dim CodeLine3 As String = "::'exit /b"
            Dim CodeLine4 As String = ""
            Dim CodeLine5 As String = "%CODE%"

            Dim CodeMethod As String = CodeLine1 & vbNewLine & CodeLine2 & vbNewLine & CodeLine3 & vbNewLine & vbNewLine & CodeLine4 & vbNewLine & CodeLine5

            Dim ProcessSource As String = Source

            Dim FinalvbsCode As String = CodeMethod.Replace("%CODE%", ProcessSource)

            Return FinalvbsCode
        End Function

    End Class

End Namespace

