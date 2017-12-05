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
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
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
        Me.GCFilter.Size = New System.Drawing.Size(754, 39)
        Me.GCFilter.TabIndex = 4
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(317, 9)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(835, 14)
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
        Me.GCData.Location = New System.Drawing.Point(0, 39)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(754, 377)
        Me.GCData.TabIndex = 5
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCompNumber, Me.GridColumnCompName, Me.GridColumnBegin, Me.GridColumn4, Me.GridColumnDel, Me.GridColumnSal, Me.GridColumnRet, Me.GridColumnretTrf, Me.GridColumnTrf, Me.GridColumnRepair, Me.GridColumnRetRep, Me.GridColumnAdjIn, Me.GridColumnAdjOut, Me.GridColumnEnd, Me.GridColumnType, Me.GridColumnPrice, Me.GridColumnCost})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupCount = 1
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_beg", Me.GridColumnBegin, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", Me.GridColumn4, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_del", Me.GridColumnDel, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret", Me.GridColumnRet, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret_trf", Me.GridColumnretTrf, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_trf", Me.GridColumnTrf, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rep", Me.GridColumnRepair, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rep_ret", Me.GridColumnRetRep, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_sal", Me.GridColumnSal, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj_in", Me.GridColumnAdjIn, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj_out", Me.GridColumnAdjOut, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_end", Me.GridColumnEnd, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_price", Me.GridColumnPrice, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_cost", Me.GridColumnCost, "{0:N2}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
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
        Me.GridColumnSal.VisibleIndex = 5
        Me.GridColumnSal.Width = 92
        '
        'GridColumnRet
        '
        Me.GridColumnRet.Caption = "RETURN"
        Me.GridColumnRet.DisplayFormat.FormatString = "N0"
        Me.GridColumnRet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRet.FieldName = "qty_ret"
        Me.GridColumnRet.Name = "GridColumnRet"
        Me.GridColumnRet.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ret", "{0:N0}")})
        Me.GridColumnRet.Visible = True
        Me.GridColumnRet.VisibleIndex = 6
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
        Me.GridColumnretTrf.VisibleIndex = 7
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
        Me.GridColumnTrf.VisibleIndex = 8
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
        Me.GridColumnRepair.VisibleIndex = 9
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
        Me.GridColumnRetRep.VisibleIndex = 10
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
        Me.GridColumnAdjIn.VisibleIndex = 11
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
        Me.GridColumnAdjOut.VisibleIndex = 12
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
        Me.GridColumnEnd.VisibleIndex = 13
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
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 14
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
        Me.GridColumnCost.Visible = True
        Me.GridColumnCost.VisibleIndex = 15
        Me.GridColumnCost.Width = 126
        '
        'FormFGTransSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 416)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.GCFilter)
        Me.Name = "FormFGTransSummary"
        Me.Text = "Tranaction Summary"
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
