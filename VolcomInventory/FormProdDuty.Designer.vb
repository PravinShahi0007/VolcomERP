<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProdDuty
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
        Me.GCProd = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVProd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridColumnVendorCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIdReportStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnProdDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPOType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTerm = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDesignCOP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIdPO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIdDelivery = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnProdNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnColor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnOrderQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFOB = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBDueDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBPRDueDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDutyP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSDP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSVATP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSRP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSTP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnEst = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnEstRoyS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnEstRoyD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnEstRoySA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnEstRoyDA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFinal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFinalRoyS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFinalRoyD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFinalRoySA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFinalRoyDA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiffPrice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiffRoyS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiffRoyD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiffAmoRoyS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiffAmoRoyD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDutyPaid = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICEDutyPaid = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BandedGridColumnPRProposed = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICEPRProposed = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RIPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView14 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEDesignStockStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GVSLEDesgSearch = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCodeSearch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEDutyPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPRProposed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCProd
        '
        Me.GCProd.ContextMenuStrip = Me.ViewMenu
        Me.GCProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProd.Location = New System.Drawing.Point(0, 38)
        Me.GCProd.MainView = Me.GVProd
        Me.GCProd.Name = "GCProd"
        Me.GCProd.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIPictureEdit, Me.RICEPRProposed, Me.RICEDutyPaid})
        Me.GCProd.Size = New System.Drawing.Size(889, 294)
        Me.GCProd.TabIndex = 4
        Me.GCProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProd})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMEdit})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(140, 26)
        '
        'SMEdit
        '
        Me.SMEdit.Name = "SMEdit"
        Me.SMEdit.Size = New System.Drawing.Size(139, 22)
        Me.SMEdit.Text = "Edit Variable"
        '
        'GVProd
        '
        Me.GVProd.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.gridBand5, Me.gridBand6, Me.gridBand7})
        Me.GVProd.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnVendorCode, Me.GridColumnCompName, Me.GridColumnProdNo, Me.GridColumnReportStatus, Me.GridColumnIdReportStatus, Me.GridColumnProdDate, Me.GridColumnPOType, Me.GridColumnTerm, Me.GridColumnDesignCOP, Me.GridColumnDesign, Me.BandedGridColumnColor, Me.BandedGridColumnFOB, Me.BandedGridColumnPIBNo, Me.BandedGridColumnPIBDate, Me.BandedGridColumnPIBDueDate, Me.BandedGridColumnPIBPRDueDate, Me.BandedGridColumnDutyPaid, Me.BandedGridColumnPRProposed, Me.BandedGridColumnDutyP, Me.BandedGridColumnSDP, Me.BandedGridColumnSVATP, Me.BandedGridColumnSRP, Me.BandedGridColumnSTP, Me.GridColumnOrderQty, Me.BandedGridColumn1, Me.BandedGridColumnEst, Me.BandedGridColumnEstRoyS, Me.BandedGridColumnEstRoyD, Me.BandedGridColumnEstRoySA, Me.BandedGridColumnEstRoyDA, Me.BandedGridColumnFinal, Me.BandedGridColumnFinalRoyS, Me.BandedGridColumnFinalRoyD, Me.BandedGridColumnFinalRoySA, Me.BandedGridColumnFinalRoyDA, Me.BandedGridColumnDiffPrice, Me.BandedGridColumnDiffRoyS, Me.BandedGridColumnDiffRoyD, Me.BandedGridColumnDiffAmoRoyS, Me.BandedGridColumnDiffAmoRoyD, Me.GridColumnCode, Me.GridColumnIdPO, Me.GridColumnIdSeason, Me.GridColumnSeason, Me.GridColumnIdDelivery, Me.GridColumnDelivery})
        Me.GVProd.GridControl = Me.GCProd
        Me.GVProd.GroupCount = 2
        Me.GVProd.Name = "GVProd"
        Me.GVProd.OptionsBehavior.Editable = False
        Me.GVProd.OptionsFind.AlwaysVisible = True
        Me.GVProd.OptionsView.ColumnAutoWidth = False
        Me.GVProd.OptionsView.ShowGroupPanel = False
        Me.GVProd.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDelivery, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdPO, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnVendorCode
        '
        Me.GridColumnVendorCode.Caption = "Vendor Code"
        Me.GridColumnVendorCode.FieldName = "comp_number"
        Me.GridColumnVendorCode.Name = "GridColumnVendorCode"
        Me.GridColumnVendorCode.Visible = True
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Vendor"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.Width = 79
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Width = 106
        '
        'GridColumnIdReportStatus
        '
        Me.GridColumnIdReportStatus.Caption = "Id Report Status"
        Me.GridColumnIdReportStatus.FieldName = "id_report_status"
        Me.GridColumnIdReportStatus.Name = "GridColumnIdReportStatus"
        '
        'GridColumnProdDate
        '
        Me.GridColumnProdDate.Caption = "Date"
        Me.GridColumnProdDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnProdDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnProdDate.FieldName = "prod_order_date"
        Me.GridColumnProdDate.Name = "GridColumnProdDate"
        Me.GridColumnProdDate.Width = 78
        '
        'GridColumnPOType
        '
        Me.GridColumnPOType.Caption = "PO Type"
        Me.GridColumnPOType.FieldName = "po_type"
        Me.GridColumnPOType.Name = "GridColumnPOType"
        Me.GridColumnPOType.Width = 78
        '
        'GridColumnTerm
        '
        Me.GridColumnTerm.Caption = "Term"
        Me.GridColumnTerm.FieldName = "term_production"
        Me.GridColumnTerm.Name = "GridColumnTerm"
        Me.GridColumnTerm.Width = 78
        '
        'GridColumnDesignCOP
        '
        Me.GridColumnDesignCOP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDesignCOP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDesignCOP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDesignCOP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDesignCOP.Caption = "Cost Final"
        Me.GridColumnDesignCOP.DisplayFormat.FormatString = "N2"
        Me.GridColumnDesignCOP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDesignCOP.FieldName = "design_cop"
        Me.GridColumnDesignCOP.Name = "GridColumnDesignCOP"
        '
        'GridColumnIdPO
        '
        Me.GridColumnIdPO.Caption = "ID PO"
        Me.GridColumnIdPO.FieldName = "id_prod_order"
        Me.GridColumnIdPO.Name = "GridColumnIdPO"
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        '
        'GridColumnIdDelivery
        '
        Me.GridColumnIdDelivery.Caption = "Delivery"
        Me.GridColumnIdDelivery.FieldName = "id_delivery"
        Me.GridColumnIdDelivery.Name = "GridColumnIdDelivery"
        '
        'GridColumnDelivery
        '
        Me.GridColumnDelivery.Caption = "Delivery"
        Me.GridColumnDelivery.FieldName = "delivery"
        Me.GridColumnDelivery.FieldNameSortGroup = "id_delivery"
        Me.GridColumnDelivery.Name = "GridColumnDelivery"
        Me.GridColumnDelivery.Visible = True
        '
        'GridColumnProdNo
        '
        Me.GridColumnProdNo.Caption = "PO #"
        Me.GridColumnProdNo.FieldName = "prod_order_number"
        Me.GridColumnProdNo.Name = "GridColumnProdNo"
        Me.GridColumnProdNo.Visible = True
        Me.GridColumnProdNo.Width = 74
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Design Code"
        Me.GridColumnCode.FieldName = "design_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Width = 78
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Style"
        Me.GridColumnDesign.FieldName = "design_display_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.Width = 121
        '
        'BandedGridColumnColor
        '
        Me.BandedGridColumnColor.Caption = "Color"
        Me.BandedGridColumnColor.FieldName = "color"
        Me.BandedGridColumnColor.Name = "BandedGridColumnColor"
        Me.BandedGridColumnColor.Visible = True
        '
        'GridColumnOrderQty
        '
        Me.GridColumnOrderQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOrderQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrderQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOrderQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrderQty.Caption = "Order Qty"
        Me.GridColumnOrderQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnOrderQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOrderQty.FieldName = "qty_order"
        Me.GridColumnOrderQty.Name = "GridColumnOrderQty"
        Me.GridColumnOrderQty.Visible = True
        Me.GridColumnOrderQty.Width = 89
        '
        'BandedGridColumnFOB
        '
        Me.BandedGridColumnFOB.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFOB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFOB.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFOB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFOB.Caption = "FOB"
        Me.BandedGridColumnFOB.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFOB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFOB.FieldName = "FOB"
        Me.BandedGridColumnFOB.Name = "BandedGridColumnFOB"
        Me.BandedGridColumnFOB.Visible = True
        '
        'BandedGridColumnPIBNo
        '
        Me.BandedGridColumnPIBNo.Caption = "PIB#"
        Me.BandedGridColumnPIBNo.FieldName = "pib_no"
        Me.BandedGridColumnPIBNo.Name = "BandedGridColumnPIBNo"
        Me.BandedGridColumnPIBNo.Visible = True
        Me.BandedGridColumnPIBNo.Width = 85
        '
        'BandedGridColumnPIBDate
        '
        Me.BandedGridColumnPIBDate.Caption = "PIB Date"
        Me.BandedGridColumnPIBDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnPIBDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnPIBDate.FieldName = "pib_date"
        Me.BandedGridColumnPIBDate.Name = "BandedGridColumnPIBDate"
        Me.BandedGridColumnPIBDate.Visible = True
        Me.BandedGridColumnPIBDate.Width = 85
        '
        'BandedGridColumnPIBDueDate
        '
        Me.BandedGridColumnPIBDueDate.Caption = "PIB Due Date"
        Me.BandedGridColumnPIBDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnPIBDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnPIBDueDate.FieldName = "pib_due_date"
        Me.BandedGridColumnPIBDueDate.Name = "BandedGridColumnPIBDueDate"
        Me.BandedGridColumnPIBDueDate.Visible = True
        Me.BandedGridColumnPIBDueDate.Width = 85
        '
        'BandedGridColumnPIBPRDueDate
        '
        Me.BandedGridColumnPIBPRDueDate.Caption = "PIB PR Due Date"
        Me.BandedGridColumnPIBPRDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnPIBPRDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnPIBPRDueDate.FieldName = "pib_pr_due_date"
        Me.BandedGridColumnPIBPRDueDate.Name = "BandedGridColumnPIBPRDueDate"
        Me.BandedGridColumnPIBPRDueDate.Visible = True
        Me.BandedGridColumnPIBPRDueDate.Width = 102
        '
        'BandedGridColumnDutyP
        '
        Me.BandedGridColumnDutyP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDutyP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnDutyP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDutyP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnDutyP.Caption = "Duty %"
        Me.BandedGridColumnDutyP.FieldName = "duty_percent"
        Me.BandedGridColumnDutyP.Name = "BandedGridColumnDutyP"
        Me.BandedGridColumnDutyP.Visible = True
        Me.BandedGridColumnDutyP.Width = 81
        '
        'BandedGridColumnSDP
        '
        Me.BandedGridColumnSDP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnSDP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnSDP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnSDP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnSDP.Caption = "Store Discount %"
        Me.BandedGridColumnSDP.FieldName = "store_disc"
        Me.BandedGridColumnSDP.Name = "BandedGridColumnSDP"
        Me.BandedGridColumnSDP.Visible = True
        Me.BandedGridColumnSDP.Width = 99
        '
        'BandedGridColumnSVATP
        '
        Me.BandedGridColumnSVATP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnSVATP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnSVATP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnSVATP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnSVATP.Caption = "Sales VAT %"
        Me.BandedGridColumnSVATP.FieldName = "sales_vat"
        Me.BandedGridColumnSVATP.Name = "BandedGridColumnSVATP"
        Me.BandedGridColumnSVATP.Visible = True
        Me.BandedGridColumnSVATP.Width = 81
        '
        'BandedGridColumnSRP
        '
        Me.BandedGridColumnSRP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnSRP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnSRP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnSRP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnSRP.Caption = "Sales Royalty %"
        Me.BandedGridColumnSRP.FieldName = "royalty_percent"
        Me.BandedGridColumnSRP.Name = "BandedGridColumnSRP"
        Me.BandedGridColumnSRP.Visible = True
        Me.BandedGridColumnSRP.Width = 112
        '
        'BandedGridColumnSTP
        '
        Me.BandedGridColumnSTP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnSTP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnSTP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnSTP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnSTP.Caption = "Sales Through %"
        Me.BandedGridColumnSTP.FieldName = "sales_thru"
        Me.BandedGridColumnSTP.Name = "BandedGridColumnSTP"
        Me.BandedGridColumnSTP.Visible = True
        Me.BandedGridColumnSTP.Width = 98
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn1.Caption = "Qty Sales"
        Me.BandedGridColumn1.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn1.FieldName = "qty_st"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumnEst
        '
        Me.BandedGridColumnEst.Caption = "Est Price"
        Me.BandedGridColumnEst.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnEst.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnEst.FieldName = "est_price"
        Me.BandedGridColumnEst.Name = "BandedGridColumnEst"
        Me.BandedGridColumnEst.Visible = True
        Me.BandedGridColumnEst.Width = 78
        '
        'BandedGridColumnEstRoyS
        '
        Me.BandedGridColumnEstRoyS.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoyS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoyS.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoyS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoyS.Caption = "Est Royalty Sales"
        Me.BandedGridColumnEstRoyS.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnEstRoyS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnEstRoyS.FieldName = "royalty_sales_est"
        Me.BandedGridColumnEstRoyS.Name = "BandedGridColumnEstRoyS"
        Me.BandedGridColumnEstRoyS.Visible = True
        '
        'BandedGridColumnEstRoyD
        '
        Me.BandedGridColumnEstRoyD.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoyD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoyD.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoyD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoyD.Caption = "Est Royalty Duty"
        Me.BandedGridColumnEstRoyD.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnEstRoyD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnEstRoyD.FieldName = "royalty_duty_est"
        Me.BandedGridColumnEstRoyD.Name = "BandedGridColumnEstRoyD"
        Me.BandedGridColumnEstRoyD.Visible = True
        Me.BandedGridColumnEstRoyD.Width = 79
        '
        'BandedGridColumnEstRoySA
        '
        Me.BandedGridColumnEstRoySA.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoySA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoySA.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoySA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoySA.Caption = "Amount Est Royalty Sales"
        Me.BandedGridColumnEstRoySA.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnEstRoySA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnEstRoySA.FieldName = "amount_royalty_sales_est"
        Me.BandedGridColumnEstRoySA.Name = "BandedGridColumnEstRoySA"
        Me.BandedGridColumnEstRoySA.Visible = True
        '
        'BandedGridColumnEstRoyDA
        '
        Me.BandedGridColumnEstRoyDA.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoyDA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoyDA.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoyDA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoyDA.Caption = "Amount Est Royalty Duty"
        Me.BandedGridColumnEstRoyDA.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnEstRoyDA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnEstRoyDA.FieldName = "amount_royalty_duty_est"
        Me.BandedGridColumnEstRoyDA.Name = "BandedGridColumnEstRoyDA"
        Me.BandedGridColumnEstRoyDA.Visible = True
        '
        'BandedGridColumnFinal
        '
        Me.BandedGridColumnFinal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinal.Caption = "Final Price"
        Me.BandedGridColumnFinal.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFinal.FieldName = "final_price"
        Me.BandedGridColumnFinal.Name = "BandedGridColumnFinal"
        Me.BandedGridColumnFinal.Visible = True
        '
        'BandedGridColumnFinalRoyS
        '
        Me.BandedGridColumnFinalRoyS.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoyS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoyS.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoyS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoyS.Caption = "Royalty Sales"
        Me.BandedGridColumnFinalRoyS.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFinalRoyS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFinalRoyS.FieldName = "royalty_sales_final"
        Me.BandedGridColumnFinalRoyS.Name = "BandedGridColumnFinalRoyS"
        Me.BandedGridColumnFinalRoyS.Visible = True
        '
        'BandedGridColumnFinalRoyD
        '
        Me.BandedGridColumnFinalRoyD.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoyD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoyD.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoyD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoyD.Caption = "Royalty Duty"
        Me.BandedGridColumnFinalRoyD.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFinalRoyD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFinalRoyD.FieldName = "royalty_duty_final"
        Me.BandedGridColumnFinalRoyD.Name = "BandedGridColumnFinalRoyD"
        Me.BandedGridColumnFinalRoyD.Visible = True
        '
        'BandedGridColumnFinalRoySA
        '
        Me.BandedGridColumnFinalRoySA.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoySA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoySA.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoySA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoySA.Caption = "Amount Royalty Sales"
        Me.BandedGridColumnFinalRoySA.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFinalRoySA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFinalRoySA.FieldName = "amount_royalty_sales_final"
        Me.BandedGridColumnFinalRoySA.Name = "BandedGridColumnFinalRoySA"
        Me.BandedGridColumnFinalRoySA.Visible = True
        '
        'BandedGridColumnFinalRoyDA
        '
        Me.BandedGridColumnFinalRoyDA.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoyDA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoyDA.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoyDA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoyDA.Caption = "Amount Royalty Duty"
        Me.BandedGridColumnFinalRoyDA.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFinalRoyDA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFinalRoyDA.FieldName = "amount_royalty_duty_final"
        Me.BandedGridColumnFinalRoyDA.Name = "BandedGridColumnFinalRoyDA"
        Me.BandedGridColumnFinalRoyDA.Visible = True
        '
        'BandedGridColumnDiffPrice
        '
        Me.BandedGridColumnDiffPrice.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDiffPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDiffPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffPrice.Caption = "Price Diff"
        Me.BandedGridColumnDiffPrice.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnDiffPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffPrice.FieldName = "price_diff"
        Me.BandedGridColumnDiffPrice.Name = "BandedGridColumnDiffPrice"
        Me.BandedGridColumnDiffPrice.UnboundExpression = "[final_price] - [est_price]"
        Me.BandedGridColumnDiffPrice.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnDiffPrice.Visible = True
        '
        'BandedGridColumnDiffRoyS
        '
        Me.BandedGridColumnDiffRoyS.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDiffRoyS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffRoyS.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDiffRoyS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffRoyS.Caption = "Royalty Sales Diff"
        Me.BandedGridColumnDiffRoyS.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnDiffRoyS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffRoyS.FieldName = "diff_roys"
        Me.BandedGridColumnDiffRoyS.Name = "BandedGridColumnDiffRoyS"
        Me.BandedGridColumnDiffRoyS.UnboundExpression = "[royalty_sales_final] - [royalty_sales_est]"
        Me.BandedGridColumnDiffRoyS.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnDiffRoyS.Visible = True
        '
        'BandedGridColumnDiffRoyD
        '
        Me.BandedGridColumnDiffRoyD.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDiffRoyD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffRoyD.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDiffRoyD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffRoyD.Caption = "Royalty Duty Diff"
        Me.BandedGridColumnDiffRoyD.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnDiffRoyD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffRoyD.FieldName = "diff_royd"
        Me.BandedGridColumnDiffRoyD.Name = "BandedGridColumnDiffRoyD"
        Me.BandedGridColumnDiffRoyD.UnboundExpression = "[royalty_duty_final] - [royalty_duty_est]"
        Me.BandedGridColumnDiffRoyD.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnDiffRoyD.Visible = True
        '
        'BandedGridColumnDiffAmoRoyS
        '
        Me.BandedGridColumnDiffAmoRoyS.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDiffAmoRoyS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffAmoRoyS.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDiffAmoRoyS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffAmoRoyS.Caption = "Amount Royalty Sales Diff"
        Me.BandedGridColumnDiffAmoRoyS.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnDiffAmoRoyS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffAmoRoyS.FieldName = "diff_roys_amo"
        Me.BandedGridColumnDiffAmoRoyS.Name = "BandedGridColumnDiffAmoRoyS"
        Me.BandedGridColumnDiffAmoRoyS.UnboundExpression = "[amount_royalty_sales_final] - [amount_royalty_sales_est]"
        Me.BandedGridColumnDiffAmoRoyS.Visible = True
        '
        'BandedGridColumnDiffAmoRoyD
        '
        Me.BandedGridColumnDiffAmoRoyD.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDiffAmoRoyD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffAmoRoyD.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDiffAmoRoyD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffAmoRoyD.Caption = "Amount Royalty Duty Diff"
        Me.BandedGridColumnDiffAmoRoyD.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnDiffAmoRoyD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffAmoRoyD.FieldName = "diff_royd_amo"
        Me.BandedGridColumnDiffAmoRoyD.Name = "BandedGridColumnDiffAmoRoyD"
        Me.BandedGridColumnDiffAmoRoyD.UnboundExpression = "[amount_royalty_duty_final] - [amount_royalty_duty_est]"
        Me.BandedGridColumnDiffAmoRoyD.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnDiffAmoRoyD.Visible = True
        '
        'BandedGridColumnDutyPaid
        '
        Me.BandedGridColumnDutyPaid.Caption = "Payment Completed"
        Me.BandedGridColumnDutyPaid.ColumnEdit = Me.RICEDutyPaid
        Me.BandedGridColumnDutyPaid.FieldName = "duty_is_pay"
        Me.BandedGridColumnDutyPaid.Name = "BandedGridColumnDutyPaid"
        Me.BandedGridColumnDutyPaid.Visible = True
        Me.BandedGridColumnDutyPaid.Width = 104
        '
        'RICEDutyPaid
        '
        Me.RICEDutyPaid.AutoHeight = False
        Me.RICEDutyPaid.Name = "RICEDutyPaid"
        Me.RICEDutyPaid.ValueChecked = "yes"
        Me.RICEDutyPaid.ValueUnchecked = "no"
        '
        'BandedGridColumnPRProposed
        '
        Me.BandedGridColumnPRProposed.Caption = "PR Proposed"
        Me.BandedGridColumnPRProposed.ColumnEdit = Me.RICEPRProposed
        Me.BandedGridColumnPRProposed.FieldName = "duty_is_pr_proposed"
        Me.BandedGridColumnPRProposed.Name = "BandedGridColumnPRProposed"
        Me.BandedGridColumnPRProposed.Visible = True
        Me.BandedGridColumnPRProposed.Width = 85
        '
        'RICEPRProposed
        '
        Me.RICEPRProposed.AutoHeight = False
        Me.RICEPRProposed.Name = "RICEPRProposed"
        Me.RICEPRProposed.ValueChecked = "yes"
        Me.RICEPRProposed.ValueUnchecked = "no"
        '
        'RIPictureEdit
        '
        Me.RIPictureEdit.Name = "RIPictureEdit"
        Me.RIPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BPrint)
        Me.PanelControl1.Controls.Add(Me.SLEVendor)
        Me.PanelControl1.Controls.Add(Me.SLESeason)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLEDesignStockStore)
        Me.PanelControl1.Controls.Add(Me.LabelControl9)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(889, 38)
        Me.PanelControl1.TabIndex = 5
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(780, 6)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(59, 23)
        Me.BPrint.TabIndex = 8906
        Me.BPrint.Text = "Print"
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(512, 8)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendor.Properties.Appearance.Options.UseFont = True
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView14
        Me.SLEVendor.Size = New System.Drawing.Size(197, 20)
        Me.SLEVendor.TabIndex = 8905
        '
        'GridView14
        '
        Me.GridView14.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView14.Name = "GridView14"
        Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView14.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id Comp"
        Me.GridColumn10.FieldName = "id_comp"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Comp Number"
        Me.GridColumn11.FieldName = "comp_number"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 188
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Comp Name"
        Me.GridColumn12.FieldName = "comp_name"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        Me.GridColumn12.Width = 504
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(303, 8)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(163, 20)
        Me.SLESeason.TabIndex = 8904
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn8})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id Season"
        Me.GridColumn6.FieldName = "id_season"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Season"
        Me.GridColumn8.FieldName = "season"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(715, 6)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8903
        Me.BSearch.Text = "Search"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(472, 11)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 8901
        Me.LabelControl3.Text = "Vendor"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(262, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 8897
        Me.LabelControl1.Text = "Season"
        '
        'SLEDesignStockStore
        '
        Me.SLEDesignStockStore.Location = New System.Drawing.Point(49, 8)
        Me.SLEDesignStockStore.Name = "SLEDesignStockStore"
        Me.SLEDesignStockStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDesignStockStore.Properties.View = Me.GVSLEDesgSearch
        Me.SLEDesignStockStore.Size = New System.Drawing.Size(195, 20)
        Me.SLEDesignStockStore.TabIndex = 8896
        '
        'GVSLEDesgSearch
        '
        Me.GVSLEDesgSearch.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCodeSearch, Me.GridColumn7, Me.GridColumn9})
        Me.GVSLEDesgSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GVSLEDesgSearch.Name = "GVSLEDesgSearch"
        Me.GVSLEDesgSearch.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVSLEDesgSearch.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCodeSearch
        '
        Me.GridColumnCodeSearch.Caption = "Code"
        Me.GridColumnCodeSearch.FieldName = "design_code"
        Me.GridColumnCodeSearch.Name = "GridColumnCodeSearch"
        Me.GridColumnCodeSearch.Visible = True
        Me.GridColumnCodeSearch.VisibleIndex = 0
        Me.GridColumnCodeSearch.Width = 186
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Description"
        Me.GridColumn7.FieldName = "display_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 360
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.Caption = "Color"
        Me.GridColumn9.FieldName = "color"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        Me.GridColumn9.Width = 146
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(11, 11)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl9.TabIndex = 8895
        Me.LabelControl9.Text = "Design"
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand1.Caption = "Vendor"
        Me.GridBand1.Columns.Add(Me.GridColumnVendorCode)
        Me.GridBand1.Columns.Add(Me.GridColumnCompName)
        Me.GridBand1.Columns.Add(Me.GridColumnReportStatus)
        Me.GridBand1.Columns.Add(Me.GridColumnIdReportStatus)
        Me.GridBand1.Columns.Add(Me.GridColumnProdDate)
        Me.GridBand1.Columns.Add(Me.GridColumnPOType)
        Me.GridBand1.Columns.Add(Me.GridColumnTerm)
        Me.GridBand1.Columns.Add(Me.GridColumnDesignCOP)
        Me.GridBand1.Columns.Add(Me.GridColumnIdPO)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 154
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "FG Purchase Order"
        Me.gridBand2.Columns.Add(Me.GridColumnIdSeason)
        Me.gridBand2.Columns.Add(Me.GridColumnSeason)
        Me.gridBand2.Columns.Add(Me.GridColumnIdDelivery)
        Me.gridBand2.Columns.Add(Me.GridColumnDelivery)
        Me.gridBand2.Columns.Add(Me.GridColumnProdNo)
        Me.gridBand2.Columns.Add(Me.GridColumnCode)
        Me.gridBand2.Columns.Add(Me.GridColumnDesign)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnColor)
        Me.gridBand2.Columns.Add(Me.GridColumnOrderQty)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnFOB)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 584
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "PIB"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBNo)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBPRDueDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPRProposed)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBDueDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnDutyPaid)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 546
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand4.Caption = "*"
        Me.gridBand4.Columns.Add(Me.BandedGridColumnDutyP)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnSDP)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnSVATP)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnSRP)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnSTP)
        Me.gridBand4.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 546
        '
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.Caption = "Estimate (PD)"
        Me.gridBand5.Columns.Add(Me.BandedGridColumnEst)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnEstRoyS)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnEstRoyD)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnEstRoySA)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnEstRoyDA)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 4
        Me.gridBand5.Width = 382
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "Final"
        Me.gridBand6.Columns.Add(Me.BandedGridColumnFinal)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnFinalRoyS)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnFinalRoyD)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnFinalRoySA)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnFinalRoyDA)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 5
        Me.gridBand6.Width = 375
        '
        'gridBand7
        '
        Me.gridBand7.Caption = "Different (Final - PD)"
        Me.gridBand7.Columns.Add(Me.BandedGridColumnDiffPrice)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnDiffRoyS)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnDiffRoyD)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnDiffAmoRoyS)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnDiffAmoRoyD)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 6
        Me.gridBand7.Width = 375
        '
        'FormProdDuty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 332)
        Me.Controls.Add(Me.GCProd)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormProdDuty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Duty Report"
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEDutyPaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPRProposed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents RIPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView14 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDesignStockStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GVSLEDesgSearch As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodeSearch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GVProd As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumnVendorCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnProdNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIdReportStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnProdDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPOType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnTerm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDesignCOP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnOrderQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIdPO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIdDelivery As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDelivery As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnColor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFOB As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDutyP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSTP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSDP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSVATP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSRP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnEst As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnEstRoyS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnEstRoyD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnEstRoySA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnEstRoyDA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFinal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFinalRoyS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFinalRoyD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFinalRoySA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFinalRoyDA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMEdit As ToolStripMenuItem
    Friend WithEvents BandedGridColumnDiffPrice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiffRoyS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiffRoyD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiffAmoRoyS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiffAmoRoyD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBDueDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBPRDueDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDutyPaid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPRProposed As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RICEDutyPaid As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RICEPRProposed As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
