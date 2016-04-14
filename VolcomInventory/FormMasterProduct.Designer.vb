<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterProduct
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
        Me.XTCProduct = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDesign = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFabrication = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDisplayName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Orign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBreakSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnActive = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPProduct = New DevExpress.XtraTab.XtraTabPage()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PCLotTitle = New DevExpress.XtraEditors.PanelControl()
        Me.LabelPrintedName = New DevExpress.XtraEditors.LabelControl()
        Me.LDesignTitle = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCProduct.SuspendLayout()
        Me.XTPDesign.SuspendLayout()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPProduct.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCLotTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCLotTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCProduct
        '
        Me.XTCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCProduct.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XTCProduct.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Vertical
        Me.XTCProduct.Location = New System.Drawing.Point(0, 0)
        Me.XTCProduct.Name = "XTCProduct"
        Me.XTCProduct.SelectedTabPage = Me.XTPDesign
        Me.XTCProduct.ShowTabHeader = DevExpress.Utils.DefaultBoolean.[False]
        Me.XTCProduct.Size = New System.Drawing.Size(940, 410)
        Me.XTCProduct.TabIndex = 3
        Me.XTCProduct.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDesign, Me.XTPProduct})
        '
        'XTPDesign
        '
        Me.XTPDesign.Controls.Add(Me.GCDesign)
        Me.XTPDesign.Name = "XTPDesign"
        Me.XTPDesign.Size = New System.Drawing.Size(934, 404)
        Me.XTPDesign.Text = "Design"
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(0, 0)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCDesign.Size = New System.Drawing.Size(934, 404)
        Me.GCDesign.TabIndex = 3
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign, Me.GridView2})
        '
        'GVDesign
        '
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColID, Me.ColName, Me.ColUOM, Me.ColSampleSeason, Me.GridColumn7, Me.GridColumnFabrication, Me.GridColumnOrign, Me.ColSampleCode, Me.ColDisplayName, Me.Orign, Me.GridColumnColor, Me.GridColumnClass, Me.GridColumnBreakSize, Me.GridColumnPrice, Me.GridColumnActive})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.GroupCount = 1
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.Editable = False
        Me.GVDesign.OptionsCustomization.AllowGroup = False
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        Me.GVDesign.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSampleSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn7, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColID, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColID
        '
        Me.ColID.Caption = "Id Sample"
        Me.ColID.FieldName = "id_design"
        Me.ColID.Name = "ColID"
        '
        'ColName
        '
        Me.ColName.Caption = "Design"
        Me.ColName.FieldName = "design_name"
        Me.ColName.Name = "ColName"
        Me.ColName.Width = 99
        '
        'ColUOM
        '
        Me.ColUOM.Caption = "UOM"
        Me.ColUOM.FieldName = "id_uom"
        Me.ColUOM.Name = "ColUOM"
        '
        'ColSampleSeason
        '
        Me.ColSampleSeason.Caption = "Season"
        Me.ColSampleSeason.FieldName = "season"
        Me.ColSampleSeason.FieldNameSortGroup = "id_season"
        Me.ColSampleSeason.Name = "ColSampleSeason"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "id season"
        Me.GridColumn7.FieldName = "id_season"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnFabrication
        '
        Me.GridColumnFabrication.Caption = "Fabrication"
        Me.GridColumnFabrication.FieldName = "design_fabrication"
        Me.GridColumnFabrication.Name = "GridColumnFabrication"
        '
        'GridColumnOrign
        '
        Me.GridColumnOrign.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOrign.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnOrign.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOrign.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnOrign.Caption = "Source"
        Me.GridColumnOrign.FieldName = "product_source"
        Me.GridColumnOrign.Name = "GridColumnOrign"
        Me.GridColumnOrign.Width = 69
        '
        'ColSampleCode
        '
        Me.ColSampleCode.Caption = "Code"
        Me.ColSampleCode.FieldName = "design_code"
        Me.ColSampleCode.Name = "ColSampleCode"
        Me.ColSampleCode.Visible = True
        Me.ColSampleCode.VisibleIndex = 0
        Me.ColSampleCode.Width = 92
        '
        'ColDisplayName
        '
        Me.ColDisplayName.Caption = "Description"
        Me.ColDisplayName.FieldName = "design_display_name"
        Me.ColDisplayName.Name = "ColDisplayName"
        Me.ColDisplayName.Visible = True
        Me.ColDisplayName.VisibleIndex = 1
        Me.ColDisplayName.Width = 92
        '
        'Orign
        '
        Me.Orign.Caption = "Sample"
        Me.Orign.FieldName = "orign"
        Me.Orign.Name = "Orign"
        Me.Orign.Width = 120
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 2
        Me.GridColumnColor.Width = 67
        '
        'GridColumnClass
        '
        Me.GridColumnClass.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnClass.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnClass.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnClass.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnClass.Caption = "Class"
        Me.GridColumnClass.FieldName = "product_class_display"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.Visible = True
        Me.GridColumnClass.VisibleIndex = 3
        Me.GridColumnClass.Width = 64
        '
        'GridColumnBreakSize
        '
        Me.GridColumnBreakSize.Caption = "Size Chart"
        Me.GridColumnBreakSize.FieldName = "size_chart"
        Me.GridColumnBreakSize.Name = "GridColumnBreakSize"
        Me.GridColumnBreakSize.Visible = True
        Me.GridColumnBreakSize.VisibleIndex = 4
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Current Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 5
        '
        'GridColumnActive
        '
        Me.GridColumnActive.Caption = "Active"
        Me.GridColumnActive.FieldName = "active"
        Me.GridColumnActive.Name = "GridColumnActive"
        Me.GridColumnActive.Visible = True
        Me.GridColumnActive.VisibleIndex = 6
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Active"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "Not Active"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCDesign
        Me.GridView2.Name = "GridView2"
        '
        'XTPProduct
        '
        Me.XTPProduct.Controls.Add(Me.GCProduct)
        Me.XTPProduct.Controls.Add(Me.PCLotTitle)
        Me.XTPProduct.Name = "XTPProduct"
        Me.XTPProduct.PageVisible = False
        Me.XTPProduct.Size = New System.Drawing.Size(934, 404)
        Me.XTPProduct.Text = "Product"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(0, 46)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(934, 358)
        Me.GCProduct.TabIndex = 10
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct, Me.GridView3})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn6, Me.GridColumn5})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.Editable = False
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Sample"
        Me.GridColumn1.FieldName = "id_product"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Short Description"
        Me.GridColumn2.FieldName = "product_display_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Description"
        Me.GridColumn3.FieldName = "product_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "UOM"
        Me.GridColumn4.FieldName = "id_uom"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Product Code"
        Me.GridColumn6.FieldName = "product_full_code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Size"
        Me.GridColumn5.FieldName = "Size"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCProduct
        Me.GridView3.Name = "GridView3"
        '
        'PCLotTitle
        '
        Me.PCLotTitle.Appearance.BackColor = System.Drawing.Color.White
        Me.PCLotTitle.Appearance.BackColor2 = System.Drawing.Color.Transparent
        Me.PCLotTitle.Appearance.BorderColor = System.Drawing.Color.White
        Me.PCLotTitle.Appearance.Options.UseBackColor = True
        Me.PCLotTitle.Appearance.Options.UseBorderColor = True
        Me.PCLotTitle.Controls.Add(Me.LabelPrintedName)
        Me.PCLotTitle.Controls.Add(Me.LDesignTitle)
        Me.PCLotTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCLotTitle.Location = New System.Drawing.Point(0, 0)
        Me.PCLotTitle.LookAndFeel.SkinName = "iMaginary"
        Me.PCLotTitle.Name = "PCLotTitle"
        Me.PCLotTitle.Size = New System.Drawing.Size(934, 46)
        Me.PCLotTitle.TabIndex = 9
        '
        'LabelPrintedName
        '
        Me.LabelPrintedName.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPrintedName.Location = New System.Drawing.Point(87, 10)
        Me.LabelPrintedName.Name = "LabelPrintedName"
        Me.LabelPrintedName.Size = New System.Drawing.Size(6, 26)
        Me.LabelPrintedName.TabIndex = 4
        Me.LabelPrintedName.Text = "-"
        '
        'LDesignTitle
        '
        Me.LDesignTitle.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDesignTitle.Location = New System.Drawing.Point(8, 10)
        Me.LDesignTitle.Name = "LDesignTitle"
        Me.LDesignTitle.Size = New System.Drawing.Size(73, 26)
        Me.LDesignTitle.TabIndex = 3
        Me.LDesignTitle.Text = "Design : "
        '
        'FormMasterProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 410)
        Me.Controls.Add(Me.XTCProduct)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterProduct"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Product"
        CType(Me.XTCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCProduct.ResumeLayout(False)
        Me.XTPDesign.ResumeLayout(False)
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPProduct.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCLotTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCLotTitle.ResumeLayout(False)
        Me.PCLotTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCProduct As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDesign As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Orign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPProduct As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PCLotTitle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelPrintedName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LDesignTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBreakSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFabrication As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnActive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
