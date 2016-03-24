Option Strict On
Option Explicit On
Imports System.Windows.Forms
Imports VB = Microsoft.VisualBasic

Public Class frmConfig

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub DisplayIniSection()
        'Dim flxGrid1 As Object
        Dim x As Integer
        Dim y As Integer
        flxGrid1.Rows = 2
        flxGrid1.Cols = 4
        flxGrid1.Row = 1


        For y = 1 To flxGrid1.Cols
            flxGrid1.Col = y - 1
            flxGrid1.set_ColAlignment(flxGrid1.Col, Convert.ToInt16(MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter))

            'ensure row 1 is blank
            flxGrid1.Text = vbNullString
            Select Case flxGrid1.Col
                Case 0
                    flxGrid1.set_ColWidth(flxGrid1.Col, 3500)

                Case 1
                    flxGrid1.set_ColWidth(flxGrid1.Col, 7500)

                Case Else
                    'hidden
                    flxGrid1.set_ColWidth(flxGrid1.Col, 0)


            End Select
        Next



        flxGrid1.Row = 0
        flxGrid1.Col = 0
        flxGrid1.Text = "Parameter"
        flxGrid1.Col = 1
        flxGrid1.Text = "Setting"
        flxGrid1.Col = 2
        flxGrid1.Text = "Numeric"
        flxGrid1.Col = 3
        flxGrid1.Text = "Zero Allowed"

        For x = 1 To IniRecordCount
            If IniEntries(x).SectionName = gstrPassIniSection Then
                flxGrid1.Row += 1
                flxGrid1.Col = 0
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore
                flxGrid1.Text = vbNullString & IniEntries(x).KeyName
                flxGrid1.Col = 1
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore
                flxGrid1.Text = vbNullString & IniEntries(x).Value
                flxGrid1.Col = 2
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore
                flxGrid1.Text = vbNullString & IniEntries(x).Numeric
                flxGrid1.Col = 3
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore
                flxGrid1.Text = vbNullString & IniEntries(x).ZeroAllowed

                flxGrid1.Rows += 1
            End If
        Next

        'get rid of last blank grid row
        flxGrid1.Rows -= 1

    End Sub

    Private Sub ModifyEntry(ByRef iRowSel As Integer, ByRef bAddingEntry As Boolean)


        Dim strValue As String
        Dim strParameter As String
        Dim lpSectionName As String
        Dim NumericType As Boolean = False
        Dim ZeroOk As Boolean = False
        Dim oini As ini

        oini = New ini

        Try

            If iRowSel = 0 Then Exit Sub


            strParameter = Trim(flxGrid1.get_TextMatrix(iRowSel, 0))
            strValue = Trim(flxGrid1.get_TextMatrix(iRowSel, 1))
            If Trim(flxGrid1.get_TextMatrix(iRowSel, 2)).ToUpper = "TRUE" Then
                NumericType = True
            End If

            If Trim(flxGrid1.get_TextMatrix(iRowSel, 3)).ToUpper = "TRUE" Then
                ZeroOk = True
            End If

            '  strInputBox = InputBox(vbNullString, strParameter, strValue)
            Dim strReturnedText As String = String.Empty
            Dim result As DialogResult = frmPrompt.ShowDialog(strParameter, strValue, strReturnedText, True, NumericType, ZeroOk)

            If result = Windows.Forms.DialogResult.Cancel Then
                Exit Sub

            Else
                'save to grid
                flxGrid1.set_TextMatrix(iRowSel, 1, Trim(strReturnedText))

                'write to ini
                lpSectionName = gstrPassIniSection
                Call oini.ProfileSaveItem(lpSectionName, strParameter, UCase(strReturnedText), gstrIniFileName)

                'reread ini file data to get changes
                Call Ini_Main()

            End If

        Catch

        End Try

    End Sub
    Private Sub frmConfig_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = gstrPassIniSection
        Call DisplayIniSection()
    End Sub

    Private Sub flxGrid1_MouseDownEvent1(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid1.MouseDownEvent
        Dim iRowSel As Integer


        iRowSel = flxGrid1.RowSel

        'can't select header of last blank line
        If iRowSel = 0 Then Exit Sub

        Call ModifyEntry(iRowSel, False)

    End Sub


    Private Sub flxGrid1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flxGrid1.Enter

    End Sub
End Class
