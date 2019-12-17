<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAREvaluation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAREvaluation))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewData = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBrowseEval = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPInvoiceDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInvoiceDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVInvoiceDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_store = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_inv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumninv_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkInvoice = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumninv_rmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumninv_amount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpaid_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrelease_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnactive_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbtn_bbm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoBtnBBM = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.XTPGroupStore = New DevExpress.XtraTab.XtraTabPage()
        Me.GCGroup = New DevExpress.XtraGrid.GridControl()
        Me.GVGroup = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumninv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumnpaid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndiff = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.BtnBrowseEval.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPInvoiceDetail.SuspendLayout()
        CType(Me.GCInvoiceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoiceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoBtnBBM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPGroupStore.SuspendLayout()
        CType(Me.GCGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnViewData)
        Me.PanelControl1.Controls.Add(Me.BtnBrowseEval)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(798, 50)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnViewData
        '
        Me.BtnViewData.Image = CType(resources.GetObject("BtnViewData.Image"), System.Drawing.Image)
        Me.BtnViewData.Location = New System.Drawing.Point(347, 13)
        Me.BtnViewData.Name = "BtnViewData"
        Me.BtnViewData.Size = New System.Drawing.Size(91, 23)
        Me.BtnViewData.TabIndex = 2
        Me.BtnViewData.Text = "View Data"
        '
        'BtnBrowseEval
        '
        Me.BtnBrowseEval.Location = New System.Drawing.Point(96, 15)
        Me.BtnBrowseEval.Name = "BtnBrowseEval"
        Me.BtnBrowseEval.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BtnBrowseEval.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.BtnBrowseEval.Size = New System.Drawing.Size(245, 20)
        Me.BtnBrowseEval.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Evaluation Date"
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 50)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPInvoiceDetail
        Me.XTCData.Size = New System.Drawing.Size(798, 414)
        Me.XTCData.TabIndex = 1
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPInvoiceDetail, Me.XTPGroupStore})
        '
        'XTPInvoiceDetail
        '
        Me.XTPInvoiceDetail.Controls.Add(Me.GCInvoiceDetail)
        Me.XTPInvoiceDetail.Name = "XTPInvoiceDetail"
        Me.XTPInvoiceDetail.Size = New System.Drawing.Size(792, 386)
        Me.XTPInvoiceDetail.Text = "Invoice Detail"
        '
        'GCInvoiceDetail
        '
        Me.GCInvoiceDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoiceDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCInvoiceDetail.MainView = Me.GVInvoiceDetail
        Me.GCInvoiceDetail.Name = "GCInvoiceDetail"
        Me.GCInvoiceDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoBtnBBM, Me.RepoLinkInvoice})
        Me.GCInvoiceDetail.Size = New System.Drawing.Size(792, 386)
        Me.GCInvoiceDetail.TabIndex = 0
        Me.GCInvoiceDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoiceDetail})
        '
        'GVInvoiceDetail
        '
        Me.GVInvoiceDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumngroup_store, Me.GridColumnid_inv, Me.GridColumninv_number, Me.GridColumninv_rmt, Me.GridColumninv_amount, Me.GridColumnpaid_status, Me.GridColumnrelease_date, Me.GridColumnote, Me.GridColumnactive_status, Me.GridColumnbtn_bbm})
        Me.GVInvoiceDetail.GridControl = Me.GCInvoiceDetail
        Me.GVInvoiceDetail.GroupCount = 1
        Me.GVInvoiceDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "inv_amount", Me.GridColumninv_amount, "{0:N2}")})
        Me.GVInvoiceDetail.Name = "GVInvoiceDetail"
        Me.GVInvoiceDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVInvoiceDetail.OptionsView.ColumnAutoWidth = False
        Me.GVInvoiceDetail.OptionsView.ShowFooter = True
        Me.GVInvoiceDetail.OptionsView.ShowGroupedColumns = True
        Me.GVInvoiceDetail.OptionsView.ShowGroupPanel = False
        Me.GVInvoiceDetail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumngroup_store, DevExpress.Data.ColumnSortOrder.Ascending)})
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
        Me.GridColumngroup_store.Caption = "Group Store"
        Me.GridColumngroup_store.FieldName = "group_store"
        Me.GridColumngroup_store.Name = "GridColumngroup_store"
        Me.GridColumngroup_store.OptionsColumn.AllowEdit = False
        Me.GridColumngroup_store.Visible = True
        Me.GridColumngroup_store.VisibleIndex = 0
        '
        'GridColumnid_inv
        '
        Me.GridColumnid_inv.Caption = "id_inv"
        Me.GridColumnid_inv.FieldName = "id_inv"
        Me.GridColumnid_inv.Name = "GridColumnid_inv"
        Me.GridColumnid_inv.OptionsColumn.AllowEdit = False
        '
        'GridColumninv_number
        '
        Me.GridColumninv_number.Caption = "Invoice No"
        Me.GridColumninv_number.ColumnEdit = Me.RepoLinkInvoice
        Me.GridColumninv_number.FieldName = "inv_number"
        Me.GridColumninv_number.Name = "GridColumninv_number"
        Me.GridColumninv_number.OptionsColumn.ReadOnly = True
        Me.GridColumninv_number.Visible = True
        Me.GridColumninv_number.VisibleIndex = 1
        '
        'RepoLinkInvoice
        '
        Me.RepoLinkInvoice.AutoHeight = False
        Me.RepoLinkInvoice.Name = "RepoLinkInvoice"
        '
        'GridColumninv_rmt
        '
        Me.GridColumninv_rmt.Caption = "inv_rmt"
        Me.GridColumninv_rmt.FieldName = "inv_rmt"
        Me.GridColumninv_rmt.Name = "GridColumninv_rmt"
        Me.GridColumninv_rmt.OptionsColumn.AllowEdit = False
        '
        'GridColumninv_amount
        '
        Me.GridColumninv_amount.Caption = "Invoice Amount"
        Me.GridColumninv_amount.DisplayFormat.FormatString = "N2"
        Me.GridColumninv_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumninv_amount.FieldName = "inv_amount"
        Me.GridColumninv_amount.Name = "GridColumninv_amount"
        Me.GridColumninv_amount.OptionsColumn.AllowEdit = False
        Me.GridColumninv_amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "inv_amount", "{0:N2}")})
        Me.GridColumninv_amount.Visible = True
        Me.GridColumninv_amount.VisibleIndex = 2
        '
        'GridColumnpaid_status
        '
        Me.GridColumnpaid_status.Caption = "Paid Status"
        Me.GridColumnpaid_status.FieldName = "paid_status"
        Me.GridColumnpaid_status.Name = "GridColumnpaid_status"
        Me.GridColumnpaid_status.OptionsColumn.AllowEdit = False
        Me.GridColumnpaid_status.Visible = True
        Me.GridColumnpaid_status.VisibleIndex = 3
        '
        'GridColumnrelease_date
        '
        Me.GridColumnrelease_date.Caption = "Release Date"
        Me.GridColumnrelease_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnrelease_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnrelease_date.FieldName = "release_date"
        Me.GridColumnrelease_date.Name = "GridColumnrelease_date"
        Me.GridColumnrelease_date.OptionsColumn.AllowEdit = False
        Me.GridColumnrelease_date.Visible = True
        Me.GridColumnrelease_date.VisibleIndex = 5
        '
        'GridColumnote
        '
        Me.GridColumnote.Caption = "Note"
        Me.GridColumnote.FieldName = "note"
        Me.GridColumnote.Name = "GridColumnote"
        Me.GridColumnote.OptionsColumn.AllowEdit = False
        Me.GridColumnote.Visible = True
        Me.GridColumnote.VisibleIndex = 6
        '
        'GridColumnactive_status
        '
        Me.GridColumnactive_status.Caption = "Status"
        Me.GridColumnactive_status.FieldName = "active_status"
        Me.GridColumnactive_status.Name = "GridColumnactive_status"
        Me.GridColumnactive_status.OptionsColumn.AllowEdit = False
        Me.GridColumnactive_status.Visible = True
        Me.GridColumnactive_status.VisibleIndex = 7
        '
        'GridColumnbtn_bbm
        '
        Me.GridColumnbtn_bbm.Caption = "Payment"
        Me.GridColumnbtn_bbm.ColumnEdit = Me.RepoBtnBBM
        Me.GridColumnbtn_bbm.FieldName = "btn_bbm"
        Me.GridColumnbtn_bbm.Name = "GridColumnbtn_bbm"
        Me.GridColumnbtn_bbm.Visible = True
        Me.GridColumnbtn_bbm.VisibleIndex = 4
        '
        'RepoBtnBBM
        '
        Me.RepoBtnBBM.AutoHeight = False
        SerializableAppearanceObject1.BackColor = System.Drawing.Color.Teal
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject1.Options.UseBackColor = True
        SerializableAppearanceObject1.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseForeColor = True
        Me.RepoBtnBBM.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "View BBM", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.RepoBtnBBM.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.RepoBtnBBM.Name = "RepoBtnBBM"
        Me.RepoBtnBBM.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'XTPGroupStore
        '
        Me.XTPGroupStore.Controls.Add(Me.GCGroup)
        Me.XTPGroupStore.Name = "XTPGroupStore"
        Me.XTPGroupStore.Size = New System.Drawing.Size(792, 386)
        Me.XTPGroupStore.Text = "Group Store"
        '
        'GCGroup
        '
        Me.GCGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCGroup.Location = New System.Drawing.Point(0, 0)
        Me.GCGroup.MainView = Me.GVGroup
        Me.GCGroup.Name = "GCGroup"
        Me.GCGroup.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.GCGroup.Size = New System.Drawing.Size(792, 386)
        Me.GCGroup.TabIndex = 1
        Me.GCGroup.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVGroup})
        '
        'GVGroup
        '
        Me.GVGroup.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumninv, Me.GridColumnpaid, Me.GridColumndiff})
        Me.GVGroup.GridControl = Me.GCGroup
        Me.GVGroup.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "inv", Me.GridColumninv, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "paid", Me.GridColumnpaid, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff", Me.GridColumndiff, "{0:N0}")})
        Me.GVGroup.Name = "GVGroup"
        Me.GVGroup.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVGroup.OptionsView.ColumnAutoWidth = False
        Me.GVGroup.OptionsView.ShowFooter = True
        Me.GVGroup.OptionsView.ShowGroupedColumns = True
        Me.GVGroup.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_comp_group"
        Me.GridColumn1.FieldName = "id_comp_group"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Group Store"
        Me.GridColumn2.FieldName = "group_store"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumninv
        '
        Me.GridColumninv.Caption = "Invoice Overdue"
        Me.GridColumninv.DisplayFormat.FormatString = "N0"
        Me.GridColumninv.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumninv.FieldName = "inv"
        Me.GridColumninv.Name = "GridColumninv"
        Me.GridColumninv.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "inv", "{0:N0}")})
        Me.GridColumninv.Visible = True
        Me.GridColumninv.VisibleIndex = 1
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        SerializableAppearanceObject2.BackColor = System.Drawing.Color.Teal
        SerializableAppearanceObject2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject2.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject2.Options.UseBackColor = True
        SerializableAppearanceObject2.Options.UseFont = True
        SerializableAppearanceObject2.Options.UseForeColor = True
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "BBM", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'GridColumnpaid
        '
        Me.GridColumnpaid.Caption = "Paid"
        Me.GridColumnpaid.DisplayFormat.FormatString = "N0"
        Me.GridColumnpaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpaid.FieldName = "paid"
        Me.GridColumnpaid.Name = "GridColumnpaid"
        Me.GridColumnpaid.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "paid", "{0:N0}")})
        Me.GridColumnpaid.Visible = True
        Me.GridColumnpaid.VisibleIndex = 2
        '
        'GridColumndiff
        '
        Me.GridColumndiff.Caption = "Diff"
        Me.GridColumndiff.DisplayFormat.FormatString = "N0"
        Me.GridColumndiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndiff.FieldName = "diff"
        Me.GridColumndiff.Name = "GridColumndiff"
        Me.GridColumndiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff", "{0:N0}")})
        Me.GridColumndiff.UnboundExpression = "[paid] - [inv]"
        Me.GridColumndiff.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumndiff.Visible = True
        Me.GridColumndiff.VisibleIndex = 3
        '
        'FormAREvaluation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 464)
        Me.Controls.Add(Me.XTCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormAREvaluation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AR Evaluation"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.BtnBrowseEval.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPInvoiceDetail.ResumeLayout(False)
        CType(Me.GCInvoiceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoiceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoBtnBBM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPGroupStore.ResumeLayout(False)
        CType(Me.GCGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPInvoiceDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPGroupStore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BtnViewData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBrowseEval As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCInvoiceDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvoiceDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_store As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_inv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumninv_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumninv_rmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumninv_amount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpaid_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrelease_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnactive_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbtn_bbm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoBtnBBM As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GCGroup As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVGroup As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepoLinkInvoice As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumninv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpaid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndiff As DevExpress.XtraGrid.Columns.GridColumn
End Class
