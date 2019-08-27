<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportSalesDelOrderOwnStore
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LRecNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.LRecDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.LabelUni4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelUni1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelUni6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelUni5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelUni3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelUni2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelCat = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelFrom = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelPrepare = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTo = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.LabelPrintedBy = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelPrintedDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrPanel2 = New DevExpress.XtraReports.UI.XRPanel()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LabelNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 175.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(798.0!, 175.0!)
        Me.WinControlContainer1.WinControl = Me.GCItemList
        '
        'GCItemList
        '
        Me.GCItemList.Location = New System.Drawing.Point(0, 0)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(766, 168)
        Me.GCItemList.TabIndex = 3
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnQty, Me.GridColumnPrice, Me.GridColumnPriceType, Me.GridColumnAmount})
        Me.GVItemList.CustomizationFormBounds = New System.Drawing.Rectangle(958, 136, 216, 180)
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQty, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnAmount, "{0:n0}")})
        Me.GVItemList.IndicatorWidth = 30
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVItemList.OptionsCustomization.AllowFilter = False
        Me.GVItemList.OptionsCustomization.AllowSort = False
        Me.GVItemList.OptionsView.ShowFooter = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.ReadOnly = True
        Me.GridColumnNo.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 42
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.ReadOnly = True
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 205
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_design"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.ReadOnly = True
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 673
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
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 43
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.OptionsColumn.AllowShowHide = False
        Me.GridColumnQty.OptionsColumn.ReadOnly = True
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:n0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 4
        Me.GridColumnQty.Width = 57
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnPrice.OptionsColumn.AllowShowHide = False
        Me.GridColumnPrice.OptionsColumn.ReadOnly = True
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 6
        Me.GridColumnPrice.Width = 232
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.Visible = True
        Me.GridColumnPriceType.VisibleIndex = 5
        Me.GridColumnPriceType.Width = 68
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnAmount.OptionsColumn.AllowShowHide = False
        Me.GridColumnAmount.OptionsColumn.ReadOnly = True
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:n0}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 7
        Me.GridColumnAmount.Width = 298
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.XrLabel12, Me.LRecNumber, Me.LTitle, Me.LRecDate, Me.XrPanel1})
        Me.TopMargin.HeightF = 127.0833!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(2.000122!, 1.041599!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(39.58338!, 25.08334!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(43.5835!, 1.041599!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(11.45835!, 25.08334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = ":"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LRecNumber
        '
        Me.LRecNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LRecNumber.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LRecNumber.LocationFloat = New DevExpress.Utils.PointFloat(55.04187!, 1.041599!)
        Me.LRecNumber.Name = "LRecNumber"
        Me.LRecNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LRecNumber.SizeF = New System.Drawing.SizeF(247.6663!, 25.08334!)
        Me.LRecNumber.StylePriority.UseBorders = False
        Me.LRecNumber.StylePriority.UseFont = False
        Me.LRecNumber.StylePriority.UseTextAlignment = False
        Me.LRecNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(302.7082!, 1.041599!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(188.9586!, 25.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "DELIVERY SLIP"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'LRecDate
        '
        Me.LRecDate.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LRecDate.LocationFloat = New DevExpress.Utils.PointFloat(491.6667!, 1.041599!)
        Me.LRecDate.Name = "LRecDate"
        Me.LRecDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LRecDate.SizeF = New System.Drawing.SizeF(304.3332!, 25.08334!)
        Me.LRecDate.StylePriority.UseFont = False
        Me.LRecDate.StylePriority.UseTextAlignment = False
        Me.LRecDate.Text = "DATE"
        Me.LRecDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'XrPanel1
        '
        Me.XrPanel1.BorderColor = System.Drawing.Color.DimGray
        Me.XrPanel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.CanGrow = False
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelUni4, Me.LabelUni1, Me.LabelUni6, Me.LabelUni5, Me.LabelUni3, Me.LabelUni2, Me.LabelCat, Me.XrLabel13, Me.XrLabel8, Me.LabelFrom, Me.XrLabel7, Me.XrLabel6, Me.LabelPrepare, Me.XrLabel5, Me.XrLabel4, Me.XrLabel11, Me.XrLabel10, Me.LabelTo, Me.LabelAddress, Me.XrLabel2, Me.XrLabel3})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 26.12494!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(796.0001!, 100.9584!)
        Me.XrPanel1.StylePriority.UseBorderColor = False
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'LabelUni4
        '
        Me.LabelUni4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelUni4.LocationFloat = New DevExpress.Utils.PointFloat(481.9582!, 56.33342!)
        Me.LabelUni4.Name = "LabelUni4"
        Me.LabelUni4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelUni4.SizeF = New System.Drawing.SizeF(85.41656!, 13.58335!)
        Me.LabelUni4.StylePriority.UseBorders = False
        Me.LabelUni4.Text = "Name"
        '
        'LabelUni1
        '
        Me.LabelUni1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelUni1.LocationFloat = New DevExpress.Utils.PointFloat(481.9582!, 42.75015!)
        Me.LabelUni1.Name = "LabelUni1"
        Me.LabelUni1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelUni1.SizeF = New System.Drawing.SizeF(85.41656!, 13.58335!)
        Me.LabelUni1.StylePriority.UseBorders = False
        Me.LabelUni1.Text = "NIK"
        '
        'LabelUni6
        '
        Me.LabelUni6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelUni6.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LabelUni6.LocationFloat = New DevExpress.Utils.PointFloat(578.8328!, 56.33351!)
        Me.LabelUni6.Name = "LabelUni6"
        Me.LabelUni6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelUni6.SizeF = New System.Drawing.SizeF(215.1664!, 13.58337!)
        Me.LabelUni6.StylePriority.UseBorders = False
        Me.LabelUni6.StylePriority.UseFont = False
        '
        'LabelUni5
        '
        Me.LabelUni5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelUni5.LocationFloat = New DevExpress.Utils.PointFloat(567.3748!, 56.33342!)
        Me.LabelUni5.Name = "LabelUni5"
        Me.LabelUni5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelUni5.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.LabelUni5.StylePriority.UseBorders = False
        Me.LabelUni5.Text = ":"
        '
        'LabelUni3
        '
        Me.LabelUni3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelUni3.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LabelUni3.LocationFloat = New DevExpress.Utils.PointFloat(578.8335!, 42.75012!)
        Me.LabelUni3.Name = "LabelUni3"
        Me.LabelUni3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelUni3.SizeF = New System.Drawing.SizeF(215.1664!, 13.58337!)
        Me.LabelUni3.StylePriority.UseBorders = False
        Me.LabelUni3.StylePriority.UseFont = False
        '
        'LabelUni2
        '
        Me.LabelUni2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelUni2.LocationFloat = New DevExpress.Utils.PointFloat(567.3748!, 42.75014!)
        Me.LabelUni2.Name = "LabelUni2"
        Me.LabelUni2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelUni2.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.LabelUni2.StylePriority.UseBorders = False
        Me.LabelUni2.Text = ":"
        '
        'LabelCat
        '
        Me.LabelCat.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelCat.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LabelCat.LocationFloat = New DevExpress.Utils.PointFloat(578.8328!, 15.58339!)
        Me.LabelCat.Name = "LabelCat"
        Me.LabelCat.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelCat.SizeF = New System.Drawing.SizeF(215.1667!, 13.58337!)
        Me.LabelCat.StylePriority.UseBorders = False
        Me.LabelCat.StylePriority.UseFont = False
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(567.3748!, 15.58326!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.Text = ":"
        '
        'XrLabel8
        '
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(481.9582!, 15.58339!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(85.41656!, 13.58335!)
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.Text = "Category"
        '
        'LabelFrom
        '
        Me.LabelFrom.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelFrom.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LabelFrom.LocationFloat = New DevExpress.Utils.PointFloat(578.8329!, 29.16676!)
        Me.LabelFrom.Name = "LabelFrom"
        Me.LabelFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelFrom.SizeF = New System.Drawing.SizeF(215.1664!, 13.58337!)
        Me.LabelFrom.StylePriority.UseBorders = False
        Me.LabelFrom.StylePriority.UseFont = False
        '
        'XrLabel7
        '
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(567.3748!, 29.16676!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.Text = ":"
        '
        'XrLabel6
        '
        Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(481.9583!, 29.16675!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(85.41656!, 13.58335!)
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.Text = "Warehouse"
        '
        'LabelPrepare
        '
        Me.LabelPrepare.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelPrepare.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LabelPrepare.LocationFloat = New DevExpress.Utils.PointFloat(578.833!, 2.000014!)
        Me.LabelPrepare.Name = "LabelPrepare"
        Me.LabelPrepare.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelPrepare.SizeF = New System.Drawing.SizeF(215.1667!, 13.58337!)
        Me.LabelPrepare.StylePriority.UseBorders = False
        Me.LabelPrepare.StylePriority.UseFont = False
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(567.3748!, 2.000014!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.Text = ":"
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(481.9583!, 2.000014!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(85.41647!, 13.58337!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.Text = "Prepare Order"
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(84.29162!, 2.000014!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(84.29162!, 15.58336!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(11.45834!, 13.58335!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.Text = ":"
        '
        'LabelTo
        '
        Me.LabelTo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelTo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTo.LocationFloat = New DevExpress.Utils.PointFloat(95.74995!, 2.000013!)
        Me.LabelTo.Name = "LabelTo"
        Me.LabelTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTo.SizeF = New System.Drawing.SizeF(295.8334!, 13.58335!)
        Me.LabelTo.StylePriority.UseBorders = False
        Me.LabelTo.StylePriority.UseFont = False
        '
        'LabelAddress
        '
        Me.LabelAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelAddress.LocationFloat = New DevExpress.Utils.PointFloat(95.74995!, 15.58337!)
        Me.LabelAddress.Name = "LabelAddress"
        Me.LabelAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelAddress.SizeF = New System.Drawing.SizeF(295.8334!, 54.33342!)
        Me.LabelAddress.StylePriority.UseBorders = False
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(2.000039!, 15.58328!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(82.2916!, 13.58335!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.Text = "Address"
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.000039!, 2.000011!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(82.2916!, 13.58335!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.Text = "Store"
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPrintedBy, Me.XrLabel15, Me.LabelPrintedDate, Me.XrLabel14, Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 49.95829!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LabelPrintedBy
        '
        Me.LabelPrintedBy.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPrintedBy.LocationFloat = New DevExpress.Utils.PointFloat(303.1543!, 0!)
        Me.LabelPrintedBy.Name = "LabelPrintedBy"
        Me.LabelPrintedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelPrintedBy.SizeF = New System.Drawing.SizeF(92.84579!, 18.71793!)
        Me.LabelPrintedBy.StylePriority.UseFont = False
        Me.LabelPrintedBy.StylePriority.UseTextAlignment = False
        Me.LabelPrintedBy.Text = "Ari Tri Wibowo"
        Me.LabelPrintedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel15
        '
        Me.XrLabel15.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(228.098!, 0!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(75.0563!, 18.71793!)
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "Printed by : "
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelPrintedDate
        '
        Me.LabelPrintedDate.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPrintedDate.LocationFloat = New DevExpress.Utils.PointFloat(84.29165!, 0!)
        Me.LabelPrintedDate.Name = "LabelPrintedDate"
        Me.LabelPrintedDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelPrintedDate.SizeF = New System.Drawing.SizeF(143.8063!, 18.71793!)
        Me.LabelPrintedDate.StylePriority.UseFont = False
        Me.LabelPrintedDate.StylePriority.UseTextAlignment = False
        Me.LabelPrintedDate.Text = "18-05-1991 11:05:24"
        Me.LabelPrintedDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel14
        '
        Me.XrLabel14.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(84.29163!, 18.71793!)
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Printed Date : "
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(645.9999!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.XrPanel2})
        Me.ReportFooter.HeightF = 126.0417!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 101.0417!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(795.9999!, 25.0!)
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
        'XrPanel2
        '
        Me.XrPanel2.BorderColor = System.Drawing.Color.Black
        Me.XrPanel2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2, Me.LabelNote, Me.XrLabel9})
        Me.XrPanel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPanel2.Name = "XrPanel2"
        Me.XrPanel2.SizeF = New System.Drawing.SizeF(798.0!, 101.0417!)
        Me.XrPanel2.StylePriority.UseBorderColor = False
        Me.XrPanel2.StylePriority.UseBorders = False
        '
        'XrTable2
        '
        Me.XrTable2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTable2.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(296.0001!, 3.833363!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(500.0!, 25.0!)
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell4, Me.XrTableCell5, Me.XrTableCell6})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = "DEPT. HEAD"
        Me.XrTableCell2.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Text = "SECURITY"
        Me.XrTableCell3.Weight = 1.0R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Text = "DISPATCHER"
        Me.XrTableCell4.Weight = 1.0R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Text = "INV. CONTROL"
        Me.XrTableCell5.Weight = 1.0R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Text = "CUSTOMER"
        Me.XrTableCell6.Weight = 1.0R
        '
        'LabelNote
        '
        Me.LabelNote.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelNote.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNote.LocationFloat = New DevExpress.Utils.PointFloat(2.000109!, 17.4167!)
        Me.LabelNote.Name = "LabelNote"
        Me.LabelNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNote.SizeF = New System.Drawing.SizeF(271.2353!, 55.91663!)
        Me.LabelNote.StylePriority.UseBorders = False
        Me.LabelNote.StylePriority.UseFont = False
        Me.LabelNote.Text = "a"
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
        Me.XrLabel9.Text = "Note :"
        '
        'ReportSalesDelOrderOwnStore
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportFooter})
        Me.Margins = New System.Drawing.Printing.Margins(26, 26, 127, 50)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrPanel2 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelUni4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelUni1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelUni6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelUni5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelUni3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelUni2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelCat As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelPrepare As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LRecNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LRecDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents LabelPrintedBy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelPrintedDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
End Class
