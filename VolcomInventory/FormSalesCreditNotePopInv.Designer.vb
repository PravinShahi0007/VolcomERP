<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesCreditNotePopInv
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
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesStore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDiscount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesTax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNetto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesPosRev = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAge = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlChoose = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.SCCInvoice = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlSummary = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControlDetail = New DevExpress.XtraEditors.GroupControl()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOLStoreNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDELNo = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GVSalesPOSDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSalesPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlChoose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlChoose.SuspendLayout()
        CType(Me.SCCInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCInvoice.SuspendLayout()
        CType(Me.GroupControlSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSummary.SuspendLayout()
        CType(Me.GroupControlDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlDetail.SuspendLayout()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GCSalesPOS.Location = New System.Drawing.Point(20, 2)
        Me.GCSalesPOS.MainView = Me.GVSalesPOS
        Me.GCSalesPOS.Name = "GCSalesPOS"
        Me.GCSalesPOS.Size = New System.Drawing.Size(730, 241)
        Me.GCSalesPOS.TabIndex = 1
        Me.GCSalesPOS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesPOS, Me.GVSalesPOSDet})
        '
        'GVSalesPOS
        '
        Me.GVSalesPOS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnStore, Me.GridColumnSalesPOSDate, Me.GridColumn1, Me.GridColumnSalesStore, Me.GridColumnType, Me.GridColumnQty, Me.GridColumnTotal, Me.GridColumnDiscount, Me.GridColumnSalesTax, Me.GridColumnNetto, Me.GridColumnSalesPosRev, Me.GridColumnDueDate, Me.GridColumnStatus, Me.GridColumnAge, Me.GridColumnRemark, Me.GridColumnOLStoreNo, Me.GridColumnDELNo})
        Me.GVSalesPOS.GridControl = Me.GCSalesPOS
        Me.GVSalesPOS.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.GVSalesPOS.Name = "GVSalesPOS"
        Me.GVSalesPOS.OptionsBehavior.ReadOnly = True
        Me.GVSalesPOS.OptionsFind.AlwaysVisible = True
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
        Me.GridColumnSalesPOSDate.VisibleIndex = 3
        Me.GridColumnSalesPOSDate.Width = 84
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PERIOD"
        Me.GridColumn1.FieldName = "sales_pos_period"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        Me.GridColumn1.Width = 68
        '
        'GridColumnSalesStore
        '
        Me.GridColumnSalesStore.Caption = "STORE"
        Me.GridColumnSalesStore.FieldName = "store_name_from"
        Me.GridColumnSalesStore.Name = "GridColumnSalesStore"
        Me.GridColumnSalesStore.Visible = True
        Me.GridColumnSalesStore.VisibleIndex = 5
        Me.GridColumnSalesStore.Width = 68
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "TYPE"
        Me.GridColumnType.FieldName = "so_type"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.Visible = True
        Me.GridColumnType.VisibleIndex = 6
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
        Me.GridColumnQty.VisibleIndex = 7
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
        Me.GridColumnTotal.VisibleIndex = 10
        Me.GridColumnTotal.Width = 68
        '
        'GridColumnDiscount
        '
        Me.GridColumnDiscount.Caption = "COMMISSION (%)"
        Me.GridColumnDiscount.FieldName = "sales_pos_discount"
        Me.GridColumnDiscount.Name = "GridColumnDiscount"
        Me.GridColumnDiscount.Visible = True
        Me.GridColumnDiscount.VisibleIndex = 8
        Me.GridColumnDiscount.Width = 97
        '
        'GridColumnSalesTax
        '
        Me.GridColumnSalesTax.Caption = "TAX(%)"
        Me.GridColumnSalesTax.FieldName = "sales_pos_vat"
        Me.GridColumnSalesTax.Name = "GridColumnSalesTax"
        Me.GridColumnSalesTax.Visible = True
        Me.GridColumnSalesTax.VisibleIndex = 9
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
        Me.GridColumnNetto.VisibleIndex = 11
        Me.GridColumnNetto.Width = 92
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
        Me.GridColumnSalesPosRev.VisibleIndex = 12
        Me.GridColumnSalesPosRev.Width = 85
        '
        'GridColumnDueDate
        '
        Me.GridColumnDueDate.Caption = "DUE DATE"
        Me.GridColumnDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDueDate.FieldName = "sales_pos_due_date"
        Me.GridColumnDueDate.Name = "GridColumnDueDate"
        Me.GridColumnDueDate.Visible = True
        Me.GridColumnDueDate.VisibleIndex = 13
        Me.GridColumnDueDate.Width = 65
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "STATUS"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
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
        'PanelControlChoose
        '
        Me.PanelControlChoose.Controls.Add(Me.BtnCancel)
        Me.PanelControlChoose.Controls.Add(Me.BtnChoose)
        Me.PanelControlChoose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlChoose.Location = New System.Drawing.Point(0, 432)
        Me.PanelControlChoose.LookAndFeel.SkinName = "Blue"
        Me.PanelControlChoose.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlChoose.Name = "PanelControlChoose"
        Me.PanelControlChoose.Size = New System.Drawing.Size(752, 37)
        Me.PanelControlChoose.TabIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(600, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 33)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(675, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 33)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Save"
        '
        'SCCInvoice
        '
        Me.SCCInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCInvoice.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.SCCInvoice.Horizontal = False
        Me.SCCInvoice.Location = New System.Drawing.Point(0, 0)
        Me.SCCInvoice.Name = "SCCInvoice"
        Me.SCCInvoice.Panel1.Controls.Add(Me.GroupControlSummary)
        Me.SCCInvoice.Panel1.Text = "Panel1"
        Me.SCCInvoice.Panel2.Controls.Add(Me.GroupControlDetail)
        Me.SCCInvoice.Panel2.Text = "Panel2"
        Me.SCCInvoice.Size = New System.Drawing.Size(752, 432)
        Me.SCCInvoice.SplitterPosition = 182
        Me.SCCInvoice.TabIndex = 1
        Me.SCCInvoice.Text = "SplitContainerControl1"
        '
        'GroupControlSummary
        '
        Me.GroupControlSummary.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlSummary.Controls.Add(Me.GCSalesPOS)
        Me.GroupControlSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSummary.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSummary.Name = "GroupControlSummary"
        Me.GroupControlSummary.Size = New System.Drawing.Size(752, 245)
        Me.GroupControlSummary.TabIndex = 0
        Me.GroupControlSummary.Text = "Invoice"
        '
        'GroupControlDetail
        '
        Me.GroupControlDetail.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlDetail.Controls.Add(Me.GCItemList)
        Me.GroupControlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlDetail.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlDetail.Name = "GroupControlDetail"
        Me.GroupControlDetail.Size = New System.Drawing.Size(752, 182)
        Me.GroupControlDetail.TabIndex = 0
        Me.GroupControlDetail.Text = "Detail"
        '
        'GCItemList
        '
        Me.GCItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemList.Location = New System.Drawing.Point(20, 2)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(730, 178)
        Me.GCItemList.TabIndex = 3
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.ReadOnly = True
        Me.GVItemList.OptionsCustomization.AllowGroup = False
        Me.GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItemList.OptionsView.ShowFooter = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "No"
        Me.GridColumn4.FieldName = "no"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 43
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Code"
        Me.GridColumn5.FieldName = "code"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 72
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Description"
        Me.GridColumn6.FieldName = "name"
        Me.GridColumn6.FieldNameSortGroup = "id_design"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 142
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.Caption = "Size"
        Me.GridColumn7.FieldName = "size"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 4
        Me.GridColumn7.Width = 56
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "UOM"
        Me.GridColumn8.FieldName = "uom"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Width = 71
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.Caption = "Qty"
        Me.GridColumn9.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn9.DisplayFormat.FormatString = "F2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "sales_pos_det_qty"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_det_qty", "{0:f2}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 121
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.Caption = "Amount"
        Me.GridColumn10.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "sales_pos_det_amount"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_det_amount", "{0:n2}")})
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        Me.GridColumn10.Width = 106
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.Caption = "Price"
        Me.GridColumn11.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "design_price_retail"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 6
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Price Type"
        Me.GridColumn12.FieldName = "design_price_type"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 5
        Me.GridColumn12.Width = 71
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.Caption = "Price Del"
        Me.GridColumn13.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "design_price"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Width = 117
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Remark"
        Me.GridColumn14.FieldName = "sales_pos_det_note"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Width = 255
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "id design"
        Me.GridColumn15.FieldName = "id_design"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Id Product"
        Me.GridColumn16.FieldName = "id_product"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn16.Width = 92
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Id Sample"
        Me.GridColumn17.FieldName = "id_sample"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn17.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Id Design Price Del"
        Me.GridColumn18.FieldName = "id_design_price"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Width = 84
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Id Sales POS Det"
        Me.GridColumn19.FieldName = "id_sales_pos_det"
        Me.GridColumn19.Name = "GridColumn19"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Color"
        Me.GridColumn20.FieldName = "color"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 3
        Me.GridColumn20.Width = 71
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Id Design Price"
        Me.GridColumn21.FieldName = "id_design_price_retail"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumnOLStoreNo
        '
        Me.GridColumnOLStoreNo.Caption = "OL STORE NO"
        Me.GridColumnOLStoreNo.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnOLStoreNo.Name = "GridColumnOLStoreNo"
        Me.GridColumnOLStoreNo.Visible = True
        Me.GridColumnOLStoreNo.VisibleIndex = 1
        '
        'GridColumnDELNo
        '
        Me.GridColumnDELNo.Caption = "DEL NO"
        Me.GridColumnDELNo.FieldName = "pl_sales_order_del_number"
        Me.GridColumnDELNo.Name = "GridColumnDELNo"
        Me.GridColumnDELNo.Visible = True
        Me.GridColumnDELNo.VisibleIndex = 2
        '
        'FormSalesCreditNotePopInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 469)
        Me.Controls.Add(Me.SCCInvoice)
        Me.Controls.Add(Me.PanelControlChoose)
        Me.LookAndFeel.SkinName = "Black"
        Me.MinimizeBox = False
        Me.Name = "FormSalesCreditNotePopInv"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Invoice List"
        CType(Me.GVSalesPOSDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSalesPOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesPOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlChoose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlChoose.ResumeLayout(False)
        CType(Me.SCCInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCInvoice.ResumeLayout(False)
        CType(Me.GroupControlSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSummary.ResumeLayout(False)
        CType(Me.GroupControlDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlDetail.ResumeLayout(False)
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlChoose As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SCCInvoice As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlSummary As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlDetail As DevExpress.XtraEditors.GroupControl
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
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOLStoreNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDELNo As DevExpress.XtraGrid.Columns.GridColumn
End Class
