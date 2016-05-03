<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatPurchase
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl
        Me.XTPPurchaseMat = New DevExpress.XtraTab.XtraTabPage
        Me.GCMatPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVMatPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdMatPurchase = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSamplePurcDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPayment = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XTPProdDemand = New DevExpress.XtraTab.XtraTabPage
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlProdNumber = New DevExpress.XtraEditors.GroupControl
        Me.GCProdDemand = New DevExpress.XtraGrid.GridControl
        Me.GVProdDemand = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnProdDemand = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnProdDemandNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnCodeFull = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStyleOrigin = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStyleCountry = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAging = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReturn = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnEstimateCost = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnProposePrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMarkUp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQuantitiy = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotalCost = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotalAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BCreate = New DevExpress.XtraEditors.SimpleButton
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPPurchaseMat.SuspendLayout()
        CType(Me.GCMatPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPProdDemand.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControlProdNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlProdNumber.SuspendLayout()
        CType(Me.GCProdDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPPurchaseMat
        Me.XtraTabControl1.Size = New System.Drawing.Size(796, 375)
        Me.XtraTabControl1.TabIndex = 7
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPurchaseMat, Me.XTPProdDemand})
        '
        'XTPPurchaseMat
        '
        Me.XTPPurchaseMat.Controls.Add(Me.GCMatPurchase)
        Me.XTPPurchaseMat.Name = "XTPPurchaseMat"
        Me.XTPPurchaseMat.Size = New System.Drawing.Size(790, 349)
        Me.XTPPurchaseMat.Text = "List Purchase"
        '
        'GCMatPurchase
        '
        Me.GCMatPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCMatPurchase.MainView = Me.GVMatPurchase
        Me.GCMatPurchase.Name = "GCMatPurchase"
        Me.GCMatPurchase.Size = New System.Drawing.Size(790, 349)
        Me.GCMatPurchase.TabIndex = 4
        Me.GCMatPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatPurchase})
        '
        'GVMatPurchase
        '
        Me.GVMatPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatPurchase, Me.ColSeason, Me.ColDelivery, Me.ColPONumber, Me.ColShipFrom, Me.ColShipTo, Me.ColSamplePurcDate, Me.ColRecDate, Me.ColDueDate, Me.ColPayment, Me.ColStatus, Me.ColIDStatus, Me.ColIdDelivery, Me.ColIdSeason, Me.GridColumn1})
        Me.GVMatPurchase.GridControl = Me.GCMatPurchase
        Me.GVMatPurchase.GroupCount = 2
        Me.GVMatPurchase.Name = "GVMatPurchase"
        Me.GVMatPurchase.OptionsBehavior.Editable = False
        Me.GVMatPurchase.OptionsFind.AlwaysVisible = True
        Me.GVMatPurchase.OptionsView.ShowGroupPanel = False
        Me.GVMatPurchase.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColDelivery, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdMatPurchase, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'ColIdMatPurchase
        '
        Me.ColIdMatPurchase.Caption = "ID Sample Purchase"
        Me.ColIdMatPurchase.FieldName = "id_mat_purc"
        Me.ColIdMatPurchase.Name = "ColIdMatPurchase"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.FieldNameSortGroup = "id_season"
        Me.ColSeason.Name = "ColSeason"
        Me.ColSeason.Visible = True
        Me.ColSeason.VisibleIndex = 0
        '
        'ColDelivery
        '
        Me.ColDelivery.Caption = "Delivery"
        Me.ColDelivery.FieldName = "delivery"
        Me.ColDelivery.FieldNameSortGroup = "id_delivery"
        Me.ColDelivery.Name = "ColDelivery"
        Me.ColDelivery.Visible = True
        Me.ColDelivery.VisibleIndex = 0
        '
        'ColPONumber
        '
        Me.ColPONumber.Caption = "Number"
        Me.ColPONumber.FieldName = "mat_purc_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 0
        Me.ColPONumber.Width = 120
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "To"
        Me.ColShipFrom.FieldName = "comp_name_to"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 1
        Me.ColShipFrom.Width = 107
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "Ship To"
        Me.ColShipTo.FieldName = "comp_name_ship_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 2
        Me.ColShipTo.Width = 107
        '
        'ColSamplePurcDate
        '
        Me.ColSamplePurcDate.Caption = "Create Date"
        Me.ColSamplePurcDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColSamplePurcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColSamplePurcDate.FieldName = "mat_purc_date"
        Me.ColSamplePurcDate.Name = "ColSamplePurcDate"
        Me.ColSamplePurcDate.Visible = True
        Me.ColSamplePurcDate.VisibleIndex = 4
        Me.ColSamplePurcDate.Width = 99
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Est. Receive Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "mat_purc_lead_time"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 5
        Me.ColRecDate.Width = 99
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Due Date"
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "mat_purc_top"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 6
        Me.ColDueDate.Width = 109
        '
        'ColPayment
        '
        Me.ColPayment.Caption = "Payment"
        Me.ColPayment.FieldName = "payment"
        Me.ColPayment.Name = "ColPayment"
        Me.ColPayment.Visible = True
        Me.ColPayment.VisibleIndex = 3
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 7
        Me.ColStatus.Width = 62
        '
        'ColIDStatus
        '
        Me.ColIDStatus.Caption = "ID Status"
        Me.ColIDStatus.FieldName = "id_report_status"
        Me.ColIDStatus.Name = "ColIDStatus"
        '
        'ColIdDelivery
        '
        Me.ColIdDelivery.Caption = "Delivery"
        Me.ColIdDelivery.FieldName = "id_delivery"
        Me.ColIdDelivery.Name = "ColIdDelivery"
        '
        'ColIdSeason
        '
        Me.ColIdSeason.Caption = "Season"
        Me.ColIdSeason.FieldName = "id_season"
        Me.ColIdSeason.Name = "ColIdSeason"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Revised From"
        Me.GridColumn1.FieldName = "mat_purc_rev_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 8
        '
        'XTPProdDemand
        '
        Me.XTPProdDemand.Controls.Add(Me.SplitContainerControl1)
        Me.XTPProdDemand.Name = "XTPProdDemand"
        Me.XTPProdDemand.Size = New System.Drawing.Size(790, 349)
        Me.XTPProdDemand.Text = "Generate From PD"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControlProdNumber)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(790, 349)
        Me.SplitContainerControl1.SplitterPosition = 200
        Me.SplitContainerControl1.TabIndex = 4
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControlProdNumber
        '
        Me.GroupControlProdNumber.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlProdNumber.Controls.Add(Me.GCProdDemand)
        Me.GroupControlProdNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlProdNumber.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlProdNumber.Name = "GroupControlProdNumber"
        Me.GroupControlProdNumber.Size = New System.Drawing.Size(790, 200)
        Me.GroupControlProdNumber.TabIndex = 0
        Me.GroupControlProdNumber.Text = "PD Number"
        '
        'GCProdDemand
        '
        Me.GCProdDemand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdDemand.Location = New System.Drawing.Point(22, 2)
        Me.GCProdDemand.MainView = Me.GVProdDemand
        Me.GCProdDemand.Name = "GCProdDemand"
        Me.GCProdDemand.Size = New System.Drawing.Size(766, 196)
        Me.GCProdDemand.TabIndex = 0
        Me.GCProdDemand.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdDemand})
        '
        'GVProdDemand
        '
        Me.GVProdDemand.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnProdDemand, Me.GridColumnProdDemandNumber, Me.GridColumnSeason, Me.GridColumnIdSeason, Me.ColIdReportStatus, Me.ColReportStatus})
        Me.GVProdDemand.GridControl = Me.GCProdDemand
        Me.GVProdDemand.Name = "GVProdDemand"
        Me.GVProdDemand.OptionsBehavior.Editable = False
        Me.GVProdDemand.OptionsFind.AlwaysVisible = True
        Me.GVProdDemand.OptionsView.ShowGroupPanel = False
        '
        'GridColumnProdDemand
        '
        Me.GridColumnProdDemand.Caption = "ID"
        Me.GridColumnProdDemand.FieldName = "id_prod_demand"
        Me.GridColumnProdDemand.Name = "GridColumnProdDemand"
        '
        'GridColumnProdDemandNumber
        '
        Me.GridColumnProdDemandNumber.Caption = "Production Demand Number"
        Me.GridColumnProdDemandNumber.FieldName = "prod_demand_number"
        Me.GridColumnProdDemandNumber.Name = "GridColumnProdDemandNumber"
        Me.GridColumnProdDemandNumber.Visible = True
        Me.GridColumnProdDemandNumber.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'ColIdReportStatus
        '
        Me.ColIdReportStatus.Caption = "Id Status"
        Me.ColIdReportStatus.FieldName = "id_report_status"
        Me.ColIdReportStatus.Name = "ColIdReportStatus"
        '
        'ColReportStatus
        '
        Me.ColReportStatus.Caption = "Status"
        Me.ColReportStatus.FieldName = "report_status"
        Me.ColReportStatus.Name = "ColReportStatus"
        Me.ColReportStatus.Visible = True
        Me.ColReportStatus.VisibleIndex = 2
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCProduct)
        Me.GroupControl1.Controls.Add(Me.PanelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(790, 144)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Product List"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(22, 2)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(766, 103)
        Me.GCProduct.TabIndex = 4
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCodeFull, Me.GridColumnDelivery, Me.GridColumnStyleOrigin, Me.GridColumnStyleCountry, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnAging, Me.GridColumnReturn, Me.GridColumnEstimateCost, Me.GridColumnProposePrice, Me.GridColumnMarkUp, Me.GridColumnQuantitiy, Me.GridColumnTotalCost, Me.GridColumnTotalAmount, Me.GridColumnDesign, Me.GridColumnCategory})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_demand_product_qty", Me.GridColumnQuantitiy, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", Me.GridColumnTotalCost, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_amount", Me.GridColumnTotalAmount, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "mark_up", Me.GridColumnMarkUp, "Sub Total")})
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.Editable = False
        Me.GVProduct.OptionsFind.AlwaysVisible = True
        Me.GVProduct.OptionsView.ShowFooter = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCodeFull
        '
        Me.GridColumnCodeFull.Caption = "Code"
        Me.GridColumnCodeFull.FieldName = "product_full_code"
        Me.GridColumnCodeFull.Name = "GridColumnCodeFull"
        Me.GridColumnCodeFull.Visible = True
        Me.GridColumnCodeFull.VisibleIndex = 0
        '
        'GridColumnDelivery
        '
        Me.GridColumnDelivery.Caption = "Delivery"
        Me.GridColumnDelivery.FieldName = "delivery"
        Me.GridColumnDelivery.Name = "GridColumnDelivery"
        Me.GridColumnDelivery.Visible = True
        Me.GridColumnDelivery.VisibleIndex = 1
        '
        'GridColumnStyleOrigin
        '
        Me.GridColumnStyleOrigin.Caption = "Style Origin"
        Me.GridColumnStyleOrigin.FieldName = "season_orign_display"
        Me.GridColumnStyleOrigin.Name = "GridColumnStyleOrigin"
        Me.GridColumnStyleOrigin.Visible = True
        Me.GridColumnStyleOrigin.VisibleIndex = 2
        '
        'GridColumnStyleCountry
        '
        Me.GridColumnStyleCountry.Caption = "Style Country"
        Me.GridColumnStyleCountry.FieldName = "country_orign"
        Me.GridColumnStyleCountry.Name = "GridColumnStyleCountry"
        Me.GridColumnStyleCountry.Visible = True
        Me.GridColumnStyleCountry.VisibleIndex = 3
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "Color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 4
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "Size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 5
        '
        'GridColumnAging
        '
        Me.GridColumnAging.Caption = "Aging (day)"
        Me.GridColumnAging.FieldName = "lifetime"
        Me.GridColumnAging.Name = "GridColumnAging"
        Me.GridColumnAging.Visible = True
        Me.GridColumnAging.VisibleIndex = 6
        '
        'GridColumnReturn
        '
        Me.GridColumnReturn.Caption = "Return"
        Me.GridColumnReturn.FieldName = "return_date"
        Me.GridColumnReturn.Name = "GridColumnReturn"
        Me.GridColumnReturn.Visible = True
        Me.GridColumnReturn.VisibleIndex = 7
        '
        'GridColumnEstimateCost
        '
        Me.GridColumnEstimateCost.Caption = "Estimate Cost"
        Me.GridColumnEstimateCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnEstimateCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnEstimateCost.FieldName = "estimate_cost"
        Me.GridColumnEstimateCost.Name = "GridColumnEstimateCost"
        Me.GridColumnEstimateCost.Visible = True
        Me.GridColumnEstimateCost.VisibleIndex = 8
        '
        'GridColumnProposePrice
        '
        Me.GridColumnProposePrice.Caption = "Propose Price"
        Me.GridColumnProposePrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnProposePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnProposePrice.FieldName = "prod_demand_design_propose_price"
        Me.GridColumnProposePrice.Name = "GridColumnProposePrice"
        Me.GridColumnProposePrice.Visible = True
        Me.GridColumnProposePrice.VisibleIndex = 9
        '
        'GridColumnMarkUp
        '
        Me.GridColumnMarkUp.Caption = "Mark Up"
        Me.GridColumnMarkUp.FieldName = "mark_up"
        Me.GridColumnMarkUp.Name = "GridColumnMarkUp"
        Me.GridColumnMarkUp.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "mark_up", "Total")})
        Me.GridColumnMarkUp.Visible = True
        Me.GridColumnMarkUp.VisibleIndex = 10
        '
        'GridColumnQuantitiy
        '
        Me.GridColumnQuantitiy.Caption = "Quantitiy"
        Me.GridColumnQuantitiy.DisplayFormat.FormatString = "N2"
        Me.GridColumnQuantitiy.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQuantitiy.FieldName = "prod_demand_product_qty"
        Me.GridColumnQuantitiy.Name = "GridColumnQuantitiy"
        Me.GridColumnQuantitiy.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_demand_product_qty", "{0:N2}")})
        Me.GridColumnQuantitiy.Visible = True
        Me.GridColumnQuantitiy.VisibleIndex = 11
        '
        'GridColumnTotalCost
        '
        Me.GridColumnTotalCost.Caption = "Total Cost"
        Me.GridColumnTotalCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalCost.FieldName = "total_cost"
        Me.GridColumnTotalCost.Name = "GridColumnTotalCost"
        Me.GridColumnTotalCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:N2}")})
        Me.GridColumnTotalCost.Visible = True
        Me.GridColumnTotalCost.VisibleIndex = 12
        '
        'GridColumnTotalAmount
        '
        Me.GridColumnTotalAmount.Caption = "Total Amount"
        Me.GridColumnTotalAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalAmount.FieldName = "total_amount"
        Me.GridColumnTotalAmount.Name = "GridColumnTotalAmount"
        Me.GridColumnTotalAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_amount", "{0:N2}")})
        Me.GridColumnTotalAmount.Visible = True
        Me.GridColumnTotalAmount.VisibleIndex = 13
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 14
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "category"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 15
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCreate)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(22, 105)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(766, 37)
        Me.PanelControl1.TabIndex = 3
        '
        'BCreate
        '
        Me.BCreate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BCreate.Enabled = False
        Me.BCreate.Location = New System.Drawing.Point(2, 2)
        Me.BCreate.Name = "BCreate"
        Me.BCreate.Size = New System.Drawing.Size(762, 33)
        Me.BCreate.TabIndex = 2
        Me.BCreate.Text = "Generate PO"
        '
        'FormMatPurchase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 375)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatPurchase"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Raw Material"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPPurchaseMat.ResumeLayout(False)
        CType(Me.GCMatPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPProdDemand.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControlProdNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlProdNumber.ResumeLayout(False)
        CType(Me.GCProdDemand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdDemand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPurchaseMat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMatPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMatPurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPProdDemand As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlProdNumber As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProdDemand As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdDemand As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnProdDemand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdDemandNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodeFull As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStyleOrigin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStyleCountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAging As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReturn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstimateCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProposePrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMarkUp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQuantitiy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCreate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
