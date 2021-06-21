<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportBalancePPNSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportBalancePPNSummary))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XLNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.GCSummary = New DevExpress.XtraGrid.GridControl()
        Me.GVSummary = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GCSum = New DevExpress.XtraGrid.GridControl()
        Me.GVSum = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WinControlContainer2 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.LPageFooter = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer2, Me.XrLabel2, Me.XrLabel1, Me.WinControlContainer1})
        Me.Detail.HeightF = 274.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
        Me.BottomMargin.HeightF = 20.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLTitle, Me.XrLine1, Me.XLPeriod, Me.XrPictureBox1, Me.XLNumber, Me.XLDate})
        Me.ReportHeader.HeightF = 156.2083!
        Me.ReportHeader.Name = "ReportHeader"
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
        Me.XLTitle.Text = "LAPORAN PPN"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 136.2083!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(756.0!, 20.00001!)
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(0!, 98.20833!)
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
        'GCSummary
        '
        Me.GCSummary.Location = New System.Drawing.Point(0, 0)
        Me.GCSummary.MainView = Me.GVSummary
        Me.GCSummary.Name = "GCSummary"
        Me.GCSummary.Size = New System.Drawing.Size(726, 100)
        Me.GCSummary.TabIndex = 4
        Me.GCSummary.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSummary})
        '
        'GVSummary
        '
        Me.GVSummary.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVSummary.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVSummary.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVSummary.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVSummary.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVSummary.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVSummary.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVSummary.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVSummary.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVSummary.ColumnPanelRowHeight = 32
        Me.GVSummary.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn6, Me.GridColumn3, Me.GridColumn7, Me.GridColumn4, Me.GridColumn8, Me.GridColumn5})
        Me.GVSummary.GridControl = Me.GCSummary
        Me.GVSummary.GroupCount = 1
        Me.GVSummary.GroupFormat = "[#image]{1} {2}"
        Me.GVSummary.LevelIndent = 0
        Me.GVSummary.Name = "GVSummary"
        Me.GVSummary.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSummary.OptionsBehavior.ReadOnly = True
        Me.GVSummary.OptionsPrint.AllowMultilineHeaders = True
        Me.GVSummary.OptionsView.ColumnAutoWidth = False
        Me.GVSummary.OptionsView.ShowGroupPanel = False
        Me.GVSummary.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "KETERANGAN"
        Me.GridColumn1.FieldName = "keterangan"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn2.Caption = "PT VOLCOM INDONESIA (OFFICE)"
        Me.GridColumn2.FieldName = "vi"
        Me.GridColumn2.MinWidth = 100
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 100
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = " "
        Me.GridColumn6.DisplayFormat.FormatString = "N2"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "vi_total"
        Me.GridColumn6.MinWidth = 90
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 90
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn3.Caption = "TOKO VOLCOM BEMO CORNER"
        Me.GridColumn3.FieldName = "bc"
        Me.GridColumn3.MinWidth = 100
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 100
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = " "
        Me.GridColumn7.DisplayFormat.FormatString = "N2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "bc_total"
        Me.GridColumn7.MinWidth = 90
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        Me.GridColumn7.Width = 90
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn4.Caption = "TOKO VOLCOM SEMINYAK"
        Me.GridColumn4.FieldName = "sm"
        Me.GridColumn4.MinWidth = 100
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        Me.GridColumn4.Width = 100
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = " "
        Me.GridColumn8.DisplayFormat.FormatString = "N2"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "sm_total"
        Me.GridColumn8.MinWidth = 90
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 5
        Me.GridColumn8.Width = 90
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "TOTAL"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "total"
        Me.GridColumn5.MinWidth = 100
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 6
        Me.GridColumn5.Width = 100
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 28.00002!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(756.0!, 104.0!)
        Me.WinControlContainer1.WinControl = Me.GCSummary
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 147.0!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(756.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "SUMMARY"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.000019!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(756.0!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "DETAIL"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'GCSum
        '
        Me.GCSum.Location = New System.Drawing.Point(0, 0)
        Me.GCSum.MainView = Me.GVSum
        Me.GCSum.Name = "GCSum"
        Me.GCSum.Size = New System.Drawing.Size(726, 100)
        Me.GCSum.TabIndex = 5
        Me.GCSum.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSum})
        '
        'GVSum
        '
        Me.GVSum.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVSum.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSum.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVSum.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVSum.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVSum.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVSum.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVSum.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVSum.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVSum.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVSum.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVSum.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVSum.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVSum.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVSum.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVSum.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSum.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVSum.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVSum.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVSum.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVSum.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVSum.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVSum.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVSum.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVSum.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVSum.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVSum.ColumnPanelRowHeight = 32
        Me.GVSum.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn12, Me.GridColumn14, Me.GridColumn16})
        Me.GVSum.GridControl = Me.GCSum
        Me.GVSum.GroupFormat = "[#image]{1} {2}"
        Me.GVSum.LevelIndent = 0
        Me.GVSum.Name = "GVSum"
        Me.GVSum.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSum.OptionsBehavior.ReadOnly = True
        Me.GVSum.OptionsPrint.AllowMultilineHeaders = True
        Me.GVSum.OptionsView.ColumnAutoWidth = False
        Me.GVSum.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "KETERANGAN"
        Me.GridColumn9.FieldName = "keterangan"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn10.Caption = "PT VOLCOM INDONESIA (OFFICE)"
        Me.GridColumn10.DisplayFormat.FormatString = "N2"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "vi"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 1
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn12.Caption = "TOKO VOLCOM BEMO CORNER"
        Me.GridColumn12.DisplayFormat.FormatString = "N2"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "bc"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn14.Caption = "TOKO VOLCOM SEMINYAK"
        Me.GridColumn14.DisplayFormat.FormatString = "N2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "sm"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 3
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "TOTAL"
        Me.GridColumn16.DisplayFormat.FormatString = "N2"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "total"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 4
        '
        'WinControlContainer2
        '
        Me.WinControlContainer2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 170.0!)
        Me.WinControlContainer2.Name = "WinControlContainer2"
        Me.WinControlContainer2.SizeF = New System.Drawing.SizeF(756.0!, 104.0!)
        Me.WinControlContainer2.WinControl = Me.GCSum
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.ReportFooter.HeightF = 34.99997!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
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
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LPageFooter})
        Me.PageFooter.HeightF = 23.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'LPageFooter
        '
        Me.LPageFooter.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Italic)
        Me.LPageFooter.ForeColor = System.Drawing.Color.DarkGray
        Me.LPageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.LPageFooter.Multiline = True
        Me.LPageFooter.Name = "LPageFooter"
        Me.LPageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPageFooter.SizeF = New System.Drawing.SizeF(755.9998!, 23.0!)
        Me.LPageFooter.StylePriority.UseFont = False
        Me.LPageFooter.StylePriority.UseForeColor = False
        Me.LPageFooter.StylePriority.UseTextAlignment = False
        Me.LPageFooter.Text = "Printed by : [employee_print] (Volcom ERP)"
        Me.LPageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'ReportBalancePPNSummary
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 50, 20)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XLNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCSummary As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSummary As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WinControlContainer2 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCSum As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSum As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents LPageFooter As DevExpress.XtraReports.UI.XRLabel
End Class
