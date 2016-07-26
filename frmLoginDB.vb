Option Explicit On
Option Strict On

Public Class frmLoginDB


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        End
    End Sub
    Private Sub SelectOk()
        Dim lpSectionName As String
        Dim strParameter As String
        Dim oini As New ini
        Dim strValue As String

        DBUserName = txtUsername.Text.ToUpper
        DBPassword = txtPassword.Text.ToUpper
        'DBPassword = "TEST3_RW"
        DBServer = txtDB.Text.ToUpper
        DBSid = txtSID.Text.ToUpper

        'write to ini 
        lpSectionName = "LastDBLogin"

        strParameter = "DBServer"
        strValue = DBServer
        Call oini.ProfileSaveItem(lpSectionName, strParameter, strValue, gstrIniFileName)

        strParameter = "DBSid"
        strValue = DBSid
        Call oini.ProfileSaveItem(lpSectionName, strParameter, strValue, gstrIniFileName)

        strParameter = "DBUser"
        strValue = DBUserName
        Call oini.ProfileSaveItem(lpSectionName, strParameter, strValue, gstrIniFileName)


        'write to ini 
        lpSectionName = "SocketCommunication"

        strParameter = "IPAddressOverrideLocalPC"
        gstrIPAddressOverrideLocalPC = txtIPAddressOverrideLocalPC.Text
        strValue = gstrIPAddressOverrideLocalPC
        Call oini.ProfileSaveItem(lpSectionName, strParameter, strValue, gstrIniFileName)



        Me.Close()
    End Sub


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        SelectOk()
    End Sub

    Private Sub frmLoginDB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Len(txtDB.Text) = 0 Then
            txtDB.Focus()
        ElseIf Len(txtSID.Text) = 0 Then
            txtSID.Focus()
        ElseIf Len(txtUsername.Text) = 0 Then
            txtUsername.Focus()
        Else
            txtPassword.Focus()
        End If
        lblIniFile.Text = "Using following files for this instance " + vbCrLf + gstrIniFileName + vbCrLf + gMdbFileName
    End Sub



    Private Sub frmLoginDB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblVersion.Text = "v" & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & _
       "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & _
       System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart

        Me.Text = "Database Login"

        Dim bAutoLogin As Boolean = False

        txtDB.Text = DBServer
        txtSID.Text = DBSid
        txtUsername.Text = DBUserName
        txtPassword.Text = vbNullString

        txtIPAddressOverrideLocalPC.Text = gstrIPAddressOverrideLocalPC


        radButAccess.Checked = False
        radButOracle.Checked = True
        grpDatabaseType.Visible = False
        grpOracleDatabase.Visible = True


        'autologon setting
        Timer1.Enabled = bAutoLogin

        chkDefeatAutoLogin.Visible = bAutoLogin


    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectOk()
        End If
    End Sub


    Private Sub lblVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVersion.Click
        txtUsername.Text = "test3"
        txtPassword.Text = "test3_rw"
        SelectOk()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If chkDefeatAutoLogin.Checked = False Then
            txtPassword.Text = "test3_rw"
            SelectOk()
        End If
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        txtPassword.Text = "test3_rw"
        SelectOk()
    End Sub

    Private Sub radButAccess_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radButAccess.CheckedChanged
        gstrDatabaseType = gcstrACCESS
        DatabaseTypeChange()
    End Sub

    Private Sub radButOracle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radButOracle.CheckedChanged
        gstrDatabaseType = "ORACLE"
        DatabaseTypeChange()
    End Sub

    Private Sub DatabaseTypeChange()

        'change and save the user selection
        Dim lpSectionName As String
        Dim strParameter As String
        Dim oini As ini

        oini = New ini

        'determine the database type to connect to
        If gstrDatabaseType = gcstrACCESS Then

            grpOracleDatabase.Visible = False
            gstrDatabaseType = gcstrACCESS

        Else

            grpOracleDatabase.Visible = True
            gstrDatabaseType = "ORACLE"
        End If



        'write to ini
        lpSectionName = "CONFIG"
        strParameter = "DATABASETYPE"
        Call oini.ProfileSaveItem(lpSectionName, strParameter, Convert.ToString(gstrDatabaseType), gstrIniFileName)

    End Sub

    Private Sub chkDefeatAutoLogin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDefeatAutoLogin.CheckedChanged

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        'txtPassword.Text = "zdevel3_RWz"
        txtPassword.Text = "devel3_RW"
        SelectOk()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        txtUsername.Text = "tst09"
        txtPassword.Text = "tst09_rw"
        SelectOk()
    End Sub
End Class