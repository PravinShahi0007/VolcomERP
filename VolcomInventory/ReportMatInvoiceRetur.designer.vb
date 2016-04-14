<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportMatInvoiceRetur
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
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQtyRec = New DevExpress.XtraGrid.Columns.GridColumn
        Me.COlUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdMatDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyRet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel
        Me.LReturNumber = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.zxc = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.LDate = New DevExpress.XtraReports.UI.XRLabel
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.LInvoice = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.LPDONumber = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel26 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel
        Me.LDesign = New DevExpress.XtraReports.UI.XRLabel
        Me.LPLNumber = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel
        Me.LFromNPWP = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel48 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel47 = New DevExpress.XtraReports.UI.XRLabel
        Me.LToNPWP = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel
        Me.LDueDate = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel
        Me.LToAddress = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.LToName = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.LFromName = New DevExpress.XtraReports.UI.XRLabel
        Me.LFromAddress = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel
        Me.LCurGross = New DevExpress.XtraReports.UI.XRLabel
        Me.LCurVat = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrLabel41 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel36 = New DevExpress.XtraReports.UI.XRLabel
        Me.LTot = New DevExpress.XtraReports.UI.XRLabel
        Me.LCurTot = New DevExpress.XtraReports.UI.XRLabel
        Me.LNote = New DevExpress.XtraReports.UI.XRLabel
        Me.LSay = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel29 = New DevExpress.XtraReports.UI.XRLabel
        Me.LGrossTot = New DevExpress.XtraReports.UI.XRLabel
        Me.LNotex = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel32 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel34 = New DevExpress.XtraReports.UI.XRLabel
        Me.LVat = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel
        Me.LVatTot = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 142.7083!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(650.0!, 142.7083!)
        Me.WinControlContainer1.WinControl = Me.GCListPurchase
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCListPurchase.Size = New System.Drawing.Size(624, 137)
        Me.GCListPurchase.TabIndex = 1
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase, Me.GridView1})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.Transparent
        Me.GVListPurchase.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVListPurchase.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVListPurchase.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPRDetSample, Me.ColIdPurcDet, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQtyRec, Me.COlUOM, Me.ColNote, Me.GridColumnTotal, Me.GridColumnIdMatDet, Me.GridColumnQtyRet})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVListPurchase.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVListPurchase.OptionsPrint.PrintFooter = False
        Me.GVListPurchase.OptionsPrint.UsePrintStyles = True
        Me.GVListPurchase.OptionsView.ShowFooter = True
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdPRDetSample
        '
        Me.ColIdPRDetSample.Caption = "ID Rec Det"
        Me.ColIdPRDetSample.FieldName = "id_inv_pl_mrs_ret_det"
        Me.ColIdPRDetSample.Name = "ColIdPRDetSample"
        Me.ColIdPRDetSample.OptionsColumn.AllowEdit = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Detail"
        Me.ColIdPurcDet.FieldName = "id_inv_pl_mrs_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        Me.ColIdPurcDet.OptionsColumn.AllowEdit = False
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 26
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 74
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 157
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
        Me.ColPrice.VisibleIndex = 5
        Me.ColPrice.Width = 66
        '
        'ColQtyRec
        '
        Me.ColQtyRec.AppearanceCell.Options.UseTextOptions = True
        Me.ColQtyRec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyRec.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQtyRec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyRec.Caption = "Qty Invoice"
        Me.ColQtyRec.DisplayFormat.FormatString = "N2"
        Me.ColQtyRec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQtyRec.FieldName = "qty"
        Me.ColQtyRec.Name = "ColQtyRec"
        Me.ColQtyRec.OptionsColumn.AllowEdit = False
        Me.ColQtyRec.Width = 70
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
        Me.COlUOM.VisibleIndex = 4
        Me.COlUOM.Width = 44
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 7
        Me.ColNote.Width = 80
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "total_price"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.OptionsColumn.AllowEdit = False
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_price", "{0:N2}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 6
        Me.GridColumnTotal.Width = 79
        '
        'GridColumnIdMatDet
        '
        Me.GridColumnIdMatDet.Caption = "Id Mat"
        Me.GridColumnIdMatDet.FieldName = "id_mat_det"
        Me.GridColumnIdMatDet.Name = "GridColumnIdMatDet"
        '
        'GridColumnQtyRet
        '
        Me.GridColumnQtyRet.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyRet.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyRet.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyRet.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyRet.Caption = "Qty Retur"
        Me.GridColumnQtyRet.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQtyRet.FieldName = "inv_pl_mrs_ret_det_qty"
        Me.GridColumnQtyRet.Name = "GridColumnQtyRet"
        Me.GridColumnQtyRet.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyRet.Visible = True
        Me.GridColumnQtyRet.VisibleIndex = 3
        Me.GridColumnQtyRet.Width = 80
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "n2"
        Me.RepositoryItemSpinEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 131072})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GCListPurchase
        Me.GridView1.Name = "GridView1"
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LTitle, Me.LReturNumber, Me.XrLabel12, Me.XrLabel6, Me.zxc, Me.XrLabel1, Me.LDate, Me.XrPanel1})
        Me.TopMargin.HeightF = 144.1667!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(199.9992!, 0.0!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(248.9586!, 25.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "NOTA RETUR"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'LReturNumber
        '
        Me.LReturNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LReturNumber.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LReturNumber.LocationFloat = New DevExpress.Utils.PointFloat(88.45837!, 0.0!)
        Me.LReturNumber.Name = "LReturNumber"
        Me.LReturNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LReturNumber.SizeF = New System.Drawing.SizeF(111.5409!, 25.08334!)
        Me.LReturNumber.StylePriority.UseBorders = False
        Me.LReturNumber.StylePriority.UseFont = False
        Me.LReturNumber.StylePriority.UseTextAlignment = False
        Me.LReturNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(77.00002!, 0.0!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(11.45835!, 25.08334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = ":"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(549.1658!, 0.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(11.45844!, 25.08334!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = ":"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'zxc
        '
        Me.zxc.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.zxc.LocationFloat = New DevExpress.Utils.PointFloat(448.9578!, 0.0!)
        Me.zxc.Name = "zxc"
        Me.zxc.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.zxc.SizeF = New System.Drawing.SizeF(100.2081!, 25.08334!)
        Me.zxc.StylePriority.UseFont = False
        Me.zxc.StylePriority.UseTextAlignment = False
        Me.zxc.Text = "DATE"
        Me.zxc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(77.00014!, 25.08334!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LDate
        '
        Me.LDate.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LDate.LocationFloat = New DevExpress.Utils.PointFloat(560.6249!, 0.0!)
        Me.LDate.Name = "LDate"
        Me.LDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDate.SizeF = New System.Drawing.SizeF(89.37506!, 25.08334!)
        Me.LDate.StylePriority.UseFont = False
        Me.LDate.StylePriority.UseTextAlignment = False
        Me.LDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrPanel1
        '
        Me.XrPanel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.CanGrow = False
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel10, Me.LInvoice, Me.XrLabel7, Me.LPDONumber, Me.XrLabel26, Me.XrLabel25, Me.XrLabel24, Me.XrLabel23, Me.LDesign, Me.LPLNumber, Me.XrLabel17, Me.XrLabel16, Me.LFromNPWP, Me.XrLabel5, Me.XrLabel2, Me.XrLabel48, Me.XrLabel47, Me.LToNPWP, Me.XrLabel30, Me.LDueDate, Me.XrLabel20, Me.XrLabel19, Me.LToAddress, Me.XrLabel21, Me.XrLabel13, Me.LToName, Me.XrLabel15, Me.XrLabel11, Me.XrLabel9, Me.LFromName, Me.LFromAddress, Me.XrLabel4, Me.XrLabel3})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 25.08334!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(649.9999!, 119.0834!)
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(2.000084!, 2.00003!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(75.0!, 13.58337!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.Text = "Invoice"
        '
        'LInvoice
        '
        Me.LInvoice.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LInvoice.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LInvoice.LocationFloat = New DevExpress.Utils.PointFloat(88.45838!, 2.000062!)
        Me.LInvoice.Name = "LInvoice"
        Me.LInvoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LInvoice.SizeF = New System.Drawing.SizeF(237.5002!, 13.58334!)
        Me.LInvoice.StylePriority.UseBorders = False
        Me.LInvoice.StylePriority.UseFont = False
        Me.LInvoice.StylePriority.UseTextAlignment = False
        Me.LInvoice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel7
        '
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(77.00008!, 2.00003!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = ":"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LPDONumber
        '
        Me.LPDONumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LPDONumber.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LPDONumber.LocationFloat = New DevExpress.Utils.PointFloat(88.45809!, 83.33337!)
        Me.LPDONumber.Name = "LPDONumber"
        Me.LPDONumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPDONumber.SizeF = New System.Drawing.SizeF(237.5006!, 13.58334!)
        Me.LPDONumber.StylePriority.UseBorders = False
        Me.LPDONumber.StylePriority.UseFont = False
        Me.LPDONumber.StylePriority.UseTextAlignment = False
        Me.LPDONumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel26
        '
        Me.XrLabel26.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(77.00002!, 83.33337!)
        Me.XrLabel26.Name = "XrLabel26"
        Me.XrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel26.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel26.StylePriority.UseBorders = False
        Me.XrLabel26.StylePriority.UseTextAlignment = False
        Me.XrLabel26.Text = ":"
        Me.XrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel25
        '
        Me.XrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(1.999664!, 83.33334!)
        Me.XrLabel25.Name = "XrLabel25"
        Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel25.SizeF = New System.Drawing.SizeF(75.0!, 13.58337!)
        Me.XrLabel25.StylePriority.UseBorders = False
        Me.XrLabel25.Text = "PDO"
        '
        'XrLabel24
        '
        Me.XrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(352.0835!, 83.33338!)
        Me.XrLabel24.Name = "XrLabel24"
        Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel24.SizeF = New System.Drawing.SizeF(69.99969!, 13.58337!)
        Me.XrLabel24.StylePriority.UseBorders = False
        Me.XrLabel24.Text = "Design"
        '
        'XrLabel23
        '
        Me.XrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(422.0832!, 83.33335!)
        Me.XrLabel23.Name = "XrLabel23"
        Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel23.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel23.StylePriority.UseBorders = False
        Me.XrLabel23.StylePriority.UseTextAlignment = False
        Me.XrLabel23.Text = ":"
        Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LDesign
        '
        Me.LDesign.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LDesign.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LDesign.LocationFloat = New DevExpress.Utils.PointFloat(433.5416!, 83.33347!)
        Me.LDesign.Name = "LDesign"
        Me.LDesign.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDesign.SizeF = New System.Drawing.SizeF(206.5421!, 13.58334!)
        Me.LDesign.StylePriority.UseBorders = False
        Me.LDesign.StylePriority.UseFont = False
        Me.LDesign.StylePriority.UseTextAlignment = False
        Me.LDesign.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LPLNumber
        '
        Me.LPLNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LPLNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LPLNumber.LocationFloat = New DevExpress.Utils.PointFloat(88.4585!, 69.74999!)
        Me.LPLNumber.Name = "LPLNumber"
        Me.LPLNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPLNumber.SizeF = New System.Drawing.SizeF(237.5002!, 13.58334!)
        Me.LPLNumber.StylePriority.UseBorders = False
        Me.LPLNumber.StylePriority.UseFont = False
        Me.LPLNumber.StylePriority.UseTextAlignment = False
        Me.LPLNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel17
        '
        Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(77.00014!, 69.74999!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel17.StylePriority.UseBorders = False
        Me.XrLabel17.StylePriority.UseTextAlignment = False
        Me.XrLabel17.Text = ":"
        Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel16
        '
        Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(2.000141!, 69.74998!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(75.0!, 13.58337!)
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.Text = "Work Order"
        '
        'LFromNPWP
        '
        Me.LFromNPWP.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LFromNPWP.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LFromNPWP.LocationFloat = New DevExpress.Utils.PointFloat(88.458!, 56.16658!)
        Me.LFromNPWP.Name = "LFromNPWP"
        Me.LFromNPWP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LFromNPWP.SizeF = New System.Drawing.SizeF(237.5005!, 13.58335!)
        Me.LFromNPWP.StylePriority.UseBorders = False
        Me.LFromNPWP.StylePriority.UseFont = False
        Me.LFromNPWP.StylePriority.UseTextAlignment = False
        Me.LFromNPWP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(77.00002!, 56.16658!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = ":"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(2.000046!, 56.16658!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(74.99997!, 13.58337!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.Text = "NPWP"
        '
        'XrLabel48
        '
        Me.XrLabel48.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel48.LocationFloat = New DevExpress.Utils.PointFloat(352.0001!, 56.16669!)
        Me.XrLabel48.Name = "XrLabel48"
        Me.XrLabel48.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel48.SizeF = New System.Drawing.SizeF(69.99957!, 13.58337!)
        Me.XrLabel48.StylePriority.UseBorders = False
        Me.XrLabel48.Text = "NPWP"
        '
        'XrLabel47
        '
        Me.XrLabel47.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel47.LocationFloat = New DevExpress.Utils.PointFloat(421.9996!, 56.16674!)
        Me.XrLabel47.Name = "XrLabel47"
        Me.XrLabel47.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel47.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel47.StylePriority.UseBorders = False
        Me.XrLabel47.StylePriority.UseTextAlignment = False
        Me.XrLabel47.Text = ":"
        Me.XrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LToNPWP
        '
        Me.LToNPWP.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LToNPWP.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LToNPWP.LocationFloat = New DevExpress.Utils.PointFloat(433.4579!, 56.16669!)
        Me.LToNPWP.Name = "LToNPWP"
        Me.LToNPWP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LToNPWP.SizeF = New System.Drawing.SizeF(206.5419!, 13.58335!)
        Me.LToNPWP.StylePriority.UseBorders = False
        Me.LToNPWP.StylePriority.UseFont = False
        Me.LToNPWP.StylePriority.UseTextAlignment = False
        Me.LToNPWP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel30
        '
        Me.XrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(421.9996!, 1.999998!)
        Me.XrLabel30.Name = "XrLabel30"
        Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel30.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel30.StylePriority.UseBorders = False
        Me.XrLabel30.StylePriority.UseTextAlignment = False
        Me.XrLabel30.Text = ":"
        Me.XrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LDueDate
        '
        Me.LDueDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LDueDate.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.LDueDate.LocationFloat = New DevExpress.Utils.PointFloat(433.4579!, 1.999998!)
        Me.LDueDate.Name = "LDueDate"
        Me.LDueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDueDate.SizeF = New System.Drawing.SizeF(206.5419!, 13.58335!)
        Me.LDueDate.StylePriority.UseBorders = False
        Me.LDueDate.StylePriority.UseFont = False
        Me.LDueDate.StylePriority.UseTextAlignment = False
        Me.LDueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel20
        '
        Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(352.0001!, 2.000029!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(69.99957!, 13.58335!)
        Me.XrLabel20.StylePriority.UseBorders = False
        Me.XrLabel20.StylePriority.UseTextAlignment = False
        Me.XrLabel20.Text = "Due Date"
        Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel19
        '
        Me.XrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(352.0001!, 29.16662!)
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(69.99957!, 13.58335!)
        Me.XrLabel19.StylePriority.UseBorders = False
        Me.XrLabel19.Text = "Address"
        '
        'LToAddress
        '
        Me.LToAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LToAddress.LocationFloat = New DevExpress.Utils.PointFloat(433.4579!, 29.16668!)
        Me.LToAddress.Name = "LToAddress"
        Me.LToAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LToAddress.SizeF = New System.Drawing.SizeF(206.5421!, 27.00001!)
        Me.LToAddress.StylePriority.UseBorders = False
        '
        'XrLabel21
        '
        Me.XrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(352.0!, 15.58326!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(69.99969!, 13.58337!)
        Me.XrLabel21.StylePriority.UseBorders = False
        Me.XrLabel21.Text = "To"
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(421.9996!, 15.58326!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.Text = ":"
        '
        'LToName
        '
        Me.LToName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LToName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LToName.LocationFloat = New DevExpress.Utils.PointFloat(433.4579!, 15.58329!)
        Me.LToName.Name = "LToName"
        Me.LToName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LToName.SizeF = New System.Drawing.SizeF(206.5419!, 13.58338!)
        Me.LToName.StylePriority.UseBorders = False
        Me.LToName.StylePriority.UseFont = False
        '
        'XrLabel15
        '
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(421.9996!, 29.16662!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(11.45837!, 13.58335!)
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.Text = ":"
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(77.00008!, 15.58323!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'XrLabel9
        '
        Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(76.99966!, 29.16656!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(11.45834!, 13.58335!)
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.Text = ":"
        '
        'LFromName
        '
        Me.LFromName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LFromName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LFromName.LocationFloat = New DevExpress.Utils.PointFloat(88.45838!, 15.58326!)
        Me.LFromName.Name = "LFromName"
        Me.LFromName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LFromName.SizeF = New System.Drawing.SizeF(237.5002!, 13.58335!)
        Me.LFromName.StylePriority.UseBorders = False
        Me.LFromName.StylePriority.UseFont = False
        '
        'LFromAddress
        '
        Me.LFromAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LFromAddress.LocationFloat = New DevExpress.Utils.PointFloat(88.458!, 29.16659!)
        Me.LFromAddress.Name = "LFromAddress"
        Me.LFromAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LFromAddress.SizeF = New System.Drawing.SizeF(237.5002!, 27.0!)
        Me.LFromAddress.StylePriority.UseBorders = False
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(1.999664!, 29.16659!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(74.99997!, 13.58335!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.Text = "Address"
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.000014!, 15.58325!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(75.00007!, 13.58335!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.Text = "From"
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 19.20834!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 0.4904111!)
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
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel22, Me.LCurGross, Me.LCurVat, Me.XrLabel8, Me.XrTable1, Me.XrLabel41, Me.XrLabel36, Me.LTot, Me.LCurTot, Me.LNote, Me.LSay, Me.XrLabel29, Me.LGrossTot, Me.LNotex, Me.XrLabel32, Me.XrLabel34, Me.LVat, Me.XrLabel31, Me.LVatTot, Me.XrLabel28})
        Me.PageFooter.HeightF = 105.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrLabel22
        '
        Me.XrLabel22.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.Right
        Me.XrLabel22.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(352.0836!, 39.99993!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(100.0!, 20.00002!)
        Me.XrLabel22.StylePriority.UseBorderColor = False
        Me.XrLabel22.StylePriority.UseBorders = False
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.StylePriority.UseTextAlignment = False
        Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LCurGross
        '
        Me.LCurGross.BorderColor = System.Drawing.Color.DimGray
        Me.LCurGross.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.LCurGross.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCurGross.LocationFloat = New DevExpress.Utils.PointFloat(452.0836!, 0.0!)
        Me.LCurGross.Name = "LCurGross"
        Me.LCurGross.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LCurGross.SizeF = New System.Drawing.SizeF(47.91635!, 19.99998!)
        Me.LCurGross.StylePriority.UseBorderColor = False
        Me.LCurGross.StylePriority.UseBorders = False
        Me.LCurGross.StylePriority.UseFont = False
        Me.LCurGross.StylePriority.UseTextAlignment = False
        Me.LCurGross.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LCurVat
        '
        Me.LCurVat.BorderColor = System.Drawing.Color.DimGray
        Me.LCurVat.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LCurVat.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCurVat.LocationFloat = New DevExpress.Utils.PointFloat(452.0836!, 20.00001!)
        Me.LCurVat.Name = "LCurVat"
        Me.LCurVat.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LCurVat.SizeF = New System.Drawing.SizeF(47.91635!, 19.99998!)
        Me.LCurVat.StylePriority.UseBorderColor = False
        Me.LCurVat.StylePriority.UseBorders = False
        Me.LCurVat.StylePriority.UseFont = False
        Me.LCurVat.StylePriority.UseTextAlignment = False
        Me.LCurVat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.Right
        Me.XrLabel8.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(452.0836!, 40.00018!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(197.9164!, 20.00005!)
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 79.99998!)
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
        'XrLabel41
        '
        Me.XrLabel41.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel41.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel41.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel41.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel41.Name = "XrLabel41"
        Me.XrLabel41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel41.SizeF = New System.Drawing.SizeF(46.87503!, 39.99999!)
        Me.XrLabel41.StylePriority.UseBorderColor = False
        Me.XrLabel41.StylePriority.UseBorders = False
        Me.XrLabel41.StylePriority.UseFont = False
        Me.XrLabel41.Text = "SAY"
        '
        'XrLabel36
        '
        Me.XrLabel36.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel36.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel36.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(352.0836!, 59.99994!)
        Me.XrLabel36.Name = "XrLabel36"
        Me.XrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel36.SizeF = New System.Drawing.SizeF(100.0!, 20.00002!)
        Me.XrLabel36.StylePriority.UseBorderColor = False
        Me.XrLabel36.StylePriority.UseBorders = False
        Me.XrLabel36.StylePriority.UseFont = False
        Me.XrLabel36.StylePriority.UseTextAlignment = False
        Me.XrLabel36.Text = "TOTAL :"
        Me.XrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LTot
        '
        Me.LTot.BorderColor = System.Drawing.Color.DimGray
        Me.LTot.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LTot.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTot.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 59.99997!)
        Me.LTot.Name = "LTot"
        Me.LTot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTot.SizeF = New System.Drawing.SizeF(149.9999!, 19.99998!)
        Me.LTot.StylePriority.UseBorderColor = False
        Me.LTot.StylePriority.UseBorders = False
        Me.LTot.StylePriority.UseFont = False
        Me.LTot.StylePriority.UseTextAlignment = False
        Me.LTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LCurTot
        '
        Me.LCurTot.BorderColor = System.Drawing.Color.DimGray
        Me.LCurTot.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LCurTot.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCurTot.LocationFloat = New DevExpress.Utils.PointFloat(452.0836!, 60.00023!)
        Me.LCurTot.Name = "LCurTot"
        Me.LCurTot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LCurTot.SizeF = New System.Drawing.SizeF(47.91635!, 19.99998!)
        Me.LCurTot.StylePriority.UseBorderColor = False
        Me.LCurTot.StylePriority.UseBorders = False
        Me.LCurTot.StylePriority.UseFont = False
        Me.LCurTot.StylePriority.UseTextAlignment = False
        Me.LCurTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LNote
        '
        Me.LNote.BorderColor = System.Drawing.Color.DimGray
        Me.LNote.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LNote.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNote.LocationFloat = New DevExpress.Utils.PointFloat(57.20844!, 40.00015!)
        Me.LNote.Name = "LNote"
        Me.LNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNote.SizeF = New System.Drawing.SizeF(294.875!, 40.00003!)
        Me.LNote.StylePriority.UseBorderColor = False
        Me.LNote.StylePriority.UseBorders = False
        Me.LNote.StylePriority.UseFont = False
        '
        'LSay
        '
        Me.LSay.BorderColor = System.Drawing.Color.DimGray
        Me.LSay.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LSay.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSay.LocationFloat = New DevExpress.Utils.PointFloat(57.20843!, 0.0!)
        Me.LSay.Name = "LSay"
        Me.LSay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LSay.SizeF = New System.Drawing.SizeF(294.875!, 40.0!)
        Me.LSay.StylePriority.UseBorderColor = False
        Me.LSay.StylePriority.UseBorders = False
        Me.LSay.StylePriority.UseFont = False
        '
        'XrLabel29
        '
        Me.XrLabel29.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel29.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel29.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(46.87503!, 39.99999!)
        Me.XrLabel29.Name = "XrLabel29"
        Me.XrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel29.SizeF = New System.Drawing.SizeF(10.3334!, 39.99999!)
        Me.XrLabel29.StylePriority.UseBorderColor = False
        Me.XrLabel29.StylePriority.UseBorders = False
        Me.XrLabel29.StylePriority.UseFont = False
        Me.XrLabel29.Text = ":"
        '
        'LGrossTot
        '
        Me.LGrossTot.BorderColor = System.Drawing.Color.DimGray
        Me.LGrossTot.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LGrossTot.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LGrossTot.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 0.0!)
        Me.LGrossTot.Name = "LGrossTot"
        Me.LGrossTot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LGrossTot.SizeF = New System.Drawing.SizeF(149.9999!, 20.00001!)
        Me.LGrossTot.StylePriority.UseBorderColor = False
        Me.LGrossTot.StylePriority.UseBorders = False
        Me.LGrossTot.StylePriority.UseFont = False
        Me.LGrossTot.StylePriority.UseTextAlignment = False
        Me.LGrossTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LNotex
        '
        Me.LNotex.BorderColor = System.Drawing.Color.DimGray
        Me.LNotex.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
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
        'XrLabel32
        '
        Me.XrLabel32.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.Right
        Me.XrLabel32.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(427.0832!, 20.00014!)
        Me.XrLabel32.Name = "XrLabel32"
        Me.XrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel32.SizeF = New System.Drawing.SizeF(25.00024!, 20.00002!)
        Me.XrLabel32.StylePriority.UseBorderColor = False
        Me.XrLabel32.StylePriority.UseBorders = False
        Me.XrLabel32.StylePriority.UseFont = False
        Me.XrLabel32.StylePriority.UseTextAlignment = False
        Me.XrLabel32.Text = "%"
        Me.XrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel34
        '
        Me.XrLabel34.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel34.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel34.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(352.0835!, 20.00001!)
        Me.XrLabel34.Name = "XrLabel34"
        Me.XrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel34.SizeF = New System.Drawing.SizeF(35.41669!, 20.00014!)
        Me.XrLabel34.StylePriority.UseBorderColor = False
        Me.XrLabel34.StylePriority.UseBorders = False
        Me.XrLabel34.StylePriority.UseFont = False
        Me.XrLabel34.StylePriority.UseTextAlignment = False
        Me.XrLabel34.Text = "VAT"
        Me.XrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LVat
        '
        Me.LVat.BorderColor = System.Drawing.Color.DimGray
        Me.LVat.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LVat.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVat.LocationFloat = New DevExpress.Utils.PointFloat(387.5001!, 20.00001!)
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
        'XrLabel31
        '
        Me.XrLabel31.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel31.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(46.87503!, 0.0!)
        Me.XrLabel31.Name = "XrLabel31"
        Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel31.SizeF = New System.Drawing.SizeF(10.3334!, 39.99999!)
        Me.XrLabel31.StylePriority.UseBorderColor = False
        Me.XrLabel31.StylePriority.UseBorders = False
        Me.XrLabel31.StylePriority.UseFont = False
        Me.XrLabel31.Text = ":"
        '
        'LVatTot
        '
        Me.LVatTot.BorderColor = System.Drawing.Color.DimGray
        Me.LVatTot.Borders = DevExpress.XtraPrinting.BorderSide.Right
        Me.LVatTot.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVatTot.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 20.00014!)
        Me.LVatTot.Name = "LVatTot"
        Me.LVatTot.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LVatTot.SizeF = New System.Drawing.SizeF(149.9995!, 20.00004!)
        Me.LVatTot.StylePriority.UseBorderColor = False
        Me.LVatTot.StylePriority.UseBorders = False
        Me.LVatTot.StylePriority.UseFont = False
        Me.LVatTot.StylePriority.UseTextAlignment = False
        Me.LVatTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel28
        '
        Me.XrLabel28.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel28.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel28.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(352.0834!, 0.0!)
        Me.XrLabel28.Name = "XrLabel28"
        Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel28.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel28.StylePriority.UseBorderColor = False
        Me.XrLabel28.StylePriority.UseBorders = False
        Me.XrLabel28.StylePriority.UseFont = False
        Me.XrLabel28.StylePriority.UseTextAlignment = False
        Me.XrLabel28.Text = "GROSS TOTAL"
        Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'ReportMatInvoiceRetur
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 144, 19)
        Me.PageHeight = 500
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Version = "11.1"
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LReturNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents zxc As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LPDONumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDesign As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPLNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LFromNPWP As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel48 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel47 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LToNPWP As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDueDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LToAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LToName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LFromName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LFromAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel41 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel36 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LCurTot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LSay As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LGrossTot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNotex As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel34 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LVat As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LVatTot As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPRDetSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQtyRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents COlUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdMatDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyRet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LInvoice As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LCurGross As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LCurVat As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
End Class
