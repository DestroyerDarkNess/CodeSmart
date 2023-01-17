
Public Class Form1

    Private Step1Form As Step1 = New Step1 With {.TopLevel = False, .Visible = True}
    Private Step2Form As Step2 = New Step2 With {.TopLevel = False, .Visible = True}
    Private Step3Form As Step3 = New Step3 With {.TopLevel = False, .Visible = True}
    Private Step4Form As Step4 = New Step4 With {.TopLevel = False, .Visible = True}
    Private Step5Form As Step5 = New Step5 With {.TopLevel = False, .Visible = True}

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Core.Helper.MainForm = Me
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StartGuiAll()
    End Sub

    Public Sub StartGuiAll()
        If Core.Helper.InstallerInstanse.Installed = True Then
            End
        End If
        PanelContainer.Controls.Add(Step1Form)
       
    End Sub


    Public Sub NextStep()
        Dim GetCurrentForm As Form = PanelContainer.Controls(0)
        PanelContainer.Controls.Clear()
        If TypeOf GetCurrentForm Is Step1 Then
            PanelContainer.Controls.Add(Step2Form)
            Step2Form.CheckBoxes()
        ElseIf TypeOf GetCurrentForm Is Step2 Then
            PanelContainer.Controls.Add(Step3Form)
        ElseIf TypeOf GetCurrentForm Is Step3 Then
            PanelContainer.Controls.Add(Step4Form)
            Step4Form.StartInstall()
        ElseIf TypeOf GetCurrentForm Is Step4 Then
            Me.CancelButton.Text = "Close"
            Me.CancelButton.Invalidate()
            PanelContainer.Controls.Add(Step5Form)
       ElseIf TypeOf GetCurrentForm Is Step5 Then

        End If
    End Sub

    Public Sub ReturnStep()
        Dim GetCurrentForm As Form = PanelContainer.Controls(0)
        PanelContainer.Controls.Clear()
        If TypeOf GetCurrentForm Is Step1 Then

        ElseIf TypeOf GetCurrentForm Is Step2 Then
            PanelContainer.Controls.Add(Step1Form)
        ElseIf TypeOf GetCurrentForm Is Step3 Then
            PanelContainer.Controls.Add(Step2Form)
            Step2Form.CheckBoxes()
        ElseIf TypeOf GetCurrentForm Is Step4 Then
            PanelContainer.Controls.Add(Step3Form)
        ElseIf TypeOf GetCurrentForm Is Step5 Then
            PanelContainer.Controls.Add(Step4Form)
        End If
    End Sub

    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        ReturnStep()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        End
    End Sub

    Private Sub ContinueButton_Click(sender As Object, e As EventArgs) Handles ContinueButton.Click
        NextStep()
    End Sub

End Class
