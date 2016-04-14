<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportSampleReceipt
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer
        Me.GCSummary = New DevExpress.XtraGrid.GridControl
        Me.GVSummary = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdPLSampleDetail = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPLSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCountReceiptSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XrPanel2 = New DevExpress.XtraReports.UI.XRPanel
        Me.LabelNote = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelNo = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel
        Me.LabelSource = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelStatus = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelPL = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.LabelFrom = New DevExpress.XtraReports.UI.XRLabel
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 126.9631!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(649.9999!, 124.8798!)
        Me.WinControlContainer1.WinControl = Me.GCSummary
        '
        'GCSummary
        '
        Me.GCSummary.Location = New System.Drawing.Point(22, 2)
        Me.GCSummary.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCSummary.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCSummary.MainView = Me.GVSummary
        Me.GCSummary.Name = "GCSummary"
        Me.GCSummary.Size = New System.Drawing.Size(624, 120)
        Me.GCSummary.TabIndex = 0
        Me.GCSummary.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSummary})
        '
        'GVSummary
        '
        Me.GVSummary.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.EvenRow.BackColor2 = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.EvenRow.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.EvenRow.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.EvenRow.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.FilterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.FilterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.FilterPanel.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.FooterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.GroupFooter.BackColor2 = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.Lines.BackColor2 = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.Lines.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.Lines.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.OddRow.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.OddRow.BackColor2 = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.OddRow.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.OddRow.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.OddRow.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.Preview.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.Preview.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.Row.BackColor2 = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVSummary.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdPLSampleDetail, Me.GridColumnIdPLSample, Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumn1, Me.GridColumnCountReceiptSample, Me.GridColumnAmount})
        Me.GVSummary.GridControl = Me.GCSummary
        Me.GVSummary.Name = "GVSummary"
        Me.GVSummary.OptionsPrint.UsePrintStyles = True
        Me.GVSummary.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdPLSampleDetail
        '
        Me.GridColumnIdPLSampleDetail.Caption = "Id PL Sample Detail"
        Me.GridColumnIdPLSampleDetail.FieldName = "id_pl_sample_purc_det"
        Me.GridColumnIdPLSampleDetail.Name = "GridColumnIdPLSampleDetail"
        Me.GridColumnIdPLSampleDetail.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdPLSample
        '
        Me.GridColumnIdPLSample.Caption = "IdPLSample"
        Me.GridColumnIdPLSample.FieldName = "id_pl_sample_purc_det"
        Me.GridColumnIdPLSample.Name = "GridColumnIdPLSample"
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Qty Limit"
        Me.GridColumn1.FieldName = "qty_issue"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'GridColumnCountReceiptSample
        '
        Me.GridColumnCountReceiptSample.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCountReceiptSample.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCountReceiptSample.Caption = "Qty Receipt"
        Me.GridColumnCountReceiptSample.DisplayFormat.FormatString = "d"
        Me.GridColumnCountReceiptSample.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCountReceiptSample.FieldName = "count_receipt_sample"
        Me.GridColumnCountReceiptSample.Name = "GridColumnCountReceiptSample"
        Me.GridColumnCountReceiptSample.OptionsColumn.AllowEdit = False
        Me.GridColumnCountReceiptSample.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumnCountReceiptSample.Visible = True
        Me.GridColumnCountReceiptSample.VisibleIndex = 5
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.AllowEdit = False
        '
        'XrPanel2
        '
        Me.XrPanel2.BorderColor = System.Drawing.Color.Black
        Me.XrPanel2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelNote, Me.XrLabel9, Me.XrLabel14})
        Me.XrPanel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPanel2.Name = "XrPanel2"
        Me.XrPanel2.SizeF = New System.Drawing.SizeF(649.9999!, 47.29169!)
        Me.XrPanel2.StylePriority.UseBorderColor = False
        Me.XrPanel2.StylePriority.UseBorders = False
        '
        'LabelNote
        '
        Me.LabelNote.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelNote.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelNote.LocationFloat = New DevExpress.Utils.PointFloat(63.598!, 3.833359!)
        Me.LabelNote.Name = "LabelNote"
        Me.LabelNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNote.SizeF = New System.Drawing.SizeF(576.4018!, 33.45833!)
        Me.LabelNote.StylePriority.UseBorders = False
        Me.LabelNote.StylePriority.UseFont = False
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
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel11, Me.XrLabel1, Me.XrLabel6, Me.LabelNo, Me.LabelDate, Me.XrLabel8, Me.LTitle, Me.XrPanel1})
        Me.TopMargin.HeightF = 109.8494!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(552.0833!, 6.18269!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(509.4583!, 6.18269!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(42.62506!, 13.58337!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(509.3749!, 19.76609!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(42.62506!, 11.49996!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "DATE"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LabelNo
        '
        Me.LabelNo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNo.LocationFloat = New DevExpress.Utils.PointFloat(564.5001!, 6.18269!)
        Me.LabelNo.Name = "LabelNo"
        Me.LabelNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNo.SizeF = New System.Drawing.SizeF(85.49994!, 13.58337!)
        Me.LabelNo.StylePriority.UseFont = False
        Me.LabelNo.StylePriority.UseTextAlignment = False
        Me.LabelNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LabelDate
        '
        Me.LabelDate.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(564.5!, 19.76606!)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDate.SizeF = New System.Drawing.SizeF(85.49988!, 11.49999!)
        Me.LabelDate.StylePriority.UseFont = False
        Me.LabelDate.StylePriority.UseTextAlignment = False
        Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(552.0!, 19.76606!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(11.45831!, 11.49999!)
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.Text = ":"
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(225.4644!, 19.76609!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(205.2086!, 15.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "RECEIPT  SAMPLE "
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrPanel1
        '
        Me.XrPanel1.BorderColor = System.Drawing.Color.Black
        Me.XrPanel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.CanGrow = False
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelSource, Me.XrLabel20, Me.XrLabel18, Me.LabelStatus, Me.XrLabel13, Me.XrLabel12, Me.LabelPL, Me.XrLabel10, Me.XrLabel3, Me.XrLabel4, Me.XrLabel2, Me.LabelFrom})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 34.84943!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(649.9999!, 75.0!)
        Me.XrPanel1.StylePriority.UseBorderColor = False
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'LabelSource
        '
        Me.LabelSource.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelSource.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSource.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 29.16669!)
        Me.LabelSource.Name = "LabelSource"
        Me.LabelSource.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelSource.SizeF = New System.Drawing.SizeF(226.0978!, 13.58333!)
        Me.LabelSource.StylePriority.UseBorders = False
        Me.LabelSource.StylePriority.UseFont = False
        '
        'XrLabel20
        '
        Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(88.54166!, 29.16663!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel20.StylePriority.UseBorders = False
        Me.XrLabel20.Text = ":"
        '
        'XrLabel18
        '
        Me.XrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel18.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(1.999982!, 29.16669!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(86.54163!, 13.58333!)
        Me.XrLabel18.StylePriority.UseBorders = False
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.Text = "PL Category"
        '
        'LabelStatus
        '
        Me.LabelStatus.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelStatus.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.LocationFloat = New DevExpress.Utils.PointFloat(454.5025!, 2.000031!)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelStatus.SizeF = New System.Drawing.SizeF(184.0391!, 13.58332!)
        Me.LabelStatus.StylePriority.UseBorders = False
        Me.LabelStatus.StylePriority.UseFont = False
        Me.LabelStatus.Text = "Not Matched"
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(443.0441!, 2.000011!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.Text = ":"
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(357.1523!, 2.000021!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(85.89175!, 13.58334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.Text = "Status Receipt"
        '
        'LabelPL
        '
        Me.LabelPL.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelPL.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPL.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 15.58335!)
        Me.LabelPL.Name = "LabelPL"
        Me.LabelPL.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelPL.SizeF = New System.Drawing.SizeF(226.0978!, 13.58334!)
        Me.LabelPL.StylePriority.UseBorders = False
        Me.LabelPL.StylePriority.UseFont = False
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(88.54168!, 15.58335!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(11.45831!, 13.58334!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.Text = ":"
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(1.999982!, 2.000004!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(86.54168!, 13.58334!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "From"
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(88.54168!, 2.000001!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.Text = ":"
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(1.999982!, 15.58335!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(86.54166!, 13.58334!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "PL"
        '
        'LabelFrom
        '
        Me.LabelFrom.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelFrom.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFrom.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 2.000004!)
        Me.LabelFrom.Name = "LabelFrom"
        Me.LabelFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelFrom.SizeF = New System.Drawing.SizeF(226.0979!, 13.58335!)
        Me.LabelFrom.StylePriority.UseBorders = False
        Me.LabelFrom.StylePriority.UseFont = False
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 20.22041!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(499.9999!, 0.0!)
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
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.XrPanel2})
        Me.PageFooter.HeightF = 72.70835!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 47.29169!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(649.9996!, 25.0!)
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Lucida Console", 8.0!)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.Text = "Here Table Mark Goes, Please Ignore This"
        Me.XrTableCell1.Visible = False
        Me.XrTableCell1.Weight = 2.9999998640548888
        '
        'ReportSampleReceipt
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 110, 20)
        Me.PageHeight = 500
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Version = "11.1"
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelSource As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelStatus As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelPL As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCSummary As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSummary As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdPLSampleDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPLSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCountReceiptSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPanel2 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
End Class
