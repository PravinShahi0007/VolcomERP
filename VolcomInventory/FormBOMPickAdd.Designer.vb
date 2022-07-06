<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBOMPickAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBOMPickAdd))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BEditMat = New DevExpress.XtraEditors.SimpleButton()
        Me.BAddMat = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl3 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GCDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn67 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn68 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn69 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.GCBomDetMat = New DevExpress.XtraGrid.GridControl()
        Me.GVBomDetMat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCOP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECOP = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnTotalCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnKursMat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl3.SuspendLayout()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.GCBomDetMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBomDetMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BEditMat)
        Me.PanelControl1.Controls.Add(Me.BAddMat)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 516)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(949, 42)
        Me.PanelControl1.TabIndex = 19
        '
        'BEditMat
        '
        Me.BEditMat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditMat.Image = CType(resources.GetObject("BEditMat.Image"), System.Drawing.Image)
        Me.BEditMat.ImageIndex = 2
        Me.BEditMat.Location = New System.Drawing.Point(755, 2)
        Me.BEditMat.Name = "BEditMat"
        Me.BEditMat.Size = New System.Drawing.Size(91, 38)
        Me.BEditMat.TabIndex = 16
        Me.BEditMat.Text = "Close"
        '
        'BAddMat
        '
        Me.BAddMat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddMat.Image = CType(resources.GetObject("BAddMat.Image"), System.Drawing.Image)
        Me.BAddMat.ImageIndex = 0
        Me.BAddMat.Location = New System.Drawing.Point(846, 2)
        Me.BAddMat.Name = "BAddMat"
        Me.BAddMat.Size = New System.Drawing.Size(101, 38)
        Me.BAddMat.TabIndex = 15
        Me.BAddMat.Text = "Add"
        '
        'SplitContainerControl3
        '
        Me.SplitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl3.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl3.Horizontal = False
        Me.SplitContainerControl3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl3.Name = "SplitContainerControl3"
        Me.SplitContainerControl3.Panel1.Controls.Add(Me.GCDesign)
        Me.SplitContainerControl3.Panel1.Text = "Panel1"
        Me.SplitContainerControl3.Panel2.Controls.Add(Me.GroupControl6)
        Me.SplitContainerControl3.Panel2.Text = "Panel2"
        Me.SplitContainerControl3.Size = New System.Drawing.Size(949, 516)
        Me.SplitContainerControl3.SplitterPosition = 297
        Me.SplitContainerControl3.TabIndex = 20
        Me.SplitContainerControl3.Text = "SplitContainerControl3"
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(0, 0)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(949, 297)
        Me.GCDesign.TabIndex = 4
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign, Me.GridView2})
        '
        'GVDesign
        '
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn11, Me.GridColumn59, Me.GridColumn60, Me.GridColumn61, Me.GridColumn62, Me.GridColumn63, Me.GridColumn64, Me.GridColumn65, Me.GridColumn66, Me.GridColumn67, Me.GridColumn68, Me.GridColumn69})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.Editable = False
        Me.GVDesign.OptionsCustomization.AllowGroup = False
        Me.GVDesign.OptionsFind.AlwaysVisible = True
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        Me.GVDesign.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn11, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Id Design"
        Me.GridColumn11.FieldName = "id_design"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridColumn59
        '
        Me.GridColumn59.Caption = "Short Description"
        Me.GridColumn59.FieldName = "design_display_name"
        Me.GridColumn59.Name = "GridColumn59"
        Me.GridColumn59.Width = 92
        '
        'GridColumn60
        '
        Me.GridColumn60.Caption = "Description"
        Me.GridColumn60.FieldName = "design_name"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.Visible = True
        Me.GridColumn60.VisibleIndex = 3
        Me.GridColumn60.Width = 391
        '
        'GridColumn61
        '
        Me.GridColumn61.Caption = "UOM"
        Me.GridColumn61.FieldName = "id_uom"
        Me.GridColumn61.Name = "GridColumn61"
        '
        'GridColumn62
        '
        Me.GridColumn62.Caption = "Season"
        Me.GridColumn62.FieldName = "season"
        Me.GridColumn62.FieldNameSortGroup = "id_season"
        Me.GridColumn62.Name = "GridColumn62"
        Me.GridColumn62.Visible = True
        Me.GridColumn62.VisibleIndex = 0
        Me.GridColumn62.Width = 162
        '
        'GridColumn63
        '
        Me.GridColumn63.Caption = "Code"
        Me.GridColumn63.FieldName = "design_code"
        Me.GridColumn63.Name = "GridColumn63"
        Me.GridColumn63.Visible = True
        Me.GridColumn63.VisibleIndex = 2
        Me.GridColumn63.Width = 363
        '
        'GridColumn64
        '
        Me.GridColumn64.Caption = "Design Orign"
        Me.GridColumn64.FieldName = "orign"
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.Width = 120
        '
        'GridColumn65
        '
        Me.GridColumn65.Caption = "Season"
        Me.GridColumn65.FieldName = "id_season"
        Me.GridColumn65.Name = "GridColumn65"
        '
        'GridColumn66
        '
        Me.GridColumn66.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn66.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn66.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn66.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn66.Caption = "Color"
        Me.GridColumn66.FieldName = "color"
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.Visible = True
        Me.GridColumn66.VisibleIndex = 4
        Me.GridColumn66.Width = 264
        '
        'GridColumn67
        '
        Me.GridColumn67.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn67.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn67.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn67.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn67.Caption = "Source"
        Me.GridColumn67.FieldName = "product_source"
        Me.GridColumn67.Name = "GridColumn67"
        Me.GridColumn67.Width = 69
        '
        'GridColumn68
        '
        Me.GridColumn68.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn68.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn68.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn68.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn68.Caption = "Class"
        Me.GridColumn68.FieldName = "class"
        Me.GridColumn68.Name = "GridColumn68"
        Me.GridColumn68.Visible = True
        Me.GridColumn68.VisibleIndex = 1
        Me.GridColumn68.Width = 253
        '
        'GridColumn69
        '
        Me.GridColumn69.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn69.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn69.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn69.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn69.Caption = "Qty"
        Me.GridColumn69.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn69.FieldName = "qty"
        Me.GridColumn69.Name = "GridColumn69"
        Me.GridColumn69.Width = 183
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCDesign
        Me.GridView2.Name = "GridView2"
        '
        'GroupControl6
        '
        Me.GroupControl6.Controls.Add(Me.GCBomDetMat)
        Me.GroupControl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl6.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(949, 214)
        Me.GroupControl6.TabIndex = 1
        Me.GroupControl6.Text = "BOM"
        '
        'GCBomDetMat
        '
        Me.GCBomDetMat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBomDetMat.Location = New System.Drawing.Point(2, 20)
        Me.GCBomDetMat.MainView = Me.GVBomDetMat
        Me.GCBomDetMat.Name = "GCBomDetMat"
        Me.GCBomDetMat.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICECOP})
        Me.GCBomDetMat.Size = New System.Drawing.Size(945, 192)
        Me.GCBomDetMat.TabIndex = 18
        Me.GCBomDetMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBomDetMat, Me.GridView3})
        '
        'GVBomDetMat
        '
        Me.GVBomDetMat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn12, Me.GridColumn6, Me.GridColumn3, Me.GridColumn2, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumnCOP, Me.GridColumnTotalCost, Me.GridColumnKursMat, Me.GridColumn18})
        Me.GVBomDetMat.CustomizationFormBounds = New System.Drawing.Rectangle(885, 289, 216, 178)
        Me.GVBomDetMat.GridControl = Me.GCBomDetMat
        Me.GVBomDetMat.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumn7, "{0:N2}")})
        Me.GVBomDetMat.Name = "GVBomDetMat"
        Me.GVBomDetMat.OptionsBehavior.Editable = False
        Me.GVBomDetMat.OptionsFilter.AllowFilterEditor = False
        Me.GVBomDetMat.OptionsFind.AllowFindPanel = False
        Me.GVBomDetMat.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVBomDetMat.OptionsView.ShowFooter = True
        Me.GVBomDetMat.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Mat"
        Me.GridColumn1.FieldName = "id_component"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Id Component Price"
        Me.GridColumn12.FieldName = "id_component_price"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Code"
        Me.GridColumn6.FieldName = "code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 206
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Material"
        Me.GridColumn3.FieldName = "name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 364
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Size"
        Me.GridColumn2.FieldName = "size"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 5
        Me.GridColumn2.Width = 60
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "Qty"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "component_qty"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 6
        Me.GridColumn4.Width = 104
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.Caption = "Unit Price"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "price"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 8
        Me.GridColumn5.Width = 202
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.Caption = "Total"
        Me.GridColumn7.DisplayFormat.FormatString = "N2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "total"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumn7.Width = 207
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "Color"
        Me.GridColumn8.FieldName = "color"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 4
        Me.GridColumn8.Width = 111
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.Caption = "UOM"
        Me.GridColumn9.FieldName = "uom"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 94
        '
        'GridColumnCOP
        '
        Me.GridColumnCOP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCOP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCOP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCOP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCOP.Caption = "COP"
        Me.GridColumnCOP.ColumnEdit = Me.RICECOP
        Me.GridColumnCOP.FieldName = "is_cost2"
        Me.GridColumnCOP.Name = "GridColumnCOP"
        Me.GridColumnCOP.Visible = True
        Me.GridColumnCOP.VisibleIndex = 0
        Me.GridColumnCOP.Width = 97
        '
        'RICECOP
        '
        Me.RICECOP.AutoHeight = False
        Me.RICECOP.Name = "RICECOP"
        Me.RICECOP.ValueChecked = "yes"
        Me.RICECOP.ValueUnchecked = "no"
        '
        'GridColumnTotalCost
        '
        Me.GridColumnTotalCost.Caption = "Total Cost"
        Me.GridColumnTotalCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalCost.FieldName = "total_cost"
        Me.GridColumnTotalCost.Name = "GridColumnTotalCost"
        Me.GridColumnTotalCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:N2}")})
        Me.GridColumnTotalCost.UnboundExpression = "Iif([is_cost] = 1, 1, 0) * [qty] * [price]"
        Me.GridColumnTotalCost.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnTotalCost.Visible = True
        Me.GridColumnTotalCost.VisibleIndex = 9
        Me.GridColumnTotalCost.Width = 213
        '
        'GridColumnKursMat
        '
        Me.GridColumnKursMat.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnKursMat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKursMat.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnKursMat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKursMat.Caption = "Kurs"
        Me.GridColumnKursMat.DisplayFormat.FormatString = "N2"
        Me.GridColumnKursMat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnKursMat.FieldName = "kurs"
        Me.GridColumnKursMat.Name = "GridColumnKursMat"
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn18.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn18.Caption = "Additional Cost"
        Me.GridColumn18.ColumnEdit = Me.RICECOP
        Me.GridColumn18.FieldName = "is_addcost2"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 1
        Me.GridColumn18.Width = 181
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCBomDetMat
        Me.GridView3.Name = "GridView3"
        '
        'FormBOMPickAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 558)
        Me.Controls.Add(Me.SplitContainerControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBOMPickAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick From Another Design"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl3.ResumeLayout(False)
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        CType(Me.GCBomDetMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBomDetMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BEditMat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddMat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl3 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn67 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn68 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn69 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCBomDetMat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBomDetMat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCOP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICECOP As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnTotalCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnKursMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
