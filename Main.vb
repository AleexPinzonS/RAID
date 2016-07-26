Option Explicit On
Option Strict On
Imports Microsoft.VisualBasic
Imports System.Reflection.MethodBase    'used to get procedure name for error logging
Imports ADOX
Imports System.Data
Imports System.Linq


Public Class Main

    Public SocketServer As AsynchronousSocketListener
    Public SecondSocketServer As AsynchronousSocketListener
    Const bBypassDB As Boolean = False
    Public dbConStatus As Integer
    Public dbConStatusAccess As Integer
    Public piTabSelected As Integer
    Public bToggle As Boolean
    Public pstrPLNumb As String
    Public PromptForUserConfirmation As Boolean = True
    Public SendHeartbeatAutomatically As Boolean = False
    Public UserTextBoxestoSave As TextBox()
    Public Structure Cust_pallet
        Dim strCust_ID As String
        Dim strPallet_Type As String
        Dim Code_Date As String
    End Structure


    Private Sub Main_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        SocketServer.CloseSockets()
        SecondSocketServer.CloseSockets()
    End Sub


    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Ensure that the user doesn't mistakenly close 

        Dim iMsgResult As DialogResult
        iMsgResult = (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
        If iMsgResult = Windows.Forms.DialogResult.Yes Then
            e.Cancel = False
            SaveLastXMLSent()
            SaveLastUserValues()
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub SaveLastXMLSent()
        'save the Last XML Sent at form closing to use in the XML editor form

        Dim myStream As New System.IO.StreamWriter(gstrProgramDataPath & gcstrLastXMLSentFileName, True)
        myStream.Write(gstrLastXMLSent)
        myStream.Close()
    End Sub
    Private Sub SaveLastUserValues()

        Dim lpSectionName As String = "LastUserValues"
        Dim oini As ini
        oini = New ini

        'write to ini  to save last user enterable values
        Try
            If UserTextBoxestoSave Is Nothing Then Exit Sub 'in case no text boxes are defined to be saved as the control array is built into the restore routine


            For Each oTextBox As TextBox In UserTextBoxestoSave
                oini.ProfileSaveItem(lpSectionName, oTextBox.Name, oTextBox.Text, gstrIniFileName)

            Next
        Catch

            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub RestoreLastUserValues()

        Dim lpSectionName As String = "LastUserValues"
        Dim oini As ini
        oini = New ini

        UserTextBoxestoSave = {
                                txtMsg21_MOT_CODE,
                                txtRequestNextProdOrder_DeliveryLocation,
                                txtlblRaid_Msg23_SelectedSlot,
                                txtShipULPickUp_Load_Flag,
                                txtMsg11_Tech_Group,
                                txtMsg11_RDT_Message,
                                txtInfeedRestrictToUlPall,
                                txtInfeedRestrictToCtlgrp,
                                txtInfeedRestrictToItem,
                                txtReconcileItmCod
                              }

        'get last user enterable values

        For Each oTextBox As TextBox In UserTextBoxestoSave
            oTextBox.Text = oini.ProfileGetItem(lpSectionName, oTextBox.Name, "", gstrIniFileName)
        Next

    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Startup()
    End Sub
    Private Sub Startup()
        Dim x As Integer
        Dim strVersion As String
        Dim strSocket As String
        Dim bRetry As Boolean
        Dim instancePrefix As String = ""

        gstrProgramDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\" & Application.ProductName & "\"

        If (My.Computer.FileSystem.GetFiles(gstrProgramDataPath, FileIO.SearchOption.SearchTopLevelOnly, "*.ini").Count > 1) Then

            Dim frmGetPrefix As New frmInstancePreFix

            frmGetPrefix.ShowDialog()
            'instancePrefix = frmGetPrefix.txtInstancePrefix.Text
            instancePrefix = gInstancePrefix
            'instancePrefix = frmGetPrefix.cboInstances.Text
            If (instancePrefix = "Default") Then
                instancePrefix = ""
            End If
        End If


        If (Len(instancePrefix) > 0) Then
            gApplication_ProductName = instancePrefix + "_" + Application.ProductName
        Else
            gApplication_ProductName = Application.ProductName
        End If
        cstrLogFilePrefix = gApplication_ProductName

        'Set the variables for color
        colorFore = System.Drawing.Color.Black
        colorBack = System.Drawing.Color.White

        PositionFormatStartup()

        WriteLog("Startup ", vbNullString)

        'use the configuration settings
        Ini_Main()

        strVersion = "v" & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart

        'Me.Text = Application.ProductName & Space(1) & strVersion & Space(2) & "(ASRS Emulator)"
        Me.Text = gApplication_ProductName & Space(1) & strVersion & Space(2) & "(ASRS Emulator)" & "-  [" & gstrXML_WCS_ID & "]"

        'fix the tab page colors - issue with settign this on the page properties always revert to white  arrghh
        For Each tPage As TabPage In TabControl1.TabPages
            tPage.BackColor = Color.FromKnownColor(KnownColor.Control)
        Next

        'set initial state of various buttons
        btnInfeedAutoScanOff.BackColor = Color.Red
        btnASRSInfeedAutoScanOff.BackColor = Color.Red
        butMsg13AutoScanOff.BackColor = Color.Red
        butMsg21AutoSendOff.BackColor = Color.Red
        butMsg22AutoSendOff.BackColor = Color.Red
        butMsg24AutoSendOff.BackColor = Color.Red
        btnFPDSAutoScanOff.BackColor = Color.Red

        ConnectToRAIDDatabase()

        'give user 3 chances to login into WCS database
        'SAJJAD UNCOMMENT THIS
        For x = 1 To 3
            bRetry = TryLogintoWMSDatabase()
            If bRetry = False Then
                Exit For   'user logged in successfully or decided to skip WMS connect
            Else
                If x = 3 Then
                    MessageBox.Show("Check all parameters and credentials before trying again", "Too Many WMS Database Login Failures", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If
        Next

        'Write the version and settings to the log file
        WriteLog("START", Strings.StrDup(60, "-"))
        WriteLog("Version ", String.Format("Version {0}", My.Application.Info.Version.ToString))

        'start socket listener(s)
        For x = 1 To gstrSocketPort.GetUpperBound(0)
            'should always be 1
            strSocket = gstrSocketPort(x)

            If IsNumeric(strSocket) Then
                If CInt(strSocket) > 0 Then
                    SocketServer = New AsynchronousSocketListener(gstrSocketPort(x))
                End If

            End If
        Next

        gstrLocalListenerIP = GetIPAddress()
        WriteLog("MyIP ", gstrLocalListenerIP)
        For x = 1 To IniRecordCount
            WriteLog("Setting", IniEntries(x).KeyName & "=" & IniEntries(x).Value)
        Next

        RestoreLastUserValues()

        ToolStripStatusLblConnections.Text = "Host Connection:" & Space(1) & gstrSocketServerIP & Space(2) & "Port: " & gstrSocketServerPort & " | DB: " & DBServer & "/" & DBUserName

        ApplyDatabasePatches(strVersion.ToUpper, False)
        AnyRequiredDatabaseTablesMissing()

        'summary page setup
        'SetupGraphicalSummary()
        TabControl1.Controls.Remove(TabPage10)



        'Display the first tab
        piTabSelected = 1
        GetandDisplayInfeedData()

        RefreshLog()


    End Sub
    Private Function TryLogintoWMSDatabase() As Boolean
        'Present User Form to Login into DATABASE
        Dim LoginMsgBoxResult As DialogResult
        Dim formLogin As New frmLoginDB

        TryLogintoWMSDatabase = False

        formLogin.ShowDialog()

        If ConnectToWMSDatabase() = False Then
            LoginMsgBoxResult = MessageBox.Show("Yes to Try Again" & vbCrLf & vbCrLf & "No to Skip WMS Login" & vbCrLf & vbCrLf & "Cancel to Exit Program" & vbCrLf & vbCrLf, "Unable To Connect to WMS Database", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            If LoginMsgBoxResult = DialogResult.Yes Then
                TryLogintoWMSDatabase = True
            ElseIf LoginMsgBoxResult = DialogResult.No Then
                'dont retry login just move on

            Else

                'user cancelled
                End
            End If

        End If
    End Function
    Private Sub RefreshLog()
        'display the contents of today's log file to the main screen
        Dim FilePath As String


        Try
            FilePath = LogFileName()

            txtLog.Text = My.Computer.FileSystem.ReadAllText(FilePath)

            If txtLog.Lines.GetUpperBound(0) > giMaxLinesCurrentSystemLogFile Then
                KeepLogFileSizeUnderControl(FilePath)
            End If

            txtLog.SelectionStart = txtLog.TextLength
            txtLog.ScrollToCaret()

            butRefresh.BackColor = Color.FromKnownColor(KnownColor.Control)
            ToolStripStatusLabelRefresh.Visible = False

            'highlight errors
            SearchLog("ERROR ", Color.Red) 'with the space to avoid finding ini parameters!

            DisplayMessageTimeStamps()
        Catch
            ' move on

        End Try
    End Sub
    Private Sub KeepLogFileSizeUnderControl(ByVal strLogFile As String)
        Dim strLogFile_1 As String
        Dim fiFile As New System.IO.FileInfo(strLogFile)
        Try


            strLogFile_1 = strLogFile & "_" & Hour(Now).ToString.PadLeft(2, gcCharZero) & Minute(Now).ToString.PadLeft(2, gcCharZero) & ".log"

            fiFile.CopyTo(strLogFile_1)

            'purge the log file
            fiFile.Delete()

        Catch

            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try

    End Sub
    Private Sub SearchLog(ByVal SearchText As String, ByVal HighLightColor As Color)
        Try
            Dim textEnd As Integer = txtLog.TextLength
            Dim index As Integer = 0
            Dim lastIndex As Integer = txtLog.Text.LastIndexOf(SearchText)

            While index < lastIndex
                txtLog.Find(SearchText, index, textEnd, RichTextBoxFinds.None)
                txtLog.SelectionBackColor = HighLightColor
                txtLog.SelectionColor = Color.White
                index = txtLog.Text.IndexOf(SearchText, index) + 1
            End While
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub


    Private Sub MainToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainToolStripMenuItem.Click
        ShowIniForm("Config")
    End Sub

    Private Sub WriteLog(ByVal strAction As String, ByVal strText As String)
        Dim FilePath As String

        Try
            If Len(strText) = 0 Then Exit Sub
            If giMessageLogLevel = -1 Then Exit Sub

            FilePath = LogFileName()
            My.Computer.FileSystem.WriteAllText(FilePath, Now & " | " & strAction.PadRight(15, Convert.ToChar(" ")) & strText.Trim & vbCrLf, True)
            gbNewOutboundData = True
        Catch

        Finally
            tmrRefreshLog.Enabled = True
        End Try
    End Sub


    Private Sub DeleteOldLogFiles()
        Dim DaysOld As Integer
        Dim DeleteTime As DateTime

        Try

            DaysOld = giKeepLogDays
            DeleteTime = Today.AddDays(DaysOld * -1)

            For Each fullFilePath As String In My.Computer.FileSystem.GetFiles(gstrProgramDataPath)
                If Strings.Right(fullFilePath.ToUpper, 4) = ".LOG" Then
                    If Strings.InStr(fullFilePath, cstrLogFilePrefix) > 1 Then

                        Dim fiFile As New System.IO.FileInfo(fullFilePath)
                        If fiFile.Exists Then
                            If fiFile.LastWriteTime < DeleteTime Then
                                fiFile.Delete()
                            End If

                        End If

                    End If
                End If
                Debug.Print(fullFilePath)
            Next

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally
            WriteLog("Purged Logs", "Older than " & DeleteTime)

        End Try
    End Sub

    Private Sub DeleteOldLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteOldLogsToolStripMenuItem.Click
        DeleteOldLogFiles()
    End Sub
    Private Function ConnectToRAIDDatabase() As Boolean

        Dim strDatabase As String = Application.ProductName & ".mdb"

        ConnectToRAIDDatabase = False

        Try

            'Make the database connection with the above parameters
            If bBypassDB = False Then

                oDataBaseConnection = New DatabaseConnections

                'strDatabase = Application.ProductName & ".mdb"
                strDatabase = gApplication_ProductName & ".mdb"

                gMdbFileName = gstrProgramDataPath & strDatabase

                WriteLog("Initialize ", "Using mdb file ... " + gstrProgramDataPath & strDatabase)

                dbConStatus = oDataBaseConnection.ConnectToAccessDB(
                                         gstrProgramDataPath & strDatabase)
                If dbConStatus = -1 Then
                    Call oDataBaseConnection.DisplayDatabaseConnectionError(
                       strDatabase)
                    ConnectToRAIDDatabase = False
                Else
                    ConnectToRAIDDatabase = True

                End If



            End If
        Catch
            ConnectToRAIDDatabase = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Function
    Private Function ConnectToWMSDatabase() As Boolean

        Dim strDatabase As String
        ConnectToWMSDatabase = False

        Try

            'Make the database connection with the above parameters
            If bBypassDB = False Then

                oDataBaseConnection = New DatabaseConnections


                'oracle  dbcon2
                strDatabase = "RTCIS"
                dbConStatus = oDataBaseConnection.ConnectToDB(DBUserName, DBPassword)

                If dbConStatus = -1 Then
                    '   Call oDataBaseConnection.DisplayDatabaseConnectionError( strDatabase)
                    ConnectToWMSDatabase = False
                    WriteLog(gcstrError, "Login Failed to WMS Database")
                Else
                    ConnectToWMSDatabase = True
                End If

            End If
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            ConnectToWMSDatabase = False
        End Try

    End Function


    Private Sub SendXMLFromFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendXMLFromFileToolStripMenuItem.Click
        Dim strFilename As String
        Dim strXML As String

        Try
            strFilename = InputBox("Enter Complete Filepath and Filename including Extension:", "Specify File", gstrDefaultFolderForXMLFiles)

            If Len(strFilename) > 0 Then
                strXML = My.Computer.FileSystem.ReadAllText(strFilename)

                WriteLog("Sending", strFilename)

                SendRequest(strXML)
            End If
        Catch
            MessageBox.Show("Error with XML" & vbCrLf & vbCrLf & Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub


    Private Sub tmrRefreshLog_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefreshLog.Tick
        Try
            If gbNewInboundData = True Then
                butRefresh.BackColor = Color.Green
                ToolStripStatusLabelRefresh.Visible = True

                If chkAutoRefresh.Checked = True Then
                    tmrBlink.Enabled = True
                    RefreshLog()
                End If

            End If

            If gbNewOutboundData = True Then
                If chkAutoRefresh.Checked = True Then
                    RefreshLog()
                End If

            End If

            gbNewInboundData = False
            gbNewOutboundData = False

            'Load_TCS_TRAILER_EMU(dgvTrlActivityData)

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Err.Description)
        Finally

        End Try
    End Sub

    Private Sub SendHeartbeatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendHeartbeatToolStripMenuItem.Click
        SendHeartbeat()
    End Sub
    Private Sub SendHeartbeat()
        WriteLog("Send", "Heartbeat")
        Dim strTest As String = CreateXMLHeartbeat(Now.ToString)

        SendRequest(strTest)

    End Sub

    Private Sub ServiceStepsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiceStepsToolStripMenuItem.Click
        'close all popup windows

        Dim objType As Type() = Reflection.Assembly.GetExecutingAssembly.GetTypes()
        Dim x As Integer
        Try

            For x = Application.OpenForms.Count - 1 To 0 Step -1

                'MessageBox.Show(Application.OpenForms.Item(x).Name)
                If Application.OpenForms.Item(x).Name = "frmStepDetail" Or
                  Application.OpenForms.Item(x).Name = "frmXMLEditor" Then

                    Application.OpenForms.Item(x).Close()
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error Closing Popups" & ex.Message)
        Finally

        End Try

    End Sub


    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim formAbout As New AboutBox1

        AboutBox1.ShowDialog()
    End Sub

    Private Sub TabPage1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter
        TabPageSelected(CType(sender, TabPage))
    End Sub

    Private Sub TabPageSelected(ByVal oTab As TabPage)
        Static strCurrentSelected As String

        If strCurrentSelected = oTab.Name Then
            Exit Sub
        Else
            strCurrentSelected = oTab.Name
        End If


        Select Case oTab.Name

            Case "TabPage1"

                If flxGrid1.Rows <= 1 Then
                    GetandDisplayInfeedData()
                End If

                If flxGrid11.Rows <= 1 Then
                    GetandDisplayASRSAvailableInventorySummary()
                End If

            Case "TabPage2"

                If flxGrid2.Rows <= 1 Then
                    GetAndDisplayASRSInfeedData()
                End If

                If flxGrid3.Rows <= 1 Then
                    GetAndDisplayNeedingMsg7()
                End If

                If flxGrid11.Rows <= 1 Then
                    GetandDisplayASRSAvailableInventorySummary()
                End If

            Case "TabPage3"

                If flxGrid6.Rows <= 1 Then
                    GetAndDisplayMsg13Data()
                    GetAndDisplayMsg14Data()
                End If

            Case "TabPage4"

                If flxGrid4.Rows <= 1 Then
                    GetandDisplayMsg21HeaderData()
                    HighlightGridRow(flxGrid4, 1, 0)
                End If

            Case "TabPage5"

                If flxGrid5.Rows <= 1 Then
                    GetAndDisplayMsg16Data()
                End If

            Case "TabPage6"

                'no grid   

            Case "TabPage7"

                'no grid

            Case "TabPage8"

                If flxGrid9.Rows <= 1 Then
                    GetAndDisplayMsg24Data()
                    HighlightGridRow(flxGrid9, 1, 0)
                    SelectSlotForUnitLoadRemoval(flxGrid9, 1)     'select first row
                End If

            Case "TabPage9"

                If flxGrid12.Rows <= 1 Then

                    If txtReconcileItmCod.Text.Length > 0 Then
                        ReconcileInventory(txtReconcileItmCod.Text)
                    End If

                End If

            Case "TabPage11"

                If flxGrid13.Rows <= 1 Then
                    GetAndDisplayTrailerFPDSData()

                End If
                If flxGrid14.Rows <= 1 Then
                    GetAndDisplayTrailerAllInputConveyorData()
                End If
            Case "tabPgTrlMovEmu"
                'If (dGridTraMovData.RowCount = 0) Then
                'dGridTraMovData.RowCount = 0
                GetAndDisplayTrailerMoveData()
                'GetAndDisplayTCSTrailerViewData()


                'End If


        End Select

    End Sub



    Private Sub butRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRefresh.Click
        RefreshLog()
    End Sub

    Private Sub tmrBlink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBlink.Tick
        Static iCount As Integer

        iCount += 1
        If iCount > 6 Then

            tmrBlink.Enabled = False
            ToolStripStatusLabelRefresh.Visible = False
            ToolStripStatusLabelRefresh.BackColor = Color.FromKnownColor(KnownColor.Control)
            iCount = 0
        Else
            ToolStripStatusLabelRefresh.Visible = True
            Select Case iCount
                Case 1, 3, 5
                    ToolStripStatusLabelRefresh.BackColor = Color.Green
                Case Else
                    ToolStripStatusLabelRefresh.BackColor = Color.FromKnownColor(KnownColor.Control)

            End Select

        End If

    End Sub

    Private Sub SocketCommunicationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SocketCommunicationToolStripMenuItem.Click

        ShowIniForm("SocketCommunication")

    End Sub

    Public Function DisplayNextUnitLoadID() As String
        Dim strULIDSuffix As String
        Dim strULIDNoCheckDigit As String
        Dim strCheckDigit As String
        Dim pad As Char

        Try
            strULIDSuffix = Convert.ToString(giLastULIDUsed + 1)

            pad = "0"c
            strULIDSuffix = strULIDSuffix.PadLeft(9, pad)

            strULIDNoCheckDigit = gstrULIDPrefix & strULIDSuffix


            strCheckDigit = Convert.ToString(Mod10CheckDigit(strULIDNoCheckDigit))
            DisplayNextUnitLoadID = strULIDNoCheckDigit & strCheckDigit
        Catch
            DisplayNextUnitLoadID = String.Empty
        End Try

    End Function

    Private Sub flxGrid1_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent)
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub


    Private Sub TabPage3_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Enter
        TabPageSelected(CType(sender, TabPage))
    End Sub

    Private Sub XMLEditorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XMLEditorToolStripMenuItem.Click
        Dim formXMLEditor As New frmXMLEditor
        formXMLEditor.Show()
    End Sub

    Private Sub PositionFormatStartup()
        Dim iOffset As Integer
        Dim workingRectangle As System.Drawing.Rectangle = Screen.PrimaryScreen.WorkingArea

        ' Set the size of the form slightly less than size of rectangle.  the working area does not include the task bar
        Me.Size = New System.Drawing.Size(workingRectangle.Width - iOffset, workingRectangle.Height - iOffset)

        ' Set the location so the entire form is visible.
        Me.Location = New System.Drawing.Point(iOffset, iOffset)

    End Sub


    Private Sub flxGrid4_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid4.MouseDownEvent

        Dim iRowSel As Integer
        Dim iColSel As Integer


        iRowSel = flxGrid4.MouseRow
        iColSel = flxGrid4.MouseCol

        'first row is header row
        If iRowSel = 0 Then Exit Sub

        If iColSel = 2 Then
            HighlightGridRow(flxGrid4, iRowSel, iColSel)
            SelectLineItemDetails(flxGrid4, iRowSel)

        Else
            If iColSel = 0 Then
                HighlightGridRow(flxGrid4, iRowSel, iColSel)
                SelectLineItemDetails(flxGrid4, iRowSel)
            End If
            ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
        End If


    End Sub

    Private Sub SelectLineItemDetails(ByVal oGrid As AxMSFlexGrid, ByVal iRowSel As Integer)

        Dim strShipId As String
        Dim strRetro_status As String
        Try

            If oGrid.Rows <= 1 Then
                strShipId = "-1"
                strRetro_status = "-1"
                lblRaid_SelectedLoadStatus.Text = String.Empty
                txtlblRaid_Msg23_SelectedSlot.Text = String.Empty
                lblRaid_SelectedShipidDisplay.Text = String.Empty
                lblRaid_Msg23_SelectedDisposition.Text = String.Empty
            Else
                strShipId = Trim(oGrid.get_TextMatrix(iRowSel, 2))
                lblRaid_SelectedShipidDisplay.Text = strShipId
                strRetro_status = Trim(oGrid.get_TextMatrix(iRowSel, 5))
                lblRaid_SelectedLoadStatus.Text = Trim(oGrid.get_TextMatrix(iRowSel, 6))
                txtlblRaid_Msg23_SelectedSlot.Text = Trim(oGrid.get_TextMatrix(iRowSel, 4))
                lblRaid_Msg23_SelectedDisposition.Text = Trim(oGrid.get_TextMatrix(iRowSel, 3))
            End If

            'dont allow the user to stage ULS until the Msg22 has been sent
            If IsNumeric(strRetro_status) = False Then

                'dave - could use some work here for destaging to make it cleaner and not have enabled but oh well
                If strRetro_status = "D22" OrElse strRetro_status = "A22" OrElse strRetro_status = "D42" OrElse strRetro_status = "A42" Then
                    butMsg21_Detail_Advance.Enabled = True
                Else
                    butMsg21_Detail_Advance.Enabled = False
                End If
            Else

                If CInt(strRetro_status) < 22 Then
                    butMsg21_Detail_Advance.Enabled = False
                Else
                    butMsg21_Detail_Advance.Enabled = True
                End If
            End If
            GetandDisplayMsg21DetailData(strShipId)

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Sub

    Private Sub SearchLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchLogToolStripMenuItem.Click
        Dim UserSearchText As String = String.Empty

        UserSearchText = InputBox("Search Text:", "Specify Case Sensitive Search Text", String.Empty)

        If UserSearchText.Length > 0 Then
            SearchLog(UserSearchText, Color.Green)
        End If

    End Sub



    Private Sub SendHeartbeatAutomaticallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendHeartbeatAutomaticallyToolStripMenuItem.Click
        If SendHeartbeatAutomaticallyToolStripMenuItem.Checked = True Then
            SendHeartbeatAutomatically = True
            ToolStripStatusLabelHeartBeatOn.Visible = True
            SendHeartbeat()

        Else
            SendHeartbeatAutomatically = False
            ToolStripStatusLabelHeartBeatOn.Visible = False

        End If
    End Sub

    Private Sub tmrHeartbeat_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHeartbeat.Tick
        tmrHeartbeat.Interval = giAutoHeartBeatSendIntervalMilliSeconds

        If SendHeartbeatAutomatically = True Then
            SendHeartbeat()
        End If
    End Sub


    Private Sub SocketListeningPortsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SocketListeningPortsToolStripMenuItem.Click

        ShowIniForm("SocketListeningPorts")

    End Sub

    Private Sub cmdRefreshInfeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshInfeed.Click
        GetandDisplayInfeedData()
    End Sub

    Private Sub GetandDisplayInfeedData()
        FillUlsWithMsg5Retro_Status()
        FillUlsOnFPDS()
        MatchUlsOnFpdsWithMsg5OnlyInActivDB()
        DisplayULsOnFPDS()
    End Sub
    Private Sub MatchUlsOnFpdsWithMsg5OnlyInActivDB()
        Dim x As Integer
        Dim y As Integer

        For x = 1 To ULsOnFPDSRecordCount
            ULsOnFPDS(x).Message5Only = False
            For y = 1 To ULsWithMsg5RecordCount
                If Strings.Left(ULsOnFPDS(x).ULID, 19) = Strings.Left(ULsWithMsg5(y).CUST_ID, 19) Then
                    ULsOnFPDS(x).Message5Only = True
                End If
            Next
        Next


    End Sub

    Private Sub FillUlsOnFPDS()
        Dim strSQL As String

        Try



            strSQL = "select u.ULID, u.LOCATN, NVL(u.UL_STACOD,0) UL_STACOD, u.CTRL_DATE,U.BASE_ULID " &
                "from UNITLD U, UNTDTL D " &
                "where d.ulid=u.ulid " &
                 "and u.locatn in (" & gstrFPDSLocationsSQL & ") " &
                "and u.subsit='" & gstrFPDSSubsitCharacter & "' "

            If txtInfeedRestrictToUlPall.TextLength > 0 Then
                strSQL &= "and u.ulpall='" & txtInfeedRestrictToUlPall.Text & "' "
            End If

            If txtInfeedRestrictToCtlgrp.TextLength > 0 Then
                strSQL &= "and d.ctlgrp='" & txtInfeedRestrictToCtlgrp.Text & "' "
            End If

            If txtInfeedRestrictToItem.TextLength > 0 Then
                strSQL &= "and d.itmcod='" & txtInfeedRestrictToItem.Text & "' "
            End If

            If gbShowOnlyTheBaseStackedULID = True Then
                strSQL &= "and (U.BASE_ULID is null or U.BASE_ULID=U.ULID) "
            End If

            strSQL &= "and rownum <=" & giMaxNumUlRecordsRTCISInfeedToQuery & " " &
                "order by u.CTRL_DATE desc"

            ' Open the Recordset using the select string:
            dbrec2.Open(strSQL, DBCON2)

            ULsOnFPDSRecordCount = 0
            ReDim ULsOnFPDS(0)

            Do Until dbrec2.EOF

                ULsOnFPDSRecordCount += 1
                ReDim Preserve ULsOnFPDS(ULsOnFPDSRecordCount)

                With ULsOnFPDS(ULsOnFPDSRecordCount)

                    .ULID = Convert.ToString(dbrec2.Fields("ULID").Value)
                    .LOCATN = Convert.ToString(dbrec2.Fields("LOCATN").Value)
                    .UL_STACOD = Convert.ToString(dbrec2.Fields("UL_STACOD").Value)
                    .CTRL_DATE = Convert.ToString(dbrec2.Fields("CTRL_DATE").Value)
                    .BASE_ULID = Convert.ToString(dbrec2.Fields("BASE_ULID").Value)

                End With

                dbrec2.MoveNext()

            Loop

            dbrec2.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub



    Private Sub InfeedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfeedToolStripMenuItem.Click
        ShowIniForm("Infeed")
    End Sub

    Private Sub DisplayULsOnFPDS()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid1.Rows = 1
            flxGrid1.Rows = 2
            flxGrid1.Cols = 8
            flxGrid1.Row = 0
            For y = 1 To flxGrid1.Cols
                flxGrid1.Col = y - 1
                flxGrid1.Text = vbNullString

                Select Case flxGrid1.Col

                    Case 0
                        flxGrid1.set_ColWidth(flxGrid1.Col, 500)

                    Case 1, 2
                        flxGrid1.set_ColWidth(flxGrid1.Col, 2000)

                    Case Else
                        flxGrid1.set_ColWidth(flxGrid1.Col, 1000)

                End Select

            Next

            flxGrid1.Redraw = False


            flxGrid1.Rows = 2
            flxGrid1.Row = 0

            flxGrid1.Col = 0
            flxGrid1.Text = "Sel"
            flxGrid1.Col = 1
            flxGrid1.Text = "Ctrl_Date"
            flxGrid1.Col = 2
            flxGrid1.Text = "Ulid"
            flxGrid1.Col = 3
            flxGrid1.Text = "Loc"
            flxGrid1.Col = 4
            flxGrid1.Text = "UL_Stacod"
            flxGrid1.Col = 5
            flxGrid1.Text = "Bypcod"
            flxGrid1.Col = 6
            flxGrid1.Text = "BaseUL"
            flxGrid1.Col = 7
            flxGrid1.Text = "ASRSKnow"

            For x = 1 To ULsOnFPDSRecordCount

                flxGrid1.Row += 1

                flxGrid1.Col = 1
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore
                flxGrid1.Text = vbNullString & ULsOnFPDS(x).CTRL_DATE

                flxGrid1.Col = 2
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore
                flxGrid1.Text = vbNullString & ULsOnFPDS(x).ULID

                flxGrid1.Col = 3
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore
                flxGrid1.Text = vbNullString & ULsOnFPDS(x).LOCATN

                flxGrid1.Col = 4
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore
                flxGrid1.Text = vbNullString & ULsOnFPDS(x).UL_STACOD

                flxGrid1.Col = 5
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore
                flxGrid1.Text = vbNullString & gcStrZero        'Always defauly bypass code to 0

                flxGrid1.Col = 6
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore
                flxGrid1.Text = vbNullString & ULsOnFPDS(x).BASE_ULID


                flxGrid1.Col = 7
                flxGrid1.CellBackColor = colorBack
                flxGrid1.CellForeColor = colorFore

                If ULsOnFPDS(x).Message5Only = True Then
                    flxGrid1.Text = vbNullString & gcstrY        '
                Else
                    flxGrid1.Text = vbNullString & gcstrN
                End If

                flxGrid1.Rows += 1

            Next


            'remove last blank row
            flxGrid1.Rows -= 1
            flxGrid1.Col = 0

            DisplayGridRowCount(cmdInfeedSelectAll, flxGrid1)
            ' flxGrid1.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        Finally

            flxGrid1.Redraw = True

        End Try
    End Sub

    Private Sub cmdInfeedSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInfeedSelectAll.Click
        ProcessGridSelectAll(flxGrid1)
    End Sub

    Private Sub cmdInfeedDeSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInfeedDeSelectAll.Click
        ProcessGridDeSelectAll(flxGrid1)
    End Sub

    Private Sub InfeedAdvance(ByVal bUserPrompt As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim strULID As String
        Dim iAdvances As Integer = 0
        Dim strUserMessage As String

        Try

            If bUserPrompt = True Then

                If gbUseAlternateMsg567Induction = True Then
                    strUserMessage = "Use Cobbled Together Alternate Msg567 Induction Approach ?"

                Else
                    strUserMessage = "Send Msg5 for Selected ULID(s) ?"
                End If
                shMsgbox = MsgBox(strUserMessage, MsgBoxStyle.YesNo, "Confirm Infeed Processing")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub

                End If
            Else
                GetandDisplayInfeedData()
                ProcessGridSelectAll(flxGrid1)
            End If

            For x = 1 To flxGrid1.Rows - 1

                If flxGrid1.get_TextMatrix(x, 0) = gcstrY Then
                    strULID = flxGrid1.get_TextMatrix(x, 2)

                    'dont want to keep sending Msg5s for the same UL
                    If flxGrid1.get_TextMatrix(x, 7) <> "Y" Then
                        iAdvances += 1


                        'do the advance but limit the number of messages that can be sent 
                        If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then
                            'convert ULID 19 to ULID if necessary

                            If strULID.Length = 19 Then

                                strULID &= Convert.ToString(Mod10CheckDigit(strULID))
                            End If


                            If gbUseAlternateMsg567Induction = True Then     'DAVE DAVE DAVE changed the 7 status to 5
                                FillCustPalletDataFromWMS(strULID)
                                With UlInfoFromWMS(1)

                                    If .BASE_ULID.Length = 19 Then
                                        .BASE_ULID &= Convert.ToString(Mod10CheckDigit(.BASE_ULID))
                                    End If

                                    InsertULInto_CUST_PALLET(strULID, "5", .BRAND_CODE, .BRAND_DESC, .CODE_DATE, .PALLET_TYPE, .HOLD_STATUS, gstrASRSSystemLocationName, .BASE_ULID)
                                    'add 00 prefix to delivery code to ensure any existign number is cleared out
                                    SendKeystoPutty(strULID & "~" &
                                                    "000" & gstrDtldrvsndMsg5UlWeight & "~" &
                                                    "00" & gstrDtldrvsndMsg5DeliveryCode & "~" &
                                                    gstrDtldrvsndMsg5UnitLoadStatus & "~" &
                                                    gstrDtldrvsndMsg5StationId & "~" &
                                                    gstrDtldrvsndMsg5PortId & "~" &
                                                    "~~")

                                    WriteLog(gcstrINFO, "DTLDRVSND Msg5 - ULID:" & strULID & ", Dlvcod: " & gstrDtldrvsndMsg5DeliveryCode)

                                    'if the 

                                End With
                            Else
                                If SendRequest(CreateXML_Msg5(strULID, flxGrid1.get_TextMatrix(x, 4), flxGrid1.get_TextMatrix(x, 5))) = True Then
                                    InsertULInto_CUST_PALLET(strULID, "5", String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
                                    Threading.Thread.Sleep(giInfeedMilliSecTimeDelayBetweenMsgs)
                                Else
                                    WriteLog(gcstrError, "Msg5 Failed for ULID " & strULID & " Database Update Skipped")
                                End If
                            End If
                        Else
                            Exit For
                        End If

                    Else
                        If bUserPrompt = True Then
                            WriteLog(gcstrINFO, "ULID" & Space(1) & strULID & Space(1) & "Already in ASRS Database. Not Advanced. Override ASRSKnow to N to Resend")
                        End If
                    End If

                End If
            Next

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

            If bUserPrompt = True Then
                GetandDisplayInfeedData()
            End If

        End Try
    End Sub

    Private Sub cmdInfeedAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInfeedAdvance.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid1) = False Then Exit Sub
        InfeedAdvance(True)
    End Sub
    Public Function IsAtLeastOneGridRowSelectionSetYes(ByVal oGrid As AxMSFlexGrid) As Boolean
        Dim x As Integer

        IsAtLeastOneGridRowSelectionSetYes = False
        For x = 1 To oGrid.Rows - 1
            If oGrid.get_TextMatrix(x, 0) = gcstrY Then
                IsAtLeastOneGridRowSelectionSetYes = True
                Exit For
            End If
        Next

        If IsAtLeastOneGridRowSelectionSetYes = False Then
            MessageBox.Show("Please Select at Least 1 Row in the Grid", "No Rows Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Function


    Private Sub FillUlsASRSInfeed()
        Dim strSQL As String
        Try

            strSQL = "select CUST_ID, ACTIV_INPUT_LOCATION,RETRO_STATUS,RETRO_LOC,CTRL_DATE,PLC_USERID " &
                "from CUST_PALLET " &
                "where " &
                 "retro_status in ('5','A8','S8','C8','U8','L8','M8') " &
                "order by CTRL_DATE asc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            UlsASRSInfeedRecordCount = 0
            ReDim UlsASRSInfeed(0)

            Do Until dbrec1.EOF


                UlsASRSInfeedRecordCount += 1
                ReDim Preserve UlsASRSInfeed(UlsASRSInfeedRecordCount)

                With UlsASRSInfeed(UlsASRSInfeedRecordCount)

                    .CUST_ID = Convert.ToString(dbrec1.Fields("CUST_ID").Value)
                    .CTRL_DATE = Convert.ToString(dbrec1.Fields("CTRL_DATE").Value)
                    .ACTIV_INPUT_LOCATION = Convert.ToString(dbrec1.Fields("ACTIV_INPUT_LOCATION").Value)
                    .RETRO_STATUS = Convert.ToString(dbrec1.Fields("RETRO_STATUS").Value)
                    .RETRO_LOC = Convert.ToString(dbrec1.Fields("RETRO_LOC").Value)
                    .PLC_USERID = Convert.ToString(dbrec1.Fields("PLC_USERID").Value)

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub FillUlsNeedingMsg7()
        Dim strSQL As String


        Try
            strSQL = "select CUST_ID, ACTIV_INPUT_LOCATION,RETRO_STATUS,RETRO_LOC,CTRL_DATE, BASE_ULID " &
             "from CUST_PALLET " &
             "where " &
             "retro_status in ('6') "

            If gbShowOnlyTheBaseStackedULID = True Then
                strSQL &= "and (len(BASE_ULID)=0 or BASE_ULID=CUST_ID) "
            End If

            strSQL &= "order by CTRL_DATE asc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            ULsNeedingMsg7RecordCount = 0
            ReDim ULsNeedingMsg7(0)

            Do Until dbrec1.EOF

                ULsNeedingMsg7RecordCount += 1
                ReDim Preserve ULsNeedingMsg7(ULsNeedingMsg7RecordCount)

                With ULsNeedingMsg7(ULsNeedingMsg7RecordCount)

                    .CUST_ID = Convert.ToString(dbrec1.Fields("CUST_ID").Value)
                    .CTRL_DATE = Convert.ToString(dbrec1.Fields("CTRL_DATE").Value)
                    .ACTIV_INPUT_LOCATION = Convert.ToString(dbrec1.Fields("ACTIV_INPUT_LOCATION").Value)
                    .Retro_Status = Convert.ToString(dbrec1.Fields("RETRO_STATUS").Value)
                    .Retro_Loc = Convert.ToString(dbrec1.Fields("RETRO_LOC").Value)
                    .BASE_ULID = Convert.ToString(dbrec1.Fields("BASE_ULID").Value)

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub
    Private Sub FillStagedUlsInWMS()
        Dim strSQL As String
        Try

            strSQL = "select l.activ_loc, u.ulid " &
                    "from unitld u,locatn l, untdtl d, ctlgrp c " &
                    "Where u.subsit(+)=l.subsit and u.locatn(+)=l.locatn " &
                    "and u.ulid=d.ulid(+)  " &
                    "and d.itmcod=c.itmcod(+) and d.itmcls=c.itmcls(+) and d.ctlgrp=c.ctlgrp(+)  " &
                    "and l.activ_loc is not null   " &
                    "order by lpad(l.activ_loc,10)"

            strSQL = "select nvl(l.activ_loc,l.locatn) ACTIV_LOC, u.ulid " &
                    "from unitld u,locatn l " &
                    "Where u.subsit(+)=l.subsit and u.locatn(+)=l.locatn " &
                    "and (l.activ_loc is not null or l.locatn like '" & gstrManualOutputVTLPrefix & "%')  " &
                    "order by lpad(nvl(l.activ_loc,l.locatn),10)"

            ' Open the Recordset using the select string:
            dbrec2.Open(strSQL, DBCON2)

            StagedUlsInWMSRecordCount = 0
            ReDim StagedUlsInWMS(0)

            Do Until dbrec2.EOF

                StagedUlsInWMSRecordCount += 1
                ReDim Preserve StagedUlsInWMS(StagedUlsInWMSRecordCount)

                With StagedUlsInWMS(StagedUlsInWMSRecordCount)

                    .SLOT = Convert.ToString(dbrec2.Fields("ACTIV_LOC").Value)
                    .ULID = Convert.ToString(dbrec2.Fields("ULID").Value)


                End With

                dbrec2.MoveNext()

            Loop

            'Close Recordset:
            dbrec2.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub
    Private Sub FillUlsWithMsg5Retro_Status()
        'this gets just the ULID where a MSg5 has been sent but otherwise the UL has not been udpated
        Dim strSQL As String
        Try

            strSQL = "select CUST_ID " &
                "from CUST_PALLET " &
                "where " &
                 "retro_status is not null " &
                "order by CTRL_DATE asc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            ULsWithMsg5RecordCount = 0
            ReDim ULsWithMsg5(0)

            Do Until dbrec1.EOF

                ULsWithMsg5RecordCount += 1
                ReDim Preserve ULsWithMsg5(ULsWithMsg5RecordCount)

                With ULsWithMsg5(ULsWithMsg5RecordCount)

                    .CUST_ID = Convert.ToString(dbrec1.Fields("CUST_ID").Value)

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub DisplayULsASRSInfeed()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid2.Rows = 1
            flxGrid2.Rows = 2
            flxGrid2.Cols = 7
            flxGrid2.Row = 0
            For y = 1 To flxGrid2.Cols
                flxGrid2.Col = y - 1
                flxGrid2.Text = vbNullString

                Select Case flxGrid2.Col

                    Case 0, 6
                        flxGrid2.set_ColWidth(flxGrid2.Col, 500)

                    Case 1, 2
                        flxGrid2.set_ColWidth(flxGrid2.Col, 1900)

                    Case Else
                        flxGrid2.set_ColWidth(flxGrid2.Col, 800)

                End Select

            Next

            flxGrid2.Redraw = False


            flxGrid2.Rows = 2
            flxGrid2.Row = 0

            flxGrid2.Col = 0
            flxGrid2.Text = "Sel"
            flxGrid2.Col = 1
            flxGrid2.Text = "Ctrl_Date"
            flxGrid2.Col = 2
            flxGrid2.Text = "CustID"
            flxGrid2.Col = 3
            flxGrid2.Text = "Input"
            flxGrid2.Col = 4
            flxGrid2.Text = "Status"
            flxGrid2.Col = 5
            flxGrid2.Text = "Loc"
            flxGrid2.Col = 6
            flxGrid2.Text = "PLC"

            For x = 1 To UlsASRSInfeedRecordCount

                flxGrid2.Row += 1

                flxGrid2.Col = 1
                flxGrid2.CellBackColor = colorBack
                flxGrid2.CellForeColor = colorFore
                flxGrid2.Text = vbNullString & UlsASRSInfeed(x).CTRL_DATE

                flxGrid2.Col = 2
                flxGrid2.CellBackColor = colorBack
                flxGrid2.CellForeColor = colorFore
                flxGrid2.Text = vbNullString & UlsASRSInfeed(x).CUST_ID

                flxGrid2.Col = 3
                flxGrid2.CellBackColor = colorBack
                flxGrid2.CellForeColor = colorFore

                'determine the infeed location based upon the message type
                flxGrid2.Text = vbNullString & FindActivInputLocation(UlsASRSInfeed(x).RETRO_STATUS)
                If UlsASRSInfeed(x).ACTIV_INPUT_LOCATION.Length = 0 OrElse UlsASRSInfeed(x).ACTIV_INPUT_LOCATION = "-1" Then
                    flxGrid2.Text = vbNullString & FindActivInputLocation(UlsASRSInfeed(x).RETRO_STATUS)
                Else
                    flxGrid2.Text = vbNullString & UlsASRSInfeed(x).ACTIV_INPUT_LOCATION
                End If

                flxGrid2.Col = 4
                flxGrid2.CellBackColor = colorBack
                flxGrid2.CellForeColor = colorFore
                flxGrid2.Text = vbNullString & UlsASRSInfeed(x).RETRO_STATUS

                flxGrid2.Col = 5
                flxGrid2.CellBackColor = colorBack
                flxGrid2.CellForeColor = colorFore
                flxGrid2.Text = vbNullString & UlsASRSInfeed(x).RETRO_LOC

                flxGrid2.Col = 6
                flxGrid2.CellBackColor = colorBack
                flxGrid2.CellForeColor = colorFore
                If UlsASRSInfeed(x).PLC_USERID.Length = 0 Then
                    flxGrid2.Text = "-1-1"
                Else
                    flxGrid2.Text = vbNullString & UlsASRSInfeed(x).PLC_USERID
                End If



                flxGrid2.Rows += 1

            Next

            'remove last blank row
            flxGrid2.Rows -= 1
            flxGrid2.Col = 0

            DisplayGridRowCount(cmdASRSInfeedSelectAll, flxGrid2)

            ' flxGrid2.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

            flxGrid2.Redraw = True

        End Try
    End Sub

    Private Sub DisplayGridRowCount(ByVal oButton As Button, ByVal oGrid As AxMSFlexGridLib.AxMSFlexGrid)
        oButton.Text = "Select All " & (oGrid.Rows - 1).ToString
    End Sub
    Private Function FindActivInputLocation(ByVal strMsgtyp As String) As String
        'round robin assign input locations
        Static iA8Index As Integer
        Static iC8Index As Integer
        Static iU8Index As Integer
        Static iL8Index As Integer
        Try
            'kinda brute force approach
            Select Case strMsgtyp
                Case "A8"

                    FindActivInputLocation = InfeedLocationsA8(iA8Index)

                    If iA8Index >= InfeedLocationsA8.GetUpperBound(0) Then
                        iA8Index = 0
                    Else
                        iA8Index += 1
                    End If

                Case "U8"

                    FindActivInputLocation = InfeedLocationsU8(iU8Index)

                    If iU8Index >= InfeedLocationsU8.GetUpperBound(0) Then
                        iU8Index = 0
                    Else
                        iU8Index += 1
                    End If

                Case "L8"

                    FindActivInputLocation = InfeedLocationsL8(iL8Index)

                    If iL8Index >= InfeedLocationsL8.GetUpperBound(0) Then
                        iL8Index = 0
                    Else
                        iL8Index += 1
                    End If

                Case "C8"

                    FindActivInputLocation = InfeedLocationsC8(iC8Index)

                    If iC8Index >= InfeedLocationsC8.GetUpperBound(0) Then
                        iC8Index = 0
                    Else
                        iC8Index += 1
                    End If

                Case Else
                    FindActivInputLocation = "-1"

            End Select

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            FindActivInputLocation = "-1"

        End Try
    End Function
    Private Sub GetandDisplayStagedUlsInWMS()

        FillStagedUlsInWMS()
        DisplayStagedUlsInWMS()
    End Sub
    Private Sub DisplayStagedUlsInWMS()
        Dim x As Integer


        Dim iMaxcols As Integer

        Try
            flxGrid15.Rows = 1
            flxGrid15.Rows = 2
            flxGrid15.Cols = 2

            flxGrid15.Row = 0


            flxGrid15.Redraw = False


            flxGrid15.Rows = 2
            flxGrid15.Row = 0

            flxGrid15.Col = 0
            flxGrid15.Text = "SLOT"
            flxGrid15.Col = 1
            flxGrid15.Text = ""


            For x = 1 To StagedUlsInWMSRecordCount
                iMaxcols = flxGrid15.Cols


                'if new slot set the row
                If x = 1 Then
                    flxGrid15.Row = 1
                    flxGrid15.Col = 0
                    flxGrid15.CellBackColor = colorBack
                    flxGrid15.CellForeColor = colorFore
                    flxGrid15.Text = vbNullString & StagedUlsInWMS(x).SLOT
                ElseIf x > 1 And StagedUlsInWMS(x).SLOT <> StagedUlsInWMS(x - 1).SLOT Then
                    flxGrid15.Rows += 1
                    flxGrid15.Row += 1
                    flxGrid15.Col = 0

                    flxGrid15.CellBackColor = colorBack
                    flxGrid15.CellForeColor = colorFore
                    flxGrid15.Text = vbNullString & StagedUlsInWMS(x).SLOT
                End If

                If flxGrid15.Col + 1 = flxGrid15.Cols Then
                    flxGrid15.Cols += 1

                End If
                flxGrid15.Col += 1




                flxGrid15.Text = vbNullString & StagedUlsInWMS(x).ULID
                flxGrid15.CellForeColor = colorBack
                If StagedUlsInWMS(x).ULID.Length > 0 Then
                    flxGrid15.CellBackColor = Color.CadetBlue
                Else
                    flxGrid15.CellBackColor = colorBack
                End If

            Next


            'put a count in the top row and size the cols
            For x = 1 To flxGrid15.Cols - 1

                flxGrid15.set_TextMatrix(0, x, x.ToString)

                flxGrid15.set_ColWidth(x, 800)

            Next


            'remove last blank row
            flxGrid15.Rows -= 1
            flxGrid15.Col = 0
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid15.Redraw = True

        End Try
    End Sub


    Private Sub butRefreshASRSInfeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRefreshASRSInfeed.Click
        GetAndDisplayASRSInfeedData()
    End Sub

    Private Sub GetAndDisplayASRSInfeedData()
        FillUlsASRSInfeed()
        DisplayULsASRSInfeed()

    End Sub
    Private Sub GetAndDisplayNeedingMsg7()
        FillUlsNeedingMsg7()
        DisplayULsNeedingMsg7()
    End Sub
    Private Sub DisplayULsNeedingMsg7()
        Dim x As Integer
        Dim y As Integer


        Try
            flxGrid3.Rows = 1
            flxGrid3.Rows = 2
            flxGrid3.Cols = 7
            flxGrid3.Row = 0
            For y = 1 To flxGrid3.Cols
                flxGrid3.Col = y - 1
                flxGrid3.Text = vbNullString

                Select Case flxGrid3.Col

                    Case 0
                        flxGrid3.set_ColWidth(flxGrid3.Col, 500)

                    Case 1, 2
                        flxGrid3.set_ColWidth(flxGrid3.Col, 1900)

                    Case Else
                        flxGrid3.set_ColWidth(flxGrid3.Col, 800)

                End Select

            Next

            flxGrid3.Redraw = False


            flxGrid3.Rows = 2
            flxGrid3.Row = 0

            flxGrid3.Col = 0
            flxGrid3.Text = "Sel"
            flxGrid3.Col = 1
            flxGrid3.Text = "Ctrl_Date"
            flxGrid3.Col = 2
            flxGrid3.Text = "CustID"
            flxGrid3.Col = 3
            flxGrid3.Text = "Input"
            flxGrid3.Col = 4
            flxGrid3.Text = "Status"
            flxGrid3.Col = 5
            flxGrid3.Text = "Loc"
            flxGrid3.Col = 6
            flxGrid3.Text = "BaseUL"

            For x = 1 To ULsNeedingMsg7RecordCount

                flxGrid3.Row += 1

                flxGrid3.Col = 1
                flxGrid3.CellBackColor = colorBack
                flxGrid3.CellForeColor = colorFore
                flxGrid3.Text = vbNullString & ULsNeedingMsg7(x).CTRL_DATE

                flxGrid3.Col = 2
                flxGrid3.CellBackColor = colorBack
                flxGrid3.CellForeColor = colorFore
                flxGrid3.Text = vbNullString & ULsNeedingMsg7(x).CUST_ID

                flxGrid3.Col = 3
                flxGrid3.CellBackColor = colorBack
                flxGrid3.CellForeColor = colorFore
                flxGrid3.Text = vbNullString & ULsNeedingMsg7(x).ACTIV_INPUT_LOCATION

                flxGrid3.Col = 4
                flxGrid3.CellBackColor = colorBack
                flxGrid3.CellForeColor = colorFore
                flxGrid3.Text = vbNullString & ULsNeedingMsg7(x).Retro_Status

                flxGrid3.Col = 5
                flxGrid3.CellBackColor = colorBack
                flxGrid3.CellForeColor = colorFore
                flxGrid3.Text = vbNullString & ULsNeedingMsg7(x).Retro_Loc

                flxGrid3.Col = 6
                flxGrid3.CellBackColor = colorBack
                flxGrid3.CellForeColor = colorFore
                flxGrid3.Text = vbNullString & ULsNeedingMsg7(x).BASE_ULID



                flxGrid3.Rows += 1

            Next


            'remove last blank row
            flxGrid3.Rows -= 1
            flxGrid3.Col = 0

            DisplayGridRowCount(butMsg7SelectAll, flxGrid3)
            ' flxGrid3.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid3.Redraw = True

        End Try
    End Sub
    Private Sub flxGrid2_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid2.MouseDownEvent
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub

    Private Sub ASRSInfeedAdvance(ByVal bUserPrompt As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim strULID As String
        Dim iAdvances As Integer = 0
        Dim strActiv_Input_Location As String
        Dim strPLC_Userid As String

        Try

            If bUserPrompt = True Then

                shMsgbox = MsgBox("Send AssignInductionLoc for Selected ULID(s) ?", MsgBoxStyle.YesNo, "Confirm ASRS Infeed Processing")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                GetAndDisplayASRSInfeedData()
                ProcessGridSelectAll(flxGrid2)
            End If

            For x = 1 To flxGrid2.Rows - 1
                strULID = flxGrid2.get_TextMatrix(x, 2)
                strActiv_Input_Location = flxGrid2.get_TextMatrix(x, 3)

                'row must be selected and have a "valif input lcoation
                If flxGrid2.get_TextMatrix(x, 0) = gcstrY And strActiv_Input_Location <> "-1" Then
                    iAdvances += 1

                    If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then
                        'convert ULID 19 to ULID if necessary

                        If strULID.Length = 19 Then

                            strULID &= Convert.ToString(Mod10CheckDigit(strULID))
                        End If

                        'do the advance
                        strPLC_Userid = flxGrid2.get_TextMatrix(x, 6)     'echo back to WMS so it can route the Msg6 to the correct PLC

                        If SendRequest(CreateXML_AssignInductionLoc(strULID, strActiv_Input_Location, strPLC_Userid)) = True Then
                            If gbUseAlternateMsg567Induction = False Then
                                Update_CUST_PALLET_RETRO_STATUS_INPUTLOC(strULID, "S8", strActiv_Input_Location)
                            Else
                                'so the 8 is sent and the 6 will go to the DTL driver, so we will assume it makes there
                                Update_CUST_PALLET_RETRO_STATUS_INPUTLOC(strULID, "6", strActiv_Input_Location)
                            End If
                            Threading.Thread.Sleep(giInfeedMilliSecTimeDelayBetweenMsgs)
                        Else
                            WriteLog(gcstrError, "Msg8 Failed for ULID " & strULID & " Database Update Skipped")
                        End If
                    Else
                        Exit For
                    End If

                Else
                    'givethe user feedback
                    If bUserPrompt = True And flxGrid2.get_TextMatrix(x, 0) = gcstrY And strActiv_Input_Location = "-1" Then
                        WriteLog(gcstrINFO, "Input Location must be zero or greater. ULID Not Advanced -  " & strULID & " ")
                    End If
                End If
            Next

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

            If bUserPrompt = True Then
                ' GetAndDisplayASRSInfeedData()
            End If

        End Try
    End Sub
    Public Function Update_CUST_PALLET_RETRO_STATUS_INPUTLOC(ByVal strULID As String, ByVal strRETRO_STATUS As String, ByVal strInputLoc As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_PALLET set " &
            "RETRO_STATUS='" & strRETRO_STATUS & "'," &
            "ACTIV_INPUT_LOCATION='" & strInputLoc & "'," &
            "CTRL_DATE='" & Date.Now.ToString & "' " &
            "where CUST_ID ='" & strULID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_PALLET_RETRO_STATUS_INPUTLOC = True

        Catch
            Update_CUST_PALLET_RETRO_STATUS_INPUTLOC = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function


    Private Sub cmdASRSInfeedAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdASRSInfeedAdvance.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid2) = False Then Exit Sub
        ASRSInfeedAdvance(True)
    End Sub

    Private Sub cmdASRSInfeedSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdASRSInfeedSelectAll.Click
        ProcessGridSelectAll(flxGrid2)
    End Sub

    Private Sub cmdASRSInfeedDeSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdASRSInfeedDeSelectAll.Click
        ProcessGridDeSelectAll(flxGrid2)
    End Sub

    Public Function Update_CUST_PALLET_Single_Field(ByVal strULID As String, ByVal strFieldName As String, ByVal strFieldValue As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_PALLET set " &
            strFieldName & "='" & strFieldValue & "'," &
            "CTRL_DATE='" & Date.Now.ToString & "' " &
            "where CUST_ID ='" & strULID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_PALLET_Single_Field = True

        Catch
            Update_CUST_PALLET_Single_Field = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function
    Public Function Update_CUST_LINEITEM_AfterMsg15(ByVal strULID As String, ByVal strRetro_Status As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_LINEITEM set " &
            "RETRO_STATUS='" & strRetro_Status & "' " &
            "where CUST_ID ='" & strULID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_LINEITEM_AfterMsg15 = True

        Catch
            Update_CUST_LINEITEM_AfterMsg15 = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function

    Public Function Update_CUST_PALLET_AfterMsg15(ByVal strULID As String, ByVal strRetro_Loc As String, ByVal strRetro_Status As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_PALLET set " &
            "RETRO_LOC='" & strRetro_Loc & "'," &
            "RETRO_STATUS='" & strRetro_Status & " '," &
            "CTRL_DATE='" & Date.Now.ToString & "' " &
            "where CUST_ID ='" & strULID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_PALLET_AfterMsg15 = True

        Catch
            Update_CUST_PALLET_AfterMsg15 = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function
    Public Function Update_CUST_PALLET_ReturnToASRSSystemAndUnassign(ByVal strSHIP_ID As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_PALLET set " &
            "RETRO_LOC" & "='" & gstrASRSSystemLocationName & "'," &
            "RETRO_STATUS='7'," &
            "SHIP_ID" & "= null," &
            "CTRL_DATE='" & Date.Now.ToString & "' " &
            "where SHIP_ID ='" & strSHIP_ID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_PALLET_ReturnToASRSSystemAndUnassign = True
            WriteLog("INFO", "Returned to " & gstrASRSSystemLocationName & " All ULs Associated to ShipID " & strSHIP_ID)
        Catch
            Update_CUST_PALLET_ReturnToASRSSystemAndUnassign = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strSHIP_ID & Space(1) & Err.Description)

        End Try

    End Function
    Public Function Update_CUST_PALLET_AfterStaging(ByVal strULID As String, ByVal strShipid As String, ByVal strRetro_loc As String, ByVal strRetro_Status As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_PALLET set " &
            "SHIP_ID='" & strShipid & "'," &
            "RETRO_LOC='" & strRetro_loc & "'," &
             "RETRO_STATUS='" & strRetro_Status & "' " &
            "where CUST_ID ='" & strULID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_PALLET_AfterStaging = True

        Catch
            Update_CUST_PALLET_AfterStaging = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function
    Public Function Update_CUST_SHIPMENT_Single_Field(ByVal strShipId As String, ByVal strFieldName As String, ByVal strFieldValue As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_SHIPMENT set " &
            strFieldName & "='" & strFieldValue & "' " &
            "where CUST_SHIPMENT ='" & strShipId & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_SHIPMENT_Single_Field = True

        Catch
            Update_CUST_SHIPMENT_Single_Field = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strShipId & Space(1) & Err.Description)

        End Try

    End Function

    Private Sub btnInfeedAutoScanOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfeedAutoScanOff.Click
        InfeedAutoScanOff()
    End Sub
    Private Sub InfeedAutoScanOff()

        AutoScanOff(btnInfeedAutoScanOn, btnInfeedAutoScanOff)
        cmdRefreshInfeed.Enabled = True

    End Sub

    Private Sub InfeedAutoScanOn()
        AutoScanOn(btnInfeedAutoScanOn, btnInfeedAutoScanOff)

        Me.Refresh()
    End Sub

    Private Sub btnInfeedAutoScanOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfeedAutoScanOn.Click
        InfeedAutoScanOn()
    End Sub

    Private Sub DeleteCust_PalletToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCust_PalletToolStripMenuItem.Click
        DeleteAllDatafromEmulatorDBTable("CUST_PALLET", True)
        GetAllData()
    End Sub

    Private Sub DeleteAllDatafromEmulatorDBTable(ByVal strTable As String, ByVal bConfirmDeletion As Boolean)
        Dim strSQL As String
        Dim iMsgResult As DialogResult
        Dim oRecordsAffected As Object = 0

        Try
            If bConfirmDeletion = True Then
                iMsgResult = MessageBox.Show("Ok to Delete All " & strTable & " Data?", "Confirm Emulator Data Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If iMsgResult = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            strSQL = "delete from " & strTable

            DBCON1.Execute(strSQL, oRecordsAffected)

            WriteLog("Success", GetCurrentMethod.Name & Space(1) & strTable & Space(1) & "Records:" & Space(1) & oRecordsAffected.ToString)

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()

        Finally

        End Try

    End Sub


    Private Sub RemoveAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAToolStripMenuItem.Click
        Dim iMsgResult As DialogResult

        iMsgResult = MessageBox.Show("Ok to Delete All Emulator Data?", "Confirm Emulator Data Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If iMsgResult = Windows.Forms.DialogResult.No Then Exit Sub

        DeleteAllDatafromEmulatorDBTable("CUST_PALLET", False)
        DeleteAllDatafromEmulatorDBTable("CUST_SHIPMENT", False)
        DeleteAllDatafromEmulatorDBTable("CUST_LINEITEM", False)
        DeleteAllDatafromEmulatorDBTable("MSG16HST", False)
        DeleteAllDatafromEmulatorDBTable("TRAILER_FPDS", False)
        DeleteAllDatafromEmulatorDBTable("TCS_TRAILER_EMU", False)
        GetAllData()

    End Sub

    Private Sub flxGrid3_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent)
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub

    Private Sub butMsg7SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg7SelectAll.Click
        ProcessGridSelectAll(flxGrid3)
    End Sub

    Private Sub butMsg7DeSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg7DeSelectAll.Click
        ProcessGridDeSelectAll(flxGrid3)
    End Sub

    Private Sub butMsg7Advance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg7Advance.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid3) = False Then Exit Sub
        AdvanceViaMsg7(True)
    End Sub

    Private Sub AdvanceViaMsg7(ByVal bUserPrompt As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim strULID As String
        Dim iAdvances As Integer = 0
        Dim strLocation As String
        Dim lRecordsAffected As Long

        Try

            If bUserPrompt = True Then

                shMsgbox = MsgBox("Send Msg7 for Selected ULID(s) ?", MsgBoxStyle.YesNo, "Confirm ASRS Infeed Processing")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                GetAndDisplayNeedingMsg7()
                ProcessGridSelectAll(flxGrid3)
            End If

            For x = 1 To flxGrid3.Rows - 1

                If flxGrid3.get_TextMatrix(x, 0) = gcstrY Then
                    iAdvances += 1
                    If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then
                        'convert ULID 19 to ULID if necessary
                        strULID = flxGrid3.get_TextMatrix(x, 2)
                        If strULID.Length = 19 Then

                            strULID &= Convert.ToString(Mod10CheckDigit(strULID))
                        End If


                        'do the advance
                        If flxGrid3.get_TextMatrix(x, 3).Length <> 0 Then
                            If flxGrid3.get_TextMatrix(x, 3) <> "-1" Then
                                'delivery location specified
                                strLocation = flxGrid3.get_TextMatrix(x, 3)
                            Else
                                'don't have valid del loc
                                strLocation = gstrRejectLocation
                            End If
                        Else
                            strLocation = gstrRejectLocation
                        End If

                        If gbUseAlternateMsg567Induction = False Then
                            If SendRequest(CreateXML_Msg7(strULID, "0", strLocation)) = True Then

                                If strLocation <> gstrRejectLocation Then
                                    'put the UL into ASRS
                                    Update_CUST_PALLET_RETRO_STATUS_LOC(strULID, "7", gstrASRSSystemLocationName)
                                Else
                                    'remove the UL from ASRS since its on a FPDS reject spur and will need to be re-inducted
                                    lRecordsAffected = DeleteULIDfromDB(strULID)
                                    WriteLog(gcstrProcessed, "UL Sent to Reject, Removed from ASRS DB " & strULID & RecordAffectedMessage(lRecordsAffected, gcstrDelete))
                                End If
                            Else
                                WriteLog(gcstrError, "Msg7 Failed for ULID " & strULID & " Database Update Skipped")

                            End If
                        Else
                            'the msg7 gets sent via the PLC, need to mirror what the PLC does
                            'put the UL into ASRS

                            HstInbMsg7(strULID, strLocation)
                            If strLocation <> "9" Then
                                Update_CUST_PALLET_RETRO_STATUS_LOC(strULID, "7", gstrASRSSystemLocationName)
                            Else
                                'going to reject - delete from database
                                'there also shodul be a D8 sent which may double delete this ULID
                                'remove the UL from ASRS since its on a FPDS reject spur and will need to be re-inducted
                                lRecordsAffected = DeleteULIDfromDB(strULID)
                                WriteLog(gcstrProcessed, "UL Sent to Reject, Removed from ASRS DB " & strULID & RecordAffectedMessage(lRecordsAffected, gcstrDelete))

                            End If
                        End If
                    Else
                        Exit For
                    End If

                End If
            Next

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

            If bUserPrompt = True Then
                GetAndDisplayNeedingMsg7()
                GetandDisplayASRSAvailableInventorySummary()
            End If

        End Try
    End Sub

    Private Sub ASRSInfeedAutoScanOn()

        AutoScanOn(btnASRSInfeedAutoScanOn, btnASRSInfeedAutoScanOff)

    End Sub
    Private Sub btnASRSInfeedAutoScanOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASRSInfeedAutoScanOn.Click
        ASRSInfeedAutoScanOn()
    End Sub

    Private Sub btnASRSInfeedAutoScanOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASRSInfeedAutoScanOff.Click
        ASRSInfeedAutoScanOff()
    End Sub
    Private Sub ASRSInfeedAutoScanOff()
        AutoScanOff(btnASRSInfeedAutoScanOn, btnASRSInfeedAutoScanOff)

    End Sub



    Private Sub butRefreshNeedingMsg7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRefreshNeedingMsg7.Click
        GetAndDisplayNeedingMsg7()
    End Sub

    Private Sub GetAllData()
        GetandDisplayInfeedData()
        GetAndDisplayASRSInfeedData()
        GetAndDisplayNeedingMsg7()
        GetandDisplayASRSAvailableInventorySummary()
        GetandDisplayMsg21HeaderData()
        GetAndDisplayMsg24Data()
        GetandDisplayStagedUlsInWMS()
    End Sub

    Private Sub AllProcessesInAutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllProcessesInAutoToolStripMenuItem.Click
        If AllProcessesInAutoToolStripMenuItem.Checked Then
            ASRSInfeedAutoScanOn()
            InfeedAutoScanOn()
            Msg13AutoScanOn()
            Msg21AutoSendOn()
            Msg22AutoSendOn()
            Msg24AutoSendOn()
            TrailerFPDSAutoScanOn()
        Else
            ASRSInfeedAutoScanOff()
            InfeedAutoScanOff()
            Msg13AutoScanOff()
            Msg21AutoSendOff()
            Msg22AutoSendOff()
            Msg24AutoSendOff()
            TrailerFPDSAutoScanOff()
        End If
    End Sub

    Private Sub butMsg13SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg13SelectAll.Click
        ProcessGridSelectAll(flxGrid6)
    End Sub

    Private Sub butMsg13DeSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg13DeSelectAll.Click
        ProcessGridDeSelectAll(flxGrid6)
    End Sub

    Private Sub butMsg13RefreshData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg13RefreshData.Click
        GetAndDisplayMsg13Data()
    End Sub

    Private Sub GetAndDisplayMsg13Data()
        FillMsg13_Cust_LineItem_Aggregate()
        DisplayMsg13Cust_LineItem_Aggregate()

    End Sub

    Private Sub FillMsg13_Cust_LineItem_Aggregate()
        Dim strSQL As String
        Try

            strSQL = "select L.SHIP_ID,L.BRAND_CODE,L.CODE_DATE,L.PAL_TYPE, " &
                "sum(L.QUANTITY) AS SUMofQuantity , L.RETRO_STATUS, S.SLOT " &
                "from CUST_LINEITEM L, CUST_SHIPMENT S " &
                "where " &
                "L.SHIP_ID=S.CUST_SHIPMENT " &
                 "and L.retro_status in ('13') " &
                 "group by L.SHIP_ID,L.BRAND_CODE,L.CODE_DATE,L.PAL_TYPE,L.RETRO_STATUS,S.SLOT " &
                "order by L.SHIP_ID  asc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Msg13_Cust_LineItem_Aggregate_RecordCount = 0
            ReDim Msg13_Cust_LineItem_Aggregate(0)

            Do Until dbrec1.EOF


                Msg13_Cust_LineItem_Aggregate_RecordCount += 1
                ReDim Preserve Msg13_Cust_LineItem_Aggregate(Msg13_Cust_LineItem_Aggregate_RecordCount)

                With Msg13_Cust_LineItem_Aggregate(Msg13_Cust_LineItem_Aggregate_RecordCount)
                    .SHIP_ID = Convert.ToString(dbrec1.Fields("SHIP_ID").Value)
                    .BRAND_CODE = Convert.ToString(dbrec1.Fields("BRAND_CODE").Value)
                    .CODE_DATE = Convert.ToString(dbrec1.Fields("CODE_DATE").Value)
                    .PAL_TYPE = Convert.ToString(dbrec1.Fields("PAL_TYPE").Value)
                    .QUANTITY = Convert.ToString(dbrec1.Fields("SUMofQuantity").Value)
                    .RETRO_STATUS = Convert.ToString(dbrec1.Fields("RETRO_STATUS").Value)
                    .Slot = Convert.ToString(dbrec1.Fields("SLOT").Value)
                    '  .WITHDRAWAL_INTENT_CODE = Convert.ToString(dbrec1.Fields("WITHDRAWAL_INTENT_CODE").Value)

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub FillMsg13_Cust_LineItem()


        Dim strSQL As String
        Try
            strSQL = "select L.SHIP_ID,L.LINE_ID,L.BRAND_CODE,L.CODE_DATE,L.PAL_TYPE, S.SLOT, L.SELECT_FLAG, L.RETRO_STATUS, L.CUST_ID " &
                "from CUST_LINEITEM L, CUST_SHIPMENT S " &
                "where " &
                "L.SHIP_ID=S.CUST_SHIPMENT " &
                 "and L.retro_status in ('13S','13C','14','14D')" &
                "order by L.SHIP_ID,L.LINE_ID  asc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Msg13_Cust_LineItem_RecordCount = 0
            ReDim Msg13_Cust_LineItem(0)

            Do Until dbrec1.EOF


                Msg13_Cust_LineItem_RecordCount += 1
                ReDim Preserve Msg13_Cust_LineItem(Msg13_Cust_LineItem_RecordCount)

                With Msg13_Cust_LineItem(Msg13_Cust_LineItem_RecordCount)
                    .SHIP_ID = Convert.ToString(dbrec1.Fields("SHIP_ID").Value)
                    .LINE_ID = Convert.ToString(dbrec1.Fields("LINE_ID").Value)
                    .BRAND_CODE = Convert.ToString(dbrec1.Fields("BRAND_CODE").Value)
                    .CODE_DATE = Convert.ToString(dbrec1.Fields("CODE_DATE").Value)
                    .PAL_TYPE = Convert.ToString(dbrec1.Fields("PAL_TYPE").Value)
                    .Slot = Convert.ToString(dbrec1.Fields("SLOT").Value)
                    .SELECT_FLAG = Convert.ToString(dbrec1.Fields("SELECT_FLAG").Value)
                    .RETRO_STATUS = Convert.ToString(dbrec1.Fields("RETRO_STATUS").Value)
                    .CUST_ID = Convert.ToString(dbrec1.Fields("CUST_ID").Value)

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub DisplayMsg13Cust_LineItem_Aggregate()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid6.Rows = 1
            flxGrid6.Rows = 2
            flxGrid6.Cols = 10
            flxGrid6.Row = 0
            For y = 1 To flxGrid6.Cols
                flxGrid6.Col = y - 1
                flxGrid6.Text = vbNullString

                Select Case flxGrid6.Col

                    Case 0, 5, 6, 9
                        flxGrid6.set_ColWidth(flxGrid6.Col, 500)

                    Case -1
                        flxGrid6.set_ColWidth(flxGrid6.Col, 2000)

                    Case 2
                        flxGrid6.set_ColWidth(flxGrid6.Col, 0)

                    Case 4
                        flxGrid6.set_ColWidth(flxGrid6.Col, 1200)

                    Case Else
                        flxGrid6.set_ColWidth(flxGrid6.Col, 1000)

                End Select

            Next

            flxGrid6.Redraw = False


            flxGrid6.Rows = 2
            flxGrid6.Row = 0

            flxGrid6.Col = 0
            flxGrid6.Text = "Sel"
            flxGrid6.Col = 1
            flxGrid6.Text = "ShipId"
            flxGrid6.Col = 2
            flxGrid6.Text = String.Empty
            flxGrid6.Col = 3
            flxGrid6.Text = "Brand"
            flxGrid6.Col = 4
            flxGrid6.Text = "CodDat"
            flxGrid6.Col = 5
            flxGrid6.Text = "Pal"
            flxGrid6.Col = 6
            flxGrid6.Text = "Qty"
            'these don't come from the query, but are the 2 criteria to return to RTCIS
            flxGrid6.Col = 7
            flxGrid6.Text = "WDTime"
            flxGrid6.Col = 8
            flxGrid6.Text = "Output"
            flxGrid6.Col = 9
            flxGrid6.Text = "Stat"

            For x = 1 To Msg13_Cust_LineItem_Aggregate_RecordCount

                flxGrid6.Row += 1

                flxGrid6.Col = 1
                flxGrid6.CellBackColor = colorBack
                flxGrid6.CellForeColor = colorFore
                flxGrid6.Text = vbNullString & Msg13_Cust_LineItem_Aggregate(x).SHIP_ID

                flxGrid6.Col = 2
                flxGrid6.CellBackColor = colorBack
                flxGrid6.CellForeColor = colorFore
                flxGrid6.Text = vbNullString & Msg13_Cust_LineItem_Aggregate(x).LINE_ID

                flxGrid6.Col = 3
                flxGrid6.CellBackColor = colorBack
                flxGrid6.CellForeColor = colorFore
                flxGrid6.Text = vbNullString & Msg13_Cust_LineItem_Aggregate(x).BRAND_CODE

                flxGrid6.Col = 4
                flxGrid6.CellBackColor = colorBack
                flxGrid6.CellForeColor = colorFore
                flxGrid6.Text = vbNullString & Msg13_Cust_LineItem_Aggregate(x).CODE_DATE

                flxGrid6.Col = 5
                flxGrid6.CellBackColor = colorBack
                flxGrid6.CellForeColor = colorFore
                flxGrid6.Text = vbNullString & Msg13_Cust_LineItem_Aggregate(x).PAL_TYPE

                flxGrid6.Col = 6
                flxGrid6.CellBackColor = colorBack
                flxGrid6.CellForeColor = colorFore
                flxGrid6.Text = vbNullString & Msg13_Cust_LineItem_Aggregate(x).QUANTITY

                flxGrid6.Col = 7
                flxGrid6.CellBackColor = colorBack
                flxGrid6.CellForeColor = colorFore
                flxGrid6.Text = vbNullString & gstrDefaultWithdrawalOutputMins

                flxGrid6.Col = 8
                flxGrid6.CellBackColor = colorBack
                flxGrid6.CellForeColor = colorFore
                flxGrid6.Text = vbNullString & Msg13_Cust_LineItem_Aggregate(x).Slot

                flxGrid6.Col = 9
                flxGrid6.CellBackColor = colorBack
                flxGrid6.CellForeColor = colorFore
                flxGrid6.Text = vbNullString & Msg13_Cust_LineItem_Aggregate(x).RETRO_STATUS

                flxGrid6.Rows += 1

            Next

            'remove last blank row
            flxGrid6.Rows -= 1
            flxGrid6.Col = 0
            DisplayGridRowCount(butMsg13SelectAll, flxGrid6)
            ' flxGrid6.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid6.Redraw = True

        End Try
    End Sub

    Private Sub DisplayMsg16_History()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid5.Rows = 1
            flxGrid5.Rows = 2
            flxGrid5.Cols = 6
            flxGrid5.Row = 0
            For y = 1 To flxGrid5.Cols
                flxGrid5.Col = y - 1
                flxGrid5.Text = vbNullString

                Select Case flxGrid5.Col

                    Case 0
                        flxGrid5.set_ColWidth(flxGrid5.Col, 0)

                    Case 1, 2
                        flxGrid5.set_ColWidth(flxGrid5.Col, 2000)

                    Case -1
                        flxGrid5.set_ColWidth(flxGrid5.Col, 0)

                    Case Else
                        flxGrid5.set_ColWidth(flxGrid5.Col, 1200)

                End Select

            Next

            flxGrid5.Redraw = False

            flxGrid5.Rows = 2
            flxGrid5.Row = 0

            flxGrid5.Col = 0
            flxGrid5.Text = "Sel"
            flxGrid5.Col = 1
            flxGrid5.Text = "Ctrl_Date"
            flxGrid5.Col = 2
            flxGrid5.Text = "CustID"
            flxGrid5.Col = 3
            flxGrid5.Text = "Brand"
            flxGrid5.Col = 4
            flxGrid5.Text = "Coddat"
            flxGrid5.Col = 5
            flxGrid5.Text = "HoldStat"


            For x = 1 To Msg16_History_RecordCount

                flxGrid5.Row += 1

                flxGrid5.Col = 1
                flxGrid5.CellBackColor = colorBack
                flxGrid5.CellForeColor = colorFore
                flxGrid5.Text = vbNullString & Msg16_History(x).CTRL_DATE

                flxGrid5.Col = 2
                flxGrid5.CellBackColor = colorBack
                flxGrid5.CellForeColor = colorFore
                flxGrid5.Text = vbNullString & Msg16_History(x).CUST_ID

                flxGrid5.Col = 3
                flxGrid5.CellBackColor = colorBack
                flxGrid5.CellForeColor = colorFore
                flxGrid5.Text = vbNullString & Msg16_History(x).BRAND_CODE

                flxGrid5.Col = 4
                flxGrid5.CellBackColor = colorBack
                flxGrid5.CellForeColor = colorFore
                flxGrid5.Text = vbNullString & Msg16_History(x).CODE_DATE

                flxGrid5.Col = 5
                flxGrid5.CellBackColor = colorBack
                flxGrid5.CellForeColor = colorFore
                flxGrid5.Text = vbNullString & Msg16_History(x).HOLD_STATUS


                flxGrid5.Rows += 1

            Next


            'remove last blank row
            flxGrid5.Rows -= 1
            flxGrid5.Col = 0

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid5.Redraw = True

        End Try
    End Sub
    Private Sub DeleteCUSTSHIPMENTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCUSTSHIPMENTToolStripMenuItem.Click
        DeleteAllDatafromEmulatorDBTable("CUST_SHIPMENT", True)
    End Sub

    Private Sub DeleteCUSTLINEITEMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCUSTLINEITEMToolStripMenuItem.Click
        DeleteAllDatafromEmulatorDBTable("CUST_LINEITEM", True)
    End Sub

    Private Sub ManualOutputRequestsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualOutputRequestsToolStripMenuItem.Click

        ShowIniForm("ManualOutputRequests")

    End Sub
    Private Sub ShowIniForm(ByVal strIniSection As String)
        Dim formConfig As New frmConfig
        'ensure sync with ini file
        Call Ini_Main()

        gstrPassIniSection = strIniSection
        formConfig.ShowDialog()
    End Sub

    Private Sub butMsg13Advance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg13Advance.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid6) = False Then Exit Sub
        Msg13Advance(True)
    End Sub
    Private Sub Msg13Advance(ByVal bUserPrompt As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim strSHIP_ID As String
        Dim iAdvances As Integer = 0
        Dim strRetro_Status As String = "13S"  '13 SENT
        Dim strUserRequestedSlot As String
        Dim strAvailableSlot As String
        Dim bRefreshLog As Boolean
        Dim strCurrentRetro_Status As String

        Try

            If bUserPrompt = True Then

                shMsgbox = MsgBox("Send AssignWithdrawalLoc for Selected Shipid (s) ?", MsgBoxStyle.YesNo, "Confirm Message Send")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                GetAndDisplayMsg13Data()
                ProcessGridSelectAll(flxGrid6)
            End If

            For x = 1 To flxGrid6.Rows - 1

                If flxGrid6.get_TextMatrix(x, 0) = gcstrY Then
                    iAdvances += 1

                    If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then

                        strSHIP_ID = flxGrid6.get_TextMatrix(x, 1)
                        strUserRequestedSlot = flxGrid6.get_TextMatrix(x, 8)
                        strCurrentRetro_Status = flxGrid6.get_TextMatrix(x, 9)

                        If strCurrentRetro_Status = "13" Then
                            If strUserRequestedSlot.Length <> 0 Then
                                'take whatever is on the grid
                                strAvailableSlot = strUserRequestedSlot

                            Else
                                strAvailableSlot = FindOpenSlotForManualWithdraw(strUserRequestedSlot)
                            End If


                            If strAvailableSlot <> "-1" Then
                                'do the advance
                                'shipid  (M#), withdraw output time, and locatn
                                SendMsg13(strSHIP_ID, flxGrid6.get_TextMatrix(x, 7), strAvailableSlot, strRetro_Status)

                                'put the warning here so that the user sees it in the log after the message
                                If strAvailableSlot.Length > 0 Then
                                    If ManualOutputLocationExists(strAvailableSlot) = False Then
                                        WriteLog(gcstrINFO, "Sent Slot " & strUserRequestedSlot & " Does Not Exist")
                                    End If
                                End If

                            Else
                                SendMsg13(strSHIP_ID, flxGrid6.get_TextMatrix(x, 7), String.Empty, strRetro_Status)
                                WriteLog(gcstrError, "No Slots Available for " & strSHIP_ID)
                                bRefreshLog = True  'set the log refresh flag
                            End If

                        End If
                    Else
                        Exit For
                    End If

                End If
            Next

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally


        End Try
    End Sub


    Public Function Update_CUST_LINEITEM_MSG13(ByVal strSHIP_ID As String, ByVal strRETRO_STATUS As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_LINEITEM set " &
            "RETRO_STATUS='" & strRETRO_STATUS & "'" &
            "where SHIP_ID ='" & strSHIP_ID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_LINEITEM_MSG13 = True

        Catch
            Update_CUST_LINEITEM_MSG13 = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strSHIP_ID & Space(1) & Err.Description)

        End Try

    End Function

    Private Sub SendMsg13(ByVal strSHIP_ID As String, ByVal strOutputMinutes As String, ByVal strSlot As String, ByVal strRETRO_STATUS As String)

        Try

            If SendRequest(CreateXML_AssignWithdrawalLoc(strSHIP_ID, strOutputMinutes, strSlot)) = True Then

                Update_CUST_SHIPMENT(strSHIP_ID, strRETRO_STATUS, strSlot)

                ' dave this seems to be duplicate effort but "ok" for now
                Update_CUST_LINEITEM_MSG13(strSHIP_ID, strRETRO_STATUS)

            Else
                WriteLog(gcstrError, "Msg 13 Failed for ID " & strSHIP_ID & " Slot " & strSlot & " Database Update Skipped")

            End If
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strSHIP_ID & Space(1) & Err.Description)
        End Try
    End Sub

    Private Sub flxGrid6_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid6.MouseDownEvent
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub

    Private Sub butMsg13AutoScanOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg13AutoScanOn.Click
        Msg13AutoScanOn()

    End Sub

    Private Sub butMsg13AutoScanOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg13AutoScanOff.Click
        Msg13AutoScanOff()
    End Sub

    Private Sub Msg13AutoScanOn()
        AutoScanOn(butMsg13AutoScanOn, butMsg13AutoScanOff)

    End Sub

    Private Sub Msg13AutoScanOff()
        AutoScanOff(butMsg13AutoScanOn, butMsg13AutoScanOff)
    End Sub


    Private Function FindOpenSlotForManualWithdraw(ByVal strRequestedSlot As String) As String
        Dim strSql As String
        Dim iSlotsCount As Integer = 0
        Dim iSlots() As String
        Dim x As Integer
        Dim y As Integer
        Dim strFirstAvailableSlot As String = "-1"
        Dim bSlotInUse As Boolean
        Static iRoundRobinSlot As Integer

        'requested slot doesn't have to be populated

        Try

            If gstrManualOutputLocationsSQL.Length = 0 Then
                WriteLog(gcstrError, "No ManualOutputLocations Defined, Please Add Configuration Under ManualOutPutRequests")
                FindOpenSlotForManualWithdraw = "-1"
                Exit Function
            End If

            'find all currently used slots but not those that have been requested by user

            strSql = "select SLOT " &
                "from CUST_SHIPMENT " &
                "where " &
                 "slot in (" & gstrManualOutputLocationsSQL & ") " &
                 "and retro_status not in ('13') " &
                "order by SLOT asc "

            ' Open the Recordset using the select string:
            dbrec1.Open(strSql, DBCON1)

            ReDim iSlots(0)

            Do Until dbrec1.EOF

                iSlotsCount += 1
                ReDim Preserve iSlots(iSlotsCount)

                iSlots(iSlotsCount) = Convert.ToString(dbrec1.Fields("SLOT").Value)

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

            For x = 1 To ManualOutputLocationsRecordCount

                bSlotInUse = False
                For y = 1 To iSlotsCount
                    If iSlots(y) = ManualOutputLocations(x - 1) Then
                        'this slot is already in use
                        bSlotInUse = True
                        Exit For
                    End If
                Next

                If bSlotInUse = False Then

                    'this slot is available as it was not found
                    If ManualOutputLocations(x - 1) = strRequestedSlot Then
                        'done - no need to keep looking
                        strFirstAvailableSlot = strRequestedSlot
                        Exit For
                    Else
                        If strFirstAvailableSlot = "-1" Then
                            'dont want to overwrite if previous slot available
                            strFirstAvailableSlot = ManualOutputLocations(x - 1)
                        End If

                    End If

                End If

            Next

            If strFirstAvailableSlot = "-1" Then
                'just round robin the vtls as at leat for emulation we want to always return a vtl
                If iRoundRobinSlot > ManualOutputLocationsRecordCount - 1 Then
                    iRoundRobinSlot = 0
                End If

                FindOpenSlotForManualWithdraw = ManualOutputLocations(iRoundRobinSlot)
                iRoundRobinSlot += 1
            Else

                FindOpenSlotForManualWithdraw = strFirstAvailableSlot
            End If


        Catch ex As Exception
            FindOpenSlotForManualWithdraw = "-1"
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Function

    Private Function FindOpenSlotForShipment(ByVal strRequestedSlot As String) As String
        Dim strSql As String
        Dim iSlotsCount As Integer = 0
        Dim iSlots() As String
        Dim x As Integer
        Dim y As Integer
        Dim strFirstAvailableSlot As String = "-1"
        Dim bSlotInUse As Boolean

        'requested slot doesn't have to be populated

        Try

            'find all currently used slot

            strSql = "select SLOT " &
                "from CUST_SHIPMENT " &
                "where " &
                 "slot in (" & gstrSlotsSQL & ") " &
                 "and retro_status not in ('21') " &
                "order by SLOT asc "

            ' Open the Recordset using the select string:
            dbrec1.Open(strSql, DBCON1)

            ReDim iSlots(0)

            Do Until dbrec1.EOF


                iSlotsCount += 1
                ReDim Preserve iSlots(iSlotsCount)

                iSlots(iSlotsCount) = Convert.ToString(dbrec1.Fields("SLOT").Value)

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()


            For x = 1 To SlotsRecordCount


                bSlotInUse = False
                For y = 1 To iSlotsCount
                    If iSlots(y) = Slots(x - 1) Then
                        'this slot is already in use
                        bSlotInUse = True
                        Exit For
                    End If
                Next

                If bSlotInUse = False Then

                    'this slot is available as it was not found
                    If Slots(x - 1) = strRequestedSlot Then
                        'done - no need to keep looking
                        strFirstAvailableSlot = strRequestedSlot
                        Exit For
                    Else
                        If strFirstAvailableSlot = "-1" Then
                            'dont want to overwrite if previous slot available
                            strFirstAvailableSlot = Slots(x - 1)
                        End If

                    End If

                End If


            Next

            FindOpenSlotForShipment = strFirstAvailableSlot


        Catch ex As Exception
            FindOpenSlotForShipment = "-1"
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Function

    Private Sub butMsg14GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg14GetData.Click
        GetAndDisplayMsg14Data()
    End Sub

    Private Sub GetAndDisplayMsg14Data()
        FillMsg13_Cust_LineItem()
        DisplayMsg14Cust_LineItem()
    End Sub

    Private Sub butMsg14SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg14SelectAll.Click
        ProcessGridSelectAll(flxGrid7)
    End Sub

    Private Sub butMsg14DeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg14DeselectAll.Click
        ProcessGridDeSelectAll(flxGrid7)
    End Sub

    Private Sub butMsg14Advance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg14Advance.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid7) = False Then Exit Sub
        Msg14Advance(True)
    End Sub

    Private Sub Msg14Advance(ByVal bUserPrompt As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim iAdvances As Integer = 0
        Dim strRetro_Status As String = "14"
        Dim strMsgTyp As String

        Dim strSHIP_ID As String
        Dim strLINE_ID As String
        Dim strACTIV_OUTPUT_LOCATION As String
        Dim strUNIT_LOAD_ID As String
        Dim strPALLET_TYPE As String
        Dim strBRAND_CODE As String
        Dim strCODE_DATE As String
        Dim strWITHDRAWAL_OUTPUT_STATUS As String
        Dim strSelect_Flag As String
        Dim strMsgTypFromGrid As String
        Dim strQty As String
        Dim bSkipMsgSend As Boolean


        Dim struct As Cust_pallet

        Try

            If bUserPrompt = True Then

                shMsgbox = MsgBox("Send WithdrawalULArrival for Selected Shipid (s) ?", MsgBoxStyle.YesNo, "Confirm Message Send")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                'get rid of any completed withdraws first
                PurgeCompletedWithdraws(bUserPrompt)

                GetAndDisplayMsg14Data()
                ProcessGridSelectAll(flxGrid7)
            End If

            For x = 1 To flxGrid7.Rows - 1

                bSkipMsgSend = False
                If flxGrid7.get_TextMatrix(x, 0) = gcstrY Then
                    iAdvances += 1

                    If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then


                        strSHIP_ID = flxGrid7.get_TextMatrix(x, 1)
                        strLINE_ID = flxGrid7.get_TextMatrix(x, 2)
                        strACTIV_OUTPUT_LOCATION = flxGrid7.get_TextMatrix(x, 8)
                        strUNIT_LOAD_ID = flxGrid7.get_TextMatrix(x, 6)
                        strPALLET_TYPE = flxGrid7.get_TextMatrix(x, 5)
                        strBRAND_CODE = flxGrid7.get_TextMatrix(x, 3)
                        strCODE_DATE = flxGrid7.get_TextMatrix(x, 4)
                        strWITHDRAWAL_OUTPUT_STATUS = flxGrid7.get_TextMatrix(x, 7)
                        strSelect_Flag = flxGrid7.get_TextMatrix(x, 9)
                        strMsgTypFromGrid = flxGrid7.get_TextMatrix(x, 10)

                        strRetro_Status = "14"
                        If strMsgTypFromGrid = "13S" Then
                            'A14 if inventory can be found, D14 if not

                            If strUNIT_LOAD_ID.Length = 0 Then
                                'need to find a ULID
                                struct = FindULforShipid(strUNIT_LOAD_ID, strPALLET_TYPE, strBRAND_CODE, strCODE_DATE, strSelect_Flag)
                                strUNIT_LOAD_ID = struct.strCust_ID
                            End If

                            If strUNIT_LOAD_ID = "-1" Then

                                WriteLog("Info", "No Inventory for Manual Request " &
                                                "|ShipId:" & strSHIP_ID &
                                                "|Brand:" & strBRAND_CODE &
                                                "|Pal:" & strPALLET_TYPE &
                                                "|CodDat:" & strCODE_DATE &
                                                "|")
                                strMsgTyp = "D14"    'cant fulfill request
                                strRetro_Status = "14D"
                                strWITHDRAWAL_OUTPUT_STATUS = TotalWithdrawalOutputStatusforD14(strSHIP_ID)    'short qty

                            Else
                                strMsgTyp = "A14"
                            End If

                        ElseIf strMsgTypFromGrid = "13C" Then
                            'D14
                            ' strMsgTyp = "D14"
                            'strRetro_Status = "14D"
                            'strWITHDRAWAL_OUTPUT_STATUS = TotalWithdrawalOutputStatusforD14(strSHIP_ID)    'short qty

                            'D14
                            strMsgTyp = "A14"
                            strRetro_Status = "14"
                            strWITHDRAWAL_OUTPUT_STATUS = "-106"    'error code for confirming cancel


                        ElseIf strMsgTypFromGrid = "14" OrElse strMsgTypFromGrid = "14D" Then
                            'dont count this as an advance!
                            strMsgTyp = String.Empty
                            iAdvances -= 1

                            WriteLog(gcstrINFO, "Info:" & strSHIP_ID & Space(2) & "Not Sending Msg" & strMsgTypFromGrid & " Already Sent")
                            bSkipMsgSend = True
                        Else
                            'unknown but still send it!
                            WriteLog(gcstrError, "Info:" & strSHIP_ID & Space(2) & "Unknown Msgtyp:" & strMsgTypFromGrid)
                            strMsgTyp = strMsgTypFromGrid
                        End If

                        If bSkipMsgSend = False Then
                            If SendRequest(CreateXML_WithdrawalULArrival(strMsgTyp, strSHIP_ID, strACTIV_OUTPUT_LOCATION,
                                    strUNIT_LOAD_ID, strPALLET_TYPE, strBRAND_CODE, strCODE_DATE, strWITHDRAWAL_OUTPUT_STATUS)) = True Then

                                'update the shipment table 
                                Update_CUST_SHIPMENT(strSHIP_ID, strRetro_Status, strACTIV_OUTPUT_LOCATION)

                                'update the line_item_table
                                If strMsgTyp = "A14" Then
                                    strQty = "1"
                                    Update_CUST_LINEITEM_AfterStaging(strSHIP_ID, strLINE_ID, strUNIT_LOAD_ID, strRetro_Status, strQty)
                                ElseIf strMsgTyp = "D14" Then
                                    strQty = "0"
                                    Update_CUST_LINEITEM_forD14(strSHIP_ID, strRetro_Status, strQty)

                                End If


                                If strMsgTyp = "A14" Then
                                    Update_CUST_PALLET_AfterStaging(strUNIT_LOAD_ID, strSHIP_ID, gstrManualOutputVTLPrefix & strACTIV_OUTPUT_LOCATION, strRetro_Status)
                                    txtUtil_Ulid.Text = strUNIT_LOAD_ID
                                End If
                            Else
                                WriteLog(gcstrError, "Msg14 Failed for ULID " & strUNIT_LOAD_ID & " ID " & strSHIP_ID & " Slot " & strACTIV_OUTPUT_LOCATION & " Database Update Skipped")

                                Exit For
                            End If
                        End If
                    End If

                End If
            Next

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally



        End Try
    End Sub

    Private Function TotalWithdrawalOutputStatusforD14(ByVal strShip_id As String) As String
        Dim y As Integer
        Dim iShortQuantity As Integer = 0

        Try
            'once a withdraw is determined to be short only 1 D14 is sent for the entire short qty and not by UL
            'look at all items  for the same ship_id
            For y = 1 To flxGrid7.Rows - 1
                If strShip_id = flxGrid7.get_TextMatrix(y, 1) And flxGrid7.get_TextMatrix(y, 10) <> "14" _
                        And flxGrid7.get_TextMatrix(y, 10) <> "14D" Then
                    iShortQuantity += 1

                    'ensure that records for the same SHIP_ID don't trigger another 14 by unselecting
                    flxGrid7.set_TextMatrix(y, 0, String.Empty)

                End If

            Next
            TotalWithdrawalOutputStatusforD14 = iShortQuantity.ToString
        Catch
            TotalWithdrawalOutputStatusforD14 = "0"
        End Try
    End Function

    Public Function Update_CUST_LINEITEM_AfterStaging(ByVal strSHIP_ID As String, ByVal strLINE_ID As String,
                                               ByVal strULID As String, ByVal strRETRO_STATUS As String, ByVal strQty As String) As Boolean

        Dim strSql As String = String.Empty

        Try
            'If strULID <> "-1" Then      'dave removed the IF on 20140827 because it was not cancelign SS correctly
            strSql = "update CUST_LINEITEM set " &
            "RETRO_STATUS='" & strRETRO_STATUS & "', " &
            "CUST_ID='" & strULID & "', " &
            "STAGED='" & strQty & "', " &
            "SUPPLIED='" & strQty & "' " &
            "where SHIP_ID ='" & strSHIP_ID & "' " &
            "and LINE_ID ='" & strLINE_ID & "' "
            'Else

            'End If
            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_LINEITEM_AfterStaging = True

        Catch
            Update_CUST_LINEITEM_AfterStaging = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strSHIP_ID & Space(1) & Err.Description)

        End Try

    End Function
    Public Function Update_CUST_LINEITEM_forD14(ByVal strSHIP_ID As String, ByVal strRETRO_STATUS As String, ByVal strQty As String) As Boolean

        Dim strSql As String

        Try
            strSql = "update CUST_LINEITEM set " &
            "RETRO_STATUS='" & strRETRO_STATUS & "', " &
            "CUST_ID='-1', " &
            "STAGED='" & strQty & "', " &
            "SUPPLIED='" & strQty & "' " &
            "where SHIP_ID ='" & strSHIP_ID & "' " &
            "and (staged <> '1' or staged is null) "

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_LINEITEM_forD14 = True

        Catch
            Update_CUST_LINEITEM_forD14 = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strSHIP_ID & Space(1) & Err.Description)

        End Try

    End Function
    Private Sub flxGrid7_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid7.MouseDownEvent
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub

    Private Function FindULforShipid(ByVal strULID As String, ByVal strPallet_Type As String,
                                     ByVal strBrand_Code As String, ByVal strCode_date As String, ByVal strHoldStatus As String) As Cust_pallet
        Dim strSql As String
        Dim iRecordCount As Integer = 0
        Dim iRecord() As String
        Dim strPalletSQL As String = String.Empty
        Dim strCoddatSQL As String = String.Empty
        Dim strHoldStatusSQL As String = String.Empty
        Dim struct As New Cust_pallet


        Try
            If strPallet_Type.Length > 0 Then
                strPalletSQL = "and PALLET_TYPE='" & strPallet_Type & "' "
            End If

            If strCode_date.Length > 0 Then
                strCoddatSQL = "and CODE_DATE='" & strCode_date & "' "
            Else
                ' strHoldStatusSQL = "and HOLD_STATUS='" & strHoldStatus & "' "   I am not sure why I had this in there
            End If

            If strHoldStatus.Length > 0 Then
                strHoldStatusSQL = "and HOLD_STATUS='" & strHoldStatus & "' "
            End If

            'find all currently used Record but not those that have been requested by user

            If strULID.Length = 0 Then   ' need to find  UL

                strSql = "select CUST_ID as THEVALUE, PALLET_TYPE, CODE_DATE " &
                    "from CUST_PALLET " &
                    "where " &
                    "BRAND_CODE='" & strBrand_Code & "' " &
                    strPalletSQL &
                    strCoddatSQL &
                    strHoldStatusSQL &
                    "and (ship_id is null or ship_id='') " &
                    "order by cust_id asc "
            Else
                'dave fix this later needs to get code_date etc
                strSql = "select CUST_ID as THEVALUE, PALLET_TYPE, CODE_DATE " &
                    "from CUST_PALLET " &
                    "where " &
                    "BRAND_CODE='" & strBrand_Code & "', " &
                    "and CUST_ID='" & strULID & "' " &
                    "order by cust_id asc "
            End If

            ' Open the Recordset using the select string:
            dbrec1.Open(strSql, DBCON1)

            ReDim iRecord(0)

            Do Until dbrec1.EOF

                iRecordCount += 1


                struct.strCust_ID = Convert.ToString(dbrec1.Fields("THEVALUE").Value)
                struct.strPallet_Type = Convert.ToString(dbrec1.Fields("PALLET_TYPE").Value)
                struct.Code_Date = Convert.ToString(dbrec1.Fields("CODE_DATE").Value)

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()


            If iRecordCount > 0 Then

            Else
                struct.strCust_ID = "-1"
            End If
            Return struct
        Catch ex As Exception
            struct.strCust_ID = "-1"
            Return struct
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Function

    Private Sub butMsg11_Send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg11_Send.Click
        SendMsg11()
    End Sub

    Private Sub SendMsg11()
        Try

            If SendRequest(CreateXML_Msg11(txtMsg11_Tech_Group.Text, txtMsg11_RDT_Message.Text)) = False Then
                WriteLog(gcstrError, "Msg11 Failed for Tech Group " & txtMsg11_Tech_Group.Text)
            End If

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub butMsg16_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg16_GetData.Click
        GetAndDisplayMsg16Data()
    End Sub
    Private Sub GetAndDisplayMsg16Data()
        FillMsg16_History()
        DisplayMsg16_History()

    End Sub


    Private Sub FillMsg16_History()
        Dim strSQL As String

        Try

            strSQL = "select CTRL_DATE,CUST_ID,CODE_DATE,HOLD_STATUS,BRAND_CODE " &
                "from MSG16HST " &
                "where " &
                "ctrl_date > " & Today.AddDays(giDaysOfMsg16HistoryToDisplay * -1) &
                " order by CTRL_DATE  desc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Msg16_History_RecordCount = 0
            ReDim Msg16_History(0)

            Do Until dbrec1.EOF

                Msg16_History_RecordCount += 1
                ReDim Preserve Msg16_History(Msg16_History_RecordCount)

                With Msg16_History(Msg16_History_RecordCount)
                    .CTRL_DATE = Convert.ToString(dbrec1.Fields("CTRL_DATE").Value)
                    .CUST_ID = Convert.ToString(dbrec1.Fields("CUST_ID").Value)
                    .CODE_DATE = Convert.ToString(dbrec1.Fields("CODE_DATE").Value)
                    .HOLD_STATUS = Convert.ToString(dbrec1.Fields("HOLD_STATUS").Value)
                    .BRAND_CODE = Convert.ToString(dbrec1.Fields("BRAND_CODE").Value)


                    '  .WITHDRAWAL_INTENT_CODE = Convert.ToString(dbrec1.Fields("WITHDRAWAL_INTENT_CODE").Value)

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub


    Private Sub DisplayMsg14Cust_LineItem()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid7.Rows = 1
            flxGrid7.Rows = 2
            flxGrid7.Cols = 11
            flxGrid7.Row = 0
            For y = 1 To flxGrid7.Cols
                flxGrid7.Col = y - 1
                flxGrid7.Text = vbNullString

                Select Case flxGrid7.Col

                    Case 0, 2, 5, 10
                        flxGrid7.set_ColWidth(flxGrid7.Col, 500)

                    Case 6
                        flxGrid7.set_ColWidth(flxGrid7.Col, 2000)

                    Case -1
                        flxGrid7.set_ColWidth(flxGrid7.Col, 0)

                    Case Else
                        flxGrid7.set_ColWidth(flxGrid7.Col, 1000)

                End Select

            Next

            flxGrid7.Redraw = False


            flxGrid7.Rows = 2
            flxGrid7.Row = 0

            flxGrid7.Col = 0
            flxGrid7.Text = "Sel"
            flxGrid7.Col = 1
            flxGrid7.Text = "ShipId"
            flxGrid7.Col = 2
            flxGrid7.Text = "L#"
            flxGrid7.Col = 3
            flxGrid7.Text = "Brand"
            flxGrid7.Col = 4
            flxGrid7.Text = "CodDat"
            flxGrid7.Col = 5
            flxGrid7.Text = "Pal"
            flxGrid7.Col = 6
            flxGrid7.Text = "Ulid"
            'these don't come from the query, but are the 2 criteria to return to RTCIS
            flxGrid7.Col = 7
            flxGrid7.Text = "OutStat"
            flxGrid7.Col = 8
            flxGrid7.Text = "OutLoc"
            flxGrid7.Col = 9
            flxGrid7.Text = "SelFlg"
            flxGrid7.Col = 10
            flxGrid7.Text = "Msg"

            For x = 1 To Msg13_Cust_LineItem_RecordCount

                flxGrid7.Row += 1

                flxGrid7.Col = 1
                flxGrid7.CellBackColor = colorBack
                flxGrid7.CellForeColor = colorFore
                flxGrid7.Text = vbNullString & Msg13_Cust_LineItem(x).SHIP_ID

                flxGrid7.Col = 2
                flxGrid7.CellBackColor = colorBack
                flxGrid7.CellForeColor = colorFore
                flxGrid7.Text = vbNullString & Msg13_Cust_LineItem(x).LINE_ID

                flxGrid7.Col = 3
                flxGrid7.CellBackColor = colorBack
                flxGrid7.CellForeColor = colorFore
                flxGrid7.Text = vbNullString & Msg13_Cust_LineItem(x).BRAND_CODE

                flxGrid7.Col = 4
                flxGrid7.CellBackColor = colorBack
                flxGrid7.CellForeColor = colorFore
                flxGrid7.Text = vbNullString & Msg13_Cust_LineItem(x).CODE_DATE

                flxGrid7.Col = 5
                flxGrid7.CellBackColor = colorBack
                flxGrid7.CellForeColor = colorFore
                flxGrid7.Text = vbNullString & Msg13_Cust_LineItem(x).PAL_TYPE

                flxGrid7.Col = 6            'ULID
                flxGrid7.CellBackColor = colorBack
                flxGrid7.CellForeColor = colorFore
                flxGrid7.Text = vbNullString & Msg13_Cust_LineItem(x).CUST_ID

                flxGrid7.Col = 7
                flxGrid7.CellBackColor = colorBack
                flxGrid7.CellForeColor = colorFore
                If Msg13_Cust_LineItem(x).RETRO_STATUS = "13S" Then
                    flxGrid7.Text = vbNullString & "0"      'default output status
                ElseIf Msg13_Cust_LineItem(x).RETRO_STATUS = "13C" Then
                    flxGrid7.Text = vbNullString & "1"
                End If


                flxGrid7.Col = 8
                flxGrid7.CellBackColor = colorBack
                flxGrid7.CellForeColor = colorFore
                flxGrid7.Text = vbNullString & Msg13_Cust_LineItem(x).Slot

                flxGrid7.Col = 9
                flxGrid7.CellBackColor = colorBack
                flxGrid7.CellForeColor = colorFore
                flxGrid7.Text = vbNullString & Msg13_Cust_LineItem(x).SELECT_FLAG

                flxGrid7.Col = 10
                flxGrid7.CellBackColor = colorBack
                flxGrid7.CellForeColor = colorFore
                flxGrid7.Text = vbNullString & Msg13_Cust_LineItem(x).RETRO_STATUS

                flxGrid7.Rows += 1

            Next

            'remove last blank row
            flxGrid7.Rows -= 1
            flxGrid7.Col = 0
            DisplayGridRowCount(butMsg14SelectAll, flxGrid7)
            ' flxGrid7.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid7.Redraw = True

        End Try
    End Sub

    Private Sub DeleteMsg16HistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMsg16HistoryToolStripMenuItem.Click
        DeleteAllDatafromEmulatorDBTable("MSG16HST", True)
    End Sub

    Private Sub SendMsg21()
        Try

            If SendRequest(CreateXML_RequestNextShip(txtMsg21_MOT_CODE.Text)) = False Then
                WriteLog(gcstrError, "Msg21 Send Failed")
            End If
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Sub

    Private Sub SendMsgRequestNextProdOrder()
        Try

            If SendRequest(CreateXML_RequestNextProdOrder(txtRequestNextProdOrder_DeliveryLocation.Text)) = False Then
                WriteLog(gcstrError, "RequestNextProdOrder Msg Send Failed")
            End If
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Sub
    Private Sub Msg24AutoSendOn()
        AutoScanOn(butMsg24AutoSendOn, butMsg24AutoSendOff)
    End Sub
    Private Sub Msg22AutoSendOn()
        AutoScanOn(butMsg22AutoSendOn, butMsg22AutoSendOff)
    End Sub
    Private Sub Msg22AutoSendOff()
        AutoScanOff(butMsg22AutoSendOn, butMsg22AutoSendOff)
    End Sub
    Private Sub Msg21AutoSendOn()
        AutoScanOn(butMsg21AutoSendOn, butMsg21AutoSendOff)
    End Sub
    Private Sub Msg21AutoSendOff()
        AutoScanOff(butMsg21AutoSendOn, butMsg21AutoSendOff)
    End Sub

    Private Sub AutoScanOn(ByVal oOnButton As Button, ByVal oOffButton As Button)
        chkAutoDataRefresh.Checked = False 'prevent duplicate data retrieves
        chkAutoRefresh.Checked = True

        'setup the  timer
        tmrAutoScan.Interval = Convert.ToInt32(giAutoScanIntervalSeconds * 1000)
        tmrAutoScan.Enabled = True

        'set auto button colors
        oOnButton.BackColor = Color.LightGreen
        oOffButton.BackColor = Color.FromKnownColor(KnownColor.Control)


        Me.Refresh()
    End Sub

    Private Sub AutoScanOff(ByVal oOnButton As Button, ByVal oOffButton As Button)

        oOnButton.BackColor = Color.FromKnownColor(KnownColor.Control)
        oOffButton.BackColor = Color.Red
    End Sub


    Private Sub AutoScanTimerFired()
        Dim AtLeastOneULOperationinAuto As Boolean = False

        Try
            lblToolStripWorking.Visible = False
            lblToolStripWorking.Text = String.Empty

            If btnInfeedAutoScanOn.BackColor = Color.LightGreen Then
                lblToolStripWorking.Text = "RTCIS Infeed Auto Scanning"
                lblToolStripWorking.Visible = True
                InfeedAdvance(False)
                AtLeastOneULOperationinAuto = True
            End If

            If btnASRSInfeedAutoScanOn.BackColor = Color.LightGreen Then
                lblToolStripWorking.Text = "ASRS Infeed Auto Scanning"
                AdvanceViaMsg7(False)
                ASRSInfeedAdvance(False)
                GetandDisplayASRSAvailableInventorySummary()
                AtLeastOneULOperationinAuto = True
            End If

            If butMsg13AutoScanOn.BackColor = Color.LightGreen Then
                lblToolStripWorking.Text = "Msg13/14 Auto Scanning"
                Msg13Advance(False)
                Msg14Advance(False)
            End If

            If butMsg21AutoSendOn.BackColor = Color.LightGreen Then
                lblToolStripWorking.Text = "Msg21 Request Shipment from RTCIS Auto Scanning"
                lblToolStripWorking.Visible = True
                SendMsg21()
            End If

            If butMsg22AutoSendOn.BackColor = Color.LightGreen Then
                lblToolStripWorking.Text = "Stage/De-Stage Auto Scanning"
                lblToolStripWorking.Visible = True
                StageOrDestageAdvance(False)

            End If

            If butMsg24AutoSendOn.BackColor = Color.LightGreen Then
                lblToolStripWorking.Text = "Order Completion Auto Scanning"
                lblToolStripWorking.Visible = True
                StageCompleteAdvance(False)
                GetandDisplayStagedUlsInWMS()
            End If


            If btnFPDSAutoScanOn.BackColor = Color.LightGreen Then
                lblToolStripWorking.Text = "Trailer FPDS Auto Scanning "
                lblToolStripWorking.Visible = True
                FPDSAdvance(False)
            End If


            If lblToolStripWorking.Visible = True Then
                gbAtLeastOneAutoScanFunctionActive = True
            Else
                gbAtLeastOneAutoScanFunctionActive = False
            End If

            If AtLeastOneULOperationinAuto = True Then
                '  GetGraphicalData()
            End If

        Catch
            InfeedAutoScanOff()
            ASRSInfeedAutoScanOff()
            Msg13AutoScanOff()
            Msg21AutoSendOff()
            Msg22AutoSendOff()
            Msg24AutoSendOff()
            TrailerFPDSAutoScanOff()
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            lblToolStripWorking.Visible = False
        End Try

    End Sub

    Private Sub FillMsg21_Header()
        Dim strSQL As String
        Try

            strSQL = "select CUST_SHIPMENT,DISPOSITION, APP_DATETIME, RETRO_STATUS, SLOT, LOAD_STATUS, SHIP_TYPE " &
                "from CUST_SHIPMENT " &
                "where " &
                 "(retro_status in ('21','A22','D22','41','A42','D42') or (retro_status in ('A24','A44') and LOAD_STATUS='CANCLD'))  " &
                 "and SHIP_TYPE in('SR','CR') " &
                "order by APP_DATETIME  asc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Msg21_Header_RecordCount = 0
            ReDim Msg21_Header(0)

            Do Until dbrec1.EOF


                Msg21_Header_RecordCount += 1
                ReDim Preserve Msg21_Header(Msg21_Header_RecordCount)

                With Msg21_Header(Msg21_Header_RecordCount)
                    .SHIP_ID = Convert.ToString(dbrec1.Fields("CUST_SHIPMENT").Value)
                    .DISPOSITION = Convert.ToString(dbrec1.Fields("DISPOSITION").Value)
                    .APP_DATETIME = Convert.ToString(dbrec1.Fields("APP_DATETIME").Value)
                    .RETRO_STATUS = Convert.ToString(dbrec1.Fields("RETRO_STATUS").Value)
                    .SLOT = Convert.ToString(dbrec1.Fields("SLOT").Value)
                    .LOAD_STATUS = Convert.ToString(dbrec1.Fields("LOAD_STATUS").Value)
                    .SHIP_TYPE = Convert.ToString(dbrec1.Fields("SHIP_TYPE").Value)

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub butMsg21_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21_GetData.Click
        GetandDisplayMsg21HeaderData()
    End Sub

    Private Sub GetandDisplayMsg21HeaderData()
        FillMsg21_Header()
        DisplayMsg21_Header()

        'redisplay the line item grid, auto select the first row
        SelectLineItemDetails(flxGrid4, 1)
    End Sub

    Private Sub DisplayMsg21_Header()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid4.Rows = 1
            flxGrid4.Rows = 2
            flxGrid4.Cols = 8
            flxGrid4.Row = 0
            For y = 1 To flxGrid4.Cols
                flxGrid4.Col = y - 1
                flxGrid4.Text = vbNullString

                Select Case flxGrid4.Col

                    Case 0, 3, 4, 7
                        flxGrid4.set_ColWidth(flxGrid4.Col, 500)

                    Case 5, 6
                        flxGrid4.set_ColWidth(flxGrid4.Col, 800)

                    Case 1
                        flxGrid4.set_ColWidth(flxGrid4.Col, 1700)

                    Case Else
                        flxGrid4.set_ColWidth(flxGrid4.Col, 1000)

                End Select

            Next

            flxGrid4.Redraw = False


            flxGrid4.Rows = 2
            flxGrid4.Row = 0

            flxGrid4.Col = 0
            flxGrid4.Text = "Sel"
            flxGrid4.Col = 1
            flxGrid4.Text = "Apt Dat"
            flxGrid4.Col = 2
            flxGrid4.Text = "ShipId"
            flxGrid4.Col = 3
            flxGrid4.Text = "Disp"
            flxGrid4.Col = 4
            flxGrid4.Text = "Slot"
            flxGrid4.Col = 5
            flxGrid4.Text = "R_Stat"
            flxGrid4.Col = 6
            flxGrid4.Text = "L_Stat"
            flxGrid4.Col = 7
            flxGrid4.Text = "Typ"

            For x = 1 To Msg21_Header_RecordCount

                flxGrid4.Row += 1

                flxGrid4.Col = 1
                flxGrid4.CellBackColor = colorBack
                flxGrid4.CellForeColor = colorFore
                flxGrid4.Text = vbNullString & Msg21_Header(x).APP_DATETIME

                flxGrid4.Col = 2
                flxGrid4.CellBackColor = colorBack
                flxGrid4.CellForeColor = colorFore
                flxGrid4.Text = vbNullString & Msg21_Header(x).SHIP_ID

                flxGrid4.Col = 3
                flxGrid4.CellBackColor = colorBack
                flxGrid4.CellForeColor = colorFore
                flxGrid4.Text = vbNullString & Msg21_Header(x).DISPOSITION

                flxGrid4.Col = 4
                flxGrid4.CellBackColor = colorBack
                flxGrid4.CellForeColor = colorFore
                flxGrid4.Text = vbNullString & Msg21_Header(x).SLOT

                flxGrid4.Col = 5
                flxGrid4.CellBackColor = colorBack
                flxGrid4.CellForeColor = colorFore
                flxGrid4.Text = vbNullString & Msg21_Header(x).RETRO_STATUS

                flxGrid4.Col = 6
                flxGrid4.CellBackColor = colorBack
                flxGrid4.CellForeColor = colorFore
                flxGrid4.Text = vbNullString & Msg21_Header(x).LOAD_STATUS

                flxGrid4.Col = 7
                flxGrid4.CellBackColor = colorBack
                flxGrid4.CellForeColor = colorFore
                flxGrid4.Text = vbNullString & Msg21_Header(x).SHIP_TYPE

                flxGrid4.Rows += 1

            Next


            'remove last blank row
            flxGrid4.Rows -= 1
            flxGrid4.Col = 0
            DisplayGridRowCount(butMsg21_Header_SelectAll, flxGrid4)
            ' flxGrid4.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid4.Redraw = True

        End Try
    End Sub


    Private Sub butMsg21_Header_SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21_Header_SelectAll.Click
        ProcessGridSelectAll(flxGrid4)
    End Sub

    Private Sub butMsg21_Header_DeSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21_Header_DeSelectAll.Click
        ProcessGridDeSelectAll(flxGrid4)
    End Sub

    Private Sub butMsg21_Header_Advance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21_Header_Advance.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid4) = False Then Exit Sub
        StageOrDestageAdvance(True)
    End Sub

    Private Sub butMsg21_Detail_SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21_Detail_SelectAll.Click
        ProcessGridSelectAll(flxGrid8)
    End Sub

    Private Sub butMsg21_Detail_DeSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21_Detail_DeSelectAll.Click
        ProcessGridDeSelectAll(flxGrid8)
    End Sub

    Private Sub GetandDisplayMsg21DetailData(ByVal strShipid As String)
        'check how many ULs are in the slot 
        If StagedUlsforShipId(strShipid) < giMaxUnitLoadsPerSlot Then
            lblSlotMaxAlarm.Visible = False
        Else
            lblSlotMaxAlarm.Visible = True
        End If
        FillMsg21_Detail(strShipid)
        DisplayMsg21_Detail()
    End Sub

    Private Sub DisplayMsg21_Detail()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid8.Rows = 1
            flxGrid8.Rows = 2
            flxGrid8.Cols = 11
            flxGrid8.Row = 0
            For y = 1 To flxGrid8.Cols
                flxGrid8.Col = y - 1
                flxGrid8.Text = vbNullString

                Select Case flxGrid8.Col

                    Case 0, 10
                        flxGrid8.set_ColWidth(flxGrid8.Col, 500)

                    Case 4
                        flxGrid8.set_ColWidth(flxGrid8.Col, 1200)

                    Case 8
                        flxGrid8.set_ColWidth(flxGrid8.Col, 2000)

                    Case Else
                        flxGrid8.set_ColWidth(flxGrid8.Col, 1000)

                End Select

            Next

            flxGrid8.Redraw = False

            flxGrid8.Rows = 2
            flxGrid8.Row = 0

            flxGrid8.Col = 0
            flxGrid8.Text = "Sel"
            flxGrid8.Col = 1
            flxGrid8.Text = "Line Id"
            flxGrid8.Col = 2
            flxGrid8.Text = "Seq"
            flxGrid8.Col = 3
            flxGrid8.Text = "Brand"
            flxGrid8.Col = 4
            flxGrid8.Text = "Coddat"
            flxGrid8.Col = 5
            flxGrid8.Text = "Pal Typ"
            flxGrid8.Col = 6
            flxGrid8.Text = "StgPalTyp"
            flxGrid8.Col = 7
            flxGrid8.Text = "Staged"
            flxGrid8.Col = 8
            flxGrid8.Text = "CustID"
            flxGrid8.Col = 9
            flxGrid8.Text = "Retro_Sta"
            flxGrid8.Col = 10
            flxGrid8.Text = "Qa"

            For x = 1 To Msg21_Detail_RecordCount

                flxGrid8.Row += 1

                flxGrid8.Col = 1
                flxGrid8.CellBackColor = colorBack
                flxGrid8.CellForeColor = colorFore
                flxGrid8.Text = vbNullString & Msg21_DEtail(x).LINE_ID


                flxGrid8.Col = 2
                flxGrid8.CellBackColor = colorBack
                flxGrid8.CellForeColor = colorFore
                flxGrid8.Text = vbNullString & Msg21_DEtail(x).SEQUENCE

                flxGrid8.Col = 3
                flxGrid8.CellBackColor = colorBack
                flxGrid8.CellForeColor = colorFore
                flxGrid8.Text = vbNullString & Msg21_DEtail(x).BRAND_CODE

                flxGrid8.Col = 4
                flxGrid8.CellBackColor = colorBack
                flxGrid8.CellForeColor = colorFore
                flxGrid8.Text = vbNullString & Msg21_DEtail(x).CODE_DATE

                flxGrid8.Col = 5
                flxGrid8.CellBackColor = colorBack
                flxGrid8.CellForeColor = colorFore
                flxGrid8.Text = vbNullString & Msg21_DEtail(x).PAL_TYPE

                flxGrid8.Col = 6
                flxGrid8.CellBackColor = colorBack
                flxGrid8.CellForeColor = colorFore
                flxGrid8.Text = vbNullString & Msg21_DEtail(x).StagedPalletType

                flxGrid8.Col = 7
                flxGrid8.CellBackColor = colorBack
                flxGrid8.CellForeColor = colorFore
                flxGrid8.Text = vbNullString & Msg21_DEtail(x).STAGED

                flxGrid8.Col = 8
                flxGrid8.CellBackColor = colorBack
                flxGrid8.CellForeColor = colorFore
                flxGrid8.Text = vbNullString & Msg21_DEtail(x).CUST_ID

                flxGrid8.Col = 9
                flxGrid8.CellBackColor = colorBack
                flxGrid8.CellForeColor = colorFore
                flxGrid8.Text = vbNullString & Msg21_DEtail(x).RETRO_STATUS

                flxGrid8.Col = 10
                flxGrid8.CellBackColor = colorBack
                flxGrid8.CellForeColor = colorFore
                flxGrid8.Text = vbNullString & Msg21_DEtail(x).SELECT_FLAG

                flxGrid8.Rows += 1

            Next


            'remove last blank row
            flxGrid8.Rows -= 1
            flxGrid8.Col = 0
            DisplayGridRowCount(butMsg21_Detail_SelectAll, flxGrid8)
            ' flxGrid8.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid8.Redraw = True

        End Try
    End Sub

    Private Sub FillMsg21_Detail(ByVal strShipid As String)
        Dim strSQL As String
        Try

            strSQL = "select L.LINE_ID,L.SEQUENCE,L.BRAND_CODE, L.CODE_DATE, L.PAL_TYPE, L.STAGED, L.CUST_ID,L.RETRO_STATUS, PALLET_TYPE as CUST_PALLET_TYPE, SELECT_FLAG " &
                "from CUST_LINEITEM L " &
                "LEFT OUTER JOIN CUST_PALLET P " &
                "ON L.CUST_ID = P.CUST_ID " &
                "where " &
                 "L.SHIP_ID= '" & strShipid & "' " &
                "order by L.LINE_ID, L.BRAND_CODE  asc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Msg21_Detail_RecordCount = 0
            ReDim Msg21_DEtail(0)

            Do Until dbrec1.EOF


                Msg21_Detail_RecordCount += 1
                ReDim Preserve Msg21_DEtail(Msg21_Detail_RecordCount)

                With Msg21_DEtail(Msg21_Detail_RecordCount)
                    .LINE_ID = Convert.ToString(dbrec1.Fields("LINE_ID").Value)
                    .SEQUENCE = Convert.ToString(dbrec1.Fields("SEQUENCE").Value)
                    .BRAND_CODE = Convert.ToString(dbrec1.Fields("BRAND_CODE").Value)
                    .CODE_DATE = Convert.ToString(dbrec1.Fields("CODE_DATE").Value)
                    .PAL_TYPE = Convert.ToString(dbrec1.Fields("PAL_TYPE").Value)
                    .STAGED = Convert.ToString(dbrec1.Fields("STAGED").Value)
                    .CUST_ID = Convert.ToString(dbrec1.Fields("CUST_ID").Value)
                    .RETRO_STATUS = Convert.ToString(dbrec1.Fields("RETRO_STATUS").Value)
                    .StagedPalletType = Convert.ToString(dbrec1.Fields("CUST_PALLET_TYPE").Value)
                    .SELECT_FLAG = Convert.ToString(dbrec1.Fields("SELECT_FLAG").Value)
                    'dave might need to have FIFO window for CIMAT

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub StageOrDestageAdvance(ByVal bUserPrompt As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim strSHIP_ID As String
        Dim iAdvances As Integer = 0
        Dim strRetro_Status As String = "22"  '13 SENT
        Dim strAvailableSlot As String
        Dim strSlot As String
        Dim strUserSelectedRow As String
        Dim bRefreshLog As Boolean
        Dim strLoad_Status As String
        Dim strShip_Type As String

        Try

            If bUserPrompt = True Then

                shMsgbox = MsgBox("Send Msg for Selected Shipid (s) ?", MsgBoxStyle.YesNo, "Confirm Msg Processing")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                GetandDisplayMsg21HeaderData()
                ProcessGridSelectAll(flxGrid4)
            End If

            For x = 1 To flxGrid4.Rows - 1


                strUserSelectedRow = flxGrid4.get_TextMatrix(x, 0)
                strSHIP_ID = Trim(flxGrid4.get_TextMatrix(x, 2))
                strSlot = Trim(flxGrid4.get_TextMatrix(x, 4))
                strRetro_Status = Trim(flxGrid4.get_TextMatrix(x, 5))
                strLoad_Status = Trim(flxGrid4.get_TextMatrix(x, 6))
                strShip_Type = Trim(flxGrid4.get_TextMatrix(x, 7))

                If strUserSelectedRow = gcstrY And (strRetro_Status = "21" Or strRetro_Status = "41") Then
                    iAdvances += 1


                    If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then

                        strAvailableSlot = FindOpenSlotForShipment(strSlot)

                        If strAvailableSlot <> "-1" Then
                            'do the advance
                            'shipid  (M#), withdraw output time, and locatn
                            If strShip_Type = gcstrPORequest Then

                                SendMsg22("A42", strSHIP_ID, strAvailableSlot)
                            Else
                                SendMsg22("A22", strSHIP_ID, strAvailableSlot)
                            End If
                        Else
                            WriteLog(gcstrError, "No Slots Available for Ship_ID: " & strSHIP_ID)
                            bRefreshLog = True

                        End If

                    Else
                        Exit For
                    End If
                ElseIf strUserSelectedRow = gcstrY And (strRetro_Status = "A22" Or strRetro_Status = "D22" Or strRetro_Status = "A42" Or strRetro_Status = "D42") Then
                    iAdvances += 1
                    'send the msg23
                    SelectLineItemDetails(flxGrid4, x)
                    If bUserPrompt = True Then
                        ULStageOrDestageAdvance(False, True)   'in this case we want to auto process records without askign user but log
                    Else
                        ULStageOrDestageAdvance(False, False)
                    End If

                ElseIf strUserSelectedRow = gcstrY And (strRetro_Status = "A24" Or strRetro_Status = "A44") And strLoad_Status = gcstrMsg20CancelText Then
                    iAdvances += 1
                    ' SendMsg22("D22", strSHIP_ID, strSlot)
                    If bUserPrompt = True Then
                        WriteLog(gcstrINFO, "Already Advanced: " & strSHIP_ID)
                    End If

                ElseIf bUserPrompt = True And strUserSelectedRow = gcstrY Then
                    WriteLog(gcstrINFO, "Status Not Applicable or Already Advanced: " & strSHIP_ID)
                    bRefreshLog = True
                End If

            Next

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

        End Try
    End Sub



    Private Sub butMsg21_Detail_Advance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21_Detail_Advance.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid8) = False Then Exit Sub
        'send msg23 unit load staged or destaged
        ULStageOrDestageAdvance(True, True)
    End Sub

    Private Sub ULStageOrDestageAdvance(ByVal bUserPrompt As Boolean, ByVal bProvideLogging As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim strSHIP_ID As String = String.Empty
        Dim iAdvances As Integer = 0
        Dim strSlot As String
        Dim strPAL_TYPE As String
        Dim strBRAND_CODE As String
        Dim strCODE_DATE As String
        Dim strULID As String
        Dim strLINE_ID As String
        Dim strSEQUENCE As String
        Dim bStopStageAfterNextMsg23 As Boolean
        Dim strDisposition As String
        Dim bDestageShipment As Boolean = False
        Dim bStopStagingFutureULs As Boolean
        Dim strRetroStatus As String
        Dim strQaStatus As String


        Try

            If lblRaid_SelectedLoadStatus.Text = gcstrMsg26StopText Then
                WriteLog(gcstrINFO, "Can't Stage - Staging Already Stopped" & strSHIP_ID)
                Exit Sub
            ElseIf lblRaid_SelectedLoadStatus.Text = "STG1THENSTOP" Then
                'ok to send just 1 more pallet
                bStopStageAfterNextMsg23 = True

            ElseIf lblRaid_SelectedLoadStatus.Text = gcstrMsg20CancelText Then
                'destage via Msg D23
                bDestageShipment = True

            Else
                'proceed normally
            End If

            If bUserPrompt = True Then

                shMsgbox = MsgBox("Send ShipULStaged/ProdOrderULStaged for Selected Customer IDs (s) ?", MsgBoxStyle.YesNo, "Confirm Message Processing")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                'dont have to get data 
                ProcessGridSelectAll(flxGrid8)
            End If

            For x = 1 To flxGrid8.Rows - 1

                If flxGrid8.get_TextMatrix(x, 0) = gcstrY Then
                    iAdvances += 1


                    If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then

                        'send the msg 23
                        strSHIP_ID = lblRaid_SelectedShipidDisplay.Text
                        strSlot = txtlblRaid_Msg23_SelectedSlot.Text
                        strDisposition = lblRaid_Msg23_SelectedDisposition.Text
                        strLINE_ID = Trim(flxGrid8.get_TextMatrix(x, 1))
                        strSEQUENCE = Trim(flxGrid8.get_TextMatrix(x, 2))
                        strBRAND_CODE = Trim(flxGrid8.get_TextMatrix(x, 3))
                        strCODE_DATE = Trim(flxGrid8.get_TextMatrix(x, 4))
                        strPAL_TYPE = Trim(flxGrid8.get_TextMatrix(x, 5))
                        strULID = Trim(flxGrid8.get_TextMatrix(x, 8))
                        strRetroStatus = Trim(flxGrid8.get_TextMatrix(x, 9))
                        strQaStatus = Trim(flxGrid8.get_TextMatrix(x, 10))

                        If bDestageShipment = True Then
                            If strULID.Length > 0 And strULID <> "-1" Then
                                'UL needs to be destaged
                                DestageUL(strSHIP_ID, strLINE_ID, strULID, strSlot, strBRAND_CODE, strRetroStatus)
                            Else
                                If bProvideLogging = True Then
                                    WriteLog(gcstrINFO, "Selected Line Item Doesn't Have UL Assigned - Shipid :" &
                                             strSHIP_ID & " Line Item: " & strLINE_ID)
                                End If
                            End If
                        Else
                            'need to check if the slot can fir more ULS in
                            If StagedUlsforShipId(strSHIP_ID) < giMaxUnitLoadsPerSlot Then
                                lblSlotMaxAlarm.Visible = False
                                bStopStagingFutureULs = StageUL(strSHIP_ID, strSlot, strULID, strPAL_TYPE, strBRAND_CODE, strCODE_DATE, strLINE_ID, strSEQUENCE, bStopStageAfterNextMsg23, strQaStatus, strRetroStatus, bProvideLogging)
                                If bStopStagingFutureULs = True Then
                                    Exit For
                                End If
                            Else
                                lblSlotMaxAlarm.Visible = True
                                'can't fint any more ULs into the slot
                                If bProvideLogging = True Then
                                    WriteLog(gcstrINFO, "Slot " & strSlot & " is full can't stage more ULs for " & strSHIP_ID)
                                End If
                            End If
                        End If

                    End If

                End If


            Next

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

            If bUserPrompt = True Then
                ' GetAndDisplayASRSInfeedData()
            End If

        End Try
    End Sub
    Private Sub DestageUL(ByVal strShip_Id As String, ByVal strLINE_ID As String, ByVal strULID As String, ByVal strActivOutPutLocation As String,
                          ByVal strBrandCode As String, ByVal strCurrentRetroStatus As String)

        Dim strRetro_Status As String

        If strCurrentRetroStatus = "43" Then
            strRetro_Status = "D43"
        Else
            strRetro_Status = "D23"
        End If

        Try
            If SendRequest(CreateXML_ShipULDestaged(strRetro_Status, String.Empty, strULID, strActivOutPutLocation, String.Empty, String.Empty,
                                            strBrandCode, String.Empty)) = True Then

                'update the line_item table     indicate that the pallet was destaged with the D23
                Update_CUST_LINEITEM_AfterStaging(strShip_Id, strLINE_ID, String.Empty, strRetro_Status, "0")

                'set the status of the UL back to 7 indicatign that it has been inducted and can be reused and the shipid cleared
                Update_CUST_PALLET_AfterStaging(strULID, String.Empty, gstrASRSSystemLocationName, "7")
            Else
                WriteLog(gcstrError, strRetro_Status & " Failed for ULID " & strULID & " Shipid " & strShip_Id & " Slot " & strActivOutPutLocation & " Database Update Skipped")

            End If

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub
    Private Function StageUL(ByVal strShip_Id As String, ByVal strSlot As String, ByVal strULID As String, ByVal strPAL_TYPE As String,
                            ByVal strBRAND_CODE As String, ByVal strCODE_DATE As String, ByVal strLINE_ID As String,
                            ByVal strSequence As String, ByVal bStopStageAfterNextMsg23 As Boolean,
                            ByVal strQaStatus As String, ByVal strCurrent_Retro_Status As String, ByVal bManualAadvance As Boolean) As Boolean

        Dim bCancelULLineItem As Boolean
        Dim strACTIV_LEVELforCurrentStagingULID As String
        Dim bStageUl As Boolean = False
        Dim strRetro_Status As String
        Dim structCust_Pallet As Cust_pallet
        Dim bMsgSendSuccess As Boolean

        StageUL = False

        Try

            If strCurrent_Retro_Status = "41" Then
                strRetro_Status = "A43"
            Else
                strRetro_Status = "A23"
            End If

            'determine if a ul is staged or if one can be found to stage
            bStageUl = False
            bCancelULLineItem = False
            If strULID.Length = 0 Then
                'dave need to populate withraw flag from the header?
                structCust_Pallet = FindULforShipid(String.Empty, strPAL_TYPE, strBRAND_CODE, strCODE_DATE, strQaStatus)

                If structCust_Pallet.strCust_ID = "-1" Then
                    'could not find UL to stage
                    If lblRaid_Msg23_SelectedDisposition.Text.ToUpper = "SW" Then
                        'query for any pallet type
                        structCust_Pallet = FindULforShipid(String.Empty, String.Empty, strBRAND_CODE, strCODE_DATE, strQaStatus)
                        If structCust_Pallet.strCust_ID = "-1" Then

                            bCancelULLineItem = True
                            WriteLog("Info", "No Inventory for " &
                                     "|ShipId:" & strShip_Id &
                                     "|Brand:" & strBRAND_CODE &
                                     "|Pal: Stage Any " &
                                     "|CodDat:" & strCODE_DATE &
                                     "|QaStatus:" & strQaStatus &
                                     "|")

                        Else
                            'UL was not staged and a UL was found on a differing pallet type and SW selected
                            bStageUl = True
                            WriteLog("Info", "Shipment with Disposition SW Staged Different Pallet Type  " &
                                     "|ShipId:" & strShip_Id &
                                     "|Brand:" & strBRAND_CODE &
                                     "|Pal: Stage Any " &
                                     "|CodDat:" & strCODE_DATE &
                                     "|QaStatus:" & strQaStatus &
                                     "|")

                            strULID = structCust_Pallet.strCust_ID
                            strPAL_TYPE = structCust_Pallet.strPallet_Type

                        End If
                    Else

                        Select Case lblRaid_Msg23_SelectedDisposition.Text.ToUpper
                            Case "SO"

                                WriteLog("Info", "Stage Open - No Inventory for " &
                                            "|ShipId:" & strShip_Id &
                                            "|Brand:" & strBRAND_CODE &
                                            "|Pal:" & strPAL_TYPE &
                                            "|CodDat:" & strCODE_DATE &
                                            "|QaStatus:" & strQaStatus &
                                            "|")
                            Case "SS"

                                WriteLog("Info", "Cancel CUST_LINEITEM  - Stage Short - No Inventory for " &
                                            "|ShipId:" & strShip_Id &
                                            "|Brand:" & strBRAND_CODE &
                                            "|Pal:" & strPAL_TYPE &
                                            "|CodDat:" & strCODE_DATE &
                                            "|QaStatus:" & strQaStatus &
                                            "|")
                                Update_CUST_LINEITEM_AfterStaging(strShip_Id, strLINE_ID, "-1", strRetro_Status, "0")

                            Case Else  'normal disposition

                                WriteLog("Info", "Normal Disposition - No Inventory for " &
                                            "|ShipId:" & strShip_Id &
                                            "|Brand:" & strBRAND_CODE &
                                            "|Pal:" & strPAL_TYPE &
                                            "|CodDat:" & strCODE_DATE &
                                            "|QaStatus:" & strQaStatus &
                                            "|")
                        End Select
                    End If
                Else
                    'UL was not staged and a UL was found
                    bStageUl = True
                    strULID = structCust_Pallet.strCust_ID
                    strCODE_DATE = structCust_Pallet.Code_Date
                End If
            Else
                'UL already staged for this line item
                If bManualAadvance = True Then
                    'let user know
                    WriteLog(gcstrINFO, strULID & " Already Staged for Shipid " & strShip_Id & " Seq " & strSequence)
                End If
            End If


            If bStageUl = True Then

                strACTIV_LEVELforCurrentStagingULID = FindThenSetNextActivLevelIDforShipid(strShip_Id)

                If strRetro_Status = "A43" Then
                    bMsgSendSuccess = SendRequest(CreateXML_ProdULStaged(strRetro_Status, strShip_Id, strULID, strSlot, strACTIV_LEVELforCurrentStagingULID,
                                                 strPAL_TYPE, strBRAND_CODE, strCODE_DATE, strSequence))
                Else

                    bMsgSendSuccess = SendRequest(CreateXML_ShipULStaged(strRetro_Status, strShip_Id, strULID, strSlot, strACTIV_LEVELforCurrentStagingULID,
                                                   strPAL_TYPE, strBRAND_CODE, strCODE_DATE, strSequence))
                End If
                If bMsgSendSuccess = True Then
                    Update_CUST_LINEITEM_AfterStaging(strShip_Id, strLINE_ID, strULID, Strings.Right(strRetro_Status, 2), "1")

                    Update_CUST_PALLET_AfterStaging(strULID, strShip_Id, strSlot & strACTIV_LEVELforCurrentStagingULID, Strings.Right(strRetro_Status, 2))

                    If bStopStageAfterNextMsg23 = True Then
                        Update_CUST_SHIPMENT_Single_Field(strShip_Id, "LOAD_STATUS", gcstrMsg26StopText)
                        WriteLog(gcstrINFO, "Stopped after Staging 1 More UL: " & strShip_Id)
                        StageUL = True
                    End If

                Else
                    WriteLog(gcstrError, "Msg " & strRetro_Status & " Failed for ULID " & strULID & " Shipid " & strShip_Id & " Slot " & strSlot & " Database Update Skipped")

                End If

            End If



        Catch


            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Function
    Private Sub flxGrid8_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid8.MouseDownEvent
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub

    Private Sub butMsg21AutoSendOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21AutoSendOff.Click
        Msg21AutoSendOff()
    End Sub

    Private Sub butMsg21AutoSendOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21AutoSendOn.Click
        Msg21AutoSendOn()
    End Sub

    Private Sub butMsg21_Send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21_Send.Click
        SendMsg21()
    End Sub

    Private Sub butMsg22AutoSendOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg22AutoSendOff.Click
        Msg22AutoSendOff()
    End Sub

    Private Sub butMsg22AutoSendOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg22AutoSendOn.Click

        Msg22AutoSendOn()

    End Sub



    Private Sub butMsg21_Detail_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21_Detail_GetData.Click
        GetandDisplayMsg21DetailData(lblRaid_SelectedShipidDisplay.Text)
    End Sub

    Private Sub FillShipment_Cust_LineItem_Aggregate()
        Dim strSQL As String
        Try

            strSQL = "select L.SHIP_ID, S.SLOT, S.RETRO_STATUS, S.LOAD_STATUS, S.SIGNON, S.DISPOSITION, S.SHIP_TYPE, " &
                "sum(L.QUANTITY) AS SUMofQuantity ,  " &
                "sum(L.STAGED) AS SUMofStaged  " &
                "from CUST_LINEITEM L, CUST_SHIPMENT S " &
                "where " &
                "L.SHIP_ID=S.CUST_SHIPMENT " &
                "and S.SHIP_TYPE in ('SR','CR') " &
                 "group by L.SHIP_ID, S.SLOT,S.RETRO_STATUS, S.LOAD_STATUS,S.SIGNON,S.DISPOSITION, S.SHIP_TYPE " &
                "order by L.SHIP_ID  asc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Shipment_Cust_LineItem_Aggregate_RecordCount = 0
            ReDim Shipment_Cust_LineItem_Aggregate(0)

            Do Until dbrec1.EOF

                Shipment_Cust_LineItem_Aggregate_RecordCount += 1
                ReDim Preserve Shipment_Cust_LineItem_Aggregate(Shipment_Cust_LineItem_Aggregate_RecordCount)

                With Shipment_Cust_LineItem_Aggregate(Shipment_Cust_LineItem_Aggregate_RecordCount)
                    .SHIP_ID = Convert.ToString(dbrec1.Fields("SHIP_ID").Value)
                    .Slot = Convert.ToString(dbrec1.Fields("SLOT").Value)
                    .QUANTITY = Convert.ToString(dbrec1.Fields("SUMofQuantity").Value)
                    .STAGED = Convert.ToString(dbrec1.Fields("SUMofStaged").Value)
                    .RETRO_STATUS = Convert.ToString(dbrec1.Fields("RETRO_STATUS").Value)
                    .Load_Status = Convert.ToString(dbrec1.Fields("LOAD_STATUS").Value)
                    .Signon = Convert.ToString(dbrec1.Fields("SIGNON").Value)
                    .Disposition = Convert.ToString(dbrec1.Fields("DISPOSITION").Value)
                    .Ship_type = Convert.ToString(dbrec1.Fields("SHIP_TYPE").Value)

                    '  .WITHDRAWAL_INTENT_CODE = Convert.ToString(dbrec1.Fields("WITHDRAWAL_INTENT_CODE").Value)

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub butMsg24_Header_DeSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg24_Header_DeSelectAll.Click
        ProcessGridDeSelectAll(flxGrid9)
    End Sub

    Private Sub butMsg24_Header_SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg24_Header_SelectAll.Click
        ProcessGridSelectAll(flxGrid9)
    End Sub

    Private Sub butMsg24Advance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg24Advance.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid9) = False Then Exit Sub
        StageCompleteAdvance(True)
    End Sub

    Private Sub DisplayShipmentCust_LineItem_Aggregate()
        Dim x As Integer
        Dim y As Integer
        Dim bCompletelyStaged As Boolean

        Try
            flxGrid9.Rows = 1
            flxGrid9.Rows = 2
            flxGrid9.Cols = 10
            flxGrid9.Row = 0
            For y = 1 To flxGrid9.Cols
                flxGrid9.Col = y - 1
                flxGrid9.Text = vbNullString

                Select Case flxGrid9.Col

                    Case 0, 2, 3, 9
                        flxGrid9.set_ColWidth(flxGrid9.Col, 500)

                    Case 4, 5, 6, 7, 8
                        flxGrid9.set_ColWidth(flxGrid9.Col, 800)


                    Case Else
                        flxGrid9.set_ColWidth(flxGrid9.Col, 1000)

                End Select

            Next

            flxGrid9.Redraw = False

            flxGrid9.Rows = 2
            flxGrid9.Row = 0

            flxGrid9.Col = 0
            flxGrid9.Text = "Sel"
            flxGrid9.Col = 1
            flxGrid9.Text = "ShipID"
            flxGrid9.Col = 2
            flxGrid9.Text = "Disp"
            flxGrid9.Col = 3
            flxGrid9.Text = "Slot"
            flxGrid9.Col = 4
            flxGrid9.Text = "QTY"
            flxGrid9.Col = 5
            flxGrid9.Text = "Staged"
            flxGrid9.Col = 6
            flxGrid9.Text = "R_Stat"
            flxGrid9.Col = 7
            flxGrid9.Text = "L_Stat"
            flxGrid9.Col = 8
            flxGrid9.Text = "SignOn"
            flxGrid9.Col = 9
            flxGrid9.Text = "Typ"



            For x = 1 To Shipment_Cust_LineItem_Aggregate_RecordCount

                flxGrid9.Row += 1

                flxGrid9.Col = 1
                flxGrid9.CellBackColor = colorBack
                flxGrid9.CellForeColor = colorFore
                flxGrid9.Text = vbNullString & Shipment_Cust_LineItem_Aggregate(x).SHIP_ID

                flxGrid9.Col = 2
                flxGrid9.CellBackColor = colorBack
                flxGrid9.CellForeColor = colorFore
                flxGrid9.Text = vbNullString & Shipment_Cust_LineItem_Aggregate(x).Disposition

                flxGrid9.Col = 3
                flxGrid9.CellBackColor = colorBack
                flxGrid9.CellForeColor = colorFore
                flxGrid9.Text = vbNullString & Shipment_Cust_LineItem_Aggregate(x).Slot

                bCompletelyStaged = False
                If Shipment_Cust_LineItem_Aggregate(x).QUANTITY = Shipment_Cust_LineItem_Aggregate(x).STAGED Then
                    bCompletelyStaged = True
                End If

                flxGrid9.Col = 4

                If bCompletelyStaged = False Then
                    flxGrid9.CellBackColor = colorBack
                    flxGrid9.CellForeColor = colorFore
                Else
                    flxGrid9.CellBackColor = Color.Green
                    flxGrid9.CellForeColor = Color.White
                End If
                flxGrid9.Text = vbNullString & Shipment_Cust_LineItem_Aggregate(x).QUANTITY

                flxGrid9.Col = 5
                If bCompletelyStaged = False Then
                    flxGrid9.CellBackColor = colorBack
                    flxGrid9.CellForeColor = colorFore
                Else
                    flxGrid9.CellBackColor = Color.Green
                    flxGrid9.CellForeColor = Color.White
                End If
                flxGrid9.Text = vbNullString & Shipment_Cust_LineItem_Aggregate(x).STAGED

                flxGrid9.Col = 6
                flxGrid9.CellBackColor = colorBack
                flxGrid9.CellForeColor = colorFore
                flxGrid9.Text = vbNullString & Shipment_Cust_LineItem_Aggregate(x).RETRO_STATUS

                flxGrid9.Col = 7
                flxGrid9.CellBackColor = colorBack
                flxGrid9.CellForeColor = colorFore
                flxGrid9.Text = vbNullString & Shipment_Cust_LineItem_Aggregate(x).Load_Status

                flxGrid9.Col = 8

                If bCompletelyStaged = False Then
                    flxGrid9.CellBackColor = colorBack
                    flxGrid9.CellForeColor = colorFore
                ElseIf Shipment_Cust_LineItem_Aggregate(x).Signon <> "Y" Then
                    flxGrid9.CellBackColor = Color.Yellow
                    flxGrid9.CellForeColor = colorFore
                Else
                    flxGrid9.CellBackColor = Color.Green
                    flxGrid9.CellForeColor = Color.White
                End If

                flxGrid9.Text = vbNullString & Shipment_Cust_LineItem_Aggregate(x).Signon

                flxGrid9.Col = 9
                flxGrid9.CellBackColor = colorBack
                flxGrid9.CellForeColor = colorFore
                flxGrid9.Text = vbNullString & Shipment_Cust_LineItem_Aggregate(x).Ship_type

                flxGrid9.Rows += 1



            Next


            'remove last blank row
            flxGrid9.Rows -= 1
            flxGrid9.Col = 0
            DisplayGridRowCount(butMsg24_Header_SelectAll, flxGrid9)
            ' flxGrid9.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid9.Redraw = True

        End Try
    End Sub

    Private Sub butMsg24_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg24_GetData.Click
        GetAndDisplayMsg24Data()
    End Sub

    Private Sub GetAndDisplayMsg24Data()
        FillShipment_Cust_LineItem_Aggregate()
        DisplayShipmentCust_LineItem_Aggregate()
        SelectSlotForUnitLoadRemoval(flxGrid9, 0)
    End Sub

    Private Sub StageCompleteAdvance(ByVal bUserPrompt As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim strSHIP_ID As String
        Dim iAdvances As Integer = 0
        Dim strRetro_Status As String = "24"  '13 SENT
        Dim strLoad_Status As String
        Dim strGrid_Retro_Status As String
        Dim strSlot As String
        Dim bCompletelyStaged As Boolean
        Dim bAdvanceThisShipment As Boolean
        Dim strSlotSignOn As String
        Dim strUserMessage As String = "Send Msg "
        Dim strMessage_type As String
        Dim strStagedQty As String

        Try

            If bUserPrompt = True Then

                shMsgbox = MsgBox(strUserMessage & "for Selected Shipid (s) ?", MsgBoxStyle.YesNo, "Confirm Msg Processing")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                GetAndDisplayMsg24Data()
                ProcessGridSelectAll(flxGrid9)
            End If

            For x = 1 To flxGrid9.Rows - 1
                bAdvanceThisShipment = False
                If flxGrid9.get_TextMatrix(x, 0) = gcstrY Then

                    If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then

                        strSHIP_ID = flxGrid9.get_TextMatrix(x, 1)
                        strSlot = flxGrid9.get_TextMatrix(x, 3)
                        strStagedQty = flxGrid9.get_TextMatrix(x, 5)
                        strGrid_Retro_Status = flxGrid9.get_TextMatrix(x, 6)
                        strLoad_Status = flxGrid9.get_TextMatrix(x, 7)
                        strSlotSignOn = flxGrid9.get_TextMatrix(x, 8)

                        bCompletelyStaged = flxGrid9.get_TextMatrix(x, 4) = flxGrid9.get_TextMatrix(x, 5)
                        If bCompletelyStaged = False Then
                            'check if potentially the shipment had been staged short and there are no other line items existing
                            'this is needed in auto mode otherwise shipment wont advance
                            'DAVE TODOT
                        End If

                        If bUserPrompt = True Then
                            If bCompletelyStaged = False And strLoad_Status <> gcstrMsg20CancelText Then
                                shMsgbox = MsgBox("Shipment Not Completely Staged.  Still Send Msg24/44 for Shipment " & strSHIP_ID & " ?", MsgBoxStyle.YesNo, "Confirm Msg Processing")

                                If shMsgbox = MsgBoxResult.Yes Then
                                    bAdvanceThisShipment = True
                                End If

                            End If
                        End If


                        strMessage_type = String.Empty
                        If strGrid_Retro_Status <> "A24" And strGrid_Retro_Status <> "D24" And
                                strGrid_Retro_Status <> "A44" And strGrid_Retro_Status <> "D44" Then
                            If bAdvanceThisShipment = True Or bCompletelyStaged = True Or strLoad_Status = gcstrMsg26StopText Then
                                If strGrid_Retro_Status = "A22" Or strGrid_Retro_Status = "21" Then
                                    strMessage_type = "A24"
                                ElseIf strGrid_Retro_Status = "A42" Or strGrid_Retro_Status = "41" Then
                                    strMessage_type = "A44"
                                Else
                                    WriteLog(gcstrError, strGrid_Retro_Status & " Retro_Status -  Unexpected Message Status")

                                End If
                            End If

                            SelectSlotForUnitLoadRemoval(flxGrid9, x)
                            If lblRaid_SelectedLoadStatus_Msg24.Text = gcstrMsg20CancelText And strGrid_Retro_Status <> "DESTAGED" Then

                                If flxGrid10.Rows <= 1 Then
                                    'no ULS in slot
                                    If strGrid_Retro_Status = "D22" Then
                                        strMessage_type = "D24"
                                    ElseIf strGrid_Retro_Status = "D42" Then
                                        strMessage_type = "D44"
                                    End If

                                End If
                            End If


                            'so the current staging or destaging is in progress so now complete it
                            If strMessage_type.Length > 0 Then

                                iAdvances += 1
                                'do the advance
                                If strMessage_type = "D24" Then
                                    If SendRequest(CreateXML_ShipDestageComplete(strMessage_type, strSlot)) = True Then
                                        Update_CUST_SHIPMENT(strSHIP_ID, "DESTAGED", String.Empty)
                                    Else
                                        WriteLog(gcstrError, strMessage_type & " Failed for Slot " & strSlot & " Database Update Skipped")

                                    End If
                                ElseIf strMessage_type = "D44" Then
                                    If SendRequest(CreateXML_ProdOrderDestageComplete(strMessage_type, strSlot)) = True Then
                                        Update_CUST_SHIPMENT(strSHIP_ID, "DESTAGED", String.Empty)
                                    Else
                                        WriteLog(gcstrError, strMessage_type & " Failed for Slot " & strSlot & " Database Update Skipped")
                                    End If
                                ElseIf strMessage_type = "A24" Then
                                    If SendRequest(CreateXML_ShipStageComplete(strMessage_type, strSHIP_ID, strSlot)) = True Then
                                        Update_CUST_SHIPMENT(strSHIP_ID, strMessage_type, strSlot)
                                    Else
                                        WriteLog(gcstrError, strMessage_type & " Failed for Shipid " & strSHIP_ID & " Slot " & strSlot & " Database Update Skipped")

                                    End If
                                ElseIf strMessage_type = "A44" Then
                                    If SendRequest(CreateXML_ProdOrderStageComplete(strMessage_type, strSHIP_ID, strSlot)) = True Then
                                        Update_CUST_SHIPMENT(strSHIP_ID, strMessage_type, strSlot)
                                    Else
                                        WriteLog(gcstrError, strMessage_type & " Failed for Shipid " & strSHIP_ID & " Slot " & strSlot & " Database Update Skipped")

                                    End If
                                End If
                            End If

                        End If

                        'reworked this below  20140829
                        'If bUserPrompt = False And strGrid_Retro_Status = "A24" And strSlotSignOn = gcstrY Then
                        ''send the msg15s
                        'SelectSlotForUnitLoadRemoval(flxGrid9, x)
                        'Msg15Advance(False)

                        'If flxGrid10.Rows > 1 Then

                        'Else
                        '   'dave what to do   ???
                        'End If

                        'End If

                        'the current status is already complete
                        'in auto mode select all the associated ULs and ship them out of ASRS
                        'in manual mode tell the user that they foobared and that they need to be usind UL Removal to send
                        'the ShipULPickup
                        If strGrid_Retro_Status = "A24" Or strGrid_Retro_Status = "A44" Then
                            If strSlotSignOn = gcstrY Then
                                If bUserPrompt = False Then
                                    'send the msg15s
                                    SelectSlotForUnitLoadRemoval(flxGrid9, x)
                                    Msg15Advance(False)
                                Else
                                    WriteLog(gcstrINFO, "Shipid " & strSHIP_ID & " Staging and SignOn Already Completed, Use UL Removal to Advance")
                                End If
                            Else
                                'in manual send mode let user know they need to slot sign on!
                                If bUserPrompt = True Then
                                    WriteLog(gcstrINFO, "Shipid " & strSHIP_ID & " Needs Slot Sign On then Use UL Removal to Advance")
                                End If

                            End If
                        End If

                        'user wants to destage
                        If strSlotSignOn = "U" And (strGrid_Retro_Status = "A24" Or strGrid_Retro_Status = "A44") Then
                            'Send D22 for A24 or D42 for A44
                            SendMsg22("D" & Strings.Mid(strGrid_Retro_Status, 2, 1) & "2", strSHIP_ID, strSlot)
                        End If

                        If bUserPrompt = True And strGrid_Retro_Status = "DESTAGED" Then
                            'cant advance beyond this - ready to purge!
                            WriteLog(gcstrINFO, "Shipid " & strSHIP_ID & " Already Destaged - No Action Performed")


                        End If

                    Else
                        Exit For
                    End If

                End If
            Next

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

        End Try
    End Sub

    Private Sub flxGrid9_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles flxGrid9.HandleDestroyed

    End Sub

    Private Sub flxGrid9_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid9.MouseDownEvent
        Dim iRowSel As Integer
        Dim iColSel As Integer

        Dim oGrid As AxMSFlexGrid
        oGrid = CType(sender, AxMSFlexGrid)


        iRowSel = oGrid.MouseRow
        iColSel = oGrid.MouseCol

        'first row is header row
        If iRowSel = 0 Then Exit Sub

        If e.button = 2 Then
            'Save to clipboard 
            Clipboard.SetDataObject(Trim(oGrid.get_TextMatrix(iRowSel, iColSel)))
        Else
            If iColSel = 1 Then
                HighlightGridRow(flxGrid9, iRowSel, iColSel)
                SelectSlotForUnitLoadRemoval(oGrid, iRowSel)
            Else
                If iColSel = 0 Then
                    HighlightGridRow(flxGrid9, iRowSel, iColSel)
                    SelectSlotForUnitLoadRemoval(oGrid, iRowSel)
                End If
                ProcessGridMouseDown(oGrid, e.button)
            End If
        End If

    End Sub


    Private Sub Msg24AutoSendOff()
        AutoScanOff(butMsg24AutoSendOn, butMsg24AutoSendOff)
    End Sub

    Private Sub butMsg24AutoSendOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg24AutoSendOn.Click
        AutoScanOn(butMsg24AutoSendOn, butMsg24AutoSendOff)
    End Sub

    Private Sub butMsg24AutoSendOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg24AutoSendOff.Click
        Msg24AutoSendOff()
    End Sub

    Private Sub OutboundStagingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutboundStagingToolStripMenuItem.Click
        OpenIniFileSection(gcstrIniOutbound)
    End Sub

    Private Sub OpenIniFileSection(ByVal strSection As String)
        ShowIniForm(gcstrIniOutbound)
    End Sub

    Private Sub flxGrid10_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid10.MouseDownEvent
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub

    Private Sub SelectSlotForUnitLoadRemoval(ByVal oGrid As AxMSFlexGrid, ByVal iRowSel As Integer)

        Dim strShipId As String
        Dim strSlotSignOn As String
        Try
            If oGrid.Rows <= 1 Or iRowSel = 0 Then
                strShipId = "-1"
                lblRaidMsg15ShipId.Text = String.Empty
                lblRaid_SelectedLoadStatus_Msg24.Text = String.Empty
                lblRaid_SelectedRetroStatus_Msg24.Text = String.Empty
                strSlotSignOn = String.Empty
            Else

                strShipId = Trim(oGrid.get_TextMatrix(iRowSel, 1))
                lblRaidMsg15ShipId.Text = strShipId
                strSlotSignOn = Trim(oGrid.get_TextMatrix(iRowSel, 8))
                lblRaid_SelectedRetroStatus_Msg24.Text = Trim(oGrid.get_TextMatrix(iRowSel, 6))
                lblRaid_SelectedLoadStatus_Msg24.Text = Trim(oGrid.get_TextMatrix(iRowSel, 7))
            End If

            'dont allow the user to stage ULS until the Msg22 has been sent
            If strSlotSignOn = gcstrY Then
                butMsg15Advance.Enabled = True
            ElseIf Trim(oGrid.get_TextMatrix(iRowSel, 9)) = gcstrPORequest Then
                'customization requests dont use slot sign on - already indexed forward like manual withdraws
                butMsg15Advance.Enabled = True
            Else

                butMsg15Advance.Enabled = False
            End If

            GetandDisplayULRemovalData(strShipId)

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub butMsg15SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg15SelectAll.Click
        ProcessGridSelectAll(flxGrid10)
    End Sub

    Private Sub butMsg15DeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg15DeselectAll.Click
        ProcessGridSelectAll(flxGrid10)
    End Sub
    Private Sub GetandDisplayULRemovalData(ByVal strShipId As String)
        FillMsg15_Detail(strShipId)
        DisplayMsg15_Detail()
    End Sub
    Private Sub FillMsg15_Detail(ByVal strShipid As String)
        Dim strSQL As String
        Try

            strSQL = "select L.LINE_ID,L.SEQUENCE,L.BRAND_CODE, L.CODE_DATE, L.PAL_TYPE, L.STAGED, L.CUST_ID, P.RETRO_LOC,P.PALLET_TYPE as CUST_PALLET_TYPE " &
                "from CUST_LINEITEM L, CUST_PALLET P " &
                "where " &
                "L.CUST_ID=P.CUST_ID " &
                "and L.cust_id is not null " &
                "and L.SHIP_ID= '" & strShipid & "' " &
                "order by L.LINE_ID, L.SEQUENCE,L.BRAND_CODE  asc"

            Msg15_Detail_RecordCount = 0
            ReDim Msg15_DEtail(0)

            If dbrec1.State = 1 Then
                WriteLog(gcstrINFO, GetCurrentMethod.Name() & " Skipped as RS was open")
                Exit Sub
            End If

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)


            Msg15_Detail_RecordCount = 0
            ReDim Msg15_DEtail(0)

            Do Until dbrec1.EOF

                Msg15_Detail_RecordCount += 1
                ReDim Preserve Msg15_DEtail(Msg15_Detail_RecordCount)

                With Msg15_DEtail(Msg15_Detail_RecordCount)
                    .LINE_ID = Convert.ToString(dbrec1.Fields("LINE_ID").Value)
                    .SEQUENCE = Convert.ToString(dbrec1.Fields("SEQUENCE").Value)
                    .BRAND_CODE = Convert.ToString(dbrec1.Fields("BRAND_CODE").Value)
                    .CODE_DATE = Convert.ToString(dbrec1.Fields("CODE_DATE").Value)
                    .PAL_TYPE = Convert.ToString(dbrec1.Fields("PAL_TYPE").Value)
                    .STAGED = Convert.ToString(dbrec1.Fields("STAGED").Value)
                    .CUST_ID = Convert.ToString(dbrec1.Fields("CUST_ID").Value)
                    .Retro_Loc = Convert.ToString(dbrec1.Fields("RETRO_LOC").Value)
                    .StagedPalletType = Convert.ToString(dbrec1.Fields("CUST_PALLET_TYPE").Value)
                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub DisplayMsg15_Detail()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid10.Rows = 1
            flxGrid10.Rows = 2
            flxGrid10.Cols = 11
            flxGrid10.Row = 0
            For y = 1 To flxGrid10.Cols
                flxGrid10.Col = y - 1
                flxGrid10.Text = vbNullString

                Select Case flxGrid10.Col

                    Case 0, 1, 2
                        flxGrid10.set_ColWidth(flxGrid10.Col, 500)
                    Case 4
                        flxGrid10.set_ColWidth(flxGrid10.Col, 1200)
                    Case 5, 6
                        flxGrid10.set_ColWidth(flxGrid10.Col, 750)
                    Case 7
                        flxGrid10.set_ColWidth(flxGrid10.Col, 0)

                    Case 8
                        flxGrid10.set_ColWidth(flxGrid10.Col, 2000)

                    Case Else
                        flxGrid10.set_ColWidth(flxGrid10.Col, 1000)

                End Select

            Next

            flxGrid10.Redraw = False

            ' Initialize the Grid by defining the Details:
            flxGrid10.Rows = 2
            flxGrid10.Row = 0

            flxGrid10.Col = 0
            flxGrid10.Text = "Sel"
            flxGrid10.Col = 1
            flxGrid10.Text = "L#"
            flxGrid10.Col = 2
            flxGrid10.Text = "Seq"
            flxGrid10.Col = 3
            flxGrid10.Text = "Brand"
            flxGrid10.Col = 4
            flxGrid10.Text = "Coddat"
            flxGrid10.Col = 5
            flxGrid10.Text = "Paltyp"
            flxGrid10.Col = 6
            flxGrid10.Text = "StgPal"
            flxGrid10.Col = 7
            flxGrid10.Text = "Staged"   'hidden for now
            flxGrid10.Col = 8
            flxGrid10.Text = "CustID"
            flxGrid10.Col = 9
            flxGrid10.Text = "Loc"
            flxGrid10.Col = 10
            flxGrid10.Text = "Stat"


            For x = 1 To Msg15_Detail_RecordCount

                flxGrid10.Row += 1

                flxGrid10.Col = 1
                flxGrid10.CellBackColor = colorBack
                flxGrid10.CellForeColor = colorFore
                flxGrid10.Text = vbNullString & Msg15_DEtail(x).LINE_ID

                flxGrid10.Col = 2
                flxGrid10.CellBackColor = colorBack
                flxGrid10.CellForeColor = colorFore
                flxGrid10.Text = vbNullString & Msg15_DEtail(x).SEQUENCE

                flxGrid10.Col = 3
                flxGrid10.CellBackColor = colorBack
                flxGrid10.CellForeColor = colorFore
                flxGrid10.Text = vbNullString & Msg15_DEtail(x).BRAND_CODE

                flxGrid10.Col = 4
                flxGrid10.CellBackColor = colorBack
                flxGrid10.CellForeColor = colorFore
                flxGrid10.Text = vbNullString & Msg15_DEtail(x).CODE_DATE

                flxGrid10.Col = 5
                flxGrid10.CellBackColor = colorBack
                flxGrid10.CellForeColor = colorFore
                flxGrid10.Text = vbNullString & Msg15_DEtail(x).PAL_TYPE

                flxGrid10.Col = 6
                flxGrid10.CellBackColor = colorBack
                flxGrid10.CellForeColor = colorFore
                flxGrid10.Text = vbNullString & Msg15_DEtail(x).StagedPalletType

                flxGrid10.Col = 7
                flxGrid10.CellBackColor = colorBack
                flxGrid10.CellForeColor = colorFore
                flxGrid10.Text = vbNullString & Msg15_DEtail(x).STAGED

                flxGrid10.Col = 8
                flxGrid10.CellBackColor = colorBack
                flxGrid10.CellForeColor = colorFore
                flxGrid10.Text = vbNullString & Msg15_DEtail(x).CUST_ID

                flxGrid10.Col = 9
                flxGrid10.CellBackColor = colorBack
                flxGrid10.CellForeColor = colorFore
                flxGrid10.Text = vbNullString & Msg15_DEtail(x).Retro_Loc

                flxGrid10.Col = 10
                flxGrid10.CellBackColor = colorBack
                flxGrid10.CellForeColor = colorFore
                flxGrid10.Text = vbNullString & gcStrZero


                flxGrid10.Rows += 1

            Next

            'remove last blank row
            flxGrid10.Rows -= 1
            flxGrid10.Col = 0
            DisplayGridRowCount(butMsg15SelectAll, flxGrid10)
            ' flxGrid10.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid10.Redraw = True

        End Try
    End Sub

    Private Sub butMsg15Advance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg15Advance.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid10) = False Then Exit Sub
        Msg15Advance(True)
    End Sub

    Private Sub Msg15Advance(ByVal bUserPrompt As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim iAdvances As Integer = 0
        Dim strRetro_Status As String = "15"
        Dim strMsgTyp As String = "A15"
        Dim strLocation As String

        Dim strSHIP_ID As String = String.Empty
        Dim strACTIV_OUTPUT_LOCATION As String
        Dim strUNIT_LOAD_ID As String
        Dim strPALLET_TYPE As String
        Dim strBRAND_CODE As String
        Dim strCODE_DATE As String
        Dim strWITHDRAWAL_OUTPUT_STATUS As String
        Dim strACTIV_LEVEL_ID As String
        Dim bPurgeShipments As Boolean
        Dim strMessageName As String = "ShipULPickup"

        Try

            If bUserPrompt = True Then

                shMsgbox = MsgBox("Send " & strMessageName & " for Selected Ulid (s) ?", MsgBoxStyle.YesNo, "Confirm " & strMessageName & " Processing")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else

                ProcessGridSelectAll(flxGrid10)
            End If

            For x = 1 To flxGrid10.Rows - 1

                If flxGrid10.get_TextMatrix(x, 0) = gcstrY Then

                    If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then

                        strSHIP_ID = lblRaidMsg15ShipId.Text
                        strUNIT_LOAD_ID = flxGrid10.get_TextMatrix(x, 8)
                        strPALLET_TYPE = flxGrid10.get_TextMatrix(x, 5)
                        strBRAND_CODE = flxGrid10.get_TextMatrix(x, 3)
                        strCODE_DATE = flxGrid10.get_TextMatrix(x, 4)
                        strWITHDRAWAL_OUTPUT_STATUS = flxGrid10.get_TextMatrix(x, 10)
                        strACTIV_LEVEL_ID = Strings.Right(flxGrid10.get_TextMatrix(x, 9), 1)
                        strACTIV_OUTPUT_LOCATION = Strings.Left(flxGrid10.get_TextMatrix(x, 9), flxGrid10.get_TextMatrix(x, 9).Length - 1)
                        strLocation = flxGrid10.get_TextMatrix(x, 9)

                        If strLocation <> "SHIPPED" Then
                            iAdvances += 1
                            If SendRequest(CreateXML_ShipULPickup(strMsgTyp, strSHIP_ID, txtShipULPickUp_Load_Flag.Text, strACTIV_OUTPUT_LOCATION, strACTIV_LEVEL_ID,
                                        strUNIT_LOAD_ID, strPALLET_TYPE, strBRAND_CODE, strCODE_DATE, strWITHDRAWAL_OUTPUT_STATUS)) = True Then

                                Update_CUST_PALLET_AfterMsg15(strUNIT_LOAD_ID, "SHIPPED", "15")

                                'update the line_item table as well

                                Update_CUST_LINEITEM_AfterMsg15(strUNIT_LOAD_ID, "15")
                            Else
                                WriteLog(gcstrError, strMessageName & " Failed for ULID " & strUNIT_LOAD_ID & " Shipid " & strSHIP_ID & " Slot " & strACTIV_OUTPUT_LOCATION & " Database Update Skipped")

                            End If
                        ElseIf strLocation = "SHIPPED" Then
                            If bUserPrompt = True Then
                                WriteLog(gcstrINFO, strMessageName & " Already Sent for ULID " & strUNIT_LOAD_ID & " Shipid " & strSHIP_ID & " No Action Performed")

                            End If
                            bPurgeShipments = True

                        End If
                    Else
                        Exit For
                    End If

                End If
            Next

            If bPurgeShipments = True And lblRaid_SelectedRetroStatus_Msg24.Text = "A24" Then
                PurgeCompletedShipments(bUserPrompt, strSHIP_ID)
            End If

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

            If bUserPrompt = True Then
                ' GetAndDisplayASRSInfeedData()
            End If

        End Try
    End Sub

    Private Function FindThenSetNextActivLevelIDforShipid(ByVal strShipId As String) As String
        Dim strSql As String
        Dim iRecordsCount As Integer = 0
        Dim iRecords() As String
        Dim x As Integer
        Dim strNewLevelID As String

        Try

            strSql = "select NEXTLEVELID " &
                "from CUST_SHIPMENT " &
                "where " &
                 "CUST_SHIPMENT='" & strShipId & "' "

            ' Open the Recordset using the select string:
            dbrec1.Open(strSql, DBCON1)

            ReDim iRecords(0)

            Do Until dbrec1.EOF

                iRecordsCount += 1
                ReDim Preserve iRecords(iRecordsCount)

                iRecords(iRecordsCount) = Convert.ToString(dbrec1.Fields("NEXTLEVELID").Value)

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

            If iRecordsCount = 0 Then
                'shipid not found
                FindThenSetNextActivLevelIDforShipid = "-1"
            ElseIf iRecordsCount > 0 And iRecords(iRecordsCount).Length = 0 Then
                'shipid found but no level, assume starting level ID shoudl be returned
                FindThenSetNextActivLevelIDforShipid = ActivLevelIds(0)
            ElseIf iRecordsCount > 0 And iRecords(iRecordsCount).Length > 0 Then
                FindThenSetNextActivLevelIDforShipid = iRecords(1)
            Else
                FindThenSetNextActivLevelIDforShipid = "-1"
            End If

            If FindThenSetNextActivLevelIDforShipid <> "-1" Then
                'update the ship header for the next record

                For x = 0 To ActivLevelIdsRecordCount - 1   'zero based array
                    If FindThenSetNextActivLevelIDforShipid = ActivLevelIds(x) Then
                        If x < ActivLevelIdsRecordCount - 1 Then
                            strNewLevelID = ActivLevelIds(x + 1)
                        Else
                            strNewLevelID = ActivLevelIds(0)
                        End If

                        Update_CUST_SHIPMENT_Single_Field(strShipId, "NEXTLEVELID", strNewLevelID)
                    End If
                Next
            End If


        Catch ex As Exception
            FindThenSetNextActivLevelIDforShipid = "-1"
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Function

    Private Function FindShippedShipmentsToPurge() As String()
        Dim strSql As String
        Dim iRecordCount As Integer = 0
        Dim iRecord() As String

        Try

            strSql = "select SHIP_ID,CountLineItem,CountCustPallet,MinOfRETRO_LOC,MaxOfRETRO_LOC " &
                    "from ASRS_SHIPPED " &
                    "where " &
                    "CountLineItem=CountCustPallet " &
                    "and MinOfRETRO_LOC=MaxOfRETRO_LOC"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSql, DBCON1)

            ReDim iRecord(0)

            Do Until dbrec1.EOF

                iRecordCount += 1
                ReDim Preserve iRecord(iRecordCount)

                iRecord(iRecordCount) = Convert.ToString(dbrec1.Fields("SHIP_ID").Value)

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

            Return iRecord

        Catch ex As Exception
            ReDim iRecord(0)
            Return iRecord
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Function

    Private Function DeleteAllDataAssociatedWithShipID(ByVal strShipid As String) As Boolean
        Dim strSql As String

        DeleteAllDataAssociatedWithShipID = False

        Try

            strSql = "delete from cust_shipment where cust_shipment='" & strShipid & "'"
            DBCON1.Execute(strSql)

            strSql = "delete from cust_lineitem where ship_id='" & strShipid & "'"
            DBCON1.Execute(strSql)

            strSql = "delete from cust_pallet where ship_id='" & strShipid & "'"
            DBCON1.Execute(strSql)

            DeleteAllDataAssociatedWithShipID = True

        Catch ex As Exception
            DeleteAllDataAssociatedWithShipID = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Function

    Private Sub PurgeCompletedShipmentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurgeCompletedShipmentsToolStripMenuItem.Click

        PurgeCompletedShipments(True, String.Empty)

    End Sub
    Private Sub PurgeCompletedShipments(ByVal bPromptForDeletion As Boolean, ByVal strShipidForDescriptionPurposesOnly As String)
        Dim shMsgbox As MsgBoxResult
        Dim strtext As String = "Removed All Records Associated with Completed/Cancelled Shipments."
        Dim strAffectedRecords As String

        If strShipidForDescriptionPurposesOnly.Length > 0 Then
            strtext &= " including ShipID " & strShipidForDescriptionPurposesOnly

        End If

        If bPromptForDeletion = True Then
            shMsgbox = MsgBox("Ok to Purge ASRS Data for Shipments ASRS Ship Complete?", MsgBoxStyle.YesNo, "Confirm Data Deletion")

            If shMsgbox = Windows.Forms.DialogResult.No Then Exit Sub
        End If

        strAffectedRecords = DeleteCompletedShipments()

        'control what is logged - dont just repeat purged 0
        If bPromptForDeletion = True Then
            WriteLog(gcstrINFO, strtext & Space(1) & "Shipments Purged: " & strAffectedRecords)
        Else
            If CInt(strAffectedRecords) > 0 Then
                WriteLog(gcstrINFO, strtext & Space(1) & "Shipments Purged: " & strAffectedRecords)
            End If
        End If

    End Sub
    Private Sub PurgeCompletedWithdraws(ByVal bPromptForDeletion As Boolean)
        Dim shMsgbox As MsgBoxResult
        Dim strtext As String = "Removed All Records Associated with Completed/Cancelled Withdraws."
        Dim strAffectedRecords As String

        If bPromptForDeletion = True Then
            shMsgbox = MsgBox("Ok to Purge ASRS Data for Completed Manual Withdrawals?", MsgBoxStyle.YesNo, "Confirm Data Deletion")

            If shMsgbox = Windows.Forms.DialogResult.No Then Exit Sub
        End If

        strAffectedRecords = DeleteCompletedWithdraws()
        WriteLog(gcstrINFO, strtext & Space(1) & "Withdraws Purged: " & strAffectedRecords)

    End Sub
    Private Function DeleteCompletedWithdraws() As String
        Dim strSql As String
        Dim oRecordsAffected As Object = 0

        DeleteCompletedWithdraws = gcStrZero
        Try


            strSql = "delete  from cust_shipment where " &
                    "cust_shipment not in " &
                    "(select distinct ship_id from cust_lineitem where RETRO_STATUS not in ('14','14D') and cust_shipment like 'M%') " &
                    "and cust_shipment like 'M%'"

            DBCON1.Execute(strSql, oRecordsAffected)

            DeleteOrphaned_CustLineItem_CustPallet()


            DeleteCompletedWithdraws = oRecordsAffected.ToString

        Catch ex As Exception
            DeleteCompletedWithdraws = "-1"
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Function

    Private Function DeleteCompletedShipments() As String
        Dim strSql As String
        Dim oRecordsAffected As Object = 0

        DeleteCompletedShipments = gcStrZero
        Try

            strSql = "delete  from cust_shipment where " &
                    "cust_shipment not in " &
                    "(select distinct ship_id from cust_lineitem where staged is null and RETRO_STATUS <> 'CANCLD') " &
                    "and cust_shipment not in (select distinct ship_id from cust_pallet where retro_loc <> 'SHIPPED' and ship_id is not null ) " &
                    "or RETRO_STATUS='DESTAGED' or RETRO_STATUS='CANCLD' "


            DBCON1.Execute(strSql, oRecordsAffected)



            DeleteOrphaned_CustLineItem_CustPallet()


            DeleteCompletedShipments = oRecordsAffected.ToString

        Catch ex As Exception
            DeleteCompletedShipments = "-1"
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Function
    Private Sub DeleteOrphaned_CustLineItem_CustPallet()
        Try
            Dim strSQL As String

            strSQL = "delete  from cust_pallet where " &
               "ship_id <> '' and " &
               "ship_id not in " &
               "(select  cust_shipment from  cust_shipment) "

            DBCON1.Execute(strSQL)

            strSQL = "delete  from cust_lineitem where " &
                    "ship_id not in " &
                    "(select  cust_shipment from  cust_shipment) "

            DBCON1.Execute(strSQL)

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Sub

    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter
        TabPageSelected(CType(sender, TabPage))
    End Sub

    Private Sub TabPage4_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage4.Enter
        TabPageSelected(CType(sender, TabPage))
    End Sub

    Private Sub TabPage5_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage5.Enter
        TabPageSelected(CType(sender, TabPage))
    End Sub

    Private Sub TabPage6_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage6.Enter
        TabPageSelected(CType(sender, TabPage))
    End Sub

    Private Sub TabPage7_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage7.Enter
        TabPageSelected(CType(sender, TabPage))
    End Sub

    Private Sub TabPage8_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage8.Enter
        TabPageSelected(CType(sender, TabPage))
    End Sub
    Private Sub GetandDisplayASRSAvailableInventorySummary()
        FillASRSAvailableInventorySummary()
        DisplayASRSAvailableInventorySummary()
    End Sub
    Private Sub DisplayASRSAvailableInventorySummary()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid11.Rows = 1
            flxGrid11.Rows = 2
            flxGrid11.Cols = 5
            flxGrid11.Row = 0
            For y = 1 To flxGrid11.Cols
                flxGrid11.Col = y - 1
                flxGrid11.Text = vbNullString

                Select Case flxGrid11.Col

                    Case 0
                        flxGrid11.set_ColWidth(flxGrid11.Col, 0)

                    Case 2
                        flxGrid11.set_ColWidth(flxGrid11.Col, 800)

                    Case 3, 4
                        flxGrid11.set_ColWidth(flxGrid11.Col, 600)

                    Case Else
                        flxGrid11.set_ColWidth(flxGrid11.Col, 900)

                End Select

            Next

            flxGrid11.Redraw = False


            flxGrid11.Rows = 2
            flxGrid11.Row = 0

            flxGrid11.Col = 0
            flxGrid11.Text = "Sel"
            flxGrid11.Col = 1
            flxGrid11.Text = "Brand"
            flxGrid11.Col = 2
            flxGrid11.Text = "Paltyp"
            flxGrid11.Col = 3
            flxGrid11.Text = "Qa"
            flxGrid11.Col = 4
            flxGrid11.Text = "ULs"

            For x = 1 To ASRSAvailableInventorySummaryRecordCount

                flxGrid11.Row += 1

                flxGrid11.Col = 1
                flxGrid11.CellBackColor = colorBack
                flxGrid11.CellForeColor = colorFore
                flxGrid11.Text = vbNullString & ASRSAvailableInventorySummary(x).BRAND_CODE

                flxGrid11.Col = 2
                flxGrid11.CellBackColor = colorBack
                flxGrid11.CellForeColor = colorFore
                flxGrid11.Text = vbNullString & ASRSAvailableInventorySummary(x).PALLET_TYPE

                flxGrid11.Col = 3
                flxGrid11.CellBackColor = colorBack
                flxGrid11.CellForeColor = colorFore
                flxGrid11.Text = vbNullString & ASRSAvailableInventorySummary(x).HOLD_STATUS

                flxGrid11.Col = 4
                flxGrid11.CellBackColor = colorBack
                flxGrid11.CellForeColor = colorFore
                flxGrid11.Text = vbNullString & ASRSAvailableInventorySummary(x).ULIDCOUNT

                flxGrid11.Rows += 1

            Next

            'remove last blank row
            flxGrid11.Rows -= 1
            flxGrid11.Col = 0
            ' flxgrid11.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid11.Redraw = True

        End Try
    End Sub

    Private Sub FillASRSAvailableInventorySummary()
        Dim strSQL As String
        Try

            strSQL = "select BRAND_CODE,HOLD_STATUS,PALLET_TYPE,ULIDCOUNT  " &
                "from ULIDSummary " &
                "order by BRAND_CODE,PALLET_TYPE,HOLD_STATUS "

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            ASRSAvailableInventorySummaryRecordCount = 0
            ReDim ASRSAvailableInventorySummary(0)

            Do Until dbrec1.EOF

                ASRSAvailableInventorySummaryRecordCount += 1
                ReDim Preserve ASRSAvailableInventorySummary(ASRSAvailableInventorySummaryRecordCount)

                With ASRSAvailableInventorySummary(ASRSAvailableInventorySummaryRecordCount)

                    .BRAND_CODE = Convert.ToString(dbrec1.Fields("BRAND_CODE").Value)
                    .PALLET_TYPE = Convert.ToString(dbrec1.Fields("PALLET_TYPE").Value)
                    .ULIDCOUNT = Convert.ToString(dbrec1.Fields("ULIDCOUNT").Value)
                    .HOLD_STATUS = Convert.ToString(dbrec1.Fields("HOLD_STATUS").Value)
                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub butRereshAsrsInventorySummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRereshAsrsInventorySummary.Click
        GetandDisplayASRSAvailableInventorySummary()
    End Sub

    Private Sub ClearShipmentIDFromDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearShipmentIDFromDatabaseToolStripMenuItem.Click
        ClearShipmentIDFromDatabase()
    End Sub

    Private Sub ClearShipmentIDFromDatabase()
        Dim strUserinput As String

        strUserinput = InputBox("Cust_Shipment and Cust_LineItem records will be deleted.  ULIDs associated with removed Ship Ids will have ShipId nulled and Location Set to ASRS System Location",
                                "Enter Ship ID to Clear from DB")
        If strUserinput.Length = 0 Then Exit Sub

        DeleteDatafromEmulatorDBTablewithWhereClause("CUST_SHIPMENT", "CUST_SHIPMENT='" & strUserinput & "'", False)
        DeleteDatafromEmulatorDBTablewithWhereClause("CUST_LINEITEM", "SHIP_ID='" & strUserinput & "'", False)
        Update_CUST_PALLET_ReturnToASRSSystemAndUnassign(strUserinput)
    End Sub

    Private Sub butMsg21CheckInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg21CheckInventory.Click
        ShortInventoryCheck(lblRaid_SelectedShipidDisplay.Text)
    End Sub

    Private Sub DisplayMessageTimeStamps()
        Dim iYear As Integer = 1986

        If Year(gFirstMsgInTimeStamp) > iYear = True Then
            lblFirstMsgInTimeStamp.Text = gFirstMsgInTimeStamp.ToString
        End If
        If Year(gLastMsgInTimeStamp) > iYear = True Then
            lblLastMsgInTimeStamp.Text = gLastMsgInTimeStamp.ToString
        End If
        If Year(gFirstMsgOutTimeStamp) > iYear = True Then
            lblFirstMsgOutTimeStamp.Text = gFirstMsgOutTimeStamp.ToString
        End If
        If Year(gLastMsgOutTimeStamp) > iYear = True Then
            lblLastMsgOutTimeStamp.Text = gLastMsgOutTimeStamp.ToString
        End If

        lblMsgInCount.Text = giMsgInCount.ToString '& DateDiff(DateInterval.Second, gFirstMsgInTimeStamp, gLastMsgInTimeStamp) / 60
        lblMsgOutCount.Text = giMsgOutCount.ToString
    End Sub

    Private Sub ZeroOutMsgTimeStampData()
        Dim strText As String = ".."

        gFirstMsgInTimeStamp = DateAdd(DateInterval.Year, -100, Now)
        lblFirstMsgInTimeStamp.Text = strText

        gLastMsgInTimeStamp = gFirstMsgInTimeStamp
        lblLastMsgInTimeStamp.Text = strText

        gFirstMsgOutTimeStamp = gFirstMsgInTimeStamp
        lblFirstMsgOutTimeStamp.Text = strText

        gLastMsgOutTimeStamp = gFirstMsgInTimeStamp
        lblLastMsgOutTimeStamp.Text = strText

        giMsgInCount = 0
        giMsgOutCount = 0

        DisplayMessageTimeStamps()

    End Sub

    Private Sub ResetMessageCountersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetMessageCountersToolStripMenuItem.Click
        ZeroOutMsgTimeStampData()
    End Sub

    Private Sub tmrAutoScan_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAutoScan.Tick
        AutoScanTimerFired()
    End Sub

    Private Sub flxGrid2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flxGrid2.Enter

    End Sub

    Private Sub flxGrid3_MouseDownEvent1(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid3.MouseDownEvent
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub



    Private Sub FillUlsFromRTCISforReconcile(ByVal strItemCode As String)
        Dim strSQL As String
        Try


            strSQL = "select untdtl.ulid, untdtl.itmcod, ctlgrp.ctlgrp, ctlgrp.qastat, " &
            "p.plcpal, unitld.locatn, ordhdr.shipid " &
            "from locatn, ctlgrp, ordhdr, untdtl, unitld, ulpall p " &
            "where " &
            "unitld.ulpall=p.ulpall And " &
            "ctlgrp.ctlgrp = untdtl.ctlgrp And " &
            "ctlgrp.itmcod = untdtl.itmcod And " &
            "ctlgrp.itmcls = untdtl.itmcls And " &
            "ordhdr.ordnum(+)=unitld.ordnum and " &
            "untdtl.ulid = unitld.ulid And " &
            "locatn.subsit = unitld.subsit And " &
            "locatn.locatn = unitld.locatn And " &
            "untdtl.itmcod='" & strItemCode & "' And " &
            "unitld.subsit='" & gstrFPDSSubsitCharacter & "' and " &
            "(locatn.ACTIV_LOC is not null or unitld.locatn='" & gstrRTCISASRSSystemLocationName & "' or  " &
            "unitld.locatn like '" & gstrManualOutputVTLPrefix & "%') " &
            "order by untdtl.ulid "


            ' Open the Recordset using the select string:
            dbrec2.Open(strSQL, DBCON2)

            RTCISInventoryRecordCount = 0
            ReDim RTCISInventory(0)

            Do Until dbrec2.EOF

                RTCISInventoryRecordCount += 1
                ReDim Preserve RTCISInventory(RTCISInventoryRecordCount)

                With RTCISInventory(RTCISInventoryRecordCount)

                    .ULID = Convert.ToString(dbrec2.Fields("ULID").Value)
                    .ITMCOD = Convert.ToString(dbrec2.Fields("ITMCOD").Value)
                    .CTLGRP = Convert.ToString(dbrec2.Fields("CTLGRP").Value)
                    .QASTAT = Convert.ToString(dbrec2.Fields("QASTAT").Value)
                    .ULPALL = Convert.ToString(dbrec2.Fields("PLCPAL").Value)
                    .LOCATN = Convert.ToString(dbrec2.Fields("LOCATN").Value)
                    .SHIPID = Convert.ToString(dbrec2.Fields("SHIPID").Value)


                End With

                dbrec2.MoveNext()

            Loop

            dbrec2.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub
    Private Sub FillUlsFromCust_PalletForReconcile(ByVal strItemCode As String)
        Dim strSQL As String

        Try


            strSQL = "select CUST_ID, BRAND_CODE,CODE_DATE,HOLD_STATUS,PALLET_TYPE,RETRO_LOC,SHIP_ID " &
                    "from CUST_PALLET " &
                    "where BRAND_CODE='" & strItemCode & "' " &
                    "order by CUST_ID "


            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            ASRSInventoryRecordCount = 0
            ReDim ASRSInventory(0)

            Do Until dbrec1.EOF

                ASRSInventoryRecordCount += 1
                ReDim Preserve ASRSInventory(ASRSInventoryRecordCount)

                With ASRSInventory(ASRSInventoryRecordCount)

                    .ULID = Convert.ToString(dbrec1.Fields("CUST_ID").Value)
                    .ITMCOD = Convert.ToString(dbrec1.Fields("BRAND_CODE").Value)
                    .CTLGRP = Convert.ToString(dbrec1.Fields("CODE_DATE").Value)
                    .QASTAT = Convert.ToString(dbrec1.Fields("HOLD_STATUS").Value)
                    .ULPALL = Convert.ToString(dbrec1.Fields("PALLET_TYPE").Value)
                    .LOCATN = Convert.ToString(dbrec1.Fields("RETRO_LOC").Value)
                    .SHIPID = Convert.ToString(dbrec1.Fields("SHIP_ID").Value)


                End With

                dbrec1.MoveNext()

            Loop

            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub
    Private Sub ReconcileInventory(ByVal strItemCode As String)

        Dim x As Integer
        Dim iRTCISIndex As Integer
        Dim bMismatch As Boolean = False
        Dim mismatch(6) As Boolean
        Try

            SetupReconcileGrid()
            FillUlsFromRTCISforReconcile(strItemCode)
            FillUlsFromCust_PalletForReconcile(strItemCode)

            flxGrid12.Redraw = False

            For x = 1 To ASRSInventoryRecordCount

                bMismatch = False


                iRTCISIndex = BinarySearch(Strings.Left(ASRSInventory(x).ULID, 19), x)

                If iRTCISIndex = -1 Then
                    'no match
                    flxGrid12.Row += 1

                    flxGrid12.Col = 1
                    flxGrid12.CellBackColor = colorBack
                    flxGrid12.CellForeColor = colorFore
                    flxGrid12.Text = vbNullString & ASRSInventory(x).ULID

                    flxGrid12.Col = 2
                    flxGrid12.CellBackColor = colorBack
                    flxGrid12.CellForeColor = colorFore
                    flxGrid12.Text = vbNullString & ASRSInventory(x).LOCATN

                    flxGrid12.Col = 3
                    flxGrid12.CellBackColor = Color.Red
                    flxGrid12.CellForeColor = Color.White


                    flxGrid12.Col = 4
                    flxGrid12.CellBackColor = colorBack
                    flxGrid12.CellForeColor = colorFore
                    flxGrid12.Text = vbNullString & ASRSInventory(x).ITMCOD

                    flxGrid12.Col = 6
                    flxGrid12.CellBackColor = colorBack
                    flxGrid12.CellForeColor = colorFore
                    flxGrid12.Text = vbNullString & ASRSInventory(x).CTLGRP

                    flxGrid12.Col = 8
                    flxGrid12.CellBackColor = colorBack
                    flxGrid12.CellForeColor = colorFore
                    flxGrid12.Text = vbNullString & ASRSInventory(x).QASTAT

                    flxGrid12.Col = 10
                    flxGrid12.CellBackColor = colorBack
                    flxGrid12.CellForeColor = colorFore
                    flxGrid12.Text = vbNullString & ASRSInventory(x).ULPALL

                    flxGrid12.Col = 12
                    flxGrid12.CellBackColor = colorBack
                    flxGrid12.CellForeColor = colorFore
                    flxGrid12.Text = vbNullString & ASRSInventory(x).SHIPID




                    flxGrid12.Rows += 1

                Else
                    ReDim mismatch(6)

                    If ASRSInventory(x).LOCATN = gstrASRSSystemLocationName And RTCISInventory(iRTCISIndex).LOCATN = gstrRTCISASRSSystemLocationName Then
                        'ok locations matchs
                    Else

                        If ASRSInventory(x).LOCATN <> RTCISInventory(iRTCISIndex).LOCATN Then
                            mismatch(1) = True
                            bMismatch = True
                        End If
                    End If

                    If ASRSInventory(x).ITMCOD <> RTCISInventory(iRTCISIndex).ITMCOD Then
                        mismatch(2) = True
                        bMismatch = True
                    End If

                    If ASRSInventory(x).CTLGRP <> RTCISInventory(iRTCISIndex).CTLGRP Then
                        mismatch(3) = True
                        bMismatch = True
                    End If

                    If ASRSInventory(x).QASTAT <> RTCISInventory(iRTCISIndex).QASTAT Then
                        mismatch(4) = True
                        bMismatch = True
                    End If

                    If ASRSInventory(x).ULPALL <> RTCISInventory(iRTCISIndex).ULPALL Then
                        mismatch(5) = True
                        bMismatch = True
                    End If

                    If ASRSInventory(x).SHIPID <> RTCISInventory(iRTCISIndex).SHIPID Then

                        If Strings.Left(ASRSInventory(x).SHIPID, 1) <> "M" Then
                            mismatch(6) = True
                        Else
                            'this is a manual withdraw and RTCSI does not associate the UL to a man wthdrw
                        End If
                    End If

                End If

                If iRTCISIndex > 0 Then
                    flxGrid12.Row += 1

                    flxGrid12.Col = 1
                    flxGrid12.CellBackColor = colorBack
                    flxGrid12.CellForeColor = colorFore
                    flxGrid12.Text = vbNullString & ASRSInventory(x).ULID

                    '=======================================================================================
                    flxGrid12.Col = 2
                    If mismatch(1) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & ASRSInventory(x).LOCATN

                    flxGrid12.Col = 3
                    If mismatch(1) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & RTCISInventory(iRTCISIndex).LOCATN

                    '=======================================================================================
                    flxGrid12.Col = 4
                    If mismatch(2) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & ASRSInventory(x).ITMCOD

                    flxGrid12.Col = 5
                    If mismatch(2) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & RTCISInventory(iRTCISIndex).ITMCOD

                    '=======================================================================================
                    flxGrid12.Col = 6
                    If mismatch(3) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & ASRSInventory(x).CTLGRP

                    flxGrid12.Col = 7
                    If mismatch(3) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & RTCISInventory(iRTCISIndex).CTLGRP

                    '=======================================================================================
                    flxGrid12.Col = 8
                    If mismatch(4) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & ASRSInventory(x).QASTAT

                    flxGrid12.Col = 9
                    If mismatch(4) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & RTCISInventory(iRTCISIndex).QASTAT

                    '=======================================================================================
                    flxGrid12.Col = 10
                    If mismatch(5) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & ASRSInventory(x).ULPALL

                    flxGrid12.Col = 11
                    If mismatch(5) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & RTCISInventory(iRTCISIndex).ULPALL

                    '=======================================================================================
                    flxGrid12.Col = 12
                    If mismatch(6) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & ASRSInventory(x).SHIPID

                    flxGrid12.Col = 13
                    If mismatch(6) = True Then
                        flxGrid12.CellBackColor = Color.Red
                        flxGrid12.CellForeColor = Color.White
                    Else
                        flxGrid12.CellBackColor = colorBack
                        flxGrid12.CellForeColor = colorFore
                    End If
                    flxGrid12.Text = vbNullString & RTCISInventory(iRTCISIndex).SHIPID


                    flxGrid12.Rows += 1
                End If

            Next

            'dont show all the ULS in RTCIS ASRS
            'For x = 1 To RTCISInventoryRecordCount
            '    If RTCISInventory(x).MatchingIndex = 0 Then
            '        flxGrid12.Row += 1

            '        flxGrid12.Col = 1
            '        flxGrid12.CellBackColor = colorBack
            '        flxGrid12.CellForeColor = colorFore
            '        flxGrid12.Text = vbNullString & RTCISInventory(x).ULID

            '        flxGrid12.Col = 2
            '        flxGrid12.CellBackColor = colorBack
            '        flxGrid12.CellForeColor = colorFore
            '        flxGrid12.Text = vbNullString

            '        flxGrid12.Col = 3
            '        flxGrid12.CellBackColor = colorBack
            '        flxGrid12.CellForeColor = colorFore
            '        flxGrid12.Text = vbNullString & RTCISInventory(x).LOCATN


            '        flxGrid12.Rows += 1
            '    End If
            'Next
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally
            flxGrid12.Redraw = True
        End Try

    End Sub

    Shared Function BinarySearch(ByVal key As String, ByVal iInputIndex As Integer) As Integer

        Dim low As Integer = 1                 ' low index
        Dim high As Integer = RTCISInventoryRecordCount ' high index 
        Dim middle As Integer             ' middle index

        While low <= high

            middle = (low + high) \ 2

            If key = RTCISInventory(middle).ULID Then     ' match
                RTCISInventory(middle).MatchingIndex = iInputIndex
                Return middle
            ElseIf key < RTCISInventory(middle).ULID Then ' search low end
                high = middle - 1
            Else
                low = middle + 1
            End If

        End While

        Return -1 ' search key not found
    End Function ' BinarySearch
    Shared Function BinarySearch2(ByVal array As Integer(),
 ByVal key As Integer) As Integer

        Dim low As Integer = 0                 ' low index
        Dim high As Integer = array.GetUpperBound(0) ' high index 
        Dim middle As Integer             ' middle index

        While low <= high
            middle = (low + high) \ 2

            If key = array(middle) Then     ' match
                Return middle
            ElseIf key < array(middle) Then ' search low end
                high = middle - 1            ' of array
            Else
                low = middle + 1
            End If

        End While

        Return -1 ' search key not found
    End Function ' BinarySearch



    Private Sub SetupReconcileGrid()

        Dim y As Integer

        Try
            flxGrid12.Rows = 1
            flxGrid12.Rows = 2
            flxGrid12.Cols = 14
            flxGrid12.Row = 0
            For y = 1 To flxGrid12.Cols
                flxGrid12.Col = y - 1
                flxGrid12.Text = vbNullString

                Select Case flxGrid12.Col


                    Case 0
                        flxGrid12.set_ColWidth(flxGrid12.Col, 0)
                    Case 1
                        flxGrid12.set_ColWidth(flxGrid12.Col, 2000)
                    Case 6, 7
                        flxGrid12.set_ColWidth(flxGrid12.Col, 1200)

                    Case Else
                        flxGrid12.set_ColWidth(flxGrid12.Col, 1000)

                End Select

            Next

            flxGrid12.Redraw = False

            ' Initialize the Grid by defining the Details:
            flxGrid12.Rows = 2
            flxGrid12.Row = 0

            flxGrid12.Col = 0
            flxGrid12.Text = "Sel"
            flxGrid12.Col = 1
            flxGrid12.Text = "Ulid"
            flxGrid12.Col = 2
            flxGrid12.Text = "A_Loc"
            flxGrid12.Col = 3
            flxGrid12.Text = "R_Loc"
            flxGrid12.Col = 4
            flxGrid12.Text = "A_ItmCod"
            flxGrid12.Col = 5
            flxGrid12.Text = "R_ItmCod"
            flxGrid12.Col = 6
            flxGrid12.Text = "A_CtlGrp"
            flxGrid12.Col = 7
            flxGrid12.Text = "R_CtlGrp"
            flxGrid12.Col = 8
            flxGrid12.Text = "A_QaStat"
            flxGrid12.Col = 9
            flxGrid12.Text = "R_QaStat"
            flxGrid12.Col = 10
            flxGrid12.Text = "A_UlPall"
            flxGrid12.Col = 11
            flxGrid12.Text = "R_UlPall"
            flxGrid12.Col = 12
            flxGrid12.Text = "A_ShipId"
            flxGrid12.Col = 13
            flxGrid12.Text = "R_ShipId"



            flxGrid12.Col = 0
            ' flxGrid12.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            RefreshLog()
        Finally

            flxGrid12.Redraw = True

        End Try
    End Sub

    Private Sub butReconcile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butReconcile.Click
        If txtReconcileItmCod.Text.Length > 0 Then
            ReconcileInventory(txtReconcileItmCod.Text)
        Else
            MessageBox.Show("Please Enter An Item Code to Reconcile", "Item Code Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub DeleteCompletedWithdrawsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCompletedWithdrawsToolStripMenuItem.Click
        PurgeCompletedWithdraws(True)
    End Sub

    Private Sub FillUlPallFromRTCISforReconcile()
        Dim strSQL As String
        Try


            strSQL = "select ulpall, plcpal " &
            "from ulpall  " &
            "where plcpal is not null "



            ' Open the Recordset using the select string:
            dbrec2.Open(strSQL, DBCON2)

            UlpallRecordCount = 0
            ReDim Ulpall(0)

            Do Until dbrec2.EOF

                UlpallRecordCount += 1
                ReDim Preserve Ulpall(UlpallRecordCount)

                With Ulpall(UlpallRecordCount)
                    .ULPALL = Convert.ToString(dbrec2.Fields("ULPALL").Value)
                    .PLCPAL = Convert.ToString(dbrec2.Fields("PLCPAL").Value)
                End With

                dbrec2.MoveNext()

            Loop

            dbrec2.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub flxGrid1_MouseDownEvent1(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid1.MouseDownEvent
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub

    Private Sub TabPage9_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage9.Enter
        TabPageSelected(CType(sender, TabPage))
    End Sub

    Private Sub butRequestNextProdOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRequestNextProdOrder.Click
        SendMsgRequestNextProdOrder()
    End Sub

    Private Sub EditXMLBeforeSendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditXMLBeforeSendToolStripMenuItem.Click
        If EditXMLBeforeSendToolStripMenuItem.Checked = True Then
            EditXMLBeforeSendToolStripMenuItem.Checked = False
        Else
            EditXMLBeforeSendToolStripMenuItem.Checked = True
        End If

        If EditXMLBeforeSendToolStripMenuItem.Checked = True Then
            gbEditXMLBeforeSend = True

        Else
            gbEditXMLBeforeSend = False
        End If
    End Sub

    Private Sub PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem.Click
        If PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem.Checked = True Then
            PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem.Checked = False
        Else
            PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem.Checked = True
        End If


        If PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem.Checked = True Then
            gbPreventDBUpdatesAfterMessage = True
        Else
            gbPreventDBUpdatesAfterMessage = False

        End If
    End Sub

    Private Function StagedUlsforShipId(ByVal strShipId As String) As Integer
        Dim strSQL As String
        Dim strValue As String = "0"
        Try
            StagedUlsforShipId = 0

            strSQL = "select sum(L.STAGED) AS SUMofStaged  " &
                "from CUST_LINEITEM L " &
                "where " &
                "L.RETRO_STATUS in ('23','43') " &
                "and L.SHIP_ID='" & strShipId & "' "

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)


            Do Until dbrec1.EOF

                strValue = Convert.ToString(dbrec1.Fields("SUMofStaged").Value)

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

            If IsNumeric(strValue) = False Then
                StagedUlsforShipId = 0
            Else
                StagedUlsforShipId = CInt(strValue)
            End If

        Catch ex As Exception
            StagedUlsforShipId = 0
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Function

    Public Sub HighlightGridRow(ByVal oGrid As AxMSFlexGrid, ByVal iRowSelected As Integer, ByVal iColSelected As Integer)
        Dim x As Integer
        Dim y As Integer

        Dim clrText As Color

        For x = 1 To oGrid.Rows - 1
            oGrid.Row = x
            If iRowSelected = x Then
                clrText = Color.Blue
            Else
                clrText = Color.Black
            End If
            For y = 0 To oGrid.Cols - 1
                oGrid.Col = y
                If oGrid.CellForeColor = clrText Then       'aviod repainting cells that dont need repainting
                    Exit For
                Else
                    oGrid.CellForeColor = clrText
                End If

            Next

        Next

        'set the selected cell back to the original, otherwise strange back colors arise!
        'make sure that when no rows or no cols exist that a CLR error isnt generated
        If iRowSelected < oGrid.Rows Then
            oGrid.Row = iRowSelected
        End If
        If iColSelected < oGrid.Cols Then
            oGrid.Col = iColSelected
        End If


    End Sub

    Private Sub flxGrid4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flxGrid4.Enter

    End Sub

    Private Sub flxGrid9_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flxGrid9.Enter

    End Sub

    Private Sub SetupGraphicalSummary()

        lblG01Title.Text = "A8"
        lblG02Title.Text = "6"
        lblG03Title.Text = "7"
        lblG04Title.Text = "8"
        lblG05Title.Text = "23"
        lblG06Title.Text = "15"


        For Each cntrl As Control In TabPage10.Controls
            If cntrl.Name.StartsWith("lblG") Or cntrl.Name.StartsWith("lblE") Then
                If cntrl.Name.Contains("Title") = False Then
                    InitializeSingleSummaryLabel(cntrl)
                End If
            End If
        Next
    End Sub

    Private Sub InitializeSingleSummaryLabel(ByVal oLabel As Control)
        oLabel.Tag = oLabel.Text   'store last value
        oLabel.Text = gcStrZero
        oLabel.BackColor = System.Drawing.SystemColors.GrayText

    End Sub

    Private Sub FillULStatusGrouped()
        Dim strSQL As String

        strSQL = "Select RETRO_STATUS, ULIDCOUNT from qryULIDStatusSummary "

        ' Open the Recordset using the select string:
        dbrec1.Open(strSQL, DBCON1)

        ULStatusGrouped_RecordCount = 0
        ReDim ULStatusGrouped(0)

        Do Until dbrec1.EOF

            ' Populate the ULStatusGrouped array by parsing through the recordset one row at a time:
            ULStatusGrouped_RecordCount += 1
            ReDim Preserve ULStatusGrouped(ULStatusGrouped_RecordCount)

            With ULStatusGrouped(ULStatusGrouped_RecordCount)

                .Retro_Status = Convert.ToString(dbrec1.Fields("RETRO_STATUS").Value)
                .ULCount = Convert.ToString(dbrec1.Fields("ULIDCOUNT").Value)

            End With

            dbrec1.MoveNext()

        Loop

        'Close Recordset:
        dbrec1.Close()

    End Sub

    Private Sub butGetGraphicalData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetGraphicalData.Click
        GetGraphicalData()
    End Sub
    Private Sub GetGraphicalData()
        FillULStatusGrouped()
        DisplayGraphicalSummary()
    End Sub

    Private Sub DisplayGraphicalSummary()
        Dim x As Integer

        Try

            'need to set all values to zero to initialize
            SetupGraphicalSummary()

            'DisplayErrorRoutingSelections(linE01)
            'DisplayErrorRoutingSelections(linE02)
            'DisplayErrorRoutingSelections(linE03)
            'DisplayErrorRoutingSelections(linE04)
            'DisplayErrorRoutingSelections(linE05)
            'DisplayErrorRoutingSelections(linE06)
            'DisplayErrorRoutingSelections(linE07)
            'DisplayErrorRoutingSelections(linE08)
            'DisplayErrorRoutingSelections(linE09)
            'DisplayErrorRoutingSelections(linE10)




            'probably a better way
            For x = 1 To ULStatusGrouped_RecordCount
                With ULStatusGrouped(x)

                    Select Case .Retro_Status
                        Case "A8"
                            UpdateULGroupedLabel(lblG01, .ULCount)

                        Case "6"
                            UpdateULGroupedLabel(lblG02, .ULCount)

                        Case "7"
                            UpdateULGroupedLabel(lblG03, .ULCount)

                        Case "8"      'in ASRS
                            UpdateULGroupedLabel(lblG04, .ULCount)

                        Case "23"
                            UpdateULGroupedLabel(lblG05, .ULCount)

                        Case "15"
                            UpdateULGroupedLabel(lblG06, .ULCount)



                    End Select
                End With

            Next

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub UpdateULGroupedLabel(ByVal oLabel As Label, ByVal strText As String)
        Dim strPrevText As String

        Try
            If Strings.Len(oLabel.Tag) = 0 Then
                strPrevText = " "
            Else
                strPrevText = oLabel.Tag.ToString
            End If
            oLabel.Text = strText

            If strPrevText <> strText Then
                If Strings.Mid(oLabel.Name, 4, 1) = gcstrCartonPathGood Then
                    oLabel.BackColor = Color.LightGreen
                Else
                    oLabel.BackColor = Color.Red

                End If
            Else
                oLabel.BackColor = System.Drawing.SystemColors.GrayText
            End If


        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub FillCustPalletDataFromWMS(ByVal strULID As String)


        Dim strSQL As String
        Try

            strULID = Strings.Left(strULID, 19)

            strSQL = "select u.ulid, min(i.itmcod) itmcod,min(i.itmdsc) itmdsc, min(c.ctlgrp) ctlgrp, min(p.plcpal) plcpal,min(c.qastat) qastat, min(u.base_ulid) base_ulid " &
            "from itmmst i, ctlgrp c, ulpall p, untdtl d, unitld u " &
            "where  " &
            "u.ulpall = p.ulpall " &
            "and i.itmcod=d.itmcod " &
            "and i.itmcls=d.itmcls " &
            "and c.ctlgrp=d.ctlgrp " &
            "and c.itmcod=d.itmcod " &
            "and c.itmcls=d.itmcls " &
            "and d.ulid=u.ulid " &
            "and u.ulid='" & strULID & "' " &
            "group by u.ulid"


            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON2)

            UlInfoFromWMSRecordCount = 0
            ReDim UlInfoFromWMS(0)

            Do Until dbrec1.EOF


                UlInfoFromWMSRecordCount += 1
                ReDim Preserve UlInfoFromWMS(UlInfoFromWMSRecordCount)

                With UlInfoFromWMS(UlInfoFromWMSRecordCount)
                    .BRAND_CODE = Convert.ToString(dbrec1.Fields("ITMCOD").Value)
                    .BRAND_DESC = Convert.ToString(dbrec1.Fields("ITMDSC").Value)
                    .CODE_DATE = Convert.ToString(dbrec1.Fields("CTLGRP").Value)
                    .PALLET_TYPE = Convert.ToString(dbrec1.Fields("PLCPAL").Value)
                    .HOLD_STATUS = Convert.ToString(dbrec1.Fields("QASTAT").Value)
                    .BASE_ULID = Convert.ToString(dbrec1.Fields("BASE_ULID").Value)
                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub flxGrid13_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid13.MouseDownEvent
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub

    Private Sub cmdFPDSSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFPDSSelectAll.Click
        ProcessGridSelectAll(flxGrid13)
    End Sub

    Private Sub cmdFPDSDeSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFPDSDeSelectAll.Click
        ProcessGridDeSelectAll(flxGrid13)
    End Sub

    Private Sub cmdFPDSAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFPDSAdvance.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid13) = False Then Exit Sub
        FPDSAdvance(True)
    End Sub

    Private Sub butRefreshFPDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRefreshFPDS.Click
        GetAndDisplayTrailerFPDSData()
    End Sub
    Private Sub GetAndDisplayTrailerFPDSData()
        FillTrailerFPDS()
        DisplayTrailerFPDS()
    End Sub

    Private Sub GetAndDisplayTrailerAllInputConveyorData()
        FillAllInputConveyor()
        DisplayAllInputConveyor()
    End Sub

    Private Sub FillTrailerFPDS()
        Dim strSQL As String
        Try

            strSQL = "select MESSAGE_TYPE,TRAILER_NUMBER,TRUCK_LINE, LINE_COUNT,CTRL_DATE " &
                "from TRAILER_FPDS where message_type='A35' " &
                "order by CTRL_DATE asc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Trailer_Hdr_FPDSRecordCount = 0
            ReDim Trailer_Hdr_Fpds(0)

            Do Until dbrec1.EOF


                Trailer_Hdr_FPDSRecordCount += 1
                ReDim Preserve Trailer_Hdr_Fpds(Trailer_Hdr_FPDSRecordCount)

                With Trailer_Hdr_Fpds(Trailer_Hdr_FPDSRecordCount)

                    .MESSAGE_TYPE = Convert.ToString(dbrec1.Fields("MESSAGE_TYPE").Value)
                    .TRAILER_NUMBER = Convert.ToString(dbrec1.Fields("TRAILER_NUMBER").Value)
                    .TRUCK_LINE = Convert.ToString(dbrec1.Fields("TRUCK_LINE").Value)
                    .LINE_COUNT = Convert.ToString(dbrec1.Fields("LINE_COUNT").Value)
                    .CTRL_DATE = Convert.ToString(dbrec1.Fields("CTRL_DATE").Value)

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub DisplayTrailerFPDS()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid13.Rows = 1
            flxGrid13.Rows = 2
            flxGrid13.Cols = 6
            flxGrid13.Row = 0
            For y = 1 To flxGrid13.Cols
                flxGrid13.Col = y - 1
                flxGrid13.Text = vbNullString

                Select Case flxGrid13.Col

                    Case 0
                        flxGrid13.set_ColWidth(flxGrid13.Col, 500)

                    Case 1
                        flxGrid13.set_ColWidth(flxGrid13.Col, 1900)

                    Case 4
                        flxGrid13.set_ColWidth(flxGrid13.Col, 1000)

                    Case Else
                        flxGrid13.set_ColWidth(flxGrid13.Col, 1200)

                End Select

            Next

            flxGrid13.Redraw = False


            flxGrid13.Rows = 2
            flxGrid13.Row = 0

            flxGrid13.Col = 0
            flxGrid13.Text = "Sel"
            flxGrid13.Col = 1
            flxGrid13.Text = "Ctrl_Date"
            flxGrid13.Col = 2
            flxGrid13.Text = "Trailer"
            flxGrid13.Col = 3
            flxGrid13.Text = "Truck Line"
            flxGrid13.Col = 4
            flxGrid13.Text = "Count"
            flxGrid13.Col = 5
            flxGrid13.Text = "Conveyor"


            For x = 1 To Trailer_Hdr_FPDSRecordCount

                flxGrid13.Row += 1

                flxGrid13.Col = 1
                flxGrid13.CellBackColor = colorBack
                flxGrid13.CellForeColor = colorFore
                flxGrid13.Text = vbNullString & Trailer_Hdr_Fpds(x).CTRL_DATE

                flxGrid13.Col = 2
                flxGrid13.CellBackColor = colorBack
                flxGrid13.CellForeColor = colorFore
                flxGrid13.Text = vbNullString & Trailer_Hdr_Fpds(x).TRAILER_NUMBER

                flxGrid13.Col = 3
                flxGrid13.CellBackColor = colorBack
                flxGrid13.CellForeColor = colorFore
                flxGrid13.Text = vbNullString & Trailer_Hdr_Fpds(x).TRUCK_LINE

                flxGrid13.Col = 4
                flxGrid13.CellBackColor = colorBack
                flxGrid13.CellForeColor = colorFore
                flxGrid13.Text = vbNullString & Trailer_Hdr_Fpds(x).LINE_COUNT


                flxGrid13.Col = 5
                flxGrid13.CellBackColor = colorBack
                flxGrid13.CellForeColor = colorFore
                flxGrid13.Text = gstrM35Activ_Input_ConveyorsPrefix & Activ_Input_Conveyors(RandomNumber(0, Activ_Input_Conveyors.GetUpperBound(0)))

                flxGrid13.Rows += 1

            Next

            'remove last blank row
            flxGrid13.Rows -= 1
            flxGrid13.Col = 0
            DisplayGridRowCount(cmdFPDSSelectAll, flxGrid13)
            ' flxGrid13.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

            flxGrid13.Redraw = True

        End Try
    End Sub
    Private Sub FillAllInputConveyor()
        Dim strSQL As String
        Try

            strSQL = "select MESSAGE_TYPE,TRAILER_NUMBER,TRUCK_LINE, LINE_COUNT,CTRL_DATE,ACTIV_INPUT_LOCATION " &
                "from TRAILER_FPDS " &
                "order by CTRL_DATE asc"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            AllInputConveyorRecordCount = 0
            ReDim AllInputConveyor(0)

            Do Until dbrec1.EOF


                AllInputConveyorRecordCount += 1
                ReDim Preserve AllInputConveyor(AllInputConveyorRecordCount)

                With AllInputConveyor(AllInputConveyorRecordCount)

                    .MESSAGE_TYPE = Convert.ToString(dbrec1.Fields("MESSAGE_TYPE").Value)
                    .TRAILER_NUMBER = Convert.ToString(dbrec1.Fields("TRAILER_NUMBER").Value)
                    .TRUCK_LINE = Convert.ToString(dbrec1.Fields("TRUCK_LINE").Value)
                    .LINE_COUNT = Convert.ToString(dbrec1.Fields("LINE_COUNT").Value)
                    .CTRL_DATE = Convert.ToString(dbrec1.Fields("CTRL_DATE").Value)
                    .ACTIV_INPUT_LOCATION = Convert.ToString(dbrec1.Fields("ACTIV_INPUT_LOCATION").Value)

                End With

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    Private Sub DisplayAllInputConveyor()
        Dim x As Integer
        Dim y As Integer

        Try
            flxGrid14.Rows = 1
            flxGrid14.Rows = 2
            flxGrid14.Cols = 7
            flxGrid14.Row = 0
            For y = 1 To flxGrid14.Cols
                flxGrid14.Col = y - 1
                flxGrid14.Text = vbNullString

                Select Case flxGrid14.Col

                    Case 0
                        flxGrid14.set_ColWidth(flxGrid14.Col, 500)

                    Case 1
                        flxGrid14.set_ColWidth(flxGrid14.Col, 1900)

                    Case 4
                        flxGrid14.set_ColWidth(flxGrid14.Col, 1000)

                    Case Else
                        flxGrid14.set_ColWidth(flxGrid14.Col, 1200)

                End Select

            Next

            flxGrid14.Redraw = False


            flxGrid14.Rows = 2
            flxGrid14.Row = 0

            flxGrid14.Col = 0
            flxGrid14.Text = "Sel"
            flxGrid14.Col = 1
            flxGrid14.Text = "Ctrl_Date"
            flxGrid14.Col = 2
            flxGrid14.Text = "Trailer"
            flxGrid14.Col = 3
            flxGrid14.Text = "Truck Line"
            flxGrid14.Col = 4
            flxGrid14.Text = "Count"
            flxGrid14.Col = 5
            flxGrid14.Text = "Conveyor"
            flxGrid14.Col = 6
            flxGrid14.Text = "MsgTyp/Status"


            For x = 1 To AllInputConveyorRecordCount

                flxGrid14.Row += 1

                flxGrid14.Col = 1
                flxGrid14.CellBackColor = colorBack
                flxGrid14.CellForeColor = colorFore
                flxGrid14.Text = vbNullString & AllInputConveyor(x).CTRL_DATE

                flxGrid14.Col = 2
                flxGrid14.CellBackColor = colorBack
                flxGrid14.CellForeColor = colorFore
                flxGrid14.Text = vbNullString & AllInputConveyor(x).TRAILER_NUMBER

                flxGrid14.Col = 3
                flxGrid14.CellBackColor = colorBack
                flxGrid14.CellForeColor = colorFore
                flxGrid14.Text = vbNullString & AllInputConveyor(x).TRUCK_LINE

                flxGrid14.Col = 4
                flxGrid14.CellBackColor = colorBack
                flxGrid14.CellForeColor = colorFore
                flxGrid14.Text = vbNullString & AllInputConveyor(x).LINE_COUNT

                flxGrid14.Col = 5
                flxGrid14.CellBackColor = colorBack
                flxGrid14.CellForeColor = colorFore
                flxGrid14.Text = vbNullString & AllInputConveyor(x).ACTIV_INPUT_LOCATION

                flxGrid14.Col = 6
                flxGrid14.CellBackColor = colorBack
                flxGrid14.CellForeColor = colorFore
                flxGrid14.Text = vbNullString & AllInputConveyor(x).MESSAGE_TYPE

                flxGrid14.Rows += 1

            Next

            'remove last blank row
            flxGrid14.Rows -= 1
            flxGrid14.Col = 0
            DisplayGridRowCount(butConveyorInputSelectAll, flxGrid14)
            ' flxGrid14.Sort = flexSortNumericAscending
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

            flxGrid14.Redraw = True

        End Try
    End Sub

    Private Sub FPDSAdvance(ByVal bUserPrompt As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim iAdvances As Integer = 0
        Dim strActiv_Input_Location As String
        Dim strTRUCK_LINE As String
        Dim strTRAILER_NUMBER As String

        Try

            If bUserPrompt = True Then

                shMsgbox = MsgBox("Send AssignFPDSLoc for Selected Trailer(s) ?", MsgBoxStyle.YesNo, "Confirm Assign FPDS Location Processing")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                GetAndDisplayTrailerFPDSData()
                ProcessGridSelectAll(flxGrid13)
            End If

            For x = 1 To flxGrid13.Rows - 1

                If flxGrid13.get_TextMatrix(x, 0) = gcstrY Then
                    iAdvances += 1

                    If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then


                        'do the advance
                        strTRAILER_NUMBER = flxGrid13.get_TextMatrix(x, 2)
                        strTRUCK_LINE = flxGrid13.get_TextMatrix(x, 3)
                        strActiv_Input_Location = flxGrid13.get_TextMatrix(x, 5)

                        If SendRequest(CreateXML_AssignFPDSLoc("A35", strTRAILER_NUMBER, strTRUCK_LINE, strActiv_Input_Location)) = True Then
                            Update_TRAILER_FPDS(strTRUCK_LINE, strTRAILER_NUMBER, "A35S", strActiv_Input_Location)

                        Else
                            WriteLog(gcstrError, "Msg35 Failed for Truckline|Trailer " & strTRUCK_LINE & "|" & strTRAILER_NUMBER & " Database Update Skipped")
                        End If
                    Else
                        Exit For
                    End If

                End If
            Next

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

            If bUserPrompt = True Then
                ' GetAndDisplayASRSInfeedData()
            End If

        End Try
    End Sub


    Private Sub DeleteTRAILERFPDSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteTRAILERFPDSToolStripMenuItem.Click
        DeleteAllDatafromEmulatorDBTable("TRAILER_FPDS", True)
        GetAndDisplayTrailerFPDSData()
    End Sub

    Private Sub TabPage11_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage11.Enter
        TabPageSelected(CType(sender, TabPage))
    End Sub

    Private Sub btnFPDSAutoScanOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFPDSAutoScanOn.Click
        TrailerFPDSAutoScanOn()
    End Sub

    Private Sub btnFPDSAutoScanOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFPDSAutoScanOff.Click
        TrailerFPDSAutoScanOff()
    End Sub

    Private Sub TrailerFPDSAutoScanOn()
        AutoScanOn(btnFPDSAutoScanOn, btnFPDSAutoScanOff)
    End Sub

    Private Sub TrailerFPDSAutoScanOff()
        AutoScanOff(btnFPDSAutoScanOn, btnFPDSAutoScanOff)
    End Sub


    Private Sub butRefreshConveyorInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRefreshConveyorInput.Click
        GetAndDisplayTrailerAllInputConveyorData()
    End Sub


    Private Sub butConveyorInputSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butConveyorInputSelectAll.Click
        ProcessGridSelectAll(flxGrid14)
    End Sub

    Private Sub butConveyorInputDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butConveyorInputDeselectAll.Click
        ProcessGridDeSelectAll(flxGrid14)
    End Sub



    Private Sub butConveyorInputDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butConveyorInputDelete.Click
        If IsAtLeastOneGridRowSelectionSetYes(flxGrid14) = False Then Exit Sub

        DeleteFromTrailerFPDS(True)
    End Sub

    Private Sub flxGrid14_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid14.MouseDownEvent
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub

    Private Sub DeleteFromTrailerFPDS(ByVal bUserPrompt As Boolean)
        Dim x As Integer
        Dim shMsgbox As MsgBoxResult
        Dim iAdvances As Integer = 0
        Dim strTRUCK_LINE As String
        Dim strTRAILER_NUMBER As String
        Dim lRecordsAffected As Integer

        Try

            If bUserPrompt = True Then

                shMsgbox = MsgBox("Delete Db Entry AssignFPDSLoc for Selected Trailer(s) ?", MsgBoxStyle.YesNo, "Confirm Assign FPDS Location Database Deletion")

                If shMsgbox = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                GetAndDisplayTrailerAllInputConveyorData()
                ProcessGridSelectAll(flxGrid14)
            End If

            For x = 1 To flxGrid14.Rows - 1

                If flxGrid14.get_TextMatrix(x, 0) = gcstrY Then
                    iAdvances += 1

                    If iAdvances <= giMaxNumMsgsByMsgToSendPerTimerInterval Then

                        'deletion
                        strTRAILER_NUMBER = flxGrid14.get_TextMatrix(x, 2)
                        strTRUCK_LINE = flxGrid14.get_TextMatrix(x, 3)

                        lRecordsAffected = DeleteDatafromEmulatorDBTablewithWhereClause("TRAILER_FPDS",
                            "TRAILER_NUMBER='" & strTRAILER_NUMBER & "' and TRUCK_LINE ='" & strTRUCK_LINE & "'", False)

                        WriteLog(gcstrProcessed, "Removed from WCS DB " & strTRUCK_LINE & "|" & strTRAILER_NUMBER & Space(1) & RecordAffectedMessage(lRecordsAffected, gcstrDelete))

                    Else
                        Exit For
                    End If

                End If
            Next

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        Finally

            If bUserPrompt = True Then
                ' GetAndDisplayASRSInfeedData()
            End If

        End Try
    End Sub






    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DisplayAvailableDatabasePatches()
    End Sub


    Private Sub DisplayDatabasePatchVersionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayDatabasePatchVersionsToolStripMenuItem.Click
        DisplayAvailableDatabasePatches()
    End Sub


    Private Sub CheckDBForRequiredTablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDBForRequiredTablesToolStripMenuItem.Click
        AnyRequiredDatabaseTablesMissing()
        RefreshLog()
    End Sub

    Private Sub HostInboundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HostInboundToolStripMenuItem.Click
        ShowIniForm("HostInbound")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


    End Sub
    Private Sub SendKeystoPutty(ByVal strKeys As String)

        '"00000470010001157363~~~~~~~~"
        ' Get processes.
        Dim processes() As Process = Process.GetProcesses()

        ' Loop over processes.
        For Each p As Process In processes

            ' Display process properties.

            If UCase(Strings.Left(p.ProcessName, 5)) = Strings.Left(gstrDtldrvsndTermEmuProcessName, 5) And UCase(p.MainWindowTitle) = gstrDtldrvsndTermEmuWindowTitle Then
                'WriteLog(gcstrINFO, p.ProcessName + "/" + p.Id.ToString())
                AppActivate(p.Id)
                SendKeys.SendWait(strKeys)
                Exit For
            End If

        Next
    End Sub

    Private Sub butUtil_MoveUl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butUtil_MoveUl.Click
        MoveUlViaHSTINB(txtUtil_Ulid.Text, txtUtil_DstLoc.Text)
    End Sub



    Private Sub UpdateAllWMSEventsfromICtoSC()
        Dim strSql As String
        Dim MsgResult As DialogResult
        Try

            MsgResult = MessageBox.Show("Are you really sure you want to update all WMS Events stuck in IC to SC ?", "WMS Database Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If MsgResult = DialogResult.No Then
                Exit Sub
            End If

            strSql = "update sl_evt_data set evt_stat_cd = 'SC' where evt_stat_CD = 'IC' "
            DBCON2.Execute(strSql)

            WriteLog(gcstrINFO, "Updated All WMS Events that were in IC to SC")

        Catch

            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try


    End Sub

    Private Sub UpdateEventsInICToSCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateEventsInICToSCToolStripMenuItem.Click
        UpdateAllWMSEventsfromICtoSC()
    End Sub

    Private Sub UpdateWMStoCurrentSessionId()
        Dim strSql As String
        Dim MsgResult As DialogResult
        Try

            MsgResult = MessageBox.Show("Are you really sure you want the WMS ASRS Location Session ID to " & gstrXML_WCS_ID & " ?", "WMS Database Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If MsgResult = DialogResult.No Then
                Exit Sub
            End If

            'dave need to come back and make this a little more solid inc ase session key does not exist etc
            strSql = "update locatn " &
                     "set session_sid=(select SESSION_SID from rtcis_session where session_key='" & gstrXML_WCS_ID & "') " &
                     "where " &
                     "locatn='" & gstrRTCISASRSSystemLocationName & "' " &
                     "and subsit='" & gstrFPDSSubsitCharacter & "'"

            DBCON2.Execute(strSql)

            WriteLog(gcstrINFO, "Updated WMS ASRS Location Session ID to " & gstrXML_WCS_ID)

        Catch

            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try
    End Sub
    Private Sub UpdateWMSSessionIDtoSendToMyIp()
        Dim strSql As String
        Dim MsgResult As DialogResult
        Try

            MsgResult = MessageBox.Show("Update the IP RTCIS Session ID " & gstrXML_WCS_ID & " sends to " & gstrLocalListenerIP & " ?", "WMS Database Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If MsgResult = DialogResult.No Then
                Exit Sub
            End If

            'dave need to come back and make this a little more solid inc ase session key does not exist etc
            strSql = "update RTCIS_SESSION " &
                     "set SND_HOSTNAME= '" & gstrLocalListenerIP & "' " &
                     "where " &
                    "session_key='" & gstrXML_WCS_ID & "' "


            DBCON2.Execute(strSql)

            WriteLog(gcstrINFO, "Updated WMS Session " & gstrXML_WCS_ID & " to send to hostname " & gstrLocalListenerIP)

        Catch

            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try
    End Sub
    Private Sub UpdateASRSSessionIDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateASRSSessionIDToolStripMenuItem.Click
        UpdateWMStoCurrentSessionId()
    End Sub

    Private Sub RemoveULIDfromRAID(ByVal strULID As String)
        Dim strSql As String
        Dim MsgResult As DialogResult
        Dim oRecordsAffected As Object = 0
        Try

            MsgResult = MessageBox.Show("Ok to Proceed  to remove the ULID " & strULID & " from CUST_PALLET and update CUST_LINETEM to null ?", "ConfirmRAID ULID Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If MsgResult = DialogResult.No Then
                Exit Sub
            End If

            strSql = "delete from cust_pallet where cust_id='" & strULID & "'"
            DBCON1.Execute(strSql, oRecordsAffected)
            WriteLog("Success", strSql & Space(1) & "Records:" & Space(1) & oRecordsAffected.ToString)

            strSql = "update cust_lineitem set cust_id=null where cust_id='" & strULID & "'"
            DBCON1.Execute(strSql, oRecordsAffected)
            WriteLog("Success", strSql & Space(1) & "Records:" & Space(1) & oRecordsAffected.ToString)



        Catch

            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try


    End Sub

    Private Sub ClearULIDFromDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearULIDFromDatabaseToolStripMenuItem.Click
        Dim strUserInput As String
        strUserInput = InputBox("ULID: ",
                        "ULID to Clear from RAID DB")
        If strUserInput.Length = 0 Then Exit Sub

        RemoveULIDfromRAID(strUserInput)
    End Sub

    Private Sub DTLDriverSendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTLDriverSendToolStripMenuItem.Click
        ShowIniForm("DTLDriverSend")
    End Sub

    Private Sub butFillStagedUlsInWMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFillStagedUlsInWMS.Click
        GetandDisplayStagedUlsInWMS()
    End Sub

    Private Sub flxGrid15_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid15.MouseDownEvent
        Dim strText As String
        strText = ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)

        If strText.Length = 19 Then
            Clipboard.SetDataObject(strText & Convert.ToString(Mod10CheckDigit(strText)))
        End If

    End Sub

    Private Sub flxGrid15_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flxGrid15.Enter

    End Sub


    Private Sub UpdateRTCSESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateRTCSESToolStripMenuItem.Click
        UpdateWMSSessionIDtoSendToMyIp()
    End Sub

    Private Sub butMsg7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMsg7.Click
        HstInbMsg7(txtMsg7ULID.Text, txtMsg7Dlvloc.Text)
    End Sub

    Private Sub ApplyDatabasePatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplyDatabasePatchToolStripMenuItem.Click
        ApplyDatabasePatch()
    End Sub

    Private Sub ApplyDatabasePatch()

        Dim strText As String = String.Empty

        For Each patch As String In AvailableDatabasePatches
            strText &= patch & vbCrLf
        Next

        Dim strUserInput As String
        strUserInput = Trim(InputBox("Available Patches:" & vbCrLf & vbCrLf & strText & vbCrLf & "Please Enter Patch to Apply: ",
                        "Apply RAID DB Patch"))
        If strUserInput.Length = 0 Then Exit Sub

        If Array.IndexOf(AvailableDatabasePatches, strUserInput) <> -1 Then

            ApplyDatabasePatches(strUserInput, True)
        Else
            WriteLog(gcstrError, "Entered Database Patch Does Not Exist: " & strUserInput)
        End If
    End Sub


    Private Sub flxGrid1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flxGrid1.Enter

    End Sub

    Private Sub flxGrid12_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flxGrid12.Enter

    End Sub

    Private Sub flxGrid12_MouseDownEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_MouseDownEvent) Handles flxGrid12.MouseDownEvent
        ProcessGridMouseDown(CType(sender, AxMSFlexGrid), e.button)
    End Sub
    'Private Sub btnTrlCkout_Click(sender As Object, e As EventArgs) Handles btnTrlCkout.Click
    '    WriteLog("Send", "Trailer Check-Out ")
    '    SendRequest(CreateXML_ForContainer(sender))
    'End Sub


    'Private Sub btnTrlCkin_Click(sender As Object, e As EventArgs) Handles btnTCin_TrlCkin.Click
    '    WriteLog("Send", "Trailer Check-In ")
    '    Dim strXmlTrlCi As String = CreateXML_ForContainer(sender)
    '    SendRequest(strXmlTrlCi)
    'End Sub

    Public Sub GetAndDisplayTrailerMoveData()

        'Attach the DataGridView Column Selector to the grid
        'so the user can hide/show the db columns.

        Dim dgvcs As DataGridViewColumnSelector = New DataGridViewColumnSelector(dGridTraMovData)
        'Dim dgvaf As DataGridVie


        Dim sqlQry As String

        'sqlQry = "SELECT    TCS_TRAILER_EMU.TCS_TRANSIT_NUM, TCS_TRAILER_EMU.TRUCK_LINE, TCS_TRAILER_EMU.TRAILER_NUMBER, TCS_TRAILER_EMU.TRACTOR_ID, 
        '                    TCS_TRAILER_EMU.TRAILER_TYPE, TCS_TRAILER_EMU.DRIVER_NAME, TCS_TRAILER_EMU.USABLE, TCS_TRAILER_EMU.UNUSABLE_REASON, 
        '                    TCS_TRAILER_EMU.EMPTY, TCS_TRAILER_EMU.SHIPMENT_ID, TCS_TRAILER_EMU.RR_NUMBER, TCS_TRAILER_EMU.INVOICE_NUMBER, 
        '                    TCS_TRAILER_EMU.BOL_NUMBER, TCS_TRAILER_EMU.SITE_NAME, TCS_TRAILER_EMU.LOCATION 
        '        FROM TCS_TRAILER_EMU  
        '        where 1=1  
        '        order by CTRL_DATE asc"



        sqlQry = "Select * FROM TCS_TRAILER_EMU  where 1=1 and ckin_stat = '0'"

        If chkBxTcsEmuEMUSessionOnly.Checked = True Then
            sqlQry += "and TCS_TRANSIT_NUM = '" + gstrXML_WCS_ID + "' "
        End If

        sqlQry += "order by CTRL_DATE asc"


        Dim da As System.Data.OleDb.OleDbDataAdapter
        Dim dt As DataTable
        Dim ds As DataSet

        Try
            da = New System.Data.OleDb.OleDbDataAdapter()
            dt = New DataTable()
            ds = New DataSet

            'dbrec1.Open(sqlQry, DBCON1, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly, 2)

            ' ==> User Below Options:=-1 for Query 
            dbrec1.Open(sqlQry, DBCON1, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, Options:=-1)

            ' ==> User Below Options:=2 for Table 
            'dbrec1.Open("TCS_TRAILER_EMU", DBCON1, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, 2)

            'da.Fill(ds, dbrec1, "TCS_TRAILER_EMU")
            da.Fill(dt, dbrec1)

            'dGridTraMovData.DataSource = ds.Tables("TCS_TRAILER_EMU")
            dGridTraMovData.DataSource = dt
            With dGridTraMovData
                .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                '.RowHeadersVisible = False
                '.Columns(0).Visible = False
                '.Columns.Item("SITNAM").Tag = CType("SITE_NAME", String)
                '.Columns.Item("SHIPID").Tag = CType("SHIPMENT_ID", String)
                '.Columns.Item("RRNUMB").Tag = CType("RR_NUMBER", String)
                '.Columns.Item("INVNUM").Tag = CType("INVOICE_NUMBER", String)
                '.Columns.Item("LIC_PLATE_NUM").Tag = CType("LICENSE_PLATE_NUMBER", String)
                '.Columns.Item("LIC_PLATE_STATE").Tag = CType("LICENSE_PLATE_STATE", String)
                '.Columns(1).HeaderCell.Value = "Truck Line"
                'For Each col As Column In .Columns
                '    col(""

                'Next
            End With

            'Close Recordset
            dbrec1.Close()

            'dGridTraMovData.Refresh()
            dGridTraMovData.AllowUserToAddRows = False
            dGridTraMovData.Show()

            ds.Dispose()
            dt.Dispose()
            da.Dispose()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & ex.Message)
            MsgBox("Error Loading Data Grid")

            dbrec1.Close()
        End Try

        'Hide the following columns on initial load, 
        'User can view the colum(s) data by selecting from the selector 

        dgvcs.DataGridView.Columns("LENGTH").Visible = False
        dgvcs.DataGridView.Columns("WIDTH").Visible = False
        dgvcs.DataGridView.Columns("HEIGHT").Visible = False
        dgvcs.DataGridView.Columns("EMPTY_WEIGHT").Visible = False
        dgvcs.DataGridView.Columns("FULL_WEIGHT").Visible = False
        dgvcs.DataGridView.Columns("EST_WEIGHT").Visible = False
        dgvcs.DataGridView.Columns("TEMP_CODE").Visible = False
        dgvcs.DataGridView.Columns("LICENSE_NUM").Visible = False
        dgvcs.DataGridView.Columns("LICENSE_STATE").Visible = False
        dgvcs.DataGridView.Columns("UNUSABLE_REASON").Visible = False
        dgvcs.DataGridView.Columns("ORIGIN").Visible = False
        dgvcs.DataGridView.Columns("CONTENTS").Visible = False
        dgvcs.DataGridView.Columns("FREIGHT_AMOUNT").Visible = False
        dgvcs.DataGridView.Columns("FREIGHT_CURRENCY").Visible = False
        dgvcs.DataGridView.Columns("CTRL_DATE").Visible = False
        dgvcs.DataGridView.Columns("CKIN_DATE").Visible = False
        dgvcs.DataGridView.Columns("CKOUT_DATE").Visible = False
        dgvcs.DataGridView.Columns("TRACTOR_CKIN_DATE").Visible = False
        dgvcs.DataGridView.Columns("CARRIER_ARRIVAL_DT").Visible = False
        dgvcs.DataGridView.Columns("SOURCE_SITE_NAME").Visible = False
        dgvcs.DataGridView.Columns("SOURCE_LOCATION").Visible = False
        dgvcs.DataGridView.Columns("DEST_SITE_NAME").Visible = False
        dgvcs.DataGridView.Columns("DEST_LOCATION").Visible = False
        dgvcs.DataGridView.Columns("REQUEST_ID").Visible = False
        dgvcs.DataGridView.Columns("DEVICE_ID").Visible = False
        dgvcs.DataGridView.Columns("USER_ID").Visible = False
        dgvcs.DataGridView.Columns("QUEUE_FLAG").Visible = False

    End Sub
    Private Sub GetAndDisplayTCSTrailerViewData(dgv As DataGridView, chkbbySession As CheckBox, chkbEmpty As CheckBox, chkbReadytoshp As CheckBox)
        Dim dgvcs As DataGridViewColumnSelector = New DataGridViewColumnSelector(dgv)

        Dim sqlQry As String
        '"Select TRKLIN,TRLNUM,TRACTOR_ID " +
        '    "from [TCS_TRAILER] " +
        '    "where 1=1 " +
        '    "order by TRKLIN,TRLNUM"
        sqlQry = "Select * FROM TCS_TRAILER where 1=1 "

        If (Not IsNothing(chkbbySession) And chkbbySession.Checked = True) Then
            sqlQry += " and TCS_SESSION_KEY ='" + gstrXML_WCS_ID + "' "
        End If

        If (Not IsNothing(chkbEmpty) And chkbEmpty.Checked = True) Then
            sqlQry += " and EMPTY='Y' "
        End If
        If (Not IsNothing(chkbReadytoshp) And chkbReadytoshp.Checked = True) Then
            sqlQry += " and READY_TO_SHIP = 'Y' "
        End If

        sqlQry += " order by TCS_SESSION_KEY, TRKLIN, TRLNUM, TRACTOR_ID"
        Dim da As System.Data.OleDb.OleDbDataAdapter
        Dim dt As DataTable
        Dim ds As DataSet
        Try
            da = New System.Data.OleDb.OleDbDataAdapter()
            dt = New DataTable()
            ds = New DataSet

            ' ==> User Below Options:=-1 for Query 
            dbrec2.Open(sqlQry, DBCON2, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, Options:=-1)
            ' ==> User Below Options:=2 for Table 

            'dbrec2.Open("TCS_TRAILER", DBCON2, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, 2)

            da.Fill(dt, dbrec2)

            'show number of rows.
            'lblWMSTCSTrlData.Text += "  (" + dbrec2.RecordCount.ToString + " rows )"

            dgv.DataSource = dt
            With dgv
                .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                '.RowHeadersVisible = False
                '.Columns(0).Visible = False
                .Columns.Item("TRKLIN").Tag = CType("TRUCK_LINE", String)
                .Columns.Item("TRLNUM").Tag = CType("TRAILER_NUMBER", String)
                .Columns.Item("EMPTY").Tag = CType("EMPTY", String)
                .Columns.Item("TRLTYP").Tag = CType("TRAILER_TYPE", String)
                .Columns.Item("ORIGIN").Tag = CType("ORIGIN", String)
                .Columns.Item("CONTNT").Tag = CType("CONTENTS", String)
                .Columns.Item("LENGTH").Tag = CType("LENGTH", String)
                .Columns.Item("WIDTH").Tag = CType("WIDTH", String)
                .Columns.Item("HEIGHT").Tag = CType("HEIGHT", String)
                .Columns.Item("EMPWGT").Tag = CType("EMPTY_WEIGHT", String)
                .Columns.Item("FULWGT").Tag = CType("FULL_WEIGHT", String)
                .Columns.Item("USABLE").Tag = CType("USABLE", String)
                .Columns.Item("REASON").Tag = CType("UNUSABLE_REASON", String)

                .Columns.Item("SHIPMENT_NUMBER").Tag = CType("SHIPMENT_ID", String)
                .Columns.Item("RRNUMB").Tag = CType("RR_NUMBER", String)
                .Columns.Item("INVNUM").Tag = CType("INVOICE_NUMBER", String)

                .Columns.Item("SITNAM").Tag = CType("SITE_NAME", String)
                .Columns.Item("LOCATN").Tag = CType("LOCATION", String)
                .Columns.Item("BLDING").Tag = CType("BUILDING", String)

                .Columns.Item("TRACTOR_ID").Tag = CType("TRACTOR_ID", String)
                .Columns.Item("CHKOUT_LIC_NO").Tag = CType("LICENSE_NUM", String)
                .Columns.Item("CHKOUT_LIC_ST").Tag = CType("LICENSE_STATE", String)
                .Columns.Item("CHKOUT_DRVNAM").Tag = CType("DRIVER_NAME", String)

                .Columns.Item("FREIGHT").Tag = CType("FREIGHT_AMOUNT", String)
                .Columns.Item("CURRENCY").Tag = CType("FREIGHT_CURRENCY", String)
                '.Columns.Item("TCS_TRANSIT_NUM").Tag = CType("TCS_TRAILER_TAG", String)
                .Columns.Item("TCS_TRANSIT_NUM").Tag = CType("TCS_TRANSIT_NUM", String)


                '.Columns(1).HeaderCell.Value = "Truck Line"
            End With

            'Close Recordset
            dbrec2.Close()

            'dGridTraMovData.Refresh()
            dgv.AllowUserToAddRows = False
            dgv.Show()

            ds.Dispose()
            dt.Dispose()
            da.Dispose()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & ex.Message)
            MsgBox("Error Loading Data TCS_TRAILER View Grid")
            dbrec2.Close()
        End Try

        dgvcs.DataGridView.Columns("TCS_SESSION_SID").Visible = False
        dgvcs.DataGridView.Columns("SUBSIT").Visible = False
        dgvcs.DataGridView.Columns("PNDSIT").Visible = False
        dgvcs.DataGridView.Columns("LENGTH").Visible = False
        dgvcs.DataGridView.Columns("WIDTH").Visible = False
        dgvcs.DataGridView.Columns("HEIGHT").Visible = False
        dgvcs.DataGridView.Columns("EMPWGT").Visible = False
        dgvcs.DataGridView.Columns("FULWGT").Visible = False
        dgvcs.DataGridView.Columns("CHKIN_DATE").Visible = False
        dgvcs.DataGridView.Columns("CHKIN_LIC_NO").Visible = False
        dgvcs.DataGridView.Columns("CHKIN_LIC_ST").Visible = False
        dgvcs.DataGridView.Columns("CHKIN_DRVNAM").Visible = False
        dgvcs.DataGridView.Columns("CHKIN_TRACTOR_ID").Visible = False
        dgvcs.DataGridView.Columns("LEGAL_ENTITY").Visible = False
        dgvcs.DataGridView.Columns("PONUMB").Visible = False
        dgvcs.DataGridView.Columns("SHPWGT").Visible = False
        dgvcs.DataGridView.Columns("PLN_NUMBER").Visible = False
        dgvcs.DataGridView.Columns("CSTNUM").Visible = False
        dgvcs.DataGridView.Columns("CSTNAM").Visible = False
        dgvcs.DataGridView.Columns("STREET").Visible = False
        dgvcs.DataGridView.Columns("CITY").Visible = False
        dgvcs.DataGridView.Columns("STATE").Visible = False
        dgvcs.DataGridView.Columns("LRDATE").Visible = False
        dgvcs.DataGridView.Columns("APPT_DATE").Visible = False
        dgvcs.DataGridView.Columns("APPT_NUMBER").Visible = False
        dgvcs.DataGridView.Columns("PARSNO").Visible = False
        dgvcs.DataGridView.Columns("SHIP_SEAL1").Visible = False
        dgvcs.DataGridView.Columns("SHIP_SEAL2").Visible = False
        dgvcs.DataGridView.Columns("RCP_SEAL1").Visible = False
        dgvcs.DataGridView.Columns("RCP_SEAL2").Visible = False

    End Sub

    Private Sub GetTCSLocationViewData()
        Dim dgvcs As DataGridViewColumnSelector = New DataGridViewColumnSelector(dgvTcsLocation)

        Dim sqlQry As String

        sqlQry = "Select * FROM TCS_LOCATION where 1=1 "
        sqlQry += " order by SITNAM, LOCATN, TRKLIN, TRLNUM"

        Dim da As System.Data.OleDb.OleDbDataAdapter
        Dim dt As DataTable
        Dim ds As DataSet
        Try
            da = New System.Data.OleDb.OleDbDataAdapter()
            dt = New DataTable()
            ds = New DataSet

            ' ==> User Below Options:=-1 for Query 
            'dbrec2.Open(sqlQry, DBCON2, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, Options:=-1)
            ' ==> User Below Options:=2 for Table 

            dbrec2.Open("TCS_LOCATION", DBCON2, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, 2)

            da.Fill(dt, dbrec2)

            dgvTcsLocation.DataSource = dt
            With dgvTcsLocation
                .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                '.RowHeadersVisible = False
                '.Columns(0).Visible = False
                .Columns.Item("SITNAM").Tag = CType("SITE_NAME", String)
                .Columns.Item("BLDING").Tag = CType("BUILDING", String)
                .Columns.Item("LOCATN").Tag = CType("LOCATION", String)
                .Columns.Item("TRKLIN").Tag = CType("TRUCK_LINE", String)
                .Columns.Item("TRLNUM").Tag = CType("TRAILER_NUMBER", String)
                '.Columns(1).HeaderCell.Value = "Truck Line"
            End With

            'Close Recordset
            dbrec2.Close()

            'dgvTcsLocation.Refresh()
            dgvTcsLocation.AllowUserToAddRows = False
            dgvTcsLocation.Show()

            ds.Dispose()
            dt.Dispose()
            da.Dispose()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & ex.Message)
            MsgBox("Error Loading Data TCS_LOCATION View Grid")
            dbrec2.Close()
        End Try
        dgvcs.DataGridView.Columns("SUBSIT").Visible = False
        dgvcs.DataGridView.Columns("SERFLG").Visible = False
        dgvcs.DataGridView.Columns("PND_TRLCNT").Visible = False


    End Sub

    Private Sub GetTCSTrailerReqViewData(dgv As DataGridView, chkb As CheckBox)
        Dim dgvcs As DataGridViewColumnSelector = New DataGridViewColumnSelector(dgv)

        Dim sqlQry As String

        sqlQry = "Select * FROM TCS_TRAILER_REQ where 1=1 "

        If (chkb.Checked = True) Then
            sqlQry += " and TCS_SESSION_KEY ='" + gstrXML_WCS_ID + "' "
        End If

        sqlQry += " order by TCS_SESSION_KEY, TRKLIN, TRLNUM"

        Dim da As System.Data.OleDb.OleDbDataAdapter
        Dim dt As DataTable
        Dim ds As DataSet
        Try
            da = New System.Data.OleDb.OleDbDataAdapter()
            dt = New DataTable()
            ds = New DataSet

            ' ==> User Below Options:=-1 for Query 
            dbrec2.Open(sqlQry, DBCON2, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, Options:=-1)
            ' ==> User Below Options:=2 for Table 

            'dbrec2.Open("TCS_TRAILER", DBCON2, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, 2)

            da.Fill(dt, dbrec2)

            dgv.DataSource = dt
            With dgv
                .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                '.RowHeadersVisible = False
                '.Columns(0).Visible = False
                .Columns.Item("TRLREQ").Tag = CType("REQUEST_ID", String)
                .Columns.Item("TRKLIN").Tag = CType("TRUCK_LINE", String)
                .Columns.Item("TRLNUM").Tag = CType("TRAILER_NUMBER", String)
                .Columns.Item("SITNAM").Tag = CType("SITE_NAME", String)
                .Columns.Item("BLDING").Tag = CType("BUILDING", String)
                .Columns.Item("LOCATN").Tag = CType("LOCATION", String)
                .Columns.Item("PND_SITNAM").Tag = CType("DEST_SITE_NAME", String)
                .Columns.Item("PNDLOC").Tag = CType("DEST_LOCATION", String)
                .Columns.Item("PRIORITY").Tag = CType("PRIORITY", String)
                '.Columns(1).HeaderCell.Value = "Truck Line"
            End With

            'Close Recordset
            dbrec2.Close()

            'dgvTcsLocation.Refresh()
            dgv.AllowUserToAddRows = False
            dgv.Show()

            ds.Dispose()
            dt.Dispose()
            da.Dispose()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & ex.Message)
            MsgBox("Error Loading Data TCS_TRAILER_REQ View Grid")
            dbrec2.Close()
        End Try
        dgvcs.DataGridView.Columns("SUBSIT").Visible = False
        dgvcs.DataGridView.Columns("PNDSIT").Visible = False
        dgvcs.DataGridView.Columns("TCS_SESSION_SID").Visible = False

    End Sub



    Private Sub tabPgTrlMovEmu_Enter(sender As Object, e As EventArgs) Handles tabPgTrlMovEmu.Enter


        'TRAILER CHECKIN/CHECKOUT PAGE
        'Trailer Checkin 
        btnTrlMovTCkin.Tag = CType(TRAILER_CKIN_BUTTON_TAG_ARRAY, Object())

        'trailer checkout
        btnTrlMovTCkout.Tag = CType(TRAILER_CKOUT_BUTTON_TAG_ARRAY, Object())

        'Assign Shipment 
        btnTrlMovAsgnShpRcp.Tag = CType(TRAILER_SHP_RCP_ASGNMT_BTN_TAG_ARRAY, Object())

        'Trailer Location Request
        btnTrlMovTLocAsgn.Tag = CType(TRAILER_LOCATION_REQUEST_BUTTON_TAG_ARRAY, Object())

        'TRAILER MOVEMENT PAGE

        'Trailer Location Request 
        btnTrlMovTrlLocReq.Tag = CType(TRAILER_LOCATION_REQUEST_ON_MOVEMNT_BUTTON_TAG_ARRAY, Object())
        'Trailer Location Update
        btnTrlMovTrlLocUpd.Tag = CType(TRAILER_LOC_UPDATE_BUTTON_TAG_ARRAY, Object())
        'Trailer Move Cancel
        btnTrlMovTrlMovCancel.Tag = CType(TRAILER_MOVE_CANCEL_BUTTON_TAG_ARRAY, Object())
        'Trailer Change Priority
        btnTrlMovTrlChgPriority.Tag = CType(TRAILER_MOVE_CHANGE_PRIORITY_BUTTON_TAG_ARRAY, Object())

        'Trailer Move Execution 

        'Trailer Mover Pickup / Hook 
        btnTrlMovTrlMovPickup.Tag = CType(TRAILER_MOVE_PICKUP_BUTTON_TAG_ARRAY, Object())
        'Trailer Move Complete / Unhook
        btnTrlMovTrlMovComp.Tag = CType(TRAILER_MOVE_COMPL_BUTTON_TAG_ARRAY, Object())
        'Trailer Move Cancel
        btnTrlMovExecTrlMovCancel.Tag = CType(TRAILER_MOVE_CANCEL_EXEC_BUTTON_TAG_ARRAY, Object())
        'Trailer Change Priority 
        btnTrlMovExecTrlChgPriority.Tag = CType(TRAILER_MOVE_EXEC_CHANGE_PRIORITY_BUTTON_TAG_ARRAY, Object())




        TabPageSelected(CType(sender, TabPage))

        'EMULATOR DATA 
        chkBxTcsEmuEMUSessionOnly.Text = gstrXML_WCS_ID + " Session data only"

        'TRAILER CHECKIN/CHECKOUT TAB
        chkBxTcsEmuWMSSessOnly.Text = gstrXML_WCS_ID + " Session data only"
        'TRAILER MOVEMENT TAB
        chkBxTcsEmuTrlMovWMSSessOnly.Text = gstrXML_WCS_ID + " Session data only"
        chkbTrlMvmtThisSessionOnly.Text = gstrXML_WCS_ID + " Session data only"

        'TRAILER MOVE EXECUTION TAB
        chkbTCSTrlExecCurSessOnly.Text = gstrXML_WCS_ID + " Session data only"

        ' Load the Activity Grid
        Load_TCS_TRAILER_EMU(dgvTrlActivityData)


        'Dim tcsTransDict As New Dictionary(Of String, Object())
        'tcsTransDict.Add(TRL_CKIN_TAG, TRAILER_CKIN_BUTTON_TAG_ARRAY)
        'tcsTransDict.Add(TRL_CKIN_CONF_TAG, TRL_CKIN_INB_CONF_MSG_ARRAY)

        'tcsTransDict.Add(TRL_LOC_REQUEST_TAG, TRAILER_LOCATION_REQUEST_BUTTON_TAG_ARRAY)
        'tcsTransDict.Add(TRL_LOC_ASSG_CONF_TAG, TRL_LOC_ASSG_CONF_MSG_ARRAY)

        'tcsTransDict.Add(TRL_SHPRCP_REQUEST_TAG, TRAILER_SHP_RCP_ASGNMT_BTN_TAG_ARRAY)
        'tcsTransDict.Add(TRL_SHPRCP_ASG_CONF_TAG, TRL_SHPRCP_ASG_CONF_TAG_ARRAY)

        'tcsTransDict.Add(TRL_CKOUT_TAG, TRAILER_CKOUT_BUTTON_TAG_ARRAY)
        'tcsTransDict.Add(TRL_CKOUT_CONF_TAG, TRL_CKOUT_CONF_TAG_ARRAY)

        'tcsTransDict.Add(TRL_SHPRCP_REQUEST_TAG, TRAILER_SHP_RCP_ASGNMT_BTN_TAG_ARRAY)
        'tcsTransDict.Add(TRL_SHPRCP_ASG_CONF_TAG, TRL_SHPRCP_ASG_CONF_TAG_ARRAY)

        'tcsTransDict.Add(TRL_LOC_UPDATE_TAG, TRAILER_LOC_UPDATE_BUTTON_TAG_ARRAY)
        'tcsTransDict.Add(TRL_LOC_UPDATE_CONF_TAG, TRL_LOC_UPDATE_CONF_TAG_ARRAY)



        'tabPgTrlMovEmu.Tag = CType(tcsTransDict, Dictionary(Of String, Object()))

    End Sub

    Private Sub btnTrlMovTAnyButton_Click(sender As Object, e As EventArgs) _
        Handles btnTrlMovTCkin.Click,   'Trailer Checkin/Checkout Tab
                btnTrlMovTCkout.Click,
                btnTrlMovAsgnShpRcp.Click,
                btnTrlMovTLocAsgn.Click,
                btnTrlMovTrlLocReq.Click,   'Trailer Movement Tab
                btnTrlMovTrlLocUpd.Click,
                btnTrlMovTrlMovCancel.Click,
                btnTrlMovTrlChgPriority.Click,
                btnTrlMovTrlMovPickup.Click,    'Trailer Move Execution
                btnTrlMovTrlMovComp.Click,
                btnTrlMovExecTrlMovCancel.Click,
                btnTrlMovExecTrlChgPriority.Click


        'This is a generic click event for all the button click events for the buttons it handles .
        WriteLog("Send", "Event For - " + CType(sender, Button).Text)

        'SendRequest(CreateXML_ForAction(sender))
        CreateXML_ForAction(sender)

    End Sub


    Private Sub highlightOnHoverOverButton_MouseHover(sender As Object, e As EventArgs) _
        Handles btnTrlMovTCkin.MouseHover, btnTrlMovTCkin.GotFocus,     'Trailer Checkin/Checkout 
                btnTrlMovTCkout.MouseHover, btnTrlMovTCkout.GotFocus,
                btnTrlMovAsgnShpRcp.MouseHover, btnTrlMovAsgnShpRcp.GotFocus,
                btnTrlMovTLocAsgn.MouseHover, btnTrlMovTLocAsgn.GotFocus,
                btnTrlMovTrlLocReq.MouseHover, btnTrlMovTrlLocReq.GotFocus,     'Trailer Movement 
                btnTrlMovTrlLocUpd.MouseHover, btnTrlMovTrlLocUpd.GotFocus,
                btnTrlMovTrlMovCancel.MouseHover, btnTrlMovTrlMovCancel.GotFocus,
                btnTrlMovTrlChgPriority.MouseHover, btnTrlMovTrlChgPriority.GotFocus,
                btnTrlMovTrlMovPickup.MouseHover, btnTrlMovTrlMovPickup.GotFocus,     'Trailer Move Execution
                btnTrlMovTrlMovComp.MouseHover, btnTrlMovTrlMovComp.GotFocus,
                btnTrlMovExecTrlMovCancel.MouseHover, btnTrlMovExecTrlMovCancel.GotFocus,
                btnTrlMovExecTrlChgPriority.MouseHover, btnTrlMovExecTrlChgPriority.GotFocus

        highlightTaggedControls(sender, HIGHLIGHT_FIELD_COLOR)

    End Sub

    Private Sub highlightOnHoverOverButton_MouseLeave(sender As Object, e As EventArgs) _
    Handles btnTrlMovTCkin.MouseLeave, btnTrlMovTCkin.LostFocus,
            btnTrlMovTCkout.MouseLeave, btnTrlMovTCkout.LostFocus,
            btnTrlMovAsgnShpRcp.MouseLeave, btnTrlMovAsgnShpRcp.LostFocus,
            btnTrlMovTLocAsgn.MouseLeave, btnTrlMovTLocAsgn.LostFocus,
            btnTrlMovTrlLocReq.MouseLeave, btnTrlMovTrlLocReq.LostFocus,     'Trailer Movement 
            btnTrlMovTrlLocUpd.MouseLeave, btnTrlMovTrlLocUpd.LostFocus,
            btnTrlMovTrlMovCancel.MouseLeave, btnTrlMovTrlMovCancel.LostFocus,
            btnTrlMovTrlChgPriority.MouseLeave, btnTrlMovTrlChgPriority.LostFocus,
            btnTrlMovTrlMovPickup.MouseLeave, btnTrlMovTrlMovPickup.LostFocus,     'Trailer Move Execution
            btnTrlMovTrlMovComp.MouseLeave, btnTrlMovTrlMovComp.LostFocus,
            btnTrlMovExecTrlMovCancel.MouseLeave, btnTrlMovExecTrlMovCancel.LostFocus,
            btnTrlMovExecTrlChgPriority.MouseLeave, btnTrlMovExecTrlChgPriority.LostFocus


        highlightTaggedControls(sender, HIGHLIGHT_FIELD_RESET_COLOR)

    End Sub
    Private Sub DeleteTCSTRAILERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteTCSTRAILERToolStripMenuItem.Click
        DeleteAllDatafromEmulatorDBTable("TCS_TRAILER_EMU", True)
        GetAndDisplayTrailerMoveData()
    End Sub

    Private Sub chkBxTcsEmuEMUSessionOnly_CheckedChanged(sender As Object, e As EventArgs) Handles chkBxTcsEmuEMUSessionOnly.CheckedChanged
        GetAndDisplayTrailerMoveData()
    End Sub
    Private Sub dGridTraMovData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGridTraMovData.CellClick
        Dim row As DataGridViewRow
        'Dim cell As DataGridViewCell
        'if you click on the column header 
        If (e.RowIndex < 0) Then
            Exit Sub
        End If
        row = dGridTraMovData.Rows(e.RowIndex)


        For Each r As DataGridViewRow In dGridTraMovData.Rows
            r.Selected = False
        Next
        row.Selected = True

        loadFormDataFromGrid(row, gbTrailerMovMain)

    End Sub

    'TCS EMULATRO -- TRAILER CHECKIN/CHECKOUT TAB HANDLERS
    Private Sub btnGetTrlMovData_Click(sender As Object, e As EventArgs) Handles btnGetTrlMovData.Click
        'Load TCS_TRAILER_EMU Data
        'GetAndDisplayTrailerMoveData()
        'Load TCS_TRAILER View Data
        GetAndDisplayTCSTrailerViewData(dGridTCSTrlViewData, chkBxTcsEmuWMSSessOnly, chkBxTcsEmuWMSEmpty, chkBxTcsEmuWMSReadyToShip)

    End Sub

    Private Sub dGridTCSTrlViewData_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dGridTCSTrlViewData.RowEnter
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = True
        loadFormDataFromGrid(CType(sender, DataGridView).Rows(e.RowIndex), gbTrailerMovMain)
    End Sub
    Private Sub dGridTCSTrlViewData_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dGridTCSTrlViewData.RowLeave
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = False
    End Sub
    Private Sub btnTrlMovReset_Click(sender As Object, e As EventArgs) Handles btnTrlMovReset.Click
        'Dim ctrllst As List(Of Control) = getAllCtrlList(gbTrailerMovMain)
        clearAllControls(CType(sender, Button), getAllCtrlList(gbTrailerMovMain))
    End Sub

    'TCS EMULATRO -- TRAILER MOVEMENT TAB HANDLERS
    Private Sub btnLoadTrailerMovData_Click(sender As Object, e As EventArgs) Handles btnLoadTrailerMovData.Click
        GetAndDisplayTCSTrailerViewData(dgvTrlMvmtTCSTrailerView, chkbTrlMvmtThisSessionOnly, chkbTrlMvmtShowEmpty, chkbTrlMvmtReadyToShip)
        GetTCSTrailerReqViewData(dgvTcsTrailerReq, chkBxTcsEmuTrlMovWMSSessOnly)
    End Sub

    Private Sub dgvTrlMvmtTCSTrailerView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTrlMvmtTCSTrailerView.RowEnter
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = True
        loadFormDataFromGrid(CType(sender, DataGridView).Rows(e.RowIndex), gbxTrailerMovement)
    End Sub

    Private Sub dgvTrlMvmtTCSTrailerView_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTrlMvmtTCSTrailerView.RowLeave
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = False
    End Sub
    Private Sub dgvTcsTrailerReq_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTcsTrailerReq.RowEnter
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = True
        loadFormDataFromGrid(CType(sender, DataGridView).Rows(e.RowIndex), gbxTrailerMovement)
    End Sub

    Private Sub dgvTcsTrailerReq_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTcsTrailerReq.RowLeave
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = False
    End Sub


    Private Sub btnTrlMovementReset_Click(sender As Object, e As EventArgs) Handles btnTrlMovementReset.Click
        clearAllControls(CType(sender, Button), getAllCtrlList(gbxTrailerMovement))
    End Sub

    'TCS EMULATRO -- TRAILER MOVE EXECUTION TAB HANDLERS
    Private Sub btnLoadTrlExecTrlReqData_Click(sender As Object, e As EventArgs) Handles btnLoadTrlExecTrlReqData.Click
        GetTCSLocationViewData()
        GetTCSTrailerReqViewData(dgTCSTrlReqbySessionViewData, chkbTCSTrlExecCurSessOnly)
    End Sub

    Private Sub btnTrlMovExecReset_Click(sender As Object, e As EventArgs) Handles btnTrlMovExecReset.Click
        clearAllControls(CType(sender, Button), getAllCtrlList(gbxTrailerMoveExec))
    End Sub

    Private Sub dgvTcsLocation_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTcsLocation.RowEnter
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = True
        loadFormDataFromGrid(CType(sender, DataGridView).Rows(e.RowIndex), gbxTrailerMoveExec)
    End Sub
    Private Sub dgvTcsLocation_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTcsLocation.RowLeave
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = False
    End Sub

    Private Sub dgTCSTrlReqbySessionViewData_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTCSTrlReqbySessionViewData.RowEnter
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = True
        loadFormDataFromGrid(CType(sender, DataGridView).Rows(e.RowIndex), gbxTrailerMoveExec)
    End Sub

    Private Sub dgTCSTrlReqbySessionViewData_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgTCSTrlReqbySessionViewData.RowLeave
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = False
    End Sub

    Private Sub dgvTrlActivityData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTrlActivityData.CellContentClick
        'Load_TCS_TRAILER_EMU(dgvTrlActivityData)
    End Sub

    Private Sub btnTCSEmuViewData_Click(sender As Object, e As EventArgs) Handles btnTCSEmuViewData.Click
        Dim row As DataGridViewRow = dgvTrlActivityData.CurrentRow
        Dim xmlStr As String = getXmlOfRow(row, CType(tabPgTrlMovEmu.Tag, Dictionary(Of String, Object())))
        gstrLastXMLSent = xmlStr
        Dim formXMLEditor As New frmXMLEditor
        formXMLEditor.ProcessData = True
        formXMLEditor.DataGridRow = row
        formXMLEditor.ShowDialog()
    End Sub

    Private Sub dgvTrlActivityData_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTrlActivityData.RowEnter
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub dgvTrlActivityData_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTrlActivityData.RowLeave
        CType(sender, DataGridView).Rows(e.RowIndex).Selected = False
    End Sub

    Private Sub TCSConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TCSConfigToolStripMenuItem.Click
        ShowIniForm("TCSConfig")
    End Sub

    Private Sub btnLoadActivityData_Click(sender As Object, e As EventArgs) Handles btnLoadActivityData.Click
        Load_TCS_TRAILER_EMU(dgvTrlActivityData)
    End Sub
End Class
