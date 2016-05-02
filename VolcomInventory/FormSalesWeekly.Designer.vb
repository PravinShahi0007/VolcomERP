<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesWeekly
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.components = New System.ComponentModel.Container
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode
        Me.GVSalesPOSDet = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesignPriceRetail = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesignPriceType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdDesignPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSalesPOSDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdDesignPriceRetail = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCSalesPOS = New DevExpress.XtraGrid.GridControl
        Me.GVSalesPOS = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnStore = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSalesPOSDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMemoType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSalesStore = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDiscount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSalesTax = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNetto = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSalesPosRev = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDueDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAge = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolTipControllerNew = New DevExpress.Utils.ToolTipController(Me.components)
        Me.XTCPOS = New DevExpress.XtraTab.XtraTabControl
        Me.XTPDailySales = New DevExpress.XtraTab.XtraTabPage
        Me.GCView = New DevExpress.XtraEditors.GroupControl
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl
        Me.LEOptionView = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.BHide = New DevExpress.XtraEditors.SimpleButton
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.SLEStore = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnStoreLabel = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.XTPWeeklySales = New DevExpress.XtraTab.XtraTabPage
        Me.GroupControlWeeklySales = New DevExpress.XtraEditors.GroupControl
        Me.GCSalesPOSWeekly = New DevExpress.XtraGrid.GridControl
        Me.BGVSalesPOSWeekly = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.CheckShowRevBefTaxWS = New DevExpress.XtraEditors.CheckEdit
        Me.CheckShowRetailWS = New DevExpress.XtraEditors.CheckEdit
        Me.LEDayWeekly = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.BtnViewWeeklySales = New DevExpress.XtraEditors.SimpleButton
        Me.DEEndWeekly = New DevExpress.XtraEditors.DateEdit
        Me.DEFromWeekly = New DevExpress.XtraEditors.DateEdit
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl
        Me.XTPMonthlySales = New DevExpress.XtraTab.XtraTabPage
        Me.GroupControlMonthlySales = New DevExpress.XtraEditors.GroupControl
        Me.GCSalesPOSMonthly = New DevExpress.XtraGrid.GridControl
        Me.BGVSalesPOSMonthly = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.CheckShowRevBefTax = New DevExpress.XtraEditors.CheckEdit
        Me.CheckShowRetail = New DevExpress.XtraEditors.CheckEdit
        Me.LEUntilYear = New DevExpress.XtraEditors.LookUpEdit
        Me.LEUntilMonth = New DevExpress.XtraEditors.LookUpEdit
        Me.LEFromYear = New DevExpress.XtraEditors.LookUpEdit
        Me.LEFromMonth = New DevExpress.XtraEditors.LookUpEdit
        Me.BtnViewMonthlySales = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl
        CType(Me.GVSalesPOSDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSalesPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPOS.SuspendLayout()
        Me.XTPDailySales.SuspendLayout()
        CType(Me.GCView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCView.SuspendLayout()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.LEOptionView.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPWeeklySales.SuspendLayout()
        CType(Me.GroupControlWeeklySales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlWeeklySales.SuspendLayout()
        CType(Me.GCSalesPOSWeekly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVSalesPOSWeekly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.CheckShowRevBefTaxWS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckShowRetailWS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDayWeekly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEndWeekly.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEndWeekly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromWeekly.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromWeekly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMonthlySales.SuspendLayout()
        CType(Me.GroupControlMonthlySales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlMonthlySales.SuspendLayout()
        CType(Me.GCSalesPOSMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVSalesPOSMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.CheckShowRevBefTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckShowRetail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEUntilYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEUntilMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEFromYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEFromMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GCSalesPOS.Location = New System.Drawing.Point(22, 2)
        Me.GCSalesPOS.MainView = Me.GVSalesPOS
        Me.GCSalesPOS.Name = "GCSalesPOS"
        Me.GCSalesPOS.Size = New System.Drawing.Size(1108, 434)
        Me.GCSalesPOS.TabIndex = 0
        Me.GCSalesPOS.ToolTipController = Me.ToolTipControllerNew
        Me.GCSalesPOS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesPOS, Me.GVSalesPOSDet})
        '
        'GVSalesPOS
        '
        Me.GVSalesPOS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnStore, Me.GridColumnSalesPOSDate, Me.GridColumnMemoType, Me.GridColumn1, Me.GridColumnSalesStore, Me.GridColumnType, Me.GridColumnQty, Me.GridColumnTotal, Me.GridColumnDiscount, Me.GridColumnSalesTax, Me.GridColumnNetto, Me.GridColumnSalesPosRev, Me.GridColumnStatus, Me.GridColumnDueDate, Me.GridColumnAge, Me.GridColumnRemark})
        Me.GVSalesPOS.GridControl = Me.GCSalesPOS
        Me.GVSalesPOS.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_det_qty", Me.GridColumnQty, "{0:f2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", Me.GridColumnTotal, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_netto", Me.GridColumnNetto, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_revenue", Me.GridColumnSalesPosRev, "{0:n2}")})
        Me.GVSalesPOS.Name = "GVSalesPOS"
        Me.GVSalesPOS.OptionsBehavior.ReadOnly = True
        Me.GVSalesPOS.OptionsPrint.PrintDetails = True
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
        Me.GridColumnSalesPOSDate.VisibleIndex = 2
        Me.GridColumnSalesPOSDate.Width = 84
        '
        'GridColumnMemoType
        '
        Me.GridColumnMemoType.Caption = "INV. TYPE"
        Me.GridColumnMemoType.FieldName = "memo_type"
        Me.GridColumnMemoType.FieldNameSortGroup = "id_memo_type"
        Me.GridColumnMemoType.Name = "GridColumnMemoType"
        Me.GridColumnMemoType.Visible = True
        Me.GridColumnMemoType.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PERIOD"
        Me.GridColumn1.FieldName = "sales_pos_period"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 68
        '
        'GridColumnSalesStore
        '
        Me.GridColumnSalesStore.Caption = "STORE"
        Me.GridColumnSalesStore.FieldName = "store_name_from"
        Me.GridColumnSalesStore.Name = "GridColumnSalesStore"
        Me.GridColumnSalesStore.Visible = True
        Me.GridColumnSalesStore.VisibleIndex = 4
        Me.GridColumnSalesStore.Width = 68
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "TYPE"
        Me.GridColumnType.FieldName = "so_type"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.Visible = True
        Me.GridColumnType.VisibleIndex = 5
        Me.GridColumnType.Width = 68
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "QTY"
        Me.GridColumnQty.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sales_pos_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_det_qty", "{0:n2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 6
        Me.GridColumnQty.Width = 68
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "RETAIL"
        Me.GridColumnTotal.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "sales_pos_total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", "{0:n2}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 9
        Me.GridColumnTotal.Width = 68
        '
        'GridColumnDiscount
        '
        Me.GridColumnDiscount.Caption = "COMMISSION (%)"
        Me.GridColumnDiscount.FieldName = "sales_pos_discount"
        Me.GridColumnDiscount.Name = "GridColumnDiscount"
        Me.GridColumnDiscount.Visible = True
        Me.GridColumnDiscount.VisibleIndex = 7
        Me.GridColumnDiscount.Width = 97
        '
        'GridColumnSalesTax
        '
        Me.GridColumnSalesTax.Caption = "TAX(%)"
        Me.GridColumnSalesTax.FieldName = "sales_pos_vat"
        Me.GridColumnSalesTax.Name = "GridColumnSalesTax"
        Me.GridColumnSalesTax.Visible = True
        Me.GridColumnSalesTax.VisibleIndex = 8
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
        Me.GridColumnNetto.VisibleIndex = 10
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
        Me.GridColumnSalesPosRev.VisibleIndex = 11
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
        Me.GridColumnDueDate.VisibleIndex = 12
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
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sales_pos_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.OptionsColumn.ShowInCustomizationForm = False
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
        Me.XTCPOS.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDailySales, Me.XTPWeeklySales, Me.XTPMonthlySales})
        '
        'XTPDailySales
        '
        Me.XTPDailySales.Controls.Add(Me.GCView)
        Me.XTPDailySales.Controls.Add(Me.GCFilter)
        Me.XTPDailySales.Name = "XTPDailySales"
        Me.XTPDailySales.Size = New System.Drawing.Size(1132, 488)
        Me.XTPDailySales.Text = "Daily Sales"
        '
        'GCView
        '
        Me.GCView.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCView.Controls.Add(Me.GCSalesPOS)
        Me.GCView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCView.Location = New System.Drawing.Point(0, 50)
        Me.GCView.Name = "GCView"
        Me.GCView.Size = New System.Drawing.Size(1132, 438)
        Me.GCView.TabIndex = 3
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.LEOptionView)
        Me.GCFilter.Controls.Add(Me.LabelControl4)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.DEUntil)
        Me.GCFilter.Controls.Add(Me.DEFrom)
        Me.GCFilter.Controls.Add(Me.LabelControl2)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Controls.Add(Me.SLEStore)
        Me.GCFilter.Controls.Add(Me.LabelControl1)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(1132, 50)
        Me.GCFilter.TabIndex = 2
        '
        'LEOptionView
        '
        Me.LEOptionView.Location = New System.Drawing.Point(623, 14)
        Me.LEOptionView.Name = "LEOptionView"
        Me.LEOptionView.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEOptionView.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_option_view", "Id Option View", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("option_view", "Option View")})
        Me.LEOptionView.Size = New System.Drawing.Size(123, 20)
        Me.LEOptionView.TabIndex = 8900
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(560, 17)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl4.TabIndex = 8899
        Me.LabelControl4.Text = "Option View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(835, 14)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(756, 14)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(440, 14)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(286, 14)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEFrom.Size = New System.Drawing.Size(121, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(413, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(256, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'SLEStore
        '
        Me.SLEStore.Location = New System.Drawing.Point(64, 14)
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
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(32, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Store"
        '
        'XTPWeeklySales
        '
        Me.XTPWeeklySales.Controls.Add(Me.GroupControlWeeklySales)
        Me.XTPWeeklySales.Controls.Add(Me.GroupControl1)
        Me.XTPWeeklySales.Name = "XTPWeeklySales"
        Me.XTPWeeklySales.Size = New System.Drawing.Size(1132, 488)
        Me.XTPWeeklySales.Text = "Weekly Sales"
        '
        'GroupControlWeeklySales
        '
        Me.GroupControlWeeklySales.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlWeeklySales.Controls.Add(Me.GCSalesPOSWeekly)
        Me.GroupControlWeeklySales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlWeeklySales.Enabled = False
        Me.GroupControlWeeklySales.Location = New System.Drawing.Point(0, 50)
        Me.GroupControlWeeklySales.Name = "GroupControlWeeklySales"
        Me.GroupControlWeeklySales.Size = New System.Drawing.Size(1132, 438)
        Me.GroupControlWeeklySales.TabIndex = 4
        '
        'GCSalesPOSWeekly
        '
        Me.GCSalesPOSWeekly.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesPOSWeekly.Location = New System.Drawing.Point(22, 2)
        Me.GCSalesPOSWeekly.MainView = Me.BGVSalesPOSWeekly
        Me.GCSalesPOSWeekly.Name = "GCSalesPOSWeekly"
        Me.GCSalesPOSWeekly.Size = New System.Drawing.Size(1108, 434)
        Me.GCSalesPOSWeekly.TabIndex = 3
        Me.GCSalesPOSWeekly.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVSalesPOSWeekly})
        '
        'BGVSalesPOSWeekly
        '
        Me.BGVSalesPOSWeekly.GridControl = Me.GCSalesPOSWeekly
        Me.BGVSalesPOSWeekly.Name = "BGVSalesPOSWeekly"
        Me.BGVSalesPOSWeekly.OptionsBehavior.ReadOnly = True
        Me.BGVSalesPOSWeekly.OptionsView.ColumnAutoWidth = False
        Me.BGVSalesPOSWeekly.OptionsView.ShowFooter = True
        Me.BGVSalesPOSWeekly.OptionsView.ShowGroupPanel = False
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.CheckShowRevBefTaxWS)
        Me.GroupControl1.Controls.Add(Me.CheckShowRetailWS)
        Me.GroupControl1.Controls.Add(Me.LEDayWeekly)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.BtnViewWeeklySales)
        Me.GroupControl1.Controls.Add(Me.DEEndWeekly)
        Me.GroupControl1.Controls.Add(Me.DEFromWeekly)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1132, 50)
        Me.GroupControl1.TabIndex = 2
        '
        'CheckShowRevBefTaxWS
        '
        Me.CheckShowRevBefTaxWS.Location = New System.Drawing.Point(681, 14)
        Me.CheckShowRevBefTaxWS.Name = "CheckShowRevBefTaxWS"
        Me.CheckShowRevBefTaxWS.Properties.Caption = "Show Revenue Before Tax"
        Me.CheckShowRevBefTaxWS.Size = New System.Drawing.Size(154, 19)
        Me.CheckShowRevBefTaxWS.TabIndex = 8903
        '
        'CheckShowRetailWS
        '
        Me.CheckShowRetailWS.Location = New System.Drawing.Point(601, 14)
        Me.CheckShowRetailWS.Name = "CheckShowRetailWS"
        Me.CheckShowRetailWS.Properties.Caption = "Show Retail"
        Me.CheckShowRetailWS.Size = New System.Drawing.Size(90, 19)
        Me.CheckShowRetailWS.TabIndex = 8902
        '
        'LEDayWeekly
        '
        Me.LEDayWeekly.Location = New System.Drawing.Point(391, 14)
        Me.LEDayWeekly.Name = "LEDayWeekly"
        Me.LEDayWeekly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDayWeekly.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_day", "Id Day", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("day", "Day")})
        Me.LEDayWeekly.Size = New System.Drawing.Size(123, 20)
        Me.LEDayWeekly.TabIndex = 8900
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(332, 17)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl5.TabIndex = 8899
        Me.LabelControl5.Text = "Begin From"
        '
        'BtnViewWeeklySales
        '
        Me.BtnViewWeeklySales.Location = New System.Drawing.Point(520, 14)
        Me.BtnViewWeeklySales.LookAndFeel.SkinName = "Blue"
        Me.BtnViewWeeklySales.Name = "BtnViewWeeklySales"
        Me.BtnViewWeeklySales.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewWeeklySales.TabIndex = 8896
        Me.BtnViewWeeklySales.Text = "View"
        '
        'DEEndWeekly
        '
        Me.DEEndWeekly.EditValue = Nothing
        Me.DEEndWeekly.Location = New System.Drawing.Point(215, 14)
        Me.DEEndWeekly.Name = "DEEndWeekly"
        Me.DEEndWeekly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEndWeekly.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEndWeekly.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEndWeekly.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEEndWeekly.Size = New System.Drawing.Size(111, 20)
        Me.DEEndWeekly.TabIndex = 8895
        '
        'DEFromWeekly
        '
        Me.DEFromWeekly.EditValue = Nothing
        Me.DEFromWeekly.Location = New System.Drawing.Point(61, 14)
        Me.DEFromWeekly.Name = "DEFromWeekly"
        Me.DEFromWeekly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromWeekly.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromWeekly.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromWeekly.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEFromWeekly.Size = New System.Drawing.Size(121, 20)
        Me.DEFromWeekly.TabIndex = 8894
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(188, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl6.TabIndex = 8893
        Me.LabelControl6.Text = "Until"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(31, 17)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl7.TabIndex = 8892
        Me.LabelControl7.Text = "From"
        '
        'XTPMonthlySales
        '
        Me.XTPMonthlySales.Controls.Add(Me.GroupControlMonthlySales)
        Me.XTPMonthlySales.Controls.Add(Me.GroupControl2)
        Me.XTPMonthlySales.Name = "XTPMonthlySales"
        Me.XTPMonthlySales.Size = New System.Drawing.Size(1132, 488)
        Me.XTPMonthlySales.Text = "Monthly Sales"
        '
        'GroupControlMonthlySales
        '
        Me.GroupControlMonthlySales.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlMonthlySales.Controls.Add(Me.GCSalesPOSMonthly)
        Me.GroupControlMonthlySales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlMonthlySales.Enabled = False
        Me.GroupControlMonthlySales.Location = New System.Drawing.Point(0, 50)
        Me.GroupControlMonthlySales.Name = "GroupControlMonthlySales"
        Me.GroupControlMonthlySales.Size = New System.Drawing.Size(1132, 438)
        Me.GroupControlMonthlySales.TabIndex = 4
        '
        'GCSalesPOSMonthly
        '
        Me.GCSalesPOSMonthly.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesPOSMonthly.Location = New System.Drawing.Point(22, 2)
        Me.GCSalesPOSMonthly.MainView = Me.BGVSalesPOSMonthly
        Me.GCSalesPOSMonthly.Name = "GCSalesPOSMonthly"
        Me.GCSalesPOSMonthly.Size = New System.Drawing.Size(1108, 434)
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
        Me.GroupControl2.Size = New System.Drawing.Size(1132, 50)
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
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.LEOptionView.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPWeeklySales.ResumeLayout(False)
        CType(Me.GroupControlWeeklySales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlWeeklySales.ResumeLayout(False)
        CType(Me.GCSalesPOSWeekly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVSalesPOSWeekly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.CheckShowRevBefTaxWS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckShowRetailWS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDayWeekly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEndWeekly.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEndWeekly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromWeekly.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromWeekly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMonthlySales.ResumeLayout(False)
        CType(Me.GroupControlMonthlySales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlMonthlySales.ResumeLayout(False)
        CType(Me.GCSalesPOSMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVSalesPOSMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.CheckShowRevBefTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckShowRetail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEUntilYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEUntilMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEFromYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEFromMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LEDayWeekly As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewWeeklySales As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEEndWeekly As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromWeekly As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
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
End Class
