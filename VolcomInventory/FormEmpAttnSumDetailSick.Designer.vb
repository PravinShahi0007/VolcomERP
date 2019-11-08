<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpAttnSumDetailSick
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
        Me.TEEmployeeCode = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl = New DevExpress.XtraEditors.PanelControl()
        Me.BPrintSum = New DevExpress.XtraEditors.SimpleButton()
        Me.TEEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnMonth = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPurpose = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl.SuspendLayout()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TEEmployeeCode
        '
        Me.TEEmployeeCode.Location = New System.Drawing.Point(12, 12)
        Me.TEEmployeeCode.Name = "TEEmployeeCode"
        Me.TEEmployeeCode.Properties.ReadOnly = True
        Me.TEEmployeeCode.Size = New System.Drawing.Size(150, 20)
        Me.TEEmployeeCode.TabIndex = 0
        '
        'PanelControl
        '
        Me.PanelControl.Controls.Add(Me.BPrintSum)
        Me.PanelControl.Controls.Add(Me.TEEmployeeName)
        Me.PanelControl.Controls.Add(Me.TEEmployeeCode)
        Me.PanelControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl.Name = "PanelControl"
        Me.PanelControl.Size = New System.Drawing.Size(784, 48)
        Me.PanelControl.TabIndex = 1
        '
        'BPrintSum
        '
        Me.BPrintSum.Location = New System.Drawing.Point(424, 9)
        Me.BPrintSum.Name = "BPrintSum"
        Me.BPrintSum.Size = New System.Drawing.Size(59, 25)
        Me.BPrintSum.TabIndex = 13
        Me.BPrintSum.Text = "Print"
        '
        'TEEmployeeName
        '
        Me.TEEmployeeName.Location = New System.Drawing.Point(168, 12)
        Me.TEEmployeeName.Name = "TEEmployeeName"
        Me.TEEmployeeName.Properties.ReadOnly = True
        Me.TEEmployeeName.Size = New System.Drawing.Size(250, 20)
        Me.TEEmployeeName.TabIndex = 1
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 48)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(784, 513)
        Me.GCList.TabIndex = 2
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnMonth, Me.GridColumnDate, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumnTotal, Me.GridColumnPurpose})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.GroupCount = 1
        Me.GVList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "leave_total", Me.GridColumnTotal, "{0:N0}")})
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVList.OptionsBehavior.Editable = False
        Me.GVList.OptionsView.ShowFooter = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        Me.GVList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnMonth, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnMonth
        '
        Me.GridColumnMonth.Caption = "Month"
        Me.GridColumnMonth.FieldName = "leave_month"
        Me.GridColumnMonth.Name = "GridColumnMonth"
        Me.GridColumnMonth.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
        Me.GridColumnMonth.Visible = True
        Me.GridColumnMonth.VisibleIndex = 0
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date"
        Me.GridColumnDate.FieldName = "leave_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 0
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "leave_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 1
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "leave_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 2
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "leave_total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "leave_total", "{0:N1}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 3
        '
        'GridColumnPurpose
        '
        Me.GridColumnPurpose.Caption = "Purpose"
        Me.GridColumnPurpose.FieldName = "leave_purpose"
        Me.GridColumnPurpose.Name = "GridColumnPurpose"
        Me.GridColumnPurpose.Visible = True
        Me.GridColumnPurpose.VisibleIndex = 4
        '
        'FormEmpAttnSumDetailSick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControl)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpAttnSumDetailSick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Sick"
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl.ResumeLayout(False)
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TEEmployeeCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnMonth As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPurpose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BPrintSum As DevExpress.XtraEditors.SimpleButton
End Class
