<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpSalesOrder
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
        Me.SCCSO = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlSalesOrder = New DevExpress.XtraEditors.GroupControl()
        Me.GCSalesOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSalesTargetNumb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesTargetDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDSalesTargetNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrepareStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnIdSalesOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1Category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPreparedFor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControlSalesOrderDet = New DevExpress.XtraEditors.GroupControl()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesTarget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEanCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCNav.SuspendLayout()
        CType(Me.SCCSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCSO.SuspendLayout()
        CType(Me.GroupControlSalesOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSalesOrder.SuspendLayout()
        CType(Me.GCSalesOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlSalesOrderDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSalesOrderDet.SuspendLayout()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCNav
        '
        Me.PCNav.Controls.Add(Me.BCancel)
        Me.PCNav.Controls.Add(Me.BSave)
        Me.PCNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCNav.Location = New System.Drawing.Point(0, 437)
        Me.PCNav.LookAndFeel.SkinName = "Blue"
        Me.PCNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCNav.Name = "PCNav"
        Me.PCNav.Size = New System.Drawing.Size(759, 43)
        Me.PCNav.TabIndex = 1
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(617, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 39)
        Me.BCancel.TabIndex = 4
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(687, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 39)
        Me.BSave.TabIndex = 3
        Me.BSave.Text = "Choose"
        '
        'SCCSO
        '
        Me.SCCSO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCSO.Horizontal = False
        Me.SCCSO.Location = New System.Drawing.Point(0, 0)
        Me.SCCSO.Name = "SCCSO"
        Me.SCCSO.Panel1.Controls.Add(Me.GroupControlSalesOrder)
        Me.SCCSO.Panel1.Text = "Panel1"
        Me.SCCSO.Panel2.Controls.Add(Me.GroupControlSalesOrderDet)
        Me.SCCSO.Panel2.Text = "Panel2"
        Me.SCCSO.Size = New System.Drawing.Size(759, 437)
        Me.SCCSO.SplitterPosition = 239
        Me.SCCSO.TabIndex = 2
        Me.SCCSO.Text = "SplitContainerControl1"
        '
        'GroupControlSalesOrder
        '
        Me.GroupControlSalesOrder.Controls.Add(Me.GCSalesOrder)
        Me.GroupControlSalesOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSalesOrder.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSalesOrder.Name = "GroupControlSalesOrder"
        Me.GroupControlSalesOrder.Size = New System.Drawing.Size(759, 239)
        Me.GroupControlSalesOrder.TabIndex = 0
        Me.GroupControlSalesOrder.Text = "Sales Order"
        '
        'GCSalesOrder
        '
        Me.GCSalesOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesOrder.Location = New System.Drawing.Point(2, 20)
        Me.GCSalesOrder.MainView = Me.GVSalesOrder
        Me.GCSalesOrder.Name = "GCSalesOrder"
        Me.GCSalesOrder.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1})
        Me.GCSalesOrder.Size = New System.Drawing.Size(755, 217)
        Me.GCSalesOrder.TabIndex = 3
        Me.GCSalesOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesOrder, Me.GridView2})
        '
        'GVSalesOrder
        '
        Me.GVSalesOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSalesTargetNumb, Me.GridColumnTo, Me.GridColumnSalesTargetDate, Me.GridColumnDSalesTargetNote, Me.GridColumnReportStatus, Me.GridColumnPrepareStatus, Me.GridColumn9, Me.GridColumnIdSalesOrder, Me.GridColumn1Category, Me.GridColumn10, Me.GridColumnReff, Me.GridColumnPreparedFor})
        Me.GVSalesOrder.GridControl = Me.GCSalesOrder
        Me.GVSalesOrder.Name = "GVSalesOrder"
        Me.GVSalesOrder.OptionsBehavior.ReadOnly = True
        Me.GVSalesOrder.OptionsCustomization.AllowSort = False
        Me.GVSalesOrder.OptionsFind.AlwaysVisible = True
        Me.GVSalesOrder.OptionsView.ShowGroupPanel = False
        Me.GVSalesOrder.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdSalesOrder, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnSalesTargetNumb
        '
        Me.GridColumnSalesTargetNumb.Caption = "Number"
        Me.GridColumnSalesTargetNumb.FieldName = "sales_order_number"
        Me.GridColumnSalesTargetNumb.Name = "GridColumnSalesTargetNumb"
        Me.GridColumnSalesTargetNumb.Visible = True
        Me.GridColumnSalesTargetNumb.VisibleIndex = 0
        Me.GridColumnSalesTargetNumb.Width = 123
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "Store/Destination"
        Me.GridColumnTo.FieldName = "store_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 2
        Me.GridColumnTo.Width = 111
        '
        'GridColumnSalesTargetDate
        '
        Me.GridColumnSalesTargetDate.Caption = "Created Date"
        Me.GridColumnSalesTargetDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnSalesTargetDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnSalesTargetDate.FieldName = "sales_order_date"
        Me.GridColumnSalesTargetDate.Name = "GridColumnSalesTargetDate"
        Me.GridColumnSalesTargetDate.Visible = True
        Me.GridColumnSalesTargetDate.VisibleIndex = 6
        Me.GridColumnSalesTargetDate.Width = 111
        '
        'GridColumnDSalesTargetNote
        '
        Me.GridColumnDSalesTargetNote.Caption = "Note"
        Me.GridColumnDSalesTargetNote.FieldName = "sales_order_note"
        Me.GridColumnDSalesTargetNote.Name = "GridColumnDSalesTargetNote"
        Me.GridColumnDSalesTargetNote.Width = 111
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Width = 141
        '
        'GridColumnPrepareStatus
        '
        Me.GridColumnPrepareStatus.Caption = "Packing Status"
        Me.GridColumnPrepareStatus.FieldName = "prepare_status"
        Me.GridColumnPrepareStatus.Name = "GridColumnPrepareStatus"
        Me.GridColumnPrepareStatus.Visible = True
        Me.GridColumnPrepareStatus.VisibleIndex = 7
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Completness"
        Me.GridColumn9.ColumnEdit = Me.RepositoryItemProgressBar1
        Me.GridColumn9.FieldName = "so_completness"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        Me.GridColumn9.Width = 85
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Appearance.ForeColor = System.Drawing.Color.Red
        Me.RepositoryItemProgressBar1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        Me.RepositoryItemProgressBar1.ShowTitle = True
        '
        'GridColumnIdSalesOrder
        '
        Me.GridColumnIdSalesOrder.Caption = "Id Sales Order"
        Me.GridColumnIdSalesOrder.FieldName = "id_sales_order"
        Me.GridColumnIdSalesOrder.Name = "GridColumnIdSalesOrder"
        Me.GridColumnIdSalesOrder.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn1Category
        '
        Me.GridColumn1Category.Caption = "Category"
        Me.GridColumn1Category.FieldName = "so_status"
        Me.GridColumn1Category.FieldNameSortGroup = "id_so_status"
        Me.GridColumn1Category.Name = "GridColumn1Category"
        Me.GridColumn1Category.Visible = True
        Me.GridColumn1Category.VisibleIndex = 4
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Warehouse"
        Me.GridColumn10.FieldName = "warehouse_name_to"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 3
        '
        'GridColumnReff
        '
        Me.GridColumnReff.Caption = "Reff"
        Me.GridColumnReff.FieldName = "fg_so_reff_number"
        Me.GridColumnReff.Name = "GridColumnReff"
        Me.GridColumnReff.Visible = True
        Me.GridColumnReff.VisibleIndex = 1
        '
        'GridColumnPreparedFor
        '
        Me.GridColumnPreparedFor.Caption = "Del. Type"
        Me.GridColumnPreparedFor.FieldName = "so_cat"
        Me.GridColumnPreparedFor.FieldNameSortGroup = "id_so_cat"
        Me.GridColumnPreparedFor.Name = "GridColumnPreparedFor"
        Me.GridColumnPreparedFor.Visible = True
        Me.GridColumnPreparedFor.VisibleIndex = 5
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSalesOrder
        Me.GridView2.Name = "GridView2"
        '
        'GroupControlSalesOrderDet
        '
        Me.GroupControlSalesOrderDet.Controls.Add(Me.GCItemList)
        Me.GroupControlSalesOrderDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSalesOrderDet.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSalesOrderDet.Name = "GroupControlSalesOrderDet"
        Me.GroupControlSalesOrderDet.Size = New System.Drawing.Size(759, 193)
        Me.GroupControlSalesOrderDet.TabIndex = 0
        Me.GroupControlSalesOrderDet.Text = "Item List"
        '
        'GCItemList
        '
        Me.GCItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemList.Location = New System.Drawing.Point(2, 20)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(755, 171)
        Me.GCItemList.TabIndex = 3
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnIdSalesTarget, Me.GridColumnCode, Me.GridColumnEanCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnQty, Me.GridColumnPrice, Me.GridColumnAmount, Me.GridColumnRemark, Me.GridColumn1, Me.GridColumn2})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.GroupCount = 1
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVItemList.OptionsBehavior.ReadOnly = True
        Me.GVItemList.OptionsCustomization.AllowGroup = False
        Me.GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        Me.GVItemList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 46
        '
        'GridColumnIdSalesTarget
        '
        Me.GridColumnIdSalesTarget.Caption = "ID Sales Target"
        Me.GridColumnIdSalesTarget.FieldName = "id_sales_target"
        Me.GridColumnIdSalesTarget.Name = "GridColumnIdSalesTarget"
        Me.GridColumnIdSalesTarget.OptionsColumn.AllowEdit = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 76
        '
        'GridColumnEanCode
        '
        Me.GridColumnEanCode.Caption = "EAN Code"
        Me.GridColumnEanCode.FieldName = "ean_code"
        Me.GridColumnEanCode.Name = "GridColumnEanCode"
        Me.GridColumnEanCode.OptionsColumn.AllowEdit = False
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_design"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Width = 142
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        Me.GridColumnSize.Width = 59
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Width = 71
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "F2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sales_order_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        Me.GridColumnQty.Width = 102
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 4
        Me.GridColumnPrice.Width = 123
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 5
        Me.GridColumnAmount.Width = 141
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sales_order_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 6
        Me.GridColumnRemark.Width = 255
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Product"
        Me.GridColumn1.FieldName = "id_product"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GridColumn2"
        Me.GridColumn2.FieldName = "id_sales_order_det"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'FormPopUpSalesOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 480)
        Me.Controls.Add(Me.SCCSO)
        Me.Controls.Add(Me.PCNav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpSalesOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Sales Order"
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCNav.ResumeLayout(False)
        CType(Me.SCCSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCSO.ResumeLayout(False)
        CType(Me.GroupControlSalesOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSalesOrder.ResumeLayout(False)
        CType(Me.GCSalesOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlSalesOrderDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSalesOrderDet.ResumeLayout(False)
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PCNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SCCSO As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlSalesOrder As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlSalesOrderDet As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesTarget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEanCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCSalesOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSalesTargetNumb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesTargetDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDSalesTargetNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrepareStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnIdSalesOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1Category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPreparedFor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
