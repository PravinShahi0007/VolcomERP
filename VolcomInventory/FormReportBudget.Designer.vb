<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportBudget
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportBudget))
        Me.GCItemCat = New DevExpress.XtraGrid.GridControl()
        Me.GVItemCat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridBudgetUsage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LEYear = New DevExpress.XtraEditors.LookUpEdit()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SLEMainCategory = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEDepartement = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelChart = New DevExpress.XtraEditors.PanelControl()
        Me.LookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtActual = New DevExpress.XtraEditors.TextEdit()
        Me.TxtBudget = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GaugeControl1 = New DevExpress.XtraGauges.Win.GaugeControl()
        Me.CircularGauge1 = New DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge()
        Me.LabelComponent3 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
        Me.ArcScaleRangeBarComponent3 = New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent()
        Me.ArcScaleComponent3 = New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent()
        CType(Me.GCItemCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEMainCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelChart.SuspendLayout()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtActual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CircularGauge1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelComponent3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArcScaleRangeBarComponent3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArcScaleComponent3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCItemCat
        '
        Me.GCItemCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemCat.Location = New System.Drawing.Point(0, 219)
        Me.GCItemCat.MainView = Me.GVItemCat
        Me.GCItemCat.Name = "GCItemCat"
        Me.GCItemCat.Size = New System.Drawing.Size(1017, 323)
        Me.GCItemCat.TabIndex = 2
        Me.GCItemCat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemCat})
        '
        'GVItemCat
        '
        Me.GVItemCat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn1, Me.GridColumn7, Me.GridColumn10, Me.GridBudgetUsage, Me.GridColumn2, Me.GridColumn3, Me.GridColumn11, Me.GridColumn12, Me.GridColumn8})
        Me.GVItemCat.GridControl = Me.GCItemCat
        Me.GVItemCat.Name = "GVItemCat"
        Me.GVItemCat.OptionsBehavior.Editable = False
        Me.GVItemCat.OptionsFind.AlwaysVisible = True
        Me.GVItemCat.OptionsView.ShowFooter = True
        Me.GVItemCat.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id"
        Me.GridColumn6.FieldName = "id_item_cat_main"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Departement"
        Me.GridColumn1.FieldName = "departement"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Expense Type"
        Me.GridColumn7.FieldName = "expense_type"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Main Category"
        Me.GridColumn10.FieldName = "main_cat"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 1
        '
        'GridBudgetUsage
        '
        Me.GridBudgetUsage.AppearanceCell.Options.UseTextOptions = True
        Me.GridBudgetUsage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridBudgetUsage.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBudgetUsage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridBudgetUsage.Caption = "Budget"
        Me.GridBudgetUsage.DisplayFormat.FormatString = "N2"
        Me.GridBudgetUsage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridBudgetUsage.FieldName = "budget"
        Me.GridBudgetUsage.Name = "GridBudgetUsage"
        Me.GridBudgetUsage.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget", "{0:N2}")})
        Me.GridBudgetUsage.Visible = True
        Me.GridBudgetUsage.VisibleIndex = 3
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Booked Budget (PO)"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "po_booked"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "po_booked", "{0:N2}")})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Actual (Receiving)"
        Me.GridColumn3.DisplayFormat.FormatString = "N2"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "rec"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rec", "{0:N2}")})
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 5
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.Caption = "Total Used Budget"
        Me.GridColumn11.DisplayFormat.FormatString = "N2"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "val_used"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "val_used", "{0:N2}")})
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 6
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn12.Caption = "Remaining Budget"
        Me.GridColumn12.DisplayFormat.FormatString = "N2"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "val_remaining"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "val_remaining", "{0:N2}")})
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 7
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Budget Used"
        Me.GridColumn8.DisplayFormat.FormatString = "{0:N2} %"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "used_percent"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 8
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LEYear)
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.SLEMainCategory)
        Me.PanelControl1.Controls.Add(Me.SLEDepartement)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1017, 45)
        Me.PanelControl1.TabIndex = 3
        '
        'LEYear
        '
        Me.LEYear.Location = New System.Drawing.Point(293, 14)
        Me.LEYear.Name = "LEYear"
        Me.LEYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEYear.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("year", "Year")})
        Me.LEYear.Size = New System.Drawing.Size(125, 20)
        Me.LEYear.TabIndex = 8915
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(468, 14)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(127, 20)
        Me.DEUntil.TabIndex = 8914
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(424, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 8913
        Me.Label4.Text = "Until : "
        '
        'SLEMainCategory
        '
        Me.SLEMainCategory.Location = New System.Drawing.Point(677, 14)
        Me.SLEMainCategory.Name = "SLEMainCategory"
        Me.SLEMainCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEMainCategory.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEMainCategory.Size = New System.Drawing.Size(192, 20)
        Me.SLEMainCategory.TabIndex = 8912
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5, Me.GridColumn9})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID"
        Me.GridColumn4.FieldName = "id_item_cat_main"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Main Category"
        Me.GridColumn5.FieldName = "item_cat_main"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Expense Type"
        Me.GridColumn9.FieldName = "expense_type"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        '
        'SLEDepartement
        '
        Me.SLEDepartement.Location = New System.Drawing.Point(82, 14)
        Me.SLEDepartement.Name = "SLEDepartement"
        Me.SLEDepartement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDepartement.Properties.View = Me.GridView2
        Me.SLEDepartement.Size = New System.Drawing.Size(177, 20)
        Me.SLEDepartement.TabIndex = 8910
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
        Me.GridColumn13.Caption = "ID Departement"
        Me.GridColumn13.FieldName = "id_departement"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Departement"
        Me.GridColumn14.FieldName = "departement"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(265, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl2.TabIndex = 28
        Me.LabelControl2.Text = "Year"
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(875, 12)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 27
        Me.BtnView.Text = "View"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(601, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl1.TabIndex = 25
        Me.LabelControl1.Text = "Main Category"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl6.TabIndex = 23
        Me.LabelControl6.Text = "Departement"
        '
        'PanelChart
        '
        Me.PanelChart.Controls.Add(Me.LookUpEdit1)
        Me.PanelChart.Controls.Add(Me.Label3)
        Me.PanelChart.Controls.Add(Me.TxtActual)
        Me.PanelChart.Controls.Add(Me.TxtBudget)
        Me.PanelChart.Controls.Add(Me.Label2)
        Me.PanelChart.Controls.Add(Me.Label1)
        Me.PanelChart.Controls.Add(Me.LabelControl3)
        Me.PanelChart.Controls.Add(Me.GaugeControl1)
        Me.PanelChart.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelChart.Location = New System.Drawing.Point(0, 45)
        Me.PanelChart.Name = "PanelChart"
        Me.PanelChart.Size = New System.Drawing.Size(1017, 174)
        Me.PanelChart.TabIndex = 7
        Me.PanelChart.Visible = False
        '
        'LookUpEdit1
        '
        Me.LookUpEdit1.Location = New System.Drawing.Point(250, 61)
        Me.LookUpEdit1.Name = "LookUpEdit1"
        Me.LookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit1.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_item_cat", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("item_cat", "Category")})
        Me.LookUpEdit1.Size = New System.Drawing.Size(232, 20)
        Me.LookUpEdit1.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(177, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Used"
        '
        'TxtActual
        '
        Me.TxtActual.Enabled = False
        Me.TxtActual.Location = New System.Drawing.Point(250, 120)
        Me.TxtActual.Name = "TxtActual"
        Me.TxtActual.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtActual.Properties.Appearance.Options.UseFont = True
        Me.TxtActual.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtActual.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtActual.Size = New System.Drawing.Size(314, 22)
        Me.TxtActual.TabIndex = 8
        '
        'TxtBudget
        '
        Me.TxtBudget.Enabled = False
        Me.TxtBudget.Location = New System.Drawing.Point(250, 90)
        Me.TxtBudget.Name = "TxtBudget"
        Me.TxtBudget.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBudget.Properties.Appearance.Options.UseFont = True
        Me.TxtBudget.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtBudget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtBudget.Size = New System.Drawing.Size(314, 22)
        Me.TxtBudget.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(177, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Budget"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(177, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Options"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(180, 13)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(189, 32)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Budget Summary"
        '
        'GaugeControl1
        '
        Me.GaugeControl1.BackColor = System.Drawing.Color.Transparent
        Me.GaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.GaugeControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GaugeControl1.Gauges.AddRange(New DevExpress.XtraGauges.Base.IGauge() {Me.CircularGauge1})
        Me.GaugeControl1.Location = New System.Drawing.Point(2, 2)
        Me.GaugeControl1.Name = "GaugeControl1"
        Me.GaugeControl1.Size = New System.Drawing.Size(160, 170)
        Me.GaugeControl1.TabIndex = 2
        '
        'CircularGauge1
        '
        Me.CircularGauge1.Bounds = New System.Drawing.Rectangle(6, 6, 148, 158)
        Me.CircularGauge1.Labels.AddRange(New DevExpress.XtraGauges.Win.Base.LabelComponent() {Me.LabelComponent3})
        Me.CircularGauge1.Name = "CircularGauge1"
        Me.CircularGauge1.RangeBars.AddRange(New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent() {Me.ArcScaleRangeBarComponent3})
        Me.CircularGauge1.Scales.AddRange(New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent() {Me.ArcScaleComponent3})
        '
        'LabelComponent3
        '
        Me.LabelComponent3.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 27.75!)
        Me.LabelComponent3.Name = "circularGauge1_Label1"
        Me.LabelComponent3.Size = New System.Drawing.SizeF(140.0!, 60.0!)
        Me.LabelComponent3.Text = "0%"
        Me.LabelComponent3.UseColorScheme = False
        Me.LabelComponent3.ZOrder = -1001
        '
        'ArcScaleRangeBarComponent3
        '
        Me.ArcScaleRangeBarComponent3.ArcScale = Me.ArcScaleComponent3
        Me.ArcScaleRangeBarComponent3.Name = "circularGauge1_RangeBar2"
        Me.ArcScaleRangeBarComponent3.RoundedCaps = True
        Me.ArcScaleRangeBarComponent3.ShowBackground = True
        Me.ArcScaleRangeBarComponent3.StartOffset = 80.0!
        Me.ArcScaleRangeBarComponent3.ZOrder = -10
        '
        'ArcScaleComponent3
        '
        Me.ArcScaleComponent3.AppearanceMajorTickmark.BorderBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
        Me.ArcScaleComponent3.AppearanceMajorTickmark.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
        Me.ArcScaleComponent3.AppearanceMinorTickmark.BorderBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
        Me.ArcScaleComponent3.AppearanceMinorTickmark.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
        Me.ArcScaleComponent3.AppearanceTickmarkText.Font = New System.Drawing.Font("Tahoma", 8.5!)
        Me.ArcScaleComponent3.AppearanceTickmarkText.TextBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A")
        Me.ArcScaleComponent3.Center = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 125.0!)
        Me.ArcScaleComponent3.EndAngle = 90.0!
        Me.ArcScaleComponent3.MajorTickCount = 0
        Me.ArcScaleComponent3.MajorTickmark.FormatString = "{0:F0}"
        Me.ArcScaleComponent3.MajorTickmark.ShapeOffset = -14.0!
        Me.ArcScaleComponent3.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1
        Me.ArcScaleComponent3.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight
        Me.ArcScaleComponent3.MaxValue = 100.0!
        Me.ArcScaleComponent3.MinorTickCount = 0
        Me.ArcScaleComponent3.MinorTickmark.ShapeOffset = -7.0!
        Me.ArcScaleComponent3.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2
        Me.ArcScaleComponent3.Name = "scale1"
        Me.ArcScaleComponent3.StartAngle = -270.0!
        '
        'FormReportBudget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 542)
        Me.Controls.Add(Me.GCItemCat)
        Me.Controls.Add(Me.PanelChart)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportBudget"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report Budget"
        CType(Me.GCItemCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEMainCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelChart.ResumeLayout(False)
        Me.PanelChart.PerformLayout()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtActual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CircularGauge1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelComponent3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArcScaleRangeBarComponent3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArcScaleComponent3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCItemCat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemCat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridBudgetUsage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelChart As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtActual As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtBudget As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GaugeControl1 As DevExpress.XtraGauges.Win.GaugeControl
    Friend WithEvents CircularGauge1 As DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge
    Private WithEvents LabelComponent3 As DevExpress.XtraGauges.Win.Base.LabelComponent
    Private WithEvents ArcScaleRangeBarComponent3 As DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent
    Private WithEvents ArcScaleComponent3 As DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent
    Friend WithEvents LookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEDepartement As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEMainCategory As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents LEYear As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
End Class
