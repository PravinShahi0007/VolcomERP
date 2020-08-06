<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportVA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportVA))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.LabelTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTransDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnno = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsales_order_ol_shop_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncustomer_name = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsettlement_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnpay_type = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandPaymentGate = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnpayment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandERP = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumninvoice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnship_invoice_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumninvoice_amount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_order = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncheckout_id = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 300.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelTitle, Me.LabelNumber, Me.XrPictureBox1})
        Me.TopMargin.HeightF = 72.91666!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1, Me.XrLabel8})
        Me.BottomMargin.HeightF = 47.91667!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelTransDate, Me.XrLabel3, Me.XrLabel1, Me.XrLabel11, Me.XrLabel10, Me.LabelDate})
        Me.PageHeader.HeightF = 48.95833!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel11
        '
        Me.XrLabel11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(811.5313!, 0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(98.72699!, 16.18692!)
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "CREATED DATE"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel10
        '
        Me.XrLabel10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(910.2585!, 0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = ":"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'LabelDate
        '
        Me.LabelDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(928.0825!, 0!)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDate.SizeF = New System.Drawing.SizeF(122.9174!, 16.18692!)
        Me.LabelDate.StylePriority.UseFont = False
        Me.LabelDate.StylePriority.UseTextAlignment = False
        Me.LabelDate.Text = "01/12/2017"
        Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 23.33333!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(210.4167!, 39.58334!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'LabelTitle
        '
        Me.LabelTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.LocationFloat = New DevExpress.Utils.PointFloat(578.9521!, 23.33333!)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTitle.SizeF = New System.Drawing.SizeF(472.0478!, 25.08334!)
        Me.LabelTitle.StylePriority.UseFont = False
        Me.LabelTitle.StylePriority.UseTextAlignment = False
        Me.LabelTitle.Text = "PAYOUT VIRTUAL ACCOUNT"
        Me.LabelTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'LabelNumber
        '
        Me.LabelNumber.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumber.LocationFloat = New DevExpress.Utils.PointFloat(734.5479!, 48.41666!)
        Me.LabelNumber.Name = "LabelNumber"
        Me.LabelNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNumber.SizeF = New System.Drawing.SizeF(316.4521!, 14.5!)
        Me.LabelNumber.StylePriority.UseFont = False
        Me.LabelNumber.StylePriority.UseTextAlignment = False
        Me.LabelNumber.Text = "0000000"
        Me.LabelNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(811.5313!, 16.18692!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(98.72699!, 16.18692!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "TRANS. DATE"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(910.2585!, 16.18692!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(17.82407!, 16.18692!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = ":"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'LabelTransDate
        '
        Me.LabelTransDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTransDate.LocationFloat = New DevExpress.Utils.PointFloat(928.0825!, 16.18692!)
        Me.LabelTransDate.Name = "LabelTransDate"
        Me.LabelTransDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTransDate.SizeF = New System.Drawing.SizeF(122.9174!, 16.18692!)
        Me.LabelTransDate.StylePriority.UseFont = False
        Me.LabelTransDate.StylePriority.UseTextAlignment = False
        Me.LabelTransDate.Text = "01/12/2017"
        Me.LabelTransDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.ReportFooter.HeightF = 48.95833!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Lucida Sans", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.Gray
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(548.8425!, 16.04167!)
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "Printed from Volcom ERP ([printed_date])"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(901.0001!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1051.0!, 25.0!)
        Me.XrTable1.StylePriority.UseBorders = False
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
        'GCData
        '
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(1009, 263)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBandPaymentGate, Me.gridBandERP})
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnsettlement_date, Me.BandedGridColumnpay_type, Me.BandedGridColumnid_order, Me.BandedGridColumnsales_order_ol_shop_number, Me.BandedGridColumncustomer_name, Me.BandedGridColumncheckout_id, Me.BandedGridColumnpayment, Me.BandedGridColumninvoice, Me.BandedGridColumninvoice_amount, Me.BandedGridColumnno, Me.BandedGridColumnship_invoice_number})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.BandedGridColumnno)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnsales_order_ol_shop_number)
        Me.GridBand1.Columns.Add(Me.BandedGridColumncustomer_name)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnsettlement_date)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnpay_type)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 429
        '
        'BandedGridColumnno
        '
        Me.BandedGridColumnno.Caption = "No"
        Me.BandedGridColumnno.FieldName = "no"
        Me.BandedGridColumnno.Name = "BandedGridColumnno"
        Me.BandedGridColumnno.Visible = True
        Me.BandedGridColumnno.Width = 45
        '
        'BandedGridColumnsales_order_ol_shop_number
        '
        Me.BandedGridColumnsales_order_ol_shop_number.Caption = "Order No"
        Me.BandedGridColumnsales_order_ol_shop_number.FieldName = "sales_order_ol_shop_number"
        Me.BandedGridColumnsales_order_ol_shop_number.Name = "BandedGridColumnsales_order_ol_shop_number"
        Me.BandedGridColumnsales_order_ol_shop_number.Visible = True
        Me.BandedGridColumnsales_order_ol_shop_number.Width = 90
        '
        'BandedGridColumncustomer_name
        '
        Me.BandedGridColumncustomer_name.Caption = "Cust."
        Me.BandedGridColumncustomer_name.FieldName = "customer_name"
        Me.BandedGridColumncustomer_name.Name = "BandedGridColumncustomer_name"
        Me.BandedGridColumncustomer_name.Visible = True
        '
        'BandedGridColumnsettlement_date
        '
        Me.BandedGridColumnsettlement_date.Caption = "Trans. Date"
        Me.BandedGridColumnsettlement_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.BandedGridColumnsettlement_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnsettlement_date.FieldName = "transaction_date"
        Me.BandedGridColumnsettlement_date.Name = "BandedGridColumnsettlement_date"
        Me.BandedGridColumnsettlement_date.Visible = True
        Me.BandedGridColumnsettlement_date.Width = 144
        '
        'BandedGridColumnpay_type
        '
        Me.BandedGridColumnpay_type.Caption = "Pay Type"
        Me.BandedGridColumnpay_type.FieldName = "pay_type"
        Me.BandedGridColumnpay_type.Name = "BandedGridColumnpay_type"
        Me.BandedGridColumnpay_type.Visible = True
        '
        'gridBandPaymentGate
        '
        Me.gridBandPaymentGate.Caption = "Payment Gateway"
        Me.gridBandPaymentGate.Columns.Add(Me.BandedGridColumnpayment)
        Me.gridBandPaymentGate.Name = "gridBandPaymentGate"
        Me.gridBandPaymentGate.VisibleIndex = 1
        Me.gridBandPaymentGate.Width = 135
        '
        'BandedGridColumnpayment
        '
        Me.BandedGridColumnpayment.Caption = "Amount"
        Me.BandedGridColumnpayment.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnpayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnpayment.FieldName = "payment"
        Me.BandedGridColumnpayment.Name = "BandedGridColumnpayment"
        Me.BandedGridColumnpayment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "payment", "{0:N2}")})
        Me.BandedGridColumnpayment.Visible = True
        Me.BandedGridColumnpayment.Width = 135
        '
        'gridBandERP
        '
        Me.gridBandERP.Caption = "ERP"
        Me.gridBandERP.Columns.Add(Me.BandedGridColumninvoice)
        Me.gridBandERP.Columns.Add(Me.BandedGridColumnship_invoice_number)
        Me.gridBandERP.Columns.Add(Me.BandedGridColumninvoice_amount)
        Me.gridBandERP.Name = "gridBandERP"
        Me.gridBandERP.VisibleIndex = 2
        Me.gridBandERP.Width = 253
        '
        'BandedGridColumninvoice
        '
        Me.BandedGridColumninvoice.Caption = "Invoice No."
        Me.BandedGridColumninvoice.FieldName = "invoice_number"
        Me.BandedGridColumninvoice.Name = "BandedGridColumninvoice"
        Me.BandedGridColumninvoice.Visible = True
        Me.BandedGridColumninvoice.Width = 89
        '
        'BandedGridColumnship_invoice_number
        '
        Me.BandedGridColumnship_invoice_number.Caption = "Invoice Ship"
        Me.BandedGridColumnship_invoice_number.FieldName = "ship_invoice_number"
        Me.BandedGridColumnship_invoice_number.Name = "BandedGridColumnship_invoice_number"
        Me.BandedGridColumnship_invoice_number.Visible = True
        '
        'BandedGridColumninvoice_amount
        '
        Me.BandedGridColumninvoice_amount.Caption = "Amount"
        Me.BandedGridColumninvoice_amount.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumninvoice_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumninvoice_amount.FieldName = "invoice_amount"
        Me.BandedGridColumninvoice_amount.Name = "BandedGridColumninvoice_amount"
        Me.BandedGridColumninvoice_amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "invoice_amount", "{0:N2}")})
        Me.BandedGridColumninvoice_amount.Visible = True
        Me.BandedGridColumninvoice_amount.Width = 89
        '
        'BandedGridColumnid_order
        '
        Me.BandedGridColumnid_order.Caption = "id_order"
        Me.BandedGridColumnid_order.FieldName = "id_order"
        Me.BandedGridColumnid_order.Name = "BandedGridColumnid_order"
        '
        'BandedGridColumncheckout_id
        '
        Me.BandedGridColumncheckout_id.Caption = "Checkout Id"
        Me.BandedGridColumncheckout_id.FieldName = "checkout_id"
        Me.BandedGridColumncheckout_id.Name = "BandedGridColumncheckout_id"
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1051.0!, 274.0417!)
        Me.WinControlContainer1.WinControl = Me.GCData
        '
        'ReportVA
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(51, 67, 73, 48)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents LabelTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTransDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnno As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsales_order_ol_shop_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncustomer_name As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsettlement_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnpay_type As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandPaymentGate As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnpayment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandERP As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumninvoice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnship_invoice_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumninvoice_amount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_order As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncheckout_id As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
