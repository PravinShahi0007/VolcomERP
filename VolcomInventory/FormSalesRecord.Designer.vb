<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesRecord
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesRecord))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnGetData = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewData = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEOutlet = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_departement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnoutlet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_pos_combine = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_pos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_outlet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOutletview = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpos_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnshift_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnuser_employee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsubtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndiscount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvoucher_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvoucher = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncash = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncard = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncard_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncard_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsync_time = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.VolcomMRP.WaitForm), True, True)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEOutlet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnGetData)
        Me.PanelControl1.Controls.Add(Me.BtnViewData)
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.SLEOutlet)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.DEFrom)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1110, 49)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnGetData
        '
        Me.BtnGetData.Image = CType(resources.GetObject("BtnGetData.Image"), System.Drawing.Image)
        Me.BtnGetData.Location = New System.Drawing.Point(665, 12)
        Me.BtnGetData.Name = "BtnGetData"
        Me.BtnGetData.Size = New System.Drawing.Size(75, 23)
        Me.BtnGetData.TabIndex = 8901
        Me.BtnGetData.Text = "Get Data"
        '
        'BtnViewData
        '
        Me.BtnViewData.Image = CType(resources.GetObject("BtnViewData.Image"), System.Drawing.Image)
        Me.BtnViewData.Location = New System.Drawing.Point(577, 12)
        Me.BtnViewData.Name = "BtnViewData"
        Me.BtnViewData.Size = New System.Drawing.Size(84, 23)
        Me.BtnViewData.TabIndex = 1
        Me.BtnViewData.Text = "View Data"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(460, 14)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8899
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl1.TabIndex = 8900
        Me.LabelControl1.Text = "Outlet"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(433, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8897
        Me.LabelControl2.Text = "Until"
        '
        'SLEOutlet
        '
        Me.SLEOutlet.Location = New System.Drawing.Point(51, 14)
        Me.SLEOutlet.Name = "SLEOutlet"
        Me.SLEOutlet.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEOutlet.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEOutlet.Size = New System.Drawing.Size(235, 20)
        Me.SLEOutlet.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_departement, Me.GridColumnoutlet})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_departement
        '
        Me.GridColumnid_departement.Caption = "id"
        Me.GridColumnid_departement.FieldName = "id_outlet"
        Me.GridColumnid_departement.Name = "GridColumnid_departement"
        '
        'GridColumnoutlet
        '
        Me.GridColumnoutlet.Caption = "Outlet"
        Me.GridColumnoutlet.FieldName = "outlet"
        Me.GridColumnoutlet.Name = "GridColumnoutlet"
        Me.GridColumnoutlet.Visible = True
        Me.GridColumnoutlet.VisibleIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(289, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8896
        Me.LabelControl3.Text = "From"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(317, 14)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8898
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 49)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(1110, 408)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_pos_combine, Me.GridColumnid_pos, Me.GridColumnid_outlet, Me.GridColumnOutletview, Me.GridColumnpos_number, Me.GridColumn1, Me.GridColumnshift_type, Me.GridColumnuser_employee, Me.GridColumnsubtotal, Me.GridColumndiscount, Me.GridColumntotal, Me.GridColumnvoucher_number, Me.GridColumnvoucher, Me.GridColumncash, Me.GridColumncard, Me.GridColumncard_type, Me.GridColumncard_name, Me.GridColumntotal_qty, Me.GridColumncountry, Me.GridColumnsync_time, Me.GridColumnsales_name})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_pos_combine
        '
        Me.GridColumnid_pos_combine.Caption = "id_pos_combine"
        Me.GridColumnid_pos_combine.FieldName = "id_pos_combine"
        Me.GridColumnid_pos_combine.Name = "GridColumnid_pos_combine"
        '
        'GridColumnid_pos
        '
        Me.GridColumnid_pos.Caption = "id_pos"
        Me.GridColumnid_pos.FieldName = "id_pos"
        Me.GridColumnid_pos.Name = "GridColumnid_pos"
        '
        'GridColumnid_outlet
        '
        Me.GridColumnid_outlet.Caption = "id_outlet"
        Me.GridColumnid_outlet.FieldName = "id_outlet"
        Me.GridColumnid_outlet.Name = "GridColumnid_outlet"
        '
        'GridColumnOutletview
        '
        Me.GridColumnOutletview.Caption = "Outlet"
        Me.GridColumnOutletview.FieldName = "outlet"
        Me.GridColumnOutletview.Name = "GridColumnOutletview"
        Me.GridColumnOutletview.Visible = True
        Me.GridColumnOutletview.VisibleIndex = 0
        '
        'GridColumnpos_number
        '
        Me.GridColumnpos_number.Caption = "Transaction No."
        Me.GridColumnpos_number.FieldName = "pos_number"
        Me.GridColumnpos_number.Name = "GridColumnpos_number"
        Me.GridColumnpos_number.Visible = True
        Me.GridColumnpos_number.VisibleIndex = 1
        Me.GridColumnpos_number.Width = 140
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Created Date"
        Me.GridColumn1.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1.FieldName = "pos_date"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        '
        'GridColumnshift_type
        '
        Me.GridColumnshift_type.Caption = "Shift"
        Me.GridColumnshift_type.FieldName = "shift_type"
        Me.GridColumnshift_type.Name = "GridColumnshift_type"
        Me.GridColumnshift_type.Visible = True
        Me.GridColumnshift_type.VisibleIndex = 3
        '
        'GridColumnuser_employee
        '
        Me.GridColumnuser_employee.Caption = "User"
        Me.GridColumnuser_employee.FieldName = "user_employee"
        Me.GridColumnuser_employee.Name = "GridColumnuser_employee"
        Me.GridColumnuser_employee.Visible = True
        Me.GridColumnuser_employee.VisibleIndex = 4
        '
        'GridColumnsubtotal
        '
        Me.GridColumnsubtotal.Caption = "Subtotal"
        Me.GridColumnsubtotal.DisplayFormat.FormatString = "N2"
        Me.GridColumnsubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsubtotal.FieldName = "subtotal"
        Me.GridColumnsubtotal.Name = "GridColumnsubtotal"
        Me.GridColumnsubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "subtotal", "{0:N2}")})
        Me.GridColumnsubtotal.Visible = True
        Me.GridColumnsubtotal.VisibleIndex = 6
        '
        'GridColumndiscount
        '
        Me.GridColumndiscount.Caption = "Discount"
        Me.GridColumndiscount.DisplayFormat.FormatString = "N2"
        Me.GridColumndiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndiscount.FieldName = "discount"
        Me.GridColumndiscount.Name = "GridColumndiscount"
        Me.GridColumndiscount.Visible = True
        Me.GridColumndiscount.VisibleIndex = 7
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
        '
        'GridColumnvoucher_number
        '
        Me.GridColumnvoucher_number.Caption = "Voucher No."
        Me.GridColumnvoucher_number.FieldName = "voucher_number"
        Me.GridColumnvoucher_number.Name = "GridColumnvoucher_number"
        Me.GridColumnvoucher_number.Visible = True
        Me.GridColumnvoucher_number.VisibleIndex = 9
        '
        'GridColumnvoucher
        '
        Me.GridColumnvoucher.Caption = "Voucher"
        Me.GridColumnvoucher.DisplayFormat.FormatString = "N2"
        Me.GridColumnvoucher.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnvoucher.FieldName = "voucher"
        Me.GridColumnvoucher.Name = "GridColumnvoucher"
        Me.GridColumnvoucher.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "voucher", "{0:N2}")})
        Me.GridColumnvoucher.Visible = True
        Me.GridColumnvoucher.VisibleIndex = 10
        '
        'GridColumncash
        '
        Me.GridColumncash.Caption = "Cash"
        Me.GridColumncash.DisplayFormat.FormatString = "N2"
        Me.GridColumncash.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumncash.FieldName = "cash"
        Me.GridColumncash.Name = "GridColumncash"
        Me.GridColumncash.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cash", "{0:N2}")})
        Me.GridColumncash.Visible = True
        Me.GridColumncash.VisibleIndex = 11
        '
        'GridColumncard
        '
        Me.GridColumncard.Caption = "Card"
        Me.GridColumncard.DisplayFormat.FormatString = "N2"
        Me.GridColumncard.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumncard.FieldName = "card"
        Me.GridColumncard.Name = "GridColumncard"
        Me.GridColumncard.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "card", "{0:N2}")})
        Me.GridColumncard.Visible = True
        Me.GridColumncard.VisibleIndex = 12
        '
        'GridColumncard_type
        '
        Me.GridColumncard_type.Caption = "Card Type"
        Me.GridColumncard_type.FieldName = "card_type"
        Me.GridColumncard_type.Name = "GridColumncard_type"
        Me.GridColumncard_type.Visible = True
        Me.GridColumncard_type.VisibleIndex = 13
        '
        'GridColumncard_name
        '
        Me.GridColumncard_name.Caption = "Customer Card Name"
        Me.GridColumncard_name.FieldName = "card_name"
        Me.GridColumncard_name.Name = "GridColumncard_name"
        Me.GridColumncard_name.Visible = True
        Me.GridColumncard_name.VisibleIndex = 14
        Me.GridColumncard_name.Width = 114
        '
        'GridColumntotal_qty
        '
        Me.GridColumntotal_qty.Caption = "Qty"
        Me.GridColumntotal_qty.DisplayFormat.FormatString = "N2"
        Me.GridColumntotal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty.FieldName = "total_qty"
        Me.GridColumntotal_qty.Name = "GridColumntotal_qty"
        Me.GridColumntotal_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N2}")})
        Me.GridColumntotal_qty.Visible = True
        Me.GridColumntotal_qty.VisibleIndex = 5
        '
        'GridColumncountry
        '
        Me.GridColumncountry.Caption = "Customer Country"
        Me.GridColumncountry.FieldName = "country"
        Me.GridColumncountry.Name = "GridColumncountry"
        Me.GridColumncountry.Visible = True
        Me.GridColumncountry.VisibleIndex = 15
        Me.GridColumncountry.Width = 117
        '
        'GridColumnsync_time
        '
        Me.GridColumnsync_time.Caption = "Sync Time"
        Me.GridColumnsync_time.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnsync_time.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsync_time.FieldName = "sync_time"
        Me.GridColumnsync_time.Name = "GridColumnsync_time"
        Me.GridColumnsync_time.Visible = True
        Me.GridColumnsync_time.VisibleIndex = 17
        '
        'GridColumnsales_name
        '
        Me.GridColumnsales_name.Caption = "Sales"
        Me.GridColumnsales_name.FieldName = "sales_name"
        Me.GridColumnsales_name.Name = "GridColumnsales_name"
        Me.GridColumnsales_name.Visible = True
        Me.GridColumnsales_name.VisibleIndex = 16
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'FormSalesRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 457)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormSalesRecord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Record"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEOutlet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEOutlet As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BtnGetData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnViewData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents GridColumnid_departement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnoutlet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_pos_combine As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_pos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_outlet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOutletview As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpos_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnshift_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnuser_employee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvoucher_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvoucher As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncash As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncard As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncard_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncard_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsync_time As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_name As DevExpress.XtraGrid.Columns.GridColumn
End Class
