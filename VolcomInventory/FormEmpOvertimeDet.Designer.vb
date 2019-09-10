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
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOnlyDp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartementSub = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeePosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCConversionType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RISLUEType = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RISLUETypeView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStartWorkSub = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITEAttendanceStartSub = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GCEndWorkSub = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITEAttendanceEndSub = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GCBreakHoursSub = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITEBreak = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GCTotalHoursSub = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBEmpDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.SBEmpAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.LUEOvertimeType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TECreatedAt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SBMark = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.MEOvertimeNote = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.PCReportStatus = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TEReportStatus = New DevExpress.XtraEditors.TextEdit()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLUEType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RISLUETypeView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEAttendanceStartSub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEAttendanceStartSub.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEAttendanceEndSub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEAttendanceEndSub.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEBreak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.LUEOvertimeType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.PCReportStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCReportStatus.SuspendLayout()
        CType(Me.TEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RISLUEType, Me.RITEAttendanceStartSub, Me.RITEAttendanceEndSub, Me.RITEBreak})
        Me.GCEmployee.Size = New System.Drawing.Size(982, 426)
        Me.GCEmployee.TabIndex = 0
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.ColumnPanelRowHeight = 32
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdEmployee, Me.GCOnlyDp, Me.GCIdDepartement, Me.GCIdDepartementSub, Me.GCDepartement, Me.GCDate, Me.GCEmployeeCode, Me.GCEmployeeName, Me.GCEmployeePosition, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCConversionType, Me.GCStartWorkSub, Me.GCEndWorkSub, Me.GCBreakHoursSub, Me.GCTotalHoursSub})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 2
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDate, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
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
        'GCIdDepartementSub
        '
        Me.GCIdDepartementSub.FieldName = "id_departement_sub"
        Me.GCIdDepartementSub.Name = "GCIdDepartementSub"
        Me.GCIdDepartementSub.OptionsColumn.AllowEdit = False
        Me.GCIdDepartementSub.Width = 109
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.OptionsColumn.AllowEdit = False
        Me.GCDepartement.Visible = True
        Me.GCDepartement.VisibleIndex = 4
        '
        'GCDate
        '
        Me.GCDate.Caption = "Date"
        Me.GCDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GCDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCDate.FieldName = "date"
        Me.GCDate.Name = "GCDate"
        Me.GCDate.OptionsColumn.AllowEdit = False
        Me.GCDate.Visible = True
        Me.GCDate.VisibleIndex = 5
        '
        'GCEmployeeCode
        '
        Me.GCEmployeeCode.Caption = "NIP"
        Me.GCEmployeeCode.FieldName = "employee_code"
        Me.GCEmployeeCode.Name = "GCEmployeeCode"
        Me.GCEmployeeCode.OptionsColumn.AllowEdit = False
        Me.GCEmployeeCode.Visible = True
        Me.GCEmployeeCode.VisibleIndex = 0
        '
        'GCEmployeeName
        '
        Me.GCEmployeeName.Caption = "Employee"
        Me.GCEmployeeName.FieldName = "employee_name"
        Me.GCEmployeeName.Name = "GCEmployeeName"
        Me.GCEmployeeName.OptionsColumn.AllowEdit = False
        Me.GCEmployeeName.Visible = True
        Me.GCEmployeeName.VisibleIndex = 1
        '
        'GCEmployeePosition
        '
        Me.GCEmployeePosition.Caption = "Employee Position"
        Me.GCEmployeePosition.FieldName = "employee_position"
        Me.GCEmployeePosition.Name = "GCEmployeePosition"
        Me.GCEmployeePosition.OptionsColumn.AllowEdit = False
        Me.GCEmployeePosition.Visible = True
        Me.GCEmployeePosition.VisibleIndex = 2
        Me.GCEmployeePosition.Width = 100
        '
        'GCIdEmployeeStatus
        '
        Me.GCIdEmployeeStatus.FieldName = "id_employee_status"
        Me.GCIdEmployeeStatus.Name = "GCIdEmployeeStatus"
        Me.GCIdEmployeeStatus.OptionsColumn.AllowEdit = False
        '
        'GCEmployeeStatus
        '
        Me.GCEmployeeStatus.Caption = "Employee Status"
        Me.GCEmployeeStatus.FieldName = "employee_status"
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.VisibleIndex = 3
        '
        'GCConversionType
        '
        Me.GCConversionType.AppearanceHeader.Options.UseTextOptions = True
        Me.GCConversionType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCConversionType.Caption = "Conversion Type"
        Me.GCConversionType.ColumnEdit = Me.RISLUEType
        Me.GCConversionType.FieldName = "conversion_type"
        Me.GCConversionType.Name = "GCConversionType"
        Me.GCConversionType.Visible = True
        Me.GCConversionType.VisibleIndex = 4
        Me.GCConversionType.Width = 91
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
        Me.RISLUETypeView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9, Me.GridColumn1})
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
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "to_salary"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GCStartWorkSub
        '
        Me.GCStartWorkSub.AppearanceHeader.Options.UseTextOptions = True
        Me.GCStartWorkSub.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCStartWorkSub.Caption = "Start Work"
        Me.GCStartWorkSub.ColumnEdit = Me.RITEAttendanceStartSub
        Me.GCStartWorkSub.DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss"
        Me.GCStartWorkSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCStartWorkSub.FieldName = "start_work_sub"
        Me.GCStartWorkSub.MinWidth = 150
        Me.GCStartWorkSub.Name = "GCStartWorkSub"
        Me.GCStartWorkSub.Visible = True
        Me.GCStartWorkSub.VisibleIndex = 5
        Me.GCStartWorkSub.Width = 150
        '
        'RITEAttendanceStartSub
        '
        Me.RITEAttendanceStartSub.AutoHeight = False
        Me.RITEAttendanceStartSub.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RITEAttendanceStartSub.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RITEAttendanceStartSub.DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss"
        Me.RITEAttendanceStartSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RITEAttendanceStartSub.EditFormat.FormatString = "dd MMM yyyy HH:mm:ss"
        Me.RITEAttendanceStartSub.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RITEAttendanceStartSub.Mask.EditMask = "dd MMM yyyy HH:mm:ss"
        Me.RITEAttendanceStartSub.Mask.UseMaskAsDisplayFormat = True
        Me.RITEAttendanceStartSub.Name = "RITEAttendanceStartSub"
        '
        'GCEndWorkSub
        '
        Me.GCEndWorkSub.AppearanceHeader.Options.UseTextOptions = True
        Me.GCEndWorkSub.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEndWorkSub.Caption = "End Work"
        Me.GCEndWorkSub.ColumnEdit = Me.RITEAttendanceEndSub
        Me.GCEndWorkSub.DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss"
        Me.GCEndWorkSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCEndWorkSub.FieldName = "end_work_sub"
        Me.GCEndWorkSub.MinWidth = 150
        Me.GCEndWorkSub.Name = "GCEndWorkSub"
        Me.GCEndWorkSub.Visible = True
        Me.GCEndWorkSub.VisibleIndex = 6
        Me.GCEndWorkSub.Width = 150
        '
        'RITEAttendanceEndSub
        '
        Me.RITEAttendanceEndSub.AutoHeight = False
        Me.RITEAttendanceEndSub.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RITEAttendanceEndSub.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RITEAttendanceEndSub.DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss"
        Me.RITEAttendanceEndSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RITEAttendanceEndSub.EditFormat.FormatString = "dd MMM yyyy HH:mm:ss"
        Me.RITEAttendanceEndSub.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RITEAttendanceEndSub.Mask.EditMask = "dd MMM yyyy HH:mm:ss"
        Me.RITEAttendanceEndSub.Mask.UseMaskAsDisplayFormat = True
        Me.RITEAttendanceEndSub.Name = "RITEAttendanceEndSub"
        '
        'GCBreakHoursSub
        '
        Me.GCBreakHoursSub.AppearanceHeader.Options.UseTextOptions = True
        Me.GCBreakHoursSub.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCBreakHoursSub.Caption = "Break (hours)"
        Me.GCBreakHoursSub.ColumnEdit = Me.RITEBreak
        Me.GCBreakHoursSub.DisplayFormat.FormatString = "N1"
        Me.GCBreakHoursSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBreakHoursSub.FieldName = "break_hours_sub"
        Me.GCBreakHoursSub.Name = "GCBreakHoursSub"
        Me.GCBreakHoursSub.Visible = True
        Me.GCBreakHoursSub.VisibleIndex = 7
        '
        'RITEBreak
        '
        Me.RITEBreak.AutoHeight = False
        Me.RITEBreak.DisplayFormat.FormatString = "N1"
        Me.RITEBreak.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEBreak.EditFormat.FormatString = "N1"
        Me.RITEBreak.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEBreak.Mask.EditMask = "N1"
        Me.RITEBreak.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RITEBreak.Mask.UseMaskAsDisplayFormat = True
        Me.RITEBreak.Name = "RITEBreak"
        '
        'GCTotalHoursSub
        '
        Me.GCTotalHoursSub.AppearanceHeader.Options.UseTextOptions = True
        Me.GCTotalHoursSub.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCTotalHoursSub.Caption = "Total (hours)"
        Me.GCTotalHoursSub.DisplayFormat.FormatString = "N1"
        Me.GCTotalHoursSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalHoursSub.FieldName = "total_hours_sub"
        Me.GCTotalHoursSub.Name = "GCTotalHoursSub"
        Me.GCTotalHoursSub.OptionsColumn.AllowEdit = False
        Me.GCTotalHoursSub.Visible = True
        Me.GCTotalHoursSub.VisibleIndex = 8
        Me.GCTotalHoursSub.Width = 72
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.PanelControl1)
        Me.GroupControl1.Controls.Add(Me.PanelControl2)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 70)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1008, 484)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Employee List"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.GCEmployee)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(20, 52)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(986, 430)
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
        Me.GroupControl2.Controls.Add(Me.LUEOvertimeType)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.LabelControl4)
        Me.GroupControl2.Controls.Add(Me.TECreatedBy)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.TECreatedAt)
        Me.GroupControl2.Controls.Add(Me.TENumber)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1008, 70)
        Me.GroupControl2.TabIndex = 2
        Me.GroupControl2.Text = "Overtime"
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
        Me.SBClose.Location = New System.Drawing.Point(781, 2)
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
        Me.SBPrint.Location = New System.Drawing.Point(856, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(75, 46)
        Me.SBPrint.TabIndex = 4
        Me.SBPrint.Text = "Print"
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
        Me.MEOvertimeNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MEOvertimeNote.Location = New System.Drawing.Point(105, 11)
        Me.MEOvertimeNote.Name = "MEOvertimeNote"
        Me.MEOvertimeNote.Size = New System.Drawing.Size(865, 70)
        Me.MEOvertimeNote.TabIndex = 12
        '
        'PanelControl6
        '
        Me.PanelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl6.Controls.Add(Me.PCReportStatus)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl6.Location = New System.Drawing.Point(20, 89)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(986, 34)
        Me.PanelControl6.TabIndex = 13
        '
        'PCReportStatus
        '
        Me.PCReportStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCReportStatus.Controls.Add(Me.LabelControl10)
        Me.PCReportStatus.Controls.Add(Me.TEReportStatus)
        Me.PCReportStatus.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCReportStatus.Location = New System.Drawing.Point(0, 0)
        Me.PCReportStatus.Name = "PCReportStatus"
        Me.PCReportStatus.Size = New System.Drawing.Size(240, 34)
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
        Me.TEReportStatus.Location = New System.Drawing.Point(105, 5)
        Me.TEReportStatus.Name = "TEReportStatus"
        Me.TEReportStatus.Properties.ReadOnly = True
        Me.TEReportStatus.Size = New System.Drawing.Size(124, 20)
        Me.TEReportStatus.TabIndex = 21
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
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLUEType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RISLUETypeView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEAttendanceStartSub.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEAttendanceStartSub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEAttendanceEndSub.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEAttendanceEndSub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEBreak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.LUEOvertimeType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.PCReportStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCReportStatus.ResumeLayout(False)
        Me.PCReportStatus.PerformLayout()
        CType(Me.TEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SBEmpDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBEmpAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LUEOvertimeType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents MEOvertimeNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RISLUEType As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RISLUETypeView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEReportStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TECreatedAt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PCReportStatus As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents RITEAttendanceStartSub As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RITEAttendanceEndSub As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RITEBreak As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOnlyDp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartementSub As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeePosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCConversionType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCStartWorkSub As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEndWorkSub As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCBreakHoursSub As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTotalHoursSub As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
