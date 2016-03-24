
Imports System.Reflection.MethodBase    'used to get procedure name for error logging

Module modHstInb


    'host inbound
    Public gstrHstInbHost_Id As String
    Public gstrHstInbMachId As String
    Public gstrHstInbSubsit As String


    Public Sub iniHostInbound(ByVal oini As ini, ByVal strIniFileName As String, ByVal lpSectionName As String)
        Dim lpKeyName As String
        Dim strValue As String

        Try

            lpKeyName = "HstInbHost_Id"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "WILMA", strIniFileName)
            gstrHstInbHost_Id = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "HstInbSubsit"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "1", strIniFileName)
            gstrHstInbSubsit = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)

            lpKeyName = "HstInbMachId"
            strValue = oini.ProfileGetItem(lpSectionName, lpKeyName, "E8", strIniFileName)
            gstrHstInbMachId = strValue
            Call AddIniKeyNametoIniArray(lpSectionName, lpKeyName, strValue)


        Catch

        End Try

    End Sub

    Public Sub HstInbMsg7(ByVal strULID As String, ByVal strDlvcod As String)

        Dim strSql As String
        Dim strHstInbMsgType As String = "7"
        Dim strHstInbErrCod As String = "A"

        Try
            If strULID.Length = 19 Then
                strULID &= Convert.ToString(Mod10CheckDigit(strULID))
            End If


            strSql = "Insert into HSTINB " & _
                     "(msgtyp,subsit,ulidcd,machid,host_id,mstamp,errcod,ctrl_date,ctrl_user,delvcd) " & _
                    "values ('" & strHstInbMsgType & "','" & _
                    gstrHstInbSubsit & "','" & _
                    strULID & "','" & _
                    gstrHstInbMachId & "','" & _
                    gstrHstInbHost_Id & "'," & _
                    "sysdate ,'" & _
                    strHstInbErrCod & "'," & _
                    "sysdate ,'" & _
                    gstrHstInbHost_Id & "','" & strDlvcod & _
                    "')"


            DBCON2.Execute(strSql)

            WriteLog(gcstrINFO, "Msg7 Sent to RTCIS to DlvCod " & strDlvcod & " for" & Space(1) & strULID)


            System.Threading.Thread.Sleep(500) ' Sleep for 0.5 seconds 




        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try
    End Sub

    Public Sub MoveUlViaHSTINB(ByVal strULID As String, ByVal strToLoc As String)

        Dim strSql As String

        Dim strHstInbMsgType As String
        Dim strHstInbMsgInt As String
        Dim strHstInbTrxCod As String
        Dim strHstInbErrCod As String


        Try


            'Fixed values for HSTINB insert
            strHstInbMsgType = "3"
            strHstInbMsgInt = "M"
            strHstInbTrxCod = "03"
            strHstInbErrCod = "A"


            If strULID.Length = 19 Then
                strULID &= Convert.ToString(Mod10CheckDigit(strULID))
            End If


            strSql = "Insert into HSTINB " & _
                     "(msgtyp,msgint,trxcod,subsit, to_loc,ulidcd,machid,host_id,mstamp,errcod,ctrl_date,ctrl_user) " & _
                    "values ('" & strHstInbMsgType & "','" & _
                    strHstInbMsgInt & "','" & _
                    strHstInbTrxCod & "','" & _
                    gstrHstInbSubsit & "','" & _
                    strToLoc & "','" & _
                    strULID & "','" & _
                    gstrHstInbMachId & "','" & _
                    gstrHstInbHost_Id & "'," & _
                    "sysdate ,'" & _
                    strHstInbErrCod & "'," & _
                    "sysdate ,'" & _
                    gstrHstInbHost_Id & "'" & _
                    ")"


            DBCON2.Execute(strSql)

            WriteLog(gcstrINFO, "ULID Move Sent to RTCIS Location " & strToLoc & " for" & Space(1) & strULID)


            System.Threading.Thread.Sleep(500) ' Sleep for 0.5 seconds 




        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)

        End Try

    End Sub

End Module
