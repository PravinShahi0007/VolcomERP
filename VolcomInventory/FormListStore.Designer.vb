<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListStore
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
        Me.GCCompany = New DevExpress.XtraGrid.GridControl()
        Me.GVCompany = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CompanyCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.address_primary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.sub_district = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name_display = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active_company = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnho_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnregion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnarea = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncommerce_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnemployee_name = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCCompany
        '
        Me.GCCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompany.Location = New System.Drawing.Point(0, 0)
        Me.GCCompany.MainView = Me.GVCompany
        Me.GCCompany.Name = "GCCompany"
        Me.GCCompany.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.is_active_company, Me.RepositoryItemCheckEdit1})
        Me.GCCompany.Size = New System.Drawing.Size(1100, 556)
        Me.GCCompany.TabIndex = 4
        Me.GCCompany.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompany})
        '
        'GVCompany
        '
        Me.GVCompany.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_company, Me.CompanyCode, Me.company, Me.address_primary, Me.sub_district, Me.is_active, Me.Category, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GCStatus, Me.GridColumncomp_name_display, Me.GridColumnho_name, Me.GridColumncomp_group, Me.GridColumncomp_group_desc, Me.GridColumncountry, Me.GridColumnregion, Me.GridColumnstate, Me.GridColumncity, Me.GridColumnarea, Me.GridColumnstore_type, Me.GridColumncommerce_type, Me.GridColumnemployee_name})
        Me.GVCompany.GridControl = Me.GCCompany
        Me.GVCompany.Name = "GVCompany"
        Me.GVCompany.OptionsBehavior.Editable = False
        Me.GVCompany.OptionsView.ColumnAutoWidth = False
        Me.GVCompany.OptionsView.ShowGroupPanel = False
        '
        'id_company
        '
        Me.id_company.Caption = "ID"
        Me.id_company.FieldName = "id_comp"
        Me.id_company.Name = "id_company"
        '
        'CompanyCode
        '
        Me.CompanyCode.Caption = "Code"
        Me.CompanyCode.FieldName = "comp_number"
        Me.CompanyCode.Name = "CompanyCode"
        Me.CompanyCode.Visible = True
        Me.CompanyCode.VisibleIndex = 0
        Me.CompanyCode.Width = 79
        '
        'company
        '
        Me.company.Caption = "Store"
        Me.company.FieldName = "comp_name"
        Me.company.Name = "company"
        Me.company.Visible = True
        Me.company.VisibleIndex = 2
        Me.company.Width = 105
        '
        'address_primary
        '
        Me.address_primary.Caption = "Address"
        Me.address_primary.FieldName = "address_primary"
        Me.address_primary.Name = "address_primary"
        Me.address_primary.Visible = True
        Me.address_primary.VisibleIndex = 5
        Me.address_primary.Width = 289
        '
        'sub_district
        '
        Me.sub_district.Caption = "Sub District"
        Me.sub_district.FieldName = "sub_district"
        Me.sub_district.Name = "sub_district"
        Me.sub_district.Visible = True
        Me.sub_district.VisibleIndex = 11
        '
        'is_active
        '
        Me.is_active.AppearanceHeader.Options.UseTextOptions = True
        Me.is_active.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.is_active.Caption = "Active"
        Me.is_active.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.is_active.FieldName = "is_active"
        Me.is_active.Name = "is_active"
        Me.is_active.Width = 52
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Category
        '
        Me.Category.Caption = "Category"
        Me.Category.FieldName = "company_category"
        Me.Category.Name = "Category"
        Me.Category.Width = 80
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Contact Person"
        Me.GridColumn1.FieldName = "contact_person"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 12
        Me.GridColumn1.Width = 91
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Contact Number"
        Me.GridColumn2.FieldName = "contact_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 13
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Contact Email"
        Me.GridColumn3.FieldName = "contact_email"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 14
        '
        'GCStatus
        '
        Me.GCStatus.Caption = "Status"
        Me.GCStatus.FieldName = "comp_status"
        Me.GCStatus.Name = "GCStatus"
        Me.GCStatus.Visible = True
        Me.GCStatus.VisibleIndex = 19
        '
        'GridColumncomp_name_display
        '
        Me.GridColumncomp_name_display.Caption = "Short Name"
        Me.GridColumncomp_name_display.FieldName = "comp_display_name"
        Me.GridColumncomp_name_display.Name = "GridColumncomp_name_display"
        Me.GridColumncomp_name_display.Visible = True
        Me.GridColumncomp_name_display.VisibleIndex = 1
        '
        'is_active_company
        '
        Me.is_active_company.AutoHeight = False
        Me.is_active_company.DisplayValueChecked = "1"
        Me.is_active_company.DisplayValueUnchecked = "0"
        Me.is_active_company.Name = "is_active_company"
        '
        'GridColumnho_name
        '
        Me.GridColumnho_name.Caption = "Head Office"
        Me.GridColumnho_name.FieldName = "ho_name"
        Me.GridColumnho_name.Name = "GridColumnho_name"
        Me.GridColumnho_name.Visible = True
        Me.GridColumnho_name.VisibleIndex = 15
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 3
        '
        'GridColumncomp_group_desc
        '
        Me.GridColumncomp_group_desc.Caption = "Group Description"
        Me.GridColumncomp_group_desc.FieldName = "comp_group_desc"
        Me.GridColumncomp_group_desc.Name = "GridColumncomp_group_desc"
        Me.GridColumncomp_group_desc.Visible = True
        Me.GridColumncomp_group_desc.VisibleIndex = 4
        '
        'GridColumncountry
        '
        Me.GridColumncountry.Caption = "Country"
        Me.GridColumncountry.FieldName = "country"
        Me.GridColumncountry.Name = "GridColumncountry"
        Me.GridColumncountry.Visible = True
        Me.GridColumncountry.VisibleIndex = 6
        '
        'GridColumnregion
        '
        Me.GridColumnregion.Caption = "Region"
        Me.GridColumnregion.FieldName = "region"
        Me.GridColumnregion.Name = "GridColumnregion"
        Me.GridColumnregion.Visible = True
        Me.GridColumnregion.VisibleIndex = 7
        '
        'GridColumnstate
        '
        Me.GridColumnstate.Caption = "State"
        Me.GridColumnstate.FieldName = "state"
        Me.GridColumnstate.Name = "GridColumnstate"
        Me.GridColumnstate.Visible = True
        Me.GridColumnstate.VisibleIndex = 8
        '
        'GridColumncity
        '
        Me.GridColumncity.Caption = "City"
        Me.GridColumncity.FieldName = "city"
        Me.GridColumncity.Name = "GridColumncity"
        Me.GridColumncity.Visible = True
        Me.GridColumncity.VisibleIndex = 9
        '
        'GridColumnarea
        '
        Me.GridColumnarea.Caption = "Area"
        Me.GridColumnarea.FieldName = "area"
        Me.GridColumnarea.Name = "GridColumnarea"
        Me.GridColumnarea.Visible = True
        Me.GridColumnarea.VisibleIndex = 10
        '
        'GridColumnstore_type
        '
        Me.GridColumnstore_type.Caption = "Store Type"
        Me.GridColumnstore_type.FieldName = "store_type"
        Me.GridColumnstore_type.Name = "GridColumnstore_type"
        Me.GridColumnstore_type.Visible = True
        Me.GridColumnstore_type.VisibleIndex = 16
        '
        'GridColumncommerce_type
        '
        Me.GridColumncommerce_type.Caption = "Commerce Typ"
        Me.GridColumncommerce_type.FieldName = "commerce_type"
        Me.GridColumncommerce_type.Name = "GridColumncommerce_type"
        Me.GridColumncommerce_type.Visible = True
        Me.GridColumncommerce_type.VisibleIndex = 17
        '
        'GridColumnemployee_name
        '
        Me.GridColumnemployee_name.Caption = "Sales Rep."
        Me.GridColumnemployee_name.FieldName = "employee_name"
        Me.GridColumnemployee_name.Name = "GridColumnemployee_name"
        Me.GridColumnemployee_name.Visible = True
        Me.GridColumnemployee_name.VisibleIndex = 18
        '
        'FormListStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 556)
        Me.Controls.Add(Me.GCCompany)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormListStore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List Store"
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCCompany As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompany As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CompanyCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents address_primary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents sub_district As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents is_active As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents is_active_company As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumncomp_name_display As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnho_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnregion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnarea As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstore_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncommerce_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnemployee_name As DevExpress.XtraGrid.Columns.GridColumn
End Class
