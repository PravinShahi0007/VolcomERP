<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleReceipt
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
        Me.GCReceipt = New DevExpress.XtraGrid.GridControl
        Me.GVReceipt = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdReceiptSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPLSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdContactFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdCompContactTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReceiptNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLSampleNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCReceipt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReceipt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCReceipt
        '
        Me.GCReceipt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCReceipt.Location = New System.Drawing.Point(0, 0)
        Me.GCReceipt.MainView = Me.GVReceipt
        Me.GCReceipt.Name = "GCReceipt"
        Me.GCReceipt.Size = New System.Drawing.Size(532, 376)
        Me.GCReceipt.TabIndex = 1
        Me.GCReceipt.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReceipt})
        '
        'GVReceipt
        '
        Me.GVReceipt.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdReceiptSample, Me.GridColumnIdPLSample, Me.GridColumnIdContactFrom, Me.GridColumnIdCompContactTo, Me.GridColumnReceiptNumber, Me.GridColumnPLSampleNumber, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumnPLDate, Me.GridColumnPLNote, Me.GridColumnStatus, Me.GridColumnSeason})
        Me.GVReceipt.GridControl = Me.GCReceipt
        Me.GVReceipt.GroupCount = 1
        Me.GVReceipt.Name = "GVReceipt"
        Me.GVReceipt.OptionsBehavior.Editable = False
        Me.GVReceipt.OptionsFind.AlwaysVisible = True
        Me.GVReceipt.OptionsView.ShowGroupPanel = False
        Me.GVReceipt.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdReceiptSample
        '
        Me.GridColumnIdReceiptSample.Caption = "Id Receipt Sample"
        Me.GridColumnIdReceiptSample.FieldName = "id_receipt_sample"
        Me.GridColumnIdReceiptSample.Name = "GridColumnIdReceiptSample"
        '
        'GridColumnIdPLSample
        '
        Me.GridColumnIdPLSample.Caption = "Id PL Sample"
        Me.GridColumnIdPLSample.FieldName = "id_pl_sample_purc"
        Me.GridColumnIdPLSample.Name = "GridColumnIdPLSample"
        '
        'GridColumnIdContactFrom
        '
        Me.GridColumnIdContactFrom.Caption = "GridColumnIdContacctFrom"
        Me.GridColumnIdContactFrom.FieldName = "id_comp_contact_from"
        Me.GridColumnIdContactFrom.Name = "GridColumnIdContactFrom"
        '
        'GridColumnIdCompContactTo
        '
        Me.GridColumnIdCompContactTo.Caption = "GridColumnIdCompContactTo"
        Me.GridColumnIdCompContactTo.FieldName = "id_comp_contact_to"
        Me.GridColumnIdCompContactTo.Name = "GridColumnIdCompContactTo"
        '
        'GridColumnReceiptNumber
        '
        Me.GridColumnReceiptNumber.Caption = "Receipt Number"
        Me.GridColumnReceiptNumber.FieldName = "receipt_sample_number"
        Me.GridColumnReceiptNumber.Name = "GridColumnReceiptNumber"
        Me.GridColumnReceiptNumber.Visible = True
        Me.GridColumnReceiptNumber.VisibleIndex = 0
        '
        'GridColumnPLSampleNumber
        '
        Me.GridColumnPLSampleNumber.Caption = "PL Number"
        Me.GridColumnPLSampleNumber.FieldName = "pl_sample_purc_number"
        Me.GridColumnPLSampleNumber.Name = "GridColumnPLSampleNumber"
        Me.GridColumnPLSampleNumber.Visible = True
        Me.GridColumnPLSampleNumber.VisibleIndex = 1
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "comp_name_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 2
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "comp_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        '
        'GridColumnPLDate
        '
        Me.GridColumnPLDate.Caption = "Created Date"
        Me.GridColumnPLDate.FieldName = "receipt_sample_date"
        Me.GridColumnPLDate.Name = "GridColumnPLDate"
        Me.GridColumnPLDate.Visible = True
        Me.GridColumnPLDate.VisibleIndex = 3
        '
        'GridColumnPLNote
        '
        Me.GridColumnPLNote.Caption = "Note"
        Me.GridColumnPLNote.FieldName = "receipt_sample_note"
        Me.GridColumnPLNote.Name = "GridColumnPLNote"
        Me.GridColumnPLNote.Visible = True
        Me.GridColumnPLNote.VisibleIndex = 4
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 5
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 6
        '
        'FormSampleReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 376)
        Me.Controls.Add(Me.GCReceipt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleReceipt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receipt Slip"
        CType(Me.GCReceipt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReceipt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCReceipt As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReceipt As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdPLSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdContactFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompContactTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReceiptNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReceiptSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLSampleNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
End Class
