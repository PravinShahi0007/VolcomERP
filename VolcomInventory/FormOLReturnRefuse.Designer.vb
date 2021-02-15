<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLReturnRefuse
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
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPCreated = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_return_refuse = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_refuse_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrefuse_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_store_contact = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_ol_shop_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_ol_shop_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncustomer_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnshipping_address = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_return_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_return_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_pos_cn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_number_cn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPOrderList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumncreated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPCreated.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPOrderList.SuspendLayout()
        CType(Me.GCOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPCreated
        Me.XTCData.Size = New System.Drawing.Size(707, 470)
        Me.XTCData.TabIndex = 0
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPCreated, Me.XTPOrderList})
        '
        'XTPCreated
        '
        Me.XTPCreated.Controls.Add(Me.GCData)
        Me.XTPCreated.Controls.Add(Me.GCFilter)
        Me.XTPCreated.Name = "XTPCreated"
        Me.XTPCreated.Size = New System.Drawing.Size(701, 442)
        Me.XTPCreated.Text = "Created List"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 39)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(701, 403)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_return_refuse, Me.GridColumnid_refuse_type, Me.GridColumnrefuse_type, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumnid_store_contact, Me.GridColumnid_comp, Me.GridColumncomp_number, Me.GridColumncomp_name, Me.GridColumnid_comp_group, Me.GridColumncomp_group, Me.GridColumncomp_group_desc, Me.GridColumnid_sales_order, Me.GridColumnsales_order_number, Me.GridColumnsales_order_ol_shop_number, Me.GridColumnsales_order_date, Me.GridColumnsales_order_ol_shop_date, Me.GridColumncustomer_name, Me.GridColumnshipping_address, Me.GridColumnid_sales_return_order, Me.GridColumnsales_return_order_number, Me.GridColumnid_sales_pos_cn, Me.GridColumnsales_pos_number_cn, Me.GridColumnnote, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumncreated_by_name})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_return_refuse
        '
        Me.GridColumnid_return_refuse.Caption = "id_return_refuse"
        Me.GridColumnid_return_refuse.FieldName = "id_return_refuse"
        Me.GridColumnid_return_refuse.Name = "GridColumnid_return_refuse"
        '
        'GridColumnid_refuse_type
        '
        Me.GridColumnid_refuse_type.Caption = "id_refuse_type"
        Me.GridColumnid_refuse_type.FieldName = "id_refuse_type"
        Me.GridColumnid_refuse_type.Name = "GridColumnid_refuse_type"
        '
        'GridColumnrefuse_type
        '
        Me.GridColumnrefuse_type.Caption = "Type"
        Me.GridColumnrefuse_type.FieldName = "refuse_type"
        Me.GridColumnrefuse_type.Name = "GridColumnrefuse_type"
        Me.GridColumnrefuse_type.Visible = True
        Me.GridColumnrefuse_type.VisibleIndex = 1
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 7
        '
        'GridColumnid_store_contact
        '
        Me.GridColumnid_store_contact.Caption = "id_store_contact"
        Me.GridColumnid_store_contact.FieldName = "id_store_contact"
        Me.GridColumnid_store_contact.Name = "GridColumnid_store_contact"
        '
        'GridColumnid_comp
        '
        Me.GridColumnid_comp.Caption = "id_comp"
        Me.GridColumnid_comp.FieldName = "id_comp"
        Me.GridColumnid_comp.Name = "GridColumnid_comp"
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
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Store Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        '
        'GridColumncomp_group_desc
        '
        Me.GridColumncomp_group_desc.Caption = "Store Group"
        Me.GridColumncomp_group_desc.FieldName = "comp_group_desc"
        Me.GridColumncomp_group_desc.Name = "GridColumncomp_group_desc"
        Me.GridColumncomp_group_desc.Visible = True
        Me.GridColumncomp_group_desc.VisibleIndex = 6
        '
        'GridColumnid_sales_order
        '
        Me.GridColumnid_sales_order.Caption = "id_sales_order"
        Me.GridColumnid_sales_order.FieldName = "id_sales_order"
        Me.GridColumnid_sales_order.Name = "GridColumnid_sales_order"
        '
        'GridColumnsales_order_number
        '
        Me.GridColumnsales_order_number.Caption = "SO. No."
        Me.GridColumnsales_order_number.FieldName = "sales_order_number"
        Me.GridColumnsales_order_number.Name = "GridColumnsales_order_number"
        '
        'GridColumnsales_order_ol_shop_number
        '
        Me.GridColumnsales_order_ol_shop_number.Caption = "Order Number"
        Me.GridColumnsales_order_ol_shop_number.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.Name = "GridColumnsales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.Visible = True
        Me.GridColumnsales_order_ol_shop_number.VisibleIndex = 2
        Me.GridColumnsales_order_ol_shop_number.Width = 99
        '
        'GridColumnsales_order_date
        '
        Me.GridColumnsales_order_date.Caption = "SO Date"
        Me.GridColumnsales_order_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnsales_order_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_order_date.FieldName = "sales_order_date"
        Me.GridColumnsales_order_date.Name = "GridColumnsales_order_date"
        '
        'GridColumnsales_order_ol_shop_date
        '
        Me.GridColumnsales_order_ol_shop_date.Caption = "Order Date"
        Me.GridColumnsales_order_ol_shop_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnsales_order_ol_shop_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_order_ol_shop_date.FieldName = "sales_order_ol_shop_date"
        Me.GridColumnsales_order_ol_shop_date.Name = "GridColumnsales_order_ol_shop_date"
        '
        'GridColumncustomer_name
        '
        Me.GridColumncustomer_name.Caption = "Customer"
        Me.GridColumncustomer_name.FieldName = "customer_name"
        Me.GridColumncustomer_name.Name = "GridColumncustomer_name"
        Me.GridColumncustomer_name.Visible = True
        Me.GridColumncustomer_name.VisibleIndex = 3
        '
        'GridColumnshipping_address
        '
        Me.GridColumnshipping_address.Caption = "Address"
        Me.GridColumnshipping_address.FieldName = "shipping_address"
        Me.GridColumnshipping_address.Name = "GridColumnshipping_address"
        '
        'GridColumnid_sales_return_order
        '
        Me.GridColumnid_sales_return_order.Caption = "id_sales_return_order"
        Me.GridColumnid_sales_return_order.FieldName = "id_sales_return_order"
        Me.GridColumnid_sales_return_order.Name = "GridColumnid_sales_return_order"
        '
        'GridColumnsales_return_order_number
        '
        Me.GridColumnsales_return_order_number.Caption = "ROR. No."
        Me.GridColumnsales_return_order_number.FieldName = "sales_return_order_number"
        Me.GridColumnsales_return_order_number.Name = "GridColumnsales_return_order_number"
        '
        'GridColumnid_sales_pos_cn
        '
        Me.GridColumnid_sales_pos_cn.Caption = "id_sales_pos_cn"
        Me.GridColumnid_sales_pos_cn.FieldName = "id_sales_pos_cn"
        Me.GridColumnid_sales_pos_cn.Name = "GridColumnid_sales_pos_cn"
        '
        'GridColumnsales_pos_number_cn
        '
        Me.GridColumnsales_pos_number_cn.Caption = "CN. No."
        Me.GridColumnsales_pos_number_cn.FieldName = "sales_pos_number_cn"
        Me.GridColumnsales_pos_number_cn.Name = "GridColumnsales_pos_number_cn"
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        '
        'GridColumnid_report_status
        '
        Me.GridColumnid_report_status.Caption = "id_report_status"
        Me.GridColumnid_report_status.FieldName = "id_report_status"
        Me.GridColumnid_report_status.Name = "GridColumnid_report_status"
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 9
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Controls.Add(Me.DEUntil)
        Me.GCFilter.Controls.Add(Me.DEFrom)
        Me.GCFilter.Controls.Add(Me.LabelControl2)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(701, 39)
        Me.GCFilter.TabIndex = 5
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(317, 9)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(835, 14)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(202, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(58, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'XTPOrderList
        '
        Me.XTPOrderList.Controls.Add(Me.GCOrder)
        Me.XTPOrderList.Controls.Add(Me.GroupControl1)
        Me.XTPOrderList.Name = "XTPOrderList"
        Me.XTPOrderList.Size = New System.Drawing.Size(701, 442)
        Me.XTPOrderList.Text = "Order List"
        '
        'GCOrder
        '
        Me.GCOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOrder.Location = New System.Drawing.Point(0, 39)
        Me.GCOrder.MainView = Me.GVOrder
        Me.GCOrder.Name = "GCOrder"
        Me.GCOrder.Size = New System.Drawing.Size(701, 403)
        Me.GCOrder.TabIndex = 7
        Me.GCOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOrder})
        '
        'GVOrder
        '
        Me.GVOrder.GridControl = Me.GCOrder
        Me.GVOrder.Name = "GVOrder"
        Me.GVOrder.OptionsBehavior.ReadOnly = True
        Me.GVOrder.OptionsFind.AlwaysVisible = True
        Me.GVOrder.OptionsView.ColumnAutoWidth = False
        Me.GVOrder.OptionsView.ShowGroupPanel = False
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.SimpleButton3)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(701, 39)
        Me.GroupControl1.TabIndex = 6
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageIndex = 9
        Me.SimpleButton2.Location = New System.Drawing.Point(938, 14)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(104, 20)
        Me.SimpleButton2.TabIndex = 8898
        Me.SimpleButton2.Text = "Hide All Detail"
        Me.SimpleButton2.Visible = False
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageIndex = 8
        Me.SimpleButton3.Location = New System.Drawing.Point(835, 14)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(99, 20)
        Me.SimpleButton3.TabIndex = 8897
        Me.SimpleButton3.Text = "Expand All Detail"
        Me.SimpleButton3.Visible = False
        '
        'GridColumncreated_by_name
        '
        Me.GridColumncreated_by_name.Caption = "Created by"
        Me.GridColumncreated_by_name.FieldName = "created_by_name"
        Me.GridColumncreated_by_name.Name = "GridColumncreated_by_name"
        Me.GridColumncreated_by_name.Visible = True
        Me.GridColumncreated_by_name.VisibleIndex = 8
        '
        'FormOLReturnRefuse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 470)
        Me.Controls.Add(Me.XTCData)
        Me.MinimizeBox = False
        Me.Name = "FormOLReturnRefuse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Refuse Return Online Order"
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPCreated.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPOrderList.ResumeLayout(False)
        CType(Me.GCOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPCreated As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPOrderList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_return_refuse As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_refuse_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrefuse_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_store_contact As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_ol_shop_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_ol_shop_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncustomer_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnshipping_address As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_return_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_return_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_pos_cn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_number_cn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by_name As DevExpress.XtraGrid.Columns.GridColumn
End Class
