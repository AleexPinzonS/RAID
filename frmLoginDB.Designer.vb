<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginDB
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginDB))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDB = New System.Windows.Forms.TextBox()
        Me.txtSID = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIPAddressOverrideLocalPC = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpOracleDatabase = New System.Windows.Forms.GroupBox()
        Me.grpDatabaseType = New System.Windows.Forms.GroupBox()
        Me.radButOracle = New System.Windows.Forms.RadioButton()
        Me.radButAccess = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkDefeatAutoLogin = New System.Windows.Forms.CheckBox()
        Me.grpOracleDatabase.SuspendLayout()
        Me.grpDatabaseType.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SID:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Username:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Password:"
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(74, 16)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(77, 20)
        Me.txtDB.TabIndex = 4
        '
        'txtSID
        '
        Me.txtSID.Location = New System.Drawing.Point(234, 17)
        Me.txtSID.Name = "txtSID"
        Me.txtSID.Size = New System.Drawing.Size(90, 20)
        Me.txtSID.TabIndex = 5
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(74, 53)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(185, 20)
        Me.txtUsername.TabIndex = 6
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(74, 95)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(185, 20)
        Me.txtPassword.TabIndex = 7
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(51, 275)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(101, 30)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(216, 275)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(101, 30)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.ForeColor = System.Drawing.Color.Blue
        Me.lblVersion.Location = New System.Drawing.Point(355, 9)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 10
        Me.lblVersion.Text = "Version"
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(320, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "."
        '
        'txtIPAddressOverrideLocalPC
        '
        Me.txtIPAddressOverrideLocalPC.Location = New System.Drawing.Point(144, 240)
        Me.txtIPAddressOverrideLocalPC.Name = "txtIPAddressOverrideLocalPC"
        Me.txtIPAddressOverrideLocalPC.Size = New System.Drawing.Size(185, 20)
        Me.txtIPAddressOverrideLocalPC.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 243)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "IPAddressOverrideLocalPC"
        '
        'grpOracleDatabase
        '
        Me.grpOracleDatabase.Controls.Add(Me.txtUsername)
        Me.grpOracleDatabase.Controls.Add(Me.Label1)
        Me.grpOracleDatabase.Controls.Add(Me.Label5)
        Me.grpOracleDatabase.Controls.Add(Me.Label2)
        Me.grpOracleDatabase.Controls.Add(Me.Label3)
        Me.grpOracleDatabase.Controls.Add(Me.Label4)
        Me.grpOracleDatabase.Controls.Add(Me.txtDB)
        Me.grpOracleDatabase.Controls.Add(Me.txtSID)
        Me.grpOracleDatabase.Controls.Add(Me.txtPassword)
        Me.grpOracleDatabase.Location = New System.Drawing.Point(9, 88)
        Me.grpOracleDatabase.Name = "grpOracleDatabase"
        Me.grpOracleDatabase.Size = New System.Drawing.Size(339, 122)
        Me.grpOracleDatabase.TabIndex = 14
        Me.grpOracleDatabase.TabStop = False
        Me.grpOracleDatabase.Text = "Oracle"
        '
        'grpDatabaseType
        '
        Me.grpDatabaseType.Controls.Add(Me.radButOracle)
        Me.grpDatabaseType.Controls.Add(Me.radButAccess)
        Me.grpDatabaseType.Location = New System.Drawing.Point(12, 9)
        Me.grpDatabaseType.Name = "grpDatabaseType"
        Me.grpDatabaseType.Size = New System.Drawing.Size(148, 66)
        Me.grpDatabaseType.TabIndex = 15
        Me.grpDatabaseType.TabStop = False
        Me.grpDatabaseType.Text = " Database Type"
        Me.grpDatabaseType.Visible = False
        '
        'radButOracle
        '
        Me.radButOracle.AutoSize = True
        Me.radButOracle.Enabled = False
        Me.radButOracle.Location = New System.Drawing.Point(38, 42)
        Me.radButOracle.Name = "radButOracle"
        Me.radButOracle.Size = New System.Drawing.Size(56, 17)
        Me.radButOracle.TabIndex = 1
        Me.radButOracle.TabStop = True
        Me.radButOracle.Text = "Oracle"
        Me.radButOracle.UseVisualStyleBackColor = True
        '
        'radButAccess
        '
        Me.radButAccess.AutoSize = True
        Me.radButAccess.Location = New System.Drawing.Point(38, 19)
        Me.radButAccess.Name = "radButAccess"
        Me.radButAccess.Size = New System.Drawing.Size(67, 17)
        Me.radButAccess.TabIndex = 0
        Me.radButAccess.TabStop = True
        Me.radButAccess.Text = "ACCESS"
        Me.radButAccess.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(94, 341)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(191, 45)
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'chkDefeatAutoLogin
        '
        Me.chkDefeatAutoLogin.AutoSize = True
        Me.chkDefeatAutoLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDefeatAutoLogin.Location = New System.Drawing.Point(265, 39)
        Me.chkDefeatAutoLogin.Name = "chkDefeatAutoLogin"
        Me.chkDefeatAutoLogin.Size = New System.Drawing.Size(133, 20)
        Me.chkDefeatAutoLogin.TabIndex = 17
        Me.chkDefeatAutoLogin.Text = "Defeat Auto Login"
        Me.chkDefeatAutoLogin.UseVisualStyleBackColor = True
        '
        'frmLoginDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 398)
        Me.Controls.Add(Me.chkDefeatAutoLogin)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.grpDatabaseType)
        Me.Controls.Add(Me.grpOracleDatabase)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.txtIPAddressOverrideLocalPC)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoginDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TopMost = True
        Me.grpOracleDatabase.ResumeLayout(False)
        Me.grpOracleDatabase.PerformLayout()
        Me.grpDatabaseType.ResumeLayout(False)
        Me.grpDatabaseType.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDB As System.Windows.Forms.TextBox
    Friend WithEvents txtSID As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIPAddressOverrideLocalPC As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grpOracleDatabase As System.Windows.Forms.GroupBox
    Friend WithEvents grpDatabaseType As System.Windows.Forms.GroupBox
    Friend WithEvents radButAccess As System.Windows.Forms.RadioButton
    Friend WithEvents radButOracle As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chkDefeatAutoLogin As System.Windows.Forms.CheckBox
End Class
