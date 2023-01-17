Class BasicProgress(Of T)
    Implements IProgress(Of T)

    Private ReadOnly _handler As Action(Of T)

    Public Sub New(handler As Action(Of T))
        _handler = handler
    End Sub

    Private Sub Report(value As T) Implements IProgress(Of T).Report
        _handler(value)
    End Sub
End Class