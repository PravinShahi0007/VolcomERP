<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpUniSizeMain
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
        Me.components = New System.ComponentModel.Container()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnTemplateName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsex = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass_member = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MEClass = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MESize = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumnSelectedSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MESize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.MEClass, Me.MESize})
        Me.GCData.Size = New System.Drawing.Size(699, 394)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnTemplateName, Me.GridColumnsex, Me.GridColumnclass_member, Me.GridColumnSize, Me.GridColumnSelectedSize})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.RowAutoHeight = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        Me.GVData.RowHeight = 65
        '
        'GridColumnTemplateName
        '
        Me.GridColumnTemplateName.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTemplateName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnTemplateName.Caption = "Group"
        Me.GridColumnTemplateName.FieldName = "template_name"
        Me.GridColumnTemplateName.Name = "GridColumnTemplateName"
        Me.GridColumnTemplateName.OptionsColumn.AllowEdit = False
        Me.GridColumnTemplateName.Visible = True
        Me.GridColumnTemplateName.VisibleIndex = 0
        Me.GridColumnTemplateName.Width = 93
        '
        'GridColumnsex
        '
        Me.GridColumnsex.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnsex.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnsex.Caption = "Sex"
        Me.GridColumnsex.FieldName = "sex"
        Me.GridColumnsex.Name = "GridColumnsex"
        Me.GridColumnsex.OptionsColumn.AllowEdit = False
        Me.GridColumnsex.Visible = True
        Me.GridColumnsex.VisibleIndex = 1
        '
        'GridColumnclass_member
        '
        Me.GridColumnclass_member.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnclass_member.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnclass_member.Caption = "Class"
        Me.GridColumnclass_member.ColumnEdit = Me.MEClass
        Me.GridColumnclass_member.FieldName = "class_member"
        Me.GridColumnclass_member.Name = "GridColumnclass_member"
        Me.GridColumnclass_member.OptionsColumn.AllowEdit = False
        Me.GridColumnclass_member.Visible = True
        Me.GridColumnclass_member.VisibleIndex = 2
        Me.GridColumnclass_member.Width = 138
        '
        'MEClass
        '
        Me.MEClass.Name = "MEClass"
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnSize.Caption = "Size Chart"
        Me.GridColumnSize.ColumnEdit = Me.MESize
        Me.GridColumnSize.FieldName = "size_member"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 123
        '
        'MESize
        '
        Me.MESize.Name = "MESize"
        '
        'GridColumnSelectedSize
        '
        Me.GridColumnSelectedSize.Caption = "Selected Size"
        Me.GridColumnSelectedSize.FieldName = "selected_size"
        Me.GridColumnSelectedSize.Name = "GridColumnSelectedSize"
        Me.GridColumnSelectedSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSelectedSize.Visible = True
        Me.GridColumnSelectedSize.VisibleIndex = 4
        Me.GridColumnSelectedSize.Width = 125
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddSizeToolStripMenuItem, Me.ResetSizeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 70)
        '
        'AddSizeToolStripMenuItem
        '
        Me.AddSizeToolStripMenuItem.Name = "AddSizeToolStripMenuItem"
        Me.AddSizeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddSizeToolStripMenuItem.Text = "Add Size"
        '
        'ResetSizeToolStripMenuItem
        '
        Me.ResetSizeToolStripMenuItem.Name = "ResetSizeToolStripMenuItem"
        Me.ResetSizeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ResetSizeToolStripMenuItem.Text = "Reset Size"
        '
        'FormEmpUniSizeMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 394)
        Me.Controls.Add(Me.GCData)
        Me.Name = "FormEmpUniSizeMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Size Profile - "
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MESize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnTemplateName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsex As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass_member As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MEClass As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents MESize As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumnSelectedSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AddSizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetSizeToolStripMenuItem As ToolStripMenuItem
End Class
