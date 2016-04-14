<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterProductMulti
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.GCCodeDetail = New DevExpress.XtraGrid.GridControl
        Me.GVCodeDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumnIdCodeDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnCodeName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnDisplayName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSelect = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCCodeDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCodeDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.CheckEdit1)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 367)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(746, 37)
        Me.PanelControl1.TabIndex = 0
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(7, 9)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Select All Size"
        Me.CheckEdit1.Size = New System.Drawing.Size(102, 19)
        Me.CheckEdit1.TabIndex = 1
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Location = New System.Drawing.Point(669, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 33)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "Choose"
        '
        'GCCodeDetail
        '
        Me.GCCodeDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCodeDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCCodeDetail.MainView = Me.GVCodeDetail
        Me.GCCodeDetail.Name = "GCCodeDetail"
        Me.GCCodeDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemCheckEdit1})
        Me.GCCodeDetail.Size = New System.Drawing.Size(746, 367)
        Me.GCCodeDetail.TabIndex = 7
        Me.GCCodeDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCodeDetail})
        '
        'GVCodeDetail
        '
        Me.GVCodeDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdCodeDet, Me.ColumnCode, Me.ColumnCodeName, Me.ColumnDisplayName, Me.GridColumnSelect})
        Me.GVCodeDetail.GridControl = Me.GCCodeDetail
        Me.GVCodeDetail.Name = "GVCodeDetail"
        Me.GVCodeDetail.OptionsView.ShowGroupPanel = False
        '
        'ColumnIdCodeDet
        '
        Me.ColumnIdCodeDet.Caption = "Id Code Detail"
        Me.ColumnIdCodeDet.FieldName = "id_code_detail"
        Me.ColumnIdCodeDet.Name = "ColumnIdCodeDet"
        Me.ColumnIdCodeDet.OptionsColumn.ReadOnly = True
        '
        'ColumnCode
        '
        Me.ColumnCode.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColumnCode.AppearanceCell.Options.UseFont = True
        Me.ColumnCode.AppearanceCell.Options.UseTextOptions = True
        Me.ColumnCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColumnCode.Caption = "Code"
        Me.ColumnCode.FieldName = "code"
        Me.ColumnCode.Name = "ColumnCode"
        Me.ColumnCode.OptionsColumn.ReadOnly = True
        Me.ColumnCode.Visible = True
        Me.ColumnCode.VisibleIndex = 0
        Me.ColumnCode.Width = 182
        '
        'ColumnCodeName
        '
        Me.ColumnCodeName.Caption = "Name"
        Me.ColumnCodeName.FieldName = "code_detail_name"
        Me.ColumnCodeName.Name = "ColumnCodeName"
        Me.ColumnCodeName.OptionsColumn.ReadOnly = True
        Me.ColumnCodeName.Visible = True
        Me.ColumnCodeName.VisibleIndex = 2
        Me.ColumnCodeName.Width = 335
        '
        'ColumnDisplayName
        '
        Me.ColumnDisplayName.Caption = "Printed Name"
        Me.ColumnDisplayName.FieldName = "display_name"
        Me.ColumnDisplayName.Name = "ColumnDisplayName"
        Me.ColumnDisplayName.OptionsColumn.ReadOnly = True
        Me.ColumnDisplayName.Visible = True
        Me.ColumnDisplayName.VisibleIndex = 1
        Me.ColumnDisplayName.Width = 136
        '
        'GridColumnSelect
        '
        Me.GridColumnSelect.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.Caption = "Select"
        Me.GridColumnSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnSelect.FieldName = "is_select"
        Me.GridColumnSelect.Name = "GridColumnSelect"
        Me.GridColumnSelect.Visible = True
        Me.GridColumnSelect.VisibleIndex = 3
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit2.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'FormMasterProductMulti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 404)
        Me.Controls.Add(Me.GCCodeDetail)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormMasterProductMulti"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose Size"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCCodeDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCodeDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCCodeDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCodeDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdCodeDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCodeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
