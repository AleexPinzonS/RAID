Option Strict On
Option Explicit On
Imports System.Reflection.MethodBase    'used to get procedure name for error logging
Module modRAIDShared
    Public Function Update_CUST_SHIPMENT(ByVal strSHIP_ID As String, ByVal strRETRO_STATUS As String, ByVal strSLOT As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_SHIPMENT set " & _
            "SLOT='" & strSLOT & "'," & _
            "RETRO_STATUS='" & strRETRO_STATUS & "' " & _
            "where CUST_SHIPMENT ='" & strSHIP_ID & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_SHIPMENT = True

        Catch
            Update_CUST_SHIPMENT = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strSHIP_ID & Space(1) & Err.Description)

        End Try

    End Function

   

    Public Function Update_CUST_SHIPMENT_Single_Field(ByVal strCUST_SHIPMENT As String, ByVal strFieldName As String, ByVal strFieldValue As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update CUST_SHIPMENT set " & _
            strFieldName & "='" & strFieldValue & "' " & _
            "where CUST_SHIPMENT ='" & strCUST_SHIPMENT & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_CUST_SHIPMENT_Single_Field = True

        Catch
            Update_CUST_SHIPMENT_Single_Field = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strCUST_SHIPMENT & Space(1) & Err.Description)

        End Try

    End Function

    Public Sub SendMsg22(ByVal strMessage_type As String, ByVal strSHIP_ID As String, ByVal strSlot As String)
        Dim strXMLShipid As String
        Dim bMsgSuccess As Boolean
        Try
            If strMessage_type = "A22" Then
                strXMLShipid = strSHIP_ID
                bMsgSuccess = SendRequest(CreateXML_ShipStageStart(strMessage_type, strXMLShipid, strSlot))
            ElseIf strMessage_type = "D22" Then
                strXMLShipid = String.Empty
                bMsgSuccess = SendRequest(CreateXML_ShipDestageStart(strMessage_type, strXMLShipid, strSlot))
            ElseIf strMessage_type = "A42" Then
                strXMLShipid = strSHIP_ID
                bMsgSuccess = SendRequest(CreateXML_ProdOrderStageStart(strMessage_type, strXMLShipid, strSlot))
            ElseIf strMessage_type = "D42" Then
                strXMLShipid = String.Empty
                bMsgSuccess = SendRequest(CreateXML_ProdOrderStartDeStage(strMessage_type, strXMLShipid, strSlot))
            End If



            If bMsgSuccess = True Then

                Update_CUST_SHIPMENT(strSHIP_ID, strMessage_type, strSlot)
            Else
                WriteLog(gcstrError, "Msg " & strMessage_type & " Failed for Shipid " & strSHIP_ID & " Slot " & strSlot & " Database Update Skipped")
            End If


        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strSHIP_ID & Space(1) & Err.Description)
        End Try
    End Sub

    Public Function ManualOutputLocationExists(ByVal strLocation As String) As Boolean


        Try
            If Array.IndexOf(ManualOutputLocations, strLocation) <> -1 Then

                ManualOutputLocationExists = True
            Else
                ManualOutputLocationExists = False

            End If

        Catch ex As Exception
            ManualOutputLocationExists = False
        End Try
    End Function

    Public Function DeleteULIDfromDB(ByVal strULID As String) As Long
        Dim strSql As String
        Dim lRecordsUpdated As Object = 0

        Try

            strSql = "delete from cust_pallet where " & _
                    "CUST_ID ='" & strULID & "' or BASE_ULID ='" & strULID & "'"
            DBCON1.Execute(strSql, lRecordsUpdated)

        Catch ex As Exception
            lRecordsUpdated = -1
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        Finally
            DeleteULIDfromDB = CLng(lRecordsUpdated)
        End Try
    End Function

    Public Function DeleteDatafromEmulatorDBTablewithWhereClause(ByVal strTable As String, ByVal strWhere As String, ByVal bConfirmDeletion As Boolean) As Integer
        Dim strSQL As String
        Dim iMsgResult As DialogResult
        Dim oRecordsAffected As Object = 0

        Try
            If bConfirmDeletion = True Then

                strSQL = "delete from " & strTable & " where " & strWhere

                iMsgResult = MessageBox.Show("Ok to " & strSQL & " ?", "Confirm Emulator Data Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If iMsgResult = Windows.Forms.DialogResult.No Then
                    oRecordsAffected = -1

                    Exit Function
                End If
            End If

            strSQL = "delete from " & strTable & " where " & strWhere

            DBCON1.Execute(strSQL, oRecordsAffected)

            WriteLog("INFO", "Success - " & strSQL)

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        Finally
            DeleteDatafromEmulatorDBTablewithWhereClause = CInt(oRecordsAffected)
        End Try

    End Function
    Public Function Update_TRAILER_FPDS(ByVal strTRUCK_LINE As String, ByVal strTRAILER_NUMBER As String, ByVal strMESSAGE_TYPE As String, ByVal strActiv_Input_Location As String) As Boolean

        Dim strSql As String

        Try

            strSql = "update TRAILER_FPDS set " & _
            "MESSAGE_TYPE='" & strMESSAGE_TYPE & "'," & _
            "ACTIV_INPUT_LOCATION='" & strActiv_Input_Location & " '," & _
            "CTRL_DATE='" & Date.Now.ToString & "' " & _
            "where TRUCK_LINE ='" & strTRUCK_LINE & "' and " & _
            "TRAILER_NUMBER ='" & strTRAILER_NUMBER & "'"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            Update_TRAILER_FPDS = True

        Catch
            Update_TRAILER_FPDS = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strTRUCK_LINE & "|" & strTRAILER_NUMBER & Space(1) & Err.Description)

        End Try

    End Function

    Public Function InsertULInto_CUST_PALLET(ByVal strULID As String, ByVal strRetro_Status As String, ByVal strBRAND_CODE As String, ByVal strBRAND_DESC As String, _
                  ByVal strCODE_DATE As String, ByVal strPALLET_TYPE As String, ByVal strHOLD_STATUS As String, ByVal strRETRO_LOC As String, ByVal strBASE_ULID As String) As Boolean

        Dim strSql As String

        Try

            strSql = "INSERT INTO CUST_PALLET " & _
            "(CUST_ID, RETRO_STATUS, BRAND_CODE,BRAND_DESC,CODE_DATE,PALLET_TYPE,HOLD_STATUS,RETRO_LOC, BASE_ULID) values ('" & _
            strULID & "','" & strRetro_Status & "','" & strBRAND_CODE & "','" & strBRAND_DESC & "','" & strCODE_DATE & "','" & strPALLET_TYPE & "','" & strHOLD_STATUS & "','" & _
            strRETRO_LOC & "','" & strBASE_ULID & "')"

            If Len(strSql) > 0 Then
                DBCON1.Execute(strSql)
            End If

            InsertULInto_CUST_PALLET = True

        Catch
            InsertULInto_CUST_PALLET = False
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & strULID & Space(1) & Err.Description)

        End Try

    End Function
End Module
