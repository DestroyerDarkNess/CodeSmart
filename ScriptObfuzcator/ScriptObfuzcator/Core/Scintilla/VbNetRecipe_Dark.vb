﻿Imports ScintillaNET

Namespace Core.Scintilla

    Public Class VbNetRecipe_Dark

        Public Shared Sub SetVbNetDarkStyle(ByVal editor As ScintillaNET.Scintilla)

            Dim backColor As Color = Color.FromArgb(255, 30, 30, 30)
            Dim selectionColor As Color = Color.FromArgb(255, 38, 79, 120)

            Dim keywords As String = Core.Scintilla.LexerWords.keywords

            Dim classnames As String = Core.Scintilla.LexerWords.classnames

            Dim literals As String = Core.Scintilla.LexerWords.literals


            Dim other As String = "_" ' line-break.

            ' Reset the styles.
            editor.StyleResetDefault()
            editor.StyleClearAll()
            ' editor.Styles(Style.[Default]).Font = "Consolas"
            ' editor.Styles(Style.[Default]).Size = 10

            ' Set the Vb.Net lexer.
            editor.Lexer = Lexer.Vb

            ' Set folding properties.
            With editor
                .SetProperty("fold", "1")
                .SetProperty("fold.compact", "1")
                .SetProperty("fold.html", "1")
            End With

            ' Set the margin for fold markers.
            With editor
                .Margins(2).Type = MarginType.Symbol
                .Margins(2).Mask = Marker.MaskFolders
                .Margins(2).Sensitive = True
                .Margins(2).Width = 20
            End With

            ' Reset folder markers.
            For i As Integer = Marker.FolderEnd To Marker.FolderOpen
                editor.Markers(i).SetForeColor(SystemColors.ControlLightLight)
                editor.Markers(i).SetBackColor(SystemColors.ControlDark)
            Next

            ' Set the style of the folder markers.
            With editor
                .Markers(Marker.Folder).Symbol = MarkerSymbol.BoxPlus
                .Markers(Marker.Folder).SetBackColor(SystemColors.ControlText)
                .Markers(Marker.FolderOpen).Symbol = MarkerSymbol.BoxMinus
                .Markers(Marker.FolderEnd).Symbol = MarkerSymbol.BoxPlusConnected
                .Markers(Marker.FolderEnd).SetBackColor(SystemColors.ControlText)
                .Markers(Marker.FolderMidTail).Symbol = MarkerSymbol.TCorner
                .Markers(Marker.FolderOpenMid).Symbol = MarkerSymbol.BoxMinusConnected
                .Markers(Marker.FolderSub).Symbol = MarkerSymbol.VLine
                .Markers(Marker.FolderTail).Symbol = MarkerSymbol.LCorner
            End With

            ' Enable automatic folding
            editor.AutomaticFold = (AutomaticFold.Show Or AutomaticFold.Click Or AutomaticFold.Change)

            ' Disable whitespaces visibility.
            editor.ViewWhitespace = WhitespaceMode.Invisible

            ' Set the common editor colors.
            editor.CaretForeColor = Color.WhiteSmoke
            editor.SetSelectionBackColor(True, selectionColor)

            ' Set the style of the Vb.Net language.
            With editor
                .Styles(Style.Default).BackColor = backColor

                .Styles(Style.Vb.Asm).BackColor = backColor
                .Styles(Style.Vb.Asm).ForeColor = Color.FromArgb(255, 181, 206, 168)
                .Styles(Style.Vb.Asm).Bold = True
                .Styles(Style.Vb.Asm).Italic = False
                .Styles(Style.Vb.Asm).Underline = False

                .Styles(Style.Vb.BinNumber).BackColor = backColor
                .Styles(Style.Vb.BinNumber).ForeColor = Color.FromArgb(255, 181, 206, 168)
                .Styles(Style.Vb.BinNumber).Bold = False
                .Styles(Style.Vb.BinNumber).Italic = False
                .Styles(Style.Vb.BinNumber).Underline = False

                .Styles(Style.Vb.Comment).BackColor = backColor
                .Styles(Style.Vb.Comment).ForeColor = Color.FromArgb(255, 87, 159, 56)
                .Styles(Style.Vb.Comment).Bold = False
                .Styles(Style.Vb.Comment).Italic = False
                .Styles(Style.Vb.Comment).Underline = False

                .Styles(Style.Vb.CommentBlock).BackColor = backColor
                .Styles(Style.Vb.CommentBlock).ForeColor = Color.FromArgb(255, 87, 159, 56)
                .Styles(Style.Vb.CommentBlock).Bold = False
                .Styles(Style.Vb.CommentBlock).Italic = False
                .Styles(Style.Vb.CommentBlock).Underline = False

                .Styles(Style.Vb.Constant).BackColor = backColor
                .Styles(Style.Vb.Constant).ForeColor = Color.MediumOrchid
                .Styles(Style.Vb.Constant).Bold = False
                .Styles(Style.Vb.Constant).Italic = False
                .Styles(Style.Vb.Constant).Underline = False

                .Styles(Style.Vb.Date).BackColor = backColor
                .Styles(Style.Vb.Date).ForeColor = Color.MediumOrchid
                .Styles(Style.Vb.Date).Bold = False
                .Styles(Style.Vb.Date).Italic = False
                .Styles(Style.Vb.Date).Underline = False

                .Styles(Style.Vb.Default).BackColor = backColor
                .Styles(Style.Vb.Default).ForeColor = Color.LightGray
                .Styles(Style.Vb.Default).Bold = False
                .Styles(Style.Vb.Default).Italic = False
                .Styles(Style.Vb.Default).Underline = False

                .Styles(Style.Vb.DocBlock).BackColor = backColor
                .Styles(Style.Vb.DocBlock).ForeColor = Color.FromArgb(255, 87, 159, 56)
                .Styles(Style.Vb.DocBlock).Bold = False
                .Styles(Style.Vb.DocBlock).Italic = False
                .Styles(Style.Vb.DocBlock).Underline = False

                .Styles(Style.Vb.DocKeyword).BackColor = backColor
                .Styles(Style.Vb.DocKeyword).ForeColor = Color.FromArgb(255, 100, 150, 215)
                .Styles(Style.Vb.DocKeyword).Bold = False
                .Styles(Style.Vb.DocKeyword).Italic = False
                .Styles(Style.Vb.DocKeyword).Underline = False

                .Styles(Style.Vb.DocLine).BackColor = backColor
                .Styles(Style.Vb.DocLine).ForeColor = Color.FromArgb(255, 87, 159, 56)
                .Styles(Style.Vb.DocLine).Bold = False
                .Styles(Style.Vb.DocLine).Italic = False
                .Styles(Style.Vb.DocLine).Underline = False

                .Styles(Style.Vb.Error).BackColor = backColor
                .Styles(Style.Vb.Error).ForeColor = Color.IndianRed
                .Styles(Style.Vb.Error).Bold = True
                .Styles(Style.Vb.Error).Italic = False
                .Styles(Style.Vb.Error).Underline = False

                .Styles(Style.Vb.HexNumber).BackColor = backColor
                .Styles(Style.Vb.HexNumber).ForeColor = Color.FromArgb(255, 181, 206, 168)
                .Styles(Style.Vb.HexNumber).Bold = False
                .Styles(Style.Vb.HexNumber).Italic = False
                .Styles(Style.Vb.HexNumber).Underline = False

                .Styles(Style.Vb.Identifier).BackColor = backColor
                .Styles(Style.Vb.Identifier).ForeColor = Color.Gainsboro
                .Styles(Style.Vb.Identifier).Bold = False
                .Styles(Style.Vb.Identifier).Italic = False
                .Styles(Style.Vb.Identifier).Underline = False

                .Styles(Style.Vb.Keyword).BackColor = backColor
                .Styles(Style.Vb.Keyword).ForeColor = Color.FromArgb(255, 100, 150, 215)
                .Styles(Style.Vb.Keyword).Bold = False
                .Styles(Style.Vb.Keyword).Italic = False
                .Styles(Style.Vb.Keyword).Underline = False

                .Styles(Style.Vb.Keyword2).BackColor = backColor
                .Styles(Style.Vb.Keyword2).ForeColor = Color.FromArgb(255, 62, 201, 174)
                .Styles(Style.Vb.Keyword2).Bold = False
                .Styles(Style.Vb.Keyword2).Italic = False
                .Styles(Style.Vb.Keyword2).Underline = False

                .Styles(Style.Vb.Keyword3).BackColor = backColor
                .Styles(Style.Vb.Keyword3).ForeColor = Color.FromArgb(255, 181, 206, 168)
                .Styles(Style.Vb.Keyword3).Bold = False
                .Styles(Style.Vb.Keyword3).Italic = False
                .Styles(Style.Vb.Keyword3).Underline = False

                .Styles(Style.Vb.Keyword4).BackColor = backColor
                .Styles(Style.Vb.Keyword4).ForeColor = Color.IndianRed
                .Styles(Style.Vb.Keyword4).Bold = False
                .Styles(Style.Vb.Keyword4).Italic = False
                .Styles(Style.Vb.Keyword4).Underline = False

                .Styles(Style.Vb.Label).BackColor = backColor
                .Styles(Style.Vb.Label).ForeColor = Color.FromArgb(255, 100, 150, 215)
                .Styles(Style.Vb.Label).Bold = False
                .Styles(Style.Vb.Label).Italic = False
                .Styles(Style.Vb.Label).Underline = False

                .Styles(Style.Vb.Number).BackColor = backColor
                .Styles(Style.Vb.Number).ForeColor = Color.FromArgb(255, 181, 206, 168)
                .Styles(Style.Vb.Number).Bold = False
                .Styles(Style.Vb.Number).Italic = False
                .Styles(Style.Vb.Number).Underline = False

                .Styles(Style.Vb.Operator).BackColor = backColor
                ' .Styles(Style.Vb.Operator).ForeColor = Color.DarkKhaki
                ' .Styles(Style.Vb.Operator).ForeColor = Color.DarkCyan
                ' .Styles(Style.Vb.Operator).ForeColor = Color.Honeydew
                ' .Styles(Style.Vb.Operator).ForeColor = Color.LightSteelBlue
                .Styles(Style.Vb.Operator).ForeColor = Color.LightSlateGray
                .Styles(Style.Vb.Operator).Bold = True
                .Styles(Style.Vb.Operator).Italic = False
                .Styles(Style.Vb.Operator).Underline = False

                .Styles(Style.Vb.Preprocessor).BackColor = backColor
                ' .Styles(Style.Vb.Preprocessor).ForeColor = Color.HotPink
                .Styles(Style.Vb.Preprocessor).ForeColor = Color.LightSlateGray
                .Styles(Style.Vb.Preprocessor).Bold = False
                .Styles(Style.Vb.Preprocessor).Italic = False
                .Styles(Style.Vb.Preprocessor).Underline = False

                .Styles(Style.Vb.String).BackColor = backColor
                .Styles(Style.Vb.String).ForeColor = Color.FromArgb(255, 214, 157, 133)
                .Styles(Style.Vb.String).Bold = False
                .Styles(Style.Vb.String).Italic = False
                .Styles(Style.Vb.String).Underline = False

                .Styles(Style.Vb.StringEol).BackColor = backColor
                .Styles(Style.Vb.StringEol).ForeColor = Color.Gainsboro
                .Styles(Style.Vb.StringEol).FillLine = True
                .Styles(Style.Vb.StringEol).Bold = False
                .Styles(Style.Vb.StringEol).Italic = False
                .Styles(Style.Vb.StringEol).Underline = False

            End With

            ' Set the Vb.Net keywords.
            editor.SetKeywords(0, keywords)
            editor.SetKeywords(1, classnames)
            editor.SetKeywords(2, literals)
            editor.SetKeywords(3, other)

        End Sub

    End Class

End Namespace

