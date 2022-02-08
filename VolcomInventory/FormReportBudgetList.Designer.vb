<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportBudgetList
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
        Me.components = New System.ComponentModel.Container()
        Me.GCBudgetCard = New DevExpress.XtraGrid.GridControl()
        Me.ViewReport = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVBudgetCard = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPCard = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPO = New DevExpress.XtraGrid.GridControl()
        Me.GVPO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn99 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn101 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn89 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCountPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRecAmo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RPBRec = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEIsCheckPO = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.GCBudgetCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewReport.SuspendLayout()
        CType(Me.GVBudgetCard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPCard.SuspendLayout()
        Me.XTPList.SuspendLayout()
        CType(Me.GCPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RPBRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEIsCheckPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCBudgetCard
        '
        Me.GCBudgetCard.ContextMenuStrip = Me.ViewReport
        Me.GCBudgetCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBudgetCard.Location = New System.Drawing.Point(0, 0)
        Me.GCBudgetCard.MainView = Me.GVBudgetCard
        Me.GCBudgetCard.Name = "GCBudgetCard"
        Me.GCBudgetCard.Size = New System.Drawing.Size(786, 499)
        Me.GCBudgetCard.TabIndex = 0
        Me.GCBudgetCard.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBudgetCard})
        '
        'ViewReport
        '
        Me.ViewReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailToolStripMenuItem})
        Me.ViewReport.Name = "ContextMenuStripYM"
        Me.ViewReport.Size = New System.Drawing.Size(138, 26)
        '
        'ViewDetailToolStripMenuItem
        '
        Me.ViewDetailToolStripMenuItem.Name = "ViewDetailToolStripMenuItem"
        Me.ViewDetailToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ViewDetailToolStripMenuItem.Text = "View Report"
        '
        'GVBudgetCard
        '
        Me.GVBudgetCard.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn7, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVBudgetCard.GridControl = Me.GCBudgetCard
        Me.GVBudgetCard.Name = "GVBudgetCard"
        Me.GVBudgetCard.OptionsBehavior.Editable = False
        Me.GVBudgetCard.OptionsBehavior.ReadOnly = True
        Me.GVBudgetCard.OptionsView.ShowFooter = True
        Me.GVBudgetCard.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Description"
        Me.GridColumn1.FieldName = "note"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 208
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Report Number"
        Me.GridColumn6.FieldName = "report_number"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 106
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Item"
        Me.GridColumn7.FieldName = "item_desc"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 86
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Used Budget"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "value"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", "{0:N2}")})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        Me.GridColumn2.Width = 374
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Remaining"
        Me.GridColumn3.FieldName = "remaining_budget"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID Report"
        Me.GridColumn4.FieldName = "id_report"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Report Mark Type"
        Me.GridColumn5.FieldName = "report_mark_type"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPCard
        Me.XtraTabControl1.Size = New System.Drawing.Size(792, 527)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPCard, Me.XTPList})
        '
        'XTPCard
        '
        Me.XTPCard.Controls.Add(Me.GCBudgetCard)
        Me.XTPCard.Name = "XTPCard"
        Me.XTPCard.Size = New System.Drawing.Size(786, 499)
        Me.XTPCard.Text = "Card List"
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCPO)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(786, 499)
        Me.XTPList.Text = "List Booked PO"
        '
        'GCPO
        '
        Me.GCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPO.Location = New System.Drawing.Point(0, 0)
        Me.GCPO.MainView = Me.GVPO
        Me.GCPO.Name = "GCPO"
        Me.GCPO.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEIsCheckPO, Me.RPBRec})
        Me.GCPO.Size = New System.Drawing.Size(786, 499)
        Me.GCPO.TabIndex = 1
        Me.GCPO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPO})
        '
        'GVPO
        '
        Me.GVPO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn99, Me.GridColumn9, Me.GridColumn101, Me.GridColumn10, Me.GridColumn35, Me.GridColumn11, Me.GridColumn37, Me.GridColumn36, Me.GridColumn89, Me.GridColumn12, Me.GridColumn13, Me.GridColumnCountPO, Me.GridColumnTotPO, Me.GridColumnRecAmo, Me.GridColumn59, Me.GridColumn53, Me.GridColumn54, Me.GridColumn58, Me.GridColumn57, Me.GridColumn55, Me.GridColumn56})
        Me.GVPO.GridControl = Me.GCPO
        Me.GVPO.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "last_update", Me.GridColumnCountPO, "Total PO : {0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_po", Me.GridColumnTotPO, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", Me.GridColumnRecAmo, "{0:N2}")})
        Me.GVPO.Name = "GVPO"
        Me.GVPO.OptionsView.ColumnAutoWidth = False
        Me.GVPO.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPO.OptionsView.ShowFooter = True
        Me.GVPO.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID PO"
        Me.GridColumn8.FieldName = "id_purc_order"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        '
        'GridColumn99
        '
        Me.GridColumn99.Caption = "Unit"
        Me.GridColumn99.FieldName = "tag_description"
        Me.GridColumn99.Name = "GridColumn99"
        Me.GridColumn99.Visible = True
        Me.GridColumn99.VisibleIndex = 0
        Me.GridColumn99.Width = 94
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "PO Number"
        Me.GridColumn9.FieldName = "purc_order_number"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        '
        'GridColumn101
        '
        Me.GridColumn101.Caption = "PO Type"
        Me.GridColumn101.FieldName = "expense_type"
        Me.GridColumn101.Name = "GridColumn101"
        Me.GridColumn101.Visible = True
        Me.GridColumn101.VisibleIndex = 1
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Created By"
        Me.GridColumn10.FieldName = "emp_created"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 3
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "Vendor Code"
        Me.GridColumn35.FieldName = "comp_number"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 5
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Vendor"
        Me.GridColumn11.FieldName = "comp_name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Contact Person"
        Me.GridColumn37.FieldName = "contact_person"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.OptionsColumn.AllowEdit = False
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 6
        Me.GridColumn37.Width = 84
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Contact Number"
        Me.GridColumn36.FieldName = "contact_number"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsColumn.AllowEdit = False
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 7
        Me.GridColumn36.Width = 88
        '
        'GridColumn89
        '
        Me.GridColumn89.Caption = "Approval Status"
        Me.GridColumn89.FieldName = "report_status"
        Me.GridColumn89.Name = "GridColumn89"
        Me.GridColumn89.Visible = True
        Me.GridColumn89.VisibleIndex = 9
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Created Date"
        Me.GridColumn12.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn12.FieldName = "date_created"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 8
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Last Update By"
        Me.GridColumn13.FieldName = "emp_updated"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 10
        Me.GridColumn13.Width = 83
        '
        'GridColumnCountPO
        '
        Me.GridColumnCountPO.Caption = "Last Update"
        Me.GridColumnCountPO.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCountPO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCountPO.FieldName = "last_update"
        Me.GridColumnCountPO.Name = "GridColumnCountPO"
        Me.GridColumnCountPO.OptionsColumn.AllowEdit = False
        Me.GridColumnCountPO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "last_update", "Total PO : {0}")})
        Me.GridColumnCountPO.Visible = True
        Me.GridColumnCountPO.VisibleIndex = 11
        '
        'GridColumnTotPO
        '
        Me.GridColumnTotPO.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotPO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotPO.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotPO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotPO.Caption = "PO Amount"
        Me.GridColumnTotPO.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotPO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotPO.FieldName = "total_po"
        Me.GridColumnTotPO.Name = "GridColumnTotPO"
        Me.GridColumnTotPO.OptionsColumn.AllowEdit = False
        Me.GridColumnTotPO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_po", "{0:N2}")})
        Me.GridColumnTotPO.Visible = True
        Me.GridColumnTotPO.VisibleIndex = 12
        '
        'GridColumnRecAmo
        '
        Me.GridColumnRecAmo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnRecAmo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRecAmo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRecAmo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRecAmo.Caption = "Receive Amount"
        Me.GridColumnRecAmo.DisplayFormat.FormatString = "N2"
        Me.GridColumnRecAmo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRecAmo.FieldName = "total_rec"
        Me.GridColumnRecAmo.Name = "GridColumnRecAmo"
        Me.GridColumnRecAmo.OptionsColumn.AllowEdit = False
        Me.GridColumnRecAmo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", "{0:N2}")})
        Me.GridColumnRecAmo.Visible = True
        Me.GridColumnRecAmo.VisibleIndex = 13
        '
        'GridColumn59
        '
        Me.GridColumn59.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn59.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn59.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn59.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn59.Caption = "Paid Amount"
        Me.GridColumn59.DisplayFormat.FormatString = "N2"
        Me.GridColumn59.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn59.FieldName = "val_pay"
        Me.GridColumn59.Name = "GridColumn59"
        Me.GridColumn59.OptionsColumn.AllowEdit = False
        Me.GridColumn59.Visible = True
        Me.GridColumn59.VisibleIndex = 17
        '
        'GridColumn53
        '
        Me.GridColumn53.Caption = "Receive Progress"
        Me.GridColumn53.ColumnEdit = Me.RPBRec
        Me.GridColumn53.FieldName = "rec_progress"
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.OptionsColumn.AllowEdit = False
        Me.GridColumn53.Visible = True
        Me.GridColumn53.VisibleIndex = 14
        Me.GridColumn53.Width = 93
        '
        'RPBRec
        '
        Me.RPBRec.EndColor = System.Drawing.Color.LawnGreen
        Me.RPBRec.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.RPBRec.LookAndFeel.UseDefaultLookAndFeel = False
        Me.RPBRec.Name = "RPBRec"
        Me.RPBRec.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.RPBRec.ShowTitle = True
        Me.RPBRec.Step = 1
        '
        'GridColumn54
        '
        Me.GridColumn54.Caption = "Receive Status"
        Me.GridColumn54.FieldName = "rec_status"
        Me.GridColumn54.Name = "GridColumn54"
        Me.GridColumn54.OptionsColumn.AllowEdit = False
        Me.GridColumn54.Visible = True
        Me.GridColumn54.VisibleIndex = 16
        Me.GridColumn54.Width = 82
        '
        'GridColumn58
        '
        Me.GridColumn58.Caption = "Est. Receive Date"
        Me.GridColumn58.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn58.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn58.FieldName = "est_date_receive"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.OptionsColumn.AllowEdit = False
        Me.GridColumn58.Visible = True
        Me.GridColumn58.VisibleIndex = 15
        Me.GridColumn58.Width = 96
        '
        'GridColumn57
        '
        Me.GridColumn57.Caption = "Payment Due Date"
        Me.GridColumn57.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn57.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn57.FieldName = "pay_due_date"
        Me.GridColumn57.Name = "GridColumn57"
        Me.GridColumn57.OptionsColumn.AllowEdit = False
        Me.GridColumn57.Visible = True
        Me.GridColumn57.VisibleIndex = 19
        Me.GridColumn57.Width = 100
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "Payment Progress"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.OptionsColumn.AllowEdit = False
        Me.GridColumn55.Visible = True
        Me.GridColumn55.VisibleIndex = 18
        Me.GridColumn55.Width = 97
        '
        'GridColumn56
        '
        Me.GridColumn56.Caption = "Payment Status"
        Me.GridColumn56.FieldName = "pay_status"
        Me.GridColumn56.Name = "GridColumn56"
        Me.GridColumn56.OptionsColumn.AllowEdit = False
        Me.GridColumn56.Visible = True
        Me.GridColumn56.VisibleIndex = 20
        Me.GridColumn56.Width = 86
        '
        'RICEIsCheckPO
        '
        Me.RICEIsCheckPO.AutoHeight = False
        Me.RICEIsCheckPO.Name = "RICEIsCheckPO"
        Me.RICEIsCheckPO.ValueChecked = "yes"
        Me.RICEIsCheckPO.ValueUnchecked = "no"
        '
        'FormReportBudgetList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 527)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormReportBudgetList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Budget Card List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GCBudgetCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewReport.ResumeLayout(False)
        CType(Me.GVBudgetCard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPCard.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        CType(Me.GCPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RPBRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEIsCheckPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCBudgetCard As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBudgetCard As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewReport As ContextMenuStrip
    Friend WithEvents ViewDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPCard As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn99 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn101 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn89 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCountPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecAmo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RPBRec As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEIsCheckPO As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
