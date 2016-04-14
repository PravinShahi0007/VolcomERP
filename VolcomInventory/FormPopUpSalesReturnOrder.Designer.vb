<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpSalesReturnOrder
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
        Me.SCCReturnOrder = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCSalesReturnOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesReturnOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSalesTargetNumb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesTargetDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDSalesTargetNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrepStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSvcLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesTarget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReturnCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesOrderDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReturnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesignPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCNav.SuspendLayout()
        CType(Me.SCCReturnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCReturnOrder.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCSalesReturnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesReturnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
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
        Me.PCNav.Location = New System.Drawing.Point(0, 454)
        Me.PCNav.LookAndFeel.SkinName = "Blue"
        Me.PCNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCNav.Name = "PCNav"
        Me.PCNav.Size = New System.Drawing.Size(787, 45)
        Me.PCNav.TabIndex = 2
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(629, 10)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 4
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(705, 10)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 3
        Me.BSave.Text = "Choose"
        '
        'SCCReturnOrder
        '
        Me.SCCReturnOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCReturnOrder.Horizontal = False
        Me.SCCReturnOrder.Location = New System.Drawing.Point(0, 0)
        Me.SCCReturnOrder.Name = "SCCReturnOrder"
        Me.SCCReturnOrder.Panel1.Controls.Add(Me.GroupControl1)
        Me.SCCReturnOrder.Panel1.Text = "Panel1"
        Me.SCCReturnOrder.Panel2.Controls.Add(Me.GroupControl2)
        Me.SCCReturnOrder.Panel2.Text = "Panel2"
        Me.SCCReturnOrder.Size = New System.Drawing.Size(787, 454)
        Me.SCCReturnOrder.SplitterPosition = 243
        Me.SCCReturnOrder.TabIndex = 3
        Me.SCCReturnOrder.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCSalesReturnOrder)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(787, 243)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Return Order"
        '
        'GCSalesReturnOrder
        '
        Me.GCSalesReturnOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesReturnOrder.Location = New System.Drawing.Point(2, 20)
        Me.GCSalesReturnOrder.MainView = Me.GVSalesReturnOrder
        Me.GCSalesReturnOrder.Name = "GCSalesReturnOrder"
        Me.GCSalesReturnOrder.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1})
        Me.GCSalesReturnOrder.Size = New System.Drawing.Size(783, 221)
        Me.GCSalesReturnOrder.TabIndex = 3
        Me.GCSalesReturnOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesReturnOrder, Me.GridView2})
        '
        'GVSalesReturnOrder
        '
        Me.GVSalesReturnOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSalesTargetNumb, Me.GridColumnTo, Me.GridColumnSalesTargetDate, Me.GridColumnEstDate, Me.GridColumnDSalesTargetNote, Me.GridColumnReportStatus, Me.GridColumnPrepStatus, Me.GridColumnSvcLevel})
        Me.GVSalesReturnOrder.GridControl = Me.GCSalesReturnOrder
        Me.GVSalesReturnOrder.Name = "GVSalesReturnOrder"
        Me.GVSalesReturnOrder.OptionsBehavior.ReadOnly = True
        Me.GVSalesReturnOrder.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSalesTargetNumb
        '
        Me.GridColumnSalesTargetNumb.Caption = "Number"
        Me.GridColumnSalesTargetNumb.FieldName = "sales_return_order_number"
        Me.GridColumnSalesTargetNumb.Name = "GridColumnSalesTargetNumb"
        Me.GridColumnSalesTargetNumb.Visible = True
        Me.GridColumnSalesTargetNumb.VisibleIndex = 0
        Me.GridColumnSalesTargetNumb.Width = 83
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "store_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 1
        '
        'GridColumnSalesTargetDate
        '
        Me.GridColumnSalesTargetDate.Caption = "Created Date"
        Me.GridColumnSalesTargetDate.FieldName = "sales_return_order_date"
        Me.GridColumnSalesTargetDate.Name = "GridColumnSalesTargetDate"
        Me.GridColumnSalesTargetDate.Visible = True
        Me.GridColumnSalesTargetDate.VisibleIndex = 2
        '
        'GridColumnEstDate
        '
        Me.GridColumnEstDate.Caption = "Estimate Return"
        Me.GridColumnEstDate.FieldName = "sales_return_order_est_date"
        Me.GridColumnEstDate.Name = "GridColumnEstDate"
        Me.GridColumnEstDate.Visible = True
        Me.GridColumnEstDate.VisibleIndex = 3
        '
        'GridColumnDSalesTargetNote
        '
        Me.GridColumnDSalesTargetNote.Caption = "Note"
        Me.GridColumnDSalesTargetNote.FieldName = "sales_return_order_note"
        Me.GridColumnDSalesTargetNote.Name = "GridColumnDSalesTargetNote"
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        '
        'GridColumnPrepStatus
        '
        Me.GridColumnPrepStatus.Caption = "Status"
        Me.GridColumnPrepStatus.FieldName = "prepare_status"
        Me.GridColumnPrepStatus.Name = "GridColumnPrepStatus"
        '
        'GridColumnSvcLevel
        '
        Me.GridColumnSvcLevel.Caption = "Service Level"
        Me.GridColumnSvcLevel.ColumnEdit = Me.RepositoryItemProgressBar1
        Me.GridColumnSvcLevel.FieldName = "svc_level"
        Me.GridColumnSvcLevel.Name = "GridColumnSvcLevel"
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        Me.RepositoryItemProgressBar1.ReadOnly = True
        Me.RepositoryItemProgressBar1.ShowTitle = True
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSalesReturnOrder
        Me.GridView2.Name = "GridView2"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCItemList)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(787, 206)
        Me.GroupControl2.TabIndex = 0
        Me.GroupControl2.Text = "Detail"
        '
        'GCItemList
        '
        Me.GCItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemList.Location = New System.Drawing.Point(2, 20)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(783, 184)
        Me.GCItemList.TabIndex = 3
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnIdSalesTarget, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnQty, Me.GridColumnPrice, Me.GridColumnAmount, Me.GridColumnReturnCategory, Me.GridColumnRemark, Me.GridColumnIdDesign, Me.GridColumnIdProduct, Me.GridColumnIdSample, Me.GridColumnIdSalesOrderDet, Me.GridColumnProductName, Me.GridColumnIdReturnCat, Me.GridColumnIdDesignPrice, Me.GridColumnPriceType})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.ReadOnly = True
        Me.GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 41
        '
        'GridColumnIdSalesTarget
        '
        Me.GridColumnIdSalesTarget.Caption = "ID Sales Target"
        Me.GridColumnIdSalesTarget.FieldName = "id_sales_return_order"
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
        Me.GridColumnCode.Width = 55
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_design"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 103
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
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 43
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
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.DisplayFormat.FormatString = "F2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sales_return_order_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 6
        Me.GridColumnQty.Width = 74
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 5
        Me.GridColumnPrice.Width = 89
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 7
        Me.GridColumnAmount.Width = 103
        '
        'GridColumnReturnCategory
        '
        Me.GridColumnReturnCategory.Caption = "Return Category"
        Me.GridColumnReturnCategory.FieldName = "return_cat"
        Me.GridColumnReturnCategory.Name = "GridColumnReturnCategory"
        Me.GridColumnReturnCategory.Visible = True
        Me.GridColumnReturnCategory.VisibleIndex = 8
        Me.GridColumnReturnCategory.Width = 90
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sales_return_order_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 9
        Me.GridColumnRemark.Width = 155
        '
        'GridColumnIdDesign
        '
        Me.GridColumnIdDesign.Caption = "id design"
        Me.GridColumnIdDesign.FieldName = "id_design"
        Me.GridColumnIdDesign.Name = "GridColumnIdDesign"
        Me.GridColumnIdDesign.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        Me.GridColumnIdProduct.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSalesOrderDet
        '
        Me.GridColumnIdSalesOrderDet.Caption = "Id Sales Order Det"
        Me.GridColumnIdSalesOrderDet.FieldName = "id_sales_return_order_det"
        Me.GridColumnIdSalesOrderDet.Name = "GridColumnIdSalesOrderDet"
        Me.GridColumnIdSalesOrderDet.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSalesOrderDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnProductName
        '
        Me.GridColumnProductName.Caption = "Product Name"
        Me.GridColumnProductName.FieldName = "product_name"
        Me.GridColumnProductName.Name = "GridColumnProductName"
        '
        'GridColumnIdReturnCat
        '
        Me.GridColumnIdReturnCat.Caption = "GridColumnIdReturnCat"
        Me.GridColumnIdReturnCat.FieldName = "id_return_cat"
        Me.GridColumnIdReturnCat.Name = "GridColumnIdReturnCat"
        '
        'GridColumnIdDesignPrice
        '
        Me.GridColumnIdDesignPrice.Caption = "Id Design Price"
        Me.GridColumnIdDesignPrice.FieldName = "id_design_price"
        Me.GridColumnIdDesignPrice.Name = "GridColumnIdDesignPrice"
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.Visible = True
        Me.GridColumnPriceType.VisibleIndex = 4
        '
        'FormPopUpSalesReturnOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 499)
        Me.Controls.Add(Me.SCCReturnOrder)
        Me.Controls.Add(Me.PCNav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpSalesReturnOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Return Order"
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCNav.ResumeLayout(False)
        CType(Me.SCCReturnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCReturnOrder.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCSalesReturnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesReturnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PCNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SCCReturnOrder As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSalesReturnOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesReturnOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSalesTargetNumb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesTargetDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDSalesTargetNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesTarget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReturnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesOrderDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReturnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesignPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrepStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSvcLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
End Class
