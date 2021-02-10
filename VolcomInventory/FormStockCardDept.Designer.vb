<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockCardDept
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStockCardDept))
        Me.XTCStockCard = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPStockCard = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.XTPStockOnHand = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSOH = New DevExpress.XtraGrid.GridControl()
        Me.GVSOH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdItemCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DESOHUntil = New DevExpress.XtraEditors.DateEdit()
        Me.XTPStockInOut = New DevExpress.XtraTab.XtraTabPage()
        Me.SLEITem = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnItemId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEUntilSC = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnViewSC = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFromSC = New DevExpress.XtraEditors.DateEdit()
        Me.GCSC = New DevExpress.XtraGrid.GridControl()
        Me.GVSC = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnTransNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStorageDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtySC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBalQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStorageCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntype = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCStockCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCStockCard.SuspendLayout()
        Me.XTPStockCard.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.XTPStockOnHand.SuspendLayout()
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DESOHUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DESOHUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEITem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilSC.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilSC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromSC.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromSC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCStockCard
        '
        Me.XTCStockCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCStockCard.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCStockCard.Location = New System.Drawing.Point(0, 0)
        Me.XTCStockCard.Name = "XTCStockCard"
        Me.XTCStockCard.SelectedTabPage = Me.XTPStockCard
        Me.XTCStockCard.Size = New System.Drawing.Size(1077, 539)
        Me.XTCStockCard.TabIndex = 0
        Me.XTCStockCard.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPStockOnHand, Me.XTPStockCard, Me.XTPStockInOut})
        '
        'XTPStockCard
        '
        Me.XTPStockCard.Controls.Add(Me.GCSC)
        Me.XTPStockCard.Controls.Add(Me.PanelControl1)
        Me.XTPStockCard.Name = "XTPStockCard"
        Me.XTPStockCard.Size = New System.Drawing.Size(1071, 511)
        Me.XTPStockCard.Text = "Stock Card"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEITem)
        Me.PanelControl1.Controls.Add(Me.DEUntilSC)
        Me.PanelControl1.Controls.Add(Me.LabelControl7)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.BtnViewSC)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.DEFromSC)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1071, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'XTPStockOnHand
        '
        Me.XTPStockOnHand.Controls.Add(Me.GCSOH)
        Me.XTPStockOnHand.Controls.Add(Me.PanelControl2)
        Me.XTPStockOnHand.Name = "XTPStockOnHand"
        Me.XTPStockOnHand.Size = New System.Drawing.Size(1071, 511)
        Me.XTPStockOnHand.Text = "Stock On Hand"
        '
        'GCSOH
        '
        Me.GCSOH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSOH.Location = New System.Drawing.Point(0, 46)
        Me.GCSOH.MainView = Me.GVSOH
        Me.GCSOH.Name = "GCSOH"
        Me.GCSOH.Size = New System.Drawing.Size(1071, 465)
        Me.GCSOH.TabIndex = 2
        Me.GCSOH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSOH})
        '
        'GVSOH
        '
        Me.GVSOH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdItem, Me.GridColumn12, Me.GridColumnItemDesc, Me.GridColumnIdItemCat, Me.GridColumnItemCat, Me.GridColumnQty, Me.GridColumnAmount, Me.GridColumnIdDept, Me.GridColumnDept, Me.GridColumnValue, Me.GridColumn6})
        Me.GVSOH.GridControl = Me.GCSOH
        Me.GVSOH.GroupCount = 1
        Me.GVSOH.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQty, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnAmount, "{0:N2}")})
        Me.GVSOH.Name = "GVSOH"
        Me.GVSOH.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSOH.OptionsBehavior.Editable = False
        Me.GVSOH.OptionsView.ShowFooter = True
        Me.GVSOH.OptionsView.ShowGroupPanel = False
        Me.GVSOH.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDept, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdItem
        '
        Me.GridColumnIdItem.Caption = "Id Item"
        Me.GridColumnIdItem.FieldName = "id_item"
        Me.GridColumnIdItem.Name = "GridColumnIdItem"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Kode Item"
        Me.GridColumn12.FieldName = "id_item"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 0
        Me.GridColumn12.Width = 117
        '
        'GridColumnItemDesc
        '
        Me.GridColumnItemDesc.Caption = "Item"
        Me.GridColumnItemDesc.FieldName = "item_name"
        Me.GridColumnItemDesc.Name = "GridColumnItemDesc"
        Me.GridColumnItemDesc.Visible = True
        Me.GridColumnItemDesc.VisibleIndex = 1
        Me.GridColumnItemDesc.Width = 505
        '
        'GridColumnIdItemCat
        '
        Me.GridColumnIdItemCat.Caption = "Id Cat"
        Me.GridColumnIdItemCat.FieldName = "id_item_cat"
        Me.GridColumnIdItemCat.Name = "GridColumnIdItemCat"
        '
        'GridColumnItemCat
        '
        Me.GridColumnItemCat.Caption = "Description"
        Me.GridColumnItemCat.FieldName = "item_detail"
        Me.GridColumnItemCat.Name = "GridColumnItemCat"
        Me.GridColumnItemCat.Visible = True
        Me.GridColumnItemCat.VisibleIndex = 2
        Me.GridColumnItemCat.Width = 505
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        Me.GridColumnQty.Width = 505
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnAmount.UnboundExpression = "[qty] * [value]"
        Me.GridColumnAmount.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        '
        'GridColumnIdDept
        '
        Me.GridColumnIdDept.Caption = "Id Departement"
        Me.GridColumnIdDept.FieldName = "id_departement"
        Me.GridColumnIdDept.Name = "GridColumnIdDept"
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Departement"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 0
        '
        'GridColumnValue
        '
        Me.GridColumnValue.Caption = "Cost"
        Me.GridColumnValue.DisplayFormat.FormatString = "N2"
        Me.GridColumnValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValue.FieldName = "value"
        Me.GridColumnValue.Name = "GridColumnValue"
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "UOM"
        Me.GridColumn6.FieldName = "uom"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnView)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.DESOHUntil)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1071, 46)
        Me.PanelControl2.TabIndex = 1
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(215, 11)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 25
        Me.BtnView.Text = "View"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(10, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 27
        Me.LabelControl2.Text = "Until"
        '
        'DESOHUntil
        '
        Me.DESOHUntil.EditValue = Nothing
        Me.DESOHUntil.Location = New System.Drawing.Point(37, 13)
        Me.DESOHUntil.Name = "DESOHUntil"
        Me.DESOHUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESOHUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESOHUntil.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DESOHUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DESOHUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DESOHUntil.Size = New System.Drawing.Size(172, 20)
        Me.DESOHUntil.TabIndex = 26
        '
        'XTPStockInOut
        '
        Me.XTPStockInOut.Name = "XTPStockInOut"
        Me.XTPStockInOut.Size = New System.Drawing.Size(1071, 511)
        Me.XTPStockInOut.Text = "In / Out"
        '
        'SLEITem
        '
        Me.SLEITem.Location = New System.Drawing.Point(39, 11)
        Me.SLEITem.Name = "SLEITem"
        Me.SLEITem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEITem.Properties.ShowClearButton = False
        Me.SLEITem.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEITem.Size = New System.Drawing.Size(177, 20)
        Me.SLEITem.TabIndex = 29
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnItemId, Me.GridColumn13, Me.GridColumnDesc, Me.GridColumnCat, Me.GridColumn8})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        Me.SearchLookUpEdit1View.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn13, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnItemId
        '
        Me.GridColumnItemId.Caption = "id item"
        Me.GridColumnItemId.FieldName = "id_item"
        Me.GridColumnItemId.Name = "GridColumnItemId"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Kode Item"
        Me.GridColumn13.FieldName = "id_item"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        Me.GridColumn13.Width = 178
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Description"
        Me.GridColumnDesc.FieldName = "item_desc"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 1
        Me.GridColumnDesc.Width = 727
        '
        'GridColumnCat
        '
        Me.GridColumnCat.Caption = "Category"
        Me.GridColumnCat.FieldName = "item_cat"
        Me.GridColumnCat.Name = "GridColumnCat"
        Me.GridColumnCat.Visible = True
        Me.GridColumnCat.VisibleIndex = 2
        Me.GridColumnCat.Width = 727
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "UOM"
        Me.GridColumn8.FieldName = "uom"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 3
        '
        'DEUntilSC
        '
        Me.DEUntilSC.EditValue = Nothing
        Me.DEUntilSC.Location = New System.Drawing.Point(393, 11)
        Me.DEUntilSC.Name = "DEUntilSC"
        Me.DEUntilSC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilSC.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilSC.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DEUntilSC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilSC.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilSC.Size = New System.Drawing.Size(110, 20)
        Me.DEUntilSC.TabIndex = 35
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(222, 14)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl7.TabIndex = 34
        Me.LabelControl7.Text = "From"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl4.TabIndex = 33
        Me.LabelControl4.Text = "Item"
        '
        'BtnViewSC
        '
        Me.BtnViewSC.Image = CType(resources.GetObject("BtnViewSC.Image"), System.Drawing.Image)
        Me.BtnViewSC.Location = New System.Drawing.Point(509, 9)
        Me.BtnViewSC.Name = "BtnViewSC"
        Me.BtnViewSC.Size = New System.Drawing.Size(75, 23)
        Me.BtnViewSC.TabIndex = 30
        Me.BtnViewSC.Text = "View"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(366, 14)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 32
        Me.LabelControl3.Text = "Until"
        '
        'DEFromSC
        '
        Me.DEFromSC.EditValue = Nothing
        Me.DEFromSC.Location = New System.Drawing.Point(250, 11)
        Me.DEFromSC.Name = "DEFromSC"
        Me.DEFromSC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromSC.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromSC.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DEFromSC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromSC.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromSC.Size = New System.Drawing.Size(110, 20)
        Me.DEFromSC.TabIndex = 31
        '
        'GCSC
        '
        Me.GCSC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSC.Location = New System.Drawing.Point(0, 46)
        Me.GCSC.MainView = Me.GVSC
        Me.GCSC.Name = "GCSC"
        Me.GCSC.Size = New System.Drawing.Size(1071, 465)
        Me.GCSC.TabIndex = 3
        Me.GCSC.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSC})
        '
        'GVSC
        '
        Me.GVSC.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnTransNumber, Me.GridColumnStorageDate, Me.GridColumnQtySC, Me.GridColumnBalQty, Me.GridColumnStorageCat, Me.GridColumntype, Me.GridColumnStatus})
        Me.GVSC.GridControl = Me.GCSC
        Me.GVSC.Name = "GVSC"
        Me.GVSC.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSC.OptionsBehavior.Editable = False
        Me.GVSC.OptionsCustomization.AllowSort = False
        Me.GVSC.OptionsView.ShowGroupPanel = False
        '
        'GridColumnTransNumber
        '
        Me.GridColumnTransNumber.Caption = "Transaction Number"
        Me.GridColumnTransNumber.FieldName = "trans_number"
        Me.GridColumnTransNumber.Name = "GridColumnTransNumber"
        Me.GridColumnTransNumber.Visible = True
        Me.GridColumnTransNumber.VisibleIndex = 1
        '
        'GridColumnStorageDate
        '
        Me.GridColumnStorageDate.Caption = "Time"
        Me.GridColumnStorageDate.DisplayFormat.FormatString = "dd MMM yyyy HH:mm"
        Me.GridColumnStorageDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnStorageDate.FieldName = "storage_date"
        Me.GridColumnStorageDate.Name = "GridColumnStorageDate"
        Me.GridColumnStorageDate.Visible = True
        Me.GridColumnStorageDate.VisibleIndex = 3
        '
        'GridColumnQtySC
        '
        Me.GridColumnQtySC.Caption = "Qty"
        Me.GridColumnQtySC.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtySC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtySC.FieldName = "qty"
        Me.GridColumnQtySC.Name = "GridColumnQtySC"
        Me.GridColumnQtySC.Visible = True
        Me.GridColumnQtySC.VisibleIndex = 4
        '
        'GridColumnBalQty
        '
        Me.GridColumnBalQty.Caption = "Balance"
        Me.GridColumnBalQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnBalQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBalQty.FieldName = "bal_qty"
        Me.GridColumnBalQty.Name = "GridColumnBalQty"
        Me.GridColumnBalQty.Visible = True
        Me.GridColumnBalQty.VisibleIndex = 5
        '
        'GridColumnStorageCat
        '
        Me.GridColumnStorageCat.Caption = "Movement"
        Me.GridColumnStorageCat.FieldName = "storage_category"
        Me.GridColumnStorageCat.Name = "GridColumnStorageCat"
        Me.GridColumnStorageCat.Visible = True
        Me.GridColumnStorageCat.VisibleIndex = 6
        '
        'GridColumntype
        '
        Me.GridColumntype.Caption = "Transaction Type"
        Me.GridColumntype.FieldName = "type"
        Me.GridColumntype.Name = "GridColumntype"
        Me.GridColumntype.Visible = True
        Me.GridColumntype.VisibleIndex = 0
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Transaction Status"
        Me.GridColumnStatus.FieldName = "status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 2
        '
        'FormStockCardDept
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 539)
        Me.Controls.Add(Me.XTCStockCard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormStockCardDept"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Stock Card"
        CType(Me.XTCStockCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCStockCard.ResumeLayout(False)
        Me.XTPStockCard.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.XTPStockOnHand.ResumeLayout(False)
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DESOHUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DESOHUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEITem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilSC.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilSC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromSC.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromSC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCStockCard As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPStockCard As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPStockInOut As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTPStockOnHand As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DESOHUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GCSOH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdItemCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEITem As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnItemId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEUntilSC As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewSC As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFromSC As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GCSC As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSC As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnTransNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStorageDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtySC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBalQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStorageCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntype As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
