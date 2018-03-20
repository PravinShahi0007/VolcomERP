<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterAsset
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
        Me.GCAsset = New DevExpress.XtraGrid.GridControl()
        Me.GVAsset = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColumnIdCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCodeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCodeDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEPil = New DevExpress.XtraEditors.LookUpEdit()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        CType(Me.GCAsset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAsset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCAsset
        '
        Me.GCAsset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAsset.Location = New System.Drawing.Point(0, 42)
        Me.GCAsset.MainView = Me.GVAsset
        Me.GCAsset.Name = "GCAsset"
        Me.GCAsset.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit3, Me.RepositoryItemCheckEdit4})
        Me.GCAsset.Size = New System.Drawing.Size(1154, 445)
        Me.GCAsset.TabIndex = 2
        Me.GCAsset.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAsset})
        '
        'GVAsset
        '
        Me.GVAsset.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdCode, Me.GridColumn2, Me.GridColumn1, Me.GCCodeName, Me.GCCodeDesc, Me.GridColumn11, Me.GridColumn10, Me.GridColumn9, Me.GridColumn3, Me.GridColumn8, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVAsset.GridControl = Me.GCAsset
        Me.GVAsset.Name = "GVAsset"
        Me.GVAsset.OptionsBehavior.Editable = False
        Me.GVAsset.OptionsView.ShowGroupPanel = False
        '
        'ColumnIdCode
        '
        Me.ColumnIdCode.Caption = "Id Code"
        Me.ColumnIdCode.FieldName = "id_asset"
        Me.ColumnIdCode.Name = "ColumnIdCode"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Old Code"
        Me.GridColumn2.FieldName = "asset_code_old"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 73
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Vendor SKU"
        Me.GridColumn1.FieldName = "vendor_code"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 73
        '
        'GCCodeName
        '
        Me.GCCodeName.Caption = "Code"
        Me.GCCodeName.FieldName = "asset_code"
        Me.GCCodeName.Name = "GCCodeName"
        Me.GCCodeName.Visible = True
        Me.GCCodeName.VisibleIndex = 1
        Me.GCCodeName.Width = 128
        '
        'GCCodeDesc
        '
        Me.GCCodeDesc.Caption = "Description"
        Me.GCCodeDesc.FieldName = "asset_desc"
        Me.GCCodeDesc.Name = "GCCodeDesc"
        Me.GCCodeDesc.Visible = True
        Me.GCCodeDesc.VisibleIndex = 4
        Me.GCCodeDesc.Width = 204
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Orign Departement"
        Me.GridColumn11.FieldName = "departement"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 5
        Me.GridColumn11.Width = 72
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Orign User"
        Me.GridColumn10.FieldName = "employee_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 6
        Me.GridColumn10.Width = 72
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Category"
        Me.GridColumn9.FieldName = "asset_cat"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        Me.GridColumn9.Width = 72
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "PO No"
        Me.GridColumn3.FieldName = "po_no"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 7
        Me.GridColumn3.Width = 73
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "PO Date"
        Me.GridColumn8.FieldName = "po_date"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 8
        Me.GridColumn8.Width = 72
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "PO Value"
        Me.GridColumn4.FieldName = "po_value"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 9
        Me.GridColumn4.Width = 72
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Rec Value"
        Me.GridColumn5.FieldName = "rec_value"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 11
        Me.GridColumn5.Width = 72
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Rec Date"
        Me.GridColumn6.FieldName = "rec_date"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 10
        Me.GridColumn6.Width = 72
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Age (Month)"
        Me.GridColumn7.FieldName = "age"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 12
        Me.GridColumn7.Width = 81
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
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
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.DEEnd)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.LEPil)
        Me.PanelControl1.Controls.Add(Me.DEStart)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1154, 42)
        Me.PanelControl1.TabIndex = 3
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(500, 10)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(75, 23)
        Me.BView.TabIndex = 18
        Me.BView.Text = "View"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(345, 12)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Size = New System.Drawing.Size(149, 20)
        Me.DEEnd.TabIndex = 17
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(335, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl1.TabIndex = 16
        Me.LabelControl1.Text = "-"
        '
        'LEPil
        '
        Me.LEPil.Location = New System.Drawing.Point(12, 12)
        Me.LEPil.Name = "LEPil"
        Me.LEPil.Properties.Appearance.Options.UseTextOptions = True
        Me.LEPil.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEPil.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEPil.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEPil.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEPil.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEPil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPil.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_pil", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("pil_name", "Option")})
        Me.LEPil.Properties.NullText = ""
        Me.LEPil.Properties.ShowFooter = False
        Me.LEPil.Size = New System.Drawing.Size(162, 20)
        Me.LEPil.TabIndex = 15
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(180, 12)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(149, 20)
        Me.DEStart.TabIndex = 14
        '
        'FormMasterAsset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 487)
        Me.Controls.Add(Me.GCAsset)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterAsset"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List Asset"
        CType(Me.GCAsset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAsset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCAsset As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAsset As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCodeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCodeDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPil As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
End Class
