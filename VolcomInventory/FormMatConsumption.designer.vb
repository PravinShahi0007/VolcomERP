<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatConsumption
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.GCDesign = New DevExpress.XtraGrid.GridControl
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDisplayName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSampleSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSampleCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Orign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnOrign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNamaDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColProductCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColProductname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIDSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XTCFabCon = New DevExpress.XtraTab.XtraTabControl
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage
        Me.GCFabCon = New DevExpress.XtraGrid.GridControl
        Me.GVFabCon = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCFabCon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCFabCon.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GCFabCon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFabCon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(746, 336)
        Me.SplitContainerControl1.SplitterPosition = 165
        Me.SplitContainerControl1.TabIndex = 29
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCDesign)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(746, 165)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Design"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCProduct)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(746, 166)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Consumption"
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(2, 22)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(742, 141)
        Me.GCDesign.TabIndex = 4
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign, Me.GridView2})
        '
        'GVDesign
        '
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColID, Me.ColDisplayName, Me.ColName, Me.ColUOM, Me.ColSampleSeason, Me.ColSampleCode, Me.Orign, Me.ColIdSeason, Me.GridColumnColor, Me.GridColumnOrign, Me.GridColumnClass})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.GroupCount = 1
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.Editable = False
        Me.GVDesign.OptionsCustomization.AllowGroup = False
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        Me.GVDesign.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColID
        '
        Me.ColID.Caption = "Id Sample"
        Me.ColID.FieldName = "id_design"
        Me.ColID.Name = "ColID"
        '
        'ColDisplayName
        '
        Me.ColDisplayName.Caption = "Short Description"
        Me.ColDisplayName.FieldName = "design_display_name"
        Me.ColDisplayName.Name = "ColDisplayName"
        Me.ColDisplayName.Visible = True
        Me.ColDisplayName.VisibleIndex = 3
        Me.ColDisplayName.Width = 92
        '
        'ColName
        '
        Me.ColName.Caption = "Description"
        Me.ColName.FieldName = "design_name"
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 4
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
        Me.ColSampleSeason.Name = "ColSampleSeason"
        '
        'ColSampleCode
        '
        Me.ColSampleCode.Caption = "Code"
        Me.ColSampleCode.FieldName = "design_code"
        Me.ColSampleCode.Name = "ColSampleCode"
        Me.ColSampleCode.Visible = True
        Me.ColSampleCode.VisibleIndex = 2
        Me.ColSampleCode.Width = 92
        '
        'Orign
        '
        Me.Orign.Caption = "Design Orign"
        Me.Orign.FieldName = "orign"
        Me.Orign.Name = "Orign"
        Me.Orign.Visible = True
        Me.Orign.VisibleIndex = 6
        Me.Orign.Width = 120
        '
        'ColIdSeason
        '
        Me.ColIdSeason.Caption = "Season"
        Me.ColIdSeason.FieldName = "id_season"
        Me.ColIdSeason.Name = "ColIdSeason"
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
        Me.GridColumnColor.VisibleIndex = 5
        Me.GridColumnColor.Width = 67
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
        Me.GridColumnOrign.Visible = True
        Me.GridColumnOrign.VisibleIndex = 0
        Me.GridColumnOrign.Width = 69
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
        Me.GridColumnClass.VisibleIndex = 1
        Me.GridColumnClass.Width = 64
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCDesign
        Me.GridView2.Name = "GridView2"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(2, 22)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(742, 142)
        Me.GCProduct.TabIndex = 1
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdProduct, Me.ColIdDesign, Me.GridColumn1, Me.ColNamaDesign, Me.ColProductCode, Me.ColProductname, Me.ColSeason, Me.ColSize, Me.GridColumnIDSeason})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupCount = 2
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.Editable = False
        Me.GVProduct.OptionsFind.AlwaysVisible = True
        Me.GVProduct.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        Me.GVProduct.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColNamaDesign, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdDesign, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'ColIdProduct
        '
        Me.ColIdProduct.Caption = "ID Product"
        Me.ColIdProduct.FieldName = "id_product"
        Me.ColIdProduct.Name = "ColIdProduct"
        '
        'ColIdDesign
        '
        Me.ColIdDesign.Caption = "ID Design"
        Me.ColIdDesign.FieldName = "id_design"
        Me.ColIdDesign.Name = "ColIdDesign"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Season"
        Me.GridColumn1.FieldName = "id_season"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'ColNamaDesign
        '
        Me.ColNamaDesign.Caption = "Design"
        Me.ColNamaDesign.FieldName = "design_name"
        Me.ColNamaDesign.FieldNameSortGroup = "id_design"
        Me.ColNamaDesign.Name = "ColNamaDesign"
        '
        'ColProductCode
        '
        Me.ColProductCode.Caption = "Code"
        Me.ColProductCode.FieldName = "product_full_code"
        Me.ColProductCode.Name = "ColProductCode"
        Me.ColProductCode.Visible = True
        Me.ColProductCode.VisibleIndex = 0
        Me.ColProductCode.Width = 147
        '
        'ColProductname
        '
        Me.ColProductname.Caption = "Product"
        Me.ColProductname.FieldName = "product_name"
        Me.ColProductname.Name = "ColProductname"
        Me.ColProductname.Visible = True
        Me.ColProductname.VisibleIndex = 1
        Me.ColProductname.Width = 147
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.FieldNameSortGroup = "id_season"
        Me.ColSeason.Name = "ColSeason"
        '
        'ColSize
        '
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "Size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 2
        Me.ColSize.Width = 80
        '
        'GridColumnIDSeason
        '
        Me.GridColumnIDSeason.Caption = "ID Season"
        Me.GridColumnIDSeason.FieldName = "id_season"
        Me.GridColumnIDSeason.Name = "GridColumnIDSeason"
        '
        'XTCFabCon
        '
        Me.XTCFabCon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCFabCon.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCFabCon.Location = New System.Drawing.Point(0, 0)
        Me.XTCFabCon.Name = "XTCFabCon"
        Me.XTCFabCon.SelectedTabPage = Me.XtraTabPage1
        Me.XTCFabCon.Size = New System.Drawing.Size(752, 362)
        Me.XTCFabCon.TabIndex = 30
        Me.XTCFabCon.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.SplitContainerControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(746, 336)
        Me.XtraTabPage1.Text = "Design List"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GCFabCon)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(746, 336)
        Me.XtraTabPage2.Text = "List Fabric Consumption"
        '
        'GCFabCon
        '
        Me.GCFabCon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFabCon.Location = New System.Drawing.Point(0, 0)
        Me.GCFabCon.MainView = Me.GVFabCon
        Me.GCFabCon.Name = "GCFabCon"
        Me.GCFabCon.Size = New System.Drawing.Size(746, 336)
        Me.GCFabCon.TabIndex = 2
        Me.GCFabCon.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFabCon})
        '
        'GVFabCon
        '
        Me.GVFabCon.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GVFabCon.GridControl = Me.GCFabCon
        Me.GVFabCon.GroupCount = 2
        Me.GVFabCon.Name = "GVFabCon"
        Me.GVFabCon.OptionsBehavior.Editable = False
        Me.GVFabCon.OptionsFind.AlwaysVisible = True
        Me.GVFabCon.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVFabCon.OptionsView.ShowGroupPanel = False
        Me.GVFabCon.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn8, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn5, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn3, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID Product"
        Me.GridColumn2.FieldName = "id_product"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ID Design"
        Me.GridColumn3.FieldName = "id_design"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID Season"
        Me.GridColumn4.FieldName = "id_season"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Design"
        Me.GridColumn5.FieldName = "design_name"
        Me.GridColumn5.FieldNameSortGroup = "id_design"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Number"
        Me.GridColumn6.FieldName = "product_full_code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        Me.GridColumn6.Width = 147
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Design"
        Me.GridColumn7.FieldName = "product_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 147
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Season"
        Me.GridColumn8.FieldName = "season"
        Me.GridColumn8.FieldNameSortGroup = "id_season"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Size"
        Me.GridColumn9.FieldName = "Size"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        Me.GridColumn9.Width = 80
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "ID Season"
        Me.GridColumn10.FieldName = "id_season"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'FormMatConsumption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 362)
        Me.Controls.Add(Me.XTCFabCon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatConsumption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fabric Consumption"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCFabCon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCFabCon.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GCFabCon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFabCon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Orign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNamaDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColProductCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColProductname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCFabCon As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCFabCon As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFabCon As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
End Class
