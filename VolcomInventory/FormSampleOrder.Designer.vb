<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleOrder
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
        Me.SCCSampleSO = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlOrder = New DevExpress.XtraEditors.GroupControl
        Me.GCSampleOrder = New DevExpress.XtraGrid.GridControl
        Me.GVSampleOrder = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupControlProgress = New DevExpress.XtraEditors.GroupControl
        Me.GCDetailSO = New DevExpress.XtraGrid.GridControl
        Me.GVDetailSO = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyDel = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumn658 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn659 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn660 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn661 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn662 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.SCCSampleSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCSampleSO.SuspendLayout()
        CType(Me.GroupControlOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlOrder.SuspendLayout()
        CType(Me.GCSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlProgress.SuspendLayout()
        CType(Me.GCDetailSO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetailSO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SCCSampleSO
        '
        Me.SCCSampleSO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCSampleSO.Horizontal = False
        Me.SCCSampleSO.Location = New System.Drawing.Point(0, 0)
        Me.SCCSampleSO.Name = "SCCSampleSO"
        Me.SCCSampleSO.Panel1.Controls.Add(Me.GroupControlOrder)
        Me.SCCSampleSO.Panel1.Text = "Panel1"
        Me.SCCSampleSO.Panel2.Controls.Add(Me.GroupControlProgress)
        Me.SCCSampleSO.Panel2.Text = "Panel2"
        Me.SCCSampleSO.Size = New System.Drawing.Size(681, 454)
        Me.SCCSampleSO.SplitterPosition = 218
        Me.SCCSampleSO.TabIndex = 0
        Me.SCCSampleSO.Text = "SplitContainerControl1"
        '
        'GroupControlOrder
        '
        Me.GroupControlOrder.Controls.Add(Me.GCSampleOrder)
        Me.GroupControlOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlOrder.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlOrder.Name = "GroupControlOrder"
        Me.GroupControlOrder.Size = New System.Drawing.Size(681, 218)
        Me.GroupControlOrder.TabIndex = 0
        Me.GroupControlOrder.Text = "Order List"
        '
        'GCSampleOrder
        '
        Me.GCSampleOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleOrder.Location = New System.Drawing.Point(2, 22)
        Me.GCSampleOrder.MainView = Me.GVSampleOrder
        Me.GCSampleOrder.Name = "GCSampleOrder"
        Me.GCSampleOrder.Size = New System.Drawing.Size(677, 194)
        Me.GCSampleOrder.TabIndex = 2
        Me.GCSampleOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleOrder, Me.GridView2})
        '
        'GVSampleOrder
        '
        Me.GVSampleOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn658, Me.GridColumn659, Me.GridColumn660, Me.GridColumn661, Me.GridColumn662, Me.GridColumn6, Me.GridColumn7})
        Me.GVSampleOrder.GridControl = Me.GCSampleOrder
        Me.GVSampleOrder.Name = "GVSampleOrder"
        Me.GVSampleOrder.OptionsBehavior.ReadOnly = True
        Me.GVSampleOrder.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSampleOrder
        Me.GridView2.Name = "GridView2"
        '
        'GroupControlProgress
        '
        Me.GroupControlProgress.Controls.Add(Me.GCDetailSO)
        Me.GroupControlProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlProgress.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlProgress.Name = "GroupControlProgress"
        Me.GroupControlProgress.Size = New System.Drawing.Size(681, 231)
        Me.GroupControlProgress.TabIndex = 0
        Me.GroupControlProgress.Text = "Progress Order"
        '
        'GCDetailSO
        '
        Me.GCDetailSO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetailSO.Location = New System.Drawing.Point(2, 22)
        Me.GCDetailSO.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCDetailSO.MainView = Me.GVDetailSO
        Me.GCDetailSO.Name = "GCDetailSO"
        Me.GCDetailSO.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCDetailSO.Size = New System.Drawing.Size(677, 207)
        Me.GCDetailSO.TabIndex = 5
        Me.GCDetailSO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetailSO})
        '
        'GVDetailSO
        '
        Me.GVDetailSO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnQty, Me.GridColumnQtyDel, Me.GridColumnPrice, Me.GridColumnAmount})
        Me.GVDetailSO.GridControl = Me.GCDetailSO
        Me.GVDetailSO.Name = "GVDetailSO"
        Me.GVDetailSO.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVDetailSO.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVDetailSO.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetailSO.OptionsBehavior.ReadOnly = True
        Me.GVDetailSO.OptionsCustomization.AllowGroup = False
        Me.GVDetailSO.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVDetailSO.OptionsView.ShowFooter = True
        Me.GVDetailSO.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 46
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 76
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_sample"
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
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 59
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Width = 71
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Order Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "F2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sample_order_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty", "{0:f2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 4
        Me.GridColumnQty.Width = 102
        '
        'GridColumnQtyDel
        '
        Me.GridColumnQtyDel.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyDel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyDel.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyDel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyDel.Caption = "Delivered Qty"
        Me.GridColumnQtyDel.DisplayFormat.FormatString = "F2"
        Me.GridColumnQtyDel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyDel.FieldName = "sample_order_det_qty_del"
        Me.GridColumnQtyDel.Name = "GridColumnQtyDel"
        Me.GridColumnQtyDel.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty_del", "{0:f2}")})
        Me.GridColumnQtyDel.Visible = True
        Me.GridColumnQtyDel.VisibleIndex = 5
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Width = 123
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Width = 141
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
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
        'FormSampleOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 454)
        Me.Controls.Add(Me.SCCSampleSO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Order Sample"
        CType(Me.SCCSampleSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCSampleSO.ResumeLayout(False)
        CType(Me.GroupControlOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlOrder.ResumeLayout(False)
        CType(Me.GCSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlProgress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlProgress.ResumeLayout(False)
        CType(Me.GCDetailSO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetailSO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SCCSampleSO As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlOrder As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlProgress As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSampleOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCDetailSO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetailSO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnQtyDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn658 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn659 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn660 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn661 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn662 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
