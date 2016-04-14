<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemandBreakSingle
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
        Me.GroupControlProduct = New DevExpress.XtraEditors.GroupControl
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnProductFullCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnProductName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControlForm = New DevExpress.XtraEditors.GroupControl
        Me.TxtProductSize = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.TxtProductName = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.TxtProductCode = New DevExpress.XtraEditors.TextEdit
        Me.LabelNumber = New DevExpress.XtraEditors.LabelControl
        Me.TxtQuantity = New DevExpress.XtraEditors.SpinEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.SLEBOM = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdBOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdProductBom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnBOMName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTermProduction = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUnitPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDateCreated = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.TxtEstimateCost = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelAttention = New DevExpress.XtraEditors.LabelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.SCCSize = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.GCSize = New DevExpress.XtraGrid.GridControl
        Me.GVSize = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnPDAlloc = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyAlloc = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GroupControlProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlProduct.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlForm.SuspendLayout()
        CType(Me.TxtProductSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProductName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProductCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEBOM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.TxtEstimateCost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SCCSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCSize.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControlProduct
        '
        Me.GroupControlProduct.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControlProduct.Controls.Add(Me.GCProduct)
        Me.GroupControlProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlProduct.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlProduct.Name = "GroupControlProduct"
        Me.GroupControlProduct.Size = New System.Drawing.Size(715, 185)
        Me.GroupControlProduct.TabIndex = 0
        Me.GroupControlProduct.Text = "Select Product Size"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(2, 22)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(711, 161)
        Me.GCProduct.TabIndex = 0
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdProduct, Me.GridColumnProductFullCode, Me.GridColumnProductName, Me.GridColumnSize})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.Editable = False
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "IDProduct"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        '
        'GridColumnProductFullCode
        '
        Me.GridColumnProductFullCode.Caption = "Code"
        Me.GridColumnProductFullCode.FieldName = "product_full_code"
        Me.GridColumnProductFullCode.Name = "GridColumnProductFullCode"
        Me.GridColumnProductFullCode.Visible = True
        Me.GridColumnProductFullCode.VisibleIndex = 0
        '
        'GridColumnProductName
        '
        Me.GridColumnProductName.Caption = "Name"
        Me.GridColumnProductName.FieldName = "product_name"
        Me.GridColumnProductName.Name = "GridColumnProductName"
        Me.GridColumnProductName.Visible = True
        Me.GridColumnProductName.VisibleIndex = 1
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "Size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        '
        'GroupControlForm
        '
        Me.GroupControlForm.Controls.Add(Me.TxtProductSize)
        Me.GroupControlForm.Controls.Add(Me.LabelControl4)
        Me.GroupControlForm.Controls.Add(Me.TxtProductName)
        Me.GroupControlForm.Controls.Add(Me.LabelControl1)
        Me.GroupControlForm.Controls.Add(Me.TxtProductCode)
        Me.GroupControlForm.Controls.Add(Me.LabelNumber)
        Me.GroupControlForm.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControlForm.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlForm.Name = "GroupControlForm"
        Me.GroupControlForm.Size = New System.Drawing.Size(715, 10)
        Me.GroupControlForm.TabIndex = 1
        Me.GroupControlForm.Text = "Product Information"
        Me.GroupControlForm.Visible = False
        '
        'TxtProductSize
        '
        Me.TxtProductSize.Location = New System.Drawing.Point(330, 103)
        Me.TxtProductSize.Name = "TxtProductSize"
        Me.TxtProductSize.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProductSize.Properties.Appearance.Options.UseFont = True
        Me.TxtProductSize.Properties.MaxLength = 50
        Me.TxtProductSize.Properties.ReadOnly = True
        Me.TxtProductSize.Size = New System.Drawing.Size(323, 22)
        Me.TxtProductSize.TabIndex = 56
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(330, 61)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(67, 15)
        Me.LabelControl4.TabIndex = 55
        Me.LabelControl4.Text = "Product Size"
        '
        'TxtProductName
        '
        Me.TxtProductName.Location = New System.Drawing.Point(12, 50)
        Me.TxtProductName.Name = "TxtProductName"
        Me.TxtProductName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProductName.Properties.Appearance.Options.UseFont = True
        Me.TxtProductName.Properties.MaxLength = 50
        Me.TxtProductName.Properties.ReadOnly = True
        Me.TxtProductName.Size = New System.Drawing.Size(641, 22)
        Me.TxtProductName.TabIndex = 50
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 8)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(77, 15)
        Me.LabelControl1.TabIndex = 49
        Me.LabelControl1.Text = "Product Name"
        '
        'TxtProductCode
        '
        Me.TxtProductCode.Location = New System.Drawing.Point(12, 103)
        Me.TxtProductCode.Name = "TxtProductCode"
        Me.TxtProductCode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProductCode.Properties.Appearance.Options.UseFont = True
        Me.TxtProductCode.Properties.MaxLength = 50
        Me.TxtProductCode.Properties.ReadOnly = True
        Me.TxtProductCode.Size = New System.Drawing.Size(312, 22)
        Me.TxtProductCode.TabIndex = 47
        '
        'LabelNumber
        '
        Me.LabelNumber.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumber.Location = New System.Drawing.Point(12, 61)
        Me.LabelNumber.Name = "LabelNumber"
        Me.LabelNumber.Size = New System.Drawing.Size(73, 15)
        Me.LabelNumber.TabIndex = 48
        Me.LabelNumber.Text = "Product Code"
        '
        'TxtQuantity
        '
        Me.TxtQuantity.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtQuantity.Location = New System.Drawing.Point(638, 30)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQuantity.Properties.Appearance.Options.UseFont = True
        Me.TxtQuantity.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.TxtQuantity.Properties.IsFloatValue = False
        Me.TxtQuantity.Properties.Mask.EditMask = "N00"
        Me.TxtQuantity.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.TxtQuantity.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtQuantity.Size = New System.Drawing.Size(65, 22)
        Me.TxtQuantity.TabIndex = 3
        Me.TxtQuantity.Visible = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(606, 33)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(19, 15)
        Me.LabelControl3.TabIndex = 53
        Me.LabelControl3.Text = "Qty"
        Me.LabelControl3.Visible = False
        '
        'SLEBOM
        '
        Me.SLEBOM.EditValue = "[Eda"
        Me.SLEBOM.Location = New System.Drawing.Point(107, 30)
        Me.SLEBOM.Name = "SLEBOM"
        Me.SLEBOM.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEBOM.Properties.Appearance.Options.UseFont = True
        Me.SLEBOM.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEBOM.Properties.NullText = "-Nothing BOM List-"
        Me.SLEBOM.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEBOM.Size = New System.Drawing.Size(206, 22)
        Me.SLEBOM.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdBOM, Me.GridColumnIdProductBom, Me.GridColumnBOMName, Me.GridColumnTermProduction, Me.GridColumnUnitPrice, Me.GridColumnDateCreated})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdBOM
        '
        Me.GridColumnIdBOM.Caption = "IdBom"
        Me.GridColumnIdBOM.FieldName = "id_bom"
        Me.GridColumnIdBOM.Name = "GridColumnIdBOM"
        '
        'GridColumnIdProductBom
        '
        Me.GridColumnIdProductBom.Caption = "IdProduct"
        Me.GridColumnIdProductBom.FieldName = "id_product"
        Me.GridColumnIdProductBom.Name = "GridColumnIdProductBom"
        '
        'GridColumnBOMName
        '
        Me.GridColumnBOMName.Caption = "BOM Name"
        Me.GridColumnBOMName.FieldName = "bom_name"
        Me.GridColumnBOMName.Name = "GridColumnBOMName"
        Me.GridColumnBOMName.Visible = True
        Me.GridColumnBOMName.VisibleIndex = 0
        '
        'GridColumnTermProduction
        '
        Me.GridColumnTermProduction.Caption = "Term Production"
        Me.GridColumnTermProduction.FieldName = "term_production"
        Me.GridColumnTermProduction.Name = "GridColumnTermProduction"
        Me.GridColumnTermProduction.Visible = True
        Me.GridColumnTermProduction.VisibleIndex = 1
        '
        'GridColumnUnitPrice
        '
        Me.GridColumnUnitPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumnUnitPrice.Caption = "Unit Price"
        Me.GridColumnUnitPrice.FieldName = "bom_unit_price"
        Me.GridColumnUnitPrice.Name = "GridColumnUnitPrice"
        Me.GridColumnUnitPrice.Visible = True
        Me.GridColumnUnitPrice.VisibleIndex = 2
        '
        'GridColumnDateCreated
        '
        Me.GridColumnDateCreated.Caption = "Created Date"
        Me.GridColumnDateCreated.FieldName = "bom_date_created"
        Me.GridColumnDateCreated.Name = "GridColumnDateCreated"
        Me.GridColumnDateCreated.Visible = True
        Me.GridColumnDateCreated.VisibleIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(89, 15)
        Me.LabelControl2.TabIndex = 51
        Me.LabelControl2.Text = "Bill Of Material "
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.TxtEstimateCost)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.SLEBOM)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.TxtQuantity)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 10)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(715, 62)
        Me.GroupControl1.TabIndex = 57
        Me.GroupControl1.Text = "Estimate Price"
        '
        'TxtEstimateCost
        '
        Me.TxtEstimateCost.Location = New System.Drawing.Point(403, 30)
        Me.TxtEstimateCost.Name = "TxtEstimateCost"
        Me.TxtEstimateCost.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstimateCost.Properties.Appearance.Options.UseFont = True
        Me.TxtEstimateCost.Properties.Mask.EditMask = "N2"
        Me.TxtEstimateCost.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtEstimateCost.Properties.MaxLength = 50
        Me.TxtEstimateCost.Properties.ReadOnly = True
        Me.TxtEstimateCost.Size = New System.Drawing.Size(197, 22)
        Me.TxtEstimateCost.TabIndex = 2
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(324, 33)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(73, 15)
        Me.LabelControl5.TabIndex = 57
        Me.LabelControl5.Text = "Estimate COP"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelAttention)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 486)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(715, 31)
        Me.PanelControl1.TabIndex = 60
        '
        'LabelAttention
        '
        Me.LabelAttention.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelAttention.Location = New System.Drawing.Point(12, 9)
        Me.LabelAttention.Name = "LabelAttention"
        Me.LabelAttention.Size = New System.Drawing.Size(237, 13)
        Me.LabelAttention.TabIndex = 6
        Me.LabelAttention.Text = "This sample is not found in sample requisition list !"
        Me.LabelAttention.Visible = False
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(563, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 27)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(638, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 27)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Save"
        '
        'SCCSize
        '
        Me.SCCSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCSize.Horizontal = False
        Me.SCCSize.Location = New System.Drawing.Point(0, 0)
        Me.SCCSize.Name = "SCCSize"
        Me.SCCSize.Panel1.Controls.Add(Me.GroupControlProduct)
        Me.SCCSize.Panel1.Text = "Panel1"
        Me.SCCSize.Panel2.Controls.Add(Me.GroupControl2)
        Me.SCCSize.Panel2.Controls.Add(Me.GroupControl1)
        Me.SCCSize.Panel2.Controls.Add(Me.GroupControlForm)
        Me.SCCSize.Panel2.Text = "Panel2"
        Me.SCCSize.Size = New System.Drawing.Size(715, 486)
        Me.SCCSize.SplitterPosition = 185
        Me.SCCSize.TabIndex = 61
        Me.SCCSize.Text = "SplitContainerControl1"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCSize)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 72)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(715, 224)
        Me.GroupControl2.TabIndex = 58
        Me.GroupControl2.Text = "Allocation List"
        '
        'GCSize
        '
        Me.GCSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSize.Location = New System.Drawing.Point(2, 22)
        Me.GCSize.MainView = Me.GVSize
        Me.GCSize.Name = "GCSize"
        Me.GCSize.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCSize.Size = New System.Drawing.Size(711, 200)
        Me.GCSize.TabIndex = 0
        Me.GCSize.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSize})
        '
        'GVSize
        '
        Me.GVSize.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnPDAlloc, Me.GridColumnQtyAlloc, Me.GridColumnId})
        Me.GVSize.GridControl = Me.GCSize
        Me.GVSize.Name = "GVSize"
        Me.GVSize.OptionsCustomization.AllowFilter = False
        Me.GVSize.OptionsCustomization.AllowGroup = False
        Me.GVSize.OptionsView.ShowFooter = True
        Me.GVSize.OptionsView.ShowGroupPanel = False
        '
        'GridColumnPDAlloc
        '
        Me.GridColumnPDAlloc.Caption = "Allocation For"
        Me.GridColumnPDAlloc.FieldName = "pd_alloc"
        Me.GridColumnPDAlloc.Name = "GridColumnPDAlloc"
        Me.GridColumnPDAlloc.OptionsColumn.ReadOnly = True
        Me.GridColumnPDAlloc.Visible = True
        Me.GridColumnPDAlloc.VisibleIndex = 0
        '
        'GridColumnQtyAlloc
        '
        Me.GridColumnQtyAlloc.Caption = "Qty"
        Me.GridColumnQtyAlloc.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQtyAlloc.FieldName = "prod_demand_alloc_qty"
        Me.GridColumnQtyAlloc.Name = "GridColumnQtyAlloc"
        Me.GridColumnQtyAlloc.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_demand_alloc_qty", "{0:f0}")})
        Me.GridColumnQtyAlloc.Visible = True
        Me.GridColumnQtyAlloc.VisibleIndex = 1
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.IsFloatValue = False
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.Mask.SaveLiteral = False
        Me.RepositoryItemSpinEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_prod_demand_alloc"
        Me.GridColumnId.Name = "GridColumnId"
        Me.GridColumnId.OptionsColumn.ShowInCustomizationForm = False
        '
        'FormProdDemandBreakSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(715, 517)
        Me.Controls.Add(Me.SCCSize)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdDemandBreakSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Breakdown Size"
        CType(Me.GroupControlProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlProduct.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlForm.ResumeLayout(False)
        Me.GroupControlForm.PerformLayout()
        CType(Me.TxtProductSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProductName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProductCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEBOM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.TxtEstimateCost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SCCSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCSize.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControlProduct As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControlForm As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TxtProductCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtProductName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEBOM As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TxtQuantity As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductFullCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TxtProductSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnIdBOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProductBom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTermProduction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUnitPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDateCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBOMName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TxtEstimateCost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelAttention As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SCCSize As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSize As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSize As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnPDAlloc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyAlloc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
End Class
