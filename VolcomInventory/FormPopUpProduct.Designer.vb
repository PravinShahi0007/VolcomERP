<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPopUpProduct
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
        Me.components = New System.ComponentModel.Container()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PCSelAll = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.GCProdList = New DevExpress.XtraGrid.GridControl()
        Me.GVProdList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdDesignPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignDisplayName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductOrigin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstDelDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnEstWHDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnColod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnIsSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMImg = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSelAll.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PCSelAll)
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 371)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(971, 35)
        Me.PanelControl1.TabIndex = 0
        '
        'PCSelAll
        '
        Me.PCSelAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCSelAll.Controls.Add(Me.CheckEditSelAll)
        Me.PCSelAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCSelAll.Location = New System.Drawing.Point(2, 2)
        Me.PCSelAll.Name = "PCSelAll"
        Me.PCSelAll.Size = New System.Drawing.Size(99, 31)
        Me.PCSelAll.TabIndex = 104
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(5, 6)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(91, 19)
        Me.CheckEditSelAll.TabIndex = 102
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(894, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 31)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'GCProdList
        '
        Me.GCProdList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdList.Location = New System.Drawing.Point(0, 0)
        Me.GCProdList.MainView = Me.GVProdList
        Me.GCProdList.Name = "GCProdList"
        Me.GCProdList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2, Me.RepositoryItemTextEdit3, Me.RepositoryItemSpinEdit1, Me.RepoQty})
        Me.GCProdList.Size = New System.Drawing.Size(971, 371)
        Me.GCProdList.TabIndex = 3
        Me.GCProdList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdList})
        '
        'GVProdList
        '
        Me.GVProdList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdDesignPrice, Me.GridColumnDesignCode, Me.GridColumnDesignDisplayName, Me.GridColumnProductCode, Me.GridColumnVendorCode, Me.GridColumnProductOrigin, Me.GridColumnDivision, Me.GridColumnProdSize, Me.GridColumnEstDelDate, Me.GridColumnEstWHDate, Me.GridColumnColod, Me.GridColumnDelivery, Me.GridColumnPrice, Me.GridColumnQty, Me.GridColumnIsSelect})
        Me.GVProdList.GridControl = Me.GCProdList
        Me.GVProdList.GroupCount = 1
        Me.GVProdList.Name = "GVProdList"
        Me.GVProdList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVProdList.OptionsView.ShowFooter = True
        Me.GVProdList.OptionsView.ShowGroupPanel = False
        Me.GVProdList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDesignDisplayName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdDesignPrice
        '
        Me.GridColumnIdDesignPrice.Caption = "Id Design Price"
        Me.GridColumnIdDesignPrice.FieldName = "id_design_price"
        Me.GridColumnIdDesignPrice.Name = "GridColumnIdDesignPrice"
        Me.GridColumnIdDesignPrice.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdDesignPrice.Width = 80
        '
        'GridColumnDesignCode
        '
        Me.GridColumnDesignCode.Caption = "Code"
        Me.GridColumnDesignCode.FieldName = "design_code"
        Me.GridColumnDesignCode.Name = "GridColumnDesignCode"
        Me.GridColumnDesignCode.OptionsColumn.ReadOnly = True
        '
        'GridColumnDesignDisplayName
        '
        Me.GridColumnDesignDisplayName.Caption = "Style"
        Me.GridColumnDesignDisplayName.FieldName = "design_display_name"
        Me.GridColumnDesignDisplayName.FieldNameSortGroup = "id_design"
        Me.GridColumnDesignDisplayName.Name = "GridColumnDesignDisplayName"
        Me.GridColumnDesignDisplayName.OptionsColumn.ReadOnly = True
        '
        'GridColumnProductCode
        '
        Me.GridColumnProductCode.Caption = "Product Code"
        Me.GridColumnProductCode.FieldName = "product_full_code"
        Me.GridColumnProductCode.Name = "GridColumnProductCode"
        Me.GridColumnProductCode.OptionsColumn.ReadOnly = True
        Me.GridColumnProductCode.Visible = True
        Me.GridColumnProductCode.VisibleIndex = 1
        Me.GridColumnProductCode.Width = 84
        '
        'GridColumnVendorCode
        '
        Me.GridColumnVendorCode.Caption = "Vendor/UPC Code"
        Me.GridColumnVendorCode.FieldName = "product_ean_code"
        Me.GridColumnVendorCode.Name = "GridColumnVendorCode"
        Me.GridColumnVendorCode.OptionsColumn.ReadOnly = True
        Me.GridColumnVendorCode.Visible = True
        Me.GridColumnVendorCode.VisibleIndex = 0
        Me.GridColumnVendorCode.Width = 95
        '
        'GridColumnProductOrigin
        '
        Me.GridColumnProductOrigin.Caption = "Origin"
        Me.GridColumnProductOrigin.FieldName = "Product Source_display"
        Me.GridColumnProductOrigin.Name = "GridColumnProductOrigin"
        Me.GridColumnProductOrigin.OptionsColumn.ReadOnly = True
        Me.GridColumnProductOrigin.Visible = True
        Me.GridColumnProductOrigin.VisibleIndex = 2
        Me.GridColumnProductOrigin.Width = 56
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "Product Division_display"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.OptionsColumn.ReadOnly = True
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 3
        Me.GridColumnDivision.Width = 56
        '
        'GridColumnProdSize
        '
        Me.GridColumnProdSize.Caption = "Size"
        Me.GridColumnProdSize.FieldName = "Size"
        Me.GridColumnProdSize.Name = "GridColumnProdSize"
        Me.GridColumnProdSize.OptionsColumn.ReadOnly = True
        Me.GridColumnProdSize.Visible = True
        Me.GridColumnProdSize.VisibleIndex = 5
        Me.GridColumnProdSize.Width = 56
        '
        'GridColumnEstDelDate
        '
        Me.GridColumnEstDelDate.Caption = "Est. In Store Date"
        Me.GridColumnEstDelDate.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnEstDelDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnEstDelDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnEstDelDate.FieldName = "delivery_date"
        Me.GridColumnEstDelDate.Name = "GridColumnEstDelDate"
        Me.GridColumnEstDelDate.OptionsColumn.ReadOnly = True
        Me.GridColumnEstDelDate.Visible = True
        Me.GridColumnEstDelDate.VisibleIndex = 7
        Me.GridColumnEstDelDate.Width = 47
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTextEdit1.Mask.EditMask = "dd MMMM yyyy"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        Me.RepositoryItemTextEdit1.ReadOnly = True
        '
        'GridColumnEstWHDate
        '
        Me.GridColumnEstWHDate.Caption = "Est. WH. Date"
        Me.GridColumnEstWHDate.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumnEstWHDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnEstWHDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnEstWHDate.FieldName = "est_wh_date"
        Me.GridColumnEstWHDate.Name = "GridColumnEstWHDate"
        Me.GridColumnEstWHDate.OptionsColumn.ReadOnly = True
        Me.GridColumnEstWHDate.Visible = True
        Me.GridColumnEstWHDate.VisibleIndex = 8
        Me.GridColumnEstWHDate.Width = 49
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Mask.EditMask = "dd MMMM yyyy"
        Me.RepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.NullText = "-"
        '
        'GridColumnColod
        '
        Me.GridColumnColod.Caption = "Color"
        Me.GridColumnColod.FieldName = "Color_display"
        Me.GridColumnColod.Name = "GridColumnColod"
        Me.GridColumnColod.OptionsColumn.ReadOnly = True
        Me.GridColumnColod.Visible = True
        Me.GridColumnColod.VisibleIndex = 4
        Me.GridColumnColod.Width = 56
        '
        'GridColumnDelivery
        '
        Me.GridColumnDelivery.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDelivery.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumnDelivery.Caption = "Del"
        Me.GridColumnDelivery.FieldName = "delivery"
        Me.GridColumnDelivery.Name = "GridColumnDelivery"
        Me.GridColumnDelivery.Visible = True
        Me.GridColumnDelivery.VisibleIndex = 6
        Me.GridColumnDelivery.Width = 47
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.FieldNameSortGroup = "id_design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 9
        Me.GridColumnPrice.Width = 56
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.ColumnEdit = Me.RepoQty
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:n0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 10
        Me.GridColumnQty.Width = 47
        '
        'RepoQty
        '
        Me.RepoQty.AutoHeight = False
        Me.RepoQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoQty.IsFloatValue = False
        Me.RepoQty.Mask.EditMask = "N00"
        Me.RepoQty.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepoQty.Name = "RepoQty"
        '
        'GridColumnIsSelect
        '
        Me.GridColumnIsSelect.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnIsSelect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIsSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIsSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIsSelect.Caption = "Select"
        Me.GridColumnIsSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnIsSelect.FieldName = "is_select"
        Me.GridColumnIsSelect.Name = "GridColumnIsSelect"
        Me.GridColumnIsSelect.Visible = True
        Me.GridColumnIsSelect.VisibleIndex = 11
        Me.GridColumnIsSelect.Width = 65
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.Mask.EditMask = "dd MMMM yyyy"
        Me.RepositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        Me.RepositoryItemTextEdit3.NullText = "-"
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-559939585, 902409669, 54, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMImg})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(153, 48)
        '
        'SMImg
        '
        Me.SMImg.Name = "SMImg"
        Me.SMImg.Size = New System.Drawing.Size(152, 22)
        Me.SMImg.Text = "View Image"
        '
        'FormPopUpProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 406)
        Me.Controls.Add(Me.GCProdList)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormPopUpProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pop Up Product"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSelAll.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCProdList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnDesignCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductOrigin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstDelDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstWHDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesignPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PCSelAll As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMImg As ToolStripMenuItem
End Class
