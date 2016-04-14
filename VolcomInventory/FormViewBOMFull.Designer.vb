<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormViewBOMFull
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
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlBreakDown = New DevExpress.XtraEditors.GroupControl
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdProdDemandProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIDProdDemandDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIDBom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnBOMName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnEstimateCost = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotalCost = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCost = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GCBOM = New DevExpress.XtraGrid.GridControl
        Me.GVBOM = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColTotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Cat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIDCat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PCLotTitle = New DevExpress.XtraEditors.PanelControl
        Me.LabelPrintedName = New DevExpress.XtraEditors.LabelControl
        Me.LSampleTitle = New DevExpress.XtraEditors.LabelControl
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControlBreakDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlBreakDown.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCLotTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCLotTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 40)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControlBreakDown)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(844, 492)
        Me.SplitContainerControl1.SplitterPosition = 153
        Me.SplitContainerControl1.TabIndex = 23
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControlBreakDown
        '
        Me.GroupControlBreakDown.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.GroupControlBreakDown.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlBreakDown.Controls.Add(Me.GCProduct)
        Me.GroupControlBreakDown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlBreakDown.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlBreakDown.LookAndFeel.SkinName = "Seven Classic"
        Me.GroupControlBreakDown.Name = "GroupControlBreakDown"
        Me.GroupControlBreakDown.Size = New System.Drawing.Size(844, 153)
        Me.GroupControlBreakDown.TabIndex = 21
        Me.GroupControlBreakDown.Text = "Breakdown Size"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(22, 2)
        Me.GCProduct.LookAndFeel.SkinName = "Seven Classic"
        Me.GCProduct.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(820, 149)
        Me.GCProduct.TabIndex = 2
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdProdDemandProduct, Me.GridColumnIDProdDemandDesign, Me.GridColumnIdProduct, Me.GridColumnIDBom, Me.GridColumnCode, Me.GridColumnProduct, Me.GridColumnBOMName, Me.GridColumnQty, Me.GridColumnEstimateCost, Me.GridColumnTotalCost, Me.GridColumnTotal, Me.GridColumnSize, Me.ColCost})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.Editable = False
        Me.GVProduct.OptionsView.ShowFooter = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdProdDemandProduct
        '
        Me.GridColumnIdProdDemandProduct.Caption = "IdProdDemandProduct"
        Me.GridColumnIdProdDemandProduct.FieldName = "id_prod_demand_product"
        Me.GridColumnIdProdDemandProduct.Name = "GridColumnIdProdDemandProduct"
        '
        'GridColumnIDProdDemandDesign
        '
        Me.GridColumnIDProdDemandDesign.Caption = "IDProdDemandDesign"
        Me.GridColumnIDProdDemandDesign.FieldName = "id_prod_demand_design"
        Me.GridColumnIDProdDemandDesign.Name = "GridColumnIDProdDemandDesign"
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "IdProduct"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        '
        'GridColumnIDBom
        '
        Me.GridColumnIDBom.Caption = "IDBom"
        Me.GridColumnIDBom.FieldName = "id_bom"
        Me.GridColumnIDBom.Name = "GridColumnIDBom"
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "product_full_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        Me.GridColumnCode.Width = 151
        '
        'GridColumnProduct
        '
        Me.GridColumnProduct.Caption = "Product"
        Me.GridColumnProduct.FieldName = "product_name"
        Me.GridColumnProduct.Name = "GridColumnProduct"
        Me.GridColumnProduct.Visible = True
        Me.GridColumnProduct.VisibleIndex = 1
        Me.GridColumnProduct.Width = 151
        '
        'GridColumnBOMName
        '
        Me.GridColumnBOMName.Caption = "BOM Name"
        Me.GridColumnBOMName.FieldName = "bom_name"
        Me.GridColumnBOMName.Name = "GridColumnBOMName"
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Quantity"
        Me.GridColumnQty.FieldName = "prod_demand_product_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        Me.GridColumnQty.Width = 136
        '
        'GridColumnEstimateCost
        '
        Me.GridColumnEstimateCost.Caption = "Estimate Cost"
        Me.GridColumnEstimateCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnEstimateCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnEstimateCost.FieldName = "bom_unit_price"
        Me.GridColumnEstimateCost.Name = "GridColumnEstimateCost"
        Me.GridColumnEstimateCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "bom_unit_price", "{0:N2}")})
        Me.GridColumnEstimateCost.Visible = True
        Me.GridColumnEstimateCost.VisibleIndex = 4
        Me.GridColumnEstimateCost.Width = 150
        '
        'GridColumnTotalCost
        '
        Me.GridColumnTotalCost.Caption = "Estimate Cost + Royalty"
        Me.GridColumnTotalCost.FieldName = "total_cost"
        Me.GridColumnTotalCost.Name = "GridColumnTotalCost"
        Me.GridColumnTotalCost.Width = 175
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.FieldName = "total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "Size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        Me.GridColumnSize.Width = 59
        '
        'ColCost
        '
        Me.ColCost.Caption = "Total Cost"
        Me.ColCost.DisplayFormat.FormatString = "N2"
        Me.ColCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColCost.FieldName = "total_bom"
        Me.ColCost.Name = "ColCost"
        Me.ColCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_bom", "{0:N2}")})
        Me.ColCost.Visible = True
        Me.ColCost.VisibleIndex = 5
        Me.ColCost.Width = 157
        '
        'GroupControl1
        '
        Me.GroupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCBOM)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.LookAndFeel.SkinName = "Seven Classic"
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(844, 334)
        Me.GroupControl1.TabIndex = 22
        Me.GroupControl1.Text = "BOM"
        '
        'GCBOM
        '
        Me.GCBOM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBOM.Location = New System.Drawing.Point(22, 2)
        Me.GCBOM.LookAndFeel.SkinName = "Seven Classic"
        Me.GCBOM.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCBOM.MainView = Me.GVBOM
        Me.GCBOM.Name = "GCBOM"
        Me.GCBOM.Size = New System.Drawing.Size(820, 330)
        Me.GCBOM.TabIndex = 2
        Me.GCBOM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBOM})
        '
        'GVBOM
        '
        Me.GVBOM.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.FooterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Transparent
        Me.GVBOM.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVBOM.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GVBOM.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVBOM.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVBOM.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVBOM.AppearancePrint.FooterPanel.Options.UseForeColor = True
        Me.GVBOM.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.GroupFooter.BackColor2 = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Transparent
        Me.GVBOM.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVBOM.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GVBOM.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVBOM.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVBOM.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVBOM.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.GVBOM.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Transparent
        Me.GVBOM.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GVBOM.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GVBOM.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVBOM.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVBOM.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVBOM.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.GVBOM.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVBOM.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVBOM.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVBOM.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVBOM.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVBOM.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.GVBOM.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColCode, Me.ColName, Me.ColSize, Me.ColQty, Me.ColPrice, Me.ColTotal, Me.Cat, Me.ColIDCat})
        Me.GVBOM.GridControl = Me.GCBOM
        Me.GVBOM.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.ColTotal, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", Me.ColPrice, "Sub Total{0}")})
        Me.GVBOM.Name = "GVBOM"
        Me.GVBOM.OptionsBehavior.Editable = False
        Me.GVBOM.OptionsPrint.PrintVertLines = False
        Me.GVBOM.OptionsView.ShowFooter = True
        Me.GVBOM.OptionsView.ShowGroupPanel = False
        Me.GVBOM.OptionsView.ShowIndicator = False
        Me.GVBOM.RowSeparatorHeight = 1
        '
        'ColCode
        '
        Me.ColCode.AppearanceCell.Options.UseTextOptions = True
        Me.ColCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColCode.AppearanceHeader.Options.UseTextOptions = True
        Me.ColCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 0
        Me.ColCode.Width = 103
        '
        'ColName
        '
        Me.ColName.AppearanceCell.Options.UseTextOptions = True
        Me.ColName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColName.AppearanceHeader.Options.UseTextOptions = True
        Me.ColName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 1
        Me.ColName.Width = 200
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
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 2
        Me.ColSize.Width = 51
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.DisplayFormat.FormatString = "N2"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "qty_uom"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 3
        Me.ColQty.Width = 51
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", "Total")})
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 4
        Me.ColPrice.Width = 103
        '
        'ColTotal
        '
        Me.ColTotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotal.Caption = "Total"
        Me.ColTotal.DisplayFormat.FormatString = "N2"
        Me.ColTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColTotal.FieldName = "total"
        Me.ColTotal.Name = "ColTotal"
        Me.ColTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.ColTotal.Visible = True
        Me.ColTotal.VisibleIndex = 5
        Me.ColTotal.Width = 114
        '
        'Cat
        '
        Me.Cat.Caption = "Category"
        Me.Cat.FieldName = "category"
        Me.Cat.Name = "Cat"
        '
        'ColIDCat
        '
        Me.ColIDCat.Caption = "Category"
        Me.ColIDCat.FieldName = "id_component_category"
        Me.ColIDCat.Name = "ColIDCat"
        Me.ColIDCat.Visible = True
        Me.ColIDCat.VisibleIndex = 6
        '
        'PCLotTitle
        '
        Me.PCLotTitle.Appearance.BackColor = System.Drawing.Color.White
        Me.PCLotTitle.Appearance.BackColor2 = System.Drawing.Color.Transparent
        Me.PCLotTitle.Appearance.BorderColor = System.Drawing.Color.White
        Me.PCLotTitle.Appearance.Options.UseBackColor = True
        Me.PCLotTitle.Appearance.Options.UseBorderColor = True
        Me.PCLotTitle.Controls.Add(Me.LabelPrintedName)
        Me.PCLotTitle.Controls.Add(Me.LSampleTitle)
        Me.PCLotTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCLotTitle.Location = New System.Drawing.Point(0, 0)
        Me.PCLotTitle.LookAndFeel.SkinName = "iMaginary"
        Me.PCLotTitle.Name = "PCLotTitle"
        Me.PCLotTitle.Size = New System.Drawing.Size(844, 40)
        Me.PCLotTitle.TabIndex = 22
        '
        'LabelPrintedName
        '
        Me.LabelPrintedName.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPrintedName.Location = New System.Drawing.Point(84, 5)
        Me.LabelPrintedName.Name = "LabelPrintedName"
        Me.LabelPrintedName.Size = New System.Drawing.Size(6, 26)
        Me.LabelPrintedName.TabIndex = 4
        Me.LabelPrintedName.Text = "-"
        '
        'LSampleTitle
        '
        Me.LSampleTitle.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSampleTitle.Location = New System.Drawing.Point(5, 5)
        Me.LSampleTitle.Name = "LSampleTitle"
        Me.LSampleTitle.Size = New System.Drawing.Size(73, 26)
        Me.LSampleTitle.TabIndex = 3
        Me.LSampleTitle.Text = "Design : "
        '
        'FormViewBOMFull
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 532)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.PCLotTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormViewBOMFull"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View BOM"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControlBreakDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlBreakDown.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCBOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCLotTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCLotTitle.ResumeLayout(False)
        Me.PCLotTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlBreakDown As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdProdDemandProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDProdDemandDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDBom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBOMName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstimateCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCBOM As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBOM As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PCLotTitle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelPrintedName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LSampleTitle As DevExpress.XtraEditors.LabelControl
End Class
