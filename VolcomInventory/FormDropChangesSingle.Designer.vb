<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDropChangesSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDropChangesSingle))
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControlMove = New DevExpress.XtraEditors.PanelControl()
        Me.DEInStoreDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SLESeasonMove = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_delivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_season = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason_del = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnin_store_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.MEReason = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEStatus = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnAddProduct = New DevExpress.XtraEditors.SimpleButton()
        Me.CESelectAll = New DevExpress.XtraEditors.CheckEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnid_design = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_class = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_sht = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_color = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_critical_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntags = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbtn_history = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoBtnHistory = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumnid_prod_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfinal_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnestimate_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControlMove, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlMove.SuspendLayout()
        CType(Me.DEInStoreDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEInStoreDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeasonMove.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoBtnHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControlMove)
        Me.PanelControl1.Controls.Add(Me.MEReason)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.SLEStatus)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 291)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(591, 132)
        Me.PanelControl1.TabIndex = 0
        '
        'PanelControlMove
        '
        Me.PanelControlMove.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlMove.Controls.Add(Me.DEInStoreDate)
        Me.PanelControlMove.Controls.Add(Me.LabelControl3)
        Me.PanelControlMove.Controls.Add(Me.SLESeasonMove)
        Me.PanelControlMove.Controls.Add(Me.LabelControl4)
        Me.PanelControlMove.Location = New System.Drawing.Point(139, 4)
        Me.PanelControlMove.Name = "PanelControlMove"
        Me.PanelControlMove.Size = New System.Drawing.Size(295, 62)
        Me.PanelControlMove.TabIndex = 7
        Me.PanelControlMove.Visible = False
        '
        'DEInStoreDate
        '
        Me.DEInStoreDate.EditValue = Nothing
        Me.DEInStoreDate.Enabled = False
        Me.DEInStoreDate.Location = New System.Drawing.Point(133, 29)
        Me.DEInStoreDate.Name = "DEInStoreDate"
        Me.DEInStoreDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEInStoreDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEInStoreDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEInStoreDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEInStoreDate.Size = New System.Drawing.Size(153, 20)
        Me.DEInStoreDate.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(6, 10)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Move To"
        '
        'SLESeasonMove
        '
        Me.SLESeasonMove.Location = New System.Drawing.Point(4, 29)
        Me.SLESeasonMove.Name = "SLESeasonMove"
        Me.SLESeasonMove.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeasonMove.Properties.NullText = "- Select Season -"
        Me.SLESeasonMove.Properties.ShowClearButton = False
        Me.SLESeasonMove.Properties.View = Me.GridView1
        Me.SLESeasonMove.Size = New System.Drawing.Size(123, 20)
        Me.SLESeasonMove.TabIndex = 5
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_delivery, Me.GridColumnid_season, Me.GridColumnseason_del, Me.GridColumnin_store_date})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_delivery
        '
        Me.GridColumnid_delivery.Caption = "id_delivery"
        Me.GridColumnid_delivery.FieldName = "id_delivery"
        Me.GridColumnid_delivery.Name = "GridColumnid_delivery"
        '
        'GridColumnid_season
        '
        Me.GridColumnid_season.Caption = "id_season"
        Me.GridColumnid_season.FieldName = "id_season"
        Me.GridColumnid_season.Name = "GridColumnid_season"
        '
        'GridColumnseason_del
        '
        Me.GridColumnseason_del.Caption = "Season"
        Me.GridColumnseason_del.FieldName = "season_del"
        Me.GridColumnseason_del.Name = "GridColumnseason_del"
        Me.GridColumnseason_del.Visible = True
        Me.GridColumnseason_del.VisibleIndex = 0
        '
        'GridColumnin_store_date
        '
        Me.GridColumnin_store_date.Caption = "In Store Date"
        Me.GridColumnin_store_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnin_store_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnin_store_date.FieldName = "in_store_date"
        Me.GridColumnin_store_date.Name = "GridColumnin_store_date"
        Me.GridColumnin_store_date.Visible = True
        Me.GridColumnin_store_date.VisibleIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(133, 10)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "In Store Date"
        '
        'MEReason
        '
        Me.MEReason.Location = New System.Drawing.Point(17, 79)
        Me.MEReason.Name = "MEReason"
        Me.MEReason.Properties.MaxLength = 254
        Me.MEReason.Size = New System.Drawing.Size(549, 38)
        Me.MEReason.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(17, 61)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Reason"
        '
        'SLEStatus
        '
        Me.SLEStatus.Enabled = False
        Me.SLEStatus.Location = New System.Drawing.Point(17, 33)
        Me.SLEStatus.Name = "SLEStatus"
        Me.SLEStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStatus.Properties.NullText = "- Select Status-"
        Me.SLEStatus.Properties.ShowClearButton = False
        Me.SLEStatus.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEStatus.Size = New System.Drawing.Size(123, 20)
        Me.SLEStatus.TabIndex = 3
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
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(17, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Status"
        '
        'BtnAddProduct
        '
        Me.BtnAddProduct.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnAddProduct.Image = CType(resources.GetObject("BtnAddProduct.Image"), System.Drawing.Image)
        Me.BtnAddProduct.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.BtnAddProduct.Location = New System.Drawing.Point(0, 423)
        Me.BtnAddProduct.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnAddProduct.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnAddProduct.Name = "BtnAddProduct"
        Me.BtnAddProduct.Size = New System.Drawing.Size(591, 38)
        Me.BtnAddProduct.TabIndex = 1
        Me.BtnAddProduct.Text = "Add Product"
        '
        'CESelectAll
        '
        Me.CESelectAll.Location = New System.Drawing.Point(17, 8)
        Me.CESelectAll.Name = "CESelectAll"
        Me.CESelectAll.Properties.Caption = "Select All"
        Me.CESelectAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelectAll.TabIndex = 2
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.CESelectAll)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(591, 33)
        Me.PanelControl2.TabIndex = 3
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 33)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepoBtnHistory})
        Me.GCData.Size = New System.Drawing.Size(591, 258)
        Me.GCData.TabIndex = 4
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSelect, Me.GridColumnid_design, Me.GridColumndesign_code, Me.GridColumndesign_class, Me.GridColumndesign_desc, Me.GridColumndesign_sht, Me.GridColumndesign_color, Me.GridColumnid_critical_product, Me.GridColumntags, Me.GridColumnbtn_history, Me.GridColumnid_prod_order, Me.GridColumntotal_qty, Me.GridColumnfinal_price, Me.GridColumnestimate_price, Me.GridColumndelivery})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSelect
        '
        Me.GridColumnSelect.Caption = "Select"
        Me.GridColumnSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnSelect.FieldName = "is_select"
        Me.GridColumnSelect.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnSelect.Name = "GridColumnSelect"
        Me.GridColumnSelect.Visible = True
        Me.GridColumnSelect.VisibleIndex = 0
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnid_design
        '
        Me.GridColumnid_design.Caption = "id_design"
        Me.GridColumnid_design.FieldName = "id_design"
        Me.GridColumnid_design.Name = "GridColumnid_design"
        Me.GridColumnid_design.OptionsColumn.AllowEdit = False
        '
        'GridColumndesign_code
        '
        Me.GridColumndesign_code.Caption = "Code"
        Me.GridColumndesign_code.FieldName = "design_code"
        Me.GridColumndesign_code.Name = "GridColumndesign_code"
        Me.GridColumndesign_code.OptionsColumn.AllowEdit = False
        Me.GridColumndesign_code.Visible = True
        Me.GridColumndesign_code.VisibleIndex = 1
        '
        'GridColumndesign_class
        '
        Me.GridColumndesign_class.Caption = "Class"
        Me.GridColumndesign_class.FieldName = "design_class"
        Me.GridColumndesign_class.Name = "GridColumndesign_class"
        Me.GridColumndesign_class.OptionsColumn.AllowEdit = False
        Me.GridColumndesign_class.Visible = True
        Me.GridColumndesign_class.VisibleIndex = 2
        '
        'GridColumndesign_desc
        '
        Me.GridColumndesign_desc.Caption = "Description"
        Me.GridColumndesign_desc.FieldName = "design_desc"
        Me.GridColumndesign_desc.Name = "GridColumndesign_desc"
        Me.GridColumndesign_desc.OptionsColumn.AllowEdit = False
        Me.GridColumndesign_desc.Visible = True
        Me.GridColumndesign_desc.VisibleIndex = 3
        '
        'GridColumndesign_sht
        '
        Me.GridColumndesign_sht.Caption = "Silhouette"
        Me.GridColumndesign_sht.FieldName = "design_sht"
        Me.GridColumndesign_sht.Name = "GridColumndesign_sht"
        Me.GridColumndesign_sht.OptionsColumn.AllowEdit = False
        '
        'GridColumndesign_color
        '
        Me.GridColumndesign_color.Caption = "Color"
        Me.GridColumndesign_color.FieldName = "design_color"
        Me.GridColumndesign_color.Name = "GridColumndesign_color"
        Me.GridColumndesign_color.OptionsColumn.AllowEdit = False
        Me.GridColumndesign_color.Visible = True
        Me.GridColumndesign_color.VisibleIndex = 4
        '
        'GridColumnid_critical_product
        '
        Me.GridColumnid_critical_product.Caption = "id_critical_product"
        Me.GridColumnid_critical_product.FieldName = "id_critical_product"
        Me.GridColumnid_critical_product.Name = "GridColumnid_critical_product"
        Me.GridColumnid_critical_product.OptionsColumn.AllowEdit = False
        '
        'GridColumntags
        '
        Me.GridColumntags.Caption = "Tags"
        Me.GridColumntags.FieldName = "tags"
        Me.GridColumntags.Name = "GridColumntags"
        Me.GridColumntags.OptionsColumn.AllowEdit = False
        Me.GridColumntags.Visible = True
        Me.GridColumntags.VisibleIndex = 6
        '
        'GridColumnbtn_history
        '
        Me.GridColumnbtn_history.Caption = "  "
        Me.GridColumnbtn_history.ColumnEdit = Me.RepoBtnHistory
        Me.GridColumnbtn_history.FieldName = "btn_history"
        Me.GridColumnbtn_history.Name = "GridColumnbtn_history"
        Me.GridColumnbtn_history.Visible = True
        Me.GridColumnbtn_history.VisibleIndex = 9
        '
        'RepoBtnHistory
        '
        Me.RepoBtnHistory.AutoHeight = False
        SerializableAppearanceObject2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        SerializableAppearanceObject2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject2.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject2.Options.UseBackColor = True
        SerializableAppearanceObject2.Options.UseFont = True
        SerializableAppearanceObject2.Options.UseForeColor = True
        Me.RepoBtnHistory.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "History", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.RepoBtnHistory.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.RepoBtnHistory.Name = "RepoBtnHistory"
        Me.RepoBtnHistory.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'GridColumnid_prod_order
        '
        Me.GridColumnid_prod_order.Caption = "id_prod_order"
        Me.GridColumnid_prod_order.FieldName = "id_prod_order"
        Me.GridColumnid_prod_order.Name = "GridColumnid_prod_order"
        Me.GridColumnid_prod_order.OptionsColumn.AllowEdit = False
        '
        'GridColumntotal_qty
        '
        Me.GridColumntotal_qty.Caption = "Total Qty"
        Me.GridColumntotal_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty.FieldName = "total_qty"
        Me.GridColumntotal_qty.Name = "GridColumntotal_qty"
        Me.GridColumntotal_qty.OptionsColumn.AllowEdit = False
        Me.GridColumntotal_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N0}")})
        Me.GridColumntotal_qty.Visible = True
        Me.GridColumntotal_qty.VisibleIndex = 7
        '
        'GridColumnfinal_price
        '
        Me.GridColumnfinal_price.Caption = "Price"
        Me.GridColumnfinal_price.DisplayFormat.FormatString = "N0"
        Me.GridColumnfinal_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnfinal_price.FieldName = "final_price"
        Me.GridColumnfinal_price.Name = "GridColumnfinal_price"
        Me.GridColumnfinal_price.OptionsColumn.AllowEdit = False
        Me.GridColumnfinal_price.Visible = True
        Me.GridColumnfinal_price.VisibleIndex = 8
        '
        'GridColumnestimate_price
        '
        Me.GridColumnestimate_price.Caption = "Est. Price"
        Me.GridColumnestimate_price.DisplayFormat.FormatString = "N0"
        Me.GridColumnestimate_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnestimate_price.FieldName = "estimate_price"
        Me.GridColumnestimate_price.Name = "GridColumnestimate_price"
        Me.GridColumnestimate_price.OptionsColumn.AllowEdit = False
        '
        'GridColumndelivery
        '
        Me.GridColumndelivery.Caption = "Del"
        Me.GridColumndelivery.FieldName = "delivery"
        Me.GridColumndelivery.Name = "GridColumndelivery"
        Me.GridColumndelivery.OptionsColumn.AllowEdit = False
        Me.GridColumndelivery.Visible = True
        Me.GridColumndelivery.VisibleIndex = 5
        '
        'FormDropChangesSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 461)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.BtnAddProduct)
        Me.MinimizeBox = False
        Me.Name = "FormDropChangesSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Product"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControlMove, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlMove.ResumeLayout(False)
        Me.PanelControlMove.PerformLayout()
        CType(Me.DEInStoreDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEInStoreDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeasonMove.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoBtnHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAddProduct As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStatus As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DEInStoreDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESeasonMove As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEReason As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents CESelectAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlMove As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnid_design As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_class As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_sht As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_color As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_critical_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntags As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbtn_history As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoBtnHistory As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumnid_delivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_season As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason_del As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnin_store_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_prod_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfinal_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnestimate_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndelivery As DevExpress.XtraGrid.Columns.GridColumn
End Class
