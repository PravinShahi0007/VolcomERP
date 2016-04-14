<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterRawMat
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode
        Me.XTCRawMat = New DevExpress.XtraTab.XtraTabControl
        Me.XTPRawMat = New DevExpress.XtraTab.XtraTabPage
        Me.GCRawMat = New DevExpress.XtraGrid.GridControl
        Me.GVRawMat = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumnIdRawMat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRawMaterial = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnSubCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumIdItemcategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnIdItemCategorySub = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRecCreatedRawMat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRecModifiedRawMat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.XTPDetailLot = New DevExpress.XtraTab.XtraTabPage
        Me.GCLot = New DevExpress.XtraGrid.GridControl
        Me.GVLot = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumnRawMatDetail = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnCodeRawMat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnCodeType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnLot = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnMethod = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRecCreated = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRecModified = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnIsActive = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.PCLotTitle = New DevExpress.XtraEditors.PanelControl
        Me.LabelRawMatContent = New DevExpress.XtraEditors.LabelControl
        Me.LabelRawMatTitle = New DevExpress.XtraEditors.LabelControl
        Me.XTPDetailSupplier = New DevExpress.XtraTab.XtraTabPage
        Me.GCSupplier = New DevExpress.XtraGrid.GridControl
        Me.GVSupplier = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumnIdRawMatSupplier = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnCompanyName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnUnitPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRecCreatedSupplier = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRecModifiedSupplier = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnActiveSupplier = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelSupplier = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        CType(Me.XTCRawMat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCRawMat.SuspendLayout()
        Me.XTPRawMat.SuspendLayout()
        CType(Me.GCRawMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRawMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDetailLot.SuspendLayout()
        CType(Me.GCLot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVLot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCLotTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCLotTitle.SuspendLayout()
        Me.XTPDetailSupplier.SuspendLayout()
        CType(Me.GCSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCRawMat
        '
        Me.XTCRawMat.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCRawMat.Appearance.Options.UseFont = True
        Me.XTCRawMat.AppearancePage.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCRawMat.AppearancePage.Header.Options.UseFont = True
        Me.XTCRawMat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCRawMat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCRawMat.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XTCRawMat.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Vertical
        Me.XTCRawMat.Location = New System.Drawing.Point(0, 0)
        Me.XTCRawMat.Name = "XTCRawMat"
        Me.XTCRawMat.SelectedTabPage = Me.XTPRawMat
        Me.XTCRawMat.Size = New System.Drawing.Size(630, 453)
        Me.XTCRawMat.TabIndex = 2
        Me.XTCRawMat.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRawMat, Me.XTPDetailLot, Me.XTPDetailSupplier})
        '
        'XTPRawMat
        '
        Me.XTPRawMat.Controls.Add(Me.GCRawMat)
        Me.XTPRawMat.Name = "XTPRawMat"
        Me.XTPRawMat.Size = New System.Drawing.Size(604, 447)
        Me.XTPRawMat.Text = "Raw Material"
        '
        'GCRawMat
        '
        Me.GCRawMat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRawMat.Location = New System.Drawing.Point(0, 0)
        Me.GCRawMat.MainView = Me.GVRawMat
        Me.GCRawMat.Name = "GCRawMat"
        Me.GCRawMat.Size = New System.Drawing.Size(604, 447)
        Me.GCRawMat.TabIndex = 0
        Me.GCRawMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRawMat, Me.GridView2})
        '
        'GVRawMat
        '
        Me.GVRawMat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdRawMat, Me.ColumnRawMaterial, Me.ColumnUOM, Me.ColumnCategory, Me.ColumnSubCategory, Me.ColumIdItemcategory, Me.ColumnIdItemCategorySub, Me.ColumnRecCreatedRawMat, Me.ColumnRecModifiedRawMat})
        Me.GVRawMat.GridControl = Me.GCRawMat
        Me.GVRawMat.Name = "GVRawMat"
        Me.GVRawMat.OptionsBehavior.Editable = False
        '
        'ColumnIdRawMat
        '
        Me.ColumnIdRawMat.Caption = "Id Raw Mat"
        Me.ColumnIdRawMat.FieldName = "id_raw_mat"
        Me.ColumnIdRawMat.Name = "ColumnIdRawMat"
        '
        'ColumnRawMaterial
        '
        Me.ColumnRawMaterial.Caption = "Raw Material"
        Me.ColumnRawMaterial.FieldName = "raw_mat"
        Me.ColumnRawMaterial.Name = "ColumnRawMaterial"
        Me.ColumnRawMaterial.Visible = True
        Me.ColumnRawMaterial.VisibleIndex = 0
        '
        'ColumnUOM
        '
        Me.ColumnUOM.Caption = "UOM"
        Me.ColumnUOM.FieldName = "uom"
        Me.ColumnUOM.Name = "ColumnUOM"
        Me.ColumnUOM.Visible = True
        Me.ColumnUOM.VisibleIndex = 1
        '
        'ColumnCategory
        '
        Me.ColumnCategory.Caption = "Category"
        Me.ColumnCategory.FieldName = "item_category"
        Me.ColumnCategory.Name = "ColumnCategory"
        Me.ColumnCategory.Visible = True
        Me.ColumnCategory.VisibleIndex = 2
        '
        'ColumnSubCategory
        '
        Me.ColumnSubCategory.Caption = "Sub Category"
        Me.ColumnSubCategory.FieldName = "item_category_sub"
        Me.ColumnSubCategory.Name = "ColumnSubCategory"
        Me.ColumnSubCategory.Visible = True
        Me.ColumnSubCategory.VisibleIndex = 3
        '
        'ColumIdItemcategory
        '
        Me.ColumIdItemcategory.Caption = "Id Item category"
        Me.ColumIdItemcategory.FieldName = "id_item_category"
        Me.ColumIdItemcategory.Name = "ColumIdItemcategory"
        '
        'ColumnIdItemCategorySub
        '
        Me.ColumnIdItemCategorySub.Caption = "Id Item category Sub"
        Me.ColumnIdItemCategorySub.FieldName = "id_item_category_sub"
        Me.ColumnIdItemCategorySub.Name = "ColumnIdItemCategorySub"
        '
        'ColumnRecCreatedRawMat
        '
        Me.ColumnRecCreatedRawMat.Caption = "Record Created"
        Me.ColumnRecCreatedRawMat.FieldName = "time_created"
        Me.ColumnRecCreatedRawMat.Name = "ColumnRecCreatedRawMat"
        Me.ColumnRecCreatedRawMat.Visible = True
        Me.ColumnRecCreatedRawMat.VisibleIndex = 4
        '
        'ColumnRecModifiedRawMat
        '
        Me.ColumnRecModifiedRawMat.Caption = "Record Modified"
        Me.ColumnRecModifiedRawMat.FieldName = "time_modified"
        Me.ColumnRecModifiedRawMat.Name = "ColumnRecModifiedRawMat"
        Me.ColumnRecModifiedRawMat.Visible = True
        Me.ColumnRecModifiedRawMat.VisibleIndex = 5
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCRawMat
        Me.GridView2.Name = "GridView2"
        '
        'XTPDetailLot
        '
        Me.XTPDetailLot.Controls.Add(Me.GCLot)
        Me.XTPDetailLot.Controls.Add(Me.PCLotTitle)
        Me.XTPDetailLot.Name = "XTPDetailLot"
        Me.XTPDetailLot.Size = New System.Drawing.Size(604, 447)
        Me.XTPDetailLot.Text = "Detail Lot"
        '
        'GCLot
        '
        Me.GCLot.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.GCLot.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GCLot.Location = New System.Drawing.Point(0, 46)
        Me.GCLot.MainView = Me.GVLot
        Me.GCLot.Name = "GCLot"
        Me.GCLot.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCLot.Size = New System.Drawing.Size(604, 401)
        Me.GCLot.TabIndex = 7
        Me.GCLot.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVLot})
        '
        'GVLot
        '
        Me.GVLot.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnRawMatDetail, Me.ColumnCodeRawMat, Me.GridColumn1, Me.ColumnCodeType, Me.ColumnColor, Me.ColumnLot, Me.ColumnSize, Me.ColumnMethod, Me.ColumnRecCreated, Me.ColumnRecModified, Me.ColumnIsActive})
        Me.GVLot.GridControl = Me.GCLot
        Me.GVLot.Name = "GVLot"
        Me.GVLot.OptionsBehavior.Editable = False
        '
        'ColumnRawMatDetail
        '
        Me.ColumnRawMatDetail.Caption = "Id Raw Mat Detail"
        Me.ColumnRawMatDetail.FieldName = "id_raw_mat_detail"
        Me.ColumnRawMatDetail.Name = "ColumnRawMatDetail"
        '
        'ColumnCodeRawMat
        '
        Me.ColumnCodeRawMat.Caption = "Code"
        Me.ColumnCodeRawMat.FieldName = "raw_mat_code"
        Me.ColumnCodeRawMat.Name = "ColumnCodeRawMat"
        Me.ColumnCodeRawMat.Visible = True
        Me.ColumnCodeRawMat.VisibleIndex = 0
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Description"
        Me.GridColumn1.FieldName = "raw_mat_detail"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        '
        'ColumnCodeType
        '
        Me.ColumnCodeType.Caption = "Code Type"
        Me.ColumnCodeType.FieldName = "raw_mat_code_name"
        Me.ColumnCodeType.Name = "ColumnCodeType"
        Me.ColumnCodeType.Visible = True
        Me.ColumnCodeType.VisibleIndex = 2
        '
        'ColumnColor
        '
        Me.ColumnColor.Caption = "Color"
        Me.ColumnColor.FieldName = "item_color"
        Me.ColumnColor.Name = "ColumnColor"
        Me.ColumnColor.Visible = True
        Me.ColumnColor.VisibleIndex = 3
        '
        'ColumnLot
        '
        Me.ColumnLot.Caption = "#Lot "
        Me.ColumnLot.FieldName = "lot"
        Me.ColumnLot.Name = "ColumnLot"
        Me.ColumnLot.Visible = True
        Me.ColumnLot.VisibleIndex = 4
        '
        'ColumnSize
        '
        Me.ColumnSize.Caption = "Size/Setting"
        Me.ColumnSize.FieldName = "item_size"
        Me.ColumnSize.Name = "ColumnSize"
        Me.ColumnSize.Visible = True
        Me.ColumnSize.VisibleIndex = 5
        '
        'ColumnMethod
        '
        Me.ColumnMethod.Caption = "Inventory Method"
        Me.ColumnMethod.FieldName = "method"
        Me.ColumnMethod.Name = "ColumnMethod"
        Me.ColumnMethod.Visible = True
        Me.ColumnMethod.VisibleIndex = 6
        '
        'ColumnRecCreated
        '
        Me.ColumnRecCreated.Caption = "Record Created"
        Me.ColumnRecCreated.FieldName = "time_created"
        Me.ColumnRecCreated.Name = "ColumnRecCreated"
        Me.ColumnRecCreated.Visible = True
        Me.ColumnRecCreated.VisibleIndex = 7
        '
        'ColumnRecModified
        '
        Me.ColumnRecModified.Caption = "Record Modified"
        Me.ColumnRecModified.FieldName = "time_modified"
        Me.ColumnRecModified.Name = "ColumnRecModified"
        Me.ColumnRecModified.Visible = True
        Me.ColumnRecModified.VisibleIndex = 8
        '
        'ColumnIsActive
        '
        Me.ColumnIsActive.Caption = "Active"
        Me.ColumnIsActive.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.ColumnIsActive.FieldName = "is_active"
        Me.ColumnIsActive.Name = "ColumnIsActive"
        Me.ColumnIsActive.Visible = True
        Me.ColumnIsActive.VisibleIndex = 9
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'PCLotTitle
        '
        Me.PCLotTitle.Appearance.BackColor = System.Drawing.Color.White
        Me.PCLotTitle.Appearance.Options.UseBackColor = True
        Me.PCLotTitle.Controls.Add(Me.LabelRawMatContent)
        Me.PCLotTitle.Controls.Add(Me.LabelRawMatTitle)
        Me.PCLotTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCLotTitle.Location = New System.Drawing.Point(0, 0)
        Me.PCLotTitle.LookAndFeel.SkinName = "iMaginary"
        Me.PCLotTitle.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCLotTitle.Name = "PCLotTitle"
        Me.PCLotTitle.Size = New System.Drawing.Size(604, 46)
        Me.PCLotTitle.TabIndex = 6
        '
        'LabelRawMatContent
        '
        Me.LabelRawMatContent.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRawMatContent.Location = New System.Drawing.Point(141, 11)
        Me.LabelRawMatContent.Name = "LabelRawMatContent"
        Me.LabelRawMatContent.Size = New System.Drawing.Size(6, 26)
        Me.LabelRawMatContent.TabIndex = 4
        Me.LabelRawMatContent.Text = "-"
        '
        'LabelRawMatTitle
        '
        Me.LabelRawMatTitle.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRawMatTitle.Location = New System.Drawing.Point(6, 10)
        Me.LabelRawMatTitle.Name = "LabelRawMatTitle"
        Me.LabelRawMatTitle.Size = New System.Drawing.Size(129, 26)
        Me.LabelRawMatTitle.TabIndex = 3
        Me.LabelRawMatTitle.Text = "Raw Material : "
        '
        'XTPDetailSupplier
        '
        Me.XTPDetailSupplier.Controls.Add(Me.GCSupplier)
        Me.XTPDetailSupplier.Controls.Add(Me.PanelControl1)
        Me.XTPDetailSupplier.Name = "XTPDetailSupplier"
        Me.XTPDetailSupplier.Size = New System.Drawing.Size(604, 447)
        Me.XTPDetailSupplier.Text = "Detail Supplier"
        '
        'GCSupplier
        '
        Me.GCSupplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSupplier.Location = New System.Drawing.Point(0, 48)
        Me.GCSupplier.MainView = Me.GVSupplier
        Me.GCSupplier.Name = "GCSupplier"
        Me.GCSupplier.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.GCSupplier.Size = New System.Drawing.Size(604, 399)
        Me.GCSupplier.TabIndex = 2
        Me.GCSupplier.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSupplier})
        '
        'GVSupplier
        '
        Me.GVSupplier.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdRawMatSupplier, Me.ColumnCompanyName, Me.ColumnUnitPrice, Me.ColumnRecCreatedSupplier, Me.ColumnRecModifiedSupplier, Me.ColumnActiveSupplier})
        Me.GVSupplier.GridControl = Me.GCSupplier
        Me.GVSupplier.Name = "GVSupplier"
        Me.GVSupplier.OptionsBehavior.Editable = False
        '
        'ColumnIdRawMatSupplier
        '
        Me.ColumnIdRawMatSupplier.Caption = "Id Raw Mat Supplier"
        Me.ColumnIdRawMatSupplier.FieldName = "id_raw_mat_supplier"
        Me.ColumnIdRawMatSupplier.Name = "ColumnIdRawMatSupplier"
        '
        'ColumnCompanyName
        '
        Me.ColumnCompanyName.Caption = "Supplier"
        Me.ColumnCompanyName.FieldName = "company_name"
        Me.ColumnCompanyName.Name = "ColumnCompanyName"
        Me.ColumnCompanyName.Visible = True
        Me.ColumnCompanyName.VisibleIndex = 0
        '
        'ColumnUnitPrice
        '
        Me.ColumnUnitPrice.Caption = "Unit Price"
        Me.ColumnUnitPrice.FieldName = "unit_price"
        Me.ColumnUnitPrice.Name = "ColumnUnitPrice"
        Me.ColumnUnitPrice.Visible = True
        Me.ColumnUnitPrice.VisibleIndex = 1
        '
        'ColumnRecCreatedSupplier
        '
        Me.ColumnRecCreatedSupplier.Caption = "Record Created"
        Me.ColumnRecCreatedSupplier.FieldName = "time_created"
        Me.ColumnRecCreatedSupplier.Name = "ColumnRecCreatedSupplier"
        Me.ColumnRecCreatedSupplier.Visible = True
        Me.ColumnRecCreatedSupplier.VisibleIndex = 2
        '
        'ColumnRecModifiedSupplier
        '
        Me.ColumnRecModifiedSupplier.Caption = "Record Modified"
        Me.ColumnRecModifiedSupplier.FieldName = "time_modified"
        Me.ColumnRecModifiedSupplier.Name = "ColumnRecModifiedSupplier"
        Me.ColumnRecModifiedSupplier.Visible = True
        Me.ColumnRecModifiedSupplier.VisibleIndex = 3
        '
        'ColumnActiveSupplier
        '
        Me.ColumnActiveSupplier.Caption = "Default"
        Me.ColumnActiveSupplier.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.ColumnActiveSupplier.FieldName = "is_default"
        Me.ColumnActiveSupplier.Name = "ColumnActiveSupplier"
        Me.ColumnActiveSupplier.Visible = True
        Me.ColumnActiveSupplier.VisibleIndex = 4
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit2.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelSupplier)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "iMaginary"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(604, 48)
        Me.PanelControl1.TabIndex = 1
        '
        'LabelSupplier
        '
        Me.LabelSupplier.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSupplier.Location = New System.Drawing.Point(205, 11)
        Me.LabelSupplier.Name = "LabelSupplier"
        Me.LabelSupplier.Size = New System.Drawing.Size(6, 26)
        Me.LabelSupplier.TabIndex = 6
        Me.LabelSupplier.Text = "-"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(9, 11)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(198, 26)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Supplier Raw Material  "
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(141, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(0, 26)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "-"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(6, 10)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(0, 26)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Raw Material : "
        '
        'FormMasterRawMat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 453)
        Me.Controls.Add(Me.XTCRawMat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterRawMat"
        Me.ShowInTaskbar = False
        Me.Text = "Master Raw Material"
        CType(Me.XTCRawMat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCRawMat.ResumeLayout(False)
        Me.XTPRawMat.ResumeLayout(False)
        CType(Me.GCRawMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRawMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDetailLot.ResumeLayout(False)
        CType(Me.GCLot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVLot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCLotTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCLotTitle.ResumeLayout(False)
        Me.PCLotTitle.PerformLayout()
        Me.XTPDetailSupplier.ResumeLayout(False)
        CType(Me.GCSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCRawMat As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDetailLot As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PCLotTitle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelRawMatContent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelRawMatTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCLot As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVLot As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnRawMatDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCodeRawMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCodeType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnLot As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnMethod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRecCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRecModified As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnIsActive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents XTPDetailSupplier As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPRawMat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRawMat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRawMat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdRawMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRawMaterial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnSubCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumIdItemcategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnIdItemCategorySub As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnRecCreatedRawMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRecModifiedRawMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSupplier As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSupplier As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdRawMatSupplier As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCompanyName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnUnitPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRecCreatedSupplier As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRecModifiedSupplier As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnActiveSupplier As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents LabelSupplier As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
