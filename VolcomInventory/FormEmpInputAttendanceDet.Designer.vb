<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpInputAttendanceDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpInputAttendanceDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LUEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TECreatedAt = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdEmpAttmInputDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeePosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCTimeIn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIDETime = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GCTimeOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBMark = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSubmit = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.DDBImportExcel = New DevExpress.XtraEditors.DropDownButton()
        Me.PMImportExcel = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BBINIKSogo = New DevExpress.XtraBars.BarButtonItem()
        Me.BBINIPVolcom = New DevExpress.XtraBars.BarButtonItem()
        Me.BMImportExcel = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SBRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LUEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedAt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIDETime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIDETime.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PMImportExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BMImportExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LUEReportStatus)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.TENumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.TECreatedBy)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TECreatedAt)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 70)
        Me.PanelControl1.TabIndex = 0
        '
        'LUEReportStatus
        '
        Me.LUEReportStatus.Location = New System.Drawing.Point(95, 38)
        Me.LUEReportStatus.Name = "LUEReportStatus"
        Me.LUEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LUEReportStatus.Properties.ReadOnly = True
        Me.LUEReportStatus.Size = New System.Drawing.Size(200, 20)
        Me.LUEReportStatus.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 41)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Report Status"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Number"
        '
        'TENumber
        '
        Me.TENumber.Location = New System.Drawing.Point(95, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(200, 20)
        Me.TENumber.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl3.Location = New System.Drawing.Point(489, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Created By"
        '
        'TECreatedBy
        '
        Me.TECreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TECreatedBy.Location = New System.Drawing.Point(572, 38)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(200, 20)
        Me.TECreatedBy.TabIndex = 5
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl2.Location = New System.Drawing.Point(489, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Created At"
        '
        'TECreatedAt
        '
        Me.TECreatedAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TECreatedAt.Location = New System.Drawing.Point(572, 12)
        Me.TECreatedAt.Name = "TECreatedAt"
        Me.TECreatedAt.Properties.ReadOnly = True
        Me.TECreatedAt.Size = New System.Drawing.Size(200, 20)
        Me.TECreatedAt.TabIndex = 3
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.GCEmployee)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 122)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 387)
        Me.PanelControl2.TabIndex = 1
        '
        'GCEmployee
        '
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(2, 2)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIDETime})
        Me.GCEmployee.Size = New System.Drawing.Size(780, 383)
        Me.GCEmployee.TabIndex = 0
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdEmpAttmInputDet, Me.GCIdDepartement, Me.GCDepartement, Me.GCIdEmployee, Me.GCEmployeeCode, Me.GCEmployeeName, Me.GCEmployeePosition, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCDate, Me.GCTimeIn, Me.GCTimeOut})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCIdEmpAttmInputDet
        '
        Me.GCIdEmpAttmInputDet.FieldName = "id_emp_attn_input_det"
        Me.GCIdEmpAttmInputDet.Name = "GCIdEmpAttmInputDet"
        Me.GCIdEmpAttmInputDet.OptionsColumn.AllowEdit = False
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
        'GCIdEmployee
        '
        Me.GCIdEmployee.FieldName = "id_employee"
        Me.GCIdEmployee.Name = "GCIdEmployee"
        Me.GCIdEmployee.OptionsColumn.AllowEdit = False
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
        'GCDate
        '
        Me.GCDate.Caption = "Date"
        Me.GCDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GCDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCDate.FieldName = "date"
        Me.GCDate.Name = "GCDate"
        Me.GCDate.OptionsColumn.AllowEdit = False
        Me.GCDate.Visible = True
        Me.GCDate.VisibleIndex = 4
        '
        'GCTimeIn
        '
        Me.GCTimeIn.Caption = "Time In"
        Me.GCTimeIn.ColumnEdit = Me.RIDETime
        Me.GCTimeIn.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GCTimeIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCTimeIn.FieldName = "time_in"
        Me.GCTimeIn.MinWidth = 200
        Me.GCTimeIn.Name = "GCTimeIn"
        Me.GCTimeIn.Visible = True
        Me.GCTimeIn.VisibleIndex = 5
        Me.GCTimeIn.Width = 200
        '
        'RIDETime
        '
        Me.RIDETime.AutoHeight = False
        Me.RIDETime.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RIDETime.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RIDETime.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.RIDETime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RIDETime.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.RIDETime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RIDETime.Mask.EditMask = "dd MMMM yyyy HH:mm:ss"
        Me.RIDETime.Mask.UseMaskAsDisplayFormat = True
        Me.RIDETime.Name = "RIDETime"
        '
        'GCTimeOut
        '
        Me.GCTimeOut.Caption = "Time Out"
        Me.GCTimeOut.ColumnEdit = Me.RIDETime
        Me.GCTimeOut.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GCTimeOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCTimeOut.FieldName = "time_out"
        Me.GCTimeOut.MinWidth = 200
        Me.GCTimeOut.Name = "GCTimeOut"
        Me.GCTimeOut.Visible = True
        Me.GCTimeOut.VisibleIndex = 6
        Me.GCTimeOut.Width = 200
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SBClose)
        Me.PanelControl3.Controls.Add(Me.SBMark)
        Me.PanelControl3.Controls.Add(Me.SBSubmit)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 509)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(784, 52)
        Me.PanelControl3.TabIndex = 2
        '
        'SBClose
        '
        Me.SBClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(594, 6)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(89, 40)
        Me.SBClose.TabIndex = 2
        Me.SBClose.Text = "Close"
        '
        'SBMark
        '
        Me.SBMark.Image = CType(resources.GetObject("SBMark.Image"), System.Drawing.Image)
        Me.SBMark.Location = New System.Drawing.Point(6, 6)
        Me.SBMark.Name = "SBMark"
        Me.SBMark.Size = New System.Drawing.Size(89, 40)
        Me.SBMark.TabIndex = 1
        Me.SBMark.Text = "Mark"
        '
        'SBSubmit
        '
        Me.SBSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBSubmit.Image = CType(resources.GetObject("SBSubmit.Image"), System.Drawing.Image)
        Me.SBSubmit.Location = New System.Drawing.Point(689, 6)
        Me.SBSubmit.Name = "SBSubmit"
        Me.SBSubmit.Size = New System.Drawing.Size(89, 40)
        Me.SBSubmit.TabIndex = 0
        Me.SBSubmit.Text = "Submit"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.DDBImportExcel)
        Me.PanelControl4.Controls.Add(Me.SBRemove)
        Me.PanelControl4.Controls.Add(Me.SBAdd)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(0, 70)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(784, 52)
        Me.PanelControl4.TabIndex = 2
        '
        'DDBImportExcel
        '
        Me.DDBImportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DDBImportExcel.DropDownControl = Me.PMImportExcel
        Me.DDBImportExcel.Image = CType(resources.GetObject("DDBImportExcel.Image"), System.Drawing.Image)
        Me.DDBImportExcel.Location = New System.Drawing.Point(453, 6)
        Me.DDBImportExcel.Name = "DDBImportExcel"
        Me.DDBImportExcel.Size = New System.Drawing.Size(135, 40)
        Me.DDBImportExcel.TabIndex = 3
        Me.DDBImportExcel.Text = "Import Excel"
        '
        'PMImportExcel
        '
        Me.PMImportExcel.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBINIKSogo), New DevExpress.XtraBars.LinkPersistInfo(Me.BBINIPVolcom)})
        Me.PMImportExcel.Manager = Me.BMImportExcel
        Me.PMImportExcel.Name = "PMImportExcel"
        '
        'BBINIKSogo
        '
        Me.BBINIKSogo.Caption = "NIK Sogo"
        Me.BBINIKSogo.Id = 0
        Me.BBINIKSogo.Name = "BBINIKSogo"
        '
        'BBINIPVolcom
        '
        Me.BBINIPVolcom.Caption = "NIP Volcom"
        Me.BBINIPVolcom.Id = 1
        Me.BBINIPVolcom.Name = "BBINIPVolcom"
        '
        'BMImportExcel
        '
        Me.BMImportExcel.DockControls.Add(Me.barDockControlTop)
        Me.BMImportExcel.DockControls.Add(Me.barDockControlBottom)
        Me.BMImportExcel.DockControls.Add(Me.barDockControlLeft)
        Me.BMImportExcel.DockControls.Add(Me.barDockControlRight)
        Me.BMImportExcel.Form = Me
        Me.BMImportExcel.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBINIKSogo, Me.BBINIPVolcom})
        Me.BMImportExcel.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(784, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 561)
        Me.barDockControlBottom.Size = New System.Drawing.Size(784, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 561)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(784, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 561)
        '
        'SBRemove
        '
        Me.SBRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBRemove.Image = CType(resources.GetObject("SBRemove.Image"), System.Drawing.Image)
        Me.SBRemove.Location = New System.Drawing.Point(594, 6)
        Me.SBRemove.Name = "SBRemove"
        Me.SBRemove.Size = New System.Drawing.Size(89, 40)
        Me.SBRemove.TabIndex = 2
        Me.SBRemove.Text = "Remove"
        '
        'SBAdd
        '
        Me.SBAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(689, 6)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(89, 40)
        Me.SBAdd.TabIndex = 0
        Me.SBAdd.Text = "Add"
        '
        'FormEmpInputAttendanceDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl4)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.MinimizeBox = False
        Me.Name = "FormEmpInputAttendanceDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Attendance Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LUEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedAt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIDETime.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIDETime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.PMImportExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BMImportExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBSubmit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCIdEmpAttmInputDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeePosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTimeIn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTimeOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIDETime As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECreatedAt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LUEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SBMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DDBImportExcel As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents PMImportExcel As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BBINIKSogo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BMImportExcel As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BBINIPVolcom As DevExpress.XtraBars.BarButtonItem
End Class
