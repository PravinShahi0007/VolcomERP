<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportProdQCAdjOut
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
        Me.GCDetail = New DevExpress.XtraGrid.GridControl
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIDProdDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCost = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel
        Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel
        Me.LDesign = New DevExpress.XtraReports.UI.XRLabel
        Me.LDesignCode = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.LPONumber = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.LDate = New DevExpress.XtraReports.UI.XRLabel
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel
        Me.LNumber = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.LSayCurr = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell
        Me.LTotQty = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.LNote = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.LTotCost = New DevExpress.XtraReports.UI.XRLabel
        Me.LNotex = New DevExpress.XtraReports.UI.XRLabel
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 146.875!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(654.0!, 146.875!)
        Me.WinControlContainer1.WinControl = Me.GCDetail
        '
        'GCDetail
        '
        Me.GCDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.Size = New System.Drawing.Size(628, 141)
        Me.GCDetail.TabIndex = 0
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.Transparent
        Me.GVDetail.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.GVDetail.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVDetail.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVDetail.AppearancePrint.Row.BackColor = System.Drawing.Color.Transparent
        Me.GVDetail.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GVDetail.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.Row.Options.UseFont = True
        Me.GVDetail.AppearancePrint.Row.Options.UseForeColor = True
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnIdDet, Me.GridColumnIDProdDet, Me.GridColumnQty, Me.GridColumnNote, Me.GridColumnCode, Me.GridColumnDescription, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnCost, Me.GridColumnAmount})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVDetail.OptionsPrint.PrintFooter = False
        Me.GVDetail.OptionsPrint.UsePrintStyles = True
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.ReadOnly = True
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 50
        '
        'GridColumnIdDet
        '
        Me.GridColumnIdDet.Caption = "ID Det"
        Me.GridColumnIdDet.FieldName = "id_prod_order_qc_adj_out_det"
        Me.GridColumnIdDet.Name = "GridColumnIdDet"
        Me.GridColumnIdDet.OptionsColumn.ReadOnly = True
        '
        'GridColumnIDProdDet
        '
        Me.GridColumnIDProdDet.Caption = "ID Prod Order Det"
        Me.GridColumnIDProdDet.FieldName = "id_prod_order_det"
        Me.GridColumnIDProdDet.Name = "GridColumnIDProdDet"
        Me.GridColumnIDProdDet.OptionsColumn.ReadOnly = True
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 6
        Me.GridColumnQty.Width = 102
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 8
        Me.GridColumnNote.Width = 145
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.ReadOnly = True
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 139
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.Caption = "Description"
        Me.GridColumnDescription.FieldName = "description"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.OptionsColumn.ReadOnly = True
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 2
        Me.GridColumnDescription.Width = 242
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.OptionsColumn.ReadOnly = True
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        Me.GridColumnColor.Width = 87
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.ReadOnly = True
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 4
        Me.GridColumnSize.Width = 101
        '
        'GridColumnCost
        '
        Me.GridColumnCost.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCost.Caption = "Cost"
        Me.GridColumnCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCost.FieldName = "cost"
        Me.GridColumnCost.Name = "GridColumnCost"
        Me.GridColumnCost.OptionsColumn.ReadOnly = True
        Me.GridColumnCost.Visible = True
        Me.GridColumnCost.VisibleIndex = 5
        Me.GridColumnCost.Width = 153
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.ReadOnly = True
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 7
        Me.GridColumnAmount.Width = 161
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1, Me.LDate, Me.LTitle, Me.LNumber, Me.XrLabel12, Me.XrLabel1})
        Me.TopMargin.HeightF = 73.0!
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
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel25, Me.XrLabel22, Me.LDesign, Me.LDesignCode, Me.XrLabel5, Me.XrLabel11, Me.XrLabel9, Me.LPONumber, Me.XrLabel3})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 27.58336!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(654.0!, 45.12498!)
        Me.XrPanel1.StylePriority.UseBorderColor = False
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'XrLabel25
        '
        Me.XrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(423.0865!, 15.58339!)
        Me.XrLabel25.Name = "XrLabel25"
        Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel25.SizeF = New System.Drawing.SizeF(11.45834!, 13.58335!)
        Me.XrLabel25.StylePriority.UseBorders = False
        Me.XrLabel25.Text = ":"
        '
        'XrLabel22
        '
        Me.XrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(340.7947!, 15.5834!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(82.29175!, 13.58334!)
        Me.XrLabel22.StylePriority.UseBorders = False
        Me.XrLabel22.Text = "Design"
        '
        'LDesign
        '
        Me.LDesign.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LDesign.LocationFloat = New DevExpress.Utils.PointFloat(434.5449!, 15.5834!)
        Me.LDesign.Name = "LDesign"
        Me.LDesign.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDesign.SizeF = New System.Drawing.SizeF(209.4552!, 13.58335!)
        Me.LDesign.StylePriority.UseBorders = False
        '
        'LDesignCode
        '
        Me.LDesignCode.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LDesignCode.LocationFloat = New DevExpress.Utils.PointFloat(434.5449!, 2.00003!)
        Me.LDesignCode.Name = "LDesignCode"
        Me.LDesignCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDesignCode.SizeF = New System.Drawing.SizeF(209.4551!, 13.58337!)
        Me.LDesignCode.StylePriority.UseBorders = False
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(340.7947!, 2.000046!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(82.29175!, 13.58335!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.Text = "Design Code"
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(109.2917!, 2.000014!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'XrLabel9
        '
        Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(423.0865!, 2.000046!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(11.45834!, 13.58335!)
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.Text = ":"
        '
        'LPONumber
        '
        Me.LPONumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LPONumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LPONumber.LocationFloat = New DevExpress.Utils.PointFloat(120.75!, 2.000031!)
        Me.LPONumber.Name = "LPONumber"
        Me.LPONumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPONumber.SizeF = New System.Drawing.SizeF(209.4551!, 13.58335!)
        Me.LPONumber.StylePriority.UseBorders = False
        Me.LPONumber.StylePriority.UseFont = False
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.000014!, 2.000013!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(107.2916!, 13.58335!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.Text = "Production Order"
        '
        'LDate
        '
        Me.LDate.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LDate.LocationFloat = New DevExpress.Utils.PointFloat(489.4169!, 0.00001589457!)
        Me.LDate.Name = "LDate"
        Me.LDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LDate.SizeF = New System.Drawing.SizeF(164.5831!, 27.58335!)
        Me.LDate.StylePriority.UseFont = False
        Me.LDate.StylePriority.UseTextAlignment = False
        Me.LDate.Text = "DATE"
        Me.LDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(200.0831!, 0.0!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(289.3338!, 27.58334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "QC ADJUSTMENT OUT"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'LNumber
        '
        Me.LNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LNumber.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LNumber.LocationFloat = New DevExpress.Utils.PointFloat(79.08325!, 0.00001589457!)
        Me.LNumber.Name = "LNumber"
        Me.LNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNumber.SizeF = New System.Drawing.SizeF(120.9998!, 27.58334!)
        Me.LNumber.StylePriority.UseBorders = False
        Me.LNumber.StylePriority.UseFont = False
        Me.LNumber.StylePriority.UseTextAlignment = False
        Me.LNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(67.62492!, 0.00001589457!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(11.45835!, 27.58334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = ":"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(67.62492!, 27.58335!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 21.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(503.9999!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 20.80126!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LSayCurr, Me.XrLabel14, Me.XrTable1, Me.LTotQty, Me.XrLabel4, Me.XrLabel10, Me.LNote, Me.XrLabel17, Me.XrLabel2, Me.LTotCost, Me.LNotex})
        Me.PageFooter.HeightF = 105.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'LSayCurr
        '
        Me.LSayCurr.BorderColor = System.Drawing.Color.DimGray
        Me.LSayCurr.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LSayCurr.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSayCurr.LocationFloat = New DevExpress.Utils.PointFloat(57.20825!, 39.99999!)
        Me.LSayCurr.Name = "LSayCurr"
        Me.LSayCurr.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LSayCurr.SizeF = New System.Drawing.SizeF(596.7916!, 40.00002!)
        Me.LSayCurr.StylePriority.UseBorderColor = False
        Me.LSayCurr.StylePriority.UseBorders = False
        Me.LSayCurr.StylePriority.UseFont = False
        Me.LSayCurr.StylePriority.UseTextAlignment = False
        Me.LSayCurr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel14
        '
        Me.XrLabel14.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel14.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel14.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(46.87503!, 40.00003!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(10.3334!, 39.99999!)
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = ":"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 80.00002!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(653.9999!, 25.0!)
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
        'LTotQty
        '
        Me.LTotQty.BorderColor = System.Drawing.Color.DimGray
        Me.LTotQty.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LTotQty.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTotQty.LocationFloat = New DevExpress.Utils.PointFloat(531.0834!, 0.0!)
        Me.LTotQty.Name = "LTotQty"
        Me.LTotQty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTotQty.SizeF = New System.Drawing.SizeF(122.9166!, 20.00001!)
        Me.LTotQty.StylePriority.UseBorderColor = False
        Me.LTotQty.StylePriority.UseBorders = False
        Me.LTotQty.StylePriority.UseFont = False
        Me.LTotQty.StylePriority.UseTextAlignment = False
        Me.LTotQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel4
        '
        Me.XrLabel4.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel4.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel4.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(454.0001!, 0.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(77.08334!, 20.0!)
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "TOTAL QTY"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = ":"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LNote
        '
        Me.LNote.BorderColor = System.Drawing.Color.DimGray
        Me.LNote.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LNote.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNote.LocationFloat = New DevExpress.Utils.PointFloat(57.20844!, 0.0!)
        Me.LNote.Name = "LNote"
        Me.LNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNote.SizeF = New System.Drawing.SizeF(396.7917!, 39.99999!)
        Me.LNote.StylePriority.UseBorderColor = False
        Me.LNote.StylePriority.UseBorders = False
        Me.LNote.StylePriority.UseFont = False
        Me.LNote.StylePriority.UseTextAlignment = False
        Me.LNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel17
        '
        Me.XrLabel17.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel17.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel17.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(454.0001!, 19.99998!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(77.08322!, 20.00001!)
        Me.XrLabel17.StylePriority.UseBorderColor = False
        Me.XrLabel17.StylePriority.UseBorders = False
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.StylePriority.UseTextAlignment = False
        Me.XrLabel17.Text = "TOTAL COST"
        Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "NOTE"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LTotCost
        '
        Me.LTotCost.BorderColor = System.Drawing.Color.DimGray
        Me.LTotCost.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.LTotCost.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTotCost.LocationFloat = New DevExpress.Utils.PointFloat(531.0834!, 20.00001!)
        Me.LTotCost.Name = "LTotCost"
        Me.LTotCost.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTotCost.SizeF = New System.Drawing.SizeF(122.9166!, 20.00001!)
        Me.LTotCost.StylePriority.UseBorderColor = False
        Me.LTotCost.StylePriority.UseBorders = False
        Me.LTotCost.StylePriority.UseFont = False
        Me.LTotCost.StylePriority.UseTextAlignment = False
        Me.LTotCost.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
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
        Me.LNotex.StylePriority.UseTextAlignment = False
        Me.LNotex.Text = "SAY"
        Me.LNotex.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'ReportProdQCAdjOut
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(100, 95, 73, 21)
        Me.PageHeight = 500
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Version = "11.1"
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDProdDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDesign As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDesignCode As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPONumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LSayCurr As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LTotQty As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTotCost As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNotex As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
