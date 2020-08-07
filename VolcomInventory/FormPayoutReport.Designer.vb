<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPayoutReport
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
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnorder_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnorder_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncustomer_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumninv_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumninv_ship_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntrans_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpay_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntype = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpayment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntrans_fee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.DEFrom)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(669, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(306, 12)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8901
        Me.BtnView.Text = "View"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(191, 12)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8900
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(47, 12)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8899
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(164, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8898
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8897
        Me.LabelControl3.Text = "From"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 47)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(669, 406)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnorder_number, Me.GridColumnorder_date, Me.GridColumncustomer_name, Me.GridColumninv_number, Me.GridColumninv_ship_number, Me.GridColumntrans_date, Me.GridColumnpay_type, Me.GridColumnbank, Me.GridColumntype, Me.GridColumnid, Me.GridColumnpayment, Me.GridColumntrans_fee, Me.GridColumnamount})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnorder_number
        '
        Me.GridColumnorder_number.Caption = "Order Number"
        Me.GridColumnorder_number.FieldName = "order_number"
        Me.GridColumnorder_number.Name = "GridColumnorder_number"
        Me.GridColumnorder_number.Visible = True
        Me.GridColumnorder_number.VisibleIndex = 0
        '
        'GridColumnorder_date
        '
        Me.GridColumnorder_date.Caption = "Order Date"
        Me.GridColumnorder_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnorder_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnorder_date.FieldName = "order_date"
        Me.GridColumnorder_date.Name = "GridColumnorder_date"
        Me.GridColumnorder_date.Visible = True
        Me.GridColumnorder_date.VisibleIndex = 1
        '
        'GridColumncustomer_name
        '
        Me.GridColumncustomer_name.Caption = "Customer"
        Me.GridColumncustomer_name.FieldName = "customer_name"
        Me.GridColumncustomer_name.Name = "GridColumncustomer_name"
        Me.GridColumncustomer_name.Visible = True
        Me.GridColumncustomer_name.VisibleIndex = 2
        '
        'GridColumninv_number
        '
        Me.GridColumninv_number.Caption = "Invoice#"
        Me.GridColumninv_number.FieldName = "inv_number"
        Me.GridColumninv_number.Name = "GridColumninv_number"
        Me.GridColumninv_number.Visible = True
        Me.GridColumninv_number.VisibleIndex = 3
        '
        'GridColumninv_ship_number
        '
        Me.GridColumninv_ship_number.Caption = "Invoice Ship#"
        Me.GridColumninv_ship_number.FieldName = "inv_ship_number"
        Me.GridColumninv_ship_number.Name = "GridColumninv_ship_number"
        Me.GridColumninv_ship_number.Visible = True
        Me.GridColumninv_ship_number.VisibleIndex = 4
        '
        'GridColumntrans_date
        '
        Me.GridColumntrans_date.Caption = "Settlement Date"
        Me.GridColumntrans_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumntrans_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumntrans_date.FieldName = "trans_date"
        Me.GridColumntrans_date.Name = "GridColumntrans_date"
        Me.GridColumntrans_date.Visible = True
        Me.GridColumntrans_date.VisibleIndex = 5
        '
        'GridColumnpay_type
        '
        Me.GridColumnpay_type.Caption = "Payment Type"
        Me.GridColumnpay_type.FieldName = "pay_type"
        Me.GridColumnpay_type.Name = "GridColumnpay_type"
        Me.GridColumnpay_type.Visible = True
        Me.GridColumnpay_type.VisibleIndex = 6
        '
        'GridColumnbank
        '
        Me.GridColumnbank.Caption = "Bank"
        Me.GridColumnbank.FieldName = "bank"
        Me.GridColumnbank.Name = "GridColumnbank"
        Me.GridColumnbank.Visible = True
        Me.GridColumnbank.VisibleIndex = 7
        '
        'GridColumntype
        '
        Me.GridColumntype.Caption = "Type"
        Me.GridColumntype.FieldName = "type"
        Me.GridColumntype.Name = "GridColumntype"
        Me.GridColumntype.Visible = True
        Me.GridColumntype.VisibleIndex = 8
        '
        'GridColumnid
        '
        Me.GridColumnid.Caption = "id"
        Me.GridColumnid.FieldName = "id"
        Me.GridColumnid.Name = "GridColumnid"
        Me.GridColumnid.Visible = True
        Me.GridColumnid.VisibleIndex = 9
        '
        'GridColumnpayment
        '
        Me.GridColumnpayment.Caption = "Amount"
        Me.GridColumnpayment.DisplayFormat.FormatString = "N2"
        Me.GridColumnpayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpayment.FieldName = "payment"
        Me.GridColumnpayment.Name = "GridColumnpayment"
        Me.GridColumnpayment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "payment", "{0:N2}")})
        Me.GridColumnpayment.Visible = True
        Me.GridColumnpayment.VisibleIndex = 10
        '
        'GridColumntrans_fee
        '
        Me.GridColumntrans_fee.Caption = "Fee"
        Me.GridColumntrans_fee.DisplayFormat.FormatString = "N2"
        Me.GridColumntrans_fee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntrans_fee.FieldName = "trans_fee"
        Me.GridColumntrans_fee.Name = "GridColumntrans_fee"
        Me.GridColumntrans_fee.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "trans_fee", "{0:N2}")})
        Me.GridColumntrans_fee.Visible = True
        Me.GridColumntrans_fee.VisibleIndex = 11
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Netto"
        Me.GridColumnamount.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 12
        '
        'FormPayoutReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 453)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormPayoutReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payout Report"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnorder_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnorder_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncustomer_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumninv_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumninv_ship_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntrans_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpay_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntype As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntrans_fee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
End Class
