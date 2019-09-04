<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpPayrollReportPajak
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollReportPajak))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCPajak = New DevExpress.XtraGrid.GridControl()
        Me.GVPajak = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnActWorkdays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnOvertimeHours = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBSalary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnTotTHP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalAdjustment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalPaymentOt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotal1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnTotalDeduction = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotal2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBTotal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnJHT = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJKK = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJKM = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnBPJS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalJamsostek1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalJamsostek2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnGroup = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCPajak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPajak, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1008, 46)
        Me.PanelControl1.TabIndex = 5
        '
        'SBPrint
        '
        Me.SBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrint.Image = CType(resources.GetObject("SBPrint.Image"), System.Drawing.Image)
        Me.SBPrint.Location = New System.Drawing.Point(921, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(85, 42)
        Me.SBPrint.TabIndex = 0
        Me.SBPrint.Text = "Print"
        '
        'GCPajak
        '
        Me.GCPajak.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPajak.Location = New System.Drawing.Point(0, 46)
        Me.GCPajak.MainView = Me.GVPajak
        Me.GCPajak.Name = "GCPajak"
        Me.GCPajak.Size = New System.Drawing.Size(1008, 683)
        Me.GCPajak.TabIndex = 6
        Me.GCPajak.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPajak})
        '
        'GVPajak
        '
        Me.GVPajak.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPajak.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.BandPanel.Options.UseFont = True
        Me.GVPajak.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPajak.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVPajak.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPajak.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVPajak.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPajak.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVPajak.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPajak.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVPajak.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPajak.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.Row.Options.UseFont = True
        Me.GVPajak.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand8, Me.GBWorkingDays, Me.GBSalary, Me.gridBand1, Me.GBTotal, Me.gridBand2})
        Me.GVPajak.ColumnPanelRowHeight = 32
        Me.GVPajak.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnGroup, Me.BandedGridColumnDepartement, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnPosition, Me.GridColumnStatus, Me.BandedGridColumnActWorkdays, Me.BandedGridColumnOvertimeHours, Me.GridColumnTotTHP, Me.BandedGridColumnTotalAdjustment, Me.BandedGridColumnTotalPaymentOt, Me.BandedGridColumnTotal1, Me.BandedGridColumnTotalDeduction, Me.BandedGridColumnTotal2, Me.BandedGridColumnGrandTotal, Me.BandedGridColumnJHT, Me.BandedGridColumnJKK, Me.BandedGridColumnJKM, Me.BandedGridColumnJP, Me.BandedGridColumnBPJS, Me.BandedGridColumnTotalJamsostek1, Me.BandedGridColumnTotalJamsostek2})
        Me.GVPajak.GridControl = Me.GCPajak
        Me.GVPajak.GroupCount = 1
        Me.GVPajak.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", Me.GridColumnTotTHP, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", Me.BandedGridColumnTotalAdjustment, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", Me.BandedGridColumnTotalPaymentOt, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_1", Me.BandedGridColumnTotal1, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", Me.BandedGridColumnTotalDeduction, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_2", Me.BandedGridColumnTotal2, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", Me.BandedGridColumnGrandTotal, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jht", Me.BandedGridColumnJHT, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jkk", Me.BandedGridColumnJKK, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jkm", Me.BandedGridColumnJKM, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jp", Me.BandedGridColumnJP, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bpjs", Me.BandedGridColumnBPJS, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_jamsostek1", Me.BandedGridColumnTotalJamsostek1, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_jamsostek2", Me.BandedGridColumnTotalJamsostek2, "{0:N0}")})
        Me.GVPajak.LevelIndent = 0
        Me.GVPajak.Name = "GVPajak"
        Me.GVPajak.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPajak.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GVPajak.OptionsPrint.AllowMultilineHeaders = True
        Me.GVPajak.OptionsView.ColumnAutoWidth = False
        Me.GVPajak.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPajak.OptionsView.ShowFooter = True
        Me.GVPajak.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVPajak.OptionsView.ShowGroupPanel = False
        Me.GVPajak.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumnDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'gridBand8
        '
        Me.gridBand8.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand8.Caption = "Employee"
        Me.gridBand8.Columns.Add(Me.GridColumnNIP)
        Me.gridBand8.Columns.Add(Me.GridColumnName)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnDepartement)
        Me.gridBand8.Columns.Add(Me.GridColumnPosition)
        Me.gridBand8.Columns.Add(Me.GridColumnStatus)
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 0
        Me.gridBand8.Width = 430
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNIP.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.OptionsColumn.AllowEdit = False
        Me.GridColumnNIP.Visible = True
        Me.GridColumnNIP.Width = 83
        '
        'GridColumnName
        '
        Me.GridColumnName.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnName.Caption = "Employee"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        '
        'BandedGridColumnDepartement
        '
        Me.BandedGridColumnDepartement.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDepartement.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnDepartement.Caption = "Departement"
        Me.BandedGridColumnDepartement.FieldName = "departement"
        Me.BandedGridColumnDepartement.Name = "BandedGridColumnDepartement"
        Me.BandedGridColumnDepartement.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnDepartement.Visible = True
        Me.BandedGridColumnDepartement.Width = 86
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPosition.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnPosition.Caption = "Employee Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.OptionsColumn.AllowEdit = False
        Me.GridColumnPosition.Visible = True
        Me.GridColumnPosition.Width = 96
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnStatus.Caption = "Employee Status"
        Me.GridColumnStatus.FieldName = "employee_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.OptionsColumn.AllowEdit = False
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.Width = 90
        '
        'GBWorkingDays
        '
        Me.GBWorkingDays.AppearanceHeader.Options.UseTextOptions = True
        Me.GBWorkingDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBWorkingDays.Caption = "Working Days"
        Me.GBWorkingDays.Columns.Add(Me.BandedGridColumnActWorkdays)
        Me.GBWorkingDays.Columns.Add(Me.BandedGridColumnOvertimeHours)
        Me.GBWorkingDays.Name = "GBWorkingDays"
        Me.GBWorkingDays.VisibleIndex = 1
        Me.GBWorkingDays.Width = 202
        '
        'BandedGridColumnActWorkdays
        '
        Me.BandedGridColumnActWorkdays.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnActWorkdays.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnActWorkdays.Caption = "Actual Working Days"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnActWorkdays.FieldName = "actual_workdays"
        Me.BandedGridColumnActWorkdays.Name = "BandedGridColumnActWorkdays"
        Me.BandedGridColumnActWorkdays.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnActWorkdays.Visible = True
        Me.BandedGridColumnActWorkdays.Width = 109
        '
        'BandedGridColumnOvertimeHours
        '
        Me.BandedGridColumnOvertimeHours.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnOvertimeHours.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnOvertimeHours.Caption = "Overtime (Hours)"
        Me.BandedGridColumnOvertimeHours.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnOvertimeHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnOvertimeHours.FieldName = "total_ot_hour"
        Me.BandedGridColumnOvertimeHours.Name = "BandedGridColumnOvertimeHours"
        Me.BandedGridColumnOvertimeHours.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnOvertimeHours.Visible = True
        Me.BandedGridColumnOvertimeHours.Width = 93
        '
        'GBSalary
        '
        Me.GBSalary.AppearanceHeader.Options.UseTextOptions = True
        Me.GBSalary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBSalary.Columns.Add(Me.GridColumnTotTHP)
        Me.GBSalary.Columns.Add(Me.BandedGridColumnTotalAdjustment)
        Me.GBSalary.Columns.Add(Me.BandedGridColumnTotalPaymentOt)
        Me.GBSalary.Columns.Add(Me.BandedGridColumnTotal1)
        Me.GBSalary.Name = "GBSalary"
        Me.GBSalary.VisibleIndex = 2
        Me.GBSalary.Width = 362
        '
        'GridColumnTotTHP
        '
        Me.GridColumnTotTHP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnTotTHP.Caption = "Total THP"
        Me.GridColumnTotTHP.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotTHP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotTHP.FieldName = "tot_thp"
        Me.GridColumnTotTHP.Name = "GridColumnTotTHP"
        Me.GridColumnTotTHP.OptionsColumn.AllowEdit = False
        Me.GridColumnTotTHP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", "{0:N0}")})
        Me.GridColumnTotTHP.Visible = True
        '
        'BandedGridColumnTotalAdjustment
        '
        Me.BandedGridColumnTotalAdjustment.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalAdjustment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
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
        'BandedGridColumnTotalPaymentOt
        '
        Me.BandedGridColumnTotalPaymentOt.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalPaymentOt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotalPaymentOt.Caption = "Total Overtime"
        Me.BandedGridColumnTotalPaymentOt.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalPaymentOt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalPaymentOt.FieldName = "total_ot_wages"
        Me.BandedGridColumnTotalPaymentOt.Name = "BandedGridColumnTotalPaymentOt"
        Me.BandedGridColumnTotalPaymentOt.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalPaymentOt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", "{0:N0}")})
        Me.BandedGridColumnTotalPaymentOt.Visible = True
        Me.BandedGridColumnTotalPaymentOt.Width = 81
        '
        'BandedGridColumnTotal1
        '
        Me.BandedGridColumnTotal1.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotal1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotal1.Caption = "Total I"
        Me.BandedGridColumnTotal1.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotal1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotal1.FieldName = "total_1"
        Me.BandedGridColumnTotal1.Name = "BandedGridColumnTotal1"
        Me.BandedGridColumnTotal1.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotal1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_1", "{0:N0}")})
        Me.BandedGridColumnTotal1.Visible = True
        '
        'gridBand1
        '
        Me.gridBand1.Columns.Add(Me.BandedGridColumnTotalDeduction)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnTotal2)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 3
        Me.gridBand1.Width = 165
        '
        'BandedGridColumnTotalDeduction
        '
        Me.BandedGridColumnTotalDeduction.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalDeduction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
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
        'BandedGridColumnTotal2
        '
        Me.BandedGridColumnTotal2.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotal2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotal2.Caption = "Total II"
        Me.BandedGridColumnTotal2.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotal2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotal2.FieldName = "total_2"
        Me.BandedGridColumnTotal2.Name = "BandedGridColumnTotal2"
        Me.BandedGridColumnTotal2.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotal2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_2", "{0:N0}")})
        Me.BandedGridColumnTotal2.Visible = True
        '
        'GBTotal
        '
        Me.GBTotal.Columns.Add(Me.BandedGridColumnGrandTotal)
        Me.GBTotal.Name = "GBTotal"
        Me.GBTotal.VisibleIndex = 4
        Me.GBTotal.Width = 75
        '
        'BandedGridColumnGrandTotal
        '
        Me.BandedGridColumnGrandTotal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnGrandTotal.Caption = "Grand Total"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnGrandTotal.FieldName = "grand_total"
        Me.BandedGridColumnGrandTotal.Name = "BandedGridColumnGrandTotal"
        Me.BandedGridColumnGrandTotal.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnGrandTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", "{0:N0}")})
        Me.BandedGridColumnGrandTotal.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.Columns.Add(Me.BandedGridColumnJHT)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnJKK)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnJKM)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnJP)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnBPJS)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnTotalJamsostek1)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnTotalJamsostek2)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 5
        Me.gridBand2.Width = 616
        '
        'BandedGridColumnJHT
        '
        Me.BandedGridColumnJHT.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJHT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJHT.Caption = "JHT 3.7%"
        Me.BandedGridColumnJHT.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnJHT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJHT.FieldName = "jht"
        Me.BandedGridColumnJHT.Name = "BandedGridColumnJHT"
        Me.BandedGridColumnJHT.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnJHT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jht", "{0:N0}")})
        Me.BandedGridColumnJHT.Visible = True
        '
        'BandedGridColumnJKK
        '
        Me.BandedGridColumnJKK.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJKK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJKK.Caption = "JKK 0.24%"
        Me.BandedGridColumnJKK.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnJKK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJKK.FieldName = "jkk"
        Me.BandedGridColumnJKK.Name = "BandedGridColumnJKK"
        Me.BandedGridColumnJKK.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnJKK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jkk", "{0:N0}")})
        Me.BandedGridColumnJKK.Visible = True
        '
        'BandedGridColumnJKM
        '
        Me.BandedGridColumnJKM.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJKM.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJKM.Caption = "JKM 0.3%"
        Me.BandedGridColumnJKM.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnJKM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJKM.FieldName = "jkm"
        Me.BandedGridColumnJKM.Name = "BandedGridColumnJKM"
        Me.BandedGridColumnJKM.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnJKM.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jkm", "{0:N0}")})
        Me.BandedGridColumnJKM.Visible = True
        '
        'BandedGridColumnJP
        '
        Me.BandedGridColumnJP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJP.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJP.Caption = "JP 2%"
        Me.BandedGridColumnJP.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnJP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJP.FieldName = "jp"
        Me.BandedGridColumnJP.Name = "BandedGridColumnJP"
        Me.BandedGridColumnJP.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnJP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jp", "{0:N0}")})
        Me.BandedGridColumnJP.Visible = True
        '
        'BandedGridColumnBPJS
        '
        Me.BandedGridColumnBPJS.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnBPJS.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnBPJS.Caption = "BPJS 4%"
        Me.BandedGridColumnBPJS.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnBPJS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnBPJS.FieldName = "bpjs"
        Me.BandedGridColumnBPJS.Name = "BandedGridColumnBPJS"
        Me.BandedGridColumnBPJS.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnBPJS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bpjs", "{0:N0}")})
        Me.BandedGridColumnBPJS.Visible = True
        '
        'BandedGridColumnTotalJamsostek1
        '
        Me.BandedGridColumnTotalJamsostek1.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalJamsostek1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotalJamsostek1.Caption = "Total"
        Me.BandedGridColumnTotalJamsostek1.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalJamsostek1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalJamsostek1.FieldName = "total_jamsostek1"
        Me.BandedGridColumnTotalJamsostek1.Name = "BandedGridColumnTotalJamsostek1"
        Me.BandedGridColumnTotalJamsostek1.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalJamsostek1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_jamsostek1", "{0:N0}")})
        Me.BandedGridColumnTotalJamsostek1.Visible = True
        '
        'BandedGridColumnTotalJamsostek2
        '
        Me.BandedGridColumnTotalJamsostek2.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalJamsostek2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotalJamsostek2.Caption = "Total Jamsostek (JHT, JKK, JKM)"
        Me.BandedGridColumnTotalJamsostek2.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalJamsostek2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalJamsostek2.FieldName = "total_jamsostek2"
        Me.BandedGridColumnTotalJamsostek2.Name = "BandedGridColumnTotalJamsostek2"
        Me.BandedGridColumnTotalJamsostek2.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalJamsostek2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_jamsostek2", "{0:N0}")})
        Me.BandedGridColumnTotalJamsostek2.Visible = True
        Me.BandedGridColumnTotalJamsostek2.Width = 166
        '
        'BandedGridColumnGroup
        '
        Me.BandedGridColumnGroup.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnGroup.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnGroup.Caption = "Group"
        Me.BandedGridColumnGroup.FieldName = "group_report"
        Me.BandedGridColumnGroup.Name = "BandedGridColumnGroup"
        Me.BandedGridColumnGroup.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnGroup.Visible = True
        '
        'FormEmpPayrollReportPajak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GCPajak)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormEmpPayrollReportPajak"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Pajak"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCPajak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPajak, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPajak As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPajak As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumnNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnOvertimeHours As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnTotTHP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalAdjustment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalPaymentOt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalDeduction As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnGrandTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnActWorkdays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotal1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotal2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnGroup As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJHT As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJKK As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJKM As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnBPJS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalJamsostek1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalJamsostek2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBSalary As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBTotal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
