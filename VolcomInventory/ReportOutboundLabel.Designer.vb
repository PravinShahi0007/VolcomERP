﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportOutboundLabel
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
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.XRNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XRBarcode = New DevExpress.XtraReports.UI.XRBarCode()
        Me.XrTable = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRowTotal = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell38 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XRTotal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me.XrTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1})
        Me.Detail.HeightF = 250.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPanel1
        '
        Me.XrPanel1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XRNumber, Me.XrLabel1, Me.XRBarcode, Me.XrTable})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(353.125!, 250.0!)
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'XRNumber
        '
        Me.XRNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XRNumber.LocationFloat = New DevExpress.Utils.PointFloat(50.41669!, 5.750004!)
        Me.XRNumber.Name = "XRNumber"
        Me.XRNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XRNumber.SizeF = New System.Drawing.SizeF(292.7083!, 23.0!)
        Me.XRNumber.StylePriority.UseBorders = False
        Me.XRNumber.StylePriority.UseTextAlignment = False
        Me.XRNumber.Text = "OL #"
        Me.XRNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 5.750004!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(40.41668!, 23.0!)
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "OL #"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XRBarcode
        '
        Me.XRBarcode.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XRBarcode.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 28.75001!)
        Me.XRBarcode.Name = "XRBarcode"
        Me.XRBarcode.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100.0!)
        Me.XRBarcode.ShowText = False
        Me.XRBarcode.SizeF = New System.Drawing.SizeF(334.7917!, 37.58333!)
        Me.XRBarcode.StylePriority.UseBorders = False
        Me.XRBarcode.Symbology = Code128Generator1
        Me.XRBarcode.Text = "20211231999"
        '
        'XrTable
        '
        Me.XrTable.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTable.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 70.33335!)
        Me.XrTable.Name = "XrTable"
        Me.XrTable.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow, Me.XrTableRowTotal})
        Me.XrTable.SizeF = New System.Drawing.SizeF(333.125!, 38.05555!)
        Me.XrTable.StylePriority.UseBorders = False
        Me.XrTable.StylePriority.UseFont = False
        '
        'XrTableRow
        '
        Me.XrTableRow.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableRow.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell5, Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell6})
        Me.XrTableRow.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableRow.Name = "XrTableRow"
        Me.XrTableRow.StylePriority.UseBorders = False
        Me.XrTableRow.StylePriority.UseFont = False
        Me.XrTableRow.StylePriority.UseTextAlignment = False
        Me.XrTableRow.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableRow.Weight = 1.0833331298828126R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell1.StylePriority.UseBorders = False
        Me.XrTableCell1.StylePriority.UsePadding = False
        Me.XrTableCell1.Text = "NO"
        Me.XrTableCell1.Weight = 0.35373032269379917R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell5.StylePriority.UseBorders = False
        Me.XrTableCell5.StylePriority.UsePadding = False
        Me.XrTableCell5.Text = "DO#"
        Me.XrTableCell5.Weight = 0.98488846466064517R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell2.StylePriority.UseBorders = False
        Me.XrTableCell2.StylePriority.UsePadding = False
        Me.XrTableCell2.Text = "STORE"
        Me.XrTableCell2.Weight = 0.5925447994725388R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell3.StylePriority.UseBorders = False
        Me.XrTableCell3.StylePriority.UsePadding = False
        Me.XrTableCell3.Text = "DESCRIPTION"
        Me.XrTableCell3.Weight = 1.9196563859094205R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell6.StylePriority.UseBorders = False
        Me.XrTableCell6.StylePriority.UsePadding = False
        Me.XrTableCell6.Text = "QTY"
        Me.XrTableCell6.Weight = 0.78527090738736938R
        '
        'XrTableRowTotal
        '
        Me.XrTableRowTotal.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell38, Me.XRTotal})
        Me.XrTableRowTotal.Name = "XrTableRowTotal"
        Me.XrTableRowTotal.Weight = 1.2000000748505417R
        '
        'XrTableCell38
        '
        Me.XrTableCell38.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell38.Name = "XrTableCell38"
        Me.XrTableCell38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell38.StylePriority.UseBorders = False
        Me.XrTableCell38.StylePriority.UsePadding = False
        Me.XrTableCell38.Weight = 3.1192317505743681R
        '
        'XRTotal
        '
        Me.XRTotal.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XRTotal.Name = "XRTotal"
        Me.XRTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XRTotal.StylePriority.UseBorders = False
        Me.XRTotal.StylePriority.UsePadding = False
        Me.XRTotal.Weight = 0.63608264704615025R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 20.0!
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
        'ReportOutboundLabel
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Margins = New System.Drawing.Printing.Margins(230, 100, 20, 50)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "15.1"
        CType(Me.XrTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XRBarcode As DevExpress.XtraReports.UI.XRBarCode
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XRNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRowTotal As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell38 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XRTotal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
End Class
