<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpDesignPD
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
        Me.PCClose = New DevExpress.XtraEditors.PanelControl
        Me.CheckEditProduct = New DevExpress.XtraEditors.CheckEdit
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.GCItemList = New DevExpress.XtraGrid.GridControl
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNoImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPOImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPD = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUSCodeImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCodeImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeasonOriginImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCountryImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSourceImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnClassImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDeliveryImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStyleImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColorImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnEOSImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAgeImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRetImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRetCodeImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMSRPImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPricePDImp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCOPPD = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSelect = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GridColumnSeasonNu = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PBC = New DevExpress.XtraEditors.ProgressBarControl
        CType(Me.PCClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCClose.SuspendLayout()
        CType(Me.CheckEditProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCClose
        '
        Me.PCClose.Controls.Add(Me.CheckEditProduct)
        Me.PCClose.Controls.Add(Me.BtnClose)
        Me.PCClose.Controls.Add(Me.BtnSave)
        Me.PCClose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCClose.Location = New System.Drawing.Point(0, 485)
        Me.PCClose.LookAndFeel.SkinName = "Blue"
        Me.PCClose.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCClose.Name = "PCClose"
        Me.PCClose.Size = New System.Drawing.Size(808, 35)
        Me.PCClose.TabIndex = 39
        '
        'CheckEditProduct
        '
        Me.CheckEditProduct.Location = New System.Drawing.Point(11, 9)
        Me.CheckEditProduct.Name = "CheckEditProduct"
        Me.CheckEditProduct.Properties.Caption = "Select All"
        Me.CheckEditProduct.Size = New System.Drawing.Size(80, 19)
        Me.CheckEditProduct.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Location = New System.Drawing.Point(656, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 31)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(731, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 31)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Choose"
        '
        'GCItemList
        '
        Me.GCItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemList.Location = New System.Drawing.Point(0, 32)
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(808, 453)
        Me.GCItemList.TabIndex = 40
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNoImp, Me.GridColumnPOImp, Me.GridColumnPD, Me.GridColumnUSCodeImp, Me.GridColumnCodeImp, Me.GridColumnSeasonOriginImp, Me.GridColumnCountryImp, Me.GridColumnSourceImp, Me.GridColumnClassImp, Me.GridColumnDivision, Me.GridColumnDeliveryImp, Me.GridColumnStyleImp, Me.GridColumnColorImp, Me.GridColumnQtyImp, Me.GridColumnEOSImp, Me.GridColumnAgeImp, Me.GridColumnRetImp, Me.GridColumnRetCodeImp, Me.GridColumnMSRPImp, Me.GridColumnPricePDImp, Me.GridColumnCOPPD, Me.GridColumnSelect, Me.GridColumnSeasonNu})
        Me.GVItemList.CustomizationFormBounds = New System.Drawing.Rectangle(825, 486, 216, 178)
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsCustomization.AllowRowSizing = True
        Me.GVItemList.OptionsView.ColumnAutoWidth = False
        Me.GVItemList.OptionsView.RowAutoHeight = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNoImp
        '
        Me.GridColumnNoImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNoImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnNoImp.Caption = "No"
        Me.GridColumnNoImp.FieldName = "no"
        Me.GridColumnNoImp.Name = "GridColumnNoImp"
        Me.GridColumnNoImp.OptionsColumn.ReadOnly = True
        Me.GridColumnNoImp.Visible = True
        Me.GridColumnNoImp.VisibleIndex = 0
        Me.GridColumnNoImp.Width = 45
        '
        'GridColumnPOImp
        '
        Me.GridColumnPOImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPOImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnPOImp.Caption = "Prod Order#"
        Me.GridColumnPOImp.FieldName = "prod_order_number"
        Me.GridColumnPOImp.FieldNameSortGroup = "id_prod_order"
        Me.GridColumnPOImp.Name = "GridColumnPOImp"
        Me.GridColumnPOImp.OptionsColumn.ReadOnly = True
        Me.GridColumnPOImp.Visible = True
        Me.GridColumnPOImp.VisibleIndex = 1
        '
        'GridColumnPD
        '
        Me.GridColumnPD.Caption = "PD #"
        Me.GridColumnPD.FieldName = "prod_demand_number"
        Me.GridColumnPD.FieldNameSortGroup = "id_prod_demand"
        Me.GridColumnPD.Name = "GridColumnPD"
        Me.GridColumnPD.Visible = True
        Me.GridColumnPD.VisibleIndex = 2
        '
        'GridColumnUSCodeImp
        '
        Me.GridColumnUSCodeImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUSCodeImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnUSCodeImp.Caption = "Style No"
        Me.GridColumnUSCodeImp.FieldName = "design_code_import"
        Me.GridColumnUSCodeImp.Name = "GridColumnUSCodeImp"
        Me.GridColumnUSCodeImp.OptionsColumn.ReadOnly = True
        Me.GridColumnUSCodeImp.Visible = True
        Me.GridColumnUSCodeImp.VisibleIndex = 3
        '
        'GridColumnCodeImp
        '
        Me.GridColumnCodeImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCodeImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnCodeImp.Caption = "Code"
        Me.GridColumnCodeImp.FieldName = "design_code"
        Me.GridColumnCodeImp.Name = "GridColumnCodeImp"
        Me.GridColumnCodeImp.OptionsColumn.ReadOnly = True
        Me.GridColumnCodeImp.Visible = True
        Me.GridColumnCodeImp.VisibleIndex = 4
        '
        'GridColumnSeasonOriginImp
        '
        Me.GridColumnSeasonOriginImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSeasonOriginImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnSeasonOriginImp.Caption = "Season Origin"
        Me.GridColumnSeasonOriginImp.FieldName = "season_orign_display"
        Me.GridColumnSeasonOriginImp.FieldNameSortGroup = "id_season_orign"
        Me.GridColumnSeasonOriginImp.Name = "GridColumnSeasonOriginImp"
        Me.GridColumnSeasonOriginImp.OptionsColumn.ReadOnly = True
        Me.GridColumnSeasonOriginImp.Visible = True
        Me.GridColumnSeasonOriginImp.VisibleIndex = 6
        Me.GridColumnSeasonOriginImp.Width = 76
        '
        'GridColumnCountryImp
        '
        Me.GridColumnCountryImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCountryImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnCountryImp.Caption = "Style Country"
        Me.GridColumnCountryImp.FieldName = "country_display_name"
        Me.GridColumnCountryImp.FieldNameSortGroup = "id_country"
        Me.GridColumnCountryImp.Name = "GridColumnCountryImp"
        Me.GridColumnCountryImp.OptionsColumn.ReadOnly = True
        Me.GridColumnCountryImp.Visible = True
        Me.GridColumnCountryImp.VisibleIndex = 7
        '
        'GridColumnSourceImp
        '
        Me.GridColumnSourceImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSourceImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnSourceImp.Caption = "Source"
        Me.GridColumnSourceImp.FieldName = "source"
        Me.GridColumnSourceImp.Name = "GridColumnSourceImp"
        Me.GridColumnSourceImp.OptionsColumn.ReadOnly = True
        Me.GridColumnSourceImp.Visible = True
        Me.GridColumnSourceImp.VisibleIndex = 8
        '
        'GridColumnClassImp
        '
        Me.GridColumnClassImp.Caption = "Class"
        Me.GridColumnClassImp.FieldName = "class"
        Me.GridColumnClassImp.Name = "GridColumnClassImp"
        Me.GridColumnClassImp.OptionsColumn.ReadOnly = True
        Me.GridColumnClassImp.Visible = True
        Me.GridColumnClassImp.VisibleIndex = 9
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "division"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 10
        '
        'GridColumnDeliveryImp
        '
        Me.GridColumnDeliveryImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDeliveryImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnDeliveryImp.Caption = "Del"
        Me.GridColumnDeliveryImp.FieldName = "delivery"
        Me.GridColumnDeliveryImp.FieldNameSortGroup = "id_delivery"
        Me.GridColumnDeliveryImp.Name = "GridColumnDeliveryImp"
        Me.GridColumnDeliveryImp.OptionsColumn.ReadOnly = True
        Me.GridColumnDeliveryImp.Visible = True
        Me.GridColumnDeliveryImp.VisibleIndex = 11
        Me.GridColumnDeliveryImp.Width = 44
        '
        'GridColumnStyleImp
        '
        Me.GridColumnStyleImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnStyleImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnStyleImp.Caption = "Style"
        Me.GridColumnStyleImp.FieldName = "design_display_name"
        Me.GridColumnStyleImp.FieldNameSortGroup = "id_design"
        Me.GridColumnStyleImp.Name = "GridColumnStyleImp"
        Me.GridColumnStyleImp.OptionsColumn.ReadOnly = True
        Me.GridColumnStyleImp.Visible = True
        Me.GridColumnStyleImp.VisibleIndex = 12
        '
        'GridColumnColorImp
        '
        Me.GridColumnColorImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColorImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnColorImp.Caption = "Color"
        Me.GridColumnColorImp.FieldName = "color"
        Me.GridColumnColorImp.Name = "GridColumnColorImp"
        Me.GridColumnColorImp.OptionsColumn.ReadOnly = True
        Me.GridColumnColorImp.Visible = True
        Me.GridColumnColorImp.VisibleIndex = 13
        '
        'GridColumnQtyImp
        '
        Me.GridColumnQtyImp.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyImp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyImp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnQtyImp.Caption = "Qty"
        Me.GridColumnQtyImp.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnQtyImp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyImp.FieldName = "qty"
        Me.GridColumnQtyImp.Name = "GridColumnQtyImp"
        Me.GridColumnQtyImp.OptionsColumn.ReadOnly = True
        Me.GridColumnQtyImp.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "fg_propose_price_det_qty", "{0:n0}")})
        Me.GridColumnQtyImp.Visible = True
        Me.GridColumnQtyImp.VisibleIndex = 14
        Me.GridColumnQtyImp.Width = 51
        '
        'GridColumnEOSImp
        '
        Me.GridColumnEOSImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnEOSImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnEOSImp.Caption = "EOS"
        Me.GridColumnEOSImp.FieldName = "design_eos"
        Me.GridColumnEOSImp.Name = "GridColumnEOSImp"
        Me.GridColumnEOSImp.OptionsColumn.ReadOnly = True
        Me.GridColumnEOSImp.Visible = True
        Me.GridColumnEOSImp.VisibleIndex = 15
        '
        'GridColumnAgeImp
        '
        Me.GridColumnAgeImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAgeImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnAgeImp.Caption = "Age"
        Me.GridColumnAgeImp.FieldName = "lifetime"
        Me.GridColumnAgeImp.Name = "GridColumnAgeImp"
        Me.GridColumnAgeImp.OptionsColumn.ReadOnly = True
        Me.GridColumnAgeImp.Visible = True
        Me.GridColumnAgeImp.VisibleIndex = 16
        '
        'GridColumnRetImp
        '
        Me.GridColumnRetImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRetImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnRetImp.Caption = "Ret"
        Me.GridColumnRetImp.FieldName = "design_ret"
        Me.GridColumnRetImp.Name = "GridColumnRetImp"
        Me.GridColumnRetImp.OptionsColumn.ReadOnly = True
        Me.GridColumnRetImp.Visible = True
        Me.GridColumnRetImp.VisibleIndex = 17
        '
        'GridColumnRetCodeImp
        '
        Me.GridColumnRetCodeImp.Caption = "Code Ret"
        Me.GridColumnRetCodeImp.FieldName = "ret_code"
        Me.GridColumnRetCodeImp.Name = "GridColumnRetCodeImp"
        Me.GridColumnRetCodeImp.OptionsColumn.ReadOnly = True
        Me.GridColumnRetCodeImp.Visible = True
        Me.GridColumnRetCodeImp.VisibleIndex = 18
        '
        'GridColumnMSRPImp
        '
        Me.GridColumnMSRPImp.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnMSRPImp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMSRPImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnMSRPImp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMSRPImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnMSRPImp.Caption = "US/OZ MSRP"
        Me.GridColumnMSRPImp.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnMSRPImp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMSRPImp.FieldName = "msrp"
        Me.GridColumnMSRPImp.Name = "GridColumnMSRPImp"
        Me.GridColumnMSRPImp.OptionsColumn.ReadOnly = True
        Me.GridColumnMSRPImp.Visible = True
        Me.GridColumnMSRPImp.VisibleIndex = 19
        '
        'GridColumnPricePDImp
        '
        Me.GridColumnPricePDImp.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPricePDImp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPricePDImp.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPricePDImp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPricePDImp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnPricePDImp.Caption = "Price PD"
        Me.GridColumnPricePDImp.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPricePDImp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPricePDImp.FieldName = "price_pd"
        Me.GridColumnPricePDImp.Name = "GridColumnPricePDImp"
        Me.GridColumnPricePDImp.OptionsColumn.ReadOnly = True
        Me.GridColumnPricePDImp.Visible = True
        Me.GridColumnPricePDImp.VisibleIndex = 21
        Me.GridColumnPricePDImp.Width = 121
        '
        'GridColumnCOPPD
        '
        Me.GridColumnCOPPD.Caption = "COP PD"
        Me.GridColumnCOPPD.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnCOPPD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCOPPD.FieldName = "cop_pd"
        Me.GridColumnCOPPD.Name = "GridColumnCOPPD"
        Me.GridColumnCOPPD.Visible = True
        Me.GridColumnCOPPD.VisibleIndex = 20
        '
        'GridColumnSelect
        '
        Me.GridColumnSelect.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.Caption = "Select"
        Me.GridColumnSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnSelect.FieldName = "is_select"
        Me.GridColumnSelect.Name = "GridColumnSelect"
        Me.GridColumnSelect.Visible = True
        Me.GridColumnSelect.VisibleIndex = 22
        Me.GridColumnSelect.Width = 52
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnSeasonNu
        '
        Me.GridColumnSeasonNu.Caption = "Season"
        Me.GridColumnSeasonNu.FieldName = "season"
        Me.GridColumnSeasonNu.FieldNameSortGroup = "id_season"
        Me.GridColumnSeasonNu.Name = "GridColumnSeasonNu"
        Me.GridColumnSeasonNu.Visible = True
        Me.GridColumnSeasonNu.VisibleIndex = 5
        '
        'PBC
        '
        Me.PBC.Dock = System.Windows.Forms.DockStyle.Top
        Me.PBC.Location = New System.Drawing.Point(0, 0)
        Me.PBC.Name = "PBC"
        Me.PBC.Size = New System.Drawing.Size(808, 32)
        Me.PBC.TabIndex = 92
        Me.PBC.Visible = False
        '
        'FormPopUpDesignPD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 520)
        Me.Controls.Add(Me.GCItemList)
        Me.Controls.Add(Me.PBC)
        Me.Controls.Add(Me.PCClose)
        Me.MinimizeBox = False
        Me.Name = "FormPopUpDesignPD"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design"
        CType(Me.PCClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCClose.ResumeLayout(False)
        CType(Me.CheckEditProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PCClose As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNoImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUSCodeImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCodeImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeasonOriginImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCountryImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSourceImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClassImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeliveryImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStyleImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColorImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEOSImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAgeImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMSRPImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPricePDImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetCodeImp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnSeasonNu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCOPPD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckEditProduct As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnPD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PBC As DevExpress.XtraEditors.ProgressBarControl
End Class
