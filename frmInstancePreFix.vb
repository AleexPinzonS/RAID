Imports System.Windows.Forms

Public Class frmInstancePreFix
    Dim inicnt As Integer = 0
    Dim mdbCnt As Integer = 0
    Dim iniFilePattern As String = "*.ini"
    Dim mdbfilePattern As String = "*.mdb"
    Dim listofInstance As List(Of String)



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        gInstancePrefix = cboInstances.Text
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        cboInstances.Text = ""
        gInstancePrefix = ""

        Me.Close()
    End Sub

    Private Sub txtInstancePrefix_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmInstancePreFix_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Check if there are multiple .ini and .mdb files in 
        'ProgramData/RAID directory.

        gstrProgramDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\" & Application.ProductName & "\"
        gstrIniFileName = gstrProgramDataPath & gApplication_ProductName & ".ini"

        'inicnt = My.Computer.FileSystem.GetFiles(gstrProgramDataPath + "*.ini").Count

        'If (inicnt > 1) Then
        'MsgBox("Found " & inicnt & " ini files found")

        Dim filename As String = ""
        For Each file As String In My.Computer.FileSystem.GetFiles(gstrProgramDataPath, FileIO.SearchOption.SearchTopLevelOnly, {"*.ini"})
            filename = file.Substring(Len(gstrProgramDataPath)) ' removed dir
            filename = filename.Substring(0, InStr(filename, ".") - 1)
            'cboInstances.Items.Add(filename.Substring(0, InStr(filename, ".") - 1))
            If (System.IO.File.Exists(gstrProgramDataPath + filename + ".mdb")) Then
                If (InStr(filename, "_") = 0) Then
                    cboInstances.Items.Add("Default")
                Else
                    cboInstances.Items.Add(filename.Substring(0, InStr(filename, "_") - 1))
                End If
            End If
            'System.Console.Write(filename.Substring(0, InStr(filename, ".") - 1) + vbCrLf)
            'System.Console.Write(filename + vbCrLf)
            'System.Console.Write(file.Substring(Len(gstrProgramDataPath), InStr(file, "_")) + vbCrLf)
        Next
        'End If

    End Sub

    Private Sub frmInstancePreFix_Activated(sender As Object, e As EventArgs) Handles Me.Activated


        inicnt = My.Computer.FileSystem.GetFiles(gstrProgramDataPath, FileIO.SearchOption.SearchTopLevelOnly, "*.ini").Count
        mdbCnt = My.Computer.FileSystem.GetFiles(gstrProgramDataPath, FileIO.SearchOption.SearchTopLevelOnly, "*.mdb").Count


    End Sub


End Class
