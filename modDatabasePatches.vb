Option Explicit On
Option Strict On

Imports System.Reflection.MethodBase    'used to get procedure name for error logging

Module modDatabasePatches

    Public AvailableDatabasePatches() As String = {"V0.47", "V0.60"}
    Public Sub DisplayAvailableDatabasePatches()
        Dim strText As String = String.Empty

        For Each patch As String In AvailableDatabasePatches
            strText &= patch & vbCrLf
        Next

        MessageBox.Show(strText, "Available Database Patches", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub ApplyDatabasePatches(ByVal strAppVersion As String, ByVal bWarnIfPatchDoesNotExist As Boolean)
        If UCase(strAppVersion) = "V0.47" Then
            If Adox_AddColumn_Text("CUST_PALLET", "PLC_USERID", 50, True, False) = True Then
                WriteLog(gcstrINFO, strAppVersion & " Database Patch Applied")
            End If
        ElseIf UCase(strAppVersion) = "V0.60" Then
            If Adox_AddColumn_Text("CUST_PALLET", "BASE_ULID", 50, True, False) = True Then
                WriteLog(gcstrINFO, strAppVersion & " Database Patch Applied - Added CUST_PALLET.BASE_ULID")
            End If
        Else
            If bWarnIfPatchDoesNotExist = True Then
                WriteLog(gcstrError, strAppVersion & " Database Patch Does Not Exist")
            End If
        End If
    End Sub




End Module
