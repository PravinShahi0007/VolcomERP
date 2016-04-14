<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportSamplePR
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
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdPRDetSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQtyRec = New DevExpress.XtraGrid.Columns.GridColumn
        Me.COlUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColTotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDebit = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel
        Me.LPayToAddress = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.LDONumber = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.LDueDate = New DevExpress.XtraReports.UI.XRLabel
        Me.LPONumber = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.LRecNumber = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.LPayToName = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.LPRNumber = New DevExpress.XtraReports.UI.XRLabel
        Me.LPRDate = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell
        Me.LTot = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel
        Me.LCur = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.LSay = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.LNote = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.LDP = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.LVat = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.LGrossTot = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.LNotex = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.LVatTot = New DevExpress.XtraReports.UI.XRLabel
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 150.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(650.0!, 150.0!)
        Me.WinControlContainer1.WinControl = Me.GCListPurchase
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(624, 144)
        Me.GCListPurchase.TabIndex = 0
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVListPurchase.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GVListPurchase.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVListPurchase.AppearancePrint.FooterPanel.Options.UseForeColor = True
        Me.GVListPurchase.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVListPurchase.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVListPurchase.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVListPurchase.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPRDetSample, Me.ColIdPurcDet, Me.ColType, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQtyRec, Me.COlUOM, Me.ColTotal, Me.ColDebit, Me.ColNote})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVListPurchase.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVListPurchase.OptionsPrint.UsePrintStyles = True
        Me.GVListPurchase.OptionsView.ShowFooter = True
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdPRDetSample
        '
        Me.ColIdPRDetSample.Caption = "ID Rec Det"
        Me.ColIdPRDetSample.FieldName = "id_pr_sample_purc_det"
        Me.ColIdPRDetSample.Name = "ColIdPRDetSample"
        Me.ColIdPRDetSample.OptionsColumn.AllowEdit = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Detail"
        Me.ColIdPurcDet.FieldName = "id_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        Me.ColIdPurcDet.OptionsColumn.AllowEdit = False
        '
        'ColType
        '
        Me.ColType.Caption = "Type"
        Me.ColType.FieldName = "type"
        Me.ColType.Name = "ColType"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColNo.Caption = "NO."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 28
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 79
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 165
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.OptionsColumn.AllowEdit = False
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 3
        Me.ColPrice.Width = 110
        '
        'ColQtyRec
        '
        Me.ColQtyRec.AppearanceCell.Options.UseTextOptions = True
        Me.ColQtyRec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyRec.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQtyRec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyRec.Caption = "Qty"
        Me.ColQtyRec.DisplayFormat.FormatString = "N2"
        Me.ColQtyRec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQtyRec.FieldName = "qty"
        Me.ColQtyRec.Name = "ColQtyRec"
        Me.ColQtyRec.OptionsColumn.AllowEdit = False
        Me.ColQtyRec.Visible = True
        Me.ColQtyRec.VisibleIndex = 4
        Me.ColQtyRec.Width = 38
        '
        'COlUOM
        '
        Me.COlUOM.AppearanceCell.Options.UseTextOptions = True
        Me.COlUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.COlUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.COlUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.COlUOM.Caption = "UOM"
        Me.COlUOM.FieldName = "uom"
        Me.COlUOM.Name = "COlUOM"
        Me.COlUOM.OptionsColumn.AllowEdit = False
        Me.COlUOM.Visible = True
        Me.COlUOM.VisibleIndex = 5
        Me.COlUOM.Width = 51
        '
        'ColTotal
        '
        Me.ColTotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotal.Caption = "Credit"
        Me.ColTotal.DisplayFormat.FormatString = "N2"
        Me.ColTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColTotal.FieldName = "total"
        Me.ColTotal.Name = "ColTotal"
        Me.ColTotal.OptionsColumn.AllowEdit = False
        Me.ColTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.ColTotal.Visible = True
        Me.ColTotal.VisibleIndex = 7
        Me.ColTotal.Width = 146
        '
        'ColDebit
        '
        Me.ColDebit.AppearanceCell.Options.UseTextOptions = True
        Me.ColDebit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDebit.AppearanceHeader.Options.UseTextOptions = True
        Me.ColDebit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDebit.Caption = "Debit"
        Me.ColDebit.DisplayFormat.FormatString = "N2"
        Me.ColDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDebit.FieldName = "debit"
        Me.ColDebit.Name = "ColDebit"
        Me.ColDebit.OptionsColumn.AllowEdit = False
        Me.ColDebit.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "{0:N2}")})
        Me.ColDebit.Visible = True
        Me.ColDebit.VisibleIndex = 6
        Me.ColDebit.Width = 140
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 8
        Me.ColNote.Width = 66
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1, Me.LPRNumber, Me.LPRDate, Me.XrLabel1, Me.XrLabel12, Me.LTitle})
        Me.TopMargin.HeightF = 114.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPanel1
        '
        Me.XrPanel1.BorderColor = System.Drawing.Color.DimGray
        Me.XrPanel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.CanGrow = False
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LPayToAddress, Me.XrLabel16, Me.XrLabel15, Me.LDONumber, Me.XrLabel8, Me.XrLabel7, Me.LDueDate, Me.LPONumber, Me.XrLabel5, Me.XrLabel21, Me.XrLabel13, Me.LRecNumber, Me.XrLabel11, Me.XrLabel9, Me.LPayToName, Me.XrLabel3})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 25.08337!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(649.9999!, 88.45833!)
        Me.XrPanel1.StylePriority.UseBorderColor = False
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'LPayToAddress
        '
        Me.LPayToAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LPayToAddress.LocationFloat = New DevExpress.Utils.PointFloat(79.0833!, 15.58337!)
        Me.LPayToAddress.Name = "LPayToAddress"
        Me.LPayToAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPayToAddress.SizeF = New System.Drawing.SizeF(219.8718!, 27.0!)
        Me.LPayToAddress.StylePriority.UseBorders = False
        '
        'XrLabel16
        '
        Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(323.2531!, 42.75006!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(85.41647!, 13.58337!)
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.Text = "Delivery No"
        '
        'XrLabel15
        '
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(408.6696!, 42.75006!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.Text = ":"
        '
        'LDONumber
        '
        Me.LDONumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LDONumber.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LDONumber.LocationFloat = New DevExpress.Utils.PointFloat(420.128!, 42.74999!)
        Me.LDONumber.Name = "LDONumber"
        Me.LDONumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDONumber.SizeF = New System.Drawing.SizeF(219.8719!, 13.58337!)
        Me.LDONumber.StylePriority.UseBorders = False
        Me.LDONumber.StylePriority.UseFont = False
        '
        'XrLabel8
        '
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(67.62495!, 56.3334!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(11.45834!, 13.58335!)
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.Text = ":"
        '
        'XrLabel7
        '
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(2.000046!, 56.33341!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(65.62492!, 13.58335!)
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.Text = "Due Date"
        '
        'LDueDate
        '
        Me.LDueDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LDueDate.LocationFloat = New DevExpress.Utils.PointFloat(79.0833!, 56.3334!)
        Me.LDueDate.Name = "LDueDate"
        Me.LDueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDueDate.SizeF = New System.Drawing.SizeF(219.8719!, 13.58335!)
        Me.LDueDate.StylePriority.UseBorders = False
        '
        'LPONumber
        '
        Me.LPONumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LPONumber.LocationFloat = New DevExpress.Utils.PointFloat(79.0833!, 42.75005!)
        Me.LPONumber.Name = "LPONumber"
        Me.LPONumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPONumber.SizeF = New System.Drawing.SizeF(219.8718!, 13.58337!)
        Me.LPONumber.StylePriority.UseBorders = False
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(1.999919!, 42.75005!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(65.62503!, 13.58335!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.Text = "Order No"
        '
        'XrLabel21
        '
        Me.XrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(323.253!, 56.33332!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(85.41647!, 13.58337!)
        Me.XrLabel21.StylePriority.UseBorders = False
        Me.XrLabel21.Text = "Receive No"
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(408.6695!, 56.3334!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.Text = ":"
        '
        'LRecNumber
        '
        Me.LRecNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LRecNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LRecNumber.LocationFloat = New DevExpress.Utils.PointFloat(420.128!, 56.3334!)
        Me.LRecNumber.Name = "LRecNumber"
        Me.LRecNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LRecNumber.SizeF = New System.Drawing.SizeF(219.8719!, 13.58336!)
        Me.LRecNumber.StylePriority.UseBorders = False
        Me.LRecNumber.StylePriority.UseFont = False
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(67.62498!, 2.00003!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'XrLabel9
        '
        Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(67.62495!, 42.75006!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(11.45834!, 13.58335!)
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.Text = ":"
        '
        'LPayToName
        '
        Me.LPayToName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LPayToName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LPayToName.LocationFloat = New DevExpress.Utils.PointFloat(79.0833!, 2.000013!)
        Me.LPayToName.Name = "LPayToName"
        Me.LPayToName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPayToName.SizeF = New System.Drawing.SizeF(219.8718!, 13.58335!)
        Me.LPayToName.StylePriority.UseBorders = False
        Me.LPayToName.StylePriority.UseFont = False
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.000014!, 2.000013!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(65.62495!, 13.58335!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.Text = "Paid To"
        '
        'LPRNumber
        '
        Me.LPRNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LPRNumber.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LPRNumber.LocationFloat = New DevExpress.Utils.PointFloat(79.08331!, 0.0!)
        Me.LPRNumber.Name = "LPRNumber"
        Me.LPRNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPRNumber.SizeF = New System.Drawing.SizeF(120.9165!, 25.08334!)
        Me.LPRNumber.StylePriority.UseBorders = False
        Me.LPRNumber.StylePriority.UseFont = False
        Me.LPRNumber.StylePriority.UseTextAlignment = False
        Me.LPRNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LPRDate
        '
        Me.LPRDate.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LPRDate.LocationFloat = New DevExpress.Utils.PointFloat(448.9585!, 0.0!)
        Me.LPRDate.Name = "LPRDate"
        Me.LPRDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPRDate.SizeF = New System.Drawing.SizeF(201.0415!, 25.08334!)
        Me.LPRDate.StylePriority.UseFont = False
        Me.LPRDate.StylePriority.UseTextAlignment = False
        Me.LPRDate.Text = "DATE"
        Me.LPRDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(67.62505!, 25.08334!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(67.62492!, 0.0!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(11.45835!, 25.08334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = ":"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(199.9998!, 0.0!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(248.9586!, 25.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "PAYMENT REQUISITION SAMPLE"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 19.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 0.0!)
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
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.LTot, Me.XrLabel24, Me.LCur, Me.XrLabel4, Me.LSay, Me.XrLabel2, Me.LNote, Me.XrLabel18, Me.LDP, Me.XrLabel14, Me.LVat, Me.XrLabel6, Me.LGrossTot, Me.XrLabel19, Me.XrLabel23, Me.XrLabel17, Me.LNotex, Me.XrLabel10, Me.LVatTot})
        Me.PageFooter.HeightF = 125.4166!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 99.99989!)
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
        'LTot
        '
        Me.LTot.BorderColor = System.Drawing.Color.DimGray
        Me.LTot.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LTot.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTot.LocationFloat = New DevExpress.Utils.PointFloat(550.0001!, 79.99989!)
        Me.LTot.Name = "LTot"
        Me.LTot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTot.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.LTot.StylePriority.UseBorderColor = False
        Me.LTot.StylePriority.UseBorders = False
        Me.LTot.StylePriority.UseFont = False
        Me.LTot.StylePriority.UseTextAlignment = False
        Me.LTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel24
        '
        Me.XrLabel24.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel24.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel24.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(299.9998!, 79.99989!)
        Me.XrLabel24.Name = "XrLabel24"
        Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel24.SizeF = New System.Drawing.SizeF(237.4999!, 20.0!)
        Me.XrLabel24.StylePriority.UseBorderColor = False
        Me.XrLabel24.StylePriority.UseBorders = False
        Me.XrLabel24.StylePriority.UseFont = False
        Me.XrLabel24.StylePriority.UseTextAlignment = False
        Me.XrLabel24.Text = "PLEASE PAY  THIS AMOUNT "
        Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LCur
        '
        Me.LCur.BorderColor = System.Drawing.Color.DimGray
        Me.LCur.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LCur.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCur.LocationFloat = New DevExpress.Utils.PointFloat(79.0833!, 79.99989!)
        Me.LCur.Name = "LCur"
        Me.LCur.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LCur.SizeF = New System.Drawing.SizeF(220.9165!, 20.00005!)
        Me.LCur.StylePriority.UseBorderColor = False
        Me.LCur.StylePriority.UseBorders = False
        Me.LCur.StylePriority.UseFont = False
        Me.LCur.StylePriority.UseTextAlignment = False
        Me.LCur.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel4.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(450.0001!, 39.9999!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(35.41669!, 39.99999!)
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "VAT"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LSay
        '
        Me.LSay.BorderColor = System.Drawing.Color.DimGray
        Me.LSay.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LSay.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSay.LocationFloat = New DevExpress.Utils.PointFloat(57.20844!, 0.0!)
        Me.LSay.Name = "LSay"
        Me.LSay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LSay.SizeF = New System.Drawing.SizeF(392.7917!, 40.0!)
        Me.LSay.StylePriority.UseBorderColor = False
        Me.LSay.StylePriority.UseBorders = False
        Me.LSay.StylePriority.UseFont = False
        '
        'XrLabel2
        '
        Me.XrLabel2.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel2.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(46.87503!, 39.99999!)
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "SAY"
        '
        'LNote
        '
        Me.LNote.BorderColor = System.Drawing.Color.DimGray
        Me.LNote.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LNote.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNote.LocationFloat = New DevExpress.Utils.PointFloat(57.20844!, 39.99987!)
        Me.LNote.Name = "LNote"
        Me.LNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNote.SizeF = New System.Drawing.SizeF(392.7917!, 40.00003!)
        Me.LNote.StylePriority.UseBorderColor = False
        Me.LNote.StylePriority.UseBorders = False
        Me.LNote.StylePriority.UseFont = False
        '
        'XrLabel18
        '
        Me.XrLabel18.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel18.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel18.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(450.0001!, 19.99998!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel18.StylePriority.UseBorderColor = False
        Me.XrLabel18.StylePriority.UseBorders = False
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.StylePriority.UseTextAlignment = False
        Me.XrLabel18.Text = "DP"
        Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LDP
        '
        Me.LDP.BorderColor = System.Drawing.Color.DimGray
        Me.LDP.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LDP.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDP.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 19.99998!)
        Me.LDP.Name = "LDP"
        Me.LDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDP.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.LDP.StylePriority.UseBorderColor = False
        Me.LDP.StylePriority.UseBorders = False
        Me.LDP.StylePriority.UseFont = False
        Me.LDP.StylePriority.UseTextAlignment = False
        Me.LDP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel14
        '
        Me.XrLabel14.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel14.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(46.87503!, 39.99999!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(10.3334!, 39.99999!)
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.Text = ":"
        '
        'LVat
        '
        Me.LVat.BorderColor = System.Drawing.Color.DimGray
        Me.LVat.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.LVat.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVat.LocationFloat = New DevExpress.Utils.PointFloat(485.4168!, 39.9999!)
        Me.LVat.Name = "LVat"
        Me.LVat.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LVat.SizeF = New System.Drawing.SizeF(39.58307!, 39.99999!)
        Me.LVat.StylePriority.UseBorderColor = False
        Me.LVat.StylePriority.UseBorders = False
        Me.LVat.StylePriority.UseFont = False
        Me.LVat.StylePriority.UseTextAlignment = False
        Me.LVat.Text = "0"
        Me.LVat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel6.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(537.5001!, 79.99989!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(12.5!, 19.99998!)
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'LGrossTot
        '
        Me.LGrossTot.BorderColor = System.Drawing.Color.DimGray
        Me.LGrossTot.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LGrossTot.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LGrossTot.LocationFloat = New DevExpress.Utils.PointFloat(550.0001!, 0.0!)
        Me.LGrossTot.Name = "LGrossTot"
        Me.LGrossTot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LGrossTot.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.LGrossTot.StylePriority.UseBorderColor = False
        Me.LGrossTot.StylePriority.UseBorders = False
        Me.LGrossTot.StylePriority.UseFont = False
        Me.LGrossTot.StylePriority.UseTextAlignment = False
        Me.LGrossTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel19
        '
        Me.XrLabel19.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel19.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel19.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(524.9999!, 39.9999!)
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(25.00024!, 39.99999!)
        Me.XrLabel19.StylePriority.UseBorderColor = False
        Me.XrLabel19.StylePriority.UseBorders = False
        Me.XrLabel19.StylePriority.UseFont = False
        Me.XrLabel19.StylePriority.UseTextAlignment = False
        Me.XrLabel19.Text = "%"
        Me.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel23
        '
        Me.XrLabel23.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel23.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel23.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 79.99989!)
        Me.XrLabel23.Name = "XrLabel23"
        Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel23.SizeF = New System.Drawing.SizeF(79.0834!, 20.00002!)
        Me.XrLabel23.StylePriority.UseBorderColor = False
        Me.XrLabel23.StylePriority.UseBorders = False
        Me.XrLabel23.StylePriority.UseFont = False
        Me.XrLabel23.StylePriority.UseTextAlignment = False
        Me.XrLabel23.Text = "CURRENCY : "
        Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel17
        '
        Me.XrLabel17.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel17.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel17.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(450.0001!, 0.0!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel17.StylePriority.UseBorderColor = False
        Me.XrLabel17.StylePriority.UseBorders = False
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.StylePriority.UseTextAlignment = False
        Me.XrLabel17.Text = "GROSS TOTAL"
        Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LNotex
        '
        Me.LNotex.BorderColor = System.Drawing.Color.DimGray
        Me.LNotex.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.LNotex.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNotex.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 39.99999!)
        Me.LNotex.Name = "LNotex"
        Me.LNotex.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNotex.SizeF = New System.Drawing.SizeF(46.87503!, 40.00001!)
        Me.LNotex.StylePriority.UseBorderColor = False
        Me.LNotex.StylePriority.UseBorders = False
        Me.LNotex.StylePriority.UseFont = False
        Me.LNotex.Text = "NOTE "
        '
        'XrLabel10
        '
        Me.XrLabel10.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel10.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(46.87503!, 0.0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(10.3334!, 39.99999!)
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.Text = ":"
        '
        'LVatTot
        '
        Me.LVatTot.BorderColor = System.Drawing.Color.DimGray
        Me.LVatTot.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LVatTot.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVatTot.LocationFloat = New DevExpress.Utils.PointFloat(549.9997!, 39.99996!)
        Me.LVatTot.Name = "LVatTot"
        Me.LVatTot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LVatTot.SizeF = New System.Drawing.SizeF(100.0!, 39.99993!)
        Me.LVatTot.StylePriority.UseBorderColor = False
        Me.LVatTot.StylePriority.UseBorders = False
        Me.LVatTot.StylePriority.UseFont = False
        Me.LVatTot.StylePriority.UseTextAlignment = False
        Me.LVatTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportSamplePR
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(100, 99, 114, 19)
        Me.PageHeight = 500
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Version = "11.1"
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents LPRNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPRDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPRDetSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQtyRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents COlUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents ColType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDebit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LPayToAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDONumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDueDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPONumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LRecNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPayToName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents LTot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LCur As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LSay As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDP As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LVat As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LGrossTot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNotex As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LVatTot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
End Class
