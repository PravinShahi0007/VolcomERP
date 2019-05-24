<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposeEmpSalaryDet
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProposeEmpSalaryDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.DECreatedAt = New DevExpress.XtraEditors.DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.DEEffectiveDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBMark = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSubmit = New DevExpress.XtraEditors.SimpleButton()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.CMSGCEmployee = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveEmployeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCEmployeeId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCBasicSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITESalary = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GCJobAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCMealAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCTransportAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHouseAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCAttendanceAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCTotalSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBInsertEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.SBRemoveEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreatedAt.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreatedAt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEffectiveDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSGCEmployee.SuspendLayout()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITESalary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TECreatedBy)
        Me.PanelControl1.Controls.Add(Me.DECreatedAt)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.TENumber)
        Me.PanelControl1.Controls.Add(Me.DEEffectiveDate)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1008, 72)
        Me.PanelControl1.TabIndex = 0
        '
        'TECreatedBy
        '
        Me.TECreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TECreatedBy.Location = New System.Drawing.Point(784, 12)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(203, 20)
        Me.TECreatedBy.TabIndex = 8
        '
        'DECreatedAt
        '
        Me.DECreatedAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DECreatedAt.EditValue = Nothing
        Me.DECreatedAt.Location = New System.Drawing.Point(784, 38)
        Me.DECreatedAt.Name = "DECreatedAt"
        Me.DECreatedAt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DECreatedAt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreatedAt.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreatedAt.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedAt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreatedAt.Properties.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedAt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreatedAt.Properties.Mask.EditMask = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedAt.Properties.ReadOnly = True
        Me.DECreatedAt.Size = New System.Drawing.Size(203, 20)
        Me.DECreatedAt.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(703, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Created At"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(703, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Created By"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Number"
        '
        'TENumber
        '
        Me.TENumber.Location = New System.Drawing.Point(105, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(203, 20)
        Me.TENumber.TabIndex = 3
        '
        'DEEffectiveDate
        '
        Me.DEEffectiveDate.EditValue = Nothing
        Me.DEEffectiveDate.Location = New System.Drawing.Point(105, 38)
        Me.DEEffectiveDate.Name = "DEEffectiveDate"
        Me.DEEffectiveDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEEffectiveDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEffectiveDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEffectiveDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEEffectiveDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEffectiveDate.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEEffectiveDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEffectiveDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEEffectiveDate.Size = New System.Drawing.Size(203, 20)
        Me.DEEffectiveDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Effective Date"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SBPrint)
        Me.PanelControl3.Controls.Add(Me.SBClose)
        Me.PanelControl3.Controls.Add(Me.SBMark)
        Me.PanelControl3.Controls.Add(Me.SBSubmit)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 681)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1008, 48)
        Me.PanelControl3.TabIndex = 2
        '
        'SBPrint
        '
        Me.SBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrint.Image = CType(resources.GetObject("SBPrint.Image"), System.Drawing.Image)
        Me.SBPrint.Location = New System.Drawing.Point(721, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(95, 44)
        Me.SBPrint.TabIndex = 3
        Me.SBPrint.Text = "Print"
        '
        'SBClose
        '
        Me.SBClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(816, 2)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(95, 44)
        Me.SBClose.TabIndex = 4
        Me.SBClose.Text = "Close"
        '
        'SBMark
        '
        Me.SBMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.SBMark.Image = CType(resources.GetObject("SBMark.Image"), System.Drawing.Image)
        Me.SBMark.Location = New System.Drawing.Point(2, 2)
        Me.SBMark.Name = "SBMark"
        Me.SBMark.Size = New System.Drawing.Size(95, 44)
        Me.SBMark.TabIndex = 2
        Me.SBMark.Text = "Mark"
        '
        'SBSubmit
        '
        Me.SBSubmit.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSubmit.Image = CType(resources.GetObject("SBSubmit.Image"), System.Drawing.Image)
        Me.SBSubmit.Location = New System.Drawing.Point(911, 2)
        Me.SBSubmit.Name = "SBSubmit"
        Me.SBSubmit.Size = New System.Drawing.Size(95, 44)
        Me.SBSubmit.TabIndex = 1
        Me.SBSubmit.Text = "Submit"
        '
        'GCEmployee
        '
        Me.GCEmployee.ContextMenuStrip = Me.CMSGCEmployee
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(0, 121)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RITESalary})
        Me.GCEmployee.Size = New System.Drawing.Size(1008, 466)
        Me.GCEmployee.TabIndex = 3
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'CMSGCEmployee
        '
        Me.CMSGCEmployee.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveEmployeeToolStripMenuItem})
        Me.CMSGCEmployee.Name = "CMSGCEmployee"
        Me.CMSGCEmployee.Size = New System.Drawing.Size(173, 26)
        '
        'RemoveEmployeeToolStripMenuItem
        '
        Me.RemoveEmployeeToolStripMenuItem.Name = "RemoveEmployeeToolStripMenuItem"
        Me.RemoveEmployeeToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.RemoveEmployeeToolStripMenuItem.Text = "Remove Employee"
        '
        'GVEmployee
        '
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCEmployeeId, Me.GCNIP, Me.GCName, Me.GCIdDepartement, Me.GCDepartement, Me.GCPosition, Me.GCIdEmployeeLevel, Me.GCLevel, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCBasicSalary, Me.GCJobAllowance, Me.GCMealAllowance, Me.GCTransportAllowance, Me.GCHouseAllowance, Me.GCAttendanceAllowance, Me.GCTotalSalary})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", Me.GCBasicSalary, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", Me.GCJobAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", Me.GCMealAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", Me.GCTransportAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house", Me.GCHouseAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", Me.GCAttendanceAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary", Me.GCTotalSalary, "{0:N0}")})
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsFind.AlwaysVisible = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowFooter = True
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCEmployeeId
        '
        Me.GCEmployeeId.FieldName = "id_employee"
        Me.GCEmployeeId.Name = "GCEmployeeId"
        Me.GCEmployeeId.OptionsColumn.AllowEdit = False
        '
        'GCNIP
        '
        Me.GCNIP.Caption = "NIP"
        Me.GCNIP.FieldName = "employee_code"
        Me.GCNIP.Name = "GCNIP"
        Me.GCNIP.OptionsColumn.AllowEdit = False
        Me.GCNIP.Visible = True
        Me.GCNIP.VisibleIndex = 0
        '
        'GCName
        '
        Me.GCName.Caption = "Name"
        Me.GCName.FieldName = "employee_name"
        Me.GCName.Name = "GCName"
        Me.GCName.OptionsColumn.AllowEdit = False
        Me.GCName.Visible = True
        Me.GCName.VisibleIndex = 1
        '
        'GCIdDepartement
        '
        Me.GCIdDepartement.FieldName = "id_departement"
        Me.GCIdDepartement.Name = "GCIdDepartement"
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
        'GCPosition
        '
        Me.GCPosition.Caption = "Position"
        Me.GCPosition.FieldName = "employee_position"
        Me.GCPosition.Name = "GCPosition"
        Me.GCPosition.OptionsColumn.AllowEdit = False
        Me.GCPosition.Visible = True
        Me.GCPosition.VisibleIndex = 2
        '
        'GCIdEmployeeLevel
        '
        Me.GCIdEmployeeLevel.FieldName = "id_employee_level"
        Me.GCIdEmployeeLevel.Name = "GCIdEmployeeLevel"
        '
        'GCLevel
        '
        Me.GCLevel.Caption = "Level"
        Me.GCLevel.FieldName = "employee_level"
        Me.GCLevel.Name = "GCLevel"
        Me.GCLevel.OptionsColumn.AllowEdit = False
        Me.GCLevel.Visible = True
        Me.GCLevel.VisibleIndex = 3
        '
        'GCIdEmployeeStatus
        '
        Me.GCIdEmployeeStatus.FieldName = "id_employee_status"
        Me.GCIdEmployeeStatus.Name = "GCIdEmployeeStatus"
        '
        'GCEmployeeStatus
        '
        Me.GCEmployeeStatus.Caption = "Employee Status"
        Me.GCEmployeeStatus.FieldName = "employee_status"
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.VisibleIndex = 4
        '
        'GCBasicSalary
        '
        Me.GCBasicSalary.Caption = "Basic Salary"
        Me.GCBasicSalary.ColumnEdit = Me.RITESalary
        Me.GCBasicSalary.DisplayFormat.FormatString = "N0"
        Me.GCBasicSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBasicSalary.FieldName = "basic_salary"
        Me.GCBasicSalary.Name = "GCBasicSalary"
        Me.GCBasicSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", "{0:N0}")})
        Me.GCBasicSalary.Visible = True
        Me.GCBasicSalary.VisibleIndex = 5
        Me.GCBasicSalary.Width = 67
        '
        'RITESalary
        '
        Me.RITESalary.AutoHeight = False
        Me.RITESalary.Name = "RITESalary"
        '
        'GCJobAllowance
        '
        Me.GCJobAllowance.Caption = "Job Allowance"
        Me.GCJobAllowance.ColumnEdit = Me.RITESalary
        Me.GCJobAllowance.DisplayFormat.FormatString = "N0"
        Me.GCJobAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCJobAllowance.FieldName = "allow_job"
        Me.GCJobAllowance.Name = "GCJobAllowance"
        Me.GCJobAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", "{0:N0}")})
        Me.GCJobAllowance.Visible = True
        Me.GCJobAllowance.VisibleIndex = 6
        Me.GCJobAllowance.Width = 78
        '
        'GCMealAllowance
        '
        Me.GCMealAllowance.Caption = "Meal Allowance"
        Me.GCMealAllowance.ColumnEdit = Me.RITESalary
        Me.GCMealAllowance.DisplayFormat.FormatString = "N0"
        Me.GCMealAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCMealAllowance.FieldName = "allow_meal"
        Me.GCMealAllowance.Name = "GCMealAllowance"
        Me.GCMealAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", "{0:N0}")})
        Me.GCMealAllowance.Visible = True
        Me.GCMealAllowance.VisibleIndex = 7
        Me.GCMealAllowance.Width = 83
        '
        'GCTransportAllowance
        '
        Me.GCTransportAllowance.Caption = "Transport Allowance"
        Me.GCTransportAllowance.ColumnEdit = Me.RITESalary
        Me.GCTransportAllowance.DisplayFormat.FormatString = "N0"
        Me.GCTransportAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTransportAllowance.FieldName = "allow_trans"
        Me.GCTransportAllowance.Name = "GCTransportAllowance"
        Me.GCTransportAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", "{0:N0}")})
        Me.GCTransportAllowance.Visible = True
        Me.GCTransportAllowance.VisibleIndex = 8
        Me.GCTransportAllowance.Width = 108
        '
        'GCHouseAllowance
        '
        Me.GCHouseAllowance.Caption = "House Allowance"
        Me.GCHouseAllowance.ColumnEdit = Me.RITESalary
        Me.GCHouseAllowance.DisplayFormat.FormatString = "N0"
        Me.GCHouseAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHouseAllowance.FieldName = "allow_house"
        Me.GCHouseAllowance.Name = "GCHouseAllowance"
        Me.GCHouseAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house", "{0:N0}")})
        Me.GCHouseAllowance.Visible = True
        Me.GCHouseAllowance.VisibleIndex = 9
        Me.GCHouseAllowance.Width = 91
        '
        'GCAttendanceAllowance
        '
        Me.GCAttendanceAllowance.Caption = "Attendance Allowance"
        Me.GCAttendanceAllowance.ColumnEdit = Me.RITESalary
        Me.GCAttendanceAllowance.DisplayFormat.FormatString = "N0"
        Me.GCAttendanceAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCAttendanceAllowance.FieldName = "allow_car"
        Me.GCAttendanceAllowance.Name = "GCAttendanceAllowance"
        Me.GCAttendanceAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", "{0:N0}")})
        Me.GCAttendanceAllowance.Visible = True
        Me.GCAttendanceAllowance.VisibleIndex = 10
        Me.GCAttendanceAllowance.Width = 117
        '
        'GCTotalSalary
        '
        Me.GCTotalSalary.Caption = "Total Salary"
        Me.GCTotalSalary.DisplayFormat.FormatString = "N0"
        Me.GCTotalSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalSalary.FieldName = "total_salary"
        Me.GCTotalSalary.Name = "GCTotalSalary"
        Me.GCTotalSalary.OptionsColumn.AllowEdit = False
        Me.GCTotalSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary", "{0:N0}")})
        Me.GCTotalSalary.UnboundExpression = "[basic_salary] + [allow_job] + [allow_meal] + [allow_trans] + [allow_house] + [al" &
    "low_car]"
        Me.GCTotalSalary.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GCTotalSalary.Visible = True
        Me.GCTotalSalary.VisibleIndex = 11
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBInsertEmployee)
        Me.PanelControl2.Controls.Add(Me.SBRemoveEmployee)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 72)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1008, 49)
        Me.PanelControl2.TabIndex = 3
        '
        'SBInsertEmployee
        '
        Me.SBInsertEmployee.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBInsertEmployee.Image = CType(resources.GetObject("SBInsertEmployee.Image"), System.Drawing.Image)
        Me.SBInsertEmployee.Location = New System.Drawing.Point(737, 2)
        Me.SBInsertEmployee.Name = "SBInsertEmployee"
        Me.SBInsertEmployee.Size = New System.Drawing.Size(130, 45)
        Me.SBInsertEmployee.TabIndex = 1
        Me.SBInsertEmployee.Text = "Insert Employee"
        '
        'SBRemoveEmployee
        '
        Me.SBRemoveEmployee.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBRemoveEmployee.Image = CType(resources.GetObject("SBRemoveEmployee.Image"), System.Drawing.Image)
        Me.SBRemoveEmployee.Location = New System.Drawing.Point(867, 2)
        Me.SBRemoveEmployee.Name = "SBRemoveEmployee"
        Me.SBRemoveEmployee.Size = New System.Drawing.Size(139, 45)
        Me.SBRemoveEmployee.TabIndex = 0
        Me.SBRemoveEmployee.Text = "Remove Employee"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.MENote)
        Me.PanelControl4.Controls.Add(Me.Label5)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(0, 587)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(1008, 94)
        Me.PanelControl4.TabIndex = 4
        '
        'MENote
        '
        Me.MENote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MENote.Location = New System.Drawing.Point(105, 17)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(882, 58)
        Me.MENote.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Note"
        '
        'FormProposeEmpSalaryDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GCEmployee)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl4)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormProposeEmpSalaryDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose Employee Salary Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreatedAt.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreatedAt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEffectiveDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSGCEmployee.ResumeLayout(False)
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITESalary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DECreatedAt As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DEEffectiveDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBInsertEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBRemoveEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSubmit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents CMSGCEmployee As ContextMenuStrip
    Friend WithEvents RemoveEmployeeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RITESalary As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCEmployeeId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCNIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCBasicSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCJobAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCMealAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTransportAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHouseAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCAttendanceAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTotalSalary As DevExpress.XtraGrid.Columns.GridColumn
End Class
