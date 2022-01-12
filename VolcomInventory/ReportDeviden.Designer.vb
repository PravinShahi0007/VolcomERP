<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportDeviden
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportDeviden))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.LpayFromMark = New DevExpress.XtraReports.UI.XRLabel()
        Me.LpayFromTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.LPayFrom = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelBeneficiary = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDotBeneficiary = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTitleBeneficiary = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTitleDueDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDotDueDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDUelDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.LabelTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GCHistory = New DevExpress.XtraGrid.GridControl()
        Me.GVHistory = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 276.0417!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 8.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 23.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.ReportFooter.HeightF = 25.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel11, Me.XrLabel10, Me.XrLabel9, Me.XrLabel4, Me.XrLabel5, Me.XrLabel6, Me.XrLabel1, Me.XrLabel2, Me.XrLabel3, Me.LpayFromMark, Me.LpayFromTitle, Me.LPayFrom, Me.XrLabel8, Me.LabelDate, Me.XrLabel7, Me.LabelBeneficiary, Me.LabelDotBeneficiary, Me.LabelTitleBeneficiary, Me.LabelTitleDueDate, Me.LabelDotDueDate, Me.LabelDUelDate, Me.XrPictureBox1, Me.LabelTitle})
        Me.PageHeader.HeightF = 137.5!
        Me.PageHeader.Name = "PageHeader"
        '
        'LpayFromMark
        '
        Me.LpayFromMark.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LpayFromMark.LocationFloat = New DevExpress.Utils.PointFloat(123.6111!, 73.39646!)
        Me.LpayFromMark.Name = "LpayFromMark"
        Me.LpayFromMark.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LpayFromMark.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.LpayFromMark.StylePriority.UseFont = False
        Me.LpayFromMark.StylePriority.UseTextAlignment = False
        Me.LpayFromMark.Text = ":"
        Me.LpayFromMark.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LpayFromTitle
        '
        Me.LpayFromTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LpayFromTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 73.3964!)
        Me.LpayFromTitle.Name = "LpayFromTitle"
        Me.LpayFromTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LpayFromTitle.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.LpayFromTitle.StylePriority.UseFont = False
        Me.LpayFromTitle.StylePriority.UseTextAlignment = False
        Me.LpayFromTitle.Text = "PROFIT YEAR"
        Me.LpayFromTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LPayFrom
        '
        Me.LPayFrom.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LPayFrom.LocationFloat = New DevExpress.Utils.PointFloat(141.4349!, 73.39639!)
        Me.LPayFrom.Name = "LPayFrom"
        Me.LPayFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPayFrom.SizeF = New System.Drawing.SizeF(349.796!, 16.18694!)
        Me.LPayFrom.StylePriority.UseFont = False
        Me.LPayFrom.StylePriority.UseTextAlignment = False
        Me.LPayFrom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(579.426!, 73.39639!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = ":"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelDate
        '
        Me.LabelDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(597.2501!, 73.39639!)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDate.SizeF = New System.Drawing.SizeF(154.7499!, 16.18694!)
        Me.LabelDate.StylePriority.UseFont = False
        Me.LabelDate.StylePriority.UseTextAlignment = False
        Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(491.2315!, 73.39636!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(88.19446!, 16.18694!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "CREATED DATE"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelBeneficiary
        '
        Me.LabelBeneficiary.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBeneficiary.LocationFloat = New DevExpress.Utils.PointFloat(597.2504!, 89.58337!)
        Me.LabelBeneficiary.Name = "LabelBeneficiary"
        Me.LabelBeneficiary.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelBeneficiary.SizeF = New System.Drawing.SizeF(154.7496!, 16.18694!)
        Me.LabelBeneficiary.StylePriority.UseFont = False
        Me.LabelBeneficiary.StylePriority.UseTextAlignment = False
        Me.LabelBeneficiary.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelDotBeneficiary
        '
        Me.LabelDotBeneficiary.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDotBeneficiary.LocationFloat = New DevExpress.Utils.PointFloat(579.4262!, 89.58334!)
        Me.LabelDotBeneficiary.Name = "LabelDotBeneficiary"
        Me.LabelDotBeneficiary.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDotBeneficiary.SizeF = New System.Drawing.SizeF(17.82406!, 16.18693!)
        Me.LabelDotBeneficiary.StylePriority.UseFont = False
        Me.LabelDotBeneficiary.StylePriority.UseTextAlignment = False
        Me.LabelDotBeneficiary.Text = ":"
        Me.LabelDotBeneficiary.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelTitleBeneficiary
        '
        Me.LabelTitleBeneficiary.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitleBeneficiary.LocationFloat = New DevExpress.Utils.PointFloat(491.2308!, 89.5833!)
        Me.LabelTitleBeneficiary.Name = "LabelTitleBeneficiary"
        Me.LabelTitleBeneficiary.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitleBeneficiary.SizeF = New System.Drawing.SizeF(88.1944!, 16.18693!)
        Me.LabelTitleBeneficiary.StylePriority.UseFont = False
        Me.LabelTitleBeneficiary.StylePriority.UseTextAlignment = False
        Me.LabelTitleBeneficiary.Text = "CREATED BY"
        Me.LabelTitleBeneficiary.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelTitleDueDate
        '
        Me.LabelTitleDueDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitleDueDate.LocationFloat = New DevExpress.Utils.PointFloat(491.2318!, 105.7702!)
        Me.LabelTitleDueDate.Name = "LabelTitleDueDate"
        Me.LabelTitleDueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitleDueDate.SizeF = New System.Drawing.SizeF(88.19446!, 16.18693!)
        Me.LabelTitleDueDate.StylePriority.UseFont = False
        Me.LabelTitleDueDate.StylePriority.UseTextAlignment = False
        Me.LabelTitleDueDate.Text = "REFF DATE"
        Me.LabelTitleDueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelDotDueDate
        '
        Me.LabelDotDueDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDotDueDate.LocationFloat = New DevExpress.Utils.PointFloat(579.426!, 105.7703!)
        Me.LabelDotDueDate.Name = "LabelDotDueDate"
        Me.LabelDotDueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDotDueDate.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.LabelDotDueDate.StylePriority.UseFont = False
        Me.LabelDotDueDate.StylePriority.UseTextAlignment = False
        Me.LabelDotDueDate.Text = ":"
        Me.LabelDotDueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelDUelDate
        '
        Me.LabelDUelDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDUelDate.LocationFloat = New DevExpress.Utils.PointFloat(597.2504!, 105.7703!)
        Me.LabelDUelDate.Name = "LabelDUelDate"
        Me.LabelDUelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDUelDate.SizeF = New System.Drawing.SizeF(154.7496!, 16.18694!)
        Me.LabelDUelDate.StylePriority.UseFont = False
        Me.LabelDUelDate.StylePriority.UseTextAlignment = False
        Me.LabelDUelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(210.4167!, 39.58334!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'LabelTitle
        '
        Me.LabelTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.LocationFloat = New DevExpress.Utils.PointFloat(530.9936!, 0!)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitle.SizeF = New System.Drawing.SizeF(221.006!, 20.0!)
        Me.LabelTitle.StylePriority.UseFont = False
        Me.LabelTitle.StylePriority.UseTextAlignment = False
        Me.LabelTitle.Text = "PERHITUNGAN DEVIDEN"
        Me.LabelTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(751.9996!, 25.0!)
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
        'GCHistory
        '
        Me.GCHistory.Location = New System.Drawing.Point(0, 0)
        Me.GCHistory.MainView = Me.GVHistory
        Me.GCHistory.Name = "GCHistory"
        Me.GCHistory.Size = New System.Drawing.Size(722, 265)
        Me.GCHistory.TabIndex = 2
        Me.GCHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVHistory})
        '
        'GVHistory
        '
        Me.GVHistory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn24, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn25})
        Me.GVHistory.GridControl = Me.GCHistory
        Me.GVHistory.GroupCount = 1
        Me.GVHistory.Name = "GVHistory"
        Me.GVHistory.OptionsBehavior.Editable = False
        Me.GVHistory.OptionsView.ShowFooter = True
        Me.GVHistory.OptionsView.ShowGroupPanel = False
        Me.GVHistory.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn18, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn24, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "ID"
        Me.GridColumn15.FieldName = "id_shareholder_share"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "ID COmp"
        Me.GridColumn16.FieldName = "id_comp"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "PPH Account"
        Me.GridColumn17.FieldName = "pph_account"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Profit Year"
        Me.GridColumn24.FieldName = "profit_year"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 0
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Shareholder"
        Me.GridColumn18.FieldName = "comp_name"
        Me.GridColumn18.FieldNameSortGroup = "id_comp"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 0
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.Caption = "Share (%)"
        Me.GridColumn19.DisplayFormat.FormatString = "{0:N0} %"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "deviden_percent"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 1
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.Caption = "Net Deviden"
        Me.GridColumn20.DisplayFormat.FormatString = "N2"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "deviden_amount"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "deviden_amount", "{0:N2}")})
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 5
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.Caption = "PPH COA"
        Me.GridColumn21.DisplayFormat.FormatString = "N2"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "pph_desc"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn22.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn22.Caption = "PPH (%)"
        Me.GridColumn22.DisplayFormat.FormatString = "{0:N0} %"
        Me.GridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn22.FieldName = "pph_percent"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 3
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.Caption = "PPH Amount"
        Me.GridColumn23.DisplayFormat.FormatString = "N2"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn23.FieldName = "pph_amount"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph_amount", "{0:N2}")})
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 4
        '
        'GridColumn25
        '
        Me.GridColumn25.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.Caption = "Deviden"
        Me.GridColumn25.DisplayFormat.FormatString = "N2"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn25.FieldName = "deviden"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.UnboundExpression = "[pph_amount] + [deviden_amount]"
        Me.GridColumn25.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 2
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(752.0001!, 276.0417!)
        Me.WinControlContainer1.WinControl = Me.GCHistory
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(141.4352!, 89.58334!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(143.5457!, 16.18693!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 89.58334!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "PROFIT AMOUNT"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(123.6111!, 89.5834!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = ":"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(123.6111!, 105.7703!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = ":"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 105.7703!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(123.6111!, 16.18693!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "DEVIDEN AMOUNT"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(141.4352!, 105.7703!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(143.5457!, 16.18693!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel9
        '
        Me.XrLabel9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(300.6058!, 105.7703!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(82.98608!, 16.18693!)
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "% TO PROFIT"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel10
        '
        Me.XrLabel10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(383.5919!, 105.7702!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = ":"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(401.416!, 105.7702!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(49.19086!, 16.18693!)
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'ReportDeviden
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportFooter, Me.PageHeader})
        Me.Margins = New System.Drawing.Printing.Margins(29, 46, 8, 23)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents LpayFromMark As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LpayFromTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPayFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelBeneficiary As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDotBeneficiary As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTitleBeneficiary As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTitleDueDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDotDueDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDUelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents LabelTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCHistory As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVHistory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
End Class
