<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormABGRoyaltyZone
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormABGRoyaltyZone))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEQuarter = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEYear = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnquarter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumninvoice_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncustomer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsku = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnteritory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndistribution_method = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnproperty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnunit_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnunit_price_usd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngross_sales = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngross_sales_usd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_tax_or_disc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_tax_usd = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEQuarter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEQuarter)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.SLEYear)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(764, 51)
        Me.PanelControl1.TabIndex = 0
        '
        'SLEQuarter
        '
        Me.SLEQuarter.Location = New System.Drawing.Point(226, 16)
        Me.SLEQuarter.Name = "SLEQuarter"
        Me.SLEQuarter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEQuarter.Properties.ShowClearButton = False
        Me.SLEQuarter.Properties.View = Me.GridView1
        Me.SLEQuarter.Size = New System.Drawing.Size(88, 20)
        Me.SLEQuarter.TabIndex = 7
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
        Me.LabelControl2.Location = New System.Drawing.Point(182, 19)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Quarter"
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(320, 14)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(69, 23)
        Me.BtnView.TabIndex = 5
        Me.BtnView.Text = "View"
        '
        'SLEYear
        '
        Me.SLEYear.Location = New System.Drawing.Point(48, 16)
        Me.SLEYear.Name = "SLEYear"
        Me.SLEYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEYear.Properties.ShowClearButton = False
        Me.SLEYear.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEYear.Size = New System.Drawing.Size(128, 20)
        Me.SLEYear.TabIndex = 4
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
        Me.LabelControl1.Location = New System.Drawing.Point(15, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Year"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 51)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(764, 399)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnquarter, Me.GridColumninvoice_date, Me.GridColumncustomer, Me.GridColumnsku, Me.GridColumnteritory, Me.GridColumndistribution_method, Me.GridColumnproperty, Me.GridColumncategory, Me.GridColumnqty, Me.GridColumnunit_price, Me.GridColumnunit_price_usd, Me.GridColumngross_sales, Me.GridColumngross_sales_usd, Me.GridColumnsales_tax_or_disc, Me.GridColumnsales_tax_usd})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupedColumns = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnquarter
        '
        Me.GridColumnquarter.Caption = "QUARTER"
        Me.GridColumnquarter.FieldName = "quarter"
        Me.GridColumnquarter.Name = "GridColumnquarter"
        Me.GridColumnquarter.Visible = True
        Me.GridColumnquarter.VisibleIndex = 0
        '
        'GridColumninvoice_date
        '
        Me.GridColumninvoice_date.Caption = "Invoice Date"
        Me.GridColumninvoice_date.FieldName = "invoice_date"
        Me.GridColumninvoice_date.Name = "GridColumninvoice_date"
        Me.GridColumninvoice_date.Visible = True
        Me.GridColumninvoice_date.VisibleIndex = 1
        '
        'GridColumncustomer
        '
        Me.GridColumncustomer.Caption = "Customer"
        Me.GridColumncustomer.FieldName = "customer"
        Me.GridColumncustomer.Name = "GridColumncustomer"
        Me.GridColumncustomer.Visible = True
        Me.GridColumncustomer.VisibleIndex = 2
        '
        'GridColumnsku
        '
        Me.GridColumnsku.Caption = "SKU"
        Me.GridColumnsku.FieldName = "sku"
        Me.GridColumnsku.Name = "GridColumnsku"
        Me.GridColumnsku.Visible = True
        Me.GridColumnsku.VisibleIndex = 3
        '
        'GridColumnteritory
        '
        Me.GridColumnteritory.Caption = "Teritory"
        Me.GridColumnteritory.FieldName = "teritory"
        Me.GridColumnteritory.Name = "GridColumnteritory"
        Me.GridColumnteritory.Visible = True
        Me.GridColumnteritory.VisibleIndex = 4
        '
        'GridColumndistribution_method
        '
        Me.GridColumndistribution_method.Caption = "Distribution Method"
        Me.GridColumndistribution_method.FieldName = "distribution_method"
        Me.GridColumndistribution_method.Name = "GridColumndistribution_method"
        Me.GridColumndistribution_method.Visible = True
        Me.GridColumndistribution_method.VisibleIndex = 5
        '
        'GridColumnproperty
        '
        Me.GridColumnproperty.Caption = "Property"
        Me.GridColumnproperty.FieldName = "property"
        Me.GridColumnproperty.Name = "GridColumnproperty"
        Me.GridColumnproperty.Visible = True
        Me.GridColumnproperty.VisibleIndex = 6
        '
        'GridColumncategory
        '
        Me.GridColumncategory.Caption = "Category"
        Me.GridColumncategory.FieldName = "category"
        Me.GridColumncategory.Name = "GridColumncategory"
        Me.GridColumncategory.Visible = True
        Me.GridColumncategory.VisibleIndex = 7
        '
        'GridColumnqty
        '
        Me.GridColumnqty.Caption = "Quantity"
        Me.GridColumnqty.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty.FieldName = "qty"
        Me.GridColumnqty.Name = "GridColumnqty"
        Me.GridColumnqty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnqty.Visible = True
        Me.GridColumnqty.VisibleIndex = 8
        '
        'GridColumnunit_price
        '
        Me.GridColumnunit_price.Caption = "Unit Price"
        Me.GridColumnunit_price.DisplayFormat.FormatString = "N0"
        Me.GridColumnunit_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnunit_price.FieldName = "unit_price"
        Me.GridColumnunit_price.Name = "GridColumnunit_price"
        Me.GridColumnunit_price.Visible = True
        Me.GridColumnunit_price.VisibleIndex = 9
        '
        'GridColumnunit_price_usd
        '
        Me.GridColumnunit_price_usd.Caption = "Unit Price (USD)"
        Me.GridColumnunit_price_usd.DisplayFormat.FormatString = "N2"
        Me.GridColumnunit_price_usd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnunit_price_usd.FieldName = "unit_price_usd"
        Me.GridColumnunit_price_usd.Name = "GridColumnunit_price_usd"
        Me.GridColumnunit_price_usd.Visible = True
        Me.GridColumnunit_price_usd.VisibleIndex = 10
        '
        'GridColumngross_sales
        '
        Me.GridColumngross_sales.Caption = "Gross Sales"
        Me.GridColumngross_sales.DisplayFormat.FormatString = "N0"
        Me.GridColumngross_sales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumngross_sales.FieldName = "gross_sales"
        Me.GridColumngross_sales.Name = "GridColumngross_sales"
        Me.GridColumngross_sales.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "gross_sales", "{0:N0}")})
        Me.GridColumngross_sales.Visible = True
        Me.GridColumngross_sales.VisibleIndex = 11
        '
        'GridColumngross_sales_usd
        '
        Me.GridColumngross_sales_usd.Caption = "Gross Sales (USD)"
        Me.GridColumngross_sales_usd.DisplayFormat.FormatString = "N2"
        Me.GridColumngross_sales_usd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumngross_sales_usd.FieldName = "gross_sales_usd"
        Me.GridColumngross_sales_usd.Name = "GridColumngross_sales_usd"
        Me.GridColumngross_sales_usd.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "gross_sales_usd", "{0:N2}")})
        Me.GridColumngross_sales_usd.Visible = True
        Me.GridColumngross_sales_usd.VisibleIndex = 12
        '
        'GridColumnsales_tax_or_disc
        '
        Me.GridColumnsales_tax_or_disc.Caption = "Sales Tax or Discount"
        Me.GridColumnsales_tax_or_disc.DisplayFormat.FormatString = "N0"
        Me.GridColumnsales_tax_or_disc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_tax_or_disc.FieldName = "sales_tax_or_disc"
        Me.GridColumnsales_tax_or_disc.Name = "GridColumnsales_tax_or_disc"
        Me.GridColumnsales_tax_or_disc.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_tax_or_disc", "{0:N0}")})
        Me.GridColumnsales_tax_or_disc.Visible = True
        Me.GridColumnsales_tax_or_disc.VisibleIndex = 13
        '
        'GridColumnsales_tax_usd
        '
        Me.GridColumnsales_tax_usd.Caption = "Sales Tax (USD)"
        Me.GridColumnsales_tax_usd.DisplayFormat.FormatString = "N2"
        Me.GridColumnsales_tax_usd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_tax_usd.FieldName = "sales_tax_usd"
        Me.GridColumnsales_tax_usd.Name = "GridColumnsales_tax_usd"
        Me.GridColumnsales_tax_usd.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_tax_usd", "{0:N2}")})
        Me.GridColumnsales_tax_usd.Visible = True
        Me.GridColumnsales_tax_usd.VisibleIndex = 14
        '
        'FormABGRoyaltyZone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 450)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormABGRoyaltyZone"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABG Royalty Zone"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEQuarter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEYear As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEQuarter As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnquarter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumninvoice_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncustomer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsku As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnteritory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndistribution_method As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnproperty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnunit_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnunit_price_usd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngross_sales As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngross_sales_usd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_tax_or_disc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_tax_usd As DevExpress.XtraGrid.Columns.GridColumn
End Class
