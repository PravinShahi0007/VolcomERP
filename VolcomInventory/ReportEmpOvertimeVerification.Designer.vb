<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportEmpOvertimeVerification
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportEmpOvertimeVerification))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer2 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCAttendance = New DevExpress.XtraGrid.GridControl()
        Me.GVAttendance = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BGCIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCIdDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCIdDepartementSub = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCNIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCEmployeePosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCIdEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCToSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCConversionType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLUEType2 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCIsStore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCIsDayOff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCStartWork = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCEndWork = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCStartWorkOt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCEndWorkOt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCBreakHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCTotalHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCPointOt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCValid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEValid = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BGCIdScheduleType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCIn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BGCOtPotention = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartementSub = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeePosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCToSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCConversionType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLUEType = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIsDayOff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStartWork = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEndWork = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCBreakHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCTotalHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XLPayrollPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XLCreatedBy = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLOTtype = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLCreatedAt = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XLOTNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLUEType2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEValid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLUEType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer2, Me.XrLabel12, Me.XrLabel7, Me.WinControlContainer1})
        Me.Detail.HeightF = 484.5347!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer2
        '
        Me.WinControlContainer2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 266.5347!)
        Me.WinControlContainer2.Name = "WinControlContainer2"
        Me.WinControlContainer2.SizeF = New System.Drawing.SizeF(1075.0!, 208.0!)
        Me.WinControlContainer2.WinControl = Me.GCAttendance
        '
        'GCAttendance
        '
        Me.GCAttendance.Location = New System.Drawing.Point(2, 20)
        Me.GCAttendance.MainView = Me.GVAttendance
        Me.GCAttendance.Name = "GCAttendance"
        Me.GCAttendance.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RISLUEType2, Me.RICEValid})
        Me.GCAttendance.Size = New System.Drawing.Size(1032, 200)
        Me.GCAttendance.TabIndex = 1
        Me.GCAttendance.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAttendance})
        '
        'GVAttendance
        '
        Me.GVAttendance.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVAttendance.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVAttendance.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVAttendance.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVAttendance.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVAttendance.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVAttendance.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVAttendance.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVAttendance.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVAttendance.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVAttendance.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVAttendance.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVAttendance.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVAttendance.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVAttendance.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVAttendance.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVAttendance.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVAttendance.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVAttendance.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVAttendance.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVAttendance.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVAttendance.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVAttendance.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVAttendance.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVAttendance.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVAttendance.AppearancePrint.Lines.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVAttendance.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVAttendance.AppearancePrint.Lines.Options.UseFont = True
        Me.GVAttendance.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVAttendance.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVAttendance.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVAttendance.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVAttendance.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVAttendance.AppearancePrint.Row.Options.UseFont = True
        Me.GVAttendance.ColumnPanelRowHeight = 32
        Me.GVAttendance.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.BGCIdEmployee, Me.BGCIdDepartement, Me.BGCIdDepartementSub, Me.BGCDepartement, Me.BGCDate, Me.BGCNIP, Me.BGCEmployeeName, Me.BGCEmployeePosition, Me.BGCIdEmployeeStatus, Me.BGCEmployeeStatus, Me.BGCToSalary, Me.BGCConversionType, Me.BGCIsStore, Me.BGCIsDayOff, Me.BGCStartWork, Me.BGCEndWork, Me.BGCStartWorkOt, Me.BGCEndWorkOt, Me.BGCBreakHours, Me.BGCTotalHours, Me.BGCPointOt, Me.BGCValid, Me.BGCIdScheduleType, Me.BGCIn, Me.BGCOut, Me.BGCOtPotention})
        Me.GVAttendance.GridControl = Me.GCAttendance
        Me.GVAttendance.GroupCount = 1
        Me.GVAttendance.LevelIndent = 0
        Me.GVAttendance.Name = "GVAttendance"
        Me.GVAttendance.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVAttendance.OptionsPrint.AllowMultilineHeaders = True
        Me.GVAttendance.OptionsView.AllowCellMerge = True
        Me.GVAttendance.OptionsView.ColumnAutoWidth = False
        Me.GVAttendance.OptionsView.ShowGroupPanel = False
        Me.GVAttendance.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BGCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'BGCIdEmployee
        '
        Me.BGCIdEmployee.FieldName = "id_employee"
        Me.BGCIdEmployee.Name = "BGCIdEmployee"
        Me.BGCIdEmployee.OptionsColumn.AllowEdit = False
        Me.BGCIdEmployee.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BGCIdDepartement
        '
        Me.BGCIdDepartement.FieldName = "id_departement"
        Me.BGCIdDepartement.Name = "BGCIdDepartement"
        Me.BGCIdDepartement.OptionsColumn.AllowEdit = False
        Me.BGCIdDepartement.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BGCIdDepartementSub
        '
        Me.BGCIdDepartementSub.FieldName = "id_departement_sub"
        Me.BGCIdDepartementSub.Name = "BGCIdDepartementSub"
        Me.BGCIdDepartementSub.OptionsColumn.AllowEdit = False
        Me.BGCIdDepartementSub.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCIdDepartementSub.Width = 109
        '
        'BGCDepartement
        '
        Me.BGCDepartement.Caption = "Departement"
        Me.BGCDepartement.FieldName = "departement"
        Me.BGCDepartement.Name = "BGCDepartement"
        Me.BGCDepartement.OptionsColumn.AllowEdit = False
        Me.BGCDepartement.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BGCDate
        '
        Me.BGCDate.Caption = "Date"
        Me.BGCDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BGCDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BGCDate.FieldName = "date"
        Me.BGCDate.MinWidth = 100
        Me.BGCDate.Name = "BGCDate"
        Me.BGCDate.OptionsColumn.AllowEdit = False
        Me.BGCDate.Width = 100
        '
        'BGCNIP
        '
        Me.BGCNIP.Caption = "NIP"
        Me.BGCNIP.FieldName = "employee_code"
        Me.BGCNIP.MinWidth = 65
        Me.BGCNIP.Name = "BGCNIP"
        Me.BGCNIP.OptionsColumn.AllowEdit = False
        Me.BGCNIP.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCNIP.Visible = True
        Me.BGCNIP.VisibleIndex = 0
        '
        'BGCEmployeeName
        '
        Me.BGCEmployeeName.Caption = "Employee"
        Me.BGCEmployeeName.FieldName = "employee_name"
        Me.BGCEmployeeName.MinWidth = 195
        Me.BGCEmployeeName.Name = "BGCEmployeeName"
        Me.BGCEmployeeName.OptionsColumn.AllowEdit = False
        Me.BGCEmployeeName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCEmployeeName.Visible = True
        Me.BGCEmployeeName.VisibleIndex = 1
        Me.BGCEmployeeName.Width = 195
        '
        'BGCEmployeePosition
        '
        Me.BGCEmployeePosition.AppearanceHeader.Options.UseTextOptions = True
        Me.BGCEmployeePosition.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BGCEmployeePosition.Caption = "Employee Position"
        Me.BGCEmployeePosition.FieldName = "employee_position"
        Me.BGCEmployeePosition.MinWidth = 150
        Me.BGCEmployeePosition.Name = "BGCEmployeePosition"
        Me.BGCEmployeePosition.OptionsColumn.AllowEdit = False
        Me.BGCEmployeePosition.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCEmployeePosition.Visible = True
        Me.BGCEmployeePosition.VisibleIndex = 2
        Me.BGCEmployeePosition.Width = 150
        '
        'BGCIdEmployeeStatus
        '
        Me.BGCIdEmployeeStatus.FieldName = "id_employee_status"
        Me.BGCIdEmployeeStatus.Name = "BGCIdEmployeeStatus"
        Me.BGCIdEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.BGCIdEmployeeStatus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BGCEmployeeStatus
        '
        Me.BGCEmployeeStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.BGCEmployeeStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BGCEmployeeStatus.Caption = "Employee Status"
        Me.BGCEmployeeStatus.FieldName = "employee_status"
        Me.BGCEmployeeStatus.MinWidth = 60
        Me.BGCEmployeeStatus.Name = "BGCEmployeeStatus"
        Me.BGCEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.BGCEmployeeStatus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCEmployeeStatus.Visible = True
        Me.BGCEmployeeStatus.VisibleIndex = 3
        Me.BGCEmployeeStatus.Width = 90
        '
        'BGCToSalary
        '
        Me.BGCToSalary.FieldName = "to_salary"
        Me.BGCToSalary.Name = "BGCToSalary"
        Me.BGCToSalary.OptionsColumn.AllowEdit = False
        Me.BGCToSalary.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BGCConversionType
        '
        Me.BGCConversionType.AppearanceHeader.Options.UseTextOptions = True
        Me.BGCConversionType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BGCConversionType.Caption = "Conversion Type"
        Me.BGCConversionType.ColumnEdit = Me.RISLUEType2
        Me.BGCConversionType.FieldName = "conversion_type"
        Me.BGCConversionType.Name = "BGCConversionType"
        Me.BGCConversionType.OptionsColumn.AllowEdit = False
        Me.BGCConversionType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCConversionType.Visible = True
        Me.BGCConversionType.VisibleIndex = 4
        Me.BGCConversionType.Width = 91
        '
        'RISLUEType2
        '
        Me.RISLUEType2.AutoHeight = False
        Me.RISLUEType2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLUEType2.Name = "RISLUEType2"
        Me.RISLUEType2.View = Me.GridView2
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "GridColumn8"
        Me.GridColumn3.FieldName = "id_type"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Conversion Type"
        Me.GridColumn4.FieldName = "type"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "GridColumn1"
        Me.GridColumn5.FieldName = "to_salary"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "GridColumn2"
        Me.GridColumn6.FieldName = "to_dp"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'BGCIsStore
        '
        Me.BGCIsStore.FieldName = "is_store"
        Me.BGCIsStore.Name = "BGCIsStore"
        Me.BGCIsStore.OptionsColumn.AllowEdit = False
        Me.BGCIsStore.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BGCIsDayOff
        '
        Me.BGCIsDayOff.FieldName = "is_day_off"
        Me.BGCIsDayOff.Name = "BGCIsDayOff"
        Me.BGCIsDayOff.OptionsColumn.AllowEdit = False
        Me.BGCIsDayOff.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BGCStartWork
        '
        Me.BGCStartWork.AppearanceHeader.Options.UseTextOptions = True
        Me.BGCStartWork.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BGCStartWork.Caption = "Start Work"
        Me.BGCStartWork.DisplayFormat.FormatString = "HH:mm"
        Me.BGCStartWork.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BGCStartWork.FieldName = "start_work_att"
        Me.BGCStartWork.Name = "BGCStartWork"
        Me.BGCStartWork.OptionsColumn.AllowEdit = False
        Me.BGCStartWork.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCStartWork.Width = 62
        '
        'BGCEndWork
        '
        Me.BGCEndWork.AppearanceHeader.Options.UseTextOptions = True
        Me.BGCEndWork.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BGCEndWork.Caption = "End Work"
        Me.BGCEndWork.DisplayFormat.FormatString = "HH:mm"
        Me.BGCEndWork.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BGCEndWork.FieldName = "end_work_att"
        Me.BGCEndWork.Name = "BGCEndWork"
        Me.BGCEndWork.OptionsColumn.AllowEdit = False
        Me.BGCEndWork.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCEndWork.Width = 56
        '
        'BGCStartWorkOt
        '
        Me.BGCStartWorkOt.Caption = "Start Work"
        Me.BGCStartWorkOt.DisplayFormat.FormatString = "HH:mm"
        Me.BGCStartWorkOt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BGCStartWorkOt.FieldName = "start_work_ot"
        Me.BGCStartWorkOt.Name = "BGCStartWorkOt"
        Me.BGCStartWorkOt.OptionsColumn.AllowEdit = False
        Me.BGCStartWorkOt.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCStartWorkOt.Visible = True
        Me.BGCStartWorkOt.VisibleIndex = 5
        Me.BGCStartWorkOt.Width = 62
        '
        'BGCEndWorkOt
        '
        Me.BGCEndWorkOt.Caption = "End Work"
        Me.BGCEndWorkOt.DisplayFormat.FormatString = "HH:mm"
        Me.BGCEndWorkOt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BGCEndWorkOt.FieldName = "end_work_ot"
        Me.BGCEndWorkOt.Name = "BGCEndWorkOt"
        Me.BGCEndWorkOt.OptionsColumn.AllowEdit = False
        Me.BGCEndWorkOt.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCEndWorkOt.Visible = True
        Me.BGCEndWorkOt.VisibleIndex = 6
        Me.BGCEndWorkOt.Width = 56
        '
        'BGCBreakHours
        '
        Me.BGCBreakHours.AppearanceHeader.Options.UseTextOptions = True
        Me.BGCBreakHours.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BGCBreakHours.Caption = "Break (hours)"
        Me.BGCBreakHours.DisplayFormat.FormatString = "N1"
        Me.BGCBreakHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BGCBreakHours.FieldName = "break_hours"
        Me.BGCBreakHours.Name = "BGCBreakHours"
        Me.BGCBreakHours.OptionsColumn.AllowEdit = False
        Me.BGCBreakHours.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCBreakHours.Visible = True
        Me.BGCBreakHours.VisibleIndex = 7
        '
        'BGCTotalHours
        '
        Me.BGCTotalHours.AppearanceHeader.Options.UseTextOptions = True
        Me.BGCTotalHours.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BGCTotalHours.Caption = "Total (hours)"
        Me.BGCTotalHours.DisplayFormat.FormatString = "N1"
        Me.BGCTotalHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BGCTotalHours.FieldName = "total_hours"
        Me.BGCTotalHours.Name = "BGCTotalHours"
        Me.BGCTotalHours.OptionsColumn.AllowEdit = False
        Me.BGCTotalHours.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCTotalHours.Visible = True
        Me.BGCTotalHours.VisibleIndex = 8
        Me.BGCTotalHours.Width = 72
        '
        'BGCPointOt
        '
        Me.BGCPointOt.Caption = "Point"
        Me.BGCPointOt.DisplayFormat.FormatString = "N1"
        Me.BGCPointOt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BGCPointOt.FieldName = "point_ot"
        Me.BGCPointOt.Name = "BGCPointOt"
        Me.BGCPointOt.OptionsColumn.AllowEdit = False
        Me.BGCPointOt.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCPointOt.Visible = True
        Me.BGCPointOt.VisibleIndex = 9
        Me.BGCPointOt.Width = 34
        '
        'BGCValid
        '
        Me.BGCValid.Caption = "Valid"
        Me.BGCValid.ColumnEdit = Me.RICEValid
        Me.BGCValid.FieldName = "is_valid"
        Me.BGCValid.Name = "BGCValid"
        Me.BGCValid.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.BGCValid.Width = 61
        '
        'RICEValid
        '
        Me.RICEValid.AutoHeight = False
        Me.RICEValid.Name = "RICEValid"
        Me.RICEValid.ValueChecked = "yes"
        Me.RICEValid.ValueUnchecked = "no"
        '
        'BGCIdScheduleType
        '
        Me.BGCIdScheduleType.FieldName = "id_schedule_type"
        Me.BGCIdScheduleType.Name = "BGCIdScheduleType"
        Me.BGCIdScheduleType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BGCIn
        '
        Me.BGCIn.Caption = "In"
        Me.BGCIn.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.BGCIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BGCIn.FieldName = "in"
        Me.BGCIn.Name = "BGCIn"
        Me.BGCIn.OptionsColumn.AllowEdit = False
        Me.BGCIn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BGCOut
        '
        Me.BGCOut.Caption = "Out"
        Me.BGCOut.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.BGCOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BGCOut.FieldName = "out"
        Me.BGCOut.Name = "BGCOut"
        Me.BGCOut.OptionsColumn.AllowEdit = False
        Me.BGCOut.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BGCOtPotention
        '
        Me.BGCOtPotention.FieldName = "ot_potention"
        Me.BGCOtPotention.Name = "BGCOtPotention"
        Me.BGCOtPotention.OptionsColumn.AllowEdit = False
        Me.BGCOtPotention.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'XrLabel12
        '
        Me.XrLabel12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(0!, 243.5347!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.Text = "Realization"
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.Text = "Proposed"
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 22.99999!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1075.0!, 208.0!)
        Me.WinControlContainer1.WinControl = Me.GCEmployee
        '
        'GCEmployee
        '
        Me.GCEmployee.Location = New System.Drawing.Point(2, 2)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RISLUEType})
        Me.GCEmployee.Size = New System.Drawing.Size(1032, 200)
        Me.GCEmployee.TabIndex = 0
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.Row.Options.UseFont = True
        Me.GVEmployee.ColumnPanelRowHeight = 32
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdEmployee, Me.GCIdDepartement, Me.GCIdDepartementSub, Me.GCDepartement, Me.GCDate, Me.GCEmployeeCode, Me.GCEmployeeName, Me.GCEmployeePosition, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCToSalary, Me.GCConversionType, Me.GCIsDayOff, Me.GCStartWork, Me.GCEndWork, Me.GCBreakHours, Me.GCTotalHours})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.LevelIndent = 0
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsPrint.AllowMultilineHeaders = True
        Me.GVEmployee.OptionsView.AllowCellMerge = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCIdEmployee
        '
        Me.GCIdEmployee.FieldName = "id_employee"
        Me.GCIdEmployee.Name = "GCIdEmployee"
        Me.GCIdEmployee.OptionsColumn.AllowEdit = False
        Me.GCIdEmployee.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCIdDepartement
        '
        Me.GCIdDepartement.FieldName = "id_departement"
        Me.GCIdDepartement.Name = "GCIdDepartement"
        Me.GCIdDepartement.OptionsColumn.AllowEdit = False
        Me.GCIdDepartement.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCIdDepartementSub
        '
        Me.GCIdDepartementSub.FieldName = "id_departement_sub"
        Me.GCIdDepartementSub.Name = "GCIdDepartementSub"
        Me.GCIdDepartementSub.OptionsColumn.AllowEdit = False
        Me.GCIdDepartementSub.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCIdDepartementSub.Width = 109
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.OptionsColumn.AllowEdit = False
        Me.GCDepartement.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCDepartement.Visible = True
        Me.GCDepartement.VisibleIndex = 4
        Me.GCDepartement.Width = 86
        '
        'GCDate
        '
        Me.GCDate.Caption = "Date"
        Me.GCDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GCDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCDate.FieldName = "ot_date"
        Me.GCDate.MinWidth = 100
        Me.GCDate.Name = "GCDate"
        Me.GCDate.OptionsColumn.AllowEdit = False
        Me.GCDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        '
        'GCEmployeeCode
        '
        Me.GCEmployeeCode.Caption = "NIP"
        Me.GCEmployeeCode.FieldName = "employee_code"
        Me.GCEmployeeCode.MinWidth = 65
        Me.GCEmployeeCode.Name = "GCEmployeeCode"
        Me.GCEmployeeCode.OptionsColumn.AllowEdit = False
        Me.GCEmployeeCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCEmployeeCode.Visible = True
        Me.GCEmployeeCode.VisibleIndex = 0
        '
        'GCEmployeeName
        '
        Me.GCEmployeeName.Caption = "Employee"
        Me.GCEmployeeName.FieldName = "employee_name"
        Me.GCEmployeeName.MinWidth = 195
        Me.GCEmployeeName.Name = "GCEmployeeName"
        Me.GCEmployeeName.OptionsColumn.AllowEdit = False
        Me.GCEmployeeName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCEmployeeName.Visible = True
        Me.GCEmployeeName.VisibleIndex = 1
        Me.GCEmployeeName.Width = 195
        '
        'GCEmployeePosition
        '
        Me.GCEmployeePosition.AppearanceHeader.Options.UseTextOptions = True
        Me.GCEmployeePosition.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEmployeePosition.Caption = "Employee Position"
        Me.GCEmployeePosition.FieldName = "employee_position"
        Me.GCEmployeePosition.MinWidth = 150
        Me.GCEmployeePosition.Name = "GCEmployeePosition"
        Me.GCEmployeePosition.OptionsColumn.AllowEdit = False
        Me.GCEmployeePosition.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCEmployeePosition.Visible = True
        Me.GCEmployeePosition.VisibleIndex = 2
        Me.GCEmployeePosition.Width = 150
        '
        'GCIdEmployeeStatus
        '
        Me.GCIdEmployeeStatus.FieldName = "id_employee_status"
        Me.GCIdEmployeeStatus.Name = "GCIdEmployeeStatus"
        Me.GCIdEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.GCIdEmployeeStatus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCEmployeeStatus
        '
        Me.GCEmployeeStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.GCEmployeeStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEmployeeStatus.Caption = "Employee Status"
        Me.GCEmployeeStatus.FieldName = "employee_status"
        Me.GCEmployeeStatus.MinWidth = 60
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.GCEmployeeStatus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.VisibleIndex = 3
        Me.GCEmployeeStatus.Width = 150
        '
        'GCToSalary
        '
        Me.GCToSalary.FieldName = "to_salary"
        Me.GCToSalary.Name = "GCToSalary"
        Me.GCToSalary.OptionsColumn.AllowEdit = False
        Me.GCToSalary.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCConversionType
        '
        Me.GCConversionType.AppearanceHeader.Options.UseTextOptions = True
        Me.GCConversionType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCConversionType.Caption = "Conversion Type"
        Me.GCConversionType.ColumnEdit = Me.RISLUEType
        Me.GCConversionType.FieldName = "conversion_type"
        Me.GCConversionType.Name = "GCConversionType"
        Me.GCConversionType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCConversionType.Visible = True
        Me.GCConversionType.VisibleIndex = 4
        Me.GCConversionType.Width = 91
        '
        'RISLUEType
        '
        Me.RISLUEType.AutoHeight = False
        Me.RISLUEType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLUEType.Name = "RISLUEType"
        Me.RISLUEType.View = Me.GridView1
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9, Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "GridColumn8"
        Me.GridColumn8.FieldName = "id_type"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Conversion Type"
        Me.GridColumn9.FieldName = "type"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "to_salary"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GridColumn2"
        Me.GridColumn2.FieldName = "to_dp"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GCIsDayOff
        '
        Me.GCIsDayOff.FieldName = "is_day_off"
        Me.GCIsDayOff.Name = "GCIsDayOff"
        Me.GCIsDayOff.OptionsColumn.AllowEdit = False
        Me.GCIsDayOff.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCStartWork
        '
        Me.GCStartWork.AppearanceHeader.Options.UseTextOptions = True
        Me.GCStartWork.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCStartWork.Caption = "Start Work"
        Me.GCStartWork.DisplayFormat.FormatString = "HH:mm"
        Me.GCStartWork.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCStartWork.FieldName = "ot_start_time"
        Me.GCStartWork.Name = "GCStartWork"
        Me.GCStartWork.OptionsColumn.AllowEdit = False
        Me.GCStartWork.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCStartWork.Visible = True
        Me.GCStartWork.VisibleIndex = 5
        Me.GCStartWork.Width = 62
        '
        'GCEndWork
        '
        Me.GCEndWork.AppearanceHeader.Options.UseTextOptions = True
        Me.GCEndWork.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEndWork.Caption = "End Work"
        Me.GCEndWork.DisplayFormat.FormatString = "HH:mm"
        Me.GCEndWork.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCEndWork.FieldName = "ot_end_time"
        Me.GCEndWork.Name = "GCEndWork"
        Me.GCEndWork.OptionsColumn.AllowEdit = False
        Me.GCEndWork.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCEndWork.Visible = True
        Me.GCEndWork.VisibleIndex = 6
        Me.GCEndWork.Width = 56
        '
        'GCBreakHours
        '
        Me.GCBreakHours.AppearanceHeader.Options.UseTextOptions = True
        Me.GCBreakHours.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCBreakHours.Caption = "Break (hours)"
        Me.GCBreakHours.DisplayFormat.FormatString = "N1"
        Me.GCBreakHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBreakHours.FieldName = "ot_break"
        Me.GCBreakHours.Name = "GCBreakHours"
        Me.GCBreakHours.OptionsColumn.AllowEdit = False
        Me.GCBreakHours.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCBreakHours.Visible = True
        Me.GCBreakHours.VisibleIndex = 7
        '
        'GCTotalHours
        '
        Me.GCTotalHours.AppearanceHeader.Options.UseTextOptions = True
        Me.GCTotalHours.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCTotalHours.Caption = "Total (hours)"
        Me.GCTotalHours.DisplayFormat.FormatString = "N1"
        Me.GCTotalHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalHours.FieldName = "ot_total_hours"
        Me.GCTotalHours.Name = "GCTotalHours"
        Me.GCTotalHours.OptionsColumn.AllowEdit = False
        Me.GCTotalHours.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCTotalHours.Visible = True
        Me.GCTotalHours.VisibleIndex = 8
        Me.GCTotalHours.Width = 72
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 60.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLPayrollPeriod, Me.XrLabel10, Me.XrLabel11, Me.XrLabel2, Me.XrLabel4, Me.XLDate, Me.XLNumber, Me.XrLabel1, Me.XrLine1, Me.XrPictureBox1, Me.XLCreatedBy, Me.XLOTtype, Me.XLCreatedAt, Me.XrLabel13, Me.XrLabel14, Me.XrLabel9, Me.XrLabel5, Me.XrLabel6, Me.XrLabel3})
        Me.ReportHeader.HeightF = 143.15!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XLPayrollPeriod
        '
        Me.XLPayrollPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLPayrollPeriod.LocationFloat = New DevExpress.Utils.PointFloat(115.0001!, 110.15!)
        Me.XLPayrollPeriod.Name = "XLPayrollPeriod"
        Me.XLPayrollPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLPayrollPeriod.SizeF = New System.Drawing.SizeF(275.0!, 23.0!)
        Me.XLPayrollPeriod.StylePriority.UseFont = False
        Me.XLPayrollPeriod.Text = "[payrollperiod]"
        '
        'XrLabel10
        '
        Me.XrLabel10.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 110.15!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.Text = ":"
        '
        'XrLabel11
        '
        Me.XrLabel11.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(0!, 110.15!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.Text = "Payroll Period"
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 87.15003!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "Date"
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 87.15003!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = ":"
        '
        'XLDate
        '
        Me.XLDate.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLDate.LocationFloat = New DevExpress.Utils.PointFloat(115.0!, 87.15003!)
        Me.XLDate.Name = "XLDate"
        Me.XLDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLDate.SizeF = New System.Drawing.SizeF(275.0!, 23.0!)
        Me.XLDate.StylePriority.UseFont = False
        Me.XLDate.Text = "[date]"
        '
        'XLNumber
        '
        Me.XLNumber.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XLNumber.LocationFloat = New DevExpress.Utils.PointFloat(854.0002!, 9.000015!)
        Me.XLNumber.Name = "XLNumber"
        Me.XLNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLNumber.SizeF = New System.Drawing.SizeF(220.0!, 23.0!)
        Me.XLNumber.StylePriority.UseFont = False
        Me.XLNumber.StylePriority.UseTextAlignment = False
        Me.XLNumber.Text = "[number]"
        Me.XLNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(220.0001!, 9.000015!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(634.0001!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "EMPLOYEE OVERTIME VERIFICATION"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 41.15!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1074.0!, 23.0!)
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(220.0!, 41.15!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XLCreatedBy
        '
        Me.XLCreatedBy.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLCreatedBy.LocationFloat = New DevExpress.Utils.PointFloat(869.0002!, 87.15003!)
        Me.XLCreatedBy.Multiline = True
        Me.XLCreatedBy.Name = "XLCreatedBy"
        Me.XLCreatedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCreatedBy.SizeF = New System.Drawing.SizeF(205.9998!, 23.0!)
        Me.XLCreatedBy.StylePriority.UseFont = False
        Me.XLCreatedBy.Text = "[createdby]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'XLOTtype
        '
        Me.XLOTtype.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLOTtype.LocationFloat = New DevExpress.Utils.PointFloat(115.0!, 64.15002!)
        Me.XLOTtype.Name = "XLOTtype"
        Me.XLOTtype.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLOTtype.SizeF = New System.Drawing.SizeF(275.0!, 23.0!)
        Me.XLOTtype.StylePriority.UseFont = False
        Me.XLOTtype.Text = "[overtimtype]"
        '
        'XLCreatedAt
        '
        Me.XLCreatedAt.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLCreatedAt.LocationFloat = New DevExpress.Utils.PointFloat(869.0002!, 64.15002!)
        Me.XLCreatedAt.Name = "XLCreatedAt"
        Me.XLCreatedAt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLCreatedAt.SizeF = New System.Drawing.SizeF(204.9999!, 23.0!)
        Me.XLCreatedAt.StylePriority.UseFont = False
        Me.XLCreatedAt.Text = "[createdat]"
        '
        'XrLabel13
        '
        Me.XrLabel13.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(854.0002!, 64.15002!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.Text = ":"
        '
        'XrLabel14
        '
        Me.XrLabel14.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(854.0002!, 87.15003!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.Text = ":"
        '
        'XrLabel9
        '
        Me.XrLabel9.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 64.15002!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.Text = ":"
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(754.0002!, 64.15002!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = "Created By"
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(754.0002!, 87.15003!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.Text = "Created At"
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 64.15002!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "Overtime Type"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.XLOTNote, Me.XrLabel17, Me.XrLabel16})
        Me.ReportFooter.HeightF = 96.54173!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 71.54173!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1075.0!, 25.0!)
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Lucida Console", 8.0!)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.Text = "Here Table Mark Goes, Please Ignore This"
        Me.XrTableCell1.Visible = False
        Me.XrTableCell1.Weight = 2.99999986405489R
        '
        'XLOTNote
        '
        Me.XLOTNote.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLOTNote.LocationFloat = New DevExpress.Utils.PointFloat(114.9999!, 0!)
        Me.XLOTNote.Name = "XLOTNote"
        Me.XLOTNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLOTNote.SizeF = New System.Drawing.SizeF(960.0!, 61.54167!)
        Me.XLOTNote.StylePriority.UseFont = False
        Me.XLOTNote.Text = "[overtimenote]"
        '
        'XrLabel17
        '
        Me.XrLabel17.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(99.99994!, 0!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.Text = ":"
        '
        'XrLabel16
        '
        Me.XrLabel16.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel16.Multiline = True
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.Text = "Overtime Purpose"
        '
        'ReportEmpOvertimeVerification
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 50, 60)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLUEType2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEValid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLUEType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XLNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XLCreatedBy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLOTtype As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLCreatedAt As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XLOTNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartementSub As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeePosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCToSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCConversionType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLUEType As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIsDayOff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCStartWork As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEndWork As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCBreakHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTotalHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLPayrollPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer2 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCAttendance As DevExpress.XtraGrid.GridControl
    Friend WithEvents RISLUEType2 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RICEValid As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GVAttendance As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BGCIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCIdDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCIdDepartementSub As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCNIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCEmployeePosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCIdEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCToSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCConversionType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCIsStore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCIsDayOff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCStartWork As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCEndWork As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCStartWorkOt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCEndWorkOt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCBreakHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCTotalHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCPointOt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCValid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCIdScheduleType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCIn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGCOtPotention As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
