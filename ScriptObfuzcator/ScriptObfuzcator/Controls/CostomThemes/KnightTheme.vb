﻿Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Enum MouseStateKnight
    None = 0
    Over = 1
    Down = 2
End Enum

Class KnightTheme
    Inherits ContainerControl

#Region " Declarations "
    Private _Header As Integer = 38
    Private _Down As Boolean = False
    Private _MousePoint As Point
#End Region

#Region " MouseStates "

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _Down = False
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Location.Y < _Header AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
            _Down = True
            _MousePoint = e.Location
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If _Down = True Then
            ParentForm.Location = MousePosition - _MousePoint
        End If
    End Sub

#End Region

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        ParentForm.FormBorderStyle = FormBorderStyle.None
        ParentForm.TransparencyKey = Color.Fuchsia
        Dock = DockStyle.Fill
        Invalidate()
    End Sub

    Sub New()
        BackColor = Color.FromArgb(46, 49, 61)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(236, 73, 99))
        G.FillRectangle(New SolidBrush(Color.FromArgb(46, 49, 61)), New Rectangle(0, _Header, Width, Height - _Header))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(0, 0, 1, 1))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(1, 0, 1, 1))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(0, 1, 1, 1))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(Width - 1, 0, 1, 1))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(Width - 2, 0, 1, 1))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(Width - 1, 1, 1, 1))
        Dim _StringF As New StringFormat
        _StringF.Alignment = StringAlignment.Center
        _StringF.LineAlignment = StringAlignment.Center
        G.DrawString(Text, New Font("Segoe UI", 12), Brushes.White, New RectangleF(0, 0, Width, _Header), _StringF)
    End Sub

End Class

Class KnightButton
    Inherits Control

#Region " Declarations "
    Private _State As MouseStateKnight = MouseState.None
#End Region

#Region " MouseStates "

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _State = MouseStateKnight.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _State = MouseStateKnight.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseStateKnight.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _State = MouseStateKnight.Over
        Invalidate()
    End Sub

#End Region

#Region " Properties "
    Private _Rounded As Boolean
    Public Property RoundedCorners() As Boolean
        Get
            Return _Rounded
        End Get
        Set(ByVal value As Boolean)
            _Rounded = value
        End Set
    End Property
#End Region

    Sub New()
        Size = New Size(90, 30)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(236, 73, 99))
        Select Case _State
            Case MouseStateKnight.Over
                G.FillRectangle(New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(0, 0, Width, Height))

            Case MouseStateKnight.Down
                G.FillRectangle(New SolidBrush(Color.FromArgb(25, Color.Black)), New Rectangle(0, 0, Width, Height))
        End Select
        If _Rounded Then
            G.FillRectangle(New SolidBrush(Parent.BackColor), New Rectangle(0, 0, 1, 1))
            G.FillRectangle(New SolidBrush(Parent.BackColor), New Rectangle(Width - 1, 0, 1, 1))
            G.FillRectangle(New SolidBrush(Parent.BackColor), New Rectangle(0, Height - 1, 1, 1))
            G.FillRectangle(New SolidBrush(Parent.BackColor), New Rectangle(Width - 1, Height - 1, 1, 1))
        End If
        Dim _StringF As New StringFormat
        _StringF.Alignment = StringAlignment.Center
        _StringF.LineAlignment = StringAlignment.Center
        G.DrawString(Text, New Font("Segoe UI", 10), Brushes.White, New RectangleF(0, 0, Width - 1, Height - 1), _StringF)
    End Sub
End Class

Class KnightGroupBox
    Inherits ContainerControl

    Sub New()
        Size = New Size(200, 100)
        BackColor = Color.FromArgb(37, 39, 48)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(BackColor)
        G.DrawRectangle(New Pen(Color.FromArgb(236, 73, 99)), New Rectangle(0, 0, Width - 1, Height - 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(46, 49, 61)), New Rectangle(0, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(46, 49, 61)), New Rectangle(Width - 1, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(46, 49, 61)), New Rectangle(0, Height - 1, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(46, 49, 61)), New Rectangle(Width - 1, Height - 1, 1, 1))
        G.DrawString(Text, New Font("Segoe UI", 10), Brushes.White, New Point(7, 5))
    End Sub

