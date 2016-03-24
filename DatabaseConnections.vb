Option Strict On
Option Explicit On

Public NotInheritable Class DatabaseConnections




    Public Function ConnectToDB(ByVal UserName As String, ByVal Password As String) As Integer
        '* If successful, return 0, if error, return -1
        '*
        '* Global Variables Referenced:
        '*       DBCon1
        '*       dbrec1
        '*
        Dim constr As String = Nothing
        Try
            '
            'Define ADO Objects:
            DBCON2 = New ADODB.Connection
            dbrec2 = New ADODB.Recordset

            'Open The connection to Oracle:

            Dim TNS_INFO As String

            TNS_INFO = "(DESCRIPTION=" &
                               "(ADDRESS_LIST=" &
                               "(ADDRESS=(PROTOCOL=TCP)" &
                               "(HOST=" & DBServer & ")" &
                               "(PORT=1521)))" &
                               "(CONNECT_DATA=(SID=" & DBSid & ")" &
                               "(SERVER=DEDICATED)))"

            'This connection requires an entry in tnsnames.ora file for oracle client DB.
            'NOTE: THIS CONNECTION REQUIRES A ENTRY IN TNSNAMES.ORA FILE
            '
            'WITH THAT SAID THE CONSTR BELOW ONLY REQUIRES DBSERVER TO BE PASSED IN BELOW.

            'constr = "Provider=MSDAORA.1; " &
            '            "Data Source=" & TNS_INFO & ";" &
            '            "user id=" & UserName & ";" &
            '            "password=" & Password
            constr = "Provider=MSDAORA.1; " &
                        "Data Source=" & DBServer & ";" &
                        "user id=" & UserName & ";" &
                        "password=" & Password
            'Debug info
            'MsgBox(constr)
            'WriteLog(gcstrError, "DB Constr:[" & constr & "]")

            DBCON2.Open(constr)

            'Define the recordset objects:
            dbrec2 = New ADODB.Recordset

            'Set Return Code:
            ConnectToDB = 0

        Catch e As Exception
            ConnectToDB = -1
            WriteLog(gcstrError, "DB Connection Error: [" & e.Source & "]--[" & e.Message & "]")
            MsgBox(e.Message, MsgBoxStyle.Critical, "WMS DB Connection Error")

        End Try

    End Function



    Public Sub DisplayDatabaseConnectionError(ByVal strDB As String)
        MsgBox("Error encountered when connecting to " & strDB & " Database  " & vbCrLf & vbCrLf & Err.Description, , "Database Connection Error")
    End Sub

    Public Function ConnectToAccessDB(ByVal strCompletePathAndFileName As String) As Integer
        '* If successful, return 0, if error, return -1
        '*
        '* Global Variables Referenced:
        '*       DBConAccess
        '*       dbRecAccess
        '*





        Try
            '
            'Define ADO Objects:
            DBCON1 = New ADODB.Connection
            dbrec1 = New ADODB.Recordset


            strConnectStringMDB = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                          "Data Source=" & strCompletePathAndFileName & ";" & _
                          "User Id=admin;" & _
                          "Password=;"

            'Open The connection to Access:
            DBCON1.Open(strConnectStringMDB)
            'Define the recordset object:
            dbrec1 = New ADODB.Recordset

            'Set Return Code:
            ConnectToAccessDB = 0
            '
        Catch

            ConnectToAccessDB = -1

        End Try

    End Function

    
End Class