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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDllPath = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblInvalidRegasmPath = New System.Windows.Forms.Label()
        Me.txtRegasmPath = New System.Windows.Forms.TextBox()
        Me.labelForRegasm = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDllInfo = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COM DLL : "
        '
        'txtDllPath
        '
        Me.txtDllPath.Location = New System.Drawing.Point(81, 16)
        Me.txtDllPath.Name = "txtDllPath"
        Me.txtDllPath.ReadOnly = True
        Me.txtDllPath.Size = New System.Drawing.Size(727, 20)
        Me.txtDllPath.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(730, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 27)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Select"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(15, 81)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(141, 27)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Register"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLog)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(11, 114)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(438, 187)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Output"
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.Black
        Me.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.ForeColor = System.Drawing.Color.White
        Me.txtLog.Location = New System.Drawing.Point(3, 16)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.Size = New System.Drawing.Size(432, 168)
        Me.txtLog.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(171, 81)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(141, 27)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "UnRegister"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'lblInvalidRegasmPath
        '
        Me.lblInvalidRegasmPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvalidRegasmPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblInvalidRegasmPath.ForeColor = System.Drawing.Color.Red
        Me.lblInvalidRegasmPath.Location = New System.Drawing.Point(81, 43)
        Me.lblInvalidRegasmPath.Name = "lblInvalidRegasmPath"
        Me.lblInvalidRegasmPath.Size = New System.Drawing.Size(52, 23)
        Me.lblInvalidRegasmPath.TabIndex = 14
        Me.lblInvalidRegasmPath.Text = "Invalid"
        Me.lblInvalidRegasmPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRegasmPath
        '
        Me.txtRegasmPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRegasmPath.BackColor = System.Drawing.SystemColors.Control
        Me.txtRegasmPath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRegasmPath.Location = New System.Drawing.Point(138, 48)
        Me.txtRegasmPath.Name = "txtRegasmPath"
        Me.txtRegasmPath.ReadOnly = True
        Me.txtRegasmPath.Size = New System.Drawing.Size(552, 13)
        Me.txtRegasmPath.TabIndex = 13
        '
        'labelForRegasm
        '
        Me.labelForRegasm.AutoSize = True
        Me.labelForRegasm.Location = New System.Drawing.Point(4, 47)
        Me.labelForRegasm.Name = "labelForRegasm"
        Me.labelForRegasm.Size = New System.Drawing.Size(79, 13)
        Me.labelForRegasm.TabIndex = 12
        Me.labelForRegasm.Text = "Regasm path->"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDllInfo)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(455, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(353, 187)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DLL Info"
        '
        'txtDllInfo
        '
        Me.txtDllInfo.BackColor = System.Drawing.Color.Black
        Me.txtDllInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDllInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDllInfo.ForeColor = System.Drawing.Color.White
        Me.txtDllInfo.Location = New System.Drawing.Point(3, 16)
        Me.txtDllInfo.Name = "txtDllInfo"
        Me.txtDllInfo.Size = New System.Drawing.Size(347, 168)
        Me.txtDllInfo.TabIndex = 0
        Me.txtDllInfo.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(820, 313)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblInvalidRegasmPath)
        Me.Controls.Add(Me.txtRegasmPath)
        Me.Controls.Add(Me.labelForRegasm)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDllPath)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Com Object Registerer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDllPath As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Private WithEvents lblInvalidRegasmPath As System.Windows.Forms.Label
    Private WithEvents txtRegasmPath As System.Windows.Forms.TextBox
    Private WithEvents labelForRegasm As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDllInfo As System.Windows.Forms.RichTextBox

End Class
