<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportPurcOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportPurcOrder))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCSummary = New DevExpress.XtraGrid.GridControl()
        Me.GVSummary = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnPOIdItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOItemDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOSubTot = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOVal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITEVal = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnDiscPercent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDisc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEVal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1, Me.XrTable1})
        Me.Detail.HeightF = 154.1667!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(627.0001!, 129.1667!)
        Me.WinControlContainer1.WinControl = Me.GCSummary
        '
        'GCSummary
        '
        Me.GCSummary.Location = New System.Drawing.Point(0, 0)
        Me.GCSummary.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCSummary.MainView = Me.GVSummary
        Me.GCSummary.Name = "GCSummary"
        Me.GCSummary.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit2, Me.RepositoryItemSearchLookUpEdit1, Me.RITEVal})
        Me.GCSummary.Size = New System.Drawing.Size(602, 124)
        Me.GCSummary.TabIndex = 5
        Me.GCSummary.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSummary})
        '
        'GVSummary
        '
        Me.GVSummary.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnPOIdItem, Me.GridColumnPOItemDesc, Me.GridColumnQtyPO, Me.GridColumnPOUOM, Me.GridColumnValQty, Me.GridColumnPOSubTot, Me.GridColumnPOVal, Me.GridColumnDiscPercent, Me.GridColumnDisc})
        Me.GVSummary.GridControl = Me.GCSummary
        Me.GVSummary.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sub_tot", Nothing, "{0:N2}")})
        Me.GVSummary.Name = "GVSummary"
        Me.GVSummary.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSummary.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSummary.OptionsCustomization.AllowGroup = False
        Me.GVSummary.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVSummary.OptionsCustomization.AllowSort = False
        Me.GVSummary.OptionsFilter.AllowFilterEditor = False
        Me.GVSummary.OptionsView.ShowFooter = True
        Me.GVSummary.OptionsView.ShowGroupPanel = False
        '
        'GridColumnPOIdItem
        '
        Me.GridColumnPOIdItem.Caption = "ID Item"
        Me.GridColumnPOIdItem.FieldName = "id_item"
        Me.GridColumnPOIdItem.Name = "GridColumnPOIdItem"
        Me.GridColumnPOIdItem.OptionsColumn.AllowEdit = False
        '
        'GridColumnPOItemDesc
        '
        Me.GridColumnPOItemDesc.Caption = "Item"
        Me.GridColumnPOItemDesc.FieldName = "item_desc"
        Me.GridColumnPOItemDesc.Name = "GridColumnPOItemDesc"
        Me.GridColumnPOItemDesc.OptionsColumn.AllowEdit = False
        Me.GridColumnPOItemDesc.Visible = True
        Me.GridColumnPOItemDesc.VisibleIndex = 0
        Me.GridColumnPOItemDesc.Width = 157
        '
        'GridColumnQtyPO
        '
        Me.GridColumnQtyPO.Caption = "Qty"
        Me.GridColumnQtyPO.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyPO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyPO.FieldName = "qty_po"
        Me.GridColumnQtyPO.Name = "GridColumnQtyPO"
        Me.GridColumnQtyPO.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyPO.Visible = True
        Me.GridColumnQtyPO.VisibleIndex = 1
        Me.GridColumnQtyPO.Width = 72
        '
        'GridColumnPOUOM
        '
        Me.GridColumnPOUOM.Caption = "UOM"
        Me.GridColumnPOUOM.FieldName = "uom"
        Me.GridColumnPOUOM.Name = "GridColumnPOUOM"
        Me.GridColumnPOUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnPOUOM.Visible = True
        Me.GridColumnPOUOM.VisibleIndex = 2
        Me.GridColumnPOUOM.Width = 48
        '
        'GridColumnValQty
        '
        Me.GridColumnValQty.Caption = "Value x Qty"
        Me.GridColumnValQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnValQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValQty.FieldName = "sub_tot_before"
        Me.GridColumnValQty.Name = "GridColumnValQty"
        Me.GridColumnValQty.OptionsColumn.AllowEdit = False
        Me.GridColumnValQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sub_tot_before", "{0:N2}")})
        Me.GridColumnValQty.UnboundExpression = "[qty_po] * [val_po]"
        Me.GridColumnValQty.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        '
        'GridColumnPOSubTot
        '
        Me.GridColumnPOSubTot.Caption = "Sub Total"
        Me.GridColumnPOSubTot.DisplayFormat.FormatString = "N2"
        Me.GridColumnPOSubTot.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPOSubTot.FieldName = "sub_total"
        Me.GridColumnPOSubTot.Name = "GridColumnPOSubTot"
        Me.GridColumnPOSubTot.OptionsColumn.AllowEdit = False
        Me.GridColumnPOSubTot.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sub_total", "{0:N2}")})
        Me.GridColumnPOSubTot.UnboundExpression = "([val_po] - [discount]) * [qty_po]"
        Me.GridColumnPOSubTot.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnPOSubTot.Visible = True
        Me.GridColumnPOSubTot.VisibleIndex = 6
        Me.GridColumnPOSubTot.Width = 239
        '
        'GridColumnPOVal
        '
        Me.GridColumnPOVal.Caption = "Value"
        Me.GridColumnPOVal.ColumnEdit = Me.RITEVal
        Me.GridColumnPOVal.DisplayFormat.FormatString = "N2"
        Me.GridColumnPOVal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPOVal.FieldName = "val_po"
        Me.GridColumnPOVal.Name = "GridColumnPOVal"
        Me.GridColumnPOVal.Visible = True
        Me.GridColumnPOVal.VisibleIndex = 3
        Me.GridColumnPOVal.Width = 174
        '
        'RITEVal
        '
        Me.RITEVal.AutoHeight = False
        Me.RITEVal.DisplayFormat.FormatString = "N2"
        Me.RITEVal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEVal.Mask.EditMask = "N2"
        Me.RITEVal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RITEVal.Name = "RITEVal"
        '
        'GridColumnDiscPercent
        '
        Me.GridColumnDiscPercent.Caption = "Discount (%)"
        Me.GridColumnDiscPercent.ColumnEdit = Me.RITEVal
        Me.GridColumnDiscPercent.DisplayFormat.FormatString = "N2"
        Me.GridColumnDiscPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDiscPercent.FieldName = "discount_percent"
        Me.GridColumnDiscPercent.Name = "GridColumnDiscPercent"
        Me.GridColumnDiscPercent.Visible = True
        Me.GridColumnDiscPercent.VisibleIndex = 4
        Me.GridColumnDiscPercent.Width = 78
        '
        'GridColumnDisc
        '
        Me.GridColumnDisc.Caption = "Discount"
        Me.GridColumnDisc.ColumnEdit = Me.RITEVal
        Me.GridColumnDisc.DisplayFormat.FormatString = "N2"
        Me.GridColumnDisc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDisc.FieldName = "discount"
        Me.GridColumnDisc.Name = "GridColumnDisc"
        Me.GridColumnDisc.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "discount", "{0:N2}")})
        Me.GridColumnDisc.Visible = True
        Me.GridColumnDisc.VisibleIndex = 5
        Me.GridColumnDisc.Width = 161
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit2.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit2.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.NullText = "-- Choose item --"
        Me.RepositoryItemSearchLookUpEdit1.View = Me.GridView3
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "ID Item"
        Me.GridColumn16.FieldName = "id_item"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Category"
        Me.GridColumn17.FieldName = "item_cat"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 1
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Item Description"
        Me.GridColumn18.FieldName = "item_desc"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 0
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "UOM"
        Me.GridColumn19.FieldName = "uom"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 3
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Budget Remaining"
        Me.GridColumn20.DisplayFormat.FormatString = "N0"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "budget_remaining"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 2
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0001589457!, 129.1667!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(626.9999!, 25.0!)
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
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.XrLabel7, Me.XrLine1})
        Me.TopMargin.HeightF = 55.65194!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 6.610268!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(210.4167!, 39.58334!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Franklin Gothic Demi", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(282.2917!, 11.61027!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(344.7085!, 26.4167!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Purchase Order"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0002617929!, 46.19361!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(626.9999!, 9.458328!)
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 19.7596!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(477.0001!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 19.7596!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportHeader
        '
        Me.ReportHeader.HeightF = 81.77084!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportPurcOrder
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 56, 20)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEVal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCSummary As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSummary As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnPOIdItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOItemDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOSubTot As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOVal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RITEVal As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnDiscPercent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDisc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
End Class
