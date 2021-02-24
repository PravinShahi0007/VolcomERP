<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpProdRec
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEFGPO = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.GCProdRec = New DevExpress.XtraGrid.GridControl()
        Me.GVProdRec = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPRodOrderRecPurc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ColPSONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDelRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStyleCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPoTypeRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnArriveDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEFGPO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProdRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEFGPO)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(915, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'SLEFGPO
        '
        Me.SLEFGPO.Location = New System.Drawing.Point(45, 13)
        Me.SLEFGPO.Name = "SLEFGPO"
        Me.SLEFGPO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEFGPO.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEFGPO.Size = New System.Drawing.Size(201, 20)
        Me.SLEFGPO.TabIndex = 8917
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_prod_order"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "prod_order_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 314
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Design Code"
        Me.GridColumn3.FieldName = "design_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 353
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Design"
        Me.GridColumn4.FieldName = "design_display_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 949
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl3.TabIndex = 8916
        Me.LabelControl3.Text = "FGPO"
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(252, 11)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(49, 23)
        Me.BView.TabIndex = 8915
        Me.BView.Text = "view"
        '
        'GCProdRec
        '
        Me.GCProdRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdRec.Location = New System.Drawing.Point(0, 44)
        Me.GCProdRec.MainView = Me.GVProdRec
        Me.GCProdRec.Name = "GCProdRec"
        Me.GCProdRec.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit1, Me.RepositoryItemTextEdit1})
        Me.GCProdRec.Size = New System.Drawing.Size(915, 529)
        Me.GCProdRec.TabIndex = 3
        Me.GCProdRec.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdRec, Me.GridView3})
        '
        'GVProdRec
        '
        Me.GVProdRec.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPRodOrderRecPurc, Me.ColSeason, Me.ColRecNumber, Me.ColShipFrom, Me.ColShipTo, Me.ColRecDate, Me.ColDueDate, Me.ColPSONumber, Me.ColDONumber, Me.ColIDStatus, Me.ColStatus, Me.GridColumnIdDel, Me.GridColumnDelRec, Me.GridColumnName, Me.GridColumnStyleCode, Me.GridColumnPoTypeRec, Me.GridColumnQty, Me.GridColumnArriveDate, Me.GridColumn5, Me.GridColumn7})
        Me.GVProdRec.GridControl = Me.GCProdRec
        Me.GVProdRec.GroupCount = 1
        Me.GVProdRec.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQty, "{0:n0}")})
        Me.GVProdRec.Name = "GVProdRec"
        Me.GVProdRec.OptionsBehavior.Editable = False
        Me.GVProdRec.OptionsFind.AlwaysVisible = True
        Me.GVProdRec.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVProdRec.OptionsView.ColumnAutoWidth = False
        Me.GVProdRec.OptionsView.ShowFooter = True
        Me.GVProdRec.OptionsView.ShowGroupPanel = False
        Me.GVProdRec.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdPRodOrderRecPurc, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'ColIdPRodOrderRecPurc
        '
        Me.ColIdPRodOrderRecPurc.Caption = "ID Prod Order Rec"
        Me.ColIdPRodOrderRecPurc.FieldName = "id_prod_order_rec"
        Me.ColIdPRodOrderRecPurc.Name = "ColIdPRodOrderRecPurc"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.FieldNameSortGroup = "id_season"
        Me.ColSeason.Name = "ColSeason"
        Me.ColSeason.Visible = True
        Me.ColSeason.VisibleIndex = 11
        '
        'ColRecNumber
        '
        Me.ColRecNumber.Caption = "Number"
        Me.ColRecNumber.FieldName = "prod_order_rec_number"
        Me.ColRecNumber.Name = "ColRecNumber"
        Me.ColRecNumber.Visible = True
        Me.ColRecNumber.VisibleIndex = 0
        Me.ColRecNumber.Width = 67
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "From"
        Me.ColShipFrom.FieldName = "comp_from"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 5
        Me.ColShipFrom.Width = 122
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "To"
        Me.ColShipTo.FieldName = "comp_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 6
        Me.ColShipTo.Width = 122
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Receive Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "prod_order_rec_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 10
        Me.ColRecDate.Width = 122
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
        Me.ColDueDate.Width = 124
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'ColPSONumber
        '
        Me.ColPSONumber.Caption = "Prod No."
        Me.ColPSONumber.FieldName = "prod_order_number"
        Me.ColPSONumber.Name = "ColPSONumber"
        Me.ColPSONumber.Visible = True
        Me.ColPSONumber.VisibleIndex = 1
        Me.ColPSONumber.Width = 69
        '
        'ColDONumber
        '
        Me.ColDONumber.Caption = "Del. Ref#"
        Me.ColDONumber.FieldName = "delivery_order_number"
        Me.ColDONumber.Name = "ColDONumber"
        Me.ColDONumber.Visible = True
        Me.ColDONumber.VisibleIndex = 8
        Me.ColDONumber.Width = 63
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
        Me.ColStatus.Width = 93
        '
        'GridColumnIdDel
        '
        Me.GridColumnIdDel.Caption = "Del"
        Me.GridColumnIdDel.FieldName = "id_delivery"
        Me.GridColumnIdDel.Name = "GridColumnIdDel"
        '
        'GridColumnDelRec
        '
        Me.GridColumnDelRec.Caption = "Delivery"
        Me.GridColumnDelRec.Name = "GridColumnDelRec"
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Style"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 3
        Me.GridColumnName.Width = 112
        '
        'GridColumnStyleCode
        '
        Me.GridColumnStyleCode.Caption = "Code"
        Me.GridColumnStyleCode.FieldName = "code"
        Me.GridColumnStyleCode.Name = "GridColumnStyleCode"
        Me.GridColumnStyleCode.Visible = True
        Me.GridColumnStyleCode.VisibleIndex = 2
        Me.GridColumnStyleCode.Width = 69
        '
        'GridColumnPoTypeRec
        '
        Me.GridColumnPoTypeRec.Caption = "PO Type"
        Me.GridColumnPoTypeRec.FieldName = "po_type"
        Me.GridColumnPoTypeRec.Name = "GridColumnPoTypeRec"
        Me.GridColumnPoTypeRec.Visible = True
        Me.GridColumnPoTypeRec.VisibleIndex = 4
        Me.GridColumnPoTypeRec.Width = 63
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 7
        Me.GridColumnQty.Width = 52
        '
        'GridColumnArriveDate
        '
        Me.GridColumnArriveDate.Caption = "Arrive in QC"
        Me.GridColumnArriveDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnArriveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnArriveDate.FieldName = "arrive_date"
        Me.GridColumnArriveDate.Name = "GridColumnArriveDate"
        Me.GridColumnArriveDate.Visible = True
        Me.GridColumnArriveDate.VisibleIndex = 12
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Est Arrive in QC"
        Me.GridColumn5.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn5.FieldName = "est_qc_date"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 13
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Diff Day On Estimate"
        Me.GridColumn7.FieldName = "diff_day"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 14
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
        'FormPopUpProdRec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 573)
        Me.Controls.Add(Me.GCProdRec)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormPopUpProdRec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List Receiving"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEFGPO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProdRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCProdRec As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdRec As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPRodOrderRecPurc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ColPSONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStyleCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPoTypeRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnArriveDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEFGPO As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
End Class
