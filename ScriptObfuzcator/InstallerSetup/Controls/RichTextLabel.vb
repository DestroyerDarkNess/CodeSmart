'  /*               *\
' |#* RichTextLabel *#|
'  \*               */
'
' // By Elektro H@cker
'
'   Description:
'   ............
' · A RichTextbox used as a Label to set text using various colors.
'
'   Methods:
'   ........
' · AppendText (Overload)

' Examples:
' RichTextLabel1.AppendText("My ", Color.White, , New Font("Arial", 12, FontStyle.Bold))
' RichTextLabel1.AppendText("RichText-", Color.White, , New Font("Arial", 12, FontStyle.Bold))
' RichTextLabel1.AppendText("Label", Color.YellowGreen, Color.Black, New Font("Lucida console", 16, FontStyle.Italic))

Imports System.ComponentModel

Public Class RichTextLabel : Inherits RichTextBox

    Public Sub New()
        MyBase.Enabled = False
        MyBase.Size = New Point(200, 20)
        MyBase.BorderStyle = Windows.Forms.BorderStyle.None
    End Sub

#Region " Overrided Properties "

    ''' <summary>
    ''' Turn the control backcolor to transparent.
    ''' </summary>
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = (cp.ExStyle Or 32)
            Return cp
        End Get
    End Property

#End Region

#Region " Shadowed Properties "

    ' AcceptsTab
    ' Just hidden from the designer and editor.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property AcceptsTab() As Boolean
        Get
            Return MyBase.AcceptsTab
        End Get
        Set(value As Boolean)
            MyBase.AcceptsTab = False
        End Set
    End Property

    ' AutoWordSelection
    ' Just hidden from the designer and editor.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property AutoWordSelection() As Boolean
        Get
            Return MyBase.AutoWordSelection
        End Get
        Set(value As Boolean)
            MyBase.AutoWordSelection = False
        End Set
    End Property

    ' BackColor
    ' Not hidden, but little hardcoded 'cause the createparams transparency.
    <Browsable(True), EditorBrowsable(EditorBrowsableState.Always)>
    Public Shadows Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(value As Color)
            MyBase.SelectionStart = 0
            MyBase.SelectionLength = MyBase.TextLength
            MyBase.SelectionBackColor = value
            MyBase.BackColor = value
        End Set
    End Property

    ' BorderStyle
    ' Just hidden from the designer and editor.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property BorderStyle() As BorderStyle
        Get
            Return MyBase.BorderStyle
        End Get
        Set(value As BorderStyle)
            MyBase.BorderStyle = BorderStyle.None
        End Set
    End Property

    ' Cursor
    ' Hidden from the designer and editor,
    ' because while the control is disabled the cursor always be the default even if changed.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property Cursor() As Cursor
        Get
            Return MyBase.Cursor
        End Get
        Set(value As Cursor)
            MyBase.Cursor = Cursors.Default
        End Set
    End Property

    ' Enabled
    ' Hidden from the but not from the editor,
    ' because to prevent exceptions when doing loops over a control collection to disable/enable controls.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Always)>
    Public Shadows Property Enabled() As Boolean
        Get
            Return MyBase.Enabled
        End Get
        Set(value As Boolean)
            MyBase.Enabled = False
        End Set
    End Property

    ' HideSelection
    ' Just hidden from the designer and editor.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property HideSelection() As Boolean
        Get
            Return MyBase.HideSelection
        End Get
        Set(value As Boolean)
            MyBase.HideSelection = True
        End Set
    End Property

    ' MaxLength
    ' Just hidden from the designer and editor.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property MaxLength() As Integer
        Get
            Return MyBase.MaxLength
        End Get
        Set(value As Integer)
            MyBase.MaxLength = 2147483646
        End Set
    End Property

    ' ReadOnly
    ' Just hidden from the designer and editor.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(value As Boolean)
            MyBase.ReadOnly = True
        End Set
    End Property

    ' ScrollBars
    ' Just hidden from the designer and editor.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property ScrollBars() As RichTextBoxScrollBars
        Get
            Return MyBase.ScrollBars
        End Get
        Set(value As RichTextBoxScrollBars)
            MyBase.ScrollBars = RichTextBoxScrollBars.None
        End Set
    End Property

    ' ShowSelectionMargin
    ' Just hidden from the designer and editor.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property ShowSelectionMargin() As Boolean
        Get
            Return MyBase.ShowSelectionMargin
        End Get
        Set(value As Boolean)
            MyBase.ShowSelectionMargin = False
        End Set
    End Property

    ' TabStop
    ' Just hidden from the designer and editor.
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property TabStop() As Boolean
        Get
            Return MyBase.TabStop
        End Get
        Set(value As Boolean)
            MyBase.TabStop = False
        End Set
    End Property

#End Region

#Region " Funcs & Procs "

    ''' <summary>
    ''' Append text to the current text.
    ''' </summary>
    ''' <param name="text">The text to append</param>
    ''' <param name="forecolor">The font color</param>
    ''' <param name="backcolor">The Background color</param>
    ''' <param name="font">The font of the appended text</param>
    Public Overloads Sub AppendText(ByVal text As String, _
                          ByVal forecolor As Color, _
                          Optional ByVal backcolor As Color = Nothing, _
                          Optional ByVal font As Font = Nothing)

        Dim index As Int32 = MyBase.TextLength
        MyBase.AppendText(text)
        MyBase.SelectionStart = index
        MyBase.SelectionLength = MyBase.TextLength - index
        MyBase.SelectionColor = forecolor

        If Not backcolor = Nothing _
        Then MyBase.SelectionBackColor = backcolor _
        Else MyBase.SelectionBackColor = DefaultBackColor

        If font IsNot Nothing Then MyBase.SelectionFont = font

        ' Reset selection
        MyBase.SelectionStart = MyBase.TextLength
        MyBase.SelectionLength = 0

    End Sub

#End Region

End Class