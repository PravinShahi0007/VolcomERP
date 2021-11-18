<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFGAdjInInvoice
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGAdjInInvoice))
        Me.GCInvoice = New DevExpress.XtraGrid.GridControl()
        Me.GVInvoice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBPick = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SLUEStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLUEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCInvoice
        '
        Me.GCInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoice.Location = New System.Drawing.Point(0, 47)
        Me.GCInvoice.MainView = Me.GVInvoice
        Me.GCInvoice.Name = "GCInvoice"
        Me.GCInvoice.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit})
        Me.GCInvoice.Size = New System.Drawing.Size(784, 466)
        Me.GCInvoice.TabIndex = 0
        Me.GCInvoice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoice})
        '
        'GVInvoice
        '
        Me.GVInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24})
        Me.GVInvoice.GridControl = Me.GCInvoice
        Me.GVInvoice.GroupCount = 2
        Me.GVInvoice.Name = "GVInvoice"
        Me.GVInvoice.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVInvoice.OptionsFind.AlwaysVisible = True
        Me.GVInvoice.OptionsView.ColumnAutoWidth = False
        Me.GVInvoice.OptionsView.ShowGroupPanel = False
        Me.GVInvoice.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn4, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "*"
        Me.GridColumn1.ColumnEdit = Me.RepositoryItemCheckEdit
        Me.GridColumn1.FieldName = "is_checked"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 104
        '
        'RepositoryItemCheckEdit
        '
        Me.RepositoryItemCheckEdit.AutoHeight = False
        Me.RepositoryItemCheckEdit.Name = "RepositoryItemCheckEdit"
        Me.RepositoryItemCheckEdit.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit.ValueUnchecked = "no"
        '
        'GridColumn2
        '
        Me.GridColumn2.FieldName = "id_sales_pos"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Number"
        Me.GridColumn3.FieldName = "sales_pos_number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 99
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Period"
        Me.GridColumn4.FieldName = "sales_period"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumn5
        '
        Me.GridColumn5.FieldName = "id_comp"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Store"
        Me.GridColumn6.FieldName = "comp"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Drawer"
        Me.GridColumn7.FieldName = "wh_drawer"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 11
        '
        'GridColumn8
        '
        Me.GridColumn8.FieldName = "id_product"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Name"
        Me.GridColumn9.FieldName = "name"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Size"
        Me.GridColumn10.FieldName = "size"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 2
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "UOM"
        Me.GridColumn11.FieldName = "uom"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 3
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Code"
        Me.GridColumn12.FieldName = "code"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 4
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Qty"
        Me.GridColumn13.DisplayFormat.FormatString = "N0"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "adj_in_fg_det_qty"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 5
        Me.GridColumn13.Width = 99
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Price"
        Me.GridColumn14.DisplayFormat.FormatString = "N2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "adj_in_fg_det_price"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 6
        Me.GridColumn14.Width = 106
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Amount"
        Me.GridColumn15.DisplayFormat.FormatString = "N2"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "adj_in_fg_det_amount"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 7
        Me.GridColumn15.Width = 119
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Retail Price"
        Me.GridColumn16.DisplayFormat.FormatString = "N2"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "retail_price"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 8
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Retail Amount"
        Me.GridColumn17.DisplayFormat.FormatString = "N2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "retail_price_amount"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 9
        Me.GridColumn17.Width = 105
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Note"
        Me.GridColumn18.FieldName = "adj_in_fg_det_note"
        Me.GridColumn18.MinWidth = 100
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 10
        Me.GridColumn18.Width = 100
        '
        'GridColumn19
        '
        Me.GridColumn19.FieldName = "id_wh_rack"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.ReadOnly = True
        '
        'GridColumn20
        '
        Me.GridColumn20.FieldName = "id_wh_locator"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.ReadOnly = True
        Me.GridColumn20.Width = 77
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Rack"
        Me.GridColumn21.FieldName = "wh_rack"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.ReadOnly = True
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 12
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Locator"
        Me.GridColumn22.FieldName = "wh_locator"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.ReadOnly = True
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 13
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Store"
        Me.GridColumn23.FieldName = "comp_name"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.ReadOnly = True
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 14
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBPick)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 513)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 48)
        Me.PanelControl1.TabIndex = 1
        '
        'SBPick
        '
        Me.SBPick.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPick.Image = CType(resources.GetObject("SBPick.Image"), System.Drawing.Image)
        Me.SBPick.Location = New System.Drawing.Point(697, 2)
        Me.SBPick.Name = "SBPick"
        Me.SBPick.Size = New System.Drawing.Size(85, 44)
        Me.SBPick.TabIndex = 0
        Me.SBPick.Text = "Pick"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBView)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.SLUEStore)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 47)
        Me.PanelControl2.TabIndex = 2
        '
        'SLUEStore
        '
        Me.SLUEStore.Location = New System.Drawing.Point(64, 12)
        Me.SLUEStore.Name = "SLUEStore"
        Me.SLUEStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEStore.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEStore.Size = New System.Drawing.Size(215, 20)
        Me.SLUEStore.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Account"
        '
        'SBView
        '
        Me.SBView.Location = New System.Drawing.Point(285, 10)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(75, 23)
        Me.SBView.TabIndex = 2
        Me.SBView.Text = "View"
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "GridColumn24"
        Me.GridColumn24.DisplayFormat.FormatString = "N0"
        Me.GridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn24.FieldName = "qty_fixed"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.ReadOnly = True
        '
        'FormFGAdjInInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCInvoice)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormFGAdjInInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormFGAdjInInvoice"
        CType(Me.GCInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLUEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCInvoice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLUEStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
End Class
