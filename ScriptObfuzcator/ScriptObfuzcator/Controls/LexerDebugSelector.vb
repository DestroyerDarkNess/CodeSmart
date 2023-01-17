Public Class LexerDebugSelector

    Private Sub LexerDebugSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.Location = Form1.CenterForm(Me, Me.Location)
        ' Me.BackColor = Color.FromArgb(100, 0, 0, 0)
    End Sub

    Private _LexerSelector As ScintillaNET.Lexer = ScintillaNET.Lexer.Null
    Public Property LexerSelector() As ScintillaNET.Lexer
        Get
            Return _LexerSelector
        End Get
        Set(ByVal value As ScintillaNET.Lexer)
            _LexerSelector = value
        End Set
    End Property

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Me.Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Dim Language As String = GunaComboBox1.Items(GunaComboBox1.SelectedIndex)
        ' MsgBox(LCase(Language))
        Select Case LCase(Language)
            Case LCase("Batch (CMD.EXE)") : _LexerSelector = ScintillaNET.Lexer.Batch
            Case LCase("VBS  (Cscrpit.EXE)") : _LexerSelector = ScintillaNET.Lexer.VbScript
            Case LCase("Windows default") : _LexerSelector = ScintillaNET.Lexer.Null
        End Select
        Me.Close()
    End Sub

    Private Sub LexerDebugSelector_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '  Dim LocationX = (Form1.Left + (Form1.Width - GunaPanel1.Width) / 2) ' set the X coordinates.
        '   Dim LocationY = (Form1.Top + (Form1.Height - GunaPanel1.Height) / 2) ' set the Y coordinates.
        'GunaPanel1.Location = New Point(LocationX, LocationY)
    End Sub

End Class
