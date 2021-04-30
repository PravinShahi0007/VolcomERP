<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOutboundPOD
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnso_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndel_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndel_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnlast_update = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_mark_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_ol_shop_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncustomer_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnawbill_no = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncargo_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsub_district = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpick_up_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrec_by_store_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrec_by_store_person = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLECity = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEOnlineOffline = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUE3PL = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SBViewOutbound = New DevExpress.XtraEditors.SimpleButton()
        Me.DETo = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLECity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEOnlineOffline.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUE3PL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 44)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(1181, 464)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnno, Me.GridColumnso_status, Me.GridColumndel_number, Me.GridColumndel_date, Me.GridColumnlast_update, Me.GridColumncomp_number, Me.GridColumncomp_name, Me.GridColumncomp_group1, Me.GridColumncomp_group_desc, Me.GridColumnreport_mark_type, Me.GridColumnsales_order_number, Me.GridColumnsales_order_ol_shop_number, Me.GridColumncustomer_name, Me.GridColumntotal_qty, Me.GridColumnnote, Me.GridColumnawbill_no, Me.GridColumncargo_name, Me.GridColumnsub_district, Me.GridColumncity, Me.GridColumnpick_up_date, Me.GridColumnrec_by_store_date, Me.GridColumnrec_by_store_person})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnno
        '
        Me.GridColumnno.Caption = "No"
        Me.GridColumnno.FieldName = "no"
        Me.GridColumnno.Name = "GridColumnno"
        Me.GridColumnno.Visible = True
        Me.GridColumnno.VisibleIndex = 0
        '
        'GridColumnso_status
        '
        Me.GridColumnso_status.Caption = "Category"
        Me.GridColumnso_status.FieldName = "so_status"
        Me.GridColumnso_status.Name = "GridColumnso_status"
        Me.GridColumnso_status.Visible = True
        Me.GridColumnso_status.VisibleIndex = 1
        '
        'GridColumndel_number
        '
        Me.GridColumndel_number.Caption = "Delivery Slip"
        Me.GridColumndel_number.FieldName = "del_number"
        Me.GridColumndel_number.Name = "GridColumndel_number"
        Me.GridColumndel_number.Visible = True
        Me.GridColumndel_number.VisibleIndex = 2
        '
        'GridColumndel_date
        '
        Me.GridColumndel_date.Caption = "Created Date"
        Me.GridColumndel_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumndel_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndel_date.FieldName = "del_date"
        Me.GridColumndel_date.Name = "GridColumndel_date"
        Me.GridColumndel_date.Visible = True
        Me.GridColumndel_date.VisibleIndex = 3
        '
        'GridColumnlast_update
        '
        Me.GridColumnlast_update.Caption = "Last Updated"
        Me.GridColumnlast_update.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnlast_update.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnlast_update.FieldName = "last_update"
        Me.GridColumnlast_update.Name = "GridColumnlast_update"
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Store Acc."
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 4
        '
        'GridColumncomp_name
        '
        Me.GridColumncomp_name.Caption = "Store"
        Me.GridColumncomp_name.FieldName = "comp_name"
        Me.GridColumncomp_name.Name = "GridColumncomp_name"
        Me.GridColumncomp_name.Visible = True
        Me.GridColumncomp_name.VisibleIndex = 5
        '
        'GridColumncomp_group1
        '
        Me.GridColumncomp_group1.Caption = "Store Group"
        Me.GridColumncomp_group1.FieldName = "comp_group"
        Me.GridColumncomp_group1.Name = "GridColumncomp_group1"
        Me.GridColumncomp_group1.Visible = True
        Me.GridColumncomp_group1.VisibleIndex = 6
        '
        'GridColumncomp_group_desc
        '
        Me.GridColumncomp_group_desc.Caption = "Store Group Desc."
        Me.GridColumncomp_group_desc.FieldName = "comp_group_desc"
        Me.GridColumncomp_group_desc.Name = "GridColumncomp_group_desc"
        Me.GridColumncomp_group_desc.Visible = True
        Me.GridColumncomp_group_desc.VisibleIndex = 7
        Me.GridColumncomp_group_desc.Width = 91
        '
        'GridColumnreport_mark_type
        '
        Me.GridColumnreport_mark_type.Caption = "report_mark_type"
        Me.GridColumnreport_mark_type.FieldName = "report_mark_type"
        Me.GridColumnreport_mark_type.Name = "GridColumnreport_mark_type"
        '
        'GridColumnsales_order_number
        '
        Me.GridColumnsales_order_number.Caption = "Prepare Order"
        Me.GridColumnsales_order_number.FieldName = "sales_order_number"
        Me.GridColumnsales_order_number.Name = "GridColumnsales_order_number"
        Me.GridColumnsales_order_number.Visible = True
        Me.GridColumnsales_order_number.VisibleIndex = 8
        Me.GridColumnsales_order_number.Width = 94
        '
        'GridColumnsales_order_ol_shop_number
        '
        Me.GridColumnsales_order_ol_shop_number.Caption = "OL. Store Order"
        Me.GridColumnsales_order_ol_shop_number.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.Name = "GridColumnsales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.Visible = True
        Me.GridColumnsales_order_ol_shop_number.VisibleIndex = 9
        Me.GridColumnsales_order_ol_shop_number.Width = 94
        '
        'GridColumncustomer_name
        '
        Me.GridColumncustomer_name.Caption = "Customer"
        Me.GridColumncustomer_name.FieldName = "customer_name"
        Me.GridColumncustomer_name.Name = "GridColumncustomer_name"
        Me.GridColumncustomer_name.Visible = True
        Me.GridColumncustomer_name.VisibleIndex = 10
        '
        'GridColumntotal_qty
        '
        Me.GridColumntotal_qty.Caption = "Qty"
        Me.GridColumntotal_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty.FieldName = "total_qty"
        Me.GridColumntotal_qty.Name = "GridColumntotal_qty"
        Me.GridColumntotal_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N0}")})
        Me.GridColumntotal_qty.Visible = True
        Me.GridColumntotal_qty.VisibleIndex = 11
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 12
        '
        'GridColumnawbill_no
        '
        Me.GridColumnawbill_no.Caption = "AWB"
        Me.GridColumnawbill_no.FieldName = "awbill_no"
        Me.GridColumnawbill_no.Name = "GridColumnawbill_no"
        Me.GridColumnawbill_no.Visible = True
        Me.GridColumnawbill_no.VisibleIndex = 13
        '
        'GridColumncargo_name
        '
        Me.GridColumncargo_name.Caption = "3PL"
        Me.GridColumncargo_name.FieldName = "cargo_name"
        Me.GridColumncargo_name.Name = "GridColumncargo_name"
        Me.GridColumncargo_name.Visible = True
        Me.GridColumncargo_name.VisibleIndex = 14
        '
        'GridColumnsub_district
        '
        Me.GridColumnsub_district.Caption = "Sub District"
        Me.GridColumnsub_district.FieldName = "sub_district"
        Me.GridColumnsub_district.Name = "GridColumnsub_district"
        Me.GridColumnsub_district.Visible = True
        Me.GridColumnsub_district.VisibleIndex = 15
        '
        'GridColumncity
        '
        Me.GridColumncity.Caption = "City"
        Me.GridColumncity.FieldName = "city"
        Me.GridColumncity.Name = "GridColumncity"
        Me.GridColumncity.Visible = True
        Me.GridColumncity.VisibleIndex = 16
        '
        'GridColumnpick_up_date
        '
        Me.GridColumnpick_up_date.Caption = "Pick Up Date"
        Me.GridColumnpick_up_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnpick_up_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnpick_up_date.FieldName = "pick_up_date"
        Me.GridColumnpick_up_date.Name = "GridColumnpick_up_date"
        Me.GridColumnpick_up_date.Visible = True
        Me.GridColumnpick_up_date.VisibleIndex = 17
        '
        'GridColumnrec_by_store_date
        '
        Me.GridColumnrec_by_store_date.Caption = "Received Date"
        Me.GridColumnrec_by_store_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnrec_by_store_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnrec_by_store_date.FieldName = "rec_by_store_date"
        Me.GridColumnrec_by_store_date.Name = "GridColumnrec_by_store_date"
        Me.GridColumnrec_by_store_date.Visible = True
        Me.GridColumnrec_by_store_date.VisibleIndex = 18
        '
        'GridColumnrec_by_store_person
        '
        Me.GridColumnrec_by_store_person.Caption = "Received by"
        Me.GridColumnrec_by_store_person.FieldName = "rec_by_store_person"
        Me.GridColumnrec_by_store_person.Name = "GridColumnrec_by_store_person"
        Me.GridColumnrec_by_store_person.Visible = True
        Me.GridColumnrec_by_store_person.VisibleIndex = 19
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLECity)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.SLEStoreGroup)
        Me.PanelControl1.Controls.Add(Me.SLEOnlineOffline)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.SLUE3PL)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SBViewOutbound)
        Me.PanelControl1.Controls.Add(Me.DETo)
        Me.PanelControl1.Controls.Add(Me.LabelControl19)
        Me.PanelControl1.Controls.Add(Me.DEFrom)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1181, 44)
        Me.PanelControl1.TabIndex = 1
        '
        'SLECity
        '
        Me.SLECity.Location = New System.Drawing.Point(820, 12)
        Me.SLECity.Name = "SLECity"
        Me.SLECity.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECity.Properties.ShowClearButton = False
        Me.SLECity.Properties.View = Me.SearchLookUpEdit1View
        Me.SLECity.Size = New System.Drawing.Size(100, 20)
        Me.SLECity.TabIndex = 8943
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(795, 15)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl6.TabIndex = 8942
        Me.LabelControl6.Text = "City"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(620, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 8940
        Me.LabelControl3.Text = "Store Group"
        '
        'SLEStoreGroup
        '
        Me.SLEStoreGroup.Location = New System.Drawing.Point(684, 12)
        Me.SLEStoreGroup.Name = "SLEStoreGroup"
        Me.SLEStoreGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroup.Properties.View = Me.GridView3
        Me.SLEStoreGroup.Size = New System.Drawing.Size(105, 20)
        Me.SLEStoreGroup.TabIndex = 8941
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumncomp_group, Me.GridColumndescription})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'SLEOnlineOffline
        '
        Me.SLEOnlineOffline.Location = New System.Drawing.Point(385, 12)
        Me.SLEOnlineOffline.Name = "SLEOnlineOffline"
        Me.SLEOnlineOffline.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEOnlineOffline.Properties.View = Me.GridView2
        Me.SLEOnlineOffline.Size = New System.Drawing.Size(100, 20)
        Me.SLEOnlineOffline.TabIndex = 8939
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn32, Me.GridColumn33})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn32
        '
        Me.GridColumn32.FieldName = "id_type"
        Me.GridColumn32.Name = "GridColumn32"
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Type"
        Me.GridColumn33.FieldName = "type"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(491, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl2.TabIndex = 8938
        Me.LabelControl2.Text = "3PL"
        '
        'SLUE3PL
        '
        Me.SLUE3PL.Location = New System.Drawing.Point(514, 12)
        Me.SLUE3PL.Name = "SLUE3PL"
        Me.SLUE3PL.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUE3PL.Properties.View = Me.GridView1
        Me.SLUE3PL.Size = New System.Drawing.Size(100, 20)
        Me.SLUE3PL.TabIndex = 8937
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn30, Me.GridColumn31})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn30
        '
        Me.GridColumn30.FieldName = "id_3pl"
        Me.GridColumn30.Name = "GridColumn30"
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "3PL"
        Me.GridColumn31.FieldName = "3pl"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(355, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 8936
        Me.LabelControl1.Text = "Type"
        '
        'SBViewOutbound
        '
        Me.SBViewOutbound.Location = New System.Drawing.Point(926, 10)
        Me.SBViewOutbound.Name = "SBViewOutbound"
        Me.SBViewOutbound.Size = New System.Drawing.Size(75, 23)
        Me.SBViewOutbound.TabIndex = 8933
        Me.SBViewOutbound.Text = "View"
        '
        'DETo
        '
        Me.DETo.EditValue = Nothing
        Me.DETo.Location = New System.Drawing.Point(197, 12)
        Me.DETo.Name = "DETo"
        Me.DETo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DETo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DETo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETo.Size = New System.Drawing.Size(152, 20)
        Me.DETo.TabIndex = 8932
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(179, 15)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl19.TabIndex = 8931
        Me.LabelControl19.Text = "To"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(12, 12)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Size = New System.Drawing.Size(161, 20)
        Me.DEFrom.TabIndex = 8930
        '
        'FormOutboundPOD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1181, 508)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormOutboundPOD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Outbound POD Report"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLECity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEOnlineOffline.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUE3PL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEOnlineOffline As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLUE3PL As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBViewOutbound As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DETo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStoreGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLECity As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnso_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndel_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndel_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnlast_update As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_mark_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_ol_shop_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncustomer_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnawbill_no As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncargo_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsub_district As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpick_up_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrec_by_store_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrec_by_store_person As DevExpress.XtraGrid.Columns.GridColumn
End Class
