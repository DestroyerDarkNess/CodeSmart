#Region " Imports "

Imports ScintillaNET

#End Region

#Region " ElektroKit.ThirdParty.ScintillaNet.Tools.ScintillaNetUtil "

Namespace ElektroKit.ThirdParty.ScintillaNet.Tools

    Friend NotInheritable Class ScintillaNetUtil

#Region " Private Fields "

        Private Shared vbKeywords As String =
    <a>
debug
release
addhandler
addressof
aggregate
alias
and
andalso
ansi
as
assembly
auto
binary
boolean
byref
byte
byval
call
case
catch
cbool
cbyte
cchar
cdate
cdbl
cdec
char
cint
class
clng
cobj
compare
const
continue
csbyte
cshort
csng
cstr
ctype
cuint
culng
cushort
custom
date
decimal
declare
default
delegate
dim
directcast
distinct
do
double
each
else
elseif
end
endif
enum
equals
erase
error
event
exit
explicit
false
finally
for
friend
from
function
get
gettype
getxmlnamespace
global
gosub
goto
group
handles
if
implements
imports
in
inherits
integer
interface
into
is
isfalse
isnot
istrue
join
key
let
lib
like
long
loop
me
mid
mod
module
mustinherit
mustoverride
my
mybase
myclass
namespace
narrowing
new
next
not
nothing
notinheritable
notoverridable
object
of
off
on
operator
option
optional
or
order
orelse
overloads
overridable
overrides
paramarray
partial
preserve
private
property
protected
public
raiseevent
readonly
redim
rem
removehandler
resume
return
sbyte
select
set
shadows
shared
short
single
skip
static
step
stop
strict
string
structure
sub
synclock
take
text
then
throw
to
true
try
trycast
typeof
uinteger
ulong
unicode
until
ushort
using
variant
wend
when
where
while
widening
with
withevents
writeonly
xor
</a>.Value

        Private Shared vbLiterals As String =
    <a>
!
#
%
@
&amp;
i
d
f
l
r
s
ui
ul
us
</a>.Value

        Private Shared vbOther As String = "_" ' line-break.

        Private Shared netTypeNames As String = <a></a>.Value

