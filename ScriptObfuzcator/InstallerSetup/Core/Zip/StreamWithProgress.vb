Imports System.IO

Public Class StreamWithProgress
    Inherits Stream

    ' NOTE For illustration purposes. For production code, one would want To
    ' override *all* of the virtual methods, delegating to the base _stream object,
    ' to ensure performance optimizations in the base _stream object aren't
    ' bypassed.

    Private ReadOnly _stream As Stream
    Private ReadOnly _readProgress As IProgress(Of Integer)
    Private ReadOnly _writeProgress As IProgress(Of Integer)

    Public Sub New(Stream As Stream, readProgress As IProgress(Of Integer), writeProgress As IProgress(Of Integer))
        _stream = Stream
        _readProgress = readProgress
        _writeProgress = writeProgress
    End Sub

    Public Overrides ReadOnly Property CanRead As Boolean
        Get
            Return _stream.CanRead
        End Get
    End Property

    Public Overrides ReadOnly Property CanSeek As Boolean
        Get
            Return _stream.CanSeek
        End Get
    End Property

    Public Overrides ReadOnly Property CanWrite As Boolean
        Get
            Return _stream.CanWrite
        End Get
    End Property

    Public Overrides ReadOnly Property Length As Long
        Get
            Return _stream.Length
        End Get
    End Property

    Public Overrides Property Position As Long
        Get
            Return _stream.Position
        End Get
        Set(value As Long)
            _stream.Position = value
        End Set
    End Property

    Public Overrides Sub Flush()
        _stream.Flush()
    End Sub

    Public Overrides Sub SetLength(value As Long)
        _stream.SetLength(value)
    End Sub

    Public Overrides Function Seek(offset As Long, origin As SeekOrigin) As Long
        Return _stream.Seek(offset, origin)
    End Function

    Public Overrides Sub Write(buffer() As Byte, offset As Integer, count As Integer)
        _stream.Write(buffer, offset, count)
        _writeProgress.Report(count)
    End Sub

    Public Overrides Function Read(buffer() As Byte, offset As Integer, count As Integer) As Integer
        Dim bytesRead As Integer = _stream.Read(buffer, offset, count)

        _readProgress.Report(bytesRead)
        Return bytesRead
    End Function
End Class