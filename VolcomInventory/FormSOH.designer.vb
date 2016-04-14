<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSOH
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GCSOH = New DevExpress.XtraGrid.GridControl
        Me.BGVSOH = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Me.GridColumnIDSOH = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnYear = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnMonth = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnPeriode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.BandedGridColumnStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Me.GridColumnComp_group = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnSourceCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnSource = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Me.GridColumnQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnQtyPrice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnQtyCost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Me.GridColumnStoreQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnStoreQtyPrice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnStoreQtyCost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Me.GridColumnDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnDiffPrice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnDiffCost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Me.GridColumnUid = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnUidPrice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GridColumnUidCost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LESOHPeriode = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdPOType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPOType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.DDBPrint = New DevExpress.XtraEditors.DropDownButton
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LESOHPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSOH
        '
        Me.GCSOH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSOH.Location = New System.Drawing.Point(0, 39)
        Me.GCSOH.MainView = Me.BGVSOH
        Me.GCSOH.Name = "GCSOH"
        Me.GCSOH.Size = New System.Drawing.Size(720, 285)
        Me.GCSOH.TabIndex = 1
        Me.GCSOH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVSOH})
        '
        'BGVSOH
        '
        Me.BGVSOH.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand1, Me.GridBand2, Me.GridBand3, Me.GridBand5, Me.GridBand4, Me.GridBand6})
        Me.BGVSOH.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnIDSOH, Me.GridColumnComp_group, Me.GridColumnSourceCode, Me.GridColumnSource, Me.GridColumnPeriode, Me.GridColumnMonth, Me.GridColumnYear, Me.GridColumnQty, Me.GridColumnQtyPrice, Me.GridColumnQtyCost, Me.GridColumnStoreQty, Me.GridColumnStoreQtyPrice, Me.GridColumnStoreQtyCost, Me.GridColumnDiff, Me.GridColumnDiffPrice, Me.GridColumnDiffCost, Me.GridColumnUid, Me.GridColumnUidPrice, Me.GridColumnUidCost, Me.BandedGridColumnStatus})
        Me.BGVSOH.GridControl = Me.GCSOH
        Me.BGVSOH.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_price", Me.GridColumnQtyPrice, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_cost", Me.GridColumnQtyCost, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_store_qty", Me.GridColumnStoreQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_store_qty_price", Me.GridColumnStoreQtyPrice, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_store_qty_cost", Me.GridColumnStoreQtyCost, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff", Me.GridColumnDiff, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_price", Me.GridColumnDiffPrice, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_cost", Me.GridColumnDiffCost, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "unid_qty", Me.GridColumnUid, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "unid_qty_price", Me.GridColumnUidPrice, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "unid_qty_cost", Me.GridColumnUidCost, "{0:N2}")})
        Me.BGVSOH.Name = "BGVSOH"
        Me.BGVSOH.OptionsView.ColumnAutoWidth = False
        Me.BGVSOH.OptionsView.ShowFooter = True
        Me.BGVSOH.OptionsView.ShowGroupPanel = False
        '
        'gridBand1
        '
        Me.gridBand1.Caption = "Detail"
        Me.gridBand1.Columns.Add(Me.GridColumnIDSOH)
        Me.gridBand1.Columns.Add(Me.GridColumnYear)
        Me.gridBand1.Columns.Add(Me.GridColumnMonth)
        Me.gridBand1.Columns.Add(Me.GridColumnPeriode)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnStatus)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.Width = 174
        '
        'GridColumnIDSOH
        '
        Me.GridColumnIDSOH.Caption = "Id SOH"
        Me.GridColumnIDSOH.FieldName = "id_soh"
        Me.GridColumnIDSOH.Name = "GridColumnIDSOH"
        Me.GridColumnIDSOH.Width = 22
        '
        'GridColumnYear
        '
        Me.GridColumnYear.Caption = "Year"
        Me.GridColumnYear.FieldName = "year_date_end"
        Me.GridColumnYear.Name = "GridColumnYear"
        Me.GridColumnYear.Visible = True
        Me.GridColumnYear.Width = 25
        '
        'GridColumnMonth
        '
        Me.GridColumnMonth.Caption = "Month"
        Me.GridColumnMonth.FieldName = "month_date_end"
        Me.GridColumnMonth.Name = "GridColumnMonth"
        Me.GridColumnMonth.Visible = True
        Me.GridColumnMonth.Width = 34
        '
        'GridColumnPeriode
        '
        Me.GridColumnPeriode.Caption = "Periode"
        Me.GridColumnPeriode.FieldName = "soh_periode"
        Me.GridColumnPeriode.Name = "GridColumnPeriode"
        Me.GridColumnPeriode.Visible = True
        Me.GridColumnPeriode.Width = 47
        '
        'BandedGridColumnStatus
        '
        Me.BandedGridColumnStatus.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnStatus.Caption = "Status"
        Me.BandedGridColumnStatus.FieldName = "status_soh"
        Me.BandedGridColumnStatus.Name = "BandedGridColumnStatus"
        Me.BandedGridColumnStatus.Visible = True
        Me.BandedGridColumnStatus.Width = 68
        '
        'GridBand2
        '
        Me.GridBand2.Caption = "Source"
        Me.GridBand2.Columns.Add(Me.GridColumnComp_group)
        Me.GridBand2.Columns.Add(Me.GridColumnSourceCode)
        Me.GridBand2.Columns.Add(Me.GridColumnSource)
        Me.GridBand2.MinWidth = 20
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.Width = 130
        '
        'GridColumnComp_group
        '
        Me.GridColumnComp_group.Caption = "Group"
        Me.GridColumnComp_group.FieldName = "comp_group"
        Me.GridColumnComp_group.Name = "GridColumnComp_group"
        Me.GridColumnComp_group.Visible = True
        Me.GridColumnComp_group.Width = 38
        '
        'GridColumnSourceCode
        '
        Me.GridColumnSourceCode.Caption = "Code"
        Me.GridColumnSourceCode.FieldName = "comp_number"
        Me.GridColumnSourceCode.Name = "GridColumnSourceCode"
        Me.GridColumnSourceCode.Visible = True
        Me.GridColumnSourceCode.Width = 34
        '
        'GridColumnSource
        '
        Me.GridColumnSource.Caption = "Source"
        Me.GridColumnSource.FieldName = "comp_name"
        Me.GridColumnSource.Name = "GridColumnSource"
        Me.GridColumnSource.Visible = True
        Me.GridColumnSource.Width = 58
        '
        'GridBand3
        '
        Me.GridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand3.Caption = "Volcom"
        Me.GridBand3.Columns.Add(Me.GridColumnQty)
        Me.GridBand3.Columns.Add(Me.GridColumnQtyPrice)
        Me.GridBand3.Columns.Add(Me.GridColumnQtyCost)
        Me.GridBand3.MinWidth = 20
        Me.GridBand3.Name = "GridBand3"
        Me.GridBand3.Width = 163
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
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.Width = 30
        '
        'GridColumnQtyPrice
        '
        Me.GridColumnQtyPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyPrice.Caption = "Amount"
        Me.GridColumnQtyPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyPrice.FieldName = "qty_price"
        Me.GridColumnQtyPrice.Name = "GridColumnQtyPrice"
        Me.GridColumnQtyPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_price", "{0:N2}")})
        Me.GridColumnQtyPrice.Visible = True
        Me.GridColumnQtyPrice.Width = 35
        '
        'GridColumnQtyCost
        '
        Me.GridColumnQtyCost.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyCost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyCost.Caption = "Cost"
        Me.GridColumnQtyCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyCost.FieldName = "qty_cost"
        Me.GridColumnQtyCost.Name = "GridColumnQtyCost"
        Me.GridColumnQtyCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_cost", "{0:N2}")})
        Me.GridColumnQtyCost.Visible = True
        Me.GridColumnQtyCost.Width = 98
        '
        'GridBand5
        '
        Me.GridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand5.Caption = "Store"
        Me.GridBand5.Columns.Add(Me.GridColumnStoreQty)
        Me.GridBand5.Columns.Add(Me.GridColumnStoreQtyPrice)
        Me.GridBand5.Columns.Add(Me.GridColumnStoreQtyCost)
        Me.GridBand5.MinWidth = 20
        Me.GridBand5.Name = "GridBand5"
        Me.GridBand5.Width = 122
        '
        'GridColumnStoreQty
        '
        Me.GridColumnStoreQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnStoreQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnStoreQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnStoreQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnStoreQty.Caption = "Qty"
        Me.GridColumnStoreQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnStoreQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnStoreQty.FieldName = "soh_store_qty"
        Me.GridColumnStoreQty.Name = "GridColumnStoreQty"
        Me.GridColumnStoreQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_store_qty", "{0:N0}")})
        Me.GridColumnStoreQty.Visible = True
        Me.GridColumnStoreQty.Width = 22
        '
        'GridColumnStoreQtyPrice
        '
        Me.GridColumnStoreQtyPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnStoreQtyPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnStoreQtyPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnStoreQtyPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnStoreQtyPrice.Caption = "Amount"
        Me.GridColumnStoreQtyPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnStoreQtyPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnStoreQtyPrice.FieldName = "soh_store_qty_price"
        Me.GridColumnStoreQtyPrice.Name = "GridColumnStoreQtyPrice"
        Me.GridColumnStoreQtyPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_store_qty_price", "{0:N2}")})
        Me.GridColumnStoreQtyPrice.Visible = True
        Me.GridColumnStoreQtyPrice.Width = 22
        '
        'GridColumnStoreQtyCost
        '
        Me.GridColumnStoreQtyCost.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnStoreQtyCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnStoreQtyCost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnStoreQtyCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnStoreQtyCost.Caption = "Cost"
        Me.GridColumnStoreQtyCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnStoreQtyCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnStoreQtyCost.FieldName = "soh_store_qty_cost"
        Me.GridColumnStoreQtyCost.Name = "GridColumnStoreQtyCost"
        Me.GridColumnStoreQtyCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_store_qty_cost", "{0:N2}")})
        Me.GridColumnStoreQtyCost.Visible = True
        Me.GridColumnStoreQtyCost.Width = 78
        '
        'GridBand4
        '
        Me.GridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand4.Caption = "Different"
        Me.GridBand4.Columns.Add(Me.GridColumnDiff)
        Me.GridBand4.Columns.Add(Me.GridColumnDiffPrice)
        Me.GridBand4.Columns.Add(Me.GridColumnDiffCost)
        Me.GridBand4.MinWidth = 20
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.Width = 122
        '
        'GridColumnDiff
        '
        Me.GridColumnDiff.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiff.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDiff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiff.Caption = "Qty"
        Me.GridColumnDiff.DisplayFormat.FormatString = "N0"
        Me.GridColumnDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDiff.FieldName = "diff"
        Me.GridColumnDiff.Name = "GridColumnDiff"
        Me.GridColumnDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff", "{0:N0}")})
        Me.GridColumnDiff.Visible = True
        Me.GridColumnDiff.Width = 22
        '
        'GridColumnDiffPrice
        '
        Me.GridColumnDiffPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDiffPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiffPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDiffPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiffPrice.Caption = "Amount"
        Me.GridColumnDiffPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnDiffPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDiffPrice.FieldName = "diff_price"
        Me.GridColumnDiffPrice.Name = "GridColumnDiffPrice"
        Me.GridColumnDiffPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_price", "{0:N2}")})
        Me.GridColumnDiffPrice.Visible = True
        Me.GridColumnDiffPrice.Width = 22
        '
        'GridColumnDiffCost
        '
        Me.GridColumnDiffCost.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDiffCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiffCost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDiffCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiffCost.Caption = "Cost"
        Me.GridColumnDiffCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnDiffCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDiffCost.FieldName = "diff_cost"
        Me.GridColumnDiffCost.Name = "GridColumnDiffCost"
        Me.GridColumnDiffCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_cost", "{0:N2}")})
        Me.GridColumnDiffCost.Visible = True
        Me.GridColumnDiffCost.Width = 78
        '
        'GridBand6
        '
        Me.GridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand6.Caption = "Unidentified"
        Me.GridBand6.Columns.Add(Me.GridColumnUid)
        Me.GridBand6.Columns.Add(Me.GridColumnUidPrice)
        Me.GridBand6.Columns.Add(Me.GridColumnUidCost)
        Me.GridBand6.MinWidth = 20
        Me.GridBand6.Name = "GridBand6"
        Me.GridBand6.Width = 105
        '
        'GridColumnUid
        '
        Me.GridColumnUid.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnUid.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUid.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnUid.Caption = "Qty"
        Me.GridColumnUid.DisplayFormat.FormatString = "N0"
        Me.GridColumnUid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnUid.FieldName = "unid_qty"
        Me.GridColumnUid.Name = "GridColumnUid"
        Me.GridColumnUid.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "unid_qty", "{0:N0}")})
        Me.GridColumnUid.Visible = True
        Me.GridColumnUid.Width = 22
        '
        'GridColumnUidPrice
        '
        Me.GridColumnUidPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUidPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnUidPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUidPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnUidPrice.Caption = "Amount"
        Me.GridColumnUidPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnUidPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnUidPrice.FieldName = "unid_qty_price"
        Me.GridColumnUidPrice.Name = "GridColumnUidPrice"
        Me.GridColumnUidPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "unid_qty_price", "{0:N2}")})
        Me.GridColumnUidPrice.Visible = True
        Me.GridColumnUidPrice.Width = 22
        '
        'GridColumnUidCost
        '
        Me.GridColumnUidCost.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUidCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnUidCost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUidCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnUidCost.Caption = "Cost"
        Me.GridColumnUidCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnUidCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnUidCost.FieldName = "unid_qty_cost"
        Me.GridColumnUidCost.Name = "GridColumnUidCost"
        Me.GridColumnUidCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "unid_qty_cost", "{0:N2}")})
        Me.GridColumnUidCost.Visible = True
        Me.GridColumnUidCost.Width = 61
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DDBPrint)
        Me.PanelControl1.Controls.Add(Me.LESOHPeriode)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(720, 39)
        Me.PanelControl1.TabIndex = 2
        '
        'LESOHPeriode
        '
        Me.LESOHPeriode.Location = New System.Drawing.Point(65, 9)
        Me.LESOHPeriode.Name = "LESOHPeriode"
        Me.LESOHPeriode.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LESOHPeriode.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.LESOHPeriode.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LESOHPeriode.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.LESOHPeriode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESOHPeriode.Properties.NullText = ""
        Me.LESOHPeriode.Properties.ShowFooter = False
        Me.LESOHPeriode.Properties.View = Me.GridView3
        Me.LESOHPeriode.Size = New System.Drawing.Size(242, 20)
        Me.LESOHPeriode.TabIndex = 122
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPOType, Me.ColPOType})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'ColIdPOType
        '
        Me.ColIdPOType.Caption = "Id SOH Periode"
        Me.ColIdPOType.FieldName = "id_soh_periode"
        Me.ColIdPOType.Name = "ColIdPOType"
        '
        'ColPOType
        '
        Me.ColPOType.Caption = "SOH Periode"
        Me.ColPOType.FieldName = "soh_periode"
        Me.ColPOType.Name = "ColPOType"
        Me.ColPOType.Visible = True
        Me.ColPOType.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl1.TabIndex = 123
        Me.LabelControl1.Text = "Periode"
        '
        'DDBPrint
        '
        Me.DDBPrint.Location = New System.Drawing.Point(315, 6)
        Me.DDBPrint.Name = "DDBPrint"
        Me.DDBPrint.DropDownArrowStyle = False
        Me.DDBPrint.Size = New System.Drawing.Size(72, 24)
        Me.DDBPrint.TabIndex = 124
        Me.DDBPrint.Text = "View"
        '
        'FormSOH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 324)
        Me.Controls.Add(Me.GCSOH)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSOH"
        Me.Text = "FormSOH"
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LESOHPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSOH As DevExpress.XtraGrid.GridControl
    Friend WithEvents BGVSOH As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumnIDSOH As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnComp_group As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnSourceCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnSource As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPeriode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnMonth As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnYear As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnQtyPrice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnQtyCost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnStoreQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnStoreQtyPrice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnStoreQtyCost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDiffPrice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDiffCost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnUid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnUidPrice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnUidCost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LESOHPeriode As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DDBPrint As DevExpress.XtraEditors.DropDownButton
End Class
