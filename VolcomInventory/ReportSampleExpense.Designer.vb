<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportSampleExpense
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
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LPONumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.LNO = New DevExpress.XtraReports.UI.XRLabel()
        Me.LPODate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LVat = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LGrossTot = New DevExpress.XtraReports.UI.XRLabel()
        Me.LNotex = New DevExpress.XtraReports.UI.XRLabel()
        Me.LVatTot = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LCur = New DevExpress.XtraReports.UI.XRLabel()
        Me.LTot = New DevExpress.XtraReports.UI.XRLabel()
        Me.LNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LHKurs = New DevExpress.XtraReports.UI.XRLabel()
        Me.LKurs = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.GCAfter = New DevExpress.XtraGrid.GridControl()
        Me.GVAfter = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 160.4167!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LTitle, Me.XrLabel12, Me.LPONumber, Me.LNO, Me.LPODate})
        Me.TopMargin.HeightF = 73.62499!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 19.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.LNotex, Me.LHKurs, Me.XrLabel26, Me.XrLabel5, Me.LNote, Me.LVat, Me.LTot, Me.LCur, Me.XrLabel18, Me.XrLabel8, Me.LVatTot, Me.LKurs, Me.LGrossTot, Me.XrLabel25, Me.XrLabel14, Me.XrLabel23})
        Me.PageFooter.HeightF = 125.0001!
        Me.PageFooter.Name = "PageFooter"
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(180.0!, 22.92!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(290.0001!, 25.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "SAMPLE MATERIAL PURCHASE ORDER"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(39.99999!, 22.92!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(10.0!, 25.08334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = ":"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LPONumber
        '
        Me.LPONumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LPONumber.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LPONumber.LocationFloat = New DevExpress.Utils.PointFloat(49.99997!, 22.92!)
        Me.LPONumber.Name = "LPONumber"
        Me.LPONumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPONumber.SizeF = New System.Drawing.SizeF(130.0!, 25.08334!)
        Me.LPONumber.StylePriority.UseBorders = False
        Me.LPONumber.StylePriority.UseFont = False
        Me.LPONumber.StylePriority.UseTextAlignment = False
        Me.LPONumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LNO
        '
        Me.LNO.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LNO.LocationFloat = New DevExpress.Utils.PointFloat(0!, 22.92!)
        Me.LNO.Name = "LNO"
        Me.LNO.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNO.SizeF = New System.Drawing.SizeF(40.0!, 25.08334!)
        Me.LNO.StylePriority.UseFont = False
        Me.LNO.StylePriority.UseTextAlignment = False
        Me.LNO.Text = "NO"
        Me.LNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LPODate
        '
        Me.LPODate.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LPODate.LocationFloat = New DevExpress.Utils.PointFloat(470.0!, 22.92!)
        Me.LPODate.Name = "LPODate"
        Me.LPODate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPODate.SizeF = New System.Drawing.SizeF(180.0!, 25.08334!)
        Me.LPODate.StylePriority.UseFont = False
        Me.LPODate.StylePriority.UseTextAlignment = False
        Me.LPODate.Text = "DATE"
        Me.LPODate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 80.00024!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(649.9996!, 25.0!)
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
        'LVat
        '
        Me.LVat.BorderColor = System.Drawing.Color.DimGray
        Me.LVat.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.LVat.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVat.LocationFloat = New DevExpress.Utils.PointFloat(387.5!, 20.00008!)
        Me.LVat.Name = "LVat"
        Me.LVat.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LVat.SizeF = New System.Drawing.SizeF(39.58307!, 20.00014!)
        Me.LVat.StylePriority.UseBorderColor = False
        Me.LVat.StylePriority.UseBorders = False
        Me.LVat.StylePriority.UseFont = False
        Me.LVat.StylePriority.UseTextAlignment = False
        Me.LVat.Text = "0"
        Me.LVat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel23
        '
        Me.XrLabel23.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel23.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel23.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(352.0838!, 60.0001!)
        Me.XrLabel23.Name = "XrLabel23"
        Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel23.SizeF = New System.Drawing.SizeF(74.9993!, 20.00002!)
        Me.XrLabel23.StylePriority.UseBorderColor = False
        Me.XrLabel23.StylePriority.UseBorders = False
        Me.XrLabel23.StylePriority.UseFont = False
        Me.XrLabel23.StylePriority.UseTextAlignment = False
        Me.XrLabel23.Text = "CURRENCY :"
        Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel14
        '
        Me.XrLabel14.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel14.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel14.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(427.083!, 20.00008!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(25.00024!, 20.00002!)
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "%"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel25
        '
        Me.XrLabel25.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel25.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(352.0833!, 20.00008!)
        Me.XrLabel25.Name = "XrLabel25"
        Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel25.SizeF = New System.Drawing.SizeF(35.41669!, 20.00014!)
        Me.XrLabel25.StylePriority.UseBorderColor = False
        Me.XrLabel25.StylePriority.UseBorders = False
        Me.XrLabel25.StylePriority.UseFont = False
        Me.XrLabel25.StylePriority.UseTextAlignment = False
        Me.XrLabel25.Text = "VAT"
        Me.XrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LGrossTot
        '
        Me.LGrossTot.BorderColor = System.Drawing.Color.DimGray
        Me.LGrossTot.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LGrossTot.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LGrossTot.LocationFloat = New DevExpress.Utils.PointFloat(452.0836!, 0!)
        Me.LGrossTot.Name = "LGrossTot"
        Me.LGrossTot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LGrossTot.SizeF = New System.Drawing.SizeF(197.9163!, 20.00001!)
        Me.LGrossTot.StylePriority.UseBorderColor = False
        Me.LGrossTot.StylePriority.UseBorders = False
        Me.LGrossTot.StylePriority.UseFont = False
        Me.LGrossTot.StylePriority.UseTextAlignment = False
        Me.LGrossTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LNotex
        '
        Me.LNotex.BorderColor = System.Drawing.Color.DimGray
        Me.LNotex.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.LNotex.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNotex.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.LNotex.Name = "LNotex"
        Me.LNotex.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNotex.SizeF = New System.Drawing.SizeF(46.87503!, 60.00016!)
        Me.LNotex.StylePriority.UseBorderColor = False
        Me.LNotex.StylePriority.UseBorders = False
        Me.LNotex.StylePriority.UseFont = False
        Me.LNotex.Text = "NOTE "
        '
        'LVatTot
        '
        Me.LVatTot.BorderColor = System.Drawing.Color.DimGray
        Me.LVatTot.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LVatTot.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVatTot.LocationFloat = New DevExpress.Utils.PointFloat(452.0834!, 20.00001!)
        Me.LVatTot.Name = "LVatTot"
        Me.LVatTot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LVatTot.SizeF = New System.Drawing.SizeF(197.9164!, 20.00005!)
        Me.LVatTot.StylePriority.UseBorderColor = False
        Me.LVatTot.StylePriority.UseBorders = False
        Me.LVatTot.StylePriority.UseFont = False
        Me.LVatTot.StylePriority.UseTextAlignment = False
        Me.LVatTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel8
        '
        Me.XrLabel8.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel8.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(352.0835!, 0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "GROSS TOTAL"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel18
        '
        Me.XrLabel18.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel18.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(46.8749!, 0!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(10.3334!, 60.00013!)
        Me.XrLabel18.StylePriority.UseBorderColor = False
        Me.XrLabel18.StylePriority.UseBorders = False
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.Text = ":"
        '
        'LCur
        '
        Me.LCur.BorderColor = System.Drawing.Color.DimGray
        Me.LCur.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LCur.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCur.LocationFloat = New DevExpress.Utils.PointFloat(427.0831!, 60.00004!)
        Me.LCur.Name = "LCur"
        Me.LCur.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LCur.SizeF = New System.Drawing.SizeF(43.75024!, 20.00005!)
        Me.LCur.StylePriority.UseBorderColor = False
        Me.LCur.StylePriority.UseBorders = False
        Me.LCur.StylePriority.UseFont = False
        Me.LCur.StylePriority.UseTextAlignment = False
        Me.LCur.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LTot
        '
        Me.LTot.BorderColor = System.Drawing.Color.DimGray
        Me.LTot.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LTot.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTot.LocationFloat = New DevExpress.Utils.PointFloat(452.0833!, 40.00009!)
        Me.LTot.Name = "LTot"
        Me.LTot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTot.SizeF = New System.Drawing.SizeF(197.9163!, 19.99998!)
        Me.LTot.StylePriority.UseBorderColor = False
        Me.LTot.StylePriority.UseBorders = False
        Me.LTot.StylePriority.UseFont = False
        Me.LTot.StylePriority.UseTextAlignment = False
        Me.LTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LNote
        '
        Me.LNote.BorderColor = System.Drawing.Color.DimGray
        Me.LNote.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LNote.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNote.LocationFloat = New DevExpress.Utils.PointFloat(57.20832!, 0!)
        Me.LNote.Name = "LNote"
        Me.LNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNote.SizeF = New System.Drawing.SizeF(294.875!, 60.0001!)
        Me.LNote.StylePriority.UseBorderColor = False
        Me.LNote.StylePriority.UseBorders = False
        Me.LNote.StylePriority.UseFont = False
        '
        'XrLabel5
        '
        Me.XrLabel5.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel5.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel5.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 60.00016!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(352.0838!, 20.00006!)
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel26
        '
        Me.XrLabel26.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel26.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel26.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(352.0834!, 40.00022!)
        Me.XrLabel26.Name = "XrLabel26"
        Me.XrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel26.SizeF = New System.Drawing.SizeF(100.0!, 20.00002!)
        Me.XrLabel26.StylePriority.UseBorderColor = False
        Me.XrLabel26.StylePriority.UseBorders = False
        Me.XrLabel26.StylePriority.UseFont = False
        Me.XrLabel26.StylePriority.UseTextAlignment = False
        Me.XrLabel26.Text = "TOTAL "
        Me.XrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LHKurs
        '
        Me.LHKurs.BorderColor = System.Drawing.Color.DimGray
        Me.LHKurs.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LHKurs.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LHKurs.LocationFloat = New DevExpress.Utils.PointFloat(470.8333!, 60.00004!)
        Me.LHKurs.Name = "LHKurs"
        Me.LHKurs.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LHKurs.SizeF = New System.Drawing.SizeF(44.79099!, 20.00002!)
        Me.LHKurs.StylePriority.UseBorderColor = False
        Me.LHKurs.StylePriority.UseBorders = False
        Me.LHKurs.StylePriority.UseFont = False
        Me.LHKurs.StylePriority.UseTextAlignment = False
        Me.LHKurs.Text = "KURS :"
        Me.LHKurs.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LKurs
        '
        Me.LKurs.BorderColor = System.Drawing.Color.DimGray
        Me.LKurs.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LKurs.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LKurs.LocationFloat = New DevExpress.Utils.PointFloat(515.6245!, 60.00016!)
        Me.LKurs.Name = "LKurs"
        Me.LKurs.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LKurs.SizeF = New System.Drawing.SizeF(134.3756!, 20.00005!)
        Me.LKurs.StylePriority.UseBorderColor = False
        Me.LKurs.StylePriority.UseBorders = False
        Me.LKurs.StylePriority.UseFont = False
        Me.LKurs.StylePriority.UseTextAlignment = False
        Me.LKurs.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(500.0001!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'GCAfter
        '
        Me.GCAfter.Location = New System.Drawing.Point(0, 137)
        Me.GCAfter.MainView = Me.GVAfter
        Me.GCAfter.Name = "GCAfter"
        Me.GCAfter.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemDateEdit1})
        Me.GCAfter.Size = New System.Drawing.Size(624, 154)
        Me.GCAfter.TabIndex = 10
        Me.GCAfter.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAfter})
        '
        'GVAfter
        '
        Me.GVAfter.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVAfter.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVAfter.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVAfter.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVAfter.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVAfter.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVAfter.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVAfter.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVAfter.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVAfter.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVAfter.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVAfter.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVAfter.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn7, Me.GridColumn2, Me.GridColumn3, Me.GridColumn5, Me.GridColumn6, Me.GridColumn4})
        Me.GVAfter.GridControl = Me.GCAfter
        Me.GVAfter.Name = "GVAfter"
        Me.GVAfter.OptionsView.ShowFooter = True
        Me.GVAfter.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.GridColumn1.AppearanceCell.BorderColor = System.Drawing.Color.Black
        Me.GridColumn1.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn1.AppearanceCell.Options.UseBorderColor = True
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.FieldName = "id_sample_po_mat_det"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Description"
        Me.GridColumn2.FieldName = "description"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 693
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Qty"
        Me.GridColumn3.DisplayFormat.FormatString = "N2"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "qty"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 128
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "UOM"
        Me.GridColumn5.FieldName = "uom"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 111
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn6.Caption = "Value"
        Me.GridColumn6.DisplayFormat.FormatString = "N2"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "value"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 396
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "Sub Total"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "sub_total"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sub_total", "{0:N2}")})
        Me.GridColumn4.UnboundExpression = "[qty] * [value]"
        Me.GridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        Me.GridColumn4.Width = 304
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.RepositoryItemDateEdit1.DisplayFormat.FormatString = "yyyy"
        Me.RepositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit1.EditFormat.FormatString = "yyyy"
        Me.RepositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit1.Mask.EditMask = "yyyy"
        Me.RepositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        Me.RepositoryItemDateEdit1.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.RepositoryItemDateEdit1.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(650.0001!, 160.4167!)
        Me.WinControlContainer1.WinControl = Me.GCAfter
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "No."
        Me.GridColumn7.FieldName = "no"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'ReportSampleExpense
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 74, 19)
        Me.PageHeight = 550
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPONumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNO As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPODate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LGrossTot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNotex As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LVatTot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LCur As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LVat As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LHKurs As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LKurs As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCAfter As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAfter As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents LNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
