<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpOvertimeDet
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpOvertimeDet))
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOnlyDp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIsStore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeePosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCConversionType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLUEType = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RISLUETypeView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStartWork = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITEAttendance = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GCEndWork = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCBreakHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITEBreakHours = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GCTotalHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIsDayOff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCPoint = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCValid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEValid = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBEmpDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.SBEmpAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.TEOvertimeEnd = New DevExpress.XtraEditors.DateEdit()
        Me.TEOvertimeStart = New DevExpress.XtraEditors.DateEdit()
        Me.TEOvertimeBreak = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.TETotalHours = New DevExpress.XtraEditors.TextEdit()
        Me.LUEOvertimeType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.DEOvertimeDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TECreatedAt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SBMark = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SBCheck = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.MEOvertimeNote = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.SLUEPayrollPeriod = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SLUEPayrollPeriodView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.PCReportStatus = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TEReportStatus = New DevExpress.XtraEditors.TextEdit()
        Me.PCCheckStatus = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.TECheckStatus = New DevExpress.XtraEditors.TextEdit()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLUEType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLUETypeView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEAttendance.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEBreakHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEValid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.TEOvertimeEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeBreak.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotalHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LUEOvertimeType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOvertimeDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOvertimeDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedAt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.MEOvertimeNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl6.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.SLUEPayrollPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEPayrollPeriodView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCReportStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCReportStatus.SuspendLayout()
        CType(Me.TEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCCheckStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCCheckStatus.SuspendLayout()
        CType(Me.TECheckStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(34, 67)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Overtime Date"
        '
        'TENumber
        '
        Me.TENumber.EditValue = "[autogenerate]"
        Me.TENumber.Location = New System.Drawing.Point(125, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(320, 20)
        Me.TENumber.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(34, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Number"
        '
        'GCEmployee
        '
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(2, 2)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RISLUEType, Me.RICEValid, Me.RITEBreakHours, Me.RITEAttendance})
        Me.GCEmployee.Size = New System.Drawing.Size(982, 377)
        Me.GCEmployee.TabIndex = 0
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdEmployee, Me.GCOnlyDp, Me.GCIdDepartement, Me.GCDepartement, Me.GCIsStore, Me.GCEmployeeCode, Me.GCEmployeeName, Me.GCEmployeePosition, Me.GCIdEmployeeLevel, Me.GCEmployeeLevel, Me.GCConversionType, Me.GCStartWork, Me.GCEndWork, Me.GCBreakHours, Me.GCTotalHours, Me.GCIsDayOff, Me.GCPoint, Me.GCValid})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCIdEmployee
        '
        Me.GCIdEmployee.FieldName = "id_employee"
        Me.GCIdEmployee.Name = "GCIdEmployee"
        Me.GCIdEmployee.OptionsColumn.AllowEdit = False
        '
        'GCOnlyDp
        '
        Me.GCOnlyDp.FieldName = "only_dp"
        Me.GCOnlyDp.Name = "GCOnlyDp"
        Me.GCOnlyDp.OptionsColumn.AllowEdit = False
        '
        'GCIdDepartement
        '
        Me.GCIdDepartement.FieldName = "id_departement"
        Me.GCIdDepartement.Name = "GCIdDepartement"
        Me.GCIdDepartement.OptionsColumn.AllowEdit = False
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.OptionsColumn.AllowEdit = False
        Me.GCDepartement.Visible = True
        Me.GCDepartement.VisibleIndex = 0
        '
        'GCIsStore
        '
        Me.GCIsStore.FieldName = "is_store"
        Me.GCIsStore.Name = "GCIsStore"
        '
        'GCEmployeeCode
        '
        Me.GCEmployeeCode.Caption = "Code"
        Me.GCEmployeeCode.FieldName = "employee_code"
        Me.GCEmployeeCode.Name = "GCEmployeeCode"
        Me.GCEmployeeCode.OptionsColumn.AllowEdit = False
        Me.GCEmployeeCode.Visible = True
        Me.GCEmployeeCode.VisibleIndex = 0
        '
        'GCEmployeeName
        '
        Me.GCEmployeeName.Caption = "Name"
        Me.GCEmployeeName.FieldName = "employee_name"
        Me.GCEmployeeName.Name = "GCEmployeeName"
        Me.GCEmployeeName.OptionsColumn.AllowEdit = False
        Me.GCEmployeeName.Visible = True
        Me.GCEmployeeName.VisibleIndex = 1
        '
        'GCEmployeePosition
        '
        Me.GCEmployeePosition.Caption = "Position"
        Me.GCEmployeePosition.FieldName = "employee_position"
        Me.GCEmployeePosition.Name = "GCEmployeePosition"
        Me.GCEmployeePosition.OptionsColumn.AllowEdit = False
        Me.GCEmployeePosition.Visible = True
        Me.GCEmployeePosition.VisibleIndex = 2
        '
        'GCIdEmployeeLevel
        '
        Me.GCIdEmployeeLevel.FieldName = "id_employee_level"
        Me.GCIdEmployeeLevel.Name = "GCIdEmployeeLevel"
        Me.GCIdEmployeeLevel.OptionsColumn.AllowEdit = False
        '
        'GCEmployeeLevel
        '
        Me.GCEmployeeLevel.Caption = "Level"
        Me.GCEmployeeLevel.FieldName = "employee_level"
        Me.GCEmployeeLevel.Name = "GCEmployeeLevel"
        Me.GCEmployeeLevel.OptionsColumn.AllowEdit = False
        Me.GCEmployeeLevel.Visible = True
        Me.GCEmployeeLevel.VisibleIndex = 3
        '
        'GCConversionType
        '
        Me.GCConversionType.Caption = "Conversion Type"
        Me.GCConversionType.ColumnEdit = Me.RISLUEType
        Me.GCConversionType.FieldName = "conversion_type"
        Me.GCConversionType.Name = "GCConversionType"
        Me.GCConversionType.Visible = True
        Me.GCConversionType.VisibleIndex = 4
        '
        'RISLUEType
        '
        Me.RISLUEType.AutoHeight = False
        Me.RISLUEType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RISLUEType.Name = "RISLUEType"
        Me.RISLUEType.View = Me.RISLUETypeView
        '
        'RISLUETypeView
        '
        Me.RISLUETypeView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9})
        Me.RISLUETypeView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RISLUETypeView.Name = "RISLUETypeView"
        Me.RISLUETypeView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RISLUETypeView.OptionsView.ShowGroupPanel = False
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
        'GCStartWork
        '
        Me.GCStartWork.Caption = "Start Work"
        Me.GCStartWork.ColumnEdit = Me.RITEAttendance
        Me.GCStartWork.DisplayFormat.FormatString = "dd MMM yyyy h:mm:ss tt"
        Me.GCStartWork.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCStartWork.FieldName = "start_work"
        Me.GCStartWork.MinWidth = 150
        Me.GCStartWork.Name = "GCStartWork"
        Me.GCStartWork.Visible = True
        Me.GCStartWork.VisibleIndex = 5
        Me.GCStartWork.Width = 150
        '
        'RITEAttendance
        '
        Me.RITEAttendance.AutoHeight = False
        Me.RITEAttendance.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RITEAttendance.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RITEAttendance.DisplayFormat.FormatString = "dd MMM yyyy h:mm:ss tt"
        Me.RITEAttendance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RITEAttendance.EditFormat.FormatString = "dd MMM yyyy h:mm:ss tt"
        Me.RITEAttendance.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RITEAttendance.Mask.EditMask = "dd MMM yyyy h:mm:ss tt"
        Me.RITEAttendance.Mask.UseMaskAsDisplayFormat = True
        Me.RITEAttendance.Name = "RITEAttendance"
        '
        'GCEndWork
        '
        Me.GCEndWork.Caption = "End Work"
        Me.GCEndWork.ColumnEdit = Me.RITEAttendance
        Me.GCEndWork.DisplayFormat.FormatString = "dd MMM yyyy h:mm:ss tt"
        Me.GCEndWork.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCEndWork.FieldName = "end_work"
        Me.GCEndWork.MinWidth = 150
        Me.GCEndWork.Name = "GCEndWork"
        Me.GCEndWork.Visible = True
        Me.GCEndWork.VisibleIndex = 6
        Me.GCEndWork.Width = 150
        '
        'GCBreakHours
        '
        Me.GCBreakHours.Caption = "Break (hours)"
        Me.GCBreakHours.ColumnEdit = Me.RITEBreakHours
        Me.GCBreakHours.DisplayFormat.FormatString = "N1"
        Me.GCBreakHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBreakHours.FieldName = "break_hours"
        Me.GCBreakHours.Name = "GCBreakHours"
        Me.GCBreakHours.Visible = True
        Me.GCBreakHours.VisibleIndex = 7
        '
        'RITEBreakHours
        '
        Me.RITEBreakHours.AutoHeight = False
        Me.RITEBreakHours.DisplayFormat.FormatString = "N1"
        Me.RITEBreakHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEBreakHours.EditFormat.FormatString = "N1"
        Me.RITEBreakHours.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEBreakHours.Mask.EditMask = "N1"
        Me.RITEBreakHours.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RITEBreakHours.Name = "RITEBreakHours"
        '
        'GCTotalHours
        '
        Me.GCTotalHours.Caption = "Total (hours)"
        Me.GCTotalHours.DisplayFormat.FormatString = "N1"
        Me.GCTotalHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalHours.FieldName = "total_hours"
        Me.GCTotalHours.Name = "GCTotalHours"
        Me.GCTotalHours.OptionsColumn.AllowEdit = False
        Me.GCTotalHours.Visible = True
        Me.GCTotalHours.VisibleIndex = 8
        '
        'GCIsDayOff
        '
        Me.GCIsDayOff.FieldName = "is_day_off"
        Me.GCIsDayOff.Name = "GCIsDayOff"
        '
        'GCPoint
        '
        Me.GCPoint.Caption = "Point"
        Me.GCPoint.DisplayFormat.FormatString = "N1"
        Me.GCPoint.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCPoint.FieldName = "point"
        Me.GCPoint.Name = "GCPoint"
        Me.GCPoint.OptionsColumn.AllowEdit = False
        Me.GCPoint.Visible = True
        Me.GCPoint.VisibleIndex = 9
        '
        'GCValid
        '
        Me.GCValid.Caption = "Valid"
        Me.GCValid.ColumnEdit = Me.RICEValid
        Me.GCValid.FieldName = "valid"
        Me.GCValid.Name = "GCValid"
        Me.GCValid.Visible = True
        Me.GCValid.VisibleIndex = 10
        '
        'RICEValid
        '
        Me.RICEValid.AutoHeight = False
        Me.RICEValid.Name = "RICEValid"
        Me.RICEValid.ValueChecked = "yes"
        Me.RICEValid.ValueUnchecked = "no"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.PanelControl1)
        Me.GroupControl1.Controls.Add(Me.PanelControl2)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 119)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1008, 435)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Employee List"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.GCEmployee)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(20, 52)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(986, 381)
        Me.PanelControl1.TabIndex = 1
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBEmpDelete)
        Me.PanelControl2.Controls.Add(Me.SBEmpAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(986, 50)
        Me.PanelControl2.TabIndex = 2
        '
        'SBEmpDelete
        '
        Me.SBEmpDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBEmpDelete.Image = CType(resources.GetObject("SBEmpDelete.Image"), System.Drawing.Image)
        Me.SBEmpDelete.Location = New System.Drawing.Point(827, 5)
        Me.SBEmpDelete.Name = "SBEmpDelete"
        Me.SBEmpDelete.Size = New System.Drawing.Size(75, 40)
        Me.SBEmpDelete.TabIndex = 1
        Me.SBEmpDelete.Text = "Delete"
        '
        'SBEmpAdd
        '
        Me.SBEmpAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBEmpAdd.Image = CType(resources.GetObject("SBEmpAdd.Image"), System.Drawing.Image)
        Me.SBEmpAdd.Location = New System.Drawing.Point(906, 5)
        Me.SBEmpAdd.Name = "SBEmpAdd"
        Me.SBEmpAdd.Size = New System.Drawing.Size(75, 40)
        Me.SBEmpAdd.TabIndex = 0
        Me.SBEmpAdd.Text = "Add"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.TEOvertimeEnd)
        Me.GroupControl2.Controls.Add(Me.TEOvertimeStart)
        Me.GroupControl2.Controls.Add(Me.TEOvertimeBreak)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.LabelControl11)
        Me.GroupControl2.Controls.Add(Me.TETotalHours)
        Me.GroupControl2.Controls.Add(Me.LUEOvertimeType)
        Me.GroupControl2.Controls.Add(Me.LabelControl9)
        Me.GroupControl2.Controls.Add(Me.LabelControl8)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.LabelControl4)
        Me.GroupControl2.Controls.Add(Me.TECreatedBy)
        Me.GroupControl2.Controls.Add(Me.DEOvertimeDate)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.TECreatedAt)
        Me.GroupControl2.Controls.Add(Me.TENumber)
        Me.GroupControl2.Controls.Add(Me.LabelControl2)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1008, 119)
        Me.GroupControl2.TabIndex = 2
        Me.GroupControl2.Text = "Overtime"
        '
        'TEOvertimeEnd
        '
        Me.TEOvertimeEnd.EditValue = Nothing
        Me.TEOvertimeEnd.Location = New System.Drawing.Point(825, 64)
        Me.TEOvertimeEnd.Name = "TEOvertimeEnd"
        Me.TEOvertimeEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.TEOvertimeEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy h:mm:ss tt"
        Me.TEOvertimeEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeEnd.Properties.EditFormat.FormatString = "dd MMM yyyy h:mm:ss tt"
        Me.TEOvertimeEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeEnd.Properties.Mask.EditMask = "dd MMM yyyy h:mm:ss tt"
        Me.TEOvertimeEnd.Size = New System.Drawing.Size(165, 20)
        Me.TEOvertimeEnd.TabIndex = 25
        '
        'TEOvertimeStart
        '
        Me.TEOvertimeStart.EditValue = Nothing
        Me.TEOvertimeStart.Location = New System.Drawing.Point(646, 64)
        Me.TEOvertimeStart.Name = "TEOvertimeStart"
        Me.TEOvertimeStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.TEOvertimeStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy h:mm:ss tt"
        Me.TEOvertimeStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeStart.Properties.EditFormat.FormatString = "dd MMM yyyy h:mm:ss tt"
        Me.TEOvertimeStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeStart.Properties.Mask.EditMask = "dd MMM yyyy h:mm:ss tt"
        Me.TEOvertimeStart.Size = New System.Drawing.Size(165, 20)
        Me.TEOvertimeStart.TabIndex = 24
        '
        'TEOvertimeBreak
        '
        Me.TEOvertimeBreak.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEOvertimeBreak.EditValue = New Decimal(New Integer() {0, 0, 0, 65536})
        Me.TEOvertimeBreak.Location = New System.Drawing.Point(646, 90)
        Me.TEOvertimeBreak.Name = "TEOvertimeBreak"
        Me.TEOvertimeBreak.Properties.DisplayFormat.FormatString = "N1"
        Me.TEOvertimeBreak.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEOvertimeBreak.Properties.EditFormat.FormatString = "N1"
        Me.TEOvertimeBreak.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEOvertimeBreak.Properties.Mask.EditMask = "N1"
        Me.TEOvertimeBreak.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEOvertimeBreak.Size = New System.Drawing.Size(100, 20)
        Me.TEOvertimeBreak.TabIndex = 23
        '
        'LabelControl12
        '
        Me.LabelControl12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl12.Location = New System.Drawing.Point(770, 93)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(109, 13)
        Me.LabelControl12.TabIndex = 22
        Me.LabelControl12.Text = "Total Overtime (hours)"
        '
        'LabelControl11
        '
        Me.LabelControl11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl11.Location = New System.Drawing.Point(570, 93)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl11.TabIndex = 21
        Me.LabelControl11.Text = "Break (hours)"
        '
        'TETotalHours
        '
        Me.TETotalHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TETotalHours.EditValue = ""
        Me.TETotalHours.Location = New System.Drawing.Point(890, 90)
        Me.TETotalHours.Name = "TETotalHours"
        Me.TETotalHours.Properties.DisplayFormat.FormatString = "N1"
        Me.TETotalHours.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TETotalHours.Properties.EditFormat.FormatString = "N1"
        Me.TETotalHours.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TETotalHours.Properties.ReadOnly = True
        Me.TETotalHours.Size = New System.Drawing.Size(100, 20)
        Me.TETotalHours.TabIndex = 18
        '
        'LUEOvertimeType
        '
        Me.LUEOvertimeType.Location = New System.Drawing.Point(125, 38)
        Me.LUEOvertimeType.Name = "LUEOvertimeType"
        Me.LUEOvertimeType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUEOvertimeType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ot_type", "Overtime Type")})
        Me.LUEOvertimeType.Size = New System.Drawing.Size(320, 20)
        Me.LUEOvertimeType.TabIndex = 15
        '
        'LabelControl9
        '
        Me.LabelControl9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl9.Location = New System.Drawing.Point(815, 67)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl9.TabIndex = 14
        Me.LabelControl9.Text = "-"
        '
        'LabelControl8
        '
        Me.LabelControl8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl8.Location = New System.Drawing.Point(570, 67)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl8.TabIndex = 13
        Me.LabelControl8.Text = "Time"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(34, 41)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl5.TabIndex = 10
        Me.LabelControl5.Text = "Overtime Type"
        '
        'LabelControl4
        '
        Me.LabelControl4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl4.Location = New System.Drawing.Point(570, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "Created By"
        '
        'TECreatedBy
        '
        Me.TECreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TECreatedBy.Location = New System.Drawing.Point(646, 12)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(344, 20)
        Me.TECreatedBy.TabIndex = 8
        '
        'DEOvertimeDate
        '
        Me.DEOvertimeDate.EditValue = Nothing
        Me.DEOvertimeDate.Location = New System.Drawing.Point(125, 64)
        Me.DEOvertimeDate.Name = "DEOvertimeDate"
        Me.DEOvertimeDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEOvertimeDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOvertimeDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOvertimeDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEOvertimeDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEOvertimeDate.Size = New System.Drawing.Size(320, 20)
        Me.DEOvertimeDate.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl3.Location = New System.Drawing.Point(570, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Created At"
        '
        'TECreatedAt
        '
        Me.TECreatedAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TECreatedAt.Location = New System.Drawing.Point(646, 38)
        Me.TECreatedAt.Name = "TECreatedAt"
        Me.TECreatedAt.Properties.ReadOnly = True
        Me.TECreatedAt.Size = New System.Drawing.Size(344, 20)
        Me.TECreatedAt.TabIndex = 5
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(13, 13)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Overtime Purpose"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SBMark)
        Me.PanelControl3.Controls.Add(Me.SBClose)
        Me.PanelControl3.Controls.Add(Me.SBPrint)
        Me.PanelControl3.Controls.Add(Me.SBCheck)
        Me.PanelControl3.Controls.Add(Me.SBSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 679)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1008, 50)
        Me.PanelControl3.TabIndex = 15
        '
        'SBMark
        '
        Me.SBMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.SBMark.Enabled = False
        Me.SBMark.Image = CType(resources.GetObject("SBMark.Image"), System.Drawing.Image)
        Me.SBMark.Location = New System.Drawing.Point(2, 2)
        Me.SBMark.Name = "SBMark"
        Me.SBMark.Size = New System.Drawing.Size(75, 46)
        Me.SBMark.TabIndex = 3
        Me.SBMark.Text = "Mark"
        '
        'SBClose
        '
        Me.SBClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(703, 2)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(75, 46)
        Me.SBClose.TabIndex = 2
        Me.SBClose.Text = "Close"
        '
        'SBPrint
        '
        Me.SBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrint.Enabled = False
        Me.SBPrint.Image = CType(resources.GetObject("SBPrint.Image"), System.Drawing.Image)
        Me.SBPrint.Location = New System.Drawing.Point(778, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(75, 46)
        Me.SBPrint.TabIndex = 4
        Me.SBPrint.Text = "Print"
        '
        'SBCheck
        '
        Me.SBCheck.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBCheck.Image = CType(resources.GetObject("SBCheck.Image"), System.Drawing.Image)
        Me.SBCheck.Location = New System.Drawing.Point(853, 2)
        Me.SBCheck.Name = "SBCheck"
        Me.SBCheck.Size = New System.Drawing.Size(78, 46)
        Me.SBCheck.TabIndex = 5
        Me.SBCheck.Text = "Check"
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(931, 2)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 46)
        Me.SBSave.TabIndex = 1
        Me.SBSave.Text = "Save"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.PanelControl4)
        Me.GroupControl3.Controls.Add(Me.PanelControl6)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 554)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(1008, 125)
        Me.GroupControl3.TabIndex = 15
        Me.GroupControl3.Text = "Detail"
        '
        'PanelControl4
        '
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.LabelControl6)
        Me.PanelControl4.Controls.Add(Me.MEOvertimeNote)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl4.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(986, 87)
        Me.PanelControl4.TabIndex = 27
        '
        'MEOvertimeNote
        '
        Me.MEOvertimeNote.Location = New System.Drawing.Point(105, 11)
        Me.MEOvertimeNote.Name = "MEOvertimeNote"
        Me.MEOvertimeNote.Size = New System.Drawing.Size(865, 70)
        Me.MEOvertimeNote.TabIndex = 12
        '
        'PanelControl6
        '
        Me.PanelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl6.Controls.Add(Me.PanelControl5)
        Me.PanelControl6.Controls.Add(Me.PCReportStatus)
        Me.PanelControl6.Controls.Add(Me.PCCheckStatus)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl6.Location = New System.Drawing.Point(20, 89)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(986, 34)
        Me.PanelControl6.TabIndex = 13
        '
        'PanelControl5
        '
        Me.PanelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl5.Controls.Add(Me.SLUEPayrollPeriod)
        Me.PanelControl5.Controls.Add(Me.LabelControl7)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl5.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(546, 34)
        Me.PanelControl5.TabIndex = 28
        '
        'SLUEPayrollPeriod
        '
        Me.SLUEPayrollPeriod.Location = New System.Drawing.Point(105, 5)
        Me.SLUEPayrollPeriod.Name = "SLUEPayrollPeriod"
        Me.SLUEPayrollPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEPayrollPeriod.Properties.View = Me.SLUEPayrollPeriodView
        Me.SLUEPayrollPeriod.Size = New System.Drawing.Size(241, 20)
        Me.SLUEPayrollPeriod.TabIndex = 17
        '
        'SLUEPayrollPeriodView
        '
        Me.SLUEPayrollPeriodView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16})
        Me.SLUEPayrollPeriodView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SLUEPayrollPeriodView.Name = "SLUEPayrollPeriodView"
        Me.SLUEPayrollPeriodView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SLUEPayrollPeriodView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.FieldName = "id_payroll"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Periode Start"
        Me.GridColumn14.FieldName = "periode_start"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Periode End"
        Me.GridColumn15.FieldName = "periode_end"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 1
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Periode"
        Me.GridColumn16.FieldName = "periode"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(11, 8)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl7.TabIndex = 13
        Me.LabelControl7.Text = "Payroll Period"
        '
        'PCReportStatus
        '
        Me.PCReportStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCReportStatus.Controls.Add(Me.LabelControl10)
        Me.PCReportStatus.Controls.Add(Me.TEReportStatus)
        Me.PCReportStatus.Dock = System.Windows.Forms.DockStyle.Right
        Me.PCReportStatus.Location = New System.Drawing.Point(546, 0)
        Me.PCReportStatus.Name = "PCReportStatus"
        Me.PCReportStatus.Size = New System.Drawing.Size(220, 34)
        Me.PCReportStatus.TabIndex = 25
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(7, 8)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl10.TabIndex = 17
        Me.LabelControl10.Text = "Report Status"
        '
        'TEReportStatus
        '
        Me.TEReportStatus.Location = New System.Drawing.Point(80, 5)
        Me.TEReportStatus.Name = "TEReportStatus"
        Me.TEReportStatus.Properties.ReadOnly = True
        Me.TEReportStatus.Size = New System.Drawing.Size(124, 20)
        Me.TEReportStatus.TabIndex = 21
        '
        'PCCheckStatus
        '
        Me.PCCheckStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCCheckStatus.Controls.Add(Me.LabelControl13)
        Me.PCCheckStatus.Controls.Add(Me.TECheckStatus)
        Me.PCCheckStatus.Dock = System.Windows.Forms.DockStyle.Right
        Me.PCCheckStatus.Location = New System.Drawing.Point(766, 0)
        Me.PCCheckStatus.Name = "PCCheckStatus"
        Me.PCCheckStatus.Size = New System.Drawing.Size(220, 34)
        Me.PCCheckStatus.TabIndex = 26
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(7, 8)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl13.TabIndex = 17
        Me.LabelControl13.Text = "Check Status"
        '
        'TECheckStatus
        '
        Me.TECheckStatus.Location = New System.Drawing.Point(80, 5)
        Me.TECheckStatus.Name = "TECheckStatus"
        Me.TECheckStatus.Properties.ReadOnly = True
        Me.TECheckStatus.Size = New System.Drawing.Size(124, 20)
        Me.TECheckStatus.TabIndex = 21
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'FormEmpOvertimeDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.PanelControl3)
        Me.MinimizeBox = False
        Me.Name = "FormEmpOvertimeDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overtime Detail"
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLUEType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLUETypeView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEAttendance.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEBreakHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEValid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.TEOvertimeEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeBreak.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotalHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LUEOvertimeType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOvertimeDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOvertimeDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedAt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.MEOvertimeNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl6.ResumeLayout(False)
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.SLUEPayrollPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEPayrollPeriodView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCReportStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCReportStatus.ResumeLayout(False)
        Me.PCReportStatus.PerformLayout()
        CType(Me.TEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCCheckStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCCheckStatus.ResumeLayout(False)
        Me.PCCheckStatus.PerformLayout()
        CType(Me.TECheckStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SBEmpDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBEmpAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeePosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEOvertimeDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LUEOvertimeType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents MEOvertimeNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TETotalHours As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCOnlyDp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCConversionType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RISLUEType As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RISLUETypeView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEReportStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TECreatedAt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEOvertimeBreak As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCStartWork As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEndWork As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCValid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEValid As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents SBCheck As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCReportStatus As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCCheckStatus As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECheckStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLUEPayrollPeriod As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLUEPayrollPeriodView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCTotalHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RITEBreakHours As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GCBreakHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIsDayOff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCPoint As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIsStore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TEOvertimeStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TEOvertimeEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents RITEAttendance As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
End Class
