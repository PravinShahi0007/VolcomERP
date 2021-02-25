<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTempTable
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
        Me.GCTemp = New DevExpress.XtraGrid.GridControl()
        Me.GVTemp = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColRetOutNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPSONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCTemp
        '
        Me.GCTemp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTemp.Location = New System.Drawing.Point(0, 0)
        Me.GCTemp.MainView = Me.GVTemp
        Me.GCTemp.Name = "GCTemp"
        Me.GCTemp.Size = New System.Drawing.Size(904, 447)
        Me.GCTemp.TabIndex = 0
        Me.GCTemp.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTemp})
        '
        'GVTemp
        '
        Me.GVTemp.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColRetOutNumber, Me.ColShipTo, Me.ColRecDate, Me.ColDueDate, Me.ColPSONumber, Me.GridColumn7, Me.GridColumn9, Me.GridColumn10, Me.GridColumn14, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVTemp.GridControl = Me.GCTemp
        Me.GVTemp.GroupCount = 1
        Me.GVTemp.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumn10, "{0:n0}")})
        Me.GVTemp.Name = "GVTemp"
        Me.GVTemp.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVTemp.OptionsBehavior.Editable = False
        Me.GVTemp.OptionsView.ShowFooter = True
        Me.GVTemp.OptionsView.ShowGroupPanel = False
        Me.GVTemp.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColRetOutNumber
        '
        Me.ColRetOutNumber.Caption = "Number"
        Me.ColRetOutNumber.FieldName = "prod_order_ret_out_number"
        Me.ColRetOutNumber.Name = "ColRetOutNumber"
        Me.ColRetOutNumber.Visible = True
        Me.ColRetOutNumber.VisibleIndex = 0
        Me.ColRetOutNumber.Width = 78
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "To"
        Me.ColShipTo.FieldName = "comp_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 4
        Me.ColShipTo.Width = 139
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Create Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "prod_order_ret_out_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Width = 136
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Est. Return In Date"
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "prod_order_ret_out_due_date"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 8
        Me.ColDueDate.Width = 148
        '
        'ColPSONumber
        '
        Me.ColPSONumber.Caption = "FGPO No."
        Me.ColPSONumber.FieldName = "prod_order_number"
        Me.ColPSONumber.Name = "ColPSONumber"
        Me.ColPSONumber.Visible = True
        Me.ColPSONumber.VisibleIndex = 1
        Me.ColPSONumber.Width = 80
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Code"
        Me.GridColumn7.FieldName = "code"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        Me.GridColumn7.Width = 80
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Name"
        Me.GridColumn9.FieldName = "name"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        Me.GridColumn9.Width = 139
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Qty"
        Me.GridColumn10.DisplayFormat.FormatString = "N0"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "qty"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 5
        Me.GridColumn10.Width = 50
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Qty Return In"
        Me.GridColumn14.DisplayFormat.FormatString = "N0"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "qty_retin"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 6
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Different (pcs)"
        Me.GridColumn1.FieldName = "diff_qty"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 7
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Overdue (days)"
        Me.GridColumn2.FieldName = "overdue"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 9
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Status"
        Me.GridColumn3.FieldName = "sts"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.UnboundExpression = "Iif([overdue] > 0, 'Overdue', 'Due Soon')"
        Me.GridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'FormTempTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 447)
        Me.Controls.Add(Me.GCTemp)
        Me.Name = "FormTempTable"
        Me.Text = "FormTempTable"
        CType(Me.GCTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCTemp As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTemp As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColRetOutNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPSONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
