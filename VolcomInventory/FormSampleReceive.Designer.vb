<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleReceive
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
        Me.GCSampleReceive = New DevExpress.XtraGrid.GridControl
        Me.GVSampleReceive = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdSampleRec = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPSONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XTPListPO = New DevExpress.XtraTab.XtraTabPage
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GCSamplePurchaseNeed = New DevExpress.XtraGrid.GridControl
        Me.GVSamplePurchaseNeed = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPayment = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQtyReceive = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDatenow = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDiscount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.XTCTabReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCTabReceive.SuspendLayout()
        Me.XTPListReceive.SuspendLayout()
        CType(Me.GCSampleReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPListPO.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCSamplePurchaseNeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSamplePurchaseNeed, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.XTCTabReceive.Size = New System.Drawing.Size(910, 434)
        Me.XTCTabReceive.TabIndex = 5
        Me.XTCTabReceive.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPListReceive, Me.XTPListPO})
        '
        'XTPListReceive
        '
        Me.XTPListReceive.Controls.Add(Me.GCSampleReceive)
        Me.XTPListReceive.Name = "XTPListReceive"
        Me.XTPListReceive.Size = New System.Drawing.Size(904, 408)
        Me.XTPListReceive.Text = "List Receive"
        '
        'GCSampleReceive
        '
        Me.GCSampleReceive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleReceive.Location = New System.Drawing.Point(0, 0)
        Me.GCSampleReceive.MainView = Me.GVSampleReceive
        Me.GCSampleReceive.Name = "GCSampleReceive"
        Me.GCSampleReceive.Size = New System.Drawing.Size(904, 408)
        Me.GCSampleReceive.TabIndex = 2
        Me.GCSampleReceive.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleReceive})
        '
        'GVSampleReceive
        '
        Me.GVSampleReceive.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSampleRec, Me.ColSeason, Me.ColRecNumber, Me.ColShipFrom, Me.ColShipTo, Me.ColRecDate, Me.ColDueDate, Me.ColPSONumber, Me.ColDONumber, Me.ColIDStatus, Me.ColStatus})
        Me.GVSampleReceive.GridControl = Me.GCSampleReceive
        Me.GVSampleReceive.GroupCount = 1
        Me.GVSampleReceive.Name = "GVSampleReceive"
        Me.GVSampleReceive.OptionsBehavior.Editable = False
        Me.GVSampleReceive.OptionsFind.AlwaysVisible = True
        Me.GVSampleReceive.OptionsView.ShowGroupPanel = False
        Me.GVSampleReceive.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdSampleRec
        '
        Me.ColIdSampleRec.Caption = "ID Sample Purchase"
        Me.ColIdSampleRec.FieldName = "id_sample_purc_rec"
        Me.ColIdSampleRec.Name = "ColIdSampleRec"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season Orign"
        Me.ColSeason.FieldName = "season_orign"
        Me.ColSeason.Name = "ColSeason"
        '
        'ColRecNumber
        '
        Me.ColRecNumber.Caption = "Number"
        Me.ColRecNumber.FieldName = "sample_purc_rec_number"
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
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "sample_purc_rec_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 6
        Me.ColRecDate.Width = 131
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Delivery Order Date"
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "delivery_order_date"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 3
        Me.ColDueDate.Width = 144
        '
        'ColPSONumber
        '
        Me.ColPSONumber.Caption = "PO Number"
        Me.ColPSONumber.FieldName = "sample_purc_number"
        Me.ColPSONumber.Name = "ColPSONumber"
        Me.ColPSONumber.Visible = True
        Me.ColPSONumber.VisibleIndex = 1
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
        'XTPListPO
        '
        Me.XTPListPO.Controls.Add(Me.SplitContainerControl1)
        Me.XTPListPO.Name = "XTPListPO"
        Me.XTPListPO.Size = New System.Drawing.Size(904, 408)
        Me.XTPListPO.Text = "List Purchase Order"
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
        Me.SplitContainerControl1.Size = New System.Drawing.Size(904, 408)
        Me.SplitContainerControl1.SplitterPosition = 249
        Me.SplitContainerControl1.TabIndex = 28
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCSamplePurchaseNeed)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(904, 249)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Purchase Order"
        '
        'GCSamplePurchaseNeed
        '
        Me.GCSamplePurchaseNeed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSamplePurchaseNeed.Location = New System.Drawing.Point(2, 22)
        Me.GCSamplePurchaseNeed.MainView = Me.GVSamplePurchaseNeed
        Me.GCSamplePurchaseNeed.Name = "GCSamplePurchaseNeed"
        Me.GCSamplePurchaseNeed.Size = New System.Drawing.Size(900, 225)
        Me.GCSamplePurchaseNeed.TabIndex = 2
        Me.GCSamplePurchaseNeed.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSamplePurchaseNeed})
        '
        'GVSamplePurchaseNeed
        '
        Me.GVSamplePurchaseNeed.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.ColPayment, Me.ColQtyReceive, Me.ColDatenow})
        Me.GVSamplePurchaseNeed.GridControl = Me.GCSamplePurchaseNeed
        Me.GVSamplePurchaseNeed.GroupCount = 1
        Me.GVSamplePurchaseNeed.Name = "GVSamplePurchaseNeed"
        Me.GVSamplePurchaseNeed.OptionsBehavior.Editable = False
        Me.GVSamplePurchaseNeed.OptionsView.ShowGroupPanel = False
        Me.GVSamplePurchaseNeed.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn6, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "ID Sample Purchase"
        Me.GridColumn5.FieldName = "id_sample_purc"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Season Orign"
        Me.GridColumn6.FieldName = "season_orign"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Number"
        Me.GridColumn7.FieldName = "sample_purc_number"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 65
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "To"
        Me.GridColumn8.FieldName = "comp_name_to"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        Me.GridColumn8.Width = 127
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Ship To"
        Me.GridColumn9.FieldName = "comp_name_ship_to"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        Me.GridColumn9.Width = 127
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Create Date"
        Me.GridColumn10.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn10.FieldName = "sample_purc_date"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 4
        Me.GridColumn10.Width = 117
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Est. Receive Date"
        Me.GridColumn11.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn11.FieldName = "sample_purc_lead_time"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 5
        Me.GridColumn11.Width = 117
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Due Date"
        Me.GridColumn12.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn12.FieldName = "sample_purc_top"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 7
        Me.GridColumn12.Width = 129
        '
        'ColPayment
        '
        Me.ColPayment.Caption = "Payment"
        Me.ColPayment.FieldName = "payment"
        Me.ColPayment.Name = "ColPayment"
        Me.ColPayment.Visible = True
        Me.ColPayment.VisibleIndex = 3
        Me.ColPayment.Width = 89
        '
        'ColQtyReceive
        '
        Me.ColQtyReceive.AppearanceCell.Options.UseTextOptions = True
        Me.ColQtyReceive.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColQtyReceive.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQtyReceive.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColQtyReceive.Caption = "Receive Created"
        Me.ColQtyReceive.FieldName = "qty_receive"
        Me.ColQtyReceive.Name = "ColQtyReceive"
        Me.ColQtyReceive.Visible = True
        Me.ColQtyReceive.VisibleIndex = 6
        Me.ColQtyReceive.Width = 120
        '
        'ColDatenow
        '
        Me.ColDatenow.Caption = "Date now"
        Me.ColDatenow.FieldName = "date_now"
        Me.ColDatenow.Name = "ColDatenow"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCListPurchase)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(904, 154)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Detail"
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(2, 22)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(900, 130)
        Me.GCListPurchase.TabIndex = 3
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPrice, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColDiscount, Me.ColSubtotal})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.Editable = False
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdPrice
        '
        Me.ColIdPrice.Caption = "ID Price"
        Me.ColIdPrice.FieldName = "id_sample_purc_det"
        Me.ColIdPrice.Name = "ColIdPrice"
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
        Me.ColDiscount.FieldName = "discount"
        Me.ColDiscount.Name = "ColDiscount"
        Me.ColDiscount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
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
        Me.ColSubtotal.FieldName = "total"
        Me.ColSubtotal.Name = "ColSubtotal"
        Me.ColSubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.ColSubtotal.Visible = True
        Me.ColSubtotal.VisibleIndex = 6
        Me.ColSubtotal.Width = 165
        '
        'FormSampleReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 434)
        Me.Controls.Add(Me.XTCTabReceive)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleReceive"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Receive Sample"
        CType(Me.XTCTabReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCTabReceive.ResumeLayout(False)
        Me.XTPListReceive.ResumeLayout(False)
        CType(Me.GCSampleReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPListPO.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCSamplePurchaseNeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSamplePurchaseNeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCTabReceive As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPListReceive As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSampleReceive As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleReceive As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSampleRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPSONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPListPO As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSamplePurchaseNeed As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSamplePurchaseNeed As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQtyReceive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDatenow As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
End Class
