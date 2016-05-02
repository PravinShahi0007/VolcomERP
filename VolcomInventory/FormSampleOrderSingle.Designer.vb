<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleOrderSingle
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
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.TxtAmount = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.SPQty = New DevExpress.XtraEditors.SpinEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.SLEPrice = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnPriceName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCurr = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAvailable = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.SCCSO = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlSample = New DevExpress.XtraEditors.GroupControl
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyWH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControlImg = New DevExpress.XtraEditors.PanelControl
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit
        Me.BtnViewImg = New DevExpress.XtraEditors.SimpleButton
        Me.XTCInfoSO = New DevExpress.XtraTab.XtraTabControl
        Me.XTPInfoQTy = New DevExpress.XtraTab.XtraTabPage
        Me.GCWH = New DevExpress.XtraGrid.GridControl
        Me.GVWH = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnWH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDepartemen = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SCCSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCSO.SuspendLayout()
        CType(Me.GroupControlSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSample.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlImg.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCInfoSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCInfoSO.SuspendLayout()
        Me.XTPInfoQTy.SuspendLayout()
        CType(Me.GCWH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVWH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnCancel)
        Me.PanelControlNav.Controls.Add(Me.BtnChoose)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 554)
        Me.PanelControlNav.LookAndFeel.SkinName = "Blue"
        Me.PanelControlNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(964, 34)
        Me.PanelControlNav.TabIndex = 4
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(812, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 30)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(887, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 30)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.TxtAmount)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.MENote)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.SPQty)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.SLEPrice)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 464)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(964, 90)
        Me.GroupControl1.TabIndex = 5
        Me.GroupControl1.Text = "Data Entry"
        '
        'TxtAmount
        '
        Me.TxtAmount.EditValue = "0.0"
        Me.TxtAmount.Enabled = False
        Me.TxtAmount.Location = New System.Drawing.Point(363, 45)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.Properties.Appearance.Options.UseFont = True
        Me.TxtAmount.Properties.Mask.EditMask = "n2"
        Me.TxtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAmount.Properties.Mask.SaveLiteral = False
        Me.TxtAmount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtAmount.Properties.NullText = "0"
        Me.TxtAmount.Size = New System.Drawing.Size(188, 20)
        Me.TxtAmount.TabIndex = 136
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(363, 28)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 24
        Me.LabelControl4.Text = "Amount"
        '
        'MENote
        '
        Me.MENote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MENote.Location = New System.Drawing.Point(557, 45)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(398, 38)
        Me.MENote.TabIndex = 23
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(557, 28)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl3.TabIndex = 22
        Me.LabelControl3.Text = "Remark"
        '
        'SPQty
        '
        Me.SPQty.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.SPQty.Location = New System.Drawing.Point(209, 44)
        Me.SPQty.Name = "SPQty"
        Me.SPQty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.SPQty.Properties.DisplayFormat.FormatString = "f2"
        Me.SPQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SPQty.Properties.EditValueChangedDelay = 50
        Me.SPQty.Properties.IsFloatValue = False
        Me.SPQty.Properties.Mask.EditMask = "f2"
        Me.SPQty.Properties.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 131072})
        Me.SPQty.Size = New System.Drawing.Size(148, 20)
        Me.SPQty.TabIndex = 21
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(209, 28)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Quantity"
        '
        'SLEPrice
        '
        Me.SLEPrice.Location = New System.Drawing.Point(12, 44)
        Me.SLEPrice.Name = "SLEPrice"
        Me.SLEPrice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPrice.Properties.NullText = "-Select Price-"
        Me.SLEPrice.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEPrice.Size = New System.Drawing.Size(182, 20)
        Me.SLEPrice.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnPriceName, Me.GridColumn3, Me.GridColumnCurr, Me.GridColumn1, Me.GridColumnPriceType, Me.GridColumn4, Me.GridColumnAvailable})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnPriceName
        '
        Me.GridColumnPriceName.Caption = "Price Name"
        Me.GridColumnPriceName.FieldName = "sample_ret_price_name"
        Me.GridColumnPriceName.Name = "GridColumnPriceName"
        Me.GridColumnPriceName.OptionsColumn.AllowEdit = False
        Me.GridColumnPriceName.Visible = True
        Me.GridColumnPriceName.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created Date"
        Me.GridColumn3.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "sample_ret_price_date"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumnCurr
        '
        Me.GridColumnCurr.Caption = "Currency"
        Me.GridColumnCurr.FieldName = "currency"
        Me.GridColumnCurr.Name = "GridColumnCurr"
        Me.GridColumnCurr.Visible = True
        Me.GridColumnCurr.VisibleIndex = 3
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Price"
        Me.GridColumn1.DisplayFormat.FormatString = "n2"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "sample_ret_price"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.Visible = True
        Me.GridColumnPriceType.VisibleIndex = 5
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Price Tag"
        Me.GridColumn4.FieldName = "is_print"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 6
        '
        'GridColumnAvailable
        '
        Me.GridColumnAvailable.Caption = "Available Date"
        Me.GridColumnAvailable.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnAvailable.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnAvailable.FieldName = "sample_ret_price_start_date"
        Me.GridColumnAvailable.Name = "GridColumnAvailable"
        Me.GridColumnAvailable.Visible = True
        Me.GridColumnAvailable.VisibleIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 28)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Retail Price"
        '
        'SCCSO
        '
        Me.SCCSO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCSO.Horizontal = False
        Me.SCCSO.Location = New System.Drawing.Point(0, 0)
        Me.SCCSO.Name = "SCCSO"
        Me.SCCSO.Panel1.Controls.Add(Me.GroupControlSample)
        Me.SCCSO.Panel1.Text = "Panel1"
        Me.SCCSO.Panel2.Controls.Add(Me.XTCInfoSO)
        Me.SCCSO.Panel2.Text = "Panel2"
        Me.SCCSO.Size = New System.Drawing.Size(964, 464)
        Me.SCCSO.SplitterPosition = 246
        Me.SCCSO.TabIndex = 7
        Me.SCCSO.Text = "SplitContainerControl1"
        '
        'GroupControlSample
        '
        Me.GroupControlSample.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControlSample.Controls.Add(Me.GCProduct)
        Me.GroupControlSample.Controls.Add(Me.PanelControlImg)
        Me.GroupControlSample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSample.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSample.Name = "GroupControlSample"
        Me.GroupControlSample.Size = New System.Drawing.Size(964, 246)
        Me.GroupControlSample.TabIndex = 5
        Me.GroupControlSample.Text = "Sample"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(163, 22)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(799, 222)
        Me.GCProduct.TabIndex = 1
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCode, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnSample, Me.GridColumnQtyWH})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.Editable = False
        Me.GVProduct.OptionsBehavior.ReadOnly = True
        Me.GVProduct.OptionsView.ShowFooter = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
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
        Me.GridColumnColor.VisibleIndex = 2
        Me.GridColumnColor.Width = 83
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        '
        'GridColumnSample
        '
        Me.GridColumnSample.Caption = "Description"
        Me.GridColumnSample.FieldName = "name"
        Me.GridColumnSample.FieldNameSortGroup = "id_sample"
        Me.GridColumnSample.Name = "GridColumnSample"
        Me.GridColumnSample.Visible = True
        Me.GridColumnSample.VisibleIndex = 1
        '
        'GridColumnQtyWH
        '
        Me.GridColumnQtyWH.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyWH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyWH.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyWH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyWH.Caption = "Qty"
        Me.GridColumnQtyWH.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnQtyWH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyWH.FieldName = "qty_all_sample"
        Me.GridColumnQtyWH.Name = "GridColumnQtyWH"
        Me.GridColumnQtyWH.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_all_sample", "{0:n2}")})
        Me.GridColumnQtyWH.Visible = True
        Me.GridColumnQtyWH.VisibleIndex = 4
        '
        'PanelControlImg
        '
        Me.PanelControlImg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlImg.Controls.Add(Me.PictureEdit1)
        Me.PanelControlImg.Controls.Add(Me.BtnViewImg)
        Me.PanelControlImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlImg.Location = New System.Drawing.Point(2, 22)
        Me.PanelControlImg.Name = "PanelControlImg"
        Me.PanelControlImg.Size = New System.Drawing.Size(161, 222)
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
        Me.PictureEdit1.Size = New System.Drawing.Size(161, 199)
        Me.PictureEdit1.TabIndex = 3
        '
        'BtnViewImg
        '
        Me.BtnViewImg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewImg.Location = New System.Drawing.Point(0, 199)
        Me.BtnViewImg.Name = "BtnViewImg"
        Me.BtnViewImg.Size = New System.Drawing.Size(161, 23)
        Me.BtnViewImg.TabIndex = 0
        Me.BtnViewImg.Text = "View Image"
        '
        'XTCInfoSO
        '
        Me.XTCInfoSO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCInfoSO.Location = New System.Drawing.Point(0, 0)
        Me.XTCInfoSO.Name = "XTCInfoSO"
        Me.XTCInfoSO.SelectedTabPage = Me.XTPInfoQTy
        Me.XTCInfoSO.Size = New System.Drawing.Size(964, 213)
        Me.XTCInfoSO.TabIndex = 0
        Me.XTCInfoSO.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPInfoQTy})
        '
        'XTPInfoQTy
        '
        Me.XTPInfoQTy.Controls.Add(Me.GCWH)
        Me.XTPInfoQTy.Name = "XTPInfoQTy"
        Me.XTPInfoQTy.Size = New System.Drawing.Size(958, 187)
        Me.XTPInfoQTy.Text = "WH Info"
        '
        'GCWH
        '
        Me.GCWH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCWH.Location = New System.Drawing.Point(0, 0)
        Me.GCWH.MainView = Me.GVWH
        Me.GCWH.Name = "GCWH"
        Me.GCWH.Size = New System.Drawing.Size(958, 187)
        Me.GCWH.TabIndex = 0
        Me.GCWH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVWH})
        '
        'GVWH
        '
        Me.GVWH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnWH, Me.GridColumnQty, Me.GridColumnDepartemen})
        Me.GVWH.GridControl = Me.GCWH
        Me.GVWH.Name = "GVWH"
        Me.GVWH.OptionsView.ShowFooter = True
        Me.GVWH.OptionsView.ShowGroupPanel = False
        '
        'GridColumnWH
        '
        Me.GridColumnWH.Caption = "WH Source"
        Me.GridColumnWH.FieldName = "wh"
        Me.GridColumnWH.Name = "GridColumnWH"
        Me.GridColumnWH.Visible = True
        Me.GridColumnWH.VisibleIndex = 0
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty Available"
        Me.GridColumnQty.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty_all_sample"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_all_sample", "{0:f2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 2
        Me.GridColumnQty.Width = 258
        '
        'GridColumnDepartemen
        '
        Me.GridColumnDepartemen.Caption = "Departement"
        Me.GridColumnDepartemen.FieldName = "departement"
        Me.GridColumnDepartemen.FieldNameSortGroup = "id_departement"
        Me.GridColumnDepartemen.Name = "GridColumnDepartemen"
        Me.GridColumnDepartemen.Visible = True
        Me.GridColumnDepartemen.VisibleIndex = 1
        '
        'FormSampleOrderSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 588)
        Me.Controls.Add(Me.SCCSO)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControlNav)
        Me.MinimizeBox = False
        Me.Name = "FormSampleOrderSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Item"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SPQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SCCSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCSO.ResumeLayout(False)
        CType(Me.GroupControlSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSample.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlImg.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCInfoSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCInfoSO.ResumeLayout(False)
        Me.XTPInfoQTy.ResumeLayout(False)
        CType(Me.GCWH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVWH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TxtAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SPQty As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEPrice As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnPriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SCCSO As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlSample As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlImg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnViewImg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCInfoSO As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPInfoQTy As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCWH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVWH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnWH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyWH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDepartemen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAvailable As DevExpress.XtraGrid.Columns.GridColumn
End Class
