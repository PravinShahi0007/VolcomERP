<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdClosingPps
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCProd = New DevExpress.XtraGrid.GridControl()
        Me.GVProd = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIDWO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICESelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLERejectClaim = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GVClaimReject = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLEClaimLate = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GVLateClaim = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRecQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLERejectClaim, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVClaimReject, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLEClaimLate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVLateClaim, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1174, 79)
        Me.PanelControl1.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 515)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1174, 41)
        Me.PanelControl2.TabIndex = 1
        '
        'GCProd
        '
        Me.GCProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProd.Location = New System.Drawing.Point(0, 79)
        Me.GCProd.MainView = Me.GVProd
        Me.GCProd.Name = "GCProd"
        Me.GCProd.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIPictureEdit, Me.RICESelect, Me.RISLERejectClaim, Me.RISLEClaimLate})
        Me.GCProd.Size = New System.Drawing.Size(1174, 436)
        Me.GCProd.TabIndex = 4
        Me.GCProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProd})
        '
        'GVProd
        '
        Me.GVProd.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIDWO, Me.GridColumn26, Me.GridColumn25, Me.GridColumnCompName, Me.GridColumnProdNo, Me.GridColumnDesign, Me.GridColumnCode, Me.GridColumnOrderQty, Me.GridColumnRecQty, Me.GridColumn23, Me.GridColumn22, Me.GridColumn24, Me.GridColumn16, Me.GridColumn20, Me.GridColumn17, Me.GridColumn21, Me.GridColumn18, Me.GridColumn19, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVProd.GridControl = Me.GCProd
        Me.GVProd.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_order", Me.GridColumnOrderQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", Me.GridColumnRecQty, "{0:N0}")})
        Me.GVProd.Name = "GVProd"
        Me.GVProd.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVProd.OptionsFind.AlwaysVisible = True
        Me.GVProd.OptionsView.ColumnAutoWidth = False
        Me.GVProd.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVProd.OptionsView.ShowFooter = True
        Me.GVProd.OptionsView.ShowGroupedColumns = True
        Me.GVProd.OptionsView.ShowGroupPanel = False
        Me.GVProd.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnCompName, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnProdNo, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIDWO
        '
        Me.GridColumnIDWO.Caption = "ID PO"
        Me.GridColumnIDWO.FieldName = "id_prod_order"
        Me.GridColumnIDWO.Name = "GridColumnIDWO"
        '
        'RICESelect
        '
        Me.RICESelect.AutoHeight = False
        Me.RICESelect.Name = "RICESelect"
        Me.RICESelect.ValueChecked = "yes"
        Me.RICESelect.ValueUnchecked = "no"
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Reject Claim"
        Me.GridColumn26.ColumnEdit = Me.RISLERejectClaim
        Me.GridColumn26.FieldName = "id_claim_reject"
        Me.GridColumn26.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 4
        '
        'RISLERejectClaim
        '
        Me.RISLERejectClaim.AutoHeight = False
        Me.RISLERejectClaim.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLERejectClaim.Name = "RISLERejectClaim"
        Me.RISLERejectClaim.View = Me.GVClaimReject
        '
        'GVClaimReject
        '
        Me.GVClaimReject.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn27, Me.GridColumn28})
        Me.GVClaimReject.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GVClaimReject.Name = "GVClaimReject"
        Me.GVClaimReject.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVClaimReject.OptionsView.ShowGroupPanel = False
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "ID"
        Me.GridColumn27.FieldName = "id_claim_reject"
        Me.GridColumn27.Name = "GridColumn27"
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Claim Reject"
        Me.GridColumn28.FieldName = "description"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 0
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Late Delivery Claim"
        Me.GridColumn25.ColumnEdit = Me.RISLEClaimLate
        Me.GridColumn25.FieldName = "id_claim_late"
        Me.GridColumn25.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 5
        '
        'RISLEClaimLate
        '
        Me.RISLEClaimLate.AutoHeight = False
        Me.RISLEClaimLate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLEClaimLate.Name = "RISLEClaimLate"
        Me.RISLEClaimLate.View = Me.GVLateClaim
        '
        'GVLateClaim
        '
        Me.GVLateClaim.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn29, Me.GridColumn30})
        Me.GVLateClaim.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GVLateClaim.Name = "GVLateClaim"
        Me.GVLateClaim.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVLateClaim.OptionsView.ShowGroupPanel = False
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "ID"
        Me.GridColumn29.FieldName = "id_claim_late"
        Me.GridColumn29.Name = "GridColumn29"
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Claim Late"
        Me.GridColumn30.FieldName = "description"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 0
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Vendor"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.OptionsColumn.AllowEdit = False
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 1
        Me.GridColumnCompName.Width = 79
        '
        'GridColumnProdNo
        '
        Me.GridColumnProdNo.Caption = "Number"
        Me.GridColumnProdNo.FieldName = "prod_order_number"
        Me.GridColumnProdNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnProdNo.Name = "GridColumnProdNo"
        Me.GridColumnProdNo.OptionsColumn.AllowEdit = False
        Me.GridColumnProdNo.Visible = True
        Me.GridColumnProdNo.VisibleIndex = 2
        Me.GridColumnProdNo.Width = 74
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_display_name"
        Me.GridColumnDesign.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.OptionsColumn.AllowEdit = False
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 4
        Me.GridColumnDesign.Width = 121
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "design_code"
        Me.GridColumnCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 3
        Me.GridColumnCode.Width = 78
        '
        'GridColumnOrderQty
        '
        Me.GridColumnOrderQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOrderQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrderQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOrderQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrderQty.Caption = "Order Qty"
        Me.GridColumnOrderQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnOrderQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOrderQty.FieldName = "qty_order"
        Me.GridColumnOrderQty.Name = "GridColumnOrderQty"
        Me.GridColumnOrderQty.OptionsColumn.AllowEdit = False
        Me.GridColumnOrderQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_order", "{0:N0}")})
        Me.GridColumnOrderQty.Visible = True
        Me.GridColumnOrderQty.VisibleIndex = 7
        Me.GridColumnOrderQty.Width = 89
        '
        'GridColumnRecQty
        '
        Me.GridColumnRecQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnRecQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRecQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRecQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRecQty.Caption = "Received Qty"
        Me.GridColumnRecQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnRecQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRecQty.FieldName = "qty_rec"
        Me.GridColumnRecQty.Name = "GridColumnRecQty"
        Me.GridColumnRecQty.OptionsColumn.AllowEdit = False
        Me.GridColumnRecQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", "{0:N0}")})
        Me.GridColumnRecQty.Visible = True
        Me.GridColumnRecQty.VisibleIndex = 8
        Me.GridColumnRecQty.Width = 96
        '
        'RIPictureEdit
        '
        Me.RIPictureEdit.Name = "RIPictureEdit"
        Me.RIPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Est Receive Date"
        Me.GridColumn23.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn23.FieldName = "est_rec_date"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 16
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "First Arrive in QC Date"
        Me.GridColumn22.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn22.FieldName = "first_rec_date"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 15
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Late Receiving"
        Me.GridColumn24.FieldName = "late"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 17
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn16.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn16.Caption = "QC Normal"
        Me.GridColumn16.DisplayFormat.FormatString = "N0"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "qc_normal"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 9
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.Caption = "QC Normal Claim Minor"
        Me.GridColumn20.DisplayFormat.FormatString = "N0"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "qc_normal_minor"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 10
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.Caption = "QC Reject Minor"
        Me.GridColumn17.DisplayFormat.FormatString = "N0"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "qc_minor"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 11
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.Caption = "QC Minor Claim Major"
        Me.GridColumn21.DisplayFormat.FormatString = "N0"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "qc_minor_major"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 12
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn18.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn18.Caption = "QC Reject Major"
        Me.GridColumn18.DisplayFormat.FormatString = "N0"
        Me.GridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn18.FieldName = "qc_major"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 13
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.Caption = "QC Afkir"
        Me.GridColumn19.DisplayFormat.FormatString = "N0"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "qc_afkir"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 14
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Amount Claim Minor"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 17
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Amount Claim Major"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 18
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Amount Claim Afkir"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 19
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Total Reject Claim"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 20
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Total Late Claim"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 21
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Total Claim"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 22
        '
        'FormProdClosingPps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 556)
        Me.Controls.Add(Me.GCProd)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormProdClosingPps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose Closing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLERejectClaim, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVClaimReject, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLEClaimLate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVLateClaim, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProd As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIDWO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICESelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLERejectClaim As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GVClaimReject As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLEClaimLate As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GVLateClaim As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
End Class
