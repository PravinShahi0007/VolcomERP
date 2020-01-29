<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGTransSummary
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
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnExportToXLSRec = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEAmoType = New DevExpress.XtraEditors.LookUpEdit()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCompNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBegin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnretTrf = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTrf = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRepair = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRetRep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAdjIn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAdjOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_exp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpros = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPageStore = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPageDesign = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEndDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCostDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.LEAmoType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl.SuspendLayout()
        Me.XtraTabPageStore.SuspendLayout()
        Me.XtraTabPageDesign.SuspendLayout()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnExportToXLSRec)
        Me.GCFilter.Controls.Add(Me.LabelControl1)
        Me.GCFilter.Controls.Add(Me.LEAmoType)
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
        Me.GCFilter.Size = New System.Drawing.Size(1008, 39)
        Me.GCFilter.TabIndex = 4
        '
        'BtnExportToXLSRec
        '
        Me.BtnExportToXLSRec.Location = New System.Drawing.Point(601, 9)
        Me.BtnExportToXLSRec.LookAndFeel.SkinName = "Blue"
        Me.BtnExportToXLSRec.Name = "BtnExportToXLSRec"
        Me.BtnExportToXLSRec.Size = New System.Drawing.Size(92, 20)
        Me.BtnExportToXLSRec.TabIndex = 8901
        Me.BtnExportToXLSRec.Text = "Export to XLS"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(319, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl1.TabIndex = 8900
        Me.LabelControl1.Text = "Amount Type"
        '
        'LEAmoType
        '
        Me.LEAmoType.Location = New System.Drawing.Point(389, 9)
        Me.LEAmoType.Name = "LEAmoType"
        Me.LEAmoType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEAmoType.Size = New System.Drawing.Size(125, 20)
        Me.LEAmoType.TabIndex = 8899
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(520, 9)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(1132, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(1029, 14)
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
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(1002, 662)
        Me.GCData.TabIndex = 5
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCompNumber, Me.GridColumnCompName, Me.GridColumnBegin, Me.GridColumn4, Me.GridColumnDel, Me.GridColumnSal, Me.GridColumnRet, Me.GridColumnretTrf, Me.GridColumnTrf, Me.GridColumnRepair, Me.GridColumnRetRep, Me.GridColumnAdjIn, Me.GridColumnAdjOut, Me.GridColumnEnd, Me.GridColumnType, Me.GridColumnPrice, Me.GridColumnCost, Me.GridColumnqty_exp, Me.GridColumnpros})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupCount = 1
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_beg", Me.GridColumnBegin, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", Me.GridColumn4, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_del", Me.GridColumnDel, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret", Me.GridColumnRet, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_trf", Me.GridColumnretTrf, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_trf", Me.GridColumnTrf, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rep", Me.GridColumnRepair, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rep_ret", Me.GridColumnRetRep, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_sal", Me.GridColumnSal, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj_in", Me.GridColumnAdjIn, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj_out", Me.GridColumnAdjOut, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_end", Me.GridColumnEnd, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_price", Me.GridColumnPrice, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_cost", Me.GridColumnCost, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_exp", Me.GridColumnqty_exp, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "pros", Me.GridColumnpros, "{0:N2}", "b")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVData.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        Me.GVData.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnType, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnCompNumber
        '
        Me.GridColumnCompNumber.Caption = "ACCOUNT#"
        Me.GridColumnCompNumber.FieldName = "comp_number"
        Me.GridColumnCompNumber.Name = "GridColumnCompNumber"
        Me.GridColumnCompNumber.Visible = True
        Me.GridColumnCompNumber.VisibleIndex = 0
        Me.GridColumnCompNumber.Width = 71
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "NAME"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 1
        Me.GridColumnCompName.Width = 115
        '
        'GridColumnBegin
        '
        Me.GridColumnBegin.Caption = "BEGIN"
        Me.GridColumnBegin.DisplayFormat.FormatString = "N0"
        Me.GridColumnBegin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBegin.FieldName = "qty_beg"
        Me.GridColumnBegin.Name = "GridColumnBegin"
        Me.GridColumnBegin.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_beg", "{0:N0}")})
        Me.GridColumnBegin.Visible = True
        Me.GridColumnBegin.VisibleIndex = 2
        Me.GridColumnBegin.Width = 100
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "REC"
        Me.GridColumn4.DisplayFormat.FormatString = "N0"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "qty_rec"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", "{0:N0}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 86
        '
        'GridColumnDel
        '
        Me.GridColumnDel.Caption = "DEL"
        Me.GridColumnDel.DisplayFormat.FormatString = "N0"
        Me.GridColumnDel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDel.FieldName = "qty_del"
        Me.GridColumnDel.Name = "GridColumnDel"
        Me.GridColumnDel.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_del", "{0:N0}")})
        Me.GridColumnDel.Visible = True
        Me.GridColumnDel.VisibleIndex = 4
        Me.GridColumnDel.Width = 89
        '
        'GridColumnSal
        '
        Me.GridColumnSal.Caption = "SALE"
        Me.GridColumnSal.DisplayFormat.FormatString = "N0"
        Me.GridColumnSal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSal.FieldName = "qty_sal"
        Me.GridColumnSal.Name = "GridColumnSal"
        Me.GridColumnSal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_sal", "{0:N0}")})
        Me.GridColumnSal.Visible = True
        Me.GridColumnSal.VisibleIndex = 6
        Me.GridColumnSal.Width = 92
        '
        'GridColumnRet
        '
        Me.GridColumnRet.Caption = "RET"
        Me.GridColumnRet.DisplayFormat.FormatString = "N0"
        Me.GridColumnRet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRet.FieldName = "qty_ret"
        Me.GridColumnRet.Name = "GridColumnRet"
        Me.GridColumnRet.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret", "{0:N0}")})
        Me.GridColumnRet.Visible = True
        Me.GridColumnRet.VisibleIndex = 7
        Me.GridColumnRet.Width = 91
        '
        'GridColumnretTrf
        '
        Me.GridColumnretTrf.Caption = "RET TRF"
        Me.GridColumnretTrf.DisplayFormat.FormatString = "N0"
        Me.GridColumnretTrf.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnretTrf.FieldName = "qty_ret_trf"
        Me.GridColumnretTrf.Name = "GridColumnretTrf"
        Me.GridColumnretTrf.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_trf", "{0:N0}")})
        Me.GridColumnretTrf.Visible = True
        Me.GridColumnretTrf.VisibleIndex = 8
        Me.GridColumnretTrf.Width = 97
        '
        'GridColumnTrf
        '
        Me.GridColumnTrf.Caption = "TRF"
        Me.GridColumnTrf.DisplayFormat.FormatString = "N0"
        Me.GridColumnTrf.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTrf.FieldName = "qty_trf"
        Me.GridColumnTrf.Name = "GridColumnTrf"
        Me.GridColumnTrf.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_trf", "{0:N0}")})
        Me.GridColumnTrf.Visible = True
        Me.GridColumnTrf.VisibleIndex = 9
        Me.GridColumnTrf.Width = 99
        '
        'GridColumnRepair
        '
        Me.GridColumnRepair.Caption = "REP"
        Me.GridColumnRepair.DisplayFormat.FormatString = "N0"
        Me.GridColumnRepair.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRepair.FieldName = "qty_rep"
        Me.GridColumnRepair.Name = "GridColumnRepair"
        Me.GridColumnRepair.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rep", "{0:N0}")})
        Me.GridColumnRepair.Visible = True
        Me.GridColumnRepair.VisibleIndex = 10
        Me.GridColumnRepair.Width = 96
        '
        'GridColumnRetRep
        '
        Me.GridColumnRetRep.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRetRep.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnRetRep.Caption = "RET REP"
        Me.GridColumnRetRep.DisplayFormat.FormatString = "N0"
        Me.GridColumnRetRep.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRetRep.FieldName = "qty_rep_ret"
        Me.GridColumnRetRep.Name = "GridColumnRetRep"
        Me.GridColumnRetRep.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rep_ret", "{0:N0}")})
        Me.GridColumnRetRep.Visible = True
        Me.GridColumnRetRep.VisibleIndex = 11
        Me.GridColumnRetRep.Width = 88
        '
        'GridColumnAdjIn
        '
        Me.GridColumnAdjIn.Caption = "ADJ IN"
        Me.GridColumnAdjIn.DisplayFormat.FormatString = "N0"
        Me.GridColumnAdjIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAdjIn.FieldName = "qty_adj_in"
        Me.GridColumnAdjIn.Name = "GridColumnAdjIn"
        Me.GridColumnAdjIn.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj_in", "{0:N0}")})
        Me.GridColumnAdjIn.Visible = True
        Me.GridColumnAdjIn.VisibleIndex = 12
        Me.GridColumnAdjIn.Width = 103
        '
        'GridColumnAdjOut
        '
        Me.GridColumnAdjOut.Caption = "ADJ OUT"
        Me.GridColumnAdjOut.DisplayFormat.FormatString = "N0"
        Me.GridColumnAdjOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAdjOut.FieldName = "qty_adj_out"
        Me.GridColumnAdjOut.Name = "GridColumnAdjOut"
        Me.GridColumnAdjOut.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj_out", "{0:N0}")})
        Me.GridColumnAdjOut.Visible = True
        Me.GridColumnAdjOut.VisibleIndex = 13
        Me.GridColumnAdjOut.Width = 106
        '
        'GridColumnEnd
        '
        Me.GridColumnEnd.Caption = "END"
        Me.GridColumnEnd.DisplayFormat.FormatString = "N0"
        Me.GridColumnEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnEnd.FieldName = "qty_end"
        Me.GridColumnEnd.Name = "GridColumnEnd"
        Me.GridColumnEnd.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_end", "{0:N0}")})
        Me.GridColumnEnd.Visible = True
        Me.GridColumnEnd.VisibleIndex = 14
        Me.GridColumnEnd.Width = 88
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "TYPE"
        Me.GridColumnType.FieldName = "type"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.Visible = True
        Me.GridColumnType.VisibleIndex = 14
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Amount Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "amount_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_price", "{0:N2}")})
        Me.GridColumnPrice.Width = 113
        '
        'GridColumnCost
        '
        Me.GridColumnCost.Caption = "Amount Cost"
        Me.GridColumnCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCost.FieldName = "amount_cost"
        Me.GridColumnCost.Name = "GridColumnCost"
        Me.GridColumnCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_cost", "{0:N2}")})
        Me.GridColumnCost.Width = 126
        '
        'GridColumnqty_exp
        '
        Me.GridColumnqty_exp.Caption = "EXP"
        Me.GridColumnqty_exp.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_exp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_exp.FieldName = "qty_exp"
        Me.GridColumnqty_exp.Name = "GridColumnqty_exp"
        Me.GridColumnqty_exp.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_exp", "{0:N0}")})
        Me.GridColumnqty_exp.Visible = True
        Me.GridColumnqty_exp.VisibleIndex = 5
        '
        'GridColumnpros
        '
        Me.GridColumnpros.Caption = "%"
        Me.GridColumnpros.DisplayFormat.FormatString = "N2"
        Me.GridColumnpros.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpros.FieldName = "pros"
        Me.GridColumnpros.Name = "GridColumnpros"
        Me.GridColumnpros.OptionsColumn.ReadOnly = True
        Me.GridColumnpros.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "pros", "{0:N2}", "a")})
        Me.GridColumnpros.Visible = True
        Me.GridColumnpros.VisibleIndex = 15
        '
        'XtraTabControl
        '
        Me.XtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl.Location = New System.Drawing.Point(0, 39)
        Me.XtraTabControl.Name = "XtraTabControl"
        Me.XtraTabControl.SelectedTabPage = Me.XtraTabPageStore
        Me.XtraTabControl.Size = New System.Drawing.Size(1008, 690)
        Me.XtraTabControl.TabIndex = 6
        Me.XtraTabControl.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPageStore, Me.XtraTabPageDesign})
        '
        'XtraTabPageStore
        '
        Me.XtraTabPageStore.Controls.Add(Me.GCData)
        Me.XtraTabPageStore.Name = "XtraTabPageStore"
        Me.XtraTabPageStore.Size = New System.Drawing.Size(1002, 662)
        Me.XtraTabPageStore.Text = "By Store"
        '
        'XtraTabPageDesign
        '
        Me.XtraTabPageDesign.Controls.Add(Me.GCDesign)
        Me.XtraTabPageDesign.Name = "XtraTabPageDesign"
        Me.XtraTabPageDesign.Size = New System.Drawing.Size(1002, 662)
        Me.XtraTabPageDesign.Text = "By Design"
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(0, 0)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(1002, 662)
        Me.GCDesign.TabIndex = 6
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign})
        '
        'GVDesign
        '
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumnEndDesign, Me.GridColumn15, Me.GridColumnPriceDesign, Me.GridColumnCostDesign, Me.GridColumn19, Me.GridColumn20})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_beg", Me.GridColumn3, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", Me.GridColumn5, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_del", Me.GridColumn6, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret", Me.GridColumn8, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_trf", Me.GridColumn9, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_trf", Me.GridColumn10, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rep", Me.GridColumn11, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rep_ret", Me.GridColumn12, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_sal", Me.GridColumn7, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj_in", Me.GridColumn13, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj_out", Me.GridColumn14, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_end", Me.GridColumnEndDesign, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_price", Me.GridColumnPriceDesign, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_cost", Me.GridColumnCostDesign, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_exp", Me.GridColumn19, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "pros", Me.GridColumn20, "{0:N2}", "b")})
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDesign.OptionsBehavior.ReadOnly = True
        Me.GVDesign.OptionsView.ColumnAutoWidth = False
        Me.GVDesign.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDesign.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVDesign.OptionsView.ShowFooter = True
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "CODE"
        Me.GridColumn1.FieldName = "design_code"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 71
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "NAME"
        Me.GridColumn2.FieldName = "design_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 115
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "BEGIN"
        Me.GridColumn3.DisplayFormat.FormatString = "N0"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "qty_beg"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_beg", "{0:N0}")})
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 100
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "REC"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "qty_rec"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", "{0:N0}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 86
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "DEL"
        Me.GridColumn6.DisplayFormat.FormatString = "N0"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "qty_del"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_del", "{0:N0}")})
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 89
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "SALE"
        Me.GridColumn7.DisplayFormat.FormatString = "N0"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "qty_sal"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_sal", "{0:N0}")})
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 92
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "RET"
        Me.GridColumn8.DisplayFormat.FormatString = "N0"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "qty_ret"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret", "{0:N0}")})
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        Me.GridColumn8.Width = 91
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "RET TRF"
        Me.GridColumn9.DisplayFormat.FormatString = "N0"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "qty_ret_trf"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_trf", "{0:N0}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        Me.GridColumn9.Width = 97
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "TRF"
        Me.GridColumn10.DisplayFormat.FormatString = "N0"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "qty_trf"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_trf", "{0:N0}")})
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 9
        Me.GridColumn10.Width = 99
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "REP"
        Me.GridColumn11.DisplayFormat.FormatString = "N0"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "qty_rep"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rep", "{0:N0}")})
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 10
        Me.GridColumn11.Width = 96
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn12.Caption = "RET REP"
        Me.GridColumn12.DisplayFormat.FormatString = "N0"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "qty_rep_ret"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rep_ret", "{0:N0}")})
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 11
        Me.GridColumn12.Width = 88
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ADJ IN"
        Me.GridColumn13.DisplayFormat.FormatString = "N0"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "qty_adj_in"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj_in", "{0:N0}")})
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 12
        Me.GridColumn13.Width = 103
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "ADJ OUT"
        Me.GridColumn14.DisplayFormat.FormatString = "N0"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "qty_adj_out"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj_out", "{0:N0}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 13
        Me.GridColumn14.Width = 106
        '
        'GridColumnEndDesign
        '
        Me.GridColumnEndDesign.Caption = "END"
        Me.GridColumnEndDesign.DisplayFormat.FormatString = "N0"
        Me.GridColumnEndDesign.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnEndDesign.FieldName = "qty_end"
        Me.GridColumnEndDesign.Name = "GridColumnEndDesign"
        Me.GridColumnEndDesign.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_end", "{0:N0}")})
        Me.GridColumnEndDesign.Visible = True
        Me.GridColumnEndDesign.VisibleIndex = 14
        Me.GridColumnEndDesign.Width = 88
        '
        'GridColumnPriceDesign
        '
        Me.GridColumnPriceDesign.Caption = "Amount Price"
        Me.GridColumnPriceDesign.DisplayFormat.FormatString = "N2"
        Me.GridColumnPriceDesign.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPriceDesign.FieldName = "amount_price"
        Me.GridColumnPriceDesign.Name = "GridColumnPriceDesign"
        Me.GridColumnPriceDesign.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_price", "{0:N2}")})
        Me.GridColumnPriceDesign.Width = 113
        '
        'GridColumnCostDesign
        '
        Me.GridColumnCostDesign.Caption = "Amount Cost"
        Me.GridColumnCostDesign.DisplayFormat.FormatString = "N2"
        Me.GridColumnCostDesign.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCostDesign.FieldName = "amount_cost"
        Me.GridColumnCostDesign.Name = "GridColumnCostDesign"
        Me.GridColumnCostDesign.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_cost", "{0:N2}")})
        Me.GridColumnCostDesign.Width = 126
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "EXP"
        Me.GridColumn19.DisplayFormat.FormatString = "N0"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "qty_exp"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_exp", "{0:N0}")})
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 5
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "%"
        Me.GridColumn20.DisplayFormat.FormatString = "N2"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "pros"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.ReadOnly = True
        Me.GridColumn20.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "pros", "{0:N2}", "a")})
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 15
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "AGE"
        Me.GridColumn15.DisplayFormat.FormatString = "N0"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "age"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 16
        '
        'FormFGTransSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.XtraTabControl)
        Me.Controls.Add(Me.GCFilter)
        Me.Name = "FormFGTransSummary"
        Me.Text = "Transaction Summary"
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.LEAmoType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl.ResumeLayout(False)
        Me.XtraTabPageStore.ResumeLayout(False)
        Me.XtraTabPageDesign.ResumeLayout(False)
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCompNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBegin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnretTrf As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTrf As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRepair As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetRep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdjIn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdjOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_exp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEAmoType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridColumnpros As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnExportToXLSRec As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPageStore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPageDesign As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEndDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCostDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
End Class
