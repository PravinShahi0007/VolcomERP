<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGProposePrice
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
        Me.GCFGPropose = New DevExpress.XtraGrid.GridControl
        Me.GVFGPropose = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnFGProposeNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSource = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCFGPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFGPropose
        '
        Me.GCFGPropose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGPropose.Location = New System.Drawing.Point(0, 0)
        Me.GCFGPropose.MainView = Me.GVFGPropose
        Me.GCFGPropose.Name = "GCFGPropose"
        Me.GCFGPropose.Size = New System.Drawing.Size(769, 480)
        Me.GCFGPropose.TabIndex = 0
        Me.GCFGPropose.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGPropose})
        '
        'GVFGPropose
        '
        Me.GVFGPropose.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnFGProposeNumber, Me.GridColumnSeason, Me.GridColumnSource, Me.GridColumnCreatedDate, Me.GridColumnDivision, Me.GridColumnStatus})
        Me.GVFGPropose.GridControl = Me.GCFGPropose
        Me.GVFGPropose.Name = "GVFGPropose"
        Me.GVFGPropose.OptionsView.ShowGroupPanel = False
        '
        'GridColumnFGProposeNumber
        '
        Me.GridColumnFGProposeNumber.Caption = "Number"
        Me.GridColumnFGProposeNumber.FieldName = "fg_propose_price_number"
        Me.GridColumnFGProposeNumber.Name = "GridColumnFGProposeNumber"
        Me.GridColumnFGProposeNumber.Visible = True
        Me.GridColumnFGProposeNumber.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'GridColumnSource
        '
        Me.GridColumnSource.Caption = "Source"
        Me.GridColumnSource.FieldName = "source"
        Me.GridColumnSource.FieldNameSortGroup = "id_source"
        Me.GridColumnSource.Name = "GridColumnSource"
        Me.GridColumnSource.Visible = True
        Me.GridColumnSource.VisibleIndex = 2
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "fg_propose_price_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 4
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "division"
        Me.GridColumnDivision.FieldNameSortGroup = "id_division"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 3
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.FieldNameSortGroup = "id_report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 5
        '
        'FormFGProposePrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 480)
        Me.Controls.Add(Me.GCFGPropose)
        Me.Name = "FormFGProposePrice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose Price - Normal Price"
        CType(Me.GCFGPropose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGPropose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCFGPropose As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGPropose As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnFGProposeNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
End Class
