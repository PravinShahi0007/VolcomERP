<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdPRWO
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
        Me.XTCTabPR = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPListPR = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMatPR = New DevExpress.XtraGrid.GridControl()
        Me.GVMatPR = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdMatPurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPRNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPayTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMatPurcDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDOPRNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRecNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIDPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPListPO = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCProdWO = New DevExpress.XtraGrid.GridControl()
        Me.GVProdWO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSamplePurcDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPayment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdWoType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColWoType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProgress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PGBProg = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnIDCompTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedPR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl()
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCTabPR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCTabPR.SuspendLayout()
        Me.XTPListPR.SuspendLayout()
        CType(Me.GCMatPR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatPR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPListPO.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCProdWO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdWO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PGBProg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCTabPR
        '
        Me.XTCTabPR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCTabPR.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCTabPR.Location = New System.Drawing.Point(0, 0)
        Me.XTCTabPR.Name = "XTCTabPR"
        Me.XTCTabPR.SelectedTabPage = Me.XTPListPR
        Me.XTCTabPR.Size = New System.Drawing.Size(891, 325)
        Me.XTCTabPR.TabIndex = 6
        Me.XTCTabPR.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPListPR, Me.XTPListPO})
        '
        'XTPListPR
        '
        Me.XTPListPR.Controls.Add(Me.GCMatPR)
        Me.XTPListPR.Name = "XTPListPR"
        Me.XTPListPR.Size = New System.Drawing.Size(885, 297)
        Me.XTPListPR.Text = "List Payment Requisition"
        '
        'GCMatPR
        '
        Me.GCMatPR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatPR.Location = New System.Drawing.Point(0, 0)
        Me.GCMatPR.MainView = Me.GVMatPR
        Me.GCMatPR.Name = "GCMatPR"
        Me.GCMatPR.Size = New System.Drawing.Size(885, 297)
        Me.GCMatPR.TabIndex = 2
        Me.GCMatPR.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatPR})
        '
        'GVMatPR
        '
        Me.GVMatPR.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatPurchase, Me.ColPRNumber, Me.ColPayTo, Me.ColMatPurcDate, Me.ColDueDate, Me.ColPONumber, Me.ColNote, Me.ColStatus, Me.ColIDStatus, Me.GridColumnDOPRNumber, Me.GridColumnRecNumber, Me.GridColumnPO, Me.GridColumnIDPO, Me.GridColumnIdRec})
        Me.GVMatPR.GridControl = Me.GCMatPR
        Me.GVMatPR.GroupCount = 1
        Me.GVMatPR.Name = "GVMatPR"
        Me.GVMatPR.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVMatPR.OptionsBehavior.Editable = False
        Me.GVMatPR.OptionsFind.AlwaysVisible = True
        Me.GVMatPR.OptionsView.ShowGroupPanel = False
        Me.GVMatPR.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnPO, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdMatPurchase
        '
        Me.ColIdMatPurchase.Caption = "ID PR"
        Me.ColIdMatPurchase.FieldName = "id_pr_prod_order"
        Me.ColIdMatPurchase.Name = "ColIdMatPurchase"
        '
        'ColPRNumber
        '
        Me.ColPRNumber.Caption = "Number"
        Me.ColPRNumber.FieldName = "pr_prod_order_number"
        Me.ColPRNumber.Name = "ColPRNumber"
        Me.ColPRNumber.Visible = True
        Me.ColPRNumber.VisibleIndex = 0
        Me.ColPRNumber.Width = 73
        '
        'ColPayTo
        '
        Me.ColPayTo.Caption = "Pay To"
        Me.ColPayTo.FieldName = "comp_to"
        Me.ColPayTo.Name = "ColPayTo"
        Me.ColPayTo.Visible = True
        Me.ColPayTo.VisibleIndex = 1
        Me.ColPayTo.Width = 113
        '
        'ColMatPurcDate
        '
        Me.ColMatPurcDate.Caption = "Create Date"
        Me.ColMatPurcDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColMatPurcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColMatPurcDate.FieldName = "pr_prod_order_date"
        Me.ColMatPurcDate.Name = "ColMatPurcDate"
        Me.ColMatPurcDate.Visible = True
        Me.ColMatPurcDate.VisibleIndex = 5
        Me.ColMatPurcDate.Width = 100
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Due Date"
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "prod_order_wo_top"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 6
        Me.ColDueDate.Width = 103
        '
        'ColPONumber
        '
        Me.ColPONumber.Caption = "Work Order Number"
        Me.ColPONumber.FieldName = "prod_order_wo_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 2
        Me.ColPONumber.Width = 73
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "pr_prod_order_note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 7
        Me.ColNote.Width = 132
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 8
        '
        'ColIDStatus
        '
        Me.ColIDStatus.Caption = "ID Status"
        Me.ColIDStatus.FieldName = "id_report_status"
        Me.ColIDStatus.Name = "ColIDStatus"
        '
        'GridColumnDOPRNumber
        '
        Me.GridColumnDOPRNumber.Caption = "DO Number"
        Me.GridColumnDOPRNumber.FieldName = "delivery_order_number"
        Me.GridColumnDOPRNumber.Name = "GridColumnDOPRNumber"
        Me.GridColumnDOPRNumber.Visible = True
        Me.GridColumnDOPRNumber.VisibleIndex = 4
        '
        'GridColumnRecNumber
        '
        Me.GridColumnRecNumber.Caption = "Receive Number"
        Me.GridColumnRecNumber.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnRecNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnRecNumber.FieldName = "prod_order_rec_number"
        Me.GridColumnRecNumber.Name = "GridColumnRecNumber"
        Me.GridColumnRecNumber.Visible = True
        Me.GridColumnRecNumber.VisibleIndex = 3
        '
        'GridColumnPO
        '
        Me.GridColumnPO.Caption = "PDO Number"
        Me.GridColumnPO.FieldName = "prod_order_number"
        Me.GridColumnPO.Name = "GridColumnPO"
        '
        'GridColumnIDPO
        '
        Me.GridColumnIDPO.Caption = "ID PO"
        Me.GridColumnIDPO.FieldName = "id_prod_order"
        Me.GridColumnIDPO.Name = "GridColumnIDPO"
        '
        'GridColumnIdRec
        '
        Me.GridColumnIdRec.Caption = "ID Rec"
        Me.GridColumnIdRec.FieldName = "id_prod_order_rec"
        Me.GridColumnIdRec.Name = "GridColumnIdRec"
        '
        'XTPListPO
        '
        Me.XTPListPO.Controls.Add(Me.SplitContainerControl1)
        Me.XTPListPO.Name = "XTPListPO"
        Me.XTPListPO.Size = New System.Drawing.Size(791, 419)
        Me.XTPListPO.Text = "List Production Work Order"
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
        Me.SplitContainerControl1.Size = New System.Drawing.Size(791, 419)
        Me.SplitContainerControl1.SplitterPosition = 226
        Me.SplitContainerControl1.TabIndex = 28
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCProdWO)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(791, 226)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Need Payment Requisition"
        '
        'GCProdWO
        '
        Me.GCProdWO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdWO.Location = New System.Drawing.Point(2, 20)
        Me.GCProdWO.MainView = Me.GVProdWO
        Me.GCProdWO.Name = "GCProdWO"
        Me.GCProdWO.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PGBProg})
        Me.GCProdWO.Size = New System.Drawing.Size(787, 204)
        Me.GCProdWO.TabIndex = 9
        Me.GCProdWO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdWO})
        '
        'GVProdWO
        '
        Me.GVProdWO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.ColShipFrom, Me.ColShipTo, Me.ColSamplePurcDate, Me.ColRecDate, Me.GridColumn3, Me.ColPayment, Me.GridColumn4, Me.GridColumn5, Me.ColIdWoType, Me.ColWoType, Me.GridColumnProgress, Me.GridColumnIDCompTo, Me.GridColumnPONumber, Me.GridColumnCreatedPR})
        Me.GVProdWO.GridControl = Me.GCProdWO
        Me.GVProdWO.GroupCount = 1
        Me.GVProdWO.Name = "GVProdWO"
        Me.GVProdWO.OptionsBehavior.Editable = False
        Me.GVProdWO.OptionsFind.AlwaysVisible = True
        Me.GVProdWO.OptionsView.ShowGroupPanel = False
        Me.GVProdWO.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnPONumber, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Sample Purchase"
        Me.GridColumn1.FieldName = "id_prod_order_wo"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "prod_order_wo_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 88
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "To"
        Me.ColShipFrom.FieldName = "comp_name_to"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 2
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "Ship To"
        Me.ColShipTo.FieldName = "comp_name_ship_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 3
        '
        'ColSamplePurcDate
        '
        Me.ColSamplePurcDate.Caption = "Create Date"
        Me.ColSamplePurcDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColSamplePurcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColSamplePurcDate.FieldName = "prod_order_wo_date"
        Me.ColSamplePurcDate.Name = "ColSamplePurcDate"
        Me.ColSamplePurcDate.Visible = True
        Me.ColSamplePurcDate.VisibleIndex = 4
        Me.ColSamplePurcDate.Width = 69
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Est. Receive Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "prod_order_wo_lead_time"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 5
        Me.ColRecDate.Width = 69
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Due Date"
        Me.GridColumn3.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "prod_order_wo_top"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 8
        Me.GridColumn3.Width = 109
        '
        'ColPayment
        '
        Me.ColPayment.Caption = "Payment"
        Me.ColPayment.FieldName = "payment"
        Me.ColPayment.Name = "ColPayment"
        Me.ColPayment.Width = 80
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Status"
        Me.GridColumn4.FieldName = "report_status"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 6
        Me.GridColumn4.Width = 43
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "ID Status"
        Me.GridColumn5.FieldName = "id_report_status"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'ColIdWoType
        '
        Me.ColIdWoType.Caption = "WO Type"
        Me.ColIdWoType.FieldName = "id_ovh_price"
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
        Me.ColWoType.Width = 53
        '
        'GridColumnProgress
        '
        Me.GridColumnProgress.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnProgress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnProgress.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnProgress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnProgress.Caption = "Progress"
        Me.GridColumnProgress.ColumnEdit = Me.PGBProg
        Me.GridColumnProgress.FieldName = "progress"
        Me.GridColumnProgress.Name = "GridColumnProgress"
        Me.GridColumnProgress.Visible = True
        Me.GridColumnProgress.VisibleIndex = 7
        Me.GridColumnProgress.Width = 64
        '
        'PGBProg
        '
        Me.PGBProg.Appearance.BackColor = System.Drawing.Color.Lime
        Me.PGBProg.EndColor = System.Drawing.Color.Green
        Me.PGBProg.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PGBProg.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PGBProg.Name = "PGBProg"
        Me.PGBProg.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.PGBProg.ShowTitle = True
        Me.PGBProg.StartColor = System.Drawing.Color.Green
        Me.PGBProg.Step = 1
        '
        'GridColumnIDCompTo
        '
        Me.GridColumnIDCompTo.Caption = "ID Companyu"
        Me.GridColumnIDCompTo.FieldName = "id_comp_contact"
        Me.GridColumnIDCompTo.Name = "GridColumnIDCompTo"
        Me.GridColumnIDCompTo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIDCompTo.OptionsFilter.AllowAutoFilter = False
        Me.GridColumnIDCompTo.OptionsFilter.AllowFilter = False
        '
        'GridColumnPONumber
        '
        Me.GridColumnPONumber.Caption = "PO Number"
        Me.GridColumnPONumber.FieldName = "prod_order_number"
        Me.GridColumnPONumber.Name = "GridColumnPONumber"
        Me.GridColumnPONumber.Visible = True
        Me.GridColumnPONumber.VisibleIndex = 1
        Me.GridColumnPONumber.Width = 67
        '
        'GridColumnCreatedPR
        '
        Me.GridColumnCreatedPR.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCreatedPR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCreatedPR.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCreatedPR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCreatedPR.Caption = "Created PR"
        Me.GridColumnCreatedPR.FieldName = "qty_pr"
        Me.GridColumnCreatedPR.Name = "GridColumnCreatedPR"
        Me.GridColumnCreatedPR.Visible = True
        Me.GridColumnCreatedPR.VisibleIndex = 9
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCListPurchase)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(791, 188)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Detail"
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(2, 20)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Margin = New System.Windows.Forms.Padding(0)
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(787, 166)
        Me.GCListPurchase.TabIndex = 2
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdMat, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColSubtotal, Me.GridColumn6, Me.ColColor, Me.ColSize})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.Editable = False
        Me.GVListPurchase.OptionsView.ShowFooter = True
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
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
        Me.ColNo.Width = 50
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 107
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 179
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
        Me.ColPrice.FieldName = "cost"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.OptionsColumn.AllowEdit = False
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 6
        Me.ColPrice.Width = 107
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
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.OptionsColumn.AllowEdit = False
        Me.ColQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 5
        Me.ColQty.Width = 51
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
        Me.ColSubtotal.Visible = True
        Me.ColSubtotal.VisibleIndex = 7
        Me.ColSubtotal.Width = 125
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Note"
        Me.GridColumn6.FieldName = "note"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 8
        Me.GridColumn6.Width = 65
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
        Me.ColColor.Width = 56
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
        Me.ColSize.Width = 56
        '
        'FormProdPRWO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 325)
        Me.Controls.Add(Me.XTCTabPR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdPRWO"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Work Order Payment Requisition"
        CType(Me.XTCTabPR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCTabPR.ResumeLayout(False)
        Me.XTPListPR.ResumeLayout(False)
        CType(Me.GCMatPR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatPR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPListPO.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCProdWO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdWO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PGBProg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCTabPR As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPListPR As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMatPR As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatPR As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMatPurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPRNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPayTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMatPurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDOPRNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPListPO As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridColumnPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCProdWO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdWO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdWoType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColWoType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProgress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PGBProg As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnIDCompTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedPR As DevExpress.XtraGrid.Columns.GridColumn
End Class
