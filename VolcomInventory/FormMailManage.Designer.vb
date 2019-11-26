<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMailManage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMailManage))
        Me.XTCMailManage = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSalesInvoiceList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInvoiceList = New DevExpress.XtraGrid.GridControl()
        Me.GVInvoiceList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECheckReceive = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnIdRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_list = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_total_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_start_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_end_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelectAllInvoice = New DevExpress.XtraEditors.CheckEdit()
        Me.BCreatePO = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAlreadyProcessed = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPending = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPHistory = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntilList = New DevExpress.XtraEditors.DateEdit()
        Me.BViewPayment = New DevExpress.XtraEditors.SimpleButton()
        Me.DEFromList = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEStoreDeposit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPUnpaidBill = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_mail_manage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnupdated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnupdated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_mark_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_mark_type_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_mail_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmail_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmail_status_note = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmail_subject = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnto = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCMailManage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCMailManage.SuspendLayout()
        Me.XTPSalesInvoiceList.SuspendLayout()
        CType(Me.GCInvoiceList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoiceList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheckReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.CESelectAllInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPHistory.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStoreDeposit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCMailManage
        '
        Me.XTCMailManage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCMailManage.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCMailManage.Location = New System.Drawing.Point(0, 0)
        Me.XTCMailManage.Name = "XTCMailManage"
        Me.XTCMailManage.SelectedTabPage = Me.XTPSalesInvoiceList
        Me.XTCMailManage.Size = New System.Drawing.Size(927, 443)
        Me.XTCMailManage.TabIndex = 0
        Me.XTCMailManage.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPHistory, Me.XTPSalesInvoiceList, Me.XTPUnpaidBill})
        '
        'XTPSalesInvoiceList
        '
        Me.XTPSalesInvoiceList.Controls.Add(Me.GCInvoiceList)
        Me.XTPSalesInvoiceList.Controls.Add(Me.PanelControl3)
        Me.XTPSalesInvoiceList.Controls.Add(Me.PanelControl1)
        Me.XTPSalesInvoiceList.Name = "XTPSalesInvoiceList"
        Me.XTPSalesInvoiceList.Size = New System.Drawing.Size(921, 415)
        Me.XTPSalesInvoiceList.Text = "Sales Invoice"
        '
        'GCInvoiceList
        '
        Me.GCInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoiceList.Location = New System.Drawing.Point(0, 43)
        Me.GCInvoiceList.MainView = Me.GVInvoiceList
        Me.GCInvoiceList.Name = "GCInvoiceList"
        Me.GCInvoiceList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICECheckReceive, Me.RepositoryItemCheckEdit2})
        Me.GCInvoiceList.Size = New System.Drawing.Size(921, 332)
        Me.GCInvoiceList.TabIndex = 18
        Me.GCInvoiceList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoiceList})
        '
        'GVInvoiceList
        '
        Me.GVInvoiceList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumnIdRec, Me.GridColumnOrderNumber, Me.GridColumnCreatedDate, Me.GridColumnsales_pos_total, Me.GridColumn4, Me.GridColumn19, Me.GridColumn23, Me.GridColumnAmount, Me.GridColumn12, Me.GridColumnVendor, Me.GridColumn10, Me.GridColumn25, Me.GridColumn26, Me.GridColumncomp_group_list, Me.GridColumnid_comp, Me.GridColumnsales_pos_total_qty, Me.GridColumnsales_pos_start_period, Me.GridColumnsales_pos_end_period})
        Me.GVInvoiceList.GridControl = Me.GCInvoiceList
        Me.GVInvoiceList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnAmount, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total_qty", Me.GridColumnsales_pos_total_qty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", Me.GridColumnsales_pos_total, "{0:N2}")})
        Me.GVInvoiceList.Name = "GVInvoiceList"
        Me.GVInvoiceList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVInvoiceList.OptionsFind.AlwaysVisible = True
        Me.GVInvoiceList.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVInvoiceList.OptionsView.ColumnAutoWidth = False
        Me.GVInvoiceList.OptionsView.ShowFooter = True
        Me.GVInvoiceList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "*"
        Me.GridColumn2.ColumnEdit = Me.RICECheckReceive
        Me.GridColumn2.FieldName = "is_check"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'RICECheckReceive
        '
        Me.RICECheckReceive.AutoHeight = False
        Me.RICECheckReceive.Name = "RICECheckReceive"
        Me.RICECheckReceive.ValueChecked = "yes"
        Me.RICECheckReceive.ValueUnchecked = "no"
        '
        'GridColumnIdRec
        '
        Me.GridColumnIdRec.Caption = "ID"
        Me.GridColumnIdRec.FieldName = "id_sales_pos"
        Me.GridColumnIdRec.Name = "GridColumnIdRec"
        Me.GridColumnIdRec.OptionsColumn.AllowEdit = False
        '
        'GridColumnOrderNumber
        '
        Me.GridColumnOrderNumber.Caption = "Number"
        Me.GridColumnOrderNumber.FieldName = "sales_pos_number"
        Me.GridColumnOrderNumber.Name = "GridColumnOrderNumber"
        Me.GridColumnOrderNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnOrderNumber.Visible = True
        Me.GridColumnOrderNumber.VisibleIndex = 1
        Me.GridColumnOrderNumber.Width = 165
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "sales_pos_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.OptionsColumn.AllowEdit = False
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 6
        Me.GridColumnCreatedDate.Width = 92
        '
        'GridColumnsales_pos_total
        '
        Me.GridColumnsales_pos_total.Caption = "Total Sales"
        Me.GridColumnsales_pos_total.DisplayFormat.FormatString = "N2"
        Me.GridColumnsales_pos_total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_total.FieldName = "sales_pos_total"
        Me.GridColumnsales_pos_total.Name = "GridColumnsales_pos_total"
        Me.GridColumnsales_pos_total.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", "{0:N2}")})
        Me.GridColumnsales_pos_total.Visible = True
        Me.GridColumnsales_pos_total.VisibleIndex = 11
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Store Discount (%)"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "sales_pos_discount"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 12
        Me.GridColumn4.Width = 127
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "VAT (%)"
        Me.GridColumn19.DisplayFormat.FormatString = "N2"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "sales_pos_vat"
        Me.GridColumn19.Name = "GridColumn19"
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Potongan"
        Me.GridColumn23.DisplayFormat.FormatString = "N2"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn23.FieldName = "sales_pos_potongan"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 13
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.Caption = "Amount Invoice"
        Me.GridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.AllowEdit = False
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 14
        Me.GridColumnAmount.Width = 111
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Due Date"
        Me.GridColumn12.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn12.FieldName = "sales_pos_due_date"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 9
        Me.GridColumn12.Width = 108
        '
        'GridColumnVendor
        '
        Me.GridColumnVendor.Caption = "Store"
        Me.GridColumnVendor.FieldName = "comp_name"
        Me.GridColumnVendor.Name = "GridColumnVendor"
        Me.GridColumnVendor.OptionsColumn.AllowEdit = False
        Me.GridColumnVendor.Visible = True
        Me.GridColumnVendor.VisibleIndex = 4
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Store Code"
        Me.GridColumn10.FieldName = "comp_number"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 3
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Type"
        Me.GridColumn25.FieldName = "report_mark_type_name"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 2
        Me.GridColumn25.Width = 115
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Id Invoice Type"
        Me.GridColumn26.FieldName = "report_mark_type"
        Me.GridColumn26.Name = "GridColumn26"
        '
        'GridColumncomp_group_list
        '
        Me.GridColumncomp_group_list.Caption = "Group Store"
        Me.GridColumncomp_group_list.FieldName = "comp_group"
        Me.GridColumncomp_group_list.Name = "GridColumncomp_group_list"
        Me.GridColumncomp_group_list.Visible = True
        Me.GridColumncomp_group_list.VisibleIndex = 5
        '
        'GridColumnid_comp
        '
        Me.GridColumnid_comp.Caption = "id_comp"
        Me.GridColumnid_comp.FieldName = "id_comp"
        Me.GridColumnid_comp.Name = "GridColumnid_comp"
        '
        'GridColumnsales_pos_total_qty
        '
        Me.GridColumnsales_pos_total_qty.Caption = "Total Qty"
        Me.GridColumnsales_pos_total_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnsales_pos_total_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_total_qty.FieldName = "sales_pos_total_qty"
        Me.GridColumnsales_pos_total_qty.Name = "GridColumnsales_pos_total_qty"
        Me.GridColumnsales_pos_total_qty.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_total_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total_qty", "{0:N0}")})
        Me.GridColumnsales_pos_total_qty.Visible = True
        Me.GridColumnsales_pos_total_qty.VisibleIndex = 10
        '
        'GridColumnsales_pos_start_period
        '
        Me.GridColumnsales_pos_start_period.Caption = "Start Period"
        Me.GridColumnsales_pos_start_period.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_start_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_start_period.FieldName = "sales_pos_start_period"
        Me.GridColumnsales_pos_start_period.Name = "GridColumnsales_pos_start_period"
        Me.GridColumnsales_pos_start_period.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_start_period.Visible = True
        Me.GridColumnsales_pos_start_period.VisibleIndex = 7
        '
        'GridColumnsales_pos_end_period
        '
        Me.GridColumnsales_pos_end_period.Caption = "End Period"
        Me.GridColumnsales_pos_end_period.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_end_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_end_period.FieldName = "sales_pos_end_period"
        Me.GridColumnsales_pos_end_period.Name = "GridColumnsales_pos_end_period"
        Me.GridColumnsales_pos_end_period.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_end_period.Visible = True
        Me.GridColumnsales_pos_end_period.VisibleIndex = 8
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.PictureChecked = CType(resources.GetObject("RepositoryItemCheckEdit2.PictureChecked"), System.Drawing.Image)
        Me.RepositoryItemCheckEdit2.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "No"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.PanelControl4)
        Me.PanelControl3.Controls.Add(Me.BCreatePO)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 375)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(921, 40)
        Me.PanelControl3.TabIndex = 4
        '
        'PanelControl4
        '
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.CESelectAllInvoice)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl4.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(84, 36)
        Me.PanelControl4.TabIndex = 20
        '
        'CESelectAllInvoice
        '
        Me.CESelectAllInvoice.Location = New System.Drawing.Point(9, 8)
        Me.CESelectAllInvoice.Name = "CESelectAllInvoice"
        Me.CESelectAllInvoice.Properties.Caption = "Select All"
        Me.CESelectAllInvoice.Size = New System.Drawing.Size(66, 19)
        Me.CESelectAllInvoice.TabIndex = 21
        '
        'BCreatePO
        '
        Me.BCreatePO.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BCreatePO.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BCreatePO.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreatePO.Appearance.Options.UseBackColor = True
        Me.BCreatePO.Appearance.Options.UseFont = True
        Me.BCreatePO.Appearance.Options.UseForeColor = True
        Me.BCreatePO.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCreatePO.Location = New System.Drawing.Point(820, 2)
        Me.BCreatePO.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BCreatePO.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BCreatePO.Name = "BCreatePO"
        Me.BCreatePO.Size = New System.Drawing.Size(99, 36)
        Me.BCreatePO.TabIndex = 19
        Me.BCreatePO.Text = "Proceed"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnAlreadyProcessed)
        Me.PanelControl1.Controls.Add(Me.BtnPending)
        Me.PanelControl1.Controls.Add(Me.SLEStoreGroup)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(921, 43)
        Me.PanelControl1.TabIndex = 3
        '
        'BtnAlreadyProcessed
        '
        Me.BtnAlreadyProcessed.Appearance.BackColor = System.Drawing.Color.Teal
        Me.BtnAlreadyProcessed.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnAlreadyProcessed.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnAlreadyProcessed.Appearance.Options.UseBackColor = True
        Me.BtnAlreadyProcessed.Appearance.Options.UseFont = True
        Me.BtnAlreadyProcessed.Appearance.Options.UseForeColor = True
        Me.BtnAlreadyProcessed.Location = New System.Drawing.Point(304, 11)
        Me.BtnAlreadyProcessed.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnAlreadyProcessed.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnAlreadyProcessed.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnAlreadyProcessed.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnAlreadyProcessed.Name = "BtnAlreadyProcessed"
        Me.BtnAlreadyProcessed.Size = New System.Drawing.Size(129, 20)
        Me.BtnAlreadyProcessed.TabIndex = 8925
        Me.BtnAlreadyProcessed.Text = "Already Processed"
        '
        'BtnPending
        '
        Me.BtnPending.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.BtnPending.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnPending.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnPending.Appearance.Options.UseBackColor = True
        Me.BtnPending.Appearance.Options.UseFont = True
        Me.BtnPending.Appearance.Options.UseForeColor = True
        Me.BtnPending.Location = New System.Drawing.Point(226, 11)
        Me.BtnPending.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnPending.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnPending.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnPending.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnPending.Name = "BtnPending"
        Me.BtnPending.Size = New System.Drawing.Size(75, 20)
        Me.BtnPending.TabIndex = 8924
        Me.BtnPending.Text = "Pending"
        '
        'SLEStoreGroup
        '
        Me.SLEStoreGroup.Location = New System.Drawing.Point(78, 11)
        Me.SLEStoreGroup.Name = "SLEStoreGroup"
        Me.SLEStoreGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroup.Properties.View = Me.GridView3
        Me.SLEStoreGroup.Size = New System.Drawing.Size(145, 20)
        Me.SLEStoreGroup.TabIndex = 8923
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumncomp_group, Me.GridColumndescription})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(14, 14)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 8922
        Me.LabelControl3.Text = "Store Group"
        '
        'XTPHistory
        '
        Me.XTPHistory.Controls.Add(Me.GCData)
        Me.XTPHistory.Controls.Add(Me.PanelControl2)
        Me.XTPHistory.Name = "XTPHistory"
        Me.XTPHistory.Size = New System.Drawing.Size(921, 415)
        Me.XTPHistory.Text = "History"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.DEUntilList)
        Me.PanelControl2.Controls.Add(Me.BViewPayment)
        Me.PanelControl2.Controls.Add(Me.DEFromList)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.LabelControl6)
        Me.PanelControl2.Controls.Add(Me.SLEStoreDeposit)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(921, 43)
        Me.PanelControl2.TabIndex = 15
        '
        'DEUntilList
        '
        Me.DEUntilList.EditValue = Nothing
        Me.DEUntilList.Location = New System.Drawing.Point(190, 13)
        Me.DEUntilList.Name = "DEUntilList"
        Me.DEUntilList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilList.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilList.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilList.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilList.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilList.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilList.TabIndex = 8922
        '
        'BViewPayment
        '
        Me.BViewPayment.Location = New System.Drawing.Point(307, 13)
        Me.BViewPayment.Name = "BViewPayment"
        Me.BViewPayment.Size = New System.Drawing.Size(60, 19)
        Me.BViewPayment.TabIndex = 8916
        Me.BViewPayment.Text = "view"
        '
        'DEFromList
        '
        Me.DEFromList.EditValue = Nothing
        Me.DEFromList.Location = New System.Drawing.Point(46, 13)
        Me.DEFromList.Name = "DEFromList"
        Me.DEFromList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromList.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromList.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromList.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromList.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromList.Size = New System.Drawing.Size(111, 20)
        Me.DEFromList.TabIndex = 8921
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(163, 16)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl4.TabIndex = 8920
        Me.LabelControl4.Text = "Until"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(16, 16)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl6.TabIndex = 8919
        Me.LabelControl6.Text = "From"
        '
        'SLEStoreDeposit
        '
        Me.SLEStoreDeposit.Location = New System.Drawing.Point(50, 102)
        Me.SLEStoreDeposit.Name = "SLEStoreDeposit"
        Me.SLEStoreDeposit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreDeposit.Properties.View = Me.GridView1
        Me.SLEStoreDeposit.Size = New System.Drawing.Size(177, 20)
        Me.SLEStoreDeposit.TabIndex = 8918
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn29})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Comp Contact"
        Me.GridColumn1.FieldName = "id_comp_contact"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Vendor"
        Me.GridColumn29.FieldName = "comp_name"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 105)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 8917
        Me.LabelControl1.Text = "Store"
        '
        'XTPUnpaidBill
        '
        Me.XTPUnpaidBill.Name = "XTPUnpaidBill"
        Me.XTPUnpaidBill.Size = New System.Drawing.Size(921, 415)
        Me.XTPUnpaidBill.Text = "Unpaid Sales Invoice"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 43)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(921, 372)
        Me.GCData.TabIndex = 16
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_mail_manage, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumncreated_by_name, Me.GridColumnupdated_date, Me.GridColumnupdated_by_name, Me.GridColumnreport_mark_type, Me.GridColumnreport_mark_type_name, Me.GridColumnid_mail_status, Me.GridColumnmail_status, Me.GridColumnmail_status_note, Me.GridColumnmail_subject, Me.GridColumnto})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupedColumns = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_mail_manage
        '
        Me.GridColumnid_mail_manage.Caption = "id_mail_manage"
        Me.GridColumnid_mail_manage.FieldName = "id_mail_manage"
        Me.GridColumnid_mail_manage.Name = "GridColumnid_mail_manage"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Email Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 4
        '
        'GridColumncreated_by_name
        '
        Me.GridColumncreated_by_name.Caption = "Created By"
        Me.GridColumncreated_by_name.FieldName = "created_by_name"
        Me.GridColumncreated_by_name.Name = "GridColumncreated_by_name"
        Me.GridColumncreated_by_name.Visible = True
        Me.GridColumncreated_by_name.VisibleIndex = 5
        '
        'GridColumnupdated_date
        '
        Me.GridColumnupdated_date.Caption = "Updated Date"
        Me.GridColumnupdated_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnupdated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnupdated_date.FieldName = "updated_date"
        Me.GridColumnupdated_date.Name = "GridColumnupdated_date"
        Me.GridColumnupdated_date.Visible = True
        Me.GridColumnupdated_date.VisibleIndex = 6
        '
        'GridColumnupdated_by_name
        '
        Me.GridColumnupdated_by_name.Caption = "Updated By"
        Me.GridColumnupdated_by_name.FieldName = "updated_by_name"
        Me.GridColumnupdated_by_name.Name = "GridColumnupdated_by_name"
        Me.GridColumnupdated_by_name.Visible = True
        Me.GridColumnupdated_by_name.VisibleIndex = 7
        '
        'GridColumnreport_mark_type
        '
        Me.GridColumnreport_mark_type.Caption = "report_mark_type"
        Me.GridColumnreport_mark_type.FieldName = "report_mark_type"
        Me.GridColumnreport_mark_type.Name = "GridColumnreport_mark_type"
        '
        'GridColumnreport_mark_type_name
        '
        Me.GridColumnreport_mark_type_name.Caption = "Type"
        Me.GridColumnreport_mark_type_name.FieldName = "report_mark_type_name"
        Me.GridColumnreport_mark_type_name.Name = "GridColumnreport_mark_type_name"
        Me.GridColumnreport_mark_type_name.Visible = True
        Me.GridColumnreport_mark_type_name.VisibleIndex = 1
        '
        'GridColumnid_mail_status
        '
        Me.GridColumnid_mail_status.Caption = "id_mail_status"
        Me.GridColumnid_mail_status.FieldName = "id_mail_status"
        Me.GridColumnid_mail_status.Name = "GridColumnid_mail_status"
        '
        'GridColumnmail_status
        '
        Me.GridColumnmail_status.Caption = "Last Status"
        Me.GridColumnmail_status.FieldName = "mail_status"
        Me.GridColumnmail_status.Name = "GridColumnmail_status"
        Me.GridColumnmail_status.Visible = True
        Me.GridColumnmail_status.VisibleIndex = 8
        '
        'GridColumnmail_status_note
        '
        Me.GridColumnmail_status_note.Caption = "Note"
        Me.GridColumnmail_status_note.FieldName = "mail_status_note"
        Me.GridColumnmail_status_note.Name = "GridColumnmail_status_note"
        '
        'GridColumnmail_subject
        '
        Me.GridColumnmail_subject.Caption = "Subject"
        Me.GridColumnmail_subject.FieldName = "mail_subject"
        Me.GridColumnmail_subject.Name = "GridColumnmail_subject"
        Me.GridColumnmail_subject.Visible = True
        Me.GridColumnmail_subject.VisibleIndex = 2
        '
        'GridColumnto
        '
        Me.GridColumnto.Caption = "Destination To"
        Me.GridColumnto.FieldName = "to"
        Me.GridColumnto.Name = "GridColumnto"
        Me.GridColumnto.Visible = True
        Me.GridColumnto.VisibleIndex = 3
        Me.GridColumnto.Width = 155
        '
        'FormMailManage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 443)
        Me.Controls.Add(Me.XTCMailManage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMailManage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mail Management"
        CType(Me.XTCMailManage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCMailManage.ResumeLayout(False)
        Me.XTPSalesInvoiceList.ResumeLayout(False)
        CType(Me.GCInvoiceList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoiceList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheckReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.CESelectAllInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPHistory.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStoreDeposit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCMailManage As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPHistory As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSalesInvoiceList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPUnpaidBill As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEUntilList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BViewPayment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEFromList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStoreDeposit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEStoreGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CESelectAllInvoice As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BCreatePO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCInvoiceList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvoiceList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICECheckReceive As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_list As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_total_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BtnPending As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAlreadyProcessed As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnsales_pos_start_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_end_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_mail_manage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnupdated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnupdated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_mark_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_mark_type_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_mail_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmail_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmail_status_note As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmail_subject As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnto As DevExpress.XtraGrid.Columns.GridColumn
End Class
