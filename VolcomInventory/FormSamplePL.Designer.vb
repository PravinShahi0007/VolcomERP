<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSamplePL
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
        Me.GCPL = New DevExpress.XtraGrid.GridControl
        Me.GVPL = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdPLSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdContactFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdCompContactTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSamplePurc = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPoNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCPL
        '
        Me.GCPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPL.Location = New System.Drawing.Point(0, 0)
        Me.GCPL.MainView = Me.GVPL
        Me.GCPL.Name = "GCPL"
        Me.GCPL.Size = New System.Drawing.Size(673, 368)
        Me.GCPL.TabIndex = 0
        Me.GCPL.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPL})
        '
        'GVPL
        '
        Me.GVPL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdPLSample, Me.GridColumnIdContactFrom, Me.GridColumnIdCompContactTo, Me.GridColumnIdSamplePurc, Me.GridColumnIdReportStatus, Me.GridColumnPLNumber, Me.GridColumnPoNumber, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumnPLCategory, Me.GridColumnPLDate, Me.GridColumnPLNote, Me.GridColumnSeason, Me.GridColumnStatus})
        Me.GVPL.GridControl = Me.GCPL
        Me.GVPL.GroupCount = 1
        Me.GVPL.Name = "GVPL"
        Me.GVPL.OptionsBehavior.Editable = False
        Me.GVPL.OptionsFind.AlwaysVisible = True
        Me.GVPL.OptionsView.ShowGroupPanel = False
        Me.GVPL.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdPLSample
        '
        Me.GridColumnIdPLSample.Caption = "Id PL Sample"
        Me.GridColumnIdPLSample.FieldName = "id_pl_sample_purc"
        Me.GridColumnIdPLSample.Name = "GridColumnIdPLSample"
        Me.GridColumnIdPLSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdContactFrom
        '
        Me.GridColumnIdContactFrom.Caption = "GridColumnIdContacctFrom"
        Me.GridColumnIdContactFrom.FieldName = "id_comp_contact_from"
        Me.GridColumnIdContactFrom.Name = "GridColumnIdContactFrom"
        Me.GridColumnIdContactFrom.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdCompContactTo
        '
        Me.GridColumnIdCompContactTo.Caption = "GridColumnIdCompContactTo"
        Me.GridColumnIdCompContactTo.FieldName = "id_comp_contact_to"
        Me.GridColumnIdCompContactTo.Name = "GridColumnIdCompContactTo"
        Me.GridColumnIdCompContactTo.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSamplePurc
        '
        Me.GridColumnIdSamplePurc.Caption = "GridColumnIdSamplePurc"
        Me.GridColumnIdSamplePurc.FieldName = "id_sample_purc"
        Me.GridColumnIdSamplePurc.Name = "GridColumnIdSamplePurc"
        Me.GridColumnIdSamplePurc.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnPLNumber
        '
        Me.GridColumnPLNumber.Caption = "Number"
        Me.GridColumnPLNumber.FieldName = "pl_sample_purc_number"
        Me.GridColumnPLNumber.Name = "GridColumnPLNumber"
        Me.GridColumnPLNumber.Visible = True
        Me.GridColumnPLNumber.VisibleIndex = 0
        '
        'GridColumnPoNumber
        '
        Me.GridColumnPoNumber.Caption = "PO"
        Me.GridColumnPoNumber.FieldName = "sample_purc_number"
        Me.GridColumnPoNumber.Name = "GridColumnPoNumber"
        Me.GridColumnPoNumber.Visible = True
        Me.GridColumnPoNumber.VisibleIndex = 1
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
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 3
        '
        'GridColumnPLCategory
        '
        Me.GridColumnPLCategory.Caption = "Source"
        Me.GridColumnPLCategory.FieldName = "pl_category"
        Me.GridColumnPLCategory.Name = "GridColumnPLCategory"
        Me.GridColumnPLCategory.Visible = True
        Me.GridColumnPLCategory.VisibleIndex = 4
        '
        'GridColumnPLDate
        '
        Me.GridColumnPLDate.Caption = "Created Date"
        Me.GridColumnPLDate.FieldName = "pl_sample_purc_date"
        Me.GridColumnPLDate.Name = "GridColumnPLDate"
        Me.GridColumnPLDate.Visible = True
        Me.GridColumnPLDate.VisibleIndex = 5
        '
        'GridColumnPLNote
        '
        Me.GridColumnPLNote.Caption = "Note"
        Me.GridColumnPLNote.FieldName = "pl_sample_purc_note"
        Me.GridColumnPLNote.Name = "GridColumnPLNote"
        Me.GridColumnPLNote.Visible = True
        Me.GridColumnPLNote.VisibleIndex = 6
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 7
        '
        'GridColumnIdReportStatus
        '
        Me.GridColumnIdReportStatus.Caption = "Id Report Status"
        Me.GridColumnIdReportStatus.FieldName = "id_report_status"
        Me.GridColumnIdReportStatus.Name = "GridColumnIdReportStatus"
        '
        'FormSamplePL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 368)
        Me.Controls.Add(Me.GCPL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSamplePL"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Packing List Sample"
        CType(Me.GCPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCPL As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdPLSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdContactFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompContactTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSamplePurc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPoNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
