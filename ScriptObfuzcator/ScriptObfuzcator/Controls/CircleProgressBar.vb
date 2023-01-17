Public Class CircleProgressBar
    Inherits UserControl

    Dim _Myrr As Integer = 0
    Public Property Value As Integer
        Set(value As Integer)
            _Myrr = value
        End Set
        Get
            Return _Myrr
        End Get
    End Property

    Dim _BarSize As Integer = 2
    Public Property BarSize As Integer
        Set(value As Integer)
            _BarSize = value
        End Set
        Get
            Return _BarSize
        End Get
    End Property

    Dim _TextValue As String = ""
    Public Property TextValue As String
        Set(value As String)
            _TextValue = value
        End Set
        Get
            Return _TextValue
        End Get
    End Property

    Dim _ShowValueInText As Boolean = False
    Public Property ShowValueInText As Boolean
        Set(value As Boolean)
            _ShowValueInText = value
        End Set
        Get
            Return _ShowValueInText
        End Get
    End Property

    Dim _ProgressColor As Color = Color.LightSeaGreen
    Public Property ProgressColor As Color
        Set(value As Color)
            _ProgressColor = value
        End Set
        Get
            Return _ProgressColor
        End Get
    End Property

    Dim _ProgressBackColor As Color = Color.LightGray
    Public Property ProgressBackColor As Color
        Set(value As Color)
            _ProgressBackColor = value
        End Set
        Get
            Return _ProgressBackColor
        End Get
    End Property

    Public Sub New()
        Me.BackColor = Color.Transparent


    End Sub


    Private Sub DrawProgress(g As Graphics, rect As Rectangle, percentage As Single)
        'work out the angles for each arc  
        Dim progressAngle = CSng(360 / 100 * percentage)
        Dim remainderAngle = 360 - progressAngle
        'create pens to use for the arcs  
        Using progressPen As New Pen(_ProgressColor, _BarSize), remainderPen As New Pen(_ProgressBackColor, _BarSize)
            'set the smoothing to high quality for better output  
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            'draw the blue and white arcs  
            g.DrawArc(progressPen, rect, -90, progressAngle)
            g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle)
        End Using
        'draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly  
        Using fnt As New Font(Me.Font.FontFamily, 14)
            Dim text As String = _TextValue 'percentage.ToString + "%"
            If _ShowValueInText = True Then
                text = _Myrr
            End If
            Dim textSize = g.MeasureString(text, fnt)
            Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
            Dim textColor As Brush = New SolidBrush(Me.ForeColor)
            g.DrawString(text, fnt, textColor, textPoint)
        End Using
    End Sub

    Private Sub UserControl1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim ReferencePoint As Integer = (_BarSize * 5) / 2
        Dim CalculateLoacation As Point = New Point(Val((Val(Me.Width - ReferencePoint) * 5) / 60), Val((Val(Me.Height - ReferencePoint) * 5) / 60))
        Dim CalculateWidth As Integer = (CalculateLoacation.X * 5) / 2
        Dim CalculateHeigth As Integer = (CalculateLoacation.Y * 5) / 2
        Dim CircleSize As Size = New Size(Val(Me.Width - CalculateWidth), Val(Me.Height - CalculateHeigth))
        DrawProgress(e.Graphics, New Rectangle(CalculateLoacation.X, CalculateLoacation.Y, CircleSize.Width, CircleSize.Height), _Myrr)
    End Sub


    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'CircleProgressBar
        '
        Me.Name = "CircleProgressBar"
        Me.ResumeLayout(False)

    End Sub
End Class
