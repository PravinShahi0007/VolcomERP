﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSalesWeekly
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.GVSalesPOSDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignPriceRetail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesignPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesPOSDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesignPriceRetail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCSalesPOS = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesPOS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnStore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesPOSDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMemoType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesStore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDiscount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesTax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNetto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesPosRev = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAge = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_discount_value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_potongan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_tax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolTipControllerNew = New DevExpress.Utils.ToolTipController(Me.components)
        Me.XTCPOS = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDailySales = New DevExpress.XtraTab.XtraTabPage()
        Me.GCView = New DevExpress.XtraEditors.GroupControl()
        Me.XTCDailySales = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSummary = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.CEAllUnit = New DevExpress.XtraEditors.CheckEdit()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExportToXLSDaily = New DevExpress.XtraEditors.SimpleButton()
        Me.CEPromo = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnStoreLabel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.LEOptionView = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPWeeklySales = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSalesWeeklyByDate = New DevExpress.XtraGrid.GridControl()
        Me.BGVSalesWeeklyByDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.BtnExportToXLSDateWeekly = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.DEEndWeek = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromWeek = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtWeek = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtYear = New DevExpress.XtraEditors.TextEdit()
        Me.CEPromoWeeklyByDate = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnViewDateWeekly = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckEdit3 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit4 = New DevExpress.XtraEditors.CheckEdit()
        Me.XTPMonthlySales = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCMonthlySales = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPMonthlyByWeek = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControlWeeklySales = New DevExpress.XtraEditors.GroupControl()
        Me.GCSalesPOSWeekly = New DevExpress.XtraGrid.GridControl()
        Me.BGVSalesPOSWeekly = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.BtnExportToXLSWeekly = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEEndWeekly = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFromWeekly = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LEDayWeekly = New DevExpress.XtraEditors.LookUpEdit()
        Me.CEPromoWeekly = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckShowRevBefTaxWS = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckShowRetailWS = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnViewWeeklySales = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPMonthlyByMonth = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.CheckShowRevBefTax = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckShowRetail = New DevExpress.XtraEditors.CheckEdit()
        Me.LEUntilYear = New DevExpress.XtraEditors.LookUpEdit()
        Me.LEUntilMonth = New DevExpress.XtraEditors.LookUpEdit()
        Me.LEFromYear = New DevExpress.XtraEditors.LookUpEdit()
        Me.LEFromMonth = New DevExpress.XtraEditors.LookUpEdit()
        Me.BtnViewMonthlySales = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControlMonthlySales = New DevExpress.XtraEditors.GroupControl()
        Me.GCSalesPOSMonthly = New DevExpress.XtraGrid.GridControl()
        Me.BGVSalesPOSMonthly = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.XTPInvoice = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInvoiceWeek = New DevExpress.XtraGrid.GridControl()
        Me.GVInvoiceWeek = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.RepositoryItemHyperLinkEdit = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.DEInvoiceTo = New DevExpress.XtraEditors.DateEdit()
        Me.SBInvoiceExportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.SBInvoiceTo = New DevExpress.XtraEditors.SimpleButton()
        Me.DEInvoiceFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPUSASales = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.GCDetailRoyalty = New DevExpress.XtraGrid.GridControl()
        Me.GVDetailRoyalty = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDetailSales = New DevExpress.XtraGrid.GridControl()
        Me.GVDetailSales = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCUSASales = New DevExpress.XtraGrid.GridControl()
        Me.GVUSASales = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl11 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.SLUEUSASales = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GVSalesPOSDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSalesPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPOS.SuspendLayout()
        Me.XTPDailySales.SuspendLayout()
        CType(Me.GCView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCView.SuspendLayout()
        CType(Me.XTCDailySales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCDailySales.SuspendLayout()
        Me.XTPSummary.SuspendLayout()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.CEAllUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.CEPromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEOptionView.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPWeeklySales.SuspendLayout()
        CType(Me.GCSalesWeeklyByDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVSalesWeeklyByDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEEndWeek.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEndWeek.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromWeek.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromWeek.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtWeek.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEPromoWeeklyByDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMonthlySales.SuspendLayout()
        CType(Me.XTCMonthlySales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCMonthlySales.SuspendLayout()
        Me.XTPMonthlyByWeek.SuspendLayout()
        CType(Me.GroupControlWeeklySales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlWeeklySales.SuspendLayout()
        CType(Me.GCSalesPOSWeekly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVSalesPOSWeekly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEEndWeekly.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEndWeekly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromWeekly.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromWeekly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDayWeekly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEPromoWeekly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckShowRevBefTaxWS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckShowRetailWS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMonthlyByMonth.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.CheckShowRevBefTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckShowRetail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEUntilYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEUntilMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEFromYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEFromMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlMonthlySales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlMonthlySales.SuspendLayout()
        CType(Me.GCSalesPOSMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVSalesPOSMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPInvoice.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.GCInvoiceWeek, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoiceWeek, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.DEInvoiceTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEInvoiceTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEInvoiceFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEInvoiceFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPUSASales.SuspendLayout()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.GCDetailRoyalty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetailRoyalty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDetailSales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetailSales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCUSASales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUSASales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl11.SuspendLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.SLUEUSASales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GVSalesPOSDet
        '
        Me.GVSalesPOSDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumn2, Me.GridColumnAmount, Me.GridColumnDesignPriceRetail, Me.GridColumnDesignPriceType, Me.GridColumnPrice, Me.GridColumn3, Me.GridColumnIdDesign, Me.GridColumnIdProduct, Me.GridColumnIdSample, Me.GridColumnIdDesignPrice, Me.GridColumnIdSalesPOSDet, Me.GridColumnColor, Me.GridColumnIdDesignPriceRetail})
        Me.GVSalesPOSDet.GridControl = Me.GCSalesPOS
        Me.GVSalesPOSDet.Name = "GVSalesPOSDet"
        Me.GVSalesPOSDet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSalesPOSDet.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSalesPOSDet.OptionsBehavior.ReadOnly = True
        Me.GVSalesPOSDet.OptionsCustomization.AllowGroup = False
        Me.GVSalesPOSDet.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVSalesPOSDet.OptionsView.ShowFooter = True
        Me.GVSalesPOSDet.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 43
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 72
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_design"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 142
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 4
        Me.GridColumnSize.Width = 56
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Width = 71
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Qty"
        Me.GridColumn2.DisplayFormat.FormatString = "F2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "sales_pos_det_qty"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_det_qty", "{0:f2}")})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 7
        Me.GridColumn2.Width = 121
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "sales_pos_det_amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_det_amount", "{0:n2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 8
        Me.GridColumnAmount.Width = 106
        '
        'GridColumnDesignPriceRetail
        '
        Me.GridColumnDesignPriceRetail.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDesignPriceRetail.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDesignPriceRetail.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDesignPriceRetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDesignPriceRetail.Caption = "Price"
        Me.GridColumnDesignPriceRetail.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnDesignPriceRetail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDesignPriceRetail.FieldName = "design_price_retail"
        Me.GridColumnDesignPriceRetail.Name = "GridColumnDesignPriceRetail"
        Me.GridColumnDesignPriceRetail.Visible = True
        Me.GridColumnDesignPriceRetail.VisibleIndex = 6
        '
        'GridColumnDesignPriceType
        '
        Me.GridColumnDesignPriceType.Caption = "Price Type"
        Me.GridColumnDesignPriceType.FieldName = "design_price_type"
        Me.GridColumnDesignPriceType.Name = "GridColumnDesignPriceType"
        Me.GridColumnDesignPriceType.Visible = True
        Me.GridColumnDesignPriceType.VisibleIndex = 5
        Me.GridColumnDesignPriceType.Width = 71
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Price Del"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Width = 117
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Remark"
        Me.GridColumn3.FieldName = "sales_pos_det_note"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Width = 255
        '
        'GridColumnIdDesign
        '
        Me.GridColumnIdDesign.Caption = "id design"
        Me.GridColumnIdDesign.FieldName = "id_design"
        Me.GridColumnIdDesign.Name = "GridColumnIdDesign"
        Me.GridColumnIdDesign.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        Me.GridColumnIdProduct.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdProduct.Width = 92
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdDesignPrice
        '
        Me.GridColumnIdDesignPrice.Caption = "Id Design Price Del"
        Me.GridColumnIdDesignPrice.FieldName = "id_design_price"
        Me.GridColumnIdDesignPrice.Name = "GridColumnIdDesignPrice"
        Me.GridColumnIdDesignPrice.Width = 84
        '
        'GridColumnIdSalesPOSDet
        '
        Me.GridColumnIdSalesPOSDet.Caption = "Id Sales POS Det"
        Me.GridColumnIdSalesPOSDet.Name = "GridColumnIdSalesPOSDet"
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        Me.GridColumnColor.Width = 71
        '
        'GridColumnIdDesignPriceRetail
        '
        Me.GridColumnIdDesignPriceRetail.Caption = "Id Design Price"
        Me.GridColumnIdDesignPriceRetail.FieldName = "id_design_price_retail"
        Me.GridColumnIdDesignPriceRetail.Name = "GridColumnIdDesignPriceRetail"
        '
        'GCSalesPOS
        '
        Me.GCSalesPOS.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.GVSalesPOSDet
        GridLevelNode1.RelationName = "Detail Transaction"
        Me.GCSalesPOS.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GCSalesPOS.Location = New System.Drawing.Point(0, 0)
        Me.GCSalesPOS.MainView = Me.GVSalesPOS
        Me.GCSalesPOS.Name = "GCSalesPOS"
        Me.GCSalesPOS.Size = New System.Drawing.Size(1081, 344)
        Me.GCSalesPOS.TabIndex = 0
        Me.GCSalesPOS.ToolTipController = Me.ToolTipControllerNew
        Me.GCSalesPOS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesPOS, Me.GVSalesPOSDet})
        '
        'GVSalesPOS
        '
        Me.GVSalesPOS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnStore, Me.GridColumnSalesPOSDate, Me.GridColumnMemoType, Me.GridColumn1, Me.GridColumnSalesStore, Me.GridColumnType, Me.GridColumnQty, Me.GridColumnTotal, Me.GridColumnDiscount, Me.GridColumnSalesTax, Me.GridColumnNetto, Me.GridColumnSalesPosRev, Me.GridColumnStatus, Me.GridColumnDueDate, Me.GridColumnAge, Me.GridColumnRemark, Me.GridColumnstore_number, Me.GridColumnstore_name, Me.GridColumnsales_pos_discount_value, Me.GridColumnsales_pos_potongan, Me.GridColumnstore_group, Me.GridColumnsales_pos_tax})
        Me.GVSalesPOS.GridControl = Me.GCSalesPOS
        Me.GVSalesPOS.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_det_qty", Me.GridColumnQty, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total_retail", Me.GridColumnTotal, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_netto", Me.GridColumnNetto, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_revenue", Me.GridColumnSalesPosRev, "{0:n2}")})
        Me.GVSalesPOS.Name = "GVSalesPOS"
        Me.GVSalesPOS.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSalesPOS.OptionsBehavior.ReadOnly = True
        Me.GVSalesPOS.OptionsPrint.PrintDetails = True
        Me.GVSalesPOS.OptionsView.ColumnAutoWidth = False
        Me.GVSalesPOS.OptionsView.ShowFooter = True
        Me.GVSalesPOS.OptionsView.ShowGroupPanel = False
        '
        'GridColumnStore
        '
        Me.GridColumnStore.Caption = "NUMBER"
        Me.GridColumnStore.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnStore.FieldName = "sales_pos_number"
        Me.GridColumnStore.Name = "GridColumnStore"
        Me.GridColumnStore.Visible = True
        Me.GridColumnStore.VisibleIndex = 0
        Me.GridColumnStore.Width = 68
        '
        'GridColumnSalesPOSDate
        '
        Me.GridColumnSalesPOSDate.Caption = "CREATED DATE"
        Me.GridColumnSalesPOSDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnSalesPOSDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnSalesPOSDate.FieldName = "sales_pos_date"
        Me.GridColumnSalesPOSDate.Name = "GridColumnSalesPOSDate"
        Me.GridColumnSalesPOSDate.Visible = True
        Me.GridColumnSalesPOSDate.VisibleIndex = 4
        Me.GridColumnSalesPOSDate.Width = 84
        '
        'GridColumnMemoType
        '
        Me.GridColumnMemoType.Caption = "INV. TYPE"
        Me.GridColumnMemoType.FieldName = "memo_type"
        Me.GridColumnMemoType.FieldNameSortGroup = "id_memo_type"
        Me.GridColumnMemoType.Name = "GridColumnMemoType"
        Me.GridColumnMemoType.Visible = True
        Me.GridColumnMemoType.VisibleIndex = 7
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PERIOD"
        Me.GridColumn1.FieldName = "sales_pos_period"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 5
        Me.GridColumn1.Width = 68
        '
        'GridColumnSalesStore
        '
        Me.GridColumnSalesStore.Caption = "STORE"
        Me.GridColumnSalesStore.FieldName = "store_name_from"
        Me.GridColumnSalesStore.Name = "GridColumnSalesStore"
        Me.GridColumnSalesStore.Width = 68
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "TYPE"
        Me.GridColumnType.FieldName = "so_type"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.Width = 68
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "QTY"
        Me.GridColumnQty.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sales_pos_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_det_qty", "{0:n0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 8
        Me.GridColumnQty.Width = 68
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "RETAIL"
        Me.GridColumnTotal.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "sales_pos_total_retail"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total_retail", "{0:n2}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 9
        Me.GridColumnTotal.Width = 68
        '
        'GridColumnDiscount
        '
        Me.GridColumnDiscount.Caption = "DISC (%)"
        Me.GridColumnDiscount.FieldName = "sales_pos_discount"
        Me.GridColumnDiscount.Name = "GridColumnDiscount"
        Me.GridColumnDiscount.Visible = True
        Me.GridColumnDiscount.VisibleIndex = 10
        Me.GridColumnDiscount.Width = 97
        '
        'GridColumnSalesTax
        '
        Me.GridColumnSalesTax.Caption = "TAX(%)"
        Me.GridColumnSalesTax.FieldName = "sales_pos_vat"
        Me.GridColumnSalesTax.Name = "GridColumnSalesTax"
        '
        'GridColumnNetto
        '
        Me.GridColumnNetto.Caption = "REV BEFORE TAX"
        Me.GridColumnNetto.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnNetto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnNetto.FieldName = "sales_pos_netto"
        Me.GridColumnNetto.Name = "GridColumnNetto"
        Me.GridColumnNetto.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_netto", "{0:n2}")})
        Me.GridColumnNetto.Visible = True
        Me.GridColumnNetto.VisibleIndex = 13
        Me.GridColumnNetto.Width = 65
        '
        'GridColumnSalesPosRev
        '
        Me.GridColumnSalesPosRev.Caption = "REV AFTER TAX"
        Me.GridColumnSalesPosRev.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnSalesPosRev.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSalesPosRev.FieldName = "sales_pos_revenue"
        Me.GridColumnSalesPosRev.Name = "GridColumnSalesPosRev"
        Me.GridColumnSalesPosRev.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_revenue", "{0:n2}")})
        Me.GridColumnSalesPosRev.Visible = True
        Me.GridColumnSalesPosRev.VisibleIndex = 15
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "STATUS"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        '
        'GridColumnDueDate
        '
        Me.GridColumnDueDate.Caption = "DUE DATE"
        Me.GridColumnDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDueDate.FieldName = "sales_pos_due_date"
        Me.GridColumnDueDate.Name = "GridColumnDueDate"
        Me.GridColumnDueDate.Visible = True
        Me.GridColumnDueDate.VisibleIndex = 6
        Me.GridColumnDueDate.Width = 65
        '
        'GridColumnAge
        '
        Me.GridColumnAge.Caption = "AGE (DAY)"
        Me.GridColumnAge.FieldName = "sales_pos_age"
        Me.GridColumnAge.Name = "GridColumnAge"
        Me.GridColumnAge.Width = 65
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "REMARK"
        Me.GridColumnRemark.FieldName = "sales_pos_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 16
        '
        'GridColumnstore_number
        '
        Me.GridColumnstore_number.Caption = "STORE ACC"
        Me.GridColumnstore_number.FieldName = "store_number"
        Me.GridColumnstore_number.Name = "GridColumnstore_number"
        Me.GridColumnstore_number.Visible = True
        Me.GridColumnstore_number.VisibleIndex = 1
        '
        'GridColumnstore_name
        '
        Me.GridColumnstore_name.Caption = "STORE"
        Me.GridColumnstore_name.FieldName = "store_name"
        Me.GridColumnstore_name.Name = "GridColumnstore_name"
        Me.GridColumnstore_name.Visible = True
        Me.GridColumnstore_name.VisibleIndex = 2
        '
        'GridColumnsales_pos_discount_value
        '
        Me.GridColumnsales_pos_discount_value.Caption = "DISC"
        Me.GridColumnsales_pos_discount_value.DisplayFormat.FormatString = "N2"
        Me.GridColumnsales_pos_discount_value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_discount_value.FieldName = "sales_pos_discount_value"
        Me.GridColumnsales_pos_discount_value.Name = "GridColumnsales_pos_discount_value"
        Me.GridColumnsales_pos_discount_value.Visible = True
        Me.GridColumnsales_pos_discount_value.VisibleIndex = 11
        '
        'GridColumnsales_pos_potongan
        '
        Me.GridColumnsales_pos_potongan.Caption = "POT. PENJUALAN"
        Me.GridColumnsales_pos_potongan.DisplayFormat.FormatString = "N2"
        Me.GridColumnsales_pos_potongan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_potongan.FieldName = "sales_pos_potongan_value"
        Me.GridColumnsales_pos_potongan.Name = "GridColumnsales_pos_potongan"
        Me.GridColumnsales_pos_potongan.Visible = True
        Me.GridColumnsales_pos_potongan.VisibleIndex = 12
        '
        'GridColumnstore_group
        '
        Me.GridColumnstore_group.Caption = "STORE GROUP"
        Me.GridColumnstore_group.FieldName = "comp_group"
        Me.GridColumnstore_group.Name = "GridColumnstore_group"
        Me.GridColumnstore_group.Visible = True
        Me.GridColumnstore_group.VisibleIndex = 3
        '
        'GridColumnsales_pos_tax
        '
        Me.GridColumnsales_pos_tax.Caption = "TAX"
        Me.GridColumnsales_pos_tax.DisplayFormat.FormatString = "N2"
        Me.GridColumnsales_pos_tax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_tax.FieldName = "sales_pos_tax"
        Me.GridColumnsales_pos_tax.Name = "GridColumnsales_pos_tax"
        Me.GridColumnsales_pos_tax.Visible = True
        Me.GridColumnsales_pos_tax.VisibleIndex = 14
        '
        'ToolTipControllerNew
        '
        '
        'XTCPOS
        '
        Me.XTCPOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPOS.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPOS.Location = New System.Drawing.Point(0, 0)
        Me.XTCPOS.Name = "XTCPOS"
        Me.XTCPOS.SelectedTabPage = Me.XTPDailySales
        Me.XTCPOS.Size = New System.Drawing.Size(1138, 514)
        Me.XTCPOS.TabIndex = 4
        Me.XTCPOS.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDailySales, Me.XTPWeeklySales, Me.XTPMonthlySales, Me.XTPInvoice, Me.XTPUSASales})
        '
        'XTPDailySales
        '
        Me.XTPDailySales.Controls.Add(Me.GCView)
        Me.XTPDailySales.Controls.Add(Me.GCFilter)
        Me.XTPDailySales.Name = "XTPDailySales"
        Me.XTPDailySales.Size = New System.Drawing.Size(1132, 486)
        Me.XTPDailySales.Text = "Daily Sales"
        '
        'GCView
        '
        Me.GCView.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCView.Controls.Add(Me.XTCDailySales)
        Me.GCView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCView.Location = New System.Drawing.Point(0, 132)
        Me.GCView.Name = "GCView"
        Me.GCView.Size = New System.Drawing.Size(1132, 354)
        Me.GCView.TabIndex = 3
        '
        'XTCDailySales
        '
        Me.XTCDailySales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCDailySales.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCDailySales.Location = New System.Drawing.Point(20, 2)
        Me.XTCDailySales.Name = "XTCDailySales"
        Me.XTCDailySales.SelectedTabPage = Me.XTPSummary
        Me.XTCDailySales.Size = New System.Drawing.Size(1110, 350)
        Me.XTCDailySales.TabIndex = 1
        Me.XTCDailySales.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSummary, Me.XTPDetail})
        '
        'XTPSummary
        '
        Me.XTPSummary.Controls.Add(Me.GCSalesPOS)
        Me.XTPSummary.Name = "XTPSummary"
        Me.XTPSummary.Size = New System.Drawing.Size(1081, 344)
        Me.XTPSummary.Text = "Summary"
        '
        'XTPDetail
        '
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.PageVisible = False
        Me.XTPDetail.Size = New System.Drawing.Size(1081, 344)
        Me.XTPDetail.Text = "Detail"
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.PanelControl3)
        Me.GCFilter.Controls.Add(Me.LEOptionView)
        Me.GCFilter.Controls.Add(Me.LabelControl4)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(1132, 132)
        Me.GCFilter.TabIndex = 2
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.CEAllUnit)
        Me.PanelControl3.Controls.Add(Me.PanelControl4)
        Me.PanelControl3.Controls.Add(Me.CEPromo)
        Me.PanelControl3.Controls.Add(Me.LabelControl8)
        Me.PanelControl3.Controls.Add(Me.SLEStore)
        Me.PanelControl3.Controls.Add(Me.SLEStoreGroup)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Controls.Add(Me.LabelControl2)
        Me.PanelControl3.Controls.Add(Me.DEFrom)
        Me.PanelControl3.Controls.Add(Me.DEUntil)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl3.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(464, 128)
        Me.PanelControl3.TabIndex = 8930
        '
        'CEAllUnit
        '
        Me.CEAllUnit.Location = New System.Drawing.Point(235, 64)
        Me.CEAllUnit.Name = "CEAllUnit"
        Me.CEAllUnit.Properties.Caption = "Include Branch Sales"
        Me.CEAllUnit.Size = New System.Drawing.Size(121, 19)
        Me.CEAllUnit.TabIndex = 8930
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.BtnView)
        Me.PanelControl4.Controls.Add(Me.BtnExportToXLSDaily)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(2, 90)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(460, 36)
        Me.PanelControl4.TabIndex = 0
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(370, 9)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'BtnExportToXLSDaily
        '
        Me.BtnExportToXLSDaily.Location = New System.Drawing.Point(272, 9)
        Me.BtnExportToXLSDaily.LookAndFeel.SkinName = "Blue"
        Me.BtnExportToXLSDaily.Name = "BtnExportToXLSDaily"
        Me.BtnExportToXLSDaily.Size = New System.Drawing.Size(92, 20)
        Me.BtnExportToXLSDaily.TabIndex = 8927
        Me.BtnExportToXLSDaily.Text = "Export to XLS"
        '
        'CEPromo
        '
        Me.CEPromo.Location = New System.Drawing.Point(358, 64)
        Me.CEPromo.Name = "CEPromo"
        Me.CEPromo.Properties.Caption = "Include Promo"
        Me.CEPromo.Size = New System.Drawing.Size(89, 19)
        Me.CEPromo.TabIndex = 8926
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(15, 15)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl8.TabIndex = 8928
        Me.LabelControl8.Text = "Store Group"
        '
        'SLEStore
        '
        Me.SLEStore.Location = New System.Drawing.Point(261, 12)
        Me.SLEStore.Name = "SLEStore"
        Me.SLEStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStore.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEStore.Size = New System.Drawing.Size(186, 20)
        Me.SLEStore.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnStoreLabel})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnStoreLabel
        '
        Me.GridColumnStoreLabel.Caption = "Store"
        Me.GridColumnStoreLabel.FieldName = "comp_name_label"
        Me.GridColumnStoreLabel.Name = "GridColumnStoreLabel"
        Me.GridColumnStoreLabel.Visible = True
        Me.GridColumnStoreLabel.VisibleIndex = 0
        '
        'SLEStoreGroup
        '
        Me.SLEStoreGroup.Location = New System.Drawing.Point(79, 12)
        Me.SLEStoreGroup.Name = "SLEStoreGroup"
        Me.SLEStoreGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroup.Properties.View = Me.GridView3
        Me.SLEStoreGroup.Size = New System.Drawing.Size(145, 20)
        Me.SLEStoreGroup.TabIndex = 8929
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumncomp_group, Me.GridColumndescription})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(229, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Store"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(15, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(229, 41)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(79, 38)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Size = New System.Drawing.Size(144, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(261, 38)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(186, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'LEOptionView
        '
        Me.LEOptionView.Location = New System.Drawing.Point(105, 199)
        Me.LEOptionView.Name = "LEOptionView"
        Me.LEOptionView.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEOptionView.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_option_view", "Id Option View", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("option_view", "Option View")})
        Me.LEOptionView.Size = New System.Drawing.Size(123, 20)
        Me.LEOptionView.TabIndex = 8900
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(42, 202)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl4.TabIndex = 8899
        Me.LabelControl4.Text = "Option View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(341, 199)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(238, 199)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'XTPWeeklySales
        '
        Me.XTPWeeklySales.Controls.Add(Me.GCSalesWeeklyByDate)
        Me.XTPWeeklySales.Controls.Add(Me.GroupControl3)
        Me.XTPWeeklySales.Name = "XTPWeeklySales"
        Me.XTPWeeklySales.Size = New System.Drawing.Size(1132, 486)
        Me.XTPWeeklySales.Text = "Weekly Sales"
        '
        'GCSalesWeeklyByDate
        '
        Me.GCSalesWeeklyByDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesWeeklyByDate.Location = New System.Drawing.Point(0, 46)
        Me.GCSalesWeeklyByDate.MainView = Me.BGVSalesWeeklyByDate
        Me.GCSalesWeeklyByDate.Name = "GCSalesWeeklyByDate"
        Me.GCSalesWeeklyByDate.Size = New System.Drawing.Size(1132, 440)
        Me.GCSalesWeeklyByDate.TabIndex = 4
        Me.GCSalesWeeklyByDate.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVSalesWeeklyByDate})
        '
        'BGVSalesWeeklyByDate
        '
        Me.BGVSalesWeeklyByDate.GridControl = Me.GCSalesWeeklyByDate
        Me.BGVSalesWeeklyByDate.Name = "BGVSalesWeeklyByDate"
        Me.BGVSalesWeeklyByDate.OptionsBehavior.AutoExpandAllGroups = True
        Me.BGVSalesWeeklyByDate.OptionsBehavior.ReadOnly = True
        Me.BGVSalesWeeklyByDate.OptionsView.ColumnAutoWidth = False
        Me.BGVSalesWeeklyByDate.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BGVSalesWeeklyByDate.OptionsView.ShowFooter = True
        Me.BGVSalesWeeklyByDate.OptionsView.ShowGroupPanel = False
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.BtnExportToXLSDateWeekly)
        Me.GroupControl3.Controls.Add(Me.PanelControl2)
        Me.GroupControl3.Controls.Add(Me.BtnViewDateWeekly)
        Me.GroupControl3.Controls.Add(Me.CheckEdit3)
        Me.GroupControl3.Controls.Add(Me.CheckEdit4)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl3.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(1132, 46)
        Me.GroupControl3.TabIndex = 3
        '
        'BtnExportToXLSDateWeekly
        '
        Me.BtnExportToXLSDateWeekly.Location = New System.Drawing.Point(743, 13)
        Me.BtnExportToXLSDateWeekly.LookAndFeel.SkinName = "Blue"
        Me.BtnExportToXLSDateWeekly.Name = "BtnExportToXLSDateWeekly"
        Me.BtnExportToXLSDateWeekly.Size = New System.Drawing.Size(92, 20)
        Me.BtnExportToXLSDateWeekly.TabIndex = 8934
        Me.BtnExportToXLSDateWeekly.Text = "Export to XLS"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.DEEndWeek)
        Me.PanelControl2.Controls.Add(Me.DEFromWeek)
        Me.PanelControl2.Controls.Add(Me.LabelControl11)
        Me.PanelControl2.Controls.Add(Me.LabelControl15)
        Me.PanelControl2.Controls.Add(Me.TxtWeek)
        Me.PanelControl2.Controls.Add(Me.LabelControl10)
        Me.PanelControl2.Controls.Add(Me.LabelControl14)
        Me.PanelControl2.Controls.Add(Me.TxtYear)
        Me.PanelControl2.Controls.Add(Me.CEPromoWeeklyByDate)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(636, 42)
        Me.PanelControl2.TabIndex = 8933
        '
        'DEEndWeek
        '
        Me.DEEndWeek.EditValue = Nothing
        Me.DEEndWeek.Enabled = False
        Me.DEEndWeek.Location = New System.Drawing.Point(386, 11)
        Me.DEEndWeek.Name = "DEEndWeek"
        Me.DEEndWeek.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEEndWeek.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEndWeek.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEndWeek.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEEndWeek.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEndWeek.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEEndWeek.Size = New System.Drawing.Size(140, 20)
        Me.DEEndWeek.TabIndex = 8933
        '
        'DEFromWeek
        '
        Me.DEFromWeek.EditValue = Nothing
        Me.DEFromWeek.Enabled = False
        Me.DEFromWeek.Location = New System.Drawing.Point(213, 11)
        Me.DEFromWeek.Name = "DEFromWeek"
        Me.DEFromWeek.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromWeek.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromWeek.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromWeek.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFromWeek.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromWeek.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEFromWeek.Size = New System.Drawing.Size(140, 20)
        Me.DEFromWeek.TabIndex = 4
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(96, 14)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl11.TabIndex = 8931
        Me.LabelControl11.Text = "Week"
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(16, 14)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl15.TabIndex = 8930
        Me.LabelControl15.Text = "Year"
        '
        'TxtWeek
        '
        Me.TxtWeek.EditValue = "1"
        Me.TxtWeek.Location = New System.Drawing.Point(129, 11)
        Me.TxtWeek.Name = "TxtWeek"
        Me.TxtWeek.Properties.Mask.EditMask = "F0"
        Me.TxtWeek.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtWeek.Size = New System.Drawing.Size(48, 20)
        Me.TxtWeek.TabIndex = 8932
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(183, 14)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl10.TabIndex = 8892
        Me.LabelControl10.Text = "From"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(359, 14)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl14.TabIndex = 8893
        Me.LabelControl14.Text = "Until"
        '
        'TxtYear
        '
        Me.TxtYear.EditValue = "2020"
        Me.TxtYear.Location = New System.Drawing.Point(46, 11)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Properties.DisplayFormat.FormatString = "yyyy"
        Me.TxtYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtYear.Properties.Mask.EditMask = "yyyy"
        Me.TxtYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        Me.TxtYear.Size = New System.Drawing.Size(44, 20)
        Me.TxtYear.TabIndex = 8929
        '
        'CEPromoWeeklyByDate
        '
        Me.CEPromoWeeklyByDate.Location = New System.Drawing.Point(532, 11)
        Me.CEPromoWeeklyByDate.Name = "CEPromoWeeklyByDate"
        Me.CEPromoWeeklyByDate.Properties.Caption = "Include Promo"
        Me.CEPromoWeeklyByDate.Size = New System.Drawing.Size(89, 19)
        Me.CEPromoWeeklyByDate.TabIndex = 8927
        '
        'BtnViewDateWeekly
        '
        Me.BtnViewDateWeekly.Location = New System.Drawing.Point(663, 13)
        Me.BtnViewDateWeekly.LookAndFeel.SkinName = "Blue"
        Me.BtnViewDateWeekly.Name = "BtnViewDateWeekly"
        Me.BtnViewDateWeekly.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewDateWeekly.TabIndex = 8896
        Me.BtnViewDateWeekly.Text = "View"
        '
        'CheckEdit3
        '
        Me.CheckEdit3.Location = New System.Drawing.Point(973, 58)
        Me.CheckEdit3.Name = "CheckEdit3"
        Me.CheckEdit3.Properties.Caption = "Show Revenue Before Tax"
        Me.CheckEdit3.Size = New System.Drawing.Size(154, 19)
        Me.CheckEdit3.TabIndex = 8903
        Me.CheckEdit3.Visible = False
        '
        'CheckEdit4
        '
        Me.CheckEdit4.Location = New System.Drawing.Point(893, 58)
        Me.CheckEdit4.Name = "CheckEdit4"
        Me.CheckEdit4.Properties.Caption = "Show Retail"
        Me.CheckEdit4.Size = New System.Drawing.Size(90, 19)
        Me.CheckEdit4.TabIndex = 8902
        Me.CheckEdit4.Visible = False
        '
        'XTPMonthlySales
        '
        Me.XTPMonthlySales.Controls.Add(Me.XTCMonthlySales)
        Me.XTPMonthlySales.Name = "XTPMonthlySales"
        Me.XTPMonthlySales.Size = New System.Drawing.Size(1132, 486)
        Me.XTPMonthlySales.Text = "Monthly Sales"
        '
        'XTCMonthlySales
        '
        Me.XTCMonthlySales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCMonthlySales.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCMonthlySales.Location = New System.Drawing.Point(0, 0)
        Me.XTCMonthlySales.Name = "XTCMonthlySales"
        Me.XTCMonthlySales.SelectedTabPage = Me.XTPMonthlyByWeek
        Me.XTCMonthlySales.Size = New System.Drawing.Size(1132, 486)
        Me.XTCMonthlySales.TabIndex = 5
        Me.XTCMonthlySales.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPMonthlyByWeek, Me.XTPMonthlyByMonth})
        '
        'XTPMonthlyByWeek
        '
        Me.XTPMonthlyByWeek.Controls.Add(Me.GroupControlWeeklySales)
        Me.XTPMonthlyByWeek.Controls.Add(Me.GroupControl1)
        Me.XTPMonthlyByWeek.Name = "XTPMonthlyByWeek"
        Me.XTPMonthlyByWeek.Size = New System.Drawing.Size(1103, 480)
        Me.XTPMonthlyByWeek.Text = "View by Week"
        '
        'GroupControlWeeklySales
        '
        Me.GroupControlWeeklySales.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlWeeklySales.Controls.Add(Me.GCSalesPOSWeekly)
        Me.GroupControlWeeklySales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlWeeklySales.Enabled = False
        Me.GroupControlWeeklySales.Location = New System.Drawing.Point(0, 52)
        Me.GroupControlWeeklySales.Name = "GroupControlWeeklySales"
        Me.GroupControlWeeklySales.Size = New System.Drawing.Size(1103, 428)
        Me.GroupControlWeeklySales.TabIndex = 4
        '
        'GCSalesPOSWeekly
        '
        Me.GCSalesPOSWeekly.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesPOSWeekly.Location = New System.Drawing.Point(20, 2)
        Me.GCSalesPOSWeekly.MainView = Me.BGVSalesPOSWeekly
        Me.GCSalesPOSWeekly.Name = "GCSalesPOSWeekly"
        Me.GCSalesPOSWeekly.Size = New System.Drawing.Size(1081, 424)
        Me.GCSalesPOSWeekly.TabIndex = 3
        Me.GCSalesPOSWeekly.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVSalesPOSWeekly})
        '
        'BGVSalesPOSWeekly
        '
        Me.BGVSalesPOSWeekly.GridControl = Me.GCSalesPOSWeekly
        Me.BGVSalesPOSWeekly.Name = "BGVSalesPOSWeekly"
        Me.BGVSalesPOSWeekly.OptionsBehavior.AutoExpandAllGroups = True
        Me.BGVSalesPOSWeekly.OptionsBehavior.ReadOnly = True
        Me.BGVSalesPOSWeekly.OptionsView.ColumnAutoWidth = False
        Me.BGVSalesPOSWeekly.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BGVSalesPOSWeekly.OptionsView.ShowFooter = True
        Me.BGVSalesPOSWeekly.OptionsView.ShowGroupPanel = False
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.BtnExportToXLSWeekly)
        Me.GroupControl1.Controls.Add(Me.PanelControl1)
        Me.GroupControl1.Controls.Add(Me.CheckShowRevBefTaxWS)
        Me.GroupControl1.Controls.Add(Me.CheckShowRetailWS)
        Me.GroupControl1.Controls.Add(Me.BtnViewWeeklySales)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1103, 52)
        Me.GroupControl1.TabIndex = 2
        '
        'BtnExportToXLSWeekly
        '
        Me.BtnExportToXLSWeekly.Location = New System.Drawing.Point(681, 16)
        Me.BtnExportToXLSWeekly.LookAndFeel.SkinName = "Blue"
        Me.BtnExportToXLSWeekly.Name = "BtnExportToXLSWeekly"
        Me.BtnExportToXLSWeekly.Size = New System.Drawing.Size(92, 20)
        Me.BtnExportToXLSWeekly.TabIndex = 8934
        Me.BtnExportToXLSWeekly.Text = "Export to XLS"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEEndWeekly)
        Me.PanelControl1.Controls.Add(Me.LabelControl7)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.DEFromWeekly)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.LEDayWeekly)
        Me.PanelControl1.Controls.Add(Me.CEPromoWeekly)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl1.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(574, 48)
        Me.PanelControl1.TabIndex = 8933
        '
        'DEEndWeekly
        '
        Me.DEEndWeekly.EditValue = Nothing
        Me.DEEndWeekly.Location = New System.Drawing.Point(178, 14)
        Me.DEEndWeekly.Name = "DEEndWeekly"
        Me.DEEndWeekly.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEEndWeekly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEndWeekly.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEEndWeekly.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEndWeekly.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEndWeekly.Size = New System.Drawing.Size(111, 20)
        Me.DEEndWeekly.TabIndex = 8895
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 17)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl7.TabIndex = 8892
        Me.LabelControl7.Text = "From"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(151, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl6.TabIndex = 8893
        Me.LabelControl6.Text = "Until"
        '
        'DEFromWeekly
        '
        Me.DEFromWeekly.EditValue = Nothing
        Me.DEFromWeekly.Location = New System.Drawing.Point(42, 14)
        Me.DEFromWeekly.Name = "DEFromWeekly"
        Me.DEFromWeekly.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromWeekly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromWeekly.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromWeekly.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromWeekly.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromWeekly.Size = New System.Drawing.Size(104, 20)
        Me.DEFromWeekly.TabIndex = 8894
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(295, 17)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl5.TabIndex = 8899
        Me.LabelControl5.Text = "Begin Day"
        '
        'LEDayWeekly
        '
        Me.LEDayWeekly.Location = New System.Drawing.Point(349, 14)
        Me.LEDayWeekly.Name = "LEDayWeekly"
        Me.LEDayWeekly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDayWeekly.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_day", "Id Day", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("day", "Day")})
        Me.LEDayWeekly.Size = New System.Drawing.Size(128, 20)
        Me.LEDayWeekly.TabIndex = 8900
        '
        'CEPromoWeekly
        '
        Me.CEPromoWeekly.Location = New System.Drawing.Point(483, 14)
        Me.CEPromoWeekly.Name = "CEPromoWeekly"
        Me.CEPromoWeekly.Properties.Caption = "Include Promo"
        Me.CEPromoWeekly.Size = New System.Drawing.Size(89, 19)
        Me.CEPromoWeekly.TabIndex = 8927
        '
        'CheckShowRevBefTaxWS
        '
        Me.CheckShowRevBefTaxWS.Location = New System.Drawing.Point(973, 58)
        Me.CheckShowRevBefTaxWS.Name = "CheckShowRevBefTaxWS"
        Me.CheckShowRevBefTaxWS.Properties.Caption = "Show Revenue Before Tax"
        Me.CheckShowRevBefTaxWS.Size = New System.Drawing.Size(154, 19)
        Me.CheckShowRevBefTaxWS.TabIndex = 8903
        Me.CheckShowRevBefTaxWS.Visible = False
        '
        'CheckShowRetailWS
        '
        Me.CheckShowRetailWS.Location = New System.Drawing.Point(893, 58)
        Me.CheckShowRetailWS.Name = "CheckShowRetailWS"
        Me.CheckShowRetailWS.Properties.Caption = "Show Retail"
        Me.CheckShowRetailWS.Size = New System.Drawing.Size(90, 19)
        Me.CheckShowRetailWS.TabIndex = 8902
        Me.CheckShowRetailWS.Visible = False
        '
        'BtnViewWeeklySales
        '
        Me.BtnViewWeeklySales.Location = New System.Drawing.Point(602, 16)
        Me.BtnViewWeeklySales.LookAndFeel.SkinName = "Blue"
        Me.BtnViewWeeklySales.Name = "BtnViewWeeklySales"
        Me.BtnViewWeeklySales.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewWeeklySales.TabIndex = 8896
        Me.BtnViewWeeklySales.Text = "View"
        '
        'XTPMonthlyByMonth
        '
        Me.XTPMonthlyByMonth.Controls.Add(Me.GroupControl2)
        Me.XTPMonthlyByMonth.Controls.Add(Me.GroupControlMonthlySales)
        Me.XTPMonthlyByMonth.Name = "XTPMonthlyByMonth"
        Me.XTPMonthlyByMonth.PageVisible = False
        Me.XTPMonthlyByMonth.Size = New System.Drawing.Size(1103, 480)
        Me.XTPMonthlyByMonth.Text = "View by Month"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.CheckShowRevBefTax)
        Me.GroupControl2.Controls.Add(Me.CheckShowRetail)
        Me.GroupControl2.Controls.Add(Me.LEUntilYear)
        Me.GroupControl2.Controls.Add(Me.LEUntilMonth)
        Me.GroupControl2.Controls.Add(Me.LEFromYear)
        Me.GroupControl2.Controls.Add(Me.LEFromMonth)
        Me.GroupControl2.Controls.Add(Me.BtnViewMonthlySales)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.LabelControl13)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1103, 48)
        Me.GroupControl2.TabIndex = 3
        '
        'CheckShowRevBefTax
        '
        Me.CheckShowRevBefTax.Location = New System.Drawing.Point(811, 14)
        Me.CheckShowRevBefTax.Name = "CheckShowRevBefTax"
        Me.CheckShowRevBefTax.Properties.Caption = "Show Revenue Before Tax"
        Me.CheckShowRevBefTax.Size = New System.Drawing.Size(154, 19)
        Me.CheckShowRevBefTax.TabIndex = 8902
        '
        'CheckShowRetail
        '
        Me.CheckShowRetail.Location = New System.Drawing.Point(727, 14)
        Me.CheckShowRetail.Name = "CheckShowRetail"
        Me.CheckShowRetail.Properties.Caption = "Show Retail"
        Me.CheckShowRetail.Size = New System.Drawing.Size(90, 19)
        Me.CheckShowRetail.TabIndex = 8901
        '
        'LEUntilYear
        '
        Me.LEUntilYear.Location = New System.Drawing.Point(530, 14)
        Me.LEUntilYear.Name = "LEUntilYear"
        Me.LEUntilYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEUntilYear.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_year", "Code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("label_year", "Year"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_year", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LEUntilYear.Size = New System.Drawing.Size(110, 20)
        Me.LEUntilYear.TabIndex = 8900
        '
        'LEUntilMonth
        '
        Me.LEUntilMonth.Location = New System.Drawing.Point(372, 14)
        Me.LEUntilMonth.Name = "LEUntilMonth"
        Me.LEUntilMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEUntilMonth.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_month", "Code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("label_month", "Month")})
        Me.LEUntilMonth.Size = New System.Drawing.Size(152, 20)
        Me.LEUntilMonth.TabIndex = 8899
        '
        'LEFromYear
        '
        Me.LEFromYear.Location = New System.Drawing.Point(219, 14)
        Me.LEFromYear.Name = "LEFromYear"
        Me.LEFromYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEFromYear.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_year", "Code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("label_year", "Year"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_year", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LEFromYear.Size = New System.Drawing.Size(110, 20)
        Me.LEFromYear.TabIndex = 8898
        '
        'LEFromMonth
        '
        Me.LEFromMonth.Location = New System.Drawing.Point(61, 14)
        Me.LEFromMonth.Name = "LEFromMonth"
        Me.LEFromMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEFromMonth.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_month", "Code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("label_month", "Month")})
        Me.LEFromMonth.Size = New System.Drawing.Size(152, 20)
        Me.LEFromMonth.TabIndex = 8897
        '
        'BtnViewMonthlySales
        '
        Me.BtnViewMonthlySales.Location = New System.Drawing.Point(646, 14)
        Me.BtnViewMonthlySales.LookAndFeel.SkinName = "Blue"
        Me.BtnViewMonthlySales.Name = "BtnViewMonthlySales"
        Me.BtnViewMonthlySales.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewMonthlySales.TabIndex = 8896
        Me.BtnViewMonthlySales.Text = "View"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(345, 17)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl12.TabIndex = 8893
        Me.LabelControl12.Text = "Until"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(31, 17)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl13.TabIndex = 8892
        Me.LabelControl13.Text = "From"
        '
        'GroupControlMonthlySales
        '
        Me.GroupControlMonthlySales.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlMonthlySales.Controls.Add(Me.GCSalesPOSMonthly)
        Me.GroupControlMonthlySales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlMonthlySales.Enabled = False
        Me.GroupControlMonthlySales.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlMonthlySales.Name = "GroupControlMonthlySales"
        Me.GroupControlMonthlySales.Size = New System.Drawing.Size(1103, 480)
        Me.GroupControlMonthlySales.TabIndex = 4
        '
        'GCSalesPOSMonthly
        '
        Me.GCSalesPOSMonthly.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesPOSMonthly.Location = New System.Drawing.Point(20, 2)
        Me.GCSalesPOSMonthly.MainView = Me.BGVSalesPOSMonthly
        Me.GCSalesPOSMonthly.Name = "GCSalesPOSMonthly"
        Me.GCSalesPOSMonthly.Size = New System.Drawing.Size(1081, 476)
        Me.GCSalesPOSMonthly.TabIndex = 4
        Me.GCSalesPOSMonthly.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVSalesPOSMonthly})
        '
        'BGVSalesPOSMonthly
        '
        Me.BGVSalesPOSMonthly.GridControl = Me.GCSalesPOSMonthly
        Me.BGVSalesPOSMonthly.Name = "BGVSalesPOSMonthly"
        Me.BGVSalesPOSMonthly.OptionsBehavior.ReadOnly = True
        Me.BGVSalesPOSMonthly.OptionsView.ColumnAutoWidth = False
        Me.BGVSalesPOSMonthly.OptionsView.ShowFooter = True
        Me.BGVSalesPOSMonthly.OptionsView.ShowGroupPanel = False
        '
        'XTPInvoice
        '
        Me.XTPInvoice.Controls.Add(Me.XtraTabControl1)
        Me.XTPInvoice.Controls.Add(Me.GroupControl4)
        Me.XTPInvoice.Name = "XTPInvoice"
        Me.XTPInvoice.Size = New System.Drawing.Size(1132, 486)
        Me.XTPInvoice.Text = "Invoice"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 50)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1132, 436)
        Me.XtraTabControl1.TabIndex = 6
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GCInvoiceWeek)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1103, 430)
        Me.XtraTabPage1.Text = "View by Week"
        '
        'GCInvoiceWeek
        '
        Me.GCInvoiceWeek.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoiceWeek.Location = New System.Drawing.Point(0, 0)
        Me.GCInvoiceWeek.MainView = Me.GVInvoiceWeek
        Me.GCInvoiceWeek.Name = "GCInvoiceWeek"
        Me.GCInvoiceWeek.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit})
        Me.GCInvoiceWeek.Size = New System.Drawing.Size(1103, 430)
        Me.GCInvoiceWeek.TabIndex = 0
        Me.GCInvoiceWeek.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoiceWeek})
        '
        'GVInvoiceWeek
        '
        Me.GVInvoiceWeek.Appearance.BandPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVInvoiceWeek.Appearance.BandPanel.Options.UseFont = True
        Me.GVInvoiceWeek.GridControl = Me.GCInvoiceWeek
        Me.GVInvoiceWeek.Name = "GVInvoiceWeek"
        Me.GVInvoiceWeek.OptionsPrint.UsePrintStyles = False
        Me.GVInvoiceWeek.OptionsView.AllowCellMerge = True
        Me.GVInvoiceWeek.OptionsView.ColumnAutoWidth = False
        Me.GVInvoiceWeek.OptionsView.ShowFooter = True
        Me.GVInvoiceWeek.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemHyperLinkEdit
        '
        Me.RepositoryItemHyperLinkEdit.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit.Name = "RepositoryItemHyperLinkEdit"
        '
        'GroupControl4
        '
        Me.GroupControl4.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl4.Controls.Add(Me.DEInvoiceTo)
        Me.GroupControl4.Controls.Add(Me.SBInvoiceExportExcel)
        Me.GroupControl4.Controls.Add(Me.LabelControl9)
        Me.GroupControl4.Controls.Add(Me.SBInvoiceTo)
        Me.GroupControl4.Controls.Add(Me.DEInvoiceFrom)
        Me.GroupControl4.Controls.Add(Me.LabelControl16)
        Me.GroupControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl4.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(1132, 50)
        Me.GroupControl4.TabIndex = 4
        '
        'DEInvoiceTo
        '
        Me.DEInvoiceTo.EditValue = Nothing
        Me.DEInvoiceTo.Location = New System.Drawing.Point(213, 16)
        Me.DEInvoiceTo.Name = "DEInvoiceTo"
        Me.DEInvoiceTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEInvoiceTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEInvoiceTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEInvoiceTo.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEInvoiceTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEInvoiceTo.Size = New System.Drawing.Size(111, 20)
        Me.DEInvoiceTo.TabIndex = 8895
        '
        'SBInvoiceExportExcel
        '
        Me.SBInvoiceExportExcel.Location = New System.Drawing.Point(411, 16)
        Me.SBInvoiceExportExcel.LookAndFeel.SkinName = "Blue"
        Me.SBInvoiceExportExcel.Name = "SBInvoiceExportExcel"
        Me.SBInvoiceExportExcel.Size = New System.Drawing.Size(92, 20)
        Me.SBInvoiceExportExcel.TabIndex = 8934
        Me.SBInvoiceExportExcel.Text = "Export to XLS"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(30, 19)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl9.TabIndex = 8892
        Me.LabelControl9.Text = "From"
        '
        'SBInvoiceTo
        '
        Me.SBInvoiceTo.Location = New System.Drawing.Point(330, 16)
        Me.SBInvoiceTo.LookAndFeel.SkinName = "Blue"
        Me.SBInvoiceTo.Name = "SBInvoiceTo"
        Me.SBInvoiceTo.Size = New System.Drawing.Size(75, 20)
        Me.SBInvoiceTo.TabIndex = 8896
        Me.SBInvoiceTo.Text = "View"
        '
        'DEInvoiceFrom
        '
        Me.DEInvoiceFrom.EditValue = Nothing
        Me.DEInvoiceFrom.Location = New System.Drawing.Point(65, 16)
        Me.DEInvoiceFrom.Name = "DEInvoiceFrom"
        Me.DEInvoiceFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEInvoiceFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEInvoiceFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEInvoiceFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEInvoiceFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEInvoiceFrom.Size = New System.Drawing.Size(100, 20)
        Me.DEInvoiceFrom.TabIndex = 8894
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(181, 19)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl16.TabIndex = 8893
        Me.LabelControl16.Text = "Until"
        '
        'XTPUSASales
        '
        Me.XTPUSASales.Controls.Add(Me.XtraScrollableControl1)
        Me.XTPUSASales.Controls.Add(Me.GroupControl5)
        Me.XTPUSASales.Name = "XTPUSASales"
        Me.XTPUSASales.Size = New System.Drawing.Size(1132, 486)
        Me.XTPUSASales.Text = "USA Sales"
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.GCDetailRoyalty)
        Me.XtraScrollableControl1.Controls.Add(Me.GCDetailSales)
        Me.XtraScrollableControl1.Controls.Add(Me.GCUSASales)
        Me.XtraScrollableControl1.Controls.Add(Me.PanelControl11)
        Me.XtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraScrollableControl1.Location = New System.Drawing.Point(0, 50)
        Me.XtraScrollableControl1.Name = "XtraScrollableControl1"
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(1132, 436)
        Me.XtraScrollableControl1.TabIndex = 18
        '
        'GCDetailRoyalty
        '
        Me.GCDetailRoyalty.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCDetailRoyalty.Location = New System.Drawing.Point(0, 210)
        Me.GCDetailRoyalty.MainView = Me.GVDetailRoyalty
        Me.GCDetailRoyalty.Name = "GCDetailRoyalty"
        Me.GCDetailRoyalty.Size = New System.Drawing.Size(1132, 200)
        Me.GCDetailRoyalty.TabIndex = 34
        Me.GCDetailRoyalty.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetailRoyalty})
        '
        'GVDetailRoyalty
        '
        Me.GVDetailRoyalty.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn9, Me.GridColumn13, Me.GridColumn12})
        Me.GVDetailRoyalty.GridControl = Me.GCDetailRoyalty
        Me.GVDetailRoyalty.GroupCount = 1
        Me.GVDetailRoyalty.GroupFormat = "{1} {2}"
        Me.GVDetailRoyalty.Name = "GVDetailRoyalty"
        Me.GVDetailRoyalty.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetailRoyalty.OptionsView.ColumnAutoWidth = False
        Me.GVDetailRoyalty.OptionsView.ShowColumnHeaders = False
        Me.GVDetailRoyalty.OptionsView.ShowFooter = True
        Me.GVDetailRoyalty.OptionsView.ShowGroupPanel = False
        Me.GVDetailRoyalty.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn14, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Group"
        Me.GridColumn14.FieldName = "group"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Text"
        Me.GridColumn9.FieldName = "text"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        Me.GridColumn9.Width = 200
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Date"
        Me.GridColumn13.FieldName = "date"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 1
        Me.GridColumn13.Width = 300
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Amount"
        Me.GridColumn12.DisplayFormat.FormatString = "N2"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "amount"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        Me.GridColumn12.Width = 300
        '
        'GCDetailSales
        '
        Me.GCDetailSales.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCDetailSales.Location = New System.Drawing.Point(0, 110)
        Me.GCDetailSales.MainView = Me.GVDetailSales
        Me.GCDetailSales.Name = "GCDetailSales"
        Me.GCDetailSales.Size = New System.Drawing.Size(1132, 100)
        Me.GCDetailSales.TabIndex = 33
        Me.GCDetailSales.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetailSales})
        '
        'GVDetailSales
        '
        Me.GVDetailSales.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11})
        Me.GVDetailSales.GridControl = Me.GCDetailSales
        Me.GVDetailSales.Name = "GVDetailSales"
        Me.GVDetailSales.OptionsView.ColumnAutoWidth = False
        Me.GVDetailSales.OptionsView.ShowColumnHeaders = False
        Me.GVDetailSales.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Text"
        Me.GridColumn10.FieldName = "text"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 500
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Amount"
        Me.GridColumn11.DisplayFormat.FormatString = "N2"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "amount"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 300
        '
        'GCUSASales
        '
        Me.GCUSASales.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCUSASales.Location = New System.Drawing.Point(0, 30)
        Me.GCUSASales.MainView = Me.GVUSASales
        Me.GCUSASales.Name = "GCUSASales"
        Me.GCUSASales.Size = New System.Drawing.Size(1132, 80)
        Me.GCUSASales.TabIndex = 1
        Me.GCUSASales.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUSASales})
        '
        'GVUSASales
        '
        Me.GVUSASales.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVUSASales.GridControl = Me.GCUSASales
        Me.GVUSASales.Name = "GVUSASales"
        Me.GVUSASales.OptionsView.ColumnAutoWidth = False
        Me.GVUSASales.OptionsView.ShowFooter = True
        Me.GVUSASales.OptionsView.ShowGroupPanel = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "No"
        Me.GridColumn4.FieldName = "no"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 200
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Date"
        Me.GridColumn5.FieldName = "date"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 300
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Amount"
        Me.GridColumn6.DisplayFormat.FormatString = "N2"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "amount"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 300
        '
        'PanelControl11
        '
        Me.PanelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl11.Controls.Add(Me.LabelControl18)
        Me.PanelControl11.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl11.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl11.Name = "PanelControl11"
        Me.PanelControl11.Size = New System.Drawing.Size(1132, 30)
        Me.PanelControl11.TabIndex = 32
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(10, 8)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(163, 13)
        Me.LabelControl18.TabIndex = 0
        Me.LabelControl18.Text = "Rekapitulasi Penjualan Gabungan:"
        '
        'GroupControl5
        '
        Me.GroupControl5.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl5.Controls.Add(Me.SLUEUSASales)
        Me.GroupControl5.Controls.Add(Me.LabelControl17)
        Me.GroupControl5.Controls.Add(Me.SimpleButton2)
        Me.GroupControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl5.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(1132, 50)
        Me.GroupControl5.TabIndex = 5
        '
        'SLUEUSASales
        '
        Me.SLUEUSASales.Location = New System.Drawing.Point(78, 17)
        Me.SLUEUSASales.Name = "SLUEUSASales"
        Me.SLUEUSASales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEUSASales.Properties.View = Me.GridView1
        Me.SLUEUSASales.Size = New System.Drawing.Size(195, 20)
        Me.SLUEUSASales.TabIndex = 8935
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn7})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.FieldName = "month"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Month"
        Me.GridColumn7.FieldName = "text"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(38, 20)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl17.TabIndex = 8892
        Me.LabelControl17.Text = "From"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(279, 17)
        Me.SimpleButton2.LookAndFeel.SkinName = "Blue"
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 20)
        Me.SimpleButton2.TabIndex = 8896
        Me.SimpleButton2.Text = "View"
        '
        'FormSalesWeekly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 514)
        Me.Controls.Add(Me.XTCPOS)
        Me.MinimizeBox = False
        Me.Name = "FormSalesWeekly"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Standard Report Sales"
        CType(Me.GVSalesPOSDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSalesPOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesPOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCPOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPOS.ResumeLayout(False)
        Me.XTPDailySales.ResumeLayout(False)
        CType(Me.GCView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCView.ResumeLayout(False)
        CType(Me.XTCDailySales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCDailySales.ResumeLayout(False)
        Me.XTPSummary.ResumeLayout(False)
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.CEAllUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.CEPromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEOptionView.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPWeeklySales.ResumeLayout(False)
        CType(Me.GCSalesWeeklyByDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVSalesWeeklyByDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEEndWeek.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEndWeek.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromWeek.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromWeek.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtWeek.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEPromoWeeklyByDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMonthlySales.ResumeLayout(False)
        CType(Me.XTCMonthlySales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCMonthlySales.ResumeLayout(False)
        Me.XTPMonthlyByWeek.ResumeLayout(False)
        CType(Me.GroupControlWeeklySales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlWeeklySales.ResumeLayout(False)
        CType(Me.GCSalesPOSWeekly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVSalesPOSWeekly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEEndWeekly.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEndWeekly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromWeekly.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromWeekly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDayWeekly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEPromoWeekly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckShowRevBefTaxWS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckShowRetailWS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMonthlyByMonth.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.CheckShowRevBefTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckShowRetail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEUntilYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEUntilMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEFromYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEFromMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlMonthlySales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlMonthlySales.ResumeLayout(False)
        CType(Me.GCSalesPOSMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVSalesPOSMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPInvoice.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.GCInvoiceWeek, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoiceWeek, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        Me.GroupControl4.PerformLayout()
        CType(Me.DEInvoiceTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEInvoiceTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEInvoiceFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEInvoiceFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPUSASales.ResumeLayout(False)
        Me.XtraScrollableControl1.ResumeLayout(False)
        CType(Me.GCDetailRoyalty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetailRoyalty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDetailSales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetailSales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCUSASales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUSASales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl11.ResumeLayout(False)
        Me.PanelControl11.PerformLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl5.ResumeLayout(False)
        Me.GroupControl5.PerformLayout()
        CType(Me.SLUEUSASales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCPOS As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPWeeklySales As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControlWeeklySales As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSalesPOSWeekly As DevExpress.XtraGrid.GridControl
    Friend WithEvents BGVSalesPOSWeekly As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CheckShowRevBefTaxWS As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckShowRetailWS As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnViewWeeklySales As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPMonthlySales As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControlMonthlySales As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSalesPOSMonthly As DevExpress.XtraGrid.GridControl
    Friend WithEvents BGVSalesPOSMonthly As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CheckShowRevBefTax As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckShowRetail As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LEUntilYear As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LEUntilMonth As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LEFromYear As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LEFromMonth As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BtnViewMonthlySales As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTPDailySales As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LEOptionView As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnStoreLabel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCView As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSalesPOS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesPOSDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignPriceRetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesignPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesPOSDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesignPriceRetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVSalesPOS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnStore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesPOSDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesStore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesTax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNetto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesPosRev As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAge As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMemoType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolTipControllerNew As DevExpress.Utils.ToolTipController
    Friend WithEvents XTCDailySales As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSummary As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumnstore_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstore_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CEPromo As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnsales_pos_discount_value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_potongan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnExportToXLSDaily As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnstore_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnExportToXLSWeekly As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCMonthlySales As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPMonthlyByWeek As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPMonthlyByMonth As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnExportToXLSDateWeekly As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtWeek As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CEPromoWeeklyByDate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit3 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit4 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnViewDateWeekly As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEEndWeekly As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFromWeekly As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDayWeekly As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents CEPromoWeekly As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DEEndWeek As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromWeek As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GCSalesWeeklyByDate As DevExpress.XtraGrid.GridControl
    Friend WithEvents BGVSalesWeeklyByDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStoreGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CEAllUnit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnsales_pos_tax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPInvoice As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DEInvoiceTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBInvoiceExportExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEInvoiceFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SBInvoiceTo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCInvoiceWeek As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvoiceWeek As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents XTPUSASales As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XtraScrollableControl1 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents SLUEUSASales As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl11 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCUSASales As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVUSASales As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDetailSales As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetailSales As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDetailRoyalty As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetailRoyalty As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
End Class
