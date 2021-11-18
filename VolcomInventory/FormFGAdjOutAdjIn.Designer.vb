<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFGAdjOutAdjIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGAdjOutAdjIn))
        Me.SBPick = New DevExpress.XtraEditors.SimpleButton()
        Me.GVAdjIn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCAdjIn = New DevExpress.XtraGrid.GridControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLUEProduct = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEditName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEditSize = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEditAccount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEditPrice = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEditQty = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GVAdjIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCAdjIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLUEProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'GVAdjIn
        '
        Me.GVAdjIn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn22, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn1})
        Me.GVAdjIn.GridControl = Me.GCAdjIn
        Me.GVAdjIn.Name = "GVAdjIn"
        Me.GVAdjIn.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVAdjIn.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVAdjIn.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVAdjIn.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GVAdjIn.OptionsView.ColumnAutoWidth = False
        Me.GVAdjIn.OptionsView.ShowFooter = True
        Me.GVAdjIn.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "*"
        Me.GridColumn2.ColumnEdit = Me.RepositoryItemCheckEdit
        Me.GridColumn2.FieldName = "is_checked"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'RepositoryItemCheckEdit
        '
        Me.RepositoryItemCheckEdit.AutoHeight = False
        Me.RepositoryItemCheckEdit.Name = "RepositoryItemCheckEdit"
        Me.RepositoryItemCheckEdit.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit.ValueUnchecked = "no"
        '
        'GridColumn3
        '
        Me.GridColumn3.FieldName = "id_product"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Name"
        Me.GridColumn4.FieldName = "name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Code"
        Me.GridColumn22.FieldName = "code"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 5
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Size"
        Me.GridColumn5.FieldName = "size"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Qty"
        Me.GridColumn6.DisplayFormat.FormatString = "N0"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "adj_out_fg_det_qty"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "adj_out_fg_det_qty", "{0:N0}")})
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Note"
        Me.GridColumn7.FieldName = "adj_out_fg_det_note"
        Me.GridColumn7.MinWidth = 100
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 4
        Me.GridColumn7.Width = 100
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "UOM"
        Me.GridColumn8.FieldName = "uom"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Drawer"
        Me.GridColumn9.FieldName = "wh_drawer"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Account Number"
        Me.GridColumn10.FieldName = "comp_number"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Account Name"
        Me.GridColumn11.FieldName = "comp_name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 9
        '
        'GridColumn12
        '
        Me.GridColumn12.FieldName = "id_wh_locator"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        '
        'GridColumn13
        '
        Me.GridColumn13.FieldName = "id_wh_drawer"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        '
        'GridColumn14
        '
        Me.GridColumn14.FieldName = "id_wh_rack"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        '
        'GridColumn15
        '
        Me.GridColumn15.FieldName = "id_comp"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Price"
        Me.GridColumn16.DisplayFormat.FormatString = "N2"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "adj_out_fg_det_price"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 10
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Amount"
        Me.GridColumn17.DisplayFormat.FormatString = "N2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "adj_out_fg_det_amount"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 11
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Retail Price"
        Me.GridColumn18.DisplayFormat.FormatString = "N2"
        Me.GridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn18.FieldName = "retail_price"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 12
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Retail Price Amount"
        Me.GridColumn19.DisplayFormat.FormatString = "N2"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "retail_price_amount"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 13
        '
        'GridColumn1
        '
        Me.GridColumn1.DisplayFormat.FormatString = "N0"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "qty_fixed"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        '
        'GCAdjIn
        '
        Me.GCAdjIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAdjIn.Location = New System.Drawing.Point(0, 181)
        Me.GCAdjIn.MainView = Me.GVAdjIn
        Me.GCAdjIn.Name = "GCAdjIn"
        Me.GCAdjIn.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit})
        Me.GCAdjIn.Size = New System.Drawing.Size(784, 332)
        Me.GCAdjIn.TabIndex = 2
        Me.GCAdjIn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAdjIn})
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBPick)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 513)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 48)
        Me.PanelControl1.TabIndex = 3
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControl6)
        Me.PanelControl2.Controls.Add(Me.TextEditQty)
        Me.PanelControl2.Controls.Add(Me.LabelControl5)
        Me.PanelControl2.Controls.Add(Me.TextEditPrice)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.TextEditAccount)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.TextEditSize)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.TextEditName)
        Me.PanelControl2.Controls.Add(Me.SBView)
        Me.PanelControl2.Controls.Add(Me.SLUEProduct)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 181)
        Me.PanelControl2.TabIndex = 4
        '
        'SBView
        '
        Me.SBView.Location = New System.Drawing.Point(323, 16)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(75, 23)
        Me.SBView.TabIndex = 4
        Me.SBView.Text = "View"
        '
        'SLUEProduct
        '
        Me.SLUEProduct.Location = New System.Drawing.Point(70, 18)
        Me.SLUEProduct.Name = "SLUEProduct"
        Me.SLUEProduct.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEProduct.Properties.View = Me.GridView1
        Me.SLUEProduct.Size = New System.Drawing.Size(247, 20)
        Me.SLUEProduct.TabIndex = 3
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 21)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Code"
        '
        'TextEditName
        '
        Me.TextEditName.Location = New System.Drawing.Point(70, 44)
        Me.TextEditName.Name = "TextEditName"
        Me.TextEditName.Properties.ReadOnly = True
        Me.TextEditName.Size = New System.Drawing.Size(247, 20)
        Me.TextEditName.TabIndex = 5
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 47)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "Name"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 73)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "Size"
        '
        'TextEditSize
        '
        Me.TextEditSize.Location = New System.Drawing.Point(70, 70)
        Me.TextEditSize.Name = "TextEditSize"
        Me.TextEditSize.Properties.ReadOnly = True
        Me.TextEditSize.Size = New System.Drawing.Size(247, 20)
        Me.TextEditSize.TabIndex = 7
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 99)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl4.TabIndex = 10
        Me.LabelControl4.Text = "Account"
        '
        'TextEditAccount
        '
        Me.TextEditAccount.Location = New System.Drawing.Point(70, 96)
        Me.TextEditAccount.Name = "TextEditAccount"
        Me.TextEditAccount.Properties.ReadOnly = True
        Me.TextEditAccount.Size = New System.Drawing.Size(247, 20)
        Me.TextEditAccount.TabIndex = 9
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(17, 125)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl5.TabIndex = 12
        Me.LabelControl5.Text = "Price"
        '
        'TextEditPrice
        '
        Me.TextEditPrice.Location = New System.Drawing.Point(70, 122)
        Me.TextEditPrice.Name = "TextEditPrice"
        Me.TextEditPrice.Properties.ReadOnly = True
        Me.TextEditPrice.Size = New System.Drawing.Size(247, 20)
        Me.TextEditPrice.TabIndex = 11
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(17, 151)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl6.TabIndex = 14
        Me.LabelControl6.Text = "Qty"
        '
        'TextEditQty
        '
        Me.TextEditQty.Location = New System.Drawing.Point(70, 148)
        Me.TextEditQty.Name = "TextEditQty"
        Me.TextEditQty.Properties.ReadOnly = True
        Me.TextEditQty.Size = New System.Drawing.Size(247, 20)
        Me.TextEditQty.TabIndex = 13
        '
        'FormFGAdjOutAdjIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCAdjIn)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormFGAdjOutAdjIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormFGAdjOutAdjIn"
        CType(Me.GVAdjIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCAdjIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLUEProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SBPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GVAdjIn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCAdjIn As DevExpress.XtraGrid.GridControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
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
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLUEProduct As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents TextEditName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditAccount As DevExpress.XtraEditors.TextEdit
End Class
