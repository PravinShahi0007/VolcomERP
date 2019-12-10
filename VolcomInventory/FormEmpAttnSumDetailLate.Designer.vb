<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpAttnSumDetailLate
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
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnMonth = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStartWork = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEndWork = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl = New DevExpress.XtraEditors.PanelControl()
        Me.BPrintSum = New DevExpress.XtraEditors.SimpleButton()
        Me.TEEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.TEEmployeeCode = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl.SuspendLayout()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 48)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(784, 513)
        Me.GCList.TabIndex = 4
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnMonth, Me.GridColumnDate, Me.GridColumnStartWork, Me.GridColumnLate, Me.GridColumnEndWork})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.GroupCount = 1
        Me.GVList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "late", Me.GridColumnLate, "{0:N0}")})
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
        Me.GridColumnMonth.FieldName = "late_month"
        Me.GridColumnMonth.Name = "GridColumnMonth"
        Me.GridColumnMonth.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
        Me.GridColumnMonth.Visible = True
        Me.GridColumnMonth.VisibleIndex = 0
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date"
        Me.GridColumnDate.FieldName = "late_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 0
        '
        'GridColumnStartWork
        '
        Me.GridColumnStartWork.Caption = "Start Work"
        Me.GridColumnStartWork.FieldName = "att_in"
        Me.GridColumnStartWork.Name = "GridColumnStartWork"
        Me.GridColumnStartWork.Visible = True
        Me.GridColumnStartWork.VisibleIndex = 1
        '
        'GridColumnLate
        '
        Me.GridColumnLate.Caption = "Late"
        Me.GridColumnLate.DisplayFormat.FormatString = "N0"
        Me.GridColumnLate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnLate.FieldName = "late"
        Me.GridColumnLate.Name = "GridColumnLate"
        Me.GridColumnLate.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "late", "{0:N0}")})
        Me.GridColumnLate.Visible = True
        Me.GridColumnLate.VisibleIndex = 2
        '
        'GridColumnEndWork
        '
        Me.GridColumnEndWork.Caption = "End Work"
        Me.GridColumnEndWork.FieldName = "att_out"
        Me.GridColumnEndWork.Name = "GridColumnEndWork"
        Me.GridColumnEndWork.Visible = True
        Me.GridColumnEndWork.VisibleIndex = 3
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
        Me.PanelControl.TabIndex = 3
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
        'TEEmployeeCode
        '
        Me.TEEmployeeCode.Location = New System.Drawing.Point(12, 12)
        Me.TEEmployeeCode.Name = "TEEmployeeCode"
        Me.TEEmployeeCode.Properties.ReadOnly = True
        Me.TEEmployeeCode.Size = New System.Drawing.Size(150, 20)
        Me.TEEmployeeCode.TabIndex = 0
        '
        'FormEmpAttnSumDetailLate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControl)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpAttnSumDetailLate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Late"
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl.ResumeLayout(False)
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnMonth As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStartWork As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEndWork As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPrintSum As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEEmployeeCode As DevExpress.XtraEditors.TextEdit
End Class
