<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBuktiPickupDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBuktiPickupDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCombinedDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWarehouse = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrepareOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOLStoreOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DEDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SLUECompany = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCompany = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TEUpdatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.DEUpdatedDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.DECreatedDate = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SBCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.TEReportStatus = New DevExpress.XtraEditors.TextEdit()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SBComplete = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAttachement = New DevExpress.XtraEditors.SimpleButton()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUECompany.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEUpdatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUpdatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUpdatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.TEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBRemove)
        Me.PanelControl1.Controls.Add(Me.SBAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 69)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1008, 49)
        Me.PanelControl1.TabIndex = 0
        '
        'SBRemove
        '
        Me.SBRemove.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBRemove.Image = CType(resources.GetObject("SBRemove.Image"), System.Drawing.Image)
        Me.SBRemove.Location = New System.Drawing.Point(824, 2)
        Me.SBRemove.Name = "SBRemove"
        Me.SBRemove.Size = New System.Drawing.Size(100, 45)
        Me.SBRemove.TabIndex = 0
        Me.SBRemove.Text = "Remove"
        '
        'SBAdd
        '
        Me.SBAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(924, 2)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(82, 45)
        Me.SBAdd.TabIndex = 1
        Me.SBAdd.Text = "Add"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 118)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(1008, 417)
        Me.GCList.TabIndex = 1
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdDel, Me.GridColumnNo, Me.GridColumnNumber, Me.GridColumnCombinedDelivery, Me.GridColumnWarehouse, Me.GridColumnStore, Me.GridColumnStoreGroup, Me.GridColumnPrepareOrder, Me.GridColumnOLStoreOrder, Me.GridColumnCategory, Me.GridColumnTotalDelivery, Me.GridColumnCreatedDate})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowFooter = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdDel
        '
        Me.GridColumnIdDel.FieldName = "id_pl_sales_order_del"
        Me.GridColumnIdDel.Name = "GridColumnIdDel"
        Me.GridColumnIdDel.OptionsColumn.AllowEdit = False
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "pl_sales_order_del_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 1
        '
        'GridColumnCombinedDelivery
        '
        Me.GridColumnCombinedDelivery.Caption = "Combined Delivery"
        Me.GridColumnCombinedDelivery.FieldName = "combine_number"
        Me.GridColumnCombinedDelivery.Name = "GridColumnCombinedDelivery"
        Me.GridColumnCombinedDelivery.OptionsColumn.AllowEdit = False
        Me.GridColumnCombinedDelivery.Visible = True
        Me.GridColumnCombinedDelivery.VisibleIndex = 2
        '
        'GridColumnWarehouse
        '
        Me.GridColumnWarehouse.Caption = "Warehouse"
        Me.GridColumnWarehouse.FieldName = "wh"
        Me.GridColumnWarehouse.Name = "GridColumnWarehouse"
        Me.GridColumnWarehouse.OptionsColumn.AllowEdit = False
        Me.GridColumnWarehouse.Visible = True
        Me.GridColumnWarehouse.VisibleIndex = 3
        '
        'GridColumnStore
        '
        Me.GridColumnStore.Caption = "Store"
        Me.GridColumnStore.FieldName = "store"
        Me.GridColumnStore.Name = "GridColumnStore"
        Me.GridColumnStore.OptionsColumn.AllowEdit = False
        Me.GridColumnStore.Visible = True
        Me.GridColumnStore.VisibleIndex = 4
        '
        'GridColumnStoreGroup
        '
        Me.GridColumnStoreGroup.Caption = "Store Group"
        Me.GridColumnStoreGroup.FieldName = "comp_group"
        Me.GridColumnStoreGroup.Name = "GridColumnStoreGroup"
        Me.GridColumnStoreGroup.OptionsColumn.AllowEdit = False
        Me.GridColumnStoreGroup.Visible = True
        Me.GridColumnStoreGroup.VisibleIndex = 5
        '
        'GridColumnPrepareOrder
        '
        Me.GridColumnPrepareOrder.Caption = "Prepare Order #"
        Me.GridColumnPrepareOrder.FieldName = "sales_order_number"
        Me.GridColumnPrepareOrder.Name = "GridColumnPrepareOrder"
        Me.GridColumnPrepareOrder.OptionsColumn.AllowEdit = False
        Me.GridColumnPrepareOrder.Visible = True
        Me.GridColumnPrepareOrder.VisibleIndex = 6
        '
        'GridColumnOLStoreOrder
        '
        Me.GridColumnOLStoreOrder.Caption = "OL Store Order"
        Me.GridColumnOLStoreOrder.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnOLStoreOrder.Name = "GridColumnOLStoreOrder"
        Me.GridColumnOLStoreOrder.OptionsColumn.AllowEdit = False
        Me.GridColumnOLStoreOrder.Visible = True
        Me.GridColumnOLStoreOrder.VisibleIndex = 7
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "so_status"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.OptionsColumn.AllowEdit = False
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 8
        '
        'GridColumnTotalDelivery
        '
        Me.GridColumnTotalDelivery.Caption = "Total Delivery"
        Me.GridColumnTotalDelivery.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotalDelivery.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalDelivery.FieldName = "total"
        Me.GridColumnTotalDelivery.Name = "GridColumnTotalDelivery"
        Me.GridColumnTotalDelivery.OptionsColumn.AllowEdit = False
        Me.GridColumnTotalDelivery.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N0}")})
        Me.GridColumnTotalDelivery.Visible = True
        Me.GridColumnTotalDelivery.VisibleIndex = 9
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "pl_sales_order_del_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.OptionsColumn.AllowEdit = False
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 10
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.Label7)
        Me.PanelControl2.Controls.Add(Me.DEDate)
        Me.PanelControl2.Controls.Add(Me.Label6)
        Me.PanelControl2.Controls.Add(Me.SLUECompany)
        Me.PanelControl2.Controls.Add(Me.Label4)
        Me.PanelControl2.Controls.Add(Me.Label5)
        Me.PanelControl2.Controls.Add(Me.TEUpdatedBy)
        Me.PanelControl2.Controls.Add(Me.DEUpdatedDate)
        Me.PanelControl2.Controls.Add(Me.Label3)
        Me.PanelControl2.Controls.Add(Me.Label2)
        Me.PanelControl2.Controls.Add(Me.TECreatedBy)
        Me.PanelControl2.Controls.Add(Me.DECreatedDate)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1008, 69)
        Me.PanelControl2.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Pickup Date"
        '
        'DEDate
        '
        Me.DEDate.EditValue = Nothing
        Me.DEDate.Location = New System.Drawing.Point(86, 38)
        Me.DEDate.Name = "DEDate"
        Me.DEDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDate.Properties.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DEDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEDate.Size = New System.Drawing.Size(200, 20)
        Me.DEDate.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Cargo"
        '
        'SLUECompany
        '
        Me.SLUECompany.Location = New System.Drawing.Point(86, 12)
        Me.SLUECompany.Name = "SLUECompany"
        Me.SLUECompany.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUECompany.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUECompany.Size = New System.Drawing.Size(200, 20)
        Me.SLUECompany.TabIndex = 8
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdComp, Me.GCCompany})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GCIdComp
        '
        Me.GCIdComp.FieldName = "id_comp"
        Me.GCIdComp.Name = "GCIdComp"
        '
        'GCCompany
        '
        Me.GCCompany.Caption = "Company"
        Me.GCCompany.FieldName = "comp_name"
        Me.GCCompany.Name = "GCCompany"
        Me.GCCompany.Visible = True
        Me.GCCompany.VisibleIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(713, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Update Date"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(423, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Updated By"
        '
        'TEUpdatedBy
        '
        Me.TEUpdatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEUpdatedBy.Location = New System.Drawing.Point(497, 38)
        Me.TEUpdatedBy.Name = "TEUpdatedBy"
        Me.TEUpdatedBy.Properties.ReadOnly = True
        Me.TEUpdatedBy.Size = New System.Drawing.Size(200, 20)
        Me.TEUpdatedBy.TabIndex = 5
        '
        'DEUpdatedDate
        '
        Me.DEUpdatedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DEUpdatedDate.EditValue = Nothing
        Me.DEUpdatedDate.Location = New System.Drawing.Point(796, 38)
        Me.DEUpdatedDate.Name = "DEUpdatedDate"
        Me.DEUpdatedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUpdatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUpdatedDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DEUpdatedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUpdatedDate.Properties.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DEUpdatedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUpdatedDate.Properties.Mask.EditMask = "dd MMMM yyyy HH:mm:ss"
        Me.DEUpdatedDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEUpdatedDate.Properties.ReadOnly = True
        Me.DEUpdatedDate.Size = New System.Drawing.Size(200, 20)
        Me.DEUpdatedDate.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(713, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Created Date"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(423, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Created By"
        '
        'TECreatedBy
        '
        Me.TECreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TECreatedBy.Location = New System.Drawing.Point(497, 12)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(200, 20)
        Me.TECreatedBy.TabIndex = 1
        '
        'DECreatedDate
        '
        Me.DECreatedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DECreatedDate.EditValue = Nothing
        Me.DECreatedDate.Location = New System.Drawing.Point(796, 12)
        Me.DECreatedDate.Name = "DECreatedDate"
        Me.DECreatedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreatedDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreatedDate.Properties.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreatedDate.Properties.Mask.EditMask = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DECreatedDate.Properties.ReadOnly = True
        Me.DECreatedDate.Size = New System.Drawing.Size(200, 20)
        Me.DECreatedDate.TabIndex = 0
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.Label1)
        Me.PanelControl3.Controls.Add(Me.MENote)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 580)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1008, 100)
        Me.PanelControl3.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MENote.Location = New System.Drawing.Point(75, 16)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(921, 71)
        Me.MENote.TabIndex = 0
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.Label8)
        Me.PanelControl4.Controls.Add(Me.SBCancel)
        Me.PanelControl4.Controls.Add(Me.TEReportStatus)
        Me.PanelControl4.Controls.Add(Me.SBSave)
        Me.PanelControl4.Controls.Add(Me.SBComplete)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(0, 680)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(1008, 49)
        Me.PanelControl4.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Report Status"
        '
        'SBCancel
        '
        Me.SBCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBCancel.Image = CType(resources.GetObject("SBCancel.Image"), System.Drawing.Image)
        Me.SBCancel.Location = New System.Drawing.Point(653, 2)
        Me.SBCancel.Name = "SBCancel"
        Me.SBCancel.Size = New System.Drawing.Size(129, 45)
        Me.SBCancel.TabIndex = 4
        Me.SBCancel.Text = "Cancel Propose"
        '
        'TEReportStatus
        '
        Me.TEReportStatus.Location = New System.Drawing.Point(97, 15)
        Me.TEReportStatus.Name = "TEReportStatus"
        Me.TEReportStatus.Properties.ReadOnly = True
        Me.TEReportStatus.Size = New System.Drawing.Size(200, 20)
        Me.TEReportStatus.TabIndex = 12
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(782, 2)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(123, 45)
        Me.SBSave.TabIndex = 3
        Me.SBSave.Text = "Save Changes"
        '
        'SBComplete
        '
        Me.SBComplete.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBComplete.Image = CType(resources.GetObject("SBComplete.Image"), System.Drawing.Image)
        Me.SBComplete.Location = New System.Drawing.Point(905, 2)
        Me.SBComplete.Name = "SBComplete"
        Me.SBComplete.Size = New System.Drawing.Size(101, 45)
        Me.SBComplete.TabIndex = 2
        Me.SBComplete.Text = "Complete"
        '
        'SBAttachement
        '
        Me.SBAttachement.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SBAttachement.Location = New System.Drawing.Point(0, 535)
        Me.SBAttachement.Name = "SBAttachement"
        Me.SBAttachement.Size = New System.Drawing.Size(1008, 45)
        Me.SBAttachement.TabIndex = 4
        Me.SBAttachement.Text = "Attachment"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        '
        'FormBuktiPickupDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.SBAttachement)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl4)
        Me.Name = "FormBuktiPickupDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bukti Pickup Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUECompany.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEUpdatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUpdatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUpdatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.TEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DECreatedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents SBAttachement As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBComplete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TEUpdatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DEUpdatedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents SLUECompany As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCompany As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCombinedDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWarehouse As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrepareOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOLStoreOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label7 As Label
    Friend WithEvents DEDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents SBCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnStoreGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents TEReportStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
End Class
