Option Explicit On
Option Strict On

'Imports System.Net.Sockets
'Imports System.Net
Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Linq
Imports System.Reflection.MethodBase
Imports System.Xml.Linq
Imports System.Data

Module modUtil

    Public HIGHLIGHT_FIELD_COLOR As Color = Color.Red
    Public HIGHLIGHT_FIELD_RESET_COLOR As Color = Color.White

    '>>>>>>TRAILER CHECKIN and CONFIRM<<<<<<<

    'Trailer Checkin tags/columns/fields
    Public TRL_CKIN_TAG As String = "TrailerCheckin"
    Public TRL_CKIN_DATA_TAG As String = "TrailerData"
    Public TRL_CKIN_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "TRAILER_TYPE", "LENGTH", "WIDTH", "HEIGHT",
                                        "EMPTY_WEIGHT", "FULL_WEIGHT", "TEMP_CODE",
                                        "DRIVER_NAME", "TRACTOR_ID", "LICENSE_NUM", "LICENSE_STATE",
                                        "USABLE", "UNUSABLE_REASON", "EMPTY", "ORIGIN", "CONTENTS", "FREIGHT_AMOUNT",
                                        "FREIGHT_CURRENCY", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER", "BOL_NUMBER", "SITE_NAME",
                                        "BUILDING", "BUILDING_LIST", "LOCATION", "TCS_TRANSIT_NUM", "TCS_TRAILER_TAG", "CKIN_DATE"}
    'Trailer Checkin Button tag array.
    Public TRAILER_CKIN_BUTTON_TAG_ARRAY As Object() = {TRL_CKIN_TAG, TRL_CKIN_DATA_TAG, TRL_CKIN_DATA_ELEMENTS, Main.gbTrailerMovMain}
    'Inbound Messages Tags
    Public TRL_CKIN_CONF_TAG As String = "TrailerCheckinConfirm"
    Public TRL_CKIN_CONF_DATA_TAG As String = "TrailerData"
    'Trailer Checkin Confirm Fields
    Public TRL_CKIN_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "TRACTOR_ID",
                                                        "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER",
                                                        "SITE_NAME", "BUILDING", "TCS_TRAILER_TAG", "LOCATION",
                                                        "ERROR_CODE", "ERROR_MSG"}
    'Trailer Checkin Inbound
    Public TRL_CKIN_INB_TAG As String = TRL_CKIN_TAG
    Public TRL_CKIN_INB_DATA_TAG As String = TRL_CKIN_DATA_TAG
    'Trailer Move Request Inbound Fields
    Public TRL_CKIN_INB_DATA_ELEMENTS As String() = TRL_CKIN_DATA_ELEMENTS
    Public TRL_CKIN_INB_CONF_MSG_ARRAY As Object() = {TRL_CKIN_CONF_TAG, TRL_CKIN_CONF_DATA_TAG, TRL_CKIN_CONF_DATA_ELEMENTS}


    '>>>>>>TRAILER LOCATION REQUEST/ASSIGNMENT <<<<<<
    'Trailer location assigmnment tags/columns/fields
    Public TRL_LOC_REQUEST_TAG As String = "TrailerLocRequest"
    Public TRL_LOC_REQUEST_DATA_TAG As String = "TrailerData"
    Public TRL_LOC_REQUEST_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "SITE_NAME", "BUILDING", "BUILDING_LIST", "QUEUE_FLAG", "PRIORITY"}
    'trailer location assignment button tag array on trailer checkin and checkout Tab
    Public TRAILER_LOCATION_REQUEST_BUTTON_TAG_ARRAY As Object() = {TRL_LOC_REQUEST_TAG, TRL_LOC_REQUEST_DATA_TAG, TRL_LOC_REQUEST_DATA_ELEMENTS, Main.gbTrailerMovMain}
    'trailer location assignment button tag array on trailer movement Tab
    Public TRAILER_LOCATION_REQUEST_ON_MOVEMNT_BUTTON_TAG_ARRAY As Object() = {TRL_LOC_REQUEST_TAG, TRL_LOC_REQUEST_DATA_TAG, TRL_LOC_REQUEST_DATA_ELEMENTS, Main.gbxTrailerMovement}
    'Inbound Messages Tags

    Public TRL_LOC_ASSG_CONF_TAG As String = "TrailerLocAssign"
    Public TRL_LOC_ASSG_CONF_DATA_TAG As String = "LocationData"
    'Trailer Location Assignment Confirm Fields
    Public TRL_LOC_ASSG_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "SITE_NAME", "BUILDING", "LOCATION",
                                                            "DEST_SITE_NAME", "DEST_BUILDING", "DEST_LOCATION", "QUEUE_FLAG",
                                                            "ERROR_CODE", "ERROR_MSG"}
    Public TRL_LOC_ASSG_CONF_MSG_ARRAY As Object() = {TRL_LOC_ASSG_CONF_TAG, TRL_LOC_ASSG_CONF_DATA_TAG, TRL_LOC_ASSG_CONF_DATA_ELEMENTS}
    '>>>>>>>TRAILER SHIPMENT/RECEIPT REQUEST <<<<<<<<
    'Trailer Shipment/Receipt Assignment 
    Public TRL_SHPRCP_REQUEST_TAG As String = "TrailerShipRecRequest"
    Public TRL_SHPRCP_REQUEST_DATA_TAG As String = "ShipRecData"
    Public TRL_SHPRCP_REQUEST_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "TRACTOR_ID", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER", "BOL_NUMBER"}
    Public TRAILER_SHP_RCP_ASGNMT_BTN_TAG_ARRAY As Object() = {TRL_SHPRCP_REQUEST_TAG, TRL_SHPRCP_REQUEST_DATA_TAG, TRL_SHPRCP_REQUEST_DATA_ELEMENTS, Main.gbTrailerMovMain}
    'Inbound Messages Tags
    Public TRL_SHPRCP_ASG_CONF_TAG As String = "TrailerShipRecAssign"
    Public TRL_SHPRCP_ASG_CONF_DATA_TAG As String = "ShipRecData"
    'Trailer Shipment Assignment Confirm Fields
    Public TRL_SHPRCP_ASG_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "TRACTOR_ID", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER", "BOL_NUMBER", "ERROR_CODE", "ERROR_MSG"}
    Public TRL_SHPRCP_ASG_CONF_TAG_ARRAY As Object() = {TRL_SHPRCP_ASG_CONF_TAG, TRL_SHPRCP_ASG_CONF_DATA_TAG, TRL_SHPRCP_ASG_CONF_DATA_ELEMENTS}

    '>>>>>>Trailer Checkout <<<<<<<
    Public TRL_CKOUT_TAG As String = "TrailerCheckout"
    Public TRL_CKOUT_DATA_TAG As String = "TrailerData"
    Public TRL_CKOUT_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "DRIVER_NAME", "LICENSE_NUM",
                                                         "LICENSE_STATE", "TRACTOR_ID", "CARRIER_ARRIVAL_DT", "SHIPMENT_ID", "PO_NUMBER",
                                                         "CKOUT_DATE"}
    Public TRAILER_CKOUT_BUTTON_TAG_ARRAY As Object() = {TRL_CKOUT_TAG, TRL_CKOUT_DATA_TAG, TRL_CKOUT_DATA_ELEMENTS, Main.gbTrailerMovMain}
    'Inbound Messages Tags
    Public TRL_CKOUT_CONF_TAG As String = "TrailerCheckoutConfirm"
    Public TRL_CKOUT_CONF_DATA_TAG As String = "TrailerData"
    'Trailer Checkout Confirm Fields
    Public TRL_CKOUT_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "TRACTOR_ID", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER", "BOL_NUMBER", "ERROR_CODE", "ERROR_MSG"}
    Public TRL_CKOUT_CONF_TAG_ARRAY As Object() = {TRL_CKOUT_CONF_TAG, TRL_CKOUT_CONF_DATA_TAG, TRL_CKOUT_CONF_DATA_ELEMENTS}

    ' >>>>>>Trailer Location Update<<<<<<
    Public TRL_LOC_UPDATE_TAG As String = "TrailerLocUpdate"
    Public TRL_LOC_UPDATE_DATA_TAG As String = "LocationData"
    Public TRL_LOC_UPDATE_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "SITE_NAME", "LOCATION", "TCS_TRAILER_TAG"}
    Public TRAILER_LOC_UPDATE_BUTTON_TAG_ARRAY As Object() = {TRL_LOC_UPDATE_TAG, TRL_LOC_UPDATE_DATA_TAG, TRL_LOC_UPDATE_ELEMENTS, Main.gbxTrailerMovement}

    'Inbound Messages Tags
    Public TRL_LOC_UPDATE_CONF_TAG As String = "TrailerLocUpdateConfirm"
    Public TRL_LOC_UPDATE_CONF_DATA_TAG As String = "LocationData"
    'Trailer Move Request Cancel Confirm Fields
    Public TRL_LOC_UPDATE_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "SITE_NAME", "LOCATION", "ERROR_CODE", "ERROR_MSG"}
    Public TRL_LOC_UPDATE_CONF_TAG_ARRAY As Object() = {TRL_LOC_UPDATE_CONF_TAG, TRL_LOC_UPDATE_CONF_DATA_TAG, TRL_LOC_UPDATE_CONF_DATA_ELEMENTS}




    '>>>>>>>Trailer move request pickup<<<<<<
    Public TRL_MOVE_PICKUP_TAG As String = "TrailerMoveRequestPickup"
    Public TRL_MOVE_PICKUP_DATA_TAG As String = "PickupData"
    Public TRL_MOVE_PICKUP_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "REQUEST_ID", "SOURCE_SITE_NAME", "SOURCE_LOCATION", "DEVICE_ID", "USER_ID"}
    Public TRAILER_MOVE_PICKUP_BUTTON_TAG_ARRAY As Object() = {TRL_MOVE_PICKUP_TAG, TRL_MOVE_PICKUP_DATA_TAG, TRL_MOVE_PICKUP_ELEMENTS, Main.gbxTrailerMoveExec}

    '>>>>>Trailer move request deposit<<<<<<
    Public TRL_MOVE_COMPL_TAG As String = "TrailerMoveRequestDeposit"
    Public TRL_MOVE_COMPL_DATA_TAG As String = "DepositData"
    Public TRL_MOVE_COMPL_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "REQUEST_ID", "DEST_SITE_NAME", "DEST_LOCATION", "DEVICE_ID", "USER_ID"}
    Public TRAILER_MOVE_COMPL_BUTTON_TAG_ARRAY As Object() = {TRL_MOVE_COMPL_TAG, TRL_MOVE_COMPL_DATA_TAG, TRL_MOVE_COMPL_ELEMENTS, Main.gbxTrailerMoveExec}

    'Inbound Messages Tags
    Public TRL_MOVE_DEPOSIT_CONF_TAG As String = "TrailerMoveRequestDepositConfirm"
    Public TRL_MOVE_DEPOSIT_CONF_DATA_TAG As String = "DepositData"
    'Trailer Move Request Cancel Confirm Fields
    Public TRL_MOVE_DEPOSIT_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "REQUEST_ID", "DEST_SITE_NAME", "DEST_LOCATION", "ERROR_CODE", "ERROR_MSG"}


    '>>>>>Trailer Move Cancel<<<<<
    Public TRL_MOVE_CANCEL_TAG As String = "TrailerMoveRequestCancel"
    Public TRL_MOVE_CANCEL_DATA_TAG As String = "CancelData"
    Public TRL_MOVE_CANCEL_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "REQUEST_ID", "USABLE", "UNUSABLE_REASON", "SITE_NAME", "LOCATION"}
    'For button on trailer movement tab
    Public TRAILER_MOVE_CANCEL_BUTTON_TAG_ARRAY As Object() = {TRL_MOVE_CANCEL_TAG, TRL_MOVE_CANCEL_DATA_TAG, TRL_MOVE_CANCEL_ELEMENTS, Main.gbxTrailerMovement}
    'For button on Trailer move execution tab
    Public TRAILER_MOVE_CANCEL_EXEC_BUTTON_TAG_ARRAY As Object() = {TRL_MOVE_CANCEL_TAG, TRL_MOVE_CANCEL_DATA_TAG, TRL_MOVE_CANCEL_ELEMENTS, Main.gbxTrailerMoveExec}
    'Inbound Messages Tags
    Public TRL_MOVREQ_CANCEL_CONF_TAG As String = "TrailerMoveRequestCancelConfirm"
    Public TRL_MOVREQ_CANCEL_CONF_DATA_TAG As String = "CancelData"
    'Trailer Move Request Cancel Confirm Fields
    Public TRL_MOVREQ_CANCEL_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "REQUEST_ID", "ERROR_CODE", "ERROR_MSG"}
    Public TRL_MOVREQ_CANCEL_CONF_TAG_ARRAY As Object() = {TRL_MOVREQ_CANCEL_CONF_TAG, TRL_MOVREQ_CANCEL_CONF_DATA_TAG, TRL_MOVREQ_CANCEL_CONF_DATA_ELEMENTS}
    '>>>>>>>Trailer Change Priority <<<<<<<
    Public TRL_MOVE_CHANGE_PRIORITY_TAG As String = "TrailerMoveRequestChange"
    Public TRL_MOVE_CHANGE_PRIORITY_DATA_TAG As String = "ChangeData"
    Public TRL_MOVE_CHANGE_PRIORITY_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "PRIORITY", "REQUEST_ID"}
    'For button on trailer movement tab
    Public TRAILER_MOVE_CHANGE_PRIORITY_BUTTON_TAG_ARRAY As Object() = {TRL_MOVE_CHANGE_PRIORITY_TAG, TRL_MOVE_CHANGE_PRIORITY_DATA_TAG, TRL_MOVE_CHANGE_PRIORITY_ELEMENTS, Main.gbxTrailerMovement}
    'For button on Trailer move execution tab
    Public TRAILER_MOVE_EXEC_CHANGE_PRIORITY_BUTTON_TAG_ARRAY As Object() = {TRL_MOVE_CHANGE_PRIORITY_TAG, TRL_MOVE_CHANGE_PRIORITY_DATA_TAG, TRL_MOVE_CHANGE_PRIORITY_ELEMENTS, Main.gbxTrailerMoveExec}

    '>>>>>Trailer Move Request (INBOUND )- FROM WMS <<<<<
    Public TRL_MOVE_REQUEST_TAG As String = "TrailerMoveRequestCancel"
    Public TRL_MOVE_REQUEST_DATA_TAG As String = "CancelData"
    Public TRL_MOVE_REQUEST_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "REQUEST_ID", "USABLE", "UNUSABLE_REASON", "SITE_NAME", "LOCATION"}
    'For button on trailer movement tab
    Public TRAILER_MOVE_REQUEST_BUTTON_TAG_ARRAY As Object() = {TRL_MOVE_REQUEST_TAG, TRL_MOVE_REQUEST_DATA_TAG, TRL_MOVE_CANCEL_ELEMENTS, Main.gbxTrailerMovement}

    'Inbound Messages Tags
    Public TRL_MOVE_REQUEST_INB_TAG As String = "TrailerMoveRequest"
    Public TRL_MOVE_REQUEST_INB_DATA_TAG As String = "MoveRequestData"
    'Trailer Move Request Inbound Fields
    Public TRL_MOVE_REQUEST_INB_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "SOURCE_SITE_NAME", "SOURCE_LOCATION", "DEST_SITE_NAME", "DEST_LOCATION", "PRIORITY", "REQUEST_ID", "ERROR_CODE", "ERROR_MSG"}

    Public TRL_MOVE_REQUEST_INB_CONFIRM_TAG As String = "TrailerMoveRequestConfirm"
    Public TRL_MOVE_REQUEST_INB_CONFIRM_DATA_TAG As String = "MoveRequestData"
    Public TRL_MOVE_REQUEST_INB_CONFIRM_MSG_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "REQUEST_ID", "ERROR_CODE", "ERROR_MSG"}
    Public TRL_MOVE_REQUEST_INB_CONFIRM_MSG_TAG As Object() = {TRL_MOVE_REQUEST_INB_CONFIRM_TAG, TRL_MOVE_REQUEST_INB_CONFIRM_DATA_TAG, TRL_MOVE_REQUEST_INB_CONFIRM_MSG_ELEMENTS}



    Public DEFAULT_ELEMENTS As String() = {"DEFELEMENT1", "DEFELEMENT2"}
    Public DEFAULT_TAG_ARRAY As Object() = {"DEFAULTROOT", "DEFAULTDATA", CType(DEFAULT_ELEMENTS, String())}







    Private Function getControlTextValue(ctrl As Control) As String

        getControlTextValue = ""
        If (IsNothing(ctrl)) Then
            Return getControlTextValue
        End If

        Try
            If (TypeOf ctrl Is TextBox Or TypeOf ctrl Is ComboBox) Then
                If (ctrl.Text.Length > 0) Then
                    getControlTextValue = ctrl.Text
                End If
            ElseIf (TypeOf ctrl Is RadioButton) Then
                Dim rb As RadioButton = CType(ctrl, RadioButton)
                If (rb.Checked) Then
                    getControlTextValue = rb.Text
                End If
            ElseIf (TypeOf ctrl Is CheckBox) Then
                Dim cb As CheckBox = CType(ctrl, CheckBox)

                If cb.Checked Then
                    getControlTextValue = "Y"
                Else
                    getControlTextValue = "N"
                End If
            ElseIf (TypeOf ctrl Is DateTimePicker) Then
                Dim dt As DateTimePicker = CType(ctrl, DateTimePicker)

                getControlTextValue = Format(dt.Value, "yyyyMMddHHmmss")

            End If
        Catch ex As Exception
            WriteLog(GetCurrentMethod.Name(), "ERROR: Adding tag for [" + CType(ctrl.Tag, String) + "] " + ex.Message)
        End Try

        Return getControlTextValue

    End Function


    Private Sub AddToXML(ByVal memory_stream As MemoryStream, ByVal xmlWriter As XmlTextWriter, tag As String, val As String)
        xmlWriter.WriteStartElement(tag)
        xmlWriter.WriteString(val)
        xmlWriter.WriteEndElement()
    End Sub

    Private Sub AddToXML(ByVal memory_stream As MemoryStream, ByVal xmlWriter As XmlTextWriter, ByVal ctrl As Control, ByVal dic As Dictionary(Of String, String))
        'As XmlTextWriter
        Try
            If (TypeOf ctrl Is TextBox Or TypeOf ctrl Is ComboBox) Then
                'If (ctrl.Text.Length > 0) Then  'send the empty tag if no text.
                xmlWriter.WriteStartElement(CType(ctrl.Tag, String))
                xmlWriter.WriteString(ctrl.Text)
                xmlWriter.WriteEndElement()
                dic.Add(CType(ctrl.Tag, String), ctrl.Text)
                'End If
            ElseIf (TypeOf ctrl Is RadioButton) Then
                If (CType(ctrl, RadioButton).Checked) Then
                    xmlWriter.WriteStartElement(CType(ctrl.Tag, String))
                    xmlWriter.WriteString(ctrl.Text)
                    xmlWriter.WriteEndElement()
                    dic.Add(CType(ctrl.Tag, String), "Y")

                End If
            ElseIf (TypeOf ctrl Is CheckBox) Then
                Dim cb As CheckBox = CType(ctrl, CheckBox)
                xmlWriter.WriteStartElement(CType(ctrl.Tag, String))
                If cb.Checked Then
                    xmlWriter.WriteString("Y")
                    dic.Add(CType(ctrl.Tag, String), "Y")
                Else
                    xmlWriter.WriteString("N")
                    dic.Add(CType(ctrl.Tag, String), "N")
                End If

                xmlWriter.WriteEndElement()

            ElseIf (TypeOf ctrl Is DateTimePicker) Then
                Dim dt As DateTimePicker = CType(ctrl, DateTimePicker)
                xmlWriter.WriteStartElement(CType(dt.Tag, String))
                xmlWriter.WriteString(Format(dt.Value, "yyyyMMddHHmmss"))
                xmlWriter.WriteEndElement()

                dic.Add(CType(ctrl.Tag, String), Format(dt.Value, "yyyyMMddHHmmss"))
            End If
        Catch ex As Exception
            WriteLog("AddToXML", "ERROR: Adding tag for [" + CType(ctrl.Tag, String) + "] " + ex.Message)
        End Try
        'AddToXML = xmlWriter
    End Sub

    Public Function CreateXML_ForAction(ByVal sender As Object) As String
        ','rootElement As String,
        'containerGroupControl As Control,
        'xmlTagList As String())

        Dim ctrl As Control
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)

        Dim senderCtrl As Control = CType(sender, Button)
        'Dim container As Control = senderCtrl.Parent

        ''***
        Dim btnTagAttrArray As Object() = CType(senderCtrl.Tag, Object())

        Dim rootTag As String = CType(btnTagAttrArray(0), String)
        Dim dataTag As String = CType(btnTagAttrArray(1), String)
        Dim tagLst As String() = CType(btnTagAttrArray(2), String())
        Dim container As GroupBox = CType(btnTagAttrArray(3), GroupBox)

        Dim oubdataDic As New Dictionary(Of String, String)



        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        ''**xml_text_writer.WriteStartElement(rootElement)
        xml_text_writer.WriteStartElement(rootTag)

        'write the header segment 
        CreateXMLMessageHeader(memory_stream, xml_text_writer)

        'Start the data segment 
        xml_text_writer.WriteStartElement(dataTag)

        Dim allSubControls As List(Of Control) = getAllCtrlList(container)

        ''**For Each tag As String In xmlTagList
        For Each tag As String In tagLst
            ctrl = allSubControls.Find(Function(s) CType(s.Tag, String) = tag)
            If (IsNothing(ctrl) = False) Then
                AddToXML(memory_stream, xml_text_writer, ctrl, oubdataDic)
            End If
        Next

        xml_text_writer.WriteEndElement()  ' end datatag

        xml_text_writer.WriteEndElement()  'end roottag

        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        Dim strTextXMl As String = Nothing

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        xml_text_writer.Close()

        'SASMFA Stop updating the TCS_TRAILER_EMU table.

        ''''If (checkTCS_TRAILER_EMU(getControlTextValue(allSubControls.Find(Function(s) CType(s.Tag, String) = "TRUCK_LINE")),
        ''''                getControlTextValue(allSubControls.Find(Function(s) CType(s.Tag, String) = "TRAILER_NUMBER")),
        ''''                getControlTextValue(allSubControls.Find(Function(s) CType(s.Tag, String) = "TRACTOR_ID"))) = False) Then
        ''''    'Add a row to TCS_TRAILER_EMU local table
        ''''    AddToTCS_TRAILER_EMU(CType(sender, Button), allSubControls)

        ''''Else
        ''''    'update existing record
        ''''    updateTCS_TRAILER_EMU(CType(sender, Button), allSubControls, tagLst)
        ''''End If

        'AddToTCS_TRAILER_EMU(CType(sender, Button), allSubControls)

        If (SendRequest(strTextXMl)) Then
            'A row should be added after the XML is sent. 

            AddToTCS_TRAILER_EMU(tagLst, oubdataDic, "O", rootTag, "Sent")
        End If



        CreateXML_ForAction = strTextXMl

    End Function

    'Public Function CreateXML_ForContainer(ByVal sender As Object) As String

    '    'Dim ctrl As Control
    '    Dim memory_stream As New MemoryStream
    '    Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)

    '    Dim senderCtrl As Control = CType(sender, Button)
    '    Dim container As Control = senderCtrl.Parent

    '    ' Use indentation to make the result look nice.
    '    xml_text_writer.Formatting = Formatting.Indented
    '    xml_text_writer.Indentation = 4

    '    ' Write the XML declaration.
    '    xml_text_writer.WriteStartDocument(True)

    '    'Root Tag
    '    xml_text_writer.WriteStartElement(CType(senderCtrl.Tag, String))

    '    CreateXMLMessageHeader(memory_stream, xml_text_writer)

    '    Dim containerTag As String = Nothing

    '    containerTag = CType(container.Tag, String)

    '    If IsNothing(containerTag) Then
    '        containerTag = "CONTAINER_MISSING_TAG"
    '    End If

    '    'Dim allTextBoxes As List(Of TextBox)
    '    Dim allSubControls As New List(Of Control)
    '    'Try
    '    '    'allTextBoxes = (From txt In container.Controls.OfType(Of TextBox)()
    '    '    '                Order By txt.TabIndex).ToList()
    '    '    allSubControls = (From ctrol In container.Controls.OfType(Of Control)()
    '    '                      Order By ctrol.TabIndex).ToList()
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'End Try

    '    xml_text_writer.WriteStartElement(CType(container.Tag, String))

    '    allSubControls.AddRange(getAllCtrls(container, memory_stream, xml_text_writer))

    '    'Dim txtbox As TextBox
    '    'For Each txtbox In allTextBoxes

    '    'THIS IS WORKING.
    '    '=========
    '    'For Each ctrl In (From ctrol In container.Controls.OfType(Of Control)()
    '    '                  Order By ctrol.TabIndex).ToList()
    '    '    AddToXML(memory_stream, xml_text_writer, ctrl)
    '    'Next
    '    '=============
    '    'For Each ctrl In container.Controls
    '    '    AddToXML(memory_stream, xml_text_writer, ctrl)
    '    'Next

    '    xml_text_writer.WriteEndElement()

    '    xml_text_writer.WriteEndElement()

    '    ' End the document.
    '    xml_text_writer.WriteEndDocument()
    '    xml_text_writer.Flush()

    '    Dim strTextXMl As String = Nothing

    '    ' Use a StreamReader to display the result.
    '    Dim stream_reader As New StreamReader(memory_stream)

    '    memory_stream.Seek(0, SeekOrigin.Begin)
    '    strTextXMl = stream_reader.ReadToEnd()

    '    ' Close the XmlTextWriter.
    '    xml_text_writer.Close()

    '    CreateXML_ForContainer = strTextXMl

    'End Function

    Private Function getAllControls(Of T)(ByVal parent As Control) As List(Of Control)
        Dim ctrlList As New List(Of Control)

        If parent.HasChildren = True Then
            For Each ctrl As Control In parent.Controls
                If TypeOf ctrl Is T Then
                    ctrlList.Add(ctrl)
                End If
                ctrlList.AddRange(getAllControls(Of T)(ctrl))
            Next
        ElseIf parent.HasChildren = False Then
            For Each ctrl As Control In parent.Controls
                If TypeOf ctrl Is T Then
                    ctrlList.Add(ctrl)
                End If
                ctrlList.AddRange(getAllControls(Of T)(ctrl))
            Next
        End If
        Return ctrlList

    End Function

    'Private Function getAllCtrls(ByVal parent As Control, ByVal memory_stream As MemoryStream, ByVal xml_text_writer As XmlTextWriter) As List(Of Control)
    '    Dim ctrlList As New List(Of Control)
    '    Dim ctrl As Control

    '    For Each ctrl In (From ctrol In parent.Controls.OfType(Of Control)()
    '                      Order By ctrol.TabIndex).ToList()
    '        If (ctrl.HasChildren) Then
    '            ctrlList.AddRange(getAllCtrls(ctrl, memory_stream, xml_text_writer))
    '        End If
    '        AddToXML(memory_stream, xml_text_writer, ctrl)
    '    Next

    '    Return ctrlList
    'End Function

    Public Function getAllCtrlList(ByVal parent As Control) As List(Of Control)
        Dim ctrlList As New List(Of Control)
        For Each ctrl As Control In (From ctrol In parent.Controls.OfType(Of Control)()
                                     Order By ctrol.TabIndex).ToList()
            If (ctrl.HasChildren) Then
                ctrlList.AddRange(getAllCtrlList(ctrl))
            Else
                'eleminate label controls from list
                If (TypeOf ctrl IsNot Label And TypeOf ctrl IsNot Button) Then
                    ctrlList.Add(ctrl)
                End If
            End If
        Next

        Return ctrlList

    End Function
    Public Sub loadFormDataFromGrid(row As DataGridViewRow, groupCtrl As Control)

        Dim ctrllst As List(Of Control) = getAllCtrlList(groupCtrl)
        Dim rb As RadioButton
        Dim cb As CheckBox
        Dim ctr As Control

        For Each cell As DataGridViewCell In row.Cells
            ctr = ctrllst.Find(Function(s) CType(s.Tag, String) = cell.OwningColumn.Name.ToString)

            'if no control was found, check if we can find a control.tag = column.tag
            If (IsNothing(ctr)) Then
                ctr = ctrllst.Find(Function(s) CType(s.Tag, String) = CType(cell.OwningColumn.Tag, String))
            End If

            If (TypeOf ctr Is TextBox Or TypeOf ctr Is ComboBox) Then
                ctr.Text = ""
                ctr.Text = cell.Value.ToString
            ElseIf (TypeOf ctr Is RadioButton) Then
                rb = CType(ctr, RadioButton)
                If (cell.Value.ToString = "Y") Then
                    rb.Checked = True
                Else
                    rb.Checked = False
                End If
            ElseIf (TypeOf ctr Is CheckBox) Then
                cb = CType(ctr, CheckBox)
                If (cell.Value.ToString = "Y") Then
                    cb.Checked = True
                Else
                    cb.Checked = False
                End If
            End If
        Next

    End Sub
    Public Sub highlightTaggedControls(senderCtrl As Object, setColor As Color)
        'controlTagsToHighlight As String(), grpControl As Control, 

        Dim ctr As Control
        Dim pnl As Panel
        Dim gb As GroupBox

        Dim btnTagAttrArray As Object() = CType(CType(senderCtrl, Button).Tag, Object())

        'Dim rootTag As String = CType(btnTagAttrArray(0), String)
        'Dim dataTag As String = CType(btnTagAttrArray(1), String)
        Dim ctrltagLst As String() = CType(btnTagAttrArray(2), String())
        Dim container As GroupBox = CType(btnTagAttrArray(3), GroupBox)

        Dim ctrllst As List(Of Control) = getAllCtrlList(container)

        'For each control in the with conrtol tagList 
        'find a control defined in the list and set the color

        For Each tag As String In ctrltagLst 'controlTagsToHighlight
            'find the control with matching tag
            ctr = ctrllst.Find(Function(s) CType(s.Tag, String) = tag)
            'found it
            If (IsNothing(ctr) = False) Then
                'if panel set panel background 
                If (TypeOf ctr.Parent Is Panel) Then
                    ctr.Parent.BackColor = CType(IIf(setColor = Color.White, Color.Transparent, setColor), Color)
                Else
                    If ((TypeOf ctr Is TextBox Or TypeOf ctr Is ComboBox Or TypeOf ctr Is CheckBox Or TypeOf ctr Is DateTimePicker) And
                        TypeOf ctr.Parent Is GroupBox) Then
                        'get the current parent groupbox.
                        gb = CType(ctr.Parent, GroupBox)

                        'initialize new panel
                        pnl = New Panel()
                        pnl.Name = "pnl" + ctr.Name
                        pnl.Size = New Size(ctr.Width + 2, ctr.Height + 2)
                        pnl.Location = New Point(ctr.Location.X, ctr.Location.Y)
                        pnl.Padding = New Padding(1)

                        'add panel to the current parent of control
                        gb.Controls.Add(pnl)
                        ''''ctr.BackColor = setColor
                        'Dock the contol in panel
                        ctr.Dock = DockStyle.Fill
                        'Set the contolr parent as panel 
                        ctr.Parent = pnl

                    End If
                End If
            End If

        Next
    End Sub
    Public Sub clearAllControls(sender As Button, grpCtrl As List(Of Control))
        Dim ctrl As Control

        For Each ctrl In grpCtrl
            Try
                If (TypeOf ctrl Is TextBox Or TypeOf ctrl Is ComboBox) Then
                    ctrl.Text = ""
                ElseIf (TypeOf ctrl Is RadioButton) Then
                    Dim rb As RadioButton = CType(ctrl, RadioButton)
                    rb.Checked = False
                ElseIf (TypeOf ctrl Is CheckBox) Then
                    Dim cb As CheckBox = CType(ctrl, CheckBox)
                    cb.Checked = False
                ElseIf (TypeOf ctrl Is DateTimePicker) Then
                    Dim dt As DateTimePicker = CType(ctrl, DateTimePicker)
                    dt.Value = Now
                End If
            Catch ex As Exception
                WriteLog(GetCurrentMethod.Name(), "ERROR: During Re-Set for [" + CType(ctrl.Tag, String) + "] " + ex.Message)
            End Try
        Next
    End Sub
    Public Function AddToTCS_TRAILER_EMU(sender As Button, grpCtrl As List(Of Control)) As Boolean
        Dim strSql As String
        Dim status As Boolean = False


        strSql = "INSERT INTO TCS_TRAILER_EMU " &
                     "(SESSION_KEY, TRUCK_LINE, TRAILER_NUMBER, TRACTOR_ID,TRAILER_TYPE, LENGTH,WIDTH,HEIGHT,
                       EMPTY_WEIGHT, FULL_WEIGHT, EST_WEIGHT, TEMP_CODE, DRIVER_NAME, 
                       LICENSE_NUM, LICENSE_STATE, USABLE, UNUSABLE_REASON, EMPTY, 
                       ORIGIN, CONTENTS, FREIGHT_AMOUNT, FREIGHT_CURRENCY, 
                       SHIPMENT_ID, RR_NUMBER, INVOICE_NUMBER, BOL_NUMBER, 
                       SITE_NAME, BUILDING, BUILDING_LIST, LOCATION, 
                       TCS_TRANSIT_NUM, TCS_TRAILER_TAG, CTRL_DATE, CKIN_DATE)
                       values ('" & gstrXML_WCS_ID & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "TRUCK_LINE")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "TRAILER_NUMBER")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "TRACTOR_ID")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "TRAILER_TYPE")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "LENGTH")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "WIDTH")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "HEIGHT")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "EMPTY_WEIGHT")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "FULL_WEIGHT")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "EST_WEIGHT")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "TEMP_CODE")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "DRIVER_NAME")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "LICENSE_NUM")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "LICENSE_STATE")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "USABLE")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "UNUSABLE_REASON")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "EMPTY")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "ORIGIN")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "CONTENTS")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "FREIGHT_AMOUNT")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "FREIGHT_CURRENCY")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "SHIPMENT_ID")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "RR_NUMBER")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "INVOICE_NUMBER")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "BOL_NUMBER")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "SITE_NAME")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "BUILDING")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "BUILDING_LIST")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "LOCATION")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "TCS_TRANSIT_NUM")) & "','" &
            getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "TCS_TRAILER_TAG")) & "','" &
            Format(Now, "yyyyMMddHHmmss") & "','" &
            Format(Now, "yyyyMMddHHmmss") & " ')"


        Try
            DBCON1.Execute(strSql)
            'dbrec1.Close()
            status = True
            WriteLog(gcstrError, GetCurrentMethod.Name() & "[DEBUG]" & "[" & strSql & "]")
        Catch ex As Exception
            status = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & "[" & Err.Description & "]" & "[" & ex.Message & "]" & "[" & strSql & "]")
            'dbrec1.Close()
        End Try

        Return status

    End Function

    Public Function AddToTCS_TRAILER_EMU(dbCols As String(), inbDataDict As Dictionary(Of String, String), msgTyp As String, msgNam As String, msgStat As String) As Boolean

        Dim status As Boolean = False
        Dim cols As New StringBuilder()
        Dim vals As New StringBuilder()

        Dim sqlStr As New StringBuilder("INSERT INTO TCS_TRAILER_EMU (")

        cols.Append("SESSION_KEY").Append(", ")
        vals.Append("'").Append(gstrXML_WCS_ID).Append("', ")
        cols.Append("MESSAGE_TYPE").Append(", ")
        vals.Append("'").Append(msgTyp).Append("', ")
        cols.Append("MESSAGE_NAME").Append(", ")
        vals.Append("'").Append(msgNam).Append("', ")
        cols.Append("MESSAGE_STATUS").Append(", ")
        vals.Append("'").Append(msgStat).Append("', ")


        'loop thru the list of db colums/tags that we want to add for this msgnam 
        '
        For Each elem As String In dbCols
                If (inbDataDict.ContainsKey(elem) = True) Then
                    cols.Append(elem).Append(", ")
                    vals.Append("'").Append(inbDataDict.Item(elem)).Append("', ")
                End If
            Next

            cols.Append("CTRL_DATE")
            vals.Append("'").Append(Format(Now, "yyyyMMddHHmmss")).Append("'")

            sqlStr.Append(cols).Append(") values (").Append(vals).Append(")")

            Try
                DBCON1.Execute(sqlStr.ToString)
                status = True
            'WriteLog("DEBUG", GetCurrentMethod.Name() & "[DEBUG]" & "[" & sqlStr.ToString & "]")
        Catch ex As Exception
                status = False
                WriteLog(gcstrError, GetCurrentMethod.Name() & "[" & Err.Description & "]" & "[" & ex.Message & "]" & "[" & sqlStr.ToString & "]")
            End Try

            Return status

    End Function

    Public Function updateTCS_TRAILER_EMU(sender As Button, grpCtrl As List(Of Control), taglst As String()) As Boolean
        Dim strSql As String
        Dim status As Boolean = False

        Dim updateSql As New StringBuilder("UPDATE TCS_TRAILER_EMU set ")

        For Each tag As String In taglst
            With updateSql
                If (tag = "CKIN_DATE") Then
                    .Append("CKIN_DATE= '" & Format(Now, "yyyyMMddHHmmss") & "',")
                ElseIf (tag = "CKOUT_DATE") Then
                    .Append("CKOUT_DATE= '" & Format(Now, "yyyyMMddHHmmss") & "',")
                ElseIf (tag = "TRACTOR_CKIN_DATE") Then
                    .Append("TRACTOR_CKIN_DATE= '" & Format(Now, "yyyyMMddHHmmss") & "',")
                Else
                    .Append(tag).Append(" = '").Append(getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = tag))).Append("',")
                End If
            End With
        Next
        With updateSql
            .Append(" CTRL_DATE= '" & Format(Now, "yyyyMMddHHmmss")).Append("' ")
            .Append(" WHERE ")
            .Append(" TRUCK_LINE= '" & getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "TRUCK_LINE"))).Append("' and")
            .Append(" TRAILER_NUMBER= '" & getControlTextValue(grpCtrl.Find(Function(s) CType(s.Tag, String) = "TRAILER_NUMBER"))).Append("'")
        End With

        strSql = updateSql.ToString()

        Try
            DBCON1.Execute(strSql)
            status = True
        Catch ex As Exception
            status = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & "[" & Err.Description & "]" & "[" & ex.Message & "]" & "[" & strSql & "]")
        End Try

        Return status
    End Function

    Public Function updateTCS_TRAILER_EMU(inbFldLst As String(), xmlObj As Dictionary(Of String, String), inbMsg As String) As Boolean
        Dim strSql As String = ""
        Dim status As Boolean = False
        Dim trailer As String = ""
        Dim trklin As String = ""
        Dim tractor As String = ""
        Dim useTractor As Boolean = False

        Try

            If (IsNothing(xmlObj)) Then
                WriteLog(gcstrError, GetCurrentMethod.Name() & "[" & "Null or Invalid inbound XML data" & "]")
            End If
            If (xmlObj.ContainsKey("TRAILER_NUMBER")) Then
                trailer = xmlObj.Item("TRAILER_NUMBER")
            End If
            If (xmlObj.ContainsKey("TRUCK_LINE")) Then
                trklin = xmlObj.Item("TRUCK_LINE")
            End If
            If (xmlObj.ContainsKey("TRACTOR_ID")) Then
                tractor = xmlObj.Item("TRACTOR_ID")
            End If

            If (IsNothing(tractor) = False) Then
                If (checkTCS_TRAILER_EMU(trklin, trailer, tractor) = True) Then
                    useTractor = True
                End If
            End If

            Dim updateSql As New StringBuilder("UPDATE TCS_TRAILER_EMU set ")

            For Each elem As String In inbFldLst
                If (xmlObj.ContainsKey(elem) = True) Then
                    'If (elem IsNot "TRUCK_LINE" And elem IsNot "TRAILER_NUMBER" And elem IsNot "ERROR_CODE" And elem IsNot "ERROR_MSG") Then
                    If (elem IsNot "ERROR_CODE" And elem IsNot "ERROR_MSG") Then
                        With updateSql
                            .Append(" " + elem + "= '" + xmlObj.Item(elem) + "',")
                        End With
                    End If
                End If
            Next

            If (inbMsg.ToUpper = TRL_CKIN_CONF_TAG.ToUpper) Then
                updateSql.Append(" CKIN_STAT = '" + xmlObj.Item("ERROR_CODE") + "',")
            ElseIf (inbMsg = TRL_CKOUT_CONF_TAG) Then
                updateSql.Append(" CKOUT_STAT = '" + xmlObj.Item("ERROR_CODE") + "',")
            End If

            With updateSql
                .Append(" CTRL_DATE= '" & Format(Now, "yyyyMMddHHmmss")).Append("' ")
                .Append(" WHERE ")
                .Append(" TRUCK_LINE= '" & trklin).Append("' and")
                .Append(" TRAILER_NUMBER= '" & trailer).Append("'")
            End With

            strSql = updateSql.ToString

            DBCON1.Execute(strSql)
            status = True
        Catch ex As Exception
            status = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & "[" & Err.Description & "]" & "[" & ex.Message & "]" & "[" & strSql & "]")
        End Try

        'Main.GetAndDisplayTrailerMoveData()
        Return status

    End Function

    Public Function checkTCS_TRAILER_EMU(trklin As String, trlnum As String, tractor As String) As Boolean
        Dim status As Boolean = False
        Dim sqlQry As String = ""

        If (Len(tractor) > 0) Then
            sqlQry = "SELECT 'x' AS test FROM dual
                       WHERE Exists (select 'y' from TCS_TRAILER_EMU 
                                      where TRUCK_LINE  = '" & trklin & "'" &
                                        "and TRAILER_NUMBER  = '" & trlnum & "'" &
                                        "and TRACTOR_ID  = '" & tractor & "' )"
        Else
            sqlQry = "SELECT 'x' AS test FROM dual
                       WHERE Exists (select 'y' from TCS_TRAILER_EMU 
                                      where TRUCK_LINE  = '" & trklin & "'" &
                            "and TRAILER_NUMBER  = '" & trlnum & "' )"
        End If

        Try
            dbrec1.Open(sqlQry, DBCON1)

            If (dbrec1.RecordCount > 0) Then
                status = True
            End If

            dbrec1.Close()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & "[" & ex.Message & "]" & "[" & sqlQry & "]")
            dbrec1.Close()
        End Try

        Return status
    End Function

    Public Function ProcessInboundMessage(inbMsgType As String,
                                          inbMsgElements As String(),
                                          xmlDoc As XDocument,
                                          inbMsgDataDic As Dictionary(Of String, String),
                                          autoSendConfirm As Boolean,
                                          confMsgObjArray As Object()
                                          ) As Boolean
        'confMsgObjArray As Object()  ====  {"OB_ConfMsgTag", "OB_MsgDataTag", OBMsgDataElements{} }      

        Dim retStat As Boolean = True

        'Insert the inbound data in the TCS_TRAILER_EMU table
        Try
            If (Not AddToTCS_TRAILER_EMU(inbMsgElements, inbMsgDataDic, "I", inbMsgType, "Processed")) Then
                'Write to the log 
                WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & "Error inserting record to TCS_TRAILER_EMU table")
                'Throw New Exception("Error inserting record to TCS_TRAILER_EMU table ")
            End If

        Catch ex As Exception

        End Try

        'Check if the confirmation message needs to be send
        If (Not CType(confMsgObjArray(0), String).Equals("DEFAULTROOT")) Then
            If (autoSendConfirm) Then
                If (SendRequest(CreateXml_SendOubMessageForInb(confMsgObjArray, inbMsgDataDic))) Then
                    'if send is successful then add a record to table
                    If (Not AddToTCS_TRAILER_EMU(CType(confMsgObjArray(2), String()), inbMsgDataDic, "O", CType(confMsgObjArray(0), String), "Sent")) Then
                        'Write to the log 
                        WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & "Error inserting " & CType(confMsgObjArray(0), String) & "record to TCS_TRAILER_EMU table")
                    End If
                Else
                    WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & CType(confMsgObjArray(0), String) & " message not sent")
                End If
            Else
                'add a record to the table with the status of to send
                AddToTCS_TRAILER_EMU(CType(confMsgObjArray(2), String()), inbMsgDataDic, "O", CType(confMsgObjArray(0), String), "Not Sent")
            End If
        End If
        'Reload Emulator Activity Grid

        Return retStat
    End Function

    Public Function CreateXml_SendOubMessageForInb(confMsgObjArray As Object(), dataDic As Dictionary(Of String, String)) As String
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)

        Dim rootTag As String = CType(confMsgObjArray(0), String)
        Dim dataTag As String = CType(confMsgObjArray(1), String)
        Dim dataElementsTags As String() = CType(confMsgObjArray(2), String())
        Dim dataElementValue As Dictionary(Of String, String) = dataDic

        Dim oubDataDic As New Dictionary(Of String, String)


        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement(rootTag)

        'write the header segment 
        CreateXMLMessageHeader(memory_stream, xml_text_writer)

        'Start the data segment 
        xml_text_writer.WriteStartElement(dataTag)

        For Each tag As String In dataElementsTags
            If (dataDic.ContainsKey(tag) = True) Then
                AddToXML(memory_stream, xml_text_writer, tag, dataDic.Item(tag))
                oubDataDic.Add(tag, dataDic.Item(tag))
            ElseIf (tag = "ERROR_CODE") Then
                AddToXML(memory_stream, xml_text_writer, tag, "0")
                oubDataDic.Add(tag, "0")
            ElseIf (tag = "ERROR_MSG") Then
                AddToXML(memory_stream, xml_text_writer, tag, "")
                oubDataDic.Add(tag, "")
            End If
        Next

        xml_text_writer.WriteEndElement()

        xml_text_writer.WriteEndElement()

        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        Dim strTextXMl As String = Nothing

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        xml_text_writer.Close()

        ' Add a row to the TCS_TRAILER_EMU table
        'If (Not AddToTCS_TRAILER_EMU(dataElementsTags, oubDataDic, "O", rootTag)) Then
        '    'Write to the log 
        '    WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & "Error inserting " & rootTag & "record to TCS_TRAILER_EMU table")

        'End If

        CreateXml_SendOubMessageForInb = strTextXMl

    End Function

    Public Function Load_TCS_TRAILER_EMU(dgv As DataGridView) As String

        'Attach the DataGridView Column Selector to the grid
        'so the user can hide/show the db columns.

        Dim dgvcs As DataGridViewColumnSelector = New DataGridViewColumnSelector(dgv)

        Dim sqlQry As String

        sqlQry = "Select * FROM TCS_TRAILER_EMU  where 1=1 "


        sqlQry += " order by CTRL_DATE desc"


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
            dgv.DataSource = dt
            With dgv
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
            dgv.AllowUserToAddRows = False
            dgv.Show()

            ds.Dispose()
            dt.Dispose()
            da.Dispose()

        Catch ex As Exception
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & ex.Message)
            MsgBox("Error Loading Trailer Activity Data Grid")
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

        Load_TCS_TRAILER_EMU = "0"

    End Function

    Public Function getXmlOfRow(row As DataGridViewRow, trnsDict As Dictionary(Of String, Object())) As String
        getXmlOfRow = ""

        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)

        Dim msgnam As String = row.Cells("MESSAGE_NAME").Value.ToString
        Dim rootTag As String = msgnam
        Dim dataTag As String = "DefDataTag"
        Dim dataElements As String() = DEFAULT_ELEMENTS

        Select Case rootTag
            Case TRL_CKIN_TAG
                dataTag = TRL_CKIN_DATA_TAG
                dataElements = TRL_CKIN_DATA_ELEMENTS
            Case TRL_CKIN_CONF_TAG
                dataTag = TRL_CKIN_CONF_DATA_TAG
                dataElements = TRL_CKIN_CONF_DATA_ELEMENTS
            Case TRL_LOC_REQUEST_TAG
                dataTag = TRL_LOC_REQUEST_DATA_TAG
                dataElements = TRL_LOC_REQUEST_DATA_ELEMENTS
            Case TRL_LOC_ASSG_CONF_TAG
                dataTag = TRL_LOC_ASSG_CONF_DATA_TAG
                dataElements = TRL_LOC_ASSG_CONF_DATA_ELEMENTS
            Case TRL_SHPRCP_REQUEST_TAG
                dataTag = TRL_SHPRCP_REQUEST_DATA_TAG
                dataElements = TRL_SHPRCP_REQUEST_DATA_ELEMENTS
            Case TRL_SHPRCP_ASG_CONF_TAG
                dataTag = TRL_SHPRCP_ASG_CONF_DATA_TAG
                dataElements = TRL_SHPRCP_ASG_CONF_DATA_ELEMENTS
            Case TRL_CKOUT_TAG
                dataTag = TRL_CKOUT_CONF_DATA_TAG
                dataElements = TRL_CKOUT_CONF_DATA_ELEMENTS
            Case TRL_CKOUT_CONF_TAG
                dataTag = TRL_CKOUT_CONF_DATA_TAG
                dataElements = TRL_CKOUT_CONF_DATA_ELEMENTS
            Case TRL_LOC_UPDATE_TAG
                dataTag = TRL_LOC_UPDATE_DATA_TAG
                dataElements = TRL_LOC_UPDATE_ELEMENTS
            Case TRL_LOC_UPDATE_CONF_TAG
                dataTag = TRL_LOC_UPDATE_CONF_DATA_TAG
                dataElements = TRL_LOC_UPDATE_CONF_DATA_ELEMENTS
            Case TRL_MOVE_PICKUP_TAG
                dataTag = TRL_MOVE_PICKUP_DATA_TAG
                dataElements = TRL_MOVE_PICKUP_ELEMENTS
            Case TRL_MOVE_COMPL_TAG
                dataTag = TRL_MOVE_COMPL_DATA_TAG
                dataElements = TRL_MOVE_COMPL_ELEMENTS
            Case TRL_MOVE_DEPOSIT_CONF_TAG
                dataTag = TRL_MOVE_DEPOSIT_CONF_DATA_TAG
                dataElements = TRL_MOVE_DEPOSIT_CONF_DATA_ELEMENTS
            Case TRL_MOVE_CANCEL_TAG
                dataTag = TRL_MOVE_CANCEL_DATA_TAG
                dataElements = TRL_MOVE_CANCEL_ELEMENTS
            Case TRL_MOVREQ_CANCEL_CONF_TAG
                dataTag = TRL_MOVREQ_CANCEL_CONF_DATA_TAG
                dataElements = TRL_MOVREQ_CANCEL_CONF_DATA_ELEMENTS
            Case TRL_MOVE_CHANGE_PRIORITY_TAG
                dataTag = TRL_MOVE_CHANGE_PRIORITY_DATA_TAG
                dataElements = TRL_MOVE_CHANGE_PRIORITY_ELEMENTS
            Case TRL_MOVE_REQUEST_TAG
                dataTag = TRL_MOVE_REQUEST_INB_DATA_TAG
                dataElements = TRL_MOVE_REQUEST_INB_DATA_ELEMENTS
            Case TRL_MOVE_REQUEST_INB_TAG
                dataTag = TRL_MOVE_REQUEST_INB_DATA_TAG
                dataElements = TRL_MOVE_REQUEST_INB_DATA_ELEMENTS
            Case TRL_MOVE_REQUEST_INB_TAG
                dataTag = TRL_MOVE_REQUEST_INB_DATA_TAG
                dataElements = TRL_MOVE_REQUEST_INB_DATA_ELEMENTS
            Case TRL_MOVE_REQUEST_INB_CONFIRM_TAG
                dataTag = TRL_MOVE_REQUEST_INB_CONFIRM_DATA_TAG
                dataElements = TRL_MOVE_REQUEST_INB_CONFIRM_MSG_ELEMENTS
        End Select

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        ''**xml_text_writer.WriteStartElement(rootElement)
        xml_text_writer.WriteStartElement(rootTag)
        'write the header segment 
        CreateXMLMessageHeader(memory_stream, xml_text_writer)

        'Start the data segment 
        xml_text_writer.WriteStartElement(dataTag)

        'Get only the cells that pertains to the message_name
        For Each elem As String In dataElements
            AddToXML(memory_stream, xml_text_writer, elem, row.Cells.Item(elem).Value.ToString())
        Next
        'For Each cell As DataGridViewCell In row.Cells
        '    If (Len(cell.Value.ToString) > 0) Then
        '        AddToXML(memory_stream, xml_text_writer, cell.OwningColumn.Name.ToString, cell.Value.ToString)
        '    End If
        'Next


        xml_text_writer.WriteEndElement()  ' end datatag

        xml_text_writer.WriteEndElement()  'end roottag

        ' End the document.
        xml_text_writer.WriteEndDocument()
        xml_text_writer.Flush()

        Dim strTextXMl As String = Nothing

        ' Use a StreamReader to display the result.
        Dim stream_reader As New StreamReader(memory_stream)

        memory_stream.Seek(0, SeekOrigin.Begin)
        strTextXMl = stream_reader.ReadToEnd()

        xml_text_writer.Close()

        getXmlOfRow = strTextXMl


    End Function


    Public Function updateTCS_TRAILER_EMU_MsgSts(dgvrow As DataGridViewRow) As Boolean
        Dim strSql As String = ""
        Dim status As Boolean = False


        Try
            Dim updateSql As New StringBuilder("UPDATE TCS_TRAILER_EMU set MESSAGE_STATUS = 'Sent' WHERE ")

            For Each cell As DataGridViewCell In dgvrow.Cells
                If Len(cell.Value.ToString) > 0 Then
                    With updateSql
                        .Append(" ")
                        .Append(cell.OwningColumn.Name)
                        .Append("= '").Append(cell.Value.ToString).Append("'  and ")
                    End With
                End If
            Next
            updateSql.Append("CKOUT_STAT is null")

            strSql = updateSql.ToString
            DBCON1.Execute(strSql)
            status = True

        Catch ex As Exception
            status = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & "[" & Err.Description & "]" & "[" & ex.Message & "]" & "[" & strSql & "]")
        End Try

        'Main.GetAndDisplayTrailerMoveData()
        Return status

    End Function
End Module

