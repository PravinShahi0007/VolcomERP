<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLStoreDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOLStoreDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SearchLookUpEdit1 = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnBrowseFile = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumnItemId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumnOLStoreID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumnUniPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCustName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnShippingName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAddress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPhone = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPostCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRegion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPaymentMethod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTrackingCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit()
        Me.RepositoryItemHyperLinkEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepoAttachDetail = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoAttachDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnBrowseFile)
        Me.PanelControl1.Controls.Add(Me.SearchLookUpEdit1)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(961, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Group Store"
        '
        'SearchLookUpEdit1
        '
        Me.SearchLookUpEdit1.Location = New System.Drawing.Point(85, 12)
        Me.SearchLookUpEdit1.Name = "SearchLookUpEdit1"
        Me.SearchLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEdit1.Properties.View = Me.SearchLookUpEdit1View
        Me.SearchLookUpEdit1.Size = New System.Drawing.Size(189, 20)
        Me.SearchLookUpEdit1.TabIndex = 2
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'BtnBrowseFile
        '
        Me.BtnBrowseFile.Image = CType(resources.GetObject("BtnBrowseFile.Image"), System.Drawing.Image)
        Me.BtnBrowseFile.Location = New System.Drawing.Point(280, 10)
        Me.BtnBrowseFile.Name = "BtnBrowseFile"
        Me.BtnBrowseFile.Size = New System.Drawing.Size(129, 23)
        Me.BtnBrowseFile.TabIndex = 1
        Me.BtnBrowseFile.Text = "Browse Excel File"
        '
        'BtnLoad
        '
        Me.BtnLoad.Appearance.BackColor = System.Drawing.Color.SlateBlue
        Me.BtnLoad.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoad.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnLoad.Appearance.Options.UseBackColor = True
        Me.BtnLoad.Appearance.Options.UseFont = True
        Me.BtnLoad.Appearance.Options.UseForeColor = True
        Me.BtnLoad.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnLoad.Location = New System.Drawing.Point(0, 526)
        Me.BtnLoad.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnLoad.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnLoad.LookAndFeel.SkinName = "Metropolis"
        Me.BtnLoad.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnLoad.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(961, 31)
        Me.BtnLoad.TabIndex = 4
        Me.BtnLoad.Text = "Create Order"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 45)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2, Me.RepositoryItemImageEdit2, Me.RepositoryItemHyperLinkEdit2, Me.RepositoryItemCheckEdit2, Me.RepositoryItemSearchLookUpEdit1, Me.RepoAttachDetail})
        Me.GCDetail.Size = New System.Drawing.Size(961, 481)
        Me.GCDetail.TabIndex = 5
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6, Me.GridColumn14, Me.GridColumn20, Me.BandedGridColumnCode, Me.BandedGridColumnDescription, Me.BandedGridColumnItemId, Me.BandedGridColumnOLStoreID, Me.BandedGridColumnQty, Me.BandedGridColumnUniPrice, Me.BandedGridColumnAmount, Me.GridColumnCustName, Me.GridColumnShippingName, Me.GridColumnAddress, Me.GridColumnPhone, Me.GridColumnCity, Me.GridColumnPostCode, Me.GridColumnRegion, Me.GridColumnPaymentMethod, Me.GridColumnTrackingCode})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsView.ColumnAutoWidth = False
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "OL Store Order#"
        Me.GridColumn5.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn5.FieldName = "ol_store_order_number"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 150
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.NullText = "-"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "ERP Order#"
        Me.GridColumn6.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn6.FieldName = "order_number"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        Me.GridColumn6.Width = 150
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Id SO"
        Me.GridColumn14.FieldName = "id_so"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Order Date"
        Me.GridColumn20.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn20.FieldName = "order_date"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.ReadOnly = True
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 4
        Me.GridColumn20.Width = 119
        '
        'BandedGridColumnCode
        '
        Me.BandedGridColumnCode.Caption = "Product Code"
        Me.BandedGridColumnCode.FieldName = "code"
        Me.BandedGridColumnCode.Name = "BandedGridColumnCode"
        Me.BandedGridColumnCode.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnCode.Visible = True
        Me.BandedGridColumnCode.VisibleIndex = 5
        Me.BandedGridColumnCode.Width = 117
        '
        'BandedGridColumnDescription
        '
        Me.BandedGridColumnDescription.Caption = "Product Name"
        Me.BandedGridColumnDescription.FieldName = "name"
        Me.BandedGridColumnDescription.Name = "BandedGridColumnDescription"
        Me.BandedGridColumnDescription.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnDescription.Visible = True
        Me.BandedGridColumnDescription.VisibleIndex = 6
        Me.BandedGridColumnDescription.Width = 97
        '
        'BandedGridColumnItemId
        '
        Me.BandedGridColumnItemId.Caption = "Item Id"
        Me.BandedGridColumnItemId.FieldName = "item_id"
        Me.BandedGridColumnItemId.Name = "BandedGridColumnItemId"
        Me.BandedGridColumnItemId.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnItemId.Visible = True
        Me.BandedGridColumnItemId.VisibleIndex = 2
        '
        'BandedGridColumnOLStoreID
        '
        Me.BandedGridColumnOLStoreID.Caption = "OL Store Id"
        Me.BandedGridColumnOLStoreID.FieldName = "ol_store_id"
        Me.BandedGridColumnOLStoreID.Name = "BandedGridColumnOLStoreID"
        Me.BandedGridColumnOLStoreID.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnOLStoreID.Visible = True
        Me.BandedGridColumnOLStoreID.VisibleIndex = 3
        '
        'BandedGridColumnQty
        '
        Me.BandedGridColumnQty.Caption = "Qty"
        Me.BandedGridColumnQty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQty.FieldName = "order_qty"
        Me.BandedGridColumnQty.Name = "BandedGridColumnQty"
        Me.BandedGridColumnQty.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_qty", "{0:N0}")})
        Me.BandedGridColumnQty.Visible = True
        Me.BandedGridColumnQty.VisibleIndex = 7
        '
        'BandedGridColumnUniPrice
        '
        Me.BandedGridColumnUniPrice.Caption = "Unit Price"
        Me.BandedGridColumnUniPrice.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnUniPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnUniPrice.FieldName = "design_price"
        Me.BandedGridColumnUniPrice.Name = "BandedGridColumnUniPrice"
        Me.BandedGridColumnUniPrice.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnUniPrice.Visible = True
        Me.BandedGridColumnUniPrice.VisibleIndex = 8
        '
        'BandedGridColumnAmount
        '
        Me.BandedGridColumnAmount.Caption = "Amount"
        Me.BandedGridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAmount.FieldName = "amount"
        Me.BandedGridColumnAmount.Name = "BandedGridColumnAmount"
        Me.BandedGridColumnAmount.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.BandedGridColumnAmount.UnboundExpression = "[order_qty] * [design_price]"
        Me.BandedGridColumnAmount.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnAmount.Visible = True
        Me.BandedGridColumnAmount.VisibleIndex = 9
        '
        'GridColumnCustName
        '
        Me.GridColumnCustName.Caption = "Customer Name"
        Me.GridColumnCustName.FieldName = "customer_name"
        Me.GridColumnCustName.Name = "GridColumnCustName"
        Me.GridColumnCustName.Visible = True
        Me.GridColumnCustName.VisibleIndex = 10
        Me.GridColumnCustName.Width = 98
        '
        'GridColumnShippingName
        '
        Me.GridColumnShippingName.Caption = "Shipping Name"
        Me.GridColumnShippingName.FieldName = "shipping_name"
        Me.GridColumnShippingName.Name = "GridColumnShippingName"
        Me.GridColumnShippingName.Visible = True
        Me.GridColumnShippingName.VisibleIndex = 11
        Me.GridColumnShippingName.Width = 98
        '
        'GridColumnAddress
        '
        Me.GridColumnAddress.Caption = "Address"
        Me.GridColumnAddress.FieldName = "shipping_address"
        Me.GridColumnAddress.Name = "GridColumnAddress"
        Me.GridColumnAddress.Visible = True
        Me.GridColumnAddress.VisibleIndex = 13
        '
        'GridColumnPhone
        '
        Me.GridColumnPhone.Caption = "Phone"
        Me.GridColumnPhone.FieldName = "shipping_phone"
        Me.GridColumnPhone.Name = "GridColumnPhone"
        Me.GridColumnPhone.Visible = True
        Me.GridColumnPhone.VisibleIndex = 12
        '
        'GridColumnCity
        '
        Me.GridColumnCity.Caption = "City"
        Me.GridColumnCity.FieldName = "shipping_city"
        Me.GridColumnCity.Name = "GridColumnCity"
        Me.GridColumnCity.Visible = True
        Me.GridColumnCity.VisibleIndex = 14
        '
        'GridColumnPostCode
        '
        Me.GridColumnPostCode.Caption = "Post Code"
        Me.GridColumnPostCode.FieldName = "shipping_post_code"
        Me.GridColumnPostCode.Name = "GridColumnPostCode"
        Me.GridColumnPostCode.Visible = True
        Me.GridColumnPostCode.VisibleIndex = 15
        '
        'GridColumnRegion
        '
        Me.GridColumnRegion.Caption = "Region"
        Me.GridColumnRegion.FieldName = "shipping_region"
        Me.GridColumnRegion.Name = "GridColumnRegion"
        Me.GridColumnRegion.Visible = True
        Me.GridColumnRegion.VisibleIndex = 16
        '
        'GridColumnPaymentMethod
        '
        Me.GridColumnPaymentMethod.Caption = "Payment Method"
        Me.GridColumnPaymentMethod.FieldName = "payment_method"
        Me.GridColumnPaymentMethod.Name = "GridColumnPaymentMethod"
        Me.GridColumnPaymentMethod.Visible = True
        Me.GridColumnPaymentMethod.VisibleIndex = 17
        Me.GridColumnPaymentMethod.Width = 102
        '
        'GridColumnTrackingCode
        '
        Me.GridColumnTrackingCode.Caption = "Tracking Code"
        Me.GridColumnTrackingCode.FieldName = "tracking_code"
        Me.GridColumnTrackingCode.Name = "GridColumnTrackingCode"
        Me.GridColumnTrackingCode.Visible = True
        Me.GridColumnTrackingCode.VisibleIndex = 18
        '
        'RepositoryItemImageEdit2
        '
        Me.RepositoryItemImageEdit2.AutoHeight = False
        Me.RepositoryItemImageEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageEdit2.Name = "RepositoryItemImageEdit2"
        '
        'RepositoryItemHyperLinkEdit2
        '
        Me.RepositoryItemHyperLinkEdit2.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit2.Name = "RepositoryItemHyperLinkEdit2"
        Me.RepositoryItemHyperLinkEdit2.SingleClick = True
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.PictureChecked = CType(resources.GetObject("RepositoryItemCheckEdit2.PictureChecked"), System.Drawing.Image)
        Me.RepositoryItemCheckEdit2.ReadOnly = True
        Me.RepositoryItemCheckEdit2.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "No"
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.View = Me.GridView4
        '
        'GridView4
        '
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'RepoAttachDetail
        '
        Me.RepoAttachDetail.AutoHeight = False
        Me.RepoAttachDetail.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoAttachDetail.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_mark_type", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_mark_type_name", "Transaction")})
        Me.RepoAttachDetail.Name = "RepoAttachDetail"
        '
        'FormOLStoreDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 557)
        Me.Controls.Add(Me.GCDetail)
        Me.Controls.Add(Me.BtnLoad)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormOLStoreDet"
        Me.Text = "Online Store Workplace"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoAttachDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnBrowseFile As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SearchLookUpEdit1 As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnItemId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnOLStoreID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnUniPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCustName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnShippingName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAddress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPhone As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPostCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRegion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPaymentMethod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTrackingCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
    Friend WithEvents RepositoryItemHyperLinkEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepoAttachDetail As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
End Class
