<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesOrderPromoList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesOrderPromoList))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNoProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_ol_promo_collection_det_prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_ol_promo_collection_prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design_prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncodeprod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname_prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_prod_shopify = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncurrenttag = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price_prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprice_type_prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount_prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_block_view_sku = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnid_design_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncolor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsht = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 320)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(543, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(331, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(92, 42)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(423, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(118, 42)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add Product"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(0, 0)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GCProduct.Size = New System.Drawing.Size(543, 320)
        Me.GCProduct.TabIndex = 1
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNoProduct, Me.GridColumnid_ol_promo_collection_det_prod, Me.GridColumnid_ol_promo_collection_prod, Me.GridColumnid_design_prod, Me.GridColumnid_product, Me.GridColumncodeprod, Me.GridColumnname_prod, Me.GridColumnsize, Me.GridColumndesign_code, Me.GridColumnid_prod_shopify, Me.GridColumncurrenttag, Me.GridColumndesign_price_prod, Me.GridColumnprice_type_prod, Me.GridColumnqty_prod, Me.GridColumnamount_prod, Me.GridColumnis_block_view_sku, Me.GridColumnorder_qty, Me.GridColumnid_design_price, Me.GridColumnclass, Me.GridColumncolor, Me.GridColumnsht})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsCustomization.AllowSort = False
        Me.GVProduct.OptionsFind.AlwaysVisible = True
        Me.GVProduct.OptionsView.ColumnAutoWidth = False
        Me.GVProduct.OptionsView.ShowFooter = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNoProduct
        '
        Me.GridColumnNoProduct.Caption = "No"
        Me.GridColumnNoProduct.FieldName = "no"
        Me.GridColumnNoProduct.Name = "GridColumnNoProduct"
        Me.GridColumnNoProduct.OptionsColumn.ReadOnly = True
        Me.GridColumnNoProduct.Width = 45
        '
        'GridColumnid_ol_promo_collection_det_prod
        '
        Me.GridColumnid_ol_promo_collection_det_prod.Caption = "id_ol_promo_collection_det"
        Me.GridColumnid_ol_promo_collection_det_prod.FieldName = "id_ol_promo_collection_sku"
        Me.GridColumnid_ol_promo_collection_det_prod.Name = "GridColumnid_ol_promo_collection_det_prod"
        Me.GridColumnid_ol_promo_collection_det_prod.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_ol_promo_collection_prod
        '
        Me.GridColumnid_ol_promo_collection_prod.Caption = "id_ol_promo_collection"
        Me.GridColumnid_ol_promo_collection_prod.FieldName = "id_ol_promo_collection"
        Me.GridColumnid_ol_promo_collection_prod.Name = "GridColumnid_ol_promo_collection_prod"
        Me.GridColumnid_ol_promo_collection_prod.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_design_prod
        '
        Me.GridColumnid_design_prod.Caption = "id_design"
        Me.GridColumnid_design_prod.FieldName = "id_design"
        Me.GridColumnid_design_prod.Name = "GridColumnid_design_prod"
        Me.GridColumnid_design_prod.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "id_product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        Me.GridColumnid_product.OptionsColumn.ReadOnly = True
        '
        'GridColumncodeprod
        '
        Me.GridColumncodeprod.Caption = "Code"
        Me.GridColumncodeprod.FieldName = "code"
        Me.GridColumncodeprod.Name = "GridColumncodeprod"
        Me.GridColumncodeprod.OptionsColumn.ReadOnly = True
        Me.GridColumncodeprod.Visible = True
        Me.GridColumncodeprod.VisibleIndex = 0
        Me.GridColumncodeprod.Width = 100
        '
        'GridColumnname_prod
        '
        Me.GridColumnname_prod.Caption = "Description"
        Me.GridColumnname_prod.FieldName = "name"
        Me.GridColumnname_prod.Name = "GridColumnname_prod"
        Me.GridColumnname_prod.OptionsColumn.ReadOnly = True
        Me.GridColumnname_prod.Visible = True
        Me.GridColumnname_prod.VisibleIndex = 2
        Me.GridColumnname_prod.Width = 263
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.OptionsColumn.ReadOnly = True
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 4
        '
        'GridColumndesign_code
        '
        Me.GridColumndesign_code.Caption = "Main Code"
        Me.GridColumndesign_code.FieldName = "design_code"
        Me.GridColumndesign_code.Name = "GridColumndesign_code"
        Me.GridColumndesign_code.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_prod_shopify
        '
        Me.GridColumnid_prod_shopify.Caption = "id_prod_shopify"
        Me.GridColumnid_prod_shopify.FieldName = "id_prod_shopify"
        Me.GridColumnid_prod_shopify.Name = "GridColumnid_prod_shopify"
        Me.GridColumnid_prod_shopify.OptionsColumn.ReadOnly = True
        '
        'GridColumncurrenttag
        '
        Me.GridColumncurrenttag.Caption = "Current Tag"
        Me.GridColumncurrenttag.FieldName = "current_tag"
        Me.GridColumncurrenttag.Name = "GridColumncurrenttag"
        Me.GridColumncurrenttag.OptionsColumn.ReadOnly = True
        '
        'GridColumndesign_price_prod
        '
        Me.GridColumndesign_price_prod.Caption = "Unit Price"
        Me.GridColumndesign_price_prod.DisplayFormat.FormatString = "N0"
        Me.GridColumndesign_price_prod.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndesign_price_prod.FieldName = "design_price"
        Me.GridColumndesign_price_prod.Name = "GridColumndesign_price_prod"
        Me.GridColumndesign_price_prod.OptionsColumn.ReadOnly = True
        '
        'GridColumnprice_type_prod
        '
        Me.GridColumnprice_type_prod.Caption = "Price Type"
        Me.GridColumnprice_type_prod.FieldName = "price_type"
        Me.GridColumnprice_type_prod.Name = "GridColumnprice_type_prod"
        Me.GridColumnprice_type_prod.OptionsColumn.ReadOnly = True
        '
        'GridColumnqty_prod
        '
        Me.GridColumnqty_prod.Caption = "Qty"
        Me.GridColumnqty_prod.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_prod.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_prod.FieldName = "qty"
        Me.GridColumnqty_prod.Name = "GridColumnqty_prod"
        Me.GridColumnqty_prod.OptionsColumn.ReadOnly = True
        Me.GridColumnqty_prod.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        '
        'GridColumnamount_prod
        '
        Me.GridColumnamount_prod.Caption = "Amount"
        Me.GridColumnamount_prod.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount_prod.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount_prod.FieldName = "amount"
        Me.GridColumnamount_prod.Name = "GridColumnamount_prod"
        Me.GridColumnamount_prod.OptionsColumn.ReadOnly = True
        Me.GridColumnamount_prod.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamount_prod.UnboundExpression = "[qty] * [design_price]"
        Me.GridColumnamount_prod.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        '
        'GridColumnis_block_view_sku
        '
        Me.GridColumnis_block_view_sku.Caption = "Replace Stock"
        Me.GridColumnis_block_view_sku.FieldName = "is_block_view"
        Me.GridColumnis_block_view_sku.Name = "GridColumnis_block_view_sku"
        Me.GridColumnis_block_view_sku.OptionsColumn.ReadOnly = True
        Me.GridColumnis_block_view_sku.Width = 92
        '
        'GridColumnorder_qty
        '
        Me.GridColumnorder_qty.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnorder_qty.AppearanceCell.Options.UseFont = True
        Me.GridColumnorder_qty.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnorder_qty.AppearanceHeader.Options.UseFont = True
        Me.GridColumnorder_qty.Caption = "Qty"
        Me.GridColumnorder_qty.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnorder_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnorder_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnorder_qty.FieldName = "order_qty"
        Me.GridColumnorder_qty.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.GridColumnorder_qty.Name = "GridColumnorder_qty"
        Me.GridColumnorder_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_qty", "{0:N0}")})
        Me.GridColumnorder_qty.Visible = True
        Me.GridColumnorder_qty.VisibleIndex = 5
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "N0"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Mask.EditMask = "N0"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'GridColumnid_design_price
        '
        Me.GridColumnid_design_price.Caption = "id_design_price"
        Me.GridColumnid_design_price.FieldName = "id_design_price"
        Me.GridColumnid_design_price.Name = "GridColumnid_design_price"
        Me.GridColumnid_design_price.OptionsColumn.AllowEdit = False
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.OptionsColumn.ReadOnly = True
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 1
        '
        'GridColumncolor
        '
        Me.GridColumncolor.Caption = "Color"
        Me.GridColumncolor.FieldName = "color"
        Me.GridColumncolor.Name = "GridColumncolor"
        Me.GridColumncolor.OptionsColumn.ReadOnly = True
        Me.GridColumncolor.Visible = True
        Me.GridColumncolor.VisibleIndex = 3
        '
        'GridColumnsht
        '
        Me.GridColumnsht.Caption = "Silhouette"
        Me.GridColumnsht.FieldName = "sht"
        Me.GridColumnsht.Name = "GridColumnsht"
        Me.GridColumnsht.OptionsColumn.ReadOnly = True
        '
        'FormSalesOrderPromoList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 366)
        Me.Controls.Add(Me.GCProduct)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesOrderPromoList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNoProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_ol_promo_collection_det_prod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_ol_promo_collection_prod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_design_prod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncodeprod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname_prod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_prod_shopify As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncurrenttag As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_price_prod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnprice_type_prod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_prod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount_prod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_block_view_sku As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnid_design_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncolor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsht As DevExpress.XtraGrid.Columns.GridColumn
End Class
