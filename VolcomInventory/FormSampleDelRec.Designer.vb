<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleDelRec
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
        Me.XTCSampleDelRec = New DevExpress.XtraTab.XtraTabControl
        Me.XTPSampleDelRec = New DevExpress.XtraTab.XtraTabPage
        Me.GCSampleDelRec = New DevExpress.XtraGrid.GridControl
        Me.GVSampleDelRec = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XTPSampleDelRecWaiting = New DevExpress.XtraTab.XtraTabPage
        Me.SCCWaitingReceive = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlSampleDel = New DevExpress.XtraEditors.GroupControl
        Me.GCSampleDel = New DevExpress.XtraGrid.GridControl
        Me.GVSampleDel = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControlSampleDelDet = New DevExpress.XtraEditors.GroupControl
        Me.GCSampleDelList = New DevExpress.XtraGrid.GridControl
        Me.GVSampleDelList = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnYearSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyWH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRetail = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRetailAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCostAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPlSalesOrderDel = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        CType(Me.XTCSampleDelRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSampleDelRec.SuspendLayout()
        Me.XTPSampleDelRec.SuspendLayout()
        CType(Me.GCSampleDelRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleDelRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSampleDelRecWaiting.SuspendLayout()
        CType(Me.SCCWaitingReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCWaitingReceive.SuspendLayout()
        CType(Me.GroupControlSampleDel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSampleDel.SuspendLayout()
        CType(Me.GCSampleDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlSampleDelDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSampleDelDet.SuspendLayout()
        CType(Me.GCSampleDelList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleDelList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCSampleDelRec
        '
        Me.XTCSampleDelRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSampleDelRec.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSampleDelRec.Location = New System.Drawing.Point(0, 0)
        Me.XTCSampleDelRec.Name = "XTCSampleDelRec"
        Me.XTCSampleDelRec.SelectedTabPage = Me.XTPSampleDelRec
        Me.XTCSampleDelRec.Size = New System.Drawing.Size(731, 513)
        Me.XTCSampleDelRec.TabIndex = 0
        Me.XTCSampleDelRec.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSampleDelRec, Me.XTPSampleDelRecWaiting})
        '
        'XTPSampleDelRec
        '
        Me.XTPSampleDelRec.Controls.Add(Me.GCSampleDelRec)
        Me.XTPSampleDelRec.Name = "XTPSampleDelRec"
        Me.XTPSampleDelRec.Size = New System.Drawing.Size(725, 487)
        Me.XTPSampleDelRec.Text = "Receive List"
        '
        'GCSampleDelRec
        '
        Me.GCSampleDelRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleDelRec.Location = New System.Drawing.Point(0, 0)
        Me.GCSampleDelRec.MainView = Me.GVSampleDelRec
        Me.GCSampleDelRec.Name = "GCSampleDelRec"
        Me.GCSampleDelRec.Size = New System.Drawing.Size(725, 487)
        Me.GCSampleDelRec.TabIndex = 1
        Me.GCSampleDelRec.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleDelRec})
        '
        'GVSampleDelRec
        '
        Me.GVSampleDelRec.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNumber, Me.GridColumnPLNumber, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumnDate, Me.GridColumnPLCategory, Me.GridColumnStatus})
        Me.GVSampleDelRec.GridControl = Me.GCSampleDelRec
        Me.GVSampleDelRec.Name = "GVSampleDelRec"
        Me.GVSampleDelRec.OptionsBehavior.Editable = False
        Me.GVSampleDelRec.OptionsBehavior.ReadOnly = True
        Me.GVSampleDelRec.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "sample_del_rec_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnPLNumber
        '
        Me.GridColumnPLNumber.Caption = "PL Number"
        Me.GridColumnPLNumber.FieldName = "sample_del_number"
        Me.GridColumnPLNumber.Name = "GridColumnPLNumber"
        Me.GridColumnPLNumber.Visible = True
        Me.GridColumnPLNumber.VisibleIndex = 1
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "comp_name_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 2
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "comp_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 3
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Created Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "sample_del_rec_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 5
        '
        'GridColumnPLCategory
        '
        Me.GridColumnPLCategory.Caption = "Category"
        Me.GridColumnPLCategory.FieldName = "pl_category"
        Me.GridColumnPLCategory.Name = "GridColumnPLCategory"
        Me.GridColumnPLCategory.Visible = True
        Me.GridColumnPLCategory.VisibleIndex = 4
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 6
        '
        'XTPSampleDelRecWaiting
        '
        Me.XTPSampleDelRecWaiting.Controls.Add(Me.SCCWaitingReceive)
        Me.XTPSampleDelRecWaiting.Name = "XTPSampleDelRecWaiting"
        Me.XTPSampleDelRecWaiting.Size = New System.Drawing.Size(725, 487)
        Me.XTPSampleDelRecWaiting.Text = "Waiting to Receive"
        '
        'SCCWaitingReceive
        '
        Me.SCCWaitingReceive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCWaitingReceive.Horizontal = False
        Me.SCCWaitingReceive.Location = New System.Drawing.Point(0, 0)
        Me.SCCWaitingReceive.Name = "SCCWaitingReceive"
        Me.SCCWaitingReceive.Panel1.Controls.Add(Me.GroupControlSampleDel)
        Me.SCCWaitingReceive.Panel1.Text = "Panel1"
        Me.SCCWaitingReceive.Panel2.Controls.Add(Me.GroupControlSampleDelDet)
        Me.SCCWaitingReceive.Panel2.Text = "Panel2"
        Me.SCCWaitingReceive.Size = New System.Drawing.Size(725, 487)
        Me.SCCWaitingReceive.SplitterPosition = 230
        Me.SCCWaitingReceive.TabIndex = 0
        Me.SCCWaitingReceive.Text = "SplitContainerControl1"
        '
        'GroupControlSampleDel
        '
        Me.GroupControlSampleDel.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlSampleDel.Controls.Add(Me.GCSampleDel)
        Me.GroupControlSampleDel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSampleDel.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSampleDel.Name = "GroupControlSampleDel"
        Me.GroupControlSampleDel.Size = New System.Drawing.Size(725, 230)
        Me.GroupControlSampleDel.TabIndex = 0
        Me.GroupControlSampleDel.Text = "Packing List Delivery Sample"
        '
        'GCSampleDel
        '
        Me.GCSampleDel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleDel.Location = New System.Drawing.Point(22, 2)
        Me.GCSampleDel.MainView = Me.GVSampleDel
        Me.GCSampleDel.Name = "GCSampleDel"
        Me.GCSampleDel.Size = New System.Drawing.Size(701, 226)
        Me.GCSampleDel.TabIndex = 1
        Me.GCSampleDel.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleDel})
        '
        'GVSampleDel
        '
        Me.GVSampleDel.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8})
        Me.GVSampleDel.GridControl = Me.GCSampleDel
        Me.GVSampleDel.Name = "GVSampleDel"
        Me.GVSampleDel.OptionsBehavior.Editable = False
        Me.GVSampleDel.OptionsBehavior.ReadOnly = True
        Me.GVSampleDel.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVSampleDel.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Number"
        Me.GridColumn1.FieldName = "sample_del_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "From"
        Me.GridColumn2.FieldName = "comp_name_from"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "To"
        Me.GridColumn3.FieldName = "comp_name_to"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Created Date"
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "sample_del_date"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Category"
        Me.GridColumn5.FieldName = "pl_category"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Status"
        Me.GridColumn6.FieldName = "report_status"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Total Delivered"
        Me.GridColumn7.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "total_qty_delivered"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Total Received"
        Me.GridColumn8.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "total_qty_received"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        '
        'GroupControlSampleDelDet
        '
        Me.GroupControlSampleDelDet.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlSampleDelDet.Controls.Add(Me.GCSampleDelList)
        Me.GroupControlSampleDelDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSampleDelDet.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSampleDelDet.Name = "GroupControlSampleDelDet"
        Me.GroupControlSampleDelDet.Size = New System.Drawing.Size(725, 252)
        Me.GroupControlSampleDelDet.TabIndex = 0
        Me.GroupControlSampleDelDet.Text = "Detail List"
        '
        'GCSampleDelList
        '
        Me.GCSampleDelList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleDelList.Location = New System.Drawing.Point(22, 2)
        Me.GCSampleDelList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCSampleDelList.MainView = Me.GVSampleDelList
        Me.GCSampleDelList.Name = "GCSampleDelList"
        Me.GCSampleDelList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCSampleDelList.Size = New System.Drawing.Size(701, 248)
        Me.GCSampleDelList.TabIndex = 4
        Me.GCSampleDelList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleDelList})
        '
        'GVSampleDelList
        '
        Me.GVSampleDelList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnColor, Me.GridColumnSeason, Me.GridColumnYearSeason, Me.GridColumnQty, Me.GridColumnQtyWH, Me.GridColumnRemark, Me.GridColumnRetail, Me.GridColumnRetailAmount, Me.GridColumnCostAmount, Me.GridColumnIdSample, Me.GridColumnIdPlSalesOrderDel})
        Me.GVSampleDelList.GridControl = Me.GCSampleDelList
        Me.GVSampleDelList.Name = "GVSampleDelList"
        Me.GVSampleDelList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSampleDelList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVSampleDelList.OptionsBehavior.ReadOnly = True
        Me.GVSampleDelList.OptionsCustomization.AllowGroup = False
        Me.GVSampleDelList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVSampleDelList.OptionsView.ShowFooter = True
        Me.GVSampleDelList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 43
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 74
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_design"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 142
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
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 4
        Me.GridColumnSize.Width = 57
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.OptionsColumn.AllowEdit = False
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        Me.GridColumnColor.Width = 56
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.OptionsColumn.AllowEdit = False
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 5
        '
        'GridColumnYearSeason
        '
        Me.GridColumnYearSeason.Caption = "Year"
        Me.GridColumnYearSeason.FieldName = "season_year"
        Me.GridColumnYearSeason.Name = "GridColumnYearSeason"
        Me.GridColumnYearSeason.OptionsColumn.AllowEdit = False
        Me.GridColumnYearSeason.Visible = True
        Me.GridColumnYearSeason.VisibleIndex = 6
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "F2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sample_del_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_qty", "{0:f2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 7
        Me.GridColumnQty.Width = 96
        '
        'GridColumnQtyWH
        '
        Me.GridColumnQtyWH.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyWH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyWH.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyWH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyWH.Caption = "Qty From WH"
        Me.GridColumnQtyWH.DisplayFormat.FormatString = "F2"
        Me.GridColumnQtyWH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyWH.FieldName = "sample_del_det_qty_wh"
        Me.GridColumnQtyWH.Name = "GridColumnQtyWH"
        Me.GridColumnQtyWH.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyWH.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_qty_wh", "{0:f2}")})
        Me.GridColumnQtyWH.Width = 91
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sample_del_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 8
        Me.GridColumnRemark.Width = 93
        '
        'GridColumnRetail
        '
        Me.GridColumnRetail.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnRetail.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRetail.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRetail.Caption = "Retail"
        Me.GridColumnRetail.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnRetail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRetail.FieldName = "sample_ret_price"
        Me.GridColumnRetail.Name = "GridColumnRetail"
        Me.GridColumnRetail.OptionsColumn.AllowEdit = False
        '
        'GridColumnRetailAmount
        '
        Me.GridColumnRetailAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnRetailAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRetailAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRetailAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRetailAmount.Caption = "Retail Amount"
        Me.GridColumnRetailAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnRetailAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRetailAmount.FieldName = "sample_del_det_amount_ret"
        Me.GridColumnRetailAmount.Name = "GridColumnRetailAmount"
        Me.GridColumnRetailAmount.OptionsColumn.AllowEdit = False
        Me.GridColumnRetailAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_amount_ret", "{0:n2}")})
        '
        'GridColumnCostAmount
        '
        Me.GridColumnCostAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCostAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCostAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCostAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCostAmount.Caption = "Cost Amount"
        Me.GridColumnCostAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnCostAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCostAmount.FieldName = "sample_del_det_amount"
        Me.GridColumnCostAmount.Name = "GridColumnCostAmount"
        Me.GridColumnCostAmount.OptionsColumn.AllowEdit = False
        Me.GridColumnCostAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_del_det_amount", "{0:n2}")})
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdPlSalesOrderDel
        '
        Me.GridColumnIdPlSalesOrderDel.Caption = "Id Sample Del Det"
        Me.GridColumnIdPlSalesOrderDel.FieldName = "id_sample_del_det"
        Me.GridColumnIdPlSalesOrderDel.Name = "GridColumnIdPlSalesOrderDel"
        Me.GridColumnIdPlSalesOrderDel.OptionsColumn.AllowEdit = False
        Me.GridColumnIdPlSalesOrderDel.OptionsColumn.ShowInCustomizationForm = False
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'FormSampleDelRec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 513)
        Me.Controls.Add(Me.XTCSampleDelRec)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleDelRec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receive PL Sample Delivery"
        CType(Me.XTCSampleDelRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSampleDelRec.ResumeLayout(False)
        Me.XTPSampleDelRec.ResumeLayout(False)
        CType(Me.GCSampleDelRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleDelRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSampleDelRecWaiting.ResumeLayout(False)
        CType(Me.SCCWaitingReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCWaitingReceive.ResumeLayout(False)
        CType(Me.GroupControlSampleDel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSampleDel.ResumeLayout(False)
        CType(Me.GCSampleDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlSampleDelDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSampleDelDet.ResumeLayout(False)
        CType(Me.GCSampleDelList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleDelList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCSampleDelRec As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSampleDelRec As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSampleDelRecWaiting As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSampleDelRec As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleDelRec As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SCCWaitingReceive As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlSampleDel As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlSampleDelDet As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSampleDel As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleDel As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCSampleDelList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleDelList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnYearSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyWH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetailAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCostAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPlSalesOrderDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
End Class
