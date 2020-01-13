<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportAccountingLedger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportAccountingLedger))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCAccountingLedger = New DevExpress.XtraGrid.GridControl()
        Me.GVAccountingLedger = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XLAccount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCAccountingLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAccountingLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1, Me.XLAccount, Me.XrLabel4, Me.XrLabel2, Me.XrLabel1, Me.XrLabel3, Me.XLPeriod})
        Me.Detail.HeightF = 153.625!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 64.99998!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1075.0!, 88.62501!)
        Me.WinControlContainer1.WinControl = Me.GCAccountingLedger
        '
        'GCAccountingLedger
        '
        Me.GCAccountingLedger.Location = New System.Drawing.Point(0, 44)
        Me.GCAccountingLedger.MainView = Me.GVAccountingLedger
        Me.GCAccountingLedger.Name = "GCAccountingLedger"
        Me.GCAccountingLedger.Size = New System.Drawing.Size(1032, 85)
        Me.GCAccountingLedger.TabIndex = 1
        Me.GCAccountingLedger.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAccountingLedger})
        '
        'GVAccountingLedger
        '
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVAccountingLedger.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVAccountingLedger.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVAccountingLedger.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVAccountingLedger.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVAccountingLedger.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVAccountingLedger.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVAccountingLedger.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVAccountingLedger.AppearancePrint.Row.Options.UseFont = True
        Me.GVAccountingLedger.ColumnPanelRowHeight = 32
        Me.GVAccountingLedger.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn20, Me.GridColumn19, Me.GridColumn18, Me.GridColumn17, Me.GridColumn16, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn10, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn21})
        Me.GVAccountingLedger.GridControl = Me.GCAccountingLedger
        Me.GVAccountingLedger.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", Me.GridColumn7, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", Me.GridColumn8, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "number", Me.GridColumn16, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "last_balance", Me.GridColumn9, "{0:N0}")})
        Me.GVAccountingLedger.LevelIndent = 0
        Me.GVAccountingLedger.Name = "GVAccountingLedger"
        Me.GVAccountingLedger.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVAccountingLedger.OptionsBehavior.Editable = False
        Me.GVAccountingLedger.OptionsView.ShowFooter = True
        Me.GVAccountingLedger.OptionsView.ShowGroupPanel = False
        '
        'GridColumn20
        '
        Me.GridColumn20.FieldName = "id_report"
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn19
        '
        Me.GridColumn19.FieldName = "report_mark_type"
        Me.GridColumn19.Name = "GridColumn19"
        '
        'GridColumn18
        '
        Me.GridColumn18.FieldName = "id_report_ref"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn17
        '
        Me.GridColumn17.FieldName = "report_mark_type_ref"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "No"
        Me.GridColumn16.FieldName = "number"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Account"
        Me.GridColumn1.FieldName = "acc_name"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Report Number"
        Me.GridColumn2.FieldName = "report_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Company"
        Me.GridColumn3.FieldName = "comp_number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Journal Date"
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "date_created"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Reff"
        Me.GridColumn5.FieldName = "report_number_ref"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Description"
        Me.GridColumn6.FieldName = "acc_trans_note"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 6
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Debit"
        Me.GridColumn7.DisplayFormat.FormatString = "N0"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "debit"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "{0:N0}")})
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 8
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Credit"
        Me.GridColumn8.DisplayFormat.FormatString = "N0"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "credit"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "{0:N0}")})
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 9
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Balance"
        Me.GridColumn9.DisplayFormat.FormatString = "N0"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "balance"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "last_balance", "{0:N0}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 10
        '
        'GridColumn21
        '
        Me.GridColumn21.DisplayFormat.FormatString = "N0"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "last_balance"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'XLAccount
        '
        Me.XLAccount.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLAccount.LocationFloat = New DevExpress.Utils.PointFloat(75.00003!, 28.00001!)
        Me.XLAccount.Name = "XLAccount"
        Me.XLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLAccount.SizeF = New System.Drawing.SizeF(1000.0!, 23.0!)
        Me.XLAccount.StylePriority.UseFont = False
        Me.XLAccount.StylePriority.UseTextAlignment = False
        Me.XLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(60.00001!, 27.99999!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = ":"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 27.99999!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Account"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Period"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(60.00001!, 5.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = ":"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 4.999987!)
        Me.XLPeriod.Name = "XLPeriod"
        Me.XLPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLPeriod.SizeF = New System.Drawing.SizeF(1000.0!, 23.0!)
        Me.XLPeriod.StylePriority.UseFont = False
        Me.XLPeriod.StylePriority.UseTextAlignment = False
        Me.XLPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(924.9999!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.XLTitle, Me.XrLine1})
        Me.ReportHeader.HeightF = 91.15003!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 15.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(220.0!, 41.15!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XLTitle
        '
        Me.XLTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XLTitle.LocationFloat = New DevExpress.Utils.PointFloat(220.0001!, 14.99999!)
        Me.XLTitle.Multiline = True
        Me.XLTitle.Name = "XLTitle"
        Me.XLTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTitle.SizeF = New System.Drawing.SizeF(634.9997!, 41.15001!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.StylePriority.UseTextAlignment = False
        Me.XLTitle.Text = "Buku Besar"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 71.15002!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1075.0!, 20.00001!)
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Qty"
        Me.GridColumn10.DisplayFormat.FormatString = "N2"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "qty"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 7
        '
        'ReportAccountingLedger
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 50, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCAccountingLedger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAccountingLedger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLAccount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCAccountingLedger As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAccountingLedger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
End Class
