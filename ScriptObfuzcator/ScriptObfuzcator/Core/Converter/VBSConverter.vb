Namespace Core.Converter
    Public Class VBSConverter


        Public Shared Function VBS2Bat(ByVal Source As String) As String

            Dim CodeMethod As String = <a><![CDATA[
@if (true == false) @end /*
@echo off
Rem Convert by CodeSmart : https://toolslib.net/downloads/viewdownload/631-code-smart/
set "SYSDIR=SysWOW64"
if "%PROCESSOR_ARCHITECTURE%" == "x86" if not defined PROCESSOR_ARCHITEW6432 set "SYSDIR=System32"
"%WINDIR%\%SYSDIR%\cscript.exe" //nologo //e:javascript "%~f0" %*
goto :EOF */

(function(readFile, code)
{
    var e;
    try {
        var vb = new ActiveXObject('MSScriptControl.ScriptControl');
        vb.Language = 'VBScript';
        vb.AddObject('WScript', WScript, true);
        vb.AddCode(code);
    } catch(e) {
        var file = readFile();
        var prologLen = file.slice(0, file.indexOf(code)).split('\n').length;
        var vbe = vb.Error;
        WScript.Echo(
            WScript.ScriptFullName + 
            '(' + ( prologLen + vbe.Line - 1 ) + ', ' + vbe.Column + ') ' + 
            vbe.Source + ': ' + vbe.Description);
    }
})(
function()
{
    var fso = new ActiveXObject('Scripting.FileSystemObject');
    var f = fso.OpenTextFile(WScript.ScriptFullName, 1, true);
    var file = f.ReadAll();
    f.Close();
    return file;
}, 
(function()
{
    return arguments.callee.toString().replace(/^[\s\S]+\/\*|\*\/[\s\S]+$/g, '');
/* ' VBScript

' Convert by CodeSmart : https://toolslib.net/downloads/viewdownload/631-code-smart/

%CODE%

' Convert by CodeSmart : https://toolslib.net/downloads/viewdownload/631-code-smart/

*/
})());

]]></a>.Value

            Dim ProcessSource As String = Source

            Dim FinalvbsCode As String = CodeMethod.Replace("%CODE%", ProcessSource)

            Return FinalvbsCode
        End Function

        Public Shared Function VBS2Bat2(ByVal Source As String) As String

            Dim CodeLine1 As String = "::'@echo off &cscript //nologo //e:vbscript " & """" & "%~f0" & """"
            Dim CodeLine2 As String = "::'>nul pause & REM Delete this line in case you don't want to pause at the end of the execution"
            Dim CodeLine3 As String = "::'exit /b"
            Dim CodeLine4 As String = "' Convert by CodeSmart : https://toolslib.net/downloads/viewdownload/631-code-smart/"
            Dim CodeLine5 As String = "%CODE%"

            Dim CodeMethod As String = CodeLine1 & vbNewLine & CodeLine2 & vbNewLine & CodeLine3 & vbNewLine & vbNewLine & CodeLine4 & vbNewLine & CodeLine5

            Dim ProcessSource As String = Source

            Dim FinalvbsCode As String = CodeMethod.Replace("%CODE%", ProcessSource)

            Return FinalvbsCode
        End Function

    End Class
End Namespace

