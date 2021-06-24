<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCompany
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
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAddress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSubDistrict = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCPNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCPEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active_company = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnShortName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProvince = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsland = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMasterArea = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreType = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.GCCompany.Size = New System.Drawing.Size(1008, 619)
        Me.GCCompany.TabIndex = 3
        Me.GCCompany.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompany})
        '
        'GVCompany
        '
        Me.GVCompany.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_company, Me.GridColumnCode, Me.GridColumnShortName, Me.company, Me.GridColumnAddress, Me.GridColumnSubDistrict, Me.is_active, Me.Category, Me.GridColumnCP, Me.GridColumnCPNumber, Me.GridColumnCPEmail, Me.GCStatus, Me.GridColumnCity, Me.GridColumnProvince, Me.GridColumnIsland, Me.GridColumnMasterArea, Me.GridColumnStoreType})
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
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "comp_number"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        Me.GridColumnCode.Width = 79
        '
        'company
        '
        Me.company.Caption = "Contact Name"
        Me.company.FieldName = "comp_name"
        Me.company.Name = "company"
        Me.company.Visible = True
        Me.company.VisibleIndex = 1
        Me.company.Width = 105
        '
        'GridColumnAddress
        '
        Me.GridColumnAddress.Caption = "Address"
        Me.GridColumnAddress.FieldName = "address_primary"
        Me.GridColumnAddress.Name = "GridColumnAddress"
        Me.GridColumnAddress.Visible = True
        Me.GridColumnAddress.VisibleIndex = 3
        Me.GridColumnAddress.Width = 289
        '
        'GridColumnSubDistrict
        '
        Me.GridColumnSubDistrict.Caption = "Sub District"
        Me.GridColumnSubDistrict.FieldName = "sub_district"
        Me.GridColumnSubDistrict.Name = "GridColumnSubDistrict"
        Me.GridColumnSubDistrict.Visible = True
        Me.GridColumnSubDistrict.VisibleIndex = 4
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
        Me.Category.Visible = True
        Me.Category.VisibleIndex = 2
        Me.Category.Width = 80
        '
        'GridColumnCP
        '
        Me.GridColumnCP.Caption = "Contact Person"
        Me.GridColumnCP.FieldName = "contact_person"
        Me.GridColumnCP.Name = "GridColumnCP"
        Me.GridColumnCP.Visible = True
        Me.GridColumnCP.VisibleIndex = 5
        '
        'GridColumnCPNumber
        '
        Me.GridColumnCPNumber.Caption = "Number"
        Me.GridColumnCPNumber.FieldName = "contact_number"
        Me.GridColumnCPNumber.Name = "GridColumnCPNumber"
        Me.GridColumnCPNumber.Visible = True
        Me.GridColumnCPNumber.VisibleIndex = 6
        '
        'GridColumnCPEmail
        '
        Me.GridColumnCPEmail.Caption = "Email"
        Me.GridColumnCPEmail.FieldName = "contact_email"
        Me.GridColumnCPEmail.Name = "GridColumnCPEmail"
        Me.GridColumnCPEmail.Visible = True
        Me.GridColumnCPEmail.VisibleIndex = 7
        '
        'GCStatus
        '
        Me.GCStatus.Caption = "Status"
        Me.GCStatus.FieldName = "comp_status"
        Me.GCStatus.Name = "GCStatus"
        Me.GCStatus.Visible = True
        Me.GCStatus.VisibleIndex = 8
        '
        'is_active_company
        '
        Me.is_active_company.AutoHeight = False
        Me.is_active_company.DisplayValueChecked = "1"
        Me.is_active_company.DisplayValueUnchecked = "0"
        Me.is_active_company.Name = "is_active_company"
        '
        'GridColumnShortName
        '
        Me.GridColumnShortName.Caption = "Short Name"
        Me.GridColumnShortName.FieldName = "comp_display_name"
        Me.GridColumnShortName.Name = "GridColumnShortName"
        '
        'GridColumnCity
        '
        Me.GridColumnCity.Caption = "City"
        Me.GridColumnCity.FieldName = "city"
        Me.GridColumnCity.Name = "GridColumnCity"
        '
        'GridColumnProvince
        '
        Me.GridColumnProvince.Caption = "Province"
        Me.GridColumnProvince.FieldName = "state"
        Me.GridColumnProvince.Name = "GridColumnProvince"
        '
        'GridColumnIsland
        '
        Me.GridColumnIsland.Caption = "Island"
        Me.GridColumnIsland.FieldName = "island"
        Me.GridColumnIsland.Name = "GridColumnIsland"
        '
        'GridColumnMasterArea
        '
        Me.GridColumnMasterArea.Caption = "Master Area"
        Me.GridColumnMasterArea.FieldName = "area"
        Me.GridColumnMasterArea.Name = "GridColumnMasterArea"
        '
        'GridColumnStoreType
        '
        Me.GridColumnStoreType.Caption = "Store Type"
        Me.GridColumnStoreType.FieldName = "store_type"
        Me.GridColumnStoreType.Name = "GridColumnStoreType"
        '
        'FormMasterCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 619)
        Me.Controls.Add(Me.GCCompany)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCompany"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company"
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCCompany As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompany As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAddress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents is_active As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents is_active_company As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GCStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCPNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCPEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSubDistrict As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnShortName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProvince As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsland As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMasterArea As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreType As DevExpress.XtraGrid.Columns.GridColumn
End Class
