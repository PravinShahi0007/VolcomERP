<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportEmpOvertimeMemo
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportEmpOvertimeMemo))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.SubBand1 = New DevExpress.XtraReports.UI.SubBand()
        Me.XPFrom = New DevExpress.XtraReports.UI.XRPanel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLHal = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLFromPosition = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLFrom = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLTo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLToPosition = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLCC1Dot = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLCC1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLCC1Position = New DevExpress.XtraReports.UI.XRLabel()
        Me.XPCC = New DevExpress.XtraReports.UI.XRPanel()
        Me.XLCC2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLCC2Dot = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLCC2Position = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLCC3Dot = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLCC3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLCC3Position = New DevExpress.XtraReports.UI.XRLabel()
        Me.SubBand2 = New DevExpress.XtraReports.UI.SubBand()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLText = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrPictureBox2 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRowHeader = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRowFooter = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellPersonTotal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellConsumptionTotal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XLNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.SubBand3 = New DevExpress.XtraReports.UI.SubBand()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.HeightF = 0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.SubBands.AddRange(New DevExpress.XtraReports.UI.SubBand() {Me.SubBand1, Me.SubBand2, Me.SubBand3})
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'SubBand1
        '
        Me.SubBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XPFrom, Me.XrLabel3, Me.XrLabel4, Me.XrLabel6, Me.XLTo, Me.XLToPosition, Me.XLCC1Dot, Me.XLCC1, Me.XLCC1Position, Me.XPCC})
        Me.SubBand1.HeightF = 176.0!
        Me.SubBand1.Name = "SubBand1"
        '
        'XPFrom
        '
        Me.XPFrom.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5, Me.XrLabel19, Me.XLHal, Me.XLFromPosition, Me.XLFrom, Me.XrLabel10, Me.XrLabel18})
        Me.XPFrom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 112.0!)
        Me.XPFrom.Name = "XPFrom"
        Me.XPFrom.SizeF = New System.Drawing.SizeF(686.9999!, 57.0!)
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(150.0!, 23.0!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = "Dari"
        '
        'XrLabel19
        '
        Me.XrLabel19.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(150.0001!, 32.99999!)
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(23.0!, 23.0!)
        Me.XrLabel19.StylePriority.UseFont = False
        Me.XrLabel19.Text = ":"
        '
        'XLHal
        '
        Me.XLHal.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLHal.LocationFloat = New DevExpress.Utils.PointFloat(173.0!, 32.99999!)
        Me.XLHal.Name = "XLHal"
        Me.XLHal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLHal.SizeF = New System.Drawing.SizeF(514.0!, 23.00001!)
        Me.XLHal.StylePriority.UseFont = False
        '
        'XLFromPosition
        '
        Me.XLFromPosition.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLFromPosition.LocationFloat = New DevExpress.Utils.PointFloat(436.9997!, 0!)
        Me.XLFromPosition.Name = "XLFromPosition"
        Me.XLFromPosition.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLFromPosition.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
        Me.XLFromPosition.StylePriority.UseFont = False
        '
        'XLFrom
        '
        Me.XLFrom.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLFrom.LocationFloat = New DevExpress.Utils.PointFloat(173.0!, 0!)
        Me.XLFrom.Name = "XLFrom"
        Me.XLFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLFrom.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
        Me.XLFrom.StylePriority.UseFont = False
        '
        'XrLabel10
        '
        Me.XrLabel10.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(150.0001!, 0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(23.0!, 23.0!)
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.Text = ":"
        '
        'XrLabel18
        '
        Me.XrLabel18.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.99999!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(150.0!, 23.0!)
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.Text = "Hal"
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(150.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "Kepada"
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.99996!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(150.0!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = "CC"
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(150.0001!, 0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(23.0!, 23.0!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.Text = ":"
        '
        'XLTo
        '
        Me.XLTo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XLTo.LocationFloat = New DevExpress.Utils.PointFloat(173.0!, 0!)
        Me.XLTo.Name = "XLTo"
        Me.XLTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTo.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
        Me.XLTo.StylePriority.UseFont = False
        '
        'XLToPosition
        '
        Me.XLToPosition.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XLToPosition.LocationFloat = New DevExpress.Utils.PointFloat(437.0!, 0!)
        Me.XLToPosition.Name = "XLToPosition"
        Me.XLToPosition.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLToPosition.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
        Me.XLToPosition.StylePriority.UseFont = False
        '
        'XLCC1Dot
        '
        Me.XLCC1Dot.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLCC1Dot.LocationFloat = New DevExpress.Utils.PointFloat(150.0001!, 32.99996!)
        Me.XLCC1Dot.Name = "XLCC1Dot"
        Me.XLCC1Dot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCC1Dot.SizeF = New System.Drawing.SizeF(23.0!, 23.0!)
        Me.XLCC1Dot.StylePriority.UseFont = False
        Me.XLCC1Dot.Text = ":"
        '
        'XLCC1
        '
        Me.XLCC1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLCC1.LocationFloat = New DevExpress.Utils.PointFloat(173.0!, 32.99996!)
        Me.XLCC1.Name = "XLCC1"
        Me.XLCC1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCC1.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
        Me.XLCC1.StylePriority.UseFont = False
        '
        'XLCC1Position
        '
        Me.XLCC1Position.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLCC1Position.LocationFloat = New DevExpress.Utils.PointFloat(437.0!, 32.99996!)
        Me.XLCC1Position.Name = "XLCC1Position"
        Me.XLCC1Position.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCC1Position.SizeF = New System.Drawing.SizeF(249.9999!, 23.0!)
        Me.XLCC1Position.StylePriority.UseFont = False
        '
        'XPCC
        '
        Me.XPCC.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLCC2, Me.XLCC2Dot, Me.XLCC2Position, Me.XLCC3Dot, Me.XLCC3, Me.XLCC3Position})
        Me.XPCC.LocationFloat = New DevExpress.Utils.PointFloat(150.0001!, 55.99998!)
        Me.XPCC.Name = "XPCC"
        Me.XPCC.SizeF = New System.Drawing.SizeF(536.9996!, 46.00003!)
        '
        'XLCC2
        '
        Me.XLCC2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLCC2.LocationFloat = New DevExpress.Utils.PointFloat(22.99989!, 0!)
        Me.XLCC2.Name = "XLCC2"
        Me.XLCC2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCC2.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
        Me.XLCC2.StylePriority.UseFont = False
        '
        'XLCC2Dot
        '
        Me.XLCC2Dot.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLCC2Dot.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XLCC2Dot.Name = "XLCC2Dot"
        Me.XLCC2Dot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCC2Dot.SizeF = New System.Drawing.SizeF(23.0!, 23.0!)
        Me.XLCC2Dot.StylePriority.UseFont = False
        Me.XLCC2Dot.Text = ":"
        '
        'XLCC2Position
        '
        Me.XLCC2Position.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLCC2Position.LocationFloat = New DevExpress.Utils.PointFloat(286.9999!, 0!)
        Me.XLCC2Position.Name = "XLCC2Position"
        Me.XLCC2Position.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCC2Position.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
        Me.XLCC2Position.StylePriority.UseFont = False
        '
        'XLCC3Dot
        '
        Me.XLCC3Dot.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLCC3Dot.LocationFloat = New DevExpress.Utils.PointFloat(0!, 23.00002!)
        Me.XLCC3Dot.Name = "XLCC3Dot"
        Me.XLCC3Dot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCC3Dot.SizeF = New System.Drawing.SizeF(23.0!, 23.0!)
        Me.XLCC3Dot.StylePriority.UseFont = False
        Me.XLCC3Dot.Text = ":"
        '
        'XLCC3
        '
        Me.XLCC3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLCC3.LocationFloat = New DevExpress.Utils.PointFloat(22.99986!, 22.99999!)
        Me.XLCC3.Name = "XLCC3"
        Me.XLCC3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCC3.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
        Me.XLCC3.StylePriority.UseFont = False
        '
        'XLCC3Position
        '
        Me.XLCC3Position.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLCC3Position.LocationFloat = New DevExpress.Utils.PointFloat(286.9999!, 22.99999!)
        Me.XLCC3Position.Name = "XLCC3Position"
        Me.XLCC3Position.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCC3Position.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
        Me.XLCC3Position.StylePriority.UseFont = False
        '
        'SubBand2
        '
        Me.SubBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable, Me.XrLabel21, Me.XLText, Me.XrLine1})
        Me.SubBand2.HeightF = 162.9999!
        Me.SubBand2.Name = "SubBand2"
        '
        'XrLabel21
        '
        Me.XrLabel21.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.99999!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(686.9998!, 23.0!)
        Me.XrLabel21.StylePriority.UseFont = False
        Me.XrLabel21.Text = "Dengan hormat,"
        '
        'XLText
        '
        Me.XLText.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLText.LocationFloat = New DevExpress.Utils.PointFloat(0!, 70.99997!)
        Me.XLText.Multiline = True
        Me.XLText.Name = "XLText"
        Me.XLText.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLText.SizeF = New System.Drawing.SizeF(686.9999!, 46.0!)
        Me.XLText.StylePriority.UseFont = False
        Me.XLText.Text = "Sehubungan dengan rencana lembur [departement], bersama ini mohon disiapkan dana " &
    "konsumsi sebesar sebagai berikut:"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 104.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(687.0!, 25.0!)
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
        'XrLine1
        '
        Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine1.BorderWidth = 1.0!
        Me.XrLine1.LineWidth = 2
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(686.9999!, 10.0!)
        Me.XrLine1.StylePriority.UseBorders = False
        Me.XrLine1.StylePriority.UseBorderWidth = False
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 30.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(239.5636!, 0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(210.2772!, 150.0!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel1
        '
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 16.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 160.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(686.9999!, 27.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "MEMO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 70.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 11.75!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.00007529007!, 187.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(686.9999!, 25.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "[number]"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.XrLabel1, Me.XrLabel2})
        Me.ReportHeader.HeightF = 237.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox2})
        Me.ReportFooter.HeightF = 67.9742!
        Me.ReportFooter.Name = "ReportFooter"
        Me.ReportFooter.PrintAtBottom = True
        '
        'XrPictureBox2
        '
        Me.XrPictureBox2.Image = CType(resources.GetObject("XrPictureBox2.Image"), System.Drawing.Image)
        Me.XrPictureBox2.LocationFloat = New DevExpress.Utils.PointFloat(192.0614!, 0!)
        Me.XrPictureBox2.Name = "XrPictureBox2"
        Me.XrPictureBox2.SizeF = New System.Drawing.SizeF(300.0!, 67.9742!)
        Me.XrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(0!, 51.00001!)
        Me.XrLabel7.Multiline = True
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(686.9999!, 23.0!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.Text = "Demikian kami sampaikan atas perhatian dan kerjasama yang baik kami ucapkan terim" &
    "a kasih."
        '
        'XrTable
        '
        Me.XrTable.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrTable.LocationFloat = New DevExpress.Utils.PointFloat(0!, 116.9999!)
        Me.XrTable.Name = "XrTable"
        Me.XrTable.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowHeader, Me.XrTableRowFooter})
        Me.XrTable.SizeF = New System.Drawing.SizeF(686.9997!, 46.0!)
        Me.XrTable.StylePriority.UseBorders = False
        Me.XrTable.StylePriority.UseFont = False
        '
        'XrTableRowHeader
        '
        Me.XrTableRowHeader.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTableRowHeader.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell5, Me.XrTableCell6, Me.XrTableCell7})
        Me.XrTableRowHeader.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableRowHeader.Name = "XrTableRowHeader"
        Me.XrTableRowHeader.StylePriority.UseBackColor = False
        Me.XrTableRowHeader.StylePriority.UseFont = False
        Me.XrTableRowHeader.StylePriority.UseTextAlignment = False
        Me.XrTableRowHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableRowHeader.Weight = 0.92R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100.0!)
        Me.XrTableCell5.StylePriority.UsePadding = False
        Me.XrTableCell5.Text = "Tanggal"
        Me.XrTableCell5.Weight = 1.1974286192967509R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100.0!)
        Me.XrTableCell6.StylePriority.UsePadding = False
        Me.XrTableCell6.Text = "Jumlah Orang"
        Me.XrTableCell6.Weight = 0.621810114450475R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100.0!)
        Me.XrTableCell7.StylePriority.UsePadding = False
        Me.XrTableCell7.Text = "Jumlah Konsumsi"
        Me.XrTableCell7.Weight = 0.62180908431720627R
        '
        'XrTableRowFooter
        '
        Me.XrTableRowFooter.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTableRowFooter.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell8, Me.XrTableCellPersonTotal, Me.XrTableCellConsumptionTotal})
        Me.XrTableRowFooter.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableRowFooter.Name = "XrTableRowFooter"
        Me.XrTableRowFooter.StylePriority.UseBackColor = False
        Me.XrTableRowFooter.StylePriority.UseFont = False
        Me.XrTableRowFooter.StylePriority.UseTextAlignment = False
        Me.XrTableRowFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableRowFooter.Weight = 0.92R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100.0!)
        Me.XrTableCell8.StylePriority.UsePadding = False
        Me.XrTableCell8.Text = "Total"
        Me.XrTableCell8.Weight = 1.1974286192967509R
        '
        'XrTableCellPersonTotal
        '
        Me.XrTableCellPersonTotal.Name = "XrTableCellPersonTotal"
        Me.XrTableCellPersonTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100.0!)
        Me.XrTableCellPersonTotal.StylePriority.UsePadding = False
        Me.XrTableCellPersonTotal.Text = "[person_total]"
        Me.XrTableCellPersonTotal.Weight = 0.621810114450475R
        '
        'XrTableCellConsumptionTotal
        '
        Me.XrTableCellConsumptionTotal.Name = "XrTableCellConsumptionTotal"
        Me.XrTableCellConsumptionTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100.0!)
        Me.XrTableCellConsumptionTotal.StylePriority.UsePadding = False
        Me.XrTableCellConsumptionTotal.Text = "[consumption_total]"
        Me.XrTableCellConsumptionTotal.Weight = 0.62180908431720627R
        '
        'XLNote
        '
        Me.XLNote.Font = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Italic)
        Me.XLNote.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.999955!)
        Me.XLNote.Name = "XLNote"
        Me.XLNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLNote.SizeF = New System.Drawing.SizeF(686.9998!, 23.0!)
        Me.XLNote.StylePriority.UseFont = False
        Me.XLNote.Text = "*) konsumsi Rp. [ot_consumption] / orang"
        '
        'SubBand3
        '
        Me.SubBand3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLNote, Me.XrLabel7, Me.XrTable1})
        Me.SubBand3.HeightF = 129.0!
        Me.SubBand3.Name = "SubBand3"
        '
        'ReportEmpOvertimeMemo
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Margins = New System.Drawing.Printing.Margins(70, 70, 30, 70)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "15.1"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XLText As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLHal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLFromPosition As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLCC2Position As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLCC1Position As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLCC2Dot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLCC2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLCC1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLCC1Dot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLToPosition As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLTo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPictureBox2 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents SubBand1 As DevExpress.XtraReports.UI.SubBand
    Friend WithEvents SubBand2 As DevExpress.XtraReports.UI.SubBand
    Friend WithEvents XLCC3Position As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLCC3Dot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLCC3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XPFrom As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XPCC As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRowHeader As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRowFooter As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellPersonTotal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellConsumptionTotal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XLNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents SubBand3 As DevExpress.XtraReports.UI.SubBand
End Class
