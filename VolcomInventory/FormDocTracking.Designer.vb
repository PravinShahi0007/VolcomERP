<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDocTracking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDocTracking))
        Me.PanelNav = New DevExpress.XtraEditors.PanelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEComp = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BandedGridColumntrans_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnbeg_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnbeg_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoQty = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BandedGridColumnreceive_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnreceive_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumntrf_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumntrf_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndel_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndel_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsal_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsal_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_report = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnreport_mark_type = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.VolcomMRP.WaitForm), True, True)
        Me.BandedGridColumnexp_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnexp_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand14 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand10 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand11 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand12 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand13 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnrts_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.PanelNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelNav.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelNav
        '
        Me.PanelNav.Controls.Add(Me.BView)
        Me.PanelNav.Controls.Add(Me.DEUntil)
        Me.PanelNav.Controls.Add(Me.LabelControl3)
        Me.PanelNav.Controls.Add(Me.LabelControl1)
        Me.PanelNav.Controls.Add(Me.LabelControl2)
        Me.PanelNav.Controls.Add(Me.SLEComp)
        Me.PanelNav.Controls.Add(Me.DEFrom)
        Me.PanelNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelNav.Name = "PanelNav"
        Me.PanelNav.Size = New System.Drawing.Size(1007, 48)
        Me.PanelNav.TabIndex = 0
        '
        'BView
        '
        Me.BView.Image = CType(resources.GetObject("BView.Image"), System.Drawing.Image)
        Me.BView.Location = New System.Drawing.Point(635, 14)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(60, 20)
        Me.BView.TabIndex = 8914
        Me.BView.Text = "View"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Enabled = False
        Me.DEUntil.Location = New System.Drawing.Point(452, 14)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(177, 20)
        Me.DEUntil.TabIndex = 8933
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(244, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8934
        Me.LabelControl3.Text = "From"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(425, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl1.TabIndex = 8932
        Me.LabelControl1.Text = "Until"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(16, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl2.TabIndex = 8913
        Me.LabelControl2.Text = "Account"
        '
        'SLEComp
        '
        Me.SLEComp.Location = New System.Drawing.Point(61, 14)
        Me.SLEComp.Name = "SLEComp"
        Me.SLEComp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEComp.Properties.View = Me.GridView2
        Me.SLEComp.Size = New System.Drawing.Size(177, 20)
        Me.SLEComp.TabIndex = 8914
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14, Me.GridColumnid_comp_cat})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID Comp"
        Me.GridColumn13.FieldName = "id_comp"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Company"
        Me.GridColumn14.FieldName = "comp_name"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'GridColumnid_comp_cat
        '
        Me.GridColumnid_comp_cat.Caption = "id_comp_cat"
        Me.GridColumnid_comp_cat.FieldName = "id_comp_cat"
        Me.GridColumnid_comp_cat.Name = "GridColumnid_comp_cat"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Enabled = False
        Me.DEFrom.Location = New System.Drawing.Point(274, 14)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(145, 20)
        Me.DEFrom.TabIndex = 8931
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 48)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoQty})
        Me.GCData.Size = New System.Drawing.Size(1007, 438)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand2, Me.gridBand14, Me.gridBand1, Me.gridBand3, Me.gridBand4, Me.gridBand5, Me.gridBand6, Me.gridBand7, Me.gridBand8, Me.gridBand9, Me.gridBand10, Me.gridBand11, Me.gridBand12, Me.gridBand13})
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnid_report, Me.BandedGridColumnreport_mark_type, Me.BandedGridColumntrans_date, Me.BandedGridColumnbeg_number, Me.BandedGridColumnbeg_qty, Me.BandedGridColumnreceive_number, Me.BandedGridColumnreceive_qty, Me.BandedGridColumntrf_number, Me.BandedGridColumntrf_qty, Me.BandedGridColumndel_number, Me.BandedGridColumndel_qty, Me.BandedGridColumnsal_number, Me.BandedGridColumnsal_qty, Me.BandedGridColumnexp_number, Me.BandedGridColumnexp_qty, Me.BandedGridColumnrts_number, Me.BandedGridColumn1})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'BandedGridColumntrans_date
        '
        Me.BandedGridColumntrans_date.Caption = "Date"
        Me.BandedGridColumntrans_date.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.BandedGridColumntrans_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumntrans_date.FieldName = "trans_date"
        Me.BandedGridColumntrans_date.Name = "BandedGridColumntrans_date"
        Me.BandedGridColumntrans_date.Visible = True
        '
        'BandedGridColumnbeg_number
        '
        Me.BandedGridColumnbeg_number.Caption = "Number"
        Me.BandedGridColumnbeg_number.FieldName = "beg_number"
        Me.BandedGridColumnbeg_number.Name = "BandedGridColumnbeg_number"
        Me.BandedGridColumnbeg_number.Visible = True
        '
        'BandedGridColumnbeg_qty
        '
        Me.BandedGridColumnbeg_qty.Caption = "Qty"
        Me.BandedGridColumnbeg_qty.ColumnEdit = Me.RepoQty
        Me.BandedGridColumnbeg_qty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnbeg_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnbeg_qty.FieldName = "beg_qty"
        Me.BandedGridColumnbeg_qty.Name = "BandedGridColumnbeg_qty"
        Me.BandedGridColumnbeg_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "beg_qty", "{0:N0}")})
        Me.BandedGridColumnbeg_qty.Visible = True
        '
        'RepoQty
        '
        Me.RepoQty.AutoHeight = False
        Me.RepoQty.Name = "RepoQty"
        '
        'BandedGridColumnreceive_number
        '
        Me.BandedGridColumnreceive_number.Caption = "Number"
        Me.BandedGridColumnreceive_number.FieldName = "receive_number"
        Me.BandedGridColumnreceive_number.Name = "BandedGridColumnreceive_number"
        Me.BandedGridColumnreceive_number.Visible = True
        '
        'BandedGridColumnreceive_qty
        '
        Me.BandedGridColumnreceive_qty.Caption = "Qty"
        Me.BandedGridColumnreceive_qty.ColumnEdit = Me.RepoQty
        Me.BandedGridColumnreceive_qty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnreceive_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnreceive_qty.FieldName = "receive_qty"
        Me.BandedGridColumnreceive_qty.Name = "BandedGridColumnreceive_qty"
        Me.BandedGridColumnreceive_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "receive_qty", "{0:N0}")})
        Me.BandedGridColumnreceive_qty.Visible = True
        '
        'BandedGridColumntrf_number
        '
        Me.BandedGridColumntrf_number.Caption = "Number"
        Me.BandedGridColumntrf_number.FieldName = "trf_number"
        Me.BandedGridColumntrf_number.Name = "BandedGridColumntrf_number"
        Me.BandedGridColumntrf_number.Visible = True
        '
        'BandedGridColumntrf_qty
        '
        Me.BandedGridColumntrf_qty.Caption = "Qty"
        Me.BandedGridColumntrf_qty.ColumnEdit = Me.RepoQty
        Me.BandedGridColumntrf_qty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumntrf_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumntrf_qty.FieldName = "trf_qty"
        Me.BandedGridColumntrf_qty.Name = "BandedGridColumntrf_qty"
        Me.BandedGridColumntrf_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "trf_qty", "{0:N0}")})
        Me.BandedGridColumntrf_qty.Visible = True
        '
        'BandedGridColumndel_number
        '
        Me.BandedGridColumndel_number.Caption = "Number"
        Me.BandedGridColumndel_number.FieldName = "del_number"
        Me.BandedGridColumndel_number.Name = "BandedGridColumndel_number"
        Me.BandedGridColumndel_number.Visible = True
        '
        'BandedGridColumndel_qty
        '
        Me.BandedGridColumndel_qty.Caption = "Qty"
        Me.BandedGridColumndel_qty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumndel_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumndel_qty.FieldName = "del_qty"
        Me.BandedGridColumndel_qty.Name = "BandedGridColumndel_qty"
        Me.BandedGridColumndel_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_qty", "{0:N0}")})
        Me.BandedGridColumndel_qty.Visible = True
        '
        'BandedGridColumnsal_number
        '
        Me.BandedGridColumnsal_number.Caption = "Number"
        Me.BandedGridColumnsal_number.FieldName = "sal_number"
        Me.BandedGridColumnsal_number.Name = "BandedGridColumnsal_number"
        Me.BandedGridColumnsal_number.Visible = True
        '
        'BandedGridColumnsal_qty
        '
        Me.BandedGridColumnsal_qty.Caption = "Qty"
        Me.BandedGridColumnsal_qty.ColumnEdit = Me.RepoQty
        Me.BandedGridColumnsal_qty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnsal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnsal_qty.FieldName = "sal_qty"
        Me.BandedGridColumnsal_qty.Name = "BandedGridColumnsal_qty"
        Me.BandedGridColumnsal_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sal_qty", "{0:N0}")})
        Me.BandedGridColumnsal_qty.Visible = True
        '
        'BandedGridColumnid_report
        '
        Me.BandedGridColumnid_report.Caption = "id_report"
        Me.BandedGridColumnid_report.FieldName = "id_report"
        Me.BandedGridColumnid_report.Name = "BandedGridColumnid_report"
        '
        'BandedGridColumnreport_mark_type
        '
        Me.BandedGridColumnreport_mark_type.Caption = "Report Mark Type"
        Me.BandedGridColumnreport_mark_type.FieldName = "report_mark_type"
        Me.BandedGridColumnreport_mark_type.Name = "BandedGridColumnreport_mark_type"
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'BandedGridColumnexp_number
        '
        Me.BandedGridColumnexp_number.Caption = "Number"
        Me.BandedGridColumnexp_number.FieldName = "exp_number"
        Me.BandedGridColumnexp_number.Name = "BandedGridColumnexp_number"
        Me.BandedGridColumnexp_number.Visible = True
        '
        'BandedGridColumnexp_qty
        '
        Me.BandedGridColumnexp_qty.Caption = "Qty"
        Me.BandedGridColumnexp_qty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnexp_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnexp_qty.FieldName = "exp_qty"
        Me.BandedGridColumnexp_qty.Name = "BandedGridColumnexp_qty"
        Me.BandedGridColumnexp_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "exp_qty", "{0:N0}")})
        Me.BandedGridColumnexp_qty.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.Columns.Add(Me.BandedGridColumntrans_date)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 0
        Me.gridBand2.Width = 75
        '
        'gridBand14
        '
        Me.gridBand14.Caption = "BEGINNING"
        Me.gridBand14.Columns.Add(Me.BandedGridColumnbeg_number)
        Me.gridBand14.Columns.Add(Me.BandedGridColumnbeg_qty)
        Me.gridBand14.Name = "gridBand14"
        Me.gridBand14.VisibleIndex = 1
        Me.gridBand14.Width = 150
        '
        'gridBand1
        '
        Me.gridBand1.Caption = "RECEIVE"
        Me.gridBand1.Columns.Add(Me.BandedGridColumnreceive_number)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnreceive_qty)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 2
        Me.gridBand1.Width = 150
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "TRANSFER"
        Me.gridBand3.Columns.Add(Me.BandedGridColumntrf_number)
        Me.gridBand3.Columns.Add(Me.BandedGridColumntrf_qty)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 3
        Me.gridBand3.Width = 150
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "DELIVERY"
        Me.gridBand4.Columns.Add(Me.BandedGridColumndel_number)
        Me.gridBand4.Columns.Add(Me.BandedGridColumndel_qty)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 4
        Me.gridBand4.Width = 150
        '
        'gridBand5
        '
        Me.gridBand5.Caption = "SALES"
        Me.gridBand5.Columns.Add(Me.BandedGridColumnsal_number)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnsal_qty)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 5
        Me.gridBand5.Width = 150
        '
        'gridBand6
        '
        Me.gridBand6.Caption = "EXPENSE"
        Me.gridBand6.Columns.Add(Me.BandedGridColumnexp_number)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnexp_qty)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 6
        Me.gridBand6.Width = 150
        '
        'gridBand7
        '
        Me.gridBand7.Caption = "RETURN"
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 7
        Me.gridBand7.Width = 75
        '
        'gridBand8
        '
        Me.gridBand8.Caption = "RETURN TRF"
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 8
        '
        'gridBand9
        '
        Me.gridBand9.Caption = "ADJ. OUT"
        Me.gridBand9.Name = "gridBand9"
        Me.gridBand9.VisibleIndex = 9
        '
        'gridBand10
        '
        Me.gridBand10.Caption = "ADJ. IN"
        Me.gridBand10.Name = "gridBand10"
        Me.gridBand10.VisibleIndex = 10
        '
        'gridBand11
        '
        Me.gridBand11.Caption = "REPAIR"
        Me.gridBand11.Name = "gridBand11"
        Me.gridBand11.VisibleIndex = 11
        '
        'gridBand12
        '
        Me.gridBand12.Caption = "RET. REPAIR"
        Me.gridBand12.Name = "gridBand12"
        Me.gridBand12.VisibleIndex = 12
        Me.gridBand12.Width = 87
        '
        'gridBand13
        '
        Me.gridBand13.Name = "gridBand13"
        Me.gridBand13.VisibleIndex = 13
        '
        'BandedGridColumnrts_number
        '
        Me.BandedGridColumnrts_number.Caption = "Number"
        Me.BandedGridColumnrts_number.FieldName = "rts_number"
        Me.BandedGridColumnrts_number.Name = "BandedGridColumnrts_number"
        Me.BandedGridColumnrts_number.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Qty"
        Me.BandedGridColumn1.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'FormDocTracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 486)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelNav)
        Me.Name = "FormDocTracking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Document Tracking"
        CType(Me.PanelNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelNav.ResumeLayout(False)
        Me.PanelNav.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEComp As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents BandedGridColumnid_report As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnreport_mark_type As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumntrans_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnbeg_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnbeg_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepoQty As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BandedGridColumnreceive_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnreceive_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumntrf_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumntrf_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndel_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndel_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsal_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsal_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand14 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnexp_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnexp_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand10 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand11 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand12 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand13 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnrts_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
