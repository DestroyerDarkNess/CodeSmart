<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutFrm
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
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.VisualStudioGroupBox1 = New CodeSmart.VisualStudioGroupBox()
        Me.VisualStudioGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(89, 116)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(160, 15)
        Me.GunaLabel1.TabIndex = 0
        Me.GunaLabel1.Text = "S4LSalsoft Copyright ©  2021"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.ForeColor = System.Drawing.Color.White
        Me.GunaLabel2.Location = New System.Drawing.Point(30, 41)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(122, 30)
        Me.GunaLabel2.TabIndex = 1
        Me.GunaLabel2.Text = " Destroyer#8328" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Enderman Gray#2317" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'VisualStudioGroupBox1
        '
        Me.VisualStudioGroupBox1.BorderColour = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.VisualStudioGroupBox1.Controls.Add(Me.GunaLabel2)
        Me.VisualStudioGroupBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.VisualStudioGroupBox1.HeaderColour = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.VisualStudioGroupBox1.Location = New System.Drawing.Point(23, 10)
        Me.VisualStudioGroupBox1.MainColour = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.VisualStudioGroupBox1.Name = "VisualStudioGroupBox1"
        Me.VisualStudioGroupBox1.Size = New System.Drawing.Size(208, 90)
        Me.VisualStudioGroupBox1.TabIndex = 2
        Me.VisualStudioGroupBox1.Text = "Credits & Discord Contacts: "
        Me.VisualStudioGroupBox1.TextColour = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(131, Byte), Integer))
        '
        'AboutFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(261, 140)
        Me.Controls.Add(Me.VisualStudioGroupBox1)
        Me.Controls.Add(Me.GunaLabel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutFrm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About Code Smart"
        Me.VisualStudioGroupBox1.ResumeLayout(False)
        Me.VisualStudioGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents VisualStudioGroupBox1 As CodeSmart.VisualStudioGroupBox
End Class
