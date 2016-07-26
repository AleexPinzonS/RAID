Option Strict On
Option Explicit On
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Reflection.MethodBase    'used to get procedure name for error logging

Module Declarations

    'dave to do
    '\\\\\\\MSg13 C(ancel)
    'redo autoscan off and on to use a sub  (liek MSg21 is now)

    Public gInstancePrefix As String = ""
    Public gApplication_ProductName As String = Application.ProductName

    Public gstrProgramDataPath As String
    Public gstrIniFileName As String
    Public gstrPassIniSection As String
    Public gcstrIniOutbound As String = "Outbound"

    Public gbNewInboundData As Boolean
    Public gbNewOutboundData As Boolean

    Public gstrLocalListenerIP As String
    Public gstrSocketPort() As String
    Public ciMaxSocketListeningPorts As Integer = 10
    Public gbLogRawInboundData As Boolean

    Public giKeepLogDays As Integer

    'color setting
    Public colorFore As Color
    Public colorBack As Color

    Public cstrLogFilePrefix As String = gApplication_ProductName + "_"
    'IIf(Len(gInstancePrefix) > 0, gInstancePrefix + Application.ProductName + "_", Application.ProductName + "_").ToString

    'Public cstrLogFilePrefix As String = Application.ProductName & "_"

    'Variables to hold UserName,Password, and Oracle TNS Name:
    Public DBUserName As String
    Public DBPassword As String
    Public DBServer As String
    Public DBSid As String

    Public strConnectStringMDB As String
    Public gMdbFileName As String

    'ADO DB Objects:
    Public DBCON1 As ADODB.Connection
    Public dbrec1 As ADODB.Recordset
    Public DBCON2 As ADODB.Connection
    Public dbrec2 As ADODB.Recordset


    Public oDataBaseConnection As DatabaseConnections
    Public gstrDatabaseType As String

    Public IniEntries() As IniType
    Public IniRecordCount As Integer

    'these are for outbound
    Public gstrSetSocketServerIPtoMyIP As String
    Public gstrSocketServerIP As String
    Public gstrSocketServerPort As String
    Public gstrDefaultFolderForXMLFiles As String
    Public gstrXSDFileName As String
    Public gstrLastXMLSent As String


    'xml messaging settings
    Public gstrXML_WCS_ID As String

    Public gstrIPAddressOverrideLocalPC As String

    'misc config
    Public giDaysOfMsg16HistoryToDisplay As Integer
    Public giMessageLogLevel As Integer = 0
    Public giMaxLinesCurrentSystemLogFile As Integer

    'control config
    Public gbEditXMLBeforeSend As Boolean
    Public gbPreventDBUpdatesAfterMessage As Boolean


    'timer related
    Public giAutoHeartBeatSendIntervalMilliSeconds As Integer
    Public giMaxNumMsgsByMsgToSendPerTimerInterval As Integer
    Public giAutoScanIntervalSeconds As Integer
    Public gbAtLeastOneAutoScanFunctionActive As Boolean

    'unit load creation
    Public giLastULIDUsed As Integer
    Public gstrULIDPrefix As String

    'infeed configuration
    Public gstrFPDSSubsitCharacter As String
    Public gstrASRSSystemLocationName As String
    Public gstrRejectLocation As String
    Public FPDSLocations As String()
    Public FPDSLocationsRecordCount As Integer
    Public gstrFPDSLocationsSQL As String
    Public InfeedLocationsA8 As String()
    Public InfeedLocationsL8 As String()
    Public InfeedLocationsU8 As String()
    Public InfeedLocationsC8 As String()
    Public Activ_Input_Conveyors As String()
    Public gstrRTCISASRSSystemLocationName As String
    Public giInfeedMilliSecTimeDelayBetweenMsgs As Integer
    Public gbUseAlternateMsg567Induction As Boolean
    Public gbShowOnlyTheBaseStackedULID As Boolean
    Public gstrM35Activ_Input_ConveyorsPrefix As String

    Public giMaxNumUlRecordsRTCISInfeedToQuery As Integer

    'dtl driver send
    Public gstrDtldrvsndTermEmuProcessName As String
    Public gstrDtldrvsndTermEmuWindowTitle As String
    Public gstrDtldrvsndMsg5UlWeight As String
    Public gstrDtldrvsndMsg5DeliveryCode As String
    Public gstrDtldrvsndMsg5UnitLoadStatus As String
    Public gstrDtldrvsndMsg5StationId As String
    Public gstrDtldrvsndMsg5PortId As String

    'manual withdrawal
    Public gstrDefaultWithdrawalOutputMins As String
    Public ManualOutputLocations As String()
    Public ManualOutputLocationsRecordCount As Integer
    Public gstrManualOutputLocationsSQL As String
    Public gstrManualOutputVTLPrefix As String

    'outbound side
    Public giMaxUnitLoadsPerSlot As Integer
    Public gbStage1MorePalletAfterA26Received As Boolean
    Public gbSendResponseToSlotSignOn As Boolean
    Public gstrNumberofMessagesforStackedPallet As String
    Public ActivLevelIds As String()
    Public ActivLevelIdsRecordCount As Integer
    Public Slots As String()
    Public SlotsRecordCount As Integer
    Public gstrSlotsSQL As String

    Public gFirstMsgInTimeStamp As Date
    Public gFirstMsgOutTimeStamp As Date
    Public gLastMsgInTimeStamp As Date
    Public gLastMsgOutTimeStamp As Date
    Public giMsgInCount As Integer
    Public giMsgOutCount As Integer
    Public Structure IniType
        Dim SectionName As String
        Dim KeyName As String
        Dim Value As String
        Dim Numeric As Boolean
        Dim ZeroAllowed As Boolean
    End Structure

    'TCS Config Section
    Public gTCSAutoConfirmTCSInbounds As Boolean = True
    Public gstrTCSAutoConfDelaySec As Integer
    Public gstrAtuoLoadTCSGrids As String = "N"



    Public Sub Ini_Main()

        Dim lpSectionName As String
        Dim oini As ini

        oini = New ini

        IniRecordCount = 0
        ReDim IniEntries(0)

        'gstrIniFileName = gstrProgramDataPath & Application.ProductName & ".ini"
        gstrIniFileName = gstrProgramDataPath & gApplication_ProductName & ".ini"


        WriteLog("Initialize ", "Using Ini File " + gstrIniFileName)

        'Get Data for the individual ini sections

        lpSectionName = "Config"
        iniConfig(oini, gstrIniFileName, lpSectionName)

        lpSectionName = "SocketCommunication"
        iniSocketCommunication(oini, gstrIniFileName, lpSectionName)

        lpSectionName = "SocketListeningPorts"
        iniSocketListeningPorts(oini, gstrIniFileName, lpSectionName)

        lpSectionName = "LastDBLogin"
        iniLastDBLogin(oini, gstrIniFileName, lpSectionName)

        lpSectionName = "Infeed"
        iniInfeed(oini, gstrIniFileName, lpSectionName)

        lpSectionName = "ManualOutputRequests"
        iniManualOutputRequests(oini, gstrIniFileName, lpSectionName)

        lpSectionName = "HostInbound"
        iniHostInbound(oini, gstrIniFileName, lpSectionName)

        lpSectionName = gcstrIniOutbound
        iniOutbound(oini, gstrIniFileName, lpSectionName)

        lpSectionName = "DTLDriverSend"
        iniDTLDriverSend(oini, gstrIniFileName, lpSectionName)

        lpSectionName = "TCSConfig"
        iniTCSConfig(oini, gstrIniFileName, lpSectionName)

    End Sub



    Private Sub iniConfig(ByVal oini As ini, ByVal strIniFileName As String, ByVal lpSectionName As String)
        Dim lpKeyName As String
        Dim strValue As String
        Dim iDefaultValue1 As Integer = 1
        Dim iDefaultValue4 As Integer = 4
        Dim iDefaultValue10 As Integer = 10
        Dim ZeroOk As Boolean

        Try

            lpKeyName = "DatabaseType"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrACCESS, strIniFileName)
            gstrDatabaseType = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "KeepLogDays"
            ZeroOk = False
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "7", strIniFileName)
            strValue = ValidateIniNumericEntry(strValue, 7, ZeroOk)
            giKeepLogDays = CInt(strValue)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)

            lpKeyName = "MaxLinesCurrentSystemLogFile"
            ZeroOk = False
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "5000", strIniFileName)
            strValue = ValidateIniNumericEntry(strValue, 5000, ZeroOk)
            giMaxLinesCurrentSystemLogFile = CInt(strValue)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)

            lpKeyName = "MessageLogLevel"
            ZeroOk = True
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "1", strIniFileName)
            strValue = ValidateIniNumericEntry(strValue, 1, ZeroOk)
            giMessageLogLevel = CInt(strValue)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)

            lpKeyName = "DefaultFolderForXMLFiles"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "c:\", strIniFileName)
            gstrDefaultFolderForXMLFiles = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "XSDFileName"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrNA, strIniFileName)
            gstrXSDFileName = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "WCS_ID"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "PBLWCS", strIniFileName)
            gstrXML_WCS_ID = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "AutoHeartBeatSendIntervalMilliSeconds"
            ZeroOk = False
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "5000", strIniFileName)
            strValue = ValidateIniNumericEntry(strValue, 5000, ZeroOk)
            giAutoHeartBeatSendIntervalMilliSeconds = CInt(strValue)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)

            lpKeyName = "DaysOfMsg16HistoryToDisplay"
            ZeroOk = False
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, iDefaultValue1.ToString, strIniFileName)
            strValue = ValidateIniNumericEntry(strValue, iDefaultValue1, ZeroOk)
            giDaysOfMsg16HistoryToDisplay = CInt(strValue)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)

            lpKeyName = "AutoScanIntervalSeconds"
            ZeroOk = False
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, iDefaultValue10.ToString, strIniFileName)
            strValue = ValidateIniNumericEntry(strValue, iDefaultValue10, ZeroOk)
            'timers cant be 0!
            giAutoScanIntervalSeconds = CInt(strValue)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)

            lpKeyName = "MaxNumMsgsByMsgToSendPerTimerInterval"
            ZeroOk = False
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, iDefaultValue4.ToString, strIniFileName)
            strValue = ValidateIniNumericEntry(strValue, iDefaultValue4, ZeroOk)
            giMaxNumMsgsByMsgToSendPerTimerInterval = CInt(strValue)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)

        Catch

        End Try

    End Sub
    Private Sub iniSocketCommunication(ByVal oini As ini, ByVal strIniFileName As String, ByVal lpSectionName As String)
        Dim lpKeyName As String
        Dim strValue As String
        Dim ZeroOk As Boolean

        Try

            lpKeyName = "IPAddressOverrideLocalPC"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "", strIniFileName)
            gstrIPAddressOverrideLocalPC = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "SetSocketServerIPtoMyIP"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "N", strIniFileName)
            gstrSetSocketServerIPtoMyIP = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "SocketServerIP"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "155.155.155.155", strIniFileName)
            If gstrSetSocketServerIPtoMyIP = gcstrY Then
                gstrSocketServerIP = GetIPAddress()
            Else
                gstrSocketServerIP = strValue
            End If
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, gstrSocketServerIP)

            lpKeyName = "SocketServerPort"
            ZeroOk = False
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "13002", strIniFileName)
            strValue = ValidateIniNumericEntry(strValue, 13002, ZeroOk)
            gstrSocketServerPort = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)

            lpKeyName = "LogRawInboundData"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "N", strIniFileName)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)
            If strValue = "Y" Then
                gbLogRawInboundData = True
            Else
                gbLogRawInboundData = False

            End If



        Catch

        End Try

    End Sub
    Private Sub iniSocketListeningPorts(ByVal oini As ini, ByVal strIniFileName As String, ByVal lpSectionName As String)
        Dim lpKeyName As String
        Dim strValue As String

        Dim x As Integer

        Try

            ReDim gstrSocketPort(ciMaxSocketListeningPorts)

            For x = 1 To ciMaxSocketListeningPorts

                lpKeyName = "ListenPort" & x.ToString
                strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "0", strIniFileName)
                gstrSocketPort(x) = strValue

                Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            Next

        Catch

        End Try

    End Sub
    Private Sub iniInfeed(ByVal oini As ini, ByVal strIniFileName As String, ByVal lpSectionName As String)
        Dim lpKeyName As String
        Dim strValue As String
        Dim x As Integer
        Dim iDefaultValue4 As Integer = 4
        Dim iDefaultValue5 As Integer = 5
        Dim zerook As Boolean
        Try

            lpKeyName = "ASRSSystemLocationName"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "ASRS", strIniFileName)
            gstrASRSSystemLocationName = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "RTCISASRSSystemLocationName"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "CIMAT", strIniFileName)
            gstrRTCISASRSSystemLocationName = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "RejectLocation"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "REJECT", strIniFileName)
            gstrRejectLocation = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "InfeedMilliSecTimeDelayBetweenMsgs"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "1000", strIniFileName)
            If IsNumeric(strValue) = False Then
                giInfeedMilliSecTimeDelayBetweenMsgs = 1000
            Else
                giInfeedMilliSecTimeDelayBetweenMsgs = CInt(strValue)
            End If
            If giInfeedMilliSecTimeDelayBetweenMsgs < 0 Then
                giInfeedMilliSecTimeDelayBetweenMsgs = 0
            End If
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, Convert.ToString(giInfeedMilliSecTimeDelayBetweenMsgs))

            lpKeyName = "FPDSSubsitCharacter"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "0", strIniFileName)
            gstrFPDSSubsitCharacter = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "FPDSLocations"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrNA, strIniFileName).ToUpper
            strValue = Strings.Replace(strValue, " ", String.Empty)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)


            ReDim FPDSLocations(0)
            FPDSLocationsRecordCount = 0

            If Strings.Len(strValue) > 0 And strValue <> gcstrNA Then
                FPDSLocations = strValue.Split(gcCharComma)
                FPDSLocationsRecordCount = FPDSLocations.GetUpperBound(0) + 1

            End If

            gstrFPDSLocationsSQL = String.Empty
            For x = 1 To FPDSLocationsRecordCount
                If x > 1 Then
                    gstrFPDSLocationsSQL &= gcstrComma
                End If
                gstrFPDSLocationsSQL &= gcstrApos & Trim(FPDSLocations(x - 1)) & gcstrApos   'zero based array

            Next

            lpKeyName = "MaxNumUlRecordsRTCISInfeedToQuery"
            ZeroOk = False
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "500", strIniFileName)
            strValue = ValidateIniNumericEntry(strValue, 10, ZeroOk)
            giMaxNumUlRecordsRTCISInfeedToQuery = CInt(strValue)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)

            lpKeyName = "InfeedLocationsA8"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrNA, strIniFileName).ToUpper
            strValue = Strings.Replace(strValue, " ", String.Empty)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            ReDim InfeedLocationsA8(0)

            If Strings.Len(strValue) > 0 And strValue <> gcstrNA Then
                InfeedLocationsA8 = strValue.Split(gcCharComma)
            End If

            lpKeyName = "InfeedLocationsU8"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrNA, strIniFileName).ToUpper
            strValue = Strings.Replace(strValue, " ", String.Empty)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            ReDim InfeedLocationsU8(0)

            If Strings.Len(strValue) > 0 And strValue <> gcstrNA Then
                InfeedLocationsU8 = strValue.Split(gcCharComma)
            End If

            lpKeyName = "InfeedLocationsL8"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrNA, strIniFileName).ToUpper
            strValue = Strings.Replace(strValue, " ", String.Empty)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            ReDim InfeedLocationsL8(0)

            If Strings.Len(strValue) > 0 And strValue <> gcstrNA Then
                InfeedLocationsL8 = strValue.Split(gcCharComma)
            End If

            lpKeyName = "InfeedLocationsC8"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrNA, strIniFileName).ToUpper
            strValue = Strings.Replace(strValue, " ", String.Empty)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            ReDim InfeedLocationsC8(0)

            If Strings.Len(strValue) > 0 And strValue <> gcstrNA Then
                InfeedLocationsC8 = strValue.Split(gcCharComma)

            End If

            lpKeyName = "UseAlternateMsg567Induction"
            strValue = ValidateValueForYorN(oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrN, strIniFileName).ToUpper)

            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)
            If strValue = gcstrY Then
                gbUseAlternateMsg567Induction = True
            Else
                gbUseAlternateMsg567Induction = False
            End If


            lpKeyName = "Activ_Input_Conveyors"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrNA, strIniFileName).ToUpper
            strValue = Strings.Replace(strValue, " ", String.Empty)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            ReDim Activ_Input_Conveyors(0)

            If Strings.Len(strValue) > 0 And strValue <> gcstrNA Then
                Activ_Input_Conveyors = strValue.Split(gcCharComma)
            End If

            lpKeyName = "M35Activ_Input_ConveyorsPrefix"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "FPDS", strIniFileName).ToUpper
            gstrM35Activ_Input_ConveyorsPrefix = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)


            lpKeyName = "ShowOnlyTheBaseStackedULID"
            strValue = ValidateValueForYorN(oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrY, strIniFileName).ToUpper)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)
            If strValue = gcstrY Then
                gbShowOnlyTheBaseStackedULID = True
            Else
                gbShowOnlyTheBaseStackedULID = False
            End If


        Catch

        End Try

    End Sub
    Private Sub iniDTLDriverSend(ByVal oini As ini, ByVal strIniFileName As String, ByVal lpSectionName As String)
        Dim lpKeyName As String
        Dim strValue As String

        Try

            lpKeyName = "DtldrvsndTermEmuProcessName"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "PUTTY", strIniFileName).ToUpper
            gstrDtldrvsndTermEmuProcessName = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "DtldrvsndTermEmuWindowTitle"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "RAID", strIniFileName).ToUpper
            gstrDtldrvsndTermEmuWindowTitle = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "DtldrvsndMsg5UlWeight"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "0", strIniFileName).ToUpper
            gstrDtldrvsndMsg5UlWeight = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)
          

            lpKeyName = "DtldrvsndMsg5DeliveryCode"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "0", strIniFileName).ToUpper
            gstrDtldrvsndMsg5DeliveryCode = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)


            lpKeyName = "DtldrvsndMsg5UnitLoadStatus"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "0", strIniFileName).ToUpper
            gstrDtldrvsndMsg5UnitLoadStatus = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "DtldrvsndMsg5StationId"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "-1", strIniFileName).ToUpper
            gstrDtldrvsndMsg5StationId = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "DtldrvsndMsg5PortId"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "-1", strIniFileName).ToUpper
            gstrDtldrvsndMsg5PortId = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)


        Catch

        End Try

    End Sub
    Private Sub iniOutbound(ByVal oini As ini, ByVal strIniFileName As String, ByVal lpSectionName As String)
        Dim lpKeyName As String
        Dim strValue As String
        Dim x As Integer
        Dim ZeroOk As Boolean

        Try
            'The activ_ouput_location concatenated with the activ_level_id comprises the location name used in RTCIS.  
            'For sites other than ACTIV or ACTIW, the activ_level_id should always be “A”. Blank for D23

            lpKeyName = "MaxUnitLoadsPerSlot"
            ZeroOk = False
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "10", strIniFileName)
            strValue = ValidateIniNumericEntry(strValue, 10, ZeroOk)
            giMaxUnitLoadsPerSlot = CInt(strValue)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)

            lpKeyName = "ActivLevelIds"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "A", strIniFileName).ToUpper
            strValue = Strings.Replace(strValue, " ", String.Empty)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            ReDim ActivLevelIds(0)
            ActivLevelIdsRecordCount = 0

            If Strings.Len(strValue) > 0 And strValue <> gcstrNA Then
                ActivLevelIds = strValue.Split(gcCharComma)
                ActivLevelIdsRecordCount = ActivLevelIds.GetUpperBound(0) + 1

            End If

            lpKeyName = "Slots"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrNA, strIniFileName).ToUpper
            strValue = Strings.Replace(strValue, " ", String.Empty)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            ReDim Slots(0)
            SlotsRecordCount = 0

            If Strings.Len(strValue) > 0 And strValue <> gcstrNA Then
                Slots = strValue.Split(gcCharComma)
                SlotsRecordCount = Slots.GetUpperBound(0) + 1

            End If

            gstrSlotsSQL = String.Empty
            For x = 1 To SlotsRecordCount
                If x > 1 Then
                    gstrSlotsSQL &= gcstrComma
                End If
                gstrSlotsSQL &= gcstrApos & Trim(Slots(x - 1)) & gcstrApos   'zero based array

            Next

            lpKeyName = "Stage1MorePalletAfterA26Received"
            strValue = ValidateValueForYorN(oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrN, strIniFileName).ToUpper)

            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)
            If strValue = gcstrN Then
                gbStage1MorePalletAfterA26Received = False
            Else
                gbStage1MorePalletAfterA26Received = True
            End If

            lpKeyName = "SendResponseToSlotSignOn"
            strValue = ValidateValueForYorN(oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrN, strIniFileName).ToUpper)

            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)
            If strValue = gcstrN Then
                gbSendResponseToSlotSignOn = False
            Else
                gbSendResponseToSlotSignOn = True
            End If

            lpKeyName = "NumberofMessagesforStackedPallet"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "1", strIniFileName).ToUpper
            gstrNumberofMessagesforStackedPallet = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

        Catch

        End Try

    End Sub

    Private Sub iniManualOutputRequests(ByVal oini As ini, ByVal strIniFileName As String, ByVal lpSectionName As String)
        Dim lpKeyName As String
        Dim strValue As String
        Dim x As Integer

        Dim iDefaultValue4 As Integer = 4
        Dim iDefaultValue5 As Integer = 5

        Dim ZeroOk As Boolean

        Try

            lpKeyName = "DefaultWithdrawalOutputMins"
            ZeroOk = False
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, iDefaultValue5.ToString, strIniFileName).ToUpper
            strValue = ValidateIniNumericEntry(strValue, iDefaultValue5, ZeroOk)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)
            gstrDefaultWithdrawalOutputMins = strValue

            lpKeyName = "ManualOutputVTLPrefix"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "VTL", strIniFileName).ToUpper
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue, True, ZeroOk)
            gstrManualOutputVTLPrefix = strValue


            lpKeyName = "ManualOutputLocations"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, gcstrNA, strIniFileName).ToUpper
            strValue = Strings.Replace(strValue, " ", String.Empty)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            ReDim ManualOutputLocations(0)
            ManualOutputLocationsRecordCount = 0

            If Strings.Len(strValue) > 0 And strValue <> gcstrNA Then
                ManualOutputLocations = strValue.Split(gcCharComma)
                ManualOutputLocationsRecordCount = ManualOutputLocations.GetUpperBound(0) + 1

            End If

            gstrManualOutputLocationsSQL = String.Empty
            For x = 1 To ManualOutputLocationsRecordCount
                If x > 1 Then
                    gstrManualOutputLocationsSQL &= gcstrComma
                End If
                gstrManualOutputLocationsSQL &= gcstrApos & Trim(ManualOutputLocations(x - 1)) & gcstrApos   'zero based array

            Next

        Catch

        End Try

    End Sub
    Private Sub iniLastDBLogin(ByVal oini As ini, ByVal strIniFileName As String, ByVal lpSectionName As String)
        Dim lpKeyName As String
        Dim strValue As String

        Try

            lpKeyName = "DBServer"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, vbNullString, strIniFileName)
            DBServer = strValue

            lpKeyName = "DBSid"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "rtcis", strIniFileName)
            DBSid = strValue

            lpKeyName = "DBUser"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, vbNullString, strIniFileName)
            DBUserName = strValue

        Catch

        End Try

    End Sub

    Public Sub AddIniKeyNametoIniArray(ByRef lpSectionName As String, ByRef lpKeyName As String, ByRef strValue As String,
                                        Optional ByVal bNumeric As Boolean = False, Optional ByVal bZeroAllowed As Boolean = True)
        IniRecordCount += 1
        ReDim Preserve IniEntries(IniRecordCount)
        With IniEntries(IniRecordCount)
            IniEntries(IniRecordCount).SectionName = lpSectionName
            IniEntries(IniRecordCount).KeyName = lpKeyName
            IniEntries(IniRecordCount).Value = strValue
            IniEntries(IniRecordCount).Numeric = bNumeric
            IniEntries(IniRecordCount).ZeroAllowed = bZeroAllowed
        End With
    End Sub

    Private Sub iniTCSConfig(ByVal oini As ini, ByVal strIniFileName As String, ByVal lpSectionName As String)
        Dim lpKeyName As String
        Dim strValue As String

        Try

            lpKeyName = "AutoConfirmTCSInbounds"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "Y", strIniFileName).ToUpper
            gTCSAutoConfirmTCSInbounds = If((strValue = "Y"), True, False)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "AutoConfirmDelaySecs"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "0", strIniFileName).ToUpper
            gstrTCSAutoConfDelaySec = CInt(strValue)
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "AutoLoadTCSEmuGrids"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "N", strIniFileName).ToUpper
            gstrAtuoLoadTCSGrids = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)


        Catch

        End Try

    End Sub
End Module