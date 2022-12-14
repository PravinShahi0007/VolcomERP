<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterAssetCategory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GCAssetCat = New DevExpress.XtraGrid.GridControl()
        Me.GVAssetCat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColumnIdCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCodeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCodeDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.GCAssetCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAssetCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCAssetCat
        '
        Me.GCAssetCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAssetCat.Location = New System.Drawing.Point(0, 0)
        Me.GCAssetCat.MainView = Me.GVAssetCat
        Me.GCAssetCat.Name = "GCAssetCat"
        Me.GCAssetCat.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit3, Me.RepositoryItemCheckEdit4})
        Me.GCAssetCat.Size = New System.Drawing.Size(918, 406)
        Me.GCAssetCat.TabIndex = 1
        Me.GCAssetCat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAssetCat})
        '
        'GVAssetCat
        '
        Me.GVAssetCat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdCode, Me.GCCodeName, Me.GCCodeDesc})
        Me.GVAssetCat.GridControl = Me.GCAssetCat
        Me.GVAssetCat.Name = "GVAssetCat"
        Me.GVAssetCat.OptionsBehavior.Editable = False
        Me.GVAssetCat.OptionsView.ShowGroupPanel = False
        '
        'ColumnIdCode
        '
        Me.ColumnIdCode.Caption = "Id Code"
        Me.ColumnIdCode.FieldName = "id_asset_cat"
        Me.ColumnIdCode.Name = "ColumnIdCode"
        '
        'GCCodeName
        '
        Me.GCCodeName.Caption = "Code"
        Me.GCCodeName.FieldName = "asset_cat_code"
        Me.GCCodeName.Name = "GCCodeName"
        Me.GCCodeName.Visible = True
        Me.GCCodeName.VisibleIndex = 0
        Me.GCCodeName.Width = 132
        '
        'GCCodeDesc
        '
        Me.GCCodeDesc.Caption = "Category"
        Me.GCCodeDesc.FieldName = "asset_cat"
        Me.GCCodeDesc.Name = "GCCodeDesc"
        Me.GCCodeDesc.Visible = True
        Me.GCCodeDesc.VisibleIndex = 1
        Me.GCCodeDesc.Width = 210
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        '
        'RepositoryItemCheckEdit4
        '
        Me.RepositoryItemCheckEdit4.AutoHeight = False
        Me.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'FormMasterAssetCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 406)
        Me.Controls.Add(Me.GCAssetCat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterAssetCategory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Asset Category"
        CType(Me.GCAssetCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAssetCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCAssetCat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAssetCat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCodeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCodeDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
