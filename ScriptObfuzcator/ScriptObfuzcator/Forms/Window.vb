Public Class Window

    Private Tabs As New List(Of TabPage)

    Private Sub Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tabs.Clear()
        ListView1.Items.Clear()
        CurrentTabSlected = Nothing
        ' Tabs.AddRange(Form1.TabVScontrol1.TabPages)
        For Each TabPageC As TabPage In Form1.TabVScontrol1.TabPages
            Tabs.Add(TabPageC)
        Next
        LoadPages()
    End Sub

    Private Sub LoadPages()

        For Each TabEx As TabPage In Tabs
            Dim TabPageName As String = TabEx.Text
            Dim FilePath As String = String.Empty
            Dim Format As String = String.Empty
            Dim TypeFile As String = String.Empty
            Dim ItemStr As String = String.Empty

            For Each ControlsinTab As Control In TabEx.Controls

                If TypeOf ControlsinTab Is Label Then
                    If ControlsinTab.Name = "dirlbl" Then
                        Dim ControlVal As Label = TryCast(ControlsinTab, Label)
                        FilePath = ControlVal.Text
                    End If
                End If

            Next
            If Not FilePath = "" Then
                Format = IO.Path.GetExtension(FilePath)
                TypeFile = Form1.GetLexer(Format).ToString

            End If
            If TypeFile = "" Then
                ItemStr = TabPageName & "[" & "Null" & "]"
            Else
                ItemStr = TabPageName & "[" & TypeFile & "]"
            End If

            ListView1.Items.Add(ItemStr).SubItems.Add(FilePath)
        Next


    End Sub

    Private CurrentTabSlected As TabPage = Nothing

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Dim IndexSelected As Integer = ListView1.SelectedIndices(0)
        Dim TabName As String = ListView1.Items.Item(IndexSelected).Text
        Dim DirName As String = ListView1.Items.Item(IndexSelected).SubItems(1).Text

        If DirName = "" Then
            Button2.Text = "Save As"
        Else
            Button2.Text = "Save"
        End If

        CurrentTabSlected = Tabs(IndexSelected)
       
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CurrentTabSlected IsNot Nothing Then
            Form1.TabVScontrol1.SelectTab(Form1.TabVScontrol1.TabPages.IndexOf(CurrentTabSlected))
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Save" Then
            SaveFileEx()
        ElseIf Button2.Text = "Save As" Then
            SaveAsFileEx()
        End If
    End Sub

    Private Sub SaveFileEx()

        If CurrentTabSlected IsNot Nothing Then

            Dim CurrentTabControl As TabPage = Form1.TabVScontrol1.TabPages(Form1.TabVScontrol1.TabPages.IndexOf(CurrentTabSlected))
            Dim CurrentText As String = String.Empty
            Dim FilePatch As String = String.Empty
          
            For Each ControlsinTab As Control In CurrentTabControl.Controls

                If TypeOf ControlsinTab Is Label Then

                    If ControlsinTab.Name = "dirlbl" Then
                        Dim ControlVal As Label = TryCast(ControlsinTab, Label)
                        FilePatch = ControlVal.Text
                    End If


                End If

                If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                    Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                    CurrentText = ControlVal.Text

                End If

            Next

            If FilePatch = "" Then
                SaveAsFileEx()
            Else
                Dim SaveF As Boolean = Core.Utils.FileWriteText(FilePatch, CurrentText)
                If Not SaveF = True Then
                    MsgBox(Core.Utils.FileManagerEx)
               End If
            End If

        End If

    End Sub


    Private Sub SaveAsFileEx()

        If CurrentTabSlected IsNot Nothing Then

            Dim CurrentTabControl As TabPage = Form1.TabVScontrol1.TabPages(Form1.TabVScontrol1.TabPages.IndexOf(CurrentTabSlected))
            Dim CurrentLblb As Label = Nothing

            Dim CurrentText As String = String.Empty
            Dim FilePatch As String = Core.Utils.SaveFile()
            Dim TypeFile As String = String.Empty
            Dim ItemStr As String = String.Empty

            Dim IndexSelected As Integer = ListView1.SelectedIndices(0)

            If Not FilePatch = Nothing Then

                For Each ControlsinTab As Control In CurrentTabControl.Controls

                    If TypeOf ControlsinTab Is ScintillaNET.Scintilla Then

                        Dim ControlVal As ScintillaNET.Scintilla = TryCast(ControlsinTab, ScintillaNET.Scintilla)
                        CurrentText = ControlVal.Text

                    End If

                    If TypeOf ControlsinTab Is Label Then
                        If ControlsinTab.Name = "dirlbl" Then
                            Dim ControlLblVal = TryCast(ControlsinTab, Label)
                            CurrentLblb = ControlLblVal
                            ControlLblVal.Text = FilePatch
                        End If
                    End If

                Next

                Dim SaveF As Boolean = Core.Utils.FileWriteText(FilePatch, CurrentText)
                If SaveF = True Then
                    CurrentTabControl.Text = IO.Path.GetFileName(FilePatch)
                    If CurrentLblb IsNot Nothing Then
                        CurrentLblb.Text = FilePatch
                    End If
                    TypeFile = Form1.GetLexer(IO.Path.GetExtension(FilePatch)).ToString
                    If TypeFile = "" Then
                        ItemStr = IO.Path.GetFileName(FilePatch) & "[" & "Null" & "]"
                    Else
                        ItemStr = IO.Path.GetFileName(FilePatch) & "[" & TypeFile & "]"
                    End If
                    ListView1.Items.Item(IndexSelected).Text = ItemStr
                    ListView1.Items.Item(IndexSelected).SubItems(1).Text = FilePatch

                Else
                    MsgBox(Core.Utils.FileManagerEx)
                End If

            End If

        End If
      
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If CurrentTabSlected IsNot Nothing Then
            Form1.TabVScontrol1.TabPages.Remove(CurrentTabSlected)
            Dim IndexSelected As Integer = ListView1.SelectedIndices(0)
            ListView1.Items.RemoveAt(IndexSelected)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

End Class