<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatStockOpname
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
        Me.GCMatPR = New DevExpress.XtraGrid.GridControl
        Me.GVMatPR = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdMatSO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDateCreated = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDateUpdated = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIDReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatusOpen = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnidLock = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCMatPR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatPR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCMatPR
        '
        Me.GCMatPR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatPR.Location = New System.Drawing.Point(0, 0)
        Me.GCMatPR.MainView = Me.GVMatPR
        Me.GCMatPR.Name = "GCMatPR"
        Me.GCMatPR.Size = New System.Drawing.Size(840, 447)
        Me.GCMatPR.TabIndex = 3
        Me.GCMatPR.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatPR})
        '
        'GVMatPR
        '
        Me.GVMatPR.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdMatSO, Me.GridColumnDateCreated, Me.GridColumnDateUpdated, Me.GridColumnReportStatus, Me.GridColumnIDReportStatus, Me.GridColumnNumber, Me.GridColumnStatusOpen, Me.GridColumnidLock})
        Me.GVMatPR.GridControl = Me.GCMatPR
        Me.GVMatPR.GroupCount = 1
        Me.GVMatPR.Name = "GVMatPR"
        Me.GVMatPR.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVMatPR.OptionsBehavior.Editable = False
        Me.GVMatPR.OptionsFind.AlwaysVisible = True
        Me.GVMatPR.OptionsView.ShowGroupPanel = False
        Me.GVMatPR.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnStatusOpen, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdMatSO
        '
        Me.GridColumnIdMatSO.Caption = "Id Mat SO"
        Me.GridColumnIdMatSO.FieldName = "id_mat_so"
        Me.GridColumnIdMatSO.Name = "GridColumnIdMatSO"
        '
        'GridColumnDateCreated
        '
        Me.GridColumnDateCreated.Caption = "Date Created"
        Me.GridColumnDateCreated.FieldName = "mat_so_date_created"
        Me.GridColumnDateCreated.Name = "GridColumnDateCreated"
        Me.GridColumnDateCreated.Visible = True
        Me.GridColumnDateCreated.VisibleIndex = 1
        Me.GridColumnDateCreated.Width = 136
        '
        'GridColumnDateUpdated
        '
        Me.GridColumnDateUpdated.Caption = "Last Update"
        Me.GridColumnDateUpdated.FieldName = "mat_so_last_update"
        Me.GridColumnDateUpdated.Name = "GridColumnDateUpdated"
        Me.GridColumnDateUpdated.Visible = True
        Me.GridColumnDateUpdated.VisibleIndex = 2
        Me.GridColumnDateUpdated.Width = 136
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 3
        Me.GridColumnReportStatus.Width = 89
        '
        'GridColumnIDReportStatus
        '
        Me.GridColumnIDReportStatus.Caption = "Id Report Status"
        Me.GridColumnIDReportStatus.FieldName = "id_report_status"
        Me.GridColumnIDReportStatus.Name = "GridColumnIDReportStatus"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "mat_so_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        Me.GridColumnNumber.Width = 122
        '
        'GridColumnStatusOpen
        '
        Me.GridColumnStatusOpen.Caption = "Stock Opname Status"
        Me.GridColumnStatusOpen.FieldName = "lock"
        Me.GridColumnStatusOpen.Name = "GridColumnStatusOpen"
        Me.GridColumnStatusOpen.Visible = True
        Me.GridColumnStatusOpen.VisibleIndex = 4
        Me.GridColumnStatusOpen.Width = 120
        '
        'GridColumnidLock
        '
        Me.GridColumnidLock.Caption = "Id Lock"
        Me.GridColumnidLock.FieldName = "id_lock"
        Me.GridColumnidLock.Name = "GridColumnidLock"
        '
        'FormMatStockOpname
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 447)
        Me.Controls.Add(Me.GCMatPR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatStockOpname"
        Me.Text = "Stock Opname"
        CType(Me.GCMatPR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatPR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCMatPR As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatPR As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdMatSO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDateCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDateUpdated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatusOpen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnidLock As DevExpress.XtraGrid.Columns.GridColumn
End Class
