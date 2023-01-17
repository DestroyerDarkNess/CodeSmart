Imports System.IO
Imports System.IO.Compression

NotInheritable Class ZipFileWithProgress

    Private Sub New()
    End Sub

    'Dim sourceDirectory As String = args(0),
    '        archive As String = args(1),
    '       archiveDirectory As String = Path.GetDirectoryName(Path.GetFullPath(archive)),
    '        unpackDirectoryName As String = Guid.NewGuid().ToString()
    '
    '   File.Delete(archive)
    '    ZipFileWithProgress.CreateFromDirectory(sourceDirectory, archive,
    '       New BasicProgress(Of Double)(
    '            Sub(p)
    '                Console.WriteLine($"{p:P2} archiving complete")
    '           End Sub))
    '
    '   ZipFileWithProgress.ExtractToDirectory(archive, unpackDirectoryName,
    '       New BasicProgress(Of Double)(
    '          Sub(p)
    '               Console.WriteLine($"{p:P0} extracting complete")
    '           End Sub))

    Public Shared Sub CreateFromDirectory(
        sourceDirectoryName As String,
        destinationArchiveFileName As String,
        progress As IProgress(Of Double))

        sourceDirectoryName = Path.GetFullPath(sourceDirectoryName)

        Dim sourceFiles As FileInfo() = New DirectoryInfo(sourceDirectoryName).GetFiles("*", SearchOption.AllDirectories)
        Dim totalBytes As Double = sourceFiles.Sum(Function(f) f.Length)
        Dim currentBytes As Long = 0

        Using archive As ZipArchive = ZipFile.Open(destinationArchiveFileName, ZipArchiveMode.Create)
            For Each fileInfo As FileInfo In sourceFiles
                ' NOTE: naive method To Get Sub-path from file name, relative to
                ' input directory. Production code should be more robust than this.
                ' Either use Path class Or similar to parse directory separators And
                ' reconstruct output file name, Or change this entire method to be
                ' recursive so that it can follow the sub-directories And include them
                ' in the entry name as they are processed.
                Dim entryName As String = fileInfo.FullName.Substring(sourceDirectoryName.Length + 1)
                Dim entry As ZipArchiveEntry = archive.CreateEntry(entryName)

                entry.LastWriteTime = fileInfo.LastWriteTime

                Using inputStream As Stream = File.OpenRead(fileInfo.FullName)
                    Using outputStream As Stream = entry.Open()
                        Dim progressStream As Stream = New StreamWithProgress(inputStream,
                            New BasicProgress(Of Integer)(
                                Sub(i)
                                    currentBytes += i
                                    progress.Report(currentBytes / totalBytes)
                                End Sub), Nothing)

                        progressStream.CopyTo(outputStream)
                    End Using
                End Using
            Next
        End Using
    End Sub

    Public Shared Sub ExtractToDirectory(
        sourceArchiveFileName As String,
        destinationDirectoryName As String,
        progress As IProgress(Of Double))

        Using archive As ZipArchive = ZipFile.OpenRead(sourceArchiveFileName)
            Dim totalBytes As Double = archive.Entries.Sum(Function(e) e.Length)
            Dim currentBytes As Long = 0

            For Each entry As ZipArchiveEntry In archive.Entries
                Dim fileName As String = Path.Combine(destinationDirectoryName, entry.FullName)

                Directory.CreateDirectory(Path.GetDirectoryName(fileName))
                Using inputStream As Stream = entry.Open()
                    Using outputStream As Stream = File.OpenWrite(fileName)
                        Dim progressStream As Stream = New StreamWithProgress(outputStream, Nothing,
                            New BasicProgress(Of Integer)(
                                Sub(i)
                                    currentBytes += i
                                    progress.Report(currentBytes / totalBytes)
                                End Sub))

                        inputStream.CopyTo(progressStream)
                    End Using
                End Using

                File.SetLastWriteTime(fileName, entry.LastWriteTime.LocalDateTime)
            Next
        End Using
    End Sub
End Class