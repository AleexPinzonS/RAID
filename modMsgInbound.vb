Option Explicit On
Option Strict Off  'woudl rather have this on but LINQ seems to need it off and cant find way around


Imports System.Security.Cryptography
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Reflection.MethodBase    'used to get procedure name for error logging
Imports System.Xml.Linq
Imports System.Linq


Module modMsgInbound

    '$PROBHIDE NOT_READ
    Public Structure Confirm_Heartbeat
        Dim strText As String
    End Structure

    Public Structure MessageHeader
        Dim SESSION_KEY As String
        Dim MESSAGE_ID As String
        Dim TIMESTAMP As String
    End Structure
    Public Structure Msg8
        Dim strMsgTyp As String
        Dim strCust_ID As String
        Dim strBrand_Code As String
        Dim strBrand_Desc As String
        Dim strCode_Date As String
        Dim strPallet_Type As String
        Dim strHold_Status As String
        Dim strActiv_Input_Location As String
        Dim strUser_Id As String
        Dim strMessage_Timestamp As String
        Dim strCtrl_Date As String
        Dim strItem_group As String
        Dim strBase_ulid As String
        Dim strCase_quantity As String
        Dim strPartial_flag As String
        Dim strPlc_Userid As String

    End Structure
    Public Structure Msg6

        Dim strMsgTyp As String
        Dim strCust_ID As String
        Dim strUNIT_LOAD_FORMER_ID As String
        Dim strUSER_ID As String
        Dim strActiv_Input_Location As String

    End Structure
    Public Structure Msg13
        Dim strMESSAGE_TYPE As String
        Dim strHOST_CONTROL_NUMBER As String
        Dim strBRAND_CODE As String
        Dim strCODE_DATE As String
        Dim strPALLET_TYPE As String
        Dim strUL_WITHDRAWAL_QTY As String
        Dim strWITHDRAWAL_INTENT_CODE As String
        Dim strWITHDRAWAL_SELECT_FLAG As String
        Dim strWITHDRAWAL_PARTIAL_CODE As String
        Dim strUNIT_LOAD_ID As String
        Dim strActiv_output_location As String

    End Structure

    Public Structure Msg16

        Dim strMsgTyp As String
        Dim strUnit_Load_Id As String
        Dim strBrand_Code As String
        Dim strCode_Date As String
        Dim strUl_hold_Status_code As String


    End Structure
    Public Structure Msg21

        Dim MESSAGE_TYPE As String
        Dim HOST_CONTROL_NUMBER As String
        'Dim WITHDRAW_SELECT_FLAG As String
        Dim WITHDRAWAL_SELECT_FLAG As String
        Dim SCHEDULED_SHIP_DATE As String
        Dim SCHEDULED_SHIP_TIME As String
        Dim TIMESTAMP As String
        Dim USER_ID As String
        Dim ORDER_DISPOSITION As String
        Dim LINE_COUNT As String
        Dim SEQUENCE As String
        Dim BRAND_CODE As String
        Dim CODE_DATE As String
        Dim PALLET_TYPE As String
        Dim LINE_QTY As String
        Dim FIFO_WINDOW As String

    End Structure
    Public Structure Msg26

        Dim strMESSAGE_TYPE As String
        Dim strHOST_CONTROL_NUMBER As String

    End Structure
    Public Structure Msg20

        Dim strMESSAGE_TYPE As String
        Dim strHOST_CONTROL_NUMBER As String

    End Structure
    Public Structure Msg25

        Dim strMESSAGE_TYPE As String
        Dim strHOST_CONTROL_NUMBER As String
        Dim strACTIV_OUTPUT_LOCATION As String

    End Structure
    Public Structure Msg32

        Dim strMESSAGE_TYPE As String
        Dim strHOST_CONTROL_NUMBER As String
        Dim strACTIV_OUTPUT_LOCATION As String
        Dim strSIGNON_FLG As String
    End Structure
    Public Structure Msg40

        Dim strMESSAGE_TYPE As String
        Dim strHOST_CONTROL_NUMBER As String

    End Structure
    Public Structure Msg41

        Dim MESSAGE_TYPE As String
        Dim HOST_CONTROL_NUMBER As String
        Dim DELIVERY_LOCATION As String
        Dim SCHEDULED_START_DATE As String
        Dim SCHEDULED_START_TIME As String
        Dim ORDER_DISPOSITION As String
        Dim LINE_COUNT As String
        Dim SEQUENCE As String
        Dim BRAND_CODE As String
        Dim CODE_DATE As String
        Dim PALLET_TYPE As String
        Dim LINE_QTY As String
        Dim FIFO_WINDOW As String

    End Structure
    Public Structure MsgSlotDestage

        Dim strMESSAGE_TYPE As String
        Dim strACTIV_OUTPUT_LOCATION As String

    End Structure

    Private Structure ULReserved
        Dim ULID As String
        Dim SHIPID As String
    End Structure

    Private Structure Heartbeat
        Dim TEXT As String
    End Structure
    Public Structure RequestFPDS
        Dim MESSAGE_TYPE As String
        Dim TRAILER_NUMBER As String
        Dim TRUCK_LINE As String
        Dim ACTIV_INPUT_LOCATION As String
        Dim LINE_COUNT As String
        Dim Unit_Load_Id As String
        Dim Brand_Code As String
        Dim Item_Number As String
        Dim Pallet_Type As String
    End Structure

    Public NotInheritable Class XMLReadIt

        Public Sub ParseXML(ByVal strData As String)
            Dim x As Integer
            Dim strMsgForLog As String
            Dim strStatus As String
            Dim strSlot As String
            Dim bOktoUpdate As Boolean = False
            Dim strShipid As String
            Dim strRootTag As String
            Dim lRecordsAffected As Long = 0
            Dim strA35StatusfromDB As String
            Dim strULIDs As String

            Try

                gbNewInboundData = True
                gLastMsgInTimeStamp = Now
                giMsgInCount += 1
                If Year(gFirstMsgInTimeStamp) < 1986 Then
                    gFirstMsgInTimeStamp = gLastMsgInTimeStamp
                End If

                'determine what the xml is and route to its routine
                Dim document As XDocument = XDocument.Parse(strData)
                strRootTag = document.Root.Name.ToString.ToUpper
                strMsgForLog = strRootTag & " for ULID "

                Select Case strRootTag

                    Case "Confirm_HeartBeat".ToUpper
                        Dim structXML As Confirm_Heartbeat
                        structXML = ReadXML_ConfirmHeartbeat(document)

                        WriteLog(gcstrProcessed, "Heartbeat Message = " & structXML.strText)
                    Case TRL_CKIN_CONF_TAG.ToUpper
                        Dim structXML As TrailerCheckinConfirm
                        structXML = ReadXML_TrailerCheckinConfirm(document)

                        WriteLog(gcstrProcessed, "Processed Trailer Check-In Message-[" &
                                                    structXML.strTRUCK_LINE & "]-[" &
                                                    structXML.strTRAILER_NUMBER & "]-[" &
                                                    structXML.strTRACTOR_ID & "]-Status[" &
                                                    structXML.strERROR_CODE & "]-Error Msg[" &
                                                    structXML.strERROR_MSG & "]")
                    Case TRL_LOC_ASSG_CONF_TAG.ToUpper
                        Dim structXML As TrailerLocAsgnmtConfirm
                        structXML = ReadXML_TrailerLocAsgnmtConfirm(document)

                        WriteLog(gcstrProcessed, "Trailer Location Assignment [" &
                                                    structXML.strTRUCK_LINE & "]-[" &
                                                    structXML.strTRAILER_NUMBER & "]-[" &
                                                    structXML.strSITE_NAME & "]-[" &
                                                    structXML.strLOCATION & "]-Status[" &
                                                    structXML.strERROR_CODE & "]-Error Msg[" &
                                                    structXML.strERROR_MSG & "]")

                    Case TRL_SHPRCP_ASG_CONF_TAG.ToUpper
                        Dim structXML As TrailerShpRcpAsgnmtConfirm
                        structXML = ReadXML_TrailerShpRcpAsgnmtConfirm(document)

                        WriteLog(gcstrProcessed, "Trailer Shipment/Receipt Assignment[" &
                                                    structXML.strTRUCK_LINE & "]-[" &
                                                    structXML.strTRAILER_NUMBER & "]-" &
                                                    structXML.strTRACTOR_ID & "]-Status[" &
                                                    structXML.strERROR_CODE & "]-Error Msg[" &
                                                    structXML.strERROR_MSG & "]")

                    Case TRL_CKOUT_CONF_TAG.ToUpper
                        Dim structXML As TrailerCheckOutConfirm
                        structXML = ReadXML_TrailerCheckOutConfirm(document)

                        WriteLog(gcstrProcessed, "Trailer Check-Out Message [" &
                                                    structXML.strTRUCK_LINE & "]-[" &
                                                    structXML.strTRAILER_NUMBER & "]-[" &
                                                    structXML.strTRACTOR_ID & "]- Status[" &
                                                    structXML.strERROR_CODE & "]-Error Msg[" &
                                                    structXML.strERROR_MSG & "]")

                    Case "MSG6".ToUpper
                        Dim structXML As Msg6
                        structXML = ReadXML_Msg06(document)

                        Update_CUST_PALLET_RETRO_STATUS(structXML.strCust_ID, "6")

                        WriteLog(gcstrProcessed, strMsgForLog & structXML.strCust_ID)

                    Case "RequestInduction".ToUpper
                        Dim structXML As Msg8
                        structXML = ReadXML_Msg08(document)

                        'A8 ‘– Ask ASRS for input location.  Occurs when delivery location = 0 in message 5.   Two A8s are sent for Stacked pallets.  
                        'D8 ‘– De-announce the Unit load to ASRS.  Happens when unit load pending location is the ASRS. The ASRS then de-allocates resources for storing the specific unit load.  Only one D8 is sent for stacked pallets.
                        'M8 ‘– Announce to ASRS which input location will arrive. When delivery location is not 0, 88, 99, consign type, or reject type  location.
                        'C8’ – Request an input location for a case picked unit load.  This is a unit load which has been created with many different item codes.  
                        'L8’ – same as an A8, except it is telling the ASRS system that the ulid is on the lower FPDS, so the ASRS system will only return lower input points. Happens when message 5 delivery location = 88  
                        'U8’ – same as an A8, except it is telling the ASRS system that the ulid is on the upper FPDS, so the ASRS system will only return upper input points. Happens when message 5 delivery location = 99  


                        Select Case structXML.strMsgTyp

                            Case "D8"
                                lRecordsAffected = DeleteULIDfromDB(structXML.strCust_ID)
                                WriteLog(gcstrProcessed, "D8 - Deleted ULID from ASRS DB: " & structXML.strCust_ID & RecordAffectedMessage(lRecordsAffected, gcstrDelete))

                            Case "A8", "C8", "L8", "U8", "M8"

                                lRecordsAffected = Update_CUST_PALLET_ForA8(structXML.strCust_ID, structXML.strBrand_Code, structXML.strBrand_Desc, structXML.strCode_Date, _
                                                         structXML.strPallet_Type, structXML.strHold_Status, structXML.strActiv_Input_Location, structXML.strMsgTyp, _
                                                         "FPDS", structXML.strPlc_Userid)

                                If lRecordsAffected = 0 And structXML.strBase_ulid <> structXML.strCust_ID Then
                                    'this is stacked pallet whereas RAID didn't know the ULID yet

                                    With structXML
                                        InsertULInto_CUST_PALLET(structXML.strCust_ID, "5", .strBrand_Code, .strBrand_Desc, .strCode_Date, .strPallet_Type, .strHold_Status, _
                                                                 gstrASRSSystemLocationName, .strBase_ulid)
                                        lRecordsAffected = Update_CUST_PALLET_ForA8(structXML.strCust_ID, structXML.strBrand_Code, structXML.strBrand_Desc, structXML.strCode_Date, _
                                                     structXML.strPallet_Type, structXML.strHold_Status, structXML.strActiv_Input_Location, structXML.strMsgTyp, _
                                                     "FPDS", structXML.strPlc_Userid)

                                    End With

                                End If

                                WriteLog(gcstrProcessed, strMsgForLog & structXML.strCust_ID & RecordAffectedMessage(lRecordsAffected, gcstrUpdate))
                        End Select



                    Case "WithdrawalRequest".ToUpper
                        Dim structXML As Msg13
                        structXML = ReadXML_Msg13(document)

                        ProcessMsg13(structXML)

                        WriteLog(gcstrProcessed, strRootTag.ToUpper & Space(1) & structXML.strHOST_CONTROL_NUMBER)

                    Case "QAStatusChange".ToUpper
                        Dim structXML As Msg16
                        structXML = ReadXML_Msg16(document)

                        lRecordsAffected = Update_CUST_PALLET_MSG16(structXML.strUnit_Load_Id, structXML.strCode_Date, structXML.strUl_hold_Status_code)

                        InsertInto_Msg16HSt(structXML.strUnit_Load_Id, structXML.strCode_Date, structXML.strUl_hold_Status_code, structXML.strBrand_Code)

                        WriteLog(gcstrProcessed, strMsgForLog & structXML.strUnit_Load_Id & RecordAffectedMessage(lRecordsAffected, gcstrUpdate))

                    Case "CancelShipment".ToUpper    'Cancel shipment - then send Msg 24
                        Dim structXML As Msg20
                        structXML = ReadXML_Msg20(document)


                        strSlot = WhatSlotAssignedToShipment(structXML.strHOST_CONTROL_NUMBER)

                        If strSlot <> "-1" Then

                            If strSlot.Length > 0 Then
                                'send the 24 only if the status is not 24
                                If WhatRetro_StatusIsShipment(structXML.strHOST_CONTROL_NUMBER) <> "A24" Then
                                    SendRequest(CreateXML_ShipStageComplete("A24", structXML.strHOST_CONTROL_NUMBER, strSlot))
                                    Update_CUST_SHIPMENT(structXML.strHOST_CONTROL_NUMBER, "A24", strSlot)
                                Else
                                    WriteLog(gcstrINFO, "No A24 Sent in Response to A20 since A24 Previously Sent for Shipid " & structXML.strHOST_CONTROL_NUMBER)
                                End If
                            Else
                                'no futher action required, set the status for purge routine
                                Update_CUST_SHIPMENT(structXML.strHOST_CONTROL_NUMBER, "CANCLD", strSlot)
                                WriteLog(gcstrINFO, strRootTag & "No A24 Sent Since No Slot Assigned - Host Control #: " & structXML.strHOST_CONTROL_NUMBER)

                            End If


                            Update_CUST_SHIPMENT_Single_Field(structXML.strHOST_CONTROL_NUMBER, "LOAD_STATUS", gcstrMsg20CancelText)
                            WriteLog(gcstrProcessed, strRootTag & " Cancelled - Host Control #: " & structXML.strHOST_CONTROL_NUMBER)
                        Else
                            WriteLog(gcstrINFO, strRootTag & " No Slot Assigned - Host Control #: " & structXML.strHOST_CONTROL_NUMBER)

                        End If

                        'cancel all line items not yet staged, necessary for purge routine
                        Update_CUST_LINEITEM_CancelNonStagedItems(structXML.strHOST_CONTROL_NUMBER)
                        gbNewOutboundData = True   'set the log refresh flag

                    Case "CancelProdOrder".ToUpper    'Cancel production order- then send Msg 44
                        Dim structXML As Msg40
                        structXML = ReadXML_Msg40(document)


                        strSlot = WhatSlotAssignedToShipment(structXML.strHOST_CONTROL_NUMBER)

                        If strSlot <> "-1" Then

                            If strSlot.Length > 0 Then
                                'send the 44 only if the status is not 44
                                If WhatRetro_StatusIsShipment(structXML.strHOST_CONTROL_NUMBER) <> "A44" Then
                                    SendRequest(CreateXML_ShipStageComplete("A44", structXML.strHOST_CONTROL_NUMBER, strSlot))
                                    Update_CUST_SHIPMENT(structXML.strHOST_CONTROL_NUMBER, "A44", strSlot)
                                Else
                                    WriteLog(gcstrINFO, "No A44 Sent in Response to A40 since A44 Previously Sent for Shipid " & structXML.strHOST_CONTROL_NUMBER)
                                End If
                            Else
                                'no futher action required, set the status for purge routine
                                Update_CUST_SHIPMENT(structXML.strHOST_CONTROL_NUMBER, "CANCLD", strSlot)
                                WriteLog(gcstrINFO, strRootTag & "No A44 Sent Since No Slot Assigned - Host Control #: " & structXML.strHOST_CONTROL_NUMBER)

                            End If


                            Update_CUST_SHIPMENT_Single_Field(structXML.strHOST_CONTROL_NUMBER, "LOAD_STATUS", gcstrMsg20CancelText)
                            WriteLog(gcstrProcessed, strRootTag & " Cancelled - Host Control #: " & structXML.strHOST_CONTROL_NUMBER)
                        Else
                            WriteLog(gcstrINFO, strRootTag & " No Slot Assigned - Host Control #: " & structXML.strHOST_CONTROL_NUMBER)

                        End If

                        'cancel all line items not yet staged, necessary for purge routine
                        Update_CUST_LINEITEM_CancelNonStagedItems(structXML.strHOST_CONTROL_NUMBER)
                        gbNewOutboundData = True   'set the log refresh flag

                    Case "AssignShip".ToUpper
                        Dim structXML() As Msg21
                        Dim bShipmmentAsigned As Boolean = False
                        Dim iNumberifLineItems As Integer
                        structXML = ReadXML_Msg21(document)
                        If structXML(0).LINE_COUNT = gcStrZero Then
                            WriteLog(gcstrProcessed, strRootTag & " No Shipments Available for Processing")
                        Else

                            bShipmmentAsigned = True
                            'use (0)  to populate shipment header values and (x) to get the detail records

                            'need to find a UL based on brand_code/pallet_type/code_date etc
                            'populate shipment header
                            InsertInto_CUST_SHIPMENT(structXML(0).HOST_CONTROL_NUMBER, gcstrShipmentRequest, "ACTIV", structXML(0).ORDER_DISPOSITION, _
                                 structXML(0).SCHEDULED_SHIP_DATE & Space(1) & structXML(0).SCHEDULED_SHIP_TIME, "21", String.Empty)

                            If Left(structXML(0).HOST_CONTROL_NUMBER, 1) = "M" And structXML(0).HOST_CONTROL_NUMBER.Length = 5 Then
                                'this is a batched manual withdrawal and will have no line items listed as all items are identical
                                For x = 1 To structXML(0).LINE_QTY
                                    'InsertInto_CUST_LINEITEM(structXML(0).HOST_CONTROL_NUMBER, x.ToString, x.ToString, structXML(0).BRAND_CODE, _
                                    '   structXML(0).CODE_DATE, structXML(0).PALLET_TYPE, "1", structXML(0).WITHDRAW_SELECT_FLAG, "21", String.Empty)
                                    InsertInto_CUST_LINEITEM(structXML(0).HOST_CONTROL_NUMBER, x.ToString, x.ToString, structXML(0).BRAND_CODE,
                                       structXML(0).CODE_DATE, structXML(0).PALLET_TYPE, "1", structXML(0).WITHDRAWAL_SELECT_FLAG, "21", String.Empty)

                                Next

                                strULIDs = structXML(0).LINE_QTY
                            Else
                                'normal shipment or process order with line itmes
                                iNumberifLineItems = structXML.GetUpperBound(0)
                                'create a lineitem record for each UL needed
                                For x = 0 To structXML.GetUpperBound(0)
                                    'InsertInto_CUST_LINEITEM(structXML(0).HOST_CONTROL_NUMBER, (x + 1).ToString, structXML(x).SEQUENCE, structXML(x).BRAND_CODE,
                                    '        structXML(x).CODE_DATE, structXML(x).PALLET_TYPE, "1", structXML(0).WITHDRAW_SELECT_FLAG, "21", String.Empty)
                                    InsertInto_CUST_LINEITEM(structXML(0).HOST_CONTROL_NUMBER, (x + 1).ToString, structXML(x).SEQUENCE, structXML(x).BRAND_CODE,
                                            structXML(x).CODE_DATE, structXML(x).PALLET_TYPE, "1", structXML(0).WITHDRAWAL_SELECT_FLAG, "21", String.Empty)
                                Next

                                strULIDs = (structXML.GetUpperBound(0) + 1).ToString
                            End If


                            WriteLog(gcstrProcessed, strRootTag & " Host Control #: " & structXML(0).HOST_CONTROL_NUMBER & " ULs: " & strULIDs)
                        End If

                        'display log to user of short product
                        If gbAtLeastOneAutoScanFunctionActive = False And bShipmmentAsigned = True Then
                            ShortInventoryCheck(structXML(0).HOST_CONTROL_NUMBER)  'only in manual mode
                        Else
                            If bShipmmentAsigned = True Then
                                WriteLog(gcstrINFO, "Inventory Check Skipped")
                            End If

                        End If

                    Case "AssignProdOrder".ToUpper
                        Dim structXML() As Msg41

                        structXML = ReadXML_Msg41(document)
                        If structXML(0).LINE_COUNT = gcStrZero Then
                            WriteLog(gcstrProcessed, strRootTag & " No Prod Orders Available for Processing")
                        Else


                            'use (0)  to populate shipment header values and (x) to get the detail records

                            'need to find a UL based on brand_code/pallet_type/code_date etc
                            'populate shipment header
                            InsertInto_CUST_SHIPMENT(structXML(0).HOST_CONTROL_NUMBER, gcstrPORequest, "ACTIV", structXML(0).ORDER_DISPOSITION, _
                                 structXML(0).SCHEDULED_START_DATE & Space(1) & structXML(0).SCHEDULED_START_TIME, "41", String.Empty)

                            'create a lineitem record for each UL needed
                            'currently XML passes in destination location, but not using it
                            For x = 0 To structXML.GetUpperBound(0)
                                InsertInto_CUST_LINEITEM(structXML(0).HOST_CONTROL_NUMBER, (x + 1).ToString, structXML(x).SEQUENCE, structXML(x).BRAND_CODE, _
                                        structXML(x).CODE_DATE, structXML(x).PALLET_TYPE, "1", String.Empty, "41", String.Empty)
                            Next
                            WriteLog(gcstrProcessed, strRootTag & " Host Control #: " & structXML(0).HOST_CONTROL_NUMBER & " ULs: " & (structXML.GetUpperBound(0) + 1).ToString)
                        End If

                        'display log to user of short product
                        If gbAtLeastOneAutoScanFunctionActive = False Then
                            ShortInventoryCheck(structXML(0).HOST_CONTROL_NUMBER)  'only in manual mode
                        Else
                            WriteLog(gcstrINFO, "Inventory Check Skipped  - in Auto Mode")

                        End If

                    Case "ShipLaneEmpty".ToUpper
                        Dim structXML As Msg25
                        structXML = ReadXML_Msg25(document)

                        WriteLog(gcstrProcessed, "Msg25 Processed - Slot " & structXML.strACTIV_OUTPUT_LOCATION & " is Empty")


                    Case "StopShipStaging".ToUpper
                        Dim structXML As Msg26
                        structXML = ReadXML_Msg26(document)

                        strSlot = WhatSlotAssignedToShipment(structXML.strHOST_CONTROL_NUMBER)
                        If strSlot <> "-1" Then
                            If gbStage1MorePalletAfterA26Received = False Then
                                'tell RTCIS that stage is now complete


                                SendRequest(CreateXML_ShipStageComplete("A24", structXML.strHOST_CONTROL_NUMBER, strSlot))

                                gbNewOutboundData = True   'set the log refresh flag

                                'update the shipment table 
                                'M#,locatn,status
                                Update_CUST_SHIPMENT(structXML.strHOST_CONTROL_NUMBER, "24", strSlot)
                                Update_CUST_SHIPMENT_Single_Field(structXML.strHOST_CONTROL_NUMBER, "LOAD_STATUS", gcstrMsg26StopText)
                                WriteLog(gcstrINFO, "Stop Staging " & structXML.strHOST_CONTROL_NUMBER)


                            Else
                                'want to stage 1 more pallet before stage complete
                                Update_CUST_SHIPMENT_Single_Field(structXML.strHOST_CONTROL_NUMBER, "LOAD_STATUS", "STG1THENSTOP")
                                WriteLog(gcstrINFO, "Stop Staging " & structXML.strHOST_CONTROL_NUMBER & " after 1 more UL is staged")

                            End If

                        Else
                            WriteLog(gcstrError, "No Slot Associated with Host Control#  " & structXML.strHOST_CONTROL_NUMBER)


                        End If

                    Case "SlotSignOnOff".ToUpper
                        Dim structXML As Msg32
                        structXML = ReadXML_Msg32(document)


                        '  Message_type()    'A32’ – sent when a user signs on to load a shipment which has been staged in an ASRS output slot or conveyor.  The user can also manually sign on to a staging slot or conveyor from the RDT.  
                        'D32’ – sent when a user signs off the shipment loading or manually signs off the slot.  
                        'U32’ – is used to tell ACTIV to de-stage a cancelled order.
                        'Host_control_number	This is the host control number supplied in msg 21.  It is included in the A32 message but not the D32 or U32 message.
                        'Activ_output_location	This is the output slot or conveyor location which is being signed on to, or the location of the order to de-stage.

                        strStatus = String.Empty
                        If structXML.strSIGNON_FLG = "Y" Then
                            strStatus = "Y"
                            bOktoUpdate = True

                        ElseIf structXML.strSIGNON_FLG = "N" Then
                            strStatus = String.Empty
                            bOktoUpdate = True

                        Else
                            WriteLog(gcstrError, strRootTag.ToUpper & Space(1) & structXML.strHOST_CONTROL_NUMBER & Space(1) & _
                                        " Invalid Sign On Flag |" & structXML.strSIGNON_FLG & "|")

                        End If


                        If bOktoUpdate = True Then

                            If structXML.strACTIV_OUTPUT_LOCATION.Length > 0 Then
                                strShipid = WhatShipmentAssignedToSlot(structXML.strACTIV_OUTPUT_LOCATION)
                                If strShipid = "-1" Then
                                    strShipid = String.Empty
                                    WriteLog(gcstrError, "No Host Control# Associated with Slot " & structXML.strACTIV_OUTPUT_LOCATION)


                                Else
                                    WriteLog(gcstrINFO, strShipid & " is the Host Control# Associated with Slot " & structXML.strACTIV_OUTPUT_LOCATION)

                                End If

                            ElseIf structXML.strHOST_CONTROL_NUMBER.Length > 0 Then
                                strShipid = structXML.strHOST_CONTROL_NUMBER

                            Else
                                strShipid = String.Empty
                                WriteLog(gcstrError, strRootTag.ToUpper & Space(1) & " Neither Host Control # Nor Slot Specified")

                            End If


                            If strShipid.Length > 0 Then
                                Update_CUST_SHIPMENT_Single_Field(strShipid, "SIGNON", strStatus)

                                If gbSendResponseToSlotSignOn = True Then
                                    SendRequest(CreateXML_SlotSignOnConfirmation(structXML.strHOST_CONTROL_NUMBER, structXML.strACTIV_OUTPUT_LOCATION, "0"))
                                End If
                                WriteLog(gcstrINFO, structXML.strMESSAGE_TYPE & " |" & structXML.strSIGNON_FLG & "| " & "successfully processed")
                            End If

                        End If
                        WriteLog(gcstrProcessed, strRootTag.ToUpper & Space(1) & "Host#: " & structXML.strHOST_CONTROL_NUMBER)

                    Case "SlotDestage".ToUpper
                        Dim structXML As MsgSlotDestage
                        structXML = ReadXML_MsgSlotDestage(document)


                        '  Message_type()    'A32’ – sent when a user signs on to load a shipment which has been staged in an ASRS output slot or conveyor.  The user can also manually sign on to a staging slot or conveyor from the RDT.  
                        'D32’ – sent when a user signs off the shipment loading or manually signs off the slot.  
                        'U32’ – is used to tell ACTIV to de-stage a cancelled order.
                        'Host_control_number	This is the host control number supplied in msg 21.  It is included in the A32 message but not the D32 or U32 message.
                        'Activ_output_location	This is the output slot or conveyor location which is being signed on to, or the location of the order to de-stage.

                        strStatus = "U"
                        WriteLog("UnStage", strRootTag.ToUpper & Space(1) & "Slot" & Space(1) & structXML.strACTIV_OUTPUT_LOCATION & Space(1) & " Requested")






                        If structXML.strACTIV_OUTPUT_LOCATION.Length > 0 Then
                            strShipid = WhatShipmentAssignedToSlot(structXML.strACTIV_OUTPUT_LOCATION)
                            If strShipid = "-1" Then
                                WriteLog(gcstrError, strRootTag.ToUpper & Space(1) & " Can Not Determine Host Control # associated to Slot " & structXML.strACTIV_OUTPUT_LOCATION)

                            Else
                                WriteLog(gcstrINFO, strShipid & " is the Host Control# Associated with Slot " & structXML.strACTIV_OUTPUT_LOCATION)

                            End If


                        Else
                            strShipid = String.Empty
                            WriteLog(gcstrError, strRootTag.ToUpper & Space(1) & " Slot Not Specified")

                        End If


                        If strShipid.Length > 0 And strShipid <> "-1" Then
                            Update_CUST_SHIPMENT_Single_Field(strShipid, "SIGNON", strStatus)
                            WriteLog(gcstrINFO, strRootTag & " succesfully processed")
                        End If


                    Case "RequestFPDS".ToUpper
                        Dim structXML() As RequestFPDS
                        structXML = ReadXML_RequestFPDS(document)

                        Dim iUniqueULIDs As Integer = (From c In structXML Select c.Unit_Load_Id Distinct).Count

                        strA35StatusfromDB = ReadTrailer_FPDS_MessageTypeFromDB(structXML(0).TRUCK_LINE, structXML(0).TRAILER_NUMBER)

                        If iUniqueULIDs = UBound(structXML) + 1 Then
                            'all ULs are unique
                        Else
                            WriteLog(gcstrError, strRootTag.ToUpper & Space(1) & " WMS Sent Duplicate ULIDs " & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER)

                        End If

                        If structXML(0).MESSAGE_TYPE = "A35" Then
                            'check to see if request already exists, if not then insert the request
                            If strA35StatusfromDB = "A35" OrElse strA35StatusfromDB = "A35S" OrElse strA35StatusfromDB = "D35" Then

                                'consecutive A35 received - start with clean slate - ok per retrotech
                                lRecordsAffected = DeleteDatafromEmulatorDBTablewithWhereClause("TRAILER_FPDS", _
                                    "TRAILER_NUMBER='" & structXML(0).TRAILER_NUMBER & "' and TRUCK_LINE ='" & structXML(0).TRUCK_LINE & "'", False)

                                WriteLog(gcstrProcessed, "Removed from WCS DB " & structXML(0).TRUCK_LINE & "|" & structXML(0).TRAILER_NUMBER & Space(1) & RecordAffectedMessage(lRecordsAffected, gcstrDelete))

                                'create the new entry
                                InsertInto_TRAILER_FPDS(structXML(0).MESSAGE_TYPE, structXML(0).TRAILER_NUMBER, _
                                                      structXML(0).TRUCK_LINE, structXML(0).LINE_COUNT)

                                WriteLog(gcstrProcessed, strRootTag.ToUpper & Space(1) & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER & " (Consecutive A35s received)")


                            ElseIf strA35StatusfromDB = "M35" Then
                                WriteLog(gcstrError, strRootTag.ToUpper & Space(1) & "Message Rejected  - M35 Already Exists (RTCIS Needs to Send D35 then M35)" & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER)

                            Else
                                InsertInto_TRAILER_FPDS(structXML(0).MESSAGE_TYPE, structXML(0).TRAILER_NUMBER, _
                                                        structXML(0).TRUCK_LINE, structXML(0).LINE_COUNT)

                                WriteLog(gcstrProcessed, strRootTag.ToUpper & Space(1) & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER)

                            End If

                        ElseIf structXML(0).MESSAGE_TYPE = "M35" Then
                            If structXML(0).ACTIV_INPUT_LOCATION.Length = 0 Then
                                WriteLog(gcstrError, strRootTag.ToUpper & Space(1) & "M35 Missing Conveyor Input Location " & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER)
                            ElseIf Array.IndexOf(Activ_Input_Conveyors, structXML(0).ACTIV_INPUT_LOCATION) = -1 Then
                                WriteLog(gcstrError, strRootTag.ToUpper & Space(1) & "M35 Invalid Conveyor Input Location (Add via Configuration/Infeed Menu) " & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER)
                            Else

                                If strA35StatusfromDB = "D35" OrElse strA35StatusfromDB = "A35S" Then
                                    Update_TRAILER_FPDS(structXML(0).TRUCK_LINE, structXML(0).TRAILER_NUMBER, structXML(0).MESSAGE_TYPE, structXML(0).ACTIV_INPUT_LOCATION)
                                    WriteLog(gcstrProcessed, strRootTag.ToUpper & Space(1) & "Processed M35 " & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER & " to " & structXML(0).ACTIV_INPUT_LOCATION)
                                Else
                                    'the M35 ws received unsolicited, the RTCIS user moved the traiel rto the door without askign and we get notified
                                    'create the new entry
                                    InsertInto_TRAILER_FPDS(structXML(0).MESSAGE_TYPE, structXML(0).TRAILER_NUMBER, _
                                                          structXML(0).TRUCK_LINE, structXML(0).LINE_COUNT)
                                    Update_TRAILER_FPDS(structXML(0).TRUCK_LINE, structXML(0).TRAILER_NUMBER, structXML(0).MESSAGE_TYPE, structXML(0).ACTIV_INPUT_LOCATION)

                                    WriteLog(gcstrProcessed, strRootTag.ToUpper & Space(1) & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER & " Unsolicited M35  - Manual Move to Door?")

                                End If
                            End If
                        ElseIf structXML(0).MESSAGE_TYPE = "D35" Then

                            If strA35StatusfromDB = "A35S" OrElse strA35StatusfromDB = "M35" Then
                                Update_TRAILER_FPDS(structXML(0).TRUCK_LINE, structXML(0).TRAILER_NUMBER, structXML(0).MESSAGE_TYPE, structXML(0).ACTIV_INPUT_LOCATION)
                                ' consider adding lRecordsAffected
                                WriteLog(gcstrProcessed, strRootTag.ToUpper & Space(1) & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER)

                            ElseIf strA35StatusfromDB = "A35" Then
                                Update_TRAILER_FPDS(structXML(0).TRUCK_LINE, structXML(0).TRAILER_NUMBER, structXML(0).MESSAGE_TYPE, structXML(0).ACTIV_INPUT_LOCATION)
                                ' consider adding lRecordsAffected
                                WriteLog(gcstrINFO, strRootTag.ToUpper & Space(1) & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER & "D35 Processed But WCS Had Not Sent A35 Response (Status was A35 not A35S)")

                            Else

                                WriteLog(gcstrError, strRootTag.ToUpper & Space(1) & "Message Rejected  - An Existing Request in A35S or M35 Status does not exist " & structXML(0).TRUCK_LINE & Space(2) & structXML(0).TRAILER_NUMBER)

                            End If
                        End If





                    Case Else


                        WriteLog(gcstrINFO, "Unknown Message Received" & Space(1) & strRootTag)

                End Select

            Catch

                WriteLog(gcstrError, "ParseXML: " & Err.Description)
            Finally

            End Try
        End Sub
       
        ' Display any validation errors.
        Private Shared Sub ValidationCallBack(ByVal sender As Object, ByVal e As ValidationEventArgs)
            WriteLog(gcstrError, "InvalidXML: " & e.Message)
        End Sub

    End Class

    Dim Msg41_Data As Object
    Dim Msg41_LINE_ITEM_DATA As Object

   

    Private Sub WriteLog(ByVal strAction As String, ByVal strText As String)
        Dim FilePath As String

        Try
            If giMessageLogLevel = -1 Then Exit Sub
            FilePath = LogFileName()
            My.Computer.FileSystem.WriteAllText(FilePath, Now & " | " & strAction.PadRight(15, Convert.ToChar(" ")) & strText.Trim & vbCrLf, True)
            gbNewOutboundData = True
        Catch

        Finally

        End Try
    End Sub


    Public Function Update_CUST_PALLET_ForA8(ByVal strULID As String, ByVal strBrand_Code As String, ByVal str_Brand_Desc As String, ByVal strCode_Date As String, _
                                             ByVal strPallet_Type As String, ByVal strHold_Status As String, ByVal strActiv_Input_location As String, ByVal strRetro_Status As String, _
                                             ByVal strRetro_loc As String, ByVal strPLC_USERID As String) As Long
        Dim strSql As String
        Dim oRecordsUpdated As Object = 0

        Try

            strSql = "update CUST_PALLET set " & _
            "BRAND_CODE ='" & strBrand_Code & "'," & _
            "BRAND_DESC='" & str_Brand_Desc & "'," & _
            "CODE_DATE='" & strCode_Date & "'," & _
            "PALLET_TYPE='" & strPallet_Type & "'," & _
            "HOLD_STATUS='" & strHold_Status & "'," & _
            "ACTIV_INPUT_LOCATION='" & strActiv_Input_location & "'," & _
            "RETRO_LOC='" & strRetro_loc & "'," & _
            "RETRO_STATUS='" & strRetro_Status & "', " & _
            "PLC_USERID='" & strPLC_USERID & "', " & _
            "CTRL_DATE='" & Date.Now.ToString & "' " & _
            "where CUST_ID ='" & strULID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql, oRecordsUpdated)
            End If

            Update_CUST_PALLET_ForA8 = CInt(oRecordsUpdated)

        Catch
            Update_CUST_PALLET_ForA8 = -1
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function


    Public Function Update_CUST_PALLET_RETRO_STATUS(ByVal strULID As String, ByVal strRETRO_STATUS As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_PALLET set " & _
            "RETRO_STATUS='" & strRETRO_STATUS & "'," & _
            "CTRL_DATE='" & Date.Now.ToString & "' " & _
            "where CUST_ID ='" & strULID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_PALLET_RETRO_STATUS = True

        Catch
            Update_CUST_PALLET_RETRO_STATUS = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function
    Public Function Update_CUST_PALLET_RETRO_STATUS_LOC(ByVal strULID As String, ByVal strRETRO_STATUS As String, ByVal strRetro_loc As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_PALLET set " & _
            "RETRO_STATUS='" & strRETRO_STATUS & "'," & _
            "RETRO_LOC='" & strRetro_loc & "'," &
            "CTRL_DATE='" & Date.Now.ToString & "' " & _
            "where CUST_ID ='" & strULID & "'"

            If gbShowOnlyTheBaseStackedULID = True Then
                strSql &= "or BASE_ULID ='" & strULID & "'"
            End If

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_PALLET_RETRO_STATUS_LOC = True

        Catch
            Update_CUST_PALLET_RETRO_STATUS_LOC = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function
    Public Function Update_CUST_PALLET_Cancelled_Withdraw(ByVal strShipID As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_PALLET set " & _
            "RETRO_STATUS='7'," & _
            "SHIP_ID=''," &
            "CTRL_DATE='" & Date.Now.ToString & "' " & _
            "where SHIP_ID ='" & strShipID & "' and retro_status <> '14'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_PALLET_Cancelled_Withdraw = True

        Catch
            Update_CUST_PALLET_Cancelled_Withdraw = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strShipID & Space(1) & Err.Description)

        End Try

    End Function

    Public Function Update_CUST_PALLET_RETRO_STATUS_SHIPID(ByVal strULID As String, ByVal strRETRO_STATUS As String, ByVal strShipID As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_PALLET set " & _
            "RETRO_STATUS='" & strRETRO_STATUS & "'," & _
            "SHIP_ID='" & strShipID & "'," &
            "CTRL_DATE='" & Date.Now.ToString & "' " & _
            "where CUST_ID ='" & strULID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_PALLET_RETRO_STATUS_SHIPID = True

        Catch
            Update_CUST_PALLET_RETRO_STATUS_SHIPID = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function

    

    Public Function Update_CUST_PALLET_MSG16(ByVal strULID As String, ByVal strCODE_DATE As String, _
                                             ByVal strULHOLD_STATUS As String) As Long

        Dim strSql As String
        Dim oRecordsUpdated As Object = 0

        Try

            strSql = "update CUST_PALLET set " & _
            "CODE_DATE='" & strCODE_DATE & "'," & _
            "HOLD_STATUS='" & strULHOLD_STATUS & "'," &
            "CTRL_DATE='" & Date.Now.ToString & "' " & _
            "where CUST_ID ='" & strULID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql, oRecordsUpdated)
            End If

            Update_CUST_PALLET_MSG16 = CLng(oRecordsUpdated)

        Catch
            Update_CUST_PALLET_MSG16 = -1
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function
    Private Sub ProcessMsg13(ByVal structXML As Msg13)
        Dim bSuccess As Boolean
        Dim x As Integer
        With structXML
            If .strWITHDRAWAL_INTENT_CODE = "N" Then
                'request is new
                If .strActiv_output_location.Length > 0 Then
                    If ManualOutputLocationExists(.strActiv_output_location) = False Then
                        WriteLog(gcstrINFO, "Requested Slot " & .strActiv_output_location & " Does Not Exist")
                    End If
                End If
                If .strUNIT_LOAD_ID.Length > 0 Then
                    'requesting a specific ULID

                    Dim structULReserved As ULReserved = IsUnitLoadReserved(.strUNIT_LOAD_ID)

                    If structULReserved.ULID = "-1" Then
                        'need to tell RTCIS that this UL does not exist
                        WriteLog("INFO", "MSG13 Specified UL Does Not Exist:  " & .strUNIT_LOAD_ID)
                    ElseIf structULReserved.SHIPID.Length > 0 And structULReserved.SHIPID <> "-1" Then
                        'need to tell RTCIS that this UL is already assigned
                        WriteLog("INFO", "MSG13 Specified UL Can't Be Retrieved:  " & .strUNIT_LOAD_ID)
                    Else
                        'can withdraw this UL - DAVE - update the db, use the GUI to send the response 13
                        Update_CUST_PALLET_RETRO_STATUS_SHIPID(.strUNIT_LOAD_ID, "13", .strHOST_CONTROL_NUMBER)

                        'populate shipment header
                        bSuccess = InsertInto_CUST_SHIPMENT(structXML.strHOST_CONTROL_NUMBER, "MR", "USER", _
                                String.Empty, Now.ToString, "13", structXML.strActiv_output_location)

                        'create  lineitem with ULID already known
                        bSuccess = InsertInto_CUST_LINEITEM(structXML.strHOST_CONTROL_NUMBER, x.ToString, x.ToString, structXML.strBRAND_CODE, _
                                structXML.strCODE_DATE, structXML.strPALLET_TYPE, "1", _
                                structXML.strWITHDRAWAL_SELECT_FLAG, "13", .strUNIT_LOAD_ID)

                    End If

                Else
                    'need to find a UL based on brand_code/pallet_type/code_date etc
                    'populate shipment header
                    bSuccess = InsertInto_CUST_SHIPMENT(structXML.strHOST_CONTROL_NUMBER, "MR", "USER", _
                            String.Empty, Now.ToString, "13", structXML.strActiv_output_location)

                    'create a lineitem record for each UL needed
                    For x = 1 To CInt(structXML.strUL_WITHDRAWAL_QTY)
                        bSuccess = InsertInto_CUST_LINEITEM(structXML.strHOST_CONTROL_NUMBER, x.ToString, x.ToString, structXML.strBRAND_CODE, _
                                structXML.strCODE_DATE, structXML.strPALLET_TYPE, "1", _
                                structXML.strWITHDRAWAL_SELECT_FLAG, "13", String.Empty)
                    Next


                End If
            ElseIf .strWITHDRAWAL_INTENT_CODE = "C" Then
                'need to cancel existing request
                Update_CUST_LINEITEM_WithdrawCancelled(.strHOST_CONTROL_NUMBER)
                '//dave  NEED to FINISH  - if the 14 hasnt been sent, remove the ULID
                Update_CUST_PALLET_Cancelled_Withdraw(.strHOST_CONTROL_NUMBER)

                WriteLog("INFO", "MSG13 Cancel Received:  " & .strHOST_CONTROL_NUMBER)

            Else
                WriteLog(gcstrError, "Invalid Withdraw Intent - Valid = N or C: " & .strHOST_CONTROL_NUMBER)
            End If



        End With
    End Sub


    Public Function InsertInto_CUST_SHIPMENT(ByVal strCUST_SHIPMENT As String, ByVal strSHIP_TYPE As String, _
       ByVal strUSER_ID As String, ByVal strPRIORITY As String, ByVal strAPP_DATETIME As String, _
       ByVal strRETRO_STATUS As String, ByVal strSLOT As String) As Boolean

        Dim strSql As String
        Dim strNEXTLEVELID As String

        Try

            'Default the nextlevelid
            strNEXTLEVELID = ActivLevelIds(0)

            strSql = "INSERT INTO CUST_SHIPMENT " & _
            "(CUST_SHIPMENT,SHIP_TYPE,USER_ID,DISPOSITION,APP_DATETIME,RETRO_STATUS,SLOT,NEXTLEVELID) values (" & _
            "'" & strCUST_SHIPMENT & "'," & _
            "'" & strSHIP_TYPE & "'," & _
            "'" & strUSER_ID & "'," & _
            "'" & strPRIORITY & "'," & _
            "'" & strAPP_DATETIME & "'," & _
            "'" & strRETRO_STATUS & "'," & _
            "'" & strSLOT & "'," & _
            "'" & strNEXTLEVELID & "' " & _
            ")"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            InsertInto_CUST_SHIPMENT = True

        Catch
            InsertInto_CUST_SHIPMENT = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strCUST_SHIPMENT & Space(1) & Err.Description)

        End Try

    End Function

    Public Function InsertInto_CUST_LINEITEM(ByVal strSHIP_ID As String, ByVal strLINE_ID As String, ByVal strSEQUENCE As String, _
      ByVal strBRAND_CODE As String, ByVal strCODE_DATE As String, ByVal strPAL_TYPE As String, _
      ByVal strQUANTITY As String, ByVal strSELECT_FLAG As String, ByVal strRETRO_STATUS As String, ByVal strCUST_ID As String) As Boolean

        Dim strSql As String

        Try

            strSql = "INSERT INTO CUST_LINEITEM " & _
            "(SHIP_ID,LINE_ID,SEQUENCE,BRAND_CODE,CODE_DATE,PAL_TYPE,QUANTITY,SELECT_FLAG,RETRO_STATUS,CUST_ID) values (" & _
            "'" & strSHIP_ID & "'," & _
            "'" & strLINE_ID & "'," & _
            "'" & strSEQUENCE & "'," & _
            "'" & strBRAND_CODE & "'," & _
            "'" & strCODE_DATE & "'," & _
            "'" & strPAL_TYPE & "'," & _
            "'" & strQUANTITY & "'," & _
            "'" & strSELECT_FLAG & "'," & _
            "'" & strRETRO_STATUS & "'," & _
            "'" & strCUST_ID & "'" & _
            ")"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            InsertInto_CUST_LINEITEM = True

        Catch
            InsertInto_CUST_LINEITEM = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strSHIP_ID & Space(1) & Err.Description)

        End Try

    End Function
    Private Function IsUnitLoadReserved(ByVal strULID As String) As ULReserved
        Dim strSQL As String

        Dim struct As ULReserved
        struct.SHIPID = "-1"
        struct.ULID = "-1"

        Try
            strSQL = "select CUST_ID,SHIP_ID " & _
                "from CUST_PALLET " & _
                "where " & _
                 "cust_id='" & strULID & "' "

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Do Until dbrec1.EOF

                struct.ULID = Convert.ToString(dbrec1.Fields("CUST_ID").Value)
                struct.SHIPID = Convert.ToString(dbrec1.Fields("SHIP_ID").Value)

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()


            Return struct

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function


    Public Function InsertInto_Msg16HSt(ByVal strCUST_ID As String, ByVal strCODE_DATE As String, ByVal strHOLD_STATUS As String, ByVal strBRAND_CODE As String) As Boolean

        Dim strSql As String

        Try

            strSql = "INSERT INTO MSG16HST " & _
            "(CUST_ID,CODE_DATE,HOLD_STATUS,BRAND_CODE) values (" & _
            "'" & strCUST_ID & "'," & _
            "'" & strCODE_DATE & "'," & _
            "'" & strHOLD_STATUS & "', " & _
              "'" & strBRAND_CODE & "' " & _
            ")"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            InsertInto_Msg16HSt = True

        Catch
            InsertInto_Msg16HSt = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strCUST_ID & Space(1) & Err.Description)

        End Try

    End Function


    Private Function WhatRetro_StatusIsShipment(ByVal strShipId As String) As String
        Dim strSQL As String
        WhatRetro_StatusIsShipment = "-1"

        Try
            strSQL = "select RETRO_STATUS " & _
                "from CUST_SHIPMENT " & _
                "where " & _
                 "cust_shipment='" & strShipId & "' "

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Do Until dbrec1.EOF

                WhatRetro_StatusIsShipment = Convert.ToString(dbrec1.Fields("RETRO_STATUS").Value)


                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()


        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try
    End Function
    Private Function WhatSlotAssignedToShipment(ByVal strShipId As String) As String
        Dim strSQL As String
        WhatSlotAssignedToShipment = "-1"

        Try
            strSQL = "select SLOT " & _
                "from CUST_SHIPMENT " & _
                "where " & _
                 "cust_shipment='" & strShipId & "' "

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Do Until dbrec1.EOF

                WhatSlotAssignedToShipment = Convert.ToString(dbrec1.Fields("SLOT").Value)


                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()


        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try
    End Function

    Private Function WhatShipmentAssignedToSlot(ByVal strSlot As String) As String
        Dim strSQL As String
        WhatShipmentAssignedToSlot = "-1"

        Try
            strSQL = "select cust_shipment " & _
                "from CUST_SHIPMENT " & _
                "where " & _
                "slot='" & strSlot & "' "

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Do Until dbrec1.EOF

                WhatShipmentAssignedToSlot = Convert.ToString(dbrec1.Fields("CUST_SHIPMENT").Value)


                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()


        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try
    End Function
    Public Function Update_CUST_LINEITEM_WithdrawCancelled(ByVal strSHIPID As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_LINEITEM set " & _
            "RETRO_STATUS='13C' " & _
            "where SHIP_ID ='" & strSHIPID & "' and retro_status='13S' "

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_LINEITEM_WithdrawCancelled = True

        Catch
            Update_CUST_LINEITEM_WithdrawCancelled = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strSHIPID & Space(1) & Err.Description)

        End Try

    End Function
    Public Function Update_CUST_LINEITEM_CancelNonStagedItems(ByVal strSHIPID As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_LINEITEM set " & _
            "RETRO_STATUS='CANCLD' " & _
            "where SHIP_ID ='" & strSHIPID & "' and CUST_ID='' "

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_LINEITEM_CancelNonStagedItems = True

        Catch
            Update_CUST_LINEITEM_CancelNonStagedItems = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strSHIPID & Space(1) & Err.Description)

        End Try

    End Function

    
    Public Sub ShortInventoryCheck(ByVal strShip_Id As String)
        Dim strSQL As String
        Dim strULIDCount As String
        Dim iUlidCount As Integer
        Dim iLineItemSum As Integer
        Dim strBrand_Code As String
        Dim strPAL_TYPE As String
        Dim bShortInventory As Boolean
        Try

            WriteLog(gcstrINFO, "...Checking Available Inventory for Control# " & strShip_Id & "...")

            strSQL = "select SHIP_ID, BRAND_CODE,PAL_TYPE,SumOfQUANTITY, ULIDCOUNT " & _
                "from qryAvailableInventoryforLineItem " & _
                "where " & _
                "ship_id='" & strShip_Id & "' " & _
                "order by BRAND_CODE,PAL_TYPE"

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Do Until dbrec1.EOF

                strULIDCount = Convert.ToString(dbrec1.Fields("ULIDCOUNT").Value)
                If IsNumeric(strULIDCount) = False Then

                    iUlidCount = 0
                Else
                    iUlidCount = CInt(strULIDCount)
                End If

                iLineItemSum = CInt(Convert.ToString(dbrec1.Fields("SumOfQUANTITY").Value))
                If iLineItemSum > iUlidCount Then

                    strBrand_Code = Convert.ToString(dbrec1.Fields("BRAND_CODE").Value)
                    strPAL_TYPE = Convert.ToString(dbrec1.Fields("PAL_TYPE").Value)

                    WriteLog(gcstrINFO, "Shipid " & strShip_Id & " Short Brand " & strBrand_Code & " Paltyp " & strPAL_TYPE & " Short Qty " & (iLineItemSum - iUlidCount).ToString)
                    bShortInventory = True
                End If

                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()

            If bShortInventory = False Then
                WriteLog(gcstrINFO, "All Inventory Available for Shipid " & strShip_Id)
            End If

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Sub

    
    Dim Msg21_LINE_ITEM_DATA As Object
    Dim Msg21_Data As Object
    Dim RequestFPDS_LINE_ITEM_DATA As Object
    Dim RequestFPDS_Data As Object
    Dim Msg_Data As Object
    Public Function ReadXML_ConfirmHeartbeat(ByVal document As XDocument) As Confirm_Heartbeat
        Dim struct As New Confirm_Heartbeat

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("ConfirmHeartBeatData") _
                     Select New With _
                     { _
                        .TEXT = Msg_Data.Element("TEXT").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.strText = Msg_Data.TEXT
            Next

            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_Msg06(ByVal document As XDocument) As Msg6
        Dim struct As New Msg6

        Try


            Dim HeaderItems As Object = From Msg_Data In document.Descendants("ULDATA") _
                     Select New With _
                     { _
                        .UNIT_LOAD_ID = Msg_Data.Element("UNIT_LOAD_ID").Value, _
                        .DELIVERY_LOCATION = Msg_Data.Element("DELIVERY_LOCATION").Value, _
                        .UNIT_LOAD_FORMER_ID = Msg_Data.Element("UNIT_LOAD_FORMER_ID").Value, _
                        .USER_ID = Msg_Data.Element("USER_ID").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.strCust_ID = Msg_Data.UNIT_LOAD_ID
                struct.strActiv_Input_Location = Msg_Data.DELIVERY_LOCATION
                struct.strUNIT_LOAD_FORMER_ID = Msg_Data.UNIT_LOAD_FORMER_ID
                struct.strUSER_ID = Msg_Data.USER_ID
            Next


            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_MessageHeader(ByVal document As XDocument) As MessageHeader
        Dim struct As New MessageHeader

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("MessageHeader") _
                     Select New With _
                     { _
                        .SESSION_KEY = Msg_Data.Element("SESSION_KEY").Value, _
                        .MESSAGE_ID = Msg_Data.Element("MESSAGE_ID").Value, _
                        .TIMESTAMP = Msg_Data.Element("TIMESTAMP").Value, _
                        .USER_ID = Msg_Data.Element("USER_ID").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.SESSION_KEY = Msg_Data.SESSION_KEY
                struct.MESSAGE_ID = Msg_Data.MESSAGE_ID
                struct.TIMESTAMP = Msg_Data.TIMESTAMP
            Next


            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_Msg08(ByVal document As XDocument) As Msg8
        Dim struct As New Msg8

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("RequestLocForPallet") _
                     Select New With _
                     { _
                         .MESSAGE_TYPE = Msg_Data.Element("MESSAGE_TYPE").Value, _
                        .ULID = Msg_Data.Element("UNIT_LOAD_ID").Value, _
                        .BRAND_CODE = Msg_Data.Element("BRAND_CODE").Value, _
                        .BRAND_DESCRIPTION = Msg_Data.Element("BRAND_DESCRIPTION").Value, _
                        .CODE_DATE = Msg_Data.Element("CODE_DATE").Value, _
                        .PALLET_TYPE = Msg_Data.Element("PALLET_TYPE").Value, _
                        .UL_HOLD_STATUS_CODE = Msg_Data.Element("UL_HOLD_STATUS_CODE").Value, _
                        .ACTIV_INPUT_LOCATION = Msg_Data.Element("ACTIV_INPUT_LOCATION").Value, _
                        .ITEM_GROUP = Msg_Data.Element("ITEM_GROUP").Value, _
                        .BASE_ULID = Msg_Data.Element("BASE_ULID").Value, _
                        .CASE_QUANTITY = Msg_Data.Element("CASE_QUANTITY").Value, _
                        .PARTIAL_FLAG = Msg_Data.Element("PARTIAL_FLAG").Value, _
                        .PLC_USERID = Msg_Data.Element("PLC_USERID").Value _
                     }


            For Each Msg_Data In HeaderItems
                struct.strMsgTyp = Msg_Data.MESSAGE_TYPE
                struct.strCust_ID = Msg_Data.ULID
                struct.strBrand_Code = Msg_Data.BRAND_CODE
                struct.strBrand_Desc = Msg_Data.BRAND_DESCRIPTION
                struct.strCode_Date = Msg_Data.CODE_DATE
                struct.strPallet_Type = Msg_Data.PALLET_TYPE
                struct.strHold_Status = Msg_Data.UL_HOLD_STATUS_CODE
                struct.strActiv_Input_Location = Msg_Data.ACTIV_INPUT_LOCATION
                struct.strItem_group = Msg_Data.ITEM_GROUP
                struct.strBase_ulid = Msg_Data.BASE_ULID
                struct.strCase_quantity = Msg_Data.CASE_QUANTITY
                struct.strPartial_flag = Msg_Data.PARTIAL_FLAG
                struct.strPLC_USERID = Msg_Data.PLC_USERID
            Next


            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_Msg13(ByVal document As XDocument) As Msg13
        Dim struct As New Msg13

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("RequestInventory") _
                     Select New With _
                     { _
                         .MESSAGE_TYPE = Msg_Data.Element("MESSAGE_TYPE").Value, _
                         .HOST_CONTROL_NUMBER = Msg_Data.Element("HOST_CONTROL_NUMBER").Value, _
                        .BRAND_CODE = Msg_Data.Element("BRAND_CODE").Value, _
                        .UNIT_LOAD_ID = Msg_Data.Element("UNIT_LOAD_ID").Value, _
                        .CODE_DATE = Msg_Data.Element("CODE_DATE").Value, _
                        .PALLET_TYPE = Msg_Data.Element("PALLET_TYPE").Value, _
                        .UL_WITHDRAWAL_QTY = Msg_Data.Element("UL_WITHDRAWAL_QTY").Value, _
                        .ACTIV_OUTPUT_LOCATION = Msg_Data.Element("ACTIV_OUTPUT_LOCATION").Value, _
                        .WITHDRAWAL_INTENT_CODE = Msg_Data.Element("WITHDRAWAL_INTENT_CODE").Value, _
                        .WITHDRAWAL_SELECT_FLAG = Msg_Data.Element("WITHDRAWAL_SELECT_FLAG").Value, _
                        .WITHDRAWAL_PARTIAL_CODE = Msg_Data.Element("WITHDRAWAL_PARTIAL_CODE").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.strMESSAGE_TYPE = Msg_Data.MESSAGE_TYPE
                struct.strHOST_CONTROL_NUMBER = Msg_Data.HOST_CONTROL_NUMBER
                struct.strBRAND_CODE = Msg_Data.BRAND_CODE
                struct.strUNIT_LOAD_ID = Msg_Data.UNIT_LOAD_ID
                struct.strCODE_DATE = Msg_Data.CODE_DATE
                struct.strPALLET_TYPE = Msg_Data.PALLET_TYPE
                struct.strUL_WITHDRAWAL_QTY = Msg_Data.UL_WITHDRAWAL_QTY
                struct.strActiv_output_location = Msg_Data.ACTIV_OUTPUT_LOCATION
                struct.strWITHDRAWAL_INTENT_CODE = Msg_Data.WITHDRAWAL_INTENT_CODE
                struct.strWITHDRAWAL_SELECT_FLAG = Msg_Data.WITHDRAWAL_SELECT_FLAG
                struct.strWITHDRAWAL_PARTIAL_CODE = Msg_Data.WITHDRAWAL_PARTIAL_CODE
            Next


            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_Msg16(ByVal document As XDocument) As Msg16
        Dim struct As New Msg16

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("ChangeULQA") _
                     Select New With _
                     { _
                         .UNIT_LOAD_ID = Msg_Data.Element("UNIT_LOAD_ID").Value, _
                        .BRAND_CODE = Msg_Data.Element("BRAND_CODE").Value, _
                        .CODE_DATE = Msg_Data.Element("CODE_DATE").Value, _
                        .UL_HOLD_STATUS_CODE = Msg_Data.Element("UL_HOLD_STATUS_CODE").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.strUnit_Load_Id = Msg_Data.UNIT_LOAD_ID
                struct.strBrand_Code = Msg_Data.BRAND_CODE
                struct.strCode_Date = Msg_Data.CODE_DATE
                struct.strUl_hold_Status_code = Msg_Data.UL_HOLD_STATUS_CODE
            Next


            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_Msg20(ByVal document As XDocument) As Msg20
        Dim struct As New Msg20

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("StopShip") _
                     Select New With _
                     { _
                        .MESSAGE_TYPE = Msg_Data.Element("MESSAGE_TYPE").Value, _
                        .HOST_CONTROL_NUMBER = Msg_Data.Element("HOST_CONTROL_NUMBER").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.strMESSAGE_TYPE = Msg_Data.MESSAGE_TYPE
                struct.strHOST_CONTROL_NUMBER = Msg_Data.HOST_CONTROL_NUMBER
            Next


            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function

    Public Function ReadXML_Msg21(ByVal document As XDocument) As Msg21()
        Dim struct(0) As Msg21
        Dim iMsg21_LINE_ITEM_DATA_Count As Integer = -1

        Try

            'ignorign message_type

            '.WITHDRAW_SELECT_FLAG = Msg21_Data.Element("WITHDRAW_SELECT_FLAG").Value,
            Dim HeaderItems As Object = From Msg21_Data In document.Descendants("ShipHeader")
                                        Select New With
                     {
                        .HOST_CONTROL_NUMBER = Msg21_Data.Element("HOST_CONTROL_NUMBER").Value,
                        .WITHDRAWAL_SELECT_FLAG = Msg21_Data.Element("WITHDRAWAL_SELECT_FLAG").Value,
                        .SCHEDULED_SHIP_DATE = Msg21_Data.Element("SCHEDULED_SHIP_DATE").Value,
                        .SCHEDULED_SHIP_TIME = Msg21_Data.Element("SCHEDULED_SHIP_TIME").Value,
                        .ORDER_DISPOSITION = Msg21_Data.Element("ORDER_DISPOSITION").Value,
                        .LINE_COUNT = Msg21_Data.Element("LINE_COUNT").Value
                     }

            For Each Msg21_Data In HeaderItems
                struct(0).HOST_CONTROL_NUMBER = Msg21_Data.HOST_CONTROL_NUMBER
                'struct(0).WITHDRAW_SELECT_FLAG = Msg21_Data.WITHDRAW_SELECT_FLAG
                struct(0).WITHDRAWAL_SELECT_FLAG = Msg21_Data.WITHDRAWAL_SELECT_FLAG
                struct(0).SCHEDULED_SHIP_DATE = Msg21_Data.SCHEDULED_SHIP_DATE
                struct(0).SCHEDULED_SHIP_TIME = Msg21_Data.SCHEDULED_SHIP_TIME
                struct(0).ORDER_DISPOSITION = Msg21_Data.ORDER_DISPOSITION
                struct(0).LINE_COUNT = Msg21_Data.LINE_COUNT
            Next

            Dim LineItems As Object = From Msg21_LINE_ITEM_DATA In document.Descendants("ShipUL") _
                         Select New With _
                         { _
                            .SEQUENCE = Msg21_LINE_ITEM_DATA.Element("SEQUENCE").Value, _
                            .BRAND_CODE = Msg21_LINE_ITEM_DATA.Element("BRAND_CODE").Value, _
                            .CODE_DATE = Msg21_LINE_ITEM_DATA.Element("CODE_DATE").Value, _
                            .PALLET_TYPE = Msg21_LINE_ITEM_DATA.Element("PALLET_TYPE").Value, _
                            .LINE_QTY = Msg21_LINE_ITEM_DATA.Element("LINE_QTY").Value, _
                            .FIFO_WINDOW = Msg21_LINE_ITEM_DATA.Element("FIFO_WINDOW").Value _
                         }

            For Each Msg21_LINE_ITEM_DATA In LineItems

                iMsg21_LINE_ITEM_DATA_Count += 1
                ReDim Preserve struct(iMsg21_LINE_ITEM_DATA_Count)

                struct(iMsg21_LINE_ITEM_DATA_Count).SEQUENCE = Msg21_LINE_ITEM_DATA.SEQUENCE
                struct(iMsg21_LINE_ITEM_DATA_Count).BRAND_CODE = Msg21_LINE_ITEM_DATA.BRAND_CODE
                struct(iMsg21_LINE_ITEM_DATA_Count).CODE_DATE = Msg21_LINE_ITEM_DATA.CODE_DATE
                struct(iMsg21_LINE_ITEM_DATA_Count).PALLET_TYPE = Msg21_LINE_ITEM_DATA.PALLET_TYPE
                struct(iMsg21_LINE_ITEM_DATA_Count).LINE_QTY = Msg21_LINE_ITEM_DATA.LINE_QTY
                struct(iMsg21_LINE_ITEM_DATA_Count).FIFO_WINDOW = Msg21_LINE_ITEM_DATA.FIFO_WINDOW

            Next
            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_Msg25(ByVal document As XDocument) As Msg25
        Dim struct As New Msg25

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("LocEmpty") _
                     Select New With _
                     { _
                        .MESSAGE_TYPE = Msg_Data.Element("MESSAGE_TYPE").Value, _
                        .HOST_CONTROL_NUMBER = Msg_Data.Element("HOST_CONTROL_NUMBER").Value, _
                        .ACTIV_OUTPUT_LOCATION = Msg_Data.Element("ACTIV_OUTPUT_LOCATION").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.strMESSAGE_TYPE = Msg_Data.MESSAGE_TYPE
                struct.strHOST_CONTROL_NUMBER = Msg_Data.HOST_CONTROL_NUMBER
                struct.strACTIV_OUTPUT_LOCATION = Msg_Data.ACTIV_OUTPUT_LOCATION

            Next


            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_Msg26(ByVal document As XDocument) As Msg26
        Dim struct As New Msg26

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("StopStage") _
                     Select New With _
                     { _
                        .MESSAGE_TYPE = Msg_Data.Element("MESSAGE_TYPE").Value, _
                        .HOST_CONTROL_NUMBER = Msg_Data.Element("HOST_CONTROL_NUMBER").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.strMESSAGE_TYPE = Msg_Data.MESSAGE_TYPE
                struct.strHOST_CONTROL_NUMBER = Msg_Data.HOST_CONTROL_NUMBER
            Next

            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_Msg32(ByVal document As XDocument) As Msg32
        Dim struct As New Msg32

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("SlotRequest") _
                     Select New With _
                     { _
                        .MESSAGE_TYPE = Msg_Data.Element("MESSAGE_TYPE").Value, _
                        .HOST_CONTROL_NUMBER = Msg_Data.Element("HOST_CONTROL_NUMBER").Value, _
                        .ACTIV_OUTPUT_LOCATION = Msg_Data.Element("ACTIV_OUTPUT_LOCATION").Value, _
                        .SIGNON_FLG = Msg_Data.Element("SIGNON_FLG").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.strMESSAGE_TYPE = Msg_Data.MESSAGE_TYPE
                struct.strHOST_CONTROL_NUMBER = Msg_Data.HOST_CONTROL_NUMBER
                struct.strACTIV_OUTPUT_LOCATION = Msg_Data.ACTIV_OUTPUT_LOCATION
                struct.strSIGNON_FLG = Msg_Data.SIGNON_FLG

            Next


            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_Msg40(ByVal document As XDocument) As Msg40
        Dim struct As New Msg40

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("StopProdOrder") _
                     Select New With _
                     { _
                        .MESSAGE_TYPE = Msg_Data.Element("MESSAGE_TYPE").Value, _
                        .HOST_CONTROL_NUMBER = Msg_Data.Element("HOST_CONTROL_NUMBER").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.strMESSAGE_TYPE = Msg_Data.MESSAGE_TYPE
                struct.strHOST_CONTROL_NUMBER = Msg_Data.HOST_CONTROL_NUMBER
            Next


            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_Msg41(ByVal document As XDocument) As Msg41()
        Dim struct(0) As Msg41
        Dim iMsg41_LINE_ITEM_DATA_Count As Integer = -1

        Try

            'ignorign message_type

            Dim HeaderItems As Object = From Msg41_Data In document.Descendants("ProdOrderHeader") _
                     Select New With _
                     { _
                        .HOST_CONTROL_NUMBER = Msg41_Data.Element("HOST_CONTROL_NUMBER").Value, _
                        .SCHEDULED_START_DATE = Msg41_Data.Element("SCHEDULED_START_DATE").Value, _
                        .SCHEDULED_START_TIME = Msg41_Data.Element("SCHEDULED_START_TIME").Value, _
                        .ORDER_DISPOSITION = Msg41_Data.Element("ORDER_DISPOSITION").Value, _
                        .LINE_COUNT = Msg41_Data.Element("LINE_COUNT").Value _
                     }

            For Each Msg41_Data In HeaderItems
                struct(0).HOST_CONTROL_NUMBER = Msg41_Data.HOST_CONTROL_NUMBER
                struct(0).SCHEDULED_START_DATE = Msg41_Data.SCHEDULED_START_DATE
                struct(0).SCHEDULED_START_TIME = Msg41_Data.SCHEDULED_START_TIME
                struct(0).ORDER_DISPOSITION = Msg41_Data.ORDER_DISPOSITION
                struct(0).LINE_COUNT = Msg41_Data.LINE_COUNT
            Next

            Dim LineItems As Object = From Msg41_LINE_ITEM_DATA In document.Descendants("ProdOrderUL") _
                         Select New With _
                         { _
                            .SEQUENCE = Msg41_LINE_ITEM_DATA.Element("SEQUENCE").Value, _
                            .BRAND_CODE = Msg41_LINE_ITEM_DATA.Element("BRAND_CODE").Value, _
                            .CODE_DATE = Msg41_LINE_ITEM_DATA.Element("CODE_DATE").Value, _
                            .PALLET_TYPE = Msg41_LINE_ITEM_DATA.Element("PALLET_TYPE").Value, _
                            .LINE_QTY = Msg41_LINE_ITEM_DATA.Element("LINE_QTY").Value, _
                            .FIFO_WINDOW = Msg41_LINE_ITEM_DATA.Element("FIFO_WINDOW").Value _
                         }

            For Each Msg41_LINE_ITEM_DATA In LineItems

                iMsg41_LINE_ITEM_DATA_Count += 1
                ReDim Preserve struct(iMsg41_LINE_ITEM_DATA_Count)

                struct(iMsg41_LINE_ITEM_DATA_Count).SEQUENCE = Msg41_LINE_ITEM_DATA.SEQUENCE
                struct(iMsg41_LINE_ITEM_DATA_Count).BRAND_CODE = Msg41_LINE_ITEM_DATA.BRAND_CODE
                struct(iMsg41_LINE_ITEM_DATA_Count).CODE_DATE = Msg41_LINE_ITEM_DATA.CODE_DATE
                struct(iMsg41_LINE_ITEM_DATA_Count).PALLET_TYPE = Msg41_LINE_ITEM_DATA.PALLET_TYPE
                struct(iMsg41_LINE_ITEM_DATA_Count).LINE_QTY = Msg41_LINE_ITEM_DATA.LINE_QTY
                struct(iMsg41_LINE_ITEM_DATA_Count).FIFO_WINDOW = Msg41_LINE_ITEM_DATA.FIFO_WINDOW

            Next
            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_MsgSlotDestage(ByVal document As XDocument) As MsgSlotDestage
        Dim struct As New MsgSlotDestage

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants("SlotRequest") _
                     Select New With _
                     { _
                        .MESSAGE_TYPE = Msg_Data.Element("MESSAGE_TYPE").Value, _
                        .ACTIV_OUTPUT_LOCATION = Msg_Data.Element("ACTIV_OUTPUT_LOCATION").Value _
                     }

            For Each Msg_Data In HeaderItems
                struct.strMESSAGE_TYPE = Msg_Data.MESSAGE_TYPE
                struct.strACTIV_OUTPUT_LOCATION = Msg_Data.ACTIV_OUTPUT_LOCATION
            Next


            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function GetOptionalXMLValue(ByVal elem As XElement, ByVal strElementNAme As String) As String
        Dim child As Object = elem.Element(strElementNAme)
        If child Is Nothing Then
            Return String.Empty
        Else
            Return child.Value
        End If
    End Function
    Public Function ReadXML_RequestFPDS(ByVal document As XDocument) As RequestFPDS()
        Dim struct(0) As RequestFPDS
        Dim iRequestFPDS_LINE_ITEM_DATA_Count As Integer = -1

        Try

            'ignorign message_type
            'the ctype indicates optional fields and is used to aviod an exception error when the field is not present 

            Dim HeaderItems As Object = From RequestFPDS_Data In document.Descendants("TrailerHeader") _
                     Select New With _
                     { _
                        .MESSAGE_TYPE = RequestFPDS_Data.Element("MESSAGE_TYPE").Value, _
                        .TRAILER_NUMBER = RequestFPDS_Data.Element("TRAILER_NUMBER").Value, _
                        .TRUCK_LINE = RequestFPDS_Data.Element("TRUCK_LINE").Value, _
                        .LINE_COUNT = RequestFPDS_Data.Element("LINE_COUNT").Value, _
                        .ACTIV_INPUT_LOCATION = GetOptionalXMLValue(RequestFPDS_Data, "ACTIV_INPUT_CONVEYOR") _
                     }

            ' .ACTIV_INPUT_LOCATION = CType(RequestFPDS_Data.Element("BOB").Value, String) _

            For Each RequestFPDS_Data In HeaderItems
                struct(0).MESSAGE_TYPE = RequestFPDS_Data.MESSAGE_TYPE
                struct(0).TRAILER_NUMBER = RequestFPDS_Data.TRAILER_NUMBER
                struct(0).TRUCK_LINE = RequestFPDS_Data.TRUCK_LINE
                struct(0).LINE_COUNT = RequestFPDS_Data.LINE_COUNT
                struct(0).ACTIV_INPUT_LOCATION = RequestFPDS_Data.ACTIV_INPUT_LOCATION
            Next

            Dim LineItems As Object = From RequestFPDS_LINE_ITEM_DATA In document.Descendants("TrailerUL") _
                         Select New With _
                         { _
                            .UNIT_LOAD_ID = RequestFPDS_LINE_ITEM_DATA.Element("UNIT_LOAD_ID").Value, _
                            .BRAND_CODE = RequestFPDS_LINE_ITEM_DATA.Element("BRAND_CODE").Value, _
                            .ITEM_NUMBER = RequestFPDS_LINE_ITEM_DATA.Element("ITEM_NUMBER").Value, _
                            .PALLET_TYPE = RequestFPDS_LINE_ITEM_DATA.Element("PALLET_TYPE").Value _
                         }

            For Each RequestFPDS_LINE_ITEM_DATA In LineItems

                iRequestFPDS_LINE_ITEM_DATA_Count += 1
                ReDim Preserve struct(iRequestFPDS_LINE_ITEM_DATA_Count)

                struct(iRequestFPDS_LINE_ITEM_DATA_Count).UNIT_LOAD_ID = RequestFPDS_LINE_ITEM_DATA.UNIT_LOAD_ID
                struct(iRequestFPDS_LINE_ITEM_DATA_Count).BRAND_CODE = RequestFPDS_LINE_ITEM_DATA.BRAND_CODE
                struct(iRequestFPDS_LINE_ITEM_DATA_Count).ITEM_NUMBER = RequestFPDS_LINE_ITEM_DATA.ITEM_NUMBER
                struct(iRequestFPDS_LINE_ITEM_DATA_Count).PALLET_TYPE = RequestFPDS_LINE_ITEM_DATA.PALLET_TYPE

            Next
            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function

    Public Function InsertInto_TRAILER_FPDS(ByVal strMESSAGE_TYPE As String, ByVal strTRAILER_NUMBER As String, _
     ByVal strTRUCK_LINE As String, ByVal strLINE_COUNT As String) As Boolean

        Dim strSql As String

        Try

            strSql = "INSERT INTO TRAILER_FPDS " & _
            "(MESSAGE_TYPE,TRAILER_NUMBER,TRUCK_LINE,LINE_COUNT,CTRL_DATE) values (" & _
            "'" & strMESSAGE_TYPE & "'," & _
            "'" & strTRAILER_NUMBER & "'," & _
            "'" & strTRUCK_LINE & "'," & _
            "'" & strLINE_COUNT & "'," & _
            "'" & Date.Now.ToString & "' " & _
            ")"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            InsertInto_TRAILER_FPDS = True

        Catch
            InsertInto_TRAILER_FPDS = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strTRUCK_LINE & "|" & strTRAILER_NUMBER & Space(1) & Err.Description)

        End Try

    End Function

    Private Function ReadTrailer_FPDS_MessageTypeFromDB(ByVal strTruck_Line As String, ByVal strTrailer_Number As String) As String
        Dim strSQL As String
        ReadTrailer_FPDS_MessageTypeFromDB = "-1"

        Try
            strSQL = "select MESSAGE_TYPE " & _
                "from TRAILER_FPDS " & _
                "where " & _
                "TRUCK_LINE='" & strTruck_Line & "' and " & _
                "TRAILER_NUMBER='" & strTrailer_Number & "' "

            ' Open the Recordset using the select string:
            dbrec1.Open(strSQL, DBCON1)

            Do Until dbrec1.EOF

                ReadTrailer_FPDS_MessageTypeFromDB = Convert.ToString(dbrec1.Fields("MESSAGE_TYPE").Value)


                dbrec1.MoveNext()

            Loop

            'Close Recordset:
            dbrec1.Close()


        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try
    End Function

    Public Function ReadXML_TrailerCheckinConfirm(ByVal document As XDocument) As TrailerCheckinConfirm
        Dim struct As New TrailerCheckinConfirm

        Try
            'Dim HeaderItems As Object = From Msg_Data In document.Descendants(TRL_CKIN_CONF_DATA_TAG)
            '                            Select New With
            '                            {
            '                               .TRAILER_NUMBER = Msg_Data.Element("TRAILER_NUMBER").Value,
            '                               .TRUCK_LINE = Msg_Data.Element("TRUCK_LINE").Value,
            '                               .TRACTOR_ID = Msg_Data.Element("TRACTOR_ID").Value,
            '                               .SHIPMENT_ID = Msg_Data.Element("SHIPMENT_ID").Value,
            '                               .RR_NUMBER = Msg_Data.Element("RR_NUMBER").Value,
            '                               .SITE_NAME = Msg_Data.Element("SITE_NAME").Value,
            '                               .BUILDING = Msg_Data.Element("BUILDING").Value,
            '                               .LOCATION = Msg_Data.Element("LOCATION").Value,
            '                               .INVOICE_NUMBER = Msg_Data.Element("INVOICE_NUMBER").Value,
            '                               .ERROR_CODE = Msg_Data.Element("ERROR_CODE").Value,
            '                               .ERROR_MSG = Msg_Data.Element("ERROR_MSG").Value
            '                            }

            'Dim dataDict As Dictionary(Of String, String) = From elem In document.Descendants(TRL_CKIN_CONF_DATA_TAG).ToDictionary(Of String, String)(XElement.Name.ToString(), elem.Value)
            '                                                            Select New Dictionary(elem.Name.ToString(), elem.Value)

            'Dim dic As Object = From elem In document.Descendants(TRL_CKIN_CONF_DATA_TAG).ToDictionary(Of String, String)(Function(p) p.Name.ToString, Function(p) p.Value)

            'Select Case New KeyValuePair(Of String, String)(elem.Name.ToString(), elem.Value)

            'Dim dataDict As KeyValuePair(Of String, String) = CType(dic, KeyValuePair(Of String, String))

            Dim dataDict As Dictionary(Of String, String) = (From elem In document.Descendants(TRL_CKIN_CONF_DATA_TAG).Elements()
                                                             Select New KeyValuePair(Of String, String)(elem.Name.ToString(), elem.Value)).ToDictionary(Function(p) p.Key, Function(p) p.Value)

            'gives exception
            'Dim dataDict As Dictionary(Of String, String) = From elem In document.Descendants(TRL_CKIN_CONF_DATA_TAG).Elements()
            '                                                Select New KeyValuePair(Of String, String)(elem.Name.ToString(), elem.Value)





            'Dim val As String = ""


            'For Each elem As String In trlCkInConfTagLst
            '    val += elem + "=" + dataDict.Item(elem) + " - " + vbCrLf

            'Next
            Dim updateStatus As Boolean = updateTCS_TRAILER_EMU(trlCkInConfTagLst, dataDict)
            'If (updateStatus = False) Then
            '    WriteLog(gcstrError, GetCurrentMethod.Name() & val)
            'End If

            ''''For Each Msg_Data In HeaderItems
            ''''    struct.strTRAILER_NUMBER = Msg_Data.TRAILER_NUMBER
            ''''    struct.strTRUCK_LINE = Msg_Data.TRUCK_LINE
            ''''    struct.strTRACTOR_ID = Msg_Data.TRACTOR_ID
            ''''    struct.strSHIPMENT_ID = Msg_Data.SHIPMENT_ID
            ''''    struct.strRR_NUMBER = Msg_Data.RR_NUMBER
            ''''    struct.strBUILDING = Msg_Data.BUILDING
            ''''    struct.strLOCATION = Msg_Data.LOCATION
            ''''    struct.strINVOICE_NUMBER = Msg_Data.INVOICE_NUMBER
            ''''    struct.strERROR_CODE = Msg_Data.ERROR_CODE
            ''''    struct.strERROR_MSG = Msg_Data.ERROR_MSG
            ''''Next

            'Dim nvp As New System.Collections.Specialized.NameValueCollection

            'nvp.Add("TRAILER_NUMBER", Msg_Data.Element("TRAILER_NUMBER").Value)

            'process the confirmation message in RAID db
            'ckeck if record exists 
            'if tractor id exist 
            'If (Len(struct.strTRACTOR_ID) > 0 And
            ' checkTCS_TRAILER_EMU(struct.strTRUCK_LINE, struct.strTRAILER_NUMBER, struct.strTRACTOR_ID) = True) Then

            'ElseIf (checkTCS_TRAILER_EMU(struct.strTRUCK_LINE, struct.strTRAILER_NUMBER, "")) Then
            '    updateTCS_TRAILER_EMU(st)

            'End If

            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function

    Public Function ReadXML_TrailerCheckOutConfirm(ByVal document As XDocument) As TrailerCheckOutConfirm
        Dim struct As New TrailerCheckOutConfirm

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants(TRL_CKOUT_CONF_DATA_TAG)
                                        Select New With
                                        {
                                           .TRAILER_NUMBER = Msg_Data.Element("TRAILER_NUMBER").Value,
                                           .TRUCK_LINE = Msg_Data.Element("TRUCK_LINE").Value,
                                           .TRACTOR_ID = Msg_Data.Element("TRACTOR_ID").Value,
                                           .SHIPMENT_ID = Msg_Data.Element("SHIPMENT_ID").Value,
                                           .RR_NUMBER = Msg_Data.Element("PO_NUMBER").Value,
                                           .ERROR_CODE = Msg_Data.Element("ERROR_CODE").Value,
                                           .ERROR_MSG = Msg_Data.Element("ERROR_MSG").Value
                                        }

            For Each Msg_Data In HeaderItems
                struct.strTRAILER_NUMBER = Msg_Data.TRAILER_NUMBER
                struct.strTRUCK_LINE = Msg_Data.TRUCK_LINE
                struct.strTRACTOR_ID = Msg_Data.TRACTOR_ID
                struct.strSHIPMENT_ID = Msg_Data.SHIPMENT_ID
                struct.strPO_NUMBER = Msg_Data.RR_NUMBER
                struct.strERROR_CODE = Msg_Data.ERROR_CODE
                struct.strERROR_MSG = Msg_Data.ERROR_MSG
            Next
            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function

    Public Function ReadXML_TrailerLocAsgnmtConfirm(ByVal document As XDocument) As TrailerLocAsgnmtConfirm
        Dim struct As New TrailerLocAsgnmtConfirm

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants(TRL_LOC_ASSG_CONF_DATA_TAG)
                                        Select New With
                                        {
                                           .TRAILER_NUMBER = Msg_Data.Element("TRAILER_NUMBER").Value,
                                           .TRUCK_LINE = Msg_Data.Element("TRUCK_LINE").Value,
                                           .SITE_NAME = Msg_Data.Element("SITE_NAME").Value,
                                           .SHIPMENT_ID = Msg_Data.Element("SHIPMENT_ID").Value,
                                           .BUILDING = Msg_Data.Element("BUILDING").Value,
                                           .LOCATION = Msg_Data.Element("LOCATION").Value,
                                           .ERROR_CODE = Msg_Data.Element("ERROR_CODE").Value,
                                           .ERROR_MSG = Msg_Data.Element("ERROR_MSG").Value
                                        }

            For Each Msg_Data In HeaderItems
                struct.strTRAILER_NUMBER = Msg_Data.TRAILER_NUMBER
                struct.strTRUCK_LINE = Msg_Data.TRUCK_LINE
                struct.strSITE_NAME = Msg_Data.SITE_NAME
                struct.strBUILDING = Msg_Data.BUILDING
                struct.strLOCATION = Msg_Data.LOCATION
                struct.strERROR_CODE = Msg_Data.ERROR_CODE
                struct.strERROR_MSG = Msg_Data.ERROR_MSG
            Next
            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function
    Public Function ReadXML_TrailerShpRcpAsgnmtConfirm(ByVal document As XDocument) As TrailerShpRcpAsgnmtConfirm
        Dim struct As New TrailerShpRcpAsgnmtConfirm

        Try

            Dim HeaderItems As Object = From Msg_Data In document.Descendants(TRL_CKOUT_CONF_DATA_TAG)
                                        Select New With
                                        {
                                           .TRAILER_NUMBER = Msg_Data.Element("TRAILER_NUMBER").Value,
                                           .TRUCK_LINE = Msg_Data.Element("TRUCK_LINE").Value,
                                           .TRACTOR_ID = Msg_Data.Element("TRACTOR_ID").Value,
                                           .SHIPMENT_ID = Msg_Data.Element("SHIPMENT_ID").Value,
                                           .RR_NUMBER = Msg_Data.Element("RR_NUMBER").Value,
                                           .INVOICE_NUMBER = Msg_Data.Element("INVOICE_NUMBER").Value,
                                           .BOL_NUMBER = Msg_Data.Element("BOL_NUMBER").Value,
                                           .ERROR_CODE = Msg_Data.Element("ERROR_CODE").Value,
                                           .ERROR_MSG = Msg_Data.Element("ERROR_MSG").Value
                                        }

            For Each Msg_Data In HeaderItems
                struct.strTRAILER_NUMBER = Msg_Data.TRAILER_NUMBER
                struct.strTRUCK_LINE = Msg_Data.TRUCK_LINE
                struct.strTRACTOR_ID = Msg_Data.TRACTOR_ID
                struct.strSHIPMENT_ID = Msg_Data.SHIPMENT_ID
                struct.strRR_NUMBER = Msg_Data.RR_NUMBER
                struct.strINVOICE_NUMBER = Msg_Data.INVOICE_NUMBER
                struct.strBOL_NUMBER = Msg_Data.BOL_NUMBER
                struct.strERROR_CODE = Msg_Data.ERROR_CODE
                struct.strERROR_MSG = Msg_Data.ERROR_MSG
            Next
            Return struct
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return struct
        End Try
    End Function

End Module
