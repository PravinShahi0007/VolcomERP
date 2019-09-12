<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormARAging
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
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEStatusInvoice = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEStoreInvoice = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridColumnsales_pos_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnsales_pos_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnsales_pos_due_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn90 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn90_up = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnpaid_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnpaid_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnon_process = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnrec_payment_status = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumncomp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnpaid = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBandInvoice = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandAgingAR = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandPaid = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandStatus = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStatusInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStoreInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEStoreGroup)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLEStatusInvoice)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.SLEStoreInvoice)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(890, 42)
        Me.PanelControl1.TabIndex = 3
        '
        'SLEStoreGroup
        '
        Me.SLEStoreGroup.Location = New System.Drawing.Point(78, 10)
        Me.SLEStoreGroup.Name = "SLEStoreGroup"
        Me.SLEStoreGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroup.Properties.View = Me.GridView1
        Me.SLEStoreGroup.Size = New System.Drawing.Size(145, 20)
        Me.SLEStoreGroup.TabIndex = 8921
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumncomp_group, Me.GridColumndescription})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 8920
        Me.LabelControl1.Text = "Store Group"
        '
        'SLEStatusInvoice
        '
        Me.SLEStatusInvoice.Location = New System.Drawing.Point(481, 10)
        Me.SLEStatusInvoice.Name = "SLEStatusInvoice"
        Me.SLEStatusInvoice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStatusInvoice.Properties.View = Me.GridView5
        Me.SLEStatusInvoice.Size = New System.Drawing.Size(123, 20)
        Me.SLEStatusInvoice.TabIndex = 8919
        '
        'GridView5
        '
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16, Me.GridColumn17})
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "ID Status payment"
        Me.GridColumn16.FieldName = "id_status_payment"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Status"
        Me.GridColumn17.FieldName = "status_payment"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(444, 13)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl5.TabIndex = 8918
        Me.LabelControl5.Text = "Status"
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(608, 8)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(60, 23)
        Me.BView.TabIndex = 8913
        Me.BView.Text = "view"
        '
        'SLEStoreInvoice
        '
        Me.SLEStoreInvoice.Location = New System.Drawing.Point(261, 10)
        Me.SLEStoreInvoice.Name = "SLEStoreInvoice"
        Me.SLEStoreInvoice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreInvoice.Properties.View = Me.GridView2
        Me.SLEStoreInvoice.Size = New System.Drawing.Size(177, 20)
        Me.SLEStoreInvoice.TabIndex = 8912
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID Comp Contact"
        Me.GridColumn13.FieldName = "id_comp_contact"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Vendor"
        Me.GridColumn14.FieldName = "comp_name"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(229, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Store"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 42)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GCData.Size = New System.Drawing.Size(890, 415)
        Me.GCData.TabIndex = 4
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'GVData
        '
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBandInvoice, Me.gridBandAgingAR, Me.gridBandPaid, Me.gridBandStatus})
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnsales_pos_number, Me.GridColumnsales_pos_date, Me.GridColumnsales_pos_due_date, Me.GridColumn30, Me.GridColumn60, Me.GridColumn90, Me.GridColumn90_up, Me.GridColumnpaid_number, Me.GridColumnpaid_date, Me.GridColumnon_process, Me.GridColumnrec_payment_status, Me.GridColumncomp, Me.GridColumnpaid})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnsales_pos_number
        '
        Me.GridColumnsales_pos_number.Caption = "Invoice No."
        Me.GridColumnsales_pos_number.FieldName = "sales_pos_number"
        Me.GridColumnsales_pos_number.Name = "GridColumnsales_pos_number"
        Me.GridColumnsales_pos_number.Visible = True
        '
        'GridColumnsales_pos_date
        '
        Me.GridColumnsales_pos_date.Caption = "Created Date"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_date.FieldName = "sales_pos_date"
        Me.GridColumnsales_pos_date.Name = "GridColumnsales_pos_date"
        Me.GridColumnsales_pos_date.Visible = True
        '
        'GridColumnsales_pos_due_date
        '
        Me.GridColumnsales_pos_due_date.Caption = "Due Date"
        Me.GridColumnsales_pos_due_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_due_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_due_date.FieldName = "sales_pos_due_date"
        Me.GridColumnsales_pos_due_date.Name = "GridColumnsales_pos_due_date"
        Me.GridColumnsales_pos_due_date.Visible = True
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "0 - 30"
        Me.GridColumn30.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn30.DisplayFormat.FormatString = "N2"
        Me.GridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn30.FieldName = "30"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "30", "{0:N2}")})
        Me.GridColumn30.Visible = True
        '
        'GridColumn60
        '
        Me.GridColumn60.Caption = "31 - 60"
        Me.GridColumn60.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn60.DisplayFormat.FormatString = "N2"
        Me.GridColumn60.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn60.FieldName = "60"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "60", "{0:N2}")})
        Me.GridColumn60.Visible = True
        '
        'GridColumn90
        '
        Me.GridColumn90.Caption = "61 - 90"
        Me.GridColumn90.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn90.DisplayFormat.FormatString = "N2"
        Me.GridColumn90.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn90.FieldName = "90"
        Me.GridColumn90.Name = "GridColumn90"
        Me.GridColumn90.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "90", "{0:N2}")})
        Me.GridColumn90.Visible = True
        '
        'GridColumn90_up
        '
        Me.GridColumn90_up.Caption = ">90"
        Me.GridColumn90_up.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn90_up.DisplayFormat.FormatString = "N2"
        Me.GridColumn90_up.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn90_up.FieldName = "90_up"
        Me.GridColumn90_up.Name = "GridColumn90_up"
        Me.GridColumn90_up.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "90_up", "{0:N2}")})
        Me.GridColumn90_up.Visible = True
        '
        'GridColumnpaid_number
        '
        Me.GridColumnpaid_number.Caption = "Payment No."
        Me.GridColumnpaid_number.FieldName = "paid_number"
        Me.GridColumnpaid_number.Name = "GridColumnpaid_number"
        Me.GridColumnpaid_number.Visible = True
        '
        'GridColumnpaid_date
        '
        Me.GridColumnpaid_date.Caption = "Paid Date"
        Me.GridColumnpaid_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnpaid_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnpaid_date.FieldName = "paid_date"
        Me.GridColumnpaid_date.Name = "GridColumnpaid_date"
        Me.GridColumnpaid_date.Visible = True
        '
        'GridColumnon_process
        '
        Me.GridColumnon_process.Caption = "On Process"
        Me.GridColumnon_process.FieldName = "on_process"
        Me.GridColumnon_process.Name = "GridColumnon_process"
        Me.GridColumnon_process.Visible = True
        '
        'GridColumnrec_payment_status
        '
        Me.GridColumnrec_payment_status.Caption = "Status"
        Me.GridColumnrec_payment_status.FieldName = "rec_payment_status"
        Me.GridColumnrec_payment_status.Name = "GridColumnrec_payment_status"
        Me.GridColumnrec_payment_status.Visible = True
        '
        'GridColumncomp
        '
        Me.GridColumncomp.Caption = "Store"
        Me.GridColumncomp.FieldName = "comp"
        Me.GridColumncomp.Name = "GridColumncomp"
        Me.GridColumncomp.Visible = True
        '
        'GridColumnpaid
        '
        Me.GridColumnpaid.Caption = "Paid"
        Me.GridColumnpaid.DisplayFormat.FormatString = "N2"
        Me.GridColumnpaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpaid.FieldName = "paid"
        Me.GridColumnpaid.Name = "GridColumnpaid"
        Me.GridColumnpaid.Visible = True
        '
        'GridBandInvoice
        '
        Me.GridBandInvoice.Caption = "INVOICE"
        Me.GridBandInvoice.Columns.Add(Me.GridColumnsales_pos_number)
        Me.GridBandInvoice.Columns.Add(Me.GridColumncomp)
        Me.GridBandInvoice.Columns.Add(Me.GridColumnsales_pos_date)
        Me.GridBandInvoice.Columns.Add(Me.GridColumnsales_pos_due_date)
        Me.GridBandInvoice.Name = "GridBandInvoice"
        Me.GridBandInvoice.VisibleIndex = 0
        Me.GridBandInvoice.Width = 300
        '
        'gridBandAgingAR
        '
        Me.gridBandAgingAR.Caption = "AGING AR"
        Me.gridBandAgingAR.Columns.Add(Me.GridColumn30)
        Me.gridBandAgingAR.Columns.Add(Me.GridColumn60)
        Me.gridBandAgingAR.Columns.Add(Me.GridColumn90)
        Me.gridBandAgingAR.Columns.Add(Me.GridColumn90_up)
        Me.gridBandAgingAR.Name = "gridBandAgingAR"
        Me.gridBandAgingAR.VisibleIndex = 1
        Me.gridBandAgingAR.Width = 300
        '
        'gridBandPaid
        '
        Me.gridBandPaid.Caption = "PAID"
        Me.gridBandPaid.Columns.Add(Me.GridColumnpaid_number)
        Me.gridBandPaid.Columns.Add(Me.GridColumnpaid)
        Me.gridBandPaid.Columns.Add(Me.GridColumnpaid_date)
        Me.gridBandPaid.Columns.Add(Me.GridColumnon_process)
        Me.gridBandPaid.Name = "gridBandPaid"
        Me.gridBandPaid.VisibleIndex = 2
        Me.gridBandPaid.Width = 300
        '
        'gridBandStatus
        '
        Me.gridBandStatus.Columns.Add(Me.GridColumnrec_payment_status)
        Me.gridBandStatus.Name = "gridBandStatus"
        Me.gridBandStatus.VisibleIndex = 3
        Me.gridBandStatus.Width = 75
        '
        'FormARAging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 457)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormARAging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AR Report"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStatusInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStoreInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEStatusInvoice As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEStoreInvoice As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents SLEStoreGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBandInvoice As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumnsales_pos_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumncomp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnsales_pos_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnsales_pos_due_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandAgingAR As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn90 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn90_up As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandPaid As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumnpaid_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnpaid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnpaid_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnon_process As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandStatus As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumnrec_payment_status As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
