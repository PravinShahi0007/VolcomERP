<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGTrfReceive
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
        Me.GCFGTrf = New DevExpress.XtraGrid.GridControl
        Me.GVFGTrf = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnFGTrfNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompNameFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompNameTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnFGTrfDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCFGTrf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGTrf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFGTrf
        '
        Me.GCFGTrf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGTrf.Location = New System.Drawing.Point(0, 0)
        Me.GCFGTrf.MainView = Me.GVFGTrf
        Me.GCFGTrf.Name = "GCFGTrf"
        Me.GCFGTrf.Size = New System.Drawing.Size(735, 394)
        Me.GCFGTrf.TabIndex = 2
        Me.GCFGTrf.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGTrf})
        '
        'GVFGTrf
        '
        Me.GVFGTrf.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnFGTrfNumber, Me.GridColumnCompNameFrom, Me.GridColumnCompNameTo, Me.GridColumnFGTrfDate, Me.GridColumn1, Me.GridColumnStatus})
        Me.GVFGTrf.GridControl = Me.GCFGTrf
        Me.GVFGTrf.Name = "GVFGTrf"
        Me.GVFGTrf.OptionsView.ShowGroupPanel = False
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
        Me.GridColumnFGTrfDate.Caption = "Transfer Created Date"
        Me.GridColumnFGTrfDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnFGTrfDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnFGTrfDate.FieldName = "fg_trf_date"
        Me.GridColumnFGTrfDate.Name = "GridColumnFGTrfDate"
        Me.GridColumnFGTrfDate.Visible = True
        Me.GridColumnFGTrfDate.VisibleIndex = 3
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Receive Transfer"
        Me.GridColumn1.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1.FieldName = "fg_trf_date_rec"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 5
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 4
        '
        'FormFGTrfReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 394)
        Me.Controls.Add(Me.GCFGTrf)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGTrfReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receive Transfer"
        CType(Me.GCFGTrf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGTrf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCFGTrf As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGTrf As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnFGTrfNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNameFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNameTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFGTrfDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
