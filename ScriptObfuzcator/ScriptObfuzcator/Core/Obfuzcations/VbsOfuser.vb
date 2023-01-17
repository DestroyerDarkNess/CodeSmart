

Namespace Core.Obfuzcations
    Public Class VbsOfuser

        Public Enum VbsSettingObz
            HexFacebook = 0
            RC = 1
            UR = 2
        End Enum


        Public Shared Function VbsObfuscator(ByVal Source As String, ByVal OptionObz As VbsSettingObz, Optional ByVal RandonVal As Boolean = False) As String
            If OptionObz = VbsSettingObz.HexFacebook Then
                Return VBSMethod1(Source, RandonVal)
            ElseIf OptionObz = VbsSettingObz.RC Then
                ' Return BatMethod2(Source)
            ElseIf OptionObz = VbsSettingObz.UR Then
                ' Return BatMethod3(Source)
            End If
        End Function

        Private Shared CloseXmlMethod1 As String = "]]>"
        Private Shared LineCodeMethod1 As String = "FACEBOOKFACEBOOK = FACEBOOKFACEBOOK & php(" & """" & "%Hex%" & """" & ")" 'FACEBOOKFACEBOOK = FACEBOOKFACEBOOK & php("6D7367626F782022686F6C6122")
        Private Shared CodeMethod1 As String = <a><![CDATA[<?XML version="1.0"?><job>
 
<script language="VBScript">
 
<![CDATA[ 

'Please Save this Code in ".wsf" format
'Please Save this Code in ".wsf" format
'Please Save this Code in ".wsf" format
'Please Save this Code in ".wsf" format
'Please Save this Code in ".wsf" format
'Please Save this Code in ".wsf" format
'Please Save this Code in ".wsf" format
'Please Save this Code in ".wsf" format
'Please Save this Code in ".wsf" format
'Please Save this Code in ".wsf" format

%LineCode%
 
Function php(FACEBOOKFACEBOOK) : For y = 1 To Len(FACEBOOKFACEBOOK) Step 2 : ub = ub & Chr(Clng("&H" & Mid(FACEBOOKFACEBOOK, y, 2))) : Next : php = ub : End Function
 
ExecuteGlobal FACEBOOKFACEBOOK

%CloseXML%

</script>
 
</job>

]]></a>.Value



        Private Shared Function VBSMethod1(ByVal Source As String, Optional ByVal RandonVal As Boolean = False) As String
            Dim ProcessSource As String = LCase(Source)

            Dim SpliterLine As String() = ProcessSource.Split(vbNewLine)
            Dim LineCodesAssembler As String = String.Empty

            For Each Cline As String In SpliterLine
                If Not Cline = String.Empty Then
                    Dim Hex_str As String = String2Hex(Cline)
                    Dim CreateLineCode As String = LineCodeMethod1.Replace("%Hex%", Hex_str)

                    LineCodesAssembler += CreateLineCode & vbNewLine
                End If
            Next

            Dim GenerateCode As String = CodeMethod1.Replace("%LineCode%", LineCodesAssembler)

            GenerateCode = GenerateCode.Replace("%CloseXML%", CloseXmlMethod1)

            Return GenerateCode

        End Function

        Private Shared Function String2Hex(ByVal Source_String As String) As String
            Dim Hex_StringBuilder As New System.Text.StringBuilder()
            For Each c As Char In Source_String : Hex_StringBuilder.Append(Asc(c).ToString("x2")) : Next c
            Return Hex_StringBuilder.ToString()
        End Function

    End Class
End Namespace

