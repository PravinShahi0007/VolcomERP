<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterItemSize
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
        Me.GCItemSize = New DevExpress.XtraGrid.GridControl
        Me.GVItemSize = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumnIdItemSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnCodeItemSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnItemSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCItemSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCItemSize
        '
        Me.GCItemSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemSize.Location = New System.Drawing.Point(0, 0)
        Me.GCItemSize.MainView = Me.GVItemSize
        Me.GCItemSize.Name = "GCItemSize"
        Me.GCItemSize.Size = New System.Drawing.Size(521, 329)
        Me.GCItemSize.TabIndex = 0
        Me.GCItemSize.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemSize})
        '
        'GVItemSize
        '
        Me.GVItemSize.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdItemSize, Me.ColumnCodeItemSize, Me.ColumnItemSize, Me.ColumnDescription})
        Me.GVItemSize.GridControl = Me.GCItemSize
        Me.GVItemSize.Name = "GVItemSize"
        Me.GVItemSize.OptionsBehavior.Editable = False
        '
        'ColumnIdItemSize
        '
        Me.ColumnIdItemSize.Caption = "Id "
        Me.ColumnIdItemSize.FieldName = "id_item_size"
        Me.ColumnIdItemSize.Name = "ColumnIdItemSize"
        '
        'ColumnCodeItemSize
        '
        Me.ColumnCodeItemSize.Caption = "Code "
        Me.ColumnCodeItemSize.FieldName = "code_item_size"
        Me.ColumnCodeItemSize.Name = "ColumnCodeItemSize"
        Me.ColumnCodeItemSize.Visible = True
        Me.ColumnCodeItemSize.VisibleIndex = 0
        '
        'ColumnItemSize
        '
        Me.ColumnItemSize.Caption = "Item Size"
        Me.ColumnItemSize.FieldName = "item_size"
        Me.ColumnItemSize.Name = "ColumnItemSize"
        Me.ColumnItemSize.Visible = True
        Me.ColumnItemSize.VisibleIndex = 1
        '
        'ColumnDescription
        '
        Me.ColumnDescription.Caption = "Description"
        Me.ColumnDescription.FieldName = "description_item_size"
        Me.ColumnDescription.Name = "ColumnDescription"
        Me.ColumnDescription.Visible = True
        Me.ColumnDescription.VisibleIndex = 2
        '
        'FormMasterItemSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 329)
        Me.Controls.Add(Me.GCItemSize)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterItemSize"
        Me.ShowInTaskbar = False
        Me.Text = "Master Item Size"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GCItemSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCItemSize As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemSize As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdItemSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCodeItemSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnItemSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
End Class
