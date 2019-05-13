<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesOrderReportDetNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesOrderReportDetNew))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCNew = New DevExpress.XtraGrid.GridControl()
        Me.GVNew = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprepare_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnwh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndestination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_scan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_completed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpros_scan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnpros_del = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnso_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBarScan = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnfinal_comment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfinal_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfinal_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBarScan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 564)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(834, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(666, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(79, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(745, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 43)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'GCNew
        '
        Me.GCNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCNew.Location = New System.Drawing.Point(0, 0)
        Me.GCNew.MainView = Me.GVNew
        Me.GCNew.Name = "GCNew"
        Me.GCNew.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBarScan, Me.RepositoryItemProgressBar})
        Me.GCNew.Size = New System.Drawing.Size(834, 564)
        Me.GCNew.TabIndex = 6
        Me.GCNew.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVNew})
        '
        'GVNew
        '
        Me.GVNew.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_order, Me.GridColumnsales_order_number, Me.GridColumnsales_order_date, Me.GridColumnprepare_status, Me.GridColumnwh, Me.GridColumndestination, Me.GridColumntotal_order, Me.GridColumntotal_scan, Me.GridColumntotal_completed, Me.GridColumnpros_scan, Me.GridColumnpros_del, Me.GridColumnso_status, Me.GridColumnfinal_comment, Me.GridColumnfinal_date, Me.GridColumnfinal_by_name})
        Me.GVNew.GridControl = Me.GCNew
        Me.GVNew.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", Me.GridColumntotal_order, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_scan", Me.GridColumntotal_scan, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_completed", Me.GridColumntotal_completed, "{0:N0}")})
        Me.GVNew.Name = "GVNew"
        Me.GVNew.OptionsBehavior.ReadOnly = True
        Me.GVNew.OptionsFind.AlwaysVisible = True
        Me.GVNew.OptionsView.ColumnAutoWidth = False
        Me.GVNew.OptionsView.ShowFooter = True
        Me.GVNew.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_order
        '
        Me.GridColumnid_sales_order.Caption = "Id SO"
        Me.GridColumnid_sales_order.FieldName = "id_sales_order"
        Me.GridColumnid_sales_order.Name = "GridColumnid_sales_order"
        '
        'GridColumnsales_order_number
        '
        Me.GridColumnsales_order_number.Caption = "Order Number"
        Me.GridColumnsales_order_number.FieldName = "sales_order_number"
        Me.GridColumnsales_order_number.Name = "GridColumnsales_order_number"
        Me.GridColumnsales_order_number.Visible = True
        Me.GridColumnsales_order_number.VisibleIndex = 0
        '
        'GridColumnsales_order_date
        '
        Me.GridColumnsales_order_date.Caption = "Order Date"
        Me.GridColumnsales_order_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_order_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_order_date.FieldName = "sales_order_date"
        Me.GridColumnsales_order_date.Name = "GridColumnsales_order_date"
        Me.GridColumnsales_order_date.Visible = True
        Me.GridColumnsales_order_date.VisibleIndex = 1
        '
        'GridColumnprepare_status
        '
        Me.GridColumnprepare_status.Caption = "Status"
        Me.GridColumnprepare_status.FieldName = "prepare_status"
        Me.GridColumnprepare_status.Name = "GridColumnprepare_status"
        Me.GridColumnprepare_status.Visible = True
        Me.GridColumnprepare_status.VisibleIndex = 10
        '
        'GridColumnwh
        '
        Me.GridColumnwh.Caption = "From"
        Me.GridColumnwh.FieldName = "wh"
        Me.GridColumnwh.Name = "GridColumnwh"
        Me.GridColumnwh.Visible = True
        Me.GridColumnwh.VisibleIndex = 3
        '
        'GridColumndestination
        '
        Me.GridColumndestination.Caption = "To"
        Me.GridColumndestination.FieldName = "destination"
        Me.GridColumndestination.Name = "GridColumndestination"
        Me.GridColumndestination.Visible = True
        Me.GridColumndestination.VisibleIndex = 4
        '
        'GridColumntotal_order
        '
        Me.GridColumntotal_order.Caption = "Order Total"
        Me.GridColumntotal_order.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_order.FieldName = "total_order"
        Me.GridColumntotal_order.Name = "GridColumntotal_order"
        Me.GridColumntotal_order.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", "{0:N0}")})
        Me.GridColumntotal_order.Visible = True
        Me.GridColumntotal_order.VisibleIndex = 5
        '
        'GridColumntotal_scan
        '
        Me.GridColumntotal_scan.Caption = "Scan Total"
        Me.GridColumntotal_scan.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_scan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_scan.FieldName = "total_scan"
        Me.GridColumntotal_scan.Name = "GridColumntotal_scan"
        Me.GridColumntotal_scan.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_scan", "{0:N0}")})
        Me.GridColumntotal_scan.Visible = True
        Me.GridColumntotal_scan.VisibleIndex = 6
        '
        'GridColumntotal_completed
        '
        Me.GridColumntotal_completed.Caption = "Delivered Total"
        Me.GridColumntotal_completed.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_completed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_completed.FieldName = "total_completed"
        Me.GridColumntotal_completed.Name = "GridColumntotal_completed"
        Me.GridColumntotal_completed.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_completed", "{0:N0}")})
        Me.GridColumntotal_completed.Visible = True
        Me.GridColumntotal_completed.VisibleIndex = 7
        Me.GridColumntotal_completed.Width = 141
        '
        'GridColumnpros_scan
        '
        Me.GridColumnpros_scan.Caption = "Scan (%)"
        Me.GridColumnpros_scan.ColumnEdit = Me.RepositoryItemProgressBar
        Me.GridColumnpros_scan.FieldName = "pros_scan"
        Me.GridColumnpros_scan.Name = "GridColumnpros_scan"
        Me.GridColumnpros_scan.UnboundExpression = "([total_scan]/[total_order])*100"
        Me.GridColumnpros_scan.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnpros_scan.Visible = True
        Me.GridColumnpros_scan.VisibleIndex = 8
        '
        'RepositoryItemProgressBar
        '
        Me.RepositoryItemProgressBar.Name = "RepositoryItemProgressBar"
        Me.RepositoryItemProgressBar.ShowTitle = True
        '
        'GridColumnpros_del
        '
        Me.GridColumnpros_del.Caption = "Delivered (%)"
        Me.GridColumnpros_del.ColumnEdit = Me.RepositoryItemProgressBar
        Me.GridColumnpros_del.FieldName = "pros_del"
        Me.GridColumnpros_del.Name = "GridColumnpros_del"
        Me.GridColumnpros_del.UnboundExpression = "([total_completed]/[total_order])*100"
        Me.GridColumnpros_del.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnpros_del.Visible = True
        Me.GridColumnpros_del.VisibleIndex = 9
        '
        'GridColumnso_status
        '
        Me.GridColumnso_status.Caption = "Category"
        Me.GridColumnso_status.FieldName = "so_status"
        Me.GridColumnso_status.Name = "GridColumnso_status"
        Me.GridColumnso_status.Visible = True
        Me.GridColumnso_status.VisibleIndex = 2
        '
        'RepositoryItemProgressBarScan
        '
        Me.RepositoryItemProgressBarScan.Name = "RepositoryItemProgressBarScan"
        Me.RepositoryItemProgressBarScan.ShowTitle = True
        '
        'GridColumnfinal_comment
        '
        Me.GridColumnfinal_comment.Caption = "Closed Note"
        Me.GridColumnfinal_comment.FieldName = "final_comment"
        Me.GridColumnfinal_comment.Name = "GridColumnfinal_comment"
        Me.GridColumnfinal_comment.Visible = True
        Me.GridColumnfinal_comment.VisibleIndex = 11
        '
        'GridColumnfinal_date
        '
        Me.GridColumnfinal_date.Caption = "Closed Date"
        Me.GridColumnfinal_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnfinal_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnfinal_date.FieldName = "final_date"
        Me.GridColumnfinal_date.Name = "GridColumnfinal_date"
        Me.GridColumnfinal_date.Visible = True
        Me.GridColumnfinal_date.VisibleIndex = 12
        '
        'GridColumnfinal_by_name
        '
        Me.GridColumnfinal_by_name.Caption = "Closed By"
        Me.GridColumnfinal_by_name.FieldName = "final_by_name"
        Me.GridColumnfinal_by_name.Name = "GridColumnfinal_by_name"
        Me.GridColumnfinal_by_name.Visible = True
        Me.GridColumnfinal_by_name.VisibleIndex = 13
        '
        'FormSalesOrderReportDetNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 611)
        Me.Controls.Add(Me.GCNew)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormSalesOrderReportDetNew"
        Me.Text = "- Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBarScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCNew As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVNew As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemProgressBarScan As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnid_sales_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnprepare_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnwh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndestination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_scan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_completed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpros_scan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnpros_del As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnso_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfinal_comment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfinal_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfinal_by_name As DevExpress.XtraGrid.Columns.GridColumn
End Class
