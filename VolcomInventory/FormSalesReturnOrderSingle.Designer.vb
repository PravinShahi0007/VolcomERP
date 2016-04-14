<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturnOrderSingle
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
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEReturnCat = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdReturnCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReturnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.TxtPrice = New DevExpress.XtraEditors.TextEdit()
        Me.TxtAmount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SPQty = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControlSample = New DevExpress.XtraEditors.GroupControl()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyQC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlImg = New DevExpress.XtraEditors.PanelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.BtnViewImg = New DevExpress.XtraEditors.SimpleButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.SLEReturnCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSample.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlImg.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnChoose)
        Me.PanelControlNav.Controls.Add(Me.LabelControl5)
        Me.PanelControlNav.Controls.Add(Me.SLEReturnCat)
        Me.PanelControlNav.Controls.Add(Me.BtnCancel)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 381)
        Me.PanelControlNav.LookAndFeel.SkinName = "Blue"
        Me.PanelControlNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(882, 47)
        Me.PanelControlNav.TabIndex = 4
        '
        'BtnChoose
        '
        Me.BtnChoose.Location = New System.Drawing.Point(783, 12)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 23)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(370, 52)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(81, 13)
        Me.LabelControl5.TabIndex = 137
        Me.LabelControl5.Text = "Return Category"
        '
        'SLEReturnCat
        '
        Me.SLEReturnCat.Location = New System.Drawing.Point(217, 55)
        Me.SLEReturnCat.Name = "SLEReturnCat"
        Me.SLEReturnCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEReturnCat.Properties.NullText = "[Return category not available]"
        Me.SLEReturnCat.Properties.View = Me.GridView1
        Me.SLEReturnCat.Size = New System.Drawing.Size(132, 20)
        Me.SLEReturnCat.TabIndex = 4
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdReturnCategory, Me.GridColumnReturnCat})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdReturnCategory
        '
        Me.GridColumnIdReturnCategory.Caption = "Id Return Category"
        Me.GridColumnIdReturnCategory.FieldName = "id_return_cat"
        Me.GridColumnIdReturnCategory.Name = "GridColumnIdReturnCategory"
        '
        'GridColumnReturnCat
        '
        Me.GridColumnReturnCat.Caption = "Return Category"
        Me.GridColumnReturnCat.FieldName = "return_cat"
        Me.GridColumnReturnCat.Name = "GridColumnReturnCat"
        Me.GridColumnReturnCat.Visible = True
        Me.GridColumnReturnCat.VisibleIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(702, 12)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.TxtPrice)
        Me.GroupControl1.Controls.Add(Me.TxtAmount)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.MENote)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.SPQty)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 277)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(882, 104)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Data Entry"
        '
        'TxtPrice
        '
        Me.TxtPrice.EditValue = "0.0"
        Me.TxtPrice.Enabled = False
        Me.TxtPrice.Location = New System.Drawing.Point(12, 52)
        Me.TxtPrice.Name = "TxtPrice"
        Me.TxtPrice.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrice.Properties.Appearance.Options.UseFont = True
        Me.TxtPrice.Properties.Mask.EditMask = "n2"
        Me.TxtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtPrice.Properties.Mask.SaveLiteral = False
        Me.TxtPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtPrice.Properties.NullText = "0"
        Me.TxtPrice.Size = New System.Drawing.Size(176, 20)
        Me.TxtPrice.TabIndex = 138
        '
        'TxtAmount
        '
        Me.TxtAmount.EditValue = "0.0"
        Me.TxtAmount.Enabled = False
        Me.TxtAmount.Location = New System.Drawing.Point(288, 52)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.Properties.Appearance.Options.UseFont = True
        Me.TxtAmount.Properties.Mask.EditMask = "n2"
        Me.TxtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAmount.Properties.Mask.SaveLiteral = False
        Me.TxtAmount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtAmount.Properties.NullText = "0"
        Me.TxtAmount.Size = New System.Drawing.Size(97, 20)
        Me.TxtAmount.TabIndex = 3
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(288, 33)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 24
        Me.LabelControl4.Text = "Amount"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(391, 50)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(465, 38)
        Me.MENote.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(391, 33)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl3.TabIndex = 22
        Me.LabelControl3.Text = "Remark"
        '
        'SPQty
        '
        Me.SPQty.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.SPQty.Location = New System.Drawing.Point(194, 52)
        Me.SPQty.Name = "SPQty"
        Me.SPQty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.SPQty.Properties.DisplayFormat.FormatString = "f2"
        Me.SPQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SPQty.Properties.EditValueChangedDelay = 50
        Me.SPQty.Properties.IsFloatValue = False
        Me.SPQty.Properties.Mask.EditMask = "f2"
        Me.SPQty.Properties.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 131072})
        Me.SPQty.Size = New System.Drawing.Size(88, 20)
        Me.SPQty.TabIndex = 21
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(194, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Quantity"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Retail Price"
        '
        'GroupControlSample
        '
        Me.GroupControlSample.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControlSample.Controls.Add(Me.GCProduct)
        Me.GroupControlSample.Controls.Add(Me.PanelControlImg)
        Me.GroupControlSample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSample.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSample.Name = "GroupControlSample"
        Me.GroupControlSample.Size = New System.Drawing.Size(882, 277)
        Me.GroupControlSample.TabIndex = 6
        Me.GroupControlSample.Text = "Product"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(212, 20)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(668, 255)
        Me.GCProduct.TabIndex = 1
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCode, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnDesign, Me.GridColumn2, Me.GridColumnQtyQC, Me.GridColumnIdProduct, Me.GridColumnDesignPriceType, Me.GridColumnPrice})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupCount = 2
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.ReadOnly = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        Me.GVProduct.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDesign, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 1
        Me.GridColumnColor.Width = 83
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_name"
        Me.GridColumnDesign.FieldNameSortGroup = "id_design"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Season"
        Me.GridColumn2.FieldName = "season"
        Me.GridColumn2.FieldNameSortGroup = "id_season"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumnQtyQC
        '
        Me.GridColumnQtyQC.Caption = "Qty"
        Me.GridColumnQtyQC.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnQtyQC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyQC.FieldName = "qty_all_product"
        Me.GridColumnQtyQC.Name = "GridColumnQtyQC"
        Me.GridColumnQtyQC.Visible = True
        Me.GridColumnQtyQC.VisibleIndex = 4
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        '
        'GridColumnDesignPriceType
        '
        Me.GridColumnDesignPriceType.Caption = "Price Type"
        Me.GridColumnDesignPriceType.FieldName = "design_price_type"
        Me.GridColumnDesignPriceType.Name = "GridColumnDesignPriceType"
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price_retail"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 3
        '
        'PanelControlImg
        '
        Me.PanelControlImg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlImg.Controls.Add(Me.PictureEdit1)
        Me.PanelControlImg.Controls.Add(Me.BtnViewImg)
        Me.PanelControlImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlImg.Location = New System.Drawing.Point(2, 20)
        Me.PanelControlImg.Name = "PanelControlImg"
        Me.PanelControlImg.Size = New System.Drawing.Size(210, 255)
        Me.PanelControlImg.TabIndex = 0
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(210, 232)
        Me.PictureEdit1.TabIndex = 3
        '
        'BtnViewImg
        '
        Me.BtnViewImg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewImg.Location = New System.Drawing.Point(0, 232)
        Me.BtnViewImg.Name = "BtnViewImg"
        Me.BtnViewImg.Size = New System.Drawing.Size(210, 23)
        Me.BtnViewImg.TabIndex = 0
        Me.BtnViewImg.Text = "View Image"
        '
        'FormSalesReturnOrderSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 428)
        Me.Controls.Add(Me.GroupControlSample)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControlNav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReturnOrderSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Item Sales Return Order"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        Me.PanelControlNav.PerformLayout()
        CType(Me.SLEReturnCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SPQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSample.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlImg.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TxtAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SPQty As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlSample As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyQC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlImg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnViewImg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEReturnCat As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdReturnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReturnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TxtPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
