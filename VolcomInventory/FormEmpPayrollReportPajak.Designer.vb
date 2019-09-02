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
        Me.GridColumnIDEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIsOfficePayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnGroupReport = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartementSub = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnOvertimeHours = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTotTHP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalAdjustment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalDeduction = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalPaymentOt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnActWorkdays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotal1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotal2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GBWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GBSalary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GBTotal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
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
        Me.GVPajak.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand8, Me.GBWorkingDays, Me.GBSalary, Me.gridBand1, Me.GBTotal})
        Me.GVPajak.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnIDEmployee, Me.GCIsOfficePayroll, Me.GridColumnGroupReport, Me.GridColumnDepartement, Me.BandedGridColumn1, Me.GridColumnDepartementSub, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnPosition, Me.GridColumnStatus, Me.BandedGridColumnActWorkdays, Me.BandedGridColumnOvertimeHours, Me.GridColumnTotTHP, Me.BandedGridColumnTotalAdjustment, Me.BandedGridColumnTotalPaymentOt, Me.BandedGridColumnTotal1, Me.BandedGridColumnTotalDeduction, Me.BandedGridColumnTotal2, Me.BandedGridColumnGrandTotal})
        Me.GVPajak.GridControl = Me.GCPajak
        Me.GVPajak.GroupCount = 3
        Me.GVPajak.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", Me.GridColumnTotTHP, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", Me.BandedGridColumnTotalAdjustment, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", Me.BandedGridColumnTotalDeduction, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", Me.BandedGridColumnTotalPaymentOt, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", Me.BandedGridColumnGrandTotal, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "id_departement_sub", Me.BandedGridColumn1, "{0}")})
        Me.GVPajak.Name = "GVPajak"
        Me.GVPajak.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPajak.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GVPajak.OptionsView.ColumnAutoWidth = False
        Me.GVPajak.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPajak.OptionsView.ShowFooter = True
        Me.GVPajak.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVPajak.OptionsView.ShowGroupPanel = False
        Me.GVPajak.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnGroupReport, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDepartement, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDepartementSub, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIDEmployee
        '
        Me.GridColumnIDEmployee.FieldName = "id_employee"
        Me.GridColumnIDEmployee.Name = "GridColumnIDEmployee"
        Me.GridColumnIDEmployee.OptionsColumn.AllowEdit = False
        '
        'GCIsOfficePayroll
        '
        Me.GCIsOfficePayroll.FieldName = "is_office_payroll"
        Me.GCIsOfficePayroll.Name = "GCIsOfficePayroll"
        Me.GCIsOfficePayroll.OptionsColumn.AllowEdit = False
        '
        'GridColumnGroupReport
        '
        Me.GridColumnGroupReport.Caption = "Group"
        Me.GridColumnGroupReport.FieldName = "group_report"
        Me.GridColumnGroupReport.Name = "GridColumnGroupReport"
        Me.GridColumnGroupReport.OptionsColumn.AllowEdit = False
        Me.GridColumnGroupReport.Width = 83
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Departement"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.OptionsColumn.AllowEdit = False
        Me.GridColumnDepartement.Width = 83
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.FieldName = "id_departement_sub"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'GridColumnDepartementSub
        '
        Me.GridColumnDepartementSub.Caption = "Sub Departement"
        Me.GridColumnDepartementSub.FieldName = "departement_sub"
        Me.GridColumnDepartementSub.Name = "GridColumnDepartementSub"
        Me.GridColumnDepartementSub.OptionsColumn.AllowEdit = False
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.OptionsColumn.AllowEdit = False
        Me.GridColumnNIP.Visible = True
        Me.GridColumnNIP.Width = 83
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Employee"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
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
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Employee Status"
        Me.GridColumnStatus.FieldName = "employee_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.OptionsColumn.AllowEdit = False
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.Width = 84
        '
        'BandedGridColumnOvertimeHours
        '
        Me.BandedGridColumnOvertimeHours.Caption = "Overtime (Hours)"
        Me.BandedGridColumnOvertimeHours.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnOvertimeHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnOvertimeHours.FieldName = "total_ot_hour"
        Me.BandedGridColumnOvertimeHours.Name = "BandedGridColumnOvertimeHours"
        Me.BandedGridColumnOvertimeHours.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnOvertimeHours.Visible = True
        Me.BandedGridColumnOvertimeHours.Width = 93
        '
        'GridColumnTotTHP
        '
        Me.GridColumnTotTHP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
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
        Me.BandedGridColumnTotalPaymentOt.Width = 81
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
        'BandedGridColumnActWorkdays
        '
        Me.BandedGridColumnActWorkdays.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnActWorkdays.Caption = "Actual Working Days"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnActWorkdays.FieldName = "actual_workdays"
        Me.BandedGridColumnActWorkdays.Name = "BandedGridColumnActWorkdays"
        Me.BandedGridColumnActWorkdays.Visible = True
        Me.BandedGridColumnActWorkdays.Width = 109
        '
        'BandedGridColumnTotal1
        '
        Me.BandedGridColumnTotal1.Caption = "Total I"
        Me.BandedGridColumnTotal1.FieldName = "total_1"
        Me.BandedGridColumnTotal1.Name = "BandedGridColumnTotal1"
        Me.BandedGridColumnTotal1.Visible = True
        '
        'BandedGridColumnTotal2
        '
        Me.BandedGridColumnTotal2.Caption = "Total II"
        Me.BandedGridColumnTotal2.FieldName = "total_2"
        Me.BandedGridColumnTotal2.Name = "BandedGridColumnTotal2"
        Me.BandedGridColumnTotal2.Visible = True
        '
        'gridBand8
        '
        Me.gridBand8.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand8.Caption = "Employee"
        Me.gridBand8.Columns.Add(Me.GridColumnGroupReport)
        Me.gridBand8.Columns.Add(Me.GridColumnDepartement)
        Me.gridBand8.Columns.Add(Me.GridColumnNIP)
        Me.gridBand8.Columns.Add(Me.GridColumnName)
        Me.gridBand8.Columns.Add(Me.GridColumnPosition)
        Me.gridBand8.Columns.Add(Me.GridColumnStatus)
        Me.gridBand8.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 0
        Me.gridBand8.Width = 338
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
        'gridBand1
        '
        Me.gridBand1.Columns.Add(Me.BandedGridColumnTotalDeduction)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnTotal2)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 3
        Me.gridBand1.Width = 165
        '
        'GBTotal
        '
        Me.GBTotal.Columns.Add(Me.BandedGridColumnGrandTotal)
        Me.GBTotal.Name = "GBTotal"
        Me.GBTotal.VisibleIndex = 4
        Me.GBTotal.Width = 75
        '
        'FormEmpPayrollReportPajak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GCPajak)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormEmpPayrollReportPajak"
        Me.Text = "Report Pajak"
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
    Friend WithEvents GridColumnGroupReport As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
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
    Friend WithEvents GridColumnIDEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIsOfficePayroll As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDepartementSub As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnActWorkdays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotal1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotal2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBSalary As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBTotal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
