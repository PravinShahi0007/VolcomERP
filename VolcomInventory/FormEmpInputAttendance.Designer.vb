<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpInputAttendance
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
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTC = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRequest = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPEmployee = New DevExpress.XtraTab.XtraTabPage()
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
        Me.GCEmpAttnInput = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCreatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCreatedAt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.DETo = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTC.SuspendLayout()
        Me.XTPRequest.SuspendLayout()
        Me.XTPEmployee.SuspendLayout()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIDETime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIDETime.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DETo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 0)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(850, 512)
        Me.GCList.TabIndex = 0
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.Editable = False
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "id_emp_attn_input"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.FieldName = "id_report_status"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Report Status"
        Me.GridColumn4.FieldName = "report_status"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Created By"
        Me.GridColumn5.FieldName = "created_by"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Created At"
        Me.GridColumn6.FieldName = "created_at"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        '
        'XTC
        '
        Me.XTC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTC.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTC.Location = New System.Drawing.Point(0, 0)
        Me.XTC.Name = "XTC"
        Me.XTC.SelectedTabPage = Me.XTPRequest
        Me.XTC.Size = New System.Drawing.Size(856, 540)
        Me.XTC.TabIndex = 1
        Me.XTC.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRequest, Me.XTPEmployee})
        '
        'XTPRequest
        '
        Me.XTPRequest.Controls.Add(Me.GCList)
        Me.XTPRequest.Name = "XTPRequest"
        Me.XTPRequest.Size = New System.Drawing.Size(850, 512)
        Me.XTPRequest.Text = "By Request"
        '
        'XTPEmployee
        '
        Me.XTPEmployee.Controls.Add(Me.GCEmployee)
        Me.XTPEmployee.Controls.Add(Me.PanelControl1)
        Me.XTPEmployee.Name = "XTPEmployee"
        Me.XTPEmployee.Size = New System.Drawing.Size(850, 512)
        Me.XTPEmployee.Text = "By Employee"
        '
        'GCEmployee
        '
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(0, 43)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIDETime})
        Me.GCEmployee.Size = New System.Drawing.Size(850, 469)
        Me.GCEmployee.TabIndex = 1
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdEmpAttmInputDet, Me.GCIdDepartement, Me.GCDepartement, Me.GCIdEmployee, Me.GCEmployeeCode, Me.GCEmployeeName, Me.GCEmployeePosition, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCDate, Me.GCTimeIn, Me.GCTimeOut, Me.GCEmpAttnInput, Me.GCNumber, Me.GCIdReportStatus, Me.GCReportStatus, Me.GCCreatedBy, Me.GCCreatedAt})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsBehavior.Editable = False
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCIdEmpAttmInputDet
        '
        Me.GCIdEmpAttmInputDet.FieldName = "id_emp_attn_input_det"
        Me.GCIdEmpAttmInputDet.Name = "GCIdEmpAttmInputDet"
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
        Me.GCDepartement.Visible = True
        Me.GCDepartement.VisibleIndex = 0
        Me.GCDepartement.Width = 86
        '
        'GCIdEmployee
        '
        Me.GCIdEmployee.FieldName = "id_employee"
        Me.GCIdEmployee.Name = "GCIdEmployee"
        '
        'GCEmployeeCode
        '
        Me.GCEmployeeCode.Caption = "NIP"
        Me.GCEmployeeCode.FieldName = "employee_code"
        Me.GCEmployeeCode.Name = "GCEmployeeCode"
        Me.GCEmployeeCode.Visible = True
        Me.GCEmployeeCode.VisibleIndex = 0
        '
        'GCEmployeeName
        '
        Me.GCEmployeeName.Caption = "Employee"
        Me.GCEmployeeName.FieldName = "employee_name"
        Me.GCEmployeeName.Name = "GCEmployeeName"
        Me.GCEmployeeName.Visible = True
        Me.GCEmployeeName.VisibleIndex = 1
        '
        'GCEmployeePosition
        '
        Me.GCEmployeePosition.Caption = "Employee Position"
        Me.GCEmployeePosition.FieldName = "employee_position"
        Me.GCEmployeePosition.Name = "GCEmployeePosition"
        Me.GCEmployeePosition.Visible = True
        Me.GCEmployeePosition.VisibleIndex = 2
        Me.GCEmployeePosition.Width = 96
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
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.VisibleIndex = 3
        Me.GCEmployeeStatus.Width = 90
        '
        'GCDate
        '
        Me.GCDate.Caption = "Date"
        Me.GCDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GCDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCDate.FieldName = "date"
        Me.GCDate.Name = "GCDate"
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
        'GCEmpAttnInput
        '
        Me.GCEmpAttnInput.FieldName = "id_emp_attn_input"
        Me.GCEmpAttnInput.Name = "GCEmpAttnInput"
        '
        'GCNumber
        '
        Me.GCNumber.Caption = "Number"
        Me.GCNumber.FieldName = "number"
        Me.GCNumber.Name = "GCNumber"
        Me.GCNumber.Visible = True
        Me.GCNumber.VisibleIndex = 7
        '
        'GCIdReportStatus
        '
        Me.GCIdReportStatus.FieldName = "id_report_status"
        Me.GCIdReportStatus.Name = "GCIdReportStatus"
        '
        'GCReportStatus
        '
        Me.GCReportStatus.Caption = "Report Status"
        Me.GCReportStatus.FieldName = "report_status"
        Me.GCReportStatus.Name = "GCReportStatus"
        Me.GCReportStatus.Visible = True
        Me.GCReportStatus.VisibleIndex = 8
        Me.GCReportStatus.Width = 77
        '
        'GCCreatedBy
        '
        Me.GCCreatedBy.Caption = "Created By"
        Me.GCCreatedBy.FieldName = "created_by"
        Me.GCCreatedBy.Name = "GCCreatedBy"
        Me.GCCreatedBy.Visible = True
        Me.GCCreatedBy.VisibleIndex = 9
        '
        'GCCreatedAt
        '
        Me.GCCreatedAt.Caption = "Created At"
        Me.GCCreatedAt.FieldName = "created_at"
        Me.GCCreatedAt.Name = "GCCreatedAt"
        Me.GCCreatedAt.Visible = True
        Me.GCCreatedAt.VisibleIndex = 10
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.SBView)
        Me.PanelControl1.Controls.Add(Me.DETo)
        Me.PanelControl1.Controls.Add(Me.DEFrom)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(850, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(217, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "-"
        '
        'SBView
        '
        Me.SBView.Location = New System.Drawing.Point(440, 9)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(66, 23)
        Me.SBView.TabIndex = 2
        Me.SBView.Text = "View"
        '
        'DETo
        '
        Me.DETo.EditValue = Nothing
        Me.DETo.Location = New System.Drawing.Point(234, 11)
        Me.DETo.Name = "DETo"
        Me.DETo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DETo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETo.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DETo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETo.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DETo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DETo.Size = New System.Drawing.Size(200, 20)
        Me.DETo.TabIndex = 1
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(11, 11)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEFrom.Size = New System.Drawing.Size(200, 20)
        Me.DEFrom.TabIndex = 0
        '
        'FormEmpInputAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 540)
        Me.Controls.Add(Me.XTC)
        Me.Name = "FormEmpInputAttendance"
        Me.Text = "Input Attendance"
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTC.ResumeLayout(False)
        Me.XTPRequest.ResumeLayout(False)
        Me.XTPEmployee.ResumeLayout(False)
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIDETime.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIDETime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DETo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTC As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRequest As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPEmployee As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdEmpAttmInputDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeePosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTimeIn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIDETime As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GCTimeOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCreatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCreatedAt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmpAttnInput As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DETo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As Label
End Class
