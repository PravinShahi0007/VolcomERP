<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterRawMaterialCat
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
        Me.GridControlMasterItemCategory = New DevExpress.XtraGrid.GridControl
        Me.GridViewMasterItemCategory = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdItemCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMasterItemCategory = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GridControlMasterItemCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewMasterItemCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControlMasterItemCategory
        '
        Me.GridControlMasterItemCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlMasterItemCategory.Location = New System.Drawing.Point(0, 0)
        Me.GridControlMasterItemCategory.MainView = Me.GridViewMasterItemCategory
        Me.GridControlMasterItemCategory.Name = "GridControlMasterItemCategory"
        Me.GridControlMasterItemCategory.Size = New System.Drawing.Size(667, 368)
        Me.GridControlMasterItemCategory.TabIndex = 0
        Me.GridControlMasterItemCategory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewMasterItemCategory})
        '
        'GridViewMasterItemCategory
        '
        Me.GridViewMasterItemCategory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdItemCategory, Me.GridColumnMasterItemCategory})
        Me.GridViewMasterItemCategory.GridControl = Me.GridControlMasterItemCategory
        Me.GridViewMasterItemCategory.Name = "GridViewMasterItemCategory"
        Me.GridViewMasterItemCategory.OptionsBehavior.Editable = False
        Me.GridViewMasterItemCategory.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdItemCategory
        '
        Me.GridColumnIdItemCategory.Caption = "IDMatCat"
        Me.GridColumnIdItemCategory.FieldName = "id_mat_cat"
        Me.GridColumnIdItemCategory.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnIdItemCategory.ImageAlignment = System.Drawing.StringAlignment.Center
        Me.GridColumnIdItemCategory.Name = "GridColumnIdItemCategory"
        Me.GridColumnIdItemCategory.Width = 30
        '
        'GridColumnMasterItemCategory
        '
        Me.GridColumnMasterItemCategory.Caption = "Material Category"
        Me.GridColumnMasterItemCategory.FieldName = "mat_cat"
        Me.GridColumnMasterItemCategory.Name = "GridColumnMasterItemCategory"
        Me.GridColumnMasterItemCategory.Visible = True
        Me.GridColumnMasterItemCategory.VisibleIndex = 0
        Me.GridColumnMasterItemCategory.Width = 205
        '
        'FormMasterRawMaterialCat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 368)
        Me.Controls.Add(Me.GridControlMasterItemCategory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterRawMaterialCat"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Category"
        Me.TopMost = True
        CType(Me.GridControlMasterItemCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewMasterItemCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControlMasterItemCategory As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewMasterItemCategory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdItemCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMasterItemCategory As DevExpress.XtraGrid.Columns.GridColumn
End Class
