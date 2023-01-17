
<ComClass(Debug.ClassId, Debug.InterfaceId, Debug.EventsId)>
Public Class Debug

    Public Const ClassId As String = "EB57BBC3-A848-4BA6-B35C-EF269E9E629E" '{EB57BBC3-A848-4BA6-B35C-EF269E9E629E}
    Public Const InterfaceId As String = "F8D4DBB9-52FB-4586-B4FD-0075AD112B60"
    Public Const EventsId As String = "06CDD59A-2DAF-4680-88A1-AF0B723D43CD"

    Public Sub New()
        MyBase.New()
    End Sub

    Private DebugWindow As DebugForm = New DebugForm With {.TopLevel = True, .Visible = True}

    Public Sub OpenDebugDialog()
        DebugWindow.Show()
    End Sub

    Public Sub SetDialogTitle(ByVal Title As String)
        DebugWindow.Text = Title
    End Sub

    Public Sub ToolBar(ByVal Show As Boolean)
        DebugWindow.ShowInTaskbar = Show
    End Sub

    Public Sub Write(ByVal Text As String)
        DebugWindow.WriteConsole(Text)
    End Sub

    Public Sub SetDialogLocation(ByVal x As Integer, ByVal y As Integer)
        DebugWindow.Location = New Drawing.Point(x, y)
    End Sub

    Public Sub SetDialogWidth(ByVal x As String)
        DebugWindow.Width = Val(x)
    End Sub

    Public Sub SetDialogHeight(ByVal y As String)
        DebugWindow.Height = Val(y)
    End Sub

End Class

