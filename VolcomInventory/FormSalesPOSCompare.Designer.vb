<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesPOSCompare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesPOSCompare))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBandSummary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnstatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnno = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandStore = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumninput_price = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnsales_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandERP = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumndesign_price_retail = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnlimit_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnsales_pos_det_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnno_stock_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnamount_erp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandCheck = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnnote = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnnote_price = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnConfirm)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 364)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(593, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(92, 43)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(685, 2)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(97, 43)
        Me.BtnConfirm.TabIndex = 0
        Me.BtnConfirm.Text = "Confirm"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(784, 364)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBandSummary, Me.GridBand1, Me.gridBandStore, Me.gridBandERP, Me.gridBandCheck})
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnno, Me.GridColumncode, Me.GridColumndescription, Me.GridColumnsize, Me.GridColumninput_price, Me.GridColumndesign_price_retail, Me.GridColumnlimit_qty, Me.GridColumnsales_pos_det_qty, Me.GridColumnno_stock_qty, Me.GridColumnsales_qty, Me.GridColumnamount, Me.GridColumnamount_erp, Me.GridColumnnote, Me.GridColumnnote_price, Me.GridColumnstatus})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsCustomization.AllowSort = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'gridBandSummary
        '
        Me.gridBandSummary.Columns.Add(Me.GridColumnstatus)
        Me.gridBandSummary.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gridBandSummary.Name = "gridBandSummary"
        Me.gridBandSummary.VisibleIndex = 0
        Me.gridBandSummary.Width = 75
        '
        'GridColumnstatus
        '
        Me.GridColumnstatus.Caption = "Status"
        Me.GridColumnstatus.FieldName = "status"
        Me.GridColumnstatus.Name = "GridColumnstatus"
        Me.GridColumnstatus.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.GridColumnno)
        Me.GridBand1.Columns.Add(Me.GridColumncode)
        Me.GridBand1.Columns.Add(Me.GridColumndescription)
        Me.GridBand1.Columns.Add(Me.GridColumnsize)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 1
        Me.GridBand1.Width = 300
        '
        'GridColumnno
        '
        Me.GridColumnno.Caption = "No"
        Me.GridColumnno.FieldName = "no"
        Me.GridColumnno.Name = "GridColumnno"
        Me.GridColumnno.Visible = True
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.Visible = True
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "name"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        '
        'gridBandStore
        '
        Me.gridBandStore.Caption = "Store"
        Me.gridBandStore.Columns.Add(Me.GridColumninput_price)
        Me.gridBandStore.Columns.Add(Me.GridColumnsales_qty)
        Me.gridBandStore.Columns.Add(Me.GridColumnamount)
        Me.gridBandStore.Name = "gridBandStore"
        Me.gridBandStore.VisibleIndex = 2
        Me.gridBandStore.Width = 225
        '
        'GridColumninput_price
        '
        Me.GridColumninput_price.Caption = "Price"
        Me.GridColumninput_price.DisplayFormat.FormatString = "N0"
        Me.GridColumninput_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumninput_price.FieldName = "input_price"
        Me.GridColumninput_price.Name = "GridColumninput_price"
        Me.GridColumninput_price.Visible = True
        '
        'GridColumnsales_qty
        '
        Me.GridColumnsales_qty.Caption = "Qty"
        Me.GridColumnsales_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnsales_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_qty.FieldName = "sales_qty"
        Me.GridColumnsales_qty.Name = "GridColumnsales_qty"
        Me.GridColumnsales_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_qty", "{0:N0}")})
        Me.GridColumnsales_qty.Visible = True
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount"
        Me.GridColumnamount.DisplayFormat.FormatString = "N0"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount_store"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_store", "{0:N0}")})
        Me.GridColumnamount.UnboundExpression = "[input_price] * [sales_qty]"
        Me.GridColumnamount.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnamount.Visible = True
        '
        'gridBandERP
        '
        Me.gridBandERP.Caption = "ERP"
        Me.gridBandERP.Columns.Add(Me.GridColumndesign_price_retail)
        Me.gridBandERP.Columns.Add(Me.GridColumnlimit_qty)
        Me.gridBandERP.Columns.Add(Me.GridColumnsales_pos_det_qty)
        Me.gridBandERP.Columns.Add(Me.GridColumnno_stock_qty)
        Me.gridBandERP.Columns.Add(Me.GridColumnamount_erp)
        Me.gridBandERP.Name = "gridBandERP"
        Me.gridBandERP.VisibleIndex = 3
        Me.gridBandERP.Width = 375
        '
        'GridColumndesign_price_retail
        '
        Me.GridColumndesign_price_retail.Caption = "Price"
        Me.GridColumndesign_price_retail.DisplayFormat.FormatString = "N0"
        Me.GridColumndesign_price_retail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndesign_price_retail.FieldName = "design_price_retail"
        Me.GridColumndesign_price_retail.Name = "GridColumndesign_price_retail"
        Me.GridColumndesign_price_retail.Visible = True
        '
        'GridColumnlimit_qty
        '
        Me.GridColumnlimit_qty.Caption = "Available Qty"
        Me.GridColumnlimit_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnlimit_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnlimit_qty.FieldName = "limit_qty"
        Me.GridColumnlimit_qty.Name = "GridColumnlimit_qty"
        Me.GridColumnlimit_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "limit_qty", "{0:N0}")})
        Me.GridColumnlimit_qty.Visible = True
        '
        'GridColumnsales_pos_det_qty
        '
        Me.GridColumnsales_pos_det_qty.Caption = "Invoice Qty"
        Me.GridColumnsales_pos_det_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnsales_pos_det_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_det_qty.FieldName = "sales_pos_det_qty"
        Me.GridColumnsales_pos_det_qty.Name = "GridColumnsales_pos_det_qty"
        Me.GridColumnsales_pos_det_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_det_qty", "{0:N0}")})
        Me.GridColumnsales_pos_det_qty.Visible = True
        '
        'GridColumnno_stock_qty
        '
        Me.GridColumnno_stock_qty.Caption = "No Stock Qty"
        Me.GridColumnno_stock_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnno_stock_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnno_stock_qty.FieldName = "no_stock_qty"
        Me.GridColumnno_stock_qty.Name = "GridColumnno_stock_qty"
        Me.GridColumnno_stock_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "no_stock_qty", "{0:N0}")})
        Me.GridColumnno_stock_qty.Visible = True
        '
        'GridColumnamount_erp
        '
        Me.GridColumnamount_erp.Caption = "Amount"
        Me.GridColumnamount_erp.DisplayFormat.FormatString = "N0"
        Me.GridColumnamount_erp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount_erp.FieldName = "amount_erp"
        Me.GridColumnamount_erp.Name = "GridColumnamount_erp"
        Me.GridColumnamount_erp.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_erp", "{0:N0}")})
        Me.GridColumnamount_erp.UnboundExpression = "[design_price_retail] * [sales_pos_det_qty]"
        Me.GridColumnamount_erp.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnamount_erp.Visible = True
        '
        'gridBandCheck
        '
        Me.gridBandCheck.Caption = "Note"
        Me.gridBandCheck.Columns.Add(Me.GridColumnnote)
        Me.gridBandCheck.Columns.Add(Me.GridColumnnote_price)
        Me.gridBandCheck.Name = "gridBandCheck"
        Me.gridBandCheck.VisibleIndex = 4
        Me.gridBandCheck.Width = 150
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Stock"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        '
        'GridColumnnote_price
        '
        Me.GridColumnnote_price.Caption = "Price"
        Me.GridColumnnote_price.FieldName = "note_price"
        Me.GridColumnnote_price.Name = "GridColumnnote_price"
        Me.GridColumnnote_price.Visible = True
        '
        'FormSalesPOSCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSalesPOSCompare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Invoice - Compare Item"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumnno As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnamount_erp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumninput_price As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnsales_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumndesign_price_retail As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnlimit_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnsales_pos_det_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnno_stock_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnnote_price As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnstatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandSummary As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandStore As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandERP As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandCheck As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