End Class

<DefaultEvent("CheckedChanged")>
Class KnightRadioButton
    Inherits Control

#Region " Variables"
    Private _Checked As Boolean
#End Region

#Region " Properties"
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property
    Event CheckedChanged(ByVal sender As Object)
    Protected Overrides Sub OnClick(e As EventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnClick(e)
    End Sub
    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return
        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is KnightRadioButton Then
                DirectCast(C, KnightRadioButton).Checked = False
                Invalidate()
            End If
        Next
    End Sub
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        InvalidateControls()
    End Sub


    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 16
    End Sub

#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.SmoothingMode = 2
        G.TextRenderingHint = 5
        G.Clear(Parent.BackColor)
        If Parent.BackColor = Color.FromArgb(46, 49, 61) Then
            G.FillEllipse(New SolidBrush(Color.FromArgb(37, 39, 48)), New Rectangle(0, 0, 15, 15))
        Else
            G.FillEllipse(New SolidBrush(Color.FromArgb(24, 25, 31)), New Rectangle(0, 0, 15, 15))
        End If
        If Checked Then
            G.FillEllipse(New SolidBrush(Color.FromArgb(236, 73, 99)), New Rectangle(4, 4, 7, 7))
        End If
        G.DrawString(Text, New Font("Segoe UI", 10), Brushes.White, New Point(18, -2))
    End Sub

End Class

<DefaultEvent("CheckedChanged")>
Class KnightCheckBox
    Inherits Control

#Region "Variables"
    Private _Checked As Boolean
#End Region

#Region " Properties"
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Event CheckedChanged(ByVal sender As Object)
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        If Not _Checked Then
            Checked = True
        Else
            Checked = False
        End If
        RaiseEvent CheckedChanged(Me)
        MyBase.OnClick(e)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 16
    End Sub

#End Region


    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(BackColor)

        If Parent.BackColor = Color.FromArgb(46, 49, 61) Then
            G.FillRectangle(New SolidBrush(Color.FromArgb(37, 39, 48)), New Rectangle(0, 0, 15, 15))
        Else
            G.FillRectangle(New SolidBrush(Color.FromArgb(24, 25, 31)), New Rectangle(0, 0, 15, 15))
        End If
        If Checked Then
            G.FillRectangle(New SolidBrush(Color.FromArgb(236, 73, 99)), New Rectangle(4, 4, 7, 7))
        End If

        G.DrawString(Text, New Font("Segoe UI", 10), Brushes.White, New Point(18, -2))

    End Sub
End Class

<DefaultEvent("TextChanged")>
Class KnightTextBox
    Inherits Control

#Region " Variables"
    Private WithEvents _TextBox As Windows.Forms.TextBox
#End Region

#Region " Properties"

#Region " TextBox Properties"

    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    <Category("Options")> _
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If _TextBox IsNot Nothing Then
                _TextBox.TextAlign = value
            End If
        End Set
    End Property
    Private _MaxLength As Integer = 32767
    <Category("Options")> _
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If _TextBox IsNot Nothing Then
                _TextBox.MaxLength = value
            End If
        End Set
    End Property
    Private _ReadOnly As Boolean
    <Category("Options")> _
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If _TextBox IsNot Nothing Then
                _TextBox.ReadOnly = value
            End If
        End Set
    End Property
    Private _UseSystemPasswordChar As Boolean
    <Category("Options")> _
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If _TextBox IsNot Nothing Then
                _TextBox.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    Private _Multiline As Boolean
    <Category("Options")> _
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If _TextBox IsNot Nothing Then
                _TextBox.Multiline = value

                If value Then
                    _TextBox.Height = Height - 11
                Else
                    Height = _TextBox.Height + 11
                End If

            End If
        End Set
    End Property
    <Category("Options")> _
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If _TextBox IsNot Nothing Then
                _TextBox.Text = value
            End If
        End Set
    End Property
    <Category("Options")> _
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If _TextBox IsNot Nothing Then
                _TextBox.Font = value
                _TextBox.Location = New Point(3, 5)
                _TextBox.Width = Width - 6

                If Not _Multiline Then
                    Height = _TextBox.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(_TextBox) Then
            Controls.Add(_TextBox)
        End If
    End Sub
    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = _TextBox.Text
    End Sub
    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            _TextBox.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            _TextBox.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        _TextBox.Location = New Point(5, 5)
        _TextBox.Width = Width - 10

        If _Multiline Then
            _TextBox.Height = Height - 11
        Else
            Height = _TextBox.Height + 11
        End If
        MyBase.OnResize(e)
    End Sub

#End Region
#End Region
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True

        BackColor = Color.Transparent

        _TextBox = New Windows.Forms.TextBox
        _TextBox.Font = New Font("Segoe UI", 10)
        _TextBox.Text = Text
        _TextBox.BackColor = Color.FromArgb(37, 39, 48)
        _TextBox.ForeColor = Color.White
        _TextBox.MaxLength = _MaxLength
        _TextBox.Multiline = _Multiline
        _TextBox.ReadOnly = _ReadOnly
        _TextBox.UseSystemPasswordChar = _UseSystemPasswordChar
        _TextBox.BorderStyle = BorderStyle.None
        _TextBox.Location = New Point(5, 5)
        _TextBox.Width = Width - 10

        _TextBox.Cursor = Cursors.IBeam

        If _Multiline Then
            _TextBox.Height = Height - 11
        Else
            Height = _TextBox.Height + 11
        End If

        AddHandler _TextBox.TextChanged, AddressOf OnBaseTextChanged
        AddHandler _TextBox.KeyDown, AddressOf OnBaseKeyDown
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(37, 39, 48))
        G.DrawRectangle(New Pen(Color.FromArgb(236, 73, 99)), New Rectangle(0, 0, Width - 1, Height - 1))
    End Sub
