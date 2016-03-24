<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrompt
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
        Me.butOK = New System.Windows.Forms.Button()
        Me.txtTextEntry = New System.Windows.Forms.TextBox()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.lblZeroLabel = New System.Windows.Forms.Label()
        Me.lblTypeLabel = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblZero = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(158, 116)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(76, 38)
        Me.butOK.TabIndex = 1
        Me.butOK.Text = "OK"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'txtTextEntry
        '
        Me.txtTextEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTextEntry.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtTextEntry.Location = New System.Drawing.Point(12, 79)
        Me.txtTextEntry.Name = "txtTextEntry"
        Me.txtTextEntry.Size = New System.Drawing.Size(481, 22)
        Me.txtTextEntry.TabIndex = 0
        '
        'butCancel
        '
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(253, 116)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(76, 38)
        Me.butCancel.TabIndex = 2
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'lblZeroLabel
        '
        Me.lblZeroLabel.AutoSize = True
        Me.lblZeroLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZeroLabel.Location = New System.Drawing.Point(52, 49)
        Me.lblZeroLabel.Name = "lblZeroLabel"
        Me.lblZeroLabel.Size = New System.Drawing.Size(81, 15)
        Me.lblZeroLabel.TabIndex = 3
        Me.lblZeroLabel.Text = "Zero Allowed:"
        Me.lblZeroLabel.Visible = False
        '
        'lblTypeLabel
        '
        Me.lblTypeLabel.AutoSize = True
        Me.lblTypeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTypeLabel.Location = New System.Drawing.Point(49, 19)
        Me.lblTypeLabel.Name = "lblTypeLabel"
        Me.lblTypeLabel.Size = New System.Drawing.Size(84, 15)
        Me.lblTypeLabel.TabIndex = 4
        Me.lblTypeLabel.Text = "Variable Type:"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblType.Location = New System.Drawing.Point(148, 19)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(85, 15)
        Me.lblType.TabIndex = 6
        Me.lblType.Text = "AlphaNumeric"
        '
        'lblZero
        '
        Me.lblZero.AutoSize = True
        Me.lblZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZero.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblZero.Location = New System.Drawing.Point(151, 49)
        Me.lblZero.Name = "lblZero"
        Me.lblZero.Size = New System.Drawing.Size(27, 15)
        Me.lblZero.TabIndex = 5
        Me.lblZero.Text = "Yes"
        Me.lblZero.Visible = False
        '
        'frmPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(521, 186)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.lblZero)
        Me.Controls.Add(Me.lblTypeLabel)
        Me.Controls.Add(Me.lblZeroLabel)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.txtTextEntry)
        Me.Controls.Add(Me.butOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrompt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Prompt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents txtTextEntry As System.Windows.Forms.TextBox
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents lblZeroLabel As System.Windows.Forms.Label
    Friend WithEvents lblTypeLabel As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblZero As System.Windows.Forms.Label
End Class
