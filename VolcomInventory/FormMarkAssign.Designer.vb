<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMarkAssign
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
        Me.GCMarkAssign = New DevExpress.XtraGrid.GridControl()
        Me.GVMarkAssign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdMarkAssign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMarkIdType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMarkType = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCMarkAssign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMarkAssign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCMarkAssign
        '
        Me.GCMarkAssign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMarkAssign.Location = New System.Drawing.Point(0, 0)
        Me.GCMarkAssign.MainView = Me.GVMarkAssign
        Me.GCMarkAssign.Name = "GCMarkAssign"
        Me.GCMarkAssign.Size = New System.Drawing.Size(764, 349)
        Me.GCMarkAssign.TabIndex = 2
        Me.GCMarkAssign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMarkAssign})
        '
        'GVMarkAssign
        '
        Me.GVMarkAssign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMarkAssign, Me.GridColumn1, Me.ColMarkIdType, Me.ColIdReportStatus, Me.ColReportStatus, Me.ColMarkType})
        Me.GVMarkAssign.CustomizationFormBounds = New System.Drawing.Rectangle(609, 328, 210, 172)
        Me.GVMarkAssign.GridControl = Me.GCMarkAssign
        Me.GVMarkAssign.GroupCount = 1
        Me.GVMarkAssign.Name = "GVMarkAssign"
        Me.GVMarkAssign.OptionsBehavior.Editable = False
        Me.GVMarkAssign.OptionsView.ShowGroupPanel = False
        Me.GVMarkAssign.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdMarkAssign, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdMarkAssign
        '
        Me.ColIdMarkAssign.Caption = "Id Mark Assign"
        Me.ColIdMarkAssign.FieldName = "id_mark_asg"
        Me.ColIdMarkAssign.Name = "ColIdMarkAssign"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Report"
        Me.GridColumn1.FieldName = "report_mark_type_name"
        Me.GridColumn1.FieldNameSortGroup = "report_mark_type"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'ColMarkIdType
        '
        Me.ColMarkIdType.Caption = "Report"
        Me.ColMarkIdType.FieldName = "report_mark_type"
        Me.ColMarkIdType.Name = "ColMarkIdType"
        '
        'ColIdReportStatus
        '
        Me.ColIdReportStatus.Caption = "Status"
        Me.ColIdReportStatus.FieldName = "id_report_status"
        Me.ColIdReportStatus.Name = "ColIdReportStatus"
        '
        'ColReportStatus
        '
        Me.ColReportStatus.Caption = "Status"
        Me.ColReportStatus.FieldName = "report_status"
        Me.ColReportStatus.Name = "ColReportStatus"
        Me.ColReportStatus.Visible = True
        Me.ColReportStatus.VisibleIndex = 1
        '
        'ColMarkType
        '
        Me.ColMarkType.Caption = "Report"
        Me.ColMarkType.FieldName = "report_mark_type_name"
        Me.ColMarkType.Name = "ColMarkType"
        Me.ColMarkType.Visible = True
        Me.ColMarkType.VisibleIndex = 0
        '
        'FormMarkAssign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 349)
        Me.Controls.Add(Me.GCMarkAssign)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMarkAssign"
        Me.ShowInTaskbar = False
        Me.Text = "Assign Mark"
        CType(Me.GCMarkAssign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMarkAssign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCMarkAssign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMarkAssign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMarkAssign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkIdType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
