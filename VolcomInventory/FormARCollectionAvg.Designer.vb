<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormARCollectionAvg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormARCollectionAvg))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEYear = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSummary = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSummary = New DevExpress.XtraGrid.GridControl()
        Me.GVSummary = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_store = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnidate_pdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnddate_pdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncoll_rate_summary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group_detail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_store_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_pos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_due_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_bbm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbbm_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndate_received = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnidate_pdate_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnddate_pdate_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncoll_rate_detail = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPSummary.SuspendLayout()
        Me.XTPDetail.SuspendLayout()
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEYear)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(724, 42)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(209, 9)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(69, 23)
        Me.BtnView.TabIndex = 2
        Me.BtnView.Text = "View"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Year"
        '
        'SLEYear
        '
        Me.SLEYear.Location = New System.Drawing.Point(43, 11)
        Me.SLEYear.Name = "SLEYear"
        Me.SLEYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEYear.Properties.ShowClearButton = False
        Me.SLEYear.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEYear.Size = New System.Drawing.Size(160, 20)
        Me.SLEYear.TabIndex = 3
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.Location = New System.Drawing.Point(0, 42)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPSummary
        Me.XTCData.Size = New System.Drawing.Size(724, 434)
        Me.XTCData.TabIndex = 2
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSummary, Me.XTPDetail})
        '
        'XTPSummary
        '
        Me.XTPSummary.Controls.Add(Me.GCSummary)
        Me.XTPSummary.Name = "XTPSummary"
        Me.XTPSummary.Size = New System.Drawing.Size(718, 406)
        Me.XTPSummary.Text = "Summary"
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.GCDetail)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(718, 406)
        Me.XTPDetail.Text = "Detail"
        '
        'GCSummary
        '
        Me.GCSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSummary.Location = New System.Drawing.Point(0, 0)
        Me.GCSummary.MainView = Me.GVSummary
        Me.GCSummary.Name = "GCSummary"
        Me.GCSummary.Size = New System.Drawing.Size(718, 406)
        Me.GCSummary.TabIndex = 0
        Me.GCSummary.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSummary})
        '
        'GVSummary
        '
        Me.GVSummary.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumngroup_store, Me.GridColumnidate_pdate, Me.GridColumnddate_pdate, Me.GridColumncoll_rate_summary})
        Me.GVSummary.GridControl = Me.GCSummary
        Me.GVSummary.Name = "GVSummary"
        Me.GVSummary.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSummary.OptionsFind.AlwaysVisible = True
        Me.GVSummary.OptionsView.ColumnAutoWidth = False
        Me.GVSummary.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        Me.GridColumnid_comp_group.OptionsColumn.AllowEdit = False
        '
        'GridColumngroup_store
        '
        Me.GridColumngroup_store.Caption = "Store Group"
        Me.GridColumngroup_store.FieldName = "group_store"
        Me.GridColumngroup_store.Name = "GridColumngroup_store"
        Me.GridColumngroup_store.OptionsColumn.AllowEdit = False
        Me.GridColumngroup_store.Visible = True
        Me.GridColumngroup_store.VisibleIndex = 0
        '
        'GridColumnidate_pdate
        '
        Me.GridColumnidate_pdate.Caption = "Collection Day (Invoice Date)"
        Me.GridColumnidate_pdate.DisplayFormat.FormatString = "N2"
        Me.GridColumnidate_pdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnidate_pdate.FieldName = "idate_pdate"
        Me.GridColumnidate_pdate.Name = "GridColumnidate_pdate"
        Me.GridColumnidate_pdate.OptionsColumn.AllowEdit = False
        Me.GridColumnidate_pdate.ToolTip = "Time span between invoice date and payment date"
        Me.GridColumnidate_pdate.Visible = True
        Me.GridColumnidate_pdate.VisibleIndex = 1
        Me.GridColumnidate_pdate.Width = 151
        '
        'GridColumnddate_pdate
        '
        Me.GridColumnddate_pdate.Caption = "Collection Day (Due Date)"
        Me.GridColumnddate_pdate.DisplayFormat.FormatString = "N2"
        Me.GridColumnddate_pdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnddate_pdate.FieldName = "ddate_pdate"
        Me.GridColumnddate_pdate.Name = "GridColumnddate_pdate"
        Me.GridColumnddate_pdate.OptionsColumn.AllowEdit = False
        Me.GridColumnddate_pdate.Visible = True
        Me.GridColumnddate_pdate.VisibleIndex = 2
        Me.GridColumnddate_pdate.Width = 162
        '
        'GridColumncoll_rate_summary
        '
        Me.GridColumncoll_rate_summary.Caption = "Collection Rate"
        Me.GridColumncoll_rate_summary.FieldName = "coll_rate_summary"
        Me.GridColumncoll_rate_summary.Name = "GridColumncoll_rate_summary"
        Me.GridColumncoll_rate_summary.OptionsColumn.AllowEdit = False
        Me.GridColumncoll_rate_summary.UnboundExpression = "Iif([ddate_pdate] <= 0, 'Lancar', 'Tidak Lancar')"
        Me.GridColumncoll_rate_summary.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumncoll_rate_summary.Visible = True
        Me.GridColumncoll_rate_summary.VisibleIndex = 3
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.Size = New System.Drawing.Size(718, 406)
        Me.GCDetail.TabIndex = 1
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group_detail, Me.GridColumngroup_store_det, Me.GridColumnid_sales_pos, Me.GridColumnsales_pos_number, Me.GridColumnsales_pos_date, Me.GridColumnsales_pos_due_date, Me.GridColumnamount, Me.GridColumnid_bbm, Me.GridColumnbbm_number, Me.GridColumndate_received, Me.GridColumnidate_pdate_det, Me.GridColumnddate_pdate_det, Me.GridColumncoll_rate_detail})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.GroupCount = 1
        Me.GVDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnamount, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "idate_pdate", Me.GridColumnidate_pdate_det, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "ddate_pdate", Me.GridColumnddate_pdate_det, "{0:N2}")})
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsFind.AlwaysVisible = True
        Me.GVDetail.OptionsView.ColumnAutoWidth = False
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupedColumns = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        Me.GVDetail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumngroup_store_det, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnid_comp_group_detail
        '
        Me.GridColumnid_comp_group_detail.Caption = "id_comp_group"
        Me.GridColumnid_comp_group_detail.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group_detail.Name = "GridColumnid_comp_group_detail"
        Me.GridColumnid_comp_group_detail.OptionsColumn.AllowEdit = False
        '
        'GridColumngroup_store_det
        '
        Me.GridColumngroup_store_det.Caption = "Store Group"
        Me.GridColumngroup_store_det.FieldName = "group_store"
        Me.GridColumngroup_store_det.Name = "GridColumngroup_store_det"
        Me.GridColumngroup_store_det.OptionsColumn.AllowEdit = False
        Me.GridColumngroup_store_det.Visible = True
        Me.GridColumngroup_store_det.VisibleIndex = 0
        Me.GridColumngroup_store_det.Width = 104
        '
        'GridColumnid_sales_pos
        '
        Me.GridColumnid_sales_pos.Caption = "id_sales_pos"
        Me.GridColumnid_sales_pos.FieldName = "id_sales_pos"
        Me.GridColumnid_sales_pos.Name = "GridColumnid_sales_pos"
        Me.GridColumnid_sales_pos.OptionsColumn.AllowEdit = False
        '
        'GridColumnsales_pos_number
        '
        Me.GridColumnsales_pos_number.Caption = "Invoice No"
        Me.GridColumnsales_pos_number.FieldName = "sales_pos_number"
        Me.GridColumnsales_pos_number.Name = "GridColumnsales_pos_number"
        Me.GridColumnsales_pos_number.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_number.Visible = True
        Me.GridColumnsales_pos_number.VisibleIndex = 1
        '
        'GridColumnsales_pos_date
        '
        Me.GridColumnsales_pos_date.Caption = "Invoice Date"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_date.FieldName = "sales_pos_date"
        Me.GridColumnsales_pos_date.Name = "GridColumnsales_pos_date"
        Me.GridColumnsales_pos_date.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_date.Visible = True
        Me.GridColumnsales_pos_date.VisibleIndex = 2
        '
        'GridColumnsales_pos_due_date
        '
        Me.GridColumnsales_pos_due_date.Caption = "Due Date"
        Me.GridColumnsales_pos_due_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_due_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_due_date.FieldName = "sales_pos_due_date"
        Me.GridColumnsales_pos_due_date.Name = "GridColumnsales_pos_due_date"
        Me.GridColumnsales_pos_due_date.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_due_date.Visible = True
        Me.GridColumnsales_pos_due_date.VisibleIndex = 3
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount"
        Me.GridColumnamount.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.OptionsColumn.AllowEdit = False
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 4
        '
        'GridColumnid_bbm
        '
        Me.GridColumnid_bbm.Caption = "id_bbm"
        Me.GridColumnid_bbm.FieldName = "id_bbm"
        Me.GridColumnid_bbm.Name = "GridColumnid_bbm"
        Me.GridColumnid_bbm.OptionsColumn.AllowEdit = False
        '
        'GridColumnbbm_number
        '
        Me.GridColumnbbm_number.Caption = "BBM No"
        Me.GridColumnbbm_number.FieldName = "bbm_number"
        Me.GridColumnbbm_number.Name = "GridColumnbbm_number"
        Me.GridColumnbbm_number.OptionsColumn.AllowEdit = False
        Me.GridColumnbbm_number.Visible = True
        Me.GridColumnbbm_number.VisibleIndex = 5
        '
        'GridColumndate_received
        '
        Me.GridColumndate_received.Caption = "Payment Date"
        Me.GridColumndate_received.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumndate_received.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndate_received.FieldName = "date_received"
        Me.GridColumndate_received.Name = "GridColumndate_received"
        Me.GridColumndate_received.OptionsColumn.AllowEdit = False
        Me.GridColumndate_received.Visible = True
        Me.GridColumndate_received.VisibleIndex = 6
        Me.GridColumndate_received.Width = 101
        '
        'GridColumnidate_pdate_det
        '
        Me.GridColumnidate_pdate_det.Caption = "Collection Day (Invoice Date)"
        Me.GridColumnidate_pdate_det.DisplayFormat.FormatString = "N2"
        Me.GridColumnidate_pdate_det.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnidate_pdate_det.FieldName = "idate_pdate"
        Me.GridColumnidate_pdate_det.Name = "GridColumnidate_pdate_det"
        Me.GridColumnidate_pdate_det.OptionsColumn.AllowEdit = False
        Me.GridColumnidate_pdate_det.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "idate_pdate", "{0:N2}")})
        Me.GridColumnidate_pdate_det.Visible = True
        Me.GridColumnidate_pdate_det.VisibleIndex = 7
        Me.GridColumnidate_pdate_det.Width = 169
        '
        'GridColumnddate_pdate_det
        '
        Me.GridColumnddate_pdate_det.Caption = "Collection Day (Due Date)"
        Me.GridColumnddate_pdate_det.DisplayFormat.FormatString = "N2"
        Me.GridColumnddate_pdate_det.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnddate_pdate_det.FieldName = "ddate_pdate"
        Me.GridColumnddate_pdate_det.Name = "GridColumnddate_pdate_det"
        Me.GridColumnddate_pdate_det.OptionsColumn.AllowEdit = False
        Me.GridColumnddate_pdate_det.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "ddate_pdate", "{0:N2}")})
        Me.GridColumnddate_pdate_det.Visible = True
        Me.GridColumnddate_pdate_det.VisibleIndex = 8
        Me.GridColumnddate_pdate_det.Width = 145
        '
        'GridColumncoll_rate_detail
        '
        Me.GridColumncoll_rate_detail.Caption = "Collection Rate"
        Me.GridColumncoll_rate_detail.FieldName = "coll_rate_detail"
        Me.GridColumncoll_rate_detail.Name = "GridColumncoll_rate_detail"
        Me.GridColumncoll_rate_detail.OptionsColumn.AllowEdit = False
        Me.GridColumncoll_rate_detail.UnboundExpression = "Iif([ddate_pdate] <= 0, 'Lancar', 'Tidak Lancar')"
        Me.GridColumncoll_rate_detail.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumncoll_rate_detail.Visible = True
        Me.GridColumncoll_rate_detail.VisibleIndex = 9
        Me.GridColumncoll_rate_detail.Width = 170
        '
        'FormARCollectionAvg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 476)
        Me.Controls.Add(Me.XTCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormARCollectionAvg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Collection Average"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPSummary.ResumeLayout(False)
        Me.XTPDetail.ResumeLayout(False)
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEYear As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSummary As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSummary As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSummary As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_store As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnidate_pdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnddate_pdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncoll_rate_summary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group_detail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_store_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_pos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_due_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_bbm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbbm_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndate_received As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnidate_pdate_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnddate_pdate_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncoll_rate_detail As DevExpress.XtraGrid.Columns.GridColumn
End Class
