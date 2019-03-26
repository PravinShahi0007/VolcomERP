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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpOvertimeDet))
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBEmpDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.SBEmpAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.TEOvertimeEnd = New DevExpress.XtraEditors.TimeEdit()
        Me.TEOvertimeStart = New DevExpress.XtraEditors.TimeEdit()
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
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.LUEPayrollPeriod = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.MEOvertimeNote = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.TEOvertimeEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LUEPayrollPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEOvertimeNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TENumber.Location = New System.Drawing.Point(124, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(260, 20)
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
        Me.GCEmployee.Size = New System.Drawing.Size(758, 433)
        Me.GCEmployee.TabIndex = 0
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_employee"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "employee_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Name"
        Me.GridColumn3.FieldName = "employee_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Position"
        Me.GridColumn4.FieldName = "employee_position"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Level"
        Me.GridColumn5.FieldName = "employee_level"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.PanelControl1)
        Me.GroupControl1.Controls.Add(Me.PanelControl2)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 95)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(784, 491)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Employee List"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.GCEmployee)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(20, 52)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(762, 437)
        Me.PanelControl1.TabIndex = 1
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBEmpDelete)
        Me.PanelControl2.Controls.Add(Me.SBEmpAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(762, 50)
        Me.PanelControl2.TabIndex = 2
        '
        'SBEmpDelete
        '
        Me.SBEmpDelete.Image = CType(resources.GetObject("SBEmpDelete.Image"), System.Drawing.Image)
        Me.SBEmpDelete.Location = New System.Drawing.Point(603, 5)
        Me.SBEmpDelete.Name = "SBEmpDelete"
        Me.SBEmpDelete.Size = New System.Drawing.Size(75, 40)
        Me.SBEmpDelete.TabIndex = 1
        Me.SBEmpDelete.Text = "Delete"
        '
        'SBEmpAdd
        '
        Me.SBEmpAdd.Image = CType(resources.GetObject("SBEmpAdd.Image"), System.Drawing.Image)
        Me.SBEmpAdd.Location = New System.Drawing.Point(682, 5)
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
        Me.GroupControl2.Size = New System.Drawing.Size(784, 95)
        Me.GroupControl2.TabIndex = 2
        Me.GroupControl2.Text = "Overtime"
        '
        'TEOvertimeEnd
        '
        Me.TEOvertimeEnd.EditValue = New Date(2019, 3, 26, 0, 0, 0, 0)
        Me.TEOvertimeEnd.Location = New System.Drawing.Point(597, 64)
        Me.TEOvertimeEnd.Name = "TEOvertimeEnd"
        Me.TEOvertimeEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeEnd.Size = New System.Drawing.Size(100, 20)
        Me.TEOvertimeEnd.TabIndex = 20
        '
        'TEOvertimeStart
        '
        Me.TEOvertimeStart.EditValue = New Date(2019, 3, 26, 0, 0, 0, 0)
        Me.TEOvertimeStart.Location = New System.Drawing.Point(480, 64)
        Me.TEOvertimeStart.Name = "TEOvertimeStart"
        Me.TEOvertimeStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeStart.Size = New System.Drawing.Size(100, 20)
        Me.TEOvertimeStart.TabIndex = 19
        '
        'TETotalHours
        '
        Me.TETotalHours.EditValue = ""
        Me.TETotalHours.Location = New System.Drawing.Point(702, 64)
        Me.TETotalHours.Name = "TETotalHours"
        Me.TETotalHours.Properties.ReadOnly = True
        Me.TETotalHours.Size = New System.Drawing.Size(70, 20)
        Me.TETotalHours.TabIndex = 18
        '
        'LUEOvertimeType
        '
        Me.LUEOvertimeType.Location = New System.Drawing.Point(124, 38)
        Me.LUEOvertimeType.Name = "LUEOvertimeType"
        Me.LUEOvertimeType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUEOvertimeType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ot_type", "Overtime Type")})
        Me.LUEOvertimeType.Size = New System.Drawing.Size(260, 20)
        Me.LUEOvertimeType.TabIndex = 15
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(587, 67)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl9.TabIndex = 14
        Me.LabelControl9.Text = "-"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(401, 67)
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
        Me.LabelControl4.Location = New System.Drawing.Point(401, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "Created By"
        '
        'TECreatedBy
        '
        Me.TECreatedBy.Location = New System.Drawing.Point(480, 12)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(292, 20)
        Me.TECreatedBy.TabIndex = 8
        '
        'DEOvertimeDate
        '
        Me.DEOvertimeDate.EditValue = Nothing
        Me.DEOvertimeDate.Location = New System.Drawing.Point(124, 64)
        Me.DEOvertimeDate.Name = "DEOvertimeDate"
        Me.DEOvertimeDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEOvertimeDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOvertimeDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOvertimeDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEOvertimeDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEOvertimeDate.Size = New System.Drawing.Size(260, 20)
        Me.DEOvertimeDate.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(401, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Created At"
        '
        'TECreatedAt
        '
        Me.TECreatedAt.Location = New System.Drawing.Point(480, 38)
        Me.TECreatedAt.Name = "TECreatedAt"
        Me.TECreatedAt.Properties.ReadOnly = True
        Me.TECreatedAt.Size = New System.Drawing.Size(292, 20)
        Me.TECreatedAt.TabIndex = 5
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(34, 18)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Overtime Note"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SBMark)
        Me.PanelControl3.Controls.Add(Me.SBClose)
        Me.PanelControl3.Controls.Add(Me.SBSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 711)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(784, 50)
        Me.PanelControl3.TabIndex = 15
        '
        'SBMark
        '
        Me.SBMark.Image = CType(resources.GetObject("SBMark.Image"), System.Drawing.Image)
        Me.SBMark.Location = New System.Drawing.Point(5, 5)
        Me.SBMark.Name = "SBMark"
        Me.SBMark.Size = New System.Drawing.Size(75, 40)
        Me.SBMark.TabIndex = 3
        Me.SBMark.Text = "Mark"
        '
        'SBClose
        '
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(623, 5)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(75, 40)
        Me.SBClose.TabIndex = 2
        Me.SBClose.Text = "Close"
        '
        'SBSave
        '
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(702, 5)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 40)
        Me.SBSave.TabIndex = 1
        Me.SBSave.Text = "Save"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.LUEPayrollPeriod)
        Me.GroupControl3.Controls.Add(Me.LabelControl7)
        Me.GroupControl3.Controls.Add(Me.MEOvertimeNote)
        Me.GroupControl3.Controls.Add(Me.LabelControl6)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 586)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(784, 125)
        Me.GroupControl3.TabIndex = 15
        Me.GroupControl3.Text = "Detail"
        '
        'LUEPayrollPeriod
        '
        Me.LUEPayrollPeriod.Location = New System.Drawing.Point(124, 92)
        Me.LUEPayrollPeriod.Name = "LUEPayrollPeriod"
        Me.LUEPayrollPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUEPayrollPeriod.Size = New System.Drawing.Size(260, 20)
        Me.LUEPayrollPeriod.TabIndex = 16
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(34, 95)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl7.TabIndex = 13
        Me.LabelControl7.Text = "Payroll Period"
        '
        'MEOvertimeNote
        '
        Me.MEOvertimeNote.Location = New System.Drawing.Point(124, 16)
        Me.MEOvertimeNote.Name = "MEOvertimeNote"
        Me.MEOvertimeNote.Size = New System.Drawing.Size(648, 70)
        Me.MEOvertimeNote.TabIndex = 12
        '
        'FormEmpOvertimeDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 761)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.PanelControl3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpOvertimeDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overtime Detail"
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.TEOvertimeEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.GroupControl3.PerformLayout()
        CType(Me.LUEPayrollPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEOvertimeNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SBEmpDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBEmpAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECreatedAt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents LUEPayrollPeriod As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TETotalHours As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEOvertimeEnd As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents TEOvertimeStart As DevExpress.XtraEditors.TimeEdit
End Class
