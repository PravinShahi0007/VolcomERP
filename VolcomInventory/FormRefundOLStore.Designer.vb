<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRefundOLStore
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
        Me.XTPAcceptedList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_ol_store_refund = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_order_ol_shop = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_ol_shop_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPOrderList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCOrderList = New DevExpress.XtraGrid.GridControl()
        Me.GVOrderList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_ol_shop_number_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncustomer_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.SLECompGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumnwh_normal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnwh_sale = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPAcceptedList.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPOrderList.SuspendLayout()
        CType(Me.GCOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLECompGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPAcceptedList
        Me.XTCData.Size = New System.Drawing.Size(754, 504)
        Me.XTCData.TabIndex = 2
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPAcceptedList, Me.XTPOrderList})
        '
        'XTPAcceptedList
        '
        Me.XTPAcceptedList.Controls.Add(Me.GCData)
        Me.XTPAcceptedList.Name = "XTPAcceptedList"
        Me.XTPAcceptedList.Size = New System.Drawing.Size(748, 476)
        Me.XTPAcceptedList.Text = "Accepted List"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(748, 476)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_ol_store_refund, Me.GridColumnid_sales_order_ol_shop, Me.GridColumnsales_order_ol_shop_number, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumncreated_by_name, Me.GridColumnnote, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumncomp_group_name, Me.GridColumnwh_normal, Me.GridColumnwh_sale})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_ol_store_refund
        '
        Me.GridColumnid_ol_store_refund.Caption = "id_ol_store_refund"
        Me.GridColumnid_ol_store_refund.FieldName = "id_ol_store_refund"
        Me.GridColumnid_ol_store_refund.Name = "GridColumnid_ol_store_refund"
        '
        'GridColumnid_sales_order_ol_shop
        '
        Me.GridColumnid_sales_order_ol_shop.Caption = "id_sales_order_ol_shop"
        Me.GridColumnid_sales_order_ol_shop.FieldName = "id_sales_order_ol_shop"
        Me.GridColumnid_sales_order_ol_shop.Name = "GridColumnid_sales_order_ol_shop"
        '
        'GridColumnsales_order_ol_shop_number
        '
        Me.GridColumnsales_order_ol_shop_number.Caption = "Order Number"
        Me.GridColumnsales_order_ol_shop_number.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.Name = "GridColumnsales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.Visible = True
        Me.GridColumnsales_order_ol_shop_number.VisibleIndex = 2
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
        Me.GridColumncreated_date.VisibleIndex = 5
        '
        'GridColumncreated_by_name
        '
        Me.GridColumncreated_by_name.Caption = "Created By"
        Me.GridColumncreated_by_name.FieldName = "created_by_name"
        Me.GridColumncreated_by_name.Name = "GridColumncreated_by_name"
        Me.GridColumncreated_by_name.Visible = True
        Me.GridColumncreated_by_name.VisibleIndex = 6
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
        Me.GridColumnreport_status.VisibleIndex = 7
        '
        'GridColumncomp_group_name
        '
        Me.GridColumncomp_group_name.Caption = "Store Group"
        Me.GridColumncomp_group_name.FieldName = "comp_group_name"
        Me.GridColumncomp_group_name.Name = "GridColumncomp_group_name"
        Me.GridColumncomp_group_name.Visible = True
        Me.GridColumncomp_group_name.VisibleIndex = 1
        '
        'XTPOrderList
        '
        Me.XTPOrderList.Controls.Add(Me.GCOrderList)
        Me.XTPOrderList.Controls.Add(Me.PanelControl1)
        Me.XTPOrderList.Name = "XTPOrderList"
        Me.XTPOrderList.Size = New System.Drawing.Size(748, 476)
        Me.XTPOrderList.Text = "Order List"
        '
        'GCOrderList
        '
        Me.GCOrderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOrderList.Location = New System.Drawing.Point(0, 43)
        Me.GCOrderList.MainView = Me.GVOrderList
        Me.GCOrderList.Name = "GCOrderList"
        Me.GCOrderList.Size = New System.Drawing.Size(748, 433)
        Me.GCOrderList.TabIndex = 1
        Me.GCOrderList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOrderList})
        '
        'GVOrderList
        '
        Me.GVOrderList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group_order, Me.GridColumnsales_order_ol_shop_number_order, Me.GridColumnorder_date, Me.GridColumncustomer_name})
        Me.GVOrderList.GridControl = Me.GCOrderList
        Me.GVOrderList.Name = "GVOrderList"
        Me.GVOrderList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVOrderList.OptionsBehavior.Editable = False
        Me.GVOrderList.OptionsFind.AlwaysVisible = True
        Me.GVOrderList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group_order
        '
        Me.GridColumnid_comp_group_order.Caption = "id_comp_group"
        Me.GridColumnid_comp_group_order.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group_order.Name = "GridColumnid_comp_group_order"
        '
        'GridColumnsales_order_ol_shop_number_order
        '
        Me.GridColumnsales_order_ol_shop_number_order.Caption = "Order Number"
        Me.GridColumnsales_order_ol_shop_number_order.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number_order.Name = "GridColumnsales_order_ol_shop_number_order"
        Me.GridColumnsales_order_ol_shop_number_order.Visible = True
        Me.GridColumnsales_order_ol_shop_number_order.VisibleIndex = 0
        '
        'GridColumnorder_date
        '
        Me.GridColumnorder_date.Caption = "Order Date"
        Me.GridColumnorder_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnorder_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnorder_date.FieldName = "order_date"
        Me.GridColumnorder_date.Name = "GridColumnorder_date"
        '
        'GridColumncustomer_name
        '
        Me.GridColumncustomer_name.Caption = "Customer"
        Me.GridColumncustomer_name.FieldName = "customer_name"
        Me.GridColumncustomer_name.Name = "GridColumncustomer_name"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnViewOrder)
        Me.PanelControl1.Controls.Add(Me.SLECompGroup)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(748, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnViewOrder
        '
        Me.BtnViewOrder.Location = New System.Drawing.Point(307, 10)
        Me.BtnViewOrder.Name = "BtnViewOrder"
        Me.BtnViewOrder.Size = New System.Drawing.Size(75, 23)
        Me.BtnViewOrder.TabIndex = 8
        Me.BtnViewOrder.Text = "View"
        '
        'SLECompGroup
        '
        Me.SLECompGroup.Location = New System.Drawing.Point(86, 12)
        Me.SLECompGroup.Name = "SLECompGroup"
        Me.SLECompGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECompGroup.Properties.ShowClearButton = False
        Me.SLECompGroup.Properties.View = Me.GridView2
        Me.SLECompGroup.Size = New System.Drawing.Size(215, 20)
        Me.SLECompGroup.TabIndex = 7
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumn10})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Group Description"
        Me.GridColumn10.FieldName = "description"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Store Group"
        '
        'GridColumnwh_normal
        '
        Me.GridColumnwh_normal.Caption = "Normal Account"
        Me.GridColumnwh_normal.FieldName = "wh_normal"
        Me.GridColumnwh_normal.Name = "GridColumnwh_normal"
        Me.GridColumnwh_normal.Visible = True
        Me.GridColumnwh_normal.VisibleIndex = 3
        '
        'GridColumnwh_sale
        '
        Me.GridColumnwh_sale.Caption = "Sale Account"
        Me.GridColumnwh_sale.FieldName = "wh_sale"
        Me.GridColumnwh_sale.Name = "GridColumnwh_sale"
        Me.GridColumnwh_sale.Visible = True
        Me.GridColumnwh_sale.VisibleIndex = 4
        '
        'FormRefundOLStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 504)
        Me.Controls.Add(Me.XTCData)
        Me.Name = "FormRefundOLStore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Accept Refund"
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPAcceptedList.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPOrderList.ResumeLayout(False)
        CType(Me.GCOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLECompGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPAcceptedList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_ol_store_refund As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_order_ol_shop As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_ol_shop_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPOrderList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCOrderList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOrderList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_ol_shop_number_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncustomer_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLECompGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnwh_normal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnwh_sale As DevExpress.XtraGrid.Columns.GridColumn
End Class
