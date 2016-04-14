<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterOVH
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
        Me.GCOVH = New DevExpress.XtraGrid.GridControl()
        Me.GVOVH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_ovh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.overhead_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.overhead = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEditOVH = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnTypeOVH = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCOVH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOVH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEditOVH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCOVH
        '
        Me.GCOVH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOVH.Location = New System.Drawing.Point(0, 0)
        Me.GCOVH.MainView = Me.GVOVH
        Me.GCOVH.Name = "GCOVH"
        Me.GCOVH.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEditOVH})
        Me.GCOVH.Size = New System.Drawing.Size(654, 238)
        Me.GCOVH.TabIndex = 1
        Me.GCOVH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOVH})
        '
        'GVOVH
        '
        Me.GVOVH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_ovh, Me.GridColumnTypeOVH, Me.overhead_code, Me.overhead, Me.GridColumnUom})
        Me.GVOVH.GridControl = Me.GCOVH
        Me.GVOVH.Name = "GVOVH"
        Me.GVOVH.OptionsBehavior.Editable = False
        Me.GVOVH.OptionsView.ShowGroupPanel = False
        '
        'id_ovh
        '
        Me.id_ovh.Caption = "ID"
        Me.id_ovh.FieldName = "id_ovh"
        Me.id_ovh.Name = "id_ovh"
        '
        'overhead_code
        '
        Me.overhead_code.Caption = "Code"
        Me.overhead_code.FieldName = "overhead_code"
        Me.overhead_code.Name = "overhead_code"
        Me.overhead_code.Visible = True
        Me.overhead_code.VisibleIndex = 0
        Me.overhead_code.Width = 145
        '
        'overhead
        '
        Me.overhead.Caption = "Overhead"
        Me.overhead.FieldName = "overhead"
        Me.overhead.Name = "overhead"
        Me.overhead.Visible = True
        Me.overhead.VisibleIndex = 2
        Me.overhead.Width = 150
        '
        'GridColumnUom
        '
        Me.GridColumnUom.Caption = "Unit Of Measure"
        Me.GridColumnUom.FieldName = "uom"
        Me.GridColumnUom.Name = "GridColumnUom"
        Me.GridColumnUom.Visible = True
        Me.GridColumnUom.VisibleIndex = 3
        Me.GridColumnUom.Width = 150
        '
        'RepositoryItemCheckEditOVH
        '
        Me.RepositoryItemCheckEditOVH.AutoHeight = False
        Me.RepositoryItemCheckEditOVH.Name = "RepositoryItemCheckEditOVH"
        Me.RepositoryItemCheckEditOVH.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEditOVH.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GridColumnTypeOVH
        '
        Me.GridColumnTypeOVH.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTypeOVH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnTypeOVH.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTypeOVH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnTypeOVH.Caption = "Category"
        Me.GridColumnTypeOVH.FieldName = "ovh_cat"
        Me.GridColumnTypeOVH.Name = "GridColumnTypeOVH"
        Me.GridColumnTypeOVH.Visible = True
        Me.GridColumnTypeOVH.VisibleIndex = 1
        '
        'FormMasterOVH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 238)
        Me.Controls.Add(Me.GCOVH)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterOVH"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overhead"
        CType(Me.GCOVH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOVH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEditOVH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCOVH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOVH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_ovh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents overhead_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents overhead As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEditOVH As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnUom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTypeOVH As DevExpress.XtraGrid.Columns.GridColumn
End Class
