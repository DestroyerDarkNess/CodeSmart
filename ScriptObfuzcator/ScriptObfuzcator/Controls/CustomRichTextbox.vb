Public Class CustomRichTextbox
    Inherits RichTextBox


    Public Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        AllowDrop = True
        Me.BorderStyle = Windows.Forms.BorderStyle.None
        Me.ForeColor = Color.White
        Me.BackColor = Color.Transparent
    End Sub



End Class
