<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterItemColor
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
        Me.GCItemColor = New DevExpress.XtraGrid.GridControl
        Me.GVItemColor = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumIdItemColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnCodeItemColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnItemColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCItemColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCItemColor
        '
        Me.GCItemColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemColor.Location = New System.Drawing.Point(0, 0)
        Me.GCItemColor.MainView = Me.GVItemColor
        Me.GCItemColor.Name = "GCItemColor"
        Me.GCItemColor.Size = New System.Drawing.Size(552, 347)
        Me.GCItemColor.TabIndex = 0
        Me.GCItemColor.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemColor})
        '
        'GVItemColor
        '
        Me.GVItemColor.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumIdItemColor, Me.ColumnCodeItemColor, Me.ColumnItemColor, Me.ColumnDescription})
        Me.GVItemColor.GridControl = Me.GCItemColor
        Me.GVItemColor.Name = "GVItemColor"
        Me.GVItemColor.OptionsBehavior.Editable = False
        '
        'ColumIdItemColor
        '
        Me.ColumIdItemColor.Caption = "Id"
        Me.ColumIdItemColor.FieldName = "id_item_color"
        Me.ColumIdItemColor.Name = "ColumIdItemColor"
        '
        'ColumnCodeItemColor
        '
        Me.ColumnCodeItemColor.Caption = "Code"
        Me.ColumnCodeItemColor.FieldName = "code_item_color"
        Me.ColumnCodeItemColor.Name = "ColumnCodeItemColor"
        Me.ColumnCodeItemColor.Visible = True
        Me.ColumnCodeItemColor.VisibleIndex = 0
        '
        'ColumnItemColor
        '
        Me.ColumnItemColor.Caption = "Item Color"
        Me.ColumnItemColor.FieldName = "item_color"
        Me.ColumnItemColor.Name = "ColumnItemColor"
        Me.ColumnItemColor.Visible = True
        Me.ColumnItemColor.VisibleIndex = 1
        '
        'ColumnDescription
        '
        Me.ColumnDescription.Caption = "Description"
        Me.ColumnDescription.FieldName = "description_item_color"
        Me.ColumnDescription.Name = "ColumnDescription"
        Me.ColumnDescription.Visible = True
        Me.ColumnDescription.VisibleIndex = 2
        '
        'FormMasterItemColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 347)
        Me.Controls.Add(Me.GCItemColor)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterItemColor"
        Me.ShowInTaskbar = False
        Me.Text = "Master Color"
        CType(Me.GCItemColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCItemColor As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemColor As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumIdItemColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCodeItemColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnItemColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
End Class
