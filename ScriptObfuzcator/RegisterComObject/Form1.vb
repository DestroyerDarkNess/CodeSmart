Imports System.Reflection
Imports System.IO

Public Class Form1

#Region " Path "

    Private ReadOnly _regasmPaths As List(Of String) = New List(Of String) From {
    "C:\Windows\Microsoft.NET\Framework64\v2.0.50727\regasm.exe",
    "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\regasm.exe",
    "C:\Windows\Microsoft.NET\Framework\v2.0.50727\regasm.exe",
    "C:\Windows\Microsoft.NET\Framework\v4.0.30319\regasm.exe"
}


#End Region

#Region " Funcs "

    Private Sub RunRegAsmCommand(ByVal regasmArguments As String)
        Try

            Dim process = New Process()
            Dim processStartInfo = New ProcessStartInfo With {
                .WindowStyle = ProcessWindowStyle.Normal,
                .FileName = txtRegasmPath.Text,
                .Arguments = regasmArguments,
                .UseShellExecute = False,
                .RedirectStandardOutput = True,
                .RedirectStandardError = True,
                .CreateNoWindow = True,
                .Verb = "runas"
            }
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardError = True
            process.StartInfo = processStartInfo
            AddHandler process.OutputDataReceived, AddressOf Process_OutputDataReceived
            process.Start()
            process.BeginOutputReadLine()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private _lastOperationType As String = ""
    Private _isLastOperationSuccess As Boolean

    Private Sub Process_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        Me.BeginInvoke(Sub()
                           txtLog.Text += e.Data + Environment.NewLine

                           If e.Data IsNot Nothing Then

                               If _lastOperationType = "register" Then

                                   If e.Data.Contains("registered successfully") Then
                                       _isLastOperationSuccess = True
                                       txtLog.ForeColor = Color.Lime
                                   End If
                               ElseIf _lastOperationType = "unregister" Then

                                   If e.Data.Contains("un-registered successfully") Then
                                       _isLastOperationSuccess = True
                                       txtLog.ForeColor = Color.Red
                                   End If
                               End If
                           End If

                       End Sub)

    End Sub

#End Region

#Region " DLL Info "


    Private Sub PrintDllInfo()
        Try
            txtDllInfo.Text = ""
            Dim assembly = System.Reflection.Assembly.LoadFile(txtDllPath.Text)
            Dim allPublicClasses = GetLoadableTypes(assembly)

            For Each type In allPublicClasses
                Dim methods = GetMethods(type)

                If methods IsNot Nothing AndAlso methods.Count > 0 Then
                    AppendFormattedText(txtDllInfo, type.FullName & ":" + Environment.NewLine, Color.Navy, True, HorizontalAlignment.Left)
                    methods.ForEach(Function(m)
                                        AppendFormattedText(txtDllInfo, m + Environment.NewLine, Color.Black, False, HorizontalAlignment.Left)
                                    End Function)
                    AppendFormattedText(txtDllInfo, New String("_"c, 50) & Environment.NewLine + Environment.NewLine, Color.Green, False, HorizontalAlignment.Left)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Function GetMethods(ByVal type As Type) As List(Of String)
        Dim methods As List(Of String) = New List(Of String)()

        For Each method In type.GetMethods(BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.DeclaredOnly)
            Dim parameters = method.GetParameters()
            Dim parameterDescriptions As String = ""

            For Each parameter In parameters
                parameterDescriptions += parameter.ParameterType.FullName & " " + parameter.Name & ", "
            Next

            methods.Add(method.ReturnType.ToString & " " & method.Name & parameterDescriptions.TrimEnd(" "c).TrimEnd(","c))
        Next

        Return methods
    End Function

    Public Shared Function GetLoadableTypes(ByVal assembly As Assembly) As IEnumerable(Of Type)
        Try
            Return assembly.GetTypes()
        Catch e As ReflectionTypeLoadException
            Dim types = New List(Of Type)()

            For Each eType In e.Types

                If eType IsNot Nothing AndAlso eType.IsPublic Then
                    types.Add(eType)
                End If
            Next

            Return types
        End Try
    End Function

    Private Sub AppendFormattedText(ByVal rtb As RichTextBox, ByVal text As String, ByVal textColour As Color, ByVal isBold As Boolean, ByVal alignment As HorizontalAlignment)
        Dim start As Integer = rtb.TextLength
        rtb.AppendText(text)
        Dim [end] As Integer = rtb.TextLength
        rtb.[Select](start, [end] - start)
        rtb.SelectionColor = textColour
        rtb.SelectionAlignment = alignment
        rtb.SelectionFont = New Font(rtb.SelectionFont.FontFamily, rtb.SelectionFont.Size, (If(isBold, FontStyle.Bold, FontStyle.Regular)))
        rtb.SelectionLength = 0
    End Sub

#End Region


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FilePath As String = OpenFile()

        If FilePath IsNot Nothing Then
            txtDllPath.Text = FilePath
            PrintDllInfo()
        End If

    End Sub

    Public Function OpenFile() As String
        Dim OpenFileDialog1 As New OpenFileDialog
        ' OpenFileDialog1.DefaultExt = "txt"
        OpenFileDialog1.FileName = ""
        '  OpenFileDialog1.InitialDirectory = "c:\"
        OpenFileDialog1.Title = "Select file"
        OpenFileDialog1.Filter = "DLL File|*.dll"

        If Not OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Return OpenFileDialog1.FileName
        End If

        Return Nothing

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not HasValidRegasmFilePath() Then
            MessageBox.Show("Invalid regasm.exe file path! Check regasm.exe file exists in the specified location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        txtLog.Text = ""
        _lastOperationType = "register"

        Dim regasmArguments = "/codebase " & """" & txtDllPath.Text & """"
        RunRegAsmCommand(regasmArguments)
    End Sub

    Private Function HasValidRegasmFilePath() As Boolean
        Return File.Exists(txtRegasmPath.Text) AndAlso New FileInfo(txtRegasmPath.Text).Name.ToLower() = "regasm.exe"
    End Function

   

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DetectRegasmFileLocation()
    End Sub

    Private Sub DetectRegasmFileLocation()
        _regasmPaths.ForEach(Function(regasmPath)
                                 If File.Exists(regasmPath) Then
                                     txtRegasmPath.Text = regasmPath
                                     lblInvalidRegasmPath.Text = "Valid"
                                     lblInvalidRegasmPath.ForeColor = Color.Lime
                                 Else
                                     lblInvalidRegasmPath.Text = "Invalid"
                                     lblInvalidRegasmPath.ForeColor = Color.Red
                                 End If
                             End Function)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Not HasValidRegasmFilePath() Then
            MessageBox.Show("Invalid regasm.exe file path! Check regasm.exe file exists in the specified location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        txtLog.Text = ""
        _lastOperationType = "unregister"
        RunRegAsmCommand("/u " & """" & txtDllPath.Text & """")

    End Sub

End Class
