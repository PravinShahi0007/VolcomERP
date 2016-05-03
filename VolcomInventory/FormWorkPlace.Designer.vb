<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWorkPlace
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
        Me.GCWorkplace = New DevExpress.XtraGrid.GridControl
        Me.GVWorkplace = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.row = New DevExpress.XtraGrid.Columns.GridColumn
        Me.time = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        CType(Me.GCWorkplace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVWorkplace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCWorkplace
        '
        Me.GCWorkplace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCWorkplace.Location = New System.Drawing.Point(0, 0)
        Me.GCWorkplace.MainView = Me.GVWorkplace
        Me.GCWorkplace.Name = "GCWorkplace"
        Me.GCWorkplace.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCWorkplace.Size = New System.Drawing.Size(613, 326)
        Me.GCWorkplace.TabIndex = 2
        Me.GCWorkplace.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVWorkplace})
        '
        'GVWorkplace
        '
        Me.GVWorkplace.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GVWorkplace.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GVWorkplace.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.row, Me.time})
        Me.GVWorkplace.GridControl = Me.GCWorkplace
        Me.GVWorkplace.Name = "GVWorkplace"
        Me.GVWorkplace.OptionsBehavior.Editable = False
        Me.GVWorkplace.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVWorkplace.OptionsSelection.EnableAppearanceFocusedRow = False
        '
        'row
        '
        Me.row.Caption = "ROW"
        Me.row.FieldName = "season"
        Me.row.Name = "row"
        Me.row.Visible = True
        Me.row.VisibleIndex = 0
        '
        'time
        '
        Me.time.Caption = "DATE"
        Me.time.FieldName = "time"
        Me.time.Name = "time"
        Me.time.Visible = True
        Me.time.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'FormWorkPlace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 326)
        Me.Controls.Add(Me.GCWorkplace)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormWorkPlace"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Workplace"
        CType(Me.GCWorkplace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVWorkplace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCWorkplace As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVWorkplace As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents row As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents time As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
