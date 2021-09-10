<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportPreCalBudget
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
        Me.XTDetail = New DevExpress.XtraReports.UI.XRTable()
        Me.XRRow = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.LVendor1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XTDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XTDetail})
        Me.Detail.HeightF = 25.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XTDetail
        '
        Me.XTDetail.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XTDetail.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XTDetail.Name = "XTDetail"
        Me.XTDetail.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100.0!)
        Me.XTDetail.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XRRow})
        Me.XTDetail.SizeF = New System.Drawing.SizeF(1050.0!, 25.0!)
        Me.XTDetail.StylePriority.UseBorders = False
        Me.XTDetail.StylePriority.UsePadding = False
        Me.XTDetail.StylePriority.UseTextAlignment = False
        Me.XTDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XRRow
        '
        Me.XRRow.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell6, Me.XrTableCell7, Me.XrTableCell8, Me.XrTableCell9, Me.XrTableCell10, Me.XrTableCell11})
        Me.XRRow.Name = "XRRow"
        Me.XRRow.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.Text = "Description"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell1.Weight = 2.272727272727272R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 100.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 100.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable3})
        Me.PageHeader.HeightF = 25.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrTable3
        '
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(1050.0!, 25.0!)
        Me.XrTable3.StylePriority.UseTextAlignment = False
        Me.XrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.LVendor1, Me.XrTableCell4, Me.XrTableCell5})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'LVendor1
        '
        Me.LVendor1.Name = "LVendor1"
        Me.LVendor1.Text = "[vendor1]"
        Me.LVendor1.Weight = 1.0317728380016711R
        '
        'ReportFooter
        '
        Me.ReportFooter.HeightF = 100.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'PageFooter
        '
        Me.PageFooter.HeightF = 100.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Weight = 0.10317728239230949R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Text = "[vendor2]"
        Me.XrTableCell5.Weight = 1.0317727413402504R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = "Unit Price"
        Me.XrTableCell2.Weight = 0.90909090909090917R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Text = "Qty"
        Me.XrTableCell3.Weight = 0.36363636363636359R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Text = "Total"
        Me.XrTableCell6.Weight = 1.0000002774325285R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Weight = 0.454544344815341R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.StylePriority.UseTextAlignment = False
        Me.XrTableCell8.Text = "Description"
        Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell8.Weight = 2.2727273652048763R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Text = "Unit Price"
        Me.XrTableCell9.Weight = 0.90909093551311448R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Text = "Qty"
        Me.XrTableCell10.Weight = 0.36363636469329341R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Text = "Total"
        Me.XrTableCell11.Weight = 1.0000000295173761R
        '
        'ReportPreCalBudget
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(51, 68, 100, 100)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.XTDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XTDetail As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XRRow As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents LVendor1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
End Class
