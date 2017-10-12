<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpProdOVH
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
        Me.code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCompany = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.overhead = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOVHName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColUnitPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompContact = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceOri = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsMainVendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RCIMainVendor = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnKurs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEditOVH = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.BShowBOM = New DevExpress.XtraEditors.SimpleButton()
        Me.CEBOM = New DevExpress.XtraEditors.CheckEdit()
        Me.BCancelOvh = New DevExpress.XtraEditors.SimpleButton()
        Me.BSaveOvh = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCOVH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOVH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCIMainVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEditOVH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.CEBOM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCOVH
        '
        Me.GCOVH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOVH.Location = New System.Drawing.Point(0, 0)
        Me.GCOVH.MainView = Me.GVOVH
        Me.GCOVH.Name = "GCOVH"
        Me.GCOVH.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEditOVH, Me.RCIMainVendor})
        Me.GCOVH.Size = New System.Drawing.Size(809, 340)
        Me.GCOVH.TabIndex = 34
        Me.GCOVH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOVH})
        '
        'GVOVH
        '
        Me.GVOVH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_ovh, Me.code, Me.ColCompany, Me.overhead, Me.GridColumnOVHName, Me.ColUnitPrice, Me.GridColumnUom, Me.GridColumnIdCompContact, Me.GridColumnPriceOri, Me.GridColumnCurrency, Me.GridColumnIdCurrency, Me.GridColumnIsMainVendor, Me.GridColumnKurs})
        Me.GVOVH.GridControl = Me.GCOVH
        Me.GVOVH.Name = "GVOVH"
        Me.GVOVH.OptionsBehavior.Editable = False
        Me.GVOVH.OptionsView.ShowGroupPanel = False
        '
        'id_ovh
        '
        Me.id_ovh.Caption = "ID"
        Me.id_ovh.FieldName = "id_ovh_price"
        Me.id_ovh.Name = "id_ovh"
        '
        'code
        '
        Me.code.Caption = "Code"
        Me.code.FieldName = "code"
        Me.code.Name = "code"
        Me.code.Visible = True
        Me.code.VisibleIndex = 0
        Me.code.Width = 122
        '
        'ColCompany
        '
        Me.ColCompany.Caption = "Vendor"
        Me.ColCompany.FieldName = "comp_name"
        Me.ColCompany.Name = "ColCompany"
        Me.ColCompany.Visible = True
        Me.ColCompany.VisibleIndex = 3
        Me.ColCompany.Width = 136
        '
        'overhead
        '
        Me.overhead.Caption = "Overhead"
        Me.overhead.FieldName = "name"
        Me.overhead.Name = "overhead"
        Me.overhead.Visible = True
        Me.overhead.VisibleIndex = 1
        Me.overhead.Width = 99
        '
        'GridColumnOVHName
        '
        Me.GridColumnOVHName.Caption = "Description"
        Me.GridColumnOVHName.FieldName = "ovh_price_name"
        Me.GridColumnOVHName.Name = "GridColumnOVHName"
        Me.GridColumnOVHName.Visible = True
        Me.GridColumnOVHName.VisibleIndex = 2
        Me.GridColumnOVHName.Width = 151
        '
        'ColUnitPrice
        '
        Me.ColUnitPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColUnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColUnitPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColUnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColUnitPrice.Caption = "BOM Price"
        Me.ColUnitPrice.DisplayFormat.FormatString = "N2"
        Me.ColUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColUnitPrice.FieldName = "price"
        Me.ColUnitPrice.Name = "ColUnitPrice"
        Me.ColUnitPrice.Width = 100
        '
        'GridColumnUom
        '
        Me.GridColumnUom.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUom.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUom.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUom.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUom.Caption = "UOM"
        Me.GridColumnUom.FieldName = "uom"
        Me.GridColumnUom.Name = "GridColumnUom"
        Me.GridColumnUom.Visible = True
        Me.GridColumnUom.VisibleIndex = 6
        Me.GridColumnUom.Width = 55
        '
        'GridColumnIdCompContact
        '
        Me.GridColumnIdCompContact.Caption = "Id Comp Contact"
        Me.GridColumnIdCompContact.FieldName = "id_comp_contact"
        Me.GridColumnIdCompContact.Name = "GridColumnIdCompContact"
        '
        'GridColumnPriceOri
        '
        Me.GridColumnPriceOri.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPriceOri.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPriceOri.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPriceOri.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPriceOri.Caption = "Vendor Price"
        Me.GridColumnPriceOri.DisplayFormat.FormatString = "N4"
        Me.GridColumnPriceOri.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPriceOri.FieldName = "price_ori"
        Me.GridColumnPriceOri.Name = "GridColumnPriceOri"
        Me.GridColumnPriceOri.Visible = True
        Me.GridColumnPriceOri.VisibleIndex = 5
        Me.GridColumnPriceOri.Width = 73
        '
        'GridColumnCurrency
        '
        Me.GridColumnCurrency.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCurrency.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCurrency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCurrency.Caption = "Currency"
        Me.GridColumnCurrency.FieldName = "currency"
        Me.GridColumnCurrency.Name = "GridColumnCurrency"
        Me.GridColumnCurrency.Visible = True
        Me.GridColumnCurrency.VisibleIndex = 4
        Me.GridColumnCurrency.Width = 56
        '
        'GridColumnIdCurrency
        '
        Me.GridColumnIdCurrency.Caption = "Id Currecny"
        Me.GridColumnIdCurrency.FieldName = "id_currency"
        Me.GridColumnIdCurrency.Name = "GridColumnIdCurrency"
        '
        'GridColumnIsMainVendor
        '
        Me.GridColumnIsMainVendor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIsMainVendor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIsMainVendor.Caption = "Main Vendor"
        Me.GridColumnIsMainVendor.ColumnEdit = Me.RCIMainVendor
        Me.GridColumnIsMainVendor.FieldName = "is_ovh_main"
        Me.GridColumnIsMainVendor.Name = "GridColumnIsMainVendor"
        Me.GridColumnIsMainVendor.Visible = True
        Me.GridColumnIsMainVendor.VisibleIndex = 7
        '
        'RCIMainVendor
        '
        Me.RCIMainVendor.AutoHeight = False
        Me.RCIMainVendor.Name = "RCIMainVendor"
        Me.RCIMainVendor.ValueChecked = CType(1, Byte)
        Me.RCIMainVendor.ValueUnchecked = CType(2, Byte)
        '
        'GridColumnKurs
        '
        Me.GridColumnKurs.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnKurs.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKurs.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnKurs.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKurs.Caption = "Kurs"
        Me.GridColumnKurs.DisplayFormat.FormatString = "N2"
        Me.GridColumnKurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnKurs.FieldName = "kurs"
        Me.GridColumnKurs.Name = "GridColumnKurs"
        '
        'RepositoryItemCheckEditOVH
        '
        Me.RepositoryItemCheckEditOVH.AutoHeight = False
        Me.RepositoryItemCheckEditOVH.Name = "RepositoryItemCheckEditOVH"
        Me.RepositoryItemCheckEditOVH.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEditOVH.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'PanelControl4
        '
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.BShowBOM)
        Me.PanelControl4.Controls.Add(Me.CEBOM)
        Me.PanelControl4.Controls.Add(Me.BCancelOvh)
        Me.PanelControl4.Controls.Add(Me.BSaveOvh)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(0, 340)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(809, 35)
        Me.PanelControl4.TabIndex = 33
        '
        'BShowBOM
        '
        Me.BShowBOM.Enabled = False
        Me.BShowBOM.Location = New System.Drawing.Point(193, 6)
        Me.BShowBOM.Name = "BShowBOM"
        Me.BShowBOM.Size = New System.Drawing.Size(103, 23)
        Me.BShowBOM.TabIndex = 6
        Me.BShowBOM.Text = "Show Overhead"
        Me.BShowBOM.Visible = False
        '
        'CEBOM
        '
        Me.CEBOM.Location = New System.Drawing.Point(12, 8)
        Me.CEBOM.Name = "CEBOM"
        Me.CEBOM.Properties.Caption = "Show Only Overhead From BOM"
        Me.CEBOM.Size = New System.Drawing.Size(175, 19)
        Me.CEBOM.TabIndex = 5
        '
        'BCancelOvh
        '
        Me.BCancelOvh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancelOvh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancelOvh.Location = New System.Drawing.Point(669, 0)
        Me.BCancelOvh.Name = "BCancelOvh"
        Me.BCancelOvh.Size = New System.Drawing.Size(70, 35)
        Me.BCancelOvh.TabIndex = 2
        Me.BCancelOvh.Text = "Cancel"
        '
        'BSaveOvh
        '
        Me.BSaveOvh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSaveOvh.Location = New System.Drawing.Point(739, 0)
        Me.BSaveOvh.Name = "BSaveOvh"
        Me.BSaveOvh.Size = New System.Drawing.Size(70, 35)
        Me.BSaveOvh.TabIndex = 1
        Me.BSaveOvh.Text = "Choose"
        '
        'FormPopUpProdOVH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 375)
        Me.Controls.Add(Me.GCOVH)
        Me.Controls.Add(Me.PanelControl4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpProdOVH"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Overhead"
        CType(Me.GCOVH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOVH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCIMainVendor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEditOVH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.CEBOM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCOVH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOVH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_ovh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCompany As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents overhead As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUnitPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompContact As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceOri As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEditOVH As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancelOvh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSaveOvh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BShowBOM As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEBOM As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnOVHName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsMainVendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RCIMainVendor As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnKurs As DevExpress.XtraGrid.Columns.GridColumn
End Class
