<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportMBalanceSheet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportMBalanceSheet))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XTPasiva = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XTRowPasiva = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XTAktiva = New DevExpress.XtraReports.UI.XRTable()
        Me.XRTableRowAktiva = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XtRowAsset = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XRTotalPasivaDesc = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XRTotalPasiva = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XRTotalPasivaPercent = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XRTotalAssetDesc = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XRTotalAsset = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XRTotalAssetPercent = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XRTableMark = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XTPasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTAktiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XRTableMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XTPasiva, Me.XTAktiva})
        Me.Detail.HeightF = 57.40386!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XTPasiva
        '
        Me.XTPasiva.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XTPasiva.BorderWidth = 1.0!
        Me.XTPasiva.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.XTPasiva.LocationFloat = New DevExpress.Utils.PointFloat(366.0!, 0!)
        Me.XTPasiva.Name = "XTPasiva"
        Me.XTPasiva.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100.0!)
        Me.XTPasiva.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2, Me.XTRowPasiva})
        Me.XTPasiva.SizeF = New System.Drawing.SizeF(360.0!, 55.0!)
        Me.XTPasiva.StylePriority.UseBorders = False
        Me.XTPasiva.StylePriority.UseBorderWidth = False
        Me.XTPasiva.StylePriority.UseFont = False
        Me.XTPasiva.StylePriority.UsePadding = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell8, Me.XrTableCell9, Me.XrTableCell10})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell8.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.StylePriority.UseBorders = False
        Me.XrTableCell8.StylePriority.UseFont = False
        Me.XrTableCell8.StylePriority.UseTextAlignment = False
        Me.XrTableCell8.Text = "DESCRIPTION"
        Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell8.Weight = 1.471026385668873R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.StylePriority.UseFont = False
        Me.XrTableCell9.StylePriority.UseTextAlignment = False
        Me.XrTableCell9.Text = "AMOUNT (IDR)"
        Me.XrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell9.Weight = 0.98068426112875617R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.StylePriority.UseFont = False
        Me.XrTableCell10.StylePriority.UseTextAlignment = False
        Me.XrTableCell10.Text = "% TO TOTAL ASSET"
        Me.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell10.Weight = 0.75780148053284579R
        '
        'XTRowPasiva
        '
        Me.XTRowPasiva.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell12, Me.XrTableCell13, Me.XrTableCell14})
        Me.XTRowPasiva.Name = "XTRowPasiva"
        Me.XTRowPasiva.Weight = 0.375R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell12.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.StylePriority.UseBorders = False
        Me.XrTableCell12.StylePriority.UseFont = False
        Me.XrTableCell12.StylePriority.UseTextAlignment = False
        Me.XrTableCell12.Text = "LIABILIIES & EQUITY"
        Me.XrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell12.Weight = 1.471026385668873R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.StylePriority.UseFont = False
        Me.XrTableCell13.StylePriority.UseTextAlignment = False
        Me.XrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell13.Weight = 0.98068426112875617R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.StylePriority.UseFont = False
        Me.XrTableCell14.StylePriority.UseTextAlignment = False
        Me.XrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell14.Weight = 0.75780148053284579R
        '
        'XTAktiva
        '
        Me.XTAktiva.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XTAktiva.BorderWidth = 1.0!
        Me.XTAktiva.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.XTAktiva.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XTAktiva.Name = "XTAktiva"
        Me.XTAktiva.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100.0!)
        Me.XTAktiva.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XRTableRowAktiva, Me.XtRowAsset})
        Me.XTAktiva.SizeF = New System.Drawing.SizeF(366.0!, 55.0!)
        Me.XTAktiva.StylePriority.UseBorders = False
        Me.XTAktiva.StylePriority.UseBorderWidth = False
        Me.XTAktiva.StylePriority.UseFont = False
        Me.XTAktiva.StylePriority.UsePadding = False
        '
        'XRTableRowAktiva
        '
        Me.XRTableRowAktiva.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell4})
        Me.XRTableRowAktiva.Name = "XRTableRowAktiva"
        Me.XRTableRowAktiva.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.Text = "DESCRIPTION"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell1.Weight = 1.4710263854970316R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.Text = "AMOUNT (IDR)"
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell2.Weight = 0.9806842612433172R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        Me.XrTableCell3.Text = "% TO TOTAL ASSET"
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell3.Weight = 0.75780148059012642R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.StylePriority.UseBorders = False
        Me.XrTableCell4.Weight = 0.053491864595908482R
        '
        'XtRowAsset
        '
        Me.XtRowAsset.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell5, Me.XrTableCell6, Me.XrTableCell7, Me.XrTableCell11})
        Me.XtRowAsset.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.XtRowAsset.Name = "XtRowAsset"
        Me.XtRowAsset.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100.0!)
        Me.XtRowAsset.StylePriority.UseFont = False
        Me.XtRowAsset.StylePriority.UsePadding = False
        Me.XtRowAsset.Weight = 0.375R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100.0!)
        Me.XrTableCell5.StylePriority.UseFont = False
        Me.XrTableCell5.StylePriority.UsePadding = False
        Me.XrTableCell5.StylePriority.UseTextAlignment = False
        Me.XrTableCell5.Text = "ASSETS"
        Me.XrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell5.Weight = 1.4710263854970316R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.StylePriority.UseFont = False
        Me.XrTableCell6.StylePriority.UseTextAlignment = False
        Me.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell6.Weight = 0.9806842612433172R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.StylePriority.UseFont = False
        Me.XrTableCell7.StylePriority.UseTextAlignment = False
        Me.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell7.Weight = 0.75780148059012642R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.StylePriority.UseBorders = False
        Me.XrTableCell11.Weight = 0.053491864595908482R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 32.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 21.48438!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.LTitle})
        Me.PageHeader.HeightF = 83.24319!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(328.8541!, 23.00001!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(66.14587!, 54.47917!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(727.0!, 23.0!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "BALANCE SHEET"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XRTableMark, Me.XrTable2, Me.XrTable1})
        Me.ReportFooter.HeightF = 57.05128!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable2
        '
        Me.XrTable2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.BorderWidth = 1.0!
        Me.XrTable2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(366.0!, 0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100.0!)
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(360.0!, 15.0!)
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseBorderWidth = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UsePadding = False
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XRTotalPasivaDesc, Me.XRTotalPasiva, Me.XRTotalPasivaPercent})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 0.375R
        '
        'XRTotalPasivaDesc
        '
        Me.XRTotalPasivaDesc.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XRTotalPasivaDesc.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XRTotalPasivaDesc.Name = "XRTotalPasivaDesc"
        Me.XRTotalPasivaDesc.StylePriority.UseBorders = False
        Me.XRTotalPasivaDesc.StylePriority.UseFont = False
        Me.XRTotalPasivaDesc.StylePriority.UseTextAlignment = False
        Me.XRTotalPasivaDesc.Text = "TOTAL LIABILIIES & EQUITY"
        Me.XRTotalPasivaDesc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XRTotalPasivaDesc.Weight = 1.471026385668873R
        '
        'XRTotalPasiva
        '
        Me.XRTotalPasiva.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XRTotalPasiva.Name = "XRTotalPasiva"
        Me.XRTotalPasiva.StylePriority.UseFont = False
        Me.XRTotalPasiva.StylePriority.UseTextAlignment = False
        Me.XRTotalPasiva.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XRTotalPasiva.Weight = 0.98068426112875617R
        '
        'XRTotalPasivaPercent
        '
        Me.XRTotalPasivaPercent.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XRTotalPasivaPercent.Name = "XRTotalPasivaPercent"
        Me.XRTotalPasivaPercent.StylePriority.UseFont = False
        Me.XRTotalPasivaPercent.StylePriority.UseTextAlignment = False
        Me.XRTotalPasivaPercent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XRTotalPasivaPercent.Weight = 0.75780148053284579R
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.BorderWidth = 1.0!
        Me.XrTable1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(366.0!, 15.0!)
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseBorderWidth = False
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UsePadding = False
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XRTotalAssetDesc, Me.XRTotalAsset, Me.XRTotalAssetPercent, Me.XrTableCell22})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100.0!)
        Me.XrTableRow3.StylePriority.UsePadding = False
        Me.XrTableRow3.Weight = 0.375R
        '
        'XRTotalAssetDesc
        '
        Me.XRTotalAssetDesc.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XRTotalAssetDesc.Name = "XRTotalAssetDesc"
        Me.XRTotalAssetDesc.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100.0!)
        Me.XRTotalAssetDesc.StylePriority.UseFont = False
        Me.XRTotalAssetDesc.StylePriority.UsePadding = False
        Me.XRTotalAssetDesc.StylePriority.UseTextAlignment = False
        Me.XRTotalAssetDesc.Text = "TOTAL ASSETS"
        Me.XRTotalAssetDesc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XRTotalAssetDesc.Weight = 1.4710263854970316R
        '
        'XRTotalAsset
        '
        Me.XRTotalAsset.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XRTotalAsset.Name = "XRTotalAsset"
        Me.XRTotalAsset.StylePriority.UseFont = False
        Me.XRTotalAsset.StylePriority.UseTextAlignment = False
        Me.XRTotalAsset.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XRTotalAsset.Weight = 0.9806842612433172R
        '
        'XRTotalAssetPercent
        '
        Me.XRTotalAssetPercent.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XRTotalAssetPercent.Name = "XRTotalAssetPercent"
        Me.XRTotalAssetPercent.StylePriority.UseFont = False
        Me.XRTotalAssetPercent.StylePriority.UseTextAlignment = False
        Me.XRTotalAssetPercent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XRTotalAssetPercent.Weight = 0.75780148059012642R
        '
        'XrTableCell22
        '
        Me.XrTableCell22.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell22.Name = "XrTableCell22"
        Me.XrTableCell22.StylePriority.UseBorders = False
        Me.XrTableCell22.Weight = 0.053491864595908482R
        '
        'XRTableMark
        '
        Me.XRTableMark.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XRTableMark.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XRTableMark.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.05128!)
        Me.XRTableMark.Name = "XRTableMark"
        Me.XRTableMark.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XRTableMark.SizeF = New System.Drawing.SizeF(726.0!, 25.0!)
        Me.XRTableMark.StylePriority.UseBorders = False
        Me.XRTableMark.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell15})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell15
        '
        Me.XrTableCell15.Font = New System.Drawing.Font("Lucida Console", 8.0!)
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.StylePriority.UseFont = False
        Me.XrTableCell15.Text = "Here Table Mark Goes, Please Ignore This"
        Me.XrTableCell15.Visible = False
        Me.XrTableCell15.Weight = 2.99999986405489R
        '
        'ReportMBalanceSheet
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter})
        Me.Margins = New System.Drawing.Printing.Margins(48, 52, 32, 21)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.XTPasiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTAktiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XRTableMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XTAktiva As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XRTableRowAktiva As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XTPasiva As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XtRowAsset As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XTRowPasiva As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XRTotalPasivaDesc As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XRTotalPasiva As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XRTotalPasivaPercent As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XRTotalAssetDesc As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XRTotalAsset As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XRTotalAssetPercent As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XRTableMark As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
End Class
