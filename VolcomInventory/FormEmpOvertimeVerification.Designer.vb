<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpOvertimeVerification
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DESearch = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GCInfo1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCIdEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCOnlyDp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeePosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIdEmployeeStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCConversionType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIsDayOff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBProposed = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCStartWorkSub = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEndWorkSub = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCBreakHoursSub = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalHoursSub = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCAttendance = New DevExpress.XtraGrid.GridControl()
        Me.GVAttendance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DESearch.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DESearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.DESearch)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1008, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'SBView
        '
        Me.SBView.Location = New System.Drawing.Point(268, 10)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(75, 23)
        Me.SBView.TabIndex = 2
        Me.SBView.Text = "View"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Date"
        '
        'DESearch
        '
        Me.DESearch.EditValue = Nothing
        Me.DESearch.Location = New System.Drawing.Point(47, 12)
        Me.DESearch.Name = "DESearch"
        Me.DESearch.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESearch.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESearch.Size = New System.Drawing.Size(215, 20)
        Me.DESearch.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 676)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1008, 53)
        Me.PanelControl2.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.GCEmployee)
        Me.PanelControl3.Controls.Add(Me.GCAttendance)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(0, 46)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1008, 630)
        Me.PanelControl3.TabIndex = 2
        '
        'GCEmployee
        '
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(2, 2)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.Size = New System.Drawing.Size(504, 626)
        Me.GCEmployee.TabIndex = 0
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GCInfo1, Me.GBProposed})
        Me.GVEmployee.ColumnPanelRowHeight = 32
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GCIdEmployee, Me.GCOnlyDp, Me.GCDate, Me.GCIdDepartement, Me.GCDepartement, Me.GCEmployeeCode, Me.GCEmployeeName, Me.GCEmployeePosition, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCConversionType, Me.GCIsDayOff, Me.GCStartWorkSub, Me.GCEndWorkSub, Me.GCBreakHoursSub, Me.GCTotalHoursSub})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 2
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsView.AllowCellMerge = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDate, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCInfo1
        '
        Me.GCInfo1.Columns.Add(Me.GCIdEmployee)
        Me.GCInfo1.Columns.Add(Me.GCOnlyDp)
        Me.GCInfo1.Columns.Add(Me.GCIdDepartement)
        Me.GCInfo1.Columns.Add(Me.GCDepartement)
        Me.GCInfo1.Columns.Add(Me.GCDate)
        Me.GCInfo1.Columns.Add(Me.GCEmployeeCode)
        Me.GCInfo1.Columns.Add(Me.GCEmployeeName)
        Me.GCInfo1.Columns.Add(Me.GCEmployeePosition)
        Me.GCInfo1.Columns.Add(Me.GCIdEmployeeStatus)
        Me.GCInfo1.Columns.Add(Me.GCEmployeeStatus)
        Me.GCInfo1.Columns.Add(Me.GCConversionType)
        Me.GCInfo1.Columns.Add(Me.GCIsDayOff)
        Me.GCInfo1.Name = "GCInfo1"
        Me.GCInfo1.VisibleIndex = 0
        Me.GCInfo1.Width = 475
        '
        'GCIdEmployee
        '
        Me.GCIdEmployee.FieldName = "id_employee"
        Me.GCIdEmployee.Name = "GCIdEmployee"
        Me.GCIdEmployee.OptionsColumn.AllowEdit = False
        Me.GCIdEmployee.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCOnlyDp
        '
        Me.GCOnlyDp.FieldName = "only_dp"
        Me.GCOnlyDp.Name = "GCOnlyDp"
        Me.GCOnlyDp.OptionsColumn.AllowEdit = False
        Me.GCOnlyDp.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCIdDepartement
        '
        Me.GCIdDepartement.FieldName = "id_departement"
        Me.GCIdDepartement.Name = "GCIdDepartement"
        Me.GCIdDepartement.OptionsColumn.AllowEdit = False
        Me.GCIdDepartement.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.OptionsColumn.AllowEdit = False
        Me.GCDepartement.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCDate
        '
        Me.GCDate.Caption = "Date"
        Me.GCDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GCDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCDate.FieldName = "date"
        Me.GCDate.Name = "GCDate"
        Me.GCDate.OptionsColumn.AllowEdit = False
        Me.GCDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCEmployeeCode
        '
        Me.GCEmployeeCode.Caption = "Code"
        Me.GCEmployeeCode.FieldName = "employee_code"
        Me.GCEmployeeCode.Name = "GCEmployeeCode"
        Me.GCEmployeeCode.OptionsColumn.AllowEdit = False
        Me.GCEmployeeCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCEmployeeCode.Visible = True
        '
        'GCEmployeeName
        '
        Me.GCEmployeeName.Caption = "Name"
        Me.GCEmployeeName.FieldName = "employee_name"
        Me.GCEmployeeName.Name = "GCEmployeeName"
        Me.GCEmployeeName.OptionsColumn.AllowEdit = False
        Me.GCEmployeeName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCEmployeeName.Visible = True
        '
        'GCEmployeePosition
        '
        Me.GCEmployeePosition.Caption = "Position"
        Me.GCEmployeePosition.FieldName = "employee_position"
        Me.GCEmployeePosition.Name = "GCEmployeePosition"
        Me.GCEmployeePosition.OptionsColumn.AllowEdit = False
        Me.GCEmployeePosition.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCEmployeePosition.Visible = True
        Me.GCEmployeePosition.Width = 100
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
        Me.GCEmployeeStatus.Caption = "Status"
        Me.GCEmployeeStatus.FieldName = "employee_status"
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.GCEmployeeStatus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCEmployeeStatus.Visible = True
        '
        'GCConversionType
        '
        Me.GCConversionType.AppearanceHeader.Options.UseTextOptions = True
        Me.GCConversionType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCConversionType.Caption = "Conversion Type"
        Me.GCConversionType.FieldName = "conversion_type"
        Me.GCConversionType.Name = "GCConversionType"
        Me.GCConversionType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCConversionType.Visible = True
        '
        'GCIsDayOff
        '
        Me.GCIsDayOff.Caption = "Day Off"
        Me.GCIsDayOff.FieldName = "is_day_off"
        Me.GCIsDayOff.Name = "GCIsDayOff"
        Me.GCIsDayOff.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCIsDayOff.Visible = True
        '
        'GBProposed
        '
        Me.GBProposed.Caption = "Proposed"
        Me.GBProposed.Columns.Add(Me.GCStartWorkSub)
        Me.GBProposed.Columns.Add(Me.GCEndWorkSub)
        Me.GBProposed.Columns.Add(Me.GCBreakHoursSub)
        Me.GBProposed.Columns.Add(Me.GCTotalHoursSub)
        Me.GBProposed.Name = "GBProposed"
        Me.GBProposed.VisibleIndex = 1
        Me.GBProposed.Width = 400
        '
        'GCStartWorkSub
        '
        Me.GCStartWorkSub.AppearanceHeader.Options.UseTextOptions = True
        Me.GCStartWorkSub.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCStartWorkSub.Caption = "Start Work"
        Me.GCStartWorkSub.DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss"
        Me.GCStartWorkSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCStartWorkSub.FieldName = "start_work_sub"
        Me.GCStartWorkSub.MinWidth = 150
        Me.GCStartWorkSub.Name = "GCStartWorkSub"
        Me.GCStartWorkSub.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCStartWorkSub.Visible = True
        Me.GCStartWorkSub.Width = 150
        '
        'GCEndWorkSub
        '
        Me.GCEndWorkSub.AppearanceHeader.Options.UseTextOptions = True
        Me.GCEndWorkSub.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEndWorkSub.Caption = "End Work"
        Me.GCEndWorkSub.DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss"
        Me.GCEndWorkSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCEndWorkSub.FieldName = "end_work_sub"
        Me.GCEndWorkSub.MinWidth = 150
        Me.GCEndWorkSub.Name = "GCEndWorkSub"
        Me.GCEndWorkSub.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCEndWorkSub.Visible = True
        Me.GCEndWorkSub.Width = 150
        '
        'GCBreakHoursSub
        '
        Me.GCBreakHoursSub.AppearanceHeader.Options.UseTextOptions = True
        Me.GCBreakHoursSub.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCBreakHoursSub.Caption = "Break (hours)"
        Me.GCBreakHoursSub.DisplayFormat.FormatString = "N1"
        Me.GCBreakHoursSub.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBreakHoursSub.FieldName = "break_hours_sub"
        Me.GCBreakHoursSub.Name = "GCBreakHoursSub"
        Me.GCBreakHoursSub.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCBreakHoursSub.Visible = True
        Me.GCBreakHoursSub.Width = 50
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
        Me.GCTotalHoursSub.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCTotalHoursSub.Visible = True
        Me.GCTotalHoursSub.Width = 50
        '
        'GCAttendance
        '
        Me.GCAttendance.Dock = System.Windows.Forms.DockStyle.Right
        Me.GCAttendance.Location = New System.Drawing.Point(506, 2)
        Me.GCAttendance.MainView = Me.GVAttendance
        Me.GCAttendance.Name = "GCAttendance"
        Me.GCAttendance.Size = New System.Drawing.Size(500, 626)
        Me.GCAttendance.TabIndex = 1
        Me.GCAttendance.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAttendance, Me.GridView2})
        '
        'GVAttendance
        '
        Me.GVAttendance.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.GVAttendance.ColumnPanelRowHeight = 32
        Me.GVAttendance.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn4, Me.BandedGridColumn3, Me.BandedGridColumn1, Me.BandedGridColumn2})
        Me.GVAttendance.GridControl = Me.GCAttendance
        Me.GVAttendance.Name = "GVAttendance"
        Me.GVAttendance.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVAttendance.OptionsView.AllowCellMerge = True
        Me.GVAttendance.OptionsView.ColumnAutoWidth = False
        Me.GVAttendance.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 300
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Code"
        Me.BandedGridColumn4.FieldName = "employee_code"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Name"
        Me.BandedGridColumn3.FieldName = "employee_name"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Start Work"
        Me.BandedGridColumn1.FieldName = "start_work"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "End Work"
        Me.BandedGridColumn2.FieldName = "end_work"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCAttendance
        Me.GridView2.Name = "GridView2"
        '
        'FormEmpOvertimeVerification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormEmpOvertimeVerification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overtime Verification"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DESearch.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DESearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DESearch As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GCAttendance As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GCInfo1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GCIdEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCOnlyDp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeePosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCConversionType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIsDayOff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBProposed As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GCStartWorkSub As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEndWorkSub As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCBreakHoursSub As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalHoursSub As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GVAttendance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
