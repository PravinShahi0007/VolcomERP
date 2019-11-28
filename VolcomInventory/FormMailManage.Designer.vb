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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMailManage))
        Me.XTCMailManage = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPHistory = New DevExpress.XtraTab.XtraTabPage()
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
        Me.XTPSalesInvoiceList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInvoiceList = New DevExpress.XtraGrid.GridControl()
        Me.CMSSalesInvoice = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.PanelControl8 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPendingGroup = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAlreadyProcessed = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPending = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPUnpaidBill = New DevExpress.XtraTab.XtraTabPage()
        Me.GCUnpaid = New DevExpress.XtraGrid.GridControl()
        Me.GVUnpaid = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnLastNumberEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCreatedDateEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnStatusEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnLastNumberEW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCreatedDateEW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnStatusEW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumndue_days = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumntotal_rec = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumntotaldue = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelectAllUnpaidInvoice = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnProceedEmailWarning = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnProceedEmailNotice = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnOverdue = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnMinThreeOverdue = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl9 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPendingMailUnpaidGroupStore = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEStoreGroupUnpaid = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCMailManage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCMailManage.SuspendLayout()
        Me.XTPHistory.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStoreDeposit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSalesInvoiceList.SuspendLayout()
        CType(Me.GCInvoiceList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSSalesInvoice.SuspendLayout()
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
        CType(Me.PanelControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl8.SuspendLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPUnpaidBill.SuspendLayout()
        CType(Me.GCUnpaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUnpaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl6.SuspendLayout()
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl7.SuspendLayout()
        CType(Me.CESelectAllUnpaidInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.PanelControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl9.SuspendLayout()
        CType(Me.SLEStoreGroupUnpaid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCMailManage
        '
        Me.XTCMailManage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCMailManage.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCMailManage.Location = New System.Drawing.Point(0, 0)
        Me.XTCMailManage.Name = "XTCMailManage"
        Me.XTCMailManage.SelectedTabPage = Me.XTPHistory
        Me.XTCMailManage.Size = New System.Drawing.Size(927, 443)
        Me.XTCMailManage.TabIndex = 0
        Me.XTCMailManage.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPHistory, Me.XTPSalesInvoiceList, Me.XTPUnpaidBill})
        '
        'XTPHistory
        '
        Me.XTPHistory.Controls.Add(Me.GCData)
        Me.XTPHistory.Controls.Add(Me.PanelControl2)
        Me.XTPHistory.Name = "XTPHistory"
        Me.XTPHistory.Size = New System.Drawing.Size(921, 415)
        Me.XTPHistory.Text = "History"
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
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
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
        Me.GridColumnupdated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
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
        Me.GCInvoiceList.ContextMenuStrip = Me.CMSSalesInvoice
        Me.GCInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoiceList.Location = New System.Drawing.Point(0, 43)
        Me.GCInvoiceList.MainView = Me.GVInvoiceList
        Me.GCInvoiceList.Name = "GCInvoiceList"
        Me.GCInvoiceList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICECheckReceive, Me.RepositoryItemCheckEdit2})
        Me.GCInvoiceList.Size = New System.Drawing.Size(921, 332)
        Me.GCInvoiceList.TabIndex = 18
        Me.GCInvoiceList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoiceList})
        '
        'CMSSalesInvoice
        '
        Me.CMSSalesInvoice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailToolStripMenuItem})
        Me.CMSSalesInvoice.Name = "CMSSalesInvoice"
        Me.CMSSalesInvoice.Size = New System.Drawing.Size(131, 26)
        '
        'ViewDetailToolStripMenuItem
        '
        Me.ViewDetailToolStripMenuItem.Name = "ViewDetailToolStripMenuItem"
        Me.ViewDetailToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ViewDetailToolStripMenuItem.Text = "view detail"
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
        Me.PanelControl1.Controls.Add(Me.PanelControl8)
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
        'PanelControl8
        '
        Me.PanelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl8.Controls.Add(Me.BtnPendingGroup)
        Me.PanelControl8.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl8.Location = New System.Drawing.Point(709, 2)
        Me.PanelControl8.Name = "PanelControl8"
        Me.PanelControl8.Size = New System.Drawing.Size(210, 39)
        Me.PanelControl8.TabIndex = 8930
        '
        'BtnPendingGroup
        '
        Me.BtnPendingGroup.Appearance.BackColor = System.Drawing.Color.OrangeRed
        Me.BtnPendingGroup.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnPendingGroup.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnPendingGroup.Appearance.Options.UseBackColor = True
        Me.BtnPendingGroup.Appearance.Options.UseFont = True
        Me.BtnPendingGroup.Appearance.Options.UseForeColor = True
        Me.BtnPendingGroup.Location = New System.Drawing.Point(8, 9)
        Me.BtnPendingGroup.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnPendingGroup.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnPendingGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnPendingGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnPendingGroup.Name = "BtnPendingGroup"
        Me.BtnPendingGroup.Size = New System.Drawing.Size(195, 20)
        Me.BtnPendingGroup.TabIndex = 8926
        Me.BtnPendingGroup.Text = "Pending Mail (By Group Store)"
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
        'XTPUnpaidBill
        '
        Me.XTPUnpaidBill.Controls.Add(Me.GCUnpaid)
        Me.XTPUnpaidBill.Controls.Add(Me.PanelControl6)
        Me.XTPUnpaidBill.Controls.Add(Me.PanelControl5)
        Me.XTPUnpaidBill.Name = "XTPUnpaidBill"
        Me.XTPUnpaidBill.Size = New System.Drawing.Size(921, 415)
        Me.XTPUnpaidBill.Text = "Unpaid Sales Invoice"
        '
        'GCUnpaid
        '
        Me.GCUnpaid.ContextMenuStrip = Me.CMSSalesInvoice
        Me.GCUnpaid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCUnpaid.Location = New System.Drawing.Point(0, 43)
        Me.GCUnpaid.MainView = Me.GVUnpaid
        Me.GCUnpaid.Name = "GCUnpaid"
        Me.GCUnpaid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit3})
        Me.GCUnpaid.Size = New System.Drawing.Size(921, 332)
        Me.GCUnpaid.TabIndex = 19
        Me.GCUnpaid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUnpaid})
        '
        'GVUnpaid
        '
        Me.GVUnpaid.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.GridBand1})
        Me.GVUnpaid.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn11, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn24, Me.GridColumn27, Me.GridColumn28, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumntotal_rec, Me.GridColumntotaldue, Me.GridColumndue_days, Me.GridColumn33, Me.BandedGridColumnLastNumberEN, Me.BandedGridColumnCreatedDateEN, Me.BandedGridColumnStatusEN, Me.BandedGridColumnLastNumberEW, Me.BandedGridColumnCreatedDateEW, Me.BandedGridColumnStatusEW})
        Me.GVUnpaid.GridControl = Me.GCUnpaid
        Me.GVUnpaid.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumn17, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total_qty", Me.GridColumn30, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", Me.GridColumn13, "{0:N2}")})
        Me.GVUnpaid.Name = "GVUnpaid"
        Me.GVUnpaid.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVUnpaid.OptionsFind.AlwaysVisible = True
        Me.GVUnpaid.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVUnpaid.OptionsView.ColumnAutoWidth = False
        Me.GVUnpaid.OptionsView.ShowFooter = True
        Me.GVUnpaid.OptionsView.ShowGroupPanel = False
        '
        'gridBand2
        '
        Me.gridBand2.Columns.Add(Me.GridColumn7)
        Me.gridBand2.Columns.Add(Me.GridColumn9)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 0
        Me.gridBand2.Width = 240
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.Caption = "*"
        Me.GridColumn7.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn7.FieldName = "is_check"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Number"
        Me.GridColumn9.FieldName = "sales_pos_number"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.Width = 165
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Email Pemberitahuan"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnLastNumberEN)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnCreatedDateEN)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnStatusEN)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 1
        Me.gridBand3.Width = 225
        '
        'BandedGridColumnLastNumberEN
        '
        Me.BandedGridColumnLastNumberEN.Caption = "Last Number"
        Me.BandedGridColumnLastNumberEN.FieldName = "mail_notice_no"
        Me.BandedGridColumnLastNumberEN.Name = "BandedGridColumnLastNumberEN"
        Me.BandedGridColumnLastNumberEN.Visible = True
        '
        'BandedGridColumnCreatedDateEN
        '
        Me.BandedGridColumnCreatedDateEN.Caption = "Date"
        Me.BandedGridColumnCreatedDateEN.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.BandedGridColumnCreatedDateEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnCreatedDateEN.FieldName = "mail_notice_date"
        Me.BandedGridColumnCreatedDateEN.Name = "BandedGridColumnCreatedDateEN"
        Me.BandedGridColumnCreatedDateEN.Visible = True
        '
        'BandedGridColumnStatusEN
        '
        Me.BandedGridColumnStatusEN.Caption = "Status"
        Me.BandedGridColumnStatusEN.FieldName = "mail_notice_status"
        Me.BandedGridColumnStatusEN.Name = "BandedGridColumnStatusEN"
        Me.BandedGridColumnStatusEN.Visible = True
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "Email Peringatan"
        Me.gridBand4.Columns.Add(Me.BandedGridColumnLastNumberEW)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnCreatedDateEW)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnStatusEW)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 2
        Me.gridBand4.Width = 302
        '
        'BandedGridColumnLastNumberEW
        '
        Me.BandedGridColumnLastNumberEW.Caption = "Last Number"
        Me.BandedGridColumnLastNumberEW.FieldName = "mail_warning_no"
        Me.BandedGridColumnLastNumberEW.Name = "BandedGridColumnLastNumberEW"
        Me.BandedGridColumnLastNumberEW.Visible = True
        Me.BandedGridColumnLastNumberEW.Width = 115
        '
        'BandedGridColumnCreatedDateEW
        '
        Me.BandedGridColumnCreatedDateEW.Caption = "Date"
        Me.BandedGridColumnCreatedDateEW.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.BandedGridColumnCreatedDateEW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnCreatedDateEW.FieldName = "mail_warning_date"
        Me.BandedGridColumnCreatedDateEW.Name = "BandedGridColumnCreatedDateEW"
        Me.BandedGridColumnCreatedDateEW.Visible = True
        Me.BandedGridColumnCreatedDateEW.Width = 112
        '
        'BandedGridColumnStatusEW
        '
        Me.BandedGridColumnStatusEW.Caption = "Status"
        Me.BandedGridColumnStatusEW.FieldName = "mail_warning_status"
        Me.BandedGridColumnStatusEW.Name = "BandedGridColumnStatusEW"
        Me.BandedGridColumnStatusEW.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Detail Invoice"
        Me.GridBand1.Columns.Add(Me.GridColumn8)
        Me.GridBand1.Columns.Add(Me.GridColumn13)
        Me.GridBand1.Columns.Add(Me.GridColumn14)
        Me.GridBand1.Columns.Add(Me.GridColumn15)
        Me.GridBand1.Columns.Add(Me.GridColumn16)
        Me.GridBand1.Columns.Add(Me.GridColumn21)
        Me.GridBand1.Columns.Add(Me.GridColumn20)
        Me.GridBand1.Columns.Add(Me.GridColumn27)
        Me.GridBand1.Columns.Add(Me.GridColumn22)
        Me.GridBand1.Columns.Add(Me.GridColumn11)
        Me.GridBand1.Columns.Add(Me.GridColumn31)
        Me.GridBand1.Columns.Add(Me.GridColumn32)
        Me.GridBand1.Columns.Add(Me.GridColumn18)
        Me.GridBand1.Columns.Add(Me.GridColumndue_days)
        Me.GridBand1.Columns.Add(Me.GridColumn33)
        Me.GridBand1.Columns.Add(Me.GridColumn17)
        Me.GridBand1.Columns.Add(Me.GridColumn24)
        Me.GridBand1.Columns.Add(Me.GridColumn28)
        Me.GridBand1.Columns.Add(Me.GridColumn30)
        Me.GridBand1.Columns.Add(Me.GridColumntotal_rec)
        Me.GridBand1.Columns.Add(Me.GridColumntotaldue)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 3
        Me.GridBand1.Width = 1067
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID"
        Me.GridColumn8.FieldName = "id_sales_pos"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Total Sales"
        Me.GridColumn13.DisplayFormat.FormatString = "N2"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "sales_pos_total"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", "{0:N2}")})
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Store Discount (%)"
        Me.GridColumn14.DisplayFormat.FormatString = "N2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "sales_pos_discount"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Width = 127
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "VAT (%)"
        Me.GridColumn15.DisplayFormat.FormatString = "N2"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "sales_pos_vat"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Potongan"
        Me.GridColumn16.DisplayFormat.FormatString = "N2"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "sales_pos_potongan"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Store Code"
        Me.GridColumn21.FieldName = "comp_number"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Store"
        Me.GridColumn20.FieldName = "comp_name"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.Visible = True
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Group Store"
        Me.GridColumn27.FieldName = "comp_group"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Type"
        Me.GridColumn22.FieldName = "report_mark_type_name"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.Width = 115
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Created Date"
        Me.GridColumn11.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn11.FieldName = "sales_pos_date"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.Width = 92
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Start Period"
        Me.GridColumn31.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn31.FieldName = "sales_pos_start_period"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.Visible = True
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "End Period"
        Me.GridColumn32.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn32.FieldName = "sales_pos_end_period"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.Visible = True
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Due Date"
        Me.GridColumn18.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn18.FieldName = "sales_pos_due_date"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.Visible = True
        Me.GridColumn18.Width = 108
        '
        'GridColumndue_days
        '
        Me.GridColumndue_days.Caption = "Due Days Origin"
        Me.GridColumndue_days.FieldName = "due_days"
        Me.GridColumndue_days.Name = "GridColumndue_days"
        Me.GridColumndue_days.Width = 98
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Due Days"
        Me.GridColumn33.FieldName = "due_days_view"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.UnboundExpression = "Iif([due_days] = 0, [due_days], Iif([due_days] < 0, [due_days], Concat('+', [due_" &
    "days])))"
        Me.GridColumn33.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumn33.Visible = True
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.Caption = "Amount Invoice"
        Me.GridColumn17.DisplayFormat.FormatString = "N2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "amount"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.Width = 111
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Id Invoice Type"
        Me.GridColumn24.FieldName = "report_mark_type"
        Me.GridColumn24.Name = "GridColumn24"
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "id_comp"
        Me.GridColumn28.FieldName = "id_comp"
        Me.GridColumn28.Name = "GridColumn28"
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Total Qty"
        Me.GridColumn30.DisplayFormat.FormatString = "N0"
        Me.GridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn30.FieldName = "sales_pos_total_qty"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.AllowEdit = False
        Me.GridColumn30.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total_qty", "{0:N0}")})
        '
        'GridColumntotal_rec
        '
        Me.GridColumntotal_rec.Caption = "Amount Received"
        Me.GridColumntotal_rec.DisplayFormat.FormatString = "N2"
        Me.GridColumntotal_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_rec.FieldName = "total_rec"
        Me.GridColumntotal_rec.Name = "GridColumntotal_rec"
        Me.GridColumntotal_rec.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", "{0:N2}")})
        Me.GridColumntotal_rec.Visible = True
        Me.GridColumntotal_rec.Width = 116
        '
        'GridColumntotaldue
        '
        Me.GridColumntotaldue.Caption = "Balance"
        Me.GridColumntotaldue.DisplayFormat.FormatString = "N2"
        Me.GridColumntotaldue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotaldue.FieldName = "total_due"
        Me.GridColumntotaldue.Name = "GridColumntotaldue"
        Me.GridColumntotaldue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_due", "{0:N2}")})
        Me.GridColumntotaldue.Visible = True
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        Me.RepositoryItemCheckEdit3.PictureChecked = CType(resources.GetObject("RepositoryItemCheckEdit3.PictureChecked"), System.Drawing.Image)
        Me.RepositoryItemCheckEdit3.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit3.ValueUnchecked = "No"
        '
        'PanelControl6
        '
        Me.PanelControl6.Controls.Add(Me.PanelControl7)
        Me.PanelControl6.Controls.Add(Me.BtnProceedEmailWarning)
        Me.PanelControl6.Controls.Add(Me.BtnProceedEmailNotice)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl6.Location = New System.Drawing.Point(0, 375)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(921, 40)
        Me.PanelControl6.TabIndex = 5
        '
        'PanelControl7
        '
        Me.PanelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl7.Controls.Add(Me.CESelectAllUnpaidInvoice)
        Me.PanelControl7.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl7.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl7.Name = "PanelControl7"
        Me.PanelControl7.Size = New System.Drawing.Size(84, 36)
        Me.PanelControl7.TabIndex = 20
        '
        'CESelectAllUnpaidInvoice
        '
        Me.CESelectAllUnpaidInvoice.Location = New System.Drawing.Point(9, 8)
        Me.CESelectAllUnpaidInvoice.Name = "CESelectAllUnpaidInvoice"
        Me.CESelectAllUnpaidInvoice.Properties.Caption = "Select All"
        Me.CESelectAllUnpaidInvoice.Size = New System.Drawing.Size(66, 19)
        Me.CESelectAllUnpaidInvoice.TabIndex = 21
        '
        'BtnProceedEmailWarning
        '
        Me.BtnProceedEmailWarning.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BtnProceedEmailWarning.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnProceedEmailWarning.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnProceedEmailWarning.Appearance.Options.UseBackColor = True
        Me.BtnProceedEmailWarning.Appearance.Options.UseFont = True
        Me.BtnProceedEmailWarning.Appearance.Options.UseForeColor = True
        Me.BtnProceedEmailWarning.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnProceedEmailWarning.Location = New System.Drawing.Point(571, 2)
        Me.BtnProceedEmailWarning.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnProceedEmailWarning.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnProceedEmailWarning.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnProceedEmailWarning.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnProceedEmailWarning.Name = "BtnProceedEmailWarning"
        Me.BtnProceedEmailWarning.Size = New System.Drawing.Size(174, 36)
        Me.BtnProceedEmailWarning.TabIndex = 19
        Me.BtnProceedEmailWarning.Text = "Proses Email Peringatan"
        Me.BtnProceedEmailWarning.Visible = False
        '
        'BtnProceedEmailNotice
        '
        Me.BtnProceedEmailNotice.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BtnProceedEmailNotice.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnProceedEmailNotice.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnProceedEmailNotice.Appearance.Options.UseBackColor = True
        Me.BtnProceedEmailNotice.Appearance.Options.UseFont = True
        Me.BtnProceedEmailNotice.Appearance.Options.UseForeColor = True
        Me.BtnProceedEmailNotice.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnProceedEmailNotice.Location = New System.Drawing.Point(745, 2)
        Me.BtnProceedEmailNotice.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnProceedEmailNotice.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnProceedEmailNotice.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnProceedEmailNotice.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnProceedEmailNotice.Name = "BtnProceedEmailNotice"
        Me.BtnProceedEmailNotice.Size = New System.Drawing.Size(174, 36)
        Me.BtnProceedEmailNotice.TabIndex = 21
        Me.BtnProceedEmailNotice.Text = "Proses Email Pemberitahuan"
        Me.BtnProceedEmailNotice.Visible = False
        '
        'PanelControl5
        '
        Me.PanelControl5.Controls.Add(Me.BtnOverdue)
        Me.PanelControl5.Controls.Add(Me.BtnMinThreeOverdue)
        Me.PanelControl5.Controls.Add(Me.PanelControl9)
        Me.PanelControl5.Controls.Add(Me.SLEStoreGroupUnpaid)
        Me.PanelControl5.Controls.Add(Me.LabelControl2)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl5.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(921, 43)
        Me.PanelControl5.TabIndex = 4
        '
        'BtnOverdue
        '
        Me.BtnOverdue.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.BtnOverdue.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnOverdue.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnOverdue.Appearance.Options.UseBackColor = True
        Me.BtnOverdue.Appearance.Options.UseFont = True
        Me.BtnOverdue.Appearance.Options.UseForeColor = True
        Me.BtnOverdue.Location = New System.Drawing.Point(330, 11)
        Me.BtnOverdue.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnOverdue.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnOverdue.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnOverdue.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnOverdue.Name = "BtnOverdue"
        Me.BtnOverdue.Size = New System.Drawing.Size(93, 20)
        Me.BtnOverdue.TabIndex = 8933
        Me.BtnOverdue.Text = "Overdue"
        '
        'BtnMinThreeOverdue
        '
        Me.BtnMinThreeOverdue.Appearance.BackColor = System.Drawing.Color.Orange
        Me.BtnMinThreeOverdue.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnMinThreeOverdue.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnMinThreeOverdue.Appearance.Options.UseBackColor = True
        Me.BtnMinThreeOverdue.Appearance.Options.UseFont = True
        Me.BtnMinThreeOverdue.Appearance.Options.UseForeColor = True
        Me.BtnMinThreeOverdue.Location = New System.Drawing.Point(229, 11)
        Me.BtnMinThreeOverdue.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnMinThreeOverdue.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnMinThreeOverdue.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnMinThreeOverdue.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnMinThreeOverdue.Name = "BtnMinThreeOverdue"
        Me.BtnMinThreeOverdue.Size = New System.Drawing.Size(98, 20)
        Me.BtnMinThreeOverdue.TabIndex = 8932
        Me.BtnMinThreeOverdue.Text = "(H-3) Overdue"
        '
        'PanelControl9
        '
        Me.PanelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl9.Controls.Add(Me.BtnPendingMailUnpaidGroupStore)
        Me.PanelControl9.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl9.Location = New System.Drawing.Point(738, 2)
        Me.PanelControl9.Name = "PanelControl9"
        Me.PanelControl9.Size = New System.Drawing.Size(181, 39)
        Me.PanelControl9.TabIndex = 8929
        '
        'BtnPendingMailUnpaidGroupStore
        '
        Me.BtnPendingMailUnpaidGroupStore.Appearance.BackColor = System.Drawing.Color.OrangeRed
        Me.BtnPendingMailUnpaidGroupStore.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnPendingMailUnpaidGroupStore.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnPendingMailUnpaidGroupStore.Appearance.Options.UseBackColor = True
        Me.BtnPendingMailUnpaidGroupStore.Appearance.Options.UseFont = True
        Me.BtnPendingMailUnpaidGroupStore.Appearance.Options.UseForeColor = True
        Me.BtnPendingMailUnpaidGroupStore.Location = New System.Drawing.Point(7, 9)
        Me.BtnPendingMailUnpaidGroupStore.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnPendingMailUnpaidGroupStore.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnPendingMailUnpaidGroupStore.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnPendingMailUnpaidGroupStore.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnPendingMailUnpaidGroupStore.Name = "BtnPendingMailUnpaidGroupStore"
        Me.BtnPendingMailUnpaidGroupStore.Size = New System.Drawing.Size(167, 20)
        Me.BtnPendingMailUnpaidGroupStore.TabIndex = 8928
        Me.BtnPendingMailUnpaidGroupStore.Text = "Ovedue (By Group Store)"
        '
        'SLEStoreGroupUnpaid
        '
        Me.SLEStoreGroupUnpaid.Location = New System.Drawing.Point(78, 11)
        Me.SLEStoreGroupUnpaid.Name = "SLEStoreGroupUnpaid"
        Me.SLEStoreGroupUnpaid.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroupUnpaid.Properties.View = Me.GridView2
        Me.SLEStoreGroupUnpaid.Size = New System.Drawing.Size(145, 20)
        Me.SLEStoreGroupUnpaid.TabIndex = 8923
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn5, Me.GridColumn6})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "id_comp_group"
        Me.GridColumn3.FieldName = "id_comp_group"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Group"
        Me.GridColumn5.FieldName = "comp_group"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Description"
        Me.GridColumn6.FieldName = "description"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(14, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl2.TabIndex = 8922
        Me.LabelControl2.Text = "Store Group"
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
        Me.XTPHistory.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStoreDeposit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSalesInvoiceList.ResumeLayout(False)
        CType(Me.GCInvoiceList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSSalesInvoice.ResumeLayout(False)
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
        CType(Me.PanelControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl8.ResumeLayout(False)
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPUnpaidBill.ResumeLayout(False)
        CType(Me.GCUnpaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUnpaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl6.ResumeLayout(False)
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl7.ResumeLayout(False)
        CType(Me.CESelectAllUnpaidInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.PanelControl9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl9.ResumeLayout(False)
        CType(Me.SLEStoreGroupUnpaid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CMSSalesInvoice As ContextMenuStrip
    Friend WithEvents ViewDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnPendingGroup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEStoreGroupUnpaid As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl7 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CESelectAllUnpaidInvoice As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnProceedEmailWarning As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCUnpaid As DevExpress.XtraGrid.GridControl
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BtnPendingMailUnpaidGroupStore As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl9 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl8 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnOverdue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnMinThreeOverdue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GVUnpaid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnLastNumberEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCreatedDateEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnStatusEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnLastNumberEW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCreatedDateEW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnStatusEW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumndue_days As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumntotal_rec As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumntotaldue As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BtnProceedEmailNotice As DevExpress.XtraEditors.SimpleButton
End Class
