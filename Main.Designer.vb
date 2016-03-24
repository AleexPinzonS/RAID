<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.tmrRefreshLog = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DTLDriverSendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HostInboundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfeedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualOutputRequestsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutboundStagingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SocketCommunicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SocketListeningPortsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllProcessesInAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetMessageCountersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditXMLBeforeSendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckDBForRequiredTablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisplayDatabasePatchVersionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApplyDatabasePatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearShipmentIDFromDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearULIDFromDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteOldLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCust_PalletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCUSTSHIPMENTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCUSTLINEITEMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMsg16HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteTRAILERFPDSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurgeCompletedShipmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCompletedWithdrawsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendHeartbeatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendHeartbeatAutomaticallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendXMLFromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XMLEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WMSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateEventsInICToSCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateASRSSessionIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateRTCSESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServiceStepsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmrBlink = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelRefresh = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblWait = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelHeartBeatOn = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusSpacer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblToolStripWorking = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLblConnections = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.butMsg21_Header_Advance = New System.Windows.Forms.Button()
        Me.butMsg21_Header_SelectAll = New System.Windows.Forms.Button()
        Me.butMsg21_Header_DeSelectAll = New System.Windows.Forms.Button()
        Me.linMain = New System.Windows.Forms.Panel()
        Me.tmrHeartbeat = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtInfeedRestrictToCtlgrp = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtInfeedRestrictToUlPall = New System.Windows.Forms.TextBox()
        Me.txtInfeedRestrictToItem = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.flxGrid1 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnInfeedAutoScanOff = New System.Windows.Forms.Button()
        Me.btnInfeedAutoScanOn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdInfeedAdvance = New System.Windows.Forms.Button()
        Me.cmdInfeedSelectAll = New System.Windows.Forms.Button()
        Me.cmdInfeedDeSelectAll = New System.Windows.Forms.Button()
        Me.cmdRefreshInfeed = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpCartonControl = New System.Windows.Forms.GroupBox()
        Me.cmdASRSInfeedAdvance = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnASRSInfeedAutoScanOn = New System.Windows.Forms.Button()
        Me.btnASRSInfeedAutoScanOff = New System.Windows.Forms.Button()
        Me.cmdASRSInfeedSelectAll = New System.Windows.Forms.Button()
        Me.cmdASRSInfeedDeSelectAll = New System.Windows.Forms.Button()
        Me.butRefreshASRSInfeed = New System.Windows.Forms.Button()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.butRereshAsrsInventorySummary = New System.Windows.Forms.Button()
        Me.flxGrid2 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.flxGrid3 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.grpPickControl = New System.Windows.Forms.GroupBox()
        Me.butRefreshNeedingMsg7 = New System.Windows.Forms.Button()
        Me.butMsg7Advance = New System.Windows.Forms.Button()
        Me.butMsg7SelectAll = New System.Windows.Forms.Button()
        Me.butMsg7DeSelectAll = New System.Windows.Forms.Button()
        Me.flxGrid11 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtRequestNextProdOrder_DeliveryLocation = New System.Windows.Forms.TextBox()
        Me.butRequestNextProdOrder = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMsg21_MOT_CODE = New System.Windows.Forms.TextBox()
        Me.butMsg21_Send = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.butMsg21AutoSendOff = New System.Windows.Forms.Button()
        Me.butMsg21AutoSendOn = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.flxGrid4 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.flxGrid8 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.butMsg22AutoSendOff = New System.Windows.Forms.Button()
        Me.butMsg22AutoSendOn = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.lblSlotMaxAlarm = New System.Windows.Forms.Label()
        Me.butMsg21CheckInventory = New System.Windows.Forms.Button()
        Me.lblRaid_Msg23_SelectedDisposition = New System.Windows.Forms.Label()
        Me.lblRaid_SelectedLoadStatus = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.butMsg21_Detail_GetData = New System.Windows.Forms.Button()
        Me.txtlblRaid_Msg23_SelectedSlot = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRaid_SelectedShipidDisplay = New System.Windows.Forms.Label()
        Me.lblRaid_SelectedShipid = New System.Windows.Forms.Label()
        Me.butMsg21_Detail_Advance = New System.Windows.Forms.Button()
        Me.butMsg21_Detail_SelectAll = New System.Windows.Forms.Button()
        Me.butMsg21_Detail_DeSelectAll = New System.Windows.Forms.Button()
        Me.butMsg21_GetData = New System.Windows.Forms.Button()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.flxGrid10 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.flxGrid9 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.txtShipULPickUp_Load_Flag = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblRaid_SelectedRetroStatus_Msg24 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblRaid_SelectedLoadStatus_Msg24 = New System.Windows.Forms.Label()
        Me.lblRaidMsg15ShipId = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.butMsg15Advance = New System.Windows.Forms.Button()
        Me.butMsg15SelectAll = New System.Windows.Forms.Button()
        Me.butMsg15DeselectAll = New System.Windows.Forms.Button()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.butMsg24AutoSendOff = New System.Windows.Forms.Button()
        Me.butMsg24AutoSendOn = New System.Windows.Forms.Button()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.butMsg24Advance = New System.Windows.Forms.Button()
        Me.butMsg24_Header_SelectAll = New System.Windows.Forms.Button()
        Me.butMsg24_Header_DeSelectAll = New System.Windows.Forms.Button()
        Me.butMsg24_GetData = New System.Windows.Forms.Button()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.flxGrid5 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.butMsg16_GetData = New System.Windows.Forms.Button()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.butMsg11_Send = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMsg11_Tech_Group = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMsg11_RDT_Message = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.txtUtil_DstLoc = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtUtil_Ulid = New System.Windows.Forms.TextBox()
        Me.butUtil_MoveUl = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.flxGrid6 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.flxGrid7 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.butMsg14GetData = New System.Windows.Forms.Button()
        Me.butMsg14Advance = New System.Windows.Forms.Button()
        Me.butMsg14SelectAll = New System.Windows.Forms.Button()
        Me.butMsg14DeselectAll = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.butMsg13AutoScanOff = New System.Windows.Forms.Button()
        Me.butMsg13AutoScanOn = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.butMsg13Advance = New System.Windows.Forms.Button()
        Me.butMsg13SelectAll = New System.Windows.Forms.Button()
        Me.butMsg13RefreshData = New System.Windows.Forms.Button()
        Me.butMsg13DeSelectAll = New System.Windows.Forms.Button()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.flxGrid12 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.butReconcile = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtReconcileItmCod = New System.Windows.Forms.TextBox()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.lblE10Title = New System.Windows.Forms.Label()
        Me.lblG10Title = New System.Windows.Forms.Label()
        Me.lblE10 = New System.Windows.Forms.Label()
        Me.linE10 = New System.Windows.Forms.Panel()
        Me.linG10 = New System.Windows.Forms.Panel()
        Me.lblG10 = New System.Windows.Forms.Label()
        Me.lblE09Title = New System.Windows.Forms.Label()
        Me.lblG09Title = New System.Windows.Forms.Label()
        Me.lblE09 = New System.Windows.Forms.Label()
        Me.linE09 = New System.Windows.Forms.Panel()
        Me.linG09 = New System.Windows.Forms.Panel()
        Me.lblG09 = New System.Windows.Forms.Label()
        Me.butGetGraphicalData = New System.Windows.Forms.Button()
        Me.lblE08Title = New System.Windows.Forms.Label()
        Me.lblE07Title = New System.Windows.Forms.Label()
        Me.lblE06Title = New System.Windows.Forms.Label()
        Me.lblE05Title = New System.Windows.Forms.Label()
        Me.lblE04Title = New System.Windows.Forms.Label()
        Me.lblE03Title = New System.Windows.Forms.Label()
        Me.lblE02Title = New System.Windows.Forms.Label()
        Me.lblE01Title = New System.Windows.Forms.Label()
        Me.lblG08Title = New System.Windows.Forms.Label()
        Me.lblG07Title = New System.Windows.Forms.Label()
        Me.lblG06Title = New System.Windows.Forms.Label()
        Me.lblG05Title = New System.Windows.Forms.Label()
        Me.lblG04Title = New System.Windows.Forms.Label()
        Me.lblG03Title = New System.Windows.Forms.Label()
        Me.lblG02Title = New System.Windows.Forms.Label()
        Me.lblG01Title = New System.Windows.Forms.Label()
        Me.lblE08 = New System.Windows.Forms.Label()
        Me.lblE07 = New System.Windows.Forms.Label()
        Me.lblE06 = New System.Windows.Forms.Label()
        Me.lblE05 = New System.Windows.Forms.Label()
        Me.lblE04 = New System.Windows.Forms.Label()
        Me.lblE03 = New System.Windows.Forms.Label()
        Me.lblE02 = New System.Windows.Forms.Label()
        Me.lblE01 = New System.Windows.Forms.Label()
        Me.linE08 = New System.Windows.Forms.Panel()
        Me.linE07 = New System.Windows.Forms.Panel()
        Me.linE06 = New System.Windows.Forms.Panel()
        Me.linE05 = New System.Windows.Forms.Panel()
        Me.linE04 = New System.Windows.Forms.Panel()
        Me.linE03 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.linE02 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.linE01 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.linG08 = New System.Windows.Forms.Panel()
        Me.lblG08 = New System.Windows.Forms.Label()
        Me.linG07 = New System.Windows.Forms.Panel()
        Me.lblG07 = New System.Windows.Forms.Label()
        Me.linG06 = New System.Windows.Forms.Panel()
        Me.lblG06 = New System.Windows.Forms.Label()
        Me.linG05 = New System.Windows.Forms.Panel()
        Me.lblG05 = New System.Windows.Forms.Label()
        Me.linG04 = New System.Windows.Forms.Panel()
        Me.lblG04 = New System.Windows.Forms.Label()
        Me.linG03 = New System.Windows.Forms.Panel()
        Me.lblG03 = New System.Windows.Forms.Label()
        Me.linG02 = New System.Windows.Forms.Panel()
        Me.lblG02 = New System.Windows.Forms.Label()
        Me.linG01 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblG01 = New System.Windows.Forms.Label()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpFPDSControl = New System.Windows.Forms.GroupBox()
        Me.cmdFPDSAdvance = New System.Windows.Forms.Button()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.btnFPDSAutoScanOn = New System.Windows.Forms.Button()
        Me.btnFPDSAutoScanOff = New System.Windows.Forms.Button()
        Me.cmdFPDSSelectAll = New System.Windows.Forms.Button()
        Me.cmdFPDSDeSelectAll = New System.Windows.Forms.Button()
        Me.butRefreshFPDS = New System.Windows.Forms.Button()
        Me.flxGrid13 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.butConveyorInputDelete = New System.Windows.Forms.Button()
        Me.butConveyorInputSelectAll = New System.Windows.Forms.Button()
        Me.butConveyorInputDeselectAll = New System.Windows.Forms.Button()
        Me.butRefreshConveyorInput = New System.Windows.Forms.Button()
        Me.flxGrid14 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.butFillStagedUlsInWMS = New System.Windows.Forms.Button()
        Me.flxGrid15 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.TabPage13 = New System.Windows.Forms.TabPage()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtMsg7Dlvloc = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtMsg7ULID = New System.Windows.Forms.TextBox()
        Me.butMsg7 = New System.Windows.Forms.Button()
        Me.TabPage14 = New System.Windows.Forms.TabPage()
        Me.tabCtlTrailer = New System.Windows.Forms.TabControl()
        Me.tabPgAutoCheckin = New System.Windows.Forms.TabPage()
        Me.grpBxTrailerCkin = New System.Windows.Forms.GroupBox()
        Me.txtTrailer = New System.Windows.Forms.TextBox()
        Me.lblTrailerID = New System.Windows.Forms.Label()
        Me.btnTrlCkin = New System.Windows.Forms.Button()
        Me.TabPage16 = New System.Windows.Forms.TabPage()
        Me.grpBxTrlCkout = New System.Windows.Forms.GroupBox()
        Me.txtTrlCo_LicPlateState = New System.Windows.Forms.TextBox()
        Me.lblLicPlateState = New System.Windows.Forms.Label()
        Me.txtTrlCo_LicPlateNum = New System.Windows.Forms.TextBox()
        Me.lblLicPlateNum = New System.Windows.Forms.Label()
        Me.txtTrlCo_DrvName = New System.Windows.Forms.TextBox()
        Me.lblDrvNam = New System.Windows.Forms.Label()
        Me.dtpckrTrlCo_CarArrDt = New System.Windows.Forms.DateTimePicker()
        Me.txtTrlCo_TrlCoCarArrDt = New System.Windows.Forms.TextBox()
        Me.lblCarArrDt = New System.Windows.Forms.Label()
        Me.txtTrlCo_TractorId = New System.Windows.Forms.TextBox()
        Me.lbltrlCoTractorId = New System.Windows.Forms.Label()
        Me.txtTrlCo_TrkLin = New System.Windows.Forms.TextBox()
        Me.lblTrlCoTrlkin = New System.Windows.Forms.Label()
        Me.txtTrlCo_trlnum = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.btnTrlCkout = New System.Windows.Forms.Button()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkAutoDataRefresh = New System.Windows.Forms.CheckBox()
        Me.butRefresh = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.RichTextBox()
        Me.chkAutoRefresh = New System.Windows.Forms.CheckBox()
        Me.lblMsgOutCount = New System.Windows.Forms.Label()
        Me.lblMsgInCount = New System.Windows.Forms.Label()
        Me.lblLastMsgOutTimeStamp = New System.Windows.Forms.Label()
        Me.lblFirstMsgOutTimeStamp = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblLastMsgInTimeStamp = New System.Windows.Forms.Label()
        Me.lblFirstMsgInTimeStamp = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tmrAutoScan = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox19.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.flxGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpCartonControl.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.flxGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flxGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPickControl.SuspendLayout()
        CType(Me.flxGrid11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.flxGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flxGrid8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.flxGrid10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.flxGrid9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.flxGrid5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.flxGrid6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flxGrid7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        CType(Me.flxGrid12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage10.SuspendLayout()
        Me.linE03.SuspendLayout()
        Me.linE02.SuspendLayout()
        Me.linE01.SuspendLayout()
        Me.linG01.SuspendLayout()
        Me.TabPage11.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.grpFPDSControl.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        CType(Me.flxGrid13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox17.SuspendLayout()
        CType(Me.flxGrid14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage12.SuspendLayout()
        CType(Me.flxGrid15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage13.SuspendLayout()
        Me.TabPage14.SuspendLayout()
        Me.tabCtlTrailer.SuspendLayout()
        Me.tabPgAutoCheckin.SuspendLayout()
        Me.grpBxTrailerCkin.SuspendLayout()
        Me.TabPage16.SuspendLayout()
        Me.grpBxTrlCkout.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrRefreshLog
        '
        Me.tmrRefreshLog.Enabled = True
        Me.tmrRefreshLog.Interval = 2000
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationToolStripMenuItem, Me.ControlToolStripMenuItem, Me.DatabaseUpdatesToolStripMenuItem, Me.LogsToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.WMSToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1284, 24)
        Me.MenuStrip1.TabIndex = 31
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainToolStripMenuItem, Me.DTLDriverSendToolStripMenuItem, Me.HostInboundToolStripMenuItem, Me.InfeedToolStripMenuItem, Me.ManualOutputRequestsToolStripMenuItem, Me.OutboundStagingToolStripMenuItem, Me.SocketCommunicationToolStripMenuItem, Me.SocketListeningPortsToolStripMenuItem})
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.ConfigurationToolStripMenuItem.Text = "Configuration"
        '
        'MainToolStripMenuItem
        '
        Me.MainToolStripMenuItem.Name = "MainToolStripMenuItem"
        Me.MainToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.MainToolStripMenuItem.Text = "Main"
        '
        'DTLDriverSendToolStripMenuItem
        '
        Me.DTLDriverSendToolStripMenuItem.Name = "DTLDriverSendToolStripMenuItem"
        Me.DTLDriverSendToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.DTLDriverSendToolStripMenuItem.Text = "DTL Driver Send"
        '
        'HostInboundToolStripMenuItem
        '
        Me.HostInboundToolStripMenuItem.Name = "HostInboundToolStripMenuItem"
        Me.HostInboundToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.HostInboundToolStripMenuItem.Text = "Host Inbound"
        '
        'InfeedToolStripMenuItem
        '
        Me.InfeedToolStripMenuItem.Name = "InfeedToolStripMenuItem"
        Me.InfeedToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.InfeedToolStripMenuItem.Text = "Infeed"
        '
        'ManualOutputRequestsToolStripMenuItem
        '
        Me.ManualOutputRequestsToolStripMenuItem.Name = "ManualOutputRequestsToolStripMenuItem"
        Me.ManualOutputRequestsToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ManualOutputRequestsToolStripMenuItem.Text = "Manual Output Requests"
        '
        'OutboundStagingToolStripMenuItem
        '
        Me.OutboundStagingToolStripMenuItem.Name = "OutboundStagingToolStripMenuItem"
        Me.OutboundStagingToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.OutboundStagingToolStripMenuItem.Text = "Outbound Staging"
        '
        'SocketCommunicationToolStripMenuItem
        '
        Me.SocketCommunicationToolStripMenuItem.Name = "SocketCommunicationToolStripMenuItem"
        Me.SocketCommunicationToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SocketCommunicationToolStripMenuItem.Text = "Socket Communication"
        '
        'SocketListeningPortsToolStripMenuItem
        '
        Me.SocketListeningPortsToolStripMenuItem.Name = "SocketListeningPortsToolStripMenuItem"
        Me.SocketListeningPortsToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SocketListeningPortsToolStripMenuItem.Text = "Socket Listening Ports"
        '
        'ControlToolStripMenuItem
        '
        Me.ControlToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllProcessesInAutoToolStripMenuItem, Me.ResetMessageCountersToolStripMenuItem, Me.EditXMLBeforeSendToolStripMenuItem, Me.PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem})
        Me.ControlToolStripMenuItem.Name = "ControlToolStripMenuItem"
        Me.ControlToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ControlToolStripMenuItem.Text = "Control"
        '
        'AllProcessesInAutoToolStripMenuItem
        '
        Me.AllProcessesInAutoToolStripMenuItem.CheckOnClick = True
        Me.AllProcessesInAutoToolStripMenuItem.Name = "AllProcessesInAutoToolStripMenuItem"
        Me.AllProcessesInAutoToolStripMenuItem.Size = New System.Drawing.Size(305, 22)
        Me.AllProcessesInAutoToolStripMenuItem.Text = "All Processes in Auto"
        '
        'ResetMessageCountersToolStripMenuItem
        '
        Me.ResetMessageCountersToolStripMenuItem.Name = "ResetMessageCountersToolStripMenuItem"
        Me.ResetMessageCountersToolStripMenuItem.Size = New System.Drawing.Size(305, 22)
        Me.ResetMessageCountersToolStripMenuItem.Text = "Reset Message Counters"
        '
        'EditXMLBeforeSendToolStripMenuItem
        '
        Me.EditXMLBeforeSendToolStripMenuItem.Name = "EditXMLBeforeSendToolStripMenuItem"
        Me.EditXMLBeforeSendToolStripMenuItem.Size = New System.Drawing.Size(305, 22)
        Me.EditXMLBeforeSendToolStripMenuItem.Text = "User Edit XML Before Send"
        '
        'PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem
        '
        Me.PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem.Name = "PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem"
        Me.PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem.Size = New System.Drawing.Size(305, 22)
        Me.PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem.Text = "Prevent DB Updates After Message Advance"
        '
        'DatabaseUpdatesToolStripMenuItem
        '
        Me.DatabaseUpdatesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckDBForRequiredTablesToolStripMenuItem, Me.DisplayDatabasePatchVersionsToolStripMenuItem, Me.ApplyDatabasePatchToolStripMenuItem})
        Me.DatabaseUpdatesToolStripMenuItem.Name = "DatabaseUpdatesToolStripMenuItem"
        Me.DatabaseUpdatesToolStripMenuItem.Size = New System.Drawing.Size(113, 20)
        Me.DatabaseUpdatesToolStripMenuItem.Text = "Database Updates"
        '
        'CheckDBForRequiredTablesToolStripMenuItem
        '
        Me.CheckDBForRequiredTablesToolStripMenuItem.Name = "CheckDBForRequiredTablesToolStripMenuItem"
        Me.CheckDBForRequiredTablesToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.CheckDBForRequiredTablesToolStripMenuItem.Text = "Check DB for Required Tables"
        '
        'DisplayDatabasePatchVersionsToolStripMenuItem
        '
        Me.DisplayDatabasePatchVersionsToolStripMenuItem.Name = "DisplayDatabasePatchVersionsToolStripMenuItem"
        Me.DisplayDatabasePatchVersionsToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.DisplayDatabasePatchVersionsToolStripMenuItem.Text = "Display Database Patch Versions"
        '
        'ApplyDatabasePatchToolStripMenuItem
        '
        Me.ApplyDatabasePatchToolStripMenuItem.Name = "ApplyDatabasePatchToolStripMenuItem"
        Me.ApplyDatabasePatchToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.ApplyDatabasePatchToolStripMenuItem.Text = "Apply Database Patch"
        '
        'LogsToolStripMenuItem
        '
        Me.LogsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearShipmentIDFromDatabaseToolStripMenuItem, Me.ClearULIDFromDatabaseToolStripMenuItem, Me.DeleteOldLogsToolStripMenuItem, Me.DeleteCust_PalletToolStripMenuItem, Me.DeleteCUSTSHIPMENTToolStripMenuItem, Me.DeleteCUSTLINEITEMToolStripMenuItem, Me.DeleteMsg16HistoryToolStripMenuItem, Me.DeleteTRAILERFPDSToolStripMenuItem, Me.PurgeCompletedShipmentsToolStripMenuItem, Me.DeleteCompletedWithdrawsToolStripMenuItem, Me.RemoveAToolStripMenuItem})
        Me.LogsToolStripMenuItem.Name = "LogsToolStripMenuItem"
        Me.LogsToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.LogsToolStripMenuItem.Text = "Maintenance"
        '
        'ClearShipmentIDFromDatabaseToolStripMenuItem
        '
        Me.ClearShipmentIDFromDatabaseToolStripMenuItem.Name = "ClearShipmentIDFromDatabaseToolStripMenuItem"
        Me.ClearShipmentIDFromDatabaseToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.ClearShipmentIDFromDatabaseToolStripMenuItem.Text = "Clear Shipment ID from Database"
        '
        'ClearULIDFromDatabaseToolStripMenuItem
        '
        Me.ClearULIDFromDatabaseToolStripMenuItem.Name = "ClearULIDFromDatabaseToolStripMenuItem"
        Me.ClearULIDFromDatabaseToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.ClearULIDFromDatabaseToolStripMenuItem.Text = "Clear ULID from Database"
        '
        'DeleteOldLogsToolStripMenuItem
        '
        Me.DeleteOldLogsToolStripMenuItem.Name = "DeleteOldLogsToolStripMenuItem"
        Me.DeleteOldLogsToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.DeleteOldLogsToolStripMenuItem.Text = "Delete Old Logs"
        '
        'DeleteCust_PalletToolStripMenuItem
        '
        Me.DeleteCust_PalletToolStripMenuItem.Name = "DeleteCust_PalletToolStripMenuItem"
        Me.DeleteCust_PalletToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.DeleteCust_PalletToolStripMenuItem.Text = "Delete CUST_PALLET"
        '
        'DeleteCUSTSHIPMENTToolStripMenuItem
        '
        Me.DeleteCUSTSHIPMENTToolStripMenuItem.Name = "DeleteCUSTSHIPMENTToolStripMenuItem"
        Me.DeleteCUSTSHIPMENTToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.DeleteCUSTSHIPMENTToolStripMenuItem.Text = "Delete CUST_SHIPMENT"
        '
        'DeleteCUSTLINEITEMToolStripMenuItem
        '
        Me.DeleteCUSTLINEITEMToolStripMenuItem.Name = "DeleteCUSTLINEITEMToolStripMenuItem"
        Me.DeleteCUSTLINEITEMToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.DeleteCUSTLINEITEMToolStripMenuItem.Text = "Delete CUST_LINEITEM"
        '
        'DeleteMsg16HistoryToolStripMenuItem
        '
        Me.DeleteMsg16HistoryToolStripMenuItem.Name = "DeleteMsg16HistoryToolStripMenuItem"
        Me.DeleteMsg16HistoryToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.DeleteMsg16HistoryToolStripMenuItem.Text = "Delete Msg16 History"
        '
        'DeleteTRAILERFPDSToolStripMenuItem
        '
        Me.DeleteTRAILERFPDSToolStripMenuItem.Name = "DeleteTRAILERFPDSToolStripMenuItem"
        Me.DeleteTRAILERFPDSToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.DeleteTRAILERFPDSToolStripMenuItem.Text = "Delete TRAILER_FPDS"
        '
        'PurgeCompletedShipmentsToolStripMenuItem
        '
        Me.PurgeCompletedShipmentsToolStripMenuItem.Name = "PurgeCompletedShipmentsToolStripMenuItem"
        Me.PurgeCompletedShipmentsToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.PurgeCompletedShipmentsToolStripMenuItem.Text = "Delete Completed Shipments"
        '
        'DeleteCompletedWithdrawsToolStripMenuItem
        '
        Me.DeleteCompletedWithdrawsToolStripMenuItem.Name = "DeleteCompletedWithdrawsToolStripMenuItem"
        Me.DeleteCompletedWithdrawsToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.DeleteCompletedWithdrawsToolStripMenuItem.Text = "Delete Completed Withdraws"
        '
        'RemoveAToolStripMenuItem
        '
        Me.RemoveAToolStripMenuItem.Name = "RemoveAToolStripMenuItem"
        Me.RemoveAToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.RemoveAToolStripMenuItem.Text = "Remove All Emulator Data"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.Checked = True
        Me.ToolsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchLogToolStripMenuItem, Me.SendHeartbeatToolStripMenuItem, Me.SendHeartbeatAutomaticallyToolStripMenuItem, Me.SendXMLFromFileToolStripMenuItem, Me.XMLEditorToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'SearchLogToolStripMenuItem
        '
        Me.SearchLogToolStripMenuItem.Name = "SearchLogToolStripMenuItem"
        Me.SearchLogToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.SearchLogToolStripMenuItem.Text = "Search Log"
        '
        'SendHeartbeatToolStripMenuItem
        '
        Me.SendHeartbeatToolStripMenuItem.Name = "SendHeartbeatToolStripMenuItem"
        Me.SendHeartbeatToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.SendHeartbeatToolStripMenuItem.Text = "Send Heartbeat"
        '
        'SendHeartbeatAutomaticallyToolStripMenuItem
        '
        Me.SendHeartbeatAutomaticallyToolStripMenuItem.CheckOnClick = True
        Me.SendHeartbeatAutomaticallyToolStripMenuItem.Name = "SendHeartbeatAutomaticallyToolStripMenuItem"
        Me.SendHeartbeatAutomaticallyToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.SendHeartbeatAutomaticallyToolStripMenuItem.Text = "Send Heartbeat Automatically"
        '
        'SendXMLFromFileToolStripMenuItem
        '
        Me.SendXMLFromFileToolStripMenuItem.Name = "SendXMLFromFileToolStripMenuItem"
        Me.SendXMLFromFileToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.SendXMLFromFileToolStripMenuItem.Text = "Send XML From File"
        '
        'XMLEditorToolStripMenuItem
        '
        Me.XMLEditorToolStripMenuItem.Name = "XMLEditorToolStripMenuItem"
        Me.XMLEditorToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.XMLEditorToolStripMenuItem.Text = "XML Editor"
        '
        'WMSToolStripMenuItem
        '
        Me.WMSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateEventsInICToSCToolStripMenuItem, Me.UpdateASRSSessionIDToolStripMenuItem, Me.UpdateRTCSESToolStripMenuItem})
        Me.WMSToolStripMenuItem.Name = "WMSToolStripMenuItem"
        Me.WMSToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.WMSToolStripMenuItem.Text = "WMS"
        '
        'UpdateEventsInICToSCToolStripMenuItem
        '
        Me.UpdateEventsInICToSCToolStripMenuItem.Name = "UpdateEventsInICToSCToolStripMenuItem"
        Me.UpdateEventsInICToSCToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.UpdateEventsInICToSCToolStripMenuItem.Text = "Update Events in IC to SC"
        '
        'UpdateASRSSessionIDToolStripMenuItem
        '
        Me.UpdateASRSSessionIDToolStripMenuItem.Name = "UpdateASRSSessionIDToolStripMenuItem"
        Me.UpdateASRSSessionIDToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.UpdateASRSSessionIDToolStripMenuItem.Text = "Update ASRS Session ID"
        '
        'UpdateRTCSESToolStripMenuItem
        '
        Me.UpdateRTCSESToolStripMenuItem.Name = "UpdateRTCSESToolStripMenuItem"
        Me.UpdateRTCSESToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.UpdateRTCSESToolStripMenuItem.Text = "Update RTCSES to MyIP"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.ServiceStepsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ServiceStepsToolStripMenuItem
        '
        Me.ServiceStepsToolStripMenuItem.Name = "ServiceStepsToolStripMenuItem"
        Me.ServiceStepsToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ServiceStepsToolStripMenuItem.Text = "Close All Popup Windows"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(920, 425)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = " Don't Delete"
        Me.Label1.Visible = False
        '
        'tmrBlink
        '
        Me.tmrBlink.Interval = 500
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelRefresh, Me.lblWait, Me.ToolStripStatusLabelHeartBeatOn, Me.ToolStripStatusSpacer, Me.lblToolStripWorking, Me.ToolStripStatusLblConnections})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 654)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1284, 22)
        Me.StatusStrip1.TabIndex = 62
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelRefresh
        '
        Me.ToolStripStatusLabelRefresh.Name = "ToolStripStatusLabelRefresh"
        Me.ToolStripStatusLabelRefresh.Size = New System.Drawing.Size(130, 17)
        Me.ToolStripStatusLabelRefresh.Text = "New Message Received"
        Me.ToolStripStatusLabelRefresh.Visible = False
        '
        'lblWait
        '
        Me.lblWait.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblWait.ForeColor = System.Drawing.Color.White
        Me.lblWait.Name = "lblWait"
        Me.lblWait.Size = New System.Drawing.Size(85, 17)
        Me.lblWait.Text = "...Please Wait..."
        Me.lblWait.Visible = False
        '
        'ToolStripStatusLabelHeartBeatOn
        '
        Me.ToolStripStatusLabelHeartBeatOn.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStripStatusLabelHeartBeatOn.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripStatusLabelHeartBeatOn.Name = "ToolStripStatusLabelHeartBeatOn"
        Me.ToolStripStatusLabelHeartBeatOn.Size = New System.Drawing.Size(78, 17)
        Me.ToolStripStatusLabelHeartBeatOn.Text = "HeartBeat On"
        Me.ToolStripStatusLabelHeartBeatOn.Visible = False
        '
        'ToolStripStatusSpacer
        '
        Me.ToolStripStatusSpacer.Name = "ToolStripStatusSpacer"
        Me.ToolStripStatusSpacer.Size = New System.Drawing.Size(634, 17)
        Me.ToolStripStatusSpacer.Spring = True
        '
        'lblToolStripWorking
        '
        Me.lblToolStripWorking.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblToolStripWorking.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblToolStripWorking.Name = "lblToolStripWorking"
        Me.lblToolStripWorking.Size = New System.Drawing.Size(52, 17)
        Me.lblToolStripWorking.Text = "Working"
        Me.lblToolStripWorking.Visible = False
        '
        'ToolStripStatusLblConnections
        '
        Me.ToolStripStatusLblConnections.Name = "ToolStripStatusLblConnections"
        Me.ToolStripStatusLblConnections.Size = New System.Drawing.Size(634, 17)
        Me.ToolStripStatusLblConnections.Spring = True
        Me.ToolStripStatusLblConnections.Text = "IP etc"
        Me.ToolStripStatusLblConnections.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 13)
        Me.Label15.TabIndex = 101
        Me.Label15.Text = "Override Sitnam:"
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.ForeColor = System.Drawing.Color.Blue
        Me.TextBox1.Location = New System.Drawing.Point(101, 124)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(120, 20)
        Me.TextBox1.TabIndex = 100
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(10, 179)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(36, 13)
        Me.Label23.TabIndex = 99
        Me.Label23.Text = "Sldflg:"
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.ForeColor = System.Drawing.Color.Blue
        Me.TextBox2.Location = New System.Drawing.Point(101, 176)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(120, 20)
        Me.TextBox2.TabIndex = 98
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(10, 101)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 13)
        Me.Label24.TabIndex = 97
        Me.Label24.Text = "UlPall:"
        '
        'TextBox3
        '
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.ForeColor = System.Drawing.Color.Blue
        Me.TextBox3.Location = New System.Drawing.Point(101, 98)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(120, 20)
        Me.TextBox3.TabIndex = 96
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(10, 153)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(86, 13)
        Me.Label25.TabIndex = 95
        Me.Label25.Text = "Override Locatn:"
        '
        'TextBox4
        '
        Me.TextBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox4.ForeColor = System.Drawing.Color.Blue
        Me.TextBox4.Location = New System.Drawing.Point(101, 150)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(120, 20)
        Me.TextBox4.TabIndex = 94
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(10, 23)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 13)
        Me.Label26.TabIndex = 93
        Me.Label26.Text = "Ulid:"
        '
        'TextBox5
        '
        Me.TextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox5.ForeColor = System.Drawing.Color.Blue
        Me.TextBox5.Location = New System.Drawing.Point(101, 20)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(228, 20)
        Me.TextBox5.TabIndex = 92
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(10, 49)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(42, 13)
        Me.Label27.TabIndex = 90
        Me.Label27.Text = "Sitnam:"
        '
        'TextBox6
        '
        Me.TextBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox6.ForeColor = System.Drawing.Color.Blue
        Me.TextBox6.Location = New System.Drawing.Point(101, 46)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(120, 20)
        Me.TextBox6.TabIndex = 89
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(10, 75)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(43, 13)
        Me.Label28.TabIndex = 88
        Me.Label28.Text = "Locatn:"
        '
        'TextBox7
        '
        Me.TextBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox7.ForeColor = System.Drawing.Color.Blue
        Me.TextBox7.Location = New System.Drawing.Point(101, 72)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(120, 20)
        Me.TextBox7.TabIndex = 87
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(39, 326)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 39)
        Me.Button1.TabIndex = 77
        Me.Button1.Text = "Identify UL"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.butMsg21_Header_Advance)
        Me.GroupBox9.Controls.Add(Me.butMsg21_Header_SelectAll)
        Me.GroupBox9.Controls.Add(Me.butMsg21_Header_DeSelectAll)
        Me.GroupBox9.Location = New System.Drawing.Point(91, 5)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(286, 68)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Shipment Control"
        Me.ToolTip1.SetToolTip(Me.GroupBox9, "Click ShipId to Display Line Items")
        '
        'butMsg21_Header_Advance
        '
        Me.butMsg21_Header_Advance.Location = New System.Drawing.Point(186, 18)
        Me.butMsg21_Header_Advance.Name = "butMsg21_Header_Advance"
        Me.butMsg21_Header_Advance.Size = New System.Drawing.Size(84, 34)
        Me.butMsg21_Header_Advance.TabIndex = 2
        Me.butMsg21_Header_Advance.Text = "Advance"
        Me.butMsg21_Header_Advance.UseVisualStyleBackColor = True
        '
        'butMsg21_Header_SelectAll
        '
        Me.butMsg21_Header_SelectAll.Location = New System.Drawing.Point(6, 18)
        Me.butMsg21_Header_SelectAll.Name = "butMsg21_Header_SelectAll"
        Me.butMsg21_Header_SelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg21_Header_SelectAll.TabIndex = 0
        Me.butMsg21_Header_SelectAll.Text = "Select All"
        Me.butMsg21_Header_SelectAll.UseVisualStyleBackColor = True
        '
        'butMsg21_Header_DeSelectAll
        '
        Me.butMsg21_Header_DeSelectAll.Location = New System.Drawing.Point(96, 18)
        Me.butMsg21_Header_DeSelectAll.Name = "butMsg21_Header_DeSelectAll"
        Me.butMsg21_Header_DeSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg21_Header_DeSelectAll.TabIndex = 1
        Me.butMsg21_Header_DeSelectAll.Text = "DeSelectAll"
        Me.butMsg21_Header_DeSelectAll.UseVisualStyleBackColor = True
        '
        'linMain
        '
        Me.linMain.BackColor = System.Drawing.SystemColors.ControlText
        Me.linMain.Location = New System.Drawing.Point(38, 200)
        Me.linMain.Name = "linMain"
        Me.linMain.Size = New System.Drawing.Size(882, 10)
        Me.linMain.TabIndex = 85
        Me.ToolTip1.SetToolTip(Me.linMain, "Click On Error Path to Force SSCC Error")
        '
        'tmrHeartbeat
        '
        Me.tmrHeartbeat.Enabled = True
        Me.tmrHeartbeat.Interval = 60000
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 27)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel1MinSize = 125
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2MinSize = 75
        Me.SplitContainer1.Size = New System.Drawing.Size(1257, 625)
        Me.SplitContainer1.SplitterDistance = 440
        Me.SplitContainer1.TabIndex = 63
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage9)
        Me.TabControl1.Controls.Add(Me.TabPage10)
        Me.TabControl1.Controls.Add(Me.TabPage11)
        Me.TabControl1.Controls.Add(Me.TabPage12)
        Me.TabControl1.Controls.Add(Me.TabPage13)
        Me.TabControl1.Controls.Add(Me.TabPage14)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1286, 439)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.DataGrid1)
        Me.TabPage1.Controls.Add(Me.GroupBox19)
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.cmdRefreshInfeed)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "RTCIS Infeed"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(933, 46)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(130, 80)
        Me.DataGrid1.TabIndex = 64
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.Label22)
        Me.GroupBox19.Controls.Add(Me.txtInfeedRestrictToCtlgrp)
        Me.GroupBox19.Controls.Add(Me.Label21)
        Me.GroupBox19.Controls.Add(Me.Label20)
        Me.GroupBox19.Controls.Add(Me.txtInfeedRestrictToUlPall)
        Me.GroupBox19.Controls.Add(Me.txtInfeedRestrictToItem)
        Me.GroupBox19.Location = New System.Drawing.Point(574, 6)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(339, 68)
        Me.GroupBox19.TabIndex = 63
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Query Restrictions"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(143, 20)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 13)
        Me.Label22.TabIndex = 67
        Me.Label22.Text = "Control Group"
        '
        'txtInfeedRestrictToCtlgrp
        '
        Me.txtInfeedRestrictToCtlgrp.Location = New System.Drawing.Point(125, 35)
        Me.txtInfeedRestrictToCtlgrp.Name = "txtInfeedRestrictToCtlgrp"
        Me.txtInfeedRestrictToCtlgrp.Size = New System.Drawing.Size(106, 20)
        Me.txtInfeedRestrictToCtlgrp.TabIndex = 66
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(254, 20)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 13)
        Me.Label21.TabIndex = 65
        Me.Label21.Text = "Ulpall"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(24, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 13)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "Item Code"
        '
        'txtInfeedRestrictToUlPall
        '
        Me.txtInfeedRestrictToUlPall.Location = New System.Drawing.Point(245, 35)
        Me.txtInfeedRestrictToUlPall.Name = "txtInfeedRestrictToUlPall"
        Me.txtInfeedRestrictToUlPall.Size = New System.Drawing.Size(76, 20)
        Me.txtInfeedRestrictToUlPall.TabIndex = 63
        '
        'txtInfeedRestrictToItem
        '
        Me.txtInfeedRestrictToItem.Location = New System.Drawing.Point(6, 35)
        Me.txtInfeedRestrictToItem.Name = "txtInfeedRestrictToItem"
        Me.txtInfeedRestrictToItem.Size = New System.Drawing.Size(106, 20)
        Me.txtInfeedRestrictToItem.TabIndex = 62
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.flxGrid1, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(6, 80)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 327.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(805, 327)
        Me.TableLayoutPanel3.TabIndex = 61
        '
        'flxGrid1
        '
        Me.flxGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxGrid1.Location = New System.Drawing.Point(3, 3)
        Me.flxGrid1.Name = "flxGrid1"
        Me.flxGrid1.OcxState = CType(resources.GetObject("flxGrid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid1.Size = New System.Drawing.Size(827, 321)
        Me.flxGrid1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnInfeedAutoScanOff)
        Me.GroupBox3.Controls.Add(Me.btnInfeedAutoScanOn)
        Me.GroupBox3.Location = New System.Drawing.Point(482, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(80, 68)
        Me.GroupBox3.TabIndex = 60
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Auto Mode"
        '
        'btnInfeedAutoScanOff
        '
        Me.btnInfeedAutoScanOff.Location = New System.Drawing.Point(14, 41)
        Me.btnInfeedAutoScanOff.Name = "btnInfeedAutoScanOff"
        Me.btnInfeedAutoScanOff.Size = New System.Drawing.Size(40, 23)
        Me.btnInfeedAutoScanOff.TabIndex = 5
        Me.btnInfeedAutoScanOff.Text = "Off"
        '
        'btnInfeedAutoScanOn
        '
        Me.btnInfeedAutoScanOn.Location = New System.Drawing.Point(14, 15)
        Me.btnInfeedAutoScanOn.Name = "btnInfeedAutoScanOn"
        Me.btnInfeedAutoScanOn.Size = New System.Drawing.Size(40, 23)
        Me.btnInfeedAutoScanOn.TabIndex = 4
        Me.btnInfeedAutoScanOn.Text = "On"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdInfeedAdvance)
        Me.GroupBox1.Controls.Add(Me.cmdInfeedSelectAll)
        Me.GroupBox1.Controls.Add(Me.cmdInfeedDeSelectAll)
        Me.GroupBox1.Location = New System.Drawing.Point(105, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(372, 68)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Infeed Control "
        '
        'cmdInfeedAdvance
        '
        Me.cmdInfeedAdvance.Location = New System.Drawing.Point(186, 18)
        Me.cmdInfeedAdvance.Name = "cmdInfeedAdvance"
        Me.cmdInfeedAdvance.Size = New System.Drawing.Size(84, 34)
        Me.cmdInfeedAdvance.TabIndex = 3
        Me.cmdInfeedAdvance.Text = "Advance"
        Me.cmdInfeedAdvance.UseVisualStyleBackColor = True
        '
        'cmdInfeedSelectAll
        '
        Me.cmdInfeedSelectAll.Location = New System.Drawing.Point(6, 18)
        Me.cmdInfeedSelectAll.Name = "cmdInfeedSelectAll"
        Me.cmdInfeedSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.cmdInfeedSelectAll.TabIndex = 1
        Me.cmdInfeedSelectAll.Text = "Select All"
        Me.cmdInfeedSelectAll.UseVisualStyleBackColor = True
        '
        'cmdInfeedDeSelectAll
        '
        Me.cmdInfeedDeSelectAll.Location = New System.Drawing.Point(96, 18)
        Me.cmdInfeedDeSelectAll.Name = "cmdInfeedDeSelectAll"
        Me.cmdInfeedDeSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.cmdInfeedDeSelectAll.TabIndex = 2
        Me.cmdInfeedDeSelectAll.Text = "DeSelectAll"
        Me.cmdInfeedDeSelectAll.UseVisualStyleBackColor = True
        '
        'cmdRefreshInfeed
        '
        Me.cmdRefreshInfeed.Location = New System.Drawing.Point(15, 24)
        Me.cmdRefreshInfeed.Name = "cmdRefreshInfeed"
        Me.cmdRefreshInfeed.Size = New System.Drawing.Size(84, 34)
        Me.cmdRefreshInfeed.TabIndex = 0
        Me.cmdRefreshInfeed.Text = "Get Data"
        Me.cmdRefreshInfeed.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "ASRS Infeed"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.41291!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.58709!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 242.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpCartonControl, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox15, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.flxGrid2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.flxGrid3, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grpPickControl, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.flxGrid11, 2, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(15, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 331.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1228, 397)
        Me.TableLayoutPanel1.TabIndex = 69
        '
        'grpCartonControl
        '
        Me.grpCartonControl.Controls.Add(Me.cmdASRSInfeedAdvance)
        Me.grpCartonControl.Controls.Add(Me.GroupBox2)
        Me.grpCartonControl.Controls.Add(Me.cmdASRSInfeedSelectAll)
        Me.grpCartonControl.Controls.Add(Me.cmdASRSInfeedDeSelectAll)
        Me.grpCartonControl.Controls.Add(Me.butRefreshASRSInfeed)
        Me.grpCartonControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCartonControl.Location = New System.Drawing.Point(3, 3)
        Me.grpCartonControl.Name = "grpCartonControl"
        Me.grpCartonControl.Size = New System.Drawing.Size(481, 60)
        Me.grpCartonControl.TabIndex = 0
        Me.grpCartonControl.TabStop = False
        Me.grpCartonControl.Text = "ASRS Input Location Control"
        '
        'cmdASRSInfeedAdvance
        '
        Me.cmdASRSInfeedAdvance.Location = New System.Drawing.Point(294, 19)
        Me.cmdASRSInfeedAdvance.Name = "cmdASRSInfeedAdvance"
        Me.cmdASRSInfeedAdvance.Size = New System.Drawing.Size(84, 34)
        Me.cmdASRSInfeedAdvance.TabIndex = 3
        Me.cmdASRSInfeedAdvance.Text = "Advance"
        Me.cmdASRSInfeedAdvance.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnASRSInfeedAutoScanOn)
        Me.GroupBox2.Controls.Add(Me.btnASRSInfeedAutoScanOff)
        Me.GroupBox2.Location = New System.Drawing.Point(384, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(107, 48)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Auto Mode"
        '
        'btnASRSInfeedAutoScanOn
        '
        Me.btnASRSInfeedAutoScanOn.Location = New System.Drawing.Point(10, 18)
        Me.btnASRSInfeedAutoScanOn.Name = "btnASRSInfeedAutoScanOn"
        Me.btnASRSInfeedAutoScanOn.Size = New System.Drawing.Size(40, 23)
        Me.btnASRSInfeedAutoScanOn.TabIndex = 0
        Me.btnASRSInfeedAutoScanOn.Text = "On"
        '
        'btnASRSInfeedAutoScanOff
        '
        Me.btnASRSInfeedAutoScanOff.Location = New System.Drawing.Point(57, 18)
        Me.btnASRSInfeedAutoScanOff.Name = "btnASRSInfeedAutoScanOff"
        Me.btnASRSInfeedAutoScanOff.Size = New System.Drawing.Size(40, 23)
        Me.btnASRSInfeedAutoScanOff.TabIndex = 1
        Me.btnASRSInfeedAutoScanOff.Text = "Off"
        '
        'cmdASRSInfeedSelectAll
        '
        Me.cmdASRSInfeedSelectAll.Location = New System.Drawing.Point(114, 19)
        Me.cmdASRSInfeedSelectAll.Name = "cmdASRSInfeedSelectAll"
        Me.cmdASRSInfeedSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.cmdASRSInfeedSelectAll.TabIndex = 1
        Me.cmdASRSInfeedSelectAll.Text = "Select All"
        Me.cmdASRSInfeedSelectAll.UseVisualStyleBackColor = True
        '
        'cmdASRSInfeedDeSelectAll
        '
        Me.cmdASRSInfeedDeSelectAll.Location = New System.Drawing.Point(204, 19)
        Me.cmdASRSInfeedDeSelectAll.Name = "cmdASRSInfeedDeSelectAll"
        Me.cmdASRSInfeedDeSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.cmdASRSInfeedDeSelectAll.TabIndex = 2
        Me.cmdASRSInfeedDeSelectAll.Text = "DeSelectAll"
        Me.cmdASRSInfeedDeSelectAll.UseVisualStyleBackColor = True
        '
        'butRefreshASRSInfeed
        '
        Me.butRefreshASRSInfeed.Location = New System.Drawing.Point(6, 19)
        Me.butRefreshASRSInfeed.Name = "butRefreshASRSInfeed"
        Me.butRefreshASRSInfeed.Size = New System.Drawing.Size(84, 34)
        Me.butRefreshASRSInfeed.TabIndex = 0
        Me.butRefreshASRSInfeed.Text = "Get Data"
        Me.butRefreshASRSInfeed.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.butRereshAsrsInventorySummary)
        Me.GroupBox15.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox15.Location = New System.Drawing.Point(988, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(237, 60)
        Me.GroupBox15.TabIndex = 63
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "ASRS Inventory Summary"
        '
        'butRereshAsrsInventorySummary
        '
        Me.butRereshAsrsInventorySummary.Location = New System.Drawing.Point(41, 18)
        Me.butRereshAsrsInventorySummary.Name = "butRereshAsrsInventorySummary"
        Me.butRereshAsrsInventorySummary.Size = New System.Drawing.Size(84, 34)
        Me.butRereshAsrsInventorySummary.TabIndex = 1
        Me.butRereshAsrsInventorySummary.Text = "Get Data"
        Me.butRereshAsrsInventorySummary.UseVisualStyleBackColor = True
        '
        'flxGrid2
        '
        Me.flxGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxGrid2.Location = New System.Drawing.Point(3, 69)
        Me.flxGrid2.Name = "flxGrid2"
        Me.flxGrid2.OcxState = CType(resources.GetObject("flxGrid2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid2.Size = New System.Drawing.Size(481, 325)
        Me.flxGrid2.TabIndex = 0
        Me.flxGrid2.TabStop = False
        '
        'flxGrid3
        '
        Me.flxGrid3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxGrid3.Location = New System.Drawing.Point(490, 69)
        Me.flxGrid3.Name = "flxGrid3"
        Me.flxGrid3.OcxState = CType(resources.GetObject("flxGrid3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid3.Size = New System.Drawing.Size(492, 325)
        Me.flxGrid3.TabIndex = 0
        '
        'grpPickControl
        '
        Me.grpPickControl.Controls.Add(Me.butRefreshNeedingMsg7)
        Me.grpPickControl.Controls.Add(Me.butMsg7Advance)
        Me.grpPickControl.Controls.Add(Me.butMsg7SelectAll)
        Me.grpPickControl.Controls.Add(Me.butMsg7DeSelectAll)
        Me.grpPickControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpPickControl.Location = New System.Drawing.Point(490, 3)
        Me.grpPickControl.Name = "grpPickControl"
        Me.grpPickControl.Size = New System.Drawing.Size(492, 60)
        Me.grpPickControl.TabIndex = 2
        Me.grpPickControl.TabStop = False
        Me.grpPickControl.Text = "Final Destination Msg7 Control        (9=Reject)"
        '
        'butRefreshNeedingMsg7
        '
        Me.butRefreshNeedingMsg7.Location = New System.Drawing.Point(16, 18)
        Me.butRefreshNeedingMsg7.Name = "butRefreshNeedingMsg7"
        Me.butRefreshNeedingMsg7.Size = New System.Drawing.Size(84, 34)
        Me.butRefreshNeedingMsg7.TabIndex = 0
        Me.butRefreshNeedingMsg7.Text = "Get Data"
        Me.butRefreshNeedingMsg7.UseVisualStyleBackColor = True
        '
        'butMsg7Advance
        '
        Me.butMsg7Advance.Location = New System.Drawing.Point(336, 18)
        Me.butMsg7Advance.Name = "butMsg7Advance"
        Me.butMsg7Advance.Size = New System.Drawing.Size(84, 34)
        Me.butMsg7Advance.TabIndex = 3
        Me.butMsg7Advance.Text = "Advance"
        Me.butMsg7Advance.UseVisualStyleBackColor = True
        '
        'butMsg7SelectAll
        '
        Me.butMsg7SelectAll.Location = New System.Drawing.Point(156, 18)
        Me.butMsg7SelectAll.Name = "butMsg7SelectAll"
        Me.butMsg7SelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg7SelectAll.TabIndex = 1
        Me.butMsg7SelectAll.Text = "Select All"
        Me.butMsg7SelectAll.UseVisualStyleBackColor = True
        '
        'butMsg7DeSelectAll
        '
        Me.butMsg7DeSelectAll.Location = New System.Drawing.Point(246, 18)
        Me.butMsg7DeSelectAll.Name = "butMsg7DeSelectAll"
        Me.butMsg7DeSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg7DeSelectAll.TabIndex = 2
        Me.butMsg7DeSelectAll.Text = "DeSelectAll"
        Me.butMsg7DeSelectAll.UseVisualStyleBackColor = True
        '
        'flxGrid11
        '
        Me.flxGrid11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxGrid11.Location = New System.Drawing.Point(988, 69)
        Me.flxGrid11.Name = "flxGrid11"
        Me.flxGrid11.OcxState = CType(resources.GetObject("flxGrid11.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid11.Size = New System.Drawing.Size(237, 325)
        Me.flxGrid11.TabIndex = 64
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.GroupBox16)
        Me.TabPage7.Controls.Add(Me.GroupBox8)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage7.TabIndex = 8
        Me.TabPage7.Text = "Request Order"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.Label17)
        Me.GroupBox16.Controls.Add(Me.txtRequestNextProdOrder_DeliveryLocation)
        Me.GroupBox16.Controls.Add(Me.butRequestNextProdOrder)
        Me.GroupBox16.Location = New System.Drawing.Point(410, 25)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(362, 163)
        Me.GroupBox16.TabIndex = 67
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Production Order"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(15, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(143, 13)
        Me.Label17.TabIndex = 60
        Me.Label17.Text = "Delivery Location (Prod Line)"
        '
        'txtRequestNextProdOrder_DeliveryLocation
        '
        Me.txtRequestNextProdOrder_DeliveryLocation.Location = New System.Drawing.Point(164, 28)
        Me.txtRequestNextProdOrder_DeliveryLocation.Name = "txtRequestNextProdOrder_DeliveryLocation"
        Me.txtRequestNextProdOrder_DeliveryLocation.Size = New System.Drawing.Size(76, 20)
        Me.txtRequestNextProdOrder_DeliveryLocation.TabIndex = 0
        '
        'butRequestNextProdOrder
        '
        Me.butRequestNextProdOrder.Location = New System.Drawing.Point(257, 18)
        Me.butRequestNextProdOrder.Name = "butRequestNextProdOrder"
        Me.butRequestNextProdOrder.Size = New System.Drawing.Size(84, 34)
        Me.butRequestNextProdOrder.TabIndex = 1
        Me.butRequestNextProdOrder.Text = "Send"
        Me.butRequestNextProdOrder.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label6)
        Me.GroupBox8.Controls.Add(Me.txtMsg21_MOT_CODE)
        Me.GroupBox8.Controls.Add(Me.butMsg21_Send)
        Me.GroupBox8.Controls.Add(Me.GroupBox7)
        Me.GroupBox8.Location = New System.Drawing.Point(24, 25)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(362, 163)
        Me.GroupBox8.TabIndex = 66
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Shipment"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "MOT Code"
        '
        'txtMsg21_MOT_CODE
        '
        Me.txtMsg21_MOT_CODE.Location = New System.Drawing.Point(87, 26)
        Me.txtMsg21_MOT_CODE.Name = "txtMsg21_MOT_CODE"
        Me.txtMsg21_MOT_CODE.Size = New System.Drawing.Size(43, 20)
        Me.txtMsg21_MOT_CODE.TabIndex = 0
        '
        'butMsg21_Send
        '
        Me.butMsg21_Send.Location = New System.Drawing.Point(150, 19)
        Me.butMsg21_Send.Name = "butMsg21_Send"
        Me.butMsg21_Send.Size = New System.Drawing.Size(84, 34)
        Me.butMsg21_Send.TabIndex = 1
        Me.butMsg21_Send.Text = "Send"
        Me.butMsg21_Send.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.butMsg21AutoSendOff)
        Me.GroupBox7.Controls.Add(Me.butMsg21AutoSendOn)
        Me.GroupBox7.Location = New System.Drawing.Point(257, 19)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(80, 68)
        Me.GroupBox7.TabIndex = 64
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Auto Mode"
        '
        'butMsg21AutoSendOff
        '
        Me.butMsg21AutoSendOff.Location = New System.Drawing.Point(14, 41)
        Me.butMsg21AutoSendOff.Name = "butMsg21AutoSendOff"
        Me.butMsg21AutoSendOff.Size = New System.Drawing.Size(40, 23)
        Me.butMsg21AutoSendOff.TabIndex = 1
        Me.butMsg21AutoSendOff.Text = "Off"
        '
        'butMsg21AutoSendOn
        '
        Me.butMsg21AutoSendOn.Location = New System.Drawing.Point(14, 15)
        Me.butMsg21AutoSendOn.Name = "butMsg21AutoSendOn"
        Me.butMsg21AutoSendOn.Size = New System.Drawing.Size(40, 23)
        Me.butMsg21AutoSendOn.TabIndex = 0
        Me.butMsg21AutoSendOn.Text = "On"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.TableLayoutPanel5)
        Me.TabPage4.Controls.Add(Me.GroupBox11)
        Me.TabPage4.Controls.Add(Me.GroupBox10)
        Me.TabPage4.Controls.Add(Me.GroupBox9)
        Me.TabPage4.Controls.Add(Me.butMsg21_GetData)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage4.TabIndex = 5
        Me.TabPage4.Text = "Order Stage/De-Stage"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.03185!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.96815!))
        Me.TableLayoutPanel5.Controls.Add(Me.flxGrid4, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.flxGrid8, 1, 0)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(15, 75)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1256, 333)
        Me.TableLayoutPanel5.TabIndex = 72
        '
        'flxGrid4
        '
        Me.flxGrid4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxGrid4.Location = New System.Drawing.Point(3, 3)
        Me.flxGrid4.Name = "flxGrid4"
        Me.flxGrid4.OcxState = CType(resources.GetObject("flxGrid4.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid4.Size = New System.Drawing.Size(434, 327)
        Me.flxGrid4.TabIndex = 58
        Me.flxGrid4.TabStop = False
        '
        'flxGrid8
        '
        Me.flxGrid8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxGrid8.Location = New System.Drawing.Point(443, 3)
        Me.flxGrid8.Name = "flxGrid8"
        Me.flxGrid8.OcxState = CType(resources.GetObject("flxGrid8.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid8.Size = New System.Drawing.Size(810, 327)
        Me.flxGrid8.TabIndex = 69
        Me.flxGrid8.TabStop = False
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.butMsg22AutoSendOff)
        Me.GroupBox11.Controls.Add(Me.butMsg22AutoSendOn)
        Me.GroupBox11.Location = New System.Drawing.Point(377, 5)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(80, 68)
        Me.GroupBox11.TabIndex = 2
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Auto Mode"
        '
        'butMsg22AutoSendOff
        '
        Me.butMsg22AutoSendOff.Location = New System.Drawing.Point(14, 41)
        Me.butMsg22AutoSendOff.Name = "butMsg22AutoSendOff"
        Me.butMsg22AutoSendOff.Size = New System.Drawing.Size(40, 23)
        Me.butMsg22AutoSendOff.TabIndex = 1
        Me.butMsg22AutoSendOff.Text = "Off"
        '
        'butMsg22AutoSendOn
        '
        Me.butMsg22AutoSendOn.Location = New System.Drawing.Point(14, 15)
        Me.butMsg22AutoSendOn.Name = "butMsg22AutoSendOn"
        Me.butMsg22AutoSendOn.Size = New System.Drawing.Size(40, 23)
        Me.butMsg22AutoSendOn.TabIndex = 0
        Me.butMsg22AutoSendOn.Text = "On"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.lblSlotMaxAlarm)
        Me.GroupBox10.Controls.Add(Me.butMsg21CheckInventory)
        Me.GroupBox10.Controls.Add(Me.lblRaid_Msg23_SelectedDisposition)
        Me.GroupBox10.Controls.Add(Me.lblRaid_SelectedLoadStatus)
        Me.GroupBox10.Controls.Add(Me.Label10)
        Me.GroupBox10.Controls.Add(Me.butMsg21_Detail_GetData)
        Me.GroupBox10.Controls.Add(Me.txtlblRaid_Msg23_SelectedSlot)
        Me.GroupBox10.Controls.Add(Me.Label8)
        Me.GroupBox10.Controls.Add(Me.lblRaid_SelectedShipidDisplay)
        Me.GroupBox10.Controls.Add(Me.lblRaid_SelectedShipid)
        Me.GroupBox10.Controls.Add(Me.butMsg21_Detail_Advance)
        Me.GroupBox10.Controls.Add(Me.butMsg21_Detail_SelectAll)
        Me.GroupBox10.Controls.Add(Me.butMsg21_Detail_DeSelectAll)
        Me.GroupBox10.Location = New System.Drawing.Point(457, 5)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(814, 68)
        Me.GroupBox10.TabIndex = 3
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Shipment Line Item Control"
        '
        'lblSlotMaxAlarm
        '
        Me.lblSlotMaxAlarm.AutoSize = True
        Me.lblSlotMaxAlarm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlotMaxAlarm.ForeColor = System.Drawing.Color.Red
        Me.lblSlotMaxAlarm.Location = New System.Drawing.Point(355, 48)
        Me.lblSlotMaxAlarm.Name = "lblSlotMaxAlarm"
        Me.lblSlotMaxAlarm.Size = New System.Drawing.Size(182, 15)
        Me.lblSlotMaxAlarm.TabIndex = 72
        Me.lblSlotMaxAlarm.Text = "Maximum ULs for Slot Reached"
        Me.lblSlotMaxAlarm.Visible = False
        '
        'butMsg21CheckInventory
        '
        Me.butMsg21CheckInventory.Location = New System.Drawing.Point(680, 13)
        Me.butMsg21CheckInventory.Name = "butMsg21CheckInventory"
        Me.butMsg21CheckInventory.Size = New System.Drawing.Size(84, 34)
        Me.butMsg21CheckInventory.TabIndex = 71
        Me.butMsg21CheckInventory.Text = "Avail Inv Check"
        Me.butMsg21CheckInventory.UseVisualStyleBackColor = True
        '
        'lblRaid_Msg23_SelectedDisposition
        '
        Me.lblRaid_Msg23_SelectedDisposition.AutoSize = True
        Me.lblRaid_Msg23_SelectedDisposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRaid_Msg23_SelectedDisposition.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblRaid_Msg23_SelectedDisposition.Location = New System.Drawing.Point(254, 44)
        Me.lblRaid_Msg23_SelectedDisposition.Name = "lblRaid_Msg23_SelectedDisposition"
        Me.lblRaid_Msg23_SelectedDisposition.Size = New System.Drawing.Size(21, 20)
        Me.lblRaid_Msg23_SelectedDisposition.TabIndex = 70
        Me.lblRaid_Msg23_SelectedDisposition.Text = "..."
        '
        'lblRaid_SelectedLoadStatus
        '
        Me.lblRaid_SelectedLoadStatus.AutoSize = True
        Me.lblRaid_SelectedLoadStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRaid_SelectedLoadStatus.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblRaid_SelectedLoadStatus.Location = New System.Drawing.Point(158, 43)
        Me.lblRaid_SelectedLoadStatus.Name = "lblRaid_SelectedLoadStatus"
        Me.lblRaid_SelectedLoadStatus.Size = New System.Drawing.Size(21, 20)
        Me.lblRaid_SelectedLoadStatus.TabIndex = 69
        Me.lblRaid_SelectedLoadStatus.Text = "..."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(89, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Load Status:"
        '
        'butMsg21_Detail_GetData
        '
        Me.butMsg21_Detail_GetData.Location = New System.Drawing.Point(4, 19)
        Me.butMsg21_Detail_GetData.Name = "butMsg21_Detail_GetData"
        Me.butMsg21_Detail_GetData.Size = New System.Drawing.Size(84, 34)
        Me.butMsg21_Detail_GetData.TabIndex = 0
        Me.butMsg21_Detail_GetData.Text = "Get Data"
        Me.butMsg21_Detail_GetData.UseVisualStyleBackColor = True
        '
        'txtlblRaid_Msg23_SelectedSlot
        '
        Me.txtlblRaid_Msg23_SelectedSlot.Location = New System.Drawing.Point(295, 21)
        Me.txtlblRaid_Msg23_SelectedSlot.Name = "txtlblRaid_Msg23_SelectedSlot"
        Me.txtlblRaid_Msg23_SelectedSlot.Size = New System.Drawing.Size(52, 20)
        Me.txtlblRaid_Msg23_SelectedSlot.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(252, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Slot:"
        '
        'lblRaid_SelectedShipidDisplay
        '
        Me.lblRaid_SelectedShipidDisplay.AutoSize = True
        Me.lblRaid_SelectedShipidDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRaid_SelectedShipidDisplay.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblRaid_SelectedShipidDisplay.Location = New System.Drawing.Point(158, 19)
        Me.lblRaid_SelectedShipidDisplay.Name = "lblRaid_SelectedShipidDisplay"
        Me.lblRaid_SelectedShipidDisplay.Size = New System.Drawing.Size(21, 20)
        Me.lblRaid_SelectedShipidDisplay.TabIndex = 62
        Me.lblRaid_SelectedShipidDisplay.Text = "..."
        '
        'lblRaid_SelectedShipid
        '
        Me.lblRaid_SelectedShipid.AutoSize = True
        Me.lblRaid_SelectedShipid.Location = New System.Drawing.Point(101, 23)
        Me.lblRaid_SelectedShipid.Name = "lblRaid_SelectedShipid"
        Me.lblRaid_SelectedShipid.Size = New System.Drawing.Size(39, 13)
        Me.lblRaid_SelectedShipid.TabIndex = 61
        Me.lblRaid_SelectedShipid.Text = "Shipid:"
        '
        'butMsg21_Detail_Advance
        '
        Me.butMsg21_Detail_Advance.Location = New System.Drawing.Point(533, 13)
        Me.butMsg21_Detail_Advance.Name = "butMsg21_Detail_Advance"
        Me.butMsg21_Detail_Advance.Size = New System.Drawing.Size(84, 34)
        Me.butMsg21_Detail_Advance.TabIndex = 4
        Me.butMsg21_Detail_Advance.Text = "Advance"
        Me.butMsg21_Detail_Advance.UseVisualStyleBackColor = True
        '
        'butMsg21_Detail_SelectAll
        '
        Me.butMsg21_Detail_SelectAll.Location = New System.Drawing.Point(353, 13)
        Me.butMsg21_Detail_SelectAll.Name = "butMsg21_Detail_SelectAll"
        Me.butMsg21_Detail_SelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg21_Detail_SelectAll.TabIndex = 2
        Me.butMsg21_Detail_SelectAll.Text = "Select All"
        Me.butMsg21_Detail_SelectAll.UseVisualStyleBackColor = True
        '
        'butMsg21_Detail_DeSelectAll
        '
        Me.butMsg21_Detail_DeSelectAll.Location = New System.Drawing.Point(443, 13)
        Me.butMsg21_Detail_DeSelectAll.Name = "butMsg21_Detail_DeSelectAll"
        Me.butMsg21_Detail_DeSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg21_Detail_DeSelectAll.TabIndex = 3
        Me.butMsg21_Detail_DeSelectAll.Text = "DeSelectAll"
        Me.butMsg21_Detail_DeSelectAll.UseVisualStyleBackColor = True
        '
        'butMsg21_GetData
        '
        Me.butMsg21_GetData.Location = New System.Drawing.Point(1, 23)
        Me.butMsg21_GetData.Name = "butMsg21_GetData"
        Me.butMsg21_GetData.Size = New System.Drawing.Size(84, 34)
        Me.butMsg21_GetData.TabIndex = 0
        Me.butMsg21_GetData.Text = "Get Data"
        Me.butMsg21_GetData.UseVisualStyleBackColor = True
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.Panel8)
        Me.TabPage8.Controls.Add(Me.Panel7)
        Me.TabPage8.Controls.Add(Me.GroupBox14)
        Me.TabPage8.Controls.Add(Me.GroupBox13)
        Me.TabPage8.Controls.Add(Me.GroupBox12)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage8.TabIndex = 9
        Me.TabPage8.Text = "Order Compl"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.flxGrid10)
        Me.Panel8.Location = New System.Drawing.Point(577, 80)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(694, 332)
        Me.Panel8.TabIndex = 74
        '
        'flxGrid10
        '
        Me.flxGrid10.Location = New System.Drawing.Point(3, 3)
        Me.flxGrid10.Name = "flxGrid10"
        Me.flxGrid10.OcxState = CType(resources.GetObject("flxGrid10.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid10.Size = New System.Drawing.Size(677, 329)
        Me.flxGrid10.TabIndex = 72
        Me.flxGrid10.TabStop = False
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.flxGrid9)
        Me.Panel7.Location = New System.Drawing.Point(3, 80)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(571, 332)
        Me.Panel7.TabIndex = 73
        '
        'flxGrid9
        '
        Me.flxGrid9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.flxGrid9.Location = New System.Drawing.Point(3, 3)
        Me.flxGrid9.Name = "flxGrid9"
        Me.flxGrid9.OcxState = CType(resources.GetObject("flxGrid9.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid9.Size = New System.Drawing.Size(565, 325)
        Me.flxGrid9.TabIndex = 62
        Me.flxGrid9.TabStop = False
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.txtShipULPickUp_Load_Flag)
        Me.GroupBox14.Controls.Add(Me.Label16)
        Me.GroupBox14.Controls.Add(Me.Label12)
        Me.GroupBox14.Controls.Add(Me.lblRaid_SelectedRetroStatus_Msg24)
        Me.GroupBox14.Controls.Add(Me.Label7)
        Me.GroupBox14.Controls.Add(Me.lblRaid_SelectedLoadStatus_Msg24)
        Me.GroupBox14.Controls.Add(Me.lblRaidMsg15ShipId)
        Me.GroupBox14.Controls.Add(Me.Label11)
        Me.GroupBox14.Controls.Add(Me.butMsg15Advance)
        Me.GroupBox14.Controls.Add(Me.butMsg15SelectAll)
        Me.GroupBox14.Controls.Add(Me.butMsg15DeselectAll)
        Me.GroupBox14.Location = New System.Drawing.Point(578, 6)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(598, 68)
        Me.GroupBox14.TabIndex = 2
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "UL Removal (ShipULPickup)"
        '
        'txtShipULPickUp_Load_Flag
        '
        Me.txtShipULPickUp_Load_Flag.Location = New System.Drawing.Point(498, 33)
        Me.txtShipULPickUp_Load_Flag.Name = "txtShipULPickUp_Load_Flag"
        Me.txtShipULPickUp_Load_Flag.Size = New System.Drawing.Size(43, 20)
        Me.txtShipULPickUp_Load_Flag.TabIndex = 70
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(486, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 13)
        Me.Label16.TabIndex = 69
        Me.Label16.Text = "Load_Flag (Y,N,null):"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Retro Status:"
        '
        'lblRaid_SelectedRetroStatus_Msg24
        '
        Me.lblRaid_SelectedRetroStatus_Msg24.AutoSize = True
        Me.lblRaid_SelectedRetroStatus_Msg24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRaid_SelectedRetroStatus_Msg24.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblRaid_SelectedRetroStatus_Msg24.Location = New System.Drawing.Point(71, 48)
        Me.lblRaid_SelectedRetroStatus_Msg24.Name = "lblRaid_SelectedRetroStatus_Msg24"
        Me.lblRaid_SelectedRetroStatus_Msg24.Size = New System.Drawing.Size(17, 16)
        Me.lblRaid_SelectedRetroStatus_Msg24.TabIndex = 67
        Me.lblRaid_SelectedRetroStatus_Msg24.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Load Status:"
        '
        'lblRaid_SelectedLoadStatus_Msg24
        '
        Me.lblRaid_SelectedLoadStatus_Msg24.AutoSize = True
        Me.lblRaid_SelectedLoadStatus_Msg24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRaid_SelectedLoadStatus_Msg24.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblRaid_SelectedLoadStatus_Msg24.Location = New System.Drawing.Point(71, 28)
        Me.lblRaid_SelectedLoadStatus_Msg24.Name = "lblRaid_SelectedLoadStatus_Msg24"
        Me.lblRaid_SelectedLoadStatus_Msg24.Size = New System.Drawing.Size(17, 16)
        Me.lblRaid_SelectedLoadStatus_Msg24.TabIndex = 65
        Me.lblRaid_SelectedLoadStatus_Msg24.Text = "..."
        '
        'lblRaidMsg15ShipId
        '
        Me.lblRaidMsg15ShipId.AutoSize = True
        Me.lblRaidMsg15ShipId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRaidMsg15ShipId.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblRaidMsg15ShipId.Location = New System.Drawing.Point(71, 12)
        Me.lblRaidMsg15ShipId.Name = "lblRaidMsg15ShipId"
        Me.lblRaidMsg15ShipId.Size = New System.Drawing.Size(17, 16)
        Me.lblRaidMsg15ShipId.TabIndex = 64
        Me.lblRaidMsg15ShipId.Text = "..."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Shipid:"
        '
        'butMsg15Advance
        '
        Me.butMsg15Advance.Location = New System.Drawing.Point(369, 19)
        Me.butMsg15Advance.Name = "butMsg15Advance"
        Me.butMsg15Advance.Size = New System.Drawing.Size(84, 34)
        Me.butMsg15Advance.TabIndex = 1
        Me.butMsg15Advance.Text = "Advance"
        Me.butMsg15Advance.UseVisualStyleBackColor = True
        '
        'butMsg15SelectAll
        '
        Me.butMsg15SelectAll.Location = New System.Drawing.Point(189, 19)
        Me.butMsg15SelectAll.Name = "butMsg15SelectAll"
        Me.butMsg15SelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg15SelectAll.TabIndex = 4
        Me.butMsg15SelectAll.Text = "Select All"
        Me.butMsg15SelectAll.UseVisualStyleBackColor = True
        '
        'butMsg15DeselectAll
        '
        Me.butMsg15DeselectAll.Location = New System.Drawing.Point(279, 19)
        Me.butMsg15DeselectAll.Name = "butMsg15DeselectAll"
        Me.butMsg15DeselectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg15DeselectAll.TabIndex = 0
        Me.butMsg15DeselectAll.Text = "DeSelectAll"
        Me.butMsg15DeselectAll.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.butMsg24AutoSendOff)
        Me.GroupBox13.Controls.Add(Me.butMsg24AutoSendOn)
        Me.GroupBox13.Location = New System.Drawing.Point(494, 6)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(80, 68)
        Me.GroupBox13.TabIndex = 1
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Auto Mode"
        '
        'butMsg24AutoSendOff
        '
        Me.butMsg24AutoSendOff.Location = New System.Drawing.Point(14, 41)
        Me.butMsg24AutoSendOff.Name = "butMsg24AutoSendOff"
        Me.butMsg24AutoSendOff.Size = New System.Drawing.Size(40, 23)
        Me.butMsg24AutoSendOff.TabIndex = 1
        Me.butMsg24AutoSendOff.Text = "Off"
        '
        'butMsg24AutoSendOn
        '
        Me.butMsg24AutoSendOn.Location = New System.Drawing.Point(14, 15)
        Me.butMsg24AutoSendOn.Name = "butMsg24AutoSendOn"
        Me.butMsg24AutoSendOn.Size = New System.Drawing.Size(40, 23)
        Me.butMsg24AutoSendOn.TabIndex = 0
        Me.butMsg24AutoSendOn.Text = "On"
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.butMsg24Advance)
        Me.GroupBox12.Controls.Add(Me.butMsg24_Header_SelectAll)
        Me.GroupBox12.Controls.Add(Me.butMsg24_Header_DeSelectAll)
        Me.GroupBox12.Controls.Add(Me.butMsg24_GetData)
        Me.GroupBox12.Location = New System.Drawing.Point(15, 6)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(473, 68)
        Me.GroupBox12.TabIndex = 0
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Staging Completion Control"
        '
        'butMsg24Advance
        '
        Me.butMsg24Advance.Location = New System.Drawing.Point(274, 19)
        Me.butMsg24Advance.Name = "butMsg24Advance"
        Me.butMsg24Advance.Size = New System.Drawing.Size(84, 34)
        Me.butMsg24Advance.TabIndex = 3
        Me.butMsg24Advance.Text = "Advance"
        Me.butMsg24Advance.UseVisualStyleBackColor = True
        '
        'butMsg24_Header_SelectAll
        '
        Me.butMsg24_Header_SelectAll.Location = New System.Drawing.Point(94, 19)
        Me.butMsg24_Header_SelectAll.Name = "butMsg24_Header_SelectAll"
        Me.butMsg24_Header_SelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg24_Header_SelectAll.TabIndex = 1
        Me.butMsg24_Header_SelectAll.Text = "Select All"
        Me.butMsg24_Header_SelectAll.UseVisualStyleBackColor = True
        '
        'butMsg24_Header_DeSelectAll
        '
        Me.butMsg24_Header_DeSelectAll.Location = New System.Drawing.Point(184, 19)
        Me.butMsg24_Header_DeSelectAll.Name = "butMsg24_Header_DeSelectAll"
        Me.butMsg24_Header_DeSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg24_Header_DeSelectAll.TabIndex = 2
        Me.butMsg24_Header_DeSelectAll.Text = "DeSelectAll"
        Me.butMsg24_Header_DeSelectAll.UseVisualStyleBackColor = True
        '
        'butMsg24_GetData
        '
        Me.butMsg24_GetData.Location = New System.Drawing.Point(6, 19)
        Me.butMsg24_GetData.Name = "butMsg24_GetData"
        Me.butMsg24_GetData.Size = New System.Drawing.Size(84, 34)
        Me.butMsg24_GetData.TabIndex = 0
        Me.butMsg24_GetData.Text = "Get Data"
        Me.butMsg24_GetData.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.flxGrid5)
        Me.TabPage5.Controls.Add(Me.butMsg16_GetData)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage5.TabIndex = 6
        Me.TabPage5.Text = "QaChg History"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'flxGrid5
        '
        Me.flxGrid5.Location = New System.Drawing.Point(15, 80)
        Me.flxGrid5.Name = "flxGrid5"
        Me.flxGrid5.OcxState = CType(resources.GetObject("flxGrid5.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid5.Size = New System.Drawing.Size(725, 275)
        Me.flxGrid5.TabIndex = 59
        Me.flxGrid5.TabStop = False
        '
        'butMsg16_GetData
        '
        Me.butMsg16_GetData.Location = New System.Drawing.Point(15, 24)
        Me.butMsg16_GetData.Name = "butMsg16_GetData"
        Me.butMsg16_GetData.Size = New System.Drawing.Size(84, 34)
        Me.butMsg16_GetData.TabIndex = 0
        Me.butMsg16_GetData.Text = "Get Data"
        Me.butMsg16_GetData.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.Button2)
        Me.TabPage6.Controls.Add(Me.butMsg11_Send)
        Me.TabPage6.Controls.Add(Me.Label4)
        Me.TabPage6.Controls.Add(Me.Label5)
        Me.TabPage6.Controls.Add(Me.txtMsg11_Tech_Group)
        Me.TabPage6.Controls.Add(Me.Label3)
        Me.TabPage6.Controls.Add(Me.Label2)
        Me.TabPage6.Controls.Add(Me.txtMsg11_RDT_Message)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage6.TabIndex = 7
        Me.TabPage6.Text = "RF Broadcast"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(747, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 36)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'butMsg11_Send
        '
        Me.butMsg11_Send.Location = New System.Drawing.Point(101, 106)
        Me.butMsg11_Send.Name = "butMsg11_Send"
        Me.butMsg11_Send.Size = New System.Drawing.Size(84, 34)
        Me.butMsg11_Send.TabIndex = 2
        Me.butMsg11_Send.Text = "Send"
        Me.butMsg11_Send.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(487, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "(Max 9 Chars in RTCIS)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tech Group:"
        '
        'txtMsg11_Tech_Group
        '
        Me.txtMsg11_Tech_Group.Location = New System.Drawing.Point(101, 15)
        Me.txtMsg11_Tech_Group.Name = "txtMsg11_Tech_Group"
        Me.txtMsg11_Tech_Group.Size = New System.Drawing.Size(97, 20)
        Me.txtMsg11_Tech_Group.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(487, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "(Max 40 Chars in RTCIS)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "RDT Message:"
        '
        'txtMsg11_RDT_Message
        '
        Me.txtMsg11_RDT_Message.Location = New System.Drawing.Point(101, 41)
        Me.txtMsg11_RDT_Message.Name = "txtMsg11_RDT_Message"
        Me.txtMsg11_RDT_Message.Size = New System.Drawing.Size(380, 20)
        Me.txtMsg11_RDT_Message.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Transparent
        Me.TabPage3.Controls.Add(Me.GroupBox20)
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "Manual Output Req"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.txtUtil_DstLoc)
        Me.GroupBox20.Controls.Add(Me.Label29)
        Me.GroupBox20.Controls.Add(Me.txtUtil_Ulid)
        Me.GroupBox20.Controls.Add(Me.butUtil_MoveUl)
        Me.GroupBox20.Location = New System.Drawing.Point(1045, 6)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(228, 68)
        Me.GroupBox20.TabIndex = 68
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Move UL via HSTINB"
        '
        'txtUtil_DstLoc
        '
        Me.txtUtil_DstLoc.Location = New System.Drawing.Point(8, 45)
        Me.txtUtil_DstLoc.Name = "txtUtil_DstLoc"
        Me.txtUtil_DstLoc.Size = New System.Drawing.Size(76, 20)
        Me.txtUtil_DstLoc.TabIndex = 0
        Me.txtUtil_DstLoc.Text = "FPDS"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(90, 48)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(25, 13)
        Me.Label29.TabIndex = 60
        Me.Label29.Text = "Loc"
        '
        'txtUtil_Ulid
        '
        Me.txtUtil_Ulid.Location = New System.Drawing.Point(7, 19)
        Me.txtUtil_Ulid.Name = "txtUtil_Ulid"
        Me.txtUtil_Ulid.Size = New System.Drawing.Size(169, 20)
        Me.txtUtil_Ulid.TabIndex = 0
        '
        'butUtil_MoveUl
        '
        Me.butUtil_MoveUl.Location = New System.Drawing.Point(138, 44)
        Me.butUtil_MoveUl.Name = "butUtil_MoveUl"
        Me.butUtil_MoveUl.Size = New System.Drawing.Size(84, 21)
        Me.butUtil_MoveUl.TabIndex = 1
        Me.butUtil_MoveUl.Text = "Send"
        Me.butUtil_MoveUl.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.51592!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.48408!))
        Me.TableLayoutPanel2.Controls.Add(Me.flxGrid6, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.flxGrid7, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(15, 80)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1256, 327)
        Me.TableLayoutPanel2.TabIndex = 67
        '
        'flxGrid6
        '
        Me.flxGrid6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxGrid6.Location = New System.Drawing.Point(3, 3)
        Me.flxGrid6.Name = "flxGrid6"
        Me.flxGrid6.OcxState = CType(resources.GetObject("flxGrid6.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid6.Size = New System.Drawing.Size(527, 321)
        Me.flxGrid6.TabIndex = 64
        Me.flxGrid6.TabStop = False
        '
        'flxGrid7
        '
        Me.flxGrid7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxGrid7.Location = New System.Drawing.Point(536, 3)
        Me.flxGrid7.Name = "flxGrid7"
        Me.flxGrid7.OcxState = CType(resources.GetObject("flxGrid7.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid7.Size = New System.Drawing.Size(717, 321)
        Me.flxGrid7.TabIndex = 66
        Me.flxGrid7.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.butMsg14GetData)
        Me.GroupBox6.Controls.Add(Me.butMsg14Advance)
        Me.GroupBox6.Controls.Add(Me.butMsg14SelectAll)
        Me.GroupBox6.Controls.Add(Me.butMsg14DeselectAll)
        Me.GroupBox6.Location = New System.Drawing.Point(633, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(406, 68)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Msg14 Control "
        '
        'butMsg14GetData
        '
        Me.butMsg14GetData.Location = New System.Drawing.Point(6, 18)
        Me.butMsg14GetData.Name = "butMsg14GetData"
        Me.butMsg14GetData.Size = New System.Drawing.Size(84, 34)
        Me.butMsg14GetData.TabIndex = 0
        Me.butMsg14GetData.Text = "Get Data"
        Me.butMsg14GetData.UseVisualStyleBackColor = True
        '
        'butMsg14Advance
        '
        Me.butMsg14Advance.Location = New System.Drawing.Point(307, 18)
        Me.butMsg14Advance.Name = "butMsg14Advance"
        Me.butMsg14Advance.Size = New System.Drawing.Size(84, 34)
        Me.butMsg14Advance.TabIndex = 3
        Me.butMsg14Advance.Text = "Advance"
        Me.butMsg14Advance.UseVisualStyleBackColor = True
        '
        'butMsg14SelectAll
        '
        Me.butMsg14SelectAll.Location = New System.Drawing.Point(127, 18)
        Me.butMsg14SelectAll.Name = "butMsg14SelectAll"
        Me.butMsg14SelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg14SelectAll.TabIndex = 1
        Me.butMsg14SelectAll.Text = "Select All"
        Me.butMsg14SelectAll.UseVisualStyleBackColor = True
        '
        'butMsg14DeselectAll
        '
        Me.butMsg14DeselectAll.Location = New System.Drawing.Point(217, 18)
        Me.butMsg14DeselectAll.Name = "butMsg14DeselectAll"
        Me.butMsg14DeselectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg14DeselectAll.TabIndex = 2
        Me.butMsg14DeselectAll.Text = "DeSelectAll"
        Me.butMsg14DeselectAll.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.butMsg13AutoScanOff)
        Me.GroupBox4.Controls.Add(Me.butMsg13AutoScanOn)
        Me.GroupBox4.Location = New System.Drawing.Point(549, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(80, 68)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Auto Mode"
        '
        'butMsg13AutoScanOff
        '
        Me.butMsg13AutoScanOff.Location = New System.Drawing.Point(14, 41)
        Me.butMsg13AutoScanOff.Name = "butMsg13AutoScanOff"
        Me.butMsg13AutoScanOff.Size = New System.Drawing.Size(40, 23)
        Me.butMsg13AutoScanOff.TabIndex = 1
        Me.butMsg13AutoScanOff.Text = "Off"
        '
        'butMsg13AutoScanOn
        '
        Me.butMsg13AutoScanOn.Location = New System.Drawing.Point(14, 15)
        Me.butMsg13AutoScanOn.Name = "butMsg13AutoScanOn"
        Me.butMsg13AutoScanOn.Size = New System.Drawing.Size(40, 23)
        Me.butMsg13AutoScanOn.TabIndex = 0
        Me.butMsg13AutoScanOn.Text = "On"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.butMsg13Advance)
        Me.GroupBox5.Controls.Add(Me.butMsg13SelectAll)
        Me.GroupBox5.Controls.Add(Me.butMsg13RefreshData)
        Me.GroupBox5.Controls.Add(Me.butMsg13DeSelectAll)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(530, 68)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Msg13 Control "
        '
        'butMsg13Advance
        '
        Me.butMsg13Advance.Location = New System.Drawing.Point(274, 18)
        Me.butMsg13Advance.Name = "butMsg13Advance"
        Me.butMsg13Advance.Size = New System.Drawing.Size(84, 34)
        Me.butMsg13Advance.TabIndex = 3
        Me.butMsg13Advance.Text = "Advance"
        Me.butMsg13Advance.UseVisualStyleBackColor = True
        '
        'butMsg13SelectAll
        '
        Me.butMsg13SelectAll.Location = New System.Drawing.Point(94, 18)
        Me.butMsg13SelectAll.Name = "butMsg13SelectAll"
        Me.butMsg13SelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg13SelectAll.TabIndex = 1
        Me.butMsg13SelectAll.Text = "Select All"
        Me.butMsg13SelectAll.UseVisualStyleBackColor = True
        '
        'butMsg13RefreshData
        '
        Me.butMsg13RefreshData.Location = New System.Drawing.Point(4, 18)
        Me.butMsg13RefreshData.Name = "butMsg13RefreshData"
        Me.butMsg13RefreshData.Size = New System.Drawing.Size(84, 34)
        Me.butMsg13RefreshData.TabIndex = 0
        Me.butMsg13RefreshData.Text = "Get Data"
        Me.butMsg13RefreshData.UseVisualStyleBackColor = True
        '
        'butMsg13DeSelectAll
        '
        Me.butMsg13DeSelectAll.Location = New System.Drawing.Point(184, 18)
        Me.butMsg13DeSelectAll.Name = "butMsg13DeSelectAll"
        Me.butMsg13DeSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butMsg13DeSelectAll.TabIndex = 2
        Me.butMsg13DeSelectAll.Text = "DeSelectAll"
        Me.butMsg13DeSelectAll.UseVisualStyleBackColor = True
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.flxGrid12)
        Me.TabPage9.Controls.Add(Me.butReconcile)
        Me.TabPage9.Controls.Add(Me.Label32)
        Me.TabPage9.Controls.Add(Me.txtReconcileItmCod)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage9.TabIndex = 10
        Me.TabPage9.Text = "Reconcile"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'flxGrid12
        '
        Me.flxGrid12.Location = New System.Drawing.Point(18, 54)
        Me.flxGrid12.Name = "flxGrid12"
        Me.flxGrid12.OcxState = CType(resources.GetObject("flxGrid12.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid12.Size = New System.Drawing.Size(967, 345)
        Me.flxGrid12.TabIndex = 1
        '
        'butReconcile
        '
        Me.butReconcile.Location = New System.Drawing.Point(188, 3)
        Me.butReconcile.Name = "butReconcile"
        Me.butReconcile.Size = New System.Drawing.Size(84, 34)
        Me.butReconcile.TabIndex = 0
        Me.butReconcile.Text = "Reconcile"
        Me.butReconcile.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(15, 14)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(55, 13)
        Me.Label32.TabIndex = 66
        Me.Label32.Text = "Item Code"
        '
        'txtReconcileItmCod
        '
        Me.txtReconcileItmCod.Location = New System.Drawing.Point(76, 11)
        Me.txtReconcileItmCod.Name = "txtReconcileItmCod"
        Me.txtReconcileItmCod.Size = New System.Drawing.Size(106, 20)
        Me.txtReconcileItmCod.TabIndex = 65
        '
        'TabPage10
        '
        Me.TabPage10.Controls.Add(Me.lblE10Title)
        Me.TabPage10.Controls.Add(Me.lblG10Title)
        Me.TabPage10.Controls.Add(Me.lblE10)
        Me.TabPage10.Controls.Add(Me.linE10)
        Me.TabPage10.Controls.Add(Me.linG10)
        Me.TabPage10.Controls.Add(Me.lblG10)
        Me.TabPage10.Controls.Add(Me.lblE09Title)
        Me.TabPage10.Controls.Add(Me.lblG09Title)
        Me.TabPage10.Controls.Add(Me.lblE09)
        Me.TabPage10.Controls.Add(Me.linE09)
        Me.TabPage10.Controls.Add(Me.linG09)
        Me.TabPage10.Controls.Add(Me.lblG09)
        Me.TabPage10.Controls.Add(Me.butGetGraphicalData)
        Me.TabPage10.Controls.Add(Me.lblE08Title)
        Me.TabPage10.Controls.Add(Me.lblE07Title)
        Me.TabPage10.Controls.Add(Me.lblE06Title)
        Me.TabPage10.Controls.Add(Me.lblE05Title)
        Me.TabPage10.Controls.Add(Me.lblE04Title)
        Me.TabPage10.Controls.Add(Me.lblE03Title)
        Me.TabPage10.Controls.Add(Me.lblE02Title)
        Me.TabPage10.Controls.Add(Me.lblE01Title)
        Me.TabPage10.Controls.Add(Me.lblG08Title)
        Me.TabPage10.Controls.Add(Me.lblG07Title)
        Me.TabPage10.Controls.Add(Me.lblG06Title)
        Me.TabPage10.Controls.Add(Me.lblG05Title)
        Me.TabPage10.Controls.Add(Me.lblG04Title)
        Me.TabPage10.Controls.Add(Me.lblG03Title)
        Me.TabPage10.Controls.Add(Me.lblG02Title)
        Me.TabPage10.Controls.Add(Me.lblG01Title)
        Me.TabPage10.Controls.Add(Me.lblE08)
        Me.TabPage10.Controls.Add(Me.lblE07)
        Me.TabPage10.Controls.Add(Me.lblE06)
        Me.TabPage10.Controls.Add(Me.lblE05)
        Me.TabPage10.Controls.Add(Me.lblE04)
        Me.TabPage10.Controls.Add(Me.lblE03)
        Me.TabPage10.Controls.Add(Me.lblE02)
        Me.TabPage10.Controls.Add(Me.lblE01)
        Me.TabPage10.Controls.Add(Me.linE08)
        Me.TabPage10.Controls.Add(Me.linE07)
        Me.TabPage10.Controls.Add(Me.linE06)
        Me.TabPage10.Controls.Add(Me.linE05)
        Me.TabPage10.Controls.Add(Me.linE04)
        Me.TabPage10.Controls.Add(Me.linE03)
        Me.TabPage10.Controls.Add(Me.linE02)
        Me.TabPage10.Controls.Add(Me.linE01)
        Me.TabPage10.Controls.Add(Me.linG08)
        Me.TabPage10.Controls.Add(Me.lblG08)
        Me.TabPage10.Controls.Add(Me.linG07)
        Me.TabPage10.Controls.Add(Me.lblG07)
        Me.TabPage10.Controls.Add(Me.linG06)
        Me.TabPage10.Controls.Add(Me.lblG06)
        Me.TabPage10.Controls.Add(Me.linG05)
        Me.TabPage10.Controls.Add(Me.lblG05)
        Me.TabPage10.Controls.Add(Me.linG04)
        Me.TabPage10.Controls.Add(Me.lblG04)
        Me.TabPage10.Controls.Add(Me.linG03)
        Me.TabPage10.Controls.Add(Me.lblG03)
        Me.TabPage10.Controls.Add(Me.linG02)
        Me.TabPage10.Controls.Add(Me.lblG02)
        Me.TabPage10.Controls.Add(Me.linG01)
        Me.TabPage10.Controls.Add(Me.linMain)
        Me.TabPage10.Controls.Add(Me.lblG01)
        Me.TabPage10.Location = New System.Drawing.Point(4, 22)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage10.TabIndex = 11
        Me.TabPage10.Text = "UL GUI"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'lblE10Title
        '
        Me.lblE10Title.Location = New System.Drawing.Point(877, 327)
        Me.lblE10Title.Name = "lblE10Title"
        Me.lblE10Title.Size = New System.Drawing.Size(78, 48)
        Me.lblE10Title.TabIndex = 145
        Me.lblE10Title.Text = "NA"
        Me.lblE10Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE10Title.Visible = False
        '
        'lblG10Title
        '
        Me.lblG10Title.Location = New System.Drawing.Point(877, 47)
        Me.lblG10Title.Name = "lblG10Title"
        Me.lblG10Title.Size = New System.Drawing.Size(78, 38)
        Me.lblG10Title.TabIndex = 144
        Me.lblG10Title.Text = "NA"
        Me.lblG10Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblE10
        '
        Me.lblE10.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblE10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblE10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE10.Location = New System.Drawing.Point(877, 250)
        Me.lblE10.Name = "lblE10"
        Me.lblE10.Size = New System.Drawing.Size(78, 69)
        Me.lblE10.TabIndex = 143
        Me.lblE10.Text = "0"
        Me.lblE10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE10.Visible = False
        '
        'linE10
        '
        Me.linE10.BackColor = System.Drawing.SystemColors.ControlText
        Me.linE10.Location = New System.Drawing.Point(910, 210)
        Me.linE10.Name = "linE10"
        Me.linE10.Size = New System.Drawing.Size(10, 40)
        Me.linE10.TabIndex = 142
        Me.linE10.Visible = False
        '
        'linG10
        '
        Me.linG10.BackColor = System.Drawing.SystemColors.ControlText
        Me.linG10.Location = New System.Drawing.Point(910, 161)
        Me.linG10.Name = "linG10"
        Me.linG10.Size = New System.Drawing.Size(10, 40)
        Me.linG10.TabIndex = 141
        '
        'lblG10
        '
        Me.lblG10.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblG10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG10.Location = New System.Drawing.Point(877, 92)
        Me.lblG10.Name = "lblG10"
        Me.lblG10.Size = New System.Drawing.Size(78, 69)
        Me.lblG10.TabIndex = 140
        Me.lblG10.Text = "0"
        Me.lblG10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblE09Title
        '
        Me.lblE09Title.Location = New System.Drawing.Point(784, 327)
        Me.lblE09Title.Name = "lblE09Title"
        Me.lblE09Title.Size = New System.Drawing.Size(78, 48)
        Me.lblE09Title.TabIndex = 139
        Me.lblE09Title.Text = "NA"
        Me.lblE09Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE09Title.Visible = False
        '
        'lblG09Title
        '
        Me.lblG09Title.Location = New System.Drawing.Point(784, 47)
        Me.lblG09Title.Name = "lblG09Title"
        Me.lblG09Title.Size = New System.Drawing.Size(78, 38)
        Me.lblG09Title.TabIndex = 138
        Me.lblG09Title.Text = "NA"
        Me.lblG09Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblE09
        '
        Me.lblE09.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblE09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblE09.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE09.Location = New System.Drawing.Point(784, 250)
        Me.lblE09.Name = "lblE09"
        Me.lblE09.Size = New System.Drawing.Size(78, 69)
        Me.lblE09.TabIndex = 137
        Me.lblE09.Text = "0"
        Me.lblE09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE09.Visible = False
        '
        'linE09
        '
        Me.linE09.BackColor = System.Drawing.SystemColors.ControlText
        Me.linE09.Location = New System.Drawing.Point(817, 210)
        Me.linE09.Name = "linE09"
        Me.linE09.Size = New System.Drawing.Size(10, 40)
        Me.linE09.TabIndex = 136
        Me.linE09.Visible = False
        '
        'linG09
        '
        Me.linG09.BackColor = System.Drawing.SystemColors.ControlText
        Me.linG09.Location = New System.Drawing.Point(817, 161)
        Me.linG09.Name = "linG09"
        Me.linG09.Size = New System.Drawing.Size(10, 40)
        Me.linG09.TabIndex = 135
        '
        'lblG09
        '
        Me.lblG09.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblG09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG09.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG09.Location = New System.Drawing.Point(784, 92)
        Me.lblG09.Name = "lblG09"
        Me.lblG09.Size = New System.Drawing.Size(78, 69)
        Me.lblG09.TabIndex = 134
        Me.lblG09.Text = "0"
        Me.lblG09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'butGetGraphicalData
        '
        Me.butGetGraphicalData.Location = New System.Drawing.Point(17, 19)
        Me.butGetGraphicalData.Name = "butGetGraphicalData"
        Me.butGetGraphicalData.Size = New System.Drawing.Size(84, 34)
        Me.butGetGraphicalData.TabIndex = 133
        Me.butGetGraphicalData.Text = "Get Data"
        Me.butGetGraphicalData.UseVisualStyleBackColor = True
        '
        'lblE08Title
        '
        Me.lblE08Title.Location = New System.Drawing.Point(691, 327)
        Me.lblE08Title.Name = "lblE08Title"
        Me.lblE08Title.Size = New System.Drawing.Size(78, 48)
        Me.lblE08Title.TabIndex = 132
        Me.lblE08Title.Text = "NA"
        Me.lblE08Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE08Title.Visible = False
        '
        'lblE07Title
        '
        Me.lblE07Title.Location = New System.Drawing.Point(596, 327)
        Me.lblE07Title.Name = "lblE07Title"
        Me.lblE07Title.Size = New System.Drawing.Size(78, 48)
        Me.lblE07Title.TabIndex = 131
        Me.lblE07Title.Text = "NA"
        Me.lblE07Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE07Title.Visible = False
        '
        'lblE06Title
        '
        Me.lblE06Title.Location = New System.Drawing.Point(502, 327)
        Me.lblE06Title.Name = "lblE06Title"
        Me.lblE06Title.Size = New System.Drawing.Size(78, 48)
        Me.lblE06Title.TabIndex = 130
        Me.lblE06Title.Text = "NA"
        Me.lblE06Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE06Title.Visible = False
        '
        'lblE05Title
        '
        Me.lblE05Title.Location = New System.Drawing.Point(407, 327)
        Me.lblE05Title.Name = "lblE05Title"
        Me.lblE05Title.Size = New System.Drawing.Size(78, 48)
        Me.lblE05Title.TabIndex = 129
        Me.lblE05Title.Text = "NA"
        Me.lblE05Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE05Title.Visible = False
        '
        'lblE04Title
        '
        Me.lblE04Title.Location = New System.Drawing.Point(314, 327)
        Me.lblE04Title.Name = "lblE04Title"
        Me.lblE04Title.Size = New System.Drawing.Size(78, 48)
        Me.lblE04Title.TabIndex = 128
        Me.lblE04Title.Text = "NA"
        Me.lblE04Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE04Title.Visible = False
        '
        'lblE03Title
        '
        Me.lblE03Title.Location = New System.Drawing.Point(219, 327)
        Me.lblE03Title.Name = "lblE03Title"
        Me.lblE03Title.Size = New System.Drawing.Size(78, 48)
        Me.lblE03Title.TabIndex = 127
        Me.lblE03Title.Text = "NA"
        Me.lblE03Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE03Title.Visible = False
        '
        'lblE02Title
        '
        Me.lblE02Title.Location = New System.Drawing.Point(122, 327)
        Me.lblE02Title.Name = "lblE02Title"
        Me.lblE02Title.Size = New System.Drawing.Size(78, 48)
        Me.lblE02Title.TabIndex = 126
        Me.lblE02Title.Text = "NA"
        Me.lblE02Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE02Title.Visible = False
        '
        'lblE01Title
        '
        Me.lblE01Title.Location = New System.Drawing.Point(27, 327)
        Me.lblE01Title.Name = "lblE01Title"
        Me.lblE01Title.Size = New System.Drawing.Size(78, 48)
        Me.lblE01Title.TabIndex = 125
        Me.lblE01Title.Text = "NA"
        Me.lblE01Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE01Title.Visible = False
        '
        'lblG08Title
        '
        Me.lblG08Title.Location = New System.Drawing.Point(691, 47)
        Me.lblG08Title.Name = "lblG08Title"
        Me.lblG08Title.Size = New System.Drawing.Size(78, 38)
        Me.lblG08Title.TabIndex = 124
        Me.lblG08Title.Text = "NA"
        Me.lblG08Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblG07Title
        '
        Me.lblG07Title.Location = New System.Drawing.Point(596, 47)
        Me.lblG07Title.Name = "lblG07Title"
        Me.lblG07Title.Size = New System.Drawing.Size(78, 38)
        Me.lblG07Title.TabIndex = 123
        Me.lblG07Title.Text = "NA"
        Me.lblG07Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblG06Title
        '
        Me.lblG06Title.Location = New System.Drawing.Point(502, 47)
        Me.lblG06Title.Name = "lblG06Title"
        Me.lblG06Title.Size = New System.Drawing.Size(78, 38)
        Me.lblG06Title.TabIndex = 122
        Me.lblG06Title.Text = "NA"
        Me.lblG06Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblG05Title
        '
        Me.lblG05Title.Location = New System.Drawing.Point(407, 47)
        Me.lblG05Title.Name = "lblG05Title"
        Me.lblG05Title.Size = New System.Drawing.Size(78, 38)
        Me.lblG05Title.TabIndex = 121
        Me.lblG05Title.Text = "NA"
        Me.lblG05Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblG04Title
        '
        Me.lblG04Title.Location = New System.Drawing.Point(314, 47)
        Me.lblG04Title.Name = "lblG04Title"
        Me.lblG04Title.Size = New System.Drawing.Size(78, 38)
        Me.lblG04Title.TabIndex = 120
        Me.lblG04Title.Text = "NA"
        Me.lblG04Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblG03Title
        '
        Me.lblG03Title.Location = New System.Drawing.Point(219, 47)
        Me.lblG03Title.Name = "lblG03Title"
        Me.lblG03Title.Size = New System.Drawing.Size(78, 38)
        Me.lblG03Title.TabIndex = 119
        Me.lblG03Title.Text = "NA"
        Me.lblG03Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblG02Title
        '
        Me.lblG02Title.Location = New System.Drawing.Point(122, 47)
        Me.lblG02Title.Name = "lblG02Title"
        Me.lblG02Title.Size = New System.Drawing.Size(78, 38)
        Me.lblG02Title.TabIndex = 118
        Me.lblG02Title.Text = "NA"
        Me.lblG02Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblG01Title
        '
        Me.lblG01Title.Location = New System.Drawing.Point(27, 47)
        Me.lblG01Title.Name = "lblG01Title"
        Me.lblG01Title.Size = New System.Drawing.Size(78, 38)
        Me.lblG01Title.TabIndex = 117
        Me.lblG01Title.Text = "NA"
        Me.lblG01Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblE08
        '
        Me.lblE08.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblE08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblE08.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE08.Location = New System.Drawing.Point(691, 250)
        Me.lblE08.Name = "lblE08"
        Me.lblE08.Size = New System.Drawing.Size(78, 69)
        Me.lblE08.TabIndex = 116
        Me.lblE08.Text = "0"
        Me.lblE08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE08.Visible = False
        '
        'lblE07
        '
        Me.lblE07.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblE07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblE07.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE07.Location = New System.Drawing.Point(596, 250)
        Me.lblE07.Name = "lblE07"
        Me.lblE07.Size = New System.Drawing.Size(78, 69)
        Me.lblE07.TabIndex = 115
        Me.lblE07.Text = "0"
        Me.lblE07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE07.Visible = False
        '
        'lblE06
        '
        Me.lblE06.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblE06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblE06.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE06.Location = New System.Drawing.Point(502, 250)
        Me.lblE06.Name = "lblE06"
        Me.lblE06.Size = New System.Drawing.Size(78, 69)
        Me.lblE06.TabIndex = 114
        Me.lblE06.Text = "0"
        Me.lblE06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE06.Visible = False
        '
        'lblE05
        '
        Me.lblE05.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblE05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblE05.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE05.Location = New System.Drawing.Point(407, 250)
        Me.lblE05.Name = "lblE05"
        Me.lblE05.Size = New System.Drawing.Size(78, 69)
        Me.lblE05.TabIndex = 113
        Me.lblE05.Text = "0"
        Me.lblE05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE05.Visible = False
        '
        'lblE04
        '
        Me.lblE04.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblE04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblE04.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE04.Location = New System.Drawing.Point(314, 250)
        Me.lblE04.Name = "lblE04"
        Me.lblE04.Size = New System.Drawing.Size(78, 69)
        Me.lblE04.TabIndex = 112
        Me.lblE04.Text = "0"
        Me.lblE04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE04.Visible = False
        '
        'lblE03
        '
        Me.lblE03.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblE03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblE03.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE03.Location = New System.Drawing.Point(219, 250)
        Me.lblE03.Name = "lblE03"
        Me.lblE03.Size = New System.Drawing.Size(78, 69)
        Me.lblE03.TabIndex = 111
        Me.lblE03.Text = "0"
        Me.lblE03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE03.Visible = False
        '
        'lblE02
        '
        Me.lblE02.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblE02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblE02.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE02.Location = New System.Drawing.Point(122, 250)
        Me.lblE02.Name = "lblE02"
        Me.lblE02.Size = New System.Drawing.Size(78, 69)
        Me.lblE02.TabIndex = 110
        Me.lblE02.Text = "0"
        Me.lblE02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE02.Visible = False
        '
        'lblE01
        '
        Me.lblE01.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblE01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblE01.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE01.Location = New System.Drawing.Point(27, 250)
        Me.lblE01.Name = "lblE01"
        Me.lblE01.Size = New System.Drawing.Size(78, 69)
        Me.lblE01.TabIndex = 109
        Me.lblE01.Text = "0"
        Me.lblE01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblE01.Visible = False
        '
        'linE08
        '
        Me.linE08.BackColor = System.Drawing.SystemColors.ControlText
        Me.linE08.Location = New System.Drawing.Point(724, 210)
        Me.linE08.Name = "linE08"
        Me.linE08.Size = New System.Drawing.Size(10, 40)
        Me.linE08.TabIndex = 108
        Me.linE08.Visible = False
        '
        'linE07
        '
        Me.linE07.BackColor = System.Drawing.SystemColors.ControlText
        Me.linE07.Location = New System.Drawing.Point(629, 210)
        Me.linE07.Name = "linE07"
        Me.linE07.Size = New System.Drawing.Size(10, 40)
        Me.linE07.TabIndex = 107
        Me.linE07.Visible = False
        '
        'linE06
        '
        Me.linE06.BackColor = System.Drawing.SystemColors.ControlText
        Me.linE06.Location = New System.Drawing.Point(536, 210)
        Me.linE06.Name = "linE06"
        Me.linE06.Size = New System.Drawing.Size(10, 40)
        Me.linE06.TabIndex = 106
        Me.linE06.Visible = False
        '
        'linE05
        '
        Me.linE05.BackColor = System.Drawing.SystemColors.ControlText
        Me.linE05.Location = New System.Drawing.Point(443, 210)
        Me.linE05.Name = "linE05"
        Me.linE05.Size = New System.Drawing.Size(10, 40)
        Me.linE05.TabIndex = 105
        Me.linE05.Visible = False
        '
        'linE04
        '
        Me.linE04.BackColor = System.Drawing.SystemColors.ControlText
        Me.linE04.Location = New System.Drawing.Point(351, 210)
        Me.linE04.Name = "linE04"
        Me.linE04.Size = New System.Drawing.Size(10, 40)
        Me.linE04.TabIndex = 104
        Me.linE04.Visible = False
        '
        'linE03
        '
        Me.linE03.BackColor = System.Drawing.SystemColors.ControlText
        Me.linE03.Controls.Add(Me.Panel13)
        Me.linE03.Location = New System.Drawing.Point(252, 210)
        Me.linE03.Name = "linE03"
        Me.linE03.Size = New System.Drawing.Size(10, 40)
        Me.linE03.TabIndex = 103
        Me.linE03.Visible = False
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel13.Location = New System.Drawing.Point(-317, 9)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(10, 40)
        Me.Panel13.TabIndex = 19
        '
        'linE02
        '
        Me.linE02.BackColor = System.Drawing.SystemColors.ControlText
        Me.linE02.Controls.Add(Me.Panel5)
        Me.linE02.Controls.Add(Me.Panel9)
        Me.linE02.Controls.Add(Me.Panel10)
        Me.linE02.Location = New System.Drawing.Point(151, 210)
        Me.linE02.Name = "linE02"
        Me.linE02.Size = New System.Drawing.Size(10, 40)
        Me.linE02.TabIndex = 102
        Me.linE02.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel5.Location = New System.Drawing.Point(-125, 9)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(10, 40)
        Me.Panel5.TabIndex = 21
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel9.Location = New System.Drawing.Point(-222, 9)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(10, 40)
        Me.Panel9.TabIndex = 20
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel10.Location = New System.Drawing.Point(-317, 9)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(10, 40)
        Me.Panel10.TabIndex = 19
        '
        'linE01
        '
        Me.linE01.BackColor = System.Drawing.SystemColors.ControlText
        Me.linE01.Controls.Add(Me.Panel2)
        Me.linE01.Controls.Add(Me.Panel3)
        Me.linE01.Controls.Add(Me.Panel4)
        Me.linE01.Location = New System.Drawing.Point(60, 210)
        Me.linE01.Name = "linE01"
        Me.linE01.Size = New System.Drawing.Size(10, 40)
        Me.linE01.TabIndex = 101
        Me.linE01.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel2.Location = New System.Drawing.Point(-125, 9)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 40)
        Me.Panel2.TabIndex = 21
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel3.Location = New System.Drawing.Point(-222, 9)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(10, 40)
        Me.Panel3.TabIndex = 20
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel4.Location = New System.Drawing.Point(-317, 9)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(10, 40)
        Me.Panel4.TabIndex = 19
        '
        'linG08
        '
        Me.linG08.BackColor = System.Drawing.SystemColors.ControlText
        Me.linG08.Location = New System.Drawing.Point(724, 161)
        Me.linG08.Name = "linG08"
        Me.linG08.Size = New System.Drawing.Size(10, 40)
        Me.linG08.TabIndex = 100
        '
        'lblG08
        '
        Me.lblG08.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblG08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG08.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG08.Location = New System.Drawing.Point(691, 92)
        Me.lblG08.Name = "lblG08"
        Me.lblG08.Size = New System.Drawing.Size(78, 69)
        Me.lblG08.TabIndex = 99
        Me.lblG08.Text = "0"
        Me.lblG08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linG07
        '
        Me.linG07.BackColor = System.Drawing.SystemColors.ControlText
        Me.linG07.Location = New System.Drawing.Point(629, 161)
        Me.linG07.Name = "linG07"
        Me.linG07.Size = New System.Drawing.Size(10, 40)
        Me.linG07.TabIndex = 98
        '
        'lblG07
        '
        Me.lblG07.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblG07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG07.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG07.Location = New System.Drawing.Point(596, 92)
        Me.lblG07.Name = "lblG07"
        Me.lblG07.Size = New System.Drawing.Size(78, 69)
        Me.lblG07.TabIndex = 97
        Me.lblG07.Text = "0"
        Me.lblG07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linG06
        '
        Me.linG06.BackColor = System.Drawing.SystemColors.ControlText
        Me.linG06.Location = New System.Drawing.Point(536, 161)
        Me.linG06.Name = "linG06"
        Me.linG06.Size = New System.Drawing.Size(10, 40)
        Me.linG06.TabIndex = 96
        '
        'lblG06
        '
        Me.lblG06.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblG06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG06.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG06.Location = New System.Drawing.Point(502, 92)
        Me.lblG06.Name = "lblG06"
        Me.lblG06.Size = New System.Drawing.Size(78, 69)
        Me.lblG06.TabIndex = 95
        Me.lblG06.Text = "0"
        Me.lblG06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linG05
        '
        Me.linG05.BackColor = System.Drawing.SystemColors.ControlText
        Me.linG05.Location = New System.Drawing.Point(443, 161)
        Me.linG05.Name = "linG05"
        Me.linG05.Size = New System.Drawing.Size(10, 40)
        Me.linG05.TabIndex = 94
        '
        'lblG05
        '
        Me.lblG05.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblG05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG05.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG05.Location = New System.Drawing.Point(407, 92)
        Me.lblG05.Name = "lblG05"
        Me.lblG05.Size = New System.Drawing.Size(78, 69)
        Me.lblG05.TabIndex = 93
        Me.lblG05.Text = "0"
        Me.lblG05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linG04
        '
        Me.linG04.BackColor = System.Drawing.SystemColors.ControlText
        Me.linG04.Location = New System.Drawing.Point(351, 161)
        Me.linG04.Name = "linG04"
        Me.linG04.Size = New System.Drawing.Size(10, 40)
        Me.linG04.TabIndex = 92
        '
        'lblG04
        '
        Me.lblG04.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblG04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG04.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG04.Location = New System.Drawing.Point(314, 92)
        Me.lblG04.Name = "lblG04"
        Me.lblG04.Size = New System.Drawing.Size(78, 69)
        Me.lblG04.TabIndex = 91
        Me.lblG04.Text = "0"
        Me.lblG04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linG03
        '
        Me.linG03.BackColor = System.Drawing.SystemColors.ControlText
        Me.linG03.Location = New System.Drawing.Point(252, 161)
        Me.linG03.Name = "linG03"
        Me.linG03.Size = New System.Drawing.Size(10, 40)
        Me.linG03.TabIndex = 90
        '
        'lblG03
        '
        Me.lblG03.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblG03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG03.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG03.Location = New System.Drawing.Point(219, 92)
        Me.lblG03.Name = "lblG03"
        Me.lblG03.Size = New System.Drawing.Size(78, 69)
        Me.lblG03.TabIndex = 89
        Me.lblG03.Text = "0"
        Me.lblG03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linG02
        '
        Me.linG02.BackColor = System.Drawing.SystemColors.ControlText
        Me.linG02.Location = New System.Drawing.Point(151, 161)
        Me.linG02.Name = "linG02"
        Me.linG02.Size = New System.Drawing.Size(10, 40)
        Me.linG02.TabIndex = 88
        '
        'lblG02
        '
        Me.lblG02.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblG02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG02.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG02.Location = New System.Drawing.Point(122, 92)
        Me.lblG02.Name = "lblG02"
        Me.lblG02.Size = New System.Drawing.Size(78, 69)
        Me.lblG02.TabIndex = 87
        Me.lblG02.Text = "0"
        Me.lblG02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linG01
        '
        Me.linG01.BackColor = System.Drawing.SystemColors.ControlText
        Me.linG01.Controls.Add(Me.Panel6)
        Me.linG01.Controls.Add(Me.Panel1)
        Me.linG01.Controls.Add(Me.Panel11)
        Me.linG01.Location = New System.Drawing.Point(60, 161)
        Me.linG01.Name = "linG01"
        Me.linG01.Size = New System.Drawing.Size(10, 40)
        Me.linG01.TabIndex = 86
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel6.Location = New System.Drawing.Point(-125, 9)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(10, 40)
        Me.Panel6.TabIndex = 21
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel1.Location = New System.Drawing.Point(-222, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 40)
        Me.Panel1.TabIndex = 20
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel11.Location = New System.Drawing.Point(-317, 9)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(10, 40)
        Me.Panel11.TabIndex = 19
        '
        'lblG01
        '
        Me.lblG01.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblG01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG01.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG01.Location = New System.Drawing.Point(27, 92)
        Me.lblG01.Name = "lblG01"
        Me.lblG01.Size = New System.Drawing.Size(78, 69)
        Me.lblG01.TabIndex = 84
        Me.lblG01.Text = "0"
        Me.lblG01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage11
        '
        Me.TabPage11.Controls.Add(Me.TableLayoutPanel6)
        Me.TabPage11.Location = New System.Drawing.Point(4, 22)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage11.TabIndex = 12
        Me.TabPage11.Text = "FPDS Request"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.64013!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.35987!))
        Me.TableLayoutPanel6.Controls.Add(Me.grpFPDSControl, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.flxGrid13, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.GroupBox17, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.flxGrid14, 1, 1)
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(15, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.3727!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.6273!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(1228, 381)
        Me.TableLayoutPanel6.TabIndex = 2
        '
        'grpFPDSControl
        '
        Me.grpFPDSControl.Controls.Add(Me.cmdFPDSAdvance)
        Me.grpFPDSControl.Controls.Add(Me.GroupBox18)
        Me.grpFPDSControl.Controls.Add(Me.cmdFPDSSelectAll)
        Me.grpFPDSControl.Controls.Add(Me.cmdFPDSDeSelectAll)
        Me.grpFPDSControl.Controls.Add(Me.butRefreshFPDS)
        Me.grpFPDSControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFPDSControl.Location = New System.Drawing.Point(3, 3)
        Me.grpFPDSControl.Name = "grpFPDSControl"
        Me.grpFPDSControl.Size = New System.Drawing.Size(505, 60)
        Me.grpFPDSControl.TabIndex = 1
        Me.grpFPDSControl.TabStop = False
        Me.grpFPDSControl.Text = "Conveyor Input Location Control"
        '
        'cmdFPDSAdvance
        '
        Me.cmdFPDSAdvance.Location = New System.Drawing.Point(294, 19)
        Me.cmdFPDSAdvance.Name = "cmdFPDSAdvance"
        Me.cmdFPDSAdvance.Size = New System.Drawing.Size(84, 34)
        Me.cmdFPDSAdvance.TabIndex = 3
        Me.cmdFPDSAdvance.Text = "Advance"
        Me.cmdFPDSAdvance.UseVisualStyleBackColor = True
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.btnFPDSAutoScanOn)
        Me.GroupBox18.Controls.Add(Me.btnFPDSAutoScanOff)
        Me.GroupBox18.Location = New System.Drawing.Point(384, 7)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(107, 48)
        Me.GroupBox18.TabIndex = 1
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Auto Mode"
        '
        'btnFPDSAutoScanOn
        '
        Me.btnFPDSAutoScanOn.Location = New System.Drawing.Point(10, 18)
        Me.btnFPDSAutoScanOn.Name = "btnFPDSAutoScanOn"
        Me.btnFPDSAutoScanOn.Size = New System.Drawing.Size(40, 23)
        Me.btnFPDSAutoScanOn.TabIndex = 0
        Me.btnFPDSAutoScanOn.Text = "On"
        '
        'btnFPDSAutoScanOff
        '
        Me.btnFPDSAutoScanOff.Location = New System.Drawing.Point(57, 18)
        Me.btnFPDSAutoScanOff.Name = "btnFPDSAutoScanOff"
        Me.btnFPDSAutoScanOff.Size = New System.Drawing.Size(40, 23)
        Me.btnFPDSAutoScanOff.TabIndex = 1
        Me.btnFPDSAutoScanOff.Text = "Off"
        '
        'cmdFPDSSelectAll
        '
        Me.cmdFPDSSelectAll.Location = New System.Drawing.Point(114, 19)
        Me.cmdFPDSSelectAll.Name = "cmdFPDSSelectAll"
        Me.cmdFPDSSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.cmdFPDSSelectAll.TabIndex = 1
        Me.cmdFPDSSelectAll.Text = "Select All"
        Me.cmdFPDSSelectAll.UseVisualStyleBackColor = True
        '
        'cmdFPDSDeSelectAll
        '
        Me.cmdFPDSDeSelectAll.Location = New System.Drawing.Point(204, 19)
        Me.cmdFPDSDeSelectAll.Name = "cmdFPDSDeSelectAll"
        Me.cmdFPDSDeSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.cmdFPDSDeSelectAll.TabIndex = 2
        Me.cmdFPDSDeSelectAll.Text = "DeSelectAll"
        Me.cmdFPDSDeSelectAll.UseVisualStyleBackColor = True
        '
        'butRefreshFPDS
        '
        Me.butRefreshFPDS.Location = New System.Drawing.Point(6, 19)
        Me.butRefreshFPDS.Name = "butRefreshFPDS"
        Me.butRefreshFPDS.Size = New System.Drawing.Size(84, 34)
        Me.butRefreshFPDS.TabIndex = 0
        Me.butRefreshFPDS.Text = "Get Data"
        Me.butRefreshFPDS.UseVisualStyleBackColor = True
        '
        'flxGrid13
        '
        Me.flxGrid13.Location = New System.Drawing.Point(3, 72)
        Me.flxGrid13.Name = "flxGrid13"
        Me.flxGrid13.OcxState = CType(resources.GetObject("flxGrid13.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid13.Size = New System.Drawing.Size(505, 292)
        Me.flxGrid13.TabIndex = 2
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.butConveyorInputDelete)
        Me.GroupBox17.Controls.Add(Me.butConveyorInputSelectAll)
        Me.GroupBox17.Controls.Add(Me.butConveyorInputDeselectAll)
        Me.GroupBox17.Controls.Add(Me.butRefreshConveyorInput)
        Me.GroupBox17.Location = New System.Drawing.Point(514, 3)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(517, 60)
        Me.GroupBox17.TabIndex = 3
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Conveyor  Input Location Database"
        '
        'butConveyorInputDelete
        '
        Me.butConveyorInputDelete.Location = New System.Drawing.Point(294, 19)
        Me.butConveyorInputDelete.Name = "butConveyorInputDelete"
        Me.butConveyorInputDelete.Size = New System.Drawing.Size(84, 34)
        Me.butConveyorInputDelete.TabIndex = 3
        Me.butConveyorInputDelete.Text = "Delete"
        Me.butConveyorInputDelete.UseVisualStyleBackColor = True
        '
        'butConveyorInputSelectAll
        '
        Me.butConveyorInputSelectAll.Location = New System.Drawing.Point(114, 19)
        Me.butConveyorInputSelectAll.Name = "butConveyorInputSelectAll"
        Me.butConveyorInputSelectAll.Size = New System.Drawing.Size(84, 34)
        Me.butConveyorInputSelectAll.TabIndex = 1
        Me.butConveyorInputSelectAll.Text = "Select All"
        Me.butConveyorInputSelectAll.UseVisualStyleBackColor = True
        '
        'butConveyorInputDeselectAll
        '
        Me.butConveyorInputDeselectAll.Location = New System.Drawing.Point(204, 19)
        Me.butConveyorInputDeselectAll.Name = "butConveyorInputDeselectAll"
        Me.butConveyorInputDeselectAll.Size = New System.Drawing.Size(84, 34)
        Me.butConveyorInputDeselectAll.TabIndex = 2
        Me.butConveyorInputDeselectAll.Text = "DeSelectAll"
        Me.butConveyorInputDeselectAll.UseVisualStyleBackColor = True
        '
        'butRefreshConveyorInput
        '
        Me.butRefreshConveyorInput.Location = New System.Drawing.Point(6, 19)
        Me.butRefreshConveyorInput.Name = "butRefreshConveyorInput"
        Me.butRefreshConveyorInput.Size = New System.Drawing.Size(84, 34)
        Me.butRefreshConveyorInput.TabIndex = 0
        Me.butRefreshConveyorInput.Text = "Get Data"
        Me.butRefreshConveyorInput.UseVisualStyleBackColor = True
        '
        'flxGrid14
        '
        Me.flxGrid14.Location = New System.Drawing.Point(514, 72)
        Me.flxGrid14.Name = "flxGrid14"
        Me.flxGrid14.OcxState = CType(resources.GetObject("flxGrid14.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid14.Size = New System.Drawing.Size(577, 293)
        Me.flxGrid14.TabIndex = 4
        '
        'TabPage12
        '
        Me.TabPage12.Controls.Add(Me.butFillStagedUlsInWMS)
        Me.TabPage12.Controls.Add(Me.flxGrid15)
        Me.TabPage12.Location = New System.Drawing.Point(4, 22)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage12.TabIndex = 13
        Me.TabPage12.Text = "WMS Staging"
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'butFillStagedUlsInWMS
        '
        Me.butFillStagedUlsInWMS.Location = New System.Drawing.Point(23, 3)
        Me.butFillStagedUlsInWMS.Name = "butFillStagedUlsInWMS"
        Me.butFillStagedUlsInWMS.Size = New System.Drawing.Size(113, 35)
        Me.butFillStagedUlsInWMS.TabIndex = 1
        Me.butFillStagedUlsInWMS.Text = "Get Data"
        Me.butFillStagedUlsInWMS.UseVisualStyleBackColor = True
        '
        'flxGrid15
        '
        Me.flxGrid15.Location = New System.Drawing.Point(23, 55)
        Me.flxGrid15.Name = "flxGrid15"
        Me.flxGrid15.OcxState = CType(resources.GetObject("flxGrid15.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid15.Size = New System.Drawing.Size(1046, 353)
        Me.flxGrid15.TabIndex = 0
        '
        'TabPage13
        '
        Me.TabPage13.Controls.Add(Me.Label31)
        Me.TabPage13.Controls.Add(Me.txtMsg7Dlvloc)
        Me.TabPage13.Controls.Add(Me.Label30)
        Me.TabPage13.Controls.Add(Me.txtMsg7ULID)
        Me.TabPage13.Controls.Add(Me.butMsg7)
        Me.TabPage13.Location = New System.Drawing.Point(4, 22)
        Me.TabPage13.Name = "TabPage13"
        Me.TabPage13.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage13.TabIndex = 14
        Me.TabPage13.Text = "Utilities"
        Me.TabPage13.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(2, 48)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(37, 13)
        Me.Label31.TabIndex = 70
        Me.Label31.Text = "Dlvloc"
        '
        'txtMsg7Dlvloc
        '
        Me.txtMsg7Dlvloc.Location = New System.Drawing.Point(51, 41)
        Me.txtMsg7Dlvloc.Name = "txtMsg7Dlvloc"
        Me.txtMsg7Dlvloc.Size = New System.Drawing.Size(106, 20)
        Me.txtMsg7Dlvloc.TabIndex = 69
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(7, 18)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(32, 13)
        Me.Label30.TabIndex = 68
        Me.Label30.Text = "ULID"
        '
        'txtMsg7ULID
        '
        Me.txtMsg7ULID.Location = New System.Drawing.Point(51, 15)
        Me.txtMsg7ULID.Name = "txtMsg7ULID"
        Me.txtMsg7ULID.Size = New System.Drawing.Size(163, 20)
        Me.txtMsg7ULID.TabIndex = 67
        '
        'butMsg7
        '
        Me.butMsg7.Location = New System.Drawing.Point(51, 73)
        Me.butMsg7.Name = "butMsg7"
        Me.butMsg7.Size = New System.Drawing.Size(107, 33)
        Me.butMsg7.TabIndex = 0
        Me.butMsg7.Text = "Send Msg7"
        Me.butMsg7.UseVisualStyleBackColor = True
        '
        'TabPage14
        '
        Me.TabPage14.Controls.Add(Me.tabCtlTrailer)
        Me.TabPage14.Location = New System.Drawing.Point(4, 22)
        Me.TabPage14.Name = "TabPage14"
        Me.TabPage14.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage14.Size = New System.Drawing.Size(1278, 413)
        Me.TabPage14.TabIndex = 15
        Me.TabPage14.Text = "Trailer Movements"
        Me.TabPage14.UseVisualStyleBackColor = True
        '
        'tabCtlTrailer
        '
        Me.tabCtlTrailer.Controls.Add(Me.tabPgAutoCheckin)
        Me.tabCtlTrailer.Controls.Add(Me.TabPage16)
        Me.tabCtlTrailer.Location = New System.Drawing.Point(6, 21)
        Me.tabCtlTrailer.Name = "tabCtlTrailer"
        Me.tabCtlTrailer.SelectedIndex = 0
        Me.tabCtlTrailer.Size = New System.Drawing.Size(516, 354)
        Me.tabCtlTrailer.TabIndex = 1
        '
        'tabPgAutoCheckin
        '
        Me.tabPgAutoCheckin.Controls.Add(Me.grpBxTrailerCkin)
        Me.tabPgAutoCheckin.Location = New System.Drawing.Point(4, 22)
        Me.tabPgAutoCheckin.Name = "tabPgAutoCheckin"
        Me.tabPgAutoCheckin.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPgAutoCheckin.Size = New System.Drawing.Size(508, 328)
        Me.tabPgAutoCheckin.TabIndex = 0
        Me.tabPgAutoCheckin.Text = "Auto Trailer Check-In"
        Me.tabPgAutoCheckin.UseVisualStyleBackColor = True
        '
        'grpBxTrailerCkin
        '
        Me.grpBxTrailerCkin.Controls.Add(Me.txtTrailer)
        Me.grpBxTrailerCkin.Controls.Add(Me.lblTrailerID)
        Me.grpBxTrailerCkin.Controls.Add(Me.btnTrlCkin)
        Me.grpBxTrailerCkin.Location = New System.Drawing.Point(18, 28)
        Me.grpBxTrailerCkin.Name = "grpBxTrailerCkin"
        Me.grpBxTrailerCkin.Size = New System.Drawing.Size(407, 280)
        Me.grpBxTrailerCkin.TabIndex = 0
        Me.grpBxTrailerCkin.TabStop = False
        Me.grpBxTrailerCkin.Text = "Auto Check-In Details"
        '
        'txtTrailer
        '
        Me.txtTrailer.Location = New System.Drawing.Point(82, 24)
        Me.txtTrailer.Name = "txtTrailer"
        Me.txtTrailer.Size = New System.Drawing.Size(100, 20)
        Me.txtTrailer.TabIndex = 2
        '
        'lblTrailerID
        '
        Me.lblTrailerID.AutoSize = True
        Me.lblTrailerID.Location = New System.Drawing.Point(19, 27)
        Me.lblTrailerID.Name = "lblTrailerID"
        Me.lblTrailerID.Size = New System.Drawing.Size(48, 13)
        Me.lblTrailerID.TabIndex = 1
        Me.lblTrailerID.Text = "Trailer Id"
        '
        'btnTrlCkin
        '
        Me.btnTrlCkin.Location = New System.Drawing.Point(298, 226)
        Me.btnTrlCkin.Name = "btnTrlCkin"
        Me.btnTrlCkin.Size = New System.Drawing.Size(97, 23)
        Me.btnTrlCkin.TabIndex = 0
        Me.btnTrlCkin.Text = "Check-&In Trailer"
        Me.btnTrlCkin.UseVisualStyleBackColor = True
        '
        'TabPage16
        '
        Me.TabPage16.AccessibleName = "TrailerCheckout"
        Me.TabPage16.Controls.Add(Me.grpBxTrlCkout)
        Me.TabPage16.Location = New System.Drawing.Point(4, 22)
        Me.TabPage16.Name = "TabPage16"
        Me.TabPage16.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage16.Size = New System.Drawing.Size(508, 328)
        Me.TabPage16.TabIndex = 1
        Me.TabPage16.Tag = "TrailerCheckout"
        Me.TabPage16.Text = "Trailer Check-Out"
        Me.TabPage16.UseVisualStyleBackColor = True
        '
        'grpBxTrlCkout
        '
        Me.grpBxTrlCkout.AccessibleName = "TrailerData"
        Me.grpBxTrlCkout.Controls.Add(Me.txtTrlCo_LicPlateState)
        Me.grpBxTrlCkout.Controls.Add(Me.lblLicPlateState)
        Me.grpBxTrlCkout.Controls.Add(Me.txtTrlCo_LicPlateNum)
        Me.grpBxTrlCkout.Controls.Add(Me.lblLicPlateNum)
        Me.grpBxTrlCkout.Controls.Add(Me.txtTrlCo_DrvName)
        Me.grpBxTrlCkout.Controls.Add(Me.lblDrvNam)
        Me.grpBxTrlCkout.Controls.Add(Me.dtpckrTrlCo_CarArrDt)
        Me.grpBxTrlCkout.Controls.Add(Me.txtTrlCo_TrlCoCarArrDt)
        Me.grpBxTrlCkout.Controls.Add(Me.lblCarArrDt)
        Me.grpBxTrlCkout.Controls.Add(Me.txtTrlCo_TractorId)
        Me.grpBxTrlCkout.Controls.Add(Me.lbltrlCoTractorId)
        Me.grpBxTrlCkout.Controls.Add(Me.txtTrlCo_TrkLin)
        Me.grpBxTrlCkout.Controls.Add(Me.lblTrlCoTrlkin)
        Me.grpBxTrlCkout.Controls.Add(Me.txtTrlCo_trlnum)
        Me.grpBxTrlCkout.Controls.Add(Me.Label33)
        Me.grpBxTrlCkout.Controls.Add(Me.btnTrlCkout)
        Me.grpBxTrlCkout.Location = New System.Drawing.Point(26, 24)
        Me.grpBxTrlCkout.Name = "grpBxTrlCkout"
        Me.grpBxTrlCkout.Size = New System.Drawing.Size(432, 280)
        Me.grpBxTrlCkout.TabIndex = 1
        Me.grpBxTrlCkout.TabStop = False
        Me.grpBxTrlCkout.Tag = "TrailerData"
        Me.grpBxTrlCkout.Text = "Check-Out Details"
        '
        'txtTrlCo_LicPlateState
        '
        Me.txtTrlCo_LicPlateState.AccessibleName = "LICENSE_PLATE_STATE"
        Me.txtTrlCo_LicPlateState.Location = New System.Drawing.Point(136, 148)
        Me.txtTrlCo_LicPlateState.Name = "txtTrlCo_LicPlateState"
        Me.txtTrlCo_LicPlateState.Size = New System.Drawing.Size(100, 20)
        Me.txtTrlCo_LicPlateState.TabIndex = 12
        Me.txtTrlCo_LicPlateState.Tag = "LICENSE_PLATE_STATE"
        '
        'lblLicPlateState
        '
        Me.lblLicPlateState.AutoSize = True
        Me.lblLicPlateState.Location = New System.Drawing.Point(26, 151)
        Me.lblLicPlateState.Name = "lblLicPlateState"
        Me.lblLicPlateState.Size = New System.Drawing.Size(99, 13)
        Me.lblLicPlateState.TabIndex = 14
        Me.lblLicPlateState.Text = "License Plate State"
        '
        'txtTrlCo_LicPlateNum
        '
        Me.txtTrlCo_LicPlateNum.AccessibleName = "LICENSE_PLATE_NUM"
        Me.txtTrlCo_LicPlateNum.Location = New System.Drawing.Point(136, 122)
        Me.txtTrlCo_LicPlateNum.Name = "txtTrlCo_LicPlateNum"
        Me.txtTrlCo_LicPlateNum.Size = New System.Drawing.Size(100, 20)
        Me.txtTrlCo_LicPlateNum.TabIndex = 10
        Me.txtTrlCo_LicPlateNum.Tag = "LICENSE_PLATE_NUM"
        '
        'lblLicPlateNum
        '
        Me.lblLicPlateNum.AutoSize = True
        Me.lblLicPlateNum.Location = New System.Drawing.Point(26, 125)
        Me.lblLicPlateNum.Name = "lblLicPlateNum"
        Me.lblLicPlateNum.Size = New System.Drawing.Size(111, 13)
        Me.lblLicPlateNum.TabIndex = 12
        Me.lblLicPlateNum.Text = "License Plate Number"
        '
        'txtTrlCo_DrvName
        '
        Me.txtTrlCo_DrvName.AccessibleName = "DRIVER_NAME"
        Me.txtTrlCo_DrvName.Location = New System.Drawing.Point(136, 96)
        Me.txtTrlCo_DrvName.Name = "txtTrlCo_DrvName"
        Me.txtTrlCo_DrvName.Size = New System.Drawing.Size(100, 20)
        Me.txtTrlCo_DrvName.TabIndex = 8
        Me.txtTrlCo_DrvName.Tag = "DRIVER_NAME"
        '
        'lblDrvNam
        '
        Me.lblDrvNam.AutoSize = True
        Me.lblDrvNam.Location = New System.Drawing.Point(26, 99)
        Me.lblDrvNam.Name = "lblDrvNam"
        Me.lblDrvNam.Size = New System.Drawing.Size(66, 13)
        Me.lblDrvNam.TabIndex = 10
        Me.lblDrvNam.Text = "Driver Name"
        '
        'dtpckrTrlCo_CarArrDt
        '
        Me.dtpckrTrlCo_CarArrDt.AccessibleName = "CARRIER_ARRIVAL_DT"
        Me.dtpckrTrlCo_CarArrDt.Location = New System.Drawing.Point(136, 174)
        Me.dtpckrTrlCo_CarArrDt.Name = "dtpckrTrlCo_CarArrDt"
        Me.dtpckrTrlCo_CarArrDt.Size = New System.Drawing.Size(200, 20)
        Me.dtpckrTrlCo_CarArrDt.TabIndex = 14
        Me.dtpckrTrlCo_CarArrDt.Tag = "CARRIER_ARRIVAL_DT"
        '
        'txtTrlCo_TrlCoCarArrDt
        '
        Me.txtTrlCo_TrlCoCarArrDt.Location = New System.Drawing.Point(136, 197)
        Me.txtTrlCo_TrlCoCarArrDt.Name = "txtTrlCo_TrlCoCarArrDt"
        Me.txtTrlCo_TrlCoCarArrDt.Size = New System.Drawing.Size(100, 20)
        Me.txtTrlCo_TrlCoCarArrDt.TabIndex = 15
        '
        'lblCarArrDt
        '
        Me.lblCarArrDt.AutoSize = True
        Me.lblCarArrDt.Location = New System.Drawing.Point(26, 174)
        Me.lblCarArrDt.Name = "lblCarArrDt"
        Me.lblCarArrDt.Size = New System.Drawing.Size(95, 13)
        Me.lblCarArrDt.TabIndex = 7
        Me.lblCarArrDt.Text = "Carrier Arrival Date"
        '
        'txtTrlCo_TractorId
        '
        Me.txtTrlCo_TractorId.AccessibleName = "TRACTOR_ID"
        Me.txtTrlCo_TractorId.Location = New System.Drawing.Point(136, 72)
        Me.txtTrlCo_TractorId.Name = "txtTrlCo_TractorId"
        Me.txtTrlCo_TractorId.Size = New System.Drawing.Size(100, 20)
        Me.txtTrlCo_TractorId.TabIndex = 6
        Me.txtTrlCo_TractorId.Tag = "TRACTOR_ID"
        '
        'lbltrlCoTractorId
        '
        Me.lbltrlCoTractorId.AutoSize = True
        Me.lbltrlCoTractorId.Location = New System.Drawing.Point(26, 79)
        Me.lbltrlCoTractorId.Name = "lbltrlCoTractorId"
        Me.lbltrlCoTractorId.Size = New System.Drawing.Size(55, 13)
        Me.lbltrlCoTractorId.TabIndex = 5
        Me.lbltrlCoTractorId.Text = "Tractor ID"
        '
        'txtTrlCo_TrkLin
        '
        Me.txtTrlCo_TrkLin.AccessibleDescription = ""
        Me.txtTrlCo_TrkLin.AccessibleName = "TRUCK_LINE"
        Me.txtTrlCo_TrkLin.Location = New System.Drawing.Point(136, 23)
        Me.txtTrlCo_TrkLin.Name = "txtTrlCo_TrkLin"
        Me.txtTrlCo_TrkLin.Size = New System.Drawing.Size(100, 20)
        Me.txtTrlCo_TrkLin.TabIndex = 2
        Me.txtTrlCo_TrkLin.Tag = "TRUCK_LINE"
        '
        'lblTrlCoTrlkin
        '
        Me.lblTrlCoTrlkin.AutoSize = True
        Me.lblTrlCoTrlkin.Location = New System.Drawing.Point(26, 30)
        Me.lblTrlCoTrlkin.Name = "lblTrlCoTrlkin"
        Me.lblTrlCoTrlkin.Size = New System.Drawing.Size(58, 13)
        Me.lblTrlCoTrlkin.TabIndex = 3
        Me.lblTrlCoTrlkin.Text = "Truck Line"
        '
        'txtTrlCo_trlnum
        '
        Me.txtTrlCo_trlnum.AccessibleDescription = ""
        Me.txtTrlCo_trlnum.AccessibleName = "TRAILER_ID"
        Me.txtTrlCo_trlnum.Location = New System.Drawing.Point(136, 49)
        Me.txtTrlCo_trlnum.Name = "txtTrlCo_trlnum"
        Me.txtTrlCo_trlnum.Size = New System.Drawing.Size(100, 20)
        Me.txtTrlCo_trlnum.TabIndex = 4
        Me.txtTrlCo_trlnum.Tag = "TRAILER_ID"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(26, 56)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(48, 13)
        Me.Label33.TabIndex = 1
        Me.Label33.Text = "Trailer Id"
        '
        'btnTrlCkout
        '
        Me.btnTrlCkout.Location = New System.Drawing.Point(22, 226)
        Me.btnTrlCkout.Name = "btnTrlCkout"
        Me.btnTrlCkout.Size = New System.Drawing.Size(97, 23)
        Me.btnTrlCkout.TabIndex = 0
        Me.btnTrlCkout.Text = "Check-&Out Trailer"
        Me.btnTrlCkout.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Location = New System.Drawing.Point(-2, -1)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkAutoDataRefresh)
        Me.SplitContainer2.Panel1.Controls.Add(Me.butRefresh)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtLog)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkAutoRefresh)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblMsgOutCount)
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblMsgInCount)
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblLastMsgOutTimeStamp)
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblFirstMsgOutTimeStamp)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label18)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label19)
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblLastMsgInTimeStamp)
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblFirstMsgInTimeStamp)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label13)
        Me.SplitContainer2.Size = New System.Drawing.Size(1257, 180)
        Me.SplitContainer2.SplitterDistance = 1131
        Me.SplitContainer2.TabIndex = 62
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Auto Refresh"
        '
        'chkAutoDataRefresh
        '
        Me.chkAutoDataRefresh.AutoSize = True
        Me.chkAutoDataRefresh.Location = New System.Drawing.Point(8, 93)
        Me.chkAutoDataRefresh.Name = "chkAutoDataRefresh"
        Me.chkAutoDataRefresh.Size = New System.Drawing.Size(49, 17)
        Me.chkAutoDataRefresh.TabIndex = 68
        Me.chkAutoDataRefresh.TabStop = False
        Me.chkAutoDataRefresh.Text = "Data"
        Me.chkAutoDataRefresh.UseVisualStyleBackColor = True
        Me.chkAutoDataRefresh.Visible = False
        '
        'butRefresh
        '
        Me.butRefresh.Location = New System.Drawing.Point(3, 3)
        Me.butRefresh.Name = "butRefresh"
        Me.butRefresh.Size = New System.Drawing.Size(57, 45)
        Me.butRefresh.TabIndex = 38
        Me.butRefresh.TabStop = False
        Me.butRefresh.Text = "Refresh Log"
        Me.butRefresh.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.AcceptsTab = True
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLog.Font = New System.Drawing.Font("r_ansi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.Location = New System.Drawing.Point(72, 3)
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(1052, 167)
        Me.txtLog.TabIndex = 19
        Me.txtLog.TabStop = False
        Me.txtLog.Text = ""
        '
        'chkAutoRefresh
        '
        Me.chkAutoRefresh.AutoSize = True
        Me.chkAutoRefresh.Checked = True
        Me.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoRefresh.Location = New System.Drawing.Point(8, 70)
        Me.chkAutoRefresh.Name = "chkAutoRefresh"
        Me.chkAutoRefresh.Size = New System.Drawing.Size(44, 17)
        Me.chkAutoRefresh.TabIndex = 61
        Me.chkAutoRefresh.TabStop = False
        Me.chkAutoRefresh.Text = "Log"
        Me.chkAutoRefresh.UseVisualStyleBackColor = True
        '
        'lblMsgOutCount
        '
        Me.lblMsgOutCount.AutoSize = True
        Me.lblMsgOutCount.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMsgOutCount.Location = New System.Drawing.Point(76, 95)
        Me.lblMsgOutCount.Name = "lblMsgOutCount"
        Me.lblMsgOutCount.Size = New System.Drawing.Size(16, 13)
        Me.lblMsgOutCount.TabIndex = 9
        Me.lblMsgOutCount.Text = "..."
        '
        'lblMsgInCount
        '
        Me.lblMsgInCount.AutoSize = True
        Me.lblMsgInCount.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMsgInCount.Location = New System.Drawing.Point(76, 8)
        Me.lblMsgInCount.Name = "lblMsgInCount"
        Me.lblMsgInCount.Size = New System.Drawing.Size(16, 13)
        Me.lblMsgInCount.TabIndex = 8
        Me.lblMsgInCount.Text = "..."
        '
        'lblLastMsgOutTimeStamp
        '
        Me.lblLastMsgOutTimeStamp.AutoSize = True
        Me.lblLastMsgOutTimeStamp.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblLastMsgOutTimeStamp.Location = New System.Drawing.Point(6, 160)
        Me.lblLastMsgOutTimeStamp.Name = "lblLastMsgOutTimeStamp"
        Me.lblLastMsgOutTimeStamp.Size = New System.Drawing.Size(16, 13)
        Me.lblLastMsgOutTimeStamp.TabIndex = 7
        Me.lblLastMsgOutTimeStamp.Text = "..."
        '
        'lblFirstMsgOutTimeStamp
        '
        Me.lblFirstMsgOutTimeStamp.AutoSize = True
        Me.lblFirstMsgOutTimeStamp.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblFirstMsgOutTimeStamp.Location = New System.Drawing.Point(6, 113)
        Me.lblFirstMsgOutTimeStamp.Name = "lblFirstMsgOutTimeStamp"
        Me.lblFirstMsgOutTimeStamp.Size = New System.Drawing.Size(16, 13)
        Me.lblFirstMsgOutTimeStamp.TabIndex = 6
        Me.lblFirstMsgOutTimeStamp.Text = "..."
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 139)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 13)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Last MsgOut"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 95)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 13)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "First Msg Out"
        '
        'lblLastMsgInTimeStamp
        '
        Me.lblLastMsgInTimeStamp.AutoSize = True
        Me.lblLastMsgInTimeStamp.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblLastMsgInTimeStamp.Location = New System.Drawing.Point(6, 74)
        Me.lblLastMsgInTimeStamp.Name = "lblLastMsgInTimeStamp"
        Me.lblLastMsgInTimeStamp.Size = New System.Drawing.Size(16, 13)
        Me.lblLastMsgInTimeStamp.TabIndex = 3
        Me.lblLastMsgInTimeStamp.Text = "..."
        '
        'lblFirstMsgInTimeStamp
        '
        Me.lblFirstMsgInTimeStamp.AutoSize = True
        Me.lblFirstMsgInTimeStamp.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblFirstMsgInTimeStamp.Location = New System.Drawing.Point(6, 27)
        Me.lblFirstMsgInTimeStamp.Name = "lblFirstMsgInTimeStamp"
        Me.lblFirstMsgInTimeStamp.Size = New System.Drawing.Size(16, 13)
        Me.lblFirstMsgInTimeStamp.TabIndex = 2
        Me.lblFirstMsgInTimeStamp.Text = "..."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Last Msg In"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "First Msg In"
        '
        'tmrAutoScan
        '
        Me.tmrAutoScan.Interval = 5000
        Me.tmrAutoScan.Tag = "Msg24"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 676)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RAID"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.flxGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpCartonControl.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        CType(Me.flxGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flxGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPickControl.ResumeLayout(False)
        CType(Me.flxGrid11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.flxGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flxGrid8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.flxGrid10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        CType(Me.flxGrid9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.flxGrid5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.flxGrid6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flxGrid7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage9.PerformLayout()
        CType(Me.flxGrid12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage10.ResumeLayout(False)
        Me.linE03.ResumeLayout(False)
        Me.linE02.ResumeLayout(False)
        Me.linE01.ResumeLayout(False)
        Me.linG01.ResumeLayout(False)
        Me.TabPage11.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.grpFPDSControl.ResumeLayout(False)
        Me.GroupBox18.ResumeLayout(False)
        CType(Me.flxGrid13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox17.ResumeLayout(False)
        CType(Me.flxGrid14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage12.ResumeLayout(False)
        CType(Me.flxGrid15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage13.ResumeLayout(False)
        Me.TabPage13.PerformLayout()
        Me.TabPage14.ResumeLayout(False)
        Me.tabCtlTrailer.ResumeLayout(False)
        Me.tabPgAutoCheckin.ResumeLayout(False)
        Me.grpBxTrailerCkin.ResumeLayout(False)
        Me.grpBxTrailerCkin.PerformLayout()
        Me.TabPage16.ResumeLayout(False)
        Me.grpBxTrlCkout.ResumeLayout(False)
        Me.grpBxTrlCkout.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLog As System.Windows.Forms.RichTextBox
    Friend WithEvents tmrRefreshLog As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteOldLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butRefresh As System.Windows.Forms.Button
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendXMLFromFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendHeartbeatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServiceStepsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents chkAutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents tmrBlink As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelRefresh As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblWait As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SocketCommunicationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents chkAutoDataRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdRefreshInfeed As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdInfeedAdvance As System.Windows.Forms.Button
    Friend WithEvents cmdInfeedSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdInfeedDeSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnInfeedAutoScanOff As System.Windows.Forms.Button
    Friend WithEvents btnInfeedAutoScanOn As System.Windows.Forms.Button
    Friend WithEvents butRefreshASRSInfeed As System.Windows.Forms.Button
    Friend WithEvents flxGrid2 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents grpCartonControl As System.Windows.Forms.GroupBox
    Friend WithEvents cmdASRSInfeedAdvance As System.Windows.Forms.Button
    Friend WithEvents cmdASRSInfeedSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdASRSInfeedDeSelectAll As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents grpPickControl As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg7Advance As System.Windows.Forms.Button
    Friend WithEvents butMsg7SelectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg7DeSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnASRSInfeedAutoScanOff As System.Windows.Forms.Button
    Friend WithEvents btnASRSInfeedAutoScanOn As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents XMLEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLblConnections As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DeleteCust_PalletToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents flxGrid4 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents SearchLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrHeartbeat As System.Windows.Forms.Timer
    Friend WithEvents SendHeartbeatAutomaticallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelHeartBeatOn As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents butMsg16_GetData As System.Windows.Forms.Button
    Friend WithEvents flxGrid5 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents SocketListeningPortsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfeedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butRefreshNeedingMsg7 As System.Windows.Forms.Button
    Friend WithEvents ControlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllProcessesInAutoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg13AutoScanOff As System.Windows.Forms.Button
    Friend WithEvents butMsg13AutoScanOn As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg13Advance As System.Windows.Forms.Button
    Friend WithEvents butMsg13SelectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg13DeSelectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg13RefreshData As System.Windows.Forms.Button
    Friend WithEvents flxGrid6 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents DeleteCUSTSHIPMENTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteCUSTLINEITEMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManualOutputRequestsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg14Advance As System.Windows.Forms.Button
    Friend WithEvents butMsg14SelectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg14DeselectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg14GetData As System.Windows.Forms.Button
    Friend WithEvents flxGrid7 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents butMsg11_Send As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMsg11_Tech_Group As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMsg11_RDT_Message As System.Windows.Forms.TextBox
    Friend WithEvents DeleteMsg16HistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg21_Header_Advance As System.Windows.Forms.Button
    Friend WithEvents butMsg21_Header_SelectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg21_Header_DeSelectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg21_GetData As System.Windows.Forms.Button
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg21_Detail_Advance As System.Windows.Forms.Button
    Friend WithEvents butMsg21_Detail_SelectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg21_Detail_DeSelectAll As System.Windows.Forms.Button
    Friend WithEvents flxGrid8 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents lblRaid_SelectedShipidDisplay As System.Windows.Forms.Label
    Friend WithEvents lblRaid_SelectedShipid As System.Windows.Forms.Label
    Friend WithEvents txtlblRaid_Msg23_SelectedSlot As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMsg21_MOT_CODE As System.Windows.Forms.TextBox
    Friend WithEvents butMsg21_Send As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg21AutoSendOff As System.Windows.Forms.Button
    Friend WithEvents butMsg21AutoSendOn As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg22AutoSendOff As System.Windows.Forms.Button
    Friend WithEvents butMsg22AutoSendOn As System.Windows.Forms.Button
    Friend WithEvents butMsg21_Detail_GetData As System.Windows.Forms.Button
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents flxGrid9 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg24Advance As System.Windows.Forms.Button
    Friend WithEvents butMsg24_Header_SelectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg24_Header_DeSelectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg24_GetData As System.Windows.Forms.Button
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg24AutoSendOff As System.Windows.Forms.Button
    Friend WithEvents butMsg24AutoSendOn As System.Windows.Forms.Button
    Friend WithEvents OutboundStagingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRaid_SelectedLoadStatus As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents butMsg15Advance As System.Windows.Forms.Button
    Friend WithEvents butMsg15SelectAll As System.Windows.Forms.Button
    Friend WithEvents butMsg15DeselectAll As System.Windows.Forms.Button
    Friend WithEvents flxGrid10 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents lblRaidMsg15ShipId As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PurgeCompletedShipmentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblToolStripWorking As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusSpacer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRaid_Msg23_SelectedDisposition As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblRaid_SelectedLoadStatus_Msg24 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblRaid_SelectedRetroStatus_Msg24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents butRereshAsrsInventorySummary As System.Windows.Forms.Button
    Friend WithEvents flxGrid11 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents ClearShipmentIDFromDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butMsg21CheckInventory As System.Windows.Forms.Button
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents flxGrid3 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLastMsgOutTimeStamp As System.Windows.Forms.Label
    Friend WithEvents lblFirstMsgOutTimeStamp As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblLastMsgInTimeStamp As System.Windows.Forms.Label
    Friend WithEvents lblFirstMsgInTimeStamp As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblMsgOutCount As System.Windows.Forms.Label
    Friend WithEvents lblMsgInCount As System.Windows.Forms.Label
    Friend WithEvents ResetMessageCountersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrAutoScan As System.Windows.Forms.Timer
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents butReconcile As System.Windows.Forms.Button
    Friend WithEvents flxGrid12 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents DeleteCompletedWithdrawsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flxGrid1 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtShipULPickUp_Load_Flag As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtRequestNextProdOrder_DeliveryLocation As System.Windows.Forms.TextBox
    Friend WithEvents butRequestNextProdOrder As System.Windows.Forms.Button
    Friend WithEvents EditXMLBeforeSendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreventDBUpdatesAfterMessageAdvanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblSlotMaxAlarm As System.Windows.Forms.Label
    Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
    Friend WithEvents lblE10Title As System.Windows.Forms.Label
    Friend WithEvents lblG10Title As System.Windows.Forms.Label
    Friend WithEvents lblE10 As System.Windows.Forms.Label
    Friend WithEvents linE10 As System.Windows.Forms.Panel
    Friend WithEvents linG10 As System.Windows.Forms.Panel
    Friend WithEvents lblG10 As System.Windows.Forms.Label
    Friend WithEvents lblE09Title As System.Windows.Forms.Label
    Friend WithEvents lblG09Title As System.Windows.Forms.Label
    Friend WithEvents lblE09 As System.Windows.Forms.Label
    Friend WithEvents linE09 As System.Windows.Forms.Panel
    Friend WithEvents linG09 As System.Windows.Forms.Panel
    Friend WithEvents lblG09 As System.Windows.Forms.Label
    Friend WithEvents butGetGraphicalData As System.Windows.Forms.Button
    Friend WithEvents lblE08Title As System.Windows.Forms.Label
    Friend WithEvents lblE07Title As System.Windows.Forms.Label
    Friend WithEvents lblE06Title As System.Windows.Forms.Label
    Friend WithEvents lblE05Title As System.Windows.Forms.Label
    Friend WithEvents lblE04Title As System.Windows.Forms.Label
    Friend WithEvents lblE03Title As System.Windows.Forms.Label
    Friend WithEvents lblE02Title As System.Windows.Forms.Label
    Friend WithEvents lblE01Title As System.Windows.Forms.Label
    Friend WithEvents lblG08Title As System.Windows.Forms.Label
    Friend WithEvents lblG07Title As System.Windows.Forms.Label
    Friend WithEvents lblG06Title As System.Windows.Forms.Label
    Friend WithEvents lblG05Title As System.Windows.Forms.Label
    Friend WithEvents lblG04Title As System.Windows.Forms.Label
    Friend WithEvents lblG03Title As System.Windows.Forms.Label
    Friend WithEvents lblG02Title As System.Windows.Forms.Label
    Friend WithEvents lblG01Title As System.Windows.Forms.Label
    Friend WithEvents lblE08 As System.Windows.Forms.Label
    Friend WithEvents lblE07 As System.Windows.Forms.Label
    Friend WithEvents lblE06 As System.Windows.Forms.Label
    Friend WithEvents lblE05 As System.Windows.Forms.Label
    Friend WithEvents lblE04 As System.Windows.Forms.Label
    Friend WithEvents lblE03 As System.Windows.Forms.Label
    Friend WithEvents lblE02 As System.Windows.Forms.Label
    Friend WithEvents lblE01 As System.Windows.Forms.Label
    Friend WithEvents linE08 As System.Windows.Forms.Panel
    Friend WithEvents linE07 As System.Windows.Forms.Panel
    Friend WithEvents linE06 As System.Windows.Forms.Panel
    Friend WithEvents linE05 As System.Windows.Forms.Panel
    Friend WithEvents linE04 As System.Windows.Forms.Panel
    Friend WithEvents linE03 As System.Windows.Forms.Panel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents linE02 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents linE01 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents linG08 As System.Windows.Forms.Panel
    Friend WithEvents lblG08 As System.Windows.Forms.Label
    Friend WithEvents linG07 As System.Windows.Forms.Panel
    Friend WithEvents lblG07 As System.Windows.Forms.Label
    Friend WithEvents linG06 As System.Windows.Forms.Panel
    Friend WithEvents lblG06 As System.Windows.Forms.Label
    Friend WithEvents linG05 As System.Windows.Forms.Panel
    Friend WithEvents lblG05 As System.Windows.Forms.Label
    Friend WithEvents linG04 As System.Windows.Forms.Panel
    Friend WithEvents lblG04 As System.Windows.Forms.Label
    Friend WithEvents linG03 As System.Windows.Forms.Panel
    Friend WithEvents lblG03 As System.Windows.Forms.Label
    Friend WithEvents linG02 As System.Windows.Forms.Panel
    Friend WithEvents lblG02 As System.Windows.Forms.Label
    Friend WithEvents linG01 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents linMain As System.Windows.Forms.Panel
    Friend WithEvents lblG01 As System.Windows.Forms.Label
    Friend WithEvents TabPage11 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpFPDSControl As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFPDSAdvance As System.Windows.Forms.Button
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFPDSAutoScanOn As System.Windows.Forms.Button
    Friend WithEvents btnFPDSAutoScanOff As System.Windows.Forms.Button
    Friend WithEvents cmdFPDSSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdFPDSDeSelectAll As System.Windows.Forms.Button
    Friend WithEvents butRefreshFPDS As System.Windows.Forms.Button
    Friend WithEvents flxGrid13 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents DeleteTRAILERFPDSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents butConveyorInputDelete As System.Windows.Forms.Button
    Friend WithEvents butConveyorInputSelectAll As System.Windows.Forms.Button
    Friend WithEvents butConveyorInputDeselectAll As System.Windows.Forms.Button
    Friend WithEvents butRefreshConveyorInput As System.Windows.Forms.Button
    Friend WithEvents flxGrid14 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents DatabaseUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisplayDatabasePatchVersionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckDBForRequiredTablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtInfeedRestrictToUlPall As System.Windows.Forms.TextBox
    Friend WithEvents txtInfeedRestrictToItem As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtInfeedRestrictToCtlgrp As System.Windows.Forms.TextBox
    Friend WithEvents HostInboundToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUtil_DstLoc As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtUtil_Ulid As System.Windows.Forms.TextBox
    Friend WithEvents butUtil_MoveUl As System.Windows.Forms.Button
    Friend WithEvents WMSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateEventsInICToSCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateASRSSessionIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearULIDFromDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DTLDriverSendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage12 As System.Windows.Forms.TabPage
    Friend WithEvents flxGrid15 As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents butFillStagedUlsInWMS As System.Windows.Forms.Button
    Friend WithEvents UpdateRTCSESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage13 As System.Windows.Forms.TabPage
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtMsg7Dlvloc As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtMsg7ULID As System.Windows.Forms.TextBox
    Friend WithEvents butMsg7 As System.Windows.Forms.Button
    Friend WithEvents ApplyDatabasePatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtReconcileItmCod As System.Windows.Forms.TextBox
    Friend WithEvents DataGrid1 As DataGrid
    Friend WithEvents TabPage14 As TabPage
    Friend WithEvents grpBxTrailerCkin As GroupBox
    Friend WithEvents lblTrailerID As Label
    Friend WithEvents btnTrlCkin As Button
    Friend WithEvents txtTrailer As TextBox
    Friend WithEvents tabCtlTrailer As TabControl
    Friend WithEvents tabPgAutoCheckin As TabPage
    Friend WithEvents TabPage16 As TabPage
    Friend WithEvents grpBxTrlCkout As GroupBox
    Friend WithEvents txtTrlCo_TractorId As TextBox
    Friend WithEvents lbltrlCoTractorId As Label
    Friend WithEvents txtTrlCo_TrkLin As TextBox
    Friend WithEvents lblTrlCoTrlkin As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents btnTrlCkout As Button
    Friend WithEvents txtTrlCo_TrlCoCarArrDt As TextBox
    Friend WithEvents lblCarArrDt As Label
    Friend WithEvents dtpckrTrlCo_CarArrDt As DateTimePicker
    Friend WithEvents txtTrlCo_LicPlateState As TextBox
    Friend WithEvents lblLicPlateState As Label
    Friend WithEvents txtTrlCo_LicPlateNum As TextBox
    Friend WithEvents lblLicPlateNum As Label
    Friend WithEvents txtTrlCo_DrvName As TextBox
    Friend WithEvents lblDrvNam As Label
    Private WithEvents txtTrlCo_trlnum As TextBox
End Class
