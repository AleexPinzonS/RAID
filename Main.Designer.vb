<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.TCSConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.DeleteTCSTRAILERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.btnTrlMovAsgnShpRcp = New System.Windows.Forms.Button()
        Me.btnTrlMovTLocAsgn = New System.Windows.Forms.Button()
        Me.btnTrlMovTrlLocReq = New System.Windows.Forms.Button()
        Me.btnTrlMovTrlMovPickup = New System.Windows.Forms.Button()
        Me.btnTrlMovTrlMovComp = New System.Windows.Forms.Button()
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
        Me.tabPgTrlMovEmu = New System.Windows.Forms.TabPage()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnTCSEmuViewData = New System.Windows.Forms.Button()
        Me.dgvTrlActivityData = New System.Windows.Forms.DataGridView()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.pnlTCSEmuData = New System.Windows.Forms.Panel()
        Me.dGridTraMovData = New System.Windows.Forms.DataGridView()
        Me.chkBxTcsEmuEMUSessionOnly = New System.Windows.Forms.CheckBox()
        Me.lblTrlEMUData = New System.Windows.Forms.Label()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage16 = New System.Windows.Forms.TabPage()
        Me.chkBxTcsEmuWMSEmpty = New System.Windows.Forms.CheckBox()
        Me.chkBxTcsEmuWMSReadyToShip = New System.Windows.Forms.CheckBox()
        Me.chkBxTcsEmuWMSSessOnly = New System.Windows.Forms.CheckBox()
        Me.dGridTCSTrlViewData = New System.Windows.Forms.DataGridView()
        Me.gbTrailerMovMain = New System.Windows.Forms.GroupBox()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.TextBox58 = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.GroupBox30 = New System.Windows.Forms.GroupBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.TextBox32 = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.TextBox33 = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TextBox34 = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.TextBox35 = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.TextBox46 = New System.Windows.Forms.TextBox()
        Me.GroupBox29 = New System.Windows.Forms.GroupBox()
        Me.TextBox38 = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.TextBox45 = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.TextBox36 = New System.Windows.Forms.TextBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.TextBox37 = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.btnTrlMovReset = New System.Windows.Forms.Button()
        Me.TextBox39 = New System.Windows.Forms.TextBox()
        Me.btnTrlMovTCkout = New System.Windows.Forms.Button()
        Me.GroupBox27 = New System.Windows.Forms.GroupBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.btnTrlMovTCkin = New System.Windows.Forms.Button()
        Me.lblWMSTCSTrlData = New System.Windows.Forms.Label()
        Me.btnGetTrlMovData = New System.Windows.Forms.Button()
        Me.TabPage17 = New System.Windows.Forms.TabPage()
        Me.chkbTrlMvmtShowEmpty = New System.Windows.Forms.CheckBox()
        Me.chkbTrlMvmtReadyToShip = New System.Windows.Forms.CheckBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.chkbTrlMvmtThisSessionOnly = New System.Windows.Forms.CheckBox()
        Me.dgvTrlMvmtTCSTrailerView = New System.Windows.Forms.DataGridView()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.chkBxTcsEmuTrlMovWMSSessOnly = New System.Windows.Forms.CheckBox()
        Me.dgvTcsTrailerReq = New System.Windows.Forms.DataGridView()
        Me.btnLoadTrailerMovData = New System.Windows.Forms.Button()
        Me.gbxTrailerMovement = New System.Windows.Forms.GroupBox()
        Me.btnTrlMovementReset = New System.Windows.Forms.Button()
        Me.btnTrlMovTrlChgPriority = New System.Windows.Forms.Button()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.TextBox60 = New System.Windows.Forms.TextBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.TextBox43 = New System.Windows.Forms.TextBox()
        Me.TextBox42 = New System.Windows.Forms.TextBox()
        Me.btnTrlMovTrlLocUpd = New System.Windows.Forms.Button()
        Me.btnTrlMovTrlMovCancel = New System.Windows.Forms.Button()
        Me.TextBox57 = New System.Windows.Forms.TextBox()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.TextBox56 = New System.Windows.Forms.TextBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.TextBox55 = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.TextBox51 = New System.Windows.Forms.TextBox()
        Me.TextBox52 = New System.Windows.Forms.TextBox()
        Me.TextBox53 = New System.Windows.Forms.TextBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.TextBox54 = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.TabPage18 = New System.Windows.Forms.TabPage()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.dgvTcsLocation = New System.Windows.Forms.DataGridView()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.chkbTCSTrlExecCurSessOnly = New System.Windows.Forms.CheckBox()
        Me.btnLoadTrlExecTrlReqData = New System.Windows.Forms.Button()
        Me.dgTCSTrlReqbySessionViewData = New System.Windows.Forms.DataGridView()
        Me.gbxTrailerMoveExec = New System.Windows.Forms.GroupBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.btnTrlMovExecReset = New System.Windows.Forms.Button()
        Me.btnTrlMovExecTrlChgPriority = New System.Windows.Forms.Button()
        Me.TextBox65 = New System.Windows.Forms.TextBox()
        Me.TextBox66 = New System.Windows.Forms.TextBox()
        Me.TextBox44 = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.TextBox41 = New System.Windows.Forms.TextBox()
        Me.TextBox40 = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.TextBox49 = New System.Windows.Forms.TextBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.TextBox50 = New System.Windows.Forms.TextBox()
        Me.TextBox47 = New System.Windows.Forms.TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.TextBox48 = New System.Windows.Forms.TextBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.btnTrlMovExecTrlMovCancel = New System.Windows.Forms.Button()
        Me.TextBox59 = New System.Windows.Forms.TextBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.TextBox61 = New System.Windows.Forms.TextBox()
        Me.TextBox62 = New System.Windows.Forms.TextBox()
        Me.TextBox63 = New System.Windows.Forms.TextBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.TextBox64 = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
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
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnLoadActivityData = New System.Windows.Forms.Button()
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
        Me.tabPgTrlMovEmu.SuspendLayout()
        Me.Panel14.SuspendLayout()
        CType(Me.dgvTrlActivityData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTCSEmuData.SuspendLayout()
        CType(Me.dGridTraMovData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TabPage16.SuspendLayout()
        CType(Me.dGridTCSTrlViewData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTrailerMovMain.SuspendLayout()
        Me.GroupBox30.SuspendLayout()
        Me.GroupBox29.SuspendLayout()
        Me.GroupBox27.SuspendLayout()
        Me.TabPage17.SuspendLayout()
        CType(Me.dgvTrlMvmtTCSTrailerView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTcsTrailerReq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxTrailerMovement.SuspendLayout()
        Me.TabPage18.SuspendLayout()
        CType(Me.dgvTcsLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTCSTrlReqbySessionViewData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxTrailerMoveExec.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MenuStrip1.Size = New System.Drawing.Size(1779, 24)
        Me.MenuStrip1.TabIndex = 31
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainToolStripMenuItem, Me.DTLDriverSendToolStripMenuItem, Me.HostInboundToolStripMenuItem, Me.InfeedToolStripMenuItem, Me.ManualOutputRequestsToolStripMenuItem, Me.OutboundStagingToolStripMenuItem, Me.SocketCommunicationToolStripMenuItem, Me.SocketListeningPortsToolStripMenuItem, Me.TCSConfigToolStripMenuItem})
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
        'TCSConfigToolStripMenuItem
        '
        Me.TCSConfigToolStripMenuItem.Name = "TCSConfigToolStripMenuItem"
        Me.TCSConfigToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.TCSConfigToolStripMenuItem.Text = "TCS Config"
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
        Me.LogsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearShipmentIDFromDatabaseToolStripMenuItem, Me.ClearULIDFromDatabaseToolStripMenuItem, Me.DeleteOldLogsToolStripMenuItem, Me.DeleteCust_PalletToolStripMenuItem, Me.DeleteCUSTSHIPMENTToolStripMenuItem, Me.DeleteCUSTLINEITEMToolStripMenuItem, Me.DeleteMsg16HistoryToolStripMenuItem, Me.DeleteTRAILERFPDSToolStripMenuItem, Me.PurgeCompletedShipmentsToolStripMenuItem, Me.DeleteCompletedWithdrawsToolStripMenuItem, Me.RemoveAToolStripMenuItem, Me.DeleteTCSTRAILERToolStripMenuItem})
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
        'DeleteTCSTRAILERToolStripMenuItem
        '
        Me.DeleteTCSTRAILERToolStripMenuItem.Name = "DeleteTCSTRAILERToolStripMenuItem"
        Me.DeleteTCSTRAILERToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.DeleteTCSTRAILERToolStripMenuItem.Text = "Delete TCS_TRAILER"
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 739)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1779, 22)
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
        Me.ToolStripStatusSpacer.Size = New System.Drawing.Size(882, 17)
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
        Me.ToolStripStatusLblConnections.Size = New System.Drawing.Size(882, 17)
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
        'btnTrlMovAsgnShpRcp
        '
        Me.btnTrlMovAsgnShpRcp.Location = New System.Drawing.Point(213, 209)
        Me.btnTrlMovAsgnShpRcp.Name = "btnTrlMovAsgnShpRcp"
        Me.btnTrlMovAsgnShpRcp.Size = New System.Drawing.Size(112, 23)
        Me.btnTrlMovAsgnShpRcp.TabIndex = 2
        Me.btnTrlMovAsgnShpRcp.TabStop = False
        Me.btnTrlMovAsgnShpRcp.Text = "Assign Shipment"
        Me.ToolTip1.SetToolTip(Me.btnTrlMovAsgnShpRcp, "Assign Shipment Or Receipt")
        Me.btnTrlMovAsgnShpRcp.UseVisualStyleBackColor = True
        '
        'btnTrlMovTLocAsgn
        '
        Me.btnTrlMovTLocAsgn.Location = New System.Drawing.Point(331, 209)
        Me.btnTrlMovTLocAsgn.Name = "btnTrlMovTLocAsgn"
        Me.btnTrlMovTLocAsgn.Size = New System.Drawing.Size(129, 23)
        Me.btnTrlMovTLocAsgn.TabIndex = 3
        Me.btnTrlMovTLocAsgn.TabStop = False
        Me.btnTrlMovTLocAsgn.Tag = "TrailerLocAssignmentData"
        Me.btnTrlMovTLocAsgn.Text = "Location Request"
        Me.ToolTip1.SetToolTip(Me.btnTrlMovTLocAsgn, "Trailer Location Assignment")
        Me.btnTrlMovTLocAsgn.UseVisualStyleBackColor = True
        '
        'btnTrlMovTrlLocReq
        '
        Me.btnTrlMovTrlLocReq.Location = New System.Drawing.Point(-1, 125)
        Me.btnTrlMovTrlLocReq.Name = "btnTrlMovTrlLocReq"
        Me.btnTrlMovTrlLocReq.Size = New System.Drawing.Size(119, 23)
        Me.btnTrlMovTrlLocReq.TabIndex = 79
        Me.btnTrlMovTrlLocReq.TabStop = False
        Me.btnTrlMovTrlLocReq.Tag = "TrailerLocAssignmentData"
        Me.btnTrlMovTrlLocReq.Text = "Trl. Loc Request"
        Me.ToolTip1.SetToolTip(Me.btnTrlMovTrlLocReq, "Trailer Location Assignment")
        Me.btnTrlMovTrlLocReq.UseVisualStyleBackColor = True
        '
        'btnTrlMovTrlMovPickup
        '
        Me.btnTrlMovTrlMovPickup.AccessibleName = ""
        Me.btnTrlMovTrlMovPickup.Location = New System.Drawing.Point(11, 148)
        Me.btnTrlMovTrlMovPickup.Name = "btnTrlMovTrlMovPickup"
        Me.btnTrlMovTrlMovPickup.Size = New System.Drawing.Size(111, 23)
        Me.btnTrlMovTrlMovPickup.TabIndex = 82
        Me.btnTrlMovTrlMovPickup.Tag = ""
        Me.btnTrlMovTrlMovPickup.Text = "Trl. Move Pickup"
        Me.ToolTip1.SetToolTip(Me.btnTrlMovTrlMovPickup, "Trailer Move Pickup or Hook")
        Me.btnTrlMovTrlMovPickup.UseVisualStyleBackColor = True
        '
        'btnTrlMovTrlMovComp
        '
        Me.btnTrlMovTrlMovComp.Location = New System.Drawing.Point(128, 147)
        Me.btnTrlMovTrlMovComp.Name = "btnTrlMovTrlMovComp"
        Me.btnTrlMovTrlMovComp.Size = New System.Drawing.Size(108, 23)
        Me.btnTrlMovTrlMovComp.TabIndex = 83
        Me.btnTrlMovTrlMovComp.TabStop = False
        Me.btnTrlMovTrlMovComp.Text = "Trl. Move Complete"
        Me.ToolTip1.SetToolTip(Me.btnTrlMovTrlMovComp, "Trailer Move Complete or Unhook")
        Me.btnTrlMovTrlMovComp.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1752, 710)
        Me.SplitContainer1.SplitterDistance = 465
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
        Me.TabControl1.Controls.Add(Me.tabPgTrlMovEmu)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1781, 459)
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
        Me.TabPage1.Size = New System.Drawing.Size(1773, 433)
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
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 347.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1300, 347)
        Me.TableLayoutPanel3.TabIndex = 61
        '
        'flxGrid1
        '
        Me.flxGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxGrid1.Location = New System.Drawing.Point(3, 3)
        Me.flxGrid1.Name = "flxGrid1"
        Me.flxGrid1.OcxState = CType(resources.GetObject("flxGrid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid1.Size = New System.Drawing.Size(1420, 341)
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
        Me.TabPage2.Size = New System.Drawing.Size(1773, 433)
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
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 332.0!))
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1723, 417)
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
        Me.grpCartonControl.Size = New System.Drawing.Size(681, 60)
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
        Me.GroupBox15.Location = New System.Drawing.Point(1393, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(327, 60)
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
        Me.flxGrid2.Location = New System.Drawing.Point(3, 89)
        Me.flxGrid2.Name = "flxGrid2"
        Me.flxGrid2.OcxState = CType(resources.GetObject("flxGrid2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid2.Size = New System.Drawing.Size(681, 325)
        Me.flxGrid2.TabIndex = 0
        Me.flxGrid2.TabStop = False
        '
        'flxGrid3
        '
        Me.flxGrid3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flxGrid3.Location = New System.Drawing.Point(690, 89)
        Me.flxGrid3.Name = "flxGrid3"
        Me.flxGrid3.OcxState = CType(resources.GetObject("flxGrid3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid3.Size = New System.Drawing.Size(697, 325)
        Me.flxGrid3.TabIndex = 0
        '
        'grpPickControl
        '
        Me.grpPickControl.Controls.Add(Me.butRefreshNeedingMsg7)
        Me.grpPickControl.Controls.Add(Me.butMsg7Advance)
        Me.grpPickControl.Controls.Add(Me.butMsg7SelectAll)
        Me.grpPickControl.Controls.Add(Me.butMsg7DeSelectAll)
        Me.grpPickControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpPickControl.Location = New System.Drawing.Point(690, 3)
        Me.grpPickControl.Name = "grpPickControl"
        Me.grpPickControl.Size = New System.Drawing.Size(697, 60)
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
        Me.flxGrid11.Location = New System.Drawing.Point(1393, 89)
        Me.flxGrid11.Name = "flxGrid11"
        Me.flxGrid11.OcxState = CType(resources.GetObject("flxGrid11.OcxState"), System.Windows.Forms.AxHost.State)
        Me.flxGrid11.Size = New System.Drawing.Size(327, 325)
        Me.flxGrid11.TabIndex = 64
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.GroupBox16)
        Me.TabPage7.Controls.Add(Me.GroupBox8)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(1773, 433)
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
        Me.TabPage4.Size = New System.Drawing.Size(1773, 433)
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
        Me.TabPage8.Size = New System.Drawing.Size(1773, 433)
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
        Me.TabPage5.Size = New System.Drawing.Size(1773, 433)
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
        Me.TabPage6.Size = New System.Drawing.Size(1773, 433)
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
        Me.TabPage3.Size = New System.Drawing.Size(1773, 433)
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
        Me.TabPage9.Size = New System.Drawing.Size(1773, 433)
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
        Me.TabPage10.Size = New System.Drawing.Size(1773, 433)
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
        Me.TabPage11.Size = New System.Drawing.Size(1773, 433)
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
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(1723, 401)
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
        Me.grpFPDSControl.Size = New System.Drawing.Size(711, 60)
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
        Me.flxGrid13.Location = New System.Drawing.Point(3, 76)
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
        Me.GroupBox17.Location = New System.Drawing.Point(720, 3)
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
        Me.flxGrid14.Location = New System.Drawing.Point(720, 76)
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
        Me.TabPage12.Size = New System.Drawing.Size(1773, 433)
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
        Me.TabPage13.Size = New System.Drawing.Size(1773, 433)
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
        'tabPgTrlMovEmu
        '
        Me.tabPgTrlMovEmu.Controls.Add(Me.Panel14)
        Me.tabPgTrlMovEmu.Controls.Add(Me.pnlTCSEmuData)
        Me.tabPgTrlMovEmu.Controls.Add(Me.TabControl2)
        Me.tabPgTrlMovEmu.Location = New System.Drawing.Point(4, 22)
        Me.tabPgTrlMovEmu.Name = "tabPgTrlMovEmu"
        Me.tabPgTrlMovEmu.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPgTrlMovEmu.Size = New System.Drawing.Size(1773, 433)
        Me.tabPgTrlMovEmu.TabIndex = 16
        Me.tabPgTrlMovEmu.Text = "TCS Emulator"
        Me.tabPgTrlMovEmu.UseVisualStyleBackColor = True
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.btnLoadActivityData)
        Me.Panel14.Controls.Add(Me.btnTCSEmuViewData)
        Me.Panel14.Controls.Add(Me.dgvTrlActivityData)
        Me.Panel14.Controls.Add(Me.Label34)
        Me.Panel14.Location = New System.Drawing.Point(1184, 3)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(451, 424)
        Me.Panel14.TabIndex = 8
        '
        'btnTCSEmuViewData
        '
        Me.btnTCSEmuViewData.Location = New System.Drawing.Point(3, 397)
        Me.btnTCSEmuViewData.Name = "btnTCSEmuViewData"
        Me.btnTCSEmuViewData.Size = New System.Drawing.Size(75, 23)
        Me.btnTCSEmuViewData.TabIndex = 78
        Me.btnTCSEmuViewData.Text = "View Data"
        Me.btnTCSEmuViewData.UseVisualStyleBackColor = True
        '
        'dgvTrlActivityData
        '
        Me.dgvTrlActivityData.AllowUserToAddRows = False
        Me.dgvTrlActivityData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTrlActivityData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTrlActivityData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTrlActivityData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTrlActivityData.Location = New System.Drawing.Point(3, 16)
        Me.dgvTrlActivityData.Name = "dgvTrlActivityData"
        Me.dgvTrlActivityData.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTrlActivityData.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTrlActivityData.Size = New System.Drawing.Size(433, 381)
        Me.dgvTrlActivityData.TabIndex = 8
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(3, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(137, 13)
        Me.Label34.TabIndex = 7
        Me.Label34.Text = "Emulator Activity Data "
        '
        'pnlTCSEmuData
        '
        Me.pnlTCSEmuData.Controls.Add(Me.dGridTraMovData)
        Me.pnlTCSEmuData.Controls.Add(Me.chkBxTcsEmuEMUSessionOnly)
        Me.pnlTCSEmuData.Controls.Add(Me.lblTrlEMUData)
        Me.pnlTCSEmuData.Location = New System.Drawing.Point(1597, 3)
        Me.pnlTCSEmuData.Name = "pnlTCSEmuData"
        Me.pnlTCSEmuData.Size = New System.Drawing.Size(141, 78)
        Me.pnlTCSEmuData.TabIndex = 7
        Me.pnlTCSEmuData.Visible = False
        '
        'dGridTraMovData
        '
        Me.dGridTraMovData.AllowUserToAddRows = False
        Me.dGridTraMovData.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dGridTraMovData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dGridTraMovData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dGridTraMovData.DefaultCellStyle = DataGridViewCellStyle5
        Me.dGridTraMovData.Location = New System.Drawing.Point(12, 54)
        Me.dGridTraMovData.Name = "dGridTraMovData"
        Me.dGridTraMovData.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dGridTraMovData.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dGridTraMovData.Size = New System.Drawing.Size(176, 104)
        Me.dGridTraMovData.TabIndex = 5
        '
        'chkBxTcsEmuEMUSessionOnly
        '
        Me.chkBxTcsEmuEMUSessionOnly.AutoSize = True
        Me.chkBxTcsEmuEMUSessionOnly.Location = New System.Drawing.Point(12, 26)
        Me.chkBxTcsEmuEMUSessionOnly.Name = "chkBxTcsEmuEMUSessionOnly"
        Me.chkBxTcsEmuEMUSessionOnly.Size = New System.Drawing.Size(110, 17)
        Me.chkBxTcsEmuEMUSessionOnly.TabIndex = 1
        Me.chkBxTcsEmuEMUSessionOnly.Text = "Only This Session"
        Me.chkBxTcsEmuEMUSessionOnly.UseVisualStyleBackColor = True
        '
        'lblTrlEMUData
        '
        Me.lblTrlEMUData.AutoSize = True
        Me.lblTrlEMUData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrlEMUData.Location = New System.Drawing.Point(12, 7)
        Me.lblTrlEMUData.Name = "lblTrlEMUData"
        Me.lblTrlEMUData.Size = New System.Drawing.Size(91, 13)
        Me.lblTrlEMUData.TabIndex = 5
        Me.lblTrlEMUData.Text = "Emulator Data "
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage16)
        Me.TabControl2.Controls.Add(Me.TabPage17)
        Me.TabControl2.Controls.Add(Me.TabPage18)
        Me.TabControl2.Location = New System.Drawing.Point(1, 0)
        Me.TabControl2.Multiline = True
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1181, 430)
        Me.TabControl2.TabIndex = 6
        '
        'TabPage16
        '
        Me.TabPage16.Controls.Add(Me.chkBxTcsEmuWMSEmpty)
        Me.TabPage16.Controls.Add(Me.chkBxTcsEmuWMSReadyToShip)
        Me.TabPage16.Controls.Add(Me.chkBxTcsEmuWMSSessOnly)
        Me.TabPage16.Controls.Add(Me.dGridTCSTrlViewData)
        Me.TabPage16.Controls.Add(Me.gbTrailerMovMain)
        Me.TabPage16.Controls.Add(Me.lblWMSTCSTrlData)
        Me.TabPage16.Controls.Add(Me.btnGetTrlMovData)
        Me.TabPage16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage16.Location = New System.Drawing.Point(4, 22)
        Me.TabPage16.Name = "TabPage16"
        Me.TabPage16.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage16.Size = New System.Drawing.Size(1173, 404)
        Me.TabPage16.TabIndex = 0
        Me.TabPage16.Text = "Trailer Checkin/Checkout"
        Me.TabPage16.UseVisualStyleBackColor = True
        '
        'chkBxTcsEmuWMSEmpty
        '
        Me.chkBxTcsEmuWMSEmpty.AutoSize = True
        Me.chkBxTcsEmuWMSEmpty.Location = New System.Drawing.Point(503, 3)
        Me.chkBxTcsEmuWMSEmpty.Name = "chkBxTcsEmuWMSEmpty"
        Me.chkBxTcsEmuWMSEmpty.Size = New System.Drawing.Size(85, 17)
        Me.chkBxTcsEmuWMSEmpty.TabIndex = 4
        Me.chkBxTcsEmuWMSEmpty.Text = "Show Empty"
        Me.chkBxTcsEmuWMSEmpty.UseVisualStyleBackColor = True
        '
        'chkBxTcsEmuWMSReadyToShip
        '
        Me.chkBxTcsEmuWMSReadyToShip.AutoSize = True
        Me.chkBxTcsEmuWMSReadyToShip.Location = New System.Drawing.Point(352, 3)
        Me.chkBxTcsEmuWMSReadyToShip.Name = "chkBxTcsEmuWMSReadyToShip"
        Me.chkBxTcsEmuWMSReadyToShip.Size = New System.Drawing.Size(93, 17)
        Me.chkBxTcsEmuWMSReadyToShip.TabIndex = 3
        Me.chkBxTcsEmuWMSReadyToShip.Text = "Ready to Ship"
        Me.chkBxTcsEmuWMSReadyToShip.UseVisualStyleBackColor = True
        '
        'chkBxTcsEmuWMSSessOnly
        '
        Me.chkBxTcsEmuWMSSessOnly.AutoSize = True
        Me.chkBxTcsEmuWMSSessOnly.Location = New System.Drawing.Point(200, 3)
        Me.chkBxTcsEmuWMSSessOnly.Name = "chkBxTcsEmuWMSSessOnly"
        Me.chkBxTcsEmuWMSSessOnly.Size = New System.Drawing.Size(110, 17)
        Me.chkBxTcsEmuWMSSessOnly.TabIndex = 2
        Me.chkBxTcsEmuWMSSessOnly.Text = "Only This Session"
        Me.chkBxTcsEmuWMSSessOnly.UseVisualStyleBackColor = True
        '
        'dGridTCSTrlViewData
        '
        Me.dGridTCSTrlViewData.AllowUserToAddRows = False
        Me.dGridTCSTrlViewData.AllowUserToDeleteRows = False
        Me.dGridTCSTrlViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGridTCSTrlViewData.Location = New System.Drawing.Point(6, 26)
        Me.dGridTCSTrlViewData.Name = "dGridTCSTrlViewData"
        Me.dGridTCSTrlViewData.ReadOnly = True
        Me.dGridTCSTrlViewData.Size = New System.Drawing.Size(1142, 138)
        Me.dGridTCSTrlViewData.TabIndex = 6
        '
        'gbTrailerMovMain
        '
        Me.gbTrailerMovMain.Controls.Add(Me.Label96)
        Me.gbTrailerMovMain.Controls.Add(Me.TextBox58)
        Me.gbTrailerMovMain.Controls.Add(Me.Label66)
        Me.gbTrailerMovMain.Controls.Add(Me.Label65)
        Me.gbTrailerMovMain.Controls.Add(Me.CheckBox4)
        Me.gbTrailerMovMain.Controls.Add(Me.GroupBox30)
        Me.gbTrailerMovMain.Controls.Add(Me.TextBox46)
        Me.gbTrailerMovMain.Controls.Add(Me.GroupBox29)
        Me.gbTrailerMovMain.Controls.Add(Me.Label70)
        Me.gbTrailerMovMain.Controls.Add(Me.btnTrlMovReset)
        Me.gbTrailerMovMain.Controls.Add(Me.TextBox39)
        Me.gbTrailerMovMain.Controls.Add(Me.btnTrlMovTCkout)
        Me.gbTrailerMovMain.Controls.Add(Me.btnTrlMovAsgnShpRcp)
        Me.gbTrailerMovMain.Controls.Add(Me.GroupBox27)
        Me.gbTrailerMovMain.Controls.Add(Me.btnTrlMovTLocAsgn)
        Me.gbTrailerMovMain.Controls.Add(Me.Label57)
        Me.gbTrailerMovMain.Controls.Add(Me.btnTrlMovTCkin)
        Me.gbTrailerMovMain.Location = New System.Drawing.Point(3, 164)
        Me.gbTrailerMovMain.Name = "gbTrailerMovMain"
        Me.gbTrailerMovMain.Size = New System.Drawing.Size(1145, 237)
        Me.gbTrailerMovMain.TabIndex = 1
        Me.gbTrailerMovMain.TabStop = False
        Me.gbTrailerMovMain.Tag = "TrailerCheckinData"
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Location = New System.Drawing.Point(931, 137)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(38, 13)
        Me.Label96.TabIndex = 77
        Me.Label96.Text = "Priority"
        '
        'TextBox58
        '
        Me.TextBox58.AccessibleName = "FREIGHT_CURRENCY"
        Me.TextBox58.Location = New System.Drawing.Point(1017, 137)
        Me.TextBox58.Name = "TextBox58"
        Me.TextBox58.Size = New System.Drawing.Size(97, 20)
        Me.TextBox58.TabIndex = 76
        Me.TextBox58.Tag = "PRIORITY"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(708, 137)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(68, 13)
        Me.Label66.TabIndex = 75
        Me.Label66.Text = "Queue Flag?"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(815, 145)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(0, 13)
        Me.Label65.TabIndex = 74
        '
        'CheckBox4
        '
        Me.CheckBox4.AccessibleName = "EMPTY"
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox4.Location = New System.Drawing.Point(785, 137)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox4.TabIndex = 73
        Me.CheckBox4.Tag = "QUEUE_FLAG"
        Me.CheckBox4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'GroupBox30
        '
        Me.GroupBox30.Controls.Add(Me.Label61)
        Me.GroupBox30.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox30.Controls.Add(Me.Label69)
        Me.GroupBox30.Controls.Add(Me.TextBox32)
        Me.GroupBox30.Controls.Add(Me.Label50)
        Me.GroupBox30.Controls.Add(Me.TextBox33)
        Me.GroupBox30.Controls.Add(Me.Label51)
        Me.GroupBox30.Controls.Add(Me.TextBox34)
        Me.GroupBox30.Controls.Add(Me.Label52)
        Me.GroupBox30.Controls.Add(Me.TextBox35)
        Me.GroupBox30.Controls.Add(Me.Label53)
        Me.GroupBox30.Controls.Add(Me.TextBox25)
        Me.GroupBox30.Controls.Add(Me.Label46)
        Me.GroupBox30.Controls.Add(Me.TextBox22)
        Me.GroupBox30.Location = New System.Drawing.Point(702, 9)
        Me.GroupBox30.Name = "GroupBox30"
        Me.GroupBox30.Size = New System.Drawing.Size(436, 122)
        Me.GroupBox30.TabIndex = 11
        Me.GroupBox30.TabStop = False
        Me.GroupBox30.Text = "Tractor Details"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(228, 93)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(84, 13)
        Me.Label61.TabIndex = 11
        Me.Label61.Text = "Freight Currency"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.AccessibleName = "CARRIER_ARRIVAL_DT"
        Me.DateTimePicker1.Location = New System.Drawing.Point(94, 68)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(209, 20)
        Me.DateTimePicker1.TabIndex = 4
        Me.DateTimePicker1.Tag = "CARRIER_ARRIVAL_DT"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(6, 71)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(83, 13)
        Me.Label69.TabIndex = 13
        Me.Label69.Text = "Carrier Arrival Dt"
        '
        'TextBox32
        '
        Me.TextBox32.AccessibleName = "TRACTOR_ID"
        Me.TextBox32.Location = New System.Drawing.Point(93, 16)
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Size = New System.Drawing.Size(110, 20)
        Me.TextBox32.TabIndex = 0
        Me.TextBox32.Tag = "TRACTOR_ID"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(6, 21)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(55, 13)
        Me.Label50.TabIndex = 17
        Me.Label50.Text = "Tractor ID"
        '
        'TextBox33
        '
        Me.TextBox33.AccessibleName = "DRIVER_NAME"
        Me.TextBox33.Location = New System.Drawing.Point(93, 42)
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New System.Drawing.Size(110, 20)
        Me.TextBox33.TabIndex = 2
        Me.TextBox33.Tag = "DRIVER_NAME"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(6, 45)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(66, 13)
        Me.Label51.TabIndex = 15
        Me.Label51.Text = "Driver Name"
        '
        'TextBox34
        '
        Me.TextBox34.AccessibleName = "LICENSE_PLATE_NUM"
        Me.TextBox34.Location = New System.Drawing.Point(314, 18)
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Size = New System.Drawing.Size(100, 20)
        Me.TextBox34.TabIndex = 1
        Me.TextBox34.Tag = "LICENSE_NUM"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(228, 19)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(61, 13)
        Me.Label52.TabIndex = 16
        Me.Label52.Text = "Lic. Plate #"
        '
        'TextBox35
        '
        Me.TextBox35.AccessibleName = "LICENSE_PLATE_STATE"
        Me.TextBox35.Location = New System.Drawing.Point(314, 42)
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New System.Drawing.Size(100, 20)
        Me.TextBox35.TabIndex = 3
        Me.TextBox35.Tag = "LICENSE_STATE"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(228, 45)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(79, 13)
        Me.Label53.TabIndex = 14
        Me.Label53.Text = "Lic. Plate State"
        '
        'TextBox25
        '
        Me.TextBox25.AccessibleName = "FREIGHT_AMOUNT"
        Me.TextBox25.Location = New System.Drawing.Point(93, 93)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(110, 20)
        Me.TextBox25.TabIndex = 5
        Me.TextBox25.Tag = "FREIGHT_AMOUNT"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(6, 93)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(78, 13)
        Me.Label46.TabIndex = 12
        Me.Label46.Text = "Freight Amount"
        '
        'TextBox22
        '
        Me.TextBox22.AccessibleName = "FREIGHT_CURRENCY"
        Me.TextBox22.Location = New System.Drawing.Point(314, 93)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(97, 20)
        Me.TextBox22.TabIndex = 6
        Me.TextBox22.Tag = "FREIGHT_CURRENCY"
        '
        'TextBox46
        '
        Me.TextBox46.AccessibleName = "WCS_TRANSIT_NUM"
        Me.TextBox46.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox46.Location = New System.Drawing.Point(795, 170)
        Me.TextBox46.Name = "TextBox46"
        Me.TextBox46.Size = New System.Drawing.Size(115, 20)
        Me.TextBox46.TabIndex = 1
        Me.TextBox46.Tag = "TCS_TRAILER_TAG"
        '
        'GroupBox29
        '
        Me.GroupBox29.Controls.Add(Me.TextBox38)
        Me.GroupBox29.Controls.Add(Me.Label56)
        Me.GroupBox29.Controls.Add(Me.TextBox45)
        Me.GroupBox29.Controls.Add(Me.Label63)
        Me.GroupBox29.Controls.Add(Me.Label68)
        Me.GroupBox29.Controls.Add(Me.TextBox36)
        Me.GroupBox29.Controls.Add(Me.Panel12)
        Me.GroupBox29.Controls.Add(Me.Label54)
        Me.GroupBox29.Controls.Add(Me.TextBox29)
        Me.GroupBox29.Controls.Add(Me.TextBox28)
        Me.GroupBox29.Controls.Add(Me.TextBox30)
        Me.GroupBox29.Controls.Add(Me.Label48)
        Me.GroupBox29.Controls.Add(Me.Label47)
        Me.GroupBox29.Controls.Add(Me.TextBox31)
        Me.GroupBox29.Controls.Add(Me.TextBox37)
        Me.GroupBox29.Controls.Add(Me.Label49)
        Me.GroupBox29.Controls.Add(Me.Label55)
        Me.GroupBox29.Location = New System.Drawing.Point(3, 130)
        Me.GroupBox29.Name = "GroupBox29"
        Me.GroupBox29.Size = New System.Drawing.Size(694, 75)
        Me.GroupBox29.TabIndex = 10
        Me.GroupBox29.TabStop = False
        Me.GroupBox29.Text = "Trailer Contents/Location"
        '
        'TextBox38
        '
        Me.TextBox38.AccessibleName = "INVOICE_NUMBER"
        Me.TextBox38.Location = New System.Drawing.Point(572, 16)
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New System.Drawing.Size(94, 20)
        Me.TextBox38.TabIndex = 3
        Me.TextBox38.Tag = "INVOICE_NUMBER"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(515, 20)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(52, 13)
        Me.Label56.TabIndex = 23
        Me.Label56.Text = "Invoice #"
        '
        'TextBox45
        '
        Me.TextBox45.AccessibleName = "INVOICE_NUMBER"
        Me.TextBox45.Location = New System.Drawing.Point(396, 17)
        Me.TextBox45.Name = "TextBox45"
        Me.TextBox45.Size = New System.Drawing.Size(107, 20)
        Me.TextBox45.TabIndex = 2
        Me.TextBox45.Tag = "BOL_NUMBER"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(176, 47)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(51, 13)
        Me.Label63.TabIndex = 21
        Me.Label63.Text = "Location "
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(340, 20)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(38, 13)
        Me.Label68.TabIndex = 24
        Me.Label68.Text = "BOL #"
        '
        'TextBox36
        '
        Me.TextBox36.AccessibleName = "RR_NUMBER"
        Me.TextBox36.Location = New System.Drawing.Point(233, 15)
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New System.Drawing.Size(96, 20)
        Me.TextBox36.TabIndex = 1
        Me.TextBox36.Tag = "RR_NUMBER"
        '
        'Panel12
        '
        Me.Panel12.Location = New System.Drawing.Point(580, 76)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(127, 44)
        Me.Panel12.TabIndex = 57
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(176, 21)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(54, 13)
        Me.Label54.TabIndex = 0
        Me.Label54.Text = "Receipt #"
        '
        'TextBox29
        '
        Me.TextBox29.AccessibleName = "BUILDING"
        Me.TextBox29.Location = New System.Drawing.Point(396, 44)
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New System.Drawing.Size(108, 20)
        Me.TextBox29.TabIndex = 6
        Me.TextBox29.Tag = "BUILDING"
        '
        'TextBox28
        '
        Me.TextBox28.AccessibleName = "SITE_NAME"
        Me.TextBox28.Location = New System.Drawing.Point(69, 45)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New System.Drawing.Size(92, 20)
        Me.TextBox28.TabIndex = 4
        Me.TextBox28.Tag = "SITE_NAME"
        '
        'TextBox30
        '
        Me.TextBox30.AccessibleName = "LOCATION"
        Me.TextBox30.Location = New System.Drawing.Point(233, 41)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New System.Drawing.Size(98, 20)
        Me.TextBox30.TabIndex = 5
        Me.TextBox30.Tag = "LOCATION"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(337, 47)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(44, 13)
        Me.Label48.TabIndex = 20
        Me.Label48.Text = "Building"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(9, 50)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(56, 13)
        Me.Label47.TabIndex = 22
        Me.Label47.Text = "Site Name"
        '
        'TextBox31
        '
        Me.TextBox31.AccessibleName = "BUILDING_LIST"
        Me.TextBox31.Location = New System.Drawing.Point(571, 41)
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New System.Drawing.Size(97, 20)
        Me.TextBox31.TabIndex = 7
        Me.TextBox31.Tag = "BUILDING_LIST"
        '
        'TextBox37
        '
        Me.TextBox37.AccessibleName = "SHIPMENT_ID"
        Me.TextBox37.Location = New System.Drawing.Point(67, 19)
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.Size = New System.Drawing.Size(94, 20)
        Me.TextBox37.TabIndex = 0
        Me.TextBox37.Tag = "SHIPMENT_ID"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(515, 46)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(50, 13)
        Me.Label49.TabIndex = 19
        Me.Label49.Text = "Bldg. List"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(7, 22)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(42, 13)
        Me.Label55.TabIndex = 1
        Me.Label55.Text = "Ship ID"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(708, 178)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(82, 13)
        Me.Label70.TabIndex = 70
        Me.Label70.Text = "TCS Trailer Tag"
        '
        'btnTrlMovReset
        '
        Me.btnTrlMovReset.AccessibleName = "TrailerCheckOut"
        Me.btnTrlMovReset.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnTrlMovReset.Location = New System.Drawing.Point(466, 209)
        Me.btnTrlMovReset.Name = "btnTrlMovReset"
        Me.btnTrlMovReset.Size = New System.Drawing.Size(67, 23)
        Me.btnTrlMovReset.TabIndex = 4
        Me.btnTrlMovReset.Tag = ""
        Me.btnTrlMovReset.Text = "Clear All "
        Me.btnTrlMovReset.UseVisualStyleBackColor = True
        '
        'TextBox39
        '
        Me.TextBox39.AccessibleName = "TCS_TRANSIT_NUM"
        Me.TextBox39.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox39.Location = New System.Drawing.Point(1016, 177)
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.Size = New System.Drawing.Size(113, 20)
        Me.TextBox39.TabIndex = 2
        Me.TextBox39.Tag = "TCS_TRANSIT_NUM"
        '
        'btnTrlMovTCkout
        '
        Me.btnTrlMovTCkout.AccessibleName = "TrailerCheckOut"
        Me.btnTrlMovTCkout.Location = New System.Drawing.Point(108, 209)
        Me.btnTrlMovTCkout.Name = "btnTrlMovTCkout"
        Me.btnTrlMovTCkout.Size = New System.Drawing.Size(97, 23)
        Me.btnTrlMovTCkout.TabIndex = 1
        Me.btnTrlMovTCkout.Tag = "TrailerData"
        Me.btnTrlMovTCkout.Text = "Checkout Trailer"
        Me.btnTrlMovTCkout.UseVisualStyleBackColor = True
        '
        'GroupBox27
        '
        Me.GroupBox27.Controls.Add(Me.TextBox10)
        Me.GroupBox27.Controls.Add(Me.TextBox8)
        Me.GroupBox27.Controls.Add(Me.TextBox9)
        Me.GroupBox27.Controls.Add(Me.Label71)
        Me.GroupBox27.Controls.Add(Me.CheckBox1)
        Me.GroupBox27.Controls.Add(Me.TextBox27)
        Me.GroupBox27.Controls.Add(Me.Label40)
        Me.GroupBox27.Controls.Add(Me.CheckBox2)
        Me.GroupBox27.Controls.Add(Me.Label60)
        Me.GroupBox27.Controls.Add(Me.TextBox16)
        Me.GroupBox27.Controls.Add(Me.TextBox17)
        Me.GroupBox27.Controls.Add(Me.TextBox18)
        Me.GroupBox27.Controls.Add(Me.Label41)
        Me.GroupBox27.Controls.Add(Me.TextBox19)
        Me.GroupBox27.Controls.Add(Me.TextBox20)
        Me.GroupBox27.Controls.Add(Me.Label42)
        Me.GroupBox27.Controls.Add(Me.TextBox21)
        Me.GroupBox27.Controls.Add(Me.TextBox23)
        Me.GroupBox27.Controls.Add(Me.Label43)
        Me.GroupBox27.Controls.Add(Me.Label59)
        Me.GroupBox27.Controls.Add(Me.Label44)
        Me.GroupBox27.Controls.Add(Me.Label58)
        Me.GroupBox27.Controls.Add(Me.TextBox24)
        Me.GroupBox27.Controls.Add(Me.Label45)
        Me.GroupBox27.Controls.Add(Me.TextBox26)
        Me.GroupBox27.Location = New System.Drawing.Point(3, 9)
        Me.GroupBox27.Name = "GroupBox27"
        Me.GroupBox27.Size = New System.Drawing.Size(694, 122)
        Me.GroupBox27.TabIndex = 9
        Me.GroupBox27.TabStop = False
        Me.GroupBox27.Text = "Trailer Info"
        '
        'TextBox10
        '
        Me.TextBox10.AccessibleName = "TYPE"
        Me.TextBox10.Location = New System.Drawing.Point(233, 42)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(120, 20)
        Me.TextBox10.TabIndex = 104
        Me.TextBox10.Tag = "TEMP_CODE"
        '
        'TextBox8
        '
        Me.TextBox8.AccessibleName = "LOCATION"
        Me.TextBox8.Location = New System.Drawing.Point(233, 14)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(122, 20)
        Me.TextBox8.TabIndex = 103
        Me.TextBox8.Tag = "TRAILER_NUMBER"
        '
        'TextBox9
        '
        Me.TextBox9.AccessibleName = "SITE_NAME"
        Me.TextBox9.Location = New System.Drawing.Point(61, 13)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(100, 20)
        Me.TextBox9.TabIndex = 102
        Me.TextBox9.Tag = "TRUCK_LINE"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(5, 97)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(88, 13)
        Me.Label71.TabIndex = 25
        Me.Label71.Text = "Usable?/Reason"
        '
        'CheckBox1
        '
        Me.CheckBox1.AccessibleName = "USABLE"
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(105, 98)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Tag = "USABLE"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox27
        '
        Me.TextBox27.AccessibleName = "UNUSABLE_REASON"
        Me.TextBox27.Location = New System.Drawing.Point(126, 94)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New System.Drawing.Size(495, 20)
        Me.TextBox27.TabIndex = 8
        Me.TextBox27.Tag = "UNUSABLE_REASON"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(373, 45)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(105, 13)
        Me.Label40.TabIndex = 21
        Me.Label40.Text = "Dimensions (L/W/H)"
        '
        'CheckBox2
        '
        Me.CheckBox2.AccessibleName = "EMPTY"
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox2.Location = New System.Drawing.Point(488, 15)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Tag = "EMPTY"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(440, 15)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(42, 13)
        Me.Label60.TabIndex = 23
        Me.Label60.Text = "Empty?"
        '
        'TextBox16
        '
        Me.TextBox16.AccessibleName = "LENGTH"
        Me.TextBox16.Location = New System.Drawing.Point(487, 43)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(40, 20)
        Me.TextBox16.TabIndex = 9
        Me.TextBox16.Tag = "LENGTH"
        '
        'TextBox17
        '
        Me.TextBox17.AccessibleName = "WIDTH"
        Me.TextBox17.Location = New System.Drawing.Point(533, 43)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(41, 20)
        Me.TextBox17.TabIndex = 10
        Me.TextBox17.Tag = "WIDTH"
        '
        'TextBox18
        '
        Me.TextBox18.AccessibleName = "HEIGHT"
        Me.TextBox18.Location = New System.Drawing.Point(580, 43)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(40, 20)
        Me.TextBox18.TabIndex = 11
        Me.TextBox18.Tag = "HEIGHT"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(373, 69)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(112, 13)
        Me.Label41.TabIndex = 20
        Me.Label41.Text = "Weight(Emp/Full/Est.)"
        '
        'TextBox19
        '
        Me.TextBox19.AccessibleName = "EMPTY_WEIGHT"
        Me.TextBox19.Location = New System.Drawing.Point(488, 68)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(40, 20)
        Me.TextBox19.TabIndex = 12
        Me.TextBox19.Tag = "EMPTY_WEIGHT"
        '
        'TextBox20
        '
        Me.TextBox20.AccessibleName = "FULL_WEIGHT"
        Me.TextBox20.Location = New System.Drawing.Point(534, 68)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(41, 20)
        Me.TextBox20.TabIndex = 13
        Me.TextBox20.Tag = "FULL_WEIGHT"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(167, 45)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(62, 13)
        Me.Label42.TabIndex = 0
        Me.Label42.Text = "Temp Code"
        '
        'TextBox21
        '
        Me.TextBox21.AccessibleName = "EST_WEIGHT"
        Me.TextBox21.Location = New System.Drawing.Point(580, 68)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(41, 20)
        Me.TextBox21.TabIndex = 14
        Me.TextBox21.Tag = "EST_WEIGHT"
        '
        'TextBox23
        '
        Me.TextBox23.AccessibleName = "TYPE"
        Me.TextBox23.Location = New System.Drawing.Point(61, 42)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(100, 20)
        Me.TextBox23.TabIndex = 3
        Me.TextBox23.Tag = "TRAILER_TYPE"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(3, 45)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(31, 13)
        Me.Label43.TabIndex = 24
        Me.Label43.Text = "Type"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(167, 15)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(48, 13)
        Me.Label59.TabIndex = 1
        Me.Label59.Text = "Trailer Id"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(5, 71)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(34, 13)
        Me.Label44.TabIndex = 23
        Me.Label44.Text = "Origin"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(3, 15)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(58, 13)
        Me.Label58.TabIndex = 18
        Me.Label58.Text = "Truck Line"
        '
        'TextBox24
        '
        Me.TextBox24.AccessibleName = "ORIGIN"
        Me.TextBox24.Location = New System.Drawing.Point(61, 68)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(100, 20)
        Me.TextBox24.TabIndex = 5
        Me.TextBox24.Tag = "ORIGIN"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(167, 71)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(49, 13)
        Me.Label45.TabIndex = 22
        Me.Label45.Text = "Contents"
        '
        'TextBox26
        '
        Me.TextBox26.AccessibleName = "CONTENTS"
        Me.TextBox26.Location = New System.Drawing.Point(233, 68)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(122, 20)
        Me.TextBox26.TabIndex = 6
        Me.TextBox26.Tag = "CONTENTS"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(930, 180)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(76, 13)
        Me.Label57.TabIndex = 72
        Me.Label57.Text = "TCS Transit #."
        '
        'btnTrlMovTCkin
        '
        Me.btnTrlMovTCkin.AccessibleName = "TrailerCheckin"
        Me.btnTrlMovTCkin.Location = New System.Drawing.Point(5, 209)
        Me.btnTrlMovTCkin.Name = "btnTrlMovTCkin"
        Me.btnTrlMovTCkin.Size = New System.Drawing.Size(97, 23)
        Me.btnTrlMovTCkin.TabIndex = 0
        Me.btnTrlMovTCkin.Tag = "{""TrailerData"", """","""")"
        Me.btnTrlMovTCkin.Text = "Check-In Trailer"
        Me.btnTrlMovTCkin.UseVisualStyleBackColor = True
        '
        'lblWMSTCSTrlData
        '
        Me.lblWMSTCSTrlData.AutoSize = True
        Me.lblWMSTCSTrlData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWMSTCSTrlData.Location = New System.Drawing.Point(6, 5)
        Me.lblWMSTCSTrlData.Name = "lblWMSTCSTrlData"
        Me.lblWMSTCSTrlData.Size = New System.Drawing.Size(171, 13)
        Me.lblWMSTCSTrlData.TabIndex = 3
        Me.lblWMSTCSTrlData.Text = "WMS TCS Trailer View Data "
        '
        'btnGetTrlMovData
        '
        Me.btnGetTrlMovData.Location = New System.Drawing.Point(1065, 3)
        Me.btnGetTrlMovData.Name = "btnGetTrlMovData"
        Me.btnGetTrlMovData.Size = New System.Drawing.Size(81, 22)
        Me.btnGetTrlMovData.TabIndex = 0
        Me.btnGetTrlMovData.TabStop = False
        Me.btnGetTrlMovData.Text = "Get Data"
        Me.btnGetTrlMovData.UseVisualStyleBackColor = True
        '
        'TabPage17
        '
        Me.TabPage17.Controls.Add(Me.chkbTrlMvmtShowEmpty)
        Me.TabPage17.Controls.Add(Me.chkbTrlMvmtReadyToShip)
        Me.TabPage17.Controls.Add(Me.Label33)
        Me.TabPage17.Controls.Add(Me.chkbTrlMvmtThisSessionOnly)
        Me.TabPage17.Controls.Add(Me.dgvTrlMvmtTCSTrailerView)
        Me.TabPage17.Controls.Add(Me.Label86)
        Me.TabPage17.Controls.Add(Me.chkBxTcsEmuTrlMovWMSSessOnly)
        Me.TabPage17.Controls.Add(Me.dgvTcsTrailerReq)
        Me.TabPage17.Controls.Add(Me.btnLoadTrailerMovData)
        Me.TabPage17.Controls.Add(Me.gbxTrailerMovement)
        Me.TabPage17.Location = New System.Drawing.Point(4, 22)
        Me.TabPage17.Name = "TabPage17"
        Me.TabPage17.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage17.Size = New System.Drawing.Size(1173, 404)
        Me.TabPage17.TabIndex = 1
        Me.TabPage17.Text = "Trailer Movement"
        Me.TabPage17.UseVisualStyleBackColor = True
        '
        'chkbTrlMvmtShowEmpty
        '
        Me.chkbTrlMvmtShowEmpty.AutoSize = True
        Me.chkbTrlMvmtShowEmpty.Location = New System.Drawing.Point(512, 3)
        Me.chkbTrlMvmtShowEmpty.Name = "chkbTrlMvmtShowEmpty"
        Me.chkbTrlMvmtShowEmpty.Size = New System.Drawing.Size(85, 17)
        Me.chkbTrlMvmtShowEmpty.TabIndex = 17
        Me.chkbTrlMvmtShowEmpty.Text = "Show Empty"
        Me.chkbTrlMvmtShowEmpty.UseVisualStyleBackColor = True
        '
        'chkbTrlMvmtReadyToShip
        '
        Me.chkbTrlMvmtReadyToShip.AutoSize = True
        Me.chkbTrlMvmtReadyToShip.Location = New System.Drawing.Point(361, 3)
        Me.chkbTrlMvmtReadyToShip.Name = "chkbTrlMvmtReadyToShip"
        Me.chkbTrlMvmtReadyToShip.Size = New System.Drawing.Size(93, 17)
        Me.chkbTrlMvmtReadyToShip.TabIndex = 16
        Me.chkbTrlMvmtReadyToShip.Text = "Ready to Ship"
        Me.chkbTrlMvmtReadyToShip.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(6, 7)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(136, 13)
        Me.Label33.TabIndex = 15
        Me.Label33.Text = "WMS TCS Trailer Data"
        '
        'chkbTrlMvmtThisSessionOnly
        '
        Me.chkbTrlMvmtThisSessionOnly.AutoSize = True
        Me.chkbTrlMvmtThisSessionOnly.Location = New System.Drawing.Point(225, 6)
        Me.chkbTrlMvmtThisSessionOnly.Name = "chkbTrlMvmtThisSessionOnly"
        Me.chkbTrlMvmtThisSessionOnly.Size = New System.Drawing.Size(110, 17)
        Me.chkbTrlMvmtThisSessionOnly.TabIndex = 14
        Me.chkbTrlMvmtThisSessionOnly.Text = "Only This Session"
        Me.chkbTrlMvmtThisSessionOnly.UseVisualStyleBackColor = True
        '
        'dgvTrlMvmtTCSTrailerView
        '
        Me.dgvTrlMvmtTCSTrailerView.AllowUserToAddRows = False
        Me.dgvTrlMvmtTCSTrailerView.AllowUserToDeleteRows = False
        Me.dgvTrlMvmtTCSTrailerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTrlMvmtTCSTrailerView.Location = New System.Drawing.Point(6, 25)
        Me.dgvTrlMvmtTCSTrailerView.Name = "dgvTrlMvmtTCSTrailerView"
        Me.dgvTrlMvmtTCSTrailerView.ReadOnly = True
        Me.dgvTrlMvmtTCSTrailerView.Size = New System.Drawing.Size(711, 201)
        Me.dgvTrlMvmtTCSTrailerView.TabIndex = 13
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(859, 11)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(163, 13)
        Me.Label86.TabIndex = 12
        Me.Label86.Text = "WMS TCS Trailer Req Data"
        '
        'chkBxTcsEmuTrlMovWMSSessOnly
        '
        Me.chkBxTcsEmuTrlMovWMSSessOnly.AutoSize = True
        Me.chkBxTcsEmuTrlMovWMSSessOnly.Location = New System.Drawing.Point(1033, 7)
        Me.chkBxTcsEmuTrlMovWMSSessOnly.Name = "chkBxTcsEmuTrlMovWMSSessOnly"
        Me.chkBxTcsEmuTrlMovWMSSessOnly.Size = New System.Drawing.Size(110, 17)
        Me.chkBxTcsEmuTrlMovWMSSessOnly.TabIndex = 11
        Me.chkBxTcsEmuTrlMovWMSSessOnly.Text = "Only This Session"
        Me.chkBxTcsEmuTrlMovWMSSessOnly.UseVisualStyleBackColor = True
        '
        'dgvTcsTrailerReq
        '
        Me.dgvTcsTrailerReq.AllowUserToAddRows = False
        Me.dgvTcsTrailerReq.AllowUserToDeleteRows = False
        Me.dgvTcsTrailerReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTcsTrailerReq.Location = New System.Drawing.Point(723, 25)
        Me.dgvTcsTrailerReq.Name = "dgvTcsTrailerReq"
        Me.dgvTcsTrailerReq.ReadOnly = True
        Me.dgvTcsTrailerReq.Size = New System.Drawing.Size(444, 363)
        Me.dgvTcsTrailerReq.TabIndex = 10
        '
        'btnLoadTrailerMovData
        '
        Me.btnLoadTrailerMovData.Location = New System.Drawing.Point(614, 0)
        Me.btnLoadTrailerMovData.Name = "btnLoadTrailerMovData"
        Me.btnLoadTrailerMovData.Size = New System.Drawing.Size(103, 23)
        Me.btnLoadTrailerMovData.TabIndex = 8
        Me.btnLoadTrailerMovData.TabStop = False
        Me.btnLoadTrailerMovData.Text = "Get Data"
        Me.btnLoadTrailerMovData.UseVisualStyleBackColor = True
        '
        'gbxTrailerMovement
        '
        Me.gbxTrailerMovement.Controls.Add(Me.btnTrlMovementReset)
        Me.gbxTrailerMovement.Controls.Add(Me.btnTrlMovTrlChgPriority)
        Me.gbxTrailerMovement.Controls.Add(Me.Label97)
        Me.gbxTrailerMovement.Controls.Add(Me.TextBox60)
        Me.gbxTrailerMovement.Controls.Add(Me.Label95)
        Me.gbxTrailerMovement.Controls.Add(Me.CheckBox5)
        Me.gbxTrailerMovement.Controls.Add(Me.TextBox43)
        Me.gbxTrailerMovement.Controls.Add(Me.TextBox42)
        Me.gbxTrailerMovement.Controls.Add(Me.btnTrlMovTrlLocUpd)
        Me.gbxTrailerMovement.Controls.Add(Me.btnTrlMovTrlMovCancel)
        Me.gbxTrailerMovement.Controls.Add(Me.btnTrlMovTrlLocReq)
        Me.gbxTrailerMovement.Controls.Add(Me.TextBox57)
        Me.gbxTrailerMovement.Controls.Add(Me.Label85)
        Me.gbxTrailerMovement.Controls.Add(Me.TextBox56)
        Me.gbxTrailerMovement.Controls.Add(Me.Label84)
        Me.gbxTrailerMovement.Controls.Add(Me.Label83)
        Me.gbxTrailerMovement.Controls.Add(Me.CheckBox3)
        Me.gbxTrailerMovement.Controls.Add(Me.TextBox55)
        Me.gbxTrailerMovement.Controls.Add(Me.Label79)
        Me.gbxTrailerMovement.Controls.Add(Me.TextBox51)
        Me.gbxTrailerMovement.Controls.Add(Me.TextBox52)
        Me.gbxTrailerMovement.Controls.Add(Me.TextBox53)
        Me.gbxTrailerMovement.Controls.Add(Me.Label80)
        Me.gbxTrailerMovement.Controls.Add(Me.Label81)
        Me.gbxTrailerMovement.Controls.Add(Me.TextBox54)
        Me.gbxTrailerMovement.Controls.Add(Me.Label82)
        Me.gbxTrailerMovement.Controls.Add(Me.Label76)
        Me.gbxTrailerMovement.Controls.Add(Me.Label77)
        Me.gbxTrailerMovement.Location = New System.Drawing.Point(6, 232)
        Me.gbxTrailerMovement.Name = "gbxTrailerMovement"
        Me.gbxTrailerMovement.Size = New System.Drawing.Size(711, 156)
        Me.gbxTrailerMovement.TabIndex = 7
        Me.gbxTrailerMovement.TabStop = False
        '
        'btnTrlMovementReset
        '
        Me.btnTrlMovementReset.AccessibleName = "TrailerCheckOut"
        Me.btnTrlMovementReset.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnTrlMovementReset.Location = New System.Drawing.Point(528, 125)
        Me.btnTrlMovementReset.Name = "btnTrlMovementReset"
        Me.btnTrlMovementReset.Size = New System.Drawing.Size(67, 23)
        Me.btnTrlMovementReset.TabIndex = 90
        Me.btnTrlMovementReset.Tag = ""
        Me.btnTrlMovementReset.Text = "Clear All "
        Me.btnTrlMovementReset.UseVisualStyleBackColor = True
        '
        'btnTrlMovTrlChgPriority
        '
        Me.btnTrlMovTrlChgPriority.Location = New System.Drawing.Point(369, 124)
        Me.btnTrlMovTrlChgPriority.Name = "btnTrlMovTrlChgPriority"
        Me.btnTrlMovTrlChgPriority.Size = New System.Drawing.Size(113, 25)
        Me.btnTrlMovTrlChgPriority.TabIndex = 89
        Me.btnTrlMovTrlChgPriority.Text = "Trl. Change Priority"
        Me.btnTrlMovTrlChgPriority.UseVisualStyleBackColor = True
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Location = New System.Drawing.Point(423, 96)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(38, 13)
        Me.Label97.TabIndex = 88
        Me.Label97.Text = "Priority"
        '
        'TextBox60
        '
        Me.TextBox60.AccessibleName = "FREIGHT_CURRENCY"
        Me.TextBox60.Location = New System.Drawing.Point(509, 93)
        Me.TextBox60.Name = "TextBox60"
        Me.TextBox60.Size = New System.Drawing.Size(117, 20)
        Me.TextBox60.TabIndex = 87
        Me.TextBox60.Tag = "PRIORITY"
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Location = New System.Drawing.Point(237, 98)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(68, 13)
        Me.Label95.TabIndex = 86
        Me.Label95.Text = "Queue Flag?"
        '
        'CheckBox5
        '
        Me.CheckBox5.AccessibleName = "EMPTY"
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox5.Location = New System.Drawing.Point(314, 98)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox5.TabIndex = 85
        Me.CheckBox5.Tag = "QUEUE_FLAG"
        Me.CheckBox5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'TextBox43
        '
        Me.TextBox43.AccessibleName = "LOCATION"
        Me.TextBox43.Location = New System.Drawing.Point(258, 8)
        Me.TextBox43.Name = "TextBox43"
        Me.TextBox43.Size = New System.Drawing.Size(88, 20)
        Me.TextBox43.TabIndex = 84
        Me.TextBox43.Tag = "TRAILER_NUMBER"
        '
        'TextBox42
        '
        Me.TextBox42.AccessibleName = "SITE_NAME"
        Me.TextBox42.Location = New System.Drawing.Point(86, 9)
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.Size = New System.Drawing.Size(96, 20)
        Me.TextBox42.TabIndex = 83
        Me.TextBox42.Tag = "TRUCK_LINE"
        '
        'btnTrlMovTrlLocUpd
        '
        Me.btnTrlMovTrlLocUpd.Location = New System.Drawing.Point(124, 124)
        Me.btnTrlMovTrlLocUpd.Name = "btnTrlMovTrlLocUpd"
        Me.btnTrlMovTrlLocUpd.Size = New System.Drawing.Size(106, 23)
        Me.btnTrlMovTrlLocUpd.TabIndex = 82
        Me.btnTrlMovTrlLocUpd.TabStop = False
        Me.btnTrlMovTrlLocUpd.Text = "Trl. Loc Update"
        Me.btnTrlMovTrlLocUpd.UseVisualStyleBackColor = True
        '
        'btnTrlMovTrlMovCancel
        '
        Me.btnTrlMovTrlMovCancel.AccessibleName = "TrailerCheckin"
        Me.btnTrlMovTrlMovCancel.Location = New System.Drawing.Point(240, 125)
        Me.btnTrlMovTrlMovCancel.Name = "btnTrlMovTrlMovCancel"
        Me.btnTrlMovTrlMovCancel.Size = New System.Drawing.Size(117, 23)
        Me.btnTrlMovTrlMovCancel.TabIndex = 81
        Me.btnTrlMovTrlMovCancel.Tag = ""
        Me.btnTrlMovTrlMovCancel.Text = "Trl. Move Cancel"
        Me.btnTrlMovTrlMovCancel.UseVisualStyleBackColor = True
        '
        'TextBox57
        '
        Me.TextBox57.AccessibleName = "BUILDING"
        Me.TextBox57.Location = New System.Drawing.Point(86, 92)
        Me.TextBox57.Name = "TextBox57"
        Me.TextBox57.Size = New System.Drawing.Size(120, 20)
        Me.TextBox57.TabIndex = 77
        Me.TextBox57.Tag = "REQUEST_ID"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(5, 96)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(59, 13)
        Me.Label85.TabIndex = 78
        Me.Label85.Text = "Request Id"
        '
        'TextBox56
        '
        Me.TextBox56.AccessibleName = "WCS_TRANSIT_NUM"
        Me.TextBox56.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox56.Location = New System.Drawing.Point(509, 66)
        Me.TextBox56.Name = "TextBox56"
        Me.TextBox56.Size = New System.Drawing.Size(117, 20)
        Me.TextBox56.TabIndex = 71
        Me.TextBox56.Tag = "TCS_TRAILER_TAG"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Location = New System.Drawing.Point(423, 69)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(82, 13)
        Me.Label84.TabIndex = 72
        Me.Label84.Text = "TCS Trailer Tag"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(5, 70)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(88, 13)
        Me.Label83.TabIndex = 33
        Me.Label83.Text = "Usable?/Reason"
        '
        'CheckBox3
        '
        Me.CheckBox3.AccessibleName = "USABLE"
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(95, 69)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox3.TabIndex = 31
        Me.CheckBox3.Tag = "USABLE"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'TextBox55
        '
        Me.TextBox55.AccessibleName = "UNUSABLE_REASON"
        Me.TextBox55.Location = New System.Drawing.Point(116, 66)
        Me.TextBox55.Name = "TextBox55"
        Me.TextBox55.Size = New System.Drawing.Size(290, 20)
        Me.TextBox55.TabIndex = 32
        Me.TextBox55.Tag = "UNUSABLE_REASON"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(189, 42)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(51, 13)
        Me.Label79.TabIndex = 29
        Me.Label79.Text = "Location "
        '
        'TextBox51
        '
        Me.TextBox51.AccessibleName = "BUILDING"
        Me.TextBox51.Location = New System.Drawing.Point(412, 38)
        Me.TextBox51.Name = "TextBox51"
        Me.TextBox51.Size = New System.Drawing.Size(75, 20)
        Me.TextBox51.TabIndex = 25
        Me.TextBox51.Tag = "BUILDING"
        '
        'TextBox52
        '
        Me.TextBox52.AccessibleName = "SITE_NAME"
        Me.TextBox52.Location = New System.Drawing.Point(86, 39)
        Me.TextBox52.Name = "TextBox52"
        Me.TextBox52.Size = New System.Drawing.Size(96, 20)
        Me.TextBox52.TabIndex = 23
        Me.TextBox52.Tag = "SITE_NAME"
        '
        'TextBox53
        '
        Me.TextBox53.AccessibleName = "LOCATION"
        Me.TextBox53.Location = New System.Drawing.Point(258, 36)
        Me.TextBox53.Name = "TextBox53"
        Me.TextBox53.Size = New System.Drawing.Size(88, 20)
        Me.TextBox53.TabIndex = 24
        Me.TextBox53.Tag = "LOCATION"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(362, 38)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(44, 13)
        Me.Label80.TabIndex = 28
        Me.Label80.Text = "Building"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(5, 39)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(56, 13)
        Me.Label81.TabIndex = 30
        Me.Label81.Text = "Site Name"
        '
        'TextBox54
        '
        Me.TextBox54.AccessibleName = "BUILDING_LIST"
        Me.TextBox54.Location = New System.Drawing.Point(568, 36)
        Me.TextBox54.Name = "TextBox54"
        Me.TextBox54.Size = New System.Drawing.Size(58, 20)
        Me.TextBox54.TabIndex = 26
        Me.TextBox54.Tag = "BUILDING_LIST"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(501, 39)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(50, 13)
        Me.Label82.TabIndex = 27
        Me.Label82.Text = "Bldg. List"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(189, 14)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(48, 13)
        Me.Label76.TabIndex = 21
        Me.Label76.Text = "Trailer Id"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(5, 11)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(58, 13)
        Me.Label77.TabIndex = 22
        Me.Label77.Text = "Truck Line"
        '
        'TabPage18
        '
        Me.TabPage18.Controls.Add(Me.Label88)
        Me.TabPage18.Controls.Add(Me.dgvTcsLocation)
        Me.TabPage18.Controls.Add(Me.Label98)
        Me.TabPage18.Controls.Add(Me.chkbTCSTrlExecCurSessOnly)
        Me.TabPage18.Controls.Add(Me.btnLoadTrlExecTrlReqData)
        Me.TabPage18.Controls.Add(Me.dgTCSTrlReqbySessionViewData)
        Me.TabPage18.Controls.Add(Me.gbxTrailerMoveExec)
        Me.TabPage18.Location = New System.Drawing.Point(4, 22)
        Me.TabPage18.Name = "TabPage18"
        Me.TabPage18.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage18.Size = New System.Drawing.Size(1173, 404)
        Me.TabPage18.TabIndex = 2
        Me.TabPage18.Text = "Trailer Move Execution"
        Me.TabPage18.UseVisualStyleBackColor = True
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.Location = New System.Drawing.Point(822, 9)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(149, 13)
        Me.Label88.TabIndex = 16
        Me.Label88.Text = "WMS TCS Location Data"
        '
        'dgvTcsLocation
        '
        Me.dgvTcsLocation.AllowUserToAddRows = False
        Me.dgvTcsLocation.AllowUserToDeleteRows = False
        Me.dgvTcsLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTcsLocation.Location = New System.Drawing.Point(822, 27)
        Me.dgvTcsLocation.Name = "dgvTcsLocation"
        Me.dgvTcsLocation.ReadOnly = True
        Me.dgvTcsLocation.Size = New System.Drawing.Size(345, 371)
        Me.dgvTcsLocation.TabIndex = 15
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.Location = New System.Drawing.Point(10, 6)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(163, 13)
        Me.Label98.TabIndex = 14
        Me.Label98.Text = "WMS TCS Trailer Req Data"
        '
        'chkbTCSTrlExecCurSessOnly
        '
        Me.chkbTCSTrlExecCurSessOnly.AutoSize = True
        Me.chkbTCSTrlExecCurSessOnly.Location = New System.Drawing.Point(243, 6)
        Me.chkbTCSTrlExecCurSessOnly.Name = "chkbTCSTrlExecCurSessOnly"
        Me.chkbTCSTrlExecCurSessOnly.Size = New System.Drawing.Size(110, 17)
        Me.chkbTCSTrlExecCurSessOnly.TabIndex = 13
        Me.chkbTCSTrlExecCurSessOnly.Text = "This Session Only"
        Me.chkbTCSTrlExecCurSessOnly.UseVisualStyleBackColor = True
        '
        'btnLoadTrlExecTrlReqData
        '
        Me.btnLoadTrlExecTrlReqData.Location = New System.Drawing.Point(724, 3)
        Me.btnLoadTrlExecTrlReqData.Name = "btnLoadTrlExecTrlReqData"
        Me.btnLoadTrlExecTrlReqData.Size = New System.Drawing.Size(92, 20)
        Me.btnLoadTrlExecTrlReqData.TabIndex = 10
        Me.btnLoadTrlExecTrlReqData.TabStop = False
        Me.btnLoadTrlExecTrlReqData.Text = "Get Data"
        Me.btnLoadTrlExecTrlReqData.UseVisualStyleBackColor = True
        '
        'dgTCSTrlReqbySessionViewData
        '
        Me.dgTCSTrlReqbySessionViewData.AllowUserToAddRows = False
        Me.dgTCSTrlReqbySessionViewData.AllowUserToDeleteRows = False
        Me.dgTCSTrlReqbySessionViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTCSTrlReqbySessionViewData.Location = New System.Drawing.Point(12, 27)
        Me.dgTCSTrlReqbySessionViewData.Name = "dgTCSTrlReqbySessionViewData"
        Me.dgTCSTrlReqbySessionViewData.ReadOnly = True
        Me.dgTCSTrlReqbySessionViewData.Size = New System.Drawing.Size(804, 186)
        Me.dgTCSTrlReqbySessionViewData.TabIndex = 11
        '
        'gbxTrailerMoveExec
        '
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox12)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label35)
        Me.gbxTrailerMoveExec.Controls.Add(Me.btnTrlMovExecReset)
        Me.gbxTrailerMoveExec.Controls.Add(Me.btnTrlMovExecTrlChgPriority)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox65)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox66)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox44)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label67)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label64)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox41)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox40)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label62)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label75)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox49)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label74)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox50)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox47)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label72)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox48)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label73)
        Me.gbxTrailerMoveExec.Controls.Add(Me.btnTrlMovTrlMovPickup)
        Me.gbxTrailerMoveExec.Controls.Add(Me.btnTrlMovTrlMovComp)
        Me.gbxTrailerMoveExec.Controls.Add(Me.btnTrlMovExecTrlMovCancel)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox59)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label87)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label89)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox61)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox62)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox63)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label90)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label91)
        Me.gbxTrailerMoveExec.Controls.Add(Me.TextBox64)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label92)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label93)
        Me.gbxTrailerMoveExec.Controls.Add(Me.Label94)
        Me.gbxTrailerMoveExec.Location = New System.Drawing.Point(6, 219)
        Me.gbxTrailerMoveExec.Name = "gbxTrailerMoveExec"
        Me.gbxTrailerMoveExec.Size = New System.Drawing.Size(810, 179)
        Me.gbxTrailerMoveExec.TabIndex = 8
        Me.gbxTrailerMoveExec.TabStop = False
        '
        'TextBox12
        '
        Me.TextBox12.AccessibleName = "BUILDING"
        Me.TextBox12.Location = New System.Drawing.Point(85, 121)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(103, 20)
        Me.TextBox12.TabIndex = 106
        Me.TextBox12.Tag = "USER_ID"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(9, 124)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(41, 13)
        Me.Label35.TabIndex = 107
        Me.Label35.Text = "User Id"
        '
        'btnTrlMovExecReset
        '
        Me.btnTrlMovExecReset.AccessibleName = "TrailerCheckOut"
        Me.btnTrlMovExecReset.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnTrlMovExecReset.Location = New System.Drawing.Point(504, 148)
        Me.btnTrlMovExecReset.Name = "btnTrlMovExecReset"
        Me.btnTrlMovExecReset.Size = New System.Drawing.Size(67, 23)
        Me.btnTrlMovExecReset.TabIndex = 103
        Me.btnTrlMovExecReset.Tag = ""
        Me.btnTrlMovExecReset.Text = "Clear All "
        Me.btnTrlMovExecReset.UseVisualStyleBackColor = True
        '
        'btnTrlMovExecTrlChgPriority
        '
        Me.btnTrlMovExecTrlChgPriority.AccessibleName = "TrailerCheckin"
        Me.btnTrlMovExecTrlChgPriority.Location = New System.Drawing.Point(366, 149)
        Me.btnTrlMovExecTrlChgPriority.Name = "btnTrlMovExecTrlChgPriority"
        Me.btnTrlMovExecTrlChgPriority.Size = New System.Drawing.Size(117, 23)
        Me.btnTrlMovExecTrlChgPriority.TabIndex = 102
        Me.btnTrlMovExecTrlChgPriority.Tag = ""
        Me.btnTrlMovExecTrlChgPriority.Text = "Change Priority"
        Me.btnTrlMovExecTrlChgPriority.UseVisualStyleBackColor = True
        '
        'TextBox65
        '
        Me.TextBox65.AccessibleName = "LOCATION"
        Me.TextBox65.Location = New System.Drawing.Point(270, 14)
        Me.TextBox65.Name = "TextBox65"
        Me.TextBox65.Size = New System.Drawing.Size(100, 20)
        Me.TextBox65.TabIndex = 101
        Me.TextBox65.Tag = "TRAILER_NUMBER"
        '
        'TextBox66
        '
        Me.TextBox66.AccessibleName = "SITE_NAME"
        Me.TextBox66.Location = New System.Drawing.Point(86, 13)
        Me.TextBox66.Name = "TextBox66"
        Me.TextBox66.Size = New System.Drawing.Size(103, 20)
        Me.TextBox66.TabIndex = 100
        Me.TextBox66.Tag = "TRUCK_LINE"
        '
        'TextBox44
        '
        Me.TextBox44.AccessibleName = "LICENSE_PLATE_NUM"
        Me.TextBox44.Location = New System.Drawing.Point(450, 92)
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.Size = New System.Drawing.Size(103, 20)
        Me.TextBox44.TabIndex = 94
        Me.TextBox44.Tag = "DEVICE_ID"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(391, 96)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(53, 13)
        Me.Label67.TabIndex = 97
        Me.Label67.Text = "Device Id"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(208, 96)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(38, 13)
        Me.Label64.TabIndex = 99
        Me.Label64.Text = "Priority"
        '
        'TextBox41
        '
        Me.TextBox41.AccessibleName = "BUILDING_LIST"
        Me.TextBox41.Location = New System.Drawing.Point(270, 92)
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.Size = New System.Drawing.Size(100, 20)
        Me.TextBox41.TabIndex = 96
        Me.TextBox41.Tag = "PRIORITY"
        '
        'TextBox40
        '
        Me.TextBox40.AccessibleName = "BUILDING"
        Me.TextBox40.Location = New System.Drawing.Point(85, 92)
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.Size = New System.Drawing.Size(103, 20)
        Me.TextBox40.TabIndex = 95
        Me.TextBox40.Tag = "REQUEST_ID"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(9, 95)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(59, 13)
        Me.Label62.TabIndex = 98
        Me.Label62.Text = "Request Id"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(579, 69)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(56, 13)
        Me.Label75.TabIndex = 93
        Me.Label75.Text = "Dest.  Loc"
        '
        'TextBox49
        '
        Me.TextBox49.AccessibleName = "DRIVER_NAME"
        Me.TextBox49.Location = New System.Drawing.Point(450, 66)
        Me.TextBox49.Name = "TextBox49"
        Me.TextBox49.Size = New System.Drawing.Size(103, 20)
        Me.TextBox49.TabIndex = 88
        Me.TextBox49.Tag = "DEST_SITE_NAME"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(391, 66)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(53, 13)
        Me.Label74.TabIndex = 92
        Me.Label74.Text = "Dest. Site"
        '
        'TextBox50
        '
        Me.TextBox50.AccessibleName = "LICENSE_PLATE_STATE"
        Me.TextBox50.Location = New System.Drawing.Point(670, 63)
        Me.TextBox50.Name = "TextBox50"
        Me.TextBox50.Size = New System.Drawing.Size(100, 20)
        Me.TextBox50.TabIndex = 89
        Me.TextBox50.Tag = "DEST_LOCATION"
        '
        'TextBox47
        '
        Me.TextBox47.AccessibleName = "DRIVER_NAME"
        Me.TextBox47.Location = New System.Drawing.Point(86, 66)
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Size = New System.Drawing.Size(102, 20)
        Me.TextBox47.TabIndex = 86
        Me.TextBox47.Tag = "SOURCE_SITE_NAME"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(9, 70)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(47, 13)
        Me.Label72.TabIndex = 91
        Me.Label72.Text = "Src. Site"
        '
        'TextBox48
        '
        Me.TextBox48.AccessibleName = "LICENSE_PLATE_STATE"
        Me.TextBox48.Location = New System.Drawing.Point(270, 66)
        Me.TextBox48.Name = "TextBox48"
        Me.TextBox48.Size = New System.Drawing.Size(100, 20)
        Me.TextBox48.TabIndex = 87
        Me.TextBox48.Tag = "SOURCE_LOCATION"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(206, 70)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(47, 13)
        Me.Label73.TabIndex = 90
        Me.Label73.Text = "Src Loc."
        '
        'btnTrlMovExecTrlMovCancel
        '
        Me.btnTrlMovExecTrlMovCancel.AccessibleName = "TrailerCheckin"
        Me.btnTrlMovExecTrlMovCancel.Location = New System.Drawing.Point(242, 149)
        Me.btnTrlMovExecTrlMovCancel.Name = "btnTrlMovExecTrlMovCancel"
        Me.btnTrlMovExecTrlMovCancel.Size = New System.Drawing.Size(117, 23)
        Me.btnTrlMovExecTrlMovCancel.TabIndex = 81
        Me.btnTrlMovExecTrlMovCancel.Tag = ""
        Me.btnTrlMovExecTrlMovCancel.Text = "Cancel Move"
        Me.btnTrlMovExecTrlMovCancel.UseVisualStyleBackColor = True
        '
        'TextBox59
        '
        Me.TextBox59.AccessibleName = "WCS_TRANSIT_NUM"
        Me.TextBox59.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox59.Location = New System.Drawing.Point(670, 89)
        Me.TextBox59.Name = "TextBox59"
        Me.TextBox59.Size = New System.Drawing.Size(100, 20)
        Me.TextBox59.TabIndex = 71
        Me.TextBox59.Tag = "TCS_TRAILER_TAG"
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Location = New System.Drawing.Point(579, 96)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(82, 13)
        Me.Label87.TabIndex = 72
        Me.Label87.Text = "TCS Trailer Tag"
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Location = New System.Drawing.Point(206, 47)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(51, 13)
        Me.Label89.TabIndex = 29
        Me.Label89.Text = "Location "
        '
        'TextBox61
        '
        Me.TextBox61.AccessibleName = "BUILDING"
        Me.TextBox61.Location = New System.Drawing.Point(450, 41)
        Me.TextBox61.Name = "TextBox61"
        Me.TextBox61.Size = New System.Drawing.Size(103, 20)
        Me.TextBox61.TabIndex = 25
        Me.TextBox61.Tag = "BUILDING"
        '
        'TextBox62
        '
        Me.TextBox62.AccessibleName = "SITE_NAME"
        Me.TextBox62.Location = New System.Drawing.Point(86, 40)
        Me.TextBox62.Name = "TextBox62"
        Me.TextBox62.Size = New System.Drawing.Size(103, 20)
        Me.TextBox62.TabIndex = 23
        Me.TextBox62.Tag = "SITE_NAME"
        '
        'TextBox63
        '
        Me.TextBox63.AccessibleName = "LOCATION"
        Me.TextBox63.Location = New System.Drawing.Point(270, 41)
        Me.TextBox63.Name = "TextBox63"
        Me.TextBox63.Size = New System.Drawing.Size(100, 20)
        Me.TextBox63.TabIndex = 24
        Me.TextBox63.Tag = "LOCATION"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(389, 41)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(44, 13)
        Me.Label90.TabIndex = 28
        Me.Label90.Text = "Building"
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Location = New System.Drawing.Point(8, 44)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(56, 13)
        Me.Label91.TabIndex = 30
        Me.Label91.Text = "Site Name"
        '
        'TextBox64
        '
        Me.TextBox64.AccessibleName = "BUILDING_LIST"
        Me.TextBox64.Location = New System.Drawing.Point(670, 37)
        Me.TextBox64.Name = "TextBox64"
        Me.TextBox64.Size = New System.Drawing.Size(100, 20)
        Me.TextBox64.TabIndex = 26
        Me.TextBox64.Tag = "BUILDING_LIST"
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Location = New System.Drawing.Point(577, 44)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(50, 13)
        Me.Label92.TabIndex = 27
        Me.Label92.Text = "Bldg. List"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Location = New System.Drawing.Point(206, 22)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(48, 13)
        Me.Label93.TabIndex = 21
        Me.Label93.Text = "Trailer Id"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Location = New System.Drawing.Point(8, 17)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(58, 13)
        Me.Label94.TabIndex = 22
        Me.Label94.Text = "Truck Line"
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
        Me.SplitContainer2.Size = New System.Drawing.Size(1752, 223)
        Me.SplitContainer2.SplitterDistance = 1573
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
        Me.txtLog.Size = New System.Drawing.Size(1494, 193)
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
        'btnLoadActivityData
        '
        Me.btnLoadActivityData.Location = New System.Drawing.Point(84, 398)
        Me.btnLoadActivityData.Name = "btnLoadActivityData"
        Me.btnLoadActivityData.Size = New System.Drawing.Size(81, 22)
        Me.btnLoadActivityData.TabIndex = 79
        Me.btnLoadActivityData.TabStop = False
        Me.btnLoadActivityData.Text = "Get Data"
        Me.btnLoadActivityData.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1779, 761)
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
        Me.tabPgTrlMovEmu.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        CType(Me.dgvTrlActivityData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTCSEmuData.ResumeLayout(False)
        Me.pnlTCSEmuData.PerformLayout()
        CType(Me.dGridTraMovData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage16.ResumeLayout(False)
        Me.TabPage16.PerformLayout()
        CType(Me.dGridTCSTrlViewData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTrailerMovMain.ResumeLayout(False)
        Me.gbTrailerMovMain.PerformLayout()
        Me.GroupBox30.ResumeLayout(False)
        Me.GroupBox30.PerformLayout()
        Me.GroupBox29.ResumeLayout(False)
        Me.GroupBox29.PerformLayout()
        Me.GroupBox27.ResumeLayout(False)
        Me.GroupBox27.PerformLayout()
        Me.TabPage17.ResumeLayout(False)
        Me.TabPage17.PerformLayout()
        CType(Me.dgvTrlMvmtTCSTrailerView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTcsTrailerReq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxTrailerMovement.ResumeLayout(False)
        Me.gbxTrailerMovement.PerformLayout()
        Me.TabPage18.ResumeLayout(False)
        Me.TabPage18.PerformLayout()
        CType(Me.dgvTcsLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTCSTrlReqbySessionViewData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxTrailerMoveExec.ResumeLayout(False)
        Me.gbxTrailerMoveExec.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ToolTip2 As ToolTip
    Friend WithEvents tabPgTrlMovEmu As TabPage
    Friend WithEvents dGridTraMovData As DataGridView
    Friend WithEvents gbTrailerMovMain As GroupBox
    Friend WithEvents btnTrlMovTCkout As Button
    Friend WithEvents GroupBox27 As GroupBox
    Friend WithEvents Label40 As Label
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents TextBox18 As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents TextBox19 As TextBox
    Friend WithEvents TextBox20 As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents TextBox21 As TextBox
    Friend WithEvents TextBox22 As TextBox
    Friend WithEvents TextBox23 As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents TextBox24 As TextBox
    Friend WithEvents TextBox25 As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents TextBox26 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox27 As TextBox
    Friend WithEvents GroupBox29 As GroupBox
    Friend WithEvents TextBox28 As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents TextBox29 As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents TextBox30 As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents TextBox31 As TextBox
    Friend WithEvents GroupBox30 As GroupBox
    Friend WithEvents TextBox32 As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents TextBox33 As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents TextBox34 As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents TextBox35 As TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents btnTrlMovAsgnShpRcp As Button
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents TextBox36 As TextBox
    Friend WithEvents Label54 As Label
    Friend WithEvents TextBox37 As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents TextBox38 As TextBox
    Friend WithEvents Label56 As Label
    Friend WithEvents TextBox39 As TextBox
    Friend WithEvents Label57 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents btnTrlMovTCkin As Button
    Friend WithEvents btnGetTrlMovData As Button
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents btnTrlMovTLocAsgn As Button
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label60 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents btnTrlMovReset As Button
    Friend WithEvents TextBox45 As TextBox
    Friend WithEvents Label68 As Label
    Friend WithEvents TextBox46 As TextBox
    Friend WithEvents Label70 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label69 As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents dGridTCSTrlViewData As DataGridView
    Friend WithEvents lblWMSTCSTrlData As Label
    Friend WithEvents lblTrlEMUData As Label
    Friend WithEvents DeleteTCSTRAILERToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage16 As TabPage
    Friend WithEvents TabPage17 As TabPage
    Friend WithEvents TabPage18 As TabPage
    Friend WithEvents gbxTrailerMovement As GroupBox
    Friend WithEvents btnTrlMovTrlMovCancel As Button
    Friend WithEvents btnTrlMovTrlLocReq As Button
    Friend WithEvents TextBox57 As TextBox
    Friend WithEvents Label85 As Label
    Friend WithEvents TextBox56 As TextBox
    Friend WithEvents Label84 As Label
    Friend WithEvents Label83 As Label
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents TextBox55 As TextBox
    Friend WithEvents Label79 As Label
    Friend WithEvents TextBox51 As TextBox
    Friend WithEvents TextBox52 As TextBox
    Friend WithEvents TextBox53 As TextBox
    Friend WithEvents Label80 As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents TextBox54 As TextBox
    Friend WithEvents Label82 As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents dgvTcsTrailerReq As DataGridView
    Friend WithEvents btnLoadTrailerMovData As Button
    Friend WithEvents btnLoadTrlExecTrlReqData As Button
    Friend WithEvents dgTCSTrlReqbySessionViewData As DataGridView
    Friend WithEvents gbxTrailerMoveExec As GroupBox
    Friend WithEvents TextBox44 As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents TextBox41 As TextBox
    Friend WithEvents TextBox40 As TextBox
    Friend WithEvents Label62 As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents TextBox49 As TextBox
    Friend WithEvents Label74 As Label
    Friend WithEvents TextBox50 As TextBox
    Friend WithEvents TextBox47 As TextBox
    Friend WithEvents Label72 As Label
    Friend WithEvents TextBox48 As TextBox
    Friend WithEvents Label73 As Label
    Friend WithEvents btnTrlMovTrlMovPickup As Button
    Friend WithEvents btnTrlMovTrlMovComp As Button
    Friend WithEvents btnTrlMovExecTrlMovCancel As Button
    Friend WithEvents TextBox59 As TextBox
    Friend WithEvents Label87 As Label
    Friend WithEvents Label89 As Label
    Friend WithEvents TextBox61 As TextBox
    Friend WithEvents TextBox62 As TextBox
    Friend WithEvents TextBox63 As TextBox
    Friend WithEvents Label90 As Label
    Friend WithEvents Label91 As Label
    Friend WithEvents TextBox64 As TextBox
    Friend WithEvents Label92 As Label
    Friend WithEvents Label93 As Label
    Friend WithEvents Label94 As Label
    Friend WithEvents btnTrlMovTrlLocUpd As Button
    Friend WithEvents chkBxTcsEmuWMSEmpty As CheckBox
    Friend WithEvents chkBxTcsEmuWMSReadyToShip As CheckBox
    Friend WithEvents chkBxTcsEmuWMSSessOnly As CheckBox
    Friend WithEvents chkBxTcsEmuEMUSessionOnly As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents Label66 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label86 As Label
    Friend WithEvents chkBxTcsEmuTrlMovWMSSessOnly As CheckBox
    Friend WithEvents TextBox43 As TextBox
    Friend WithEvents TextBox42 As TextBox
    Friend WithEvents Label95 As Label
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents Label96 As Label
    Friend WithEvents TextBox58 As TextBox
    Friend WithEvents Label97 As Label
    Friend WithEvents TextBox60 As TextBox
    Friend WithEvents btnTrlMovTrlChgPriority As Button
    Friend WithEvents Label98 As Label
    Friend WithEvents chkbTCSTrlExecCurSessOnly As CheckBox
    Friend WithEvents TextBox65 As TextBox
    Friend WithEvents TextBox66 As TextBox
    Friend WithEvents btnTrlMovExecTrlChgPriority As Button
    Friend WithEvents btnTrlMovementReset As Button
    Friend WithEvents btnTrlMovExecReset As Button
    Friend WithEvents pnlTCSEmuData As Panel
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label88 As Label
    Friend WithEvents dgvTcsLocation As DataGridView
    Friend WithEvents dgvTrlMvmtTCSTrailerView As DataGridView
    Friend WithEvents Label33 As Label
    Friend WithEvents chkbTrlMvmtThisSessionOnly As CheckBox
    Friend WithEvents chkbTrlMvmtShowEmpty As CheckBox
    Friend WithEvents chkbTrlMvmtReadyToShip As CheckBox
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents dgvTrlActivityData As DataGridView
    Friend WithEvents Label34 As Label
    Friend WithEvents btnTCSEmuViewData As Button
    Friend WithEvents TCSConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnLoadActivityData As Button
End Class
