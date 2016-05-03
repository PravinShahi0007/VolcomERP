<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGMissingInvoice
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
        Me.GCFGMissingInvoice = New DevExpress.XtraGrid.GridControl
        Me.GVFGMissingInvoice = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPeriod = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStore = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCFGMissingInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGMissingInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFGMissingInvoice
        '
        Me.GCFGMissingInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGMissingInvoice.Location = New System.Drawing.Point(0, 0)
        Me.GCFGMissingInvoice.MainView = Me.GVFGMissingInvoice
        Me.GCFGMissingInvoice.Name = "GCFGMissingInvoice"
        Me.GCFGMissingInvoice.Size = New System.Drawing.Size(785, 495)
        Me.GCFGMissingInvoice.TabIndex = 1
        Me.GCFGMissingInvoice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGMissingInvoice})
        '
        'GVFGMissingInvoice
        '
        Me.GVFGMissingInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNumber, Me.GridColumnPeriod, Me.GridColumnCreatedDate, Me.GridColumnStore, Me.GridColumnReportStatus})
        Me.GVFGMissingInvoice.GridControl = Me.GCFGMissingInvoice
        Me.GVFGMissingInvoice.Name = "GVFGMissingInvoice"
        Me.GVFGMissingInvoice.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "fg_missing_invoice_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnPeriod
        '
        Me.GridColumnPeriod.Caption = "Period"
        Me.GridColumnPeriod.FieldName = "fg_missing_invoice_period"
        Me.GridColumnPeriod.Name = "GridColumnPeriod"
        Me.GridColumnPeriod.Visible = True
        Me.GridColumnPeriod.VisibleIndex = 2
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.FieldName = "fg_missing_invoice_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 3
        '
        'GridColumnStore
        '
        Me.GridColumnStore.Caption = "Store"
        Me.GridColumnStore.FieldName = "store_name_to"
        Me.GridColumnStore.Name = "GridColumnStore"
        Me.GridColumnStore.Visible = True
        Me.GridColumnStore.VisibleIndex = 1
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 4
        '
        'FormFGMissingInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 495)
        Me.Controls.Add(Me.GCFGMissingInvoice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGMissingInvoice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Missing Finished Goods Invoice"
        CType(Me.GCFGMissingInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGMissingInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCFGMissingInvoice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGMissingInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPeriod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
