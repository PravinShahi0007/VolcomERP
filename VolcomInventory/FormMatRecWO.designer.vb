<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatRecWO
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
        Me.XTCTabReceive = New DevExpress.XtraTab.XtraTabControl
        Me.XTPListReceive = New DevExpress.XtraTab.XtraTabPage
        Me.GCMatRecPurc = New DevExpress.XtraGrid.GridControl
        Me.GVMatRecPurc = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdMatRecPurc = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColWONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XTPListWO = New DevExpress.XtraTab.XtraTabPage
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GCMatWO = New DevExpress.XtraGrid.GridControl
        Me.GVMatWO = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdMatPurchase = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSamplePurcDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPayment = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdWoType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColWoType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQtyRec = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDateNow = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdOvhPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDiscount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.XTCTabReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCTabReceive.SuspendLayout()
        Me.XTPListReceive.SuspendLayout()
        CType(Me.GCMatRecPurc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatRecPurc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPListWO.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCMatWO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatWO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCTabReceive
        '
        Me.XTCTabReceive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCTabReceive.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCTabReceive.Location = New System.Drawing.Point(0, 0)
        Me.XTCTabReceive.Name = "XTCTabReceive"
        Me.XTCTabReceive.SelectedTabPage = Me.XTPListReceive
        Me.XTCTabReceive.Size = New System.Drawing.Size(884, 372)
        Me.XTCTabReceive.TabIndex = 8
        Me.XTCTabReceive.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPListReceive, Me.XTPListWO})
        '
        'XTPListReceive
        '
        Me.XTPListReceive.Controls.Add(Me.GCMatRecPurc)
        Me.XTPListReceive.Name = "XTPListReceive"
        Me.XTPListReceive.Size = New System.Drawing.Size(878, 346)
        Me.XTPListReceive.Text = "List Receive"
        '
        'GCMatRecPurc
        '
        Me.GCMatRecPurc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatRecPurc.Location = New System.Drawing.Point(0, 0)
        Me.GCMatRecPurc.MainView = Me.GVMatRecPurc
        Me.GCMatRecPurc.Name = "GCMatRecPurc"
        Me.GCMatRecPurc.Size = New System.Drawing.Size(878, 346)
        Me.GCMatRecPurc.TabIndex = 2
        Me.GCMatRecPurc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatRecPurc})
        '
        'GVMatRecPurc
        '
        Me.GVMatRecPurc.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatRecPurc, Me.ColSeason, Me.ColRecNumber, Me.ColShipFrom, Me.ColShipTo, Me.ColRecDate, Me.ColDueDate, Me.ColWONumber, Me.ColDONumber, Me.ColIDStatus, Me.ColStatus})
        Me.GVMatRecPurc.GridControl = Me.GCMatRecPurc
        Me.GVMatRecPurc.GroupCount = 1
        Me.GVMatRecPurc.Name = "GVMatRecPurc"
        Me.GVMatRecPurc.OptionsBehavior.Editable = False
        Me.GVMatRecPurc.OptionsFind.AlwaysVisible = True
        Me.GVMatRecPurc.OptionsView.ShowGroupPanel = False
        Me.GVMatRecPurc.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdMatRecPurc
        '
        Me.ColIdMatRecPurc.Caption = "ID Material WO"
        Me.ColIdMatRecPurc.FieldName = "id_mat_wo_rec"
        Me.ColIdMatRecPurc.Name = "ColIdMatRecPurc"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.Name = "ColSeason"
        '
        'ColRecNumber
        '
        Me.ColRecNumber.Caption = "Number"
        Me.ColRecNumber.FieldName = "mat_wo_rec_number"
        Me.ColRecNumber.Name = "ColRecNumber"
        Me.ColRecNumber.Visible = True
        Me.ColRecNumber.VisibleIndex = 0
        Me.ColRecNumber.Width = 73
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "From"
        Me.ColShipFrom.FieldName = "comp_from"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 4
        Me.ColShipFrom.Width = 142
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "To"
        Me.ColShipTo.FieldName = "comp_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 5
        Me.ColShipTo.Width = 142
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Receive Date"
        Me.ColRecDate.FieldName = "mat_wo_rec_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 6
        Me.ColRecDate.Width = 131
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Delivery Order Date"
        Me.ColDueDate.FieldName = "delivery_order_date"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 3
        Me.ColDueDate.Width = 144
        '
        'ColWONumber
        '
        Me.ColWONumber.Caption = "WO Number"
        Me.ColWONumber.FieldName = "mat_wo_number"
        Me.ColWONumber.Name = "ColWONumber"
        Me.ColWONumber.Visible = True
        Me.ColWONumber.VisibleIndex = 1
        '
        'ColDONumber
        '
        Me.ColDONumber.Caption = "DO Number"
        Me.ColDONumber.FieldName = "delivery_order_number"
        Me.ColDONumber.Name = "ColDONumber"
        Me.ColDONumber.Visible = True
        Me.ColDONumber.VisibleIndex = 2
        '
        'ColIDStatus
        '
        Me.ColIDStatus.Caption = "ID Status"
        Me.ColIDStatus.FieldName = "id_report_status"
        Me.ColIDStatus.Name = "ColIDStatus"
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 7
        '
        'XTPListWO
        '
        Me.XTPListWO.Controls.Add(Me.SplitContainerControl1)
        Me.XTPListWO.Name = "XTPListWO"
        Me.XTPListWO.Size = New System.Drawing.Size(878, 346)
        Me.XTPListWO.Text = "List Work Order"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(878, 346)
        Me.SplitContainerControl1.SplitterPosition = 244
        Me.SplitContainerControl1.TabIndex = 28
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCMatWO)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(878, 244)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Work Order"
        '
        'GCMatWO
        '
        Me.GCMatWO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatWO.Location = New System.Drawing.Point(2, 22)
        Me.GCMatWO.MainView = Me.GVMatWO
        Me.GCMatWO.Name = "GCMatWO"
        Me.GCMatWO.Size = New System.Drawing.Size(874, 220)
        Me.GCMatWO.TabIndex = 6
        Me.GCMatWO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatWO})
        '
        'GVMatWO
        '
        Me.GVMatWO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatPurchase, Me.GridColumn1, Me.ColDelivery, Me.ColPONumber, Me.GridColumn2, Me.GridColumn3, Me.ColSamplePurcDate, Me.GridColumn4, Me.GridColumn5, Me.ColPayment, Me.GridColumn6, Me.GridColumn7, Me.ColIdDelivery, Me.ColIdSeason, Me.ColIdWoType, Me.ColWoType, Me.ColQtyRec, Me.ColDateNow})
        Me.GVMatWO.GridControl = Me.GCMatWO
        Me.GVMatWO.GroupCount = 2
        Me.GVMatWO.Name = "GVMatWO"
        Me.GVMatWO.OptionsBehavior.Editable = False
        Me.GVMatWO.OptionsFind.AlwaysVisible = True
        Me.GVMatWO.OptionsView.ShowGroupPanel = False
        Me.GVMatWO.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdSeason, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdDelivery, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdMatPurchase
        '
        Me.ColIdMatPurchase.Caption = "ID Sample Purchase"
        Me.ColIdMatPurchase.FieldName = "id_mat_wo"
        Me.ColIdMatPurchase.Name = "ColIdMatPurchase"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Season"
        Me.GridColumn1.FieldName = "season"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'ColDelivery
        '
        Me.ColDelivery.Caption = "Del"
        Me.ColDelivery.FieldName = "delivery"
        Me.ColDelivery.Name = "ColDelivery"
        '
        'ColPONumber
        '
        Me.ColPONumber.Caption = "Number"
        Me.ColPONumber.FieldName = "mat_wo_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 0
        Me.ColPONumber.Width = 120
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "To"
        Me.GridColumn2.FieldName = "comp_name_to"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 107
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Ship To"
        Me.GridColumn3.FieldName = "comp_name_ship_to"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 107
        '
        'ColSamplePurcDate
        '
        Me.ColSamplePurcDate.Caption = "Create Date"
        Me.ColSamplePurcDate.FieldName = "mat_wo_date"
        Me.ColSamplePurcDate.Name = "ColSamplePurcDate"
        Me.ColSamplePurcDate.Visible = True
        Me.ColSamplePurcDate.VisibleIndex = 5
        Me.ColSamplePurcDate.Width = 99
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Est. Receive Date"
        Me.GridColumn4.FieldName = "mat_wo_lead_time"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 6
        Me.GridColumn4.Width = 99
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Due Date"
        Me.GridColumn5.FieldName = "mat_wo_top"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 7
        Me.GridColumn5.Width = 109
        '
        'ColPayment
        '
        Me.ColPayment.Caption = "Payment"
        Me.ColPayment.FieldName = "payment"
        Me.ColPayment.Name = "ColPayment"
        Me.ColPayment.Visible = True
        Me.ColPayment.VisibleIndex = 4
        Me.ColPayment.Width = 80
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Status"
        Me.GridColumn6.FieldName = "report_status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 8
        Me.GridColumn6.Width = 62
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "ID Status"
        Me.GridColumn7.FieldName = "id_report_status"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'ColIdDelivery
        '
        Me.ColIdDelivery.Caption = "Delivery"
        Me.ColIdDelivery.FieldName = "id_delivery"
        Me.ColIdDelivery.Name = "ColIdDelivery"
        '
        'ColIdSeason
        '
        Me.ColIdSeason.Caption = "Season"
        Me.ColIdSeason.FieldName = "id_season"
        Me.ColIdSeason.Name = "ColIdSeason"
        '
        'ColIdWoType
        '
        Me.ColIdWoType.Caption = "WO Type"
        Me.ColIdWoType.FieldName = "id_overhead"
        Me.ColIdWoType.Name = "ColIdWoType"
        Me.ColIdWoType.Width = 80
        '
        'ColWoType
        '
        Me.ColWoType.Caption = "WO Type"
        Me.ColWoType.FieldName = "overhead"
        Me.ColWoType.Name = "ColWoType"
        Me.ColWoType.Visible = True
        Me.ColWoType.VisibleIndex = 1
        '
        'ColQtyRec
        '
        Me.ColQtyRec.Caption = "GridColumn8"
        Me.ColQtyRec.FieldName = "qty_rec"
        Me.ColQtyRec.Name = "ColQtyRec"
        '
        'ColDateNow
        '
        Me.ColDateNow.Caption = "GridColumn8"
        Me.ColDateNow.FieldName = "date_now"
        Me.ColDateNow.Name = "ColDateNow"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCListPurchase)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(878, 97)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Detail"
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(2, 22)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Margin = New System.Windows.Forms.Padding(0)
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(874, 73)
        Me.GCListPurchase.TabIndex = 1
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdOvhPrice, Me.ColIdMat, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColDiscount, Me.ColSubtotal, Me.ColNote})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.Editable = False
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Purc Det"
        Me.ColIdPurcDet.FieldName = "id_mat_wo_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        '
        'ColIdOvhPrice
        '
        Me.ColIdOvhPrice.Caption = "Id Ovh Price"
        Me.ColIdOvhPrice.FieldName = "id_ovh_price"
        Me.ColIdOvhPrice.Name = "ColIdOvhPrice"
        '
        'ColIdMat
        '
        Me.ColIdMat.Caption = "Id Mat"
        Me.ColIdMat.FieldName = "id_mat_det"
        Me.ColIdMat.Name = "ColIdMat"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 30
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 140
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
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
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 3
        Me.ColPrice.Width = 140
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 5
        Me.ColQty.Width = 68
        '
        'ColDiscount
        '
        Me.ColDiscount.AppearanceCell.Options.UseTextOptions = True
        Me.ColDiscount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDiscount.AppearanceHeader.Options.UseTextOptions = True
        Me.ColDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDiscount.Caption = "Discount"
        Me.ColDiscount.DisplayFormat.FormatString = "N2"
        Me.ColDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDiscount.FieldName = "discount"
        Me.ColDiscount.Name = "ColDiscount"
        Me.ColDiscount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "discount", "{0:N2}")})
        Me.ColDiscount.Visible = True
        Me.ColDiscount.VisibleIndex = 4
        Me.ColDiscount.Width = 96
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
        Me.ColSubtotal.FieldName = "total"
        Me.ColSubtotal.Name = "ColSubtotal"
        Me.ColSubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.ColSubtotal.Visible = True
        Me.ColSubtotal.VisibleIndex = 6
        Me.ColSubtotal.Width = 165
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 7
        '
        'FormMatRecWO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 372)
        Me.Controls.Add(Me.XTCTabReceive)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatRecWO"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receiving Raw Material Work Order"
        CType(Me.XTCTabReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCTabReceive.ResumeLayout(False)
        Me.XTPListReceive.ResumeLayout(False)
        CType(Me.GCMatRecPurc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatRecPurc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPListWO.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCMatWO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatWO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCTabReceive As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPListReceive As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMatRecPurc As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatRecPurc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMatRecPurc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColWONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPListWO As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCMatWO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatWO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMatPurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdWoType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColWoType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQtyRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDateNow As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdOvhPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
End Class
