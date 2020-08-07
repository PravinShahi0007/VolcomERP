<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVAHistoryDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVAHistoryDetail))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DECreated = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DETrans = New DevExpress.XtraEditors.DateEdit()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnno = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsales_order_ol_shop_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncustomer_name = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsettlement_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnpay_type = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandPaymentGate = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnpayment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandERP = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumninvoice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnship_invoice_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumninvoice_amount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_order = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncheckout_id = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.TxtBank = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETrans.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETrans.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.TxtBank)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.DETrans)
        Me.PanelControl1.Controls.Add(Me.DECreated)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 403)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(820, 53)
        Me.PanelControl1.TabIndex = 1
        '
        'DECreated
        '
        Me.DECreated.EditValue = Nothing
        Me.DECreated.Enabled = False
        Me.DECreated.Location = New System.Drawing.Point(358, 21)
        Me.DECreated.Name = "DECreated"
        Me.DECreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreated.Size = New System.Drawing.Size(201, 20)
        Me.DECreated.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(358, 5)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Created Date"
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(638, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(90, 49)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(728, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(90, 49)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(154, 5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(82, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Transaction Date"
        '
        'DETrans
        '
        Me.DETrans.EditValue = Nothing
        Me.DETrans.Enabled = False
        Me.DETrans.Location = New System.Drawing.Point(153, 21)
        Me.DETrans.Name = "DETrans"
        Me.DETrans.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETrans.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETrans.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DETrans.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETrans.Size = New System.Drawing.Size(201, 20)
        Me.DETrans.TabIndex = 4
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(820, 403)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBandPaymentGate, Me.gridBandERP})
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnsettlement_date, Me.BandedGridColumnpay_type, Me.BandedGridColumnid_order, Me.BandedGridColumnsales_order_ol_shop_number, Me.BandedGridColumncustomer_name, Me.BandedGridColumncheckout_id, Me.BandedGridColumnpayment, Me.BandedGridColumninvoice, Me.BandedGridColumninvoice_amount, Me.BandedGridColumnno, Me.BandedGridColumnship_invoice_number})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.BandedGridColumnno)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnsales_order_ol_shop_number)
        Me.GridBand1.Columns.Add(Me.BandedGridColumncustomer_name)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnsettlement_date)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnpay_type)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 429
        '
        'BandedGridColumnno
        '
        Me.BandedGridColumnno.Caption = "No"
        Me.BandedGridColumnno.FieldName = "no"
        Me.BandedGridColumnno.Name = "BandedGridColumnno"
        Me.BandedGridColumnno.Visible = True
        Me.BandedGridColumnno.Width = 45
        '
        'BandedGridColumnsales_order_ol_shop_number
        '
        Me.BandedGridColumnsales_order_ol_shop_number.Caption = "Order No"
        Me.BandedGridColumnsales_order_ol_shop_number.FieldName = "sales_order_ol_shop_number"
        Me.BandedGridColumnsales_order_ol_shop_number.Name = "BandedGridColumnsales_order_ol_shop_number"
        Me.BandedGridColumnsales_order_ol_shop_number.Visible = True
        Me.BandedGridColumnsales_order_ol_shop_number.Width = 90
        '
        'BandedGridColumncustomer_name
        '
        Me.BandedGridColumncustomer_name.Caption = "Cust."
        Me.BandedGridColumncustomer_name.FieldName = "customer_name"
        Me.BandedGridColumncustomer_name.Name = "BandedGridColumncustomer_name"
        Me.BandedGridColumncustomer_name.Visible = True
        '
        'BandedGridColumnsettlement_date
        '
        Me.BandedGridColumnsettlement_date.Caption = "Trans. Date"
        Me.BandedGridColumnsettlement_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.BandedGridColumnsettlement_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnsettlement_date.FieldName = "transaction_date"
        Me.BandedGridColumnsettlement_date.Name = "BandedGridColumnsettlement_date"
        Me.BandedGridColumnsettlement_date.Visible = True
        Me.BandedGridColumnsettlement_date.Width = 144
        '
        'BandedGridColumnpay_type
        '
        Me.BandedGridColumnpay_type.Caption = "Pay Type"
        Me.BandedGridColumnpay_type.FieldName = "pay_type"
        Me.BandedGridColumnpay_type.Name = "BandedGridColumnpay_type"
        Me.BandedGridColumnpay_type.Visible = True
        '
        'gridBandPaymentGate
        '
        Me.gridBandPaymentGate.Caption = "Payment Gateway"
        Me.gridBandPaymentGate.Columns.Add(Me.BandedGridColumnpayment)
        Me.gridBandPaymentGate.Name = "gridBandPaymentGate"
        Me.gridBandPaymentGate.VisibleIndex = 1
        Me.gridBandPaymentGate.Width = 135
        '
        'BandedGridColumnpayment
        '
        Me.BandedGridColumnpayment.Caption = "Amount"
        Me.BandedGridColumnpayment.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnpayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnpayment.FieldName = "payment"
        Me.BandedGridColumnpayment.Name = "BandedGridColumnpayment"
        Me.BandedGridColumnpayment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "payment", "{0:N2}")})
        Me.BandedGridColumnpayment.Visible = True
        Me.BandedGridColumnpayment.Width = 135
        '
        'gridBandERP
        '
        Me.gridBandERP.Caption = "ERP"
        Me.gridBandERP.Columns.Add(Me.BandedGridColumninvoice)
        Me.gridBandERP.Columns.Add(Me.BandedGridColumnship_invoice_number)
        Me.gridBandERP.Columns.Add(Me.BandedGridColumninvoice_amount)
        Me.gridBandERP.Name = "gridBandERP"
        Me.gridBandERP.VisibleIndex = 2
        Me.gridBandERP.Width = 253
        '
        'BandedGridColumninvoice
        '
        Me.BandedGridColumninvoice.Caption = "Invoice No."
        Me.BandedGridColumninvoice.FieldName = "invoice_number"
        Me.BandedGridColumninvoice.Name = "BandedGridColumninvoice"
        Me.BandedGridColumninvoice.Visible = True
        Me.BandedGridColumninvoice.Width = 89
        '
        'BandedGridColumnship_invoice_number
        '
        Me.BandedGridColumnship_invoice_number.Caption = "Invoice Ship"
        Me.BandedGridColumnship_invoice_number.FieldName = "ship_invoice_number"
        Me.BandedGridColumnship_invoice_number.Name = "BandedGridColumnship_invoice_number"
        Me.BandedGridColumnship_invoice_number.Visible = True
        '
        'BandedGridColumninvoice_amount
        '
        Me.BandedGridColumninvoice_amount.Caption = "Amount"
        Me.BandedGridColumninvoice_amount.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumninvoice_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumninvoice_amount.FieldName = "invoice_amount"
        Me.BandedGridColumninvoice_amount.Name = "BandedGridColumninvoice_amount"
        Me.BandedGridColumninvoice_amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "invoice_amount", "{0:N2}")})
        Me.BandedGridColumninvoice_amount.Visible = True
        Me.BandedGridColumninvoice_amount.Width = 89
        '
        'BandedGridColumnid_order
        '
        Me.BandedGridColumnid_order.Caption = "id_order"
        Me.BandedGridColumnid_order.FieldName = "id_order"
        Me.BandedGridColumnid_order.Name = "BandedGridColumnid_order"
        '
        'BandedGridColumncheckout_id
        '
        Me.BandedGridColumncheckout_id.Caption = "Checkout Id"
        Me.BandedGridColumncheckout_id.FieldName = "checkout_id"
        Me.BandedGridColumncheckout_id.Name = "BandedGridColumncheckout_id"
        '
        'TxtBank
        '
        Me.TxtBank.Enabled = False
        Me.TxtBank.Location = New System.Drawing.Point(13, 21)
        Me.TxtBank.Name = "TxtBank"
        Me.TxtBank.Size = New System.Drawing.Size(137, 20)
        Me.TxtBank.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(13, 6)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Bank"
        '
        'FormVAHistoryDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 456)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormVAHistoryDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import VA Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETrans.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETrans.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DECreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DETrans As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnno As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsales_order_ol_shop_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncustomer_name As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsettlement_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnpay_type As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandPaymentGate As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnpayment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandERP As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumninvoice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnship_invoice_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumninvoice_amount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_order As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncheckout_id As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtBank As DevExpress.XtraEditors.TextEdit
End Class
