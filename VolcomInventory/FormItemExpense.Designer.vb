<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemExpense
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormItemExpense))
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DuplicateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedByName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReortStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPaidStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBeneficiary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.SLEUnit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEBBKTo = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.DEBBKFrom = New DevExpress.XtraEditors.DateEdit()
        Me.BViewPayment = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBankWithdrawal = New DevExpress.XtraEditors.SimpleButton()
        Me.XTCExpense = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPExpense = New DevExpress.XtraTab.XtraTabPage()
        Me.XTP3PLInv = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInvoice = New DevExpress.XtraGrid.GridControl()
        Me.GVInvoice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TEDesc3PLInv = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPPH3PLInv = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPPN3PLInv = New DevExpress.XtraEditors.TextEdit()
        Me.SLEPPH3PLInv = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BImport = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPSNI = New DevExpress.XtraTab.XtraTabPage()
        Me.GCListSNI = New DevExpress.XtraGrid.GridControl()
        Me.GVListSNI = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BrefreshSNI = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPRider = New DevExpress.XtraTab.XtraTabPage()
        Me.GCContractList = New DevExpress.XtraGrid.GridControl()
        Me.GVContractList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICE = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.BViewEndorsee = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.DEContract = New DevExpress.XtraEditors.DateEdit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.SLEUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEBBKTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEBBKTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEBBKFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEBBKFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCExpense, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCExpense.SuspendLayout()
        Me.XTPExpense.SuspendLayout()
        Me.XTP3PLInv.SuspendLayout()
        CType(Me.GCInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEDesc3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPPN3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.XTPSNI.SuspendLayout()
        CType(Me.GCListSNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListSNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.XTPRider.SuspendLayout()
        CType(Me.GCContractList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVContractList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.DEContract.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEContract.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 46)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GCData.Size = New System.Drawing.Size(1006, 482)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DuplicateToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 26)
        '
        'DuplicateToolStripMenuItem
        '
        Me.DuplicateToolStripMenuItem.Name = "DuplicateToolStripMenuItem"
        Me.DuplicateToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.DuplicateToolStripMenuItem.Text = "Duplicate"
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnId, Me.GridColumnNumber, Me.GridColumnCreatedDate, Me.GridColumnCreatedByName, Me.GridColumnReortStt, Me.GridColumnPaidStt, Me.GridColumnBal, Me.GridColumntotal, Me.GridColumnIdComp, Me.GridColumnBeneficiary})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Unit"
        Me.GridColumn1.FieldName = "tag_description"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 96
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_item_expense"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 1
        Me.GridColumnNumber.Width = 83
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "created_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 3
        Me.GridColumnCreatedDate.Width = 83
        '
        'GridColumnCreatedByName
        '
        Me.GridColumnCreatedByName.Caption = "Created by"
        Me.GridColumnCreatedByName.FieldName = "created_by_name"
        Me.GridColumnCreatedByName.Name = "GridColumnCreatedByName"
        Me.GridColumnCreatedByName.Visible = True
        Me.GridColumnCreatedByName.VisibleIndex = 4
        Me.GridColumnCreatedByName.Width = 83
        '
        'GridColumnReortStt
        '
        Me.GridColumnReortStt.Caption = "Approval Status"
        Me.GridColumnReortStt.FieldName = "report_status"
        Me.GridColumnReortStt.Name = "GridColumnReortStt"
        Me.GridColumnReortStt.Visible = True
        Me.GridColumnReortStt.VisibleIndex = 5
        Me.GridColumnReortStt.Width = 83
        '
        'GridColumnPaidStt
        '
        Me.GridColumnPaidStt.Caption = "Payment Status"
        Me.GridColumnPaidStt.FieldName = "paid_status"
        Me.GridColumnPaidStt.Name = "GridColumnPaidStt"
        Me.GridColumnPaidStt.Visible = True
        Me.GridColumnPaidStt.VisibleIndex = 6
        Me.GridColumnPaidStt.Width = 83
        '
        'GridColumnBal
        '
        Me.GridColumnBal.Caption = "Balance Due"
        Me.GridColumnBal.DisplayFormat.FormatString = "N2"
        Me.GridColumnBal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBal.FieldName = "balance"
        Me.GridColumnBal.Name = "GridColumnBal"
        Me.GridColumnBal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", "{0:N2}")})
        Me.GridColumnBal.Visible = True
        Me.GridColumnBal.VisibleIndex = 7
        Me.GridColumnBal.Width = 83
        '
        'GridColumntotal
        '
        Me.GridColumntotal.Caption = "Total"
        Me.GridColumntotal.DisplayFormat.FormatString = "N2"
        Me.GridColumntotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal.FieldName = "total"
        Me.GridColumntotal.Name = "GridColumntotal"
        Me.GridColumntotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumntotal.Visible = True
        Me.GridColumntotal.VisibleIndex = 8
        Me.GridColumntotal.Width = 88
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "Id Comp"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        '
        'GridColumnBeneficiary
        '
        Me.GridColumnBeneficiary.Caption = "Vendor"
        Me.GridColumnBeneficiary.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnBeneficiary.FieldName = "comp"
        Me.GridColumnBeneficiary.Name = "GridColumnBeneficiary"
        Me.GridColumnBeneficiary.Visible = True
        Me.GridColumnBeneficiary.VisibleIndex = 2
        Me.GridColumnBeneficiary.Width = 83
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.SLEUnit)
        Me.PanelControlNav.Controls.Add(Me.DEBBKTo)
        Me.PanelControlNav.Controls.Add(Me.LabelControl19)
        Me.PanelControlNav.Controls.Add(Me.LabelControl18)
        Me.PanelControlNav.Controls.Add(Me.DEBBKFrom)
        Me.PanelControlNav.Controls.Add(Me.BViewPayment)
        Me.PanelControlNav.Controls.Add(Me.BtnBankWithdrawal)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(1006, 46)
        Me.PanelControlNav.TabIndex = 1
        '
        'SLEUnit
        '
        Me.SLEUnit.Location = New System.Drawing.Point(388, 13)
        Me.SLEUnit.Name = "SLEUnit"
        Me.SLEUnit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEUnit.Properties.View = Me.GridView6
        Me.SLEUnit.Size = New System.Drawing.Size(154, 20)
        Me.SLEUnit.TabIndex = 8931
        '
        'GridView6
        '
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn25, Me.GridColumn26, Me.GridColumn27})
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "id_coa_tag"
        Me.GridColumn25.FieldName = "id_comp"
        Me.GridColumn25.Name = "GridColumn25"
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn26.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn26.Caption = "Number"
        Me.GridColumn26.FieldName = "tag_code"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 0
        Me.GridColumn26.Width = 281
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Unit"
        Me.GridColumn27.FieldName = "tag_description"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 1
        Me.GridColumn27.Width = 1351
        '
        'DEBBKTo
        '
        Me.DEBBKTo.EditValue = Nothing
        Me.DEBBKTo.Location = New System.Drawing.Point(224, 13)
        Me.DEBBKTo.Name = "DEBBKTo"
        Me.DEBBKTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEBBKTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEBBKTo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEBBKTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEBBKTo.Size = New System.Drawing.Size(158, 20)
        Me.DEBBKTo.TabIndex = 8930
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(206, 16)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl19.TabIndex = 8929
        Me.LabelControl19.Text = "To"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl18.TabIndex = 8928
        Me.LabelControl18.Text = "From"
        '
        'DEBBKFrom
        '
        Me.DEBBKFrom.EditValue = Nothing
        Me.DEBBKFrom.Location = New System.Drawing.Point(42, 13)
        Me.DEBBKFrom.Name = "DEBBKFrom"
        Me.DEBBKFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEBBKFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEBBKFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEBBKFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEBBKFrom.Size = New System.Drawing.Size(158, 20)
        Me.DEBBKFrom.TabIndex = 8927
        '
        'BViewPayment
        '
        Me.BViewPayment.Location = New System.Drawing.Point(548, 11)
        Me.BViewPayment.Name = "BViewPayment"
        Me.BViewPayment.Size = New System.Drawing.Size(60, 23)
        Me.BViewPayment.TabIndex = 8926
        Me.BViewPayment.Text = "view"
        '
        'BtnBankWithdrawal
        '
        Me.BtnBankWithdrawal.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnBankWithdrawal.Image = CType(resources.GetObject("BtnBankWithdrawal.Image"), System.Drawing.Image)
        Me.BtnBankWithdrawal.Location = New System.Drawing.Point(874, 2)
        Me.BtnBankWithdrawal.Name = "BtnBankWithdrawal"
        Me.BtnBankWithdrawal.Size = New System.Drawing.Size(130, 42)
        Me.BtnBankWithdrawal.TabIndex = 0
        Me.BtnBankWithdrawal.Text = "Bank Withdrawal"
        Me.BtnBankWithdrawal.Visible = False
        '
        'XTCExpense
        '
        Me.XTCExpense.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCExpense.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCExpense.Location = New System.Drawing.Point(0, 0)
        Me.XTCExpense.Name = "XTCExpense"
        Me.XTCExpense.SelectedTabPage = Me.XTPExpense
        Me.XTCExpense.Size = New System.Drawing.Size(1012, 556)
        Me.XTCExpense.TabIndex = 2
        Me.XTCExpense.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPExpense, Me.XTP3PLInv, Me.XTPSNI, Me.XTPRider})
        '
        'XTPExpense
        '
        Me.XTPExpense.Controls.Add(Me.GCData)
        Me.XTPExpense.Controls.Add(Me.PanelControlNav)
        Me.XTPExpense.Name = "XTPExpense"
        Me.XTPExpense.Size = New System.Drawing.Size(1006, 528)
        Me.XTPExpense.Text = "Expense List"
        '
        'XTP3PLInv
        '
        Me.XTP3PLInv.Controls.Add(Me.GCInvoice)
        Me.XTP3PLInv.Controls.Add(Me.PanelControl2)
        Me.XTP3PLInv.Controls.Add(Me.BImport)
        Me.XTP3PLInv.Controls.Add(Me.PanelControl1)
        Me.XTP3PLInv.Name = "XTP3PLInv"
        Me.XTP3PLInv.Size = New System.Drawing.Size(1006, 528)
        Me.XTP3PLInv.Text = "3PL Invoice"
        '
        'GCInvoice
        '
        Me.GCInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoice.Location = New System.Drawing.Point(0, 48)
        Me.GCInvoice.MainView = Me.GVInvoice
        Me.GCInvoice.Name = "GCInvoice"
        Me.GCInvoice.Size = New System.Drawing.Size(1006, 403)
        Me.GCInvoice.TabIndex = 4
        Me.GCInvoice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoice})
        '
        'GVInvoice
        '
        Me.GVInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn39, Me.GridColumn47, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn2})
        Me.GVInvoice.GridControl = Me.GCInvoice
        Me.GVInvoice.Name = "GVInvoice"
        Me.GVInvoice.OptionsBehavior.Editable = False
        Me.GVInvoice.OptionsBehavior.ReadOnly = True
        Me.GVInvoice.OptionsFind.AlwaysVisible = True
        Me.GVInvoice.OptionsView.ShowGroupPanel = False
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "ID Ivn AWB"
        Me.GridColumn39.FieldName = "id_awb_inv_sum"
        Me.GridColumn39.Name = "GridColumn39"
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "3PL"
        Me.GridColumn47.FieldName = "comp_name"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 0
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Invoice Number"
        Me.GridColumn40.FieldName = "inv_number"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 1
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Created By"
        Me.GridColumn41.FieldName = "employee_name"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 2
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Created Date"
        Me.GridColumn42.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn42.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn42.FieldName = "created_date"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 3
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Report Status"
        Me.GridColumn43.FieldName = "report_status"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 4
        '
        'GridColumn44
        '
        Me.GridColumn44.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn44.Caption = "(Volcom) Total Invoice"
        Me.GridColumn44.DisplayFormat.FormatString = "N2"
        Me.GridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn44.FieldName = "c_tot"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 5
        '
        'GridColumn45
        '
        Me.GridColumn45.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn45.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn45.Caption = "(Cargo) Total Invoice"
        Me.GridColumn45.DisplayFormat.FormatString = "N2"
        Me.GridColumn45.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn45.FieldName = "a_tot"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 6
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "(Final) Total Invoice"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "final_tot"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 7
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TEDesc3PLInv)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.TEPPH3PLInv)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.TEPPN3PLInv)
        Me.PanelControl2.Controls.Add(Me.SLEPPH3PLInv)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 451)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1006, 43)
        Me.PanelControl2.TabIndex = 92
        Me.PanelControl2.Visible = False
        '
        'TEDesc3PLInv
        '
        Me.TEDesc3PLInv.Location = New System.Drawing.Point(740, 14)
        Me.TEDesc3PLInv.Name = "TEDesc3PLInv"
        Me.TEDesc3PLInv.Size = New System.Drawing.Size(259, 20)
        Me.TEDesc3PLInv.TabIndex = 7
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(681, 17)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Description"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(397, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "PPH Account"
        '
        'TEPPH3PLInv
        '
        Me.TEPPH3PLInv.Location = New System.Drawing.Point(248, 14)
        Me.TEPPH3PLInv.Name = "TEPPH3PLInv"
        Me.TEPPH3PLInv.Properties.Mask.EditMask = "N2"
        Me.TEPPH3PLInv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPPH3PLInv.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPPH3PLInv.Size = New System.Drawing.Size(143, 20)
        Me.TEPPH3PLInv.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(201, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "PPH (%)"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "PPN (%)"
        '
        'TEPPN3PLInv
        '
        Me.TEPPN3PLInv.Location = New System.Drawing.Point(58, 14)
        Me.TEPPN3PLInv.Name = "TEPPN3PLInv"
        Me.TEPPN3PLInv.Properties.Mask.EditMask = "N2"
        Me.TEPPN3PLInv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPPN3PLInv.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPPN3PLInv.Size = New System.Drawing.Size(137, 20)
        Me.TEPPN3PLInv.TabIndex = 1
        '
        'SLEPPH3PLInv
        '
        Me.SLEPPH3PLInv.Location = New System.Drawing.Point(464, 14)
        Me.SLEPPH3PLInv.Name = "SLEPPH3PLInv"
        Me.SLEPPH3PLInv.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPPH3PLInv.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEPPH3PLInv.Size = New System.Drawing.Size(211, 20)
        Me.SLEPPH3PLInv.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "id"
        Me.GridColumn3.FieldName = "id_acc"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ACC"
        Me.GridColumn4.FieldName = "acc_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 400
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Description"
        Me.GridColumn5.FieldName = "acc_description"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 1216
        '
        'BImport
        '
        Me.BImport.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BImport.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BImport.Appearance.ForeColor = System.Drawing.Color.White
        Me.BImport.Appearance.Options.UseBackColor = True
        Me.BImport.Appearance.Options.UseFont = True
        Me.BImport.Appearance.Options.UseForeColor = True
        Me.BImport.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BImport.Location = New System.Drawing.Point(0, 494)
        Me.BImport.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BImport.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BImport.Name = "BImport"
        Me.BImport.Size = New System.Drawing.Size(1006, 34)
        Me.BImport.TabIndex = 91
        Me.BImport.Text = "Generate Expense"
        Me.BImport.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BRefresh)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1006, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefresh.Image = CType(resources.GetObject("BRefresh.Image"), System.Drawing.Image)
        Me.BRefresh.Location = New System.Drawing.Point(890, 2)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(114, 44)
        Me.BRefresh.TabIndex = 2
        Me.BRefresh.Text = "Refresh"
        '
        'XTPSNI
        '
        Me.XTPSNI.Controls.Add(Me.GCListSNI)
        Me.XTPSNI.Controls.Add(Me.PanelControl3)
        Me.XTPSNI.Name = "XTPSNI"
        Me.XTPSNI.Size = New System.Drawing.Size(1006, 528)
        Me.XTPSNI.Text = "SNI"
        '
        'GCListSNI
        '
        Me.GCListSNI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListSNI.Location = New System.Drawing.Point(0, 48)
        Me.GCListSNI.MainView = Me.GVListSNI
        Me.GCListSNI.Name = "GCListSNI"
        Me.GCListSNI.Size = New System.Drawing.Size(1006, 480)
        Me.GCListSNI.TabIndex = 93
        Me.GCListSNI.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListSNI})
        '
        'GVListSNI
        '
        Me.GVListSNI.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn12, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GVListSNI.GridControl = Me.GCListSNI
        Me.GVListSNI.Name = "GVListSNI"
        Me.GVListSNI.OptionsBehavior.Editable = False
        Me.GVListSNI.OptionsBehavior.ReadOnly = True
        Me.GVListSNI.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "ID"
        Me.GridColumn6.FieldName = "id_awb_office"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.Caption = "Season"
        Me.GridColumn12.FieldName = "season"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        Me.GridColumn12.Width = 155
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Note"
        Me.GridColumn7.FieldName = "note"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 4
        Me.GridColumn7.Width = 216
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Number"
        Me.GridColumn8.FieldName = "number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        Me.GridColumn8.Width = 197
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Created By"
        Me.GridColumn9.FieldName = "employee_name"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        Me.GridColumn9.Width = 210
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Created Date"
        Me.GridColumn10.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn10.FieldName = "created_date"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 3
        Me.GridColumn10.Width = 210
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BrefreshSNI)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1006, 48)
        Me.PanelControl3.TabIndex = 1
        '
        'BrefreshSNI
        '
        Me.BrefreshSNI.Dock = System.Windows.Forms.DockStyle.Right
        Me.BrefreshSNI.Image = CType(resources.GetObject("BrefreshSNI.Image"), System.Drawing.Image)
        Me.BrefreshSNI.Location = New System.Drawing.Point(890, 2)
        Me.BrefreshSNI.Name = "BrefreshSNI"
        Me.BrefreshSNI.Size = New System.Drawing.Size(114, 44)
        Me.BrefreshSNI.TabIndex = 2
        Me.BrefreshSNI.Text = "Refresh"
        '
        'XTPRider
        '
        Me.XTPRider.Controls.Add(Me.GCContractList)
        Me.XTPRider.Controls.Add(Me.PanelControl4)
        Me.XTPRider.Name = "XTPRider"
        Me.XTPRider.Size = New System.Drawing.Size(1006, 528)
        Me.XTPRider.Text = "Endorsee"
        '
        'GCContractList
        '
        Me.GCContractList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCContractList.Location = New System.Drawing.Point(0, 45)
        Me.GCContractList.MainView = Me.GVContractList
        Me.GCContractList.Name = "GCContractList"
        Me.GCContractList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICE})
        Me.GCContractList.Size = New System.Drawing.Size(1006, 483)
        Me.GCContractList.TabIndex = 97
        Me.GCContractList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVContractList})
        '
        'GVContractList
        '
        Me.GVContractList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn11, Me.GridColumn13, Me.GridColumn14, Me.GridColumn21, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn22})
        Me.GVContractList.GridControl = Me.GCContractList
        Me.GVContractList.Name = "GVContractList"
        Me.GVContractList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "ID Kontrak"
        Me.GridColumn11.FieldName = "id_kontrak_rider"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID Comp"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "*"
        Me.GridColumn14.ColumnEdit = Me.RICE
        Me.GridColumn14.FieldName = "is_check"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Width = 54
        '
        'RICE
        '
        Me.RICE.AutoHeight = False
        Me.RICE.Name = "RICE"
        Me.RICE.ValueChecked = "yes"
        Me.RICE.ValueUnchecked = "no"
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Periode"
        Me.GridColumn21.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn21.FieldName = "periode"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 1
        Me.GridColumn21.Width = 111
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Endorsee"
        Me.GridColumn15.FieldName = "comp_name"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 0
        Me.GridColumn15.Width = 263
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Periode Start"
        Me.GridColumn16.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn16.FieldName = "kontrak_from"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        Me.GridColumn16.Width = 159
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Periode Until"
        Me.GridColumn17.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn17.FieldName = "kontrak_until"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 3
        Me.GridColumn17.Width = 159
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn18.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn18.Caption = "Periode (Month)"
        Me.GridColumn18.FieldName = "qty_month"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Width = 261
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.Caption = "Monthly Payment"
        Me.GridColumn19.DisplayFormat.FormatString = "N2"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "monthly_pay"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 4
        Me.GridColumn19.Width = 169
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.Caption = "Total Payment"
        Me.GridColumn20.DisplayFormat.FormatString = "N2"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "total"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Width = 268
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Expense Number"
        Me.GridColumn22.FieldName = "number"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 5
        Me.GridColumn22.Width = 127
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.BViewEndorsee)
        Me.PanelControl4.Controls.Add(Me.LabelControl5)
        Me.PanelControl4.Controls.Add(Me.DEContract)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(1006, 45)
        Me.PanelControl4.TabIndex = 96
        '
        'BViewEndorsee
        '
        Me.BViewEndorsee.Location = New System.Drawing.Point(297, 9)
        Me.BViewEndorsee.Name = "BViewEndorsee"
        Me.BViewEndorsee.Size = New System.Drawing.Size(58, 23)
        Me.BViewEndorsee.TabIndex = 2
        Me.BViewEndorsee.Text = "view"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl5.TabIndex = 1
        Me.LabelControl5.Text = "Date Reff"
        '
        'DEContract
        '
        Me.DEContract.EditValue = Nothing
        Me.DEContract.Location = New System.Drawing.Point(65, 11)
        Me.DEContract.Name = "DEContract"
        Me.DEContract.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEContract.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEContract.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEContract.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEContract.Size = New System.Drawing.Size(226, 20)
        Me.DEContract.TabIndex = 0
        '
        'FormItemExpense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 556)
        Me.Controls.Add(Me.XTCExpense)
        Me.Name = "FormItemExpense"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expense"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        Me.PanelControlNav.PerformLayout()
        CType(Me.SLEUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEBBKTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEBBKTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEBBKFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEBBKFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCExpense, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCExpense.ResumeLayout(False)
        Me.XTPExpense.ResumeLayout(False)
        Me.XTP3PLInv.ResumeLayout(False)
        CType(Me.GCInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TEDesc3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPPN3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.XTPSNI.ResumeLayout(False)
        CType(Me.GCListSNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListSNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.XTPRider.ResumeLayout(False)
        CType(Me.GCContractList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVContractList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.DEContract.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEContract.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedByName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReortStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPaidStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBeneficiary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnBankWithdrawal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEBBKTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEBBKFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BViewPayment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEUnit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCExpense As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPExpense As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTP3PLInv As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCInvoice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEPPH3PLInv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPPN3PLInv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SLEPPH3PLInv As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEDesc3PLInv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTPSNI As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BrefreshSNI As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCListSNI As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListSNI As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DuplicateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XTPRider As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BViewEndorsee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEContract As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GCContractList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVContractList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICE As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
End Class
