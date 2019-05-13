<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesOrderReportDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesOrderReportDet))
        Me.PanelControlHead = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCNew = New DevExpress.XtraGrid.GridControl()
        Me.GVNew = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumntotal_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_scan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_completed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpros_scan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnpros_del = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBarScan = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControlHead, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBarScan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlHead
        '
        Me.PanelControlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlHead.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlHead.Name = "PanelControlHead"
        Me.PanelControlHead.Size = New System.Drawing.Size(794, 73)
        Me.PanelControlHead.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 449)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(794, 47)
        Me.PanelControl1.TabIndex = 1
        '
        'GCNew
        '
        Me.GCNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCNew.Location = New System.Drawing.Point(0, 73)
        Me.GCNew.MainView = Me.GVNew
        Me.GCNew.Name = "GCNew"
        Me.GCNew.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBarScan, Me.RepositoryItemProgressBar})
        Me.GCNew.Size = New System.Drawing.Size(794, 376)
        Me.GCNew.TabIndex = 7
        Me.GCNew.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVNew})
        '
        'GVNew
        '
        Me.GVNew.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumntotal_order, Me.GridColumntotal_scan, Me.GridColumntotal_completed, Me.GridColumnpros_scan, Me.GridColumnpros_del, Me.GridColumnBarcode, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnsize, Me.GridColumndesign_price, Me.GridColumndesign_price_type})
        Me.GVNew.GridControl = Me.GCNew
        Me.GVNew.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", Me.GridColumntotal_order, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_scan", Me.GridColumntotal_scan, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_completed", Me.GridColumntotal_completed, "{0:N0}")})
        Me.GVNew.Name = "GVNew"
        Me.GVNew.OptionsBehavior.ReadOnly = True
        Me.GVNew.OptionsFind.AlwaysVisible = True
        Me.GVNew.OptionsView.ColumnAutoWidth = False
        Me.GVNew.OptionsView.ShowFooter = True
        Me.GVNew.OptionsView.ShowGroupPanel = False
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
        Me.GridColumntotal_order.VisibleIndex = 6
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
        Me.GridColumntotal_scan.VisibleIndex = 7
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
        Me.GridColumntotal_completed.VisibleIndex = 8
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
        Me.GridColumnpros_scan.VisibleIndex = 9
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
        Me.GridColumnpros_del.VisibleIndex = 10
        '
        'RepositoryItemProgressBarScan
        '
        Me.RepositoryItemProgressBarScan.Name = "RepositoryItemProgressBarScan"
        Me.RepositoryItemProgressBarScan.ShowTitle = True
        '
        'GridColumnBarcode
        '
        Me.GridColumnBarcode.Caption = "Barcode"
        Me.GridColumnBarcode.FieldName = "barcode"
        Me.GridColumnBarcode.Name = "GridColumnBarcode"
        Me.GridColumnBarcode.Visible = True
        Me.GridColumnBarcode.VisibleIndex = 0
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 3
        '
        'GridColumndesign_price
        '
        Me.GridColumndesign_price.Caption = "Price"
        Me.GridColumndesign_price.DisplayFormat.FormatString = "N0"
        Me.GridColumndesign_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndesign_price.FieldName = "design_price"
        Me.GridColumndesign_price.Name = "GridColumndesign_price"
        Me.GridColumndesign_price.Visible = True
        Me.GridColumndesign_price.VisibleIndex = 4
        '
        'GridColumndesign_price_type
        '
        Me.GridColumndesign_price_type.Caption = "Price Type"
        Me.GridColumndesign_price_type.FieldName = "design_price_type"
        Me.GridColumndesign_price_type.Name = "GridColumndesign_price_type"
        Me.GridColumndesign_price_type.Visible = True
        Me.GridColumndesign_price_type.VisibleIndex = 5
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(705, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 43)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'FormSalesOrderReportDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 496)
        Me.Controls.Add(Me.GCNew)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControlHead)
        Me.MinimizeBox = False
        Me.Name = "FormSalesOrderReportDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControlHead, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBarScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControlHead As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCNew As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVNew As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumntotal_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_scan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_completed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpros_scan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnpros_del As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBarScan As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_price_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
End Class
