Option Explicit On
Option Strict On

Public Module modApplicationDefinitions

    'basic strings for any application
    Public Const gcstrError As String = "ERROR"
    Public Const gcstrINFO As String = "INFO"
    Public Const gcstrNA As String = "NA"
    Public Const gcstrUpdate As String = "Update"
    Public Const gcstrInsert As String = "Insert"
    Public Const gcstrDelete As String = "Delete"
    Public Const gcstrProcessed As String = "Processed"
    Public Const gcstrUNEXPECTED As String = "UNEXPECTED"
    Public Const gcstrACCESS As String = "ACCESS"


    'characters as strings
    Public Const gcstrComma As String = ","
    Public Const gcstrApos As String = "'"
    Public Const gcStrZero As String = "0"
    Public Const gcstrY As String = "Y"
    Public Const gcstrN As String = "N"


    'characters
    Public Const gcCharComma As Char = ","c
    Public Const gcCharZero As Char = "0"c
    Public Const gcCharSpace As Char = " "c


    'misc for socket apps
    Public Const gcstrMessageHeaderElement As String = "MessageHeader"
    Public Const gcstrOracleDateTimeFormat As String = "yyyyMMdd HH:mm:ss"
    Public Const gcstrLastXMLSentFileName As String = "LastXMLSent.txt"


    'Application Specific 
    Public Const gcstrSet_Carton_Status As String = "Set_Carton_Status"
    Public Const gcstrSet_Location_Status As String = "SET_LOCATION_STATUS"
    Public Const gcstrIgnore_Error As String = "IGNORE_ERROR"
    Public Const gcstrMsg20CancelText As String = "CANCLD"
    Public Const gcstrMsg26StopText As String = "STPSTG"
    Public Const gcstrShipmentRequest As String = "SR"
    Public Const gcstrPORequest As String = "CR"

    'sumamry screen
    Public Const gcstrCartonPathError As String = "E"
    Public Const gcstrCartonPathGood As String = "G"

End Module
