﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBuktiPickupPick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBuktiPickupPick))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SLUEGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLUECompany = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCompany = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICESelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
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
        Me.GridColumnTrackingCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelectAll = New DevExpress.XtraEditors.CheckEdit()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLUEGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUECompany.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.SLUEGroup)
        Me.PanelControl1.Controls.Add(Me.SLUECompany)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.SBView)
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.DEFrom)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.Label6)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1008, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Group"
        '
        'SLUEGroup
        '
        Me.SLUEGroup.Location = New System.Drawing.Point(56, 12)
        Me.SLUEGroup.Name = "SLUEGroup"
        Me.SLUEGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEGroup.Properties.View = Me.GridView1
        Me.SLUEGroup.Size = New System.Drawing.Size(150, 20)
        Me.SLUEGroup.TabIndex = 18
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "id_comp_group"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Group"
        Me.GridColumn2.FieldName = "comp_group"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'SLUECompany
        '
        Me.SLUECompany.Location = New System.Drawing.Point(271, 12)
        Me.SLUECompany.Name = "SLUECompany"
        Me.SLUECompany.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUECompany.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUECompany.Size = New System.Drawing.Size(150, 20)
        Me.SLUECompany.TabIndex = 17
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Store"
        '
        'SBView
        '
        Me.SBView.Location = New System.Drawing.Point(846, 10)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(75, 23)
        Me.SBView.TabIndex = 15
        Me.SBView.Text = "View"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(690, 12)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEUntil.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEUntil.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEUntil.Size = New System.Drawing.Size(150, 20)
        Me.DEUntil.TabIndex = 14
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(484, 12)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEFrom.Size = New System.Drawing.Size(150, 20)
        Me.DEFrom.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(651, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Until"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(442, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "From"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 43)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICESelect})
        Me.GCList.Size = New System.Drawing.Size(1008, 469)
        Me.GCList.TabIndex = 2
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSelect, Me.GridColumnIdDel, Me.GridColumn3, Me.GridColumnNumber, Me.GridColumnCombinedDelivery, Me.GridColumnWarehouse, Me.GridColumnStore, Me.GridColumnStoreGroup, Me.GridColumnPrepareOrder, Me.GridColumnOLStoreOrder, Me.GridColumnCategory, Me.GridColumnTotalDelivery, Me.GridColumnCreatedDate, Me.GridColumnTrackingCode})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowFooter = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSelect
        '
        Me.GridColumnSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.Caption = "*"
        Me.GridColumnSelect.ColumnEdit = Me.RICESelect
        Me.GridColumnSelect.FieldName = "is_select"
        Me.GridColumnSelect.Name = "GridColumnSelect"
        Me.GridColumnSelect.Visible = True
        Me.GridColumnSelect.VisibleIndex = 0
        '
        'RICESelect
        '
        Me.RICESelect.AutoHeight = False
        Me.RICESelect.Name = "RICESelect"
        Me.RICESelect.ValueChecked = "yes"
        Me.RICESelect.ValueUnchecked = "no"
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
        Me.GridColumnNumber.VisibleIndex = 2
        '
        'GridColumnCombinedDelivery
        '
        Me.GridColumnCombinedDelivery.Caption = "Combined Delivery"
        Me.GridColumnCombinedDelivery.FieldName = "combine_number"
        Me.GridColumnCombinedDelivery.Name = "GridColumnCombinedDelivery"
        Me.GridColumnCombinedDelivery.OptionsColumn.AllowEdit = False
        Me.GridColumnCombinedDelivery.Visible = True
        Me.GridColumnCombinedDelivery.VisibleIndex = 3
        Me.GridColumnCombinedDelivery.Width = 99
        '
        'GridColumnWarehouse
        '
        Me.GridColumnWarehouse.Caption = "Warehouse"
        Me.GridColumnWarehouse.FieldName = "wh"
        Me.GridColumnWarehouse.Name = "GridColumnWarehouse"
        Me.GridColumnWarehouse.OptionsColumn.AllowEdit = False
        Me.GridColumnWarehouse.Visible = True
        Me.GridColumnWarehouse.VisibleIndex = 5
        '
        'GridColumnStore
        '
        Me.GridColumnStore.Caption = "Store"
        Me.GridColumnStore.FieldName = "store"
        Me.GridColumnStore.Name = "GridColumnStore"
        Me.GridColumnStore.OptionsColumn.AllowEdit = False
        Me.GridColumnStore.Visible = True
        Me.GridColumnStore.VisibleIndex = 6
        '
        'GridColumnStoreGroup
        '
        Me.GridColumnStoreGroup.Caption = "Store Group"
        Me.GridColumnStoreGroup.FieldName = "comp_group"
        Me.GridColumnStoreGroup.Name = "GridColumnStoreGroup"
        Me.GridColumnStoreGroup.OptionsColumn.AllowEdit = False
        Me.GridColumnStoreGroup.Visible = True
        Me.GridColumnStoreGroup.VisibleIndex = 7
        '
        'GridColumnPrepareOrder
        '
        Me.GridColumnPrepareOrder.Caption = "Prepare Order #"
        Me.GridColumnPrepareOrder.FieldName = "sales_order_number"
        Me.GridColumnPrepareOrder.Name = "GridColumnPrepareOrder"
        Me.GridColumnPrepareOrder.OptionsColumn.AllowEdit = False
        Me.GridColumnPrepareOrder.Visible = True
        Me.GridColumnPrepareOrder.VisibleIndex = 8
        Me.GridColumnPrepareOrder.Width = 90
        '
        'GridColumnOLStoreOrder
        '
        Me.GridColumnOLStoreOrder.Caption = "OL Store Order"
        Me.GridColumnOLStoreOrder.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnOLStoreOrder.Name = "GridColumnOLStoreOrder"
        Me.GridColumnOLStoreOrder.OptionsColumn.AllowEdit = False
        Me.GridColumnOLStoreOrder.Visible = True
        Me.GridColumnOLStoreOrder.VisibleIndex = 9
        Me.GridColumnOLStoreOrder.Width = 83
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "so_status"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.OptionsColumn.AllowEdit = False
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 10
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
        Me.GridColumnTotalDelivery.VisibleIndex = 11
        Me.GridColumnTotalDelivery.Width = 76
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
        Me.GridColumnCreatedDate.VisibleIndex = 12
        '
        'GridColumnTrackingCode
        '
        Me.GridColumnTrackingCode.Caption = "Tracking Code"
        Me.GridColumnTrackingCode.FieldName = "tracking_code"
        Me.GridColumnTrackingCode.Name = "GridColumnTrackingCode"
        Me.GridColumnTrackingCode.OptionsColumn.AllowEdit = False
        Me.GridColumnTrackingCode.Visible = True
        Me.GridColumnTrackingCode.VisibleIndex = 4
        Me.GridColumnTrackingCode.Width = 78
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.CESelectAll)
        Me.PanelControl2.Controls.Add(Me.SBClose)
        Me.PanelControl2.Controls.Add(Me.SBAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 512)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1008, 49)
        Me.PanelControl2.TabIndex = 12
        '
        'CESelectAll
        '
        Me.CESelectAll.Location = New System.Drawing.Point(15, 15)
        Me.CESelectAll.Name = "CESelectAll"
        Me.CESelectAll.Properties.Caption = "Select All"
        Me.CESelectAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelectAll.TabIndex = 5
        '
        'SBClose
        '
        Me.SBClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(832, 2)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(84, 45)
        Me.SBClose.TabIndex = 4
        Me.SBClose.Text = "Close"
        '
        'SBAdd
        '
        Me.SBAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(916, 2)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(90, 45)
        Me.SBAdd.TabIndex = 3
        Me.SBAdd.Text = "Add"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Manifest Print Number"
        Me.GridColumn3.FieldName = "number_odp"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 124
        '
        'FormBuktiPickupPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 561)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.MinimizeBox = False
        Me.Name = "FormBuktiPickupPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bukti Pickup Pick"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLUEGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUECompany.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label6 As Label
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCombinedDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWarehouse As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrepareOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOLStoreOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICESelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents SLUECompany As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCompany As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTrackingCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CESelectAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents SLUEGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
