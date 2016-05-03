<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpPLProd
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
        Me.PCNav = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SCCProd = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlProd = New DevExpress.XtraEditors.GroupControl()
        Me.GCProd = New DevExpress.XtraGrid.GridControl()
        Me.GVProd = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnProdNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAllocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.GroupControlListProd = New DevExpress.XtraEditors.GroupControl()
        Me.GCListProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVListProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCNav.SuspendLayout()
        CType(Me.SCCProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCProd.SuspendLayout()
        CType(Me.GroupControlProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlProd.SuspendLayout()
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlListProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlListProd.SuspendLayout()
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCNav
        '
        Me.PCNav.Controls.Add(Me.BCancel)
        Me.PCNav.Controls.Add(Me.BSave)
        Me.PCNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCNav.Location = New System.Drawing.Point(0, 510)
        Me.PCNav.LookAndFeel.SkinName = "Blue"
        Me.PCNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCNav.Name = "PCNav"
        Me.PCNav.Size = New System.Drawing.Size(926, 49)
        Me.PCNav.TabIndex = 1
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(768, 14)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 4
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(844, 14)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 3
        Me.BSave.Text = "Choose"
        '
        'SCCProd
        '
        Me.SCCProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCProd.Horizontal = False
        Me.SCCProd.Location = New System.Drawing.Point(0, 0)
        Me.SCCProd.Name = "SCCProd"
        Me.SCCProd.Panel1.Controls.Add(Me.GroupControlProd)
        Me.SCCProd.Panel1.Text = "Panel1"
        Me.SCCProd.Panel2.Controls.Add(Me.GroupControlListProd)
        Me.SCCProd.Panel2.Text = "Panel2"
        Me.SCCProd.Size = New System.Drawing.Size(926, 510)
        Me.SCCProd.SplitterPosition = 241
        Me.SCCProd.TabIndex = 2
        Me.SCCProd.Text = "SplitContainerControl1"
        '
        'GroupControlProd
        '
        Me.GroupControlProd.Controls.Add(Me.GCProd)
        Me.GroupControlProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlProd.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlProd.Name = "GroupControlProd"
        Me.GroupControlProd.Size = New System.Drawing.Size(926, 241)
        Me.GroupControlProd.TabIndex = 0
        Me.GroupControlProd.Text = "Packing List"
        '
        'GCProd
        '
        Me.GCProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProd.Location = New System.Drawing.Point(2, 20)
        Me.GCProd.MainView = Me.GVProd
        Me.GCProd.Name = "GCProd"
        Me.GCProd.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIPictureEdit})
        Me.GCProd.Size = New System.Drawing.Size(922, 219)
        Me.GCProd.TabIndex = 3
        Me.GCProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProd})
        '
        'GVProd
        '
        Me.GVProd.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnProdNo, Me.GridColumnReportStatus, Me.GridColumnIdReportStatus, Me.GridColumnProdDate, Me.GridColumnPOType, Me.GridColumnDesign, Me.GridColumnCode, Me.GridColumnIdPO, Me.GridColumnSeason, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumn1, Me.GridColumnAllocation, Me.GridColumnPONumber})
        Me.GVProd.GridControl = Me.GCProd
        Me.GVProd.GroupCount = 1
        Me.GVProd.Name = "GVProd"
        Me.GVProd.OptionsBehavior.Editable = False
        Me.GVProd.OptionsFind.AlwaysVisible = True
        Me.GVProd.OptionsView.ShowGroupPanel = False
        Me.GVProd.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdPO, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnProdNo
        '
        Me.GridColumnProdNo.Caption = "Number"
        Me.GridColumnProdNo.FieldName = "pl_prod_order_number"
        Me.GridColumnProdNo.Name = "GridColumnProdNo"
        Me.GridColumnProdNo.Visible = True
        Me.GridColumnProdNo.VisibleIndex = 0
        Me.GridColumnProdNo.Width = 91
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 8
        Me.GridColumnReportStatus.Width = 121
        '
        'GridColumnIdReportStatus
        '
        Me.GridColumnIdReportStatus.Caption = "Id Report Status"
        Me.GridColumnIdReportStatus.FieldName = "id_report_status"
        Me.GridColumnIdReportStatus.Name = "GridColumnIdReportStatus"
        Me.GridColumnIdReportStatus.Width = 89
        '
        'GridColumnProdDate
        '
        Me.GridColumnProdDate.Caption = "Date"
        Me.GridColumnProdDate.FieldName = "pl_prod_order_date"
        Me.GridColumnProdDate.Name = "GridColumnProdDate"
        Me.GridColumnProdDate.Visible = True
        Me.GridColumnProdDate.VisibleIndex = 7
        Me.GridColumnProdDate.Width = 96
        '
        'GridColumnPOType
        '
        Me.GridColumnPOType.Caption = "PL Category"
        Me.GridColumnPOType.FieldName = "pl_category"
        Me.GridColumnPOType.Name = "GridColumnPOType"
        Me.GridColumnPOType.Visible = True
        Me.GridColumnPOType.VisibleIndex = 6
        Me.GridColumnPOType.Width = 96
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_display_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 5
        Me.GridColumnDesign.Width = 148
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "design_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 4
        Me.GridColumnCode.Width = 96
        '
        'GridColumnIdPO
        '
        Me.GridColumnIdPO.Caption = "ID PO"
        Me.GridColumnIdPO.FieldName = "id_pl_prod_order"
        Me.GridColumnIdPO.Name = "GridColumnIdPO"
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "comp_name_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 2
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "comp_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 3
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Design"
        Me.GridColumn1.FieldName = "id_design"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnAllocation
        '
        Me.GridColumnAllocation.Caption = "Allocation"
        Me.GridColumnAllocation.FieldName = "pd_alloc"
        Me.GridColumnAllocation.Name = "GridColumnAllocation"
        '
        'RIPictureEdit
        '
        Me.RIPictureEdit.Name = "RIPictureEdit"
        Me.RIPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'GroupControlListProd
        '
        Me.GroupControlListProd.Controls.Add(Me.GCListProduct)
        Me.GroupControlListProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlListProd.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlListProd.Name = "GroupControlListProd"
        Me.GroupControlListProd.Size = New System.Drawing.Size(926, 264)
        Me.GroupControlListProd.TabIndex = 1
        Me.GroupControlListProd.Text = "Detail"
        '
        'GCListProduct
        '
        Me.GCListProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListProduct.Location = New System.Drawing.Point(2, 20)
        Me.GCListProduct.MainView = Me.GVListProduct
        Me.GCListProduct.Margin = New System.Windows.Forms.Padding(0)
        Me.GCListProduct.Name = "GCListProduct"
        Me.GCListProduct.Size = New System.Drawing.Size(922, 242)
        Me.GCListProduct.TabIndex = 1
        Me.GCListProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListProduct})
        '
        'GVListProduct
        '
        Me.GVListProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdMat, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColSubtotal, Me.ColNote, Me.ColColor, Me.ColSize})
        Me.GVListProduct.GridControl = Me.GCListProduct
        Me.GVListProduct.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GVListProduct.Name = "GVListProduct"
        Me.GVListProduct.OptionsView.ShowFooter = True
        Me.GVListProduct.OptionsView.ShowGroupPanel = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Purc Det"
        Me.ColIdPurcDet.FieldName = "id_prod_order_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        '
        'ColIdMat
        '
        Me.ColIdMat.Caption = "Id Mat"
        Me.ColIdMat.FieldName = "id_prod_demand_product"
        Me.ColIdMat.Name = "ColIdMat"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 30
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 140
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 235
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Unit Cost"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "estimate_cost"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.OptionsColumn.AllowEdit = False
        Me.ColPrice.Width = 140
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.DisplayFormat.FormatString = "{0:N2}"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "pl_prod_order_det_qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.OptionsColumn.AllowEdit = False
        Me.ColQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_prod_order_det_qty", "{0:N2}")})
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 5
        Me.ColQty.Width = 68
        '
        'ColSubtotal
        '
        Me.ColSubtotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.Caption = "Sub Total"
        Me.ColSubtotal.DisplayFormat.FormatString = "N2"
        Me.ColSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColSubtotal.FieldName = "total_cost"
        Me.ColSubtotal.Name = "ColSubtotal"
        Me.ColSubtotal.OptionsColumn.AllowEdit = False
        Me.ColSubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:N2}")})
        Me.ColSubtotal.Width = 165
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        '
        'ColColor
        '
        Me.ColColor.AppearanceCell.Options.UseTextOptions = True
        Me.ColColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColColor.AppearanceHeader.Options.UseTextOptions = True
        Me.ColColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColColor.Caption = "Color"
        Me.ColColor.FieldName = "color"
        Me.ColColor.Name = "ColColor"
        Me.ColColor.OptionsColumn.AllowEdit = False
        Me.ColColor.Visible = True
        Me.ColColor.VisibleIndex = 3
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.OptionsColumn.AllowEdit = False
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 4
        '
        'GridColumnPONumber
        '
        Me.GridColumnPONumber.Caption = "PO Number"
        Me.GridColumnPONumber.FieldName = "prod_order_number"
        Me.GridColumnPONumber.Name = "GridColumnPONumber"
        Me.GridColumnPONumber.Visible = True
        Me.GridColumnPONumber.VisibleIndex = 1
        '
        'FormPopUpPLProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 559)
        Me.Controls.Add(Me.SCCProd)
        Me.Controls.Add(Me.PCNav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpPLProd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Packing List Production"
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCNav.ResumeLayout(False)
        CType(Me.SCCProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCProd.ResumeLayout(False)
        CType(Me.GroupControlProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlProd.ResumeLayout(False)
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlListProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlListProd.ResumeLayout(False)
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PCNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SCCProd As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlProd As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProd As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnProdNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents GroupControlListProd As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCListProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAllocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPONumber As DevExpress.XtraGrid.Columns.GridColumn
End Class
