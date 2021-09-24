<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVMStoreDisplay
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnis_select = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_active = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_active_view = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp_groupx = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_groupX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnaddress_primary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnarea = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnemployee_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnlog_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore_type = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(993, 594)
        Me.GCData.TabIndex = 3
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnis_select, Me.GridColumnid_comp, Me.GridColumnis_active, Me.GridColumnis_active_view, Me.GridColumncomp_number, Me.GridColumncomp_name, Me.GridColumnid_comp_groupx, Me.GridColumncomp_groupX, Me.GridColumncomp_group_desc, Me.GridColumnaddress_primary, Me.GridColumnarea, Me.GridColumncity, Me.GridColumnstate, Me.GridColumnemployee_name, Me.GridColumnlog_date, Me.GridColumnstore_type})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnis_select
        '
        Me.GridColumnis_select.Caption = "Select"
        Me.GridColumnis_select.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnis_select.FieldName = "is_select"
        Me.GridColumnis_select.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnis_select.Name = "GridColumnis_select"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnid_comp
        '
        Me.GridColumnid_comp.Caption = "id_comp"
        Me.GridColumnid_comp.FieldName = "id_comp"
        Me.GridColumnid_comp.Name = "GridColumnid_comp"
        Me.GridColumnid_comp.OptionsColumn.ReadOnly = True
        '
        'GridColumnis_active
        '
        Me.GridColumnis_active.Caption = "is_active"
        Me.GridColumnis_active.FieldName = "is_active"
        Me.GridColumnis_active.Name = "GridColumnis_active"
        Me.GridColumnis_active.OptionsColumn.ReadOnly = True
        '
        'GridColumnis_active_view
        '
        Me.GridColumnis_active_view.Caption = "Status"
        Me.GridColumnis_active_view.FieldName = "is_active_view"
        Me.GridColumnis_active_view.Name = "GridColumnis_active_view"
        Me.GridColumnis_active_view.OptionsColumn.ReadOnly = True
        Me.GridColumnis_active_view.UnboundExpression = "Iif([is_active] = 1, 'Active', 'Not Active')"
        Me.GridColumnis_active_view.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumnis_active_view.Visible = True
        Me.GridColumnis_active_view.VisibleIndex = 9
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Account No."
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.OptionsColumn.ReadOnly = True
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 1
        '
        'GridColumncomp_name
        '
        Me.GridColumncomp_name.Caption = "Account Description"
        Me.GridColumncomp_name.FieldName = "comp_name"
        Me.GridColumncomp_name.Name = "GridColumncomp_name"
        Me.GridColumncomp_name.OptionsColumn.ReadOnly = True
        Me.GridColumncomp_name.Visible = True
        Me.GridColumncomp_name.VisibleIndex = 0
        Me.GridColumncomp_name.Width = 118
        '
        'GridColumnid_comp_groupx
        '
        Me.GridColumnid_comp_groupx.Caption = "id_comp_group"
        Me.GridColumnid_comp_groupx.FieldName = "id_comp_group"
        Me.GridColumnid_comp_groupx.Name = "GridColumnid_comp_groupx"
        Me.GridColumnid_comp_groupx.OptionsColumn.ReadOnly = True
        '
        'GridColumncomp_groupX
        '
        Me.GridColumncomp_groupX.Caption = "Group Code"
        Me.GridColumncomp_groupX.FieldName = "comp_group"
        Me.GridColumncomp_groupX.Name = "GridColumncomp_groupX"
        Me.GridColumncomp_groupX.OptionsColumn.ReadOnly = True
        Me.GridColumncomp_groupX.Visible = True
        Me.GridColumncomp_groupX.VisibleIndex = 2
        '
        'GridColumncomp_group_desc
        '
        Me.GridColumncomp_group_desc.Caption = "Group"
        Me.GridColumncomp_group_desc.FieldName = "comp_group_desc"
        Me.GridColumncomp_group_desc.Name = "GridColumncomp_group_desc"
        Me.GridColumncomp_group_desc.OptionsColumn.ReadOnly = True
        Me.GridColumncomp_group_desc.Visible = True
        Me.GridColumncomp_group_desc.VisibleIndex = 3
        '
        'GridColumnaddress_primary
        '
        Me.GridColumnaddress_primary.Caption = "Address"
        Me.GridColumnaddress_primary.FieldName = "address_primary"
        Me.GridColumnaddress_primary.Name = "GridColumnaddress_primary"
        Me.GridColumnaddress_primary.OptionsColumn.ReadOnly = True
        Me.GridColumnaddress_primary.Visible = True
        Me.GridColumnaddress_primary.VisibleIndex = 4
        '
        'GridColumnarea
        '
        Me.GridColumnarea.Caption = "Area"
        Me.GridColumnarea.FieldName = "area"
        Me.GridColumnarea.Name = "GridColumnarea"
        Me.GridColumnarea.OptionsColumn.ReadOnly = True
        Me.GridColumnarea.Visible = True
        Me.GridColumnarea.VisibleIndex = 5
        '
        'GridColumncity
        '
        Me.GridColumncity.Caption = "City"
        Me.GridColumncity.FieldName = "city"
        Me.GridColumncity.Name = "GridColumncity"
        Me.GridColumncity.OptionsColumn.ReadOnly = True
        Me.GridColumncity.Visible = True
        Me.GridColumncity.VisibleIndex = 6
        '
        'GridColumnstate
        '
        Me.GridColumnstate.Caption = "State"
        Me.GridColumnstate.FieldName = "state"
        Me.GridColumnstate.Name = "GridColumnstate"
        Me.GridColumnstate.OptionsColumn.ReadOnly = True
        Me.GridColumnstate.Visible = True
        Me.GridColumnstate.VisibleIndex = 7
        '
        'GridColumnemployee_name
        '
        Me.GridColumnemployee_name.Caption = "Sales Rep."
        Me.GridColumnemployee_name.FieldName = "employee_name"
        Me.GridColumnemployee_name.Name = "GridColumnemployee_name"
        Me.GridColumnemployee_name.OptionsColumn.ReadOnly = True
        '
        'GridColumnlog_date
        '
        Me.GridColumnlog_date.Caption = "Last Updated"
        Me.GridColumnlog_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnlog_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnlog_date.FieldName = "log_date"
        Me.GridColumnlog_date.Name = "GridColumnlog_date"
        Me.GridColumnlog_date.OptionsColumn.ReadOnly = True
        '
        'GridColumnstore_type
        '
        Me.GridColumnstore_type.Caption = "Store Type"
        Me.GridColumnstore_type.FieldName = "store_type"
        Me.GridColumnstore_type.Name = "GridColumnstore_type"
        Me.GridColumnstore_type.Visible = True
        Me.GridColumnstore_type.VisibleIndex = 8
        '
        'FormVMStoreDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 594)
        Me.Controls.Add(Me.GCData)
        Me.MinimizeBox = False
        Me.Name = "FormVMStoreDisplay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Store Display"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_active As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_active_view As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp_groupx As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_groupX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnaddress_primary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnarea As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnemployee_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnlog_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstore_type As DevExpress.XtraGrid.Columns.GridColumn
End Class
