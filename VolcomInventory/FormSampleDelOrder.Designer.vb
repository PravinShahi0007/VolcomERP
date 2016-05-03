<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleDelOrder
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
        Me.XTCSampleDelOrder = New DevExpress.XtraTab.XtraTabControl
        Me.XTPDeliveryList = New DevExpress.XtraTab.XtraTabPage
        Me.GCSampleDelOrder = New DevExpress.XtraGrid.GridControl
        Me.GVSampleDelOrder = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.XTPWaitingList = New DevExpress.XtraTab.XtraTabPage
        Me.SCCSampleOrderDel = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlSampleOrder = New DevExpress.XtraEditors.GroupControl
        Me.GCSampleOrder = New DevExpress.XtraGrid.GridControl
        Me.GVSampleOrder = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn658 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn659 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn660 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn661 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn662 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCreatedDO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView13 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupControlSampleOrderDetail = New DevExpress.XtraEditors.GroupControl
        Me.GCListSampleOrder = New DevExpress.XtraGrid.GridControl
        Me.GVListSampleOrder = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn663 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn664 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn665 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn666 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn667 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn668 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn669 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn670 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn671 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn672 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn673 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn674 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSampleRetPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit28 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.XTCSampleDelOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSampleDelOrder.SuspendLayout()
        Me.XTPDeliveryList.SuspendLayout()
        CType(Me.GCSampleDelOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleDelOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPWaitingList.SuspendLayout()
        CType(Me.SCCSampleOrderDel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCSampleOrderDel.SuspendLayout()
        CType(Me.GroupControlSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSampleOrder.SuspendLayout()
        CType(Me.GCSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlSampleOrderDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSampleOrderDetail.SuspendLayout()
        CType(Me.GCListSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit28, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCSampleDelOrder
        '
        Me.XTCSampleDelOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSampleDelOrder.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSampleDelOrder.Location = New System.Drawing.Point(0, 0)
        Me.XTCSampleDelOrder.Name = "XTCSampleDelOrder"
        Me.XTCSampleDelOrder.SelectedTabPage = Me.XTPDeliveryList
        Me.XTCSampleDelOrder.Size = New System.Drawing.Size(717, 482)
        Me.XTCSampleDelOrder.TabIndex = 0
        Me.XTCSampleDelOrder.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDeliveryList, Me.XTPWaitingList})
        '
        'XTPDeliveryList
        '
        Me.XTPDeliveryList.Controls.Add(Me.GCSampleDelOrder)
        Me.XTPDeliveryList.Name = "XTPDeliveryList"
        Me.XTPDeliveryList.Size = New System.Drawing.Size(711, 456)
        Me.XTPDeliveryList.Text = "Delivery List"
        '
        'GCSampleDelOrder
        '
        Me.GCSampleDelOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleDelOrder.Location = New System.Drawing.Point(0, 0)
        Me.GCSampleDelOrder.MainView = Me.GVSampleDelOrder
        Me.GCSampleDelOrder.Name = "GCSampleDelOrder"
        Me.GCSampleDelOrder.Size = New System.Drawing.Size(711, 456)
        Me.GCSampleDelOrder.TabIndex = 3
        Me.GCSampleDelOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleDelOrder, Me.GridView3})
        '
        'GVSampleDelOrder
        '
        Me.GVSampleDelOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn8})
        Me.GVSampleDelOrder.GridControl = Me.GCSampleDelOrder
        Me.GVSampleDelOrder.Name = "GVSampleDelOrder"
        Me.GVSampleDelOrder.OptionsBehavior.Editable = False
        Me.GVSampleDelOrder.OptionsBehavior.ReadOnly = True
        Me.GVSampleDelOrder.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Number"
        Me.GridColumn1.FieldName = "pl_sample_order_del_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 83
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "To"
        Me.GridColumn2.FieldName = "store_name_to"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created Date"
        Me.GridColumn3.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "pl_sample_order_del_date"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Note"
        Me.GridColumn4.FieldName = "pl_sample_order_del_note"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Status"
        Me.GridColumn5.FieldName = "report_status"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Sales Order Numb."
        Me.GridColumn8.FieldName = "sample_order_number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 2
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCSampleDelOrder
        Me.GridView3.Name = "GridView3"
        '
        'XTPWaitingList
        '
        Me.XTPWaitingList.Controls.Add(Me.SCCSampleOrderDel)
        Me.XTPWaitingList.Name = "XTPWaitingList"
        Me.XTPWaitingList.Size = New System.Drawing.Size(711, 456)
        Me.XTPWaitingList.Text = "Waiting to Delivery"
        '
        'SCCSampleOrderDel
        '
        Me.SCCSampleOrderDel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCSampleOrderDel.Horizontal = False
        Me.SCCSampleOrderDel.Location = New System.Drawing.Point(0, 0)
        Me.SCCSampleOrderDel.Name = "SCCSampleOrderDel"
        Me.SCCSampleOrderDel.Panel1.Controls.Add(Me.GroupControlSampleOrder)
        Me.SCCSampleOrderDel.Panel1.Text = "Panel1"
        Me.SCCSampleOrderDel.Panel2.Controls.Add(Me.GroupControlSampleOrderDetail)
        Me.SCCSampleOrderDel.Panel2.Text = "Panel2"
        Me.SCCSampleOrderDel.Size = New System.Drawing.Size(711, 456)
        Me.SCCSampleOrderDel.SplitterPosition = 209
        Me.SCCSampleOrderDel.TabIndex = 0
        Me.SCCSampleOrderDel.Text = "SplitContainerControl1"
        '
        'GroupControlSampleOrder
        '
        Me.GroupControlSampleOrder.Controls.Add(Me.GCSampleOrder)
        Me.GroupControlSampleOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSampleOrder.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSampleOrder.Name = "GroupControlSampleOrder"
        Me.GroupControlSampleOrder.Size = New System.Drawing.Size(711, 209)
        Me.GroupControlSampleOrder.TabIndex = 0
        Me.GroupControlSampleOrder.Text = "Sample Order List"
        '
        'GCSampleOrder
        '
        Me.GCSampleOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleOrder.Location = New System.Drawing.Point(2, 22)
        Me.GCSampleOrder.MainView = Me.GVSampleOrder
        Me.GCSampleOrder.Name = "GCSampleOrder"
        Me.GCSampleOrder.Size = New System.Drawing.Size(707, 185)
        Me.GCSampleOrder.TabIndex = 4
        Me.GCSampleOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleOrder, Me.GridView13})
        '
        'GVSampleOrder
        '
        Me.GVSampleOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn658, Me.GridColumn659, Me.GridColumn660, Me.GridColumn661, Me.GridColumn662, Me.GridColumn6, Me.GridColumn7, Me.GridColumnCreatedDO})
        Me.GVSampleOrder.GridControl = Me.GCSampleOrder
        Me.GVSampleOrder.Name = "GVSampleOrder"
        Me.GVSampleOrder.OptionsBehavior.ReadOnly = True
        Me.GVSampleOrder.OptionsView.ShowGroupPanel = False
        '
        'GridColumn658
        '
        Me.GridColumn658.Caption = "Number"
        Me.GridColumn658.FieldName = "sample_order_number"
        Me.GridColumn658.Name = "GridColumn658"
        Me.GridColumn658.Visible = True
        Me.GridColumn658.VisibleIndex = 0
        Me.GridColumn658.Width = 83
        '
        'GridColumn659
        '
        Me.GridColumn659.Caption = "To"
        Me.GridColumn659.FieldName = "store_name_to"
        Me.GridColumn659.Name = "GridColumn659"
        Me.GridColumn659.Visible = True
        Me.GridColumn659.VisibleIndex = 1
        '
        'GridColumn660
        '
        Me.GridColumn660.Caption = "Created Date"
        Me.GridColumn660.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn660.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn660.FieldName = "sample_order_date"
        Me.GridColumn660.Name = "GridColumn660"
        Me.GridColumn660.Visible = True
        Me.GridColumn660.VisibleIndex = 4
        '
        'GridColumn661
        '
        Me.GridColumn661.Caption = "Note"
        Me.GridColumn661.FieldName = "sample_order_note"
        Me.GridColumn661.Name = "GridColumn661"
        Me.GridColumn661.Visible = True
        Me.GridColumn661.VisibleIndex = 5
        '
        'GridColumn662
        '
        Me.GridColumn662.Caption = "Status"
        Me.GridColumn662.FieldName = "report_status"
        Me.GridColumn662.Name = "GridColumn662"
        Me.GridColumn662.Visible = True
        Me.GridColumn662.VisibleIndex = 6
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Sales Order Status"
        Me.GridColumn6.FieldName = "so_status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Sales Order Type"
        Me.GridColumn7.FieldName = "so_type"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        '
        'GridColumnCreatedDO
        '
        Me.GridColumnCreatedDO.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCreatedDO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCreatedDO.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCreatedDO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCreatedDO.Caption = "Created DO"
        Me.GridColumnCreatedDO.FieldName = "total_del"
        Me.GridColumnCreatedDO.Name = "GridColumnCreatedDO"
        Me.GridColumnCreatedDO.Visible = True
        Me.GridColumnCreatedDO.VisibleIndex = 7
        '
        'GridView13
        '
        Me.GridView13.GridControl = Me.GCSampleOrder
        Me.GridView13.Name = "GridView13"
        '
        'GroupControlSampleOrderDetail
        '
        Me.GroupControlSampleOrderDetail.Controls.Add(Me.GCListSampleOrder)
        Me.GroupControlSampleOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSampleOrderDetail.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSampleOrderDetail.Name = "GroupControlSampleOrderDetail"
        Me.GroupControlSampleOrderDetail.Size = New System.Drawing.Size(711, 242)
        Me.GroupControlSampleOrderDetail.TabIndex = 0
        Me.GroupControlSampleOrderDetail.Text = "Item List"
        '
        'GCListSampleOrder
        '
        Me.GCListSampleOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListSampleOrder.Location = New System.Drawing.Point(2, 22)
        Me.GCListSampleOrder.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCListSampleOrder.MainView = Me.GVListSampleOrder
        Me.GCListSampleOrder.Name = "GCListSampleOrder"
        Me.GCListSampleOrder.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit28})
        Me.GCListSampleOrder.Size = New System.Drawing.Size(707, 218)
        Me.GCListSampleOrder.TabIndex = 4
        Me.GCListSampleOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListSampleOrder})
        '
        'GVListSampleOrder
        '
        Me.GVListSampleOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn663, Me.GridColumn664, Me.GridColumn665, Me.GridColumn666, Me.GridColumn667, Me.GridColumn668, Me.GridColumn669, Me.GridColumn9, Me.GridColumn10, Me.GridColumn670, Me.GridColumn671, Me.GridColumn672, Me.GridColumn673, Me.GridColumn674, Me.GridColumnIdSampleRetPrice})
        Me.GVListSampleOrder.GridControl = Me.GCListSampleOrder
        Me.GVListSampleOrder.Name = "GVListSampleOrder"
        Me.GVListSampleOrder.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVListSampleOrder.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVListSampleOrder.OptionsBehavior.ReadOnly = True
        Me.GVListSampleOrder.OptionsCustomization.AllowGroup = False
        Me.GVListSampleOrder.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVListSampleOrder.OptionsView.ShowFooter = True
        Me.GVListSampleOrder.OptionsView.ShowGroupPanel = False
        '
        'GridColumn663
        '
        Me.GridColumn663.Caption = "No"
        Me.GridColumn663.FieldName = "no"
        Me.GridColumn663.Name = "GridColumn663"
        Me.GridColumn663.OptionsColumn.AllowEdit = False
        Me.GridColumn663.Visible = True
        Me.GridColumn663.VisibleIndex = 0
        Me.GridColumn663.Width = 35
        '
        'GridColumn664
        '
        Me.GridColumn664.Caption = "Code"
        Me.GridColumn664.FieldName = "code"
        Me.GridColumn664.Name = "GridColumn664"
        Me.GridColumn664.OptionsColumn.AllowEdit = False
        Me.GridColumn664.Visible = True
        Me.GridColumn664.VisibleIndex = 1
        Me.GridColumn664.Width = 58
        '
        'GridColumn665
        '
        Me.GridColumn665.Caption = "Description"
        Me.GridColumn665.FieldName = "name"
        Me.GridColumn665.FieldNameSortGroup = "id_sample"
        Me.GridColumn665.Name = "GridColumn665"
        Me.GridColumn665.OptionsColumn.AllowEdit = False
        Me.GridColumn665.Visible = True
        Me.GridColumn665.VisibleIndex = 2
        Me.GridColumn665.Width = 121
        '
        'GridColumn666
        '
        Me.GridColumn666.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn666.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn666.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn666.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn666.Caption = "Size"
        Me.GridColumn666.FieldName = "size"
        Me.GridColumn666.Name = "GridColumn666"
        Me.GridColumn666.OptionsColumn.AllowEdit = False
        Me.GridColumn666.Visible = True
        Me.GridColumn666.VisibleIndex = 3
        Me.GridColumn666.Width = 45
        '
        'GridColumn667
        '
        Me.GridColumn667.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn667.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn667.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn667.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn667.Caption = "UOM"
        Me.GridColumn667.FieldName = "uom"
        Me.GridColumn667.Name = "GridColumn667"
        Me.GridColumn667.OptionsColumn.AllowEdit = False
        Me.GridColumn667.Width = 71
        '
        'GridColumn668
        '
        Me.GridColumn668.Caption = "Price Type"
        Me.GridColumn668.FieldName = "design_price_type"
        Me.GridColumn668.Name = "GridColumn668"
        Me.GridColumn668.OptionsColumn.AllowEdit = False
        Me.GridColumn668.Width = 98
        '
        'GridColumn669
        '
        Me.GridColumn669.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn669.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn669.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn669.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn669.Caption = "Order Qty"
        Me.GridColumn669.DisplayFormat.FormatString = "F2"
        Me.GridColumn669.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn669.FieldName = "sample_order_det_qty"
        Me.GridColumn669.Name = "GridColumn669"
        Me.GridColumn669.OptionsColumn.AllowEdit = False
        Me.GridColumn669.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn669.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty", "{0:f2}")})
        Me.GridColumn669.Visible = True
        Me.GridColumn669.VisibleIndex = 5
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Delivered Qty"
        Me.GridColumn9.DisplayFormat.FormatString = "F2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "sample_order_det_qty_del"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty_del", "{0:f2}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 6
        Me.GridColumn9.Width = 99
        '
        'GridColumn670
        '
        Me.GridColumn670.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn670.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn670.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn670.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn670.Caption = "Price"
        Me.GridColumn670.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn670.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn670.FieldName = "sample_ret_price"
        Me.GridColumn670.Name = "GridColumn670"
        Me.GridColumn670.OptionsColumn.AllowEdit = False
        Me.GridColumn670.Visible = True
        Me.GridColumn670.VisibleIndex = 4
        Me.GridColumn670.Width = 91
        '
        'GridColumn671
        '
        Me.GridColumn671.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn671.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn671.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn671.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn671.Caption = "Delivered Amount"
        Me.GridColumn671.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn671.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn671.FieldName = "sample_order_det_amount"
        Me.GridColumn671.Name = "GridColumn671"
        Me.GridColumn671.OptionsColumn.AllowEdit = False
        Me.GridColumn671.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_amount", "{0:n2}")})
        Me.GridColumn671.Visible = True
        Me.GridColumn671.VisibleIndex = 8
        Me.GridColumn671.Width = 94
        '
        'GridColumn672
        '
        Me.GridColumn672.Caption = "Remark"
        Me.GridColumn672.FieldName = "sample_order_det_note"
        Me.GridColumn672.Name = "GridColumn672"
        Me.GridColumn672.Visible = True
        Me.GridColumn672.VisibleIndex = 9
        Me.GridColumn672.Width = 157
        '
        'GridColumn673
        '
        Me.GridColumn673.Caption = "Id Sample"
        Me.GridColumn673.FieldName = "id_sample"
        Me.GridColumn673.Name = "GridColumn673"
        Me.GridColumn673.OptionsColumn.AllowEdit = False
        Me.GridColumn673.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn673.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn674
        '
        Me.GridColumn674.Caption = "Id Sample Order Det"
        Me.GridColumn674.FieldName = "id_sample_order_det"
        Me.GridColumn674.Name = "GridColumn674"
        Me.GridColumn674.OptionsColumn.AllowEdit = False
        Me.GridColumn674.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn674.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn674.Width = 107
        '
        'GridColumnIdSampleRetPrice
        '
        Me.GridColumnIdSampleRetPrice.Caption = "Id Sample Ret Price"
        Me.GridColumnIdSampleRetPrice.FieldName = "id_sample_ret_price"
        Me.GridColumnIdSampleRetPrice.Name = "GridColumnIdSampleRetPrice"
        Me.GridColumnIdSampleRetPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSampleRetPrice.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdSampleRetPrice.Width = 102
        '
        'RepositoryItemSpinEdit28
        '
        Me.RepositoryItemSpinEdit28.AutoHeight = False
        Me.RepositoryItemSpinEdit28.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit28.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit28.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit28.Name = "RepositoryItemSpinEdit28"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Remaining Qty"
        Me.GridColumn10.DisplayFormat.FormatString = "F2"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "sample_order_det_qty_remaining"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty_remaining", "{0:f2}")})
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 7
        Me.GridColumn10.Width = 102
        '
        'FormSampleDelOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 482)
        Me.Controls.Add(Me.XTCSampleDelOrder)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleDelOrder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Order Sample"
        CType(Me.XTCSampleDelOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSampleDelOrder.ResumeLayout(False)
        Me.XTPDeliveryList.ResumeLayout(False)
        CType(Me.GCSampleDelOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleDelOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPWaitingList.ResumeLayout(False)
        CType(Me.SCCSampleOrderDel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCSampleOrderDel.ResumeLayout(False)
        CType(Me.GroupControlSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSampleOrder.ResumeLayout(False)
        CType(Me.GCSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlSampleOrderDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSampleOrderDetail.ResumeLayout(False)
        CType(Me.GCListSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit28, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCSampleDelOrder As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDeliveryList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPWaitingList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSampleDelOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleDelOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SCCSampleOrderDel As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlSampleOrder As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlSampleOrderDetail As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSampleOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn658 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn659 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn660 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn661 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn662 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView13 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCListSampleOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListSampleOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn663 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn664 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn665 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn666 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn667 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn668 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn669 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn670 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn671 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn672 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn673 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn674 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSampleRetPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit28 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
End Class
