<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesInvoice
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
        Me.GCSalesInvoice = New DevExpress.XtraGrid.GridControl
        Me.GVSalesInvoice = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPeriod = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSOType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStore = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCSalesInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSalesInvoice
        '
        Me.GCSalesInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesInvoice.Location = New System.Drawing.Point(0, 0)
        Me.GCSalesInvoice.MainView = Me.GVSalesInvoice
        Me.GCSalesInvoice.Name = "GCSalesInvoice"
        Me.GCSalesInvoice.Size = New System.Drawing.Size(706, 438)
        Me.GCSalesInvoice.TabIndex = 0
        Me.GCSalesInvoice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesInvoice})
        '
        'GVSalesInvoice
        '
        Me.GVSalesInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNumber, Me.GridColumnPeriod, Me.GridColumnSOType, Me.GridColumnCreatedDate, Me.GridColumnStore, Me.GridColumnReportStatus})
        Me.GVSalesInvoice.GridControl = Me.GCSalesInvoice
        Me.GVSalesInvoice.Name = "GVSalesInvoice"
        Me.GVSalesInvoice.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "sales_invoice_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnPeriod
        '
        Me.GridColumnPeriod.Caption = "Period"
        Me.GridColumnPeriod.FieldName = "sales_invoice_period"
        Me.GridColumnPeriod.Name = "GridColumnPeriod"
        Me.GridColumnPeriod.Visible = True
        Me.GridColumnPeriod.VisibleIndex = 2
        '
        'GridColumnSOType
        '
        Me.GridColumnSOType.Caption = "Sales Type"
        Me.GridColumnSOType.FieldName = "so_type"
        Me.GridColumnSOType.Name = "GridColumnSOType"
        Me.GridColumnSOType.Visible = True
        Me.GridColumnSOType.VisibleIndex = 3
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.FieldName = "sales_invoice_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 4
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
        Me.GridColumnReportStatus.VisibleIndex = 5
        '
        'FormSalesInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 438)
        Me.Controls.Add(Me.GCSalesInvoice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesInvoice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Invoice"
        CType(Me.GCSalesInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSalesInvoice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPeriod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
