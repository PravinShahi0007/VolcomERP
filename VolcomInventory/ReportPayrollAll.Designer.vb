<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportPayrollAll
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportPayrollAll))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCPayroll = New DevExpress.XtraGrid.GridControl()
        Me.GVPayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnActWorkdays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalAdjustment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalDeduction = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalPaymentOt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTotTHP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICEPending = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RICESelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.BandedGridColumnBasicSalaryDW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnActWorkdaysDW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBEmployee = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GBWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GBSalary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GBDW = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GBGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 260.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1119.0!, 260.0!)
        Me.WinControlContainer1.WinControl = Me.GCPayroll
        '
        'GCPayroll
        '
        Me.GCPayroll.Location = New System.Drawing.Point(0, 39)
        Me.GCPayroll.MainView = Me.GVPayroll
        Me.GCPayroll.Name = "GCPayroll"
        Me.GCPayroll.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEPending, Me.RICESelect})
        Me.GCPayroll.Size = New System.Drawing.Size(1074, 250)
        Me.GCPayroll.TabIndex = 1
        Me.GCPayroll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayroll})
        '
        'GVPayroll
        '
        Me.GVPayroll.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayroll.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.BandPanel.Options.UseFont = True
        Me.GVPayroll.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayroll.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVPayroll.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayroll.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVPayroll.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayroll.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVPayroll.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayroll.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVPayroll.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayroll.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.Row.Options.UseFont = True
        Me.GVPayroll.BandPanelRowHeight = 16
        Me.GVPayroll.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GBEmployee, Me.GBWorkingDays, Me.GBSalary, Me.GBDW, Me.GBGrandTotal})
        Me.GVPayroll.ColumnPanelRowHeight = 32
        Me.GVPayroll.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnDepartement, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnPosition, Me.GridColumnLevel, Me.GridColumnWorkingDays, Me.BandedGridColumnActWorkdays, Me.GridColumnTotTHP, Me.BandedGridColumnTotalAdjustment, Me.BandedGridColumnTotalDeduction, Me.BandedGridColumnTotalPaymentOt, Me.BandedGridColumnActWorkdaysDW, Me.BandedGridColumnBasicSalaryDW, Me.BandedGridColumnGrandTotal})
        Me.GVPayroll.GridControl = Me.GCPayroll
        Me.GVPayroll.GroupCount = 1
        Me.GVPayroll.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", Me.GridColumnTotTHP, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", Me.BandedGridColumnTotalAdjustment, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", Me.BandedGridColumnTotalDeduction, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", Me.BandedGridColumnTotalPaymentOt, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", Me.BandedGridColumnGrandTotal, "{0:N0}")})
        Me.GVPayroll.Name = "GVPayroll"
        Me.GVPayroll.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPayroll.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GVPayroll.OptionsPrint.AllowMultilineHeaders = True
        Me.GVPayroll.OptionsView.ColumnAutoWidth = False
        Me.GVPayroll.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPayroll.OptionsView.ShowFooter = True
        Me.GVPayroll.OptionsView.ShowGroupPanel = False
        Me.GVPayroll.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.OptionsColumn.AllowEdit = False
        Me.GridColumnNIP.Visible = True
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Employee"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Departement"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.OptionsColumn.AllowEdit = False
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.Caption = "Employee Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.OptionsColumn.AllowEdit = False
        Me.GridColumnPosition.Visible = True
        Me.GridColumnPosition.Width = 96
        '
        'GridColumnLevel
        '
        Me.GridColumnLevel.Caption = "Employee Level"
        Me.GridColumnLevel.FieldName = "employee_level"
        Me.GridColumnLevel.Name = "GridColumnLevel"
        Me.GridColumnLevel.OptionsColumn.AllowEdit = False
        Me.GridColumnLevel.Visible = True
        Me.GridColumnLevel.Width = 84
        '
        'GridColumnWorkingDays
        '
        Me.GridColumnWorkingDays.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnWorkingDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnWorkingDays.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnWorkingDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnWorkingDays.Caption = "Working Days"
        Me.GridColumnWorkingDays.DisplayFormat.FormatString = "N1"
        Me.GridColumnWorkingDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnWorkingDays.FieldName = "workdays"
        Me.GridColumnWorkingDays.Name = "GridColumnWorkingDays"
        Me.GridColumnWorkingDays.OptionsColumn.AllowEdit = False
        Me.GridColumnWorkingDays.Visible = True
        Me.GridColumnWorkingDays.Width = 76
        '
        'BandedGridColumnActWorkdays
        '
        Me.BandedGridColumnActWorkdays.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnActWorkdays.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnActWorkdays.Caption = "Actual Working Days"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnActWorkdays.FieldName = "actual_workdays"
        Me.BandedGridColumnActWorkdays.Name = "BandedGridColumnActWorkdays"
        Me.BandedGridColumnActWorkdays.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnActWorkdays.Visible = True
        Me.BandedGridColumnActWorkdays.Width = 109
        '
        'BandedGridColumnTotalAdjustment
        '
        Me.BandedGridColumnTotalAdjustment.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalAdjustment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalAdjustment.Caption = "Total Bonus / Adjustment"
        Me.BandedGridColumnTotalAdjustment.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalAdjustment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalAdjustment.FieldName = "total_adjustment"
        Me.BandedGridColumnTotalAdjustment.Name = "BandedGridColumnTotalAdjustment"
        Me.BandedGridColumnTotalAdjustment.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalAdjustment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", "{0:N0}")})
        Me.BandedGridColumnTotalAdjustment.Visible = True
        Me.BandedGridColumnTotalAdjustment.Width = 131
        '
        'BandedGridColumnTotalDeduction
        '
        Me.BandedGridColumnTotalDeduction.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalDeduction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalDeduction.Caption = "Total Deduction"
        Me.BandedGridColumnTotalDeduction.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalDeduction.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalDeduction.FieldName = "total_deduction"
        Me.BandedGridColumnTotalDeduction.Name = "BandedGridColumnTotalDeduction"
        Me.BandedGridColumnTotalDeduction.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalDeduction.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", "{0:N0}")})
        Me.BandedGridColumnTotalDeduction.Visible = True
        Me.BandedGridColumnTotalDeduction.Width = 90
        '
        'BandedGridColumnTotalPaymentOt
        '
        Me.BandedGridColumnTotalPaymentOt.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalPaymentOt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalPaymentOt.Caption = "Total Overtime"
        Me.BandedGridColumnTotalPaymentOt.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalPaymentOt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalPaymentOt.FieldName = "total_ot_wages"
        Me.BandedGridColumnTotalPaymentOt.Name = "BandedGridColumnTotalPaymentOt"
        Me.BandedGridColumnTotalPaymentOt.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalPaymentOt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", "{0:N0}")})
        Me.BandedGridColumnTotalPaymentOt.Visible = True
        Me.BandedGridColumnTotalPaymentOt.Width = 110
        '
        'GridColumnTotTHP
        '
        Me.GridColumnTotTHP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.Caption = "Total Salary"
        Me.GridColumnTotTHP.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotTHP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotTHP.FieldName = "tot_thp"
        Me.GridColumnTotTHP.Name = "GridColumnTotTHP"
        Me.GridColumnTotTHP.OptionsColumn.AllowEdit = False
        Me.GridColumnTotTHP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", "{0:N0}")})
        Me.GridColumnTotTHP.Visible = True
        '
        'BandedGridColumnGrandTotal
        '
        Me.BandedGridColumnGrandTotal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.Caption = "Grand Total"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnGrandTotal.FieldName = "grand_total"
        Me.BandedGridColumnGrandTotal.Name = "BandedGridColumnGrandTotal"
        Me.BandedGridColumnGrandTotal.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnGrandTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", "{0:N0}")})
        Me.BandedGridColumnGrandTotal.Visible = True
        '
        'RICEPending
        '
        Me.RICEPending.AutoHeight = False
        Me.RICEPending.Name = "RICEPending"
        Me.RICEPending.ValueChecked = "yes"
        Me.RICEPending.ValueUnchecked = "no"
        '
        'RICESelect
        '
        Me.RICESelect.AutoHeight = False
        Me.RICESelect.Name = "RICESelect"
        Me.RICESelect.ValueChecked = "yes"
        Me.RICESelect.ValueUnchecked = "no"
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.XLTitle, Me.XLPeriod, Me.XrLine1})
        Me.TopMargin.HeightF = 75.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0.00003973643!, 10.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(220.0!, 41.15!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XLTitle
        '
        Me.XLTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XLTitle.LocationFloat = New DevExpress.Utils.PointFloat(220.0!, 20.0!)
        Me.XLTitle.Name = "XLTitle"
        Me.XLTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTitle.SizeF = New System.Drawing.SizeF(679.0001!, 23.0!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.StylePriority.UseTextAlignment = False
        Me.XLTitle.Text = "Payroll"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(899.0!, 20.0!)
        Me.XLPeriod.Name = "XLPeriod"
        Me.XLPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLPeriod.SizeF = New System.Drawing.SizeF(220.0!, 23.0!)
        Me.XLPeriod.StylePriority.UseFont = False
        Me.XLPeriod.StylePriority.UseTextAlignment = False
        Me.XLPeriod.Text = "[period]"
        Me.XLPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.00003973643!, 51.15!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1119.0!, 23.0!)
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.Name = "SqlDataSource1"
        '
        'BandedGridColumnBasicSalaryDW
        '
        Me.BandedGridColumnBasicSalaryDW.Caption = "Daily Salary"
        Me.BandedGridColumnBasicSalaryDW.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnBasicSalaryDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnBasicSalaryDW.FieldName = "basic_salary"
        Me.BandedGridColumnBasicSalaryDW.Name = "BandedGridColumnBasicSalaryDW"
        Me.BandedGridColumnBasicSalaryDW.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnBasicSalaryDW.Visible = True
        '
        'BandedGridColumnActWorkdaysDW
        '
        Me.BandedGridColumnActWorkdaysDW.Caption = "Actual Working Days"
        Me.BandedGridColumnActWorkdaysDW.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnActWorkdaysDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnActWorkdaysDW.FieldName = "actual_workdays"
        Me.BandedGridColumnActWorkdaysDW.Name = "BandedGridColumnActWorkdaysDW"
        Me.BandedGridColumnActWorkdaysDW.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnActWorkdaysDW.Visible = True
        Me.BandedGridColumnActWorkdaysDW.Width = 109
        '
        'GBEmployee
        '
        Me.GBEmployee.Caption = "Employee"
        Me.GBEmployee.Columns.Add(Me.GridColumnNIP)
        Me.GBEmployee.Columns.Add(Me.GridColumnName)
        Me.GBEmployee.Columns.Add(Me.GridColumnDepartement)
        Me.GBEmployee.Columns.Add(Me.GridColumnPosition)
        Me.GBEmployee.Columns.Add(Me.GridColumnLevel)
        Me.GBEmployee.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GBEmployee.Name = "GBEmployee"
        Me.GBEmployee.VisibleIndex = 0
        Me.GBEmployee.Width = 330
        '
        'GBWorkingDays
        '
        Me.GBWorkingDays.AppearanceHeader.Options.UseTextOptions = True
        Me.GBWorkingDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBWorkingDays.Caption = "Working Days"
        Me.GBWorkingDays.Columns.Add(Me.GridColumnWorkingDays)
        Me.GBWorkingDays.Columns.Add(Me.BandedGridColumnActWorkdays)
        Me.GBWorkingDays.Name = "GBWorkingDays"
        Me.GBWorkingDays.VisibleIndex = 1
        Me.GBWorkingDays.Width = 185
        '
        'GBSalary
        '
        Me.GBSalary.AppearanceHeader.Options.UseTextOptions = True
        Me.GBSalary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBSalary.Columns.Add(Me.BandedGridColumnTotalAdjustment)
        Me.GBSalary.Columns.Add(Me.BandedGridColumnTotalDeduction)
        Me.GBSalary.Columns.Add(Me.BandedGridColumnTotalPaymentOt)
        Me.GBSalary.Columns.Add(Me.GridColumnTotTHP)
        Me.GBSalary.Name = "GBSalary"
        Me.GBSalary.VisibleIndex = 2
        Me.GBSalary.Width = 406
        '
        'GBDW
        '
        Me.GBDW.Columns.Add(Me.BandedGridColumnActWorkdaysDW)
        Me.GBDW.Columns.Add(Me.BandedGridColumnBasicSalaryDW)
        Me.GBDW.Name = "GBDW"
        Me.GBDW.VisibleIndex = 3
        Me.GBDW.Width = 184
        '
        'GBGrandTotal
        '
        Me.GBGrandTotal.Columns.Add(Me.BandedGridColumnGrandTotal)
        Me.GBGrandTotal.Name = "GBGrandTotal"
        Me.GBGrandTotal.VisibleIndex = 4
        Me.GBGrandTotal.Width = 75
        '
        'ReportPayrollAll
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.SqlDataSource1})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 75, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        Me.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCPayroll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayroll As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumnNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnLevel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnTotTHP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalAdjustment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalDeduction As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalPaymentOt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnGrandTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RICEPending As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RICESelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents BandedGridColumnActWorkdays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnActWorkdaysDW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnBasicSalaryDW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBEmployee As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBSalary As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBDW As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBGrandTotal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
