<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpProdDet
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
        Me.LabelControlAlloc = New DevExpress.XtraEditors.LabelControl()
        Me.LabelSubTitle = New DevExpress.XtraEditors.LabelControl()
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl()
        Me.PCClose = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GVListProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEanCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRangeUnique = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyAlloc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCQtyRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCQtyRetIn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCQtyRetOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSNIIn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSNIOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCQtyQCReport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCListProduct = New DevExpress.XtraGrid.GridControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PCClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCClose.SuspendLayout()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.LabelControlAlloc)
        Me.PanelControl1.Controls.Add(Me.LabelSubTitle)
        Me.PanelControl1.Controls.Add(Me.LabelTitle)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(997, 73)
        Me.PanelControl1.TabIndex = 37
        '
        'LabelControlAlloc
        '
        Me.LabelControlAlloc.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControlAlloc.Location = New System.Drawing.Point(12, 47)
        Me.LabelControlAlloc.Name = "LabelControlAlloc"
        Me.LabelControlAlloc.Size = New System.Drawing.Size(123, 15)
        Me.LabelControlAlloc.TabIndex = 31
        Me.LabelControlAlloc.Text = "Production Order : xxx"
        Me.LabelControlAlloc.Visible = False
        '
        'LabelSubTitle
        '
        Me.LabelSubTitle.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubTitle.Location = New System.Drawing.Point(12, 32)
        Me.LabelSubTitle.Name = "LabelSubTitle"
        Me.LabelSubTitle.Size = New System.Drawing.Size(123, 15)
        Me.LabelSubTitle.TabIndex = 30
        Me.LabelSubTitle.Text = "Production Order : xxx"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(12, 10)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(99, 23)
        Me.LabelTitle.TabIndex = 29
        Me.LabelTitle.Text = "Detail Order"
        '
        'PCClose
        '
        Me.PCClose.Controls.Add(Me.BtnClose)
        Me.PCClose.Controls.Add(Me.BtnSave)
        Me.PCClose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCClose.Location = New System.Drawing.Point(0, 434)
        Me.PCClose.LookAndFeel.SkinName = "Blue"
        Me.PCClose.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCClose.Name = "PCClose"
        Me.PCClose.Size = New System.Drawing.Size(997, 32)
        Me.PCClose.TabIndex = 38
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Location = New System.Drawing.Point(845, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 28)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(920, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 28)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Choose"
        '
        'GVListProduct
        '
        Me.GVListProduct.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GVListProduct.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVListProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdMat, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColSubtotal, Me.ColColor, Me.ColSize, Me.GridColumnUOM, Me.GridColumnEanCode, Me.GridColumnRangeUnique, Me.GridColumnQtyAlloc, Me.GCQtyRec, Me.GCQtyRetIn, Me.GCQtyRetOut, Me.GridColumnSNIIn, Me.GridColumnSNIOut, Me.GCQtyQCReport})
        Me.GVListProduct.GridControl = Me.GCListProduct
        Me.GVListProduct.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GVListProduct.Name = "GVListProduct"
        Me.GVListProduct.OptionsBehavior.Editable = False
        Me.GVListProduct.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVListProduct.OptionsView.ShowFooter = True
        Me.GVListProduct.OptionsView.ShowGroupPanel = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Prod Order Det"
        Me.ColIdPurcDet.FieldName = "id_prod_order_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        Me.ColIdPurcDet.Width = 96
        '
        'ColIdMat
        '
        Me.ColIdMat.Caption = "Id Mat"
        Me.ColIdMat.FieldName = "id_prod_demand_product"
        Me.ColIdMat.Name = "ColIdMat"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 34
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 108
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 3
        Me.ColName.Width = 131
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Unit Cost"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "estimate_cost"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.OptionsColumn.AllowEdit = False
        Me.ColPrice.Width = 86
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty Allowed"
        Me.ColQty.DisplayFormat.FormatString = "{0:F2}"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.OptionsColumn.AllowEdit = False
        Me.ColQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:F2}")})
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 13
        Me.ColQty.Width = 100
        '
        'ColSubtotal
        '
        Me.ColSubtotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.Caption = "Sub Total"
        Me.ColSubtotal.DisplayFormat.FormatString = "N2"
        Me.ColSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColSubtotal.FieldName = "total_cost"
        Me.ColSubtotal.Name = "ColSubtotal"
        Me.ColSubtotal.OptionsColumn.AllowEdit = False
        Me.ColSubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:N2}")})
        Me.ColSubtotal.Width = 72
        '
        'ColColor
        '
        Me.ColColor.AppearanceCell.Options.UseTextOptions = True
        Me.ColColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColColor.AppearanceHeader.Options.UseTextOptions = True
        Me.ColColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColColor.Caption = "Color"
        Me.ColColor.FieldName = "color"
        Me.ColColor.Name = "ColColor"
        Me.ColColor.OptionsColumn.AllowEdit = False
        Me.ColColor.Visible = True
        Me.ColColor.VisibleIndex = 4
        Me.ColColor.Width = 54
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.OptionsColumn.AllowEdit = False
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 5
        Me.ColSize.Width = 58
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.Width = 77
        '
        'GridColumnEanCode
        '
        Me.GridColumnEanCode.Caption = "Vendor Code"
        Me.GridColumnEanCode.FieldName = "ean_code"
        Me.GridColumnEanCode.Name = "GridColumnEanCode"
        Me.GridColumnEanCode.Visible = True
        Me.GridColumnEanCode.VisibleIndex = 2
        Me.GridColumnEanCode.Width = 119
        '
        'GridColumnRangeUnique
        '
        Me.GridColumnRangeUnique.Caption = "Unique Range"
        Me.GridColumnRangeUnique.FieldName = "range_qty"
        Me.GridColumnRangeUnique.Name = "GridColumnRangeUnique"
        Me.GridColumnRangeUnique.Visible = True
        Me.GridColumnRangeUnique.VisibleIndex = 6
        Me.GridColumnRangeUnique.Width = 74
        '
        'GridColumnQtyAlloc
        '
        Me.GridColumnQtyAlloc.Caption = "Allocation Qty"
        Me.GridColumnQtyAlloc.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnQtyAlloc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyAlloc.FieldName = "jum_alloc_allow"
        Me.GridColumnQtyAlloc.Name = "GridColumnQtyAlloc"
        Me.GridColumnQtyAlloc.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jum_alloc_allow", "{0:f2}")})
        Me.GridColumnQtyAlloc.Width = 148
        '
        'GCQtyRec
        '
        Me.GCQtyRec.AppearanceCell.Options.UseTextOptions = True
        Me.GCQtyRec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCQtyRec.AppearanceHeader.Options.UseTextOptions = True
        Me.GCQtyRec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCQtyRec.Caption = "Qty Receiving"
        Me.GCQtyRec.DisplayFormat.FormatString = "N0"
        Me.GCQtyRec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCQtyRec.FieldName = "qty_rec"
        Me.GCQtyRec.Name = "GCQtyRec"
        Me.GCQtyRec.Visible = True
        Me.GCQtyRec.VisibleIndex = 7
        Me.GCQtyRec.Width = 77
        '
        'GCQtyRetIn
        '
        Me.GCQtyRetIn.AppearanceCell.Options.UseTextOptions = True
        Me.GCQtyRetIn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCQtyRetIn.AppearanceHeader.Options.UseTextOptions = True
        Me.GCQtyRetIn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCQtyRetIn.Caption = "Qty Ret In"
        Me.GCQtyRetIn.DisplayFormat.FormatString = "N0"
        Me.GCQtyRetIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCQtyRetIn.FieldName = "qty_ret_in"
        Me.GCQtyRetIn.Name = "GCQtyRetIn"
        Me.GCQtyRetIn.Visible = True
        Me.GCQtyRetIn.VisibleIndex = 8
        Me.GCQtyRetIn.Width = 69
        '
        'GCQtyRetOut
        '
        Me.GCQtyRetOut.AppearanceCell.Options.UseTextOptions = True
        Me.GCQtyRetOut.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCQtyRetOut.AppearanceHeader.Options.UseTextOptions = True
        Me.GCQtyRetOut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCQtyRetOut.Caption = "Qty Ret Out"
        Me.GCQtyRetOut.DisplayFormat.FormatString = "N0"
        Me.GCQtyRetOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCQtyRetOut.FieldName = "qty_ret_out"
        Me.GCQtyRetOut.Name = "GCQtyRetOut"
        Me.GCQtyRetOut.Visible = True
        Me.GCQtyRetOut.VisibleIndex = 9
        Me.GCQtyRetOut.Width = 69
        '
        'GridColumnSNIIn
        '
        Me.GridColumnSNIIn.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSNIIn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSNIIn.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSNIIn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSNIIn.Caption = "Qty SNI In"
        Me.GridColumnSNIIn.DisplayFormat.FormatString = "N0"
        Me.GridColumnSNIIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSNIIn.FieldName = "qty_sni_in"
        Me.GridColumnSNIIn.Name = "GridColumnSNIIn"
        Me.GridColumnSNIIn.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_sni_in", "{0:N0}")})
        Me.GridColumnSNIIn.Visible = True
        Me.GridColumnSNIIn.VisibleIndex = 10
        '
        'GridColumnSNIOut
        '
        Me.GridColumnSNIOut.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSNIOut.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSNIOut.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSNIOut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSNIOut.Caption = "Qty SNI Out"
        Me.GridColumnSNIOut.DisplayFormat.FormatString = "N0"
        Me.GridColumnSNIOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSNIOut.FieldName = "qty_sni_out"
        Me.GridColumnSNIOut.Name = "GridColumnSNIOut"
        Me.GridColumnSNIOut.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_sni_out", "{0:N0}")})
        Me.GridColumnSNIOut.Visible = True
        Me.GridColumnSNIOut.VisibleIndex = 11
        '
        'GCQtyQCReport
        '
        Me.GCQtyQCReport.AppearanceCell.Options.UseTextOptions = True
        Me.GCQtyQCReport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCQtyQCReport.AppearanceHeader.Options.UseTextOptions = True
        Me.GCQtyQCReport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCQtyQCReport.Caption = "Qty QC Report"
        Me.GCQtyQCReport.DisplayFormat.FormatString = "N0"
        Me.GCQtyQCReport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCQtyQCReport.FieldName = "qty_qcr"
        Me.GCQtyQCReport.Name = "GCQtyQCReport"
        Me.GCQtyQCReport.Visible = True
        Me.GCQtyQCReport.VisibleIndex = 12
        Me.GCQtyQCReport.Width = 86
        '
        'GCListProduct
        '
        Me.GCListProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListProduct.Location = New System.Drawing.Point(0, 73)
        Me.GCListProduct.MainView = Me.GVListProduct
        Me.GCListProduct.Margin = New System.Windows.Forms.Padding(0)
        Me.GCListProduct.Name = "GCListProduct"
        Me.GCListProduct.Size = New System.Drawing.Size(997, 361)
        Me.GCListProduct.TabIndex = 39
        Me.GCListProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListProduct})
        '
        'FormPopUpProdDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 466)
        Me.Controls.Add(Me.GCListProduct)
        Me.Controls.Add(Me.PCClose)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormPopUpProdDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Item Production Order"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PCClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCClose.ResumeLayout(False)
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelSubTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PCClose As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GVListProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEanCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumnRangeUnique As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyAlloc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControlAlloc As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCQtyRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCQtyRetIn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCQtyRetOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCQtyQCReport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSNIIn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSNIOut As DevExpress.XtraGrid.Columns.GridColumn
End Class