End Class

Class KnightClose
    Inherits Control

#Region " Declarations "
    Private _State As MouseStateKnight
#End Region

#Region " MouseStates "
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _State = MouseStateKnight.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _State = MouseStateKnight.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseStateKnight.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _State = MouseStateKnight.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Environment.Exit(0)
    End Sub
#End Region

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(12, 12)
    End Sub

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Size = New Size(12, 12)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics

        G.Clear(Color.FromArgb(236, 73, 99))

        Dim _StringF As New StringFormat
        _StringF.Alignment = StringAlignment.Center
        _StringF.LineAlignment = StringAlignment.Center

        G.DrawString("r", New Font("Marlett", 11), Brushes.White, New RectangleF(0, 0, Width, Height), _StringF)

        Select Case _State
            Case MouseStateKnight.Over
                G.DrawString("r", New Font("Marlett", 11), New SolidBrush(Color.FromArgb(25, Color.White)), New RectangleF(0, 0, Width, Height), _StringF)

            Case MouseStateKnight.Down
                G.DrawString("r", New Font("Marlett", 11), New SolidBrush(Color.FromArgb(40, Color.Black)), New RectangleF(0, 0, Width, Height), _StringF)

        End Select

    End Sub

End Class

Class KnightMini
    Inherits Control

#Region " Declarations "
    Private _State As MouseStateKnight
#End Region

#Region " MouseStates "
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _State = MouseStateKnight.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _State = MouseStateKnight.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseStateKnight.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _State = MouseStateKnight.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        FindForm.WindowState = FormWindowState.Minimized
    End Sub
#End Region

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(12, 12)
    End Sub

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Size = New Size(12, 12)
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics

        G.Clear(Color.FromArgb(236, 73, 99))

        Dim _StringF As New StringFormat
        _StringF.Alignment = StringAlignment.Center
        _StringF.LineAlignment = StringAlignment.Center

        G.DrawString("0", New Font("Marlett", 11), Brushes.White, New RectangleF(0, 0, Width, Height), _StringF)

        Select Case _State
            Case MouseStateKnight.Over
                G.DrawString("0", New Font("Marlett", 11), New SolidBrush(Color.FromArgb(25, Color.White)), New RectangleF(0, 0, Width, Height), _StringF)

            Case MouseStateKnight.Down
                G.DrawString("0", New Font("Marlett", 11), New SolidBrush(Color.FromArgb(40, Color.Black)), New RectangleF(0, 0, Width, Height), _StringF)

        End Select

    End Sub

End Class