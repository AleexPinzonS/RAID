Option Strict On
Option Explicit On
Friend NotInheritable Class ini



    'Declarations to read ini file
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpSectionName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFilename As String) As Integer

    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpSectionName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFilename As String) As Integer

    Public Function ProfileGetItem(ByRef lpSectionName As String, ByRef lpKeyName As String, ByRef defaultValue As String, ByRef inifile As String) As String

        'Retrieves a value from an ini file corresponding
        'to the section and key name passed.

        Dim success As Integer
        Dim nSize As Integer
        Dim ret As String

        'call the API with the parameters passed. The return value is the length of the
        'string in ret, including the terminating null. If a default value was passed,
        'and the section or key name are not in the file, that value is returned. If no
        'default value was passed (vbnullstring), then success will = 0 if not found.

        'Pad a string large enough to hold the data.
        ret = Space(2048)
        nSize = Len(ret)
        success = GetPrivateProfileString(lpSectionName, lpKeyName, defaultValue, ret, nSize, inifile)

        If success <> 0 Then
            ProfileGetItem = Left(ret, success)
        Else
            ProfileGetItem = defaultValue
        End If

    End Function


    Public Sub ProfileSaveItem(ByRef lpSectionName As String, ByRef lpKeyName As String, ByRef lpValue As String, ByRef lpFilename As String)

        'This function saves the passed value to the file,
        'under the section and key names specified.
        'If the ini file does not exist, it is created.
        'If the section does not exist, it is created.
        'If the key name does not exist, it is created.
        'If the key name exists, its value is replaced.


        Call WritePrivateProfileString(lpSectionName, lpKeyName, lpValue, lpFilename)

    End Sub
End Class