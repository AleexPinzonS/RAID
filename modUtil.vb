Option Explicit On
Option Strict On

'Imports System.Net.Sockets
'Imports System.Net
Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Linq



Module modUtil
    'Public Structure ButtonTannsactionData
    '    Dim tranRootTag As String
    '    Dim tranDatatag As String
    '    Dim trnDataElements As String()
    '    Dim trnDataFieldsContainer As GroupBox
    'End Structure

    Public HIGHLIGHT_FIELD_COLOR As Color = Color.Red
    Public HIGHLIGHT_FIELD_RESET_COLOR As Color = Color.White

    Public trlCkInTagLst As String() = {"TRAILER_ID", "TRUCK_LINE", "TYPE", "LENGTH", "WIDTH", "HEIGHT",
                                        "EMPTY_WEIGHT", "FULL_WEIGHT", "EST_WEIGHT", "TEMP_CODE",
                                        "DRIVER_NAME", "TRACTOR_ID", "LICENSE_PLATE_NUM", "LICENSE_PLATE_STATE",
                                        "USABLE", "UNUSABLE_REASON", "EMPTY", "ORIGIN", "CONTENTS", "FREIGHT_AMOUNT",
                                        "FREIGHT_CURRENCY", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER", "SITE_NAME",
                                        "BUILDING", "BUILDING_LIST", "LOCATION", "WCS_TRANSIT_NUM"}

    Public trlCkoutTagLst As String() = {"TRAILER_ID", "TRUCK_LINE", "DRIVER_NAME", "LICENSE_PLATE_NUM",
                                         "LICENSE_PLATE_STATE", "TRACTOR_ID", "CARRIER_ARRIVAL_DT"}


    Public trlLocAsgnmtTagLst As String() = {"TRAILER_ID", "TRUCK_LINE", "SITE_NAME", "BUILDING", "BUILDING_LIST"}
    Public trlAsgnShpRcpTagLst As String() = {"TRAILER_ID", "TRUCK_LINE", "TRACTOR_ID", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER"}
    Public trlTractorCkinTagLst As String() = {"TRAILER_ID", "TRUCK_LINE", "TRACTOR_ID", "SHIPMENT_ID", "RR_NUMBER", "INVOICE_NUMBER"}
    Public trlMoveToNewLocTagLst As String() = {"TRAILER_ID", "TRUCK_LINE", "SITE_NAME", "BUILDING", "LOCATION"}
    Public trlMoveReqTagLst As String() = {"TRAILER_ID", "TRUCK_LINE", "SITE_NAME", "BUILDING", "BUILDING_LIST", "LOCATION",
                                            "PRIORITY", "REQUEST_ID"} 'These two tag are not on screen yet
    Public trlChangePriorityTagLst As String() = {"TRAILER_ID", "TRUCK_LINE",
                                                    "PRIORITY", "REQUEST_ID"} 'These two tag are not on screen yet

    Public trlCancelReqTagLst As String() = {"TRAILER_ID", "TRUCK_LINE",
                                                "PRIORITY", "REQUEST_ID"} 'These two tag are not on screen yet
    Public trlReqForDepartTractorTagLst As String() = {"TRUCK_LINE",
                                                        "SHIP_SITE_NAME", "REQUEST_TYPE",'These two tag are not on screen yet
                                                        "TRACTOR_ID",
                                                        "REC_SITE_NAME", "CUSTOMER_ID"} 'These two tag are not on screen yet

    'Private Function GetAll(control As Control, type As Type) As IEnumerable(Of Control)
    '    Dim controls As List(Of Control) = control.Controls.Cast(Of Control)()

    '    Return controls.SelectMany(Function(ctrl) GetAll(ctrl, type)).Concat(controls).Where(Function(c) c.[GetType]() = type)
    'End Function

    Private Sub AddToXML(ByVal memory_stream As MemoryStream, ByVal xmlWriter As XmlTextWriter, ByVal ctrl As Control)
        'As XmlTextWriter
        Try
            If (TypeOf ctrl Is TextBox Or TypeOf ctrl Is ComboBox) Then
                If (ctrl.Text.Length > 0) Then
                    xmlWriter.WriteStartElement(CType(ctrl.Tag, String))
                    xmlWriter.WriteString(ctrl.Text)
                    xmlWriter.WriteEndElement()
                End If
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

    Public Sub AddToXML(ByVal memory_stream As MemoryStream, ByVal xmlWriter As XmlTextWriter, ByVal ctrl As TextBox)

        Try
            xmlWriter.WriteStartElement(CType(ctrl.Tag, String))
            xmlWriter.WriteString(ctrl.Text)
            xmlWriter.WriteEndElement()
        Catch ex As Exception
            'MsgBox(ex.Message)
            WriteLog("AddToXML", "ERROR: Adding tag for [" + CType(ctrl.Tag, String) + "] " + ex.Message)
        End Try

    End Sub


    'Public Function CreateXML_ForContainer(ByVal container As Control) As String

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


        '
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
                    If ((TypeOf ctr Is TextBox Or TypeOf ctr Is ComboBox Or TypeOf ctr Is CheckBox) And
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
End Module
