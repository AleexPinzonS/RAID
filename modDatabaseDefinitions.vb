Option Explicit On
Option Strict On

Imports System.Reflection.MethodBase    'used to get procedure name for error logging
Imports System.Reflection
Imports ADOX
Imports ADOX.DataTypeEnum

Module modDatabaseDefinitions
    Dim RequiredDatabaseTables() As String = {"CUST_LINEITEM", "CUST_PALLET", "CUST_SHIPMENT", "DUAL", "MSG16HST", "TRAILER_FPDS"}


    Dim TablesInDatabase() As String
    Dim ColsInDatabase() As String
    Public Sub GetDatabaseTablesfromDB()


        Dim Cn As ADODB.Connection, Cat As ADOX.Catalog, _
                                    objTable As ADOX.Table

        Cn = New ADODB.Connection
        Cat = New ADOX.Catalog

        objTable = New ADOX.Table

        Dim tbl As ADOX.Table       'Each Table in Tables.
        Dim col As ADOX.Column      'Each Column in the Table.
        Dim bShowFieldsToo As Boolean = True
        Dim x As Integer



        Try

            'Open the connection
            Cn.Open(strConnectStringMDB)

            'Open the Catalog
            Cat.ActiveConnection = Cn

            ReDim TablesInDatabase(0)
            DBTableColumnsfromDBRecordCount = 0
            ReDim DBTableColumnsfromDB(0)

            'Loop through the tables only
            For Each tbl In Cat.Tables
                If tbl.Type = "TABLE" Then
                    x += 1
                    ReDim Preserve TablesInDatabase(x)
                    TablesInDatabase(x) = tbl.Name
                    ' WriteLog(gcstrINFO, tbl.Name)
                End If
            Next

            x = 0
            'Loop through the tables and columns
            For Each tbl In Cat.Tables
                ' WriteLog(gcstrINFO, tbl.Name & Space(1) & tbl.Type)
                If tbl.Type = "TABLE" Then
                    If bShowFieldsToo Then
                        'Loop through the columns of the table.
                        For Each col In tbl.Columns


                            x += 1
                            ReDim Preserve ColsInDatabase(x)
                            ColsInDatabase(x) = tbl.Name & "." & col.Name '& "." & col.Type & "." & col.DefinedSize

                            'WriteLog(gcstrINFO, ColsInDatabase(x))

                            DBTableColumnsfromDBRecordCount += 1
                            ReDim Preserve DBTableColumnsfromDB(DBTableColumnsfromDBRecordCount)

                            With DBTableColumnsfromDB(DBTableColumnsfromDBRecordCount)
                                .dbTABLE = tbl.Name
                                .dbCOLUMN = col.Name
                                .dbCOLTYP = col.Type.ToString
                                .dbCOLLEN = col.DefinedSize.ToString

                            End With

                        Next
                    End If
                End If
            Next



            ' clean up objects
            col = Nothing
            tbl = Nothing
            objTable = Nothing
            Cat = Nothing
            Cn.Close()
            Cn = Nothing
        Catch
            ' 'http://allenbrowne.com/func-adox.html#ShowAllTables
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try
    End Sub

    Public Function AnyRequiredDatabaseTablesMissing() As Boolean
        Dim x As Integer
        Dim y As Integer
        Dim strRequiredColsfromApp() As String = Nothing
        Dim bMissingCol As Boolean = False
        Dim bMissingOneOrMoreDBColumns As Boolean = False

        AnyRequiredDatabaseTablesMissing = False

        Try
            GetDatabaseTablesfromDB()

            For x = 0 To RequiredDatabaseTables.GetUpperBound(0)
                If Array.IndexOf(TablesInDatabase, RequiredDatabaseTables(x)) = -1 Then
                    AnyRequiredDatabaseTablesMissing = True
                    WriteLog(gcstrError, "Required WCS Database Table is Missing: " & RequiredDatabaseTables(x))

                Else
                    'check columns

                    Dim bColCheck As Boolean = True
                    Select Case RequiredDatabaseTables(x)
                        Case "MSG16HST"
                            Dim oDBStructure As MSG16HST = Nothing
                            strRequiredColsfromApp = ListDBStructuresFields(oDBStructure)
                        Case "CUST_SHIPMENT"
                            Dim oDBStructure As CUST_SHIPMENT = Nothing
                            strRequiredColsfromApp = ListDBStructuresFields(oDBStructure)
                        Case "CUST_LINEITEM"
                            Dim oDBStructure As CUST_LINEITEM = Nothing
                            strRequiredColsfromApp = ListDBStructuresFields(oDBStructure)
                        Case "CUST_PALLET"
                            Dim oDBStructure As CUST_PALLET = Nothing
                            strRequiredColsfromApp = ListDBStructuresFields(oDBStructure)
                        Case "DUAL"
                            Dim oDBStructure As DUAL = Nothing
                            strRequiredColsfromApp = ListDBStructuresFields(oDBStructure)
                        Case "TRAILER_FPDS"
                            Dim oDBStructure As TRAILER_FPDS = Nothing
                            strRequiredColsfromApp = ListDBStructuresFields(oDBStructure)
                        Case Else
                            bColCheck = False
                    End Select

                    If bColCheck = True Then

                        bMissingCol = False
                        For y = 0 To strRequiredColsfromApp.GetUpperBound(0)
                            If Array.IndexOf(ColsInDatabase, strRequiredColsfromApp(y)) = -1 Then
                                WriteLog(gcstrError, "Required WCS Database Column is Missing: " & strRequiredColsfromApp(y))
                                bMissingCol = True
                                bMissingOneOrMoreDBColumns = True
                            End If
                        Next


                    End If

                End If
            Next

            If AnyRequiredDatabaseTablesMissing = False Then
                WriteLog(gcstrINFO, "---All WCS Database Tables Exist")
            End If

            If bMissingOneOrMoreDBColumns = False Then
                'use for development only
                WriteLog(gcstrINFO, "------All Required Columns Exist in WCS Database Tables")
            End If

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
        End Try

    End Function



    Private Function ListDBStructuresFields(ByVal oStruct As Object) As String()
        Dim myType As Type = oStruct.GetType
        Dim x As Integer
        Dim strText As String
        Dim strFields() As String = Nothing

        For Each myField As Reflection.FieldInfo In myType.GetFields
            If myField.Name = UCase(myField.Name) Then
                x += 1

                strText = myType.Name & "." & myField.Name
                'WriteLog(gcstrINFO, strText)
                ReDim Preserve strFields(x)
                strFields(x) = strText
            End If
        Next

        Return strFields
    End Function

    Public Function Adox_AddColumn_Text(ByVal strTable As String, ByVal strColumn As String, ByVal iSize As Integer, ByVal bNullable As Boolean, ByVal bLogIfNotAdded As Boolean) As Boolean
        'Purpose:   Show how to add fields to a table, and delete them using ADOX.
        Dim cat As New ADOX.Catalog
        Dim tbl As ADOX.Table
        Dim ExistingCol As ADOX.Column
        Dim col As New ADOX.Column
        Dim Cn As ADODB.Connection

        Cn = New ADODB.Connection


        Try
            'Initialize

            'Open the connection
            Cn.Open(strConnectStringMDB)

            'Open the Catalog
            cat.ActiveConnection = Cn

            tbl = cat.Tables(strTable)

            For Each ExistingCol In tbl.Columns
                If UCase(ExistingCol.Name) = UCase(strColumn) Then
                    If bLogIfNotAdded = True Then
                        WriteLog(gcstrINFO, "Database Column NOT Added - Already Exists: " & tbl.Name & "." & ExistingCol.Name)
                    End If

                    Adox_AddColumn_Text = False
                    Exit Function
                End If
            Next


            'Add a new column
            With col
                .Name = strColumn
                .Type = DataTypeEnum.adVarWChar
                .DefinedSize = iSize
                .Attributes = ColumnAttributesEnum.adColNullable
            End With
            tbl.Columns.Append(col)

            Adox_AddColumn_Text = True
            WriteLog(gcstrINFO, "Database Column Added: " & tbl.Name & "." & col.Name)

        Catch
            WriteLog(gcstrError, GetCurrentMethod.Name() & Space(1) & Err.Description)
            Adox_AddColumn_Text = False
        Finally
            'Clean up
            col = Nothing
            tbl = Nothing
            cat = Nothing

        End Try
    End Function

    Public Function CreateTable(ByVal strTable As String) As Boolean
        ' This code adds a single-field Primary key
        '
        Dim Cn As ADODB.Connection, Cat As ADOX.Catalog, objTable As ADOX.Table

        Cn = New ADODB.Connection
        Cat = New ADOX.Catalog
        objTable = New ADOX.Table
        Try

            'Open the connection

            Cn.Open(strConnectStringMDB)

            'Open the Catalog
            Cat.ActiveConnection = Cn

            'Create the table
            objTable.Name = strTable

            'Append the newly created table to the Tables Collection
            Cat.Tables.Append(objTable)
            CreateTable = True
        Catch
            CreateTable = False
        Finally

            ' clean up objects

            objTable = Nothing
            Cat = Nothing
            Cn.Close()
            Cn = Nothing
        End Try
    End Function

    ''http://allenbrowne.com/func-adox.html#ShowAllTables

End Module
