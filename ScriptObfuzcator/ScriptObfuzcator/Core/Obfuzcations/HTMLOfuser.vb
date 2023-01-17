Imports System.Text
Imports HtmlAgilityPack

Namespace Core.Obfuzcations
    Public Class HTMLOfuser

        Public Enum HTMLSettingObz
            Full = 0
            RC = 1
            UR = 2
        End Enum


        Public Shared Function HTMLObfuscator(ByVal Source As String, ByVal OptionObz As HTMLSettingObz, Optional ByVal RandonVal As Boolean = False) As String
            If OptionObz = HTMLSettingObz.Full Then
                Return HTMLMethod1(Source, RandonVal)
            ElseIf OptionObz = HTMLSettingObz.RC Then
                ' Return BatMethod2(Source)
            ElseIf OptionObz = HTMLSettingObz.UR Then
                ' Return BatMethod3(Source)
            End If
        End Function

        Private Shared Function HTMLMethod1(ByVal Source As String, Optional ByVal RandonVal As Boolean = False) As String
            '  Try
            Dim ProcessSource As String = Obfuscate(Source)
            Return ProcessSource
            '  Catch ex As Exception
            '     Return ex.Message
            ' End Try
        End Function

        Private Shared ReadOnly _rand As Random = New Random()

        Private Shared Function Obfuscate(ByVal html As String) As String
            If Not String.IsNullOrWhiteSpace(html) Then
                Dim doc As HtmlDocument = New HtmlDocument()
                doc.LoadHtml(html)

                If doc.DocumentNode IsNot Nothing Then
                    ObfuscateNode(doc.DocumentNode)
                    Return doc.DocumentNode.OuterHtml
                End If
            End If

            Return html
        End Function

        Private Shared Sub ObfuscateNode(ByVal node As HtmlNode)
            Select Case node.NodeType
                Case HtmlNodeType.Document, HtmlNodeType.Element

                    For Each childNode In node.ChildNodes
                        ObfuscateNode(childNode)
                    Next

                Case HtmlNodeType.Comment, HtmlNodeType.Text
                    node.InnerHtml = ObfuscateText(node.InnerHtml)
                Case Else
                    Throw New ArgumentOutOfRangeException("Unexpected html node type: " & node.NodeType)
            End Select
        End Sub

        Private Shared Function ObfuscateText(ByVal text As String) As String
            Dim sb = New StringBuilder(text)
            Dim ignore As Boolean = False

            For i As Integer = 0 To text.Length - 1
                Dim c = text(i)

                If c = "&" Then
                    ignore = True
                ElseIf c = ";" Then
                    ignore = False
                ElseIf Not ignore Then

                    If Char.IsLetter(c) Then
                        sb(i) = ChrW(_rand.Next(AscW("a"), AscW("z") + 1))
                    ElseIf Char.IsDigit(c) Then
                        sb(i) = ChrW(_rand.Next("0", "9" + 1))
                    End If

                End If
            Next

            Return sb.ToString()
        End Function


    End Class
End Namespace




