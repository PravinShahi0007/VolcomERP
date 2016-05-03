<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBOMSingleWip
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
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GCProductPrice = New DevExpress.XtraGrid.GridControl
        Me.GVProductPrice = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColMatPirce = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPriceName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCurrenct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.TEPriceTot = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl
        Me.TEPrice = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.TEUOM = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit
        Me.TEVendCur = New DevExpress.XtraEditors.TextEdit
        Me.TEKurs = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.TEQty = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.TEVendPrice = New DevExpress.XtraEditors.TextEdit
        Me.LabelControlUpdateName = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.LabelBOMName = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCProductPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProductPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.TEPriceTot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEUOM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVendCur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVendPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupGeneral)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(824, 430)
        Me.SplitContainerControl1.SplitterPosition = 251
        Me.SplitContainerControl1.TabIndex = 30
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCProduct)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(824, 251)
        Me.GroupGeneral.TabIndex = 14
        Me.GroupGeneral.Text = "Material"
        '
        'GCProduct
        '
        Me.GCProduct.Location = New System.Drawing.Point(2, 22)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(820, 219)
        Me.GCProduct.TabIndex = 11
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct, Me.GridView3})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn3, Me.GridColumn4, Me.ColSize, Me.GridColumn2})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupCount = 1
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.Editable = False
        Me.GVProduct.OptionsFind.AlwaysVisible = True
        Me.GVProduct.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        Me.GVProduct.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Mat"
        Me.GridColumn1.FieldName = "id_product"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Code"
        Me.GridColumn6.FieldName = "product_full_code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Material"
        Me.GridColumn3.FieldName = "product_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "UOM"
        Me.GridColumn4.FieldName = "uom"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'ColSize
        '
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "Size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 2
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Season"
        Me.GridColumn2.FieldName = "season"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCProduct
        Me.GridView3.Name = "GridView3"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl1.Controls.Add(Me.GCProductPrice)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(824, 174)
        Me.GroupControl1.TabIndex = 15
        Me.GroupControl1.Text = "Price"
        '
        'GCProductPrice
        '
        Me.GCProductPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProductPrice.Location = New System.Drawing.Point(2, 22)
        Me.GCProductPrice.MainView = Me.GVProductPrice
        Me.GCProductPrice.Name = "GCProductPrice"
        Me.GCProductPrice.Size = New System.Drawing.Size(820, 150)
        Me.GCProductPrice.TabIndex = 3
        Me.GCProductPrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProductPrice, Me.GridView1})
        '
        'GVProductPrice
        '
        Me.GVProductPrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColMatPirce, Me.ColPriceName, Me.ColPrice, Me.ColDate, Me.ColCurrenct})
        Me.GVProductPrice.GridControl = Me.GCProductPrice
        Me.GVProductPrice.Name = "GVProductPrice"
        Me.GVProductPrice.OptionsBehavior.Editable = False
        Me.GVProductPrice.OptionsView.ShowGroupPanel = False
        '
        'ColMatPirce
        '
        Me.ColMatPirce.Caption = "Id Price"
        Me.ColMatPirce.FieldName = "id_product_price"
        Me.ColMatPirce.Name = "ColMatPirce"
        '
        'ColPriceName
        '
        Me.ColPriceName.Caption = "Name"
        Me.ColPriceName.FieldName = "product_price_name"
        Me.ColPriceName.Name = "ColPriceName"
        Me.ColPriceName.Visible = True
        Me.ColPriceName.VisibleIndex = 0
        Me.ColPriceName.Width = 174
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
        Me.ColPrice.FieldName = "product_price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 1
        Me.ColPrice.Width = 174
        '
        'ColDate
        '
        Me.ColDate.Caption = "Date"
        Me.ColDate.FieldName = "product_price_date"
        Me.ColDate.Name = "ColDate"
        Me.ColDate.Visible = True
        Me.ColDate.VisibleIndex = 3
        Me.ColDate.Width = 174
        '
        'ColCurrenct
        '
        Me.ColCurrenct.AppearanceCell.Options.UseTextOptions = True
        Me.ColCurrenct.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColCurrenct.AppearanceHeader.Options.UseTextOptions = True
        Me.ColCurrenct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColCurrenct.Caption = "Currency"
        Me.ColCurrenct.FieldName = "currency"
        Me.ColCurrenct.Name = "ColCurrenct"
        Me.ColCurrenct.Visible = True
        Me.ColCurrenct.VisibleIndex = 2
        Me.ColCurrenct.Width = 60
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GCProductPrice
        Me.GridView1.Name = "GridView1"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.TEPriceTot)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.TEPrice)
        Me.GroupControl2.Controls.Add(Me.LabelControl2)
        Me.GroupControl2.Controls.Add(Me.TEUOM)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.LECurrency)
        Me.GroupControl2.Controls.Add(Me.TEVendCur)
        Me.GroupControl2.Controls.Add(Me.TEKurs)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.TEQty)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Controls.Add(Me.TEVendPrice)
        Me.GroupControl2.Controls.Add(Me.LabelControlUpdateName)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl2.Location = New System.Drawing.Point(0, 430)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(824, 101)
        Me.GroupControl2.TabIndex = 29
        Me.GroupControl2.Text = "Detail"
        '
        'TEPriceTot
        '
        Me.TEPriceTot.Enabled = False
        Me.TEPriceTot.Location = New System.Drawing.Point(573, 67)
        Me.TEPriceTot.Name = "TEPriceTot"
        Me.TEPriceTot.Properties.Appearance.Options.UseTextOptions = True
        Me.TEPriceTot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TEPriceTot.Properties.Mask.EditMask = "N2"
        Me.TEPriceTot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPriceTot.Properties.Mask.SaveLiteral = False
        Me.TEPriceTot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPriceTot.Size = New System.Drawing.Size(238, 20)
        Me.TEPriceTot.TabIndex = 6
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(573, 52)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl7.TabIndex = 116
        Me.LabelControl7.Text = "Total Price"
        '
        'TEPrice
        '
        Me.TEPrice.EditValue = "0"
        Me.TEPrice.Location = New System.Drawing.Point(326, 25)
        Me.TEPrice.Name = "TEPrice"
        Me.TEPrice.Properties.Appearance.Options.UseTextOptions = True
        Me.TEPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEPrice.Properties.Mask.EditMask = "N2"
        Me.TEPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPrice.Properties.Mask.SaveLiteral = False
        Me.TEPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPrice.Size = New System.Drawing.Size(205, 20)
        Me.TEPrice.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(326, 9)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 114
        Me.LabelControl2.Text = "Price"
        '
        'TEUOM
        '
        Me.TEUOM.Enabled = False
        Me.TEUOM.Location = New System.Drawing.Point(447, 67)
        Me.TEUOM.Name = "TEUOM"
        Me.TEUOM.Properties.Appearance.Options.UseTextOptions = True
        Me.TEUOM.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEUOM.Size = New System.Drawing.Size(84, 20)
        Me.TEUOM.TabIndex = 5
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl5.Location = New System.Drawing.Point(35, 50)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(49, 15)
        Me.LabelControl5.TabIndex = 112
        Me.LabelControl5.Text = "Currency"
        '
        'LECurrency
        '
        Me.LECurrency.Enabled = False
        Me.LECurrency.Location = New System.Drawing.Point(35, 67)
        Me.LECurrency.Name = "LECurrency"
        Me.LECurrency.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurrency.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_currency", "Id Currency", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency", "Currency")})
        Me.LECurrency.Properties.NullText = ""
        Me.LECurrency.Properties.ShowFooter = False
        Me.LECurrency.Size = New System.Drawing.Size(84, 20)
        Me.LECurrency.TabIndex = 1
        '
        'TEVendCur
        '
        Me.TEVendCur.Enabled = False
        Me.TEVendCur.Location = New System.Drawing.Point(35, 25)
        Me.TEVendCur.Name = "TEVendCur"
        Me.TEVendCur.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVendCur.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TEVendCur.Size = New System.Drawing.Size(84, 20)
        Me.TEVendCur.TabIndex = 89
        '
        'TEKurs
        '
        Me.TEKurs.EditValue = "1"
        Me.TEKurs.Location = New System.Drawing.Point(125, 67)
        Me.TEKurs.Name = "TEKurs"
        Me.TEKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEKurs.Properties.Mask.EditMask = "N2"
        Me.TEKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEKurs.Properties.Mask.SaveLiteral = False
        Me.TEKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEKurs.Size = New System.Drawing.Size(167, 20)
        Me.TEKurs.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(125, 51)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 88
        Me.LabelControl3.Text = "Kurs"
        '
        'TEQty
        '
        Me.TEQty.EditValue = "1"
        Me.TEQty.Location = New System.Drawing.Point(326, 67)
        Me.TEQty.Name = "TEQty"
        Me.TEQty.Properties.Appearance.Options.UseTextOptions = True
        Me.TEQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEQty.Properties.EditValueChangedDelay = 1
        Me.TEQty.Properties.Mask.EditMask = "N2"
        Me.TEQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEQty.Properties.Mask.SaveLiteral = False
        Me.TEQty.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEQty.Size = New System.Drawing.Size(115, 20)
        Me.TEQty.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(326, 50)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl1.TabIndex = 84
        Me.LabelControl1.Text = "Qty"
        '
        'TEVendPrice
        '
        Me.TEVendPrice.EditValue = "0"
        Me.TEVendPrice.Enabled = False
        Me.TEVendPrice.Location = New System.Drawing.Point(125, 25)
        Me.TEVendPrice.Name = "TEVendPrice"
        Me.TEVendPrice.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVendPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVendPrice.Properties.Mask.EditMask = "N2"
        Me.TEVendPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEVendPrice.Properties.Mask.SaveLiteral = False
        Me.TEVendPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEVendPrice.Size = New System.Drawing.Size(167, 20)
        Me.TEVendPrice.TabIndex = 81
        '
        'LabelControlUpdateName
        '
        Me.LabelControlUpdateName.Location = New System.Drawing.Point(35, 9)
        Me.LabelControlUpdateName.Name = "LabelControlUpdateName"
        Me.LabelControlUpdateName.Size = New System.Drawing.Size(60, 13)
        Me.LabelControlUpdateName.TabIndex = 82
        Me.LabelControlUpdateName.Text = "Vendor Price"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.LabelBOMName)
        Me.PanelControl2.Controls.Add(Me.LabelControl6)
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 531)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(824, 38)
        Me.PanelControl2.TabIndex = 28
        '
        'LabelBOMName
        '
        Me.LabelBOMName.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBOMName.Location = New System.Drawing.Point(95, 6)
        Me.LabelBOMName.Name = "LabelBOMName"
        Me.LabelBOMName.Size = New System.Drawing.Size(6, 26)
        Me.LabelBOMName.TabIndex = 13
        Me.LabelBOMName.Text = "-"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(5, 6)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(84, 26)
        Me.LabelControl6.TabIndex = 12
        Me.LabelControl6.Text = "Method : "
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(665, 9)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(741, 9)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Save"
        '
        'FormBOMSingleWip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 569)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBOMSingleWip"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick WIP"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCProductPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProductPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.TEPriceTot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEUOM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVendCur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVendPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProductPrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProductPrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColMatPirce As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCurrenct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TEPriceTot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEUOM As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TEVendCur As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEVendPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControlUpdateName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelBOMName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
End Class
