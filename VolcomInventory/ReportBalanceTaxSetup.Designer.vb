<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportBalanceTaxSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportBalanceTaxSetup))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCSetupTax = New DevExpress.XtraGrid.GridControl()
        Me.GVSetupTax = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XLTaxReport = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XLNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XLTag = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCSetupTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSetupTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 100.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(755.9998!, 90.0!)
        Me.WinControlContainer1.WinControl = Me.GCSetupTax
        '
        'GCSetupTax
        '
        Me.GCSetupTax.Location = New System.Drawing.Point(0, 125)
        Me.GCSetupTax.MainView = Me.GVSetupTax
        Me.GCSetupTax.Name = "GCSetupTax"
        Me.GCSetupTax.Size = New System.Drawing.Size(726, 86)
        Me.GCSetupTax.TabIndex = 4
        Me.GCSetupTax.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSetupTax})
        '
        'GVSetupTax
        '
        Me.GVSetupTax.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVSetupTax.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVSetupTax.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVSetupTax.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVSetupTax.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVSetupTax.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVSetupTax.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVSetupTax.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVSetupTax.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVSetupTax.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVSetupTax.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVSetupTax.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVSetupTax.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVSetupTax.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVSetupTax.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVSetupTax.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVSetupTax.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn4})
        Me.GVSetupTax.GridControl = Me.GCSetupTax
        Me.GVSetupTax.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", Me.GridColumn4, "{0:N2}")})
        Me.GVSetupTax.Name = "GVSetupTax"
        Me.GVSetupTax.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSetupTax.OptionsBehavior.ReadOnly = True
        Me.GVSetupTax.OptionsView.ShowFooter = True
        Me.GVSetupTax.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "No"
        Me.GridColumn1.FieldName = "no"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Bulan"
        Me.GridColumn3.DisplayFormat.FormatString = "MMMM yyyy"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "bulan"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Total"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "total"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLTag, Me.XLTaxReport, Me.XLTitle, Me.XrLine1, Me.XLPeriod, Me.XrPictureBox1, Me.XLNumber, Me.XLDate})
        Me.ReportHeader.HeightF = 207.2083!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XLTaxReport
        '
        Me.XLTaxReport.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XLTaxReport.LocationFloat = New DevExpress.Utils.PointFloat(0!, 121.2083!)
        Me.XLTaxReport.Multiline = True
        Me.XLTaxReport.Name = "XLTaxReport"
        Me.XLTaxReport.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTaxReport.SizeF = New System.Drawing.SizeF(756.0!, 23.0!)
        Me.XLTaxReport.StylePriority.UseFont = False
        Me.XLTaxReport.StylePriority.UseTextAlignment = False
        Me.XLTaxReport.Text = "TAX REPORT: [tax_report]"
        Me.XLTaxReport.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLTitle
        '
        Me.XLTitle.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XLTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 75.20831!)
        Me.XLTitle.Multiline = True
        Me.XLTitle.Name = "XLTitle"
        Me.XLTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTitle.SizeF = New System.Drawing.SizeF(756.0!, 23.0!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.StylePriority.UseTextAlignment = False
        Me.XLTitle.Text = "SETUP TAX INSTALLMENT"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 177.2083!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(756.0!, 20.00001!)
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(0!, 144.2083!)
        Me.XLPeriod.Multiline = True
        Me.XLPeriod.Name = "XLPeriod"
        Me.XLPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLPeriod.SizeF = New System.Drawing.SizeF(756.0!, 23.0!)
        Me.XLPeriod.StylePriority.UseFont = False
        Me.XLPeriod.StylePriority.UseTextAlignment = False
        Me.XLPeriod.Text = "PERIODE: [period_from] - [period_to]"
        Me.XLPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(250.0!, 45.0!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XLNumber
        '
        Me.XLNumber.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XLNumber.LocationFloat = New DevExpress.Utils.PointFloat(458.3333!, 0!)
        Me.XLNumber.Multiline = True
        Me.XLNumber.Name = "XLNumber"
        Me.XLNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLNumber.SizeF = New System.Drawing.SizeF(297.6665!, 23.0!)
        Me.XLNumber.StylePriority.UseFont = False
        Me.XLNumber.StylePriority.UseTextAlignment = False
        Me.XLNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XLDate
        '
        Me.XLDate.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLDate.LocationFloat = New DevExpress.Utils.PointFloat(458.3333!, 23.0!)
        Me.XLDate.Multiline = True
        Me.XLDate.Name = "XLDate"
        Me.XLDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLDate.SizeF = New System.Drawing.SizeF(297.6667!, 23.0!)
        Me.XLDate.StylePriority.UseFont = False
        Me.XLDate.StylePriority.UseTextAlignment = False
        Me.XLDate.Text = "Created At: [date]"
        Me.XLDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.ReportFooter.HeightF = 40.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 15.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(756.0!, 25.0!)
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell13})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrTableCell13.KeepTogether = True
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.StylePriority.UseFont = False
        Me.XrTableCell13.Text = "Here Table Mark Goes, Please Ignore This"
        Me.XrTableCell13.Visible = False
        Me.XrTableCell13.Weight = 2.99999986405489R
        '
        'XLTag
        '
        Me.XLTag.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XLTag.LocationFloat = New DevExpress.Utils.PointFloat(0!, 98.2083!)
        Me.XLTag.Multiline = True
        Me.XLTag.Name = "XLTag"
        Me.XLTag.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTag.SizeF = New System.Drawing.SizeF(756.0!, 23.0!)
        Me.XLTag.StylePriority.UseFont = False
        Me.XLTag.StylePriority.UseTextAlignment = False
        Me.XLTag.Text = "TAG: [tag]"
        Me.XLTag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportBalanceTaxSetup
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 50, 50)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCSetupTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSetupTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XLNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCSetupTax As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSetupTax As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XLTaxReport As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLTag As DevExpress.XtraReports.UI.XRLabel
End Class
