<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLOrderList
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOLOrderList))
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileAttachmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadShippingLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnsales_order_ol_shop_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncustomer_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_ol_shop_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprinted_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprinted_by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp_group2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_order_single = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.SLECompGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumntracking_code = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLECompGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 47)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(784, 514)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem, Me.FileAttachmentToolStripMenuItem, Me.DownloadShippingLabelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(210, 70)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'FileAttachmentToolStripMenuItem
        '
        Me.FileAttachmentToolStripMenuItem.Name = "FileAttachmentToolStripMenuItem"
        Me.FileAttachmentToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.FileAttachmentToolStripMenuItem.Text = "File Attachment"
        '
        'DownloadShippingLabelToolStripMenuItem
        '
        Me.DownloadShippingLabelToolStripMenuItem.Name = "DownloadShippingLabelToolStripMenuItem"
        Me.DownloadShippingLabelToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.DownloadShippingLabelToolStripMenuItem.Text = "Download Shipping Label"
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnsales_order_ol_shop_number, Me.GridColumncustomer_name, Me.GridColumnsales_order_ol_shop_date, Me.GridColumnid_sales_order, Me.GridColumnsales_order_number, Me.GridColumncomp_group_desc, Me.GridColumnprinted_date, Me.GridColumnprinted_by, Me.GridColumnid_comp_group2, Me.GridColumnid_sales_order_single, Me.GridColumntracking_code})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnsales_order_ol_shop_number
        '
        Me.GridColumnsales_order_ol_shop_number.Caption = "OL. Order No."
        Me.GridColumnsales_order_ol_shop_number.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.Name = "GridColumnsales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number.Visible = True
        Me.GridColumnsales_order_ol_shop_number.VisibleIndex = 1
        Me.GridColumnsales_order_ol_shop_number.Width = 111
        '
        'GridColumncustomer_name
        '
        Me.GridColumncustomer_name.Caption = "Customer"
        Me.GridColumncustomer_name.FieldName = "customer_name"
        Me.GridColumncustomer_name.Name = "GridColumncustomer_name"
        Me.GridColumncustomer_name.Visible = True
        Me.GridColumncustomer_name.VisibleIndex = 2
        '
        'GridColumnsales_order_ol_shop_date
        '
        Me.GridColumnsales_order_ol_shop_date.Caption = "OL. Order Date"
        Me.GridColumnsales_order_ol_shop_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnsales_order_ol_shop_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_order_ol_shop_date.FieldName = "sales_order_ol_shop_date"
        Me.GridColumnsales_order_ol_shop_date.Name = "GridColumnsales_order_ol_shop_date"
        Me.GridColumnsales_order_ol_shop_date.Visible = True
        Me.GridColumnsales_order_ol_shop_date.VisibleIndex = 3
        Me.GridColumnsales_order_ol_shop_date.Width = 117
        '
        'GridColumnid_sales_order
        '
        Me.GridColumnid_sales_order.Caption = "id_sales_order"
        Me.GridColumnid_sales_order.FieldName = "id_sales_order"
        Me.GridColumnid_sales_order.Name = "GridColumnid_sales_order"
        '
        'GridColumnsales_order_number
        '
        Me.GridColumnsales_order_number.Caption = "Sales Order No."
        Me.GridColumnsales_order_number.FieldName = "sales_order_number"
        Me.GridColumnsales_order_number.Name = "GridColumnsales_order_number"
        Me.GridColumnsales_order_number.Visible = True
        Me.GridColumnsales_order_number.VisibleIndex = 5
        Me.GridColumnsales_order_number.Width = 171
        '
        'GridColumncomp_group_desc
        '
        Me.GridColumncomp_group_desc.Caption = "Store"
        Me.GridColumncomp_group_desc.FieldName = "comp_group_desc"
        Me.GridColumncomp_group_desc.Name = "GridColumncomp_group_desc"
        Me.GridColumncomp_group_desc.Visible = True
        Me.GridColumncomp_group_desc.VisibleIndex = 0
        '
        'GridColumnprinted_date
        '
        Me.GridColumnprinted_date.Caption = "Last Printed"
        Me.GridColumnprinted_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnprinted_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnprinted_date.FieldName = "printed_date"
        Me.GridColumnprinted_date.Name = "GridColumnprinted_date"
        Me.GridColumnprinted_date.Visible = True
        Me.GridColumnprinted_date.VisibleIndex = 6
        '
        'GridColumnprinted_by
        '
        Me.GridColumnprinted_by.Caption = "Last Printed by"
        Me.GridColumnprinted_by.FieldName = "printed_by"
        Me.GridColumnprinted_by.Name = "GridColumnprinted_by"
        Me.GridColumnprinted_by.Visible = True
        Me.GridColumnprinted_by.VisibleIndex = 7
        '
        'GridColumnid_comp_group2
        '
        Me.GridColumnid_comp_group2.Caption = "id_comp_group"
        Me.GridColumnid_comp_group2.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group2.Name = "GridColumnid_comp_group2"
        '
        'GridColumnid_sales_order_single
        '
        Me.GridColumnid_sales_order_single.Caption = "id_sales_order_single"
        Me.GridColumnid_sales_order_single.FieldName = "id_sales_order_single"
        Me.GridColumnid_sales_order_single.Name = "GridColumnid_sales_order_single"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(10, 15)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl7.TabIndex = 9
        Me.LabelControl7.Text = "Store Group"
        '
        'SLECompGroup
        '
        Me.SLECompGroup.Location = New System.Drawing.Point(74, 12)
        Me.SLECompGroup.Name = "SLECompGroup"
        Me.SLECompGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECompGroup.Properties.ShowClearButton = False
        Me.SLECompGroup.Properties.View = Me.GridView2
        Me.SLECompGroup.Size = New System.Drawing.Size(196, 20)
        Me.SLECompGroup.TabIndex = 8
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
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 47)
        Me.PanelControl1.TabIndex = 10
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.SLECompGroup)
        Me.PanelControl2.Controls.Add(Me.LabelControl7)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(421, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(276, 43)
        Me.PanelControl2.TabIndex = 11
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(697, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(85, 43)
        Me.SimpleButton1.TabIndex = 11
        Me.SimpleButton1.Text = "View"
        '
        'GridColumntracking_code
        '
        Me.GridColumntracking_code.Caption = "Tracking Code"
        Me.GridColumntracking_code.FieldName = "tracking_code"
        Me.GridColumntracking_code.Name = "GridColumntracking_code"
        Me.GridColumntracking_code.Visible = True
        Me.GridColumntracking_code.VisibleIndex = 4
        Me.GridColumntracking_code.Width = 94
        '
        'FormOLOrderList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormOLOrderList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Online Order List"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLECompGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLECompGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents GridColumnsales_order_ol_shop_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncustomer_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_ol_shop_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnprinted_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnprinted_by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileAttachmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadShippingLabelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumnid_comp_group2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_order_single As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntracking_code As DevExpress.XtraGrid.Columns.GridColumn
End Class
