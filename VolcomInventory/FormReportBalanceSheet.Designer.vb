<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportBalanceSheet
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
        Me.components = New System.ComponentModel.Container()
        Me.PCFilterUpper = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEUnit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.TLBalanceSheet = New DevExpress.XtraTreeList.TreeList()
        Me.treeListBand3 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLAccount = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand4 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLPrevMonth = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLThisMonth = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCIDAcc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCIDAccParent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLCredit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand1 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.treeListBand2 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.XTCBalanceSheet = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPGeneralLedger = New DevExpress.XtraTab.XtraTabPage()
        Me.TLLedger = New DevExpress.XtraTreeList.TreeList()
        Me.treeListBand5 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLAccName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLAccDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand6 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCLedDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLedCredit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLIDAcc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLIdAccParent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCLedIDAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.XTPBalanceSheet = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCBS = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBSLedger = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPBSReport = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitterBS = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCAktiva = New DevExpress.XtraGrid.GridControl()
        Me.GVAktiva = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnPrevMonth = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnThisMonth = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCPasiva = New DevExpress.XtraGrid.GridControl()
        Me.GVPasiva = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn16 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn17 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn18 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.XTPProfitAndLoss = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCProfitAndLoss = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPATreeView = New DevExpress.XtraTab.XtraTabPage()
        Me.TLProfitAndLoss = New DevExpress.XtraTreeList.TreeList()
        Me.treeListBand7 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCPLAccount = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.treeListBand8 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.TCPLPrevMonth = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLThisMonth = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLIdAcc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLIdAccParent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLCredit = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TCPLIdAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.XTPPLReportView = New DevExpress.XtraTab.XtraTabPage()
        Me.GCProfitAndLoss = New DevExpress.XtraGrid.GridControl()
        Me.GVProfitAndLoss = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn19 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn20 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn21 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn28 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn22 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn27 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnYTD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn29 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn23 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn24 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn25 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.XTPPajak = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPTaxDetail = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPendingLapor = New DevExpress.XtraTab.XtraTabPage()
        Me.GCTaxReport = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewJournalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVTaxReport = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICETaxReport = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnTaxCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPPNPPH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTarif = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDPP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAlamatNPWP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn73 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BReported = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.XTPPendingTransaction = New DevExpress.XtraTab.XtraTabPage()
        Me.GCTaxPending = New DevExpress.XtraGrid.GridControl()
        Me.GVTaxPending = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn74 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPLapor = New DevExpress.XtraTab.XtraTabPage()
        Me.GCActiveTax = New DevExpress.XtraGrid.GridControl()
        Me.GVActiveTax = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEActiveTax = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnActiveTaxCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn75 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BMoveActiveTax = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelAllActiveTax = New DevExpress.XtraEditors.CheckEdit()
        Me.PCPajak = New DevExpress.XtraEditors.PanelControl()
        Me.XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.SBSummaryPpn = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSetup = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SBSummary = New DevExpress.XtraEditors.SimpleButton()
        Me.DETaxFrom = New DevExpress.XtraEditors.DateEdit()
        Me.SLETaxCat = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BViewPajak = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BPrintPajak = New DevExpress.XtraEditors.SimpleButton()
        Me.SLETaxTagCOA = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.DETaxUntil = New DevExpress.XtraEditors.DateEdit()
        Me.XTPMonthlyReport = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCMonthlyReport = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPMBS = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.GCMAktiva = New DevExpress.XtraGrid.GridControl()
        Me.GVMAktiva = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BandedGridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumnPercentage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BandedGridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.GCMPasiva = New DevExpress.XtraGrid.GridControl()
        Me.GVMPasiva = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPMProfitLoss = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMProfitLoss = New DevExpress.XtraGrid.GridControl()
        Me.GVMProfitLoss = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn38 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn39 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn45 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn40 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn41 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn42 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn43 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn44 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnMISPercent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn46 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn47 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn48 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn49 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn50 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn51 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.XTPMBSvsMonth = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMBSvsPrevMonth = New DevExpress.XtraGrid.GridControl()
        Me.GVMBSvsPrevMonth = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn67 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn68 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn69 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn70 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn72 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn71 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPMPLvsMonth = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMPLvsPrevMonth = New DevExpress.XtraGrid.GridControl()
        Me.GVMPLvsPrevMonth = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn52 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn53 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn54 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn55 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn56 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand10 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn57 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn58 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn59 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn60 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn61 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn62 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn63 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn64 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn65 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn66 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.XTPMPLvsYear = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMPLvsPrevYear = New DevExpress.XtraGrid.GridControl()
        Me.GVMPLvsPrevYear = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand11 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn67 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn68 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn69 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn70 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn71 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBandPrevYear = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn72 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnVsYearPrev = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn73 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn76 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn77 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandThisYear = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn74 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnVsYearThisMonth = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand14 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn75 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn78 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn79 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn80 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn81 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.XTPMPLvsYTD = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMPLvsYTD = New DevExpress.XtraGrid.GridControl()
        Me.GVMPLvsYTD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand12 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn82 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn83 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn84 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn85 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn86 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand13 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn87 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn88 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn89 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn91 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand15 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn92 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn93 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand16 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn94 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn95 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn96 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn97 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn98 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.XTPMPBSvsPrevYear = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMBSvsPrevYear = New DevExpress.XtraGrid.GridControl()
        Me.GVMBSvsPrevYear = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand17 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn76 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn77 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn78 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn79 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn80 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn81 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn82 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand18 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn84 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn90 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand19 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn83 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn85 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.XTPSalesAchievement = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraScrollableControl2 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.GroupControl9 = New DevExpress.XtraEditors.GroupControl()
        Me.GCSalVsLastYear = New DevExpress.XtraGrid.GridControl()
        Me.GVSalVsLastYear = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand28 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn111 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn112 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand29 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn113 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn114 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GroupControl8 = New DevExpress.XtraEditors.GroupControl()
        Me.GCSalLastYear = New DevExpress.XtraGrid.GridControl()
        Me.GVSalLastYear = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand26 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn107 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn108 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand27 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn109 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn110 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GroupControl7 = New DevExpress.XtraEditors.GroupControl()
        Me.GCOverUnderTarget = New DevExpress.XtraGrid.GridControl()
        Me.GVOverUnderTarget = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand24 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn103 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn104 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand25 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn105 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn106 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.GCSalesRealization = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesRealization = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand22 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn99 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn100 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand23 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn101 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn102 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.GCMTargetUSA = New DevExpress.XtraGrid.GridControl()
        Me.GVMTargetUSA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand20 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn86 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn87 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand21 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn88 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn89 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PCFilterMonthly = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrintMonthlyReport = New DevExpress.XtraEditors.SimpleButton()
        Me.BViewMonthlyReport = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.DEMonthlyReport = New DevExpress.XtraEditors.DateEdit()
        CType(Me.PCFilterUpper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCFilterUpper.SuspendLayout()
        CType(Me.SLEUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLBalanceSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCBalanceSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCBalanceSheet.SuspendLayout()
        Me.XTPGeneralLedger.SuspendLayout()
        CType(Me.TLLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPBalanceSheet.SuspendLayout()
        CType(Me.XTCBS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCBS.SuspendLayout()
        Me.XTPBSLedger.SuspendLayout()
        Me.XTPBSReport.SuspendLayout()
        CType(Me.SplitterBS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitterBS.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCAktiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAktiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCPasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPProfitAndLoss.SuspendLayout()
        CType(Me.XTCProfitAndLoss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCProfitAndLoss.SuspendLayout()
        Me.XTPPATreeView.SuspendLayout()
        CType(Me.TLProfitAndLoss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPLReportView.SuspendLayout()
        CType(Me.GCProfitAndLoss, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProfitAndLoss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPajak.SuspendLayout()
        CType(Me.XTPTaxDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPTaxDetail.SuspendLayout()
        Me.XTPPendingLapor.SuspendLayout()
        CType(Me.GCTaxReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVTaxReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICETaxReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPendingTransaction.SuspendLayout()
        CType(Me.GCTaxPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVTaxPending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPLapor.SuspendLayout()
        CType(Me.GCActiveTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVActiveTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEActiveTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.CESelAllActiveTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCPajak, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCPajak.SuspendLayout()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.DETaxFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETaxFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLETaxCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLETaxTagCOA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETaxUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETaxUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMonthlyReport.SuspendLayout()
        CType(Me.XTCMonthlyReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCMonthlyReport.SuspendLayout()
        Me.XTPMBS.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GCMAktiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMAktiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.GCMPasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMPasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMProfitLoss.SuspendLayout()
        CType(Me.GCMProfitLoss, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMProfitLoss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMBSvsMonth.SuspendLayout()
        CType(Me.GCMBSvsPrevMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMBSvsPrevMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMPLvsMonth.SuspendLayout()
        CType(Me.GCMPLvsPrevMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMPLvsPrevMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMPLvsYear.SuspendLayout()
        CType(Me.GCMPLvsPrevYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMPLvsPrevYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMPLvsYTD.SuspendLayout()
        CType(Me.GCMPLvsYTD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMPLvsYTD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMPBSvsPrevYear.SuspendLayout()
        CType(Me.GCMBSvsPrevYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMBSvsPrevYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSalesAchievement.SuspendLayout()
        Me.XtraScrollableControl2.SuspendLayout()
        CType(Me.GroupControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl9.SuspendLayout()
        CType(Me.GCSalVsLastYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalVsLastYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl8.SuspendLayout()
        CType(Me.GCSalLastYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalLastYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl7.SuspendLayout()
        CType(Me.GCOverUnderTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOverUnderTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.GCSalesRealization, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesRealization, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.GCMTargetUSA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMTargetUSA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCFilterMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCFilterMonthly.SuspendLayout()
        CType(Me.DEMonthlyReport.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEMonthlyReport.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCFilterUpper
        '
        Me.PCFilterUpper.Controls.Add(Me.BPrint)
        Me.PCFilterUpper.Controls.Add(Me.SLEUnit)
        Me.PCFilterUpper.Controls.Add(Me.LabelControl2)
        Me.PCFilterUpper.Controls.Add(Me.BView)
        Me.PCFilterUpper.Controls.Add(Me.LabelControl1)
        Me.PCFilterUpper.Controls.Add(Me.DEUntil)
        Me.PCFilterUpper.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCFilterUpper.Location = New System.Drawing.Point(0, 0)
        Me.PCFilterUpper.Name = "PCFilterUpper"
        Me.PCFilterUpper.Size = New System.Drawing.Size(1021, 48)
        Me.PCFilterUpper.TabIndex = 0
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(500, 14)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(50, 23)
        Me.BPrint.TabIndex = 6
        Me.BPrint.Text = "print"
        '
        'SLEUnit
        '
        Me.SLEUnit.Location = New System.Drawing.Point(37, 16)
        Me.SLEUnit.Name = "SLEUnit"
        Me.SLEUnit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEUnit.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEUnit.Size = New System.Drawing.Size(193, 20)
        Me.SLEUnit.TabIndex = 5
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_coa_tag"
        Me.GridColumn1.FieldName = "id_comp"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Number"
        Me.GridColumn3.FieldName = "tag_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 281
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Unit"
        Me.GridColumn2.FieldName = "tag_description"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 1351
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 19)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Unit"
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(444, 14)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(50, 23)
        Me.BView.TabIndex = 3
        Me.BView.Text = "view"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(236, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Date"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(265, 16)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(173, 20)
        Me.DEUntil.TabIndex = 1
        '
        'TLBalanceSheet
        '
        Me.TLBalanceSheet.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand3, Me.treeListBand4})
        Me.TLBalanceSheet.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TCIDAcc, Me.TCIDAccParent, Me.TCLAccount, Me.TCLDescription, Me.TCLDebit, Me.TCLCredit, Me.TCAllChild, Me.TCLPrevMonth, Me.TCLThisMonth})
        Me.TLBalanceSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLBalanceSheet.Location = New System.Drawing.Point(0, 0)
        Me.TLBalanceSheet.Name = "TLBalanceSheet"
        Me.TLBalanceSheet.OptionsBehavior.EnableFiltering = True
        Me.TLBalanceSheet.OptionsBehavior.PopulateServiceColumns = True
        Me.TLBalanceSheet.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart
        Me.TLBalanceSheet.OptionsFilter.ShowAllValuesInFilterPopup = True
        Me.TLBalanceSheet.OptionsFind.AllowFindPanel = True
        Me.TLBalanceSheet.OptionsView.ShowBandsMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TLBalanceSheet.Size = New System.Drawing.Size(1009, 416)
        Me.TLBalanceSheet.TabIndex = 1
        '
        'treeListBand3
        '
        Me.treeListBand3.Caption = "Chart Of Account"
        Me.treeListBand3.Columns.Add(Me.TCLAccount)
        Me.treeListBand3.Columns.Add(Me.TCLDescription)
        Me.treeListBand3.Name = "treeListBand3"
        Me.treeListBand3.Width = 423
        '
        'TCLAccount
        '
        Me.TCLAccount.Caption = "Account"
        Me.TCLAccount.FieldName = "acc_name"
        Me.TCLAccount.Name = "TCLAccount"
        Me.TCLAccount.Visible = True
        Me.TCLAccount.VisibleIndex = 0
        Me.TCLAccount.Width = 212
        '
        'TCLDescription
        '
        Me.TCLDescription.Caption = "Description"
        Me.TCLDescription.FieldName = "acc_description"
        Me.TCLDescription.Name = "TCLDescription"
        Me.TCLDescription.Visible = True
        Me.TCLDescription.VisibleIndex = 1
        Me.TCLDescription.Width = 211
        '
        'treeListBand4
        '
        Me.treeListBand4.Caption = "Amount"
        Me.treeListBand4.Columns.Add(Me.TCLPrevMonth)
        Me.treeListBand4.Columns.Add(Me.TCLThisMonth)
        Me.treeListBand4.Name = "treeListBand4"
        Me.treeListBand4.Width = 453
        '
        'TCLPrevMonth
        '
        Me.TCLPrevMonth.Caption = "Previous Month"
        Me.TCLPrevMonth.FieldName = "prev_month"
        Me.TCLPrevMonth.Format.FormatString = "N2"
        Me.TCLPrevMonth.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLPrevMonth.Name = "TCLPrevMonth"
        Me.TCLPrevMonth.Visible = True
        Me.TCLPrevMonth.VisibleIndex = 2
        Me.TCLPrevMonth.Width = 227
        '
        'TCLThisMonth
        '
        Me.TCLThisMonth.Caption = "This Month"
        Me.TCLThisMonth.FieldName = "this_month"
        Me.TCLThisMonth.Format.FormatString = "N2"
        Me.TCLThisMonth.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLThisMonth.Name = "TCLThisMonth"
        Me.TCLThisMonth.Visible = True
        Me.TCLThisMonth.VisibleIndex = 3
        Me.TCLThisMonth.Width = 226
        '
        'TCIDAcc
        '
        Me.TCIDAcc.Caption = "ID"
        Me.TCIDAcc.FieldName = "id_acc"
        Me.TCIDAcc.Name = "TCIDAcc"
        '
        'TCIDAccParent
        '
        Me.TCIDAccParent.Caption = "ID Acc Parent"
        Me.TCIDAccParent.FieldName = "id_acc_parent"
        Me.TCIDAccParent.Name = "TCIDAccParent"
        '
        'TCLDebit
        '
        Me.TCLDebit.Caption = "Debit"
        Me.TCLDebit.FieldName = "debit"
        Me.TCLDebit.Name = "TCLDebit"
        '
        'TCLCredit
        '
        Me.TCLCredit.Caption = "Credit"
        Me.TCLCredit.FieldName = "credit"
        Me.TCLCredit.Name = "TCLCredit"
        '
        'TCAllChild
        '
        Me.TCAllChild.Caption = "ID All Child"
        Me.TCAllChild.FieldName = "id_all_child"
        Me.TCAllChild.Name = "TCAllChild"
        '
        'treeListBand1
        '
        Me.treeListBand1.Caption = "Account"
        Me.treeListBand1.Name = "treeListBand1"
        '
        'treeListBand2
        '
        Me.treeListBand2.Caption = "Amount"
        Me.treeListBand2.Name = "treeListBand2"
        '
        'XTCBalanceSheet
        '
        Me.XTCBalanceSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCBalanceSheet.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCBalanceSheet.Location = New System.Drawing.Point(0, 48)
        Me.XTCBalanceSheet.Name = "XTCBalanceSheet"
        Me.XTCBalanceSheet.SelectedTabPage = Me.XTPGeneralLedger
        Me.XTCBalanceSheet.Size = New System.Drawing.Size(1021, 472)
        Me.XTCBalanceSheet.TabIndex = 2
        Me.XTCBalanceSheet.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPGeneralLedger, Me.XTPBalanceSheet, Me.XTPProfitAndLoss, Me.XTPPajak, Me.XTPMonthlyReport})
        '
        'XTPGeneralLedger
        '
        Me.XTPGeneralLedger.Controls.Add(Me.TLLedger)
        Me.XTPGeneralLedger.Name = "XTPGeneralLedger"
        Me.XTPGeneralLedger.PageVisible = False
        Me.XTPGeneralLedger.Size = New System.Drawing.Size(1015, 444)
        Me.XTPGeneralLedger.Text = "Ledger"
        '
        'TLLedger
        '
        Me.TLLedger.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand5, Me.treeListBand6})
        Me.TLLedger.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TCLIDAcc, Me.TCLIdAccParent, Me.TCLAccName, Me.TCLAccDescription, Me.TCLedDebit, Me.TCLedCredit, Me.TCLedIDAllChild})
        Me.TLLedger.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLLedger.Location = New System.Drawing.Point(0, 0)
        Me.TLLedger.Name = "TLLedger"
        Me.TLLedger.OptionsBehavior.EnableFiltering = True
        Me.TLLedger.OptionsFind.AllowFindPanel = True
        Me.TLLedger.Size = New System.Drawing.Size(1015, 444)
        Me.TLLedger.TabIndex = 0
        '
        'treeListBand5
        '
        Me.treeListBand5.Caption = "Account"
        Me.treeListBand5.Columns.Add(Me.TCLAccName)
        Me.treeListBand5.Columns.Add(Me.TCLAccDescription)
        Me.treeListBand5.Name = "treeListBand5"
        Me.treeListBand5.Width = 427
        '
        'TCLAccName
        '
        Me.TCLAccName.Caption = "Account"
        Me.TCLAccName.FieldName = "acc_name"
        Me.TCLAccName.Name = "TCLAccName"
        Me.TCLAccName.Visible = True
        Me.TCLAccName.VisibleIndex = 0
        Me.TCLAccName.Width = 213
        '
        'TCLAccDescription
        '
        Me.TCLAccDescription.Caption = "Description"
        Me.TCLAccDescription.FieldName = "acc_description"
        Me.TCLAccDescription.Name = "TCLAccDescription"
        Me.TCLAccDescription.Visible = True
        Me.TCLAccDescription.VisibleIndex = 1
        Me.TCLAccDescription.Width = 214
        '
        'treeListBand6
        '
        Me.treeListBand6.Caption = "Amount"
        Me.treeListBand6.Columns.Add(Me.TCLedDebit)
        Me.treeListBand6.Columns.Add(Me.TCLedCredit)
        Me.treeListBand6.Name = "treeListBand6"
        Me.treeListBand6.Width = 449
        '
        'TCLedDebit
        '
        Me.TCLedDebit.Caption = "Debit"
        Me.TCLedDebit.FieldName = "debit"
        Me.TCLedDebit.Format.FormatString = "N2"
        Me.TCLedDebit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLedDebit.Name = "TCLedDebit"
        Me.TCLedDebit.Visible = True
        Me.TCLedDebit.VisibleIndex = 2
        Me.TCLedDebit.Width = 226
        '
        'TCLedCredit
        '
        Me.TCLedCredit.Caption = "Credit"
        Me.TCLedCredit.FieldName = "credit"
        Me.TCLedCredit.Format.FormatString = "N2"
        Me.TCLedCredit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCLedCredit.Name = "TCLedCredit"
        Me.TCLedCredit.Visible = True
        Me.TCLedCredit.VisibleIndex = 3
        Me.TCLedCredit.Width = 223
        '
        'TCLIDAcc
        '
        Me.TCLIDAcc.Caption = "ID Acc"
        Me.TCLIDAcc.FieldName = "id_acc"
        Me.TCLIDAcc.Name = "TCLIDAcc"
        '
        'TCLIdAccParent
        '
        Me.TCLIdAccParent.Caption = "ID Acc Parent"
        Me.TCLIdAccParent.FieldName = "id_acc_parent"
        Me.TCLIdAccParent.Name = "TCLIdAccParent"
        '
        'TCLedIDAllChild
        '
        Me.TCLedIDAllChild.Caption = "ID All Child"
        Me.TCLedIDAllChild.FieldName = "id_all_child"
        Me.TCLedIDAllChild.Name = "TCLedIDAllChild"
        '
        'XTPBalanceSheet
        '
        Me.XTPBalanceSheet.Controls.Add(Me.XTCBS)
        Me.XTPBalanceSheet.Name = "XTPBalanceSheet"
        Me.XTPBalanceSheet.Size = New System.Drawing.Size(1015, 444)
        Me.XTPBalanceSheet.Text = "Balance Sheet"
        '
        'XTCBS
        '
        Me.XTCBS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCBS.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCBS.Location = New System.Drawing.Point(0, 0)
        Me.XTCBS.Name = "XTCBS"
        Me.XTCBS.SelectedTabPage = Me.XTPBSLedger
        Me.XTCBS.Size = New System.Drawing.Size(1015, 444)
        Me.XTCBS.TabIndex = 2
        Me.XTCBS.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBSLedger, Me.XTPBSReport})
        '
        'XTPBSLedger
        '
        Me.XTPBSLedger.Controls.Add(Me.TLBalanceSheet)
        Me.XTPBSLedger.Name = "XTPBSLedger"
        Me.XTPBSLedger.PageVisible = False
        Me.XTPBSLedger.Size = New System.Drawing.Size(1009, 416)
        Me.XTPBSLedger.Text = "Tree View"
        '
        'XTPBSReport
        '
        Me.XTPBSReport.Controls.Add(Me.SplitterBS)
        Me.XTPBSReport.Name = "XTPBSReport"
        Me.XTPBSReport.Size = New System.Drawing.Size(1009, 416)
        Me.XTPBSReport.Text = "Report View"
        '
        'SplitterBS
        '
        Me.SplitterBS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitterBS.Location = New System.Drawing.Point(0, 0)
        Me.SplitterBS.Name = "SplitterBS"
        Me.SplitterBS.Panel1.Controls.Add(Me.GroupControl1)
        Me.SplitterBS.Panel1.Text = "Panel1"
        Me.SplitterBS.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitterBS.Panel2.Text = "Panel2"
        Me.SplitterBS.Size = New System.Drawing.Size(1009, 416)
        Me.SplitterBS.SplitterPosition = 521
        Me.SplitterBS.TabIndex = 0
        Me.SplitterBS.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCAktiva)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(521, 416)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Asset"
        '
        'GCAktiva
        '
        Me.GCAktiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAktiva.Location = New System.Drawing.Point(2, 20)
        Me.GCAktiva.MainView = Me.GVAktiva
        Me.GCAktiva.Name = "GCAktiva"
        Me.GCAktiva.Size = New System.Drawing.Size(517, 394)
        Me.GCAktiva.TabIndex = 0
        Me.GCAktiva.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAktiva})
        '
        'GVAktiva
        '
        Me.GVAktiva.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand3})
        Me.GVAktiva.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn12, Me.BandedGridColumn11, Me.BandedGridColumn14, Me.BandedGridColumn13, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumnThisMonth, Me.BandedGridColumnPrevMonth})
        Me.GVAktiva.GridControl = Me.GCAktiva
        Me.GVAktiva.GroupCount = 2
        Me.GVAktiva.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumnThisMonth, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.BandedGridColumnPrevMonth, "{0:N2}")})
        Me.GVAktiva.Name = "GVAktiva"
        Me.GVAktiva.OptionsView.ShowFooter = True
        Me.GVAktiva.OptionsView.ShowGroupPanel = False
        Me.GVAktiva.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn11, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn13, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Account"
        Me.GridBand1.Columns.Add(Me.BandedGridColumn11)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn13)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 150
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.Caption = "Head"
        Me.BandedGridColumn11.FieldName = "head_desc"
        Me.BandedGridColumn11.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.Caption = "Sub"
        Me.BandedGridColumn13.FieldName = "sub_desc"
        Me.BandedGridColumn13.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "No"
        Me.BandedGridColumn2.FieldName = "acc_name"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Name"
        Me.BandedGridColumn3.FieldName = "acc_description"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Amount"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPrevMonth)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnThisMonth)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 1
        Me.gridBand3.Width = 150
        '
        'BandedGridColumnPrevMonth
        '
        Me.BandedGridColumnPrevMonth.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPrevMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPrevMonth.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPrevMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPrevMonth.Caption = "Prev Month"
        Me.BandedGridColumnPrevMonth.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnPrevMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPrevMonth.FieldName = "prev_month"
        Me.BandedGridColumnPrevMonth.Name = "BandedGridColumnPrevMonth"
        Me.BandedGridColumnPrevMonth.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        Me.BandedGridColumnPrevMonth.Visible = True
        '
        'BandedGridColumnThisMonth
        '
        Me.BandedGridColumnThisMonth.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnThisMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnThisMonth.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnThisMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnThisMonth.Caption = "This Month"
        Me.BandedGridColumnThisMonth.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnThisMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnThisMonth.FieldName = "this_month"
        Me.BandedGridColumnThisMonth.Name = "BandedGridColumnThisMonth"
        Me.BandedGridColumnThisMonth.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumnThisMonth.Visible = True
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.Caption = "Head Name"
        Me.BandedGridColumn12.FieldName = "head_name"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        Me.BandedGridColumn12.Visible = True
        '
        'BandedGridColumn14
        '
        Me.BandedGridColumn14.Caption = "Sub Name"
        Me.BandedGridColumn14.FieldName = "sub_name"
        Me.BandedGridColumn14.Name = "BandedGridColumn14"
        Me.BandedGridColumn14.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "ID Acc"
        Me.BandedGridColumn1.FieldName = "id_acc"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCPasiva)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(483, 416)
        Me.GroupControl2.TabIndex = 2
        Me.GroupControl2.Text = "Liability And Equity"
        '
        'GCPasiva
        '
        Me.GCPasiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPasiva.Location = New System.Drawing.Point(2, 20)
        Me.GCPasiva.MainView = Me.GVPasiva
        Me.GCPasiva.Name = "GCPasiva"
        Me.GCPasiva.Size = New System.Drawing.Size(479, 394)
        Me.GCPasiva.TabIndex = 1
        Me.GCPasiva.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPasiva})
        '
        'GVPasiva
        '
        Me.GVPasiva.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2, Me.GridBand4})
        Me.GVPasiva.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn16, Me.BandedGridColumn6, Me.BandedGridColumn17, Me.BandedGridColumn7, Me.BandedGridColumn18, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn15, Me.BandedGridColumn10})
        Me.GVPasiva.GridControl = Me.GCPasiva
        Me.GVPasiva.GroupCount = 2
        Me.GVPasiva.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumn15, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.BandedGridColumn10, "{0:N2}")})
        Me.GVPasiva.Name = "GVPasiva"
        Me.GVPasiva.OptionsView.ShowFooter = True
        Me.GVPasiva.OptionsView.ShowGroupPanel = False
        Me.GVPasiva.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn6, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn7, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand2
        '
        Me.GridBand2.Caption = "Account"
        Me.GridBand2.Columns.Add(Me.BandedGridColumn6)
        Me.GridBand2.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand2.Columns.Add(Me.BandedGridColumn8)
        Me.GridBand2.Columns.Add(Me.BandedGridColumn9)
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        Me.GridBand2.Width = 150
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Head"
        Me.BandedGridColumn6.FieldName = "head_desc"
        Me.BandedGridColumn6.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "Sub"
        Me.BandedGridColumn7.FieldName = "sub_desc"
        Me.BandedGridColumn7.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "No"
        Me.BandedGridColumn8.FieldName = "acc_name"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Visible = True
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "Name"
        Me.BandedGridColumn9.FieldName = "acc_description"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.Visible = True
        '
        'GridBand4
        '
        Me.GridBand4.Caption = "Amount"
        Me.GridBand4.Columns.Add(Me.BandedGridColumn10)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn15)
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.VisibleIndex = 1
        Me.GridBand4.Width = 150
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn10.Caption = "Prev Month"
        Me.BandedGridColumn10.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn10.FieldName = "prev_month"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        Me.BandedGridColumn10.Visible = True
        '
        'BandedGridColumn15
        '
        Me.BandedGridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn15.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn15.Caption = "This Month"
        Me.BandedGridColumn15.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn15.FieldName = "this_month"
        Me.BandedGridColumn15.Name = "BandedGridColumn15"
        Me.BandedGridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumn15.Visible = True
        '
        'BandedGridColumn16
        '
        Me.BandedGridColumn16.Caption = "Head Name"
        Me.BandedGridColumn16.FieldName = "head_name"
        Me.BandedGridColumn16.Name = "BandedGridColumn16"
        Me.BandedGridColumn16.Visible = True
        '
        'BandedGridColumn17
        '
        Me.BandedGridColumn17.Caption = "Sub Name"
        Me.BandedGridColumn17.FieldName = "sub_name"
        Me.BandedGridColumn17.Name = "BandedGridColumn17"
        Me.BandedGridColumn17.Visible = True
        '
        'BandedGridColumn18
        '
        Me.BandedGridColumn18.Caption = "ID Acc"
        Me.BandedGridColumn18.FieldName = "id_acc"
        Me.BandedGridColumn18.Name = "BandedGridColumn18"
        '
        'XTPProfitAndLoss
        '
        Me.XTPProfitAndLoss.Controls.Add(Me.XTCProfitAndLoss)
        Me.XTPProfitAndLoss.Name = "XTPProfitAndLoss"
        Me.XTPProfitAndLoss.Size = New System.Drawing.Size(1015, 444)
        Me.XTPProfitAndLoss.Text = "Profit And Loss"
        '
        'XTCProfitAndLoss
        '
        Me.XTCProfitAndLoss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCProfitAndLoss.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCProfitAndLoss.Location = New System.Drawing.Point(0, 0)
        Me.XTCProfitAndLoss.Name = "XTCProfitAndLoss"
        Me.XTCProfitAndLoss.SelectedTabPage = Me.XTPPATreeView
        Me.XTCProfitAndLoss.Size = New System.Drawing.Size(1015, 444)
        Me.XTCProfitAndLoss.TabIndex = 0
        Me.XTCProfitAndLoss.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPATreeView, Me.XTPPLReportView})
        '
        'XTPPATreeView
        '
        Me.XTPPATreeView.Controls.Add(Me.TLProfitAndLoss)
        Me.XTPPATreeView.Name = "XTPPATreeView"
        Me.XTPPATreeView.PageVisible = False
        Me.XTPPATreeView.Size = New System.Drawing.Size(1009, 416)
        Me.XTPPATreeView.Text = "Tree View"
        '
        'TLProfitAndLoss
        '
        Me.TLProfitAndLoss.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand7, Me.treeListBand8})
        Me.TLProfitAndLoss.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TCPLIdAcc, Me.TCPLIdAccParent, Me.TCPLAccount, Me.TCPLDescription, Me.TCPLDebit, Me.TCPLCredit, Me.TCPLIdAllChild, Me.TCPLPrevMonth, Me.TCPLThisMonth})
        Me.TLProfitAndLoss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLProfitAndLoss.Location = New System.Drawing.Point(0, 0)
        Me.TLProfitAndLoss.Name = "TLProfitAndLoss"
        Me.TLProfitAndLoss.Size = New System.Drawing.Size(1009, 416)
        Me.TLProfitAndLoss.TabIndex = 0
        '
        'treeListBand7
        '
        Me.treeListBand7.Caption = "Account"
        Me.treeListBand7.Columns.Add(Me.TCPLAccount)
        Me.treeListBand7.Columns.Add(Me.TCPLDescription)
        Me.treeListBand7.Name = "treeListBand7"
        '
        'TCPLAccount
        '
        Me.TCPLAccount.Caption = "Account"
        Me.TCPLAccount.FieldName = "coa_name"
        Me.TCPLAccount.Name = "TCPLAccount"
        Me.TCPLAccount.Visible = True
        Me.TCPLAccount.VisibleIndex = 0
        '
        'TCPLDescription
        '
        Me.TCPLDescription.Caption = "Description"
        Me.TCPLDescription.FieldName = "coa_description"
        Me.TCPLDescription.Name = "TCPLDescription"
        Me.TCPLDescription.Visible = True
        Me.TCPLDescription.VisibleIndex = 1
        '
        'treeListBand8
        '
        Me.treeListBand8.Caption = "Amount"
        Me.treeListBand8.Columns.Add(Me.TCPLPrevMonth)
        Me.treeListBand8.Columns.Add(Me.TCPLThisMonth)
        Me.treeListBand8.Name = "treeListBand8"
        '
        'TCPLPrevMonth
        '
        Me.TCPLPrevMonth.Caption = "Previous Month"
        Me.TCPLPrevMonth.FieldName = "prev_month"
        Me.TCPLPrevMonth.Format.FormatString = "N2"
        Me.TCPLPrevMonth.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCPLPrevMonth.Name = "TCPLPrevMonth"
        Me.TCPLPrevMonth.Visible = True
        Me.TCPLPrevMonth.VisibleIndex = 2
        '
        'TCPLThisMonth
        '
        Me.TCPLThisMonth.Caption = "This Month"
        Me.TCPLThisMonth.FieldName = "this_month"
        Me.TCPLThisMonth.Format.FormatString = "N2"
        Me.TCPLThisMonth.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TCPLThisMonth.Name = "TCPLThisMonth"
        Me.TCPLThisMonth.Visible = True
        Me.TCPLThisMonth.VisibleIndex = 3
        '
        'TCPLIdAcc
        '
        Me.TCPLIdAcc.Caption = "ID Acc"
        Me.TCPLIdAcc.FieldName = "id_acc"
        Me.TCPLIdAcc.Name = "TCPLIdAcc"
        Me.TCPLIdAcc.Visible = True
        Me.TCPLIdAcc.VisibleIndex = 0
        '
        'TCPLIdAccParent
        '
        Me.TCPLIdAccParent.Caption = "ID Acc Parent"
        Me.TCPLIdAccParent.FieldName = "id_acc_parent"
        Me.TCPLIdAccParent.Name = "TCPLIdAccParent"
        Me.TCPLIdAccParent.Visible = True
        Me.TCPLIdAccParent.VisibleIndex = 1
        '
        'TCPLDebit
        '
        Me.TCPLDebit.Caption = "Debit"
        Me.TCPLDebit.FieldName = "debit"
        Me.TCPLDebit.Name = "TCPLDebit"
        Me.TCPLDebit.Visible = True
        Me.TCPLDebit.VisibleIndex = 7
        '
        'TCPLCredit
        '
        Me.TCPLCredit.Caption = "Credit"
        Me.TCPLCredit.FieldName = "credit"
        Me.TCPLCredit.Name = "TCPLCredit"
        Me.TCPLCredit.Visible = True
        Me.TCPLCredit.VisibleIndex = 8
        '
        'TCPLIdAllChild
        '
        Me.TCPLIdAllChild.Caption = "ID All Child"
        Me.TCPLIdAllChild.FieldName = "id_all_child"
        Me.TCPLIdAllChild.Name = "TCPLIdAllChild"
        Me.TCPLIdAllChild.Visible = True
        Me.TCPLIdAllChild.VisibleIndex = 6
        '
        'XTPPLReportView
        '
        Me.XTPPLReportView.Controls.Add(Me.GCProfitAndLoss)
        Me.XTPPLReportView.Name = "XTPPLReportView"
        Me.XTPPLReportView.Size = New System.Drawing.Size(1009, 416)
        Me.XTPPLReportView.Text = "Report View"
        '
        'GCProfitAndLoss
        '
        Me.GCProfitAndLoss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProfitAndLoss.Location = New System.Drawing.Point(0, 0)
        Me.GCProfitAndLoss.MainView = Me.GVProfitAndLoss
        Me.GCProfitAndLoss.Name = "GCProfitAndLoss"
        Me.GCProfitAndLoss.Size = New System.Drawing.Size(1009, 416)
        Me.GCProfitAndLoss.TabIndex = 1
        Me.GCProfitAndLoss.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProfitAndLoss})
        '
        'GVProfitAndLoss
        '
        Me.GVProfitAndLoss.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand5, Me.GridBand6})
        Me.GVProfitAndLoss.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn23, Me.BandedGridColumn4, Me.BandedGridColumn24, Me.BandedGridColumn5, Me.BandedGridColumn25, Me.BandedGridColumn19, Me.BandedGridColumn20, Me.BandedGridColumn22, Me.BandedGridColumn21, Me.BandedGridColumnYTD, Me.BandedGridColumn27, Me.BandedGridColumn28, Me.BandedGridColumn29})
        Me.GVProfitAndLoss.GridControl = Me.GCProfitAndLoss
        Me.GVProfitAndLoss.GroupCount = 2
        Me.GVProfitAndLoss.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumn22, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.BandedGridColumn21, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", Me.BandedGridColumnYTD, "{0:N2}")})
        Me.GVProfitAndLoss.Name = "GVProfitAndLoss"
        Me.GVProfitAndLoss.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVProfitAndLoss.OptionsView.ShowFooter = True
        Me.GVProfitAndLoss.OptionsView.ShowGroupPanel = False
        Me.GVProfitAndLoss.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn4, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn5, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand5
        '
        Me.GridBand5.Caption = "Account"
        Me.GridBand5.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand5.Columns.Add(Me.BandedGridColumn5)
        Me.GridBand5.Columns.Add(Me.BandedGridColumn19)
        Me.GridBand5.Columns.Add(Me.BandedGridColumn20)
        Me.GridBand5.Name = "GridBand5"
        Me.GridBand5.VisibleIndex = 0
        Me.GridBand5.Width = 150
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Head"
        Me.BandedGridColumn4.FieldName = "head_desc"
        Me.BandedGridColumn4.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Sub"
        Me.BandedGridColumn5.FieldName = "sub_desc"
        Me.BandedGridColumn5.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        '
        'BandedGridColumn19
        '
        Me.BandedGridColumn19.Caption = "No"
        Me.BandedGridColumn19.FieldName = "acc_name"
        Me.BandedGridColumn19.Name = "BandedGridColumn19"
        Me.BandedGridColumn19.Visible = True
        '
        'BandedGridColumn20
        '
        Me.BandedGridColumn20.Caption = "Name"
        Me.BandedGridColumn20.FieldName = "acc_description"
        Me.BandedGridColumn20.Name = "BandedGridColumn20"
        Me.BandedGridColumn20.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "acc_description", "Net Profit ")})
        Me.BandedGridColumn20.Visible = True
        '
        'GridBand6
        '
        Me.GridBand6.Caption = "Amount"
        Me.GridBand6.Columns.Add(Me.BandedGridColumn21)
        Me.GridBand6.Columns.Add(Me.BandedGridColumn28)
        Me.GridBand6.Columns.Add(Me.BandedGridColumn22)
        Me.GridBand6.Columns.Add(Me.BandedGridColumn27)
        Me.GridBand6.Columns.Add(Me.BandedGridColumnYTD)
        Me.GridBand6.Columns.Add(Me.BandedGridColumn29)
        Me.GridBand6.Name = "GridBand6"
        Me.GridBand6.VisibleIndex = 1
        Me.GridBand6.Width = 450
        '
        'BandedGridColumn21
        '
        Me.BandedGridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn21.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn21.Caption = "Prev Month"
        Me.BandedGridColumn21.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn21.FieldName = "prev_month"
        Me.BandedGridColumn21.Name = "BandedGridColumn21"
        Me.BandedGridColumn21.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        Me.BandedGridColumn21.Visible = True
        '
        'BandedGridColumn28
        '
        Me.BandedGridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn28.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn28.Caption = "%"
        Me.BandedGridColumn28.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn28.FieldName = "percent_prev_month"
        Me.BandedGridColumn28.Name = "BandedGridColumn28"
        Me.BandedGridColumn28.Visible = True
        '
        'BandedGridColumn22
        '
        Me.BandedGridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn22.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn22.Caption = "This Month"
        Me.BandedGridColumn22.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn22.FieldName = "this_month"
        Me.BandedGridColumn22.Name = "BandedGridColumn22"
        Me.BandedGridColumn22.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumn22.Visible = True
        '
        'BandedGridColumn27
        '
        Me.BandedGridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn27.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn27.Caption = "%"
        Me.BandedGridColumn27.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn27.FieldName = "percent_this_month"
        Me.BandedGridColumn27.Name = "BandedGridColumn27"
        Me.BandedGridColumn27.Visible = True
        '
        'BandedGridColumnYTD
        '
        Me.BandedGridColumnYTD.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnYTD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnYTD.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnYTD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnYTD.Caption = "Year to Date"
        Me.BandedGridColumnYTD.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnYTD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnYTD.FieldName = "this_year_to_date"
        Me.BandedGridColumnYTD.Name = "BandedGridColumnYTD"
        Me.BandedGridColumnYTD.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", "{0:N2}")})
        Me.BandedGridColumnYTD.Visible = True
        '
        'BandedGridColumn29
        '
        Me.BandedGridColumn29.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn29.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn29.Caption = "%"
        Me.BandedGridColumn29.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn29.FieldName = "percent_this_year_to_date"
        Me.BandedGridColumn29.Name = "BandedGridColumn29"
        Me.BandedGridColumn29.Visible = True
        '
        'BandedGridColumn23
        '
        Me.BandedGridColumn23.Caption = "Head Name"
        Me.BandedGridColumn23.FieldName = "head_name"
        Me.BandedGridColumn23.Name = "BandedGridColumn23"
        Me.BandedGridColumn23.Visible = True
        '
        'BandedGridColumn24
        '
        Me.BandedGridColumn24.Caption = "Sub Name"
        Me.BandedGridColumn24.FieldName = "sub_name"
        Me.BandedGridColumn24.Name = "BandedGridColumn24"
        Me.BandedGridColumn24.Visible = True
        '
        'BandedGridColumn25
        '
        Me.BandedGridColumn25.Caption = "ID Acc"
        Me.BandedGridColumn25.FieldName = "id_acc"
        Me.BandedGridColumn25.Name = "BandedGridColumn25"
        '
        'XTPPajak
        '
        Me.XTPPajak.Controls.Add(Me.XTPTaxDetail)
        Me.XTPPajak.Controls.Add(Me.PCPajak)
        Me.XTPPajak.Name = "XTPPajak"
        Me.XTPPajak.Size = New System.Drawing.Size(1015, 444)
        Me.XTPPajak.Text = "Tax Report"
        '
        'XTPTaxDetail
        '
        Me.XTPTaxDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTPTaxDetail.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTPTaxDetail.Location = New System.Drawing.Point(0, 78)
        Me.XTPTaxDetail.Name = "XTPTaxDetail"
        Me.XTPTaxDetail.SelectedTabPage = Me.XTPPendingLapor
        Me.XTPTaxDetail.Size = New System.Drawing.Size(1015, 366)
        Me.XTPTaxDetail.TabIndex = 3
        Me.XTPTaxDetail.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPendingLapor, Me.XTPPendingTransaction, Me.XTPLapor})
        '
        'XTPPendingLapor
        '
        Me.XTPPendingLapor.Controls.Add(Me.GCTaxReport)
        Me.XTPPendingLapor.Controls.Add(Me.PanelControl1)
        Me.XTPPendingLapor.Name = "XTPPendingLapor"
        Me.XTPPendingLapor.Size = New System.Drawing.Size(1009, 338)
        Me.XTPPendingLapor.Text = "Pending Lapor"
        '
        'GCTaxReport
        '
        Me.GCTaxReport.ContextMenuStrip = Me.ViewMenu
        Me.GCTaxReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTaxReport.Location = New System.Drawing.Point(0, 0)
        Me.GCTaxReport.MainView = Me.GVTaxReport
        Me.GCTaxReport.Name = "GCTaxReport"
        Me.GCTaxReport.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICETaxReport})
        Me.GCTaxReport.Size = New System.Drawing.Size(1009, 298)
        Me.GCTaxReport.TabIndex = 2
        Me.GCTaxReport.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTaxReport})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailToolStripMenuItem, Me.ViewJournalToolStripMenuItem})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(141, 48)
        '
        'ViewDetailToolStripMenuItem
        '
        Me.ViewDetailToolStripMenuItem.Name = "ViewDetailToolStripMenuItem"
        Me.ViewDetailToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ViewDetailToolStripMenuItem.Text = "View Report"
        '
        'ViewJournalToolStripMenuItem
        '
        Me.ViewJournalToolStripMenuItem.Name = "ViewJournalToolStripMenuItem"
        Me.ViewJournalToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ViewJournalToolStripMenuItem.Text = "View Journal"
        '
        'GVTaxReport
        '
        Me.GVTaxReport.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn52, Me.GridColumnTaxCat, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn24, Me.GridColumnDesc, Me.GridColumnVendorCode, Me.GridColumn23, Me.GridColumnPPNPPH, Me.GridColumnTarif, Me.GridColumnDPP, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumnAlamatNPWP, Me.GridColumn17, Me.GridColumn73})
        Me.GVTaxReport.GridControl = Me.GCTaxReport
        Me.GVTaxReport.GroupCount = 1
        Me.GVTaxReport.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", Me.GridColumnTarif, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", Me.GridColumnDPP, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "tax_report", Me.GridColumnDesc, "Total {0} :")})
        Me.GVTaxReport.LevelIndent = 0
        Me.GVTaxReport.Name = "GVTaxReport"
        Me.GVTaxReport.OptionsView.ColumnAutoWidth = False
        Me.GVTaxReport.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVTaxReport.OptionsView.ShowFooter = True
        Me.GVTaxReport.OptionsView.ShowGroupPanel = False
        Me.GVTaxReport.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnTaxCat, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn52
        '
        Me.GridColumn52.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn52.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn52.Caption = "*"
        Me.GridColumn52.ColumnEdit = Me.RICETaxReport
        Me.GridColumn52.FieldName = "is_check"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.Visible = True
        Me.GridColumn52.VisibleIndex = 0
        Me.GridColumn52.Width = 55
        '
        'RICETaxReport
        '
        Me.RICETaxReport.AutoHeight = False
        Me.RICETaxReport.Name = "RICETaxReport"
        Me.RICETaxReport.ValueChecked = "yes"
        Me.RICETaxReport.ValueUnchecked = "no"
        '
        'GridColumnTaxCat
        '
        Me.GridColumnTaxCat.Caption = "Tax Category"
        Me.GridColumnTaxCat.FieldName = "tax_report"
        Me.GridColumnTaxCat.FieldNameSortGroup = "sorting"
        Me.GridColumnTaxCat.MinWidth = 55
        Me.GridColumnTaxCat.Name = "GridColumnTaxCat"
        Me.GridColumnTaxCat.OptionsColumn.AllowEdit = False
        Me.GridColumnTaxCat.OptionsColumn.ReadOnly = True
        Me.GridColumnTaxCat.Visible = True
        Me.GridColumnTaxCat.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID"
        Me.GridColumn4.FieldName = "id_acc_trans_det"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Journal No."
        Me.GridColumn5.FieldName = "jurnal_no"
        Me.GridColumn5.MinWidth = 55
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 81
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Date Reff"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "date_reference"
        Me.GridColumn6.MinWidth = 70
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 80
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Reff"
        Me.GridColumn7.FieldName = "number"
        Me.GridColumn7.MinWidth = 60
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Inv Number"
        Me.GridColumn24.FieldName = "inv_number"
        Me.GridColumn24.MinWidth = 100
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.OptionsColumn.ReadOnly = True
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 4
        Me.GridColumn24.Width = 100
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Description"
        Me.GridColumnDesc.FieldName = "description"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.OptionsColumn.AllowEdit = False
        Me.GridColumnDesc.OptionsColumn.ReadOnly = True
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 5
        '
        'GridColumnVendorCode
        '
        Me.GridColumnVendorCode.Caption = "Vendor Code"
        Me.GridColumnVendorCode.FieldName = "comp_number"
        Me.GridColumnVendorCode.Name = "GridColumnVendorCode"
        Me.GridColumnVendorCode.OptionsColumn.AllowEdit = False
        Me.GridColumnVendorCode.OptionsColumn.ReadOnly = True
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Vendor"
        Me.GridColumn23.FieldName = "comp_name"
        Me.GridColumn23.MinWidth = 70
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.OptionsColumn.ReadOnly = True
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 6
        Me.GridColumn23.Width = 160
        '
        'GridColumnPPNPPH
        '
        Me.GridColumnPPNPPH.Caption = "(%)"
        Me.GridColumnPPNPPH.DisplayFormat.FormatString = "{0:N1} %"
        Me.GridColumnPPNPPH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPPNPPH.FieldName = "pph_percent"
        Me.GridColumnPPNPPH.MinWidth = 35
        Me.GridColumnPPNPPH.Name = "GridColumnPPNPPH"
        Me.GridColumnPPNPPH.OptionsColumn.AllowEdit = False
        Me.GridColumnPPNPPH.OptionsColumn.ReadOnly = True
        Me.GridColumnPPNPPH.Visible = True
        Me.GridColumnPPNPPH.VisibleIndex = 7
        '
        'GridColumnTarif
        '
        Me.GridColumnTarif.Caption = "Tarif"
        Me.GridColumnTarif.DisplayFormat.FormatString = "N2"
        Me.GridColumnTarif.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTarif.FieldName = "pph"
        Me.GridColumnTarif.MinWidth = 70
        Me.GridColumnTarif.Name = "GridColumnTarif"
        Me.GridColumnTarif.OptionsColumn.AllowEdit = False
        Me.GridColumnTarif.OptionsColumn.ReadOnly = True
        Me.GridColumnTarif.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", "{0:N2}")})
        Me.GridColumnTarif.Visible = True
        Me.GridColumnTarif.VisibleIndex = 8
        Me.GridColumnTarif.Width = 80
        '
        'GridColumnDPP
        '
        Me.GridColumnDPP.Caption = "DPP"
        Me.GridColumnDPP.DisplayFormat.FormatString = "N2"
        Me.GridColumnDPP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDPP.FieldName = "dpp"
        Me.GridColumnDPP.MinWidth = 70
        Me.GridColumnDPP.Name = "GridColumnDPP"
        Me.GridColumnDPP.OptionsColumn.AllowEdit = False
        Me.GridColumnDPP.OptionsColumn.ReadOnly = True
        Me.GridColumnDPP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", "{0:N2}")})
        Me.GridColumnDPP.Visible = True
        Me.GridColumnDPP.VisibleIndex = 9
        Me.GridColumnDPP.Width = 80
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "NPWP"
        Me.GridColumn13.FieldName = "npwp"
        Me.GridColumn13.MinWidth = 80
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 10
        Me.GridColumn13.Width = 80
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Kitas"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Nama di Identitas"
        Me.GridColumn15.FieldName = "npwp_name"
        Me.GridColumn15.MinWidth = 110
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 11
        Me.GridColumn15.Width = 140
        '
        'GridColumnAlamatNPWP
        '
        Me.GridColumnAlamatNPWP.Caption = "Alamat"
        Me.GridColumnAlamatNPWP.FieldName = "npwp_address"
        Me.GridColumnAlamatNPWP.Name = "GridColumnAlamatNPWP"
        Me.GridColumnAlamatNPWP.OptionsColumn.AllowEdit = False
        Me.GridColumnAlamatNPWP.OptionsColumn.ReadOnly = True
        Me.GridColumnAlamatNPWP.Visible = True
        Me.GridColumnAlamatNPWP.VisibleIndex = 12
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "No Bukti Potong"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        '
        'GridColumn73
        '
        Me.GridColumn73.Caption = "Order Cat"
        Me.GridColumn73.FieldName = "sorting"
        Me.GridColumn73.Name = "GridColumn73"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BReported)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 298)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1009, 40)
        Me.PanelControl1.TabIndex = 5
        '
        'BReported
        '
        Me.BReported.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BReported.Appearance.ForeColor = System.Drawing.Color.White
        Me.BReported.Appearance.Options.UseBackColor = True
        Me.BReported.Appearance.Options.UseForeColor = True
        Me.BReported.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BReported.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BReported.Location = New System.Drawing.Point(118, 2)
        Me.BReported.Name = "BReported"
        Me.BReported.Size = New System.Drawing.Size(889, 36)
        Me.BReported.TabIndex = 4
        Me.BReported.Text = "Rekap"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.CheckEditSelAll)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(116, 36)
        Me.PanelControl2.TabIndex = 0
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(8, 8)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All Item"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(109, 19)
        Me.CheckEditSelAll.TabIndex = 103
        '
        'XTPPendingTransaction
        '
        Me.XTPPendingTransaction.Controls.Add(Me.GCTaxPending)
        Me.XTPPendingTransaction.Name = "XTPPendingTransaction"
        Me.XTPPendingTransaction.Size = New System.Drawing.Size(1009, 338)
        Me.XTPPendingTransaction.Text = "Pending Tax Transaction"
        '
        'GCTaxPending
        '
        Me.GCTaxPending.ContextMenuStrip = Me.ViewMenu
        Me.GCTaxPending.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTaxPending.Location = New System.Drawing.Point(0, 0)
        Me.GCTaxPending.MainView = Me.GVTaxPending
        Me.GCTaxPending.Name = "GCTaxPending"
        Me.GCTaxPending.Size = New System.Drawing.Size(1009, 338)
        Me.GCTaxPending.TabIndex = 3
        Me.GCTaxPending.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTaxPending})
        '
        'GVTaxPending
        '
        Me.GVTaxPending.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9, Me.GridColumn11, Me.GridColumn12, Me.GridColumn16, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35, Me.GridColumn74})
        Me.GVTaxPending.GridControl = Me.GCTaxPending
        Me.GVTaxPending.GroupCount = 1
        Me.GVTaxPending.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", Me.GridColumn29, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", Me.GridColumn30, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "tax_report", Me.GridColumn25, "Total {0} :")})
        Me.GVTaxPending.LevelIndent = 0
        Me.GVTaxPending.Name = "GVTaxPending"
        Me.GVTaxPending.OptionsView.ColumnAutoWidth = False
        Me.GVTaxPending.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVTaxPending.OptionsView.ShowFooter = True
        Me.GVTaxPending.OptionsView.ShowGroupPanel = False
        Me.GVTaxPending.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn8, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Tax Category"
        Me.GridColumn8.FieldName = "tax_report"
        Me.GridColumn8.FieldNameSortGroup = "sorting"
        Me.GridColumn8.MinWidth = 55
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ID"
        Me.GridColumn9.FieldName = "id_acc_trans_det"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Date Reff"
        Me.GridColumn11.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn11.FieldName = "date_reference"
        Me.GridColumn11.MinWidth = 70
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 80
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Reff"
        Me.GridColumn12.FieldName = "number"
        Me.GridColumn12.MinWidth = 60
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Inv Number"
        Me.GridColumn16.FieldName = "inv_number"
        Me.GridColumn16.MinWidth = 100
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        Me.GridColumn16.Width = 100
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Description"
        Me.GridColumn25.FieldName = "description"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.OptionsColumn.ReadOnly = True
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 3
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Vendor Code"
        Me.GridColumn26.FieldName = "comp_number"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.AllowEdit = False
        Me.GridColumn26.OptionsColumn.ReadOnly = True
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Vendor"
        Me.GridColumn27.FieldName = "comp_name"
        Me.GridColumn27.MinWidth = 70
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.AllowEdit = False
        Me.GridColumn27.OptionsColumn.ReadOnly = True
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 4
        Me.GridColumn27.Width = 160
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "(%)"
        Me.GridColumn28.DisplayFormat.FormatString = "{0:N1} %"
        Me.GridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn28.FieldName = "pph_percent"
        Me.GridColumn28.MinWidth = 35
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.AllowEdit = False
        Me.GridColumn28.OptionsColumn.ReadOnly = True
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 5
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Tarif"
        Me.GridColumn29.DisplayFormat.FormatString = "N2"
        Me.GridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn29.FieldName = "pph"
        Me.GridColumn29.MinWidth = 70
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsColumn.AllowEdit = False
        Me.GridColumn29.OptionsColumn.ReadOnly = True
        Me.GridColumn29.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", "{0:N2}")})
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 6
        Me.GridColumn29.Width = 80
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "DPP"
        Me.GridColumn30.DisplayFormat.FormatString = "N2"
        Me.GridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn30.FieldName = "dpp"
        Me.GridColumn30.MinWidth = 70
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.AllowEdit = False
        Me.GridColumn30.OptionsColumn.ReadOnly = True
        Me.GridColumn30.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", "{0:N2}")})
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 7
        Me.GridColumn30.Width = 80
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "NPWP"
        Me.GridColumn31.FieldName = "npwp"
        Me.GridColumn31.MinWidth = 80
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.OptionsColumn.ReadOnly = True
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 8
        Me.GridColumn31.Width = 80
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Kitas"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.OptionsColumn.ReadOnly = True
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Nama di Identitas"
        Me.GridColumn33.FieldName = "npwp_name"
        Me.GridColumn33.MinWidth = 110
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.OptionsColumn.ReadOnly = True
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 9
        Me.GridColumn33.Width = 140
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Alamat"
        Me.GridColumn34.FieldName = "npwp_address"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        Me.GridColumn34.OptionsColumn.ReadOnly = True
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 10
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "No Bukti Potong"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.OptionsColumn.ReadOnly = True
        '
        'GridColumn74
        '
        Me.GridColumn74.Caption = "Order Cat"
        Me.GridColumn74.FieldName = "sorting"
        Me.GridColumn74.Name = "GridColumn74"
        '
        'XTPLapor
        '
        Me.XTPLapor.Controls.Add(Me.GCActiveTax)
        Me.XTPLapor.Controls.Add(Me.PanelControl3)
        Me.XTPLapor.Name = "XTPLapor"
        Me.XTPLapor.Size = New System.Drawing.Size(1009, 338)
        Me.XTPLapor.Text = "Rekap Tax"
        '
        'GCActiveTax
        '
        Me.GCActiveTax.ContextMenuStrip = Me.ViewMenu
        Me.GCActiveTax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCActiveTax.Location = New System.Drawing.Point(0, 0)
        Me.GCActiveTax.MainView = Me.GVActiveTax
        Me.GCActiveTax.Name = "GCActiveTax"
        Me.GCActiveTax.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEActiveTax})
        Me.GCActiveTax.Size = New System.Drawing.Size(1009, 298)
        Me.GCActiveTax.TabIndex = 3
        Me.GCActiveTax.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVActiveTax})
        '
        'GVActiveTax
        '
        Me.GVActiveTax.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumnActiveTaxCat, Me.GridColumn36, Me.GridColumn37, Me.GridColumn38, Me.GridColumn39, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn51, Me.GridColumn75})
        Me.GVActiveTax.GridControl = Me.GCActiveTax
        Me.GVActiveTax.GroupCount = 1
        Me.GVActiveTax.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", Me.GridColumn45, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", Me.GridColumn46, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Max, "tax_report", Me.GridColumn41, "Total {0} :")})
        Me.GVActiveTax.LevelIndent = 0
        Me.GVActiveTax.Name = "GVActiveTax"
        Me.GVActiveTax.OptionsView.ColumnAutoWidth = False
        Me.GVActiveTax.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVActiveTax.OptionsView.ShowFooter = True
        Me.GVActiveTax.OptionsView.ShowGroupPanel = False
        Me.GVActiveTax.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnActiveTaxCat, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn10.Caption = "*"
        Me.GridColumn10.ColumnEdit = Me.RICEActiveTax
        Me.GridColumn10.FieldName = "is_check"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'RICEActiveTax
        '
        Me.RICEActiveTax.AutoHeight = False
        Me.RICEActiveTax.Name = "RICEActiveTax"
        Me.RICEActiveTax.ValueChecked = "yes"
        Me.RICEActiveTax.ValueUnchecked = "no"
        '
        'GridColumnActiveTaxCat
        '
        Me.GridColumnActiveTaxCat.Caption = "Tax Category"
        Me.GridColumnActiveTaxCat.FieldName = "tax_report"
        Me.GridColumnActiveTaxCat.FieldNameSortGroup = "sorting"
        Me.GridColumnActiveTaxCat.MinWidth = 55
        Me.GridColumnActiveTaxCat.Name = "GridColumnActiveTaxCat"
        Me.GridColumnActiveTaxCat.OptionsColumn.AllowEdit = False
        Me.GridColumnActiveTaxCat.OptionsColumn.ReadOnly = True
        Me.GridColumnActiveTaxCat.Visible = True
        Me.GridColumnActiveTaxCat.VisibleIndex = 0
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "ID"
        Me.GridColumn36.FieldName = "id_acc_trans_det"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsColumn.AllowEdit = False
        Me.GridColumn36.OptionsColumn.ReadOnly = True
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Journal No."
        Me.GridColumn37.FieldName = "jurnal_no"
        Me.GridColumn37.MinWidth = 55
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.OptionsColumn.AllowEdit = False
        Me.GridColumn37.OptionsColumn.ReadOnly = True
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 1
        Me.GridColumn37.Width = 81
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "Date Reff"
        Me.GridColumn38.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn38.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn38.FieldName = "date_reference"
        Me.GridColumn38.MinWidth = 70
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.OptionsColumn.AllowEdit = False
        Me.GridColumn38.OptionsColumn.ReadOnly = True
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 2
        Me.GridColumn38.Width = 80
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Reff"
        Me.GridColumn39.FieldName = "number"
        Me.GridColumn39.MinWidth = 60
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.OptionsColumn.AllowEdit = False
        Me.GridColumn39.OptionsColumn.ReadOnly = True
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 3
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Inv Number"
        Me.GridColumn40.FieldName = "inv_number"
        Me.GridColumn40.MinWidth = 100
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.OptionsColumn.AllowEdit = False
        Me.GridColumn40.OptionsColumn.ReadOnly = True
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 4
        Me.GridColumn40.Width = 100
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Description"
        Me.GridColumn41.FieldName = "description"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.OptionsColumn.AllowEdit = False
        Me.GridColumn41.OptionsColumn.ReadOnly = True
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 5
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Vendor Code"
        Me.GridColumn42.FieldName = "comp_number"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.OptionsColumn.AllowEdit = False
        Me.GridColumn42.OptionsColumn.ReadOnly = True
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Vendor"
        Me.GridColumn43.FieldName = "comp_name"
        Me.GridColumn43.MinWidth = 70
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.OptionsColumn.AllowEdit = False
        Me.GridColumn43.OptionsColumn.ReadOnly = True
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 6
        Me.GridColumn43.Width = 160
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "(%)"
        Me.GridColumn44.DisplayFormat.FormatString = "{0:N1} %"
        Me.GridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn44.FieldName = "pph_percent"
        Me.GridColumn44.MinWidth = 35
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsColumn.AllowEdit = False
        Me.GridColumn44.OptionsColumn.ReadOnly = True
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 7
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Tarif"
        Me.GridColumn45.DisplayFormat.FormatString = "N0"
        Me.GridColumn45.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn45.FieldName = "pph"
        Me.GridColumn45.MinWidth = 70
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsColumn.AllowEdit = False
        Me.GridColumn45.OptionsColumn.ReadOnly = True
        Me.GridColumn45.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph", "{0:N2}")})
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 8
        Me.GridColumn45.Width = 80
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "DPP"
        Me.GridColumn46.DisplayFormat.FormatString = "N0"
        Me.GridColumn46.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn46.FieldName = "dpp"
        Me.GridColumn46.MinWidth = 70
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.OptionsColumn.AllowEdit = False
        Me.GridColumn46.OptionsColumn.ReadOnly = True
        Me.GridColumn46.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dpp", "{0:N2}")})
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 9
        Me.GridColumn46.Width = 80
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "NPWP"
        Me.GridColumn47.FieldName = "npwp"
        Me.GridColumn47.MinWidth = 80
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.OptionsColumn.AllowEdit = False
        Me.GridColumn47.OptionsColumn.ReadOnly = True
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 10
        Me.GridColumn47.Width = 80
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "Kitas"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.OptionsColumn.AllowEdit = False
        Me.GridColumn48.OptionsColumn.ReadOnly = True
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "Nama di Identitas"
        Me.GridColumn49.FieldName = "npwp_name"
        Me.GridColumn49.MinWidth = 110
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.OptionsColumn.AllowEdit = False
        Me.GridColumn49.OptionsColumn.ReadOnly = True
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 11
        Me.GridColumn49.Width = 140
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "Alamat"
        Me.GridColumn50.FieldName = "npwp_address"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.OptionsColumn.AllowEdit = False
        Me.GridColumn50.OptionsColumn.ReadOnly = True
        Me.GridColumn50.Visible = True
        Me.GridColumn50.VisibleIndex = 12
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "No Bukti Potong"
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.OptionsColumn.AllowEdit = False
        Me.GridColumn51.OptionsColumn.ReadOnly = True
        '
        'GridColumn75
        '
        Me.GridColumn75.Caption = "Order Cat"
        Me.GridColumn75.FieldName = "sorting"
        Me.GridColumn75.Name = "GridColumn75"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BMoveActiveTax)
        Me.PanelControl3.Controls.Add(Me.PanelControl4)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 298)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1009, 40)
        Me.PanelControl3.TabIndex = 6
        '
        'BMoveActiveTax
        '
        Me.BMoveActiveTax.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BMoveActiveTax.Appearance.ForeColor = System.Drawing.Color.White
        Me.BMoveActiveTax.Appearance.Options.UseBackColor = True
        Me.BMoveActiveTax.Appearance.Options.UseForeColor = True
        Me.BMoveActiveTax.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BMoveActiveTax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BMoveActiveTax.Location = New System.Drawing.Point(118, 2)
        Me.BMoveActiveTax.Name = "BMoveActiveTax"
        Me.BMoveActiveTax.Size = New System.Drawing.Size(889, 36)
        Me.BMoveActiveTax.TabIndex = 4
        Me.BMoveActiveTax.Text = "Move"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.CESelAllActiveTax)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl4.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(116, 36)
        Me.PanelControl4.TabIndex = 0
        '
        'CESelAllActiveTax
        '
        Me.CESelAllActiveTax.Location = New System.Drawing.Point(8, 8)
        Me.CESelAllActiveTax.Name = "CESelAllActiveTax"
        Me.CESelAllActiveTax.Properties.Caption = "Select All Item"
        Me.CESelAllActiveTax.Size = New System.Drawing.Size(109, 19)
        Me.CESelAllActiveTax.TabIndex = 103
        '
        'PCPajak
        '
        Me.PCPajak.Controls.Add(Me.XtraScrollableControl1)
        Me.PCPajak.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCPajak.Location = New System.Drawing.Point(0, 0)
        Me.PCPajak.Name = "PCPajak"
        Me.PCPajak.Size = New System.Drawing.Size(1015, 78)
        Me.PCPajak.TabIndex = 1
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.SBSummaryPpn)
        Me.XtraScrollableControl1.Controls.Add(Me.SBSetup)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl4)
        Me.XtraScrollableControl1.Controls.Add(Me.SBSummary)
        Me.XtraScrollableControl1.Controls.Add(Me.DETaxFrom)
        Me.XtraScrollableControl1.Controls.Add(Me.SLETaxCat)
        Me.XtraScrollableControl1.Controls.Add(Me.BViewPajak)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl6)
        Me.XtraScrollableControl1.Controls.Add(Me.BPrintPajak)
        Me.XtraScrollableControl1.Controls.Add(Me.SLETaxTagCOA)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl3)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl5)
        Me.XtraScrollableControl1.Controls.Add(Me.DETaxUntil)
        Me.XtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraScrollableControl1.Location = New System.Drawing.Point(2, 2)
        Me.XtraScrollableControl1.Name = "XtraScrollableControl1"
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(1011, 74)
        Me.XtraScrollableControl1.TabIndex = 14
        '
        'SBSummaryPpn
        '
        Me.SBSummaryPpn.Location = New System.Drawing.Point(1064, 12)
        Me.SBSummaryPpn.Name = "SBSummaryPpn"
        Me.SBSummaryPpn.Size = New System.Drawing.Size(79, 23)
        Me.SBSummaryPpn.TabIndex = 15
        Me.SBSummaryPpn.Text = "summary ppn"
        '
        'SBSetup
        '
        Me.SBSetup.Location = New System.Drawing.Point(894, 12)
        Me.SBSetup.Name = "SBSetup"
        Me.SBSetup.Size = New System.Drawing.Size(79, 23)
        Me.SBSetup.TabIndex = 14
        Me.SBSetup.Text = "setup tax"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 17)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl4.TabIndex = 2
        Me.LabelControl4.Text = "Date"
        '
        'SBSummary
        '
        Me.SBSummary.Location = New System.Drawing.Point(979, 12)
        Me.SBSummary.Name = "SBSummary"
        Me.SBSummary.Size = New System.Drawing.Size(79, 23)
        Me.SBSummary.TabIndex = 13
        Me.SBSummary.Text = "summary pph"
        '
        'DETaxFrom
        '
        Me.DETaxFrom.EditValue = Nothing
        Me.DETaxFrom.Location = New System.Drawing.Point(40, 14)
        Me.DETaxFrom.Name = "DETaxFrom"
        Me.DETaxFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETaxFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETaxFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DETaxFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETaxFrom.Size = New System.Drawing.Size(173, 20)
        Me.DETaxFrom.TabIndex = 1
        '
        'SLETaxCat
        '
        Me.SLETaxCat.Location = New System.Drawing.Point(653, 14)
        Me.SLETaxCat.Name = "SLETaxCat"
        Me.SLETaxCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLETaxCat.Properties.View = Me.GridView2
        Me.SLETaxCat.Size = New System.Drawing.Size(123, 20)
        Me.SLETaxCat.TabIndex = 12
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn21, Me.GridColumn22})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "id_tax_report"
        Me.GridColumn21.FieldName = "id_tax_report"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn22.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn22.Caption = "Tax Type"
        Me.GridColumn22.FieldName = "tax_report"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 0
        Me.GridColumn22.Width = 281
        '
        'BViewPajak
        '
        Me.BViewPajak.Location = New System.Drawing.Point(782, 12)
        Me.BViewPajak.Name = "BViewPajak"
        Me.BViewPajak.Size = New System.Drawing.Size(50, 23)
        Me.BViewPajak.TabIndex = 3
        Me.BViewPajak.Text = "view"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(623, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Type"
        '
        'BPrintPajak
        '
        Me.BPrintPajak.Location = New System.Drawing.Point(838, 12)
        Me.BPrintPajak.Name = "BPrintPajak"
        Me.BPrintPajak.Size = New System.Drawing.Size(50, 23)
        Me.BPrintPajak.TabIndex = 6
        Me.BPrintPajak.Text = "print"
        '
        'SLETaxTagCOA
        '
        Me.SLETaxTagCOA.Location = New System.Drawing.Point(449, 14)
        Me.SLETaxTagCOA.Name = "SLETaxTagCOA"
        Me.SLETaxTagCOA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLETaxTagCOA.Properties.View = Me.GridView1
        Me.SLETaxTagCOA.Size = New System.Drawing.Size(168, 20)
        Me.SLETaxTagCOA.TabIndex = 10
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn18, Me.GridColumn19, Me.GridColumn20})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "id_coa_tag"
        Me.GridColumn18.FieldName = "id_comp"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn19.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn19.Caption = "Tag Code"
        Me.GridColumn19.FieldName = "tag_code"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        Me.GridColumn19.Width = 281
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Description"
        Me.GridColumn20.FieldName = "tag_description"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 1
        Me.GridColumn20.Width = 1351
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(219, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "until"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(424, 17)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Tag"
        '
        'DETaxUntil
        '
        Me.DETaxUntil.EditValue = Nothing
        Me.DETaxUntil.Location = New System.Drawing.Point(245, 14)
        Me.DETaxUntil.Name = "DETaxUntil"
        Me.DETaxUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETaxUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETaxUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DETaxUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETaxUntil.Size = New System.Drawing.Size(173, 20)
        Me.DETaxUntil.TabIndex = 8
        '
        'XTPMonthlyReport
        '
        Me.XTPMonthlyReport.Controls.Add(Me.XTCMonthlyReport)
        Me.XTPMonthlyReport.Controls.Add(Me.PCFilterMonthly)
        Me.XTPMonthlyReport.Name = "XTPMonthlyReport"
        Me.XTPMonthlyReport.Size = New System.Drawing.Size(1015, 444)
        Me.XTPMonthlyReport.Text = "Comparation Report"
        '
        'XTCMonthlyReport
        '
        Me.XTCMonthlyReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCMonthlyReport.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCMonthlyReport.Location = New System.Drawing.Point(0, 48)
        Me.XTCMonthlyReport.Name = "XTCMonthlyReport"
        Me.XTCMonthlyReport.SelectedTabPage = Me.XTPMBS
        Me.XTCMonthlyReport.Size = New System.Drawing.Size(1015, 396)
        Me.XTCMonthlyReport.TabIndex = 0
        Me.XTCMonthlyReport.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPMBS, Me.XTPMProfitLoss, Me.XTPMBSvsMonth, Me.XTPMPLvsMonth, Me.XTPMPLvsYear, Me.XTPMPLvsYTD, Me.XTPMPBSvsPrevYear, Me.XTPSalesAchievement})
        '
        'XTPMBS
        '
        Me.XTPMBS.Controls.Add(Me.SplitContainerControl1)
        Me.XTPMBS.Name = "XTPMBS"
        Me.XTPMBS.Size = New System.Drawing.Size(1009, 368)
        Me.XTPMBS.Text = "Balance Sheet"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControl3)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl4)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1009, 368)
        Me.SplitContainerControl1.SplitterPosition = 512
        Me.SplitContainerControl1.TabIndex = 1
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.GCMAktiva)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(512, 368)
        Me.GroupControl3.TabIndex = 1
        Me.GroupControl3.Text = "Asset"
        '
        'GCMAktiva
        '
        Me.GCMAktiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMAktiva.Location = New System.Drawing.Point(2, 20)
        Me.GCMAktiva.MainView = Me.GVMAktiva
        Me.GCMAktiva.Name = "GCMAktiva"
        Me.GCMAktiva.Size = New System.Drawing.Size(508, 346)
        Me.GCMAktiva.TabIndex = 0
        Me.GCMAktiva.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMAktiva})
        '
        'GVMAktiva
        '
        Me.GVMAktiva.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.BandedGridColumn35, Me.BandedGridColumn26, Me.BandedGridColumn36, Me.BandedGridColumn30, Me.BandedGridColumn37, Me.BandedGridColumn31, Me.BandedGridColumn32, Me.BandedGridColumn34, Me.BandedGridColumnPercentage, Me.BandedGridColumn33})
        Me.GVMAktiva.GridControl = Me.GCMAktiva
        Me.GVMAktiva.GroupCount = 2
        Me.GVMAktiva.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumn34, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.BandedGridColumn33, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percentage", Me.BandedGridColumnPercentage, "{0:N2} %", 1)})
        Me.GVMAktiva.Name = "GVMAktiva"
        Me.GVMAktiva.OptionsView.ShowFooter = True
        Me.GVMAktiva.OptionsView.ShowGroupPanel = False
        Me.GVMAktiva.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn26, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn30, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'BandedGridColumn35
        '
        Me.BandedGridColumn35.Caption = "Head Name"
        Me.BandedGridColumn35.FieldName = "head_name"
        Me.BandedGridColumn35.Name = "BandedGridColumn35"
        '
        'BandedGridColumn26
        '
        Me.BandedGridColumn26.Caption = "Head"
        Me.BandedGridColumn26.FieldName = "head_desc"
        Me.BandedGridColumn26.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn26.Name = "BandedGridColumn26"
        Me.BandedGridColumn26.Visible = True
        Me.BandedGridColumn26.VisibleIndex = 1
        '
        'BandedGridColumn36
        '
        Me.BandedGridColumn36.Caption = "Sub Name"
        Me.BandedGridColumn36.FieldName = "sub_name"
        Me.BandedGridColumn36.Name = "BandedGridColumn36"
        '
        'BandedGridColumn30
        '
        Me.BandedGridColumn30.Caption = "Sub"
        Me.BandedGridColumn30.FieldName = "sub_desc"
        Me.BandedGridColumn30.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn30.Name = "BandedGridColumn30"
        Me.BandedGridColumn30.Visible = True
        Me.BandedGridColumn30.VisibleIndex = 3
        '
        'BandedGridColumn37
        '
        Me.BandedGridColumn37.Caption = "ID Acc"
        Me.BandedGridColumn37.FieldName = "id_acc"
        Me.BandedGridColumn37.Name = "BandedGridColumn37"
        '
        'BandedGridColumn31
        '
        Me.BandedGridColumn31.Caption = "No"
        Me.BandedGridColumn31.FieldName = "acc_name"
        Me.BandedGridColumn31.Name = "BandedGridColumn31"
        Me.BandedGridColumn31.Visible = True
        Me.BandedGridColumn31.VisibleIndex = 0
        Me.BandedGridColumn31.Width = 121
        '
        'BandedGridColumn32
        '
        Me.BandedGridColumn32.Caption = "Name"
        Me.BandedGridColumn32.FieldName = "acc_description"
        Me.BandedGridColumn32.Name = "BandedGridColumn32"
        Me.BandedGridColumn32.Visible = True
        Me.BandedGridColumn32.VisibleIndex = 1
        Me.BandedGridColumn32.Width = 121
        '
        'BandedGridColumn34
        '
        Me.BandedGridColumn34.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn34.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn34.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn34.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn34.Caption = "Amount"
        Me.BandedGridColumn34.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn34.FieldName = "this_month"
        Me.BandedGridColumn34.Name = "BandedGridColumn34"
        Me.BandedGridColumn34.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumn34.Visible = True
        Me.BandedGridColumn34.VisibleIndex = 2
        Me.BandedGridColumn34.Width = 157
        '
        'BandedGridColumnPercentage
        '
        Me.BandedGridColumnPercentage.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPercentage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPercentage.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPercentage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPercentage.Caption = "% to Total Asset"
        Me.BandedGridColumnPercentage.DisplayFormat.FormatString = "{0:N2} %"
        Me.BandedGridColumnPercentage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPercentage.FieldName = "percentage"
        Me.BandedGridColumnPercentage.Name = "BandedGridColumnPercentage"
        Me.BandedGridColumnPercentage.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percentage", "{0:N2} %", 2)})
        Me.BandedGridColumnPercentage.Visible = True
        Me.BandedGridColumnPercentage.VisibleIndex = 3
        Me.BandedGridColumnPercentage.Width = 102
        '
        'BandedGridColumn33
        '
        Me.BandedGridColumn33.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn33.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn33.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn33.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn33.Caption = "Prev Month"
        Me.BandedGridColumn33.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn33.FieldName = "prev_month"
        Me.BandedGridColumn33.Name = "BandedGridColumn33"
        Me.BandedGridColumn33.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.GCMPasiva)
        Me.GroupControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl4.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(492, 368)
        Me.GroupControl4.TabIndex = 2
        Me.GroupControl4.Text = "Liability And Equity"
        '
        'GCMPasiva
        '
        Me.GCMPasiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMPasiva.Location = New System.Drawing.Point(2, 20)
        Me.GCMPasiva.MainView = Me.GVMPasiva
        Me.GCMPasiva.Name = "GCMPasiva"
        Me.GCMPasiva.Size = New System.Drawing.Size(488, 346)
        Me.GCMPasiva.TabIndex = 1
        Me.GCMPasiva.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMPasiva})
        '
        'GVMPasiva
        '
        Me.GVMPasiva.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn53, Me.GridColumn54, Me.GridColumn55, Me.GridColumn56, Me.GridColumn57, Me.GridColumn58, Me.GridColumn59, Me.GridColumn60, Me.GridColumn61, Me.GridColumn62})
        Me.GVMPasiva.GridControl = Me.GCMPasiva
        Me.GVMPasiva.GroupCount = 2
        Me.GVMPasiva.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.GridColumn60, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.GridColumn62, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percentage", Me.GridColumn61, "{0:N2} %", 1)})
        Me.GVMPasiva.Name = "GVMPasiva"
        Me.GVMPasiva.OptionsView.ShowFooter = True
        Me.GVMPasiva.OptionsView.ShowGroupPanel = False
        Me.GVMPasiva.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn54, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn56, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn53
        '
        Me.GridColumn53.Caption = "Head Name"
        Me.GridColumn53.FieldName = "head_name"
        Me.GridColumn53.Name = "GridColumn53"
        '
        'GridColumn54
        '
        Me.GridColumn54.Caption = "Head"
        Me.GridColumn54.FieldName = "head_desc"
        Me.GridColumn54.FieldNameSortGroup = "head_name"
        Me.GridColumn54.Name = "GridColumn54"
        Me.GridColumn54.Visible = True
        Me.GridColumn54.VisibleIndex = 1
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "Sub Name"
        Me.GridColumn55.FieldName = "sub_name"
        Me.GridColumn55.Name = "GridColumn55"
        '
        'GridColumn56
        '
        Me.GridColumn56.Caption = "Sub"
        Me.GridColumn56.FieldName = "sub_desc"
        Me.GridColumn56.FieldNameSortGroup = "sub_name"
        Me.GridColumn56.Name = "GridColumn56"
        Me.GridColumn56.Visible = True
        Me.GridColumn56.VisibleIndex = 3
        '
        'GridColumn57
        '
        Me.GridColumn57.Caption = "ID Acc"
        Me.GridColumn57.FieldName = "id_acc"
        Me.GridColumn57.Name = "GridColumn57"
        '
        'GridColumn58
        '
        Me.GridColumn58.Caption = "No"
        Me.GridColumn58.FieldName = "acc_name"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.Visible = True
        Me.GridColumn58.VisibleIndex = 0
        Me.GridColumn58.Width = 121
        '
        'GridColumn59
        '
        Me.GridColumn59.Caption = "Name"
        Me.GridColumn59.FieldName = "acc_description"
        Me.GridColumn59.Name = "GridColumn59"
        Me.GridColumn59.Visible = True
        Me.GridColumn59.VisibleIndex = 1
        Me.GridColumn59.Width = 121
        '
        'GridColumn60
        '
        Me.GridColumn60.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn60.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn60.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn60.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn60.Caption = "Amount"
        Me.GridColumn60.DisplayFormat.FormatString = "N2"
        Me.GridColumn60.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn60.FieldName = "this_month"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.GridColumn60.Visible = True
        Me.GridColumn60.VisibleIndex = 2
        Me.GridColumn60.Width = 157
        '
        'GridColumn61
        '
        Me.GridColumn61.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn61.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn61.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn61.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn61.Caption = "% to Total Asset"
        Me.GridColumn61.DisplayFormat.FormatString = "{0:N2} %"
        Me.GridColumn61.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn61.FieldName = "percentage"
        Me.GridColumn61.Name = "GridColumn61"
        Me.GridColumn61.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percentage", "{0:N2} %", 2)})
        Me.GridColumn61.Visible = True
        Me.GridColumn61.VisibleIndex = 3
        Me.GridColumn61.Width = 102
        '
        'GridColumn62
        '
        Me.GridColumn62.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn62.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn62.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn62.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn62.Caption = "Prev Month"
        Me.GridColumn62.DisplayFormat.FormatString = "N2"
        Me.GridColumn62.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn62.FieldName = "prev_month"
        Me.GridColumn62.Name = "GridColumn62"
        Me.GridColumn62.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        '
        'XTPMProfitLoss
        '
        Me.XTPMProfitLoss.Controls.Add(Me.GCMProfitLoss)
        Me.XTPMProfitLoss.Name = "XTPMProfitLoss"
        Me.XTPMProfitLoss.Size = New System.Drawing.Size(1009, 368)
        Me.XTPMProfitLoss.Text = "Income Statement"
        '
        'GCMProfitLoss
        '
        Me.GCMProfitLoss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMProfitLoss.Location = New System.Drawing.Point(0, 0)
        Me.GCMProfitLoss.MainView = Me.GVMProfitLoss
        Me.GCMProfitLoss.Name = "GCMProfitLoss"
        Me.GCMProfitLoss.Size = New System.Drawing.Size(1009, 368)
        Me.GCMProfitLoss.TabIndex = 2
        Me.GCMProfitLoss.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMProfitLoss})
        '
        'GVMProfitLoss
        '
        Me.GVMProfitLoss.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand7, Me.GridBand8})
        Me.GVMProfitLoss.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn48, Me.BandedGridColumn38, Me.BandedGridColumn49, Me.BandedGridColumn39, Me.BandedGridColumn50, Me.BandedGridColumn51, Me.BandedGridColumn45, Me.BandedGridColumn40, Me.BandedGridColumn41, Me.BandedGridColumn44, Me.BandedGridColumn42, Me.BandedGridColumn46, Me.BandedGridColumnMISPercent, Me.BandedGridColumn43, Me.BandedGridColumn47})
        Me.GVMProfitLoss.GridControl = Me.GCMProfitLoss
        Me.GVMProfitLoss.GroupCount = 3
        Me.GVMProfitLoss.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumn44, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.BandedGridColumn42, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", Me.BandedGridColumn46, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "percent_this_month", Me.BandedGridColumnMISPercent, "{0:N0} %", 1)})
        Me.GVMProfitLoss.Name = "GVMProfitLoss"
        Me.GVMProfitLoss.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVMProfitLoss.OptionsView.ShowFooter = True
        Me.GVMProfitLoss.OptionsView.ShowGroupPanel = False
        Me.GVMProfitLoss.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn45, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn38, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn39, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand7
        '
        Me.GridBand7.Caption = "Account"
        Me.GridBand7.Columns.Add(Me.BandedGridColumn38)
        Me.GridBand7.Columns.Add(Me.BandedGridColumn39)
        Me.GridBand7.Columns.Add(Me.BandedGridColumn45)
        Me.GridBand7.Columns.Add(Me.BandedGridColumn40)
        Me.GridBand7.Columns.Add(Me.BandedGridColumn41)
        Me.GridBand7.Name = "GridBand7"
        Me.GridBand7.VisibleIndex = 0
        Me.GridBand7.Width = 158
        '
        'BandedGridColumn38
        '
        Me.BandedGridColumn38.Caption = "Head"
        Me.BandedGridColumn38.FieldName = "head_desc"
        Me.BandedGridColumn38.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn38.Name = "BandedGridColumn38"
        '
        'BandedGridColumn39
        '
        Me.BandedGridColumn39.Caption = "Sub"
        Me.BandedGridColumn39.FieldName = "sub_desc"
        Me.BandedGridColumn39.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn39.Name = "BandedGridColumn39"
        '
        'BandedGridColumn45
        '
        Me.BandedGridColumn45.Caption = "Group"
        Me.BandedGridColumn45.FieldName = "report_sub"
        Me.BandedGridColumn45.FieldNameSortGroup = "id_consolidation_report_sub"
        Me.BandedGridColumn45.Name = "BandedGridColumn45"
        Me.BandedGridColumn45.Width = 83
        '
        'BandedGridColumn40
        '
        Me.BandedGridColumn40.Caption = "No"
        Me.BandedGridColumn40.FieldName = "acc_name"
        Me.BandedGridColumn40.Name = "BandedGridColumn40"
        Me.BandedGridColumn40.Visible = True
        Me.BandedGridColumn40.Width = 83
        '
        'BandedGridColumn41
        '
        Me.BandedGridColumn41.Caption = "Name"
        Me.BandedGridColumn41.FieldName = "acc_description"
        Me.BandedGridColumn41.Name = "BandedGridColumn41"
        Me.BandedGridColumn41.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "acc_description", "Net Profit After Tax")})
        Me.BandedGridColumn41.Visible = True
        '
        'GridBand8
        '
        Me.GridBand8.Caption = "Amount"
        Me.GridBand8.Columns.Add(Me.BandedGridColumn42)
        Me.GridBand8.Columns.Add(Me.BandedGridColumn43)
        Me.GridBand8.Columns.Add(Me.BandedGridColumn44)
        Me.GridBand8.Columns.Add(Me.BandedGridColumnMISPercent)
        Me.GridBand8.Columns.Add(Me.BandedGridColumn46)
        Me.GridBand8.Columns.Add(Me.BandedGridColumn47)
        Me.GridBand8.Name = "GridBand8"
        Me.GridBand8.VisibleIndex = 1
        Me.GridBand8.Width = 150
        '
        'BandedGridColumn42
        '
        Me.BandedGridColumn42.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn42.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn42.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn42.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn42.Caption = "Prev Month"
        Me.BandedGridColumn42.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn42.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn42.FieldName = "prev_month"
        Me.BandedGridColumn42.Name = "BandedGridColumn42"
        Me.BandedGridColumn42.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        '
        'BandedGridColumn43
        '
        Me.BandedGridColumn43.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn43.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn43.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn43.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn43.Caption = "%"
        Me.BandedGridColumn43.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn43.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn43.FieldName = "percent_prev_month"
        Me.BandedGridColumn43.Name = "BandedGridColumn43"
        '
        'BandedGridColumn44
        '
        Me.BandedGridColumn44.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn44.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn44.Caption = "Amount"
        Me.BandedGridColumn44.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn44.FieldName = "this_month"
        Me.BandedGridColumn44.Name = "BandedGridColumn44"
        Me.BandedGridColumn44.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumn44.Visible = True
        '
        'BandedGridColumnMISPercent
        '
        Me.BandedGridColumnMISPercent.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnMISPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnMISPercent.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnMISPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnMISPercent.Caption = "%"
        Me.BandedGridColumnMISPercent.DisplayFormat.FormatString = "{0:N0} %"
        Me.BandedGridColumnMISPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnMISPercent.FieldName = "percent_this_month"
        Me.BandedGridColumnMISPercent.Name = "BandedGridColumnMISPercent"
        Me.BandedGridColumnMISPercent.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_this_month", "{0:N0} %", 2)})
        Me.BandedGridColumnMISPercent.Visible = True
        '
        'BandedGridColumn46
        '
        Me.BandedGridColumn46.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn46.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn46.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn46.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn46.Caption = "Year to Date"
        Me.BandedGridColumn46.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn46.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn46.FieldName = "this_year_to_date"
        Me.BandedGridColumn46.Name = "BandedGridColumn46"
        Me.BandedGridColumn46.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", "{0:N2}")})
        '
        'BandedGridColumn47
        '
        Me.BandedGridColumn47.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn47.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn47.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn47.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn47.Caption = "%"
        Me.BandedGridColumn47.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn47.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn47.FieldName = "percent_this_year_to_date"
        Me.BandedGridColumn47.Name = "BandedGridColumn47"
        '
        'BandedGridColumn48
        '
        Me.BandedGridColumn48.Caption = "Head Name"
        Me.BandedGridColumn48.FieldName = "head_name"
        Me.BandedGridColumn48.Name = "BandedGridColumn48"
        Me.BandedGridColumn48.Visible = True
        '
        'BandedGridColumn49
        '
        Me.BandedGridColumn49.Caption = "Sub Name"
        Me.BandedGridColumn49.FieldName = "sub_name"
        Me.BandedGridColumn49.Name = "BandedGridColumn49"
        Me.BandedGridColumn49.Visible = True
        '
        'BandedGridColumn50
        '
        Me.BandedGridColumn50.Caption = "ID Acc"
        Me.BandedGridColumn50.FieldName = "id_acc"
        Me.BandedGridColumn50.Name = "BandedGridColumn50"
        '
        'BandedGridColumn51
        '
        Me.BandedGridColumn51.Caption = "Report Group No"
        Me.BandedGridColumn51.FieldName = "id_consolidation_report_sub"
        Me.BandedGridColumn51.Name = "BandedGridColumn51"
        '
        'XTPMBSvsMonth
        '
        Me.XTPMBSvsMonth.Controls.Add(Me.GCMBSvsPrevMonth)
        Me.XTPMBSvsMonth.Name = "XTPMBSvsMonth"
        Me.XTPMBSvsMonth.Size = New System.Drawing.Size(1009, 368)
        Me.XTPMBSvsMonth.Text = "Balance Sheet vs last Month"
        '
        'GCMBSvsPrevMonth
        '
        Me.GCMBSvsPrevMonth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMBSvsPrevMonth.Location = New System.Drawing.Point(0, 0)
        Me.GCMBSvsPrevMonth.MainView = Me.GVMBSvsPrevMonth
        Me.GCMBSvsPrevMonth.Name = "GCMBSvsPrevMonth"
        Me.GCMBSvsPrevMonth.Size = New System.Drawing.Size(1009, 368)
        Me.GCMBSvsPrevMonth.TabIndex = 1
        Me.GCMBSvsPrevMonth.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMBSvsPrevMonth})
        '
        'GVMBSvsPrevMonth
        '
        Me.GVMBSvsPrevMonth.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn63, Me.GridColumn64, Me.GridColumn65, Me.GridColumn66, Me.GridColumn67, Me.GridColumn68, Me.GridColumn69, Me.GridColumn70, Me.GridColumn72, Me.GridColumn71})
        Me.GVMBSvsPrevMonth.GridControl = Me.GCMBSvsPrevMonth
        Me.GVMBSvsPrevMonth.GroupCount = 2
        Me.GVMBSvsPrevMonth.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.GridColumn70, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.GridColumn72, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percentage", Me.GridColumn71, "{0:N2} %", 1)})
        Me.GVMBSvsPrevMonth.Name = "GVMBSvsPrevMonth"
        Me.GVMBSvsPrevMonth.OptionsView.ShowGroupPanel = False
        Me.GVMBSvsPrevMonth.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn64, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn66, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn63
        '
        Me.GridColumn63.Caption = "Head Name"
        Me.GridColumn63.FieldName = "head_name"
        Me.GridColumn63.Name = "GridColumn63"
        '
        'GridColumn64
        '
        Me.GridColumn64.Caption = "Head"
        Me.GridColumn64.FieldName = "head_desc"
        Me.GridColumn64.FieldNameSortGroup = "head_name"
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.Visible = True
        Me.GridColumn64.VisibleIndex = 1
        '
        'GridColumn65
        '
        Me.GridColumn65.Caption = "Sub Name"
        Me.GridColumn65.FieldName = "sub_name"
        Me.GridColumn65.Name = "GridColumn65"
        '
        'GridColumn66
        '
        Me.GridColumn66.Caption = "Sub"
        Me.GridColumn66.FieldName = "sub_desc"
        Me.GridColumn66.FieldNameSortGroup = "sub_name"
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.Visible = True
        Me.GridColumn66.VisibleIndex = 3
        '
        'GridColumn67
        '
        Me.GridColumn67.Caption = "ID Acc"
        Me.GridColumn67.FieldName = "id_acc"
        Me.GridColumn67.Name = "GridColumn67"
        '
        'GridColumn68
        '
        Me.GridColumn68.Caption = "No"
        Me.GridColumn68.FieldName = "acc_name"
        Me.GridColumn68.Name = "GridColumn68"
        Me.GridColumn68.Width = 211
        '
        'GridColumn69
        '
        Me.GridColumn69.Caption = "Name"
        Me.GridColumn69.FieldName = "acc_description"
        Me.GridColumn69.Name = "GridColumn69"
        Me.GridColumn69.Visible = True
        Me.GridColumn69.VisibleIndex = 0
        Me.GridColumn69.Width = 498
        '
        'GridColumn70
        '
        Me.GridColumn70.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn70.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn70.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn70.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn70.Caption = "This Month"
        Me.GridColumn70.DisplayFormat.FormatString = "N2"
        Me.GridColumn70.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn70.FieldName = "this_month"
        Me.GridColumn70.Name = "GridColumn70"
        Me.GridColumn70.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.GridColumn70.Visible = True
        Me.GridColumn70.VisibleIndex = 2
        Me.GridColumn70.Width = 292
        '
        'GridColumn72
        '
        Me.GridColumn72.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn72.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn72.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn72.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn72.Caption = "Prev Month"
        Me.GridColumn72.DisplayFormat.FormatString = "N2"
        Me.GridColumn72.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn72.FieldName = "prev_month"
        Me.GridColumn72.Name = "GridColumn72"
        Me.GridColumn72.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        Me.GridColumn72.Visible = True
        Me.GridColumn72.VisibleIndex = 1
        Me.GridColumn72.Width = 354
        '
        'GridColumn71
        '
        Me.GridColumn71.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn71.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn71.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn71.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn71.Caption = "% to Prev Month"
        Me.GridColumn71.DisplayFormat.FormatString = "{0:N2} %"
        Me.GridColumn71.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn71.FieldName = "percentage"
        Me.GridColumn71.Name = "GridColumn71"
        Me.GridColumn71.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percentage", "{0:N2} %", 2)})
        Me.GridColumn71.Visible = True
        Me.GridColumn71.VisibleIndex = 3
        Me.GridColumn71.Width = 261
        '
        'XTPMPLvsMonth
        '
        Me.XTPMPLvsMonth.Controls.Add(Me.GCMPLvsPrevMonth)
        Me.XTPMPLvsMonth.Name = "XTPMPLvsMonth"
        Me.XTPMPLvsMonth.Size = New System.Drawing.Size(1009, 368)
        Me.XTPMPLvsMonth.Text = "Income Statement vs last Month"
        '
        'GCMPLvsPrevMonth
        '
        Me.GCMPLvsPrevMonth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMPLvsPrevMonth.Location = New System.Drawing.Point(0, 0)
        Me.GCMPLvsPrevMonth.MainView = Me.GVMPLvsPrevMonth
        Me.GCMPLvsPrevMonth.Name = "GCMPLvsPrevMonth"
        Me.GCMPLvsPrevMonth.Size = New System.Drawing.Size(1009, 368)
        Me.GCMPLvsPrevMonth.TabIndex = 3
        Me.GCMPLvsPrevMonth.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMPLvsPrevMonth})
        '
        'GVMPLvsPrevMonth
        '
        Me.GVMPLvsPrevMonth.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand9, Me.GridBand10})
        Me.GVMPLvsPrevMonth.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn63, Me.BandedGridColumn52, Me.BandedGridColumn64, Me.BandedGridColumn53, Me.BandedGridColumn65, Me.BandedGridColumn66, Me.BandedGridColumn54, Me.BandedGridColumn55, Me.BandedGridColumn56, Me.BandedGridColumn59, Me.BandedGridColumn57, Me.BandedGridColumn61, Me.BandedGridColumn60, Me.BandedGridColumn58, Me.BandedGridColumn62})
        Me.GVMPLvsPrevMonth.GridControl = Me.GCMPLvsPrevMonth
        Me.GVMPLvsPrevMonth.GroupCount = 3
        Me.GVMPLvsPrevMonth.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumn59, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", Me.BandedGridColumn57, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", Me.BandedGridColumn61, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "percent_this_month", Me.BandedGridColumn60, "{0:N0} %", 1)})
        Me.GVMPLvsPrevMonth.Name = "GVMPLvsPrevMonth"
        Me.GVMPLvsPrevMonth.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVMPLvsPrevMonth.OptionsView.ShowFooter = True
        Me.GVMPLvsPrevMonth.OptionsView.ShowGroupPanel = False
        Me.GVMPLvsPrevMonth.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn54, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn52, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn53, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand9
        '
        Me.GridBand9.Caption = "Account"
        Me.GridBand9.Columns.Add(Me.BandedGridColumn52)
        Me.GridBand9.Columns.Add(Me.BandedGridColumn53)
        Me.GridBand9.Columns.Add(Me.BandedGridColumn54)
        Me.GridBand9.Columns.Add(Me.BandedGridColumn55)
        Me.GridBand9.Columns.Add(Me.BandedGridColumn56)
        Me.GridBand9.Name = "GridBand9"
        Me.GridBand9.VisibleIndex = 0
        Me.GridBand9.Width = 158
        '
        'BandedGridColumn52
        '
        Me.BandedGridColumn52.Caption = "Head"
        Me.BandedGridColumn52.FieldName = "head_desc"
        Me.BandedGridColumn52.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn52.Name = "BandedGridColumn52"
        '
        'BandedGridColumn53
        '
        Me.BandedGridColumn53.Caption = "Sub"
        Me.BandedGridColumn53.FieldName = "sub_desc"
        Me.BandedGridColumn53.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn53.Name = "BandedGridColumn53"
        '
        'BandedGridColumn54
        '
        Me.BandedGridColumn54.Caption = "Group"
        Me.BandedGridColumn54.FieldName = "report_sub"
        Me.BandedGridColumn54.FieldNameSortGroup = "id_consolidation_report_sub"
        Me.BandedGridColumn54.Name = "BandedGridColumn54"
        Me.BandedGridColumn54.Width = 83
        '
        'BandedGridColumn55
        '
        Me.BandedGridColumn55.Caption = "No"
        Me.BandedGridColumn55.FieldName = "acc_name"
        Me.BandedGridColumn55.Name = "BandedGridColumn55"
        Me.BandedGridColumn55.Visible = True
        Me.BandedGridColumn55.Width = 83
        '
        'BandedGridColumn56
        '
        Me.BandedGridColumn56.Caption = "Name"
        Me.BandedGridColumn56.FieldName = "acc_description"
        Me.BandedGridColumn56.Name = "BandedGridColumn56"
        Me.BandedGridColumn56.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "acc_description", "Net Profit After Tax")})
        Me.BandedGridColumn56.Visible = True
        '
        'GridBand10
        '
        Me.GridBand10.Caption = "Amount"
        Me.GridBand10.Columns.Add(Me.BandedGridColumn57)
        Me.GridBand10.Columns.Add(Me.BandedGridColumn58)
        Me.GridBand10.Columns.Add(Me.BandedGridColumn59)
        Me.GridBand10.Columns.Add(Me.BandedGridColumn60)
        Me.GridBand10.Columns.Add(Me.BandedGridColumn61)
        Me.GridBand10.Columns.Add(Me.BandedGridColumn62)
        Me.GridBand10.Name = "GridBand10"
        Me.GridBand10.VisibleIndex = 1
        Me.GridBand10.Width = 225
        '
        'BandedGridColumn57
        '
        Me.BandedGridColumn57.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn57.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn57.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn57.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn57.Caption = "Prev Month"
        Me.BandedGridColumn57.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn57.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn57.FieldName = "prev_month"
        Me.BandedGridColumn57.Name = "BandedGridColumn57"
        Me.BandedGridColumn57.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        Me.BandedGridColumn57.Visible = True
        '
        'BandedGridColumn58
        '
        Me.BandedGridColumn58.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn58.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn58.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn58.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn58.Caption = "%"
        Me.BandedGridColumn58.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn58.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn58.FieldName = "percent_prev_month"
        Me.BandedGridColumn58.Name = "BandedGridColumn58"
        '
        'BandedGridColumn59
        '
        Me.BandedGridColumn59.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn59.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn59.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn59.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn59.Caption = "This Month"
        Me.BandedGridColumn59.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn59.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn59.FieldName = "this_month"
        Me.BandedGridColumn59.Name = "BandedGridColumn59"
        Me.BandedGridColumn59.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumn59.Visible = True
        '
        'BandedGridColumn60
        '
        Me.BandedGridColumn60.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn60.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn60.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn60.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn60.Caption = "% to Prev Month"
        Me.BandedGridColumn60.DisplayFormat.FormatString = "{0:N0} %"
        Me.BandedGridColumn60.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn60.FieldName = "percentage"
        Me.BandedGridColumn60.Name = "BandedGridColumn60"
        Me.BandedGridColumn60.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_this_month", "{0:N0} %", 2)})
        Me.BandedGridColumn60.Visible = True
        '
        'BandedGridColumn61
        '
        Me.BandedGridColumn61.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn61.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn61.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn61.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn61.Caption = "Year to Date"
        Me.BandedGridColumn61.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn61.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn61.FieldName = "this_year_to_date"
        Me.BandedGridColumn61.Name = "BandedGridColumn61"
        Me.BandedGridColumn61.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", "{0:N2}")})
        '
        'BandedGridColumn62
        '
        Me.BandedGridColumn62.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn62.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn62.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn62.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn62.Caption = "%"
        Me.BandedGridColumn62.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn62.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn62.FieldName = "percent_this_year_to_date"
        Me.BandedGridColumn62.Name = "BandedGridColumn62"
        '
        'BandedGridColumn63
        '
        Me.BandedGridColumn63.Caption = "Head Name"
        Me.BandedGridColumn63.FieldName = "head_name"
        Me.BandedGridColumn63.Name = "BandedGridColumn63"
        Me.BandedGridColumn63.Visible = True
        '
        'BandedGridColumn64
        '
        Me.BandedGridColumn64.Caption = "Sub Name"
        Me.BandedGridColumn64.FieldName = "sub_name"
        Me.BandedGridColumn64.Name = "BandedGridColumn64"
        Me.BandedGridColumn64.Visible = True
        '
        'BandedGridColumn65
        '
        Me.BandedGridColumn65.Caption = "ID Acc"
        Me.BandedGridColumn65.FieldName = "id_acc"
        Me.BandedGridColumn65.Name = "BandedGridColumn65"
        '
        'BandedGridColumn66
        '
        Me.BandedGridColumn66.Caption = "Report Group No"
        Me.BandedGridColumn66.FieldName = "id_consolidation_report_sub"
        Me.BandedGridColumn66.Name = "BandedGridColumn66"
        '
        'XTPMPLvsYear
        '
        Me.XTPMPLvsYear.Controls.Add(Me.GCMPLvsPrevYear)
        Me.XTPMPLvsYear.Name = "XTPMPLvsYear"
        Me.XTPMPLvsYear.Size = New System.Drawing.Size(1009, 368)
        Me.XTPMPLvsYear.Text = "Income Statement vs Last Year"
        '
        'GCMPLvsPrevYear
        '
        Me.GCMPLvsPrevYear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMPLvsPrevYear.Location = New System.Drawing.Point(0, 0)
        Me.GCMPLvsPrevYear.MainView = Me.GVMPLvsPrevYear
        Me.GCMPLvsPrevYear.Name = "GCMPLvsPrevYear"
        Me.GCMPLvsPrevYear.Size = New System.Drawing.Size(1009, 368)
        Me.GCMPLvsPrevYear.TabIndex = 4
        Me.GCMPLvsPrevYear.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMPLvsPrevYear})
        '
        'GVMPLvsPrevYear
        '
        Me.GVMPLvsPrevYear.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand11, Me.GridBandPrevYear, Me.gridBandThisYear, Me.gridBand14})
        Me.GVMPLvsPrevYear.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn78, Me.BandedGridColumn67, Me.BandedGridColumn79, Me.BandedGridColumn68, Me.BandedGridColumn80, Me.BandedGridColumn81, Me.BandedGridColumn69, Me.BandedGridColumn70, Me.BandedGridColumn71, Me.BandedGridColumn74, Me.BandedGridColumn72, Me.BandedGridColumn76, Me.BandedGridColumn75, Me.BandedGridColumn73, Me.BandedGridColumn77, Me.BandedGridColumnVsYearPrev, Me.BandedGridColumnVsYearThisMonth})
        Me.GVMPLvsPrevYear.GridControl = Me.GCMPLvsPrevYear
        Me.GVMPLvsPrevYear.GroupCount = 3
        Me.GVMPLvsPrevYear.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumn74, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_year", Me.BandedGridColumn72, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", Me.BandedGridColumn76, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percentage", Me.BandedGridColumn75, "{0:N0} %", 1), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_sales_prev_year", Me.BandedGridColumnVsYearPrev, "{0:N0} %", "3"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_sales_this_month", Me.BandedGridColumnVsYearThisMonth, "{0:N0} %", "5")})
        Me.GVMPLvsPrevYear.Name = "GVMPLvsPrevYear"
        Me.GVMPLvsPrevYear.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVMPLvsPrevYear.OptionsView.ShowFooter = True
        Me.GVMPLvsPrevYear.OptionsView.ShowGroupPanel = False
        Me.GVMPLvsPrevYear.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn69, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn67, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn68, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand11
        '
        Me.GridBand11.Caption = "Account"
        Me.GridBand11.Columns.Add(Me.BandedGridColumn67)
        Me.GridBand11.Columns.Add(Me.BandedGridColumn68)
        Me.GridBand11.Columns.Add(Me.BandedGridColumn69)
        Me.GridBand11.Columns.Add(Me.BandedGridColumn70)
        Me.GridBand11.Columns.Add(Me.BandedGridColumn71)
        Me.GridBand11.Name = "GridBand11"
        Me.GridBand11.VisibleIndex = 0
        Me.GridBand11.Width = 158
        '
        'BandedGridColumn67
        '
        Me.BandedGridColumn67.Caption = "Head"
        Me.BandedGridColumn67.FieldName = "head_desc"
        Me.BandedGridColumn67.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn67.Name = "BandedGridColumn67"
        '
        'BandedGridColumn68
        '
        Me.BandedGridColumn68.Caption = "Sub"
        Me.BandedGridColumn68.FieldName = "sub_desc"
        Me.BandedGridColumn68.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn68.Name = "BandedGridColumn68"
        '
        'BandedGridColumn69
        '
        Me.BandedGridColumn69.Caption = "Group"
        Me.BandedGridColumn69.FieldName = "report_sub"
        Me.BandedGridColumn69.FieldNameSortGroup = "id_consolidation_report_sub"
        Me.BandedGridColumn69.Name = "BandedGridColumn69"
        Me.BandedGridColumn69.Width = 83
        '
        'BandedGridColumn70
        '
        Me.BandedGridColumn70.Caption = "No"
        Me.BandedGridColumn70.FieldName = "acc_name"
        Me.BandedGridColumn70.Name = "BandedGridColumn70"
        Me.BandedGridColumn70.Visible = True
        Me.BandedGridColumn70.Width = 83
        '
        'BandedGridColumn71
        '
        Me.BandedGridColumn71.Caption = "Name"
        Me.BandedGridColumn71.FieldName = "acc_description"
        Me.BandedGridColumn71.Name = "BandedGridColumn71"
        Me.BandedGridColumn71.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "acc_description", "Net Profit After Tax")})
        Me.BandedGridColumn71.Visible = True
        '
        'GridBandPrevYear
        '
        Me.GridBandPrevYear.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBandPrevYear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBandPrevYear.Caption = "Previous Year"
        Me.GridBandPrevYear.Columns.Add(Me.BandedGridColumn72)
        Me.GridBandPrevYear.Columns.Add(Me.BandedGridColumnVsYearPrev)
        Me.GridBandPrevYear.Columns.Add(Me.BandedGridColumn73)
        Me.GridBandPrevYear.Columns.Add(Me.BandedGridColumn76)
        Me.GridBandPrevYear.Columns.Add(Me.BandedGridColumn77)
        Me.GridBandPrevYear.Name = "GridBandPrevYear"
        Me.GridBandPrevYear.VisibleIndex = 1
        Me.GridBandPrevYear.Width = 188
        '
        'BandedGridColumn72
        '
        Me.BandedGridColumn72.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn72.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn72.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn72.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn72.Caption = "Prev Year"
        Me.BandedGridColumn72.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn72.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn72.FieldName = "prev_year"
        Me.BandedGridColumn72.Name = "BandedGridColumn72"
        Me.BandedGridColumn72.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_year", "{0:N2}")})
        Me.BandedGridColumn72.Visible = True
        Me.BandedGridColumn72.Width = 113
        '
        'BandedGridColumnVsYearPrev
        '
        Me.BandedGridColumnVsYearPrev.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnVsYearPrev.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnVsYearPrev.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnVsYearPrev.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnVsYearPrev.Caption = "% To Sales"
        Me.BandedGridColumnVsYearPrev.DisplayFormat.FormatString = "{0:N0} %"
        Me.BandedGridColumnVsYearPrev.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnVsYearPrev.FieldName = "percent_sales_prev_year"
        Me.BandedGridColumnVsYearPrev.Name = "BandedGridColumnVsYearPrev"
        Me.BandedGridColumnVsYearPrev.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_sales_prev_year", "{0:N0} %", "4")})
        Me.BandedGridColumnVsYearPrev.Visible = True
        '
        'BandedGridColumn73
        '
        Me.BandedGridColumn73.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn73.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn73.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn73.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn73.Caption = "%"
        Me.BandedGridColumn73.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn73.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn73.FieldName = "percent_prev_month"
        Me.BandedGridColumn73.Name = "BandedGridColumn73"
        '
        'BandedGridColumn76
        '
        Me.BandedGridColumn76.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn76.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn76.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn76.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn76.Caption = "Year to Date"
        Me.BandedGridColumn76.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn76.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn76.FieldName = "this_year_to_date"
        Me.BandedGridColumn76.Name = "BandedGridColumn76"
        Me.BandedGridColumn76.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_year_to_date", "{0:N2}")})
        '
        'BandedGridColumn77
        '
        Me.BandedGridColumn77.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn77.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn77.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn77.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn77.Caption = "%"
        Me.BandedGridColumn77.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn77.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn77.FieldName = "percent_this_year_to_date"
        Me.BandedGridColumn77.Name = "BandedGridColumn77"
        '
        'gridBandThisYear
        '
        Me.gridBandThisYear.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBandThisYear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBandThisYear.Caption = "This Month"
        Me.gridBandThisYear.Columns.Add(Me.BandedGridColumn74)
        Me.gridBandThisYear.Columns.Add(Me.BandedGridColumnVsYearThisMonth)
        Me.gridBandThisYear.Name = "gridBandThisYear"
        Me.gridBandThisYear.VisibleIndex = 2
        Me.gridBandThisYear.Width = 187
        '
        'BandedGridColumn74
        '
        Me.BandedGridColumn74.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn74.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn74.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn74.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn74.Caption = "This Month"
        Me.BandedGridColumn74.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn74.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn74.FieldName = "this_month"
        Me.BandedGridColumn74.Name = "BandedGridColumn74"
        Me.BandedGridColumn74.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumn74.Visible = True
        Me.BandedGridColumn74.Width = 112
        '
        'BandedGridColumnVsYearThisMonth
        '
        Me.BandedGridColumnVsYearThisMonth.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnVsYearThisMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnVsYearThisMonth.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnVsYearThisMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnVsYearThisMonth.Caption = "% To Sales"
        Me.BandedGridColumnVsYearThisMonth.DisplayFormat.FormatString = "{0:N0} %"
        Me.BandedGridColumnVsYearThisMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnVsYearThisMonth.FieldName = "percent_sales_this_month"
        Me.BandedGridColumnVsYearThisMonth.Name = "BandedGridColumnVsYearThisMonth"
        Me.BandedGridColumnVsYearThisMonth.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_sales_this_month", "{0:N0} %", "6")})
        Me.BandedGridColumnVsYearThisMonth.Visible = True
        '
        'gridBand14
        '
        Me.gridBand14.Columns.Add(Me.BandedGridColumn75)
        Me.gridBand14.Name = "gridBand14"
        Me.gridBand14.VisibleIndex = 3
        Me.gridBand14.Width = 119
        '
        'BandedGridColumn75
        '
        Me.BandedGridColumn75.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn75.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn75.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn75.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn75.Caption = "% to Prev Year"
        Me.BandedGridColumn75.DisplayFormat.FormatString = "{0:N0} %"
        Me.BandedGridColumn75.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn75.FieldName = "percentage"
        Me.BandedGridColumn75.Name = "BandedGridColumn75"
        Me.BandedGridColumn75.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percentage", "{0:N0} %", 2)})
        Me.BandedGridColumn75.Visible = True
        Me.BandedGridColumn75.Width = 119
        '
        'BandedGridColumn78
        '
        Me.BandedGridColumn78.Caption = "Head Name"
        Me.BandedGridColumn78.FieldName = "head_name"
        Me.BandedGridColumn78.Name = "BandedGridColumn78"
        Me.BandedGridColumn78.Visible = True
        '
        'BandedGridColumn79
        '
        Me.BandedGridColumn79.Caption = "Sub Name"
        Me.BandedGridColumn79.FieldName = "sub_name"
        Me.BandedGridColumn79.Name = "BandedGridColumn79"
        Me.BandedGridColumn79.Visible = True
        '
        'BandedGridColumn80
        '
        Me.BandedGridColumn80.Caption = "ID Acc"
        Me.BandedGridColumn80.FieldName = "id_acc"
        Me.BandedGridColumn80.Name = "BandedGridColumn80"
        '
        'BandedGridColumn81
        '
        Me.BandedGridColumn81.Caption = "Report Group No"
        Me.BandedGridColumn81.FieldName = "id_consolidation_report_sub"
        Me.BandedGridColumn81.Name = "BandedGridColumn81"
        '
        'XTPMPLvsYTD
        '
        Me.XTPMPLvsYTD.Controls.Add(Me.GCMPLvsYTD)
        Me.XTPMPLvsYTD.Name = "XTPMPLvsYTD"
        Me.XTPMPLvsYTD.Size = New System.Drawing.Size(1009, 368)
        Me.XTPMPLvsYTD.Text = "Income Statement (YTD)"
        '
        'GCMPLvsYTD
        '
        Me.GCMPLvsYTD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMPLvsYTD.Location = New System.Drawing.Point(0, 0)
        Me.GCMPLvsYTD.MainView = Me.GVMPLvsYTD
        Me.GCMPLvsYTD.Name = "GCMPLvsYTD"
        Me.GCMPLvsYTD.Size = New System.Drawing.Size(1009, 368)
        Me.GCMPLvsYTD.TabIndex = 5
        Me.GCMPLvsYTD.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMPLvsYTD})
        '
        'GVMPLvsYTD
        '
        Me.GVMPLvsYTD.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand12, Me.GridBand13, Me.GridBand15, Me.GridBand16})
        Me.GVMPLvsYTD.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn95, Me.BandedGridColumn82, Me.BandedGridColumn96, Me.BandedGridColumn83, Me.BandedGridColumn97, Me.BandedGridColumn98, Me.BandedGridColumn84, Me.BandedGridColumn85, Me.BandedGridColumn86, Me.BandedGridColumn92, Me.BandedGridColumn87, Me.BandedGridColumn94, Me.BandedGridColumn89, Me.BandedGridColumn91, Me.BandedGridColumn88, Me.BandedGridColumn93})
        Me.GVMPLvsYTD.GridControl = Me.GCMPLvsYTD
        Me.GVMPLvsYTD.GroupCount = 3
        Me.GVMPLvsYTD.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.BandedGridColumn92, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_year", Me.BandedGridColumn87, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percentage", Me.BandedGridColumn94, "{0:N0} %", 1), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_sales_prev_year", Me.BandedGridColumn88, "{0:N0} %", "3"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_sales_this_month", Me.BandedGridColumn93, "{0:N0} %", "5")})
        Me.GVMPLvsYTD.Name = "GVMPLvsYTD"
        Me.GVMPLvsYTD.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVMPLvsYTD.OptionsView.ShowFooter = True
        Me.GVMPLvsYTD.OptionsView.ShowGroupPanel = False
        Me.GVMPLvsYTD.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn84, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn82, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn83, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand12
        '
        Me.GridBand12.Caption = "Account"
        Me.GridBand12.Columns.Add(Me.BandedGridColumn82)
        Me.GridBand12.Columns.Add(Me.BandedGridColumn83)
        Me.GridBand12.Columns.Add(Me.BandedGridColumn84)
        Me.GridBand12.Columns.Add(Me.BandedGridColumn85)
        Me.GridBand12.Columns.Add(Me.BandedGridColumn86)
        Me.GridBand12.Name = "GridBand12"
        Me.GridBand12.VisibleIndex = 0
        Me.GridBand12.Width = 158
        '
        'BandedGridColumn82
        '
        Me.BandedGridColumn82.Caption = "Head"
        Me.BandedGridColumn82.FieldName = "head_desc"
        Me.BandedGridColumn82.FieldNameSortGroup = "head_name"
        Me.BandedGridColumn82.Name = "BandedGridColumn82"
        '
        'BandedGridColumn83
        '
        Me.BandedGridColumn83.Caption = "Sub"
        Me.BandedGridColumn83.FieldName = "sub_desc"
        Me.BandedGridColumn83.FieldNameSortGroup = "sub_name"
        Me.BandedGridColumn83.Name = "BandedGridColumn83"
        '
        'BandedGridColumn84
        '
        Me.BandedGridColumn84.Caption = "Group"
        Me.BandedGridColumn84.FieldName = "report_sub"
        Me.BandedGridColumn84.FieldNameSortGroup = "id_consolidation_report_sub"
        Me.BandedGridColumn84.Name = "BandedGridColumn84"
        Me.BandedGridColumn84.Width = 83
        '
        'BandedGridColumn85
        '
        Me.BandedGridColumn85.Caption = "No"
        Me.BandedGridColumn85.FieldName = "acc_name"
        Me.BandedGridColumn85.Name = "BandedGridColumn85"
        Me.BandedGridColumn85.Visible = True
        Me.BandedGridColumn85.Width = 83
        '
        'BandedGridColumn86
        '
        Me.BandedGridColumn86.Caption = "Name"
        Me.BandedGridColumn86.FieldName = "acc_description"
        Me.BandedGridColumn86.Name = "BandedGridColumn86"
        Me.BandedGridColumn86.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "acc_description", "Net Profit After Tax")})
        Me.BandedGridColumn86.Visible = True
        '
        'GridBand13
        '
        Me.GridBand13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand13.Caption = "YTD Previous Year"
        Me.GridBand13.Columns.Add(Me.BandedGridColumn87)
        Me.GridBand13.Columns.Add(Me.BandedGridColumn88)
        Me.GridBand13.Columns.Add(Me.BandedGridColumn89)
        Me.GridBand13.Columns.Add(Me.BandedGridColumn91)
        Me.GridBand13.Name = "GridBand13"
        Me.GridBand13.VisibleIndex = 1
        Me.GridBand13.Width = 188
        '
        'BandedGridColumn87
        '
        Me.BandedGridColumn87.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn87.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn87.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn87.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn87.Caption = "Prev Year"
        Me.BandedGridColumn87.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn87.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn87.FieldName = "prev_year"
        Me.BandedGridColumn87.Name = "BandedGridColumn87"
        Me.BandedGridColumn87.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_year", "{0:N2}")})
        Me.BandedGridColumn87.Visible = True
        Me.BandedGridColumn87.Width = 113
        '
        'BandedGridColumn88
        '
        Me.BandedGridColumn88.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn88.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn88.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn88.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn88.Caption = "% To Sales"
        Me.BandedGridColumn88.DisplayFormat.FormatString = "{0:N0} %"
        Me.BandedGridColumn88.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn88.FieldName = "percent_sales_prev_year"
        Me.BandedGridColumn88.Name = "BandedGridColumn88"
        Me.BandedGridColumn88.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_sales_prev_year", "{0:N0} %", "4")})
        Me.BandedGridColumn88.Visible = True
        '
        'BandedGridColumn89
        '
        Me.BandedGridColumn89.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn89.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn89.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn89.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn89.Caption = "%"
        Me.BandedGridColumn89.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn89.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn89.FieldName = "percent_prev_month"
        Me.BandedGridColumn89.Name = "BandedGridColumn89"
        '
        'BandedGridColumn91
        '
        Me.BandedGridColumn91.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn91.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn91.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn91.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn91.Caption = "%"
        Me.BandedGridColumn91.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn91.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn91.FieldName = "percent_this_year_to_date"
        Me.BandedGridColumn91.Name = "BandedGridColumn91"
        '
        'GridBand15
        '
        Me.GridBand15.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand15.Caption = "YTD This Month"
        Me.GridBand15.Columns.Add(Me.BandedGridColumn92)
        Me.GridBand15.Columns.Add(Me.BandedGridColumn93)
        Me.GridBand15.Name = "GridBand15"
        Me.GridBand15.VisibleIndex = 2
        Me.GridBand15.Width = 187
        '
        'BandedGridColumn92
        '
        Me.BandedGridColumn92.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn92.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn92.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn92.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn92.Caption = "This Month"
        Me.BandedGridColumn92.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn92.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn92.FieldName = "this_month"
        Me.BandedGridColumn92.Name = "BandedGridColumn92"
        Me.BandedGridColumn92.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.BandedGridColumn92.Visible = True
        Me.BandedGridColumn92.Width = 112
        '
        'BandedGridColumn93
        '
        Me.BandedGridColumn93.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn93.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn93.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn93.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn93.Caption = "% To Sales"
        Me.BandedGridColumn93.DisplayFormat.FormatString = "{0:N0} %"
        Me.BandedGridColumn93.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn93.FieldName = "percent_sales_this_month"
        Me.BandedGridColumn93.Name = "BandedGridColumn93"
        Me.BandedGridColumn93.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_sales_this_month", "{0:N0} %", "6")})
        Me.BandedGridColumn93.Visible = True
        '
        'GridBand16
        '
        Me.GridBand16.Columns.Add(Me.BandedGridColumn94)
        Me.GridBand16.Name = "GridBand16"
        Me.GridBand16.VisibleIndex = 3
        Me.GridBand16.Width = 119
        '
        'BandedGridColumn94
        '
        Me.BandedGridColumn94.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn94.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn94.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn94.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn94.Caption = "% to Prev Year"
        Me.BandedGridColumn94.DisplayFormat.FormatString = "{0:N0} %"
        Me.BandedGridColumn94.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn94.FieldName = "percentage"
        Me.BandedGridColumn94.Name = "BandedGridColumn94"
        Me.BandedGridColumn94.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percentage", "{0:N0} %", 2)})
        Me.BandedGridColumn94.Visible = True
        Me.BandedGridColumn94.Width = 119
        '
        'BandedGridColumn95
        '
        Me.BandedGridColumn95.Caption = "Head Name"
        Me.BandedGridColumn95.FieldName = "head_name"
        Me.BandedGridColumn95.Name = "BandedGridColumn95"
        Me.BandedGridColumn95.Visible = True
        '
        'BandedGridColumn96
        '
        Me.BandedGridColumn96.Caption = "Sub Name"
        Me.BandedGridColumn96.FieldName = "sub_name"
        Me.BandedGridColumn96.Name = "BandedGridColumn96"
        Me.BandedGridColumn96.Visible = True
        '
        'BandedGridColumn97
        '
        Me.BandedGridColumn97.Caption = "ID Acc"
        Me.BandedGridColumn97.FieldName = "id_acc"
        Me.BandedGridColumn97.Name = "BandedGridColumn97"
        '
        'BandedGridColumn98
        '
        Me.BandedGridColumn98.Caption = "Report Group No"
        Me.BandedGridColumn98.FieldName = "id_consolidation_report_sub"
        Me.BandedGridColumn98.Name = "BandedGridColumn98"
        '
        'XTPMPBSvsPrevYear
        '
        Me.XTPMPBSvsPrevYear.Controls.Add(Me.GCMBSvsPrevYear)
        Me.XTPMPBSvsPrevYear.Name = "XTPMPBSvsPrevYear"
        Me.XTPMPBSvsPrevYear.Size = New System.Drawing.Size(1009, 368)
        Me.XTPMPBSvsPrevYear.Text = "Balance Sheet vs Prev Year"
        '
        'GCMBSvsPrevYear
        '
        Me.GCMBSvsPrevYear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMBSvsPrevYear.Location = New System.Drawing.Point(0, 0)
        Me.GCMBSvsPrevYear.MainView = Me.GVMBSvsPrevYear
        Me.GCMBSvsPrevYear.Name = "GCMBSvsPrevYear"
        Me.GCMBSvsPrevYear.Size = New System.Drawing.Size(1009, 368)
        Me.GCMBSvsPrevYear.TabIndex = 2
        Me.GCMBSvsPrevYear.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMBSvsPrevYear})
        '
        'GVMBSvsPrevYear
        '
        Me.GVMBSvsPrevYear.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand17, Me.gridBand18, Me.gridBand19})
        Me.GVMBSvsPrevYear.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn76, Me.GridColumn77, Me.GridColumn78, Me.GridColumn79, Me.GridColumn80, Me.GridColumn81, Me.GridColumn82, Me.GridColumn83, Me.GridColumn84, Me.GridColumn85, Me.BandedGridColumn90})
        Me.GVMBSvsPrevYear.GridControl = Me.GCMBSvsPrevYear
        Me.GVMBSvsPrevYear.GroupCount = 2
        Me.GVMBSvsPrevYear.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", Me.GridColumn83, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_year", Me.GridColumn84, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_asset_tm", Me.GridColumn85, "{0:N2} %", 1), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_asset_py", Me.BandedGridColumn90, "{0:N2} %", "3")})
        Me.GVMBSvsPrevYear.Name = "GVMBSvsPrevYear"
        Me.GVMBSvsPrevYear.OptionsView.ShowGroupPanel = False
        Me.GVMBSvsPrevYear.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn77, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn79, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand17
        '
        Me.GridBand17.Caption = "Description"
        Me.GridBand17.Columns.Add(Me.GridColumn76)
        Me.GridBand17.Columns.Add(Me.GridColumn77)
        Me.GridBand17.Columns.Add(Me.GridColumn78)
        Me.GridBand17.Columns.Add(Me.GridColumn79)
        Me.GridBand17.Columns.Add(Me.GridColumn80)
        Me.GridBand17.Columns.Add(Me.GridColumn81)
        Me.GridBand17.Columns.Add(Me.GridColumn82)
        Me.GridBand17.Name = "GridBand17"
        Me.GridBand17.VisibleIndex = 0
        Me.GridBand17.Width = 709
        '
        'GridColumn76
        '
        Me.GridColumn76.Caption = "Head Name"
        Me.GridColumn76.FieldName = "head_name"
        Me.GridColumn76.Name = "GridColumn76"
        '
        'GridColumn77
        '
        Me.GridColumn77.Caption = "Head"
        Me.GridColumn77.FieldName = "head_desc"
        Me.GridColumn77.FieldNameSortGroup = "head_name"
        Me.GridColumn77.Name = "GridColumn77"
        '
        'GridColumn78
        '
        Me.GridColumn78.Caption = "Sub Name"
        Me.GridColumn78.FieldName = "sub_name"
        Me.GridColumn78.Name = "GridColumn78"
        '
        'GridColumn79
        '
        Me.GridColumn79.Caption = "Sub"
        Me.GridColumn79.FieldName = "sub_desc"
        Me.GridColumn79.FieldNameSortGroup = "sub_name"
        Me.GridColumn79.Name = "GridColumn79"
        '
        'GridColumn80
        '
        Me.GridColumn80.Caption = "ID Acc"
        Me.GridColumn80.FieldName = "id_acc"
        Me.GridColumn80.Name = "GridColumn80"
        '
        'GridColumn81
        '
        Me.GridColumn81.Caption = "No"
        Me.GridColumn81.FieldName = "acc_name"
        Me.GridColumn81.Name = "GridColumn81"
        Me.GridColumn81.Visible = True
        Me.GridColumn81.Width = 211
        '
        'GridColumn82
        '
        Me.GridColumn82.Caption = "Name"
        Me.GridColumn82.FieldName = "acc_description"
        Me.GridColumn82.Name = "GridColumn82"
        Me.GridColumn82.Visible = True
        Me.GridColumn82.Width = 498
        '
        'gridBand18
        '
        Me.gridBand18.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand18.Caption = "Previous Year"
        Me.gridBand18.Columns.Add(Me.GridColumn84)
        Me.gridBand18.Columns.Add(Me.BandedGridColumn90)
        Me.gridBand18.Name = "gridBand18"
        Me.gridBand18.VisibleIndex = 1
        Me.gridBand18.Width = 344
        '
        'GridColumn84
        '
        Me.GridColumn84.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn84.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn84.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn84.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn84.Caption = "Prev Year"
        Me.GridColumn84.DisplayFormat.FormatString = "N2"
        Me.GridColumn84.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn84.FieldName = "prev_year"
        Me.GridColumn84.Name = "GridColumn84"
        Me.GridColumn84.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prev_month", "{0:N2}")})
        Me.GridColumn84.Visible = True
        Me.GridColumn84.Width = 229
        '
        'BandedGridColumn90
        '
        Me.BandedGridColumn90.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn90.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn90.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn90.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn90.Caption = "% to Total Asset"
        Me.BandedGridColumn90.DisplayFormat.FormatString = "{0:N2} %"
        Me.BandedGridColumn90.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn90.FieldName = "percent_asset_py"
        Me.BandedGridColumn90.Name = "BandedGridColumn90"
        Me.BandedGridColumn90.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_asset_py", "{0:N2} %", "4")})
        Me.BandedGridColumn90.Visible = True
        Me.BandedGridColumn90.Width = 115
        '
        'gridBand19
        '
        Me.gridBand19.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand19.Caption = "Until THis Month"
        Me.gridBand19.Columns.Add(Me.GridColumn83)
        Me.gridBand19.Columns.Add(Me.GridColumn85)
        Me.gridBand19.Name = "gridBand19"
        Me.gridBand19.VisibleIndex = 2
        Me.gridBand19.Width = 404
        '
        'GridColumn83
        '
        Me.GridColumn83.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn83.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn83.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn83.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn83.Caption = "This Month"
        Me.GridColumn83.DisplayFormat.FormatString = "N2"
        Me.GridColumn83.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn83.FieldName = "this_month"
        Me.GridColumn83.Name = "GridColumn83"
        Me.GridColumn83.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "this_month", "{0:N2}")})
        Me.GridColumn83.Visible = True
        Me.GridColumn83.Width = 237
        '
        'GridColumn85
        '
        Me.GridColumn85.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn85.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn85.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn85.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn85.Caption = "% to Total Asset"
        Me.GridColumn85.DisplayFormat.FormatString = "{0:N2} %"
        Me.GridColumn85.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn85.FieldName = "percent_asset_tm"
        Me.GridColumn85.Name = "GridColumn85"
        Me.GridColumn85.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "percent_asset_tm", "{0:N2} %", 2)})
        Me.GridColumn85.Visible = True
        Me.GridColumn85.Width = 167
        '
        'XTPSalesAchievement
        '
        Me.XTPSalesAchievement.Controls.Add(Me.XtraScrollableControl2)
        Me.XTPSalesAchievement.Name = "XTPSalesAchievement"
        Me.XTPSalesAchievement.Size = New System.Drawing.Size(1009, 368)
        Me.XTPSalesAchievement.Text = "Sales Achievement"
        '
        'XtraScrollableControl2
        '
        Me.XtraScrollableControl2.Controls.Add(Me.GroupControl9)
        Me.XtraScrollableControl2.Controls.Add(Me.GroupControl8)
        Me.XtraScrollableControl2.Controls.Add(Me.GroupControl7)
        Me.XtraScrollableControl2.Controls.Add(Me.GroupControl6)
        Me.XtraScrollableControl2.Controls.Add(Me.GroupControl5)
        Me.XtraScrollableControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraScrollableControl2.Location = New System.Drawing.Point(0, 0)
        Me.XtraScrollableControl2.Name = "XtraScrollableControl2"
        Me.XtraScrollableControl2.Size = New System.Drawing.Size(1009, 368)
        Me.XtraScrollableControl2.TabIndex = 0
        '
        'GroupControl9
        '
        Me.GroupControl9.Controls.Add(Me.GCSalVsLastYear)
        Me.GroupControl9.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl9.Location = New System.Drawing.Point(0, 1520)
        Me.GroupControl9.Name = "GroupControl9"
        Me.GroupControl9.Size = New System.Drawing.Size(1009, 380)
        Me.GroupControl9.TabIndex = 4
        Me.GroupControl9.Text = "INCREASE (DECREASE) LAST YEAR"
        '
        'GCSalVsLastYear
        '
        Me.GCSalVsLastYear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalVsLastYear.Location = New System.Drawing.Point(2, 20)
        Me.GCSalVsLastYear.MainView = Me.GVSalVsLastYear
        Me.GCSalVsLastYear.Name = "GCSalVsLastYear"
        Me.GCSalVsLastYear.Size = New System.Drawing.Size(1005, 358)
        Me.GCSalVsLastYear.TabIndex = 4
        Me.GCSalVsLastYear.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalVsLastYear})
        '
        'GVSalVsLastYear
        '
        Me.GVSalVsLastYear.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand28, Me.GridBand29})
        Me.GVSalVsLastYear.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn111, Me.BandedGridColumn112, Me.BandedGridColumn113, Me.BandedGridColumn114})
        Me.GVSalVsLastYear.GridControl = Me.GCSalVsLastYear
        Me.GVSalVsLastYear.Name = "GVSalVsLastYear"
        Me.GVSalVsLastYear.OptionsView.ShowGroupPanel = False
        '
        'GridBand28
        '
        Me.GridBand28.Columns.Add(Me.BandedGridColumn111)
        Me.GridBand28.Columns.Add(Me.BandedGridColumn112)
        Me.GridBand28.Name = "GridBand28"
        Me.GridBand28.VisibleIndex = 0
        Me.GridBand28.Width = 75
        '
        'BandedGridColumn111
        '
        Me.BandedGridColumn111.Caption = "id_month"
        Me.BandedGridColumn111.FieldName = "id_month"
        Me.BandedGridColumn111.Name = "BandedGridColumn111"
        '
        'BandedGridColumn112
        '
        Me.BandedGridColumn112.Caption = "MONTH"
        Me.BandedGridColumn112.FieldName = "month_desc_py"
        Me.BandedGridColumn112.Name = "BandedGridColumn112"
        Me.BandedGridColumn112.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "month_desc", "GRAND TOTAL")})
        Me.BandedGridColumn112.Visible = True
        '
        'GridBand29
        '
        Me.GridBand29.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand29.Caption = "TOTAL"
        Me.GridBand29.Columns.Add(Me.BandedGridColumn113)
        Me.GridBand29.Columns.Add(Me.BandedGridColumn114)
        Me.GridBand29.Name = "GridBand29"
        Me.GridBand29.VisibleIndex = 1
        Me.GridBand29.Width = 150
        '
        'BandedGridColumn113
        '
        Me.BandedGridColumn113.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn113.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn113.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn113.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn113.Caption = "BRUTO (net + vat 10%)"
        Me.BandedGridColumn113.DisplayFormat.FormatString = "{0:N2} %"
        Me.BandedGridColumn113.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn113.FieldName = "bruto_percent_py"
        Me.BandedGridColumn113.Name = "BandedGridColumn113"
        Me.BandedGridColumn113.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bruto", "{0:N2}")})
        Me.BandedGridColumn113.Visible = True
        '
        'BandedGridColumn114
        '
        Me.BandedGridColumn114.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn114.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn114.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn114.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn114.Caption = "NETT"
        Me.BandedGridColumn114.DisplayFormat.FormatString = "{0:N2} %"
        Me.BandedGridColumn114.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn114.FieldName = "nett_percent_py"
        Me.BandedGridColumn114.Name = "BandedGridColumn114"
        Me.BandedGridColumn114.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nett", "{0:N2}")})
        Me.BandedGridColumn114.Visible = True
        '
        'GroupControl8
        '
        Me.GroupControl8.Controls.Add(Me.GCSalLastYear)
        Me.GroupControl8.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl8.Location = New System.Drawing.Point(0, 1140)
        Me.GroupControl8.Name = "GroupControl8"
        Me.GroupControl8.Size = New System.Drawing.Size(1009, 380)
        Me.GroupControl8.TabIndex = 3
        Me.GroupControl8.Text = "SALES REALIZATION LAST YEAR"
        '
        'GCSalLastYear
        '
        Me.GCSalLastYear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalLastYear.Location = New System.Drawing.Point(2, 20)
        Me.GCSalLastYear.MainView = Me.GVSalLastYear
        Me.GCSalLastYear.Name = "GCSalLastYear"
        Me.GCSalLastYear.Size = New System.Drawing.Size(1005, 358)
        Me.GCSalLastYear.TabIndex = 3
        Me.GCSalLastYear.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalLastYear})
        '
        'GVSalLastYear
        '
        Me.GVSalLastYear.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand26, Me.GridBand27})
        Me.GVSalLastYear.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn107, Me.BandedGridColumn108, Me.BandedGridColumn109, Me.BandedGridColumn110})
        Me.GVSalLastYear.GridControl = Me.GCSalLastYear
        Me.GVSalLastYear.Name = "GVSalLastYear"
        Me.GVSalLastYear.OptionsView.ShowGroupPanel = False
        '
        'GridBand26
        '
        Me.GridBand26.Columns.Add(Me.BandedGridColumn107)
        Me.GridBand26.Columns.Add(Me.BandedGridColumn108)
        Me.GridBand26.Name = "GridBand26"
        Me.GridBand26.VisibleIndex = 0
        Me.GridBand26.Width = 75
        '
        'BandedGridColumn107
        '
        Me.BandedGridColumn107.Caption = "id_month"
        Me.BandedGridColumn107.FieldName = "id_month"
        Me.BandedGridColumn107.Name = "BandedGridColumn107"
        '
        'BandedGridColumn108
        '
        Me.BandedGridColumn108.Caption = "MONTH"
        Me.BandedGridColumn108.FieldName = "month_desc_py"
        Me.BandedGridColumn108.Name = "BandedGridColumn108"
        Me.BandedGridColumn108.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "month_desc", "GRAND TOTAL")})
        Me.BandedGridColumn108.Visible = True
        '
        'GridBand27
        '
        Me.GridBand27.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand27.Caption = "TOTAL"
        Me.GridBand27.Columns.Add(Me.BandedGridColumn109)
        Me.GridBand27.Columns.Add(Me.BandedGridColumn110)
        Me.GridBand27.Name = "GridBand27"
        Me.GridBand27.VisibleIndex = 1
        Me.GridBand27.Width = 150
        '
        'BandedGridColumn109
        '
        Me.BandedGridColumn109.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn109.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn109.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn109.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn109.Caption = "BRUTO (net + vat 10%)"
        Me.BandedGridColumn109.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn109.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn109.FieldName = "bruto_py"
        Me.BandedGridColumn109.Name = "BandedGridColumn109"
        Me.BandedGridColumn109.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bruto", "{0:N2}")})
        Me.BandedGridColumn109.Visible = True
        '
        'BandedGridColumn110
        '
        Me.BandedGridColumn110.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn110.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn110.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn110.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn110.Caption = "NETT"
        Me.BandedGridColumn110.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn110.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn110.FieldName = "nett_py"
        Me.BandedGridColumn110.Name = "BandedGridColumn110"
        Me.BandedGridColumn110.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nett", "{0:N2}")})
        Me.BandedGridColumn110.Visible = True
        '
        'GroupControl7
        '
        Me.GroupControl7.Controls.Add(Me.GCOverUnderTarget)
        Me.GroupControl7.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl7.Location = New System.Drawing.Point(0, 760)
        Me.GroupControl7.Name = "GroupControl7"
        Me.GroupControl7.Size = New System.Drawing.Size(1009, 380)
        Me.GroupControl7.TabIndex = 2
        Me.GroupControl7.Text = "OVER (UNDER) ON TARGET"
        '
        'GCOverUnderTarget
        '
        Me.GCOverUnderTarget.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOverUnderTarget.Location = New System.Drawing.Point(2, 20)
        Me.GCOverUnderTarget.MainView = Me.GVOverUnderTarget
        Me.GCOverUnderTarget.Name = "GCOverUnderTarget"
        Me.GCOverUnderTarget.Size = New System.Drawing.Size(1005, 358)
        Me.GCOverUnderTarget.TabIndex = 2
        Me.GCOverUnderTarget.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOverUnderTarget})
        '
        'GVOverUnderTarget
        '
        Me.GVOverUnderTarget.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand24, Me.GridBand25})
        Me.GVOverUnderTarget.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn103, Me.BandedGridColumn104, Me.BandedGridColumn105, Me.BandedGridColumn106})
        Me.GVOverUnderTarget.GridControl = Me.GCOverUnderTarget
        Me.GVOverUnderTarget.Name = "GVOverUnderTarget"
        Me.GVOverUnderTarget.OptionsView.ShowGroupPanel = False
        '
        'GridBand24
        '
        Me.GridBand24.Columns.Add(Me.BandedGridColumn103)
        Me.GridBand24.Columns.Add(Me.BandedGridColumn104)
        Me.GridBand24.Name = "GridBand24"
        Me.GridBand24.VisibleIndex = 0
        Me.GridBand24.Width = 75
        '
        'BandedGridColumn103
        '
        Me.BandedGridColumn103.Caption = "id_month"
        Me.BandedGridColumn103.FieldName = "id_month"
        Me.BandedGridColumn103.Name = "BandedGridColumn103"
        '
        'BandedGridColumn104
        '
        Me.BandedGridColumn104.Caption = "MONTH"
        Me.BandedGridColumn104.FieldName = "month_desc"
        Me.BandedGridColumn104.Name = "BandedGridColumn104"
        Me.BandedGridColumn104.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "month_desc", "GRAND TOTAL")})
        Me.BandedGridColumn104.Visible = True
        '
        'GridBand25
        '
        Me.GridBand25.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand25.Caption = "TOTAL"
        Me.GridBand25.Columns.Add(Me.BandedGridColumn105)
        Me.GridBand25.Columns.Add(Me.BandedGridColumn106)
        Me.GridBand25.Name = "GridBand25"
        Me.GridBand25.VisibleIndex = 1
        Me.GridBand25.Width = 150
        '
        'BandedGridColumn105
        '
        Me.BandedGridColumn105.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn105.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn105.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn105.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn105.Caption = "BRUTO (net + vat 10%)"
        Me.BandedGridColumn105.DisplayFormat.FormatString = "{0:N2} %"
        Me.BandedGridColumn105.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn105.FieldName = "bruto_percent_target"
        Me.BandedGridColumn105.Name = "BandedGridColumn105"
        Me.BandedGridColumn105.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bruto", "{0:N2}")})
        Me.BandedGridColumn105.Visible = True
        '
        'BandedGridColumn106
        '
        Me.BandedGridColumn106.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn106.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn106.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn106.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn106.Caption = "NETT"
        Me.BandedGridColumn106.DisplayFormat.FormatString = "{0:N2} %"
        Me.BandedGridColumn106.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn106.FieldName = "nett_percent_target"
        Me.BandedGridColumn106.Name = "BandedGridColumn106"
        Me.BandedGridColumn106.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nett", "{0:N2}")})
        Me.BandedGridColumn106.Visible = True
        '
        'GroupControl6
        '
        Me.GroupControl6.Controls.Add(Me.GCSalesRealization)
        Me.GroupControl6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl6.Location = New System.Drawing.Point(0, 380)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(1009, 380)
        Me.GroupControl6.TabIndex = 1
        Me.GroupControl6.Text = "SALES REALIZATION"
        '
        'GCSalesRealization
        '
        Me.GCSalesRealization.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesRealization.Location = New System.Drawing.Point(2, 20)
        Me.GCSalesRealization.MainView = Me.GVSalesRealization
        Me.GCSalesRealization.Name = "GCSalesRealization"
        Me.GCSalesRealization.Size = New System.Drawing.Size(1005, 358)
        Me.GCSalesRealization.TabIndex = 1
        Me.GCSalesRealization.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesRealization})
        '
        'GVSalesRealization
        '
        Me.GVSalesRealization.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand22, Me.GridBand23})
        Me.GVSalesRealization.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn99, Me.BandedGridColumn100, Me.BandedGridColumn101, Me.BandedGridColumn102})
        Me.GVSalesRealization.GridControl = Me.GCSalesRealization
        Me.GVSalesRealization.Name = "GVSalesRealization"
        Me.GVSalesRealization.OptionsView.ShowGroupPanel = False
        '
        'GridBand22
        '
        Me.GridBand22.Columns.Add(Me.BandedGridColumn99)
        Me.GridBand22.Columns.Add(Me.BandedGridColumn100)
        Me.GridBand22.Name = "GridBand22"
        Me.GridBand22.VisibleIndex = 0
        Me.GridBand22.Width = 75
        '
        'BandedGridColumn99
        '
        Me.BandedGridColumn99.Caption = "id_month"
        Me.BandedGridColumn99.FieldName = "id_month"
        Me.BandedGridColumn99.Name = "BandedGridColumn99"
        '
        'BandedGridColumn100
        '
        Me.BandedGridColumn100.Caption = "MONTH"
        Me.BandedGridColumn100.FieldName = "month_desc"
        Me.BandedGridColumn100.Name = "BandedGridColumn100"
        Me.BandedGridColumn100.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "month_desc", "GRAND TOTAL")})
        Me.BandedGridColumn100.Visible = True
        '
        'GridBand23
        '
        Me.GridBand23.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand23.Caption = "TOTAL"
        Me.GridBand23.Columns.Add(Me.BandedGridColumn101)
        Me.GridBand23.Columns.Add(Me.BandedGridColumn102)
        Me.GridBand23.Name = "GridBand23"
        Me.GridBand23.VisibleIndex = 1
        Me.GridBand23.Width = 150
        '
        'BandedGridColumn101
        '
        Me.BandedGridColumn101.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn101.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn101.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn101.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn101.Caption = "BRUTO (net + vat 10%)"
        Me.BandedGridColumn101.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn101.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn101.FieldName = "bruto_ty"
        Me.BandedGridColumn101.Name = "BandedGridColumn101"
        Me.BandedGridColumn101.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bruto", "{0:N2}")})
        Me.BandedGridColumn101.Visible = True
        '
        'BandedGridColumn102
        '
        Me.BandedGridColumn102.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn102.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn102.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn102.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn102.Caption = "NETT"
        Me.BandedGridColumn102.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn102.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn102.FieldName = "nett_ty"
        Me.BandedGridColumn102.Name = "BandedGridColumn102"
        Me.BandedGridColumn102.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nett", "{0:N2}")})
        Me.BandedGridColumn102.Visible = True
        '
        'GroupControl5
        '
        Me.GroupControl5.Controls.Add(Me.GCMTargetUSA)
        Me.GroupControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl5.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(1009, 380)
        Me.GroupControl5.TabIndex = 0
        Me.GroupControl5.Text = "MINIMUM SALES TARGET USA"
        '
        'GCMTargetUSA
        '
        Me.GCMTargetUSA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMTargetUSA.Location = New System.Drawing.Point(2, 20)
        Me.GCMTargetUSA.MainView = Me.GVMTargetUSA
        Me.GCMTargetUSA.Name = "GCMTargetUSA"
        Me.GCMTargetUSA.Size = New System.Drawing.Size(1005, 358)
        Me.GCMTargetUSA.TabIndex = 0
        Me.GCMTargetUSA.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMTargetUSA})
        '
        'GVMTargetUSA
        '
        Me.GVMTargetUSA.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand20, Me.gridBand21})
        Me.GVMTargetUSA.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn86, Me.GridColumn87, Me.GridColumn88, Me.GridColumn89})
        Me.GVMTargetUSA.GridControl = Me.GCMTargetUSA
        Me.GVMTargetUSA.Name = "GVMTargetUSA"
        Me.GVMTargetUSA.OptionsView.ShowGroupPanel = False
        '
        'GridBand20
        '
        Me.GridBand20.Columns.Add(Me.GridColumn86)
        Me.GridBand20.Columns.Add(Me.GridColumn87)
        Me.GridBand20.Name = "GridBand20"
        Me.GridBand20.VisibleIndex = 0
        Me.GridBand20.Width = 75
        '
        'GridColumn86
        '
        Me.GridColumn86.Caption = "id_month"
        Me.GridColumn86.FieldName = "id_month"
        Me.GridColumn86.Name = "GridColumn86"
        '
        'GridColumn87
        '
        Me.GridColumn87.Caption = "MONTH"
        Me.GridColumn87.FieldName = "month_desc"
        Me.GridColumn87.Name = "GridColumn87"
        Me.GridColumn87.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "month", "GRAND TOTAL")})
        Me.GridColumn87.Visible = True
        '
        'gridBand21
        '
        Me.gridBand21.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand21.Caption = "TOTAL"
        Me.gridBand21.Columns.Add(Me.GridColumn88)
        Me.gridBand21.Columns.Add(Me.GridColumn89)
        Me.gridBand21.Name = "gridBand21"
        Me.gridBand21.VisibleIndex = 1
        Me.gridBand21.Width = 150
        '
        'GridColumn88
        '
        Me.GridColumn88.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn88.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn88.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn88.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn88.Caption = "BRUTO (net + vat 10%)"
        Me.GridColumn88.DisplayFormat.FormatString = "N2"
        Me.GridColumn88.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn88.FieldName = "bruto_target"
        Me.GridColumn88.Name = "GridColumn88"
        Me.GridColumn88.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bruto", "{0:N2}")})
        Me.GridColumn88.Visible = True
        '
        'GridColumn89
        '
        Me.GridColumn89.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn89.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn89.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn89.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn89.Caption = "NETT"
        Me.GridColumn89.DisplayFormat.FormatString = "N2"
        Me.GridColumn89.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn89.FieldName = "nett_target"
        Me.GridColumn89.Name = "GridColumn89"
        Me.GridColumn89.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nett", "{0:N2}")})
        Me.GridColumn89.Visible = True
        '
        'PCFilterMonthly
        '
        Me.PCFilterMonthly.Controls.Add(Me.SimpleButton1)
        Me.PCFilterMonthly.Controls.Add(Me.BPrintMonthlyReport)
        Me.PCFilterMonthly.Controls.Add(Me.BViewMonthlyReport)
        Me.PCFilterMonthly.Controls.Add(Me.LabelControl8)
        Me.PCFilterMonthly.Controls.Add(Me.DEMonthlyReport)
        Me.PCFilterMonthly.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCFilterMonthly.Location = New System.Drawing.Point(0, 0)
        Me.PCFilterMonthly.Name = "PCFilterMonthly"
        Me.PCFilterMonthly.Size = New System.Drawing.Size(1015, 48)
        Me.PCFilterMonthly.TabIndex = 1
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(356, 13)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(76, 23)
        Me.SimpleButton1.TabIndex = 7
        Me.SimpleButton1.Text = "print all (eng)"
        '
        'BPrintMonthlyReport
        '
        Me.BPrintMonthlyReport.Location = New System.Drawing.Point(274, 13)
        Me.BPrintMonthlyReport.Name = "BPrintMonthlyReport"
        Me.BPrintMonthlyReport.Size = New System.Drawing.Size(76, 23)
        Me.BPrintMonthlyReport.TabIndex = 6
        Me.BPrintMonthlyReport.Text = "print (eng)"
        '
        'BViewMonthlyReport
        '
        Me.BViewMonthlyReport.Location = New System.Drawing.Point(218, 13)
        Me.BViewMonthlyReport.Name = "BViewMonthlyReport"
        Me.BViewMonthlyReport.Size = New System.Drawing.Size(50, 23)
        Me.BViewMonthlyReport.TabIndex = 3
        Me.BViewMonthlyReport.Text = "view"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(10, 18)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl8.TabIndex = 2
        Me.LabelControl8.Text = "Date"
        '
        'DEMonthlyReport
        '
        Me.DEMonthlyReport.EditValue = Nothing
        Me.DEMonthlyReport.Location = New System.Drawing.Point(39, 15)
        Me.DEMonthlyReport.Name = "DEMonthlyReport"
        Me.DEMonthlyReport.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEMonthlyReport.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEMonthlyReport.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEMonthlyReport.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEMonthlyReport.Size = New System.Drawing.Size(173, 20)
        Me.DEMonthlyReport.TabIndex = 1
        '
        'FormReportBalanceSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 520)
        Me.Controls.Add(Me.XTCBalanceSheet)
        Me.Controls.Add(Me.PCFilterUpper)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportBalanceSheet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Accounting Report"
        CType(Me.PCFilterUpper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCFilterUpper.ResumeLayout(False)
        Me.PCFilterUpper.PerformLayout()
        CType(Me.SLEUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLBalanceSheet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCBalanceSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCBalanceSheet.ResumeLayout(False)
        Me.XTPGeneralLedger.ResumeLayout(False)
        CType(Me.TLLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPBalanceSheet.ResumeLayout(False)
        CType(Me.XTCBS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCBS.ResumeLayout(False)
        Me.XTPBSLedger.ResumeLayout(False)
        Me.XTPBSReport.ResumeLayout(False)
        CType(Me.SplitterBS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitterBS.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCAktiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAktiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCPasiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPasiva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPProfitAndLoss.ResumeLayout(False)
        CType(Me.XTCProfitAndLoss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCProfitAndLoss.ResumeLayout(False)
        Me.XTPPATreeView.ResumeLayout(False)
        CType(Me.TLProfitAndLoss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPLReportView.ResumeLayout(False)
        CType(Me.GCProfitAndLoss, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProfitAndLoss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPajak.ResumeLayout(False)
        CType(Me.XTPTaxDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPTaxDetail.ResumeLayout(False)
        Me.XTPPendingLapor.ResumeLayout(False)
        CType(Me.GCTaxReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVTaxReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICETaxReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPendingTransaction.ResumeLayout(False)
        CType(Me.GCTaxPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVTaxPending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPLapor.ResumeLayout(False)
        CType(Me.GCActiveTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVActiveTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEActiveTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.CESelAllActiveTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCPajak, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCPajak.ResumeLayout(False)
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.DETaxFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETaxFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLETaxCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLETaxTagCOA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETaxUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETaxUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMonthlyReport.ResumeLayout(False)
        CType(Me.XTCMonthlyReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCMonthlyReport.ResumeLayout(False)
        Me.XTPMBS.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GCMAktiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMAktiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        CType(Me.GCMPasiva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMPasiva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMProfitLoss.ResumeLayout(False)
        CType(Me.GCMProfitLoss, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMProfitLoss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMBSvsMonth.ResumeLayout(False)
        CType(Me.GCMBSvsPrevMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMBSvsPrevMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMPLvsMonth.ResumeLayout(False)
        CType(Me.GCMPLvsPrevMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMPLvsPrevMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMPLvsYear.ResumeLayout(False)
        CType(Me.GCMPLvsPrevYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMPLvsPrevYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMPLvsYTD.ResumeLayout(False)
        CType(Me.GCMPLvsYTD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMPLvsYTD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMPBSvsPrevYear.ResumeLayout(False)
        CType(Me.GCMBSvsPrevYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMBSvsPrevYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSalesAchievement.ResumeLayout(False)
        Me.XtraScrollableControl2.ResumeLayout(False)
        CType(Me.GroupControl9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl9.ResumeLayout(False)
        CType(Me.GCSalVsLastYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalVsLastYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl8.ResumeLayout(False)
        CType(Me.GCSalLastYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalLastYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl7.ResumeLayout(False)
        CType(Me.GCOverUnderTarget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOverUnderTarget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        CType(Me.GCSalesRealization, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesRealization, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl5.ResumeLayout(False)
        CType(Me.GCMTargetUSA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMTargetUSA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCFilterMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCFilterMonthly.ResumeLayout(False)
        Me.PCFilterMonthly.PerformLayout()
        CType(Me.DEMonthlyReport.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEMonthlyReport.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PCFilterUpper As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TLBalanceSheet As DevExpress.XtraTreeList.TreeList
    Friend WithEvents XTCBalanceSheet As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPGeneralLedger As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPBalanceSheet As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents treeListBand1 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLAccount As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLDescription As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand2 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLPrevMonth As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLThisMonth As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCIDAcc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCIDAccParent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TLLedger As DevExpress.XtraTreeList.TreeList
    Friend WithEvents treeListBand5 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLAccName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLAccDescription As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand6 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCLedDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLedCredit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLIDAcc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLIdAccParent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLedIDAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand3 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents treeListBand4 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEUnit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPProfitAndLoss As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTCBS As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBSLedger As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPBSReport As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCProfitAndLoss As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPATreeView As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPLReportView As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TLProfitAndLoss As DevExpress.XtraTreeList.TreeList
    Friend WithEvents treeListBand7 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCPLAccount As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLDescription As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents treeListBand8 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents TCPLPrevMonth As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLThisMonth As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLIdAcc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLIdAccParent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLIdAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents SplitterBS As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GCAktiva As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAktiva As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPrevMonth As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnThisMonth As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCPasiva As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPasiva As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn16 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn17 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn18 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TCLDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCLCredit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TCPLCredit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents GCProfitAndLoss As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProfitAndLoss As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn19 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn20 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn21 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn28 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn22 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn27 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnYTD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn29 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn23 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn24 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn25 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPPajak As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PCPajak As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DETaxUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BPrintPajak As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BViewPajak As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DETaxFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GCTaxReport As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTaxReport As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPTaxDetail As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPendingLapor As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPPNPPH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTarif As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDPP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAlamatNPWP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLETaxTagCOA As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLETaxCat As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents ViewDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewJournalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumnTaxCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPPendingTransaction As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCTaxPending As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTaxPending As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPLapor As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICETaxReport As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GCActiveTax As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVActiveTax As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnActiveTaxCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BReported As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BMoveActiveTax As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CESelAllActiveTax As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEActiveTax As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents SBSummary As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraScrollableControl1 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents SBSetup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSummaryPpn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPMonthlyReport As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTCMonthlyReport As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPMBS As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPMProfitLoss As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PCFilterMonthly As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPrintMonthlyReport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BViewMonthlyReport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEMonthlyReport As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCMAktiva As DevExpress.XtraGrid.GridControl
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GVMAktiva As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BandedGridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnPercentage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCMPasiva As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMPasiva As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCMProfitLoss As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMProfitLoss As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn38 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn39 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn40 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn41 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn42 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn43 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn44 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnMISPercent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn46 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn47 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn48 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn49 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn50 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn45 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn51 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents XTPMBSvsMonth As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMBSvsPrevMonth As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMBSvsPrevMonth As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn67 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn68 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn69 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn70 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn71 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn72 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPMPLvsMonth As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMPLvsPrevMonth As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMPLvsPrevMonth As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn52 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn53 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn54 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn55 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn56 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand10 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn57 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn58 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn59 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn60 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn61 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn62 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn63 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn64 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn65 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn66 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn73 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn74 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn75 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPMPLvsYear As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMPLvsPrevYear As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMPLvsPrevYear As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn67 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn68 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn69 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn70 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn71 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn72 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn73 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn74 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn75 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn76 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn77 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn78 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn79 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn80 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn81 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents XTPMPLvsYTD As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPMPBSvsPrevYear As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridBand11 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBandPrevYear As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnVsYearPrev As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandThisYear As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnVsYearThisMonth As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand14 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GCMPLvsYTD As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMPLvsYTD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand12 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn82 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn83 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn84 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn85 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn86 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand13 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn87 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn88 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn89 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn91 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand15 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn92 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn93 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand16 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn94 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn95 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn96 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn97 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn98 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCMBSvsPrevYear As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMBSvsPrevYear As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand17 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn76 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn77 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn78 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn79 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn80 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn81 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn82 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand18 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn84 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn90 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand19 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn83 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn85 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPSalesAchievement As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraScrollableControl2 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents GroupControl9 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl8 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl7 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCMTargetUSA As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMTargetUSA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand20 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn86 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn87 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand21 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn88 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn89 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSalesRealization As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesRealization As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand22 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn99 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn100 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand23 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn101 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn102 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCOverUnderTarget As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOverUnderTarget As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand24 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn103 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn104 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand25 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn105 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn106 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSalVsLastYear As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalVsLastYear As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand28 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn111 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn112 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand29 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn113 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn114 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSalLastYear As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalLastYear As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand26 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn107 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn108 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand27 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn109 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn110 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
