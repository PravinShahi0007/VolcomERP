<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingListPR
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
        Me.GCPaymentList = New DevExpress.XtraGrid.GridControl
        Me.GVPaymentList = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CEChecked = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GridColumnIdReport = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReportNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReportDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDueDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdReportMarkType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRemainingDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdCurr = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCurr = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnKurs = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnVAT_percent = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnVAT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCPaymentList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPaymentList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEChecked, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCPaymentList
        '
        Me.GCPaymentList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPaymentList.Location = New System.Drawing.Point(0, 0)
        Me.GCPaymentList.MainView = Me.GVPaymentList
        Me.GCPaymentList.Name = "GCPaymentList"
        Me.GCPaymentList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CEChecked})
        Me.GCPaymentList.Size = New System.Drawing.Size(820, 362)
        Me.GCPaymentList.TabIndex = 0
        Me.GCPaymentList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPaymentList})
        '
        'GVPaymentList
        '
        Me.GVPaymentList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumnIdReport, Me.GridColumn2, Me.GridColumnReportNumber, Me.GridColumnReportDate, Me.GridColumnDueDate, Me.GridColumnIdReportMarkType, Me.GridColumn1, Me.GridColumn3, Me.GridColumn5, Me.GridColumn6, Me.GridColumnRemainingDate, Me.GridColumnIdCurr, Me.GridColumnCurr, Me.GridColumnTotal, Me.GridColumnKurs, Me.GridColumnAmount, Me.GridColumnVAT_percent, Me.GridColumnVAT, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GVPaymentList.GridControl = Me.GCPaymentList
        Me.GVPaymentList.GroupCount = 1
        Me.GVPaymentList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "id_report", Nothing, "(Count = {0})")})
        Me.GVPaymentList.Name = "GVPaymentList"
        Me.GVPaymentList.OptionsView.ColumnAutoWidth = False
        Me.GVPaymentList.OptionsView.ShowFooter = True
        Me.GVPaymentList.OptionsView.ShowGroupPanel = False
        Me.GVPaymentList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "*"
        Me.GridColumn4.ColumnEdit = Me.CEChecked
        Me.GridColumn4.FieldName = "is_check"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 41
        '
        'CEChecked
        '
        Me.CEChecked.AutoHeight = False
        Me.CEChecked.Name = "CEChecked"
        Me.CEChecked.ValueChecked = "yes"
        Me.CEChecked.ValueUnchecked = "no"
        '
        'GridColumnIdReport
        '
        Me.GridColumnIdReport.Caption = "Id Report"
        Me.GridColumnIdReport.FieldName = "id_report"
        Me.GridColumnIdReport.Name = "GridColumnIdReport"
        Me.GridColumnIdReport.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Payment Request"
        Me.GridColumn2.FieldName = "report_mark_type_name"
        Me.GridColumn2.FieldNameSortGroup = "report_mark_type"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        '
        'GridColumnReportNumber
        '
        Me.GridColumnReportNumber.Caption = "Number"
        Me.GridColumnReportNumber.FieldName = "report_number"
        Me.GridColumnReportNumber.Name = "GridColumnReportNumber"
        Me.GridColumnReportNumber.OptionsColumn.ReadOnly = True
        Me.GridColumnReportNumber.Visible = True
        Me.GridColumnReportNumber.VisibleIndex = 1
        '
        'GridColumnReportDate
        '
        Me.GridColumnReportDate.Caption = "Date"
        Me.GridColumnReportDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnReportDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnReportDate.FieldName = "report_date"
        Me.GridColumnReportDate.Name = "GridColumnReportDate"
        Me.GridColumnReportDate.OptionsColumn.ReadOnly = True
        Me.GridColumnReportDate.Visible = True
        Me.GridColumnReportDate.VisibleIndex = 6
        '
        'GridColumnDueDate
        '
        Me.GridColumnDueDate.Caption = "Due Date"
        Me.GridColumnDueDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDueDate.FieldName = "report_due_date"
        Me.GridColumnDueDate.Name = "GridColumnDueDate"
        Me.GridColumnDueDate.OptionsColumn.ReadOnly = True
        Me.GridColumnDueDate.Visible = True
        Me.GridColumnDueDate.VisibleIndex = 8
        '
        'GridColumnIdReportMarkType
        '
        Me.GridColumnIdReportMarkType.Caption = "Id Report Mark Type"
        Me.GridColumnIdReportMarkType.FieldName = "report_mark_type"
        Me.GridColumnIdReportMarkType.Name = "GridColumnIdReportMarkType"
        Me.GridColumnIdReportMarkType.OptionsColumn.ReadOnly = True
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Order Number"
        Me.GridColumn1.FieldName = "order_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Receive Number"
        Me.GridColumn3.FieldName = "rec_number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Payment Type"
        Me.GridColumn5.FieldName = "payment"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 7
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id Report Status"
        Me.GridColumn6.FieldName = "id_report_status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        '
        'GridColumnRemainingDate
        '
        Me.GridColumnRemainingDate.Caption = "Remaining Time (Day)"
        Me.GridColumnRemainingDate.FieldName = "diff_date"
        Me.GridColumnRemainingDate.Name = "GridColumnRemainingDate"
        Me.GridColumnRemainingDate.OptionsColumn.ReadOnly = True
        Me.GridColumnRemainingDate.Visible = True
        Me.GridColumnRemainingDate.VisibleIndex = 9
        Me.GridColumnRemainingDate.Width = 122
        '
        'GridColumnIdCurr
        '
        Me.GridColumnIdCurr.Caption = "Id Currency"
        Me.GridColumnIdCurr.FieldName = "id_currency"
        Me.GridColumnIdCurr.Name = "GridColumnIdCurr"
        Me.GridColumnIdCurr.OptionsColumn.ReadOnly = True
        '
        'GridColumnCurr
        '
        Me.GridColumnCurr.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCurr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCurr.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCurr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCurr.Caption = "Currency"
        Me.GridColumnCurr.FieldName = "currency"
        Me.GridColumnCurr.Name = "GridColumnCurr"
        Me.GridColumnCurr.OptionsColumn.ReadOnly = True
        Me.GridColumnCurr.Visible = True
        Me.GridColumnCurr.VisibleIndex = 10
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.OptionsColumn.ReadOnly = True
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 11
        '
        'GridColumnKurs
        '
        Me.GridColumnKurs.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnKurs.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKurs.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnKurs.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKurs.Caption = "Kurs"
        Me.GridColumnKurs.DisplayFormat.FormatString = "N2"
        Me.GridColumnKurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnKurs.FieldName = "kurs"
        Me.GridColumnKurs.Name = "GridColumnKurs"
        Me.GridColumnKurs.OptionsColumn.ReadOnly = True
        Me.GridColumnKurs.Visible = True
        Me.GridColumnKurs.VisibleIndex = 13
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.ReadOnly = True
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        '
        'GridColumnVAT_percent
        '
        Me.GridColumnVAT_percent.Caption = "VAT (%)"
        Me.GridColumnVAT_percent.FieldName = "vat"
        Me.GridColumnVAT_percent.Name = "GridColumnVAT_percent"
        Me.GridColumnVAT_percent.OptionsColumn.ReadOnly = True
        '
        'GridColumnVAT
        '
        Me.GridColumnVAT.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnVAT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnVAT.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnVAT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnVAT.Caption = "VAT"
        Me.GridColumnVAT.DisplayFormat.FormatString = "N2"
        Me.GridColumnVAT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnVAT.FieldName = "vat_amount"
        Me.GridColumnVAT.Name = "GridColumnVAT"
        Me.GridColumnVAT.OptionsColumn.ReadOnly = True
        Me.GridColumnVAT.Visible = True
        Me.GridColumnVAT.VisibleIndex = 12
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Source Description"
        Me.GridColumn7.FieldName = "comp_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Source"
        Me.GridColumn8.FieldName = "comp_number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 4
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Id Comp"
        Me.GridColumn9.FieldName = "id_comp"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id Report"
        Me.GridColumn10.FieldName = "id_report"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'FormAccountingListPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 362)
        Me.Controls.Add(Me.GCPaymentList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingListPR"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List Payment Request"
        CType(Me.GCPaymentList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPaymentList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEChecked, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCPaymentList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPaymentList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdReport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReportMarkType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemainingDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CEChecked As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdCurr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnKurs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVAT_percent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVAT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
End Class
