<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormWHSvcLevel
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.XTCSvcLelel = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBySO = New DevExpress.XtraTab.XtraTabPage()
        Me.GCBySO = New DevExpress.XtraGrid.GridControl()
        Me.GVBySO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnPrepNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOnlineOrderDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrepDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDsgName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnScannedQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDelQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDiffSc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDiff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_amo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnscan_amo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndel_amo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnscan_diff_amo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndel_diff_amo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncommerce_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnExportToXLSSO = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPByCode = New DevExpress.XtraTab.XtraTabPage()
        Me.GCByCode = New DevExpress.XtraGrid.GridControl()
        Me.GVByCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBandGeneral = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPrice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandOrderByCode = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnOrderAmount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandDelByCode = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDelAmount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSvcLevelByCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GroupControlByCode = New DevExpress.XtraEditors.GroupControl()
        Me.TxtDesign = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDesignCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnViewCode = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilCode = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromCode = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPByAcc = New DevExpress.XtraTab.XtraTabPage()
        Me.GCByAcco = New DevExpress.XtraGrid.GridControl()
        Me.GVByAcco = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBandAcc = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnAccCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAcc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDEst = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandorder = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnScanQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiffQtyScan = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSLScan = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandDEL = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnDelQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSL = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GVByAcc = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControlByAccount = New DevExpress.XtraEditors.GroupControl()
        Me.TxtComp = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCompID = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnAcc = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilAcc = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromAcc = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPByReturn = New DevExpress.XtraTab.XtraTabPage()
        Me.GCReturn = New DevExpress.XtraGrid.GridControl()
        Me.GVReturn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprepare_statusror = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfinal_comment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.CEHighlightNonList = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnViewReturn = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilReturn = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromReturn = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCSvcLelel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSvcLelel.SuspendLayout()
        Me.XTPBySO.SuspendLayout()
        CType(Me.GCBySO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBySO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPByCode.SuspendLayout()
        CType(Me.GCByCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVByCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlByCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlByCode.SuspendLayout()
        CType(Me.TxtDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDesignCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilCode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromCode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPByAcc.SuspendLayout()
        CType(Me.GCByAcco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVByAcco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVByAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlByAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlByAccount.SuspendLayout()
        CType(Me.TxtComp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCompID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilAcc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromAcc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPByReturn.SuspendLayout()
        CType(Me.GCReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.CEHighlightNonList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilReturn.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilReturn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromReturn.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromReturn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCSvcLelel
        '
        Me.XTCSvcLelel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSvcLelel.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSvcLelel.Location = New System.Drawing.Point(0, 0)
        Me.XTCSvcLelel.Name = "XTCSvcLelel"
        Me.XTCSvcLelel.SelectedTabPage = Me.XTPBySO
        Me.XTCSvcLelel.Size = New System.Drawing.Size(1228, 364)
        Me.XTCSvcLelel.TabIndex = 0
        Me.XTCSvcLelel.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBySO, Me.XTPByCode, Me.XTPByAcc, Me.XTPByReturn})
        '
        'XTPBySO
        '
        Me.XTPBySO.Controls.Add(Me.GCBySO)
        Me.XTPBySO.Controls.Add(Me.GCFilter)
        Me.XTPBySO.Name = "XTPBySO"
        Me.XTPBySO.Size = New System.Drawing.Size(1222, 336)
        Me.XTPBySO.Text = "Prepare Order"
        '
        'GCBySO
        '
        Me.GCBySO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBySO.Location = New System.Drawing.Point(0, 39)
        Me.GCBySO.MainView = Me.GVBySO
        Me.GCBySO.Name = "GCBySO"
        Me.GCBySO.Size = New System.Drawing.Size(1222, 297)
        Me.GCBySO.TabIndex = 4
        Me.GCBySO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBySO})
        '
        'GVBySO
        '
        Me.GVBySO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnPrepNumber, Me.GridColumnOnlineOrderDate, Me.GridColumnPrepDate, Me.GridColumnBarcode, Me.GridColumnDesignCode, Me.GridColumnClass, Me.GridColumnDsgName, Me.GridColumnSize, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumnOrderQty, Me.GridColumnScannedQty, Me.GridColumnDelQty, Me.GridColumnDiffSc, Me.GridColumnDiff, Me.GridColumnCat, Me.GridColumnReff, Me.GridColumnStatus, Me.GridColumnNote, Me.GridColumnorder_type, Me.GridColumndesign_price, Me.GridColumnorder_amo, Me.GridColumnscan_amo, Me.GridColumndel_amo, Me.GridColumnscan_diff_amo, Me.GridColumndel_diff_amo, Me.GridColumncommerce_type, Me.GridColumn15, Me.GridColumn20, Me.GridColumncomp_group, Me.GridColumncomp_group_desc})
        Me.GVBySO.GridControl = Me.GCBySO
        Me.GVBySO.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_qty", Me.GridColumnOrderQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_sales_order_del_det_qty", Me.GridColumnDelQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_sales_order_del_det_qty_sc", Me.GridColumnScannedQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_qty", Me.GridColumnDiff, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_diff_qty", Me.GridColumnDiffSc, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_amo", Me.GridColumnorder_amo, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_amo", Me.GridColumnscan_amo, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_amo", Me.GridColumndel_amo, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_diff_amo", Me.GridColumnscan_diff_amo, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_diff_amo", Me.GridColumndel_diff_amo, "{0:N0}")})
        Me.GVBySO.Name = "GVBySO"
        Me.GVBySO.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVBySO.OptionsBehavior.Editable = False
        Me.GVBySO.OptionsView.ColumnAutoWidth = False
        Me.GVBySO.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVBySO.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVBySO.OptionsView.ShowFooter = True
        Me.GVBySO.OptionsView.ShowGroupPanel = False
        '
        'GridColumnPrepNumber
        '
        Me.GridColumnPrepNumber.Caption = "Prepare Order#"
        Me.GridColumnPrepNumber.FieldName = "sales_order_number"
        Me.GridColumnPrepNumber.Name = "GridColumnPrepNumber"
        Me.GridColumnPrepNumber.Visible = True
        Me.GridColumnPrepNumber.VisibleIndex = 0
        '
        'GridColumnOnlineOrderDate
        '
        Me.GridColumnOnlineOrderDate.Caption = "Online Order Date"
        Me.GridColumnOnlineOrderDate.DisplayFormat.FormatString = "dd\/MM\/yyyy HH:mm:ss"
        Me.GridColumnOnlineOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnOnlineOrderDate.FieldName = "sales_order_ol_shop_date"
        Me.GridColumnOnlineOrderDate.Name = "GridColumnOnlineOrderDate"
        Me.GridColumnOnlineOrderDate.Visible = True
        Me.GridColumnOnlineOrderDate.VisibleIndex = 3
        '
        'GridColumnPrepDate
        '
        Me.GridColumnPrepDate.Caption = "Date"
        Me.GridColumnPrepDate.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnPrepDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPrepDate.FieldName = "sales_order_date"
        Me.GridColumnPrepDate.Name = "GridColumnPrepDate"
        Me.GridColumnPrepDate.Visible = True
        Me.GridColumnPrepDate.VisibleIndex = 4
        '
        'GridColumnBarcode
        '
        Me.GridColumnBarcode.Caption = "Barcode"
        Me.GridColumnBarcode.FieldName = "product_full_code"
        Me.GridColumnBarcode.Name = "GridColumnBarcode"
        Me.GridColumnBarcode.Visible = True
        Me.GridColumnBarcode.VisibleIndex = 6
        '
        'GridColumnDesignCode
        '
        Me.GridColumnDesignCode.Caption = "Code"
        Me.GridColumnDesignCode.FieldName = "design_code"
        Me.GridColumnDesignCode.Name = "GridColumnDesignCode"
        Me.GridColumnDesignCode.Visible = True
        Me.GridColumnDesignCode.VisibleIndex = 7
        '
        'GridColumnClass
        '
        Me.GridColumnClass.Caption = "Class"
        Me.GridColumnClass.FieldName = "class_display"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.Visible = True
        Me.GridColumnClass.VisibleIndex = 8
        '
        'GridColumnDsgName
        '
        Me.GridColumnDsgName.Caption = "Description"
        Me.GridColumnDsgName.FieldName = "design_display_name"
        Me.GridColumnDsgName.Name = "GridColumnDsgName"
        Me.GridColumnDsgName.Visible = True
        Me.GridColumnDsgName.VisibleIndex = 9
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 12
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "comp_name_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 13
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "comp_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 14
        '
        'GridColumnOrderQty
        '
        Me.GridColumnOrderQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOrderQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrderQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOrderQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrderQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnOrderQty.Caption = "Ordered Qty"
        Me.GridColumnOrderQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnOrderQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOrderQty.FieldName = "sales_order_det_qty"
        Me.GridColumnOrderQty.Name = "GridColumnOrderQty"
        Me.GridColumnOrderQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_qty", "{0:n0}")})
        Me.GridColumnOrderQty.Visible = True
        Me.GridColumnOrderQty.VisibleIndex = 19
        Me.GridColumnOrderQty.Width = 49
        '
        'GridColumnScannedQty
        '
        Me.GridColumnScannedQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnScannedQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnScannedQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnScannedQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnScannedQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnScannedQty.Caption = "Scanned Qty"
        Me.GridColumnScannedQty.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnScannedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnScannedQty.FieldName = "pl_sales_order_del_det_qty_sc"
        Me.GridColumnScannedQty.Name = "GridColumnScannedQty"
        Me.GridColumnScannedQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_sales_order_del_det_qty_sc", "{0:n0}")})
        Me.GridColumnScannedQty.Visible = True
        Me.GridColumnScannedQty.VisibleIndex = 20
        Me.GridColumnScannedQty.Width = 65
        '
        'GridColumnDelQty
        '
        Me.GridColumnDelQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDelQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDelQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDelQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDelQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnDelQty.Caption = "Delivered Qty"
        Me.GridColumnDelQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnDelQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDelQty.FieldName = "pl_sales_order_del_det_qty"
        Me.GridColumnDelQty.Name = "GridColumnDelQty"
        Me.GridColumnDelQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_sales_order_del_det_qty", "{0:n0}")})
        Me.GridColumnDelQty.Visible = True
        Me.GridColumnDelQty.VisibleIndex = 21
        Me.GridColumnDelQty.Width = 64
        '
        'GridColumnDiffSc
        '
        Me.GridColumnDiffSc.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDiffSc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiffSc.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDiffSc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiffSc.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnDiffSc.Caption = "Scan Diff"
        Me.GridColumnDiffSc.DisplayFormat.FormatString = "N0"
        Me.GridColumnDiffSc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDiffSc.FieldName = "scan_diff_qty"
        Me.GridColumnDiffSc.Name = "GridColumnDiffSc"
        Me.GridColumnDiffSc.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_diff_qty", "{0:N0}")})
        Me.GridColumnDiffSc.UnboundExpression = "[sales_order_det_qty] - [pl_sales_order_del_det_qty_sc]"
        Me.GridColumnDiffSc.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnDiffSc.Visible = True
        Me.GridColumnDiffSc.VisibleIndex = 22
        Me.GridColumnDiffSc.Width = 50
        '
        'GridColumnDiff
        '
        Me.GridColumnDiff.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiff.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDiff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiff.Caption = "Del Diff"
        Me.GridColumnDiff.DisplayFormat.FormatString = "N0"
        Me.GridColumnDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDiff.FieldName = "diff_qty"
        Me.GridColumnDiff.Name = "GridColumnDiff"
        Me.GridColumnDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_qty", "{0:n0}")})
        Me.GridColumnDiff.UnboundExpression = "[sales_order_det_qty] - [pl_sales_order_del_det_qty]"
        Me.GridColumnDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnDiff.Visible = True
        Me.GridColumnDiff.VisibleIndex = 23
        Me.GridColumnDiff.Width = 43
        '
        'GridColumnCat
        '
        Me.GridColumnCat.Caption = "Category"
        Me.GridColumnCat.FieldName = "so_status"
        Me.GridColumnCat.Name = "GridColumnCat"
        Me.GridColumnCat.Visible = True
        Me.GridColumnCat.VisibleIndex = 5
        '
        'GridColumnReff
        '
        Me.GridColumnReff.Caption = "Reference"
        Me.GridColumnReff.FieldName = "sales_order_gen_reff"
        Me.GridColumnReff.Name = "GridColumnReff"
        Me.GridColumnReff.Visible = True
        Me.GridColumnReff.VisibleIndex = 2
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "prepare_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 29
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "final_comment"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 30
        '
        'GridColumnorder_type
        '
        Me.GridColumnorder_type.Caption = "Type"
        Me.GridColumnorder_type.FieldName = "order_type"
        Me.GridColumnorder_type.Name = "GridColumnorder_type"
        Me.GridColumnorder_type.Visible = True
        Me.GridColumnorder_type.VisibleIndex = 1
        '
        'GridColumndesign_price
        '
        Me.GridColumndesign_price.Caption = "Unit Price"
        Me.GridColumndesign_price.DisplayFormat.FormatString = "N0"
        Me.GridColumndesign_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndesign_price.FieldName = "design_price"
        Me.GridColumndesign_price.Name = "GridColumndesign_price"
        Me.GridColumndesign_price.Visible = True
        Me.GridColumndesign_price.VisibleIndex = 18
        '
        'GridColumnorder_amo
        '
        Me.GridColumnorder_amo.Caption = "Order Amount"
        Me.GridColumnorder_amo.DisplayFormat.FormatString = "N0"
        Me.GridColumnorder_amo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnorder_amo.FieldName = "order_amo"
        Me.GridColumnorder_amo.Name = "GridColumnorder_amo"
        Me.GridColumnorder_amo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_amo", "{0:N0}")})
        Me.GridColumnorder_amo.UnboundExpression = "[design_price] * [sales_order_det_qty]"
        Me.GridColumnorder_amo.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnorder_amo.Visible = True
        Me.GridColumnorder_amo.VisibleIndex = 24
        '
        'GridColumnscan_amo
        '
        Me.GridColumnscan_amo.Caption = "Scan Amount"
        Me.GridColumnscan_amo.DisplayFormat.FormatString = "N0"
        Me.GridColumnscan_amo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnscan_amo.FieldName = "scan_amo"
        Me.GridColumnscan_amo.Name = "GridColumnscan_amo"
        Me.GridColumnscan_amo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_amo", "{0:N0}")})
        Me.GridColumnscan_amo.UnboundExpression = "[design_price] * [pl_sales_order_del_det_qty_sc]"
        Me.GridColumnscan_amo.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnscan_amo.Visible = True
        Me.GridColumnscan_amo.VisibleIndex = 25
        '
        'GridColumndel_amo
        '
        Me.GridColumndel_amo.Caption = "Del Amount"
        Me.GridColumndel_amo.DisplayFormat.FormatString = "N0"
        Me.GridColumndel_amo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndel_amo.FieldName = "del_amo"
        Me.GridColumndel_amo.Name = "GridColumndel_amo"
        Me.GridColumndel_amo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_amo", "{0:N0}")})
        Me.GridColumndel_amo.UnboundExpression = "[design_price] * [pl_sales_order_del_det_qty]"
        Me.GridColumndel_amo.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumndel_amo.Visible = True
        Me.GridColumndel_amo.VisibleIndex = 26
        '
        'GridColumnscan_diff_amo
        '
        Me.GridColumnscan_diff_amo.Caption = "Scan Diff Amount"
        Me.GridColumnscan_diff_amo.DisplayFormat.FormatString = "N0"
        Me.GridColumnscan_diff_amo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnscan_diff_amo.FieldName = "scan_diff_amo"
        Me.GridColumnscan_diff_amo.Name = "GridColumnscan_diff_amo"
        Me.GridColumnscan_diff_amo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_diff_amo", "{0:N0}")})
        Me.GridColumnscan_diff_amo.UnboundExpression = "[design_price] * [scan_diff_qty]"
        Me.GridColumnscan_diff_amo.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnscan_diff_amo.Visible = True
        Me.GridColumnscan_diff_amo.VisibleIndex = 27
        '
        'GridColumndel_diff_amo
        '
        Me.GridColumndel_diff_amo.Caption = "Del Diff Amount"
        Me.GridColumndel_diff_amo.DisplayFormat.FormatString = "N0"
        Me.GridColumndel_diff_amo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndel_diff_amo.FieldName = "del_diff_amo"
        Me.GridColumndel_diff_amo.Name = "GridColumndel_diff_amo"
        Me.GridColumndel_diff_amo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_diff_amo", "{0:N0}")})
        Me.GridColumndel_diff_amo.UnboundExpression = "[design_price] * [diff_qty]"
        Me.GridColumndel_diff_amo.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumndel_diff_amo.Visible = True
        Me.GridColumndel_diff_amo.VisibleIndex = 28
        '
        'GridColumncommerce_type
        '
        Me.GridColumncommerce_type.Caption = "Commerce Type"
        Me.GridColumncommerce_type.FieldName = "commerce_type"
        Me.GridColumncommerce_type.Name = "GridColumncommerce_type"
        Me.GridColumncommerce_type.Visible = True
        Me.GridColumncommerce_type.VisibleIndex = 15
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Color"
        Me.GridColumn15.FieldName = "color"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 11
        Me.GridColumn15.Width = 60
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Silhouette"
        Me.GridColumn20.FieldName = "sht"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 10
        Me.GridColumn20.Width = 111
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Acc. Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 16
        '
        'GridColumncomp_group_desc
        '
        Me.GridColumncomp_group_desc.Caption = "Acc. Group Descr."
        Me.GridColumncomp_group_desc.FieldName = "comp_group_desc"
        Me.GridColumncomp_group_desc.Name = "GridColumncomp_group_desc"
        Me.GridColumncomp_group_desc.Visible = True
        Me.GridColumncomp_group_desc.VisibleIndex = 17
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnExportToXLSSO)
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Controls.Add(Me.DEUntil)
        Me.GCFilter.Controls.Add(Me.DEFrom)
        Me.GCFilter.Controls.Add(Me.LabelControl2)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(1222, 39)
        Me.GCFilter.TabIndex = 3
        '
        'BtnExportToXLSSO
        '
        Me.BtnExportToXLSSO.Location = New System.Drawing.Point(400, 9)
        Me.BtnExportToXLSSO.LookAndFeel.SkinName = "Blue"
        Me.BtnExportToXLSSO.Name = "BtnExportToXLSSO"
        Me.BtnExportToXLSSO.Size = New System.Drawing.Size(92, 20)
        Me.BtnExportToXLSSO.TabIndex = 8901
        Me.BtnExportToXLSSO.Text = "Export to XLS"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(320, 9)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(1111, 11)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(1008, 11)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(202, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(58, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'XTPByCode
        '
        Me.XTPByCode.Controls.Add(Me.GCByCode)
        Me.XTPByCode.Controls.Add(Me.GroupControlByCode)
        Me.XTPByCode.Name = "XTPByCode"
        Me.XTPByCode.Size = New System.Drawing.Size(1222, 336)
        Me.XTPByCode.Text = "Prepare Order By Code"
        '
        'GCByCode
        '
        Me.GCByCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCByCode.Location = New System.Drawing.Point(0, 39)
        Me.GCByCode.MainView = Me.GVByCode
        Me.GCByCode.Name = "GCByCode"
        Me.GCByCode.Size = New System.Drawing.Size(1222, 297)
        Me.GCByCode.TabIndex = 5
        Me.GCByCode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVByCode})
        '
        'GVByCode
        '
        Me.GVByCode.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBandGeneral, Me.gridBandOrderByCode, Me.gridBandDelByCode})
        Me.GVByCode.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn10, Me.BandedGridColumnOrderAmount, Me.GridColumn11, Me.BandedGridColumnDelAmount, Me.BandedGridColumnPrice, Me.BandedGridColumnSvcLevelByCode, Me.BandedGridColumn2, Me.BandedGridColumn3})
        Me.GVByCode.GridControl = Me.GCByCode
        Me.GVByCode.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_qty", Me.GridColumn10, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_amount", Me.BandedGridColumnOrderAmount, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_sales_order_del_det_qty", Me.GridColumn11, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_sales_order_del_det_amount", Me.BandedGridColumnDelAmount, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "svc_level", Me.BandedGridColumnSvcLevelByCode, "{0:N2}")})
        Me.GVByCode.Name = "GVByCode"
        Me.GVByCode.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVByCode.OptionsBehavior.Editable = False
        Me.GVByCode.OptionsView.ColumnAutoWidth = False
        Me.GVByCode.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVByCode.OptionsView.ShowFooter = True
        Me.GVByCode.OptionsView.ShowGroupPanel = False
        '
        'GridBandGeneral
        '
        Me.GridBandGeneral.Columns.Add(Me.GridColumn3)
        Me.GridBandGeneral.Columns.Add(Me.GridColumn4)
        Me.GridBandGeneral.Columns.Add(Me.GridColumn5)
        Me.GridBandGeneral.Columns.Add(Me.GridColumn6)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumn3)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumn2)
        Me.GridBandGeneral.Columns.Add(Me.GridColumn7)
        Me.GridBandGeneral.Columns.Add(Me.BandedGridColumnPrice)
        Me.GridBandGeneral.Name = "GridBandGeneral"
        Me.GridBandGeneral.VisibleIndex = 0
        Me.GridBandGeneral.Width = 635
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Barcode"
        Me.GridColumn3.FieldName = "product_full_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Code"
        Me.GridColumn4.FieldName = "design_code"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Class"
        Me.GridColumn5.FieldName = "class_display"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Description"
        Me.GridColumn6.FieldName = "design_display_name"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Silhouette"
        Me.BandedGridColumn3.FieldName = "sht"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        Me.BandedGridColumn3.Width = 110
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Color"
        Me.BandedGridColumn2.FieldName = "color"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Size"
        Me.GridColumn7.FieldName = "size"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        '
        'BandedGridColumnPrice
        '
        Me.BandedGridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPrice.Caption = "Price"
        Me.BandedGridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPrice.FieldName = "design_price"
        Me.BandedGridColumnPrice.Name = "BandedGridColumnPrice"
        Me.BandedGridColumnPrice.Visible = True
        '
        'gridBandOrderByCode
        '
        Me.gridBandOrderByCode.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBandOrderByCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBandOrderByCode.Caption = "ORDER"
        Me.gridBandOrderByCode.Columns.Add(Me.GridColumn10)
        Me.gridBandOrderByCode.Columns.Add(Me.BandedGridColumnOrderAmount)
        Me.gridBandOrderByCode.Name = "gridBandOrderByCode"
        Me.gridBandOrderByCode.VisibleIndex = 1
        Me.gridBandOrderByCode.Width = 124
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn10.Caption = "Order Qty"
        Me.GridColumn10.DisplayFormat.FormatString = "N0"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "sales_order_det_qty"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_qty", "{0:n0}")})
        Me.GridColumn10.Visible = True
        Me.GridColumn10.Width = 49
        '
        'BandedGridColumnOrderAmount
        '
        Me.BandedGridColumnOrderAmount.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnOrderAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnOrderAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnOrderAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnOrderAmount.Caption = "Amount"
        Me.BandedGridColumnOrderAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnOrderAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnOrderAmount.FieldName = "sales_order_det_amount"
        Me.BandedGridColumnOrderAmount.Name = "BandedGridColumnOrderAmount"
        Me.BandedGridColumnOrderAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_amount", "{0:n2}")})
        Me.BandedGridColumnOrderAmount.Visible = True
        '
        'gridBandDelByCode
        '
        Me.gridBandDelByCode.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBandDelByCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBandDelByCode.Caption = "DELIVERY"
        Me.gridBandDelByCode.Columns.Add(Me.GridColumn11)
        Me.gridBandDelByCode.Columns.Add(Me.BandedGridColumnDelAmount)
        Me.gridBandDelByCode.Columns.Add(Me.BandedGridColumnSvcLevelByCode)
        Me.gridBandDelByCode.Name = "gridBandDelByCode"
        Me.gridBandDelByCode.VisibleIndex = 2
        Me.gridBandDelByCode.Width = 206
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn11.Caption = "Delivery Qty"
        Me.GridColumn11.DisplayFormat.FormatString = "N0"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "pl_sales_order_del_det_qty"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_sales_order_del_det_qty", "{0:n0}")})
        Me.GridColumn11.Visible = True
        Me.GridColumn11.Width = 56
        '
        'BandedGridColumnDelAmount
        '
        Me.BandedGridColumnDelAmount.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDelAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDelAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDelAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDelAmount.Caption = "Amount"
        Me.BandedGridColumnDelAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnDelAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDelAmount.FieldName = "pl_sales_order_del_det_amount"
        Me.BandedGridColumnDelAmount.Name = "BandedGridColumnDelAmount"
        Me.BandedGridColumnDelAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_sales_order_del_det_amount", "{0:n2}")})
        Me.BandedGridColumnDelAmount.Visible = True
        '
        'BandedGridColumnSvcLevelByCode
        '
        Me.BandedGridColumnSvcLevelByCode.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnSvcLevelByCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSvcLevelByCode.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnSvcLevelByCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSvcLevelByCode.Caption = "SL (%)"
        Me.BandedGridColumnSvcLevelByCode.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnSvcLevelByCode.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnSvcLevelByCode.FieldName = "svc_level"
        Me.BandedGridColumnSvcLevelByCode.Name = "BandedGridColumnSvcLevelByCode"
        Me.BandedGridColumnSvcLevelByCode.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "svc_level", "{0:n2}")})
        Me.BandedGridColumnSvcLevelByCode.Visible = True
        '
        'GroupControlByCode
        '
        Me.GroupControlByCode.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlByCode.Controls.Add(Me.TxtDesign)
        Me.GroupControlByCode.Controls.Add(Me.TxtDesignCode)
        Me.GroupControlByCode.Controls.Add(Me.LabelControl9)
        Me.GroupControlByCode.Controls.Add(Me.BtnViewCode)
        Me.GroupControlByCode.Controls.Add(Me.SimpleButton4)
        Me.GroupControlByCode.Controls.Add(Me.SimpleButton5)
        Me.GroupControlByCode.Controls.Add(Me.DEUntilCode)
        Me.GroupControlByCode.Controls.Add(Me.DEFromCode)
        Me.GroupControlByCode.Controls.Add(Me.LabelControl5)
        Me.GroupControlByCode.Controls.Add(Me.LabelControl6)
        Me.GroupControlByCode.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControlByCode.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlByCode.Name = "GroupControlByCode"
        Me.GroupControlByCode.Size = New System.Drawing.Size(1222, 39)
        Me.GroupControlByCode.TabIndex = 4
        '
        'TxtDesign
        '
        Me.TxtDesign.EditValue = ""
        Me.TxtDesign.Enabled = False
        Me.TxtDesign.Location = New System.Drawing.Point(135, 9)
        Me.TxtDesign.Name = "TxtDesign"
        Me.TxtDesign.Size = New System.Drawing.Size(283, 20)
        Me.TxtDesign.TabIndex = 8901
        '
        'TxtDesignCode
        '
        Me.TxtDesignCode.EditValue = ""
        Me.TxtDesignCode.Location = New System.Drawing.Point(61, 9)
        Me.TxtDesignCode.Name = "TxtDesignCode"
        Me.TxtDesignCode.Size = New System.Drawing.Size(72, 20)
        Me.TxtDesignCode.TabIndex = 8900
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(23, 12)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl9.TabIndex = 8899
        Me.LabelControl9.Text = "Design"
        '
        'BtnViewCode
        '
        Me.BtnViewCode.Location = New System.Drawing.Point(711, 9)
        Me.BtnViewCode.LookAndFeel.SkinName = "Blue"
        Me.BtnViewCode.Name = "BtnViewCode"
        Me.BtnViewCode.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewCode.TabIndex = 8896
        Me.BtnViewCode.Text = "View"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.ImageIndex = 9
        Me.SimpleButton4.Location = New System.Drawing.Point(1008, 14)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(104, 20)
        Me.SimpleButton4.TabIndex = 8898
        Me.SimpleButton4.Text = "Hide All Detail"
        Me.SimpleButton4.Visible = False
        '
        'SimpleButton5
        '
        Me.SimpleButton5.ImageIndex = 8
        Me.SimpleButton5.Location = New System.Drawing.Point(1118, 14)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(99, 20)
        Me.SimpleButton5.TabIndex = 8897
        Me.SimpleButton5.Text = "Expand All Detail"
        Me.SimpleButton5.Visible = False
        '
        'DEUntilCode
        '
        Me.DEUntilCode.EditValue = Nothing
        Me.DEUntilCode.Location = New System.Drawing.Point(596, 9)
        Me.DEUntilCode.Name = "DEUntilCode"
        Me.DEUntilCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilCode.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilCode.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilCode.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilCode.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilCode.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilCode.TabIndex = 8895
        '
        'DEFromCode
        '
        Me.DEFromCode.EditValue = Nothing
        Me.DEFromCode.Location = New System.Drawing.Point(452, 9)
        Me.DEFromCode.Name = "DEFromCode"
        Me.DEFromCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromCode.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromCode.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromCode.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromCode.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromCode.Size = New System.Drawing.Size(111, 20)
        Me.DEFromCode.TabIndex = 8894
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(569, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl5.TabIndex = 8893
        Me.LabelControl5.Text = "Until"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(422, 12)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl6.TabIndex = 8892
        Me.LabelControl6.Text = "From"
        '
        'XTPByAcc
        '
        Me.XTPByAcc.Controls.Add(Me.GCByAcco)
        Me.XTPByAcc.Controls.Add(Me.GroupControlByAccount)
        Me.XTPByAcc.Name = "XTPByAcc"
        Me.XTPByAcc.Size = New System.Drawing.Size(1222, 336)
        Me.XTPByAcc.Text = "Prepare Order By Account"
        '
        'GCByAcco
        '
        Me.GCByAcco.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCByAcco.Location = New System.Drawing.Point(0, 39)
        Me.GCByAcco.MainView = Me.GVByAcco
        Me.GCByAcco.Name = "GCByAcco"
        Me.GCByAcco.Size = New System.Drawing.Size(1222, 297)
        Me.GCByAcco.TabIndex = 5
        Me.GCByAcco.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVByAcco, Me.GVByAcc})
        '
        'GVByAcco
        '
        Me.GVByAcco.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBandAcc, Me.gridBandorder, Me.gridBand1, Me.gridBandDEL})
        Me.GVByAcco.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnAccCode, Me.BandedGridColumnAcc, Me.BandedGridColumn1, Me.BandedGridColumnDelQty, Me.BandedGridColumnDiff, Me.BandedGridColumnSL, Me.BandedGridColumnSO, Me.BandedGridColumnDEst, Me.BandedGridColumnScanQty, Me.BandedGridColumnDiffQtyScan, Me.BandedGridColumnSLScan})
        Me.GVByAcco.GridControl = Me.GCByAcco
        Me.GVByAcco.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_qty", Me.BandedGridColumn1, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_qty", Me.BandedGridColumnDelQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_qty", Me.BandedGridColumnDiff, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "svc_level", Me.BandedGridColumnSL, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_qty", Me.BandedGridColumnScanQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_diff_qty", Me.BandedGridColumnDiffQtyScan, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_svc_level", Me.BandedGridColumnSLScan, "{0:N2}")})
        Me.GVByAcco.Name = "GVByAcco"
        Me.GVByAcco.OptionsBehavior.Editable = False
        Me.GVByAcco.OptionsView.ColumnAutoWidth = False
        Me.GVByAcco.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVByAcco.OptionsView.ShowFooter = True
        Me.GVByAcco.OptionsView.ShowGroupPanel = False
        '
        'gridBandAcc
        '
        Me.gridBandAcc.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBandAcc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBandAcc.Columns.Add(Me.BandedGridColumnAccCode)
        Me.gridBandAcc.Columns.Add(Me.BandedGridColumnAcc)
        Me.gridBandAcc.Columns.Add(Me.BandedGridColumnDEst)
        Me.gridBandAcc.Columns.Add(Me.BandedGridColumnSO)
        Me.gridBandAcc.Name = "gridBandAcc"
        Me.gridBandAcc.VisibleIndex = 0
        Me.gridBandAcc.Width = 300
        '
        'BandedGridColumnAccCode
        '
        Me.BandedGridColumnAccCode.Caption = "Account Code"
        Me.BandedGridColumnAccCode.FieldName = "comp_number"
        Me.BandedGridColumnAccCode.Name = "BandedGridColumnAccCode"
        Me.BandedGridColumnAccCode.Visible = True
        '
        'BandedGridColumnAcc
        '
        Me.BandedGridColumnAcc.Caption = "Account"
        Me.BandedGridColumnAcc.FieldName = "comp_name"
        Me.BandedGridColumnAcc.Name = "BandedGridColumnAcc"
        Me.BandedGridColumnAcc.Visible = True
        '
        'BandedGridColumnDEst
        '
        Me.BandedGridColumnDEst.Caption = "Destination"
        Me.BandedGridColumnDEst.FieldName = "awb_destination"
        Me.BandedGridColumnDEst.Name = "BandedGridColumnDEst"
        Me.BandedGridColumnDEst.Visible = True
        '
        'BandedGridColumnSO
        '
        Me.BandedGridColumnSO.Caption = "Prepare Order"
        Me.BandedGridColumnSO.FieldName = "sales_order_number"
        Me.BandedGridColumnSO.FieldNameSortGroup = "id_sales_order"
        Me.BandedGridColumnSO.Name = "BandedGridColumnSO"
        Me.BandedGridColumnSO.Visible = True
        '
        'gridBandorder
        '
        Me.gridBandorder.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBandorder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBandorder.Caption = "ORDER"
        Me.gridBandorder.Columns.Add(Me.BandedGridColumn1)
        Me.gridBandorder.Name = "gridBandorder"
        Me.gridBandorder.VisibleIndex = 1
        Me.gridBandorder.Width = 51
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumn1.Caption = "Order Qty"
        Me.BandedGridColumn1.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn1.FieldName = "order_qty"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_qty", "{0:n0}")})
        Me.BandedGridColumn1.Visible = True
        Me.BandedGridColumn1.Width = 51
        '
        'gridBand1
        '
        Me.gridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand1.Caption = "SCAN"
        Me.gridBand1.Columns.Add(Me.BandedGridColumnScanQty)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnDiffQtyScan)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnSLScan)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 2
        Me.gridBand1.Width = 225
        '
        'BandedGridColumnScanQty
        '
        Me.BandedGridColumnScanQty.Caption = "Scan Qty"
        Me.BandedGridColumnScanQty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnScanQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnScanQty.FieldName = "scan_qty"
        Me.BandedGridColumnScanQty.Name = "BandedGridColumnScanQty"
        Me.BandedGridColumnScanQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_qty", "{0:N0}")})
        Me.BandedGridColumnScanQty.Visible = True
        '
        'BandedGridColumnDiffQtyScan
        '
        Me.BandedGridColumnDiffQtyScan.Caption = "Diff Qty"
        Me.BandedGridColumnDiffQtyScan.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnDiffQtyScan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffQtyScan.FieldName = "scan_diff_qty"
        Me.BandedGridColumnDiffQtyScan.Name = "BandedGridColumnDiffQtyScan"
        Me.BandedGridColumnDiffQtyScan.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_diff_qty", "{0:N0}")})
        Me.BandedGridColumnDiffQtyScan.Visible = True
        '
        'BandedGridColumnSLScan
        '
        Me.BandedGridColumnSLScan.Caption = "SL (%)"
        Me.BandedGridColumnSLScan.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnSLScan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnSLScan.FieldName = "scan_svc_level"
        Me.BandedGridColumnSLScan.Name = "BandedGridColumnSLScan"
        Me.BandedGridColumnSLScan.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "scan_svc_level", "{0:N2}")})
        Me.BandedGridColumnSLScan.Visible = True
        '
        'gridBandDEL
        '
        Me.gridBandDEL.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBandDEL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBandDEL.Caption = "DELIVERY"
        Me.gridBandDEL.Columns.Add(Me.BandedGridColumnDelQty)
        Me.gridBandDEL.Columns.Add(Me.BandedGridColumnDiff)
        Me.gridBandDEL.Columns.Add(Me.BandedGridColumnSL)
        Me.gridBandDEL.Name = "gridBandDEL"
        Me.gridBandDEL.VisibleIndex = 3
        Me.gridBandDEL.Width = 215
        '
        'BandedGridColumnDelQty
        '
        Me.BandedGridColumnDelQty.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDelQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDelQty.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDelQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDelQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnDelQty.Caption = "Delivery Qty"
        Me.BandedGridColumnDelQty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnDelQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDelQty.FieldName = "del_qty"
        Me.BandedGridColumnDelQty.Name = "BandedGridColumnDelQty"
        Me.BandedGridColumnDelQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_qty", "{0:n0}")})
        Me.BandedGridColumnDelQty.Visible = True
        Me.BandedGridColumnDelQty.Width = 60
        '
        'BandedGridColumnDiff
        '
        Me.BandedGridColumnDiff.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiff.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDiff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiff.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnDiff.Caption = "Diff Qty"
        Me.BandedGridColumnDiff.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiff.FieldName = "diff_qty"
        Me.BandedGridColumnDiff.Name = "BandedGridColumnDiff"
        Me.BandedGridColumnDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_qty", "{0:N0}")})
        Me.BandedGridColumnDiff.Visible = True
        Me.BandedGridColumnDiff.Width = 80
        '
        'BandedGridColumnSL
        '
        Me.BandedGridColumnSL.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnSL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSL.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnSL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSL.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnSL.Caption = "SL (%)"
        Me.BandedGridColumnSL.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnSL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnSL.FieldName = "svc_level"
        Me.BandedGridColumnSL.Name = "BandedGridColumnSL"
        Me.BandedGridColumnSL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "svc_level", "{0:N2}")})
        Me.BandedGridColumnSL.Visible = True
        '
        'GVByAcc
        '
        Me.GVByAcc.GridControl = Me.GCByAcco
        Me.GVByAcc.Name = "GVByAcc"
        '
        'GroupControlByAccount
        '
        Me.GroupControlByAccount.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlByAccount.Controls.Add(Me.TxtComp)
        Me.GroupControlByAccount.Controls.Add(Me.TxtCompID)
        Me.GroupControlByAccount.Controls.Add(Me.LabelControl10)
        Me.GroupControlByAccount.Controls.Add(Me.BtnAcc)
        Me.GroupControlByAccount.Controls.Add(Me.SimpleButton2)
        Me.GroupControlByAccount.Controls.Add(Me.SimpleButton3)
        Me.GroupControlByAccount.Controls.Add(Me.DEUntilAcc)
        Me.GroupControlByAccount.Controls.Add(Me.DEFromAcc)
        Me.GroupControlByAccount.Controls.Add(Me.LabelControl1)
        Me.GroupControlByAccount.Controls.Add(Me.LabelControl4)
        Me.GroupControlByAccount.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControlByAccount.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlByAccount.Name = "GroupControlByAccount"
        Me.GroupControlByAccount.Size = New System.Drawing.Size(1222, 39)
        Me.GroupControlByAccount.TabIndex = 4
        '
        'TxtComp
        '
        Me.TxtComp.EditValue = ""
        Me.TxtComp.Enabled = False
        Me.TxtComp.Location = New System.Drawing.Point(150, 9)
        Me.TxtComp.Name = "TxtComp"
        Me.TxtComp.Size = New System.Drawing.Size(283, 20)
        Me.TxtComp.TabIndex = 8904
        '
        'TxtCompID
        '
        Me.TxtCompID.EditValue = ""
        Me.TxtCompID.Location = New System.Drawing.Point(76, 9)
        Me.TxtCompID.Name = "TxtCompID"
        Me.TxtCompID.Size = New System.Drawing.Size(72, 20)
        Me.TxtCompID.TabIndex = 8903
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(26, 12)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl10.TabIndex = 8902
        Me.LabelControl10.Text = "Account"
        '
        'BtnAcc
        '
        Me.BtnAcc.Location = New System.Drawing.Point(728, 9)
        Me.BtnAcc.LookAndFeel.SkinName = "Blue"
        Me.BtnAcc.Name = "BtnAcc"
        Me.BtnAcc.Size = New System.Drawing.Size(75, 20)
        Me.BtnAcc.TabIndex = 8896
        Me.BtnAcc.Text = "View"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageIndex = 9
        Me.SimpleButton2.Location = New System.Drawing.Point(938, 14)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(104, 20)
        Me.SimpleButton2.TabIndex = 8898
        Me.SimpleButton2.Text = "Hide All Detail"
        Me.SimpleButton2.Visible = False
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageIndex = 8
        Me.SimpleButton3.Location = New System.Drawing.Point(835, 14)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(99, 20)
        Me.SimpleButton3.TabIndex = 8897
        Me.SimpleButton3.Text = "Expand All Detail"
        Me.SimpleButton3.Visible = False
        '
        'DEUntilAcc
        '
        Me.DEUntilAcc.EditValue = Nothing
        Me.DEUntilAcc.Location = New System.Drawing.Point(613, 9)
        Me.DEUntilAcc.Name = "DEUntilAcc"
        Me.DEUntilAcc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilAcc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilAcc.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilAcc.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilAcc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilAcc.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilAcc.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilAcc.TabIndex = 8895
        '
        'DEFromAcc
        '
        Me.DEFromAcc.EditValue = Nothing
        Me.DEFromAcc.Location = New System.Drawing.Point(469, 9)
        Me.DEFromAcc.Name = "DEFromAcc"
        Me.DEFromAcc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromAcc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromAcc.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromAcc.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromAcc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromAcc.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromAcc.Size = New System.Drawing.Size(111, 20)
        Me.DEFromAcc.TabIndex = 8894
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(586, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl1.TabIndex = 8893
        Me.LabelControl1.Text = "Until"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(439, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl4.TabIndex = 8892
        Me.LabelControl4.Text = "From"
        '
        'XTPByReturn
        '
        Me.XTPByReturn.Controls.Add(Me.GCReturn)
        Me.XTPByReturn.Controls.Add(Me.GroupControl1)
        Me.XTPByReturn.Name = "XTPByReturn"
        Me.XTPByReturn.Size = New System.Drawing.Size(1222, 336)
        Me.XTPByReturn.Text = "Return"
        '
        'GCReturn
        '
        Me.GCReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCReturn.Location = New System.Drawing.Point(0, 39)
        Me.GCReturn.MainView = Me.GVReturn
        Me.GCReturn.Name = "GCReturn"
        Me.GCReturn.Size = New System.Drawing.Size(1222, 297)
        Me.GCReturn.TabIndex = 5
        Me.GCReturn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReturn})
        '
        'GVReturn
        '
        Me.GVReturn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn8, Me.GridColumn9, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumnprepare_statusror, Me.GridColumnfinal_comment, Me.GridColumn21, Me.GridColumn22})
        Me.GVReturn.GridControl = Me.GCReturn
        Me.GVReturn.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_order_det_qty", Me.GridColumn17, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_det_qty", Me.GridColumn18, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_qty", Me.GridColumn19, "{0:N0}")})
        Me.GVReturn.Name = "GVReturn"
        Me.GVReturn.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVReturn.OptionsBehavior.Editable = False
        Me.GVReturn.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVReturn.OptionsView.ColumnAutoWidth = False
        Me.GVReturn.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVReturn.OptionsView.ShowFooter = True
        Me.GVReturn.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Return Order#"
        Me.GridColumn1.FieldName = "sales_return_order_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Date"
        Me.GridColumn2.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "sales_return_order_date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Barcode"
        Me.GridColumn8.FieldName = "product_full_code"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 2
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Code"
        Me.GridColumn9.FieldName = "design_code"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Class"
        Me.GridColumn12.FieldName = "class_display"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 4
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Description"
        Me.GridColumn13.FieldName = "design_display_name"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 5
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Size"
        Me.GridColumn14.FieldName = "size"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 8
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Store"
        Me.GridColumn16.FieldName = "comp_name_to"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 9
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn17.Caption = "Order Qty"
        Me.GridColumn17.DisplayFormat.FormatString = "N0"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "sales_return_order_det_qty"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_order_det_qty", "{0:n0}")})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 10
        Me.GridColumn17.Width = 49
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn18.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn18.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn18.Caption = "Return Qty"
        Me.GridColumn18.DisplayFormat.FormatString = "N0"
        Me.GridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn18.FieldName = "sales_return_det_qty"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_det_qty", "{0:n0}")})
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 11
        Me.GridColumn18.Width = 56
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.Caption = "Diff"
        Me.GridColumn19.DisplayFormat.FormatString = "N0"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "diff_qty"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.GridColumn19.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_qty", "{0:n0}")})
        Me.GridColumn19.UnboundExpression = "[sales_return_det_qty] - [sales_return_order_det_qty]"
        Me.GridColumn19.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 12
        '
        'GridColumnprepare_statusror
        '
        Me.GridColumnprepare_statusror.Caption = "Status"
        Me.GridColumnprepare_statusror.FieldName = "prepare_status"
        Me.GridColumnprepare_statusror.Name = "GridColumnprepare_statusror"
        Me.GridColumnprepare_statusror.Visible = True
        Me.GridColumnprepare_statusror.VisibleIndex = 13
        '
        'GridColumnfinal_comment
        '
        Me.GridColumnfinal_comment.Caption = "Note"
        Me.GridColumnfinal_comment.FieldName = "final_comment"
        Me.GridColumnfinal_comment.Name = "GridColumnfinal_comment"
        Me.GridColumnfinal_comment.Visible = True
        Me.GridColumnfinal_comment.VisibleIndex = 14
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Color"
        Me.GridColumn21.FieldName = "color"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 7
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Silhouette"
        Me.GridColumn22.FieldName = "sht"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 6
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.CEHighlightNonList)
        Me.GroupControl1.Controls.Add(Me.BtnViewReturn)
        Me.GroupControl1.Controls.Add(Me.SimpleButton6)
        Me.GroupControl1.Controls.Add(Me.SimpleButton7)
        Me.GroupControl1.Controls.Add(Me.DEUntilReturn)
        Me.GroupControl1.Controls.Add(Me.DEFromReturn)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1222, 39)
        Me.GroupControl1.TabIndex = 4
        '
        'CEHighlightNonList
        '
        Me.CEHighlightNonList.Location = New System.Drawing.Point(398, 9)
        Me.CEHighlightNonList.Name = "CEHighlightNonList"
        Me.CEHighlightNonList.Properties.Caption = "show highlight for non list"
        Me.CEHighlightNonList.Size = New System.Drawing.Size(174, 19)
        Me.CEHighlightNonList.TabIndex = 8899
        '
        'BtnViewReturn
        '
        Me.BtnViewReturn.Location = New System.Drawing.Point(317, 9)
        Me.BtnViewReturn.LookAndFeel.SkinName = "Blue"
        Me.BtnViewReturn.Name = "BtnViewReturn"
        Me.BtnViewReturn.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewReturn.TabIndex = 8896
        Me.BtnViewReturn.Text = "View"
        '
        'SimpleButton6
        '
        Me.SimpleButton6.ImageIndex = 9
        Me.SimpleButton6.Location = New System.Drawing.Point(938, 14)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(104, 20)
        Me.SimpleButton6.TabIndex = 8898
        Me.SimpleButton6.Text = "Hide All Detail"
        Me.SimpleButton6.Visible = False
        '
        'SimpleButton7
        '
        Me.SimpleButton7.ImageIndex = 8
        Me.SimpleButton7.Location = New System.Drawing.Point(835, 14)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(99, 20)
        Me.SimpleButton7.TabIndex = 8897
        Me.SimpleButton7.Text = "Expand All Detail"
        Me.SimpleButton7.Visible = False
        '
        'DEUntilReturn
        '
        Me.DEUntilReturn.EditValue = Nothing
        Me.DEUntilReturn.Location = New System.Drawing.Point(202, 9)
        Me.DEUntilReturn.Name = "DEUntilReturn"
        Me.DEUntilReturn.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilReturn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilReturn.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilReturn.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilReturn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilReturn.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilReturn.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilReturn.TabIndex = 8895
        '
        'DEFromReturn
        '
        Me.DEFromReturn.EditValue = Nothing
        Me.DEFromReturn.Location = New System.Drawing.Point(58, 9)
        Me.DEFromReturn.Name = "DEFromReturn"
        Me.DEFromReturn.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromReturn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromReturn.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromReturn.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromReturn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromReturn.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromReturn.Size = New System.Drawing.Size(111, 20)
        Me.DEFromReturn.TabIndex = 8894
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl7.TabIndex = 8893
        Me.LabelControl7.Text = "Until"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl8.TabIndex = 8892
        Me.LabelControl8.Text = "From"
        '
        'FormWHSvcLevel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 364)
        Me.Controls.Add(Me.XTCSvcLelel)
        Me.Name = "FormWHSvcLevel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Warehouse Service Level"
        CType(Me.XTCSvcLelel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSvcLelel.ResumeLayout(False)
        Me.XTPBySO.ResumeLayout(False)
        CType(Me.GCBySO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBySO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPByCode.ResumeLayout(False)
        CType(Me.GCByCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVByCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlByCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlByCode.ResumeLayout(False)
        Me.GroupControlByCode.PerformLayout()
        CType(Me.TxtDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDesignCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilCode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromCode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPByAcc.ResumeLayout(False)
        CType(Me.GCByAcco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVByAcco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVByAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlByAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlByAccount.ResumeLayout(False)
        Me.GroupControlByAccount.PerformLayout()
        CType(Me.TxtComp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCompID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilAcc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromAcc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPByReturn.ResumeLayout(False)
        CType(Me.GCReturn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReturn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.CEHighlightNonList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilReturn.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilReturn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromReturn.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromReturn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCSvcLelel As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBySO As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPByCode As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPByAcc As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCBySO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBySO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnPrepNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrepDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDsgName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDiff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControlByAccount As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnAcc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilAcc As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromAcc As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCByAcco As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVByAcc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GVByAcco As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumnAccCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAcc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDelQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSL As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCByCode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVByCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPrice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnOrderAmount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDelAmount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GroupControlByCode As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewCode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilCode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromCode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BandedGridColumnSvcLevelByCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPByReturn As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCReturn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReturn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewReturn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilReturn As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromReturn As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnScannedQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDiffSc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TxtDesignCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtDesign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtComp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCompID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BandedGridColumnDEst As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandAcc As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandorder As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnScanQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiffQtyScan As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSLScan As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandDEL As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents CEHighlightNonList As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnprepare_statusror As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfinal_comment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnExportToXLSSO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumndesign_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_amo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnscan_amo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndel_amo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnscan_diff_amo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndel_diff_amo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOnlineOrderDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncommerce_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridBandGeneral As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandOrderByCode As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandDelByCode As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_desc As DevExpress.XtraGrid.Columns.GridColumn
End Class
