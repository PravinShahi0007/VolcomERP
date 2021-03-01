<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLReturnRefuseAddNonFisik
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnid_sales_order_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_pl_sales_order_del_det_counting = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode_list = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnitem_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnol_store_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_used = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(590, 261)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_order_det, Me.GridColumnid_pl_sales_order_del_det_counting, Me.GridColumnid_product, Me.GridColumncode_list, Me.GridColumnname, Me.GridColumnsize, Me.GridColumnitem_id, Me.GridColumnol_store_id, Me.GridColumnqty, Me.GridColumnid_design_price, Me.GridColumndesign_price, Me.GridColumnis_used})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnChoose.Location = New System.Drawing.Point(0, 261)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(590, 46)
        Me.BtnChoose.TabIndex = 2
        Me.BtnChoose.Text = "Choose"
        '
        'GridColumnid_sales_order_det
        '
        Me.GridColumnid_sales_order_det.Caption = "id_sales_order_det"
        Me.GridColumnid_sales_order_det.FieldName = "id_sales_order_det"
        Me.GridColumnid_sales_order_det.Name = "GridColumnid_sales_order_det"
        '
        'GridColumnid_pl_sales_order_del_det_counting
        '
        Me.GridColumnid_pl_sales_order_del_det_counting.Caption = "id_pl_sales_order_del_det_counting"
        Me.GridColumnid_pl_sales_order_del_det_counting.FieldName = "id_pl_sales_order_del_det_counting"
        Me.GridColumnid_pl_sales_order_del_det_counting.Name = "GridColumnid_pl_sales_order_del_det_counting"
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "id_product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        '
        'GridColumncode_list
        '
        Me.GridColumncode_list.Caption = "Code"
        Me.GridColumncode_list.FieldName = "code_list"
        Me.GridColumncode_list.Name = "GridColumncode_list"
        Me.GridColumncode_list.Visible = True
        Me.GridColumncode_list.VisibleIndex = 0
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 1
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 2
        '
        'GridColumnitem_id
        '
        Me.GridColumnitem_id.Caption = "Item Id"
        Me.GridColumnitem_id.FieldName = "item_id"
        Me.GridColumnitem_id.Name = "GridColumnitem_id"
        Me.GridColumnitem_id.Visible = True
        Me.GridColumnitem_id.VisibleIndex = 3
        '
        'GridColumnol_store_id
        '
        Me.GridColumnol_store_id.Caption = "Ol. Store Id"
        Me.GridColumnol_store_id.FieldName = "ol_store_id"
        Me.GridColumnol_store_id.Name = "GridColumnol_store_id"
        Me.GridColumnol_store_id.Visible = True
        Me.GridColumnol_store_id.VisibleIndex = 4
        '
        'GridColumnqty
        '
        Me.GridColumnqty.Caption = "Qty"
        Me.GridColumnqty.FieldName = "qty"
        Me.GridColumnqty.Name = "GridColumnqty"
        '
        'GridColumnid_design_price
        '
        Me.GridColumnid_design_price.Caption = "id_design_price"
        Me.GridColumnid_design_price.FieldName = "id_design_price"
        Me.GridColumnid_design_price.Name = "GridColumnid_design_price"
        '
        'GridColumndesign_price
        '
        Me.GridColumndesign_price.Caption = "Unit Price"
        Me.GridColumndesign_price.DisplayFormat.FormatString = "N0"
        Me.GridColumndesign_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndesign_price.FieldName = "design_price"
        Me.GridColumndesign_price.Name = "GridColumndesign_price"
        Me.GridColumndesign_price.Visible = True
        Me.GridColumndesign_price.VisibleIndex = 5
        '
        'GridColumnis_used
        '
        Me.GridColumnis_used.Caption = "is_used"
        Me.GridColumnis_used.FieldName = "is_used"
        Me.GridColumnis_used.Name = "GridColumnis_used"
        '
        'FormOLReturnRefuseAddNonFisik
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 307)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.BtnChoose)
        Me.Name = "FormOLReturnRefuseAddNonFisik"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Items"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_sales_order_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_pl_sales_order_del_det_counting As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode_list As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnitem_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnol_store_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_design_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_used As DevExpress.XtraGrid.Columns.GridColumn
End Class
