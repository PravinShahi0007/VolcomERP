<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGWHAlloc
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
        Me.GCFGWHAlloc = New DevExpress.XtraGrid.GridControl()
        Me.GVFGWHAlloc = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPreparedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsSubmit = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCFGWHAlloc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGWHAlloc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFGWHAlloc
        '
        Me.GCFGWHAlloc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGWHAlloc.Location = New System.Drawing.Point(0, 0)
        Me.GCFGWHAlloc.MainView = Me.GVFGWHAlloc
        Me.GCFGWHAlloc.Name = "GCFGWHAlloc"
        Me.GCFGWHAlloc.Size = New System.Drawing.Size(700, 366)
        Me.GCFGWHAlloc.TabIndex = 0
        Me.GCFGWHAlloc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGWHAlloc})
        '
        'GVFGWHAlloc
        '
        Me.GVFGWHAlloc.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnIdStatus, Me.GridColumnCreatedDate, Me.GridColumnNumber, Me.GridColumnNote, Me.GridColumnStatus, Me.GridColumnPreparedBy, Me.GridColumnFrom, Me.GridColumnSeason, Me.GridColumnIsSubmit})
        Me.GVFGWHAlloc.GridControl = Me.GCFGWHAlloc
        Me.GVFGWHAlloc.Name = "GVFGWHAlloc"
        Me.GVFGWHAlloc.OptionsBehavior.Editable = False
        Me.GVFGWHAlloc.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID"
        Me.GridColumnID.FieldName = "id_fg_wh_alloc"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnIdStatus
        '
        Me.GridColumnIdStatus.Caption = "Id Status"
        Me.GridColumnIdStatus.FieldName = "id_report_status"
        Me.GridColumnIdStatus.Name = "GridColumnIdStatus"
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "fg_wh_alloc_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 2
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "fg_wh_alloc_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "fg_wh_alloc_note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 3
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 4
        '
        'GridColumnPreparedBy
        '
        Me.GridColumnPreparedBy.Caption = "Prepared By"
        Me.GridColumnPreparedBy.FieldName = "prepared_by"
        Me.GridColumnPreparedBy.Name = "GridColumnPreparedBy"
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "comp_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 1
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        '
        'GridColumnIsSubmit
        '
        Me.GridColumnIsSubmit.Caption = "Submit"
        Me.GridColumnIsSubmit.FieldName = "is_submit"
        Me.GridColumnIsSubmit.Name = "GridColumnIsSubmit"
        Me.GridColumnIsSubmit.OptionsColumn.AllowEdit = False
        '
        'FormFGWHAlloc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 366)
        Me.Controls.Add(Me.GCFGWHAlloc)
        Me.MinimizeBox = False
        Me.Name = "FormFGWHAlloc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Allocation"
        CType(Me.GCFGWHAlloc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGWHAlloc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCFGWHAlloc As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGWHAlloc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPreparedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsSubmit As DevExpress.XtraGrid.Columns.GridColumn
End Class
