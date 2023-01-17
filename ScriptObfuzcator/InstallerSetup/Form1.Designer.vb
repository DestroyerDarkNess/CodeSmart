<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.ReturnButton = New InstallerSetup.XylosButton()
        Me.ContinueButton = New InstallerSetup.XylosButton()
        Me.CancelButton = New InstallerSetup.XylosButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ReturnButton)
        Me.Panel1.Controls.Add(Me.ContinueButton)
        Me.Panel1.Controls.Add(Me.PanelContainer)
        Me.Panel1.Controls.Add(Me.CancelButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 402)
        Me.Panel1.TabIndex = 1
        '
        'PanelContainer
        '
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(600, 327)
        Me.PanelContainer.TabIndex = 1
        '
        'ReturnButton
        '
        Me.ReturnButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ReturnButton.EnabledCalc = True
        Me.ReturnButton.Location = New System.Drawing.Point(48, 343)
        Me.ReturnButton.MauseDownColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.ReturnButton.MauseOverColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(145, 37)
        Me.ReturnButton.TabIndex = 3
        Me.ReturnButton.Text = "Return"
        '
        'ContinueButton
        '
        Me.ContinueButton.BackColor = System.Drawing.Color.DodgerBlue
        Me.ContinueButton.BorderColor = System.Drawing.Color.DodgerBlue
        Me.ContinueButton.EnabledCalc = True
        Me.ContinueButton.Location = New System.Drawing.Point(210, 343)
        Me.ContinueButton.MauseDownColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.ContinueButton.MauseOverColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.ContinueButton.Name = "ContinueButton"
        Me.ContinueButton.Size = New System.Drawing.Size(145, 37)
        Me.ContinueButton.TabIndex = 2
        Me.ContinueButton.Text = "Continue"
        '
        'CancelButton
        '
        Me.CancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.CancelButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.CancelButton.EnabledCalc = True
        Me.CancelButton.Location = New System.Drawing.Point(371, 343)
        Me.CancelButton.MauseDownColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.CancelButton.MauseOverColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(145, 37)
        Me.CancelButton.TabIndex = 0
        Me.CancelButton.Text = "Cancel"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(600, 402)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code Smart Installer"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CancelButton As InstallerSetup.XylosButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PanelContainer As System.Windows.Forms.Panel
    Friend WithEvents ReturnButton As InstallerSetup.XylosButton
    Friend WithEvents ContinueButton As InstallerSetup.XylosButton

End Class
