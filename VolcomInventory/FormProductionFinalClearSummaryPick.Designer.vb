<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProductionFinalClearSummaryPick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionFinalClearSummaryPick))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICESelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnIdProdFc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClaim = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTanggalInput = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEditTo = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditFrom = New DevExpress.XtraEditors.DateEdit()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SLUEViewVendor = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEViewVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBClose)
        Me.PanelControl2.Controls.Add(Me.SBAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 512)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 49)
        Me.PanelControl2.TabIndex = 13
        '
        'SBClose
        '
        Me.SBClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(608, 2)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(84, 45)
        Me.SBClose.TabIndex = 4
        Me.SBClose.Text = "Close"
        '
        'SBAdd
        '
        Me.SBAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(692, 2)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(90, 45)
        Me.SBAdd.TabIndex = 3
        Me.SBAdd.Text = "Add"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 43)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICESelect})
        Me.GCList.Size = New System.Drawing.Size(784, 469)
        Me.GCList.TabIndex = 15
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSelect, Me.GridColumnIdProdFc, Me.GridColumnVendor, Me.GridColumnDesign, Me.GridColumnNumber, Me.GridColumnCategory, Me.GridColumnClaim, Me.GridColumnQty, Me.GridColumnQtyPO, Me.GridColumnQtyRec, Me.GridColumnTanggalInput, Me.GridColumn3})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_fc_det_qty", Me.GridColumnQty, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_po", Me.GridColumnQtyPO, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", Me.GridColumnQtyRec, "{0:N2}")})
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowFooter = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSelect
        '
        Me.GridColumnSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.Caption = "*"
        Me.GridColumnSelect.ColumnEdit = Me.RICESelect
        Me.GridColumnSelect.FieldName = "is_select"
        Me.GridColumnSelect.Name = "GridColumnSelect"
        Me.GridColumnSelect.Visible = True
        Me.GridColumnSelect.VisibleIndex = 0
        '
        'RICESelect
        '
        Me.RICESelect.AutoHeight = False
        Me.RICESelect.Name = "RICESelect"
        Me.RICESelect.ValueChecked = "yes"
        Me.RICESelect.ValueUnchecked = "no"
        '
        'GridColumnIdProdFc
        '
        Me.GridColumnIdProdFc.FieldName = "id_prod_fc"
        Me.GridColumnIdProdFc.Name = "GridColumnIdProdFc"
        Me.GridColumnIdProdFc.OptionsColumn.AllowEdit = False
        '
        'GridColumnVendor
        '
        Me.GridColumnVendor.Caption = "Vendor"
        Me.GridColumnVendor.FieldName = "vendor"
        Me.GridColumnVendor.Name = "GridColumnVendor"
        Me.GridColumnVendor.OptionsColumn.AllowEdit = False
        Me.GridColumnVendor.Visible = True
        Me.GridColumnVendor.VisibleIndex = 1
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.OptionsColumn.AllowEdit = False
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 2
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "prod_fc_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 3
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "pl_category"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.OptionsColumn.AllowEdit = False
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 4
        '
        'GridColumnClaim
        '
        Me.GridColumnClaim.Caption = "Claim"
        Me.GridColumnClaim.FieldName = "pl_category_sub"
        Me.GridColumnClaim.Name = "GridColumnClaim"
        Me.GridColumnClaim.OptionsColumn.AllowEdit = False
        Me.GridColumnClaim.Visible = True
        Me.GridColumnClaim.VisibleIndex = 5
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "prod_fc_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_fc_det_qty", "{0:N2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 6
        '
        'GridColumnQtyPO
        '
        Me.GridColumnQtyPO.Caption = "Qty PO"
        Me.GridColumnQtyPO.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyPO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyPO.FieldName = "qty_po"
        Me.GridColumnQtyPO.Name = "GridColumnQtyPO"
        Me.GridColumnQtyPO.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyPO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_po", "{0:N2}")})
        Me.GridColumnQtyPO.Visible = True
        Me.GridColumnQtyPO.VisibleIndex = 7
        '
        'GridColumnQtyRec
        '
        Me.GridColumnQtyRec.Caption = "Qty Rec"
        Me.GridColumnQtyRec.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyRec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyRec.FieldName = "qty_rec"
        Me.GridColumnQtyRec.Name = "GridColumnQtyRec"
        Me.GridColumnQtyRec.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyRec.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", "{0:N2}")})
        Me.GridColumnQtyRec.Visible = True
        Me.GridColumnQtyRec.VisibleIndex = 8
        '
        'GridColumnTanggalInput
        '
        Me.GridColumnTanggalInput.Caption = "Tanggal Input"
        Me.GridColumnTanggalInput.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnTanggalInput.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnTanggalInput.FieldName = "prod_fc_date"
        Me.GridColumnTanggalInput.Name = "GridColumnTanggalInput"
        Me.GridColumnTanggalInput.OptionsColumn.AllowEdit = False
        Me.GridColumnTanggalInput.Visible = True
        Me.GridColumnTanggalInput.VisibleIndex = 9
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.DateEditTo)
        Me.PanelControl1.Controls.Add(Me.DateEditFrom)
        Me.PanelControl1.Controls.Add(Me.SBView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLUEVendor)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 43)
        Me.PanelControl1.TabIndex = 14
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(454, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl3.TabIndex = 19
        Me.LabelControl3.Text = "-"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(268, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 18
        Me.LabelControl2.Text = "Date"
        '
        'DateEditTo
        '
        Me.DateEditTo.EditValue = ""
        Me.DateEditTo.Location = New System.Drawing.Point(464, 12)
        Me.DateEditTo.Name = "DateEditTo"
        Me.DateEditTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditTo.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DateEditTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditTo.Properties.EditFormat.FormatString = "dd MMM yyyy"
        Me.DateEditTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditTo.Properties.Mask.EditMask = "dd MMM yyyy"
        Me.DateEditTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateEditTo.Size = New System.Drawing.Size(150, 20)
        Me.DateEditTo.TabIndex = 17
        '
        'DateEditFrom
        '
        Me.DateEditFrom.EditValue = ""
        Me.DateEditFrom.Location = New System.Drawing.Point(298, 12)
        Me.DateEditFrom.Name = "DateEditFrom"
        Me.DateEditFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DateEditFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditFrom.Properties.EditFormat.FormatString = "dd MMM yyyy"
        Me.DateEditFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditFrom.Properties.Mask.EditMask = "dd MMM yyyy"
        Me.DateEditFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateEditFrom.Size = New System.Drawing.Size(150, 20)
        Me.DateEditFrom.TabIndex = 16
        '
        'SBView
        '
        Me.SBView.Location = New System.Drawing.Point(630, 10)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(69, 23)
        Me.SBView.TabIndex = 2
        Me.SBView.Text = "View"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Vendor"
        '
        'SLUEVendor
        '
        Me.SLUEVendor.Location = New System.Drawing.Point(52, 12)
        Me.SLUEVendor.Name = "SLUEVendor"
        Me.SLUEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEVendor.Properties.View = Me.SLUEViewVendor
        Me.SLUEVendor.Size = New System.Drawing.Size(200, 20)
        Me.SLUEVendor.TabIndex = 0
        '
        'SLUEViewVendor
        '
        Me.SLUEViewVendor.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SLUEViewVendor.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SLUEViewVendor.Name = "SLUEViewVendor"
        Me.SLUEViewVendor.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SLUEViewVendor.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "id_comp"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Vendor"
        Me.GridColumn2.FieldName = "vendor"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Status"
        Me.GridColumn3.FieldName = "report_status"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 10
        '
        'FormProductionFinalClearSummaryPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.MinimizeBox = False
        Me.Name = "FormProductionFinalClearSummaryPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose Summary Pick"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEViewVendor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICESelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdProdFc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLUEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SLUEViewVendor As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnVendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTanggalInput As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEditTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridColumnClaim As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
