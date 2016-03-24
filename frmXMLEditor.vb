Option Explicit On
Option Strict On

Imports System.IO

Public Class frmXMLEditor

    Private bXMLBeingEditedBeforeSending As Boolean
    Public Sub New(Optional ByVal bEditXMLBEforeSend As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bXMLBeingEditedBeforeSending = bEditXMLBEforeSend

    End Sub
    Private Sub frmXMLEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetData()
    End Sub

    Private Sub butSendXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSendXML.Click
        If bXMLBeingEditedBeforeSending = True Then
            'editor launched to edit a "in process" message
            SendRequest(txtXML.Text, True)
            Me.Close()
        Else
            'xml editor was launched standalone
            SendRequest(txtXML.Text)
        End If
    End Sub


    Private Sub butGetLastSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetLastSend.Click
        GetData()
    End Sub

    Private Sub GetData()
        Dim strFileWithPath As String

        If Len(gstrLastXMLSent) > 0 Then
            txtXML.Text = gstrLastXMLSent
        Else
            strFileWithPath = My.Application.Info.DirectoryPath & "\" & gcstrLastXMLSentFileName

            Dim fiFile As New System.IO.FileInfo(strFileWithPath)
            If fiFile.Exists Then
                'load from file
                Dim myReader As New StreamReader(strFileWithPath)
                txtXML.Text = myReader.ReadToEnd
                myReader.Close()

            End If
        End If

        PositionCursorAtTextBoxEnd()
    End Sub
    Private Sub PositionCursorAtTextBoxEnd()
        'keep the text box text from highlighting by puttign the cursor at the end
        txtXML.Focus()
        txtXML.Select(txtXML.Text.Length, 0)
    End Sub


    Private Sub butSaveXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSaveXML.Click
        SaveFileDialogXML.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        SaveFileDialogXML.FilterIndex = 1
        SaveFileDialogXML.InitialDirectory = Application.StartupPath

        If SaveFileDialogXML.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim myStream As New StreamWriter(SaveFileDialogXML.FileName, True)
            myStream.Write(txtXML.Text)
            myStream.Close()
        End If

    End Sub

    Private Sub butLoadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLoadXML.Click
        OpenFileDialogXML.Title = "Please Select a File"
        OpenFileDialogXML.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        OpenFileDialogXML.FileName = String.Empty
        OpenFileDialogXML.FilterIndex = 1
        OpenFileDialogXML.InitialDirectory = Application.StartupPath

        If OpenFileDialogXML.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim myReader As New StreamReader(OpenFileDialogXML.FileName)
            txtXML.Text = myReader.ReadToEnd
            myReader.Close()
        End If

        PositionCursorAtTextBoxEnd()
    End Sub


    Private Sub butClearXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClearXML.Click
        txtXML.Text = String.Empty
    End Sub
End Class