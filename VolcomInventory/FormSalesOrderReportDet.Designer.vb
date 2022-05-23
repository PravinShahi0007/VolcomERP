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
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DECreated = New DevExpress.XtraEditors.DateEdit()
        Me.TxtTo = New DevExpress.XtraEditors.TextEdit()
        Me.TxtFrom = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCNew = New DevExpress.XtraGrid.GridControl()
        Me.GVNew = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumntotal_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_scan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_completed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpros_scan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnpros_del = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBarScan = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumndesign_class = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_color = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_sht = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControlHead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlHead.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PanelControlHead.Controls.Add(Me.PanelControl2)
        Me.PanelControlHead.Controls.Add(Me.TxtTo)
        Me.PanelControlHead.Controls.Add(Me.TxtFrom)
        Me.PanelControlHead.Controls.Add(Me.LabelControl2)
        Me.PanelControlHead.Controls.Add(Me.LabelControl1)
        Me.PanelControlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlHead.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlHead.Name = "PanelControlHead"
        Me.PanelControlHead.Size = New System.Drawing.Size(794, 73)
        Me.PanelControlHead.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.TxtNumber)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.DECreated)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(528, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(264, 69)
        Me.PanelControl2.TabIndex = 8
        '
        'TxtNumber
        '
        Me.TxtNumber.Enabled = False
        Me.TxtNumber.Location = New System.Drawing.Point(87, 7)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(165, 20)
        Me.TxtNumber.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(16, 36)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Created Date"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(16, 10)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Number"
        '
        'DECreated
        '
        Me.DECreated.EditValue = Nothing
        Me.DECreated.Enabled = False
        Me.DECreated.Location = New System.Drawing.Point(87, 33)
        Me.DECreated.Name = "DECreated"
        Me.DECreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DECreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreated.Size = New System.Drawing.Size(165, 20)
        Me.DECreated.TabIndex = 6
        '
        'TxtTo
        '
        Me.TxtTo.Enabled = False
        Me.TxtTo.Location = New System.Drawing.Point(63, 35)
        Me.TxtTo.Name = "TxtTo"
        Me.TxtTo.Size = New System.Drawing.Size(258, 20)
        Me.TxtTo.TabIndex = 3
        '
        'TxtFrom
        '
        Me.TxtFrom.Enabled = False
        Me.TxtFrom.Location = New System.Drawing.Point(63, 9)
        Me.TxtFrom.Name = "TxtFrom"
        Me.TxtFrom.Size = New System.Drawing.Size(258, 20)
        Me.TxtFrom.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(23, 38)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "To"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(23, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "From"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 449)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(794, 47)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(618, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(87, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
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
        Me.GVNew.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumntotal_order, Me.GridColumntotal_scan, Me.GridColumntotal_completed, Me.GridColumnpros_scan, Me.GridColumnpros_del, Me.GridColumnBarcode, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnsize, Me.GridColumndesign_price, Me.GridColumndesign_price_type, Me.GridColumndesign_class, Me.GridColumndesign_color, Me.GridColumndesign_sht})
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
        Me.GridColumntotal_order.VisibleIndex = 9
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
        Me.GridColumntotal_scan.VisibleIndex = 10
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
        Me.GridColumntotal_completed.VisibleIndex = 11
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
        Me.GridColumnpros_scan.VisibleIndex = 12
        '
        'RepositoryItemProgressBar
        '
        Me.RepositoryItemProgressBar.DisplayFormat.FormatString = "{0:n2}%"
        Me.RepositoryItemProgressBar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemProgressBar.Name = "RepositoryItemProgressBar"
        Me.RepositoryItemProgressBar.PercentView = False
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
        Me.GridColumnpros_del.VisibleIndex = 13
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
        Me.GridColumnName.VisibleIndex = 3
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 6
        '
        'GridColumndesign_price
        '
        Me.GridColumndesign_price.Caption = "Price"
        Me.GridColumndesign_price.DisplayFormat.FormatString = "N0"
        Me.GridColumndesign_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndesign_price.FieldName = "design_price"
        Me.GridColumndesign_price.Name = "GridColumndesign_price"
        Me.GridColumndesign_price.Visible = True
        Me.GridColumndesign_price.VisibleIndex = 7
        '
        'GridColumndesign_price_type
        '
        Me.GridColumndesign_price_type.Caption = "Price Type"
        Me.GridColumndesign_price_type.FieldName = "design_price_type"
        Me.GridColumndesign_price_type.Name = "GridColumndesign_price_type"
        Me.GridColumndesign_price_type.Visible = True
        Me.GridColumndesign_price_type.VisibleIndex = 8
        '
        'RepositoryItemProgressBarScan
        '
        Me.RepositoryItemProgressBarScan.Name = "RepositoryItemProgressBarScan"
        Me.RepositoryItemProgressBarScan.ShowTitle = True
        '
        'GridColumndesign_class
        '
        Me.GridColumndesign_class.Caption = "Class"
        Me.GridColumndesign_class.FieldName = "design_class"
        Me.GridColumndesign_class.Name = "GridColumndesign_class"
        Me.GridColumndesign_class.Visible = True
        Me.GridColumndesign_class.VisibleIndex = 2
        '
        'GridColumndesign_color
        '
        Me.GridColumndesign_color.Caption = "Color"
        Me.GridColumndesign_color.FieldName = "design_color"
        Me.GridColumndesign_color.Name = "GridColumndesign_color"
        Me.GridColumndesign_color.Visible = True
        Me.GridColumndesign_color.VisibleIndex = 5
        '
        'GridColumndesign_sht
        '
        Me.GridColumndesign_sht.Caption = "Silhouette"
        Me.GridColumndesign_sht.FieldName = "design_sht"
        Me.GridColumndesign_sht.Name = "GridColumndesign_sht"
        Me.GridColumndesign_sht.Visible = True
        Me.GridColumndesign_sht.VisibleIndex = 4
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
        Me.PanelControlHead.ResumeLayout(False)
        Me.PanelControlHead.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TxtTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DECreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumndesign_class As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_color As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_sht As DevExpress.XtraGrid.Columns.GridColumn
End Class
