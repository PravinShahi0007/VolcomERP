<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompareStockWebHistory
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_log_compare_shopify = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsync_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsync_by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnemployee_name = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(521, 312)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_log_compare_shopify, Me.GridColumnsync_date, Me.GridColumnsync_by, Me.GridColumnemployee_name})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_log_compare_shopify
        '
        Me.GridColumnid_log_compare_shopify.Caption = "id_log_compare_shopify"
        Me.GridColumnid_log_compare_shopify.FieldName = "id_log_compare_shopify"
        Me.GridColumnid_log_compare_shopify.Name = "GridColumnid_log_compare_shopify"
        '
        'GridColumnsync_date
        '
        Me.GridColumnsync_date.Caption = "Sync Date"
        Me.GridColumnsync_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnsync_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsync_date.FieldName = "sync_date"
        Me.GridColumnsync_date.Name = "GridColumnsync_date"
        Me.GridColumnsync_date.Visible = True
        Me.GridColumnsync_date.VisibleIndex = 0
        '
        'GridColumnsync_by
        '
        Me.GridColumnsync_by.Caption = "sync_by_id"
        Me.GridColumnsync_by.FieldName = "sync_by"
        Me.GridColumnsync_by.Name = "GridColumnsync_by"
        '
        'GridColumnemployee_name
        '
        Me.GridColumnemployee_name.Caption = "Sync by"
        Me.GridColumnemployee_name.FieldName = "employee_name"
        Me.GridColumnemployee_name.Name = "GridColumnemployee_name"
        Me.GridColumnemployee_name.Visible = True
        Me.GridColumnemployee_name.VisibleIndex = 1
        '
        'FormCompareStockWebHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 312)
        Me.Controls.Add(Me.GCData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCompareStockWebHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_log_compare_shopify As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsync_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsync_by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnemployee_name As DevExpress.XtraGrid.Columns.GridColumn
End Class
