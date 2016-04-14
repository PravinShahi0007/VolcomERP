<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGMissingCreditNote
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode
        Me.XTCFGMissingCN = New DevExpress.XtraTab.XtraTabControl
        Me.XTPFGMissingStoreCreditNote = New DevExpress.XtraTab.XtraTabPage
        Me.XTPFGMissingWHCreditNote = New DevExpress.XtraTab.XtraTabPage
        Me.GCFGMissingCNStore = New DevExpress.XtraGrid.GridControl
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
        Me.GVFGMissingCNStore = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnStore = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSalesPOSDate = New DevExpress.XtraGrid.Columns.GridColumn
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
        CType(Me.XTCFGMissingCN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCFGMissingCN.SuspendLayout()
        Me.XTPFGMissingStoreCreditNote.SuspendLayout()
        CType(Me.GCFGMissingCNStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesPOSDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGMissingCNStore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCFGMissingCN
        '
        Me.XTCFGMissingCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCFGMissingCN.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCFGMissingCN.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCFGMissingCN.Location = New System.Drawing.Point(0, 0)
        Me.XTCFGMissingCN.Name = "XTCFGMissingCN"
        Me.XTCFGMissingCN.SelectedTabPage = Me.XTPFGMissingStoreCreditNote
        Me.XTCFGMissingCN.Size = New System.Drawing.Size(722, 494)
        Me.XTCFGMissingCN.TabIndex = 0
        Me.XTCFGMissingCN.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPFGMissingStoreCreditNote, Me.XTPFGMissingWHCreditNote})
        '
        'XTPFGMissingStoreCreditNote
        '
        Me.XTPFGMissingStoreCreditNote.Controls.Add(Me.GCFGMissingCNStore)
        Me.XTPFGMissingStoreCreditNote.Name = "XTPFGMissingStoreCreditNote"
        Me.XTPFGMissingStoreCreditNote.Size = New System.Drawing.Size(665, 488)
        Me.XTPFGMissingStoreCreditNote.Text = "In Store"
        '
        'XTPFGMissingWHCreditNote
        '
        Me.XTPFGMissingWHCreditNote.Name = "XTPFGMissingWHCreditNote"
        Me.XTPFGMissingWHCreditNote.Size = New System.Drawing.Size(0, 0)
        Me.XTPFGMissingWHCreditNote.Text = "In WH"
        '
        'GCFGMissingCNStore
        '
        Me.GCFGMissingCNStore.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.GVSalesPOSDet
        GridLevelNode1.RelationName = "Detail Transaction"
        Me.GCFGMissingCNStore.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GCFGMissingCNStore.Location = New System.Drawing.Point(0, 0)
        Me.GCFGMissingCNStore.MainView = Me.GVFGMissingCNStore
        Me.GCFGMissingCNStore.Name = "GCFGMissingCNStore"
        Me.GCFGMissingCNStore.Size = New System.Drawing.Size(665, 488)
        Me.GCFGMissingCNStore.TabIndex = 2
        Me.GCFGMissingCNStore.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesPOSDet, Me.GVFGMissingCNStore})
        '
        'GVSalesPOSDet
        '
        Me.GVSalesPOSDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumn2, Me.GridColumnAmount, Me.GridColumnDesignPriceRetail, Me.GridColumnDesignPriceType, Me.GridColumnPrice, Me.GridColumn3, Me.GridColumnIdDesign, Me.GridColumnIdProduct, Me.GridColumnIdSample, Me.GridColumnIdDesignPrice, Me.GridColumnIdSalesPOSDet, Me.GridColumnColor, Me.GridColumnIdDesignPriceRetail})
        Me.GVSalesPOSDet.GridControl = Me.GCFGMissingCNStore
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
        'GVFGMissingCNStore
        '
        Me.GVFGMissingCNStore.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnStore, Me.GridColumnSalesPOSDate, Me.GridColumn1, Me.GridColumnSalesStore, Me.GridColumnType, Me.GridColumnQty, Me.GridColumnTotal, Me.GridColumnDiscount, Me.GridColumnSalesTax, Me.GridColumnNetto, Me.GridColumnSalesPosRev, Me.GridColumnStatus, Me.GridColumnDueDate, Me.GridColumnAge, Me.GridColumnRemark})
        Me.GVFGMissingCNStore.GridControl = Me.GCFGMissingCNStore
        Me.GVFGMissingCNStore.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_det_qty", Me.GridColumnQty, "{0:f2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", Me.GridColumnTotal, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_netto", Me.GridColumnNetto, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_revenue", Me.GridColumnSalesPosRev, "{0:n2}")})
        Me.GVFGMissingCNStore.Name = "GVFGMissingCNStore"
        Me.GVFGMissingCNStore.OptionsBehavior.ReadOnly = True
        Me.GVFGMissingCNStore.OptionsPrint.PrintDetails = True
        Me.GVFGMissingCNStore.OptionsView.ShowFooter = True
        Me.GVFGMissingCNStore.OptionsView.ShowGroupPanel = False
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
        Me.GridColumnSalesPOSDate.VisibleIndex = 1
        Me.GridColumnSalesPOSDate.Width = 84
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PERIOD"
        Me.GridColumn1.FieldName = "sales_pos_period"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 68
        '
        'GridColumnSalesStore
        '
        Me.GridColumnSalesStore.Caption = "STORE"
        Me.GridColumnSalesStore.FieldName = "store_name_from"
        Me.GridColumnSalesStore.Name = "GridColumnSalesStore"
        Me.GridColumnSalesStore.Visible = True
        Me.GridColumnSalesStore.VisibleIndex = 3
        Me.GridColumnSalesStore.Width = 68
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "TYPE"
        Me.GridColumnType.FieldName = "so_type"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.Visible = True
        Me.GridColumnType.VisibleIndex = 4
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
        Me.GridColumnQty.VisibleIndex = 5
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
        Me.GridColumnTotal.VisibleIndex = 8
        Me.GridColumnTotal.Width = 68
        '
        'GridColumnDiscount
        '
        Me.GridColumnDiscount.Caption = "COMMISSION (%)"
        Me.GridColumnDiscount.FieldName = "sales_pos_discount"
        Me.GridColumnDiscount.Name = "GridColumnDiscount"
        Me.GridColumnDiscount.Visible = True
        Me.GridColumnDiscount.VisibleIndex = 6
        Me.GridColumnDiscount.Width = 97
        '
        'GridColumnSalesTax
        '
        Me.GridColumnSalesTax.Caption = "TAX(%)"
        Me.GridColumnSalesTax.FieldName = "sales_pos_vat"
        Me.GridColumnSalesTax.Name = "GridColumnSalesTax"
        Me.GridColumnSalesTax.Visible = True
        Me.GridColumnSalesTax.VisibleIndex = 7
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
        Me.GridColumnNetto.VisibleIndex = 9
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
        Me.GridColumnSalesPosRev.VisibleIndex = 10
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "STATUS"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 13
        '
        'GridColumnDueDate
        '
        Me.GridColumnDueDate.Caption = "DUE DATE"
        Me.GridColumnDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDueDate.FieldName = "sales_pos_due_date"
        Me.GridColumnDueDate.Name = "GridColumnDueDate"
        Me.GridColumnDueDate.Visible = True
        Me.GridColumnDueDate.VisibleIndex = 11
        Me.GridColumnDueDate.Width = 65
        '
        'GridColumnAge
        '
        Me.GridColumnAge.Caption = "AGE (DAY)"
        Me.GridColumnAge.FieldName = "sales_pos_age"
        Me.GridColumnAge.Name = "GridColumnAge"
        Me.GridColumnAge.Visible = True
        Me.GridColumnAge.VisibleIndex = 12
        Me.GridColumnAge.Width = 65
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sales_pos_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.OptionsColumn.ShowInCustomizationForm = False
        '
        'FormFGMissingCreditNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 494)
        Me.Controls.Add(Me.XTCFGMissingCN)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGMissingCreditNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Missing Store Credit Note"
        CType(Me.XTCFGMissingCN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCFGMissingCN.ResumeLayout(False)
        Me.XTPFGMissingStoreCreditNote.ResumeLayout(False)
        CType(Me.GCFGMissingCNStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesPOSDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGMissingCNStore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCFGMissingCN As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPFGMissingStoreCreditNote As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPFGMissingWHCreditNote As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCFGMissingCNStore As DevExpress.XtraGrid.GridControl
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
    Friend WithEvents GVFGMissingCNStore As DevExpress.XtraGrid.Views.Grid.GridView
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
End Class
