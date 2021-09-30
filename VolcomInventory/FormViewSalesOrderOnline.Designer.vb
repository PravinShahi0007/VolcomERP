<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormViewSalesOrderOnline
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
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesTarget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEanCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesOrderDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesignPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOLStoreId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncolor = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnPriceType, Me.GridColumnQty, Me.GridColumnPrice, Me.GridColumnAmount, Me.GridColumnRemark, Me.GridColumnUOM, Me.GridColumnIdSalesTarget, Me.GridColumnEanCode, Me.GridColumnIdDesign, Me.GridColumnIdProduct, Me.GridColumnIdSample, Me.GridColumnIdSalesOrderDet, Me.GridColumnIdDesignPrice, Me.GridColumnItemId, Me.GridColumnOLStoreId, Me.GridColumnclass, Me.GridColumncolor})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItemList.OptionsView.ShowFooter = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 55
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.ReadOnly = True
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 3
        Me.GridColumnCode.Width = 90
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.ReadOnly = True
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 5
        Me.GridColumnName.Width = 190
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.ReadOnly = True
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 7
        Me.GridColumnSize.Width = 70
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.OptionsColumn.AllowEdit = False
        Me.GridColumnPriceType.OptionsColumn.ReadOnly = True
        Me.GridColumnPriceType.Visible = True
        Me.GridColumnPriceType.VisibleIndex = 8
        Me.GridColumnPriceType.Width = 131
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.DisplayFormat.FormatString = "F2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sales_order_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.OptionsColumn.AllowShowHide = False
        Me.GridColumnQty.OptionsColumn.ReadOnly = True
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_qty", "{0:f2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 9
        Me.GridColumnQty.Width = 117
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.OptionsColumn.ReadOnly = True
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 10
        Me.GridColumnPrice.Width = 142
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.ReadOnly = True
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:n2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 11
        Me.GridColumnAmount.Width = 162
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sales_order_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 12
        Me.GridColumnRemark.Width = 302
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnUOM.Width = 71
        '
        'GridColumnIdSalesTarget
        '
        Me.GridColumnIdSalesTarget.Caption = "ID Sales Target"
        Me.GridColumnIdSalesTarget.FieldName = "id_sales_target"
        Me.GridColumnIdSalesTarget.Name = "GridColumnIdSalesTarget"
        Me.GridColumnIdSalesTarget.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSalesTarget.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdSalesTarget.Width = 83
        '
        'GridColumnEanCode
        '
        Me.GridColumnEanCode.Caption = "EAN Code"
        Me.GridColumnEanCode.FieldName = "ean_code"
        Me.GridColumnEanCode.Name = "GridColumnEanCode"
        Me.GridColumnEanCode.OptionsColumn.AllowEdit = False
        Me.GridColumnEanCode.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdDesign
        '
        Me.GridColumnIdDesign.Caption = "id design"
        Me.GridColumnIdDesign.FieldName = "id_design"
        Me.GridColumnIdDesign.Name = "GridColumnIdDesign"
        Me.GridColumnIdDesign.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        Me.GridColumnIdProduct.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSalesOrderDet
        '
        Me.GridColumnIdSalesOrderDet.Caption = "Id Sales Order Det"
        Me.GridColumnIdSalesOrderDet.FieldName = "id_sales_order_det"
        Me.GridColumnIdSalesOrderDet.Name = "GridColumnIdSalesOrderDet"
        Me.GridColumnIdSalesOrderDet.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSalesOrderDet.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdSalesOrderDet.Width = 98
        '
        'GridColumnIdDesignPrice
        '
        Me.GridColumnIdDesignPrice.Caption = "Id Design Price"
        Me.GridColumnIdDesignPrice.FieldName = "id_design_price"
        Me.GridColumnIdDesignPrice.Name = "GridColumnIdDesignPrice"
        Me.GridColumnIdDesignPrice.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdDesignPrice.Width = 80
        '
        'GridColumnItemId
        '
        Me.GridColumnItemId.Caption = "Item Id"
        Me.GridColumnItemId.FieldName = "item_id"
        Me.GridColumnItemId.Name = "GridColumnItemId"
        Me.GridColumnItemId.Visible = True
        Me.GridColumnItemId.VisibleIndex = 1
        Me.GridColumnItemId.Width = 98
        '
        'GridColumnOLStoreId
        '
        Me.GridColumnOLStoreId.Caption = "OL Store Id"
        Me.GridColumnOLStoreId.FieldName = "ol_store_id"
        Me.GridColumnOLStoreId.Name = "GridColumnOLStoreId"
        Me.GridColumnOLStoreId.Visible = True
        Me.GridColumnOLStoreId.VisibleIndex = 2
        Me.GridColumnOLStoreId.Width = 98
        '
        'GCItemList
        '
        Me.GCItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemList.Location = New System.Drawing.Point(0, 0)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(663, 261)
        Me.GCItemList.TabIndex = 3
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.OptionsColumn.ReadOnly = True
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 4
        Me.GridColumnclass.Width = 67
        '
        'GridColumncolor
        '
        Me.GridColumncolor.Caption = "Color"
        Me.GridColumncolor.FieldName = "color"
        Me.GridColumncolor.Name = "GridColumncolor"
        Me.GridColumncolor.OptionsColumn.ReadOnly = True
        Me.GridColumncolor.Visible = True
        Me.GridColumncolor.VisibleIndex = 6
        Me.GridColumncolor.Width = 110
        '
        'FormViewSalesOrderOnline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 261)
        Me.Controls.Add(Me.GCItemList)
        Me.Name = "FormViewSalesOrderOnline"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormViewSalesOrderOnline"
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesTarget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEanCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesOrderDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesignPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOLStoreId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncolor As DevExpress.XtraGrid.Columns.GridColumn
End Class
