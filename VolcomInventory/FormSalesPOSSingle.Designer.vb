<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesPOSSingle
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
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.CheckFilter = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtPrice = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControlProduct = New DevExpress.XtraEditors.GroupControl()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRetailPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignPriceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlImg = New DevExpress.XtraEditors.PanelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.BtnViewImg = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SLEPrice = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnPriceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TxtCurrencyAmount = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCurrencyPrice = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAmount = New DevExpress.XtraEditors.TextEdit()
        Me.SPQty = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.CheckFilter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlProduct.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlImg.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.SLEPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCurrencyAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCurrencyPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.CheckFilter)
        Me.PanelControlNav.Controls.Add(Me.BtnChoose)
        Me.PanelControlNav.Controls.Add(Me.BtnCancel)
        Me.PanelControlNav.Controls.Add(Me.TxtPrice)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 349)
        Me.PanelControlNav.LookAndFeel.SkinName = "Blue"
        Me.PanelControlNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(865, 47)
        Me.PanelControlNav.TabIndex = 4
        '
        'CheckFilter
        '
        Me.CheckFilter.Location = New System.Drawing.Point(10, 16)
        Me.CheckFilter.Name = "CheckFilter"
        Me.CheckFilter.Properties.Caption = "Show only available stock"
        Me.CheckFilter.Size = New System.Drawing.Size(170, 19)
        Me.CheckFilter.TabIndex = 2
        Me.CheckFilter.Visible = False
        '
        'BtnChoose
        '
        Me.BtnChoose.Location = New System.Drawing.Point(778, 12)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 23)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(697, 12)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'TxtPrice
        '
        Me.TxtPrice.EditValue = "0.0"
        Me.TxtPrice.Location = New System.Drawing.Point(217, 15)
        Me.TxtPrice.Name = "TxtPrice"
        Me.TxtPrice.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrice.Properties.Appearance.Options.UseFont = True
        Me.TxtPrice.Properties.Mask.EditMask = "n2"
        Me.TxtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtPrice.Properties.Mask.SaveLiteral = False
        Me.TxtPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtPrice.Properties.NullText = "0"
        Me.TxtPrice.Properties.ReadOnly = True
        Me.TxtPrice.Size = New System.Drawing.Size(205, 20)
        Me.TxtPrice.TabIndex = 137
        Me.TxtPrice.Visible = False
        '
        'GroupControlProduct
        '
        Me.GroupControlProduct.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControlProduct.Controls.Add(Me.GCProduct)
        Me.GroupControlProduct.Controls.Add(Me.PanelControlImg)
        Me.GroupControlProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlProduct.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlProduct.Name = "GroupControlProduct"
        Me.GroupControlProduct.Size = New System.Drawing.Size(865, 289)
        Me.GroupControlProduct.TabIndex = 0
        Me.GroupControlProduct.Text = "Product"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(180, 21)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(683, 266)
        Me.GCProduct.TabIndex = 2
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnColor, Me.GridColumnPrice, Me.GridColumnRetailPrice, Me.GridColumnQty, Me.GridColumnDesignPriceName, Me.GridColumnPriceType, Me.GridColumnCode})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupCount = 1
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsView.ShowFooter = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        Me.GVProduct.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 41
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Width = 147
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        Me.GridColumnSize.Width = 35
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        Me.GridColumnColor.Width = 41
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Delivery Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnPrice.Width = 112
        '
        'GridColumnRetailPrice
        '
        Me.GridColumnRetailPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnRetailPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRetailPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRetailPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRetailPrice.Caption = "Default Price"
        Me.GridColumnRetailPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnRetailPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRetailPrice.FieldName = "design_price_retail"
        Me.GridColumnRetailPrice.Name = "GridColumnRetailPrice"
        Me.GridColumnRetailPrice.Visible = True
        Me.GridColumnRetailPrice.VisibleIndex = 4
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty_all_product"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_all_product", "{0:f2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 5
        Me.GridColumnQty.Width = 88
        '
        'GridColumnDesignPriceName
        '
        Me.GridColumnDesignPriceName.Caption = "Price Name"
        Me.GridColumnDesignPriceName.FieldName = "design_price_name"
        Me.GridColumnDesignPriceName.Name = "GridColumnDesignPriceName"
        Me.GridColumnDesignPriceName.Width = 133
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.Width = 150
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 67
        '
        'PanelControlImg
        '
        Me.PanelControlImg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlImg.Controls.Add(Me.PictureEdit1)
        Me.PanelControlImg.Controls.Add(Me.BtnViewImg)
        Me.PanelControlImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlImg.Location = New System.Drawing.Point(2, 21)
        Me.PanelControlImg.Name = "PanelControlImg"
        Me.PanelControlImg.Size = New System.Drawing.Size(178, 266)
        Me.PanelControlImg.TabIndex = 1
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(178, 243)
        Me.PictureEdit1.TabIndex = 3
        '
        'BtnViewImg
        '
        Me.BtnViewImg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewImg.Location = New System.Drawing.Point(0, 243)
        Me.BtnViewImg.Name = "BtnViewImg"
        Me.BtnViewImg.Size = New System.Drawing.Size(178, 23)
        Me.BtnViewImg.TabIndex = 0
        Me.BtnViewImg.Text = "View Image"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.SLEPrice)
        Me.GroupControl1.Controls.Add(Me.TxtCurrencyAmount)
        Me.GroupControl1.Controls.Add(Me.TxtCurrencyPrice)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.TxtAmount)
        Me.GroupControl1.Controls.Add(Me.SPQty)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 289)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(865, 60)
        Me.GroupControl1.TabIndex = 7
        Me.GroupControl1.Text = "Data Entry"
        '
        'SLEPrice
        '
        Me.SLEPrice.Enabled = False
        Me.SLEPrice.Location = New System.Drawing.Point(108, 30)
        Me.SLEPrice.Name = "SLEPrice"
        Me.SLEPrice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPrice.Properties.NullText = "[Retail price not available]"
        Me.SLEPrice.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEPrice.Size = New System.Drawing.Size(182, 20)
        Me.SLEPrice.TabIndex = 139
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnPriceName, Me.GridColumn3, Me.GridColumnCurr, Me.GridColumn1, Me.GridColumn2, Me.GridColumn4})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnPriceName
        '
        Me.GridColumnPriceName.Caption = "Price Name"
        Me.GridColumnPriceName.FieldName = "design_price_name"
        Me.GridColumnPriceName.Name = "GridColumnPriceName"
        Me.GridColumnPriceName.OptionsColumn.AllowEdit = False
        Me.GridColumnPriceName.Visible = True
        Me.GridColumnPriceName.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created Date"
        Me.GridColumn3.FieldName = "design_price_date"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumnCurr
        '
        Me.GridColumnCurr.Caption = "Currency"
        Me.GridColumnCurr.FieldName = "currency"
        Me.GridColumnCurr.Name = "GridColumnCurr"
        Me.GridColumnCurr.Visible = True
        Me.GridColumnCurr.VisibleIndex = 2
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Price"
        Me.GridColumn1.DisplayFormat.FormatString = "n2"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "design_price"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Price Type"
        Me.GridColumn2.FieldName = "design_price_type"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Price Tag"
        Me.GridColumn4.FieldName = "is_print"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        '
        'TxtCurrencyAmount
        '
        Me.TxtCurrencyAmount.EditValue = "Rp"
        Me.TxtCurrencyAmount.Location = New System.Drawing.Point(599, 30)
        Me.TxtCurrencyAmount.Name = "TxtCurrencyAmount"
        Me.TxtCurrencyAmount.Properties.ReadOnly = True
        Me.TxtCurrencyAmount.Size = New System.Drawing.Size(38, 20)
        Me.TxtCurrencyAmount.TabIndex = 3
        '
        'TxtCurrencyPrice
        '
        Me.TxtCurrencyPrice.EditValue = "Rp"
        Me.TxtCurrencyPrice.Location = New System.Drawing.Point(64, 30)
        Me.TxtCurrencyPrice.Name = "TxtCurrencyPrice"
        Me.TxtCurrencyPrice.Properties.ReadOnly = True
        Me.TxtCurrencyPrice.Size = New System.Drawing.Size(38, 20)
        Me.TxtCurrencyPrice.TabIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(556, 33)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 24
        Me.LabelControl4.Text = "Amount"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 138
        Me.LabelControl1.Text = "Price"
        '
        'TxtAmount
        '
        Me.TxtAmount.EditValue = "0.0"
        Me.TxtAmount.Location = New System.Drawing.Point(643, 30)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.Properties.Appearance.Options.UseFont = True
        Me.TxtAmount.Properties.Mask.EditMask = "n2"
        Me.TxtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAmount.Properties.Mask.SaveLiteral = False
        Me.TxtAmount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtAmount.Properties.NullText = "0"
        Me.TxtAmount.Properties.ReadOnly = True
        Me.TxtAmount.Size = New System.Drawing.Size(210, 20)
        Me.TxtAmount.TabIndex = 136
        '
        'SPQty
        '
        Me.SPQty.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.SPQty.Location = New System.Drawing.Point(384, 30)
        Me.SPQty.Name = "SPQty"
        Me.SPQty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.SPQty.Properties.DisplayFormat.FormatString = "f2"
        Me.SPQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SPQty.Properties.EditValueChangedDelay = 50
        Me.SPQty.Properties.IsFloatValue = False
        Me.SPQty.Properties.Mask.EditMask = "f2"
        Me.SPQty.Properties.Mask.SaveLiteral = False
        Me.SPQty.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.SPQty.Properties.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 131072})
        Me.SPQty.Size = New System.Drawing.Size(135, 20)
        Me.SPQty.TabIndex = 21
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(336, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Quantity"
        '
        'FormSalesPOSSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 396)
        Me.Controls.Add(Me.GroupControlProduct)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControlNav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesPOSSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Product"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.CheckFilter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlProduct.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlImg.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.SLEPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCurrencyAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCurrencyPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SPQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlProduct As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TxtCurrencyAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCurrencyPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SPQty As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlImg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnViewImg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignPriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckFilter As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnRetailPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEPrice As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnPriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
End Class
