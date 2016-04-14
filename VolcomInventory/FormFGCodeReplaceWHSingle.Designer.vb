<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGCodeReplaceWHSingle
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
        Me.PanelControlChoose = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControlItem = New DevExpress.XtraEditors.GroupControl
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyReplace = New DevExpress.XtraGrid.Columns.GridColumn
        Me.SpinQtyReplace = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumnSelect = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CheckIsSelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.SLEDO = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        CType(Me.PanelControlChoose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlChoose.SuspendLayout()
        CType(Me.GroupControlItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlItem.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpinQtyReplace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckIsSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlChoose
        '
        Me.PanelControlChoose.Controls.Add(Me.BtnCancel)
        Me.PanelControlChoose.Controls.Add(Me.BtnChoose)
        Me.PanelControlChoose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlChoose.Location = New System.Drawing.Point(0, 428)
        Me.PanelControlChoose.LookAndFeel.SkinName = "Blue"
        Me.PanelControlChoose.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlChoose.Name = "PanelControlChoose"
        Me.PanelControlChoose.Size = New System.Drawing.Size(875, 35)
        Me.PanelControlChoose.TabIndex = 1
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(723, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 31)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(798, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 31)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'GroupControlItem
        '
        Me.GroupControlItem.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlItem.Controls.Add(Me.GCProduct)
        Me.GroupControlItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlItem.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlItem.Name = "GroupControlItem"
        Me.GroupControlItem.Size = New System.Drawing.Size(875, 428)
        Me.GroupControlItem.TabIndex = 2
        Me.GroupControlItem.Text = "Product List"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(22, 2)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.SLEDO, Me.CheckIsSelect, Me.SpinQtyReplace})
        Me.GCProduct.Size = New System.Drawing.Size(851, 424)
        Me.GCProduct.TabIndex = 0
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct, Me.GridView2})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCode, Me.GridColumnDescription, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnQty, Me.GridColumnQtyReplace, Me.GridColumnSelect, Me.GridColumnIdProduct})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.ReadOnly = True
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.Caption = "Description"
        Me.GridColumnDescription.FieldName = "name"
        Me.GridColumnDescription.FieldNameSortGroup = "id_design"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.OptionsColumn.ReadOnly = True
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 1
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.OptionsColumn.ReadOnly = True
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 2
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.ReadOnly = True
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty Limit"
        Me.GridColumnQty.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty_all_product"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.OptionsColumn.ReadOnly = True
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 4
        '
        'GridColumnQtyReplace
        '
        Me.GridColumnQtyReplace.Caption = "Replacement Qty"
        Me.GridColumnQtyReplace.ColumnEdit = Me.SpinQtyReplace
        Me.GridColumnQtyReplace.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnQtyReplace.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyReplace.FieldName = "qty_replace"
        Me.GridColumnQtyReplace.Name = "GridColumnQtyReplace"
        Me.GridColumnQtyReplace.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQtyReplace.Visible = True
        Me.GridColumnQtyReplace.VisibleIndex = 5
        Me.GridColumnQtyReplace.Width = 92
        '
        'SpinQtyReplace
        '
        Me.SpinQtyReplace.AutoHeight = False
        Me.SpinQtyReplace.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.SpinQtyReplace.EditValueChangedDelay = 50
        Me.SpinQtyReplace.IsFloatValue = False
        Me.SpinQtyReplace.Mask.EditMask = "N00"
        Me.SpinQtyReplace.MaxValue = New Decimal(New Integer() {-1486618625, 232830643, 0, 0})
        Me.SpinQtyReplace.Name = "SpinQtyReplace"
        '
        'GridColumnSelect
        '
        Me.GridColumnSelect.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.Caption = "Select Product"
        Me.GridColumnSelect.ColumnEdit = Me.CheckIsSelect
        Me.GridColumnSelect.FieldName = "is_select"
        Me.GridColumnSelect.Name = "GridColumnSelect"
        Me.GridColumnSelect.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnSelect.Visible = True
        Me.GridColumnSelect.VisibleIndex = 6
        Me.GridColumnSelect.Width = 78
        '
        'CheckIsSelect
        '
        Me.CheckIsSelect.AutoHeight = False
        Me.CheckIsSelect.Name = "CheckIsSelect"
        Me.CheckIsSelect.ValueChecked = "Yes"
        Me.CheckIsSelect.ValueUnchecked = "No"
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        Me.GridColumnIdProduct.OptionsColumn.AllowEdit = False
        Me.GridColumnIdProduct.OptionsColumn.ShowInExpressionEditor = False
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'SLEDO
        '
        Me.SLEDO.AutoHeight = False
        Me.SLEDO.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDO.Name = "SLEDO"
        Me.SLEDO.NullText = "-Select Del. Order-"
        Me.SLEDO.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCProduct
        Me.GridView2.Name = "GridView2"
        '
        'FormFGCodeReplaceWHSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 463)
        Me.Controls.Add(Me.GroupControlItem)
        Me.Controls.Add(Me.PanelControlChoose)
        Me.MinimizeBox = False
        Me.Name = "FormFGCodeReplaceWHSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prick Item"
        CType(Me.PanelControlChoose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlChoose.ResumeLayout(False)
        CType(Me.GroupControlItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlItem.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpinQtyReplace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckIsSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlChoose As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlItem As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEDO As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnQtyReplace As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SpinQtyReplace As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckIsSelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
