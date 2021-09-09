<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportDebitNote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportDebitNote))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIMDescription = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GCKurs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCClaimPercent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCPriceUSD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCClaimUSD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCAmoUSD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCPriceUnit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCClaimPcs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.LTanggal = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LKepada = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.LTerbilang = New DevExpress.XtraReports.UI.XRLabel()
        Me.LSay = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LDengan = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LSummary = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIMDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 155.2083!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1054.0!, 155.2083!)
        Me.WinControlContainer1.WinControl = Me.GCItemList
        '
        'GCItemList
        '
        Me.GCItemList.Location = New System.Drawing.Point(20, 2)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1, Me.RIMDescription})
        Me.GCItemList.Size = New System.Drawing.Size(1012, 149)
        Me.GCItemList.TabIndex = 2
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.AppearancePrint.HeaderPanel.Options.UseTextOptions = True
        Me.GVItemList.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVItemList.ColumnPanelRowHeight = 50
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn13, Me.GridColumn12, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GCKurs, Me.GCClaimPercent, Me.GridColumn10, Me.GridColumn8, Me.GCPriceUSD, Me.GCClaimUSD, Me.GCAmoUSD, Me.GCPriceUnit, Me.GridColumn9, Me.GCClaimPcs, Me.GridColumn11})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.ReadOnly = True
        Me.GVItemList.OptionsCustomization.AllowGroup = False
        Me.GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItemList.OptionsPrint.AllowMultilineHeaders = True
        Me.GVItemList.OptionsView.AllowHtmlDrawHeaders = True
        Me.GVItemList.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsView.RowAutoHeight = True
        Me.GVItemList.OptionsView.ShowFooter = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_debit_note_det"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID Report"
        Me.GridColumn13.FieldName = "id_report"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Report Mark Type"
        Me.GridColumn12.FieldName = "report_mark_type"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "No"
        Me.GridColumn3.FieldName = "number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 51
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Number"
        Me.GridColumn4.FieldName = "report_number"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "report_number", "TOTAL")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 138
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Design"
        Me.GridColumn5.FieldName = "info_design"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 138
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Deskripsi"
        Me.GridColumn6.ColumnEdit = Me.RIMDescription
        Me.GridColumn6.FieldName = "description"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        Me.GridColumn6.Width = 138
        '
        'RIMDescription
        '
        Me.RIMDescription.Name = "RIMDescription"
        '
        'GCKurs
        '
        Me.GCKurs.AppearanceCell.Options.UseTextOptions = True
        Me.GCKurs.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCKurs.AppearanceHeader.Options.UseTextOptions = True
        Me.GCKurs.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCKurs.Caption = "Kurs"
        Me.GCKurs.DisplayFormat.FormatString = "N2"
        Me.GCKurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCKurs.FieldName = "kurs"
        Me.GCKurs.Name = "GCKurs"
        Me.GCKurs.Visible = True
        Me.GCKurs.VisibleIndex = 8
        Me.GCKurs.Width = 90
        '
        'GCClaimPercent
        '
        Me.GCClaimPercent.AppearanceCell.Options.UseTextOptions = True
        Me.GCClaimPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCClaimPercent.AppearanceHeader.Options.UseTextOptions = True
        Me.GCClaimPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCClaimPercent.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCClaimPercent.Caption = "Claim <br> (%)"
        Me.GCClaimPercent.DisplayFormat.FormatString = "N2"
        Me.GCClaimPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCClaimPercent.FieldName = "claim_percent"
        Me.GCClaimPercent.Name = "GCClaimPercent"
        Me.GCClaimPercent.Visible = True
        Me.GCClaimPercent.VisibleIndex = 4
        Me.GCClaimPercent.Width = 99
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "ID Currency"
        Me.GridColumn10.FieldName = "id_currency"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "Currency"
        Me.GridColumn8.FieldName = "currency"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 5
        Me.GridColumn8.Width = 90
        '
        'GCPriceUSD
        '
        Me.GCPriceUSD.AppearanceCell.Options.UseTextOptions = True
        Me.GCPriceUSD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCPriceUSD.AppearanceHeader.Options.UseTextOptions = True
        Me.GCPriceUSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCPriceUSD.Caption = "Price / Unit <br> (USD)"
        Me.GCPriceUSD.DisplayFormat.FormatString = "N2"
        Me.GCPriceUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCPriceUSD.FieldName = "unit_price_usd"
        Me.GCPriceUSD.Name = "GCPriceUSD"
        Me.GCPriceUSD.Visible = True
        Me.GCPriceUSD.VisibleIndex = 6
        Me.GCPriceUSD.Width = 90
        '
        'GCClaimUSD
        '
        Me.GCClaimUSD.AppearanceCell.Options.UseTextOptions = True
        Me.GCClaimUSD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCClaimUSD.AppearanceHeader.Options.UseTextOptions = True
        Me.GCClaimUSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCClaimUSD.Caption = "Claim / Pcs <br> (USD)"
        Me.GCClaimUSD.DisplayFormat.FormatString = "N2"
        Me.GCClaimUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCClaimUSD.FieldName = "claim_pcs_usd"
        Me.GCClaimUSD.Name = "GCClaimUSD"
        Me.GCClaimUSD.Visible = True
        Me.GCClaimUSD.VisibleIndex = 7
        Me.GCClaimUSD.Width = 90
        '
        'GCAmoUSD
        '
        Me.GCAmoUSD.AppearanceCell.Options.UseTextOptions = True
        Me.GCAmoUSD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCAmoUSD.AppearanceHeader.Options.UseTextOptions = True
        Me.GCAmoUSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCAmoUSD.Caption = "Total Amount <br> (USD)"
        Me.GCAmoUSD.DisplayFormat.FormatString = "N2"
        Me.GCAmoUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCAmoUSD.FieldName = "claim_amo_usd"
        Me.GCAmoUSD.Name = "GCAmoUSD"
        Me.GCAmoUSD.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "claim_amo_usd", "{0:N2}")})
        Me.GCAmoUSD.Visible = True
        Me.GCAmoUSD.VisibleIndex = 12
        Me.GCAmoUSD.Width = 122
        '
        'GCPriceUnit
        '
        Me.GCPriceUnit.AppearanceCell.Options.UseTextOptions = True
        Me.GCPriceUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCPriceUnit.AppearanceHeader.Options.UseTextOptions = True
        Me.GCPriceUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCPriceUnit.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCPriceUnit.Caption = "Price / Unit <br> (Rp)"
        Me.GCPriceUnit.DisplayFormat.FormatString = "N2"
        Me.GCPriceUnit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCPriceUnit.FieldName = "unit_price"
        Me.GCPriceUnit.Name = "GCPriceUnit"
        Me.GCPriceUnit.Visible = True
        Me.GCPriceUnit.VisibleIndex = 9
        Me.GCPriceUnit.Width = 143
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.Caption = "Qty"
        Me.GridColumn9.DisplayFormat.FormatString = "N0"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "qty"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 11
        Me.GridColumn9.Width = 143
        '
        'GCClaimPcs
        '
        Me.GCClaimPcs.AppearanceCell.Options.UseTextOptions = True
        Me.GCClaimPcs.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCClaimPcs.AppearanceHeader.Options.UseTextOptions = True
        Me.GCClaimPcs.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCClaimPcs.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCClaimPcs.Caption = "Claim / Pcs <br> (Rp)"
        Me.GCClaimPcs.DisplayFormat.FormatString = "N2"
        Me.GCClaimPcs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCClaimPcs.FieldName = "claim_pcs"
        Me.GCClaimPcs.Name = "GCClaimPcs"
        Me.GCClaimPcs.Visible = True
        Me.GCClaimPcs.VisibleIndex = 10
        Me.GCClaimPcs.Width = 143
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn11.Caption = "Total Amount <br> (Rp)"
        Me.GridColumn11.DisplayFormat.FormatString = "N2"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "claim_amo"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "claim_amo", "{0:N2}")})
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 13
        Me.GridColumn11.Width = 141
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 26.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 20.83333!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LTanggal, Me.XrLabel8, Me.XrLabel9, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrPictureBox1, Me.XrLabel3, Me.XrLabel2, Me.LKepada})
        Me.ReportHeader.HeightF = 171.475!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'LTanggal
        '
        Me.LTanggal.LocationFloat = New DevExpress.Utils.PointFloat(799.0925!, 125.0001!)
        Me.LTanggal.Name = "LTanggal"
        Me.LTanggal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTanggal.SizeF = New System.Drawing.SizeF(71.02411!, 18.0!)
        Me.LTanggal.Text = "TANGGAL"
        '
        'XrLabel8
        '
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(882.8618!, 125.0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(160.0965!, 18.00003!)
        Me.XrLabel8.Text = "[created_date]"
        '
        'XrLabel9
        '
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(870.1167!, 125.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(12.74515!, 18.00002!)
        Me.XrLabel9.Text = ":"
        '
        'XrLabel6
        '
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(870.1167!, 107.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(12.74515!, 18.00002!)
        Me.XrLabel6.Text = ":"
        '
        'XrLabel5
        '
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(882.8618!, 107.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(160.0965!, 18.00001!)
        Me.XrLabel5.Text = "[number]"
        '
        'XrLabel4
        '
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(799.0925!, 107.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(71.02411!, 18.0!)
        Me.XrLabel4.Text = "NO"
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(491.0508!, 0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(146.3542!, 99.89584!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel3
        '
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(67.01389!, 130.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(273.9583!, 41.47501!)
        Me.XrLabel3.Text = "[address_primary]"
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(67.01389!, 107.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(273.9583!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "[comp_name]"
        '
        'LKepada
        '
        Me.LKepada.LocationFloat = New DevExpress.Utils.PointFloat(0!, 107.0!)
        Me.LKepada.Name = "LKepada"
        Me.LKepada.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LKepada.SizeF = New System.Drawing.SizeF(67.01389!, 23.0!)
        Me.LKepada.Text = "KEPADA :"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LSummary, Me.LTerbilang, Me.LSay, Me.XrLabel12, Me.XrLabel13, Me.LDengan, Me.XrLabel15, Me.XrTable1})
        Me.ReportFooter.HeightF = 144.25!
        Me.ReportFooter.KeepTogether = True
        Me.ReportFooter.Name = "ReportFooter"
        '
        'LTerbilang
        '
        Me.LTerbilang.LocationFloat = New DevExpress.Utils.PointFloat(0!, 56.24999!)
        Me.LTerbilang.Name = "LTerbilang"
        Me.LTerbilang.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTerbilang.SizeF = New System.Drawing.SizeF(87.51717!, 18.0!)
        Me.LTerbilang.Text = "Terbilang"
        '
        'LSay
        '
        Me.LSay.LocationFloat = New DevExpress.Utils.PointFloat(100.2624!, 56.25001!)
        Me.LSay.Name = "LSay"
        Me.LSay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LSay.SizeF = New System.Drawing.SizeF(953.7374!, 18.00001!)
        '
        'XrLabel12
        '
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(87.51718!, 56.24999!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(12.74515!, 18.00002!)
        Me.XrLabel12.Text = ":"
        '
        'XrLabel13
        '
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(87.51713!, 74.24995!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(12.74515!, 18.00002!)
        Me.XrLabel13.Text = ":"
        '
        'LDengan
        '
        Me.LDengan.LocationFloat = New DevExpress.Utils.PointFloat(100.2624!, 74.25004!)
        Me.LDengan.Name = "LDengan"
        Me.LDengan.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDengan.SizeF = New System.Drawing.SizeF(953.7375!, 18.00003!)
        Me.LDengan.Text = "Dengan Pemotongan Invoice"
        '
        'XrLabel15
        '
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(0!, 74.25001!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(87.51717!, 18.0!)
        Me.XrLabel15.Text = "Account"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 119.25!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1054.0!, 25.0!)
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
        'LSummary
        '
        Me.LSummary.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Italic)
        Me.LSummary.LocationFloat = New DevExpress.Utils.PointFloat(0!, 14.0!)
        Me.LSummary.Name = "LSummary"
        Me.LSummary.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LSummary.SizeF = New System.Drawing.SizeF(1054.0!, 18.00001!)
        Me.LSummary.StylePriority.UseFont = False
        '
        'ReportDebitNote
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(49, 66, 26, 21)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIMDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LKepada As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTanggal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents LTerbilang As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LSay As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDengan As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIMDescription As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GCKurs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCClaimPercent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCPriceUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCClaimUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCAmoUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCPriceUnit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCClaimPcs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents LSummary As DevExpress.XtraReports.UI.XRLabel
End Class
