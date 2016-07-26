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
    'Public Sub New(ByVal Xmlstring As String)

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    bXMLBeingEditedBeforeSending = False

    '    'set the gstrLastXMLSent to the input xml
    '    gstrLastXMLSent = Xmlstring
    'End Sub
    Private Sub frmXMLEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GetData()
    End Sub

    Private Sub butSendXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSendXML.Click
        Dim sendStat As Boolean = False
        If bXMLBeingEditedBeforeSending = True Then
            'editor launched to edit a "in process" message
            sendStat = SendRequest(txtXML.Text, True)
            Me.Close()
        Else
            'xml editor was launched standalone
            sendStat = SendRequest(txtXML.Text)
        End If

        If (sendStat And ProcessData) Then
            'Update the dataGridRow in db
            updateTCS_TRAILER_EMU_MsgSts(DataGridRow)
            Load_TCS_TRAILER_EMU(DataGridRow.DataGridView)
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

    Dim processGridData As Boolean = False
    Public Property ProcessData As Boolean
        Get
            Return processGridData
        End Get
        Set(value As Boolean)
            processGridData = value
        End Set
    End Property

    Dim dgvRow As DataGridViewRow
    Public Property DataGridRow As DataGridViewRow
        Get
            Return dgvRow
        End Get
        Set(value As DataGridViewRow)
            dgvRow = value
        End Set
    End Property


End Class