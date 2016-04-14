<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingMapping
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
        Me.GCMarkAssign = New DevExpress.XtraGrid.GridControl
        Me.GVMarkAssign = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdMarkAssign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColMarkIdType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
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
        Me.GCMarkAssign.Size = New System.Drawing.Size(782, 355)
        Me.GCMarkAssign.TabIndex = 3
        Me.GCMarkAssign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMarkAssign})
        '
        'GVMarkAssign
        '
        Me.GVMarkAssign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMarkAssign, Me.ColMarkIdType, Me.ColReportStatus})
        Me.GVMarkAssign.GridControl = Me.GCMarkAssign
        Me.GVMarkAssign.Name = "GVMarkAssign"
        Me.GVMarkAssign.OptionsBehavior.Editable = False
        Me.GVMarkAssign.OptionsView.ShowGroupPanel = False
        '
        'ColIdMarkAssign
        '
        Me.ColIdMarkAssign.Caption = "Id Report Mark Type"
        Me.ColIdMarkAssign.FieldName = "report_mark_type"
        Me.ColIdMarkAssign.Name = "ColIdMarkAssign"
        '
        'ColMarkIdType
        '
        Me.ColMarkIdType.Caption = "Report"
        Me.ColMarkIdType.FieldName = "report_mark_type_name"
        Me.ColMarkIdType.Name = "ColMarkIdType"
        Me.ColMarkIdType.Visible = True
        Me.ColMarkIdType.VisibleIndex = 0
        '
        'ColReportStatus
        '
        Me.ColReportStatus.Caption = "Mapping Status"
        Me.ColReportStatus.FieldName = "mapping_status"
        Me.ColReportStatus.Name = "ColReportStatus"
        Me.ColReportStatus.Visible = True
        Me.ColReportStatus.VisibleIndex = 1
        '
        'FormAccountingMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 355)
        Me.Controls.Add(Me.GCMarkAssign)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingMapping"
        Me.Text = "Mapping Account Transaction"
        CType(Me.GCMarkAssign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMarkAssign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCMarkAssign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMarkAssign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMarkAssign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarkIdType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReportStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
