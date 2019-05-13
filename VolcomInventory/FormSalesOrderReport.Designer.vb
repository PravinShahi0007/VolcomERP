<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesOrderReport
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
        Me.XTCSO = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPNew = New DevExpress.XtraTab.XtraTabPage()
        Me.GCNew = New DevExpress.XtraGrid.GridControl()
        Me.GVNew = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNewid_sales_order_gen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewid_so_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewsales_order_gen_reff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewsales_order_gen_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewsales_order_gen_note = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewtotal_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNew = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewtotal_completed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewProsScan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBarScan = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnNewpros_completed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPAllOrder = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XTCSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSO.SuspendLayout()
        Me.XTPNew.SuspendLayout()
        CType(Me.GCNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBarScan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCSO
        '
        Me.XTCSO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSO.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSO.Location = New System.Drawing.Point(0, 0)
        Me.XTCSO.Name = "XTCSO"
        Me.XTCSO.SelectedTabPage = Me.XTPNew
        Me.XTCSO.Size = New System.Drawing.Size(877, 489)
        Me.XTCSO.TabIndex = 0
        Me.XTCSO.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPNew, Me.XTPAllOrder})
        '
        'XTPNew
        '
        Me.XTPNew.Controls.Add(Me.GCNew)
        Me.XTPNew.Controls.Add(Me.GCFilter)
        Me.XTPNew.Name = "XTPNew"
        Me.XTPNew.Size = New System.Drawing.Size(871, 461)
        Me.XTPNew.Text = "New"
        '
        'GCNew
        '
        Me.GCNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCNew.Location = New System.Drawing.Point(0, 39)
        Me.GCNew.MainView = Me.GVNew
        Me.GCNew.Name = "GCNew"
        Me.GCNew.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBarScan})
        Me.GCNew.Size = New System.Drawing.Size(871, 422)
        Me.GCNew.TabIndex = 5
        Me.GCNew.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVNew})
        '
        'GVNew
        '
        Me.GVNew.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNewid_sales_order_gen, Me.GridColumnNewid_so_status, Me.GridColumnNewsales_order_gen_reff, Me.GridColumnNewsales_order_gen_date, Me.GridColumnNewsales_order_gen_note, Me.GridColumnNewtotal_order, Me.GridColumnNew, Me.GridColumnNewtotal_completed, Me.GridColumnNewProsScan, Me.GridColumnNewpros_completed})
        Me.GVNew.GridControl = Me.GCNew
        Me.GVNew.Name = "GVNew"
        Me.GVNew.OptionsBehavior.ReadOnly = True
        Me.GVNew.OptionsFind.AlwaysVisible = True
        Me.GVNew.OptionsView.ColumnAutoWidth = False
        Me.GVNew.OptionsView.ShowFooter = True
        Me.GVNew.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNewid_sales_order_gen
        '
        Me.GridColumnNewid_sales_order_gen.Caption = "Id Gen"
        Me.GridColumnNewid_sales_order_gen.FieldName = "id_sales_order_gen"
        Me.GridColumnNewid_sales_order_gen.Name = "GridColumnNewid_sales_order_gen"
        '
        'GridColumnNewid_so_status
        '
        Me.GridColumnNewid_so_status.Caption = "id_so_status"
        Me.GridColumnNewid_so_status.FieldName = "id_so_status"
        Me.GridColumnNewid_so_status.Name = "GridColumnNewid_so_status"
        '
        'GridColumnNewsales_order_gen_reff
        '
        Me.GridColumnNewsales_order_gen_reff.Caption = "Reff"
        Me.GridColumnNewsales_order_gen_reff.FieldName = "sales_order_gen_reff"
        Me.GridColumnNewsales_order_gen_reff.Name = "GridColumnNewsales_order_gen_reff"
        Me.GridColumnNewsales_order_gen_reff.Visible = True
        Me.GridColumnNewsales_order_gen_reff.VisibleIndex = 0
        '
        'GridColumnNewsales_order_gen_date
        '
        Me.GridColumnNewsales_order_gen_date.Caption = "Created Date"
        Me.GridColumnNewsales_order_gen_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnNewsales_order_gen_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnNewsales_order_gen_date.FieldName = "sales_order_gen_date"
        Me.GridColumnNewsales_order_gen_date.Name = "GridColumnNewsales_order_gen_date"
        Me.GridColumnNewsales_order_gen_date.Visible = True
        Me.GridColumnNewsales_order_gen_date.VisibleIndex = 1
        '
        'GridColumnNewsales_order_gen_note
        '
        Me.GridColumnNewsales_order_gen_note.Caption = "Note"
        Me.GridColumnNewsales_order_gen_note.FieldName = "sales_order_gen_note"
        Me.GridColumnNewsales_order_gen_note.Name = "GridColumnNewsales_order_gen_note"
        '
        'GridColumnNewtotal_order
        '
        Me.GridColumnNewtotal_order.Caption = "Order Total"
        Me.GridColumnNewtotal_order.DisplayFormat.FormatString = "N0"
        Me.GridColumnNewtotal_order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnNewtotal_order.FieldName = "total_order"
        Me.GridColumnNewtotal_order.Name = "GridColumnNewtotal_order"
        Me.GridColumnNewtotal_order.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", "{0:N0}")})
        Me.GridColumnNewtotal_order.Visible = True
        Me.GridColumnNewtotal_order.VisibleIndex = 2
        Me.GridColumnNewtotal_order.Width = 113
        '
        'GridColumnNew
        '
        Me.GridColumnNew.Caption = "Scan Total"
        Me.GridColumnNew.DisplayFormat.FormatString = "N0"
        Me.GridColumnNew.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnNew.FieldName = "total_scan"
        Me.GridColumnNew.Name = "GridColumnNew"
        Me.GridColumnNew.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_scan", "{0:N0}")})
        Me.GridColumnNew.Visible = True
        Me.GridColumnNew.VisibleIndex = 3
        Me.GridColumnNew.Width = 128
        '
        'GridColumnNewtotal_completed
        '
        Me.GridColumnNewtotal_completed.Caption = "Delivered Total"
        Me.GridColumnNewtotal_completed.DisplayFormat.FormatString = "N0"
        Me.GridColumnNewtotal_completed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnNewtotal_completed.FieldName = "total_completed"
        Me.GridColumnNewtotal_completed.Name = "GridColumnNewtotal_completed"
        Me.GridColumnNewtotal_completed.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_completed", "{0:N0}")})
        Me.GridColumnNewtotal_completed.Visible = True
        Me.GridColumnNewtotal_completed.VisibleIndex = 4
        Me.GridColumnNewtotal_completed.Width = 180
        '
        'GridColumnNewProsScan
        '
        Me.GridColumnNewProsScan.Caption = "Scan (%)"
        Me.GridColumnNewProsScan.ColumnEdit = Me.RepositoryItemProgressBarScan
        Me.GridColumnNewProsScan.FieldName = "pros_scan"
        Me.GridColumnNewProsScan.Name = "GridColumnNewProsScan"
        Me.GridColumnNewProsScan.UnboundExpression = "([total_scan] / [total_order]) * 100"
        Me.GridColumnNewProsScan.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnNewProsScan.Visible = True
        Me.GridColumnNewProsScan.VisibleIndex = 5
        '
        'RepositoryItemProgressBarScan
        '
        Me.RepositoryItemProgressBarScan.Name = "RepositoryItemProgressBarScan"
        Me.RepositoryItemProgressBarScan.ShowTitle = True
        '
        'GridColumnNewpros_completed
        '
        Me.GridColumnNewpros_completed.Caption = "Delivered (%)"
        Me.GridColumnNewpros_completed.ColumnEdit = Me.RepositoryItemProgressBarScan
        Me.GridColumnNewpros_completed.FieldName = "pros_completed"
        Me.GridColumnNewpros_completed.Name = "GridColumnNewpros_completed"
        Me.GridColumnNewpros_completed.UnboundExpression = "([total_completed] / [total_order]) * 100"
        Me.GridColumnNewpros_completed.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnNewpros_completed.Visible = True
        Me.GridColumnNewpros_completed.VisibleIndex = 6
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.DEUntil)
        Me.GCFilter.Controls.Add(Me.DEFrom)
        Me.GCFilter.Controls.Add(Me.LabelControl2)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(871, 39)
        Me.GCFilter.TabIndex = 4
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
        'XTPAllOrder
        '
        Me.XTPAllOrder.Name = "XTPAllOrder"
        Me.XTPAllOrder.Size = New System.Drawing.Size(871, 461)
        Me.XTPAllOrder.Text = "All Order"
        '
        'FormSalesOrderReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 489)
        Me.Controls.Add(Me.XTCSO)
        Me.Name = "FormSalesOrderReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prepare Order Monitoring"
        CType(Me.XTCSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSO.ResumeLayout(False)
        Me.XTPNew.ResumeLayout(False)
        CType(Me.GCNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBarScan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCSO As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPNew As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPAllOrder As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCNew As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVNew As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnNewid_sales_order_gen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewid_so_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewsales_order_gen_reff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewsales_order_gen_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewsales_order_gen_note As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewtotal_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNew As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewtotal_completed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewProsScan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBarScan As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnNewpros_completed As DevExpress.XtraGrid.Columns.GridColumn
End Class
