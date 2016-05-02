<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturnQC
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
        Me.components = New System.ComponentModel.Container()
        Me.GCSalesReturnQC = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesReturnQC = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSalesReturnQCNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesReturnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreNameFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQCCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMPrePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridColumnLastUpdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUser = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCSalesReturnQC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesReturnQC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCSalesReturnQC
        '
        Me.GCSalesReturnQC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesReturnQC.Location = New System.Drawing.Point(0, 0)
        Me.GCSalesReturnQC.MainView = Me.GVSalesReturnQC
        Me.GCSalesReturnQC.Name = "GCSalesReturnQC"
        Me.GCSalesReturnQC.Size = New System.Drawing.Size(768, 509)
        Me.GCSalesReturnQC.TabIndex = 0
        Me.GCSalesReturnQC.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesReturnQC})
        '
        'GVSalesReturnQC
        '
        Me.GVSalesReturnQC.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSalesReturnQCNumber, Me.GridColumnSalesReturnNumber, Me.GridColumnStoreNameFrom, Me.GridColumnCreatedDate, Me.GridColumnQCCategory, Me.GridColumnReportStatus, Me.GridColumnCompTo, Me.GridColumnLastUpdate, Me.GridColumnLastUser})
        Me.GVSalesReturnQC.GridControl = Me.GCSalesReturnQC
        Me.GVSalesReturnQC.Name = "GVSalesReturnQC"
        Me.GVSalesReturnQC.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSalesReturnQCNumber
        '
        Me.GridColumnSalesReturnQCNumber.Caption = "Number"
        Me.GridColumnSalesReturnQCNumber.FieldName = "sales_return_qc_number"
        Me.GridColumnSalesReturnQCNumber.Name = "GridColumnSalesReturnQCNumber"
        Me.GridColumnSalesReturnQCNumber.Visible = True
        Me.GridColumnSalesReturnQCNumber.VisibleIndex = 0
        '
        'GridColumnSalesReturnNumber
        '
        Me.GridColumnSalesReturnNumber.Caption = "Return Number"
        Me.GridColumnSalesReturnNumber.FieldName = "sales_return_number"
        Me.GridColumnSalesReturnNumber.Name = "GridColumnSalesReturnNumber"
        Me.GridColumnSalesReturnNumber.Visible = True
        Me.GridColumnSalesReturnNumber.VisibleIndex = 1
        '
        'GridColumnStoreNameFrom
        '
        Me.GridColumnStoreNameFrom.Caption = "Return From"
        Me.GridColumnStoreNameFrom.FieldName = "store_name_from"
        Me.GridColumnStoreNameFrom.Name = "GridColumnStoreNameFrom"
        Me.GridColumnStoreNameFrom.Visible = True
        Me.GridColumnStoreNameFrom.VisibleIndex = 2
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "sales_return_qc_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 5
        '
        'GridColumnQCCategory
        '
        Me.GridColumnQCCategory.Caption = "QC Category"
        Me.GridColumnQCCategory.FieldName = "pl_category"
        Me.GridColumnQCCategory.Name = "GridColumnQCCategory"
        Me.GridColumnQCCategory.Visible = True
        Me.GridColumnQCCategory.VisibleIndex = 4
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 8
        '
        'GridColumnCompTo
        '
        Me.GridColumnCompTo.Caption = "Destination"
        Me.GridColumnCompTo.FieldName = "comp_name_to"
        Me.GridColumnCompTo.Name = "GridColumnCompTo"
        Me.GridColumnCompTo.Visible = True
        Me.GridColumnCompTo.VisibleIndex = 3
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMPrePrint, Me.SMPrint})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(137, 48)
        '
        'SMPrePrint
        '
        Me.SMPrePrint.Name = "SMPrePrint"
        Me.SMPrePrint.Size = New System.Drawing.Size(136, 22)
        Me.SMPrePrint.Text = "Pre Printing"
        '
        'SMPrint
        '
        Me.SMPrint.Name = "SMPrint"
        Me.SMPrint.Size = New System.Drawing.Size(136, 22)
        Me.SMPrint.Text = "Print"
        '
        'GridColumnLastUpdate
        '
        Me.GridColumnLastUpdate.Caption = "Last Updated"
        Me.GridColumnLastUpdate.DisplayFormat.FormatString = "dd MMMM yyyy'/'hh:mm tt"
        Me.GridColumnLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpdate.FieldName = "last_update"
        Me.GridColumnLastUpdate.Name = "GridColumnLastUpdate"
        Me.GridColumnLastUpdate.Visible = True
        Me.GridColumnLastUpdate.VisibleIndex = 6
        '
        'GridColumnLastUser
        '
        Me.GridColumnLastUser.Caption = "Updated By"
        Me.GridColumnLastUser.FieldName = "last_user"
        Me.GridColumnLastUser.Name = "GridColumnLastUser"
        Me.GridColumnLastUser.Visible = True
        Me.GridColumnLastUser.VisibleIndex = 7
        '
        'FormSalesReturnQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 509)
        Me.Controls.Add(Me.GCSalesReturnQC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReturnQC"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return Quality Control"
        CType(Me.GCSalesReturnQC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesReturnQC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSalesReturnQC As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesReturnQC As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSalesReturnQCNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesReturnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreNameFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQCCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMPrePrint As ToolStripMenuItem
    Friend WithEvents SMPrint As ToolStripMenuItem
    Friend WithEvents GridColumnLastUpdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUser As DevExpress.XtraGrid.Columns.GridColumn
End Class
