<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Step3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Step3))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.KnightButton1 = New InstallerSetup.KnightButton()
        Me.InstallationDirtextbox = New InstallerSetup.XylosTextBox()
        Me.LogInLabel2 = New InstallerSetup.LogInLabel()
        Me.RichTextLabel1 = New InstallerSetup.RichTextLabel()
        Me.LogInLabel3 = New InstallerSetup.LogInLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LogInLabel1 = New InstallerSetup.LogInLabel()
        Me.FolderBrowserDialog1 = New InstallerSetup.FileBorserDialog.FolderBrowserDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.KnightButton1)
        Me.Panel1.Controls.Add(Me.InstallationDirtextbox)
        Me.Panel1.Controls.Add(Me.LogInLabel2)
        Me.Panel1.Controls.Add(Me.RichTextLabel1)
        Me.Panel1.Controls.Add(Me.LogInLabel3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.LogInLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 327)
        Me.Panel1.TabIndex = 2
        '
        'KnightButton1
        '
        Me.KnightButton1.Location = New System.Drawing.Point(567, 168)
        Me.KnightButton1.Name = "KnightButton1"
        Me.KnightButton1.RoundedCorners = False
        Me.KnightButton1.Size = New System.Drawing.Size(21, 25)
        Me.KnightButton1.TabIndex = 7
        Me.KnightButton1.Text = "..."
        '
        'InstallationDirtextbox
        '
        Me.InstallationDirtextbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.InstallationDirtextbox.EnabledCalc = True
        Me.InstallationDirtextbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.InstallationDirtextbox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.InstallationDirtextbox.Location = New System.Drawing.Point(230, 168)
        Me.InstallationDirtextbox.MaxLength = 32767
        Me.InstallationDirtextbox.MultiLine = False
        Me.InstallationDirtextbox.Name = "InstallationDirtextbox"
        Me.InstallationDirtextbox.ReadOnly = True
        Me.InstallationDirtextbox.Size = New System.Drawing.Size(328, 25)
        Me.InstallationDirtextbox.TabIndex = 6
        Me.InstallationDirtextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.InstallationDirtextbox.UseSystemPasswordChar = False
        '
        'LogInLabel2
        '
        Me.LogInLabel2.AutoSize = True
        Me.LogInLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LogInLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogInLabel2.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LogInLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LogInLabel2.Location = New System.Drawing.Point(227, 138)
        Me.LogInLabel2.Name = "LogInLabel2"
        Me.LogInLabel2.Size = New System.Drawing.Size(116, 17)
        Me.LogInLabel2.TabIndex = 5
        Me.LogInLabel2.Text = "Installation folder :"
        '
        'RichTextLabel1
        '
        Me.RichTextLabel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextLabel1.Enabled = False
        Me.RichTextLabel1.ForeColor = System.Drawing.Color.White
        Me.RichTextLabel1.Location = New System.Drawing.Point(230, 217)
        Me.RichTextLabel1.Name = "RichTextLabel1"
        Me.RichTextLabel1.Size = New System.Drawing.Size(341, 38)
        Me.RichTextLabel1.TabIndex = 4
        Me.RichTextLabel1.Text = ""
        '
        'LogInLabel3
        '
        Me.LogInLabel3.BackColor = System.Drawing.Color.Transparent
        Me.LogInLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogInLabel3.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LogInLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LogInLabel3.Location = New System.Drawing.Point(227, 106)
        Me.LogInLabel3.Name = "LogInLabel3"
        Me.LogInLabel3.Size = New System.Drawing.Size(316, 23)
        Me.LogInLabel3.TabIndex = 3
        Me.LogInLabel3.Text = "The Installation will be done with these parameters:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(38, 63)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(176, 179)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'LogInLabel1
        '
        Me.LogInLabel1.AutoSize = True
        Me.LogInLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LogInLabel1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogInLabel1.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LogInLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LogInLabel1.Location = New System.Drawing.Point(224, 63)
        Me.LogInLabel1.Name = "LogInLabel1"
        Me.LogInLabel1.Size = New System.Drawing.Size(322, 32)
        Me.LogInLabel1.TabIndex = 0
        Me.LogInLabel1.Text = "Everything is ready to install!"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.DirectoryPath = Nothing
        '
        'Step3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(600, 327)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Step3"
        Me.Text = "Step3"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LogInLabel3 As InstallerSetup.LogInLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LogInLabel1 As InstallerSetup.LogInLabel
    Friend WithEvents RichTextLabel1 As InstallerSetup.RichTextLabel
    Friend WithEvents LogInLabel2 As InstallerSetup.LogInLabel
    Friend WithEvents InstallationDirtextbox As InstallerSetup.XylosTextBox
    Friend WithEvents KnightButton1 As InstallerSetup.KnightButton
    Friend WithEvents FolderBrowserDialog1 As InstallerSetup.FileBorserDialog.FolderBrowserDialog
End Class
