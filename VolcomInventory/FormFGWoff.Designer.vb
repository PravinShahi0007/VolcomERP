<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGWoff
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
        Me.GCFGWoff = New DevExpress.XtraGrid.GridControl
        Me.GVFGWoff = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnFGWoff = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompNameFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnFGWoffDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCFGWoff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGWoff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFGWoff
        '
        Me.GCFGWoff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGWoff.Location = New System.Drawing.Point(0, 0)
        Me.GCFGWoff.MainView = Me.GVFGWoff
        Me.GCFGWoff.Name = "GCFGWoff"
        Me.GCFGWoff.Size = New System.Drawing.Size(764, 486)
        Me.GCFGWoff.TabIndex = 1
        Me.GCFGWoff.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGWoff})
        '
        'GVFGWoff
        '
        Me.GVFGWoff.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnFGWoff, Me.GridColumnCompNameFrom, Me.GridColumnFGWoffDate, Me.GridColumnStatus})
        Me.GVFGWoff.GridControl = Me.GCFGWoff
        Me.GVFGWoff.Name = "GVFGWoff"
        Me.GVFGWoff.OptionsView.ShowGroupPanel = False
        '
        'GridColumnFGWoff
        '
        Me.GridColumnFGWoff.Caption = "Number"
        Me.GridColumnFGWoff.FieldName = "fg_woff_number"
        Me.GridColumnFGWoff.Name = "GridColumnFGWoff"
        Me.GridColumnFGWoff.Visible = True
        Me.GridColumnFGWoff.VisibleIndex = 0
        '
        'GridColumnCompNameFrom
        '
        Me.GridColumnCompNameFrom.Caption = "From"
        Me.GridColumnCompNameFrom.FieldName = "comp_name_from"
        Me.GridColumnCompNameFrom.Name = "GridColumnCompNameFrom"
        Me.GridColumnCompNameFrom.Visible = True
        Me.GridColumnCompNameFrom.VisibleIndex = 1
        '
        'GridColumnFGWoffDate
        '
        Me.GridColumnFGWoffDate.Caption = "Created Date"
        Me.GridColumnFGWoffDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnFGWoffDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnFGWoffDate.FieldName = "fg_woff_date"
        Me.GridColumnFGWoffDate.Name = "GridColumnFGWoffDate"
        Me.GridColumnFGWoffDate.Visible = True
        Me.GridColumnFGWoffDate.VisibleIndex = 2
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 3
        '
        'FormFGWoff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 486)
        Me.Controls.Add(Me.GCFGWoff)
        Me.MinimizeBox = False
        Me.Name = "FormFGWoff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Write Off Finished Goods"
        CType(Me.GCFGWoff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGWoff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCFGWoff As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGWoff As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnFGWoff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNameFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFGWoffDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
