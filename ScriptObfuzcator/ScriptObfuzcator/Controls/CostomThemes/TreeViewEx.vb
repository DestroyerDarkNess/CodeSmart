Option Explicit On

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Runtime.InteropServices

Public Class TreeViewEx
    Inherits TreeView

#Region "API"

    Private Const TVM_SETEXTENDEDSTYLE As Integer = &H1100 + 44
    Private Const TVS_EX_DOUBLEBUFFER As Integer = &H4

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr,
                                        ByVal msg As Integer,
                                        ByVal wp As IntPtr,
                                        ByVal lp As IntPtr) As IntPtr
    End Function

#End Region

#Region "Private Fields"

    Private ReadOnly RightImage As Bitmap
    Private ReadOnly NSF As StringFormat

    Private HoverNode As TreeNode
    Private RightImageRect As Rectangle

#End Region

#Region "Constructors"

    Sub New()
        DrawMode = TreeViewDrawMode.OwnerDrawText
        RightImage = New Bitmap(My.Resources.drad)
        NSF = New StringFormat With {
            .Alignment = StringAlignment.Near,
            .LineAlignment = StringAlignment.Center,
            .Trimming = StringTrimming.EllipsisCharacter,
            .FormatFlags = StringFormatFlags.NoWrap
        }
    End Sub

#End Region

#Region "Paint"

    Protected Overrides Sub OnDrawNode(e As DrawTreeNodeEventArgs)
        MyBase.OnDrawNode(e)

        If e.Node Is Nothing Then Return

        Dim rect As Rectangle = e.Bounds : rect.Inflate(0, 1)

        If Not ClientRectangle.IntersectsWith(rect) Then
            Return
        End If

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        'Option1: If you want to draw different background color for the selected node.
        'If (e.State And TreeNodeStates.Selected) = TreeNodeStates.Selected Then
        '    Using br As New SolidBrush(Color.LightSteelBlue) '<- suit yourself!
        '        G.FillRectangle(br, rect)
        '    End Using
        'Else
        '    Using br As New SolidBrush(If(e.Node.BackColor.Equals(Color.Empty), BackColor, e.Node.BackColor))
        '        G.FillRectangle(br, rect)
        '    End Using
        'End If

        'Option2: If you don't want Option1.
        Using br As New SolidBrush(If(e.Node.BackColor.Equals(Color.Empty), BackColor, e.Node.BackColor))
            G.FillRectangle(br, rect)
        End Using

        Using br As New SolidBrush(If(e.Node.ForeColor.Equals(Color.Empty), ForeColor, e.Node.ForeColor))
            G.DrawString(e.Node.Text, If(e.Node.NodeFont, Font), br, rect, NSF)
        End Using

        If ReferenceEquals(e.Node, HoverNode) Then
            RightImageRect = New Rectangle(rect.Right + 5,
                                           rect.Y + ((rect.Height - RightImage.Height) / 2),
                                           rect.Height - 4, rect.Height - 4)
            G.DrawImage(RightImage,
                        RightImageRect,
                        New Rectangle(0, 0, RightImage.Width, RightImage.Height),
                        GraphicsUnit.Pixel)
        End If
    End Sub

#End Region

#Region "Other Events"

    'You need this to reduce the flickering.
    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        SendMessage(
            Handle,
            TVM_SETEXTENDEDSTYLE,
            IntPtr.op_Explicit(TVS_EX_DOUBLEBUFFER),
            IntPtr.op_Explicit(TVS_EX_DOUBLEBUFFER)
            )
        MyBase.OnHandleCreated(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        Dim node = GetNodeAt(e.Location)

        If node IsNot Nothing Then
            'Avoid unnecessary Invalidate() calls.
            If Not ReferenceEquals(node, HoverNode) Then
                HoverNode = node
                Invalidate()
            End If
        Else
            'Avoid unnecessary Invalidate() calls.
            If HoverNode IsNot Nothing Then
                HoverNode = Nothing
                Invalidate()
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)

        If e.Button = MouseButtons.Left AndAlso
            RightImageRect.Contains(e.Location) Then
            'Notify the container to do something.
            OnEditButtonClicked()
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        Invalidate()
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        MyBase.Dispose(disposing)
        If disposing Then
            RightImage.Dispose()
            NSF.Dispose()
        End If
    End Sub

#End Region

#Region "Custom Events"

    Public Class EditButtonClickArgs
        Inherits EventArgs

        Public Property Node As TreeNode

        Sub New(node As TreeNode)
            Me.Node = node
        End Sub
    End Class

    ''' <summary>
    ''' Raised when the right image is clicked.
    ''' </summary>
    Public Event EditButtonClicked As EventHandler(Of EditButtonClickArgs)

    ''' <summary>
    ''' Raises the <see cref="EditButtonClicked"/> events.
    ''' </summary>
    Protected Overridable Sub OnEditButtonClicked()
        RaiseEvent EditButtonClicked(Me, New EditButtonClickArgs(HoverNode))
    End Sub

#End Region

End Class