<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleOrdered
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
        Me.GCSampleOrder = New DevExpress.XtraGrid.GridControl
        Me.GVSampleOrder = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSampleOrder
        '
        Me.GCSampleOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleOrder.Location = New System.Drawing.Point(0, 0)
        Me.GCSampleOrder.MainView = Me.GVSampleOrder
        Me.GCSampleOrder.Name = "GCSampleOrder"
        Me.GCSampleOrder.Size = New System.Drawing.Size(664, 421)
        Me.GCSampleOrder.TabIndex = 0
        Me.GCSampleOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleOrder})
        '
        'GVSampleOrder
        '
        Me.GVSampleOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn4, Me.GridColumn3, Me.GridColumn5})
        Me.GVSampleOrder.GridControl = Me.GCSampleOrder
        Me.GVSampleOrder.Name = "GVSampleOrder"
        Me.GVSampleOrder.OptionsView.ShowGroupPanel = False
        Me.GVSampleOrder.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn5, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Number"
        Me.GridColumn1.FieldName = "sample_ordered_number"
        Me.GridColumn1.FieldNameSortGroup = "id_sample_ordered"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Created Date"
        Me.GridColumn2.FieldName = "sample_ordered_date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Note"
        Me.GridColumn4.FieldName = "sample_ordered_note"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Status"
        Me.GridColumn3.FieldName = "report_status"
        Me.GridColumn3.FieldNameSortGroup = "id_report_status"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Id Sample Ordered"
        Me.GridColumn5.FieldName = "id_sample_ordered"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.ShowInCustomizationForm = False
        '
        'FormSampleOrdered
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 421)
        Me.Controls.Add(Me.GCSampleOrder)
        Me.MaximizeBox = False
        Me.Name = "FormSampleOrdered"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sample Order"
        CType(Me.GCSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSampleOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
End Class
