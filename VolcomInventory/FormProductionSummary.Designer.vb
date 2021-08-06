<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProductionSummary
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
        Me.components = New System.ComponentModel.Container()
        Me.XTCSum = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDesign = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDesign = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMEditEcopFinal = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVDesign = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.BandedGridColumnCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDescription = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnVendor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSeason = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDelivery = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnClass = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiv = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSource = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnInWHDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnInStoreDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPOType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTerm = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPODate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRecDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRecDateKO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRevDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPLToWHDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRs = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPOAmo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyRec = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnStatusRecQc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyRecOut = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyRecIn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyRecClaim = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyRecOutstanding = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyRecTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiffOrder = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnNormal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnMajor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnMinor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAfkir = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalQC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFinalRiject = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRejectProcentage = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiffReceive = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalPLToWHNormal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalPLToWHMajor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalPLToWHMinor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalPLToWHAfkir = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalPLToWH = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnStatusToWH = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiffQcReport = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPPD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPPDAmo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPPO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPPOAmo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPPreFinal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPPreFinalAmo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPPreFinalStt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPFinal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPFinalAmo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPFinalStt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnIncDec = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.SLEVendorAppOrder = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BViewByPO = New DevExpress.XtraEditors.SimpleButton()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPONumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEDesignStockStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GVSLEDesgSearch = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCodeSearch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPPD = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPD = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenuPD = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailPDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVPD = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.BtnViewPD = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilPD = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromPD = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPPOMat = New DevExpress.XtraTab.XtraTabPage()
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl()
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMatDetPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDiscount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOMatNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOMatRef = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMatPaymentTyp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLeadTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTOP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMatSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMatCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMatEstRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMatDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSattus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMatVat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVatTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMatTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMatCur = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMatKurs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.BtnViewMat = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilMat = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromMat = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPFGPO = New DevExpress.XtraTab.XtraTabPage()
        Me.GCProdRec = New DevExpress.XtraGrid.GridControl()
        Me.GVProdRec = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnRecVendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdPRodOrderRecPurc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ColPSONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStyleCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.DEUntilRec = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromRec = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView14 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.BandedGridColumnQtySNI = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandStyle = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand23 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandRejectDetail = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand39 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand20 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.XTCSum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSum.SuspendLayout()
        Me.XTPDesign.SuspendLayout()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.SLEVendorAppOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPD.SuspendLayout()
        CType(Me.GCPD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenuPD.SuspendLayout()
        CType(Me.GVPD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.DEUntilPD.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilPD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromPD.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromPD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPOMat.SuspendLayout()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.DEUntilMat.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilMat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromMat.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromMat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPFGPO.SuspendLayout()
        CType(Me.GCProdRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.DEUntilRec.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilRec.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromRec.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromRec.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCSum
        '
        Me.XTCSum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSum.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSum.Location = New System.Drawing.Point(0, 0)
        Me.XTCSum.Name = "XTCSum"
        Me.XTCSum.SelectedTabPage = Me.XTPDesign
        Me.XTCSum.Size = New System.Drawing.Size(1008, 729)
        Me.XTCSum.TabIndex = 0
        Me.XTCSum.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDesign, Me.XTPPD, Me.XTPPOMat, Me.XTPFGPO})
        '
        'XTPDesign
        '
        Me.XTPDesign.Controls.Add(Me.GCDesign)
        Me.XTPDesign.Controls.Add(Me.GCFilter)
        Me.XTPDesign.Controls.Add(Me.BHide)
        Me.XTPDesign.Controls.Add(Me.BExpand)
        Me.XTPDesign.Name = "XTPDesign"
        Me.XTPDesign.Size = New System.Drawing.Size(1002, 701)
        Me.XTPDesign.Text = "Order Summary"
        '
        'GCDesign
        '
        Me.GCDesign.ContextMenuStrip = Me.ViewMenu
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(0, 39)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.GCDesign.Size = New System.Drawing.Size(1002, 662)
        Me.GCDesign.TabIndex = 5
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailToolStripMenuItem, Me.SMEditEcopFinal})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(225, 48)
        '
        'ViewDetailToolStripMenuItem
        '
        Me.ViewDetailToolStripMenuItem.Name = "ViewDetailToolStripMenuItem"
        Me.ViewDetailToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.ViewDetailToolStripMenuItem.Text = "View Purchase Order + BOM"
        '
        'SMEditEcopFinal
        '
        Me.SMEditEcopFinal.Name = "SMEditEcopFinal"
        Me.SMEditEcopFinal.Size = New System.Drawing.Size(224, 22)
        Me.SMEditEcopFinal.Text = "View Pre-Final / Final COP"
        '
        'GVDesign
        '
        Me.GVDesign.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBandStyle, Me.gridBand3, Me.gridBand23, Me.gridBandRejectDetail, Me.gridBand39, Me.GridBand1, Me.gridBand20})
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnPO, Me.BandedGridColumnVendor, Me.BandedGridColumnCode, Me.BandedGridColumnDescription, Me.BandedGridColumnQty, Me.BandedGridColumnQtyRec, Me.BandedGridColumnQtyRecOut, Me.BandedGridColumnQtyRecIn, Me.BandedGridColumnQtyRecClaim, Me.BandedGridColumnQtySNI, Me.BandedGridColumnQtyRecOutstanding, Me.BandedGridColumnDiffOrder, Me.BandedGridColumnQtyRecTotal, Me.BandedGridColumnPOAmo, Me.BandedGridColumnCOPPD, Me.BandedGridColumnCOPPDAmo, Me.BandedGridColumnCOPPO, Me.BandedGridColumnCOPPOAmo, Me.BandedGridColumnCOPFinalStt, Me.BandedGridColumnCOPFinal, Me.BandedGridColumnCOPFinalAmo, Me.BandedGridColumnIncDec, Me.BandedGridColumnSource, Me.BandedGridColumnSeason, Me.BandedGridColumnDelivery, Me.BandedGridColumnClass, Me.BandedGridColumnDiv, Me.BandedGridColumnRs, Me.BandedGridColumnSel, Me.BandedGridColumnFinalRiject, Me.BandedGridColumnRejectProcentage, Me.BandedGridColumnNormal, Me.BandedGridColumnMajor, Me.BandedGridColumnMinor, Me.BandedGridColumnAfkir, Me.BandedGridColumnCOPPreFinalStt, Me.BandedGridColumnCOPPreFinal, Me.BandedGridColumnCOPPreFinalAmo, Me.BandedGridColumnTotalPLToWHNormal, Me.BandedGridColumnTotalPLToWHMajor, Me.BandedGridColumnTotalPLToWHMinor, Me.BandedGridColumnTotalPLToWHAfkir, Me.BandedGridColumnDiffReceive, Me.BandedGridColumnTotalQC, Me.BandedGridColumnDiffQcReport, Me.BandedGridColumnTotalPLToWH, Me.BandedGridColumnStatusToWH, Me.BandedGridColumnStatusRecQc, Me.BandedGridColumnRecDate, Me.BandedGridColumnRecDateKO, Me.BandedGridColumnRevDate, Me.BandedGridColumnPLToWHDate, Me.BandedGridColumnPODate, Me.BandedGridColumnInStoreDate, Me.BandedGridColumnInWHDate, Me.BandedGridColumnPOType, Me.BandedGridColumnTerm})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.BandedGridColumnQty, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "po_amount", Me.BandedGridColumnPOAmo, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", Me.BandedGridColumnQtyRec, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_out", Me.BandedGridColumnQtyRecOut, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_in", Me.BandedGridColumnQtyRecIn, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_claim", Me.BandedGridColumnQtyRecClaim, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diffreturn", Me.BandedGridColumnQtyRecOutstanding, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_fc", Me.BandedGridColumnFinalRiject, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_total", Me.BandedGridColumnQtyRecTotal, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cop_pd_amo", Me.BandedGridColumnCOPPDAmo, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cop_po_amo", Me.BandedGridColumnCOPPOAmo, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cop_pre_final_amo", Me.BandedGridColumnCOPPreFinalAmo, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cop_final_amo", Me.BandedGridColumnCOPFinalAmo, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "normal", Me.BandedGridColumnNormal, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_major", Me.BandedGridColumnMajor, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_minor", Me.BandedGridColumnMinor, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_afkir", Me.BandedGridColumnAfkir, "{0:N0})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_fc", Me.BandedGridColumnTotalQC, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl", Me.BandedGridColumnTotalPLToWH, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_normal", Me.BandedGridColumnTotalPLToWHNormal, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_major", Me.BandedGridColumnTotalPLToWHMajor, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_minor", Me.BandedGridColumnMinor, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_afkir", Me.BandedGridColumnTotalPLToWHAfkir, "{0:N0}")})
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVDesign.OptionsView.ShowFooter = True
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        '
        'BandedGridColumnCode
        '
        Me.BandedGridColumnCode.Caption = "CODE"
        Me.BandedGridColumnCode.FieldName = "code"
        Me.BandedGridColumnCode.Name = "BandedGridColumnCode"
        Me.BandedGridColumnCode.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnCode.Visible = True
        Me.BandedGridColumnCode.Width = 48
        '
        'BandedGridColumnDescription
        '
        Me.BandedGridColumnDescription.Caption = "DESCRIPTION"
        Me.BandedGridColumnDescription.FieldName = "name"
        Me.BandedGridColumnDescription.Name = "BandedGridColumnDescription"
        Me.BandedGridColumnDescription.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnDescription.Visible = True
        Me.BandedGridColumnDescription.Width = 86
        '
        'BandedGridColumnPO
        '
        Me.BandedGridColumnPO.Caption = "FGPO#"
        Me.BandedGridColumnPO.FieldName = "prod_order_number"
        Me.BandedGridColumnPO.Name = "BandedGridColumnPO"
        Me.BandedGridColumnPO.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnPO.Visible = True
        Me.BandedGridColumnPO.Width = 59
        '
        'BandedGridColumnVendor
        '
        Me.BandedGridColumnVendor.Caption = "VENDOR"
        Me.BandedGridColumnVendor.FieldName = "comp_name"
        Me.BandedGridColumnVendor.Name = "BandedGridColumnVendor"
        Me.BandedGridColumnVendor.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnVendor.Visible = True
        Me.BandedGridColumnVendor.Width = 70
        '
        'BandedGridColumnSeason
        '
        Me.BandedGridColumnSeason.Caption = " SEASON"
        Me.BandedGridColumnSeason.FieldName = "season"
        Me.BandedGridColumnSeason.Name = "BandedGridColumnSeason"
        Me.BandedGridColumnSeason.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnSeason.Visible = True
        Me.BandedGridColumnSeason.Width = 54
        '
        'BandedGridColumnDelivery
        '
        Me.BandedGridColumnDelivery.Caption = "DELIVERY"
        Me.BandedGridColumnDelivery.FieldName = "delivery"
        Me.BandedGridColumnDelivery.Name = "BandedGridColumnDelivery"
        Me.BandedGridColumnDelivery.Visible = True
        '
        'BandedGridColumnClass
        '
        Me.BandedGridColumnClass.Caption = "CLASS"
        Me.BandedGridColumnClass.FieldName = "class"
        Me.BandedGridColumnClass.Name = "BandedGridColumnClass"
        Me.BandedGridColumnClass.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnClass.Visible = True
        Me.BandedGridColumnClass.Width = 47
        '
        'BandedGridColumnDiv
        '
        Me.BandedGridColumnDiv.Caption = "DIVISION"
        Me.BandedGridColumnDiv.FieldName = "division"
        Me.BandedGridColumnDiv.Name = "BandedGridColumnDiv"
        Me.BandedGridColumnDiv.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnDiv.Visible = True
        Me.BandedGridColumnDiv.Width = 67
        '
        'BandedGridColumnSource
        '
        Me.BandedGridColumnSource.Caption = "SOURCE"
        Me.BandedGridColumnSource.FieldName = "product_source"
        Me.BandedGridColumnSource.Name = "BandedGridColumnSource"
        Me.BandedGridColumnSource.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnSource.Visible = True
        Me.BandedGridColumnSource.Width = 68
        '
        'BandedGridColumnInWHDate
        '
        Me.BandedGridColumnInWHDate.Caption = "EST. IN WH DATE"
        Me.BandedGridColumnInWHDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnInWHDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnInWHDate.FieldName = "est_wh_date"
        Me.BandedGridColumnInWHDate.Name = "BandedGridColumnInWHDate"
        Me.BandedGridColumnInWHDate.Visible = True
        Me.BandedGridColumnInWHDate.Width = 95
        '
        'BandedGridColumnInStoreDate
        '
        Me.BandedGridColumnInStoreDate.Caption = "EST. IN STORE DATE"
        Me.BandedGridColumnInStoreDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnInStoreDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnInStoreDate.FieldName = "delivery_date"
        Me.BandedGridColumnInStoreDate.Name = "BandedGridColumnInStoreDate"
        Me.BandedGridColumnInStoreDate.Visible = True
        Me.BandedGridColumnInStoreDate.Width = 111
        '
        'BandedGridColumnPOType
        '
        Me.BandedGridColumnPOType.Caption = "PO TYPE"
        Me.BandedGridColumnPOType.FieldName = "po_type"
        Me.BandedGridColumnPOType.Name = "BandedGridColumnPOType"
        Me.BandedGridColumnPOType.Visible = True
        '
        'BandedGridColumnTerm
        '
        Me.BandedGridColumnTerm.Caption = "TERM"
        Me.BandedGridColumnTerm.FieldName = "term_production"
        Me.BandedGridColumnTerm.Name = "BandedGridColumnTerm"
        Me.BandedGridColumnTerm.Visible = True
        '
        'BandedGridColumnPODate
        '
        Me.BandedGridColumnPODate.Caption = "PO CREATED"
        Me.BandedGridColumnPODate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnPODate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnPODate.FieldName = "prod_order_date"
        Me.BandedGridColumnPODate.Name = "BandedGridColumnPODate"
        Me.BandedGridColumnPODate.Visible = True
        '
        'BandedGridColumnRecDate
        '
        Me.BandedGridColumnRecDate.Caption = "EST. RECEIVE DATE"
        Me.BandedGridColumnRecDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnRecDate.FieldName = "est_del_date"
        Me.BandedGridColumnRecDate.Name = "BandedGridColumnRecDate"
        Me.BandedGridColumnRecDate.Visible = True
        Me.BandedGridColumnRecDate.Width = 106
        '
        'BandedGridColumnRecDateKO
        '
        Me.BandedGridColumnRecDateKO.Caption = "EST. RECEIVE DATE (KO)"
        Me.BandedGridColumnRecDateKO.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnRecDateKO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnRecDateKO.FieldName = "est_del_date_ko"
        Me.BandedGridColumnRecDateKO.Name = "BandedGridColumnRecDateKO"
        Me.BandedGridColumnRecDateKO.Visible = True
        Me.BandedGridColumnRecDateKO.Width = 131
        '
        'BandedGridColumnRevDate
        '
        Me.BandedGridColumnRevDate.Caption = "RECEIVE DATE"
        Me.BandedGridColumnRevDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnRevDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnRevDate.FieldName = "prod_order_rec_date"
        Me.BandedGridColumnRevDate.Name = "BandedGridColumnRevDate"
        Me.BandedGridColumnRevDate.Visible = True
        Me.BandedGridColumnRevDate.Width = 81
        '
        'BandedGridColumnPLToWHDate
        '
        Me.BandedGridColumnPLToWHDate.Caption = "PL TO WH DATE"
        Me.BandedGridColumnPLToWHDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnPLToWHDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnPLToWHDate.FieldName = "pl_prod_order_date"
        Me.BandedGridColumnPLToWHDate.Name = "BandedGridColumnPLToWHDate"
        Me.BandedGridColumnPLToWHDate.Visible = True
        Me.BandedGridColumnPLToWHDate.Width = 87
        '
        'BandedGridColumnRs
        '
        Me.BandedGridColumnRs.Caption = "STATUS FGPO"
        Me.BandedGridColumnRs.FieldName = "report_status"
        Me.BandedGridColumnRs.Name = "BandedGridColumnRs"
        Me.BandedGridColumnRs.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnRs.Visible = True
        Me.BandedGridColumnRs.Width = 79
        '
        'BandedGridColumnQty
        '
        Me.BandedGridColumnQty.Caption = "QTY"
        Me.BandedGridColumnQty.DisplayFormat.FormatString = "{0:n0}"
        Me.BandedGridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQty.FieldName = "qty"
        Me.BandedGridColumnQty.Name = "BandedGridColumnQty"
        Me.BandedGridColumnQty.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:n0}")})
        Me.BandedGridColumnQty.Visible = True
        Me.BandedGridColumnQty.Width = 63
        '
        'BandedGridColumnPOAmo
        '
        Me.BandedGridColumnPOAmo.Caption = "ORDER AMOUNT"
        Me.BandedGridColumnPOAmo.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnPOAmo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPOAmo.FieldName = "po_amount"
        Me.BandedGridColumnPOAmo.Name = "BandedGridColumnPOAmo"
        Me.BandedGridColumnPOAmo.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnPOAmo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "po_amount", "{0:n2}")})
        Me.BandedGridColumnPOAmo.Visible = True
        Me.BandedGridColumnPOAmo.Width = 95
        '
        'BandedGridColumnQtyRec
        '
        Me.BandedGridColumnQtyRec.Caption = "PRE RECEIVE"
        Me.BandedGridColumnQtyRec.DisplayFormat.FormatString = "{0:n0}"
        Me.BandedGridColumnQtyRec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtyRec.FieldName = "qty_rec"
        Me.BandedGridColumnQtyRec.Name = "BandedGridColumnQtyRec"
        Me.BandedGridColumnQtyRec.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", "{0:n0}")})
        Me.BandedGridColumnQtyRec.Visible = True
        Me.BandedGridColumnQtyRec.Width = 82
        '
        'BandedGridColumnStatusRecQc
        '
        Me.BandedGridColumnStatusRecQc.Caption = "STATUS"
        Me.BandedGridColumnStatusRecQc.FieldName = "status_qc"
        Me.BandedGridColumnStatusRecQc.Name = "BandedGridColumnStatusRecQc"
        Me.BandedGridColumnStatusRecQc.Visible = True
        Me.BandedGridColumnStatusRecQc.Width = 108
        '
        'BandedGridColumnQtyRecOut
        '
        Me.BandedGridColumnQtyRecOut.Caption = "RETURN OUT"
        Me.BandedGridColumnQtyRecOut.DisplayFormat.FormatString = "{0:n0}"
        Me.BandedGridColumnQtyRecOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtyRecOut.FieldName = "qty_ret_out"
        Me.BandedGridColumnQtyRecOut.Name = "BandedGridColumnQtyRecOut"
        Me.BandedGridColumnQtyRecOut.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_out", "{0:n0}")})
        Me.BandedGridColumnQtyRecOut.Visible = True
        '
        'BandedGridColumnQtyRecIn
        '
        Me.BandedGridColumnQtyRecIn.Caption = "RETURN IN"
        Me.BandedGridColumnQtyRecIn.DisplayFormat.FormatString = "{0:n0}"
        Me.BandedGridColumnQtyRecIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtyRecIn.FieldName = "qty_ret_in"
        Me.BandedGridColumnQtyRecIn.Name = "BandedGridColumnQtyRecIn"
        Me.BandedGridColumnQtyRecIn.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_in", "{0:n0}")})
        Me.BandedGridColumnQtyRecIn.Visible = True
        '
        'BandedGridColumnQtyRecClaim
        '
        Me.BandedGridColumnQtyRecClaim.Caption = "RETURN CLAIM"
        Me.BandedGridColumnQtyRecClaim.DisplayFormat.FormatString = "{0:n0}"
        Me.BandedGridColumnQtyRecClaim.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtyRecClaim.FieldName = "qty_ret_claim"
        Me.BandedGridColumnQtyRecClaim.Name = "BandedGridColumnQtyRecClaim"
        Me.BandedGridColumnQtyRecClaim.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_claim", "{0:n0}")})
        Me.BandedGridColumnQtyRecClaim.Visible = True
        Me.BandedGridColumnQtyRecClaim.Width = 84
        '
        'BandedGridColumnQtyRecOutstanding
        '
        Me.BandedGridColumnQtyRecOutstanding.Caption = "OUTSTANDING RETURN"
        Me.BandedGridColumnQtyRecOutstanding.DisplayFormat.FormatString = "{0:n0}"
        Me.BandedGridColumnQtyRecOutstanding.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtyRecOutstanding.FieldName = "diffreturn"
        Me.BandedGridColumnQtyRecOutstanding.Name = "BandedGridColumnQtyRecOutstanding"
        Me.BandedGridColumnQtyRecOutstanding.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diffreturn", "{0:n0}")})
        Me.BandedGridColumnQtyRecOutstanding.ToolTip = "RETURN OUT - RETURN IN - RETURN CLAIM"
        Me.BandedGridColumnQtyRecOutstanding.UnboundExpression = "[qty_ret_out] - [qty_ret_in] - [qty_ret_claim]"
        Me.BandedGridColumnQtyRecOutstanding.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.BandedGridColumnQtyRecOutstanding.Visible = True
        Me.BandedGridColumnQtyRecOutstanding.Width = 82
        '
        'BandedGridColumnQtyRecTotal
        '
        Me.BandedGridColumnQtyRecTotal.Caption = "FINAL REC"
        Me.BandedGridColumnQtyRecTotal.DisplayFormat.FormatString = "{0:n0}"
        Me.BandedGridColumnQtyRecTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtyRecTotal.FieldName = "qty_ret_total"
        Me.BandedGridColumnQtyRecTotal.Name = "BandedGridColumnQtyRecTotal"
        Me.BandedGridColumnQtyRecTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_total", "{0:n0}")})
        Me.BandedGridColumnQtyRecTotal.UnboundExpression = "[qty_rec] - [qty_ret_out] + [qty_ret_in] - [qty_sni]"
        Me.BandedGridColumnQtyRecTotal.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.BandedGridColumnQtyRecTotal.Visible = True
        Me.BandedGridColumnQtyRecTotal.Width = 87
        '
        'BandedGridColumnDiffOrder
        '
        Me.BandedGridColumnDiffOrder.Caption = "DIFF ORDER (REC-RET vs PO)"
        Me.BandedGridColumnDiffOrder.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnDiffOrder.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffOrder.FieldName = "qty_diff_order"
        Me.BandedGridColumnDiffOrder.Name = "BandedGridColumnDiffOrder"
        Me.BandedGridColumnDiffOrder.UnboundExpression = "[qty_ret_total] - [qty] + [qty_sni]"
        Me.BandedGridColumnDiffOrder.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.BandedGridColumnDiffOrder.Visible = True
        '
        'BandedGridColumnNormal
        '
        Me.BandedGridColumnNormal.Caption = "NORMAL"
        Me.BandedGridColumnNormal.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnNormal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnNormal.FieldName = "normal"
        Me.BandedGridColumnNormal.Name = "BandedGridColumnNormal"
        Me.BandedGridColumnNormal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "normal", "{0:N0}")})
        Me.BandedGridColumnNormal.Visible = True
        Me.BandedGridColumnNormal.Width = 97
        '
        'BandedGridColumnMajor
        '
        Me.BandedGridColumnMajor.Caption = "MAJOR"
        Me.BandedGridColumnMajor.DisplayFormat.FormatString = "{0:n0}"
        Me.BandedGridColumnMajor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnMajor.FieldName = "reject_major"
        Me.BandedGridColumnMajor.Name = "BandedGridColumnMajor"
        Me.BandedGridColumnMajor.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_major", "{0:n0}")})
        Me.BandedGridColumnMajor.Visible = True
        Me.BandedGridColumnMajor.Width = 97
        '
        'BandedGridColumnMinor
        '
        Me.BandedGridColumnMinor.Caption = "MINOR"
        Me.BandedGridColumnMinor.DisplayFormat.FormatString = "{0:n0}"
        Me.BandedGridColumnMinor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnMinor.FieldName = "reject_minor"
        Me.BandedGridColumnMinor.Name = "BandedGridColumnMinor"
        Me.BandedGridColumnMinor.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_minor", "{0:n0}")})
        Me.BandedGridColumnMinor.Visible = True
        Me.BandedGridColumnMinor.Width = 97
        '
        'BandedGridColumnAfkir
        '
        Me.BandedGridColumnAfkir.Caption = "AFKIR QC"
        Me.BandedGridColumnAfkir.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnAfkir.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAfkir.FieldName = "reject_afkir"
        Me.BandedGridColumnAfkir.Name = "BandedGridColumnAfkir"
        Me.BandedGridColumnAfkir.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reject_afkir", "{0:N0}")})
        Me.BandedGridColumnAfkir.Visible = True
        Me.BandedGridColumnAfkir.Width = 97
        '
        'BandedGridColumnTotalQC
        '
        Me.BandedGridColumnTotalQC.Caption = "TOTAL QC RESULT"
        Me.BandedGridColumnTotalQC.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalQC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalQC.FieldName = "qty_fc"
        Me.BandedGridColumnTotalQC.Name = "BandedGridColumnTotalQC"
        Me.BandedGridColumnTotalQC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_fc", "{0:N0}")})
        Me.BandedGridColumnTotalQC.Visible = True
        Me.BandedGridColumnTotalQC.Width = 130
        '
        'BandedGridColumnFinalRiject
        '
        Me.BandedGridColumnFinalRiject.Caption = "TOTAL REJECT"
        Me.BandedGridColumnFinalRiject.DisplayFormat.FormatString = "{0:n0}"
        Me.BandedGridColumnFinalRiject.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFinalRiject.FieldName = "qty_reject"
        Me.BandedGridColumnFinalRiject.Name = "BandedGridColumnFinalRiject"
        Me.BandedGridColumnFinalRiject.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_fc", "{0:n0}")})
        Me.BandedGridColumnFinalRiject.UnboundExpression = "[reject_major] + [reject_minor] + [reject_afkir]"
        Me.BandedGridColumnFinalRiject.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.BandedGridColumnFinalRiject.Visible = True
        Me.BandedGridColumnFinalRiject.Width = 79
        '
        'BandedGridColumnRejectProcentage
        '
        Me.BandedGridColumnRejectProcentage.Caption = "REJECT %"
        Me.BandedGridColumnRejectProcentage.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnRejectProcentage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRejectProcentage.FieldName = "reject_precentage"
        Me.BandedGridColumnRejectProcentage.Name = "BandedGridColumnRejectProcentage"
        Me.BandedGridColumnRejectProcentage.UnboundExpression = "([qty_reject] / [qty_rec]) * 100"
        Me.BandedGridColumnRejectProcentage.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnRejectProcentage.Visible = True
        Me.BandedGridColumnRejectProcentage.Width = 55
        '
        'BandedGridColumnDiffReceive
        '
        Me.BandedGridColumnDiffReceive.Caption = "DIFF RECEIVE"
        Me.BandedGridColumnDiffReceive.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnDiffReceive.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffReceive.FieldName = "qc_diff_receive"
        Me.BandedGridColumnDiffReceive.Name = "BandedGridColumnDiffReceive"
        Me.BandedGridColumnDiffReceive.UnboundExpression = "[qty_fc] - [qty_ret_total]"
        Me.BandedGridColumnDiffReceive.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.BandedGridColumnDiffReceive.Visible = True
        '
        'BandedGridColumnTotalPLToWHNormal
        '
        Me.BandedGridColumnTotalPLToWHNormal.Caption = "NORMAL"
        Me.BandedGridColumnTotalPLToWHNormal.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalPLToWHNormal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalPLToWHNormal.FieldName = "qty_pl_normal"
        Me.BandedGridColumnTotalPLToWHNormal.Name = "BandedGridColumnTotalPLToWHNormal"
        Me.BandedGridColumnTotalPLToWHNormal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_normal", "{0:N0}")})
        Me.BandedGridColumnTotalPLToWHNormal.Visible = True
        '
        'BandedGridColumnTotalPLToWHMajor
        '
        Me.BandedGridColumnTotalPLToWHMajor.Caption = "MAJOR"
        Me.BandedGridColumnTotalPLToWHMajor.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalPLToWHMajor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalPLToWHMajor.FieldName = "qty_pl_major"
        Me.BandedGridColumnTotalPLToWHMajor.Name = "BandedGridColumnTotalPLToWHMajor"
        Me.BandedGridColumnTotalPLToWHMajor.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_major", "{0:N0}")})
        Me.BandedGridColumnTotalPLToWHMajor.Visible = True
        '
        'BandedGridColumnTotalPLToWHMinor
        '
        Me.BandedGridColumnTotalPLToWHMinor.Caption = "MINOR"
        Me.BandedGridColumnTotalPLToWHMinor.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalPLToWHMinor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalPLToWHMinor.FieldName = "qty_pl_minor"
        Me.BandedGridColumnTotalPLToWHMinor.Name = "BandedGridColumnTotalPLToWHMinor"
        Me.BandedGridColumnTotalPLToWHMinor.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_minor", "{0:N0}")})
        Me.BandedGridColumnTotalPLToWHMinor.Visible = True
        '
        'BandedGridColumnTotalPLToWHAfkir
        '
        Me.BandedGridColumnTotalPLToWHAfkir.Caption = "AFKIR"
        Me.BandedGridColumnTotalPLToWHAfkir.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalPLToWHAfkir.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalPLToWHAfkir.FieldName = "qty_pl_afkir"
        Me.BandedGridColumnTotalPLToWHAfkir.Name = "BandedGridColumnTotalPLToWHAfkir"
        Me.BandedGridColumnTotalPLToWHAfkir.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_afkir", "{0:N0}")})
        Me.BandedGridColumnTotalPLToWHAfkir.Visible = True
        '
        'BandedGridColumnTotalPLToWH
        '
        Me.BandedGridColumnTotalPLToWH.Caption = "TOTAL"
        Me.BandedGridColumnTotalPLToWH.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalPLToWH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalPLToWH.FieldName = "qty_pl"
        Me.BandedGridColumnTotalPLToWH.Name = "BandedGridColumnTotalPLToWH"
        Me.BandedGridColumnTotalPLToWH.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl", "{0:N0}")})
        Me.BandedGridColumnTotalPLToWH.Visible = True
        Me.BandedGridColumnTotalPLToWH.Width = 106
        '
        'BandedGridColumnStatusToWH
        '
        Me.BandedGridColumnStatusToWH.Caption = "STATUS"
        Me.BandedGridColumnStatusToWH.FieldName = "status_pl"
        Me.BandedGridColumnStatusToWH.Name = "BandedGridColumnStatusToWH"
        Me.BandedGridColumnStatusToWH.Visible = True
        Me.BandedGridColumnStatusToWH.Width = 98
        '
        'BandedGridColumnDiffQcReport
        '
        Me.BandedGridColumnDiffQcReport.Caption = "DIFF QC REPORT"
        Me.BandedGridColumnDiffQcReport.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnDiffQcReport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffQcReport.FieldName = "diff_qc_report"
        Me.BandedGridColumnDiffQcReport.Name = "BandedGridColumnDiffQcReport"
        Me.BandedGridColumnDiffQcReport.UnboundExpression = "[qty_ret_total] - [qty_fc]"
        Me.BandedGridColumnDiffQcReport.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.BandedGridColumnDiffQcReport.Visible = True
        '
        'BandedGridColumnCOPPD
        '
        Me.BandedGridColumnCOPPD.Caption = "PD"
        Me.BandedGridColumnCOPPD.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnCOPPD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCOPPD.FieldName = "cop_pd"
        Me.BandedGridColumnCOPPD.Name = "BandedGridColumnCOPPD"
        Me.BandedGridColumnCOPPD.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnCOPPD.Visible = True
        Me.BandedGridColumnCOPPD.Width = 71
        '
        'BandedGridColumnCOPPDAmo
        '
        Me.BandedGridColumnCOPPDAmo.Caption = "PD AMOUNT"
        Me.BandedGridColumnCOPPDAmo.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnCOPPDAmo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCOPPDAmo.FieldName = "cop_pd_amo"
        Me.BandedGridColumnCOPPDAmo.Name = "BandedGridColumnCOPPDAmo"
        Me.BandedGridColumnCOPPDAmo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cop_pd_amo", "{0:n2}")})
        Me.BandedGridColumnCOPPDAmo.UnboundExpression = "[cop_pd] * [qty]"
        Me.BandedGridColumnCOPPDAmo.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnCOPPDAmo.Visible = True
        '
        'BandedGridColumnCOPPO
        '
        Me.BandedGridColumnCOPPO.Caption = " PO"
        Me.BandedGridColumnCOPPO.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnCOPPO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCOPPO.FieldName = "cop_po"
        Me.BandedGridColumnCOPPO.Name = "BandedGridColumnCOPPO"
        Me.BandedGridColumnCOPPO.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnCOPPO.Visible = True
        Me.BandedGridColumnCOPPO.Width = 34
        '
        'BandedGridColumnCOPPOAmo
        '
        Me.BandedGridColumnCOPPOAmo.Caption = "PO AMOUNT"
        Me.BandedGridColumnCOPPOAmo.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnCOPPOAmo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCOPPOAmo.FieldName = "cop_po_amo"
        Me.BandedGridColumnCOPPOAmo.Name = "BandedGridColumnCOPPOAmo"
        Me.BandedGridColumnCOPPOAmo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cop_po_amo", "{0:n2}")})
        Me.BandedGridColumnCOPPOAmo.UnboundExpression = "[cop_po] * [qty]"
        Me.BandedGridColumnCOPPOAmo.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnCOPPOAmo.Visible = True
        '
        'BandedGridColumnCOPPreFinal
        '
        Me.BandedGridColumnCOPPreFinal.Caption = "PRE FINAL"
        Me.BandedGridColumnCOPPreFinal.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnCOPPreFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCOPPreFinal.FieldName = "cop_pre_final"
        Me.BandedGridColumnCOPPreFinal.Name = "BandedGridColumnCOPPreFinal"
        Me.BandedGridColumnCOPPreFinal.Visible = True
        '
        'BandedGridColumnCOPPreFinalAmo
        '
        Me.BandedGridColumnCOPPreFinalAmo.Caption = "PRE FINAL AMOUNT"
        Me.BandedGridColumnCOPPreFinalAmo.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnCOPPreFinalAmo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCOPPreFinalAmo.FieldName = "cop_pre_final_amo"
        Me.BandedGridColumnCOPPreFinalAmo.Name = "BandedGridColumnCOPPreFinalAmo"
        Me.BandedGridColumnCOPPreFinalAmo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cop_pre_final_amo", "{0:n2}")})
        Me.BandedGridColumnCOPPreFinalAmo.UnboundExpression = "[cop_pre_final] * [qty_rec]"
        Me.BandedGridColumnCOPPreFinalAmo.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnCOPPreFinalAmo.Visible = True
        Me.BandedGridColumnCOPPreFinalAmo.Width = 114
        '
        'BandedGridColumnCOPPreFinalStt
        '
        Me.BandedGridColumnCOPPreFinalStt.Caption = "PRE FINAL STATUS"
        Me.BandedGridColumnCOPPreFinalStt.FieldName = "cop_pre_final_stt"
        Me.BandedGridColumnCOPPreFinalStt.Name = "BandedGridColumnCOPPreFinalStt"
        Me.BandedGridColumnCOPPreFinalStt.Visible = True
        Me.BandedGridColumnCOPPreFinalStt.Width = 100
        '
        'BandedGridColumnCOPFinal
        '
        Me.BandedGridColumnCOPFinal.Caption = "ACTUAL"
        Me.BandedGridColumnCOPFinal.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnCOPFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCOPFinal.FieldName = "cop_final"
        Me.BandedGridColumnCOPFinal.Name = "BandedGridColumnCOPFinal"
        Me.BandedGridColumnCOPFinal.Visible = True
        Me.BandedGridColumnCOPFinal.Width = 57
        '
        'BandedGridColumnCOPFinalAmo
        '
        Me.BandedGridColumnCOPFinalAmo.Caption = "ACT.  AMOUNT"
        Me.BandedGridColumnCOPFinalAmo.DisplayFormat.FormatString = "{0:n2}"
        Me.BandedGridColumnCOPFinalAmo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCOPFinalAmo.FieldName = "cop_final_amo"
        Me.BandedGridColumnCOPFinalAmo.Name = "BandedGridColumnCOPFinalAmo"
        Me.BandedGridColumnCOPFinalAmo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cop_final_amo", "{0:n2}")})
        Me.BandedGridColumnCOPFinalAmo.UnboundExpression = "[cop_final] * [qty_rec]"
        Me.BandedGridColumnCOPFinalAmo.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnCOPFinalAmo.Visible = True
        Me.BandedGridColumnCOPFinalAmo.Width = 84
        '
        'BandedGridColumnCOPFinalStt
        '
        Me.BandedGridColumnCOPFinalStt.Caption = "ACTUAL STATUS"
        Me.BandedGridColumnCOPFinalStt.FieldName = "cop_final_stt"
        Me.BandedGridColumnCOPFinalStt.Name = "BandedGridColumnCOPFinalStt"
        Me.BandedGridColumnCOPFinalStt.Visible = True
        '
        'BandedGridColumnIncDec
        '
        Me.BandedGridColumnIncDec.Caption = "INCREMENT PD vs ACTUAL"
        Me.BandedGridColumnIncDec.DisplayFormat.FormatString = "{0:n0}%"
        Me.BandedGridColumnIncDec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnIncDec.FieldName = "inc_dec"
        Me.BandedGridColumnIncDec.Name = "BandedGridColumnIncDec"
        Me.BandedGridColumnIncDec.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnIncDec.UnboundExpression = "(([cop_po]-[cop_pd])/[cop_pd])*100"
        Me.BandedGridColumnIncDec.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnIncDec.Visible = True
        Me.BandedGridColumnIncDec.Width = 125
        '
        'BandedGridColumnSel
        '
        Me.BandedGridColumnSel.Caption = "8"
        Me.BandedGridColumnSel.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.BandedGridColumnSel.FieldName = "is_select"
        Me.BandedGridColumnSel.Name = "BandedGridColumnSel"
        Me.BandedGridColumnSel.Visible = True
        Me.BandedGridColumnSel.Width = 44
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "No"
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.SLEVendorAppOrder)
        Me.GCFilter.Controls.Add(Me.BViewByPO)
        Me.GCFilter.Controls.Add(Me.SLESeason)
        Me.GCFilter.Controls.Add(Me.LabelControl11)
        Me.GCFilter.Controls.Add(Me.TEPONumber)
        Me.GCFilter.Controls.Add(Me.LabelControl12)
        Me.GCFilter.Controls.Add(Me.LabelControl10)
        Me.GCFilter.Controls.Add(Me.SLEDesignStockStore)
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.LabelControl13)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(1002, 39)
        Me.GCFilter.TabIndex = 4
        '
        'SLEVendorAppOrder
        '
        Me.SLEVendorAppOrder.Location = New System.Drawing.Point(463, 10)
        Me.SLEVendorAppOrder.Name = "SLEVendorAppOrder"
        Me.SLEVendorAppOrder.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendorAppOrder.Properties.Appearance.Options.UseFont = True
        Me.SLEVendorAppOrder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendorAppOrder.Properties.View = Me.GridView1
        Me.SLEVendorAppOrder.Size = New System.Drawing.Size(148, 20)
        Me.SLEVendorAppOrder.TabIndex = 8911
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn16, Me.GridColumn17})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Id Comp"
        Me.GridColumn15.FieldName = "id_comp"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Comp Number"
        Me.GridColumn16.FieldName = "comp_number"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 0
        Me.GridColumn16.Width = 188
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Comp Name"
        Me.GridColumn17.FieldName = "comp_name"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 1
        Me.GridColumn17.Width = 504
        '
        'BViewByPO
        '
        Me.BViewByPO.Location = New System.Drawing.Point(920, 9)
        Me.BViewByPO.LookAndFeel.SkinName = "Blue"
        Me.BViewByPO.Name = "BViewByPO"
        Me.BViewByPO.Size = New System.Drawing.Size(75, 20)
        Me.BViewByPO.TabIndex = 8901
        Me.BViewByPO.Text = "View"
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(264, 10)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(153, 20)
        Me.SLESeason.TabIndex = 8910
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn18, Me.GridColumn19})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Id Season"
        Me.GridColumn18.FieldName = "id_season"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Season"
        Me.GridColumn19.FieldName = "season"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(423, 13)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl11.TabIndex = 8909
        Me.LabelControl11.Text = "Vendor"
        '
        'TEPONumber
        '
        Me.TEPONumber.Location = New System.Drawing.Point(785, 9)
        Me.TEPONumber.Name = "TEPONumber"
        Me.TEPONumber.Size = New System.Drawing.Size(129, 20)
        Me.TEPONumber.TabIndex = 8900
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(223, 13)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl12.TabIndex = 8908
        Me.LabelControl12.Text = "Season"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(712, 12)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl10.TabIndex = 8899
        Me.LabelControl10.Text = "FGPO Number"
        '
        'SLEDesignStockStore
        '
        Me.SLEDesignStockStore.Location = New System.Drawing.Point(66, 10)
        Me.SLEDesignStockStore.Name = "SLEDesignStockStore"
        Me.SLEDesignStockStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDesignStockStore.Properties.View = Me.GVSLEDesgSearch
        Me.SLEDesignStockStore.Size = New System.Drawing.Size(151, 20)
        Me.SLEDesignStockStore.TabIndex = 8907
        '
        'GVSLEDesgSearch
        '
        Me.GVSLEDesgSearch.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCodeSearch, Me.GridColumn20, Me.GridColumn21})
        Me.GVSLEDesgSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GVSLEDesgSearch.Name = "GVSLEDesgSearch"
        Me.GVSLEDesgSearch.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVSLEDesgSearch.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCodeSearch
        '
        Me.GridColumnCodeSearch.Caption = "Code"
        Me.GridColumnCodeSearch.FieldName = "design_code"
        Me.GridColumnCodeSearch.Name = "GridColumnCodeSearch"
        Me.GridColumnCodeSearch.Visible = True
        Me.GridColumnCodeSearch.VisibleIndex = 0
        Me.GridColumnCodeSearch.Width = 186
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Description"
        Me.GridColumn20.FieldName = "display_name"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 1
        Me.GridColumn20.Width = 360
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn21.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn21.Caption = "Color"
        Me.GridColumn21.FieldName = "color"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 2
        Me.GridColumn21.Width = 146
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(617, 10)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Location = New System.Drawing.Point(24, 13)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl13.TabIndex = 8906
        Me.LabelControl13.Text = "Design"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(868, 122)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(873, 96)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'XTPPD
        '
        Me.XTPPD.Controls.Add(Me.GCPD)
        Me.XTPPD.Controls.Add(Me.GroupControl1)
        Me.XTPPD.Name = "XTPPD"
        Me.XTPPD.Size = New System.Drawing.Size(1002, 701)
        Me.XTPPD.Text = "Demand List"
        '
        'GCPD
        '
        Me.GCPD.ContextMenuStrip = Me.ViewMenuPD
        Me.GCPD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPD.Location = New System.Drawing.Point(0, 39)
        Me.GCPD.MainView = Me.GVPD
        Me.GCPD.Name = "GCPD"
        Me.GCPD.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCPD.Size = New System.Drawing.Size(1002, 662)
        Me.GCPD.TabIndex = 6
        Me.GCPD.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPD})
        '
        'ViewMenuPD
        '
        Me.ViewMenuPD.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailPDToolStripMenuItem})
        Me.ViewMenuPD.Name = "ContextMenuStripYM"
        Me.ViewMenuPD.Size = New System.Drawing.Size(151, 26)
        '
        'ViewDetailPDToolStripMenuItem
        '
        Me.ViewDetailPDToolStripMenuItem.Name = "ViewDetailPDToolStripMenuItem"
        Me.ViewDetailPDToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ViewDetailPDToolStripMenuItem.Text = "View Detail PD"
        '
        'GVPD
        '
        Me.GVPD.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8})
        Me.GVPD.GridControl = Me.GCPD
        Me.GVPD.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", Me.GridColumn3, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_price", Me.GridColumn4, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", Me.GridColumn5, "{0:n0}")})
        Me.GVPD.Name = "GVPD"
        Me.GVPD.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPD.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPD.OptionsView.ShowFooter = True
        Me.GVPD.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PD#"
        Me.GridColumn1.FieldName = "prod_demand_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 141
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "SEASON"
        Me.GridColumn2.FieldName = "season"
        Me.GridColumn2.FieldNameSortGroup = "id_season"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 141
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "TOTAL EST. COST"
        Me.GridColumn3.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "total_cost"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:n2}")})
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 153
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "TOTAL EST. RETAIL"
        Me.GridColumn4.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "total_price"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_price", "{0:n2}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        Me.GridColumn4.Width = 153
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "QTY"
        Me.GridColumn5.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "total_qty"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:n0}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        Me.GridColumn5.Width = 153
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "MARKUP"
        Me.GridColumn6.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "markup"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.UnboundExpression = "[total_price]/[total_cost]"
        Me.GridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 6
        Me.GridColumn6.Width = 191
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "ORIGIN"
        Me.GridColumn7.FieldName = "source"
        Me.GridColumn7.FieldNameSortGroup = "id_source"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        Me.GridColumn7.Width = 88
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "  "
        Me.GridColumn8.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn8.FieldName = "is_select"
        Me.GridColumn8.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        Me.GridColumn8.Width = 40
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.BtnViewPD)
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.SimpleButton3)
        Me.GroupControl1.Controls.Add(Me.DEUntilPD)
        Me.GroupControl1.Controls.Add(Me.DEFromPD)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1002, 39)
        Me.GroupControl1.TabIndex = 5
        '
        'BtnViewPD
        '
        Me.BtnViewPD.Location = New System.Drawing.Point(317, 9)
        Me.BtnViewPD.LookAndFeel.SkinName = "Blue"
        Me.BtnViewPD.Name = "BtnViewPD"
        Me.BtnViewPD.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewPD.TabIndex = 8896
        Me.BtnViewPD.Text = "View"
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
        'DEUntilPD
        '
        Me.DEUntilPD.EditValue = Nothing
        Me.DEUntilPD.Location = New System.Drawing.Point(202, 9)
        Me.DEUntilPD.Name = "DEUntilPD"
        Me.DEUntilPD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilPD.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilPD.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilPD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilPD.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilPD.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilPD.TabIndex = 8895
        '
        'DEFromPD
        '
        Me.DEFromPD.EditValue = Nothing
        Me.DEFromPD.Location = New System.Drawing.Point(58, 9)
        Me.DEFromPD.Name = "DEFromPD"
        Me.DEFromPD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromPD.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromPD.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromPD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromPD.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromPD.Size = New System.Drawing.Size(111, 20)
        Me.DEFromPD.TabIndex = 8894
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl1.TabIndex = 8893
        Me.LabelControl1.Text = "Until"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl4.TabIndex = 8892
        Me.LabelControl4.Text = "From"
        '
        'XTPPOMat
        '
        Me.XTPPOMat.Controls.Add(Me.GCListPurchase)
        Me.XTPPOMat.Controls.Add(Me.GroupControl2)
        Me.XTPPOMat.Name = "XTPPOMat"
        Me.XTPPOMat.Size = New System.Drawing.Size(1002, 701)
        Me.XTPPOMat.Text = "Purchase Material"
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 39)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Margin = New System.Windows.Forms.Padding(0)
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(1002, 662)
        Me.GCListPurchase.TabIndex = 6
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdMatDetPrice, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColDiscount, Me.ColSubtotal, Me.ColNote, Me.GridColumnSize, Me.GridColumn9, Me.GridColumnPOMatNo, Me.GridColumnPOMatRef, Me.GridColumnVendor, Me.GridColumnType, Me.GridColumnMatPaymentTyp, Me.GridColumnLeadTime, Me.GridColumnTOP, Me.GridColumnMatSeason, Me.GridColumnMatCreatedDate, Me.GridColumnMatEstRecDate, Me.GridColumnMatDueDate, Me.GridColumnSattus, Me.GridColumnUOM, Me.GridColumnMatVat, Me.GridColumnVatTotal, Me.GridColumnMatTotal, Me.GridColumnMatCur, Me.GridColumnMatKurs})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.ColQty, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.ColSubtotal, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", Me.GridColumnMatTotal, "{0:n2}")})
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVListPurchase.OptionsBehavior.ReadOnly = True
        Me.GVListPurchase.OptionsView.ColumnAutoWidth = False
        Me.GVListPurchase.OptionsView.ShowFooter = True
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        Me.GVListPurchase.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdPurcDet, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Purc Det"
        Me.ColIdPurcDet.FieldName = "id_mat_purc_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        '
        'ColIdMatDetPrice
        '
        Me.ColIdMatDetPrice.Caption = "Id Mat Price"
        Me.ColIdMatDetPrice.FieldName = "id_mat_det_price"
        Me.ColIdMatDetPrice.Name = "ColIdMatDetPrice"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.Width = 35
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 5
        Me.ColCode.Width = 100
        '
        'ColName
        '
        Me.ColName.Caption = "Description"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 6
        Me.ColName.Width = 225
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N4"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 13
        Me.ColPrice.Width = 68
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.DisplayFormat.FormatString = "{0:n2}"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:n2}")})
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 9
        Me.ColQty.Width = 56
        '
        'ColDiscount
        '
        Me.ColDiscount.AppearanceCell.Options.UseTextOptions = True
        Me.ColDiscount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDiscount.AppearanceHeader.Options.UseTextOptions = True
        Me.ColDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDiscount.Caption = "Discount"
        Me.ColDiscount.DisplayFormat.FormatString = "N4"
        Me.ColDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDiscount.FieldName = "discount"
        Me.ColDiscount.Name = "ColDiscount"
        Me.ColDiscount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "discount", "{0:N2}")})
        Me.ColDiscount.Visible = True
        Me.ColDiscount.VisibleIndex = 14
        Me.ColDiscount.Width = 74
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
        Me.ColSubtotal.VisibleIndex = 15
        Me.ColSubtotal.Width = 103
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Width = 80
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
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 8
        Me.GridColumnSize.Width = 44
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.Caption = "Color"
        Me.GridColumn9.FieldName = "color"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 71
        '
        'GridColumnPOMatNo
        '
        Me.GridColumnPOMatNo.Caption = "PO#"
        Me.GridColumnPOMatNo.FieldName = "mat_purc_number"
        Me.GridColumnPOMatNo.Name = "GridColumnPOMatNo"
        Me.GridColumnPOMatNo.Visible = True
        Me.GridColumnPOMatNo.VisibleIndex = 0
        '
        'GridColumnPOMatRef
        '
        Me.GridColumnPOMatRef.Caption = "Ref#"
        Me.GridColumnPOMatRef.FieldName = "mat_purc_number_rev"
        Me.GridColumnPOMatRef.Name = "GridColumnPOMatRef"
        Me.GridColumnPOMatRef.Visible = True
        Me.GridColumnPOMatRef.VisibleIndex = 1
        Me.GridColumnPOMatRef.Width = 55
        '
        'GridColumnVendor
        '
        Me.GridColumnVendor.Caption = "Vendor"
        Me.GridColumnVendor.FieldName = "vendor"
        Me.GridColumnVendor.Name = "GridColumnVendor"
        Me.GridColumnVendor.Visible = True
        Me.GridColumnVendor.VisibleIndex = 2
        Me.GridColumnVendor.Width = 116
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "PO Type"
        Me.GridColumnType.FieldName = "po_type"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.Visible = True
        Me.GridColumnType.VisibleIndex = 3
        Me.GridColumnType.Width = 92
        '
        'GridColumnMatPaymentTyp
        '
        Me.GridColumnMatPaymentTyp.Caption = "Payment Type"
        Me.GridColumnMatPaymentTyp.FieldName = "payment"
        Me.GridColumnMatPaymentTyp.Name = "GridColumnMatPaymentTyp"
        Me.GridColumnMatPaymentTyp.Visible = True
        Me.GridColumnMatPaymentTyp.VisibleIndex = 19
        Me.GridColumnMatPaymentTyp.Width = 92
        '
        'GridColumnLeadTime
        '
        Me.GridColumnLeadTime.Caption = "Lead Time"
        Me.GridColumnLeadTime.DisplayFormat.FormatString = "N0"
        Me.GridColumnLeadTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnLeadTime.FieldName = "mat_purc_lead_time"
        Me.GridColumnLeadTime.Name = "GridColumnLeadTime"
        Me.GridColumnLeadTime.Visible = True
        Me.GridColumnLeadTime.VisibleIndex = 20
        Me.GridColumnLeadTime.Width = 65
        '
        'GridColumnTOP
        '
        Me.GridColumnTOP.Caption = "TOP"
        Me.GridColumnTOP.DisplayFormat.FormatString = "N0"
        Me.GridColumnTOP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTOP.FieldName = "mat_purc_top"
        Me.GridColumnTOP.Name = "GridColumnTOP"
        Me.GridColumnTOP.Visible = True
        Me.GridColumnTOP.VisibleIndex = 21
        Me.GridColumnTOP.Width = 35
        '
        'GridColumnMatSeason
        '
        Me.GridColumnMatSeason.Caption = "Season"
        Me.GridColumnMatSeason.FieldName = "season"
        Me.GridColumnMatSeason.Name = "GridColumnMatSeason"
        Me.GridColumnMatSeason.Visible = True
        Me.GridColumnMatSeason.VisibleIndex = 4
        '
        'GridColumnMatCreatedDate
        '
        Me.GridColumnMatCreatedDate.Caption = "Created Date"
        Me.GridColumnMatCreatedDate.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnMatCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnMatCreatedDate.FieldName = "mat_purc_date"
        Me.GridColumnMatCreatedDate.Name = "GridColumnMatCreatedDate"
        Me.GridColumnMatCreatedDate.Visible = True
        Me.GridColumnMatCreatedDate.VisibleIndex = 22
        '
        'GridColumnMatEstRecDate
        '
        Me.GridColumnMatEstRecDate.Caption = "Est. Rec. Date"
        Me.GridColumnMatEstRecDate.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnMatEstRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnMatEstRecDate.FieldName = "rec_date"
        Me.GridColumnMatEstRecDate.Name = "GridColumnMatEstRecDate"
        Me.GridColumnMatEstRecDate.UnboundExpression = "AddDays([mat_purc_date], [mat_purc_lead_time])"
        Me.GridColumnMatEstRecDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
        Me.GridColumnMatEstRecDate.Visible = True
        Me.GridColumnMatEstRecDate.VisibleIndex = 23
        '
        'GridColumnMatDueDate
        '
        Me.GridColumnMatDueDate.Caption = "Due Date"
        Me.GridColumnMatDueDate.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnMatDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnMatDueDate.FieldName = "due_date"
        Me.GridColumnMatDueDate.Name = "GridColumnMatDueDate"
        Me.GridColumnMatDueDate.UnboundExpression = "AddDays([mat_purc_date], [mat_purc_top])"
        Me.GridColumnMatDueDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
        Me.GridColumnMatDueDate.Visible = True
        Me.GridColumnMatDueDate.VisibleIndex = 24
        '
        'GridColumnSattus
        '
        Me.GridColumnSattus.Caption = "Status"
        Me.GridColumnSattus.FieldName = "report_status"
        Me.GridColumnSattus.Name = "GridColumnSattus"
        Me.GridColumnSattus.Visible = True
        Me.GridColumnSattus.VisibleIndex = 25
        Me.GridColumnSattus.Width = 108
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 10
        Me.GridColumnUOM.Width = 42
        '
        'GridColumnMatVat
        '
        Me.GridColumnMatVat.Caption = "Vat (%)"
        Me.GridColumnMatVat.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnMatVat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMatVat.FieldName = "mat_purc_vat"
        Me.GridColumnMatVat.Name = "GridColumnMatVat"
        Me.GridColumnMatVat.Visible = True
        Me.GridColumnMatVat.VisibleIndex = 16
        Me.GridColumnMatVat.Width = 54
        '
        'GridColumnVatTotal
        '
        Me.GridColumnVatTotal.Caption = "Vat"
        Me.GridColumnVatTotal.DisplayFormat.FormatString = "N2"
        Me.GridColumnVatTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnVatTotal.FieldName = "total_vat"
        Me.GridColumnVatTotal.Name = "GridColumnVatTotal"
        Me.GridColumnVatTotal.UnboundExpression = "[mat_purc_vat] * [total] / 100"
        Me.GridColumnVatTotal.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnVatTotal.Visible = True
        Me.GridColumnVatTotal.VisibleIndex = 17
        '
        'GridColumnMatTotal
        '
        Me.GridColumnMatTotal.Caption = "Total"
        Me.GridColumnMatTotal.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnMatTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMatTotal.FieldName = "grand_total"
        Me.GridColumnMatTotal.Name = "GridColumnMatTotal"
        Me.GridColumnMatTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:n2}")})
        Me.GridColumnMatTotal.UnboundExpression = "[total] + [total_vat]"
        Me.GridColumnMatTotal.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnMatTotal.Visible = True
        Me.GridColumnMatTotal.VisibleIndex = 18
        Me.GridColumnMatTotal.Width = 79
        '
        'GridColumnMatCur
        '
        Me.GridColumnMatCur.Caption = "Currency"
        Me.GridColumnMatCur.FieldName = "currency"
        Me.GridColumnMatCur.Name = "GridColumnMatCur"
        Me.GridColumnMatCur.Visible = True
        Me.GridColumnMatCur.VisibleIndex = 11
        Me.GridColumnMatCur.Width = 52
        '
        'GridColumnMatKurs
        '
        Me.GridColumnMatKurs.Caption = "Kurs"
        Me.GridColumnMatKurs.DisplayFormat.FormatString = "N2"
        Me.GridColumnMatKurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMatKurs.FieldName = "mat_purc_kurs"
        Me.GridColumnMatKurs.Name = "GridColumnMatKurs"
        Me.GridColumnMatKurs.Visible = True
        Me.GridColumnMatKurs.VisibleIndex = 12
        Me.GridColumnMatKurs.Width = 58
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.BtnViewMat)
        Me.GroupControl2.Controls.Add(Me.SimpleButton4)
        Me.GroupControl2.Controls.Add(Me.SimpleButton5)
        Me.GroupControl2.Controls.Add(Me.DEUntilMat)
        Me.GroupControl2.Controls.Add(Me.DEFromMat)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1002, 39)
        Me.GroupControl2.TabIndex = 5
        '
        'BtnViewMat
        '
        Me.BtnViewMat.Location = New System.Drawing.Point(317, 9)
        Me.BtnViewMat.LookAndFeel.SkinName = "Blue"
        Me.BtnViewMat.Name = "BtnViewMat"
        Me.BtnViewMat.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewMat.TabIndex = 8896
        Me.BtnViewMat.Text = "View"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.ImageIndex = 9
        Me.SimpleButton4.Location = New System.Drawing.Point(938, 14)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(104, 20)
        Me.SimpleButton4.TabIndex = 8898
        Me.SimpleButton4.Text = "Hide All Detail"
        Me.SimpleButton4.Visible = False
        '
        'SimpleButton5
        '
        Me.SimpleButton5.ImageIndex = 8
        Me.SimpleButton5.Location = New System.Drawing.Point(835, 14)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(99, 20)
        Me.SimpleButton5.TabIndex = 8897
        Me.SimpleButton5.Text = "Expand All Detail"
        Me.SimpleButton5.Visible = False
        '
        'DEUntilMat
        '
        Me.DEUntilMat.EditValue = Nothing
        Me.DEUntilMat.Location = New System.Drawing.Point(202, 9)
        Me.DEUntilMat.Name = "DEUntilMat"
        Me.DEUntilMat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilMat.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilMat.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilMat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilMat.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilMat.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilMat.TabIndex = 8895
        '
        'DEFromMat
        '
        Me.DEFromMat.EditValue = Nothing
        Me.DEFromMat.Location = New System.Drawing.Point(58, 9)
        Me.DEFromMat.Name = "DEFromMat"
        Me.DEFromMat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromMat.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromMat.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromMat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromMat.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromMat.Size = New System.Drawing.Size(111, 20)
        Me.DEFromMat.TabIndex = 8894
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl5.TabIndex = 8893
        Me.LabelControl5.Text = "Until"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl6.TabIndex = 8892
        Me.LabelControl6.Text = "From"
        '
        'XTPFGPO
        '
        Me.XTPFGPO.Controls.Add(Me.GCProdRec)
        Me.XTPFGPO.Controls.Add(Me.GroupControl3)
        Me.XTPFGPO.Name = "XTPFGPO"
        Me.XTPFGPO.Size = New System.Drawing.Size(1002, 701)
        Me.XTPFGPO.Text = "Receiving FG PO"
        '
        'GCProdRec
        '
        Me.GCProdRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdRec.Location = New System.Drawing.Point(0, 39)
        Me.GCProdRec.MainView = Me.GVProdRec
        Me.GCProdRec.Name = "GCProdRec"
        Me.GCProdRec.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit1, Me.RepositoryItemTextEdit1})
        Me.GCProdRec.Size = New System.Drawing.Size(1002, 662)
        Me.GCProdRec.TabIndex = 3
        Me.GCProdRec.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdRec, Me.GridView3})
        '
        'GVProdRec
        '
        Me.GVProdRec.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnRecVendor, Me.ColIdPRodOrderRecPurc, Me.ColRecNumber, Me.ColRecDate, Me.ColDueDate, Me.ColPSONumber, Me.ColDONumber, Me.ColIDStatus, Me.ColStatus, Me.GridColumnName, Me.GridColumnStyleCode, Me.GridColumnEstRecDate, Me.GridColumn13, Me.GridColumn14})
        Me.GVProdRec.GridControl = Me.GCProdRec
        Me.GVProdRec.Name = "GVProdRec"
        Me.GVProdRec.OptionsBehavior.Editable = False
        Me.GVProdRec.OptionsFind.AlwaysVisible = True
        Me.GVProdRec.OptionsView.ShowGroupPanel = False
        '
        'GridColumnRecVendor
        '
        Me.GridColumnRecVendor.Caption = "Vendor"
        Me.GridColumnRecVendor.FieldName = "comp_from"
        Me.GridColumnRecVendor.Name = "GridColumnRecVendor"
        Me.GridColumnRecVendor.Visible = True
        Me.GridColumnRecVendor.VisibleIndex = 0
        '
        'ColIdPRodOrderRecPurc
        '
        Me.ColIdPRodOrderRecPurc.Caption = "ID Prod Order Rec"
        Me.ColIdPRodOrderRecPurc.FieldName = "id_prod_order_rec"
        Me.ColIdPRodOrderRecPurc.Name = "ColIdPRodOrderRecPurc"
        '
        'ColRecNumber
        '
        Me.ColRecNumber.Caption = "Number"
        Me.ColRecNumber.FieldName = "prod_order_rec_number"
        Me.ColRecNumber.Name = "ColRecNumber"
        Me.ColRecNumber.Visible = True
        Me.ColRecNumber.VisibleIndex = 1
        Me.ColRecNumber.Width = 67
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Receive Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "prod_order_rec_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 7
        Me.ColRecDate.Width = 104
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Delivery Order Date"
        Me.ColDueDate.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "delivery_order_date"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 9
        Me.ColDueDate.Width = 115
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'ColPSONumber
        '
        Me.ColPSONumber.Caption = "FG PO No"
        Me.ColPSONumber.FieldName = "prod_order_number"
        Me.ColPSONumber.Name = "ColPSONumber"
        Me.ColPSONumber.Visible = True
        Me.ColPSONumber.VisibleIndex = 2
        Me.ColPSONumber.Width = 68
        '
        'ColDONumber
        '
        Me.ColDONumber.Caption = "DO Number"
        Me.ColDONumber.FieldName = "delivery_order_number"
        Me.ColDONumber.Name = "ColDONumber"
        Me.ColDONumber.Visible = True
        Me.ColDONumber.VisibleIndex = 5
        Me.ColDONumber.Width = 81
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
        Me.ColStatus.VisibleIndex = 11
        Me.ColStatus.Width = 76
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Style"
        Me.GridColumnName.FieldName = "design_display_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 3
        Me.GridColumnName.Width = 68
        '
        'GridColumnStyleCode
        '
        Me.GridColumnStyleCode.Caption = "Style Code"
        Me.GridColumnStyleCode.FieldName = "design_code"
        Me.GridColumnStyleCode.Name = "GridColumnStyleCode"
        Me.GridColumnStyleCode.Visible = True
        Me.GridColumnStyleCode.VisibleIndex = 4
        '
        'GridColumnEstRecDate
        '
        Me.GridColumnEstRecDate.Caption = "Est. Receive Date"
        Me.GridColumnEstRecDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnEstRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnEstRecDate.FieldName = "est_po_rec"
        Me.GridColumnEstRecDate.Name = "GridColumnEstRecDate"
        Me.GridColumnEstRecDate.Visible = True
        Me.GridColumnEstRecDate.VisibleIndex = 6
        Me.GridColumnEstRecDate.Width = 94
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Different (Receiving Date)"
        Me.GridColumn13.FieldName = "late_rec_qc"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 8
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Different (Delivery Date)"
        Me.GridColumn14.FieldName = "late_vendor"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 10
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.NullText = "-"
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCProdRec
        Me.GridView3.Name = "GridView3"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.DEUntilRec)
        Me.GroupControl3.Controls.Add(Me.DEFromRec)
        Me.GroupControl3.Controls.Add(Me.LabelControl8)
        Me.GroupControl3.Controls.Add(Me.LabelControl9)
        Me.GroupControl3.Controls.Add(Me.SLEVendor)
        Me.GroupControl3.Controls.Add(Me.BSearch)
        Me.GroupControl3.Controls.Add(Me.LabelControl7)
        Me.GroupControl3.Controls.Add(Me.SimpleButton6)
        Me.GroupControl3.Controls.Add(Me.SimpleButton7)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl3.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(1002, 39)
        Me.GroupControl3.TabIndex = 6
        '
        'DEUntilRec
        '
        Me.DEUntilRec.EditValue = Nothing
        Me.DEUntilRec.Location = New System.Drawing.Point(442, 8)
        Me.DEUntilRec.Name = "DEUntilRec"
        Me.DEUntilRec.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilRec.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilRec.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilRec.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilRec.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilRec.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilRec.TabIndex = 8914
        '
        'DEFromRec
        '
        Me.DEFromRec.EditValue = Nothing
        Me.DEFromRec.Location = New System.Drawing.Point(298, 8)
        Me.DEFromRec.Name = "DEFromRec"
        Me.DEFromRec.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromRec.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromRec.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromRec.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromRec.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromRec.Size = New System.Drawing.Size(111, 20)
        Me.DEFromRec.TabIndex = 8913
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(415, 11)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl8.TabIndex = 8912
        Me.LabelControl8.Text = "Until"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(266, 11)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl9.TabIndex = 8911
        Me.LabelControl9.Text = "From"
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(63, 8)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendor.Properties.Appearance.Options.UseFont = True
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView14
        Me.SLEVendor.Size = New System.Drawing.Size(197, 20)
        Me.SLEVendor.TabIndex = 8910
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
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(559, 7)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8908
        Me.BSearch.Text = "Search"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(23, 11)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl7.TabIndex = 8907
        Me.LabelControl7.Text = "Vendor"
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
        'BandedGridColumnQtySNI
        '
        Me.BandedGridColumnQtySNI.Caption = "QTY SNI"
        Me.BandedGridColumnQtySNI.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnQtySNI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtySNI.FieldName = "qty_sni"
        Me.BandedGridColumnQtySNI.Name = "BandedGridColumnQtySNI"
        Me.BandedGridColumnQtySNI.Visible = True
        '
        'gridBandStyle
        '
        Me.gridBandStyle.Caption = "STYLE"
        Me.gridBandStyle.Columns.Add(Me.BandedGridColumnCode)
        Me.gridBandStyle.Columns.Add(Me.BandedGridColumnDescription)
        Me.gridBandStyle.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gridBandStyle.Name = "gridBandStyle"
        Me.gridBandStyle.VisibleIndex = 0
        Me.gridBandStyle.Width = 134
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "ORDER"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPO)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnVendor)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnSeason)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnDelivery)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnClass)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnDiv)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnSource)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnInWHDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnInStoreDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPOType)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnTerm)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPODate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnRecDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnRecDateKO)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnRevDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPLToWHDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnRs)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnQty)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPOAmo)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 1
        Me.gridBand3.Width = 1513
        '
        'gridBand23
        '
        Me.gridBand23.Caption = "RECEIVE QTY"
        Me.gridBand23.Columns.Add(Me.BandedGridColumnQtyRec)
        Me.gridBand23.Columns.Add(Me.BandedGridColumnStatusRecQc)
        Me.gridBand23.Columns.Add(Me.BandedGridColumnQtyRecOut)
        Me.gridBand23.Columns.Add(Me.BandedGridColumnQtyRecIn)
        Me.gridBand23.Columns.Add(Me.BandedGridColumnQtyRecClaim)
        Me.gridBand23.Columns.Add(Me.BandedGridColumnQtyRecOutstanding)
        Me.gridBand23.Columns.Add(Me.BandedGridColumnQtySNI)
        Me.gridBand23.Columns.Add(Me.BandedGridColumnQtyRecTotal)
        Me.gridBand23.Columns.Add(Me.BandedGridColumnDiffOrder)
        Me.gridBand23.Name = "gridBand23"
        Me.gridBand23.VisibleIndex = 2
        Me.gridBand23.Width = 743
        '
        'gridBandRejectDetail
        '
        Me.gridBandRejectDetail.Caption = "QC RESULT"
        Me.gridBandRejectDetail.Columns.Add(Me.BandedGridColumnNormal)
        Me.gridBandRejectDetail.Columns.Add(Me.BandedGridColumnMajor)
        Me.gridBandRejectDetail.Columns.Add(Me.BandedGridColumnMinor)
        Me.gridBandRejectDetail.Columns.Add(Me.BandedGridColumnAfkir)
        Me.gridBandRejectDetail.Columns.Add(Me.BandedGridColumnTotalQC)
        Me.gridBandRejectDetail.Columns.Add(Me.BandedGridColumnFinalRiject)
        Me.gridBandRejectDetail.Columns.Add(Me.BandedGridColumnRejectProcentage)
        Me.gridBandRejectDetail.Columns.Add(Me.BandedGridColumnDiffReceive)
        Me.gridBandRejectDetail.Name = "gridBandRejectDetail"
        Me.gridBandRejectDetail.VisibleIndex = 3
        Me.gridBandRejectDetail.Width = 727
        '
        'gridBand39
        '
        Me.gridBand39.Caption = "HANDOVER TO WH (PACKING LIST)"
        Me.gridBand39.Columns.Add(Me.BandedGridColumnTotalPLToWHNormal)
        Me.gridBand39.Columns.Add(Me.BandedGridColumnTotalPLToWHMajor)
        Me.gridBand39.Columns.Add(Me.BandedGridColumnTotalPLToWHMinor)
        Me.gridBand39.Columns.Add(Me.BandedGridColumnTotalPLToWHAfkir)
        Me.gridBand39.Columns.Add(Me.BandedGridColumnTotalPLToWH)
        Me.gridBand39.Columns.Add(Me.BandedGridColumnStatusToWH)
        Me.gridBand39.Columns.Add(Me.BandedGridColumnDiffQcReport)
        Me.gridBand39.Name = "gridBand39"
        Me.gridBand39.VisibleIndex = 4
        Me.gridBand39.Width = 579
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "COP"
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCOPPD)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCOPPDAmo)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCOPPO)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCOPPOAmo)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCOPPreFinal)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCOPPreFinalAmo)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCOPPreFinalStt)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCOPFinal)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCOPFinalAmo)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCOPFinalStt)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnIncDec)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 5
        Me.GridBand1.Width = 885
        '
        'gridBand20
        '
        Me.gridBand20.Columns.Add(Me.BandedGridColumnSel)
        Me.gridBand20.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.gridBand20.Name = "gridBand20"
        Me.gridBand20.Visible = False
        Me.gridBand20.VisibleIndex = -1
        Me.gridBand20.Width = 44
        '
        'FormProductionSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.XTCSum)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Production Summary"
        CType(Me.XTCSum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSum.ResumeLayout(False)
        Me.XTPDesign.ResumeLayout(False)
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.SLEVendorAppOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPD.ResumeLayout(False)
        CType(Me.GCPD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenuPD.ResumeLayout(False)
        CType(Me.GVPD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.DEUntilPD.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilPD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromPD.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromPD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPOMat.ResumeLayout(False)
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.DEUntilMat.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilMat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromMat.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromMat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPFGPO.ResumeLayout(False)
        CType(Me.GCProdRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.DEUntilRec.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilRec.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromRec.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromRec.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCSum As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDesign As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPD As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewPD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilPD As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromPD As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents BandedGridColumnPO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnVendor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDescription As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPOAmo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOPPD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOPPO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnIncDec As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSource As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSeason As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnClass As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiv As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRs As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCPD As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BandedGridColumnSel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BandedGridColumnCOPFinal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyRec As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFinalRiject As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRejectProcentage As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents XTPPOMat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewMat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilMat As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromMat As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMatDetPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOMatNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOMatRef As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatPaymentTyp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLeadTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTOP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatEstRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSattus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatVat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVatTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatCur As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatKurs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPFGPO As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCProdRec As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdRec As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPRodOrderRecPurc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ColPSONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView14 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEUntilRec As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromRec As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnStyleCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecVendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnCOPPDAmo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOPPOAmo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOPFinalAmo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnMajor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnMinor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOPPreFinal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOPPreFinalAmo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDelivery As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents ViewDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SMEditEcopFinal As ToolStripMenuItem
    Friend WithEvents BViewByPO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEPONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BandedGridColumnTotalPLToWH As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnStatusToWH As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnStatusRecQc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ViewMenuPD As ContextMenuStrip
    Friend WithEvents ViewDetailPDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BandedGridColumnQtyRecOut As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyRecIn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyRecClaim As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyRecOutstanding As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalPLToWHNormal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalPLToWHMajor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalPLToWHMinor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalPLToWHAfkir As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyRecTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnInWHDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnInStoreDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPOType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTerm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPODate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRecDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRecDateKO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRevDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPLToWHDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SLEVendorAppOrder As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDesignStockStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GVSLEDesgSearch As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodeSearch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BandedGridColumnNormal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAfkir As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalQC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOPPreFinalStt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOPFinalStt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiffOrder As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiffReceive As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiffQcReport As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtySNI As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandStyle As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand23 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandRejectDetail As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand39 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand20 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
