<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportSalesOrderNew
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Code128Generator1 As DevExpress.XtraPrinting.BarCode.Code128Generator = New DevExpress.XtraPrinting.BarCode.Code128Generator()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesTarget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEanCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesOrderDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesignPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOLStoreId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LRecNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.LabelOLOrderDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDotOLOrderDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTitleOLOrderDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelOLStoreOrder = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDotOLStoreOrder = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTitleOLStoreOrder = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTitleName = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelName = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelNameDot = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelNIK = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelNIKDot = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTitleNIK = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelWarehouse = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelCategory = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelType = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelReff = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XRBarcode = New DevExpress.XtraReports.UI.XRBarCode()
        Me.LRecDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPanel2 = New DevExpress.XtraReports.UI.XRPanel()
        Me.LabelNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 200.6042!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(772.0001!, 175.0833!)
        Me.WinControlContainer1.WinControl = Me.GCItemList
        '
        'GCItemList
        '
        Me.GCItemList.Location = New System.Drawing.Point(21, 2)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(741, 168)
        Me.GCItemList.TabIndex = 2
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnPriceType, Me.GridColumnQty, Me.GridColumnPrice, Me.GridColumnAmount, Me.GridColumnRemark, Me.GridColumnUOM, Me.GridColumnIdSalesTarget, Me.GridColumnEanCode, Me.GridColumnIdDesign, Me.GridColumnIdProduct, Me.GridColumnIdSample, Me.GridColumnIdSalesOrderDet, Me.GridColumnIdDesignPrice, Me.GridColumnItemId, Me.GridColumnOLStoreId, Me.GridColumnclass, Me.GridColumn1})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItemList.OptionsView.ShowFooter = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 55
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.ReadOnly = True
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 171
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_design"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.ReadOnly = True
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 3
        Me.GridColumnName.Width = 437
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
        Me.GridColumnSize.OptionsColumn.ReadOnly = True
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 5
        Me.GridColumnSize.Width = 80
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Prc Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.OptionsColumn.AllowEdit = False
        Me.GridColumnPriceType.OptionsColumn.ReadOnly = True
        Me.GridColumnPriceType.Visible = True
        Me.GridColumnPriceType.VisibleIndex = 6
        Me.GridColumnPriceType.Width = 91
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sales_order_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.OptionsColumn.AllowShowHide = False
        Me.GridColumnQty.OptionsColumn.ReadOnly = True
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_qty", "{0:f2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 7
        Me.GridColumnQty.Width = 91
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.OptionsColumn.ReadOnly = True
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 8
        Me.GridColumnPrice.Width = 195
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
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.ReadOnly = True
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:n2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 9
        Me.GridColumnAmount.Width = 348
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sales_order_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Width = 225
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
        Me.GridColumnUOM.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnUOM.Width = 71
        '
        'GridColumnIdSalesTarget
        '
        Me.GridColumnIdSalesTarget.Caption = "ID Sales Target"
        Me.GridColumnIdSalesTarget.FieldName = "id_sales_target"
        Me.GridColumnIdSalesTarget.Name = "GridColumnIdSalesTarget"
        Me.GridColumnIdSalesTarget.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSalesTarget.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdSalesTarget.Width = 83
        '
        'GridColumnEanCode
        '
        Me.GridColumnEanCode.Caption = "EAN Code"
        Me.GridColumnEanCode.FieldName = "ean_code"
        Me.GridColumnEanCode.Name = "GridColumnEanCode"
        Me.GridColumnEanCode.OptionsColumn.AllowEdit = False
        Me.GridColumnEanCode.OptionsColumn.ShowInCustomizationForm = False
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
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSalesOrderDet
        '
        Me.GridColumnIdSalesOrderDet.Caption = "Id Sales Order Det"
        Me.GridColumnIdSalesOrderDet.FieldName = "id_sales_order_det"
        Me.GridColumnIdSalesOrderDet.Name = "GridColumnIdSalesOrderDet"
        Me.GridColumnIdSalesOrderDet.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSalesOrderDet.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdSalesOrderDet.Width = 98
        '
        'GridColumnIdDesignPrice
        '
        Me.GridColumnIdDesignPrice.Caption = "Id Design Price"
        Me.GridColumnIdDesignPrice.FieldName = "id_design_price"
        Me.GridColumnIdDesignPrice.Name = "GridColumnIdDesignPrice"
        Me.GridColumnIdDesignPrice.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdDesignPrice.Width = 80
        '
        'GridColumnItemId
        '
        Me.GridColumnItemId.Caption = "Item Id"
        Me.GridColumnItemId.FieldName = "item_id"
        Me.GridColumnItemId.Name = "GridColumnItemId"
        '
        'GridColumnOLStoreId
        '
        Me.GridColumnOLStoreId.Caption = "OL Store Id"
        Me.GridColumnOLStoreId.FieldName = "ol_store_id"
        Me.GridColumnOLStoreId.Name = "GridColumnOLStoreId"
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 2
        Me.GridColumnclass.Width = 79
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Color"
        Me.GridColumn1.FieldName = "color"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        Me.GridColumn1.Width = 85
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LTitle, Me.XrLabel1, Me.XrLabel12, Me.LRecNumber, Me.XrPanel1, Me.LRecDate})
        Me.TopMargin.HeightF = 193.2122!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(267.1654!, 24.91666!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(259.8749!, 25.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "[judul]"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 24.91666!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(43.08301!, 25.08334!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(43.08301!, 24.91666!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(13.45819!, 25.08334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = ":"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LRecNumber
        '
        Me.LRecNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LRecNumber.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LRecNumber.LocationFloat = New DevExpress.Utils.PointFloat(56.54119!, 24.91666!)
        Me.LRecNumber.Name = "LRecNumber"
        Me.LRecNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LRecNumber.SizeF = New System.Drawing.SizeF(210.6242!, 25.08334!)
        Me.LRecNumber.StylePriority.UseBorders = False
        Me.LRecNumber.StylePriority.UseFont = False
        Me.LRecNumber.StylePriority.UseTextAlignment = False
        Me.LRecNumber.Text = "[order_number]"
        Me.LRecNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrPanel1
        '
        Me.XrPanel1.BorderColor = System.Drawing.Color.DimGray
        Me.XrPanel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.CanGrow = False
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelOLOrderDate, Me.LabelDotOLOrderDate, Me.LabelTitleOLOrderDate, Me.LabelOLStoreOrder, Me.LabelDotOLStoreOrder, Me.LabelTitleOLStoreOrder, Me.LabelTitleName, Me.LabelName, Me.LabelNameDot, Me.LabelNIK, Me.LabelNIKDot, Me.LabelTitleNIK, Me.LabelWarehouse, Me.XrLabel8, Me.LabelCategory, Me.XrLabel7, Me.XrLabel6, Me.LabelType, Me.XrLabel5, Me.XrLabel4, Me.XrLabel21, Me.XrLabel13, Me.LabelReff, Me.XrLabel11, Me.LabelTo, Me.XrLabel3, Me.XrLabel2, Me.XRBarcode})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 50.0!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(772.0001!, 143.2122!)
        Me.XrPanel1.StylePriority.UseBorderColor = False
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'LabelOLOrderDate
        '
        Me.LabelOLOrderDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelOLOrderDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelOLOrderDate.LocationFloat = New DevExpress.Utils.PointFloat(509.0834!, 45.58342!)
        Me.LabelOLOrderDate.Name = "LabelOLOrderDate"
        Me.LabelOLOrderDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelOLOrderDate.SizeF = New System.Drawing.SizeF(252.9168!, 13.58334!)
        Me.LabelOLOrderDate.StylePriority.UseBorders = False
        Me.LabelOLOrderDate.StylePriority.UseFont = False
        Me.LabelOLOrderDate.StylePriority.UseTextAlignment = False
        Me.LabelOLOrderDate.Text = "[ol_order_date]"
        Me.LabelOLOrderDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelOLOrderDate.Visible = False
        '
        'LabelDotOLOrderDate
        '
        Me.LabelDotOLOrderDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelDotOLOrderDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDotOLOrderDate.LocationFloat = New DevExpress.Utils.PointFloat(497.6246!, 45.58338!)
        Me.LabelDotOLOrderDate.Name = "LabelDotOLOrderDate"
        Me.LabelDotOLOrderDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDotOLOrderDate.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.LabelDotOLOrderDate.StylePriority.UseBorders = False
        Me.LabelDotOLOrderDate.StylePriority.UseFont = False
        Me.LabelDotOLOrderDate.StylePriority.UseTextAlignment = False
        Me.LabelDotOLOrderDate.Text = ":"
        Me.LabelDotOLOrderDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelDotOLOrderDate.Visible = False
        '
        'LabelTitleOLOrderDate
        '
        Me.LabelTitleOLOrderDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelTitleOLOrderDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitleOLOrderDate.LocationFloat = New DevExpress.Utils.PointFloat(401.7919!, 45.58339!)
        Me.LabelTitleOLOrderDate.Name = "LabelTitleOLOrderDate"
        Me.LabelTitleOLOrderDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitleOLOrderDate.SizeF = New System.Drawing.SizeF(95.83334!, 13.58338!)
        Me.LabelTitleOLOrderDate.StylePriority.UseBorders = False
        Me.LabelTitleOLOrderDate.StylePriority.UseFont = False
        Me.LabelTitleOLOrderDate.StylePriority.UseTextAlignment = False
        Me.LabelTitleOLOrderDate.Text = "OL Order Date"
        Me.LabelTitleOLOrderDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelTitleOLOrderDate.Visible = False
        '
        'LabelOLStoreOrder
        '
        Me.LabelOLStoreOrder.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelOLStoreOrder.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelOLStoreOrder.LocationFloat = New DevExpress.Utils.PointFloat(509.0833!, 32.00005!)
        Me.LabelOLStoreOrder.Name = "LabelOLStoreOrder"
        Me.LabelOLStoreOrder.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelOLStoreOrder.SizeF = New System.Drawing.SizeF(252.9168!, 13.58334!)
        Me.LabelOLStoreOrder.StylePriority.UseBorders = False
        Me.LabelOLStoreOrder.StylePriority.UseFont = False
        Me.LabelOLStoreOrder.StylePriority.UseTextAlignment = False
        Me.LabelOLStoreOrder.Text = "[ol_order_number]"
        Me.LabelOLStoreOrder.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelOLStoreOrder.Visible = False
        '
        'LabelDotOLStoreOrder
        '
        Me.LabelDotOLStoreOrder.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelDotOLStoreOrder.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDotOLStoreOrder.LocationFloat = New DevExpress.Utils.PointFloat(497.6251!, 32.00002!)
        Me.LabelDotOLStoreOrder.Name = "LabelDotOLStoreOrder"
        Me.LabelDotOLStoreOrder.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDotOLStoreOrder.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.LabelDotOLStoreOrder.StylePriority.UseBorders = False
        Me.LabelDotOLStoreOrder.StylePriority.UseFont = False
        Me.LabelDotOLStoreOrder.StylePriority.UseTextAlignment = False
        Me.LabelDotOLStoreOrder.Text = ":"
        Me.LabelDotOLStoreOrder.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelDotOLStoreOrder.Visible = False
        '
        'LabelTitleOLStoreOrder
        '
        Me.LabelTitleOLStoreOrder.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelTitleOLStoreOrder.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitleOLStoreOrder.LocationFloat = New DevExpress.Utils.PointFloat(401.7919!, 32.0!)
        Me.LabelTitleOLStoreOrder.Name = "LabelTitleOLStoreOrder"
        Me.LabelTitleOLStoreOrder.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitleOLStoreOrder.SizeF = New System.Drawing.SizeF(95.83334!, 13.58338!)
        Me.LabelTitleOLStoreOrder.StylePriority.UseBorders = False
        Me.LabelTitleOLStoreOrder.StylePriority.UseFont = False
        Me.LabelTitleOLStoreOrder.StylePriority.UseTextAlignment = False
        Me.LabelTitleOLStoreOrder.Text = "OL Store Order"
        Me.LabelTitleOLStoreOrder.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelTitleOLStoreOrder.Visible = False
        '
        'LabelTitleName
        '
        Me.LabelTitleName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelTitleName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitleName.LocationFloat = New DevExpress.Utils.PointFloat(401.792!, 59.16678!)
        Me.LabelTitleName.Name = "LabelTitleName"
        Me.LabelTitleName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitleName.SizeF = New System.Drawing.SizeF(95.83322!, 13.58337!)
        Me.LabelTitleName.StylePriority.UseBorders = False
        Me.LabelTitleName.StylePriority.UseFont = False
        Me.LabelTitleName.StylePriority.UseTextAlignment = False
        Me.LabelTitleName.Text = "Name"
        Me.LabelTitleName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelTitleName.Visible = False
        '
        'LabelName
        '
        Me.LabelName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelName.LocationFloat = New DevExpress.Utils.PointFloat(509.0836!, 59.16678!)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelName.SizeF = New System.Drawing.SizeF(253.2919!, 34.0!)
        Me.LabelName.StylePriority.UseBorders = False
        Me.LabelName.StylePriority.UseFont = False
        Me.LabelName.StylePriority.UseTextAlignment = False
        Me.LabelName.Text = "[name]"
        Me.LabelName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.LabelName.Visible = False
        '
        'LabelNameDot
        '
        Me.LabelNameDot.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelNameDot.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNameDot.LocationFloat = New DevExpress.Utils.PointFloat(497.6246!, 59.16677!)
        Me.LabelNameDot.Name = "LabelNameDot"
        Me.LabelNameDot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNameDot.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.LabelNameDot.StylePriority.UseBorders = False
        Me.LabelNameDot.StylePriority.UseFont = False
        Me.LabelNameDot.StylePriority.UseTextAlignment = False
        Me.LabelNameDot.Text = ":"
        Me.LabelNameDot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelNameDot.Visible = False
        '
        'LabelNIK
        '
        Me.LabelNIK.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelNIK.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNIK.LocationFloat = New DevExpress.Utils.PointFloat(509.0836!, 93.16676!)
        Me.LabelNIK.Name = "LabelNIK"
        Me.LabelNIK.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNIK.SizeF = New System.Drawing.SizeF(252.9166!, 13.58337!)
        Me.LabelNIK.StylePriority.UseBorders = False
        Me.LabelNIK.StylePriority.UseFont = False
        Me.LabelNIK.StylePriority.UseTextAlignment = False
        Me.LabelNIK.Text = "[nik]"
        Me.LabelNIK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelNIK.Visible = False
        '
        'LabelNIKDot
        '
        Me.LabelNIKDot.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelNIKDot.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNIKDot.LocationFloat = New DevExpress.Utils.PointFloat(497.6251!, 93.16676!)
        Me.LabelNIKDot.Name = "LabelNIKDot"
        Me.LabelNIKDot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNIKDot.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.LabelNIKDot.StylePriority.UseBorders = False
        Me.LabelNIKDot.StylePriority.UseFont = False
        Me.LabelNIKDot.StylePriority.UseTextAlignment = False
        Me.LabelNIKDot.Text = ":"
        Me.LabelNIKDot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelNIKDot.Visible = False
        '
        'LabelTitleNIK
        '
        Me.LabelTitleNIK.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelTitleNIK.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitleNIK.LocationFloat = New DevExpress.Utils.PointFloat(401.792!, 93.16676!)
        Me.LabelTitleNIK.Name = "LabelTitleNIK"
        Me.LabelTitleNIK.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitleNIK.SizeF = New System.Drawing.SizeF(95.83322!, 13.58337!)
        Me.LabelTitleNIK.StylePriority.UseBorders = False
        Me.LabelTitleNIK.StylePriority.UseFont = False
        Me.LabelTitleNIK.StylePriority.UseTextAlignment = False
        Me.LabelTitleNIK.Text = "NIK"
        Me.LabelTitleNIK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.LabelTitleNIK.Visible = False
        '
        'LabelWarehouse
        '
        Me.LabelWarehouse.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelWarehouse.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWarehouse.LocationFloat = New DevExpress.Utils.PointFloat(132.2083!, 29.16679!)
        Me.LabelWarehouse.Name = "LabelWarehouse"
        Me.LabelWarehouse.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelWarehouse.SizeF = New System.Drawing.SizeF(259.3751!, 13.58335!)
        Me.LabelWarehouse.StylePriority.UseBorders = False
        Me.LabelWarehouse.StylePriority.UseFont = False
        Me.LabelWarehouse.Text = "[from]"
        '
        'XrLabel8
        '
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(120.75!, 29.1668!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.Text = ":"
        '
        'LabelCategory
        '
        Me.LabelCategory.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelCategory.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCategory.LocationFloat = New DevExpress.Utils.PointFloat(132.2083!, 100.4622!)
        Me.LabelCategory.Name = "LabelCategory"
        Me.LabelCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelCategory.SizeF = New System.Drawing.SizeF(234.4587!, 13.58337!)
        Me.LabelCategory.StylePriority.UseBorders = False
        Me.LabelCategory.StylePriority.UseFont = False
        Me.LabelCategory.Text = "[so_status]"
        '
        'XrLabel7
        '
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(120.75!, 100.4622!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.Text = ":"
        '
        'XrLabel6
        '
        Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(2.000046!, 100.4622!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(118.7498!, 13.58337!)
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.Text = "Category"
        '
        'LabelType
        '
        Me.LabelType.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelType.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelType.LocationFloat = New DevExpress.Utils.PointFloat(132.2083!, 86.87881!)
        Me.LabelType.Name = "LabelType"
        Me.LabelType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelType.SizeF = New System.Drawing.SizeF(234.4587!, 13.58337!)
        Me.LabelType.StylePriority.UseBorders = False
        Me.LabelType.StylePriority.UseFont = False
        Me.LabelType.Text = "[so_type]"
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(120.7499!, 86.87881!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = ":"
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(2.000046!, 86.87871!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(118.7499!, 13.58337!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = "Type"
        '
        'XrLabel21
        '
        Me.XrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel21.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(2.000014!, 73.29534!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(118.7499!, 13.58337!)
        Me.XrLabel21.StylePriority.UseBorders = False
        Me.XrLabel21.StylePriority.UseFont = False
        Me.XrLabel21.Text = "Reff."
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(120.7499!, 73.29541!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.Text = ":"
        '
        'LabelReff
        '
        Me.LabelReff.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelReff.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelReff.LocationFloat = New DevExpress.Utils.PointFloat(132.2083!, 73.29543!)
        Me.LabelReff.Name = "LabelReff"
        Me.LabelReff.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelReff.SizeF = New System.Drawing.SizeF(234.4587!, 13.58337!)
        Me.LabelReff.StylePriority.UseBorders = False
        Me.LabelReff.StylePriority.UseFont = False
        Me.LabelReff.Text = "[reff]"
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(120.7499!, 42.75022!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.Text = ":"
        '
        'LabelTo
        '
        Me.LabelTo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelTo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTo.LocationFloat = New DevExpress.Utils.PointFloat(132.2083!, 42.75023!)
        Me.LabelTo.Name = "LabelTo"
        Me.LabelTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTo.SizeF = New System.Drawing.SizeF(259.3751!, 13.58335!)
        Me.LabelTo.StylePriority.UseBorders = False
        Me.LabelTo.StylePriority.UseFont = False
        Me.LabelTo.Text = "[to]"
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.000014!, 42.75023!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(118.7499!, 13.58335!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "To"
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(2.000046!, 29.16677!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(118.7499!, 13.58336!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "From"
        '
        'XRBarcode
        '
        Me.XRBarcode.Alignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XRBarcode.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XRBarcode.LocationFloat = New DevExpress.Utils.PointFloat(2.000046!, 4.166779!)
        Me.XRBarcode.Name = "XRBarcode"
        Me.XRBarcode.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100.0!)
        Me.XRBarcode.ShowText = False
        Me.XRBarcode.SizeF = New System.Drawing.SizeF(760.0001!, 25.0!)
        Me.XRBarcode.StylePriority.UseBorders = False
        Me.XRBarcode.StylePriority.UseTextAlignment = False
        Me.XRBarcode.Symbology = Code128Generator1
        Me.XRBarcode.Text = "2104142P806C96"
        '
        'LRecDate
        '
        Me.LRecDate.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LRecDate.LocationFloat = New DevExpress.Utils.PointFloat(527.0403!, 24.91666!)
        Me.LRecDate.Name = "LRecDate"
        Me.LRecDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LRecDate.SizeF = New System.Drawing.SizeF(244.9598!, 25.08334!)
        Me.LRecDate.StylePriority.UseFont = False
        Me.LRecDate.StylePriority.UseTextAlignment = False
        Me.LRecDate.Text = "[order_date]"
        Me.LRecDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 75.52071!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(622.0!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel2, Me.XrTable1})
        Me.PageFooter.HeightF = 72.29169!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrPanel2
        '
        Me.XrPanel2.BorderColor = System.Drawing.Color.Black
        Me.XrPanel2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelNote, Me.XrLabel9, Me.XrLabel14})
        Me.XrPanel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPanel2.Name = "XrPanel2"
        Me.XrPanel2.SizeF = New System.Drawing.SizeF(772.0001!, 47.29169!)
        Me.XrPanel2.StylePriority.UseBorderColor = False
        Me.XrPanel2.StylePriority.UseBorders = False
        '
        'LabelNote
        '
        Me.LabelNote.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelNote.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNote.LocationFloat = New DevExpress.Utils.PointFloat(63.598!, 3.833358!)
        Me.LabelNote.Name = "LabelNote"
        Me.LabelNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNote.SizeF = New System.Drawing.SizeF(679.5687!, 33.45833!)
        Me.LabelNote.StylePriority.UseBorders = False
        Me.LabelNote.StylePriority.UseFont = False
        Me.LabelNote.Text = "[order_note]"
        '
        'XrLabel9
        '
        Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(2.000008!, 3.833363!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(50.13963!, 13.58334!)
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.Text = "Note"
        '
        'XrLabel14
        '
        Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(52.13963!, 3.833359!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.Text = ":"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 47.29169!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(772.0001!, 25.0!)
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Lucida Console", 8.0!)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.Text = "Here Table Mark Goes, Please Ignore This"
        Me.XrTableCell1.Visible = False
        Me.XrTableCell1.Weight = 2.99999986405489R
        '
        'ReportSalesOrderNew
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(28, 27, 193, 76)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelOLStoreOrder As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDotOLStoreOrder As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTitleOLStoreOrder As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTitleName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNameDot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNIK As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNIKDot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTitleNIK As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelWarehouse As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelCategory As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelReff As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LRecNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LRecDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPanel2 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesTarget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEanCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesOrderDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesignPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOLStoreId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XRBarcode As DevExpress.XtraReports.UI.XRBarCode
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelOLOrderDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDotOLOrderDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTitleOLOrderDate As DevExpress.XtraReports.UI.XRLabel
End Class
