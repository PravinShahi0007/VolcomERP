<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleDelOrderPopUp
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
        Me.SCCSOSample = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlSO = New DevExpress.XtraEditors.GroupControl
        Me.GCSampleOrder = New DevExpress.XtraGrid.GridControl
        Me.GVSampleOrder = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn658 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn659 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn660 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn661 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn662 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView13 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupControlSODetail = New DevExpress.XtraEditors.GroupControl
        Me.GCListSampleOrder = New DevExpress.XtraGrid.GridControl
        Me.GVListSampleOrder = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn663 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn664 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn665 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn666 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn667 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn668 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn669 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn670 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn671 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn672 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn673 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn674 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSampleRetPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSelect = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.RepositoryItemSpinEdit28 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GroupControlSave = New DevExpress.XtraEditors.GroupControl
        Me.CheckEditSelectAll = New DevExpress.XtraEditors.CheckEdit
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        CType(Me.SCCSOSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCSOSample.SuspendLayout()
        CType(Me.GroupControlSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSO.SuspendLayout()
        CType(Me.GCSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlSODetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSODetail.SuspendLayout()
        CType(Me.GCListSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSave.SuspendLayout()
        CType(Me.CheckEditSelectAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SCCSOSample
        '
        Me.SCCSOSample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCSOSample.Horizontal = False
        Me.SCCSOSample.Location = New System.Drawing.Point(0, 0)
        Me.SCCSOSample.Name = "SCCSOSample"
        Me.SCCSOSample.Panel1.Controls.Add(Me.GroupControlSO)
        Me.SCCSOSample.Panel1.Text = "Panel1"
        Me.SCCSOSample.Panel2.Controls.Add(Me.GroupControlSODetail)
        Me.SCCSOSample.Panel2.Text = "Panel2"
        Me.SCCSOSample.Size = New System.Drawing.Size(681, 444)
        Me.SCCSOSample.SplitterPosition = 209
        Me.SCCSOSample.TabIndex = 0
        Me.SCCSOSample.Text = "SplitContainerControl1"
        '
        'GroupControlSO
        '
        Me.GroupControlSO.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlSO.Controls.Add(Me.GCSampleOrder)
        Me.GroupControlSO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSO.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSO.Name = "GroupControlSO"
        Me.GroupControlSO.Size = New System.Drawing.Size(681, 209)
        Me.GroupControlSO.TabIndex = 1
        Me.GroupControlSO.Text = "Sales Order Sample"
        '
        'GCSampleOrder
        '
        Me.GCSampleOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleOrder.Location = New System.Drawing.Point(22, 2)
        Me.GCSampleOrder.MainView = Me.GVSampleOrder
        Me.GCSampleOrder.Name = "GCSampleOrder"
        Me.GCSampleOrder.Size = New System.Drawing.Size(657, 205)
        Me.GCSampleOrder.TabIndex = 5
        Me.GCSampleOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleOrder, Me.GridView13})
        '
        'GVSampleOrder
        '
        Me.GVSampleOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn658, Me.GridColumn659, Me.GridColumn660, Me.GridColumn661, Me.GridColumn662, Me.GridColumn6, Me.GridColumn7})
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
        'GridView13
        '
        Me.GridView13.GridControl = Me.GCSampleOrder
        Me.GridView13.Name = "GridView13"
        '
        'GroupControlSODetail
        '
        Me.GroupControlSODetail.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlSODetail.Controls.Add(Me.GCListSampleOrder)
        Me.GroupControlSODetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSODetail.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSODetail.Name = "GroupControlSODetail"
        Me.GroupControlSODetail.Size = New System.Drawing.Size(681, 230)
        Me.GroupControlSODetail.TabIndex = 0
        Me.GroupControlSODetail.Text = "Detail"
        '
        'GCListSampleOrder
        '
        Me.GCListSampleOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListSampleOrder.Location = New System.Drawing.Point(22, 2)
        Me.GCListSampleOrder.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCListSampleOrder.MainView = Me.GVListSampleOrder
        Me.GCListSampleOrder.Name = "GCListSampleOrder"
        Me.GCListSampleOrder.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit28, Me.RepositoryItemCheckEdit1})
        Me.GCListSampleOrder.Size = New System.Drawing.Size(657, 226)
        Me.GCListSampleOrder.TabIndex = 5
        Me.GCListSampleOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListSampleOrder})
        '
        'GVListSampleOrder
        '
        Me.GVListSampleOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn663, Me.GridColumn664, Me.GridColumn665, Me.GridColumn666, Me.GridColumn667, Me.GridColumn668, Me.GridColumn669, Me.GridColumn670, Me.GridColumn671, Me.GridColumn672, Me.GridColumn673, Me.GridColumn674, Me.GridColumnIdSampleRetPrice, Me.GridColumnSelect})
        Me.GVListSampleOrder.GridControl = Me.GCListSampleOrder
        Me.GVListSampleOrder.Name = "GVListSampleOrder"
        Me.GVListSampleOrder.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVListSampleOrder.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
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
        Me.GridColumn663.Width = 42
        '
        'GridColumn664
        '
        Me.GridColumn664.Caption = "Code"
        Me.GridColumn664.FieldName = "code"
        Me.GridColumn664.Name = "GridColumn664"
        Me.GridColumn664.OptionsColumn.AllowEdit = False
        Me.GridColumn664.Visible = True
        Me.GridColumn664.VisibleIndex = 1
        Me.GridColumn664.Width = 69
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
        Me.GridColumn665.Width = 142
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
        Me.GridColumn666.Width = 53
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
        Me.GridColumn669.Caption = "Qty"
        Me.GridColumn669.DisplayFormat.FormatString = "F2"
        Me.GridColumn669.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn669.FieldName = "sample_order_det_qty"
        Me.GridColumn669.Name = "GridColumn669"
        Me.GridColumn669.OptionsColumn.AllowEdit = False
        Me.GridColumn669.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn669.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty", "{0:f2}")})
        Me.GridColumn669.Visible = True
        Me.GridColumn669.VisibleIndex = 5
        Me.GridColumn669.Width = 88
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
        Me.GridColumn670.Width = 106
        '
        'GridColumn671
        '
        Me.GridColumn671.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn671.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn671.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn671.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn671.Caption = "Amount"
        Me.GridColumn671.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn671.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn671.FieldName = "sample_order_det_amount"
        Me.GridColumn671.Name = "GridColumn671"
        Me.GridColumn671.OptionsColumn.AllowEdit = False
        Me.GridColumn671.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_amount", "{0:n2}")})
        Me.GridColumn671.Visible = True
        Me.GridColumn671.VisibleIndex = 6
        Me.GridColumn671.Width = 121
        '
        'GridColumn672
        '
        Me.GridColumn672.Caption = "Remark"
        Me.GridColumn672.FieldName = "sample_order_det_note"
        Me.GridColumn672.Name = "GridColumn672"
        Me.GridColumn672.OptionsColumn.AllowEdit = False
        Me.GridColumn672.Visible = True
        Me.GridColumn672.VisibleIndex = 7
        Me.GridColumn672.Width = 225
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
        '
        'GridColumnIdSampleRetPrice
        '
        Me.GridColumnIdSampleRetPrice.Caption = "Id Sample Ret Price"
        Me.GridColumnIdSampleRetPrice.FieldName = "id_sample_ret_price"
        Me.GridColumnIdSampleRetPrice.Name = "GridColumnIdSampleRetPrice"
        Me.GridColumnIdSampleRetPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSampleRetPrice.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnSelect
        '
        Me.GridColumnSelect.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.Caption = "Select"
        Me.GridColumnSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnSelect.FieldName = "is_select"
        Me.GridColumnSelect.Name = "GridColumnSelect"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'RepositoryItemSpinEdit28
        '
        Me.RepositoryItemSpinEdit28.AutoHeight = False
        Me.RepositoryItemSpinEdit28.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit28.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit28.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit28.Name = "RepositoryItemSpinEdit28"
        '
        'GroupControlSave
        '
        Me.GroupControlSave.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlSave.Controls.Add(Me.CheckEditSelectAll)
        Me.GroupControlSave.Controls.Add(Me.BtnCancel)
        Me.GroupControlSave.Controls.Add(Me.BtnChoose)
        Me.GroupControlSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControlSave.Location = New System.Drawing.Point(0, 444)
        Me.GroupControlSave.Name = "GroupControlSave"
        Me.GroupControlSave.Size = New System.Drawing.Size(681, 35)
        Me.GroupControlSave.TabIndex = 1
        '
        'CheckEditSelectAll
        '
        Me.CheckEditSelectAll.Location = New System.Drawing.Point(25, 6)
        Me.CheckEditSelectAll.Name = "CheckEditSelectAll"
        Me.CheckEditSelectAll.Properties.Caption = "Select All Item"
        Me.CheckEditSelectAll.Size = New System.Drawing.Size(102, 19)
        Me.CheckEditSelectAll.TabIndex = 2
        Me.CheckEditSelectAll.Visible = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(529, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 31)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(604, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 31)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'FormSampleDelOrderPopUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 479)
        Me.Controls.Add(Me.SCCSOSample)
        Me.Controls.Add(Me.GroupControlSave)
        Me.MinimizeBox = False
        Me.Name = "FormSampleDelOrderPopUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Sales Order Sample"
        CType(Me.SCCSOSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCSOSample.ResumeLayout(False)
        CType(Me.GroupControlSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSO.ResumeLayout(False)
        CType(Me.GCSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlSODetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSODetail.ResumeLayout(False)
        CType(Me.GCListSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSave.ResumeLayout(False)
        CType(Me.CheckEditSelectAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SCCSOSample As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlSO As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlSODetail As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlSave As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCSampleOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn658 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn659 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn660 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn661 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn662 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents GridColumnSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CheckEditSelectAll As DevExpress.XtraEditors.CheckEdit
End Class
