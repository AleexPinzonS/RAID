<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXMLEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmXMLEditor))
        Me.txtXML = New System.Windows.Forms.TextBox()
        Me.butSendXML = New System.Windows.Forms.Button()
        Me.butGetLastSend = New System.Windows.Forms.Button()
        Me.OpenFileDialogXML = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialogXML = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.butClearXML = New System.Windows.Forms.Button()
        Me.butLoadXML = New System.Windows.Forms.Button()
        Me.butSaveXML = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtXML
        '
        Me.txtXML.AcceptsReturn = True
        Me.txtXML.Location = New System.Drawing.Point(15, 86)
        Me.txtXML.Multiline = True
        Me.txtXML.Name = "txtXML"
        Me.txtXML.Size = New System.Drawing.Size(669, 316)
        Me.txtXML.TabIndex = 0
        '
        'butSendXML
        '
        Me.butSendXML.Location = New System.Drawing.Point(6, 18)
        Me.butSendXML.Name = "butSendXML"
        Me.butSendXML.Size = New System.Drawing.Size(84, 34)
        Me.butSendXML.TabIndex = 59
        Me.butSendXML.Text = "Send Text"
        Me.butSendXML.UseVisualStyleBackColor = True
        '
        'butGetLastSend
        '
        Me.butGetLastSend.Location = New System.Drawing.Point(15, 24)
        Me.butGetLastSend.Name = "butGetLastSend"
        Me.butGetLastSend.Size = New System.Drawing.Size(84, 34)
        Me.butGetLastSend.TabIndex = 60
        Me.butGetLastSend.Text = "Get Last XML Sent"
        Me.butGetLastSend.UseVisualStyleBackColor = True
        '
        'OpenFileDialogXML
        '
        Me.OpenFileDialogXML.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.butClearXML)
        Me.GroupBox1.Controls.Add(Me.butLoadXML)
        Me.GroupBox1.Controls.Add(Me.butSaveXML)
        Me.GroupBox1.Controls.Add(Me.butSendXML)
        Me.GroupBox1.Location = New System.Drawing.Point(106, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(438, 68)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "XML Control"
        '
        'butClearXML
        '
        Me.butClearXML.Location = New System.Drawing.Point(276, 17)
        Me.butClearXML.Name = "butClearXML"
        Me.butClearXML.Size = New System.Drawing.Size(84, 34)
        Me.butClearXML.TabIndex = 62
        Me.butClearXML.Text = "Clear Text"
        Me.butClearXML.UseVisualStyleBackColor = True
        '
        'butLoadXML
        '
        Me.butLoadXML.Location = New System.Drawing.Point(186, 17)
        Me.butLoadXML.Name = "butLoadXML"
        Me.butLoadXML.Size = New System.Drawing.Size(84, 34)
        Me.butLoadXML.TabIndex = 61
        Me.butLoadXML.Text = "Load Text"
        Me.butLoadXML.UseVisualStyleBackColor = True
        '
        'butSaveXML
        '
        Me.butSaveXML.Location = New System.Drawing.Point(96, 17)
        Me.butSaveXML.Name = "butSaveXML"
        Me.butSaveXML.Size = New System.Drawing.Size(84, 34)
        Me.butSaveXML.TabIndex = 60
        Me.butSaveXML.Text = "Save Text"
        Me.butSaveXML.UseVisualStyleBackColor = True
        '
        'frmXMLEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 493)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.butGetLastSend)
        Me.Controls.Add(Me.txtXML)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmXMLEditor"
        Me.Text = "XML Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtXML As System.Windows.Forms.TextBox
    Friend WithEvents butSendXML As System.Windows.Forms.Button
    Friend WithEvents butGetLastSend As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialogXML As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialogXML As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents butSaveXML As System.Windows.Forms.Button
    Friend WithEvents butLoadXML As System.Windows.Forms.Button
    Friend WithEvents butClearXML As System.Windows.Forms.Button
End Class
