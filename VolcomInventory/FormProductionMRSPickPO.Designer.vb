<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionMRSPickPO
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
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView14 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.GVProd = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCProd = New DevExpress.XtraGrid.GridControl()
        Me.RIPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "prod_order_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.OptionsColumn.AllowEdit = False
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 4
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(57, 9)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendor.Properties.Appearance.Options.UseFont = True
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView14
        Me.SLEVendor.Size = New System.Drawing.Size(200, 20)
        Me.SLEVendor.TabIndex = 8905
        '
        'GridView14
        '
        Me.GridView14.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView14.Name = "GridView14"
        Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView14.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id Comp"
        Me.GridColumn10.FieldName = "id_comp"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Comp Number"
        Me.GridColumn11.FieldName = "comp_number"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 188
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Comp Name"
        Me.GridColumn12.FieldName = "comp_name"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        Me.GridColumn12.Width = 504
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.Caption = "Description"
        Me.GridColumnDescription.FieldName = "design_display_name"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.OptionsColumn.AllowEdit = False
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 3
        Me.GridColumnDescription.Width = 121
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "design_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 2
        Me.GridColumnCode.Width = 78
        '
        'GridColumnProdNo
        '
        Me.GridColumnProdNo.Caption = "Number"
        Me.GridColumnProdNo.FieldName = "prod_order_number"
        Me.GridColumnProdNo.Name = "GridColumnProdNo"
        Me.GridColumnProdNo.OptionsColumn.AllowEdit = False
        Me.GridColumnProdNo.Visible = True
        Me.GridColumnProdNo.VisibleIndex = 1
        Me.GridColumnProdNo.Width = 74
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Vendor"
        Me.GridColumnCompName.DisplayFormat.FormatString = "N0"
        Me.GridColumnCompName.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCompName.FieldName = "vendor"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.OptionsColumn.AllowEdit = False
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 0
        Me.GridColumnCompName.Width = 79
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(263, 7)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8903
        Me.BSearch.Text = "Search"
        '
        'GVProd
        '
        Me.GVProd.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCompName, Me.GridColumnProdNo, Me.GridColumnCode, Me.GridColumnDescription, Me.GridColumnDate})
        Me.GVProd.GridControl = Me.GCProd
        Me.GVProd.Name = "GVProd"
        Me.GVProd.OptionsFind.AlwaysVisible = True
        Me.GVProd.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVProd.OptionsView.ColumnAutoWidth = False
        Me.GVProd.OptionsView.ShowGroupPanel = False
        '
        'GCProd
        '
        Me.GCProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProd.Location = New System.Drawing.Point(0, 38)
        Me.GCProd.MainView = Me.GVProd
        Me.GCProd.Name = "GCProd"
        Me.GCProd.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIPictureEdit, Me.RepositoryItemCheckEdit1})
        Me.GCProd.Size = New System.Drawing.Size(784, 523)
        Me.GCProd.TabIndex = 7
        Me.GCProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProd})
        '
        'RIPictureEdit
        '
        Me.RIPictureEdit.Name = "RIPictureEdit"
        Me.RIPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 8901
        Me.LabelControl3.Text = "Vendor"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEVendor)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 38)
        Me.PanelControl1.TabIndex = 6
        '
        'FormProductionMRSPickPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCProd)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormProductionMRSPickPO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick PO"
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView14 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GVProd As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents RIPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
End Class
