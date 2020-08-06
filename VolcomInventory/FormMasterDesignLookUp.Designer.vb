<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterDesignLookUp
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
        Me.GCBrowse = New DevExpress.XtraGrid.GridControl()
        Me.GVBrowse = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumnGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCBrowse
        '
        Me.GCBrowse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBrowse.Location = New System.Drawing.Point(0, 0)
        Me.GCBrowse.MainView = Me.GVBrowse
        Me.GCBrowse.Name = "GCBrowse"
        Me.GCBrowse.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit})
        Me.GCBrowse.Size = New System.Drawing.Size(584, 361)
        Me.GCBrowse.TabIndex = 0
        Me.GCBrowse.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBrowse})
        '
        'GVBrowse
        '
        Me.GVBrowse.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnGroup, Me.GridColumnValue})
        Me.GVBrowse.GridControl = Me.GCBrowse
        Me.GVBrowse.Name = "GVBrowse"
        Me.GVBrowse.OptionsBehavior.Editable = False
        Me.GVBrowse.OptionsView.RowAutoHeight = True
        Me.GVBrowse.OptionsView.ShowGroupPanel = False
        '
        'GridColumnValue
        '
        Me.GridColumnValue.Caption = "Value"
        Me.GridColumnValue.ColumnEdit = Me.RepositoryItemMemoEdit
        Me.GridColumnValue.FieldName = "value"
        Me.GridColumnValue.Name = "GridColumnValue"
        Me.GridColumnValue.Visible = True
        Me.GridColumnValue.VisibleIndex = 1
        '
        'RepositoryItemMemoEdit
        '
        Me.RepositoryItemMemoEdit.Name = "RepositoryItemMemoEdit"
        '
        'GridColumnGroup
        '
        Me.GridColumnGroup.Caption = "Column Group"
        Me.GridColumnGroup.FieldName = "column_group"
        Me.GridColumnGroup.Name = "GridColumnGroup"
        Me.GridColumnGroup.Visible = True
        Me.GridColumnGroup.VisibleIndex = 0
        '
        'FormMasterDesignLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.GCBrowse)
        Me.Name = "FormMasterDesignLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Browse"
        CType(Me.GCBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCBrowse As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBrowse As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumnGroup As DevExpress.XtraGrid.Columns.GridColumn
End Class
