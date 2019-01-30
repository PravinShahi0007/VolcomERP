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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPurchaseMat = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMatPurchase = New DevExpress.XtraGrid.GridControl()
        Me.GVMatPurchase = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdMatPurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSamplePurcDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPayment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PCFilterDate = New DevExpress.XtraEditors.PanelControl()
        Me.PCSelAll = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BClearFilter = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BFilter = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BShowPrintPanel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPProdDemand = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlProdNumber = New DevExpress.XtraEditors.GroupControl()
        Me.GCProdDemand = New DevExpress.XtraGrid.GridControl()
        Me.GVProdDemand = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnProdDemand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdDemandNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCodeFull = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStyleOrigin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStyleCountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAging = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReturn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstimateCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProposePrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMarkUp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQuantitiy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BCreate = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPPurchaseMat.SuspendLayout()
        CType(Me.GCMatPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCFilterDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCFilterDate.SuspendLayout()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSelAll.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.LESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.XTPPurchaseMat.Controls.Add(Me.PCFilterDate)
        Me.XTPPurchaseMat.Controls.Add(Me.PanelControl2)
        Me.XTPPurchaseMat.Name = "XTPPurchaseMat"
        Me.XTPPurchaseMat.Size = New System.Drawing.Size(790, 347)
        Me.XTPPurchaseMat.Text = "List Purchase"
        '
        'GCMatPurchase
        '
        Me.GCMatPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatPurchase.Location = New System.Drawing.Point(0, 44)
        Me.GCMatPurchase.MainView = Me.GVMatPurchase
        Me.GCMatPurchase.Name = "GCMatPurchase"
        Me.GCMatPurchase.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICECheck})
        Me.GCMatPurchase.Size = New System.Drawing.Size(790, 265)
        Me.GCMatPurchase.TabIndex = 4
        Me.GCMatPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatPurchase})
        '
        'GVMatPurchase
        '
        Me.GVMatPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatPurchase, Me.GridColumn2, Me.ColSeason, Me.ColDelivery, Me.ColPONumber, Me.ColShipFrom, Me.ColShipTo, Me.ColSamplePurcDate, Me.ColRecDate, Me.ColDueDate, Me.ColPayment, Me.ColStatus, Me.ColIDStatus, Me.ColIdDelivery, Me.ColIdSeason, Me.GridColumn1})
        Me.GVMatPurchase.GridControl = Me.GCMatPurchase
        Me.GVMatPurchase.GroupCount = 2
        Me.GVMatPurchase.Name = "GVMatPurchase"
        Me.GVMatPurchase.OptionsFind.AlwaysVisible = True
        Me.GVMatPurchase.OptionsView.ShowGroupPanel = False
        Me.GVMatPurchase.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColDelivery, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdMatPurchase, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'ColIdMatPurchase
        '
        Me.ColIdMatPurchase.Caption = "ID Sample Purchase"
        Me.ColIdMatPurchase.FieldName = "id_mat_purc"
        Me.ColIdMatPurchase.Name = "ColIdMatPurchase"
        Me.ColIdMatPurchase.OptionsColumn.AllowEdit = False
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "*"
        Me.GridColumn2.ColumnEdit = Me.RICECheck
        Me.GridColumn2.FieldName = "is_check"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 62
        '
        'RICECheck
        '
        Me.RICECheck.AutoHeight = False
        Me.RICECheck.Name = "RICECheck"
        Me.RICECheck.ValueChecked = "yes"
        Me.RICECheck.ValueUnchecked = "no"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.FieldNameSortGroup = "id_season"
        Me.ColSeason.Name = "ColSeason"
        Me.ColSeason.OptionsColumn.AllowEdit = False
        Me.ColSeason.Visible = True
        Me.ColSeason.VisibleIndex = 0
        '
        'ColDelivery
        '
        Me.ColDelivery.Caption = "Delivery"
        Me.ColDelivery.FieldName = "delivery"
        Me.ColDelivery.FieldNameSortGroup = "id_delivery"
        Me.ColDelivery.Name = "ColDelivery"
        Me.ColDelivery.OptionsColumn.AllowEdit = False
        Me.ColDelivery.Visible = True
        Me.ColDelivery.VisibleIndex = 0
        '
        'ColPONumber
        '
        Me.ColPONumber.Caption = "Number"
        Me.ColPONumber.FieldName = "mat_purc_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.OptionsColumn.AllowEdit = False
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 1
        Me.ColPONumber.Width = 220
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "To"
        Me.ColShipFrom.FieldName = "comp_name_to"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.OptionsColumn.AllowEdit = False
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 2
        Me.ColShipFrom.Width = 196
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "Ship To"
        Me.ColShipTo.FieldName = "comp_name_ship_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.OptionsColumn.AllowEdit = False
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 3
        Me.ColShipTo.Width = 196
        '
        'ColSamplePurcDate
        '
        Me.ColSamplePurcDate.Caption = "Create Date"
        Me.ColSamplePurcDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColSamplePurcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColSamplePurcDate.FieldName = "mat_purc_date"
        Me.ColSamplePurcDate.Name = "ColSamplePurcDate"
        Me.ColSamplePurcDate.OptionsColumn.AllowEdit = False
        Me.ColSamplePurcDate.Visible = True
        Me.ColSamplePurcDate.VisibleIndex = 5
        Me.ColSamplePurcDate.Width = 181
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Est. Receive Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "mat_purc_lead_time"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.OptionsColumn.AllowEdit = False
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 6
        Me.ColRecDate.Width = 181
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Due Date"
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "mat_purc_top"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.OptionsColumn.AllowEdit = False
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 7
        Me.ColDueDate.Width = 199
        '
        'ColPayment
        '
        Me.ColPayment.Caption = "Payment"
        Me.ColPayment.FieldName = "payment"
        Me.ColPayment.Name = "ColPayment"
        Me.ColPayment.OptionsColumn.AllowEdit = False
        Me.ColPayment.Visible = True
        Me.ColPayment.VisibleIndex = 4
        Me.ColPayment.Width = 137
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.OptionsColumn.AllowEdit = False
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 8
        Me.ColStatus.Width = 114
        '
        'ColIDStatus
        '
        Me.ColIDStatus.Caption = "ID Status"
        Me.ColIDStatus.FieldName = "id_report_status"
        Me.ColIDStatus.Name = "ColIDStatus"
        Me.ColIDStatus.OptionsColumn.AllowEdit = False
        '
        'ColIdDelivery
        '
        Me.ColIdDelivery.Caption = "Delivery"
        Me.ColIdDelivery.FieldName = "id_delivery"
        Me.ColIdDelivery.Name = "ColIdDelivery"
        Me.ColIdDelivery.OptionsColumn.AllowEdit = False
        '
        'ColIdSeason
        '
        Me.ColIdSeason.Caption = "Season"
        Me.ColIdSeason.FieldName = "id_season"
        Me.ColIdSeason.Name = "ColIdSeason"
        Me.ColIdSeason.OptionsColumn.AllowEdit = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Revised From"
        Me.GridColumn1.FieldName = "mat_purc_rev_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 9
        Me.GridColumn1.Width = 146
        '
        'PCFilterDate
        '
        Me.PCFilterDate.Controls.Add(Me.PCSelAll)
        Me.PCFilterDate.Controls.Add(Me.BClearFilter)
        Me.PCFilterDate.Controls.Add(Me.BPrint)
        Me.PCFilterDate.Controls.Add(Me.BFilter)
        Me.PCFilterDate.Controls.Add(Me.LabelControl6)
        Me.PCFilterDate.Controls.Add(Me.LabelControl11)
        Me.PCFilterDate.Controls.Add(Me.DEEnd)
        Me.PCFilterDate.Controls.Add(Me.DEStart)
        Me.PCFilterDate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCFilterDate.Location = New System.Drawing.Point(0, 309)
        Me.PCFilterDate.Name = "PCFilterDate"
        Me.PCFilterDate.Size = New System.Drawing.Size(790, 38)
        Me.PCFilterDate.TabIndex = 6
        Me.PCFilterDate.Visible = False
        '
        'PCSelAll
        '
        Me.PCSelAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCSelAll.Controls.Add(Me.CheckEditSelAll)
        Me.PCSelAll.Dock = System.Windows.Forms.DockStyle.Right
        Me.PCSelAll.Location = New System.Drawing.Point(689, 2)
        Me.PCSelAll.Name = "PCSelAll"
        Me.PCSelAll.Size = New System.Drawing.Size(99, 34)
        Me.PCSelAll.TabIndex = 8911
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(5, 7)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(92, 19)
        Me.CheckEditSelAll.TabIndex = 102
        '
        'BClearFilter
        '
        Me.BClearFilter.Location = New System.Drawing.Point(398, 7)
        Me.BClearFilter.Name = "BClearFilter"
        Me.BClearFilter.Size = New System.Drawing.Size(73, 23)
        Me.BClearFilter.TabIndex = 8910
        Me.BClearFilter.Text = "Clear Filter"
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(477, 7)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(84, 23)
        Me.BPrint.TabIndex = 8909
        Me.BPrint.Text = "Create List"
        '
        'BFilter
        '
        Me.BFilter.Location = New System.Drawing.Point(333, 7)
        Me.BFilter.Name = "BFilter"
        Me.BFilter.Size = New System.Drawing.Size(59, 23)
        Me.BFilter.TabIndex = 8908
        Me.BFilter.Text = "Filter"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(187, 12)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl6.TabIndex = 8907
        Me.LabelControl6.Text = "-"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(11, 12)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl11.TabIndex = 8895
        Me.LabelControl11.Text = "Periode"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(197, 9)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Size = New System.Drawing.Size(130, 20)
        Me.DEEnd.TabIndex = 8906
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(53, 9)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(128, 20)
        Me.DEStart.TabIndex = 8904
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BShowPrintPanel)
        Me.PanelControl2.Controls.Add(Me.BSearch)
        Me.PanelControl2.Controls.Add(Me.LabelControl12)
        Me.PanelControl2.Controls.Add(Me.LESeason)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(790, 44)
        Me.PanelControl2.TabIndex = 5
        '
        'BShowPrintPanel
        '
        Me.BShowPrintPanel.Location = New System.Drawing.Point(279, 9)
        Me.BShowPrintPanel.Name = "BShowPrintPanel"
        Me.BShowPrintPanel.Size = New System.Drawing.Size(105, 23)
        Me.BShowPrintPanel.TabIndex = 8910
        Me.BShowPrintPanel.Text = "Show filter panel"
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(214, 9)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8904
        Me.BSearch.Text = "Search"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl12.TabIndex = 141
        Me.LabelControl12.Text = "Season"
        '
        'LESeason
        '
        Me.LESeason.Location = New System.Drawing.Point(52, 11)
        Me.LESeason.Name = "LESeason"
        Me.LESeason.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LESeason.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.LESeason.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LESeason.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.LESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESeason.Properties.NullText = ""
        Me.LESeason.Properties.ShowFooter = False
        Me.LESeason.Properties.View = Me.GridView2
        Me.LESeason.Size = New System.Drawing.Size(156, 20)
        Me.LESeason.TabIndex = 140
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id Season"
        Me.GridColumn3.FieldName = "id_season"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Season"
        Me.GridColumn4.FieldName = "season"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'XTPProdDemand
        '
        Me.XTPProdDemand.Controls.Add(Me.SplitContainerControl1)
        Me.XTPProdDemand.Name = "XTPProdDemand"
        Me.XTPProdDemand.Size = New System.Drawing.Size(790, 347)
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
        Me.SplitContainerControl1.Size = New System.Drawing.Size(790, 347)
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
        Me.GCProdDemand.Location = New System.Drawing.Point(20, 2)
        Me.GCProdDemand.MainView = Me.GVProdDemand
        Me.GCProdDemand.Name = "GCProdDemand"
        Me.GCProdDemand.Size = New System.Drawing.Size(768, 196)
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
        Me.GroupControl1.Size = New System.Drawing.Size(790, 142)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Product List"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(20, 2)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(768, 101)
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
        Me.PanelControl1.Location = New System.Drawing.Point(20, 103)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(768, 37)
        Me.PanelControl1.TabIndex = 3
        '
        'BCreate
        '
        Me.BCreate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BCreate.Enabled = False
        Me.BCreate.Location = New System.Drawing.Point(2, 2)
        Me.BCreate.Name = "BCreate"
        Me.BCreate.Size = New System.Drawing.Size(764, 33)
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
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Raw Material"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPPurchaseMat.ResumeLayout(False)
        CType(Me.GCMatPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCFilterDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCFilterDate.ResumeLayout(False)
        Me.PCFilterDate.PerformLayout()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSelAll.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.LESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BShowPrintPanel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCFilterDate As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCSelAll As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BClearFilter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BFilter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICECheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
