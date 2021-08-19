<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockTakeStorePeriod
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStockTakeStorePeriod))
        Me.GCPeriod = New DevExpress.XtraGrid.GridControl()
        Me.GVPeriod = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPeriod = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPCompare = New DevExpress.XtraTab.XtraTabPage()
        Me.GCCompare = New DevExpress.XtraGrid.GridControl()
        Me.BGVCompare = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnunit_price = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsoh_amount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnstore_amount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndiff_amount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBVerification = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSelectAccount = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBBAPPelaksanaan = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExportToXLS = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnScanList = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSync = New DevExpress.XtraEditors.SimpleButton()
        Me.SBStopScan = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl.SuspendLayout()
        Me.XTPPeriod.SuspendLayout()
        Me.XTPCompare.SuspendLayout()
        CType(Me.GCCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCPeriod
        '
        Me.GCPeriod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPeriod.Location = New System.Drawing.Point(0, 0)
        Me.GCPeriod.MainView = Me.GVPeriod
        Me.GCPeriod.Name = "GCPeriod"
        Me.GCPeriod.Size = New System.Drawing.Size(1002, 701)
        Me.GCPeriod.TabIndex = 1
        Me.GCPeriod.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPeriod})
        '
        'GVPeriod
        '
        Me.GVPeriod.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn1, Me.GridColumn2, Me.GridColumn4, Me.GridColumn3})
        Me.GVPeriod.GridControl = Me.GCPeriod
        Me.GVPeriod.Name = "GVPeriod"
        Me.GVPeriod.OptionsBehavior.Editable = False
        Me.GVPeriod.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.FieldName = "id_st_store_period"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "SOH Date"
        Me.GridColumn1.FieldName = "soh_date"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Store"
        Me.GridColumn2.FieldName = "store_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Schedule Start"
        Me.GridColumn4.FieldName = "schedule_start"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Schedule End"
        Me.GridColumn3.FieldName = "schedule_end"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'XtraTabControl
        '
        Me.XtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl.Name = "XtraTabControl"
        Me.XtraTabControl.SelectedTabPage = Me.XTPPeriod
        Me.XtraTabControl.Size = New System.Drawing.Size(1008, 729)
        Me.XtraTabControl.TabIndex = 2
        Me.XtraTabControl.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPeriod, Me.XTPCompare})
        '
        'XTPPeriod
        '
        Me.XTPPeriod.Controls.Add(Me.GCPeriod)
        Me.XTPPeriod.Name = "XTPPeriod"
        Me.XTPPeriod.Size = New System.Drawing.Size(1002, 701)
        Me.XTPPeriod.Text = "Period"
        '
        'XTPCompare
        '
        Me.XTPCompare.Controls.Add(Me.GCCompare)
        Me.XTPCompare.Controls.Add(Me.PanelControl2)
        Me.XTPCompare.Controls.Add(Me.PanelControl1)
        Me.XTPCompare.Name = "XTPCompare"
        Me.XTPCompare.Size = New System.Drawing.Size(1002, 701)
        Me.XTPCompare.Text = "Hasil Scan"
        '
        'GCCompare
        '
        Me.GCCompare.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompare.Location = New System.Drawing.Point(0, 45)
        Me.GCCompare.MainView = Me.BGVCompare
        Me.GCCompare.Name = "GCCompare"
        Me.GCCompare.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit})
        Me.GCCompare.Size = New System.Drawing.Size(1002, 611)
        Me.GCCompare.TabIndex = 1
        Me.GCCompare.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVCompare})
        '
        'BGVCompare
        '
        Me.BGVCompare.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.gridBand5})
        Me.BGVCompare.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.BandedGridColumn8, Me.BandedGridColumn13, Me.BandedGridColumn9, Me.BandedGridColumn11, Me.BandedGridColumn10, Me.BandedGridColumn12, Me.BandedGridColumnunit_price, Me.BandedGridColumnsoh_amount, Me.BandedGridColumnstore_amount, Me.BandedGridColumndiff_amount, Me.BandedGridColumn15, Me.BandedGridColumn14})
        Me.BGVCompare.GridControl = Me.GCCompare
        Me.BGVCompare.GroupCount = 1
        Me.BGVCompare.Name = "BGVCompare"
        Me.BGVCompare.OptionsBehavior.AutoExpandAllGroups = True
        Me.BGVCompare.OptionsView.ShowFooter = True
        Me.BGVCompare.OptionsView.ShowGroupPanel = False
        Me.BGVCompare.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn9, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Product Info"
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnunit_price)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 300
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "No"
        Me.BandedGridColumn1.FieldName = "no"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Code"
        Me.BandedGridColumn2.FieldName = "full_code"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Name"
        Me.BandedGridColumn3.FieldName = "name"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Size"
        Me.BandedGridColumn4.FieldName = "size"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn4.Visible = True
        '
        'BandedGridColumnunit_price
        '
        Me.BandedGridColumnunit_price.Caption = "Unit Price"
        Me.BandedGridColumnunit_price.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnunit_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnunit_price.FieldName = "unit_price"
        Me.BandedGridColumnunit_price.Name = "BandedGridColumnunit_price"
        Me.BandedGridColumnunit_price.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Volcom"
        Me.gridBand2.Columns.Add(Me.BandedGridColumn5)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnsoh_amount)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 150
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Qty"
        Me.BandedGridColumn5.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn5.FieldName = "qty_volcom"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_volcom", "{0:N0}")})
        Me.BandedGridColumn5.Visible = True
        '
        'BandedGridColumnsoh_amount
        '
        Me.BandedGridColumnsoh_amount.Caption = "Amount"
        Me.BandedGridColumnsoh_amount.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnsoh_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnsoh_amount.FieldName = "soh_amount"
        Me.BandedGridColumnsoh_amount.Name = "BandedGridColumnsoh_amount"
        Me.BandedGridColumnsoh_amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_amount", "{0:N0}")})
        Me.BandedGridColumnsoh_amount.UnboundExpression = "[unit_price]*[qty_volcom]"
        Me.BandedGridColumnsoh_amount.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnsoh_amount.Visible = True
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Store"
        Me.gridBand3.Columns.Add(Me.BandedGridColumn6)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnstore_amount)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 150
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Qty"
        Me.BandedGridColumn6.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn6.FieldName = "qty_store"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_store", "{0:N0}")})
        Me.BandedGridColumn6.Visible = True
        '
        'BandedGridColumnstore_amount
        '
        Me.BandedGridColumnstore_amount.Caption = "Amount"
        Me.BandedGridColumnstore_amount.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnstore_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnstore_amount.FieldName = "store_amount"
        Me.BandedGridColumnstore_amount.Name = "BandedGridColumnstore_amount"
        Me.BandedGridColumnstore_amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "store_amount", "{0:N0}")})
        Me.BandedGridColumnstore_amount.UnboundExpression = "[unit_price]*[qty_store]"
        Me.BandedGridColumnstore_amount.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnstore_amount.Visible = True
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "Note"
        Me.gridBand4.Columns.Add(Me.BandedGridColumn7)
        Me.gridBand4.Columns.Add(Me.BandedGridColumndiff_amount)
        Me.gridBand4.Columns.Add(Me.BandedGridColumn8)
        Me.gridBand4.Columns.Add(Me.BandedGridColumn13)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 300
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "Diff"
        Me.BandedGridColumn7.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn7.FieldName = "diff"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff", "{0:N0}")})
        Me.BandedGridColumn7.Visible = True
        '
        'BandedGridColumndiff_amount
        '
        Me.BandedGridColumndiff_amount.Caption = "Amount"
        Me.BandedGridColumndiff_amount.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumndiff_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumndiff_amount.FieldName = "diff_amount"
        Me.BandedGridColumndiff_amount.Name = "BandedGridColumndiff_amount"
        Me.BandedGridColumndiff_amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_amount", "{0:N0}")})
        Me.BandedGridColumndiff_amount.UnboundExpression = "[unit_price]*[diff]"
        Me.BandedGridColumndiff_amount.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumndiff_amount.Visible = True
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "Note"
        Me.BandedGridColumn8.FieldName = "note"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn8.Visible = True
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.Caption = "Store Note"
        Me.BandedGridColumn13.FieldName = "store_note"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        Me.BandedGridColumn13.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn13.Visible = True
        '
        'gridBand5
        '
        Me.gridBand5.Caption = "Account"
        Me.gridBand5.Columns.Add(Me.BandedGridColumn9)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn11)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 4
        Me.gridBand5.Width = 150
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "Account"
        Me.BandedGridColumn9.FieldName = "comp_name"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn9.Visible = True
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.Caption = "*"
        Me.BandedGridColumn11.ColumnEdit = Me.RepositoryItemCheckEdit
        Me.BandedGridColumn11.FieldName = "is_select"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.Visible = True
        '
        'RepositoryItemCheckEdit
        '
        Me.RepositoryItemCheckEdit.AutoHeight = False
        Me.RepositoryItemCheckEdit.Name = "RepositoryItemCheckEdit"
        Me.RepositoryItemCheckEdit.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit.ValueUnchecked = "no"
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.FieldName = "is_auto"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.FieldName = "id_product"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        Me.BandedGridColumn12.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn15
        '
        Me.BandedGridColumn15.FieldName = "id_price"
        Me.BandedGridColumn15.Name = "BandedGridColumn15"
        Me.BandedGridColumn15.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn14
        '
        Me.BandedGridColumn14.FieldName = "id_comp"
        Me.BandedGridColumn14.Name = "BandedGridColumn14"
        Me.BandedGridColumn14.OptionsColumn.AllowEdit = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBVerification)
        Me.PanelControl2.Controls.Add(Me.SBSelectAccount)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 656)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1002, 45)
        Me.PanelControl2.TabIndex = 2
        '
        'SBVerification
        '
        Me.SBVerification.Dock = System.Windows.Forms.DockStyle.Left
        Me.SBVerification.Image = CType(resources.GetObject("SBVerification.Image"), System.Drawing.Image)
        Me.SBVerification.Location = New System.Drawing.Point(2, 2)
        Me.SBVerification.Name = "SBVerification"
        Me.SBVerification.Size = New System.Drawing.Size(124, 41)
        Me.SBVerification.TabIndex = 1
        Me.SBVerification.Text = "Verification"
        '
        'SBSelectAccount
        '
        Me.SBSelectAccount.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSelectAccount.Image = CType(resources.GetObject("SBSelectAccount.Image"), System.Drawing.Image)
        Me.SBSelectAccount.Location = New System.Drawing.Point(861, 2)
        Me.SBSelectAccount.Name = "SBSelectAccount"
        Me.SBSelectAccount.Size = New System.Drawing.Size(139, 41)
        Me.SBSelectAccount.TabIndex = 0
        Me.SBSelectAccount.Text = "Select Account"
        Me.SBSelectAccount.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBStopScan)
        Me.PanelControl1.Controls.Add(Me.SBBAPPelaksanaan)
        Me.PanelControl1.Controls.Add(Me.BtnExportToXLS)
        Me.PanelControl1.Controls.Add(Me.BtnScanList)
        Me.PanelControl1.Controls.Add(Me.SBSync)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1002, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'SBBAPPelaksanaan
        '
        Me.SBBAPPelaksanaan.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBBAPPelaksanaan.Image = CType(resources.GetObject("SBBAPPelaksanaan.Image"), System.Drawing.Image)
        Me.SBBAPPelaksanaan.Location = New System.Drawing.Point(765, 2)
        Me.SBBAPPelaksanaan.Name = "SBBAPPelaksanaan"
        Me.SBBAPPelaksanaan.Size = New System.Drawing.Size(141, 41)
        Me.SBBAPPelaksanaan.TabIndex = 3
        Me.SBBAPPelaksanaan.Text = "BAP Pelaksanaan"
        '
        'BtnExportToXLS
        '
        Me.BtnExportToXLS.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnExportToXLS.Image = CType(resources.GetObject("BtnExportToXLS.Image"), System.Drawing.Image)
        Me.BtnExportToXLS.Location = New System.Drawing.Point(140, 2)
        Me.BtnExportToXLS.Name = "BtnExportToXLS"
        Me.BtnExportToXLS.Size = New System.Drawing.Size(124, 41)
        Me.BtnExportToXLS.TabIndex = 2
        Me.BtnExportToXLS.Text = "Export to XLS"
        '
        'BtnScanList
        '
        Me.BtnScanList.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnScanList.Image = CType(resources.GetObject("BtnScanList.Image"), System.Drawing.Image)
        Me.BtnScanList.Location = New System.Drawing.Point(2, 2)
        Me.BtnScanList.Name = "BtnScanList"
        Me.BtnScanList.Size = New System.Drawing.Size(138, 41)
        Me.BtnScanList.TabIndex = 1
        Me.BtnScanList.Text = "Scanned Item List"
        '
        'SBSync
        '
        Me.SBSync.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSync.Image = CType(resources.GetObject("SBSync.Image"), System.Drawing.Image)
        Me.SBSync.Location = New System.Drawing.Point(906, 2)
        Me.SBSync.Name = "SBSync"
        Me.SBSync.Size = New System.Drawing.Size(94, 41)
        Me.SBSync.TabIndex = 0
        Me.SBSync.Text = "Sync"
        '
        'SBStopScan
        '
        Me.SBStopScan.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBStopScan.Image = CType(resources.GetObject("SBStopScan.Image"), System.Drawing.Image)
        Me.SBStopScan.Location = New System.Drawing.Point(655, 2)
        Me.SBStopScan.Name = "SBStopScan"
        Me.SBStopScan.Size = New System.Drawing.Size(110, 41)
        Me.SBStopScan.TabIndex = 4
        Me.SBStopScan.Text = "Stop Scan"
        '
        'FormStockTakeStorePeriod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.XtraTabControl)
        Me.Name = "FormStockTakeStorePeriod"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Take Store"
        CType(Me.GCPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl.ResumeLayout(False)
        Me.XTPPeriod.ResumeLayout(False)
        Me.XTPCompare.ResumeLayout(False)
        CType(Me.GCCompare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVCompare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCPeriod As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPeriod As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPeriod As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPCompare As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBSync As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCCompare As DevExpress.XtraGrid.GridControl
    Friend WithEvents BGVCompare As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBSelectAccount As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BtnExportToXLS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnScanList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BandedGridColumnunit_price As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsoh_amount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnstore_amount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndiff_amount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents SBVerification As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BandedGridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SBBAPPelaksanaan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBStopScan As DevExpress.XtraEditors.SimpleButton
End Class
