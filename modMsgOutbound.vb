Option Explicit On
Option Strict On

Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.XML
Imports System.IO
Module modMsgOutbound

    Public Function SendRequest(ByVal strText As String, Optional ByVal bAlwaysSend As Boolean = False) As Boolean

        Dim tcpClient As New System.Net.Sockets.TcpClient
        Dim dtSendTimeStamp As Date
        Dim charPad As Char = Convert.ToChar(gcStrZero)
        Dim strBars As String

        Try

            If gbEditXMLBeforeSend = True And bAlwaysSend = False Then
                'write the xml to file so that  on XML editor open the text will be displayed
                gstrLastXMLSent = strText
                Dim formXMLEditor As New frmXMLEditor(gbEditXMLBeforeSend)
                formXMLEditor.Show()
                If gbPreventDBUpdatesAfterMessage = True Then
                    SendRequest = False         'pretends that the message never reached WMS
                Else
                    SendRequest = True
                End If
                Exit Function
            End If

            gbNewOutboundData = True
            giMsgOutCount += 1
            gLastMsgOutTimeStamp = Now
            If Year(gFirstMsgOutTimeStamp) < 1986 Then
                gFirstMsgOutTimeStamp = gLastMsgOutTimeStamp
            End If
            WriteLog("Sending", "..." & vbCrLf & strText)

            '"Localhost" string is used when the client and the listener are on the same computer.
            'If the listener is listening at a computer that is different from the client, provide the host name of the computer
            'where the listener is listening.
            tcpClient.Connect(IPAddress.Parse(gstrSocketServerIP), CInt(gstrSocketServerPort))


            ' Uses the GetStream public method to return the NetworkStream.

            Dim netStream As NetworkStream = tcpClient.GetStream()
            If netStream.CanWrite Then
                Dim sendBytes As [Byte]() = Encoding.UTF8.GetBytes(strText & vbCr & vbLf & vbLf)
                netStream.Write(sendBytes, 0, sendBytes.Length)
                dtSendTimeStamp = Now
            Else
                WriteLog("NetStream_Write", "You cannot write data to this stream.")

                tcpClient.Close()
                ' Closing the tcpClient instance does not close the network stream.
                netStream.Close()
                Return False
            End If
            If netStream.CanRead Then

                ' Reads the NetworkStream into a byte buffer.
                Dim bytes(tcpClient.ReceiveBufferSize) As Byte
                ' Read can return anything from 0 to numBytesToRead. 
                ' This method blocks until at least one byte is read.
                netStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))

                ' Returns the data received from the host to the console.
                Dim returndata As String = Encoding.ASCII.GetString(bytes)

                If (Now - dtSendTimeStamp).Seconds > 0 Then
                    strBars = "".PadRight(10, "X"c)
                Else
                    strBars = "".PadRight(CInt((Now - dtSendTimeStamp).Milliseconds / 100), "X"c)
                    ' Dim i As Integer = CInt((Now - dtSendTimeStamp).Milliseconds / 100)

                End If

                WriteLog("Response", ProcessAckNakResponse(returndata) & "|" & (Now - dtSendTimeStamp).Seconds.ToString & "." & (Now - dtSendTimeStamp).Milliseconds.ToString.PadLeft(3, charPad))
                WriteLogAckResponse(strBars, (Now - dtSendTimeStamp).Seconds.ToString & "." & (Now - dtSendTimeStamp).Milliseconds.ToString.PadLeft(3, charPad))

            Else
                WriteLog("NetStream_Read", "You cannot read data on this stream.")
                tcpClient.Close()
                ' Closing the tcpClient instance does not close the network stream.
                netStream.Close()
                Return False
            End If

            ' Uses the Close public method to close the network stream and socket.
            tcpClient.Close()

            gstrLastXMLSent = strText

            If gbPreventDBUpdatesAfterMessage = True Then
                SendRequest = False         'pretends that the message never reached WMS
            Else
                SendRequest = True
            End If

        Catch
            SendRequest = False
            gbNewInboundData = True
            WriteLog(gcstrError, "No Response to Send - Is remote application started/reachable?")
        End Try
    End Function

   
    Public Function ProcessAckNakResponse(ByVal strResponse As String) As String
        If Strings.Left(strResponse, 1) = "A" Then
            ProcessAckNakResponse = "A"
        Else
            ProcessAckNakResponse = "N"
        End If
    End Function
    Public Function CreateXMLHeartbeat(ByVal strText As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTestXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        ' Start the Message Detail node.
        xml_text_writer.WriteStartElement("Check_HeartBeat")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        xml_text_writer.WriteStartElement("CheckHeartBeatData")

        ' Write the Heartbeat text
        xml_text_writer.WriteStartElement("TEXT".ToUpper)
        xml_text_writer.WriteString(strText)
        xml_text_writer.WriteEndElement()

        ' End the CheckHeartBeatData
        xml_text_writer.WriteEndElement()

        ' End the Check_HeartBeat
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTestXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXMLHeartbeat = strTestXMl
    End Function


    Public Function CreateXML_Msg5(ByVal strULID As String, ByVal strUL_STACOD As String, ByVal strBYPCOD As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("MSG5".ToUpper)

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("ULDATA".ToUpper)

        ' Write the lineitems
        xml_text_writer.WriteStartElement("UNIT_LOAD_ID")
        xml_text_writer.WriteString(strULID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("UL_STACOD")
        xml_text_writer.WriteString(strUL_STACOD)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ULWEIGHT")
        xml_text_writer.WriteString(gcStrZero)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("BYPCOD")
        xml_text_writer.WriteString(strBYPCOD)
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_Msg5 = strTextXMl
    End Function
    Public Sub CreateXMLMessageHeader(ByVal memory_stream As MemoryStream, ByVal xml_text_writer As XmlTextWriter)

        '<MessageHeader>
        '<WCS_ID>RTCIS</WCS_ID>    
        '<Message_Id>00000000000000000001</Message_Id>    
        ' <Timestamp>20091007 15:00:00</Timestamp>    
        '</MessageHeader> 


        'Root Tag
        xml_text_writer.WriteStartElement(gcstrMessageHeaderElement)

        ' Write the lineitems
        xml_text_writer.WriteStartElement("SESSION_KEY")
        xml_text_writer.WriteString(gstrXML_WCS_ID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("MESSAGE_ID")
        xml_text_writer.WriteString(Format(Now, "yyyyMMddHHmmssffff"))
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("TIMESTAMP")
        'xml_text_writer.WriteString(Format(Now, "s"))   XML format
        xml_text_writer.WriteString(Format(Now, "yyyyMMddHHmmss")) 'oracle format
        xml_text_writer.WriteEndElement()

        ' End root element
        xml_text_writer.WriteEndElement()


    End Sub

    Public Function CreateXML_AssignInductionLoc(ByVal strULID As String, ByVal strACTIV_INPUT_LOCATION As String, ByVal strPLC_USERID As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("AssignInductionLoc")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("LocForPallet")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString("A8")
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("UNIT_LOAD_ID")
        xml_text_writer.WriteString(strULID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_INPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_INPUT_LOCATION)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("PLC_USERID")
        xml_text_writer.WriteString(strPLC_USERID)
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_AssignInductionLoc = strTextXMl
    End Function

    Public Function CreateXML_Msg7(ByVal strULID As String, ByVal strUL_STACOD As String, ByVal strDELIVERY_LOCATION As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("MSG7".ToUpper)

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("ULDATA".ToUpper)

        ' Write the lineitems
        xml_text_writer.WriteStartElement("UNIT_LOAD_ID")
        xml_text_writer.WriteString(strULID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("UNIT_LOAD_STATUS")
        xml_text_writer.WriteString(strUL_STACOD)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("DELIVERY_LOCATION")
        xml_text_writer.WriteString(strDELIVERY_LOCATION)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("USER_ID")
        xml_text_writer.WriteString("PLCA")
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_Msg7 = strTextXMl
    End Function

    Public Function CreateXML_AssignWithdrawalLoc(ByVal strHOST_CONTROL_NUMBER As String, ByVal strWITHDRAWAL_OUTPUT_TIME As String, _
                                    ByVal strACTIV_OUTPUT_LOCATION As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("AssignWithdrawalLoc")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("LocForRequest")

        ' Write the lineitems

        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString("A13")
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHOST_CONTROL_NUMBER)
        xml_text_writer.WriteEndElement()


        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_OUTPUT_LOCATION)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("WITHDRAWAL_OUTPUT_TIME")
        xml_text_writer.WriteString(strWITHDRAWAL_OUTPUT_TIME)
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_AssignWithdrawalLoc = strTextXMl
    End Function

    Public Function CreateXML_WithdrawalULArrival(ByVal strMESSAGE_TYPE As String, ByVal strHOST_CONTROL_NUMBER As String, ByVal strACTIV_OUTPUT_LOCATION As String, _
                                    ByVal strUNIT_LOAD_ID As String, ByVal strPALLET_TYPE As String, ByVal strBRAND_CODE As String, _
                                    ByVal strCODE_DATE As String, ByVal strWITHDRAWAL_OUTPUT_STATUS As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("WithdrawalULArrival")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("PalletArrival")

        ' Write the lineitems

        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHOST_CONTROL_NUMBER)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_OUTPUT_LOCATION)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_LEVEL_ID")
        xml_text_writer.WriteString(String.Empty)
        xml_text_writer.WriteEndElement()

        'missing ACTIV_LEVEL_ID!

        xml_text_writer.WriteStartElement("UNIT_LOAD_ID")
        xml_text_writer.WriteString(strUNIT_LOAD_ID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("PALLET_TYPE")
        xml_text_writer.WriteString(strPALLET_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("BRAND_CODE")
        xml_text_writer.WriteString(strBRAND_CODE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("CODE_DATE")
        xml_text_writer.WriteString(strCODE_DATE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("WITHDRAWAL_OUTPUT_STATUS")
        xml_text_writer.WriteString(strWITHDRAWAL_OUTPUT_STATUS)
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_WithdrawalULArrival = strTextXMl
    End Function



    Public Function CreateXML_Msg11(ByVal strTech_Group As String, ByVal strRDT_Message As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("MSG11".ToUpper)

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("DATA".ToUpper)

        ' Write the lineitems
        xml_text_writer.WriteStartElement("TECH_GROUP")
        xml_text_writer.WriteString(strTech_Group)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("RDT_MESSAGE")
        xml_text_writer.WriteString(strRDT_Message)
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_Msg11 = strTextXMl
    End Function


    Public Function CreateXML_RequestNextShip(ByVal strMOT_CODE As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("RequestNextShip")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("ShipCriteria")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")       'should always be A21 for ng
        xml_text_writer.WriteString("A21")
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("MOT_CODE")       'should always be A21 for ng
        xml_text_writer.WriteString(strMOT_CODE)
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_RequestNextShip = strTextXMl
    End Function
    Public Function CreateXML_RequestNextProdOrder(ByVal strDelivery_Location As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("RequestNextProdOrder")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("OrderCriteria")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")       'should always be A41 for ng
        xml_text_writer.WriteString("A41")
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("DELIVERY_LOCATION")       'should always be A21 for ng
        xml_text_writer.WriteString(strDelivery_Location)
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_RequestNextProdOrder = strTextXMl
    End Function
    Public Function CreateXML_ProdOrderStartDeStage(ByVal strMESSAGE_TYPE As String, ByVal strHost_Control_Number As String, ByVal strSlot As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ShipDestageStart")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("StageLoc")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHost_Control_Number)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strSlot)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("DELIVERY_LOCATION")
        xml_text_writer.WriteString("NOT USED AT ALL BY RTCIS")
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ProdOrderStartDeStage = strTextXMl
    End Function

    Public Function CreateXML_ShipDestageStart(ByVal strMESSAGE_TYPE As String, ByVal strHost_Control_Number As String, ByVal strSlot As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ShipDestageStart")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("DestageLoc")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHost_Control_Number)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strSlot)
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ShipDestageStart = strTextXMl
    End Function
    Public Function CreateXML_ShipStageStart(ByVal strMESSAGE_TYPE As String, ByVal strHost_Control_Number As String, ByVal strSlot As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ShipStageStart")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("StageLoc")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHost_Control_Number)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strSlot)
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ShipStageStart = strTextXMl
    End Function
    Public Function CreateXML_ProdOrderStageStart(ByVal strMESSAGE_TYPE As String, ByVal strHost_Control_Number As String, ByVal strSlot As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ProdOrderStageStart")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("StageLoc")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHost_Control_Number)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strSlot)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("DELIVERY_LOCATION")
        xml_text_writer.WriteString("NOT USED AT ALL BY RTCIS")
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ProdOrderStageStart = strTextXMl
    End Function

    Public Function CreateXML_ProdULStaged(ByVal strMESSAGE_TYPE As String, ByVal strHOST_CONTROL_NUMBER As String, _
           ByVal strUNIT_LOAD_ID As String, ByVal strACTIV_OUTPUT_LOCATION As String, ByVal strACTIV_LEVEL_ID As String, _
           ByVal strPALLET_TYPE As String, ByVal strBRAND_CODE As String, ByVal strCODE_DATE As String, _
           ByVal strLINE_ITEM_SEQUENCE_NUMBER As String) As String

        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ProdOrderULStaged")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("StageUL")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHOST_CONTROL_NUMBER)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("UNIT_LOAD_ID")
        xml_text_writer.WriteString(strUNIT_LOAD_ID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_OUTPUT_LOCATION)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_LEVEL_ID")
        xml_text_writer.WriteString(strACTIV_LEVEL_ID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("PALLET_TYPE")
        xml_text_writer.WriteString(strPALLET_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("BRAND_CODE")
        xml_text_writer.WriteString(strBRAND_CODE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("CODE_DATE")
        xml_text_writer.WriteString(strCODE_DATE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("LINE_ITEM_SEQUENCE_NUMBER")
        xml_text_writer.WriteString(strLINE_ITEM_SEQUENCE_NUMBER)
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ProdULStaged = strTextXMl
    End Function

    Public Function CreateXML_ShipULStaged(ByVal strMESSAGE_TYPE As String, ByVal strHOST_CONTROL_NUMBER As String, _
            ByVal strUNIT_LOAD_ID As String, ByVal strACTIV_OUTPUT_LOCATION As String, ByVal strACTIV_LEVEL_ID As String, _
            ByVal strPALLET_TYPE As String, ByVal strBRAND_CODE As String, ByVal strCODE_DATE As String, _
            ByVal strLINE_ITEM_SEQUENCE_NUMBER As String) As String

        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ShipULStaged")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("StageUL")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHOST_CONTROL_NUMBER)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("UNIT_LOAD_ID")
        xml_text_writer.WriteString(strUNIT_LOAD_ID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_OUTPUT_LOCATION)
        xml_text_writer.WriteEndElement()


        xml_text_writer.WriteStartElement("ACTIV_LEVEL_ID")
        xml_text_writer.WriteString(strACTIV_LEVEL_ID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("PALLET_TYPE")
        xml_text_writer.WriteString(strPALLET_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("BRAND_CODE")
        xml_text_writer.WriteString(strBRAND_CODE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("CODE_DATE")
        xml_text_writer.WriteString(strCODE_DATE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("LINE_ITEM_SEQUENCE_NUMBER")
        xml_text_writer.WriteString(strLINE_ITEM_SEQUENCE_NUMBER)
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ShipULStaged = strTextXMl
    End Function
    Public Function CreateXML_ShipULDestaged(ByVal strMESSAGE_TYPE As String, ByVal strHOST_CONTROL_NUMBER As String, _
               ByVal strUNIT_LOAD_ID As String, ByVal strACTIV_OUTPUT_LOCATION As String, ByVal strACTIV_LEVEL_ID As String, _
               ByVal strPALLET_TYPE As String, ByVal strBRAND_CODE As String, ByVal strCODE_DATE As String) As String

        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ShipULDestaged")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("DestageUL")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHOST_CONTROL_NUMBER)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("UNIT_LOAD_ID")
        xml_text_writer.WriteString(strUNIT_LOAD_ID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_OUTPUT_LOCATION)
        xml_text_writer.WriteEndElement()


        xml_text_writer.WriteStartElement("ACTIV_LEVEL_ID")
        xml_text_writer.WriteString(strACTIV_LEVEL_ID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("PALLET_TYPE")
        xml_text_writer.WriteString(strPALLET_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("BRAND_CODE")
        xml_text_writer.WriteString(strBRAND_CODE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("CODE_DATE")
        xml_text_writer.WriteString(strCODE_DATE)
        xml_text_writer.WriteEndElement()



        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ShipULDestaged = strTextXMl
    End Function
    Public Function CreateXML_ProdOrderDestageComplete(ByVal strMESSAGE_TYPE As String, ByVal strACTIV_OUTPUT_LOCATION As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ProdOrderDestageComplete")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("ProdOrderDestaged")

        ' Write the lineitems

        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_OUTPUT_LOCATION)
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ProdOrderDestageComplete = strTextXMl
    End Function


    Public Function CreateXML_ShipDestageComplete(ByVal strMESSAGE_TYPE As String, ByVal strACTIV_OUTPUT_LOCATION As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ShipDestageComplete")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("ShipDestaged")

        ' Write the lineitems

        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_OUTPUT_LOCATION)
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ShipDestageComplete = strTextXMl
    End Function
    Public Function CreateXML_ProdOrderStageComplete(ByVal strMESSAGE_TYPE As String, ByVal strHOST_CONTROL_NUMBER As String, ByVal strACTIV_OUTPUT_LOCATION As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ProdOrderStageComplete")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("ProdOrderStaged")

        ' Write the lineitems

        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHOST_CONTROL_NUMBER)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_OUTPUT_LOCATION)
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ProdOrderStageComplete = strTextXMl
    End Function

    Public Function CreateXML_ShipStageComplete(ByVal strMESSAGE_TYPE As String, ByVal strHOST_CONTROL_NUMBER As String, ByVal strACTIV_OUTPUT_LOCATION As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ShipStageComplete")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("ShipStaged")

        ' Write the lineitems

        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHOST_CONTROL_NUMBER)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_OUTPUT_LOCATION)
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ShipStageComplete = strTextXMl
    End Function

    Public Function CreateXML_ShipULPickup(ByVal strMESSAGE_TYPE As String, ByVal strHOST_CONTROL_NUMBER As String, ByVal strLOAD_FLAG As String, _
           ByVal strACTIV_OUTPUT_LOCATION As String, ByVal strACTIV_LEVEL_ID As String, ByVal strUNIT_LOAD_ID As String, _
           ByVal strPALLET_TYPE As String, ByVal strBRAND_CODE As String, ByVal strCODE_DATE As String, _
           ByVal strWITHDRAWAL_OUTPUT_STATUS As String) As String

        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("ShipULPickup")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("PickupUL")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHOST_CONTROL_NUMBER)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("LOAD_FLAG")
        xml_text_writer.WriteString(strLOAD_FLAG)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strACTIV_OUTPUT_LOCATION)
        xml_text_writer.WriteEndElement()


        xml_text_writer.WriteStartElement("ACTIV_LEVEL_ID")
        xml_text_writer.WriteString(strACTIV_LEVEL_ID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("UNIT_LOAD_ID")
        xml_text_writer.WriteString(strUNIT_LOAD_ID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("PALLET_TYPE")
        xml_text_writer.WriteString(strPALLET_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("BRAND_CODE")
        xml_text_writer.WriteString(strBRAND_CODE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("CODE_DATE")
        xml_text_writer.WriteString(strCODE_DATE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("WITHDRAWAL_OUTPUT_STATUS")
        xml_text_writer.WriteString(strWITHDRAWAL_OUTPUT_STATUS)
        xml_text_writer.WriteEndElement()


        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ShipULPickup = strTextXMl
    End Function

    Public Function CreateXML_AssignFPDSLoc(ByVal strMESSAGE_TYPE As String, ByVal strTRAILER_NUMBER As String,
         ByVal strTRUCK_LINE As String, ByVal strACTIV_INPUT_LOCATION As String) As String

        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("AssignFPDSLoc")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("LocForTrailer")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString(strMESSAGE_TYPE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("TRAILER_NUMBER")
        xml_text_writer.WriteString(strTRAILER_NUMBER)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("TRUCK_LINE")
        xml_text_writer.WriteString(strTRUCK_LINE)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_INPUT_CONVEYOR")
        xml_text_writer.WriteString(strACTIV_INPUT_LOCATION)
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_AssignFPDSLoc = strTextXMl
    End Function
    Public Function CreateXML_SlotSignOnConfirmation(ByVal strHost_Control_Number As String, ByVal strSlot As String, ByVal strstatus As String) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.None
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("SlotSignOnConfirmation")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("SlotRequest")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("MESSAGE_TYPE")
        xml_text_writer.WriteString("A32")
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("HOST_CONTROL_NUMBER")
        xml_text_writer.WriteString(strHost_Control_Number)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("ACTIV_OUTPUT_LOCATION")
        xml_text_writer.WriteString(strSlot)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("STATUS")
        xml_text_writer.WriteString(strStatus)
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()


        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_SlotSignOnConfirmation = strTextXMl
    End Function

    Public Function CreateXML_TrailerCheckout(ByVal strTrailerID As String,
                                              ByVal strTruckLine As String,
                                              ByVal strTractorId As String,
                                              ByVal strDrvName As String,
                                              ByVal strLicPltNum As String,
                                              ByVal strLicPltSta As String,
                                              ByVal strCarArrDt As String
                                              ) As String

        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)
        Dim strTextXMl As String

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement("TrailerCheckout")

        'Message Header
        CreateXMLMessageHeader(memory_stream, xml_text_writer)


        'Segment tag
        xml_text_writer.WriteStartElement("TrailerData")

        ' Write the lineitems
        xml_text_writer.WriteStartElement("TRAILER_ID")
        xml_text_writer.WriteString(strTrailerID)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("TRUCK_LINE")
        xml_text_writer.WriteString(strTruckLine)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("TRACTOR_ID")
        xml_text_writer.WriteString(strTractorId)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("DRIVER_NAME")
        xml_text_writer.WriteString(strDrvName)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("LICENSE_PLATE_NUM")
        xml_text_writer.WriteString(strLicPltNum)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("LICENSE_PLATE_STATE")
        xml_text_writer.WriteString(strLicPltSta)
        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteStartElement("CARRIER_ARRIVAL_DT")
        xml_text_writer.WriteString(strCarArrDt)
        xml_text_writer.WriteEndElement()

        ' End outer element
        xml_text_writer.WriteEndElement()

        'End outer element
        xml_text_writer.WriteEndElement()

        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_TrailerCheckout = strTextXMl
    End Function

End Module



