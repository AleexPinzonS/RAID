
Option Strict On
Option Explicit On
Imports System.Reflection.MethodBase    'used to get procedure name for error logging
Imports System.Net   'IP Address determination

Module modCustomFunctionsSubs
    Public Function ValidateIniNumericEntry(ByVal strValue As String, ByVal iDefaultValue As Integer, ByVal ZeroOk As Boolean) As String

        Dim iValue As Integer = iDefaultValue
        Try
            'validate the number 
            If IsNumeric(strValue) Then
                iValue = CInt(strValue)
                If iValue <= 0 And ZeroOk = False Then
                    iValue = iDefaultValue
                End If
            End If
        Catch
            iValue = iDefaultValue
        Finally
            ValidateIniNumericEntry = iValue.ToString
        End Try

    End Function

    Public Function ValidateValueForYorN(ByVal strInput As String) As String
        Try

            'validate that input is yes or no
            Select Case strInput

                Case gcstrN
                    ValidateValueForYorN = strInput
                Case gcstrY
                    ValidateValueForYorN = strInput
                Case Else
                    ValidateValueForYorN = gcstrN

            End Select
        Catch ex As Exception
            ValidateValueForYorN = gcstrN

        End Try
    End Function

    Public Function Mod10CheckDigit(ByVal Barcode As String) As Integer
        Dim i As Integer
        Dim TotalOdd As Integer
        Dim TotalEven As Integer
        Dim Total As Integer
        Dim strTotalRightOneChar As String
        Dim iRightCharVal As Integer

        Try
            Barcode = Trim(Barcode)
            'get odd numbers
            For i = 1 To Len(Barcode) Step 2
                TotalOdd += Convert.ToInt16(Mid(Barcode, i, 1))
            Next i
            TotalOdd *= 3

            'get even numbers
            i = 0
            For i = 2 To Len(Barcode) Step 2
                TotalEven += Convert.ToInt16(Mid(Barcode, i, 1))
            Next i

            Total = TotalOdd + TotalEven
            strTotalRightOneChar = Right(Convert.ToString(Total), 1)


            iRightCharVal = Convert.ToInt16(IIf(strTotalRightOneChar = gcStrZero, "10", strTotalRightOneChar))


            Mod10CheckDigit = 10 - iRightCharVal

        Catch
            Mod10CheckDigit = -1
            'dont set anything
        End Try
    End Function



    Public Function RandomNumber(ByVal low As Integer, ByVal high As Integer) As Integer
        Static RandomNumGen As New System.Random
        Return RandomNumGen.Next(low, high)
    End Function

    Public Sub ProcessGridDeSelectAll(ByVal oGrid As AxMSFlexGridLib.AxMSFlexGrid)
        Dim x As Integer

        oGrid.Col = 0

        For x = 1 To oGrid.Rows - 1
            oGrid.Row = x
            oGrid.set_TextMatrix(x, 0, vbNullString)
        Next
    End Sub

    Public Sub ProcessGridSelectAll(ByVal oGrid As AxMSFlexGridLib.AxMSFlexGrid)
        Dim x As Integer

        oGrid.Col = 0

        'only select non errored rows visible rows
        For x = 1 To oGrid.Rows - 1
            oGrid.Row = x
            If oGrid.get_RowHeight(x) > 0 Then
                If Len(oGrid.get_TextMatrix(x, 1)) > 0 Then

                    'only allow selection of items that are not in the pick step
                    '  If Convert.ToInt32(oGrid.get_TextMatrix(x, 2)) <> giPickStepNumber Then
                    oGrid.set_TextMatrix(x, 0, gcstrY)
                    'End If
                End If
            End If
        Next
    End Sub

    Public Function ProcessGridMouseDown(ByVal oGrid As AxMSFlexGridLib.AxMSFlexGrid, ByVal iMouseButton As Integer) As String
        Dim strText As String
        Dim iRowSel As Integer
        Dim iColSel As Integer
        Dim strNewValue As String
        Dim strCurValue As String
        Dim strColHeader As String
        Dim iMsgResult As Integer


        iRowSel = oGrid.MouseRow
        iColSel = oGrid.MouseCol
        ProcessGridMouseDown = String.Empty

        'first row is header row
        If iRowSel = 0 Then Exit Function

        strText = Trim(oGrid.get_TextMatrix(iRowSel, iColSel))

        If iMouseButton = 2 Then

            'Save to clipboard 
            Clipboard.SetDataObject(strText)
            ProcessGridMouseDown = strText
        ElseIf iColSel = 0 Then

            'toggle the selection flag
            If oGrid.get_TextMatrix(iRowSel, 0) = gcstrY Then
                oGrid.set_TextMatrix(iRowSel, 0, vbNullString)
            Else
                oGrid.set_TextMatrix(iRowSel, 0, gcstrY)
            End If

        Else

            'Get the column header
            strColHeader = oGrid.get_TextMatrix(0, iColSel)

            'allow user to temporarily override status
            strCurValue = oGrid.get_TextMatrix(iRowSel, iColSel)

            strNewValue = InputBox(strColHeader & " Value:", "Override Value", strCurValue)
            If Strings.Len(strNewValue) = 0 Then
                iMsgResult = MessageBox.Show("Keep the Original Value of " & strCurValue & "?", "Null Value Detected", MessageBoxButtons.YesNo)

                If iMsgResult = Windows.Forms.DialogResult.Yes Then
                    oGrid.set_TextMatrix(iRowSel, iColSel, strCurValue)
                Else
                    oGrid.set_TextMatrix(iRowSel, iColSel, strNewValue)
                End If

            Else
                oGrid.set_TextMatrix(iRowSel, iColSel, strNewValue)
            End If

            'End If

        End If
    End Function



    Public Function RecordAffectedMessage(ByVal lRecordsAffected As Long, ByVal strOperationDescription As String) As String
        Dim strMsg As String = String.Empty
        Try
            If lRecordsAffected > 0 Then
                strMsg = lRecordsAffected.ToString & Space(1) & "Record(s)" & Space(1) & strOperationDescription & "d"
            ElseIf lRecordsAffected = 0 Then
                strMsg = strOperationDescription & Space(1) & "Criteria Not Met - 0 Records Affected"
            ElseIf lRecordsAffected = -1 Then
                strMsg = strOperationDescription & Space(1) & "Errored Out and Failed"
            Else
                strMsg = "Unknown" & Space(1) & strOperationDescription & Space(1) & "Error"
            End If

        Catch
            strMsg = "Unknown" & Space(1) & strOperationDescription & Space(1) & "Error"
        Finally
            RecordAffectedMessage = Space(2) & strMsg
        End Try


    End Function

    Public Function LogFileName() As String
        Dim strMonth As String
        Dim strDay As String
        Dim charPad As Char

        charPad = Convert.ToChar(gcStrZero)

        strMonth = Month(Now).ToString.PadLeft(2, charPad)
        strDay = Microsoft.VisualBasic.Day(Now).ToString.PadLeft(2, charPad)

        LogFileName = gstrProgramDataPath & cstrLogFilePrefix & Year(Now) & strMonth & strDay & ".log"

    End Function


    Public Function GetIPAddress() As String



        If Len(gstrIPAddressOverrideLocalPC) < 3 Then
            'no override
            Return GetLocalIP()
        Else
            Return gstrIPAddressOverrideLocalPC
        End If


    End Function
    Function GetLocalIP() As String
        Dim IPList As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Dim IpAddress As System.Net.IPAddress
        Try
            For Each IpAddress In IPList.AddressList


                'Only return IPv4 routable IPs       
                If (IpAddress.AddressFamily = Sockets.AddressFamily.InterNetwork) AndAlso (Not IsPrivateIP(IpAddress.ToString)) Then


                    Return IpAddress.ToString
                End If
            Next
            Return ""
        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Return ""
        End Try
    End Function
    Function IsPrivateIP(ByVal CheckIP As String) As Boolean
        Dim Quad1, Quad2 As Integer
        Quad1 = CInt(CheckIP.Substring(0, CheckIP.IndexOf(".")))
        Quad2 = CInt(CheckIP.Substring(CheckIP.IndexOf(".") + 1).Substring(0, CheckIP.IndexOf(".")))
        Select Case Quad1
            Case 10
                Return True
            Case 172
                If Quad2 >= 16 And Quad2 <= 31 Then Return True
            Case 192
                If Quad2 = 168 Then Return True
        End Select
        Return False
    End Function


    Public Sub WriteLog(ByVal strAction As String, ByVal strText As String)
        Dim FilePath As String

        Try
            If giMessageLogLevel = -1 Then Exit Sub

            FilePath = LogFileName()
            My.Computer.FileSystem.WriteAllText(FilePath, Now & " | " & strAction.PadRight(15, Convert.ToChar(" ")) & strText.Trim & vbCrLf, True)
        Catch

        Finally

        End Try
    End Sub
    Public Sub WriteLogAckResponse(ByVal strAction As String, ByVal strText As String)
        Dim FilePath As String
        Dim charPad As Char
        Dim strMonth As String
        Dim strDay As String

        Try

            If giMessageLogLevel = -1 Then Exit Sub

            charPad = Convert.ToChar(gcStrZero)

            strMonth = Month(Now).ToString.PadLeft(2, charPad)
            strDay = Microsoft.VisualBasic.Day(Now).ToString.PadLeft(2, charPad)

            FilePath = gstrProgramDataPath & "ACK" & cstrLogFilePrefix & Year(Now) & strMonth & strDay & ".log"

            My.Computer.FileSystem.WriteAllText(FilePath, Now & " | " & strAction.PadRight(15, Convert.ToChar(" ")) & strText.Trim & vbCrLf, True)
        Catch

        Finally

        End Try
    End Sub

End Module
