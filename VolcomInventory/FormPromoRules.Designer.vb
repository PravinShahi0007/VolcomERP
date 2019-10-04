<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPromoRules
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPromoRules))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCRules = New DevExpress.XtraGrid.GridControl()
        Me.GVRules = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_rules = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnlimit_value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCStore = New DevExpress.XtraGrid.GridControl()
        Me.GVStore = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_outlet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnoutlet_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnActive = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCRules, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRules, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(771, 476)
        Me.SplitContainerControl1.SplitterPosition = 216
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCRules)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(771, 216)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Rules"
        '
        'GCRules
        '
        Me.GCRules.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRules.Location = New System.Drawing.Point(2, 20)
        Me.GCRules.MainView = Me.GVRules
        Me.GCRules.Name = "GCRules"
        Me.GCRules.Size = New System.Drawing.Size(767, 194)
        Me.GCRules.TabIndex = 0
        Me.GCRules.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRules})
        '
        'GVRules
        '
        Me.GVRules.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_rules, Me.GridColumnid_design_cat, Me.GridColumndesign_cat, Me.GridColumnlimit_value, Me.GridColumnid_product, Me.GridColumncode, Me.GridColumnname, Me.GridColumnSize})
        Me.GVRules.GridControl = Me.GCRules
        Me.GVRules.Name = "GVRules"
        Me.GVRules.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRules.OptionsBehavior.Editable = False
        Me.GVRules.OptionsFind.AlwaysVisible = True
        Me.GVRules.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_rules
        '
        Me.GridColumnid_rules.Caption = "id_rules"
        Me.GridColumnid_rules.FieldName = "id_rules"
        Me.GridColumnid_rules.Name = "GridColumnid_rules"
        '
        'GridColumnid_design_cat
        '
        Me.GridColumnid_design_cat.Caption = "id_design_cat"
        Me.GridColumnid_design_cat.FieldName = "id_design_cat"
        Me.GridColumnid_design_cat.Name = "GridColumnid_design_cat"
        '
        'GridColumndesign_cat
        '
        Me.GridColumndesign_cat.Caption = "Product Status"
        Me.GridColumndesign_cat.FieldName = "design_cat"
        Me.GridColumndesign_cat.Name = "GridColumndesign_cat"
        Me.GridColumndesign_cat.Visible = True
        Me.GridColumndesign_cat.VisibleIndex = 2
        '
        'GridColumnlimit_value
        '
        Me.GridColumnlimit_value.Caption = "Limit Value"
        Me.GridColumnlimit_value.DisplayFormat.FormatString = "N0"
        Me.GridColumnlimit_value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnlimit_value.FieldName = "limit_value"
        Me.GridColumnlimit_value.Name = "GridColumnlimit_value"
        Me.GridColumnlimit_value.Visible = True
        Me.GridColumnlimit_value.VisibleIndex = 4
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "id_product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 0
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Style"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 1
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCStore)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(771, 255)
        Me.GroupControl2.TabIndex = 0
        Me.GroupControl2.Text = "Store"
        '
        'GCStore
        '
        Me.GCStore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCStore.Location = New System.Drawing.Point(2, 20)
        Me.GCStore.MainView = Me.GVStore
        Me.GCStore.Name = "GCStore"
        Me.GCStore.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCStore.Size = New System.Drawing.Size(767, 233)
        Me.GCStore.TabIndex = 1
        Me.GCStore.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVStore})
        '
        'GVStore
        '
        Me.GVStore.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_outlet, Me.GridColumnoutlet_name, Me.GridColumnActive})
        Me.GVStore.GridControl = Me.GCStore
        Me.GVStore.Name = "GVStore"
        Me.GVStore.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVStore.OptionsFind.AlwaysVisible = True
        Me.GVStore.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_outlet
        '
        Me.GridColumnid_outlet.Caption = "id_outlet"
        Me.GridColumnid_outlet.FieldName = "id_outlet"
        Me.GridColumnid_outlet.Name = "GridColumnid_outlet"
        '
        'GridColumnoutlet_name
        '
        Me.GridColumnoutlet_name.Caption = "Store"
        Me.GridColumnoutlet_name.FieldName = "outlet_name"
        Me.GridColumnoutlet_name.Name = "GridColumnoutlet_name"
        Me.GridColumnoutlet_name.Visible = True
        Me.GridColumnoutlet_name.VisibleIndex = 0
        '
        'GridColumnActive
        '
        Me.GridColumnActive.Caption = "Active"
        Me.GridColumnActive.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnActive.FieldName = "is_select"
        Me.GridColumnActive.Name = "GridColumnActive"
        Me.GridColumnActive.Visible = True
        Me.GridColumnActive.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.PictureChecked = CType(resources.GetObject("RepositoryItemCheckEdit1.PictureChecked"), System.Drawing.Image)
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        '
        'FormPromoRules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 476)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "FormPromoRules"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Promo Product Rules"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCRules, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRules, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCRules As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRules As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCStore As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVStore As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_rules As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_design_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnlimit_value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_outlet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnoutlet_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnActive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
End Class
