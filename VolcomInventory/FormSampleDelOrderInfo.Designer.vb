<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleDelOrderInfo
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelSubTitle = New DevExpress.XtraEditors.LabelControl
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl
        Me.GCListSampleOrder = New DevExpress.XtraGrid.GridControl
        Me.GVListSampleOrder = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn670 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn671 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn667 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn668 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn672 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn673 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn674 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSampleRetPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn663 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn664 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn665 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn666 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyOrder = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyDelivered = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyRemaining = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyDelivering = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit28 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCListSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit28, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.LabelSubTitle)
        Me.PanelControl1.Controls.Add(Me.LabelTitle)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(698, 59)
        Me.PanelControl1.TabIndex = 35
        '
        'LabelSubTitle
        '
        Me.LabelSubTitle.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubTitle.Location = New System.Drawing.Point(12, 32)
        Me.LabelSubTitle.Name = "LabelSubTitle"
        Me.LabelSubTitle.Size = New System.Drawing.Size(64, 15)
        Me.LabelSubTitle.TabIndex = 30
        Me.LabelSubTitle.Text = "SRS No : xxx"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(12, 9)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(102, 23)
        Me.LabelTitle.TabIndex = 29
        Me.LabelTitle.Text = "Delivery Info"
        '
        'GCListSampleOrder
        '
        Me.GCListSampleOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListSampleOrder.Location = New System.Drawing.Point(0, 59)
        Me.GCListSampleOrder.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCListSampleOrder.MainView = Me.GVListSampleOrder
        Me.GCListSampleOrder.Name = "GCListSampleOrder"
        Me.GCListSampleOrder.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit28})
        Me.GCListSampleOrder.Size = New System.Drawing.Size(698, 392)
        Me.GCListSampleOrder.TabIndex = 36
        Me.GCListSampleOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListSampleOrder})
        '
        'GVListSampleOrder
        '
        Me.GVListSampleOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn670, Me.GridColumn671, Me.GridColumn667, Me.GridColumn668, Me.GridColumn672, Me.GridColumn673, Me.GridColumn674, Me.GridColumnIdSampleRetPrice, Me.GridColumn663, Me.GridColumn664, Me.GridColumn665, Me.GridColumn666, Me.GridColumnQtyOrder, Me.GridColumnQtyDelivered, Me.GridColumnQtyRemaining, Me.GridColumnQtyDelivering})
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
        Me.GridColumn671.Width = 121
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
        'GridColumn672
        '
        Me.GridColumn672.Caption = "Remark"
        Me.GridColumn672.FieldName = "sample_order_det_note"
        Me.GridColumn672.Name = "GridColumn672"
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
        'GridColumnQtyOrder
        '
        Me.GridColumnQtyOrder.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyOrder.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyOrder.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyOrder.Caption = "Order Qty"
        Me.GridColumnQtyOrder.DisplayFormat.FormatString = "F2"
        Me.GridColumnQtyOrder.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyOrder.FieldName = "sample_order_det_qty"
        Me.GridColumnQtyOrder.Name = "GridColumnQtyOrder"
        Me.GridColumnQtyOrder.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyOrder.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQtyOrder.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty", "{0:f2}")})
        Me.GridColumnQtyOrder.Visible = True
        Me.GridColumnQtyOrder.VisibleIndex = 4
        Me.GridColumnQtyOrder.Width = 88
        '
        'GridColumnQtyDelivered
        '
        Me.GridColumnQtyDelivered.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyDelivered.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyDelivered.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyDelivered.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyDelivered.Caption = "Delivered Qty"
        Me.GridColumnQtyDelivered.DisplayFormat.FormatString = "F2"
        Me.GridColumnQtyDelivered.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyDelivered.FieldName = "sample_order_det_qty_del"
        Me.GridColumnQtyDelivered.Name = "GridColumnQtyDelivered"
        Me.GridColumnQtyDelivered.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty_del", "{0:f2}")})
        Me.GridColumnQtyDelivered.Visible = True
        Me.GridColumnQtyDelivered.VisibleIndex = 5
        '
        'GridColumnQtyRemaining
        '
        Me.GridColumnQtyRemaining.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumnQtyRemaining.AppearanceCell.Options.UseFont = True
        Me.GridColumnQtyRemaining.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyRemaining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyRemaining.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumnQtyRemaining.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQtyRemaining.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyRemaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyRemaining.Caption = "Remaining Qty"
        Me.GridColumnQtyRemaining.DisplayFormat.FormatString = "F2"
        Me.GridColumnQtyRemaining.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyRemaining.FieldName = "sample_order_det_qty_remaining"
        Me.GridColumnQtyRemaining.Name = "GridColumnQtyRemaining"
        Me.GridColumnQtyRemaining.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty_remaining", "{0:f2}")})
        Me.GridColumnQtyRemaining.Visible = True
        Me.GridColumnQtyRemaining.VisibleIndex = 6
        '
        'GridColumnQtyDelivering
        '
        Me.GridColumnQtyDelivering.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumnQtyDelivering.AppearanceCell.Options.UseFont = True
        Me.GridColumnQtyDelivering.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyDelivering.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyDelivering.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumnQtyDelivering.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQtyDelivering.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyDelivering.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyDelivering.Caption = "Delivering Qty"
        Me.GridColumnQtyDelivering.DisplayFormat.FormatString = "F2"
        Me.GridColumnQtyDelivering.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyDelivering.FieldName = "sample_order_det_qty_delivering"
        Me.GridColumnQtyDelivering.Name = "GridColumnQtyDelivering"
        Me.GridColumnQtyDelivering.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty_delivering", "{0:f2}")})
        '
        'RepositoryItemSpinEdit28
        '
        Me.RepositoryItemSpinEdit28.AutoHeight = False
        Me.RepositoryItemSpinEdit28.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit28.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit28.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit28.Name = "RepositoryItemSpinEdit28"
        '
        'FormSampleDelOrderInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 451)
        Me.Controls.Add(Me.GCListSampleOrder)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSampleDelOrderInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Order Info"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GCListSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit28, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelSubTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCListSampleOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListSampleOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn663 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn664 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn665 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn666 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn667 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn668 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn670 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn671 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn672 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn673 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn674 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSampleRetPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit28 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnQtyDelivered As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyRemaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyDelivering As DevExpress.XtraGrid.Columns.GridColumn
End Class
