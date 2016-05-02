<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCompanyCategory
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
        Me.GCCompanyCategory = New DevExpress.XtraGrid.GridControl
        Me.GVCompanyCategory = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdCompCat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.comp_cat_name = New DevExpress.XtraGrid.Columns.GridColumn
        Me.description = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCCompanyCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompanyCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCCompanyCategory
        '
        Me.GCCompanyCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompanyCategory.Location = New System.Drawing.Point(0, 0)
        Me.GCCompanyCategory.MainView = Me.GVCompanyCategory
        Me.GCCompanyCategory.Name = "GCCompanyCategory"
        Me.GCCompanyCategory.Size = New System.Drawing.Size(609, 335)
        Me.GCCompanyCategory.TabIndex = 2
        Me.GCCompanyCategory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompanyCategory})
        '
        'GVCompanyCategory
        '
        Me.GVCompanyCategory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdCompCat, Me.comp_cat_name, Me.description})
        Me.GVCompanyCategory.GridControl = Me.GCCompanyCategory
        Me.GVCompanyCategory.Name = "GVCompanyCategory"
        Me.GVCompanyCategory.OptionsBehavior.Editable = False
        Me.GVCompanyCategory.OptionsView.ShowGroupPanel = False
        '
        'ColIdCompCat
        '
        Me.ColIdCompCat.Caption = "ID"
        Me.ColIdCompCat.FieldName = "id_comp_cat"
        Me.ColIdCompCat.Name = "ColIdCompCat"
        '
        'comp_cat_name
        '
        Me.comp_cat_name.Caption = "Category"
        Me.comp_cat_name.FieldName = "comp_cat_name"
        Me.comp_cat_name.MaxWidth = 200
        Me.comp_cat_name.Name = "comp_cat_name"
        Me.comp_cat_name.Visible = True
        Me.comp_cat_name.VisibleIndex = 0
        Me.comp_cat_name.Width = 50
        '
        'description
        '
        Me.description.Caption = "Description"
        Me.description.FieldName = "description"
        Me.description.Name = "description"
        Me.description.Visible = True
        Me.description.VisibleIndex = 1
        '
        'FormMasterCompanyCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 335)
        Me.Controls.Add(Me.GCCompanyCategory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCompanyCategory"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company Category"
        CType(Me.GCCompanyCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompanyCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCCompanyCategory As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompanyCategory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdCompCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents comp_cat_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents description As DevExpress.XtraGrid.Columns.GridColumn
End Class
