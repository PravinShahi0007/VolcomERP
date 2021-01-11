<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCompareStockWebsiteDetailBook
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCompareStockWebsiteDetailBook))
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnViewBook = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnid_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncustomer_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsku = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_log_compare_shopify = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.GCData.Size = New System.Drawing.Size(472, 271)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_order, Me.GridColumnorder_date, Me.GridColumnorder_number, Me.GridColumncustomer_name, Me.GridColumnsku, Me.GridColumnqty, Me.GridColumnid_log_compare_shopify})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupCount = 1
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnqty, "{0:N0}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupedColumns = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        Me.GVData.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnorder_number, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'BtnViewBook
        '
        Me.BtnViewBook.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnViewBook.Appearance.Options.UseFont = True
        Me.BtnViewBook.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewBook.Image = CType(resources.GetObject("BtnViewBook.Image"), System.Drawing.Image)
        Me.BtnViewBook.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.BtnViewBook.Location = New System.Drawing.Point(0, 271)
        Me.BtnViewBook.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnViewBook.Name = "BtnViewBook"
        Me.BtnViewBook.Size = New System.Drawing.Size(472, 23)
        Me.BtnViewBook.TabIndex = 3
        Me.BtnViewBook.Text = "Print"
        '
        'GridColumnid_order
        '
        Me.GridColumnid_order.Caption = "id_order"
        Me.GridColumnid_order.FieldName = "id_order"
        Me.GridColumnid_order.Name = "GridColumnid_order"
        '
        'GridColumnorder_date
        '
        Me.GridColumnorder_date.Caption = "Order Date"
        Me.GridColumnorder_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnorder_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnorder_date.FieldName = "order_date"
        Me.GridColumnorder_date.Name = "GridColumnorder_date"
        Me.GridColumnorder_date.Visible = True
        Me.GridColumnorder_date.VisibleIndex = 0
        '
        'GridColumnorder_number
        '
        Me.GridColumnorder_number.Caption = "Order No."
        Me.GridColumnorder_number.FieldName = "order_number"
        Me.GridColumnorder_number.Name = "GridColumnorder_number"
        Me.GridColumnorder_number.Visible = True
        Me.GridColumnorder_number.VisibleIndex = 1
        '
        'GridColumncustomer_name
        '
        Me.GridColumncustomer_name.Caption = "Customer"
        Me.GridColumncustomer_name.FieldName = "customer_name"
        Me.GridColumncustomer_name.Name = "GridColumncustomer_name"
        Me.GridColumncustomer_name.Visible = True
        Me.GridColumncustomer_name.VisibleIndex = 2
        '
        'GridColumnsku
        '
        Me.GridColumnsku.Caption = "SKU"
        Me.GridColumnsku.FieldName = "sku"
        Me.GridColumnsku.Name = "GridColumnsku"
        Me.GridColumnsku.Visible = True
        Me.GridColumnsku.VisibleIndex = 3
        '
        'GridColumnqty
        '
        Me.GridColumnqty.Caption = "Qty"
        Me.GridColumnqty.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty.FieldName = "qty"
        Me.GridColumnqty.Name = "GridColumnqty"
        Me.GridColumnqty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnqty.Visible = True
        Me.GridColumnqty.VisibleIndex = 4
        '
        'GridColumnid_log_compare_shopify
        '
        Me.GridColumnid_log_compare_shopify.Caption = "id_log_compare_shopify"
        Me.GridColumnid_log_compare_shopify.FieldName = "id_log_compare_shopify"
        Me.GridColumnid_log_compare_shopify.Name = "GridColumnid_log_compare_shopify"
        '
        'FormCompareStockWebsiteDetailBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 294)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.BtnViewBook)
        Me.MinimizeBox = False
        Me.Name = "FormCompareStockWebsiteDetailBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Booked Detail"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnViewBook As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncustomer_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsku As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_log_compare_shopify As DevExpress.XtraGrid.Columns.GridColumn
End Class
