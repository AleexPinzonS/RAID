Module modRAIDTypes
    'use of all caps indicates that the field should be mapped to a database field
    Public RTCISInventoryRecordCount As Integer
    Public RTCISInventory() As AllInventoryType
    Public ASRSInventoryRecordCount As Integer
    Public ASRSInventory() As AllInventoryType
    Public Structure AllInventoryType
        Dim ULID As String
        Dim LOCATN As String
        Dim ITMCOD As String
        Dim CTLGRP As String
        Dim QASTAT As String
        Dim ULPALL As String
        Dim SHIPID As String
        Dim MatchingIndex As Integer
    End Structure
    Public StagedUlsInWMSRecordCount As Integer
    Public StagedUlsInWMS() As StagedUlsInWMSType
    Public Structure StagedUlsInWMSType
        Dim ULID As String
        Dim SLOT As String
    End Structure
    Public ULsOnFPDSRecordCount As Integer
    Public ULsOnFPDS() As ULsOnFPDSType
    Public Structure ULsOnFPDSType
        Dim ULID As String
        Dim LOCATN As String
        Dim UL_STACOD As String
        Dim CTRL_DATE As String
        Dim BASE_ULID As String
        Dim Message5Only As Boolean
    End Structure
    Public UlpallRecordCount As Integer
    Public Ulpall() As UlpallType
    Public Structure UlpallType
        Dim ULPALL As String
        Dim PLCPAL As String
    End Structure
    Public UlInfoFromWMSRecordCount As Integer
    Public UlInfoFromWMS() As UlInfoFromWMSType
    Public Structure UlInfoFromWMSType
        Dim BRAND_CODE As String
        Dim BRAND_DESC As String
        Dim CODE_DATE As String
        Dim PALLET_TYPE As String
        Dim HOLD_STATUS As String
        Dim BASE_ULID As String
    End Structure
    Public ULsWithMsg5RecordCount As Integer
    Public ULsWithMsg5() As ULsWithMsg5Type
    Public Structure ULsWithMsg5Type
        Dim CUST_ID As String
    End Structure
    Public ASRSAvailableInventorySummaryRecordCount As Integer
    Public ASRSAvailableInventorySummary() As ASRSAvailableInventorySummaryType
    Public Structure ASRSAvailableInventorySummaryType
        Dim BRAND_CODE As String
        Dim PALLET_TYPE As String
        Dim ULIDCOUNT As String
        Dim HOLD_STATUS As String
    End Structure
    Public ULsNeedingMsg7RecordCount As Integer
    Public ULsNeedingMsg7() As ULsNeedingMsg7Type
    Public Structure ULsNeedingMsg7Type
        Dim CTRL_DATE As String
        Dim CUST_ID As String
        Dim ACTIV_INPUT_LOCATION As String
        Dim Retro_Status As String
        Dim Retro_Loc As String
        Dim BASE_ULID As String
    End Structure
    Public UlsASRSInfeedRecordCount As Integer
    Public UlsASRSInfeed() As CUST_PALLET
    Public Structure CUST_PALLET
        Dim CUST_ID As String
        Dim CTRL_DATE As String
        Dim ACTIV_INPUT_LOCATION As String
        Dim BRAND_CODE As String
        Dim BRAND_DESC As String
        Dim CODE_DATE As String
        Dim PALLET_TYPE As String
        Dim HOLD_STATUS As String
        Dim RETRO_STATUS As String
        Dim RETRO_LOC As String
        Dim SHIP_ID As String
        Dim PLC_USERID As String
        Dim User_Id As String
        Dim Message_Timestamp As String
        Dim Item_group As String
        Dim BASE_ULID As String
        Dim Case_quantity As String
        Dim Partial_flag As String
    End Structure
    Public Msg16_History_RecordCount As Integer
    Public Msg16_History() As MSG16HST
    Public Structure MSG16HST
        Dim CUST_ID As String
        Dim CTRL_DATE As String
        Dim CODE_DATE As String
        Dim HOLD_STATUS As String
        Dim BRAND_CODE As String
    End Structure
    Public Msg13_Cust_LineItem_RecordCount As Integer
    Public Msg13_Cust_LineItem() As CUST_LINEITEM
    Public Msg13_Cust_LineItem_Aggregate_RecordCount As Integer
    Public Msg13_Cust_LineItem_Aggregate() As CUST_LINEITEM
    Public Shipment_Cust_LineItem_Aggregate_RecordCount As Integer
    Public Shipment_Cust_LineItem_Aggregate() As CUST_LINEITEM
    Public Structure CUST_LINEITEM
        Dim SHIP_ID As String
        Dim LINE_ID As String
        Dim SEQUENCE As String
        Dim BRAND_CODE As String
        Dim CODE_DATE As String
        Dim PAL_TYPE As String
        Dim ITEMCLASS As String
        Dim QUANTITY As String
        Dim RESERVED As String
        Dim SUPPLIED As String
        Dim STAGED As String
        Dim SELECT_FLAG As String
        Dim STACK_FLAG As String
        Dim CUST_ID As String
        Dim PICK_QU As String
        Dim RETRO_STATUS As String
        Dim Load_Status As String
        Dim Slot As String
        Dim Signon As String
        Dim Retro_Loc As String
        Dim StagedPalletType As String
        Dim Disposition As String
        Dim Ship_type As String
    End Structure
    Public Msg21_Header_RecordCount As Integer
    Public Msg21_Header() As Msg21_Header_Type
    Public Structure Msg21_Header_Type
        Dim SHIP_ID As String
        Dim DISPOSITION As String '
        Dim APP_DATETIME As String
        Dim RETRO_STATUS As String '
        Dim LOAD_STATUS As String '
        Dim SLOT As String '
        Dim SHIP_TYPE As String '
    End Structure
    Public Msg21_Detail_RecordCount As Integer
    Public Msg21_DEtail() As CUST_LINEITEM
    Public Msg15_Detail_RecordCount As Integer
    Public Msg15_DEtail() As CUST_LINEITEM

    Public ULStatusGrouped_RecordCount As Integer
    Public ULStatusGrouped() As ULStatusGrouped_Type
    Public Structure ULStatusGrouped_Type
        Dim ULCount As String
        Dim Retro_Status As String
    End Structure

    Public AllInputConveyorRecordCount As Integer
    Public AllInputConveyor() As TRAILER_FPDS
    Public Trailer_Hdr_FPDSRecordCount As Integer
    Public Trailer_Hdr_Fpds() As TRAILER_FPDS
    Public Structure TRAILER_FPDS
        Dim MESSAGE_TYPE As String
        Dim TRAILER_NUMBER As String
        Dim TRUCK_LINE As String
        Dim LINE_COUNT As String
        Dim CTRL_DATE As String
        Dim ACTIV_INPUT_LOCATION As String
    End Structure
    Public DBTableColumnsfromDBRecordCount As Integer
    Public DBTableColumnsAppRequiredDBRecordCount As Integer
    Public DBTableColumnsfromDB() As DBTableColumns_Type
    Public DBTableColumnsAppRequired() As DBTableColumns_Type
    Public Structure DBTableColumns_Type
        Dim dbTABLE As String
        Dim dbCOLUMN As String
        Dim dbCOLTYP As String
        Dim dbCOLLEN As String
    End Structure

    'structures used for validation only and not programatically
    Public Structure DUAL
        Dim DUAL As String
    End Structure

    Public Structure CUST_SHIPMENT
        Dim CUST_SHIPMENT As String
        Dim SHIP_TYPE As String
        Dim DISPOSITION As String
        Dim USER_ID As String
        Dim PRIORITY As String
        Dim APP_DATETIME As String
        Dim LOAD_STATUS As String
        Dim RETRO_STATUS As String
        Dim SLOT As String '
        Dim RECEIVED_DATETIME As String
        Dim SiGNON As String
        Dim NEXTLEVELID As String
    End Structure

    Public Structure TRAILER_MOVEMENT
        Dim TRUCK_LINE As String
        Dim TRAILER_ID As String
        Dim TRACTOR_ID As String
        Dim TYPE As String
        Dim LENGTH As String
        Dim WIDTH As String
        Dim HEIGHT As String
        Dim EMPTY_WEIGHT As String
        Dim FULL_WEIGHT As String
        Dim EST_WEIGHT As String
        Dim TEMP_CODE As String
        Dim DRIVER_NAME As String
        Dim LIC_PLATE_NUM As String
        Dim LIC_PLATE_STATE As String
        Dim USABLE As String
        Dim UNUSABLE_REASON As String
        Dim EMPTY As String
        Dim ORIGIN As String
        Dim CONTENTS As String
        Dim FREIGHT_AMOUNT As String
        Dim FREIGHT_CURRENCY As String
        Dim SHIPID As String
        Dim RRUNMB As String
        Dim INVNUM As String
        Dim SITNAM As String
        Dim BUILDING As String
        Dim BUILDING_LIST As String
        Dim LOCATION As String
        Dim WCS_TRANSIT_NUM As String
    End Structure
End Module
