Imports System.Windows.Forms

Public Class frmPrompt

    Protected m_BlankValid As Boolean = True
    Protected m_ReturnText As String = String.Empty
    Protected m_NumericField As Boolean
    Protected m_ZeroOk As Boolean
    Protected m_EntryError As Boolean

    Public Overloads Function ShowDialog( _
      ByVal TitleText As String, _
      ByVal DefaultText As String, _
      ByRef EnteredText As String, _
      ByVal BlankValid As Boolean, _
      ByVal NumericField As Boolean,
      ByVal ZeroOk As Boolean) As System.Windows.Forms.DialogResult

        m_BlankValid = BlankValid
        m_NumericField = NumericField
        m_ZeroOk = ZeroOk
        Dim iCount As Integer = 0

        Me.Text = TitleText
        Me.txtTextEntry.Text = DefaultText
        If NumericField = True Then
            lblType.Text = "Numeric"
            lblZero.Visible = True
            lblZeroLabel.Visible = True
            If ZeroOk = True Then
                lblZero.Text = gcstrY
            Else
                lblZero.Text = gcstrN
            End If
        Else
            lblType.Text = "AlphaNumeric"
            lblZero.Visible = False
            lblZeroLabel.Visible = False
        End If
        Me.ShowDialog()

        While m_EntryError = True
            'set the value back to the original 
            Me.txtTextEntry.Text = DefaultText
            Me.ShowDialog()

        End While

        EnteredText = m_ReturnText

        Return Me.DialogResult
    End Function

    Public Overloads Shared Function Show(ByVal TitleText As String, ByVal promptText As String, ByVal DefaultText As String, ByRef TextInputted As String, ByVal IsEmptyValid As Boolean, ByVal NumericField As Boolean, ByVal ZeroOk As Boolean) As System.Windows.Forms.DialogResult
        Dim tmp As New frmPrompt
        Return tmp.ShowDialog(TitleText, DefaultText, TextInputted, IsEmptyValid, NumericField, ZeroOk)
    End Function

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.txtTextEntry.Text = "" Then
            Me.butOK.Enabled = m_BlankValid
        Else
            Me.butOK.Enabled = True
        End If
    End Sub

    Private Sub butOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click
        m_EntryError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If m_NumericField = True Then
            If IsNumeric(Me.txtTextEntry.Text) = False Then
                MessageBox.Show("Please Enter a Numeric Value", "User Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                m_EntryError = True
                Exit Sub
            Else
                If m_ZeroOk = False And CInt(Me.txtTextEntry.Text) <= 0 Then
                    MessageBox.Show("Please Enter a Numeric Value Greater than Zero", "User Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    m_EntryError = True
                    Exit Sub
                End If
            End If
        End If

        m_ReturnText = Me.txtTextEntry.Text
        Me.Close()
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        m_EntryError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        m_ReturnText = ""
        Me.Close()
    End Sub

    Private Sub frmPrompt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtTextEntry.Select(txtTextEntry.Text.Length, 0)    'position cursor at end
    End Sub
End Class