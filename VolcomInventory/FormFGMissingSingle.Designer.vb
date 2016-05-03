<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGMissingSingle
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
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.CheckFilter = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.MEFGMissingNote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCurrencyAmount = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCurrencyPrice = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPrice = New DevExpress.XtraEditors.TextEdit()
        Me.TxtAmount = New DevExpress.XtraEditors.TextEdit()
        Me.SPQty = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControlProduct = New DevExpress.XtraEditors.GroupControl()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignPriceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlImg = New DevExpress.XtraEditors.PanelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.BtnViewImg = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.CheckFilter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.MEFGMissingNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCurrencyAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCurrencyPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlProduct.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlImg.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.CheckFilter)
        Me.PanelControlNav.Controls.Add(Me.BtnChoose)
        Me.PanelControlNav.Controls.Add(Me.BtnCancel)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 368)
        Me.PanelControlNav.LookAndFeel.SkinName = "Blue"
        Me.PanelControlNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(865, 47)
        Me.PanelControlNav.TabIndex = 5
        '
        'CheckFilter
        '
        Me.CheckFilter.Location = New System.Drawing.Point(10, 16)
        Me.CheckFilter.Name = "CheckFilter"
        Me.CheckFilter.Properties.Caption = "Show only available stock"
        Me.CheckFilter.Size = New System.Drawing.Size(170, 19)
        Me.CheckFilter.TabIndex = 2
        Me.CheckFilter.Visible = False
        '
        'BtnChoose
        '
        Me.BtnChoose.Location = New System.Drawing.Point(778, 12)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 23)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(697, 12)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.MEFGMissingNote)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.TxtCurrencyAmount)
        Me.GroupControl1.Controls.Add(Me.TxtCurrencyPrice)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.TxtPrice)
        Me.GroupControl1.Controls.Add(Me.TxtAmount)
        Me.GroupControl1.Controls.Add(Me.SPQty)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 288)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(865, 80)
        Me.GroupControl1.TabIndex = 8
        Me.GroupControl1.Text = "Data Entry"
        '
        'MEFGMissingNote
        '
        Me.MEFGMissingNote.Location = New System.Drawing.Point(41, 130)
        Me.MEFGMissingNote.Name = "MEFGMissingNote"
        Me.MEFGMissingNote.Size = New System.Drawing.Size(227, 44)
        Me.MEFGMissingNote.TabIndex = 140
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 133)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl3.TabIndex = 139
        Me.LabelControl3.Text = "Note"
        '
        'TxtCurrencyAmount
        '
        Me.TxtCurrencyAmount.EditValue = "Rp"
        Me.TxtCurrencyAmount.Location = New System.Drawing.Point(412, 39)
        Me.TxtCurrencyAmount.Name = "TxtCurrencyAmount"
        Me.TxtCurrencyAmount.Properties.ReadOnly = True
        Me.TxtCurrencyAmount.Size = New System.Drawing.Size(38, 20)
        Me.TxtCurrencyAmount.TabIndex = 3
        '
        'TxtCurrencyPrice
        '
        Me.TxtCurrencyPrice.EditValue = "Rp"
        Me.TxtCurrencyPrice.Location = New System.Drawing.Point(41, 39)
        Me.TxtCurrencyPrice.Name = "TxtCurrencyPrice"
        Me.TxtCurrencyPrice.Properties.ReadOnly = True
        Me.TxtCurrencyPrice.Size = New System.Drawing.Size(38, 20)
        Me.TxtCurrencyPrice.TabIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(369, 42)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 24
        Me.LabelControl4.Text = "Amount"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 42)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 138
        Me.LabelControl1.Text = "Price"
        '
        'TxtPrice
        '
        Me.TxtPrice.EditValue = "0.0"
        Me.TxtPrice.Location = New System.Drawing.Point(85, 39)
        Me.TxtPrice.Name = "TxtPrice"
        Me.TxtPrice.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrice.Properties.Appearance.Options.UseFont = True
        Me.TxtPrice.Properties.Mask.EditMask = "n2"
        Me.TxtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtPrice.Properties.Mask.SaveLiteral = False
        Me.TxtPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtPrice.Properties.NullText = "0"
        Me.TxtPrice.Properties.ReadOnly = True
        Me.TxtPrice.Size = New System.Drawing.Size(136, 20)
        Me.TxtPrice.TabIndex = 137
        '
        'TxtAmount
        '
        Me.TxtAmount.EditValue = "0.0"
        Me.TxtAmount.Location = New System.Drawing.Point(456, 39)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.Properties.Appearance.Options.UseFont = True
        Me.TxtAmount.Properties.Mask.EditMask = "n2"
        Me.TxtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAmount.Properties.Mask.SaveLiteral = False
        Me.TxtAmount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtAmount.Properties.NullText = "0"
        Me.TxtAmount.Properties.ReadOnly = True
        Me.TxtAmount.Size = New System.Drawing.Size(135, 20)
        Me.TxtAmount.TabIndex = 136
        '
        'SPQty
        '
        Me.SPQty.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.SPQty.Location = New System.Drawing.Point(279, 39)
        Me.SPQty.Name = "SPQty"
        Me.SPQty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.SPQty.Properties.DisplayFormat.FormatString = "f2"
        Me.SPQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SPQty.Properties.EditValueChangedDelay = 50
        Me.SPQty.Properties.IsFloatValue = False
        Me.SPQty.Properties.Mask.EditMask = "f2"
        Me.SPQty.Properties.Mask.SaveLiteral = False
        Me.SPQty.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.SPQty.Properties.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 131072})
        Me.SPQty.Size = New System.Drawing.Size(72, 20)
        Me.SPQty.TabIndex = 21
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(231, 42)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Quantity"
        '
        'GroupControlProduct
        '
        Me.GroupControlProduct.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControlProduct.Controls.Add(Me.GCProduct)
        Me.GroupControlProduct.Controls.Add(Me.PanelControlImg)
        Me.GroupControlProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlProduct.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlProduct.Name = "GroupControlProduct"
        Me.GroupControlProduct.Size = New System.Drawing.Size(865, 288)
        Me.GroupControlProduct.TabIndex = 9
        Me.GroupControlProduct.Text = "Product"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(180, 20)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(683, 266)
        Me.GCProduct.TabIndex = 2
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnColor, Me.GridColumnPrice, Me.GridColumnQty, Me.GridColumnDesignPriceName, Me.GridColumnPriceType, Me.GridColumnCode})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupCount = 1
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsView.ShowFooter = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        Me.GVProduct.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 41
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Width = 147
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        Me.GridColumnSize.Width = 39
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        Me.GridColumnColor.Width = 38
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 6
        Me.GridColumnPrice.Width = 134
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty_all_product"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_all_product", "{0:f2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 7
        Me.GridColumnQty.Width = 216
        '
        'GridColumnDesignPriceName
        '
        Me.GridColumnDesignPriceName.Caption = "Price Name"
        Me.GridColumnDesignPriceName.FieldName = "design_price_name"
        Me.GridColumnDesignPriceName.Name = "GridColumnDesignPriceName"
        Me.GridColumnDesignPriceName.Visible = True
        Me.GridColumnDesignPriceName.VisibleIndex = 4
        Me.GridColumnDesignPriceName.Width = 114
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.Visible = True
        Me.GridColumnPriceType.VisibleIndex = 5
        Me.GridColumnPriceType.Width = 85
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        '
        'PanelControlImg
        '
        Me.PanelControlImg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlImg.Controls.Add(Me.PictureEdit1)
        Me.PanelControlImg.Controls.Add(Me.BtnViewImg)
        Me.PanelControlImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlImg.Location = New System.Drawing.Point(2, 20)
        Me.PanelControlImg.Name = "PanelControlImg"
        Me.PanelControlImg.Size = New System.Drawing.Size(178, 266)
        Me.PanelControlImg.TabIndex = 1
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(178, 243)
        Me.PictureEdit1.TabIndex = 3
        '
        'BtnViewImg
        '
        Me.BtnViewImg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewImg.Location = New System.Drawing.Point(0, 243)
        Me.BtnViewImg.Name = "BtnViewImg"
        Me.BtnViewImg.Size = New System.Drawing.Size(178, 23)
        Me.BtnViewImg.TabIndex = 0
        Me.BtnViewImg.Text = "View Image"
        '
        'FormFGMissingSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 415)
        Me.Controls.Add(Me.GroupControlProduct)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControlNav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGMissingSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Product"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.CheckFilter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.MEFGMissingNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCurrencyAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCurrencyPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SPQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlProduct.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlImg.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckFilter As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TxtCurrencyAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCurrencyPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SPQty As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlProduct As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignPriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlImg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnViewImg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MEFGMissingNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
