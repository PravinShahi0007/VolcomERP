<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLineList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLineList))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BandedGridColumnid_design = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncode_import = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndescription = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_delivery = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndelivery = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_season_orign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnseason_orign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnstyle_country = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_product_origin = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnproduct_origin = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_class = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnclass = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_division = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndivision = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncolor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsize_chart = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnfabrication = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndetail_description = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.BandedGridColumneos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnage = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnin_store_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnret_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncode_ret = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnestimate_wh_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnmove_drop = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBandFreeze = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandGeneral = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.SLESeason)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(957, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(298, 12)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 1
        Me.BtnView.Text = "View"
        '
        'SLESeason
        '
        Me.SLESeason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLESeason.Location = New System.Drawing.Point(56, 14)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(236, 20)
        Me.SLESeason.TabIndex = 97
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange, Me.GridColumnSeason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Range"
        Me.GridColumnRange.FieldName = "range"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(15, 17)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl4.TabIndex = 96
        Me.LabelControl4.Text = "Season"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 48)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.GCData.Size = New System.Drawing.Size(957, 492)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GVData.Appearance.HeaderPanel.Options.UseFont = True
        Me.GVData.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GVData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBandFreeze, Me.gridBandGeneral})
        Me.GVData.ColumnPanelRowHeight = 35
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnid_design, Me.BandedGridColumncode_import, Me.BandedGridColumncode, Me.BandedGridColumndescription, Me.BandedGridColumnid_delivery, Me.BandedGridColumndelivery, Me.BandedGridColumnid_season_orign, Me.BandedGridColumnseason_orign, Me.BandedGridColumnstyle_country, Me.BandedGridColumnid_product_origin, Me.BandedGridColumnproduct_origin, Me.BandedGridColumnid_class, Me.BandedGridColumnclass, Me.BandedGridColumnid_division, Me.BandedGridColumndivision, Me.BandedGridColumncolor, Me.BandedGridColumnsize_chart, Me.BandedGridColumnfabrication, Me.BandedGridColumndetail_description, Me.BandedGridColumneos, Me.BandedGridColumnage, Me.BandedGridColumnin_store_date, Me.BandedGridColumnret_date, Me.BandedGridColumncode_ret, Me.BandedGridColumnestimate_wh_date, Me.BandedGridColumnmove_drop})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsPrint.AllowMultilineHeaders = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'BandedGridColumnid_design
        '
        Me.BandedGridColumnid_design.Caption = "id_design"
        Me.BandedGridColumnid_design.FieldName = "id_design"
        Me.BandedGridColumnid_design.Name = "BandedGridColumnid_design"
        '
        'BandedGridColumncode_import
        '
        Me.BandedGridColumncode_import.Caption = "CODE IMPORT"
        Me.BandedGridColumncode_import.FieldName = "code_import"
        Me.BandedGridColumncode_import.Name = "BandedGridColumncode_import"
        Me.BandedGridColumncode_import.Visible = True
        Me.BandedGridColumncode_import.Width = 67
        '
        'BandedGridColumncode
        '
        Me.BandedGridColumncode.Caption = "CODE"
        Me.BandedGridColumncode.FieldName = "code"
        Me.BandedGridColumncode.Name = "BandedGridColumncode"
        Me.BandedGridColumncode.Visible = True
        '
        'BandedGridColumndescription
        '
        Me.BandedGridColumndescription.Caption = "DESCRIPTION"
        Me.BandedGridColumndescription.FieldName = "description"
        Me.BandedGridColumndescription.Name = "BandedGridColumndescription"
        Me.BandedGridColumndescription.Visible = True
        Me.BandedGridColumndescription.Width = 123
        '
        'BandedGridColumnid_delivery
        '
        Me.BandedGridColumnid_delivery.Caption = "id_delivery"
        Me.BandedGridColumnid_delivery.FieldName = "id_delivery"
        Me.BandedGridColumnid_delivery.Name = "BandedGridColumnid_delivery"
        '
        'BandedGridColumndelivery
        '
        Me.BandedGridColumndelivery.Caption = "DEL"
        Me.BandedGridColumndelivery.FieldName = "delivery"
        Me.BandedGridColumndelivery.Name = "BandedGridColumndelivery"
        Me.BandedGridColumndelivery.Visible = True
        Me.BandedGridColumndelivery.Width = 35
        '
        'BandedGridColumnid_season_orign
        '
        Me.BandedGridColumnid_season_orign.Caption = "id_season_orign"
        Me.BandedGridColumnid_season_orign.FieldName = "id_season_orign"
        Me.BandedGridColumnid_season_orign.Name = "BandedGridColumnid_season_orign"
        '
        'BandedGridColumnseason_orign
        '
        Me.BandedGridColumnseason_orign.Caption = "SEASON ORIGIN"
        Me.BandedGridColumnseason_orign.FieldName = "season_orign"
        Me.BandedGridColumnseason_orign.Name = "BandedGridColumnseason_orign"
        Me.BandedGridColumnseason_orign.Visible = True
        Me.BandedGridColumnseason_orign.Width = 61
        '
        'BandedGridColumnstyle_country
        '
        Me.BandedGridColumnstyle_country.Caption = "STYLE COUNTRY"
        Me.BandedGridColumnstyle_country.FieldName = "style_country"
        Me.BandedGridColumnstyle_country.Name = "BandedGridColumnstyle_country"
        Me.BandedGridColumnstyle_country.Visible = True
        Me.BandedGridColumnstyle_country.Width = 65
        '
        'BandedGridColumnid_product_origin
        '
        Me.BandedGridColumnid_product_origin.Caption = "id_product_origin"
        Me.BandedGridColumnid_product_origin.FieldName = "id_product_origin"
        Me.BandedGridColumnid_product_origin.Name = "BandedGridColumnid_product_origin"
        '
        'BandedGridColumnproduct_origin
        '
        Me.BandedGridColumnproduct_origin.Caption = "PRODUCT ORIGIN"
        Me.BandedGridColumnproduct_origin.FieldName = "product_origin"
        Me.BandedGridColumnproduct_origin.Name = "BandedGridColumnproduct_origin"
        Me.BandedGridColumnproduct_origin.Visible = True
        Me.BandedGridColumnproduct_origin.Width = 57
        '
        'BandedGridColumnid_class
        '
        Me.BandedGridColumnid_class.Caption = "id_class"
        Me.BandedGridColumnid_class.FieldName = "id_class"
        Me.BandedGridColumnid_class.Name = "BandedGridColumnid_class"
        '
        'BandedGridColumnclass
        '
        Me.BandedGridColumnclass.Caption = "CLASS"
        Me.BandedGridColumnclass.FieldName = "class"
        Me.BandedGridColumnclass.Name = "BandedGridColumnclass"
        Me.BandedGridColumnclass.Visible = True
        Me.BandedGridColumnclass.Width = 51
        '
        'BandedGridColumnid_division
        '
        Me.BandedGridColumnid_division.Caption = "id_division"
        Me.BandedGridColumnid_division.FieldName = "id_division"
        Me.BandedGridColumnid_division.Name = "BandedGridColumnid_division"
        '
        'BandedGridColumndivision
        '
        Me.BandedGridColumndivision.Caption = "DIVISION"
        Me.BandedGridColumndivision.FieldName = "division"
        Me.BandedGridColumndivision.Name = "BandedGridColumndivision"
        Me.BandedGridColumndivision.Visible = True
        Me.BandedGridColumndivision.Width = 56
        '
        'BandedGridColumncolor
        '
        Me.BandedGridColumncolor.Caption = "COLOR"
        Me.BandedGridColumncolor.FieldName = "color"
        Me.BandedGridColumncolor.Name = "BandedGridColumncolor"
        Me.BandedGridColumncolor.Visible = True
        Me.BandedGridColumncolor.Width = 48
        '
        'BandedGridColumnsize_chart
        '
        Me.BandedGridColumnsize_chart.Caption = "SIZE CHART"
        Me.BandedGridColumnsize_chart.FieldName = "size_chart"
        Me.BandedGridColumnsize_chart.Name = "BandedGridColumnsize_chart"
        Me.BandedGridColumnsize_chart.Visible = True
        Me.BandedGridColumnsize_chart.Width = 62
        '
        'BandedGridColumnfabrication
        '
        Me.BandedGridColumnfabrication.Caption = "FABRICATION"
        Me.BandedGridColumnfabrication.FieldName = "fabrication"
        Me.BandedGridColumnfabrication.Name = "BandedGridColumnfabrication"
        Me.BandedGridColumnfabrication.Visible = True
        Me.BandedGridColumnfabrication.Width = 81
        '
        'BandedGridColumndetail_description
        '
        Me.BandedGridColumndetail_description.Caption = "DETAIL DESCRIPTION"
        Me.BandedGridColumndetail_description.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.BandedGridColumndetail_description.FieldName = "detail_description"
        Me.BandedGridColumndetail_description.Name = "BandedGridColumndetail_description"
        Me.BandedGridColumndetail_description.Visible = True
        Me.BandedGridColumndetail_description.Width = 94
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'BandedGridColumneos
        '
        Me.BandedGridColumneos.Caption = "EOS"
        Me.BandedGridColumneos.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumneos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumneos.FieldName = "eos"
        Me.BandedGridColumneos.Name = "BandedGridColumneos"
        Me.BandedGridColumneos.Visible = True
        Me.BandedGridColumneos.Width = 71
        '
        'BandedGridColumnage
        '
        Me.BandedGridColumnage.Caption = "AGE"
        Me.BandedGridColumnage.FieldName = "age"
        Me.BandedGridColumnage.Name = "BandedGridColumnage"
        Me.BandedGridColumnage.Visible = True
        Me.BandedGridColumnage.Width = 48
        '
        'BandedGridColumnin_store_date
        '
        Me.BandedGridColumnin_store_date.Caption = "IN STORE DATE"
        Me.BandedGridColumnin_store_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnin_store_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnin_store_date.FieldName = "in_store_date"
        Me.BandedGridColumnin_store_date.Name = "BandedGridColumnin_store_date"
        Me.BandedGridColumnin_store_date.Visible = True
        Me.BandedGridColumnin_store_date.Width = 71
        '
        'BandedGridColumnret_date
        '
        Me.BandedGridColumnret_date.Caption = "RET DATE"
        Me.BandedGridColumnret_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnret_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnret_date.FieldName = "ret_date"
        Me.BandedGridColumnret_date.Name = "BandedGridColumnret_date"
        Me.BandedGridColumnret_date.Visible = True
        Me.BandedGridColumnret_date.Width = 70
        '
        'BandedGridColumncode_ret
        '
        Me.BandedGridColumncode_ret.Caption = "CODE RET"
        Me.BandedGridColumncode_ret.FieldName = "code_ret"
        Me.BandedGridColumncode_ret.Name = "BandedGridColumncode_ret"
        Me.BandedGridColumncode_ret.Visible = True
        Me.BandedGridColumncode_ret.Width = 81
        '
        'BandedGridColumnestimate_wh_date
        '
        Me.BandedGridColumnestimate_wh_date.Caption = "EST. WH DATE"
        Me.BandedGridColumnestimate_wh_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnestimate_wh_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnestimate_wh_date.FieldName = "estimate_wh_date"
        Me.BandedGridColumnestimate_wh_date.Name = "BandedGridColumnestimate_wh_date"
        Me.BandedGridColumnestimate_wh_date.Visible = True
        '
        'BandedGridColumnmove_drop
        '
        Me.BandedGridColumnmove_drop.Caption = "MOVE / DROP"
        Me.BandedGridColumnmove_drop.FieldName = "move/drop"
        Me.BandedGridColumnmove_drop.Name = "BandedGridColumnmove_drop"
        Me.BandedGridColumnmove_drop.Visible = True
        '
        'GridBandFreeze
        '
        Me.GridBandFreeze.Columns.Add(Me.BandedGridColumncode)
        Me.GridBandFreeze.Columns.Add(Me.BandedGridColumndescription)
        Me.GridBandFreeze.Name = "GridBandFreeze"
        Me.GridBandFreeze.VisibleIndex = 0
        Me.GridBandFreeze.Width = 198
        '
        'gridBandGeneral
        '
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumncode_import)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumndelivery)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnseason_orign)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnstyle_country)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnproduct_origin)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnclass)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumndivision)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumncolor)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnsize_chart)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnfabrication)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumndetail_description)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumneos)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnage)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnin_store_date)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnret_date)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumncode_ret)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnestimate_wh_date)
        Me.gridBandGeneral.Columns.Add(Me.BandedGridColumnmove_drop)
        Me.gridBandGeneral.Name = "gridBandGeneral"
        Me.gridBandGeneral.VisibleIndex = 1
        Me.gridBandGeneral.Width = 1168
        '
        'FormLineList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 540)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormLineList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Line List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumnid_design As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncode_import As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndescription As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_delivery As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndelivery As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_season_orign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnseason_orign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnstyle_country As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_product_origin As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnproduct_origin As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_class As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnclass As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_division As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndivision As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBandFreeze As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandGeneral As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumncolor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsize_chart As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnfabrication As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndetail_description As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents BandedGridColumneos As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnage As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnin_store_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnret_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncode_ret As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnestimate_wh_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnmove_drop As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