#End Region

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prevents a default instance of the <see cref="ScintillaNetUtil"/> class from being created.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerNonUserCode>
        Private Sub New()
        End Sub

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Sets a VisualBasic.Net dark lexer style on the specified <see cref="Scintilla"/> editor.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="editor">
        ''' The source <see cref="Scintilla"/> editor.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Sub SetVbNetDarkStyle(ByVal editor As Scintilla)

            Dim backColor As Color = Color.FromArgb(255, 30, 30, 30)
            Dim selectionColor As Color = Color.FromArgb(255, 38, 79, 120)

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
                ' Activate the line numbers.
                .Margins(1).Type = MarginType.Number
                .Margins(1).Cursor = MarginCursor.Arrow

                ' Activate fold markers.
                .Margins(2).Type = MarginType.Symbol
                .Margins(2).Mask = Marker.MaskFolders
                .Margins(2).Cursor = MarginCursor.Arrow
                .Margins(2).Sensitive = True
                .Margins(2).Width = 20
            End With

            ' Reset folder markers.
            For i As Integer = Marker.FolderEnd To Marker.FolderOpen
                editor.Markers(i).SetForeColor(Color.Black)
                editor.Markers(i).SetBackColor(Color.FromArgb(255, 120, 123, 129))
            Next

            ' Set margin colors.
            editor.SetFoldMarginColor(True, Color.FromArgb(255, 37, 37, 38))
            editor.SetFoldMarginHighlightColor(True, Color.FromArgb(255, 37, 37, 38))

            ' Set the style of the folder markers.
            With editor
                .Markers(Marker.Folder).Symbol = MarkerSymbol.BoxPlus
                .Markers(Marker.Folder).SetBackColor(Color.FromArgb(255, 170, 173, 179))
                .Markers(Marker.FolderOpen).Symbol = MarkerSymbol.BoxMinus
                .Markers(Marker.FolderEnd).Symbol = MarkerSymbol.BoxPlusConnected
                .Markers(Marker.FolderEnd).SetBackColor(Color.FromArgb(255, 170, 173, 179))
                .Markers(Marker.FolderMidTail).Symbol = MarkerSymbol.TCorner
                .Markers(Marker.FolderOpenMid).Symbol = MarkerSymbol.BoxMinusConnected
                .Markers(Marker.FolderSub).Symbol = MarkerSymbol.VLine
                .Markers(Marker.FolderTail).Symbol = MarkerSymbol.LCorner
            End With

            ' Enable automatic folding
            editor.AutomaticFold = (AutomaticFold.Show Or AutomaticFold.Click Or AutomaticFold.Change)

            ' Disable whitespaces visibility.
            editor.ViewWhitespace = WhitespaceMode.Invisible

            ' Set the common editor properties.
            editor.CaretForeColor = Color.Gainsboro
            editor.SetSelectionBackColor(True, selectionColor)
            editor.CaretLineBackColor = Color.FromArgb(255, 45, 45, 48)
            editor.CaretLineVisible = True
            editor.CaretStyle = CaretStyle.Line
            editor.EdgeMode = EdgeMode.None
            editor.EolMode = Eol.CrLf
            editor.HScrollBar = True
            editor.IndentationGuides = IndentView.None
            editor.LineEndTypesAllowed = LineEndType.Default
            editor.PasteConvertEndings = True
            editor.ViewEol = False
            editor.VScrollBar = True

            ' Set the style of the Vb.Net language.
            With editor
                .Styles(Style.Default).BackColor = backColor
                .Styles(Style.LineNumber).BackColor = Color.FromArgb(255, 37, 37, 38)
                .Styles(Style.LineNumber).ForeColor = Color.Gainsboro
                .Styles(Style.LineNumber).Visible = True

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
            editor.SetKeywords(0, ScintillaNetUtil.vbKeywords)
            editor.SetKeywords(1, ScintillaNetUtil.netTypeNames)
            editor.SetKeywords(2, ScintillaNetUtil.vbLiterals)
            editor.SetKeywords(3, ScintillaNetUtil.vbOther)

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Sets a VisualBasic.Net light lexer style on the specified <see cref="Scintilla"/> editor.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="editor">
        ''' The source <see cref="Scintilla"/> editor.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Sub SetVbNetLightStyle(ByVal editor As Scintilla)

            Dim backColor As Color = Color.White ' Color.Gainsboro
            Dim selectionColor As Color = Color.FromArgb(255, 100, 150, 215)

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
                ' Activate the line numbers.
                .Margins(1).Type = MarginType.Number
                .Margins(1).Cursor = MarginCursor.Arrow

                ' Activate fold markers.
                .Margins(2).Type = MarginType.Symbol
                .Margins(2).Mask = Marker.MaskFolders
                .Margins(2).Cursor = MarginCursor.Arrow
                .Margins(2).Sensitive = True
                .Margins(2).Width = 20
            End With

            ' Reset folder markers.
            For i As Integer = Marker.FolderEnd To Marker.FolderOpen
                editor.Markers(i).SetForeColor(Color.DarkGray)
                editor.Markers(i).SetBackColor(Color.Black)
            Next

            ' Set the style of the folder markers.
            With editor
                .Markers(Marker.Folder).Symbol = MarkerSymbol.BoxPlus
                .Markers(Marker.Folder).SetBackColor(Color.Black)
                .Markers(Marker.FolderOpen).Symbol = MarkerSymbol.BoxMinus
                .Markers(Marker.FolderEnd).Symbol = MarkerSymbol.BoxPlusConnected
                .Markers(Marker.FolderEnd).SetBackColor(Color.Black)
                .Markers(Marker.FolderMidTail).Symbol = MarkerSymbol.TCorner
                .Markers(Marker.FolderOpenMid).Symbol = MarkerSymbol.BoxMinusConnected
                .Markers(Marker.FolderSub).Symbol = MarkerSymbol.VLine
                .Markers(Marker.FolderTail).Symbol = MarkerSymbol.LCorner
            End With

            ' Enable automatic folding
            editor.AutomaticFold = (AutomaticFold.Show Or AutomaticFold.Click Or AutomaticFold.Change)

            ' Disable whitespaces visibility.
            editor.ViewWhitespace = WhitespaceMode.Invisible

            ' Set the common editor properties.
            editor.CaretForeColor = Color.Black
            editor.SetSelectionBackColor(True, selectionColor)
            editor.CaretLineBackColor = Color.FromArgb(255, 192, 192, 192)
            editor.CaretLineVisible = True
            editor.CaretStyle = CaretStyle.Line
            editor.EdgeMode = EdgeMode.None
            editor.EolMode = Eol.CrLf
            editor.HScrollBar = True
            editor.IndentationGuides = IndentView.None
            editor.LineEndTypesAllowed = LineEndType.Default
            editor.PasteConvertEndings = True
            editor.ViewEol = False
            editor.VScrollBar = True

            ' Set the style of the Vb.Net language.
            With editor
                .Styles(Style.Default).BackColor = backColor
                .Styles(Style.LineNumber).BackColor = Color.White ' Color.FromArgb(255, 37, 37, 38)
                .Styles(Style.LineNumber).ForeColor = Color.FromArgb(255, 37, 37, 38) '.Gainsboro
                .Styles(Style.LineNumber).Visible = True

                .Styles(Style.Vb.Asm).BackColor = backColor
                .Styles(Style.Vb.Asm).ForeColor = Color.OrangeRed
                .Styles(Style.Vb.Asm).Bold = True
                .Styles(Style.Vb.Asm).Italic = False
                .Styles(Style.Vb.Asm).Underline = False

                .Styles(Style.Vb.BinNumber).BackColor = backColor
                .Styles(Style.Vb.BinNumber).ForeColor = Color.OrangeRed
                .Styles(Style.Vb.BinNumber).Bold = False
                .Styles(Style.Vb.BinNumber).Italic = False
                .Styles(Style.Vb.BinNumber).Underline = False

                .Styles(Style.Vb.Comment).BackColor = backColor
                .Styles(Style.Vb.Comment).ForeColor = Color.Green
                .Styles(Style.Vb.Comment).Bold = False
                .Styles(Style.Vb.Comment).Italic = False
                .Styles(Style.Vb.Comment).Underline = False

                .Styles(Style.Vb.CommentBlock).BackColor = backColor
                .Styles(Style.Vb.CommentBlock).ForeColor = Color.Green
                .Styles(Style.Vb.CommentBlock).Bold = False
                .Styles(Style.Vb.CommentBlock).Italic = False
                .Styles(Style.Vb.CommentBlock).Underline = False

                .Styles(Style.Vb.Constant).BackColor = backColor
                .Styles(Style.Vb.Constant).ForeColor = Color.DarkMagenta
                .Styles(Style.Vb.Constant).Bold = False
                .Styles(Style.Vb.Constant).Italic = False
                .Styles(Style.Vb.Constant).Underline = False

                .Styles(Style.Vb.Date).BackColor = backColor
                .Styles(Style.Vb.Date).ForeColor = Color.DarkMagenta
                .Styles(Style.Vb.Date).Bold = False
                .Styles(Style.Vb.Date).Italic = False
                .Styles(Style.Vb.Date).Underline = False

                .Styles(Style.Vb.Default).BackColor = backColor
                .Styles(Style.Vb.Default).ForeColor = Color.Black
                .Styles(Style.Vb.Default).Bold = False
                .Styles(Style.Vb.Default).Italic = False
                .Styles(Style.Vb.Default).Underline = False

                .Styles(Style.Vb.DocBlock).BackColor = backColor
                .Styles(Style.Vb.DocBlock).ForeColor = Color.Green
                .Styles(Style.Vb.DocBlock).Bold = False
                .Styles(Style.Vb.DocBlock).Italic = False
                .Styles(Style.Vb.DocBlock).Underline = False

                .Styles(Style.Vb.DocKeyword).BackColor = backColor
                .Styles(Style.Vb.DocKeyword).ForeColor = Color.FromArgb(255, 64, 47, 241)
                .Styles(Style.Vb.DocKeyword).Bold = False
                .Styles(Style.Vb.DocKeyword).Italic = False
                .Styles(Style.Vb.DocKeyword).Underline = False

                .Styles(Style.Vb.DocLine).BackColor = backColor
                .Styles(Style.Vb.DocLine).ForeColor = Color.Green
                .Styles(Style.Vb.DocLine).Bold = False
                .Styles(Style.Vb.DocLine).Italic = False
                .Styles(Style.Vb.DocLine).Underline = False

                .Styles(Style.Vb.Error).BackColor = backColor
                .Styles(Style.Vb.Error).ForeColor = Color.DarkRed
                .Styles(Style.Vb.Error).Bold = True
                .Styles(Style.Vb.Error).Italic = False
                .Styles(Style.Vb.Error).Underline = False

                .Styles(Style.Vb.HexNumber).BackColor = backColor
                .Styles(Style.Vb.HexNumber).ForeColor = Color.DarkOrange
                .Styles(Style.Vb.HexNumber).Bold = False
                .Styles(Style.Vb.HexNumber).Italic = False
                .Styles(Style.Vb.HexNumber).Underline = False

                .Styles(Style.Vb.Identifier).BackColor = backColor
                .Styles(Style.Vb.Identifier).ForeColor = Color.Black
                .Styles(Style.Vb.Identifier).Bold = False
                .Styles(Style.Vb.Identifier).Italic = False
                .Styles(Style.Vb.Identifier).Underline = False

                .Styles(Style.Vb.Keyword).BackColor = backColor
                .Styles(Style.Vb.Keyword).ForeColor = Color.FromArgb(255, 72, 64, 213)
                .Styles(Style.Vb.Keyword).Bold = False
                .Styles(Style.Vb.Keyword).Italic = False
                .Styles(Style.Vb.Keyword).Underline = False

                .Styles(Style.Vb.Keyword2).BackColor = backColor
                .Styles(Style.Vb.Keyword2).ForeColor = Color.DarkCyan
                .Styles(Style.Vb.Keyword2).Bold = False
                .Styles(Style.Vb.Keyword2).Italic = False
                .Styles(Style.Vb.Keyword2).Underline = False

                .Styles(Style.Vb.Keyword3).BackColor = backColor
                .Styles(Style.Vb.Keyword3).ForeColor = Color.OrangeRed
                .Styles(Style.Vb.Keyword3).Bold = False
                .Styles(Style.Vb.Keyword3).Italic = False
                .Styles(Style.Vb.Keyword3).Underline = False

                .Styles(Style.Vb.Keyword4).BackColor = backColor
                .Styles(Style.Vb.Keyword4).ForeColor = Color.DarkRed
                .Styles(Style.Vb.Keyword4).Bold = False
                .Styles(Style.Vb.Keyword4).Italic = False
                .Styles(Style.Vb.Keyword4).Underline = False

                .Styles(Style.Vb.Label).BackColor = backColor
                .Styles(Style.Vb.Label).ForeColor = Color.FromArgb(255, 72, 64, 213)
                .Styles(Style.Vb.Label).Bold = False
                .Styles(Style.Vb.Label).Italic = False
                .Styles(Style.Vb.Label).Underline = False

                .Styles(Style.Vb.Number).BackColor = backColor
                .Styles(Style.Vb.Number).ForeColor = Color.OrangeRed
                .Styles(Style.Vb.Number).Bold = False
                .Styles(Style.Vb.Number).Italic = False
                .Styles(Style.Vb.Number).Underline = False

                .Styles(Style.Vb.Operator).BackColor = backColor
                ' .Styles(Style.Vb.Operator).ForeColor = Color.DarkKhaki
                ' .Styles(Style.Vb.Operator).ForeColor = Color.DarkCyan
                ' .Styles(Style.Vb.Operator).ForeColor = Color.Honeydew
                ' .Styles(Style.Vb.Operator).ForeColor = Color.LightSteelBlue
                .Styles(Style.Vb.Operator).ForeColor = Color.Gray
                .Styles(Style.Vb.Operator).Bold = True
                .Styles(Style.Vb.Operator).Italic = False
                .Styles(Style.Vb.Operator).Underline = False

                .Styles(Style.Vb.Preprocessor).BackColor = backColor
                ' .Styles(Style.Vb.Preprocessor).ForeColor = Color.HotPink
                .Styles(Style.Vb.Preprocessor).ForeColor = Color.Gray
                .Styles(Style.Vb.Preprocessor).Bold = False
                .Styles(Style.Vb.Preprocessor).Italic = False
                .Styles(Style.Vb.Preprocessor).Underline = False

                .Styles(Style.Vb.String).BackColor = backColor
                .Styles(Style.Vb.String).ForeColor = Color.Brown
                .Styles(Style.Vb.String).Bold = False
                .Styles(Style.Vb.String).Italic = False
                .Styles(Style.Vb.String).Underline = False

                .Styles(Style.Vb.StringEol).BackColor = backColor
                .Styles(Style.Vb.StringEol).ForeColor = Color.Black
                .Styles(Style.Vb.StringEol).FillLine = True
                .Styles(Style.Vb.StringEol).Bold = False
                .Styles(Style.Vb.StringEol).Italic = False
                .Styles(Style.Vb.StringEol).Underline = False

            End With

            ' Set the Vb.Net keywords.
            editor.SetKeywords(0, ScintillaNetUtil.vbKeywords)
            editor.SetKeywords(1, ScintillaNetUtil.netTypeNames)
            editor.SetKeywords(2, ScintillaNetUtil.vbLiterals)
            editor.SetKeywords(3, ScintillaNetUtil.vbOther)

        End Sub

#End Region

    End Class

End Namespace

#End Region