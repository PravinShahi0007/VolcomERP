<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollCompare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollCompare))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCPayroll = New DevExpress.XtraGrid.GridControl()
        Me.GVPayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridColumnGroupReport = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnGrandTotalBefore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDifference = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIDPayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIDEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIsOfficePayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartementSub = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICEPending = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RITEActWorkdaysDW = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RICECheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RITEActWorkdays = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RICESent = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RITETotalSalaryTHR = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BandedGridColumnNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GBTotal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEActWorkdaysDW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEActWorkdays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICESent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITETotalSalaryTHR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1015, 46)
        Me.PanelControl1.TabIndex = 8
        '
        'SBPrint
        '
        Me.SBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrint.Image = CType(resources.GetObject("SBPrint.Image"), System.Drawing.Image)
        Me.SBPrint.Location = New System.Drawing.Point(928, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(85, 42)
        Me.SBPrint.TabIndex = 0
        Me.SBPrint.Text = "Print"
        '
        'GCPayroll
        '
        Me.GCPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayroll.Location = New System.Drawing.Point(0, 46)
        Me.GCPayroll.MainView = Me.GVPayroll
        Me.GCPayroll.Name = "GCPayroll"
        Me.GCPayroll.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEPending, Me.RITEActWorkdaysDW, Me.RICECheck, Me.RITEActWorkdays, Me.RICESent, Me.RITETotalSalaryTHR})
        Me.GCPayroll.Size = New System.Drawing.Size(1015, 448)
        Me.GCPayroll.TabIndex = 9
        Me.GCPayroll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayroll})
        '
        'GVPayroll
        '
        Me.GVPayroll.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand8, Me.GBTotal})
        Me.GVPayroll.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnIDPayroll, Me.GridColumnIDEmployee, Me.GCIsOfficePayroll, Me.GridColumnGroupReport, Me.GridColumnDepartement, Me.BandedGridColumn1, Me.GridColumnDepartementSub, Me.BandedGridColumnNo, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnPosition, Me.GridColumnStatus, Me.BandedGridColumnGrandTotal, Me.BandedGridColumnGrandTotalBefore, Me.BandedGridColumnDifference})
        Me.GVPayroll.GridControl = Me.GCPayroll
        Me.GVPayroll.GroupCount = 3
        Me.GVPayroll.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", Me.BandedGridColumnGrandTotal, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total_before", Me.BandedGridColumnGrandTotalBefore, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "difference", Me.BandedGridColumnDifference, "{0:N0}")})
        Me.GVPayroll.Name = "GVPayroll"
        Me.GVPayroll.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPayroll.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GVPayroll.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPayroll.OptionsView.ShowFooter = True
        Me.GVPayroll.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVPayroll.OptionsView.ShowGroupPanel = False
        Me.GVPayroll.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnGroupReport, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDepartement, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDepartementSub, DevExpress.Data.ColumnSortOrder.Ascending)})
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
        Me.GridColumnStatus.Width = 90
        '
        'BandedGridColumnGrandTotalBefore
        '
        Me.BandedGridColumnGrandTotalBefore.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotalBefore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotalBefore.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotalBefore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotalBefore.Caption = "Grand Total Previous Month"
        Me.BandedGridColumnGrandTotalBefore.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnGrandTotalBefore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnGrandTotalBefore.FieldName = "grand_total_before"
        Me.BandedGridColumnGrandTotalBefore.Name = "BandedGridColumnGrandTotalBefore"
        Me.BandedGridColumnGrandTotalBefore.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnGrandTotalBefore.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total_before", "{0:N0}")})
        Me.BandedGridColumnGrandTotalBefore.Visible = True
        Me.BandedGridColumnGrandTotalBefore.Width = 143
        '
        'BandedGridColumnGrandTotal
        '
        Me.BandedGridColumnGrandTotal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.Caption = "Grand Total Current Month"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnGrandTotal.FieldName = "grand_total"
        Me.BandedGridColumnGrandTotal.Name = "BandedGridColumnGrandTotal"
        Me.BandedGridColumnGrandTotal.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnGrandTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", "{0:N0}")})
        Me.BandedGridColumnGrandTotal.Visible = True
        Me.BandedGridColumnGrandTotal.Width = 139
        '
        'BandedGridColumnDifference
        '
        Me.BandedGridColumnDifference.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDifference.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDifference.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDifference.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDifference.Caption = "Difference"
        Me.BandedGridColumnDifference.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnDifference.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDifference.FieldName = "difference"
        Me.BandedGridColumnDifference.Name = "BandedGridColumnDifference"
        Me.BandedGridColumnDifference.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnDifference.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "difference", "{0:N0}")})
        Me.BandedGridColumnDifference.UnboundExpression = "[grand_total] - [grand_total_before]"
        Me.BandedGridColumnDifference.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.BandedGridColumnDifference.Visible = True
        '
        'GridColumnIDPayroll
        '
        Me.GridColumnIDPayroll.FieldName = "id_payroll_det"
        Me.GridColumnIDPayroll.Name = "GridColumnIDPayroll"
        Me.GridColumnIDPayroll.OptionsColumn.AllowEdit = False
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
        'RICEPending
        '
        Me.RICEPending.AutoHeight = False
        Me.RICEPending.Name = "RICEPending"
        Me.RICEPending.ValueChecked = "yes"
        Me.RICEPending.ValueUnchecked = "no"
        '
        'RITEActWorkdaysDW
        '
        Me.RITEActWorkdaysDW.AutoHeight = False
        Me.RITEActWorkdaysDW.DisplayFormat.FormatString = "N1"
        Me.RITEActWorkdaysDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEActWorkdaysDW.Name = "RITEActWorkdaysDW"
        '
        'RICECheck
        '
        Me.RICECheck.AutoHeight = False
        Me.RICECheck.Name = "RICECheck"
        Me.RICECheck.ValueChecked = "yes"
        Me.RICECheck.ValueUnchecked = "no"
        '
        'RITEActWorkdays
        '
        Me.RITEActWorkdays.AutoHeight = False
        Me.RITEActWorkdays.DisplayFormat.FormatString = "N1"
        Me.RITEActWorkdays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEActWorkdays.Name = "RITEActWorkdays"
        '
        'RICESent
        '
        Me.RICESent.AutoHeight = False
        Me.RICESent.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RICESent.ImageIndexChecked = 19
        Me.RICESent.Name = "RICESent"
        Me.RICESent.ValueChecked = "yes"
        Me.RICESent.ValueUnchecked = "no"
        '
        'RITETotalSalaryTHR
        '
        Me.RITETotalSalaryTHR.AutoHeight = False
        Me.RITETotalSalaryTHR.DisplayFormat.FormatString = "N0"
        Me.RITETotalSalaryTHR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITETotalSalaryTHR.EditFormat.FormatString = "N0"
        Me.RITETotalSalaryTHR.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITETotalSalaryTHR.Mask.EditMask = "N0"
        Me.RITETotalSalaryTHR.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RITETotalSalaryTHR.Mask.UseMaskAsDisplayFormat = True
        Me.RITETotalSalaryTHR.Name = "RITETotalSalaryTHR"
        '
        'BandedGridColumnNo
        '
        Me.BandedGridColumnNo.Caption = "No"
        Me.BandedGridColumnNo.FieldName = "no"
        Me.BandedGridColumnNo.Name = "BandedGridColumnNo"
        Me.BandedGridColumnNo.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnNo.Visible = True
        Me.BandedGridColumnNo.Width = 83
        '
        'gridBand8
        '
        Me.gridBand8.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand8.Caption = "Employee"
        Me.gridBand8.Columns.Add(Me.GridColumnGroupReport)
        Me.gridBand8.Columns.Add(Me.GridColumnDepartement)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnNo)
        Me.gridBand8.Columns.Add(Me.GridColumnNIP)
        Me.gridBand8.Columns.Add(Me.GridColumnName)
        Me.gridBand8.Columns.Add(Me.GridColumnPosition)
        Me.gridBand8.Columns.Add(Me.GridColumnStatus)
        Me.gridBand8.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 0
        Me.gridBand8.Width = 427
        '
        'GBTotal
        '
        Me.GBTotal.Columns.Add(Me.BandedGridColumnGrandTotalBefore)
        Me.GBTotal.Columns.Add(Me.BandedGridColumnGrandTotal)
        Me.GBTotal.Columns.Add(Me.BandedGridColumnDifference)
        Me.GBTotal.Name = "GBTotal"
        Me.GBTotal.VisibleIndex = 1
        Me.GBTotal.Width = 357
        '
        'FormEmpPayrollCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 494)
        Me.Controls.Add(Me.GCPayroll)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormEmpPayrollCompare"
        Me.Text = "Payroll Comparison"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEActWorkdaysDW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEActWorkdays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICESent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITETotalSalaryTHR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPayroll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayroll As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumnGroupReport As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RICECheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RICESent As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RITEActWorkdays As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RITETotalSalaryTHR As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RITEActWorkdaysDW As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BandedGridColumnGrandTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RICEPending As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIDPayroll As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIDEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIsOfficePayroll As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDepartementSub As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnGrandTotalBefore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDifference As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBTotal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
