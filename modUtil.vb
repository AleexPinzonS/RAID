Option Explicit On
Option Strict On

'Imports System.Net.Sockets
'Imports System.Net
Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Linq
Imports System.Reflection.MethodBase



Module modUtil
    'Public Structure ButtonTannsactionData
    '    Dim tranRootTag As String
    '    Dim tranDatatag As String
    '    Dim trnDataElements As String()
    '    Dim trnDataFieldsContainer As GroupBox
    'End Structure

    Public HIGHLIGHT_FIELD_COLOR As Color = Color.Red
    Public HIGHLIGHT_FIELD_RESET_COLOR As Color = Color.White

    'Trailer Checkin tags/columns/fields
    Public TRL_CKIN_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "TRAILER_TYPE", "LENGTH", "WIDTH", "HEIGHT",
                                        "EMPTY_WEIGHT", "FULL_WEIGHT", "EST_WEIGHT", "TEMP_CODE",
                                        "DRIVER_NAME", "TRACTOR_ID", "LICENSE_NUM", "LICENSE_STATE",
                                        "USABLE", "UNUSABLE_REASON", "EMPTY", "ORIGIN", "CONTENTS", "FREIGHT_AMOUNT",
                                        "FREIGHT_CURRENCY", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER", "BOL_NUMBER", "SITE_NAME",
                                        "BUILDING", "BUILDING_LIST", "LOCATION", "TCS_TRANSIT_NUM", "TCS_TRAILER_TAG", "CKIN_DATE"}
    'Trailer Checkin Button tag array.
    Public TRAILER_CKIN_BUTTON_TAG_ARRAY As Object() = {"TrailerCheckin", "TrailerData", TRL_CKIN_DATA_ELEMENTS, Main.gbTrailerMovMain}


    'Trailer Checkin Confirm Data
    'Public Structure TrailerCheckinConfirm
    '    Dim strTRAILER_NUMBER As String
    '    Dim strTRUCK_LINE As String
    '    Dim strTRACTOR_ID As String
    '    Dim strSHIPMENT_ID As String
    '    Dim strRR_NUMBER As String
    '    Dim strINVOICE_NUMBER As String
    '    Dim strSITE_NAME As String
    '    Dim strBUILDING As String
    '    Dim strLOCATION As String
    '    Dim strERROR_CODE As String
    '    Dim strERROR_MSG As String
    'End Structure

    'Inbound Messages Tags
    Public TRL_CKIN_CONF_TAG As String = "TrailerCheckinConfirm"
    Public TRL_CKIN_CONF_DATA_TAG As String = "TrailerData"
    'Trailer Checkin Confirm Fields
    Public TRL_CKIN_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "TRACTOR_ID",
                                            "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER",
                                            "SITE_NAME", "BUILDING", "TCS_TRAILER_TAG", "LOCATION",
                                            "ERROR_CODE", "ERROR_MSG"}

    'Trailer location assigmnment tags/columns/fields
    Public trlLocAsgnmtTagLst As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "SITE_NAME", "BUILDING", "BUILDING_LIST", "QUEUE_FLAG"}

    'trailer location assignment button tag array
    Public TRAILER_LOCATION_ASGMNT_BUTTON_TAG_ARRAY As Object() = {"TrailerLocRequest", "TrailerData", trlLocAsgnmtTagLst, Main.gbTrailerMovMain}

    'trailer location assignment confirmation.
    'Public Structure TrailerLocAsgnmtConfirm
    '    Dim strTRAILER_NUMBER As String
    '    Dim strTRUCK_LINE As String
    '    Dim strSITE_NAME As String
    '    Dim strBUILDING As String
    '    Dim strLOCATION As String
    '    Dim strERROR_CODE As String
    '    Dim strERROR_MSG As String
    'End Structure
    'Inbound Messages Tags
    Public TRL_LOC_ASSG_CONF_TAG As String = "TrailerLocAssign"
    Public TRL_LOC_ASSG_CONF_DATA_TAG As String = "LocationData"
    'Trailer Location Assignment Confirm Fields
    Public TRL_LOC_ASSG_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "SITE_NAME", "BUILDING", "LOCATION", "ERROR_CODE", "ERROR_MSG"}

    'Trailer Shipment/Receipt Assignment 
    Public trlAsgnShpRcpTagLst As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "TRACTOR_ID", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER", "BOL_NUMBER"}

    Public TRAILER_SHP_RCP_ASGNMT_BTN_TAG_ARRAY As Object() = {"TrailerShipRecRequest", "ShipRecData", trlAsgnShpRcpTagLst, Main.gbTrailerMovMain}

    'Public Structure TrailerShpRcpAsgnmtConfirm
    '    Dim strTRAILER_NUMBER As String
    '    Dim strTRUCK_LINE As String
    '    Dim strTRACTOR_ID As String
    '    Dim strSHIPMENT_ID As String
    '    Dim strRR_NUMBER As String
    '    Dim strINVOICE_NUMBER As String
    '    Dim strBOL_NUMBER As String
    '    Dim strERROR_CODE As String
    '    Dim strERROR_MSG As String
    'End Structure
    'Inbound Messages Tags
    Public TRL_SHPRCP_ASG_CONF_TAG As String = "TrailerShipRecAssignment"
    Public TRL_SHPRCP_ASG_CONF_DATA_TAG As String = "ShipRecData"
    'Trailer Shipment Assignment Confirm Fields
    Public TRL_SHPRCP_ASG_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "TRACTOR_ID", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER", "BOL_NUMBER", "ERROR_CODE", "ERROR_MSG"}

    'Trailer Checkout 
    Public trlCkoutTagLst As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "DRIVER_NAME", "LICENSE_NUM",
                                         "LICENSE_STATE", "TRACTOR_ID", "CARRIER_ARRIVAL_DT", "CKOUT_DATE"}

    Public TRAILER_CKOUT_BUTTON_TAG_ARRAY As Object() = {"TrailerCheckout", "TrailerData", trlCkoutTagLst, Main.gbTrailerMovMain}

    'Public Structure TrailerCheckOutConfirm
    '    Dim strTRAILER_NUMBER As String
    '    Dim strTRUCK_LINE As String
    '    Dim strTRACTOR_ID As String
    '    Dim strSHIPMENT_ID As String
    '    Dim strPO_NUMBER As String
    '    Dim strERROR_CODE As String
    '    Dim strERROR_MSG As String
    'End Structure
    'Inbound Messages Tags
    Public TRL_CKOUT_CONF_TAG As String = "TrailerCheckoutConfirm"
    Public TRL_CKOUT_CONF_DATA_TAG As String = "TrailerData"
    'Trailer Checkout Confirm Fields
    Public TRL_CKOUT_CONF_DATA_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "TRACTOR_ID", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER", "BOL_NUMBER", "ERROR_CODE", "ERROR_MSG"}



    Public TRL_LOC_UPDATE_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "SITE_NAME", "LOCATION", "TCS_TRAILER_TAG"}
    Public TRAILER_LOC_UPDATE_BUTTON_TAG_ARRAY As Object() = {"TrailerLocationUpdate", "TrailerData", TRL_LOC_UPDATE_ELEMENTS, Main.gbTrailerMovMain}

    Public TRL_MOVE_PICKUP_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "REQUEST_ID", "SOURCE_SITE_NAME", "SOURCE_LOCATION", "DEVICE_ID", "USER_ID"}
    Public TRAILER_MOVE_PICKUP_BUTTON_TAG_ARRAY As Object() = {"TrailerMovePickup", "TrailerData", TRL_MOVE_PICKUP_ELEMENTS, Main.gbTrailerMovMain}

    Public TRL_MOVE_COMPL_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "REQUEST_ID", "DEST_SITE_NAME", "DEST_LOCATION", "DEVICE_ID", "USER_ID"}
    Public TRAILER_MOVE_COMPL_BUTTON_TAG_ARRAY As Object() = {"TrailerMoveComplete", "TrailerData", TRL_MOVE_COMPL_ELEMENTS, Main.gbTrailerMovMain}

    Public TRL_MOVE_CANCEL_ELEMENTS As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "REQUEST_ID", "USABLE", "UNUSABLE_REASON", "SITE_NAME", "LOCATION"}
    Public TRAILER_MOVE_CANCEL_BUTTON_TAG_ARRAY As Object() = {"TrailerMoveCancel", "TrailerData", TRL_MOVE_CANCEL_ELEMENTS, Main.gbTrailerMovMain}

    'TODO or REDO BELOW **********V
    'TO RE-DO after changes to original document

    Public trlMoveToNewLocTagLst As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "SITE_NAME", "BUILDING", "LOCATION"}
    Public trlChangePriorityTagLst As String() = {"TRAILER_NUMBER", "TRUCK_LINE", "PRIORITY", "REQUEST_ID"}

    Public trlReqForDepartTractorTagLst As String() = {"TRUCK_LINE",
                                                        "SHIP_SITE_NAME", "REQUEST_TYPE",'These two tag are not on screen yet
                                                        "TRACTOR_ID",
                                                        "REC_SITE_NAME", "CUSTOMER_ID"} 'These two tag are not on screen yet

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


    Private Sub AddToXML(ByVal memory_stream As MemoryStream, ByVal xmlWriter As XmlTextWriter, ByVal ctrl As Control)
        'As XmlTextWriter
        Try
            If (TypeOf ctrl Is TextBox Or TypeOf ctrl Is ComboBox) Then
                'If (ctrl.Text.Length > 0) Then  'send the empty tag if no text.
                xmlWriter.WriteStartElement(CType(ctrl.Tag, String))
                    xmlWriter.WriteString(ctrl.Text)
                    xmlWriter.WriteEndElement()
                'End If
            ElseIf (TypeOf ctrl Is RadioButton) Then
                If (CType(ctrl, RadioButton).Checked) Then
                    xmlWriter.WriteStartElement(CType(ctrl.Tag, String))
                    xmlWriter.WriteString(ctrl.Text)
                    xmlWriter.WriteEndElement()
                End If
            ElseIf (TypeOf ctrl Is CheckBox) Then
                Dim cb As CheckBox = CType(ctrl, CheckBox)
                xmlWriter.WriteStartElement(CType(ctrl.Tag, String))
                If cb.Checked Then
                    xmlWriter.WriteString("Y")
                Else
                    xmlWriter.WriteString("N")
                End If

                xmlWriter.WriteEndElement()
            ElseIf (TypeOf ctrl Is DateTimePicker) Then
                Dim dt As DateTimePicker = CType(ctrl, DateTimePicker)
                xmlWriter.WriteStartElement(CType(dt.Tag, String))
                xmlWriter.WriteString(Format(dt.Value, "yyyyMMddHHmmss"))
                xmlWriter.WriteEndElement()
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
        ''**xml_text_writer.WriteStartElement(CType(senderCtrl.Tag, String))
        xml_text_writer.WriteStartElement(dataTag)

        ''**Dim allSubControls As List(Of Control) = getAllCtrlList(containerGroupControl)
        Dim allSubControls As List(Of Control) = getAllCtrlList(container)

        ''**For Each tag As String In xmlTagList
        For Each tag As String In tagLst
            ctrl = allSubControls.Find(Function(s) CType(s.Tag, String) = tag)
            If (IsNothing(ctrl) = False) Then
                AddToXML(memory_stream, xml_text_writer, ctrl)
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

        If (checkTCS_TRAILER_EMU(getControlTextValue(allSubControls.Find(Function(s) CType(s.Tag, String) = "TRUCK_LINE")),
                        getControlTextValue(allSubControls.Find(Function(s) CType(s.Tag, String) = "TRAILER_NUMBER")),
                        getControlTextValue(allSubControls.Find(Function(s) CType(s.Tag, String) = "TRACTOR_ID"))) = False) Then
            AddToTCS_TRAILER_EMU(CType(sender, Button), allSubControls)
        Else
            'update existing record
            updateTCS_TRAILER_EMU(CType(sender, Button), allSubControls, tagLst)
        End If

        'AddToTCS_TRAILER_EMU(CType(sender, Button), allSubControls)

        CreateXML_ForAction = strTextXMl

    End Function

    Public Function CreateXML_ForContainer(ByVal sender As Object) As String

        Dim ctrl As Control
        Dim memory_stream As New MemoryStream
        Dim xml_text_writer As New XmlTextWriter(memory_stream, System.Text.Encoding.UTF8)

        Dim senderCtrl As Control = CType(sender, Button)
        Dim container As Control = senderCtrl.Parent

        ' Use indentation to make the result look nice.
        xml_text_writer.Formatting = Formatting.Indented
        xml_text_writer.Indentation = 4

        ' Write the XML declaration.
        xml_text_writer.WriteStartDocument(True)

        'Root Tag
        xml_text_writer.WriteStartElement(CType(senderCtrl.Tag, String))

        CreateXMLMessageHeader(memory_stream, xml_text_writer)

        Dim containerTag As String = Nothing

        containerTag = CType(container.Tag, String)

        If IsNothing(containerTag) Then
            containerTag = "CONTAINER_MISSING_TAG"
        End If

        'Dim allTextBoxes As List(Of TextBox)
        Dim allSubControls As New List(Of Control)
        'Try
        '    'allTextBoxes = (From txt In container.Controls.OfType(Of TextBox)()
        '    '                Order By txt.TabIndex).ToList()
        '    allSubControls = (From ctrol In container.Controls.OfType(Of Control)()
        '                      Order By ctrol.TabIndex).ToList()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        xml_text_writer.WriteStartElement(CType(container.Tag, String))

        allSubControls.AddRange(getAllCtrls(container, memory_stream, xml_text_writer))

        'Dim txtbox As TextBox
        'For Each txtbox In allTextBoxes

        'THIS IS WORKING.
        '=========
        'For Each ctrl In (From ctrol In container.Controls.OfType(Of Control)()
        '                  Order By ctrol.TabIndex).ToList()
        '    AddToXML(memory_stream, xml_text_writer, ctrl)
        'Next
        '=============
        'For Each ctrl In container.Controls
        '    AddToXML(memory_stream, xml_text_writer, ctrl)
        'Next

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

        ' Close the XmlTextWriter.
        xml_text_writer.Close()

        CreateXML_ForContainer = strTextXMl

    End Function

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

    Private Function getAllCtrls(ByVal parent As Control, ByVal memory_stream As MemoryStream, ByVal xml_text_writer As XmlTextWriter) As List(Of Control)
        Dim ctrlList As New List(Of Control)
        Dim ctrl As Control

        For Each ctrl In (From ctrol In parent.Controls.OfType(Of Control)()
                          Order By ctrol.TabIndex).ToList()
            If (ctrl.HasChildren) Then
                ctrlList.AddRange(getAllCtrls(ctrl, memory_stream, xml_text_writer))
            End If
            AddToXML(memory_stream, xml_text_writer, ctrl)
        Next

        Return ctrlList
    End Function

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
                     "(TRUCK_LINE, TRAILER_NUMBER, TRACTOR_ID,TRAILER_TYPE, LENGTH,WIDTH,HEIGHT,
                       EMPTY_WEIGHT, FULL_WEIGHT, EST_WEIGHT, TEMP_CODE, DRIVER_NAME, 
                       LICENSE_NUM, LICENSE_STATE, USABLE, UNUSABLE_REASON, EMPTY, 
                       ORIGIN, CONTENTS, FREIGHT_AMOUNT, FREIGHT_CURRENCY, 
                       SHIPMENT_ID, RR_NUMBER, INVOICE_NUMBER, BOL_NUMBER, 
                       SITE_NAME, BUILDING, BUILDING_LIST, LOCATION, 
                       TCS_TRANSIT_NUM, TCS_TRAILER_TAG, CTRL_DATE, CKIN_DATE)
                       values ('" &
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
        Catch ex As Exception
            status = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & "[" & Err.Description & "]" & "[" & ex.Message & "]" & "[" & strSql & "]")
            'dbrec1.Close()
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

    Public Function updateTCS_TRAILER_EMU(inbFldLst As String(), xmlObj As Dictionary(Of String, String)) As Boolean
        Dim strSql As String
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


End Module

