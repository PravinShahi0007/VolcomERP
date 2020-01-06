<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAREvaluationLog
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumneval_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnlog_time = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnlog = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnlog_status = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.GCData.Size = New System.Drawing.Size(549, 305)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumneval_date, Me.GridColumnlog_time, Me.GridColumnlog, Me.GridColumnlog_status})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsPrint.AllowMultilineHeaders = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        Me.GVData.RowHeight = 35
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'GridColumneval_date
        '
        Me.GridColumneval_date.Caption = "Evaluation Date"
        Me.GridColumneval_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumneval_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumneval_date.FieldName = "eval_date"
        Me.GridColumneval_date.Name = "GridColumneval_date"
        Me.GridColumneval_date.Visible = True
        Me.GridColumneval_date.VisibleIndex = 0
        '
        'GridColumnlog_time
        '
        Me.GridColumnlog_time.Caption = "Log Time"
        Me.GridColumnlog_time.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnlog_time.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnlog_time.FieldName = "log_time"
        Me.GridColumnlog_time.Name = "GridColumnlog_time"
        Me.GridColumnlog_time.Visible = True
        Me.GridColumnlog_time.VisibleIndex = 1
        '
        'GridColumnlog
        '
        Me.GridColumnlog.Caption = "Log"
        Me.GridColumnlog.FieldName = "log"
        Me.GridColumnlog.Name = "GridColumnlog"
        Me.GridColumnlog.Visible = True
        Me.GridColumnlog.VisibleIndex = 2
        '
        'GridColumnlog_status
        '
        Me.GridColumnlog_status.Caption = "Status"
        Me.GridColumnlog_status.FieldName = "log_status"
        Me.GridColumnlog_status.Name = "GridColumnlog_status"
        Me.GridColumnlog_status.Visible = True
        Me.GridColumnlog_status.VisibleIndex = 3
        '
        'FormAREvaluationLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 305)
        Me.Controls.Add(Me.GCData)
        Me.MinimizeBox = False
        Me.Name = "FormAREvaluationLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumneval_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnlog_time As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnlog As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnlog_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
End Class
