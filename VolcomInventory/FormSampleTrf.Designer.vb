<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleTrf
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
        Me.GCSampleTrf = New DevExpress.XtraGrid.GridControl
        Me.GVSampleTrf = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnFGTrfNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompNameFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompNameTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnFGTrfDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCSampleTrf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleTrf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSampleTrf
        '
        Me.GCSampleTrf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleTrf.Location = New System.Drawing.Point(0, 0)
        Me.GCSampleTrf.MainView = Me.GVSampleTrf
        Me.GCSampleTrf.Name = "GCSampleTrf"
        Me.GCSampleTrf.Size = New System.Drawing.Size(739, 502)
        Me.GCSampleTrf.TabIndex = 1
        Me.GCSampleTrf.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleTrf})
        '
        'GVSampleTrf
        '
        Me.GVSampleTrf.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnFGTrfNumber, Me.GridColumnCompNameFrom, Me.GridColumnCompNameTo, Me.GridColumnFGTrfDate, Me.GridColumnStatus})
        Me.GVSampleTrf.GridControl = Me.GCSampleTrf
        Me.GVSampleTrf.Name = "GVSampleTrf"
        Me.GVSampleTrf.OptionsView.ShowGroupPanel = False
        '
        'GridColumnFGTrfNumber
        '
        Me.GridColumnFGTrfNumber.Caption = "Number"
        Me.GridColumnFGTrfNumber.FieldName = "fg_trf_number"
        Me.GridColumnFGTrfNumber.Name = "GridColumnFGTrfNumber"
        Me.GridColumnFGTrfNumber.Visible = True
        Me.GridColumnFGTrfNumber.VisibleIndex = 0
        '
        'GridColumnCompNameFrom
        '
        Me.GridColumnCompNameFrom.Caption = "From"
        Me.GridColumnCompNameFrom.FieldName = "comp_name_from"
        Me.GridColumnCompNameFrom.Name = "GridColumnCompNameFrom"
        Me.GridColumnCompNameFrom.Visible = True
        Me.GridColumnCompNameFrom.VisibleIndex = 1
        '
        'GridColumnCompNameTo
        '
        Me.GridColumnCompNameTo.Caption = "To"
        Me.GridColumnCompNameTo.FieldName = "comp_name_to"
        Me.GridColumnCompNameTo.Name = "GridColumnCompNameTo"
        Me.GridColumnCompNameTo.Visible = True
        Me.GridColumnCompNameTo.VisibleIndex = 2
        '
        'GridColumnFGTrfDate
        '
        Me.GridColumnFGTrfDate.Caption = "Created Date"
        Me.GridColumnFGTrfDate.FieldName = "fg_trf_date"
        Me.GridColumnFGTrfDate.Name = "GridColumnFGTrfDate"
        Me.GridColumnFGTrfDate.Visible = True
        Me.GridColumnFGTrfDate.VisibleIndex = 3
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 4
        '
        'FormSampleTrf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 502)
        Me.Controls.Add(Me.GCSampleTrf)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleTrf"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transfer"
        CType(Me.GCSampleTrf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleTrf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSampleTrf As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleTrf As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnFGTrfNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNameFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNameTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFGTrfDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
